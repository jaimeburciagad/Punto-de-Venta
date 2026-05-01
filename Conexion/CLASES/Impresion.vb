Imports System.Drawing.Printing
Imports System.Drawing
Imports System.IO

Public Class Impresion
    ' --- VARIABLES GLOBALES DE LA CLASE ---
    Private _lineas As List(Of String)
    Private _ticketID As String ' <--- AQUÍ GUARDAMOS EL ID PARA EL BARCODE

    ' Configuración visual
    Private _fuente As Font
    Private _lineaActual As Integer = 0

    ' AJUSTA ESTA RUTA A DONDE TENGAS TU LOGO (O déjala así si no usarás logo aún)
    'Private _rutaLogo As String = "C:\Sistema\Logo.png"
    Private _rutaLogo As String = System.IO.Path.Combine(Application.StartupPath, "Logo.png")

    ' --- CACHÉ DE IMPRESORA (Optimización de Velocidad) ---
    ' Shared = Se mantiene en memoria mientras el programa esté abierto
    Private Shared _impresoraCache As String = ""
    Private _impresoraUsar As String = ""

    Friend WithEvents printDoc As New PrintDocument

    ' =================================================================================
    ' CONSTRUCTOR
    ' Recibe:
    ' 1. La colección de texto (Compatibilidad con tu código viejo)
    ' 2. El TicketID (NUEVO: Para el código de barras)
    ' 3. ImpresoraEspecifica (OPCIONAL: Por si el usuario eligió una manual)
    ' =================================================================================
    Public Sub New(ByVal coleccion As Collection, Optional ByVal TicketID As String = "", Optional ByVal ImpresoraEspecifica As String = "")

        ' 1. Convertimos Collection a List (Más rápido y moderno)
        _lineas = New List(Of String)
        For Each item As String In coleccion
            _lineas.Add(item)
        Next

        ' 2. Guardamos el ID
        _ticketID = TicketID

        ' 3. Definimos la fuente (Lucida Console para que se alineen las columnas)
        _fuente = New Font("Lucida Console", 8, FontStyle.Regular)

        ' 4. LÓGICA INTELIGENTE DE SELECCIÓN DE IMPRESORA
        If ImpresoraEspecifica <> "" Then
            ' Caso A: Nos mandaron una específica (ej. Cocina)
            _impresoraUsar = ImpresoraEspecifica
            ' Opcional: ¿Queremos que esta se vuelva la default? Si sí, descomenta la siguiente línea:
            ' _impresoraCache = ImpresoraEspecifica 

        ElseIf _impresoraCache <> "" Then
            ' Caso B: Ya habíamos encontrado la impresora antes. Usamos la memoria.
            _impresoraUsar = _impresoraCache

        Else
            ' Caso C: Es la primera vez. Buscamos una EPSON/TM/POS.
            For Each imp As String In PrinterSettings.InstalledPrinters
                If imp.ToUpper().Contains("TM") Or imp.ToUpper().Contains("EPSON") Or imp.ToUpper().Contains("POS") Or imp.ToUpper().Contains("BIXOLON") Then
                    _impresoraCache = imp ' ¡La guardamos para siempre!
                    _impresoraUsar = imp
                    Exit For
                End If
            Next

            ' Si de plano no hallamos nada, usamos la default de Windows
            If _impresoraUsar = "" Then
                _impresoraUsar = (New PrinterSettings).PrinterName
                _impresoraCache = _impresoraUsar
            End If
        End If
    End Sub

    ' =================================================================================
    ' MÉTODO IMPRIME
    ' =================================================================================
    Public Sub imprime(ByVal AbreCajon As Boolean)
        If _lineas.Count = 0 Then Exit Sub

        Try
            printDoc.PrinterSettings.PrinterName = _impresoraUsar

            ' Silenciar el diálogo de "Imprimiendo..."
            printDoc.PrintController = New StandardPrintController()

            ' Esto pone los márgenes lógicos en 0, para que no empuje el texto.
            printDoc.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)

            ' Configurar "Rollo Infinito" (Alto exagerado para que no corte)
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Ticket", 285, 50000)

            ' 1. ABRIR CAJÓN (Físico)
            If AbreCajon Then AbrirCajon()

            ' 2. IMPRIMIR (Gráfico)
            printDoc.Print()

        Catch ex As Exception
            MsgBox("Error al imprimir en '" & _impresoraUsar & "': " & ex.Message, vbCritical)
            ' Si falló, borramos la caché para obligar a buscar de nuevo la próxima vez
            _impresoraCache = ""
        End Try
    End Sub

    ' =================================================================================
    ' EVENTO DE DIBUJADO (Aquí sucede la magia visual)
    ' =================================================================================
    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        Dim yPos As Single = 0
        Dim leftMargin As Single = 0  ' Ajusta si sale muy pegado a la izquierda
        Dim anchoPagina As Integer = 280 ' Ancho aprox para centrar (80mm)
        Dim altoRenglon As Single = _fuente.GetHeight(e.Graphics)

        ' --- A. DIBUJAR LOGO (Solo al inicio) ---
        If _lineaActual = 0 Then
            Try
                Using img As Image = My.Resources.DuarsaLogoTicket
                    ' Definimos el ancho máximo permitido para el logo (ej. 180 unidades = 4.5cm)
                    ' Esto evita que un logo gigante se coma los márgenes
                    Dim anchoMaxLogo As Integer = 180

                    ' Si la imagen es más chica que el máximo, usamos su tamaño original para no pixelear
                    Dim anchoFinal As Integer = Math.Min(img.Width, anchoMaxLogo)

                    ' Calculamos alto proporcional (Regla de 3)
                    Dim altoFinal As Integer = CInt((anchoFinal / img.Width) * img.Height)

                    ' Centrado Matemático: (AnchoPapel - AnchoImagen) / 2
                    Dim xImg As Integer = (anchoPagina - anchoFinal) / 2

                    ' Dibujamos
                    e.Graphics.DrawImage(img, xImg, CInt(yPos), anchoFinal, altoFinal)

                    ' Dejamos aire abajo del logo
                    yPos += altoFinal + 10
                End Using
            Catch
                ' Si falla el logo, no detenemos el ticket
            End Try
        End If

        ' --- B. DIBUJAR TEXTO (Línea por línea) ---
        While _lineaActual < _lineas.Count
            Dim linea As String = _lineas(_lineaActual)
            e.Graphics.DrawString(linea, _fuente, Brushes.Black, leftMargin, yPos)

            yPos += altoRenglon
            _lineaActual += 1

            ' Control de salto de página (Raro en tickets, pero necesario por seguridad)
            If yPos + 100 > e.MarginBounds.Height Then
                e.HasMorePages = True
                Return
            End If
        End While

        ' --- C. DIBUJAR CÓDIGO DE BARRAS (Solo al final) ---
        ' Dejamos un espacio y dibujamos el ID que recibimos en el Constructor
        yPos += 20
        If _ticketID <> "" AndAlso _ticketID <> "0" Then
            DibujarCodigoBarras(e.Graphics, _ticketID, yPos, anchoPagina)
        End If

        e.HasMorePages = False
        _lineaActual = 0 ' Reset
    End Sub

    ' =================================================================================
    ' GENERADOR CODE 39 CON AUTO-AJUSTE (CORREGIDO)
    ' =================================================================================
    Private Sub DibujarCodigoBarras(g As Graphics, texto As String, y As Single, anchoPagina As Integer)
        ' Code39 necesita asteriscos al inicio y fin
        Dim textoCodificar As String = "*" & texto.ToUpper() & "*"

        ' Diccionario Code 39
        Dim patrones As New Dictionary(Of Char, String) From {
            {"0"c, "000110100"}, {"1"c, "100100001"}, {"2"c, "001100001"}, {"3"c, "101100000"},
            {"4"c, "000110001"}, {"5"c, "100110000"}, {"6"c, "001110000"}, {"7"c, "000100101"},
            {"8"c, "100100100"}, {"9"c, "001100100"}, {"*"c, "010010100"},
            {"A"c, "100001001"}, {"B"c, "001001001"}, {"C"c, "101001000"}, {"D"c, "000011001"},
            {"E"c, "100011000"}, {"F"c, "001011000"}, {"G"c, "000001101"}, {"H"c, "100001100"},
            {"I"c, "001001100"}, {"J"c, "000011100"}, {"-"c, "010000101"}, {"."c, "110000100"},
            {" "c, "011000100"}, {"$"c, "010101000"}, {"/"c, "010100010"}, {"+"c, "010001010"},
            {"%"c, "000101010"}
        }

        ' 1. Configuración Inicial
        Dim anchoEstrecho As Single = 2.0F
        Dim ratio As Single = 2.5F
        Dim altoBarra As Single = 40

        ' 2. Calcular cuántos "módulos" de ancho necesitamos
        Dim totalModulos As Single = 0

        For Each c As Char In textoCodificar
            If patrones.ContainsKey(c) Then
                Dim patron As String = patrones(c)
                For Each bit As Char In patron
                    ' Si es 1 suma Ratio, si es 0 suma 1
                    totalModulos += If(bit = "1"c, ratio, 1.0F)
                Next
                totalModulos += 1.0F ' Espacio entre caracteres
            End If
        Next

        ' 3. LÓGICA DE AJUSTE (Fit-to-Width)
        Dim espacioDisponible As Single = anchoPagina - 20
        Dim anchoCalculado As Single = totalModulos * anchoEstrecho

        ' Si no cabe, reducimos el ancho de la barra
        If anchoCalculado > espacioDisponible Then
            anchoEstrecho = espacioDisponible / totalModulos
        End If

        Dim anchoAncho As Single = anchoEstrecho * ratio

        ' 4. DIBUJAR (Ahora sí con la sintaxis correcta)
        Dim anchoRealFinal As Single = totalModulos * anchoEstrecho
        Dim x As Single = (anchoPagina - anchoRealFinal) / 2

        For Each c As Char In textoCodificar
            If patrones.ContainsKey(c) Then
                Dim patron As String = patrones(c)

                ' AQUÍ ESTABA EL ERROR: Usamos un contador simple para recorrer el string
                For i As Integer = 0 To patron.Length - 1
                    Dim esNegro As Boolean = (i Mod 2 = 0)

                    ' CORRECCIÓN: Usamos .Chars(i) en lugar de (i)
                    Dim car As Char = patron.Chars(i)
                    Dim grosor As Single = If(car = "1"c, anchoAncho, anchoEstrecho)

                    If esNegro Then
                        g.FillRectangle(Brushes.Black, x, y, grosor, altoBarra)
                    End If
                    x += grosor
                Next
                x += anchoEstrecho ' Espacio entre caracteres
            End If
        Next

        ' 5. Texto legible abajo
        Try
            Dim fontBarra As New Font("Arial", 7)
            Dim sizeTxt As SizeF = g.MeasureString(texto, fontBarra)
            g.DrawString(texto, fontBarra, Brushes.Black, (anchoPagina - sizeTxt.Width) / 2, y + altoBarra + 2)
        Catch
            ' Si falla la fuente Arial, no pasa nada
        End Try
    End Sub

    ' =================================================================================
    ' ABRIR CAJÓN (Usa RawPrinterHelper)
    ' =================================================================================
    Private Sub AbrirCajonConCodigo()
        Try
            ' Comandos ESC/POS estándar (27, 112, 0, 25, 250)
            Dim codigos() As Byte = {27, 112, 0, 25, 250}
            RawPrinterHelper.SendBytesToPrinter(_impresoraUsar, codigos, codigos.Length)
        Catch
            ' Fallo silencioso del cajón
        End Try
    End Sub

    Private Sub AbrirCajon()

        Try
            CajonPOS.AbrirPorSistema()

        Catch ex As Exception
            Debug.Print("Error al abrir cajón por OPOS: " & ex.Message)

            ' Fallback temporal mientras pruebas en producción.
            ' Después de una semana estable, puedes quitar esto.
            Try
                Dim codigos() As Byte = {27, 112, 0, 25, 250}
                RawPrinterHelper.SendBytesToPrinter(_impresoraUsar, codigos, codigos.Length)
            Catch
                ' Fallo silencioso del cajón.
            End Try

        End Try

    End Sub

End Class