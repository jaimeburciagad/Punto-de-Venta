Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Web.Services
Imports FarPoint.Win.Spread
Imports Microsoft.Office.Interop.Excel

Public Class Devoluciones
    Public xCon As SqlConnection
    Dim RequiereSUP As Boolean
    Dim VengoDe As String

    Dim FilaSig, UltRowMatch As Integer
    Dim UltStrBusc As String
    Dim Looped As Boolean

    Dim totalote As Double
    Dim Corriendo As Boolean
    'Dim foma As Form
    Dim Inicializando As Boolean
    Public Sub New(ByRef con As String)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        Corriendo = True
        InitializeComponent()
        xCon = New SqlConnection(sCadenaConexionSQL)

        'foma = fom
        Corriendo = False
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    Public Sub imprimeTicket(ByRef pre As Collection)
        Dim oImpresion As Impresion
        oImpresion = New Impresion(pre)
        oImpresion.imprime(True)
    End Sub
    Public Sub BtnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegresar.Click
        Me.Close()
    End Sub

    Private Sub Devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Globales.caja = "vscaja7" Then
            CmbCaja.Visible = True
            LbCaja.Visible = True
        Else
            CmbCaja.Visible = False
            LbCaja.Visible = False
        End If

        TxtMotivo.Text = ""
        TxtNumTicket.Focus()
        RequiereSUP = False
        VengoDe = ""
        Inicializando = True

        If Globales.Remoto Then
            If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
                Label45.BackColor = Color.Blue
                Label45.Text = "Duarsa 2"
                Me.Text = "D2 - " & "Devolución de Mercancía"
            Else
                Label45.BackColor = Color.SlateBlue
                Label45.Text = "Duarsa 1"
                Me.Text = "D1 - " & "Devolución de Mercancía"
            End If
        Else
            If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
                Label45.BackColor = Color.SlateBlue
                Label45.Text = "Duarsa 1"
                Me.Text = "D1 - " & "Devolución de Mercancía"
            Else
                Label45.BackColor = Color.Blue
                Label45.Text = "Duarsa 2"
                Me.Text = "D2 - " & "Devolución de Mercancía"
            End If
        End If


        FormateaSpread()

        ConfiguraSpread.RellenaCmbBuscar(FpSpreadDevoluciones, CmbColumnasBuscar, CmbBuscaIndex, ColInd:=2, InicializandoVista:=False)

        TxtNumTicket.Focus()
    End Sub
    Private Sub RellenaCmbBuscar(Optional ByVal InicializandoVista As Boolean = True)
        CmbColumnasBuscar.Items.Clear()
        CmbBuscaIndex.Items.Clear()

        Dim Titulo As String = ""
        Dim Subtitulo As String = ""
        Dim IndCol, SubIndCol As Integer
        Dim TitColSpan As Integer = 0
        Dim SubTitColSpan As Integer = 0
        For c As Integer = 0 To FpSpreadDevoluciones.ActiveSheet.Columns.Count - 1
            If FpSpreadDevoluciones.ActiveSheet.Columns(c).Visible Then
                If FpSpreadDevoluciones.ActiveSheet.ColumnHeader.RowCount > 1 Then
                    If FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(0, c).ColumnSpan > 1 Then
                        Titulo = FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(0, c).Text
                        IndCol = c
                        TitColSpan = c + FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(0, c).ColumnSpan - 1
                    Else
                        If c > TitColSpan Then
                            Titulo = ""
                        End If
                    End If

                    If FpSpreadDevoluciones.ActiveSheet.ColumnHeader.RowCount = FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(0, c).RowSpan Then
                        CmbColumnasBuscar.Items.Add(FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(0, c).Text)
                        CmbBuscaIndex.Items.Add(c)
                    Else
                        Dim HeadCol As String = ""
                        For FC As Integer = 0 To FpSpreadDevoluciones.ActiveSheet.ColumnHeader.RowCount - 1
                            If FC > 0 Then
                                If FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).ColumnSpan > 1 Then
                                    Subtitulo = FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).Text
                                    SubIndCol = c
                                    SubTitColSpan = c + FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).ColumnSpan - 1
                                End If
                            End If
                            HeadCol = (IIf(Titulo <> FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).Text And (c > IndCol And c <= TitColSpan) And HeadCol = "", Titulo & " - ", "") & IIf(Subtitulo <> FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).Text And (c > SubIndCol And c <= SubTitColSpan) And HeadCol = "", Subtitulo & " - ", "") & IIf(HeadCol = "", FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).Text, HeadCol & " - " & FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).Text)).ToString.Replace(" -  - ", " - ")

                            If FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).RowSpan > 1 Then
                                FC += FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(FC, c).RowSpan - 1
                            End If
                        Next
                        If HeadCol.Replace(" - ", "").Trim = (Titulo & " - " & IIf(Subtitulo <> "", Subtitulo & " - ", "")).Replace(" - ", "").trim Then
                            HeadCol = ""
                        End If
                        CmbColumnasBuscar.Items.Add(HeadCol)
                        CmbBuscaIndex.Items.Add(c)
                    End If
                Else 'Headers es una sola fila
                    CmbColumnasBuscar.Items.Add(FpSpreadDevoluciones.ActiveSheet.ColumnHeader.Cells(0, c).Text)
                    CmbBuscaIndex.Items.Add(c)
                End If
            End If

        Next

        CmbColumnasBuscar.SelectedIndex = CmbBuscaIndex.Items.IndexOf(CInt(2))
    End Sub
    Private Sub RellenaTicket(ByVal Ticket As Integer)
        Dim dsc As New DataSet
        Dim sql As String
        Dim i As Integer

        FpSpreadDevoluciones.ActiveSheet.RowCount = 0

        sql = "select*from ecventa where ven_id='" & TxtNumTicket.Text.Trim & "'"
        Base.daQuery(sql, sCadenaConexionSQL, dsc, "art")
        RequiereSUP = False
        If dsc.Tables("Art").Rows.Count > 0 Then
            If (DateAndTime.DateDiff(DateInterval.Minute, CDate(dsc.Tables("art").Rows(0)("ven_fecha")), Now) > 15) Then
                MsgBox("El ticket excede el tiempo definido, no pueden hacerse la devolución. Se requiere de autorización especial.", vbExclamation, "Devolución de Mercancía")
                BtnGuardar.Enabled = False
                RequiereSUP = True
                Corriendo = True
                Dim auth As FingerprintAuthResult = AutorizacionConHuella.PromptFingerprint(xCon, "SUP", -1, Me)
                If auth.Approved Then
                    RegistroHistorial.HistorialAutorizaciones(xCon, My.Computer.Name, auth.UserName, TxtNumTicket.Text.Trim, "Devolución Tiempo Excedido", "Devolución de Mercancía")
                Else
                    MsgBox("Autorización Denegada.", vbExclamation, "Autorización")
                    Corriendo = False
                    Exit Sub
                End If
            Else
                RequiereSUP = False
            End If
        Else
            MsgBox("No existe Ticket.", vbExclamation, "Devolución de Mercancía")
            dsc.Tables.Remove("Art")
            Exit Sub
        End If
        dsc.Tables.Remove("Art")

        BtnGuardar.Enabled = True

        sql = "select dve_renglon, dve_articulo,dve_upc, descripcion,cant, dve_precio,ISNULL(X.cantDEV,0) as cantdev, " &
       "case when exists (select dve_venta from ecventadete h where h.dve_venta=a.ven_id and h.DVE_UPC=a.DVE_UPC) then '1' else '0' end as vale " &
       "from (select ven_id ,a.dve_renglon, a.dve_articulo,a.dve_upc,upc_descripcion as descripcion,sum(a.dve_cantidad) cant , a.dve_precio from ecventadet " &
       "a inner join ecventa on ecventa.ven_id=a.dve_venta inner join xupc on upc_upc=a.dve_upc " &
       "where ven_id=" & TxtNumTicket.Text & " And ven_status=1 group by ven_id,dve_renglon, a.dve_articulo,a.dve_upc,a.dve_precio,upc_descripcion) a left join " &
       "(SELECT ID_ARTICULO,upc_upc,SUM(CANTIDAD)AS CANTDEV FROM eccancxupc WHERE N_TICKET=" & TxtNumTicket.Text & " GROUP BY ID_ARTICULO,upc_upc ) X on x.id_articulo=a.dve_articulo " &
       "and X.upc_upc=a.DVE_upc order by DVE_RENGLON asc"

        Base.daQuery(sql, sCadenaConexionSQL, dsc, "art")

        FpSpreadDevoluciones.ActiveSheet.RowCount = dsc.Tables("art").Rows.Count
        ConfiguraSpread.ConfiguraSpread(FpSpreadDevoluciones)
        ConfiguraSpread.ConfiguraEnter(FpSpreadDevoluciones, SpreadActions.MoveToNextRow)

        FpSpreadDevoluciones.ActiveSheet.Columns(5).Visible = True

        For i = 0 To dsc.Tables("art").Rows.Count - 1
            FpSpreadDevoluciones.ActiveSheet.Cells(i, 0).Value = CDbl(dsc.Tables("art").Rows(i)("cant")) - CDbl(dsc.Tables("art").Rows(i)("cantdev"))
            FpSpreadDevoluciones.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ART").Rows(i)("dve_upc")
            FpSpreadDevoluciones.ActiveSheet.Cells(i, 2).Value = dsc.Tables("art").Rows(i)("descripcion")
            FpSpreadDevoluciones.ActiveSheet.Cells(i, 3).Value = CDbl(dsc.Tables("art").Rows(i)("dve_precio"))

            FpSpreadDevoluciones.ActiveSheet.Cells(i, 6).Value = dsc.Tables("ART").Rows(i)("DVE_ARTICULO")
            FpSpreadDevoluciones.ActiveSheet.Cells(i, 7).Value = dsc.Tables("ART").Rows(i)("vale")
        Next
        If FpSpreadDevoluciones.ActiveSheet.RowCount > 0 Then
            FpSpreadDevoluciones.ActiveSheet.Columns(5).Formula = "RC[-1]*RC[-2]"
            ConfiguraSpread.PintaClass(FpSpreadDevoluciones, FpSpreadDevoluciones.ActiveSheet.ActiveRowIndex, 2, 0, 1)
            FpSpreadDevoluciones.ActiveSheet.SetActiveCell(0, 3)
        End If
        TxtMotivo.Enabled = True
        Inicializando = True
        FpSpreadDevoluciones.Focus()
    End Sub

    Private Sub fp_Devolucion_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpreadDevoluciones.Change
        Dim i As Integer
        On Error Resume Next
        If Math.Round(FpSpreadDevoluciones.ActiveSheet.Cells(e.Row, 0).Value, 3) < Math.Round(FpSpreadDevoluciones.ActiveSheet.Cells(e.Row, 4).Value, 3) Then
            MsgBox("No puede devolver más cantidad que la comprada en este ticket.", vbExclamation, "Devolución de Mercancía")
            FpSpreadDevoluciones.ActiveSheet.Cells(e.Row, 4).Value = 0
            FpSpreadDevoluciones.ActiveSheet.SetActiveCell(e.Row, 4)
            FpSpreadDevoluciones.Focus()
        ElseIf FpSpreadDevoluciones.ActiveSheet.Cells(e.Row, 4).Value < 0 Then
            MsgBox("La cantidad a devolver no puede ser negativa.", vbExclamation, "Devolución de Mercancía")
            FpSpreadDevoluciones.ActiveSheet.Cells(e.Row, 4).Value = 0
            FpSpreadDevoluciones.ActiveSheet.SetActiveCell(e.Row, 4)
            FpSpreadDevoluciones.Focus()
        Else
            totalote = 0
            For i = 0 To FpSpreadDevoluciones.ActiveSheet.RowCount - 1
                totalote = totalote + FpSpreadDevoluciones.ActiveSheet.Cells(i, 5).Value
            Next
            TxtTotal.Text = Format(totalote, "$###,##0.00")
            FpSpreadDevoluciones.Focus()
        End If
    End Sub

    Private Sub fp_Devolucion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpSpreadDevoluciones.KeyUp
        FpSpreadDevoluciones.ActiveSheet.ActiveColumnIndex = 4
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If TxtMotivo.Text.Trim <> "" Then
            If CmbCaja.Visible Then
                If CmbCaja.SelectedIndex > -1 Then
                    If Not IsNumeric(CmbCaja.SelectedItem) Then
                        MsgBox("Número de caja debe ser numérico.", vbExclamation, "Devolución de Mercancía")
                        Exit Sub
                    End If
                Else
                    MsgBox("No ha indicado de qué caja se hará la devolución.", vbExclamation, "Devolución de Mercancía")
                    Exit Sub
                End If
            End If
        Else
            MsgBox("Especifique la razón de la devolución.", vbInformation, "Devolución de Mercancía")
            TxtMotivo.Focus()
            Exit Sub
        End If

        Dim Entre As Boolean = False
        Dim LlevaVale As Boolean = False
        For i As Integer = 0 To FpSpreadDevoluciones.ActiveSheet.Rows.Count - 1
            If FpSpreadDevoluciones.ActiveSheet.Cells(i, 4).Value > 0 Then
                Entre = True
                If FpSpreadDevoluciones.ActiveSheet.Cells(i, 7).Value = 1 Then
                    LlevaVale = True
                    Exit For
                End If
            End If
        Next
        If Entre Then
            Dim Jerarquia As String = ""
            If Not RequiereSUP AndAlso Not LlevaVale Then
                Jerarquia = "Supervisor"
            Else
                Jerarquia = "SUP"
            End If

            GeneraDevolucion(Jerarquia)
        Else
            MsgBox("No ha indicado qué artículos serán devueltos.", vbExclamation, "Devolución de Mercancía")
        End If
    End Sub

    Private Function GeneraDevolucion(ByVal Jerarquia As String) As Boolean
        Dim SQL As String

        Dim TotalDevolucion As Decimal = 0D
        Dim DSC As New DataSet
        Dim Descripcion As New System.Text.StringBuilder()

        Dim folioTicket As Integer
        If Not Integer.TryParse(TxtNumTicket.Text, folioTicket) Then
            MsgBox("Folio inválido.", vbExclamation)
            Return False
        End If

        Dim sheet = FpSpreadDevoluciones.ActiveSheet
        For i As Integer = 0 To sheet.RowCount - 1
            Dim qty As Decimal = Convert.ToDecimal(If(sheet.Cells(i, 4).Value, 0D))
            Dim qtyComprada As Decimal = Convert.ToDecimal(If(sheet.Cells(i, 0).Value, 0D))
            If qty <> 0D Then
                If Math.Round(qty, 3) > Math.Round(qtyComprada, 3) Then
                    MsgBox("No se puede devolver más artículos de los comprados.", MsgBoxStyle.Exclamation, "Devolución de Mercancías")
                    Return False
                ElseIf qty < 0D Then
                    MsgBox("La cantidad a devolver no puede ser negativa.", MsgBoxStyle.Exclamation, "Devolución de Mercancías")
                    Return False
                End If
            End If
        Next

        For i As Integer = 0 To sheet.RowCount - 1
            Dim qty As Decimal = Convert.ToDecimal(If(sheet.Cells(i, 4).Value, 0D))
            If qty <> 0D Then
                Dim precio As Decimal = Convert.ToDecimal(If(sheet.Cells(i, 3).Value, 0D))
                TotalDevolucion += qty * precio
                If Descripcion.Length > 0 Then Descripcion.Append(",")
                Descripcion.Append(qty.ToString("0.###")).Append(" ").Append(sheet.Cells(i, 2).Text.Trim())
            End If
        Next

        Dim auth As FingerprintAuthResult = AutorizacionConHuella.PromptFingerprint(xCon, Jerarquia, -1, Me)
        If auth.Approved Then
            With FpSpreadDevoluciones.ActiveSheet
                RegistroHistorial.HistorialAutorizaciones(xCon, My.Computer.Name, auth.UserName, folioTicket, "Devolución", "Devolución de Mercancía")
                If xCon.State = ConnectionState.Closed Then xCon.Open()
                Using tran = xCon.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)
                    Try
                        Dim Folio As Integer = 0
                        Using cmdFolio As New SqlCommand("
                             UPDATE ECCONSEMPRESA WITH (TABLOCKX)
                             SET RETIROS = RETIROS + 1;
                             SELECT RETIROS FROM ECCONSEMPRESA;", xCon, tran)
                            Folio = Convert.ToInt32(cmdFolio.ExecuteScalar())
                        End Using

                        If CheckBox1.Checked = True Then
                            Dim cajaCodigo As String
                            If CmbCaja.Visible AndAlso CmbCaja.SelectedItem IsNot Nothing Then
                                cajaCodigo = "00" & CInt(CmbCaja.SelectedItem).ToString() & "0"
                            Else
                                ' Falls back to last digit of Globales.caja
                                Dim lastDigit As String = Globales.caja.Substring(Globales.caja.Length - 1, 1)
                                cajaCodigo = "00" & lastDigit & "0"
                            End If

                            Using cmdRet As New SqlCommand("
                                INSERT INTO ecretiros
                                (cve_retiros, fecha, cuanto, caja, tipo, descripcion, corte, ret_estatus, usuario, motivo, Ticket)
                                VALUES (@folio, GETDATE(), @cuanto, @caja, @tipo, @desc, @corte, @estatus, @usuario, @motivo, @ticket);", xCon, tran)

                                cmdRet.Parameters.AddWithValue("@folio", Folio)
                                cmdRet.Parameters.AddWithValue("@cuanto", TotalDevolucion)
                                cmdRet.Parameters.AddWithValue("@caja", cajaCodigo)
                                cmdRet.Parameters.AddWithValue("@tipo", 6) ' DEV
                                cmdRet.Parameters.AddWithValue("@desc", "DEV " & Descripcion.ToString)
                                cmdRet.Parameters.AddWithValue("@corte", 0)
                                cmdRet.Parameters.AddWithValue("@estatus", 0)
                                cmdRet.Parameters.AddWithValue("@usuario", auth.UserName)
                                cmdRet.Parameters.AddWithValue("@motivo", TxtMotivo.Text.Trim())
                                cmdRet.Parameters.AddWithValue("@ticket", Integer.Parse(TxtNumTicket.Text.Trim()))
                                cmdRet.ExecuteNonQuery()
                            End Using

                            For i As Integer = 0 To sheet.RowCount - 1
                                Dim qty As Decimal = Convert.ToDecimal(If(sheet.Cells(i, 4).Value, 0D))
                                If qty = 0D Then Continue For

                                Dim precio As Decimal = Convert.ToDecimal(If(sheet.Cells(i, 3).Value, 0D))
                                Dim importe As Decimal = qty * precio
                                Dim upc As String = sheet.Cells(i, 6).Value.ToString()
                                Dim articulo As String = sheet.Cells(i, 1).Text

                                Using cmdCanc As New SqlCommand("
                                    INSERT INTO eccancxupc
                                    (upc, cantidad, ticket, fecha, precio, importe, articulo, usuario, folio)
                                    VALUES (@upc, @cantidad, @ticket, GETDATE(), @precio, @importe, @articulo, @usuario, @folio);", xCon, tran)

                                    cmdCanc.Parameters.AddWithValue("@upc", upc)
                                    cmdCanc.Parameters.AddWithValue("@cantidad", qty)
                                    cmdCanc.Parameters.AddWithValue("@ticket", Integer.Parse(TxtNumTicket.Text.Trim()))
                                    cmdCanc.Parameters.AddWithValue("@precio", precio)
                                    cmdCanc.Parameters.AddWithValue("@importe", importe)
                                    cmdCanc.Parameters.AddWithValue("@articulo", articulo)
                                    cmdCanc.Parameters.AddWithValue("@usuario", auth.UserName)
                                    cmdCanc.Parameters.AddWithValue("@folio", Folio)
                                    cmdCanc.ExecuteNonQuery()
                                End Using

                                Using cmd1 As New SqlCommand("EXEC APLICAMOVTOSFECHA @tipo, @fecha, @articulo, @upc, @cantidad, @importe;", xCon, tran)
                                    cmd1.Parameters.AddWithValue("@tipo", 3)
                                    cmd1.Parameters.AddWithValue("@fecha", Date.Today.ToString("yyyyMMdd"))
                                    cmd1.Parameters.AddWithValue("@articulo", articulo)
                                    cmd1.Parameters.AddWithValue("@upc", upc)
                                    cmd1.Parameters.AddWithValue("@cantidad", qty)
                                    cmd1.ExecuteNonQuery()
                                End Using

                                Using cmd2 As New SqlCommand("EXEC APLICAMOVTOSFECHACORTE @tipo, @fecha, @articulo, @upc, @cantidad, @importe;", xCon, tran)
                                    cmd2.Parameters.AddWithValue("@tipo", 3)
                                    cmd2.Parameters.AddWithValue("@fecha", Date.Today.ToString("yyyyMMdd"))
                                    cmd2.Parameters.AddWithValue("@articulo", articulo)
                                    cmd2.Parameters.AddWithValue("@upc", upc)
                                    cmd2.Parameters.AddWithValue("@cantidad", qty)
                                    cmd2.ExecuteNonQuery()
                                End Using

                                Using cmd3 As New SqlCommand("EXEC APLICAMOVTOSMES @tipo, @fecha, @articulo, @upc, @cantidad, @importe;", xCon, tran)
                                    cmd3.Parameters.AddWithValue("@tipo", 3)
                                    cmd3.Parameters.AddWithValue("@fecha", Date.Today.ToString("yyyyMMdd"))
                                    cmd3.Parameters.AddWithValue("@articulo", articulo)
                                    cmd3.Parameters.AddWithValue("@upc", upc)
                                    cmd3.Parameters.AddWithValue("@cantidad", qty)
                                    cmd3.ExecuteNonQuery()
                                End Using

                                Using cmd4 As New SqlCommand("EXEC APLICAMOVTOSSEMANA @tipo, @fecha, @articulo, @upc, @cantidad, @importe;", xCon, tran)
                                    cmd4.Parameters.AddWithValue("@tipo", 3)
                                    cmd4.Parameters.AddWithValue("@fecha", Date.Today.ToString("yyyyMMdd"))
                                    cmd4.Parameters.AddWithValue("@articulo", articulo)
                                    cmd4.Parameters.AddWithValue("@upc", upc)
                                    cmd4.Parameters.AddWithValue("@cantidad", qty)
                                    cmd4.ExecuteNonQuery()
                                End Using
                            Next

                            tran.Commit()

                            If CheckBox1.Checked AndAlso TotalDevolucion <> 0D Then
                                Dim preDINERO As New predinero(TxtNumTicket.Text, TotalDevolucion, If(CmbCaja.SelectedItem Is Nothing, 0, CInt(CmbCaja.SelectedItem)), "DEV " & Descripcion.ToString)
                                Dim oImpresion As New Impresion(preDINERO.COLECCION)
                                oImpresion.imprime(True)
                            End If

                            Return True
                        End If
                    Catch ex As Exception
                        Try : tran.Rollback() : Catch : End Try
                        MsgBox("Error al generar la devolución: " & ex.Message, MsgBoxStyle.Critical, "Devolución")
                        Return False
                    End Try
                End Using
            End With
        Else
            MsgBox("Autorización Denegada.", vbExclamation, "Autorización")
        End If
    End Function
    Private Sub FpSpreadDevoluciones_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FpSpreadDevoluciones.LeaveCell
        ConfiguraSpread.FpLeaveCell(sender, e, 4)
    End Sub
    Private Sub FpSpreadDevoluciones_CellClick(sender As Object, e As CellClickEventArgs) Handles FpSpreadDevoluciones.CellClick
        isHeaderClicked = ConfiguraSpread.FpCellClick(e, sender, Sumas, e.ColumnHeader, 4)
        FpSpreadDevoluciones.ActiveSheet.ActiveColumnIndex = 4
    End Sub

    Private isHeaderClicked As Boolean = False
    Private Sub FpSpreadDevoluciones_SelectionChanged(sender As Object, e As FarPoint.Win.Spread.SelectionChangedEventArgs) Handles FpSpreadDevoluciones.SelectionChanged
        FpSpreadDevoluciones.ActiveSheet.ActiveColumnIndex = 4
        Sumas.Text = ConfiguraSpread.Selecciona(sender, isHeaderClicked, Sumas)
    End Sub

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbColumnasBuscar.KeyDown, TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            ConfiguraSpread.Buscar(FpSpreadDevoluciones, CmbBuscaIndex.SelectedItem, TxtBuscar, CmbColumnasBuscar, Inicializando, FilaSig, UltRowMatch, UltStrBusc, Looped)
        ElseIf e.KeyCode = Keys.Escape Then
            FpSpreadDevoluciones.Focus()
        End If
    End Sub
    Private Sub CmbColumnasBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbColumnasBuscar.SelectedIndexChanged
        CmbBuscaIndex.SelectedIndex = CmbColumnasBuscar.SelectedIndex
        If CmbColumnasBuscar.SelectedIndex >= 0 Then
            TxtBuscar.Focus()
        End If
    End Sub

    Private Sub TxtNumTicket_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumTicket.KeyDown
        If e.KeyCode = Keys.Enter And TxtNumTicket.Text <> "" Then
            If IsNumeric(TxtNumTicket.Text) Then
                RellenaTicket(TxtNumTicket.Text.Trim)
            Else
                MsgBox("El folio del ticket debe ser numérico.", MsgBoxStyle.Exclamation, "Devolución de Mercancía")
                TxtNumTicket.Text = ""
                TxtNumTicket.Focus()
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not Corriendo Then
            Corriendo = True
            If Not CheckBox1.Checked Then
                If MsgBox("No se entregará dinero, la devolución sólo se hará para efectos de inventario, ¿correcto?", vbYesNo, "Devolución de Mercancía") = MsgBoxResult.No Then
                    CheckBox1.Checked = True
                End If
            End If
            Corriendo = False
        End If
    End Sub

    Private Sub TxtBuscar_GotFocus(sender As Object, e As EventArgs) Handles TxtBuscar.GotFocus
        TxtBuscar.SelectAll()
    End Sub

    Private Sub FpSpreadDevoluciones_KeyDown(sender As Object, e As KeyEventArgs) Handles FpSpreadDevoluciones.KeyDown
        If (e.KeyCode = Keys.F OrElse e.KeyCode = Keys.B) AndAlso e.Control Then
            TxtBuscar.Focus()
            TxtBuscar.SelectAll()
        End If
    End Sub
    Private Sub FormateaSpread()
        Dim ColFormatting As New List(Of DiseñaSpread)
        ColFormatting.Add(New DiseñaSpread(Name:="Cantidad Disponible", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=80, RowIndex:=0, ColIndex:=0, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.NumeroConDecimal, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="UPC", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=120, RowIndex:=0, ColIndex:=1, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Descripción", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=300, RowIndex:=0, ColIndex:=2, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Precio", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=80, RowIndex:=0, ColIndex:=3, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Cantidad a Devolver", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=80, RowIndex:=0, ColIndex:=4, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.NumeroConDecimal, ColVisible:=True, ColLocked:=False))
        ColFormatting.Add(New DiseñaSpread(Name:="Importe", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=80, RowIndex:=0, ColIndex:=5, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Clave Artículo", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=60, RowIndex:=0, ColIndex:=6, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=False, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Vale", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=60, RowIndex:=0, ColIndex:=7, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=False, ColLocked:=True))

        DiseñaSpread.DiseñaSpreadsGenérico(FpSpreadDevoluciones, ColFormatting)
        ConfiguraSpread.ConfiguraSpread(FpSpreadDevoluciones)
    End Sub
End Class
