Imports System.Console
Public Class FrAdmin
    Inherits System.Windows.Forms.Form
    'Private xCon As System.Data.SqlClient.SqlConnection
    Dim encargada As Integer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AdministraciónDeCajasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministraciónDeTicketsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetirosDeEfectioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteRetirosDeEfectivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CorteDeCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirMóduloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents EmisiónDeEtiquetasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As CheckBox
    Dim usuario As String


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal a As Integer, ByVal b As String)
        MyBase.New()
        encargada = a
        usuario = b

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'xCon = con
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdministraciónDeCajasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministraciónDeTicketsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetirosDeEfectioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteRetirosDeEfectivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CorteDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmisiónDeEtiquetasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirMóduloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministraciónDeCajasToolStripMenuItem1, Me.SalirMóduloToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1024, 24)
        Me.MenuStrip1.TabIndex = 23883
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdministraciónDeCajasToolStripMenuItem1
        '
        Me.AdministraciónDeCajasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministraciónDeTicketsToolStripMenuItem, Me.RetirosDeEfectioToolStripMenuItem, Me.ReporteRetirosDeEfectivoToolStripMenuItem, Me.CorteDeCajaToolStripMenuItem, Me.EmisiónDeEtiquetasToolStripMenuItem})
        Me.AdministraciónDeCajasToolStripMenuItem1.Name = "AdministraciónDeCajasToolStripMenuItem1"
        Me.AdministraciónDeCajasToolStripMenuItem1.Size = New System.Drawing.Size(147, 20)
        Me.AdministraciónDeCajasToolStripMenuItem1.Text = "Administración de Cajas"
        '
        'AdministraciónDeTicketsToolStripMenuItem
        '
        Me.AdministraciónDeTicketsToolStripMenuItem.Name = "AdministraciónDeTicketsToolStripMenuItem"
        Me.AdministraciónDeTicketsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AdministraciónDeTicketsToolStripMenuItem.Text = "Administración de Tickets"
        '
        'RetirosDeEfectioToolStripMenuItem
        '
        Me.RetirosDeEfectioToolStripMenuItem.Name = "RetirosDeEfectioToolStripMenuItem"
        Me.RetirosDeEfectioToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RetirosDeEfectioToolStripMenuItem.Text = "Retiro de Efectivo"
        '
        'ReporteRetirosDeEfectivoToolStripMenuItem
        '
        Me.ReporteRetirosDeEfectivoToolStripMenuItem.Name = "ReporteRetirosDeEfectivoToolStripMenuItem"
        Me.ReporteRetirosDeEfectivoToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ReporteRetirosDeEfectivoToolStripMenuItem.Text = "Reporte Retiros de Efectivo "
        '
        'CorteDeCajaToolStripMenuItem
        '
        Me.CorteDeCajaToolStripMenuItem.Name = "CorteDeCajaToolStripMenuItem"
        Me.CorteDeCajaToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.CorteDeCajaToolStripMenuItem.Text = "Corte de Caja"
        '
        'EmisiónDeEtiquetasToolStripMenuItem
        '
        Me.EmisiónDeEtiquetasToolStripMenuItem.Name = "EmisiónDeEtiquetasToolStripMenuItem"
        Me.EmisiónDeEtiquetasToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.EmisiónDeEtiquetasToolStripMenuItem.Text = "Emisión de Etiquetas"
        '
        'SalirMóduloToolStripMenuItem
        '
        Me.SalirMóduloToolStripMenuItem.Name = "SalirMóduloToolStripMenuItem"
        Me.SalirMóduloToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.SalirMóduloToolStripMenuItem.Text = "Salir Módulo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGray
        Me.Label8.Location = New System.Drawing.Point(143, 529)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(262, 15)
        Me.Label8.TabIndex = 23889
        Me.Label8.Text = "Derechos Reservados Estrategias Competitivas 2011"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(142, 484)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(250, 21)
        Me.Label22.TabIndex = 23888
        Me.Label22.Text = "EC VENTAS MENUDEO Y MAYOREO"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(96, 503)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(336, 26)
        Me.Label23.TabIndex = 23887
        Me.Label23.Text = "Administración de PUNTO DE VENTA"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 670)
        Me.Panel1.TabIndex = 23890
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.SlateBlue
        Me.CheckBox1.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(663, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(91, 25)
        Me.CheckBox1.TabIndex = 23964
        Me.CheckBox1.Text = "Duarsa 1"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(639, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 26)
        Me.Label1.TabIndex = 23895
        Me.Label1.Text = "Módulo Administración de Caja"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(146, 205)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 267)
        Me.PictureBox1.TabIndex = 23884
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Location = New System.Drawing.Point(663, 99)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(253, 538)
        Me.Panel2.TabIndex = 23896
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button7.Location = New System.Drawing.Point(20, 212)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(212, 40)
        Me.Button7.TabIndex = 23896
        Me.Button7.Text = "Reporte Tarjetas Bancarias"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button3.Location = New System.Drawing.Point(20, 162)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(212, 40)
        Me.Button3.TabIndex = 23892
        Me.Button3.Text = "Reporte Retiros de Efectivo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.logoDUARSA
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(75, 458)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(109, 56)
        Me.PictureBox3.TabIndex = 23886
        Me.PictureBox3.TabStop = False
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button5.Location = New System.Drawing.Point(20, 404)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(212, 40)
        Me.Button5.TabIndex = 23894
        Me.Button5.Text = "Menú Anterior"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button1.Location = New System.Drawing.Point(20, 70)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(212, 40)
        Me.Button1.TabIndex = 23890
        Me.Button1.Text = "Administración de Tickets"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button4.Location = New System.Drawing.Point(20, 257)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(212, 40)
        Me.Button4.TabIndex = 23893
        Me.Button4.Text = "Corte de Caja"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button2.Location = New System.Drawing.Point(20, 116)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(212, 40)
        Me.Button2.TabIndex = 23891
        Me.Button2.Text = "Retiro de Efectivo de Caja"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrAdmin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 732)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrAdmin"
        Me.Text = " N"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Private Sub pb_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Abre(New FrVenta(xCon))
    'End Sub

    Private Sub Abre(ByVal oForma As Form)
        AddHandler oForma.Closed, AddressOf MuestraAdmin
        Hide()
        oForma.Show()
    End Sub

    Private Sub MuestraAdmin(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WindowState = FormWindowState.Normal
        Focus()
        Show()
    End Sub



    Private Sub FrAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim xcontrol As New Control
        Dim xcontrol1 As New Control
        Dim bandera As Boolean
        Dim xx As New Button
        Dim dsc As New DataSet
        Dim i As Integer

        ' ''If Not encargada Then
        ''Button40.Visible = True
        ' ''End If

        ''If encargada Then
        ''Button40.Visible = False
        'If Globales.nombreusuario = "SUPERVISOR////" Then
        '    Button40.Visible = True
        'Else
        '    Button40.Visible = False
        'End If

        sql = "Select  * from progusuarios where usuario='" & usuario & "'"
        Base.daQuery(sql, sCadenaConexionSQL, dsc, "Prog")


        For i = 0 To dsc.Tables("Prog").Rows.Count - 1
            bandera = False
            For Each xcontrol In Me.Controls
                If Not bandera Then
                    For Each xcontrol1 In xcontrol.Controls
                        If xcontrol1.Name = dsc.Tables("Prog").Rows(i)("nombrecontrol") Then
                            xx = xcontrol1
                            xx.Visible = IIf(dsc.Tables("Prog").Rows(i)("valor") = 1, True, False)
                            bandera = True
                            Exit For
                        End If

                    Next
                Else
                    Exit For
                End If
            Next
        Next
        dsc.Tables.Remove("Prog")
        'End If
    End Sub


    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim oForma As Form
        'oForma = New ventascliente(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub


    Private Sub SalirMóduloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirMóduloToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AdministraciónDeTicketsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministraciónDeTicketsToolStripMenuItem.Click
        'Dim oForma As Form
        'oForma = New reimprime(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub

    Private Sub RetirosDeEfectioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetirosDeEfectioToolStripMenuItem.Click
        'Dim oForma As Form
        'oForma = New retiros(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub

    Private Sub ReporteRetirosDeEfectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteRetirosDeEfectivoToolStripMenuItem.Click
        'Dim oForma As Form
        'oForma = New Repsalidascaja(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub

    Private Sub CorteDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorteDeCajaToolStripMenuItem.Click
        'Dim oForma As Form
        'oForma = New cortecajanuevo(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim oForma As Form
        'oForma = New reimprime(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim oForma As Form
        'oForma = New retiros(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim oForma As Form
        'oForma = New Repsalidascaja(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Dim oForma As Form
        'oForma = New cortecajanuevo(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub EmisiónDeEtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmisiónDeEtiquetasToolStripMenuItem.Click
        'Dim oForma As Form
        'oForma = New etiquetas(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Dim oForma As Form
        'oForma = New Reptarjetas(IIf(CheckBox1.Checked, FrLogin.rCon, sCadenaConexionSQL), Me)
        'AddHandler oForma.Closed, AddressOf MuestraAdmin
        'Hide()
        'oForma.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not My.Computer.Network.Ping(IIf(CheckBox1.Checked, sRemoto, sServidor)) Then
            If CheckBox1.Checked Then
                CheckBox1.Checked = False
                Globales.Remoto = False
            Else
                CheckBox1.Checked = True
                Globales.Remoto = True
            End If
            MsgBox("Servidor no disponible, verifique VPN.", vbExclamation, "EC Venta")
            Exit Sub
        End If

        Globales.Remoto = CheckBox1.Checked

        If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
            If CheckBox1.Checked Then
                CheckBox1.BackColor = Color.Blue
                CheckBox1.Text = "Duarsa 2"
            Else
                CheckBox1.BackColor = Color.SlateBlue
                CheckBox1.Text = "Duarsa 1"
            End If
        Else
            If CheckBox1.Checked Then
                CheckBox1.Text = "Duarsa 1"
                CheckBox1.BackColor = Color.SlateBlue
            Else
                CheckBox1.Text = "Duarsa 2"
                CheckBox1.BackColor = Color.Blue
            End If
        End If
    End Sub

End Class
