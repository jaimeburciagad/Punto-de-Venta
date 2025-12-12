Public Class prevales
    Private spread As FarPoint.Win.Spread.FpSpread
    Private renglones As New Collection
    Private sDireccion() As String
    Private enter As Char = Chr(13)
    Private line As Char = Chr(10)
    Public Sub New(ByVal sTot As String, ByVal nombre As String, ByVal direccion As String, ByVal telefono As String, ByVal xticket As Integer)
        Dim oConv As New Conversion(CDbl(sTot.Replace("$", "")))
        'ENCABEZADO 
        renglones.Add("PAGARE                BUENO POR:$" & Format(CDbl(sTot), "###,##0.00"))
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add("Debe(mos) y pagare(mos) incondicionalmente por")
        renglones.Add("este Pagare a la orden de:")
        renglones.Add(Globales.empresa)
        renglones.Add(enter)
        renglones.Add("  en la ciudad de Gómez   Palacio  , Durango  ")
        renglones.Add(enter)

        renglones.Add("    LA    CANTIDAD   DE : $" & Format(CDbl(sTot), "###,##0.00"))
        renglones.Add("(SON: " & oConv.numeroEnLetras & ")")
        renglones.Add(enter)
        renglones.Add(" Valor recibido a  mi  entera    satisfaccion.")
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add(" Este  pagare  forma  parte   de   una ")
        renglones.Add(" serie numerada  del 1  al   1  y todos")
        renglones.Add(" están  sujetos a la condición de  que,")
        renglones.Add(" al NO pagarse cualquiera  de ellos a  ")
        renglones.Add(" su vencimiento,serán  exigibles  todos")
        renglones.Add(" los que  le  siguen en  número, además")
        renglones.Add(" de los ya vencidos,desde la  fecha de ")
        renglones.Add(" vencimiento de este documento hasta el")
        renglones.Add(" día   de   su   liquidación ,  causará")
        renglones.Add(" INTERESES MORATORIOS  al  tipo  de  5%")
        renglones.Add("   mensual,  pagadero  en  esta  ciudad")
        renglones.Add("juntamente con el principal.")
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add("                                      ACEPTO")
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add("------------------------------------------------------")
        renglones.Add(enter)
        renglones.Add(enter)

        renglones.Add("Fecha:" + Date.Now.ToShortDateString)
        renglones.Add("Ticket:" & xticket.ToString)
        renglones.Add("DEUDOR:")
        renglones.Add(" " & nombre)
        renglones.Add(" " & direccion)
        renglones.Add("TEL:" & telefono)
        renglones.Add(enter)
        renglones.Add(enter)
        renglones.Add(enter)

    End Sub




    Public ReadOnly Property COLECCION()
        Get
            Return renglones
        End Get
    End Property

End Class
