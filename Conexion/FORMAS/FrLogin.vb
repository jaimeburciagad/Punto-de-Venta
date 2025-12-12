Imports System.Data.SqlClient
Imports System.Deployment.Application
Public Class FrLogin
    Inherits System.Windows.Forms.Form
    Public xCon As New SqlConnection
    Public rCon As New SqlConnection
    Public Shared ConStr, rConStr As String

    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents panel_conf As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As CheckBox
    Public xcaja As String
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)

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
    Friend WithEvents txt_user As System.Windows.Forms.TextBox
    Friend WithEvents modificar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txt_user = New System.Windows.Forms.TextBox()
        Me.modificar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panel_conf = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_conf.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_user
        '
        Me.txt_user.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_user.Location = New System.Drawing.Point(433, 490)
        Me.txt_user.Name = "txt_user"
        Me.txt_user.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_user.Size = New System.Drawing.Size(209, 26)
        Me.txt_user.TabIndex = 0
        '
        'modificar
        '
        Me.modificar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.modificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.modificar.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar.ForeColor = System.Drawing.Color.Red
        Me.modificar.Location = New System.Drawing.Point(841, 12)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(57, 51)
        Me.modificar.TabIndex = 216
        Me.modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGray
        Me.Label8.Location = New System.Drawing.Point(413, 411)
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
        Me.Label22.Location = New System.Drawing.Point(412, 366)
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
        Me.Label23.Location = New System.Drawing.Point(366, 385)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(336, 26)
        Me.Label23.TabIndex = 23887
        Me.Label23.Text = "Administración de PUNTO DE VENTA"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(416, 87)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 267)
        Me.PictureBox1.TabIndex = 23884
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_user)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(16, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(996, 665)
        Me.Panel1.TabIndex = 23891
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.ForeColor = System.Drawing.Color.Navy
        Me.CheckBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(172, 26)
        Me.CheckBox1.TabIndex = 23898
        Me.CheckBox1.Text = "Entrar a Sucursal"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(443, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(188, 29)
        Me.Label6.TabIndex = 23895
        Me.Label6.Text = "Punto de Venta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(453, 466)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 21)
        Me.Label4.TabIndex = 23890
        Me.Label4.Text = "CONTROL DE ACCESO"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.logoDUARSA
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(16, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(83, 47)
        Me.PictureBox3.TabIndex = 23886
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(115, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 19)
        Me.Label1.TabIndex = 23892
        Me.Label1.Text = "AUTOSERVICIO DUARSA "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(115, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(357, 19)
        Me.Label2.TabIndex = 23893
        Me.Label2.Text = "Mercado de Abastos Gómez Palacio ,Durango"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(904, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 19)
        Me.Label3.TabIndex = 23894
        Me.Label3.Text = "Salir"
        '
        'panel_conf
        '
        Me.panel_conf.BackColor = System.Drawing.Color.Gainsboro
        Me.panel_conf.Controls.Add(Me.Label5)
        Me.panel_conf.Controls.Add(Me.Label9)
        Me.panel_conf.Controls.Add(Me.Label11)
        Me.panel_conf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_conf.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.panel_conf.Location = New System.Drawing.Point(228, 229)
        Me.panel_conf.Name = "panel_conf"
        Me.panel_conf.Size = New System.Drawing.Size(568, 310)
        Me.panel_conf.TabIndex = 23895
        Me.panel_conf.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(109, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(365, 82)
        Me.Label5.TabIndex = 545
        Me.Label5.Text = "SE HA GENERADO UNA APERTURA DE TURNO , PARA INGRESAR TECLEE NUEVAMENTE EL ACCESO " &
    ", EL FONDO DE CAJA SE ASIGNO NULO."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(121, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(323, 26)
        Me.Label9.TabIndex = 460
        Me.Label9.Text = "Confirmación de Apertura de Turno"
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
        'FrLogin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1024, 749)
        Me.Controls.Add(Me.panel_conf)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.modificar)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOGIN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_conf.ResumeLayout(False)
        Me.panel_conf.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Enum Puesto
        Vendedora = 1
        Supervisora = 2
        Encargada = 3
        NoExiste = 4
        Otro = 5
    End Enum

    Private Function determinaNivel(ByVal sNomina As String) As Puesto
        Dim sSql As String
        Dim dsc As New DataSet


        Base.Ejecuta("SELECT * FROM ECUSUARIOSX", xCon)
        sSql = "select * from ecusuariosx where emp_password='" & sNomina & "'"
        Try
            Base.daQuery(sSql, xCon, dsc, "EMPLEADO")

        Catch ex As Exception
            MsgBox(ex.Message)
            txt_user.Text = ""
            Exit Function
        End Try

        If dsc.Tables("empleado").Rows.Count > 0 Then
            Globales.sNominaEmpleado = dsc.Tables("empleado").Rows(0)("emp_nomina").ToString
            Globales.NombreEmpleado = dsc.Tables("empleado").Rows(0)("emp_nombre").ToString.Trim
            Globales.nombreusuario = dsc.Tables("empleado").Rows(0)("emp_nombre")
            Select Case Trim(dsc.Tables("empleado").Rows(0)("emp_tipo"))
                Case "Cajera"
                    Return Puesto.Vendedora
                Case "Supervisor"
                    Return Puesto.Encargada
                Case "Normal"
                    Return Puesto.Encargada
                Case "SUP"
                    Return Puesto.Supervisora

            End Select
        Else
            Return Puesto.NoExiste
        End If

    End Function

    Private Function abrirTurno() As Boolean
        Dim fecha As String
        fecha = Today.Year
        fecha = fecha & IIf(Today.Month < 10, "0" & Today.Month, Today.Month)
        fecha = fecha & IIf(Today.Day < 10, "0" & Today.Day, Today.Day)
        Base.Ejecuta("exec sp_creaturno '" & fecha & "'," & Globales.caja & ",'" & Globales.nombreusuario & "'", xCon)
        Return turnoAbierto()
    End Function
    Private Function turnoAbierto() As Boolean
        Dim dsc As New DataSet
        Dim sSql As String
        sSql = "select his_turno, his_fecha, his_activo  "
        sSql &= "from echisturno "
        sSql &= "where his_activo='A' AND HIS_CAJA='" & Globales.caja & "'"
        Base.daQuery(sSql, xCon, dsc, "turno")
        If dsc.Tables("turno").Rows.Count > 0 Then
            Globales.iTurnoActivo = dsc.Tables("turno").Rows(0)("his_turno")
            Globales.oFechaTurno = dsc.Tables("turno").Rows(0)("his_fecha")
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub MuestraLogin(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WindowState = FormWindowState.Normal
        Focus()
        Show()
    End Sub
    Private Sub FrLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_user.Clear()

        LeeParametrosConfiguracion()
        'iniciaConexion()
        txt_user.Focus()
    End Sub


    Private Function fondo()
        Dim dsc As New DataSet
        Dim sql As String
        sql = "select * from fondos where corte=0 and caja='" + Globales.caja + "'"
        Base.daQuery(sql, xCon, dsc, "fondo")
        If dsc.Tables("fondo").Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Private Sub leeParametrosConfiguracion()
        Dim FILECONFIG As New System.IO.StreamReader("C:\CONFIGECVENTA.txt")

        Dim sql As String
        Dim dsc As New DataSet

        On Error GoTo sigue
        Globales.sEmpresa = FILECONFIG.ReadLine
        Globales.sServidor = FILECONFIG.ReadLine
        Globales.sUsuarioBase = FILECONFIG.ReadLine
        Globales.sClaveUsuario = FILECONFIG.ReadLine
        Globales.sBaseDatos = FILECONFIG.ReadLine
        Globales.caja = "vscaja" & Val(FILECONFIG.ReadLine)
        Globales.numletras = FILECONFIG.ReadLine
        Globales.movimiento = -1
        Globales.movimiento = FILECONFIG.ReadLine
        Globales.rBaseDatos = FILECONFIG.ReadLine()
        If Globales.rBaseDatos = "" Then
            Globales.rBaseDatos = Globales.sBaseDatos
        End If
        Globales.FACTORIVA = Val(FILECONFIG.ReadLine)
        Globales.sRemoto = ""
        Globales.sRemoto = FILECONFIG.ReadLine

        If UCase(Globales.sServidor) <> "SERVER" Then
            If Not My.Computer.Network.Ping(sServidor) Then
                If Not My.Computer.Network.Ping(sRemoto) Then
                    MsgBox("No hay servidor disponible, verifique VPN.", vbExclamation, "EC Venta")
                    Exit Sub
                Else
                    CheckBox1.Checked = True
                End If
            End If
        End If

        If CheckBox1.Checked Then
            Dim TMP As String = Globales.sServidor

            Globales.sServidor = Globales.sRemoto
            Globales.sRemoto = TMP
        End If


sigue:
        If Globales.movimiento = -1 Then
            Globales.movimiento = 100
        End If




        iniciaConexion()


        sql = "select * from ecerp2018.dbo.ECERP_TICKET where ecerp_ticket_empresa_clave='" & Globales.sEmpresa & "' order by ecerp_ticket_empresa_renglon"
        Base.daQuery(sql, xCon, dsc, "tabla")


        If dsc.Tables("tabla").Rows.Count > 0 Then

            Globales.grupo = dsc.Tables("tabla").Rows(0)("ecerp_ticket_empresa_texto")
            Globales.empresa = dsc.Tables("tabla").Rows(1)("ecerp_ticket_empresa_texto")
            'Globales.rfc = dsc.Tables("tabla").Rows(2)("ecerp_ticket_empresa_texto")
            Globales.dir1 = dsc.Tables("tabla").Rows(3)("ecerp_ticket_empresa_texto")
            Globales.dir2 = dsc.Tables("tabla").Rows(4)("ecerp_ticket_empresa_texto")
            Globales.DIR3 = dsc.Tables("tabla").Rows(5)("ecerp_ticket_empresa_texto")
            Globales.CIUDAD = dsc.Tables("tabla").Rows(6)("ecerp_ticket_empresa_texto")
        End If

        dsc.Tables.Remove("tabla")

        sql = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='" & Globales.sEmpresa & "'"
        Base.daQuery(sql, xCon, dsc, "tabla")


        If dsc.Tables("tabla").Rows.Count > 0 Then
            Globales.basemicrosip = "USER=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & IIf(CheckBox1.Checked, Replace(dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sServidor & ":"), dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre")) & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"

            If Not IsDBNull(dsc.Tables("TABLA").Rows(0)("NomEmpresaNominaMicrosip")) Then
                Globales.BaseNominaMicrosip = "USER=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & IIf(CheckBox1.Checked, Replace(dsc.Tables("TABLA").Rows(0)("NomEmpresaNominaMicrosip"), "C:", sServidor & ":"), dsc.Tables("TABLA").Rows(0)("NomEmpresaNominaMicrosip")) & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"
            Else
                Globales.BaseNominaMicrosip = Globales.basemicrosip
            End If

            If Not IsDBNull(dsc.Tables("TABLA").Rows(0)("VendedorID")) Then
                Globales.VendedorID = dsc.Tables("TABLA").Rows(0)("VendedorID")
            Else
                Globales.VendedorID = -1
            End If




            Globales.usmicro = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_usuario_vc")
            Globales.SUCMICRO = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
            Globales.condpago = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
            Globales.CVEEXCENTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
            Globales.CVEIMPUESTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
            Globales.CVEIMPUESTOIEPS = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
            Globales.movimiento = dsc.Tables("tabla").Rows(0)("FactorMovimiento")
        End If
        dsc.Tables.Remove("tabla")

        DatosCrisp()
        DatosLuis()

        sql = "Select * from ecerp2018.dbo.ecerp_empresa where ecerp_empresa_clave='" & Globales.sEmpresa & "'"
        Base.daQuery(sql, xCon, dsc, "tabla")



        If dsc.Tables("tabla").Rows.Count > 0 Then
            Globales.nomempresa = dsc.Tables("tabla").Rows(0)("ECERP_empresa_refsis")
            Globales.cvesucursal = CInt(Strings.Right(Globales.nomempresa, 1))
            Globales.DirReportes = Replace(dsc.Tables("tabla").Rows(0)("ECERP_Empresa_Reportesvtas").ToString.ToUpper, "SERVER", Globales.sServidor)
            Globales.DirCargaXMLs = Replace(dsc.Tables("tabla").Rows(0)("ECERP_Empresa_XML").ToString.ToUpper, "SERVER", Globales.sServidor)
            Globales.rfc = dsc.Tables("tabla").Rows(0)("ECERP_Empresa_RFC")
        End If
        dsc.Tables.Remove("tabla")

        If sRemoto = "" Then
            Globales.rgrupo = ""
            Globales.rempresa = ""
            Globales.rrfc = ""
            Globales.rdir1 = ""
            Globales.rdir2 = ""
            Globales.rDIR3 = ""
            Globales.rCIUDAD = ""
            Globales.rusmicro = ""
            Globales.rsucmicro = 0
            Globales.rcondpago = 0
            Globales.rCVEEXCENTO = 0
            Globales.rCVEIMPUESTO = 0
            Globales.rCVEImpuestoIEPS = 0
            Globales.rmovimiento = 0
            Globales.rNomEmpresa = ""
            Globales.rDirReportes = ""
            Globales.rDirCargaXMLs = ""
        Else
            If My.Computer.Network.Ping(sRemoto) Then
                sql = "select * from ecerp2018.dbo.ECERP_TICKET where ecerp_ticket_empresa_clave='" & Globales.sEmpresa & "' order by ecerp_ticket_empresa_renglon"
                Base.daQuery(sql, rCon, dsc, "tabla")

                If dsc.Tables("tabla").Rows.Count > 0 Then
                    Globales.rgrupo = dsc.Tables("tabla").Rows(0)("ecerp_ticket_empresa_texto")
                    Globales.rempresa = dsc.Tables("tabla").Rows(1)("ecerp_ticket_empresa_texto")
                    'Globales.rrfc = dsc.Tables("tabla").Rows(2)("ecerp_ticket_empresa_texto")
                    Globales.rdir1 = dsc.Tables("tabla").Rows(3)("ecerp_ticket_empresa_texto")
                    Globales.rdir2 = dsc.Tables("tabla").Rows(4)("ecerp_ticket_empresa_texto")
                    Globales.rDIR3 = dsc.Tables("tabla").Rows(5)("ecerp_ticket_empresa_texto")
                    Globales.rCIUDAD = dsc.Tables("tabla").Rows(6)("ecerp_ticket_empresa_texto")
                End If

                dsc.Tables.Remove("tabla")

                sql = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='" & Globales.sEmpresa & "'"
                Base.daQuery(sql, rCon, dsc, "tabla")

                If dsc.Tables("tabla").Rows.Count > 0 Then
                    Globales.rBaseMicrosip = "USER=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                    "Password=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                    "Database=" & Replace(dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sRemoto & ":") & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                    "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                    "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"


                    If Not IsDBNull(dsc.Tables("TABLA").Rows(0)("NomEmpresaNominaMicrosip")) Then
                        Globales.rBaseNominaMicrosip = "USER=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                            "Password=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                            "Database=" & IIf(CheckBox1.Checked, Replace(dsc.Tables("TABLA").Rows(0)("NomEmpresaNominaMicrosip"), "C:", sServidor & ":"), dsc.Tables("TABLA").Rows(0)("NomEmpresaNominaMicrosip")) & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                            "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                            "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"
                    Else
                        Globales.rBaseNominaMicrosip = Globales.rBaseMicrosip
                    End If

                    If Not IsDBNull(dsc.Tables("TABLA").Rows(0)("VendedorID")) Then
                        Globales.rVendedorId = dsc.Tables("TABLA").Rows(0)("VendedorID")
                    Else
                        Globales.rVendedorId = -1
                    End If

                    Globales.rusmicro = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_usuario_vc")
                    Globales.rsucmicro = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
                    Globales.rcondpago = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
                    Globales.rCVEEXCENTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
                    Globales.rCVEIMPUESTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
                    Globales.rCVEImpuestoIEPS = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
                    Globales.rmovimiento = dsc.Tables("tabla").Rows(0)("FactorMovimiento")
                End If
                dsc.Tables.Remove("tabla")

                sql = "Select * from ecerp2018.dbo.ecerp_empresa where ecerp_empresa_clave='" & Globales.sEmpresa & "'"
                Base.daQuery(sql, rCon, dsc, "tabla")


                If dsc.Tables("tabla").Rows.Count > 0 Then
                    Globales.rNomEmpresa = dsc.Tables("tabla").Rows(0)("ECERP_empresa_refsis")
                    Globales.rDirReportes = Replace(dsc.Tables("tabla").Rows(0)("ECERP_Empresa_Reportesvtas").ToString.ToUpper, "SERVER", Globales.sRemoto)
                    Globales.rDirCargaXMLs = Replace(dsc.Tables("tabla").Rows(0)("ECERP_Empresa_XML").ToString.ToUpper, "SERVER", Globales.sRemoto)
                    Globales.rrfc = dsc.Tables("tabla").Rows(0)("ECERP_Empresa_RFC")
                End If
                dsc.Tables.Remove("tabla")
            Else
                Globales.rgrupo = ""
                Globales.rempresa = ""
                Globales.rrfc = ""
                Globales.rdir1 = ""
                Globales.rdir2 = ""
                Globales.rDIR3 = ""
                Globales.rCIUDAD = ""
                Globales.rusmicro = ""
                Globales.rsucmicro = 0
                Globales.rcondpago = 0
                Globales.rCVEEXCENTO = 0
                Globales.rCVEIMPUESTO = 0
                Globales.rCVEImpuestoIEPS = 0
                Globales.rmovimiento = 0
                Globales.rNomEmpresa = ""
                Globales.rDirReportes = ""
                Globales.rDirCargaXMLs = ""
            End If
        End If
        FILECONFIG.Close()
    End Sub

    Private Sub DatosCrisp()
        Dim SQL As String
        Dim DSC As New DataSet

        SQL = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='2'"
        Base.daQuery(SQL, xCon, DSC, "tabla")

        If DSC.Tables("tabla").Rows.Count > 0 Then
            Globales.BaseMicrosipCrisp = "USER=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & IIf(CheckBox1.Checked, Replace(DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sServidor & ":"), DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre")) & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"

            If Not IsDBNull(DSC.Tables("TABLA").Rows(0)("VendedorID")) Then
                Globales.VendedorIdCrisp = DSC.Tables("TABLA").Rows(0)("VendedorID")
            Else
                Globales.VendedorIdCrisp = -1
            End If

            Globales.SucMicrosipCrisp = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
            Globales.CondPagoCrisp = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
            Globales.CVEEXCENTOCrisp = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
            Globales.CVEIMPUESTOCrisp = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
            Globales.CVEIEPSCrisp = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
        Else
            Globales.BaseMicrosipCrisp = ""
            Globales.SucMicrosipCrisp = -1
            Globales.CondPagoCrisp = -1
            Globales.CVEEXCENTOCrisp = -1
            Globales.CVEIMPUESTOCrisp = -1
            Globales.CVEIEPSCrisp = -1
        End If
        DSC.Tables.Remove("tabla")

        If sRemoto = "" Then
            Globales.rBaseMicrosipCrisp = ""
            Globales.rSucMicrosipCrisp = -1
            Globales.rCondPagoCrisp = -1
            Globales.rCVEEXCENTOCrisp = -1
            Globales.rCVEIMPUESTOCrisp = -1
            Globales.rCVEIEPSCrisp = -1
        Else
            If My.Computer.Network.Ping(sRemoto) Then
                SQL = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='2'"
                Base.daQuery(SQL, rCon, DSC, "tabla")

                If DSC.Tables("tabla").Rows.Count > 0 Then
                    Globales.rBaseMicrosipCrisp = "USER=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & Replace(DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sRemoto & ":") & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"


                    If Not IsDBNull(DSC.Tables("TABLA").Rows(0)("VendedorID")) Then
                        Globales.rVendedorIdCrisp = DSC.Tables("TABLA").Rows(0)("VendedorID")
                    Else
                        Globales.rVendedorIdCrisp = -1
                    End If

                    Globales.rSucMicrosipCrisp = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
                    Globales.rCondPagoCrisp = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
                    Globales.rCVEEXCENTOCrisp = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
                    Globales.rCVEIMPUESTOCrisp = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
                    Globales.rCVEIEPSCrisp = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
                Else
                    Globales.rBaseMicrosipCrisp = ""
                    Globales.rSucMicrosipCrisp = -1
                    Globales.rCondPagoCrisp = -1
                    Globales.rCVEEXCENTOCrisp = -1
                    Globales.rCVEIMPUESTOCrisp = -1
                    Globales.rCVEIEPSCrisp = -1
                End If
                DSC.Tables.Remove("tabla")
            Else
                Globales.rBaseMicrosipCrisp = ""
                Globales.rSucMicrosipCrisp = -1
                Globales.rCondPagoCrisp = -1
                Globales.rCVEEXCENTOCrisp = -1
                Globales.rCVEIMPUESTOCrisp = -1
                Globales.rCVEIEPSCrisp = -1
            End If
        End If
    End Sub

    Private Sub DatosLuis()
        Dim SQL As String
        Dim DSC As New DataSet

        SQL = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='3'"
        Base.daQuery(SQL, xCon, DSC, "tabla")

        If DSC.Tables("tabla").Rows.Count > 0 Then
            Globales.BaseMicrosipLuisMario = "USER=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & IIf(CheckBox1.Checked, Replace(DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sServidor & ":"), DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre")) & ";" &
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"

            If Not IsDBNull(DSC.Tables("TABLA").Rows(0)("VendedorID")) Then
                Globales.VendedorIdLuisMario = DSC.Tables("TABLA").Rows(0)("VendedorID")
            Else
                Globales.VendedorIdLuisMario = -1
            End If

            Globales.SucMicrosipLuisMario = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
            Globales.CondPagoLuisMario = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
            Globales.CVEEXCENTOLuisMario = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
            Globales.CVEIMPUESTOLuisMario = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
            Globales.CVEIEPSLuisMario = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
        Else
            Globales.BaseMicrosipLuisMario = ""
            Globales.SucMicrosipLuisMario = -1
            Globales.CondPagoLuisMario = -1
            Globales.CVEEXCENTOLuisMario = -1
            Globales.CVEIMPUESTOLuisMario = -1
            Globales.CVEIEPSLuisMario = -1
        End If
        DSC.Tables.Remove("tabla")

        If sRemoto = "" Then
            Globales.rBaseMicrosipLuisMario = ""
            Globales.rSucMicrosipLuisMario = -1
            Globales.rCondPagoLuisMario = -1
            Globales.rCVEEXCENTOLuisMario = -1
            Globales.rCVEIMPUESTOLuisMario = -1
            Globales.rCVEIEPSLuisMario = -1
        Else
            If My.Computer.Network.Ping(sRemoto) Then
                SQL = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='3'"
                Base.daQuery(SQL, rCon, DSC, "tabla")

                If DSC.Tables("tabla").Rows.Count > 0 Then
                    Globales.rBaseMicrosipLuisMario = "USER=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & Replace(DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sRemoto & ":") & ";" &
                "DataSource=" & sServidor & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"

                    If Not IsDBNull(DSC.Tables("TABLA").Rows(0)("VendedorID")) Then
                        Globales.rVendedorIdLuisMario = DSC.Tables("TABLA").Rows(0)("VendedorID")
                    Else
                        Globales.rVendedorIdLuisMario = -1
                    End If

                    Globales.rSucMicrosipLuisMario = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
                    Globales.rCondPagoLuisMario = DSC.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
                    Globales.rCVEEXCENTOLuisMario = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
                    Globales.rCVEIMPUESTOLuisMario = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
                    Globales.rCVEIEPSLuisMario = DSC.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
                Else
                    Globales.rBaseMicrosipLuisMario = ""
                    Globales.rSucMicrosipLuisMario = -1
                    Globales.rCondPagoLuisMario = -1
                    Globales.rCVEEXCENTOLuisMario = -1
                    Globales.rCVEIMPUESTOLuisMario = -1
                    Globales.rCVEIEPSLuisMario = -1
                End If
                DSC.Tables.Remove("tabla")
            Else
                Globales.rBaseMicrosipLuisMario = ""
                Globales.rSucMicrosipLuisMario = -1
                Globales.rCondPagoLuisMario = -1
                Globales.rCVEEXCENTOLuisMario = -1
                Globales.rCVEIMPUESTOLuisMario = -1
                Globales.rCVEIEPSLuisMario = -1
            End If
        End If
    End Sub
    Private Sub LeeParametrosConfiguracionORIGINAK()
        Dim FILECONFIG As New System.IO.StreamReader("C:\CONFIGECVENTA.txt")
        Dim x As String
        Dim sql As String
        Dim dsc As New DataSet

        On Error GoTo sigue
        Globales.sEmpresa = FILECONFIG.ReadLine
        Globales.sServidor = FILECONFIG.ReadLine
        Globales.sUsuarioBase = FILECONFIG.ReadLine
        Globales.sClaveUsuario = FILECONFIG.ReadLine
        Globales.sBaseDatos = FILECONFIG.ReadLine
        Globales.caja = "vscaja" & Val(FILECONFIG.ReadLine)
        Globales.numletras = FILECONFIG.ReadLine
        Globales.movimiento = -1
        Globales.movimiento = FILECONFIG.ReadLine
        x = FILECONFIG.ReadLine()
        Globales.FACTORIVA = Val(FILECONFIG.ReadLine)
        Globales.sRemoto = ""
        Globales.sRemoto = FILECONFIG.ReadLine

        If UCase(Globales.sServidor) <> "SERVER" Then
            If Not My.Computer.Network.Ping(sServidor) Then
                If Not My.Computer.Network.Ping(sRemoto) Then
                    MsgBox("No hay servidor disponible, verifique VPN.", vbExclamation, "EC Venta")
                    Exit Sub
                Else
                    CheckBox1.Checked = True
                End If
            End If
        End If

        If CheckBox1.Checked Then
            Dim TMP As String = Globales.sServidor

            Globales.sServidor = Globales.sRemoto
            Globales.sRemoto = TMP
        End If


