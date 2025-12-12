Public Class predinero

        Private spread As FarPoint.Win.Spread.FpSpread
        Private renglones As New Collection
        Private sDireccion() As String
        Private enter As Char = Chr(13)
        Private line As Char = Chr(10)
    Public Sub New(ByRef TICKET As String, ByRef importe As Double, ByVal Caja As Integer, ByVal DevDescr As String)
        'ENCABEZADO
        Dim oConv As New Conversion(importe)

        renglones.Add(Globales.grupo)
        renglones.Add(Globales.empresa)
        renglones.Add(Globales.rfc)
        renglones.Add(Globales.dir1)
        renglones.Add(Globales.dir2)
        renglones.Add(Globales.DIR3)
        renglones.Add(Globales.CIUDAD)
        renglones.Add("  ")
        renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString)
        renglones.Add("Cajero: " & Globales.NombreEmpleado)
        renglones.Add("Caja: " & Caja)
        renglones.Add("  ")
        renglones.Add("-------------------------------------")
        renglones.Add("    COMPROBANTE DE SALIDA DE CAJA    ")
        renglones.Add("     POR DEVOLUCION DE MERCANCIA    ")
        renglones.Add(enter)
        renglones.Add("=====================================")
        renglones.Add(enter)
        renglones.Add("No. Ticket Dev: " & TICKET)
        renglones.Add(enter)

        If DevDescr.Length <= Globales.numletras Then
            renglones.Add(DevDescr)
        Else
            Dim i As Integer = 0
            Do Until Strings.Mid(DevDescr, Globales.numletras - i, 1) = " "
                i += 1
            Loop

            renglones.Add(Strings.Left(DevDescr, Globales.numletras - i))
            renglones.Add(Strings.Mid(DevDescr, Globales.numletras - i + 1))
        End If

        renglones.Add(enter)
        renglones.Add("Importe Dev:    " & Format(importe, "$###,##0.00"))
        renglones.Add("SON: " & oConv.numeroEnLetras)
        renglones.Add(enter)
        renglones.Add("=======================================")

    End Sub



    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

End Class
