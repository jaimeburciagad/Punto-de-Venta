Imports System.Data.SqlClient
Public Class GENERAL


    Public Shared Sub parametrosbusqueda(ByVal forma As busqueda, ByVal encabezado As String, ByVal campos As String, ByVal tabla As String, ByVal orden As String, ByVal ColumnaABuscarPor As String, ByVal conexion As SqlConnection, ByVal NombresDisplayColumnasABuscarPor As String, ByVal AnchoColumnas As String, ByVal tipocampo As String, ByVal ValorDeColumnasARegresar As String, ByVal WhereClause As String, Optional ByVal Columnas As String = "")
        forma.DSCCAMPOS = campos
        forma.DSCENCABEZADO = encabezado
        forma.DSCORDEN = orden
        forma.DSCTABLA = tabla
        forma.TXT_COLFILTRO.Text = ColumnaABuscarPor
        forma.dsccampose = NombresDisplayColumnasABuscarPor
        forma.tipocampos = tipocampo
        forma.longcampos = AnchoColumnas
        forma.DSCFILTRO = ValorDeColumnasARegresar
        forma.xCon = conexion
        forma.filtrotabla = WhereClause
        forma.Columnas = Columnas
    End Sub
    Public Shared Function fechatexto(ByVal fecha As DateTime) As String
        fechatexto = Mid("00" & fecha.Day, Len("00" & fecha.Day) - 1, 2) & "/" & _
         Mid("00" & fecha.Month, Len("00" & fecha.Month) - 1, 2) & "/" & _
         fecha.Year.ToString
    End Function

    Public Shared Sub rutinaexportaraexcel(ByVal fp_spread As FarPoint.Win.Spread.FpSpread, ByVal encabezado As String)
        ' RUTINA PARA EXPORTAR EL SPREAD DE NOTAS DE CREDITO AL EXCEL
        '        GRABA EL SPREAD EN EXCEL, PERMITIENDO QUE SE ELIJA EL NOMBRE DEL ARCHIVO 
        'LA DIRECCION EN LA QUE SE GUARDARA LA MISMA
        'LUEGO ELIMINA LOS RENGLONES EXTRAS PARA SEGUIR TRABAJANDO


        Dim nombrearchivo As String
        Dim dialogo As New SaveFileDialog
        Dim i As Integer


        fp_spread.ActiveSheet.ColumnHeader.RowCount = 5
        For i = 0 To fp_spread.ActiveSheet.ColumnCount - 1
            fp_spread.ActiveSheet.ColumnHeader.Cells.Get(4, i).Value = fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, i).Value
            fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, i).Value = ""
        Next i


        'PARA PONER NOMBRE DE LA EMPRESA PARA LA QUE SE GENERA EL REPORTE
        fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, 0).Value = "AUTOSERVICIO DUARSA "
        fp_spread.ActiveSheet.ColumnHeader.Cells.Get(1, 0).Value = encabezado
        fp_spread.ActiveSheet.ColumnHeader.Cells.Get(2, 0).Value = "Fecha Emisión:" & CStr(Now.Date())


        fp_spread.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, fp_spread.ActiveSheet.ColumnCount - 1)
        fp_spread.ActiveSheet.AddColumnHeaderSpanCell(1, 0, 1, fp_spread.ActiveSheet.ColumnCount - 1)
        fp_spread.ActiveSheet.AddColumnHeaderSpanCell(2, 0, 1, fp_spread.ActiveSheet.ColumnCount - 1)


        Try
            dialogo.Filter = "Excel Spreadsheets(*.xls)|*.xls"
            If dialogo.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                nombrearchivo = dialogo.FileName
                fp_spread.SaveExcel(nombrearchivo, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly)
            End If


            fp_spread.ActiveSheet.RemoveColumnHeaderSpanCell(0, 0)
            For i = 0 To fp_spread.ActiveSheet.ColumnCount - 1
                fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, i).Value = fp_spread.ActiveSheet.ColumnHeader.Cells.Get(4, i).Value
            Next i

            fp_spread.ActiveSheet.ColumnHeader.RowCount = 1




            MsgBox("Información Guardada en Excel Correctamente", MsgBoxStyle.Information)

        Catch ex As Exception

        End Try


    End Sub
    Public Shared Sub rutinaexportaraexcel2(ByVal fp_spread As FarPoint.Win.Spread.FpSpread, ByVal encabezado As String)
        ' RUTINA PARA EXPORTAR EL SPREAD DE NOTAS DE CREDITO AL EXCEL
        '        GRABA EL SPREAD EN EXCEL, PERMITIENDO QUE SE ELIJA EL NOMBRE DEL ARCHIVO 
        'LA DIRECCION EN LA QUE SE GUARDARA LA MISMA
        'LUEGO ELIMINA LOS RENGLONES EXTRAS PARA SEGUIR TRABAJANDO


        Dim nombrearchivo As String
        Dim dialogo As New SaveFileDialog
        Dim i As Integer


        fp_spread.ActiveSheet.ColumnHeader.RowCount = 5
        For i = 0 To fp_spread.ActiveSheet.ColumnCount - 1
            fp_spread.ActiveSheet.ColumnHeader.Cells.Get(4, i).Value = fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, i).Value
            fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, i).Value = ""
        Next i


        'PARA PONER NOMBRE DE LA EMPRESA PARA LA QUE SE GENERA EL REPORTE
        fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, 0).Value = "AUTOSERVICIO DUARSA"
        fp_spread.ActiveSheet.ColumnHeader.Cells.Get(1, 0).Value = encabezado
        fp_spread.ActiveSheet.ColumnHeader.Cells.Get(2, 0).Value = "Fecha Emisión:" & CStr(Now.Date())


        fp_spread.ActiveSheet.AddColumnHeaderSpanCell(0, 0, 1, fp_spread.ActiveSheet.ColumnCount - 1)
        fp_spread.ActiveSheet.AddColumnHeaderSpanCell(1, 0, 1, fp_spread.ActiveSheet.ColumnCount - 1)
        fp_spread.ActiveSheet.AddColumnHeaderSpanCell(2, 0, 1, fp_spread.ActiveSheet.ColumnCount - 1)


        Try
            dialogo.Filter = "Excel Spreadsheets(*.xls)|*.xls"
            If dialogo.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                nombrearchivo = dialogo.FileName
                fp_spread.SaveExcel(nombrearchivo, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly)
            End If


            fp_spread.ActiveSheet.RemoveColumnHeaderSpanCell(0, 0)
            For i = 0 To fp_spread.ActiveSheet.ColumnCount - 1
                fp_spread.ActiveSheet.ColumnHeader.Cells.Get(0, i).Value = fp_spread.ActiveSheet.ColumnHeader.Cells.Get(4, i).Value
            Next i

            fp_spread.ActiveSheet.ColumnHeader.RowCount = 2




            MsgBox("Información Guardada en Excel Correctamente", MsgBoxStyle.Information)

        Catch ex As Exception

        End Try


    End Sub
    Public Shared Sub PARAMETROSCONF(ByVal FORMA As CONFIGURACION, ByVal CONCEPTO As String, ByVal conexion As SqlConnection)
        FORMA.CONCEPTO = CONCEPTO
        FORMA.xCon = conexion
    End Sub

    'Public Shared Sub PARAMETROSCLASIFICACIONES(ByRef FORMA As SELCLASIFICACIONES, ByRef FPSPREADX As FarPoint.Win.Spread.FpSpread, ByVal conexion As SqlConnection)
    '    FORMA.FP_FAMILIAS = FPSPREADX
    '    FORMA.xCon = conexion
    'End Sub

    Public Shared Function xdaorden(ByVal xcon As SqlConnection, ByVal CONCEPTO As String) As String
        Dim sql As String
        Dim dsc As New DataSet
        Dim texto As String
        Dim i As Integer

        texto = ""

        sql = "Select * from ecconfiguracion where  conf_id='" & CONCEPTO & "' and conf_orden<>0  order by conf_orden"
        Base.daQuery(sql, xcon, dsc, "conf")
        If dsc.Tables("conf").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("conf").Rows.Count - 1
                texto = IIf(texto = "", dsc.Tables("conf").Rows(i)("conf_nombre"), texto & "," & dsc.Tables("conf").Rows(i)("conf_nombre"))
            Next
        End If
        dsc.Tables.Remove("conf")
        Return texto

    End Function



    Public Shared Sub xconfigura(ByVal fp_spread As FarPoint.Win.Spread.FpSpread, ByVal xcon As SqlConnection, ByVal CONCEPTO As String)
        Dim sql As String
        Dim dsc As New DataSet
        Dim i As Integer
        sql = "Select * from ecconfiguracion where conf_id='" & CONCEPTO & "' order by conf_columna"
        Base.daQuery(sql, xcon, dsc, "conf")
        If dsc.Tables("conf").Rows.Count > 0 Then
            For i = 0 To dsc.Tables("conf").Rows.Count - 1
                If CDbl(dsc.Tables("CONF").Rows(i)("CONF_ESTATUS")) = 0 Then
                    fp_spread.ActiveSheet.Columns.Get(dsc.Tables("conf").Rows(i)("conf_columna") - 1).Visible = False
                Else
                    fp_spread.ActiveSheet.Columns.Get(dsc.Tables("conf").Rows(i)("conf_columna") - 1).Visible = True
                End If
            Next
        End If
    End Sub

    Public Shared Sub PARAMETROSORDEN(ByVal FORMA As ORDENACION, ByVal CONCEPTO As String, ByVal conexion As SqlConnection)
        FORMA.CONCEPTO = CONCEPTO
        FORMA.xCon = conexion
    End Sub


End Class
