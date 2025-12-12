Imports System.Data.SqlClient

Imports FarPoint.Win.Spread.CellType
Public Class reimprime2
    Inherits System.Windows.Forms.Form
    Dim xcon As SqlConnection
    Dim foma As Form
    Dim iva As Double
    Dim losqueno As Double
    Private renglones As New Collection
    Private sDireccion() As String
    Private sNomina, sNombre, sTotal As String
    Private line As Char = Chr(10)
    Private scambio As String
    Friend WithEvents FP_VENTAS As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FP_VENTAS_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents FP_VENTASDET As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FP_VENTASDET_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents panel_conf As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rb_todas As System.Windows.Forms.RadioButton
    Friend WithEvents rb_una As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_ttickets As System.Windows.Forms.RadioButton
    Friend WithEvents rb_canc As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_aplica As System.Windows.Forms.Button
    Friend WithEvents txt_Fechafin As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Fechaini As System.Windows.Forms.TextBox
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BTN_IMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents txt_clave As System.Windows.Forms.TextBox
    Friend WithEvents panel_motivo As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TXT_MOTIVO As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
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
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim EnhancedColumnHeaderRenderer7 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim EnhancedRowHeaderRenderer6 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim NamedStyle3 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer1 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle4 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType1 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin1 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim NamedStyle5 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim EnhancedColumnHeaderRenderer8 As FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer()
        Dim NamedStyle6 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer2 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle7 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType2 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim EnhancedFocusIndicatorRenderer1 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer1 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim NamedStyle8 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim EnhancedRowHeaderRenderer7 As FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer = New FarPoint.Win.Spread.CellType.EnhancedRowHeaderRenderer()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType3 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim DateTimeCellType1 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reimprime))
        Dim DateTimeCellType2 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim NumberCellType4 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim DateTimeCellType3 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType3 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim CurrencyCellType1 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim CurrencyCellType2 As FarPoint.Win.Spread.CellType.CurrencyCellType = New FarPoint.Win.Spread.CellType.CurrencyCellType()
        Dim NamedStyle9 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim NamedStyle10 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("RowHeaderEnhanced")
        Dim NamedStyle11 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("CornerEnhanced")
        Dim EnhancedCornerRenderer3 As FarPoint.Win.Spread.CellType.EnhancedCornerRenderer = New FarPoint.Win.Spread.CellType.EnhancedCornerRenderer()
        Dim NamedStyle12 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("DataAreaDefault")
        Dim GeneralCellType3 As FarPoint.Win.Spread.CellType.GeneralCellType = New FarPoint.Win.Spread.CellType.GeneralCellType()
        Dim SpreadSkin2 As FarPoint.Win.Spread.SpreadSkin = New FarPoint.Win.Spread.SpreadSkin()
        Dim EnhancedFocusIndicatorRenderer2 As FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer = New FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer()
        Dim EnhancedInterfaceRenderer2 As FarPoint.Win.Spread.EnhancedInterfaceRenderer = New FarPoint.Win.Spread.EnhancedInterfaceRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim TextCellType4 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim NumberCellType5 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType6 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType7 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Me.FP_VENTAS = New FarPoint.Win.Spread.FpSpread()
        Me.FP_VENTAS_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.FP_VENTASDET = New FarPoint.Win.Spread.FpSpread()
        Me.FP_VENTASDET_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.panel_conf = New System.Windows.Forms.Panel()
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rb_ttickets = New System.Windows.Forms.RadioButton()
        Me.rb_canc = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
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
        CType(Me.FP_VENTAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_VENTAS_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_VENTASDET, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_VENTASDET_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_conf.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_motivo.SuspendLayout()
        Me.SuspendLayout()
        EnhancedColumnHeaderRenderer1.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer1.Name = "EnhancedColumnHeaderRenderer1"
        EnhancedColumnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer1.TextRotationAngle = 0.0R
        EnhancedRowHeaderRenderer1.Name = "EnhancedRowHeaderRenderer1"
        EnhancedRowHeaderRenderer1.TextRotationAngle = 0.0R
        EnhancedColumnHeaderRenderer2.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer2.Name = "EnhancedColumnHeaderRenderer2"
        EnhancedColumnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer2.TextRotationAngle = 0.0R
        EnhancedColumnHeaderRenderer3.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer3.Name = "EnhancedColumnHeaderRenderer3"
        EnhancedColumnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer3.TextRotationAngle = 0.0R
        EnhancedRowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer2.Name = "EnhancedRowHeaderRenderer2"
        EnhancedRowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer2.TextRotationAngle = 0.0R
        EnhancedColumnHeaderRenderer4.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer4.Name = "EnhancedColumnHeaderRenderer4"
        EnhancedColumnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer4.TextRotationAngle = 0.0R
        EnhancedRowHeaderRenderer3.Name = "EnhancedRowHeaderRenderer3"
        EnhancedRowHeaderRenderer3.TextRotationAngle = 0.0R
        EnhancedColumnHeaderRenderer5.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer5.Name = "EnhancedColumnHeaderRenderer5"
        EnhancedColumnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer5.TextRotationAngle = 0.0R
        EnhancedRowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer4.Name = "EnhancedRowHeaderRenderer4"
        EnhancedRowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer4.TextRotationAngle = 0.0R
        EnhancedColumnHeaderRenderer6.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer6.Name = "EnhancedColumnHeaderRenderer6"
        EnhancedColumnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer6.TextRotationAngle = 0.0R
        EnhancedRowHeaderRenderer5.Name = "EnhancedRowHeaderRenderer5"
        EnhancedRowHeaderRenderer5.TextRotationAngle = 0.0R
        '
        'FP_VENTAS
        '
        Me.FP_VENTAS.AccessibleDescription = "FP_VENTAS, Sheet1, Row 0, Column 0, "
        Me.FP_VENTAS.BackColor = System.Drawing.SystemColors.Control
        Me.FP_VENTAS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTAS.Location = New System.Drawing.Point(12, 104)
        Me.FP_VENTAS.Name = "FP_VENTAS"
        NamedStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle1.Locked = False
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        EnhancedColumnHeaderRenderer7.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer7.Name = ""
        EnhancedColumnHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer7.TextRotationAngle = 0.0R
        NamedStyle1.Renderer = EnhancedColumnHeaderRenderer7
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        EnhancedRowHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control
        EnhancedRowHeaderRenderer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedRowHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedRowHeaderRenderer6.Name = ""
        EnhancedRowHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedRowHeaderRenderer6.TextRotationAngle = 0.0R
        NamedStyle2.Renderer = EnhancedRowHeaderRenderer6
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
        Me.FP_VENTAS.Size = New System.Drawing.Size(989, 316)
        NamedStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle5.Locked = False
        NamedStyle5.NoteIndicatorColor = System.Drawing.Color.Red
        EnhancedColumnHeaderRenderer8.ActiveBackgroundColor = System.Drawing.Color.LightSteelBlue
        EnhancedColumnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control
        EnhancedColumnHeaderRenderer8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EnhancedColumnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText
        EnhancedColumnHeaderRenderer8.Name = ""
        EnhancedColumnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No
        EnhancedColumnHeaderRenderer8.TextRotationAngle = 0.0R
        NamedStyle5.Renderer = EnhancedColumnHeaderRenderer8
        NamedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        SpreadSkin1.ColumnHeaderDefaultStyle = NamedStyle5
        NamedStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle6.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle6.Renderer = EnhancedCornerRenderer2
        NamedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        SpreadSkin1.CornerDefaultStyle = NamedStyle6
        NamedStyle7.BackColor = System.Drawing.SystemColors.Window
        NamedStyle7.CellType = GeneralCellType2
        NamedStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle7.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle7.Renderer = GeneralCellType2
        SpreadSkin1.DefaultStyle = NamedStyle7
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
        NamedStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle8.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle8.NoteIndicatorColor = System.Drawing.Color.Red
        EnhancedRowHeaderRenderer7.Name = ""
        EnhancedRowHeaderRenderer7.TextRotationAngle = 0.0R
        NamedStyle8.Renderer = EnhancedRowHeaderRenderer7
        NamedStyle8.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        SpreadSkin1.RowHeaderDefaultStyle = NamedStyle8
        SpreadSkin1.ScrollBarRenderer = EnhancedScrollBarRenderer1
        SpreadSkin1.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FP_VENTAS.Skin = SpreadSkin1
        Me.FP_VENTAS.TabIndex = 568
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
        Me.FP_VENTAS_Sheet1.Columns.Get(0).Label = "Tipo Venta"
        Me.FP_VENTAS_Sheet1.Columns.Get(0).Locked = True
        NumberCellType2.DecimalPlaces = 2
        Me.FP_VENTAS_Sheet1.Columns.Get(1).CellType = NumberCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Label = "Caja"
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(1).Width = 47.0!
        NumberCellType3.DecimalPlaces = 0
        NumberCellType3.MaximumValue = 10000000.0R
        NumberCellType3.MinimumValue = -10000000.0R
        Me.FP_VENTAS_Sheet1.Columns.Get(2).CellType = NumberCellType3
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Label = "Ticket"
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(2).Width = 75.0!
        DateTimeCellType1.Calendar = CType(resources.GetObject("DateTimeCellType1.Calendar"), System.Globalization.Calendar)
        DateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText
        DateTimeCellType1.DateDefault = New Date(2011, 4, 5, 11, 16, 53, 0)
        DateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999")
        DateTimeCellType1.TimeDefault = New Date(2011, 4, 5, 11, 16, 53, 0)
        Me.FP_VENTAS_Sheet1.Columns.Get(3).CellType = DateTimeCellType1
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
        Me.FP_VENTAS_Sheet1.Columns.Get(4).Label = "Hora"
        Me.FP_VENTAS_Sheet1.Columns.Get(4).Width = 79.0!
        NumberCellType4.DecimalPlaces = 2
        Me.FP_VENTAS_Sheet1.Columns.Get(5).CellType = NumberCellType4
        Me.FP_VENTAS_Sheet1.Columns.Get(5).Label = "Total"
        Me.FP_VENTAS_Sheet1.Columns.Get(5).Width = 80.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(6).CellType = TextCellType1
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
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Label = "Fecha Cancelación"
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(7).Width = 103.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(8).CellType = TextCellType2
        Me.FP_VENTAS_Sheet1.Columns.Get(8).Label = "Motivo Cancelación"
        Me.FP_VENTAS_Sheet1.Columns.Get(8).Width = 114.0!
        Me.FP_VENTAS_Sheet1.Columns.Get(9).CellType = TextCellType3
        Me.FP_VENTAS_Sheet1.Columns.Get(9).Label = "Autorización"
        Me.FP_VENTAS_Sheet1.Columns.Get(9).Locked = True
        Me.FP_VENTAS_Sheet1.Columns.Get(9).Width = 174.0!
        CurrencyCellType1.DecimalPlaces = 2
        CurrencyCellType1.DecimalSeparator = "."
        CurrencyCellType1.Separator = ","
        CurrencyCellType1.ShowCurrencySymbol = False
        CurrencyCellType1.ShowSeparator = True
        Me.FP_VENTAS_Sheet1.Columns.Get(10).CellType = CurrencyCellType1
        Me.FP_VENTAS_Sheet1.Columns.Get(10).Label = "Su pago"
        Me.FP_VENTAS_Sheet1.Columns.Get(10).Width = 101.0!
        CurrencyCellType2.DecimalPlaces = 2
        CurrencyCellType2.DecimalSeparator = "."
        CurrencyCellType2.Separator = ","
        CurrencyCellType2.ShowCurrencySymbol = False
        CurrencyCellType2.ShowSeparator = True
        Me.FP_VENTAS_Sheet1.Columns.Get(11).CellType = CurrencyCellType2
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
        Me.FP_VENTASDET.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.FP_VENTASDET.BackColor = System.Drawing.SystemColors.Control
        Me.FP_VENTASDET.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FP_VENTASDET.Location = New System.Drawing.Point(7, 452)
        Me.FP_VENTASDET.Name = "FP_VENTASDET"
        NamedStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle9.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle9.Locked = False
        NamedStyle9.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle9.Renderer = EnhancedColumnHeaderRenderer6
        NamedStyle9.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(247, Byte), Integer))
        NamedStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle10.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle10.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle10.Renderer = EnhancedRowHeaderRenderer5
        NamedStyle10.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(233, Byte), Integer))
        NamedStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        NamedStyle11.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        NamedStyle11.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle11.Renderer = EnhancedCornerRenderer3
        NamedStyle11.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        NamedStyle12.BackColor = System.Drawing.SystemColors.Window
        NamedStyle12.CellType = GeneralCellType3
        NamedStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        NamedStyle12.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle12.Renderer = GeneralCellType3
        Me.FP_VENTASDET.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle9, NamedStyle10, NamedStyle11, NamedStyle12})
        Me.FP_VENTASDET.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FP_VENTASDET.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FP_VENTASDET_Sheet1})
        Me.FP_VENTASDET.Size = New System.Drawing.Size(555, 253)
        SpreadSkin2.ColumnHeaderDefaultStyle = NamedStyle9
        SpreadSkin2.CornerDefaultStyle = NamedStyle11
        SpreadSkin2.DefaultStyle = NamedStyle12
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
        SpreadSkin2.RowHeaderDefaultStyle = NamedStyle10
        SpreadSkin2.ScrollBarRenderer = EnhancedScrollBarRenderer2
        SpreadSkin2.SelectionRenderer = New FarPoint.Win.Spread.DefaultSelectionRenderer()
        Me.FP_VENTASDET.Skin = SpreadSkin2
        Me.FP_VENTASDET.TabIndex = 570
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
        NumberCellType5.DecimalPlaces = 2
        Me.FP_VENTASDET_Sheet1.Columns.Get(2).CellType = NumberCellType5
        Me.FP_VENTASDET_Sheet1.Columns.Get(2).Label = "Cantidad"
        Me.FP_VENTASDET_Sheet1.Columns.Get(2).Width = 71.0!
        NumberCellType6.DecimalPlaces = 2
        NumberCellType6.DecimalSeparator = "."
        NumberCellType6.Separator = ","
        NumberCellType6.ShowSeparator = True
        Me.FP_VENTASDET_Sheet1.Columns.Get(3).CellType = NumberCellType6
        Me.FP_VENTASDET_Sheet1.Columns.Get(3).Label = "Precio"
        Me.FP_VENTASDET_Sheet1.Columns.Get(3).Width = 103.0!
        NumberCellType7.DecimalPlaces = 2
        NumberCellType7.DecimalSeparator = "."
        NumberCellType7.Separator = ","
        NumberCellType7.ShowSeparator = True
        Me.FP_VENTASDET_Sheet1.Columns.Get(4).CellType = NumberCellType7
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
        Me.panel_conf.Location = New System.Drawing.Point(270, 136)
        Me.panel_conf.Name = "panel_conf"
        Me.panel_conf.Size = New System.Drawing.Size(568, 310)
        Me.panel_conf.TabIndex = 573
        Me.panel_conf.Visible = False
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
        Me.txt_clave.Text = "1"
        '
        'rb_todas
        '
        Me.rb_todas.AutoSize = True
        Me.rb_todas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_todas.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_todas.Location = New System.Drawing.Point(27, 37)
        Me.rb_todas.Name = "rb_todas"
        Me.rb_todas.Size = New System.Drawing.Size(101, 18)
        Me.rb_todas.TabIndex = 537
        Me.rb_todas.Text = "Todas las Cajas"
        Me.rb_todas.UseVisualStyleBackColor = True
        '
        'rb_una
        '
        Me.rb_una.AutoSize = True
        Me.rb_una.Checked = True
        Me.rb_una.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_una.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_una.Location = New System.Drawing.Point(27, 56)
        Me.rb_una.Name = "rb_una"
        Me.rb_una.Size = New System.Drawing.Size(68, 18)
        Me.rb_una.TabIndex = 538
        Me.rb_una.TabStop = True
        Me.rb_una.Text = "Una Caja"
        Me.rb_una.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_ttickets)
        Me.GroupBox1.Controls.Add(Me.rb_canc)
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
        Me.rb_ttickets.Location = New System.Drawing.Point(20, 42)
        Me.rb_ttickets.Name = "rb_ttickets"
        Me.rb_ttickets.Size = New System.Drawing.Size(108, 18)
        Me.rb_ttickets.TabIndex = 537
        Me.rb_ttickets.TabStop = True
        Me.rb_ttickets.Text = "Todos los Tickets"
        Me.rb_ttickets.UseVisualStyleBackColor = True
        '
        'rb_canc
        '
        Me.rb_canc.AutoSize = True
        Me.rb_canc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_canc.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rb_canc.Location = New System.Drawing.Point(20, 60)
        Me.rb_canc.Name = "rb_canc"
        Me.rb_canc.Size = New System.Drawing.Size(143, 18)
        Me.rb_canc.TabIndex = 538
        Me.rb_canc.Text = "Sólo Tickets Cancelados"
        Me.rb_canc.UseVisualStyleBackColor = True
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
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(680, 546)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 45)
        Me.Label5.TabIndex = 572
        Me.Label5.Text = "DEFINIR CONSULTA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_aplica
        '
        Me.btn_aplica.BackColor = System.Drawing.Color.White
        Me.btn_aplica.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.configurar
        Me.btn_aplica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_aplica.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplica.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_aplica.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aplica.Location = New System.Drawing.Point(683, 495)
        Me.btn_aplica.Name = "btn_aplica"
        Me.btn_aplica.Size = New System.Drawing.Size(52, 48)
        Me.btn_aplica.TabIndex = 571
        Me.btn_aplica.Text = " "
        Me.btn_aplica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aplica.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(756, 554)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 35)
        Me.Label2.TabIndex = 579
        Me.Label2.Text = "GENERAR CONSULTA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label25.Location = New System.Drawing.Point(617, 661)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(98, 46)
        Me.Label25.TabIndex = 577
        Me.Label25.Text = "EXPORTAR DATOS LISTA TICKETS"
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
        Me.btn_exportar.Location = New System.Drawing.Point(639, 609)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(52, 48)
        Me.btn_exportar.TabIndex = 576
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
        Me.generar.Location = New System.Drawing.Point(763, 495)
        Me.generar.Name = "generar"
        Me.generar.Size = New System.Drawing.Size(52, 48)
        Me.generar.TabIndex = 574
        Me.generar.Text = " "
        Me.generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.generar.UseVisualStyleBackColor = False
        '
        'regresar
        '
        Me.regresar.BackColor = System.Drawing.Color.White
        Me.regresar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.regresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.regresar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regresar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.regresar.Location = New System.Drawing.Point(918, 609)
        Me.regresar.Name = "regresar"
        Me.regresar.Size = New System.Drawing.Size(52, 48)
        Me.regresar.TabIndex = 575
        Me.regresar.Text = " "
        Me.regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.regresar.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label27.Location = New System.Drawing.Point(915, 660)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 35)
        Me.Label27.TabIndex = 578
        Me.Label27.Text = "MENU ANTERIOR"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(827, 554)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 35)
        Me.Label3.TabIndex = 581
        Me.Label3.Text = "CANCELAR TICKET"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.borrar
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(830, 495)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 48)
        Me.Button1.TabIndex = 580
        Me.Button1.Tag = "Exportar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chk_detalle
        '
        Me.chk_detalle.AutoSize = True
        Me.chk_detalle.Checked = True
        Me.chk_detalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_detalle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_detalle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.chk_detalle.Location = New System.Drawing.Point(816, 68)
        Me.chk_detalle.Name = "chk_detalle"
        Me.chk_detalle.Size = New System.Drawing.Size(184, 18)
        Me.chk_detalle.TabIndex = 582
        Me.chk_detalle.Text = "Detalle  de Artículos por Sabores"
        Me.chk_detalle.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(12, 423)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(544, 26)
        Me.Label4.TabIndex = 583
        Me.Label4.Text = "      Detalle de Artículos Registrados en Ticket de Venta         "
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(104, 86)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 584
        Me.PictureBox1.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Gray
        Me.Label22.Location = New System.Drawing.Point(122, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(177, 21)
        Me.Label22.TabIndex = 586
        Me.Label22.Text = "Administración de Cajas"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(122, 60)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(243, 26)
        Me.Label23.TabIndex = 585
        Me.Label23.Text = "Administración de Tickets"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGray
        Me.Label8.Location = New System.Drawing.Point(734, 711)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(262, 15)
        Me.Label8.TabIndex = 587
        Me.Label8.Text = "Derechos Reservados Estrategias Competitivas 2011"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(721, 660)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 47)
        Me.Label10.TabIndex = 589
        Me.Label10.Text = "EXPORTAR DETALLE TICKET"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.flechaadelante
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(724, 609)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(52, 48)
        Me.Button2.TabIndex = 588
        Me.Button2.Tag = "Exportar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(792, 660)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 47)
        Me.Label13.TabIndex = 591
        Me.Label13.Text = "REIMPRIMIR TICKET"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_IMPRIMIR
        '
        Me.BTN_IMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTN_IMPRIMIR.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.imprimir1
        Me.BTN_IMPRIMIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_IMPRIMIR.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_IMPRIMIR.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BTN_IMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_IMPRIMIR.Location = New System.Drawing.Point(804, 609)
        Me.BTN_IMPRIMIR.Name = "BTN_IMPRIMIR"
        Me.BTN_IMPRIMIR.Size = New System.Drawing.Size(52, 48)
        Me.BTN_IMPRIMIR.TabIndex = 590
        Me.BTN_IMPRIMIR.Tag = "Exportar"
        Me.BTN_IMPRIMIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_IMPRIMIR.UseVisualStyleBackColor = False
        '
        'panel_motivo
        '
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
        Me.Label17.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Location = New System.Drawing.Point(553, 182)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 35)
        Me.Label17.TabIndex = 586
        Me.Label17.Text = "REGRESAR"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(499, 173)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(48, 46)
        Me.Button5.TabIndex = 585
        Me.Button5.Tag = "Salir"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(392, 180)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 35)
        Me.Label16.TabIndex = 583
        Me.Label16.Text = "REALIZAR CANCELACION"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.borrar
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(333, 170)
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
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
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
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(38, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(195, 24)
        Me.Label14.TabIndex = 546
        Me.Label14.Text = "Indique el Motivo de la Cancelación:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'reimprime
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1010, 732)
        Me.Controls.Add(Me.panel_motivo)
        Me.Controls.Add(Me.panel_conf)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.BTN_IMPRIMIR)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.FP_VENTASDET)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "reimprime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración De Tickets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FP_VENTAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_VENTAS_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_VENTASDET, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_VENTASDET_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_conf.ResumeLayout(False)
        Me.panel_conf.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_motivo.ResumeLayout(False)
        Me.panel_motivo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) & _
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

        txt_Fechaini.Text = DateTime.Now.ToShortDateString
        txt_Fechafin.Text = DateTime.Now.ToShortDateString

    End Sub




    Private Sub rellenadetalledet(ByVal venta As Integer)
        Dim sql As String
        Dim dsc As New DataSet

        Dim i As Integer

        sql = "select * from ecventadet inner join xupc on upc_upc=dve_upc inner join articulo on art_clave=upc_cveart" & _
              " where dve_venta=" & venta & " ORDER BY DVE_renglon"

        FP_VENTASDET.ActiveSheet.RowCount = 0
        Base.daQuery(sql, xcon, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
        If dsc.Tables("ventas").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTASDET.ActiveSheet.Cells(i, 0).Text = dsc.Tables("ventas").Rows(i)("dve_articulo") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("upc_descripcion") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 2).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_cantidad")), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 3).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_precio") & ""), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 4).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_total") & ""), "###,##0.00")
            Next i
        End If

        dsc.Tables.Remove("ventas")

    End Sub



    Private Sub rellenadetalle(ByVal venta As Integer)
        Dim sql As String
        Dim dsc As New DataSet

        Dim i As Integer

        sql = "select * from ecdetventa inner join articulo on art_clave=dve_articulo" & _
              " and dve_venta=" & venta & " ORDER BY DVE_renglon"

        FP_VENTASDET.ActiveSheet.RowCount = 0
        Base.daQuery(sql, xcon, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
        If dsc.Tables("ventas").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTASDET.ActiveSheet.Cells(i, 0).Value = dsc.Tables("ventas").Rows(i)("dve_articulo") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("art_nomlargo") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 2).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_cantidad")), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 3).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_precio") & ""), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 4).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_total") & ""), "###,##0.00")
            Next i
        End If

        dsc.Tables.Remove("ventas")

    End Sub

    Private Sub fp_ventas_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FP_VENTAS.CellDoubleClick
        If chk_detalle.Checked Then
            Call rellenadetalledet(FP_VENTAS.ActiveSheet.Cells(e.Row, 2).Value)
        Else
            Call rellenadetalle(FP_VENTAS.ActiveSheet.Cells(e.Row, 2).Value)
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        panel_motivo.Visible = True
        panel_motivo.BringToFront()

    End Sub

    Private Sub reimprimir(ByVal ticket As String)

        Dim dsc As New DataSet
        Dim SQL As String
        Dim oImpresion As Impresion
        numt = ticket
        Dim i As Integer
        Dim limite As Integer
        losqueno = 0
        iva = 0
        'ENCABEZADO
        If ticket <> "" Then


            SQL = "SELECT * FROM ECDETVENTA" & _
                " INNER JOIN ECVENTA ON VEN_ID=DVE_VENTA " & _
                " INNER JOIN ARTICULO ON ART_CLAVE=DVE_ARTICULO" & _
                " WHERE DVE_VENTA='" & ticket & "'"

            Base.daQuery(SQL, xcon, dsc, "venta")


            For ajas As Integer = 0 To dsc.Tables("venta").Rows.Count - 1

                If CDbl(dsc.Tables("venta").Rows(ajas)("dve_poriva")) > 0 Then
                    '  iva = iva + (((CDbl(spread.ActiveSheet.Cells(i, 6).Value)) / 100) * CDbl(spread.ActiveSheet.Cells(i, 0).Value) * CDbl(spread.ActiveSheet.Cells(i, 2).Value))
                    iva = iva + ((CDbl(dsc.Tables("venta").Rows(ajas)("dve_poriva"))) / 100) * ((CDbl(dsc.Tables("venta").Rows(ajas)("dve_cantidad")) * CDbl(dsc.Tables("venta").Rows(ajas)("dve_precio"))) / (1 + (CDbl(dsc.Tables("venta").Rows(ajas)("dve_PORIVA")) / 100)))

                Else
                    losqueno = losqueno + (CDbl(dsc.Tables("venta").Rows(ajas)("dve_cantidad")) * CDbl(dsc.Tables("venta").Rows(ajas)("dve_precio")))
                End If
            Next
     renglones.Add(centra(Globales.grupo))
            renglones.Add(centra(Globales.empresa))
            renglones.Add(centra(Globales.rfc))
            renglones.Add(centra(Globales.DIR3))
            renglones.Add(centra(Globales.dir2))
            renglones.Add(centra(Globales.dir1))
            renglones.Add(centra(Globales.CIUDAD))
            
            renglones.Add("           ")
            renglones.Add("  ")
            renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString)
            renglones.Add("Cajero: Cajera" & Mid(dsc.Tables("venta").Rows(0)("ven_usuario"), 4, 1))
            renglones.Add("  ")
            renglones.Add("                   # ticket: " & ticket)

            renglones.Add("  ")
            renglones.Add("---------------------------------")
            renglones.Add("CANT ARTICULO       P.U.  IMPORTE")
            renglones.Add("---------------------------------")

            renglones.Add("  ")


            For i = 0 To dsc.Tables("venta").Rows.Count - 1
                renglones.Add(tabula(Format(CDbl(dsc.Tables("venta").Rows(i)("dve_cantidad")), "#0"), Mid(dsc.Tables("venta").Rows(i)("art_nomlargo"), 1, 18), Format(CDbl(dsc.Tables("venta").Rows(i)("dve_precio")), "##0.00"), Format(CDbl(dsc.Tables("venta").Rows(i)("dve_total")), "#,##0.00")))
            Next

            renglones.Add("---------------------------------")

            guardaFooter(CDbl(dsc.Tables("VENTA").Rows(0)("VEN_TOTAL")), dsc.Tables("VENTA").Rows(0)("VEN_ID"))
            renglones.Add(Chr(13))




            oImpresion = New Impresion(renglones)
            oImpresion.imprime()

            On Error Resume Next

            Do While renglones.Count > 0
                renglones.Remove(1)
            Loop
        Else
            MsgBox("DEBE DE SELECCIONAR UN NUMERO DE TICKET A IMPRIMIR", vbExclamation)
        End If

    End Sub
    Private Function centra(ByVal texto As String) As String
        centra = Space(Int((Globales.numletras - Len(texto.Trim)) / 2)) & texto.Trim
    End Function
    Private Function tabula(ByVal cant As String, ByVal art As String, ByVal unit As String, ByVal importe As String) As String
        While cant.Length < 3
            cant = " " & cant
        End While
        art = Mid(art, 1, 14)
        While art.Length < 16
            art = art & " "
        End While
        While unit.Length < 7
            unit = " " & unit
        End While
        While importe.Length < 7
            importe = " " & importe
        End While

        Return cant & " " & Mid(art, 1, 16) & unit & " " & importe
    End Function

    Private Sub guardaFooter(ByVal stotal As Double, ByVal ticket As String)
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer
        Dim tpago As Double


        Dim oConv As New Conversion(CDbl(stotal))

        'Imprime espacio en blanco
        renglones.Add("  ")
        renglones.Add("               TOTAL " & Format(stotal, "$##,##0.00"))
        renglones.Add("SON: " & oConv.numeroEnLetras)
        renglones.Add("")
        'renglones.Add("              TASA 0 :$" & Format(losqueno, "###,##0.00"))
        'renglones.Add("              TASA 16:$" & Format(CDbl(stotal) - losqueno - iva, "###,##0.00"))
        'renglones.Add("              IVA    :$" & Format(iva, "###,##0.00"))

        'renglones.Add("               TOTAL :$" & Format(CDbl(stotal), "###,##0.00"))

        renglones.Add("Monto Total incluye 16% IVA")
        renglones.Add(" de Productos Gravados")

        renglones.Add(Chr(13))

        sql = "select sum(pago) as pago, tipo_pago, referencia, banco from ecformapago where referencia=" & CDbl(ticket) & " group by tipo_pago,referencia,banco"
        Base.daQuery(sql, xcon, dsc, "pagos")
        renglones.Add("-------------------------------")
        renglones.Add("Su Pago:")
        renglones.Add(Chr(13))

        If dsc.Tables("pagos").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("pagos").Rows.Count - 1
                renglones.Add(Mid(dsc.Tables("pagos").Rows(i)("tipo_pago") & Space(10), 1, 10) & "  " & Mid(dsc.Tables("pagos").Rows(i)("banco") & Space(10), 1, 10) & "   " & Format(CDbl(dsc.Tables("pagos").Rows(i)("pago")), "###,##0.00"))
                tpago = tpago + CDbl(dsc.Tables("pagos").Rows(i)("pago"))
            Next
        End If
        renglones.Add(Chr(13))
        dsc.Tables.Remove("pagos")
        renglones.Add("           Cambio:" & Format((tpago - stotal), "$###,##0.00"))
        renglones.Add("  ")


        renglones.Add("***El importe de esta venta se incluye ***")
        renglones.Add("     en la factura global del día ")
        renglones.Add("")

        renglones.Add(Chr(13))
        renglones.Add("GRACIAS, LO ATENDIO: " & sNombre)
        renglones.Add("            REIMRESION")
        renglones.Add(Chr(13))
        renglones.Add(Chr(13))

        ' renglones.Add(Chr(27) + Chr(112) + Chr(0) + Chr(40) & Chr())

    End Sub

    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_IMPRIMIR.Click
        Call reimprimir(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2).Value)
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

    Private Sub FP_VENTAS_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        PINTA(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2, 12)
        FP_VENTAS.ActiveSheet.ActiveRowIndex = e.Row
        PINTA(FP_VENTAS.ActiveSheet.ActiveRowIndex, 1, 12)
        FP_VENTASDET.ActiveSheet.RowCount = 0

    End Sub

    Private Sub FP_VENTAS_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs)
        PINTA(e.Row, 2, 12)
        FP_VENTAS.ActiveSheet.ActiveRowIndex = e.NewRow
        PINTA(FP_VENTAS.ActiveSheet.ActiveRowIndex, 1, 12)

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

    Private Sub FP_VENTASDET_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        PINTA1(FP_VENTASDET.ActiveSheet.ActiveRowIndex, 2, 12)
        FP_VENTASDET.ActiveSheet.ActiveRowIndex = e.Row
        PINTA1(FP_VENTASDET.ActiveSheet.ActiveRowIndex, 1, 12)

    End Sub

    Private Sub FP_VENTASDET_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs)
        PINTA1(e.Row, 2, 12)
        FP_VENTASDET.ActiveSheet.ActiveRowIndex = e.NewRow
        PINTA1(FP_VENTASDET.ActiveSheet.ActiveRowIndex, 1, 12)

    End Sub

    Private Sub txt_fechaini_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Fechaini.Validating
        If Not IsDate(txt_Fechaini.Text) Then
            MsgBox("Formato de Fecha inválido", MsgBoxStyle.Exclamation)
            txt_Fechaini.Text = IIf(Now.Day > 9, CStr(Now.Day), "0" & CStr(Now.Day)) & "/" & _
        IIf(Now.Month > 9, CStr(Now.Month), "0" & CStr(Now.Month)) & "/" & _
        CStr(Now.Year)
            txt_Fechaini.Focus()
        End If
    End Sub

    Private Sub txt_fechafin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Fechafin.Validating
        If Not IsDate(txt_Fechafin.Text) Then
            MsgBox("Formato de Fecha inválido", MsgBoxStyle.Exclamation)
            txt_Fechafin.Text = IIf(Now.Day > 9, CStr(Now.Day), "0" & CStr(Now.Day)) & "/" & _
        IIf(Now.Month > 9, CStr(Now.Month), "0" & CStr(Now.Month)) & "/" & _
        CStr(Now.Year)
            txt_Fechafin.Focus()
        End If
    End Sub

    Private Sub btn_aplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplica.Click
        panel_conf.Visible = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        panel_conf.Visible = False
    End Sub

    Private Sub generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generar.Click
        rellenaventas()
    End Sub

    Private Sub rellenaventas()
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer
        Dim filtro As String

        filtro = ""

        If rb_una.Checked Then
            filtro = " and ven_usuario='000" & txt_clave.Text & "'"
        End If

        If rb_canc.Checked Then
            filtro = "and ven_status=2"
        End If

        sql = "SELECT * FROM ECVENTA  WHERE VEN_FECHA>='" & dafecha(CDate(txt_Fechaini.Text)) & "'" & _
            " AND VEN_FECHA<='" & dafecha(DateAdd("d", 1, CDate(txt_Fechafin.Text))) & "' " & filtro

        FP_VENTAS.ActiveSheet.RowCount = 0

        Base.daQuery(sql, xcon, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = 0
        If dsc.Tables("ventas").Rows.Count > 0 Then
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

                sql = "select isnull(sum(pago),0) pago from ecformapago where referencia='" & dsc.Tables("ventas").Rows(i)("ven_id") & "" & "'"
                Base.daQuery(sql, xcon, dsc, "xxtabla")
                If dsc.Tables("xxtabla").Rows.Count > 0 Then
                    If CDbl(dsc.Tables("xxtabla").Rows(0)("pago")) > 0 Then
                        FP_VENTAS.ActiveSheet.Cells(i, 10).Text = dsc.Tables("xxtabla").Rows(0)("pago") & ""
                        FP_VENTAS.ActiveSheet.Cells(i, 11).Text = CDbl(dsc.Tables("xxtabla").Rows(0)("pago") & "") - CDbl(dsc.Tables("ventas").Rows(i)("ven_total") & "")
                    End If
                End If

                dsc.Tables.Remove("xxtabla")
            Next i
        End If
        dsc.Tables.Remove("ventas")
    End Sub


    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        GENERAL.rutinaexportaraexcel(FP_VENTAS, "Lista de Tickets de Venta ")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GENERAL.rutinaexportaraexcel(FP_VENTASDET, "Reporte Detallado de Tickets de Venta  ")
    End Sub


    Private Sub regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regresar.Click
        Me.Hide()
        foma.Show()
        Me.Dispose()
    End Sub

    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_clave.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
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
                Base.Ejecuta("EXEC APLICAVENTAINVENTARIO " & TICKET & ",4", xcon)
                MsgBox("Ticket Cancelado", MsgBoxStyle.Information)
                sql = "update ECDETCLIENTEEMP SET DCLI_SALDO=Dcli_saldo-eccuentasxcob.cxc_totalvta " & _
                " from ecDETCLIENTEEMP  inner join eccuentasxcob on eccuentasxcob.cxc_cliente=DCLI_CLAVE AND DCLI_EMPRESA=1 " & _
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        panel_motivo.Visible = False
        TXT_MOTIVO.Text = ""
    End Sub
End Class











