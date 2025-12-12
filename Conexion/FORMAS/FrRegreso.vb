Imports FarPoint.Win.Spread.CellType


Imports FarPoint.Win.Spread

Imports System.Data.SqlClient
Public Class FrRegreso
    Inherits System.Windows.Forms.Form
    Public xCon As SqlConnection
    Dim autorization As Boolean
    Dim VengoDe As String
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents FpSpread1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents FpSpread1_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtMotivo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TXT_PASSWORD As TextBox
    Friend WithEvents Label5 As Label
    Dim totalote As Double
    Dim AutorizaRetiro As Boolean
    Dim Corriendo As Boolean
    Dim Encontrado As FarPoint.Win.Spread.SearchFoundFlags
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents Label41 As Label
    Dim FilaMatch As Integer

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef con As SqlConnection)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xCon = con
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
    Friend WithEvents tx_buscaticket As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents caja As System.Windows.Forms.ComboBox
    Friend WithEvents lcaja As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim EnhancedScrollBarRenderer1 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim EnhancedScrollBarRenderer2 As FarPoint.Win.Spread.EnhancedScrollBarRenderer = New FarPoint.Win.Spread.EnhancedScrollBarRenderer()
        Dim NumberCellType1 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim TextCellType1 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim TextCellType2 As FarPoint.Win.Spread.CellType.TextCellType = New FarPoint.Win.Spread.CellType.TextCellType()
        Dim NumberCellType2 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Dim NumberCellType3 As FarPoint.Win.Spread.CellType.NumberCellType = New FarPoint.Win.Spread.CellType.NumberCellType()
        Me.tx_buscaticket = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.caja = New System.Windows.Forms.ComboBox()
        Me.lcaja = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.FpSpread1 = New FarPoint.Win.Spread.FpSpread()
        Me.FpSpread1_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtMotivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TXT_PASSWORD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tx_buscaticket
        '
        Me.tx_buscaticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tx_buscaticket.Location = New System.Drawing.Point(840, 46)
        Me.tx_buscaticket.Name = "tx_buscaticket"
        Me.tx_buscaticket.Size = New System.Drawing.Size(104, 31)
        Me.tx_buscaticket.TabIndex = 1
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Red
        Me.CheckBox1.Location = New System.Drawing.Point(627, 136)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(367, 43)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Entrega de Dinero como Salida de CAJA en EFECTIVO"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'tb_total
        '
        Me.tb_total.BackColor = System.Drawing.Color.White
        Me.tb_total.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(862, 591)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(119, 26)
        Me.tb_total.TabIndex = 55
        Me.tb_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.OrangeRed
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(759, 593)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 24)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "TOTAL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(720, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 40)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "No. Ticket"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(624, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(208, 27)
        Me.Label12.TabIndex = 215
        Me.Label12.Text = "Hora:"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(624, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(208, 27)
        Me.Label11.TabIndex = 214
        Me.Label11.Text = "Fecha:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.White
        Me.btn_cancelar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.ADENTROSALIR
        Me.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_cancelar.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.ForeColor = System.Drawing.Color.Red
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(923, 642)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(58, 56)
        Me.btn_cancelar.TabIndex = 226
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.White
        Me.btn_aceptar.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.guardar1
        Me.btn_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_aceptar.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.ForeColor = System.Drawing.Color.Red
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_aceptar.Location = New System.Drawing.Point(827, 642)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(58, 56)
        Me.btn_aceptar.TabIndex = 225
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'caja
        '
        Me.caja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.caja.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.caja.Location = New System.Drawing.Point(910, 88)
        Me.caja.Name = "caja"
        Me.caja.Size = New System.Drawing.Size(32, 21)
        Me.caja.TabIndex = 227
        '
        'lcaja
        '
        Me.lcaja.BackColor = System.Drawing.Color.Transparent
        Me.lcaja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcaja.ForeColor = System.Drawing.Color.Black
        Me.lcaja.Location = New System.Drawing.Point(847, 85)
        Me.lcaja.Name = "lcaja"
        Me.lcaja.Size = New System.Drawing.Size(57, 29)
        Me.lcaja.TabIndex = 228
        Me.lcaja.Text = "Caja:"
        Me.lcaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkGray
        Me.Label18.Location = New System.Drawing.Point(150, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(186, 21)
        Me.Label18.TabIndex = 471
        Me.Label18.Text = "Administración de Ventas"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Franklin Gothic Medium", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Navy
        Me.Label20.Location = New System.Drawing.Point(150, 80)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(290, 26)
        Me.Label20.TabIndex = 470
        Me.Label20.Text = "Control Devolución de Artículos"
        '
        'FpSpread1
        '
        Me.FpSpread1.AccessibleDescription = "fp_devolucion, Sheet1, Row 0, Column 0, "
        Me.FpSpread1.BackColor = System.Drawing.SystemColors.Control
        Me.FpSpread1.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread1.HorizontalScrollBar.Name = ""
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
        Me.FpSpread1.HorizontalScrollBar.Renderer = EnhancedScrollBarRenderer1
        Me.FpSpread1.HorizontalScrollBar.TabIndex = 44
        Me.FpSpread1.Location = New System.Drawing.Point(76, 185)
        Me.FpSpread1.Name = "FpSpread1"
        Me.FpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FpSpread1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.FpSpread1_Sheet1})
        Me.FpSpread1.Size = New System.Drawing.Size(905, 376)
        Me.FpSpread1.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Sunburst
        Me.FpSpread1.TabIndex = 473
        Me.FpSpread1.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.FpSpread1.VerticalScrollBar.Name = ""
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
        Me.FpSpread1.VerticalScrollBar.Renderer = EnhancedScrollBarRenderer2
        Me.FpSpread1.VerticalScrollBar.TabIndex = 45
        '
        'FpSpread1_Sheet1
        '
        Me.FpSpread1_Sheet1.Reset()
        Me.FpSpread1_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.FpSpread1_Sheet1.ColumnCount = 8
        Me.FpSpread1_Sheet1.ColumnHeader.RowCount = 2
        Me.FpSpread1_Sheet1.RowCount = 1
        Me.FpSpread1_Sheet1.RowHeader.ColumnCount = 0
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Cantidad"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Clave"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Descripción "
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 4
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Precio"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Cantidad a Devolver"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 3
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Importe"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Cod. Artículo"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.SystemColors.Highlight
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Vale"
        Me.FpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderSunburst"
        NumberCellType1.DecimalPlaces = 3
        Me.FpSpread1_Sheet1.Columns.Get(0).CellType = NumberCellType1
        Me.FpSpread1_Sheet1.Columns.Get(0).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(0).Width = 88.0!
        Me.FpSpread1_Sheet1.Columns.Get(1).CellType = TextCellType1
        Me.FpSpread1_Sheet1.Columns.Get(1).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(1).Width = 127.0!
        Me.FpSpread1_Sheet1.Columns.Get(2).CellType = TextCellType2
        Me.FpSpread1_Sheet1.Columns.Get(2).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(2).Width = 315.0!
        NumberCellType2.DecimalPlaces = 2
        NumberCellType2.DecimalSeparator = "."
        NumberCellType2.Separator = ","
        NumberCellType2.ShowSeparator = True
        Me.FpSpread1_Sheet1.Columns.Get(3).CellType = NumberCellType2
        Me.FpSpread1_Sheet1.Columns.Get(3).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(3).Width = 109.0!
        Me.FpSpread1_Sheet1.Columns.Get(4).Width = 71.0!
        NumberCellType3.DecimalPlaces = 2
        NumberCellType3.DecimalSeparator = "."
        NumberCellType3.Separator = ","
        NumberCellType3.ShowSeparator = True
        Me.FpSpread1_Sheet1.Columns.Get(5).CellType = NumberCellType3
        Me.FpSpread1_Sheet1.Columns.Get(5).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(5).Width = 113.0!
        Me.FpSpread1_Sheet1.Columns.Get(6).Locked = True
        Me.FpSpread1_Sheet1.Columns.Get(7).Locked = True
        Me.FpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.FpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.FpSpread1_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderSunburst"
        Me.FpSpread1_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FpSpread1_Sheet1.SelectionForeColor = System.Drawing.Color.White
        Me.FpSpread1_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.FpSpread1_Sheet1.SheetCornerStyle.Parent = "CornerSunburst"
        Me.FpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(920, 701)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 50)
        Me.Label23.TabIndex = 485
        Me.Label23.Text = "MENU ANTERIOR"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(824, 701)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 50)
        Me.Label21.TabIndex = 484
        Me.Label21.Text = "GUARDAR REGISTRO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Enabled = False
        Me.TxtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotivo.Location = New System.Drawing.Point(76, 595)
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.Size = New System.Drawing.Size(677, 22)
        Me.TxtMotivo.TabIndex = 486
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(73, 567)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 25)
        Me.Label1.TabIndex = 487
        Me.Label1.Text = "Motivo de Devolución"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.TXT_PASSWORD)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(377, 358)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(271, 53)
        Me.Panel1.TabIndex = 771
        Me.Panel1.Visible = False
        '
        'TXT_PASSWORD
        '
        Me.TXT_PASSWORD.Location = New System.Drawing.Point(50, 24)
        Me.TXT_PASSWORD.Name = "TXT_PASSWORD"
        Me.TXT_PASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_PASSWORD.Size = New System.Drawing.Size(165, 20)
        Me.TXT_PASSWORD.TabIndex = 548
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(221, 16)
        Me.Label5.TabIndex = 546
        Me.Label5.Text = "Ingrese Clave para Devolución"
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TxtBuscar.Location = New System.Drawing.Point(172, 159)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(306, 20)
        Me.TxtBuscar.TabIndex = 23926
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label41.ForeColor = System.Drawing.Color.Navy
        Me.Label41.Location = New System.Drawing.Point(73, 161)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(99, 18)
        Me.Label41.TabIndex = 23925
        Me.Label41.Text = "&Buscar Artículo"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrRegreso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.TxtBuscar)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMotivo)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.FpSpread1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lcaja)
        Me.Controls.Add(Me.caja)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_total)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tx_buscaticket)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrRegreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolución De Mercancía"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FpSpread1_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Sub imprimeTicket(ByRef pre As Collection)
        Dim oImpresion As Impresion
        oImpresion = New Impresion(pre)
        oImpresion.imprime(True)
    End Sub
    Public Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Dispose()
        Me.Hide()
    End Sub

    Private Sub FrRegreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Globales.caja = "vscaja7" Then
            caja.Visible = True
            lcaja.Visible = True

        Else
            caja.Visible = False
            lcaja.Visible = False
        End If

        Me.TxtMotivo.Text = ""
        Me.tx_buscaticket.Focus()
        autorization = False
        VengoDe = ""
        Label11.Text = Label11.Text & Today.ToShortDateString
        Label12.Text = "Hora: " & DateTime.Now.Hour.ToString & ":" & Mid("00" & DateTime.Now.Minute.ToString, 2, 2) & ":00"

    End Sub
    Public Sub limpiaSpread()
        With Me.FpSpread1.ActiveSheet
            .RowCount = 0
        End With
    End Sub

    Private Sub RellenaTicket(ByVal Ticket As Integer)
        Dim dsc As New DataSet
        Dim sql As String
        Dim i As Integer

        limpiaSpread()

        sql = "select*from ecventa where ven_id='" & Me.tx_buscaticket.Text.Trim & "'"
        Base.daQuery(sql, xCon, dsc, "art")
        autorization = False
        If dsc.Tables("Art").Rows.Count > 0 Then
            If (DateAndTime.DateDiff(DateInterval.Minute, CDate(dsc.Tables("art").Rows(0)("ven_fecha")), Now) > 30 And Not AutorizaRetiro) Then
                MsgBox("El ticket excede el tiempo definido, no pueden hacerse la devolución. Se requiere de autorización especial.", vbExclamation, "Devolución de Artículos")
                btn_aceptar.Enabled = False
                autorization = True
                Corriendo = True
                AutorizaRetiro = False
                VengoDe = "Rellena"
                Panel1.Location = New Point(Me.Width / 2 - Panel1.Width, Me.Height / 2 - Panel1.Height)
                Panel1.Visible = True
                TXT_PASSWORD.Text = ""
                TXT_PASSWORD.Focus()
                Corriendo = False
                Exit Sub
            Else
                If (DateAndTime.DateDiff(DateInterval.Hour, CDate(dsc.Tables("art").Rows(0)("ven_fecha")), Now)) < 3 Then
                    autorization = False
                End If
            End If
        Else
            MsgBox("No existe Ticket.", vbExclamation, "Devolución de Artículos")
            dsc.Tables.Remove("Art")
            Exit Sub
        End If
        dsc.Tables.Remove("Art")

        btn_aceptar.Enabled = True
        'sql = "select dve_renglon, dve_articulo,dve_upc, descripcion,cant, " &
        '  "dve_precio,ISNULL(X.cantDEV,0) as cantdev " &
        '  "from " &
        '  "(select dve_renglon, dve_articulo,dve_upc,upc_descripcion as descripcion,sum(dve_cantidad) cant , " &
        '  "dve_precio from ecventadet " &
        '  "inner join ecventa on ecventa.ven_id=ecventadet.dve_venta " &
        '  "inner join xupc on upc_cveart=dve_articulo and upc_upc=dve_upc " &
        '  "where ven_id=" & Me.tx_buscaticket.Text & " and ven_status=1 group by dve_renglon, dve_articulo,dve_upc,dve_precio,upc_descripcion) a " &
        '  " left join ( " &
        '  "SELECT ID_ARTICULO,upc_upc,SUM(CANTIDAD)AS CANTDEV FROM eccancxupc " &
        '  " WHERE N_TICKET= " & Me.tx_buscaticket.Text & " GROUP BY ID_ARTICULO,upc_upc ) X on x.id_articulo=a.dve_articulo " &
        '  " and X.upc_upc=a.DVE_upc order by DVE_RENGLON asc"

        sql = "select dve_renglon, dve_articulo,dve_upc, descripcion,cant, dve_precio,ISNULL(X.cantDEV,0) as cantdev, " &
       "case when exists (select dve_venta from ecventadete h where h.dve_venta=a.ven_id and h.DVE_UPC=a.DVE_UPC) then '1' else '0' end as vale " &
       "from (select ven_id ,a.dve_renglon, a.dve_articulo,a.dve_upc,upc_descripcion as descripcion,sum(a.dve_cantidad) cant , a.dve_precio from ecventadet " &
       "a inner join ecventa on ecventa.ven_id=a.dve_venta inner join xupc on upc_upc=a.dve_upc " &
       "where ven_id=" & Me.tx_buscaticket.Text & " And ven_status=1 group by ven_id,dve_renglon, a.dve_articulo,a.dve_upc,a.dve_precio,upc_descripcion) a left join " &
       "(SELECT ID_ARTICULO,upc_upc,SUM(CANTIDAD)AS CANTDEV FROM eccancxupc WHERE N_TICKET=" & Me.tx_buscaticket.Text & " GROUP BY ID_ARTICULO,upc_upc ) X on x.id_articulo=a.dve_articulo " &
       "and X.upc_upc=a.DVE_upc order by DVE_RENGLON asc"

        Base.daQuery(sql, xCon, dsc, "art")

        FpSpread1.ActiveSheet.RowCount = dsc.Tables("art").Rows.Count
        FpSpread1.ActiveSheet.Columns(5).Visible = True


        For i = 0 To dsc.Tables("art").Rows.Count - 1
            FpSpread1.ActiveSheet.Cells(i, 0).Value = CDbl(dsc.Tables("art").Rows(i)("cant")) - CDbl(dsc.Tables("art").Rows(i)("cantdev"))
            FpSpread1.ActiveSheet.Cells(i, 2).Value = dsc.Tables("art").Rows(i)("descripcion")
            FpSpread1.ActiveSheet.Cells(i, 3).Value = CDbl(dsc.Tables("art").Rows(i)("dve_precio"))
            FpSpread1.ActiveSheet.Cells(i, 6).Value = dsc.Tables("ART").Rows(i)("DVE_ARTICULO")
            FpSpread1.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ART").Rows(i)("dve_upc")
            FpSpread1.ActiveSheet.Cells(i, 7).Value = dsc.Tables("ART").Rows(i)("vale")
        Next

        FpSpread1.ActiveSheet.ActiveRowIndex = 0
        FpSpread1.ActiveSheet.ActiveColumnIndex = 3
        PINTA(FpSpread1.ActiveSheet.ActiveRowIndex, 1, FpSpread1)
        TxtMotivo.Enabled = True
        FpSpread1.Focus()
    End Sub

    Private Sub tx_buscaticket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tx_buscaticket.KeyPress


        If Asc(e.KeyChar) = Keys.Enter And tx_buscaticket.Text <> "" Then
            If IsNumeric(tx_buscaticket.Text) Then
                RellenaTicket(tx_buscaticket.Text.Trim)
            Else
                MsgBox("El folio del ticket debe ser numérico.", MsgBoxStyle.Exclamation, "Devolución de Mercancías")
                tx_buscaticket.Text = ""
                tx_buscaticket.Focus()
            End If


        End If
    End Sub


    Private Sub fp_Devolucion_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpread1.Change
        Dim i As Integer
        On Error Resume Next
        If FpSpread1.ActiveSheet.Cells(e.Row, 0).Value < FpSpread1.ActiveSheet.Cells(e.Row, 4).Value Then
            MsgBox("No puede devolver más cantidad que la comprada en este ticket", vbExclamation, "Devolución de Mercancías")
            FpSpread1.ActiveSheet.Cells(e.Row, 4).Value = 0
            FpSpread1.ActiveSheet.SetActiveCell(e.Row, 4)
            FpSpread1.Focus()
        ElseIf FpSpread1.ActiveSheet.Cells(e.Row, 4).Value < 0 Then
            MsgBox("La cantidad a devolver no puede ser negativa.", vbExclamation, "Devolución de Mercancías")
            FpSpread1.ActiveSheet.Cells(e.Row, 4).Value = 0
            FpSpread1.ActiveSheet.SetActiveCell(e.Row, 4)
            FpSpread1.Focus()
        Else
            totalote = 0
            For i = 0 To FpSpread1.ActiveSheet.RowCount - 1
                totalote = totalote + FpSpread1.ActiveSheet.Cells(i, 4).Value * FpSpread1.ActiveSheet.Cells(i, 3).Value
                FpSpread1.ActiveSheet.Cells(i, 5).Value = FpSpread1.ActiveSheet.Cells(i, 4).Value * FpSpread1.ActiveSheet.Cells(i, 3).Value
            Next
            tb_total.Text = Format(totalote, "$###,##0.00")
            'fp_Devolucion.ActiveSheet.ActiveRowIndex = e.Row + 1
            FpSpread1.Focus()
        End If
    End Sub

    Private Sub fp_Devolucion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpSpread1.KeyUp
        '    If e.KeyCode = Keys.Down Then
        '    If fp_Devolucion.ActiveSheet.RowCount - 1 >= fp_Devolucion.ActiveSheet.ActiveRowIndex Then
        '    PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex, 1, 12)
        '    PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex - 1, 2, 12)
        '    End If
        '   End If
        '   If e.KeyCode = Keys.Up Then
        '   PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex, 1, 12)
        '   PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex + 1, 2, 12)
        '   End If

        If e.KeyCode = Keys.Left Then
            FpSpread1.ActiveSheet.ActiveColumnIndex = 4
        End If
        If e.KeyCode = Keys.Right Then
            FpSpread1.ActiveSheet.ActiveColumnIndex = 4
        End If

        FpSpread1.ActiveSheet.ActiveColumnIndex = 4
        'If e.KeyCode = Keys.Enter Then
        'fp_Devolucion.ActiveSheet.ActiveRowIndex = fp_Devolucion.ActiveSheet.ActiveRowIndex + 1
        'End If
    End Sub


    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If TxtMotivo.Text.Trim <> "" Then
            If caja.Visible Then
                If caja.SelectedIndex > -1 Then
                    If Not IsNumeric(caja.SelectedItem) Then
                        MsgBox("Número de caja debe ser numérico.", vbExclamation, "Devolución de Artículos")
                        Exit Sub
                    End If
                Else
                    MsgBox("No ha indicado de qué caja se hará la devolución.", vbExclamation, "Devolución de Artículos")
                    Exit Sub
                End If
            End If
        Else
            MsgBox("Especifique la razón de la devolución.", vbInformation, "Devolución de Artículos")
            TxtMotivo.Focus()
            Exit Sub
        End If

        Dim Entre As Boolean = False
        Dim LlevaVale As Boolean = False
        For i As Integer = 0 To FpSpread1.ActiveSheet.Rows.Count - 1
            If FpSpread1.ActiveSheet.Cells(i, 4).Value > 0 Then
                Entre = True
                If FpSpread1.ActiveSheet.Cells(i, 7).Value = 1 Then
                    LlevaVale = True
                End If
                If LlevaVale And Entre Then
                    Exit For
                End If
            End If
        Next
        If Entre Then
            Dim Pasa As Boolean = False
            If autorization Then
                Pasa = True
            ElseIf (LlevaVale And AutorizaRetiro) Then
                Pasa = True
            ElseIf (LlevaVale = False And autorization = False) Then
                Pasa = True
            Else
                Pasa = False
            End If
            If Pasa Then
                'Dim foma As Form
                'foma = New frautorizado(Me)
                'foma.BringToFront()
                'foma.ShowDialog()
            Else
                MsgBox("Existen artículos ligados a un vale de entrega de mercancía. Se requiere de autorización especial.", vbExclamation, "Devolución de Artículos")

                Corriendo = True
                VengoDe = "Aceptar"
                AutorizaRetiro = False
                Panel1.Location = New Point(Me.Width / 2 - Panel1.Width, Me.Height / 2 - Panel1.Height)
                Panel1.Visible = True
                TXT_PASSWORD.Text = ""
                TXT_PASSWORD.Focus()
                Corriendo = False
                Exit Sub
            End If
        Else
            MsgBox("No ha indicado qué artículos serán devueltos.", vbExclamation, "Devolución de Artículos")
        End If
    End Sub



    Private Sub fp_Devolucion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpSpread1.KeyDown
        '    If e.KeyCode = Keys.Down Then
        '    If fp_Devolucion.ActiveSheet.RowCount - 1 >= fp_Devolucion.ActiveSheet.ActiveRowIndex Then
        '    PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex, 1, 12)
        '    PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex - 1, 2, 12)
        '    End If
        '    End If
        '    If e.KeyCode = Keys.Up Then
        '    PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex, 1, 12)
        '    PINTA(fp_Devolucion.ActiveSheet.ActiveRowIndex + 1, 2, 12)
        '    End If
    End Sub

    Private Sub fp_Devolucion_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FpSpread1.CellClick
        If Not e.ColumnHeader Then
            If e.Button = MouseButtons.Left Then
                PINTA(sender.ActiveSheet.ActiveRowIndex, 2, sender)
                PINTA(e.Row, 1, sender)
            Else
                PINTA(sender.ActiveSheet.ActiveRowIndex, 2, sender)
                sender.ActiveSheet.ActiveRowIndex = e.Row
                PINTA(e.Row, 1, sender)
            End If
        End If

        Panel1.Visible = False
        AutorizaRetiro = False
        TXT_PASSWORD.Text = ""
    End Sub

    Private Sub fp_Devolucion_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FpSpread1.LeaveCell

        PINTA(e.Row, 2, sender)
        PINTA(e.NewRow, 1, sender)

    End Sub

    Private Sub TXT_PASSWORD_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_PASSWORD.KeyDown
        Dim SQL As String
        Dim DSC As New DataSet

        If e.KeyCode = Keys.Enter Then
            If TXT_PASSWORD.Text <> "" Then
                SQL = "select * from ecusuariosx where emp_password='" & TXT_PASSWORD.Text & "' and emp_tipo='SUP'"
                Base.daQuery(SQL, xCon, DSC, "aut")
                If DSC.Tables("aut").Rows.Count > 0 Then
                    AutorizaRetiro = True
                    If VengoDe = "Rellena" Then
                        RellenaTicket(tx_buscaticket.Text.Trim)
                    ElseIf VengoDe = "Aceptar" Then
                        Me.btn_aceptar_Click(sender, e)
                    End If
                Else
                    MsgBox("Password incorrecto.", vbExclamation, "Autoriza")
                    AutorizaRetiro = False
                    TXT_PASSWORD.Text = ""
                    TXT_PASSWORD.Focus()
                    tx_buscaticket.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Panel1.Visible = False
            AutorizaRetiro = False
            TXT_PASSWORD.Text = ""
            tx_buscaticket.Focus()
        End If
    End Sub

    Private Sub TXT_PASSWORD_LostFocus(sender As Object, e As EventArgs) Handles TXT_PASSWORD.LostFocus
        If Not Corriendo Then
            Panel1.Visible = False
            AutorizaRetiro = False
            TXT_PASSWORD.Text = ""
        Else
            Corriendo = False
        End If
    End Sub

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Buscar()
        ElseIf e.KeyCode = Keys.Escape Then
            FpSpread1.Focus()
        End If
    End Sub

    Private Sub Buscar()
