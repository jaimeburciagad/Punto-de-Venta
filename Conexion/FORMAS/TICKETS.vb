Imports System.Data.SqlClient
Imports FirebirdSql.Data.FirebirdClient
Imports FarPoint.Win.Spread.CellType

Public Class TICKETS
    Dim FOMA As Form
    Dim XCON As SqlConnection
    Public conmicrosip As FbConnection
    Public Sub New(ByRef con As SqlConnection, ByRef f As FrVenta)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        XCON = con
        FOMA = f

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub
    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) & _
        IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
    End Function



    Private Sub reimprime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        rellena()
        FP_VENTAS.Focus()
    End Sub


    Private Sub rellenadetalledet(ByVal venta As Integer)
        Dim sql As String
        Dim dsc As New DataSet

        Dim i As Integer

        sql = "select * from ecdetventa inner join articulo on art_clave=dve_articulo " & _
              " where dve_venta=" & venta & " ORDER BY DVE_renglon"

        FP_VENTASDET.ActiveSheet.RowCount = 0
        Base.daQuery(sql, xcon, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
        If dsc.Tables("ventas").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTASDET.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("art_nomcorto") & ""
                FP_VENTASDET.ActiveSheet.Cells(i, 0).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_cantidad")), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 2).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_precio") & ""), "###,##0.00")
                FP_VENTASDET.ActiveSheet.Cells(i, 3).Value = Format(CDbl(dsc.Tables("ventas").Rows(i)("dve_total") & ""), "###,##0.00")
             Next i
        End If

        dsc.Tables.Remove("ventas")

    End Sub

    Private Sub fp_ventas_CellDoubleClick(ByVal sender As Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs) Handles FP_VENTAS.CellDoubleClick

        Call rellenadetalledet(FP_VENTAS.ActiveSheet.Cells(e.Row, 1).Value)
    End Sub


    Private Sub rellena()
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer
        Dim filtro As String

        filtro = ""


        sql = "SELECT * FROM ECVENTA WHERE " & IIf(Strings.Right(Globales.caja, 1) = 7, "", "VEN_usuario='" & "000" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "' and ") & " ven_status=1 and ven_fecha>='" & Format(Today, "yyyyMMdd") & "' order by ven_fecha desc "

        FP_VENTAS.ActiveSheet.RowCount = 0

        Base.daQuery(sql, XCON, dsc, "ventas")
        FP_VENTASDET.ActiveSheet.RowCount = 0
        If dsc.Tables("ventas").Rows.Count > 0 Then
            FP_VENTAS.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTAS.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("ven_id") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 0).Text = dsc.Tables("ventas").Rows(i)("ven_fecha") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 2).Value = CDbl(dsc.Tables("ventas").Rows(i)("ven_total"))
            Next i
        End If
        dsc.Tables.Remove("ventas")
    End Sub

    Private Sub btn_regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_regresar.Click
        Me.Hide()
        FOMA.Show()
        Me.Dispose()
    End Sub

    Private Sub FP_VENTAS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FP_VENTAS.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            rellenadetalledet(FP_VENTAS.ActiveSheet.Cells(FP_VENTAS.ActiveSheet.ActiveRowIndex, 1).Value)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xforma As New Form
        xforma = New parafacturar(XCON, Me)
        xforma.BringToFront()
        xforma.ShowDialog()
        Me.Close()
    End Sub
End Class