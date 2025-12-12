Imports System.Drawing.Printing
Imports System.IO
Imports System
Imports Scripting



Public Class imp
    'ya no se usa

    Private spread As FarPoint.Win.Spread.FpSpread
    Private tipo As Integer
    'Private renglones As New Collection
    Private encabezado As New Collection
    Private sDireccion() As String
    Private sNomina, sNombre, sTotal As String
    Private lineas As Collection
    Dim objFSO As New FileSystemObject 'file system object

    Friend WithEvents printdocument1 As New PrintDocument
    Public Sub New(ByRef Xspread As FarPoint.Win.Spread.FpSpread, ByVal sDirec As String(), ByVal sNomin As String, ByVal sNombr As String, ByVal sTot As String, ByVal hhh As Boolean, Optional ByVal Xtipo As Integer = 0)
        sDireccion = sDirec
        spread = Xspread
        tipo = Xtipo
        sNomina = sNomin
        sNombre = sNombr
        sTotal = sTot

        encabezado.Add(Globales.grupo)
        encabezado.Add(Globales.empresa)
        encabezado.Add(Globales.rfc)
        encabezado.Add(Globales.dir1)
        encabezado.Add(Globales.dir2)
        encabezado.Add(Globales.DIR3)
        encabezado.Add(Globales.CIUDAD)
        encabezado.Add("")
        'cazzxrint.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("custom", 1480, 100000)

    End Sub

    Public Sub New(ByRef reng As Collection, ByVal hhh As Boolean)
        'print.DefaultPageSettings.PaperSize = New PaperSize("custom", 1480, 100000)
        ' print.PrinterSettings.DefaultPageSettings.PaperSize = New PaperSize("custom", 1480, 100000)
        lineas = reng
    End Sub

    Public ReadOnly Property getSpread()
        Get
            Return spread
        End Get
    End Property

    Public ReadOnly Property getTipo()
        Get
            Return tipo
        End Get
    End Property
    Dim fileToPrint As System.IO.StreamReader
    Dim printFont As System.Drawing.Font

    Public Sub imprimecuandop()
        'Dim count As Integer = 0
        Dim objTextOut As TextStream            'text stream
        With objFSO
            objTextOut = .CreateTextFile("c:\ticket.txt", True)
            For Each st As String In lineas
                'Posy = (topMargin + (count * (printFont.GetHeight(e.Graphics) + 2)))
                'e.Graphics.DrawString(st, printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
                objTextOut.WriteLine(st)

                'count += 1
            Next


            objTextOut.Close()
            Dim PrintPath As String = System.Environment.
            GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            fileToPrint = New System.IO.StreamReader("c:\ticket.txt")
            printFont = New System.Drawing.Font("Lucida Console", 8)

            Dim PrSet As New Printing.PrinterSettings
            Dim PgSet As New Printing.PageSettings
            Dim Impresora As String


            For Each Impresora In Printing.PrinterSettings.InstalledPrinters
                If InStr(Impresora.ToUpper, "TM") Then
                    PrSet.PrinterName = Impresora
                    Exit For
                End If
            Next Impresora

            printdocument1.PrinterSettings = PrSet

            ' Suppress the print dialog
            printdocument1.PrintController = New System.Drawing.Printing.StandardPrintController()


            printdocument1.Print()


            fileToPrint.Close()
        End With
    End Sub

    Public Sub OpenCashDrawer()
        Dim PrSet As New Printing.PrinterSettings
        Dim Impresora As String

        ' Find the TM printer
        For Each Impresora In Printing.PrinterSettings.InstalledPrinters
            If InStr(Impresora.ToUpper, "TM") Then
                PrSet.PrinterName = Impresora
                Exit For
            End If
        Next Impresora

        If String.IsNullOrEmpty(PrSet.PrinterName) Then
            MsgBox("No valid TM printer found.", vbExclamation, "Printer Error")
            Exit Sub
        End If

        ' ESC/POS command to open the cash drawer
        Dim drawerCommand As String = Chr(&H1B) & "p" & Chr(0) & Chr(25) & Chr(250)

        ' Send the command to the printer
        If Not RawPrinterHelper.SendStringToPrinter(PrSet.PrinterName, drawerCommand) Then
            MsgBox("Failed to open the cash drawer.", vbCritical, "Error")
        Else
            MsgBox("Cash drawer opened successfully.", vbInformation, "Success")
        End If
    End Sub



    Private Sub PrintDocument1_Printage(ByVal sender As Object, ByVal e As _
       System.Drawing.Printing.PrintPageEventArgs) Handles _
       printdocument1.PrintPage
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = e.MarginBounds.Left - 100
        Dim topMargin As Single = e.MarginBounds.Top - 90
        Dim line As String = Nothing
        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)
        While count < linesPerPage
            line = fileToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(e.Graphics)
            e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, _
               yPos, New StringFormat)
            count += 1
        End While
        If Not (line Is Nothing) Then
            e.HasMorePages = True
        End If
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
        'For i As Integer = 0 To sEncabezado.Length - 1
        '    Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        '    e.Graphics.DrawString(sEncabezado(i), printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        '    iCuenta += 1
        'Next i
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
        ' Imprime fecha
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("Fecha: " & Now.ToShortDateString & " " & Now.ToShortTimeString, printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime cajero
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("Cajero: " & sNomina, printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime espacio en blanco
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("  ", printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime encabezados
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("CANT ARTICULO            P.U.    IMPORTE ", printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime linea
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("-----------------------------------------", printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

    End Sub

    Private Sub imprimeFooter(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal iMargen As Single, ByVal leftMargin As Single, ByRef Posy As Single, ByVal printFont As Font, ByVal myBrush As SolidBrush, ByRef iCuenta As Integer)
        Dim oConv As New Conversion(CDbl(sTotal.Replace("$", "")))
        'Imprime espacio en blanco
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("  ", printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime importe
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("                         IMPORTE " & sTotal.PadLeft(8, " "), printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime total
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("                           TOTAL " & sTotal.PadLeft(8, " "), printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime espacio en blanco
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("  ", printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime cantidad en letra
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("SON: " & oConv.numeroEnLetras, printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

        'Imprime nombre
        Posy = (iMargen + (iCuenta * (printFont.GetHeight(e.Graphics) + 2)))
        e.Graphics.DrawString("GRACIAS, LO ATENDIÓ: " & sNombre, printFont, myBrush, leftMargin, Posy, New StringFormat(StringFormatFlags.DisplayFormatControl))
        iCuenta += 1

    End Sub
End Class