Repite:
        Dim Fila As Integer
        Encontrado = FarPoint.Win.Spread.SearchFoundFlags.Error

        Encontrado = FpSpread1.Search(FpSpread1.ActiveSheetIndex, FpSpread1.ActiveSheetIndex, TxtBuscar.Text, False, False, False, True, True, False, False, FilaMatch + IIf(FilaMatch = 0, 0, 1), 2, FpSpread1.ActiveSheet.RowCount, 2, FpSpread1.ActiveSheetIndex, Fila, 2)
        If Encontrado = FarPoint.Win.Spread.SearchFoundFlags.CellText Then
            FilaMatch = Fila
            PINTA(FpSpread1.ActiveSheet.ActiveRowIndex, 2, FpSpread1)
            FpSpread1.ActiveSheet.ActiveRowIndex = Fila
            PINTA(Fila, 1, FpSpread1)
            'fp_devolucion.ActiveSheet.AddSelection(Fila, 2, 1, 1)
            FpSpread1.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center)


            TxtBuscar.Focus()
        Else
            If FilaMatch = 0 Then
                MsgBox("No se encontraron coincidencias.", vbExclamation, "Buscar")
            Else
                FilaMatch = 0
                GoTo Repite
            End If
        End If

    End Sub

    Private Sub PINTA(ByVal renglon As Integer, ByVal color As Integer, FpSpread As FarPoint.Win.Spread.FpSpread)
        Dim acell As FarPoint.Win.Spread.Cell
        acell = FpSpread.ActiveSheet.Cells(renglon, 0, renglon, FpSpread.ActiveSheet.ColumnCount - 1)

        Select Case color
            Case 1
                acell.BackColor = System.Drawing.Color.LightBlue
            Case 2
                acell.BackColor = System.Drawing.Color.White
        End Select
    End Sub
End Class
