<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reptarjetas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim DateTimeCellType1 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reptarjetas))
        Dim DateTimeCellType2 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim NumberCellType3 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType4 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.generar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt_Fechafin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Fechaini = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_clave = New System.Windows.Forms.TextBox()
        Me.rb_todas = New System.Windows.Forms.RadioButton()
        Me.rb_una = New System.Windows.Forms.RadioButton()
        Me.regresar = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.FP_VENTAS = New FarPoint.Win.Spread.FpSpread()
        Me.FP_VENTAS_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_aplica = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rb_ttickets = New System.Windows.Forms.RadioButton()
        Me.rb_encorte = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.panel_conf = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_IMPRIMIR = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.rb_noencorte = New System.Windows.Forms.RadioButton()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.FP_VENTAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_VENTAS_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.panel_conf.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(216, 678)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 35)
        Me.Label2.TabIndex = 603
        Me.Label2.Text = "GENERAR CONSULTA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label25.Location = New System.Drawing.Point(516, 677)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(98, 46)
        Me.Label25.TabIndex = 601
        Me.Label25.Text = "EXPORTAR DATOS"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_exportar
        '
        Me.btn_exportar.BackColor = System.Drawing.Color.White
        Me.btn_exportar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.exportar1
        Me.btn_exportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_exportar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.Location = New System.Drawing.Point(538, 625)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(52, 48)
        Me.btn_exportar.TabIndex = 600
        Me.btn_exportar.Tag = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        '
        'generar
        '
        Me.generar.BackColor = System.Drawing.Color.White
        Me.generar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.BOTON_NUEVO
        Me.generar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.generar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.generar.Location = New System.Drawing.Point(225, 625)
        Me.generar.Name = "generar"
        Me.generar.Size = New System.Drawing.Size(52, 48)
        Me.generar.TabIndex = 598
        Me.generar.Text = " "
        Me.generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.generar.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_Fechafin)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txt_Fechaini)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox3.Location = New System.Drawing.Point(313, 55)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(229, 146)
        Me.GroupBox3.TabIndex = 543
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Definición de Fechas"
        '
        'txt_Fechafin
        '
        Me.txt_Fechafin.Location = New System.Drawing.Point(110, 66)
        Me.txt_Fechafin.Name = "txt_Fechafin"
        Me.txt_Fechafin.Size = New System.Drawing.Size(104, 20)
        Me.txt_Fechafin.TabIndex = 547
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Gainsboro
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(7, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 24)
        Me.Label7.TabIndex = 545
        Me.Label7.Text = "Fecha Final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gainsboro
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(7, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 24)
        Me.Label6.TabIndex = 544
        Me.Label6.Text = "Fecha Inicial:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Fechaini
        '
        Me.txt_Fechaini.Location = New System.Drawing.Point(110, 42)
        Me.txt_Fechaini.Name = "txt_Fechaini"
        Me.txt_Fechaini.Size = New System.Drawing.Size(104, 20)
        Me.txt_Fechaini.TabIndex = 546
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txt_clave)
        Me.GroupBox2.Controls.Add(Me.rb_todas)
        Me.GroupBox2.Controls.Add(Me.rb_una)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(18, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(289, 109)
        Me.GroupBox2.TabIndex = 542
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Definición de Cajas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(136, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 545
        Me.Label1.Text = "CAJA:"
        '
        'txt_clave
        '
        Me.txt_clave.Location = New System.Drawing.Point(180, 83)
        Me.txt_clave.Name = "txt_clave"
        Me.txt_clave.Size = New System.Drawing.Size(76, 20)
        Me.txt_clave.TabIndex = 544
        '
        'rb_todas
        '
        Me.rb_todas.AutoSize = True
        Me.rb_todas.Checked = True
        Me.rb_todas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_todas.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_todas.Location = New System.Drawing.Point(27, 37)
        Me.rb_todas.Name = "rb_todas"
        Me.rb_todas.Size = New System.Drawing.Size(102, 18)
        Me.rb_todas.TabIndex = 537
        Me.rb_todas.TabStop = True
        Me.rb_todas.Text = "Todas las Cajas"
        Me.rb_todas.UseVisualStyleBackColor = True
        '
        'rb_una
        '
        Me.rb_una.AutoSize = True
        Me.rb_una.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_una.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_una.Location = New System.Drawing.Point(27, 56)
        Me.rb_una.Name = "rb_una"
        Me.rb_una.Size = New System.Drawing.Size(68, 18)
        Me.rb_una.TabIndex = 538
        Me.rb_una.Text = "Una Caja"
        Me.rb_una.UseVisualStyleBackColor = True
        '
        'regresar
        '
        Me.regresar.BackColor = System.Drawing.Color.White
        Me.regresar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.regresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.regresar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regresar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.regresar.Location = New System.Drawing.Point(743, 625)
        Me.regresar.Name = "regresar"
        Me.regresar.Size = New System.Drawing.Size(52, 48)
        Me.regresar.TabIndex = 599
        Me.regresar.Text = " "
        Me.regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.regresar.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label27.Location = New System.Drawing.Point(736, 676)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 35)
        Me.Label27.TabIndex = 602
        Me.Label27.Text = "MENU ANTERIOR"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FP_VENTAS
        '
        Me.FP_VENTAS.AccessibleDescription = "FP_VENTAS, Sheet1, Row 0, Column 0, "
        Me.FP_VENTAS.BackColor = System.Drawing.SystemColors.Control
        Me.FP_VENTAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FP_VENTAS.HorizontalScrollBar.Name = ""
        EnhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
        Me.FP_VENTAS.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.FP_VENTAS.HorizontalScrollBar.TabIndex = 40
        Me.FP_VENTAS.Location = New System.Drawing.Point(14, 128)
        Me.FP_VENTAS.Name = "FP_VENTAS"
        Me.FP_VENTAS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FP_VENTAS.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FP_VENTAS_Sheet1})
        Me.FP_VENTAS.Size = New System.Drawing.Size(974, 477)
        Me.FP_VENTAS.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Sunburst
        Me.FP_VENTAS.TabIndex = 592
        Me.FP_VENTAS.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FP_VENTAS.VerticalScrollBar.Name = ""
        EnhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.DarkRed
        EnhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
        EnhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.Orange
        EnhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
        Me.FP_VENTAS.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.FP_VENTAS.VerticalScrollBar.TabIndex = 41
        '
        'FP_VENTAS_Sheet1
        '
        Me.FP_VENTAS_Sheet1.Reset()
        Me.FP_VENTAS_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FP_VENTAS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FP_VENTAS_Sheet1.ColumnCount = 8
        Me.FP_VENTAS_Sheet1.RowCount = 1
        Me.FP_VENTAS_Sheet1.RowHeader.ColumnCount = 0
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Caja"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Folio"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Fecha"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Hora"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Concepto"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Monto Pagado"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Comisión "
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Referencia"
        Me.FP_VENTAS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_VENTAS_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
        NumberCellType1.DecimalPlaces = 0
        NumberCellType1.MaximumValue = 10000000.0R
        NumberCellType1.MinimumValue = -10000000.0R
        Me.FP_VENTAS_Sheet1.Columns.Get(0).CellType = NumberCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(0).Label = "Caja"
        Me.FP_VENTAS_Sheet1.Columns.Get(0).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(0).Width = 47.0!
        NumberCellType2.DecimalPlaces = 0
        NumberCellType2.MaximumValue = 10000000.0R
        NumberCellType2.MinimumValue = -10000000.0R
        Me.FP_VENTAS_Sheet1.Columns.Get(1).CellType = NumberCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Label = "Folio"
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Width = 75.0!
        DateTimeCellType1.Calendar = CType(resources.GetObject("DateTimeCellType1.Calendar"), System.Globalization.Calendar)
        DateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText
        DateTimeCellType1.DateDefault = New Date(2011, 4, 5, 11, 16, 53, 0)
        DateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999")
        DateTimeCellType1.TimeDefault = New Date(2011, 4, 5, 11, 16, 53, 0)
        Me.FP_VENTAS_Sheet1.Columns.Get(2).CellType = DateTimeCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Label = "Fecha"
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Width = 98.0!
        DateTimeCellType2.Calendar = CType(resources.GetObject("DateTimeCellType2.Calendar"), System.Globalization.Calendar)
        DateTimeCellType2.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText
        DateTimeCellType2.DateDefault = New Date(2011, 4, 5, 11, 16, 43, 0)
        DateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly
        DateTimeCellType2.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999")
        DateTimeCellType2.TimeDefault = New Date(2011, 4, 5, 11, 16, 43, 0)
        Me.FP_VENTAS_Sheet1.Columns.Get(3).CellType = DateTimeCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(3).Label = "Hora"
        Me.FP_VENTAS_Sheet1.Columns.Get(3).Width = 58.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(4).CellType = TextCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(4).Label = "Concepto"
        Me.FP_VENTAS_Sheet1.Columns.Get(4).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(4).Width = 160.0!
        NumberCellType3.DecimalPlaces = 2
        NumberCellType3.DecimalSeparator = "."
        NumberCellType3.Separator = ","
        NumberCellType3.ShowSeparator = True
        Me.FP_VENTAS_Sheet1.Columns.Get(5).CellType = NumberCellType3
        Me.FP_VENTAS_Sheet1.Columns.Get(5).Label = "Monto Pagado"
        Me.FP_VENTAS_Sheet1.Columns.Get(5).Width = 103.0!
        NumberCellType4.DecimalPlaces = 2
        NumberCellType4.DecimalSeparator = "."
        NumberCellType4.Separator = ","
        NumberCellType4.ShowSeparator = True
        Me.FP_VENTAS_Sheet1.Columns.Get(6).CellType = NumberCellType4
        Me.FP_VENTAS_Sheet1.Columns.Get(6).Label = "Comisión "
        Me.FP_VENTAS_Sheet1.Columns.Get(6).Width = 103.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(7).CellType = TextCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Label = "Referencia"
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Width = 279.0!
        Me.FP_VENTAS_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FP_VENTAS_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FP_VENTAS_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_VENTAS_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSunburst"
        Me.FP_VENTAS_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FP_VENTAS_Sheet1.SelectionForeColor = System.Drawing.Color.White
        Me.FP_VENTAS_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_VENTAS_Sheet1.SheetCornerStyle.Parent = "CornerSunburst"
        Me.FP_VENTAS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(475, 216)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(54, 55)
        Me.Button3.TabIndex = 47
        Me.Button3.Tag = "Salir"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGray
        Me.Label8.Location = New System.Drawing.Point(736, 711)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(262, 15)
        Me.Label8.TabIndex = 611
        Me.Label8.Text = "Derechos Reservados Estrategias Competitivas 2011"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(14, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 131)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 608
        Me.PictureBox1.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(141, 42)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(177, 21)
        Me.Label22.TabIndex = 610
        Me.Label22.Text = "Administración de Cajas"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(141, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(552, 26)
        Me.Label23.TabIndex = 609
        Me.Label23.Text = "Reporte Pagos de Tickets Realizados con Tarjetas Bancarias"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(121, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(296, 26)
        Me.Label9.TabIndex = 460
        Me.Label9.Text = "Definición Parámetros Consulta"
        '
        'btn_aplica
        '
        Me.btn_aplica.BackColor = System.Drawing.Color.White
        Me.btn_aplica.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.configurar
        Me.btn_aplica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_aplica.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplica.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_aplica.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aplica.Location = New System.Drawing.Point(148, 625)
        Me.btn_aplica.Name = "btn_aplica"
        Me.btn_aplica.Size = New System.Drawing.Size(52, 48)
        Me.btn_aplica.TabIndex = 595
        Me.btn_aplica.Text = " "
        Me.btn_aplica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aplica.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_noencorte)
        Me.GroupBox1.Controls.Add(Me.rb_ttickets)
        Me.GroupBox1.Controls.Add(Me.rb_encorte)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(18, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 94)
        Me.GroupBox1.TabIndex = 541
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección Información"
        '
        'rb_ttickets
        '
        Me.rb_ttickets.AutoSize = True
        Me.rb_ttickets.Checked = True
        Me.rb_ttickets.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_ttickets.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_ttickets.Location = New System.Drawing.Point(24, 19)
        Me.rb_ttickets.Name = "rb_ttickets"
        Me.rb_ttickets.Size = New System.Drawing.Size(105, 18)
        Me.rb_ttickets.TabIndex = 537
        Me.rb_ttickets.TabStop = True
        Me.rb_ttickets.Text = "Todos los Pagos"
        Me.rb_ttickets.UseVisualStyleBackColor = True
        '
        'rb_encorte
        '
        Me.rb_encorte.AutoSize = True
        Me.rb_encorte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_encorte.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_encorte.Location = New System.Drawing.Point(24, 43)
        Me.rb_encorte.Name = "rb_encorte"
        Me.rb_encorte.Size = New System.Drawing.Size(141, 18)
        Me.rb_encorte.TabIndex = 538
        Me.rb_encorte.Text = "Sólo Aplicados en Corte"
        Me.rb_encorte.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(140, 670)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 45)
        Me.Label5.TabIndex = 596
        Me.Label5.Text = "DEFINIR CONSULTA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel_conf
        '
        Me.panel_conf.BackColor = System.Drawing.Color.Gainsboro
        Me.panel_conf.Controls.Add(Me.GroupBox3)
        Me.panel_conf.Controls.Add(Me.GroupBox2)
        Me.panel_conf.Controls.Add(Me.GroupBox1)
        Me.panel_conf.Controls.Add(Me.Label9)
        Me.panel_conf.Controls.Add(Me.Button3)
        Me.panel_conf.Controls.Add(Me.Label11)
        Me.panel_conf.Controls.Add(Me.Label12)
        Me.panel_conf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_conf.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.panel_conf.Location = New System.Drawing.Point(268, 174)
        Me.panel_conf.Name = "panel_conf"
        Me.panel_conf.Size = New System.Drawing.Size(568, 310)
        Me.panel_conf.TabIndex = 597
        Me.panel_conf.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(472, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "   "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label12.Location = New System.Drawing.Point(486, 273)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 15)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Salir"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(371, 678)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 48)
        Me.Label4.TabIndex = 613
        Me.Label4.Text = "EMITIR REPORTE "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_IMPRIMIR
        '
        Me.BTN_IMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTN_IMPRIMIR.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.imprimir1
        Me.BTN_IMPRIMIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_IMPRIMIR.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_IMPRIMIR.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BTN_IMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_IMPRIMIR.Location = New System.Drawing.Point(383, 627)
        Me.BTN_IMPRIMIR.Name = "BTN_IMPRIMIR"
        Me.BTN_IMPRIMIR.Size = New System.Drawing.Size(52, 48)
        Me.BTN_IMPRIMIR.TabIndex = 612
        Me.BTN_IMPRIMIR.Tag = "Exportar"
        Me.BTN_IMPRIMIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_IMPRIMIR.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(780, 94)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 614
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'rb_noencorte
        '
        Me.rb_noencorte.AutoSize = True
        Me.rb_noencorte.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_noencorte.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_noencorte.Location = New System.Drawing.Point(22, 67)
        Me.rb_noencorte.Name = "rb_noencorte"
        Me.rb_noencorte.Size = New System.Drawing.Size(159, 18)
        Me.rb_noencorte.TabIndex = 539
        Me.rb_noencorte.Text = "Sólo NO Aplicados en Corte"
        Me.rb_noencorte.UseVisualStyleBackColor = True
        '
        'Reptarjetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BTN_IMPRIMIR)
        Me.Controls.Add(Me.panel_conf)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.generar)
        Me.Controls.Add(Me.regresar)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.FP_VENTAS)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.btn_aplica)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Reptarjetas"
        Me.Text = "Repsalidascaja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.FP_VENTAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_VENTAS_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panel_conf.ResumeLayout(False)
        Me.panel_conf.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents generar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Fechafin As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Fechaini As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_clave As System.Windows.Forms.TextBox
    Friend WithEvents rb_todas As System.Windows.Forms.RadioButton
    Friend WithEvents rb_una As System.Windows.Forms.RadioButton
    Friend WithEvents regresar As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents FP_VENTAS As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FP_VENTAS_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_aplica As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_ttickets As System.Windows.Forms.RadioButton
    Friend WithEvents rb_encorte As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents panel_conf As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BTN_IMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents rb_noencorte As System.Windows.Forms.RadioButton


End Class
