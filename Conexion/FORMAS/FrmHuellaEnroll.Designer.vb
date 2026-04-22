<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHuellaEnroll
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pbFingerprint = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        CType(Me.pbFingerprint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbFingerprint
        '
        Me.pbFingerprint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbFingerprint.Location = New System.Drawing.Point(0, 0)
        Me.pbFingerprint.Name = "pbFingerprint"
        Me.pbFingerprint.Size = New System.Drawing.Size(334, 381)
        Me.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbFingerprint.TabIndex = 24045
        Me.pbFingerprint.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblStatus.Location = New System.Drawing.Point(0, 351)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(334, 30)
        Me.lblStatus.TabIndex = 24048
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmHuellaEnroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(334, 381)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbFingerprint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmHuellaEnroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TopMost = True
        CType(Me.pbFingerprint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbFingerprint As PictureBox
    Friend WithEvents lblStatus As Label
End Class
