Imports System.Data.SqlClient
Public Class FrBuscaArt
    Inherits System.Windows.Forms.Form
    Private xCon As SqlConnection
    Dim FactorEmpaque As Double
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LbCapExis As Label
    Friend WithEvents TxtCantidad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label18 As Label
    Private fo As FrVenta

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef con As SqlConnection, ByRef forma As FrVenta)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
        xCon = con

        fo = forma


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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents menudeo As System.Windows.Forms.Label
    Friend WithEvents p1 As System.Windows.Forms.Label
    Friend WithEvents mayoreo As System.Windows.Forms.Label
    Friend WithEvents p3 As System.Windows.Forms.Label
    Friend WithEvents mayoreote As System.Windows.Forms.Label
    Friend WithEvents p2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents P4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrBuscaArt))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.menudeo = New System.Windows.Forms.Label()
        Me.p1 = New System.Windows.Forms.Label()
        Me.mayoreo = New System.Windows.Forms.Label()
        Me.p3 = New System.Windows.Forms.Label()
        Me.mayoreote = New System.Windows.Forms.Label()
        Me.p2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.P4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LbCapExis = New System.Windows.Forms.Label()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(96, 86)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(697, 22)
        Me.TextBox1.TabIndex = 2
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ItemHeight = 17
        Me.ListBox1.Location = New System.Drawing.Point(12, 114)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(811, 289)
        Me.ListBox1.TabIndex = 3
        '
        'menudeo
        '
        Me.menudeo.BackColor = System.Drawing.Color.Transparent
        Me.menudeo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menudeo.ForeColor = System.Drawing.Color.Navy
        Me.menudeo.Location = New System.Drawing.Point(12, 417)
        Me.menudeo.Name = "menudeo"
        Me.menudeo.Size = New System.Drawing.Size(136, 23)
        Me.menudeo.TabIndex = 5
        Me.menudeo.Text = "Precio Menudeo"
        Me.menudeo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p1
        '
        Me.p1.BackColor = System.Drawing.Color.Transparent
        Me.p1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.p1.ForeColor = System.Drawing.Color.Navy
        Me.p1.Location = New System.Drawing.Point(12, 444)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(136, 23)
        Me.p1.TabIndex = 6
        Me.p1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mayoreo
        '
        Me.mayoreo.BackColor = System.Drawing.Color.Transparent
        Me.mayoreo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mayoreo.ForeColor = System.Drawing.Color.Navy
        Me.mayoreo.Location = New System.Drawing.Point(202, 417)
        Me.mayoreo.Name = "mayoreo"
        Me.mayoreo.Size = New System.Drawing.Size(136, 23)
        Me.mayoreo.TabIndex = 7
        Me.mayoreo.Text = "Precio Mayoreo"
        Me.mayoreo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p3
        '
        Me.p3.BackColor = System.Drawing.Color.Transparent
        Me.p3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.p3.ForeColor = System.Drawing.Color.Navy
        Me.p3.Location = New System.Drawing.Point(392, 444)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(136, 23)
        Me.p3.TabIndex = 10
        Me.p3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mayoreote
        '
        Me.mayoreote.BackColor = System.Drawing.Color.Transparent
        Me.mayoreote.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mayoreote.ForeColor = System.Drawing.Color.Navy
        Me.mayoreote.Location = New System.Drawing.Point(392, 417)
        Me.mayoreote.Name = "mayoreote"
        Me.mayoreote.Size = New System.Drawing.Size(136, 23)
        Me.mayoreote.TabIndex = 9
        Me.mayoreote.Text = "Precio Duarsa"
        Me.mayoreote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p2
        '
        Me.p2.BackColor = System.Drawing.Color.Transparent
        Me.p2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.p2.ForeColor = System.Drawing.Color.Navy
        Me.p2.Location = New System.Drawing.Point(202, 444)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(136, 23)
        Me.p2.TabIndex = 8
        Me.p2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(582, 417)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 23)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Capacidad Empaque"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'P4
        '
        Me.P4.BackColor = System.Drawing.Color.Transparent
        Me.P4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P4.ForeColor = System.Drawing.Color.Navy
        Me.P4.Location = New System.Drawing.Point(582, 444)
        Me.P4.Name = "P4"
        Me.P4.Size = New System.Drawing.Size(178, 23)
        Me.P4.TabIndex = 12
        Me.P4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.P4.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(737, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 479
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(737, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 478
        Me.Label3.Text = "Existencia"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label3.Visible = False
        '
        'LbCapExis
        '
        Me.LbCapExis.BackColor = System.Drawing.Color.Transparent
        Me.LbCapExis.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCapExis.ForeColor = System.Drawing.Color.Navy
        Me.LbCapExis.Location = New System.Drawing.Point(12, 483)
        Me.LbCapExis.Name = "LbCapExis"
        Me.LbCapExis.Size = New System.Drawing.Size(811, 21)
        Me.LbCapExis.TabIndex = 481
        Me.LbCapExis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(12, 86)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(78, 22)
        Me.TxtCantidad.TabIndex = 482
        Me.TxtCantidad.Text = "1"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(12, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 22)
        Me.Label4.TabIndex = 483
        Me.Label4.Text = "Cantidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(96, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 22)
        Me.Label5.TabIndex = 484
        Me.Label5.Text = "Descripción"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(178, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(243, 21)
        Me.Label20.TabIndex = 23911
        Me.Label20.Text = "Búsqueda de Artículos"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(178, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(296, 21)
        Me.Label18.TabIndex = 23909
        Me.Label18.Text = "Punto de Venta"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23910
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.ECVENTA4.My.Resources.Resources._1485477101_arrow_left_786051
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(799, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FrBuscaArt
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(891, 513)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.LbCapExis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.P4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.p3)
        Me.Controls.Add(Me.mayoreote)
        Me.Controls.Add(Me.p2)
        Me.Controls.Add(Me.mayoreo)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.menudeo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrBuscaArt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda De Artículos"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim Precio1, Precio2, Precio3, Tope As Double
    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs)

    End Sub

    Private Sub FrBuscaArt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = fo.TX_UPC.Text
        Call rellenalista()
    End Sub

    Private Sub FrBuscaArt_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Call rellenalista()
    End Sub

    Private Sub rellenalista()
        Me.ListBox1.Items.Clear()
        p1.Text = ""
        p2.Text = ""
        p3.Text = ""
        P4.Text = ""
        Precio1 = 0
        Precio2 = 0
        Precio3 = 0
        Tope = 1
        Label2.Text = ""
        LbCapExis.Text = ""

        ' Definición de precios dinamicos (Caja vs Unidad)
        Dim SQLPrecio1 As String = "CASE WHEN ISNULL(xupc.upc_factor,1) > 1 THEN round(art_precio3 * ISNULL(xupc.upc_factor,1), 2) ELSE round(art_precio1, 2) END"
        Dim SQLPrecio2 As String = "CASE WHEN ISNULL(xupc.upc_factor,1) > 1 THEN round(art_precio3 * ISNULL(xupc.upc_factor,1), 2) ELSE round(art_precio2, 2) END"
        Dim SQLPrecio3 As String = "CASE WHEN ISNULL(xupc.upc_factor,1) > 1 THEN round(art_precio3 * ISNULL(xupc.upc_factor,1), 2) ELSE round(art_precio3, 2) END"

        Me.ListBox1.Items.Add("Descripcion".PadRight(36) & "Menudeo" & "    Mayoreo" & "    Duarsa" & "    UPC")

        FactorEmpaque = 1
        Dim com As New SqlCommand
        com.Connection = Me.xCon

        ' CORRECCION AQUI: Se cambió el último SQLPrecio1 por SQLPrecio3
        com.CommandText = "select left(upc_descripcion + space(30), 30) + SPACE(5) + " &
                      "'($'+right(space(7) + convert(varchar(10), " & SQLPrecio1 & "),7)+')'+space(1)+" &
                      "'($'+right(space(7) + convert(varchar(10), " & SQLPrecio2 & "),7)+')'+space(1)+" &
                      "'($'+right(space(7) + convert(varchar(10), " & SQLPrecio3 & "),7)+')'+space(1)+" &
                      "'UPC ' + upc_upc  " &
                      "from Xupc inner join articulo on upc_cveart=art_Clave " &
                      "where UPC_DESCRIPCION like '%" & Me.TextBox1.Text.Replace("'", "") & "%' " &
                      "and ( " &
                          "(upc_upc=UPC_CODINV) " & _                      ' Muestra Unidades Principales
                          "OR (art_codrel<>'' and UPC_CODINV='') " & _     ' Muestra Dulces Viejos
                          "OR (ISNULL(xupc.upc_factor, 1) > 1) " & _       ' Muestra Cajas Nuevas
                      ") " &
                      "and art_activo=1 and upc_activo=1 " &
                      "order by upc_descripcion"

        Dim rdr As SqlDataReader
        Try
            xCon.Open()
            rdr = com.ExecuteReader
            While rdr.Read()
                Me.ListBox1.Items.Add(rdr.GetValue(0))
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        xCon.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.Items.Count = 1 Then
            ListBox1.ClearSelected()
            TextBox1.Focus()
        End If

        If ListBox1.SelectedIndex > 0 Then
            Dim sql As String
            Dim d As New DataSet

            'sql = "select art_cap1,art_CAP2,ART_UNI1,ART_UNI2,art_precio1,art_precio2,art_precio3 from Xupc inner join articulo on upc_cveart=art_Clave where convert(char(30),upc_descripcion)+SPACE(2)+'('+convert(CHAR(7),art_precio1)+')('+ convert(CHAR(7),art_precio2)+')('+convert(char(7),art_precio3)+')'+ space(2)+'COD ' + upc_upc='" & Me.ListBox1.SelectedItem & "'"         
            Dim UPC As String
            Dim i As Integer
            i = 1
            'Do Until Strings.Left(Strings.Right(Me.ListBox1.SelectedItem, i), 1) = " "
            '    i += 1
            'Loop
            UPC = Strings.Right(Me.ListBox1.SelectedItem, Len(Me.ListBox1.SelectedItem) - InStr(Me.ListBox1.SelectedItem, "UPC") - 3).Trim

            sql = "select art_clave, ISNULL(xupc.upc_factor, 1) as Factor, art_cap1,art_CAP2,ART_UNI1,ART_UNI2,art_precio1,art_precio2,art_precio3,ART_TOPEMAY " &
      "from Xupc inner Join articulo on upc_cveart=art_Clave where art_activo=1 and upc_activo=1 and upc_upc='" & UPC & "'"

            Base.daQuery(sql, xCon, d, "tabla")
            Dim Cant As Double = 1
            If TxtCantidad.Text <> "" Then
                Cant = TxtCantidad.Text
            End If

            Dim FactorVenta As Double = d.Tables("tabla").Rows(0)("Factor") ' Este viene de XUPC (1 o 24)
            Dim Cap1 As Double = d.Tables("tabla").Rows(0)("art_CAP1")
            Dim Cap2 As Double = d.Tables("tabla").Rows(0)("art_CAP2")

            FactorEmpaque = Cap1 * Cap2
            If FactorEmpaque = 0 Then FactorEmpaque = 1 ' Protección contra división por cero

            Dim PrecioBaseCaja As Double = 0

            If FactorVenta > 1 Then
                ' ES CAJA: Usamos Precio 3 (Mayoreo) como base
                PrecioBaseCaja = d.Tables("tabla").Rows(0)("art_precio3") * FactorVenta

                ' Fijamos los 3 niveles de precio al mismo valor (Precio de Caja Cerrada)
                ' Para evitar que por error se venda una caja a precio de menudeo unitario x 24
                Precio1 = PrecioBaseCaja
                Precio2 = PrecioBaseCaja
                Precio3 = PrecioBaseCaja
            Else
                ' ES PIEZA: Comportamiento normal
                Precio1 = d.Tables("tabla").Rows(0)("art_precio1")
                Precio2 = d.Tables("tabla").Rows(0)("art_precio2")
                Precio3 = d.Tables("tabla").Rows(0)("art_precio3")
            End If


            Tope = d.Tables("tabla").Rows(0)("ART_TOPEMAY")
            FactorEmpaque = d.Tables("tabla").Rows(0)("art_CAP1") * d.Tables("tabla").Rows(0)("art_CAP2")
            p1.Text = FormatCurrency(Precio1 * Cant, 2)
            p2.Text = FormatCurrency(Precio2 * Cant, 2)
            p3.Text = FormatCurrency(Precio3 * Cant, 2)
            P4.Text = d.Tables("tabla").Rows(0)("art_CAP1") & " " & d.Tables("tabla").Rows(0)("art_UNI1") & " / " & d.Tables("tabla").Rows(0)("art_CAP2") & " " & d.Tables("tabla").Rows(0)("art_UNI2")

            Existencias(UPC)


            'Base.Ejecuta("exec calcexistencianxart '" & Globales.nombreusuario & "','" & d.Tables("tabla").Rows(0)("art_clave").ToString.Trim & "'", xCon)

            'sql = "select * from ExistenciasArticuloActualizadas where usuario='" & Globales.nombreusuario & "' and upc='" & UPC & "'"

            'Base.daQuery(sql, xCon, d, "upc")

            'If d.Tables("upc").Rows.Count > 0 Then

            '    Label2.Text = Math.Truncate((d.Tables("upc").Rows(0)("existencia") - d.Tables("upc").Rows(0)("cantidadcustodias") + d.Tables("upc").Rows(0)("cantidadsucursales")) / (d.Tables("tabla").Rows(0)("art_CAP1") * d.Tables("tabla").Rows(0)("art_CAP2"))) & " " & d.Tables("tabla").Rows(0)("art_UNI1") & " y " & Math.Truncate((((d.Tables("upc").Rows(0)("existencia") - d.Tables("upc").Rows(0)("cantidadcustodias") + d.Tables("upc").Rows(0)("cantidadsucursales")) / (d.Tables("tabla").Rows(0)("art_CAP1") * d.Tables("tabla").Rows(0)("art_CAP2"))) - Math.Truncate((d.Tables("upc").Rows(0)("existencia") - d.Tables("upc").Rows(0)("cantidadcustodias") + d.Tables("upc").Rows(0)("cantidadsucursales")) / (d.Tables("tabla").Rows(0)("art_CAP1") * d.Tables("tabla").Rows(0)("art_CAP2")))) * d.Tables("tabla").Rows(0)("art_CAP1") * d.Tables("tabla").Rows(0)("art_CAP2")) & " " & d.Tables("tabla").Rows(0)("art_UNI2")

            '    If d.Tables("upc").Rows(0)("CantidadAlmacenes") > 0 Then
            '        Dim DSC As New DataSet
            '        sql = "select almacen,cap1*Cap2*Cantidad Cantidad from ExistenciasAlmacenes where upc='" & UPC & "'"
            '        Try
            '            Base.daQuery(sql, xCon, DSC, "Alm")
            '            Using DSC
            '                If DSC.Tables("Alm").Rows.Count > 0 Then
            '                    Dim StrTmp As String
            '                    For i = 0 To DSC.Tables("Alm").Rows.Count - 1
            '                        StrTmp = IIf(StrTmp = "", DSC.Tables("Alm").Rows(i)("Almacen") & ": " & DSC.Tables("Alm").Rows(i)("Cantidad") / FactorEmpaque, StrTmp & " | " & DSC.Tables("Alm").Rows(i)("Almacen").ToString & ": " & DSC.Tables("Alm").Rows(i)("Cantidad") / FactorEmpaque)
            '                    Next
            '                    Label4.Text = StrTmp
            '                Else
            '                    Label4.Text = ""
            '                End If
            '            End Using
            '        Catch ex As Exception

            '        End Try
            '    Else
            '        Label4.Text = ""
            '    End If
            'Else
            '    Label2.Text = "N/A"
            '    Label4.Text = ""
            'End If

            d.Tables.Remove("tabla")
            'd.Tables.Remove("upc")
        Else
            If ListBox1.Items.Count > 1 Then
                ListBox1.SelectedIndex = 1
            Else
                p1.Text = ""
                p2.Text = ""
                p3.Text = ""
                P4.Text = ""
                Precio1 = 0
                Precio2 = 0
                Precio3 = 0
                Tope = 1
                Label2.Text = ""
                LbCapExis.Text = ""
            End If
        End If


    End Sub

    Private Sub Existencias(ByVal UPC As String)
        ' --- MODIFICACION SQL PARA TRANSICION ---
        ' Si el UPC tiene factor > 1 (es caja nueva), devolvemos art_codrel VACIO para forzar el uso de la capacidad directa.
        ' Si es factor 1 (dulce viejo), devolvemos el art_codrel real para respetar la lógica recursiva.
        Dim SQL As String = "select " &
                            "CASE WHEN ISNULL(x.upc_factor, 1) > 1 THEN '' ELSE art_codrel END as art_codrel, " &
                            "art_clave, art_cap1, art_uni1, art_cap2, art_uni2 " &
                            "from articulo " &
                            "join xupc x on upc_cveart=art_clave " &
                            "where upc_upc='" & UPC & "'"

        Dim DSC As New DataSet
        ' OJO: Se eliminó 'Dim FactorEmpaque As Double' para usar la variable global de la clase.

        Base.daQuery(SQL, xCon, DSC, "Cap")
        If DSC.Tables("Cap").Rows.Count > 0 Then
            ' Bloque Legacy: Solo entra si es un producto viejo con relación padre-hijo explícita
            If DSC.Tables("Cap").Rows(0)("art_codrel") <> "" Then
                SQL = "select distinct UPC_CODINV from ARTICULO join XUPC on ART_CLAVE=upc_cveart where ART_CLAVE='" & DSC.Tables("Cap").Rows(0)("art_codrel") & "'"
                Base.daQuery(SQL, xCon, DSC, "CapRel")
                If DSC.Tables("CapRel").Rows.Count > 0 Then
                    UPC = DSC.Tables("CapRel").Rows(0)("upc_codinv")
                    DSC.Tables.Remove("Cap")
                    ' Buscamos las capacidades del Padre Legacy
                    SQL = "select art_codrel,art_clave, art_cap1, art_uni1, art_cap2, art_uni2 from articulo join xupc on upc_cveart=art_clave where upc_upc='" & UPC & "'"
                    Base.daQuery(SQL, xCon, DSC, "Cap")
                    If DSC.Tables("Cap").Rows.Count = 0 Then
                        DSC.Tables.Remove("Cap")
                        Exit Sub
                    End If
                End If
                DSC.Tables.Remove("CapRel")
            End If

            ' Calculamos el Factor de Empaque Físico (Para mostrar existencias en cajas/piezas)
            FactorEmpaque = DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2")

            ' Ejecuta el SP de cálculo de existencias sobre el UPC Padre/Agrupador
            Base.Ejecuta("exec calcexistencianxart '" & Globales.nombreusuario & "','" & DSC.Tables("Cap").Rows(0)("art_clave").ToString.Trim & "'", xCon)

            SQL = "select * from ExistenciasArticuloActualizadas where usuario='" & Globales.nombreusuario & "' and upc='" & UPC & "'"

            Base.daQuery(SQL, xCon, DSC, "upc")

            Dim ExistStr As String
            If DSC.Tables("upc").Rows.Count > 0 Then
                Dim CustStr, SucStr, StrAlm As String
                ' Cálculo visual de existencias (Cajas y Piezas sueltas)
                ExistStr = Math.Truncate((DSC.Tables("upc").Rows(0)("existencia") - DSC.Tables("upc").Rows(0)("cantidadcustodias") + DSC.Tables("upc").Rows(0)("cantidadsucursales")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2"))) & " " & DSC.Tables("Cap").Rows(0)("art_UNI1") & " y " & Math.Truncate((((DSC.Tables("upc").Rows(0)("existencia") - DSC.Tables("upc").Rows(0)("cantidadcustodias") + DSC.Tables("upc").Rows(0)("cantidadsucursales")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2"))) - Math.Truncate((DSC.Tables("upc").Rows(0)("existencia") - DSC.Tables("upc").Rows(0)("cantidadcustodias") + DSC.Tables("upc").Rows(0)("cantidadsucursales")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2")))) * DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2")) & " " & DSC.Tables("Cap").Rows(0)("art_UNI2")

                If DSC.Tables("upc").Rows(0)("cantidadcustodias") <> 0 Then
                    CustStr = Math.Truncate((DSC.Tables("upc").Rows(0)("cantidadcustodias")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2"))) & " " & DSC.Tables("Cap").Rows(0)("art_UNI1") & " y " & Math.Truncate((((DSC.Tables("upc").Rows(0)("cantidadcustodias")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2"))) - Math.Truncate((DSC.Tables("upc").Rows(0)("cantidadcustodias")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2")))) * DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2")) & " " & DSC.Tables("Cap").Rows(0)("art_UNI2")
                Else
                    CustStr = ""
                End If

                If DSC.Tables("upc").Rows(0)("cantidadsucursales") <> 0 Then
                    SucStr = Math.Truncate((DSC.Tables("upc").Rows(0)("cantidadsucursales")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2"))) & " " & DSC.Tables("Cap").Rows(0)("art_UNI1") & " y " & Math.Truncate((((DSC.Tables("upc").Rows(0)("cantidadsucursales")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2"))) - Math.Truncate((DSC.Tables("upc").Rows(0)("cantidadsucursales")) / (DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2")))) * DSC.Tables("Cap").Rows(0)("art_CAP1") * DSC.Tables("Cap").Rows(0)("art_CAP2")) & " " & DSC.Tables("Cap").Rows(0)("art_UNI2")
                Else
                    SucStr = ""
                End If

                If DSC.Tables("upc").Rows(0)("CantidadAlmacenes") > 0 Then
                    SQL = "select almacen,cap1*Cap2*Cantidad Cantidad from ExistenciasAlmacenes where upc='" & UPC & "'"
                    Try
                        Base.daQuery(SQL, xCon, DSC, "Alm")
                        Using DSC
                            If DSC.Tables("Alm").Rows.Count > 0 Then
                                For i = 0 To DSC.Tables("Alm").Rows.Count - 1
                                    StrAlm = IIf(StrAlm = "", DSC.Tables("Alm").Rows(i)("Almacen") & ": " & DSC.Tables("Alm").Rows(i)("Cantidad") / FactorEmpaque, StrAlm & " | " & DSC.Tables("Alm").Rows(i)("Almacen").ToString & ": " & DSC.Tables("Alm").Rows(i)("Cantidad") / FactorEmpaque)
                                Next
                            Else
                                StrAlm = ""
                            End If
                        End Using
                    Catch ex As Exception
                    End Try
                Else
                    StrAlm = ""
                End If

                ExistStr = ExistStr & IIf(StrAlm = "", "", " | " & StrAlm) & IIf(CustStr = "", "", " | Custodias: " & CustStr) & IIf(SucStr = "", "", " | Sucursales: " & SucStr)
            Else
                ExistStr = "N/A"
            End If
            DSC.Tables.Remove("upc")

            Dim CompraEmp As String
            SQL = "select top 1 dcom_cap1 Cap1, dcom_uni1 Uni1,dcom_cap2 Cap2,dcom_uni2 Uni2 from ECDETCOMPRA join eccompra on dcom_compra=com_id where dcom_articulo='" & UPC & "' and com_fechacaptura>(select max(fecha) from eccontrolinv) order by com_fechacaptura desc"
            Base.daQuery(SQL, xCon, DSC, "CapCom")
            If DSC.Tables("CapCom").Rows.Count > 0 Then
                CompraEmp = DSC.Tables("CapCom").Rows(0)("Cap1") & " " & DSC.Tables("CapCom").Rows(0)("Uni1") & " / " & DSC.Tables("CapCom").Rows(0)("Cap2") & " " & DSC.Tables("CapCom").Rows(0)("Uni2")
                If CompraEmp = DSC.Tables("Cap").Rows(0)("art_cap1") & " " & DSC.Tables("Cap").Rows(0)("art_uni1") & " / " & DSC.Tables("Cap").Rows(0)("art_cap2") & " " & DSC.Tables("Cap").Rows(0)("art_uni2") Then
                    CompraEmp = ""
                End If
            End If
            DSC.Tables.Remove("CapCom")

            LbCapExis.Text = "Existencia: " & ExistStr & " | Capacidad Empaque: " & DSC.Tables("Cap").Rows(0)("art_cap1") & " " & DSC.Tables("Cap").Rows(0)("art_uni1") & " / " & DSC.Tables("Cap").Rows(0)("art_cap2") & " " & DSC.Tables("Cap").Rows(0)("art_uni2") & IIf(CompraEmp <> "", " | Capacidad Empaque Última Compra: " & CompraEmp, "")
            LbCapExis.Visible = True
        Else
            LbCapExis.Text = ""
        End If
        DSC.Tables.Remove("Cap")
    End Sub
    Private Sub ListBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox1.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.ListBox1.SelectedIndex >= 1 Then

                'Dim sql As String = ""
                'Dim dsc As New DataSet
                'Sql = "select upc_upc from Xupc inner join articulo on upc_cveart=art_Clave where convert(char(30),upc_descripcion)+SPACE(2)+'('+convert(CHAR(7),art_precio1)+')('+ convert(CHAR(7),art_precio2)+')('+convert(char(7),art_precio3)+')'+ space(2)+'COD ' + upc_upc= '" & Me.ListBox1.SelectedItem & "'"

                ' Base.daQuery(sql, xCon, dsc, "articulo")
                Dim UPC As String
                Dim i As Integer
                i = 1
                Do Until Strings.Left(Strings.Right(Me.ListBox1.SelectedItem, i), 1) = " "
                    i += 1
                Loop
                UPC = Strings.Right(Me.ListBox1.SelectedItem, i).Trim


                'If dsc.Tables("articulo").Rows.Count > 0 Then
                fo.TX_UPC.Text = UPC
                fo.busqueda.Visible = False
                'SendKeys.Send(Chr(13))
                Me.Hide()
                Me.Dispose()
                'End If
            End If
        End If
        If Asc(e.KeyChar) = Keys.Escape Then

            TextBox1.Focus()
            ListBox1.ClearSelected()
            TextBox1.SelectAll()
            'fo.busqueda.Visible = False
            'fo.TX_UPC.Text = ""
            'SendKeys.Flush()
            'fo.TX_UPC.Focus()
            'Me.Dispose(True)
            'Me.Hide()




        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        fo.TX_UPC.Text = ""
        SendKeys.Flush()
        Me.Dispose(True)
        Me.Hide()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TxtCantidad.KeyPress
        If Asc(e.KeyChar) = Keys.Escape Then
            fo.busqueda.Visible = False
            fo.TX_UPC.Text = ""
            SendKeys.Flush()
            fo.TX_UPC.Focus()

            Me.Dispose(True)
            Me.Hide()

        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            If ListBox1.Items.Count > 1 Then
                ListBox1.Focus()
                ListBox1.SelectedIndex = 1
            End If

        End If


    End Sub


    Private Sub ListBox1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Disposed
        fo.busqueda.Visible = False



    End Sub

    Private Sub TxtCantidad_TextChanged(sender As Object, e As EventArgs) Handles TxtCantidad.TextChanged
        If TxtCantidad.Text <> "" Then
            If IsNumeric(TxtCantidad.Text) Then
                p2.Text = CDbl(TxtCantidad.Text) * Precio2
                p3.Text = CDbl(TxtCantidad.Text) * Precio3
                If CDbl(TxtCantidad.Text) < Tope Then
                    p1.Text = CDbl(TxtCantidad.Text) * Precio1
                Else
                    p1.Text = p2.Text
                End If
            Else
                TxtCantidad.Text = ""
            End If
        Else
            p1.Text = Precio1
            p2.Text = Precio2
            p3.Text = Precio3
        End If
        p1.Text = FormatCurrency(p1.Text, 2)
        p2.Text = FormatCurrency(p2.Text, 2)
        p3.Text = FormatCurrency(p3.Text, 2)
    End Sub

    Private Sub TxtCantidad_Enter(sender As Object, e As EventArgs) Handles TxtCantidad.Enter
        TxtCantidad.Text = ""
    End Sub

    Private Sub TxtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown, TextBox1.KeyDown, TxtCantidad.KeyDown
        If e.KeyCode = Keys.F3 Then
            TxtCantidad.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            TextBox1.Focus()
        End If
    End Sub
End Class