sigue:
        If Globales.movimiento = -1 Then
            Globales.movimiento = 100
        End If




        iniciaConexion()


        sql = "select * from ecerp2018.dbo.ECERP_TICKET where ecerp_ticket_empresa_clave='" & Globales.sEmpresa & "' order by ecerp_ticket_empresa_renglon"
        Base.daQuery(sql, xCon, dsc, "tabla")

        If dsc.Tables("tabla").Rows.Count > 0 Then

            Globales.grupo = dsc.Tables("tabla").Rows(0)("ecerp_ticket_empresa_texto")
            Globales.empresa = dsc.Tables("tabla").Rows(1)("ecerp_ticket_empresa_texto")
            Globales.rfc = dsc.Tables("tabla").Rows(2)("ecerp_ticket_empresa_texto")
            Globales.dir1 = dsc.Tables("tabla").Rows(3)("ecerp_ticket_empresa_texto")
            Globales.dir2 = dsc.Tables("tabla").Rows(4)("ecerp_ticket_empresa_texto")
            Globales.DIR3 = dsc.Tables("tabla").Rows(5)("ecerp_ticket_empresa_texto")
            Globales.CIUDAD = dsc.Tables("tabla").Rows(6)("ecerp_ticket_empresa_texto")
        End If

        dsc.Tables.Remove("tabla")

        sql = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='" & Globales.sEmpresa & "'"
        Base.daQuery(sql, xCon, dsc, "tabla")

        If dsc.Tables("tabla").Rows.Count > 0 Then
            Globales.basemicrosip = "USER=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & IIf(CheckBox1.Checked, Replace(dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sServidor & ":"), dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre")) & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"
            If Not IsDBNull(dsc.Tables("TABLA").Rows(0)("VendedorID")) Then
                Globales.VendedorID = dsc.Tables("TABLA").Rows(0)("VendedorID")
            Else
                Globales.VendedorID = -1
            End If

            Globales.usmicro = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_usuario_vc")
            Globales.SUCMICRO = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
            Globales.condpago = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
            Globales.CVEEXCENTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
            Globales.CVEIMPUESTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
            Globales.CVEIMPUESTOIEPS = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
            Globales.movimiento = dsc.Tables("tabla").Rows(0)("FactorMovimiento")
        End If
        dsc.Tables.Remove("tabla")


        sql = "Select * from ecerp2018.dbo.ecerp_empresa where ecerp_empresa_clave='" & Globales.sEmpresa & "'"
        Base.daQuery(sql, xCon, dsc, "tabla")

        If dsc.Tables("tabla").Rows.Count > 0 Then
            Globales.nomempresa = dsc.Tables("tabla").Rows(0)("ECERP_empresa_refsis")
            Globales.DirReportes = dsc.Tables("tabla").Rows(0)("ECERP_Empresa_Reportesvtas")
        End If
        dsc.Tables.Remove("tabla")

        If sRemoto = "" Then
            Globales.rgrupo = ""
            Globales.rempresa = ""
            Globales.rrfc = ""
            Globales.rdir1 = ""
            Globales.rdir2 = ""
            Globales.rDIR3 = ""
            Globales.rCIUDAD = ""
            Globales.rusmicro = ""
            Globales.rsucmicro = 0
            Globales.rcondpago = 0
            Globales.rCVEEXCENTO = 0
            Globales.rCVEIMPUESTO = 0
            Globales.rCVEImpuestoIEPS = 0
            Globales.rmovimiento = 0
            Globales.rNomEmpresa = ""
            Globales.rDirReportes = ""
            Globales.rDirCargaXMLs = ""
        Else
            If My.Computer.Network.Ping(sRemoto) Then
                sql = "select * from ecerp2018.dbo.ECERP_TICKET where ecerp_ticket_empresa_clave='" & Globales.sEmpresa & "' order by ecerp_ticket_empresa_renglon"
                Base.daQuery(sql, rCon, dsc, "tabla")

                If dsc.Tables("tabla").Rows.Count > 0 Then
                    Globales.rgrupo = dsc.Tables("tabla").Rows(0)("ecerp_ticket_empresa_texto")
                    Globales.rempresa = dsc.Tables("tabla").Rows(1)("ecerp_ticket_empresa_texto")
                    Globales.rrfc = dsc.Tables("tabla").Rows(2)("ecerp_ticket_empresa_texto")
                    Globales.rdir1 = dsc.Tables("tabla").Rows(3)("ecerp_ticket_empresa_texto")
                    Globales.rdir2 = dsc.Tables("tabla").Rows(4)("ecerp_ticket_empresa_texto")
                    Globales.rDIR3 = dsc.Tables("tabla").Rows(5)("ecerp_ticket_empresa_texto")
                    Globales.rCIUDAD = dsc.Tables("tabla").Rows(6)("ecerp_ticket_empresa_texto")
                End If

                dsc.Tables.Remove("tabla")

                sql = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='" & Globales.sEmpresa & "'"
                Base.daQuery(sql, rCon, dsc, "tabla")

                If dsc.Tables("tabla").Rows.Count > 0 Then
                    Globales.rBaseMicrosip = "USER=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & Replace(dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sRemoto & ":") & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"

                    Globales.rusmicro = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_usuario_vc")
                    Globales.rsucmicro = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
                    Globales.rcondpago = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
                    Globales.rCVEEXCENTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
                    Globales.rCVEIMPUESTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
                    Globales.rCVEImpuestoIEPS = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
                    Globales.rmovimiento = dsc.Tables("tabla").Rows(0)("FactorMovimiento")
                End If
                dsc.Tables.Remove("tabla")

                sql = "Select * from ecerp2018.dbo.ecerp_empresa where ecerp_empresa_clave='" & Globales.sEmpresa & "'"
                Base.daQuery(sql, rCon, dsc, "tabla")

                If dsc.Tables("tabla").Rows.Count > 0 Then
                    Globales.rNomEmpresa = dsc.Tables("tabla").Rows(0)("ECERP_empresa_refsis")
                    Globales.rDirReportes = dsc.Tables("tabla").Rows(0)("ECERP_Empresa_Reportesvtas")
                    Globales.rDirCargaXMLs = dsc.Tables("tabla").Rows(0)("ECERP_Empresa_XML")
                End If
                dsc.Tables.Remove("tabla")
            Else
                Globales.rgrupo = ""
                Globales.rempresa = ""
                Globales.rrfc = ""
                Globales.rdir1 = ""
                Globales.rdir2 = ""
                Globales.rDIR3 = ""
                Globales.rCIUDAD = ""
                Globales.rusmicro = ""
                Globales.rsucmicro = 0
                Globales.rcondpago = 0
                Globales.rCVEEXCENTO = 0
                Globales.rCVEIMPUESTO = 0
                Globales.rCVEImpuestoIEPS = 0
                Globales.rmovimiento = 0
                Globales.rNomEmpresa = ""
                Globales.rDirReportes = ""
                Globales.rDirCargaXMLs = ""
            End If
        End If


        FILECONFIG.Close()
    End Sub

    Private Sub leeParametrosConfiguracionn()
        Dim FILECONFIG As New System.IO.StreamReader("C:\CONFIGPV.txt")
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer

        Globales.sEmpresa = FILECONFIG.ReadLine
        Globales.sServidor = FILECONFIG.ReadLine
        Globales.sUsuarioBase = FILECONFIG.ReadLine
        Globales.sClaveUsuario = FILECONFIG.ReadLine
        Globales.sBaseDatos = FILECONFIG.ReadLine
        Globales.caja = "vscaja" & Val(FILECONFIG.ReadLine)
        Globales.numletras = FILECONFIG.ReadLine
        Globales.movimiento = -1

        Globales.FACTORIVA = 16

