<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ORDENACION
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
        Dim EnhancedScrollBarRenderer3 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer
        Dim EnhancedScrollBarRenderer4 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer
        Dim NumberCellType4 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType
        Dim Picture4 As FarPoint.Win.Picture = New FarPoint.Win.Picture(Nothing, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Top)
        Me.fp_conf = New FarPoint.Win.Spread.FpSpread
        Me.fp_conf_Sheet1 = New FarPoint.Win.Spread.SheetView
        Me.LBL_GUARDAR = New System.Windows.Forms.Label
        Me.LBL_SALIR = New System.Windows.Forms.Label
        Me.lbl_tachasalir = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.fp_conf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fp_conf_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fp_conf
        '
        Me.fp_conf.AccessibleDescription = "fp_conf, Sheet1, Row 0, Column 0, "
        Me.fp_conf.BackColor = System.Drawing.SystemColors.Control
        Me.fp_conf.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.fp_conf.HorizontalScrollBar.Name = ""
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
        Me.fp_conf.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer3
        Me.fp_conf.HorizontalScrollBar.TabIndex = 2
        Me.fp_conf.Location = New System.Drawing.Point(8, 74)
        Me.fp_conf.Name = "fp_conf"
        Me.fp_conf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fp_conf.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.fp_conf_Sheet1})
        Me.fp_conf.Size = New System.Drawing.Size(368, 348)
        Me.fp_conf.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Sunburst
        Me.fp_conf.TabIndex = 7
        Me.fp_conf.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.fp_conf.VerticalScrollBar.Name = ""
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
        Me.fp_conf.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer4
        Me.fp_conf.VerticalScrollBar.TabIndex = 3
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
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Orden"
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Descripción"
        Me.fp_conf_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Columna"
        Me.fp_conf_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.fp_conf_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
        Picture4.AlignHorz = FarPoint.Win.HorizontalAlignment.Center
        Picture4.TransparencyColor = System.Drawing.Color.Empty
        Picture4.TransparencyTolerance = 0
        NumberCellType4.BackgroundImage = Picture4
        NumberCellType4.DecimalPlaces = 0
        NumberCellType4.MaximumValue = 10000000
        NumberCellType4.MinimumValue = -10000000
        Me.fp_conf_Sheet1.Columns.Get(0).CellType = NumberCellType4
        Me.fp_conf_Sheet1.Columns.Get(0).Label = "Orden"
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
        'lbl_tachasalir
        '
        Me.lbl_tachasalir.AutoSize = True
        Me.lbl_tachasalir.BackColor = System.Drawing.Color.Transparent
        Me.lbl_tachasalir.Location = New System.Drawing.Point(352, 8)
        Me.lbl_tachasalir.Name = "lbl_tachasalir"
        Me.lbl_tachasalir.Size = New System.Drawing.Size(16, 13)
        Me.lbl_tachasalir.TabIndex = 231
        Me.lbl_tachasalir.Text = "   "
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(290, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(81, 59)
        Me.PictureBox2.TabIndex = 235
        Me.PictureBox2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Franklin Gothic Medium", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkGray
        Me.Label11.Location = New System.Drawing.Point(12, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 34)
        Me.Label11.TabIndex = 234
        Me.Label11.Text = "ORDENACION"
        '
        'ORDENACION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(380, 459)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbl_tachasalir)
        Me.Controls.Add(Me.LBL_SALIR)
        Me.Controls.Add(Me.LBL_GUARDAR)
        Me.Controls.Add(Me.fp_conf)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ORDENACION"
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
    Friend WithEvents lbl_tachasalir As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
