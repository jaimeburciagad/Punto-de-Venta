Imports System.Data.SqlClient

Imports FarPoint.Win.Spread.CellType
Public Class Reptarjetas
    Dim xcon As SqlConnection
    Dim limite As Integer
    Dim foma As Form

    Dim renglones As New Collection
    Dim sDireccion() As String
    Dim xENTER As Char = Chr(13)
    Dim line As Char = Chr(10)

    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) & _
        IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
    End Function

    Public Sub New(ByRef con As SqlConnection, ByRef fom As FrAdmin)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xcon = con
        foma = fom
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
    End Sub

    Private Sub repsalidascaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dsc As New DataSet
        Dim dsc1 As New DataSet

        Dim total1 As Double = 0
        Dim total2 As Double = 0
        Dim total3 As Double = 0
        Dim total4 As Double = 0
        Dim total5 As Double = 0
        Dim total6 As Double = 0

        txt_Fechaini.Text = DateTime.Now.ToShortDateString
        txt_Fechafin.Text = DateTime.Now.ToShortDateString

    End Sub

 


    Private Sub txt_fechaini_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Fechaini.Validating
        If Not IsDate(txt_Fechaini.Text) Then
            MsgBox("Formato de Fecha inválido", MsgBoxStyle.Exclamation)
            txt_Fechaini.Text = IIf(Now.Day > 9, CStr(Now.Day), "0" & CStr(Now.Day)) & "/" & _
        IIf(Now.Month > 9, CStr(Now.Month), "0" & CStr(Now.Month)) & "/" & _
        CStr(Now.Year)
            txt_Fechaini.Focus()
        End If
    End Sub

    Private Sub txt_fechafin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Fechafin.Validating
        If Not IsDate(txt_Fechafin.Text) Then
            MsgBox("Formato de Fecha inválido", MsgBoxStyle.Exclamation)
            txt_Fechafin.Text = IIf(Now.Day > 9, CStr(Now.Day), "0" & CStr(Now.Day)) & "/" & _
        IIf(Now.Month > 9, CStr(Now.Month), "0" & CStr(Now.Month)) & "/" & _
        CStr(Now.Year)
            txt_Fechafin.Focus()
        End If
    End Sub

    Private Sub btn_aplica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplica.Click
        panel_conf.Visible = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        panel_conf.Visible = False
    End Sub

    Private Sub generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generar.Click
        rellenaventas()
    End Sub

    Private Sub rellenaventas()
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer
        Dim filtro As String

        filtro = ""


        If rb_una.Checked Then
            filtro = " and caja='00" & txt_clave.Text & "0'"
        End If


        If rb_encorte.Checked Then
            filtro = IIf(filtro = "", " corte =1 ", " and corte=1 ")
        End If


        If rb_noencorte.Checked Then
            filtro = IIf(filtro = "", " corte =1 ", " and corte=0 ")
        End If


        sql = "Select * from ectarjetas  WHERE FECHA>='" & dafecha(CDate(txt_Fechaini.Text)) & "'" & _
            " AND FECHA<='" & dafecha(DateAdd("d", 1, CDate(txt_Fechafin.Text))) & "' " & filtro & " ORDER BY tar_ventaid "

        FP_VENTAS.ActiveSheet.RowCount = 0

        Base.daQuery(sql, xcon, dsc, "ventas")

        If dsc.Tables("ventas").Rows.Count > 0 Then
            FP_VENTAS.ActiveSheet.RowCount = dsc.Tables("ventas").Rows.Count
            For i = 0 To dsc.Tables("ventas").Rows.Count - 1
                FP_VENTAS.ActiveSheet.Cells(i, 0).Value = dsc.Tables("ventas").Rows(i)("CAJA").ToString.Substring(2, 1)
                FP_VENTAS.ActiveSheet.Cells(i, 1).Value = dsc.Tables("ventas").Rows(i)("tar_id") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 2).Value = dsc.Tables("ventas").Rows(i)("FECHA") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 3).Value = dsc.Tables("ventas").Rows(i)("FECHA") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 4).Text = dsc.Tables("ventas").Rows(i)("DESCRIPCION")
                FP_VENTAS.ActiveSheet.Cells(i, 5).Text = dsc.Tables("ventas").Rows(i)("CANTIDAD") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 6).Text = dsc.Tables("ventas").Rows(i)("COMISION") & ""
                FP_VENTAS.ActiveSheet.Cells(i, 7).Text = dsc.Tables("ventas").Rows(i)("REFERENCIA") & ""
            Next i
        End If
        dsc.Tables.Remove("ventas")
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        GENERAL.rutinaexportaraexcel(FP_VENTAS, "Reporte Cobros con Tarjetas Bancarias")

    End Sub

    Private Sub regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regresar.Click
        Me.Hide()
        foma.Show()
        Me.Dispose()
    End Sub

    Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_IMPRIMIR.Click
        Dim orep As REPORTE
        Dim comma As String
        comma = """"

        '      On Error Resume Next


        orep = New REPORTE
        orep.REPORTE = "C:\EC\REPORTES\TARJETAS.RPT"
        orep.TITULO = "Reporte Pagos con Tarjetas Bancarias"
        orep.SERVIDOR = Globales.sServidor
        orep.BASEDATOS = Globales.sBaseDatos
        orep.USUARIO = Globales.sUsuarioBase
        orep.CLAVEACCESO = Globales.sClaveUsuario
        If rb_encorte.Checked Then
            orep.SELECCIONAR = "{ectarjetas.Fecha}>=cdate(" & comma & txt_Fechaini.Text & comma & ")  and {ectarjetas.Fecha}<=cdate(" & comma & txt_Fechafin.Text & comma & ") and tar_empresa=1 and corte=1"
        Else
            orep.SELECCIONAR = "{ectarjetas.Fecha}>=cdate(" & comma & txt_Fechaini.Text & comma & ")  and {ectarjetas.Fecha}<=cdate(" & comma & txt_Fechafin.Text & comma & ") and tar_empresa=1 and corte=0 "

        End If
        If rb_ttickets.Checked Then
            orep.SELECCIONAR = "{ectarjetas.Fecha}>=cdate(" & comma & txt_Fechaini.Text & comma & ")  and {ectarjetas.Fecha}<=cdate(" & comma & txt_Fechafin.Text & comma & ") and {ectarjetas.TAR_EMPRESA}=1"

        End If
        orep.Show()
    End Sub

End Class