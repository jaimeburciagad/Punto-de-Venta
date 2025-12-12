Imports System.Data.SqlClient
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.CellType
Imports FarPoint.Win.Spread.Model
Public Class Repsalidascaja
    Dim xcon As SqlConnection
    Dim limite As Integer
    Dim foma As Form
    Dim AutorizaRetiro As Boolean
    Dim renglones As New Collection
    Dim sDireccion() As String
    Dim xENTER As Char = Chr(13)
    Dim line As Char = Chr(10)
    Dim Corriendo As Boolean
    Public Sub New(ByRef con As SqlConnection, ByRef fom As FrAdmin)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xcon = con
        foma = fom
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
    End Sub

    Private Sub repsalidascaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FpDetalle.ActiveSheet.OperationMode = OperationMode.RowMode

        If Globales.Remoto Then
            If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
                Label45.BackColor = Color.Blue
                Label45.Text = "Duarsa 2"
                Me.Text = "D2 - " & "Reporte de Retiros de Efectivo"
            Else
                Label45.BackColor = Color.SlateBlue
                Label45.Text = "Duarsa 1"
                Me.Text = "D1 - " & "Reporte de Retiros de Efectivo"
            End If
        Else
            If Strings.Right(Globales.nomempresa, 1) * 1 = 1 Then
                Label45.BackColor = Color.SlateBlue
                Label45.Text = "Duarsa 1"
                Me.Text = "D1 - " & "Reporte de Retiros de Efectivo"
            Else
                Label45.BackColor = Color.Blue
                Label45.Text = "Duarsa 2"
                Me.Text = "D2 - " & "Reporte de Retiros de Efectivo"
            End If
        End If

        FechaIni.Value = Today
        FechaFin.Value = Today

        FechaFin.MaxDate = Today
        FechaIni.MaxDate = Today

        If Strings.Right(Globales.caja, 1) = "7" Then
            rb_todas.Checked = True
        Else
            txt_caja.Text = Strings.Right(Globales.caja, 1)
        End If

        panel_conf.Location = New Point(Me.Width / 2 - panel_conf.Width / 2, Me.Height / 2 - panel_conf.Height / 2)
        panel_conf.Visible = True
        FechaIni.Focus()
    End Sub


    Public Sub imprimeTicket(ByRef pre As Collection)
        Dim oImpresion As Impresion
        oImpresion = New Impresion(pre)
        oImpresion.imprime(False)
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ProcesoEliminar(FP_VENTAS.ActiveSheet.ActiveRowIndex)

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

    Private Sub FP_VENTAS_LeaveCell(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs) Handles FP_VENTAS.LeaveCell
        PINTA(e.Row, 2, 12)
        'FP_VENTAS.ActiveSheet.ActiveRowIndex = e.NewRow
        PINTA(e.NewRow, 1, 12)
    End Sub

    Private Sub btn_aplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplica.Click
        panel_conf.Location = New Point(Me.Width / 2 - panel_conf.Width / 2, Me.Height / 2 - panel_conf.Height / 2)
        panel_conf.Visible = True
    End Sub

    Private Sub txt_clave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_caja.TextChanged
        rb_una.Checked = True
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
            filtro = " and caja='00" & txt_caja.Text & "0'"
        End If

        If rb_canc.Checked Then
            filtro = "and ret_estatus=2"
        End If

        sql = "SELECT * FROM ECretiros  WHERE FECHA>='" & Format(FechaIni.Value, "yyyyMMdd") & "'" &
            " AND FECHA<='" & Format(DateAdd("d", 1, CDate(FechaFin.Value)), "yyyyMMdd") & "' " & filtro & " ORDER BY CVE_RETIROS "

        FP_VENTAS.ActiveSheet.RowCount = 0

        Base.daQuery(sql, xcon, dsc, "ventas")

        If dsc.Tables("ventas").Rows.Count > 0 Then
            FP_VENTAS.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTAS.ActiveSheet.Cells(i, 0).Value = dsc.Tables("ventas").Rows(i)("CAJA").ToString.Substring(2, 1)
                FP_VENTAS.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("CVE_RETIROS") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 2).Value = dsc.Tables("ventas").Rows(i)("FECHA") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 3).Value = dsc.Tables("ventas").Rows(i)("FECHA") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 3).Text = dsc.Tables("ventas").Rows(i)("DESCRIPCION")
                FP_VENTAS.ActiveSheet.Cells(i, 4).Text = dsc.Tables("ventas").Rows(i)("CUANTO") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 5).Text = IIf(dsc.Tables("ventas").Rows(i)("CORTE") = 1, "CERRADO", "")
                FP_VENTAS.ActiveSheet.Cells(i, 6).Value = IIf(CDbl(dsc.Tables("ventas").Rows(i)("RET_Estatus")) = 2, "Cancelado", "")
                FP_VENTAS.ActiveSheet.Cells(i, 7).Text = IIf(IsDBNull(dsc.Tables("ventas").Rows(i)("Motivo")), "", dsc.Tables("ventas").Rows(i)("Motivo")) & ""
                FP_VENTAS.ActiveSheet.Cells(i, 8).Text = dsc.Tables("ventas").Rows(i)("RET_fechacanc") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 9).Value = dsc.Tables("ventas").Rows(i)("RET_CANCusuario") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 10).Text = IIf(IsDBNull(dsc.Tables("ventas").Rows(i)("Ticket")), "", dsc.Tables("ventas").Rows(i)("Ticket")) & ""
            Next i
            FP_VENTAS.ActiveSheet.AddSelection(0, 0, 1, 1)
            FP_VENTAS.ActiveSheet.SetActiveCell(0, 0)
            PINTA(FP_VENTAS.ActiveSheet.ActiveRowIndex, 1)
            FP_VENTAS.Select()
        End If
        dsc.Tables.Remove("ventas")

    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        GENERAL.rutinaexportaraexcel(FP_VENTAS, "Salida de Caja")
    End Sub

    Private Sub regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regresar.Click
        Me.Hide()
        foma.Show()
        Me.Dispose()
    End Sub


    Public Sub XIMPRIME(ByVal i As Integer)
        'ENCABEZADO
        Dim oConv As New Conversion(CDbl(FP_VENTAS.ActiveSheet.Cells(i, 4).Value))
        Dim sql As String
        Dim dsc As New DataSet
        Dim j As Integer


        sql = "select * from ecretiros where cve_retiros=" & FP_VENTAS.ActiveSheet.Cells(i, 1).Value
        Base.daQuery(sql, xcon, dsc, "tabla")


        renglones.Add(Globales.grupo)
        renglones.Add(Globales.empresa)
        renglones.Add(Globales.rfc)
        renglones.Add(Globales.dir1)
        renglones.Add(Globales.dir2)
        renglones.Add(Globales.DIR3)
        renglones.Add("          ")
        renglones.Add("  ")
        renglones.Add("Fecha: " & CDate(dsc.Tables("tabla").Rows(0)("fecha")).ToShortDateString & " " & CDate(dsc.Tables("tabla").Rows(0)("fecha")).ToShortTimeString)
        renglones.Add("Caja:    #" & dsc.Tables("tabla").Rows(0)("caja").ToString.Substring(2, 1))
        renglones.Add("Cajero: " & Globales.sNombreEmpleado)
        If IsDBNull(dsc.Tables("tabla").Rows(0)("Ticket")) = False Then
            renglones.Add("Ticket Relacionado: " & dsc.Tables("tabla").Rows(0)("Ticket") & "")
        End If
        renglones.Add("  ")
        renglones.Add("------------------------------------")
        renglones.Add(xENTER)
        renglones.Add("Vale por la cantidad de:")
        renglones.Add(xENTER)
        renglones.Add("             " & Format(CDbl(dsc.Tables("tabla").Rows(0)("cuanto")), "$###,##0.00"))
        renglones.Add(xENTER)
        renglones.Add("SON: " & oConv.numeroEnLetras)
        renglones.Add(xENTER)
        renglones.Add("CONCEPTO:" & dsc.Tables("tabla").Rows(0)("descripcion").ToUpper)
        renglones.Add(xENTER)
        renglones.Add("___________________________________")
        If CDbl(dsc.Tables("tabla").Rows(0)("tipo")) = 1 Then
            renglones.Add(" Cant     Denominacion  Importe")
            renglones.Add("____________________________________")

        End If

        sql = "select * from ecdetretiros where dret_folio=" & dsc.Tables("tabla").Rows(0)("cve_retiros").ToString
        Base.daQuery(sql, xcon, dsc, "tabla1")

        For j = 0 To dsc.Tables("tabla1").Rows.Count - 1
            If CDbl(dsc.Tables("tabla1").Rows(j)("dret_cantidad")) > 0 Then
                renglones.Add(Space(2) & Format(CDbl(dsc.Tables("tabla1").Rows(j)("dret_cantidad")), "###0.00") & Space(2) &
                                  Format(CDbl(dsc.Tables("tabla1").Rows(j)("dret_billconv")), "##,##0.00") & Space(5) &
                                   Format(CDbl(dsc.Tables("tabla1").Rows(j)("dret_importe")), "##,##0.00"))
            End If

        Next
        renglones.Add("-------------------------------------")
        renglones.Add("TOTAL            " & Format(CDbl(dsc.Tables("tabla").Rows(0)("cuanto")), "###,##0.00"))
        renglones.Add("-------------------------------------")
        renglones.Add("          REIMPRESION")

        renglones.Add(xENTER)
        renglones.Add(xENTER)

        dsc.Tables.Remove("tabla")
        dsc.Tables.Remove("tabla1")

    End Sub

    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oImpresion As Impresion
        renglones.Clear()
        XIMPRIME(FP_VENTAS.ActiveSheet.ActiveRowIndex)
        oImpresion = New Impresion(renglones)
        oImpresion.imprime(False)
        MsgBox("Proceso Realizado Correctamente", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub TXT_PASSWORD_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_PASSWORD.KeyDown
        Dim SQL As String
        Dim DSC As New DataSet

        If e.KeyCode = Keys.Enter Then
            If TXT_PASSWORD.Text <> "" Then
                SQL = "select * from ecusuariosx where emp_password='" & TXT_PASSWORD.Text & "' and emp_tipo='SUP'"
                Base.daQuery(SQL, xcon, DSC, "aut")
                If DSC.Tables("aut").Rows.Count > 0 Then
                    AutorizaRetiro = True
                    Button1.PerformClick()
                Else
                    MsgBox("Password incorrecto.", vbExclamation, "Autoriza")
                    AutorizaRetiro = False
                    TXT_PASSWORD.Text = ""
                    TXT_PASSWORD.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Panel1.Visible = False
            AutorizaRetiro = False
            TXT_PASSWORD.Text = ""
        End If
    End Sub

    Private Sub EliminaRetiro(ByVal Ticket As Integer, ByVal TicketRel As Integer)
        Dim SQL As String

        SQL = "update ecretiros set corte=2,ret_estatus=2,ret_fechacanc=getdate(),ret_cancusuario='" & Globales.nombreusuario & "'   where cve_retiros=" & Ticket
        Base.Ejecuta(SQL, xcon)
        'MsgBox("Proceso realizado correctamente", vbExclamation)

        If TicketRel <> -1 Then
            Dim DSC As New DataSet
            SQL = "select*from ECCANCXUPC where n_ticket=" & TicketRel & " and MovimientoRel=" & Ticket & " order by cve_cancelacion desc"
            Base.daQuery(SQL, xcon, DSC, "Dev")
            If DSC.Tables("Dev").Rows.Count > 0 Then
                Dim Cantidad As Double
                Dim CostoUnitario As Double
                Dim Articulo As String
                Dim UPC As String
                Dim XFecha As String
                For i As Integer = 0 To DSC.Tables("Dev").Rows.Count - 1
                    Cantidad = DSC.Tables("Dev").Rows(i)("Cantidad")
                    CostoUnitario = DSC.Tables("Dev").Rows(i)("PrecioUnit")
                    Articulo = DSC.Tables("Dev").Rows(i)("id_articulo")
                    UPC = DSC.Tables("Dev").Rows(i)("upc_upc")
                    XFecha = DSC.Tables("Dev").Rows(i)("fecha")

                    Base.Ejecuta("EXEC APLICAMOVTOSFECHA 3,'" & XFecha & "','" & UPC & "','" & Articulo & "'," & Cantidad * -1 & "," & Cantidad * -1 * CostoUnitario, xcon)
                    Base.Ejecuta("EXEC APLICAMOVTOSFECHACORTE 3,'" & XFecha & "','" & UPC & "','" & Articulo & "'," & Cantidad * -1 & "," & Cantidad * -1 * CostoUnitario, xcon)
                    Base.Ejecuta("EXEC APLICAMOVTOSMES 3,'" & XFecha & "','" & UPC & "','" & Articulo & "'," & Cantidad * -1 & "," & Cantidad * -1 * CostoUnitario, xcon)
                    Base.Ejecuta("EXEC APLICAMOVTOSSEMANA 3,'" & XFecha & "','" & UPC & "','" & Articulo & "'," & Cantidad * -1 & "," & Cantidad * -1 * CostoUnitario, xcon)
                    SQL = "delete from ECCANCXUPC where n_ticket=" & TicketRel & " and MovimientoRel=" & Ticket & ""
                    Base.Ejecuta(SQL, xcon)
                Next i
            End If
            DSC.Tables.Remove("Dev")
        End If


        Base.Ejecuta("exec creamovtodinerocanc " & Ticket & ",1", xcon)
        MsgBox("Proceso realizado correctamente", vbExclamation)
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

    Private Sub Fp_Ventas_CellClick(sender As Object, e As CellClickEventArgs) Handles FP_VENTAS.CellClick

        AutorizaRetiro = False

        TXT_PASSWORD.Text = ""
        PINTA(FP_VENTAS.ActiveSheet.ActiveRowIndex, 2)
        'FP_VENTAS.ActiveSheet.ActiveRowIndex = e.Row
        PINTA(e.Row, 1)
    End Sub

    Private Sub PINTA(ByVal renglon As Integer, ByVal color As Integer, Optional ByVal NewRenglon As Integer = -1, Optional ByVal color2 As Integer = -1)
        Dim acell As FarPoint.Win.Spread.Cell
        acell = FP_VENTAS.ActiveSheet.Cells(renglon, 0, renglon, FP_VENTAS.ActiveSheet.ColumnCount - 1)

        Select Case color
            Case 1
                acell.BackColor = System.Drawing.Color.LightBlue
            Case 2
                acell.BackColor = System.Drawing.Color.White
        End Select
        'Next I
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

    Private Sub FP_VENTAS_SelectionChanged(sender As Object, e As FarPoint.Win.Spread.SelectionChangedEventArgs) Handles FP_VENTAS.SelectionChanged, FpDetalle.SelectionChanged
        Selecciona(sender)
    End Sub

    Private Sub FP_VENTAS_GotFocus(sender As Object, e As EventArgs) Handles FP_VENTAS.GotFocus, btn_aplica.GotFocus, generar.GotFocus, Button1.GotFocus, Button2.GotFocus, btn_exportar.GotFocus, regresar.GotFocus, Me.GotFocus
        paneldetalle.Visible = False
        panel_conf.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub FP_VENTAS_CellDoubleClick(sender As Object, e As CellClickEventArgs) Handles FP_VENTAS.CellDoubleClick
        e.Cancel = True
        MuestraDetalle(e.Row)
    End Sub

    Private Sub MuestraDetalle(ByVal Row As Integer)
        Dim SQL As String
        Dim DSC As New DataSet
        AutorizaRetiro = False
        SQL = "select * from ecdetretiros join ecretiros on dret_folio=cve_retiros join billetes on BILL_CLAVE=DRET_BILLCLAVE where dret_folio=" & CDbl(FP_VENTAS.ActiveSheet.Cells(Row, 1).Text.Trim)
        Base.daQuery(SQL, xcon, DSC, "DetRetiro")
        FpDetalle.ActiveSheet.RowCount = 0
        If DSC.Tables("DetRetiro").Rows.Count > 0 Then
            FpDetalle.ActiveSheet.RowCount = DSC.Tables("DetRetiro").Rows.Count
            lbDetalleRetiro.Text = "Fecha: " & DSC.Tables("DetRetiro").Rows(0)("dret_fecha") & " | Caja: " & CInt(DSC.Tables("DetRetiro").Rows(0)("dret_caja")) & " | Folio: " & DSC.Tables("DetRetiro").Rows(0)("dret_folio")
            lbTotalRetiro.Text = "Total: " & FormatCurrency(DSC.Tables("DetRetiro").Rows(0)("cuanto"), 2)
            For i As Integer = 0 To DSC.Tables("DetRetiro").Rows.Count - 1
                FpDetalle.ActiveSheet.Cells(i, 0).Text = FormatNumber(DSC.Tables("DetRetiro").Rows(i)("dret_cantidad"), 2)
                FpDetalle.ActiveSheet.Cells(i, 1).Text = DSC.Tables("DetRetiro").Rows(i)("bill_desc")
                FpDetalle.ActiveSheet.Cells(i, 2).Text = FormatCurrency(DSC.Tables("DetRetiro").Rows(i)("dret_importe"), 2)
            Next
            Dim r As Rectangle
            r = FP_VENTAS.GetCellRectangle(0, 0, FP_VENTAS.ActiveSheet.ActiveRowIndex + 1, 5)
            paneldetalle.Top = r.Y + FP_VENTAS.Location.Y + IIf((r.Y + FP_VENTAS.Location.Y + paneldetalle.Size.Height) > FP_VENTAS.Location.Y + FP_VENTAS.Size.Height, IIf((r.Y + FP_VENTAS.Location.Y) > paneldetalle.Size.Height, -paneldetalle.Size.Height, -r.Y - FP_VENTAS.Location.Y + (Me.Height / 2 - paneldetalle.Height / 2)), 0)
            paneldetalle.Left = (Me.Width / 2 - paneldetalle.Width / 2)


            paneldetalle.Visible = True
            FpDetalle.ActiveSheet.SetActiveCell(0, 0)
            FpDetalle.Select()
        End If
        DSC.Tables.Remove("DetRetiro")
    End Sub

    Private Sub txt_caja_GotFocus(sender As Object, e As EventArgs) Handles txt_caja.GotFocus
        rb_una.Checked = True
        rb_todas.Checked = False
    End Sub

    Private Sub FP_VENTAS_KeyDown(sender As Object, e As KeyEventArgs) Handles FP_VENTAS.KeyDown
        If e.KeyCode = Keys.F6 Then
            MuestraDetalle(FP_VENTAS.ActiveSheet.ActiveRowIndex)
        End If
    End Sub

    Private Sub ProcesoEliminar(ByVal Row As Integer)

        Dim OPCION As Integer
        Dim TICKET As String
        Dim importe As String
        Dim dsc As New DataSet

        Dim sql As String
        Dim fecha1 As Date
        Dim fecha2 As Date

        If FP_VENTAS.ActiveSheet.Cells(Row, 6).Value = "Cancelado" Then
            MsgBox("El movimiento ya se encuentra cancelado.", MsgBoxStyle.Exclamation, "Reporte de Retiro de Efectivo")
            Exit Sub
        End If

        fecha1 = Today
        fecha2 = CDate(FP_VENTAS.ActiveSheet.Cells(Row, 2).Value).ToShortDateString
        If fecha1 <> fecha2 Then
            '  If Now.ToShortDateString <> CDate(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 3).Value) Then
            MsgBox("No se pueden cancelar retiros de otras fecha, sólo del día.", MsgBoxStyle.Exclamation)

        Else
            TICKET = FP_VENTAS.ActiveSheet.Cells(Row, 1).Value
            importe = FP_VENTAS.ActiveSheet.Cells(Row, 4).Value
            If Panel1.Visible = False Then
                OPCION = MsgBox("El Folio de Salida de caja " & TICKET & " por un importe de $" & importe & " será cancelado, desea cancelar el retiro de caja ?", MsgBoxStyle.OkCancel)
            Else
                OPCION = 1
            End If



            If OPCION = 1 Then
                sql = "select * from ecretiros where cve_retiros=" & TICKET
                Base.daQuery(sql, xcon, dsc, "salidas")
                If dsc.Tables("salidas").Rows.Count > 0 Then
                    If dsc.Tables("salidas").Rows(0)("corte") = 1 Then
                        MsgBox("No se puede cancelar porque ya se realizó el corte de caja de este documento")
                    Else
                        If Panel1.Visible And AutorizaRetiro Then
                            'Ingresar motivo
                            EliminaRetiro(TICKET, IIf(FP_VENTAS.ActiveSheet.Cells(Row, 10).Text = "", -1, FP_VENTAS.ActiveSheet.Cells(Row, 10).Value))
                        Else
                            Corriendo = True
                            AutorizaRetiro = False
                            Panel1.Location = New Point(Me.Width / 2 - Panel1.Width, Me.Height / 2 - Panel1.Height)
                            Panel1.Visible = True
                            TXT_PASSWORD.Text = ""
                            TXT_PASSWORD.Focus()
                            Corriendo = False
                            Exit Sub
                        End If
                    End If
                    dsc.Tables.Remove("Salidas")
                End If

                rellenaventas()
            Else
                MsgBox("Proceso Cancelado", MsgBoxStyle.Information)
            End If
        End If
    End Sub
    Private Sub FP_VENTAS_KeyUp(sender As Object, e As KeyEventArgs) Handles FP_VENTAS.KeyUp
        If e.KeyCode = Keys.Delete Then
            ProcesoEliminar(FP_VENTAS.ActiveSheet.ActiveRowIndex)
        End If
    End Sub

    Private Sub FpDetalle_DialogKey(sender As Object, e As DialogKeyEventArgs) Handles FpDetalle.DialogKey
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F6 Then
            paneldetalle.Visible = False
            FP_VENTAS.Select()
        End If
    End Sub
End Class