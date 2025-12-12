Imports System.Data.SqlClient
Public Class previrtual
    Private spread As FarPoint.Win.Spread.FpSpread
    Private renglones As New Collection
    Private sDireccion() As String
    Private enter As Char = Chr(13)
    Private line As Char = Chr(10)

    Public Sub New(ByRef Xspread As FarPoint.Win.Spread.FpSpread, ByRef numtic As String, ByRef con As SqlConnection)
        Dim Espacios As String
        spread = Xspread
        'ENCABEZADO

        renglones.Add(centra(Globales.grupo))
        renglones.Add(centra(Globales.empresa))
        renglones.Add(centra(Globales.rfc))
        renglones.Add(centra(Globales.dir1))
        renglones.Add(centra(Globales.dir2))
        renglones.Add(centra(Globales.DIR3))
        renglones.Add(" ")

        Espacios = " "
        While Len("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString & Espacios & "Caja: " & Right(Globales.caja, 1)) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString & Espacios & "Caja: " & Right(Globales.caja, 1))

        Espacios = " "
        While Len("Cajero: " & Globales.NombreEmpleado & Espacios & "# Ticket: " & numtic) < Globales.numletras
            Espacios = " " & Espacios
        End While

        renglones.Add(" ")
        renglones.Add("Cajero: " & Globales.NombreEmpleado & Espacios & "# Ticket: " & numtic)

        renglones.Add("----------------------------------------")
        renglones.Add(" VALE DE ENTREGA DE MERCANCIA PENDIENTE")
        renglones.Add("----------------------------------------")
        'COSAS
        Dim j As Integer
        j = 0
        'With spread.ActiveSheet

        Dim SQL As String
        Dim DSC As New DataSet

        SQL = "select e.*, xupc.UPC_DESCRIPCION from ecventadete e join xupc on dve_upc=upc_upc where dve_venta='" & numtic & "'"
        Base.daQuery(SQL, con, DSC, "Vale")
        If DSC.Tables("Vale").Rows.Count > 0 Then
            For i As Integer = 0 To DSC.Tables("Vale").Rows.Count - 1
                renglones.Add(Left(DSC.Tables("Vale").Rows(i)("upc_descripcion"), Globales.numletras))
                renglones.Add(tabula(Math.Round(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), 3), DSC.Tables("Vale").Rows(i)("upc_descripcion"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")), "##0.00"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")) * CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), "###0.00")))
                'renglones.Add(tabula(Math.Round(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), 3), DSC.Tables("Vale").Rows(i)("upc_descripcion"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")), "##0.00"), Format(CDbl(DSC.Tables("Vale").Rows(i)("DVE_Precio")) * CDbl(DSC.Tables("Vale").Rows(i)("DVE_Cantidad")), "###0.00")))
            Next
            renglones.Add("----------------------------------------")
        End If
        DSC.Tables.Remove("Vale")

    End Sub

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
    End Function

    Private Function centra(ByVal texto As String) As String
        centra = Space(Int((Globales.numletras - Len(texto.Trim)) / 2)) & texto.Trim
    End Function

    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

End Class
