Imports System.Data.SqlClient
Imports System.Runtime.InteropServices ' For Marshal (in CreateBitmap)
Imports System.Threading ' For Thread.Sleep (used in GetStatus)
Imports DPUruNet
Imports DPUruNet.Constants
Imports ECVENTA4.CONTROLUSUARIOS
Imports ECVENTA4.GENERAL
Imports Org.BouncyCastle.Asn1.Cmp
Public Class FrmHuellaEnroll

    Private preenrollmentFmds As New List(Of Fmd)() ' Stores FMDs during the multi-sample enrollment process
    Private enrollmentCount As Integer = 0 ' Counter for captures during enrollment
    Private enrolledTemplate As Fmd ' To hold the final enrolled FMD
    Private processingScan As Boolean = False ' Flag to prevent multiple processing for a single physical scan
    ' --- Scanner Global Declarations (Now aligned with Form_Main sample) ---
    Private _currentReader As Reader ' The fingerprint reader object (matches sample's internal field)

    Private _reset As Boolean ' From your original Form_Main sample for error handling

    Private _closing As Boolean = False

    ' Constant for probability calculations (from SDK samples)
    Private Const DPFJ_PROBABILITY_ONE As Integer = &H7FFFFFFF

    ' Delegates for thread-safe UI updates (fingerprint events run on a separate thread)
    Private Delegate Sub UpdateStatusDelegate(ByVal status As String)
    Private Delegate Sub UpdatePictureDelegate(ByVal bitmap As Bitmap)
    Private Delegate Sub ShowMessageBoxDelegate(ByVal message As String)
    ' --- End Scanner Global Declarations ---
    ' Public Property for the reader, as per Form_Main sample
    Public currentMode As FingerprintMode = FingerprintMode.None
    Dim xcon As SqlConnection
    Dim NombreEmpleado As String
    Dim EmpleadoID As Integer
    Dim JerarquiaRequerida As String
    Public Property EsLogin As Boolean = False
    Public Property VerificationResult As Boolean = False
    Public Property MatchedUserId As Integer?
    Public Property MatchedUserName As String
    Public Property MatchedUserRole As String
    Public Enum FingerprintMode
        None
        Enroll
        Verify
        Test
    End Enum
    Public Property CapturedFmd As DPUruNet.Fmd = Nothing
    Public Property CurrentReader() As Reader
        Get
            Return _currentReader
        End Get
        Set(ByVal value As Reader)
            _currentReader = value
            ' SendMessage(Action.UpdateReaderState, value) ' Original sample's call, we'll use UpdateStatus
            If value IsNot Nothing Then
                UpdateStatus("Reader selected: " & value.Description.Name)
                ' Potentially enable relevant scanner buttons here if they exist and are disabled by default
                ' e.g., btnEnroll.Enabled = True, btnVerify.Enabled = True
            Else
                UpdateStatus("No reader selected.")
            End If
        End Set
    End Property

    Public Sub New(ByRef con As SqlConnection, ByRef NombreEmp As String, ByRef IDEmp As Integer, ByVal Jerarquia As String)
        MyBase.New()
        InitializeComponent()
        xcon = con
        NombreEmpleado = NombreEmp
        EmpleadoID = IDEmp
        JerarquiaRequerida = Jerarquia
    End Sub
    Private Sub FrmHuellaEnroll_Load(sender As Object, e As EventArgs) Handles Me.Load
        If JerarquiaRequerida <> "" Then
            Me.Text = "Nivel Autorización: " & JerarquiaRequerida
        Else
            If Not EsLogin Then
                Me.Text = "Registro de Huella"
            Else
                Me.Text = "Acceso por Huella"
            End If
        End If
    End Sub



    ''' <summary>
    ''' Opens the currently selected fingerprint reader. (From Form_Main sample)
    ''' </summary>
    ''' <returns>Returns true if successful; false if unsuccessful</returns>
    Public Function OpenReader() As Boolean
        Dim result As Constants.ResultCode = Constants.ResultCode.DP_DEVICE_FAILURE

        _reset = False ' Reset flag from sample
        If CurrentReader Is Nothing Then
            UpdateStatus("No reader selected Or initialized.")
            Return False
        End If

        result = CurrentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)

        If result <> Constants.ResultCode.DP_SUCCESS Then
            MessageBox.Show("Error opening reader: " & result.ToString(), "Reader Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _reset = True
            Return False
        End If

        Return True
    End Function
    Public Function StartCaptureAsync(ByVal OnCaptured As Reader.CaptureCallback) As Boolean
        'AddHandler _currentReader.On_Captured, OnCaptured

        If Not CaptureFingerAsync() Then
            Return False
        End If

        Return True
    End Function
    ''' <summary>
    ''' Initiates a single asynchronous fingerprint capture using Reader.CaptureAsync.
    ''' This will trigger Reader.On_Captured event when data is available. (From Form_Main sample)
    ''' </summary>
    ''' <returns>Returns true if capture was successfully initiated, false if unsuccessful</returns>
    Public Function CaptureFingerAsync() As Boolean
        Try
            ' Evita iniciar captura si ya se está procesando otra
            If processingScan Then
                UpdateStatus("Capture request skipped: another scan is in progress.")
                Return False
            End If

            ' Verifica estado del lector antes de capturar
            Try
                GetStatus()
            Catch ex As Exception
                UpdateStatus("GetStatus error (possibly device busy): " & ex.Message)
                Return False
            End Try

            Dim captureResultCode As Constants.ResultCode = CurrentReader.CaptureAsync(
            Formats.Fid.ANSI,
            Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT,
            CurrentReader.Capabilities.Resolutions(0)
        )

            If captureResultCode <> Constants.ResultCode.DP_SUCCESS Then
                _reset = True
                Throw New Exception("Failed to start CaptureAsync: " & captureResultCode.ToString())
            End If

            Return True
        Catch ex As Exception
            'UpdateStatus("Capture initiation error: " & ex.Message)
            Return False
        End Try
    End Function
    Public Function OrigCaptureFingerAsync() As Boolean
        Try
            If CurrentReader Is Nothing Then
                UpdateStatus("No reader initialized.")
                Return False
            End If

            GetStatus() ' Check reader status before capturing

            Dim captureResultCode As Constants.ResultCode = CurrentReader.CaptureAsync(
            Formats.Fid.ANSI,
            Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT,
            CurrentReader.Capabilities.Resolutions(0) ' Use the first supported resolution
        )

            If captureResultCode <> Constants.ResultCode.DP_SUCCESS Then
                _reset = True
                Throw New Exception("Failed to start CaptureAsync: " & captureResultCode.ToString())
            End If

            Return True
        Catch ex As Exception
            'MessageBox.Show("Error initiating fingerprint capture: " & ex.Message, "Capture Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Checks the device status before starting capture. (From Form_Main sample)
    ''' </summary>
    Public Sub GetStatus()
        Dim result As Constants.ResultCode = CurrentReader.GetStatus()

        If result <> Constants.ResultCode.DP_SUCCESS Then
            If CurrentReader IsNot Nothing Then
                _reset = True
                Throw New Exception("Failed to get reader status: " & result.ToString())
            End If
        End If

        If CurrentReader.Status.Status = Constants.ReaderStatuses.DP_STATUS_BUSY Then
            Thread.Sleep(50) ' Wait a bit if busy
        ElseIf CurrentReader.Status.Status = Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION Then
            CurrentReader.Calibrate() ' Calibrate if needed
        ElseIf CurrentReader.Status.Status <> Constants.ReaderStatuses.DP_STATUS_READY Then
            Throw New Exception("Reader Status - " & CurrentReader.Status.Status.ToString())
        End If
    End Sub

    ''' <summary>
    ''' Cancel the capture and then close the reader. (From Form_Main sample)
    ''' </summary>

    Public Sub CancelCaptureAndCloseReader(Optional ByVal captureHandler As Reader.CaptureCallback = Nothing)
        If _currentReader Is Nothing Then Exit Sub

        Try
            ' Paso 1: Remover handler si lo pasaron
            If captureHandler IsNot Nothing Then
                RemoveHandler _currentReader.On_Captured, captureHandler
            End If

            ' Paso 2: Obtener estatus
            Dim statusResult = _currentReader.GetStatus()
            If statusResult = Constants.ResultCode.DP_SUCCESS Then
                Dim readerStatus = _currentReader.Status.Status
                If readerStatus = Constants.ReaderStatuses.DP_STATUS_BUSY Then
                    Console.WriteLine("Reader busy, skipping CancelCapture()")
                Else
                    _currentReader.CancelCapture()
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("CancelCapture error: " & ex.Message)
        End Try

        Try
            _currentReader.Dispose()
            _currentReader = Nothing
            UpdateStatus("Reader closed and resources released.")
        Catch ex As Exception
            Console.WriteLine("Dispose error: " & ex.Message)
        End Try
    End Sub



    ''' <summary>
    ''' Check quality of the resulting capture. (From Form_Main sample)
    ''' </summary>
    Public Function CheckCaptureResult(ByVal captureResult As CaptureResult) As Boolean
        If captureResult.Data Is Nothing OrElse captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
            If captureResult.ResultCode <> Constants.ResultCode.DP_SUCCESS Then
                _reset = True
                ' Original sample threw exception: Throw New Exception("" & captureResult.ResultCode.ToString())
                UpdateStatus("Capture Error (SDK Result): " & captureResult.ResultCode.ToString())
                Return False
            End If

            ' If ResultCode is success but quality is not good (and not canceled)
            If captureResult.Quality <> Constants.CaptureQuality.DP_QUALITY_GOOD Then ' Corrected access to Quality
                If captureResult.Quality = Constants.CaptureQuality.DP_QUALITY_CANCELED Then
                    UpdateStatus("Capture canceled by user.")
                Else
                    UpdateStatus("Bad quality capture: " & captureResult.Quality.ToString() & ". Please try again.")
                End If
                ' Original sample threw exception: Throw New Exception("Quality - " & captureResult.Quality.ToString())
                Return False
            End If
            Return False ' If ResultCode is not success, return False
        End If
        Return True ' Capture is good and ready for processing
    End Function

    ''' <summary>
    ''' Create a bitmap from raw data in row/column format. (Your version, previously provided)
    ''' </summary>
    Public Function CreateBitmap(ByVal rawImage() As Byte, ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim bitmap As New Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
        Dim rect As New Rectangle(0, 0, width, height)
        Dim bmpData As System.Drawing.Imaging.BitmapData = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat)

        Dim stride As Integer = bmpData.Stride
        Dim ptr As IntPtr = bmpData.Scan0

        For y As Integer = 0 To height - 1
            Marshal.Copy(rawImage, y * width, New IntPtr(ptr.ToInt64() + y * stride), width)
        Next

        bitmap.UnlockBits(bmpData)

        Dim pal As System.Drawing.Imaging.ColorPalette = bitmap.Palette
        For i As Integer = 0 To 255
            pal.Entries(i) = System.Drawing.Color.FromArgb(i, i, i)
        Next
        bitmap.Palette = pal

        Return bitmap
    End Function

    ' --- Core Fingerprint Capture and Processing ---

    ''' <summary>
    ''' Handler for when a fingerprint is captured by the reader.
    ''' This method is called asynchronously by the SDK via Reader.On_Captured.
    ''' </summary>
    ''' <param name="captureResult">Contains info and data on the fingerprint capture.</param>
    Public Sub OnCaptured(ByVal captureResult As CaptureResult)
        If Me.InvokeRequired Then
            'Me.Invoke(New MethodInvoker(Sub() OnCaptured(captureResult)))
            Me.BeginInvoke(New Action(Of CaptureResult)(AddressOf OnCaptured), captureResult)
            Return
        End If

        If _closing OrElse Me.IsDisposed Then Return

        ' Evita doble procesamiento
        If processingScan Then Return
        processingScan = True

        Try
            ' Verifica que la captura sea válida
            If Not CheckCaptureResult(captureResult) Then
                If captureResult.ResultCode <> Constants.ResultCode.DP_DEVICE_BUSY Then
                    SafeRestartCapture()
                Else
                    UpdateStatus("Device busy, will retry automatically.")
                End If
                Return
            End If

            ' Mostrar imagen
            For Each fiv As Fid.Fiv In captureResult.Data.Views
                UpdatePicture(CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height))
                Exit For
            Next

            ' Dirigir a flujo según modo
            Select Case currentMode
                Case FingerprintMode.Enroll
                    ProcessEnrollmentCapture(captureResult)
                Case FingerprintMode.Verify
                    ProcessVerificationCapture(captureResult)
                Case FingerprintMode.Test

                Case Else
                    UpdateStatus("Lectura de Huella capturada, pero no hay modo seleccionado.")
                    SafeRestartCapture()
            End Select
        Catch ex As Exception
            UpdateStatus("Unhandled error in OnCaptured: " & ex.Message)
            SafeRestartCapture()
        End Try
    End Sub
    Private Sub SafeRestartCaptureOriginal(Optional delayMs As Integer = 200)
        Dim t As New System.Windows.Forms.Timer()
        t.Interval = delayMs
        AddHandler t.Tick, Sub()
                               t.Stop()
                               t.Dispose()
                               processingScan = False
                               If CurrentReader IsNot Nothing Then CaptureFingerAsync()
                           End Sub
        t.Start()
    End Sub
    ' --- UI Helper Functions (for thread-safe updates) ---

    'Private Sub UpdateStatus(ByVal status As String)
    '    If Me.InvokeRequired Then
    '        Me.Invoke(New UpdateStatusDelegate(AddressOf UpdateStatus), New Object() {status})
    '    Else
    '        lblStatus.Text = "Status: " & status
    '        Application.DoEvents() ' Process UI messages to ensure immediate update            
    '    End If
    'End Sub

    Private Sub UpdateStatus(ByVal status As String)
        Try
            ' Si el form ya está cerrando, sal sin hacer nada
            If Me.IsDisposed OrElse Me.Disposing Then Return
            If Not Me.IsHandleCreated Then Return

            If Me.InvokeRequired Then
                Me.BeginInvoke(New Action(Of String)(AddressOf UpdateStatus), status)
                Return
            End If

            If lblStatus Is Nothing OrElse lblStatus.IsDisposed Then Return

            lblStatus.Text = "Status: " & status

            ' Si quieres “refresco inmediato”, usa Update/Refresh del control, NO DoEvents
            lblStatus.Invalidate()
            lblStatus.Update()   ' o lblStatus.Refresh()
        Catch ex As Exception
            Debug.WriteLine("UpdateStatus error: " & ex.Message)
        End Try
    End Sub


    'Private Sub UpdatePicture(ByVal bitmap As Bitmap)
    '    If Me.InvokeRequired Then
    '        Me.Invoke(New UpdatePictureDelegate(AddressOf UpdatePicture), New Object() {bitmap})
    '    Else
    '        If pbFingerprint.Image IsNot Nothing Then
    '            pbFingerprint.Image.Dispose()
    '        End If
    '        pbFingerprint.Image = bitmap
    '        pbFingerprint.Refresh()
    '    End If
    'End Sub
    Private Sub UpdatePicture(ByVal bitmap As Bitmap)
        Try
            If bitmap Is Nothing Then Return

            If Me.IsDisposed OrElse Me.Disposing Then
                bitmap.Dispose()
                Return
            End If
            If Not Me.IsHandleCreated Then
                bitmap.Dispose()
                Return
            End If

            If Me.InvokeRequired Then
                Me.BeginInvoke(New Action(Of Bitmap)(AddressOf UpdatePicture), bitmap)
                Return
            End If

            Dim oldImg = pbFingerprint.Image
            pbFingerprint.Image = bitmap
            pbFingerprint.Invalidate()
            pbFingerprint.Update()

            If oldImg IsNot Nothing Then oldImg.Dispose()
        Catch ex As Exception
            Debug.WriteLine("UpdatePicture error: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowMessageBox(ByVal message As String)
        If Me.InvokeRequired Then
            Me.Invoke(New ShowMessageBoxDelegate(AddressOf ShowMessageBox), New Object() {message})
        Else
            MessageBox.Show(message)
        End If
    End Sub

    ' --- Enrollment Logic ---
    Private Sub EnrollProcess(ByVal EmpleadoID As Integer)
        enrolledTemplate = Nothing
        preenrollmentFmds.Clear()
        enrollmentCount = 0

        Me.Text = "Registro de Huella"
        UpdateStatus("Registrar: Coloque el mismo dedo de 4 a 5 veces para un registro correcto.")
        pbFingerprint.Image = Nothing

        processingScan = False ' Ensure flag is reset to allow first capture
        If CurrentReader IsNot Nothing Then CaptureFingerAsync() ' Initiate first scan for this mode
    End Sub

    ''' <summary>
    ''' Processes a captured fingerprint during the enrollment phase.
    ''' Collects multiple FMDs and creates a single enrollment FMD.
    ''' </summary>
    ''' <param name="captureResult">The result from the live fingerprint capture.</param>

    Private Sub ProcessEnrollmentCapture(ByVal captureResult As CaptureResult)
        enrollmentCount += 1
        Dim capturedWidth As Integer = 0
        Dim capturedHeight As Integer = 0
        Dim capturedResolution As Integer = 0
        If captureResult.Data.Views.Count > 0 Then
            capturedWidth = captureResult.Data.Views(0).Width
            capturedHeight = captureResult.Data.Views(0).Height
            capturedResolution = If(CurrentReader IsNot Nothing AndAlso CurrentReader.Capabilities.Resolutions.Length > 0, CurrentReader.Capabilities.Resolutions(0), 500)
        End If

        Dim resultConversion As DataResult(Of Fmd) = DPUruNet.FeatureExtraction.CreateFmdFromFid(captureResult.Data, DPUruNet.Constants.Formats.Fmd.ANSI)
        If resultConversion.ResultCode <> DPUruNet.Constants.ResultCode.DP_SUCCESS Then
            UpdateStatus("Error extracting features: " & resultConversion.ResultCode.ToString())
            preenrollmentFmds.Clear()
            enrollmentCount = 0
            Me.Text = "Fingerprint App"
            processingScan = False
            If CurrentReader IsNot Nothing Then CaptureFingerAsync()
            Return
        End If
        preenrollmentFmds.Add(resultConversion.Data)
        UpdateStatus("Added sample " & enrollmentCount & ": FMD size=" & If(resultConversion.Data IsNot Nothing AndAlso resultConversion.Data.Bytes IsNot Nothing, resultConversion.Data.Bytes.Length, 0) & " bytes")

        If enrollmentCount < 4 Then
            UpdateStatus("Enrollment: Captured sample " & enrollmentCount & ". Place the same finger again.")
            processingScan = False
            If CurrentReader IsNot Nothing Then CaptureFingerAsync()
        ElseIf enrollmentCount >= 4 Then
            Dim resultEnrollment As DataResult(Of Fmd) = DPUruNet.Enrollment.CreateEnrollmentFmd(DPUruNet.Constants.Formats.Fmd.ANSI, preenrollmentFmds)
            If resultEnrollment.ResultCode = DPUruNet.Constants.ResultCode.DP_SUCCESS Then
                enrolledTemplate = resultEnrollment.Data

                If enrolledTemplate Is Nothing OrElse enrolledTemplate.Bytes Is Nothing OrElse enrolledTemplate.Bytes.Length = 0 Then
                    UpdateStatus("Error: Enrollment created invalid template. Bytes: " & If(enrolledTemplate IsNot Nothing AndAlso enrolledTemplate.Bytes IsNot Nothing, enrolledTemplate.Bytes.Length, "null"))
                    preenrollmentFmds.Clear()
                    enrollmentCount = 0
                    Me.Text = "Fingerprint App"
                    processingScan = False
                    If CurrentReader IsNot Nothing Then CaptureFingerAsync()
                    Return
                End If
                UpdateStatus("Enrollment complete! Template size: " & enrolledTemplate.Bytes.Length & " bytes")
                Me.CapturedFmd = enrolledTemplate
                Me.DialogResult = DialogResult.OK
                Me.Close()
                'SaveTemplateToDatabase(enrolledTemplate) ' Metadata no longer needed
            Else
                UpdateStatus("Enrollment failed: " & resultEnrollment.ResultCode.ToString())
                preenrollmentFmds.Clear()
                enrollmentCount = 0
                Me.Text = "Fingerprint App"
                processingScan = False
                If CurrentReader IsNot Nothing Then CaptureFingerAsync()
            End If
        End If
    End Sub
    ''' <summary>
    ''' Saves the enrolled fingerprint template and user data to the SQL Server database.
    ''' </summary>
    ''' <param name="fmd">The byte array of the FMD (fingerprint template).</param>   

    Private Sub SaveTemplateToDatabase(fmd As Fmd)
        Dim sql As String = "
        UPDATE ecusuariosx
        SET FingerprintTemplate = @Template
        WHERE emp_nomina = @ID
    "

        Using cmd As New SqlCommand(sql, xcon)
            cmd.Parameters.AddWithValue("@Template", fmd.Bytes)
            cmd.Parameters.AddWithValue("@ID", EmpleadoID)

            Try
                If xcon.State = ConnectionState.Closed Then xcon.Open()
                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    UpdateStatus("Huella guardada correctamente para: " & NombreEmpleado)
                Else
                    ShowMessageBox("Usuario no encontrado.")
                End If
            Catch ex As Exception
                ShowMessageBox("Error al guardar huella: " & ex.Message)
            End Try
        End Using
    End Sub
    Private Function MatchFingerprintToUser(ByVal capturedFmd As Fmd) As StoredUserTemplate
        Dim matchThreshold As Integer = DPFJ_PROBABILITY_ONE / 100000
        Dim query As String = "SELECT UserID, FirstName, LastName, emp_tipo, FingerprintTemplate FROM Users WHERE FingerprintTemplate IS NOT NULL"

        Using cmd As New SqlCommand(query, xcon)
            If xcon.State = ConnectionState.Closed Then xcon.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim templateBytes() As Byte = CType(reader("FingerprintTemplate"), Byte())
                    Dim storedFmd As New Fmd(templateBytes, DPUruNet.Constants.Formats.Fmd.ANSI, "1.0.0")
                    Dim compareResult = DPUruNet.Comparison.Compare(capturedFmd, 0, storedFmd, 0)

                    If compareResult.ResultCode = DPUruNet.Constants.ResultCode.DP_SUCCESS AndAlso compareResult.Score < matchThreshold Then
                        Return New StoredUserTemplate(
                        reader.GetInt32(reader.GetOrdinal("UserID")),
                        reader.GetString(reader.GetOrdinal("FirstName")),
                        reader.GetString(reader.GetOrdinal("LastName")),
                        storedFmd,
                        reader.GetString(reader.GetOrdinal("UserRole"))
                    )
                    End If
                End While
            End Using
        End Using

        Return Nothing
    End Function
    Private Sub ProcessVerificationCapture(ByVal captureResult As CaptureResult)
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(Sub() ProcessVerificationCapture(captureResult)))
            Return
        End If

        Try
            If Not CheckCaptureResult(captureResult) Then
                processingScan = False
                If CurrentReader IsNot Nothing Then CaptureFingerAsync() ' Re-initiate capture if bad quality
                Return
            End If

            Dim capturedFmdResult As DataResult(Of Fmd) = DPUruNet.FeatureExtraction.CreateFmdFromFid(captureResult.Data, DPUruNet.Constants.Formats.Fmd.ANSI)

            If capturedFmdResult.ResultCode <> DPUruNet.Constants.ResultCode.DP_SUCCESS Then
                UpdateStatus("Error extracting features for verification: " & capturedFmdResult.ResultCode.ToString() & ". Please try again.")
                Me.Text = "Fingerprint App"
                processingScan = False
                If CurrentReader IsNot Nothing Then CaptureFingerAsync() ' Re-initiate capture
                Return
            End If

            Dim capturedFmd As Fmd = capturedFmdResult.Data
            Dim userIdToVerify As Integer
            If EmpleadoID <> -1 Then
                If Not Integer.TryParse(EmpleadoID, userIdToVerify) Then
                    UpdateStatus("Invalid User ID entered for verification. Please enter a number.")
                    Me.Text = "Fingerprint App"
                    processingScan = False
                    If CurrentReader IsNot Nothing Then CaptureFingerAsync() ' Re-initiate capture
                    Return
                End If
            End If

            Dim storedUserTemplate As StoredUserTemplate = Nothing

            Dim matchThreshold As Integer = DPFJ_PROBABILITY_ONE / 100000 ' Ajusta sensibilidad
            Dim bestScore As Integer = DPFJ_PROBABILITY_ONE
            Dim matchedUser As StoredUserTemplate = Nothing
            Dim query As String

            'query = "SELECT emp_nomina,emp_nombre,emp_password, FingerprintTemplate,emp_tipo FROM ecusuariosx WHERE FingerprintTemplate IS NOT NULL" & If(JerarquiaRequerida <> "", " and emp_tipo='" & JerarquiaRequerida & "' ", "")
            query = "SELECT emp_nomina, emp_nombre, emp_password, FingerprintTemplate, emp_tipo FROM ecusuariosx WHERE FingerprintTemplate IS NOT NULL AND (@jer = '' OR emp_tipo = @jer);"

            Using command As New SqlCommand(query, xcon)
                command.Parameters.Add("@jer", SqlDbType.VarChar, 30).Value = JerarquiaRequerida.Trim()
                If xcon.State = ConnectionState.Closed Then xcon.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim templateBytes() As Byte = CType(reader("FingerprintTemplate"), Byte())
                        Dim storedFmd As New Fmd(templateBytes, DPUruNet.Constants.Formats.Fmd.ANSI, "1.0.0")

                        Dim compareResult = DPUruNet.Comparison.Compare(capturedFmd, 0, storedFmd, 0)

                        If compareResult.ResultCode = DPUruNet.Constants.ResultCode.DP_SUCCESS Then
                            If compareResult.Score <= matchThreshold AndAlso compareResult.Score < bestScore Then
                                If EmpleadoID = -1 OrElse EmpleadoID = reader.GetInt32(reader.GetOrdinal("emp_nomina")) Then
                                    bestScore = compareResult.Score
                                    matchedUser = New StoredUserTemplate(
                                    reader.GetInt32(reader.GetOrdinal("emp_nomina")),
                                    reader.GetString(reader.GetOrdinal("emp_nombre")),
                                    reader.GetString(reader.GetOrdinal("emp_password")),
                                    storedFmd,
                                    reader.GetString(reader.GetOrdinal("emp_tipo"))
                                )
                                ElseIf EmpleadoID <> -1 AndAlso EmpleadoID <> reader.GetInt32(reader.GetOrdinal("emp_nomina")) Then
                                    UpdateStatus("No coincide huella con el usuario requerido (" & reader.GetString(reader.GetOrdinal("emp_nombre")) & ")")
                                End If
                            End If
                        End If
                    End While
                End Using
            End Using
            If matchedUser IsNot Nothing Then
                _closing = True          ' <- corta cualquier reinicio/captura
                processingScan = False   ' <- libera

                VerificationResult = True
                MatchedUserId = matchedUser.UserID
                MatchedUserName = matchedUser.FirstName   ' o el campo correcto (emp_nombre)
                MatchedUserRole = matchedUser.UserRole
                UpdateStatus("Fingerprint matched! Bienvenido, " & matchedUser.FirstName)

                Me.BeginInvoke(Sub()
                                   Me.DialogResult = DialogResult.OK
                                   Me.Close()
                               End Sub)

                'Me.DialogResult = DialogResult.OK
                'Me.Close()
                'ShowMessageBox("Acceso concedido para " & matchedUser.FirstName)
            Else
                VerificationResult = False
                MatchedUserId = Nothing
                MatchedUserName = Nothing
                UpdateStatus("Huella no coincide con ningún usuario registrado.")
                processingScan = False
                If CurrentReader IsNot Nothing Then CaptureFingerAsync()
                'ShowMessageBox("Acceso denegado.")
            End If

            If CurrentReader IsNot Nothing Then CaptureFingerAsync() ' Re-initiate capture after completion
        Catch ex As Exception
            UpdateStatus("Unhandled Error during verification: " & ex.Message)
            Me.Text = "Fingerprint App"
            processingScan = False
            If CurrentReader IsNot Nothing Then CaptureFingerAsync() ' Re-initiate capture after error
        End Try
    End Sub
    Private Sub FrmHuellaEnroll_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CancelCaptureAndCloseReader(AddressOf Me.OnCaptured) ' No parameter needed now, as handler is removed inside
    End Sub

    Private Sub FrmHuellaEnroll_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        _closing = True

        Dim r As DPUruNet.Reader = _currentReader   ' o Dim r As Reader = _currentReader
        _currentReader = Nothing
        If r Is Nothing Then Return

        Try
            RemoveHandler r.On_Captured, AddressOf Me.OnCaptured
        Catch
        End Try

        ' Cerrar en background para que NO congele la UI
        Threading.Tasks.Task.Run(Sub()
                                     Try
                                         Try : r.CancelCapture() : Catch : End Try
                                         Try : r.Dispose() : Catch : End Try
                                     Catch
                                     End Try
                                 End Sub)
    End Sub
    Private Sub SafeRestartCapture(Optional delayMs As Integer = 200)
        If _closing OrElse Me.IsDisposed Then Return

        Dim t As New System.Windows.Forms.Timer()
        t.Interval = delayMs
        AddHandler t.Tick, Sub()
                               t.Stop()
                               t.Dispose()

                               If _closing OrElse Me.IsDisposed Then Return

                               processingScan = False
                               If CurrentReader IsNot Nothing Then CaptureFingerAsync()
                           End Sub
        t.Start()
    End Sub

    Public Sub ConfigureForLogin(Optional ByVal jerarquia As String = "")
        currentMode = FingerprintMode.Verify
        JerarquiaRequerida = jerarquia

        ' Hide/disable any enrollment-only controls if you have them
        ' e.g., btnEnroll.Visible = False : lblEnrollHelp.Visible = False

        Text = If(String.IsNullOrEmpty(jerarquia), "Inicio de sesión por huella", "Inicio de sesión · " & jerarquia)
        lblStatus.Text = "Status: Inicializando lector…"

        ' Good UX defaults for a login popup
        StartPosition = FormStartPosition.CenterScreen
        ShowInTaskbar = False
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        KeyPreview = True
    End Sub

    Private Sub FrmHuellaEnroll_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        preenrollmentFmds.Clear()
        enrollmentCount = 0

        ' Find and select the first available reader
        Dim devices As ReaderCollection = ReaderCollection.GetReaders()
        If devices.Count = 0 Then
            UpdateStatus("No existen lectores disponibles. Asegúrese que el dispositivo esté conectado y que cuente con los controladores instalados.")
            Return
        Else
            CurrentReader = devices(0) ' Assign the found reader to the CurrentReader property
        End If

        ' Open the reader (using the logic from your original sample's OpenReader)
        If Not OpenReader() Then
            UpdateStatus("Error: No puede abrirse el lector. La funcionalidad estará limitada.")
            Return
        End If

        ' Add the event handler for when the reader captures data (THIS IS Reader.On_Captured, as per your reports)
        RemoveHandler CurrentReader.On_Captured, AddressOf Me.OnCaptured ' Evita duplicados
        AddHandler CurrentReader.On_Captured, AddressOf Me.OnCaptured

        ' Initiate the *first* capture. Subsequent captures are triggered after processing in OnCaptured.
        If Not CaptureFingerAsync() Then
            UpdateStatus("Error: No pudo tomarse la primera lectura. La funcionalidad estará limitada.")
            Return
        End If

        UpdateStatus("Lector Inicializado. Coloque el dedo a registrar o verificar.")

    End Sub

End Class