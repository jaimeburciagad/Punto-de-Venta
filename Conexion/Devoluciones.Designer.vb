<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Devoluciones
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
        Dim EnhancedRowHeaderRenderer3 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedRowHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedRowHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Devoluciones))
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer1 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer1 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim CurrencyCellType1 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim CurrencyCellType2 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim TextCellType3 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.FpSpread1 = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread1_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TxtNumTicket = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LbCaja = New System.Windows.Forms.Label()
        Me.CmbCaja = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TXT_PASSWORD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.TxtMotivo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.CmbBuscaIndex = New System.Windows.Forms.ComboBox()
        Me.CmbColumnasBuscar = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        EnhancedRowHeaderRenderer3.Name = "EnhancedRowHeaderRenderer3"
        EnhancedRowHeaderRenderer3.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer1.Name = "EnhancedRowHeaderRenderer1"
        EnhancedRowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer1.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer2.Name = "EnhancedRowHeaderRenderer2"
        EnhancedRowHeaderRenderer2.TextRotationAngle = 0R
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(178, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(200, 21)
        Me.Label11.TabIndex = 23929
        Me.Label11.Text = "Administración de Cajas"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23928
        Me.PictureBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label15.Location = New System.Drawing.Point(178, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(301, 21)
        Me.Label15.TabIndex = 23927
        Me.Label15.Text = "Devolución de Mercancía"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label45.BackColor = System.Drawing.Color.SlateBlue
        Me.Label45.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(1089, 9)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(171, 22)
        Me.Label45.TabIndex = 23930
        Me.Label45.Text = "Duarsa 1"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FpSpread1
        '
        Me.FpSpread1.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.FpSpread1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FpSpread1.BackColor = System.Drawing.SystemColors.Control
        Me.FpSpread1.EditModeReplace = True
        Me.FpSpread1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FpSpread1.Location = New System.Drawing.Point(12, 95)
        Me.FpSpread1.Name = "FpSpread1"
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.Locked = False
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = EnhancedRowHeaderRenderer2
        NamedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle3.Renderer = EnhancedCornerRenderer1
        NamedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle4.BackColor = System.Drawing.SystemColors.Window
        NamedStyle4.CellType = GeneralCellType1
        NamedStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle4.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle4.Renderer = GeneralCellType1
        Me.FpSpread1.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4})
        Me.FpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread1_Sheet1})
        Me.FpSpread1.Size = New System.Drawing.Size(1248, 529)
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle1
        SpreadSkin1.CornerDefaultStyle = NamedStyle3
        SpreadSkin1.DefaultStyle = NamedStyle4
        SpreadSkin1.FocusRenderer = EnhancedFocusIndicatorRenderer1
        EnhancedInterfaceRenderer1.GrayAreaColor = System.Drawing.Color.LightSteelBlue
        EnhancedInterfaceRenderer1.ScrollBoxBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(221, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabLowerActiveColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(244, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabLowerNormalColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(249, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabUpperActiveColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(244, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabUpperNormalColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(249, Byte), Integer))
        EnhancedInterfaceRenderer1.TabStripBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(221, Byte), Integer))
        SpreadSkin1.InterfaceRenderer = EnhancedInterfaceRenderer1
        SpreadSkin1.Name = "CustomSkin1"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle2
        SpreadSkin1.ScrollBarRenderer = EnhancedScrollBarRenderer1
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FpSpread1.Skin = SpreadSkin1
        Me.FpSpread1.TabIndex = 6
        Me.FpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FpSpread1_Sheet1
        '
        Me.FpSpread1_Sheet1.Reset()
        Me.FpSpread1_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread1_Sheet1.ColumnCount = 8
        Me.FpSpread1_Sheet1.ColumnHeader.RowCount = 2
        Me.FpSpread1_Sheet1.RowCount = 1
        Me.FpSpread1_Sheet1.RowHeader.ColumnCount = 0
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Cantidad Disponible"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "UPC"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Descripción"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Precio"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Cantidad a Devolver"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Importe"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Art. Clave"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Vale"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "Style1"
        NumberCellType1.DecimalPlaces = 3
        NumberCellType1.DecimalSeparator = "."
        NumberCellType1.Separator = ","
        NumberCellType1.ShowSeparator = True
        Me.FpSpread1_Sheet1.Columns.Get(0).CellType = NumberCellType1
        Me.FpSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpread1_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(0).Width = 80.0!
        Me.FpSpread1_Sheet1.Columns.Get(1).CellType = TextCellType1
        Me.FpSpread1_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpread1_Sheet1.Columns.Get(1).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(1).Width = 100.0!
        Me.FpSpread1_Sheet1.Columns.Get(2).CellType = TextCellType2
        Me.FpSpread1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpread1_Sheet1.Columns.Get(2).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(2).Width = 300.0!
        CurrencyCellType1.CurrencySymbol = "$"
        CurrencyCellType1.DecimalPlaces = 2
        CurrencyCellType1.DecimalSeparator = "."
        CurrencyCellType1.Separator = ","
        Me.FpSpread1_Sheet1.Columns.Get(3).CellType = CurrencyCellType1
        Me.FpSpread1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpread1_Sheet1.Columns.Get(3).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(3).Width = 80.0!
        NumberCellType2.DecimalPlaces = 4
        NumberCellType2.DecimalSeparator = "."
        NumberCellType2.Separator = ","
        NumberCellType2.ShowSeparator = True
        Me.FpSpread1_Sheet1.Columns.Get(4).CellType = NumberCellType2
        Me.FpSpread1_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpread1_Sheet1.Columns.Get(4).Locked = False
        Me.FpSpread1_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(4).Width = 80.0!
        CurrencyCellType2.CurrencySymbol = "$"
        CurrencyCellType2.DecimalPlaces = 2
        CurrencyCellType2.DecimalSeparator = "."
        CurrencyCellType2.Separator = ","
        Me.FpSpread1_Sheet1.Columns.Get(5).CellType = CurrencyCellType2
        Me.FpSpread1_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Me.FpSpread1_Sheet1.Columns.Get(5).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(5).Width = 80.0!
        Me.FpSpread1_Sheet1.Columns.Get(6).CellType = TextCellType3
        Me.FpSpread1_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpread1_Sheet1.Columns.Get(6).Locked = False
        Me.FpSpread1_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(6).Visible = False
        Me.FpSpread1_Sheet1.Columns.Get(7).CellType = TextCellType4
        Me.FpSpread1_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
        Me.FpSpread1_Sheet1.Columns.Get(7).Locked = False
        Me.FpSpread1_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.Columns.Get(7).Visible = False
        Me.FpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread1_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FpSpread1_Sheet1.SelectionForeColor = System.Drawing.Color.White
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TxtBuscar.Location = New System.Drawing.Point(278, 70)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(310, 20)
        Me.TxtBuscar.TabIndex = 1
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label41.ForeColor = System.Drawing.Color.Navy
        Me.Label41.Location = New System.Drawing.Point(12, 71)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(47, 18)
        Me.Label41.TabIndex = 0
        Me.Label41.Text = "&Buscar"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNumTicket
        '
        Me.TxtNumTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNumTicket.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TxtNumTicket.Location = New System.Drawing.Point(1080, 68)
        Me.TxtNumTicket.Name = "TxtNumTicket"
        Me.TxtNumTicket.Size = New System.Drawing.Size(89, 20)
        Me.TxtNumTicket.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(1020, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ticket #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LbCaja
        '
        Me.LbCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbCaja.BackColor = System.Drawing.Color.Transparent
        Me.LbCaja.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LbCaja.ForeColor = System.Drawing.Color.Navy
        Me.LbCaja.Location = New System.Drawing.Point(1175, 69)
        Me.LbCaja.Name = "LbCaja"
        Me.LbCaja.Size = New System.Drawing.Size(38, 18)
        Me.LbCaja.TabIndex = 4
        Me.LbCaja.Text = "Caja"
        Me.LbCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbCaja
        '
        Me.CmbCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCaja.FormattingEnabled = True
        Me.CmbCaja.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7"})
        Me.CmbCaja.Location = New System.Drawing.Point(1219, 67)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(41, 22)
        Me.CmbCaja.TabIndex = 5
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(988, 44)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(272, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Registrar Devolución como Salida de Efectivo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.TXT_PASSWORD)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(501, 348)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(234, 53)
        Me.Panel1.TabIndex = 23953
        Me.Panel1.Visible = False
        '
        'TXT_PASSWORD
        '
        Me.TXT_PASSWORD.Location = New System.Drawing.Point(50, 24)
        Me.TXT_PASSWORD.Name = "TXT_PASSWORD"
        Me.TXT_PASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_PASSWORD.Size = New System.Drawing.Size(135, 20)
        Me.TXT_PASSWORD.TabIndex = 548
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(221, 16)
        Me.Label5.TabIndex = 546
        Me.Label5.Text = "Ingrese Clave para Devolución"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1023, 630)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Monto Devolución"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(1149, 630)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtTotal.Size = New System.Drawing.Size(111, 20)
        Me.TxtTotal.TabIndex = 10
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtMotivo.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TxtMotivo.Location = New System.Drawing.Point(129, 630)
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.Size = New System.Drawing.Size(288, 20)
        Me.TxtMotivo.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(12, 630)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Motivo Devolución"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(87, 723)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(75, 17)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "Regresar"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.BackColor = System.Drawing.Color.White
        Me.BtnGuardar.BackgroundImage = CType(resources.GetObject("BtnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.BtnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGuardar.Location = New System.Drawing.Point(22, 666)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(48, 48)
        Me.BtnGuardar.TabIndex = 11
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.Location = New System.Drawing.Point(9, 723)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 17)
        Me.Label21.TabIndex = 12
        Me.Label21.Text = "Guardar"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnRegresar
        '
        Me.BtnRegresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRegresar.BackColor = System.Drawing.Color.White
        Me.BtnRegresar.BackgroundImage = CType(resources.GetObject("BtnRegresar.BackgroundImage"), System.Drawing.Image)
        Me.BtnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRegresar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegresar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnRegresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnRegresar.Location = New System.Drawing.Point(100, 666)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(48, 48)
        Me.BtnRegresar.TabIndex = 13
        Me.BtnRegresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnRegresar.UseVisualStyleBackColor = False
        '
        'CmbBuscaIndex
        '
        Me.CmbBuscaIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBuscaIndex.FormattingEnabled = True
        Me.CmbBuscaIndex.Items.AddRange(New Object() {"costo unitario sin impuestos"})
        Me.CmbBuscaIndex.Location = New System.Drawing.Point(65, 69)
        Me.CmbBuscaIndex.Name = "CmbBuscaIndex"
        Me.CmbBuscaIndex.Size = New System.Drawing.Size(42, 22)
        Me.CmbBuscaIndex.TabIndex = 23972
        Me.CmbBuscaIndex.Visible = False
        '
        'CmbColumnasBuscar
        '
        Me.CmbColumnasBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbColumnasBuscar.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbColumnasBuscar.FormattingEnabled = True
        Me.CmbColumnasBuscar.Items.AddRange(New Object() {"costo unitario sin impuestos"})
        Me.CmbColumnasBuscar.Location = New System.Drawing.Point(65, 69)
        Me.CmbColumnasBuscar.Name = "CmbColumnasBuscar"
        Me.CmbColumnasBuscar.Size = New System.Drawing.Size(207, 22)
        Me.CmbColumnasBuscar.TabIndex = 23971
        '
        'Devoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1272, 749)
        Me.Controls.Add(Me.CmbBuscaIndex)
        Me.Controls.Add(Me.CmbColumnasBuscar)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.BtnRegresar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtMotivo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CmbCaja)
        Me.Controls.Add(Me.LbCaja)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNumTicket)
        Me.Controls.Add(Me.TxtBuscar)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.FpSpread1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label45)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ForeColor = System.Drawing.Color.Navy
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Devoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread1_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TxtNumTicket As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LbCaja As Label
    Friend WithEvents CmbCaja As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TXT_PASSWORD As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtTotal As TextBox
    Friend WithEvents TxtMotivo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents BtnRegresar As Button
    Friend WithEvents CmbBuscaIndex As ComboBox
    Friend WithEvents CmbColumnasBuscar As ComboBox
End Class
