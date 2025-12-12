Imports System.Data.SqlClient
Imports FarPoint.Win.Spread

Public Class Devoluciones
    Public xCon As SqlConnection
    Dim autorization As Boolean
    Dim VengoDe As String
    Dim FilaMatch, FilaSig As Integer
    Dim totalote As Double
    Dim AutorizaRetiro As Boolean
    Dim Corriendo As Boolean
    Dim Encontrado As FarPoint.Win.Spread.SearchFoundFlags
    Dim foma As Form
    Public Sub New(ByRef con As SqlConnection)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        Corriendo = True
        InitializeComponent()
        xCon = con
        'foma = fom
        Corriendo = False
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Public Sub imprimeTicket(ByRef pre As Collection)
    '    Dim oImpresion As Impresion
    '    oImpresion = New Impresion(pre)
    '    oImpresion.imprime()
    'End Sub
    Public Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegresar.Click
        Me.Close()
    End Sub

    Private Sub Devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Globales.caja = "vscaja7" Then
            CmbCaja.Visible = True
            LbCaja.Visible = True
        Else
            CmbCaja.Visible = False
            LbCaja.Visible = False
        End If

        TxtMotivo.Text = ""
        TxtNumTicket.Focus()
        autorization = False
        VengoDe = ""

        If Globales.Remoto Then
            If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
                Label45.BackColor = Color.Blue
                Label45.Text = "Duarsa 2"
                Me.Text = "D2 - " & "Devolución de Mercancía"
            Else
                Label45.BackColor = Color.SlateBlue
                Label45.Text = "Duarsa 1"
                Me.Text = "D1 - " & "Devolución de Mercancía"
            End If
        Else
            If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
                Label45.BackColor = Color.SlateBlue
                Label45.Text = "Duarsa 1"
                Me.Text = "D1 - " & "Devolución de Mercancía"
            Else
                Label45.BackColor = Color.Blue
                Label45.Text = "Duarsa 2"
                Me.Text = "D2 - " & "Devolución de Mercancía"
            End If
        End If

        RellenaCmbBuscar()

        TxtNumTicket.Focus()
    End Sub
    Private Sub RellenaCmbBuscar(Optional ByVal InicializandoVista As Boolean = True)
        CmbColumnasBuscar.Items.Clear()
        CmbBuscaIndex.Items.Clear()

        Dim Titulo As String = ""
        Dim Subtitulo As String = ""
        Dim IndCol, SubIndCol As Integer
        Dim TitColSpan As Integer = 0
        Dim SubTitColSpan As Integer = 0
        For c As Integer = 0 To FpSpread1.ActiveSheet.Columns.Count - 1
            If FpSpread1.ActiveSheet.Columns(c).Visible Then
                If FpSpread1.ActiveSheet.ColumnHeader.RowCount > 1 Then
                    If FpSpread1.ActiveSheet.ColumnHeader.Cells(0, c).ColumnSpan > 1 Then
                        Titulo = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, c).Text
                        IndCol = c
                        TitColSpan = c + FpSpread1.ActiveSheet.ColumnHeader.Cells(0, c).ColumnSpan - 1
                    Else
                        If c > TitColSpan Then
                            Titulo = ""
                        End If
                    End If

                    If FpSpread1.ActiveSheet.ColumnHeader.RowCount = FpSpread1.ActiveSheet.ColumnHeader.Cells(0, c).RowSpan Then
                        CmbColumnasBuscar.Items.Add(FpSpread1.ActiveSheet.ColumnHeader.Cells(0, c).Text)
                        CmbBuscaIndex.Items.Add(c)
                    Else
                        Dim HeadCol As String = ""
                        For FC As Integer = 0 To FpSpread1.ActiveSheet.ColumnHeader.RowCount - 1
                            If FC > 0 Then
                                If FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).ColumnSpan > 1 Then
                                    Subtitulo = FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).Text
                                    SubIndCol = c
                                    SubTitColSpan = c + FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).ColumnSpan - 1
                                End If
                            End If
                            HeadCol = (IIf(Titulo <> FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).Text And (c > IndCol And c <= TitColSpan) And HeadCol = "", Titulo & " - ", "") & IIf(Subtitulo <> FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).Text And (c > SubIndCol And c <= SubTitColSpan) And HeadCol = "", Subtitulo & " - ", "") & IIf(HeadCol = "", FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).Text, HeadCol & " - " & FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).Text)).ToString.Replace(" -  - ", " - ")

                            If FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).RowSpan > 1 Then
                                FC += FpSpread1.ActiveSheet.ColumnHeader.Cells(FC, c).RowSpan - 1
                            End If
                        Next
                        If HeadCol.Replace(" - ", "").Trim = (Titulo & " - " & IIf(Subtitulo <> "", Subtitulo & " - ", "")).Replace(" - ", "").trim Then
                            HeadCol = ""
                        End If
                        CmbColumnasBuscar.Items.Add(HeadCol)
                        CmbBuscaIndex.Items.Add(c)
                    End If
                Else 'Headers es una sola fila
                    CmbColumnasBuscar.Items.Add(FpSpread1.ActiveSheet.ColumnHeader.Cells(0, c).Text)
                    CmbBuscaIndex.Items.Add(c)
                End If
            End If

        Next

        CmbColumnasBuscar.SelectedIndex = CmbBuscaIndex.Items.IndexOf(CInt(2))
    End Sub
    Private Sub RellenaTicket(ByVal Ticket As Integer)
        Dim dsc As New DataSet
        Dim sql As String
        Dim i As Integer

        FpSpread1.ActiveSheet.RowCount = 0

        sql = "select*from ecventa where ven_id='" & TxtNumTicket.Text.Trim & "'"
        Base.daQuery(sql, xCon, dsc, "art")
        autorization = False
        If dsc.Tables("Art").Rows.Count > 0 Then
            If (DateAndTime.DateDiff(DateInterval.Minute, CDate(dsc.Tables("art").Rows(0)("ven_fecha")), Now) > 15 And Not AutorizaRetiro) Then
                MsgBox("El ticket excede el tiempo definido, no pueden hacerse la devolución. Se requiere de autorización especial.", vbExclamation, "Devolución de Mercancía")
                BtnGuardar.Enabled = False
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
                autorization = False
            End If
        Else
            MsgBox("No existe Ticket.", vbExclamation, "Devolución de Mercancía")
            dsc.Tables.Remove("Art")
            Exit Sub
        End If
        dsc.Tables.Remove("Art")

        BtnGuardar.Enabled = True

        sql = "select dve_renglon, dve_articulo,dve_upc, descripcion,cant, dve_precio,ISNULL(X.cantDEV,0) as cantdev, " &
       "case when exists (select dve_venta from ecventadete h where h.dve_venta=a.ven_id and h.DVE_UPC=a.DVE_UPC) then '1' else '0' end as vale " &
       "from (select ven_id ,a.dve_renglon, a.dve_articulo,a.dve_upc,upc_descripcion as descripcion,sum(a.dve_cantidad) cant , a.dve_precio from ecventadet " &
       "a inner join ecventa on ecventa.ven_id=a.dve_venta inner join xupc on upc_upc=a.dve_upc " &
       "where ven_id=" & TxtNumTicket.Text & " And ven_status=1 group by ven_id,dve_renglon, a.dve_articulo,a.dve_upc,a.dve_precio,upc_descripcion) a left join " &
       "(SELECT ID_ARTICULO,upc_upc,SUM(CANTIDAD)AS CANTDEV FROM eccancxupc WHERE N_TICKET=" & TxtNumTicket.Text & " GROUP BY ID_ARTICULO,upc_upc ) X on x.id_articulo=a.dve_articulo " &
       "and X.upc_upc=a.DVE_upc order by DVE_RENGLON asc"

        Base.daQuery(sql, xCon, dsc, "art")

        FpSpread1.ActiveSheet.RowCount = dsc.Tables("art").Rows.Count
        FpSpread1.ActiveSheet.Columns(5).Visible = True

        For i = 0 To dsc.Tables("art").Rows.Count - 1
            FpSpread1.ActiveSheet.Cells(i, 0).Value = CDbl(dsc.Tables("art").Rows(i)("cant")) - CDbl(dsc.Tables("art").Rows(i)("cantdev"))
            FpSpread1.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ART").Rows(i)("dve_upc")
            FpSpread1.ActiveSheet.Cells(i, 2).Value = dsc.Tables("art").Rows(i)("descripcion")
            FpSpread1.ActiveSheet.Cells(i, 3).Value = CDbl(dsc.Tables("art").Rows(i)("dve_precio"))

            FpSpread1.ActiveSheet.Cells(i, 6).Value = dsc.Tables("ART").Rows(i)("DVE_ARTICULO")
            FpSpread1.ActiveSheet.Cells(i, 7).Value = dsc.Tables("ART").Rows(i)("vale")
        Next

        FpSpread1.ActiveSheet.ActiveRowIndex = 0
        FpSpread1.ActiveSheet.ActiveColumnIndex = 3
        PINTA(FpSpread1.ActiveSheet.ActiveRowIndex, 1, FpSpread1)
        TxtMotivo.Enabled = True
        FpSpread1.Focus()
    End Sub

    Private Sub fp_Devolucion_Change(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs) Handles FpSpread1.Change
        Dim i As Integer
        On Error Resume Next
        If FpSpread1.ActiveSheet.Cells(e.Row, 0).Value < FpSpread1.ActiveSheet.Cells(e.Row, 4).Value Then
            MsgBox("No puede devolver más cantidad que la comprada en este ticket.", vbExclamation, "Devolución de Mercancía")
            FpSpread1.ActiveSheet.Cells(e.Row, 4).Value = 0
            FpSpread1.ActiveSheet.SetActiveCell(e.Row, 4)
            FpSpread1.Focus()
        ElseIf FpSpread1.ActiveSheet.Cells(e.Row, 4).Value < 0 Then
            MsgBox("La cantidad a devolver no puede ser negativa.", vbExclamation, "Devolución de Mercancía")
            FpSpread1.ActiveSheet.Cells(e.Row, 4).Value = 0
            FpSpread1.ActiveSheet.SetActiveCell(e.Row, 4)
            FpSpread1.Focus()
        Else
            totalote = 0
            For i = 0 To FpSpread1.ActiveSheet.RowCount - 1
                totalote = totalote + FpSpread1.ActiveSheet.Cells(i, 4).Value * FpSpread1.ActiveSheet.Cells(i, 3).Value
                FpSpread1.ActiveSheet.Cells(i, 5).Value = FpSpread1.ActiveSheet.Cells(i, 4).Value * FpSpread1.ActiveSheet.Cells(i, 3).Value
            Next
            TxtTotal.Text = Format(totalote, "$###,##0.00")
            FpSpread1.Focus()
        End If
    End Sub

    Private Sub fp_Devolucion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpSpread1.KeyUp
        FpSpread1.ActiveSheet.ActiveColumnIndex = 4
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If TxtMotivo.Text.Trim <> "" Then
            If CmbCaja.Visible Then
                If CmbCaja.SelectedIndex > -1 Then
                    If Not IsNumeric(CmbCaja.SelectedItem) Then
                        MsgBox("Número de caja debe ser numérico.", vbExclamation, "Devolución de Mercancía")
                        Exit Sub
                    End If
                Else
                    MsgBox("No ha indicado de qué caja se hará la devolución.", vbExclamation, "Devolución de Mercancía")
                    Exit Sub
                End If
            End If
        Else
            MsgBox("Especifique la razón de la devolución.", vbInformation, "Devolución de Mercancía")
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
                Dim foma As Form
                foma = New frautorizado(Me)
                foma.BringToFront()
                foma.ShowDialog()
            Else
                MsgBox("Existen artículos ligados a un vale de entrega de mercancía. Se requiere de autorización especial.", vbExclamation, "Devolución de Mercancía")

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
            MsgBox("No ha indicado qué artículos serán devueltos.", vbExclamation, "Devolución de Mercancía")
        End If
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
            sender.ActiveSheet.ActiveColumnIndex = 4
            sender.ActiveSheet.ActiverowIndex = e.Row
            e.Cancel = True
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
            Dim i As Integer

            For i = 1 To Len(LTrim(RTrim(TXT_PASSWORD.Text)))
                If IsNumeric(Mid(TXT_PASSWORD.Text, i, 1)) Then
                    Exit For
                End If
            Next
            TXT_PASSWORD.Text = Mid(TXT_PASSWORD.Text, i, Len(TXT_PASSWORD.Text) - i + 1)

            If TXT_PASSWORD.Text <> "" Then

                SQL = "select * from ecusuariosx where emp_password='" & TXT_PASSWORD.Text & "' and emp_tipo='SUP'"
                Base.daQuery(SQL, xCon, DSC, "Empleado")
                If DSC.Tables("Empleado").Rows.Count > 0 Then
                    AutorizaRetiro = True
                    If VengoDe = "Rellena" Then
                        RegistroHistorial.HistorialAutorizaciones(xCon, My.Computer.Name, DSC.Tables("Empleado").Rows(0)("emp_nombre"), TxtNumTicket.Text.Trim, "Devolución", "Devolución de Mercancía")
                        RellenaTicket(TxtNumTicket.Text.Trim)
                    ElseIf VengoDe = "Aceptar" Then
                        RegistroHistorial.HistorialAutorizaciones(xCon, My.Computer.Name, DSC.Tables("Empleado").Rows(0)("emp_nombre"), TxtNumTicket.Text.Trim, "Devolución", "Devolución de Mercancía")
                        Me.btn_aceptar_Click(sender, e)
                    End If
                Else
                    MsgBox("Password incorrecto.", vbExclamation, "Autoriza")
                    AutorizaRetiro = False
                    TXT_PASSWORD.Text = ""
                    TXT_PASSWORD.Focus()
                    TxtNumTicket.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Panel1.Visible = False
            AutorizaRetiro = False
            TXT_PASSWORD.Text = ""
            TxtNumTicket.Focus()
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

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbColumnasBuscar.KeyDown, TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            Buscar(CmbBuscaIndex.SelectedItem)
        ElseIf e.KeyCode = Keys.Escape Then
            FpSpread1.Focus()
        End If
    End Sub

    Private Sub Buscar(ByVal ColumnaBusq As Integer)
        Static UltRowMatch As Integer = -1
        Static UltStrBusc As String = TxtBuscar.Text
        Static Looped As Boolean = False
        If (FilaSig = 0 And FpSpread1.ActiveSheet.ActiveRowIndex > 0 And Not Looped) OrElse UltStrBusc <> TxtBuscar.Text Then
            FilaSig = FpSpread1.ActiveSheet.ActiveRowIndex
        End If
