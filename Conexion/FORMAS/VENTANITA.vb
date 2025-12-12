Public Class VENTANITA
    Inherits System.Windows.Forms.Form
    Private titulo As String
    Private mensaje As String
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal msg As String, ByVal tit As String)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        titulo = tit
        mensaje = msg

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
    Friend WithEvents b_no As System.Windows.Forms.Button
    Friend WithEvents lb_mensaje As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lb_mensaje = New System.Windows.Forms.Label
        Me.b_no = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lb_mensaje
        '
        Me.lb_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_mensaje.ForeColor = System.Drawing.Color.Black
        Me.lb_mensaje.Location = New System.Drawing.Point(16, 16)
        Me.lb_mensaje.Name = "lb_mensaje"
        Me.lb_mensaje.Size = New System.Drawing.Size(392, 24)
        Me.lb_mensaje.TabIndex = 0
        Me.lb_mensaje.Text = "Label1"
        '
        'b_no
        '
        Me.b_no.BackColor = System.Drawing.Color.RoyalBlue
        Me.b_no.DialogResult = System.Windows.Forms.DialogResult.No
        Me.b_no.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_no.ForeColor = System.Drawing.Color.White
        Me.b_no.Location = New System.Drawing.Point(232, 80)
        Me.b_no.Name = "b_no"
        Me.b_no.Size = New System.Drawing.Size(152, 56)
        Me.b_no.TabIndex = 2
        Me.b_no.Text = "OK"
        '
        'VENTANITA
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(432, 157)
        Me.Controls.Add(Me.b_no)
        Me.Controls.Add(Me.lb_mensaje)
        Me.Name = "VENTANITA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VENTANITA"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub VENTANITA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lb_mensaje.Text = mensaje
        Me.Text = titulo
        b_no.Focus()

    End Sub


    Private Sub b_no_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_no.Click
        Me.Hide()

        Me.Dispose()

    End Sub
End Class
