Imports System.Data.SqlClient
Public Class cortecajanuevo
    Inherits System.Windows.Forms.Form
    Dim foma As Form
    Private Xcon As SqlConnection
    Private renglones As New Collection
    Private Chenter As Char = Chr(13)
    Dim VENTADIA As Double
    Dim FOLIOVTAINI As Integer
    Dim FOLIOVTAFIN As Integer
    Dim FOLIORETINI As Integer
    Dim FOLIORETFIN As Integer
    Dim FOLIORETINIT As Integer
    Dim FOLIORETFINT As Integer
    Dim FOLIORETINITF As Integer
    Dim FOLIORETFINTF As Integer
    Dim COMISION As Double
    Dim COMISIONT As Double
    Dim vtaefectivo As Double
    Dim vtacredito As Double
    Dim vtacomision As Double
    Dim vtacomisiont As Double
    Dim vtavales As Double
    Dim vtatarjeta As Double
    Dim vtatransfer As Double
    Dim vtacheques As Double
    Dim cuantos1 As Integer
    Dim cuantos2 As Integer
    Dim cuantos3 As Integer
    Dim dinretiros As Double

   Public Sub New(ByRef con As SqlConnection, ByRef fom As Fradmin)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xcon = con
        foma = fom
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    Private Sub cortecajanuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TXT_CAJA.Text = Mid(Globales.caja, 7, 1)
        txt_fechaini.Text = Date.Now
    End Sub


    Private Sub BTN_NUEVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_NUEVO.Click
        Dim XVALOR As Double
        If TxtTarjetasMonto.Text <> "" Then
            If IsNumeric(TxtTarjetasMonto.Text) Then
                If GENERADATOSDIA() Then
                    If Math.Round(CDbl(TxtTarjetasMonto.Text), 2) <> Math.Round(vtatarjeta, 2) Then
                        Label5.Text = Math.Round(vtatarjeta, 2) - Math.Round(CDbl(TxtTarjetasMonto.Text), 2)
                        If CDbl(Label5.Text) < 0 Then
                            Label5.ForeColor = Color.Red
                        Else
                            Label5.ForeColor = Color.Green
                        End If
                        If Math.Abs((CDbl(TXT_DIFERENCIAS.Text))) > 10 Then
                            Label7.Text = "NECESITA CLAVE PARA CALCULAR EL CORTE YA QUE EL MONTO DE TAJETAS EN VOUCHER NO COINCIDE CON LO COBRADO Y ADEMÁS, EL RESULTADO DEL CORTE ES MAYOR QUE EL PERMITIDO."
                        Else
                            Label7.Text = "NECESITA CLAVE PARA REALIZAR EL CORTE YA QUE EL RESULTADO DEL CORTE ES MAYOR QUE EL PERMITIDO"
                        End If
                        Panel1.Visible = True
                        TXT_PASSWORD.Focus()
                        Exit Sub
                    Else
                        If Math.Abs((CDbl(TXT_DIFERENCIAS.Text))) > 10 Then
                            Label7.Text = "NECESITA CLAVE PARA REALIZAR EL CORTE YA QUE EL RESULTADO DEL CORTE ES MAYOR QUE EL PERMITIDO"
                            Panel1.Visible = True
                            TXT_PASSWORD.Focus()
                            Exit Sub
                        End If
                    End If
                    cierracorte()
                    generaTicket()

                    MessageBox.Show("Turno cerrado" & vbCrLf & "Corte de Caja realizado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    TXT_DIFERENCIAS.Text = ""
                End If
            Else
                MsgBox("El monto de tarjeta no es numérico.", vbExclamation, "Corte de Caja")
                TxtTarjetasMonto.Text = ""
                TxtTarjetasMonto.Focus()
            End If
        End If

        If GENERADATOSDIA() Then
            If Math.Abs((CDbl(TXT_DIFERENCIAS.Text))) > 10 Then
                Panel1.Visible = True
                GoTo SIGUE
            Else

                BTN_NUEVO.Enabled = False
            End If
        End If
SIGUE:
    End Sub

    Private Sub cierracorte()
        Dim sql As String

        INSERTA()
        ''datos para actualizar
        sql = "update fondos set corte=1 where corte=0 and caja ='" & TXT_CAJA.Text & "'"
        Base.Ejecuta(Sql, Xcon)

        Base.Ejecuta("UPDATE ECVENTA SET CORTE=1 WHERE VEN_STATUS=1 AND VEN_USUARIO='000" & TXT_CAJA.Text & "'  AND CORTE=0", Xcon)
        Base.Ejecuta("update ecretiros set corte=1 where ret_estatus=0 and corte=0 and caja='00" & Mid(Globales.caja, 7, 1) & "0'", Xcon)
        Base.Ejecuta("update ectarjetas set corte=1 where estatus=0 and corte=0 and caja='00" & Mid(Globales.caja, 7, 1) & "0'", Xcon)
        Base.Ejecuta("update ectransfer set corte=1 where estatus=0 and corte=0 and caja='00" & Mid(Globales.caja, 7, 1) & "0'", Xcon)

    End Sub
    Private Sub cargaEncabezado(ByVal titulo As String)
        Dim SQL As String
        Dim DSC As New DataSet

        SQL = "select his_turno, his_fecha, his_activo,HIS_CAJERA  FROM ECHISTURNO WHERE HIS_ACTIVO='A' AND HIS_CAJA='" & Globales.caja & "'"
        Base.daQuery(SQL, Xcon, DSC, "TURNO")

 

        renglones.Add(Globales.grupo)
        renglones.Add(Globales.empresa)
        renglones.Add(Globales.rfc)
        renglones.Add(Globales.dir1)
        renglones.Add(Globales.dir2)
        renglones.Add(Globales.DIR3)
        renglones.Add(Globales.CIUDAD)
        renglones.Add("               CORTE DE CAJA  # " & TXT_CAJA.Text)
        renglones.Add(Chenter)

        renglones.Add("SUPERVISOR:      " & Globales.nombreusuario)

        If DSC.Tables("TURNO").Rows.Count > 0 Then
            Globales.nombreusuario = DSC.Tables("TURNO").Rows(0)("HIS_CAJERA") & ""
        End If
        renglones.Add("CAJERA:      " & Globales.nombreusuario)
        renglones.Add(Chenter)
        renglones.Add("      " & TXT_FECHAYHORA.Text)
        renglones.Add("------------------------------------------")

        DSC.Tables.Remove("TURNO")
    End Sub

    Private Sub generaTicket()
        Dim titulo As String
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer
        Dim xvalor As Double

        renglones = New Collection
        titulo = " "
        cargaEncabezado(titulo)
        renglones.Add(" ")
        renglones.Add("VENTA DEL DIA:           $ " & Format(VENTADIA, "0.00"))
        renglones.Add("COMISION DIA VALE:       $ " & Format(vtacomision * -1, "0.00"))
        renglones.Add("COMISION DIA TARJ:       $ " & Format(vtacomisiont * -1, "0.00"))
        renglones.Add("")
        renglones.Add("FONDO DE CAJA:       $ " & Format(0, "0.00"))
        renglones.Add("======================================")
        renglones.Add("TOTAL DE CLIENTES 1:      $ " & Format(cuantos1, "0"))
        renglones.Add("TOTAL DE CLIENTES 2:      $ " & Format(cuantos2, "0"))
        renglones.Add("TOTAL DE CLIENTES 3:      $ " & Format(cuantos3, "0"))
        renglones.Add("TOTAL DEL DIA:            $ " & Format(VENTADIA, "0.00"))
        renglones.Add("TOTAL EFECTIVO:           $ " & Format(VENTADIA - vtavales - vtacheques - vtacredito - vtatarjeta - vtatransfer + (vtacomisiont * -1), "0.00"))
        renglones.Add("TOTAL VALES:              $ " & Format(vtavales, "0.00"))
        renglones.Add("TOTAL TARJETAS:           $ " & Format(vtatarjeta, "0.00"))
        renglones.Add("TOTAL TRANSFER:           $ " & Format(vtatransfer, "0.00"))
        renglones.Add("TOTAL CHEQUES:            $ " & Format(vtacheques, "0.00"))
        renglones.Add("TOTAL CREDITO:            $ " & Format(vtacredito, "0.00"))
        renglones.Add("==========================================")
        renglones.Add(Chenter)
        renglones.Add("           ENTREGA DE CAJA:")
        renglones.Add("==========================================")
        renglones.Add(Format(0 * 1, "#0") & "Billete 1000:        $ " & Format(0 * 1000, "###,##0.00"))
        renglones.Add(Format(0 * 1, "#0") & " Billete 500:        $ " & Format(0 * 500, "###,##0.00"))
        renglones.Add(Format(0 * 1, "#0") & " Billete 200:        $ " & Format(0 * 200, "###,##0.00"))
        renglones.Add(Format(0 * 1, "#0") & " Billete 100:        $ " & Format(0 * 100, "###,##0.00"))
        renglones.Add(Format(0 * 1, "#0") & " Billete  50:        $ " & Format(0 * 50, "###,##0.00"))
        renglones.Add(Format(0 * 1, "#0") & " Billete  20:        $ " & Format(0 * 20, "###,##0.00"))
        renglones.Add("     Morralla:        $ " & Format(0 * 1, "###,##0.00"))
        renglones.Add("     Dólares:         $ " & Format(0 * 1, "###,##0.00"))
        renglones.Add("     Vales:           $ " & Format(0 * 1, "###,##0.00"))
        renglones.Add("     Cheques:         $ " & Format(0 * 1, "###,##0.00"))
        renglones.Add("     Retiros:         $ " & Format(dinretiros * 1, "###,##0.00"))
        renglones.Add("     Credito:         $ " & Format(vtacredito * 1, "###,##0.00"))
        renglones.Add("     Tarjetas:        $ " & Format(vtatarjeta * 1, "###,##0.00"))
        renglones.Add("     Transfer:        $ " & Format(vtatransfer * 1, "###,##0.00"))
        renglones.Add("==========================================")
        renglones.Add("TOTAL DEL DIA:        $ " & Format((vtacredito + dinretiros + vtatarjeta + vtatransfer) * 1, "###,##0.00"))
        renglones.Add("==========================================")
        xvalor = -VENTADIA - (vtacomision * -1) + dinretiros + vtacredito + vtatarjeta + vtatransfer - (vtacomisiont * -1)
        renglones.Add("DIFERENCIA:  " & IIf(xvalor > 0, "SOBRANTE " & Format(xvalor, "###,##0.00"), "FALTANTE " & Format(Math.Abs(xvalor), "###,##0.00")))
        renglones.Add("==========================================")
        renglones.Add(Chenter)
        renglones.Add(Chenter)
        renglones.Add("             RETIROS DE CAJA")
        renglones.Add("=====================================")
        renglones.Add("       CONCEPTO             IMPORTE  ")
        renglones.Add("-------------------------------------")


        sql = "SELECT CUANTO,DESCRIPCION  FROM ECRETIROS WHERE CAJA='00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'" & _
        " and cve_retiros>= " & FOLIORETINI & "and cve_retiros<=" & FOLIORETFIN & " and ret_estatus=0"
        Base.daQuery(sql, Xcon, dsc, "RETIROS")


        For i = 0 To dsc.Tables("RETIROS").Rows.Count - 1
            renglones.Add(Mid(dsc.Tables("RETIROS").Rows(i)("DESCRIPCION") & Space(25), 1, 25).ToUpper & Format(CDbl(dsc.Tables("RETIROS").Rows(i)("CUANTO")), "$##,###0.00"))
        Next


        dsc.Tables.Remove("retiros")

        renglones.Add("==========================================")

        renglones.Add(Chenter)
        renglones.Add(Chenter)

        renglones.Add("    VOUCHER TARJETAS BANCARIAS")
        renglones.Add("=====================================")
        renglones.Add("       CONCEPTO             IMPORTE  ")
        renglones.Add("-------------------------------------")

        sql = "SELECT CANTIDAD,REFERENCIA  FROM ECTARJETAS WHERE CAJA='00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'" & _
        " and TAR_ID>= " & FOLIORETINIT & "and TAR_ID<=" & FOLIORETFINT & " and estatus=0"

        Base.daQuery(sql, Xcon, dsc, "RETIROS")
        For i = 0 To dsc.Tables("RETIROS").Rows.Count - 1
            renglones.Add(Mid(dsc.Tables("RETIROS").Rows(i)("REFERENCIA") & Space(25), 1, 25).ToUpper & Format(CDbl(dsc.Tables("RETIROS").Rows(i)("CANTIDAD")), "$##,###0.00"))
        Next
        dsc.Tables.Remove("retiros")
        renglones.Add("==========================================")

        renglones.Add(Chenter)
        renglones.Add(Chenter)

        renglones.Add("    RELACION TRANSFERENCIAS BANCARIAS")
        renglones.Add("=====================================")
        renglones.Add("       CONCEPTO             IMPORTE  ")
        renglones.Add("-------------------------------------")

        sql = "SELECT CANTIDAD,REFERENCIA  FROM ECTRANSFER WHERE CAJA='00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'" & _
        " and TRA_ID>= " & FOLIORETINITF & "and TRA_ID<=" & FOLIORETFINTF & " and estatus=0"

        Base.daQuery(sql, Xcon, dsc, "RETIROS")
        For i = 0 To dsc.Tables("RETIROS").Rows.Count - 1
            renglones.Add(Mid(dsc.Tables("RETIROS").Rows(i)("REFERENCIA") & Space(25), 1, 25).ToUpper & Format(CDbl(dsc.Tables("RETIROS").Rows(i)("CANTIDAD")), "$##,###0.00"))
        Next
        dsc.Tables.Remove("retiros")
        renglones.Add("==========================================")


        Dim oImpresion As Impresion
        oImpresion = New Impresion(renglones)
        oImpresion.imprime(True)

        sql = "UPDATE ECHISTURNO SET HIS_ACTIVO='C' WHERE HIS_ACTIVO='A' AND HIS_CAJA='" & Globales.caja & "'"
        Base.Ejecuta(sql, Xcon)
    End Sub
    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) & _
        IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
    End Function


    Private Sub INSERTA()
        Dim SQL As String
        Dim DSC As New DataSet

        SQL = "SELECT FOLIO_CORTE+1 MAXIMO FROM ECCONTROLES "
        Base.daQuery(SQL, Xcon, DSC, "TABLA")
        TXT_FOLIO.Text = DSC.Tables("TABLA").Rows(0)("MAXIMO")

        DSC.Tables.Remove("TABLA")

        Base.Ejecuta("UPDATE ECCONTROLES SET FOLIO_CORTE=FOLIO_CORTE+1", Xcon)

        SQL = "insert into eccortes ( numcorte,fechacorte,caja,bill1000,bill500,bill200,bill100,bill50,bill20,morralla," & _
            "cheques,vales,dolares,numdolares,ventatotal,vtaefectivo,vtacredito,vtacheques,vtavales,vtacomision,vtatarjeta,vtatransfer,vtacomisiont,cuantos1,cuantos2," & _
            "cuantos3,dinretiros,foliovtaini,foliovtafin,folioretini,folioretfin,folioretinit,folioretfint,folioretinitf,folioretfintf) VALUES (" & _
