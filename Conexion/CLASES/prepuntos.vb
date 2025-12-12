
Imports System.Data.SqlClient

Public Class prepuntos
    Private spread As FarPoint.Win.Spread.FpSpread
    Private renglones As New Collection
    Private sDireccion() As String
    Private enter As Char = Chr(13)
    Private line As Char = Chr(10)

    Public Sub New(ByRef numtic As String, ByRef con As SqlConnection)
        Dim SQL As String
        Dim DSC As New DataSet

        
        renglones.Add(Globales.grupo)
        renglones.Add(Globales.empresa)
        renglones.Add(Globales.rfc)
        renglones.Add(Globales.dir1)
        renglones.Add(Globales.dir2)
        renglones.Add(Globales.DIR3)
        renglones.Add(Globales.CIUDAD)
        renglones.Add(enter)

        renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString)
        renglones.Add(enter)


        renglones.Add("Cajero: " & Globales.NombreEmpleado)
        renglones.Add(enter)

        renglones.Add("                 # ticket: " & numtic)
        renglones.Add("----------------------------------------")
        renglones.Add(enter)
        renglones.Add("       CUPON PARA CANJE DE PUNTOS")
        renglones.Add("               COSTEÑA")
        renglones.Add("----------------------------------------")
        renglones.Add(enter)

        'COSAS


        SQL = "SELECT * FROM ECCANJEPUNTOS INNER JOIN ARTICULO ON ART_CLAVE=CANJE_ARTICULO WHERE CANJE_TICKET=" & numtic
        Base.daQuery(SQL, con, DSC, "PUNTOS")

        Dim j As Integer
        Dim xtotal As Integer
        j = 0
        xtotal = 0

        'With spread.ActiveSheet
        For j = 0 To DSC.Tables("PUNTOS").Rows.Count - 1
            renglones.Add(tabula(CDbl(DSC.Tables("PUNTOS").Rows(j)("CANJE_CANTIDAD")), (DSC.Tables("PUNTOS").Rows(j)("ART_NOMCORTO")), CDbl(DSC.Tables("PUNTOS").Rows(j)("CANJE_PUNTOS"))))
            xtotal = xtotal + CDbl(DSC.Tables("PUNTOS").Rows(j)("CANJE_PUNTOS"))
        Next j

        DSC.Tables.Remove("PUNTOS")

        renglones.Add("----------------------------------------")

        renglones.Add("TOTAL PUNTOS  " & xtotal.ToString)

        renglones.Add("PUNTOS CANJEABLES EN ")
        renglones.Add(Globales.grupo)
        renglones.Add(Globales.dir1)
        renglones.Add("PROMOCION VALIDA HASTA EL 30 ")
        renglones.Add("        DE ABRIL 2015")

        'End With

        'While j < 10
        'renglones.Add(enter)
        'renglones.Add(enter)


        'j += 1

        'End While

        renglones.Add("----------------------------------------")

    End Sub

    Private Function tabula(ByVal cant As String, ByVal art As String, ByVal UNIT As String) As String
        While cant.Length < 3
            cant = " " & cant
        End While
        art = Left(art, 19)
        While art.Length < 20
            art = art & " "
        End While
        While UNIT.Length < 7
            UNIT = " " & UNIT
        End While
       
        Return cant & " " & Left(art, 20) & UNIT
    End Function


    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

End Class