Repite:
        Dim Fila, Columna As Integer
        Encontrado = FarPoint.Win.Spread.SearchFoundFlags.Error

        If ColumnaBusq < 0 Then
            MsgBox("Debe seleccionar del listado la columna a buscar.", vbExclamation, "Buscar Texto")
            CmbColumnasBuscar.Focus()
            Exit Sub
        End If

        Encontrado = FpSpread1.Search(FpSpread1.ActiveSheetIndex, FpSpread1.ActiveSheetIndex, TxtBuscar.Text, False, False, True, True, True, False, False, FilaSig, ColumnaBusq, FpSpread1.ActiveSheet.RowCount - 1, ColumnaBusq, FpSpread1.ActiveSheetIndex, Fila, Columna)
        If Encontrado = FarPoint.Win.Spread.SearchFoundFlags.CellText And UltRowMatch <> Fila Then
            FilaMatch = Fila
            UltRowMatch = Fila
            UltStrBusc = TxtBuscar.Text
            If FpSpread1.ActiveSheet.Rows.Count - 1 >= Fila + 1 Then
                FilaSig = Fila + 1
            Else
                FilaSig = 0
            End If

            PINTA(FpSpread1.ActiveSheet.ActiveRowIndex, 2, FpSpread1)
            FpSpread1.ActiveSheet.ActiveRowIndex = Fila
            PINTA(Fila, 1, FpSpread1)
            FpSpread1.ActiveSheet.SetActiveCell(Fila, Columna)
            FpSpread1.ActiveSheet.AddSelection(Fila, ColumnaBusq, 1, 1)
            FpSpread1.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center)

            TxtBuscar.Focus()
        Else
            If Encontrado = FarPoint.Win.Spread.SearchFoundFlags.CellText And Fila = UltRowMatch Then
                MsgBox("No se encontraron coincidencias adicionales.", vbExclamation, "Buscar")
                UltRowMatch = -1
                FilaSig = 0

                PINTA(FpSpread1.ActiveSheet.ActiveRowIndex, 2, FpSpread1)
                FpSpread1.ActiveSheet.ActiveRowIndex = 0
                PINTA(0, 1, FpSpread1)
                FpSpread1.ActiveSheet.SetActiveCell(0, ColumnaBusq)
                FpSpread1.ActiveSheet.AddSelection(0, ColumnaBusq, 1, 1)
                FpSpread1.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center)
            ElseIf FilaMatch = 0 And (Encontrado <> FarPoint.Win.Spread.SearchFoundFlags.CellText) Then
                If Looped Then
                    MsgBox("No se encontraron coincidencias.", vbExclamation, "Buscar")
                    FilaMatch = 0
                    FilaSig = 0
                    UltRowMatch = -1
                    Looped = False
                Else
                    Looped = True
                    FilaMatch = 0
                    FilaSig = 0
                    GoTo Repite
                End If

                'aqui debo poner algo para el loop
                'debo resetear variables al cambiar de consulta, y demás escnearioas
            Else
                If Looped And UltRowMatch <> -1 Then
                    MsgBox("No se encontraron coincidencias adicionales.", vbExclamation, "Buscar")
                    FilaMatch = 0
                    FilaSig = 0
                    UltRowMatch = -1
                    Looped = False
                Else
                    Looped = True
                    FilaMatch = 0
                    FilaSig = 0
                    GoTo Repite
                End If
            End If
        End If
    End Sub
    Private Sub CmbColumnasBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbColumnasBuscar.SelectedIndexChanged
        CmbBuscaIndex.SelectedIndex = CmbColumnasBuscar.SelectedIndex
        If CmbColumnasBuscar.SelectedIndex >= 0 Then
            TxtBuscar.Focus()
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

    Private Sub TxtNumTicket_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNumTicket.KeyDown
        If e.KeyCode = Keys.Enter And TxtNumTicket.Text <> "" Then
            If IsNumeric(TxtNumTicket.Text) Then
                RellenaTicket(TxtNumTicket.Text.Trim)
            Else
                MsgBox("El folio del ticket debe ser numérico.", MsgBoxStyle.Exclamation, "Devolución de Mercancía")
                TxtNumTicket.Text = ""
                TxtNumTicket.Focus()
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not Corriendo Then
            Corriendo = True
            If Not CheckBox1.Checked Then
                If MsgBox("No se entregará dinero, la devolución sólo se hará para efectos de inventario, ¿correcto?", vbYesNo, "Devolución de Mercancía") = MsgBoxResult.No Then
                    CheckBox1.Checked = True
                End If
            End If
            Corriendo = False
        End If
    End Sub

    Private Sub TxtBuscar_GotFocus(sender As Object, e As EventArgs) Handles TxtBuscar.GotFocus
        TxtBuscar.SelectAll()
    End Sub

    Private Sub FpSpread1_KeyDown(sender As Object, e As KeyEventArgs) Handles FpSpread1.KeyDown
        If (e.KeyCode = Keys.F OrElse e.KeyCode = Keys.B) AndAlso e.Control Then
            TxtBuscar.Focus()
            TxtBuscar.SelectAll()
        End If
    End Sub
End Class