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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Devoluciones))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TxtNumTicket = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LbCaja = New System.Windows.Forms.Label()
        Me.CmbCaja = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
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
        Me.FpSpreadDevoluciones = New FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"))
        Me.FpSpreadDevoluciones_Sheet2 = Me.FpSpreadDevoluciones.GetSheet(0)
        Me.Sumas = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpreadDevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'FpSpreadDevoluciones
        '
        Me.FpSpreadDevoluciones.AccessibleDescription = "FpSpreadDevoluciones, Sheet1, Row 0, Column 0"
        Me.FpSpreadDevoluciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FpSpreadDevoluciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.FpSpreadDevoluciones.Location = New System.Drawing.Point(12, 95)
        Me.FpSpreadDevoluciones.Name = "FpSpreadDevoluciones"
        Me.FpSpreadDevoluciones.Size = New System.Drawing.Size(1248, 509)
        Me.FpSpreadDevoluciones.TabIndex = 23973
        '
        'Sumas
        '
        Me.Sumas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sumas.BackColor = System.Drawing.Color.Transparent
        Me.Sumas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sumas.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Sumas.Location = New System.Drawing.Point(598, 607)
        Me.Sumas.Name = "Sumas"
        Me.Sumas.Size = New System.Drawing.Size(662, 20)
        Me.Sumas.TabIndex = 23974
        Me.Sumas.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Sumas.Visible = False
        '
        'Devoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1272, 749)
        Me.Controls.Add(Me.Sumas)
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
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CmbCaja)
        Me.Controls.Add(Me.LbCaja)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNumTicket)
        Me.Controls.Add(Me.TxtBuscar)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.FpSpreadDevoluciones)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ForeColor = System.Drawing.Color.Navy
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Devoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpreadDevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TxtNumTicket As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LbCaja As Label
    Friend WithEvents CmbCaja As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
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
    Friend WithEvents FpSpreadDevoluciones As FarPoint.Win.Spread.FpSpread
    Friend WithEvents Sumas As Label
    Friend WithEvents FpSpreadDevoluciones_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FpSpreadDevoluciones_Sheet2 As FarPoint.Win.Spread.SheetView
End Class
