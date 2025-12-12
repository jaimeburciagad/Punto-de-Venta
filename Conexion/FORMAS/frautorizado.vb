Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class frautorizado
    Inherits System.Windows.Forms.Form
    Dim fo As Devoluciones

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef forma As Devoluciones)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        fo = forma
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(96, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(184, 40)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(328, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código de Autorización"
        '
        'frautorizado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(368, 149)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(390, 400)
        Me.Name = "frautorizado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Autorización"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub imprimevirtual(ByRef pre As Collection)
        Dim oImpresion As Impresionvirtual
        oImpresion = New Impresionvirtual(pre)
        oImpresion.imprime()
    End Sub
    Private Sub frautorizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Dim sql As String
        Dim dsc As New DataSet
        Dim sSql As String
        Dim gtotal As Double
        Dim i As Integer
        Dim XMAXIMO As Integer
        Dim descripcion As String
        Dim xfecha As String

        If e.KeyCode = Keys.Enter Then
            Dim asdf As Integer

            For asdf = 1 To Len(LTrim(RTrim(Me.TextBox1.Text)))
                If IsNumeric(Mid(TextBox1.Text, asdf, 1)) Then
                    Exit For
                End If
            Next
            TextBox1.Text = Mid(TextBox1.Text, asdf, Len(TextBox1.Text) - asdf + 1)


            sSql = "select * FROM ecusuariosx where emp_password='" & Me.TextBox1.Text & "'"
            Base.daQuery(sSql, fo.xCon, dsc, "empleado")
            If dsc.Tables("empleado").Rows.Count > 0 Then



                If dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim = "Supervisor" Then
                    With fo.FpSpread1.ActiveSheet

                        For i = 0 To .RowCount - 1
                            If CDbl(.Cells(i, 4).Value) <> 0 Then
                                If .Cells(i, 4).Value > .Cells(i, 0).Value Then
                                    MsgBox("No se puede devolver más articulos de los comprados.", MsgBoxStyle.Exclamation, "Devolución de Mercancías")
                                    Return
                                ElseIf .Cells(i, 4).Value < 0 Then
                                    MsgBox("La cantidad a devolver no puede ser negativa.", MsgBoxStyle.Exclamation, "Devolución de Mercancías")
                                    Return
                                End If
                            End If
                        Next
                        descripcion = ""
                        gtotal = 0
                        RegistroHistorial.HistorialAutorizaciones(fo.xCon, My.Computer.Name, dsc.Tables("empleado").Rows(0)("emp_nombre"), fo.TxtNumTicket.Text.Trim, "Devolución", "Devolución de Mercancía")
                        If fo.CheckBox1.Checked = True Then
                            sql = "Select retiros+1  as  maximo  from ecconsempresa "
                            Base.daQuery(sql, fo.xCon, dsc, "maximo")
                            Base.Ejecuta("UPDATE ECCONSEMPRESA SET RETIROS=RETIROS+1 ", fo.xCon)

                            XMAXIMO = CDbl(dsc.Tables("maximo").Rows(0)("maximo"))

                            dsc.Tables.Remove("maximo")

                            For i = 0 To .RowCount - 1
                                If .Cells(i, 4).Value <> 0 Then
                                    gtotal = gtotal + .Cells(i, 4).Value * .Cells(i, 3).Value
                                    descripcion = IIf(descripcion = "", CStr(.Cells(i, 4).Value) & " " & .Cells(i, 2).Text.Trim, descripcion & "," & CStr(.Cells(i, 4).Value) & " " & .Cells(i, 2).Text.Trim)
                                End If
                            Next


                            If fo.CmbCaja.Visible = True Then
                                sql = "Insert into ecretiros (cve_retiros,fecha,cuanto,caja,tipo,descripcion,corte,ret_estatus,usuario, motivo, Ticket) values(" & XMAXIMO & ",getdate()," & gtotal & ",'00" & fo.CmbCaja.SelectedItem & "0',6,'DEV " & descripcion & "',0,0,'" & dsc.Tables("empleado").Rows(0)("emp_nombre").ToString.Trim & "','" & fo.TxtMotivo.Text.Trim & "'," & fo.TxtNumTicket.Text.Trim & ")"
                            Else
                                sql = "Insert into ecretiros (cve_retiros,fecha,cuanto,caja,tipo,descripcion,corte,ret_estatus,usuario, motivo, Ticket) values(" & XMAXIMO & ",getdate()," & gtotal & ",'00" & Globales.caja.Substring(Len(Globales.caja) - 1, 1) & "0',6,'DEV " & descripcion & "',0,0,'" & dsc.Tables("empleado").Rows(0)("emp_nombre").ToString.Trim & "','" & fo.TxtMotivo.Text.Trim & "'," & fo.TxtNumTicket.Text.Trim & ")"
                            End If
                            Base.Ejecuta(sql, fo.xCon)

                            Dim preDINERO As New predinero(fo.TxtNumTicket.Text, gtotal, CInt(fo.CmbCaja.SelectedItem), "DEV " & descripcion & "")
                            imprimeTicket(preDINERO.COLECCION)
                        End If

                        For i = 0 To .RowCount - 1
                            If .Cells(i, 4).Value <> 0 Then
                                'descripcion = IIf(descripcion = "", CStr(.Cells(i, 4).Value) & " " & .Cells(i, 2).Text.Trim, descripcion & "," & CStr(.Cells(i, 4).Value) & " " & .Cells(i, 2).Text.Trim)

                                sql = "Insert eccancxupc values('" & .Cells(i, 6).Value & "'," & .Cells(i, 4).Value & "," & fo.TxtNumTicket.Text & ",getdate()," & .Cells(i, 3).Value & "," & .Cells(i, 4).Value * .Cells(i, 3).Value & ",'" & .Cells(i, 1).Text & "','" & dsc.Tables("empleado").Rows(0)("emp_nombre").ToString.Trim & "'," & XMAXIMO & ")"
                                'gtotal = gtotal + (.Cells(i, 3).Value * .Cells(i, 4).Value)
                                Base.Ejecuta(sql, fo.xCon)

                                xfecha = dafecha(Now.Date)

                                Base.Ejecuta("EXEC APLICAMOVTOSFECHA 3,'" & xfecha & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 1).Text & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 6).Value & "'," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value & "," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value * fo.FpSpread1.ActiveSheet.Cells(i, 3).Value, fo.xCon)
                                Base.Ejecuta("EXEC APLICAMOVTOSFECHACORTE 3,'" & xfecha & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 1).Text & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 6).Value & "'," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value & "," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value * fo.FpSpread1.ActiveSheet.Cells(i, 3).Value, fo.xCon)
                                Base.Ejecuta("EXEC APLICAMOVTOSMES 3,'" & xfecha & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 1).Text & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 6).Value & "'," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value & "," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value * fo.FpSpread1.ActiveSheet.Cells(i, 3).Value, fo.xCon)
                                Base.Ejecuta("EXEC APLICAMOVTOSSEMANA 3,'" & xfecha & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 1).Text & "','" & fo.FpSpread1.ActiveSheet.Cells(i, 6).Value & "'," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value & "," & fo.FpSpread1.ActiveSheet.Cells(i, 4).Value * fo.FpSpread1.ActiveSheet.Cells(i, 3).Value, fo.xCon)

                            End If
                        Next i

                        Me.Close()
                        Me.Dispose()
                        fo.btn_cancelar_Click(sender, e)

                    End With

                Else
                    MsgBox("No tiene clave de acceso para realizar la cancelación")
                    Return
                End If


            End If
        End If

    End Sub
    Public Sub imprimeTicket(ByRef pre As Collection)
        Dim oImpresion As Impresion
        oImpresion = New Impresion(pre)
        oImpresion.imprime(True)
    End Sub

    Private Function dafecha(ByVal fecha As Date) As String
        dafecha = CStr(Year(fecha)) & IIf(Month(fecha) < 10, "0" & CStr(Month(fecha)), CStr(Month(fecha))) &
        IIf(fecha.Day < 10, "0" & CStr(fecha.Day), CStr(fecha.Day))
    End Function
End Class
