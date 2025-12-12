Imports System.Data.SqlClient
Public Class paraautorizar
    Inherits System.Windows.Forms.Form
    
#Region " Código generado por el Diseñador de Windows Forms "
    Dim xcon As SqlConnection
    Dim autorizado As Boolean
    Dim fomas As FrVenta



    Public Sub New(ByRef foma As Form, ByRef autorizo As Boolean, ByRef con As SqlConnection)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xcon = con

        fomas = foma
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
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(96, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(184, 32)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(72, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código de Autorización"
        '
        'paraautorizar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(368, 149)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "paraautorizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización PARA SALIR DEL PUNTO DE VENTA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub paraautorizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown



        If e.KeyCode = Keys.Enter Then

            Dim i As Integer

            For i = 1 To Len(LTrim(RTrim(Me.TextBox1.Text)))
                If IsNumeric(Mid(TextBox1.Text, i, 1)) Then
                    Exit For
                End If
            Next
            TextBox1.Text = Mid(TextBox1.Text, i, Len(TextBox1.Text) - i + 1)

            Dim sSql As String
            Dim dsc As New DataSet
            sSql = "select * FROM ecusuariosx where emp_password='" & Me.TextBox1.Text & "'"
            Base.daQuery(sSql, xcon, dsc, "empleado")
            autorizado = False
            If dsc.Tables("empleado").Rows.Count > 0 Then

                If dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim = "Supervisor" Then
                    fomas.Flogin.Show()

                    fomas.Dispose()

                    fomas.Close()
                    Me.Dispose()

                    Me.Close()


                End If
            Else
                Me.Dispose()
                Me.Close()

            End If
        End If


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class
