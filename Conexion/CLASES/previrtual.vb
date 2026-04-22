Imports System.Data.SqlClient
Imports System.Text

Public Class previrtual
    Private renglones As New Collection
    Private NumTicket As String
    Private FechaDocumento As DateTime

    ' --------------------------------------------------------------------------------
    ' 1. CONSTRUCTOR LIMPIO
    ' --------------------------------------------------------------------------------
    Public Sub New(ByVal numtic As String)
        NumTicket = numtic

        ' 1. Obtenemos la fecha real del encabezado
        CargarEncabezado(NumTicket)

        ' 2. Generamos el documento
        GenerarDocumento()
    End Sub

    ' --------------------------------------------------------------------------------
    ' 2. DATOS
    ' --------------------------------------------------------------------------------
    Private Sub CargarEncabezado(idVenta As String)
        Dim sql As String = "SELECT ven_fecha FROM ECVENTA WHERE ven_id = " & idVenta
        Dim ds As New DataSet
        Base.daQuery(sql, sCadenaConexionSQL, ds, "Head")

        If ds.Tables("Head").Rows.Count > 0 Then
            If IsDBNull(ds.Tables("Head").Rows(0)("ven_fecha")) Then
                FechaDocumento = Now
            Else
                FechaDocumento = CDate(ds.Tables("Head").Rows(0)("ven_fecha"))
            End If
        Else
            FechaDocumento = Now
        End If
    End Sub

    ' --------------------------------------------------------------------------------
    ' 3. CONSTRUCCIÓN DEL VALE
    ' --------------------------------------------------------------------------------
    Private Sub GenerarDocumento()
        ' --- ENCABEZADO ---
        'renglones.Add(Centra(Globales.grupo))
        'renglones.Add(Centra(Globales.empresa))
        'renglones.Add(Centra(Globales.rfc))
        'renglones.Add(Centra(Globales.dir1))
        'renglones.Add(Centra(Globales.dir2))
        'renglones.Add(Centra(Globales.DIR3))
        'renglones.Add(" ")

        ' 1. FECHA CON FORMATO AM/PM Y PREFIJO (IGUAL QUE PREIMPRESION)
        Dim sFecha As String = "Fecha: " & FechaDocumento.ToString("dd/MM/yyyy hh:mm:ss tt")
        Dim sCaja As String = "Caja: " & Right(Globales.caja, 1)
        renglones.Add(Justifica(sFecha, sCaja))

        ' 2. ESPACIO ENTRE FECHA Y CAJERO
        'renglones.Add(" ")

        Dim sCajero As String = "Cajero: " & Left(Globales.NombreEmpleado, 12)
        Dim sTicket As String = "# Ticket: " & NumTicket
        renglones.Add(Justifica(sCajero, sTicket))

        renglones.Add(" ")
        renglones.Add(StrDup(Globales.numletras, "-"))
        renglones.Add(Centra("VALE DE ENTREGA DE MERCANCIA PENDIENTE"))
        renglones.Add(StrDup(Globales.numletras, "-"))

        ' 3. ENCABEZADO DE COLUMNAS (Alineación Matemática - COPIADO DE PREIMPRESION)
        ' Importe: $999,999.99 (11 chars)
        ' Precio:  $9,999.99   (9 chars)
        ' Cant:    99.999      (6 chars)

        Dim hCant As String = "CANT".PadLeft(6)
        Dim hSep1 As String = "   "   ' 3 espacios (equivale a " x ")
        Dim hPrec As String = "PRECIO".PadLeft(9)
        Dim hSep2 As String = "   "   ' 3 espacios (separador)
        Dim hImp As String = "IMPORTE".PadLeft(11)

        ' Construimos el bloque derecho
        Dim HeaderDerecho As String = hCant & hSep1 & hPrec & hSep2 & hImp

        ' Integración con "ARTICULO" (Izquierda)
        Dim EspacioIzquierdo As Integer = Globales.numletras - HeaderDerecho.Length
        Dim LineaFinal As String = ""

        If EspacioIzquierdo > 0 Then
            Dim TituloIzq As String = "ARTICULO"
            If TituloIzq.Length > EspacioIzquierdo Then TituloIzq = Left(TituloIzq, EspacioIzquierdo)
            LineaFinal = TituloIzq.PadRight(EspacioIzquierdo) & HeaderDerecho
        Else
            LineaFinal = HeaderDerecho
        End If

        renglones.Add(LineaFinal)
        renglones.Add(StrDup(Globales.numletras, "-"))

        ' --- DETALLE (LEYENDO DE ECVENTADETE) ---
        Dim sql As String = "SELECT " &
                            "dve_cantidad, " &
                            "dve_precio, " &
                            "dve_total, " &
                            "A.upc_descripcion as Descripcion " &
                            "FROM ECVENTADETE V " &
                            "LEFT JOIN xupc A ON V.dve_upc = A.upc_upc " &
                            "WHERE dve_venta = '" & NumTicket & "'"

        Dim ds As New DataSet
        Base.daQuery(sql, sCadenaConexionSQL, ds, "Vale")

        For Each row As DataRow In ds.Tables("Vale").Rows
            Dim Cant As Decimal = CDec(row("dve_cantidad"))
            Dim Prec As Decimal = CDec(row("dve_precio"))
            Dim Tot As Decimal = CDec(row("dve_total"))
            Dim Desc As String = row("Descripcion").ToString()

            ' Imprimimos Descripción
            renglones.Add(Left(Desc, Globales.numletras))

            ' Imprimimos Montos (Usando TabulaPro actualizada)
            renglones.Add(TabulaPro(Cant, Prec, Tot))
        Next

        renglones.Add(StrDup(Globales.numletras, "-"))

        ' Espacio para firma (Descomentar si se requiere)
        'renglones.Add(" ")
        'renglones.Add(" ")
        'renglones.Add(Centra("__________________________"))
        'renglones.Add(Centra("Firma de Conformidad"))
        'renglones.Add(" ")

        renglones.Add(Chr(13))
    End Sub

    ' --------------------------------------------------------------------------------
    ' HELPERS VISUALES (Estandarizados con preImpresion)
    ' --------------------------------------------------------------------------------

    Private Function TabulaPro(Cant As Decimal, Precio As Decimal, Total As Decimal) As String
        ' COPIADO EXACTO DE PREIMPRESION PARA MANTENER LA ALINEACIÓN

        ' 1. CANTIDAD (Ancho 6)
        Dim sCant As String = Cant.ToString("0.###").PadLeft(6)

        ' 2. PRECIO (Ancho 9)
        Dim sPrec As String = Format(Precio, "$#,##0.00").PadLeft(9)

        ' 3. IMPORTE (Ancho 11)
        Dim sTot As String = Format(Total, "$#,##0.00").PadLeft(11)

        ' 4. ARMADO DE LA LÍNEA
        ' Estructura: [CANT] [ x ] [PRECIO] [   ] [IMPORTE]
        Dim linea As String = String.Format("{0} x {1}   {2}", sCant, sPrec, sTot)

        ' 5. ALINEACIÓN FINAL
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