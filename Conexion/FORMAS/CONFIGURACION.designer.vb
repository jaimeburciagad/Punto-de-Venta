<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONFIGURACION
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim EnhancedColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("ColumnHeaderSunburst")
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderSunburst")
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerSunburst")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer1 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer1 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer3 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim CheckBoxCellType1 As FarPoint.Win.Spread.CellType.CheckBoxCellType = New FarPoint.Win.Spread.CellType.CheckBoxCellType()
        Dim Picture1 As FarPoint.Win.Picture = New FarPoint.Win.Picture(Nothing, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Top)
        Me.fp_conf = New FarPoint.Win.Spread.FpSpread()
        Me.fp_conf_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.LBL_GUARDAR = New System.Windows.Forms.Label()
        Me.LBL_SALIR = New System.Windows.Forms.Label()
        Me.LBL_TACHA = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.fp_conf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fp_conf_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        EnhancedColumnHeaderRenderer1.ActiveBackgroundColor = System.Drawing.Color.Orange
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.NormalGridLineColor = System.Drawing.Color.OrangeRed
        EnhancedColumnHeaderRenderer1.SelectedActiveBackgroundColor = System.Drawing.Color.OrangeRed
        EnhancedColumnHeaderRenderer1.SelectedBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(141, Byte), Integer))
        EnhancedColumnHeaderRenderer1.SelectedGridLineColor = System.Drawing.Color.DarkOrange
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0.0R
        EnhancedRowHeaderRenderer1.ActiveBackgroundColor = System.Drawing.Color.Orange
        EnhancedRowHeaderRenderer1.Name = "EnhancedRowHeaderRenderer1"
        EnhancedRowHeaderRenderer1.NormalGridLineColor = System.Drawing.Color.OrangeRed
        EnhancedRowHeaderRenderer1.SelectedActiveBackgroundColor = System.Drawing.Color.OrangeRed
        EnhancedRowHeaderRenderer1.SelectedGridLineColor = System.Drawing.Color.DarkOrange
        EnhancedRowHeaderRenderer1.TextRotationAngle = 0.0R
        '
        'fp_conf
        '
        Me.fp_conf.AccessibleDescription = "fp_conf, Sheet1, Row 0, Column 0, "
        Me.fp_conf.BackColor = System.Drawing.SystemColors.Control
        Me.fp_conf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.fp_conf.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.fp_conf.HorizontalScrollBar.Name = ""
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
        Me.fp_conf.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.fp_conf.HorizontalScrollBar.TabIndex = 8
        Me.fp_conf.Location = New System.Drawing.Point(8, 74)
        Me.fp_conf.Name = "fp_conf"
        NamedStyle1.BackColor = System.Drawing.Color.DarkOrange
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.Renderer = EnhancedColumnHeaderRenderer1
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.DarkOrange
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = EnhancedRowHeaderRenderer1
        NamedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle3.BackColor = System.Drawing.Color.OrangeRed
        NamedStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle3.NoteIndicatorColor = System.Drawing.Color.Red
        EnhancedCornerRenderer1.ActiveBackgroundColor = System.Drawing.Color.OrangeRed
        EnhancedCornerRenderer1.GridLineColor = System.Drawing.Color.Empty
        EnhancedCornerRenderer1.NormalBackgroundColor = System.Drawing.Color.Orange
        NamedStyle3.Renderer = EnhancedCornerRenderer1
        NamedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle4.BackColor = System.Drawing.SystemColors.Window
        NamedStyle4.CellType = GeneralCellType1
        NamedStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle4.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle4.Renderer = GeneralCellType1
        Me.fp_conf.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4})
        Me.fp_conf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fp_conf.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.fp_conf_Sheet1})
        Me.fp_conf.Size = New System.Drawing.Size(368, 348)
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle1
        SpreadSkin1.CornerDefaultStyle = NamedStyle3
        SpreadSkin1.DefaultStyle = NamedStyle4
        SpreadSkin1.FocusRenderer = EnhancedFocusIndicatorRenderer1
        EnhancedInterfaceRenderer1.ArrowColorEnabled = System.Drawing.Color.DarkRed
        EnhancedInterfaceRenderer1.GrayAreaColor = System.Drawing.Color.White
        EnhancedInterfaceRenderer1.RangeGroupBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedInterfaceRenderer1.RangeGroupButtonBorderColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.RangeGroupLineColor = System.Drawing.Color.DarkRed
        EnhancedInterfaceRenderer1.ScrollBoxBackgroundColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.SheetTabBorderColor = System.Drawing.Color.DarkOrange
        EnhancedInterfaceRenderer1.SheetTabLowerActiveColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedInterfaceRenderer1.SheetTabLowerNormalColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.SheetTabUpperActiveColor = System.Drawing.Color.White
        EnhancedInterfaceRenderer1.SheetTabUpperNormalColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedInterfaceRenderer1.SplitBarBackgroundColor = System.Drawing.Color.DarkOrange
        EnhancedInterfaceRenderer1.SplitBarDarkColor = System.Drawing.Color.OrangeRed
        EnhancedInterfaceRenderer1.SplitBoxBackgroundColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.SplitBoxBorderColor = System.Drawing.Color.DarkOrange
        EnhancedInterfaceRenderer1.TabStripBackgroundColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.TabStripButtonBorderColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedInterfaceRenderer1.TabStripButtonFlatStyle = System.Windows.Forms.FlatStyle.Flat
        EnhancedInterfaceRenderer1.TabStripButtonLowerActiveColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.TabStripButtonLowerNormalColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        EnhancedInterfaceRenderer1.TabStripButtonLowerPressedColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.TabStripButtonUpperActiveColor = System.Drawing.Color.DarkOrange
        EnhancedInterfaceRenderer1.TabStripButtonUpperNormalColor = System.Drawing.Color.Orange
        EnhancedInterfaceRenderer1.TabStripButtonUpperPressedColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
        SpreadSkin1.InterfaceRenderer = EnhancedInterfaceRenderer1
        SpreadSkin1.Name = "CustomSkin1"
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle2
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
        SpreadSkin1.ScrollBarRenderer = EnhancedScrollBarRenderer2
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.GradientSelectionRenderer(System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrange, System.Drawing.Drawing2D.LinearGradientMode.Horizontal, 80)
        Me.fp_conf.Skin = SpreadSkin1
        Me.fp_conf.TabIndex = 7
        Me.fp_conf.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.fp_conf.VerticalScrollBar.Name = ""
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
        Me.fp_conf.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer3
        Me.fp_conf.VerticalScrollBar.TabIndex = 9
        '
        'fp_conf_Sheet1
        '
        Me.fp_conf_Sheet1.Reset()
        Me.fp_conf_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.fp_conf_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.fp_conf_Sheet1.ColumnCount = 3
        Me.fp_conf_Sheet1.RowCount = 1
        Me.fp_conf_Sheet1.RowHeader.ColumnCount = 0
        Me.fp_conf_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Mostrar"
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Descripción"
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Columna"
        Me.fp_conf_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.fp_conf_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
        Picture1.AlignHorz = FarPoint.Win.HorizontalAlignment.Center
        Picture1.TransparencyColor = System.Drawing.Color.Empty
        Picture1.TransparencyTolerance = 0
        CheckBoxCellType1.BackgroundImage = Picture1
        CheckBoxCellType1.TextAlign = FarPoint.Win.ButtonTextAlign.TextTopPictBottom
        Me.fp_conf_Sheet1.Columns.Get(0).CellType = CheckBoxCellType1
        Me.fp_conf_Sheet1.Columns.Get(0).Label = "Mostrar"
        Me.fp_conf_Sheet1.Columns.Get(0).Width = 50.0!
        Me.fp_conf_Sheet1.Columns.Get(1).Label = "Descripción"
        Me.fp_conf_Sheet1.Columns.Get(1).Width = 280.0!
        Me.fp_conf_Sheet1.Columns.Get(2).Label = "Columna"
        Me.fp_conf_Sheet1.Columns.Get(2).Visible = False
        Me.fp_conf_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.fp_conf_Sheet1.RowHeader.Columns.Default.Resizable = True
        Me.fp_conf_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.fp_conf_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSunburst"
        Me.fp_conf_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.fp_conf_Sheet1.SheetCornerStyle.Parent = "CornerSunburst"
        Me.fp_conf_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'LBL_GUARDAR
        '
        Me.LBL_GUARDAR.AutoSize = True
        Me.LBL_GUARDAR.BackColor = System.Drawing.Color.Transparent
        Me.LBL_GUARDAR.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_GUARDAR.ForeColor = System.Drawing.Color.DarkOrange
        Me.LBL_GUARDAR.Location = New System.Drawing.Point(122, 435)
        Me.LBL_GUARDAR.Name = "LBL_GUARDAR"
        Me.LBL_GUARDAR.Size = New System.Drawing.Size(54, 15)
        Me.LBL_GUARDAR.TabIndex = 229
        Me.LBL_GUARDAR.Text = "GUARDAR"
        '
        'LBL_SALIR
        '
        Me.LBL_SALIR.AutoSize = True
        Me.LBL_SALIR.BackColor = System.Drawing.Color.Transparent
        Me.LBL_SALIR.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_SALIR.ForeColor = System.Drawing.Color.DarkOrange
        Me.LBL_SALIR.Location = New System.Drawing.Point(217, 436)
        Me.LBL_SALIR.Name = "LBL_SALIR"
        Me.LBL_SALIR.Size = New System.Drawing.Size(31, 16)
        Me.LBL_SALIR.TabIndex = 230
        Me.LBL_SALIR.Text = "Salir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LBL_TACHA
        '
        Me.LBL_TACHA.AutoSize = True
        Me.LBL_TACHA.BackColor = System.Drawing.Color.Transparent
        Me.LBL_TACHA.Location = New System.Drawing.Point(355, 9)
        Me.LBL_TACHA.Name = "LBL_TACHA"
        Me.LBL_TACHA.Size = New System.Drawing.Size(16, 13)
        Me.LBL_TACHA.TabIndex = 231
        Me.LBL_TACHA.Text = "   "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Franklin Gothic Medium", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkGray
        Me.Label11.Location = New System.Drawing.Point(12, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 34)
        Me.Label11.TabIndex = 232
        Me.Label11.Text = "CONFIGURACION"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(294, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(74, 56)
        Me.PictureBox2.TabIndex = 233
        Me.PictureBox2.TabStop = False
        '
        'CONFIGURACION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(380, 459)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LBL_TACHA)
        Me.Controls.Add(Me.LBL_SALIR)
        Me.Controls.Add(Me.LBL_GUARDAR)
        Me.Controls.Add(Me.fp_conf)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CONFIGURACION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION"
        CType(Me.fp_conf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fp_conf_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fp_conf As FarPoint.Win.Spread.FpSpread
    Friend WithEvents fp_conf_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents LBL_GUARDAR As System.Windows.Forms.Label
    Friend WithEvents LBL_SALIR As System.Windows.Forms.Label
    Friend WithEvents LBL_TACHA As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
