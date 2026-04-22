Imports System.Data.SqlClient
Imports System.Text
Public Class preImpresion
    Private renglones As New Collection

    ' Variables de Estado
    Private EsCotizacion As Boolean = False
    Private NumTicket As String
    Private Cambio As String
    Private sNomina, sNombre As String

    ' Variables Financieras
    Private FechaDocumento As DateTime
    Private Cliente As String
    Private TotalVenta As Decimal
    Private SubTotal As Decimal
    Private TotalIVA As Decimal
    Private TotalIEPS As Decimal
    Private TotalExento As Decimal

    ' --------------------------------------------------------------------------------
    ' 1. CONSTRUCTOR
    ' --------------------------------------------------------------------------------
    Public Sub New(ByVal sCambio As String,
                   ByVal sDirec As String(),
                   ByVal sNomin As String,
                   ByVal sNombr As String,
                   ByVal numtic As String)

        NumTicket = numtic
        sNomina = sNomin
        sNombre = sNombr

        ' Lógica original: Si cambio es "null", es cotización
        If sCambio = "null" OrElse String.IsNullOrEmpty(sCambio) Then
            EsCotizacion = True
            Cambio = "0.00"
        Else
            EsCotizacion = False
            Cambio = sCambio
        End If

        ' Bifurcación de Carga de Datos
        If EsCotizacion Then
            CargarDatosCotizacion(NumTicket)
        Else
            CargarDatosVenta(NumTicket)
        End If

        ' Generar el Ticket
        GenerarDocumento()
    End Sub

    ' --------------------------------------------------------------------------------
    ' A) LÓGICA PARA VENTAS (ECVENTA / ECDETVENTA)
    ' --------------------------------------------------------------------------------
    Private Sub CargarDatosVenta(idVenta As String)
        ' Usamos MAX(ven_fecha) para evitar GROUP BY y aprovechar el índice del ID
        Dim sql As String = "SELECT " &
                            "MAX(E.ven_fecha) as Fecha, " &
                            "IsNull(MAX(C.Cli_Nombre),'Público General') as Cliente, " &
                            "ISNULL(SUM(D.dve_total),0) as Total, " &
                            "ISNULL(SUM(D.dve_iva),0) as IVA, " &
                            "ISNULL(SUM(D.dve_ieps),0) as IEPS, " &
                            "ISNULL(SUM(D.dve_total - D.dve_iva - D.dve_ieps),0) as SubTotal, " &
                            "ISNULL(SUM(CASE WHEN D.dve_iva = 0 AND D.dve_ieps = 0 THEN D.dve_total ELSE 0 END),0) as Exento " &
                            "FROM ECVENTA E " &
                            "JOIN ECDETVENTA D ON E.ven_id = D.dve_venta " &
                            "JOIN TicketsClientes T ON T.FolioTicket=E.VEN_ID " &
                            "LEFT JOIN ECCLIENTES C ON T.ClienteID=C.Cli_CLAVE " &
                            "WHERE E.ven_id = " & idVenta

        EjecutarCargaFinanciera(sql)
    End Sub

    ' --------------------------------------------------------------------------------
    ' B) LÓGICA PARA COTIZACIONES (ECDETCOTIZA) - AJUSTADO A TU SCHEMA
    ' --------------------------------------------------------------------------------
    Private Sub CargarDatosCotizacion(idCotiza As String)
        ' Nota: Como ecdetcotiza usa FLOAT, hacemos CAST a DECIMAL para evitar errores de redondeo visual.
        ' Al no haber tabla de encabezado conocida con fecha (ECCOTIZA?), usamos GETDATE().

        Dim sql As String = "SELECT " &
                            "MAX(E.cot_fechacaptura) as Fecha, " &
                            "IsNull(MAX(C.Cli_Nombre),'Público General') as Cliente, " &
                            "ISNULL(SUM(CAST(D.dcot_total AS DECIMAL(18,4))),0) as Total, " &
                            "ISNULL(SUM(CAST(D.dcot_iva AS DECIMAL(18,4))),0) as IVA, " &
                            "ISNULL(SUM(CAST(D.dcot_ieps AS DECIMAL(18,4))),0) as IEPS, " &
                            "ISNULL(SUM(CAST(D.dcot_total AS DECIMAL(18,4)) - CAST(D.dcot_iva AS DECIMAL(18,4)) - CAST(D.dcot_ieps AS DECIMAL(18,4))),0) as SubTotal, " &
                            "ISNULL(SUM(CASE WHEN D.dcot_iva = 0 AND D.dcot_ieps = 0 THEN CAST(D.dcot_total AS DECIMAL(18,4)) ELSE 0 END),0) as Exento " &
                            "FROM eccotizaciones E " &
                            "JOIN ecdetcotiza D ON E.COT_ID=D.dcot_compra " &
                            "LEFT JOIN ECCLIENTES C ON E.ClienteID=C.Cli_CLAVE " &
                            "WHERE E.COT_ID = " & idCotiza

        EjecutarCargaFinanciera(sql)
    End Sub

    Private Sub EjecutarCargaFinanciera(sql As String)
        Dim ds As New DataSet
        Base.daQuery(sql, sCadenaConexionSQL, ds, "Datos")

        If ds.Tables("Datos").Rows.Count > 0 Then
            Dim row = ds.Tables("Datos").Rows(0)

            If IsDBNull(row("Fecha")) Then FechaDocumento = Now Else FechaDocumento = CDate(row("Fecha"))
            If IsDBNull(row("Cliente")) Then Cliente = "Público General" Else Cliente = row("Cliente")
            TotalVenta = CDec(row("Total"))
            TotalIVA = CDec(row("IVA"))
            TotalIEPS = CDec(row("IEPS"))
            SubTotal = CDec(row("SubTotal"))
            TotalExento = CDec(row("Exento"))
        Else
            FechaDocumento = Now
            TotalVenta = 0
        End If
    End Sub

    ' --------------------------------------------------------------------------------
    ' 3. CONSTRUCCIÓN DEL TICKET
    ' --------------------------------------------------------------------------------
    Private Sub GenerarDocumento()
        ' --- ENCABEZADO ---
        renglones.Add(Centra(Globales.grupo))
        renglones.Add(Centra(Globales.empresa))
        renglones.Add(Centra(Globales.rfc))
        renglones.Add(Centra(Globales.dir1))
        renglones.Add(Centra(Globales.dir2))
        renglones.Add(Centra(Globales.DIR3))
        renglones.Add(" ")

        ' 1. FECHA CON FORMATO AM/PM Y PREFIJO
        Dim sFecha As String = "Fecha: " & FechaDocumento.ToString("dd/MM/yyyy hh:mm:ss tt") ' tt pone AM/PM
        Dim sCaja As String = "Caja: " & Right(Globales.caja, 1)
        renglones.Add(Justifica(sFecha, sCaja))

        Dim sCajero As String = "Cajero: " & Left(Globales.NombreEmpleado, 12)
        Dim lblTicket As String = If(EsCotizacion, "# Cotiz:", "# Ticket:")
        Dim sTicket As String = lblTicket & " " & NumTicket
        renglones.Add(Justifica(sCajero, sTicket))

        ' 2. ESPACIO ENTRE FECHA Y CAJERO
        renglones.Add(" ")
        Dim sCliente As String = "Cliente: " & Left(Cliente, Globales.numletras - 9)
        renglones.Add(sCliente)

        renglones.Add(StrDup(Globales.numletras, "-"))

        ' 3. ENCABEZADO DE COLUMNAS (Alineación Matemática)
        ' DEFINICIÓN DE ANCHOS (Para alineación perfecta)
        ' Importe: $999,999.99 (11 chars)
        ' Precio:  $9,999.99   (9 chars)
        ' Cant:    99.999      (6 chars)

        Dim hArt As String = "ARTICULO"
        Dim hSep0 As String = "   "
        Dim hCant As String = "CANT".PadLeft(6)       ' Alineado a la derecha en caja de 6
        Dim hSep1 As String = "   "                   ' 3 espacios (sobre el " x ")
        Dim hPrec As String = "PRECIO".PadLeft(9 - 2)     ' Alineado a la derecha en caja de 9
        Dim hSep2 As String = "   "                   ' 3 espacios (separador visual)
        Dim hImp As String = "IMPORTE".PadLeft(11)    ' Alineado a la derecha en caja de 11

        ' Construimos la línea de títulos
        ' Resultado visual: "..CANT...PRECIO...IMPORTE"
        Dim HeaderNumeros As String = hArt & hSep0 & hCant & hSep1 & hPrec & hSep2 & hImp

        ' Empujamos todo el bloque hacia la derecha del ticket
        renglones.Add(HeaderNumeros)

        renglones.Add(StrDup(Globales.numletras, "-"))

        ' --- DETALLE ---
        Dim sqlDetalle As String = ""
        If EsCotizacion Then
            sqlDetalle = "SELECT dcot_cantidad AS Cantidad, art_nomlargo AS Descripcion, dcot_precio AS Precio, dcot_total AS Total FROM ecdetcotiza JOIN xupc ON dcot_articulo = upc_upc JOIN articulo ON upc_cveart = art_clave WHERE dcot_compra = " & NumTicket & " ORDER BY dcot_renglon ASC"
        Else
            sqlDetalle = "SELECT dve_cantidad AS Cantidad, art_nomlargo AS Descripcion, dve_precio AS Precio, dve_total AS Total FROM ECDETVENTA JOIN ARTICULO ON dve_articulo = ART_CLAVE WHERE dve_venta = " & NumTicket & " ORDER BY dve_renglon ASC"
        End If

        Dim dsDet As New DataSet
        Base.daQuery(sqlDetalle, sCadenaConexionSQL, dsDet, "Detalle")

        For Each row As DataRow In dsDet.Tables("Detalle").Rows
            Dim Cant As Decimal = CDec(row("Cantidad"))
            Dim Desc As String = row("Descripcion").ToString()
            Dim Prec As Decimal = CDec(row("Precio"))
            Dim Tot As Decimal = CDec(row("Total"))

            If Cant <> 0 Then
                renglones.Add(Left(Desc, Globales.numletras))
                renglones.Add(TabulaPro(Cant, Prec, Tot))
            End If
        Next

        renglones.Add(StrDup(Globales.numletras, "-"))

        ConstruirFooter()
        renglones.Add(Chr(13))
    End Sub

    Private Sub ConstruirFooter()
        Dim oConv As New Conversion(CDbl(TotalVenta))
        Dim sLetra As String = "Son: " & StrConv(oConv.numeroEnLetras, VbStrConv.ProperCase)

        renglones.Add(" ")

        ' 4. TOTALES CARGADOS A LA DERECHA (Con : alineados)
        If Not EsCotizacion Then
            renglones.Add(AlineaDerecha("Subtotal:", SubTotal))
            renglones.Add(AlineaDerecha("IVA:", TotalIVA))
            renglones.Add(AlineaDerecha("IEPS:", TotalIEPS))
        End If

        renglones.Add(AlineaDerecha("Total:", TotalVenta))
        renglones.Add(" ")

        If sLetra.Length <= Globales.numletras Then
            renglones.Add(sLetra)
        Else
            renglones.Add(sLetra.Substring(0, Math.Min(sLetra.Length, Globales.numletras)))
            If sLetra.Length > Globales.numletras Then
                renglones.Add(sLetra.Substring(Globales.numletras))
            End If
        End If

        renglones.Add("")

        If EsCotizacion Then
            renglones.Add(Centra("¡Muchas Gracias por su Cotización!"))
            renglones.Add("")
        Else
            CargarPagos()
            renglones.Add("")
            renglones.Add(Centra("¡Muchas Gracias por su Compra!"))
            renglones.Add("")
            renglones.Add(Centra("**El importe de esta venta se incluye **"))
            renglones.Add(Centra("      en la factura global del día      "))
        End If
    End Sub

    Private Sub CargarPagos()
        Dim sql As String = "select sum(pago) as pago, tipo_pago, banco from ecformapago where referencia=" & NumTicket & " group by tipo_pago, banco"
        Dim dsP As New DataSet
        Dim TotalPagado As Decimal = 0

        Base.daQuery(sql, sCadenaConexionSQL, dsP, "Pagos")

        For Each row As DataRow In dsP.Tables("Pagos").Rows
            Dim sPago As String = row("tipo_pago").ToString() ' "Efectivo", "Tarjeta"
            Dim dMonto As Decimal = CDec(row("pago"))
            Dim sBanco As String = row("banco").ToString().Trim

            ' Alineamos el pago también a la derecha, agregando ":" al nombre del pago
            renglones.Add(AlineaDerecha(sPago & ":", dMonto))

            If sBanco <> "" Then renglones.Add(AlineaDerecha(sBanco, 0, True)) ' True = Solo Texto

            TotalPagado += dMonto
        Next

        If dsP.Tables("Pagos").Rows.Count > 0 Then
            renglones.Add("")
            renglones.Add(AlineaDerecha("Cambio:", TotalPagado - TotalVenta))
        End If
    End Sub

    ' --------------------------------------------------------------------------------
    ' HELPERS VISUALES
    ' --------------------------------------------------------------------------------

    ' NUEVO: Alinea todo a la derecha manteniendo los ":" alineados verticalmente
    Private Function AlineaDerecha(Etiqueta As String, Monto As Decimal, Optional SoloTexto As Boolean = False) As String
        ' Definimos un ancho fijo para la etiqueta (ej. 12 chars) para que los ":" se alineen
        ' Ejemplo:
        ' "   Subtotal:" (12)
        ' "        IVA:" (12)

        Dim AnchoEtiqueta As Integer = 12
        Dim sEtiqueta As String = Etiqueta.Trim().PadLeft(AnchoEtiqueta)

        Dim sValor As String = ""
        If SoloTexto Then
            sValor = "" ' Si es nombre de banco, va solo
            ' Si quieres que el banco salga a la derecha, úsalo, si no, usa lógica normal
            Return Etiqueta.PadLeft(Globales.numletras)
        Else
            sValor = Format(Monto, "$##,##0.00").PadLeft(10) ' Ancho fijo para el monto también
        End If

        Dim LineaCompleta As String = sEtiqueta & " " & sValor

        ' Empujamos todo el bloque al extremo derecho del ticket
        Return LineaCompleta.PadLeft(Globales.numletras)
    End Function

    Private Function TabulaPro(Cant As Decimal, Precio As Decimal, Total As Decimal) As String
        ' 1. CANTIDAD (Ancho 6)
        ' Formato: 0.### (Ej: "2", "2.5", "100")
        ' Si se pasa de 6 chars (ej. 1000.555), se va a comer el margen izquierdo, pero no rompe la derecha.
        Dim sCant As String = Cant.ToString("0.###").PadLeft(6)

        ' 2. PRECIO (Ancho 9)
        ' Formato: $#,##0.00 (Ej: "$15.50", "$1,200.00")
        ' Max garantizado por ti: $9,999.99 (9 chars)
        Dim sPrec As String = Format(Precio, "$#,##0.00").PadLeft(9)

        ' 3. IMPORTE (Ancho 11)
        ' Formato: $#,##0.00
        ' Max garantizado por ti: $999,999.99 (11 chars)
        Dim sTot As String = Format(Total, "$#,##0.00").PadLeft(11)

        ' 4. ARMADO DE LA LÍNEA
        ' Estructura: [CANT] [ x ] [PRECIO] [   ] [IMPORTE]
        ' Los separadores " x " y "   " miden 3 chars cada uno, igual que en el Header.
        Dim linea As String = String.Format("{0} x {1}   {2}", sCant, sPrec, sTot)

        ' 5. ALINEACIÓN FINAL
        ' Empujamos todo a la derecha. 
        ' El espacio sobrante a la izquierda queda vacío (o para el nombre del artículo si quisieras ponerlo ahí).
        Return linea.PadLeft(Globales.numletras)
    End Function

    Private Function Centra(texto As String) As String
        If texto Is Nothing Then texto = ""
        texto = texto.Trim()
        If texto.Length >= Globales.numletras Then Return Left(texto, Globales.numletras)
        Dim espacios As Integer = (Globales.numletras - texto.Length) \ 2
        Return texto.PadLeft(texto.Length + espacios).PadRight(Globales.numletras)
    End Function

    Private Function Justifica(izq As String, der As String) As String
        izq = izq.Trim()
        der = der.Trim()
        Dim espacioDisponible As Integer = Globales.numletras - izq.Length - der.Length
        If espacioDisponible < 1 Then espacioDisponible = 1
        If (izq.Length + espacioDisponible + der.Length) > Globales.numletras Then
            Dim maxIzq As Integer = Globales.numletras - der.Length - 1
            If maxIzq > 0 Then izq = Left(izq, maxIzq)
        End If
        Return izq & StrDup(Math.Max(1, Globales.numletras - izq.Length - der.Length), " ") & der
    End Function

    Public ReadOnly Property COLECCION() As Collection
        Get
            Return renglones
        End Get
    End Property

End Class
