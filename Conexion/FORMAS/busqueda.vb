Imports System.ComponentModel
Imports System.Data.SqlClient
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.CellType
Imports FirebirdSql.Data.FirebirdClient
Public Class busqueda
    Inherits System.Windows.Forms.Form
    Public xCon As SqlConnection
    Public mCon As FbConnection
    Public DSCCAMPOS As String
    Public DSCTABLA As String
    Public DSCORDEN As String
    Public TXTCONTROL As TextBox
    Public DSCFILTRO As String
    Public DSCENCABEZADO As String
    Public dsccampose As String
    Public longcampos As String
    Public tipocampos As String
    Public VieneDe As String
    Public filtrotabla As String
    Public Ancho As Integer
    Public Microsip As Boolean
    Friend WithEvents CmbColumnas As ComboBox
    Public Columnas As String
    Public Distinct As Boolean
    Public TxtClaveAlm As TextBox
    Public TxtDescAlm As TextBox
    Friend WithEvents Sumas As Label
    Friend WithEvents FpBusqueda As FpSpread
    Friend WithEvents FpBusqueda_Sheet1 As SheetView
    Friend WithEvents FpBusqueda_Sheet2 As SheetView
    Public ButtonClick As Boolean

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)

    End Sub




    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer
    Friend WithEvents TXT_COLFILTRO As System.Windows.Forms.TextBox
    Friend WithEvents FILTRO As System.Windows.Forms.TextBox
    Friend WithEvents TXT_ENCABEZADO As System.Windows.Forms.Label
    Friend WithEvents cmb_filtro As System.Windows.Forms.ComboBox
    Friend WithEvents chk_sensitiva As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(busqueda))
        Me.FILTRO = New System.Windows.Forms.TextBox()
        Me.TXT_COLFILTRO = New System.Windows.Forms.TextBox()
        Me.TXT_ENCABEZADO = New System.Windows.Forms.Label()
        Me.cmb_filtro = New System.Windows.Forms.ComboBox()
        Me.chk_sensitiva = New System.Windows.Forms.CheckBox()
        Me.CmbColumnas = New System.Windows.Forms.ComboBox()
        Me.FpBusqueda = New FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"))
        Me.FpBusqueda_Sheet2 = Me.FpBusqueda.GetSheet(0)
        CType(Me.FpBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FILTRO
        '
        Me.FILTRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FILTRO.Location = New System.Drawing.Point(12, 48)
        Me.FILTRO.Name = "FILTRO"
        Me.FILTRO.Size = New System.Drawing.Size(360, 22)
        Me.FILTRO.TabIndex = 2
        '
        'TXT_COLFILTRO
        '
        Me.TXT_COLFILTRO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXT_COLFILTRO.Location = New System.Drawing.Point(293, 383)
        Me.TXT_COLFILTRO.Name = "TXT_COLFILTRO"
        Me.TXT_COLFILTRO.Size = New System.Drawing.Size(118, 20)
        Me.TXT_COLFILTRO.TabIndex = 276
        Me.TXT_COLFILTRO.Text = "0"
        Me.TXT_COLFILTRO.Visible = False
        '
        'TXT_ENCABEZADO
        '
        Me.TXT_ENCABEZADO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXT_ENCABEZADO.BackColor = System.Drawing.Color.Navy
        Me.TXT_ENCABEZADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_ENCABEZADO.ForeColor = System.Drawing.Color.Navy
        Me.TXT_ENCABEZADO.Location = New System.Drawing.Point(12, 16)
        Me.TXT_ENCABEZADO.Name = "TXT_ENCABEZADO"
        Me.TXT_ENCABEZADO.Size = New System.Drawing.Size(679, 24)
        Me.TXT_ENCABEZADO.TabIndex = 277
        Me.TXT_ENCABEZADO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_filtro
        '
        Me.cmb_filtro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_filtro.Location = New System.Drawing.Point(378, 48)
        Me.cmb_filtro.Name = "cmb_filtro"
        Me.cmb_filtro.Size = New System.Drawing.Size(313, 21)
        Me.cmb_filtro.TabIndex = 278
        '
        'chk_sensitiva
        '
        Me.chk_sensitiva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chk_sensitiva.BackColor = System.Drawing.Color.Transparent
        Me.chk_sensitiva.Checked = True
        Me.chk_sensitiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_sensitiva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_sensitiva.ForeColor = System.Drawing.Color.Navy
        Me.chk_sensitiva.Location = New System.Drawing.Point(12, 384)
        Me.chk_sensitiva.Name = "chk_sensitiva"
        Me.chk_sensitiva.Size = New System.Drawing.Size(143, 20)
        Me.chk_sensitiva.TabIndex = 279
        Me.chk_sensitiva.Text = "Busqueda Sensitiva"
        Me.chk_sensitiva.UseVisualStyleBackColor = False
        '
        'CmbColumnas
        '
        Me.CmbColumnas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbColumnas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbColumnas.Location = New System.Drawing.Point(199, 384)
        Me.CmbColumnas.Name = "CmbColumnas"
        Me.CmbColumnas.Size = New System.Drawing.Size(88, 21)
        Me.CmbColumnas.TabIndex = 435
        Me.CmbColumnas.Visible = False
        '
        'FpBusqueda
        '
        Me.FpBusqueda.AccessibleDescription = "FpOfertas, Sheet1, Row 0, Column 0"
        Me.FpBusqueda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FpBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.FpBusqueda.Location = New System.Drawing.Point(12, 75)
        Me.FpBusqueda.Name = "FpBusqueda"
        Me.FpBusqueda.Size = New System.Drawing.Size(679, 302)
        Me.FpBusqueda.TabIndex = 23955
        '
        'busqueda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(703, 413)
        Me.Controls.Add(Me.CmbColumnas)
        Me.Controls.Add(Me.chk_sensitiva)
        Me.Controls.Add(Me.cmb_filtro)
        Me.Controls.Add(Me.TXT_ENCABEZADO)
        Me.Controls.Add(Me.TXT_COLFILTRO)
        Me.Controls.Add(Me.FILTRO)
        Me.Controls.Add(Me.FpBusqueda)
        Me.Name = "busqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar..."
        CType(Me.FpBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub rellenafiltros()

        Dim dsc As New DataSet
        Dim i As Integer
        Dim campos As Array
        Dim ColumnasTabla As Array

        cmb_filtro.Items.Clear()
        CmbColumnas.Items.Clear()

        campos = dsccampose.Split(",")

        If Columnas <> "" Then
            ColumnasTabla = Columnas.Split(",")
        Else
            If DSCCAMPOS.ToString.ToUpper.Contains("COALESCE") Or DSCCAMPOS.ToString.ToUpper.Contains("CONVERT") Then
                ColumnasTabla = Replace(DSCCAMPOS, " , ", ";").Split(";")
            Else
                ColumnasTabla = DSCCAMPOS.Split(",")
            End If
        End If


        For i = 0 To campos.Length - 1
            If campos.GetValue(i).ToString.Trim <> "Fila" Then
                cmb_filtro.Items.Add(campos.GetValue(i).ToString.Trim)
                CmbColumnas.Items.Add(Replace(ColumnasTabla.GetValue(i).ToString.ToUpper.Trim, "DISTINCT", "").Trim)
            End If
        Next

        If DSCCAMPOS.Contains("distinct") And Not Distinct Then
            If CmbColumnas.Items.Count > 2 Then
                Me.Width = 680
            End If

            'cmb_filtro.SelectedIndex = 1 
            cmb_filtro.SelectedIndex = Val(TXT_COLFILTRO.Text)
        Else
            cmb_filtro.SelectedIndex = Val(TXT_COLFILTRO.Text)
        End If

        If Ancho <> -1 Then
            Me.Width = Ancho
        End If
    End Sub

    Private Sub BUSQUEDA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXT_ENCABEZADO.Text = DSCENCABEZADO

        FILTRO.Text = ""
        FormateaSpread()
        Call rellenafiltros()
        Call RELLENASPBUSQUEDA()

        ConfiguraSpread.ConfiguraSpread(FpBusqueda)

    End Sub

    Private Sub FILTRO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILTRO.TextChanged
        Call RELLENASPBUSQUEDA()
    End Sub
    Private Sub RELLENASPBUSQUEDA()
        Dim SQL As String
        Dim DSC As New DataSet
        Dim I As Integer
        Dim J As Integer
        Dim xx As Array
        Dim yy As Array
        Dim zz As Array
        Dim ColumnaFila As Integer = 0

        xx = dsccampose.Split(",")
        If DSCCAMPOS.Contains("distinct case") And Not Distinct Then
            SQL = "Select " & DSCCAMPOS & " FROM " & DSCTABLA & " where " & IIf(filtrotabla <> "", filtrotabla & " And ", "") & CmbColumnas.Text & " Like '" & IIf(chk_sensitiva.Checked, "%", "") & UCase(Replace(FILTRO.Text, "'", "''")) & "%'  ORDER BY " & DSCORDEN
        ElseIf DSCCAMPOS.Contains("distinct") And Not Distinct Then
            SQL = "Select*from(" & "SELECT " & DSCCAMPOS & " FROM " & DSCTABLA & ") a" & " where " & IIf(filtrotabla <> "", filtrotabla & " and ", "") & CmbColumnas.Text & " like '" & IIf(chk_sensitiva.Checked, "%", "") & Replace(FILTRO.Text, "'", "''") & "%'  ORDER BY " & DSCORDEN
        ElseIf DSCCAMPOS.Contains("ROW_NUMBER") Then
            'SQL = "Select*from(" & "SELECT " & DSCCAMPOS & " FROM " & DSCTABLA & " where " & IIf(filtrotabla <> "", filtrotabla & " and ", "") & CmbColumnas.Text & " like '" & IIf(chk_sensitiva.Checked, "%", "") & FILTRO.Text & "%') a where Fila=1 ORDER BY " & DSCORDEN
            SQL = "Select*from(" & "SELECT " & DSCCAMPOS & " FROM " & DSCTABLA & " where " & IIf(filtrotabla <> "", filtrotabla & " and ", "") & IIf(VieneDe = "Control de Artículos", "(upc_upc like '" & IIf(chk_sensitiva.Checked, "%", "") & Replace(FILTRO.Text, "'", "''") & "%' or " & CmbColumnas.Text & " like '" & IIf(chk_sensitiva.Checked, "%", "") & FILTRO.Text & "%')", CmbColumnas.Text & " like '" & IIf(chk_sensitiva.Checked, "%", "") & FILTRO.Text & "%'") & ") a where Fila=1 ORDER BY " & DSCORDEN
            ColumnaFila = 1
        Else
            SQL = "Select " & IIf(Distinct, "distinct ", "") & DSCCAMPOS & " FROM " & DSCTABLA & " where " & IIf(filtrotabla <> "", filtrotabla & " And ", "") & CmbColumnas.Text & " Like '" & IIf(chk_sensitiva.Checked, "%", "") & UCase(Replace(FILTRO.Text, "'", "''")) & "%' " & IIf(DSCORDEN.Contains("group"), DSCORDEN, " ORDER BY " & DSCORDEN)
        End If

        If Microsip Then
            'Base.daQueryMICROSIP(sql, dsmicrosip, "CLIENTE", IIf(Crisp, Globales.BaseMicrosipCrisp, IIf(RemotoForm, Globales.rBaseMicrosip, Globales.BaseMicrosip)))
            Base.daQueryMICROSIP(SQL, DSC, "TABLA", mCon.ConnectionString)
        Else
            Base.daQuery(SQL, sCadenaConexionSQL, DSC, "TABLA")
        End If

        FpBusqueda.ActiveSheet.RowCount = 0
        FpBusqueda.ActiveSheet.ColumnCount = DSC.Tables("TABLA").Columns.Count
        FpBusqueda.ActiveSheet.RowCount = DSC.Tables("TABLA").Rows.Count

        ConfiguraSpread.ConfiguraSpread(FpBusqueda) ',RowColumnBorderColor:=Color.White
        ConfiguraSpread.ConfiguraEnter(FpBusqueda, SpreadActions.MoveToNextRow)

        yy = longcampos.Split(",")
        zz = tipocampos.Split(",")
        For I = 0 To xx.Length - 1
            FpBusqueda.ActiveSheet.ColumnHeader.Cells(0, I).Text = xx.GetValue(I)
            FpBusqueda.ActiveSheet.Columns(I).Width = Val(yy.GetValue(I))
            FpBusqueda.ActiveSheet.Columns(I).Width = Val(yy.GetValue(I))
            FpBusqueda.ActiveSheet.Columns(I).Locked = True
            FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            Select Case zz.GetValue(I)
                Case "D"
                    Dim a As New DateTimeCellType
                    a.DateTimeFormat = DateTimeFormat.ShortDate
                    FpBusqueda.ActiveSheet.Columns(I).CellType = a
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Case "DT"
                    Dim a As New DateTimeCellType
                    a.DateTimeFormat = DateTimeFormat.ShortDateWithTime
                    FpBusqueda.ActiveSheet.Columns(I).CellType = a
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case "F"
                    Dim a As New NumberCellType
                    a.MaximumValue = 99999999
                    a.ShowSeparator = False
                    a.DecimalPlaces = 0
                    FpBusqueda.ActiveSheet.Columns(I).CellType = a
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Case "#"
                    Dim a As New NumberCellType
                    a.ShowSeparator = True
                    a.DecimalPlaces = 2
                    FpBusqueda.ActiveSheet.Columns(I).CellType = a
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Case "Int#"
                    Dim a As New NumberCellType
                    a.ShowSeparator = True
                    a.DecimalPlaces = 0
                    FpBusqueda.ActiveSheet.Columns(I).CellType = a
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Case "A"
                    FpBusqueda.ActiveSheet.Columns(I).CellType = New TextCellType
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case "TX"
                    FpBusqueda.ActiveSheet.Columns(I).CellType = New TextCellType
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Case "$"
                    Dim a As New CurrencyCellType
                    a.ShowSeparator = True
                    a.ShowCurrencySymbol = True
                    a.DecimalPlaces = 2
                    FpBusqueda.ActiveSheet.Columns(I).CellType = a
                    FpBusqueda.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            End Select
        Next

        For I = 0 To DSC.Tables("TABLA").Rows.Count - 1
            For J = 0 To DSC.Tables("TABLA").Columns.Count - 1
                If IsDBNull(DSC.Tables("TABLA").Rows(I)(J)) Then
                    FpBusqueda.ActiveSheet.Cells(I, J).Text = ""
                Else
                    FpBusqueda.ActiveSheet.Cells(I, J).Text = DSC.Tables("TABLA").Rows(I)(J)
                End If

            Next
        Next I
        If FpBusqueda.ActiveSheet.RowCount > 0 Then
            'Dim sel As FarPoint.Win.Spread.Model.ISheetSelectionModel
            'sel = FpBusqueda.ActiveSheet.Models.Selection
            'FpBusqueda.ActiveSheet.SetActiveCell(0, Val(TXT_COLFILTRO.Text))
            'PINTA(0, 1, 12)
            'FpBusqueda.EditMode = False
        End If

        If FpBusqueda.ActiveSheet.RowCount > 0 Then
            ConfiguraSpread.PintaClass(FpBusqueda, FpBusqueda.ActiveSheet.ActiveRowIndex, 2, 0, 1)
            FpBusqueda.ActiveSheet.SetActiveCell(0, 0)
            FpBusqueda.Focus()
        End If

        FILTRO.Focus()


    End Sub

    Private Sub FILTRO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FILTRO.KeyDown
        If e.KeyCode = Keys.Enter Then
            FpBusqueda.Focus()
        End If
        If e.KeyCode = Keys.Escape Then
            ButtonClick = False
            Me.Close()
        End If
    End Sub

    Private Sub cmb_filtro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_filtro.SelectedIndexChanged
        FILTRO.Text = ""
        TXT_COLFILTRO.Text = cmb_filtro.SelectedIndex
        CmbColumnas.SelectedIndex = cmb_filtro.SelectedIndex
        If FpBusqueda.ActiveSheet.Rows.Count > 0 Then
            FpBusqueda.ActiveSheet.ActiveColumnIndex = Val(TXT_COLFILTRO.Text)
        End If
        FILTRO.Focus()
    End Sub

    Private Sub busqueda_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not ButtonClick Then
            'TXTCONTROL.Text = ""
        End If
    End Sub

    Private Sub FpBusqueda_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            If FpBusqueda.ActiveSheet.RowCount = 0 Then
                Exit Sub
            End If
            PasaInfo()
        End If
    End Sub

    Private Sub FpBusqueda_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FpBusqueda.LeaveCell
        ConfiguraSpread.FpLeaveCell(sender, e)
    End Sub
    Private Sub FpBusqueda_CellClick(sender As Object, e As CellClickEventArgs) Handles FpBusqueda.CellClick
        isHeaderClicked = ConfiguraSpread.FpCellClick(e, sender, Sumas, e.ColumnHeader)
    End Sub

    Private isHeaderClicked As Boolean = False
    Private Sub FpBusqueda_SelectionChanged(sender As Object, e As FarPoint.Win.Spread.SelectionChangedEventArgs) Handles FpBusqueda.SelectionChanged
        Sumas.Text = ConfiguraSpread.Selecciona(sender, isHeaderClicked, Sumas)
    End Sub
    Private Sub FpBusqueda_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpBusqueda.CellDoubleClick
        PasaInfo()
    End Sub

    Private Sub FpBusqueda_DialogKey(sender As Object, e As DialogKeyEventArgs) Handles FpBusqueda.DialogKey
        If e.KeyCode = Keys.Escape Then
            ButtonClick = False
            Me.Close()
        End If
        If ModifierKeys = Keys.Shift And e.KeyCode = Keys.Tab Then
            FILTRO.Focus()
        End If
    End Sub

    Private Sub PasaInfo()
        If FpBusqueda.ActiveSheet.Cells(FpBusqueda.ActiveSheet.ActiveRowIndex, 0).Text <> "" Then
            Dim xx As Array
            Dim i As Integer
            xx = DSCFILTRO.Split(",")
            TXTCONTROL.Text = ""
            For i = 0 To xx.Length - 1
                TXTCONTROL.Text = IIf(TXTCONTROL.Text = "", "", TXTCONTROL.Text & ",") & FpBusqueda.ActiveSheet.Cells(FpBusqueda.ActiveSheet.ActiveRowIndex, Val(xx.GetValue(i)) - 1).Text
            Next
            SendKeys.Flush()
            ButtonClick = True
            Me.Dispose(True)
            Me.Hide()
        End If
    End Sub

    Private Sub FormateaSpread()
        Dim ColFormatting As New List(Of DiseñaSpread)
        ColFormatting.Add(New DiseñaSpread(Name:="Descripción", ColHeaderRows:=1, ColHeaderCols:=1, ColWidth:=60, RowIndex:=0, ColIndex:=0, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Clave", ColHeaderRows:=1, ColHeaderCols:=1, ColWidth:=60, RowIndex:=0, ColIndex:=1, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Familia", ColHeaderRows:=1, ColHeaderCols:=1, ColWidth:=60, RowIndex:=0, ColIndex:=2, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))


        DiseñaSpread.DiseñaSpreadsGenérico(FpBusqueda, ColFormatting)
        ConfiguraSpread.ConfiguraSpread(FpBusqueda)
    End Sub

End Class

