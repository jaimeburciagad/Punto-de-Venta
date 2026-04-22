Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Imaging
Imports System.Math
Imports System.Security.Cryptography
Imports FarPoint.PDF.Drawing.EMF
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.CellType
Imports FarPoint.Win.Spread.Model
Imports GrapeCity.Spreadsheet.Charts


Public Class FrVenta

    Inherits System.Windows.Forms.Form
    'Public xCon As SqlConnection
    Public numt As Integer
    Dim cerrar As Integer = 1
    Private sConexion As String
    Private hashPanel As New Hashtable
    Private sCant As String = "" ' Almacena la cantidad de un Artículo a pedir
    Private imgFamilia As Image 'Imagen del título principal
    Private masClicks As Integer
    Private claveArt As String
    Private preImpresion As New Collection
    Public HayTarjeta As Boolean
    Private formaspago As Boolean
    Private fpago As Integer
    Public PERMISOVENDER As Boolean
    Private buscararticulo As Boolean
    Private cancelacion As Boolean
    Private F3Cantidad As Boolean
    Private FueConF1 As Boolean
    Public autorizame As Boolean
    Public AutorizaCierreCambioVentana As Boolean
    Public NuevoTipoVenta As Integer
    Public xven As Decimal
    Public MontoMaximoComision, totalote, TotalComision As Decimal
    Public claveprod As String
    Dim virtual As Integer
    Public segundoticket As Boolean
    Public sipuntos As Boolean
    Public estiempoaire As Boolean
    Public pagare As Boolean
    Public clientex As String
    Public totalpagos As Decimal
    Public TIPOVENTA As Integer
    Public codigotp As String
    Public datostel As Boolean

    Public Property TotalVenta As Decimal
    Public Property TotalPago As Decimal

    Public band As Boolean
    Public Flogin As FrLogin
    Public TIEMPOCOMIS As Integer
    Public VentaCajaVirtual As Boolean
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents pBoxF1 As System.Windows.Forms.PictureBox
    Friend WithEvents LbF1 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox25 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LFORPAG As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents panelofe As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_panelofe As System.Windows.Forms.TextBox
    Friend WithEvents txtnotifica As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BTN_NUEVO As System.Windows.Forms.Button
    Friend WithEvents Paneltiempo As System.Windows.Forms.Panel
    Friend WithEvents txt_ctel4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ctel3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ctel2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ctel1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_tel4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_tel3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_tel2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_tel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As Button
    Friend WithEvents LbTotal As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TxtControl As TextBox
    Friend WithEvents LbIDOferta As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents PanelCancelaciones As Panel
    Friend WithEvents BtnCambiaVenta As Button
    Friend WithEvents PanelSeleccionTarjetas As GroupBox
    Friend WithEvents lbFila As Label
    Friend WithEvents BtnCierraPanel As Button
    Friend WithEvents BtnRegistraTarjeta As Button
    Friend WithEvents rbTDebito As RadioButton
    Friend WithEvents rbTCredito As RadioButton
    Friend WithEvents LbClienteTicket As Label
    Friend WithEvents BtnCambiaCliente As Button
    Friend WithEvents TimerReloj As Timer
    Friend WithEvents FpArticulos As FpSpread
    Friend WithEvents FpArticulos_Sheet1 As SheetView
    Friend WithEvents FpFormasPago As FpSpread
    Friend WithEvents FpFormasPago_Sheet1 As SheetView
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents FpArticulos_Sheet2 As SheetView
    Public acredito As Double

    'Funcion Que Manda a Llamar un Sonido.....(API windows)
    Private Declare Function sndPlaySoundA Lib "WinMM" (ByVal nameString As String, ByVal flags As Integer) As Integer


#Region " código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef Login As FrLogin)
        MyBase.New()
        Flogin = Login
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
        'xCon = con
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
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents TX_UPC As System.Windows.Forms.TextBox
    Friend WithEvents tx_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents l_cantidad As System.Windows.Forms.Label
    Friend WithEvents l_cancelacion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grformapago As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Lkilos As System.Windows.Forms.Label
    Friend WithEvents busqueda As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lcambio As System.Windows.Forms.Label
    Friend WithEvents TXB_BANCO As System.Windows.Forms.TextBox
    Friend WithEvents banco As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents credito As System.Windows.Forms.GroupBox
    Friend WithEvents Cliente As System.Windows.Forms.Label
    Friend WithEvents txb_credito As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_tipoventa As System.Windows.Forms.TextBox
    Friend WithEvents txb_credito1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_cveenc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_foliopago As System.Windows.Forms.TextBox
    Friend WithEvents TX_TOTALPAGO As System.Windows.Forms.Label
    Friend WithEvents txe As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrVenta))
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.TX_UPC = New System.Windows.Forms.TextBox()
        Me.tx_cantidad = New System.Windows.Forms.TextBox()
        Me.l_cantidad = New System.Windows.Forms.Label()
        Me.l_cancelacion = New System.Windows.Forms.Label()
        Me.grformapago = New System.Windows.Forms.GroupBox()
        Me.banco = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXB_BANCO = New System.Windows.Forms.TextBox()
        Me.credito = New System.Windows.Forms.GroupBox()
        Me.txb_credito1 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txb_credito = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txt_foliopago = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.PictureBox21 = New System.Windows.Forms.PictureBox()
        Me.PictureBox22 = New System.Windows.Forms.PictureBox()
        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.PictureBox25 = New System.Windows.Forms.PictureBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TX_TOTALPAGO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lcambio = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.FpFormasPago = New FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource1"))
        Me.FpArticulos_Sheet1 = Me.FpFormasPago.GetSheet(0)
        Me.LFORPAG = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Lkilos = New System.Windows.Forms.Label()
        Me.busqueda = New System.Windows.Forms.Label()
        Me.txt_tipoventa = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txe = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_cveenc = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LbF1 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnCambiaCliente = New System.Windows.Forms.Button()
        Me.BtnCambiaVenta = New System.Windows.Forms.Button()
        Me.TxtControl = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.pBoxF1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.panelofe = New System.Windows.Forms.Panel()
        Me.LbIDOferta = New System.Windows.Forms.Label()
        Me.BTN_NUEVO = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_panelofe = New System.Windows.Forms.TextBox()
        Me.txtnotifica = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Paneltiempo = New System.Windows.Forms.Panel()
        Me.txt_ctel4 = New System.Windows.Forms.TextBox()
        Me.txt_ctel3 = New System.Windows.Forms.TextBox()
        Me.txt_ctel2 = New System.Windows.Forms.TextBox()
        Me.txt_ctel1 = New System.Windows.Forms.TextBox()
        Me.txt_tel4 = New System.Windows.Forms.TextBox()
        Me.txt_tel3 = New System.Windows.Forms.TextBox()
        Me.txt_tel2 = New System.Windows.Forms.TextBox()
        Me.txt_tel1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.LbTotal = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PanelCancelaciones = New System.Windows.Forms.Panel()
        Me.PanelSeleccionTarjetas = New System.Windows.Forms.GroupBox()
        Me.lbFila = New System.Windows.Forms.Label()
        Me.BtnCierraPanel = New System.Windows.Forms.Button()
        Me.BtnRegistraTarjeta = New System.Windows.Forms.Button()
        Me.rbTDebito = New System.Windows.Forms.RadioButton()
        Me.rbTCredito = New System.Windows.Forms.RadioButton()
        Me.LbClienteTicket = New System.Windows.Forms.Label()
        Me.TimerReloj = New System.Windows.Forms.Timer(Me.components)
        Me.FpArticulos = New FarPoint.Win.Spread.FpSpread(FarPoint.Win.Spread.LegacyBehaviors.None, resources.GetObject("resource2"))
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.FpArticulos_Sheet2 = Me.FpArticulos.GetSheet(0)
        Me.grformapago.SuspendLayout()
        Me.banco.SuspendLayout()
        Me.credito.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpFormasPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBoxF1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelofe.SuspendLayout()
        Me.Paneltiempo.SuspendLayout()
        Me.PanelCancelaciones.SuspendLayout()
        Me.PanelSeleccionTarjetas.SuspendLayout()
        CType(Me.FpArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tb_total
        '
        Me.tb_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tb_total.BackColor = System.Drawing.Color.White
        Me.tb_total.Enabled = False
        Me.tb_total.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(227, 596)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(218, 35)
        Me.tb_total.TabIndex = 53
        Me.tb_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tb_total.Visible = False
        '
        'TX_UPC
        '
        Me.TX_UPC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TX_UPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TX_UPC.Location = New System.Drawing.Point(311, 705)
        Me.TX_UPC.Name = "TX_UPC"
        Me.TX_UPC.Size = New System.Drawing.Size(224, 26)
        Me.TX_UPC.TabIndex = 1
        '
        'tx_cantidad
        '
        Me.tx_cantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tx_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_cantidad.Location = New System.Drawing.Point(877, 705)
        Me.tx_cantidad.Name = "tx_cantidad"
        Me.tx_cantidad.Size = New System.Drawing.Size(112, 26)
        Me.tx_cantidad.TabIndex = 192
        Me.tx_cantidad.Visible = False
        '
        'l_cantidad
        '
        Me.l_cantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.l_cantidad.BackColor = System.Drawing.Color.Transparent
        Me.l_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_cantidad.ForeColor = System.Drawing.Color.Black
        Me.l_cantidad.Location = New System.Drawing.Point(736, 705)
        Me.l_cantidad.Name = "l_cantidad"
        Me.l_cantidad.Size = New System.Drawing.Size(135, 23)
        Me.l_cantidad.TabIndex = 193
        Me.l_cantidad.Text = "Cantidad:"
        Me.l_cantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.l_cantidad.Visible = False
        '
        'l_cancelacion
        '
        Me.l_cancelacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.l_cancelacion.BackColor = System.Drawing.Color.Transparent
        Me.l_cancelacion.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_cancelacion.ForeColor = System.Drawing.Color.Black
        Me.l_cancelacion.Location = New System.Drawing.Point(170, 705)
        Me.l_cancelacion.Name = "l_cancelacion"
        Me.l_cancelacion.Size = New System.Drawing.Size(122, 27)
        Me.l_cancelacion.TabIndex = 194
        Me.l_cancelacion.Text = "Cancelar "
        Me.l_cancelacion.Visible = False
        '
        'grformapago
        '
        Me.grformapago.BackColor = System.Drawing.Color.AliceBlue
        Me.grformapago.Controls.Add(Me.banco)
        Me.grformapago.Controls.Add(Me.credito)
        Me.grformapago.Controls.Add(Me.GroupBox1)
        Me.grformapago.Controls.Add(Me.txt_foliopago)
        Me.grformapago.Controls.Add(Me.Panel6)
        Me.grformapago.Controls.Add(Me.TX_TOTALPAGO)
        Me.grformapago.Controls.Add(Me.Label9)
        Me.grformapago.Controls.Add(Me.lcambio)
        Me.grformapago.Controls.Add(Me.Label17)
        Me.grformapago.Controls.Add(Me.Label10)
        Me.grformapago.Controls.Add(Me.FpFormasPago)
        Me.grformapago.Location = New System.Drawing.Point(207, 237)
        Me.grformapago.Name = "grformapago"
        Me.grformapago.Size = New System.Drawing.Size(646, 449)
        Me.grformapago.TabIndex = 200
        Me.grformapago.TabStop = False
        '
        'banco
        '
        Me.banco.BackColor = System.Drawing.Color.Transparent
        Me.banco.Controls.Add(Me.Label18)
        Me.banco.Controls.Add(Me.TXB_BANCO)
        Me.banco.Location = New System.Drawing.Point(4, 401)
        Me.banco.Name = "banco"
        Me.banco.Size = New System.Drawing.Size(638, 42)
        Me.banco.TabIndex = 218
        Me.banco.TabStop = False
        Me.banco.Visible = False
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(55, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(278, 23)
        Me.Label18.TabIndex = 218
        Me.Label18.Text = "Banco:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXB_BANCO
        '
        Me.TXB_BANCO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_BANCO.Location = New System.Drawing.Point(339, 14)
        Me.TXB_BANCO.Name = "TXB_BANCO"
        Me.TXB_BANCO.Size = New System.Drawing.Size(297, 22)
        Me.TXB_BANCO.TabIndex = 217
        '
        'credito
        '
        Me.credito.BackColor = System.Drawing.Color.Transparent
        Me.credito.Controls.Add(Me.txb_credito1)
        Me.credito.Controls.Add(Me.Label22)
        Me.credito.Controls.Add(Me.txb_credito)
        Me.credito.Location = New System.Drawing.Point(4, 355)
        Me.credito.Name = "credito"
        Me.credito.Size = New System.Drawing.Size(640, 46)
        Me.credito.TabIndex = 219
        Me.credito.TabStop = False
        Me.credito.Visible = False
        '
        'txb_credito1
        '
        Me.txb_credito1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_credito1.Location = New System.Drawing.Point(87, 14)
        Me.txb_credito1.Name = "txb_credito1"
        Me.txb_credito1.Size = New System.Drawing.Size(24, 26)
        Me.txb_credito1.TabIndex = 219
        Me.txb_credito1.Visible = False
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(162, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(171, 23)
        Me.Label22.TabIndex = 218
        Me.Label22.Text = "Cliente:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txb_credito
        '
        Me.txb_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_credito.Location = New System.Drawing.Point(339, 14)
        Me.txb_credito.Name = "txb_credito"
        Me.txb_credito.Size = New System.Drawing.Size(297, 26)
        Me.txb_credito.TabIndex = 217
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 401)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(638, 42)
        Me.GroupBox1.TabIndex = 218
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(55, 13)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(278, 23)
        Me.Label37.TabIndex = 218
        Me.Label37.Text = "Banco:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(339, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(297, 22)
        Me.TextBox1.TabIndex = 217
        '
        'txt_foliopago
        '
        Me.txt_foliopago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_foliopago.Location = New System.Drawing.Point(63, 386)
        Me.txt_foliopago.Name = "txt_foliopago"
        Me.txt_foliopago.Size = New System.Drawing.Size(40, 26)
        Me.txt_foliopago.TabIndex = 224
        Me.txt_foliopago.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightBlue
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.PictureBox8)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.Label35)
        Me.Panel6.Controls.Add(Me.PictureBox21)
        Me.Panel6.Controls.Add(Me.PictureBox22)
        Me.Panel6.Controls.Add(Me.PictureBox24)
        Me.Panel6.Controls.Add(Me.PictureBox23)
        Me.Panel6.Controls.Add(Me.Label34)
        Me.Panel6.Controls.Add(Me.PictureBox25)
        Me.Panel6.Controls.Add(Me.Label26)
        Me.Panel6.Controls.Add(Me.PictureBox13)
        Me.Panel6.Controls.Add(Me.Label33)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Location = New System.Drawing.Point(6, 255)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(634, 101)
        Me.Panel6.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label19.Location = New System.Drawing.Point(310, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(142, 30)
        Me.Label19.TabIndex = 505
        Me.Label19.Text = "FIN - Transferencia"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.White
        Me.PictureBox8.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox8.Location = New System.Drawing.Point(274, 64)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox8.TabIndex = 506
        Me.PictureBox8.TabStop = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label15.Location = New System.Drawing.Point(44, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 30)
        Me.Label15.TabIndex = 491
        Me.Label15.Text = "F5 - Efectivo"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label35.Location = New System.Drawing.Point(497, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(131, 30)
        Me.Label35.TabIndex = 500
        Me.Label35.Text = "F10 - Cierra Venta"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox21
        '
        Me.PictureBox21.BackColor = System.Drawing.Color.White
        Me.PictureBox21.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.exportar
        Me.PictureBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox21.Location = New System.Drawing.Point(461, 8)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox21.TabIndex = 504
        Me.PictureBox21.TabStop = False
        '
        'PictureBox22
        '
        Me.PictureBox22.BackColor = System.Drawing.Color.White
        Me.PictureBox22.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.buscar
        Me.PictureBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox22.Location = New System.Drawing.Point(8, 64)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox22.TabIndex = 503
        Me.PictureBox22.TabStop = False
        '
        'PictureBox24
        '
        Me.PictureBox24.BackColor = System.Drawing.Color.White
        Me.PictureBox24.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROGUARDAR
        Me.PictureBox24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox24.Location = New System.Drawing.Point(141, 64)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox24.TabIndex = 501
        Me.PictureBox24.TabStop = False
        '
        'PictureBox23
        '
        Me.PictureBox23.BackColor = System.Drawing.Color.White
        Me.PictureBox23.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.borrar
        Me.PictureBox23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox23.Location = New System.Drawing.Point(141, 8)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox23.TabIndex = 500
        Me.PictureBox23.TabStop = False
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label34.Location = New System.Drawing.Point(310, 8)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(142, 30)
        Me.Label34.TabIndex = 498
        Me.Label34.Text = "F9 - Tarjeta Bancaria"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox25
        '
        Me.PictureBox25.BackColor = System.Drawing.Color.White
        Me.PictureBox25.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
        Me.PictureBox25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox25.Location = New System.Drawing.Point(274, 8)
        Me.PictureBox25.Name = "PictureBox25"
        Me.PictureBox25.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox25.TabIndex = 502
        Me.PictureBox25.TabStop = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label26.Location = New System.Drawing.Point(177, 64)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(91, 30)
        Me.Label26.TabIndex = 496
        Me.Label26.Text = "F8 - Crédito"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox13
        '
        Me.PictureBox13.BackColor = System.Drawing.Color.White
        Me.PictureBox13.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROGUARDAR
        Me.PictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox13.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox13.TabIndex = 489
        Me.PictureBox13.TabStop = False
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label33.Location = New System.Drawing.Point(177, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(91, 30)
        Me.Label33.TabIndex = 495
        Me.Label33.Text = "F7 - Cheque"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(44, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 30)
        Me.Label14.TabIndex = 492
        Me.Label14.Text = "F6 - Vales"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TX_TOTALPAGO
        '
        Me.TX_TOTALPAGO.BackColor = System.Drawing.Color.MidnightBlue
        Me.TX_TOTALPAGO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TX_TOTALPAGO.ForeColor = System.Drawing.Color.White
        Me.TX_TOTALPAGO.Location = New System.Drawing.Point(475, 219)
        Me.TX_TOTALPAGO.Name = "TX_TOTALPAGO"
        Me.TX_TOTALPAGO.Size = New System.Drawing.Size(165, 30)
        Me.TX_TOTALPAGO.TabIndex = 6
        Me.TX_TOTALPAGO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightBlue
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(5, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(635, 24)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Su Pago"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lcambio
        '
        Me.lcambio.BackColor = System.Drawing.Color.MidnightBlue
        Me.lcambio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcambio.ForeColor = System.Drawing.Color.White
        Me.lcambio.Location = New System.Drawing.Point(113, 219)
        Me.lcambio.Name = "lcambio"
        Me.lcambio.Size = New System.Drawing.Size(271, 30)
        Me.lcambio.TabIndex = 5
        Me.lcambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label17.Location = New System.Drawing.Point(6, 219)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 30)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Diferencia:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(373, 219)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 30)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Suma:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FpFormasPago
        '
        Me.FpFormasPago.AccessibleDescription = ""
        Me.FpFormasPago.Font = New System.Drawing.Font("Calibri", 11.0!)
        Me.FpFormasPago.Location = New System.Drawing.Point(6, 40)
        Me.FpFormasPago.Name = "FpFormasPago"
        Me.FpFormasPago.Size = New System.Drawing.Size(634, 176)
        Me.FpFormasPago.TabIndex = 23957
        '
        'LFORPAG
        '
        Me.LFORPAG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LFORPAG.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFORPAG.Location = New System.Drawing.Point(837, 681)
        Me.LFORPAG.Name = "LFORPAG"
        Me.LFORPAG.Size = New System.Drawing.Size(152, 24)
        Me.LFORPAG.TabIndex = 490
        Me.LFORPAG.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(702, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(530, 24)
        Me.Label11.TabIndex = 212
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lkilos
        '
        Me.Lkilos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lkilos.BackColor = System.Drawing.Color.Transparent
        Me.Lkilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lkilos.ForeColor = System.Drawing.Color.Black
        Me.Lkilos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Lkilos.Location = New System.Drawing.Point(736, 707)
        Me.Lkilos.Name = "Lkilos"
        Me.Lkilos.Size = New System.Drawing.Size(135, 23)
        Me.Lkilos.TabIndex = 214
        Me.Lkilos.Text = "Kilos"
        Me.Lkilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Lkilos.Visible = False
        '
        'busqueda
        '
        Me.busqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.busqueda.BackColor = System.Drawing.Color.Transparent
        Me.busqueda.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.busqueda.ForeColor = System.Drawing.Color.Black
        Me.busqueda.Location = New System.Drawing.Point(170, 702)
        Me.busqueda.Name = "busqueda"
        Me.busqueda.Size = New System.Drawing.Size(97, 24)
        Me.busqueda.TabIndex = 215
        Me.busqueda.Text = "Buscar:"
        Me.busqueda.Visible = False
        '
        'txt_tipoventa
        '
        Me.txt_tipoventa.BackColor = System.Drawing.Color.MidnightBlue
        Me.txt_tipoventa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_tipoventa.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tipoventa.ForeColor = System.Drawing.Color.White
        Me.txt_tipoventa.Location = New System.Drawing.Point(1192, 12)
        Me.txt_tipoventa.MaxLength = 1
        Me.txt_tipoventa.Name = "txt_tipoventa"
        Me.txt_tipoventa.Size = New System.Drawing.Size(40, 19)
        Me.txt_tipoventa.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.txe)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_cveenc)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Location = New System.Drawing.Point(283, 193)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 260)
        Me.Panel1.TabIndex = 223
        Me.Panel1.Visible = False
        '
        'txe
        '
        Me.txe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txe.Location = New System.Drawing.Point(12, 63)
        Me.txe.Multiline = True
        Me.txe.Name = "txe"
        Me.txe.Size = New System.Drawing.Size(343, 110)
        Me.txe.TabIndex = 500
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(343, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Autorizar Cancelación de Productos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_cveenc
        '
        Me.txt_cveenc.Location = New System.Drawing.Point(80, 215)
        Me.txt_cveenc.Name = "txt_cveenc"
        Me.txt_cveenc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_cveenc.Size = New System.Drawing.Size(216, 20)
        Me.txt_cveenc.TabIndex = 501
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(44, 180)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(280, 32)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "Clave Supervisor:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(48, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(280, 32)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "PRODUCTO NO ENCONTRADO"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(702, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(484, 22)
        Me.Label6.TabIndex = 234
        Me.Label6.Text = "Caja:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label27.Location = New System.Drawing.Point(186, 596)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(542, 32)
        Me.Label27.TabIndex = 240
        Me.Label27.Text = "                                  TOTAL:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGray
        Me.Label1.Location = New System.Drawing.Point(258, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 21)
        Me.Label1.TabIndex = 471
        Me.Label1.Text = "Administración de Ventas"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Navy
        Me.Label28.Location = New System.Drawing.Point(258, 38)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(318, 26)
        Me.Label28.TabIndex = 470
        Me.Label28.Text = "Venta Público Menudeo y Mayoreo"
        '
        'LbF1
        '
        Me.LbF1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LbF1.BackColor = System.Drawing.Color.Transparent
        Me.LbF1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbF1.ForeColor = System.Drawing.Color.Navy
        Me.LbF1.Location = New System.Drawing.Point(62, 80)
        Me.LbF1.Name = "LbF1"
        Me.LbF1.Size = New System.Drawing.Size(168, 44)
        Me.LbF1.TabIndex = 481
        Me.LbF1.Text = "F1 - Buscar Cliente"
        Me.LbF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Navy
        Me.Label29.Location = New System.Drawing.Point(62, 131)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(168, 44)
        Me.Label29.TabIndex = 482
        Me.Label29.Text = "F2 - Cancelar Artículo"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Navy
        Me.Label30.Location = New System.Drawing.Point(62, 181)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(168, 44)
        Me.Label30.TabIndex = 483
        Me.Label30.Text = "F3 - Modificar Cantidad"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Navy
        Me.Label31.Location = New System.Drawing.Point(62, 231)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(168, 44)
        Me.Label31.TabIndex = 484
        Me.Label31.Text = "F4 - Terminar Venta"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Navy
        Me.Label32.Location = New System.Drawing.Point(62, 331)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(168, 44)
        Me.Label32.TabIndex = 485
        Me.Label32.Text = "F11 - Devolución"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.BtnCambiaCliente)
        Me.Panel3.Controls.Add(Me.BtnCambiaVenta)
        Me.Panel3.Controls.Add(Me.TxtControl)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.PictureBox12)
        Me.Panel3.Controls.Add(Me.pBoxF1)
        Me.Panel3.Controls.Add(Me.PictureBox5)
        Me.Panel3.Controls.Add(Me.PictureBox6)
        Me.Panel3.Controls.Add(Me.LbF1)
        Me.Panel3.Controls.Add(Me.PictureBox4)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Location = New System.Drawing.Point(995, 97)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(237, 638)
        Me.Panel3.TabIndex = 487
        '
        'BtnCambiaCliente
        '
        Me.BtnCambiaCliente.Enabled = False
        Me.BtnCambiaCliente.ForeColor = System.Drawing.Color.Navy
        Me.BtnCambiaCliente.Location = New System.Drawing.Point(12, 37)
        Me.BtnCambiaCliente.Name = "BtnCambiaCliente"
        Me.BtnCambiaCliente.Size = New System.Drawing.Size(109, 23)
        Me.BtnCambiaCliente.TabIndex = 507
        Me.BtnCambiaCliente.Text = "Cambiar Cliente"
        Me.BtnCambiaCliente.UseVisualStyleBackColor = True
        '
        'BtnCambiaVenta
        '
        Me.BtnCambiaVenta.Enabled = False
        Me.BtnCambiaVenta.ForeColor = System.Drawing.Color.Navy
        Me.BtnCambiaVenta.Location = New System.Drawing.Point(12, 8)
        Me.BtnCambiaVenta.Name = "BtnCambiaVenta"
        Me.BtnCambiaVenta.Size = New System.Drawing.Size(109, 23)
        Me.BtnCambiaVenta.TabIndex = 507
        Me.BtnCambiaVenta.Text = "Cambiar Tipo Venta"
        Me.BtnCambiaVenta.UseVisualStyleBackColor = True
        '
        'TxtControl
        '
        Me.TxtControl.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.TxtControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtControl.Location = New System.Drawing.Point(205, -43)
        Me.TxtControl.Name = "TxtControl"
        Me.TxtControl.Size = New System.Drawing.Size(29, 26)
        Me.TxtControl.TabIndex = 505
        Me.TxtControl.Text = "0"
        Me.TxtControl.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(62, 381)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 44)
        Me.Label8.TabIndex = 488
        Me.Label8.Text = "F12 - Facturación"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(62, 429)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 44)
        Me.Label7.TabIndex = 486
        Me.Label7.Text = "Salir"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477101_arrow_left_786052
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 431)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox1.TabIndex = 226
        Me.PictureBox1.TabStop = False
        '
        'PictureBox12
        '
        Me.PictureBox12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox12.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox12.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.pages_documents_copy_paste_icon_147449__1_
        Me.PictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox12.Location = New System.Drawing.Point(12, 381)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox12.TabIndex = 487
        Me.PictureBox12.TabStop = False
        '
        'pBoxF1
        '
        Me.pBoxF1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.pBoxF1.BackColor = System.Drawing.Color.Transparent
        Me.pBoxF1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477097_avatar_78580
        Me.pBoxF1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pBoxF1.Location = New System.Drawing.Point(12, 80)
        Me.pBoxF1.Name = "pBoxF1"
        Me.pBoxF1.Size = New System.Drawing.Size(44, 44)
        Me.pBoxF1.TabIndex = 480
        Me.pBoxF1.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477061_cart_78585__1_
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Location = New System.Drawing.Point(12, 231)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox5.TabIndex = 474
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477149_rotation_left_78589
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox6.Location = New System.Drawing.Point(12, 331)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox6.TabIndex = 475
        Me.PictureBox6.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477179_pen_78607
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(12, 181)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox4.TabIndex = 473
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477034_close2_78601
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(12, 131)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox3.TabIndex = 472
        Me.PictureBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(62, 279)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 44)
        Me.Label4.TabIndex = 509
        Me.Label4.Text = "F6 - Caja Virtual"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477156_box_78606__2_
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(12, 281)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(44, 44)
        Me.PictureBox2.TabIndex = 508
        Me.PictureBox2.TabStop = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Silver
        Me.Label16.Location = New System.Drawing.Point(3, 640)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(986, 47)
        Me.Label16.TabIndex = 489
        Me.Label16.Text = "GRACIAS POR SU PREFERENCIA"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelofe
        '
        Me.panelofe.BackColor = System.Drawing.Color.Red
        Me.panelofe.Controls.Add(Me.LbIDOferta)
        Me.panelofe.Controls.Add(Me.BTN_NUEVO)
        Me.panelofe.Controls.Add(Me.Label21)
        Me.panelofe.Controls.Add(Me.txt_panelofe)
        Me.panelofe.Controls.Add(Me.txtnotifica)
        Me.panelofe.Controls.Add(Me.Label20)
        Me.panelofe.Controls.Add(Me.Button2)
        Me.panelofe.Location = New System.Drawing.Point(177, 135)
        Me.panelofe.Name = "panelofe"
        Me.panelofe.Size = New System.Drawing.Size(450, 270)
        Me.panelofe.TabIndex = 502
        Me.panelofe.Visible = False
        '
        'LbIDOferta
        '
        Me.LbIDOferta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbIDOferta.ForeColor = System.Drawing.Color.White
        Me.LbIDOferta.Location = New System.Drawing.Point(400, 0)
        Me.LbIDOferta.Name = "LbIDOferta"
        Me.LbIDOferta.Size = New System.Drawing.Size(50, 23)
        Me.LbIDOferta.TabIndex = 529
        Me.LbIDOferta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LbIDOferta.Visible = False
        '
        'BTN_NUEVO
        '
        Me.BTN_NUEVO.BackColor = System.Drawing.Color.White
        Me.BTN_NUEVO.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
        Me.BTN_NUEVO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_NUEVO.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_NUEVO.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BTN_NUEVO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_NUEVO.Location = New System.Drawing.Point(355, 202)
        Me.BTN_NUEVO.Name = "BTN_NUEVO"
        Me.BTN_NUEVO.Size = New System.Drawing.Size(47, 41)
        Me.BTN_NUEVO.TabIndex = 528
        Me.BTN_NUEVO.Tag = "Nuevo"
        Me.BTN_NUEVO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_NUEVO.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(39, 177)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(363, 23)
        Me.Label21.TabIndex = 503
        Me.Label21.Text = "Supervisor Notificado"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_panelofe
        '
        Me.txt_panelofe.Location = New System.Drawing.Point(39, 223)
        Me.txt_panelofe.Name = "txt_panelofe"
        Me.txt_panelofe.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_panelofe.Size = New System.Drawing.Size(294, 20)
        Me.txt_panelofe.TabIndex = 502
        Me.txt_panelofe.UseSystemPasswordChar = True
        '
        'txtnotifica
        '
        Me.txtnotifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnotifica.Location = New System.Drawing.Point(39, 63)
        Me.txtnotifica.Multiline = True
        Me.txtnotifica.Name = "txtnotifica"
        Me.txtnotifica.Size = New System.Drawing.Size(363, 112)
        Me.txtnotifica.TabIndex = 500
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(39, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(363, 43)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Notificación de Oferta Expirada"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(240, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Continuar"
        '
        'Paneltiempo
        '
        Me.Paneltiempo.BackColor = System.Drawing.Color.MediumBlue
        Me.Paneltiempo.Controls.Add(Me.txt_ctel4)
        Me.Paneltiempo.Controls.Add(Me.txt_ctel3)
        Me.Paneltiempo.Controls.Add(Me.txt_ctel2)
        Me.Paneltiempo.Controls.Add(Me.txt_ctel1)
        Me.Paneltiempo.Controls.Add(Me.txt_tel4)
        Me.Paneltiempo.Controls.Add(Me.txt_tel3)
        Me.Paneltiempo.Controls.Add(Me.txt_tel2)
        Me.Paneltiempo.Controls.Add(Me.txt_tel1)
        Me.Paneltiempo.Controls.Add(Me.Button3)
        Me.Paneltiempo.Controls.Add(Me.Label23)
        Me.Paneltiempo.Controls.Add(Me.Label36)
        Me.Paneltiempo.Controls.Add(Me.Button4)
        Me.Paneltiempo.Location = New System.Drawing.Point(153, 153)
        Me.Paneltiempo.Name = "Paneltiempo"
        Me.Paneltiempo.Size = New System.Drawing.Size(450, 231)
        Me.Paneltiempo.TabIndex = 503
        Me.Paneltiempo.Visible = False
        '
        'txt_ctel4
        '
        Me.txt_ctel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ctel4.Location = New System.Drawing.Point(298, 144)
        Me.txt_ctel4.Name = "txt_ctel4"
        Me.txt_ctel4.Size = New System.Drawing.Size(39, 31)
        Me.txt_ctel4.TabIndex = 536
        Me.txt_ctel4.Visible = False
        '
        'txt_ctel3
        '
        Me.txt_ctel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ctel3.Location = New System.Drawing.Point(242, 144)
        Me.txt_ctel3.Name = "txt_ctel3"
        Me.txt_ctel3.Size = New System.Drawing.Size(46, 31)
        Me.txt_ctel3.TabIndex = 535
        Me.txt_ctel3.Visible = False
        '
        'txt_ctel2
        '
        Me.txt_ctel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ctel2.Location = New System.Drawing.Point(189, 144)
        Me.txt_ctel2.Name = "txt_ctel2"
        Me.txt_ctel2.Size = New System.Drawing.Size(47, 31)
        Me.txt_ctel2.TabIndex = 534
        Me.txt_ctel2.Visible = False
        '
        'txt_ctel1
        '
        Me.txt_ctel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ctel1.Location = New System.Drawing.Point(130, 144)
        Me.txt_ctel1.Name = "txt_ctel1"
        Me.txt_ctel1.Size = New System.Drawing.Size(207, 31)
        Me.txt_ctel1.TabIndex = 533
        '
        'txt_tel4
        '
        Me.txt_tel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tel4.Location = New System.Drawing.Point(298, 61)
        Me.txt_tel4.Name = "txt_tel4"
        Me.txt_tel4.Size = New System.Drawing.Size(39, 31)
        Me.txt_tel4.TabIndex = 532
        Me.txt_tel4.Visible = False
        '
        'txt_tel3
        '
        Me.txt_tel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tel3.Location = New System.Drawing.Point(242, 61)
        Me.txt_tel3.Name = "txt_tel3"
        Me.txt_tel3.Size = New System.Drawing.Size(46, 31)
        Me.txt_tel3.TabIndex = 531
        Me.txt_tel3.Visible = False
        '
        'txt_tel2
        '
        Me.txt_tel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tel2.Location = New System.Drawing.Point(189, 61)
        Me.txt_tel2.Name = "txt_tel2"
        Me.txt_tel2.Size = New System.Drawing.Size(47, 31)
        Me.txt_tel2.TabIndex = 530
        Me.txt_tel2.Visible = False
        '
        'txt_tel1
        '
        Me.txt_tel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tel1.Location = New System.Drawing.Point(130, 61)
        Me.txt_tel1.Name = "txt_tel1"
        Me.txt_tel1.Size = New System.Drawing.Size(210, 31)
        Me.txt_tel1.TabIndex = 529
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(375, 172)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(47, 41)
        Me.Button3.TabIndex = 528
        Me.Button3.Tag = "Nuevo"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(102, 109)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(280, 32)
        Me.Label23.TabIndex = 503
        Me.Label23.Text = "Confirmación"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(75, 15)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(344, 43)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Número de Teléfono"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(240, 272)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Continuar"
        '
        'LbTotal
        '
        Me.LbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LbTotal.BackColor = System.Drawing.Color.Transparent
        Me.LbTotal.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LbTotal.Location = New System.Drawing.Point(734, 596)
        Me.LbTotal.Name = "LbTotal"
        Me.LbTotal.Size = New System.Drawing.Size(255, 32)
        Me.LbTotal.TabIndex = 504
        Me.LbTotal.Text = "$0.00"
        Me.LbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(344, 160)
        Me.ListBox1.TabIndex = 505
        '
        'PanelCancelaciones
        '
        Me.PanelCancelaciones.BackColor = System.Drawing.Color.AliceBlue
        Me.PanelCancelaciones.Controls.Add(Me.ListBox1)
        Me.PanelCancelaciones.Location = New System.Drawing.Point(657, 130)
        Me.PanelCancelaciones.Name = "PanelCancelaciones"
        Me.PanelCancelaciones.Size = New System.Drawing.Size(370, 176)
        Me.PanelCancelaciones.TabIndex = 506
        Me.PanelCancelaciones.Visible = False
        '
        'PanelSeleccionTarjetas
        '
        Me.PanelSeleccionTarjetas.BackColor = System.Drawing.Color.AliceBlue
        Me.PanelSeleccionTarjetas.Controls.Add(Me.lbFila)
        Me.PanelSeleccionTarjetas.Controls.Add(Me.BtnCierraPanel)
        Me.PanelSeleccionTarjetas.Controls.Add(Me.BtnRegistraTarjeta)
        Me.PanelSeleccionTarjetas.Controls.Add(Me.rbTDebito)
        Me.PanelSeleccionTarjetas.Controls.Add(Me.rbTCredito)
        Me.PanelSeleccionTarjetas.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!)
        Me.PanelSeleccionTarjetas.ForeColor = System.Drawing.Color.Navy
        Me.PanelSeleccionTarjetas.Location = New System.Drawing.Point(12, 411)
        Me.PanelSeleccionTarjetas.Name = "PanelSeleccionTarjetas"
        Me.PanelSeleccionTarjetas.Size = New System.Drawing.Size(196, 70)
        Me.PanelSeleccionTarjetas.TabIndex = 507
        Me.PanelSeleccionTarjetas.TabStop = False
        Me.PanelSeleccionTarjetas.Text = "Seleccione Tipo de Tarjeta"
        Me.PanelSeleccionTarjetas.Visible = False
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
        Me.rbTDebito.Tag = "Débito"
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
        Me.rbTCredito.Tag = "Crédito"
        Me.rbTCredito.Text = "Tarjeta de Crédito"
        Me.rbTCredito.UseVisualStyleBackColor = True
        '
        'LbClienteTicket
        '
        Me.LbClienteTicket.BackColor = System.Drawing.Color.Transparent
        Me.LbClienteTicket.Font = New System.Drawing.Font("Franklin Gothic Medium", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbClienteTicket.ForeColor = System.Drawing.Color.Navy
        Me.LbClienteTicket.Location = New System.Drawing.Point(602, 68)
        Me.LbClienteTicket.Name = "LbClienteTicket"
        Me.LbClienteTicket.Size = New System.Drawing.Size(630, 26)
        Me.LbClienteTicket.TabIndex = 508
        Me.LbClienteTicket.Text = "Cliente: Público en General"
        Me.LbClienteTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TimerReloj
        '
        Me.TimerReloj.Enabled = True
        Me.TimerReloj.Interval = 1000
        '
        'FpArticulos
        '
        Me.FpArticulos.AccessibleDescription = "FpOfertas, Sheet1, Row 0, Column 0"
        Me.FpArticulos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FpArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.FpArticulos.Location = New System.Drawing.Point(3, 97)
        Me.FpArticulos.Name = "FpArticulos"
        Me.FpArticulos.Size = New System.Drawing.Size(986, 490)
        Me.FpArticulos.TabIndex = 23957
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LogoDuarsaNew
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.Location = New System.Drawing.Point(3, 12)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(249, 52)
        Me.PictureBox7.TabIndex = 489
        Me.PictureBox7.TabStop = False
        '
        'FrVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1235, 735)
        Me.Controls.Add(Me.PanelSeleccionTarjetas)
        Me.Controls.Add(Me.LbClienteTicket)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.panelofe)
        Me.Controls.Add(Me.LbTotal)
        Me.Controls.Add(Me.LFORPAG)
        Me.Controls.Add(Me.tx_cantidad)
        Me.Controls.Add(Me.Paneltiempo)
        Me.Controls.Add(Me.Lkilos)
        Me.Controls.Add(Me.l_cancelacion)
        Me.Controls.Add(Me.TX_UPC)
        Me.Controls.Add(Me.l_cantidad)
        Me.Controls.Add(Me.busqueda)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_tipoventa)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.tb_total)
        Me.Controls.Add(Me.grformapago)
        Me.Controls.Add(Me.PanelCancelaciones)
        Me.Controls.Add(Me.FpArticulos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PVENTA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grformapago.ResumeLayout(False)
        Me.grformapago.PerformLayout()
        Me.banco.ResumeLayout(False)
        Me.banco.PerformLayout()
        Me.credito.ResumeLayout(False)
        Me.credito.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpFormasPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBoxF1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelofe.ResumeLayout(False)
        Me.panelofe.PerformLayout()
        Me.Paneltiempo.ResumeLayout(False)
        Me.Paneltiempo.PerformLayout()
        Me.PanelCancelaciones.ResumeLayout(False)
        Me.PanelSeleccionTarjetas.ResumeLayout(False)
        Me.PanelSeleccionTarjetas.PerformLayout()
        CType(Me.FpArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region



    Dim Corriendo As Boolean
    Public TipoTarj As String
    Private Sub FrVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label6.Text = "Caja: " & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & " | Cajera: " & Globales.NombreEmpleado & " | Tipo Venta: "

        datostel = False
        estiempoaire = False
        claveprod = ""
        segundoticket = False
        sipuntos = False
        txt_tipoventa.MaxLength = 1

        '  configuraSpread()
        masClicks = 0
        iren = 0
        codigotp = ""

        TIEMPOCOMIS = 0
        formaspago = False
        PERMISOVENDER = True

        virtual = 0

        autorizame = False

        Corriendo = True
        FormateaSpread()
        limpiaSpread()
        Corriendo = False
        Me.txt_tipoventa.Focus()
        txt_tipoventa.SelectionStart = 0
        txt_tipoventa.SelectionLength = txt_tipoventa.Text.Length



    End Sub

    Function BuscaVenta(ByVal Optional CambiandoVenta As Boolean = False)
        Dim DSC As New DataSet
        Dim SQL As String
        Dim i As Integer

        SQL = "select t.*,Cli_Nombre from tmpauxvta2 t join ecclientes on t.ClienteID=Cli_Clave where t.usuario ='" & Globales.caja & "' order by t.renglon asc"

        Base.daQuery(SQL, sCadenaConexionSQL, DSC, "Ticket")
        If DSC.Tables("Ticket").Rows.Count > 0 Then
            Dim Continuar As MsgBoxResult
            If Not CambiandoVenta Then
                Continuar = MsgBox("Hay una cuenta pendiente, ¿desea continuar con esa venta?", vbYesNo)
            Else
                Continuar = MsgBoxResult.Yes
            End If

            If Continuar = MsgBoxResult.Yes Then
                txt_tipoventa.Text = DSC.Tables("Ticket").Rows(0)("tipo")
                TIPOVENTA = DSC.Tables("Ticket").Rows(0)("tipo")
                TxtControl.Text = DSC.Tables("Ticket").Rows(0)("ClienteID")
                LbClienteTicket.Text = "Cliente: " & DSC.Tables("Ticket").Rows(0)("Cli_Nombre").trim
                txt_tipoventa.Enabled = False
                For i = 0 To DSC.Tables("Ticket").Rows.Count - 1
                    TX_UPC.Text = DSC.Tables("Ticket").Rows(i)("articulo").ToString.Trim
                    Dim fueConF6 As Integer = DSC.Tables("ticket").Rows(i).Field(Of Integer?)("FueConF6").GetValueOrDefault(0)
                    VentaCajaVirtual = (fueConF6 = 1)
                    ToggleCajaVirtual()
                    ProcAgregaArticulo(True, DSC.Tables("Ticket").Rows(i)("Cantidad"), DSC.Tables("Ticket").Rows(i)("FueConF1"), DSC.Tables("Ticket").Rows(i)("FueConF2"), DSC.Tables("Ticket").Rows(i)("FueConF3"), DSC.Tables("Ticket").Rows(i)("TraeVale"), fueConF6)
                Next
                Me.TX_UPC.Focus()
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        DSC.Tables.Remove("Ticket")
    End Function
    Private Sub ToggleCajaVirtual()
        If VentaCajaVirtual Then
            TX_UPC.BackColor = Color.Yellow
        Else
            TX_UPC.BackColor = Color.White
        End If
    End Sub
    Public Function GuardaFormaDePagoConHandler() As Boolean
        Dim iRen As Integer = 0
        Dim sSql As String = ""
        Dim dsc As New DataSet
        Dim iID As Integer = xven ' Asumiendo que xven es accesible globalmente
        Dim xfecha As String
        Dim xusuario As Double
        Dim valorRenglon As Double
        Dim signo As Integer
        Dim HuboCredito As Boolean = False

        ' PASO 1: LECTURA DE DATOS
        ' Aquí Sí usamos tu nueva clase Base.daQuery, porque solo es lectura
        ' y no necesita estar dentro de la transacción todavía.
        sSql = "Select ven_fecha, ven_usuario from ecventa where ven_id=" & iID
        Try
            Base.daQuery(sSql, sCadenaConexionSQL, dsc, "venta") ' <--- Fíjate que ya no pasamos conexión
            If dsc.Tables("venta").Rows.Count > 0 Then
                xfecha = Format(dsc.Tables("venta").Rows(0)("ven_fecha"), "yyyyMMdd HH:mm.fff")
                xusuario = CDbl(dsc.Tables("venta").Rows(0)("ven_usuario"))
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error al leer datos de la venta: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        ' PASO 2: transacción BLINDADA
        ' Creamos una conexión LOCAL solo para este proceso Crítico.
        Using xConLocal As New SqlConnection(Globales.sCadenaConexionSQL)
            Try
                xConLocal.Open()

                ' Iniciamos la transacción sobre esta conexión local
                Using transaction As SqlTransaction = xConLocal.BeginTransaction("GuardarPagos")

                    ' Creamos el comando que ejecturá todas las órdenes dentro de la transacción
                    Using cmd As SqlCommand = xConLocal.CreateCommand()
                        cmd.Transaction = transaction
                        cmd.CommandTimeout = 120

                        With Me.FpFormasPago.ActiveSheet
                            For iRen = 0 To .RowCount - 1

                                ' Determinar Signo
                                If .Cells(iRen, 0).Text = "Comision Vales" Or .Cells(iRen, 0).Text = "Comis Tar" Then
                                    signo = -1
                                Else
                                    signo = 1
                                End If

                                valorRenglon = .Cells(iRen, 1).Value

                                ' A. Insertar en ECFORMAPAGO
                                sSql = "insert into ecformapago (referencia, tipo_pago, pago, banco) values (" &
                                   iID & ",'" & .Cells(iRen, 0).Text & "'," & (valorRenglon * signo) & ",'" & Strings.Left(.Cells(iRen, 2).Text, 50) & " ')"
                                cmd.CommandText = sSql
                                cmd.ExecuteNonQuery() ' Ejecutamos directo con el comando local

                                ' B. Lógica Específica por Tipo de Pago
                                Dim TipoPago As String = LTrim(RTrim(.Cells(iRen, 0).Text))

                                If TipoPago = "Tarjeta" Then
                                    sSql = "insert into ectarjetas (tar_empresa,TAR_VENTAID,CAJA,FECHA,DESCRIPCION,CANTIDAD,COMISION,REFERENCIA,FOLIOCONC,TOTALCONC,ESTATUS,corte,TipoTarjeta) " &
                                       "values (1," & iID & ",'00" & xusuario & "0','" & xfecha & "','Pago del Ticket " & iID & "'," &
                                       (valorRenglon * signo) & ",0,'" & .Cells(iRen, 2).Text & "',0,0,0,0,'" & TipoTarj & "')"
                                    cmd.CommandText = sSql
                                    cmd.ExecuteNonQuery()

                                ElseIf TipoPago = "Comis Tar" Then
                                    sSql = "update ectarjetas set comision=" & valorRenglon & " where tar_ventaid=" & iID
                                    cmd.CommandText = sSql
                                    cmd.ExecuteNonQuery()

                                ElseIf TipoPago = "Transfer" Then
                                    sSql = "insert into ectransfer values (1," & iID & ",'00" & xusuario & "0','" & xfecha & "','Pago del Ticket " & iID & "'," &
                                       (valorRenglon * signo) & ",0,'" & .Cells(iRen, 2).Text & "',0,0,0,0)"
                                    cmd.CommandText = sSql
                                    cmd.ExecuteNonQuery()

                                ElseIf TipoPago = "Credito" Then
                                    ' Insertamos valorRenglon (corrección de Lógica de acumulado)
                                    sSql = "Insert into eccuentasxcob values ('" & xfecha & "','" & txb_credito1.Text & "',1," & valorRenglon & "," &
                                       valorRenglon & ",0,1," & iID & ")"
                                    cmd.CommandText = sSql
                                    cmd.ExecuteNonQuery()
                                    HuboCredito = True
                                End If
                            Next iRen
                        End With

                        ' C. Actualizar Saldo Cliente (Optimizado: solo el cliente actual)
                        If HuboCredito Then
                            sSql = "update ecventa.dbo.ECDETCLIENTEEMP set DCLI_SALDO=Saldo from ecventa.dbo.eccuentasxcob e join (" &
                               "Select e.DCLI_CLAVE,COALESCE(SUM(cxc_saldo) ,0) Saldo from ecventa.dbo.ECDETCLIENTEEMP e join ecventa.dbo.eccuentasxcob x on DCLI_CLAVE=cxc_cliente " &
                               "group by e.DCLI_CLAVE) a on a.DCLI_CLAVE=e.cxc_cliente where ecventa.dbo.ECDETCLIENTEEMP.DCLI_CLAVE=" & txb_credito1.Text
                            cmd.CommandText = sSql
                            cmd.ExecuteNonQuery()
                        End If

                        ' 3. CONFIRMAR TODO
                        transaction.Commit()
                        Return True

                    End Using ' Fin del cmd
                End Using ' Fin de la Transaction (Rollback automático si falla antes del Commit)

            Catch ex As Exception
                MsgBox("Error Crítico al guardar pagos: " & ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try

        End Using ' Fin de xConLocal (Cierra la conexión automáticamente)

    End Function
    Public Function GuardaFormaDePagoConHandlerOriginal()
        Dim iRen As Integer = 0
        Dim sSql As String = ""
        Dim dsc As New DataSet
        Dim iID As Integer
        Dim DATO As String
        Dim xfecha As String
        Dim xusuario As Double
        Dim totalcredito As Double
        Dim signo As Integer


        With Me.FpFormasPago.ActiveSheet
            DATO = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)

            'sSql = "select max(ven_id) as maximo from ecventa  WHERE ven_USUARIO='" & DATO & "'"
            'Base.daQuery(sSql, sCadenaConexionSQL, dsc, "maximo")
            iID = xven

            sSql = "Select * from ecventa where ven_id=" & iID
            Try
                Base.daQuery(sSql, sCadenaConexionSQL, dsc, "venta")
                If dsc.Tables("venta").Rows.Count > 0 Then
                    xfecha = Format(dsc.Tables("venta").Rows(0)("ven_fecha"), "yyyyMMdd HH:mm.fff")
                    xusuario = CDbl(dsc.Tables("venta").Rows(0)("ven_usuario"))
                Else
                    Return False
                End If
                dsc.Tables.Remove("venta")
            Catch ex As Exception
                Return False
            End Try

            totalcredito = 0
            For iRen = 0 To .RowCount - 1
                If .Cells(iRen, 0).Text = "Comision Vales" Or .Cells(iRen, 0).Text = "Comis Tar" Then
                    signo = -1
                Else
                    signo = 1
                End If

                sSql = "insert into ecformapago (referencia, tipo_pago, pago, banco)"
                sSql &= "values (" & iID & ",'" & .Cells(iRen, 0).Text & "'," & .Cells(iRen, 1).Value * signo & ",'" & Strings.Left(.Cells(iRen, 2).Text, 50) & "')"
                Try
                    Base.Ejecuta(sSql, sCadenaConexionSQL)
                Catch ex As Exception
                    Return False
                End Try



                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Credito" Then
                    totalcredito = totalcredito + .Cells(iRen, 1).Value

                End If


                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Tarjeta" Then
                    sSql = "insert into ectarjetas (tar_empresa,TAR_VENTAID,CAJA,FECHA,DESCRIPCION,CANTIDAD,COMISION,REFERENCIA,FOLIOCONC,TOTALCONC,ESTATUS,corte,TipoTarjeta) values (1," & iID & ",'00" &
                    xusuario & "0','" & xfecha & "','Pago del Ticket " &
                   iID & "'," & .Cells(iRen, 1).Value * signo & ",0,'" &
                    .Cells(iRen, 2).Text & "',0,0,0,0,'" & TipoTarj & "')"
                    Try
                        Base.Ejecuta(sSql, sCadenaConexionSQL)
                    Catch ex As Exception
                        Return False
                    End Try

                End If
                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Comis Tar" Then
                    sSql = "update ectarjetas set comision=" & .Cells(iRen, 1).Value & " where tar_ventaid=" & iID
                    Try
                        Base.Ejecuta(sSql, sCadenaConexionSQL)
                    Catch ex As Exception
                        Return False
                    End Try

                End If

                '----------------------------------------------------
                '----------------- PAGO CON TRANSFERENCIA BANCARIA

                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Transfer" Then
                    sSql = "insert into ectransfer values (1," & iID & ",'00" &
                    xusuario & "0','" & xfecha & "','Pago del Ticket " &
                   iID & "'," & .Cells(iRen, 1).Value * signo & ",0,'" &
                    .Cells(iRen, 2).Text & "',0,0,0,0)"
                    Try
                        Base.Ejecuta(sSql, sCadenaConexionSQL)
                    Catch ex As Exception
                        Return False
                    End Try
                End If


                '----------------------------------------------------
                '-----------------
                If .Cells(iRen, 0).Text = "Credito" Then
                    'sSql = "Insert into eccuentasxcob values ('" & xfecha & "','" & txb_credito1.Text & "',1," & CDbl(dsc.Tables("venta").Rows(0)("ven_total")) & "," & _
                    'CDbl(dsc.Tables("venta").Rows(0)("ven_total")) & ",0,1," & CDbl(dsc.Tables("venta").Rows(0)("ven_id")) & ")"
                    sSql = "Insert into eccuentasxcob values ('" & xfecha & "','" & txb_credito1.Text & "',1," & (totalcredito) & "," &
                    totalcredito & ",0,1," & iID & ")"
                    Try
                        Base.Ejecuta(sSql, sCadenaConexionSQL)
                    Catch ex As Exception
                        Return False
                    End Try
                    Try
                        sSql = "update ecventa.dbo.ECDETCLIENTEEMP set DCLI_SALDO=Saldo from ecventa.dbo.eccuentasxcob e join (" &
                                "Select e.DCLI_CLAVE,COALESCE(SUM(cxc_saldo) ,0) Saldo  from ecventa.dbo.ECDETCLIENTEEMP e join ecventa.dbo.eccuentasxcob x on DCLI_CLAVE=cxc_cliente " &
                                "group by e.DCLI_CLAVE) a on a.DCLI_CLAVE=e.cxc_cliente where ecventa.dbo.ECDETCLIENTEEMP.DCLI_CLAVE=e.cxc_cliente"
                        Base.Ejecuta(sSql, sCadenaConexionSQL)
                    Catch ex As Exception
                        Return False
                    End Try
                End If
            Next iRen
            'dsc.Tables.Remove("venta")
            '   dsc.Tables.Remove("maximo")
        End With
        Return True
    End Function
    Public Sub agregaArticulo(ByVal Item As ArticuloVenta)

        Dim EsRepetido As Boolean = False
        Dim RenglonObjetivo As Integer = 0
        Dim CantidadFinal As Decimal = 0
        Dim SQL As String = "" ' Variable para tus consultas

        ' Preparamos las banderas visuales (0 o 1) para SQL
        Dim valF1 As Integer = IIf(Item.EsBusquedaF1, 1, 0)
        Dim valF2 As Integer = IIf(Item.EsCancelacion, 1, 0)
        Dim valF3 As Integer = IIf(Item.EsCambioCantidad, 1, 0)
        Dim valF6 As Integer = IIf(Item.EsCajaVirtual, 1, 0)

        ' Nota: Asumo que TxtControl.Text tiene el ID del Cliente. 
        ' Si Item.ClienteID ya lo trae, úsalo, si no, usa el textbox.
        Dim ClienteID As String = Item.ClienteID.ToString()

        With FpArticulos.ActiveSheet
            Dim iRowActual As Integer = .RowCount - 1

            ' =========================================================================
            ' 1. VALIDACIÓN DE REPETIDO
            ' =========================================================================
            If .RowCount > 1 Then
                Dim UPCAnterior As String = .Cells(iRowActual - 1, ColVenta.ColUPCInv).Text.Trim
                Dim CantidadAnterior As Decimal = CDec(.Cells(iRowActual - 1, ColVenta.ColCantidad).Value)

                If UPCAnterior = Item.UPC AndAlso
                Not Item.EsCancelacion AndAlso
                CantidadAnterior > 0 AndAlso
                Not Item.EsKilos AndAlso
                Not Item.CargandoPendiente Then

                    EsRepetido = True
                End If
            End If

            ' =========================================================================
            ' 2. operación EN GRID Y EN SQL (Aquí estaba el fallo)
            ' =========================================================================

            If EsRepetido Then
                ' >>> FUSIONAR (UPDATE SQL) <<<
                RenglonObjetivo = iRowActual - 1

                Dim CantidadAnt As Decimal = CDec(.Cells(RenglonObjetivo, ColVenta.ColCantidad).Value)
                CantidadFinal = CantidadAnt + Item.Cantidad

                ' 2.1 Actualizar Grid
                .Cells(RenglonObjetivo, ColVenta.ColCantidad).Value = CantidadFinal
                .RemoveRows(iRowActual, 1) ' Borrar el vacío

                ' 2.2 Actualizar SQL (RESTAURADO)
                ' Actualizamos la cantidad en el renglón correspondiente
                SQL = "UPDATE tmpauxvta2 SET cantidad=" & CantidadFinal &
                  ", FueConF1=" & valF1 & ", FueConF2=" & valF2 &
                  ", FueConF3=" & valF3 & ", FueConF6=" & valF6 &
                  " WHERE renglon=" & RenglonObjetivo & " AND usuario='" & Globales.caja & "'"
                Base.Ejecuta(SQL, sCadenaConexionSQL)

                iRowActual = RenglonObjetivo

            Else
                ' >>> NUEVO renglón (INSERT SQL) <<<
                RenglonObjetivo = iRowActual
                CantidadFinal = Item.Cantidad

                ' 2.1 Llenar Grid
                .Cells(iRowActual, ColVenta.ColUPCInv).Value = Item.UPC
                .Cells(iRowActual, ColVenta.ColArtClave).Value = Item.Clave
                .Cells(iRowActual, ColVenta.ColDescripcion).Value = Item.Descripcion
                .Cells(iRowActual, ColVenta.ColNomLargo).Value = Item.NombreLargo
                .Cells(iRowActual, ColVenta.ColFamilia).Value = Item.Familia
                .Cells(iRowActual, ColVenta.ColCantidad).Value = CantidadFinal
                .Cells(iRowActual, ColVenta.ColPrecio1).Value = Item.Precio1
                .Cells(iRowActual, ColVenta.ColFIVA).Value = Item.IVA
                .Cells(iRowActual, ColVenta.ColFIEPS).Value = Item.IEPS
                .Cells(iRowActual, ColVenta.ColCostoCap).Value = Item.CostoCap
                .Cells(iRowActual, ColVenta.ColTipoOferta).Value = Item.TipoOferta
                .Cells(iRowActual, ColVenta.ColF1).Value = valF1
                .Cells(iRowActual, ColVenta.ColF2).Value = valF2
                .Cells(iRowActual, ColVenta.ColF3).Value = valF3
                .Cells(iRowActual, ColVenta.ColF6).Value = valF6
                .Cells(iRowActual, ColVenta.ColVale).Value = IIf(Item.TraeVale, "*", "")

                ' Colores
                If Item.EsCancelacion Then
                    .Rows(iRowActual).ForeColor = Color.Red
                ElseIf Item.TipoOferta > 0 Then
                    .Rows(iRowActual).ForeColor = Color.Blue
                Else
                    .Rows(iRowActual).ForeColor = Color.Black
                End If
                ' Precio Inicial
                Dim PrecioInicial As Decimal = Item.Precio1
                Select Case Item.TipoVenta
                    Case 2 : PrecioInicial = Item.Precio2
                    Case 3 : PrecioInicial = Item.Precio3
                End Select
                .Cells(iRowActual, ColVenta.ColPrecio).Value = PrecioInicial
                .Cells(iRowActual, ColVenta.ColTotal).Value = CantidadFinal * PrecioInicial

                ' 2.2 Insertar SQL (RESTAURADO)
                ' Solo insertamos si NO estamos cargando un ticket pendiente (porque esos ya existen)
                If Not Item.CargandoPendiente Then
                    SQL = "INSERT INTO tmpauxvta2 (renglon, usuario, articulo, cantidad, tipo, " &
                      "FueConF1, FueConF2, FueConF3, ClienteID, ArtClave, TraeVale, Factor, FueConF6) " &
                      "VALUES (" &
                      RenglonObjetivo & ", '" & Globales.caja & "', '" & Item.UPC & "', " & CantidadFinal & ", " & Item.TipoVenta & ", " &
                      valF1 & ", " & valF2 & ", " & valF3 & ", " & ClienteID & ", '" & Item.Clave & "', " &
                      IIf(Item.TraeVale, 1, 0) & ", " & Item.Factor & ", " & valF6 & ")"

                    Base.Ejecuta(SQL, sCadenaConexionSQL)
                End If

            End If

            claveArt = Item.UPC

            ' =========================================================================
            ' 3. LLAMADA A CONTROL PRECIOS (Solo para ajustar $$, la cantidad ya está guardada)
            ' =========================================================================
            ' IMPORTANTE: Como ya guardamos la cantidad arriba (INSERT o UPDATE), 
            ' ControlPrecios NO necesita hacer INSERT. 
            ' Pero ojo: ControlPrecios Step 2 hace un UPDATE que suma la diferencia.
            ' Si le mandamos SCANT=CantidadFinal y SCANTANT=0, va a sumar OTRA VEZ.

            ' TRUCO: Le mandamos SCANT = SCANTANT para que Diferencia sea 0.
            ' ASí ControlPrecios SOLO ejecuta la Lógica de precios (Paso 3, 4 y 5) y no toca la cantidad en BD.

            CONTROLPRECIOS(UPCUPC:=Item.UPC,
                       DPRECIO1:=Item.Precio1,
                       DPRECIO2:=Item.Precio2,
                       DPRECIO3:=Item.Precio3,
                       TOPE:=Item.TopeMayoreo,
                       SCANT:=CantidadFinal,
                       SCANTANT:=CantidadFinal, ' <-- CAMBIO CLAVE: Igualamos para que no sume doble en BD
                       RENGLON:=iRowActual,
                       ArtClave:=Item.Clave,
                       CargandoPendiente:=Item.CargandoPendiente,
                       CantidadDisponible:=Item.CantidadDisponible,
                       PrecioOferta1:=Item.PrecioOferta1,
                       PrecioOferta2:=Item.PrecioOferta2,
                       PrecioOferta3:=Item.PrecioOferta3,
                       CantidadCobradas:=Item.CantidadCobradas,
                       TipoOferta:=Item.TipoOferta)

            ' Scroll
            .ActiveRowIndex = iRowActual
            FpArticulos.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Bottom, FarPoint.Win.Spread.HorizontalPosition.Left)

        End With

        sumaSpread()

    End Sub
    'Public Sub agregaArticuloOrig(ByVal Item As ArticuloVenta)
    '    'ByVal UPCUPC As String, ByVal ArtClave As String, ByVal UPCDescripcion As String, ByVal ArtNomLargo As String, ByVal Familia As String, ByVal CostoCap As Double, ByVal Precio1 As Double, ByVal Precio2 As Double, ByVal Precio3 As Double, ByVal iRen As Integer, ByVal tOPE As Double, ByVal tipo As Integer, ByVal cant As Double, ByRef iva As Double, ByRef ieps As Double, ByVal CargandoPendiente As Boolean, ByVal TraeVale As Boolean, ByVal FueConF1 As Boolean, ByVal cancelacion As Boolean, ByVal FueConF3 As Boolean, ByVal CantidadDisponible As Integer, ByVal PrecioOferta1 As Double, ByVal PrecioOferta2 As Double, ByVal PrecioOferta3 As Double, ByVal CantidadCobradas As Integer, ByVal TipoOferta As Integer, ByVal FactorCapturado As Double, ByVal FueConF6 As Boolean)
    '    Dim SQL As String
    '    Dim DSC As New DataSet
    '    Dim cantacuma As Double = 0

    '    ' Convertimos booleanos a enteros para SQL (0 o 1)
    '    ' Convertimos booleanos a enteros para SQL (0 o 1)
    '    Dim valF1 As Integer = IIf(Item.EsBusquedaF1, 1, 0)
    '    Dim valF2 As Integer = IIf(Item.EsCancelacion, 1, 0)
    '    Dim valF3 As Integer = IIf(Item.EsCambioCantidad, 1, 0)
    '    Dim valF6 As Integer = IIf(Item.EsCajaVirtual, 1, 0)

    '    With FpArticulos.ActiveSheet
    '        If Item.EsKilos OrElse Item.CargandoPendiente OrElse Item.EsCancelacion Then
    '            sCant = Item.Cantidad
    '        End If

    '        If (sCant = "" OrElse sCant = "0") AndAlso Not Item.CargandoPendiente AndAlso Not Item.EsCancelacion Then
    '            sCant = "1"
    '            Item.Cantidad = 1
    '        End If

    '        If .RowCount > 1 Then
    '            If Item.EsKilos Then
    '                ' =============================================================================
    '                ' CASO 1: Artículo REPETIDO (Incrementar Cantidad)
    '                ' =============================================================================
    '                If claveArt = Item.UPC AndAlso Not Item.EsCancelacion AndAlso .Cells(Item.Renglon - 1, ColVenta.ColCantidad).Value > 0 And Not Item.EsKilos And Not Item.CargandoPendiente Then
    '                    Item.Renglon -= 1
    '                    cantacuma = .Cells(Item.Renglon, ColVenta.ColCantidad).Value

    '                    If Not Item.EsKilos Then
    '                        sCant = .Cells(Item.Renglon, ColVenta.ColCantidad).Value + 1
    '                    Else
    '                        sCant = .Cells(Item.Renglon, ColVenta.ColCantidad).Value
    '                    End If

    '                    If Not Item.CargandoPendiente Then
    '                        ' actualización EN BD
    '                        SQL = "update tmpauxvta2 set cantidad=" & sCant & ", FueConF1=" & valF1 & ", FueConF2=" & valF2 & ", FueConF3=" & valF3 & ", FueConF6=" & valF6 & " where renglon=" & Item.Renglon & " and usuario='" & Globales.caja & "'"
    '                        Base.Ejecuta(SQL, sCadenaConexionSQL)

    '                        'SQL = " exec cargaauditoria '" & Globales.caja & "','" & Item.UPC & "'," & sCant
    '                        'Base.Ejecuta(SQL)
    '                    End If

    '                    ' actualización Visual del Grid
    '                    If Item.EsKilos Then
    '                        .Cells(Item.Renglon, ColVenta.ColCantidad).Value = "0"
    '                        .Cells(Item.Renglon, ColVenta.ColPrecio).Value = IIf(Item.TipoOferta = 0, Item.Precio1, Item.PrecioOferta1)
    '                        .Cells(Item.Renglon, ColVenta.ColTotal).Value = "0"
    '                        .RemoveRows(Item.Renglon + 1, 1)
    '                    Else
    '                        .Cells(Item.Renglon, ColVenta.ColCantidad).Value = CInt(sCant)
    '                        .Cells(Item.Renglon, ColVenta.ColPrecio).Value = IIf(Item.TipoOferta = 0, Item.Precio1, Item.PrecioOferta1)
    '                        .Cells(Item.Renglon, ColVenta.ColTotal).Value = IIf(Item.TipoOferta = 0, Item.Precio1, Item.PrecioOferta1) * CInt(sCant)
    '                        .RemoveRows(Item.Renglon + 1, 1)
    '                    End If

    '                    ' actualización de datos informativos (Restaurado)
    '                    .Cells(Item.Renglon, ColVenta.ColFIVA).Value = Item.IVA
    '                    .Cells(Item.Renglon, ColVenta.ColFIEPS).Value = Item.IEPS
    '                    .Cells(Item.Renglon, ColVenta.ColArtClave).Value = Item.Clave
    '                    .Cells(Item.Renglon, ColVenta.ColNomLargo).Value = Item.NombreLargo
    '                    .Cells(Item.Renglon, ColVenta.ColFamilia).Value = Item.Familia
    '                    .Cells(Item.Renglon, ColVenta.ColCostoCap).Value = Item.CostoCap
    '                    .Cells(Item.Renglon, ColVenta.ColTipoOferta).Value = Item.TipoOferta
    '                    .Cells(Item.Renglon, ColVenta.ColPrecio1).Value = Item.Precio1

    '                    .Cells(Item.Renglon, ColVenta.ColF1).Value = valF1
    '                    .Cells(Item.Renglon, ColVenta.ColF2).Value = valF2
    '                    .Cells(Item.Renglon, ColVenta.ColF3).Value = valF3
    '                    .Cells(Item.Renglon, ColVenta.ColF6).Value = valF6
    '                    .Cells(Item.Renglon, ColVenta.ColVale).Value = IIf(Item.TraeVale, "*", "")
    '                Else
    '                    ' =============================================================================
    '                    ' CASO 2: NUEVO renglón (Grid ya tenía datos)
    '                    ' =============================================================================
    '                    If Not Item.CargandoPendiente Then
    '                        SQL = "insert into tmpauxvta2 (renglon,usuario,articulo,cantidad,tipo,FueConF1,FueConF2,FueConF3,ClienteID,ArtClave,TraeVale,Factor,FueConF6) values(" &
    '                                Item.Renglon & ",'" & Globales.caja & "','" & Item.UPC & "'," & IIf(Item.EsKilos, 0, sCant) & "," & Item.TipoVenta & "," & valF1 & ", " & valF2 & "," & valF3 & "," & Item.ClienteID & ",'" & Item.Clave & "',''," & Item.Factor & "," & valF6 & ")"
    '                        Base.Ejecuta(SQL, sCadenaConexionSQL)
    '                        'SQL = " exec cargaauditoria '" & Globales.caja & "','" & UPCUPC & "',1 "
    '                        'Base.Ejecuta(SQL, sCadenaConexionSQL)
    '                    End If

    '                    claveArt = Item.UPC
    '                    ' Pintado visual
    '                    If Me.kilos Then
    '                        .Cells(Item.Renglon, ColVenta.ColCantidad).Value = "0"
    '                        .Cells(Item.Renglon, ColVenta.ColPrecio).Value = "0"
    '                        .Cells(Item.Renglon, ColVenta.ColTotal).Value = "0"
    '                    Else
    '                        If Item.EsKilos = 1 Then
    '                            .Cells(Item.Renglon, ColVenta.ColCantidad).Value = CDbl(sCant)
    '                        Else
    '                            .Cells(Item.Renglon, ColVenta.ColCantidad).Value = CDbl(sCant)
    '                        End If
    '                        .Cells(Item.Renglon, ColVenta.ColPrecio).Value = IIf(Item.TipoOferta = 0, Item.Precio1, Item.PrecioOferta1)
    '                        .Cells(Item.Renglon, ColVenta.ColTotal).Value = IIf(Item.TipoOferta = 0, Item.Precio1, Item.PrecioOferta1) * CDbl(sCant)
    '                    End If

    '                    If Me.kilos Then
    '                        .Cells(iren, ColVenta.ColCantidad).Value = "0"
    '                        .Cells(iren, ColVenta.ColPrecio).Value = "0"
    '                        .Cells(iren, ColVenta.ColTotal).Value = "0"
    '                    Else
    '                        If tipo = 1 Then
    '                            .Cells(iren, ColVenta.ColCantidad).Value = CDbl(sCant)
    '                        Else
    '                            .Cells(iren, ColVenta.ColCantidad).Value = CDbl(sCant)

    '                        End If
    '                        .Cells(iren, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
    '                        .Cells(iren, ColVenta.ColTotal).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1) * CDbl(sCant)
    '                    End If

    '                    .Cells(iren, ColVenta.ColDescripcion).Value = UPCDescripcion
    '                    .Cells(iren, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
    '                    .Cells(iren, ColVenta.ColUPCInv).Value = UPCUPC
    '                    .Cells(iren, ColVenta.ColFIVA).Value = iva
    '                    .Cells(iren, ColVenta.ColFIEPS).Value = ieps
    '                    .Cells(iren, ColVenta.ColArtClave).Value = ArtClave
    '                    .Cells(iren, ColVenta.ColNomLargo).Value = ArtNomLargo

    '                    .Cells(iren, ColVenta.ColFamilia).Value = Familia
    '                    .Cells(iren, ColVenta.ColCostoCap).Value = CostoCap
    '                    .Cells(iren, ColVenta.ColTipoOferta).Value = TipoOferta
    '                    .Cells(iren, ColVenta.ColPrecio1).Value = Precio1

    '                    .Cells(iren, ColVenta.ColF1).Value = IIf(FueConF1, 1, 0)
    '                    .Cells(iren, ColVenta.ColF2).Value = IIf(cancelacion, 1, 0)
    '                    .Cells(iren, ColVenta.ColF3).Value = IIf(FueConF3, 1, 0)
    '                    .Cells(iren, ColVenta.ColF6).Value = IIf(FueConF6, 1, 0)
    '                    .Cells(iren, ColVenta.ColVale).Value = IIf(TraeVale, "*", "")

    '                    .ActiveRowIndex = iren
    '                End If
    '            Else
    '                ' CASO 3: PRIMER renglón (Grid vacío)
    '                If Not CargandoPendiente Then
    '                    SQL = "insert into tmpauxvta2 (renglon,usuario,articulo,cantidad,tipo,FueConF1,FueConF2,FueConF3,ClienteID,ArtClave,TraeVale,Factor,FueConF6) values(" &
    '                                            iren & ",'" & Globales.caja & "','" & UPCUPC & "'," & IIf(kilos, 0, sCant) & "," & txt_tipoventa.Text & "," & valF1 & ", " & valF2 & "," & valF3 & "," & CDbl(TxtControl.Text) & ",'" & ArtClave & "',''," & FactorCapturado & "," & valF6 & ")"
    '                    Base.Ejecuta(SQL, sCadenaConexionSQL)
    '                    SQL = " exec cargaauditoria '" & Globales.caja & "','" & UPCUPC & "',1 "
    '                    'Base.Ejecuta(SQL, sCadenaConexionSQL)
    '                End If

    '                claveArt = UPCUPC
    '                If Me.kilos Then
    '                    .Cells(iren, ColVenta.ColCantidad).Value = "0"
    '                    .Cells(iren, ColVenta.ColPrecio).Value = "0"
    '                    .Cells(iren, ColVenta.ColTotal).Value = "0"
    '                Else
    '                    If tipo = 1 Then
    '                        .Cells(iren, ColVenta.ColCantidad).Value = CInt(sCant)
    '                    Else
    '                        .Cells(iren, ColVenta.ColCantidad).Value = CDbl(sCant)
    '                    End If
    '                    .Cells(iren, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
    '                    .Cells(iren, ColVenta.ColTotal).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1) * CDbl(sCant)
    '                End If

    '                .Cells(iren, ColVenta.ColDescripcion).Value = UPCDescripcion
    '                .Cells(iren, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
    '                .Cells(iren, ColVenta.ColUPCInv).Value = UPCUPC
    '                .Cells(iren, ColVenta.ColFIVA).Value = iva
    '                .Cells(iren, ColVenta.ColFIEPS).Value = ieps
    '                .Cells(iren, ColVenta.ColArtClave).Value = ArtClave
    '                .Cells(iren, ColVenta.ColNomLargo).Value = ArtNomLargo

    '                .Cells(iren, ColVenta.ColFamilia).Value = Familia
    '                .Cells(iren, ColVenta.ColCostoCap).Value = CostoCap
    '                .Cells(iren, ColVenta.ColTipoOferta).Value = TipoOferta
    '                .Cells(iren, ColVenta.ColPrecio1).Value = Precio1

    '                .Cells(iren, ColVenta.ColF1).Value = IIf(FueConF1, 1, 0)
    '                .Cells(iren, ColVenta.ColF2).Value = IIf(cancelacion, 1, 0)
    '                .Cells(iren, ColVenta.ColF3).Value = IIf(FueConF3, 1, 0)
    '                .Cells(iren, ColVenta.ColF6).Value = IIf(FueConF6, 1, 0)
    '                .Cells(iren, ColVenta.ColVale).Value = IIf(TraeVale, "*", "")
    '                .ActiveRowIndex = iren
    '            End If


    '        Else

    '            ' ------------------ PARA PODER REGISTRAR TIEMPO AIRE TIENE QUE SER SOLO EL ARTICULO DEL TIEMPO AIRE
    '            If Not CargandoPendiente Then
    '                SQL = "insert into tmpauxvta2 (renglon,usuario,articulo,cantidad,tipo,FueConF1,FueConF2,FueConF3,ClienteID,ArtClave,TraeVale,Factor,FueConF6) values(" &
    '                      iren & ",'" & Globales.caja & "','" & UPCUPC & "'," & 1 & "," & txt_tipoventa.Text & "," & valF1 & ", " & valF2 & "," & valF3 & "," & CDbl(TxtControl.Text) & ",'" & ArtClave & "',''," & FactorCapturado & "," & valF6 & ")"
    '                Base.Ejecuta(SQL, sCadenaConexionSQL)
    '                SQL = " exec cargaauditoria '" & Globales.caja & "','" & UPCUPC & "',1 "
    '                'Base.Ejecuta(SQL, sCadenaConexionSQL)
    '            End If

    '            SQL = "SELECT * FROM TIEMPOAIREART WHERE ARTICULO='" & UPCUPC & "'"
    '            Base.daQuery(SQL, sCadenaConexionSQL, DSC, "TABLAAIRE")

    '            If DSC.Tables("TABLAAIRE").Rows.Count > 0 Then
    '                estiempoaire = True
    '                TIEMPOCOMIS = IIf(DSC.Tables("TABLAAIRE").Rows(0)("COMISION") = 1, True, False)
    '                claveprod = DSC.Tables("TABLAAIRE").Rows(0)("PRODUCTO")
    '            Else
    '                claveprod = ""
    '            End If


    '            claveArt = UPCUPC
    '            If kilos Then
    '                .Cells(iren, ColVenta.ColCantidad).Value = "0"
    '                .Cells(iren, ColVenta.ColDescripcion).Value = UPCDescripcion
    '                .Cells(iren, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
    '                .Cells(iren, ColVenta.ColTotal).Value = "0"
    '                .Cells(iren, ColVenta.ColUPCInv).Value = UPCUPC
    '                .Cells(iren, ColVenta.ColFIVA).Value = iva
    '                .Cells(iren, ColVenta.ColFIEPS).Value = ieps
    '                .Cells(iren, ColVenta.ColArtClave).Value = ArtClave
    '                .Cells(iren, ColVenta.ColNomLargo).Value = ArtNomLargo

    '                .Cells(iren, ColVenta.ColFamilia).Value = Familia
    '                .Cells(iren, ColVenta.ColCostoCap).Value = CostoCap
    '                .Cells(iren, ColVenta.ColTipoOferta).Value = TipoOferta
    '                .Cells(iren, ColVenta.ColPrecio1).Value = Precio1

    '                .ActiveRowIndex = iren

    '            Else

    '                .Cells(iren, ColVenta.ColCantidad).Value = CDbl(sCant)
    '                .Cells(iren, ColVenta.ColDescripcion).Value = UPCDescripcion
    '                .Cells(iren, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
    '                .Cells(iren, ColVenta.ColTotal).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1) * CDbl(sCant)
    '                .Cells(iren, ColVenta.ColUPCInv).Value = UPCUPC
    '                .Cells(iren, ColVenta.ColFIVA).Value = iva
    '                .Cells(iren, ColVenta.ColFIEPS).Value = ieps
    '                .Cells(iren, ColVenta.ColArtClave).Value = ArtClave
    '                .Cells(iren, ColVenta.ColNomLargo).Value = ArtNomLargo

    '                .Cells(iren, ColVenta.ColFamilia).Value = Familia
    '                .Cells(iren, ColVenta.ColCostoCap).Value = CostoCap
    '                .Cells(iren, ColVenta.ColTipoOferta).Value = TipoOferta
    '                .Cells(iren, ColVenta.ColPrecio1).Value = Precio1

    '                .ActiveRowIndex = iren


    '            End If

    '            .Cells(iren, ColVenta.ColF1).Value = IIf(FueConF1, 1, 0)
    '            .Cells(iren, ColVenta.ColF2).Value = IIf(cancelacion, 1, 0)
    '            .Cells(iren, ColVenta.ColF3).Value = IIf(FueConF3, 1, 0)
    '            .Cells(iren, ColVenta.ColF6).Value = IIf(FueConF6, 1, 0)
    '            .Cells(iren, ColVenta.ColVale).Value = IIf(TraeVale, "*", "")

    '            If virtual = 1 And Not estiempoaire Then
    '                .Cells(iren, ColVenta.ColVale).Value = "*"
    '                virtual = 0

    '            End If
    '        End If
    '    End With

    '    'PARA CAMBIAR A PRECIOS DE MEDIO MAYOREO CUANDO EL VOLUMEN SEA EL INDICADO
    '    CONTROLPRECIOS(UPCUPC, Precio1, Precio2, Precio3, tOPE, IIf(kilos, IIf(CargandoPendiente, sCant, 0), sCant), cantacuma, iren, ArtClave, CargandoPendiente, CantidadDisponible:=CantidadDisponible, PrecioOferta1:=PrecioOferta1, PrecioOferta2:=PrecioOferta2, PrecioOferta3:=PrecioOferta3, CantidadCobradas:=CantidadCobradas + cant, TipoOferta:=TipoOferta)
    '    sCant = ""

    '    sumaSpread()

    '    If estiempoaire Then
    '        Paneltiempo.Visible = True
    '        Paneltiempo.BringToFront()
    '        txt_tel1.Focus()
    '    End If

    'End Sub
    Private Sub CONTROLPRECIOS(ByVal UPCUPC As String, ByVal DPRECIO1 As Decimal, ByVal DPRECIO2 As Decimal, ByVal DPRECIO3 As Decimal, ByVal TOPE As Decimal, ByVal SCANT As Decimal, ByVal SCANTANT As Decimal, ByVal RENGLON As Integer, ByVal ArtClave As String, ByVal Optional CargandoPendiente As Boolean = False, Optional ByVal CantidadDisponible As Decimal = -1, Optional ByVal PrecioOferta1 As Decimal = -1, Optional ByVal PrecioOferta2 As Decimal = -1, Optional ByVal PrecioOferta3 As Decimal = -1, Optional ByVal CantidadCobradas As Integer = 0, Optional ByVal TipoOferta As Integer = 0)

        ' 1. VARIABLES DE TRABAJO (Decimales)
        Dim CantidadTotalAcumulada As Decimal = 0D
        Dim SQL As String = ""
        Dim dscLocal As New DataSet

        ' Calculamos el diferencial que estamos agregando en este momento
        ' (Lo que llevo ahora - Lo que llevaba antes en este renglón)
        Dim DiferenciaCantidad As Decimal = SCANT - SCANTANT

        ' =============================================================================================
        ' PASO 1: OBTENER EL ACUMULADO (Global o Local según el caso)
        ' =============================================================================================

        Try
            Dim WhereClause As String
            If TipoOferta = 1 Then
                WhereClause = "articulo='" & UPCUPC & "'" ' Oferta UPC
            Else
                WhereClause = "ArtClave='" & ArtClave & "'" ' Oferta Familia
            End If

            ' === corrección APLICADA Aquí ===
            ' Lógica del Universo:
            ' A) Si hay CantidadDisponible (> 0), es una carrera contra el inventario global.
            '    Revisamos TODAS las cajas (sin filtrar usuario).
            ' B) Si es ilimitada (-1), es un descuento por volumen personal.
            '    Revisamos SOLO mi caja (filtrando usuario).

            If CantidadDisponible > 0 Then
                ' CHECK GLOBAL (Universo de todas las cajas)
                SQL = "select sum(cantidad) Cantidad from tmpauxvta2 where " & WhereClause
            Else
                ' CHECK LOCAL (Solo mi ticket actual)
                SQL = "select sum(cantidad) Cantidad from tmpauxvta2 where " & WhereClause & " AND USUARIO='" & Globales.caja & "'"
            End If

            Base.daQuery(SQL, sCadenaConexionSQL, dscLocal, "Historial")

            Dim CantidadEnBD As Decimal = 0
            If dscLocal.Tables("Historial").Rows.Count > 0 AndAlso IsNumeric(dscLocal.Tables("Historial").Rows(0)("Cantidad")) Then
                CantidadEnBD = CDec(dscLocal.Tables("Historial").Rows(0)("Cantidad"))
            End If

            ' El Total es: Lo que dice la BD (que puede incluir lo de otras cajas o mi registro anterior) 
            ' + Lo que estoy agregando yo ahorita (Diferencia)
            ' Nota: Si es Check Global, CantidadEnBD incluye lo que otros llevan, lo cual es correcto para validar disponibilidad.
            CantidadTotalAcumulada = CantidadEnBD + DiferenciaCantidad

            dscLocal.Tables.Remove("Historial")

        Catch ex As Exception
            Console.WriteLine("Error consultando históricos: " & ex.Message)
            CantidadTotalAcumulada = SCANT
        End Try


        ' =============================================================================================
        ' PASO 2: ACTUALIZAR LA TABLA TEMPORAL (Globales.caja)
        ' =============================================================================================
        ' Como dependemos 100% del server, esta actualización es CRÍTICA.

        If Not CargandoPendiente Then
            Try
                ' A) Verificar si existe (Lectura rápido)
                SQL = "SELECT ARTICULO FROM " & Globales.caja & " WHERE ARTICULO='" & ArtClave & "'"
                Base.daQuery(SQL, sCadenaConexionSQL, dscLocal, "Existe")

                If dscLocal.Tables("Existe").Rows.Count > 0 Then
                    ' UPDATE: Sumamos la diferencia (Maneja F3 y devoluciones)
                    SQL = "UPDATE " & Globales.caja & " SET CANTIDAD=CANTIDAD+" & DiferenciaCantidad & " WHERE ARTICULO='" & ArtClave & "'"
                    Base.Ejecuta(SQL, sCadenaConexionSQL)
                Else
                    ' INSERT: Creamos el registro
                    If DiferenciaCantidad > 0 Then
                        SQL = "INSERT INTO " & Globales.caja & " (articulo,cantidad) VALUES ('" & ArtClave & "'," & DiferenciaCantidad & ")"
                        Base.Ejecuta(SQL, sCadenaConexionSQL)
                    End If
                End If

                dscLocal.Tables.Remove("Existe")

            Catch ex As Exception
                ' ALERTA CRÍTICA (Ya no es silenciosa)
                ' Si esto falla, el servidor pierde la cuenta de los Artículos.
                ' Avisamos al usuario pero NO cerramos el programa con Stop.
                MsgBox("¡ALERTA DE RED!" & vbCrLf & vbCrLf &
                   "No se pudo actualizar el acumulado en el Servidor." & vbCrLf &
                   "Es posible que las ofertas de Mayoreo no se calculen correctamente." & vbCrLf &
                   "Verifique su conexión.", vbExclamation, "Error de Comunicación")

                ' Opcional: Podrías poner un 'Exit Sub' Aquí si prefieres que NO se calcule precio
                ' si no hay red, pero generalmente es mejor dejar que intente cobrar con lo que tiene.
            End Try
        End If

        ' =============================================================================================
        ' PASO 3: DETERMINAR EL PRECIO CORRECTO (CON CANDADO DE SEGURIDAD)
        ' =============================================================================================
        Dim PrecioFinal As Decimal = DPRECIO1
        Dim AplicaPrecioOferta As Boolean = False

        If TipoOferta > 0 Then
            ' CASO A: Oferta Ilimitada (-1) -> SIEMPRE APLICA o Oferta Limitada (> 0) -> APLICA SOLO SI...  1. El contador es válido (Diferente de -1)  2. Y estamos dentro del rango permitido
            If CantidadDisponible = -1 OrElse (CantidadDisponible > 0 AndAlso CantidadCobradas <> -1 AndAlso CantidadCobradas <= CantidadDisponible) Then
                AplicaPrecioOferta = True
            Else
                ' Caso C: Se acabó la oferta o el contador es inválido
                AplicaPrecioOferta = False
            End If
        End If

        ' B) Selección de Precio 
        Select Case TIPOVENTA
            Case 1 ' MOSTRADOR
                If AplicaPrecioOferta Then
                    If CantidadTotalAcumulada >= TOPE Then
                        PrecioFinal = IIf(PrecioOferta2 > 0, PrecioOferta2, DPRECIO2)
                    Else
                        PrecioFinal = IIf(PrecioOferta1 > 0, PrecioOferta1, DPRECIO1)
                    End If
                Else
                    If CantidadTotalAcumulada >= TOPE Then
                        PrecioFinal = DPRECIO2
                    Else
                        PrecioFinal = DPRECIO1
                    End If
                End If

            Case 2 ' MAYOREO DIRECTO
                If AplicaPrecioOferta AndAlso PrecioOferta2 > 0 Then
                    PrecioFinal = PrecioOferta2
                Else
                    PrecioFinal = DPRECIO2
                End If

            Case 3 ' DISTRIBUIDOR
                If AplicaPrecioOferta AndAlso PrecioOferta3 > 0 Then
                    PrecioFinal = PrecioOferta3
                Else
                    PrecioFinal = DPRECIO3
                End If
        End Select

        ' =============================================================================================
        ' PASO 4: APLICAR PRECIO AL renglón ACTUAL
        ' =============================================================================================
        ' Actualizamos visualmente el renglón que acabamos de escanear o modificar.

        With FpArticulos.ActiveSheet
            .Cells(RENGLON, ColVenta.ColPrecio).Value = PrecioFinal
            ' Recalculamos el total de este renglón (Cantidad * Nuevo Precio)
            ' Usamos CDec para garantizar precisión monetaria.
            Dim CantidadRenglon As Decimal = CDec(.Cells(RENGLON, ColVenta.ColCantidad).Value)
            .Cells(RENGLON, ColVenta.ColTotal).Value = CantidadRenglon * PrecioFinal
        End With

        ' =============================================================================================
        ' PASO 5: PEINAR A LOS HERMANOS (RECALCULA)
        ' =============================================================================================
        ' Ahora que sabemos que el precio bajó (o subió), debemos actualizar todos los 
        ' renglones anteriores que pertenezcan a la misma promoción.

        ' Lógica de Búsqueda para RECALCULA:
        ' - Si es Oferta Tipo 1 (UPC Específico): Buscamos por el código de Barras (UPCUPC).
        ' - Si es Oferta General o Mayoreo: Buscamos por la Familia/Clave (ArtClave).

        Dim ClaveParaBuscar As String
        If TipoOferta = 1 Then
            ClaveParaBuscar = UPCUPC
        Else
            ClaveParaBuscar = ArtClave
        End If

        ' Llamamos a la rutina optimizada (En Memoria) que definimos antes.
        ' Nota: RECALCULA al final ejecuta 'sumaSpread()', aSí que los totales generales se actualizarán ahí.
        RECALCULA(ClaveParaBuscar, PrecioFinal, TipoOferta)

    End Sub
    Private Sub RECALCULAOriginal(ByVal ArtCLave As String, ByVal PRECIO As Decimal, ByVal TipoOferta As Integer)
        ' Optimizada para no hacer consultas SQL dentro del ciclo

        Dim I As Integer
        ' Variables para lectura rápido
        Dim GridUpc As String
        Dim GridClave As String
        Dim GridTipoOferta As Integer
        Dim GridCantidad As Decimal

        With FpArticulos.ActiveSheet
            For I = 0 To .RowCount - 1

                ' 1. Leemos datos de memoria (Grid)
                GridUpc = .Cells(I, ColVenta.ColUPCInv).Text.Trim
                GridClave = .Cells(I, ColVenta.ColArtClave).Text.Trim ' <--- Aquí está EL TRUCO. Usamos la clave que ya tenemos.

                ' VALIDACIÓN de seguridad por si la celda está vacía
                Dim valOferta As String = .Cells(I, ColVenta.ColTipoOferta).Text.Trim
                GridTipoOferta = IIf(IsNumeric(valOferta), CInt(valOferta), 0)

                GridCantidad = CDec(.Cells(I, ColVenta.ColCantidad).Value)

                Dim AplicaCambio As Boolean = False

                ' 2. Lógica de Coincidencia (Match)
                If TipoOferta = 1 Then
                    ' CASO A: Oferta Específica por UPC (Ej. Solo Coca Cola Light)
                    ' Solo cambiamos si el renglón también es TipoOferta 1 y el UPC es idéntico
                    If GridTipoOferta = 1 AndAlso GridUpc = ArtCLave Then
                        AplicaCambio = True
                    End If
                Else
                    ' CASO B: Oferta por Familia/Clave (Ej. Cualquier Refresco Coca Cola)
                    ' Solo cambiamos si el renglón NO es una oferta especial (Tipo 1)
                    If GridTipoOferta <> 1 Then
                        ' En lugar de ir a SQL, comparamos la Clave del Grid con la Clave que recibimos
                        If GridClave = ArtCLave Then
                            AplicaCambio = True
                        End If
                    End If
                End If

                ' 3. Ejecución del Cambio
                If AplicaCambio Then
                    .Cells(I, ColVenta.ColPrecio).Value = PRECIO
                    .Cells(I, ColVenta.ColTotal).Value = GridCantidad * PRECIO
                End If
            Next
        End With

        ' Importante: Al mover precios individuales, el gran total cambia.
        Me.sumaSpread()
    End Sub

    Private Sub CONTROLPRECIOSOriginal(ByVal UPCUPC As String, ByVal DPRECIO1 As Double, ByVal DPRECIO2 As Double, ByVal DPRECIO3 As Double, ByVal TOPE As Double, ByVal SCANT As Double, ByVal SCANTANT As Double, ByVal RENGLON As Integer, ByVal ArtClave As String, ByVal Optional CargandoPendiente As Boolean = False, Optional ByVal CantidadDisponible As Integer = -1, Optional ByVal PrecioOferta1 As Double = -1, Optional ByVal PrecioOferta2 As Double = -1, Optional ByVal PrecioOferta3 As Double = -1, Optional ByVal CantidadCobradas As Double = 0, Optional ByVal TipoOferta As Integer = 0)
        Dim CantidadEnTicket As Double
        Dim SQL As String
        Dim dsc1 As New DataSet

        Dim YaEstoyTipo2 As Boolean = False
        Using DSC As New DataSet
            SQL = "SELECT * FROM " & Globales.caja & "  WHERE ARTICULO='" & ArtClave & "'"
            Try
                Base.daQuery(SQL, sCadenaConexionSQL, DSC, "ART")
            Catch ex As Exception
                MsgBox("No pudieron recalcularse los precios.", vbCritical, "Punto de Venta")
            End Try
            If DSC.Tables("Art").Rows.Count > 0 Then
                'If TIPOVENTA > 1 OrElse (TIPOVENTA = 1 AndAlso CDbl(DSC.Tables("ART").Rows(0)("CANTIDAD")) >= TOPE) Then 'Busco si lo registrado excede el tope, si lo excede 
                '    YaEstoyTipo2 = True
                'Else
                '    YaEstoyTipo2 = False
                'End If

                Dim CantTickTemp As Double
                Select Case TipoOferta
                    Case 1, 2
                        'UPC (1), Clave (2)
                        If CantidadDisponible > 0 Then 'Si oferta es por cantidad
                            SQL = "select sum(cantidad) Cantidad from tmpauxvta2 where " & IIf(TipoOferta = 1, "articulo='" & UPCUPC, "ArtClave='" & ArtClave) & "'"
                            Try
                                Base.daQuery(SQL, sCadenaConexionSQL, DSC, "CantTick")
                                If DSC.Tables("CantTick").Rows.Count > 0 Then
                                    CantTickTemp = DSC.Tables("CantTick").Rows(0)("Cantidad") + SCANT - SCANTANT
                                Else
                                    CantTickTemp = 0 + SCANT - SCANTANT
                                End If
                                DSC.Tables.Remove("CantTick")
                            Catch ex As Exception
                                MsgBox("No pudieron recalcularse los precios.", vbCritical, "Punto de Venta")
                            End Try
                        Else
                            SQL = "select sum(cantidad) Cantidad from tmpauxvta2 where " & IIf(TipoOferta = 1, "articulo='" & UPCUPC, "ArtClave='" & ArtClave) & "' AND USUARIO='" & Globales.caja & "'"
                            Try
                                Base.daQuery(SQL, sCadenaConexionSQL, DSC, "CantTick")
                                If DSC.Tables("CantTick").Rows.Count > 0 Then
                                    CantTickTemp = DSC.Tables("CantTick").Rows(0)("Cantidad")
                                Else
                                    CantTickTemp = 0 + SCANT - SCANTANT
                                End If
                                DSC.Tables.Remove("CantTick")
                            Catch ex As Exception
                                MsgBox("No pudieron recalcularse los precios.", vbCritical, "Punto de Venta")
                            End Try


                            'CantTickTemp = DSC.Tables("ART").Rows(0)("CANTIDAD") + SCANT - SCANTANT
                        End If
                    Case 3
                        'Familia
                        CantTickTemp = DSC.Tables("ART").Rows(0)("CANTIDAD") + IIf(CargandoPendiente, 0, SCANT - SCANTANT)
                    Case 4
                        'Marca
                        CantTickTemp = DSC.Tables("ART").Rows(0)("CANTIDAD") + IIf(CargandoPendiente, 0, SCANT - SCANTANT)
                    Case Else
                        Dim CounterTemp As Double = 0
                        For i As Integer = 0 To FpArticulos.ActiveSheet.Rows.Count - 1
                            If FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTipoOferta).Value = 0 AndAlso FpArticulos.ActiveSheet.Cells(i, ColVenta.ColArtClave).Value = ArtClave Then
                                CounterTemp += FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
                            End If
                        Next
                        If CounterTemp = 0 Then
                            CounterTemp = SCANT + SCANTANT
                        End If
                        CantTickTemp = CounterTemp
                End Select

                CantidadEnTicket = CantTickTemp 'IIf(CargandoPendiente, DSC.Tables("ART").Rows(0)("CANTIDAD"), CantTickTemp)

                If Not CargandoPendiente Then
                    SQL = "UPDATE " & Globales.caja & " SET CANTIDAD=CANTIDAD+" & SCANT - SCANTANT & " WHERE ARTICULO='" & ArtClave & "'"
                    Dim Res As MsgBoxResult = MsgBoxResult.Yes
                    Do While Res = MsgBoxResult.Yes
                        Try
                            Base.Ejecuta(SQL, sCadenaConexionSQL)
                            Exit Do
                        Catch ex As Exception
                            Res = MsgBox("Error al actualizar Tabla " & Globales.caja & Chr(13) & Chr(13) & "¿Desea intentar nuevamente?", MsgBoxStyle.YesNo, "Punto de Venta")
                            If Res = MsgBoxResult.No Then Stop
                            'Registrar step en base de datos
                        End Try
                    Loop
                End If
            Else
                CantidadEnTicket = CDbl(SCANT)
                If Not CargandoPendiente Then
                    SQL = "insert into " & Globales.caja & " (articulo,cantidad) values ('" & ArtClave & "'," & SCANT - SCANTANT & ")"
                    Base.Ejecuta(SQL, sCadenaConexionSQL)
                End If
            End If
        End Using

        'If TIPOVENTA = 1 OrElse TipoOferta > 0 Then
        Dim Precio1APeinar, Precio2APeinar As Double
        If (CantidadDisponible > 0 AndAlso CantidadCobradas <> -1 AndAlso CantidadCobradas <= CantidadDisponible) OrElse (CantidadDisponible = -1) AndAlso TipoOferta > 0 Then 'Cuando hay oferta por cantidad y aun queda
            'If CantidadCobradas <= CantidadDisponible Then
            Dim Prec As Double
            Select Case TIPOVENTA
                Case 1
                    'Validar cuantos van cobrados por clave, y cuantos por upc, y como existe oferta, definir cuáles para cuál
                    'Si lo cobrado por upc excede el tope, o si el articulo excede el tope

                    'Buscar en TmpAuxVta2 con el usuario (caja) en cuestión, y validar

                    If CantidadEnTicket >= TOPE Then 'Si la cantidad cobrada en ticket por clave
                        Prec = PrecioOferta2
                        Precio2APeinar = Prec
                        Precio1APeinar = -1
                    Else
                        Prec = PrecioOferta1
                        Precio2APeinar = -1
                        Precio1APeinar = Prec
                    End If
                Case 2
                    Prec = PrecioOferta2
                    Precio2APeinar = Prec
                    Precio1APeinar = -1
                Case 3
                    Prec = PrecioOferta3
                    Precio2APeinar = -1
                    Precio1APeinar = Prec
            End Select
            FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = Prec
        Else 'Si no hubo oferta o ya no se alcanzó la cantidad
            If (TIPOVENTA = 1 AndAlso CantidadEnTicket >= TOPE) OrElse TIPOVENTA = 2 Then
                FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = DPRECIO2
                Precio2APeinar = DPRECIO2
                Precio1APeinar = -1
            ElseIf (TIPOVENTA = 1 AndAlso CantidadEnTicket < TOPE) Then
                FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = DPRECIO1
                Precio2APeinar = -1
                Precio1APeinar = DPRECIO1
            ElseIf TIPOVENTA = 3 Then
                FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = DPRECIO3
                Precio2APeinar = DPRECIO3
                Precio1APeinar = -1
            End If
        End If
        FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColTotal).Value = FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value * FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColCantidad).Value
        RECALCULA(IIf(TipoOferta <> 1, ArtClave, UPCUPC), IIf(Precio1APeinar <> -1, Precio1APeinar, Precio2APeinar), TipoOferta)

        'If (tx_cantidad.Visible AndAlso tx_cantidad.Text <> "") OrElse (CantidadEnTicket >= TOPE AndAlso Not YaEstoyTipo2) OrElse (CantidadEnTicket < TOPE AndAlso YaEstoyTipo2) Then 'Si excedo el tope con lo actualmente cobrado o con lo que estoy cobrando ya me regreSí a menos del tope
        '    If YaEstoyTipo2 Then
        '        RECALCULA(IIf(TipoOferta <> 1, ArtClave, UPCUPC), IIf(Precio1APeinar <> -1, Precio1APeinar, Precio2APeinar), TipoOferta)
        '        'RECALCULA(ArtClave, Precio1APeinar)
        '    Else
        '        'RECALCULA(ArtClave, Precio2APeinar)
        '        RECALCULA(IIf(TipoOferta <> 1, ArtClave, UPCUPC), IIf(Precio1APeinar <> -1, Precio1APeinar, Precio2APeinar), TipoOferta)
        '    End If
        'End If
        'End If
    End Sub

    Private Sub RECALCULAOriginal(ByVal ArtCLave As String, ByVal PRECIO As Double, ByVal TipoOferta As Integer)
        Dim I As Integer

        Dim GridUpc As String
        Dim GridClave As String
        Dim GridTipoOferta As Integer
        Dim GridCantidad As Decimal

        Dim sql As String
        Dim dsc1 As New DataSet
        Dim ArtClaveSpread As String

        For I = 0 To FpArticulos.ActiveSheet.RowCount - 1
            If TipoOferta = 1 AndAlso FpArticulos.ActiveSheet.Cells(I, ColVenta.ColTipoOferta).Text.Trim = 1 Then
                If FpArticulos.ActiveSheet.Cells(I, ColVenta.ColUPCInv).Text.Trim = ArtCLave Then
                    FpArticulos.ActiveSheet.Cells(I, ColVenta.ColPrecio).Value = PRECIO
                    FpArticulos.ActiveSheet.Cells(I, ColVenta.ColTotal).Value = FpArticulos.ActiveSheet.Cells(I, ColVenta.ColCantidad).Value * PRECIO
                End If
            Else
                If FpArticulos.ActiveSheet.Cells(I, ColVenta.ColTipoOferta).Text.Trim <> 1 Then
                    sql = "select * from xupc where upc_upc='" & FpArticulos.ActiveSheet.Cells(I, ColVenta.ColUPCInv).Text.Trim & "'"
                    Base.daQuery(sql, sCadenaConexionSQL, dsc1, "art")
                    If dsc1.Tables("art").Rows.Count > 0 Then
                        ArtClaveSpread = dsc1.Tables("art").Rows(0)("upc_cveart")
                    Else
                        ArtClaveSpread = ""
                    End If
                    dsc1.Tables.Remove("art")

                    If ArtClaveSpread = ArtCLave Then
                        FpArticulos.ActiveSheet.Cells(I, ColVenta.ColPrecio).Value = PRECIO
                        FpArticulos.ActiveSheet.Cells(I, ColVenta.ColTotal).Value = FpArticulos.ActiveSheet.Cells(I, ColVenta.ColCantidad).Value * PRECIO
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub RECALCULA(ByVal ClaveBusqueda As String, ByVal NuevoPrecio As Decimal, ByVal TipoOferta As Integer)

        ' ClaveBusqueda: Puede ser el UPC (si es oferta Específica) o la Clave de Artículo (si es mayoreo general).
        ' NuevoPrecio: El precio barato que acaba de calcular ControlPrecios.

        With FpArticulos.ActiveSheet
            ' Recorremos TODOS los renglones del grid
            For i As Integer = 0 To .RowCount - 1
                Dim EsHermano As Boolean = False

                ' 1. IDENTIFICAR A LOS "HERMANOS"
                ' Dependiendo del tipo de oferta, la hermandad se define diferente.

                If TipoOferta = 1 Then
                    ' CASO A: Oferta por UPC Específico (Ej. 3x2 en Sabritas Sal)
                    ' Solo actualizamos los que tengan EXACTAMENTE el mismo UPC.
                    If .Cells(i, ColVenta.ColUPCInv).Text.Trim = ClaveBusqueda Then
                        EsHermano = True
                    End If
                Else
                    ' CASO B: Mayoreo General (Ej. A partir de 6 piezas de Refrescos Familia Coca-Cola)
                    ' Actualizamos todos los que compartan la CLAVE DE Artículo (Familia).
                    ' Esto permite que si llevas 3 Cocas y 3 Sprites, ambos bajen de precio.
                    If .Cells(i, ColVenta.ColArtClave).Text.Trim = ClaveBusqueda Then
                        EsHermano = True
                    End If
                End If

                ' 2. APLICAR EL NUEVO PRECIO
                If EsHermano Then

                    ' Solo actualizamos si el precio es diferente (para ahorrar parpadeos)
                    Dim PrecioActualEnRenglon As Decimal = CDec(.Cells(i, ColVenta.ColPrecio).Value)
                    ' Actualizamos Precio Unitario
                    .Cells(i, ColVenta.ColPrecio).Value = NuevoPrecio

                    ' Recalculamos el Total de ese renglón
                    Dim CantidadRenglon As Decimal = CDec(.Cells(i, ColVenta.ColCantidad).Value)
                    .Cells(i, ColVenta.ColTotal).Value = CantidadRenglon * NuevoPrecio

                    ' Opcional: Feedback visual (Azul si bajó a oferta)
                    If NuevoPrecio < CDec(.Cells(i, ColVenta.ColPrecio1).Value) AndAlso CDec(.Cells(i, ColVenta.ColCantidad).Value) > 0 Then
                        If TipoOferta > 0 Then
                            .Rows(i).ForeColor = Color.Blue
                        Else
                            If TIPOVENTA = 1 Then
                                .Rows(i).ForeColor = Color.Green
                            Else
                                .Rows(i).ForeColor = Color.Black
                            End If
                        End If

                    Else
                        If CDec(.Cells(i, ColVenta.ColCantidad).Value) <= 0 Then
                            .Rows(i).ForeColor = Color.Red
                        Else
                            .Rows(i).ForeColor = Color.Black
                        End If
                    End If

                End If
            Next
        End With

        ' Al final, recalculamos la suma total del ticket
        sumaSpread()

    End Sub
    Private Sub sumaSpread()
        ' 1. CAMBIO A DECIMAL (Coherencia con ProcesarHallazgo)
        Dim dTotal As Decimal = 0D
        Dim dTotalDifP1 As Decimal = 0D

        ' Variables auxiliares para lectura segura
        Dim valTotal As Object
        Dim valP1 As Object
        Dim valPReal As Object
        Dim valCant As Object

        With FpArticulos.ActiveSheet
            ' Iteramos el grid
            For iRen As Integer = 0 To .RowCount - 1

                ' Lectura segura: Obtenemos el objeto, luego validamos
                valTotal = .Cells(iRen, ColVenta.ColTotal).Value
                valP1 = .Cells(iRen, ColVenta.ColPrecio1).Value
                valPReal = .Cells(iRen, ColVenta.ColPrecio).Value
                valCant = .Cells(iRen, ColVenta.ColCantidad).Value

                ' A) SUMA TOTAL
                ' IsNumeric valida que no sea Nothing, ni DBNull, ni texto basura
                If IsNumeric(valTotal) Then
                    dTotal += CDec(valTotal)
                End If

                ' B) CÁLCULO DIFERENCIA (Comisión / Ahorro)
                ' (Precio1 - PrecioCobrado) * Cantidad
                If IsNumeric(valP1) AndAlso IsNumeric(valPReal) AndAlso IsNumeric(valCant) Then
                    dTotalDifP1 += (CDec(valP1) - CDec(valPReal)) * CDec(valCant)
                End If
            Next
        End With

        ' 2. actualización UI Y GLOBALES
        ' Usamos .ToString("N2") para asegurar 2 decimales visuales siempre
        TotalVenta = dTotal
        LbTotal.Text = dTotal.ToString("C2") ' Formato Moneda ($1,234.50)

        ' Variables Globales (Ya son Decimales, no requieren Round extra si la suma fue limpia)
        totalote = dTotal
        MontoMaximoComision = dTotalDifP1

        ' 3. SCROLL automáticO AL FINAL
        FpArticulos.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Bottom, FarPoint.Win.Spread.HorizontalPosition.Left)

    End Sub

    Private Sub TimerReloj_Tick(sender As Object, e As EventArgs) Handles TimerReloj.Tick
        ' Actualizamos la etiqueta cada segundo
        ' Usamos StrConv para poner la primera letra del mes en Mayúscula (Diciembre, no diciembre)

        Dim Fecha As String = Now.ToString("dd \de MMMM \de\l yyyy")
        Dim Hora As String = Now.ToString("HH:mm:ss")

        ' "16 de Diciembre del 2023 | Hora: 10:25:30"
        ' StrConv(..., VbStrConv.ProperCase) pone Mayúsculas bonitas al mes
        Label11.Text = StrConv(Fecha, VbStrConv.ProperCase) & " | Hora: " & Hora

    End Sub
    Public Sub GuardaTicketCliente(ByRef ClienteID As Integer, ByRef Ticket As Double)
        Dim sql As String
        Try
            Base.Ejecuta("insert into TicketsClientes (ClienteID,FolioTicket) Values (" & ClienteID & "," & Ticket & ")", sCadenaConexionSQL)
        Catch ex As Exception
            MsgBox("No se registró el ticket en tabla de TicketsClientes.", MsgBoxStyle.Critical, "Punto de Venta")
        End Try
    End Sub

    Public Function guardaTicket(FolioCaja As String)
        Dim iRen As Integer = 0
        Dim sSql As String = ""
        Dim xsql As String = ""
        Dim dsc As New DataSet
        Dim dsc1 As New DataSet
        Dim iID As Integer
        Dim iva, IEPS As Double
        Dim familia As String
        Dim costo As Double
        Dim precio As Double
        Dim cant As Double
        Dim DATO As String
        Dim sql As String
        Dim dsc2 As New DataSet
        Dim dsc3 As New DataSet
        Dim dsc4 As New DataSet
        'Dim cap1 As Double
        'Dim cap2 As Double
        'Dim uni1 As String
        'Dim uni2 As String
        Dim xrenglon As Integer


        'xven = 0
        'sql = "select isnull(folio,0)+1 maximo from eccontrolventa"
        'Base.daQuery(sql, sCadenaConexionSQL, dsc, "tabla")
        'xven = dsc.Tables("tabla").Rows(0)("maximo")
        'Base.Ejecuta("update eccontrolventa set folio=folio+1", sCadenaConexionSQL)


        DATO = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)

        'Para generar el consolidado del ticket
        Try
            Base.Ejecuta("DELETE FROM TMPAUXVTA WHERE TMP_USUARIO='" & Globales.caja & "'", sCadenaConexionSQL)
        Catch ex As Exception
            'Aqui no pasa nada, solo abortar toda la mision.
            MsgBox("Error al borrar los datos de tabla TmpAuxVta", MsgBoxStyle.Critical, "Punto de Venta")
            Return False
        End Try

        With FpArticulos.ActiveSheet
            'REGISTRA LOS MOVIMIENTOS 
            For i As Integer = 0 To .RowCount - 1
                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .Cells(i, 4).Text.Trim & "'"
                'Base.daQuery(sql, sCadenaConexionSQL, dsc3, "codart")
                'If dsc3.Tables("codart").Rows.Count > 0 Then
                'sql = "select * from tmpauxvta where tmp_articulo='" & dsc3.Tables("codart").Rows(0)("upc_cveart") & "' and tmp_usuario='" & Globales.caja & "'"
                sql = "select * from tmpauxvta where tmp_articulo='" & .Cells(i, 11).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Try
                    Base.daQuery(sql, sCadenaConexionSQL, dsc2, "impri")
                Catch ex As Exception
                    Try
                        Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                        MsgBox("Error al traer los datos de tabla TmpAuxVta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    Catch ex2 As Exception
                        MsgBox("Error al traer los datos de tabla TmpAuxVta. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    End Try
                End Try

                If dsc2.Tables("impri").Rows.Count > 0 Then
                    sql = "UPDATE TMPAUXVTA SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, 0).Value &
                                " ,TMP_TOTAL=(tmp_cantidad+" & .Cells(i, 0).Value & ")*" & .Cells(i, 2).Value & " where tmp_articulo='" & .Cells(i, 11).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Else
                    sql = "INSERT INTO TMPAUXVTA SELECT '" & Globales.caja & "'," & .Cells(i, 0).Value & ",'" & .Cells(i, 11).Text.Trim &
                            "','" & .Cells(i, 12).Text.Trim & "'," & .Cells(i, 2).Value & "," & .Cells(i, 3).Value
                End If
                Try
                    Base.Ejecuta(sql, sCadenaConexionSQL)
                Catch ex As Exception
                    dsc2.Tables.Remove("impri")
                    Try
                        Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                        MsgBox("Error al traer los datos de tabla TmpAuxVta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    Catch ex2 As Exception
                        MsgBox("Error al registrar la información en tabla TmpAuxVta. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    End Try
                End Try
                dsc2.Tables.Remove("impri")
                'End If
                'dsc3.Tables.Remove("codart")
            Next i
        End With


        'PARA GENERAR UN CONSOLIDADO DE VENTAS SIN LAS CANCELACIONES QUE SE REGISTRARON

        Try
            Base.Ejecuta("DELETE FROM TMPAUXVTA1 WHERE TMP_USUARIO='" & Globales.caja & "'", sCadenaConexionSQL)
        Catch ex As Exception
            Try
                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                MsgBox("Error al borrar los datos de tabla TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                Return False
            Catch ex2 As Exception
                MsgBox("Error al borrar los datos de tabla TmpAuxVta1. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                Return False
            End Try
        End Try

        With FpArticulos.ActiveSheet
            'REGISTRA LOS MOVIMIENTOS 
            For i As Integer = 0 To .RowCount - 1
                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .Cells(i, 4).Text.Trim & "'"
                'Base.daQuery(sql, sCadenaConexionSQL, dsc3, "codart")
                'If dsc3.Tables("codart").Rows.Count > 0 Then
                sql = "select * from tmpauxvta1 where tmp_articulo='" & .Cells(i, 11).Text.Trim & "'" &
                    " AND TMP_UPC='" & .Cells(i, 4).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Try
                    Base.daQuery(sql, sCadenaConexionSQL, dsc2, "impri")
                Catch ex As Exception
                    Try
                        Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                        MsgBox("Error al traer los datos de tabla TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return (True, False, False, False, False, False)
                    Catch ex2 As Exception
                        MsgBox("Error al traer los datos de tabla TmpAuxVta1. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return (False, False, False, False, False, False)
                    End Try
                End Try

                If dsc2.Tables("impri").Rows.Count > 0 Then
                    sql = "UPDATE TMPAUXVTA1 SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, 0).Value &
                        " ,TMP_TOTAL=(tmp_cantidad+" & .Cells(i, 0).Value & ")*" & .Cells(i, 2).Value &
                        IIf(.Cells(i, 7).Value = dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=FueConF1", IIf(.Cells(i, 7).Value > dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=" & .Cells(i, 7).Value, "")) &
                        IIf(.Cells(i, 8).Value = dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=FueConF2", IIf(.Cells(i, 8).Value > dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=" & .Cells(i, 8).Value, "")) &
                        IIf(.Cells(i, 9).Value = dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=FueConF3", IIf(.Cells(i, 9).Value > dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=" & .Cells(i, 9).Value, "")) &
                        " where tmp_articulo='" & .Cells(i, 11).Text.Trim & "'" &
                        " AND TMP_UPC='" & .Cells(i, 4).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Else
                    sql = "INSERT INTO TMPAUXVTA1 SELECT '" & Globales.caja & "'," & .Cells(i, 0).Value & ",'" & .Cells(i, 11).Text.Trim &
                    "','" & .Cells(i, 12).Text.Trim & "'," & .Cells(i, 2).Value & "," & .Cells(i, 3).Value & ",'" & .Cells(i, 4).Text.Trim & "'," &
                     .Cells(i, 6).Text.Trim & ",0,'" &
                        .Cells(i, 13).Text.Trim & "'," & .Cells(i, 7).Value & "," & .Cells(i, 8).Value & "," & .Cells(i, 9).Value & "," & .Cells(i, 10).Text.Trim & ",0," & .Cells(i, 14).Text.Trim
                End If
                Try
                    Base.Ejecuta(sql, sCadenaConexionSQL)
                Catch ex As Exception
                    dsc2.Tables.Remove("impri")
                    Try
                        Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                        Try
                            Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                            MsgBox("Error al registrar la información en tabla TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                            Return (False, False, False, False, False, False)
                        Catch ex2 As Exception
                            MsgBox("Error al registrar la información en tabla TmpAuxVta1. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
                            Return False
                        End Try
                    Catch ex3 As Exception
                        MsgBox("Error al registrar la información en tabla TmpAuxVta1. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    End Try
                End Try
                dsc2.Tables.Remove("impri")
                'End If
                'dsc3.Tables.Remove("codart")
            Next i
        End With

        'MOFICACION PARA CAJAS FIJAS
        'PARA INSERTAR TOTALES EN ECVENTA
        Dim RestaCancelacionUPC As Double
        Dim TraeVale As Boolean
        TraeVale = False
        With FpArticulos.ActiveSheet
            For i As Integer = 0 To .RowCount - 1
                RestaCancelacionUPC = 0
                If .Cells(i, 5).Text = "*" Then
                    For k As Integer = 0 To .RowCount - 1
                        If k <> i Then
                            If .Cells(i, 4).Text.Trim = .Cells(k, 4).Text.Trim Then
                                If .Cells(k, 0).Text <> "" Then
                                    If IsNumeric(.Cells(k, 0).Value) Then
                                        If CDbl(.Cells(k, 0).Value) < 0 Then
                                            RestaCancelacionUPC += CDbl(.Cells(k, 0).Value)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next k

                    If .Cells(i, 0).Text <> "" Then
                        If IsNumeric(.Cells(i, 0).Value) Then
                            If CDbl(.Cells(i, 0).Value) + RestaCancelacionUPC > 0 Then
                                TraeVale = True
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next i
        End With

        sSql = "insert into ecventa (ven_id,ven_usuario,ven_fecha,ven_status,ven_total,ven_turno,ven_tipov,CORTE, NombreCajera, TraeVale) " 'Serie
        sSql &= "values (" & xven & ",'" & DATO & "',getDate(),1," & LbTotal.Text.Replace(",", "").Replace("$", "") + "," & Globales.iTurnoActivo & "," & TIPOVENTA & ",0,'" & Globales.NombreEmpleado & "','" & IIf(TraeVale, "*", "") & "')" 'Serie

        Try
            Base.Ejecuta(sSql, sCadenaConexionSQL)
            'sSql = "select max(ven_id) from ecventa where ven_usuario='" & DATO & "'"
            'Base.daQuery(sSql, sCadenaConexionSQL, dsc, "maximo")
            iID = xven
            numt = iID

            Try
                Base.Ejecuta("insert into LigasFolios values(" & xven & ",'" & FolioCaja & "')", sCadenaConexionSQL)
            Catch ex As Exception
                Try
                    Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", sCadenaConexionSQL)
                    Try
                        Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                        Try
                            Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                            MsgBox("Error al registrar la información en LigasFolios. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                            Return False
                        Catch ex4 As Exception
                            MsgBox("Error al registrar la información en LigasFolios. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1 y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                            Return False
                        End Try
                    Catch ex3 As Exception
                        MsgBox("Error al registrar la información en LigasFolios. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta, sólo de ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    End Try
                Catch ex2 As Exception
                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en LigasFolios. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                    Return False
                End Try
            End Try


            If estiempoaire Then
                sSql = "insert into ecdetventatel (dve_venta,dve_telefono,dve_fecha,dve_folio) "
                sSql &= "values (" & iID & ",'" & txt_ctel1.Text & "-" & txt_ctel2.Text & "-" & txt_ctel3.Text & "-" & txt_ctel4.Text & "',getdate(),0)" 'serie
                Base.Ejecuta(sSql, sCadenaConexionSQL)
            End If

            '-----------------------------------------------------------------------------
            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASTICKET ECDETVENTA

            With FpArticulos.ActiveSheet
                'REGISTRA LOS MOVIMIENTOS 
                For i As Integer = 0 To .RowCount - 1
                    RestaCancelacionUPC = 0
                    If .Cells(i, 5).Text = "*" Then
                        For k As Integer = 0 To FpArticulos.ActiveSheet.Rows.Count - 1
                            If k <> i Then
                                If .Cells(i, 4).Text.Trim = .Cells(k, 4).Text.Trim Then
                                    If .Cells(k, 0).Text <> "" Then
                                        If IsNumeric(.Cells(k, 0).Value) Then
                                            If CDbl(.Cells(k, 0).Value) < 0 Then
                                                RestaCancelacionUPC += CDbl(.Cells(k, 0).Value)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next k
                        If .Cells(i, 0).Text <> "" Then
                            If IsNumeric(.Cells(i, 0).Value) Then
                                If CDbl(.Cells(i, 0).Value) > 0 Then
                                    'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .Cells(i, 4).Text.Trim & "'"
                                    'Base.daQuery(sql, sCadenaConexionSQL, dsc3, "codart1")
                                    'If dsc3.Tables("codart1").Rows.Count > 0 Then
                                    If CDbl(.Cells(i, 0).Value) + RestaCancelacionUPC > 0 Then
                                        sql = "INSERT INTO ECVENTADETE SELECT " & iID & ",'" & 'Serie
                                            .Cells(i, 11).Text.Trim & "','" & .Cells(i, 4).Text.Trim & "'," & .Cells(i, 0).Value + RestaCancelacionUPC & "," &
                                        .Cells(i, 2).Value & "," & .Cells(i, 3).Value
                                        Try
                                            Base.Ejecuta(sql, sCadenaConexionSQL)
                                        Catch ex As Exception
                                            Try
                                                Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, sCadenaConexionSQL)
                                                Try
                                                    Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", sCadenaConexionSQL)
                                                    Try
                                                        Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                                        Try
                                                            Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                                            MsgBox("Error al registrar la información en LigasFolios. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                                                            Return False
                                                        Catch ex5 As Exception
                                                            MsgBox("Error al registrar la información en LigasFolios. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1, ECVenta y ECVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                                                            Return False
                                                        End Try
                                                    Catch ex4 As Exception
                                                        MsgBox("Error al registrar la información en ECVenta. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta, sólo de ECVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                                                        Return False
                                                    End Try
                                                Catch ex3 As Exception
                                                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDete. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                                                    Return False
                                                End Try
                                            Catch ex2 As Exception
                                                MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDete. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                                                Return False
                                            End Try
                                        End Try
                                    End If
                                    'End If
                                    'dsc3.Tables.Remove("codart1")
                                End If
                            End If
                        End If
                    End If
                Next i
            End With

            Try
                sql = "Select * from tmpauxvta where tmp_usuario='" & Globales.caja & "'"
                Base.daQuery(sql, sCadenaConexionSQL, dsc2, "detventa")
            Catch ex As Exception
                Try
                    Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, sCadenaConexionSQL)
                    Try
                        Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", sCadenaConexionSQL)
                        Try
                            Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                            Try
                                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                MsgBox("Error al traer los datos de tabla TmpAuxVta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                                Return False
                            Catch ex5 As Exception
                                MsgBox("Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1, ECVenta y ECVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                                Return False
                            End Try
                        Catch ex4 As Exception
                            MsgBox("Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                            Return False
                        End Try
                    Catch ex3 As Exception
                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    End Try
                Catch ex2 As Exception
                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                    Return False
                End Try
            End Try


            xrenglon = 1
            If dsc2.Tables("detventa").Rows.Count > 0 Then

                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
                    With FpArticulos.ActiveSheet
                        'xsql = "Select art_iva,art_ieps,art_costocap2,art_familia,art_cap1,art_uni1,art_cap2,art_uni2 from articulo where art_clave='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
                        'Base.daQuery(xsql, sCadenaConexionSQL, dsc1, "precios")
                        If .Cells(iRen, 11).Text.Trim <> "" Then
                            iva = .Cells(iRen, 6).Text.Trim
                            IEPS = .Cells(iRen, 10).Text.Trim
                            costo = .Cells(iRen, 14).Text.Trim
                            familia = .Cells(iRen, 13).Text.Trim
                            'cap1 = dsc1.Tables("precios").Rows(0)("art_cap1")
                            'cap2 = dsc1.Tables("precios").Rows(0)("art_cap2")
                            'uni1 = dsc1.Tables("precios").Rows(0)("art_uni1")
                            'uni2 = dsc1.Tables("precios").Rows(0)("art_uni2")
                        Else
                            iva = 0
                            IEPS = 0
                            costo = 0
                            familia = 0
                            'cap1 = 1
                            'cap2 = 1
                            'uni1 = "PZ"
                            'uni2 = "PZ"
                        End If
                        'dsc1.Tables.Remove("precios")
                        precio = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_precio"))
                        cant = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_cantidad"))


                        sSql = "insert into ecdetventa (dve_venta,dve_articulo,dve_precio,dve_cantidad,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon, DVE_PORIEPS, DVE_IEPS) "
                        sSql &= "values (" & iID & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & precio & "," & cant & "," & 'serie
                         iva & "," & ((precio * cant) / (1 + (iva / 100))) * iva / 100 & "," & costo & "," & cant * costo & ",'" & familia & "'," & iRen + 1 & "," & IEPS & "," & ((precio * cant) / (1 + (IEPS / 100))) * IEPS / 100 & ")"
                        Try
                            Base.Ejecuta(sSql, sCadenaConexionSQL)
                        Catch ex As Exception
                            dsc2.Tables.Remove("detventa")
                            Try
                                Base.Ejecuta("delete from ecdetventa where dve_venta=" & xven, sCadenaConexionSQL)
                                Try
                                    Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, sCadenaConexionSQL)
                                    Try
                                        Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", sCadenaConexionSQL)
                                        Try
                                            Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                            Try
                                                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                                MsgBox("Error al insertar datos en ECDetVenta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                                                Return False
                                            Catch ex6 As Exception
                                                MsgBox("Error al insertar datos en ECDetVenta. No pudo borrarse información de TmpAuxVta, sólo de ECDetVenta, ECVentaDete, ECVenta y TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
                                                Return False
                                            End Try
                                        Catch ex5 As Exception
                                            MsgBox("Error al insertar datos en ECDetVenta. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECDetVenta, ECVentaDete y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                                            Return False
                                        End Try
                                    Catch ex4 As Exception
                                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                                        Return False
                                    End Try
                                Catch ex3 As Exception
                                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                                    Return False
                                End Try
                            Catch ex2 As Exception
                                MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta. No pudo borrarse información de ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                                Return False
                            End Try
                        End Try



                        'sSql = "select * from ecpromopuntos where prom_articulo='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
                        'Base.daQuery(sSql, sCadenaConexionSQL, dsc, "promo")
                        'If dsc.Tables("promo").Rows.Count > 0 Then
                        '    sSql = "insert into eccanjepuntos (canje_ticket,canje_fecha,canje_renglon,canje_articulo,canje_cantidad,canje_puntos,canje_usados,canje_saldo) " &
                        '        " values (" & iID & ",getdate()," & xrenglon & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & cant & "," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ",0," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ")" 'serie
                        '    sipuntos = True
                        '    Base.Ejecuta(sSql, sCadenaConexionSQL)
                        '    xrenglon = xrenglon + 1

                        'End If
                        'dsc.Tables.Remove("promo")
                    End With
                Next iRen
            End If

            dsc2.Tables.Remove("detventa")


            '-----------------------------------------------------------------------------
            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASDETALLADAS ECVENTADET
            sql = "SELECT * FROM TMPAUXVTA1  where tmp_usuario='" & Globales.caja & "'"
            Try
                Base.daQuery(sql, sCadenaConexionSQL, dsc2, "detventa")
            Catch ex As Exception
                Try
                    Base.Ejecuta("delete from ecdetventa where dve_venta=" & xven, sCadenaConexionSQL)
                    Try
                        Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, sCadenaConexionSQL)
                        Try
                            Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", sCadenaConexionSQL)
                            Try
                                Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                Try
                                    Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                    MsgBox("Error al traer los datos de TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                                    Return False
                                Catch ex6 As Exception
                                    MsgBox("Error al traer los datos de TmpAuxVta1. No pudo borrarse información de TmpAuxVta, sólo de ECDetVenta, ECVentaDete, ECVenta y TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
                                    Return False
                                End Try
                            Catch ex5 As Exception
                                MsgBox("Error al traer los datos de TmpAuxVta1. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECDetVenta, ECVentaDete y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                                Return False
                            End Try
                        Catch ex4 As Exception
                            MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                            Return False
                        End Try
                    Catch ex3 As Exception
                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                        Return False
                    End Try
                Catch ex2 As Exception
                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1. No pudo borrarse información de ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                    Return False
                End Try
            End Try


            If dsc2.Tables("detventa").Rows.Count > 0 Then
                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
                    sSql = "insert into ecventadet (dve_venta,dve_articulo,dve_upc,dve_precio,dve_cantidad,dve_total,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon,DVE_FALTINV,FueConF1,FueConF2,FueConF3, DVE_PORIEPS, DVE_IEPS) "
                    sSql &= "values (" & iID & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" & 'serie
                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) & "," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & "," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) &
                     "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) & "," &
                     ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0 &
                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) & "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_FAMILIA") & "'," & iRen + 1 & ",0," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF1") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF2") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF3") & '")" &
                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) & "," &
                    ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0 &
                    ")"
                    Try
                        Base.Ejecuta(sSql, sCadenaConexionSQL)
                    Catch ex As Exception
                        Try
                            Base.Ejecuta("delete from ecventadet where dve_venta=" & xven, sCadenaConexionSQL)
                            Try
                                Base.Ejecuta("delete from ecdetventa where dve_venta=" & xven, sCadenaConexionSQL)
                                Try
                                    Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, sCadenaConexionSQL)
                                    Try
                                        Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", sCadenaConexionSQL)
                                        Try
                                            Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                            Try
                                                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                                                MsgBox("Error al registrar la información en ECVentaDet. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                                                Return False
                                            Catch ex7 As Exception
                                                MsgBox("Error al registrar la información en ECVentaDet. No pudo borrarse información de TmpAuxVta, sólo de ECVentaDet, ECDetVenta, ECVentaDete, ECVenta y TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
                                                Return False
                                            End Try
                                        Catch ex6 As Exception
                                            MsgBox("Error al registrar la información en ECVentaDet. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECVentaDet, ECDetVenta, ECVentaDete y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                                            Return False
                                        End Try
                                    Catch ex5 As Exception
                                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECVentaDet, ECDetVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
                                        Return False
                                    End Try
                                Catch ex4 As Exception
                                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECVentaDet, ECDetVenta.", MsgBoxStyle.Critical, "Punto de Venta")
                                    Return False
                                End Try
                            Catch ex3 As Exception
                                MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECVentaDet.", MsgBoxStyle.Critical, "Punto de Venta")
                                Return False
                            End Try
                        Catch ex2 As Exception
                            MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECVentaDet, ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                            Return False
                        End Try
                    End Try



                    sSql = "EXEC CARGAEST  " & "'" &
                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" &
                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))

                    'Base.Ejecuta(sSql, sCadenaConexionSQL)

                Next iRen

            End If
            dsc2.Tables.Remove("DETVENTA")           '----------------------------------------------------------------------------

            sql = "exec aplicaventainventario " & iID & ",1" 'serie
            Try
                Base.Ejecuta(sql, sCadenaConexionSQL)
            Catch ex As Exception
                MsgBox("Error en Procedimiento AplicaVentaInventario. Se requerirá recálculo.", MsgBoxStyle.Critical, "Punto de Venta")
            End Try


            'dsc.Tables.Remove("maximo")
        Catch ex As Exception
            'Esto es más relevante, no se pudo insertar en ECVenta, aun aSí, no hay gravedad. Solo reintentar.
            Try
                Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                Try
                    Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", sCadenaConexionSQL)
                    MsgBox("Error al registrar la información en ECVenta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
                    Return False
                Catch ex2 As Exception
                    MsgBox("Error al registrar la información en ECVenta. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
                    Return False
                End Try
            Catch ex3 As Exception
                MsgBox("Error al registrar la información en ECVenta. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
                Return False
            End Try
        End Try
        Return True
    End Function

    Public Structure ResultadoTicket
        Public Exito As Boolean
        Public Mensaje As String

        ' Banderas de fallo para depuración
        Public FalloTmp As Boolean
        Public FalloHeader As Boolean
        Public FalloDetalle As Boolean
    End Structure

    Public Function GuardaTicketConHandler(FolioCaja As String) As (Mensaje As String, TmpAuxVta As Boolean, TmpAuxVta1 As Boolean, ECVenta As Boolean, LigasFolios As Boolean, ECVentaDete As Boolean, ECVentaDet As Boolean, ECDetVenta As Boolean)
        Dim iRen As Integer = 0
        Dim sSql As String = ""
        Dim xsql As String = ""
        Dim dsc As New DataSet
        Dim dsc1 As New DataSet
        Dim iID As Integer
        Dim iva, IEPS As Double
        Dim familia As String
        Dim costo As Double
        Dim precio As Double
        Dim cant As Double
        Dim DATO As String
        Dim sql As String
        Dim dsc2 As New DataSet
        Dim dsc3 As New DataSet
        Dim dsc4 As New DataSet
        'Dim cap1 As Double
        'Dim cap2 As Double
        'Dim uni1 As String
        'Dim uni2 As String
        Dim xrenglon As Integer


        'xven = 0
        'sql = "select isnull(folio,0)+1 maximo from eccontrolventa"
        'Base.daQuery(sql, sCadenaConexionSQL, dsc, "tabla")
        'xven = dsc.Tables("tabla").Rows(0)("maximo")
        'Base.Ejecuta("update eccontrolventa set folio=folio+1", sCadenaConexionSQL)


        DATO = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)

        'Para generar el consolidado del ticket
        Try
            Base.Ejecuta("DELETE FROM TMPAUXVTA WHERE TMP_USUARIO='" & Globales.caja & "'", sCadenaConexionSQL)
        Catch ex As Exception
            Return ("Error al borrar los datos de tabla TmpAuxVta" & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), False, False, False, False, False, False, False)
        End Try

        With FpArticulos.ActiveSheet
            'REGISTRA LOS MOVIMIENTOS 
            For i As Integer = 0 To .RowCount - 1
                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .cells(i, colupcinv).Text.Trim & "'"
                'Base.daQuery(sql, sCadenaConexionSQL, dsc3, "codart")
                'If dsc3.Tables("codart").Rows.Count > 0 Then
                'sql = "select * from tmpauxvta where tmp_articulo='" & dsc3.Tables("codart").Rows(0)("upc_cveart") & "' and tmp_usuario='" & Globales.caja & "'"
                sql = "select * from tmpauxvta where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Try
                    Base.daQuery(sql, sCadenaConexionSQL, dsc2, "impri")
                Catch ex As Exception
                    Return ("Error al traer los datos de tabla TmpAuxVta." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
                End Try

                If dsc2.Tables("impri").Rows.Count > 0 Then
                    sql = "UPDATE TMPAUXVTA SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, ColVenta.ColCantidad).Value &
                                " ,TMP_TOTAL=TMP_TOTAL+" & .Cells(i, ColVenta.ColTotal).Value & " where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Else
                    sql = "INSERT INTO TMPAUXVTA SELECT '" & Globales.caja & "'," & .Cells(i, ColVenta.ColCantidad).Value & ",'" & .Cells(i, ColVenta.ColArtClave).Text.Trim &
                            "','" & .Cells(i, ColVenta.ColNomLargo).Text.Trim & "'," & .Cells(i, ColVenta.ColPrecio).Value & "," & .Cells(i, ColVenta.ColTotal).Value & "," & .Cells(i, ColVenta.ColFIVA).Value & "," & .Cells(i, ColVenta.ColFIEPS).Value & ",'" & .Cells(i, ColVenta.ColFamilia).Value & "'," & .Cells(i, ColVenta.ColCostoCap).Value '& "," & .Cells(i, ColVenta.ColPrecio1).Value
                End If
                Try
                    Base.Ejecuta(sql, sCadenaConexionSQL)
                Catch ex As Exception
                    dsc2.Tables.Remove("impri")
                    Return ("Error al registrar la información en tabla TmpAuxVta." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
                End Try
                dsc2.Tables.Remove("impri")
                'End If
                'dsc3.Tables.Remove("codart")
            Next i
        End With


        'PARA GENERAR UN CONSOLIDADO DE VENTAS SIN LAS CANCELACIONES QUE SE REGISTRARON

        Try
            Base.Ejecuta("DELETE FROM TMPAUXVTA1 WHERE TMP_USUARIO='" & Globales.caja & "'", sCadenaConexionSQL)
        Catch ex As Exception
            Return ("Error al borrar los datos de tabla TmpAuxVta1." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
        End Try

        With FpArticulos.ActiveSheet
            'REGISTRA LOS MOVIMIENTOS 
            For i As Integer = 0 To .RowCount - 1
                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .cells(i, colupcinv).Text.Trim & "'"
                'Base.daQuery(sql, sCadenaConexionSQL, dsc3, "codart")
                'If dsc3.Tables("codart").Rows.Count > 0 Then
                sql = "select * from tmpauxvta1 where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "'" &
                    " AND TMP_UPC='" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Try
                    Base.daQuery(sql, sCadenaConexionSQL, dsc2, "impri")
                Catch ex As Exception
                    Return ("Error al traer los datos de tabla TmpAuxVta1." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
                End Try

                If dsc2.Tables("impri").Rows.Count > 0 Then
                    sql = "UPDATE TMPAUXVTA1 SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, ColVenta.ColCantidad).Value &
                        " ,TMP_TOTAL=TMP_TOTAL+" & .Cells(i, ColVenta.ColTotal).Value &
                        IIf(.Cells(i, ColVenta.ColF1).Value = dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=FueConF1", IIf(.Cells(i, ColVenta.ColF1).Value > dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=" & .Cells(i, ColVenta.ColF1).Value, "")) &
                        IIf(.Cells(i, ColVenta.ColF2).Value = dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=FueConF2", IIf(.Cells(i, ColVenta.ColF2).Value > dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=" & .Cells(i, ColVenta.ColF2).Value, "")) &
                        IIf(.Cells(i, ColVenta.ColF3).Value = dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=FueConF3", IIf(.Cells(i, ColVenta.ColF3).Value > dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=" & .Cells(i, ColVenta.ColF3).Value, "")) &
                        " where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "'" &
                        " AND TMP_UPC='" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
                Else
                    sql = "INSERT INTO TMPAUXVTA1 SELECT '" & Globales.caja & "'," & .Cells(i, ColVenta.ColCantidad).Value & ",'" & .Cells(i, ColVenta.ColArtClave).Text.Trim &
                    "','" & .Cells(i, ColVenta.ColNomLargo).Text.Trim & "'," & .Cells(i, ColVenta.ColPrecio).Value & "," & .Cells(i, ColVenta.ColTotal).Value & ",'" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "'," &
                     .Cells(i, ColVenta.ColFIVA).Text.Trim & ",0,'" &
                        .Cells(i, ColVenta.ColFamilia).Text.Trim & "'," & .Cells(i, ColVenta.ColF1).Value & "," & .Cells(i, ColVenta.ColF2).Value & "," & .Cells(i, ColVenta.ColF3).Value & "," & .Cells(i, ColVenta.ColFIEPS).Value & ",0," & .Cells(i, ColVenta.ColCostoCap).Value
                End If
                Try
                    Base.Ejecuta(sql, sCadenaConexionSQL)
                Catch ex As Exception
                    dsc2.Tables.Remove("impri")
                    Return ("Error al registrar la información en tabla TmpAuxVta1." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, True, False, False, False, False, False)
                End Try
                dsc2.Tables.Remove("impri")
                'End If
                'dsc3.Tables.Remove("codart")
            Next i
        End With

        If HayTarjeta Then
            SacaProporcionP1P2(xven)
        End If

        'MOFICACION PARA CAJAS FIJAS
        'PARA INSERTAR TOTALES EN ECVENTA
        Dim RestaCancelacionUPC As Double
        Dim TraeVale As Boolean
        TraeVale = False
        With FpArticulos.ActiveSheet
            For i As Integer = 0 To .RowCount - 1
                RestaCancelacionUPC = 0
                If .Cells(i, ColVenta.ColVale).Text = "*" Then
                    For k As Integer = 0 To .RowCount - 1
                        If k <> i Then
                            If .Cells(i, ColVenta.ColUPCInv).Text.Trim = .Cells(k, ColVenta.ColUPCInv).Text.Trim Then
                                If .Cells(k, ColVenta.ColCantidad).Text <> "" Then
                                    If IsNumeric(.Cells(k, ColVenta.ColCantidad).Value) Then
                                        If CDbl(.Cells(k, ColVenta.ColCantidad).Value) < 0 Then
                                            RestaCancelacionUPC += CDbl(.Cells(k, ColVenta.ColCantidad).Value)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next k

                    If .Cells(i, ColVenta.ColCantidad).Text <> "" Then
                        If IsNumeric(.Cells(i, ColVenta.ColCantidad).Value) Then
                            If CDbl(.Cells(i, ColVenta.ColCantidad).Value) + RestaCancelacionUPC > 0 Then
                                TraeVale = True
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next i
        End With

        sSql = "insert into ecventa (ven_id,ven_usuario,ven_fecha,ven_status,ven_total,ven_turno,ven_tipov,CORTE, NombreCajera, TraeVale) " 'Serie
        sSql &= "values (" & xven & ",'" & DATO & "',getDate(),1," & LbTotal.Text.Replace(",", "").Replace("$", "") + "," & Globales.iTurnoActivo & "," & TIPOVENTA & ",0,'" & Globales.NombreEmpleado & "','" & IIf(TraeVale, "*", "") & "')" 'Serie

        Try
            Base.Ejecuta(sSql, sCadenaConexionSQL)
            'sSql = "select max(ven_id) from ecventa where ven_usuario='" & DATO & "'"
            'Base.daQuery(sSql, sCadenaConexionSQL, dsc, "maximo")
            iID = xven
            numt = iID

            Try
                Base.Ejecuta("insert into LigasFolios values(" & xven & ",'" & FolioCaja & "')", sCadenaConexionSQL)
            Catch ex As Exception
                Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al registrar la información en LigasFolios.", True, True, True, False, False, False, False)
            End Try


            If estiempoaire Then
                sSql = "insert into ecdetventatel (dve_venta,dve_telefono,dve_fecha,dve_folio) "
                sSql &= "values (" & iID & ",'" & txt_ctel1.Text & "-" & txt_ctel2.Text & "-" & txt_ctel3.Text & "-" & txt_ctel4.Text & "',getdate(),0)" 'serie
                Base.Ejecuta(sSql, sCadenaConexionSQL)
            End If

            '-----------------------------------------------------------------------------
            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASTICKET ECDETVENTA

            With FpArticulos.ActiveSheet
                'REGISTRA LOS MOVIMIENTOS 
                For i As Integer = 0 To .RowCount - 1
                    RestaCancelacionUPC = 0
                    If .Cells(i, ColVenta.ColVale).Text = "*" Then
                        For k As Integer = 0 To FpArticulos.ActiveSheet.Rows.Count - 1
                            If k <> i Then
                                If .Cells(i, ColVenta.ColUPCInv).Text.Trim = .Cells(k, ColVenta.ColUPCInv).Text.Trim Then
                                    If .Cells(k, ColVenta.ColCantidad).Text <> "" Then
                                        If IsNumeric(.Cells(k, ColVenta.ColCantidad).Value) Then
                                            If CDbl(.Cells(k, ColVenta.ColCantidad).Value) < 0 Then
                                                RestaCancelacionUPC += CDbl(.Cells(k, ColVenta.ColCantidad).Value)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next k
                        If .Cells(i, ColVenta.ColCantidad).Text <> "" Then
                            If IsNumeric(.Cells(i, ColVenta.ColCantidad).Value) Then
                                If CDbl(.Cells(i, ColVenta.ColCantidad).Value) > 0 Then
                                    'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .cells(i, colupcinv).Text.Trim & "'"
                                    'Base.daQuery(sql, sCadenaConexionSQL, dsc3, "codart1")
                                    'If dsc3.Tables("codart1").Rows.Count > 0 Then
                                    If CDbl(.Cells(i, ColVenta.ColCantidad).Value) + RestaCancelacionUPC > 0 Then
                                        sql = "INSERT INTO ECVENTADETE SELECT " & iID & ",'" & 'Serie
                                            .Cells(i, ColVenta.ColArtClave).Text.Trim & "','" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "'," & .Cells(i, ColVenta.ColCantidad).Value + RestaCancelacionUPC & "," &
                                        .Cells(i, ColVenta.ColPrecio).Value & "," & .Cells(i, ColVenta.ColTotal).Value
                                        Try
                                            Base.Ejecuta(sql, sCadenaConexionSQL)
                                        Catch ex As Exception
                                            Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDete.", True, True, True, True, True, False, False)
                                        End Try
                                    End If
                                    'End If
                                    'dsc3.Tables.Remove("codart1")
                                End If
                            End If
                        End If
                    End If
                Next i
            End With

            Try
                sql = "Select * from tmpauxvta where tmp_usuario='" & Globales.caja & "'"
                Base.daQuery(sql, sCadenaConexionSQL, dsc2, "detventa")
            Catch ex As Exception
                Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al traer los datos de tabla TmpAuxVta.", True, True, True, True, True, False, False)
            End Try


            xrenglon = 1
            If dsc2.Tables("detventa").Rows.Count > 0 Then

                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
                    With FpArticulos.ActiveSheet
                        'xsql = "Select art_iva,art_ieps,art_costocap2,art_familia,art_cap1,art_uni1,art_cap2,art_uni2 from articulo where art_clave='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
                        'Base.daQuery(xsql, sCadenaConexionSQL, dsc1, "precios")
                        If .Cells(iRen, ColVenta.ColArtClave).Text.Trim <> "" Then
                            iva = dsc2.Tables("detventa").Rows(iRen)("tmp_iva")
                            IEPS = dsc2.Tables("detventa").Rows(iRen)("tmp_ieps")
                            costo = dsc2.Tables("detventa").Rows(iRen)("tmp_costo")
                            familia = dsc2.Tables("detventa").Rows(iRen)("tmp_familia")
                            'cap1 = dsc1.Tables("precios").Rows(0)("art_cap1")
                            'cap2 = dsc1.Tables("precios").Rows(0)("art_cap2")
                            'uni1 = dsc1.Tables("precios").Rows(0)("art_uni1")
                            'uni2 = dsc1.Tables("precios").Rows(0)("art_uni2")
                        Else
                            iva = 0
                            IEPS = 0
                            costo = 0
                            familia = 0
                            'cap1 = 1
                            'cap2 = 1
                            'uni1 = "PZ"
                            'uni2 = "PZ"
                        End If
                        'dsc1.Tables.Remove("precios")
                        precio = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_precio"))
                        cant = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_cantidad"))


                        sSql = "insert into ecdetventa (dve_venta,dve_articulo,dve_precio,dve_cantidad,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon, DVE_PORIEPS, DVE_IEPS) "
                        sSql &= "values (" & iID & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & precio & "," & cant & "," & 'serie
                         iva & "," & ((precio * cant) / (1 + (iva / 100.0))) * iva / 100 & "," & costo & "," & cant * costo & ",'" & familia & "'," & iRen + 1 & "," & IEPS & "," & ((precio * cant) / (1 + (IEPS / 100))) * IEPS / 100 & ")"
                        Try
                            Base.Ejecuta(sSql, sCadenaConexionSQL)
                        Catch ex As Exception
                            dsc2.Tables.Remove("detventa")
                            Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta.", True, True, True, True, True, True, False)
                        End Try



                        'sSql = "select * from ecpromopuntos where prom_articulo='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
                        'Base.daQuery(sSql, sCadenaConexionSQL, dsc, "promo")
                        'If dsc.Tables("promo").Rows.Count > 0 Then
                        '    sSql = "insert into eccanjepuntos (canje_ticket,canje_fecha,canje_renglon,canje_articulo,canje_cantidad,canje_puntos,canje_usados,canje_saldo) " &
                        '        " values (" & iID & ",getdate()," & xrenglon & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & cant & "," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ",0," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ")" 'serie
                        '    sipuntos = True
                        '    Base.Ejecuta(sSql, sCadenaConexionSQL)
                        '    xrenglon = xrenglon + 1

                        'End If
                        'dsc.Tables.Remove("promo")
                    End With
                Next iRen
            End If

            dsc2.Tables.Remove("detventa")


            '-----------------------------------------------------------------------------
            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASDETALLADAS ECVENTADET
            sql = "SELECT * FROM TMPAUXVTA1  where tmp_usuario='" & Globales.caja & "'"
            Try
                Base.daQuery(sql, sCadenaConexionSQL, dsc2, "detventa")
            Catch ex As Exception
                Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1.", True, True, True, True, True, True, False)
            End Try


            If dsc2.Tables("detventa").Rows.Count > 0 Then
                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
                    sSql = "insert into ecventadet (dve_venta,dve_articulo,dve_upc,dve_precio,dve_cantidad,dve_total,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon,DVE_FALTINV,FueConF1,FueConF2,FueConF3, DVE_PORIEPS, DVE_IEPS) "
                    sSql &= "values (" & iID & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" & 'serie
                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) & "," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & "," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_TOTAL")) &
                     "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) & "," &
                     ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0 &
                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) & "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_FAMILIA") & "'," & iRen + 1 & ",0," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF1") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF2") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF3") & '")" &
                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) & "," &
                    ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0 &
                    ")"
                    Try
                        Base.Ejecuta(sSql, sCadenaConexionSQL)
                    Catch ex As Exception
                        Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet.", True, True, True, True, True, True, True)
                    End Try



                    sSql = "EXEC CARGAEST  " & "'" &
                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" &
                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))

                    'Base.Ejecuta(sSql, sCadenaConexionSQL)

                Next iRen

            End If
            dsc2.Tables.Remove("DETVENTA")           '----------------------------------------------------------------------------


            Try
                sql = "exec aplicaventainventario " & iID & ",1" 'serie
                Base.Ejecuta(sql, sCadenaConexionSQL)
            Catch ex As Exception
                MsgBox("Error en Procedimiento AplicaVentaInventario." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Se requerirá recálculo.", MsgBoxStyle.Critical, "Punto de Venta")
            End Try


            'dsc.Tables.Remove("maximo")
        Catch ex As Exception
            'Esto es más relevante, no se pudo insertar en ECVenta, aun aSí, no hay gravedad. Solo reintentar.
            Return ("Error al registrar la información en ECVenta." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, True, False, False, False, False, False)
        End Try
        Return ("OK", False, False, False, False, False, False, False)
    End Function

    Public Sub imprimeTicket(ByRef pre As Collection, ByVal FolioTicket As String)
        Dim oImpresion As Impresion
        oImpresion = New Impresion(pre, FolioTicket)
        oImpresion.imprime(True)
    End Sub

    'Public Sub imprimevirtual(ByRef pre As Collection)
    '    Dim oImpresion As Impresionvirtual
    '    oImpresion = New Impresionvirtual(pre)
    '    oImpresion.imprime()
    'End Sub

    Public Sub imprimetaire(ByRef pre As Collection)
        Dim oImpresion As imptaire
        oImpresion = New imptaire(pre)
        oImpresion.imprime()
    End Sub


    Public Sub limpiaSpread(ByVal Optional CerrandoVenta As Boolean = False, ByVal Optional CambiandoTipoVenta As Boolean = False)
        Dim SQL As String

        With FpArticulos.ActiveSheet
            .RowCount = 0
        End With
        With FpFormasPago.ActiveSheet
            .RowCount = 0
        End With

        TxtControl.Text = "0"
        LbClienteTicket.Text = "Cliente: Público en General"
        Me.pBoxF1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477097_avatar_78580
        LbF1.Text = "F1 - Ligar Venta a Cliente"

        PanelCancelaciones.Visible = False
        ListBox1.Items.Clear()

        VentaCajaVirtual = False
        TX_UPC.BackColor = Color.White

        grformapago.Visible = False
        TotalVenta = 0D
        TotalPago = 0D
        TX_TOTALPAGO.Text = ""
        LbTotal.Text = ""
        sCant = ""
        claveArt = ""
        totalpagos = 0
        TotalComision = 0
        HayTarjeta = False
        Dim Entra As Boolean = True
        If CerrandoVenta Then
            Entra = True
        End If
        If CambiandoTipoVenta OrElse CerrandoVenta = False Then
            Entra = BuscaVenta(CambiandoTipoVenta)
            Entra = IIf(Entra, False, True)
        End If


        If Entra Then
            SQL = "DELETE FROM " & Globales.caja & " "
            Base.Ejecuta(SQL, sCadenaConexionSQL)
            SQL = "delete from tmpauxvta2 where usuario='" & Globales.caja & "'"
            Base.Ejecuta(SQL, sCadenaConexionSQL)
            TIPOVENTA = 1
            txt_tipoventa.Text = "1"
            txt_tipoventa.Focus()
            Me.pBoxF1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477097_avatar_78580
            LbF1.Text = "F1 - Ligar Venta a Cliente"
        End If




    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim autorizado As Boolean
        Dim oforma1 As Form

        oforma1 = New paraautorizarSALIDA(Me, autorizado)
        oforma1.Top = (Me.Height / 2 - oforma1.Height / 2)
        oforma1.Left = (Me.Width / 2 - oforma1.Width / 2)
        oforma1.BringToFront()
        oforma1.ShowDialog()
    End Sub

    Dim contando As Integer
    Dim iren As Integer


    Public Sub TX_UPC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TX_UPC.KeyDown
        Dim i As Integer

        Dim forma As Form
        Dim autor As Form
        Dim TOPE As Double
        Dim cve As String
        Dim nomlargo As String
        Dim precio As Double
        Dim sql As String = ""
        Dim dsc As New DataSet
        Dim recorre As Integer

        Dim k As Integer
        Dim PRECIO1 As Double
        Dim ANTERIOR As Double
        Dim xtipo As Integer
        Dim cantidad As Double
        Dim upcbusqueda As String
        Dim totpzas As Double
        Dim sql2 As String
        Dim errorcode As Integer
        Dim iva As Integer
        Dim VENT As New VENTANITA("¿Desea cancelar el Articulo?", "BORRAR")
        Dim xcve As String

        If ModifierKeys <> ModifierKeys.None Then
            Exit Sub
        End If

        If (e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F4) And FpArticulos.ActiveSheet.RowCount <= 0 Then
            Exit Sub
        End If

        If e.KeyCode = Keys.End Then
            If grformapago.Visible = False Then
                FpArticulos.ActiveSheet.ActiveRowIndex = FpArticulos.ActiveSheet.RowCount - 1
                FpArticulos.Focus()
            End If
        End If

        If e.KeyCode = Keys.Home Then
            If FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColCantidad).Value > 0 Then
                If FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = "*" Then
                    MsgBox("Se Registro el Artículo como entregado en caja", MsgBoxStyle.Information)
                    FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = ""
                Else
                    MsgBox("Se Registro el Artículo para entrega de Producto", MsgBoxStyle.Information)
                    FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = "*"
                End If
                sql = "update TMPAUXVTA2 set TraeVale='" & FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value & "' where usuario='" & Globales.caja & "' and Renglon=" & FpArticulos.ActiveSheet.RowCount - 1
                Try
                    Base.Ejecuta(sql, sCadenaConexionSQL)
                Catch ex As Exception
                    MsgBox("Error al actualizar Vale en TmpAuxVta2." & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Punto de Venta")
                End Try
                segundoticket = True
                TX_UPC.Focus()
            Else
                FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = ""
            End If
        End If



        If e.KeyCode = Keys.PageDown Then
            System.Diagnostics.Process.Start("C:\WINDOWS\system32\calc.exe")
        End If

        If e.KeyCode = Keys.Escape Then
            Me.TX_UPC.Text = ""
            cancelacion = False
            busqueda.Visible = False
            l_cancelacion.Visible = False
            buscararticulo = False
            If FpArticulos.ActiveSheet.RowCount = 0 Then
                Me.txt_tipoventa.Enabled = True
                TxtControl.Text = "0"
                LbClienteTicket.Text = "Cliente: Público en General"
                Me.pBoxF1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477097_avatar_78580
                LbF1.Text = "F1 - Ligar Venta a Cliente"
                Me.txt_tipoventa.Focus()
                txt_tipoventa.SelectionStart = 0
                txt_tipoventa.SelectionLength = txt_tipoventa.Text.Length
                Exit Sub
            End If

        End If


        If e.KeyCode = Keys.Enter And Not formaspago And TX_UPC.Text <> "" Then
            ProcAgregaArticulo()
        End If


        If Not PERMISOVENDER Then
            PERMISOVENDER = True
            formaspago = False
        End If

        If e.KeyCode = Keys.Escape AndAlso formaspago Then
            borrapagos()
            SendKeys.Flush()
        ElseIf e.KeyCode = Keys.Escape And Not formaspago Then
            If Me.FpArticulos.ActiveSheet.RowCount = 0 And e.KeyCode = Keys.Escape Then
                Me.txt_tipoventa.Focus()
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.F1 And Not formaspago Then
            buscararticulo = True
            Me.busqueda.Visible = True

            ' buscar articulo //listo
        End If
        'cancelacion de artikulos
        If e.KeyCode = Keys.F2 And Not formaspago Then
            cancelacion = True
            Me.l_cancelacion.Visible = True
        End If

        If e.KeyCode = Keys.F3 And Not formaspago Then  '  multiplicacion por cantidad //listo
            F3Cantidad = True
            TX_UPC.Enabled = False
            Me.l_cantidad.Visible = True
            tx_cantidad.Visible = True
            tx_cantidad.Text = ""
            tx_cantidad.Focus()

        End If
        If e.KeyCode = Keys.F4 And Not formaspago And totalote > 0 Then
            'fin de venta           
            lcambio.Text = totalote.ToString("C2")
            grformapago.BringToFront()
            grformapago.Top = (Me.Height / 2 - grformapago.Height / 2)
            grformapago.Left = (Me.Width / 2 - grformapago.Width / 2)
            grformapago.Visible = True

            formaspago = True
        End If

        'Modo Caja Virtual
        If e.KeyCode = Keys.F6 AndAlso Not formaspago Then
            'Activar Modo "Vender Caja Virtual"            
            VentaCajaVirtual = Not VentaCajaVirtual
            ToggleCajaVirtual()

        End If
        'para pago en efectivo
        If e.KeyCode = Keys.F5 And formaspago Then
            tx_cantidad.Text = ""
            Me.LFORPAG.Visible = True
            Me.LFORPAG.Text = "Efectivo"
            tx_cantidad.Visible = True
            fpago = 1
            TX_UPC.Enabled = False
            tx_cantidad.Focus()
        End If

        'para pago en vales
        If e.KeyCode = Keys.F6 And formaspago Then
            If False Then
                Me.LFORPAG.Visible = True
                Me.LFORPAG.Text = "Vales"
                tx_cantidad.Text = ""
                tx_cantidad.Visible = True
                fpago = 2
                TX_UPC.Enabled = False
                tx_cantidad.Focus()
            Else
                MsgBox("Ya no aceptamos Vales de Despensa", vbExclamation, "Punto de Venta")

            End If
        End If

        'pago chekes
        If e.KeyCode = Keys.F7 And formaspago Then
            Label18.Text = "Referencia:"
            autorizame = True

            Me.LFORPAG.Text = "Cheque"
            Me.LFORPAG.Visible = True
            tx_cantidad.Text = ""
            banco.Visible = True
            fpago = 3
            TX_UPC.Enabled = False
            Me.TXB_BANCO.Focus()
        End If


        'pago transferencias
        If e.KeyCode = Keys.End And formaspago Then
            Label18.Text = "TITULAR BANCO Y FOLIO"
            autorizame = True

            Me.LFORPAG.Text = "Transfer"
            Me.LFORPAG.Visible = True
            tx_cantidad.Text = ""
            banco.Visible = True
            fpago = 7
            TX_UPC.Enabled = False
            Me.TXB_BANCO.Focus()
        End If

        'pago credito
        If e.KeyCode = Keys.F8 And formaspago Then
            Me.LFORPAG.Text = "Crédito"
            Me.LFORPAG.Visible = True
            tx_cantidad.Text = ""
            txb_credito.Text = ""
            txb_credito1.Text = ""
            credito.Visible = True
            fpago = 4
            TX_UPC.Enabled = False
            txb_credito.Focus()
            pagare = True
            autorizame = True

        End If

        If e.KeyCode = Keys.F9 And formaspago Then
            If Round((totalote - totalpagos) * IIf(TIPOVENTA > 1, 1.02, 1), 2) > 0 Then
                TX_UPC.Enabled = False
                PanelSeleccionTarjetas.Left = Me.Width / 2 - PanelSeleccionTarjetas.Width / 2
                PanelSeleccionTarjetas.Top = Me.Height / 2 - PanelSeleccionTarjetas.Height / 2
                rbTCredito.Checked = False
                rbTDebito.Checked = False
                TipoTarj = ""
                lbFila.Text = FpFormasPago.ActiveSheet.Rows.Count
                PanelSeleccionTarjetas.Visible = True
                PanelSeleccionTarjetas.BringToFront()
                rbTDebito.Focus()
            Else
                MsgBox("El Monto pagado hasta el momento ya salda el ticket.", vbExclamation, "Monto Incorrecto")
                LFORPAG.Visible = False
                tx_cantidad.Text = ""
                tx_cantidad.Visible = False
                TXB_BANCO.Text = ""
                TX_UPC.Enabled = True
                TX_UPC.Text = ""
                TX_UPC.Focus()
            End If
        End If

        If e.KeyCode = Keys.F10 And formaspago Then

            If Math.Round(totalote, 2) > Math.Round(totalpagos, 2) Then
                MsgBox("Cantidad de pago incorrecto", MsgBoxStyle.Critical)
                SendKeys.Flush()
                Me.TX_UPC.Focus()
            Else
                Dim motivos = ObtenerMotivosAutorizacion()
                If motivos.Count > 0 Then
                    'Sí hay motivos: llenar panel/listbox
                    Using xConLocal As New SqlConnection(Globales.sCadenaConexionSQL)
                        Dim auth As FingerprintAuthResult = AutorizacionConHuella.PromptFingerprint(xConLocal, "Supervisor", -1, Me, motivos:=motivos)
                        If auth.Approved Then
                            RegistroHistorial.HistorialAutorizaciones(xConLocal, My.Computer.Name, auth.UserName, -1, "Devolución", "Devolución de Mercancía")
                        Else
                            Exit Sub
                        End If
                    End Using
                End If

                For iren = 0 To FpFormasPago.ActiveSheet.RowCount - 1
                    If FpFormasPago.ActiveSheet.Cells(iren, 0).Value Is Nothing Then Continue For
                    Dim TipoPago As String = LTrim(RTrim(FpFormasPago.ActiveSheet.Cells(iren, 0).Text))
                    Dim TipoTarjetaStr As String = LTrim(RTrim(FpFormasPago.ActiveSheet.Cells(iren, 3).Text.ToUpper))
                    If TipoPago = "Tarjeta" AndAlso Not (TipoTarjetaStr <> "Crédito" OrElse TipoTarjetaStr <> "Débito") Then
                        MsgBox("Debe seleccionar el tipo de tarjeta.", vbExclamation, "Tipo Tarjeta")
                        FpFormasPago.ActiveSheet.RemoveRows(iren, 1)
                        sumapagos()
                        Exit Sub
                    End If
                Next
                forma = New FrCambio(Me)
                forma.Top = (Me.Height / 2 - forma.Height / 2)
                forma.Left = 0
                forma.BringToFront()
                forma.ShowDialog()
                'forma.Show()
                SendKeys.Flush()
                datostel = False
                txt_ctel1.Text = ""
                txt_ctel2.Text = ""
                txt_ctel3.Text = ""
                txt_ctel4.Text = ""

                txt_tel1.Text = ""
                txt_tel2.Text = ""
                txt_tel3.Text = ""
                txt_tel4.Text = ""
                estiempoaire = False
                claveprod = ""

                'MsgBox("casi termino", MsgBoxStyle.Exclamation)
                sql2 = "select id, articulo,fechaini, descoferta, fechafin from ecboletinofer where ETIQCAMB=1 AND fechafin<'" & Format(Today, "yyyyMMdd") & "'"
                Base.daQuery(sql2, sCadenaConexionSQL, dsc, "tabla23")

                If dsc.Tables("tabla23").Rows.Count > 0 Then
                    panelofe.BringToFront()
                    panelofe.Top = (Me.Height / 2 - panelofe.Height / 2)
                    panelofe.Left = (Me.Width / 2 - panelofe.Width / 2)
                    panelofe.Visible = True
                    LbIDOferta.Text = dsc.Tables("tabla23").Rows(i)("ID")
                    '   MsgBox("casi termino  adasdas", MsgBoxStyle.Exclamation)
                    txt_panelofe.Text = ""
                    For i = 0 To dsc.Tables("tabla23").Rows.Count - 1
                        txtnotifica.Text = txtnotifica.Text & " " & dsc.Tables("tabla23").Rows(i)("DescOferta") & " vencida desde " & dsc.Tables("tabla23").Rows(i)("fechafin")
                    Next
                    dsc.Tables.Remove("TABLA23")
                    txt_panelofe.Focus()
                Else
                    dsc.Tables.Remove("TABLA23")
                    Me.txt_tipoventa.Focus()
                End If
            End If

        End If

        ''End If


        If e.KeyCode = Keys.F11 Then
            forma = New Devoluciones(sCadenaConexionSQL)
            forma.BringToFront()
            forma.ShowDialog()
            SendKeys.Flush()
            Exit Sub
        End If


        If e.KeyCode = Keys.F12 Then
            Dim xforma As New Form
            xforma = New parafacturar(Me)
            xforma.BringToFront()
            xforma.ShowDialog()
            Me.Close()



            'forma = New TICKETS(xCon, Me)
            'forma.Top = (Me.Height / 2 - forma.Height / 2)
            'forma.Left = (Me.Width / 2 - forma.Width / 2)
            'forma.BringToFront()
            'forma.ShowDialog()
            'SendKeys.Flush()
            'Exit Sub
        End If
    End Sub

    Private Function RecorreSpread(ByVal UPCUPC As String, ByVal cantidad As Decimal, ByVal CancelandoConF3 As Boolean) As Boolean

        ' 1. SI ES UNA VENTA (Cantidad Positiva) -> ¡SIEMPRE PASE USTED!
        ' No nos importa si el grid está vacío o lleno. Si estás vendiendo, 
        ' RecorreSpread no debe estorbar. El trabajo de juntar repetidos lo hará agregaArticulo.
        If cantidad >= 0 Then
            Return True
        End If

        ' =========================================================
        ' A PARTIR DE Aquí, SOLO Lógica DE Cancelación (Cantidad Negativa)
        ' =========================================================

        ' Si el carro está vacío y quieres cancelar -> BLOQUEO
        If FpArticulos.ActiveSheet.RowCount = 0 Then
            MsgBox("No puede cancelar productos de una venta vacía.", vbExclamation, "Error")
            Return False
        End If

        Dim totpzas As Decimal = 0D
        Dim Encontrado As Boolean = False
        Dim CantidadAbsoluta As Decimal = Math.Abs(cantidad)

        With FpArticulos.ActiveSheet
            For i As Integer = 0 To .RowCount - 1

                ' Si editamos con F3, ignoramos el renglón actual para no contar lo que estamos borrando
                If CancelandoConF3 AndAlso i = (.RowCount - 1) Then
                    Continue For
                End If

                ' Sumamos inventario histórico
                If .Cells(i, ColVenta.ColUPCInv).Text.Trim = UPCUPC Then
                    totpzas += CDec(.Cells(i, ColVenta.ColCantidad).Value)
                    Encontrado = True
                End If
            Next
        End With

        'cancelacion = False
        'Me.l_cancelacion.Visible = False

        ' VALIDACIÓN: ¿Alcanza el saldo para cubrir la Cancelación?
        If (totpzas - CantidadAbsoluta) >= 0 Then
            Return True
        Else
            ' Mensajes de Error (Solo salen porque cantidad es negativa)
            If CancelandoConF3 Then
                MsgBox("No puede devolver más cantidad de la que ha vendido.", vbExclamation, "Cantidad Inválida")
            ElseIf Encontrado Then
                MsgBox("La cantidad a cancelar excede lo vendido.", vbExclamation, "Cancelar")
            Else
                MsgBox("El producto no se encuentra registrado para Cancelación.", vbExclamation, "Cancelar")
            End If

            Return False
        End If

    End Function

    Private Sub tx_cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tx_cantidad.KeyDown

        ' 1. ESCAPE: Cancelar operación y limpiar
        If e.KeyCode = Keys.Escape Then
            If Lkilos.Visible Then

                With FpArticulos.ActiveSheet
                    Dim iRow As Integer = .RowCount - 1

                    ' Verificamos si el último renglón está en 0 (Esperando peso)
                    If iRow >= 0 Then
                        Dim CantidadActual As Decimal = CDec(.Cells(iRow, ColVenta.ColCantidad).Value)

                        If CantidadActual = 0 Then
                            ' ¡Sí! Es el renglón fantasma. Lo borramos.
                            .RemoveRows(iRow, 1)

                            ' también borramos de BD si agregaArticulo ya hizo el INSERT de 0
                            Dim SQLDel As String = "DELETE FROM tmpauxvta2 WHERE renglon=" & iRow & " AND usuario='" & Globales.caja & "'"
                            Base.Ejecuta(SQLDel, sCadenaConexionSQL)
                        End If
                    End If
                End With

                ' Limpiamos UI
                l_cantidad.Visible = False
                Lkilos.Visible = False
                tx_cantidad.Visible = False
                tx_cantidad.Text = ""

                TX_UPC.Enabled = True
                TX_UPC.Focus()

                ' Recalculamos por si acaso
                sumaSpread()

            ElseIf formaspago Then


            End If
            LimpiarYSalir()
            Exit Sub
        End If

        ' 2. ENTER: Procesar la acción
        If e.KeyCode = Keys.Enter Then

            ' VALIDACIÓN básicade Número (evita crashes)
            ' Permitimos operaciones matemáticas simples solo si NO es pago
            If Not formaspago AndAlso Not IsNumeric(tx_cantidad.Text) Then
                ' Intentar resolver operación matemática (ej. "2*5")
                Try
                    Dim dt As New DataTable()
                    Dim result As Object = dt.Compute(tx_cantidad.Text, "")
                    tx_cantidad.Text = Convert.ToDecimal(result).ToString()
                Catch
                    MsgBox("Ingrese un valor numérico válido.", vbExclamation, "Atención")
                    tx_cantidad.SelectAll()
                    Exit Sub
                End Try
            ElseIf Not IsNumeric(tx_cantidad.Text) Then
                MsgBox("Ingrese un valor numérico.", vbExclamation, "Atención")
                Exit Sub
            End If

            ' === DIVISIÓN DE CAMINOS ===
            If formaspago Then
                ProcesarPago()
            Else
                ProcesarCambioCantidad()
            End If

        End If
    End Sub

    ' =================================================================================
    ' SUB-RUTINA 1: PROCESAR PAGOS (Caja, Tarjeta, Vales)
    ' =================================================================================
    Private Sub ProcesarPago()
        Dim MontoPagar As Decimal = CDec(tx_cantidad.Text)
        Dim NombrePago As String = ""

        ' 1. Definir Nombre del Pago
        Select Case fpago
            Case 1 : NombrePago = "Efectivo"
            Case 2 : NombrePago = "Vales"
            Case 3 : NombrePago = "Cheque"
            Case 4 : NombrePago = "Credito"
            Case 6 : NombrePago = "Tarjeta"
            Case 7 : NombrePago = "Transfer"
            Case Else : NombrePago = "Devolucion"
        End Select

        ' 2. Validaciones de Tope (No pagar más de lo que se debe)
        ' Solo validamos sobrepago si NO es efectivo (el efectivo da cambio)
        If fpago <> 1 Then
            Dim TotalPagado As Decimal = 0
            Dim TotalEfectivo As Decimal = 0

            ' Sumar pagos previos del Grid de Pagos
            For i As Integer = 0 To FpFormasPago.ActiveSheet.RowCount - 1
                Dim Tipo As String = FpFormasPago.ActiveSheet.Cells(i, 0).Text
                Dim Monto As Decimal = CDec(FpFormasPago.ActiveSheet.Cells(i, 1).Value)

                If Tipo = "Efectivo" Then
                    TotalEfectivo += Monto
                Else
                    TotalPagado += Monto
                End If
            Next

            ' VALIDACIÓN matemática
            Dim SaldoPendiente As Decimal = totalote - TotalPagado - TotalEfectivo
            ' Nota: Usamos una pequeña tolerancia de 0.01 por redondeos
            If (MontoPagar) > (SaldoPendiente + 0.05D) Then
                Dim Autorizado As Boolean = False

                ' 1. Preguntamos antes de bloquear
                If MsgBox("El pago excede el saldo pendiente. ¿Desea autorizarlo con clave de supervisor?",
                          vbQuestion + vbYesNo, "Pago Excedente") = MsgBoxResult.Yes Then

                    ' 2. Llamamos a tu ventana de Autorización
                    AutorizaCierreCambioVentana = False
                    ' Nota: Si no has agregado 'PagoExcedente' al New, quítalo y usa solo (Me, Nothing)
                    Using oforma1 As New paraautorizarSALIDA(Me, Nothing, PagandoExcedente:=True)
                        oforma1.StartPosition = FormStartPosition.CenterScreen
                        oforma1.ShowDialog()
                    End Using

                    If AutorizaCierreCambioVentana Then
                        Autorizado = True
                    End If
                End If

                ' 3. Si NO está autorizado (ya sea porque dijo No, o porque falló la clave)
                ' EJECUTAMOS TU Lógica ORIGINAL DE BLOQUEO
                If Not Autorizado Then
                    MsgBox("Con formas de pago distintas al efectivo, no puede exceder el monto del ticket.", vbExclamation, "Monto Incorrecto")
                    LimpiarYSalir()
                    Exit Sub
                End If
            End If
        End If

        ' 3. Validaciones de Referencia Bancaria
        Dim Referencia As String = ""
        If TXB_BANCO.Text = "" AndAlso (fpago = 6 Or fpago = 7 Or fpago = 3) Then
            MsgBox("Ingrese Referencia Bancaria.", vbExclamation, "Dato Faltante")
            TXB_BANCO.Focus()
            Exit Sub
        Else
            Referencia = TXB_BANCO.Text
        End If

        ' 4. Validaciones de Crédito
        If fpago = 4 Then
            If MontoPagar > acredito Then
                Dim f As New VENTANITA("Límite de Crédito insuficiente.", "Crédito Inválido")
                f.ShowDialog()
                LimpiarYSalir()
                Exit Sub
            End If
        End If

        ' 5. AGREGAR AL GRID DE PAGOS
        With FpFormasPago.ActiveSheet
            .RowCount += 1
            Dim iRow As Integer = .RowCount - 1

            .Cells(iRow, 0).Value = NombrePago
            .Cells(iRow, 1).Value = MontoPagar
            .Cells(iRow, 2).Value = Referencia

            ' Lógica de Comisión (Vales / Tarjeta)
            If NombrePago = "Vales" AndAlso (TIPOVENTA = 2 Or TIPOVENTA = 3) Then
                .RowCount += 1
                .Cells(.RowCount - 1, 0).Value = "Comision Vales"
                Dim Comision As Decimal = Math.Round((MontoPagar / 1.02D) * 0.02D * -1, 2)
                .Cells(.RowCount - 1, 1).Value = Comision
                DistribuyeComConP1(Math.Abs(Comision))
            End If

            ' Actualizar Banderas
            HayTarjeta = (TIPOVENTA = 1 AndAlso NombrePago = "Tarjeta")
            .Cells(iRow, 3).Value = TipoTarj
        End With

        ' 6. Finalizar
        sumapagos()
        LimpiarYSalir()
    End Sub

    ' =================================================================================
    ' SUB-RUTINA 2: PROCESAR CAMBIO DE CANTIDAD (F3)
    ' =================================================================================
    Private Sub ProcesarCambioCantidad()
        Dim NuevaCantidad As Decimal = CDec(tx_cantidad.Text)

        With FpArticulos.ActiveSheet
            If .RowCount = 0 Then Exit Sub

            Dim iRen As Integer = .RowCount - 1
            Dim UPC As String = .Cells(iRen, ColVenta.ColUPCInv).Text
            Dim Clave As String = .Cells(iRen, ColVenta.ColArtClave).Text

            ' 1. VALIDACIÓN DE SALDO (RecorreSpread)
            ' Antes de mover nada, verificamos si es una Cancelación válida (-1)
            If NuevaCantidad < 0 Then
                If Not RecorreSpread(UPC, NuevaCantidad, True) Then
                    LimpiarYSalir()
                    Exit Sub
                End If
            End If

            ' 2. actualización VISUAL Y BANDERAS
            .Cells(iRen, ColVenta.ColF3).Value = 1
            F3Cantidad = True
            .Cells(iRen, ColVenta.ColCantidad).Value = NuevaCantidad

            ' Calculo temporal del total visual
            Dim PrecioActual As Decimal = CDec(.Cells(iRen, ColVenta.ColPrecio).Value)
            .Cells(iRen, ColVenta.ColTotal).Value = NuevaCantidad * PrecioActual

            ' =========================================================
            ' 3. GUARDADO DIRECTO EN BD (UPDATE)
            ' =========================================================
            ' Aquí aseguramos que el cambio se guarde en tmpauxvta2
            Dim SQLUpdate As String = "UPDATE tmpauxvta2 SET cantidad=" & NuevaCantidad &
                                  ", FueConF3=1 WHERE renglon=" & iRen &
                                  " AND usuario='" & Globales.caja & "'"
            Base.Ejecuta(SQLUpdate, sCadenaConexionSQL)

            ' =========================================================
            ' 4. CONSULTA DE PRECIOS Y OFERTAS FRESCAS
            ' =========================================================
            Dim SQL As String = "select isnull(tipo_ofer,0) Tipo_Ofer, isnull(CantidadDisponible,-1) CantidadDisponible, " &
                            "isnull(t2a.CantidadCobrados,-1) CobradosUPC, isnull(t2c.CantidadCobrados,-1) CobradosClave, " &
                            "isnull(XPRECIO1,0) XPRECIO1, isnull(XPRECIO2,0) XPRECIO2, isnull(XPRECIO3,0) XPRECIO3, " &
                            "ART_PRECIO1, ART_PRECIO2, ART_PRECIO3, ART_TOPEMAY " &
                            "from xupc inner join articulo on upc_cveart=art_Clave " &
                            "LEFT JOIN ECBOLETINOFER ON ((((ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv is null) or (ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv=XUPC.UPC_CODINV)) or ART_FAMILIA=Fam_Clave or art_marca=ClaveMarca) AND ((FECHAINI<='" & Format(Today, "yyyyMMdd") & "' AND FECHAFIN>='" & Format(Today, "yyyyMMdd") & "') or (CantidadDisponible>0 and Cantidad>0)) and Activo=1) " &
                            "left join (select ARTICULO, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by articulo) t2a on (t2a.ARTICULO=ECBOLETINOFER.UPC_CodInv and TIPO_OFER=1) " &
                            "left join (select ArtClave, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by ArtClave) t2c on (t2c.ArtClave=ECBOLETINOFER.ARTICULO and TIPO_OFER=2 ) " &
                            "where upc_upc = '" & UPC & "' " &
                            "order by XPRECIO1 asc, CantidadDisponible desc"

            Dim dscOfertas As New DataSet
            Base.daQuery(SQL, sCadenaConexionSQL, dscOfertas, "InfoOferta")

            Dim Disp As Decimal = -1
            Dim Cobrados As Decimal = 0
            Dim POff1 As Decimal = 0, POff2 As Decimal = 0, POff3 As Decimal = 0
            Dim TipoOfer As Integer = 0
            Dim BD_P1 As Decimal = 0, BD_P2 As Decimal = 0, BD_P3 As Decimal = 0, BD_Tope As Decimal = 0

            If dscOfertas.Tables("InfoOferta").Rows.Count > 0 Then
                Dim row As DataRow = dscOfertas.Tables("InfoOferta").Rows(0)

                Disp = CDec(row("CantidadDisponible"))
                TipoOfer = CInt(row("Tipo_Ofer"))
                POff1 = CDec(row("XPRECIO1"))
                POff2 = CDec(row("XPRECIO2"))
                POff3 = CDec(row("XPRECIO3"))
                BD_P1 = CDec(row("ART_PRECIO1"))
                BD_P2 = CDec(row("ART_PRECIO2"))
                BD_P3 = CDec(row("ART_PRECIO3"))
                BD_Tope = CDec(row("ART_TOPEMAY"))

                If CDec(row("CobradosClave")) <> -1 Then
                    Cobrados = CDec(row("CobradosClave"))
                Else
                    Cobrados = CDec(row("CobradosUPC"))
                End If

                ' =========================================================
                ' Lógica DE COLORES F3
                ' =========================================================
                ' 1. Cancelación o Cero -> ROJO
                If NuevaCantidad <= 0 Then
                    .Rows(iRen).ForeColor = Color.Red

                    ' 2. Si bajó de precio (Precio actual vs Precio 1) -> VERDE
                    ' Nota: Comparamos contra BD_P1 que acabamos de traer de la base de datos
                ElseIf CDec(.Cells(iRen, ColVenta.ColPrecio).Value) < BD_P1 AndAlso TIPOVENTA = 1 Then
                    .Rows(iRen).ForeColor = Color.Green

                    ' 3. Oferta especial -> VERDE (o Azul si prefieres distinguir oferta de mayoreo)
                ElseIf TipoOfer > 0 Then
                    .Rows(iRen).ForeColor = Color.Blue

                Else
                    ' Normal -> NEGRO
                    .Rows(iRen).ForeColor = Color.Black
                End If
            Else
                MsgBox("El Artículo ya no se encuentra en el catálogo.", vbCritical)
                Exit Sub
            End If

            ' =========================================================
            ' 5. LLAMADA A CONTROL PRECIOS
            ' =========================================================
            ' TRUCO IMPORTANTE: Pasamos SCANT y SCANTANT con el MISMO VALOR (NuevaCantidad).
            ' Esto hace que la "Diferencia" sea 0 dentro de ControlPrecios.
            ' ASí, ControlPrecios NO intenta hacer otro UPDATE sumando cosas, 
            ' pero Sí ejecuta toda la Lógica de VALIDACIÓN de ofertas y peinado.

            CONTROLPRECIOS(UPCUPC:=UPC,
               DPRECIO1:=BD_P1,
               DPRECIO2:=BD_P2,
               DPRECIO3:=BD_P3,
               TOPE:=BD_Tope,
               SCANT:=NuevaCantidad,      ' <-- Nueva
               SCANTANT:=NuevaCantidad,   ' <-- Igual a Nueva (Diferencia = 0)
               RENGLON:=iRen,
               ArtClave:=Clave,
               CargandoPendiente:=False,
               CantidadDisponible:=Disp,
               PrecioOferta1:=POff1,
               PrecioOferta2:=POff2,
               PrecioOferta3:=POff3,
               CantidadCobradas:=CInt(Cobrados),
               TipoOferta:=TipoOfer)

        End With

        sumaSpread()
        LimpiarYSalir()
    End Sub

    ' =================================================================================
    ' UTILIDAD: LIMPIEZA DE UI
    ' =================================================================================
    Private Sub LimpiarYSalir()
        tx_cantidad.Text = ""
        tx_cantidad.Visible = False
        LFORPAG.Text = ""
        LFORPAG.Visible = False
        l_cantidad.Visible = False
        Lkilos.Visible = False
        If formaspago Then
            If fpago = 3 OrElse fpago = 6 OrElse fpago = 7 Then 'Cheque
                CierraBanco()
            ElseIf fpago = 4 Then
                CierraCredito()
            ElseIf fpago = 7 Then

            End If
        End If
        TX_UPC.Enabled = True
        TX_UPC.Text = ""
        TX_UPC.Focus()
    End Sub
    Private Sub tx_cantidad_KeyDownOriginal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim formaspag As String
        Dim tercera As String

        Dim SQL As String
        Dim DSC As New DataSet
        Dim CantidadAnteriorF3 As Double
        Dim RENGLON As Integer
        Dim I As Integer
        Dim VECES As Integer
        Dim J As Integer
        Dim SIGNO(5) As String
        Dim TXVALOR(5) As String
        Dim Cantidad As Double

        tercera = ""
        If e.KeyCode = Keys.Enter Then
            If formaspago Then
                Select Case fpago
                    Case 1
                        formaspag = "Efectivo"
                    Case 2
                        formaspag = "Vales"
                    Case 3
                        formaspag = "Cheque"
                    Case 4
                        formaspag = "Credito"
                    Case 6
                        formaspag = "Tarjeta"
                    Case 7
                        formaspag = "Transfer"
                    Case Else
                        formaspag = "Devolucion"
                End Select


                If IsNumeric(tx_cantidad.Text) Then
                    If (tx_cantidad.TextLength) < 11 Then
                        If fpago = 2 OrElse fpago = 3 OrElse fpago = 4 OrElse fpago = 6 OrElse fpago = 7 Then
                            Dim TotalPagosEsp As Double = 0
                            Dim TotalEfectivo As Double = 0
                            Dim ComTmp As Double
                            If TIPOVENTA > 1 Then
                                ComTmp = AlcanzaComision(CDbl(tx_cantidad.Text) / 1.02 * 0.02, True)
                            Else
                                ComTmp = 0
                            End If


                            For RenPago As Integer = 0 To FpFormasPago.ActiveSheet.RowCount - 1
                                If FpFormasPago.ActiveSheet.Cells(RenPago, 0).Text = "Vales" OrElse FpFormasPago.ActiveSheet.Cells(RenPago, 0).Text = "Cheque" OrElse
                                        FpFormasPago.ActiveSheet.Cells(RenPago, 0).Text = "Credito" OrElse FpFormasPago.ActiveSheet.Cells(RenPago, 0).Text = "Tarjeta" OrElse FpFormasPago.ActiveSheet.Cells(RenPago, 0).Text = "Transfer" Then
                                    TotalPagosEsp += FpFormasPago.ActiveSheet.Cells(RenPago, 1).Value
                                Else
                                    TotalEfectivo += FpFormasPago.ActiveSheet.Cells(RenPago, 1).Value
                                End If
                            Next

                            'If TotalPagosEsp + CDbl(tx_cantidad.Text) > (Math.Round(totalote * IIf((TIPOVENTA = 2 Or TIPOVENTA = 3), 1.02, 1), 2)) Then
                            If Math.Round(TotalPagosEsp + (CDbl(tx_cantidad.Text) - ComTmp - TotalComision), 2) > totalote Then

                                MsgBox("Con Formas de Pago distintas al efectivo, la cantidad máxima a pagar es el monto del ticket.", vbExclamation, "Monto Incorrecto")
                                LFORPAG.Visible = False
                                tx_cantidad.Text = ""
                                tx_cantidad.Visible = False
                                TXB_BANCO.Text = ""
                                TX_UPC.Enabled = True
                                TX_UPC.Text = ""
                                TX_UPC.Focus()

                                Exit Sub
                            End If
                        End If

                        If Me.TXB_BANCO.Text = "" Then
                            If fpago = 6 Or fpago = 7 Or fpago = 3 Then
                                MsgBox("Ingrese Referencia Bancaria del Pago", vbExclamation, "Referencia Bancaria")
                                TXB_BANCO.Focus()
                                Exit Sub
                            End If
                            '  tercera = Me.txb_credito.Text
                        Else
                            tercera = Me.TXB_BANCO.Text
                        End If
                        If CDbl(Me.tx_cantidad.Text) > acredito And fpago = 4 Then
                            Dim forma As Form
                            forma = New VENTANITA("Límite de Crédito insuficiente.", "Crédito Inválido")
                            forma.BringToFront()
                            forma.ShowDialog()
                            tx_cantidad.Text = ""
                            tx_cantidad.Visible = False
                            TX_UPC.Text = ""
                            TX_UPC.Focus()

                            Me.LFORPAG.Text = ""
                            Exit Sub

                        End If
                        If CDbl(Me.tx_cantidad.Text) > (Math.Round(totalote, 2) - Math.Round(totalpagos, 2)) And fpago = 4 Then
                            Dim forma As Form
                            forma = New VENTANITA("La cantidad de Crédito no puede ser mayor a la cantidad pendiente de pago.", "Crédito Inválido")
                            forma.BringToFront()
                            forma.ShowDialog()
                            tx_cantidad.Text = ""
                            tx_cantidad.Visible = False
                            TX_UPC.Text = ""
                            TX_UPC.Focus()

                            Me.LFORPAG.Text = ""
                            Exit Sub
                        End If
                        FpFormasPago.ActiveSheet.RowCount = FpFormasPago.ActiveSheet.RowCount + 1
                        FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 0).Value = formaspag
                        FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 1).Value = Val(tx_cantidad.Text) 'IIf(formaspag = "Tarjeta" And (TIPOVENTA = 2 Or TIPOVENTA = 3), Math.Round(CDbl(tx_cantidad.Text) / 1.02, 2), Math.Round(CDbl(tx_cantidad.Text), 2))
                        FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 2).Value = tercera
                        If FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 0).Value = "Vales" And (TIPOVENTA = 2 Or TIPOVENTA = 3) Then
                            FpFormasPago.ActiveSheet.RowCount = FpFormasPago.ActiveSheet.RowCount + 1
                            FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 0).Value = "Comision Vales"
                            'FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 1).Value = Val(tx_cantidad.Text) * 0.03 * -1
                            FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 1).Value = Format(Round((Val(tx_cantidad.Text) / 1.02) * 0.02 * -1, 2), "#####0.00") '0.020797 comision tarjeta
                            DistribuyeComConP1(Round((Val(tx_cantidad.Text) / 1.02) * 0.02, 2))
                        End If
                        If TIPOVENTA = 1 AndAlso FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 0).Value = "Tarjeta" Then
                            HayTarjeta = True
                        Else
                            HayTarjeta = False
                        End If
                        If TIPOVENTA > 1 AndAlso FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 0).Value = "Tarjeta" Then
                            DistribuyeComConP1(Round((CDbl(tx_cantidad.Text) / 1.02) * 0.02, 2))
                        End If
                        FpFormasPago.ActiveSheet.Cells(FpFormasPago.ActiveSheet.RowCount - 1, 3).Value = TipoTarj
                        Me.TXB_BANCO.Text = ""
                        sumapagos()
                        tx_cantidad.Text = ""
                        tx_cantidad.Visible = False
                        TX_UPC.Text = ""
                        TX_UPC.Enabled = True
                        TX_UPC.Focus()

                        Me.LFORPAG.Text = ""
                    Else
                        MsgBox("Introduzca una cantidad menor, y/o que no sea código de barras.", vbExclamation, "Punto de Venta")
                        tx_cantidad.Text = ""
                        Me.tx_cantidad.Focus()
                        Exit Sub
                    End If
                Else
                    MsgBox("Introduzca un valor numérico.", vbExclamation, "Punto de Venta")
                    tx_cantidad.Text = ""
                    Me.tx_cantidad.Focus()
                    Exit Sub
                End If
            Else
                Try
                    If (tx_cantidad.TextLength) < 20 Then
                        Dim dataTable As New DataTable()
                        Try
                            Dim result As Object = dataTable.Compute(tx_cantidad.Text, "")
                            Cantidad = Convert.ToDouble(result)
                        Catch ex As Exception
                            MsgBox("Ingrese operación matemática correcta.", vbExclamation, "Punto de Venta")
                            tx_cantidad.Focus()
                            Exit Sub
                        End Try

                        tx_cantidad.Text = Cantidad

                        If Cantidad < 0 Then
                            If Not RecorreSpread(FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColUPCInv).Value, Cantidad, True) Then
                                tx_cantidad.Text = FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColCantidad).Value
                                F3Cantidad = IIf(FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.RowCount - 1, ColVenta.ColF2).Value = 1, True, False)
                            Else
                                F3Cantidad = True
                            End If
                        Else
                            F3Cantidad = True
                        End If

                        With FpArticulos.ActiveSheet
                            LbTotal.Text = CDbl(LbTotal.Text) - CDbl(.Cells(.RowCount - 1, ColVenta.ColPrecio).Value)
                            CantidadAnteriorF3 = .Cells(.RowCount - 1, ColVenta.ColCantidad).Value
                            .Cells(.RowCount - 1, ColVenta.ColF3).Value = IIf(F3Cantidad, 1, 0)
                            .Cells(.RowCount - 1, ColVenta.ColCantidad).Value = CDbl(tx_cantidad.Text)

                            If CDbl(tx_cantidad.Text) = 0 Then
                                '.Cells(.RowCount - 1, ColVenta.ColFIVA).Text = 
                            End If

                            .Cells(.RowCount - 1, ColVenta.ColTotal).Value = .Cells(.RowCount - 1, ColVenta.ColPrecio).Value * (CDbl(tx_cantidad.Text))

                            SQL = "update tmpauxvta2 set cantidad=" & CDbl(tx_cantidad.Text) & ", FueConF3=" & IIf(F3Cantidad, 1, 0) & " where  " &
                                        " usuario='" & Globales.caja & "' and renglon=" & .RowCount - 1

                            Base.Ejecuta(SQL, sCadenaConexionSQL)

                            RENGLON = .RowCount - 1

                            SQL = "select isnull(tipo_ofer,0) Tipo_Ofer,art_clave, isnull(ECBOLETINOFER.ARTICULO,'') Articulo, upc_descripcion, Art_NomLargo, Art_CostoCap2, ART_FAMILIA, isnull(ECBOLETINOFER.DescOferta,'') DescOferta, isnull(CantidadDisponible,-1) CantidadDisponible, ISNULL(ECBOLETINOFER.Cantidad,0) Cantidad, isnull(PorcentajeDescuento,'') PorcentajeDescuento, isnull(ID,'') ID, isnull(Fam_Clave,'') Fam_Clave, isnull(ClaveMarca,-1) ClaveMarca, isnull(t2a.CantidadCobrados,-1) CobradosUPC ,isnull(t2c.CantidadCobrados,-1) CobradosClave," &
                                    "isnull(ECBOLETINOFER.UPC_CodInv,'') UPCCodInvOferta, xupc.upc_codinv, ART_PRECIO1, isnull(XPRECIO1,art_precio1*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO1, ART_PRECIO2, isnull(XPRECIO2,art_precio2*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO2, ART_PRECIO3,isnull(XPRECIO3,art_precio3*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO3, " &
                                    "isnull(art_kilo,0) ART_KILO ,ISNULL(art_entrega,0) ART_ENTREGA, art_topemay, art_iva, art_ieps, upc_upc from xupc inner join articulo on upc_cveart=art_Clave " &
                                    "LEFT JOIN ECBOLETINOFER ON ((((ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv is null) or (ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv=XUPC.UPC_CODINV)) or ART_FAMILIA=Fam_Clave or art_marca=ClaveMarca) AND ((FECHAINI<='" & Format(Today, "yyyyMMdd") & "' AND FECHAFIN>='" & Format(Today, "yyyyMMdd") & "') or (CantidadDisponible>0 and Cantidad>0)) and Activo=1) " &
                                    "left join (select ARTICULO, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by articulo) t2a on (t2a.ARTICULO=ECBOLETINOFER.UPC_CodInv and TIPO_OFER=1) " &
                                    "left join (select ArtClave, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by ArtClave) t2c on (t2c.ArtClave=ECBOLETINOFER.ARTICULO and TIPO_OFER=2 ) " &
                                    "where upc_upc = '" & FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value & "' " &
                                    "order by XPRECIO1 asc, CantidadDisponible desc, UPCCodInvOferta desc"

                            'OfertaTopeMay
                            Base.daQuery(SQL, sCadenaConexionSQL, DSC, "articulo")
                            If DSC.Tables("articulo").Rows.Count > 0 Then
                                'validar la cantidad limitada
                                Dim CantCob As Double = IIf(DSC.Tables("Articulo").Rows(0)("CobradosClave") <> -1, DSC.Tables("Articulo").Rows(0)("CobradosClave") + IIf(CDbl(tx_cantidad.Text) < 0, FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColCantidad).Value - CDbl(tx_cantidad.Text), 0), DSC.Tables("Articulo").Rows(0)("CobradosUPC") + IIf(CDbl(tx_cantidad.Text) < 0, FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColCantidad).Value - CDbl(tx_cantidad.Text), 0))
                                If DSC.Tables("ARTICULO").Rows(0)("Articulo").ToString.Trim = "" AndAlso DSC.Tables("ARTICULO").Rows(0)("Fam_Clave").ToString.Trim = "" AndAlso DSC.Tables("ARTICULO").Rows(0)("ClaveMarca").ToString.Trim = "-1" Then 'Si no hay oferta
                                    CONTROLPRECIOS(FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
                                Else
                                    If CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")) > 0 And CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")) > 0 And CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")) > 0 Then
                                        If DSC.Tables("articulo").Rows(0)("Cantidad") > 0 Then 'Si oferta es por cantidad                                            
                                            If (DSC.Tables("articulo").Rows(0)("CantidadDisponible") >= DSC.Tables("Articulo").Rows(0)("CobradosClave") + IIf(CDbl(tx_cantidad.Text) < 0, Math.Abs(CDbl(tx_cantidad.Text)), 0) And DSC.Tables("Articulo").Rows(0)("CobradosClave") <> -1) Or (DSC.Tables("articulo").Rows(0)("CantidadDisponible") >= DSC.Tables("Articulo").Rows(0)("CobradosUPC") + IIf(CDbl(tx_cantidad.Text) < 0, Math.Abs(CDbl(tx_cantidad.Text)), 0) And DSC.Tables("Articulo").Rows(0)("CobradosUPC") <> -1) Then
                                                CONTROLPRECIOS(FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("art_precio1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("art_precio2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
                                            Else
                                                CONTROLPRECIOS(FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
                                            End If
                                        Else 'Cuando es por tiempo y sigue vigente
                                            CONTROLPRECIOS(FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
                                        End If
                                    Else
                                        CONTROLPRECIOS(FpArticulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
                                    End If
                                End If
                            Else
                                'Debo activarbloqueo? asumo que si está el renglón es porque existe el producto, no veo caso
                            End If
                            DSC.Tables.Remove("ARTICULO")
                        End With
                        sumaSpread()
                        tx_cantidad.Visible = False
                        Me.l_cantidad.Visible = False
                        Me.Lkilos.Visible = False

                        TX_UPC.Enabled = True
                        TX_UPC.Focus()
                    Else
                        MsgBox("Favor de Introducir un Numero Menor a 99999 y que no sea Codigo De Barras")
                        Me.tx_cantidad.Focus()
                    End If


                Catch ex As Exception
                    Dim errorcode As Integer
                    errorcode = sndPlaySoundA("c:\WINDOWs\MEDIA\tada.WAV", &H1)
                    MsgBox("yyyyyyyyFavor de Introducir un Numero Menor a 99999 y que no sea Codigo De Barras")
                    Me.tx_cantidad.Focus()
                End Try
            End If
        ElseIf e.KeyCode = Keys.Escape AndAlso formaspago Then
            sumapagos()
            banco.Visible = False
            credito.Visible = False
            LFORPAG.Text = ""
            tx_cantidad.Text = ""
            TXB_BANCO.Text = ""
            TipoTarj = ""
            tx_cantidad.Visible = False
            TX_UPC.Enabled = True
            TX_UPC.Text = ""
            TX_UPC.Focus()
        ElseIf e.KeyCode = Keys.Escape AndAlso Not formaspago Then
            If Lkilos.Visible <> True Then
                l_cantidad.Visible = False
                tx_cantidad.Visible = False
                tx_cantidad.Text = ""
                TX_UPC.Enabled = True
                TX_UPC.Text = ""
                TX_UPC.Focus()
            End If
        End If
    End Sub


    Private Sub DistribuyeComConP1(ByVal MontoComision As Decimal)
        Dim UniversoArticulos As Decimal = 0D
        Dim MontoMaximoComisionLoc As Decimal = 0D
        Dim Articulos As New List(Of Integer)

        Dim TotalComisionTmp As Decimal = 0D
        If TotalComision <> 0 Then
            TotalComisionTmp = TotalComision
            QuitaComision()
            MontoComision = Math.Round(MontoComision + TotalComisionTmp, 2)
        End If

        For i As Integer = 0 To FpArticulos.ActiveSheet.Rows.Count - 1
            If FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value > 0 AndAlso (FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value < FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * FpArticulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value) Then
                MontoMaximoComisionLoc += (FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * FpArticulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value) - FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value
                UniversoArticulos += FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value
                Articulos.Add(i)
            End If
        Next

        If MontoMaximoComisionLoc > 0 Then
            If MontoComision > MontoMaximoComisionLoc Then
                MontoComision = MontoMaximoComisionLoc
            End If

            Dim ComisionRen As Decimal = 0D
            Dim Entre As Boolean = False
            Do Until Math.Round(TotalComision, 2) = Math.Round(MontoComision, 2)
                For Each i As Integer In Articulos
                    If FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value <> 0 AndAlso TotalComision < MontoComision Then
                        Entre = True
                        ComisionRen = Math.Round(Math.Min(MontoComision - TotalComision, Math.Min(FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / UniversoArticulos * MontoComision, (FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * (FpArticulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value - FpArticulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value)))), 3)
                        FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value = FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value + ComisionRen
                        FpArticulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value = FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
                        FpArticulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value += ComisionRen
                        TotalComision = TotalComision + ComisionRen
                    ElseIf MontoComision = TotalComision Then
                        Exit For
                    End If
                Next
            Loop

        Else
            Exit Sub
        End If
        sumaSpread()
    End Sub

    Private Function AlcanzaComision(ByVal MontoComisionObjetivo As Double, ByVal RecalcularQuitarComision As Boolean) As Decimal
        Dim ComisionPrevia As Decimal = 0
        If RecalcularQuitarComision AndAlso TotalComision <> 0 Then
            ComisionPrevia = TotalComision
            QuitaComision()
            TotalComision = ComisionPrevia
            MontoComisionObjetivo = MontoComisionObjetivo + ComisionPrevia
        End If

        Dim AhorroTotalCliente As Decimal = 0

        With FpArticulos.ActiveSheet
            For i As Integer = 0 To .RowCount - 1
                ' Leemos valores seguros
                Dim Cantidad As Decimal = CDec(Val(.Cells(i, ColVenta.ColCantidad).Value))
                Dim PrecioPublico As Decimal = CDec(Val(.Cells(i, ColVenta.ColPrecio1).Value))
                Dim PrecioCobrado As Decimal = CDec(Val(.Cells(i, ColVenta.ColPrecio).Value))
                Dim TotalLinea As Decimal = CDec(Val(.Cells(i, ColVenta.ColTotal).Value))

                ' Solo calculamos ahorro en renglones válidos (Cantidad > 0)
                ' y donde realmente hubo un descuento (PrecioCobrado < PrecioPublico)
                If Cantidad > 0 AndAlso PrecioCobrado < PrecioPublico Then

                    ' CÁLCULO preciso del ahorro: (Lo que debió costar) - (Lo que costó)
                    Dim AhorroEnRenglon As Decimal = (Cantidad * PrecioPublico) - TotalLinea
                    AhorroTotalCliente += AhorroEnRenglon
                End If
            Next
        End With

        ' =========================================================
        ' 3. DECISIÓN FINAL (TOPE VS OBJETIVO)
        ' =========================================================

        If AhorroTotalCliente <= 0 Then
            ' Si no hubo ahorro, no hay margen para cobrar Comisión bajo esta regla.
            Return 0
        ElseIf MontoComisionObjetivo > AhorroTotalCliente Then
            ' Si la Comisión del banco excede lo que se ahorró el cliente,
            ' topamos la Comisión al ahorro (para que no salga perdiendo).
            Return AhorroTotalCliente
        Else
            ' Si la Comisión cabe dentro del ahorro, cobramos la Comisión completa.
            Return MontoComisionObjetivo
        End If
    End Function
    Private Sub QuitaComision()
        If TotalComision > 0 Then
            Dim ComisionRen As Double = 0
            For i As Integer = 0 To FpArticulos.ActiveSheet.RowCount - 1
                If FpArticulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value > 0 AndAlso FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value <> 0 Then
                    ComisionRen = FpArticulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value
                    FpArticulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value = 0
                    FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value = FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value - ComisionRen
                    FpArticulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value = FpArticulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
                End If
            Next
            TotalComision = 0
            sumaSpread()
        End If
    End Sub
    Private Sub sumapagos()
        Dim dTotalPagado As Decimal = 0D
        Dim ImporteRenglon As Decimal = 0D
        Dim Concepto As String = ""

        With FpFormasPago.ActiveSheet
            ' Recorremos el grid de pagos
            For iRen As Integer = 0 To .RowCount - 1

                ' 1. LECTURA SEGURA
                ' ToUpper asegura que no importen Mayúsculas/minúsculas
                Concepto = .Cells(iRen, 0).Text.Trim.ToUpper()

                ' Val() evita que truene si la celda está vacía
                ImporteRenglon = CDec(Val(.Cells(iRen, 1).Value))

                ' 2. Lógica DE SIGNOS (Comisión vs Pago Real)
                ' Interpretación: La Comisión está en el grid pero NO cuenta como dinero que baja la deuda,
                ' por eso la restamos (o no la sumamos) al poder de pago.

                If Concepto = "COMISION VALES" Or Concepto = "COMIS TAR" Then
                    dTotalPagado -= ImporteRenglon
                Else
                    dTotalPagado += ImporteRenglon
                End If
            Next
        End With

        ' 3. actualización DE GLOBALES Y UI
        totalpagos = dTotalPagado ' Actualizamos la variable global

        TotalPago = dTotalPagado
        TX_TOTALPAGO.Text = dTotalPagado.ToString("C2")  ' Formato Moneda ($1,234.50)

        ' 4. CÁLCULO DE SALDO / CAMBIO
        ' totalote = Deuda Total
        ' totalpagos = Lo que ya dieron
        Dim Diferencia As Decimal = totalote - dTotalPagado

        If Diferencia <= 0 Then
            ' CASO A: Ya cubrió el importe (o dio de más)
            ' Tu Lógica original muestra $0.00 Aquí (indicando que "Ya no debe nada").
            ' Si quisieras mostrar el CAMBIO A ENTREGAR, usarías: Math.Abs(Diferencia).ToString("C2")

            lcambio.Text = "$0.00"

        Else
            ' CASO B: todavía debe dinero (Saldo Pendiente)
            lcambio.Text = Diferencia.ToString("C2")

            ' Opcional: Color de alerta
            ' lcambio.ForeColor = Color.Red
        End If
    End Sub


    Private Sub borrapagos()
        FpFormasPago.ActiveSheet.RowCount = 0
        lcambio.Text = "$0.00"
        TXB_BANCO.Text = ""

        tx_cantidad.Text = ""
        tx_cantidad.Visible = False
        LFORPAG.Visible = False

        banco.Visible = False
        credito.Visible = False
        txb_credito.Text = ""
        txb_credito1.Text = ""
        formaspago = False
        TX_TOTALPAGO.Text = ""
        grformapago.Visible = False
        TX_UPC.Text = ""
        TX_UPC.Focus()
        totalpagos = 0
        QuitaComision()
        HayTarjeta = False
    End Sub


    Private Sub TXB_BANCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXB_BANCO.KeyDown, TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then

            If TXB_BANCO.Text <> "" Then
                banco.Visible = False
                Me.tx_cantidad.Visible = True
                Me.tx_cantidad.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            LimpiarYSalir()
        End If
    End Sub

    Private Sub txb_credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txb_credito.KeyDown

        If e.KeyCode = Keys.Enter Then
            'Me.clientex = Me.txb_credito1.Text
            Dim sql As String
            Dim dsc As New DataSet
            Dim saldo As String
            Dim creditos As String
            'If txb_credito.Text = "" Then
            '    MsgBox("ingrese numero de cliente")
            'Else

            '    If txb_credito.Text.Substring(0, 1) = "F" Then
            '        txb_credito.Text = txb_credito.Text.Substring(1, txb_credito.Text.Length - 1)
            '    End If

            Dim frmbuscar As New busqueda
            frmbuscar.TXTCONTROL = Me.txt_foliopago
            GENERAL.parametrosbusqueda(frmbuscar, "Clientes Registrados", "cli_clave,cli_nombre,dcli_saldo,dcli_limite-dcli_saldo as disponible,dcli_limite", "ecclientes inner join ecdetclienteemp on cli_clave=dcli_clave and dcli_empresa=1 ", "cli_nombre asc", "1", sCadenaConexionSQL, "Folio,Nombre,Saldo,Credito Disponible,Limite Credito", "50,200,80,100,100", "A,A,#,#,#", "2", "")
            frmbuscar.Top = (Me.Height / 2 - frmbuscar.Height / 2)
            frmbuscar.Left = (Me.Width / 2 - frmbuscar.Width / 2)
            frmbuscar.BringToFront()
            frmbuscar.ShowDialog()
            frmbuscar.Dispose()
            Me.txb_credito.Text = Me.txt_foliopago.Text


            sql = "select cli_clave,dcli_Saldo,dcli_limite from ecclientes inner join ecdetclienteemp on cli_clave=dcli_clave and dcli_empresa=1  where ltrim(rtrim(cli_nombre))='" & LTrim(RTrim(txb_credito.Text)) & "'"
            Base.daQuery(sql, sCadenaConexionSQL, dsc, "credito")
            If dsc.Tables("credito").Rows.Count > 0 Then
                creditos = dsc.Tables("credito").Rows(0)("dcli_limite")
                saldo = dsc.Tables("credito").Rows(0)("dcli_saldo")
                txb_credito1.Text = dsc.Tables("credito").Rows(0)("cli_clave")
                Me.clientex = Me.txb_credito1.Text

                acredito = Val(creditos) - Val(saldo)
                If Val(creditos) - Val(saldo) > 0 Then
                    credito.Visible = False
                    Me.tx_cantidad.Visible = True
                    Me.tx_cantidad.Focus()
                Else
                    MsgBox("Cliente sin saldo")
                    Me.LFORPAG.Text = ""
                    tx_cantidad.Text = ""
                    credito.Visible = False
                    Me.TX_UPC.Focus()
                End If

            Else
                Me.txb_credito.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            LimpiarYSalir()
        End If
        'End If

    End Sub
    Private Sub CierraBanco()
        TXB_BANCO.Text = ""
        banco.Visible = False
        sumapagos()
    End Sub
    Private Sub CierraCredito()
        pagare = False
        txb_credito.Text = ""
        txb_credito1.Text = ""
        credito.Visible = False
        sumapagos()
    End Sub

    Private Sub CierraTarjeta()

        sumapagos()
    End Sub
    Private Function ObtenerMotivosAutorizacion() As List(Of String)
        Dim lines As New List(Of String)

        ' Tipo venta 3
        If txt_tipoventa.Text.Trim = "3" Then
            lines.Add("**Venta Tipo 3**")
            lines.Add("")
        End If

        ' Autorizaciones por forma de pago
        Dim agregoPagoHeader As Boolean = False
        For i As Integer = 0 To FpFormasPago.ActiveSheet.RowCount - 1
            Dim StrPago As String = ""

            Select Case FpFormasPago.ActiveSheet.Cells(i, 0).Value.ToString.ToUpper.Trim
                Case "TRANSFER" : StrPago = "   Pago con Transferencia"
                Case "CHEQUE" : StrPago = "   Pago con Cheque"
                Case "CREDITO" : StrPago = "   Pago con Crédito de Cliente"
            End Select

            If StrPago <> "" Then
                If Not agregoPagoHeader Then
                    lines.Add("**Autorizaciones Por Método de Pago**")
                    agregoPagoHeader = True
                End If
                lines.Add(StrPago)
            End If
        Next

        ' Autorizaciones por cancelaciones
        Dim agregoCancelHeader As Boolean = False
        For i As Integer = 0 To FpArticulos.ActiveSheet.RowCount - 1
            Dim cantObj = FpArticulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
            Dim cant As Decimal = 0D
            If cantObj IsNot Nothing Then Decimal.TryParse(cantObj.ToString(), cant)

            If cant <= 0D Then
                If Not agregoCancelHeader Then
                    If lines.Count > 0 Then lines.Add("")
                    lines.Add("**Autorizaciones Por Cancelaciones de Artículos**")
                    agregoCancelHeader = True
                End If

                Dim desc As String = CStr(FpArticulos.ActiveSheet.Cells(i, ColVenta.ColDescripcion).Value)
                If cant = 0D Then
                    lines.Add("   Cancela en 0 " & desc)
                Else
                    lines.Add("   Cancela " & Math.Abs(cant) & " " & desc)
                End If
            End If
        Next

        Return lines
    End Function

    Private Function RequiereAutorizacion() As Boolean
        Dim lines = ObtenerMotivosAutorizacion()
        Return lines.Any(Function(s) Not String.IsNullOrWhiteSpace(s))
    End Function

    Private Sub txt_tipoventa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_tipoventa.KeyDown
        If e.KeyCode = Keys.Enter Then

            If ValidaTipoVenta() Then
                'TxtControl.Text = 0
                'LbClienteTicket.Text = "Cliente: Público en General"
                Dim ClienteOrig As Integer = CInt(TxtControl.Text)
                Dim ClienteOrigStr As String = LbClienteTicket.Text

                Select Case txt_tipoventa.Text
                    Case "1"
                        TIPOVENTA = 1
                    Case "2"
                        TIPOVENTA = 2
                    Case "3"
                        TIPOVENTA = 3
                        If BuscarClienteDuarsa() = 0 Then
                            TxtControl.Text = ClienteOrig
                            LbClienteTicket.Text = ClienteOrigStr
                            Exit Sub
                        Else
                            Dim TmpStr() As String = TxtControl.Text.Trim.Split(",")
                            TxtControl.Text = CInt(TmpStr(0).Trim)
                            LbClienteTicket.Text = "Cliente: " & TmpStr(1).Trim
                        End If
                    Case Else

                        MsgBox("Tipo de Venta Inválida.", vbExclamation, "Punto de Venta")
                        txt_tipoventa.Enabled = True
                        txt_tipoventa.Text = "1"
                        txt_tipoventa.Focus()
                        Exit Sub
                End Select
                Me.pBoxF1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477207_magnifier_786081
                LbF1.Text = "F1 - Buscar Artículo"
                txt_tipoventa.Enabled = False
                Me.TX_UPC.Focus()
            End If

            '  limpiaSpread()
        ElseIf e.KeyCode = Keys.F2 Then
            Dim frmbuscar As New busqueda
            Dim ClienteOrig As Integer = TxtControl.Text
            Dim LbClienteOrig As String = LbClienteTicket.Text
            Dim TipoVentaOrig As String = txt_tipoventa.Text

            frmbuscar.TXTCONTROL = TxtControl
            GENERAL.parametrosbusqueda(frmbuscar, "Cotizaciones Registradas", "cot_id , convert(varchar, cot_fechacaptura, 103) , cot_cliente , cot_total", "eccotizaciones", "cot_id desc", "1", sCadenaConexionSQL, "Folio,Fecha,Cliente,Total", "50,80,350,100", "F,D,A,$", "1", "", Columnas:="")
            frmbuscar.TXTCONTROL = TxtControl
            frmbuscar.Top = (Me.Height / 2 - frmbuscar.Height / 2)
            frmbuscar.Left = (Me.Width / 2 - frmbuscar.Width / 2)
            frmbuscar.BringToFront()
            frmbuscar.ShowDialog()
            frmbuscar.Dispose()
            If TxtControl.Text <> "" Then
                Dim SQL As String
                Dim DSC As New DataSet
                SQL = "delete from tmpauxvta2 where usuario='" & Globales.caja & "'"
                Base.Ejecuta(SQL, sCadenaConexionSQL)
                SQL = "INSERT INTO tmpauxvta2 (" &
                      "renglon, usuario, articulo, cantidad, tipo, " &
                      "FueConF1, FueConF2, FueConF3, FueConF6, " &
                      "ClienteID, ArtClave, TraeVale, Factor) " & ' <--- Aquí definimos el orden explícito
                      "SELECT " &
                      "dcot_renglon-1, '" & Globales.caja & "', dcot_articulo, dcot_cantidad*dcot_cap1*dcot_cap2, tipo, " &
                      "1, 0, 0, 0, " & ' <--- Aquí mandamos el 0 a F6 (y 1 a F1 porque viene de cotización)
                      "ClienteID, art_clave, '', 1 " & ' <--- Agregué Factor 1 al final para prevenir errores
                      "FROM ecdetcotiza " &
                      "JOIN eccotizaciones ON dcot_compra=cot_id " &
                      "JOIN xupc ON upc_upc=dcot_articulo " &
                      "JOIN articulo ON upc_cveart=art_clave " &
                      "WHERE dcot_articulo<>'' AND dcot_compra=" & TxtControl.Text

                Base.Ejecuta(SQL, sCadenaConexionSQL)

                SQL = "select Tipo,ClienteID,CLI_NOMBRE From eccotizaciones t join ecclientes on t.clienteid=CLI_CLAVE where cot_id=" & TxtControl.Text
                Base.daQuery(SQL, sCadenaConexionSQL, DSC, "Cli")
                If DSC.Tables("Cli").Rows.Count > 0 Then
                    TxtControl.Text = DSC.Tables("Cli").Rows(0)("ClienteID")
                    LbClienteTicket.Text = "Cliente: " & DSC.Tables("Cli").Rows(0)("Cli_Nombre").trim
                    txt_tipoventa.Text = DSC.Tables("Cli").Rows(0)("tipo")
                    TIPOVENTA = DSC.Tables("Cli").Rows(0)("tipo")
                    txt_tipoventa.Enabled = False

                    SQL = "select*from tmpauxvta2 where usuario ='" & Globales.caja & "' order by renglon asc"
                    Base.daQuery(SQL, sCadenaConexionSQL, DSC, "Ticket")
                    For i = 0 To DSC.Tables("Ticket").Rows.Count - 1
                        TX_UPC.Text = DSC.Tables("Ticket").Rows(i)("articulo").ToString.Trim
                        ProcAgregaArticulo(True, DSC.Tables("Ticket").Rows(i)("Cantidad"), DSC.Tables("Ticket").Rows(i)("FueConF1"), DSC.Tables("Ticket").Rows(i)("FueConF2"), DSC.Tables("Ticket").Rows(i)("FueConF3"), DSC.Tables("Ticket").Rows(i)("TraeVale"))
                    Next
                    DSC.Tables.Remove("Ticket")
                    Me.pBoxF1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477097_avatar_78580
                    LbF1.Text = "F1 - Ligar Venta a Cliente"
                    Me.TX_UPC.Focus()
                End If
                DSC.Tables.Remove("Cli")
            Else
                TxtControl.Text = ClienteOrig
                LbClienteTicket.Text = LbClienteOrig
                txt_tipoventa.Enabled = False
                txt_tipoventa.Text = TipoVentaOrig
                Me.pBoxF1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477207_magnifier_786081
                LbF1.Text = "F1 - Buscar Artículo"
                TX_UPC.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            If txt_tipoventa.Text = "" OrElse Not IsNumeric(txt_tipoventa.Text) OrElse CDbl(txt_tipoventa.Text) < 1 OrElse CDbl(txt_tipoventa.Text) > 3 Then
                txt_tipoventa.Text = 1
            End If
            If TxtControl.Text = "" OrElse Not IsNumeric(TxtControl.Text) OrElse CDbl(TxtControl.Text) < 1 Then
                TxtControl.Text = 0
            End If

            CambiaCliente(TxtControl.Text, LbClienteTicket.Text, RequiereAutorizacion:=False)
        ElseIf e.KeyCode = Keys.Escape Then
            LbClienteTicket.Text = "Cliente: Público en General"
            TxtControl.Text = 0
            TIPOVENTA = 1
            txt_tipoventa.Text = 1
        End If
    End Sub

    Private Sub txt_tipoventa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tipoventa.LostFocus
        txt_tipoventa.Focus()
    End Sub

    Private Function ValidaTipoVenta() As Boolean
        Dim s As String = If(txt_tipoventa.Text, "")

        ' Estricto: ni espacios, ni "01", ni "1.0", ni "+1"
        If s = "1" OrElse s = "2" OrElse s = "3" Then
            Return True
        End If

        MsgBox("Tipo de Venta Inválido. sólo se permite 1, 2 o 3.", MsgBoxStyle.Exclamation)
        txt_tipoventa.Text = "1"
        txt_tipoventa.Focus()
        txt_tipoventa.SelectAll()
        Return False
    End Function

    Private Sub FpArticulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FpArticulos.Click

    End Sub

    Private Sub TX_UPC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TX_UPC.TextChanged

    End Sub

    Private Sub txt_tipoventa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tipoventa.GotFocus
        If FpArticulos.ActiveSheet.RowCount >= 1 And Not Corriendo Then
            MsgBox("No se modificar el tipo de venta. Ya existen articulos en la lista", MsgBoxStyle.Exclamation)
            Me.TX_UPC.Focus()
        End If
    End Sub

    Private Sub txt_cveenc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cveenc.KeyDown
        Dim sSql As String
        Dim dsc As New DataSet


        If e.KeyCode = Keys.Enter Then
            Dim i As Integer

            For i = 1 To Len(LTrim(RTrim(Me.txt_cveenc.Text)))
                If IsNumeric(Mid(txt_cveenc.Text, i, 1)) Then
                    Exit For
                End If
            Next
            txt_cveenc.Text = Mid(txt_cveenc.Text, i, Len(txt_cveenc.Text) - i + 1)

            sSql = "select * FROM ecusuariosx where emp_password='" & Me.txt_cveenc.Text & "'"
            Base.daQuery(sSql, sCadenaConexionSQL, dsc, "empleado")
            If dsc.Tables("empleado").Rows.Count > 0 Then
                If dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim = "Controlc" Then
                    '********************************************************************************
                    sSql = "Insert into ecerrores (err_fecha,err_descripcion) values ('" & Format(Now, "yyyyMMdd HH:mm:ss") &
 "','" & txe.Text.Trim & "')"
                    Base.Ejecuta(sSql, sCadenaConexionSQL)
                    '********************************************************************************

                    txe.Text = ""
                    txt_cveenc.Text = ""
                    Panel1.Visible = False
                    TX_UPC.Text = ""
                    TX_UPC.Enabled = True
                    SendKeys.Flush()
                    TX_UPC.Focus()
                Else
                    txt_cveenc.Text = ""
                    txt_cveenc.Focus()
                End If
            End If
            dsc.Tables.Remove("empleado")
        End If
    End Sub

    Private Sub FrVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Keys.Alt = e.KeyCode Then
            SendKeys.Send(Keys.Shift)
        End If
    End Sub

    Private Sub FrVenta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If cerrar = 1 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FpArticulos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpArticulos.KeyDown
        If FpArticulos.ActiveSheet.RowCount > 0 Then
            If e.KeyCode = (Keys.F1) Then
                If FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.ActiveRowIndex, ColVenta.ColCantidad).Value > 0 Then
                    If FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = "*" Then
                        MsgBox("Se Registro el Artículo como entregado en caja", MsgBoxStyle.Information)
                        FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = ""
                    Else
                        MsgBox("Se Registro el Artículo para entrega de Producto", MsgBoxStyle.Information)
                        FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = "*"
                    End If
                    Dim SQL As String
                    SQL = "update TMPAUXVTA2 set TraeVale='" & FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value & "' where usuario='" & Globales.caja & "' and Renglon=" & FpArticulos.ActiveSheet.ActiveRowIndex
                    Try
                        Base.Ejecuta(SQL, sCadenaConexionSQL)
                    Catch ex As Exception
                        MsgBox("Error al actualizar Vale en TmpAuxVta2." & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Punto de Venta")
                    End Try
                    segundoticket = True
                    TX_UPC.Focus()
                Else
                    FpArticulos.ActiveSheet.Cells(FpArticulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = ""
                End If
                FpArticulos.ActiveSheet.ActiveRowIndex = FpArticulos.ActiveSheet.RowCount - 1
                TX_UPC.Focus()
            End If
        End If
    End Sub

    Private Sub BTN_NUEVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_NUEVO.Click
        ActualizaOferta()
    End Sub


    Private Sub ActualizaOferta()
        Dim dsc As New DataSet
        Dim SQL As String
        If txt_panelofe.Text <> "" Then
            SQL = "select * from ecusuariosx where emp_tipo='Supervisor' and emp_password='" & txt_panelofe.Text & "'"
            Base.daQuery(SQL, sCadenaConexionSQL, dsc, "Autoriza")
            If dsc.Tables("Autoriza").Rows.Count > 0 Then
                If MsgBox("¿Ya retiró todas las etiquetas de la oferta expirada?", vbYesNo, "Oferta Expirada") = MsgBoxResult.Yes Then
                    Base.Ejecuta("update ecboletinofer set EtiqCamb=0, Activo=0, Supervisor='" & dsc.Tables("Autoriza").Rows(0)("emp_nombre") & "' where ID=" & CInt(LbIDOferta.Text), sCadenaConexionSQL)
                    MsgBox("Oferta desactivada correctamente.", vbInformation, "Oferta Expirada")
                End If
                panelofe.Visible = False
            Else
                MsgBox("Password Incorrecto.", vbExclamation, "Oferta Expirada")
                txt_panelofe.Text = ""
                txt_panelofe.Focus()
            End If
            dsc.Tables.Remove("Autoriza")
        Else
            MsgBox("Ingrese código de supervisor.", vbInformation, "Oferta Expirada")
            txt_panelofe.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim valido As Boolean
        Dim DSC As New DataSet
        Dim SQL As String
        valido = False

        If (txt_ctel1.Text = txt_tel1.Text) Then

            'If (txt_ctel1.Text = txt_tel1.Text) And Len(txt_ctel1.Text) = 3 Then
            '    If (txt_ctel2.Text = txt_tel2.Text) And Len(txt_ctel2.Text) = 3 Then
            '        If (txt_ctel3.Text = txt_tel3.Text) And Len(txt_ctel3.Text) = 2 Then
            '            If (txt_ctel4.Text = txt_tel4.Text) And Len(txt_ctel4.Text) = 2 Then
            valido = True
            '            End If
            '        End If
            '    End If
        End If

        If Not valido Then
            MsgBox("Los datos del Número de Teléfono son inválidos, corrija ", MsgBoxStyle.Exclamation)
            txt_ctel1.Text = ""
            txt_ctel2.Text = ""
            txt_ctel3.Text = ""
            txt_ctel4.Text = ""
            txt_tel1.Text = ""
            txt_tel2.Text = ""
            txt_tel3.Text = ""
            txt_tel4.Text = ""
        Else

            datostel = True
            If TIEMPOCOMIS Then
                SQL = "SELECT * FROM XUPC INNER JOIN ARTICULO ON ART_CLAVE=UPC_CVEART WHERE UPC_UPC='980012356'"
                Base.daQuery(SQL, sCadenaConexionSQL, DSC, "ARTICULO")

                If DSC.Tables("articulo").Rows.Count > 0 Then

                    With FpArticulos.ActiveSheet
                        .AddRows(.RowCount, 1)
                        .Rows(.RowCount - 1).Height = 30
                        'agregaArticulo(DSC.Tables("articulo").Rows(0)("upc_upc"), DSC.Tables("articulo").Rows(0)("art_clave"), DSC.Tables("articulo").Rows(0)("art_nomlargo"), CDbl(DSC.Tables("articulo").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("articulo").Rows(0)("ART_PRECIO1")), .RowCount - 1, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), 0, 1, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_IVA")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_IEPS")))
                    End With
                End If

                DSC.Tables.Remove("ARTICULO")
            End If
            Paneltiempo.Visible = False
            TX_UPC.Focus()

        End If

    End Sub


    Private Sub txt_ctel4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ctel4.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub

    Private Sub txt_ctel4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ctel4.KeyDown
        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub
    Private Sub ActivarBloqueoNoEncontrado()
        TX_UPC.Enabled = False
        Panel1.BringToFront()
        Panel1.Top = (Me.Height / 2 - Panel1.Height / 2)
        Panel1.Left = (Me.Width / 2 - Panel1.Width / 2)
        Panel1.Visible = True
        txe.Visible = True
        Label24.Visible = True
        Label2.Visible = False

        cancelacion = False
        Me.l_cancelacion.Visible = False
        ''        TX_UPC.Text = ""

        Me.txe.Focus()
    End Sub
    Private Sub ProcesarHallazgo(ByVal dsc As DataSet, ByVal xtipo As Integer, ByVal cantidad As Decimal, ByVal CargandoPendiente As Boolean, ByVal TraeVale As Boolean, ByVal FueConF1 As Boolean, ByRef cancelacion As Boolean, ByVal FueConF3 As Boolean)

        ' 1. LLENADO BASE DEL OBJETO
        Dim NuevoItem As New ArticuloVenta()

        With NuevoItem
            .UPC = dsc.Tables("articulo").Rows(0)("upc_upc").ToString.Trim
            .Clave = dsc.Tables("articulo").Rows(0)("art_clave").ToString.Trim
            .NombreLargo = dsc.Tables("articulo").Rows(0)("Art_NomLargo").ToString.Trim
            .Familia = dsc.Tables("articulo").Rows(0)("ART_FAMILIA").ToString.Trim
            .CostoCap = CDec(dsc.Tables("articulo").Rows(0)("art_costocap2"))
            .IVA = CDec(dsc.Tables("articulo").Rows(0)("art_iva"))
            .IEPS = CDec(dsc.Tables("articulo").Rows(0)("art_ieps"))
            .TipoOferta = dsc.Tables("articulo").Rows(0)("Tipo_Ofer")
            .CantidadDisponible = dsc.Tables("articulo").Rows(0)("CantidadDisponible")
            .TopeMayoreo = CDec(dsc.Tables("ARTICULO").Rows(0)("ART_TOPEMAY"))
            .TipoVenta = TIPOVENTA

            ' ==========================================================================
            ' Lógica DE OFERTA Y DESCRIPCIÓN (AHORA CON DECIMALES)
            ' ==========================================================================
            Dim EnOferta As Boolean = False

            ' Validamos precios con CDec
            If CDec(dsc.Tables("ARTICULO").Rows(0)("XPRECIO1")) > 0 AndAlso
           CDec(dsc.Tables("ARTICULO").Rows(0)("XPRECIO2")) > 0 AndAlso
           CDec(dsc.Tables("ARTICULO").Rows(0)("XPRECIO3")) > 0 Then

                EnOferta = True
                .Descripcion = dsc.Tables("articulo").Rows(0)("DescOferta").ToString.Trim
            Else
                EnOferta = False
                .Descripcion = dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
            End If

            ' ==========================================================================
            ' Lógica DE CAJAS (TODO CON DECIMAL)
            ' ==========================================================================
            .Factor = 1D
            Dim EsVentaCajaLocal As Boolean = False
            Dim PrecioBaseMayoreo As Decimal = CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO3"))

            ' Caso A: Caja Virtual F6
            ' Nota: CDec(1) es seguro, pero CDec del dataset evita el double
            If VentaCajaVirtual AndAlso CDec(dsc.Tables("articulo").Rows(0)("Factor")) = 1D Then

                ' Multiplicación Decimal pura
                Dim Contenido As Decimal = CDec(dsc.Tables("articulo").Rows(0)("art_cap1")) * CDec(dsc.Tables("articulo").Rows(0)("art_cap2"))

                If Contenido > 1D Then
                    EsVentaCajaLocal = True
                    .Factor = Contenido
                    .Descripcion = "Caja - " & dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim & " (" & dsc.Tables("articulo").Rows(0)("art_cap1") & dsc.Tables("articulo").Rows(0)("art_uni1") & " / " & dsc.Tables("articulo").Rows(0)("art_cap2") & dsc.Tables("articulo").Rows(0)("art_uni2") & ")"
                End If
                .EsCajaVirtual = True
                TX_UPC.BackColor = Color.White

                ' Caso B: Caja Física
            ElseIf CDec(dsc.Tables("articulo").Rows(0)("Factor")) > 1D Then
                EsVentaCajaLocal = True
                .Factor = CDec(dsc.Tables("articulo").Rows(0)("Factor"))
                .Descripcion = dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
            End If

            ' ==========================================================================
            ' Lógica DE PRECIOS
            ' ==========================================================================
            If EsVentaCajaLocal Then
                ' Aritmética decimal segura
                .Precio1 = PrecioBaseMayoreo * .Factor
                .Precio2 = .Precio1
                .Precio3 = .Precio1
            Else
                Select Case .TipoVenta
                    Case 1
                        .Precio1 = IIf(EnOferta, CDec(dsc.Tables("articulo").Rows(0)("XPRECIO1")), CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO1")))
                        .Precio2 = IIf(EnOferta, CDec(dsc.Tables("articulo").Rows(0)("XPRECIO2")), CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO2")))
                        .Precio3 = IIf(EnOferta, CDec(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
                    Case 2
                        .Precio1 = IIf(EnOferta, CDec(dsc.Tables("articulo").Rows(0)("XPRECIO1")), CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO1")))
                        .Precio2 = IIf(EnOferta, CDec(dsc.Tables("articulo").Rows(0)("XPRECIO2")), CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO2")))
                        .Precio3 = IIf(EnOferta, CDec(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
                    Case 3
                        .Precio1 = IIf(EnOferta, CDec(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDec(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
                        .Precio2 = .Precio1
                        .Precio3 = .Precio1
                End Select
            End If

            ' Ofertas guardadas como Decimal
            .PrecioOferta1 = CDec(dsc.Tables("articulo").Rows(0)("XPrecio1"))
            .PrecioOferta2 = CDec(dsc.Tables("articulo").Rows(0)("XPrecio2"))
            .PrecioOferta3 = CDec(dsc.Tables("articulo").Rows(0)("XPrecio3"))

            .EsKilos = (dsc.Tables("articulo").Rows(0)("ART_KILO") = 1)
            .TipoArticulo = xtipo
            .Cantidad = cantidad
            .EsCancelacion = cancelacion
            .CargandoPendiente = CargandoPendiente
            .TraeVale = TraeVale
            .EsBusquedaF1 = FueConF1
            .EsCambioCantidad = FueConF3
        End With
        ' ==========================================================================
        ' 2. DECISIÓN DE NEGOCIO (VENTA vs Cancelación vs CARGA PENDIENTE)
        ' ==========================================================================

        If CargandoPendiente Then
            ' CASO BLINDADO: CARGA PENDIENTE
            ' Si viene de un ticket guardado, RESPETAMOS la cantidad y el signo tal cual vienen.
            ' Si en la BD decía -5, Aquí entra -5. Si decía 0.500, entra 0.500.
            NuevoItem.Cantidad = cantidad

        Else
            ' CASO EN VIVO: Aquí Sí calculamos signos y validamos pausas
            If cancelacion Then
                ' === Cancelación EN VIVO (F2) ===
                If NuevoItem.TipoArticulo = 2 Then
                    ' Si es salchi, invertimos el peso que acabamos de leer
                    NuevoItem.Cantidad = cantidad * -1D
                Else
                    ' Si es normal, restamos 1 unidad por defecto
                    NuevoItem.Cantidad = -1D
                End If
            Else
                ' === VENTA EN VIVO ===
                ' Solo Aquí validamos la pausa para pedir peso manual
                If NuevoItem.EsKilos And NuevoItem.TipoArticulo = 1 Then

                Else
                    NuevoItem.Cantidad = 1
                End If
                ' Si no hubo pausa, la cantidad se queda positiva tal cual llegó (ej. 1 o peso etiqueta)
            End If
        End If

        ' 3. AGREGAR / ACTUALIZAR GRID
        Me.TX_UPC.Text = ""

        Dim FilaFuente As New System.Drawing.Font("Arial", 14, FontStyle.Regular)
        If CargandoPendiente OrElse RecorreSpread(NuevoItem.UPC, NuevoItem.Cantidad, FueConF3) Then
            With FpArticulos.ActiveSheet
                .AddRows(.RowCount, 1)
                .Rows(.RowCount - 1).Height = 30
                .Rows(.RowCount - 1).LockFont = FilaFuente
                BtnCambiaVenta.Enabled = True
                BtnCambiaCliente.Enabled = True

                Dim CantCob As Decimal = -1
                Dim TextoCantidadTemp As Decimal = 0D
                ' Intenta convertir. Si puede, lo guarda en la variable. Si no (vacío o texto), deja el 0.
                Decimal.TryParse(tx_cantidad.Text, TextoCantidadTemp)

                ' también Aquí usamos CDec para las lecturas de SQL
                If CDec(dsc.Tables("Articulo").Rows(0)("CobradosClave")) <> -1D Then
                    CantCob = CDec(dsc.Tables("Articulo").Rows(0)("CobradosClave")) + IIf(TextoCantidadTemp < 0, Math.Abs(TextoCantidadTemp), 0)
                ElseIf CDec(dsc.Tables("Articulo").Rows(0)("CobradosUPC")) <> -1D Then
                    CantCob = CDec(dsc.Tables("Articulo").Rows(0)("CobradosUPC")) + IIf(TextoCantidadTemp < 0, Math.Abs(TextoCantidadTemp), 0)
                End If

                ' Nota: NuevoItem.CantidadCobradas es Integer en tu clase original, 
                ' si quieres precisión decimal ahí también, habría que cambiar la Clase. 
                ' Por ahora lo casteamos a Integer si tu clase lo pide aSí, o lo dejamos pasar si ya lo cambiaste.
                NuevoItem.CantidadCobradas = CInt(CantCob)

                agregaArticulo(NuevoItem)
                If Not cancelacion AndAlso NuevoItem.EsKilos AndAlso NuevoItem.TipoArticulo = 1 And Not CargandoPendiente Then
                    Me.Lkilos.Visible = True
                    Me.tx_cantidad.Text = ""
                    Me.tx_cantidad.Visible = True
                    Me.TX_UPC.Enabled = False
                    .Rows(.RowCount - 1).ForeColor = Color.Black
                    Me.tx_cantidad.Focus()
                End If

                FueConF1 = False
                If VentaCajaVirtual Then
                    VentaCajaVirtual = False
                    ToggleCajaVirtual()
                End If

                Me.sumaSpread()

                If cancelacion Then
                    Me.l_cancelacion.Visible = False
                    Me.autorizame = True
                    cancelacion = False
                End If
            End With
        End If
    End Sub
    Private Sub ProcAgregaArticulo(ByVal Optional CargandoPendiente As Boolean = False, ByVal Optional CantPend As Double = 1, ByVal Optional PendFueConF1 As Integer = 0, ByVal Optional PendFueConF2 As Integer = 0, ByVal Optional PendFueConF3 As Integer = 0, Optional PendTraeVale As String = "", Optional PendFueConF6 As Integer = 0)
        Dim i As Integer
        Dim TOPE As Decimal
        Dim UPCUPC As String
        Dim ArtClave As String
        Dim ArtNomLargo As String
        Dim CostoCap As Decimal
        Dim Familia As String
        Dim UPCDescripcion As String
        Dim Precio1, Precio2, Precio3 As Decimal
        Dim k As Integer

        Dim iva, ieps As Decimal

        Dim sql As String = ""
        Dim dsc As New DataSet
        Dim xtipo As Integer = 1
        Dim cantidad As Decimal = 0
        Dim UPCStr As String
        Dim EsEscaneado As Boolean = False
        Dim FueConF3 As Boolean = False
        Dim TraeVale As Boolean = False

        ' =================================================================================
        ' 1. LIMPIEZA Y Búsqueda F1
        ' =================================================================================
        If Not buscararticulo Then
            Dim TextoLimpio As String = Me.TX_UPC.Text.Trim()
            Dim IndicePrimerNumero As Integer = -1
            For n As Integer = 0 To TextoLimpio.Length - 1
                If Char.IsDigit(TextoLimpio(n)) Then
                    IndicePrimerNumero = n
                    Exit For
                End If
            Next
            If IndicePrimerNumero > 0 Then
                EsEscaneado = True
                TextoLimpio = TextoLimpio.Substring(IndicePrimerNumero)
            Else
                EsEscaneado = False
            End If
            TX_UPC.Text = TextoLimpio
            ' TIP PRO: Aquí Podrías guardar 'EsEscaneado' en tu objeto ArticuloVenta 
            ' si agregas esa propiedad a la clase.
        Else
            Using Busca As New FrBuscaArt(Me)
                Busca.StartPosition = FormStartPosition.CenterParent
                Busca.ShowDialog()
                buscararticulo = False
                If TX_UPC.Text <> "" Then
                    FueConF1 = True
                    ProcAgregaArticulo()
                Else
                    cancelacion = False
                    Me.l_cancelacion.Visible = False
                    TX_UPC.Text = ""
                End If
            End Using
            Exit Sub
        End If
        ' =================================================================================
        ' 2. RECUPERACIÓN DE BANDERAS
        ' =================================================================================

        If CargandoPendiente Then
            FueConF1 = IIf(PendFueConF1 = 1, True, False)
            cancelacion = IIf(PendFueConF2 = 1, True, False)
            FueConF3 = IIf(PendFueConF3 = 1, True, False)
            TraeVale = IIf(PendTraeVale = "*", True, False)
            VentaCajaVirtual = IIf(PendFueConF6 = 1, True, False)
        End If
        ' =================================================================================
        ' 3. ANÁLISIS PREVIO (Detectar Báscula)
        ' =================================================================================
        If Me.TX_UPC.Text.Length = 13 AndAlso Me.TX_UPC.Text.StartsWith("2000") Then
            UPCStr = Me.TX_UPC.Text.Substring(0, 7)
            xtipo = 2
            Dim pesoStr As String = Me.TX_UPC.Text.Substring(7, 5)
            Dim pesoRaw As Decimal
            If Decimal.TryParse(pesoStr, pesoRaw) Then
                cantidad = pesoRaw / 100D
            Else
                cantidad = 0
            End If
        Else
            UPCStr = TX_UPC.Text
            xtipo = 1
            cantidad = 0
        End If

        If CargandoPendiente Then
            cantidad = CDec(CantPend)
        End If
        ' =================================================================================
        ' 4. CONSULTA SQL "TODO INCLUIDO" (Activos e Inactivos)
        ' =================================================================================
        ' NOTA: Eliminamos "and art_activo=1" del WHERE para traerlo aunque está bloqueado
        ' Agregamos art_activo y upc_activo al SELECT para validarlos en código

        sql = "select xupc.upc_activo, articulo.art_activo, isnull(tipo_ofer,0) Tipo_Ofer, art_clave, isnull(ECBOLETINOFER.ARTICULO,'') Articulo, upc_descripcion, Art_NomLargo, Art_CostoCap2, ART_FAMILIA, isnull(ECBOLETINOFER.DescOferta,'') DescOferta, isnull(CantidadDisponible,-1) CantidadDisponible, ISNULL(ECBOLETINOFER.Cantidad,0) Cantidad, isnull(PorcentajeDescuento,'') PorcentajeDescuento, isnull(ID,'') ID, isnull(Fam_Clave,'') Fam_Clave, isnull(ClaveMarca,-1) ClaveMarca, isnull(t2a.CantidadCobrados,-1) CobradosUPC ,isnull(t2c.CantidadCobrados,-1) CobradosClave," &
          "isnull(ECBOLETINOFER.UPC_CodInv,'') UPCCodInvOferta, xupc.upc_codinv, ART_PRECIO1, isnull(XPRECIO1,art_precio1*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO1, ART_PRECIO2, isnull(XPRECIO2,art_precio2*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO2, ART_PRECIO3,isnull(XPRECIO3,art_precio3*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO3, " &
          "isnull(art_kilo,0) ART_KILO ,ISNULL(art_entrega,0) ART_ENTREGA, ISNULL(xupc.upc_factor,1) as Factor, art_cap1, art_uni1, art_cap2, art_uni2, art_topemay, art_iva, art_ieps, upc_upc from xupc inner join articulo on upc_cveart=art_Clave " &
          "LEFT JOIN ECBOLETINOFER ON ((((ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv is null) or (ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv=XUPC.UPC_CODINV)) or ART_FAMILIA=Fam_Clave or art_marca=ClaveMarca) AND ((FECHAINI<='" & Format(Today, "yyyyMMdd") & "' AND FECHAFIN>='" & Format(Today, "yyyyMMdd") & "') or (CantidadDisponible>0 and Cantidad>0)) and Activo=1) " &
          "left join (select ARTICULO, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by articulo) t2a on (t2a.ARTICULO=ECBOLETINOFER.UPC_CodInv and TIPO_OFER=1) " &
          "left join (select ArtClave, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by ArtClave) t2c on (t2c.ArtClave=ECBOLETINOFER.ARTICULO and TIPO_OFER=2 ) " &
          "where (upc_upc = '" & UPCStr & "')" ' <-- YA NO FILTRAMOS ACTIVOS AQUI

        ' Cero Fantasma (Sin filtrar activos)
        If Me.TX_UPC.Text.Length > 7 AndAlso Not (Me.TX_UPC.Text.Length = 13 AndAlso Me.TX_UPC.Text.StartsWith("2000")) Then
            sql = sql & " or (upc_upc='" & "0" & Me.TX_UPC.Text & "')"
        End If

        sql = sql & " order by XPRECIO1 asc, CantidadDisponible desc, UPCCodInvOferta desc"
        Base.daQuery(sql, sCadenaConexionSQL, dsc, "articulo")
        ' =================================================================================
        ' 5. VALIDACIÓN INTELIGENTE (EN MEMORIA)
        ' =================================================================================
        If dsc.Tables("articulo").Rows.Count > 0 Then
            ' A) CHEQUEO DE ACTIVOS (Aquí REEMPLAZAMOS EL VIAJE EXTRA)
            ' Revisamos si el Artículo o el código están dados de baja
            ' Convertimos a Boolean de forma segura
            Dim ArtActivo As Boolean = False
            Dim UpcActivo As Boolean = False

            ' Validamos nulos por si acaso
            If Not IsDBNull(dsc.Tables("articulo").Rows(0)("art_activo")) Then
                ArtActivo = (dsc.Tables("articulo").Rows(0)("art_activo") = 1)
            End If
            If Not IsDBNull(dsc.Tables("articulo").Rows(0)("upc_activo")) Then
                UpcActivo = (dsc.Tables("articulo").Rows(0)("upc_activo") = 1)
            End If

            If ArtActivo AndAlso UpcActivo Then
                ' -> TODO BIEN: PROCESAMOS LA VENTA
                ProcesarHallazgo(dsc, xtipo, cantidad, CargandoPendiente, TraeVale, FueConF1, cancelacion, FueConF3)
            Else
                ' -> EXISTE PERO está INACTIVO
                MsgBox("El Artículo se encuentra inactivo.", MsgBoxStyle.Exclamation, "Punto de Venta")
                Label24.Text = "Artículo INACTIVO"
                ActivarBloqueoNoEncontrado() ' Llamada al sub de bloqueo visual
            End If
        Else
            ' =============================================================================
            ' 6. NO ENCONTRADO REAL
            ' =============================================================================
            MsgBox("Producto no encontrado.", MsgBoxStyle.Exclamation, "Punto de Venta")

            Label24.Text = "PRODUCTO NO ENCONTRADO"
            ActivarBloqueoNoEncontrado()


        End If
    End Sub

    Private Sub txt_panelofe_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_panelofe.KeyDown
        If e.KeyCode = Keys.Enter Then
            ActualizaOferta()
        End If
    End Sub

    Private Sub BtnCambiaVenta_Click(sender As Object, e As EventArgs) Handles BtnCambiaVenta.Click
        ' 1. Confirmación INICIAL
        If MsgBox("¿Desea cambiar el tipo de venta?", vbYesNo + vbQuestion, "Punto de Venta") = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim VentaOrig As Integer = CInt(Val(txt_tipoventa.Text))
        Dim ClienteOrig As Integer = CInt(Val(TxtControl.Text))
        Dim ClienteOrigStr As String = LbClienteTicket.Text

        Dim NuevoTipoVenta As Integer = -1
        Dim NuevoClienteID As Integer = ClienteOrig ' Por defecto, es el mismo cliente

        Dim EntradaValida As Boolean = False
        Dim ResTxt As String = ""

        ' 2. BUCLE DE CAPTURA DE TIPO DE VENTA
        Do Until EntradaValida
            ResTxt = InputBox("Indique el nuevo tipo de venta (1, 2 o 3):", "Cambiar Tipo de Venta", "")

            ' Si cancela o deja vacío, salimos
            If String.IsNullOrWhiteSpace(ResTxt) Then Exit Sub

            If IsNumeric(ResTxt) Then
                NuevoTipoVenta = CInt(ResTxt)

                ' Validaciones básicas
                If NuevoTipoVenta < 1 Or NuevoTipoVenta > 3 Then
                    MsgBox("El tipo de venta debe ser 1, 2 o 3.", vbExclamation)

                ElseIf NuevoTipoVenta = VentaOrig Then
                    MsgBox("El tipo de venta seleccionado es igual al actual.", vbInformation)
                    Exit Sub ' Si es igual, no hacemos nada y salimos

                Else
                    ' --- Aquí VIENE LA Lógica FUERTE DEL TIPO 3 ---
                    If NuevoTipoVenta = 3 Then
                        ' Verificamos si el cliente ACTUAL soporta Precio 3
                        If ClienteSoportaDuarsa(NuevoClienteID) Then
                            EntradaValida = True ' Todo bien, seguimos
                        Else
                            ' El cliente actual NO soporta Precio 3. Buscamos uno que Sí.
                            MsgBox("El cliente actual no tiene permiso para Precio Duarsa (3)." & vbCrLf &
                               "Seleccione un cliente autorizado.", vbInformation)

                            Dim ResultadoBusqueda As Integer = BuscarClienteDuarsa()

                            If ResultadoBusqueda > 0 Then
                                ' Encontró un cliente válido
                                NuevoClienteID = ResultadoBusqueda
                                ' Actualizamos visualmente el nombre (necesitarías traer el nombre del buscador o BD)
                                ' Para simplificar, asumo que BuscarClienteDuarsa ya actualizó TxtControl o retornó ID
                                EntradaValida = True
                            Else
                                ' Canceló la Búsqueda -> Cancelamos el cambio de venta
                                Exit Sub
                            End If
                        End If
                    Else
                        ' Si es tipo 1 o 2, pasa directo
                        EntradaValida = True
                    End If
                End If
            Else
                MsgBox("Debe ingresar un valor numérico.", vbExclamation)
            End If
        Loop

        ' 3. Lógica DE Autorización INTELIGENTE
        ' Regla: Solo pedimos Autorización si "Mejora" el precio (Sube de nivel: 1->2, 1->3, 2->3)
        ' O si bajamos de nivel (3->1), NO pedimos Autorización (porque cobramos más caro).

        Dim RequiereAuth As Boolean = False

        If NuevoTipoVenta > VentaOrig Then RequiereAuth = True

        ' Si cambió de cliente a uno VIP, también pedimos auth por seguridad
        If ClienteOrig <> NuevoClienteID Then RequiereAuth = True

        If RequiereAuth Then
            AutorizaCierreCambioVentana = False
            Using oforma1 As New paraautorizarSALIDA(Me, Nothing, CambiandoVenta:=True)
                oforma1.StartPosition = FormStartPosition.CenterScreen
                oforma1.ShowDialog()
            End Using

            If Not AutorizaCierreCambioVentana Then
                ' No autorizó -> Revertimos y salimos
                ' (Como no hemos cambiado nada en la UI todavía, solo hacemos Exit Sub)
                ' Pero si cambiamos el TxtControl en la Búsqueda, hay que regresarlo:
                If ClienteOrig <> NuevoClienteID Then
                    TxtControl.Text = ClienteOrig.ToString()
                    LbClienteTicket.Text = ClienteOrigStr
                End If
                Exit Sub
            End If
        End If
        ' 4. APLICAR CAMBIOS
        ' Actualizamos los controles visuales antes de llamar al proceso
        txt_tipoventa.Text = NuevoTipoVenta.ToString()
        TIPOVENTA = NuevoTipoVenta

        ' Si cambió el cliente en el proceso (por la Búsqueda de Duarsa)
        If ClienteOrig <> NuevoClienteID Then
            TxtControl.Text = NuevoClienteID.ToString()
            ' Nota: LbClienteTicket ya debería haberse actualizado en la Búsqueda o Aquí
            ObtenerNombreCliente(NuevoClienteID) ' Helper opcional para actualizar el label
        End If

        ' Recalculamos todo el grid
        ActualizaPrecioTipoVenta(NuevoTipoVenta, NuevoClienteID, VentaOrig)

        TX_UPC.Focus()
    End Sub
    Private Function ClienteSoportaDuarsa(ByVal IDCliente As Integer) As Boolean
        Dim SQL As String = "SELECT PrecioDuarsa FROM ECClientes WHERE cli_clave=" & IDCliente & " AND PrecioDuarsa=1"
        Using DSC As New DataSet
            Base.daQuery(SQL, sCadenaConexionSQL, DSC, "Existe")
            Return (DSC.Tables("Existe").Rows.Count > 0)
        End Using
    End Function
    Private Function BuscarClienteDuarsa() As Integer
        Dim IDEncontrado As Integer = 0

        Using frmbuscar As New busqueda
            frmbuscar.TXTCONTROL = Me.txt_foliopago ' Control dummy
            ' Configuramos la Búsqueda filtrada por PrecioDuarsa=1
            GENERAL.parametrosbusqueda(frmbuscar, "Precio Duarsa - Clientes Registrados",
                                   "cli_clave,cli_nombre", "ecclientes", "cli_nombre asc", "1",
                                   sCadenaConexionSQL, "Clave,Nombre", "50,500", "A,A", "1,2",
                                   "precioduarsa=1", "") ' Filtro WHERE

            frmbuscar.TXTCONTROL = TxtControl ' Control destino real
            frmbuscar.StartPosition = FormStartPosition.CenterScreen
            frmbuscar.ShowDialog()
        End Using

        ' Validamos si seleccionó algo
        If TxtControl.Text.Trim <> "" AndAlso TxtControl.Text.Contains(",") Then
            ' El buscador suele devolver "ID, Nombre" o similar en el TxtControl
            Dim TmpStr() As String = TxtControl.Text.Trim.Split(",")
            IDEncontrado = CInt(Val(TmpStr(0)))

            ' Actualizamos Labels Aquí mismo para no perder el dato del nombre
            TxtControl.Text = IDEncontrado.ToString()
            LbClienteTicket.Text = "Cliente: " & TmpStr(1).Trim
        Else
            ' Si Canceló o el formato es raro
            IDEncontrado = 0
        End If

        Return IDEncontrado
    End Function

    Private Sub ObtenerNombreCliente(ByVal ID As Integer)
        ' pequeña rutina para refrescar el nombre si solo tenemos el ID
        Dim SQL As String = "SELECT cli_nombre FROM ECClientes WHERE cli_clave=" & ID
        Using DSC As New DataSet
            Base.daQuery(SQL, sCadenaConexionSQL, DSC, "Nom")
            If DSC.Tables("Nom").Rows.Count > 0 Then
                LbClienteTicket.Text = "Cliente: " & DSC.Tables("Nom").Rows(0)("cli_nombre").ToString()
            End If
        End Using
    End Sub
    Private Sub ActualizaPrecioTipoVenta(ByVal NuevoTipoVenta As Integer, ByVal ClienteID As Integer, ByVal VentaOrig As Integer)
        Dim SQL As String
        If NuevoTipoVenta <> -1 Then
            If NuevoTipoVenta <> 3 OrElse (NuevoTipoVenta = 3 And ClienteID <> -1) Then
                SQL = "update tmpauxvta2 set tipo=" & NuevoTipoVenta & ", ClienteID=" & ClienteID & " where usuario='" & Globales.caja & "' and tipo=" & VentaOrig
                Try
                    Base.Ejecuta(SQL, sCadenaConexionSQL)
                    limpiaSpread(CambiandoTipoVenta:=True)
                Catch ex As Exception
                    MsgBox("No pudo modificarse el tipo de venta.", vbExclamation, "Punto de Venta")
                End Try
            End If
        End If
    End Sub
    Private Sub tx_cantidad_VisibleChanged(sender As Object, e As EventArgs) Handles tx_cantidad.VisibleChanged
        If tx_cantidad.Visible Then
            BtnCambiaVenta.Enabled = False
            BtnCambiaCliente.Enabled = False
        Else
            BtnCambiaVenta.Enabled = True
            BtnCambiaCliente.Enabled = True
        End If
    End Sub

    Private Sub txt_tipoventa_EnabledChanged(sender As Object, e As EventArgs) Handles txt_tipoventa.EnabledChanged
        If txt_tipoventa.Enabled Then
            BtnCambiaVenta.Enabled = False
            BtnCambiaCliente.Enabled = False
        Else
            If FpArticulos.ActiveSheet.RowCount > 0 Then
                BtnCambiaVenta.Enabled = True
                BtnCambiaCliente.Enabled = True
            End If
        End If
    End Sub

    Private Sub FPs_GotFocus(sender As Object, e As EventArgs) Handles FpArticulos.GotFocus, FpFormasPago.GotFocus
        Dim Res As MsgBoxResult
        If Not Corriendo Then
            If grformapago.Visible Then
                If PanelSeleccionTarjetas.Visible = False Then
                    If sender.name = FpArticulos.Name Then
                        Corriendo = True
                        If MsgBox("¿Desea cerrar ventana de pagos?", vbYesNo, "Cerrar Pagos") = MsgBoxResult.Yes Then
                            borrapagos()
                            SendKeys.Flush()
                        Else
                            Res = MsgBoxResult.No
                        End If
                        Corriendo = False
                    End If
                    If Res = MsgBoxResult.No Or sender.name = FpFormasPago.Name Then
                        If fpago = 1 Or fpago = 2 Then
                            If tx_cantidad.Visible Then
                                tx_cantidad.Focus()
                            Else
                                TX_UPC.Focus()
                            End If
                        ElseIf fpago = 3 Or fpago = 6 Or fpago = 7 Then
                            If TXB_BANCO.Visible Then
                                TXB_BANCO.Focus()
                            Else
                                If tx_cantidad.Visible Then
                                    tx_cantidad.Focus()
                                Else
                                    TX_UPC.Focus()
                                End If
                            End If
                        ElseIf fpago = 4 Then
                            If txb_credito.Visible Then
                                txb_credito.Focus()
                            Else
                                If tx_cantidad.Visible Then
                                    tx_cantidad.Focus()
                                Else
                                    TX_UPC.Focus()
                                End If
                            End If
                        End If
                    End If
                Else
                    If TipoTarj = "" Then
                        Corriendo = True
                        If MsgBox("No ha seleccionado el tipo de tarjeta, ¿Desea cerrar ventana de tarjetas?", vbYesNo, "Cerrar Pagos") = MsgBoxResult.Yes Then
                            borrapagos()
                            CierraPanel()
                            SendKeys.Flush()
                        Else
                            rbTDebito.Focus()
                        End If
                        Corriendo = False
                    Else
                        If sender.name = FpArticulos.Name Then
                            Corriendo = True
                            If MsgBox("¿Desea cerrar ventana de pagos?", vbYesNo, "Cerrar Pagos") = MsgBoxResult.Yes Then
                                PanelSeleccionTarjetas.Visible = False
                                borrapagos()
                                SendKeys.Flush()
                            Else
                                MsgBox("Debe seleccionar primero el tipo de tarjeta.", vbExclamation, "Selección de Tarjeta")
                                If TipoTarj = rbTCredito.Tag Then
                                    rbTCredito.Focus()
                                ElseIf TipoTarj = rbTDebito.Tag Then
                                    rbTDebito.Focus()
                                End If
                            End If
                            Corriendo = False
                        Else
                            If TipoTarj = rbTCredito.Tag Then
                                rbTCredito.Focus()
                            ElseIf TipoTarj = rbTDebito.Tag Then
                                rbTDebito.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub BtnCierraPanel_Click_1(sender As Object, e As EventArgs) Handles BtnCierraPanel.Click
        CierraPanel()
    End Sub

    Private Sub BtnRegistraTarjeta_Click(sender As Object, e As EventArgs) Handles BtnRegistraTarjeta.Click
        RegistraTarjeta()
    End Sub

    Private Sub rbTCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles rbTCredito.KeyDown, rbTDebito.KeyDown
        If e.KeyCode = Keys.Escape Then
            CierraPanel()
        ElseIf e.KeyCode = Keys.Enter Then
            RegistraTarjeta()
        End If
    End Sub

    Private Sub RegistraTarjeta()
        ' 1. Limpieza inicial de UI
        PanelSeleccionTarjetas.Visible = False

        ' 2. Calculamos el saldo base (Lo que falta por pagar)
        ' Usamos Decimal para precisión financiera
        Dim SaldoPendiente As Decimal = CDec(totalote - totalpagos)

        ' VALIDACIÓN de seguridad: Si ya no debe nada, no entramos.
        If SaldoPendiente <= 0 Then
            MsgBox("El Monto pagado hasta el momento ya salda el ticket.", vbExclamation, "Monto Incorrecto")
            LimpiarControlesPago() ' Sugiero encapsular la limpieza en un Sub
            Exit Sub
        End If

        ' 3. CÁLCULO de Comisión (El "Castigo" por pagar con tarjeta en Mayoreo)
        Dim MontoComision As Decimal = 0D

        If TIPOVENTA > 1 Then
            ' CASO A: Venta Mayoreo o Duarsa (2 o 3)
            ' Se cobra Comisión del 2%.
            Dim CalculoTeorico As Decimal = SaldoPendiente * 0.02D

            ' Llamamos a tu función existente para validar topes
            ' Asumo que AlcanzaComision devuelve el importe en Decimal/Double
            MontoComision = CDec(AlcanzaComision(Math.Round(CalculoTeorico, 2), False))
            DistribuyeComConP1(MontoComision)
            ' Actualizamos la variable global para que se guarde luego
            TotalComision = MontoComision
        Else
            ' CASO B: Venta Público (1)
            ' No se cobra Comisión.
            MontoComision = 0D
            TotalComision = 0D
        End If

        ' 4. Determinar Tipo de Tarjeta (Texto informativo)
        If rbTCredito.Checked Then
            TipoTarj = "Crédito"
        ElseIf rbTDebito.Checked Then
            TipoTarj = "Débito"
        Else
            TipoTarj = "Tarjeta" ' Fallback
        End If

        ' 5. Preparar UI para cobrar
        Label18.Text = "No. Autorización: " ' "Referencia" es ambiguo, Autorización es lo que imprime el voucher
        LFORPAG.Text = "Tarjeta"
        LFORPAG.Visible = True

        ' 6. El monto a cobrar FINAL (Saldo + Comisión)
        Dim TotalACobrar As Decimal = SaldoPendiente + MontoComision

        ' Mostramos formateado a 2 decimales
        tx_cantidad.Text = TotalACobrar.ToString("N2")
        tx_cantidad.Visible = True

        ' 7. Configuración de focos y controles
        banco.Visible = True
        fpago = 6           ' ID de pago Tarjeta
        TX_UPC.Enabled = False

        ' Foco: Normalmente el flujo es -> Confirmar Monto (Enter) -> Escribir Autorización.
        ' Si prefieres ir directo a Autorización:
        Me.TXB_BANCO.Focus()
    End Sub
    ' Helper para limpiar (puedes pegarlo al final de tu form)
    Private Sub LimpiarControlesPago()
        LFORPAG.Visible = False
        tx_cantidad.Text = ""
        tx_cantidad.Visible = False
        TXB_BANCO.Text = ""
        TX_UPC.Enabled = True
        TX_UPC.Text = ""
        TX_UPC.Focus()
    End Sub
    Private Sub CierraPanel()
        'Solo quita tarjeta         
        'QuitaComision()
        TX_UPC.Enabled = True
        TipoTarj = ""
        PanelSeleccionTarjetas.Visible = False
        TX_UPC.Focus()
        ''''
    End Sub

    Private Sub CambiaCliente(ByVal ClienteOrig As Integer, ByVal ClienteOrigStr As String, ByVal RequiereAutorizacion As Boolean)
        Dim VentaOrig As Integer = CInt(txt_tipoventa.Text)
        Dim NuevoClienteID As Integer = 0
        Dim NuevoClienteNombre As String = ""
        Dim EsPrecioDuarsa As Boolean = False

        Using frmbuscar As New busqueda
            frmbuscar.TXTCONTROL = TxtControl ' Pasamos referencia del control

            ' Nota: Asumo que GENERAL.parametrosbusqueda configura el grid del buscador
            GENERAL.parametrosbusqueda(frmbuscar, "Clientes Registrados",
                                   "cli_clave,CLI_NOMBRE,PrecioDuarsa",
                                   "ecclientes", "Cli_nombre desc", "1",
                                   sCadenaConexionSQL,
                                   "Clave,Nombre,Precio Duarsa",
                                   "80,250,80", "A,A,A", "1,3,2", "", "")
            frmbuscar.StartPosition = FormStartPosition.CenterScreen
            frmbuscar.ShowDialog()
        End Using

        ' =========================================================
        ' 2. VALIDACIÓN DEL RESULTADO (Parsing seguro)
        ' =========================================================
        ' Si el control está vacío o igual al original, no hacemos nada (Cancelaron)
        If TxtControl.Text.Trim = "" OrElse TxtControl.Text.Trim = ClienteOrig.ToString() Then
            TxtControl.Text = ClienteOrig.ToString()
            LbClienteTicket.Text = ClienteOrigStr
            TX_UPC.Focus()
            Exit Sub
        End If

        ' Intentamos leer el formato "ID, PrecioDuarsa, Nombre"
        ' Ejemplo esperado: "105, 1, Juan Perez"
        Dim TmpArr() As String = TxtControl.Text.Trim.Split(",")

        If TmpArr.Length >= 3 Then
            NuevoClienteID = CInt(Val(TmpArr(0).Trim))
            EsPrecioDuarsa = (TmpArr(1).Trim = "1")
            NuevoClienteNombre = TmpArr(2).Trim

            ' Actualizamos UI temporalmente
            TxtControl.Text = NuevoClienteID.ToString()
            LbClienteTicket.Text = "Cliente: " & NuevoClienteNombre
        Else
            MsgBox("Error al leer los datos del cliente seleccionado. Formato incorrecto.", vbExclamation)
            RevertirCambios(ClienteOrig, ClienteOrigStr, VentaOrig)
            Exit Sub
        End If

        ' =========================================================
        ' 3. Lógica DE TIPO DE VENTA (DUARSA VS NORMAL)
        ' =========================================================
        Dim NuevoTipoVenta As Integer = VentaOrig

        If EsPrecioDuarsa Then
            ' CASO A: Es Cliente VIP (Duarsa) -> Forzamos Venta 3
            NuevoTipoVenta = 3

        Else
            ' CASO B: Cliente Normal
            ' Si estábamos en Venta 3 (Duarsa) y cambiamos a cliente normal, NO podemos seguir en 3.
            If VentaOrig = 3 Then
                ' Opción 1: Preguntar (Tu Lógica original mejorada)
                Dim ResTxt As String = InputBox("El cliente seleccionado NO tiene precio especial (Duarsa)." & vbCrLf &
                                            "El tipo de venta actual es 3." & vbCrLf & vbCrLf &
                                            "Ingrese '1' para Público o '2' para Medio Mayoreo:", "Ajuste de Precio", "1")

                If ResTxt.Trim = "1" Or ResTxt.Trim = "2" Then
                    NuevoTipoVenta = CInt(ResTxt)
                Else
                    ' Si cancela o pone basura, abortamos el cambio de cliente
                    MsgBox("Cambio de cliente cancelado. Debe definir un tipo de venta válido.", vbInformation)
                    RevertirCambios(ClienteOrig, ClienteOrigStr, VentaOrig)
                    Exit Sub
                End If
                ' Reactivamos para que pueda cambiarlo manualmente después
            Else
                ' Si no estábamos en 3, mantenemos la venta que tenía (1 o 2)
                NuevoTipoVenta = VentaOrig
            End If
        End If

        ' Actualizamos visualmente el tipo de venta
        txt_tipoventa.Text = NuevoTipoVenta
        txt_tipoventa.Enabled = False
        TIPOVENTA = NuevoTipoVenta

        ' =========================================================
        ' 4. Autorización (Si aplica)
        ' =========================================================
        Dim DebePedirAutorizacion As Boolean = False

        ' REGLA 1: Si pasamos a un "Mejor Nivel de Precio" (Descuento)
        ' Asumimos: 1=Caro(Público), 2=Medio, 3=Barato(VIP)
        ' Si el Nuevo es MAYOR que el Viejo (ej. 1 -> 3), estamos dando precio especial.
        If NuevoTipoVenta > VentaOrig Then
            DebePedirAutorizacion = True
        End If

        ' REGLA 2: Si es Específicamente Precio 3 (Duarsa), SIEMPRE pedir (Tu regla actual)
        If NuevoTipoVenta = 3 Then
            DebePedirAutorizacion = True
        End If

        ' EXCEPCIóN: Si simplemente estamos corrigiendo un error (mismo precio, diferente nombre)
        ' y no es precio 3, a veces no hace falta, pero dejémoslo seguro.

        ' REGLA FINAL: Solo si el argumento original era True Y nuestras reglas dicen que Sí
        If RequiereAutorizacion AndAlso DebePedirAutorizacion AndAlso ClienteOrig <> NuevoClienteID Then
            AutorizaCierreCambioVentana = False

            Using oforma1 As New paraautorizarSALIDA(Me, Nothing, CambiandoCliente:=True)
                oforma1.StartPosition = FormStartPosition.CenterScreen
                oforma1.ShowDialog()
            End Using

            If Not AutorizaCierreCambioVentana Then
                ' No autorizó -> Revertimos todo
                RevertirCambios(ClienteOrig, ClienteOrigStr, VentaOrig)
                Exit Sub
            End If
        End If

        ' =========================================================
        ' 5. FINALIZAR Y RECALCULAR
        ' =========================================================
        ' Si llegamos Aquí, el cambio es firme.
        ' Llamamos a tu rutina que actualiza el grid con los nuevos precios
        ActualizaPrecioTipoVenta(NuevoTipoVenta, NuevoClienteID, VentaOrig)

        TX_UPC.Focus()
    End Sub
    ' Helper para no repetir código de reversión
    Private Sub RevertirCambios(ByVal ID As Integer, ByVal Nombre As String, ByVal Venta As Integer)
        TxtControl.Text = ID.ToString()
        LbClienteTicket.Text = Nombre
        txt_tipoventa.Text = Venta
        TIPOVENTA = Venta
        ' Regresamos el estado habilitado original (asumiendo Lógica estándar)
        If Venta = 3 Then txt_tipoventa.Enabled = False Else txt_tipoventa.Enabled = True
        TX_UPC.Focus()
    End Sub
    Private Sub BtnCambiaCliente_Click(sender As Object, e As EventArgs) Handles BtnCambiaCliente.Click
        If MsgBox("¿Desea cambiar el cliente?", vbYesNo, "Punto de Venta") = MsgBoxResult.Yes Then
            CambiaCliente(TxtControl.Text, LbClienteTicket.Text, True)
        Else
            TX_UPC.Focus()
        End If
    End Sub

    Public Sub SacaProporcionP1P2(ByVal NumTicket As Double)

        Dim CuantosMen As Integer = 0
        Dim CuantosMay As Integer = 0
        Dim Ratio As Decimal = 0

        ' =========================================================
        ' 1. CÁLCULO DIRECTO (Usando Using para el DataSet)
        ' =========================================================
        Dim SQL As String = "SELECT " &
                        "ISNULL(SUM(CASE WHEN ART_PRECIO1 = TMP_PRECIO THEN 1 ELSE 0 END), 0) AS CuantosMen, " &
                        "ISNULL(SUM(CASE WHEN ART_PRECIO1 <> TMP_PRECIO THEN 1 ELSE 0 END), 0) AS CuantosMay " &
                        "FROM tmpauxvta1 " &
                        "JOIN articulo ON TMP_ARTICULO = ART_CLAVE " &
                        "WHERE TMP_USUARIO = '" & Globales.caja & "'"

        ' EL CAMBIO CLAVE: Using crea, usa y mata el objeto automáticamente
        Using DSC As New DataSet
            Try
                Base.daQuery(SQL, sCadenaConexionSQL, DSC, "Proporcion")

                If DSC.Tables("Proporcion").Rows.Count > 0 Then
                    CuantosMen = CInt(DSC.Tables("Proporcion").Rows(0)("CuantosMen"))
                    CuantosMay = CInt(DSC.Tables("Proporcion").Rows(0)("CuantosMay"))
                End If

                ' Aquí YA NO NECESITAS Tables.Remove NI Dispose. 
                ' Al llegar al 'End Using', el dataset muere en paz.

            Catch ex As Exception
                MsgBox("Advertencia: No se pudo calcular la estadística del ticket. " & ex.Message)
                Exit Sub
            End Try
        End Using

        ' =========================================================
        ' 2. CÁLCULO MATEMÁTICO SEGURO
        ' =========================================================
        Dim TotalLineasTicket As Integer = CuantosMen + CuantosMay

        If TotalLineasTicket > 0 Then
            Ratio = Math.Round(CDec(CuantosMay) / CDec(TotalLineasTicket), 3)
        Else
            Ratio = 0
        End If

        ' =========================================================
        ' 3. INSERTADO
        ' =========================================================
        Try
            SQL = "INSERT INTO ProporcionVentaTicket " &
              "(NumTicket, PrecioMay, PrecioMen, TotalTicket, Usuario, ProporcionMayMen) " &
              "VALUES " &
              "('" & NumTicket & "', " & CuantosMay & ", " & CuantosMen & ", " &
              totalote & ", '" & Globales.nombreusuario & "', " & Ratio & ")"

            Base.Ejecuta(SQL, sCadenaConexionSQL)

        Catch ex As Exception
            MsgBox("Error al guardar estadística de proporción: " & ex.Message)
        End Try

    End Sub

    Private Sub FormateaSpread()
        Dim ColFormatting As New List(Of DiseñaSpread)
        ColFormatting.Add(New DiseñaSpread(Name:="Forma de Pago", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=100, RowIndex:=0, ColIndex:=0, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Importe", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=100, RowIndex:=0, ColIndex:=1, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Referencia", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=310, RowIndex:=0, ColIndex:=2, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting.Add(New DiseñaSpread(Name:="Tipo Tarjeta", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=90, RowIndex:=0, ColIndex:=3, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))


        Dim ColFormatting1 As New List(Of DiseñaSpread)
        ColFormatting1.Add(New DiseñaSpread(Name:="Cantidad", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=120, RowIndex:=0, ColIndex:=0, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.NumeroCon4Decimal, ColVisible:=True, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Artículo", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=500, RowIndex:=0, ColIndex:=1, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Precio", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=114, RowIndex:=0, ColIndex:=2, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=True, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Total", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=170, RowIndex:=0, ColIndex:=3, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=True, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="UPC CodInv", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=60, RowIndex:=0, ColIndex:=4, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Vale", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=50, RowIndex:=0, ColIndex:=5, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.Texto, ColVisible:=True, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="% IVA", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=70, RowIndex:=0, ColIndex:=6, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.NumeroConDecimal, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="F1", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=50, RowIndex:=0, ColIndex:=7, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.NumeroSinDecimal, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="F2", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=50, RowIndex:=0, ColIndex:=8, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.NumeroSinDecimal, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="F3", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=50, RowIndex:=0, ColIndex:=9, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.NumeroSinDecimal, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="% IEPS", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=70, RowIndex:=0, ColIndex:=10, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.NumeroConDecimal, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="ArtClave", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=110, RowIndex:=0, ColIndex:=11, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="NomLargo", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=280, RowIndex:=0, ColIndex:=12, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Familia", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=90, RowIndex:=0, ColIndex:=13, ColAlign:=CellHorizontalAlignment.Left, ColType:=DiseñaSpread.Texto, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="CostoCap2", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=114, RowIndex:=0, ColIndex:=14, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="TipoOferta", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=106, RowIndex:=0, ColIndex:=15, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.NumeroSinDecimal, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Precio1", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=90, RowIndex:=0, ColIndex:=16, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Comisión", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=100, RowIndex:=0, ColIndex:=17, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.Dinero, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="Factor", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=100, RowIndex:=0, ColIndex:=18, ColAlign:=CellHorizontalAlignment.Right, ColType:=DiseñaSpread.NumeroConDecimal, ColVisible:=False, ColLocked:=True))
        ColFormatting1.Add(New DiseñaSpread(Name:="F6", ColHeaderRows:=2, ColHeaderCols:=1, ColWidth:=50, RowIndex:=0, ColIndex:=19, ColAlign:=CellHorizontalAlignment.Center, ColType:=DiseñaSpread.NumeroSinDecimal, ColVisible:=False, ColLocked:=True))



        DiseñaSpread.DiseñaSpreadsGenérico(FpFormasPago, ColFormatting)
        ConfiguraSpread.ConfiguraSpread(FpFormasPago)


        DiseñaSpread.DiseñaSpreadsGenérico(FpArticulos, ColFormatting1)
        ConfiguraSpread.ConfiguraSpread(FpArticulos)
    End Sub



    ' =================================================================================
    ' CLASE: ArticuloVenta
    ' OBJETO: Contenedor de datos para pasar información limpia entre procesos.
    ' =================================================================================
    Public Class ArticuloVenta
        ' Identificadores
        Public Property UPC As String
        Public Property Clave As String
        Public Property Descripcion As String
        Public Property NombreLargo As String
        Public Property Familia As String

        ' Precios y Costos
        Public Property CostoCap As Decimal
        Public Property Precio1 As Decimal
        Public Property Precio2 As Decimal
        Public Property Precio3 As Decimal
        Public Property PrecioOferta1 As Decimal = -1
        Public Property PrecioOferta2 As Decimal = -1
        Public Property PrecioOferta3 As Decimal = -1

        ' Lógica de Venta
        Public Property Renglon As Integer
        Public Property TopeMayoreo As Decimal
        Public Property TipoVenta As Integer ' 1, 2, 3
        Public Property ClienteID As Integer = 0
        Public Property Cantidad As Decimal
        Public Property CantidadDisponible As Integer = -1
        Public Property CantidadCobradas As Integer = 0

        ' Impuestos
        Public Property IVA As Decimal
        Public Property IEPS As Decimal

        ' Banderas de Estado (Flags)
        Public Property CargandoPendiente As Boolean = False
        Public Property TraeVale As Boolean = False
        Public Property EsBusquedaF1 As Boolean = False ' FueConF1
        Public Property EsCancelacion As Boolean = False ' FueConF2 (Cancelación)
        Public Property EsCambioCantidad As Boolean = False ' FueConF3
        Public Property EsCajaVirtual As Boolean = False ' FueConF6 (Nueva)
        Public Property EsKilos As Boolean = False ' Para Lógica de Báscula
        Public Property TipoArticulo As Integer = 1 ' 1 Normal, 2 Báscula, 11 Cancelación

        ' Ofertas y Factores
        Public Property TipoOferta As Integer
        Public Property Factor As Decimal = 1.0 ' Factor de conversión (Cajas)
    End Class
End Class

'Imports System.Data.SqlClient
'Imports FarPoint.Win.Spread.CellType
'Imports System.Math
'Imports FarPoint.PDF.Drawing.EMF
'Imports System.Security.Cryptography
'Imports System.Drawing.Imaging
'Imports FarPoint.Win.Spread.Model


'Public Class FrVenta

'    Inherits System.Windows.Forms.Form
'    Public xCon As SqlConnection
'    Public numt As Integer
'    Dim cerrar As Integer = 1
'    Private sConexion As String
'    Private hashPanel As New Hashtable
'    Private sCant As String = "" ' Almacena la cantidad de un artículo a pedir
'    Private imgFamilia As Image 'Imagen del título principal
'    Private masClicks As Integer
'    Private claveArt As String
'    Private preImpresion As New Collection
'    Public HayTarjeta As Boolean
'    Private formaspago As Boolean
'    Private fpago As Integer
'    Public PERMISOVENDER As Boolean
'    Private buscararticulo As Boolean
'    Private cancelacion As Boolean
'    Private F3Cantidad As Boolean
'    Private FueConF1 As Boolean
'    Private kilos As Boolean
'    Public autorizame As Boolean
'    Public AutorizaCierreCambioVentana As Boolean
'    Public NuevoTipoVenta As Integer
'    Public xven As Double
'    Public MontoMaximoComision, totalote, TotalComision As Double
'    Public claveprod As String
'    Dim virtual As Integer
'    Public segundoticket As Boolean
'    Public sipuntos As Boolean
'    Public estiempoaire As Boolean
'    Public pagare As Boolean
'    Public clientex As String
'    Public totalpagos As Double
'    Public TIPOVENTA As Integer
'    Public codigotp As String
'    Public datostel As Boolean
'    Dim bandera As Integer
'    Public band As Boolean
'    Public Flogin As FrLogin
'    Public Banderita As Boolean
'    Public TIEMPOCOMIS As Integer
'    Public VentaCajaVirtual As Boolean
'    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
'    Friend WithEvents Label6 As System.Windows.Forms.Label
'    Friend WithEvents Label27 As System.Windows.Forms.Label
'    Friend WithEvents Label1 As System.Windows.Forms.Label
'    Friend WithEvents Label28 As System.Windows.Forms.Label
'    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
'    Friend WithEvents Label3 As System.Windows.Forms.Label
'    Friend WithEvents Label29 As System.Windows.Forms.Label
'    Friend WithEvents Label30 As System.Windows.Forms.Label
'    Friend WithEvents Label31 As System.Windows.Forms.Label
'    Friend WithEvents Label32 As System.Windows.Forms.Label
'    Friend WithEvents Panel3 As System.Windows.Forms.Panel
'    Friend WithEvents Label8 As System.Windows.Forms.Label
'    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
'    Friend WithEvents Label7 As System.Windows.Forms.Label
'    Friend WithEvents Label14 As System.Windows.Forms.Label
'    Friend WithEvents Label15 As System.Windows.Forms.Label
'    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
'    Friend WithEvents Label26 As System.Windows.Forms.Label
'    Friend WithEvents Label33 As System.Windows.Forms.Label
'    Friend WithEvents Label34 As System.Windows.Forms.Label
'    Friend WithEvents Label35 As System.Windows.Forms.Label
'    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox25 As System.Windows.Forms.PictureBox
'    Friend WithEvents Panel6 As System.Windows.Forms.Panel
'    Friend WithEvents Panel5 As System.Windows.Forms.Panel
'    Friend WithEvents Label16 As System.Windows.Forms.Label
'    Friend WithEvents LFORPAG As System.Windows.Forms.Label
'    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
'    Friend WithEvents Label19 As System.Windows.Forms.Label
'    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
'    Friend WithEvents panelofe As System.Windows.Forms.Panel
'    Friend WithEvents Label21 As System.Windows.Forms.Label
'    Friend WithEvents txt_panelofe As System.Windows.Forms.TextBox
'    Friend WithEvents txtnotifica As System.Windows.Forms.TextBox
'    Friend WithEvents Label20 As System.Windows.Forms.Label
'    Friend WithEvents Button2 As System.Windows.Forms.Button
'    Friend WithEvents BTN_NUEVO As System.Windows.Forms.Button
'    Friend WithEvents Paneltiempo As System.Windows.Forms.Panel
'    Friend WithEvents txt_ctel4 As System.Windows.Forms.TextBox
'    Friend WithEvents txt_ctel3 As System.Windows.Forms.TextBox
'    Friend WithEvents txt_ctel2 As System.Windows.Forms.TextBox
'    Friend WithEvents txt_ctel1 As System.Windows.Forms.TextBox
'    Friend WithEvents txt_tel4 As System.Windows.Forms.TextBox
'    Friend WithEvents txt_tel3 As System.Windows.Forms.TextBox
'    Friend WithEvents txt_tel2 As System.Windows.Forms.TextBox
'    Friend WithEvents txt_tel1 As System.Windows.Forms.TextBox
'    Friend WithEvents Label23 As System.Windows.Forms.Label
'    Friend WithEvents Label36 As System.Windows.Forms.Label
'    Friend WithEvents Button4 As System.Windows.Forms.Button
'    Friend WithEvents Button3 As Button
'    Friend WithEvents LbTotal As Label
'    Friend WithEvents GroupBox1 As GroupBox
'    Friend WithEvents Label37 As Label
'    Friend WithEvents TextBox1 As TextBox
'    Friend WithEvents TxtControl As TextBox
'    Friend WithEvents LbIDOferta As Label
'    Friend WithEvents ListBox1 As ListBox
'    Friend WithEvents PanelCancelaciones As Panel
'    Friend WithEvents BtnCambiaVenta As Button
'    Friend WithEvents PanelSeleccionTarjetas As GroupBox
'    Friend WithEvents lbFila As Label
'    Friend WithEvents BtnCierraPanel As Button
'    Friend WithEvents BtnRegistraTarjeta As Button
'    Friend WithEvents rbTDebito As RadioButton
'    Friend WithEvents rbTCredito As RadioButton
'    Friend WithEvents LbClienteTicket As Label
'    Friend WithEvents BtnCambiaCliente As Button
'    Public acredito As Double

'    'Funcion Que Manda a Llamar un Sonido.....(API windows)
'    Private Declare Function sndPlaySoundA Lib "WinMM" (ByVal nameString As String, ByVal flags As Integer) As Integer


'#Region " Código generado por el Diseñador de Windows Forms "

'    Public Sub New(ByRef con As SqlConnection, ByRef Login As FrLogin)
'        MyBase.New()
'        Flogin = Login
'        'El Diseñador de Windows Forms requiere esta llamada.
'        InitializeComponent()
'        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
'        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
'        xCon = con
'    End Sub

'    'Form reemplaza a Dispose para limpiar la lista de componentes.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Requerido por el Diseñador de Windows Forms
'    Private components As System.ComponentModel.IContainer

'    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
'    'Puede modificarse utilizando el Diseñador de Windows Forms. 
'    'No lo modifique con el editor de código.
'    Friend WithEvents tb_total As System.Windows.Forms.TextBox
'    Friend WithEvents TX_UPC As System.Windows.Forms.TextBox
'    Friend WithEvents tx_cantidad As System.Windows.Forms.TextBox
'    Friend WithEvents l_cantidad As System.Windows.Forms.Label
'    Friend WithEvents l_cancelacion As System.Windows.Forms.Label
'    Friend WithEvents FP_FORMASPAGO As FarPoint.Win.Spread.FpSpread
'    Friend WithEvents FP_FORMASPAGO_Sheet1 As FarPoint.Win.Spread.SheetView
'    Friend WithEvents Label9 As System.Windows.Forms.Label
'    Friend WithEvents grformapago As System.Windows.Forms.GroupBox
'    Friend WithEvents Label10 As System.Windows.Forms.Label
'    Friend WithEvents ntx_totalventa As System.Windows.Forms.Label
'    Friend WithEvents ntx_totalpago As System.Windows.Forms.Label
'    Friend WithEvents Label11 As System.Windows.Forms.Label
'    Friend WithEvents Lkilos As System.Windows.Forms.Label
'    Friend WithEvents busqueda As System.Windows.Forms.Label
'    Friend WithEvents Label17 As System.Windows.Forms.Label
'    Friend WithEvents lcambio As System.Windows.Forms.Label
'    Friend WithEvents TXB_BANCO As System.Windows.Forms.TextBox
'    Friend WithEvents banco As System.Windows.Forms.GroupBox
'    Friend WithEvents Label18 As System.Windows.Forms.Label
'    Friend WithEvents credito As System.Windows.Forms.GroupBox
'    Friend WithEvents Cliente As System.Windows.Forms.Label
'    Friend WithEvents txb_credito As System.Windows.Forms.TextBox
'    Friend WithEvents Label22 As System.Windows.Forms.Label
'    Friend WithEvents txt_tipoventa As System.Windows.Forms.TextBox
'    Friend WithEvents fp_articulos As FarPoint.Win.Spread.FpSpread
'    Friend WithEvents fp_articulos_Sheet1 As FarPoint.Win.Spread.SheetView
'    Friend WithEvents txb_credito1 As System.Windows.Forms.TextBox
'    Friend WithEvents Panel1 As System.Windows.Forms.Panel
'    Friend WithEvents Label24 As System.Windows.Forms.Label
'    Friend WithEvents Label25 As System.Windows.Forms.Label
'    Friend WithEvents txt_cveenc As System.Windows.Forms.TextBox
'    Friend WithEvents Label2 As System.Windows.Forms.Label
'    Friend WithEvents txt_foliopago As System.Windows.Forms.TextBox
'    Friend WithEvents TX_TOTALPAGO As System.Windows.Forms.Label
'    Friend WithEvents txe As System.Windows.Forms.TextBox
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
'        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
'        Dim NumberCellType25 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim TextCellType22 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
'        Dim EnhancedScrollBarRenderer3 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
'        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaMidnght")
'        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
'        Dim EnhancedScrollBarRenderer4 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
'        Dim TextCellType23 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
'        Dim NumberCellType26 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim TextCellType24 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
'        Dim CurrencyCellType16 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
'        Dim CurrencyCellType17 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
'        Dim TextCellType25 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
'        Dim NumberCellType27 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim NumberCellType28 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim NumberCellType29 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim NumberCellType30 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim NumberCellType31 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim TextCellType26 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
'        Dim TextCellType27 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
'        Dim TextCellType28 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
'        Dim CurrencyCellType18 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
'        Dim NumberCellType32 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
'        Dim CurrencyCellType19 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
'        Dim CurrencyCellType20 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
'        Me.tb_total = New System.Windows.Forms.TextBox()
'        Me.TX_UPC = New System.Windows.Forms.TextBox()
'        Me.tx_cantidad = New System.Windows.Forms.TextBox()
'        Me.l_cantidad = New System.Windows.Forms.Label()
'        Me.l_cancelacion = New System.Windows.Forms.Label()
'        Me.grformapago = New System.Windows.Forms.GroupBox()
'        Me.banco = New System.Windows.Forms.GroupBox()
'        Me.Label18 = New System.Windows.Forms.Label()
'        Me.TXB_BANCO = New System.Windows.Forms.TextBox()
'        Me.credito = New System.Windows.Forms.GroupBox()
'        Me.txb_credito1 = New System.Windows.Forms.TextBox()
'        Me.Label22 = New System.Windows.Forms.Label()
'        Me.txb_credito = New System.Windows.Forms.TextBox()
'        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
'        Me.Label37 = New System.Windows.Forms.Label()
'        Me.TextBox1 = New System.Windows.Forms.TextBox()
'        Me.txt_foliopago = New System.Windows.Forms.TextBox()
'        Me.Panel6 = New System.Windows.Forms.Panel()
'        Me.Label19 = New System.Windows.Forms.Label()
'        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
'        Me.Label15 = New System.Windows.Forms.Label()
'        Me.Label35 = New System.Windows.Forms.Label()
'        Me.PictureBox21 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox22 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
'        Me.Label34 = New System.Windows.Forms.Label()
'        Me.PictureBox25 = New System.Windows.Forms.PictureBox()
'        Me.Label26 = New System.Windows.Forms.Label()
'        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
'        Me.Label33 = New System.Windows.Forms.Label()
'        Me.Label14 = New System.Windows.Forms.Label()
'        Me.TX_TOTALPAGO = New System.Windows.Forms.Label()
'        Me.Label9 = New System.Windows.Forms.Label()
'        Me.lcambio = New System.Windows.Forms.Label()
'        Me.Label17 = New System.Windows.Forms.Label()
'        Me.Label10 = New System.Windows.Forms.Label()
'        Me.FP_FORMASPAGO = New FarPoint.Win.Spread.FpSpread()
'        Me.FP_FORMASPAGO_Sheet1 = New FarPoint.Win.Spread.SheetView()
'        Me.LFORPAG = New System.Windows.Forms.Label()
'        Me.ntx_totalventa = New System.Windows.Forms.Label()
'        Me.ntx_totalpago = New System.Windows.Forms.Label()
'        Me.Label11 = New System.Windows.Forms.Label()
'        Me.Lkilos = New System.Windows.Forms.Label()
'        Me.busqueda = New System.Windows.Forms.Label()
'        Me.txt_tipoventa = New System.Windows.Forms.TextBox()
'        Me.fp_articulos = New FarPoint.Win.Spread.FpSpread()
'        Me.fp_articulos_Sheet1 = New FarPoint.Win.Spread.SheetView()
'        Me.Panel1 = New System.Windows.Forms.Panel()
'        Me.txe = New System.Windows.Forms.TextBox()
'        Me.Label2 = New System.Windows.Forms.Label()
'        Me.txt_cveenc = New System.Windows.Forms.TextBox()
'        Me.Label25 = New System.Windows.Forms.Label()
'        Me.Label24 = New System.Windows.Forms.Label()
'        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
'        Me.Label6 = New System.Windows.Forms.Label()
'        Me.Label27 = New System.Windows.Forms.Label()
'        Me.Label1 = New System.Windows.Forms.Label()
'        Me.Label28 = New System.Windows.Forms.Label()
'        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
'        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
'        Me.Label3 = New System.Windows.Forms.Label()
'        Me.Label29 = New System.Windows.Forms.Label()
'        Me.Label30 = New System.Windows.Forms.Label()
'        Me.Label31 = New System.Windows.Forms.Label()
'        Me.Label32 = New System.Windows.Forms.Label()
'        Me.Panel3 = New System.Windows.Forms.Panel()
'        Me.BtnCambiaCliente = New System.Windows.Forms.Button()
'        Me.BtnCambiaVenta = New System.Windows.Forms.Button()
'        Me.TxtControl = New System.Windows.Forms.TextBox()
'        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
'        Me.Label8 = New System.Windows.Forms.Label()
'        Me.Label7 = New System.Windows.Forms.Label()
'        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
'        Me.Panel5 = New System.Windows.Forms.Panel()
'        Me.Label16 = New System.Windows.Forms.Label()
'        Me.panelofe = New System.Windows.Forms.Panel()
'        Me.LbIDOferta = New System.Windows.Forms.Label()
'        Me.BTN_NUEVO = New System.Windows.Forms.Button()
'        Me.Label21 = New System.Windows.Forms.Label()
'        Me.txt_panelofe = New System.Windows.Forms.TextBox()
'        Me.txtnotifica = New System.Windows.Forms.TextBox()
'        Me.Label20 = New System.Windows.Forms.Label()
'        Me.Button2 = New System.Windows.Forms.Button()
'        Me.Paneltiempo = New System.Windows.Forms.Panel()
'        Me.txt_ctel4 = New System.Windows.Forms.TextBox()
'        Me.txt_ctel3 = New System.Windows.Forms.TextBox()
'        Me.txt_ctel2 = New System.Windows.Forms.TextBox()
'        Me.txt_ctel1 = New System.Windows.Forms.TextBox()
'        Me.txt_tel4 = New System.Windows.Forms.TextBox()
'        Me.txt_tel3 = New System.Windows.Forms.TextBox()
'        Me.txt_tel2 = New System.Windows.Forms.TextBox()
'        Me.txt_tel1 = New System.Windows.Forms.TextBox()
'        Me.Button3 = New System.Windows.Forms.Button()
'        Me.Label23 = New System.Windows.Forms.Label()
'        Me.Label36 = New System.Windows.Forms.Label()
'        Me.Button4 = New System.Windows.Forms.Button()
'        Me.LbTotal = New System.Windows.Forms.Label()
'        Me.ListBox1 = New System.Windows.Forms.ListBox()
'        Me.PanelCancelaciones = New System.Windows.Forms.Panel()
'        Me.PanelSeleccionTarjetas = New System.Windows.Forms.GroupBox()
'        Me.lbFila = New System.Windows.Forms.Label()
'        Me.BtnCierraPanel = New System.Windows.Forms.Button()
'        Me.BtnRegistraTarjeta = New System.Windows.Forms.Button()
'        Me.rbTDebito = New System.Windows.Forms.RadioButton()
'        Me.rbTCredito = New System.Windows.Forms.RadioButton()
'        Me.LbClienteTicket = New System.Windows.Forms.Label()
'        Me.grformapago.SuspendLayout()
'        Me.banco.SuspendLayout()
'        Me.credito.SuspendLayout()
'        Me.GroupBox1.SuspendLayout()
'        Me.Panel6.SuspendLayout()
'        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.FP_FORMASPAGO, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.FP_FORMASPAGO_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.fp_articulos, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.fp_articulos_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.Panel1.SuspendLayout()
'        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.Panel3.SuspendLayout()
'        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
'        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.panelofe.SuspendLayout()
'        Me.Paneltiempo.SuspendLayout()
'        Me.PanelCancelaciones.SuspendLayout()
'        Me.PanelSeleccionTarjetas.SuspendLayout()
'        Me.SuspendLayout()
'        '
'        'tb_total
'        '
'        Me.tb_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.tb_total.BackColor = System.Drawing.Color.White
'        Me.tb_total.Enabled = False
'        Me.tb_total.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.tb_total.Location = New System.Drawing.Point(227, 596)
'        Me.tb_total.Name = "tb_total"
'        Me.tb_total.ReadOnly = True
'        Me.tb_total.Size = New System.Drawing.Size(218, 35)
'        Me.tb_total.TabIndex = 53
'        Me.tb_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'        Me.tb_total.Visible = False
'        '
'        'TX_UPC
'        '
'        Me.TX_UPC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.TX_UPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.TX_UPC.Location = New System.Drawing.Point(311, 705)
'        Me.TX_UPC.Name = "TX_UPC"
'        Me.TX_UPC.Size = New System.Drawing.Size(224, 26)
'        Me.TX_UPC.TabIndex = 1
'        '
'        'tx_cantidad
'        '
'        Me.tx_cantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.tx_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.tx_cantidad.Location = New System.Drawing.Point(714, 705)
'        Me.tx_cantidad.Name = "tx_cantidad"
'        Me.tx_cantidad.Size = New System.Drawing.Size(112, 26)
'        Me.tx_cantidad.TabIndex = 192
'        Me.tx_cantidad.Visible = False
'        '
'        'l_cantidad
'        '
'        Me.l_cantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.l_cantidad.BackColor = System.Drawing.Color.Transparent
'        Me.l_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.l_cantidad.ForeColor = System.Drawing.Color.Black
'        Me.l_cantidad.Location = New System.Drawing.Point(573, 705)
'        Me.l_cantidad.Name = "l_cantidad"
'        Me.l_cantidad.Size = New System.Drawing.Size(135, 23)
'        Me.l_cantidad.TabIndex = 193
'        Me.l_cantidad.Text = "Cantidad:"
'        Me.l_cantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        Me.l_cantidad.Visible = False
'        '
'        'l_cancelacion
'        '
'        Me.l_cancelacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.l_cancelacion.BackColor = System.Drawing.Color.Transparent
'        Me.l_cancelacion.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.l_cancelacion.ForeColor = System.Drawing.Color.Black
'        Me.l_cancelacion.Location = New System.Drawing.Point(170, 705)
'        Me.l_cancelacion.Name = "l_cancelacion"
'        Me.l_cancelacion.Size = New System.Drawing.Size(122, 27)
'        Me.l_cancelacion.TabIndex = 194
'        Me.l_cancelacion.Text = "Cancelar "
'        Me.l_cancelacion.Visible = False
'        '
'        'grformapago
'        '
'        Me.grformapago.BackColor = System.Drawing.Color.White
'        Me.grformapago.Controls.Add(Me.banco)
'        Me.grformapago.Controls.Add(Me.credito)
'        Me.grformapago.Controls.Add(Me.GroupBox1)
'        Me.grformapago.Controls.Add(Me.txt_foliopago)
'        Me.grformapago.Controls.Add(Me.Panel6)
'        Me.grformapago.Controls.Add(Me.TX_TOTALPAGO)
'        Me.grformapago.Controls.Add(Me.Label9)
'        Me.grformapago.Controls.Add(Me.lcambio)
'        Me.grformapago.Controls.Add(Me.Label17)
'        Me.grformapago.Controls.Add(Me.Label10)
'        Me.grformapago.Controls.Add(Me.FP_FORMASPAGO)
'        Me.grformapago.Location = New System.Drawing.Point(242, 237)
'        Me.grformapago.Name = "grformapago"
'        Me.grformapago.Size = New System.Drawing.Size(646, 449)
'        Me.grformapago.TabIndex = 200
'        Me.grformapago.TabStop = False
'        '
'        'banco
'        '
'        Me.banco.BackColor = System.Drawing.Color.Transparent
'        Me.banco.Controls.Add(Me.Label18)
'        Me.banco.Controls.Add(Me.TXB_BANCO)
'        Me.banco.Location = New System.Drawing.Point(4, 401)
'        Me.banco.Name = "banco"
'        Me.banco.Size = New System.Drawing.Size(638, 42)
'        Me.banco.TabIndex = 218
'        Me.banco.TabStop = False
'        Me.banco.Visible = False
'        '
'        'Label18
'        '
'        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label18.ForeColor = System.Drawing.Color.Black
'        Me.Label18.Location = New System.Drawing.Point(55, 13)
'        Me.Label18.Name = "Label18"
'        Me.Label18.Size = New System.Drawing.Size(278, 23)
'        Me.Label18.TabIndex = 218
'        Me.Label18.Text = "Banco:"
'        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'TXB_BANCO
'        '
'        Me.TXB_BANCO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.TXB_BANCO.Location = New System.Drawing.Point(339, 14)
'        Me.TXB_BANCO.Name = "TXB_BANCO"
'        Me.TXB_BANCO.Size = New System.Drawing.Size(297, 22)
'        Me.TXB_BANCO.TabIndex = 217
'        '
'        'credito
'        '
'        Me.credito.BackColor = System.Drawing.Color.Transparent
'        Me.credito.Controls.Add(Me.txb_credito1)
'        Me.credito.Controls.Add(Me.Label22)
'        Me.credito.Controls.Add(Me.txb_credito)
'        Me.credito.Location = New System.Drawing.Point(4, 355)
'        Me.credito.Name = "credito"
'        Me.credito.Size = New System.Drawing.Size(640, 46)
'        Me.credito.TabIndex = 219
'        Me.credito.TabStop = False
'        Me.credito.Visible = False
'        '
'        'txb_credito1
'        '
'        Me.txb_credito1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txb_credito1.Location = New System.Drawing.Point(87, 14)
'        Me.txb_credito1.Name = "txb_credito1"
'        Me.txb_credito1.Size = New System.Drawing.Size(24, 26)
'        Me.txb_credito1.TabIndex = 219
'        Me.txb_credito1.Visible = False
'        '
'        'Label22
'        '
'        Me.Label22.BackColor = System.Drawing.Color.Transparent
'        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label22.ForeColor = System.Drawing.Color.Black
'        Me.Label22.Location = New System.Drawing.Point(162, 14)
'        Me.Label22.Name = "Label22"
'        Me.Label22.Size = New System.Drawing.Size(171, 23)
'        Me.Label22.TabIndex = 218
'        Me.Label22.Text = "Cliente:"
'        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'txb_credito
'        '
'        Me.txb_credito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txb_credito.Location = New System.Drawing.Point(339, 14)
'        Me.txb_credito.Name = "txb_credito"
'        Me.txb_credito.Size = New System.Drawing.Size(297, 26)
'        Me.txb_credito.TabIndex = 217
'        '
'        'GroupBox1
'        '
'        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
'        Me.GroupBox1.Controls.Add(Me.Label37)
'        Me.GroupBox1.Controls.Add(Me.TextBox1)
'        Me.GroupBox1.Location = New System.Drawing.Point(4, 401)
'        Me.GroupBox1.Name = "GroupBox1"
'        Me.GroupBox1.Size = New System.Drawing.Size(638, 42)
'        Me.GroupBox1.TabIndex = 218
'        Me.GroupBox1.TabStop = False
'        Me.GroupBox1.Visible = False
'        '
'        'Label37
'        '
'        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label37.ForeColor = System.Drawing.Color.Black
'        Me.Label37.Location = New System.Drawing.Point(55, 13)
'        Me.Label37.Name = "Label37"
'        Me.Label37.Size = New System.Drawing.Size(278, 23)
'        Me.Label37.TabIndex = 218
'        Me.Label37.Text = "Banco:"
'        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'TextBox1
'        '
'        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.TextBox1.Location = New System.Drawing.Point(339, 14)
'        Me.TextBox1.Name = "TextBox1"
'        Me.TextBox1.Size = New System.Drawing.Size(297, 22)
'        Me.TextBox1.TabIndex = 217
'        '
'        'txt_foliopago
'        '
'        Me.txt_foliopago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_foliopago.Location = New System.Drawing.Point(63, 386)
'        Me.txt_foliopago.Name = "txt_foliopago"
'        Me.txt_foliopago.Size = New System.Drawing.Size(40, 26)
'        Me.txt_foliopago.TabIndex = 224
'        Me.txt_foliopago.Visible = False
'        '
'        'Panel6
'        '
'        Me.Panel6.BackColor = System.Drawing.Color.LightBlue
'        Me.Panel6.Controls.Add(Me.Label19)
'        Me.Panel6.Controls.Add(Me.PictureBox8)
'        Me.Panel6.Controls.Add(Me.Label15)
'        Me.Panel6.Controls.Add(Me.Label35)
'        Me.Panel6.Controls.Add(Me.PictureBox21)
'        Me.Panel6.Controls.Add(Me.PictureBox22)
'        Me.Panel6.Controls.Add(Me.PictureBox24)
'        Me.Panel6.Controls.Add(Me.PictureBox23)
'        Me.Panel6.Controls.Add(Me.Label34)
'        Me.Panel6.Controls.Add(Me.PictureBox25)
'        Me.Panel6.Controls.Add(Me.Label26)
'        Me.Panel6.Controls.Add(Me.PictureBox13)
'        Me.Panel6.Controls.Add(Me.Label33)
'        Me.Panel6.Controls.Add(Me.Label14)
'        Me.Panel6.Location = New System.Drawing.Point(6, 255)
'        Me.Panel6.Name = "Panel6"
'        Me.Panel6.Size = New System.Drawing.Size(634, 101)
'        Me.Panel6.TabIndex = 7
'        '
'        'Label19
'        '
'        Me.Label19.BackColor = System.Drawing.Color.Transparent
'        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label19.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label19.Location = New System.Drawing.Point(310, 64)
'        Me.Label19.Name = "Label19"
'        Me.Label19.Size = New System.Drawing.Size(142, 30)
'        Me.Label19.TabIndex = 505
'        Me.Label19.Text = "FIN - Transferencia"
'        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'PictureBox8
'        '
'        Me.PictureBox8.BackColor = System.Drawing.Color.White
'        Me.PictureBox8.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
'        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox8.Location = New System.Drawing.Point(274, 64)
'        Me.PictureBox8.Name = "PictureBox8"
'        Me.PictureBox8.Size = New System.Drawing.Size(30, 30)
'        Me.PictureBox8.TabIndex = 506
'        Me.PictureBox8.TabStop = False
'        '
'        'Label15
'        '
'        Me.Label15.BackColor = System.Drawing.Color.Transparent
'        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label15.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label15.Location = New System.Drawing.Point(44, 8)
'        Me.Label15.Name = "Label15"
'        Me.Label15.Size = New System.Drawing.Size(91, 30)
'        Me.Label15.TabIndex = 491
'        Me.Label15.Text = "F5 - Efectivo"
'        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label35
'        '
'        Me.Label35.BackColor = System.Drawing.Color.Transparent
'        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label35.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label35.Location = New System.Drawing.Point(497, 8)
'        Me.Label35.Name = "Label35"
'        Me.Label35.Size = New System.Drawing.Size(131, 30)
'        Me.Label35.TabIndex = 500
'        Me.Label35.Text = "F10 - Cierra Venta"
'        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'PictureBox21
'        '
'        Me.PictureBox21.BackColor = System.Drawing.Color.White
'        Me.PictureBox21.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.exportar
'        Me.PictureBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox21.Location = New System.Drawing.Point(461, 8)
'        Me.PictureBox21.Name = "PictureBox21"
'        Me.PictureBox21.Size = New System.Drawing.Size(30, 30)
'        Me.PictureBox21.TabIndex = 504
'        Me.PictureBox21.TabStop = False
'        '
'        'PictureBox22
'        '
'        Me.PictureBox22.BackColor = System.Drawing.Color.White
'        Me.PictureBox22.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.buscar
'        Me.PictureBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox22.Location = New System.Drawing.Point(8, 64)
'        Me.PictureBox22.Name = "PictureBox22"
'        Me.PictureBox22.Size = New System.Drawing.Size(30, 30)
'        Me.PictureBox22.TabIndex = 503
'        Me.PictureBox22.TabStop = False
'        '
'        'PictureBox24
'        '
'        Me.PictureBox24.BackColor = System.Drawing.Color.White
'        Me.PictureBox24.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROGUARDAR
'        Me.PictureBox24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox24.Location = New System.Drawing.Point(141, 64)
'        Me.PictureBox24.Name = "PictureBox24"
'        Me.PictureBox24.Size = New System.Drawing.Size(30, 30)
'        Me.PictureBox24.TabIndex = 501
'        Me.PictureBox24.TabStop = False
'        '
'        'PictureBox23
'        '
'        Me.PictureBox23.BackColor = System.Drawing.Color.White
'        Me.PictureBox23.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.borrar
'        Me.PictureBox23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox23.Location = New System.Drawing.Point(141, 8)
'        Me.PictureBox23.Name = "PictureBox23"
'        Me.PictureBox23.Size = New System.Drawing.Size(30, 30)
'        Me.PictureBox23.TabIndex = 500
'        Me.PictureBox23.TabStop = False
'        '
'        'Label34
'        '
'        Me.Label34.BackColor = System.Drawing.Color.Transparent
'        Me.Label34.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label34.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label34.Location = New System.Drawing.Point(310, 8)
'        Me.Label34.Name = "Label34"
'        Me.Label34.Size = New System.Drawing.Size(142, 30)
'        Me.Label34.TabIndex = 498
'        Me.Label34.Text = "F9 - Tarjeta Bancaria"
'        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'PictureBox25
'        '
'        Me.PictureBox25.BackColor = System.Drawing.Color.White
'        Me.PictureBox25.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
'        Me.PictureBox25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox25.Location = New System.Drawing.Point(274, 8)
'        Me.PictureBox25.Name = "PictureBox25"
'        Me.PictureBox25.Size = New System.Drawing.Size(30, 30)
'        Me.PictureBox25.TabIndex = 502
'        Me.PictureBox25.TabStop = False
'        '
'        'Label26
'        '
'        Me.Label26.BackColor = System.Drawing.Color.Transparent
'        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label26.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label26.Location = New System.Drawing.Point(177, 64)
'        Me.Label26.Name = "Label26"
'        Me.Label26.Size = New System.Drawing.Size(91, 30)
'        Me.Label26.TabIndex = 496
'        Me.Label26.Text = "F8 - Crédito"
'        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'PictureBox13
'        '
'        Me.PictureBox13.BackColor = System.Drawing.Color.White
'        Me.PictureBox13.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROGUARDAR
'        Me.PictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox13.Location = New System.Drawing.Point(8, 8)
'        Me.PictureBox13.Name = "PictureBox13"
'        Me.PictureBox13.Size = New System.Drawing.Size(30, 30)
'        Me.PictureBox13.TabIndex = 489
'        Me.PictureBox13.TabStop = False
'        '
'        'Label33
'        '
'        Me.Label33.BackColor = System.Drawing.Color.Transparent
'        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label33.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label33.Location = New System.Drawing.Point(177, 8)
'        Me.Label33.Name = "Label33"
'        Me.Label33.Size = New System.Drawing.Size(91, 30)
'        Me.Label33.TabIndex = 495
'        Me.Label33.Text = "F7 - Cheque"
'        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label14
'        '
'        Me.Label14.BackColor = System.Drawing.Color.Transparent
'        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label14.Location = New System.Drawing.Point(44, 64)
'        Me.Label14.Name = "Label14"
'        Me.Label14.Size = New System.Drawing.Size(91, 30)
'        Me.Label14.TabIndex = 492
'        Me.Label14.Text = "F6 - Vales"
'        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'TX_TOTALPAGO
'        '
'        Me.TX_TOTALPAGO.BackColor = System.Drawing.Color.MidnightBlue
'        Me.TX_TOTALPAGO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.TX_TOTALPAGO.ForeColor = System.Drawing.Color.White
'        Me.TX_TOTALPAGO.Location = New System.Drawing.Point(475, 219)
'        Me.TX_TOTALPAGO.Name = "TX_TOTALPAGO"
'        Me.TX_TOTALPAGO.Size = New System.Drawing.Size(165, 30)
'        Me.TX_TOTALPAGO.TabIndex = 6
'        Me.TX_TOTALPAGO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'Label9
'        '
'        Me.Label9.BackColor = System.Drawing.Color.LightBlue
'        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label9.ForeColor = System.Drawing.Color.White
'        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
'        Me.Label9.Location = New System.Drawing.Point(5, 13)
'        Me.Label9.Name = "Label9"
'        Me.Label9.Size = New System.Drawing.Size(635, 24)
'        Me.Label9.TabIndex = 1
'        Me.Label9.Text = "Su Pago"
'        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'lcambio
'        '
'        Me.lcambio.BackColor = System.Drawing.Color.MidnightBlue
'        Me.lcambio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lcambio.ForeColor = System.Drawing.Color.White
'        Me.lcambio.Location = New System.Drawing.Point(113, 219)
'        Me.lcambio.Name = "lcambio"
'        Me.lcambio.Size = New System.Drawing.Size(271, 30)
'        Me.lcambio.TabIndex = 5
'        Me.lcambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label17
'        '
'        Me.Label17.BackColor = System.Drawing.Color.MidnightBlue
'        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label17.ForeColor = System.Drawing.Color.White
'        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
'        Me.Label17.Location = New System.Drawing.Point(6, 219)
'        Me.Label17.Name = "Label17"
'        Me.Label17.Size = New System.Drawing.Size(109, 30)
'        Me.Label17.TabIndex = 4
'        Me.Label17.Text = "Diferencia:"
'        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'Label10
'        '
'        Me.Label10.BackColor = System.Drawing.Color.MidnightBlue
'        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label10.ForeColor = System.Drawing.Color.White
'        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
'        Me.Label10.Location = New System.Drawing.Point(373, 219)
'        Me.Label10.Name = "Label10"
'        Me.Label10.Size = New System.Drawing.Size(103, 30)
'        Me.Label10.TabIndex = 2
'        Me.Label10.Text = "Suma:"
'        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'FP_FORMASPAGO
'        '
'        Me.FP_FORMASPAGO.AccessibleDescription = "FP_FORMASPAGO, Sheet1, Row 0, Column 0, "
'        Me.FP_FORMASPAGO.BackColor = System.Drawing.Color.White
'        Me.FP_FORMASPAGO.BorderStyle = System.Windows.Forms.BorderStyle.None
'        Me.FP_FORMASPAGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.FP_FORMASPAGO.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
'        Me.FP_FORMASPAGO.HorizontalScrollBar.Name = ""
'        EnhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
'        Me.FP_FORMASPAGO.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
'        Me.FP_FORMASPAGO.HorizontalScrollBar.TabIndex = 16
'        Me.FP_FORMASPAGO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
'        Me.FP_FORMASPAGO.Location = New System.Drawing.Point(6, 40)
'        Me.FP_FORMASPAGO.Name = "FP_FORMASPAGO"
'        Me.FP_FORMASPAGO.RightToLeft = System.Windows.Forms.RightToLeft.No
'        Me.FP_FORMASPAGO.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FP_FORMASPAGO_Sheet1})
'        Me.FP_FORMASPAGO.Size = New System.Drawing.Size(634, 176)
'        Me.FP_FORMASPAGO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Sunburst
'        Me.FP_FORMASPAGO.TabIndex = 0
'        Me.FP_FORMASPAGO.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
'        Me.FP_FORMASPAGO.VerticalScrollBar.Name = ""
'        EnhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
'        Me.FP_FORMASPAGO.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
'        Me.FP_FORMASPAGO.VerticalScrollBar.TabIndex = 17
'        Me.FP_FORMASPAGO.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
'        '
'        'FP_FORMASPAGO_Sheet1
'        '
'        Me.FP_FORMASPAGO_Sheet1.Reset()
'        Me.FP_FORMASPAGO_Sheet1.SheetName = "Sheet1"
'        'Formulas and custom names must be loaded with R1C1 reference style
'        Me.FP_FORMASPAGO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
'        Me.FP_FORMASPAGO_Sheet1.ColumnCount = 4
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.RowCount = 2
'        Me.FP_FORMASPAGO_Sheet1.RowCount = 0
'        Me.FP_FORMASPAGO_Sheet1.RowHeader.ColumnCount = 0
'        Me.FP_FORMASPAGO_Sheet1.ActiveRowIndex = -1
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 0).BackColor = System.Drawing.Color.White
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Forma de Pago"
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 1).BackColor = System.Drawing.Color.White
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Importe"
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 2).BackColor = System.Drawing.Color.White
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.Color.CornflowerBlue
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Referencia"
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 3).BackColor = System.Drawing.Color.White
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.Color.CornflowerBlue
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "TipoTar"
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
'        Me.FP_FORMASPAGO_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(0).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(0).Width = 111.0!
'        NumberCellType25.DecimalPlaces = 2
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(1).CellType = NumberCellType25
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(1).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(1).Width = 165.0!
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(2).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(2).Width = 317.0!
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(3).CellType = TextCellType22
'        Me.FP_FORMASPAGO_Sheet1.Columns.Get(3).Visible = False
'        Me.FP_FORMASPAGO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
'        Me.FP_FORMASPAGO_Sheet1.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Goldenrod)
'        Me.FP_FORMASPAGO_Sheet1.RowHeader.Columns.Default.Resizable = False
'        Me.FP_FORMASPAGO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
'        Me.FP_FORMASPAGO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSunburst"
'        Me.FP_FORMASPAGO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
'        Me.FP_FORMASPAGO_Sheet1.SheetCornerStyle.Parent = "CornerSunburst"
'        Me.FP_FORMASPAGO_Sheet1.VerticalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Goldenrod)
'        Me.FP_FORMASPAGO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
'        Me.FP_FORMASPAGO.SetActiveViewport(0, -1, 0)
'        '
'        'LFORPAG
'        '
'        Me.LFORPAG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.LFORPAG.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.LFORPAG.Location = New System.Drawing.Point(674, 681)
'        Me.LFORPAG.Name = "LFORPAG"
'        Me.LFORPAG.Size = New System.Drawing.Size(152, 24)
'        Me.LFORPAG.TabIndex = 490
'        Me.LFORPAG.Visible = False
'        '
'        'ntx_totalventa
'        '
'        Me.ntx_totalventa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.ntx_totalventa.BackColor = System.Drawing.Color.Transparent
'        Me.ntx_totalventa.Location = New System.Drawing.Point(191, 590)
'        Me.ntx_totalventa.Name = "ntx_totalventa"
'        Me.ntx_totalventa.Size = New System.Drawing.Size(152, 24)
'        Me.ntx_totalventa.TabIndex = 201
'        Me.ntx_totalventa.Visible = False
'        '
'        'ntx_totalpago
'        '
'        Me.ntx_totalpago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.ntx_totalpago.BackColor = System.Drawing.Color.Transparent
'        Me.ntx_totalpago.Location = New System.Drawing.Point(191, 609)
'        Me.ntx_totalpago.Name = "ntx_totalpago"
'        Me.ntx_totalpago.Size = New System.Drawing.Size(152, 24)
'        Me.ntx_totalpago.TabIndex = 202
'        Me.ntx_totalpago.Visible = False
'        '
'        'Label11
'        '
'        Me.Label11.BackColor = System.Drawing.Color.Transparent
'        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label11.Location = New System.Drawing.Point(459, 36)
'        Me.Label11.Name = "Label11"
'        Me.Label11.Size = New System.Drawing.Size(367, 24)
'        Me.Label11.TabIndex = 212
'        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'Lkilos
'        '
'        Me.Lkilos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.Lkilos.BackColor = System.Drawing.Color.Transparent
'        Me.Lkilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Lkilos.ForeColor = System.Drawing.Color.Black
'        Me.Lkilos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
'        Me.Lkilos.Location = New System.Drawing.Point(573, 706)
'        Me.Lkilos.Name = "Lkilos"
'        Me.Lkilos.Size = New System.Drawing.Size(135, 23)
'        Me.Lkilos.TabIndex = 214
'        Me.Lkilos.Text = "Kilos"
'        Me.Lkilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        Me.Lkilos.Visible = False
'        '
'        'busqueda
'        '
'        Me.busqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.busqueda.BackColor = System.Drawing.Color.Transparent
'        Me.busqueda.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.busqueda.ForeColor = System.Drawing.Color.Black
'        Me.busqueda.Location = New System.Drawing.Point(170, 702)
'        Me.busqueda.Name = "busqueda"
'        Me.busqueda.Size = New System.Drawing.Size(97, 24)
'        Me.busqueda.TabIndex = 215
'        Me.busqueda.Text = "Buscar:"
'        Me.busqueda.Visible = False
'        '
'        'txt_tipoventa
'        '
'        Me.txt_tipoventa.BackColor = System.Drawing.Color.MidnightBlue
'        Me.txt_tipoventa.BorderStyle = System.Windows.Forms.BorderStyle.None
'        Me.txt_tipoventa.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_tipoventa.ForeColor = System.Drawing.Color.White
'        Me.txt_tipoventa.Location = New System.Drawing.Point(786, 12)
'        Me.txt_tipoventa.Name = "txt_tipoventa"
'        Me.txt_tipoventa.Size = New System.Drawing.Size(40, 19)
'        Me.txt_tipoventa.TabIndex = 0
'        '
'        'fp_articulos
'        '
'        Me.fp_articulos.AccessibleDescription = "fp_articulos, Sheet1, Row 0, Column 0, "
'        Me.fp_articulos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.fp_articulos.BackColor = System.Drawing.Color.White
'        Me.fp_articulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.fp_articulos.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
'        Me.fp_articulos.HorizontalScrollBar.Name = ""
'        EnhancedScrollBarRenderer3.ArrowColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer3.ArrowHoveredColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer3.ArrowSelectedColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer3.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer3.ButtonBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer3.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer3.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer3.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer3.ButtonSelectedBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer3.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer3.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
'        Me.fp_articulos.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer3
'        Me.fp_articulos.HorizontalScrollBar.TabIndex = 28
'        Me.fp_articulos.Location = New System.Drawing.Point(137, 97)
'        Me.fp_articulos.Name = "fp_articulos"
'        NamedStyle2.BackColor = System.Drawing.Color.DarkGray
'        NamedStyle2.CellType = GeneralCellType2
'        NamedStyle2.ForeColor = System.Drawing.SystemColors.WindowText
'        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
'        NamedStyle2.Renderer = GeneralCellType2
'        Me.fp_articulos.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle2})
'        Me.fp_articulos.RightToLeft = System.Windows.Forms.RightToLeft.No
'        Me.fp_articulos.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.fp_articulos_Sheet1})
'        Me.fp_articulos.Size = New System.Drawing.Size(689, 490)
'        Me.fp_articulos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Sunburst
'        Me.fp_articulos.TabIndex = 221
'        Me.fp_articulos.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
'        Me.fp_articulos.VerticalScrollBar.Name = ""
'        EnhancedScrollBarRenderer4.ArrowColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer4.ArrowHoveredColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer4.ArrowSelectedColor = System.Drawing.Color.DarkRed
'        EnhancedScrollBarRenderer4.ButtonBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer4.ButtonBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer4.ButtonHoveredBackgroundColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer4.ButtonHoveredBorderColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer4.ButtonSelectedBackgroundColor = System.Drawing.Color.DarkOrange
'        EnhancedScrollBarRenderer4.ButtonSelectedBorderColor = System.Drawing.Color.Orange
'        EnhancedScrollBarRenderer4.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(96, Byte), Integer))
'        EnhancedScrollBarRenderer4.TrackBarSelectedBackgroundColor = System.Drawing.Color.Orange
'        Me.fp_articulos.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer4
'        Me.fp_articulos.VerticalScrollBar.TabIndex = 29
'        '
'        'fp_articulos_Sheet1
'        '
'        Me.fp_articulos_Sheet1.Reset()
'        Me.fp_articulos_Sheet1.SheetName = "Sheet1"
'        'Formulas and custom names must be loaded with R1C1 reference style
'        Me.fp_articulos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
'        Me.fp_articulos_Sheet1.ColumnCount = 18
'        Me.fp_articulos_Sheet1.RowHeader.ColumnCount = 0
'        Me.fp_articulos_Sheet1.Cells.Get(0, 4).CellType = TextCellType23
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Cantidad"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Artículo"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Precio"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Total"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "UPCInv"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Vale"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "% IVA"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "F1"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 8).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 8).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "F2"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 9).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 9).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "F3"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 10).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 10).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "% IEPS"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 11).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 11).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "ArtClave"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 12).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 12).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "NomLargo"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 13).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 13).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Familia"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 14).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 14).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "CostoCap2"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 15).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 15).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "TipoOferta"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 16).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 16).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Precio1"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 17).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 17).ForeColor = System.Drawing.SystemColors.Highlight
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Comisión"
'        Me.fp_articulos_Sheet1.ColumnHeader.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
'        Me.fp_articulos_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
'        Me.fp_articulos_Sheet1.ColumnHeader.Rows.Get(0).Height = 25.0!
'        NumberCellType26.DecimalPlaces = 4
'        NumberCellType26.DecimalSeparator = "."
'        NumberCellType26.Separator = ","
'        NumberCellType26.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(0).CellType = NumberCellType26
'        Me.fp_articulos_Sheet1.Columns.Get(0).Label = "Cantidad"
'        Me.fp_articulos_Sheet1.Columns.Get(0).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(0).Width = 84.0!
'        Me.fp_articulos_Sheet1.Columns.Get(1).CellType = TextCellType24
'        Me.fp_articulos_Sheet1.Columns.Get(1).Label = "Artículo"
'        Me.fp_articulos_Sheet1.Columns.Get(1).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(1).Width = 280.0!
'        CurrencyCellType16.CurrencySymbol = "$"
'        CurrencyCellType16.DecimalPlaces = 2
'        CurrencyCellType16.DecimalSeparator = "."
'        CurrencyCellType16.Separator = ","
'        CurrencyCellType16.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(2).CellType = CurrencyCellType16
'        Me.fp_articulos_Sheet1.Columns.Get(2).Label = "Precio"
'        Me.fp_articulos_Sheet1.Columns.Get(2).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(2).Width = 114.0!
'        CurrencyCellType17.CurrencySymbol = "$"
'        CurrencyCellType17.DecimalPlaces = 2
'        CurrencyCellType17.DecimalSeparator = "."
'        CurrencyCellType17.Separator = ","
'        CurrencyCellType17.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(3).CellType = CurrencyCellType17
'        Me.fp_articulos_Sheet1.Columns.Get(3).Label = "Total"
'        Me.fp_articulos_Sheet1.Columns.Get(3).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(3).Width = 124.0!
'        Me.fp_articulos_Sheet1.Columns.Get(4).Label = "UPCInv"
'        Me.fp_articulos_Sheet1.Columns.Get(4).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(4).Visible = False
'        Me.fp_articulos_Sheet1.Columns.Get(4).Width = 90.0!
'        Me.fp_articulos_Sheet1.Columns.Get(5).CellType = TextCellType25
'        Me.fp_articulos_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(5).Label = "Vale"
'        Me.fp_articulos_Sheet1.Columns.Get(5).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(5).Width = 50.0!
'        NumberCellType27.DecimalPlaces = 2
'        NumberCellType27.DecimalSeparator = "."
'        NumberCellType27.Separator = ","
'        NumberCellType27.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(6).CellType = NumberCellType27
'        Me.fp_articulos_Sheet1.Columns.Get(6).Label = "% IVA"
'        Me.fp_articulos_Sheet1.Columns.Get(6).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(6).Width = 70.0!
'        NumberCellType28.DecimalPlaces = 0
'        NumberCellType28.DecimalSeparator = "."
'        NumberCellType28.Separator = ","
'        NumberCellType28.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(7).CellType = NumberCellType28
'        Me.fp_articulos_Sheet1.Columns.Get(7).Label = "F1"
'        Me.fp_articulos_Sheet1.Columns.Get(7).Locked = True
'        Me.fp_articulos_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(7).Width = 50.0!
'        NumberCellType29.DecimalPlaces = 0
'        NumberCellType29.DecimalSeparator = "."
'        NumberCellType29.Separator = ","
'        NumberCellType29.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(8).CellType = NumberCellType29
'        Me.fp_articulos_Sheet1.Columns.Get(8).Label = "F2"
'        Me.fp_articulos_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(8).Width = 50.0!
'        NumberCellType30.DecimalPlaces = 0
'        NumberCellType30.DecimalSeparator = "."
'        NumberCellType30.Separator = ","
'        NumberCellType30.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(9).CellType = NumberCellType30
'        Me.fp_articulos_Sheet1.Columns.Get(9).Label = "F3"
'        Me.fp_articulos_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(9).Width = 50.0!
'        NumberCellType31.DecimalPlaces = 2
'        NumberCellType31.DecimalSeparator = "."
'        NumberCellType31.Separator = ","
'        NumberCellType31.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(10).CellType = NumberCellType31
'        Me.fp_articulos_Sheet1.Columns.Get(10).Label = "% IEPS"
'        Me.fp_articulos_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(10).Width = 70.0!
'        Me.fp_articulos_Sheet1.Columns.Get(11).CellType = TextCellType26
'        Me.fp_articulos_Sheet1.Columns.Get(11).Label = "ArtClave"
'        Me.fp_articulos_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(11).Width = 110.0!
'        Me.fp_articulos_Sheet1.Columns.Get(12).CellType = TextCellType27
'        Me.fp_articulos_Sheet1.Columns.Get(12).Label = "NomLargo"
'        Me.fp_articulos_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(12).Width = 280.0!
'        Me.fp_articulos_Sheet1.Columns.Get(13).CellType = TextCellType28
'        Me.fp_articulos_Sheet1.Columns.Get(13).Label = "Familia"
'        Me.fp_articulos_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(13).Width = 90.0!
'        CurrencyCellType18.CurrencySymbol = "$"
'        CurrencyCellType18.DecimalPlaces = 2
'        CurrencyCellType18.DecimalSeparator = "."
'        CurrencyCellType18.Separator = ","
'        CurrencyCellType18.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(14).CellType = CurrencyCellType18
'        Me.fp_articulos_Sheet1.Columns.Get(14).Label = "CostoCap2"
'        Me.fp_articulos_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
'        Me.fp_articulos_Sheet1.Columns.Get(14).Width = 114.0!
'        NumberCellType32.DecimalPlaces = 0
'        NumberCellType32.DecimalSeparator = "."
'        NumberCellType32.Separator = ","
'        NumberCellType32.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(15).CellType = NumberCellType32
'        Me.fp_articulos_Sheet1.Columns.Get(15).Label = "TipoOferta"
'        Me.fp_articulos_Sheet1.Columns.Get(15).Width = 106.0!
'        CurrencyCellType19.DecimalPlaces = 3
'        CurrencyCellType19.DecimalSeparator = "."
'        CurrencyCellType19.Separator = ","
'        CurrencyCellType19.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(16).CellType = CurrencyCellType19
'        Me.fp_articulos_Sheet1.Columns.Get(16).Label = "Precio1"
'        Me.fp_articulos_Sheet1.Columns.Get(16).Width = 90.0!
'        CurrencyCellType20.DecimalPlaces = 3
'        CurrencyCellType20.DecimalSeparator = "."
'        CurrencyCellType20.Separator = ","
'        CurrencyCellType20.ShowSeparator = True
'        Me.fp_articulos_Sheet1.Columns.Get(17).CellType = CurrencyCellType20
'        Me.fp_articulos_Sheet1.Columns.Get(17).Label = "Comisión"
'        Me.fp_articulos_Sheet1.Columns.Get(17).Width = 100.0!
'        Me.fp_articulos_Sheet1.RowHeader.Columns.Default.Resizable = False
'        Me.fp_articulos_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
'        Me.fp_articulos_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSunburst"
'        Me.fp_articulos_Sheet1.Rows.Get(0).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(1).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(2).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(3).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(4).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(5).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(6).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(7).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(8).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(9).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(10).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(11).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(12).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(13).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(14).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(15).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(16).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(17).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(18).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(19).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(20).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(21).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(22).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(23).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(24).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(25).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(26).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(27).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(28).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(29).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(30).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(31).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(32).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(33).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(34).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(35).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(36).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(37).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(38).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(39).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(40).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(41).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(42).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(43).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(44).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(45).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(46).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(47).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(48).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(49).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(50).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(51).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(52).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(53).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(54).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(55).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(56).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(57).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(58).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(59).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(60).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(61).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(62).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(63).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(64).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(65).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(66).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(67).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(68).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(69).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(70).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(71).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(72).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(73).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(74).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(75).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(76).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(77).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(78).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(79).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(80).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(81).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(82).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(83).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(84).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(85).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(86).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(87).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(88).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(89).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(90).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(91).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(92).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(93).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(94).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(95).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(96).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(97).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(98).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(99).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(100).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(101).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(102).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(103).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(104).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(105).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(106).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(107).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(108).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(109).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(110).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(111).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(112).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(113).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(114).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(115).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(116).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(117).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(118).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(119).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(120).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(121).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(122).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(123).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(124).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(125).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(126).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(127).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(128).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(129).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(130).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(131).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(132).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(133).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(134).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(135).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(136).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(137).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(138).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(139).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(140).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(141).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(142).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(143).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(144).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(145).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(146).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(147).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(148).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(149).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(150).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(151).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(152).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(153).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(154).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(155).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(156).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(157).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(158).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(159).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(160).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(161).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(162).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(163).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(164).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(165).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(166).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(167).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(168).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(169).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(170).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(171).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(172).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(173).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(174).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(175).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(176).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(177).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(178).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(179).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(180).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(181).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(182).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(183).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(184).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(185).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(186).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(187).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(188).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(189).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(190).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(191).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(192).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(193).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(194).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(195).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(196).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(197).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(198).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(199).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(200).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(201).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(202).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(203).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(204).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(205).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(206).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(207).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(208).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(209).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(210).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(211).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(212).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(213).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(214).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(215).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(216).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(217).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(218).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(219).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(220).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(221).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(222).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(223).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(224).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(225).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(226).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(227).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(228).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(229).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(230).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(231).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(232).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(233).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(234).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(235).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(236).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(237).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(238).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(239).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(240).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(241).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(242).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(243).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(244).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(245).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(246).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(247).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(248).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(249).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(250).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(251).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(252).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(253).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(254).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(255).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(256).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(257).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(258).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(259).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(260).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(261).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(262).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(263).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(264).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(265).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(266).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(267).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(268).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(269).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(270).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(271).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(272).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(273).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(274).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(275).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(276).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(277).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(278).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(279).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(280).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(281).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(282).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(283).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(284).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(285).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(286).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(287).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(288).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(289).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(290).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(291).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(292).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(293).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(294).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(295).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(296).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(297).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(298).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(299).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(300).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(301).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(302).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(303).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(304).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(305).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(306).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(307).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(308).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(309).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(310).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(311).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(312).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(313).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(314).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(315).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(316).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(317).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(318).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(319).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(320).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(321).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(322).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(323).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(324).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(325).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(326).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(327).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(328).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(329).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(330).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(331).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(332).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(333).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(334).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(335).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(336).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(337).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(338).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(339).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(340).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(341).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(342).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(343).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(344).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(345).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(346).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(347).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(348).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(349).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(350).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(351).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(352).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(353).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(354).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(355).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(356).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(357).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(358).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(359).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(360).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(361).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(362).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(363).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(364).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(365).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(366).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(367).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(368).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(369).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(370).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(371).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(372).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(373).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(374).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(375).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(376).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(377).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(378).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(379).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(380).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(381).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(382).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(383).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(384).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(385).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(386).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(387).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(388).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(389).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(390).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(391).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(392).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(393).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(394).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(395).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(396).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(397).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(398).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(399).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(400).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(401).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(402).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(403).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(404).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(405).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(406).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(407).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(408).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(409).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(410).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(411).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(412).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(413).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(414).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(415).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(416).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(417).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(418).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(419).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(420).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(421).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(422).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(423).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(424).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(425).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(426).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(427).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(428).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(429).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(430).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(431).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(432).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(433).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(434).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(435).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(436).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(437).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(438).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(439).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(440).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(441).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(442).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(443).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(444).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(445).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(446).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(447).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(448).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(449).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(450).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(451).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(452).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(453).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(454).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(455).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(456).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(457).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(458).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(459).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(460).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(461).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(462).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(463).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(464).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(465).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(466).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(467).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(468).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(469).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(470).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(471).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(472).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(473).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(474).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(475).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(476).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(477).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(478).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(479).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(480).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(481).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(482).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(483).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(484).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(485).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(486).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(487).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(488).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(489).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(490).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(491).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(492).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(493).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(494).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(495).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(496).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(497).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(498).Height = 41.0!
'        Me.fp_articulos_Sheet1.Rows.Get(499).Height = 41.0!
'        Me.fp_articulos_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
'        Me.fp_articulos_Sheet1.SheetCornerStyle.Parent = "CornerSunburst"
'        Me.fp_articulos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
'        '
'        'Panel1
'        '
'        Me.Panel1.BackColor = System.Drawing.Color.Red
'        Me.Panel1.Controls.Add(Me.txe)
'        Me.Panel1.Controls.Add(Me.Label2)
'        Me.Panel1.Controls.Add(Me.txt_cveenc)
'        Me.Panel1.Controls.Add(Me.Label25)
'        Me.Panel1.Controls.Add(Me.Label24)
'        Me.Panel1.Location = New System.Drawing.Point(283, 193)
'        Me.Panel1.Name = "Panel1"
'        Me.Panel1.Size = New System.Drawing.Size(368, 260)
'        Me.Panel1.TabIndex = 223
'        Me.Panel1.Visible = False
'        '
'        'txe
'        '
'        Me.txe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txe.Location = New System.Drawing.Point(12, 63)
'        Me.txe.Multiline = True
'        Me.txe.Name = "txe"
'        Me.txe.Size = New System.Drawing.Size(343, 110)
'        Me.txe.TabIndex = 500
'        '
'        'Label2
'        '
'        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label2.ForeColor = System.Drawing.Color.White
'        Me.Label2.Location = New System.Drawing.Point(12, 11)
'        Me.Label2.Name = "Label2"
'        Me.Label2.Size = New System.Drawing.Size(343, 32)
'        Me.Label2.TabIndex = 4
'        Me.Label2.Text = "Autorizar Cancelación de Productos"
'        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'txt_cveenc
'        '
'        Me.txt_cveenc.Location = New System.Drawing.Point(80, 215)
'        Me.txt_cveenc.Name = "txt_cveenc"
'        Me.txt_cveenc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
'        Me.txt_cveenc.Size = New System.Drawing.Size(216, 20)
'        Me.txt_cveenc.TabIndex = 501
'        '
'        'Label25
'        '
'        Me.Label25.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label25.ForeColor = System.Drawing.Color.White
'        Me.Label25.Location = New System.Drawing.Point(44, 180)
'        Me.Label25.Name = "Label25"
'        Me.Label25.Size = New System.Drawing.Size(280, 32)
'        Me.Label25.TabIndex = 1
'        Me.Label25.Text = "Clave Supervisor:"
'        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'Label24
'        '
'        Me.Label24.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label24.ForeColor = System.Drawing.Color.White
'        Me.Label24.Location = New System.Drawing.Point(48, 16)
'        Me.Label24.Name = "Label24"
'        Me.Label24.Size = New System.Drawing.Size(280, 32)
'        Me.Label24.TabIndex = 0
'        Me.Label24.Text = "PRODUCTO NO ENCONTRADO"
'        '
'        'PictureBox1
'        '
'        Me.PictureBox1.BackColor = System.Drawing.Color.White
'        Me.PictureBox1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
'        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox1.Location = New System.Drawing.Point(12, 427)
'        Me.PictureBox1.Name = "PictureBox1"
'        Me.PictureBox1.Size = New System.Drawing.Size(44, 44)
'        Me.PictureBox1.TabIndex = 226
'        Me.PictureBox1.TabStop = False
'        '
'        'Label6
'        '
'        Me.Label6.BackColor = System.Drawing.Color.Transparent
'        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label6.Location = New System.Drawing.Point(456, 10)
'        Me.Label6.Name = "Label6"
'        Me.Label6.Size = New System.Drawing.Size(324, 22)
'        Me.Label6.TabIndex = 234
'        Me.Label6.Text = "Caja:"
'        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'Label27
'        '
'        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.Label27.BackColor = System.Drawing.Color.White
'        Me.Label27.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label27.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Label27.Location = New System.Drawing.Point(186, 596)
'        Me.Label27.Name = "Label27"
'        Me.Label27.Size = New System.Drawing.Size(379, 32)
'        Me.Label27.TabIndex = 240
'        Me.Label27.Text = "                                  TOTAL:"
'        '
'        'Label1
'        '
'        Me.Label1.BackColor = System.Drawing.Color.Transparent
'        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label1.ForeColor = System.Drawing.Color.DarkGray
'        Me.Label1.Location = New System.Drawing.Point(133, 9)
'        Me.Label1.Name = "Label1"
'        Me.Label1.Size = New System.Drawing.Size(186, 21)
'        Me.Label1.TabIndex = 471
'        Me.Label1.Text = "Administración de Ventas"
'        '
'        'Label28
'        '
'        Me.Label28.BackColor = System.Drawing.Color.Transparent
'        Me.Label28.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label28.ForeColor = System.Drawing.Color.Navy
'        Me.Label28.Location = New System.Drawing.Point(132, 31)
'        Me.Label28.Name = "Label28"
'        Me.Label28.Size = New System.Drawing.Size(318, 26)
'        Me.Label28.TabIndex = 470
'        Me.Label28.Text = "Venta Público Menudeo y Mayoreo"
'        '
'        'PictureBox2
'        '
'        Me.PictureBox2.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
'        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox2.Location = New System.Drawing.Point(3, -1)
'        Me.PictureBox2.Name = "PictureBox2"
'        Me.PictureBox2.Size = New System.Drawing.Size(123, 123)
'        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
'        Me.PictureBox2.TabIndex = 469
'        Me.PictureBox2.TabStop = False
'        '
'        'PictureBox3
'        '
'        Me.PictureBox3.BackColor = System.Drawing.Color.White
'        Me.PictureBox3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.borrar
'        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox3.Location = New System.Drawing.Point(12, 177)
'        Me.PictureBox3.Name = "PictureBox3"
'        Me.PictureBox3.Size = New System.Drawing.Size(44, 44)
'        Me.PictureBox3.TabIndex = 472
'        Me.PictureBox3.TabStop = False
'        '
'        'PictureBox4
'        '
'        Me.PictureBox4.BackColor = System.Drawing.Color.White
'        Me.PictureBox4.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROGUARDAR
'        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox4.Location = New System.Drawing.Point(12, 227)
'        Me.PictureBox4.Name = "PictureBox4"
'        Me.PictureBox4.Size = New System.Drawing.Size(44, 44)
'        Me.PictureBox4.TabIndex = 473
'        Me.PictureBox4.TabStop = False
'        '
'        'PictureBox5
'        '
'        Me.PictureBox5.BackColor = System.Drawing.Color.White
'        Me.PictureBox5.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.BOTON_NUEVO
'        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox5.Location = New System.Drawing.Point(12, 277)
'        Me.PictureBox5.Name = "PictureBox5"
'        Me.PictureBox5.Size = New System.Drawing.Size(44, 44)
'        Me.PictureBox5.TabIndex = 474
'        Me.PictureBox5.TabStop = False
'        '
'        'PictureBox6
'        '
'        Me.PictureBox6.BackColor = System.Drawing.Color.White
'        Me.PictureBox6.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
'        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox6.Location = New System.Drawing.Point(12, 327)
'        Me.PictureBox6.Name = "PictureBox6"
'        Me.PictureBox6.Size = New System.Drawing.Size(44, 44)
'        Me.PictureBox6.TabIndex = 475
'        Me.PictureBox6.TabStop = False
'        '
'        'PictureBox11
'        '
'        Me.PictureBox11.BackColor = System.Drawing.Color.White
'        Me.PictureBox11.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.buscar
'        Me.PictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox11.Location = New System.Drawing.Point(12, 126)
'        Me.PictureBox11.Name = "PictureBox11"
'        Me.PictureBox11.Size = New System.Drawing.Size(44, 44)
'        Me.PictureBox11.TabIndex = 480
'        Me.PictureBox11.TabStop = False
'        '
'        'Label3
'        '
'        Me.Label3.BackColor = System.Drawing.Color.Transparent
'        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label3.ForeColor = System.Drawing.Color.Navy
'        Me.Label3.Location = New System.Drawing.Point(62, 126)
'        Me.Label3.Name = "Label3"
'        Me.Label3.Size = New System.Drawing.Size(168, 44)
'        Me.Label3.TabIndex = 481
'        Me.Label3.Text = "F1 - Buscar Artículo"
'        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label29
'        '
'        Me.Label29.BackColor = System.Drawing.Color.Transparent
'        Me.Label29.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label29.ForeColor = System.Drawing.Color.Navy
'        Me.Label29.Location = New System.Drawing.Point(62, 177)
'        Me.Label29.Name = "Label29"
'        Me.Label29.Size = New System.Drawing.Size(168, 44)
'        Me.Label29.TabIndex = 482
'        Me.Label29.Text = "F2 - Cancelar Artículo"
'        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label30
'        '
'        Me.Label30.BackColor = System.Drawing.Color.Transparent
'        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label30.ForeColor = System.Drawing.Color.Navy
'        Me.Label30.Location = New System.Drawing.Point(62, 227)
'        Me.Label30.Name = "Label30"
'        Me.Label30.Size = New System.Drawing.Size(168, 44)
'        Me.Label30.TabIndex = 483
'        Me.Label30.Text = "F3 - Modificar Cantidad"
'        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label31
'        '
'        Me.Label31.BackColor = System.Drawing.Color.Transparent
'        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label31.ForeColor = System.Drawing.Color.Navy
'        Me.Label31.Location = New System.Drawing.Point(62, 277)
'        Me.Label31.Name = "Label31"
'        Me.Label31.Size = New System.Drawing.Size(168, 44)
'        Me.Label31.TabIndex = 484
'        Me.Label31.Text = "F4 - Terminar Venta"
'        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label32
'        '
'        Me.Label32.BackColor = System.Drawing.Color.Transparent
'        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label32.ForeColor = System.Drawing.Color.Navy
'        Me.Label32.Location = New System.Drawing.Point(62, 327)
'        Me.Label32.Name = "Label32"
'        Me.Label32.Size = New System.Drawing.Size(168, 44)
'        Me.Label32.TabIndex = 485
'        Me.Label32.Text = "F11 - Devolución"
'        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Panel3
'        '
'        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
'        Me.Panel3.Controls.Add(Me.BtnCambiaCliente)
'        Me.Panel3.Controls.Add(Me.BtnCambiaVenta)
'        Me.Panel3.Controls.Add(Me.TxtControl)
'        Me.Panel3.Controls.Add(Me.PictureBox7)
'        Me.Panel3.Controls.Add(Me.Label8)
'        Me.Panel3.Controls.Add(Me.Label7)
'        Me.Panel3.Controls.Add(Me.PictureBox1)
'        Me.Panel3.Controls.Add(Me.PictureBox12)
'        Me.Panel3.Controls.Add(Me.PictureBox11)
'        Me.Panel3.Controls.Add(Me.PictureBox5)
'        Me.Panel3.Controls.Add(Me.PictureBox6)
'        Me.Panel3.Controls.Add(Me.Label3)
'        Me.Panel3.Controls.Add(Me.PictureBox4)
'        Me.Panel3.Controls.Add(Me.Label30)
'        Me.Panel3.Controls.Add(Me.Label29)
'        Me.Panel3.Controls.Add(Me.Label32)
'        Me.Panel3.Controls.Add(Me.Label31)
'        Me.Panel3.Controls.Add(Me.PictureBox3)
'        Me.Panel3.Location = New System.Drawing.Point(832, 4)
'        Me.Panel3.Name = "Panel3"
'        Me.Panel3.Size = New System.Drawing.Size(237, 731)
'        Me.Panel3.TabIndex = 487
'        '
'        'BtnCambiaCliente
'        '
'        Me.BtnCambiaCliente.Enabled = False
'        Me.BtnCambiaCliente.ForeColor = System.Drawing.Color.Navy
'        Me.BtnCambiaCliente.Location = New System.Drawing.Point(12, 37)
'        Me.BtnCambiaCliente.Name = "BtnCambiaCliente"
'        Me.BtnCambiaCliente.Size = New System.Drawing.Size(109, 23)
'        Me.BtnCambiaCliente.TabIndex = 507
'        Me.BtnCambiaCliente.Text = "Cambiar Cliente"
'        Me.BtnCambiaCliente.UseVisualStyleBackColor = True
'        '
'        'BtnCambiaVenta
'        '
'        Me.BtnCambiaVenta.Enabled = False
'        Me.BtnCambiaVenta.ForeColor = System.Drawing.Color.Navy
'        Me.BtnCambiaVenta.Location = New System.Drawing.Point(12, 8)
'        Me.BtnCambiaVenta.Name = "BtnCambiaVenta"
'        Me.BtnCambiaVenta.Size = New System.Drawing.Size(109, 23)
'        Me.BtnCambiaVenta.TabIndex = 507
'        Me.BtnCambiaVenta.Text = "Cambiar Tipo Venta"
'        Me.BtnCambiaVenta.UseVisualStyleBackColor = True
'        '
'        'TxtControl
'        '
'        Me.TxtControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.TxtControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.TxtControl.Location = New System.Drawing.Point(205, 3)
'        Me.TxtControl.Name = "TxtControl"
'        Me.TxtControl.Size = New System.Drawing.Size(29, 26)
'        Me.TxtControl.TabIndex = 505
'        Me.TxtControl.Text = "0"
'        Me.TxtControl.Visible = False
'        '
'        'PictureBox7
'        '
'        Me.PictureBox7.BackColor = System.Drawing.Color.White
'        Me.PictureBox7.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.logoDUARSA
'        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox7.Location = New System.Drawing.Point(41, 648)
'        Me.PictureBox7.Name = "PictureBox7"
'        Me.PictureBox7.Size = New System.Drawing.Size(138, 71)
'        Me.PictureBox7.TabIndex = 489
'        Me.PictureBox7.TabStop = False
'        '
'        'Label8
'        '
'        Me.Label8.BackColor = System.Drawing.Color.Transparent
'        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label8.ForeColor = System.Drawing.Color.Navy
'        Me.Label8.Location = New System.Drawing.Point(62, 377)
'        Me.Label8.Name = "Label8"
'        Me.Label8.Size = New System.Drawing.Size(168, 44)
'        Me.Label8.TabIndex = 488
'        Me.Label8.Text = "F12 - Facturación"
'        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'Label7
'        '
'        Me.Label7.BackColor = System.Drawing.Color.Transparent
'        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label7.ForeColor = System.Drawing.Color.Navy
'        Me.Label7.Location = New System.Drawing.Point(62, 425)
'        Me.Label7.Name = "Label7"
'        Me.Label7.Size = New System.Drawing.Size(168, 44)
'        Me.Label7.TabIndex = 486
'        Me.Label7.Text = "Salir"
'        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'PictureBox12
'        '
'        Me.PictureBox12.BackColor = System.Drawing.Color.White
'        Me.PictureBox12.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.exportar
'        Me.PictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.PictureBox12.Location = New System.Drawing.Point(12, 377)
'        Me.PictureBox12.Name = "PictureBox12"
'        Me.PictureBox12.Size = New System.Drawing.Size(44, 44)
'        Me.PictureBox12.TabIndex = 487
'        Me.PictureBox12.TabStop = False
'        '
'        'Panel5
'        '
'        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.Panel5.BackColor = System.Drawing.Color.LightBlue
'        Me.Panel5.Location = New System.Drawing.Point(3, 123)
'        Me.Panel5.Name = "Panel5"
'        Me.Panel5.Size = New System.Drawing.Size(123, 612)
'        Me.Panel5.TabIndex = 488
'        '
'        'Label16
'        '
'        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.Label16.BackColor = System.Drawing.Color.Transparent
'        Me.Label16.Font = New System.Drawing.Font("Arial", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label16.ForeColor = System.Drawing.Color.Silver
'        Me.Label16.Location = New System.Drawing.Point(161, 640)
'        Me.Label16.Name = "Label16"
'        Me.Label16.Size = New System.Drawing.Size(665, 47)
'        Me.Label16.TabIndex = 489
'        Me.Label16.Text = "GRACIAS POR SU PREFERENCIA"
'        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'panelofe
'        '
'        Me.panelofe.BackColor = System.Drawing.Color.Red
'        Me.panelofe.Controls.Add(Me.LbIDOferta)
'        Me.panelofe.Controls.Add(Me.BTN_NUEVO)
'        Me.panelofe.Controls.Add(Me.Label21)
'        Me.panelofe.Controls.Add(Me.txt_panelofe)
'        Me.panelofe.Controls.Add(Me.txtnotifica)
'        Me.panelofe.Controls.Add(Me.Label20)
'        Me.panelofe.Controls.Add(Me.Button2)
'        Me.panelofe.Location = New System.Drawing.Point(177, 135)
'        Me.panelofe.Name = "panelofe"
'        Me.panelofe.Size = New System.Drawing.Size(450, 270)
'        Me.panelofe.TabIndex = 502
'        Me.panelofe.Visible = False
'        '
'        'LbIDOferta
'        '
'        Me.LbIDOferta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.LbIDOferta.ForeColor = System.Drawing.Color.White
'        Me.LbIDOferta.Location = New System.Drawing.Point(400, 0)
'        Me.LbIDOferta.Name = "LbIDOferta"
'        Me.LbIDOferta.Size = New System.Drawing.Size(50, 23)
'        Me.LbIDOferta.TabIndex = 529
'        Me.LbIDOferta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        Me.LbIDOferta.Visible = False
'        '
'        'BTN_NUEVO
'        '
'        Me.BTN_NUEVO.BackColor = System.Drawing.Color.White
'        Me.BTN_NUEVO.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
'        Me.BTN_NUEVO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.BTN_NUEVO.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.BTN_NUEVO.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.BTN_NUEVO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
'        Me.BTN_NUEVO.Location = New System.Drawing.Point(355, 202)
'        Me.BTN_NUEVO.Name = "BTN_NUEVO"
'        Me.BTN_NUEVO.Size = New System.Drawing.Size(47, 41)
'        Me.BTN_NUEVO.TabIndex = 528
'        Me.BTN_NUEVO.Tag = "Nuevo"
'        Me.BTN_NUEVO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'        Me.BTN_NUEVO.UseVisualStyleBackColor = False
'        '
'        'Label21
'        '
'        Me.Label21.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label21.ForeColor = System.Drawing.Color.White
'        Me.Label21.Location = New System.Drawing.Point(39, 177)
'        Me.Label21.Name = "Label21"
'        Me.Label21.Size = New System.Drawing.Size(363, 23)
'        Me.Label21.TabIndex = 503
'        Me.Label21.Text = "Supervisor Notificado"
'        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'txt_panelofe
'        '
'        Me.txt_panelofe.Location = New System.Drawing.Point(39, 223)
'        Me.txt_panelofe.Name = "txt_panelofe"
'        Me.txt_panelofe.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
'        Me.txt_panelofe.Size = New System.Drawing.Size(294, 20)
'        Me.txt_panelofe.TabIndex = 502
'        Me.txt_panelofe.UseSystemPasswordChar = True
'        '
'        'txtnotifica
'        '
'        Me.txtnotifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txtnotifica.Location = New System.Drawing.Point(39, 63)
'        Me.txtnotifica.Multiline = True
'        Me.txtnotifica.Name = "txtnotifica"
'        Me.txtnotifica.Size = New System.Drawing.Size(363, 112)
'        Me.txtnotifica.TabIndex = 500
'        '
'        'Label20
'        '
'        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label20.ForeColor = System.Drawing.Color.White
'        Me.Label20.Location = New System.Drawing.Point(39, 19)
'        Me.Label20.Name = "Label20"
'        Me.Label20.Size = New System.Drawing.Size(363, 43)
'        Me.Label20.TabIndex = 4
'        Me.Label20.Text = "Notificación de Oferta Expirada"
'        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'Button2
'        '
'        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Button2.ForeColor = System.Drawing.Color.White
'        Me.Button2.Location = New System.Drawing.Point(240, 272)
'        Me.Button2.Name = "Button2"
'        Me.Button2.Size = New System.Drawing.Size(104, 32)
'        Me.Button2.TabIndex = 3
'        Me.Button2.Text = "Continuar"
'        '
'        'Paneltiempo
'        '
'        Me.Paneltiempo.BackColor = System.Drawing.Color.MediumBlue
'        Me.Paneltiempo.Controls.Add(Me.txt_ctel4)
'        Me.Paneltiempo.Controls.Add(Me.txt_ctel3)
'        Me.Paneltiempo.Controls.Add(Me.txt_ctel2)
'        Me.Paneltiempo.Controls.Add(Me.txt_ctel1)
'        Me.Paneltiempo.Controls.Add(Me.txt_tel4)
'        Me.Paneltiempo.Controls.Add(Me.txt_tel3)
'        Me.Paneltiempo.Controls.Add(Me.txt_tel2)
'        Me.Paneltiempo.Controls.Add(Me.txt_tel1)
'        Me.Paneltiempo.Controls.Add(Me.Button3)
'        Me.Paneltiempo.Controls.Add(Me.Label23)
'        Me.Paneltiempo.Controls.Add(Me.Label36)
'        Me.Paneltiempo.Controls.Add(Me.Button4)
'        Me.Paneltiempo.Location = New System.Drawing.Point(153, 153)
'        Me.Paneltiempo.Name = "Paneltiempo"
'        Me.Paneltiempo.Size = New System.Drawing.Size(450, 231)
'        Me.Paneltiempo.TabIndex = 503
'        Me.Paneltiempo.Visible = False
'        '
'        'txt_ctel4
'        '
'        Me.txt_ctel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_ctel4.Location = New System.Drawing.Point(298, 144)
'        Me.txt_ctel4.Name = "txt_ctel4"
'        Me.txt_ctel4.Size = New System.Drawing.Size(39, 31)
'        Me.txt_ctel4.TabIndex = 536
'        Me.txt_ctel4.Visible = False
'        '
'        'txt_ctel3
'        '
'        Me.txt_ctel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_ctel3.Location = New System.Drawing.Point(242, 144)
'        Me.txt_ctel3.Name = "txt_ctel3"
'        Me.txt_ctel3.Size = New System.Drawing.Size(46, 31)
'        Me.txt_ctel3.TabIndex = 535
'        Me.txt_ctel3.Visible = False
'        '
'        'txt_ctel2
'        '
'        Me.txt_ctel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_ctel2.Location = New System.Drawing.Point(189, 144)
'        Me.txt_ctel2.Name = "txt_ctel2"
'        Me.txt_ctel2.Size = New System.Drawing.Size(47, 31)
'        Me.txt_ctel2.TabIndex = 534
'        Me.txt_ctel2.Visible = False
'        '
'        'txt_ctel1
'        '
'        Me.txt_ctel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_ctel1.Location = New System.Drawing.Point(130, 144)
'        Me.txt_ctel1.Name = "txt_ctel1"
'        Me.txt_ctel1.Size = New System.Drawing.Size(207, 31)
'        Me.txt_ctel1.TabIndex = 533
'        '
'        'txt_tel4
'        '
'        Me.txt_tel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_tel4.Location = New System.Drawing.Point(298, 61)
'        Me.txt_tel4.Name = "txt_tel4"
'        Me.txt_tel4.Size = New System.Drawing.Size(39, 31)
'        Me.txt_tel4.TabIndex = 532
'        Me.txt_tel4.Visible = False
'        '
'        'txt_tel3
'        '
'        Me.txt_tel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_tel3.Location = New System.Drawing.Point(242, 61)
'        Me.txt_tel3.Name = "txt_tel3"
'        Me.txt_tel3.Size = New System.Drawing.Size(46, 31)
'        Me.txt_tel3.TabIndex = 531
'        Me.txt_tel3.Visible = False
'        '
'        'txt_tel2
'        '
'        Me.txt_tel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_tel2.Location = New System.Drawing.Point(189, 61)
'        Me.txt_tel2.Name = "txt_tel2"
'        Me.txt_tel2.Size = New System.Drawing.Size(47, 31)
'        Me.txt_tel2.TabIndex = 530
'        Me.txt_tel2.Visible = False
'        '
'        'txt_tel1
'        '
'        Me.txt_tel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_tel1.Location = New System.Drawing.Point(130, 61)
'        Me.txt_tel1.Name = "txt_tel1"
'        Me.txt_tel1.Size = New System.Drawing.Size(210, 31)
'        Me.txt_tel1.TabIndex = 529
'        '
'        'Button3
'        '
'        Me.Button3.BackColor = System.Drawing.Color.White
'        Me.Button3.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
'        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.Button3.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Button3.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
'        Me.Button3.Location = New System.Drawing.Point(375, 172)
'        Me.Button3.Name = "Button3"
'        Me.Button3.Size = New System.Drawing.Size(47, 41)
'        Me.Button3.TabIndex = 528
'        Me.Button3.Tag = "Nuevo"
'        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'        Me.Button3.UseVisualStyleBackColor = False
'        '
'        'Label23
'        '
'        Me.Label23.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label23.ForeColor = System.Drawing.Color.White
'        Me.Label23.Location = New System.Drawing.Point(102, 109)
'        Me.Label23.Name = "Label23"
'        Me.Label23.Size = New System.Drawing.Size(280, 32)
'        Me.Label23.TabIndex = 503
'        Me.Label23.Text = "Confirmación"
'        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'Label36
'        '
'        Me.Label36.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label36.ForeColor = System.Drawing.Color.White
'        Me.Label36.Location = New System.Drawing.Point(75, 15)
'        Me.Label36.Name = "Label36"
'        Me.Label36.Size = New System.Drawing.Size(344, 43)
'        Me.Label36.TabIndex = 4
'        Me.Label36.Text = "Número de teléfono"
'        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'Button4
'        '
'        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Button4.ForeColor = System.Drawing.Color.White
'        Me.Button4.Location = New System.Drawing.Point(240, 272)
'        Me.Button4.Name = "Button4"
'        Me.Button4.Size = New System.Drawing.Size(104, 32)
'        Me.Button4.TabIndex = 3
'        Me.Button4.Text = "Continuar"
'        '
'        'LbTotal
'        '
'        Me.LbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
'        Me.LbTotal.BackColor = System.Drawing.Color.White
'        Me.LbTotal.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.LbTotal.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.LbTotal.Location = New System.Drawing.Point(571, 596)
'        Me.LbTotal.Name = "LbTotal"
'        Me.LbTotal.Size = New System.Drawing.Size(255, 32)
'        Me.LbTotal.TabIndex = 504
'        Me.LbTotal.Text = "$0.00"
'        Me.LbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'ListBox1
'        '
'        Me.ListBox1.FormattingEnabled = True
'        Me.ListBox1.Location = New System.Drawing.Point(12, 8)
'        Me.ListBox1.Name = "ListBox1"
'        Me.ListBox1.Size = New System.Drawing.Size(344, 160)
'        Me.ListBox1.TabIndex = 505
'        '
'        'PanelCancelaciones
'        '
'        Me.PanelCancelaciones.BackColor = System.Drawing.Color.WhiteSmoke
'        Me.PanelCancelaciones.Controls.Add(Me.ListBox1)
'        Me.PanelCancelaciones.Location = New System.Drawing.Point(274, 49)
'        Me.PanelCancelaciones.Name = "PanelCancelaciones"
'        Me.PanelCancelaciones.Size = New System.Drawing.Size(370, 176)
'        Me.PanelCancelaciones.TabIndex = 506
'        Me.PanelCancelaciones.Visible = False
'        '
'        'PanelSeleccionTarjetas
'        '
'        Me.PanelSeleccionTarjetas.BackColor = System.Drawing.Color.AliceBlue
'        Me.PanelSeleccionTarjetas.Controls.Add(Me.lbFila)
'        Me.PanelSeleccionTarjetas.Controls.Add(Me.BtnCierraPanel)
'        Me.PanelSeleccionTarjetas.Controls.Add(Me.BtnRegistraTarjeta)
'        Me.PanelSeleccionTarjetas.Controls.Add(Me.rbTDebito)
'        Me.PanelSeleccionTarjetas.Controls.Add(Me.rbTCredito)
'        Me.PanelSeleccionTarjetas.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!)
'        Me.PanelSeleccionTarjetas.ForeColor = System.Drawing.Color.Navy
'        Me.PanelSeleccionTarjetas.Location = New System.Drawing.Point(488, 12)
'        Me.PanelSeleccionTarjetas.Name = "PanelSeleccionTarjetas"
'        Me.PanelSeleccionTarjetas.Size = New System.Drawing.Size(196, 70)
'        Me.PanelSeleccionTarjetas.TabIndex = 507
'        Me.PanelSeleccionTarjetas.TabStop = False
'        Me.PanelSeleccionTarjetas.Text = "Seleccione Tipo de Tarjeta"
'        Me.PanelSeleccionTarjetas.Visible = False
'        '
'        'lbFila
'        '
'        Me.lbFila.Font = New System.Drawing.Font("Arial", 8.25!)
'        Me.lbFila.ForeColor = System.Drawing.Color.Navy
'        Me.lbFila.Location = New System.Drawing.Point(145, 12)
'        Me.lbFila.Name = "lbFila"
'        Me.lbFila.Size = New System.Drawing.Size(41, 15)
'        Me.lbFila.TabIndex = 521
'        Me.lbFila.Text = "Fila"
'        Me.lbFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        Me.lbFila.Visible = False
'        '
'        'BtnCierraPanel
'        '
'        Me.BtnCierraPanel.BackColor = System.Drawing.Color.White
'        Me.BtnCierraPanel.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477101_arrow_left_78605__1_
'        Me.BtnCierraPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.BtnCierraPanel.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.BtnCierraPanel.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.BtnCierraPanel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
'        Me.BtnCierraPanel.Location = New System.Drawing.Point(162, 29)
'        Me.BtnCierraPanel.Name = "BtnCierraPanel"
'        Me.BtnCierraPanel.Size = New System.Drawing.Size(24, 24)
'        Me.BtnCierraPanel.TabIndex = 8
'        Me.BtnCierraPanel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'        Me.BtnCierraPanel.UseVisualStyleBackColor = False
'        '
'        'BtnRegistraTarjeta
'        '
'        Me.BtnRegistraTarjeta.BackColor = System.Drawing.Color.White
'        Me.BtnRegistraTarjeta.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477072_check_78599
'        Me.BtnRegistraTarjeta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.BtnRegistraTarjeta.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.BtnRegistraTarjeta.ForeColor = System.Drawing.Color.MidnightBlue
'        Me.BtnRegistraTarjeta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
'        Me.BtnRegistraTarjeta.Location = New System.Drawing.Point(132, 29)
'        Me.BtnRegistraTarjeta.Name = "BtnRegistraTarjeta"
'        Me.BtnRegistraTarjeta.Size = New System.Drawing.Size(24, 24)
'        Me.BtnRegistraTarjeta.TabIndex = 7
'        Me.BtnRegistraTarjeta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'        Me.BtnRegistraTarjeta.UseVisualStyleBackColor = False
'        '
'        'rbTDebito
'        '
'        Me.rbTDebito.AutoSize = True
'        Me.rbTDebito.Location = New System.Drawing.Point(6, 44)
'        Me.rbTDebito.Name = "rbTDebito"
'        Me.rbTDebito.Size = New System.Drawing.Size(109, 19)
'        Me.rbTDebito.TabIndex = 1
'        Me.rbTDebito.TabStop = True
'        Me.rbTDebito.Tag = "Débito"
'        Me.rbTDebito.Text = "Tarjeta de Débito"
'        Me.rbTDebito.UseVisualStyleBackColor = True
'        '
'        'rbTCredito
'        '
'        Me.rbTCredito.AutoSize = True
'        Me.rbTCredito.Location = New System.Drawing.Point(6, 19)
'        Me.rbTCredito.Name = "rbTCredito"
'        Me.rbTCredito.Size = New System.Drawing.Size(112, 19)
'        Me.rbTCredito.TabIndex = 0
'        Me.rbTCredito.TabStop = True
'        Me.rbTCredito.Tag = "Crédito"
'        Me.rbTCredito.Text = "Tarjeta de Crédito"
'        Me.rbTCredito.UseVisualStyleBackColor = True
'        '
'        'LbClienteTicket
'        '
'        Me.LbClienteTicket.BackColor = System.Drawing.Color.Transparent
'        Me.LbClienteTicket.Font = New System.Drawing.Font("Franklin Gothic Medium", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.LbClienteTicket.ForeColor = System.Drawing.Color.Navy
'        Me.LbClienteTicket.Location = New System.Drawing.Point(295, 68)
'        Me.LbClienteTicket.Name = "LbClienteTicket"
'        Me.LbClienteTicket.Size = New System.Drawing.Size(531, 26)
'        Me.LbClienteTicket.TabIndex = 508
'        Me.LbClienteTicket.Text = "Cliente: Público en General"
'        Me.LbClienteTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'FrVenta
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.BackColor = System.Drawing.Color.White
'        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
'        Me.ClientSize = New System.Drawing.Size(1072, 735)
'        Me.Controls.Add(Me.PanelSeleccionTarjetas)
'        Me.Controls.Add(Me.PanelCancelaciones)
'        Me.Controls.Add(Me.LbClienteTicket)
'        Me.Controls.Add(Me.grformapago)
'        Me.Controls.Add(Me.Panel1)
'        Me.Controls.Add(Me.panelofe)
'        Me.Controls.Add(Me.LbTotal)
'        Me.Controls.Add(Me.LFORPAG)
'        Me.Controls.Add(Me.tx_cantidad)
'        Me.Controls.Add(Me.ntx_totalventa)
'        Me.Controls.Add(Me.Paneltiempo)
'        Me.Controls.Add(Me.Lkilos)
'        Me.Controls.Add(Me.ntx_totalpago)
'        Me.Controls.Add(Me.l_cancelacion)
'        Me.Controls.Add(Me.TX_UPC)
'        Me.Controls.Add(Me.l_cantidad)
'        Me.Controls.Add(Me.busqueda)
'        Me.Controls.Add(Me.Panel5)
'        Me.Controls.Add(Me.Panel3)
'        Me.Controls.Add(Me.Label1)
'        Me.Controls.Add(Me.Label28)
'        Me.Controls.Add(Me.PictureBox2)
'        Me.Controls.Add(Me.Label6)
'        Me.Controls.Add(Me.txt_tipoventa)
'        Me.Controls.Add(Me.Label11)
'        Me.Controls.Add(Me.Label16)
'        Me.Controls.Add(Me.Label27)
'        Me.Controls.Add(Me.tb_total)
'        Me.Controls.Add(Me.fp_articulos)
'        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
'        Me.Name = "FrVenta"
'        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
'        Me.Text = "PVENTA"
'        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
'        Me.grformapago.ResumeLayout(False)
'        Me.grformapago.PerformLayout()
'        Me.banco.ResumeLayout(False)
'        Me.banco.PerformLayout()
'        Me.credito.ResumeLayout(False)
'        Me.credito.PerformLayout()
'        Me.GroupBox1.ResumeLayout(False)
'        Me.GroupBox1.PerformLayout()
'        Me.Panel6.ResumeLayout(False)
'        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.FP_FORMASPAGO, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.FP_FORMASPAGO_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.fp_articulos, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.fp_articulos_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.Panel1.ResumeLayout(False)
'        Me.Panel1.PerformLayout()
'        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.Panel3.ResumeLayout(False)
'        Me.Panel3.PerformLayout()
'        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
'        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.panelofe.ResumeLayout(False)
'        Me.panelofe.PerformLayout()
'        Me.Paneltiempo.ResumeLayout(False)
'        Me.Paneltiempo.PerformLayout()
'        Me.PanelCancelaciones.ResumeLayout(False)
'        Me.PanelSeleccionTarjetas.ResumeLayout(False)
'        Me.PanelSeleccionTarjetas.PerformLayout()
'        Me.ResumeLayout(False)
'        Me.PerformLayout()

'    End Sub

'#End Region

'    Private Enum ColVenta
'        ColCantidad = 0
'        ColDescripcion = 1
'        ColPrecio = 2
'        ColTotal = 3
'        ColUPCInv = 4
'        ColVale = 5
'        ColFIVA = 6
'        ColF1 = 7
'        ColF2 = 8
'        ColF3 = 9
'        ColFIEPS = 10
'        ColArtClave = 11
'        ColNomLargo = 12
'        ColFamilia = 13
'        ColCostoCap = 14
'        ColTipoOferta = 15
'        ColPrecio1 = 16
'        ColComisionRen = 17
'    End Enum

'    Dim Corriendo As Boolean
'    Dim TipoTarj As String
'    Private Sub FrVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Label6.Text = "Caja: " & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & " | Cajera: " & Globales.NombreEmpleado & " | Tipo Venta: "

'        datostel = False
'        estiempoaire = False
'        claveprod = ""
'        segundoticket = False
'        sipuntos = False

'        '  configuraSpread()
'        masClicks = 0
'        iren = 0
'        codigotp = ""
'        bandera = 1
'        TIEMPOCOMIS = 0
'        formaspago = False
'        PERMISOVENDER = True

'        Label11.Text = "Fecha: " & Today.Day & " de " & MonthName(Today.Month) & " del " & Today.Year & " | Hora: " & Now.ToShortTimeString & " |"
'        virtual = 0
'        'Label12.Text = "Hora: " & DateTime.Now.Hour.ToString & ":" & Mid("00" & DateTime.Now.Minute.ToString, 2, 2) & ":00"
'        kilos = False
'        autorizame = False

'        limpiaSpread()

'        Me.txt_tipoventa.Focus()
'        txt_tipoventa.SelectionStart = 0
'        txt_tipoventa.SelectionLength = txt_tipoventa.Text.Length
'    End Sub

'    Function BuscaVenta(ByVal Optional CambiandoVenta As Boolean = False)
'        Dim DSC As New DataSet
'        Dim SQL As String
'        Dim i As Integer

'        SQL = "select t.*,Cli_Nombre from tmpauxvta2 t join ecclientes on t.ClienteID=Cli_Clave where t.usuario ='" & Globales.caja & "' order by t.renglon asc"

'        Base.daQuery(SQL, xCon, DSC, "Ticket")
'        If DSC.Tables("Ticket").Rows.Count > 0 Then
'            Dim Continuar As MsgBoxResult
'            If Not CambiandoVenta Then
'                Continuar = MsgBox("Hay una cuenta pendiente, ¿desea continuar con esa venta?", vbYesNo)
'            Else
'                Continuar = MsgBoxResult.Yes
'            End If

'            If Continuar = MsgBoxResult.Yes Then
'                txt_tipoventa.Text = DSC.Tables("Ticket").Rows(0)("tipo")
'                TIPOVENTA = DSC.Tables("Ticket").Rows(0)("tipo")
'                TxtControl.Text = DSC.Tables("Ticket").Rows(0)("ClienteID")
'                LbClienteTicket.Text = "Cliente: " & DSC.Tables("Ticket").Rows(0)("Cli_Nombre").trim
'                txt_tipoventa.Enabled = False
'                For i = 0 To DSC.Tables("Ticket").Rows.Count - 1
'                    TX_UPC.Text = DSC.Tables("Ticket").Rows(i)("articulo").ToString.Trim
'                    ProcAgregaArticulo(True, DSC.Tables("Ticket").Rows(i)("Cantidad"), DSC.Tables("Ticket").Rows(i)("FueConF1"), DSC.Tables("Ticket").Rows(i)("FueConF2"), DSC.Tables("Ticket").Rows(i)("FueConF3"), DSC.Tables("Ticket").Rows(i)("TraeVale"))
'                Next
'                Me.TX_UPC.Focus()
'                Return True
'            Else
'                Return False
'            End If
'        Else
'            Return False
'        End If
'        DSC.Tables.Remove("Ticket")
'    End Function

'    Public Function guardaformadepago()
'        Dim iRen As Integer = 0
'        Dim sSql As String = ""
'        Dim dsc As New DataSet
'        Dim iID As Integer
'        Dim DATO As String
'        Dim xfecha As String
'        Dim totalcredito As Double
'        Dim signo As Integer


'        With Me.FP_FORMASPAGO.ActiveSheet
'            Try
'                DATO = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)

'                'sSql = "select max(ven_id) as maximo from ecventa  WHERE ven_USUARIO='" & DATO & "'"
'                'Base.daQuery(sSql, xCon, dsc, "maximo")
'                iID = xven

'                sSql = "Select * from ecventa where ven_id=" & iID
'                Try
'                    Base.daQuery(sSql, xCon, dsc, "venta")
'                Catch ex As Exception
'                    Return False
'                End Try

'                totalcredito = 0
'                For iRen = 0 To .RowCount - 1
'                    If .Cells(iRen, 0).Text = "Comision Vales" Or .Cells(iRen, 0).Text = "Comis Tar" Then
'                        signo = -1
'                    Else
'                        signo = 1
'                    End If

'                    sSql = "insert into ecformapago (referencia, tipo_pago, pago, banco)"
'                    sSql &= "values (" & iID & ",'" & .Cells(iRen, 0).Text & "'," & .Cells(iRen, 1).Value * signo & ",'" & .Cells(iRen, 2).Text & " ')"
'                    Try
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Return False
'                    End Try



'                    If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Credito" Then
'                        totalcredito = totalcredito + .Cells(iRen, 1).Value

'                    End If


'                    If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Tarjeta" Then
'                        xfecha = Format(dsc.Tables("venta").Rows(0)("ven_fecha"), "yyyyMMdd HH:mm.fff")
'                        sSql = "insert into ectarjetas (tar_empresa,TAR_VENTAID,CAJA,FECHA,DESCRIPCION,CANTIDAD,COMISION,REFERENCIA,FOLIOCONC,TOTALCONC,ESTATUS,corte,TipoTarjeta) values (1," & iID & ",'00" &
'                        CDbl(dsc.Tables("venta").Rows(0)("ven_usuario")) & "0','" & xfecha & "','Pago del Ticket " &
'                       iID & "'," & .Cells(iRen, 1).Value * signo & ",0,'" &
'                        .Cells(iRen, 2).Text & "',0,0,0,0,'" & TipoTarj & "')"
'                        Try
'                            Base.Ejecuta(sSql, xCon)
'                        Catch ex As Exception
'                            Return False
'                        End Try

'                    End If
'                    If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Comis Tar" Then
'                        xfecha = Format(dsc.Tables("venta").Rows(0)("ven_fecha"), "yyyyMMdd HH:mm.fff")
'                        sSql = "update ectarjetas set comision=" & .Cells(iRen, 1).Value & " where tar_ventaid=" & iID
'                        Try
'                            Base.Ejecuta(sSql, xCon)
'                        Catch ex As Exception
'                            Return False
'                        End Try

'                    End If

'                    '----------------------------------------------------
'                    '----------------- PAGO CON TRANSFERENCIA BANCARIA

'                    If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Transfer" Then
'                        xfecha = Format(dsc.Tables("venta").Rows(0)("ven_fecha"), "yyyyMMdd HH:mm.fff")
'                        sSql = "insert into ectransfer values (1," & iID & ",'00" &
'                        CDbl(dsc.Tables("venta").Rows(0)("ven_usuario")) & "0','" & xfecha & "','Pago del Ticket " &
'                       iID & "'," & .Cells(iRen, 1).Value * signo & ",0,'" &
'                        .Cells(iRen, 2).Text & "',0,0,0,0)"
'                        Try
'                            Base.Ejecuta(sSql, xCon)
'                        Catch ex As Exception
'                            Return False
'                        End Try
'                    End If


'                    '----------------------------------------------------
'                    '-----------------
'                    If .Cells(iRen, 0).Text = "Credito" Then
'                        xfecha = Format(dsc.Tables("venta").Rows(0)("ven_fecha"), "yyyyMMdd HH:mm.fff")
'                        'sSql = "Insert into eccuentasxcob values ('" & xfecha & "','" & txb_credito1.Text & "',1," & CDbl(dsc.Tables("venta").Rows(0)("ven_total")) & "," & _
'                        'CDbl(dsc.Tables("venta").Rows(0)("ven_total")) & ",0,1," & CDbl(dsc.Tables("venta").Rows(0)("ven_id")) & ")"
'                        sSql = "Insert into eccuentasxcob values ('" & xfecha & "','" & txb_credito1.Text & "',1," & (totalcredito) & "," &
'                        totalcredito & ",0,1," & CDbl(dsc.Tables("venta").Rows(0)("ven_id")) & ")"
'                        Try
'                            Base.Ejecuta(sSql, xCon)
'                        Catch ex As Exception
'                            Return False
'                        End Try
'                        Try
'                            sSql = "update ecdetclienteemp set dcli_saldo=dcli_Saldo +round(" & .Cells(iRen, 1).Value & ",2) where dcli_clave=" & txb_credito1.Text & " and dcli_empresa=1"
'                            Base.Ejecuta(sSql, xCon)
'                        Catch ex As Exception
'                            Return False
'                        End Try
'                    End If
'                Next iRen
'                dsc.Tables.Remove("venta")
'                '   dsc.Tables.Remove("maximo")
'            Catch exSql As SqlException
'                MessageBox.Show(exSql.Message)
'            End Try
'        End With
'        Return True
'    End Function

'    Public Function GuardaFormaDePagoConHandler()
'        Dim iRen As Integer = 0
'        Dim sSql As String = ""
'        Dim dsc As New DataSet
'        Dim iID As Integer
'        Dim DATO As String
'        Dim xfecha As String
'        Dim xusuario As Double
'        Dim totalcredito As Double
'        Dim signo As Integer


'        With Me.FP_FORMASPAGO.ActiveSheet
'            DATO = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)

'            'sSql = "select max(ven_id) as maximo from ecventa  WHERE ven_USUARIO='" & DATO & "'"
'            'Base.daQuery(sSql, xCon, dsc, "maximo")
'            iID = xven

'            sSql = "Select * from ecventa where ven_id=" & iID
'            Try
'                Base.daQuery(sSql, xCon, dsc, "venta")
'                If dsc.Tables("venta").Rows.Count > 0 Then
'                    xfecha = Format(dsc.Tables("venta").Rows(0)("ven_fecha"), "yyyyMMdd HH:mm.fff")
'                    xusuario = CDbl(dsc.Tables("venta").Rows(0)("ven_usuario"))
'                Else
'                    Return False
'                End If
'                dsc.Tables.Remove("venta")
'            Catch ex As Exception
'                Return False
'            End Try

'            totalcredito = 0
'            For iRen = 0 To .RowCount - 1
'                If .Cells(iRen, 0).Text = "Comision Vales" Or .Cells(iRen, 0).Text = "Comis Tar" Then
'                    signo = -1
'                Else
'                    signo = 1
'                End If

'                sSql = "insert into ecformapago (referencia, tipo_pago, pago, banco)"
'                sSql &= "values (" & iID & ",'" & .Cells(iRen, 0).Text & "'," & .Cells(iRen, 1).Value * signo & ",'" & Strings.Left(.Cells(iRen, 2).Text, 50) & " ')"
'                Try
'                    Base.Ejecuta(sSql, xCon)
'                Catch ex As Exception
'                    Return False
'                End Try



'                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Credito" Then
'                    totalcredito = totalcredito + .Cells(iRen, 1).Value

'                End If


'                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Tarjeta" Then
'                    sSql = "insert into ectarjetas (tar_empresa,TAR_VENTAID,CAJA,FECHA,DESCRIPCION,CANTIDAD,COMISION,REFERENCIA,FOLIOCONC,TOTALCONC,ESTATUS,corte,TipoTarjeta) values (1," & iID & ",'00" &
'                    xusuario & "0','" & xfecha & "','Pago del Ticket " &
'                   iID & "'," & .Cells(iRen, 1).Value * signo & ",0,'" &
'                    .Cells(iRen, 2).Text & "',0,0,0,0,'" & TipoTarj & "')"
'                    Try
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Return False
'                    End Try

'                End If
'                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Comis Tar" Then
'                    sSql = "update ectarjetas set comision=" & .Cells(iRen, 1).Value & " where tar_ventaid=" & iID
'                    Try
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Return False
'                    End Try

'                End If

'                '----------------------------------------------------
'                '----------------- PAGO CON TRANSFERENCIA BANCARIA

'                If LTrim(RTrim(.Cells(iRen, 0).Text)) = "Transfer" Then
'                    sSql = "insert into ectransfer values (1," & iID & ",'00" &
'                    xusuario & "0','" & xfecha & "','Pago del Ticket " &
'                   iID & "'," & .Cells(iRen, 1).Value * signo & ",0,'" &
'                    .Cells(iRen, 2).Text & "',0,0,0,0)"
'                    Try
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Return False
'                    End Try
'                End If


'                '----------------------------------------------------
'                '-----------------
'                If .Cells(iRen, 0).Text = "Credito" Then
'                    'sSql = "Insert into eccuentasxcob values ('" & xfecha & "','" & txb_credito1.Text & "',1," & CDbl(dsc.Tables("venta").Rows(0)("ven_total")) & "," & _
'                    'CDbl(dsc.Tables("venta").Rows(0)("ven_total")) & ",0,1," & CDbl(dsc.Tables("venta").Rows(0)("ven_id")) & ")"
'                    sSql = "Insert into eccuentasxcob values ('" & xfecha & "','" & txb_credito1.Text & "',1," & (totalcredito) & "," &
'                    totalcredito & ",0,1," & iID & ")"
'                    Try
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Return False
'                    End Try
'                    Try
'                        sSql = "update ecventa.dbo.ECDETCLIENTEEMP set DCLI_SALDO=Saldo from ecventa.dbo.eccuentasxcob e join (" &
'                                "Select e.DCLI_CLAVE,COALESCE(SUM(cxc_saldo) ,0) Saldo  from ecventa.dbo.ECDETCLIENTEEMP e join ecventa.dbo.eccuentasxcob x on DCLI_CLAVE=cxc_cliente " &
'                                "group by e.DCLI_CLAVE) a on a.DCLI_CLAVE=e.cxc_cliente where ecventa.dbo.ECDETCLIENTEEMP.DCLI_CLAVE=e.cxc_cliente"
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Return False
'                    End Try
'                End If
'            Next iRen
'            'dsc.Tables.Remove("venta")
'            '   dsc.Tables.Remove("maximo")
'        End With
'        Return True
'    End Function

'    Public Sub agregaArticulo(ByVal UPCUPC As String, ByVal ArtClave As String, ByVal UPCDescripcion As String, ByVal ArtNomLargo As String, ByVal Familia As String, ByVal CostoCap As Double, ByVal Precio1 As Double, ByVal Precio2 As Double, ByVal Precio3 As Double, ByVal iRen As Integer, ByVal tOPE As Double, ByVal tipo As Integer, ByVal cant As Double, ByRef iva As Double, ByRef ieps As Double, ByVal CargandoPendiente As Boolean, ByVal TraeVale As Boolean, ByVal FueConF1 As Boolean, ByVal cancelacion As Boolean, ByVal FueConF3 As Boolean, ByVal CantidadDisponible As Integer, ByVal PrecioOferta1 As Double, ByVal PrecioOferta2 As Double, ByVal PrecioOferta3 As Double, ByVal CantidadCobradas As Integer, ByVal TipoOferta As Integer)
'        Dim SQL As String
'        Dim DSC As New DataSet

'        Dim cantacuma As Double
'        cantacuma = 0

'        With fp_articulos.ActiveSheet

'            If tipo = 2 OrElse CargandoPendiente OrElse cancelacion Then
'                sCant = cant
'            End If

'            If (sCant = "" OrElse sCant = "0") AndAlso Not CargandoPendiente AndAlso Not cancelacion Then
'                sCant = "1"
'                cant = 1
'            End If


'            If .RowCount > 1 Then
'                If tipo = 1 Then

'                    If claveArt = UPCUPC AndAlso Not cancelacion AndAlso .Cells(iRen - 1, ColVenta.ColCantidad).Value > 0 And Not kilos And Not CargandoPendiente Then
'                        iRen -= 1
'                        cantacuma = .Cells(iRen, ColVenta.ColCantidad).Value
'                        If Not kilos Then
'                            sCant = .Cells(iRen, ColVenta.ColCantidad).Value + 1
'                        Else
'                            sCant = .Cells(iRen, ColVenta.ColCantidad).Value
'                        End If

'                        If Not CargandoPendiente Then
'                            SQL = "update tmpauxvta2 set cantidad=" & sCant & ", FueConF1=" & IIf(FueConF1, 1, 0) & ", FueConF2=" & IIf(cancelacion, 1, 0) & ", FueConF3=0 where renglon=" & iRen & " and usuario='" & Globales.caja & "'"
'                            Base.Ejecuta(SQL, xCon)
'                            SQL = " exec cargaauditoria '" & Globales.caja & "','" & UPCUPC & "'," & sCant
'                            'Base.Ejecuta(SQL, xCon)
'                        End If


'                        If Me.kilos Then
'                            .Cells(iRen, ColVenta.ColCantidad).Value = "0"
'                            .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                            .Cells(iRen, ColVenta.ColTotal).Value = "0"
'                            .RemoveRows(iRen + 1, 1)
'                        Else
'                            .Cells(iRen, ColVenta.ColCantidad).Value = CInt(sCant)
'                            .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                            .Cells(iRen, ColVenta.ColTotal).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1) * CInt(sCant)
'                            .RemoveRows(iRen + 1, 1)
'                        End If

'                        .Cells(iRen, ColVenta.ColFIVA).Value = iva
'                        .Cells(iRen, ColVenta.ColFIEPS).Value = ieps
'                        .Cells(iRen, ColVenta.ColArtClave).Value = ArtClave
'                        .Cells(iRen, ColVenta.ColNomLargo).Value = ArtNomLargo

'                        .Cells(iRen, ColVenta.ColFamilia).Value = Familia
'                        .Cells(iRen, ColVenta.ColCostoCap).Value = CostoCap
'                        .Cells(iRen, ColVenta.ColTipoOferta).Value = TipoOferta
'                        .Cells(iRen, ColVenta.ColPrecio1).Value = Precio1

'                        .Cells(iRen, ColVenta.ColF1).Value = IIf(FueConF1, 1, 0)
'                        .Cells(iRen, ColVenta.ColF2).Value = IIf(cancelacion, 1, 0)
'                        .Cells(iRen, ColVenta.ColF3).Value = IIf(FueConF3, 1, 0)
'                        .Cells(iRen, ColVenta.ColVale).Value = IIf(TraeVale, "*", "")

'                    Else
'                        If Not CargandoPendiente Then
'                            SQL = "insert into tmpauxvta2 (renglon,usuario,articulo,cantidad,tipo,FueConF1,FueConF2,FueConF3,ClienteID,ArtClave,TraeVale) values(" &
'                                                iRen & ",'" & Globales.caja & "','" & UPCUPC & "'," & IIf(kilos, 0, sCant) & "," & txt_tipoventa.Text & "," & IIf(FueConF1, 1, 0) & ", " & IIf(cancelacion, 1, 0) & ",0," & CDbl(TxtControl.Text) & ",'" & ArtClave & "','')"
'                            Base.Ejecuta(SQL, xCon)
'                            SQL = " exec cargaauditoria '" & Globales.caja & "','" & UPCUPC & "',1 "
'                            'Base.Ejecuta(SQL, xCon)
'                        End If

'                        claveArt = UPCUPC
'                        If Me.kilos Then
'                            .Cells(iRen, ColVenta.ColCantidad).Value = "0"
'                            .Cells(iRen, ColVenta.ColPrecio).Value = "0"
'                            .Cells(iRen, ColVenta.ColTotal).Value = "0"
'                        Else
'                            If tipo = 1 Then
'                                .Cells(iRen, ColVenta.ColCantidad).Value = CDbl(sCant)
'                            Else
'                                .Cells(iRen, ColVenta.ColCantidad).Value = CDbl(sCant)

'                            End If
'                            .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                            .Cells(iRen, ColVenta.ColTotal).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1) * CDbl(sCant)
'                        End If

'                        .Cells(iRen, ColVenta.ColDescripcion).Value = UPCDescripcion
'                        .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                        .Cells(iRen, ColVenta.ColUPCInv).Value = UPCUPC
'                        .Cells(iRen, ColVenta.ColFIVA).Value = iva
'                        .Cells(iRen, ColVenta.ColFIEPS).Value = ieps
'                        .Cells(iRen, ColVenta.ColArtClave).Value = ArtClave
'                        .Cells(iRen, ColVenta.ColNomLargo).Value = ArtNomLargo

'                        .Cells(iRen, ColVenta.ColFamilia).Value = Familia
'                        .Cells(iRen, ColVenta.ColCostoCap).Value = CostoCap
'                        .Cells(iRen, ColVenta.ColTipoOferta).Value = TipoOferta
'                        .Cells(iRen, ColVenta.ColPrecio1).Value = Precio1

'                        .Cells(iRen, ColVenta.ColF1).Value = IIf(FueConF1, 1, 0)
'                        .Cells(iRen, ColVenta.ColF2).Value = IIf(cancelacion, 1, 0)
'                        .Cells(iRen, ColVenta.ColF3).Value = IIf(FueConF3, 1, 0)
'                        .Cells(iRen, ColVenta.ColVale).Value = IIf(TraeVale, "*", "")

'                        .ActiveRowIndex = iRen
'                    End If
'                Else
'                    If Not CargandoPendiente Then
'                        SQL = "insert into tmpauxvta2 (renglon,usuario,articulo,cantidad,tipo,FueConF1,FueConF2,FueConF3,ClienteID,ArtClave,TraeVale) values(" &
'                                            iRen & ",'" & Globales.caja & "','" & UPCUPC & "'," & sCant & "," & txt_tipoventa.Text & "," & IIf(FueConF1, 1, 0) & ", " & IIf(cancelacion, 1, 0) & ",0," & CDbl(TxtControl.Text) & ",'" & ArtClave & "','')"
'                        Base.Ejecuta(SQL, xCon)
'                        SQL = " exec cargaauditoria '" & Globales.caja & "','" & UPCUPC & "',1 "
'                        'Base.Ejecuta(SQL, xCon)
'                    End If

'                    claveArt = UPCUPC
'                    If Me.kilos Then
'                        .Cells(iRen, ColVenta.ColCantidad).Value = "0"
'                        .Cells(iRen, ColVenta.ColPrecio).Value = "0"
'                        .Cells(iRen, ColVenta.ColTotal).Value = "0"
'                    Else
'                        If tipo = 1 Then
'                            .Cells(iRen, ColVenta.ColCantidad).Value = CInt(sCant)
'                        Else
'                            .Cells(iRen, ColVenta.ColCantidad).Value = CDbl(sCant)
'                        End If
'                        .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                        .Cells(iRen, ColVenta.ColTotal).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1) * CDbl(sCant)
'                    End If

'                    .Cells(iRen, ColVenta.ColDescripcion).Value = UPCDescripcion
'                    .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                    .Cells(iRen, ColVenta.ColUPCInv).Value = UPCUPC
'                    .Cells(iRen, ColVenta.ColFIVA).Value = iva
'                    .Cells(iRen, ColVenta.ColFIEPS).Value = ieps
'                    .Cells(iRen, ColVenta.ColArtClave).Value = ArtClave
'                    .Cells(iRen, ColVenta.ColNomLargo).Value = ArtNomLargo

'                    .Cells(iRen, ColVenta.ColFamilia).Value = Familia
'                    .Cells(iRen, ColVenta.ColCostoCap).Value = CostoCap
'                    .Cells(iRen, ColVenta.ColTipoOferta).Value = TipoOferta
'                    .Cells(iRen, ColVenta.ColPrecio1).Value = Precio1

'                    .Cells(iRen, ColVenta.ColF1).Value = IIf(FueConF1, 1, 0)
'                    .Cells(iRen, ColVenta.ColF2).Value = IIf(cancelacion, 1, 0)
'                    .Cells(iRen, ColVenta.ColF3).Value = IIf(FueConF3, 1, 0)
'                    .Cells(iRen, ColVenta.ColVale).Value = IIf(TraeVale, "*", "")
'                    .ActiveRowIndex = iRen
'                End If


'            Else

'                ' ------------------ PARA PODER REGISTRAR TIEMPO AIRE TIENE QUE SER SOLO EL ARTICULO DEL TIEMPO AIRE
'                If Not CargandoPendiente Then
'                    SQL = "insert into tmpauxvta2 (renglon,usuario,articulo,cantidad,tipo,FueConF1,FueConF2,FueConF3,ClienteID,ArtClave,TraeVale) values(" &
'                               iRen & ",'" & Globales.caja & "','" & UPCUPC & "'," & 1 & "," & txt_tipoventa.Text & "," & IIf(FueConF1, 1, 0) & ", " & IIf(cancelacion, 1, 0) & ",0," & CDbl(TxtControl.Text) & ",'" & ArtClave & "','')"
'                    Base.Ejecuta(SQL, xCon)
'                    SQL = " exec cargaauditoria '" & Globales.caja & "','" & UPCUPC & "',1 "
'                    'Base.Ejecuta(SQL, xCon)
'                End If

'                SQL = "SELECT * FROM TIEMPOAIREART WHERE ARTICULO='" & UPCUPC & "'"
'                Base.daQuery(SQL, xCon, DSC, "TABLAAIRE")

'                If DSC.Tables("TABLAAIRE").Rows.Count > 0 Then
'                    estiempoaire = True
'                    TIEMPOCOMIS = IIf(DSC.Tables("TABLAAIRE").Rows(0)("COMISION") = 1, True, False)
'                    claveprod = DSC.Tables("TABLAAIRE").Rows(0)("PRODUCTO")
'                Else
'                    claveprod = ""
'                End If


'                claveArt = UPCUPC
'                If kilos Then
'                    .Cells(iRen, ColVenta.ColCantidad).Value = "0"
'                    .Cells(iRen, ColVenta.ColDescripcion).Value = UPCDescripcion
'                    .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                    .Cells(iRen, ColVenta.ColTotal).Value = "0"
'                    .Cells(iRen, ColVenta.ColUPCInv).Value = UPCUPC
'                    .Cells(iRen, ColVenta.ColFIVA).Value = iva
'                    .Cells(iRen, ColVenta.ColFIEPS).Value = ieps
'                    .Cells(iRen, ColVenta.ColArtClave).Value = ArtClave
'                    .Cells(iRen, ColVenta.ColNomLargo).Value = ArtNomLargo

'                    .Cells(iRen, ColVenta.ColFamilia).Value = Familia
'                    .Cells(iRen, ColVenta.ColCostoCap).Value = CostoCap
'                    .Cells(iRen, ColVenta.ColTipoOferta).Value = TipoOferta
'                    .Cells(iRen, ColVenta.ColPrecio1).Value = Precio1

'                    .ActiveRowIndex = iRen

'                Else

'                    .Cells(iRen, ColVenta.ColCantidad).Value = CDbl(sCant)
'                    .Cells(iRen, ColVenta.ColDescripcion).Value = UPCDescripcion
'                    .Cells(iRen, ColVenta.ColPrecio).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1)
'                    .Cells(iRen, ColVenta.ColTotal).Value = IIf(TipoOferta = 0, Precio1, PrecioOferta1) * CDbl(sCant)
'                    .Cells(iRen, ColVenta.ColUPCInv).Value = UPCUPC
'                    .Cells(iRen, ColVenta.ColFIVA).Value = iva
'                    .Cells(iRen, ColVenta.ColFIEPS).Value = ieps
'                    .Cells(iRen, ColVenta.ColArtClave).Value = ArtClave
'                    .Cells(iRen, ColVenta.ColNomLargo).Value = ArtNomLargo

'                    .Cells(iRen, ColVenta.ColFamilia).Value = Familia
'                    .Cells(iRen, ColVenta.ColCostoCap).Value = CostoCap
'                    .Cells(iRen, ColVenta.ColTipoOferta).Value = TipoOferta
'                    .Cells(iRen, ColVenta.ColPrecio1).Value = Precio1

'                    .ActiveRowIndex = iRen


'                End If

'                .Cells(iRen, ColVenta.ColF1).Value = IIf(FueConF1, 1, 0)
'                .Cells(iRen, ColVenta.ColF2).Value = IIf(cancelacion, 1, 0)
'                .Cells(iRen, ColVenta.ColF3).Value = IIf(FueConF3, 1, 0)
'                .Cells(iRen, ColVenta.ColVale).Value = IIf(TraeVale, "*", "")

'                If virtual = 1 And Not estiempoaire Then
'                    .Cells(iRen, ColVenta.ColVale).Value = "*"
'                    virtual = 0

'                End If
'            End If
'        End With

'        'PARA CAMBIAR A PRECIOS DE MEDIO MAYOREO CUANDO EL VOLUMEN SEA EL INDICADO
'        CONTROLPRECIOS(UPCUPC, Precio1, Precio2, Precio3, tOPE, IIf(kilos, IIf(CargandoPendiente, sCant, 0), sCant), cantacuma, iRen, ArtClave, CargandoPendiente, CantidadDisponible:=CantidadDisponible, PrecioOferta1:=PrecioOferta1, PrecioOferta2:=PrecioOferta2, PrecioOferta3:=PrecioOferta3, CantidadCobradas:=CantidadCobradas + cant, TipoOferta:=TipoOferta)

'        sCant = ""

'        sumaSpread()

'        If estiempoaire Then
'            Paneltiempo.Visible = True
'            Paneltiempo.BringToFront()
'            txt_tel1.Focus()
'        End If

'    End Sub

'    Private Sub CONTROLPRECIOS(ByVal UPCUPC As String, ByVal DPRECIO1 As Double, ByVal DPRECIO2 As Double, ByVal DPRECIO3 As Double, ByVal TOPE As Double, ByVal SCANT As Double, ByVal SCANTANT As Double, ByVal RENGLON As Integer, ByVal ArtClave As String, ByVal Optional CargandoPendiente As Boolean = False, Optional ByVal CantidadDisponible As Integer = -1, Optional ByVal PrecioOferta1 As Double = -1, Optional ByVal PrecioOferta2 As Double = -1, Optional ByVal PrecioOferta3 As Double = -1, Optional ByVal CantidadCobradas As Double = 0, Optional ByVal TipoOferta As Integer = 0)
'        Dim CantidadEnTicket As Double
'        Dim SQL As String
'        Dim dsc1 As New DataSet

'        Dim YaEstoyTipo2 As Boolean = False
'        Using DSC As New DataSet
'            SQL = "SELECT * FROM " & Globales.caja & "  WHERE ARTICULO='" & ArtClave & "'"
'            Try
'                Base.daQuery(SQL, xCon, DSC, "ART")
'            Catch ex As Exception
'                MsgBox("No pudieron recalcularse los precios.", vbCritical, "Punto de Venta")
'            End Try
'            If DSC.Tables("Art").Rows.Count > 0 Then
'                'If TIPOVENTA > 1 OrElse (TIPOVENTA = 1 AndAlso CDbl(DSC.Tables("ART").Rows(0)("CANTIDAD")) >= TOPE) Then 'Busco si lo registrado excede el tope, si lo excede 
'                '    YaEstoyTipo2 = True
'                'Else
'                '    YaEstoyTipo2 = False
'                'End If

'                Dim CantTickTemp As Double
'                Select Case TipoOferta
'                    Case 1, 2
'                        'UPC (1), Clave (2)
'                        If CantidadDisponible > 0 Then
'                            SQL = "select sum(cantidad) Cantidad from tmpauxvta2 where " & IIf(TipoOferta = 1, "articulo='" & UPCUPC, "ArtClave='" & ArtClave) & "'"
'                            Try
'                                Base.daQuery(SQL, xCon, DSC, "CantTick")
'                                If DSC.Tables("CantTick").Rows.Count > 0 Then
'                                    CantTickTemp = DSC.Tables("CantTick").Rows(0)("Cantidad") + SCANT - SCANTANT
'                                Else
'                                    CantTickTemp = 0 + SCANT - SCANTANT
'                                End If
'                                DSC.Tables.Remove("CantTick")
'                            Catch ex As Exception
'                                MsgBox("No pudieron recalcularse los precios.", vbCritical, "Punto de Venta")
'                            End Try
'                        Else
'                            SQL = "select sum(cantidad) Cantidad from tmpauxvta2 where " & IIf(TipoOferta = 1, "articulo='" & UPCUPC, "ArtClave='" & ArtClave) & "' AND USUARIO='" & Globales.caja & "'"
'                            Try
'                                Base.daQuery(SQL, xCon, DSC, "CantTick")
'                                If DSC.Tables("CantTick").Rows.Count > 0 Then
'                                    CantTickTemp = DSC.Tables("CantTick").Rows(0)("Cantidad")
'                                Else
'                                    CantTickTemp = 0 + SCANT - SCANTANT
'                                End If
'                                DSC.Tables.Remove("CantTick")
'                            Catch ex As Exception
'                                MsgBox("No pudieron recalcularse los precios.", vbCritical, "Punto de Venta")
'                            End Try


'                            'CantTickTemp = DSC.Tables("ART").Rows(0)("CANTIDAD") + SCANT - SCANTANT
'                        End If
'                    Case 3
'                        'Familia
'                        CantTickTemp = DSC.Tables("ART").Rows(0)("CANTIDAD") + IIf(CargandoPendiente, 0, SCANT - SCANTANT)
'                    Case 4
'                        'Marca
'                        CantTickTemp = DSC.Tables("ART").Rows(0)("CANTIDAD") + IIf(CargandoPendiente, 0, SCANT - SCANTANT)
'                    Case Else
'                        Dim CounterTemp As Double = 0
'                        For i As Integer = 0 To fp_articulos.ActiveSheet.Rows.Count - 1
'                            If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTipoOferta).Value = 0 AndAlso fp_articulos.ActiveSheet.Cells(i, ColVenta.ColArtClave).Value = ArtClave Then
'                                CounterTemp += fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
'                            End If
'                        Next
'                        If CounterTemp = 0 Then
'                            CounterTemp = SCANT + SCANTANT
'                        End If
'                        CantTickTemp = CounterTemp
'                End Select

'                CantidadEnTicket = CantTickTemp 'IIf(CargandoPendiente, DSC.Tables("ART").Rows(0)("CANTIDAD"), CantTickTemp)

'                If Not CargandoPendiente Then
'                    SQL = "UPDATE " & Globales.caja & " SET CANTIDAD=CANTIDAD+" & SCANT - SCANTANT & " WHERE ARTICULO='" & ArtClave & "'"
'                    Dim Res As MsgBoxResult = MsgBoxResult.Yes
'                    Do While Res = MsgBoxResult.Yes
'                        Try
'                            Base.Ejecuta(SQL, xCon)
'                            Exit Do
'                        Catch ex As Exception
'                            Res = MsgBox("Error al actualizar Tabla " & Globales.caja & Chr(13) & Chr(13) & "¿Desea intentar nuevamente?", MsgBoxStyle.YesNo, "Punto de Venta")
'                            If Res = MsgBoxResult.No Then Stop
'                            'Registrar step en base de datos
'                        End Try
'                    Loop
'                End If
'            Else
'                CantidadEnTicket = CDbl(SCANT)
'                If Not CargandoPendiente Then
'                    SQL = "insert into " & Globales.caja & " (articulo,cantidad) values ('" & ArtClave & "'," & SCANT - SCANTANT & ")"
'                    Base.Ejecuta(SQL, xCon)
'                End If
'            End If
'        End Using

'        'If TIPOVENTA = 1 OrElse TipoOferta > 0 Then
'        Dim Precio1APeinar, Precio2APeinar As Double
'        If (CantidadDisponible > 0 AndAlso CantidadCobradas <> -1 AndAlso CantidadCobradas <= CantidadDisponible) OrElse (CantidadDisponible = -1) AndAlso TipoOferta > 0 Then 'Cuando hay oferta por cantidad y aun queda
'            'If CantidadCobradas <= CantidadDisponible Then
'            Dim Prec As Double
'            Select Case TIPOVENTA
'                Case 1
'                    'Validar cuantos van cobrados por clave, y cuantos por upc, y como existe oferta, definir cuáles para cuál
'                    'Si lo cobrado por upc excede el tope, o si el articulo excede el tope

'                    'Buscar en TmpAuxVta2 con el usuario (caja) en cuestión, y validar

'                    If CantidadEnTicket >= TOPE Then 'Si la cantidad cobrada en ticket por clave
'                        Prec = PrecioOferta2
'                        Precio2APeinar = Prec
'                        Precio1APeinar = -1
'                    Else
'                        Prec = PrecioOferta1
'                        Precio2APeinar = -1
'                        Precio1APeinar = Prec
'                    End If
'                Case 2
'                    Prec = PrecioOferta2
'                    Precio2APeinar = Prec
'                    Precio1APeinar = -1
'                Case 3
'                    Prec = PrecioOferta3
'                    Precio2APeinar = -1
'                    Precio1APeinar = Prec
'            End Select
'            fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = Prec
'        Else 'Si no hubo oferta o ya no se alcanzó la cantidad
'            If (TIPOVENTA = 1 AndAlso CantidadEnTicket >= TOPE) OrElse TIPOVENTA = 2 Then
'                fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = DPRECIO2
'                Precio2APeinar = DPRECIO2
'                Precio1APeinar = -1
'            ElseIf (TIPOVENTA = 1 AndAlso CantidadEnTicket < TOPE) Then
'                fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = DPRECIO1
'                Precio2APeinar = -1
'                Precio1APeinar = DPRECIO1
'            ElseIf TIPOVENTA = 3 Then
'                fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value = DPRECIO3
'                Precio2APeinar = DPRECIO3
'                Precio1APeinar = -1
'            End If
'        End If
'        fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColTotal).Value = fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColPrecio).Value * fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColCantidad).Value
'        RECALCULA(IIf(TipoOferta <> 1, ArtClave, UPCUPC), IIf(Precio1APeinar <> -1, Precio1APeinar, Precio2APeinar), TipoOferta)

'        'If (tx_cantidad.Visible AndAlso tx_cantidad.Text <> "") OrElse (CantidadEnTicket >= TOPE AndAlso Not YaEstoyTipo2) OrElse (CantidadEnTicket < TOPE AndAlso YaEstoyTipo2) Then 'Si excedo el tope con lo actualmente cobrado o con lo que estoy cobrando ya me regresé a menos del tope
'        '    If YaEstoyTipo2 Then
'        '        RECALCULA(IIf(TipoOferta <> 1, ArtClave, UPCUPC), IIf(Precio1APeinar <> -1, Precio1APeinar, Precio2APeinar), TipoOferta)
'        '        'RECALCULA(ArtClave, Precio1APeinar)
'        '    Else
'        '        'RECALCULA(ArtClave, Precio2APeinar)
'        '        RECALCULA(IIf(TipoOferta <> 1, ArtClave, UPCUPC), IIf(Precio1APeinar <> -1, Precio1APeinar, Precio2APeinar), TipoOferta)
'        '    End If
'        'End If
'        'End If
'    End Sub

'    Private Sub RECALCULA(ByVal ArtCLave As String, ByVal PRECIO As Double, ByVal TipoOferta As Integer)
'        Dim I As Integer
'        Dim sql As String
'        Dim dsc1 As New DataSet
'        Dim ArtClaveSpread As String

'        For I = 0 To fp_articulos.ActiveSheet.RowCount - 1
'            If TipoOferta = 1 AndAlso fp_articulos.ActiveSheet.Cells(I, ColVenta.ColTipoOferta).Text.Trim = 1 Then
'                If fp_articulos.ActiveSheet.Cells(I, ColVenta.ColUPCInv).Text.Trim = ArtCLave Then
'                    fp_articulos.ActiveSheet.Cells(I, ColVenta.ColPrecio).Value = PRECIO
'                    fp_articulos.ActiveSheet.Cells(I, ColVenta.ColTotal).Value = fp_articulos.ActiveSheet.Cells(I, ColVenta.ColCantidad).Value * PRECIO
'                End If
'            Else
'                If fp_articulos.ActiveSheet.Cells(I, ColVenta.ColTipoOferta).Text.Trim <> 1 Then
'                    sql = "select * from xupc where upc_upc='" & fp_articulos.ActiveSheet.Cells(I, ColVenta.ColUPCInv).Text.Trim & "'"
'                    Base.daQuery(sql, xCon, dsc1, "art")
'                    If dsc1.Tables("art").Rows.Count > 0 Then
'                        ArtClaveSpread = dsc1.Tables("art").Rows(0)("upc_cveart")
'                    Else
'                        ArtClaveSpread = ""
'                    End If
'                    dsc1.Tables.Remove("art")

'                    If ArtClaveSpread = ArtCLave Then
'                        fp_articulos.ActiveSheet.Cells(I, ColVenta.ColPrecio).Value = PRECIO
'                        fp_articulos.ActiveSheet.Cells(I, ColVenta.ColTotal).Value = fp_articulos.ActiveSheet.Cells(I, ColVenta.ColCantidad).Value * PRECIO
'                    End If
'                End If

'            End If


'        Next


'    End Sub
'    Private Sub pb_sube_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        sCant = ""
'        With fp_articulos.ActiveSheet
'            If .ActiveRowIndex >= 1 Then
'                .ActiveRowIndex -= 1
'            End If
'        End With
'    End Sub

'    Private Sub pb_borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        sCant = ""
'        With fp_articulos.ActiveSheet
'            If .ActiveRowIndex >= 0 AndAlso .RowCount > 0 Then
'                Dim VENT As New VENTANITA("¿QUITAR EL ARTÍCULO?", "BORRAR")
'                VENT.BringToFront()
'                VENT.ShowDialog()
'                If VENT.DialogResult = System.Windows.Forms.DialogResult.Yes Then
'                    .RemoveRows(.ActiveRowIndex, 1)
'                End If
'            End If
'        End With
'        sumaSpread()
'    End Sub

'    Private Sub pb_baja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        sCant = ""
'        With fp_articulos.ActiveSheet
'            If .RowCount >= 1 Then
'                If .ActiveRowIndex < .RowCount - 1 Then
'                    .ActiveRowIndex += 1
'                End If
'            End If
'        End With
'    End Sub
'    Public Sub cambiaCant(ByVal iCant As Integer)
'        sCant = CStr(iCant)
'    End Sub

'    Private Sub pb_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        sCant = ""
'        With fp_articulos.ActiveSheet
'            If .ActiveRowIndex >= 0 AndAlso .RowCount > 0 Then
'                Dim oForma As New FrPopup
'                sCant = .Cells(.ActiveRowIndex, ColVenta.ColCantidad).Text
'                oForma.BringToFront()
'                oForma.ShowDialog(Me)
'                .Cells(.ActiveRowIndex, ColVenta.ColCantidad).Text = sCant
'                .Cells(.ActiveRowIndex, ColVenta.ColTotal).Value = CInt(sCant) * .Cells(.ActiveRowIndex, ColVenta.ColPrecio).Value
'            End If
'        End With
'        sCant = ""
'        sumaSpread()
'    End Sub

'    Private Sub sumaSpread()
'        Dim dTotal As Double = 0
'        Dim dTotalDifP1 As Double = 0
'        Dim iRen As Integer = 0
'        With fp_articulos.ActiveSheet
'            For iRen = 0 To .RowCount - 1
'                'dTotal += Round(CDbl(.Cells(iRen, 3).Value), 2)
'                dTotal += CDbl(.Cells(iRen, ColVenta.ColTotal).Value)
'                dTotalDifP1 += (CDbl(.Cells(iRen, ColVenta.ColPrecio1).Value) - CDbl(.Cells(iRen, ColVenta.ColPrecio).Value)) * CDbl(.Cells(iRen, ColVenta.ColCantidad).Value)
'                'dTotal += .Cells(iRen, 3).Value
'            Next
'        End With
'        ntx_totalventa.Text = dTotal
'        LbTotal.Text = FormatCurrency(dTotal, 2) 'Format((dTotal), "$#,###,##0.00")
'        totalote = Math.Round(dTotal, 2)
'        MontoMaximoComision = Math.Round(dTotalDifP1, 2)

'        Label11.Text = "Fecha: " & Today.Day & " de " & MonthName(Today.Month) & " del " & Today.Year & " | Hora: " & Now.ToShortTimeString & " |"
'        'Label12.Text = "Hora: " & DateTime.Now.Hour.ToString & ":" & Mid("00" & DateTime.Now.Minute.ToString, 2, 2) & ":00"
'        '   fp_articulos.ActiveSheet.ActiveRowIndex = fp_articulos.ActiveSheet.RowCount - 1
'        '  fp_articulos.Refresh(fp_articulos.ActiveSheet.ActiveRowIndex,1,0,0)
'        fp_articulos.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Bottom, FarPoint.Win.Spread.HorizontalPosition.Left)


'    End Sub
'    Public Sub aplicainv()
'        ' Base.Ejecuta("EXEC APLVENTAPEPSNUEVO " & numt, xCon)
'    End Sub

'    Public Sub GuardaTicketCliente(ByRef ClienteID As Integer, ByRef Ticket As Double)
'        Dim sql As String
'        Try
'            Base.Ejecuta("insert into TicketsClientes (ClienteID,FolioTicket) Values (" & ClienteID & "," & Ticket & ")", xCon)
'        Catch ex As Exception
'            MsgBox("No se registró el ticket en tabla de TicketsClientes.", MsgBoxStyle.Critical, "Punto de Venta")
'        End Try
'    End Sub

'    Public Function guardaTicket(FolioCaja As String)
'        Dim iRen As Integer = 0
'        Dim sSql As String = ""
'        Dim xsql As String = ""
'        Dim dsc As New DataSet
'        Dim dsc1 As New DataSet
'        Dim iID As Integer
'        Dim iva, IEPS As Double
'        Dim familia As String
'        Dim costo As Double
'        Dim precio As Double
'        Dim cant As Double
'        Dim DATO As String
'        Dim sql As String
'        Dim dsc2 As New DataSet
'        Dim dsc3 As New DataSet
'        Dim dsc4 As New DataSet
'        'Dim cap1 As Double
'        'Dim cap2 As Double
'        'Dim uni1 As String
'        'Dim uni2 As String
'        Dim xrenglon As Integer


'        'xven = 0
'        'sql = "select isnull(folio,0)+1 maximo from eccontrolventa"
'        'Base.daQuery(sql, xCon, dsc, "tabla")
'        'xven = dsc.Tables("tabla").Rows(0)("maximo")
'        'Base.Ejecuta("update eccontrolventa set folio=folio+1", xCon)


'        DATO = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)

'        'Para generar el consolidado del ticket
'        Try
'            Base.Ejecuta("DELETE FROM TMPAUXVTA WHERE TMP_USUARIO='" & Globales.caja & "'", xCon)
'        Catch ex As Exception
'            'Aqui no pasa nada, solo abortar toda la mision.
'            MsgBox("Error al borrar los datos de tabla TmpAuxVta", MsgBoxStyle.Critical, "Punto de Venta")
'            Return False
'        End Try

'        With fp_articulos.ActiveSheet
'            'REGISTRA LOS MOVIMIENTOS 
'            For i As Integer = 0 To .RowCount - 1
'                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .Cells(i, 4).Text.Trim & "'"
'                'Base.daQuery(sql, xCon, dsc3, "codart")
'                'If dsc3.Tables("codart").Rows.Count > 0 Then
'                'sql = "select * from tmpauxvta where tmp_articulo='" & dsc3.Tables("codart").Rows(0)("upc_cveart") & "' and tmp_usuario='" & Globales.caja & "'"
'                sql = "select * from tmpauxvta where tmp_articulo='" & .Cells(i, 11).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Try
'                    Base.daQuery(sql, xCon, dsc2, "impri")
'                Catch ex As Exception
'                    Try
'                        Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                        MsgBox("Error al traer los datos de tabla TmpAuxVta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    Catch ex2 As Exception
'                        MsgBox("Error al traer los datos de tabla TmpAuxVta. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    End Try
'                End Try

'                If dsc2.Tables("impri").Rows.Count > 0 Then
'                    sql = "UPDATE TMPAUXVTA SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, 0).Value &
'                                " ,TMP_TOTAL=(tmp_cantidad+" & .Cells(i, 0).Value & ")*" & .Cells(i, 2).Value & " where tmp_articulo='" & .Cells(i, 11).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Else
'                    sql = "INSERT INTO TMPAUXVTA SELECT '" & Globales.caja & "'," & .Cells(i, 0).Value & ",'" & .Cells(i, 11).Text.Trim &
'                            "','" & .Cells(i, 12).Text.Trim & "'," & .Cells(i, 2).Value & "," & .Cells(i, 3).Value
'                End If
'                Try
'                    Base.Ejecuta(sql, xCon)
'                Catch ex As Exception
'                    dsc2.Tables.Remove("impri")
'                    Try
'                        Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                        MsgBox("Error al traer los datos de tabla TmpAuxVta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    Catch ex2 As Exception
'                        MsgBox("Error al registrar la información en tabla TmpAuxVta. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    End Try
'                End Try
'                dsc2.Tables.Remove("impri")
'                'End If
'                'dsc3.Tables.Remove("codart")
'            Next i
'        End With


'        'PARA GENERAR UN CONSOLIDADO DE VENTAS SIN LAS CANCELACIONES QUE SE REGISTRARON

'        Try
'            Base.Ejecuta("DELETE FROM TMPAUXVTA1 WHERE TMP_USUARIO='" & Globales.caja & "'", xCon)
'        Catch ex As Exception
'            Try
'                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                MsgBox("Error al borrar los datos de tabla TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                Return False
'            Catch ex2 As Exception
'                MsgBox("Error al borrar los datos de tabla TmpAuxVta1. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                Return False
'            End Try
'        End Try

'        With fp_articulos.ActiveSheet
'            'REGISTRA LOS MOVIMIENTOS 
'            For i As Integer = 0 To .RowCount - 1
'                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .Cells(i, 4).Text.Trim & "'"
'                'Base.daQuery(sql, xCon, dsc3, "codart")
'                'If dsc3.Tables("codart").Rows.Count > 0 Then
'                sql = "select * from tmpauxvta1 where tmp_articulo='" & .Cells(i, 11).Text.Trim & "'" &
'                    " AND TMP_UPC='" & .Cells(i, 4).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Try
'                    Base.daQuery(sql, xCon, dsc2, "impri")
'                Catch ex As Exception
'                    Try
'                        Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                        MsgBox("Error al traer los datos de tabla TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return (True, False, False, False, False, False)
'                    Catch ex2 As Exception
'                        MsgBox("Error al traer los datos de tabla TmpAuxVta1. No pudo borrarse la información de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return (False, False, False, False, False, False)
'                    End Try
'                End Try

'                If dsc2.Tables("impri").Rows.Count > 0 Then
'                    sql = "UPDATE TMPAUXVTA1 SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, 0).Value &
'                        " ,TMP_TOTAL=(tmp_cantidad+" & .Cells(i, 0).Value & ")*" & .Cells(i, 2).Value &
'                        IIf(.Cells(i, 7).Value = dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=FueConF1", IIf(.Cells(i, 7).Value > dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=" & .Cells(i, 7).Value, "")) &
'                        IIf(.Cells(i, 8).Value = dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=FueConF2", IIf(.Cells(i, 8).Value > dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=" & .Cells(i, 8).Value, "")) &
'                        IIf(.Cells(i, 9).Value = dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=FueConF3", IIf(.Cells(i, 9).Value > dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=" & .Cells(i, 9).Value, "")) &
'                        " where tmp_articulo='" & .Cells(i, 11).Text.Trim & "'" &
'                        " AND TMP_UPC='" & .Cells(i, 4).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Else
'                    sql = "INSERT INTO TMPAUXVTA1 SELECT '" & Globales.caja & "'," & .Cells(i, 0).Value & ",'" & .Cells(i, 11).Text.Trim &
'                    "','" & .Cells(i, 12).Text.Trim & "'," & .Cells(i, 2).Value & "," & .Cells(i, 3).Value & ",'" & .Cells(i, 4).Text.Trim & "'," &
'                     .Cells(i, 6).Text.Trim & ",0,'" &
'                        .Cells(i, 13).Text.Trim & "'," & .Cells(i, 7).Value & "," & .Cells(i, 8).Value & "," & .Cells(i, 9).Value & "," & .Cells(i, 10).Text.Trim & ",0," & .Cells(i, 14).Text.Trim
'                End If
'                Try
'                    Base.Ejecuta(sql, xCon)
'                Catch ex As Exception
'                    dsc2.Tables.Remove("impri")
'                    Try
'                        Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                        Try
'                            Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                            MsgBox("Error al registrar la información en tabla TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                            Return (False, False, False, False, False, False)
'                        Catch ex2 As Exception
'                            MsgBox("Error al registrar la información en tabla TmpAuxVta1. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
'                            Return False
'                        End Try
'                    Catch ex3 As Exception
'                        MsgBox("Error al registrar la información en tabla TmpAuxVta1. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    End Try
'                End Try
'                dsc2.Tables.Remove("impri")
'                'End If
'                'dsc3.Tables.Remove("codart")
'            Next i
'        End With

'        'MOFICACION PARA CAJAS FIJAS
'        'PARA INSERTAR TOTALES EN ECVENTA
'        Dim RestaCancelacionUPC As Double
'        Dim TraeVale As Boolean
'        TraeVale = False
'        With fp_articulos.ActiveSheet
'            For i As Integer = 0 To .RowCount - 1
'                RestaCancelacionUPC = 0
'                If .Cells(i, 5).Text = "*" Then
'                    For k As Integer = 0 To .RowCount - 1
'                        If k <> i Then
'                            If .Cells(i, 4).Text.Trim = .Cells(k, 4).Text.Trim Then
'                                If .Cells(k, 0).Text <> "" Then
'                                    If IsNumeric(.Cells(k, 0).Value) Then
'                                        If CDbl(.Cells(k, 0).Value) < 0 Then
'                                            RestaCancelacionUPC += CDbl(.Cells(k, 0).Value)
'                                        End If
'                                    End If
'                                End If
'                            End If
'                        End If
'                    Next k

'                    If .Cells(i, 0).Text <> "" Then
'                        If IsNumeric(.Cells(i, 0).Value) Then
'                            If CDbl(.Cells(i, 0).Value) + RestaCancelacionUPC > 0 Then
'                                TraeVale = True
'                                Exit For
'                            End If
'                        End If
'                    End If
'                End If
'            Next i
'        End With

'        sSql = "insert into ecventa (ven_id,ven_usuario,ven_fecha,ven_status,ven_total,ven_turno,ven_tipov,CORTE, NombreCajera, TraeVale) " 'Serie
'        sSql &= "values (" & xven & ",'" & DATO & "',getDate(),1," & LbTotal.Text.Replace(",", "").Replace("$", "") + "," & Globales.iTurnoActivo & "," & TIPOVENTA & ",0,'" & Globales.NombreEmpleado & "','" & IIf(TraeVale, "*", "") & "')" 'Serie

'        Try
'            Base.Ejecuta(sSql, xCon)
'            'sSql = "select max(ven_id) from ecventa where ven_usuario='" & DATO & "'"
'            'Base.daQuery(sSql, xCon, dsc, "maximo")
'            iID = xven
'            numt = iID

'            Try
'                Base.Ejecuta("insert into LigasFolios values(" & xven & ",'" & FolioCaja & "')", xCon)
'            Catch ex As Exception
'                Try
'                    Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", xCon)
'                    Try
'                        Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                        Try
'                            Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                            MsgBox("Error al registrar la información en LigasFolios. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                            Return False
'                        Catch ex4 As Exception
'                            MsgBox("Error al registrar la información en LigasFolios. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1 y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                            Return False
'                        End Try
'                    Catch ex3 As Exception
'                        MsgBox("Error al registrar la información en LigasFolios. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta, sólo de ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    End Try
'                Catch ex2 As Exception
'                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en LigasFolios. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                    Return False
'                End Try
'            End Try


'            If estiempoaire Then
'                sSql = "insert into ecdetventatel (dve_venta,dve_telefono,dve_fecha,dve_folio) "
'                sSql &= "values (" & iID & ",'" & txt_ctel1.Text & "-" & txt_ctel2.Text & "-" & txt_ctel3.Text & "-" & txt_ctel4.Text & "',getdate(),0)" 'serie
'                Base.Ejecuta(sSql, xCon)
'            End If

'            '-----------------------------------------------------------------------------
'            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASTICKET ECDETVENTA

'            With fp_articulos.ActiveSheet
'                'REGISTRA LOS MOVIMIENTOS 
'                For i As Integer = 0 To .RowCount - 1
'                    RestaCancelacionUPC = 0
'                    If .Cells(i, 5).Text = "*" Then
'                        For k As Integer = 0 To fp_articulos.ActiveSheet.Rows.Count - 1
'                            If k <> i Then
'                                If .Cells(i, 4).Text.Trim = .Cells(k, 4).Text.Trim Then
'                                    If .Cells(k, 0).Text <> "" Then
'                                        If IsNumeric(.Cells(k, 0).Value) Then
'                                            If CDbl(.Cells(k, 0).Value) < 0 Then
'                                                RestaCancelacionUPC += CDbl(.Cells(k, 0).Value)
'                                            End If
'                                        End If
'                                    End If
'                                End If
'                            End If
'                        Next k
'                        If .Cells(i, 0).Text <> "" Then
'                            If IsNumeric(.Cells(i, 0).Value) Then
'                                If CDbl(.Cells(i, 0).Value) > 0 Then
'                                    'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .Cells(i, 4).Text.Trim & "'"
'                                    'Base.daQuery(sql, xCon, dsc3, "codart1")
'                                    'If dsc3.Tables("codart1").Rows.Count > 0 Then
'                                    If CDbl(.Cells(i, 0).Value) + RestaCancelacionUPC > 0 Then
'                                        sql = "INSERT INTO ECVENTADETE SELECT " & iID & ",'" & 'Serie
'                                            .Cells(i, 11).Text.Trim & "','" & .Cells(i, 4).Text.Trim & "'," & .Cells(i, 0).Value + RestaCancelacionUPC & "," &
'                                        .Cells(i, 2).Value & "," & .Cells(i, 3).Value
'                                        Try
'                                            Base.Ejecuta(sql, xCon)
'                                        Catch ex As Exception
'                                            Try
'                                                Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, xCon)
'                                                Try
'                                                    Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", xCon)
'                                                    Try
'                                                        Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                                        Try
'                                                            Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                                            MsgBox("Error al registrar la información en LigasFolios. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                            Return False
'                                                        Catch ex5 As Exception
'                                                            MsgBox("Error al registrar la información en LigasFolios. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1, ECVenta y ECVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                            Return False
'                                                        End Try
'                                                    Catch ex4 As Exception
'                                                        MsgBox("Error al registrar la información en ECVenta. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta, sólo de ECVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                        Return False
'                                                    End Try
'                                                Catch ex3 As Exception
'                                                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDete. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                    Return False
'                                                End Try
'                                            Catch ex2 As Exception
'                                                MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDete. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                Return False
'                                            End Try
'                                        End Try
'                                    End If
'                                    'End If
'                                    'dsc3.Tables.Remove("codart1")
'                                End If
'                            End If
'                        End If
'                    End If
'                Next i
'            End With

'            Try
'                sql = "Select * from tmpauxvta where tmp_usuario='" & Globales.caja & "'"
'                Base.daQuery(sql, xCon, dsc2, "detventa")
'            Catch ex As Exception
'                Try
'                    Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, xCon)
'                    Try
'                        Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", xCon)
'                        Try
'                            Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                            Try
'                                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                MsgBox("Error al traer los datos de tabla TmpAuxVta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                                Return False
'                            Catch ex5 As Exception
'                                MsgBox("Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1, ECVenta y ECVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                                Return False
'                            End Try
'                        Catch ex4 As Exception
'                            MsgBox("Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                            Return False
'                        End Try
'                    Catch ex3 As Exception
'                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    End Try
'                Catch ex2 As Exception
'                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de tabla TmpAuxVta. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                    Return False
'                End Try
'            End Try


'            xrenglon = 1
'            If dsc2.Tables("detventa").Rows.Count > 0 Then

'                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
'                    With fp_articulos.ActiveSheet
'                        'xsql = "Select art_iva,art_ieps,art_costocap2,art_familia,art_cap1,art_uni1,art_cap2,art_uni2 from articulo where art_clave='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
'                        'Base.daQuery(xsql, xCon, dsc1, "precios")
'                        If .Cells(iRen, 11).Text.Trim <> "" Then
'                            iva = .Cells(iRen, 6).Text.Trim
'                            IEPS = .Cells(iRen, 10).Text.Trim
'                            costo = .Cells(iRen, 14).Text.Trim
'                            familia = .Cells(iRen, 13).Text.Trim
'                            'cap1 = dsc1.Tables("precios").Rows(0)("art_cap1")
'                            'cap2 = dsc1.Tables("precios").Rows(0)("art_cap2")
'                            'uni1 = dsc1.Tables("precios").Rows(0)("art_uni1")
'                            'uni2 = dsc1.Tables("precios").Rows(0)("art_uni2")
'                        Else
'                            iva = 0
'                            IEPS = 0
'                            costo = 0
'                            familia = 0
'                            'cap1 = 1
'                            'cap2 = 1
'                            'uni1 = "PZ"
'                            'uni2 = "PZ"
'                        End If
'                        'dsc1.Tables.Remove("precios")
'                        precio = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_precio"))
'                        cant = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_cantidad"))


'                        sSql = "insert into ecdetventa (dve_venta,dve_articulo,dve_precio,dve_cantidad,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon, DVE_PORIEPS, DVE_IEPS) "
'                        sSql &= "values (" & iID & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & precio & "," & cant & "," & 'serie
'                         iva & "," & ((precio * cant) / (1 + (iva / 100))) * iva / 100 & "," & costo & "," & cant * costo & ",'" & familia & "'," & iRen + 1 & "," & IEPS & "," & ((precio * cant) / (1 + (IEPS / 100))) * IEPS / 100 & ")"
'                        Try
'                            Base.Ejecuta(sSql, xCon)
'                        Catch ex As Exception
'                            dsc2.Tables.Remove("detventa")
'                            Try
'                                Base.Ejecuta("delete from ecdetventa where dve_venta=" & xven, xCon)
'                                Try
'                                    Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, xCon)
'                                    Try
'                                        Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", xCon)
'                                        Try
'                                            Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                            Try
'                                                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                                MsgBox("Error al insertar datos en ECDetVenta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                Return False
'                                            Catch ex6 As Exception
'                                                MsgBox("Error al insertar datos en ECDetVenta. No pudo borrarse información de TmpAuxVta, sólo de ECDetVenta, ECVentaDete, ECVenta y TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                Return False
'                                            End Try
'                                        Catch ex5 As Exception
'                                            MsgBox("Error al insertar datos en ECDetVenta. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECDetVenta, ECVentaDete y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                                            Return False
'                                        End Try
'                                    Catch ex4 As Exception
'                                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                                        Return False
'                                    End Try
'                                Catch ex3 As Exception
'                                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                                    Return False
'                                End Try
'                            Catch ex2 As Exception
'                                MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta. No pudo borrarse información de ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                                Return False
'                            End Try
'                        End Try



'                        'sSql = "select * from ecpromopuntos where prom_articulo='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
'                        'Base.daQuery(sSql, xCon, dsc, "promo")
'                        'If dsc.Tables("promo").Rows.Count > 0 Then
'                        '    sSql = "insert into eccanjepuntos (canje_ticket,canje_fecha,canje_renglon,canje_articulo,canje_cantidad,canje_puntos,canje_usados,canje_saldo) " &
'                        '        " values (" & iID & ",getdate()," & xrenglon & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & cant & "," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ",0," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ")" 'serie
'                        '    sipuntos = True
'                        '    Base.Ejecuta(sSql, xCon)
'                        '    xrenglon = xrenglon + 1

'                        'End If
'                        'dsc.Tables.Remove("promo")
'                    End With
'                Next iRen
'            End If

'            dsc2.Tables.Remove("detventa")


'            '-----------------------------------------------------------------------------
'            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASDETALLADAS ECVENTADET
'            sql = "SELECT * FROM TMPAUXVTA1  where tmp_usuario='" & Globales.caja & "'"
'            Try
'                Base.daQuery(sql, xCon, dsc2, "detventa")
'            Catch ex As Exception
'                Try
'                    Base.Ejecuta("delete from ecdetventa where dve_venta=" & xven, xCon)
'                    Try
'                        Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, xCon)
'                        Try
'                            Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", xCon)
'                            Try
'                                Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                Try
'                                    Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                    MsgBox("Error al traer los datos de TmpAuxVta1. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                                    Return False
'                                Catch ex6 As Exception
'                                    MsgBox("Error al traer los datos de TmpAuxVta1. No pudo borrarse información de TmpAuxVta, sólo de ECDetVenta, ECVentaDete, ECVenta y TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
'                                    Return False
'                                End Try
'                            Catch ex5 As Exception
'                                MsgBox("Error al traer los datos de TmpAuxVta1. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECDetVenta, ECVentaDete y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                                Return False
'                            End Try
'                        Catch ex4 As Exception
'                            MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                            Return False
'                        End Try
'                    Catch ex3 As Exception
'                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECDetVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                        Return False
'                    End Try
'                Catch ex2 As Exception
'                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1. No pudo borrarse información de ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                    Return False
'                End Try
'            End Try


'            If dsc2.Tables("detventa").Rows.Count > 0 Then
'                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
'                    sSql = "insert into ecventadet (dve_venta,dve_articulo,dve_upc,dve_precio,dve_cantidad,dve_total,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon,DVE_FALTINV,FueConF1,FueConF2,FueConF3, DVE_PORIEPS, DVE_IEPS) "
'                    sSql &= "values (" & iID & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" & 'serie
'                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) & "," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & "," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) &
'                     "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) & "," &
'                     ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0 &
'                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) & "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_FAMILIA") & "'," & iRen + 1 & ",0," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF1") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF2") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF3") & '")" &
'                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) & "," &
'                    ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0 &
'                    ")"
'                    Try
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Try
'                            Base.Ejecuta("delete from ecventadet where dve_venta=" & xven, xCon)
'                            Try
'                                Base.Ejecuta("delete from ecdetventa where dve_venta=" & xven, xCon)
'                                Try
'                                    Base.Ejecuta("delete from ecventadete where dve_venta=" & xven, xCon)
'                                    Try
'                                        Base.Ejecuta("delete from ecventa where ven_id=" & xven & " and ven_usuario='" & DATO & "'", xCon)
'                                        Try
'                                            Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                            Try
'                                                Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                                                MsgBox("Error al registrar la información en ECVentaDet. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                Return False
'                                            Catch ex7 As Exception
'                                                MsgBox("Error al registrar la información en ECVentaDet. No pudo borrarse información de TmpAuxVta, sólo de ECVentaDet, ECDetVenta, ECVentaDete, ECVenta y TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
'                                                Return False
'                                            End Try
'                                        Catch ex6 As Exception
'                                            MsgBox("Error al registrar la información en ECVentaDet. No pudo borrarse información de TmpAuxVta1 ni de TmpAuxVta, sólo de ECVentaDet, ECDetVenta, ECVentaDete y ECVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                                            Return False
'                                        End Try
'                                    Catch ex5 As Exception
'                                        MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECVentaDet, ECDetVenta y EcVentaDete.", MsgBoxStyle.Critical, "Punto de Venta")
'                                        Return False
'                                    End Try
'                                Catch ex4 As Exception
'                                    MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECVentaDet, ECDetVenta.", MsgBoxStyle.Critical, "Punto de Venta")
'                                    Return False
'                                End Try
'                            Catch ex3 As Exception
'                                MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta, sólo de ECVentaDet.", MsgBoxStyle.Critical, "Punto de Venta")
'                                Return False
'                            End Try
'                        Catch ex2 As Exception
'                            MsgBox("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet. No pudo borrarse información de ECVentaDet, ECDetVenta, ECVentaDete, ECVenta, TmpAuxVta1 ni TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                            Return False
'                        End Try
'                    End Try



'                    sSql = "EXEC CARGAEST  " & "'" &
'                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" &
'                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))

'                    'Base.Ejecuta(sSql, xCon)

'                Next iRen

'            End If
'            dsc2.Tables.Remove("DETVENTA")           '----------------------------------------------------------------------------

'            sql = "exec aplicaventainventario " & iID & ",1" 'serie
'            Try
'                Base.Ejecuta(sql, xCon)
'            Catch ex As Exception
'                MsgBox("Error en Procedimiento AplicaVentaInventario. Se requerirá recálculo.", MsgBoxStyle.Critical, "Punto de Venta")
'            End Try


'            'dsc.Tables.Remove("maximo")
'        Catch ex As Exception
'            'Esto es más relevante, no se pudo insertar en ECVenta, aun así, no hay gravedad. Solo reintentar.
'            Try
'                Base.Ejecuta("delete from TmpAuxVta1 where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                Try
'                    Base.Ejecuta("delete from TmpAuxVta where Tmp_Usuario='" & Globales.caja & "'", xCon)
'                    MsgBox("Error al registrar la información en ECVenta. Progreso borrado correctamente.", MsgBoxStyle.Critical, "Punto de Venta")
'                    Return False
'                Catch ex2 As Exception
'                    MsgBox("Error al registrar la información en ECVenta. No pudo borrarse información de TmpAuxVta, sólo de TmpAuxVta1.", MsgBoxStyle.Critical, "Punto de Venta")
'                    Return False
'                End Try
'            Catch ex3 As Exception
'                MsgBox("Error al registrar la información en ECVenta. No pudo borrarse información de TmpAuxVta1, ni de TmpAuxVta.", MsgBoxStyle.Critical, "Punto de Venta")
'                Return False
'            End Try
'        End Try
'        Return True
'    End Function


'    Public Function GuardaTicketConHandler(FolioCaja As String) As (Mensaje As String, TmpAuxVta As Boolean, TmpAuxVta1 As Boolean, ECVenta As Boolean, LigasFolios As Boolean, ECVentaDete As Boolean, ECVentaDet As Boolean, ECDetVenta As Boolean)
'        Dim iRen As Integer = 0
'        Dim sSql As String = ""
'        Dim xsql As String = ""
'        Dim dsc As New DataSet
'        Dim dsc1 As New DataSet
'        Dim iID As Integer
'        Dim iva, IEPS As Double
'        Dim familia As String
'        Dim costo As Double
'        Dim precio As Double
'        Dim cant As Double
'        Dim DATO As String
'        Dim sql As String
'        Dim dsc2 As New DataSet
'        Dim dsc3 As New DataSet
'        Dim dsc4 As New DataSet
'        'Dim cap1 As Double
'        'Dim cap2 As Double
'        'Dim uni1 As String
'        'Dim uni2 As String
'        Dim xrenglon As Integer


'        'xven = 0
'        'sql = "select isnull(folio,0)+1 maximo from eccontrolventa"
'        'Base.daQuery(sql, xCon, dsc, "tabla")
'        'xven = dsc.Tables("tabla").Rows(0)("maximo")
'        'Base.Ejecuta("update eccontrolventa set folio=folio+1", xCon)


'        DATO = "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1)

'        'Para generar el consolidado del ticket
'        Try
'            Base.Ejecuta("DELETE FROM TMPAUXVTA WHERE TMP_USUARIO='" & Globales.caja & "'", xCon)
'        Catch ex As Exception
'            Return ("Error al borrar los datos de tabla TmpAuxVta" & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), False, False, False, False, False, False, False)
'        End Try

'        With fp_articulos.ActiveSheet
'            'REGISTRA LOS MOVIMIENTOS 
'            For i As Integer = 0 To .RowCount - 1
'                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .cells(i, colupcinv).Text.Trim & "'"
'                'Base.daQuery(sql, xCon, dsc3, "codart")
'                'If dsc3.Tables("codart").Rows.Count > 0 Then
'                'sql = "select * from tmpauxvta where tmp_articulo='" & dsc3.Tables("codart").Rows(0)("upc_cveart") & "' and tmp_usuario='" & Globales.caja & "'"
'                sql = "select * from tmpauxvta where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Try
'                    Base.daQuery(sql, xCon, dsc2, "impri")
'                Catch ex As Exception
'                    Return ("Error al traer los datos de tabla TmpAuxVta." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
'                End Try

'                If dsc2.Tables("impri").Rows.Count > 0 Then
'                    sql = "UPDATE TMPAUXVTA SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, ColVenta.ColCantidad).Value &
'                                " ,TMP_TOTAL=(tmp_cantidad+" & .Cells(i, ColVenta.ColCantidad).Value & ")*" & .Cells(i, ColVenta.ColPrecio).Value & " where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Else
'                    sql = "INSERT INTO TMPAUXVTA SELECT '" & Globales.caja & "'," & .Cells(i, ColVenta.ColCantidad).Value & ",'" & .Cells(i, ColVenta.ColArtClave).Text.Trim &
'                            "','" & .Cells(i, ColVenta.ColNomLargo).Text.Trim & "'," & .Cells(i, ColVenta.ColPrecio).Value & "," & .Cells(i, ColVenta.ColTotal).Value & "," & .Cells(i, ColVenta.ColFIVA).Value & "," & .Cells(i, ColVenta.ColFIEPS).Value & ",'" & .Cells(i, ColVenta.ColFamilia).Value & "'," & .Cells(i, ColVenta.ColCostoCap).Value '& "," & .Cells(i, ColVenta.ColPrecio1).Value
'                End If
'                Try
'                    Base.Ejecuta(sql, xCon)
'                Catch ex As Exception
'                    dsc2.Tables.Remove("impri")
'                    Return ("Error al registrar la información en tabla TmpAuxVta." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
'                End Try
'                dsc2.Tables.Remove("impri")
'                'End If
'                'dsc3.Tables.Remove("codart")
'            Next i
'        End With


'        'PARA GENERAR UN CONSOLIDADO DE VENTAS SIN LAS CANCELACIONES QUE SE REGISTRARON

'        Try
'            Base.Ejecuta("DELETE FROM TMPAUXVTA1 WHERE TMP_USUARIO='" & Globales.caja & "'", xCon)
'        Catch ex As Exception
'            Return ("Error al borrar los datos de tabla TmpAuxVta1." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
'        End Try

'        With fp_articulos.ActiveSheet
'            'REGISTRA LOS MOVIMIENTOS 
'            For i As Integer = 0 To .RowCount - 1
'                'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .cells(i, colupcinv).Text.Trim & "'"
'                'Base.daQuery(sql, xCon, dsc3, "codart")
'                'If dsc3.Tables("codart").Rows.Count > 0 Then
'                sql = "select * from tmpauxvta1 where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "'" &
'                    " AND TMP_UPC='" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Try
'                    Base.daQuery(sql, xCon, dsc2, "impri")
'                Catch ex As Exception
'                    Return ("Error al traer los datos de tabla TmpAuxVta1." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, False, False, False, False, False, False)
'                End Try

'                If dsc2.Tables("impri").Rows.Count > 0 Then
'                    sql = "UPDATE TMPAUXVTA1 SET TMP_CANTIDAD=TMP_CANTIDAD+" & .Cells(i, ColVenta.ColCantidad).Value &
'                        " ,TMP_TOTAL=(tmp_cantidad+" & .Cells(i, ColVenta.ColCantidad).Value & ")*" & .Cells(i, ColVenta.ColPrecio).Value &
'                        IIf(.Cells(i, ColVenta.ColF1).Value = dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=FueConF1", IIf(.Cells(i, ColVenta.ColF1).Value > dsc2.Tables("impri").Rows(0)("FueConF1"), ",FueConF1=" & .Cells(i, ColVenta.ColF1).Value, "")) &
'                        IIf(.Cells(i, ColVenta.ColF2).Value = dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=FueConF2", IIf(.Cells(i, ColVenta.ColF2).Value > dsc2.Tables("impri").Rows(0)("FueConF2"), ",FueConF2=" & .Cells(i, ColVenta.ColF2).Value, "")) &
'                        IIf(.Cells(i, ColVenta.ColF3).Value = dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=FueConF3", IIf(.Cells(i, ColVenta.ColF3).Value > dsc2.Tables("impri").Rows(0)("FueConF3"), ",FueConF3=" & .Cells(i, ColVenta.ColF3).Value, "")) &
'                        " where tmp_articulo='" & .Cells(i, ColVenta.ColArtClave).Text.Trim & "'" &
'                        " AND TMP_UPC='" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "' and tmp_usuario='" & Globales.caja & "'"
'                Else
'                    sql = "INSERT INTO TMPAUXVTA1 SELECT '" & Globales.caja & "'," & .Cells(i, ColVenta.ColCantidad).Value & ",'" & .Cells(i, ColVenta.ColArtClave).Text.Trim &
'                    "','" & .Cells(i, ColVenta.ColNomLargo).Text.Trim & "'," & .Cells(i, ColVenta.ColPrecio).Value & "," & .Cells(i, ColVenta.ColTotal).Value & ",'" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "'," &
'                     .Cells(i, ColVenta.ColFIVA).Text.Trim & ",0,'" &
'                        .Cells(i, ColVenta.ColFamilia).Text.Trim & "'," & .Cells(i, ColVenta.ColF1).Value & "," & .Cells(i, ColVenta.ColF2).Value & "," & .Cells(i, ColVenta.ColF3).Value & "," & .Cells(i, ColVenta.ColFIEPS).Value & ",0," & .Cells(i, ColVenta.ColCostoCap).Value
'                End If
'                Try
'                    Base.Ejecuta(sql, xCon)
'                Catch ex As Exception
'                    dsc2.Tables.Remove("impri")
'                    Return ("Error al registrar la información en tabla TmpAuxVta1." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, True, False, False, False, False, False)
'                End Try
'                dsc2.Tables.Remove("impri")
'                'End If
'                'dsc3.Tables.Remove("codart")
'            Next i
'        End With

'        If HayTarjeta Then
'            SacaProporcionP1P2(xven)
'        End If

'        'MOFICACION PARA CAJAS FIJAS
'        'PARA INSERTAR TOTALES EN ECVENTA
'        Dim RestaCancelacionUPC As Double
'        Dim TraeVale As Boolean
'        TraeVale = False
'        With fp_articulos.ActiveSheet
'            For i As Integer = 0 To .RowCount - 1
'                RestaCancelacionUPC = 0
'                If .Cells(i, ColVenta.ColVale).Text = "*" Then
'                    For k As Integer = 0 To .RowCount - 1
'                        If k <> i Then
'                            If .Cells(i, ColVenta.ColUPCInv).Text.Trim = .Cells(k, ColVenta.ColUPCInv).Text.Trim Then
'                                If .Cells(k, ColVenta.ColCantidad).Text <> "" Then
'                                    If IsNumeric(.Cells(k, ColVenta.ColCantidad).Value) Then
'                                        If CDbl(.Cells(k, ColVenta.ColCantidad).Value) < 0 Then
'                                            RestaCancelacionUPC += CDbl(.Cells(k, ColVenta.ColCantidad).Value)
'                                        End If
'                                    End If
'                                End If
'                            End If
'                        End If
'                    Next k

'                    If .Cells(i, ColVenta.ColCantidad).Text <> "" Then
'                        If IsNumeric(.Cells(i, ColVenta.ColCantidad).Value) Then
'                            If CDbl(.Cells(i, ColVenta.ColCantidad).Value) + RestaCancelacionUPC > 0 Then
'                                TraeVale = True
'                                Exit For
'                            End If
'                        End If
'                    End If
'                End If
'            Next i
'        End With

'        sSql = "insert into ecventa (ven_id,ven_usuario,ven_fecha,ven_status,ven_total,ven_turno,ven_tipov,CORTE, NombreCajera, TraeVale) " 'Serie
'        sSql &= "values (" & xven & ",'" & DATO & "',getDate(),1," & LbTotal.Text.Replace(",", "").Replace("$", "") + "," & Globales.iTurnoActivo & "," & TIPOVENTA & ",0,'" & Globales.NombreEmpleado & "','" & IIf(TraeVale, "*", "") & "')" 'Serie

'        Try
'            Base.Ejecuta(sSql, xCon)
'            'sSql = "select max(ven_id) from ecventa where ven_usuario='" & DATO & "'"
'            'Base.daQuery(sSql, xCon, dsc, "maximo")
'            iID = xven
'            numt = iID

'            Try
'                Base.Ejecuta("insert into LigasFolios values(" & xven & ",'" & FolioCaja & "')", xCon)
'            Catch ex As Exception
'                Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al registrar la información en LigasFolios.", True, True, True, False, False, False, False)
'            End Try


'            If estiempoaire Then
'                sSql = "insert into ecdetventatel (dve_venta,dve_telefono,dve_fecha,dve_folio) "
'                sSql &= "values (" & iID & ",'" & txt_ctel1.Text & "-" & txt_ctel2.Text & "-" & txt_ctel3.Text & "-" & txt_ctel4.Text & "',getdate(),0)" 'serie
'                Base.Ejecuta(sSql, xCon)
'            End If

'            '-----------------------------------------------------------------------------
'            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASTICKET ECDETVENTA

'            With fp_articulos.ActiveSheet
'                'REGISTRA LOS MOVIMIENTOS 
'                For i As Integer = 0 To .RowCount - 1
'                    RestaCancelacionUPC = 0
'                    If .Cells(i, ColVenta.ColVale).Text = "*" Then
'                        For k As Integer = 0 To fp_articulos.ActiveSheet.Rows.Count - 1
'                            If k <> i Then
'                                If .Cells(i, ColVenta.ColUPCInv).Text.Trim = .Cells(k, ColVenta.ColUPCInv).Text.Trim Then
'                                    If .Cells(k, ColVenta.ColCantidad).Text <> "" Then
'                                        If IsNumeric(.Cells(k, ColVenta.ColCantidad).Value) Then
'                                            If CDbl(.Cells(k, ColVenta.ColCantidad).Value) < 0 Then
'                                                RestaCancelacionUPC += CDbl(.Cells(k, ColVenta.ColCantidad).Value)
'                                            End If
'                                        End If
'                                    End If
'                                End If
'                            End If
'                        Next k
'                        If .Cells(i, ColVenta.ColCantidad).Text <> "" Then
'                            If IsNumeric(.Cells(i, ColVenta.ColCantidad).Value) Then
'                                If CDbl(.Cells(i, ColVenta.ColCantidad).Value) > 0 Then
'                                    'sql = "Select * from xupc inner join articulo on art_clave=upc_cveart where upc_upc='" & .cells(i, colupcinv).Text.Trim & "'"
'                                    'Base.daQuery(sql, xCon, dsc3, "codart1")
'                                    'If dsc3.Tables("codart1").Rows.Count > 0 Then
'                                    If CDbl(.Cells(i, ColVenta.ColCantidad).Value) + RestaCancelacionUPC > 0 Then
'                                        sql = "INSERT INTO ECVENTADETE SELECT " & iID & ",'" & 'Serie
'                                            .Cells(i, ColVenta.ColArtClave).Text.Trim & "','" & .Cells(i, ColVenta.ColUPCInv).Text.Trim & "'," & .Cells(i, ColVenta.ColCantidad).Value + RestaCancelacionUPC & "," &
'                                        .Cells(i, ColVenta.ColPrecio).Value & "," & .Cells(i, ColVenta.ColTotal).Value
'                                        Try
'                                            Base.Ejecuta(sql, xCon)
'                                        Catch ex As Exception
'                                            Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDete.", True, True, True, True, True, False, False)
'                                        End Try
'                                    End If
'                                    'End If
'                                    'dsc3.Tables.Remove("codart1")
'                                End If
'                            End If
'                        End If
'                    End If
'                Next i
'            End With

'            Try
'                sql = "Select * from tmpauxvta where tmp_usuario='" & Globales.caja & "'"
'                Base.daQuery(sql, xCon, dsc2, "detventa")
'            Catch ex As Exception
'                Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al traer los datos de tabla TmpAuxVta.", True, True, True, True, True, False, False)
'            End Try


'            xrenglon = 1
'            If dsc2.Tables("detventa").Rows.Count > 0 Then

'                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
'                    With fp_articulos.ActiveSheet
'                        'xsql = "Select art_iva,art_ieps,art_costocap2,art_familia,art_cap1,art_uni1,art_cap2,art_uni2 from articulo where art_clave='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
'                        'Base.daQuery(xsql, xCon, dsc1, "precios")
'                        If .Cells(iRen, ColVenta.ColArtClave).Text.Trim <> "" Then
'                            iva = dsc2.Tables("detventa").Rows(iRen)("tmp_iva")
'                            IEPS = dsc2.Tables("detventa").Rows(iRen)("tmp_ieps")
'                            costo = dsc2.Tables("detventa").Rows(iRen)("tmp_costo")
'                            familia = dsc2.Tables("detventa").Rows(iRen)("tmp_familia")
'                            'cap1 = dsc1.Tables("precios").Rows(0)("art_cap1")
'                            'cap2 = dsc1.Tables("precios").Rows(0)("art_cap2")
'                            'uni1 = dsc1.Tables("precios").Rows(0)("art_uni1")
'                            'uni2 = dsc1.Tables("precios").Rows(0)("art_uni2")
'                        Else
'                            iva = 0
'                            IEPS = 0
'                            costo = 0
'                            familia = 0
'                            'cap1 = 1
'                            'cap2 = 1
'                            'uni1 = "PZ"
'                            'uni2 = "PZ"
'                        End If
'                        'dsc1.Tables.Remove("precios")
'                        precio = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_precio"))
'                        cant = CDbl(dsc2.Tables("detventa").Rows(iRen)("tmp_cantidad"))


'                        sSql = "insert into ecdetventa (dve_venta,dve_articulo,dve_precio,dve_cantidad,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon, DVE_PORIEPS, DVE_IEPS) "
'                        sSql &= "values (" & iID & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & precio & "," & cant & "," & 'serie
'                         iva & "," & ((precio * cant) / (1 + (iva / 100))) * iva / 100 & "," & costo & "," & cant * costo & ",'" & familia & "'," & iRen + 1 & "," & IEPS & "," & ((precio * cant) / (1 + (IEPS / 100))) * IEPS / 100 & ")"
'                        Try
'                            Base.Ejecuta(sSql, xCon)
'                        Catch ex As Exception
'                            dsc2.Tables.Remove("detventa")
'                            Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al insertar datos en ECDetVenta.", True, True, True, True, True, True, False)
'                        End Try



'                        'sSql = "select * from ecpromopuntos where prom_articulo='" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'"
'                        'Base.daQuery(sSql, xCon, dsc, "promo")
'                        'If dsc.Tables("promo").Rows.Count > 0 Then
'                        '    sSql = "insert into eccanjepuntos (canje_ticket,canje_fecha,canje_renglon,canje_articulo,canje_cantidad,canje_puntos,canje_usados,canje_saldo) " &
'                        '        " values (" & iID & ",getdate()," & xrenglon & ",'" & dsc2.Tables("detventa").Rows(iRen)("tmp_articulo") & "'," & cant & "," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ",0," & CDbl(dsc.Tables("promo").Rows(0)("prom_puntos")) * cant & ")" 'serie
'                        '    sipuntos = True
'                        '    Base.Ejecuta(sSql, xCon)
'                        '    xrenglon = xrenglon + 1

'                        'End If
'                        'dsc.Tables.Remove("promo")
'                    End With
'                Next iRen
'            End If

'            dsc2.Tables.Remove("detventa")


'            '-----------------------------------------------------------------------------
'            'PARA REGISTRAR DATOS EN LA TABLA DE VENTASDETALLADAS ECVENTADET
'            sql = "SELECT * FROM TMPAUXVTA1  where tmp_usuario='" & Globales.caja & "'"
'            Try
'                Base.daQuery(sql, xCon, dsc2, "detventa")
'            Catch ex As Exception
'                Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al traer los datos de TmpAuxVta1.", True, True, True, True, True, True, False)
'            End Try


'            If dsc2.Tables("detventa").Rows.Count > 0 Then
'                For iRen = 0 To dsc2.Tables("detventa").Rows.Count - 1
'                    sSql = "insert into ecventadet (dve_venta,dve_articulo,dve_upc,dve_precio,dve_cantidad,dve_total,dve_poriva,dve_iva,dve_costou,dve_costo,dve_familia,dve_renglon,DVE_FALTINV,FueConF1,FueConF2,FueConF3, DVE_PORIEPS, DVE_IEPS) "
'                    sSql &= "values (" & iID & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" & 'serie
'                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) & "," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & "," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) &
'                     "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) & "," &
'                     ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIVA")) / 100.0 &
'                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) & "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_COSTOU")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD")) & ",'" & dsc2.Tables("DETVENTA").Rows(iRen)("TMP_FAMILIA") & "'," & iRen + 1 & ",0," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF1") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF2") & "," & dsc2.Tables("DETVENTA").Rows(iRen)("FueConF3") & '")" &
'                    "," & CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) & "," &
'                    ((CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PRECIO")) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))) / (1 + (CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0))) * CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_PORIEPS")) / 100.0 &
'                    ")"
'                    Try
'                        Base.Ejecuta(sSql, xCon)
'                    Catch ex As Exception
'                        Return ("Error Crítico, notifique a Jaime Burciaga." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Error al registrar la información en ECVentaDet.", True, True, True, True, True, True, True)
'                    End Try



'                    sSql = "EXEC CARGAEST  " & "'" &
'                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_ARTICULO") & "','" &
'                    dsc2.Tables("DETVENTA").Rows(iRen)("TMP_UPC") & "'," &
'                    CDbl(dsc2.Tables("DETVENTA").Rows(iRen)("TMP_CANTIDAD"))

'                    'Base.Ejecuta(sSql, xCon)

'                Next iRen

'            End If
'            dsc2.Tables.Remove("DETVENTA")           '----------------------------------------------------------------------------


'            Try
'                sql = "exec aplicaventainventario " & iID & ",1" 'serie
'                Base.Ejecuta(sql, xCon)
'            Catch ex As Exception
'                MsgBox("Error en Procedimiento AplicaVentaInventario." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13) & "Se requerirá recálculo.", MsgBoxStyle.Critical, "Punto de Venta")
'            End Try


'            'dsc.Tables.Remove("maximo")
'        Catch ex As Exception
'            'Esto es más relevante, no se pudo insertar en ECVenta, aun así, no hay gravedad. Solo reintentar.
'            Return ("Error al registrar la información en ECVenta." & Chr(13) & Chr(13) & ex.Message & Chr(13) & Chr(13), True, True, False, False, False, False, False)
'        End Try
'        Return ("OK", False, False, False, False, False, False, False)
'    End Function

'    Public Sub imprimeTicket(ByRef pre As Collection)
'        Dim oImpresion As Impresion
'        oImpresion = New Impresion(pre)
'        oImpresion.imprime(True)
'    End Sub

'    Public Sub imprimevirtual(ByRef pre As Collection)
'        Dim oImpresion As Impresionvirtual
'        oImpresion = New Impresionvirtual(pre)
'        oImpresion.imprime()
'    End Sub

'    Public Sub imprimetaire(ByRef pre As Collection)
'        Dim oImpresion As imptaire
'        oImpresion = New imptaire(pre)
'        oImpresion.imprime()
'    End Sub


'    Public Sub limpiaSpread(ByVal Optional CerrandoVenta As Boolean = False, ByVal Optional CambiandoTipoVenta As Boolean = False)
'        Dim SQL As String

'        With fp_articulos.ActiveSheet
'            .RowCount = 0
'        End With
'        With FP_FORMASPAGO.ActiveSheet
'            .RowCount = 0
'        End With

'        TxtControl.Text = "0"
'        LbClienteTicket.Text = "Cliente: Público en General"

'        PanelCancelaciones.Visible = False
'        ListBox1.Items.Clear()

'        VentaCajaVirtual = False
'        TX_UPC.BackColor = Color.White

'        grformapago.Visible = False
'        ntx_totalventa.Text = ""
'        ntx_totalpago.Text = ""
'        TX_TOTALPAGO.Text = ""
'        LbTotal.Text = ""
'        sCant = ""
'        claveArt = ""
'        totalpagos = 0
'        TotalComision = 0
'        HayTarjeta = False
'        Dim Entra As Boolean = True
'        If CerrandoVenta Then
'            Entra = True
'        End If
'        If CambiandoTipoVenta OrElse CerrandoVenta = False Then
'            Entra = BuscaVenta(CambiandoTipoVenta)
'            Entra = IIf(Entra, False, True)
'        End If


'        If Entra Then
'            SQL = "DELETE FROM " & Globales.caja & " "
'            Base.Ejecuta(SQL, xCon)
'            SQL = "delete from tmpauxvta2 where usuario='" & Globales.caja & "'"
'            Base.Ejecuta(SQL, xCon)
'            TIPOVENTA = 1
'            txt_tipoventa.Text = "1"
'            txt_tipoventa.Focus()
'        End If


'        Banderita = False

'    End Sub

'    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
'        Dim autorizado As Boolean
'        Dim oforma1 As Form

'        oforma1 = New paraautorizarSALIDA(Me, autorizado, Me.xCon)
'        oforma1.Top = (Me.Height / 2 - oforma1.Height / 2)
'        oforma1.Left = (Me.Width / 2 - oforma1.Width / 2)
'        oforma1.BringToFront()
'        oforma1.ShowDialog()
'    End Sub

'    Dim contando As Integer
'    Dim iren As Integer


'    Public Sub TX_UPC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TX_UPC.KeyDown
'        Dim i As Integer

'        Dim forma As Form
'        Dim autor As Form
'        Dim TOPE As Double
'        Dim cve As String
'        Dim nomlargo As String
'        Dim precio As Double
'        Dim sql As String = ""
'        Dim dsc As New DataSet
'        Dim recorre As Integer
'        Dim banderola As Integer
'        Dim k As Integer
'        Dim PRECIO1 As Double
'        Dim ANTERIOR As Double
'        Dim xtipo As Integer
'        Dim cantidad As Double
'        Dim upcbusqueda As String
'        Dim totpzas As Double
'        Dim sql2 As String
'        Dim errorcode As Integer
'        Dim iva As Integer
'        Dim VENT As New VENTANITA("¿Desea cancelar el Articulo?", "BORRAR")
'        Dim xcve As String

'        If ModifierKeys <> ModifierKeys.None Then
'            Exit Sub
'        End If

'        If (e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F4) And fp_articulos.ActiveSheet.RowCount <= 0 Then
'            Exit Sub
'        End If

'        If e.KeyCode = Keys.End Then
'            If grformapago.Visible = False Then
'                fp_articulos.ActiveSheet.ActiveRowIndex = fp_articulos.ActiveSheet.RowCount - 1
'                fp_articulos.Focus()
'            End If
'        End If

'        If e.KeyCode = Keys.Home Then
'            If fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColCantidad).Value > 0 Then
'                If fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = "*" Then
'                    MsgBox("Se Registro el Artículo como entregado en caja", MsgBoxStyle.Information)
'                    fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = ""
'                Else
'                    MsgBox("Se Registro el Artículo para entrega de Producto", MsgBoxStyle.Information)
'                    fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = "*"
'                End If
'                sql = "update TMPAUXVTA2 set TraeVale='" & fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value & "' where usuario='" & Globales.caja & "' and Renglon=" & fp_articulos.ActiveSheet.RowCount - 1
'                Try
'                    Base.Ejecuta(sql, xCon)
'                Catch ex As Exception
'                    MsgBox("Error al actualizar Vale en TmpAuxVta2." & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Punto de Venta")
'                End Try
'                segundoticket = True
'                TX_UPC.Focus()
'            Else
'                fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColVale).Value = ""
'            End If
'        End If



'        If e.KeyCode = Keys.PageDown Then
'            System.Diagnostics.Process.Start("C:\WINDOWS\system32\calc.exe")
'        End If

'        If e.KeyCode = Keys.Escape Then
'            Me.TX_UPC.Text = ""
'            cancelacion = False
'            busqueda.Visible = False
'            l_cancelacion.Visible = False
'            buscararticulo = False
'            If fp_articulos.ActiveSheet.RowCount = 0 Then
'                Me.txt_tipoventa.Enabled = True
'                TxtControl.Text = "0"
'                LbClienteTicket.Text = "Cliente: Público en General"
'                Me.txt_tipoventa.Focus()
'                txt_tipoventa.SelectionStart = 0
'                txt_tipoventa.SelectionLength = txt_tipoventa.Text.Length
'                Exit Sub
'            End If

'        End If


'        If e.KeyCode = Keys.Enter And Not formaspago And TX_UPC.Text <> "" Then
'            ProcAgregaArticulo()
'        End If


'        If Not PERMISOVENDER Then
'            PERMISOVENDER = True
'            formaspago = False
'        End If

'        If e.KeyCode = Keys.Escape AndAlso formaspago Then
'            borrapagos()
'            SendKeys.Flush()
'        ElseIf e.KeyCode = Keys.Escape And Not formaspago Then
'            If Me.fp_articulos.ActiveSheet.RowCount = 0 And e.KeyCode = Keys.Escape Then
'                Me.txt_tipoventa.Focus()
'                Exit Sub
'            End If
'        End If

'        If e.KeyCode = Keys.F1 And Not formaspago Then
'            buscararticulo = True
'            Me.busqueda.Visible = True

'            ' buscar articulo //listo
'        End If
'        'cancelacion de artikulos
'        If e.KeyCode = Keys.F2 And Not formaspago Then
'            cancelacion = True
'            Me.l_cancelacion.Visible = True
'        End If

'        If e.KeyCode = Keys.F3 And Not kilos And Not formaspago Then  '  multiplicacion por cantidad //listo
'            F3Cantidad = True
'            TX_UPC.Enabled = False
'            Me.l_cantidad.Visible = True
'            tx_cantidad.Visible = True
'            tx_cantidad.Text = ""
'            tx_cantidad.Focus()

'        End If
'        If e.KeyCode = Keys.F4 And Not formaspago And totalote > 0 Then
'            'fin de venta           
'            grformapago.BringToFront()
'            grformapago.Top = (Me.Height / 2 - grformapago.Height / 2)
'            grformapago.Left = (Me.Width / 2 - grformapago.Width / 2)
'            grformapago.Visible = True


'            formaspago = True
'            If Banderita = True Then
'                errorcode = sndPlaySoundA("c:\WINDOWs\MEDIA\ringin.WAV", &H1)
'                Panel1.BringToFront()
'                Panel1.Top = (Me.Height / 2 - Panel1.Height / 2)
'                Panel1.Left = (Me.Width / 2 - Panel1.Width / 2)
'                Panel1.Visible = True
'                Label2.Visible = True
'                Label2.AutoSize = True
'                Label24.Visible = False
'                txt_cveenc.Focus()
'            End If
'        End If

'        'Modo Caja Virtual
'        If e.KeyCode = Keys.F6 AndAlso Not formaspago Then
'            'Activar Modo "Vender Caja Virtual"            
'            If VentaCajaVirtual Then
'                TX_UPC.BackColor = Color.White
'            Else
'                TX_UPC.BackColor = Color.Yellow
'            End If
'            VentaCajaVirtual = Not VentaCajaVirtual
'        End If
'        'para pago en efectivo
'        If e.KeyCode = Keys.F5 And formaspago Then
'            tx_cantidad.Text = ""
'            Me.LFORPAG.Visible = True
'            Me.LFORPAG.Text = "Efectivo"
'            tx_cantidad.Visible = True
'            fpago = 1
'            TX_UPC.Enabled = False
'            tx_cantidad.Focus()
'        End If

'        'para pago en vales
'        If e.KeyCode = Keys.F6 And formaspago Then
'            If False Then
'                Me.LFORPAG.Visible = True
'                Me.LFORPAG.Text = "Vales"
'                tx_cantidad.Text = ""
'                tx_cantidad.Visible = True
'                fpago = 2
'                TX_UPC.Enabled = False
'                tx_cantidad.Focus()
'            Else
'                MsgBox("Ya no aceptamos Vales de Despensa", vbExclamation, "Punto de Venta")

'            End If
'        End If

'        'pago chekes
'        If e.KeyCode = Keys.F7 And formaspago Then
'            Label18.Text = "Referencia:"
'            autorizame = True

'            Me.LFORPAG.Text = "Cheque"
'            Me.LFORPAG.Visible = True
'            tx_cantidad.Text = ""
'            banco.Visible = True
'            fpago = 3
'            TX_UPC.Enabled = False
'            Me.TXB_BANCO.Focus()
'        End If


'        'pago transferencias
'        If e.KeyCode = Keys.End And formaspago Then
'            Label18.Text = "TITULAR BANCO Y FOLIO"
'            autorizame = True

'            Me.LFORPAG.Text = "Transfer"
'            Me.LFORPAG.Visible = True
'            tx_cantidad.Text = ""
'            banco.Visible = True
'            fpago = 7
'            TX_UPC.Enabled = False
'            Me.TXB_BANCO.Focus()
'        End If

'        'pago credito
'        If e.KeyCode = Keys.F8 And formaspago Then
'            Me.LFORPAG.Text = "Crédito"
'            Me.LFORPAG.Visible = True
'            tx_cantidad.Text = ""
'            txb_credito.Text = ""
'            txb_credito1.Text = ""
'            credito.Visible = True
'            fpago = 4
'            TX_UPC.Enabled = False
'            txb_credito.Focus()
'            pagare = True
'            autorizame = True

'        End If

'        If e.KeyCode = Keys.F9 And formaspago Then
'            If Round((totalote - totalpagos) * IIf(TIPOVENTA > 1, 1.02, 1), 2) > 0 Then
'                autorizame = True
'                TX_UPC.Enabled = False
'                'If TIPOVENTA > 1 Then
'                '    DistribuyeComConP1(Round((totalote - totalpagos) * 0.02, 2))
'                'End If

'                PanelSeleccionTarjetas.Left = Me.Width / 2 - PanelSeleccionTarjetas.Width / 2
'                PanelSeleccionTarjetas.Top = Me.Height / 2 - PanelSeleccionTarjetas.Height / 2
'                rbTCredito.Checked = False
'                rbTDebito.Checked = False
'                TipoTarj = ""
'                lbFila.Text = FP_FORMASPAGO.ActiveSheet.Rows.Count
'                PanelSeleccionTarjetas.Visible = True
'                PanelSeleccionTarjetas.BringToFront()
'                rbTDebito.Focus()
'            Else
'                MsgBox("El Monto pagado hasta el momento ya salda el ticket.", vbExclamation, "Monto Incorrecto")
'                LFORPAG.Visible = False
'                tx_cantidad.Text = ""
'                tx_cantidad.Visible = False
'                TXB_BANCO.Text = ""
'                TX_UPC.Enabled = True
'                TX_UPC.Text = ""
'                TX_UPC.Focus()
'            End If
'        End If




'        'If e.KeyCode = Keys.F9 And formaspago Then
'        '    Label18.Text = "Folio:"
'        '    autorizame = True
'        '    Me.LFORPAG.Text = "Devolucion"
'        '    Me.LFORPAG.Visible = True
'        '    tx_cantidad.Text = ""
'        '    banco.Visible = True
'        '    fpago = 5
'        '    Me.TXB_BANCO.Focus()
'        'End If
'        'para fin de pago y emision de cambio y ticket

'        If e.KeyCode = Keys.F10 And formaspago Then
'            If Math.Round(totalote, 2) > Math.Round(totalpagos, 2) Then
'                MsgBox("Cantidad de pago incorrecto", MsgBoxStyle.Critical)
'                SendKeys.Flush()
'                Me.TX_UPC.Focus()
'            Else

'                '            formaspago = False
'                Me.autorizame = autorizacodigo()

'                If Me.autorizame Then
'                    autor = New Autorizacion(Me.xCon, Me)
'                    autor.Top = (Me.Height / 2 - autor.Height / 2)
'                    autor.Left = (Me.Width / 2 - autor.Width / 2) - PanelCancelaciones.Width

'                    PanelCancelaciones.Visible = True
'                    PanelCancelaciones.BringToFront()
'                    autor.BringToFront()
'                    PanelCancelaciones.Top = (Me.Height / 2 - autor.Height / 2)
'                    PanelCancelaciones.Left = autor.Left + autor.Width
'                    autor.ShowDialog()
'                    PanelCancelaciones.Visible = False
'                    '    SendKeys.Flush()
'                    ''Exit Sub
'                End If

'                If Me.autorizame = False Then
'                    ''Else                   

'                    forma = New FrCambio(Me)
'                    forma.Top = (Me.Height / 2 - forma.Height / 2)
'                    forma.Left = 0
'                    forma.BringToFront()
'                    forma.ShowDialog()
'                    'forma.Show()
'                    SendKeys.Flush()
'                    datostel = False
'                    txt_ctel1.Text = ""
'                    txt_ctel2.Text = ""
'                    txt_ctel3.Text = ""
'                    txt_ctel4.Text = ""

'                    txt_tel1.Text = ""
'                    txt_tel2.Text = ""
'                    txt_tel3.Text = ""
'                    txt_tel4.Text = ""
'                    estiempoaire = False
'                    claveprod = ""

'                    'MsgBox("casi termino", MsgBoxStyle.Exclamation)
'                    sql2 = "select id, articulo,fechaini, descoferta, fechafin from ecboletinofer where ETIQCAMB=1 AND fechafin<'" & Format(Today, "yyyyMMdd") & "'"
'                    Base.daQuery(sql2, xCon, dsc, "tabla23")

'                    If dsc.Tables("tabla23").Rows.Count > 0 Then
'                        panelofe.BringToFront()
'                        panelofe.Top = (Me.Height / 2 - panelofe.Height / 2)
'                        panelofe.Left = (Me.Width / 2 - panelofe.Width / 2)
'                        panelofe.Visible = True
'                        LbIDOferta.Text = dsc.Tables("tabla23").Rows(i)("ID")
'                        '   MsgBox("casi termino  adasdas", MsgBoxStyle.Exclamation)
'                        txt_panelofe.Text = ""
'                        For i = 0 To dsc.Tables("tabla23").Rows.Count - 1
'                            txtnotifica.Text = txtnotifica.Text & " " & dsc.Tables("tabla23").Rows(i)("DescOferta") & " vencida desde " & dsc.Tables("tabla23").Rows(i)("fechafin")
'                        Next
'                        dsc.Tables.Remove("TABLA23")
'                        txt_panelofe.Focus()
'                    Else
'                        dsc.Tables.Remove("TABLA23")
'                        Me.txt_tipoventa.Focus()
'                    End If
'                    'Exit Sub
'                End If

'            End If

'        End If

'        ''End If


'        If e.KeyCode = Keys.F11 Then
'            'forma = New FrRegreso(xCon)
'            forma = New Devoluciones(xCon)
'            forma.BringToFront()
'            forma.ShowDialog()
'            SendKeys.Flush()
'            Exit Sub
'        End If


'        If e.KeyCode = Keys.F12 Then
'            Dim xforma As New Form
'            xforma = New parafacturar(xCon, Me)
'            xforma.BringToFront()
'            xforma.ShowDialog()
'            Me.Close()



'            'forma = New TICKETS(xCon, Me)
'            'forma.Top = (Me.Height / 2 - forma.Height / 2)
'            'forma.Left = (Me.Width / 2 - forma.Width / 2)
'            'forma.BringToFront()
'            'forma.ShowDialog()
'            'SendKeys.Flush()
'            'Exit Sub
'        End If
'        Label11.Text = "Fecha: " & Today.Day & " de " & MonthName(Today.Month) & " del " & Today.Year & " | Hora: " & Now.ToShortTimeString & " |"
'        'Label12.Text = "Hora: " & DateTime.Now.Hour.ToString & ":" & Mid("00" & DateTime.Now.Minute.ToString, 2, 2) & ":00"

'    End Sub

'    Private Function RecorreSpread(UPCUPC As String, cantidad As Double, CancelandoConF3 As Boolean)
'        Dim totpzas As Double
'        Dim Entre As Boolean

'        Entre = False
'        totpzas = 0
'        For recorre As Integer = 0 To fp_articulos.ActiveSheet.RowCount - IIf(CancelandoConF3, 2, 1)
'            If fp_articulos.ActiveSheet.Cells(recorre, ColVenta.ColUPCInv).Text.Trim = UPCUPC Then
'                totpzas += CDbl(fp_articulos.ActiveSheet.Cells(recorre, ColVenta.ColCantidad).Value)
'                Entre = True
'            End If
'        Next


'        'If (totpzas - IIf(CancelandoConF3, Abs(cantidad), Abs(cantidad))) >= 0 And Entre Then

'        If (totpzas - Abs(cantidad)) >= 0 AndAlso Entre Then
'            RecorreSpread = True
'        Else
'            If CancelandoConF3 Or Entre Then
'                MsgBox("La cantidad a cancelar no puede ser mayor a lo ya registrado en la venta.", vbExclamation, "Cancelar")
'            Else
'                MsgBox("No puede cancelar productos que no estén registrados en la venta.", vbExclamation, "Cancelar")
'            End If

'            RecorreSpread = False
'        End If
'    End Function

'    Private Function dafecha(ByVal fecha As Date) As String
'        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) &
'                    IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
'    End Function
'    Private Sub tx_cantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tx_cantidad.KeyDown
'        Dim formaspag As String
'        Dim tercera As String

'        Dim SQL As String
'        Dim DSC As New DataSet
'        Dim CantidadAnteriorF3 As Double
'        Dim RENGLON As Integer
'        Dim I As Integer
'        Dim VECES As Integer
'        Dim J As Integer
'        Dim SIGNO(5) As String
'        Dim TXVALOR(5) As String
'        Dim Cantidad As Double

'        tercera = ""
'        If e.KeyCode = Keys.Enter Then
'            If formaspago Then
'                Select Case fpago
'                    Case 1
'                        formaspag = "Efectivo"
'                    Case 2
'                        formaspag = "Vales"
'                    Case 3
'                        formaspag = "Cheque"
'                    Case 4
'                        formaspag = "Credito"
'                    Case 6
'                        formaspag = "Tarjeta"
'                    Case 7
'                        formaspag = "Transfer"
'                    Case Else
'                        formaspag = "Devolucion"
'                End Select


'                If IsNumeric(tx_cantidad.Text) Then
'                    If (tx_cantidad.TextLength) < 11 Then
'                        If fpago = 2 OrElse fpago = 3 OrElse fpago = 4 OrElse fpago = 6 OrElse fpago = 7 Then
'                            Dim TotalPagosEsp As Double = 0
'                            Dim TotalEfectivo As Double = 0
'                            Dim ComTmp As Double
'                            If TIPOVENTA > 1 Then
'                                ComTmp = AlcanzaComision(CDbl(tx_cantidad.Text) / 1.02 * 0.02, True)
'                            Else
'                                ComTmp = 0
'                            End If


'                            For RenPago As Integer = 0 To FP_FORMASPAGO.ActiveSheet.RowCount - 1
'                                If FP_FORMASPAGO.ActiveSheet.Cells(RenPago, 0).Text = "Vales" OrElse FP_FORMASPAGO.ActiveSheet.Cells(RenPago, 0).Text = "Cheque" OrElse
'                                        FP_FORMASPAGO.ActiveSheet.Cells(RenPago, 0).Text = "Credito" OrElse FP_FORMASPAGO.ActiveSheet.Cells(RenPago, 0).Text = "Tarjeta" OrElse FP_FORMASPAGO.ActiveSheet.Cells(RenPago, 0).Text = "Transfer" Then
'                                    TotalPagosEsp += FP_FORMASPAGO.ActiveSheet.Cells(RenPago, 1).Value
'                                Else
'                                    TotalEfectivo += FP_FORMASPAGO.ActiveSheet.Cells(RenPago, 1).Value
'                                End If
'                            Next

'                            'If TotalPagosEsp + CDbl(tx_cantidad.Text) > (Math.Round(totalote * IIf((TIPOVENTA = 2 Or TIPOVENTA = 3), 1.02, 1), 2)) Then
'                            If Math.Round(TotalPagosEsp + (CDbl(tx_cantidad.Text) - ComTmp - TotalComision), 2) > totalote Then

'                                MsgBox("Con Formas de Pago distintas al efectivo, la cantidad máxima a pagar es el monto del ticket.", vbExclamation, "Monto Incorrecto")
'                                LFORPAG.Visible = False
'                                tx_cantidad.Text = ""
'                                tx_cantidad.Visible = False
'                                TXB_BANCO.Text = ""
'                                TX_UPC.Enabled = True
'                                TX_UPC.Text = ""
'                                TX_UPC.Focus()

'                                Exit Sub
'                            End If
'                        End If

'                        If Me.TXB_BANCO.Text = "" Then
'                            If fpago = 6 Or fpago = 7 Or fpago = 3 Then
'                                MsgBox("Ingrese Referencia Bancaria del Pago", vbExclamation, "Referencia Bancaria")
'                                TXB_BANCO.Focus()
'                                Exit Sub
'                            End If
'                            '  tercera = Me.txb_credito.Text
'                        Else
'                            tercera = Me.TXB_BANCO.Text
'                        End If
'                        If CDbl(Me.tx_cantidad.Text) > acredito And fpago = 4 Then
'                            Dim forma As Form
'                            forma = New VENTANITA("Límite de crédito insuficiente.", "Crédito Inválido")
'                            forma.BringToFront()
'                            forma.ShowDialog()
'                            tx_cantidad.Text = ""
'                            tx_cantidad.Visible = False
'                            TX_UPC.Text = ""
'                            TX_UPC.Focus()

'                            Me.LFORPAG.Text = ""
'                            Exit Sub

'                        End If
'                        If CDbl(Me.tx_cantidad.Text) > (Math.Round(totalote, 2) - Math.Round(totalpagos, 2)) And fpago = 4 Then
'                            Dim forma As Form
'                            forma = New VENTANITA("La cantidad de crédito no puede ser mayor a la cantidad pendiente de pago.", "Crédito Inválido")
'                            forma.BringToFront()
'                            forma.ShowDialog()
'                            tx_cantidad.Text = ""
'                            tx_cantidad.Visible = False
'                            TX_UPC.Text = ""
'                            TX_UPC.Focus()

'                            Me.LFORPAG.Text = ""
'                            Exit Sub
'                        End If
'                        FP_FORMASPAGO.ActiveSheet.RowCount = FP_FORMASPAGO.ActiveSheet.RowCount + 1
'                        FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 0).Value = formaspag
'                        FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 1).Value = Val(tx_cantidad.Text) 'IIf(formaspag = "Tarjeta" And (TIPOVENTA = 2 Or TIPOVENTA = 3), Math.Round(CDbl(tx_cantidad.Text) / 1.02, 2), Math.Round(CDbl(tx_cantidad.Text), 2))
'                        FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 2).Value = tercera
'                        If FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 0).Value = "Vales" And (TIPOVENTA = 2 Or TIPOVENTA = 3) Then
'                            FP_FORMASPAGO.ActiveSheet.RowCount = FP_FORMASPAGO.ActiveSheet.RowCount + 1
'                            FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 0).Value = "Comision Vales"
'                            'FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 1).Value = Val(tx_cantidad.Text) * 0.03 * -1
'                            FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 1).Value = Format(Round((Val(tx_cantidad.Text) / 1.02) * 0.02 * -1, 2), "#####0.00") '0.020797 comision tarjeta
'                            DistribuyeComConP1(Round((Val(tx_cantidad.Text) / 1.02) * 0.02, 2))
'                        End If
'                        If TIPOVENTA = 1 AndAlso FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 0).Value = "Tarjeta" Then
'                            HayTarjeta = True
'                        Else
'                            HayTarjeta = False
'                        End If
'                        If TIPOVENTA > 1 AndAlso FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 0).Value = "Tarjeta" Then
'                            DistribuyeComConP1(Round((CDbl(tx_cantidad.Text) / 1.02) * 0.02, 2))
'                        End If
'                        FP_FORMASPAGO.ActiveSheet.Cells(FP_FORMASPAGO.ActiveSheet.RowCount - 1, 3).Value = TipoTarj
'                        Me.TXB_BANCO.Text = ""
'                        sumapagos()
'                        tx_cantidad.Text = ""
'                        tx_cantidad.Visible = False
'                        TX_UPC.Text = ""
'                        TX_UPC.Enabled = True
'                        TX_UPC.Focus()

'                        Me.LFORPAG.Text = ""
'                    Else
'                        MsgBox("Introduzca una cantidad menor, y/o que no sea código de barras.", vbExclamation, "Punto de Venta")
'                        tx_cantidad.Text = ""
'                        Me.tx_cantidad.Focus()
'                        Exit Sub
'                    End If
'                Else
'                    MsgBox("Introduzca un valor numérico.", vbExclamation, "Punto de Venta")
'                    tx_cantidad.Text = ""
'                    Me.tx_cantidad.Focus()
'                    Exit Sub
'                End If
'            Else
'                Try
'                    If (tx_cantidad.TextLength) < 20 Then
'                        Dim dataTable As New DataTable()
'                        Try
'                            Dim result As Object = dataTable.Compute(tx_cantidad.Text, "")
'                            Cantidad = Convert.ToDouble(result)
'                        Catch ex As Exception
'                            MsgBox("Ingrese operación matemática correcta.", vbExclamation, "Punto de Venta")
'                            tx_cantidad.Focus()
'                            Exit Sub
'                        End Try

'                        tx_cantidad.Text = Cantidad

'                        If Cantidad < 0 Then
'                            If Not RecorreSpread(fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColUPCInv).Value, Cantidad, True) Then
'                                tx_cantidad.Text = fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColCantidad).Value
'                                F3Cantidad = IIf(fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.RowCount - 1, ColVenta.ColF2).Value = 1, True, False)
'                            Else
'                                F3Cantidad = True
'                            End If
'                        Else
'                            F3Cantidad = True
'                        End If

'                        With fp_articulos.ActiveSheet
'                            LbTotal.Text = CDbl(LbTotal.Text) - CDbl(.Cells(.RowCount - 1, ColVenta.ColPrecio).Value)
'                            CantidadAnteriorF3 = .Cells(.RowCount - 1, ColVenta.ColCantidad).Value
'                            .Cells(.RowCount - 1, ColVenta.ColF3).Value = IIf(F3Cantidad, 1, 0)
'                            .Cells(.RowCount - 1, ColVenta.ColCantidad).Value = CDbl(tx_cantidad.Text)

'                            If CDbl(tx_cantidad.Text) = 0 Then
'                                '.Cells(.RowCount - 1, ColVenta.ColFIVA).Text = 
'                            End If

'                            .Cells(.RowCount - 1, ColVenta.ColTotal).Value = .Cells(.RowCount - 1, ColVenta.ColPrecio).Value * (CDbl(tx_cantidad.Text))

'                            SQL = "update tmpauxvta2 set cantidad=" & CDbl(tx_cantidad.Text) & ", FueConF3=" & IIf(F3Cantidad, 1, 0) & " where  " &
'                                        " usuario='" & Globales.caja & "' and renglon=" & .RowCount - 1

'                            Base.Ejecuta(SQL, xCon)

'                            RENGLON = .RowCount - 1

'                            SQL = "select isnull(tipo_ofer,0) Tipo_Ofer,art_clave, isnull(ECBOLETINOFER.ARTICULO,'') Articulo, upc_descripcion, Art_NomLargo, Art_CostoCap2, ART_FAMILIA, isnull(ECBOLETINOFER.DescOferta,'') DescOferta, isnull(CantidadDisponible,-1) CantidadDisponible, ISNULL(ECBOLETINOFER.Cantidad,0) Cantidad, isnull(PorcentajeDescuento,'') PorcentajeDescuento, isnull(ID,'') ID, isnull(Fam_Clave,'') Fam_Clave, isnull(ClaveMarca,-1) ClaveMarca, isnull(t2a.CantidadCobrados,-1) CobradosUPC ,isnull(t2c.CantidadCobrados,-1) CobradosClave," &
'                                    "isnull(ECBOLETINOFER.UPC_CodInv,'') UPCCodInvOferta, xupc.upc_codinv, ART_PRECIO1, isnull(XPRECIO1,art_precio1*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO1, ART_PRECIO2, isnull(XPRECIO2,art_precio2*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO2, ART_PRECIO3,isnull(XPRECIO3,art_precio3*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO3, " &
'                                    "isnull(art_kilo,0) ART_KILO ,ISNULL(art_entrega,0) ART_ENTREGA, art_topemay, art_iva, art_ieps, upc_upc from xupc inner join articulo on upc_cveart=art_Clave " &
'                                    "LEFT JOIN ECBOLETINOFER ON ((((ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv is null) or (ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv=XUPC.UPC_CODINV)) or ART_FAMILIA=Fam_Clave or art_marca=ClaveMarca) AND ((FECHAINI<='" & Format(Today, "yyyyMMdd") & "' AND FECHAFIN>='" & Format(Today, "yyyyMMdd") & "') or (CantidadDisponible>0 and Cantidad>0)) and Activo=1) " &
'                                    "left join (select ARTICULO, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by articulo) t2a on (t2a.ARTICULO=ECBOLETINOFER.UPC_CodInv and TIPO_OFER=1) " &
'                                    "left join (select ArtClave, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by ArtClave) t2c on (t2c.ArtClave=ECBOLETINOFER.ARTICULO and TIPO_OFER=2 ) " &
'                                    "where upc_upc = '" & fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value & "' " &
'                                    "order by XPRECIO1 asc, CantidadDisponible desc, UPCCodInvOferta desc"

'                            'OfertaTopeMay
'                            Base.daQuery(SQL, xCon, DSC, "articulo")
'                            If DSC.Tables("articulo").Rows.Count > 0 Then
'                                'validar la cantidad limitada
'                                Dim CantCob As Double = IIf(DSC.Tables("Articulo").Rows(0)("CobradosClave") <> -1, DSC.Tables("Articulo").Rows(0)("CobradosClave") + IIf(CDbl(tx_cantidad.Text) < 0, fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColCantidad).Value - CDbl(tx_cantidad.Text), 0), DSC.Tables("Articulo").Rows(0)("CobradosUPC") + IIf(CDbl(tx_cantidad.Text) < 0, fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColCantidad).Value - CDbl(tx_cantidad.Text), 0))
'                                If DSC.Tables("ARTICULO").Rows(0)("Articulo").ToString.Trim = "" AndAlso DSC.Tables("ARTICULO").Rows(0)("Fam_Clave").ToString.Trim = "" AndAlso DSC.Tables("ARTICULO").Rows(0)("ClaveMarca").ToString.Trim = "-1" Then 'Si no hay oferta
'                                    CONTROLPRECIOS(fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
'                                Else
'                                    If CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")) > 0 And CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")) > 0 And CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")) > 0 Then
'                                        If DSC.Tables("articulo").Rows(0)("Cantidad") > 0 Then 'Si oferta es por cantidad                                            
'                                            If (DSC.Tables("articulo").Rows(0)("CantidadDisponible") >= DSC.Tables("Articulo").Rows(0)("CobradosClave") + IIf(CDbl(tx_cantidad.Text) < 0, Math.Abs(CDbl(tx_cantidad.Text)), 0) And DSC.Tables("Articulo").Rows(0)("CobradosClave") <> -1) Or (DSC.Tables("articulo").Rows(0)("CantidadDisponible") >= DSC.Tables("Articulo").Rows(0)("CobradosUPC") + IIf(CDbl(tx_cantidad.Text) < 0, Math.Abs(CDbl(tx_cantidad.Text)), 0) And DSC.Tables("Articulo").Rows(0)("CobradosUPC") <> -1) Then
'                                                CONTROLPRECIOS(fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("art_precio1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("art_precio2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
'                                            Else
'                                                CONTROLPRECIOS(fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
'                                            End If
'                                        Else 'Cuando es por tiempo y sigue vigente
'                                            CONTROLPRECIOS(fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
'                                        End If
'                                    Else
'                                        CONTROLPRECIOS(fp_articulos.ActiveSheet.Cells(RENGLON, ColVenta.ColUPCInv).Value, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO2")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_PRECIO3")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), CDbl(tx_cantidad.Text), CantidadAnteriorF3, RENGLON, DSC.Tables("ARTICULO").Rows(0)("Art_Clave"), CantidadDisponible:=DSC.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO1")), PrecioOferta2:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO2")), PrecioOferta3:=CDbl(DSC.Tables("ARTICULO").Rows(0)("XPRECIO3")), CantidadCobradas:=CantCob, TipoOferta:=DSC.Tables("Articulo").Rows(0)("Tipo_Ofer"))
'                                    End If
'                                End If
'                            Else
'                                'SQL = "select upc_upc from xupc join articulo on art_clave=upc_cveart where upc_upc='" & fp_articulos.ActiveSheet.Cells(renglon, colventa.colupcinv).Value & "' and (upc_activo<>1 or art_activo<>1)"
'                                'Base.daQuery(SQL, xCon, DSC, "Activo")
'                                'If DSC.Tables("Activo").Rows.Count > 0 Then
'                                '    MsgBox("El artículo se encuentra inactivo.", MsgBoxStyle.Exclamation, "Punto de Venta")
'                                'Else
'                                '    TX_UPC.Enabled = False
'                                '    Panel1.BringToFront()
'                                '    Panel1.Top = (Me.Height / 2 - Panel1.Height / 2)
'                                '    Panel1.Left = (Me.Width / 2 - Panel1.Width / 2)
'                                '    Panel1.Visible = True
'                                '    txe.Visible = True
'                                '    Label24.Visible = True
'                                '    Label2.Visible = False
'                                '    Me.txe.Focus()
'                                'End If
'                                'DSC.Tables.Remove("Activo")
'                            End If
'                            DSC.Tables.Remove("ARTICULO")
'                        End With
'                        sumaSpread()
'                        tx_cantidad.Visible = False
'                        Me.l_cantidad.Visible = False
'                        Me.Lkilos.Visible = False

'                        TX_UPC.Enabled = True
'                        TX_UPC.Focus()
'                    Else
'                        MsgBox("Favor de Introducir un Numero Menor a 99999 y que no sea Codigo De Barras")
'                        Me.tx_cantidad.Focus()
'                    End If

'                Catch ex As Exception
'                    Dim errorcode As Integer
'                    errorcode = sndPlaySoundA("c:\WINDOWs\MEDIA\tada.WAV", &H1)
'                    MsgBox("yyyyyyyyFavor de Introducir un Numero Menor a 99999 y que no sea Codigo De Barras")
'                    Me.tx_cantidad.Focus()
'                End Try
'            End If
'        ElseIf e.KeyCode = Keys.Escape AndAlso formaspago Then
'            sumapagos()
'            banco.Visible = False
'            credito.Visible = False
'            LFORPAG.Text = ""
'            tx_cantidad.Text = ""
'            TXB_BANCO.Text = ""
'            TipoTarj = ""
'            tx_cantidad.Visible = False
'            TX_UPC.Enabled = True
'            TX_UPC.Text = ""
'            TX_UPC.Focus()
'        ElseIf e.KeyCode = Keys.Escape AndAlso Not formaspago Then
'            If Lkilos.Visible <> True Then
'                l_cantidad.Visible = False
'                tx_cantidad.Visible = False
'                tx_cantidad.Text = ""
'                TX_UPC.Enabled = True
'                TX_UPC.Text = ""
'                TX_UPC.Focus()
'            End If
'        End If
'    End Sub

'    'Private Sub DistribuyeCom(ByVal MontoComision As Double)
'    '    Dim TotalComisionTmp As Double = 0
'    '    If TotalComision <> 0 Then
'    '        TotalComisionTmp = TotalComision
'    '        QuitaComision()
'    '        TotalComision = TotalComisionTmp
'    '        MontoComision = MontoComision + TotalComisionTmp
'    '    End If


'    '    Exit Sub

'    '    Dim ComisionRen As Double = 0
'    '    For i As Integer = 0 To fp_articulos.ActiveSheet.RowCount - 1
'    '        ComisionRen = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / totalote * MontoComision
'    '        fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value + ComisionRen
'    '        If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value <> 0 Then
'    '            fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
'    '        End If

'    '        TotalComision = TotalComision + ComisionRen
'    '    Next
'    '    sumaSpread()
'    'End Sub

'    Private Sub DistribuyeComConP1(ByVal MontoComision As Double)
'        Dim UniversoArticulos As Double = 0
'        Dim MontoMaximoComisionLoc As Double = 0
'        Dim Articulos As New List(Of Integer)

'        Dim TotalComisionTmp As Double = 0
'        If TotalComision <> 0 Then
'            TotalComisionTmp = TotalComision
'            QuitaComision()
'            'TotalComision = TotalComisionTmp
'            MontoComision = Math.Round(MontoComision + TotalComisionTmp, 2)
'        End If

'        For i As Integer = 0 To fp_articulos.ActiveSheet.Rows.Count - 1
'            If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value > 0 AndAlso (fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value < fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value) Then
'                MontoMaximoComisionLoc += (fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value) - fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value
'                UniversoArticulos += fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value
'                Articulos.Add(i)
'            End If
'        Next

'        If MontoMaximoComisionLoc > 0 Then
'            If MontoComision > MontoMaximoComisionLoc Then
'                MontoComision = MontoMaximoComisionLoc
'            End If

'            Dim ComisionRen As Double = 0
'            Dim Entre As Boolean = False
'            Do Until Math.Round(TotalComision, 2) = Math.Round(MontoComision, 2)
'                For Each i As Integer In Articulos
'                    If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value <> 0 AndAlso TotalComision < MontoComision Then
'                        Entre = True
'                        ComisionRen = Math.Round(Math.Min(MontoComision - TotalComision, Math.Min(fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / UniversoArticulos * MontoComision, (fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * (fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value - fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value)))), 3)
'                        fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value + ComisionRen
'                        fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
'                        fp_articulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value += ComisionRen
'                        TotalComision = TotalComision + ComisionRen
'                    ElseIf MontoComision = TotalComision Then
'                        Exit For
'                    End If
'                Next
'            Loop

'        Else
'            Exit Sub
'        End If
'        sumaSpread()
'    End Sub

'    Private Function AlcanzaComision(ByVal MontoComision As Double, ByVal RecalcularQuitarComision As Boolean) As Double
'        Dim TotalComisionTmp As Double = 0
'        If RecalcularQuitarComision AndAlso TotalComision <> 0 Then
'            TotalComisionTmp = TotalComision
'            QuitaComision()
'            TotalComision = TotalComisionTmp
'            MontoComision = MontoComision + TotalComisionTmp
'        End If

'        Dim MontoMaximoComision As Double = 0
'        For i As Integer = 0 To fp_articulos.ActiveSheet.Rows.Count - 1
'            If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value > 0 AndAlso (fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value < fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value) Then
'                MontoMaximoComision += (fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value * fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value) - fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value
'            End If
'        Next

'        If MontoMaximoComision > 0 Then
'            If MontoComision > MontoMaximoComision Then
'                Return MontoMaximoComision
'            Else
'                Return MontoComision
'            End If
'        Else
'            'No hay candidatos
'            Return MontoMaximoComision
'        End If

'        Return MontoMaximoComision
'    End Function
'    Private Sub QuitaComision()
'        If TotalComision > 0 Then
'            Dim ComisionRen As Double = 0
'            For i As Integer = 0 To fp_articulos.ActiveSheet.RowCount - 1
'                If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value > 0 AndAlso fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value <> 0 Then
'                    ComisionRen = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value
'                    fp_articulos.ActiveSheet.Cells(i, ColVenta.ColComisionRen).Value = 0
'                    fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value - ComisionRen
'                    fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value = fp_articulos.ActiveSheet.Cells(i, ColVenta.ColTotal).Value / fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value
'                End If
'            Next
'            TotalComision = 0
'            sumaSpread()
'        End If
'    End Sub
'    Private Sub sumapagos()
'        Dim dTotal As Double = 0
'        Dim iRen As Integer = 0
'        Dim signo As Integer

'        With FP_FORMASPAGO.ActiveSheet
'            For iRen = 0 To .RowCount - 1
'                If .Cells(iRen, 0).Text = "Comision Vales" Or .Cells(iRen, 0).Text = "Comis Tar" Then
'                    signo = -1
'                Else
'                    signo = 1
'                End If
'                dTotal += .Cells(iRen, 1).Value * signo
'            Next
'        End With
'        ntx_totalpago.Text = dTotal
'        TX_TOTALPAGO.Text = Format(dTotal, "$#,###,##0.00")
'        totalpagos = dTotal
'        If totalote - dTotal <= 0 Then
'            lcambio.Text = "$0.00"
'            ' lcambio.Text = Format(dTotal - totalote, "$#,###,##0.00")
'        Else
'            lcambio.Text = Format(totalote - dTotal, "$#,###,##0.00")
'        End If

'    End Sub


'    Private Sub borrapagos()
'        FP_FORMASPAGO.ActiveSheet.RowCount = 0
'        lcambio.Text = "$0.00"
'        TXB_BANCO.Text = ""

'        tx_cantidad.Text = ""
'        tx_cantidad.Visible = False
'        LFORPAG.Visible = False

'        banco.Visible = False
'        credito.Visible = False
'        txb_credito.Text = ""
'        txb_credito1.Text = ""
'        formaspago = False
'        TX_TOTALPAGO.Text = ""
'        grformapago.Visible = False
'        TX_UPC.Text = ""
'        TX_UPC.Focus()
'        totalpagos = 0
'        QuitaComision()
'        HayTarjeta = False
'    End Sub


'    Private Sub TXB_BANCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXB_BANCO.KeyDown, TextBox1.KeyDown
'        If e.KeyCode = Keys.Enter Then

'            If TXB_BANCO.Text = "" Then
'            Else

'                banco.Visible = False
'                Me.tx_cantidad.Visible = True
'                Me.tx_cantidad.Focus()
'            End If
'        ElseIf e.KeyCode = Keys.Escape Then
'            TXB_BANCO.Text = ""
'            tx_cantidad.Text = ""
'            tx_cantidad.Visible = False
'            banco.Visible = False
'            LFORPAG.Text = ""
'            sumapagos()
'            TX_UPC.Enabled = True
'            TX_UPC.Focus()
'        End If
'    End Sub

'    Private Sub txb_credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txb_credito.KeyDown

'        If e.KeyCode = Keys.Enter Then
'            'Me.clientex = Me.txb_credito1.Text
'            Dim sql As String
'            Dim dsc As New DataSet
'            Dim saldo As String
'            Dim creditos As String
'            'If txb_credito.Text = "" Then
'            '    MsgBox("ingrese numero de cliente")
'            'Else

'            '    If txb_credito.Text.Substring(0, 1) = "F" Then
'            '        txb_credito.Text = txb_credito.Text.Substring(1, txb_credito.Text.Length - 1)
'            '    End If

'            Dim frmbuscar As New busqueda
'            frmbuscar.TXTCONTROL = Me.txt_foliopago
'            GENERAL.parametrosbusqueda(frmbuscar, "Clientes Registrados", "cli_clave,cli_nombre,dcli_saldo,dcli_limite-dcli_saldo as disponible,dcli_limite", "ecclientes inner join ecdetclienteemp on cli_clave=dcli_clave and dcli_empresa=1 ", "cli_nombre asc", "1", xCon, "Folio,Nombre,Saldo,Credito Disponible,Limite Credito", "50,200,80,100,100", "A,A,#,#,#", "2", "")
'            frmbuscar.Top = (Me.Height / 2 - frmbuscar.Height / 2)
'            frmbuscar.Left = (Me.Width / 2 - frmbuscar.Width / 2)
'            frmbuscar.BringToFront()
'            frmbuscar.ShowDialog()
'            frmbuscar.Dispose()
'            Me.txb_credito.Text = Me.txt_foliopago.Text


'            sql = "select cli_clave,dcli_Saldo,dcli_limite from ecclientes inner join ecdetclienteemp on cli_clave=dcli_clave and dcli_empresa=1  where ltrim(rtrim(cli_nombre))='" & LTrim(RTrim(txb_credito.Text)) & "'"
'            Base.daQuery(sql, xCon, dsc, "credito")
'            If dsc.Tables("credito").Rows.Count > 0 Then
'                creditos = dsc.Tables("credito").Rows(0)("dcli_limite")
'                saldo = dsc.Tables("credito").Rows(0)("dcli_saldo")
'                txb_credito1.Text = dsc.Tables("credito").Rows(0)("cli_clave")
'                Me.clientex = Me.txb_credito1.Text

'                acredito = Val(creditos) - Val(saldo)
'                If Val(creditos) - Val(saldo) > 0 Then
'                    credito.Visible = False
'                    Me.tx_cantidad.Visible = True
'                    Me.tx_cantidad.Focus()
'                Else
'                    MsgBox("Cliente sin saldo")
'                    Me.LFORPAG.Text = ""
'                    tx_cantidad.Text = ""
'                    credito.Visible = False
'                    Me.TX_UPC.Focus()
'                End If

'            Else
'                Me.txb_credito.Focus()
'            End If
'        ElseIf e.KeyCode = Keys.Escape Then
'            pagare = False
'            txb_credito.Text = ""
'            credito.Visible = False
'            LFORPAG.Text = ""
'            sumapagos()
'            TX_UPC.Enabled = True
'            TX_UPC.Focus()
'        End If
'        'End If

'    End Sub

'    Private Function autorizacodigo()
'        Dim i As Integer
'        Dim valido As Boolean
'        Dim StrPago As String
'        valido = False
'        StrPago = ""

'        If CInt(txt_tipoventa.Text.Trim) = 3 Then
'            valido = True
'            ListBox1.Items.Add("**Venta Tipo 3**")
'            ListBox1.Items.Add(" ")
'        End If

'        For i = 0 To FP_FORMASPAGO.ActiveSheet.RowCount - 1
'            Select Case FP_FORMASPAGO.ActiveSheet.Cells(i, 0).Value
'                Case "Transfer"
'                    StrPago = "   Pago con Transferencia"
'                Case "Cheque"
'                    StrPago = "   Pago con Cheque"
'                Case "Credito"
'                    StrPago = "   Pago con Crédito de Cliente"
'                Case Else
'                    StrPago = ""
'            End Select

'            If StrPago <> "" Then
'                If ListBox1.Items.Count = 0 Then
'                    ListBox1.Items.Add("**Autorizaciones Por Método de Pago**")
'                End If
'                ListBox1.Items.Add(StrPago)
'                valido = True
'            End If
'            'Exit For
'        Next

'        'If Not valido Then
'        Dim Entre As Boolean
'        Entre = False
'        For i = 0 To fp_articulos.ActiveSheet.RowCount - 1
'            If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value <= 0 Then
'                If ListBox1.Items.Count = 0 Then
'                    ListBox1.Items.Add("**Autorizaciones Por Cancelaciones de Artículos**")
'                Else
'                    If Not Entre Then
'                        ListBox1.Items.Add(" ")
'                        ListBox1.Items.Add("**Autorizaciones Por Cancelaciones de Artículos**")
'                        Entre = True
'                    End If
'                End If
'                If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value = 0 Then
'                    ListBox1.Items.Add("   Cancela en 0 " & fp_articulos.ActiveSheet.Cells(i, ColVenta.ColDescripcion).Value)
'                Else
'                    ListBox1.Items.Add("   Cancela " & Math.Abs(fp_articulos.ActiveSheet.Cells(i, ColVenta.ColCantidad).Value) & " " & fp_articulos.ActiveSheet.Cells(i, ColVenta.ColDescripcion).Value)
'                End If

'                valido = True
'                'Exit For
'            End If
'        Next

'        'End If
'        autorizacodigo = valido
'    End Function



'    Private Sub txt_tipoventa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_tipoventa.KeyDown
'        If e.KeyCode = Keys.Enter Then

'            If ValidaTipoVenta() Then
'                'TxtControl.Text = 0
'                'LbClienteTicket.Text = "Cliente: Público en General"
'                Dim ClienteOrig As Integer = CInt(TxtControl.Text)
'                Dim ClienteOrigStr As String = LbClienteTicket.Text

'                Select Case txt_tipoventa.Text
'                    Case "1"
'                        TIPOVENTA = 1
'                    Case "2"
'                        TIPOVENTA = 2
'                    Case "3"
'                        TIPOVENTA = 3
'                        Dim frmbuscar As New busqueda
'                        frmbuscar.TXTCONTROL = Me.txt_foliopago

'                        GENERAL.parametrosbusqueda(frmbuscar, "Precio Duarsa - Clientes Registrados", "cli_clave,cli_nombre", "ecclientes", "cli_nombre asc", "1", xCon, "Clave,Nombre", "50,200", "A,A", "1,2", "precioduarsa=1")
'                        frmbuscar.TXTCONTROL = TxtControl
'                        frmbuscar.Top = (Me.Height / 2 - frmbuscar.Height / 2)
'                        frmbuscar.Left = (Me.Width / 2 - frmbuscar.Width / 2)
'                        frmbuscar.BringToFront()
'                        frmbuscar.ShowDialog()
'                        frmbuscar.Dispose()
'                        If TxtControl.Text = "" Then
'                            TxtControl.Text = ClienteOrig
'                            LbClienteTicket.Text = ClienteOrigStr
'                            Exit Sub
'                        Else
'                            Dim TmpStr() As String = TxtControl.Text.Trim.Split(",")
'                            TxtControl.Text = CInt(TmpStr(0).Trim)
'                            LbClienteTicket.Text = "Cliente: " & TmpStr(1).Trim
'                        End If
'                    Case Else

'                        MsgBox("Tipo de Venta Inválida.", vbExclamation, "Punto de Venta")
'                        txt_tipoventa.Enabled = True
'                        txt_tipoventa.Text = "1"
'                        txt_tipoventa.Focus()
'                        Exit Sub
'                End Select
'                txt_tipoventa.Enabled = False
'                Me.TX_UPC.Focus()
'            End If

'            '  limpiaSpread()
'        ElseIf e.KeyCode = Keys.F2 Then
'            Dim frmbuscar As New busqueda

'            frmbuscar.TXTCONTROL = TxtControl
'            GENERAL.parametrosbusqueda(frmbuscar, "Cotizaciones Registradas", "cot_id,convert(varchar, cot_fechacaptura, 103),cot_cliente,cot_total", "eccotizaciones", "cot_id desc", "0", xCon, "Folio,Fecha,Cliente,Total", "50,80,150,80", "A,A,A,$", "1", "", "cot_id;convert(varchar, cot_fechacaptura, 103);cot_cliente;cot_total")
'            frmbuscar.TXTCONTROL = TxtControl
'            frmbuscar.Top = (Me.Height / 2 - frmbuscar.Height / 2)
'            frmbuscar.Left = (Me.Width / 2 - frmbuscar.Width / 2)
'            frmbuscar.BringToFront()
'            frmbuscar.ShowDialog()
'            frmbuscar.Dispose()
'            If TxtControl.Text <> "" Then
'                Dim SQL As String
'                Dim DSC As New DataSet
'                SQL = "delete from tmpauxvta2 where usuario='" & Globales.caja & "'"
'                Base.Ejecuta(SQL, xCon)
'                SQL = "insert into tmpauxvta2 select dcot_renglon-1 renglon,'" & Globales.caja & "' as usuario,dcot_articulo articulo, dcot_cantidad*dcot_cap1*dcot_cap2 cantidad, tipo,1 FueConF1,0 FueConF2,0 FueConF3,ClienteID,art_clave ArtClave,'' TraeVale from ecdetcotiza join eccotizaciones on dcot_compra=cot_id join xupc on upc_upc=dcot_articulo join articulo on upc_cveart=art_clave where dcot_articulo<>'' and dcot_compra=" & TxtControl.Text
'                Base.Ejecuta(SQL, xCon)

'                SQL = "select Tipo,ClienteID,CLI_NOMBRE From eccotizaciones t join ecclientes on t.clienteid=CLI_CLAVE where cot_id=" & TxtControl.Text
'                Base.daQuery(SQL, xCon, DSC, "Cli")
'                If DSC.Tables("Cli").Rows.Count > 0 Then
'                    TxtControl.Text = DSC.Tables("Cli").Rows(0)("ClienteID")
'                    LbClienteTicket.Text = "Cliente: " & DSC.Tables("Cli").Rows(0)("Cli_Nombre").trim
'                    txt_tipoventa.Text = DSC.Tables("Cli").Rows(0)("tipo")
'                    TIPOVENTA = DSC.Tables("Cli").Rows(0)("tipo")
'                    txt_tipoventa.Enabled = False

'                    SQL = "select*from tmpauxvta2 where usuario ='" & Globales.caja & "' order by renglon asc"
'                    Base.daQuery(SQL, xCon, DSC, "Ticket")
'                    For i = 0 To DSC.Tables("Ticket").Rows.Count - 1
'                        TX_UPC.Text = DSC.Tables("Ticket").Rows(i)("articulo").ToString.Trim
'                        ProcAgregaArticulo(True, DSC.Tables("Ticket").Rows(i)("Cantidad"), DSC.Tables("Ticket").Rows(i)("FueConF1"), DSC.Tables("Ticket").Rows(i)("FueConF2"), DSC.Tables("Ticket").Rows(i)("FueConF3"), DSC.Tables("Ticket").Rows(i)("TraeVale"))
'                    Next
'                    DSC.Tables.Remove("Ticket")
'                    Me.TX_UPC.Focus()
'                End If
'                DSC.Tables.Remove("Cli")
'            End If
'        ElseIf e.KeyCode = Keys.F1 Then
'            If txt_tipoventa.Text = "" OrElse Not IsNumeric(txt_tipoventa.Text) OrElse CDbl(txt_tipoventa.Text) < 1 OrElse CDbl(txt_tipoventa.Text) > 3 Then
'                txt_tipoventa.Text = 1
'            End If
'            If TxtControl.Text = "" OrElse Not IsNumeric(TxtControl.Text) OrElse CDbl(TxtControl.Text) < 1 Then
'                TxtControl.Text = 0
'            End If

'            CambiaCliente(TxtControl.Text, LbClienteTicket.Text, RequiereAutorizacion:=False)
'        ElseIf e.KeyCode = Keys.Escape Then
'            LbClienteTicket.Text = "Cliente: Público en General"
'            TxtControl.Text = 0
'            TIPOVENTA = 1
'            txt_tipoventa.Text = 1
'        End If
'    End Sub

'    Private Sub txt_tipoventa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tipoventa.LostFocus
'        txt_tipoventa.Focus()
'    End Sub

'    Private Function ValidaTipoVenta() As Boolean

'        If txt_tipoventa.Text <> "" Then
'            If Not IsNumeric(txt_tipoventa.Text.Trim) OrElse (CDbl(txt_tipoventa.Text) < 1 OrElse CDbl(txt_tipoventa.Text) > 3) Then
'                MsgBox("Tipo de Venta Inválido, indique un tipo de venta correcto.", MsgBoxStyle.Exclamation)
'                Me.txt_tipoventa.Text = 1
'                Me.txt_tipoventa.Focus()
'                txt_tipoventa.SelectAll()
'                Return False
'            Else
'                txt_tipoventa.Focus()
'            End If
'        Else
'            Me.txt_tipoventa.Focus()
'            Return False
'        End If
'        Return True
'    End Function

'    Private Sub fp_articulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fp_articulos.Click

'    End Sub

'    Private Sub TX_UPC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TX_UPC.TextChanged

'    End Sub

'    Private Sub txt_tipoventa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tipoventa.GotFocus
'        If fp_articulos.ActiveSheet.RowCount >= 1 Then
'            MsgBox("No se modificar el tipo de venta. Ya existen articulos en la lista", MsgBoxStyle.Exclamation)
'            Me.TX_UPC.Focus()
'        End If
'    End Sub

'    Private Sub txt_cveenc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cveenc.KeyDown
'        Dim sSql As String
'        Dim dsc As New DataSet


'        If e.KeyCode = Keys.Enter Then
'            Dim i As Integer

'            For i = 1 To Len(LTrim(RTrim(Me.txt_cveenc.Text)))
'                If IsNumeric(Mid(txt_cveenc.Text, i, 1)) Then
'                    Exit For
'                End If
'            Next
'            txt_cveenc.Text = Mid(txt_cveenc.Text, i, Len(txt_cveenc.Text) - i + 1)

'            sSql = "select * FROM ecusuariosx where emp_password='" & Me.txt_cveenc.Text & "'"
'            Base.daQuery(sSql, xCon, dsc, "empleado")
'            If dsc.Tables("empleado").Rows.Count > 0 Then
'                If dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim = "Controlc" Then
'                    '********************************************************************************
'                    sSql = "Insert into ecerrores (err_fecha,err_descripcion) values ('" & dafecha(Now.Date) &
' "','" & txe.Text.Trim & "')"
'                    Base.Ejecuta(sSql, xCon)
'                    '********************************************************************************


'                    txe.Text = ""
'                    txt_cveenc.Text = ""
'                    Panel1.Visible = False
'                    TX_UPC.Text = ""
'                    TX_UPC.Enabled = True
'                    SendKeys.Flush()
'                    TX_UPC.Focus()
'                Else
'                    txt_cveenc.Text = ""
'                    txt_cveenc.Focus()
'                End If
'            End If
'            dsc.Tables.Remove("empleado")
'        End If
'    End Sub

'    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        Dim sSql As String
'        Dim dsc As New DataSet

'        Dim i As Integer

'        For i = 1 To Len(LTrim(RTrim(Me.txt_cveenc.Text)))
'            If IsNumeric(Mid(txt_cveenc.Text, i, 1)) Then
'                Exit For
'            End If
'        Next
'        txt_cveenc.Text = Mid(txt_cveenc.Text, i, Len(txt_cveenc.Text) - i + 1)


'        sSql = "select * FROM ecusuariosx where emp_password='" & Me.txt_cveenc.Text & "'"
'        Base.daQuery(sSql, xCon, dsc, "empleado")
'        If dsc.Tables("empleado").Rows.Count > 0 Then
'            If dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim = "Supervisor" Then
'                txt_cveenc.Text = ""
'                Panel1.BringToFront()
'                Panel1.Top = (Me.Height / 2 - Panel1.Height / 2)
'                Panel1.Left = (Me.Width / 2 - Panel1.Width / 2)
'                Panel1.Visible = True
'                TX_UPC.Text = ""
'                TX_UPC.Enabled = True
'                SendKeys.Flush()
'                TX_UPC.Focus()
'            Else
'                txt_cveenc.Text = ""
'                txt_cveenc.Focus()
'            End If
'        End If
'        dsc.Tables.Remove("empleado")
'        band = True
'    End Sub

'    Private Sub txt_cveenc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cveenc.TextChanged

'    End Sub

'    Private Sub FrVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
'        If Keys.Alt = e.KeyCode Then
'            SendKeys.Send(Keys.Shift)
'        End If
'    End Sub

'    Private Sub FrVenta_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

'        If cerrar = 1 Then
'            e.Cancel = True
'        End If
'    End Sub



'    Private Sub fp_articulos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fp_articulos.KeyDown
'        If fp_articulos.ActiveSheet.RowCount > 0 Then
'            If e.KeyCode = (Keys.F1) Then
'                If fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.ActiveRowIndex, ColVenta.ColCantidad).Value > 0 Then
'                    If fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = "*" Then
'                        MsgBox("Se Registro el Artículo como entregado en caja", MsgBoxStyle.Information)
'                        fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = ""
'                    Else
'                        MsgBox("Se Registro el Artículo para entrega de Producto", MsgBoxStyle.Information)
'                        fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = "*"
'                    End If
'                    Dim SQL As String
'                    SQL = "update TMPAUXVTA2 set TraeVale='" & fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value & "' where usuario='" & Globales.caja & "' and Renglon=" & fp_articulos.ActiveSheet.ActiveRowIndex
'                    Try
'                        Base.Ejecuta(Sql, xCon)
'                    Catch ex As Exception
'                        MsgBox("Error al actualizar Vale en TmpAuxVta2." & Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Punto de Venta")
'                    End Try
'                    segundoticket = True
'                    TX_UPC.Focus()
'                Else
'                    fp_articulos.ActiveSheet.Cells(fp_articulos.ActiveSheet.ActiveRowIndex, ColVenta.ColVale).Value = ""
'                End If
'                fp_articulos.ActiveSheet.ActiveRowIndex = fp_articulos.ActiveSheet.RowCount - 1
'                TX_UPC.Focus()
'            End If
'        End If
'    End Sub

'    Private Sub BTN_NUEVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_NUEVO.Click
'        ActualizaOferta()
'    End Sub


'    Private Sub ActualizaOferta()
'        Dim dsc As New DataSet
'        Dim SQL As String
'        If txt_panelofe.Text <> "" Then
'            SQL = "select * from ecusuariosx where emp_tipo='Supervisor' and emp_password='" & txt_panelofe.Text & "'"
'            Base.daQuery(SQL, xCon, dsc, "Autoriza")
'            If dsc.Tables("Autoriza").Rows.Count > 0 Then
'                If MsgBox("¿Ya retiró todas las etiquetas de la oferta expirada?", vbYesNo, "Oferta Expirada") = MsgBoxResult.Yes Then
'                    Base.Ejecuta("update ecboletinofer set EtiqCamb=0, Activo=0, Supervisor='" & dsc.Tables("Autoriza").Rows(0)("emp_nombre") & "' where ID=" & CInt(LbIDOferta.Text), xCon)
'                    MsgBox("Oferta desactivada correctamente.", vbInformation, "Oferta Expirada")
'                End If
'                panelofe.Visible = False
'            Else
'                MsgBox("Password Incorrecto.", vbExclamation, "Oferta Expirada")
'                txt_panelofe.Text = ""
'                txt_panelofe.Focus()
'            End If
'            dsc.Tables.Remove("Autoriza")
'        Else
'            MsgBox("Ingrese código de supervisor.", vbInformation, "Oferta Expirada")
'            txt_panelofe.Focus()
'        End If
'    End Sub

'    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
'        Dim valido As Boolean
'        Dim DSC As New DataSet
'        Dim SQL As String
'        valido = False

'        If (txt_ctel1.Text = txt_tel1.Text) Then

'            'If (txt_ctel1.Text = txt_tel1.Text) And Len(txt_ctel1.Text) = 3 Then
'            '    If (txt_ctel2.Text = txt_tel2.Text) And Len(txt_ctel2.Text) = 3 Then
'            '        If (txt_ctel3.Text = txt_tel3.Text) And Len(txt_ctel3.Text) = 2 Then
'            '            If (txt_ctel4.Text = txt_tel4.Text) And Len(txt_ctel4.Text) = 2 Then
'            valido = True
'            '            End If
'            '        End If
'            '    End If
'        End If

'        If Not valido Then
'            MsgBox("Los datos del número de teléfono son inválidos, corrija ", MsgBoxStyle.Exclamation)
'            txt_ctel1.Text = ""
'            txt_ctel2.Text = ""
'            txt_ctel3.Text = ""
'            txt_ctel4.Text = ""
'            txt_tel1.Text = ""
'            txt_tel2.Text = ""
'            txt_tel3.Text = ""
'            txt_tel4.Text = ""
'        Else

'            datostel = True
'            If TIEMPOCOMIS Then
'                SQL = "SELECT * FROM XUPC INNER JOIN ARTICULO ON ART_CLAVE=UPC_CVEART WHERE UPC_UPC='980012356'"
'                Base.daQuery(SQL, xCon, DSC, "ARTICULO")

'                If DSC.Tables("articulo").Rows.Count > 0 Then

'                    With fp_articulos.ActiveSheet
'                        .AddRows(.RowCount, 1)
'                        .Rows(.RowCount - 1).Height = 30
'                        'agregaArticulo(DSC.Tables("articulo").Rows(0)("upc_upc"), DSC.Tables("articulo").Rows(0)("art_clave"), DSC.Tables("articulo").Rows(0)("art_nomlargo"), CDbl(DSC.Tables("articulo").Rows(0)("ART_PRECIO1")), CDbl(DSC.Tables("articulo").Rows(0)("ART_PRECIO1")), .RowCount - 1, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_TOPEMAY")), 0, 1, CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_IVA")), CDbl(DSC.Tables("ARTICULO").Rows(0)("ART_IEPS")))
'                    End With
'                End If

'                DSC.Tables.Remove("ARTICULO")
'            End If
'            Paneltiempo.Visible = False
'            TX_UPC.Focus()

'        End If

'    End Sub


'    Private Sub txt_ctel4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ctel4.KeyDown
'        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
'            Button3.Focus()
'        End If
'    End Sub

'    Private Sub txt_ctel4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ctel4.KeyDown
'        If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
'            Button3.Focus()
'        End If

'    End Sub

'    Private Sub panelofe_Paint(sender As Object, e As PaintEventArgs) Handles panelofe.Paint

'    End Sub

'    Private Sub ProcAgregaArticulo(ByVal Optional CargandoPendiente As Boolean = False, ByVal Optional CantPend As Double = 1, ByVal Optional PendFueConF1 As Integer = False, ByVal Optional PendFueConF2 As Integer = False, ByVal Optional PendFueConF3 As Integer = False, Optional PendTraeVale As String = "")
'        Dim i As Integer

'        'Dim forma As Form
'        'Dim autor As Form
'        Dim TOPE As Double
'        ''Dim cve As String
'        Dim UPCUPC As String
'        Dim ArtClave As String
'        Dim ArtNomLargo As String
'        Dim CostoCap As Double
'        Dim Familia As String
'        Dim nomlargo As String
'        Dim Precio1, Precio2, Precio3 As Double
'        Dim sql As String = ""
'        Dim dsc As New DataSet
'        'Dim recorre As Integer
'        'Dim banderola As Integer
'        Dim k As Integer
'        Dim ANTERIOR As Double
'        Dim xtipo As Integer
'        Dim cantidad As Double
'        Dim upcbusqueda As String
'        'Dim totpzas As Double
'        'Dim sql2 As String
'        'Dim errorcode As Integer
'        Dim iva, ieps As Double
'        'Dim VENT As New VENTANITA("¿Desea cancelar el Articulo?", "BORRAR")
'        'Dim xcve As String

'        cantidad = 0
'        xtipo = 1
'        If Not buscararticulo Then
'            For i = 1 To Len(LTrim(RTrim(Me.TX_UPC.Text)))
'                If IsNumeric(Mid(TX_UPC.Text, i, 1)) Then

'                    Exit For
'                End If
'            Next
'            TX_UPC.Text = Mid(TX_UPC.Text, i, Len(TX_UPC.Text) - i + 1)
'        End If

'        If buscararticulo Then
'            Dim Busca As New Form
'            Busca = New FrBuscaArt(xCon, Me)
'            Busca.Top = (Me.Height / 2 - Busca.Height / 2)
'            Busca.Left = (Me.Width / 2 - Busca.Width / 2)
'            Busca.BringToFront()
'            Busca.ShowDialog()
'            buscararticulo = False
'            If TX_UPC.Text <> "" Then
'                FueConF1 = True
'                SendKeys.Send(Chr(13))
'            End If

'            SendKeys.Flush()
'            Exit Sub

'        End If
'        'agrega articulo //listo
'        Dim FueConF3 As Boolean = False
'        Dim TraeVale As Boolean = False
'        If CargandoPendiente Then
'            FueConF1 = PendFueConF1
'            cancelacion = PendFueConF2
'            FueConF3 = PendFueConF3
'            TraeVale = IIf(PendTraeVale = "", False, True)
'        End If

'        If Not cancelacion Then
'            Dim UPCStr As String
'            If Mid(Me.TX_UPC.Text, 1, 4) = "2000" And Len(Me.TX_UPC.Text) = 13 Then
'                UPCStr = Mid(Me.TX_UPC.Text, 1, 7)
'                xtipo = 2
'                cantidad = (Val(Mid(Me.TX_UPC.Text, 8, 5)) / 100)
'            Else
'                UPCStr = TX_UPC.Text
'                xtipo = 1
'                cantidad = 0
'            End If

'            If Mid(Me.TX_UPC.Text, 1, 4) = "2000" And Len(Me.TX_UPC.Text) = 13 Then

'            End If

'            sql = "select isnull(tipo_ofer,0) Tipo_Ofer,art_clave, isnull(ECBOLETINOFER.ARTICULO,'') Articulo, upc_descripcion, Art_NomLargo, Art_CostoCap2, ART_FAMILIA, isnull(ECBOLETINOFER.DescOferta,'') DescOferta, isnull(CantidadDisponible,-1) CantidadDisponible, ISNULL(ECBOLETINOFER.Cantidad,0) Cantidad, isnull(PorcentajeDescuento,'') PorcentajeDescuento, isnull(ID,'') ID, isnull(Fam_Clave,'') Fam_Clave, isnull(ClaveMarca,-1) ClaveMarca, isnull(t2a.CantidadCobrados,-1) CobradosUPC ,isnull(t2c.CantidadCobrados,-1) CobradosClave," &
'                  "isnull(ECBOLETINOFER.UPC_CodInv,'') UPCCodInvOferta, xupc.upc_codinv, ART_PRECIO1, isnull(XPRECIO1,art_precio1*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO1, ART_PRECIO2, isnull(XPRECIO2,art_precio2*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO2, ART_PRECIO3,isnull(XPRECIO3,art_precio3*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO3, " &
'                  "isnull(art_kilo,0) ART_KILO ,ISNULL(art_entrega,0) ART_ENTREGA, ISNULL(xupc.upc_factor,1) as Factor, art_cap1, art_uni1, art_cap2, art_uni2, art_topemay, art_iva, art_ieps, upc_upc from xupc inner join articulo on upc_cveart=art_Clave " &
'                  "LEFT JOIN ECBOLETINOFER ON ((((ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv is null) or (ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv=XUPC.UPC_CODINV)) or ART_FAMILIA=Fam_Clave or art_marca=ClaveMarca) AND ((FECHAINI<='" & Format(Today, "yyyyMMdd") & "' AND FECHAFIN>='" & Format(Today, "yyyyMMdd") & "') or (CantidadDisponible>0 and Cantidad>0)) and Activo=1) " &
'                  "left join (select ARTICULO, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by articulo) t2a on (t2a.ARTICULO=ECBOLETINOFER.UPC_CodInv and TIPO_OFER=1) " &
'                  "left join (select ArtClave, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by ArtClave) t2c on (t2c.ArtClave=ECBOLETINOFER.ARTICULO and TIPO_OFER=2 ) " &
'                  "where (upc_upc = '" & UPCStr & "' and art_activo=1 and upc_activo=1)"

'            If Len(Me.TX_UPC.Text) > 7 And Not (Mid(Me.TX_UPC.Text, 1, 4) = "2000" And Len(Me.TX_UPC.Text) = 13) Then
'                sql = sql & " or (upc_upc='" & "0" & Me.TX_UPC.Text & "' and upc_activo=1)"
'            End If

'            sql = sql & " order by XPRECIO1 asc, CantidadDisponible desc, UPCCodInvOferta desc"
'            Base.daQuery(sql, xCon, dsc, "articulo")
'            If dsc.Tables("articulo").Rows.Count > 0 Then

'                'If Mid(Me.TX_UPC.Text, 1, 4) = "2000" And Len(Me.TX_UPC.Text) = 13 Then
'                '    cantidad = (Val(Mid(Me.TX_UPC.Text, 8, 5)) / 100)
'                'End If                

'                Dim EnOFerta As Boolean = False
'                UPCUPC = dsc.Tables("articulo").Rows(0)("upc_upc").ToString.Trim
'                ArtClave = dsc.Tables("articulo").Rows(0)("art_clave").ToString.Trim
'                ArtNomLargo = dsc.Tables("articulo").Rows(0)("Art_NomLargo").ToString.Trim
'                Familia = dsc.Tables("articulo").Rows(0)("ART_FAMILIA").ToString.Trim
'                CostoCap = dsc.Tables("articulo").Rows(0)("art_costocap2").ToString.Trim

'                If dsc.Tables("ARTICULO").Rows(0)("Articulo").ToString.Trim = "" And dsc.Tables("ARTICULO").Rows(0)("Fam_Clave").ToString.Trim = "" And dsc.Tables("ARTICULO").Rows(0)("ClaveMarca").ToString.Trim = "-1" Then 'Si no hay oferta
'                    nomlargo = dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
'                    EnOFerta = False
'                Else
'                    If CDbl(dsc.Tables("ARTICULO").Rows(0)("XPRECIO1")) > 0 And CDbl(dsc.Tables("ARTICULO").Rows(0)("XPRECIO2")) > 0 And CDbl(dsc.Tables("ARTICULO").Rows(0)("XPRECIO3")) Then
'                        'Aqui tiene que haber algo para la descripcion y los descuentos
'                        nomlargo = dsc.Tables("articulo").Rows(0)("DescOferta").ToString.Trim
'                        EnOFerta = True
'                    Else
'                        nomlargo = dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
'                        EnOFerta = False
'                    End If
'                End If

'                ' --Logica Precio Caja
'                ' Evaluar logica de oferta para precio de caja virtual
'                Dim FactorEmpaque As Double
'                If VentaCajaVirtual AndAlso CDbl(dsc.Tables("articulo").Rows(0)("Factor")) = 1 Then
'                    Dim CapacidadCaja As Double = CDbl(dsc.Tables("articulo").Rows(0)("art_cap2")) * CDbl(dsc.Tables("articulo").Rows(0)("art_cap1"))
'                    If CapacidadCaja > 1 Then
'                        FactorEmpaque = CapacidadCaja
'                        nomlargo = "Caja - " & dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim & " (" & dsc.Tables("articulo").Rows(0)("art_cap1") & dsc.Tables("articulo").Rows(0)("art_uni1") & " / " & dsc.Tables("articulo").Rows(0)("art_cap2") & dsc.Tables("articulo").Rows(0)("art_uni2") & ")"

'                        Dim PrecioBaseMayoreo As Double = CDbl(dsc.Tables("Articulo").Rows(0)("ART_PRECIO3"))
'                        Precio1 = PrecioBaseMayoreo * FactorEmpaque
'                        Precio2 = Precio1
'                        Precio3 = Precio1
'                    End If

'                    VentaCajaVirtual = False
'                    TX_UPC.BackColor = Color.White
'                Else
'                    FactorEmpaque = CDbl(dsc.Tables("articulo").Rows(0)("Factor"))
'                    If FactorEmpaque > 1 Then
'                        ' Es Caja: Descripcion y Precio forzado
'                        'evaluar logica de oferta para precio de caja escaneada
'                        nomlargo = "Caja - " & dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
'                        Dim PrecioBaseMayoreo As Double = CDbl(dsc.Tables("Articulo").Rows(0)("ART_PRECIO3"))
'                        Precio1 = PrecioBaseMayoreo * FactorEmpaque
'                        Precio2 = Precio1
'                        Precio3 = Precio1
'                    Else
'                        Select Case TIPOVENTA
'                            Case 1
'                                Precio1 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO1")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO1")))
'                                Precio2 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO2")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO2")))
'                                Precio3 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
'                            Case 2
'                                Precio1 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO2")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO2")))
'                                Precio2 = Precio1
'                                Precio3 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
'                            Case 3
'                                Precio1 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
'                                Precio2 = Precio1
'                                Precio3 = Precio1
'                        End Select
'                    End If
'                End If
'                ' --------------------------

'                iva = CInt(dsc.Tables("articulo").Rows(0)("art_iva"))
'                ieps = CInt(dsc.Tables("articulo").Rows(0)("art_ieps"))
'                If EnOFerta Then
'                    TOPE = CDbl(dsc.Tables("ARTICULO").Rows(0)("ART_TOPEMAY"))
'                    'TOPE = CDbl(dsc.Tables("ARTICULO").Rows(0)("OfertaTopeMay"))
'                Else
'                    TOPE = CDbl(dsc.Tables("ARTICULO").Rows(0)("ART_TOPEMAY"))
'                End If


'                k = dsc.Tables("articulo").Rows(0)("ART_KILO")
'                virtual = dsc.Tables("articulo").Rows(0)("ART_ENTREGA")
'                'If virtual = 1 Then
'                'segundoticket = True

'                'End If

'                If k = 1 And xtipo = 1 And Not CargandoPendiente Then
'                    Me.Lkilos.Visible = True
'                    Me.tx_cantidad.Text = ""
'                    Me.tx_cantidad.Visible = True
'                    kilos = True
'                    Me.TX_UPC.Enabled = False
'                    Me.tx_cantidad.Focus()
'                End If

'                Me.TX_UPC.Text = ""

'                ' agrega el producto a la venta
'                With fp_articulos.ActiveSheet

'                    If CargandoPendiente Then
'                        cantidad = CantPend
'                        If Strings.Left(UPCUPC, 4) = "2000" And UPCUPC.Length > 4 Then
'                            xtipo = 2
'                        End If
'                    End If

'                    .AddRows(.RowCount, 1)
'                    .Rows(.RowCount - 1).Height = 30
'                    BtnCambiaVenta.Enabled = True
'                    BtnCambiaCliente.Enabled = True
'                    Dim CantCob As Double
'                    Dim TextoCantidadTemp As Double
'                    If tx_cantidad.Text <> "" Then
'                        TextoCantidadTemp = CDbl(tx_cantidad.Text)
'                    Else
'                        TextoCantidadTemp = 0
'                        If Not kilos Then


'                        End If
'                    End If
'                    If dsc.Tables("Articulo").Rows(0)("CobradosClave") <> -1 Then
'                        CantCob = dsc.Tables("Articulo").Rows(0)("CobradosClave") + IIf(TextoCantidadTemp < 0, Math.Abs(TextoCantidadTemp), 0)
'                    ElseIf dsc.Tables("Articulo").Rows(0)("CobradosUPC") <> -1 Then
'                        CantCob = dsc.Tables("Articulo").Rows(0)("CobradosUPC") + IIf(TextoCantidadTemp < 0, Math.Abs(TextoCantidadTemp), 0)
'                    Else
'                        CantCob = -1
'                    End If

'                    agregaArticulo(UPCUPC, ArtClave, nomlargo, ArtNomLargo, Familia, CostoCap, Precio1, Precio2, Precio3, .RowCount - 1, TOPE, xtipo, cantidad, iva, ieps, CargandoPendiente, TraeVale, FueConF1, cancelacion, FueConF3, CantidadDisponible:=dsc.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=dsc.Tables("articulo").Rows(0)("XPrecio1"), PrecioOferta2:=dsc.Tables("articulo").Rows(0)("XPrecio2"), PrecioOferta3:=dsc.Tables("articulo").Rows(0)("XPrecio3"), CantidadCobradas:=CantCob, TipoOferta:=dsc.Tables("articulo").Rows(0)("Tipo_Ofer")) 'Se agrega producto no con F2, puro enter, puede que atraves de F1.
'                    FueConF1 = False
'                    kilos = False
'                End With
'                SendKeys.Flush()

'            Else
'                sql = "select upc_upc from xupc join articulo on art_clave=upc_cveart where upc_upc='" & UPCStr & "' and (upc_activo<>1 or art_activo<>1)"
'                Base.daQuery(sql, xCon, dsc, "Activo")
'                If dsc.Tables("Activo").Rows.Count > 0 Then
'                    MsgBox("El artículo se encuentra inactivo.", MsgBoxStyle.Exclamation, "Punto de Venta")
'                    Label24.Text = "ARTÍCULO INACTIVO"
'                Else
'                    Label24.Text = "PRODUCTO NO ENCONTRADO"
'                End If
'                dsc.Tables.Remove("Activo")
'                TX_UPC.Enabled = False
'                Panel1.BringToFront()
'                Panel1.Top = (Me.Height / 2 - Panel1.Height / 2)
'                Panel1.Left = (Me.Width / 2 - Panel1.Width / 2)

'                Panel1.Visible = True
'                txe.Visible = True
'                Label24.Visible = True
'                Label2.Visible = False
'                Me.txe.Focus()
'            End If
'        Else
'            upcbusqueda = Me.TX_UPC.Text

'            'If Strings.Left(Me.TX_UPC.Text, 4) = "2000" And Len(Me.TX_UPC.Text) = 13 Then
'            '    'upcbusqueda = Mid(Me.TX_UPC.Text, 1, 7)
'            '    'cantidad = (Val(Mid(Me.TX_UPC.Text, 8, 5)) / 100)
'            '    xtipo = 2
'            'Else
'            '    'upcbusqueda = Me.TX_UPC.Text
'            '    'cantidad = 1
'            '    xtipo = 1
'            'End If

'            If Strings.Left(upcbusqueda, 4) = "2000" And upcbusqueda.Length = 13 Then
'                cantidad = (Val(Mid(upcbusqueda, 8, 5)) / 100) * -1
'                xtipo = 2
'            Else
'                cantidad = -1
'                xtipo = 1
'            End If

'            If CargandoPendiente Then
'                cantidad = CantPend
'            End If

'            sql = "select isnull(tipo_ofer,0) Tipo_Ofer,art_clave, isnull(ECBOLETINOFER.ARTICULO,'') Articulo, upc_descripcion, Art_NomLargo, Art_CostoCap2, ART_FAMILIA, isnull(ECBOLETINOFER.DescOferta,'') DescOferta, isnull(CantidadDisponible,-1) CantidadDisponible, ISNULL(ECBOLETINOFER.Cantidad,0) Cantidad, isnull(PorcentajeDescuento,'') PorcentajeDescuento, isnull(ID,'') ID, isnull(Fam_Clave,'') Fam_Clave, isnull(ClaveMarca,-1) ClaveMarca, isnull(t2a.CantidadCobrados,-1) CobradosUPC ,isnull(t2c.CantidadCobrados,-1) CobradosClave," &
'                  "isnull(ECBOLETINOFER.UPC_CodInv,'') UPCCodInvOferta, xupc.upc_codinv, ART_PRECIO1, isnull(XPRECIO1,art_precio1*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO1, ART_PRECIO2, isnull(XPRECIO2,art_precio2*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO2, ART_PRECIO3,isnull(XPRECIO3,art_precio3*(ISNULL(1-PorcentajeDescuento,0))) XPRECIO3, " &
'                  "isnull(art_kilo,0) ART_KILO ,ISNULL(art_entrega,0) ART_ENTREGA, ISNULL(xupc.upc_factor,1) as Factor, art_cap1, art_uni1, art_cap2, art_uni2, art_topemay, art_iva, art_ieps, upc_upc from xupc inner join articulo on upc_cveart=art_Clave " &
'                  "LEFT JOIN ECBOLETINOFER ON ((((ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv is null) or (ART_CLAVE=ARTICULO and ECBOLETINOFER.UPC_CodInv=XUPC.UPC_CODINV)) or ART_FAMILIA=Fam_Clave or art_marca=ClaveMarca) AND ((FECHAINI<='" & Format(Today, "yyyyMMdd") & "' AND FECHAFIN>='" & Format(Today, "yyyyMMdd") & "') or (CantidadDisponible>0 and Cantidad>0)) and Activo=1) " &
'                  "left join (select ARTICULO, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by articulo) t2a on (t2a.ARTICULO=ECBOLETINOFER.UPC_CodInv and TIPO_OFER=1) " &
'                  "left join (select ArtClave, isnull(SUM(cantidad),0) CantidadCobrados from tmpauxvta2 group by ArtClave) t2c on (t2c.ArtClave=ECBOLETINOFER.ARTICULO and TIPO_OFER=2 ) " &
'                  "where (upc_upc ='" & upcbusqueda & "' or (upc_upc = '" & Mid(upcbusqueda, 1, 7) & "' and art_kilo=1) and art_activo=1 and upc_activo=1)"

'            If Len(upcbusqueda) > 7 And Not (Mid(upcbusqueda, 1, 4) = "2000" And Len(upcbusqueda) = 13) Then
'                sql = sql & " or (upc_upc='" & "0" & upcbusqueda & "' and art_activo=1 and upc_activo=1)"
'            End If


'            sql = sql & " order by XPRECIO1 asc, CantidadDisponible desc, UPCCodInvOferta desc"

'            Base.daQuery(sql, xCon, dsc, "articulo")
'            If dsc.Tables("articulo").Rows.Count > 0 Then
'                'If (Strings.Left(upcbusqueda, 4) = "2000" And upcbusqueda.Length = 13) Then
'                '    cantidad = (Val(Mid(upcbusqueda, 8, 5)) / 100) * -1
'                'Else
'                '    cantidad = -1
'                'End If
'                'If CargandoPendiente Then
'                '    cantidad = CantPend
'                'End If
'                If dsc.Tables("articulo").Rows(0)("art_kilo") = 1 Then

'                End If

'                Dim EnOFerta As Boolean = False
'                UPCUPC = dsc.Tables("articulo").Rows(0)("upc_upc").ToString.Trim
'                ArtClave = dsc.Tables("articulo").Rows(0)("art_clave").ToString.Trim
'                ArtNomLargo = dsc.Tables("articulo").Rows(0)("Art_NomLargo").ToString.Trim
'                Familia = dsc.Tables("articulo").Rows(0)("ART_FAMILIA").ToString.Trim
'                CostoCap = dsc.Tables("articulo").Rows(0)("art_costocap2").ToString.Trim


'                If dsc.Tables("ARTICULO").Rows(0)("Articulo").ToString.Trim = "" And dsc.Tables("ARTICULO").Rows(0)("Fam_Clave").ToString.Trim = "" And dsc.Tables("ARTICULO").Rows(0)("ClaveMarca").ToString.Trim = "-1" Then 'Si no hay oferta
'                    nomlargo = dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
'                    EnOFerta = False
'                Else
'                    If CDbl(dsc.Tables("ARTICULO").Rows(0)("XPRECIO1")) > 0 And CDbl(dsc.Tables("ARTICULO").Rows(0)("XPRECIO2")) > 0 And CDbl(dsc.Tables("ARTICULO").Rows(0)("XPRECIO3")) Then
'                        'Aqui tiene que haber algo para la descripcion y los descuentos
'                        nomlargo = dsc.Tables("articulo").Rows(0)("DescOferta").ToString.Trim
'                        EnOFerta = True
'                    Else
'                        nomlargo = dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
'                        EnOFerta = False
'                    End If
'                End If

'                ' --Logica Precio Caja
'                ' Evaluar logica de oferta para precio de caja virtual
'                Dim FactorEmpaque As Double
'                If VentaCajaVirtual AndAlso CDbl(dsc.Tables("articulo").Rows(0)("Factor")) = 1 Then
'                    Dim CapacidadCaja As Double = CDbl(dsc.Tables("articulo").Rows(0)("art_cap2")) * CDbl(dsc.Tables("articulo").Rows(0)("art_cap1"))
'                    If CapacidadCaja > 1 Then
'                        FactorEmpaque = CapacidadCaja
'                        nomlargo = "Caja - " & dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim & " (" & dsc.Tables("articulo").Rows(0)("art_cap1") & dsc.Tables("articulo").Rows(0)("art_uni1") & " / " & dsc.Tables("articulo").Rows(0)("art_cap2") & dsc.Tables("articulo").Rows(0)("art_uni2") & ")"

'                        Dim PrecioBaseMayoreo As Double = CDbl(dsc.Tables("Articulo").Rows(0)("ART_PRECIO3"))
'                        Precio1 = PrecioBaseMayoreo * FactorEmpaque
'                        Precio2 = Precio1
'                        Precio3 = Precio1
'                    End If

'                    VentaCajaVirtual = False
'                    TX_UPC.BackColor = Color.White
'                Else
'                    FactorEmpaque = CDbl(dsc.Tables("articulo").Rows(0)("Factor"))
'                    If FactorEmpaque > 1 Then
'                        ' Es Caja: Descripcion y Precio forzado
'                        'evaluar logica de oferta para precio de caja escaneada
'                        nomlargo = "Caja - " & dsc.Tables("articulo").Rows(0)("upc_descripcion").ToString.Trim
'                        Dim PrecioBaseMayoreo As Double = CDbl(dsc.Tables("Articulo").Rows(0)("ART_PRECIO3"))
'                        Precio1 = PrecioBaseMayoreo * FactorEmpaque
'                        Precio2 = Precio1
'                        Precio3 = Precio1
'                    Else
'                        Select Case TIPOVENTA
'                            Case 1
'                                Precio1 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO1")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO1")))
'                                Precio2 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO2")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO2")))
'                                Precio3 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
'                            Case 2
'                                Precio1 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO2")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO2")))
'                                Precio2 = Precio1
'                                Precio3 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
'                            Case 3
'                                Precio1 = IIf(EnOFerta, CDbl(dsc.Tables("articulo").Rows(0)("XPRECIO3")), CDbl(dsc.Tables("articulo").Rows(0)("ART_PRECIO3")))
'                                Precio2 = Precio1
'                                Precio3 = Precio1
'                        End Select
'                    End If
'                End If
'                ' --------------------------
'                iva = CInt(dsc.Tables("articulo").Rows(0)("art_iva"))
'                ieps = CInt(dsc.Tables("articulo").Rows(0)("art_ieps"))
'                If EnOFerta Then
'                    TOPE = CDbl(dsc.Tables("ARTICULO").Rows(0)("ART_TOPEMAY"))
'                    'TOPE = CDbl(dsc.Tables("ARTICULO").Rows(0)("OfertaTopeMay"))
'                Else
'                    TOPE = CDbl(dsc.Tables("ARTICULO").Rows(0)("ART_TOPEMAY"))
'                End If

'                'inicializa el contador de digitos
'                Me.TX_UPC.Text = ""

'                If CargandoPendiente OrElse RecorreSpread(UPCUPC, cantidad, False) Then
'                    With fp_articulos.ActiveSheet
'                        .AddRows(.RowCount, 1)
'                        .Rows(.RowCount - 1).Height = 30
'                        Dim CantCob As Double
'                        Dim TextoCantidadTemp As Double
'                        If tx_cantidad.Text <> "" Then
'                            TextoCantidadTemp = CDbl(tx_cantidad.Text)
'                        Else
'                            TextoCantidadTemp = 0
'                        End If
'                        If dsc.Tables("Articulo").Rows(0)("CobradosClave") <> -1 Then
'                            CantCob = dsc.Tables("Articulo").Rows(0)("CobradosClave") + IIf(TextoCantidadTemp < 0, Math.Abs(TextoCantidadTemp), 0)
'                        ElseIf dsc.Tables("Articulo").Rows(0)("CobradosUPC") <> -1 Then

'                            CantCob = dsc.Tables("Articulo").Rows(0)("CobradosUPC") + IIf(TextoCantidadTemp < 0, Math.Abs(TextoCantidadTemp), 0)
'                        Else
'                            CantCob = -1
'                        End If


'                        agregaArticulo(UPCUPC, ArtClave, nomlargo, ArtNomLargo, Familia, CostoCap, Precio1, Precio2, Precio3, .RowCount - 1, TOPE, xtipo, cantidad, iva, ieps, CargandoPendiente, TraeVale, FueConF1, cancelacion, FueConF3, CantidadDisponible:=dsc.Tables("articulo").Rows(0)("CantidadDisponible"), PrecioOferta1:=dsc.Tables("articulo").Rows(0)("XPrecio1"), PrecioOferta2:=dsc.Tables("articulo").Rows(0)("XPrecio2"), PrecioOferta3:=dsc.Tables("articulo").Rows(0)("XPrecio3"), CantidadCobradas:=CantCob, TipoOferta:=dsc.Tables("articulo").Rows(0)("Tipo_Ofer")) 'Se agrega artículo por F2, puede que con F1.
'                        FueConF1 = False
'                        ANTERIOR = fp_articulos.ActiveSheet.Cells(.RowCount - 1, ColVenta.ColCantidad).Value

'                        If xtipo = 11 Then
'                            .Cells(.RowCount - 1, ColVenta.ColCantidad).Value = CInt(-1)
'                            .Cells(.RowCount - 1, ColVenta.ColTotal).Value = .Cells(.RowCount - 1, ColVenta.ColPrecio).Value * CInt(-1)
'                        End If

'                        'CONTROLPRECIOS(UPCUPC, Precio1, Precio2, TOPE, cantidad, ANTERIOR, .RowCount - 1, ArtClave, CargandoPendiente)

'                        Me.sumaSpread()
'                        bandera = 1
'                        'banderola = 0
'                        Me.l_cancelacion.Visible = False
'                        Me.autorizame = True
'                        'ListBox1.Items.Add("Cancela " & Math.Abs(fp_articulos.ActiveSheet.Cells(.RowCount - 1, 0).Value) & " " & fp_articulos.ActiveSheet.Cells(.RowCount - 1, 1).Value)
'                    End With
'                End If

'                cancelacion = False
'                Me.l_cancelacion.Visible = False
'            End If
'            'errorcode = sndPlaySoundA("c:\WINDOWs\MEDIA\ringin.WAV", &H1)
'            'Panel1.Visible = True
'            'Label2.Visible = True
'            'Label2.AutoSize = True
'            'Label24.Visible = False
'            'txt_cveenc.Focus()
'            Banderita = True
'        End If

'    End Sub

'    Private Sub txt_panelofe_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_panelofe.KeyDown
'        If e.KeyCode = Keys.Enter Then
'            ActualizaOferta()
'        End If
'    End Sub

'    Private Sub BtnCambiaVenta_Click(sender As Object, e As EventArgs) Handles BtnCambiaVenta.Click
'        If MsgBox("¿Desea cambiar el tipo de venta?", vbYesNo, "Punto de Venta") = MsgBoxResult.Yes Then
'            Dim Aprobado As Boolean = False
'            Dim ResTxt As String = Nothing
'            Dim ClienteID As Integer = TxtControl.Text
'            Dim VentaOrig As Integer = CInt(txt_tipoventa.Text)
'            Dim ClienteOrig As Integer = CInt(TxtControl.Text)
'            Dim ClienteOrigStr As String = LbClienteTicket.Text
'            NuevoTipoVenta = -1
'            ResTxt = " "
'            Do Until Aprobado
'                ResTxt = InputBox("Indique el nuevo tipo de venta:", "Cambiar Tipo de Venta", "")
'                If ResTxt <> "" Then
'                    If IsNumeric(ResTxt) Then
'                        If CInt(ResTxt) >= 1 And CInt(ResTxt) <= 3 Then
'                            If CInt(ResTxt) <> CInt(txt_tipoventa.Text) Then
'                                'falta poner cuando ya es 3 el cliente
'                                NuevoTipoVenta = CInt(ResTxt)
'                                If CInt(ResTxt) = 3 Then
'                                    Dim SQL As String = "select PrecioDuarsa from ECClientes where cli_clave=" & TxtControl.Text & " and PrecioDuarsa=1"
'                                    Try
'                                        Using DSC As New DataSet
'                                            Base.daQuery(SQL, xCon, DSC, "Existe")
'                                            If DSC.Tables("Existe").Rows.Count = 0 Then
'                                                Dim frmbuscar As New busqueda
'                                                frmbuscar.TXTCONTROL = Me.txt_foliopago
'                                                GENERAL.parametrosbusqueda(frmbuscar, "Precio Duarsa - Clientes Registrados", "cli_clave,cli_nombre", "ecclientes", "cli_nombre asc", "1", xCon, "Clave,Nombre", "50,200", "A,A", "1,2", "precioduarsa=1")
'                                                frmbuscar.TXTCONTROL = TxtControl
'                                                frmbuscar.Top = (Me.Height / 2 - frmbuscar.Height / 2)
'                                                frmbuscar.Left = (Me.Width / 2 - frmbuscar.Width / 2)
'                                                frmbuscar.BringToFront()
'                                                frmbuscar.ShowDialog()
'                                                frmbuscar.Dispose()

'                                                If TxtControl.Text = "" Then
'                                                    TxtControl.Text = ClienteOrig
'                                                    NuevoTipoVenta = VentaOrig
'                                                    txt_tipoventa.Text = VentaOrig
'                                                    LbClienteTicket.Text = ClienteOrigStr
'                                                Else
'                                                    Dim TmpStr() As String = TxtControl.Text.Trim.Split(",")
'                                                    TxtControl.Text = TmpStr(0).Trim
'                                                    ClienteID = CInt(TmpStr(0).Trim)
'                                                    LbClienteTicket.Text = "Cliente: " & TmpStr(1).Trim
'                                                    Aprobado = True
'                                                End If
'                                            Else
'                                                Aprobado = True
'                                            End If
'                                        End Using
'                                    Catch ex As Exception
'                                        MsgBox("Error al buscar PrecioDuarsa de Cliente actual." & Chr(13) & Chr(13) & ex.Message, vbExclamation, "Punto de Venta")
'                                        Exit Sub
'                                    End Try
'                                Else
'                                    'ClienteID = 0
'                                    Aprobado = True
'                                End If
'                            Else
'                                MsgBox("El tipo de venta es el mismo al actual.", vbInformation, "Cambiar Tipo de Venta")
'                            End If
'                        Else
'                            MsgBox("El tipo de venta debe ser 1,2 o 3.", vbInformation, "Cambiar Tipo de Venta")
'                        End If
'                    Else
'                        MsgBox("Tipo de Venta debe ser numérico.", vbInformation, "Cambiar Tipo de Venta")
'                    End If
'                Else
'                    Exit Sub
'                End If
'            Loop

'            Dim oforma1 As Form
'            AutorizaCierreCambioVentana = False
'            oforma1 = New paraautorizarSALIDA(Me, Nothing, Me.xCon, CambiandoVenta:=True)
'            oforma1.Top = (Me.Height / 2 - oforma1.Height / 2)
'            oforma1.Left = (Me.Width / 2 - oforma1.Width / 2)
'            oforma1.BringToFront()
'            oforma1.ShowDialog()
'            If AutorizaCierreCambioVentana Then
'                ActualizaPrecioTipoVenta(NuevoTipoVenta, ClienteID, VentaOrig)
'            Else
'                NuevoTipoVenta = VentaOrig
'                txt_tipoventa.Text = VentaOrig
'                TxtControl.Text = ClienteOrig
'                LbClienteTicket.Text = ClienteOrigStr
'            End If
'        Else
'            TX_UPC.Focus()
'        End If
'    End Sub
'    Private Sub ActualizaPrecioTipoVenta(ByVal NuevoTipoVenta As Integer, ByVal ClienteID As Integer, ByVal VentaOrig As Integer)
'        Dim SQL As String
'        If NuevoTipoVenta <> -1 Then
'            If NuevoTipoVenta <> 3 OrElse (NuevoTipoVenta = 3 And ClienteID <> -1) Then
'                SQL = "update tmpauxvta2 set tipo=" & NuevoTipoVenta & ", ClienteID=" & ClienteID & " where usuario='" & Globales.caja & "' and tipo=" & VentaOrig
'                Try
'                    Base.Ejecuta(SQL, xCon)
'                    limpiaSpread(CambiandoTipoVenta:=True)
'                Catch ex As Exception
'                    MsgBox("No pudo modificarse el tipo de venta.", vbExclamation, "Punto de Venta")
'                End Try
'            End If
'        End If
'    End Sub
'    Private Sub tx_cantidad_VisibleChanged(sender As Object, e As EventArgs) Handles tx_cantidad.VisibleChanged
'        If tx_cantidad.Visible Then
'            BtnCambiaVenta.Enabled = False
'            BtnCambiaCliente.Enabled = False
'        Else
'            BtnCambiaVenta.Enabled = True
'            BtnCambiaCliente.Enabled = True
'        End If
'    End Sub

'    Private Sub txt_tipoventa_EnabledChanged(sender As Object, e As EventArgs) Handles txt_tipoventa.EnabledChanged
'        If txt_tipoventa.Enabled Then
'            BtnCambiaVenta.Enabled = False
'            BtnCambiaCliente.Enabled = False
'        Else
'            If fp_articulos.ActiveSheet.RowCount > 0 Then
'                BtnCambiaVenta.Enabled = True
'                BtnCambiaCliente.Enabled = True
'            End If
'        End If
'    End Sub

'    Private Sub FPs_GotFocus(sender As Object, e As EventArgs) Handles fp_articulos.GotFocus, FP_FORMASPAGO.GotFocus
'        Dim Res As MsgBoxResult
'        If Not Corriendo Then
'            If grformapago.Visible Then
'                If PanelSeleccionTarjetas.Visible = False Then
'                    If sender.name = fp_articulos.Name Then
'                        Corriendo = True
'                        If MsgBox("¿Desea cerrar ventana de pagos?", vbYesNo, "Cerrar Pagos") = MsgBoxResult.Yes Then
'                            borrapagos()
'                            SendKeys.Flush()
'                        Else
'                            Res = MsgBoxResult.No
'                        End If
'                        Corriendo = False
'                    End If
'                    If Res = MsgBoxResult.No Or sender.name = FP_FORMASPAGO.Name Then
'                        If fpago = 1 Or fpago = 2 Then
'                            If tx_cantidad.Visible Then
'                                tx_cantidad.Focus()
'                            Else
'                                TX_UPC.Focus()
'                            End If
'                        ElseIf fpago = 3 Or fpago = 6 Or fpago = 7 Then
'                            If TXB_BANCO.Visible Then
'                                TXB_BANCO.Focus()
'                            Else
'                                If tx_cantidad.Visible Then
'                                    tx_cantidad.Focus()
'                                Else
'                                    TX_UPC.Focus()
'                                End If
'                            End If
'                        ElseIf fpago = 4 Then
'                            If txb_credito.Visible Then
'                                txb_credito.Focus()
'                            Else
'                                If tx_cantidad.Visible Then
'                                    tx_cantidad.Focus()
'                                Else
'                                    TX_UPC.Focus()
'                                End If
'                            End If
'                        End If
'                    End If
'                Else
'                    If TipoTarj = "" Then
'                        Corriendo = True
'                        If MsgBox("No ha seleccionado el tipo de tarjeta, ¿desea cerrar ventana de tarjetas?", vbYesNo, "Cerrar Pagos") = MsgBoxResult.Yes Then
'                            borrapagos()
'                            SendKeys.Flush()
'                        Else
'                            rbTCredito.Focus()
'                        End If
'                        Corriendo = False
'                    Else
'                        If sender.name = fp_articulos.Name Then
'                            Corriendo = True
'                            If MsgBox("¿Desea cerrar ventana de pagos?", vbYesNo, "Cerrar Pagos") = MsgBoxResult.Yes Then
'                                PanelSeleccionTarjetas.Visible = False
'                                borrapagos()
'                                SendKeys.Flush()
'                            Else
'                                MsgBox("Debe seleccionar primero el tipo de tarjeta.", vbExclamation, "Selección de Tarjeta")
'                                If TipoTarj = rbTCredito.Tag Then
'                                    rbTCredito.Focus()
'                                ElseIf TipoTarj = rbTDebito.Tag Then
'                                    rbTDebito.Focus()
'                                End If
'                            End If
'                            Corriendo = False
'                        Else
'                            If TipoTarj = rbTCredito.Tag Then
'                                rbTCredito.Focus()
'                            ElseIf TipoTarj = rbTDebito.Tag Then
'                                rbTDebito.Focus()
'                            End If
'                        End If
'                    End If
'                End If
'            End If
'        End If

'    End Sub

'    Private Sub BtnCierraPanel_Click_1(sender As Object, e As EventArgs) Handles BtnCierraPanel.Click
'        CierraPanel()
'    End Sub

'    Private Sub BtnRegistraTarjeta_Click(sender As Object, e As EventArgs) Handles BtnRegistraTarjeta.Click
'        RegistraTarjeta()
'    End Sub

'    Private Sub rbTCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles rbTCredito.KeyDown, rbTDebito.KeyDown
'        If e.KeyCode = Keys.Escape Then
'            CierraPanel()
'        ElseIf e.KeyCode = Keys.Enter Then
'            RegistraTarjeta()
'        End If
'    End Sub

'    Private Sub RegistraTarjeta()
'        PanelSeleccionTarjetas.Visible = False
'        'QuitaComision()
'        'If Round(((totalote - totalpagos) * IIf((TIPOVENTA = 2 Or TIPOVENTA = 3), 1.02, 1)), 2) > 0 Then
'        If Round((totalote - totalpagos) * IIf(TIPOVENTA > 1, 1.02, 1), 2) > 0 Then
'            'Dim Com As Double = AlcanzaComision((((totalote - totalpagos) * IIf((TIPOVENTA = 2 Or TIPOVENTA = 3), 0.02, 1))))
'            Dim Com As Double
'            If TIPOVENTA > 1 Then
'                Com = AlcanzaComision(Math.Round((((totalote - totalpagos) * 0.02)), 2), False)
'            Else
'                Com = 0
'                TotalComision = 0
'            End If

'            If rbTCredito.Checked Then
'                TipoTarj = "Crédito"
'            ElseIf rbTDebito.Checked Then
'                TipoTarj = "Débito"
'            End If
'            'Ahora sí lo que sigue de f9
'            Label18.Text = "Referencia:"
'            Me.LFORPAG.Text = "Tarjeta"
'            Me.LFORPAG.Visible = True
'            'tx_cantidad.Text = Round(((totalote - totalpagos) * IIf((TIPOVENTA = 2 Or TIPOVENTA = 3), 1.02, 1)), 2).ToString
'            tx_cantidad.Text = Round(((totalote - totalpagos) + Com), 2).ToString
'            tx_cantidad.Visible = True

'            banco.Visible = True
'            fpago = 6
'            TX_UPC.Enabled = False
'            Me.TXB_BANCO.Focus()
'        Else
'            MsgBox("El Monto pagado hasta el momento ya salda el ticket.", vbExclamation, "Monto Incorrecto")
'            LFORPAG.Visible = False
'            tx_cantidad.Text = ""
'            tx_cantidad.Visible = False
'            TXB_BANCO.Text = ""
'            TX_UPC.Enabled = True
'            TX_UPC.Text = ""
'            TX_UPC.Focus()
'        End If
'    End Sub
'    Private Sub CierraPanel()
'        'Solo quita tarjeta         
'        'QuitaComision()
'        TX_UPC.Enabled = True
'        TipoTarj = ""
'        PanelSeleccionTarjetas.Visible = False
'        TX_UPC.Focus()
'        ''''
'    End Sub

'    Private Sub CambiaCliente(ByVal ClienteOrig As Integer, ByVal ClienteOrigStr As String, ByVal RequiereAutorizacion As Boolean)
'        Dim frmbuscar As New busqueda
'        Dim VentaOrig As Integer = CInt(txt_tipoventa.Text)
'        frmbuscar.TXTCONTROL = TxtControl
'        GENERAL.parametrosbusqueda(frmbuscar, "Clientes Registrados", "cli_clave,CLI_NOMBRE,PrecioDuarsa", "ecclientes", "Cli_nombre desc", "1", xCon, "Clave,Nombre,Precio Duarsa", "80,250,80", "A,A,A", "1,3,2", "", "")
'        frmbuscar.TXTCONTROL = TxtControl
'        frmbuscar.Top = (Me.Height / 2 - frmbuscar.Height / 2)
'        frmbuscar.Left = (Me.Width / 2 - frmbuscar.Width / 2)
'        frmbuscar.BringToFront()
'        frmbuscar.ShowDialog()
'        frmbuscar.Dispose()
'        If TxtControl.Text <> "" Then
'            Dim TmpArr() As String = TxtControl.Text.Trim.Split(",")
'            TxtControl.Text = TmpArr(0).Trim
'            LbClienteTicket.Text = "Cliente: " & TmpArr(2).Trim
'            If TmpArr(1).Trim = "1" Then 'Si es precio Duarsa
'                txt_tipoventa.Text = 3
'                TIPOVENTA = 3
'                txt_tipoventa.Enabled = False
'                TX_UPC.Focus()
'            Else
'                If TIPOVENTA = 3 Then
'                    Dim Aprobado As Boolean = False
'                    Dim ResTxt As String = Nothing
'                    NuevoTipoVenta = -1
'                    ResTxt = " "

'                    Do Until Aprobado
'                        ResTxt = InputBox("Indique el nuevo tipo de venta:", "Cambiar Tipo de Venta", "")
'                        If ResTxt <> "" Then
'                            If IsNumeric(ResTxt) Then
'                                If CInt(ResTxt) >= 1 And CInt(ResTxt) <= 3 Then

'                                    NuevoTipoVenta = CInt(ResTxt)
'                                    If CInt(ResTxt) = 3 Then
'                                        MsgBox("El cliente " & LbClienteTicket.Text.Replace("Cliente: ", "") & " no tiene Precio Duarsa.", vbExclamation, "Punto de Venta")
'                                    Else
'                                        Aprobado = True
'                                        TIPOVENTA = NuevoTipoVenta
'                                        txt_tipoventa.Text = TIPOVENTA
'                                    End If
'                                Else
'                                    MsgBox("El tipo de venta debe ser 1,2 o 3.", vbInformation, "Cambiar Tipo de Venta")
'                                End If
'                            Else
'                                MsgBox("Tipo de Venta debe ser numérico.", vbInformation, "Cambiar Tipo de Venta")
'                            End If
'                        Else
'                            TxtControl.Text = ClienteOrig
'                            LbClienteTicket.Text = ClienteOrigStr
'                            TX_UPC.Focus()
'                            Exit Sub
'                        End If
'                    Loop
'                End If
'            End If
'        Else
'            TxtControl.Text = ClienteOrig
'            LbClienteTicket.Text = ClienteOrigStr
'            txt_tipoventa.Enabled = False
'            TX_UPC.Focus()
'        End If

'        If RequiereAutorizacion AndAlso ClienteOrig <> CInt(TxtControl.Text.Trim) Then
'            Dim oforma1 As Form
'            AutorizaCierreCambioVentana = False
'            oforma1 = New paraautorizarSALIDA(Me, Nothing, Me.xCon, CambiandoCliente:=True)
'            oforma1.Top = (Me.Height / 2 - oforma1.Height / 2)
'            oforma1.Left = (Me.Width / 2 - oforma1.Width / 2)
'            oforma1.BringToFront()
'            oforma1.ShowDialog()
'            If Not AutorizaCierreCambioVentana Then
'                TxtControl.Text = ClienteOrig
'                LbClienteTicket.Text = ClienteOrigStr
'                TIPOVENTA = VentaOrig
'                txt_tipoventa.Text = TIPOVENTA
'            Else
'                ActualizaPrecioTipoVenta(CInt(txt_tipoventa.Text), CInt(TxtControl.Text), VentaOrig)
'            End If
'        End If
'        TX_UPC.Focus()
'    End Sub
'    Private Sub BtnCambiaCliente_Click(sender As Object, e As EventArgs) Handles BtnCambiaCliente.Click
'        If MsgBox("¿Desea cambiar el cliente?", vbYesNo, "Punto de Venta") = MsgBoxResult.Yes Then
'            CambiaCliente(TxtControl.Text, LbClienteTicket.Text, True)
'        Else
'            TX_UPC.Focus()
'        End If
'    End Sub

'    Public Sub SacaProporcionP1P2(ByVal NumTicket As Double)
'        Dim CuantosMen, CuantosMay As Integer



'        For i As Integer = 0 To fp_articulos.ActiveSheet.Rows.Count - 1
'            If fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value > 0 AndAlso fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio1).Value > fp_articulos.ActiveSheet.Cells(i, ColVenta.ColPrecio).Value Then
'                CuantosMay += 1
'            Else
'                CuantosMen += 1
'            End If
'        Next


'        Dim DSC As New DataSet
'        Dim SQL As String = "SELECT COUNT(*) AS TotalFilas, " &
'        "SUM(CASE WHEN art_precio1 = TMP_PRECIO THEN 1 ELSE 0 END) AS CuantosMen, " &
'        "SUM(CASE WHEN art_precio1 <> TMP_PRECIO THEN 1 ELSE 0 END) AS CuantosMay, " &
'        "CAST(SUM(CASE WHEN art_precio1 <> TMP_PRECIO THEN 1 ELSE 0 END) AS FLOAT) / COUNT(*) AS MismatchRatio " &
'        "FROM tmpauxvta1 JOIN articulo ON TMP_ARTICULO = ART_CLAVE WHERE TMP_USUARIO = '" & Globales.caja & "';"

'        Try
'            Base.daQuery(SQL, xCon, DSC, "Proporcion")
'            If DSC.Tables("Proporcion").Rows.Count > 0 Then
'                CuantosMay = DSC.Tables("Proporcion").Rows(0)("CuantosMay")
'                CuantosMen = DSC.Tables("Proporcion").Rows(0)("CuantosMen")
'            End If
'            DSC.Tables.Remove("Proporcion")
'        Catch ex As Exception
'            MsgBox("Error al sacar Proporciones." & Chr(13) & Chr(13) & ex.Message)
'        End Try

'        Try
'                SQL = "insert into ProporcionVentaTicket values ('" & NumTicket & "'," & CuantosMay & "," & CuantosMen & "," & totalote & ",'" & Globales.nombreusuario & "'," & Math.Round(CuantosMay / (CuantosMen + CuantosMay), 3) & ")"
'                Base.Ejecuta(SQL, xCon)
'            Catch ex As Exception
'                MsgBox("Error al insertar Proporción de Venta." & Chr(13) & Chr(13) & ex.Message)
'        End Try
'    End Sub
'End Class