TXT_FOLIO.Text & "," & _
"GETDATE()" & ",'" & _
TXT_CAJA.Text & "'," & _
"0,0,0,0,0,0,0,0,0,0,0," & _
VENTADIA.ToString & "," & _
vtaefectivo.ToString & "," & _
vtacredito.ToString & "," & _
vtacheques.ToString & "," & _
vtavales.ToString & "," & _
vtacomision.ToString & "," & _
vtatarjeta.ToString & "," & _
vtatransfer.ToString & "," & _
vtacomisiont.ToString & "," & _
cuantos1.ToString & "," & _
cuantos2.ToString & "," & _
cuantos3.ToString & "," & _
dinretiros.ToString & "," & _
FOLIOVTAINI.ToString & "," & _
FOLIOVTAFIN.ToString & "," & _
FOLIORETINI.ToString & "," & _
FOLIORETFIN.ToString & "," & _
FOLIORETINIT.ToString & "," & _
FOLIORETFINT.ToString & "," & _
FOLIORETINITF.ToString & "," & _
FOLIORETFINTF.ToString & ")"
      
        Base.Ejecuta(SQL, Xcon)
        Base.Ejecuta("exec acumcorte " & TXT_FOLIO.Text, Xcon)
        CARGACORTE()

    End Sub
    Private Function GENERADATOSDIA() As Boolean
        Dim SQL As String
        Dim DSC As New DataSet
        Dim I As Integer

        SQL = "SELECT VEN_ID FROM ECVENTA WHERE VEN_STATUS=1 AND VEN_USUARIO='000" & TXT_CAJA.Text & "' AND CORTE=0"
        Base.daQuery(SQL, Xcon, DSC, "TABLA")
        If DSC.Tables("Tabla").Rows.Count = 0 Then
            MsgBox("No existen tickets cobrados desde el último corte de caja realizado.", vbExclamation, "Corte de Caja")
            GENERADATOSDIA = False
            Exit Function
        End If
        DSC.Tables.Remove("TABLA")

        SQL = "SELECT ISNULL(MIN(VEN_ID),0)  MINIMO FROM ECVENTA WHERE VEN_STATUS=1 AND VEN_USUARIO='000" & TXT_CAJA.Text & "'  AND CORTE=0"
        Base.daQuery(SQL, Xcon, DSC, "TABLA")
        FOLIOVTAINI = CDbl(DSC.Tables("TABLA").Rows(0)("MINIMO"))
        DSC.Tables.Remove("TABLA")

        SQL = "SELECT ISNULL(MAX(VEN_ID),0)  MAXIMO FROM ECVENTA WHERE VEN_STATUS=1 AND VEN_USUARIO='000" & TXT_CAJA.Text & "'  AND CORTE=0"
        Base.daQuery(SQL, Xcon, DSC, "TABLA")
        FOLIOVTAFIN = CDbl(DSC.Tables("TABLA").Rows(0)("MAXIMO"))
        DSC.Tables.Remove("TABLA")

        SQL = "SELECT ISNULL(SUM(VEN_TOTAL),0) VENTADIA FROM ECVENTA WHERE VEN_STATUS=1 AND VEN_USUARIO='000" & TXT_CAJA.Text & "'  AND CORTE=0"
        Base.daQuery(SQL, Xcon, DSC, "TABLA")

        VENTADIA = CDbl(DSC.Tables("TABLA").Rows(0)("VENTADIA"))
        DSC.Tables.Remove("TABLA")


        vtaefectivo = 0
        vtacredito = 0
        vtacomision = 0
        vtacomisiont = 0
        vtacheques = 0
        vtatarjeta = 0
        vtatransfer = 0


        SQL = "SELECT TIPO_PAGO,SUM(PAGO) MONTO  FROM ECFORMAPAGO INNER JOIN ECVENTA ON VEN_ID=REFERENCIA " &
        " WHERE VEN_STATUS=1 AND VEN_USUARIO='000" & TXT_CAJA.Text & "'  AND CORTE=0 " &
        "GROUP BY TIPO_PAGO"
        Base.daQuery(SQL, Xcon, DSC, "TABLA")
        For I = 0 To DSC.Tables("TABLA").Rows.Count - 1
            Select Case DSC.Tables("TABLA").Rows(I)("TIPO_PAGO")
                Case "Efectivo"
                    vtaefectivo = 0
                Case "Credito"
                    vtacredito = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case "Vales"
                    vtavales = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case "Comision Vales"
                    vtacomision = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case "Comis Tar"
                    vtacomisiont = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case "Cheque"
                    vtacheques = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case "Tarjeta"
                    vtatarjeta = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case "Transfer"
                    vtatransfer = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))

            End Select
        Next
        DSC.Tables.Remove("TABLA")

        vtaefectivo = VENTADIA - vtacheques - vtacredito - vtavales - vtatarjeta + vtacomisiont - vtatransfer
        SQL = "SELECT ven_tipov , count(ven_total) monto FROM ECVENTA WHERE VEN_STATUS=1 AND VEN_USUARIO='000" & TXT_CAJA.Text & "'  AND CORTE=0 " &
            " group by ven_tipov"
        Base.daQuery(SQL, Xcon, DSC, "TABLA")

        cuantos1 = 0
        cuantos2 = 0
        cuantos3 = 0

        For I = 0 To DSC.Tables("TABLA").Rows.Count - 1
            Select Case DSC.Tables("TABLA").Rows(I)("ven_tipov")
                Case 1
                    cuantos1 = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case 2
                    cuantos2 = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))
                Case 3
                    cuantos3 = CDbl(DSC.Tables("TABLA").Rows(I)("monto"))

            End Select
        Next

        DSC.Tables.Remove("TABLA")

        SQL = "select isnull(sum(cuanto),0) monto from ecretiros where caja='00" & TXT_CAJA.Text & "0' and ret_estatus<>2 and corte=0"
        Base.daQuery(SQL, Xcon, DSC, "TABLA")

        dinretiros = CDbl(DSC.Tables("TABLA").Rows(0)("monto"))
        DSC.Tables.Remove("TABLA")

        SQL = "SELECT ISNULL(MIN(CVE_RETIROS),0) MINIMO FROM ECRETIROS WHERE CAJA='00" & TXT_CAJA.Text & "0'" &
        " and corte=0  and ret_estatus=0"

        Base.daQuery(SQL, Xcon, DSC, "RETIROS")

        FOLIORETINI = CDbl(DSC.Tables("RETIROS").Rows(0)("MINIMO"))
        DSC.Tables.Remove("RETIROS")

        SQL = "SELECT ISNULL(MAX(CVE_RETIROS),0) MAXIMO FROM ECRETIROS WHERE CAJA='00" & TXT_CAJA.Text & "0'" &
        " and corte=0  and ret_estatus=0"

        Base.daQuery(SQL, Xcon, DSC, "RETIROS")

        FOLIORETFIN = CDbl(DSC.Tables("RETIROS").Rows(0)("MAXIMO"))
        DSC.Tables.Remove("RETIROS")


        SQL = "SELECT ISNULL(MIN(TAR_ID),0) MINIMO FROM ECTARJETAS WHERE CAJA='00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'" &
        " and corte=0  and estatus=0"

        Base.daQuery(SQL, Xcon, DSC, "RETIROS")

        FOLIORETINIT = CDbl(DSC.Tables("RETIROS").Rows(0)("MINIMO"))
        DSC.Tables.Remove("RETIROS")



        SQL = "SELECT ISNULL(MAX(TAR_ID),0) MAXIMO FROM ECTARJETAS WHERE CAJA='00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'" &
        " and corte=0  and estatus=0"

        Base.daQuery(SQL, Xcon, DSC, "RETIROS")

        FOLIORETFINT = CDbl(DSC.Tables("RETIROS").Rows(0)("MAXIMO"))
        DSC.Tables.Remove("RETIROS")

        '---------------------------------------------------------

        SQL = "SELECT ISNULL(MIN(TRA_ID),0) MINIMO FROM ECTRANSFER WHERE CAJA='00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'" &
      " and corte=0  and estatus=0"

        Base.daQuery(SQL, Xcon, DSC, "RETIROS")

        FOLIORETINITF = CDbl(DSC.Tables("RETIROS").Rows(0)("MINIMO"))
        DSC.Tables.Remove("RETIROS")

        SQL = "SELECT ISNULL(MAX(TRA_ID),0) MAXIMO FROM ECTRANSFER WHERE CAJA='00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0'" &
        " and corte=0  and estatus=0"

        Base.daQuery(SQL, Xcon, DSC, "RETIROS")

        FOLIORETFINTF = CDbl(DSC.Tables("RETIROS").Rows(0)("MAXIMO"))
        DSC.Tables.Remove("RETIROS")

        '--------------------------------------------------------------------------
        GENERADATOSDIA = True
    End Function
    Private Sub CARGACORTE()
        Dim SQL As String
        Dim DSC As New DataSet

        SQL = "SELECT * FROM ECCORTES WHERE NUMCORTE=" & TXT_FOLIO.Text
        Base.daQuery(SQL, Xcon, DSC, "TABLA")
        If DSC.Tables("TABLA").Rows.Count > 0 Then
            TXT_FECHAYHORA.Text = DSC.Tables("TABLA").Rows(0)("FECHACORTE")
            VENTADIA = CDbl(DSC.Tables("TABLA").Rows(0)("VENTATOTAL"))
            vtacheques = CDbl(DSC.Tables("TABLA").Rows(0)("VTACHEQUES"))
            vtacredito = CDbl(DSC.Tables("TABLA").Rows(0)("VTACREDITO"))
            vtaefectivo = CDbl(DSC.Tables("TABLA").Rows(0)("VTAEFECTIVO"))
            vtavales = CDbl(DSC.Tables("TABLA").Rows(0)("VTAVALES"))
            vtacomision = CDbl(DSC.Tables("TABLA").Rows(0)("VTACOMISION"))
            vtatarjeta = CDbl(DSC.Tables("TABLA").Rows(0)("VTAtarjeta"))
            vtatransfer = CDbl(DSC.Tables("TABLA").Rows(0)("vtatransfer"))
            vtacomisiont = CDbl(DSC.Tables("TABLA").Rows(0)("VTAcomisiont"))
            FOLIORETFIN = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIORETFIN"))
            FOLIORETINI = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIORETINI"))
            FOLIORETFINT = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIORETFINT"))
            FOLIORETINIT = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIORETINIT"))
            FOLIORETFINTF = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIORETFINTF"))
            FOLIORETINITF = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIORETINITF"))
            FOLIOVTAFIN = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIOVTAFIN"))
            FOLIOVTAINI = CDbl(DSC.Tables("TABLA").Rows(0)("FOLIOVTAINI"))
            cuantos1 = CDbl(DSC.Tables("TABLA").Rows(0)("CUANTOS1"))
            cuantos2 = CDbl(DSC.Tables("TABLA").Rows(0)("CUANTOS2"))
            cuantos3 = CDbl(DSC.Tables("TABLA").Rows(0)("CUANTOS3"))
            dinretiros = CDbl(DSC.Tables("TABLA").Rows(0)("DINRETIROS"))
            TXT_CAJA.Text = DSC.Tables("TABLA").Rows(0)("CAJA")
        End If

    End Sub

    Private Sub folio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_FOLIO.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Dim FRBUSQUEDA As New busqueda
            FRBUSQUEDA.TXTCONTROL = Me.TXT_FOLIO
            GENERAL.parametrosbusqueda(FRBUSQUEDA, "CORTES REGISTRADOS", "NUMCORTE,FECHACORTE,CAJA", "ECCORTES", "numcorte desc", "1", Xcon, "Folio Corte,Fecha,Caja", "80,120,80", "A,A,A", "1", "")
            FRBUSQUEDA.ShowDialog()
            FRBUSQUEDA.Dispose()
            If TXT_FOLIO.Text <> "" Then
                MsgBox("Espere un momento se va a reimprimir el corte",MsgBoxStyle.Information)
                CARGACORTE()
                generaTicket()
                MsgBox("Reimpresión de Corte Realizada Correctamente", MsgBoxStyle.Exclamation)
                TXT_FOLIO.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TXT_FOLIO.Enabled = True
        TXT_FOLIO.Focus()
    End Sub

    Private Sub btn_regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_regresar.Click
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim XVALOR As Double
        If TxtTarjetasMonto.Text <> "" Then
            If IsNumeric(TxtTarjetasMonto.Text) Then
                If GENERADATOSDIA() Then
                    If Math.Round(CDbl(TxtTarjetasMonto.Text), 2) <> Math.Round(vtatarjeta, 2) Then
                        Label5.Text = Math.Round(vtatarjeta, 2) - Math.Round(CDbl(TxtTarjetasMonto.Text), 2)
                        If CDbl(Label5.Text) < 0 Then
                            Label5.ForeColor = Color.Red
                        Else
                            Label5.ForeColor = Color.Green
                        End If
                        'Label7.Text = "NECESITA CLAVE PARA CALCULAR EL CORTE YA QUE EL MONTO DE TAJETAS EN VOUCHER NO COINCIDE CON LO COBRADO."
                        MsgBox("El monto de tarjeta en voucher no coincide con el cobrado.", vbExclamation, "Corte de Caja")
                        'NECESITA CLAVE PARA REALIZAR EL CORTE YA QUE EL RESULTADO DEL CORTE ES MAYOR QUE EL PERMITIDO
                    End If
                    XVALOR = -VENTADIA - (vtacomision * -1) + dinretiros + vtacredito + vtatarjeta + vtatransfer - (vtacomisiont * -1)
                    TXT_DIFERENCIAS.Text = XVALOR.ToString
                Else
                    TXT_DIFERENCIAS.Text = ""
                End If
            Else
                MsgBox("El monto de tarjeta no es numérico.", vbExclamation, "Corte de Caja")
                TxtTarjetasMonto.Text = ""
                TxtTarjetasMonto.Focus()
            End If
        Else
            MsgBox("Ingrese el monto de tarjeta del voucher.", vbExclamation, "Corte de Caja")
            TxtTarjetasMonto.Text = ""
            TxtTarjetasMonto.Focus()
        End If

    End Sub

    Private Sub panel_conf_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panel_conf.Paint

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim dsc As New DataSet
        Dim SQL As String
        SQL = "SELECT * FROM ECUSUARIOSX WHERE EMP_PASSWORD='" & TXT_PASSWORD.Text & "' AND EMP_TIPO='Supervisor' "
        Base.daQuery(SQL, Xcon, dsc, "tabla")
        If dsc.Tables("tabla").Rows.Count > 0 Then
            If GENERADATOSDIA() Then
                cierracorte()
                generaTicket()
                MessageBox.Show("Turno cerrado" & vbCrLf & "Corte de Caja realizado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                TXT_DIFERENCIAS.Text = ""
            End If
        Else
            MsgBox("ERROR DE CODIGO, CORRIJA", MsgBoxStyle.Exclamation)
        End If
        dsc.Tables.Remove("TABLA")
    End Sub
End Class