Imports System.Data.SqlClient
Public Class Autorizacion

    Inherits System.Windows.Forms.Form
    Dim xCon As SqlConnection
    Dim fo As FrVenta



#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef con As SqlConnection, ByRef foma As Form)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        Me.xCon = con
        fo = foma

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
    Friend WithEvents clave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.clave = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'clave
        '
        Me.clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clave.Location = New System.Drawing.Point(82, 87)
        Me.clave.Name = "clave"
        Me.clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.clave.Size = New System.Drawing.Size(224, 31)
        Me.clave.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(328, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código de Autorización"
        '
        'Autorizacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(384, 176)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.clave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "Autorizacion"
        Me.Text = "Autorización"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Autorizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clave.Focus()

        Me.Left = fo.PanelCancelaciones.Left - Me.Width
        Me.Top = fo.PanelCancelaciones.Top
    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

    Private Sub clave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles clave.KeyPress
        Dim forma As Form

        If Asc(e.KeyChar) = Keys.Enter Then
            Dim i As Integer

            For i = 1 To Len(LTrim(RTrim(Me.clave.Text)))
                If IsNumeric(Mid(clave.Text, i, 1)) Then
                    Exit For
                End If
            Next
            clave.Text = Mid(clave.Text, i, Len(clave.Text) - i + 1)


            Dim sSql As String
            Dim dsc As New DataSet

            sSql = "select * FROM ecusuariosx where emp_password='" & Me.clave.Text & "'"
            Base.daQuery(sSql, xCon, dsc, "empleado")
            If dsc.Tables("empleado").Rows.Count > 0 Then

                Select Case dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim

                    Case "Supervisor"
                        fo.autorizame = False
                        SendKeys.Flush()
                        Me.Hide()
                        Me.Dispose()
                        Me.Close()
                        'forma = New FrCambio(fo)
                        'forma.Show()

                    Case Else
                        MsgBox("CODIGO INCORRECTO")
                End Select
            Else
                MsgBox("CODIGO INCORRECTO")
            End If

        End If
    End Sub
End Class
