
Public Class FrPopup
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
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
    Friend WithEvents pb_4 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_6 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_1 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_2 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_5 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_3 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_9 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_7 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_0 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_8 As System.Windows.Forms.PictureBox
    Friend WithEvents pb_ok As System.Windows.Forms.PictureBox
    Friend WithEvents pb_cancelar As System.Windows.Forms.PictureBox
    Friend WithEvents tb_cant As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pb_4 = New System.Windows.Forms.PictureBox()
        Me.pb_6 = New System.Windows.Forms.PictureBox()
        Me.pb_1 = New System.Windows.Forms.PictureBox()
        Me.pb_2 = New System.Windows.Forms.PictureBox()
        Me.pb_5 = New System.Windows.Forms.PictureBox()
        Me.pb_3 = New System.Windows.Forms.PictureBox()
        Me.pb_9 = New System.Windows.Forms.PictureBox()
        Me.pb_7 = New System.Windows.Forms.PictureBox()
        Me.pb_0 = New System.Windows.Forms.PictureBox()
        Me.pb_8 = New System.Windows.Forms.PictureBox()
        Me.pb_ok = New System.Windows.Forms.PictureBox()
        Me.pb_cancelar = New System.Windows.Forms.PictureBox()
        Me.tb_cant = New System.Windows.Forms.TextBox()
        CType(Me.pb_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_ok, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_cancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb_4
        '
        Me.pb_4.Location = New System.Drawing.Point(16, 128)
        Me.pb_4.Name = "pb_4"
        Me.pb_4.Size = New System.Drawing.Size(56, 41)
        Me.pb_4.TabIndex = 0
        Me.pb_4.TabStop = False
        '
        'pb_6
        '
        Me.pb_6.Location = New System.Drawing.Point(143, 128)
        Me.pb_6.Name = "pb_6"
        Me.pb_6.Size = New System.Drawing.Size(56, 41)
        Me.pb_6.TabIndex = 1
        Me.pb_6.TabStop = False
        '
        'pb_1
        '
        Me.pb_1.Location = New System.Drawing.Point(16, 80)
        Me.pb_1.Name = "pb_1"
        Me.pb_1.Size = New System.Drawing.Size(56, 41)
        Me.pb_1.TabIndex = 2
        Me.pb_1.TabStop = False
        '
        'pb_2
        '
        Me.pb_2.Location = New System.Drawing.Point(80, 80)
        Me.pb_2.Name = "pb_2"
        Me.pb_2.Size = New System.Drawing.Size(56, 41)
        Me.pb_2.TabIndex = 3
        Me.pb_2.TabStop = False
        '
        'pb_5
        '
        Me.pb_5.Location = New System.Drawing.Point(80, 128)
        Me.pb_5.Name = "pb_5"
        Me.pb_5.Size = New System.Drawing.Size(56, 41)
        Me.pb_5.TabIndex = 4
        Me.pb_5.TabStop = False
        '
        'pb_3
        '
        Me.pb_3.Location = New System.Drawing.Point(143, 80)
        Me.pb_3.Name = "pb_3"
        Me.pb_3.Size = New System.Drawing.Size(56, 41)
        Me.pb_3.TabIndex = 5
        Me.pb_3.TabStop = False
        '
        'pb_9
        '
        Me.pb_9.Location = New System.Drawing.Point(143, 176)
        Me.pb_9.Name = "pb_9"
        Me.pb_9.Size = New System.Drawing.Size(56, 41)
        Me.pb_9.TabIndex = 6
        Me.pb_9.TabStop = False
        '
        'pb_7
        '
        Me.pb_7.Location = New System.Drawing.Point(16, 176)
        Me.pb_7.Name = "pb_7"
        Me.pb_7.Size = New System.Drawing.Size(56, 41)
        Me.pb_7.TabIndex = 7
        Me.pb_7.TabStop = False
        '
        'pb_0
        '
        Me.pb_0.Location = New System.Drawing.Point(80, 224)
        Me.pb_0.Name = "pb_0"
        Me.pb_0.Size = New System.Drawing.Size(56, 41)
        Me.pb_0.TabIndex = 8
        Me.pb_0.TabStop = False
        '
        'pb_8
        '
        Me.pb_8.Location = New System.Drawing.Point(80, 176)
        Me.pb_8.Name = "pb_8"
        Me.pb_8.Size = New System.Drawing.Size(56, 41)
        Me.pb_8.TabIndex = 9
        Me.pb_8.TabStop = False
        '
        'pb_ok
        '
        Me.pb_ok.Location = New System.Drawing.Point(143, 224)
        Me.pb_ok.Name = "pb_ok"
        Me.pb_ok.Size = New System.Drawing.Size(56, 41)
        Me.pb_ok.TabIndex = 10
        Me.pb_ok.TabStop = False
        '
        'pb_cancelar
        '
        Me.pb_cancelar.Location = New System.Drawing.Point(16, 224)
        Me.pb_cancelar.Name = "pb_cancelar"
        Me.pb_cancelar.Size = New System.Drawing.Size(56, 41)
        Me.pb_cancelar.TabIndex = 11
        Me.pb_cancelar.TabStop = False
        '
        'tb_cant
        '
        Me.tb_cant.BackColor = System.Drawing.Color.White
        Me.tb_cant.Font = New System.Drawing.Font("Comic Sans MS", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cant.Location = New System.Drawing.Point(16, 16)
        Me.tb_cant.Name = "tb_cant"
        Me.tb_cant.ReadOnly = True
        Me.tb_cant.Size = New System.Drawing.Size(176, 52)
        Me.tb_cant.TabIndex = 12
        Me.tb_cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrPopup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(216, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.tb_cant)
        Me.Controls.Add(Me.pb_cancelar)
        Me.Controls.Add(Me.pb_ok)
        Me.Controls.Add(Me.pb_8)
        Me.Controls.Add(Me.pb_0)
        Me.Controls.Add(Me.pb_7)
        Me.Controls.Add(Me.pb_9)
        Me.Controls.Add(Me.pb_3)
        Me.Controls.Add(Me.pb_5)
        Me.Controls.Add(Me.pb_2)
        Me.Controls.Add(Me.pb_1)
        Me.Controls.Add(Me.pb_6)
        Me.Controls.Add(Me.pb_4)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "FrPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MODIFICAR CANTIDAD"
        CType(Me.pb_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_ok, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_cancelar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub pb_numero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_0.Click, pb_1.Click, pb_2.Click, pb_3.Click, pb_4.Click, pb_5.Click, pb_6.Click, pb_7.Click, pb_8.Click, pb_9.Click
        tb_cant.Text = tb_cant.Text + sender.Name.ToString.Chars(3).ToString
    End Sub

    Private Sub pb_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_ok.Click
        If tb_cant.Text <> "" AndAlso CInt(tb_cant.Text) <> 0 Then
            CType(Owner, FrVenta).cambiaCant(CInt(tb_cant.Text))
        End If
        Close()
    End Sub

    Private Sub pb_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_cancelar.Click
        If tb_cant.Text <> "" Then
            tb_cant.Text = ""
        Else
            Close()
        End If
    End Sub
End Class
