<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class parafacturar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(parafacturar))
        Me.Panel_tickets = New System.Windows.Forms.Panel()
        Me.FpTickets = New FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, CType(resources.GetObject("Panel_tickets.Controls"), Object))
        Me.FpTickets_Sheet1 = Me.FpTickets.GetSheet(0)
        Me.PanelSeleccionTarjetas = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbFila = New System.Windows.Forms.Label()
        Me.BtnCierraPanel = New System.Windows.Forms.Button()
        Me.BtnRegistraTarjeta = New System.Windows.Forms.Button()
        Me.rbTDebito = New System.Windows.Forms.RadioButton()
        Me.rbTCredito = New System.Windows.Forms.RadioButton()
        Me.BtnInicializar = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.BtnEnviar = New System.Windows.Forms.Button()
        Me.BtnRegresar = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Chk_menores = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.labelfiltro = New System.Windows.Forms.Label()
        Me.TxtFiltro = New System.Windows.Forms.TextBox()
        Me.CmbCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_cliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel_tickets.SuspendLayout()
        CType(Me.FpTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSeleccionTarjetas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_tickets
        '
        Me.Panel_tickets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_tickets.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel_tickets.Controls.Add(Me.PanelSeleccionTarjetas)
        Me.Panel_tickets.Controls.Add(Me.BtnInicializar)
        Me.Panel_tickets.Controls.Add(Me.Label28)
        Me.Panel_tickets.Controls.Add(Me.BtnEnviar)
        Me.Panel_tickets.Controls.Add(Me.BtnRegresar)
        Me.Panel_tickets.Controls.Add(Me.FpTickets)
        Me.Panel_tickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_tickets.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Panel_tickets.Location = New System.Drawing.Point(12, 122)
        Me.Panel_tickets.Name = "Panel_tickets"
        Me.Panel_tickets.Size = New System.Drawing.Size(792, 399)
        Me.Panel_tickets.TabIndex = 4
        '
        'FpTickets
        '
        Me.FpTickets.AccessibleDescription = ""
        Me.FpTickets.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.FpTickets.Location = New System.Drawing.Point(12, 44)
        Me.FpTickets.Name = "FpTickets"
        Me.FpTickets.Size = New System.Drawing.Size(761, 340)
        Me.FpTickets.TabIndex = 23957
        '
        'PanelSeleccionTarjetas
        '
        Me.PanelSeleccionTarjetas.Controls.Add(Me.GroupBox1)
        Me.PanelSeleccionTarjetas.Location = New System.Drawing.Point(206, 143)
        Me.PanelSeleccionTarjetas.Name = "PanelSeleccionTarjetas"
        Me.PanelSeleccionTarjetas.Size = New System.Drawing.Size(203, 77)
        Me.PanelSeleccionTarjetas.TabIndex = 461
        Me.PanelSeleccionTarjetas.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbFila)
        Me.GroupBox1.Controls.Add(Me.BtnCierraPanel)
        Me.GroupBox1.Controls.Add(Me.BtnRegistraTarjeta)
        Me.GroupBox1.Controls.Add(Me.rbTDebito)
        Me.GroupBox1.Controls.Add(Me.rbTCredito)
        Me.GroupBox1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 70)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione Tipo de Tarjeta"
        '
        'lbFila
        '
        Me.lbFila.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lbFila.ForeColor = System.Drawing.Color.Navy
        Me.lbFila.Location = New System.Drawing.Point(145, 12)
        Me.lbFila.Name = "lbFila"
        Me.lbFila.Size = New System.Drawing.Size(41, 15)
        Me.lbFila.TabIndex = 521
        Me.lbFila.Text = "Fila"
        Me.lbFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbFila.Visible = False
        '
        'BtnCierraPanel
        '
        Me.BtnCierraPanel.BackColor = System.Drawing.Color.White
        Me.BtnCierraPanel.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477101_arrow_left_78605__1_
        Me.BtnCierraPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnCierraPanel.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCierraPanel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnCierraPanel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCierraPanel.Location = New System.Drawing.Point(162, 29)
        Me.BtnCierraPanel.Name = "BtnCierraPanel"
        Me.BtnCierraPanel.Size = New System.Drawing.Size(24, 24)
        Me.BtnCierraPanel.TabIndex = 8
        Me.BtnCierraPanel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCierraPanel.UseVisualStyleBackColor = False
        '
        'BtnRegistraTarjeta
        '
        Me.BtnRegistraTarjeta.BackColor = System.Drawing.Color.White
        Me.BtnRegistraTarjeta.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477072_check_78599
        Me.BtnRegistraTarjeta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRegistraTarjeta.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistraTarjeta.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnRegistraTarjeta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnRegistraTarjeta.Location = New System.Drawing.Point(132, 29)
        Me.BtnRegistraTarjeta.Name = "BtnRegistraTarjeta"
        Me.BtnRegistraTarjeta.Size = New System.Drawing.Size(24, 24)
        Me.BtnRegistraTarjeta.TabIndex = 7
        Me.BtnRegistraTarjeta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnRegistraTarjeta.UseVisualStyleBackColor = False
        '
        'rbTDebito
        '
        Me.rbTDebito.AutoSize = True
        Me.rbTDebito.Location = New System.Drawing.Point(6, 44)
        Me.rbTDebito.Name = "rbTDebito"
        Me.rbTDebito.Size = New System.Drawing.Size(109, 19)
        Me.rbTDebito.TabIndex = 1
        Me.rbTDebito.TabStop = True
        Me.rbTDebito.Text = "Tarjeta de Débito"
        Me.rbTDebito.UseVisualStyleBackColor = True
        '
        'rbTCredito
        '
        Me.rbTCredito.AutoSize = True
        Me.rbTCredito.Location = New System.Drawing.Point(6, 19)
        Me.rbTCredito.Name = "rbTCredito"
        Me.rbTCredito.Size = New System.Drawing.Size(112, 19)
        Me.rbTCredito.TabIndex = 0
        Me.rbTCredito.TabStop = True
        Me.rbTCredito.Text = "Tarjeta de Crédito"
        Me.rbTCredito.UseVisualStyleBackColor = True
        '
        'BtnInicializar
        '
        Me.BtnInicializar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnInicializar.BackColor = System.Drawing.Color.White
        Me.BtnInicializar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477083_plus_78571__2_
        Me.BtnInicializar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnInicializar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInicializar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnInicializar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnInicializar.Location = New System.Drawing.Point(665, 6)
        Me.BtnInicializar.Name = "BtnInicializar"
        Me.BtnInicializar.Size = New System.Drawing.Size(32, 32)
        Me.BtnInicializar.TabIndex = 6
        Me.BtnInicializar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnInicializar.UseVisualStyleBackColor = False
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Navy
        Me.Label28.Location = New System.Drawing.Point(7, 11)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(324, 26)
        Me.Label28.TabIndex = 460
        Me.Label28.Text = "Seleccionar Tickets"
        '
        'BtnEnviar
        '
        Me.BtnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEnviar.BackColor = System.Drawing.Color.White
        Me.BtnEnviar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477204_share2_78604
        Me.BtnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnEnviar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnviar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnEnviar.Location = New System.Drawing.Point(703, 6)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(32, 32)
        Me.BtnEnviar.TabIndex = 7
        Me.BtnEnviar.Tag = "Salir"
        Me.BtnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnEnviar.UseVisualStyleBackColor = False
        '
        'BtnRegresar
        '
        Me.BtnRegresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRegresar.BackColor = System.Drawing.Color.White
        Me.BtnRegresar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477101_arrow_left_78605
        Me.BtnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRegresar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegresar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnRegresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnRegresar.Location = New System.Drawing.Point(741, 6)
        Me.BtnRegresar.Name = "BtnRegresar"
        Me.BtnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.BtnRegresar.TabIndex = 8
        Me.BtnRegresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnRegresar.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CheckBox1.Location = New System.Drawing.Point(683, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox1.TabIndex = 766
        Me.CheckBox1.Text = "Declara IEPS"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Chk_menores
        '
        Me.Chk_menores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chk_menores.AutoSize = True
        Me.Chk_menores.Checked = True
        Me.Chk_menores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_menores.Enabled = False
        Me.Chk_menores.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Chk_menores.Location = New System.Drawing.Point(537, 8)
        Me.Chk_menores.Name = "Chk_menores"
        Me.Chk_menores.Size = New System.Drawing.Size(140, 17)
        Me.Chk_menores.TabIndex = 3
        Me.Chk_menores.Text = "Menores de 2000 pesos"
        Me.Chk_menores.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.labelfiltro)
        Me.Panel1.Controls.Add(Me.Chk_menores)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.TxtFiltro)
        Me.Panel1.Controls.Add(Me.CmbCliente)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 58)
        Me.Panel1.TabIndex = 0
        '
        'labelfiltro
        '
        Me.labelfiltro.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.labelfiltro.ForeColor = System.Drawing.Color.Navy
        Me.labelfiltro.Location = New System.Drawing.Point(16, 6)
        Me.labelfiltro.Name = "labelfiltro"
        Me.labelfiltro.Size = New System.Drawing.Size(41, 21)
        Me.labelfiltro.TabIndex = 520
        Me.labelfiltro.Text = "Filtro"
        Me.labelfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtFiltro
        '
        Me.TxtFiltro.Location = New System.Drawing.Point(63, 7)
        Me.TxtFiltro.Name = "TxtFiltro"
        Me.TxtFiltro.Size = New System.Drawing.Size(209, 20)
        Me.TxtFiltro.TabIndex = 1
        '
        'CmbCliente
        '
        Me.CmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCliente.Location = New System.Drawing.Point(63, 32)
        Me.CmbCliente.Name = "CmbCliente"
        Me.CmbCliente.Size = New System.Drawing.Size(537, 21)
        Me.CmbCliente.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 21)
        Me.Label1.TabIndex = 461
        Me.Label1.Text = "Cliente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_cliente
        '
        Me.txt_cliente.Enabled = False
        Me.txt_cliente.Location = New System.Drawing.Point(581, 39)
        Me.txt_cliente.Name = "txt_cliente"
        Me.txt_cliente.Size = New System.Drawing.Size(52, 20)
        Me.txt_cliente.TabIndex = 763
        Me.txt_cliente.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(178, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(200, 21)
        Me.Label4.TabIndex = 23912
        Me.Label4.Text = "Facturación de Tickets"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23911
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(178, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(301, 21)
        Me.Label5.TabIndex = 23910
        Me.Label5.Text = "Interfase Microsip"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'parafacturar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(816, 533)
        Me.Controls.Add(Me.txt_cliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel_tickets)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "parafacturar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "parafacturar"
        Me.Panel_tickets.ResumeLayout(False)
        CType(Me.FpTickets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSeleccionTarjetas.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_tickets As System.Windows.Forms.Panel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents BtnRegresar As System.Windows.Forms.Button
    Friend WithEvents BtnEnviar As System.Windows.Forms.Button
    Friend WithEvents BtnInicializar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_cliente As System.Windows.Forms.TextBox
    Friend WithEvents labelfiltro As System.Windows.Forms.Label
    Friend WithEvents TxtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents CmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chk_menores As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelSeleccionTarjetas As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbTDebito As RadioButton
    Friend WithEvents rbTCredito As RadioButton
    Friend WithEvents BtnCierraPanel As Button
    Friend WithEvents BtnRegistraTarjeta As Button
    Friend WithEvents lbFila As Label
    Friend WithEvents FpTickets As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpTickets_Sheet1 As FarPoint.Win.Spread.SheetView
End Class
