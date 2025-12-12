Imports System.Data.SqlClient
Public Class paraautorizarSALIDA
    Inherits System.Windows.Forms.Form
    
#Region " Código generado por el Diseñador de Windows Forms "
    Dim xcon As SqlConnection
    Dim autorizado, CambiaTipoVenta, CambiaCliente As Boolean
    Dim fomas As FrVenta



    Public Sub New(ByRef foma As Form, ByRef autorizo As Boolean, ByRef con As SqlConnection, ByRef Optional CambiandoVenta As Boolean = False, ByRef Optional CambiandoCliente As Boolean = False)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        xcon = con
        CambiaTipoVenta = CambiandoVenta
        CambiaCliente = CambiandoCliente
        If CambiandoVenta Then
            Label1.Text = "Código de Autorización" & vbCrLf & "Cambio en Tipo de Venta"
        ElseIf CambiandoCliente Then
            Label1.Text = "Código de Autorización" & vbCrLf & "Cambio de Cliente"
        Else
            Label1.Text = "Código de Autorización" & vbCrLf & "Cerrar Punto de Venta"
        End If

        fomas = foma
        fomas.AutorizaCierreCambioVentana = False
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
        Me.TextBox1.Location = New System.Drawing.Point(88, 105)
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
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 93)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código de Autorización PARA SALIR DEL PUNTO DE VENTA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'paraautorizarSALIDA
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(368, 149)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "paraautorizarSALIDA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización"
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
            sSql = "Select * FROM ecusuariosx where emp_password='" & Me.TextBox1.Text & "'"
            Base.daQuery(sSql, xcon, dsc, "empleado")
            autorizado = False
            If dsc.Tables("empleado").Rows.Count > 0 Then
                If dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim = "Supervisorss" Or (dsc.Tables("empleado").Rows(0)("emp_nombre").ToString.Trim = "Jaime/JR//" And dsc.Tables("empleado").Rows(0)("emp_tipo").ToString.Trim = "Supervisor") Then
                    fomas.AutorizaCierreCambioVentana = True
                    If Not CambiaTipoVenta AndAlso Not cambiacliente Then
                        fomas.Flogin.Show()
                        fomas.Dispose()
                        fomas.Close()
                    End If
                    Me.Dispose()
                    Me.Close()
                Else
                    MsgBox("Necesita password con mayor nivel de autorización.", vbExclamation, "Punto de Venta")
                    TextBox1.Text = ""
                    TextBox1.Focus()
                End If
            Else
                MsgBox("Password incorrecto.", vbExclamation, "Punto de Venta")
                TextBox1.Text = ""
                TextBox1.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            fomas.AutorizaCierreCambioVentana = False
            Me.Close()
        End If
    End Sub
End Class
