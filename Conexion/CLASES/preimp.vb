Imports System.Data.SqlClient
Public Class preimp
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

    Public Sub New(ByRef con As SqlConnection,byref cliente as String,byref totalpago as String)
        xcon = con
        'ENCABEZADO

        renglones.Add(Globales.grupo)
        renglones.Add(Globales.empresa)
        renglones.Add(Globales.rfc)
        renglones.Add(Globales.dir1)
        renglones.Add(Globales.dir2)
        renglones.Add(Globales.DIR3)
        renglones.Add(Globales.CIUDAD)
        renglones.Add("  ")
        renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString)
     
        renglones.Add("  ")


        renglones.Add("  ")
        renglones.Add("---------------------------------")
        renglones.Add("Pago de Credito")
        renglones.Add("---------------------------------")


        renglones.Add("Cliente : " & cliente)
        renglones.Add("Pago :    $" & totalpago)
        'COSAS
     
        renglones.Add("---------------------------------")


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
    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property
End Class
