Imports System.ComponentModel
Imports System.Data.SqlClient
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
    Friend WithEvents regresar As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Public filtrotabla As String
    Friend WithEvents CmbColumnas As ComboBox
    Public Columnas As String
    Dim ButtonClick As Boolean

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

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents FP_BUSQUEDA As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FP_BUSQUEDA_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents TXT_COLFILTRO As System.Windows.Forms.TextBox
    Friend WithEvents FILTRO As System.Windows.Forms.TextBox
    Friend WithEvents TXT_ENCABEZADO As System.Windows.Forms.Label
    Friend WithEvents cmb_filtro As System.Windows.Forms.ComboBox
    Friend WithEvents chk_sensitiva As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim EnhancedScrollBarRenderer3 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer4 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Me.FILTRO = New System.Windows.Forms.TextBox()
        Me.FP_BUSQUEDA = New FarPoint.Win.Spread.FpSpread()
        Me.FP_BUSQUEDA_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.TXT_COLFILTRO = New System.Windows.Forms.TextBox()
        Me.TXT_ENCABEZADO = New System.Windows.Forms.Label()
        Me.cmb_filtro = New System.Windows.Forms.ComboBox()
        Me.chk_sensitiva = New System.Windows.Forms.CheckBox()
        Me.regresar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CmbColumnas = New System.Windows.Forms.ComboBox()
        CType(Me.FP_BUSQUEDA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_BUSQUEDA_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FILTRO
        '
        Me.FILTRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FILTRO.Location = New System.Drawing.Point(24, 48)
        Me.FILTRO.Name = "FILTRO"
        Me.FILTRO.Size = New System.Drawing.Size(348, 22)
        Me.FILTRO.TabIndex = 2
        '
        'FP_BUSQUEDA
        '
        Me.FP_BUSQUEDA.AccessibleDescription = "fp_articulos, Sheet1, Row 0, Column 0, "
        Me.FP_BUSQUEDA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FP_BUSQUEDA.BackColor = System.Drawing.Color.Transparent
        Me.FP_BUSQUEDA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FP_BUSQUEDA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FP_BUSQUEDA.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer3.ArrowColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer3.ArrowHoveredColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer3.ArrowSelectedColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer3.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer3.ButtonBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer3.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer3.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer3.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer3.ButtonSelectedBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer3.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer3.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
        Me.FP_BUSQUEDA.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer3
        Me.FP_BUSQUEDA.HorizontalScrollBar.TabIndex = 4
        Me.FP_BUSQUEDA.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FP_BUSQUEDA.Location = New System.Drawing.Point(24, 76)
        Me.FP_BUSQUEDA.Name = "FP_BUSQUEDA"
        Me.FP_BUSQUEDA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FP_BUSQUEDA.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical
        Me.FP_BUSQUEDA.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical
        Me.FP_BUSQUEDA.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FP_BUSQUEDA_Sheet1})
        Me.FP_BUSQUEDA.Size = New System.Drawing.Size(538, 293)
        Me.FP_BUSQUEDA.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Sunburst
        Me.FP_BUSQUEDA.TabIndex = 275
        Me.FP_BUSQUEDA.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FP_BUSQUEDA.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer4.ArrowColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer4.ArrowHoveredColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer4.ArrowSelectedColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer4.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer4.ButtonBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer4.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer4.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer4.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer4.ButtonSelectedBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer4.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer4.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
        Me.FP_BUSQUEDA.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer4
        Me.FP_BUSQUEDA.VerticalScrollBar.TabIndex = 5
        Me.FP_BUSQUEDA.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FP_BUSQUEDA_Sheet1
        '
        Me.FP_BUSQUEDA_Sheet1.Reset()
        Me.FP_BUSQUEDA_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FP_BUSQUEDA_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FP_BUSQUEDA_Sheet1.RowHeader.ColumnCount = 0
        Me.FP_BUSQUEDA_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.Cells.Get(1, 0).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 0).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 1).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 2).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 3).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 4).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 5).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 6).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 7).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 8).BackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 8).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.Cells.Get(0, 8).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_BUSQUEDA_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
        Me.FP_BUSQUEDA_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FP_BUSQUEDA_Sheet1.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White)
        Me.FP_BUSQUEDA_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        Me.FP_BUSQUEDA_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FP_BUSQUEDA_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_BUSQUEDA_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSunburst"
        Me.FP_BUSQUEDA_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_BUSQUEDA_Sheet1.SheetCornerStyle.Parent = "CornerSunburst"
        Me.FP_BUSQUEDA_Sheet1.VerticalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White)
        Me.FP_BUSQUEDA_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        Me.FP_BUSQUEDA.SetViewportTopRow(0, 0, 461)
        '
        'TXT_COLFILTRO
        '
        Me.TXT_COLFILTRO.Location = New System.Drawing.Point(174, 417)
        Me.TXT_COLFILTRO.Name = "TXT_COLFILTRO"
        Me.TXT_COLFILTRO.Size = New System.Drawing.Size(88, 20)
        Me.TXT_COLFILTRO.TabIndex = 276
        Me.TXT_COLFILTRO.Text = "0"
        Me.TXT_COLFILTRO.Visible = False
        '
        'TXT_ENCABEZADO
        '
        Me.TXT_ENCABEZADO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXT_ENCABEZADO.BackColor = System.Drawing.Color.Orange
        Me.TXT_ENCABEZADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_ENCABEZADO.ForeColor = System.Drawing.Color.Navy
        Me.TXT_ENCABEZADO.Location = New System.Drawing.Point(24, 16)
        Me.TXT_ENCABEZADO.Name = "TXT_ENCABEZADO"
        Me.TXT_ENCABEZADO.Size = New System.Drawing.Size(538, 24)
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
        Me.cmb_filtro.Size = New System.Drawing.Size(184, 21)
        Me.cmb_filtro.TabIndex = 278
        '
        'chk_sensitiva
        '
        Me.chk_sensitiva.BackColor = System.Drawing.Color.Transparent
        Me.chk_sensitiva.Checked = True
        Me.chk_sensitiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_sensitiva.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_sensitiva.ForeColor = System.Drawing.Color.Navy
        Me.chk_sensitiva.Location = New System.Drawing.Point(24, 375)
        Me.chk_sensitiva.Name = "chk_sensitiva"
        Me.chk_sensitiva.Size = New System.Drawing.Size(208, 32)
        Me.chk_sensitiva.TabIndex = 279
        Me.chk_sensitiva.Text = "Busqueda Sensitiva"
        Me.chk_sensitiva.UseVisualStyleBackColor = False
        '
        'regresar
        '
        Me.regresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.regresar.BackColor = System.Drawing.Color.White
        Me.regresar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.regresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.regresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.regresar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regresar.ForeColor = System.Drawing.Color.Orange
        Me.regresar.Location = New System.Drawing.Point(431, 391)
        Me.regresar.Name = "regresar"
        Me.regresar.Size = New System.Drawing.Size(50, 48)
        Me.regresar.TabIndex = 433
        Me.regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.regresar.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(471, 391)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 51)
        Me.Label13.TabIndex = 434
        Me.Label13.Text = "Menu Anterior"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbColumnas
        '
        Me.CmbColumnas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbColumnas.Location = New System.Drawing.Point(278, 416)
        Me.CmbColumnas.Name = "CmbColumnas"
        Me.CmbColumnas.Size = New System.Drawing.Size(118, 21)
        Me.CmbColumnas.TabIndex = 435
        Me.CmbColumnas.Visible = False
        '
        'busqueda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(591, 469)
        Me.Controls.Add(Me.CmbColumnas)
        Me.Controls.Add(Me.regresar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chk_sensitiva)
        Me.Controls.Add(Me.cmb_filtro)
        Me.Controls.Add(Me.TXT_ENCABEZADO)
        Me.Controls.Add(Me.TXT_COLFILTRO)
        Me.Controls.Add(Me.FILTRO)
        Me.Controls.Add(Me.FP_BUSQUEDA)
        Me.Name = "busqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrBuscaArt"
        CType(Me.FP_BUSQUEDA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_BUSQUEDA_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
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
            ColumnasTabla = Columnas.Split(";")
        Else
            ColumnasTabla = DSCCAMPOS.Split(",")
        End If


        For i = 0 To campos.Length - 1
            cmb_filtro.Items.Add(campos.GetValue(i).ToString.Trim)
            CmbColumnas.Items.Add(ColumnasTabla.GetValue(i).ToString.Trim)
        Next

        If DSCCAMPOS.Contains("distinct") Then
            If CmbColumnas.Items.Count > 2 Then
                Me.Width = 680
            End If

            cmb_filtro.SelectedIndex = 1
        Else
            cmb_filtro.SelectedIndex = Val(TXT_COLFILTRO.Text)
        End If
    End Sub

    Private Sub BUSQUEDA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXT_ENCABEZADO.Text = DSCENCABEZADO

        If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
            Me.BackColor = Color.Gainsboro
        Else
            Me.BackColor = Color.AliceBlue
        End If

        FILTRO.Text = ""
        Call rellenafiltros()
        Call RELLENASPBUSQUEDA()
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

        xx = dsccampose.Split(",")
        If DSCCAMPOS.Contains("distinct") Then
            SQL = "Select*from(" & "SELECT " & DSCCAMPOS & " FROM " & DSCTABLA & ") a" & " where " & IIf(filtrotabla <> "", filtrotabla & " and ", "") & CmbColumnas.Text & " like '" & IIf(chk_sensitiva.Checked, "%", "") & FILTRO.Text & "%'  ORDER BY " & DSCORDEN
        Else
            SQL = "SELECT " & DSCCAMPOS & " FROM " & DSCTABLA & " where " & IIf(filtrotabla <> "", filtrotabla & " and ", "") & CmbColumnas.Text & " like '" & IIf(chk_sensitiva.Checked, "%", "") & UCase(FILTRO.Text) & "%'  ORDER BY " & DSCORDEN
        End If


        Base.daQuery(SQL, xCon, DSC, "TABLA")


        FP_BUSQUEDA.ActiveSheet.RowCount = 0
        FP_BUSQUEDA.ActiveSheet.ColumnCount = DSC.Tables("TABLA").Columns.Count
        FP_BUSQUEDA.ActiveSheet.RowCount = DSC.Tables("TABLA").Rows.Count



        yy = longcampos.Split(",")
        zz = tipocampos.Split(",")
        For I = 0 To xx.Length - 1
            FP_BUSQUEDA.ActiveSheet.ColumnHeader.Cells(0, I).Text = xx.GetValue(I)
            FP_BUSQUEDA.ActiveSheet.Columns(I).Width = Val(yy.GetValue(I))
            FP_BUSQUEDA.ActiveSheet.Columns(I).Width = Val(yy.GetValue(I))
            FP_BUSQUEDA.ActiveSheet.Columns(I).Locked = True
            FP_BUSQUEDA.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            Select Case zz.GetValue(I)
                Case "#"
                    FP_BUSQUEDA.ActiveSheet.Columns(I).CellType = New NumberCellType
                    FP_BUSQUEDA.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Case "A"
                    FP_BUSQUEDA.ActiveSheet.Columns(I).CellType = New TextCellType
                    FP_BUSQUEDA.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Case "$"
                    FP_BUSQUEDA.ActiveSheet.Columns(I).CellType = New CurrencyCellType
                    FP_BUSQUEDA.ActiveSheet.Columns(I).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            End Select
        Next

        For I = 0 To DSC.Tables("TABLA").Rows.Count - 1
            For J = 0 To DSC.Tables("TABLA").Columns.Count - 1
                FP_BUSQUEDA.ActiveSheet.Cells(I, J).Text = DSC.Tables("TABLA").Rows(I)(J)
            Next
        Next I
        FP_BUSQUEDA.ActiveSheet.ActiveRowIndex = 0
        FP_BUSQUEDA.ActiveSheet.ActiveColumnIndex = Val(TXT_COLFILTRO.Text)

        FILTRO.Focus()


    End Sub

    Private Sub regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regresar.Click
        ButtonClick = False
        TXTCONTROL.Text = ""
        SendKeys.Flush()
        Me.Dispose(True)
        Me.Hide()
    End Sub

    Private Sub FP_BUSQUEDA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FP_BUSQUEDA.KeyDown
        Dim nombre As String
        Dim xx As Array
        Dim i As Integer
        nombre = "PROVEEDORES"
        TXTCONTROL.Text = ""
        If e.KeyCode = Keys.Enter Then
            If FP_BUSQUEDA.ActiveSheet.RowCount = 0 Then
                Exit Sub
            End If
            xx = DSCFILTRO.Split(",")
            For i = 0 To xx.Length - 1
                TXTCONTROL.Text = IIf(TXTCONTROL.Text = "", "", TXTCONTROL.Text & ",") & FP_BUSQUEDA.ActiveSheet.Cells(FP_BUSQUEDA.ActiveSheet.ActiveRowIndex, Val(xx.GetValue(i)) - 1).Text
            Next
            SendKeys.Flush()
            ButtonClick = True
            Me.Dispose(True)
            Me.Hide()
        End If
    End Sub

    Private Sub FP_BUSQUEDA_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FP_BUSQUEDA.CellDoubleClick
        Dim xx As Array
        Dim i As Integer
        xx = DSCFILTRO.Split(",")
        TXTCONTROL.Text = ""
        For i = 0 To xx.Length - 1
            TXTCONTROL.Text = IIf(TXTCONTROL.Text = "", "", TXTCONTROL.Text & ",") & FP_BUSQUEDA.ActiveSheet.Cells(FP_BUSQUEDA.ActiveSheet.ActiveRowIndex, Val(xx.GetValue(i)) - 1).Text
        Next
        SendKeys.Flush()
        ButtonClick = True
        Me.Dispose(True)
        Me.Hide()
    End Sub

    Private Sub FILTRO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FILTRO.KeyDown
        Dim XX As Array
        Dim I As Integer
        If e.KeyCode = Keys.Enter Then
            FP_BUSQUEDA.Focus()
        End If
        If e.KeyCode = Keys.Escape Then

            TXTCONTROL.Text = ""
            If TXTCONTROL.Text = "" Then
                XX = DSCFILTRO.Split(",")
                TXTCONTROL.Text = ""
                For I = 0 To XX.Length - 1
                    TXTCONTROL.Text = IIf(TXTCONTROL.Text = "", "", TXTCONTROL.Text & ",") & " "
                Next
                '            TXTCONTROL.Text = ""
                TXTCONTROL.Text = TXTCONTROL.Text.Trim
            End If
            SendKeys.Flush()
            ButtonClick = False
            Me.Dispose(True)
            Me.Hide()
        End If
    End Sub

    Private Sub cmb_filtro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_filtro.SelectedIndexChanged
        FILTRO.Text = ""
        TXT_COLFILTRO.Text = cmb_filtro.SelectedIndex
        CmbColumnas.SelectedIndex = cmb_filtro.SelectedIndex
        If FP_BUSQUEDA.ActiveSheet.Rows.Count > 0 Then
            FP_BUSQUEDA.ActiveSheet.ActiveColumnIndex = Val(TXT_COLFILTRO.Text)
        End If
        FILTRO.Focus()
    End Sub

    Private Sub PINTA(ByVal renglon As Integer, ByVal color As Integer, ByVal tamaño As Integer)
        Dim acell As FarPoint.Win.Spread.Cell
        Dim I As Integer

        For I = 0 To FP_BUSQUEDA.ActiveSheet.ColumnCount - 1
            acell = FP_BUSQUEDA.ActiveSheet.Cells(renglon, I)
            ' acell.Font = New Font("MS Sans Serif", tamaño, FontStyle.Bold)
            Select Case color
                Case 1
                    acell.ForeColor = System.Drawing.Color.White
                    acell.BackColor = System.Drawing.Color.Orange
                Case 2
                    acell.ForeColor = System.Drawing.Color.Black
                    acell.BackColor = System.Drawing.Color.White

            End Select
        Next I
    End Sub

    Private Sub FP_BUSQUEDA_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FP_BUSQUEDA.CellClick
        PINTA(FP_BUSQUEDA.ActiveSheet.ActiveRowIndex, 2, 12)
        FP_BUSQUEDA.ActiveSheet.ActiveRowIndex = e.Row
        PINTA(FP_BUSQUEDA.ActiveSheet.ActiveRowIndex, 1, 12)

    End Sub

    Private Sub FP_BUSQUEDA_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FP_BUSQUEDA.LeaveCell
        PINTA(e.Row, 2, 12)
        FP_BUSQUEDA.ActiveSheet.ActiveRowIndex = e.NewRow
        PINTA(FP_BUSQUEDA.ActiveSheet.ActiveRowIndex, 1, 12)

    End Sub

    Private Sub busqueda_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not ButtonClick Then
            TXTCONTROL.Text = ""
        End If
    End Sub
End Class

