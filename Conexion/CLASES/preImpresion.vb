Imports System.Data.SqlClient
Public Class preImpresion
    Private spread As FarPoint.Win.Spread.FpSpread
    Private tipo As Integer
    Private renglones As New Collection
    Private sDireccion() As String
    Private sNomina, sNombre, sTotal As String
    Private enter As Char = Chr(13)
    Private line As Char = Chr(10)
    Dim scambio As String
    Dim numt As String
    Dim iva, ieps As Double
    Dim subt As Double
    Dim losqueno As Double
    Dim xcon As SqlConnection
    Dim sql As String
    Dim i As Integer
    Dim llevavale As Integer



    Public Sub New(ByVal cambio As String, ByRef Xspread As FarPoint.Win.Spread.FpSpread, ByVal sDirec As String(), ByVal sNomin As String, ByVal sNombr As String, ByVal sTot As String, ByVal numtic As String, ByRef con As SqlConnection, Optional ByVal Xtipo As Integer = 0)
        Dim dsc As New DataSet
        Dim dsc1 As New DataSet
        Dim xtexto As String
        Dim m As Integer
        Dim Espacios As String



        numt = numtic
        xcon = con
        sDireccion = sDirec
        spread = Xspread
        tipo = Xtipo
        sNomina = sNomin
        sNombre = sNombr
        sTotal = sTot
        iva = 0
        ieps = 0
        losqueno = 0
        llevavale = 0

        Dim ColIVA, ColIEPS, ColCant, ColPrecio As Integer
        If cambio <> "null" Then
            ColIVA = 6
            ColIEPS = 10
            ColCant = 0
            ColPrecio = 2
        Else
            ColIVA = 8
            ColIEPS = 10
            ColCant = 0
            ColPrecio = 7
        End If

        For i As Integer = 0 To spread.ActiveSheet.RowCount - 1
            If cambio <> "null" Then
                If spread.ActiveSheet.Cells(i, 5).Text = "*" Then
                    llevavale = 1
                End If
            End If
            If CDbl(spread.ActiveSheet.Cells(i, ColIVA).Value) > 0 Then
                iva = iva + ((CDbl(spread.ActiveSheet.Cells(i, ColIVA).Value)) / 100.0) * ((CDbl(spread.ActiveSheet.Cells(i, ColCant).Value) * CDbl(spread.ActiveSheet.Cells(i, ColPrecio).Value)) / (1 + (CDbl(spread.ActiveSheet.Cells(i, ColIVA).Value) / 100.0)) / (1 + (CDbl(spread.ActiveSheet.Cells(i, ColIEPS).Value) / 100.0)))
            ElseIf CDbl(spread.ActiveSheet.Cells(i, ColIEPS).Value) > 0 Then
                ieps = ieps + ((CDbl(spread.ActiveSheet.Cells(i, ColIEPS).Value)) / 100.0) * ((CDbl(spread.ActiveSheet.Cells(i, ColCant).Value) * CDbl(spread.ActiveSheet.Cells(i, ColPrecio).Value)) / (1 + (CDbl(spread.ActiveSheet.Cells(i, ColIEPS).Value) / 100.0)) / (1 + (CDbl(spread.ActiveSheet.Cells(i, ColIVA).Value) / 100.0)))
            Else
                losqueno = losqueno + (CDbl(spread.ActiveSheet.Cells(i, ColCant).Value) * CDbl(spread.ActiveSheet.Cells(i, ColPrecio).Value))
            End If
        Next

        subt = CDbl(sTotal) - (iva) - ieps
        If cambio <> "null" Then
            scambio = cambio
        End If

        'ENCABEZADO
        renglones.Add(centra(Globales.grupo))
        renglones.Add(centra(Globales.empresa))
        renglones.Add(centra(Globales.rfc))
        renglones.Add(centra(Globales.dir1))
        renglones.Add(centra(Globales.dir2))
        renglones.Add(centra(Globales.DIR3))
        renglones.Add(" ")


        Espacios = " "
        While Len("Fecha: " & Now.ToShortDateString & " " & Now.ToLongTimeString & Espacios & "Caja: " & Right(Globales.caja, 1)) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToLongTimeString & Espacios & "Caja: " & Right(Globales.caja, 1))

        renglones.Add("  ")

        Espacios = " "

        While Len("Cajero: " & Microsoft.VisualBasic.Strings.Left(Globales.NombreEmpleado, Globales.numletras - Len("Cajero: " & Espacios & "# Ticket: " & numtic)) & Espacios & "# Ticket: " & numtic) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add("Cajero: " & Microsoft.VisualBasic.Strings.Left(Globales.NombreEmpleado, Globales.numletras - Len("Cajero: " & Espacios & "# Ticket: " & numtic)) & Espacios & "# Ticket: " & numtic)

        renglones.Add("  ")

        xtexto = ""

        For m = 1 To Globales.numletras
            xtexto = xtexto & "-"
        Next

        renglones.Add("-----------------------------------------")
        'renglones.Add("CANT ARTICULO            P.U.    IMPORTE ")
        renglones.Add("ARTICULO          CANT   P.U.    IMPORTE ")
        renglones.Add("-----------------------------------------")

        'PARA PASAR SOLO LOS RENGLONES CONSOLIDADOS DEL TICKET

        If cambio <> "null" Then
            sql = "SELECT * FROM TMPAUXVTA WHERE TMP_USUARIO='" & Globales.caja & "'"
        Else
            sql = "select dcot_cantidad as TMP_CANTIDAD, art_clave TMP_ARTICULO, art_nomlargo TMP_DSCART, dcot_precio TMP_PRECIO, dcot_total TMP_TOTAL from ecdetcotiza e join xupc on dcot_articulo=upc_upc join articulo on upc_cveart=art_clave where dcot_compra=" & numtic & " order by dcot_renglon ASC"
        End If

        Base.daQuery(sql, xcon, dsc1, "IMPRIME")

        If dsc1.Tables("IMPRIME").Rows.Count > 0 Then
            For i = 0 To dsc1.Tables("IMPRIME").Rows.Count - 1
                If CDbl(dsc1.Tables("imprime").Rows(i)("tmp_cantidad")) <> 0 Then
                    renglones.Add(Left(dsc1.Tables("imprime").Rows(i)("tmp_dscart"), Globales.numletras))
                    renglones.Add(tabula(dsc1.Tables("imprime").Rows(i)("tmp_cantidad"), dsc1.Tables("imprime").Rows(i)("tmp_dscart"), Format(CDbl(dsc1.Tables("imprime").Rows(i)("tmp_precio")), "#,##0.00"), Format(CDbl(dsc1.Tables("imprime").Rows(i)("tmp_total")), "##,##0.00")))
                    'renglones.Add(tabula(dsc1.Tables("imprime").Rows(i)("tmp_cantidad"), dsc1.Tables("imprime").Rows(i)("tmp_dscart"), Format(CDbl(dsc1.Tables("imprime").Rows(i)("tmp_precio")), "#,##0.00"), Format(CDbl(dsc1.Tables("imprime").Rows(i)("tmp_total")), "##,##0.00")))
                End If
            Next i

        End If
        dsc1.Tables.Remove("imprime")

        renglones.Add("-----------------------------------------")

        guardaFooter(sTotal, IIf(cambio <> "null", False, True), subt, ieps, iva)
        'guardaFooter("-----------------------------------------")
        renglones.Add(enter)

    End Sub
    Private Function centra(ByVal texto As String) As String
        centra = Space(Int((Globales.numletras - Len(texto.Trim)) / 2)) & texto.Trim
    End Function
    Private Function DERECHA(ByVal TEXTO As String) As String
        DERECHA = Space(Globales.numletras - Len(TEXTO.Trim)) & TEXTO.Trim
    End Function


    Private Function tabula(ByVal cant As String, ByVal art As String, ByVal unit As String, ByVal importe As String) As String
        '33
        Dim Espacios As String
        Espacios = ""

        unit = "$ " & unit
        importe = "$ " & importe

        While unit.Length < 8
            unit = " " & unit
        End While

        While "$ " & importe.Length < 9 '7
            importe = " " & importe
        End While

        While Len(Espacios & cant & " x " & unit & " " & importe) < Globales.numletras
            Espacios = Espacios & " "
        End While

        Return Espacios & cant & " x " & unit & " " & importe



        '33

        'While cant.Length < 4 '3
        'cant = " " & cant
        'End While
        'art = Mid(art, 1, 17) '14
        'While art.Length < 17 '16
        'art = art & " "
        'End While

        'While unit.Length < 8
        'unit = " " & unit
        'End While

        'While importe.Length < 9 '7
        'importe = " " & importe
        'End While
        'Return cant & " " & art & " " & unit & " " & importe '16
        ''Return cant & " " & Mid(art, 1, 20) & unit & " " & importe '16

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

        ' renglones.Add(Chr(27) + Chr(112) + Chr(0) + Chr(40) & Chr())



    End Sub

    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property
End Class
