Imports System.Data.SqlClient

Public Class pretiempoaire
    Private spread As FarPoint.Win.Spread.FpSpread
    Private tipo As Integer
    Private renglones As New Collection
    Private sDireccion() As String
    Private sNomina, sNombre, sTotal As String
    Private enter As Char = Chr(13)
    Private line As Char = Chr(10)
    Dim scambio As String
    Dim numt As String
    Dim iva As Double
    Dim subt As Double
    Dim losqueno As Double
    Dim xcon As SqlConnection
    Dim sql As String
    Dim i As Integer
    Dim llevavale As Integer



    Public Sub New(ByVal numtic As String, ByRef con As SqlConnection)
        Dim dsc As New DataSet
        Dim dsc1 As New DataSet
        Dim xtexto As String
        xcon = con
        
        renglones.Add(centra(Globales.grupo))
        renglones.Add(centra(Globales.empresa))
        renglones.Add(centra(Globales.rfc))
        renglones.Add(centra(Globales.dir1))
        renglones.Add(centra(Globales.dir2))
        renglones.Add(centra(Globales.DIR3))
        renglones.Add(centra(Globales.CIUDAD))


        renglones.Add("  ")
        renglones.Add(centra("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString))
        renglones.Add(centra("Cajero: " & Globales.NombreEmpleado))

        renglones.Add("  ")
        renglones.Add(centra("# ticket: " & numtic))
        renglones.Add("  ")

        renglones.Add(centra("COMPROBANTE TIEMPO AIRE "))
        xtexto = ""
        renglones.Add("  ")

        sql = "SELECT * FROM TMPAUXVTA WHERE TMP_USUARIO='" & Globales.caja & "'"

        Base.daQuery(sql, xcon, dsc1, "IMPRIME")

        If dsc1.Tables("IMPRIME").Rows.Count > 0 Then
            For i = 0 To dsc1.Tables("IMPRIME").Rows.Count - 1

                sql = "SELECT * FROM ECDETVENTATEL WHERE DVE_VENTA=" & numtic
                Base.daQuery(sql, xcon, dsc1, "FOLIOS")
                If dsc1.Tables("FOLIOS").Rows.Count > 0 Then
                    If CDbl(dsc1.Tables("imprime").Rows(i)("tmp_cantidad")) <> 0 Then
                        renglones.Add(dsc1.Tables("imprime").Rows(i)("tmp_dscart"))
                        '            renglones.Add("MONTO:" & Format(CDbl(dsc1.Tables("imprime").Rows(i)("tmp_precio"))))
                        renglones.Add("TELEFONO:" & dsc1.Tables("FOLIOS").Rows(i)("DVE_TELEFONO"))
                        renglones.Add("FOLIO AUTORIZACION:" & dsc1.Tables("FOLIOS").Rows(i)("DVE_FOLIO"))
                        '                renglones.Add("FECHA :" & dsc1.Tables("FOLIOS").Rows(i)("DVE_FECHA"))
                        renglones.Add("  ")

                    End If
                End If
            Next i

        End If
        dsc1.Tables.Remove("imprime")

        renglones.Add(centra("Estimado Cliente en caso de "))
        renglones.Add(centra("presentar algún problema con su "))
        renglones.Add(centra("tiempo aire favor comunicarse"))
        renglones.Add(centra("a atención a clientes desde "))
        renglones.Add(centra("su celular"))
        renglones.Add("Vigencia tiempo abonado : 30 DIAS ")


        renglones.Add(centra(xtexto))


        guardaFooter(xtexto)
        renglones.Add(enter)

    End Sub
    Private Function centra(ByVal texto As String) As String
        centra = Space(Int((Globales.numletras - Len(texto.Trim)) / 2)) & texto.Trim
    End Function
    Private Function DERECHA(ByVal TEXTO As String) As String
        DERECHA = Space(Globales.numletras - Len(TEXTO.Trim)) & TEXTO.Trim
    End Function


    Private Function tabula(ByVal cant As String, ByVal art As String, ByVal unit As String, ByVal importe As String) As String

        While cant.Length < 4
            cant = " " & cant
        End While


        art = Left(art & Space(20), Globales.numletras - 20)


        'art = Left(art, 14)

        'While art.Length < 16
        'art = art & " "
        'End While



        While unit.Length < 6
            unit = " " & unit
        End While

        While importe.Length < 7
            importe = " " & importe
        End While



        Return cant & " " & art & " " & unit & " " & importe

    End Function


    Private Sub guardaFooter(ByVal XTEXTO As String)
        
        renglones.Add(centra("GRACIAS, LO ATENDIO: " & sNombre))
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
