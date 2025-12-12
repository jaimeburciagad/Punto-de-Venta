Public Class preretiros

    'Private spread As FarPoint.Win.Spread.FpSpread
        Private renglones As New Collection
        Private sDireccion() As String
        Private enter As Char = Chr(13)
        Private line As Char = Chr(10)
    Public Sub New(ByRef cantidad As Double, ByRef concepto As String, ByRef spread As FarPoint.Win.Spread.FpSpread, ByRef tipo As Integer)
        'ENCABEZADO
        Dim oConv As New Conversion(cantidad)

        renglones.Add(Globales.grupo)
        renglones.Add(Globales.empresa)
        renglones.Add(Globales.rfc)
        renglones.Add(Globales.dir1)
        renglones.Add(Globales.dir2)
        renglones.Add(Globales.DIR3)
        renglones.Add(Globales.CIUDAD)
        renglones.Add("  ")
        renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString)
        If Globales.caja = "vscaja7" Then
            renglones.Add("Caja:    #" & CAJARET)
        Else
            renglones.Add("Caja:" & Globales.caja)
        End If
        renglones.Add("Cajero: " & Globales.NombreEmpleado)
        renglones.Add("  ")
        renglones.Add("------------------------------------")
        renglones.Add(enter)
        renglones.Add("Vale por la cantidad de:")
        renglones.Add(enter)
        renglones.Add("             " & Format(cantidad, "$###,##0.00"))
        renglones.Add(enter)
        renglones.Add("SON: " & oConv.numeroEnLetras)
        renglones.Add(enter)
        renglones.Add("CONCEPTO:" & concepto.ToUpper)
        renglones.Add(enter)
        renglones.Add("___________________________________")
        If tipo = 1 Then
            renglones.Add(" Cant     Denominacion  Importe")
            renglones.Add("____________________________________")

        End If
        For i As Integer = 0 To spread.ActiveSheet.RowCount - 1
            If CDbl(spread.ActiveSheet.Cells(i, 2).Value) > 0 Then
                renglones.Add(Space(2) & Right(Space(7) & Format(spread.ActiveSheet.Cells(i, 0).Value, "###0.00"), 7) & Space(2) & Right(Space(7) & Format(spread.ActiveSheet.Cells(i, 4).Value, "##0.00"), 7) & Space(5) & Right(Space(10) & Format(spread.ActiveSheet.Cells(i, 2).Value, "###,##0.00"), 10))
            End If

        Next
        renglones.Add("-------------------------------------")
        renglones.Add("TOTAL            " & Format(cantidad, "###,##0.00"))
        renglones.Add("-------------------------------------")
        renglones.Add(enter)
        renglones.Add(enter)


    End Sub




    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

End Class
