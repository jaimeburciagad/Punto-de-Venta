Public Class FrmPanelAutorizaciones
    Private _panel As Panel
    Private _originalParent As Control
    Private _originalDock As DockStyle
    Private _originalVisible As Boolean

    Public Sub New(motivos As IEnumerable(Of String))
        InitializeComponent()
        SetMotivos(motivos)
    End Sub

    Public Sub SetMotivos(motivos As IEnumerable(Of String))
        ListBox1.BeginUpdate()
        Try
            ListBox1.Items.Clear()
            If motivos IsNot Nothing Then
                For Each s In motivos
                    ListBox1.Items.Add(s)
                Next
            End If
        Finally
            ListBox1.EndUpdate()
        End Try
    End Sub

    Public Sub AttachPanel(p As Panel)
        If p Is Nothing Then Return

        _panel = p
        _originalParent = p.Parent
        _originalDock = p.Dock
        _originalVisible = p.Visible

        p.Visible = True
        p.Dock = DockStyle.Fill
        p.Parent = Me
    End Sub

    Public Sub RestorePanel()
        If _panel Is Nothing OrElse _originalParent Is Nothing Then Return
        _panel.Parent = _originalParent
        _panel.Dock = _originalDock
        _panel.Visible = _originalVisible
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        RestorePanel()
        MyBase.OnFormClosed(e)
    End Sub

    Private Sub ListBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox1.DrawItem
        If e.Index < 0 Then Return

        e.DrawBackground()

        Dim txt = If(ListBox1.Items(e.Index), "").ToString()

        ' Si viene vacío, no dibujes nada (solo el fondo)
        If txt.Length = 0 Then
            e.DrawFocusRectangle()
            Return
        End If

        ' Formato simple: "encabezados" cuando empiezan con ** y terminan con **
        Dim isHeader = txt.StartsWith("**") AndAlso txt.EndsWith("**")
        If isHeader Then
            txt = txt.Trim("*"c) ' quita asteriscos
        End If

        Dim f As Font = If(isHeader, New Font(e.Font, FontStyle.Bold), e.Font)
        Using br As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(txt, f, br, e.Bounds)
        End Using

        If isHeader Then f.Dispose()
        e.DrawFocusRectangle()
    End Sub

End Class
