Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports Scripting
Imports FirebirdSql.Data.FirebirdClient

Imports FarPoint.Win.Spread.CellType
Imports FarPoint.Win.Spread

Public Class parafacturar
    Inherits System.Windows.Forms.Form
    Dim xcon As SqlConnection
    Dim foma As Form
    Dim actividad As Integer
    Dim xsubtotal As Double
    Dim xiva As Double
    Dim xtotal As Double
    Dim xdescuento As Double
    Dim XIMPORTE As Double
    Dim foliocompra As Integer
    Dim Corriendo As Boolean
    Dim TarjetaSeleccionada As Boolean
    Public conmicrosip As FbConnection

    Public Sub New(ByRef con As SqlConnection, ByRef fom As Form)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xcon = con
        foma = fom
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Corriendo = False
        TarjetaSeleccionada = False
    End Sub

    Private Sub ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actividad = 0
        rellenaPROVEEDORES()
        TxtFiltro.Focus()
    End Sub



    Private Function dafecha(ByVal TODAY As Date, ByVal tipo As Integer) As String
        If tipo = 1 Then
            TODAY = DateAdd(DateInterval.Day, -1, TODAY)
        Else
            TODAY = DateAdd(DateInterval.Day, +1, TODAY)
        End If
        dafecha = CStr(Year(TODAY)) & IIf(Month(TODAY) < 10, "0" & CStr(Month(TODAY)), CStr(Month(TODAY))) &
        IIf(TODAY.Day < 10, "0" & CStr(TODAY.Day), CStr(TODAY.Day))
    End Function

    Private Sub rellenaPROVEEDORES()
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer

        sql = "select cliente_id,nombre from clientes where upper(nombre) like'%" + UCase(Replace(TxtFiltro.Text.ToString, "'", "''")) + "%' order by nombre"
        Try
            Base.daQueryMICROSIP(sql, conmicrosip, dsc, "PROVEEDORES", Globales.basemicrosip)
            CmbCliente.Items.Clear()
            If dsc.Tables("PROVEEDORES").Rows.Count > 0 Then
                For i = 0 To dsc.Tables("PROVEEDORES").Rows.Count - 1
                    CmbCliente.Items.Add(((dsc.Tables("PROVEEDORES").Rows(i)(0)).ToString & "       ").Substring(0, 7) & dsc.Tables("PROVEEDORES").Rows(i)(1))
                Next
                CmbCliente.SelectedIndex = 0
            End If
            dsc.Tables.Remove("PROVEEDORES")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Private Sub FpTickets_KeyDown(sender As Object, e As KeyEventArgs) Handles FpTickets.KeyDown


        If e.KeyCode = Keys.Enter Then
            AgregaTicket()
        End If
    End Sub

    Private Sub AgregaTicket()
        Dim DSC As New DataSet
        Dim SQL As String
        Dim IVA As Double = 0
        Dim IEPS As Double = 0
        Dim Gravado16 As Double = 0
        Dim Gravado8 As Double = 0
        Dim Gravado0 As Double = 0
        Dim Total As Double = 0
        Corriendo = True
        If FpTickets.ActiveSheet.ActiveColumnIndex = 0 Then
            If FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text <> "" Then
                If IsNumeric(FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text) Then
                    SQL = "select ven_id, ven_total, sum(dve_iva) IVA, sum(dve_ieps) IEPS from ECVenta inner join ECVentaDet on Dve_Venta=ven_id where ven_id=" & FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text & " group by ven_id, ven_total"
                    Base.daQuery(SQL, xcon, DSC, "tabla")
                    If DSC.Tables("TABLA").Rows.Count > 0 Then
                        IVA = CDbl(DSC.Tables("TABLA").Rows(0)("IVA"))
                        Gravado16 = IVA / 0.16

                        IEPS = CDbl(DSC.Tables("TABLA").Rows(0)("IEPS"))
                        Gravado8 = IEPS / 0.08

                        Gravado0 = CDbl(DSC.Tables("TABLA").Rows(0)("VEN_TOTAL")) - IVA - Gravado16 - IEPS - Gravado8

                        Total = CDbl(DSC.Tables("TABLA").Rows(0)("VEN_TOTAL"))
                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 1).Value = FormatCurrency(Gravado0, 2)
                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 2).Value = FormatCurrency(Gravado8, 2)
                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 3).Value = FormatCurrency(Gravado16, 2)
                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 4).Value = FormatCurrency(IEPS, 2)
                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 5).Value = FormatCurrency(IVA, 2)
                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 6).Value = FormatCurrency(Total, 2)

                        SQL = "select tipo_pago, SUM(pago) Pago from ecformapago where referencia=" & FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text & " group by tipo_pago"
                        Base.daQuery(SQL, xcon, DSC, "Montos")
                        If DSC.Tables("Montos").Rows.Count > 0 Then
                            Dim Efectivo As Double = 0
                            Dim Otros As Double = 0
                            Dim Cheque As Double = 0
                            Dim Transferencia As Double = 0
                            Dim Tarjeta As Double = 0
                            Dim Vales As Double = 0
                            Dim ClaveFiscal As String = ""

                            For i As Integer = 0 To DSC.Tables("Montos").Rows.Count - 1
                                If DSC.Tables("Montos").Rows(i)("tipo_pago").ToString.ToUpper = "EFECTIVO" Then
                                    Efectivo += DSC.Tables("Montos").Rows(i)("pago")
                                ElseIf DSC.Tables("Montos").Rows(i)("tipo_pago").ToString.ToUpper = "CHEQUE" Then
                                    Cheque += DSC.Tables("Montos").Rows(i)("pago")
                                ElseIf DSC.Tables("Montos").Rows(i)("tipo_pago").ToString.ToUpper = "TRANSFER" Then
                                    Transferencia += DSC.Tables("Montos").Rows(i)("pago")
                                ElseIf DSC.Tables("Montos").Rows(i)("tipo_pago").ToString.ToUpper = "TARJETA" Or DSC.Tables("Montos").Rows(i)("tipo_pago").ToString.ToUpper = "COMIS TAR" Then
                                    Tarjeta += DSC.Tables("Montos").Rows(i)("pago")
                                ElseIf DSC.Tables("Montos").Rows(i)("tipo_pago").ToString.ToUpper = "VALES" Or DSC.Tables("Montos").Rows(i)("tipo_pago").ToString.ToUpper = "COMIS VALES" Then
                                    Vales += DSC.Tables("Montos").Rows(i)("pago")
                                End If
                                Otros += Cheque + Transferencia + Tarjeta + Vales
                            Next
                            If Efectivo > Cheque And Efectivo > Transferencia And Efectivo > Tarjeta And Efectivo > Vales Then
                                ClaveFiscal = "01"
                            ElseIf cheque > Efectivo And cheque > Transferencia And cheque > Tarjeta And cheque > Vales Then
                                ClaveFiscal = "02"
                            ElseIf Transferencia > Cheque And Transferencia > efectivo And Transferencia > Tarjeta And Transferencia > Vales Then
                                ClaveFiscal = "03"
                            ElseIf tarjeta > Cheque And tarjeta > Transferencia And tarjeta > efectivo And tarjeta > Vales Then
                                ClaveFiscal = "-1"
                            ElseIf vales > Cheque And vales > Transferencia And vales > Tarjeta And vales > efectivo Then
                                ClaveFiscal = "08"
                            Else
                                'cuando los montos son iguales 
                                If DSC.Tables("Montos").Rows(0)("tipo_pago").ToString.ToUpper = "EFECTIVO" Then
                                    ClaveFiscal = "01"
                                ElseIf DSC.Tables("Montos").Rows(0)("tipo_pago").ToString.ToUpper = "CHEQUE" Then
                                    ClaveFiscal = "02"
                                ElseIf DSC.Tables("Montos").Rows(0)("tipo_pago").ToString.ToUpper = "TRANSFER" Then
                                    ClaveFiscal = "03"
                                ElseIf DSC.Tables("Montos").Rows(0)("tipo_pago").ToString.ToUpper = "TARJETA" Or DSC.Tables("Montos").Rows(0)("tipo_pago").ToString.ToUpper = "COMIS TAR" Then
                                    ClaveFiscal = "-1"
                                ElseIf DSC.Tables("Montos").Rows(0)("tipo_pago").ToString.ToUpper = "VALES" Or DSC.Tables("Montos").Rows(0)("tipo_pago").ToString.ToUpper = "COMIS VALES" Then
                                    ClaveFiscal = "08"
                                End If
                            End If
                            FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 7).Text = ClaveFiscal

                            If ClaveFiscal = "-1" Then
                                PanelSeleccionTarjetas.Left = Me.Width / 2 - PanelSeleccionTarjetas.Width / 2
                                PanelSeleccionTarjetas.Top = foma.Height / 2 - Me.Height / 2 - PanelSeleccionTarjetas.Height / 2
                                rbTCredito.Checked = False
                                rbTDebito.Checked = False
                                TarjetaSeleccionada = False
                                lbFila.Text = FpTickets.ActiveSheet.ActiveRowIndex
                                FpTickets.ActiveSheet.SetActiveCell(CInt(lbFila.Text), 0)
                                PanelSeleccionTarjetas.Visible = True
                                rbTCredito.Focus()
                            Else
                                TarjetaSeleccionada = True
                            End If


                            If Efectivo > Otros Then
                                'Existe oportunidad para que lo de efectivo, si excede 2000, se haga en menores, y que lo demás en una sola. Es decir, hacer facturas para efectivo, y el resto juntas.
                                Chk_menores.Checked = True
                            Else
                                If Efectivo > 2000 And (Efectivo < Cheque And Efectivo < Transferencia And Efectivo < Tarjeta And Efectivo < Vales) Then
                                    MsgBox("Se harán las facturas separadas en montos menores de $2,000.00", vbInformation, "Facturación de Tickets")
                                    Chk_menores.Checked = True
                                Else
                                    Chk_menores.Checked = False
                                End If
                            End If
                            FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 8).Text = IIf(Chk_menores.Checked, 1, 0)
                            Chk_menores.Enabled = False
                        End If
                        DSC.Tables.Remove("Montos")
                        If PanelSeleccionTarjetas.Visible = False Then
                            If FpTickets.ActiveSheet.ActiveRowIndex < FpTickets.ActiveSheet.RowCount - 1 Then
                                FpTickets.ActiveSheet.ActiveRowIndex = FpTickets.ActiveSheet.ActiveRowIndex + 1
                            Else
                                FpTickets.ActiveSheet.RowCount = FpTickets.ActiveSheet.RowCount + 1
                                FpTickets.ActiveSheet.ActiveRowIndex = FpTickets.ActiveSheet.RowCount - 1
                            End If
                            FpTickets.ActiveSheet.ActiveColumnIndex = 0
                        End If
                    Else
                        MsgBox("El Folio del ticket no existe como venta registrada.", vbExclamation, "Facturación de Tickets")
                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text = ""
                    End If
                    DSC.Tables.Remove("TABLA")
                Else
                    MsgBox("El Folio del ticket debe ser numérico.", vbExclamation, "Facturación de Tickets")
                    FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text = ""
                End If
            End If
        End If
        Corriendo = False
    End Sub
    Private Sub fptickets_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FpTickets.KeyPress
        '    Dim sql As String
        '    Dim dsc As New DataSet
        '    Dim IVA As Double
        '    Dim GRAVADO As Double
        '    Dim SINGRAVAR As Double


        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Return Then

            '        If FpTickets.ActiveSheet.ActiveColumnIndex = 0 Then
            '            If FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text <> "" Then
            '                If IsNumeric(FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text) Then
            '                    sql = "select  VEN_ID ,VEN_TOTAL, SUM(DVE_IVA) IVA, SUM(DVE_IEPS) IEPS from ecventa INNER JOIN ECVENTADET ON DVE_VENTA=VEN_ID where ven_id=" & FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text &
            '                                        " GROUP BY VEN_ID,VEN_TOTAL"
            '                    Base.daQuery(sql, xcon, dsc, "tabla")

            '                    If dsc.Tables("TABLA").Rows.Count > 0 Then
            '                        IVA = CDbl(dsc.Tables("TABLA").Rows(0)("IVA"))
            '                        GRAVADO = Math.Round(IVA / 0.16, 2)
            '                        SINGRAVAR = CDbl(dsc.Tables("TABLA").Rows(0)("VEN_TOTAL")) - IVA - GRAVADO
            '                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 1).Value = SINGRAVAR
            '                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 2).Value = GRAVADO
            '                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 3).Value = IVA
            '                        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 4).Value = SINGRAVAR + GRAVADO + IVA

            '                        If FpTickets.ActiveSheet.ActiveRowIndex < FpTickets.ActiveSheet.RowCount - 1 Then
            '                            FpTickets.ActiveSheet.ActiveRowIndex = FpTickets.ActiveSheet.ActiveRowIndex + 1
            '                        Else
            '                            FpTickets.ActiveSheet.RowCount = FpTickets.ActiveSheet.RowCount + 1
            '                            FpTickets.ActiveSheet.ActiveRowIndex = FpTickets.ActiveSheet.RowCount - 1
            '                        End If
            '                        FpTickets.ActiveSheet.ActiveColumnIndex = 0
            '                    End If
            '                    dsc.Tables.Remove("TABLA")
            '                End If
            '            End If

            '        End If
        End If

        '    If Asc(e.KeyChar) = Keys.Escape Then
        '        FpTickets.ActiveSheet.Cells(FpTickets.ActiveSheet.ActiveRowIndex, 0).Text = ""
        '    End If

        '    FpTickets.Focus()

    End Sub


    Private Sub fptickets_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FpTickets.KeyUp
        If e.KeyCode = (Keys.Delete) Then
            FpTickets.ActiveSheet.RemoveRows(FpTickets.ActiveSheet.ActiveRowIndex, 1)
        End If

    End Sub



    'Private Sub insertarcompras()
    '    Dim siguiente As Double
    '    Dim sql As String
    '    Dim i As Integer
    '    Dim dsc As New DataSet
    '    Dim pro As String



    '    sql = "SELECT * FROM ECCONSEMPRESA WHERE EMP_CLAVE=" & txt_cvesucursal.Text
    '    Base.daQuery(sql, xcon, dsc, "TABLA")
    '    foliocompra1.Text = CDbl(dsc.Tables("TABLA").Rows(0)("FOLIO_VENTAS"))
    '    siguiente = CDbl(dsc.Tables("TABLA").Rows(0)("FOLIO_VENTAS"))

    '    CMB_TIPO.SelectedIndex = 1
    '    If CMB_TIPO.SelectedIndex = 1 Then
    '        factura.Text = CDbl(dsc.Tables("TABLA").Rows(0)("FOLIO_FACTURA"))
    '        sql = "UPDATE ECCONSEMPRESA SET FOLIO_FACTURA=FOLIO_FACTURA+1 WHERE EMP_CLAVE=" & txt_cvesucursal.Text
    '        Base.Ejecuta(sql, xcon)
    '    End If
    '    If CMB_TIPO.SelectedIndex = 2 Then
    '        factura.Text = CDbl(dsc.Tables("TABLA").Rows(0)("FOLIO_REMISION"))
    '        sql = "UPDATE ECCONSEMPRESA SET FOLIO_REMISION=FOLIO_REMISION+1 WHERE EMP_CLAVE=" & txt_cvesucursal.Text
    '        Base.Ejecuta(sql, xcon)
    '    End If
    '    dsc.Tables.Remove("TABLA")

    '    sql = "UPDATE ECCONSEMPRESA SET FOLIO_VENTAS=FOLIO_VENTAS+1 WHERE EMP_CLAVE=" & txt_cvesucursal.Text
    '    Base.Ejecuta(sql, xcon)

    '    pro = cmb_proveedor.SelectedItem()
    '    pro = pro.Substring(0, 4)

    '    sql = "Insert into ECVENTAMOSH (com_id,COM_EMPRESA,com_FechaCaptura,com_fechafactura,com_factura,com_cliente,com_fpp,com_fot,com_subtotal,com_descuento,com_iva,com_total,com_estatus,COM_SALDO,COM_TIPO)VALUES(" & _
    '    siguiente.ToString & "," & txt_cvesucursal.Text & ",'" & dafecha(txt_fechacaptura.Text) & "','" & _
    '    dafecha(txt_fechafactura.Text) & "','" & _
    '    factura.Text & "','" & _
    '    pro.Trim & "'," & _
    '    CDbl(fprontopago.Text) & "," & _
    '    CDbl(fotros.Text) & ",ROUND(" & _
    '    CDbl(xsubtotal) & ",2),ROUND(" & _
    '    CDbl(xdescuento) & ",2),ROUND(" & _
    '    CDbl(xiva) & ",2),ROUND(" & _
    '    CDbl(xsubtotal - xdescuento + xiva) & ",2),1,ROUND(" & _
    '    CDbl(xsubtotal - xdescuento + xiva) & ",2)," & _
    '    CMB_TIPO.SelectedIndex & ")"


    '    Base.Ejecuta(sql, xcon)

    '    For i = 0 To fp_articulos.ActiveSheet.RowCount - 1
    '        If fp_articulos.ActiveSheet.Cells(i, 1).Text <> "" Then

    '            sql = "Insert into ecdetventamosH (dcom_compra,dcom_empresa,dcom_renglon,dcom_cantidad,dcom_concepto," & _
    '            "dcom_costo,dcom_iva,dcom_fiva,dcom_total) values (" & _
    '            siguiente & "," & _
    '            txt_cvesucursal.Text & "," & _
    '            (i + 1) & "," & _
    '            CDbl(fp_articulos.ActiveSheet.Cells(i, 0).Text) & ",'" & _
    '        (fp_articulos.ActiveSheet.Cells(i, 1).Value) & "'," & _
    '            CDbl(fp_articulos.ActiveSheet.Cells(i, 3).Value) & "," & _
    '           Math.Round(CDbl(fp_articulos.ActiveSheet.Cells(i, 3).Value) * CDbl(fp_articulos.ActiveSheet.Cells(i, 2).Value) / 100, 2) & "," & _
    '             CDbl(fp_articulos.ActiveSheet.Cells(i, 2).Value) & "," & _
    '            CDbl(fp_articulos.ActiveSheet.Cells(i, 4).Value) & ")"
    '            Base.Ejecuta(sql, xcon)
    '        End If
    '    Next i
    '    foliocompra1.Text = siguiente
    '    '   sql = "EXEC APLICAMOVTOSVENTAMOS " & siguiente & "," & txt_cvesucursal.Text
    '    '    Base.Ejecuta(sql, xcon)
    '    Imprimir()




    '    nuevo.Enabled = True


    '    fp_articulos.ActiveSheet.RowCount = 0
    '    cmb_proveedor.SelectedIndex = 0
    '    CMB_TIPO.SelectedIndex = 0
    '    factura.Text = ""
    '    filtro.Text = ""
    '    recalcula()

    '    MsgBox("DOCUMENTO GENERADO CORRECTAMENTE", MsgBoxStyle.Exclamation)
    '    inicia()
    'End Sub


    Private Function dafecha(ByVal TODAY As Date) As String
        dafecha = CStr(Year(TODAY)) & IIf(Month(TODAY) < 10, "0" & CStr(Month(TODAY)), CStr(Month(TODAY))) &
        IIf(TODAY.Day < 10, "0" & CStr(TODAY.Day), CStr(TODAY.Day))
    End Function



    'Private Sub foliocompra1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles foliocompra1.KeyPress
    '    If e.KeyChar = Chr(Keys.Enter) Then
    '        Dim FRBUSQUEDA As New busqueda
    '        FRBUSQUEDA.TXTCONTROL = Me.foliocompra1
    '        GENERAL.parametrosbusqueda(FRBUSQUEDA, "Ventas Registradas", "com_id,com_factura,com_fechafactura,com_total,cli_nombre,com_estatus", "ECVENTAMOS inner join ECCTES on cli_clave=com_cliente and com_empresa=CLI_EMPRESA", "com_fechafactura", "2", xcon, "O.C,Factura,TODAY Fact,Total,Cliente,Estatus", "50,80,60,60,200,50", "A,A,A,#,A,A", "1", "COM_EMPRESA=" & txt_cvesucursal.Text)
    '        FRBUSQUEDA.ShowDialog()
    '        FRBUSQUEDA.Dispose()
    '    End If
    'End Sub

    'Private Sub Imprimir()
    '    Dim orep As REPORTE
    '    Dim comma As String
    '    comma = """"

    '    '      On Error Resume Next

    '    orep = New REPORTE
    '    Select Case CMB_TIPO.SelectedIndex
    '        Case 1
    '            orep.REPORTE = "c:\ec\reportes\" & "emitefactura.RPT"
    '            orep.TITULO = "FACTURA EMITIDA"

    '    End Select
    '    orep.SERVIDOR = Globales.sServidor
    '    orep.BASEDATOS = Globales.sBaseDatos
    '    orep.USUARIO = Globales.sUsuarioBase
    '    orep.CLAVEACCESO = Globales.sClaveUsuario
    '    orep.SELECCIONAR = "{ECVENTAMOS.com_id} = " & foliocompra1.Text & " AND {ECVENTAMOS.com_empresa}=" & txt_cvesucursal.Text
    '    orep.Show()

    '    cmb_proveedor.SelectedIndex = 0
    '    CMB_TIPO.SelectedIndex = 0
    '    foliocompra1.Text = ""
    '    filtro.Text = ""
    '    fprontopago.Text = "0"
    '    fotros.Text = 1
    '    nuevo.Enabled = True

    '    regresar.Enabled = True
    'End Sub



    Private Sub regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegresar.Click
        Me.Hide()
        foma.Show()
        Me.Dispose()
    End Sub


    Private Sub filtro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFiltro.TextChanged
        rellenaPROVEEDORES()
        TxtFiltro.Focus()
    End Sub

    '    Private Sub partido()
    '        Dim SQL As String
    '        Dim DSC As New DataSet
    '        Dim J As Integer
    '        Dim dsmicrosip As New DataSet
    '        Dim IVA As Double
    '        Dim FOLIO As String
    '        Dim monto As Double
    '        Dim renglon As Integer
    '        Dim CODIGO As Integer
    '        Dim control As Integer
    '        Dim TXTFECHA As String
    '        Dim FECHA As Date
    '        Dim siguiente As Integer
    '        Dim txtfolio As String
    '        Dim pro As String
    '        Dim DSC4 As New DataSet

    '        pro = cmb_proveedor.SelectedItem()
    '        pro = pro.Substring(0, 6)


    '        Base.daQueryMICROSIP("select a.cliente_id,b.clave_cliente,c.dir_cli_id from clientes a inner join claves_clientes b on a.cliente_id=b.cliente_id inner join dirs_clientes c on a.cliente_id=c.cliente_id  where a.cliente_id=" & pro, conmicrosip, DSC4, "CLIENTE", Globales.basemicrosip)
    '        If DSC4.Tables("CLIENTE").Rows.Count <= 0 Then
    '            MsgBox("proveedor interno " & pro, MsgBoxStyle.Exclamation)
    '            MsgBox("Debe de indicar el cliente para el que va a generar la factura", MsgBoxStyle.Information)
    '        Else
    '            FOLIO = ""
    '            FECHA = Today.Date
    '            TXTFECHA = ("0" & FECHA.Month.ToString).Substring(Len(("0" & FECHA.Month.ToString)) - 2, 2) & "/" & ("0" & FECHA.Day.ToString).Substring(Len(("0" & FECHA.Day.ToString)) - 2, 2) & "/" & FECHA.Year.ToString
    '            siguiente = 0
    '            IVA = 0
    '            monto = 0
    '            control = 0
    '            renglon = 1

    '            Dim i As Integer

    '            For i = 0 To fptickets.ActiveSheet.RowCount - 1

    '                SQL = "SELECT * FROM ECDETVENTA  inner join articulo on art_clave=dve_articulo where DVE_VENTA=" & fptickets.ActiveSheet.Cells(i, 0).Text & " order by dve_renglon"
    '                Base.daQuery(SQL, xcon, DSC, "TABLA")

    '                For J = 0 To DSC.Tables("TABLA").Rows.Count - 1
    '                    If (monto + IVA + CDbl(DSC.Tables("tabla").Rows(i)("dve_total"))) > 2000 Then

    '                        SQL = "UPDATE DOCTOS_VE SET IMPORTE_NETO=" & monto.ToString & ",TOTAL_IMPUESTOS=" & IVA.ToString & " WHERE DOCTO_VE_ID=" & siguiente
    '                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '                        Base.EjecutaMICROSIP("EXECUTE PROCEDURE  APLICA_DOCTO_VE " & siguiente, conmicrosip, Globales.basemicrosip)
    '                        MsgBox(" GENERACION DE VENTA PARA FACTURACION EN MICROSIP REALIZADA CORRECTAMENTE", MsgBoxStyle.Exclamation)
    '                        control = 0

    '                    End If
    '                    '--------------------------------------------------------------------------------
    '                    '  ----------------PARA VERIFICAR QUE EXISTA EL ARTICULO SI NO EXISTIO LO INSERTO

    '                    SQL = "SELECT ARTICULO_ID FROM CLAVES_ARTICULOS WHERE CLAVE_ARTICULO='" & DSC.Tables("TABLA").Rows(J)("DVE_ARTICULO") & "'"
    '                    Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "TABLAM", Globales.basemicrosip)
    '                    If dsmicrosip.Tables("TABLAM").Rows.Count <= 0 Then
    '                        MsgBox("no existe el articulo", MsgBoxStyle.Exclamation)

    '                        SQL = "INSERT INTO ARTICULOS (ARTICULO_ID,NOMBRE,ES_ALMACENABLE,ES_JUEGO,ESTATUS,UNIDAD_VENTA,UNIDAD_COMPRA,CONTENIDO_UNIDAD_COMPRA) " & _
    '                            " VALUES (-1,'" & DSC.Tables("TABLA").Rows(J)("ART_NOMLARGO") & "','S','N','A','" & _
    '                            DSC.Tables("TABLA").Rows(J)("ART_UNI2") & "','" & _
    '                            DSC.Tables("TABLA").Rows(J)("ART_UNI1") & "'," & _
    '                        DSC.Tables("TABLA").Rows(J)("ART_CAP2") & ")"
    '                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
    '                        MsgBox("inserte en articulos", MsgBoxStyle.Exclamation)

    '                        SQL = "SELECT ARTICULO_ID FROM ARTICULOS WHERE NOMBRE ='" & DSC.Tables("TABLA").Rows(J)("ART_NOMLARGO") & "'"
    '                        Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "TABLAM2", Globales.basemicrosip)
    '                        If dsmicrosip.Tables("TABLAM2").Rows.Count > 0 Then
    '                            CODIGO = dsmicrosip.Tables("TABLAM2").Rows(0)("ARTICULO_ID")
    '                        Else
    '                            MsgBox("ERROR NO SE INSERTO EL REGISTRO ", MsgBoxStyle.Exclamation)
    '                            CODIGO = 0
    '                        End If
    '                        dsmicrosip.Tables.Remove("TABLAM2")

    '                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '                        SQL = "INSERT INTO CLAVES_ARTICULOS (CLAVE_ARTICULO_ID,CLAVE_ARTICULO,ARTICULO_ID,ROL_CLAVE_ART_ID) VALUES " & _
    '                            "(-1,'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," & _
    '                         CODIGO & ",17)"
    '                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
    '                        MsgBox("inserte en clavesarticulos", MsgBoxStyle.Exclamation)

    '                        SQL = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," & _
    '                            CODIGO & "," & IIf(CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) = 0, Globales.CVEEXCENTO, Globales.CVEIMPUESTO) & ")"
    '                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
    '                        MsgBox("inserte en impuestos", MsgBoxStyle.Exclamation)

    '                    Else
    '                        CODIGO = dsmicrosip.Tables("TABLAM").Rows(0)("ARTICULO_ID")
    '                    End If
    '                    dsmicrosip.Tables.Remove("TABLAM")


    '                    '--------------------------------------------------------------------------------------------------------------

    '                    If control = 0 Then

    '                        SQL = " SELECT CONSECUTIVO  FROM FOLIOS_VENTAS  WHERE TIPO_DOCTO='R'"

    '                        Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla", Globales.basemicrosip)

    '                        If dsmicrosip.Tables("xtabla").Rows.Count > 0 Then

    '                            FOLIO = (dsmicrosip.Tables("xtabla").Rows(0)("CONSECUTIVO"))
    '                            txtfolio = "00000000 " & FOLIO

    '                            FOLIO = txtfolio.Substring(Len(txtfolio) - 8, 8)

    '                            Base.EjecutaMICROSIP("UPDATE FOLIOS_VENTAS  SET CONSECUTIVO=CONSECUTIVO+1 WHERE TIPO_DOCTO='R' ", conmicrosip, Globales.basemicrosip)

    '                        End If

    '                        dsmicrosip.Tables.Remove("XTABLA")
    '                        '  SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " & _
    '                        '       " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','001',28433,28435,28435,19,1,1,'P','P','S',1,1,'N',287,'VE')"
    '                        '' duarsa1
    '                        '                        SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " & _
    '                        '         " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','" & DSC4.Tables("cliente").Rows(0)("clave_cliente") & "'," & _
    '                        '                DSC4.Tables("cliente").Rows(0)("cliente_id") & "," & _
    '                        'DSC4.Tables("cliente").Rows(0)("dir_cli_id") & "," & _
    '                        'DSC4.Tables("cliente").Rows(0)("dir_cli_id") & ",19,1,1,'P','P','S',1,1,'N',304,'VE')"

    '                        '' duarsa2

    '                        SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " & _
    '                 " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','" & DSC4.Tables("cliente").Rows(0)("clave_cliente") & "'," & _
    '                    DSC4.Tables("cliente").Rows(0)("cliente_id") & "," & _
    '                    DSC4.Tables("cliente").Rows(0)("dir_cli_id") & "," & _
    '                     DSC4.Tables("cliente").Rows(0)("dir_cli_id") & ",19,1,1,'P','P','S',1,1,'N',287,'VE')"



    '                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '                        SQL = "select docto_ve_id siguiente from doctos_ve where almacen_id=19 and tipo_docto='R'  and folio='" & FOLIO & "'"

    '                        ' sql = " Select  max(docto_IN_id) siguiente from doctos_in "
    '                        Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla3", Globales.basemicrosip)

    '                        siguiente = dsmicrosip.Tables("xtabla3").Rows(0)("siguiente")


    '                        dsmicrosip.Tables.Remove("xtabla3")
    '                        control = 1
    '                    End If







    '                    SQL = "INSERT INTO DOCTOS_VE_DET ( DOCTO_VE_DET_ID,DOCTO_VE_ID,CLAVE_ARTICULO,ARTICULO_ID,UNIDADES,PRECIO_UNITARIO,PRECIO_TOTAL_NETO,POSICION) " & _
    '                        " VALUES ( -1," & _
    '                        siguiente & "," & _
    '                        "'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," & _
    '                        CODIGO & "," & _
    '                       CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) & "," & _
    '                        Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2) & "," & _
    '                    CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2) & "," & _
    '                    renglon & ")"

    '                    Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '                    monto = monto + CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2)
    '                    IVA = IVA + (CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2)) * (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)
    '                    renglon = renglon + 1
    '                Next J
    '                DSC.Tables.Remove("TABLA")
    '                End If


    '            Next i









    '        If fptickets.ActiveSheet.Cells(i, 0).Text <> "" Then

    '            If control = 0 Then

    '                SQL = " SELECT CONSECUTIVO  FROM FOLIOS_VENTAS  WHERE TIPO_DOCTO='R'"

    '                Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla", Globales.basemicrosip)

    '                If dsmicrosip.Tables("xtabla").Rows.Count > 0 Then

    '                    FOLIO = (dsmicrosip.Tables("xtabla").Rows(0)("CONSECUTIVO"))
    '                    txtfolio = "00000000 " & FOLIO

    '                    FOLIO = txtfolio.Substring(Len(txtfolio) - 8, 8)

    '                    Base.EjecutaMICROSIP("UPDATE FOLIOS_VENTAS  SET CONSECUTIVO=CONSECUTIVO+1 WHERE TIPO_DOCTO='R' ", conmicrosip, Globales.basemicrosip)

    '                End If

    '                dsmicrosip.Tables.Remove("XTABLA")
    '                '  SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " & _
    '                '       " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','001',28433,28435,28435,19,1,1,'P','P','S',1,1,'N',287,'VE')"
    '                '' duarsa1
    '                '                        SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " & _
    '                '         " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','" & DSC4.Tables("cliente").Rows(0)("clave_cliente") & "'," & _
    '                '                DSC4.Tables("cliente").Rows(0)("cliente_id") & "," & _
    '                'DSC4.Tables("cliente").Rows(0)("dir_cli_id") & "," & _
    '                'DSC4.Tables("cliente").Rows(0)("dir_cli_id") & ",19,1,1,'P','P','S',1,1,'N',304,'VE')"

    '                '' duarsa2

    '                SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " & _
    ' " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','" & DSC4.Tables("cliente").Rows(0)("clave_cliente") & "'," & _
    '        DSC4.Tables("cliente").Rows(0)("cliente_id") & "," & _
    'DSC4.Tables("cliente").Rows(0)("dir_cli_id") & "," & _
    'DSC4.Tables("cliente").Rows(0)("dir_cli_id") & ",19,1,1,'P','P','S',1,1,'N',287,'VE')"



    '                Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '                SQL = "select docto_ve_id siguiente from doctos_ve where almacen_id=19 and tipo_docto='R'  and folio='" & FOLIO & "'"

    '                ' sql = " Select  max(docto_IN_id) siguiente from doctos_in "
    '                Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla3", Globales.basemicrosip)

    '                siguiente = dsmicrosip.Tables("xtabla3").Rows(0)("siguiente")


    '                dsmicrosip.Tables.Remove("xtabla3")
    '                control = 1
    '            End If

    '            SQL = "SELECT * FROM ECDETVENTA  inner join articulo on art_clave=dve_articulo where DVE_VENTA=" & fptickets.ActiveSheet.Cells(i, 0).Text & " order by dve_renglon"
    '            Base.daQuery(SQL, xcon, DSC, "TABLA")

    '            For J = 0 To DSC.Tables("TABLA").Rows.Count - 1
    '                '--------------------------------------------------------------------------------
    '                '  ----------------PARA VERIFICAR QUE EXISTA EL ARTICULO SI NO EXISTIO LO INSERTO

    '                SQL = "SELECT ARTICULO_ID FROM CLAVES_ARTICULOS WHERE CLAVE_ARTICULO='" & DSC.Tables("TABLA").Rows(J)("DVE_ARTICULO") & "'"
    '                Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "TABLAM", Globales.basemicrosip)
    '                If dsmicrosip.Tables("TABLAM").Rows.Count <= 0 Then
    '                    MsgBox("no existe el articulo", MsgBoxStyle.Exclamation)

    '                    SQL = "INSERT INTO ARTICULOS (ARTICULO_ID,NOMBRE,ES_ALMACENABLE,ES_JUEGO,ESTATUS,UNIDAD_VENTA,UNIDAD_COMPRA,CONTENIDO_UNIDAD_COMPRA) " & _
    '                        " VALUES (-1,'" & DSC.Tables("TABLA").Rows(J)("ART_NOMLARGO") & "','S','N','A','" & _
    '                        DSC.Tables("TABLA").Rows(J)("ART_UNI2") & "','" & _
    '                        DSC.Tables("TABLA").Rows(J)("ART_UNI1") & "'," & _
    '                    DSC.Tables("TABLA").Rows(J)("ART_CAP2") & ")"
    '                    Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
    '                    MsgBox("inserte en articulos", MsgBoxStyle.Exclamation)

    '                    SQL = "SELECT ARTICULO_ID FROM ARTICULOS WHERE NOMBRE ='" & DSC.Tables("TABLA").Rows(J)("ART_NOMLARGO") & "'"
    '                    Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "TABLAM2", Globales.basemicrosip)
    '                    If dsmicrosip.Tables("TABLAM2").Rows.Count > 0 Then
    '                        CODIGO = dsmicrosip.Tables("TABLAM2").Rows(0)("ARTICULO_ID")
    '                    Else
    '                        MsgBox("ERROR NO SE INSERTO EL REGISTRO ", MsgBoxStyle.Exclamation)
    '                        CODIGO = 0
    '                    End If
    '                    dsmicrosip.Tables.Remove("TABLAM2")

    '                    Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '                    SQL = "INSERT INTO CLAVES_ARTICULOS (CLAVE_ARTICULO_ID,CLAVE_ARTICULO,ARTICULO_ID,ROL_CLAVE_ART_ID) VALUES " & _
    '                        "(-1,'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," & _
    '                     CODIGO & ",17)"
    '                    Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
    '                    MsgBox("inserte en clavesarticulos", MsgBoxStyle.Exclamation)

    '                    SQL = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," & _
    '                        CODIGO & "," & IIf(CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) = 0, Globales.CVEEXCENTO, Globales.CVEIMPUESTO) & ")"
    '                    Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
    '                    MsgBox("inserte en impuestos", MsgBoxStyle.Exclamation)

    '                Else
    '                    CODIGO = dsmicrosip.Tables("TABLAM").Rows(0)("ARTICULO_ID")
    '                End If
    '                dsmicrosip.Tables.Remove("TABLAM")


    '                '--------------------------------------------------------------------------------------------------------------
    '                SQL = "INSERT INTO DOCTOS_VE_DET ( DOCTO_VE_DET_ID,DOCTO_VE_ID,CLAVE_ARTICULO,ARTICULO_ID,UNIDADES,PRECIO_UNITARIO,PRECIO_TOTAL_NETO,POSICION) " & _
    '                    " VALUES ( -1," & _
    '                    siguiente & "," & _
    '                    "'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," & _
    '                    CODIGO & "," & _
    '                   CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) & "," & _
    '                    Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2) & "," & _
    '                CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2) & "," & _
    '                renglon & ")"

    '                Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '                monto = monto + CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2)
    '                IVA = IVA + (CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2)) * (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)
    '                renglon = renglon + 1
    '            Next J
    '            DSC.Tables.Remove("TABLA")
    '        End If


    '            Next i


    '        SQL = "UPDATE DOCTOS_VE SET IMPORTE_NETO=" & monto.ToString & ",TOTAL_IMPUESTOS=" & IVA.ToString & " WHERE DOCTO_VE_ID=" & siguiente
    '        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

    '        Base.EjecutaMICROSIP("EXECUTE PROCEDURE  APLICA_DOCTO_VE " & siguiente, conmicrosip, Globales.basemicrosip)
    '        MsgBox(" GENERACION DE VENTA PARA FACTURACION EN MICROSIP REALIZADA CORRECTAMENTE", MsgBoxStyle.Exclamation)


    '        fptickets.ActiveSheet.RowCount = 0
    '        fptickets.ActiveSheet.RowCount = 1
    '        End If
    '        DSC4.Tables.Remove("cliente")
    '    End Sub

    Private Sub generaparciales()
        Dim SQL As String
        Dim DSC As New DataSet
        Dim J As Integer
        Dim dsmicrosip As New DataSet
        Dim IVA As Double
        Dim FOLIO As String
        Dim monto As Double
        Dim renglon As Integer
        Dim CODIGO As Integer
        Dim control As Integer

        Dim FECHA As Date
        Dim siguiente As Integer
        Dim txtfolio As String
        Dim pro As String
        Dim DSC4 As New DataSet
        Dim RestanteTotalArticulo As Double
        Dim CuantosCaben As Double
        Dim SujetoIEPS As Boolean

        RestanteTotalArticulo = 0
        If CmbCliente.SelectedIndex > -1 Then
            pro = CmbCliente.SelectedItem()
            pro = pro.Substring(0, 7)
        Else
            MsgBox("Debe seleccionar el cliente a facturar.", vbExclamation, "Facturación de Tickets")
            Exit Sub
        End If

        Base.daQueryMICROSIP("select a.cliente_id,c.dir_cli_id,a.SUJETO_IEPS from clientes a inner join dirs_clientes c on a.cliente_id=c.cliente_id  where a.cliente_id=" & pro, conmicrosip, DSC4, "CLIENTE", Globales.basemicrosip)
        If DSC4.Tables("CLIENTE").Rows.Count <= 0 Then
            MsgBox("Debe de indicar el cliente para el que va a generar la factura", MsgBoxStyle.Information)
            Exit Sub
        Else
            Dim RemanenteFacturaPartida As Double
            Dim CantidadArticulo As Double
            Dim i As Integer
            Dim anterior As Integer

            Dim TEXTO As String
            Dim MenoresTexto As String
            Dim FormaPagoTexto As String

            TEXTO = ""
            MenoresTexto = ""
            FormaPagoTexto = ""

            If DSC4.Tables("CLIENTE").Rows(0)("SUJETO_IEPS").ToString.ToUpper = "S" Then
                CheckBox1.Checked = True
                SujetoIEPS = True
            Else
                CheckBox1.Checked = False
                SujetoIEPS = False
            End If
            Dim Cuantas As Integer = 0
            Dim FPago As String = ""
            For i = 0 To FpTickets.ActiveSheet.RowCount - 1
                If FpTickets.ActiveSheet.Cells(i, 0).Text <> "" Then
                    If IsNumeric(FpTickets.ActiveSheet.Cells(i, 0).Text) Then
                        If FPago <> FpTickets.ActiveSheet.Cells(i, 7).Text Then
                            If FPago = "" Then
                                FPago = FpTickets.ActiveSheet.Cells(i, 7).Text
                            Else
                                MsgBox("No puede facturar varios tickets con distintas formas de pago.", vbInformation, "Facturación de Tickets")
                                Exit Sub
                            End If
                        End If
                        TEXTO = IIf(TEXTO = "", "" & FpTickets.ActiveSheet.Cells(i, 0).Text, TEXTO & "," & FpTickets.ActiveSheet.Cells(i, 0).Text)
                        MenoresTexto = IIf(MenoresTexto = "", "" & FpTickets.ActiveSheet.Cells(i, 8).Text, MenoresTexto & "," & FpTickets.ActiveSheet.Cells(i, 8).Text)
                        FormaPagoTexto = IIf(FormaPagoTexto = "", "" & FpTickets.ActiveSheet.Cells(i, 7).Text, FormaPagoTexto & "," & FpTickets.ActiveSheet.Cells(i, 7).Text)
                        Cuantas += 1
                    End If
                End If
            Next i

            Dim Folios() As String
            Dim Menores() As String
            Dim FormasP() As String
            Dim Errores As Boolean = Nothing
            If Cuantas > 0 Then
                Folios = TEXTO.Split(",")
                Menores = MenoresTexto.Split(",")
                FormasP = FormaPagoTexto.Split(",")
            End If

            For f As Integer = 0 To Cuantas - 1
                TEXTO = Folios(f)
                MenoresTexto = Menores(f)
                FormaPagoTexto = FormasP(f)

                ' Validar Formas de Pago Microsip
                Base.daQueryMICROSIP("select forma_cobro_cc_id from formas_cobro_cc where CLAVE_FISCAL='" & FormaPagoTexto & "' and UPPER(nombre) <>'TRANSFERENCIA'", conmicrosip, DSC4, "FormaPago", Globales.basemicrosip)
                If DSC4.Tables("FormaPago").Rows.Count > 0 Then
                    Dim PagoID As Integer = DSC4.Tables("FormaPago").Rows(0)("forma_cobro_cc_id")
                    Base.daQueryMICROSIP("select*from formas_cobro_clientes where cliente_id=" & DSC4.Tables("cliente").Rows(0)("cliente_id") & " and FORMA_COBRO_ID=" & PagoID, conmicrosip, DSC4, "Existe", Globales.basemicrosip)
                    If DSC4.Tables("Existe").Rows.Count > 0 Then
                        Base.EjecutaMICROSIP("Update formas_cobro_clientes set ult_utilizada='S' where cliente_id=" & DSC4.Tables("cliente").Rows(0)("cliente_id") & " and FORMA_COBRO_ID=" & PagoID, conmicrosip, Globales.basemicrosip)
                        Base.EjecutaMICROSIP("Update formas_cobro_clientes set ult_utilizada='N' where cliente_id=" & DSC4.Tables("cliente").Rows(0)("cliente_id") & " and FORMA_COBRO_ID<>" & PagoID, conmicrosip, Globales.basemicrosip)
                    Else
                        Base.EjecutaMICROSIP("insert into formas_cobro_clientes values(-1," & DSC4.Tables("cliente").Rows(0)("cliente_id") & ",'CC'," & PagoID & ",'',null,'S')", conmicrosip, Globales.basemicrosip)
                        Base.EjecutaMICROSIP("Update formas_cobro_clientes set ult_utilizada='N' where cliente_id=" & DSC4.Tables("cliente").Rows(0)("cliente_id") & " and FORMA_COBRO_ID<>" & PagoID, conmicrosip, Globales.basemicrosip)
                    End If
                    DSC4.Tables.Remove("Existe")
                Else
                    MsgBox("Al facturar la remisión, deberá elegir la forma de pago correcta.", vbInformation, "Facturación de Tickets")
                End If
                DSC4.Tables.Remove("FormaPago")

                Dim MenoresBol As Boolean = Chk_menores.Checked
                If CInt(MenoresTexto) = 0 Then
                    MenoresBol = False
                Else
                    MenoresBol = True
                End If

                Base.daQuery("select count(ven_id) from ecventa where ven_id=" & TEXTO & " and VEN_STATUS<>2 and VEN_FECHACANC is null", xcon, DSC, "Existe")
                If DSC.Tables("Existe").Rows(0)(0) = 0 Then
                    Errores = True
                    MsgBox("No pueden facturarse tickets cancelados.", vbExclamation, "Facturación de Tickets")
                Else
                    Base.daQueryMICROSIP("select count(docto_ve_id) Cuantos from doctos_ve where orden_compra='" & TEXTO & "' and fecha_hora_cancelacion is null", conmicrosip, dsmicrosip, "ExisteMicrosip", Globales.basemicrosip)
                    If dsmicrosip.Tables("ExisteMicrosip").Rows(0)("Cuantos") > 0 Then
                        Errores = True
                        MsgBox("Existen documentos vigentes en Microsip ligados a este ticket; no se puede mandar a facturar nuevamente.", vbExclamation, "Facturación de Tickets")
                    Else
                        FOLIO = ""
                        FECHA = Today.Date
                        siguiente = 0
                        IVA = 0
                        monto = 0
                        control = 0
                        RemanenteFacturaPartida = 2000
                        J = 0
                        anterior = 0
                        renglon = 0
                        RestanteTotalArticulo = 0

                        ' ------------------------------------------------------------------------------------------------------
                        ' MODIFICACION CRITICA: Traer Factor de Empaque desde XUPC y unir con devoluciones
                        ' Esto permite saber si es caja (Factor > 1) o pieza (Factor 1) para desglosar correctamente.
                        ' ------------------------------------------------------------------------------------------------------
                        SQL = "SELECT ISNULL(x.upc_factor, 1) AS Factor, " &
                          "DVE_Cantidad - isnull(dev.CANTDEV,0) DVE_Cantidad, " &
                          "round(DVE_TOTAL-(isnull(dev.CANTDEV,0)*DVE_PRECIO),2) DVE_TOTAL, " &
                          "DVE_PRECIO, ARTICULO.* " &
                          "FROM ECDETVENTA e " &
                          "INNER JOIN articulo On art_clave=dve_articulo " &
                          "LEFT JOIN XUPC x ON e.dve_upc = x.upc_upc " &
                          "LEFT JOIN (Select ID_ARTICULO,SUM(CANTIDAD)As CANTDEV FROM eccancxupc WHERE N_TICKET In (" & TEXTO & ") GROUP BY ID_ARTICULO ) dev On dev.id_articulo=e.dve_articulo " &
                          "WHERE DVE_VENTA In (" & TEXTO & ") And dve_cantidad>0 and dve_precio>0 " &
                          "ORDER BY DVE_VENTA,dve_renglon asc"

                        Base.daQuery(SQL, xcon, DSC, "TABLA")

                        ' ------------------------------------------------------------------------------------------------------
                        ' VALVULA DE SEGURIDAD
                        ' Revisar todo el ticket antes de procesar para detectar artículos indivisibles caros (> $2000)
                        ' ------------------------------------------------------------------------------------------------------
                        If MenoresBol Then
                            For Each row As DataRow In DSC.Tables("TABLA").Rows
                                If CDbl(row("DVE_PRECIO")) >= 2000 AndAlso CDbl(row("Factor")) = 1 Then
                                    ' Si tiene codrel, es lógica vieja y podría pasar, pero si es nuevo y factor 1, es error.
                                    ' Asumimos riesgo de bloquear si es > 2000 indivisible.
                                    If row("art_codrel").ToString = "" Then
                                        Errores = True
                                        MsgBox("El ticket contiene un artículo (" & row("art_nomlargo") & ") que excede los $2,000.00 y no es divisible (Factor 1). No puede facturarse como 'Menores'.", vbExclamation, "Facturación de Tickets")
                                        Me.Close()
                                        Exit Sub
                                    End If
                                End If
                            Next
                        End If

                        J = 0
                        While J <= DSC.Tables("TABLA").Rows.Count - 1
                            ' Inicio de creación de documento Microsip si no existe
                            If control = 0 Then
                                SQL = " Select CONSECUTIVO FROM FOLIOS_VENTAS WHERE TIPO_DOCTO='R'"
                                Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla", Globales.basemicrosip)

                                If dsmicrosip.Tables("xtabla").Rows.Count > 0 Then
                                    FOLIO = (dsmicrosip.Tables("xtabla").Rows(0)("CONSECUTIVO"))
                                    txtfolio = "00000000 " & FOLIO
                                    FOLIO = txtfolio.Substring(Len(txtfolio) - 8, 8)
                                    Base.EjecutaMICROSIP("UPDATE FOLIOS_VENTAS SET CONSECUTIVO=CONSECUTIVO+1 WHERE TIPO_DOCTO='R' ", conmicrosip, Globales.basemicrosip)
                                End If
                                dsmicrosip.Tables.Remove("XTABLA")

                                SQL = "insert into doctos_ve (docto_ve_id,tipo_docto,subtipo_docto,sucursal_id,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen,usuario_creador,orden_compra" & IIf(Globales.VendedorID = -1, ")", ", vendedor_id) ") &
                                  " values (-1,'R','N'," & Globales.SUCMICRO & ",'" & FOLIO & "','" & Strings.Format(FECHA, "MM/dd/yyyy") & "','" & DSC4.Tables("cliente").Rows(0)("cliente_ID") & "'," &
                                  DSC4.Tables("cliente").Rows(0)("cliente_id") & "," &
                                  DSC4.Tables("cliente").Rows(0)("dir_cli_id") & "," &
                                  DSC4.Tables("cliente").Rows(0)("dir_cli_id") & ",19,1,1,'P','P','S',1,1,'N'," & Globales.condpago & ",'VE','" & Globales.usmicro & "','" & TEXTO & "'" & IIf(Globales.VendedorID = -1, ")", "," & Globales.VendedorID & ")")

                                Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

                                SQL = "select docto_ve_id siguiente from doctos_ve where almacen_id=19 and tipo_docto='R' and folio='" & FOLIO & "'"
                                Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla3", Globales.basemicrosip)
                                siguiente = dsmicrosip.Tables("xtabla3").Rows(0)("siguiente")
                                dsmicrosip.Tables.Remove("xtabla3")

                                If anterior <> 0 Then
                                    SQL = "UPDATE DOCTOS_VE SET IMPORTE_NETO=" & Math.Round(monto, 2) & ",TOTAL_IMPUESTOS=" & Math.Round(IVA, 2) & " WHERE DOCTO_VE_ID=" & anterior
                                    Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
                                    Base.EjecutaMICROSIP("EXECUTE PROCEDURE APLICA_DOCTO_VE " & anterior, conmicrosip, Globales.basemicrosip)
                                    monto = 0
                                    IVA = 0
                                End If
                                anterior = siguiente
                                control = 1
                            End If

                            ' Impuestos
                            Dim Impuesto, IVADeIEPS As Integer
                            Dim ValImp As Double
                            If CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) = 0 Then
                                If CDbl(DSC.Tables("TABLA").Rows(J)("ART_IEPS")) = 0 Then
                                    Impuesto = Globales.CVEEXCENTO
                                    ValImp = 0
                                    IVADeIEPS = 0
                                Else
                                    ValImp = CDbl(DSC.Tables("TABLA").Rows(J)("ART_IEPS"))
                                    IVADeIEPS = Globales.CVEEXCENTO
                                    Impuesto = Globales.CVEIMPUESTOIEPS
                                End If
                            Else
                                ValImp = CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA"))
                                IVADeIEPS = 0
                                Impuesto = Globales.CVEIMPUESTO
                            End If

                            ' Validación ID Articulo Microsip
                            If DSC.Tables("TABLA").Rows(J)("Art_CodRel") = "" Or MenoresBol = False Or DSC.Tables("TABLA").Rows(J)("DVE_Precio") < 2000 Then
                                CODIGO = ValidaArticuloMicrosip(DSC, Impuesto, J, Globales.basemicrosip, ValImp, IVADeIEPS)
                            Else
                                Dim DSC2 As New DataSet
                                SQL = "select * from Articulo where art_clave='" & DSC.Tables("TABLA").Rows(J)("ART_CODREL") & "'"
                                Base.daQuery(SQL, xcon, DSC2, "TABLA")
                                If DSC2.Tables("TABLA").Rows.Count > 0 Then
                                    CODIGO = ValidaArticuloMicrosip(DSC2, Impuesto, 0, Globales.basemicrosip, ValImp, IVADeIEPS)
                                End If
                                DSC2.Tables.Remove("TABLA")
                            End If

                            ' --------------------------------------------------------------------------------
                            ' CALCULO DE CANTIDADES UNIFICADO (El cambio fuerte)
                            ' --------------------------------------------------------------------------------
                            ' Siempre multiplicamos la cantidad por el Factor.
                            ' Si es caja (Factor 24), vendemos 24 unidades. Si es pieza (Factor 1), vendemos 1.
                            ' Esto permite que la lógica de "Menores" pueda partir la caja en unidades sueltas si es necesario.

                            CantidadArticulo = CDbl(DSC.Tables("TABLA").Rows(J)("Factor") * DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD"))
                            RestanteTotalArticulo = CDbl(DSC.Tables("TABLA").Rows(J)("DVE_TOTAL"))

                            ' Precio unitario de la pieza individual (Precio Venta / Factor)
                            Dim PrecioNeto As Double = CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO") / DSC.Tables("TABLA").Rows(J)("Factor"))

                            Dim PrecioSinImpuestos As Double
                            Dim FIVA, FIEPS As Double
                            FIVA = CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100.0
                            FIEPS = CDbl(DSC.Tables("TABLA").Rows(J)("ART_IEPS")) / 100.0
                            PrecioSinImpuestos = PrecioNeto / ((1 + FIVA) * (1 + FIEPS))

                            ' LOGICA DE DESGLOSE / PARTIDAS
                            If RemanenteFacturaPartida > RestanteTotalArticulo Or MenoresBol = False Then
                                ' CABE COMPLETO
                                SQL = "INSERT INTO DOCTOS_VE_DET ( DOCTO_VE_DET_ID,DOCTO_VE_ID,CLAVE_ARTICULO,ARTICULO_ID,UNIDADES,PRECIO_UNITARIO,PRECIO_TOTAL_NETO,POSICION) " &
                                  " VALUES ( -1," & siguiente & ",'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," &
                                  CODIGO & "," & CantidadArticulo & "," & PrecioSinImpuestos & "," &
                                  CantidadArticulo * PrecioSinImpuestos & "," & renglon & ")"

                                monto = monto + CantidadArticulo * PrecioSinImpuestos
                                IVA = IVA + CantidadArticulo * PrecioSinImpuestos * FIVA + CantidadArticulo * PrecioSinImpuestos * FIEPS

                                If MenoresBol Then
                                    ' Restamos del cupo de la factura usando el precio real por unidad * cantidad
                                    RemanenteFacturaPartida = RemanenteFacturaPartida - (CantidadArticulo * PrecioNeto)
                                    RestanteTotalArticulo = 0
                                    CantidadArticulo = 0
                                End If
                            Else
                                ' NO CABE COMPLETO - HAY QUE PARTIRLO
                                ' Verificamos si el precio unitario permite partición (menor a 2000)
                                If PrecioNeto < 2000 Then
                                    CuantosCaben = Math.Truncate((RemanenteFacturaPartida / PrecioNeto))
                                Else
                                    ' Si la unidad suelta vale más de 2000, no cabe nada. Forzamos cierre.
                                    CuantosCaben = 0
                                End If

                                If CuantosCaben <> 0 Then
                                    SQL = "INSERT INTO DOCTOS_VE_DET ( DOCTO_VE_DET_ID,DOCTO_VE_ID,CLAVE_ARTICULO,ARTICULO_ID,UNIDADES,PRECIO_UNITARIO,PRECIO_TOTAL_NETO,POSICION) " &
                                      " VALUES ( -1," & siguiente & ",'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," &
                                      CODIGO & "," & CuantosCaben & "," & PrecioSinImpuestos & "," &
                                      CuantosCaben * PrecioSinImpuestos & "," & renglon & ")"

                                    monto = monto + (CuantosCaben * PrecioSinImpuestos)
                                    IVA = IVA + (CuantosCaben * PrecioSinImpuestos * FIVA) + (CuantosCaben * PrecioSinImpuestos * FIEPS)

                                    RemanenteFacturaPartida = RemanenteFacturaPartida - (CuantosCaben * PrecioNeto)
                                    RestanteTotalArticulo = RestanteTotalArticulo - (CuantosCaben * PrecioNeto)
                                    CantidadArticulo = CantidadArticulo - CuantosCaben
                                Else
                                    ' No cupo ni uno, cerramos factura actual
                                    SQL = ""
                                    control = 0
                                    RemanenteFacturaPartida = 0
                                End If
                            End If

                            If SQL <> "" Then
                                renglon = renglon + 1
                                Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
                            End If

                            ' Si se llenó la factura, forzamos cierre para abrir nueva
                            If RemanenteFacturaPartida <= 0 And MenoresBol Then
                                control = 0
                                RemanenteFacturaPartida = 2000
                            End If

                            ' Si ya terminamos con este artículo, pasamos al siguiente
                            If RestanteTotalArticulo <= 0 Then
                                If J = DSC.Tables("TABLA").Rows.Count - 1 Then
                                    ' Era el último, cerramos todo
                                    SQL = "UPDATE DOCTOS_VE SET IMPORTE_NETO=" & monto.ToString & ",TOTAL_IMPUESTOS=" & IVA.ToString & " WHERE DOCTO_VE_ID=" & siguiente
                                    Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
                                    Base.EjecutaMICROSIP("EXECUTE PROCEDURE APLICA_DOCTO_VE " & siguiente, conmicrosip, Globales.basemicrosip)
                                    Exit While
                                Else
                                    ' Hay más artículos, pero si el siguiente tiene cantidad 0 (raro), cerramos.
                                    If (J + 1 = DSC.Tables("TABLA").Rows.Count - 1 And CDbl(DSC.Tables("TABLA").Rows(J + 1)("DVE_CANTIDAD")) <= 0) Then
                                        SQL = "UPDATE DOCTOS_VE SET IMPORTE_NETO=" & monto.ToString & ",TOTAL_IMPUESTOS=" & IVA.ToString & " WHERE DOCTO_VE_ID=" & siguiente
                                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
                                        Base.EjecutaMICROSIP("EXECUTE PROCEDURE APLICA_DOCTO_VE " & siguiente, conmicrosip, Globales.basemicrosip)
                                        Exit While
                                    Else
                                        ' Avanzamos al siguiente artículo
                                        J = J + 1
                                        If MenoresBol Then
                                            If (CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) > 0) = False Then
                                                J += 1
                                            End If
                                            ' Revisión de seguridad repetida para el siguiente item
                                            If DSC.Tables("TABLA").Rows(J)("DVE_PRECIO") >= 2000 AndAlso CDbl(DSC.Tables("TABLA").Rows(J)("Factor")) = 1 Then
                                                If DSC.Tables("TABLA").Rows(J)("art_codrel") = "" Then
                                                    Errores = True
                                                    MsgBox("Uno o más productos no pueden facturarse por exceder los $2,000. Borre la remisión en Microsip.", vbExclamation, "Facturación de Tickets")
                                                    Me.Close()
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End While
                        DSC.Tables.Remove("TABLA")
                    End If
                    dsmicrosip.Tables.Remove("ExisteMicrosip")
                End If
                DSC.Tables.Remove("Existe")
            Next f

            If Not Errores Then
                MsgBox("Proceso Realizado correctamente", MsgBoxStyle.Information, "Facturación de Tickets")
                FpTickets.ActiveSheet.ActiveRowIndex = 0
                FpTickets.ActiveSheet.ActiveColumnIndex = 0
                FpTickets.Focus()
                Me.Close()
                Exit Sub
            End If
        End If
    End Sub


    Private Sub generaentera()
        Dim SQL As String
        Dim DSC As New DataSet
        Dim J As Integer
        Dim dsmicrosip As New DataSet
        Dim IVA As Double
        Dim FOLIO As String
        Dim monto As Double
        Dim renglon As Integer
        Dim CODIGO As Integer
        Dim control As Integer
        Dim TXTFECHA As String
        Dim FECHA As Date
        Dim siguiente As Integer
        Dim txtfolio As String
        Dim pro As String
        Dim DSC4 As New DataSet

        pro = CmbCliente.SelectedItem()
        pro = pro.Substring(0, 7)

        Base.daQueryMICROSIP("select a.cliente_id,b.clave_cliente,c.dir_cli_id from clientes a inner join claves_clientes b on a.cliente_id=b.cliente_id inner join dirs_clientes c on a.cliente_id=c.cliente_id  where a.cliente_id=" & pro, conmicrosip, DSC4, "CLIENTE", Globales.basemicrosip)
        If DSC4.Tables("CLIENTE").Rows.Count <= 0 Then
            MsgBox("proveedor interno " & pro, MsgBoxStyle.Exclamation)
            MsgBox("Debe de indicar el cliente para el que va a generar la factura", MsgBoxStyle.Information)
        Else
            FOLIO = ""
            FECHA = Today.Date
            TXTFECHA = ("0" & FECHA.Month.ToString).Substring(Len(("0" & FECHA.Month.ToString)) - 2, 2) & "/" & ("0" & FECHA.Day.ToString).Substring(Len(("0" & FECHA.Day.ToString)) - 2, 2) & "/" & FECHA.Year.ToString
            siguiente = 0
            IVA = 0
            monto = 0
            control = 0
            renglon = 1
            Dim i As Integer

            For i = 0 To FpTickets.ActiveSheet.RowCount - 1

                If FpTickets.ActiveSheet.Cells(i, 0).Text <> "" Then

                    If control = 0 Then


                        SQL = " SELECT CONSECUTIVO  FROM FOLIOS_VENTAS  WHERE TIPO_DOCTO='R'"

                        Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla", Globales.basemicrosip)

                        If dsmicrosip.Tables("xtabla").Rows.Count > 0 Then

                            FOLIO = (dsmicrosip.Tables("xtabla").Rows(0)("CONSECUTIVO"))
                            txtfolio = "00000000 " & FOLIO

                            FOLIO = txtfolio.Substring(Len(txtfolio) - 8, 8)

                            Base.EjecutaMICROSIP("UPDATE FOLIOS_VENTAS  SET CONSECUTIVO=CONSECUTIVO+1 WHERE TIPO_DOCTO='R' ", conmicrosip, Globales.basemicrosip)

                        End If
                        dsmicrosip.Tables.Remove("XTABLA")
                        '  SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " & _
                        '       " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','001',28433,28435,28435,19,1,1,'P','P','S',1,1,'N',287,'VE')"


                        '' duarsa1

                        'SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen) " &
                        '    " values (-1,'R','N','" & FOLIO & "','" & TXTFECHA & "','" & DSC4.Tables("cliente").Rows(0)("clave_cliente") & "'," &
                        '    DSC4.Tables("cliente").Rows(0)("cliente_id") & "," &
                        '    DSC4.Tables("cliente").Rows(0)("dir_cli_id") & "," &
                        '    DSC4.Tables("cliente").Rows(0)("dir_cli_id") & ",19,1,1,'P','P','S',1,1,'N',2780,'VE')"

                        '                        '' duarsa2

                        SQL = "insert into doctos_ve ( docto_ve_id,tipo_docto,subtipo_docto,sucursal_id,folio,FECHA,clave_cliente,cliente_id,dir_cli_id,dir_consig_id,almacen_id,moneda_id,tipo_cambio,tipo_dscto,estatus,aplicado,importe_neto,total_impuestos,forma_emitida,cond_pago_id,sistema_origen,usuario_creador" & IIf(Globales.VendedorID = -1, ")", ", vendedor_id) ") &
                            " values (-1,'R','N'," & Globales.SUCMICRO & ",'" & FOLIO & "','" & TXTFECHA & "','" & DSC4.Tables("cliente").Rows(0)("clave_cliente") & "'," &
                            DSC4.Tables("cliente").Rows(0)("cliente_id") & "," &
                            DSC4.Tables("cliente").Rows(0)("dir_cli_id") & "," &
                            DSC4.Tables("cliente").Rows(0)("dir_cli_id") & ",19,1,1,'P','P','S',1,1,'N'," & Globales.condpago & ",'VE','" & Globales.usmicro & "'" & IIf(Globales.VendedorID = -1, ")", "," & Globales.VendedorID & ")")


                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

                        MsgBox("DOS")
                        SQL = "select docto_ve_id siguiente from doctos_ve where almacen_id=19 and tipo_docto='R'  and folio='" & FOLIO & "'"

                        ' sql = " Select  max(docto_IN_id) siguiente from doctos_in "
                        Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "xtabla3", Globales.basemicrosip)

                        siguiente = dsmicrosip.Tables("xtabla3").Rows(0)("siguiente")


                        dsmicrosip.Tables.Remove("xtabla3")
                        control = 1
                    End If

                    SQL = "SELECT * FROM ECDETVENTA  inner join articulo on art_clave=dve_articulo where DVE_VENTA=" & FpTickets.ActiveSheet.Cells(i, 0).Text & " order by dve_renglon"
                    Base.daQuery(SQL, xcon, DSC, "TABLA")

                    For J = 0 To DSC.Tables("TABLA").Rows.Count - 1
                        '--------------------------------------------------------------------------------
                        '  ----------------PARA VERIFICAR QUE EXISTA EL ARTICULO SI NO EXISTIO LO INSERTO

                        SQL = "SELECT ARTICULO_ID FROM CLAVES_ARTICULOS WHERE CLAVE_ARTICULO='" & DSC.Tables("TABLA").Rows(J)("DVE_ARTICULO") & "'"
                        Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "TABLAM", Globales.basemicrosip)
                        If dsmicrosip.Tables("TABLAM").Rows.Count <= 0 Then
                            MsgBox("no existe el articulo", MsgBoxStyle.Exclamation)

                            SQL = "INSERT INTO ARTICULOS (ARTICULO_ID,NOMBRE,ES_ALMACENABLE,ES_JUEGO,ESTATUS,UNIDAD_VENTA,UNIDAD_COMPRA,CONTENIDO_UNIDAD_COMPRA) " &
                                " VALUES (-1,'" & DSC.Tables("TABLA").Rows(J)("ART_NOMLARGO") & "','S','N','A','" &
                                DSC.Tables("TABLA").Rows(J)("ART_UNI2") & "','" &
                                DSC.Tables("TABLA").Rows(J)("ART_UNI1") & "'," &
                            DSC.Tables("TABLA").Rows(J)("ART_CAP2") & ")"
                            Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
                            MsgBox("inserte en articulos", MsgBoxStyle.Exclamation)

                            SQL = "SELECT ARTICULO_ID FROM ARTICULOS WHERE NOMBRE ='" & DSC.Tables("TABLA").Rows(J)("ART_NOMLARGO") & "'"
                            Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "TABLAM2", Globales.basemicrosip)
                            If dsmicrosip.Tables("TABLAM2").Rows.Count > 0 Then
                                CODIGO = dsmicrosip.Tables("TABLAM2").Rows(0)("ARTICULO_ID")
                            Else
                                MsgBox("ERROR NO SE INSERTO EL REGISTRO ", MsgBoxStyle.Exclamation)
                                CODIGO = 0
                            End If
                            dsmicrosip.Tables.Remove("TABLAM2")

                            Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

                            SQL = "INSERT INTO CLAVES_ARTICULOS (CLAVE_ARTICULO_ID,CLAVE_ARTICULO,ARTICULO_ID,ROL_CLAVE_ART_ID) VALUES " &
                                "(-1,'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," &
                             CODIGO & ",17)"
                            Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
                            MsgBox("inserte en clavesarticulos", MsgBoxStyle.Exclamation)

                            SQL = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," &
                                CODIGO & "," & IIf(CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) = 0, Globales.CVEEXCENTO, Globales.CVEIMPUESTO) & ")"
                            Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)
                            MsgBox("inserte en impuestos", MsgBoxStyle.Exclamation)

                        Else
                            CODIGO = dsmicrosip.Tables("TABLAM").Rows(0)("ARTICULO_ID")
                        End If
                        dsmicrosip.Tables.Remove("TABLAM")


                        '--------------------------------------------------------------------------------------------------------------
                        SQL = "INSERT INTO DOCTOS_VE_DET ( DOCTO_VE_DET_ID,DOCTO_VE_ID,CLAVE_ARTICULO,ARTICULO_ID,UNIDADES,PRECIO_UNITARIO,PRECIO_TOTAL_NETO,POSICION) " &
                            " VALUES ( -1," &
                            siguiente & "," &
                            "'" & DSC.Tables("TABLA").Rows(J)("ART_CLAVE") & "'," &
                            CODIGO & "," &
                           CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) & "," &
                            Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2) & "," &
                        CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2) & "," &
                        renglon & ")"

                        Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

                        monto = monto + CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2)
                        IVA = IVA + (CDbl(DSC.Tables("TABLA").Rows(J)("DVE_CANTIDAD")) * Math.Round(CDbl(DSC.Tables("TABLA").Rows(J)("DVE_PRECIO")) / (1 + (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)), 2)) * (CDbl(DSC.Tables("TABLA").Rows(J)("ART_IVA")) / 100)
                        renglon = renglon + 1
                    Next J
                    DSC.Tables.Remove("TABLA")
                End If


            Next i


            SQL = "UPDATE DOCTOS_VE SET IMPORTE_NETO=" & monto.ToString & ",TOTAL_IMPUESTOS=" & IVA.ToString & " WHERE DOCTO_VE_ID=" & siguiente
            Base.EjecutaMICROSIP(SQL, conmicrosip, Globales.basemicrosip)

            Base.EjecutaMICROSIP("EXECUTE PROCEDURE  APLICA_DOCTO_VE " & siguiente, conmicrosip, Globales.basemicrosip)
            MsgBox(" GENERACION DE VENTA PARA FACTURACION EN MICROSIP REALIZADA CORRECTAMENTE", MsgBoxStyle.Exclamation)


            FpTickets.ActiveSheet.RowCount = 0
            FpTickets.ActiveSheet.RowCount = 1
        End If
        DSC4.Tables.Remove("cliente")




    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInicializar.Click
        FpTickets.ActiveSheet.RowCount = 0
        FpTickets.ActiveSheet.RowCount = FpTickets.ActiveSheet.RowCount + 1

    End Sub

    Private Function HayFacturas(ByVal ClienteID As Integer) As Boolean
        Dim SQl As String

        Dim DSMicrosip As New DataSet
        Dim Fecha As Date
        Dim DSC As New DataSet

        Dim FPago As String = ""

        For i As Integer = 0 To FpTickets.ActiveSheet.RowCount - 1
            If FpTickets.ActiveSheet.Cells(i, 0).Text <> "" Then
                If IsNumeric(FpTickets.ActiveSheet.Cells(i, 0).Text) Then
                    If FPago <> FpTickets.ActiveSheet.Cells(i, 7).Text AndAlso FPago <> "" Then
                        MsgBox("No puede facturar varios tickets con distintas formas de pago.", vbInformation, "Facturación de Tickets")
                        Return False
                    Else
                        FPago = FpTickets.ActiveSheet.Cells(i, 7).Text
                    End If
                End If
            End If
        Next i

        Base.daQueryMICROSIP("select clave_fiscal from formas_cobro_cc where CLAVE_FISCAL='" & FPago & "' and UPPER(nombre) <>'TRANSFERENCIA'", conmicrosip, DSC, "FormaPago", Globales.basemicrosip)
        Dim UltPagoUtilizado As String = ""
        Dim PagoID As String = ""
        If DSC.Tables("FormaPago").Rows.Count > 0 Then
            PagoID = DSC.Tables("FormaPago").Rows(0)("clave_fiscal")
            Base.daQueryMICROSIP("select f.CLAVE_FISCAL UltUtilizada from formas_cobro_clientes c join formas_cobro_cc f on c.FORMA_COBRO_ID=f.forma_cobro_cc_id where cliente_id=" & ClienteID & " and UPPER(nombre) <>'TRANSFERENCIA' and ult_utilizada='S'", conmicrosip, DSC, "Existe", Globales.basemicrosip)
            If DSC.Tables("Existe").Rows.Count > 0 Then
                UltPagoUtilizado = (DSC.Tables("existe").Rows(0)("UltUtilizada"))
            End If
            DSC.Tables.Remove("Existe")
        Else
            MsgBox("Al facturar la remisión, deberá elegir la forma de pago correcta.", vbInformation, "Facturación de Tickets")
        End If
        DSC.Tables.Remove("FormaPago")


        SQl = "SELECT count(*) Cuantos FROM DOCTOS_VE A INNER JOIN LIBRES_FAC_VE C ON A.DOCTO_VE_ID=C.DOCTO_VE_ID WHERE cliente_id=" & ClienteID & " and fecha_hora_cancelacion is null and (TIPO_DOCTO='F' AND ESTATUS='N' and cfdi_certificado='N')"
        Base.daQueryMICROSIP(SQl, conmicrosip, DSMicrosip, "Facturas", Globales.basemicrosip)

        SQl = "select count(*) Cuantos from doctos_ve WHERE cliente_id=" & ClienteID & " and fecha_hora_cancelacion is null and (TIPO_DOCTO='R' AND ESTATUS='P')"
        Base.daQueryMICROSIP(SQl, conmicrosip, DSMicrosip, "Remisiones", Globales.basemicrosip)
        If DSMicrosip.Tables("Facturas").Rows.Count > 0 Then
            If DSMicrosip.Tables("Facturas").Rows(0)("Cuantos") > 0 AndAlso (UltPagoUtilizado = "" OrElse UltPagoUtilizado <> PagoID) Then
                MsgBox("Existen Facturas pendientes por timbrar del cliente y tienen diferente Forma de Pago.", vbExclamation, "Facturación de Tickets")
                Return True
            End If
        End If
        DSMicrosip.Tables.Remove("Facturas")

        If DSMicrosip.Tables("Remisiones").Rows.Count > 0 Then
            If DSMicrosip.Tables("Remisiones").Rows(0)("Cuantos") > 0 AndAlso (UltPagoUtilizado = "" OrElse UltPagoUtilizado <> PagoID) Then
                MsgBox("Existen Remisiones pendientes por facturar del cliente  y tienen diferente Forma de Pago.", vbExclamation, "Facturación de Tickets")
                Return True
            End If
        End If

        DSMicrosip.Tables.Remove("Remisiones")

        Return False
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
        Dim Tarjetas As Boolean = Nothing
        Dim Uso As Boolean = Nothing
        Dim Regimen As Boolean = Nothing

        If HayFacturas(CmbCliente.SelectedItem().ToString.Substring(0, 7)) Then
            Exit Sub
        End If

        Dim SQL As String = "select coalesce(d.CLAVE_REGIMEN_FISCAL,'') RegimenFiscal from dirs_clientes d right join clientes c on c.CLIENTE_ID=d.cliente_id where clave_regimen_fiscal is not null and c.cliente_id=" & CmbCliente.SelectedItem().ToString.Substring(0, 7)
        Dim DSC As New DataSet
        Base.daQueryMICROSIP(SQL, conmicrosip, DSC, "Regimen", Globales.basemicrosip)
        If DSC.Tables("Regimen").Rows.Count > 0 Then
            If DSC.Tables("Regimen").Rows(0)("RegimenFiscal") = "" Then
                MsgBox("Debe especificar el regimen fiscal del cliente. Dar de alta en Microsip.", vbExclamation, "Facturación de Tickets")
                Regimen = False
            Else
                Regimen = True
            End If
        Else
            MsgBox("Debe especificar el regimen fiscal del cliente." & Chr(13) & Chr(13) & "Dar de alta en Microsip.", vbExclamation, "Facturación de Tickets")
            Regimen = False
        End If
        DSC.Tables.Remove("Regimen")

        For i As Integer = 0 To FpTickets.ActiveSheet.RowCount - 1
            If FpTickets.ActiveSheet.Cells(i, 7).Text <> "" Then
                If FpTickets.ActiveSheet.Cells(i, 7).Text <> "-1" Then
                    Tarjetas = True
                Else
                    Tarjetas = False
                    Exit For
                End If

                Uso = True
                If False Then
                    If ObtenerUsoCFDI(FpTickets.ActiveSheet.Cells(i, 9).Text) = " " Then
                        Uso = False
                        MsgBox("Especifique el Uso del CFDI del Ticket #" & FpTickets.ActiveSheet.Cells(i, 0).Text, vbExclamation, "Facturación de Tickets")
                        Exit For
                    Else
                        Uso = True
                    End If
                End If

            End If
        Next
        If Tarjetas And Uso And Regimen Then
            Call generaparciales()
        End If

        'If Chk_menores.Checked Then
        '    generaparciales()
        'Else
        '    'generaentera()
        '    generaparciales()
        'End If
    End Sub

    Private Function ValidaArticuloMicrosip(DSC As DataSet, Impuesto As Integer, I As Integer, StrBaseMicrosip As String, ValorImpuesto As Double, IVADeIEPS As Integer)
        Dim SQL As String
        Dim dsmicrosip As New DataSet
        Dim Codigo As Integer

        SQL = "SELECT ARTICULO_ID FROM CLAVES_ARTICULOS WHERE CLAVE_ARTICULO='" & DSC.Tables("TABLA").Rows(I)("art_clave") & "'"
        Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "CODIGO", StrBaseMicrosip)
        If dsmicrosip.Tables("CODIGO").Rows.Count <= 0 Then
            MsgBox(DSC.Tables("TABLA").Rows(I)("ART_NOMLARGO") & " no existe en catálogo de artículos, se agregará.", MsgBoxStyle.Information, "Envío de Remisión")

            SQL = "SELECT * FROM articulos WHERE upper(nombre)='" & DSC.Tables("TABLA").Rows(I)("ART_NOMLARGO") & "'"
            Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "ARTICULOS", StrBaseMicrosip)

            If dsmicrosip.Tables("ARTICULOS").Rows.Count > 0 Then
                Codigo = dsmicrosip.Tables("ARTICULOS").Rows(0)("ARTiculo_ID")
                SQL = "update articulos set UNIDAD_VENTA='" & DSC.Tables("TABLA").Rows(I)("ART_UNI2") & "',UNIDAD_COMPRA='" & DSC.Tables("TABLA").Rows(I)("ART_UNI1") & "', CONTENIDO_UNIDAD_COMPRA='" & DSC.Tables("TABLA").Rows(I)("ART_CAP2") & "' where articulo_id='" & Codigo & "' "
                Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
            Else
                SQL = "INSERT INTO ARTICULOS (ARTICULO_ID, NOMBRE, ES_ALMACENABLE, ES_JUEGO, ESTATUS, UNIDAD_VENTA, UNIDAD_COMPRA, CONTENIDO_UNIDAD_COMPRA) " &
                                            " VALUES (-1,'" & DSC.Tables("TABLA").Rows(I)("ART_NOMLARGO") & "','S','N','A','" &
                                            DSC.Tables("TABLA").Rows(I)("ART_UNI2") & "','" &
                                            DSC.Tables("TABLA").Rows(I)("ART_UNI1") & "'," &
                                        DSC.Tables("TABLA").Rows(I)("ART_CAP2") & ")"
                Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)

                SQL = "SELECT ARTICULO_ID FROM ARTICULOS WHERE NOMBRE ='" & DSC.Tables("TABLA").Rows(I)("ART_NOMLARGO") & "'"
                Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "TABLAM3", StrBaseMicrosip)
                If dsmicrosip.Tables("TABLAM3").Rows.Count > 0 Then
                    Codigo = dsmicrosip.Tables("TABLAM3").Rows(0)("ARTICULO_ID")
                End If
                dsmicrosip.Tables.Remove("TABLAM3")
            End If
            dsmicrosip.Tables.Remove("ARTICULOS")

            SQL = "select*from claves_articulos where ARTICULO_ID='" & Codigo & "'"
            Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "CLAVES", StrBaseMicrosip)
            If dsmicrosip.Tables("CLAVES").Rows.Count > 0 Then
                If dsmicrosip.Tables("CLAVES").Rows.Count = 1 Then
                    If dsmicrosip.Tables("CLAVES").Rows(0)("CLAVE_ARTICULO") <> DSC.Tables("TABLA").Rows(I)("ART_CLAVE") Then
                        SQL = "update claves_articulos set CLAVE_ARTICULO='" & DSC.Tables("TABLA").Rows(I)("ART_CLAVE") & "', ROL_CLAVE_ART_ID=17 where ARTICULO_ID='" & Codigo & "'"
                        Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                    Else
                        If dsmicrosip.Tables("CLAVES").Rows(0)("ROL_CLAVE_ART_ID") <> 17 Then
                            SQL = "update claves_articulos set ROL_CLAVE_ART_ID=17 where ARTICULO_ID='" & Codigo & "'"
                            Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                        End If
                    End If
                Else
                    SQL = "delete from claves_articulos where ARTICULO_ID='" & Codigo & "'"
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)

                    SQL = "INSERT INTO CLAVES_ARTICULOS (CLAVE_ARTICULO_ID,CLAVE_ARTICULO,ARTICULO_ID,ROL_CLAVE_ART_ID) VALUES " &
                                        "(-1,'" & DSC.Tables("TABLA").Rows(I)("ART_CLAVE") & "'," &
                                        Codigo & ",17)"
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                End If
            Else
                SQL = "INSERT INTO CLAVES_ARTICULOS (CLAVE_ARTICULO_ID,CLAVE_ARTICULO,ARTICULO_ID,ROL_CLAVE_ART_ID) VALUES " &
                                        "(-1,'" & DSC.Tables("TABLA").Rows(I)("ART_CLAVE") & "'," &
                                        Codigo & ",17)"
                Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
            End If
            dsmicrosip.Tables.Remove("CLAVES")

            SQL = "select*from datos_adicionales where Elem_ID='" & Codigo & "'"
            Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "CLAVES", StrBaseMicrosip)
            If dsmicrosip.Tables("CLAVES").Rows.Count > 0 Then
                If Not IsDBNull(dsmicrosip.Tables("Claves").Rows(0)("CLAVE")) Then
                    If DSC.Tables("TABLA").Rows(I)("art_CveSat").ToString.ToUpper <> dsmicrosip.Tables("Claves").Rows(0)("CLAVE").ToString.ToUpper Then
                        Dim SQLClaveSAT As String
                        SQLClaveSAT = "update datos_adicionales set Clave='" & DSC.Tables("TABLA").Rows(I)("art_CveSat").ToString.ToUpper & "' where elem_id=" & Codigo
                        Base.EjecutaMICROSIP(SQLClaveSAT, conmicrosip, StrBaseMicrosip)
                    End If
                Else
                    Dim SQLClaveSAT As String
                    SQLClaveSAT = "insert into datos_adicionales values(-1,'ARTICULOS'," & Codigo & ",2,'" & DSC.Tables("TABLA").Rows(I)("art_CveSat").ToString.ToUpper & "','')"
                    Base.EjecutaMICROSIP(SQLClaveSAT, conmicrosip, StrBaseMicrosip)
                End If
            Else
                Dim SQLClaveSAT As String
                SQLClaveSAT = "insert into datos_adicionales values(-1,'ARTICULOS'," & Codigo & ",2,'" & DSC.Tables("TABLA").Rows(I)("art_CveSat").ToString.ToUpper & "','')"
                Base.EjecutaMICROSIP(SQLClaveSAT, conmicrosip, StrBaseMicrosip)
            End If
            dsmicrosip.Tables.Remove("CLAVES")


            SQL = "select*from IMPUESTOS_ARTICULOS where ARTICULO_ID='" & Codigo & "'"
            Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "IMPUESTOS", StrBaseMicrosip)
            If dsmicrosip.Tables("IMPUESTOS").Rows.Count > 0 Then
                If dsmicrosip.Tables("IMPUESTOS").Rows.Count = 1 Then
                    SQL = "update IMPUESTOS_ARTICULOS set IMPUESTO_ID='" & Impuesto & "' where ARTICULO_ID='" & Codigo & "'"
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                Else
                    SQL = "delete from IMPUESTOS_ARTICULOS where ARTICULO_ID='" & Codigo & "'"
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)

                    SQL = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," &
            Codigo & "," & Impuesto & ")"
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                End If
            Else
                SQL = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," &
            Codigo & "," & Impuesto & ")"
                Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
            End If

            If ValorImpuesto > 0 And IVADeIEPS > 0 Then
                SQL = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," & Codigo & "," & IVADeIEPS & ")"
                Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
            End If
            dsmicrosip.Tables.Remove("IMPUESTOS")
        Else
            SQL = "select*from articulos join claves_articulos c on c.articulo_id=articulos.articulo_id where upper(nombre)='" & DSC.Tables("TABLA").Rows(I)("art_nomlargo").ToString.ToUpper & "'"
            Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "DescExis", StrBaseMicrosip)
            If dsmicrosip.Tables("DescExis").Rows.Count <> 0 Then
                Dim u As Integer
                If dsmicrosip.Tables("DescExis").Rows(0)("articulo_id") <> dsmicrosip.Tables("CODIGO").Rows(0)("ARTICULO_ID") Then

                    SQL = "update articulos set nombre=nombre || '-ANT' where articulo_id=" & dsmicrosip.Tables("DescExis").Rows(0)("articulo_id")
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                    'falta insertart
                End If
            End If
            dsmicrosip.Tables.Remove("DescExis")

            Codigo = dsmicrosip.Tables("CODIGO").Rows(0)("ARTICULO_ID")
            SQL = "SELECT A.*, C.*, I.*, CL.* FROM ARTICULOS A LEFT JOIN DATOS_ADICIONALES C ON A.ARTICULO_ID=C.ELEM_ID left JOIN IMPUESTOS_ARTICULOS I ON A.ARTICULO_ID=I.ARTICULO_ID left join CLAVES_ARTICULOS CL on A.ARTICULO_ID=CL.ARTICULO_ID where A.ARTICULO_ID=" & Codigo
            Base.daQueryMICROSIP(SQL, conmicrosip, dsmicrosip, "DescExis", StrBaseMicrosip)

            If dsmicrosip.Tables("DescExis").Rows.Count <> 0 Then
                Dim Entre As Boolean = False
                SQL = "update articulos "
                If DSC.Tables("TABLA").Rows(I)("art_nomlargo").ToString.ToUpper <> dsmicrosip.Tables("DescExis").Rows(0)("nombre").ToString.ToUpper Then
                    SQL = SQL & IIf(Entre = False, "set ", ", ") & "nombre='" & DSC.Tables("TABLA").Rows(I)("art_nomlargo").ToString.ToUpper & "'"
                    Entre = True
                End If

                If DSC.Tables("TABLA").Rows(I)("ART_UNI2").ToString.ToUpper <> dsmicrosip.Tables("DescExis").Rows(0)("UNIDAD_VENTA").ToString.ToUpper Then
                    SQL = SQL & IIf(Entre = False, "set ", ", ") & "UNIDAD_VENTA='" & DSC.Tables("TABLA").Rows(I)("ART_UNI2").ToString.ToUpper & "'"
                    Entre = True
                End If

                If DSC.Tables("TABLA").Rows(I)("ART_UNI1").ToString.ToUpper <> dsmicrosip.Tables("DescExis").Rows(0)("UNIDAD_COMPRA").ToString.ToUpper Then
                    SQL = SQL & IIf(Entre = False, "set ", ", ") & "UNIDAD_COMPRA='" & DSC.Tables("TABLA").Rows(I)("ART_UNI1").ToString.ToUpper & "'"
                    Entre = True
                End If

                If DSC.Tables("TABLA").Rows(I)("ART_CAP2").ToString.ToUpper <> dsmicrosip.Tables("DescExis").Rows(0)("CONTENIDO_UNIDAD_COMPRA").ToString.ToUpper Then
                    SQL = SQL & IIf(Entre = False, "set ", ", ") & "CONTENIDO_UNIDAD_COMPRA=" & CDbl(DSC.Tables("TABLA").Rows(I)("ART_CAP2"))
                    Entre = True
                End If

                If Entre Then
                    SQL = SQL & " where articulo_id='" & dsmicrosip.Tables("DescExis").Rows(0)("articulo_id") & "'"
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                End If

                If Not IsDBNull(dsmicrosip.Tables("DescExis").Rows(0)("CLAVE")) Then
                    If DSC.Tables("TABLA").Rows(I)("art_CveSat").ToString.ToUpper <> dsmicrosip.Tables("DescExis").Rows(0)("CLAVE").ToString.ToUpper Then
                        Dim SQLClaveSAT As String
                        SQLClaveSAT = "update datos_adicionales set Clave='" & DSC.Tables("TABLA").Rows(I)("art_CveSat").ToString.ToUpper & "' where elem_id=" & Codigo
                        Base.EjecutaMICROSIP(SQLClaveSAT, conmicrosip, StrBaseMicrosip)
                    End If
                Else
                    Dim SQLClaveSAT As String
                    SQLClaveSAT = "insert into datos_adicionales values(-1,'ARTICULOS'," & Codigo & ",2,'" & DSC.Tables("TABLA").Rows(I)("art_CveSat").ToString.ToUpper & "','')"
                    Base.EjecutaMICROSIP(SQLClaveSAT, conmicrosip, StrBaseMicrosip)
                End If

                Dim SQLClave As String
                If Not IsDBNull(dsmicrosip.Tables("DescExis").Rows(0)("CLAVE_ARTICULO")) Then
                    If DSC.Tables("TABLA").Rows(I)("ART_CLAVE").ToString <> dsmicrosip.Tables("DescExis").Rows(0)("CLAVE_ARTICULO").ToString And dsmicrosip.Tables("DescExis").Rows.Count = 1 Then
                        SQLClave = "update CLAVES_ARTICULOS set CLAVE_ARTICULO='" & DSC.Tables("TABLA").Rows(I)("ART_CLAVE") & "', rol_clave_art_id=17 where ARTICULO_ID='" & Codigo & "'"
                        Base.EjecutaMICROSIP(SQLClave, conmicrosip, StrBaseMicrosip)
                    ElseIf DSC.Tables("TABLA").Rows(I)("ART_CLAVE").ToString = dsmicrosip.Tables("DescExis").Rows(0)("CLAVE_ARTICULO").ToString And dsmicrosip.Tables("DescExis").Rows(0)("rol_clave_art_id") <> 17 And dsmicrosip.Tables("DescExis").Rows.Count = 1 Then
                        SQLClave = "update CLAVES_ARTICULOS set rol_clave_art_id=17 where ARTICULO_ID='" & Codigo & "'"
                        Base.EjecutaMICROSIP(SQLClave, conmicrosip, StrBaseMicrosip)
                    ElseIf dsmicrosip.Tables("DescExis").Rows.Count > 1 Then
                        SQLClave = "delete from CLAVES_ARTICULOS where articulo_id=" & Codigo
                        Base.EjecutaMICROSIP(SQLClave, conmicrosip, StrBaseMicrosip)

                        SQLClave = "INSERT INTO CLAVES_ARTICULOS (CLAVE_ARTICULO_ID,CLAVE_ARTICULO,ARTICULO_ID,ROL_CLAVE_ART_ID) VALUES (-1,'" & DSC.Tables("TABLA").Rows(I)("ART_CLAVE") & "'," & Codigo & ",17)"
                        Base.EjecutaMICROSIP(SQLClave, conmicrosip, StrBaseMicrosip)
                    End If
                Else
                    SQLClave = "delete from CLAVES_ARTICULOS where articulo_id=" & Codigo
                    Base.EjecutaMICROSIP(SQLClave, conmicrosip, StrBaseMicrosip)

                    SQLClave = "insert into claves_articulos (CLAVE_ARTICULO_ID, CLAVE_ARTICULO, ARTICULO_ID, ROL_CLAVE_ART_ID) VALUES (-1,'" & DSC.Tables("TABLA").Rows(I)("ART_CLAVE").ToString & "'," & Codigo & ",17)"
                    Base.EjecutaMICROSIP(SQLClave, conmicrosip, StrBaseMicrosip)
                End If

                Dim SQLImpuesto As String
                If Not IsDBNull(dsmicrosip.Tables("DescExis").Rows(0)("IMPUESTO_ID")) Then
                    If Impuesto <> CDbl(dsmicrosip.Tables("DescExis").Rows(0)("IMPUESTO_ID")) And dsmicrosip.Tables("DescExis").Rows.Count = 1 Then
                        SQLImpuesto = "update IMPUESTOS_ARTICULOS set IMPUESTO_ID=" & Impuesto & " where ARTICULO_ID='" & Codigo & "'"
                        Base.EjecutaMICROSIP(SQLImpuesto, conmicrosip, StrBaseMicrosip)
                    ElseIf dsmicrosip.Tables("DescExis").Rows.Count > 1 Then
                        SQLImpuesto = "delete from IMPUESTOS_ARTICULOS where articulo_id=" & Codigo
                        Base.EjecutaMICROSIP(SQLImpuesto, conmicrosip, StrBaseMicrosip)

                        SQLImpuesto = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," & Codigo & "," & Impuesto & ")"
                        Base.EjecutaMICROSIP(SQLImpuesto, conmicrosip, StrBaseMicrosip)
                    End If
                Else
                    SQLImpuesto = "delete from IMPUESTOS_ARTICULOS where articulo_id=" & Codigo
                    Base.EjecutaMICROSIP(SQLImpuesto, conmicrosip, StrBaseMicrosip)

                    SQLImpuesto = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," & Codigo & "," & Impuesto & ")"
                    Base.EjecutaMICROSIP(SQLImpuesto, conmicrosip, StrBaseMicrosip)
                End If

                If ValorImpuesto > 0 And IVADeIEPS > 0 Then
                    SQL = "INSERT INTO IMPUESTOS_ARTICULOS (IMPUESTO_ART_ID,ARTICULO_ID,IMPUESTO_ID) VALUES (-1," & Codigo & "," & IVADeIEPS & ")"
                    Base.EjecutaMICROSIP(SQL, conmicrosip, StrBaseMicrosip)
                End If
            End If
            dsmicrosip.Tables.Remove("DescExis")
        End If
        dsmicrosip.Tables.Remove("CODIGO")
        Return Codigo
    End Function

    Private Sub TxtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            FpTickets.ActiveSheet.ActiveColumnIndex = 0
            FpTickets.ActiveSheet.ActiveRowIndex = 0
            FpTickets.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            If TxtFiltro.Text = "" Then
                Me.Close()
            Else
                TxtFiltro.Text = ""
            End If

        End If
    End Sub

    Private Sub FpTickets_Change(sender As Object, e As ChangeEventArgs) Handles FpTickets.Change
        If Not corriendo Then
            AgregaTicket()
        End If
    End Sub

    Private Sub FpTickets_GotFocus(sender As Object, e As EventArgs) Handles FpTickets.GotFocus, BtnEnviar.GotFocus, BtnInicializar.GotFocus, BtnRegresar.GotFocus, TxtFiltro.GotFocus, CmbCliente.GotFocus, Chk_menores.GotFocus, CheckBox1.GotFocus, Me.GotFocus
        If PanelSeleccionTarjetas.Visible Then
            If Not Corriendo Then
                If FpTickets.ActiveSheet.Cells(CInt(lbFila.Text), 7).Text <> "-1" Then
                    PanelSeleccionTarjetas.Visible = False
                    FpTickets.Focus()
                Else
                    Corriendo = True
                    FpTickets.ActiveSheet.SetActiveCell(CInt(lbFila.Text), 0)
                    MsgBox("Debe seleccionar primero el tipo de tarjeta del ticket a facturar.", vbExclamation, "Facturación de Tickets")
                    rbTCredito.Focus()
                    Corriendo = False
                End If
            End If
        End If
    End Sub

    Private Sub BtnCierraPanel_Click_1(sender As Object, e As EventArgs) Handles BtnCierraPanel.Click
        CierraPanel()
    End Sub

    Private Sub BtnRegistraTarjeta_Click(sender As Object, e As EventArgs) Handles BtnRegistraTarjeta.Click
        Dim Clave As String = ""
        If rbTCredito.Checked Then
            Clave = "04"
        ElseIf rbTDebito.Checked Then
            Clave = "28"
        End If
        FpTickets.ActiveSheet.Cells(CInt(lbFila.Text), 7).Text = Clave
        PanelSeleccionTarjetas.Visible = False
        If FpTickets.ActiveSheet.ActiveRowIndex < FpTickets.ActiveSheet.RowCount - 1 Then
            FpTickets.ActiveSheet.ActiveRowIndex = FpTickets.ActiveSheet.ActiveRowIndex + 1
        Else
            FpTickets.ActiveSheet.RowCount = FpTickets.ActiveSheet.RowCount + 1
            FpTickets.ActiveSheet.ActiveRowIndex = FpTickets.ActiveSheet.RowCount - 1
        End If
        FpTickets.ActiveSheet.ActiveColumnIndex = 0
    End Sub

    Private Sub rbTCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles rbTCredito.KeyDown, rbTDebito.KeyDown
        If e.KeyCode = Keys.Escape Then
            CierraPanel()
        End If
    End Sub

    Private Sub CierraPanel()
        FpTickets.ActiveSheet.Cells(CInt(lbFila.Text), 7).Text = "-1"
        FpTickets.ActiveSheet.RemoveRows(CInt(lbFila.Text), 1)
        If FpTickets.ActiveSheet.RowCount = 0 Then
            FpTickets.ActiveSheet.RowCount = 1
            FpTickets.ActiveSheet.SetActiveCell(0, 0)
        End If
        PanelSeleccionTarjetas.Visible = False
        TarjetaSeleccionada = False
        FpTickets.Focus()
    End Sub

    Private Shared Function ObtenerRegimenFiscal(ByVal clave As String) As String
        If clave = "601" Then
            Return "General de Ley Personas Morales"
        ElseIf clave = "603" Then
            Return "Personas Morales con Fines no Lucrativos"
        ElseIf clave = "605" Then
            Return "Sueldos y Salarios e Ingresos Asimilados a Salarios"
        ElseIf clave = "606" Then
            Return "Arrendamiento"
        ElseIf clave = "607" Then
            Return "Régimen de Enajenación o Adquisición de Bienes"
        ElseIf clave = "608" Then
            Return "Demás ingresos"
        ElseIf clave = "609" Then
            Return "Consolidación"
        ElseIf clave = "610" Then
            Return "Residentes en el Extranjero sin Establecimiento Permanente en México"
        ElseIf clave = "611" Then
            Return "Ingresos por Dividendos (socios y accionistas)"
        ElseIf clave = "612" Then
            Return "Personas Físicas con Actividades Empresariales y Profesionales"
        ElseIf clave = "614" Then
            Return "Ingresos por intereses"
        ElseIf clave = "615" Then
            Return "Régimen de los ingresos por obtención de premios"
        ElseIf clave = "616" Then
            Return "Sin obligaciones fiscales"
        ElseIf clave = "620" Then
            Return "Sociedades Cooperativas de Producción que optan por diferir sus ingresos"
        ElseIf clave = "621" Then
            Return "Incorporación Fiscal"
        ElseIf clave = "622" Then
            Return "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras"
        ElseIf clave = "623" Then
            Return "Opcional para Grupos de Sociedades"
        ElseIf clave = "624" Then
            Return "Coordinados"
        ElseIf clave = "628" Then
            Return "Hidrocarburos"
        ElseIf clave = "629" Then
            Return "De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales"
        ElseIf clave = "630" Then
            Return "Enajenación de acciones en bolsa de valores"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerUsoCFDI(ByVal clave As String) As String
        If clave.ToUpper = "Adquisición de mercancías".ToUpper Then
            Return "G01"
        ElseIf clave.ToUpper = "Devoluciones, descuentos o bonificaciones".ToUpper Then
            Return "G02"
        ElseIf clave.ToUpper = "Gastos en general".ToUpper Then
            Return "G03"
        ElseIf clave.ToUpper = "Construcciones".ToUpper Then
            Return "I01"
        ElseIf clave.ToUpper = "Mobilario y equipo de oficina por inversiones".ToUpper Then
            Return "I02"
        ElseIf clave.ToUpper = "Equipo de transporte".ToUpper Then
            Return "I03"
        ElseIf clave.ToUpper = "Equipo de computo y accesorios".ToUpper Then
            Return "I04"
        ElseIf clave.ToUpper = "Dados, troqueles, moldes, matrices y herramental".ToUpper Then
            Return "I05"
        ElseIf clave.ToUpper = "Comunicaciones telefónicas".ToUpper Then
            Return "I06"
        ElseIf clave.ToUpper = "Comunicaciones satelitales".ToUpper Then
            Return "I07"
        ElseIf clave.ToUpper = "Otra maquinaria y equipo".ToUpper Then
            Return "I08"
        ElseIf clave.ToUpper = "Honorarios médicos, dentales y gastos hospitalarios".ToUpper Then
            Return "D01"
        ElseIf clave.ToUpper = "Gastos médicos por incapacidad o discapacidad".ToUpper Then
            Return "D02"
        ElseIf clave.ToUpper = "Gastos funerales".ToUpper Then
            Return "D03"
        ElseIf clave.ToUpper = "Donativos".ToUpper Then
            Return "D04"
        ElseIf clave.ToUpper = "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)".ToUpper Then
            Return "D05"
        ElseIf clave.ToUpper = "Aportaciones voluntarias al SAR".ToUpper Then
            Return "D06"
        ElseIf clave.ToUpper = "Primas por seguros de gastos médicos".ToUpper Then
            Return "D07"
        ElseIf clave.ToUpper = "Gastos de transportación escolar obligatoria.".ToUpper Then
            Return "D08"
        ElseIf clave.ToUpper = "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones".ToUpper Then
            Return "D09"
        ElseIf clave.ToUpper = "Pagos por servicios educativos (colegiaturas)".ToUpper Then
            Return "D10"
        ElseIf clave.ToUpper = "Por definir".ToUpper Then
            Return "P01"
        Else
            Return " "
        End If
    End Function
End Class