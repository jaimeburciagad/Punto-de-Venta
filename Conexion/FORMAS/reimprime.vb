Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports FarPoint.Win.Spread.CellType
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.Model


Public Class reimprime
    Inherits System.Windows.Forms.Form
    Dim xcon As SqlConnection
    Dim foma As Form
    Dim iva As Double
    Dim losqueno As Double
    Dim Cajera As String
    Dim SQLTickets, SQLTicketDet, SQLTicketNoDet As String
    Dim SortDir As String
    Private renglones As New Collection
    Private sDireccion() As String
    Private sNomina, sNombre, sTotal As String
    Private line As Char = Chr(10)
    Private scambio As String
    Private Corriendo As Boolean
    Dim FilaEditando, FilaEditandoDet As Integer


    Friend WithEvents FP_VENTAS As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FP_VENTAS_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FP_VENTASDET As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FP_VENTASDET_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents panel_conf As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_todas As System.Windows.Forms.RadioButton
    Friend WithEvents rb_una As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_ttickets As System.Windows.Forms.RadioButton
    Friend WithEvents rb_canc As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_aplica As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
    Friend WithEvents generar As System.Windows.Forms.Button
    Friend WithEvents regresar As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chk_detalle As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BTN_IMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents txt_caja As System.Windows.Forms.TextBox
    Friend WithEvents panel_motivo As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TXT_MOTIVO As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents FechaIni As DateTimePicker
    Friend WithEvents FechaFin As DateTimePicker
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents SortByRenglon As RadioButton
    Friend WithEvents SortByDescripcion As RadioButton
    Friend WithEvents BuscaArt As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents txt_control As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RbTicket As RadioButton
    Friend WithEvents RbValeDetalle As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Sumas As Label
    Friend WithEvents CheckBox2 As CheckBox
    Private numt As String


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef con As SqlConnection, ByRef fom As Fradmin)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xcon = con
        foma = fom


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
        Dim EnhancedColumnHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer1 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer3 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer2 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer4 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer3 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer5 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer4 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer6 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer5 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer7 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer6 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer8 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer7 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer9 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer8 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer10 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer9 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer11 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer10 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer12 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer11 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer13 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer12 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedColumnHeaderRenderer14 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim EnhancedRowHeaderRenderer13 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
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
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType3 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim DateTimeCellType1 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reimprime))
        Dim DateTimeCellType2 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim CurrencyCellType1 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim DateTimeCellType3 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType3 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim CurrencyCellType2 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim CurrencyCellType3 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim NamedStyle7 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer2 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle8 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin2 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer2 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer2 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim NumberCellType4 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim CurrencyCellType4 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim CurrencyCellType5 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Me.FP_VENTAS = New FarPoint.Win.Spread.FpSpread()
        Me.FP_VENTAS_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.FP_VENTASDET = New FarPoint.Win.Spread.FpSpread()
        Me.FP_VENTASDET_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.panel_conf = New System.Windows.Forms.Panel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txt_control = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.BuscaArt = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.SortByRenglon = New System.Windows.Forms.RadioButton()
        Me.SortByDescripcion = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.FechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_caja = New System.Windows.Forms.TextBox()
        Me.rb_todas = New System.Windows.Forms.RadioButton()
        Me.rb_una = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rb_ttickets = New System.Windows.Forms.RadioButton()
        Me.rb_canc = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_aplica = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btn_exportar = New System.Windows.Forms.Button()
        Me.generar = New System.Windows.Forms.Button()
        Me.regresar = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chk_detalle = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BTN_IMPRIMIR = New System.Windows.Forms.Button()
        Me.panel_motivo = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TXT_MOTIVO = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RbTicket = New System.Windows.Forms.RadioButton()
        Me.RbValeDetalle = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Sumas = New System.Windows.Forms.Label()
        CType(Me.FP_VENTAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_VENTAS_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_VENTASDET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_VENTASDET_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_conf.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.panel_motivo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        EnhancedColumnHeaderRenderer1.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer1.Name = "EnhancedRowHeaderRenderer1"
        EnhancedRowHeaderRenderer1.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer2.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer2.Name = "EnhancedColumnHeaderRenderer2"
        EnhancedColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer2.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer3.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer3.Name = "EnhancedColumnHeaderRenderer3"
        EnhancedColumnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer3.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer2.Name = "EnhancedRowHeaderRenderer2"
        EnhancedRowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer2.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer4.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer4.Name = "EnhancedColumnHeaderRenderer4"
        EnhancedColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer4.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer3.Name = "EnhancedRowHeaderRenderer3"
        EnhancedRowHeaderRenderer3.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer5.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer5.Name = "EnhancedColumnHeaderRenderer5"
        EnhancedColumnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer5.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer4.Name = "EnhancedRowHeaderRenderer4"
        EnhancedRowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer4.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer6.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer6.Name = "EnhancedColumnHeaderRenderer6"
        EnhancedColumnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer6.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer5.Name = "EnhancedRowHeaderRenderer5"
        EnhancedRowHeaderRenderer5.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer7.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer7.Name = "EnhancedColumnHeaderRenderer7"
        EnhancedColumnHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer7.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer6.Name = "EnhancedRowHeaderRenderer6"
        EnhancedRowHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer6.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer8.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer8.Name = "EnhancedColumnHeaderRenderer8"
        EnhancedColumnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer8.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer7.Name = "EnhancedRowHeaderRenderer7"
        EnhancedRowHeaderRenderer7.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer9.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer9.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer9.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer9.Name = "EnhancedColumnHeaderRenderer9"
        EnhancedColumnHeaderRenderer9.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer9.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer8.Name = "EnhancedRowHeaderRenderer8"
        EnhancedRowHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer8.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer10.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer10.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer10.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer10.Name = "EnhancedColumnHeaderRenderer10"
        EnhancedColumnHeaderRenderer10.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer10.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer9.Name = "EnhancedRowHeaderRenderer9"
        EnhancedRowHeaderRenderer9.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer11.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer11.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer11.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer11.Name = "EnhancedColumnHeaderRenderer11"
        EnhancedColumnHeaderRenderer11.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer11.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer10.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer10.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer10.Name = "EnhancedRowHeaderRenderer10"
        EnhancedRowHeaderRenderer10.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer10.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer12.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer12.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer12.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer12.Name = "EnhancedColumnHeaderRenderer12"
        EnhancedColumnHeaderRenderer12.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer12.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer11.Name = "EnhancedRowHeaderRenderer11"
        EnhancedRowHeaderRenderer11.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer13.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer13.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer13.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer13.Name = "EnhancedColumnHeaderRenderer13"
        EnhancedColumnHeaderRenderer13.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer13.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer12.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer12.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer12.Name = "EnhancedRowHeaderRenderer12"
        EnhancedRowHeaderRenderer12.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer12.TextRotationAngle = 0R
        EnhancedColumnHeaderRenderer14.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer14.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer14.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer14.Name = "EnhancedColumnHeaderRenderer14"
        EnhancedColumnHeaderRenderer14.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer14.TextRotationAngle = 0R
        EnhancedRowHeaderRenderer13.Name = "EnhancedRowHeaderRenderer13"
        EnhancedRowHeaderRenderer13.TextRotationAngle = 0R
        '
        'FP_VENTAS
        '
        Me.FP_VENTAS.AccessibleDescription = "FP_VENTAS, Sheet1, Row 0, Column 0, "
        Me.FP_VENTAS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FP_VENTAS.BackColor = System.Drawing.SystemColors.Control
        Me.FP_VENTAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FP_VENTAS.Location = New System.Drawing.Point(12, 64)
        Me.FP_VENTAS.Name = "FP_VENTAS"
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.Locked = False
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.Renderer = EnhancedColumnHeaderRenderer12
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.Renderer = EnhancedRowHeaderRenderer11
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
        Me.FP_VENTAS.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1, NamedStyle2, NamedStyle3, NamedStyle4})
        Me.FP_VENTAS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FP_VENTAS.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FP_VENTAS_Sheet1})
        Me.FP_VENTAS.Size = New System.Drawing.Size(746, 601)
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
        Me.FP_VENTAS.Skin = SpreadSkin1
        Me.FP_VENTAS.TabIndex = 568
        Me.FP_VENTAS.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FP_VENTAS_Sheet1
        '
        Me.FP_VENTAS_Sheet1.Reset()
        Me.FP_VENTAS_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FP_VENTAS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FP_VENTAS_Sheet1.ColumnCount = 12
        Me.FP_VENTAS_Sheet1.RowCount = 1
        Me.FP_VENTAS_Sheet1.RowHeader.ColumnCount = 0
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Tipo Venta"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Caja"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Ticket"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Fecha"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Hora"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Total"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Estatus"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Fecha Cancelación"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 8).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 8).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Motivo Cancelación"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 9).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 9).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Autorización"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 10).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 10).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Su pago"
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 11).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 11).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTAS_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Su Cambio"
        Me.FP_VENTAS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_VENTAS_Sheet1.ColumnHeader.DefaultStyle.Parent = "Style1"
        NumberCellType1.DecimalPlaces = 0
        NumberCellType1.MaximumValue = 10000000.0R
        NumberCellType1.MinimumValue = -10000000.0R
        Me.FP_VENTAS_Sheet1.Columns.Get(0).CellType = NumberCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(0).Label = "Tipo Venta"
        Me.FP_VENTAS_Sheet1.Columns.Get(0).Locked = True
        NumberCellType2.DecimalPlaces = 0
        Me.FP_VENTAS_Sheet1.Columns.Get(1).CellType = NumberCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Label = "Caja"
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Width = 47.0!
        NumberCellType3.DecimalPlaces = 0
        NumberCellType3.MaximumValue = 10000000.0R
        NumberCellType3.MinimumValue = -10000000.0R
        Me.FP_VENTAS_Sheet1.Columns.Get(2).CellType = NumberCellType3
        Me.FP_VENTAS_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Label = "Ticket"
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Width = 75.0!
        DateTimeCellType1.Calendar = CType(resources.GetObject("DateTimeCellType1.Calendar"), System.Globalization.Calendar)
        DateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText
        DateTimeCellType1.DateDefault = New Date(2011, 4, 5, 11, 16, 53, 0)
        DateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999")
        DateTimeCellType1.TimeDefault = New Date(2011, 4, 5, 11, 16, 53, 0)
        Me.FP_VENTAS_Sheet1.Columns.Get(3).CellType = DateTimeCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(3).Label = "Fecha"
        Me.FP_VENTAS_Sheet1.Columns.Get(3).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(3).Width = 80.0!
        DateTimeCellType2.Calendar = CType(resources.GetObject("DateTimeCellType2.Calendar"), System.Globalization.Calendar)
        DateTimeCellType2.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText
        DateTimeCellType2.DateDefault = New Date(2011, 4, 5, 11, 16, 43, 0)
        DateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly
        DateTimeCellType2.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999")
        DateTimeCellType2.TimeDefault = New Date(2011, 4, 5, 11, 16, 43, 0)
        Me.FP_VENTAS_Sheet1.Columns.Get(4).CellType = DateTimeCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(4).Label = "Hora"
        Me.FP_VENTAS_Sheet1.Columns.Get(4).Width = 79.0!
        CurrencyCellType1.ShowSeparator = True
        Me.FP_VENTAS_Sheet1.Columns.Get(5).CellType = CurrencyCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(5).Label = "Total"
        Me.FP_VENTAS_Sheet1.Columns.Get(5).Width = 80.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(6).CellType = TextCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(6).Label = "Estatus"
        Me.FP_VENTAS_Sheet1.Columns.Get(6).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(6).Width = 89.0!
        DateTimeCellType3.Calendar = CType(resources.GetObject("DateTimeCellType3.Calendar"), System.Globalization.Calendar)
        DateTimeCellType3.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText
        DateTimeCellType3.DateDefault = New Date(2011, 4, 13, 12, 22, 14, 0)
        DateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime
        DateTimeCellType3.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999")
        DateTimeCellType3.TimeDefault = New Date(2011, 4, 13, 12, 22, 14, 0)
        Me.FP_VENTAS_Sheet1.Columns.Get(7).CellType = DateTimeCellType3
        Me.FP_VENTAS_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Label = "Fecha Cancelación"
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Width = 103.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(8).CellType = TextCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(8).Label = "Motivo Cancelación"
        Me.FP_VENTAS_Sheet1.Columns.Get(8).Width = 114.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(9).CellType = TextCellType3
        Me.FP_VENTAS_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(9).Label = "Autorización"
        Me.FP_VENTAS_Sheet1.Columns.Get(9).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(9).Width = 174.0!
        CurrencyCellType2.ShowSeparator = True
        Me.FP_VENTAS_Sheet1.Columns.Get(10).CellType = CurrencyCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(10).Label = "Su pago"
        Me.FP_VENTAS_Sheet1.Columns.Get(10).Width = 101.0!
        CurrencyCellType3.ShowSeparator = True
        Me.FP_VENTAS_Sheet1.Columns.Get(11).CellType = CurrencyCellType3
        Me.FP_VENTAS_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        Me.FP_VENTAS_Sheet1.Columns.Get(11).Label = "Su Cambio"
        Me.FP_VENTAS_Sheet1.Columns.Get(11).Width = 101.0!
        Me.FP_VENTAS_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FP_VENTAS_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FP_VENTAS_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FP_VENTAS_Sheet1.SelectionForeColor = System.Drawing.Color.White
        Me.FP_VENTAS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'FP_VENTASDET
        '
        Me.FP_VENTASDET.AccessibleDescription = "FP_VENTASDET, Sheet1, Row 0, Column 0, "
        Me.FP_VENTASDET.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FP_VENTASDET.BackColor = System.Drawing.SystemColors.Control
        Me.FP_VENTASDET.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTASDET.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.FP_VENTASDET.Location = New System.Drawing.Point(779, 65)
        Me.FP_VENTASDET.Name = "FP_VENTASDET"
        NamedStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle5.Locked = False
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle5.Renderer = EnhancedColumnHeaderRenderer14
        NamedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle6.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle6.Renderer = EnhancedRowHeaderRenderer13
        NamedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle7.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle7.Renderer = EnhancedCornerRenderer2
        NamedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle8.BackColor = System.Drawing.SystemColors.Window
        NamedStyle8.CellType = GeneralCellType2
        NamedStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle8.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle8.Renderer = GeneralCellType2
        Me.FP_VENTASDET.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle5, NamedStyle6, NamedStyle7, NamedStyle8})
        Me.FP_VENTASDET.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FP_VENTASDET.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FP_VENTASDET_Sheet1})
        Me.FP_VENTASDET.Size = New System.Drawing.Size(574, 600)
        SpreadSkin2.ColumnHeaderDefaultStyle = NamedStyle5
        SpreadSkin2.CornerDefaultStyle = NamedStyle7
        SpreadSkin2.DefaultStyle = NamedStyle8
        SpreadSkin2.FocusRenderer = EnhancedFocusIndicatorRenderer2
        EnhancedInterfaceRenderer2.GrayAreaColor = System.Drawing.Color.LightSteelBlue
        EnhancedInterfaceRenderer2.ScrollBoxBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(221, Byte), Integer))
        EnhancedInterfaceRenderer2.SheetTabLowerActiveColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(244, Byte), Integer))
        EnhancedInterfaceRenderer2.SheetTabLowerNormalColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(249, Byte), Integer))
        EnhancedInterfaceRenderer2.SheetTabUpperActiveColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(244, Byte), Integer))
        EnhancedInterfaceRenderer2.SheetTabUpperNormalColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(249, Byte), Integer))
        EnhancedInterfaceRenderer2.TabStripBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(221, Byte), Integer))
        SpreadSkin2.InterfaceRenderer = EnhancedInterfaceRenderer2
        SpreadSkin2.Name = "CustomSkin1"
        SpreadSkin2.RowHeaderDefaultStyle = NamedStyle6
        SpreadSkin2.ScrollBarRenderer = EnhancedScrollBarRenderer2
        SpreadSkin2.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FP_VENTASDET.Skin = SpreadSkin2
        Me.FP_VENTASDET.TabIndex = 570
        Me.FP_VENTASDET.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'FP_VENTASDET_Sheet1
        '
        Me.FP_VENTASDET_Sheet1.Reset()
        Me.FP_VENTASDET_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FP_VENTASDET_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FP_VENTASDET_Sheet1.ColumnCount = 5
        Me.FP_VENTASDET_Sheet1.RowCount = 1
        Me.FP_VENTASDET_Sheet1.RowHeader.ColumnCount = 0
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Artículo"
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Descripción"
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Cantidad"
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Precio"
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FP_VENTASDET_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Total"
        Me.FP_VENTASDET_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FP_VENTASDET_Sheet1.ColumnHeader.DefaultStyle.Parent = "Style1"
        Me.FP_VENTASDET_Sheet1.Columns.Get(0).CellType = TextCellType4
        Me.FP_VENTASDET_Sheet1.Columns.Get(0).Label = "Artículo"
        Me.FP_VENTASDET_Sheet1.Columns.Get(0).Width = 77.0!
        Me.FP_VENTASDET_Sheet1.Columns.Get(1).Label = "Descripción"
        Me.FP_VENTASDET_Sheet1.Columns.Get(1).Width = 195.0!
        NumberCellType4.DecimalPlaces = 2
        Me.FP_VENTASDET_Sheet1.Columns.Get(2).CellType = NumberCellType4
        Me.FP_VENTASDET_Sheet1.Columns.Get(2).Label = "Cantidad"
        Me.FP_VENTASDET_Sheet1.Columns.Get(2).Width = 71.0!
        CurrencyCellType4.ShowSeparator = True
        Me.FP_VENTASDET_Sheet1.Columns.Get(3).CellType = CurrencyCellType4
        Me.FP_VENTASDET_Sheet1.Columns.Get(3).Label = "Precio"
        Me.FP_VENTASDET_Sheet1.Columns.Get(3).Width = 103.0!
        CurrencyCellType5.ShowSeparator = True
        Me.FP_VENTASDET_Sheet1.Columns.Get(4).CellType = CurrencyCellType5
        Me.FP_VENTASDET_Sheet1.Columns.Get(4).Label = "Total"
        Me.FP_VENTASDET_Sheet1.Columns.Get(4).Width = 94.0!
        Me.FP_VENTASDET_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FP_VENTASDET_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FP_VENTASDET_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FP_VENTASDET_Sheet1.SelectionForeColor = System.Drawing.Color.White
        Me.FP_VENTASDET_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'panel_conf
        '
        Me.panel_conf.BackColor = System.Drawing.Color.Transparent
        Me.panel_conf.Controls.Add(Me.CheckBox2)
        Me.panel_conf.Controls.Add(Me.CheckBox1)
        Me.panel_conf.Controls.Add(Me.txt_control)
        Me.panel_conf.Controls.Add(Me.Button7)
        Me.panel_conf.Controls.Add(Me.BuscaArt)
        Me.panel_conf.Controls.Add(Me.GroupBox4)
        Me.panel_conf.Controls.Add(Me.GroupBox3)
        Me.panel_conf.Controls.Add(Me.GroupBox2)
        Me.panel_conf.Controls.Add(Me.GroupBox1)
        Me.panel_conf.Controls.Add(Me.Label9)
        Me.panel_conf.Controls.Add(Me.Label11)
        Me.panel_conf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_conf.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.panel_conf.Location = New System.Drawing.Point(270, 136)
        Me.panel_conf.Name = "panel_conf"
        Me.panel_conf.Size = New System.Drawing.Size(463, 251)
        Me.panel_conf.TabIndex = 573
        Me.panel_conf.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CheckBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CheckBox2.Location = New System.Drawing.Point(132, 219)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(77, 18)
        Me.CheckBox2.TabIndex = 549
        Me.CheckBox2.Text = "Por Cliente"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CheckBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CheckBox1.Location = New System.Drawing.Point(18, 219)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 18)
        Me.CheckBox1.TabIndex = 548
        Me.CheckBox1.Text = "Por Artículo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txt_control
        '
        Me.txt_control.Enabled = False
        Me.txt_control.Location = New System.Drawing.Point(399, 34)
        Me.txt_control.Name = "txt_control"
        Me.txt_control.Size = New System.Drawing.Size(45, 20)
        Me.txt_control.TabIndex = 547
        Me.txt_control.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_control.Visible = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.search_icon
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button7.Location = New System.Drawing.Point(420, 217)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(24, 24)
        Me.Button7.TabIndex = 546
        Me.Button7.Tag = "Salir"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = False
        '
        'BuscaArt
        '
        Me.BuscaArt.Enabled = False
        Me.BuscaArt.Location = New System.Drawing.Point(217, 219)
        Me.BuscaArt.Name = "BuscaArt"
        Me.BuscaArt.Size = New System.Drawing.Size(199, 20)
        Me.BuscaArt.TabIndex = 545
        Me.BuscaArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.SortByRenglon)
        Me.GroupBox4.Controls.Add(Me.SortByDescripcion)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox4.Location = New System.Drawing.Point(217, 130)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(228, 74)
        Me.GroupBox4.TabIndex = 544
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Orden de Detalle de Ticket"
        '
        'SortByRenglon
        '
        Me.SortByRenglon.AutoSize = True
        Me.SortByRenglon.BackColor = System.Drawing.Color.Transparent
        Me.SortByRenglon.Checked = True
        Me.SortByRenglon.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SortByRenglon.ForeColor = System.Drawing.Color.MidnightBlue
        Me.SortByRenglon.Location = New System.Drawing.Point(20, 20)
        Me.SortByRenglon.Name = "SortByRenglon"
        Me.SortByRenglon.Size = New System.Drawing.Size(64, 18)
        Me.SortByRenglon.TabIndex = 537
        Me.SortByRenglon.TabStop = True
        Me.SortByRenglon.Text = "Renglón"
        Me.SortByRenglon.UseVisualStyleBackColor = False
        '
        'SortByDescripcion
        '
        Me.SortByDescripcion.AutoSize = True
        Me.SortByDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.SortByDescripcion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SortByDescripcion.ForeColor = System.Drawing.Color.MidnightBlue
        Me.SortByDescripcion.Location = New System.Drawing.Point(20, 44)
        Me.SortByDescripcion.Name = "SortByDescripcion"
        Me.SortByDescripcion.Size = New System.Drawing.Size(82, 18)
        Me.SortByDescripcion.TabIndex = 538
        Me.SortByDescripcion.Text = "Descripción"
        Me.SortByDescripcion.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.FechaFin)
        Me.GroupBox3.Controls.Add(Me.FechaIni)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox3.Location = New System.Drawing.Point(217, 49)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(228, 68)
        Me.GroupBox3.TabIndex = 543
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Definición de Fechas"
        '
        'FechaFin
        '
        Me.FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaFin.Location = New System.Drawing.Point(95, 43)
        Me.FechaFin.Name = "FechaFin"
        Me.FechaFin.Size = New System.Drawing.Size(104, 20)
        Me.FechaFin.TabIndex = 549
        '
        'FechaIni
        '
        Me.FechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaIni.Location = New System.Drawing.Point(95, 17)
        Me.FechaIni.Name = "FechaIni"
        Me.FechaIni.Size = New System.Drawing.Size(104, 20)
        Me.FechaIni.TabIndex = 548
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(6, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 24)
        Me.Label7.TabIndex = 545
        Me.Label7.Text = "Fecha Final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 24)
        Me.Label6.TabIndex = 544
        Me.Label6.Text = "Fecha Inicial:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txt_caja)
        Me.GroupBox2.Controls.Add(Me.rb_todas)
        Me.GroupBox2.Controls.Add(Me.rb_una)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(18, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(193, 74)
        Me.GroupBox2.TabIndex = 542
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Definición de Cajas"
        '
        'txt_caja
        '
        Me.txt_caja.Location = New System.Drawing.Point(94, 44)
        Me.txt_caja.Name = "txt_caja"
        Me.txt_caja.Size = New System.Drawing.Size(25, 20)
        Me.txt_caja.TabIndex = 544
        Me.txt_caja.Text = "1"
        Me.txt_caja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rb_todas
        '
        Me.rb_todas.AutoSize = True
        Me.rb_todas.BackColor = System.Drawing.Color.Transparent
        Me.rb_todas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_todas.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_todas.Location = New System.Drawing.Point(20, 20)
        Me.rb_todas.Name = "rb_todas"
        Me.rb_todas.Size = New System.Drawing.Size(101, 18)
        Me.rb_todas.TabIndex = 537
        Me.rb_todas.Text = "Todas las Cajas"
        Me.rb_todas.UseVisualStyleBackColor = False
        '
        'rb_una
        '
        Me.rb_una.AutoSize = True
        Me.rb_una.BackColor = System.Drawing.Color.Transparent
        Me.rb_una.Checked = True
        Me.rb_una.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_una.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_una.Location = New System.Drawing.Point(20, 44)
        Me.rb_una.Name = "rb_una"
        Me.rb_una.Size = New System.Drawing.Size(68, 18)
        Me.rb_una.TabIndex = 538
        Me.rb_una.TabStop = True
        Me.rb_una.Text = "Una Caja"
        Me.rb_una.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rb_ttickets)
        Me.GroupBox1.Controls.Add(Me.rb_canc)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(18, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 68)
        Me.GroupBox1.TabIndex = 541
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección Información"
        '
        'rb_ttickets
        '
        Me.rb_ttickets.AutoSize = True
        Me.rb_ttickets.BackColor = System.Drawing.Color.Transparent
        Me.rb_ttickets.Checked = True
        Me.rb_ttickets.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_ttickets.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_ttickets.Location = New System.Drawing.Point(20, 20)
        Me.rb_ttickets.Name = "rb_ttickets"
        Me.rb_ttickets.Size = New System.Drawing.Size(108, 18)
        Me.rb_ttickets.TabIndex = 537
        Me.rb_ttickets.TabStop = True
        Me.rb_ttickets.Text = "Todos los Tickets"
        Me.rb_ttickets.UseVisualStyleBackColor = False
        '
        'rb_canc
        '
        Me.rb_canc.AutoSize = True
        Me.rb_canc.BackColor = System.Drawing.Color.Transparent
        Me.rb_canc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_canc.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_canc.Location = New System.Drawing.Point(20, 44)
        Me.rb_canc.Name = "rb_canc"
        Me.rb_canc.Size = New System.Drawing.Size(143, 18)
        Me.rb_canc.TabIndex = 538
        Me.rb_canc.Text = "Sólo Tickets Cancelados"
        Me.rb_canc.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(121, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(296, 26)
        Me.Label9.TabIndex = 460
        Me.Label9.Text = "Definición Parámetros Consulta"
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
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(712, 691)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 32)
        Me.Label5.TabIndex = 572
        Me.Label5.Text = "Definir Consulta"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_aplica
        '
        Me.btn_aplica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_aplica.BackColor = System.Drawing.Color.White
        Me.btn_aplica.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477019_setting_78582
        Me.btn_aplica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_aplica.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplica.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_aplica.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aplica.Location = New System.Drawing.Point(674, 691)
        Me.btn_aplica.Name = "btn_aplica"
        Me.btn_aplica.Size = New System.Drawing.Size(32, 32)
        Me.btn_aplica.TabIndex = 571
        Me.btn_aplica.Text = " "
        Me.btn_aplica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aplica.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(826, 691)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 32)
        Me.Label2.TabIndex = 579
        Me.Label2.Text = "Generar Consulta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label25.Location = New System.Drawing.Point(1168, 691)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 32)
        Me.Label25.TabIndex = 577
        Me.Label25.Text = "Exportar Datos"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_exportar.BackColor = System.Drawing.Color.White
        Me.btn_exportar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477204_share2_78604
        Me.btn_exportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_exportar.Enabled = False
        Me.btn_exportar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exportar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exportar.Location = New System.Drawing.Point(1130, 691)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(32, 32)
        Me.btn_exportar.TabIndex = 576
        Me.btn_exportar.Tag = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_exportar.UseVisualStyleBackColor = False
        '
        'generar
        '
        Me.generar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generar.BackColor = System.Drawing.Color.White
        Me.generar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477041_play_78590__1_
        Me.generar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.generar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.generar.Location = New System.Drawing.Point(788, 691)
        Me.generar.Name = "generar"
        Me.generar.Size = New System.Drawing.Size(32, 32)
        Me.generar.TabIndex = 574
        Me.generar.Text = " "
        Me.generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.generar.UseVisualStyleBackColor = False
        '
        'regresar
        '
        Me.regresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.regresar.BackColor = System.Drawing.Color.White
        Me.regresar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477101_arrow_left_78605
        Me.regresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.regresar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regresar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.regresar.Location = New System.Drawing.Point(1244, 691)
        Me.regresar.Name = "regresar"
        Me.regresar.Size = New System.Drawing.Size(32, 32)
        Me.regresar.TabIndex = 575
        Me.regresar.Text = " "
        Me.regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.regresar.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label27.Location = New System.Drawing.Point(1282, 691)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(70, 32)
        Me.Label27.TabIndex = 578
        Me.Label27.Text = "Menú Principal"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(940, 691)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 32)
        Me.Label3.TabIndex = 581
        Me.Label3.Text = "Cancelar Ticket"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477079_close_78565
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(902, 691)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 580
        Me.Button1.Tag = "Exportar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chk_detalle
        '
        Me.chk_detalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chk_detalle.AutoSize = True
        Me.chk_detalle.BackColor = System.Drawing.Color.Transparent
        Me.chk_detalle.Checked = True
        Me.chk_detalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_detalle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_detalle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.chk_detalle.Location = New System.Drawing.Point(1172, 41)
        Me.chk_detalle.Name = "chk_detalle"
        Me.chk_detalle.Size = New System.Drawing.Size(181, 18)
        Me.chk_detalle.TabIndex = 582
        Me.chk_detalle.Text = "Detalle de Artículos por Sabores"
        Me.chk_detalle.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(776, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(393, 21)
        Me.Label4.TabIndex = 583
        Me.Label4.Text = "Detalle de Artículos Registrados en Ticket de Venta         "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(1054, 691)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 32)
        Me.Label13.TabIndex = 591
        Me.Label13.Text = "Reimprimir Ticket"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_IMPRIMIR
        '
        Me.BTN_IMPRIMIR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_IMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTN_IMPRIMIR.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.printer_102274__1_1
        Me.BTN_IMPRIMIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_IMPRIMIR.Enabled = False
        Me.BTN_IMPRIMIR.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_IMPRIMIR.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BTN_IMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_IMPRIMIR.Location = New System.Drawing.Point(1016, 691)
        Me.BTN_IMPRIMIR.Name = "BTN_IMPRIMIR"
        Me.BTN_IMPRIMIR.Size = New System.Drawing.Size(32, 32)
        Me.BTN_IMPRIMIR.TabIndex = 590
        Me.BTN_IMPRIMIR.Tag = "Exportar"
        Me.BTN_IMPRIMIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_IMPRIMIR.UseVisualStyleBackColor = False
        '
        'panel_motivo
        '
        Me.panel_motivo.BackColor = System.Drawing.Color.Transparent
        Me.panel_motivo.Controls.Add(Me.Label17)
        Me.panel_motivo.Controls.Add(Me.Button5)
        Me.panel_motivo.Controls.Add(Me.Label16)
        Me.panel_motivo.Controls.Add(Me.Button4)
        Me.panel_motivo.Controls.Add(Me.TXT_MOTIVO)
        Me.panel_motivo.Controls.Add(Me.Label15)
        Me.panel_motivo.Controls.Add(Me.Label14)
        Me.panel_motivo.Location = New System.Drawing.Point(229, 170)
        Me.panel_motivo.Name = "panel_motivo"
        Me.panel_motivo.Size = New System.Drawing.Size(653, 237)
        Me.panel_motivo.TabIndex = 592
        Me.panel_motivo.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Location = New System.Drawing.Point(521, 178)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 35)
        Me.Label17.TabIndex = 586
        Me.Label17.Text = "REGRESAR"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(467, 171)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(48, 46)
        Me.Button5.TabIndex = 585
        Me.Button5.Tag = "Salir"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(361, 178)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 35)
        Me.Label16.TabIndex = 583
        Me.Label16.Text = "REALIZAR CANCELACION"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.borrar
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(307, 171)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(48, 46)
        Me.Button4.TabIndex = 582
        Me.Button4.Tag = "Exportar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TXT_MOTIVO
        '
        Me.TXT_MOTIVO.Location = New System.Drawing.Point(47, 99)
        Me.TXT_MOTIVO.Multiline = True
        Me.TXT_MOTIVO.Name = "TXT_MOTIVO"
        Me.TXT_MOTIVO.Size = New System.Drawing.Size(548, 62)
        Me.TXT_MOTIVO.TabIndex = 548
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(134, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(352, 26)
        Me.Label15.TabIndex = 547
        Me.Label15.Text = "Registro Motivo Cancelación de Ticket"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(38, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(195, 24)
        Me.Label14.TabIndex = 546
        Me.Label14.Text = "Indique el Motivo de la Cancelación:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(178, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(200, 21)
        Me.Label20.TabIndex = 23908
        Me.Label20.Text = "Administración de Cajas"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23907
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(178, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 21)
        Me.Label1.TabIndex = 23906
        Me.Label1.Text = "Administración de Tickets"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label45
        '
        Me.Label45.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label45.BackColor = System.Drawing.Color.SlateBlue
        Me.Label45.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(1181, 9)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(171, 22)
        Me.Label45.TabIndex = 23909
        Me.Label45.Text = "Duarsa 1"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.printer_102274__1_
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(12, 68)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(32, 32)
        Me.Button9.TabIndex = 539
        Me.Button9.Tag = "Exportar"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477101_arrow_left_78605__1_
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(173, 68)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(32, 32)
        Me.Button8.TabIndex = 540
        Me.Button8.Tag = "Salir"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.RbTicket)
        Me.GroupBox5.Controls.Add(Me.RbValeDetalle)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox5.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(193, 51)
        Me.GroupBox5.TabIndex = 587
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Reimprimir"
        '
        'RbTicket
        '
        Me.RbTicket.AutoSize = True
        Me.RbTicket.BackColor = System.Drawing.Color.Transparent
        Me.RbTicket.Checked = True
        Me.RbTicket.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTicket.ForeColor = System.Drawing.Color.MidnightBlue
        Me.RbTicket.Location = New System.Drawing.Point(13, 20)
        Me.RbTicket.Name = "RbTicket"
        Me.RbTicket.Size = New System.Drawing.Size(53, 18)
        Me.RbTicket.TabIndex = 537
        Me.RbTicket.TabStop = True
        Me.RbTicket.Text = "Ticket"
        Me.RbTicket.UseVisualStyleBackColor = False
        '
        'RbValeDetalle
        '
        Me.RbValeDetalle.AutoSize = True
        Me.RbValeDetalle.BackColor = System.Drawing.Color.Transparent
        Me.RbValeDetalle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbValeDetalle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.RbValeDetalle.Location = New System.Drawing.Point(72, 19)
        Me.RbValeDetalle.Name = "RbValeDetalle"
        Me.RbValeDetalle.Size = New System.Drawing.Size(114, 18)
        Me.RbValeDetalle.TabIndex = 538
        Me.RbValeDetalle.Text = "Vale de Mercancía"
        Me.RbValeDetalle.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Location = New System.Drawing.Point(949, 263)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 110)
        Me.Panel1.TabIndex = 23910
        Me.Panel1.Visible = False
        '
        'Sumas
        '
        Me.Sumas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sumas.BackColor = System.Drawing.Color.Transparent
        Me.Sumas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sumas.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Sumas.Location = New System.Drawing.Point(735, 668)
        Me.Sumas.Name = "Sumas"
        Me.Sumas.Size = New System.Drawing.Size(618, 20)
        Me.Sumas.TabIndex = 23911
        Me.Sumas.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Sumas.Visible = False
        '
        'reimprime
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1364, 732)
        Me.Controls.Add(Me.panel_motivo)
        Me.Controls.Add(Me.panel_conf)
        Me.Controls.Add(Me.Sumas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.BTN_IMPRIMIR)
        Me.Controls.Add(Me.FP_VENTASDET)
        Me.Controls.Add(Me.chk_detalle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.generar)
        Me.Controls.Add(Me.regresar)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_aplica)
        Me.Controls.Add(Me.FP_VENTAS)
        Me.Name = "reimprime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Tickets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FP_VENTAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_VENTAS_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_VENTASDET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_VENTASDET_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_conf.ResumeLayout(False)
        Me.panel_conf.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panel_motivo.ResumeLayout(False)
        Me.panel_motivo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) &
        IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
    End Function

    Private Sub reimprime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dsc As New DataSet
        Dim dsc1 As New DataSet

        Dim total1 As Double = 0
        Dim total2 As Double = 0
        Dim total3 As Double = 0
        Dim total4 As Double = 0
        Dim total5 As Double = 0
        Dim total6 As Double = 0

        FP_VENTAS.ActiveSheet.SelectionPolicy = Model.SelectionPolicy.MultiRange
        FP_VENTASDET.ActiveSheet.SelectionPolicy = Model.SelectionPolicy.MultiRange
        'FP_VENTAS.ActiveSheet.OperationMode = OperationMode.ExtendedSelect
        'FP_VENTASDET.ActiveSheet.OperationMode = OperationMode.ExtendedSelect


        FechaIni.Value = Today
        FechaFin.Value = Today

        FechaFin.MaxDate = Today
        FechaIni.MaxDate = Today
        If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
            If Remoto Then
                Label45.Text = "Duarsa 2"
                Label45.BackColor = Color.Blue
                Me.Text = "D2 - " & "Administración de Tickets"
            Else
                Label45.Text = "Duarsa 1"
                Label45.BackColor = Color.SlateBlue
                Me.Text = "D1 - " & "Administración de Tickets"
            End If
        Else
            If Remoto Then
                Label45.Text = "Duarsa 1"
                Label45.BackColor = Color.SlateBlue
                Me.Text = "D1 - " & "Administración de Tickets"
            Else
                Label45.Text = "Duarsa 2"
                Label45.BackColor = Color.Blue
                Me.Text = "D2 - " & "Administración de Tickets"
            End If
        End If



        Button1.Enabled = False
        BTN_IMPRIMIR.Enabled = False
        btn_exportar.Enabled = False



        'sql = "select max(fecha) as fecha from ECCONTROLINV"
        'Base.daQuery(sql, xcon, dsc, "FechaInv")
        'If dsc.Tables("FechaInv").Rows.Count > 0 Then
        'FechaIni.MinDate = dsc.Tables("FechaInv").Rows(0)("Fecha")
        'FechaFin.MinDate = FechaIni.MinDate
        'End If
        'dsc.Tables.Remove("FechaInv")

        If Strings.Right(Globales.caja, 1) = "7" Then
            rb_todas.Checked = True
        Else
            txt_caja.Text = Strings.Right(Globales.caja, 1)
        End If


    End Sub

    Private Sub rellenadetalledet(ByVal venta As Integer, ByVal Optional VengoDeSort As Boolean = False)
        Dim dsc As New DataSet
        Dim i As Integer
        SQLTicketNoDet = ""

        If Not VengoDeSort Then
            SQLTicketDet = "select e.dve_articulo, UPC_DESCRIPCION, e.DVE_CANTIDAD, isnull(x.cantdev,0) as CantDev, dve_cantidad-isnull(x.cantdev,0) CantNet, e.DVE_PRECIO, e.dve_total, e.dve_total-(isnull(x.cantdev,0)*dve_precio) TotalNet, case when exists (select dve_venta from ecventadete h where h.dve_venta=e.DVE_VENTA and h.DVE_UPC=e.DVE_UPC) then '1' else '0' end  as vale from ecventadet e " &
                  "inner join xupc on upc_upc=dve_upc inner join articulo on art_clave=upc_cveart " &
                  " left join ( " &
                        "SELECT ID_ARTICULO,upc_upc,SUM(CANTIDAD)AS CANTDEV FROM eccancxupc " &
                        " WHERE N_TICKET= " & venta & " GROUP BY ID_ARTICULO,upc_upc ) X on  x.id_articulo=e.dve_articulo " &
                        " and  X.upc_upc=e.DVE_upc " &
                  "where e.dve_venta=" & venta & IIf(SortByRenglon.Checked, " order by e.DVE_renglon", " order by upc_descripcion")
        End If

        FP_VENTASDET.ActiveSheet.RowCount = 0
        Base.daQuery(SQLTicketDet, xcon, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
        If dsc.Tables("ventas").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTASDET.ActiveSheet.Cells(i, 0).Text = dsc.Tables("ventas").Rows(i)("dve_articulo") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("upc_descripcion") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 2).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_cantidad")) - CDbl(dsc.Tables("ventas").Rows(i)("CantDev")), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 3).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_precio") & ""), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 4).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_total") & "") - (CDbl(dsc.Tables("ventas").Rows(i)("CantDev")) * CDbl(dsc.Tables("ventas").Rows(i)("dve_precio"))), "###,##0.00")
                If dsc.Tables("ventas").Rows(i)("Vale") <> 0 Then
                    FP_VENTASDET.ActiveSheet.Rows(i).ForeColor = Color.Blue
                End If
            Next i
            FilaEditandoDet = -1
        End If

        dsc.Tables.Remove("ventas")

    End Sub
    Private Sub rellenadetalle(ByVal venta As Integer, ByVal Optional VengoDeSort As Boolean = False)
        Dim dsc As New DataSet
        Dim i As Integer
        SQLTicketDet = ""
        If Not VengoDeSort Then
            SQLTicketNoDet = "select * from ecdetventa e inner join articulo on art_clave=dve_articulo" &
                  " and dve_venta=" & venta & IIf(SortByRenglon.Checked, " order by e.DVE_renglon", " order by art_nomlargo")
        End If

        FP_VENTASDET.ActiveSheet.RowCount = 0
        Base.daQuery(SQLTicketNoDet, xcon, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
        If dsc.Tables("ventas").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTASDET.ActiveSheet.Cells(i, 0).Value = dsc.Tables("ventas").Rows(i)("dve_articulo") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("art_nomlargo") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 2).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_cantidad")), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 3).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_precio") & ""), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 4).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_total") & ""), "###,##0.00")
            Next i
            FilaEditandoDet = -1
        End If

        dsc.Tables.Remove("ventas")
    End Sub

    Private Sub FP_VENTASDET_CellClick(sender As Object, e As CellClickEventArgs) Handles FP_VENTASDET.CellClick
        If e.ColumnHeader Then
            If (SQLTicketDet <> "" And chk_detalle.Checked) Or (SQLTicketNoDet <> "" And chk_detalle.Checked = False) Then
                Dim Fin As Integer
                Dim sql As String
                If SQLTicketNoDet = "" Then
                    Fin = InStr(SQLTicketDet, "order by")
                ElseIf SQLTicketDet = "" Then
                    Fin = InStr(SQLTicketNoDet, "order by")
                End If

                If Fin > 0 Then
                    If SQLTicketDet = "" Then
                        sql = Strings.Left(SQLTicketNoDet, Fin + 7)
                    ElseIf SQLTicketNoDet = "" Then
                        sql = Strings.Left(SQLTicketDet, Fin + 7)
                    End If


                    If SortDir = "" Then
                        SortDir = " asc"
                    ElseIf SortDir = " asc" Then
                        SortDir = " desc"
                    ElseIf SortDir = " desc" Then
                        SortDir = " asc"
                    End If

                    Select Case e.Column
                        Case 0
                            sql += " dve_articulo" & SortDir
                        Case 1
                            sql += IIf(chk_detalle.Checked, " upc_descripcion", " art_nomlargo") & SortDir
                        Case 2
                            sql += IIf(chk_detalle.Checked, " CantNet", " dve_cantidad") & SortDir
                        Case 3
                            sql += " dve_precio" & SortDir
                        Case 4
                            sql += IIf(chk_detalle.Checked, " TotalNet", " dve_total") & SortDir
                    End Select
                    If chk_detalle.Checked Then
                        SQLTicketDet = sql
                        Call rellenadetalledet(FP_VENTAS.ActiveSheet.Cells(1, 2).Value, True)
                    Else
                        SQLTicketNoDet = sql
                        Call rellenadetalle(FP_VENTAS.ActiveSheet.Cells(1, 2).Value, True)
                    End If
                End If
            End If
        Else
            PINTA(e.Row, 1, FP_VENTASDET, FilaEditandoDet)
            FilaEditandoDet = e.Row
        End If
    End Sub

    Private Sub fp_ventas_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        e.Cancel = True
        If chk_detalle.Checked Then
            Call rellenadetalledet(FP_VENTAS.ActiveSheet.Cells(e.Row, 2).Value)
        Else
            Call rellenadetalle(FP_VENTAS.ActiveSheet.Cells(e.Row, 2).Value)
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 6).Value = "Cancelado" Then
            MsgBox("El ticket ya está cancelado.", MsgBoxStyle.Exclamation, "Cancelar Ticket")
            Exit Sub
        End If
        panel_motivo.Visible = True
        TXT_MOTIVO.Focus()
        panel_motivo.BringToFront()

    End Sub

    Private Sub PINTA(ByVal renglon As Integer, ByVal color As Integer, ByVal FP As FpSpread, Optional ByVal NewRenglon As Integer = -1, Optional ByVal color2 As Integer = -1)
        Dim acell, acell0 As FarPoint.Win.Spread.Cell
        acell = FP.ActiveSheet.Cells(renglon, 0, renglon, FP.ActiveSheet.ColumnCount - 1)
        If NewRenglon > -1 Then
            acell0 = FP.ActiveSheet.Cells(NewRenglon, 0, NewRenglon, FP.ActiveSheet.ColumnCount - 1)
        End If


        If renglon <> NewRenglon Then
            Select Case color
                Case 1
                    acell.BackColor = System.Drawing.Color.LightBlue
                    If NewRenglon <> -1 Then
                        acell0.BackColor = System.Drawing.Color.White
                    End If
                Case 2
                    acell.BackColor = System.Drawing.Color.White
            End Select
        End If

    End Sub
    Private Sub reimprimir(ByVal ticket As String)

        Dim dsc As New DataSet
        Dim SQL As String
        Dim oImpresion As Impresion
        numt = ticket
        Dim i As Integer
        Dim limite As Integer
        Dim Espacios As String
        Dim ieps, subt As Double
        losqueno = 0
        iva = 0
        ieps = 0
        'ENCABEZADO
        If ticket <> "" Then


            SQL = "SELECT * FROM ECDETVENTA" &
                " INNER JOIN ECVENTA ON VEN_ID=DVE_VENTA " &
                " INNER JOIN ARTICULO ON ART_CLAVE=DVE_ARTICULO" &
                " WHERE DVE_VENTA='" & ticket & "'"

            Base.daQuery(SQL, xcon, dsc, "venta")


            For ajas As Integer = 0 To dsc.Tables("venta").Rows.Count - 1
                sTotal = sTotal + CDbl(dsc.Tables("venta").Rows(ajas)("dve_precio"))
                If CDbl(dsc.Tables("venta").Rows(ajas)("dve_poriva")) > 0 Then
                    '  iva = iva + (((CDbl(spread.ActiveSheet.Cells(i, 6).Value)) / 100.0) * CDbl(spread.ActiveSheet.Cells(i, 0).Value) * CDbl(spread.ActiveSheet.Cells(i, 2).Value))
                    iva = iva + ((CDbl(dsc.Tables("venta").Rows(ajas)("dve_poriva"))) / 100.0) * ((CDbl(dsc.Tables("venta").Rows(ajas)("dve_cantidad")) * CDbl(dsc.Tables("venta").Rows(ajas)("dve_precio"))) / (1 + (CDbl(dsc.Tables("venta").Rows(ajas)("dve_PORIVA")) / 100.0)))
                ElseIf CDbl(dsc.Tables("venta").Rows(ajas)("dve_porieps")) > 0 Then
                    ieps = ieps + ((CDbl(dsc.Tables("venta").Rows(ajas)("dve_porieps"))) / 100.0) * ((CDbl(dsc.Tables("venta").Rows(ajas)("dve_cantidad")) * CDbl(dsc.Tables("venta").Rows(ajas)("dve_precio"))) / (1 + (CDbl(dsc.Tables("venta").Rows(ajas)("dve_PORIeps")) / 100.0)))
                Else
                    losqueno = losqueno + (CDbl(dsc.Tables("venta").Rows(ajas)("dve_cantidad")) * CDbl(dsc.Tables("venta").Rows(ajas)("dve_precio")))
                End If
            Next
            subt = CDbl(sTotal) - (iva) - ieps
            renglones.Add(centra("*REIMPRESION TICKET " & Now.ToShortDateString & " " & Now.ToShortTimeString & "*"))
            renglones.Add("-----------------------------------------")
            renglones.Add(" ")
            renglones.Add(centra(Globales.grupo))
            renglones.Add(centra(Globales.empresa))
            renglones.Add(centra(Globales.rfc))
            renglones.Add(centra(Globales.dir1))
            renglones.Add(centra(Globales.dir2))
            renglones.Add(centra(Globales.DIR3))
            renglones.Add(" ")

            Espacios = " "
            While Len("Fecha: " & dsc.Tables("venta").Rows(0)("ven_fecha") & Espacios & "Caja: " & Strings.Right(dsc.Tables("venta").Rows(0)("ven_usuario"), 1)) < Globales.numletras
                Espacios = " " & Espacios
            End While

            renglones.Add("Fecha: " & dsc.Tables("venta").Rows(0)("ven_fecha") & Espacios & "Caja: " & Strings.Right(dsc.Tables("venta").Rows(0)("ven_usuario"), 1))

            If IsDBNull(dsc.Tables("venta").Rows(0)("NombreCajera")) Then
                Cajera = "Cajera" & Mid(dsc.Tables("venta").Rows(0)("ven_usuario"), 4, 1)
            Else
                Cajera = dsc.Tables("venta").Rows(0)("NombreCajera").ToString.Trim
            End If
            renglones.Add("  ")

            Espacios = " "
            While Len("Cajero: " & Microsoft.VisualBasic.Strings.Left(Cajera, Globales.numletras - Len("Cajero: " & Espacios & "# Ticket: " & ticket)) & Espacios & "# Ticket: " & ticket) < Globales.numletras
                Espacios = " " & Espacios
            End While

            renglones.Add("Cajero: " & Microsoft.VisualBasic.Strings.Left(Cajera, Globales.numletras - Len("Cajero: " & Espacios & "# Ticket: " & ticket)) & Espacios & "# Ticket: " & ticket) 'renglones.add("Cajero: " & Cajera & Espacios & "# Ticket: " & ticket)

            renglones.Add("  ")
            renglones.Add("-----------------------------------------")
            'renglones.Add("CANT ARTICULO            P.U.    IMPORTE ")
            renglones.Add("ARTICULO          CANT   P.U.    IMPORTE ")
            renglones.Add("-----------------------------------------")

            For i = 0 To dsc.Tables("venta").Rows.Count - 1
                renglones.Add(Strings.Left(dsc.Tables("venta").Rows(i)("art_nomlargo"), Globales.numletras))
                renglones.Add(tabula(Math.Round(CDbl(dsc.Tables("venta").Rows(i)("DVE_Cantidad")), 3), dsc.Tables("venta").Rows(i)("art_nomlargo"), Format(CDbl(dsc.Tables("venta").Rows(i)("DVE_Precio")), "##0.00"), Format(CDbl(dsc.Tables("venta").Rows(i)("DVE_Precio")) * CDbl(dsc.Tables("venta").Rows(i)("DVE_Cantidad")), "###0.00")))
                'renglones.Add(tabula(IIf(InStr(dsc.Tables("venta").Rows(i)("dve_cantidad").ToString, ".") > 0, Format(Math.Round(dsc.Tables("venta").Rows(i)("dve_cantidad"), 2), "#,##0.0"), dsc.Tables("venta").Rows(i)("dve_cantidad")), dsc.Tables("venta").Rows(i)("art_nomlargo"), Format(CDbl(dsc.Tables("venta").Rows(i)("dve_precio")), "#,##0.00"), Format(CDbl(dsc.Tables("venta").Rows(i)("dve_total")), "#,##0.00")))
            Next

            renglones.Add("-----------------------------------------")

            guardaFooter(CDbl(dsc.Tables("VENTA").Rows(0)("VEN_TOTAL")), False, subt, ieps, iva)
            renglones.Add(Chr(13))

            oImpresion = New Impresion(renglones)
            oImpresion.imprime(False)

            On Error Resume Next

            Do While renglones.Count > 0
                renglones.Remove(1)
            Loop
        Else
            MsgBox("Seleccione el ticket a reimprimir.", vbExclamation, "Reimpresión de Tickets")
        End If
    End Sub
    Private Function centra(ByVal texto As String) As String
        If (Globales.numletras - Len(texto.Trim)) >= 0 Then
            centra = Space(Int((Globales.numletras - Len(texto.Trim)) / 2)) & texto.Trim
        Else
            centra = texto.Trim
        End If
    End Function
    Private Function tabula(ByVal cant As String, ByVal art As String, ByVal unit As String, ByVal importe As String) As String
        '33
        Dim Espacios As String
        Espacios = ""

        unit = "$" & unit
        importe = "$" & importe

        While unit.Length < 8
            unit = " " & unit
        End While

        While "$" & importe.Length < 9 '7
            importe = " " & importe
        End While

        While Len(Espacios & cant & " x " & unit & " " & importe) < Globales.numletras
            Espacios = Espacios & " "
        End While

        Return Espacios & cant & " x " & unit & " " & importe
    End Function

    Private Function TabulaMonto(ByVal Cant As String, ByVal unit As String, ByVal importe As String) As String

        'While unit.Length < 9
        'unit = " " & unit
        'End While

        While importe.Length < 11
            importe = " " & importe
        End While
        Return Cant & " x " & unit & " " & importe
        'Return cant & " " & Mid(art, 1, 20) & unit & " " & importe '16
    End Function

    Private Sub guardaFooter(ByVal sTotal As String, ByVal Cotizacion As Boolean, Optional ByVal sSubTotal As String = "", Optional ByVal sIEPS As String = "", Optional ByVal sIVA As String = "")
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer
        Dim tpago As Double
        Dim Espacios As String

        Dim oConv As New Conversion(CDbl(sTotal.Replace("$", "").Trim))

        'Imprime espacio en blanco
        renglones.Add("  ")
        Dim EspaciosMonto As String = Strings.Left("             ", 13 - Len(Format(CDbl(sTotal.Trim), "$##,##0.00")))
        Dim LonTextoTotal As String = Len(Format(CDbl(sTotal.Trim), "$##,##0.00"))
        'Zona Nueva IEPS IVA
        Espacios = " "
        While Len(Espacios & "Subtotal: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sSubTotal.Trim), "$##,##0.00"))) & Format(CDbl(sSubTotal.Trim), "$##,##0.00")) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add(Espacios & "Subtotal: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sSubTotal.Trim), "$##,##0.00"))) & Format(CDbl(sSubTotal.Trim), "$##,##0.00"))

        Espacios = " "
        While Len(Espacios & "IVA: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sIVA.Trim), "$##,##0.00"))) & Format(CDbl(sIVA.Trim), "$##,##0.00")) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add(Espacios & "IVA: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sIVA.Trim), "$##,##0.00"))) & Format(CDbl(sIVA.Trim), "$##,##0.00"))

        Espacios = " "
        While Len(Espacios & "IEPS: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sIEPS.Trim), "$##,##0.00"))) & Format(CDbl(sIEPS.Trim), "$##,##0.00")) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add(Espacios & "IEPS: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sIEPS.Trim), "$##,##0.00"))) & Format(CDbl(sIEPS.Trim), "$##,##0.00"))
        'Fin de Zona




        Espacios = " "
        While Len(Espacios & "Total: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sTotal.Trim), "$##,##0.00"))) & Format(CDbl(sTotal.Trim), "$##,##0.00")) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add(Espacios & "Total: " & EspaciosMonto & Strings.Left("             ", LonTextoTotal - Len(Format(CDbl(sTotal.Trim), "$##,##0.00"))) & Format(CDbl(sTotal.Trim), "$##,##0.00"))
        renglones.Add("  ")

        If "Son: ".Length + oConv.numeroEnLetras.Length <= Globales.numletras Then
            renglones.Add("Son: " & StrConv(oConv.numeroEnLetras, VbStrConv.ProperCase))
        Else
            Dim EspacioMargen As Integer

            Do Until Mid(oConv.numeroEnLetras, 1, Globales.numletras - 1 - 5 - EspacioMargen).EndsWith(" ")
                EspacioMargen += 1
            Loop

            renglones.Add("Son: " & StrConv(Mid(oConv.numeroEnLetras, 1, Globales.numletras - 1 - 5 - EspacioMargen), VbStrConv.ProperCase))
            Dim SpacesTxt As String
            SpacesTxt = "     "
            renglones.Add(SpacesTxt & StrConv(Mid(oConv.numeroEnLetras, Globales.numletras - 1 - 5 - EspacioMargen, 100), VbStrConv.ProperCase))
        End If

        renglones.Add("")
        If Not Cotizacion Then
            sql = "select sum(pago) as pago, tipo_pago, referencia, banco from ecformapago where referencia=" & CDbl(numt) & " group by tipo_pago,referencia,banco"
            Base.daQuery(sql, xcon, dsc, "pagos")
            'renglones.Add("-----------------------------------------")
            'renglones.Add("Su Pago:")
            'renglones.Add(Chr(13))

            If dsc.Tables("pagos").Rows.Count > 0 Then
                For i = 0 To dsc.Tables("pagos").Rows.Count - 1
                    Espacios = " "
                    While Len(Espacios & dsc.Tables("pagos").Rows(i)("tipo_pago") & ": " & Format(CDbl(dsc.Tables("pagos").Rows(i)("pago")), "$###,##0.00")) < Globales.numletras
                        Espacios = " " & Espacios
                    End While

                    renglones.Add(Espacios & dsc.Tables("pagos").Rows(i)("tipo_pago") & ": " & Format(CDbl(dsc.Tables("pagos").Rows(i)("pago")), "$###,##0.00"))
                    If dsc.Tables("pagos").Rows(i)("banco").ToString.Trim <> "" Then
                        Espacios = " "
                        While Len(Espacios & Strings.Left(dsc.Tables("pagos").Rows(i)("banco"), Globales.numletras)) < Globales.numletras
                            Espacios = " " & Espacios
                        End While
                        renglones.Add(Espacios & Strings.Left(dsc.Tables("pagos").Rows(i)("banco"), Globales.numletras))
                    End If

                    'renglones.Add(Mid(dsc.Tables("pagos").Rows(i)("tipo_pago") & Space(10), 1, 10) & "  " & Mid(dsc.Tables("pagos").Rows(i)("banco") & Space(10), 1, 10) & "   " & Format(CDbl(dsc.Tables("pagos").Rows(i)("pago")), "###,##0.00"))
                    tpago = tpago + CDbl(dsc.Tables("pagos").Rows(i)("pago"))
                Next
                Espacios = " "
                While Len(Espacios & "Cambio: " & Format((tpago - sTotal), "$###,##0.00")) < Globales.numletras
                    Espacios = " " & Espacios
                End While
                renglones.Add("")
                renglones.Add(Espacios & "Cambio: " & Format((tpago - sTotal), "$###,##0.00")) 'scambio
            End If
            renglones.Add(Chr(13))
            dsc.Tables.Remove("pagos")

            renglones.Add(centra("¡Muchas Gracias por su Compra!"))
            'renglones.Add("")

            'renglones.Add(centra("Monto Total incluye 16% IVA"))
            'renglones.Add(centra("   de Productos Gravados   "))

            renglones.Add("")
            renglones.Add(centra("**El importe de esta venta se incluye **"))
            renglones.Add(centra("      en la factura global del día      "))
        Else
            renglones.Add(centra("¡Muchas Gracias por su Cotización!"))
            renglones.Add("")

            'renglones.Add(centra("Monto Total incluye 16% IVA"))
            'renglones.Add(centra("   de Productos Gravados   "))

            renglones.Add("")
        End If


        renglones.Add("-----------------------------------------")
        renglones.Add(centra("*REIMPRESION TICKET " & Now.ToShortDateString & " " & Now.ToShortTimeString & "*"))
        ' renglones.Add(Chr(27) + Chr(112) + Chr(0) + Chr(40) & Chr())



    End Sub


    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_IMPRIMIR.Click
        GroupBox5.Text = "Reimprimir"
        RbTicket.Text = "Ticket"
        RbValeDetalle.Text = "Vale de Mercancía"
        RbTicket.Checked = True
        If FP_VENTAS.ActiveSheet.Rows(FP_VENTAS.ActiveSheet.ActiveRowIndex).ForeColor = Color.Blue Then
            RbValeDetalle.Enabled = True
        Else
            RbValeDetalle.Enabled = False
        End If
        Panel1.Top = Me.Height / 2 - Panel1.Height
        Panel1.Left = Me.Width / 2 - Panel1.Width
        Panel1.Visible = True
        RbTicket.Focus()
    End Sub

    Private Sub PINTA(ByVal renglon As Integer, ByVal color As Integer, ByVal tamaño As Integer)
        Dim acell As FarPoint.Win.Spread.Cell
        Dim I As Integer

        For I = 0 To FP_VENTAS.ActiveSheet.ColumnCount - 1
            acell = FP_VENTAS.ActiveSheet.Cells(renglon, I)
            ' acell.Font = New Font("MS Sans Serif", tamaño, FontStyle.Bold)
            Select Case color
                Case 1
                    acell.ForeColor = System.Drawing.Color.Black
                    acell.BackColor = System.Drawing.Color.LightBlue

                Case 2
                    acell.ForeColor = System.Drawing.Color.Black
                    acell.BackColor = System.Drawing.Color.White

            End Select
        Next I
    End Sub

    Private Sub FP_VENTAS_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FP_VENTAS.CellClick
        If e.ColumnHeader Then
            If SQLTickets <> "" Then
                Dim Fin As Integer
                Fin = InStr(SQLTickets, "order by")
                If Fin > 0 Then
                    SQLTickets = Strings.Left(SQLTickets, Fin + 7)

                    If SortDir = "" Then
                        SortDir = " asc"
                    ElseIf SortDir = " asc" Then
                        SortDir = " desc"
                    ElseIf SortDir = " desc" Then
                        SortDir = " asc"
                    End If

                    Select Case e.Column
                        Case 0
                            SQLTickets += " ven_tipov" & SortDir
                        Case 1
                            SQLTickets += " ven_usuario" & SortDir
                        Case 2
                            SQLTickets += " ven_id" & SortDir
                        Case 3, 4
                            SQLTickets += " ven_fecha" & SortDir
                        Case 5
                            SQLTickets += " ven_total" & SortDir
                        Case 6
                            SQLTickets += " ven_status" & SortDir
                        Case 7
                            SQLTickets += " ven_fechacanc" & SortDir
                        Case 8
                            SQLTickets += " ven_motivo" & SortDir
                        Case 9
                            SQLTickets += " ven_dscusuario" & SortDir
                        Case 10
                            SQLTickets += " pago" & SortDir
                        Case 11
                            SQLTickets += " cambio" & SortDir
                    End Select
                    rellenaventas(True)
                End If
            End If
        Else
            PINTA(e.Row, 1, FP_VENTAS, FilaEditando)
            FilaEditando = e.Row
        End If
    End Sub

    Private Sub CambiaSeleccion(ByVal Renglon As Integer)
        panel_conf.Visible = False
        If FP_VENTAS.ActiveSheet.Cells(Renglon, 2).Text <> "" Then
            Button1.Enabled = True
            BTN_IMPRIMIR.Enabled = True
            btn_exportar.Enabled = True
        Else
            Button1.Enabled = False
            BTN_IMPRIMIR.Enabled = False
            btn_exportar.Enabled = False
        End If

        If chk_detalle.Checked Then
            Call rellenadetalledet(FP_VENTAS.ActiveSheet.Cells(Renglon, 2).Value)
        Else
            Call rellenadetalle(FP_VENTAS.ActiveSheet.Cells(Renglon, 2).Value)
        End If

    End Sub

    Private Sub FP_VENTAS_EnterCell(sender As Object, e As EnterCellEventArgs) Handles FP_VENTAS.EnterCell
        PINTA(e.Row, 1, FP_VENTAS, FilaEditando)
        FilaEditando = e.Row
        CambiaSeleccion(e.Row)
    End Sub

    Private Sub PINTA1(ByVal renglon As Integer, ByVal color As Integer, ByVal tamaño As Integer)
        Dim acell As FarPoint.Win.Spread.Cell
        Dim I As Integer

        For I = 0 To FP_VENTASDET.ActiveSheet.ColumnCount - 1
            acell = FP_VENTASDET.ActiveSheet.Cells(renglon, I)
            ' acell.Font = New Font("MS Sans Serif", tamaño, FontStyle.Bold)
            Select Case color
                Case 1
                    acell.ForeColor = System.Drawing.Color.Black
                    acell.BackColor = System.Drawing.Color.LightBlue
                Case 2
                    acell.ForeColor = System.Drawing.Color.Black
                    acell.BackColor = System.Drawing.Color.White

            End Select
        Next I
    End Sub

    Private Sub FP_VENTASDETt_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        PINTA1(FP_VENTASDET.ActiveSheet.ActiveRowIndex, 2, 12)
        'FP_VENTASDET.ActiveSheet.ActiveRowIndex = e.Row
        PINTA1(e.Row, 1, 12)

    End Sub

    Private Sub FP_VENTASDET_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs)
        PINTA1(e.Row, 2, 12)
        'FP_VENTASDET.ActiveSheet.ActiveRowIndex = e.NewRow
        PINTA1(e.NewRow, 1, 12)

    End Sub

    Private Sub btn_aplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplica.Click
        panel_conf.Location = New Point(Me.Width / 2 - panel_conf.Width / 2, Me.Height / 2 - panel_conf.Height / 2)
        panel_conf.Visible = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        panel_conf.Visible = False
    End Sub

    Private Sub generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generar.Click
        rellenaventas()
    End Sub

    Private Sub rellenaventas(ByVal Optional VengoDeSort As Boolean = False)
        Dim dsc As New DataSet
        Dim i As Integer
        Dim filtro As String
        Dim PorProducto As String

        If Not VengoDeSort Then
            filtro = ""
            panel_conf.Visible = False
            If rb_canc.Checked Then
                filtro = "and ven_status=2"
            End If

            If rb_una.Checked Then
                filtro = filtro & " and ven_usuario='000" & txt_caja.Text & "'"
            End If

            If CheckBox1.Checked Then
                PorProducto = "join (select  dve_venta, UPC_DESCRIPCION from ecventadet join xupc on dve_upc=upc_upc join ecventa on dve_venta=ven_id where UPC_upc='" & txt_control.Text.Trim & "' or UPC_CODINV='" & txt_control.Text.Trim & "' and ven_fecha>='" & Format(FechaIni.Value, "yyyyMMdd") & "' and ven_fecha<='" & Format(DateAdd("d", 1, FechaFin.Value), "yyyyMMdd") & "') a on a.DVE_VENTA=ven_id "
            ElseIf CheckBox2.Checked Then
                PorProducto = "join TicketsClientes on ven_id=FolioTicket "
                filtro = filtro & " and ClienteID=" & CInt(txt_control.Text)
            Else
                PorProducto = ""
            End If

            'SQLTickets = "SELECT * FROM ECVENTA  WHERE VEN_FECHA>='" & dafecha(CDate(txt_Fechaini.Text)) & "'" &
            '    " AND VEN_FECHA<='" & dafecha(DateAdd("d", 1, CDate(txt_Fechafin.Text))) & "' " & filtro

            SQLTickets = "SELECT ven_id, ven_tipov,VEN_USUARIO, ven_fecha,ven_total,VEN_STATUS,VEN_FECHACANC,VEN_MOTIVO,VEN_DSCUSUARIO, isnull(sum(pago),0) pago, isnull(sum(pago),0)-ven_total cambio, case when exists (select dve_venta from ecventadete where dve_venta=ven_id) then '1' else '0' end as Vale FROM ECVENTA" &
        " Join ecformapago on ven_id=referencia " & PorProducto & "WHERE VEN_FECHA>='" & Format(FechaIni.Value, "yyyyMMdd") & "' AND VEN_FECHA<='" & Format(DateAdd("d", 1, FechaFin.Value), "yyyyMMdd") & "' " & filtro &
        " group by ven_id, ven_tipov,VEN_USUARIO, ven_fecha,ven_total,VEN_STATUS,VEN_FECHACANC,VEN_MOTIVO,VEN_DSCUSUARIO order by ven_fecha asc"
        End If


        FP_VENTAS.ActiveSheet.RowCount = 0

        Base.daQuery(SQLTickets, xcon, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = 0
        If dsc.Tables("ventas").Rows.Count > 0 Then
            Button1.Enabled = True
            BTN_IMPRIMIR.Enabled = True
            btn_exportar.Enabled = True
            FP_VENTAS.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTAS.ActiveSheet.Cells(i, 0).Value = dsc.Tables("ventas").Rows(i)("ven_tipov") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("ven_usuario") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 2).Value = dsc.Tables("ventas").Rows(i)("ven_id") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 3).Text = dsc.Tables("ventas").Rows(i)("ven_fecha") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 4).Value = dsc.Tables("ventas").Rows(i)("ven_fecha")
                FP_VENTAS.ActiveSheet.Cells(i, 5).Text = dsc.Tables("ventas").Rows(i)("ven_total") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 6).Value = IIf(CDbl(dsc.Tables("ventas").Rows(i)("ven_status")) = 2, "Cancelado", "")
                FP_VENTAS.ActiveSheet.Cells(i, 7).Text = dsc.Tables("ventas").Rows(i)("ven_fechacanc") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 8).Text = dsc.Tables("ventas").Rows(i)("ven_motivo") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 9).Text = dsc.Tables("ventas").Rows(i)("ven_dscusuario") & ""
                If dsc.Tables("ventas").Rows(i)("vale") <> 0 Then
                    FP_VENTAS.ActiveSheet.Rows(i).ForeColor = Color.Blue
                End If
                If CDbl(dsc.Tables("ventas").Rows(0)("pago")) > 0 Then
                    FP_VENTAS.ActiveSheet.Cells(i, 10).Text = dsc.Tables("ventas").Rows(i)("pago") & ""
                    FP_VENTAS.ActiveSheet.Cells(i, 11).Text = CDbl(dsc.Tables("ventas").Rows(i)("pago") & "") - CDbl(dsc.Tables("ventas").Rows(i)("ven_total") & "")
                End If

                'SQLTickets = "select isnull(sum(pago),0) pago from ecformapago where referencia='" & dsc.Tables("ventas").Rows(i)("ven_id") & "" & "'"
                'Base.daQuery(SQLTickets, xcon, dsc, "xxtabla")
                'If dsc.Tables("xxtabla").Rows.Count > 0 Then
                'If CDbl(dsc.Tables("xxtabla").Rows(0)("pago")) > 0 Then
                'FP_VENTAS.ActiveSheet.Cells(i, 10).Text = dsc.Tables("xxtabla").Rows(0)("pago") & ""
                'FP_VENTAS.ActiveSheet.Cells(i, 11).Text = CDbl(dsc.Tables("xxtabla").Rows(0)("pago") & "") - CDbl(dsc.Tables("ventas").Rows(i)("ven_total") & "")
                'End If
                'End If

                'dsc.Tables.Remove("xxtabla")
            Next i
            Dim sel As FarPoint.Win.Spread.Model.ISheetSelectionModel
            sel = FP_VENTAS.ActiveSheet.Models.Selection
            sel.SetSelection(0, 0, 1, 1)
            FilaEditando = 0
            CambiaSeleccion(0)
        Else
            MsgBox("No hay ventas con los criterios seleccionados.", vbInformation, "Reimpresión de Tickets")
        End If
        dsc.Tables.Remove("ventas")
        FP_VENTAS.Focus()
    End Sub


    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        GroupBox5.Text = "Exportar"
        RbTicket.Text = "Tickets"
        RbValeDetalle.Text = "Detalle de Ticket"
        RbTicket.Checked = True
        RbValeDetalle.Enabled = True
        Panel1.Top = Me.Height / 2 - Panel1.Height
        Panel1.Left = Me.Width / 2 - Panel1.Width
        Panel1.Visible = True
        RbTicket.Focus()
    End Sub
    Private Sub regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regresar.Click
        Me.Hide()
        foma.Show()
        Me.Dispose()
    End Sub

    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_caja.TextChanged
        rb_una.Checked = True
    End Sub

    Private Sub reimprimirVALE(ByVal ticket As String)
        Dim DSC As New DataSet
        Dim SQL As String
        Dim Espacios As String
        Dim oImpresion As Impresion
        Dim i As Integer
        Dim Cajero As String


        If ticket <> "" Then

            SQL = "select e.*, xupc.UPC_DESCRIPCION, ecventa.ven_fecha, ecventa.NombreCajera, ecventa.Ven_Usuario from ecventadete e join ecventa on ven_id=dve_venta join xupc on dve_upc=upc_upc where dve_venta='" & ticket & "'"

            Base.daQuery(SQL, xcon, DSC, "vale")
            If DSC.Tables("Vale").Rows.Count > 0 Then
                renglones.Add(centra("*REIMPRESION TICKET " & Now.ToShortDateString & " " & Now.ToShortTimeString & "*"))
                renglones.Add("-----------------------------------------")
                renglones.Add(" ")
                renglones.Add(centra(Globales.grupo))
                renglones.Add(centra(Globales.empresa))
                renglones.Add(centra(Globales.rfc))
                renglones.Add(centra(Globales.dir1))
                renglones.Add(centra(Globales.dir2))
                renglones.Add(centra(Globales.DIR3))
                renglones.Add(" ")

                Espacios = " "
                While Len("Fecha: " & DSC.Tables("vale").Rows(0)("ven_fecha") & Espacios & "Caja: " & Strings.Right(DSC.Tables("vale").Rows(0)("ven_usuario"), 1)) < Globales.numletras
                    Espacios = " " & Espacios
                End While

                renglones.Add("Fecha: " & DSC.Tables("vale").Rows(0)("ven_fecha") & Espacios & "Caja: " & Strings.Right(DSC.Tables("vale").Rows(0)("ven_usuario"), 1))

                Espacios = " "
                If IsDBNull(DSC.Tables("vale").Rows(0)("NombreCajera")) Then
                    Cajero = "Cajero " & Strings.Right(DSC.Tables("vale").Rows(0)("ven_usuario"), 1)
                Else
                    Cajero = DSC.Tables("vale").Rows(0)("NombreCajera")
                End If

                While Len("Cajero: " & Cajero & Espacios & "# Ticket: " & ticket) < Globales.numletras
                    Espacios = " " & Espacios
                End While


                renglones.Add(" ")
                renglones.Add("Cajero: " & Cajero & Espacios & "# Ticket: " & ticket)
                renglones.Add(" ")
                renglones.Add("----------------------------------------")
                renglones.Add(" VALE DE ENTREGA DE MERCANCIA PENDIENTE")
                renglones.Add("----------------------------------------")


                For i = 0 To DSC.Tables("Vale").Rows.Count - 1
                    renglones.Add(Strings.Left(DSC.Tables("Vale").Rows(i)("upc_descripcion"), Globales.numletras))
                    renglones.Add(tabula(Math.Round(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), 3), DSC.Tables("Vale").Rows(i)("upc_descripcion"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")), "##0.00"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")) * CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), "###0.00")))
                    'renglones.Add(tabula(Math.Round(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), 3), DSC.Tables("Vale").Rows(i)("upc_descripcion"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")), "##0.00"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")) * CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), "###0.00")))
                Next
                renglones.Add(" ")
                renglones.Add("-----------------------------------------")
                renglones.Add(centra("*REIMPRESION TICKET " & Now.ToShortDateString & " " & Now.ToShortTimeString & "*"))

                oImpresion = New Impresion(renglones)
                oImpresion.imprime(False)

                On Error Resume Next

                Do While renglones.Count > 0
                    renglones.Remove(1)
                Loop
            Else
                MsgBox("El ticket seleccionado no cuenta con Vale de Mercancía.", vbExclamation, "Reimpresion de Ticket")
            End If
            DSC.Tables.Remove("Vale")
        Else
            MsgBox("DEBE DE SELECCIONAR UN NUMERO DE TICKET A IMPRIMIR", vbExclamation)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 6).Value = "Cancelado" Then
            MsgBox("El ticket ya está cancelado.", MsgBoxStyle.Exclamation, "Cancelar Ticket")
            Exit Sub
        End If
        Dim OPCION As Integer
        Dim TICKET As String
        Dim importe As String
        Dim sql As String

        If Now.ToShortDateString <> CDate(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 3).Value) Then
            MsgBox("No se pueden cancelar tickets de otras fecha , sólo del día", MsgBoxStyle.Exclamation)
        Else

            TICKET = FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2).Value
            importe = FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 5).Value
            OPCION = MsgBox("El ticket " & TICKET & " por un importe de $" & importe & " será cancelado, desea cancelar el ticket ?", MsgBoxStyle.OkCancel)
            If OPCION = 1 Then
                Base.Ejecuta("UPDATE ECVENTA SET VEN_STATUS=2,VEN_DSCUSUARIO='" & Globales.nombreusuario & "',VEN_FECHACANC=GETDATE() , VEN_MOTIVO='" & TXT_MOTIVO.Text & "' WHERE VEN_ID=" & TICKET, xcon)
                Base.Ejecuta("UPDATE ECTARJETAS SET ESTATUS=2 WHERE TAR_VENTAID=" & TICKET, xcon)
                Base.Ejecuta("EXEC APLICAVENTAINVENTARIO " & TICKET & ",4", xcon)
                MsgBox("Ticket Cancelado", MsgBoxStyle.Information)
                sql = "update ECDETCLIENTEEMP SET DCLI_SALDO=Dcli_saldo-eccuentasxcob.cxc_totalvta " &
                " from ecDETCLIENTEEMP  inner join eccuentasxcob on eccuentasxcob.cxc_cliente=DCLI_CLAVE AND DCLI_EMPRESA=1 " &
                " where eccuentasxcob.cxc_folio =" & TICKET.Trim
                Base.Ejecuta(sql, xcon)
                sql = "update eccuentasxcob set cxc_estatus=2,cxc_saldo=0 where cxc_folio=" & TICKET.Trim
                Base.Ejecuta(sql, xcon)
                panel_motivo.Visible = False
                TXT_MOTIVO.Text = ""
                rellenaventas()
            Else
                MsgBox("Proceso Cancelado", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub chk_detalle_CheckedChanged(sender As Object, e As EventArgs) Handles chk_detalle.CheckedChanged
        If FP_VENTAS.ActiveSheet.Rows.Count > 0 Then
            If FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2).Text <> "" Then
                If chk_detalle.Checked Then
                    Call rellenadetalledet(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2).Value)
                Else
                    Call rellenadetalle(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2).Value)
                End If
            End If
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        panel_motivo.Visible = False
        TXT_MOTIVO.Text = ""
    End Sub

    Private Sub ImprimeTicket(Ticket As Integer, VieneDe As String)

        Dim ReportDoc As New ReportDocument


        If VieneDe = "Ticket" Then
            'ReportDoc.Load(Globales.DirReportes & "Ticket.rpt")
            ReportDoc.SetParameterValue("TicketPagos", Ticket, "Pagos")
        ElseIf VieneDe = "Vale" Then
            'ReportDoc.Load(Globales.DirReportes & "Vale.rpt")

        End If

        For Each subReport As ReportDocument In ReportDoc.Subreports
            For Each crTable As Table In subReport.Database.Tables
                Dim loi As TableLogOnInfo = crTable.LogOnInfo
                loi.ConnectionInfo.ServerName = Globales.sServidor
                loi.ConnectionInfo.UserID = Globales.sUsuarioBase
                loi.ConnectionInfo.Password = Globales.sClaveUsuario
                loi.ConnectionInfo.DatabaseName = Globales.sBaseDatos
                crTable.ApplyLogOnInfo(loi)
            Next
        Next

        For Each crTable As Table In ReportDoc.Database.Tables
            Dim loi As TableLogOnInfo = crTable.LogOnInfo
            loi.ConnectionInfo.ServerName = Globales.sServidor
            loi.ConnectionInfo.UserID = Globales.sUsuarioBase
            loi.ConnectionInfo.Password = Globales.sClaveUsuario
            loi.ConnectionInfo.DatabaseName = Globales.sBaseDatos

            crTable.ApplyLogOnInfo(loi)
        Next


        ReportDoc.SetParameterValue("TicketMain", Ticket)
        ReportDoc.SetParameterValue("Encabezado1", Globales.grupo)
        ReportDoc.SetParameterValue("Encabezado2", Globales.empresa)
        ReportDoc.SetParameterValue("Encabezado3", Globales.rfc)
        ReportDoc.SetParameterValue("Encabezado4", Globales.dir1)
        ReportDoc.SetParameterValue("Encabezado5", Globales.dir2)
        ReportDoc.SetParameterValue("Encabezado6", Globales.DIR3)
        ReportDoc.SetParameterValue("Reimpresion", True)
        If SortByDescripcion.Checked Then
            ReportDoc.SetParameterValue("SortingBy", "Descripción")
        ElseIf SortByRenglon.Checked Then
            ReportDoc.SetParameterValue("SortingBy", "Renglón")
        End If


        Dim PrSet As New Printing.PrinterSettings
        Dim PgSet As New Printing.PageSettings
        Dim LaSet As New PrintLayoutSettings

        Dim Impresora As String

        For Each Impresora In Printing.PrinterSettings.InstalledPrinters
            If InStr(Impresora.ToUpper, "TM") Then
                PrSet.PrinterName = Impresora
                Exit For
            End If
        Next Impresora


        PgSet.Margins.Bottom = 0
        PgSet.Margins.Left = 0
        PgSet.Margins.Right = 0

        ReportDoc.PrintToPrinter(PrSet, PgSet, False)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged
        If Not Corriendo Then
            Corriendo = True
            If sender.Checked = False Then
                BuscaArt.Text = ""
                txt_control.Text = ""
            Else
                If sender.Checked Then
                    If sender.name = "CheckBox1" Then
                        CheckBox2.Checked = False
                    ElseIf sender.name = "CheckBox2" Then
                        CheckBox1.Checked = False
                    End If
                ElseIf CheckBox2.Checked Then
                    CheckBox1.Checked = False
                End If
                Buscar()
            End If
            Corriendo = False
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Corriendo = True
        If CheckBox1.Checked = False And CheckBox2.Checked = False Then
            CheckBox1.Checked = True
        End If
        Buscar()
        Corriendo = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Panel1.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel1.Visible = False
        If GroupBox5.Text = "Reimprimir" Then
            If RbTicket.Checked Then
                Call reimprimir(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2).Value)
            Else
                If FP_VENTAS.ActiveSheet.Rows(FP_VENTAS.ActiveSheet.ActiveRowIndex).ForeColor = Color.Blue Then
                    Call reimprimirVALE(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2).Value)
                Else
                    MsgBox("Ticket no tiene vale de mercancía.", vbInformation, "Vale de Mercancía")
                End If
            End If
        Else
            If RbTicket.Checked Then
                GENERAL.rutinaexportaraexcel(FP_VENTAS, "Lista de Tickets de Venta ")
            Else
                GENERAL.rutinaexportaraexcel(FP_VENTASDET, "Reporte Detallado de Tickets de Venta  ")
            End If
        End If
    End Sub

    Private Sub Buscar()
        Dim FRBUSCAR As New busqueda
        If CheckBox1.Checked Then
            GENERAL.parametrosbusqueda(FRBUSCAR, "Artículos", "distinct case when upc_codinv='' then upc_upc else upc_codinv end UPC, upc_descripcion", "xupc", "upc_descripcion", "1", xcon, "UPC,Descripción", "100,300", "A,A", "1", "")
        ElseIf CheckBox2.Checked Then
            GENERAL.parametrosbusqueda(FRBUSCAR, "Precio Duarsa - Clientes Registrados", "cli_clave,cli_nombre", "ecclientes", "cli_nombre asc", "1", xcon, "Clave,Nombre", "50,200", "A,A", "1", "precioduarsa=1")
        End If

        FRBUSCAR.TXTCONTROL = Me.txt_control
        FRBUSCAR.ShowDialog()
        FRBUSCAR.Dispose()
        If txt_control.Text.Trim <> "" Then
            Dim dsc As New DataSet
            Dim sql As String
            If CheckBox1.Checked Then
                sql = "select upc_Descripcion Nombre from xupc where upc_upc='" & txt_control.Text & "'"
            ElseIf CheckBox2.Checked Then
                sql = "select cli_nombre Nombre from ecclientes where cli_clave='" & txt_control.Text & "'"
            End If

            Base.daQuery(sql, xcon, dsc, "Art")
            If dsc.Tables("Art").Rows.Count > 0 Then
                BuscaArt.Text = dsc.Tables("Art").Rows(0)("Nombre").ToString.Trim
            Else
                MsgBox(IIf(CheckBox1.Checked, "Artículo", "Cliente") & " Inexistente.", vbExclamation, "Reimpresión de Ticket")
                txt_control.Text = ""
                BuscaArt.Text = ""
            End If
            dsc.Tables.Remove("Art")
        End If
    End Sub

    Private Sub BuscarVenta()
        Dim FRBUSCAR As New busqueda
        GENERAL.parametrosbusqueda(FRBUSCAR, "ARTICULOS", "distinct case when upc_codinv='' then upc_upc else upc_codinv end UPC, upc_descripcion, ART_PRECIO1, ART_PRECIO2,ART_PRECIO3", "xupc join articulo on art_clave=upc_cveart", "upc_descripcion", "1", xcon, "UPC,Descripción,Precio1,Precio2,Precio3", "100,300,60,60,60", "A,A,$,$,$", "1", "")
                FRBUSCAR.TXTCONTROL = Me.txt_control
        FRBUSCAR.ShowDialog()
        FRBUSCAR.Dispose()
        If txt_control.Text.Trim <> "" Then
            Dim dsc As New DataSet
            Dim sql As String
            sql = "select upc_Descripcion from xupc where upc_upc='" & txt_control.Text & "'"
            Base.daQuery(sql, xcon, dsc, "Art")
            If dsc.Tables("Art").Rows.Count > 0 Then
                BuscaArt.Text = dsc.Tables("Art").Rows(0)("upc_descripcion").ToString.Trim
            Else
                MsgBox("Artículo Inexistente.", vbExclamation, "Reimpresión de Ticket")
                txt_control.Text = ""
                BuscaArt.Text = ""
            End If
            dsc.Tables.Remove("Art")
        End If
    End Sub

    Private Sub txt_caja_GotFocus(sender As Object, e As EventArgs) Handles txt_caja.GotFocus
        rb_una.Checked = True
    End Sub

    Private Sub FP_VENTAS_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles FP_VENTAS.SelectionChanged
        If e.Range.Row = -1 Then
            If FP_VENTAS.ActiveSheet.RowCount > 0 Then
                CambiaSeleccion(0)
            End If
        Else
            CambiaSeleccion(e.Range.Row)
        End If
    End Sub

    Private Sub Button8_LostFocus(sender As Object, e As EventArgs) Handles FP_VENTAS.GotFocus, FP_VENTASDET.GotFocus, chk_detalle.GotFocus, btn_aplica.GotFocus, generar.GotFocus, Button1.GotFocus, BTN_IMPRIMIR.GotFocus, btn_exportar.GotFocus, regresar.GotFocus
        panel_motivo.Visible = False
        panel_conf.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub Selecciona(FpSpread As FarPoint.Win.Spread.FpSpread)
        If FpSpread.ActiveSheet.RowCount <> 0 Then
            Dim range As CellRange
            Dim i As Integer
            Dim suma As Double = 0
            Dim min As Double = 1000000
            Dim max As Double = -1000000
            Dim simbolo As String = ""
            Dim cuenta As Integer = 0
            Dim CuentaTexto As Integer = 0
            Dim texto As Boolean = False
            Dim nodinero As Boolean = False
            Dim inicia, colum As Integer
            Dim HayTexto, HayDinero As Boolean

            Sumas.Text = ""

            inicia = 0
            colum = 1


            HayDinero = True

            For i = 0 To FpSpread.ActiveSheet.SelectionCount - 1
                range = FpSpread.ActiveSheet.GetSelection(i)

                If range.RowCount = 1 And range.ColumnCount = 1 And FpSpread.ActiveSheet.SelectionCount <= 1 Then
                    Sumas.Text = ""
                    Exit Sub
                End If


                Dim h, t As Integer
                h = FpSpread.ActiveSheet.ActiveColumnIndex

                For t = range.Row To range.Row + range.RowCount - 1
                    For h = range.Column To range.Column + range.ColumnCount - 1
                        If IsDBNull(FpSpread.ActiveSheet.Cells(t, h).Value) = False Then
                            If FpSpread.ActiveSheet.Cells(t, h).Text <> "" Then
                                CuentaTexto += 1
                                If IsNumeric(FpSpread.ActiveSheet.Cells(t, h).Value) Then
                                    suma += CDbl(FpSpread.ActiveSheet.Cells(t, h).Value)
                                    cuenta += 1
                                    If CDbl(FpSpread.ActiveSheet.Cells(t, h).Value) > max Then max = CDbl(FpSpread.ActiveSheet.Cells(t, h).Value)
                                    If CDbl(FpSpread.ActiveSheet.Cells(t, h).Value) < min Then min = CDbl(FpSpread.ActiveSheet.Cells(t, h).Value)
                                    If HayDinero Then
                                        If InStr(FpSpread.ActiveSheet.Cells(t, h).Text, "$") > 0 Then
                                            HayDinero = True
                                        Else
                                            HayDinero = False
                                        End If
                                    End If
                                Else
                                    HayTexto = True
                                End If
                            End If
                        End If
                    Next
                Next

                If i = FpSpread.ActiveSheet.SelectionCount - 1 Then
                    Sumas.Visible = True
                    If CuentaTexto > 0 Then
                        If Not HayTexto Then
                            If HayDinero Then
                                Sumas.Text = "Promedio: " & FormatCurrency(suma / cuenta, 2) & " | Recuento: " & FormatNumber(CuentaTexto, 2) & " | Min: " & FormatCurrency(min, 2) & " | Max: " & FormatCurrency(max, 2) & " | Suma: " & FormatCurrency(suma, 2)
                            Else
                                Sumas.Text = "Promedio: " & FormatNumber(suma / cuenta, 2) & " | Recuento: " & FormatNumber(CuentaTexto, 2) & " | Min: " & FormatNumber(min, 2) & " | Max: " & FormatNumber(max, 2) & " | Suma: " & FormatNumber(suma, 2)
                            End If
                        Else
                            Sumas.Text = "Recuento: " & FormatNumber(CuentaTexto, 2)
                        End If

                    End If


                End If
            Next
        End If
    End Sub

    Private Sub FP_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles FP_VENTAS.SelectionChanged, FP_VENTASDET.SelectionChanged
        Selecciona(sender)
    End Sub

    Private Sub FP_VENTASDET_EnterCell(sender As Object, e As EnterCellEventArgs) Handles FP_VENTASDET.EnterCell
        PINTA(e.Row, 1, FP_VENTASDET, FilaEditandoDet)
        FilaEditandoDet = e.Row
    End Sub
End Class











