Imports System.Data.SqlClient

Imports FarPoint.Win.Spread.CellType

Public Class corteporiva
    Inherits System.Windows.Forms.Form
    Dim xcon As SqlConnection
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Dim foma As Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef con As SqlConnection, ByRef fom As FrAdmin)
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents fp_cortes As FarPoint.Win.Spread.FpSpread
    Friend WithEvents fp_cortes_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents TXT_FECHAINI As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXT_FECHAFIN As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(corteporiva))
        Me.Button1 = New System.Windows.Forms.Button
        Me.fp_cortes = New FarPoint.Win.Spread.FpSpread
        Me.fp_cortes_Sheet1 = New FarPoint.Win.Spread.SheetView
        Me.TXT_FECHAINI = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXT_FECHAFIN = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        CType(Me.fp_cortes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fp_cortes_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(725, 557)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 64)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Regresar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'fp_cortes
        '
        Me.fp_cortes.AccessibleDescription = "fp_articulos, Sheet1, Row 0, Column 0, "
        Me.fp_cortes.BackColor = System.Drawing.Color.White
        Me.fp_cortes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.fp_cortes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Me.fp_cortes.Location = New System.Drawing.Point(24, 96)
        Me.fp_cortes.Name = "fp_cortes"
        Me.fp_cortes.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical
        Me.fp_cortes.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical
        Me.fp_cortes.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.fp_cortes_Sheet1})
        Me.fp_cortes.Size = New System.Drawing.Size(776, 432)
        Me.fp_cortes.TabIndex = 222
        Me.fp_cortes.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        '
        'fp_cortes_Sheet1
        '
        Me.fp_cortes_Sheet1.Reset()
        Me.fp_cortes_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.fp_cortes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.fp_cortes_Sheet1.RowHeader.ColumnCount = 0
        Me.fp_cortes_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.Color.White
        Me.fp_cortes_Sheet1.Cells.Get(1, 0).BackColor = System.Drawing.Color.White
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 0).BackColor = System.Drawing.Color.White
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 1).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 2).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 2).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 3).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 3).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 4).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 4).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 5).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 5).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 5).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 6).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 6).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 6).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 7).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 7).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 8).BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 8).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fp_cortes_Sheet1.ColumnHeader.Cells.Get(0, 8).ForeColor = System.Drawing.SystemColors.Highlight
        Me.fp_cortes_Sheet1.GrayAreaBackColor = System.Drawing.Color.White
        Me.fp_cortes_Sheet1.HorizontalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White)
        Me.fp_cortes_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank
        Me.fp_cortes_Sheet1.RowHeader.Columns.Default.Resizable = False
        Me.fp_cortes_Sheet1.VerticalGridLine = New FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.White)
        Me.fp_cortes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        Me.fp_cortes.SetViewportTopRow(0, 0, 499)
        '
        'TXT_FECHAINI
        '
        Me.TXT_FECHAINI.Location = New System.Drawing.Point(696, 40)
        Me.TXT_FECHAINI.Name = "TXT_FECHAINI"
        Me.TXT_FECHAINI.Size = New System.Drawing.Size(104, 20)
        Me.TXT_FECHAINI.TabIndex = 302
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(608, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 24)
        Me.Label5.TabIndex = 301
        Me.Label5.Text = "Fecha Inicial:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_FECHAFIN
        '
        Me.TXT_FECHAFIN.Location = New System.Drawing.Point(696, 72)
        Me.TXT_FECHAFIN.Name = "TXT_FECHAFIN"
        Me.TXT_FECHAFIN.Size = New System.Drawing.Size(104, 20)
        Me.TXT_FECHAFIN.TabIndex = 300
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(608, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 24)
        Me.Label7.TabIndex = 299
        Me.Label7.Text = "Fecha Final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(621, 557)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 64)
        Me.Button3.TabIndex = 304
        Me.Button3.Text = "Generar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.ECVENTA4.My.Resources.Resources.CARROVOLTEADO
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Image = Global.ECVENTA4.My.Resources.Resources.logo_ec_1_
        Me.PictureBox2.Location = New System.Drawing.Point(856, 548)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 305
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.ECVENTA4.My.Resources.Resources.CARROVOLTEADO
        Me.PictureBox1.Location = New System.Drawing.Point(24, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 308
        Me.PictureBox1.TabStop = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label17.Location = New System.Drawing.Point(103, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(305, 24)
        Me.Label17.TabIndex = 307
        Me.Label17.Text = "Control de Caja ECVENTA 2009"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label19.Location = New System.Drawing.Point(103, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(305, 24)
        Me.Label19.TabIndex = 306
        Me.Label19.Text = "REPORTE DE VENTAS X CAJA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'corteporiva
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1022, 694)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TXT_FECHAINI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXT_FECHAFIN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.fp_cortes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "corteporiva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas Por Caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.fp_cortes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fp_cortes_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub configuraSpread()
        Dim oCelda As New NumberCellType
        oCelda.DecimalPlaces = 2

        With fp_cortes.ActiveSheet
            .ColumnCount = 9
            .RowCount = 0
            .ColumnHeader.RowCount = 3
            .RowHeader.ColumnCount = 0
            '.AddColumnHeaderSpanCell(0, 0, 1, 3)
            '.AddColumnHeaderSpanCell(1, 0, 1, 3)
            '.AddColumnHeaderSpanCell(2, 0, 1, 3)
            With .ColumnHeader
                .Cells(0, 0).Text = "Caja"
                .Cells(0, 1).Text = "Venta del"
                .Cells(1, 1).Text = "   Día"
                .Cells(0, 3).Text = "   Venta "
                .Cells(1, 3).Text = " Cliente1"
                .Cells(0, 4).Text = "   Venta "
                .Cells(1, 4).Text = " Cliente2"
                .Cells(0, 5).Text = "   Venta "
                .Cells(1, 5).Text = " Cliente3"
                .Cells(0, 7).Text = "  Venta "
                .Cells(1, 7).Text = " Tasa 0%"
                .Cells(0, 8).Text = "    Venta"
                .Cells(1, 8).Text = " Tasa No 0%"

                .Cells(2, 0).Text = " "
                .Cells(2, 1).Text = " "
                .Cells(2, 2).Text = " "
                .Cells(2, 3).Text = " "
                .Cells(2, 4).Text = " "
                .Cells(2, 5).Text = " "
                .Cells(2, 6).Text = " "
                .Cells(2, 7).Text = " "
                .Cells(2, 8).Text = " "

            End With
            .Columns(0).Width = 120
            .Columns(1).Width = 100
            .Columns(2).Width = 30
            .Columns(3).Width = 100
            .Columns(4).Width = 100
            .Columns(5).Width = 100
            .Columns(6).Width = 30
            .Columns(7).Width = 100
            .Columns(8).Width = 100


            .Columns(0).Locked = True
            .Columns(1).Locked = True
            .Columns(2).Locked = True
            .Columns(3).Locked = True
            .Columns(4).Locked = True
            .Columns(5).Locked = True
            .Columns(6).Locked = True
            .Columns(7).Locked = True
            .Columns(8).Locked = True

            .Columns(0).CellType = New TextCellType
            .Columns(1).CellType = New TextCellType
            .Columns(2).CellType = New TextCellType
            .Columns(3).CellType = New TextCellType
            .Columns(4).CellType = New TextCellType
            .Columns(5).CellType = New TextCellType
            .Columns(6).CellType = New TextCellType
            .Columns(7).CellType = New TextCellType
            .Columns(8).CellType = New TextCellType



            .Columns(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            .Columns(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            .Columns(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            .Columns(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            .Columns(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            .Columns(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            .Columns(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        End With
    End Sub
    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) & _
        IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
    End Function
    Private Sub corteporiva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sql As String
        Dim dsc As New DataSet
        Dim dsc1 As New DataSet
        Dim i As Integer
        Dim total1 As Double = 0
        Dim total2 As Double = 0
        Dim total3 As Double = 0
        Dim total4 As Double = 0
        Dim total5 As Double = 0
        Dim total6 As Double = 0


        '       fecha_hora.Text = Now.Today & "         " & Now.ToShortTimeString
        Call configuraSpread()


        Base.Ejecuta("exec cortestotales '" & dafecha(CDate(TXT_FECHAINI.Text)) & "','" & dafecha(CDate(TXT_FECHAFIN.Text)) & "'", xcon)

        sql = "select * from cortes order by ven_usuario"

        Base.daQuery(sql, xcon, dsc, "corte")


        If dsc.Tables("corte").Rows.Count > 0 Then
            fp_cortes.ActiveSheet.RowCount = dsc.Tables("corte").Rows.Count + 3
            For i = 0 To dsc.Tables("corte").Rows.Count - 1
                fp_cortes.ActiveSheet.Cells(i, 0).Value = "Caja " & Trim(dsc.Tables("corte").Rows(i)("ven_usuario"))
                fp_cortes.ActiveSheet.Cells(i, 1).Value = Format(CDbl(dsc.Tables("corte").Rows(i)("ventatotal")), "###,##0.00") & " "
                fp_cortes.ActiveSheet.Cells(i, 3).Value = Format(CDbl(dsc.Tables("corte").Rows(i)("ventastipo1")), "###,##0.00") & " "
                fp_cortes.ActiveSheet.Cells(i, 4).Value = Format(CDbl(dsc.Tables("corte").Rows(i)("ventastipo2")), "###,##0.00") & " "
                fp_cortes.ActiveSheet.Cells(i, 5).Value = Format(CDbl(dsc.Tables("corte").Rows(i)("ventatipo3")), "###,##0.00") & " "
                fp_cortes.ActiveSheet.Cells(i, 7).Value = Format(CDbl(dsc.Tables("corte").Rows(i)("ventaIVA")), "###,##0.00") & " "
                fp_cortes.ActiveSheet.Cells(i, 8).Value = Format(CDbl(dsc.Tables("corte").Rows(i)("ventasiva")), "###,##0.00") & " "
                total1 = total1 + CDbl(dsc.Tables("corte").Rows(i)("ventatotal"))
                total2 = total2 + CDbl(dsc.Tables("corte").Rows(i)("ventastipo1"))
                total3 = total3 + CDbl(dsc.Tables("corte").Rows(i)("ventastipo2"))
                total4 = total4 + CDbl(dsc.Tables("corte").Rows(i)("ventatipo3"))
                total5 = total5 + CDbl(dsc.Tables("corte").Rows(i)("ventaiva"))
                total6 = total6 + CDbl(dsc.Tables("corte").Rows(i)("ventasiva"))

            Next
            i = i + 1
            fp_cortes.ActiveSheet.Cells(i, 0).Value = "TOTALES DIA "
            fp_cortes.ActiveSheet.Cells(i, 1).Value = Format(total1, "###,##0.00") & " "
            fp_cortes.ActiveSheet.Cells(i, 3).Value = Format(total2, "###,##0.00") & " "
            fp_cortes.ActiveSheet.Cells(i, 4).Value = Format(total3, "###,##0.00") & " "
            fp_cortes.ActiveSheet.Cells(i, 5).Value = Format(total4, "###,##0.00") & " "
            fp_cortes.ActiveSheet.Cells(i, 7).Value = Format(total5, "###,##0.00") & " "
            fp_cortes.ActiveSheet.Cells(i, 8).Value = Format(total6, "###,##0.00") & " "

        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        foma.Show()
        Me.Dispose()
    End Sub
    Private Sub PINTA(ByVal renglon As Integer, ByVal color As Integer, ByVal tamaño As Integer)
        Dim acell As FarPoint.Win.Spread.Cell
        Dim I As Integer

        For I = 0 To fp_cortes.ActiveSheet.ColumnCount - 1
            acell = fp_cortes.ActiveSheet.Cells(renglon, I)
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

    Private Sub FP_CORTES_CellClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles fp_cortes.CellClick
        PINTA(fp_cortes.ActiveSheet.ActiveRowIndex, 2, 12)
        fp_cortes.ActiveSheet.ActiveRowIndex = e.Row
        PINTA(fp_cortes.ActiveSheet.ActiveRowIndex, 1, 12)

    End Sub

    Private Sub FP_CORTES_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles fp_cortes.LeaveCell
        PINTA(e.Row, 2, 12)
        fp_cortes.ActiveSheet.ActiveRowIndex = e.NewRow
        PINTA(fp_cortes.ActiveSheet.ActiveRowIndex, 1, 12)

    End Sub

    Private Sub TXT_FECHAINI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FECHAINI.Validated
        If Not IsDate(TXT_FECHAINI.Text) Then
            MsgBox("Fecha inválida,corregir", MsgBoxStyle.Exclamation)
            TXT_FECHAINI.Text = ""
        End If
    End Sub
    Private Sub TXT_FECHAFIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FECHAFIN.Validated
        If Not IsDate(TXT_FECHAFIN.Text) Then
            MsgBox("Fecha inválida,corregir", MsgBoxStyle.Exclamation)
            TXT_FECHAFIN.Text = ""
        End If
    End Sub

End Class