sigue:
        If Globales.movimiento = -1 Then
            Globales.movimiento = 100
        End If


        iniciaConexion()


        sql = "select * from ecerp2018.dbo.ECERP_TICKET where ecerp_ticket_empresa_clave='" & Globales.sEmpresa & "' order by ecerp_ticket_empresa_renglon"
        Base.daQuery(sql, xCon, dsc, "tabla")

        If dsc.Tables("tabla").Rows.Count > 0 Then

            Globales.grupo = dsc.Tables("tabla").Rows(0)("ecerp_ticket_empresa_texto")
            Globales.empresa = dsc.Tables("tabla").Rows(1)("ecerp_ticket_empresa_texto")
            Globales.rfc = dsc.Tables("tabla").Rows(2)("ecerp_ticket_empresa_texto")
            Globales.dir1 = dsc.Tables("tabla").Rows(3)("ecerp_ticket_empresa_texto")
            Globales.dir2 = dsc.Tables("tabla").Rows(4)("ecerp_ticket_empresa_texto")
            Globales.DIR3 = dsc.Tables("tabla").Rows(5)("ecerp_ticket_empresa_texto")
            Globales.CIUDAD = dsc.Tables("tabla").Rows(6)("ecerp_ticket_empresa_texto")
        End If

        dsc.Tables.Remove("tabla")

        sql = "sELECT * FROM ECERP2018.DBO.ECERP_CONFIGBD WHERE ecerp_Configbd_empresa_clave='" & Globales.sEmpresa & "'"
        Base.daQuery(sql, xCon, dsc, "tabla")

        If dsc.Tables("tabla").Rows.Count > 0 Then
            Globales.basemicrosip = "USER=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_USUARIO_VC") & ";" &
                "Password=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_PASS_VC") & ";" &
                "Database=" & IIf(CheckBox1.Checked, Replace(dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre"), "C:", sServidor & ":"), dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_nombre")) & ";" & '"Database=C:\MICROSIP DATOS\CRISP SERVICE S DE RL (2018).fdb;" & '
                "DataSource=" & sServidor & ";" & '"DataSource=" & dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_servidor") & ";" &
                "Port=3050;Dialect=3;Charset=NONE;Role=;Pooling=true;ServerType=0;"

            If Not IsDBNull(dsc.Tables("TABLA").Rows(0)("VendedorID")) Then
                Globales.VendedorID = dsc.Tables("TABLA").Rows(0)("VendedorID")
            Else
                Globales.VendedorID = -1
            End If
            Globales.usmicro = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_usuario_vc")
            Globales.SUCMICRO = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_suc")
            Globales.condpago = dsc.Tables("TABLA").Rows(0)("ECERP_CONFIGBD_coNdpago")
            Globales.CVEEXCENTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva0")
            Globales.CVEIMPUESTO = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva16")
            Globales.CVEIMPUESTOIEPS = dsc.Tables("tabla").Rows(0)("ECERP_CONFIGBD_iva8")
            Globales.movimiento = dsc.Tables("tabla").Rows(0)("FactorMovimiento")
        End If
        dsc.Tables.Remove("tabla")



        'Globales.grupo = "AUTOSERVICIO DUARSA"
        'Globales.empresa = "MARIA LUISA DUARTE SALAZAR"
        'Globales.rfc = "RFC: DUSL 650621 R78"
        'Globales.dir1 = "Calle 3a. Bodega 300 "
        'Globales.dir2 = "Mercado de Abastos , C.P. 35078 "
        'Globales.CIUDAD = "de Gómez Palacio Dgo"
        'Globales.DIR3 = "Gómez Palacio, Durango"


        FILECONFIG.Close()
    End Sub
    Private Sub iniciaConexion()
        Dim SQL As String
        Dim DSC As New DataSet

        'Iniciar la conexión, los parámetros correctos
        'se deben leer del archivo XML
        Dim sConexion As String
        sConexion = "SERVER=" & Globales.sServidor & ";"
        sConexion &= " DATABASE=" & Globales.sBaseDatos & ";"
        sConexion &= " INTEGRATED SECURITY=FALSE;"
        sConexion &= " USER ID=" & Globales.sUsuarioBase & ";"
        sConexion &= " PASSWORD=" & Globales.sClaveUsuario
        xCon.ConnectionString = sConexion
        ConStr = sConexion
        rCon.ConnectionString = "SERVER=" & Globales.sRemoto & ";" & " DATABASE=" & Globales.sBaseDatos & ";" & " INTEGRATED SECURITY=FALSE;" & " USER ID=" & Globales.sUsuarioBase & ";" & " PASSWORD=" & Globales.sClaveUsuario
        rConStr = "SERVER=" & Globales.sRemoto & ";" & " DATABASE=" & Globales.sBaseDatos & ";" & " INTEGRATED SECURITY=FALSE;" & " USER ID=" & Globales.sUsuarioBase & ";" & " PASSWORD=" & Globales.sClaveUsuario




        'Sql = "select emp_microsip,micro_impuesto,micro_exento from ecempresas"
        'Base.daQuery(Sql, xCon, dsc, "tabla")
        'If DSC.Tables("tabla").Rows.Count > 0 Then
        '    Globales.CVEEXCENTO = DSC.Tables("tabla").Rows(0)("micro_exento")
        '    Globales.CVEIMPUESTO = DSC.Tables("tabla").Rows(0)("micro_impuesto")
        '    Globales.basemicrosip = DSC.Tables("tabla").Rows(0)("emp_microsip")
        'End If

        'dsc.Tables.Remove("tabla")

    End Sub


    ' Private Sub lb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_0.Click, lb_1.Click, lb_2.Click, lb_3.Click, lb_4.Click, lb_5.Click, lb_6.Click, lb_7.Click, lb_8.Click, lb_9.Click
    '    txt_user.Text &= sender.Name.ToString.Chars(3).ToString
    'End Sub

    Private Sub lb_canc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_user.Clear()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim iUsuario As Puesto
        Dim oForma As Form
        If txt_user.Text <> "" Then
            Dim i As Integer

            For i = 1 To Len(LTrim(RTrim(Me.txt_user.Text)))
                If IsNumeric(Mid(txt_user.Text, i, 1)) Then
                    Exit For
                End If
            Next
            txt_user.Text = Mid(txt_user.Text, i, Len(txt_user.Text) - i + 1)

            iUsuario = determinaNivel(txt_user.Text)

            Select Case iUsuario
                Case Puesto.Vendedora
                    'Si es vendedora y ya se abrió el turno se entra
                    'a la pantalla de venta de manera directa

                    If turnoAbierto() OrElse abrirTurno() Then
                        If fondo() Then

                            txt_user.Clear()

                            oForma = New FrVenta(xCon, Me)
                            AddHandler oForma.Closed, AddressOf MuestraLogin
                            Hide()
                            oForma.Show()
                        Else

                            txt_user.Clear()
                            panel_conf.Visible = True
                            ABRETURNO()
                            MsgBox("CONTINUAR", vbExclamation)
                            panel_conf.Visible = False
                        End If

                    Else
                        MessageBox.Show("Error al revisar periodo, intentar de nuevo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case Puesto.Supervisora
                    'Se entra a la pantalla de menú administrativo
                    txt_user.Clear()
                    oForma = New FrAdmin(xCon, 0, "")
                    AddHandler oForma.Closed, AddressOf MuestraLogin

                    Hide()
                    oForma.Show()
                Case Puesto.Encargada
                    txt_user.Clear()
                    oForma = New FrAdmin(xCon, 1, Globales.nombreusuario)
                    AddHandler oForma.Closed, AddressOf MuestraLogin

                    Hide()
                    oForma.Show()
                    'Ahí ke definir que se va a hacer cuando entra
                    'una encargada
                Case Puesto.NoExiste
                    MessageBox.Show("Número de nómina no existe, favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_user.Clear()
                Case Else
                    'Aquí hay ke hacer algo para cuando el puesto no esté contempleado
                    'a entrar
            End Select
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txt_user.Clear()
    End Sub

    Private Sub txt_user_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_user.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.PictureBox3_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            If CheckBox1.Checked Then
                CheckBox1.Checked = False
            Else
                CheckBox1.Checked = True
            End If
        End If

    End Sub

    Private Sub ABRETURNO()
        Dim cuanto As Double
        Dim cajax As String
        cajax = Globales.caja
        cuanto = 0
        Dim SQL As String
        SQL = "insert fondos values(" & cuanto & ",getdate(),'" & cajax & "',0)"
        Base.Ejecuta(SQL, xCon)

    End Sub

    Private Sub modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles modificar.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not My.Computer.Network.Ping(IIf(CheckBox1.Checked, sRemoto, sServidor)) Then
            If CheckBox1.Checked Then
                CheckBox1.Checked = False
            Else
                CheckBox1.Checked = True
            End If
            MsgBox("Servidor no disponible, verifique VPN.", vbExclamation, "EC Venta")
            Exit Sub
        End If
        Globales.Remoto = CheckBox1.Checked

        LeeParametrosConfiguracion()
        If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
            Me.BackColor = Color.Gainsboro
        Else
            Me.BackColor = Color.AliceBlue
        End If
        txt_user.Focus()

    End Sub

End Class
