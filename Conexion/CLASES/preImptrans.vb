Imports System.Data.SqlClient
Public Class preImptrans
    Private spread As FarPoint.Win.Spread.FpSpread
    Private tipo As Integer
    Private renglones As New Collection
    Private sDireccion() As String
    Private sNomina, sNombre, sTotal As String
    Private enter As Char = Chr(13)
    Private line As Char = Chr(10)
    Dim scambio As String
    Dim numt As String

    Dim xcon As SqlConnection

    Public Sub New(ByVal cambio As String, ByRef Xspread As FarPoint.Win.Spread.FpSpread, ByVal sDirec As String(), ByVal sNomin As String, ByVal sNombr As String, ByVal sTot As String, ByVal numtic As String, ByRef con As SqlConnection, Optional ByVal Xtipo As Integer = 0)
        numt = numtic
        xcon = con
        sDireccion = sDirec
        spread = Xspread
        tipo = Xtipo
        sNomina = sNomin
        sNombre = sNombr
        sTotal = sTot
        scambio = cambio
        'ENCABEZADO
        renglones.Add(Globales.grupo)
        renglones.Add(Globales.empresa)
        renglones.Add(Globales.rfc)
        renglones.Add(Globales.dir1)
        renglones.Add(Globales.dir2)
        renglones.Add(Globales.DIR3)
        renglones.Add(Globales.CIUDAD)

        renglones.Add("          ")

        renglones.Add("  ")
        renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString)
        renglones.Add("Cajero: " & Globales.NombreEmpleado)
        renglones.Add("")

        renglones.Add("       TRANSFERENCIA DE ARTICULOS        ")
        renglones.Add("-----------------------------------------")
        renglones.Add("-----------------------------------------")
        renglones.Add("              # ticket: " & numtic)

        renglones.Add("  ")
        renglones.Add("CANT ARTICULO            P.U.    IMPORTE ")
        renglones.Add("-----------------------------------------")

        renglones.Add("  ")
        'COSAS
        With spread.ActiveSheet
            For i As Integer = 0 To .RowCount - 1
                renglones.Add(tabula(CDbl(.Cells(i, 0).Text.Trim), .Cells(i, 1).Text.Trim, .Cells(i, 2).Text.Trim, .Cells(i, 3).Text.Trim))
            Next
        End With

        renglones.Add("-----------------------------------------")


        guardaFooter()
        renglones.Add(enter)
        
    End Sub

    Private Function tabula(ByVal cant As String, ByVal art As String, ByVal unit As String, ByVal importe As String) As String
        '33

        While cant.Length < 4 '3
            cant = " " & cant
        End While
        art = Mid(art, 1, 17) '14
        While art.Length < 17 '16
            art = art & " "
        End While

        While unit.Length < 8
            unit = " " & unit
        End While

        While importe.Length < 9 '7
            importe = " " & importe
        End While
        Return cant & " " & art & " " & unit & " " & importe '16
        'Return cant & " " & Mid(art, 1, 20) & unit & " " & importe '16
    End Function

    Private Sub guardaFooter()
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer


        Dim oConv As New Conversion(CDbl(sTotal.Replace("$", "")))
        'Imprime espacio en blanco
        renglones.Add("  ")
        renglones.Add("            TOTAL " & sTotal.PadLeft(8, " "))
        renglones.Add("SON: " & oConv.numeroEnLetras)
        renglones.Add(enter)
        sql = "select sum(pago) as pago, tipo_pago, referencia, banco from ecformapago where referencia=" & CDbl(numt) & " group by tipo_pago,referencia,banco"
        Base.daQuery(sql, xcon, dsc, "pagos")
        renglones.Add("-----------------------------------------")
        renglones.Add("Su Pago:")

        renglones.Add(enter)





            If dsc.Tables("pagos").Rows.Count > 0 Then
                For i = 0 To dsc.Tables("pagos").Rows.Count - 1
                    renglones.Add(Left(dsc.Tables("pagos").Rows(i)("tipo_pago") & Space(10), 10) & "  " & Left(dsc.Tables("pagos").Rows(i)("banco") & Space(10), 10) & "   " & Format(CDbl(dsc.Tables("pagos").Rows(i)("pago")), "###,##0.00"))
                Next
            End If
            renglones.Add(enter)
            dsc.Tables.Remove("pagos")
            renglones.Add("                  " & scambio.PadLeft(8, " "))
            renglones.Add("  ")
            renglones.Add(enter)
            renglones.Add("GRACIAS, LO ATENDIO: " & sNombre)
            renglones.Add(enter)
            renglones.Add(enter)




            ' renglones.Add(Chr(27) + Chr(112) + Chr(0) + Chr(40) & Chr())

    End Sub

    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property
End Class
