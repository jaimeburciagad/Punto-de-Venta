Imports System.Data.SqlClient
Imports FarPoint.Win.Spread.CellType

Public Class retiros
    Inherits System.Windows.Forms.Form
    Dim foma As Form
    Dim ef As Double
    Dim va As Double
    Dim ch As Double
    Dim turno As String
    Friend WithEvents fp_billetes As FarPoint.Win.Spread.FpSpread
    Friend WithEvents fp_billetes_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btn_regresar As System.Windows.Forms.Button
    Friend WithEvents BTN_NUEVO As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BTN_GUARDAR As System.Windows.Forms.Button
    Friend WithEvents folio As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXT_TOTAL As System.Windows.Forms.TextBox
    Friend WithEvents panel_canc As System.Windows.Forms.Panel
    Friend WithEvents btn_cancela As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RB_MONEDAS As System.Windows.Forms.RadioButton
    Public xCon As SqlConnection
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef con As SqlConnection, ByRef f As FrAdmin)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xCon = con
        foma = f

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txcant As System.Windows.Forms.TextBox
    Friend WithEvents gpo_datos As System.Windows.Forms.GroupBox
    Friend WithEvents descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Autorizacion As System.Windows.Forms.Label
    Friend WithEvents txt_pass As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBL_TEXTO As System.Windows.Forms.Label
    Friend WithEvents rbgastos As System.Windows.Forms.RadioButton
    Friend WithEvents rbefectivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbproveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbvales As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim DateTimeCellType1 As FarPoint.Win.Spread.CellType.DateTimeCellType = New FarPoint.Win.Spread.CellType.DateTimeCellType()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(retiros))
        Me.txcant = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gpo_datos = New System.Windows.Forms.GroupBox()
        Me.RB_MONEDAS = New System.Windows.Forms.RadioButton()
        Me.panel_canc = New System.Windows.Forms.Panel()
        Me.btn_cancela = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXT_TOTAL = New System.Windows.Forms.TextBox()
        Me.folio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.fp_billetes = New FarPoint.Win.Spread.FpSpread()
        Me.fp_billetes_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.LBL_TEXTO = New System.Windows.Forms.Label()
        Me.rbvales = New System.Windows.Forms.RadioButton()
        Me.descripcion = New System.Windows.Forms.TextBox()
        Me.rbgastos = New System.Windows.Forms.RadioButton()
        Me.rbefectivo = New System.Windows.Forms.RadioButton()
        Me.rbproveedor = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Autorizacion = New System.Windows.Forms.Label()
        Me.txt_pass = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btn_regresar = New System.Windows.Forms.Button()
        Me.BTN_NUEVO = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BTN_GUARDAR = New System.Windows.Forms.Button()
        Me.gpo_datos.SuspendLayout()
        Me.panel_canc.SuspendLayout()
        CType(Me.fp_billetes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fp_billetes_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txcant
        '
        Me.txcant.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcant.Location = New System.Drawing.Point(811, 224)
        Me.txcant.Name = "txcant"
        Me.txcant.Size = New System.Drawing.Size(129, 26)
        Me.txcant.TabIndex = 1
        Me.txcant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(749, 230)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Monto:"
        '
        'gpo_datos
        '
        Me.gpo_datos.BackColor = System.Drawing.Color.White
        Me.gpo_datos.Controls.Add(Me.RB_MONEDAS)
        Me.gpo_datos.Controls.Add(Me.panel_canc)
        Me.gpo_datos.Controls.Add(Me.Label8)
        Me.gpo_datos.Controls.Add(Me.TXT_TOTAL)
        Me.gpo_datos.Controls.Add(Me.folio)
        Me.gpo_datos.Controls.Add(Me.Label12)
        Me.gpo_datos.Controls.Add(Me.fp_billetes)
        Me.gpo_datos.Controls.Add(Me.LBL_TEXTO)
        Me.gpo_datos.Controls.Add(Me.rbvales)
        Me.gpo_datos.Controls.Add(Me.txcant)
        Me.gpo_datos.Controls.Add(Me.descripcion)
        Me.gpo_datos.Controls.Add(Me.rbgastos)
        Me.gpo_datos.Controls.Add(Me.rbefectivo)
        Me.gpo_datos.Controls.Add(Me.rbproveedor)
        Me.gpo_datos.Controls.Add(Me.Label1)
        Me.gpo_datos.Controls.Add(Me.Label4)
        Me.gpo_datos.Controls.Add(Me.Label2)
        Me.gpo_datos.Controls.Add(Me.NumericUpDown1)
        Me.gpo_datos.Controls.Add(Me.Autorizacion)
        Me.gpo_datos.Controls.Add(Me.txt_pass)
        Me.gpo_datos.Enabled = False
        Me.gpo_datos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpo_datos.ForeColor = System.Drawing.Color.Red
        Me.gpo_datos.Location = New System.Drawing.Point(19, 138)
        Me.gpo_datos.Name = "gpo_datos"
        Me.gpo_datos.Size = New System.Drawing.Size(979, 467)
        Me.gpo_datos.TabIndex = 2
        Me.gpo_datos.TabStop = False
        Me.gpo_datos.Text = "Información para Retiro"
        '
        'RB_MONEDAS
        '
        Me.RB_MONEDAS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_MONEDAS.ForeColor = System.Drawing.Color.MidnightBlue
        Me.RB_MONEDAS.Location = New System.Drawing.Point(515, 71)
        Me.RB_MONEDAS.Name = "RB_MONEDAS"
        Me.RB_MONEDAS.Size = New System.Drawing.Size(232, 24)
        Me.RB_MONEDAS.TabIndex = 594
        Me.RB_MONEDAS.Text = "Retiro de Caja MONEDAS"
        '
        'panel_canc
        '
        Me.panel_canc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panel_canc.Controls.Add(Me.btn_cancela)
        Me.panel_canc.Controls.Add(Me.Label13)
        Me.panel_canc.Controls.Add(Me.Label9)
        Me.panel_canc.Controls.Add(Me.btn_salir)
        Me.panel_canc.Controls.Add(Me.Label11)
        Me.panel_canc.Controls.Add(Me.Label10)
        Me.panel_canc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_canc.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.panel_canc.Location = New System.Drawing.Point(259, 165)
        Me.panel_canc.Name = "panel_canc"
        Me.panel_canc.Size = New System.Drawing.Size(568, 137)
        Me.panel_canc.TabIndex = 593
        Me.panel_canc.Visible = False
        '
        'btn_cancela
        '
        Me.btn_cancela.BackColor = System.Drawing.Color.White
        Me.btn_cancela.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.borrar
        Me.btn_cancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_cancela.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancela.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_cancela.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancela.Location = New System.Drawing.Point(414, 55)
        Me.btn_cancela.Name = "btn_cancela"
        Me.btn_cancela.Size = New System.Drawing.Size(54, 55)
        Me.btn_cancela.TabIndex = 462
        Me.btn_cancela.Tag = "Salir"
        Me.btn_cancela.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancela.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label13.Location = New System.Drawing.Point(410, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 461
        Me.Label13.Text = "Cancelar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(33, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(332, 18)
        Me.Label9.TabIndex = 460
        Me.Label9.Text = "Desea Realizar la Cancelación del Movimiento"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_salir.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_salir.Location = New System.Drawing.Point(497, 55)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(54, 55)
        Me.btn_salir.TabIndex = 47
        Me.btn_salir.Tag = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.UseVisualStyleBackColor = False
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label10.Location = New System.Drawing.Point(508, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 15)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Salir"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(169, 443)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 20)
        Me.Label8.TabIndex = 296
        Me.Label8.Text = "TOTAL"
        '
        'TXT_TOTAL
        '
        Me.TXT_TOTAL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_TOTAL.Location = New System.Drawing.Point(231, 439)
        Me.TXT_TOTAL.Name = "TXT_TOTAL"
        Me.TXT_TOTAL.Size = New System.Drawing.Size(129, 22)
        Me.TXT_TOTAL.TabIndex = 295
        Me.TXT_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'folio
        '
        Me.folio.Enabled = False
        Me.folio.Location = New System.Drawing.Point(833, 165)
        Me.folio.Name = "folio"
        Me.folio.Size = New System.Drawing.Size(104, 22)
        Me.folio.TabIndex = 293
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(772, 165)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 24)
        Me.Label12.TabIndex = 294
        Me.Label12.Text = "Folio:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fp_billetes
        '
        Me.fp_billetes.AccessibleDescription = "fp_billetes, Sheet1, Row 0, Column 0, "
        Me.fp_billetes.BackColor = System.Drawing.SystemColors.Control
        Me.fp_billetes.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.fp_billetes.HorizontalScrollBar.Name = ""
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
        Me.fp_billetes.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.fp_billetes.HorizontalScrollBar.TabIndex = 28
        Me.fp_billetes.Location = New System.Drawing.Point(28, 44)
        Me.fp_billetes.Name = "fp_billetes"
        Me.fp_billetes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fp_billetes.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.fp_billetes_Sheet1})
        Me.fp_billetes.Size = New System.Drawing.Size(332, 389)
        Me.fp_billetes.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Sunburst
        Me.fp_billetes.TabIndex = 292
        Me.fp_billetes.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.fp_billetes.VerticalScrollBar.Name = ""
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
        Me.fp_billetes.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.fp_billetes.VerticalScrollBar.TabIndex = 29
        '
        'fp_billetes_Sheet1
        '
        Me.fp_billetes_Sheet1.Reset()
        Me.fp_billetes_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.fp_billetes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.fp_billetes_Sheet1.ColumnCount = 5
        Me.fp_billetes_Sheet1.RowCount = 1
        Me.fp_billetes_Sheet1.RowHeader.ColumnCount = 0
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Cantidad"
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Billete/Mon"
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Importe"
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "ID"
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_billetes_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Conv"
        Me.fp_billetes_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.fp_billetes_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
        NumberCellType1.DecimalPlaces = 2
        NumberCellType1.MaximumValue = 10000000.0R
        NumberCellType1.MinimumValue = -10000000.0R
        Me.fp_billetes_Sheet1.Columns.Get(0).CellType = NumberCellType1
        Me.fp_billetes_Sheet1.Columns.Get(0).Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.Columns.Get(0).Label = "Cantidad"
        Me.fp_billetes_Sheet1.Columns.Get(0).Width = 59.0!
        Me.fp_billetes_Sheet1.Columns.Get(1).CellType = TextCellType1
        Me.fp_billetes_Sheet1.Columns.Get(1).Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.Columns.Get(1).Label = "Billete/Mon"
        Me.fp_billetes_Sheet1.Columns.Get(1).Width = 154.0!
        NumberCellType2.DecimalPlaces = 2
        NumberCellType2.DecimalSeparator = "."
        NumberCellType2.Separator = ","
        NumberCellType2.ShowSeparator = True
        Me.fp_billetes_Sheet1.Columns.Get(2).CellType = NumberCellType2
        Me.fp_billetes_Sheet1.Columns.Get(2).Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_billetes_Sheet1.Columns.Get(2).Label = "Importe"
        Me.fp_billetes_Sheet1.Columns.Get(2).Width = 92.0!
        Me.fp_billetes_Sheet1.Columns.Get(3).Label = "ID"
        Me.fp_billetes_Sheet1.Columns.Get(3).Visible = False
        Me.fp_billetes_Sheet1.Columns.Get(3).Width = 49.0!
        DateTimeCellType1.Calendar = CType(resources.GetObject("DateTimeCellType1.Calendar"), System.Globalization.Calendar)
        DateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText
        DateTimeCellType1.DateDefault = New Date(2010, 7, 20, 17, 43, 33, 0)
        DateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999")
        DateTimeCellType1.TimeDefault = New Date(2010, 7, 20, 17, 43, 33, 0)
        Me.fp_billetes_Sheet1.Columns.Get(4).CellType = DateTimeCellType1
        Me.fp_billetes_Sheet1.Columns.Get(4).Label = "Conv"
        Me.fp_billetes_Sheet1.Columns.Get(4).Visible = False
        Me.fp_billetes_Sheet1.Columns.Get(4).Width = 44.0!
        Me.fp_billetes_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.fp_billetes_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.fp_billetes_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.fp_billetes_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSunburst"
        Me.fp_billetes_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fp_billetes_Sheet1.SelectionForeColor = System.Drawing.Color.White
        Me.fp_billetes_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.fp_billetes_Sheet1.SheetCornerStyle.Parent = "CornerSunburst"
        Me.fp_billetes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'LBL_TEXTO
        '
        Me.LBL_TEXTO.BackColor = System.Drawing.Color.Silver
        Me.LBL_TEXTO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TEXTO.ForeColor = System.Drawing.Color.White
        Me.LBL_TEXTO.Location = New System.Drawing.Point(28, 18)
        Me.LBL_TEXTO.Name = "LBL_TEXTO"
        Me.LBL_TEXTO.Size = New System.Drawing.Size(332, 23)
        Me.LBL_TEXTO.TabIndex = 288
        Me.LBL_TEXTO.Text = "BILLETES"
        Me.LBL_TEXTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbvales
        '
        Me.rbvales.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbvales.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rbvales.Location = New System.Drawing.Point(515, 94)
        Me.rbvales.Name = "rbvales"
        Me.rbvales.Size = New System.Drawing.Size(232, 24)
        Me.rbvales.TabIndex = 3
        Me.rbvales.Text = "Retiro de Caja Vales"
        '
        'descripcion
        '
        Me.descripcion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descripcion.Location = New System.Drawing.Point(573, 192)
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Size = New System.Drawing.Size(367, 26)
        Me.descripcion.TabIndex = 0
        '
        'rbgastos
        '
        Me.rbgastos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbgastos.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rbgastos.Location = New System.Drawing.Point(515, 113)
        Me.rbgastos.Name = "rbgastos"
        Me.rbgastos.Size = New System.Drawing.Size(168, 24)
        Me.rbgastos.TabIndex = 2
        Me.rbgastos.Text = "Gasto"
        '
        'rbefectivo
        '
        Me.rbefectivo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbefectivo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rbefectivo.Location = New System.Drawing.Point(516, 52)
        Me.rbefectivo.Name = "rbefectivo"
        Me.rbefectivo.Size = New System.Drawing.Size(232, 24)
        Me.rbefectivo.TabIndex = 1
        Me.rbefectivo.Text = "Retiro de Caja Efectivo y Cheques"
        '
        'rbproveedor
        '
        Me.rbproveedor.Checked = True
        Me.rbproveedor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbproveedor.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rbproveedor.Location = New System.Drawing.Point(516, 32)
        Me.rbproveedor.Name = "rbproveedor"
        Me.rbproveedor.Size = New System.Drawing.Size(168, 24)
        Me.rbproveedor.TabIndex = 0
        Me.rbproveedor.TabStop = True
        Me.rbproveedor.Text = "Pago a Proveedor"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(427, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 26)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Descripcion de retiro:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(776, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 24)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = " Caja:"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(854, 56)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NumericUpDown1.Size = New System.Drawing.Size(62, 39)
        Me.NumericUpDown1.TabIndex = 15
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Autorizacion
        '
        Me.Autorizacion.BackColor = System.Drawing.Color.Transparent
        Me.Autorizacion.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Autorizacion.ForeColor = System.Drawing.Color.Gray
        Me.Autorizacion.Location = New System.Drawing.Point(777, 341)
        Me.Autorizacion.Name = "Autorizacion"
        Me.Autorizacion.Size = New System.Drawing.Size(163, 20)
        Me.Autorizacion.TabIndex = 13
        Me.Autorizacion.Text = "Código de Autorización:"
        '
        'txt_pass
        '
        Me.txt_pass.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt_pass.Location = New System.Drawing.Point(787, 364)
        Me.txt_pass.Name = "txt_pass"
        Me.txt_pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_pass.Size = New System.Drawing.Size(153, 22)
        Me.txt_pass.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkGray
        Me.Label7.Location = New System.Drawing.Point(717, 691)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(262, 15)
        Me.Label7.TabIndex = 529
        Me.Label7.Text = "Derechos Reservados Estrategias Competitivas 2011"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label27.Location = New System.Drawing.Point(556, 668)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(68, 35)
        Me.Label27.TabIndex = 534
        Me.Label27.Text = "MENU ANTERIOR"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(339, 668)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 35)
        Me.Label22.TabIndex = 530
        Me.Label22.Text = "NUEVO REGISTRO "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_regresar
        '
        Me.btn_regresar.BackColor = System.Drawing.Color.White
        Me.btn_regresar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.btn_regresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_regresar.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_regresar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.btn_regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_regresar.Location = New System.Drawing.Point(562, 611)
        Me.btn_regresar.Name = "btn_regresar"
        Me.btn_regresar.Size = New System.Drawing.Size(53, 54)
        Me.btn_regresar.TabIndex = 526
        Me.btn_regresar.Tag = "Regresar"
        Me.btn_regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_regresar.UseVisualStyleBackColor = False
        '
        'BTN_NUEVO
        '
        Me.BTN_NUEVO.BackColor = System.Drawing.Color.White
        Me.BTN_NUEVO.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.BOTON_NUEVO
        Me.BTN_NUEVO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_NUEVO.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_NUEVO.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BTN_NUEVO.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_NUEVO.Location = New System.Drawing.Point(344, 611)
        Me.BTN_NUEVO.Name = "BTN_NUEVO"
        Me.BTN_NUEVO.Size = New System.Drawing.Size(53, 54)
        Me.BTN_NUEVO.TabIndex = 523
        Me.BTN_NUEVO.Tag = "Nuevo"
        Me.BTN_NUEVO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_NUEVO.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.LOGO_REDONDO
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(19, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 129)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 587
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(146, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 21)
        Me.Label3.TabIndex = 589
        Me.Label3.Text = "Administración de Cajas"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Navy
        Me.Label23.Location = New System.Drawing.Point(146, 75)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(369, 26)
        Me.Label23.TabIndex = 588
        Me.Label23.Text = "Registro de Salidas de Efectivo de Cajas"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkGray
        Me.Label15.Location = New System.Drawing.Point(849, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 17)
        Me.Label15.TabIndex = 590
        Me.Label15.Text = "Estrategias Competitivas "
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(409, 668)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 35)
        Me.Label5.TabIndex = 592
        Me.Label5.Text = "GUARDAR REGISTRO "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_GUARDAR
        '
        Me.BTN_GUARDAR.BackColor = System.Drawing.Color.White
        Me.BTN_GUARDAR.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.imprimir1
        Me.BTN_GUARDAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BTN_GUARDAR.Enabled = False
        Me.BTN_GUARDAR.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_GUARDAR.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BTN_GUARDAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_GUARDAR.Location = New System.Drawing.Point(412, 611)
        Me.BTN_GUARDAR.Name = "BTN_GUARDAR"
        Me.BTN_GUARDAR.Size = New System.Drawing.Size(53, 54)
        Me.BTN_GUARDAR.TabIndex = 591
        Me.BTN_GUARDAR.Tag = "Nuevo"
        Me.BTN_GUARDAR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_GUARDAR.UseVisualStyleBackColor = False
        '
        'retiros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1010, 724)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BTN_GUARDAR)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btn_regresar)
        Me.Controls.Add(Me.BTN_NUEVO)
        Me.Controls.Add(Me.gpo_datos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "retiros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retiros De Efectivo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gpo_datos.ResumeLayout(False)
        Me.gpo_datos.PerformLayout()
        Me.panel_canc.ResumeLayout(False)
        Me.panel_canc.PerformLayout()
        CType(Me.fp_billetes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fp_billetes_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub retiros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Globales.caja = "vscaja7" Then
            Label2.Visible = True
            NumericUpDown1.Visible = True
        Else
            Label2.Visible = False
            NumericUpDown1.Visible = False
        End If

        BTN_NUEVO.Enabled = True
        BTN_GUARDAR.Enabled = False
        btn_regresar.Enabled = True
    End Sub
    Private Sub inicia()
        descripcion.Text = ""
        folio.Text = ""
        fp_billetes.ActiveSheet.RowCount = 0
        txcant.Text = ""
        fp_billetes.Enabled = False
        rbefectivo.Enabled = False
        rbgastos.Enabled = False
        rbproveedor.Enabled = False
        rbvales.Enabled = False
        descripcion.Enabled = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_GUARDAR.Click
        Dim sSql As String
        Dim dsc As New DataSet
        Dim xtipo As Integer
        Dim xmaximo As Integer
        Dim sql As String

        descripcion.Text = Replace(descripcion.Text, "'", "")

        CAJARET = Me.NumericUpDown1.Value.ToString

        If Trim(txt_pass.Text) = "" Then
            MsgBox("Necesita la Clave de Autorización para realizar el retiro")
            txt_pass.Text = ""
            txt_pass.Focus()
            Exit Sub
        Else

            Dim i As Integer

            For i = 1 To Len(LTrim(RTrim(Me.txt_pass.Text)))
                If IsNumeric(Mid(txt_pass.Text, i, 1)) Then
                    Exit For
                End If
            Next

            recalcula()

            txt_pass.Text = Mid(txt_pass.Text, i, Len(txt_pass.Text) - i + 1)
            sSql = "select * FROM ecusuariosx where emp_password='" & Me.txt_pass.Text & "'"
            Base.daQuery(sSql, xCon, dsc, "empleado")
            If dsc.Tables("empleado").Rows.Count > 0 Then

                Select Case dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim

                    Case "Supervisor"

                        Dim tipo As Integer
                        If Me.rbproveedor.Checked Then
                            tipo = 4
                        End If
                        If Me.rbefectivo.Checked = True Then
                            tipo = 1

                        End If
                        If Me.RB_MONEDAS.Checked = True Then
                            tipo = 2
                        End If
                        If Me.rbvales.Checked = True Then
                            tipo = 3
                        End If

                        If Me.rbgastos.Checked = True Then
                            tipo = 5
                        End If


                        If IsNumeric(Me.txcant.Text) = True Then
                            If RB_MONEDAS.Checked Or rbefectivo.Checked Or rbvales.Checked Then
                                xtipo = 1
                            Else
                                xtipo = 0
                            End If

                            sql = "Select retiros+1  as  maximo  from ecconsempresa "
                            Base.daQuery(sql, xCon, dsc, "maximo")


                            If dsc.Tables.Count > 0 Then
                                xmaximo = CDbl(dsc.Tables("maximo").Rows(0)("maximo"))
                            Else
                                xmaximo = 1
                            End If
                            Base.Ejecuta("UPDATE ECCONSEMPRESA SET RETIROS=" & xmaximo, xCon)
                            dsc.Tables.Remove("maximo")

                            If Label2.Visible = True Then
                                Try
                                    Base.Ejecuta("insert into ecretiros values(" & xmaximo & ",getdate()," & CDbl(Me.txcant.Text) & ",'00" & NumericUpDown1.Value & "0'," & tipo & ",'" & descripcion.Text & "',0,0,null,null,'" & dsc.Tables("empleado").Rows(0)("emp_nombre").ToString.Trim & "','',null)", xCon)
                                Catch ex As Exception
                                    Base.Ejecuta("delete from ecretiros where cve_retiros='" & xmaximo & "'", xCon)
                                    MsgBox("Error en registro de retiro." & Chr(13) & Chr(13) & ex.Message, vbExclamation, "Error")
                                    Exit Sub
                                End Try

                                If xtipo = 1 Then
                                    For i = 0 To fp_billetes.ActiveSheet.RowCount - 1
                                        If CDbl(fp_billetes.ActiveSheet.Cells(i, 0).Value) <> 0 Then
                                            sql = "INSERT ECDETRETIROS  VALUES (" & xmaximo & ",GETDATE()," &
                                            "'00" & Me.NumericUpDown1.Value.ToString & "'," &
                                            fp_billetes.ActiveSheet.Cells(i, 3).Value & "," &
                                            fp_billetes.ActiveSheet.Cells(i, 4).Value & "," &
                                            fp_billetes.ActiveSheet.Cells(i, 0).Value & "," &
                                            fp_billetes.ActiveSheet.Cells(i, 0).Value * fp_billetes.ActiveSheet.Cells(i, 4).Value & ",1)"
                                            Try
                                                Base.Ejecuta(sql, xCon)
                                            Catch ex As Exception
                                                Base.Ejecuta("delete from ecretiros where cve_retiros='" & xmaximo & "'", xCon)
                                                Base.Ejecuta("delete from ECDETRETIROS where DRET_FOLIO='" & xmaximo & "'", xCon)
                                                MsgBox("Error en registro de retiro." & Chr(13) & Chr(13) & ex.Message, vbExclamation, "Error")
                                                Exit Sub
                                            End Try

                                        End If
                                    Next
                                End If
                            Else
                                Try
                                    Base.Ejecuta("insert into ecretiros values(" & xmaximo & ",getdate()," & CDbl(Me.txcant.Text) & ",'00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'," & tipo & ",'" & descripcion.Text & "',0,0,null,null,'" & dsc.Tables("empleado").Rows(0)("emp_nombre").ToString.Trim & "','',null)", xCon)
                                Catch ex As Exception
                                    Base.Ejecuta("delete from ecretiros where cve_retiros='" & xmaximo & "'", xCon)
                                    MsgBox("Error en registro de retiro." & Chr(13) & Chr(13) & ex.Message, vbExclamation, "Error")
                                    Exit Sub
                                End Try
                                If xtipo = 1 Then
                                    For i = 0 To fp_billetes.ActiveSheet.RowCount - 1
                                        If CDbl(fp_billetes.ActiveSheet.Cells(i, 0).Value) <> 0 Then
                                            sql = "INSERT ECDETRETIROS  VALUES (" & xmaximo & ",GETDATE()," &
                                            "'00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "'," &
                                            fp_billetes.ActiveSheet.Cells(i, 3).Value & "," &
                                            fp_billetes.ActiveSheet.Cells(i, 4).Value & "," &
                                            fp_billetes.ActiveSheet.Cells(i, 0).Value & "," &
                                            fp_billetes.ActiveSheet.Cells(i, 0).Value * fp_billetes.ActiveSheet.Cells(i, 4).Value & ",1)"
                                            Try
                                                Base.Ejecuta(sql, xCon)
                                            Catch ex As Exception
                                                Base.Ejecuta("delete from ecretiros where cve_retiros='" & xmaximo & "'", xCon)
                                                Base.Ejecuta("delete from ECDETRETIROS where DRET_FOLIO='" & xmaximo & "'", xCon)
                                                MsgBox("Error en registro de retiro." & Chr(13) & Chr(13) & ex.Message, vbExclamation, "Error")
                                                Exit Sub
                                            End Try
                                        End If

                                    Next
                                End If

                            End If

                            Try
                                Base.Ejecuta("exec creamovtodinero " & xmaximo & ",1", xCon)
                            Catch ex As Exception
                                Base.Ejecuta("delete from ecretiros where cve_retiros='" & xmaximo & "'", xCon)
                                Base.Ejecuta("delete from ECDETRETIROS where DRET_FOLIO='" & xmaximo & "'", xCon)

                                Base.Ejecuta("delete from eccontroldinero.dbo.ECDEPRETIROS where DREP_FOLIOREL=(select band_folio from ECCONTROLDINERO.DBO.ecefectivo where band_foliorel='" & xmaximo & "')", xCon)
                                Base.Ejecuta("delete from ECCONTROLDINERO.DBO.ecVALES where band_foliorel='" & xmaximo & "'", xCon)
                                Base.Ejecuta("delete from ECCONTROLDINERO.DBO.ecefectivo where band_foliorel='" & xmaximo & "'", xCon)

                                MsgBox("Error en registro de retiro." & Chr(13) & Chr(13) & ex.Message, vbExclamation, "Error")
                                Exit Sub
                            End Try

                            Dim preretiros As New preretiros(CDbl(Me.txcant.Text), descripcion.Text, fp_billetes, xtipo)
                            imprimeTicket(preretiros.COLECCION)
                            MsgBox("Cantidad de Retiro Registrada.")
                            txt_pass.Text = ""
                            Me.txcant.Text = ""
                            Me.descripcion.Text = ""
                            BTN_NUEVO.Enabled = True
                            BTN_GUARDAR.Enabled = False
                            ' btn_borrar.Enabled = True
                            inicia()
                        Else
                            MsgBox("Cantidad Incorrecta")
                        End If
                    Case Else
                        MsgBox("AUTORIZACION NO VALIDA")
                        txt_pass.Text = ""
                        txt_pass.Focus()

                End Select
                dsc.Tables.Remove("empleado")
            Else
                MsgBox("AUTORIZACION NO VALIDA")
                txt_pass.Text = ""
                txt_pass.Focus()
            End If
        End If
    End Sub


    Public Sub imprimeTicket(ByRef pre As Collection)
        Dim oImpresion As Impresion
        oImpresion = New Impresion(pre)
        oImpresion.imprime(False)
    End Sub


    Private Sub rbproveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbproveedor.CheckedChanged
        If rbproveedor.Checked Then
            fp_billetes.ActiveSheet.RowCount = 0
            txcant.Enabled = True
            fp_billetes.Enabled = False
            descripcion.Text = "Prov  "
            txcant.Text = "0.00"
            recalcula()
            descripcion.Focus()

        End If
    End Sub

    Private Sub folio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles folio.KeyPress
        Dim SQL As String
        Dim DSC As New DataSet
        If e.KeyChar = Chr(Keys.Enter) Then
            Dim FRBUSQUEDA As New busqueda
            FRBUSQUEDA.TXTCONTROL = Me.folio
            'If Globales.caja = "0007" Then
            GENERAL.parametrosbusqueda(FRBUSQUEDA, "Retiros de Caja ", "cve_retiros,fecha,descripcion,caja,cuanto", "ecretiros", "cve_retiros", "1", xCon, "Folio,Fecha,Concepto,Caja,Monto", "50,80,260,50,80", "A,A,A,A,#", "1", "corte=0")
            'Else
            'End If
            FRBUSQUEDA.ShowDialog()
            FRBUSQUEDA.Dispose()
            SQL = "SELECT * FROM ECRETIROS WHERE CVE_RETIROS=" & folio.Text
            Base.daQuery(SQL, xCon, DSC, "RET")
            If DSC.Tables("RET").Rows.Count > 0 Then
                descripcion.Text = DSC.Tables("RET").Rows(0)("descripcion")
                txcant.Text = CDbl(DSC.Tables("RET").Rows(0)("cuanto"))

            Else
                MsgBox("Movimiento de Retiro no registrado  o no se puede cancelar porque ya está aplicado en un corte")
                folio.Text = ""
                folio.Enabled = False
            End If

            DSC.Tables.Remove("RET")

        End If
    End Sub


    Private Sub rellenaspread(ByVal opcion As Integer)
        Dim SQL As String
        Dim DSC As New DataSet
        Dim I As Integer

        Select Case opcion
            Case 1
                SQL = "SELECT * FROM BILLETES WHERE BILL_TIPO=1 ORDER BY BILL_CONV DESC"
                Base.daQuery(SQL, xCon, DSC, "BILL")
                With fp_billetes.ActiveSheet
                    .RowCount = DSC.Tables("BILL").Rows.Count + 1

                    If DSC.Tables("BILL").Rows.Count > 0 Then
                        For I = 0 To DSC.Tables("BILL").Rows.Count - 1
                            .Cells(I, 1).Value = (DSC.Tables("BILL").Rows(I)("BILL_DESC"))
                            .Cells(I, 3).Value = CDbl(DSC.Tables("BILL").Rows(I)("BILL_CLAVE"))
                            .Cells(I, 4).Value = CDbl(DSC.Tables("BILL").Rows(I)("BILL_CONV"))
                            .Cells(I, 2).Formula = "A" & I + 1 & "*E" & I + 1
                        Next I
                    End If

                End With
                DSC.Tables.Remove("BILL")

            Case 3
                SQL = "SELECT * FROM BILLETES WHERE BILL_TIPO=2 ORDER BY BILL_CONV DESC"
                Base.daQuery(SQL, xCon, DSC, "BILL")
                With fp_billetes.ActiveSheet
                    .RowCount = DSC.Tables("BILL").Rows.Count + 1

                    If DSC.Tables("BILL").Rows.Count > 0 Then
                        For I = 0 To DSC.Tables("BILL").Rows.Count - 1
                            .Cells(I, 1).Value = (DSC.Tables("BILL").Rows(I)("BILL_DESC"))
                            .Cells(I, 3).Value = CDbl(DSC.Tables("BILL").Rows(I)("BILL_CLAVE"))
                            .Cells(I, 4).Value = CDbl(DSC.Tables("BILL").Rows(I)("BILL_CONV"))
                            .Cells(I, 2).Formula = "A" & I + 1 & "*E" & I + 1
                        Next I
                    End If

                End With
                DSC.Tables.Remove("BILL")

            Case 2
                SQL = "SELECT * FROM BILLETES WHERE BILL_TIPO=3 ORDER BY BILL_CONV DESC"
                Base.daQuery(SQL, xCon, DSC, "BILL")
                With fp_billetes.ActiveSheet
                    .RowCount = DSC.Tables("BILL").Rows.Count + 1

                    If DSC.Tables("BILL").Rows.Count > 0 Then
                        For I = 0 To DSC.Tables("BILL").Rows.Count - 1
                            .Cells(I, 1).Value = (DSC.Tables("BILL").Rows(I)("BILL_DESC"))
                            .Cells(I, 3).Value = CDbl(DSC.Tables("BILL").Rows(I)("BILL_CLAVE"))
                            .Cells(I, 4).Value = CDbl(DSC.Tables("BILL").Rows(I)("BILL_CONV"))
                            .Cells(I, 2).Formula = "A" & I + 1 & "*E" & I + 1
                        Next I
                    End If

                End With
                DSC.Tables.Remove("BILL")

        End Select

    End Sub

    Private Sub recalcula()
        Dim i As Integer
        Dim xtotal As Double
        xtotal = 0
        If fp_billetes.ActiveSheet.RowCount = 0 And (rbproveedor.Checked Or rbgastos.Checked) Then
            xtotal = CDbl(txcant.Text)
        End If
        For i = 0 To fp_billetes.ActiveSheet.RowCount - 1
            fp_billetes.ActiveSheet.Cells(i, 2).Value = fp_billetes.ActiveSheet.Cells(i, 4).Value * fp_billetes.ActiveSheet.Cells(i, 0).Value
            xtotal = xtotal + fp_billetes.ActiveSheet.Cells(i, 2).Value

        Next
        TXT_TOTAL.Text = Format(xtotal, "###,##0.00")
        txcant.Text = TXT_TOTAL.Text

    End Sub


    Private Sub rbefectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbefectivo.CheckedChanged
        If rbefectivo.Checked Then
            fp_billetes.Enabled = True
            rellenaspread(1)
            txcant.Enabled = False
            descripcion.Text = "Retiro de Efectivo "
            txcant.Text = "0.00"
            fp_billetes.ActiveSheet.ActiveRowIndex = 0
            recalcula()
            fp_billetes.Focus()
        End If
    End Sub

    Private Sub rbvales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbvales.CheckedChanged
        If rbvales.Checked Then
            fp_billetes.Enabled = True
            fp_billetes.ActiveSheet.RowCount = 0
            rellenaspread(2)
            txcant.Enabled = False
            txcant.Text = "0.00"
            recalcula()

            descripcion.Text = "Retiro de Caja Vales "
            fp_billetes.ActiveSheet.ActiveRowIndex = 0
            fp_billetes.Focus()

        End If
    End Sub

    

    Private Sub rbgastos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbgastos.CheckedChanged
        If rbgastos.Checked Then
            fp_billetes.ActiveSheet.RowCount = 0
            fp_billetes.Enabled = False
            descripcion.Text = "Gasto "
            txcant.Text = "0.00"
            txcant.Enabled = True
            recalcula()

            descripcion.Focus()
        End If
    End Sub
    Private Sub fp_billetes_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles fp_billetes.KeyPress

        Dim dsc As New DataSet


        If e.KeyChar = Chr(Keys.Enter) Or e.KeyChar = Chr(Keys.Tab) Then
            If fp_billetes.ActiveSheet.ActiveColumnIndex = 0 Then

                fp_billetes.ActiveSheet.Cells(fp_billetes.ActiveSheet.ActiveRowIndex, 2).Value = fp_billetes.ActiveSheet.Cells(fp_billetes.ActiveSheet.ActiveRowIndex, 0).Value * fp_billetes.ActiveSheet.Cells(fp_billetes.ActiveSheet.ActiveRowIndex, 4).Value
                If fp_billetes.ActiveSheet.ActiveRowIndex + 1 <= fp_billetes.ActiveSheet.RowCount - 1 Then
                    fp_billetes.ActiveSheet.ActiveRowIndex = fp_billetes.ActiveSheet.ActiveRowIndex + 1
                End If

            End If
        End If
        recalcula()
    End Sub


    Private Sub fp_billetes_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles fp_billetes.Change
        recalcula()
    End Sub


    Private Sub BTN_NUEVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_NUEVO.Click
        BTN_NUEVO.Enabled = False
        'btn_borrar.Enabled = False
        BTN_GUARDAR.Enabled = True
        btn_regresar.Enabled = True
        descripcion.Enabled = True
        descripcion.Text = ""
        descripcion.Focus()
        gpo_datos.Enabled = True
        fp_billetes.Enabled = True
        rbproveedor.Checked = True
        rbefectivo.Enabled = True
        rbgastos.Enabled = True
        rbproveedor.Enabled = True
        rbvales.Enabled = True
    End Sub

 
    Private Sub btn_regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_regresar.Click
        Me.Hide()
        foma.Show()
        Me.Dispose()
    End Sub


    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        panel_canc.Visible = False
        BTN_NUEVO.Enabled = True
        BTN_GUARDAR.Enabled = True
        '    btn_borrar.Enabled = True
        panel_canc.Visible = True
        folio.Enabled = False
        folio.Focus()
    End Sub


    Private Sub btn_cancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancela.Click
        Dim sql As String
        sql = "update ecretiros set ret_estatus=2,ret_fechacanc=getdate()" & " , ret_cancusuario='" & Globales.nombreusuario & "'" & _
            " where cve_retiros=" & folio.Text
        Base.Ejecuta(sql, xCon)
        MsgBox("Cancelación Realizada Correctamente", vbExclamation)
        panel_canc.Visible = False
        BTN_NUEVO.Enabled = True
        BTN_GUARDAR.Enabled = True

        folio.Enabled = False
        inicia()
    End Sub
    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) & _
        IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
    End Function

    Private Sub RB_MONEDAS_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RB_MONEDAS.CheckedChanged
        If RB_MONEDAS.Checked Then
            fp_billetes.Enabled = True
            fp_billetes.ActiveSheet.RowCount = 0
            rellenaspread(3)
            txcant.Enabled = False
            txcant.Text = "0.00"
            recalcula()

            descripcion.Text = "Retiro de Monedas"
            fp_billetes.ActiveSheet.ActiveRowIndex = 0
            fp_billetes.Focus()
        End If
    End Sub

    Private Sub txt_pass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pass.TextChanged

    End Sub
End Class

