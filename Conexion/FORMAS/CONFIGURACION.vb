Imports System.Data.SqlClient
Imports FarPoint.Win.Spread.CellType

Public Class CONFIGURACION
    Inherits System.Windows.Forms.Form
    Public xCon As SqlConnection
    Public CONCEPTO As String


    Private Sub CONFIGURACION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RELLENACONF()
    End Sub


    Private Sub RELLENACONF()
        'PARA VER LOS CAMPOS DEL REPORTE Y MARCAR AQUELLOS QUE ESTAN 
        'CONFIGURADOS EN ESTE MOMENTO
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer


        sql = "Select * from ecconfiguracion where conf_id='" & CONCEPTO & "' order by conf_columna"
        Base.daQuery(sql, xCon, dsc, "conf")


        If dsc.Tables("conf").Rows.Count > 0 Then
            fp_conf.ActiveSheet.RowCount = dsc.Tables("conf").Rows.Count
            For i = 0 To dsc.Tables("conf").Rows.Count - 1
                fp_conf_Sheet1.Cells.Get(i, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                If CDbl(dsc.Tables("conf").Rows(i)("conf_estatus")) = 1 Then
                    fp_conf.ActiveSheet.Cells(i, 0).Value = True
                Else
                    fp_conf.ActiveSheet.Cells(i, 0).Value = False
                End If

                fp_conf.ActiveSheet.Cells(i, 1).Value = dsc.Tables("conf").Rows(i)("conf_descripcion")
                fp_conf.ActiveSheet.Cells(i, 2).Value = dsc.Tables("conf").Rows(i)("conf_columna")
            Next
        End If

    End Sub


    Private Sub LBL_GUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBL_GUARDAR.Click
        Dim sql As String
        Dim i As Integer

        For i = 0 To fp_conf.ActiveSheet.RowCount - 1
            sql = "Update ecconfiguracion set conf_estatus=" & IIf(fp_conf.ActiveSheet.Cells(i, 0).Value, 1, 0) & _
            " where conf_columna=" & fp_conf.ActiveSheet.Cells(i, 2).Value & _
            " and conf_id='" & CONCEPTO & "'"
            Base.Ejecuta(sql, xCon)
        Next i


        MsgBox("Configuración Guardada", MsgBoxStyle.Exclamation)
        fp_conf.ActiveSheet.RowCount = 0
        LBL_SALIR_Click(sender, e)
    End Sub

    Private Sub LBL_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBL_SALIR.Click
        fp_conf.ActiveSheet.RowCount = 0
        SendKeys.Flush()
        Me.Dispose(True)
        Me.Hide()

    End Sub

    Private Sub LBL_TACHA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBL_TACHA.Click
        LBL_SALIR_Click(sender, e)
    End Sub
    Private Sub lbl_GUARDAR_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBL_GUARDAR.MouseLeave
        LBL_GUARDAR.ForeColor = System.Drawing.Color.DarkOrange
    End Sub

    Private Sub lbl_GUARDAR_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LBL_GUARDAR.MouseMove
        LBL_GUARDAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(94, Byte), Integer))
    End Sub
    Private Sub lbl_SALIR_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBL_SALIR.MouseLeave
        LBL_SALIR.ForeColor = System.Drawing.Color.DarkOrange
    End Sub

    Private Sub lbl_SALIR_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LBL_SALIR.MouseMove
        LBL_SALIR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(94, Byte), Integer))
    End Sub

End Class