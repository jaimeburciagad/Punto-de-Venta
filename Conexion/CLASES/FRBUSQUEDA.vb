
Imports System.Data.SqlClient
Public Class FRBUSQUEDA

    Public Shared Sub BUSCAR(ByVal PANEL As Panel, ByRef con As SqlConnection, ByRef ENCABEZADO As String, ByRef CAMPOS As String, ByRef TABLA As String, ByRef ORDEN As String, ByRef FILTRO As String, ByVal VALOR As String, ByVal FP As FarPoint.Win.Spread.FpSpread)
        PANEL.Visible = True
        Call RELLENASPBUSQUEDA(CAMPOS, TABLA, ORDEN, FP, con)
    End Sub

    Private Shared Sub RELLENASPBUSQUEDA(ByVal DSCCAMPOS As String, ByVal DSCTABLA As String, ByVal DSCORDEN As String, ByVal FP_BUSQUEDA As FarPoint.Win.Spread.FpSpread, ByVal XCON As SqlConnection)
        Dim SQL As String
        Dim DSC As New DataSet
        Dim I As Integer
        Dim J As Integer

        SQL = "SELECT " & DSCCAMPOS & " FROM " & DSCTABLA & " ORDER BY " & DSCORDEN
        Base.daQuery(SQL, XCON, DSC, "TABLA")
        FP_BUSQUEDA.ActiveSheet.RowCount = 0
        FP_BUSQUEDA.ActiveSheet.ColumnCount = DSC.Tables("TABLA").Columns.Count
        FP_BUSQUEDA.ActiveSheet.RowCount = DSC.Tables("TABLA").Rows.Count

        For I = 0 To DSC.Tables("TABLA").Rows.Count - 1
            For J = 0 To DSC.Tables("TABLA").Columns.Count - 1
                FP_BUSQUEDA.ActiveSheet.Cells(I, J).Text = DSC.Tables("TABLA").Rows(I)(J)
            Next
        Next I
        FP_BUSQUEDA.ActiveSheet.ActiveRowIndex = 0
        ' FP_BUSQUEDA.ActiveSheet.ActiveColumnIndex = Val(TXT_COLFILTRO.Text)
        FP_BUSQUEDA.Focus()


    End Sub


End Class
