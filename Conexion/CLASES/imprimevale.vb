Imports System.Drawing.Printing
Imports System.IO

Public Class imprimevale
    'no se usa
    Private spread As FarPoint.Win.Spread.FpSpread
    Private renglones As New Collection
    Private encabezado As New Collection
    Private lineas As Collection

    Friend WithEvents print As New PrintDocument

    Public Sub New(ByRef Xspread As FarPoint.Win.Spread.FpSpread, ByVal hhhh As Boolean)
        spread = Xspread

    End Sub

    Public Sub New(ByRef reng As Collection, ByVal hhhh As Boolean)
        lineas = reng
    End Sub

    Public ReadOnly Property getSpread()
        Get
            Return spread
        End Get
    End Property


    Public Sub imprime()

        Dim PrSet As New Printing.PrinterSettings
        Dim PgSet As New Printing.PageSettings
        Dim Impresora As String


        For Each Impresora In Printing.PrinterSettings.InstalledPrinters
            If InStr(Impresora.ToUpper, "TM") Then
                PrSet.PrinterName = Impresora
                Exit For
            End If
        Next Impresora


        print.PrinterSettings = PrSet
        print.Print()
    End Sub

    Private Sub print_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles print.PrintPage
        Dim Posy As Single = 0
        Dim leftMargin As Single = 0 'ev.MarginBounds.Left
        Dim topMargin As Single = 0 ' ev.MarginBounds.Top
        Dim printFont As New Font("Lucida Console", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        Dim count As Integer = 0

        For Each st As String In lineas
            Posy = (topMargin + (count * (printFont.GetHeight(e.Graphics) + 2)))
            e.Graphics.DrawString(st, printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
            count += 1
        Next
        myBrush.Dispose()
    End Sub

    Private Function tabula(ByVal cant As String, ByVal art As String, ByVal unit As String, ByVal importe As String) As String
        While cant.Length < 3
            cant = "0" & cant
        End While

        While art.Length < 16
            art = art & " "
        End While

        While unit.Length < 7
            unit = " " & unit
        End While

        While importe.Length < 8
            importe = " " & importe
        End While

        Return cant & "  " & art & unit & " " & importe
    End Function
    Private Sub imprimeEncabezado(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal iMargen As Single, ByVal leftMargin As Single, ByRef Posy As Single, ByVal printFont As Font, ByVal myBrush As SolidBrush, ByRef iCuenta As Integer)
        For Each st As String In encabezado
            Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
            e.Graphics.DrawString(st, printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
            iCuenta += 1
        Next
        If Not IsNothing(sDireccion) AndAlso sDireccion.Length >= 1 Then
            For j As Integer = 0 To sDireccion.Length - 1
                Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
                e.Graphics.DrawString(sDireccion(j), printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
                iCuenta += 1
            Next j
        End If

    End Sub

End Class
