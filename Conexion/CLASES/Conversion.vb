'Esta clase sirve para convertir un número
'a su equivalente en letras como formato de moneda
'para cheques, contratos, etc..
'La máxima cantidad soportada en esta versión es 999,999,99.
'Para futuras expansiones las modificaciones son sencillas pero el límite
'sería la capacidad de un Integer.
Public Class Conversion
    Private iEntero, iCentavos As Integer
    Private sLetras As String
    Public Property Centavos() As Integer
        Get
            Return iCentavos
        End Get
        Set(ByVal Value As Integer)
            iCentavos = Value Mod 100
            dameLetras()
        End Set
    End Property
    Public Property Enteros() As Integer
        Get
            Return iEntero
        End Get
        Set(ByVal Value As Integer)
            iEntero = Value Mod 1000000
            dameLetras()
        End Set
    End Property
    Public ReadOnly Property numeroEnLetras() As String
        Get
            Return sLetras
        End Get
    End Property
    Public Sub New(ByVal dCant As Double)
        Dim arrLetras() As String
        arrLetras = CStr(dCant).Split(".")
        iEntero = CInt(arrLetras(0)) Mod 1000000
        If arrLetras.Length = 1 Then
            iCentavos = 0
        Else
            arrLetras(1) = arrLetras(1).PadRight(2, "0")
            iCentavos = CInt(arrLetras(1)) Mod 100
        End If
        dameLetras()
    End Sub
    Public Sub New(ByVal sParteEntera As String, ByVal sCentavos As String)
        iEntero = CInt(sParteEntera) Mod 1000000
        iCentavos = CInt(sCentavos) Mod 100
    End Sub
    Public Sub New(ByVal iEnt As Integer, ByVal iCent As Integer)
        iEntero = iEnt Mod 1000000
        iCentavos = iCent Mod 100
    End Sub
    Private Sub dameLetras()
        'En base a las variables iEntero e iCentavos convierte el número
        'a su equivalente en letras y le agrega la condición de pesos.
        Dim iGposTres() As Integer
        Dim colStr As New Collection
        Dim sCentavos As String
        iGposTres = separaDeTresEnTres(iEntero)
        colStr = convierteALetras(iGposTres)
        sCentavos = CStr(iCentavos).PadLeft(2, "0") + "/100 M.N."
        If colStr.Count = 0 Then
            sLetras = "Cero Pesos "
        ElseIf colStr.Count = 1 Then
            sLetras = colStr(1) + " Peso" + IIf(iEntero = 1, " ", "s ")
        ElseIf colStr.Count = 2 Then
            sLetras = colStr(2) + " mil " + colStr(1) + " Pesos "
        End If
        sLetras += sCentavos
        sLetras = sLetras.ToUpper.Replace("  ", " ")
    End Sub
    Private Function separaDeTresEnTres(ByVal iEntero As Integer) As Integer()
        'Regresa un arreglo de enteros con el número
        'pasado dividio en bloques de 3 dígitos.
        Dim col As New Collection
        Dim i As Integer = 0
        Do
            col.Add(iEntero Mod 1000)
            iEntero = iEntero \ 1000
        Loop While iEntero > 0
        Dim arrInt(col.Count - 1) As Integer
        For Each num As Integer In col
            arrInt(i) = num
            i += 1
        Next
        Return arrInt
    End Function
    Private Function convierteALetras(ByVal iArr As Integer()) As Collection
        'Recibe un arreglo de longitud N y convierte cada uno de esos valores
        'a su equivalente en letras.
        'Los números del arreglo deben ser menores a 1000
        Dim sCol As New Collection
        For Each num As Integer In iArr
            sCol.Add(convierteBloqueTres(num))
        Next
        Return sCol
    End Function
    Private Function convierteBloqueTres(ByVal iNum As Integer) As String
        'Convierte un número menor a 1000 a su equivalente en letras
        Dim sStr As String
        sStr = ""
        Dim iMod As Integer
        If iNum >= 100 Then
            iMod = iNum Mod 100
            Select Case iNum \ 100
                Case 1
                    sStr = IIf(iMod = 0, "cien ", "ciento ")
                Case 2
                    sStr = "doscientos "
                Case 3
                    sStr = "trescientos "
                Case 4
                    sStr = "cuatrocientos "
                Case 5
                    sStr = "quinientos "
                Case 6
                    sStr = "seiscientos "
                Case 7
                    sStr = "setecientos "
                Case 8
                    sStr = "ochocientos "
                Case 9
                    sStr = "novecientos "
            End Select
            sStr = sStr + convierteBloqueDos(iMod)
        ElseIf iNum >= 10 Then
            sStr = convierteBloqueDos(iNum)
        Else
            sStr = convierteBloqueUno(iNum)
        End If
        Return sStr
    End Function
    Private Function convierteBloqueDos(ByVal iNum As Integer) As String
        'Convierte un número que sea menor a 100 a su equivalente en letras
        Dim sStr As String
        sStr = ""
        Dim iMod As Integer
        If iNum >= 10 Then
            iMod = iNum Mod 10
            Select Case iNum \ 10
                Case 1
                    Select Case iNum
                        Case 10
                            sStr = "diez"
                        Case 11
                            sStr = "once"
                        Case 12
                            sStr = "doce"
                        Case 13
                            sStr = "trece"
                        Case 14
                            sStr = "catorce"
                        Case 15
                            sStr = "quince"
                        Case 16
                            sStr = "dieciseis"
                        Case 17
                            sStr = "diecisiete"
                        Case 18
                            sStr = "dieciocho"
                        Case 19
                            sStr = "diecinueve"
                    End Select
                Case 2
                    sStr = IIf(iMod = 0, "veinte", "veinti" + convierteBloqueUno(iMod))
                Case 3
                    sStr = IIf(iMod = 0, "treinta", "treinta y " + convierteBloqueUno(iMod))
                Case 4
                    sStr = IIf(iMod = 0, "cuarenta", "cuarenta y " + convierteBloqueUno(iMod))
                Case 5
                    sStr = IIf(iMod = 0, "cincuenta", "cincuenta y " + convierteBloqueUno(iMod))
                Case 6
                    sStr = IIf(iMod = 0, "sesenta", "sesenta y " + convierteBloqueUno(iMod))
                Case 7
                    sStr = IIf(iMod = 0, "setenta", "setenta y " + convierteBloqueUno(iMod))
                Case 8
                    sStr = IIf(iMod = 0, "ochenta", "ochenta y " + convierteBloqueUno(iMod))
                Case 9
                    sStr = IIf(iMod = 0, "noventa", "noventa y " + convierteBloqueUno(iMod))
            End Select
        Else
            sStr = convierteBloqueUno(iNum)
        End If
        Return sStr
    End Function
    Private Function convierteBloqueUno(ByVal iNum As Integer) As String
        'Convierte un número que sea menor a 10 a su equivalente en letras
        Dim sStr As String
        Select Case iNum
            Case 1
                sStr = "un"
            Case 2
                sStr = "dos"
            Case 3
                sStr = "tres"
            Case 4
                sStr = "cuatro"
            Case 5
                sStr = "cinco"
            Case 6
                sStr = "seis"
            Case 7
                sStr = "siete"
            Case 8
                sStr = "ocho"
            Case 9
                sStr = "nueve"
            Case Else
                sStr = ""
        End Select
        Return sStr
    End Function
End Class
