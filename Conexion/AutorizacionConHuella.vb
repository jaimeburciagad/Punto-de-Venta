Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class FingerprintAuthResult
    Public Property Approved As Boolean
    Public Property UserId As Integer?
    Public Property UserName As String
    Public Property UserRole As String
End Class

Module AutorizacionConHuella
    Public Function PromptFingerprint(xcon As SqlConnection,
                                      jerarquia As String,
                                      idemp As Integer,
                                      Optional owner As IWin32Window = Nothing,
                                      Optional motivos As IEnumerable(Of String) = Nothing) As FingerprintAuthResult
        Dim res As New FingerprintAuthResult With {
            .Approved = False, .UserId = Nothing, .UserName = Nothing, .UserRole = Nothing
        }


        Dim side As FrmPanelAutorizaciones = Nothing
        Dim motivosList = If(motivos, Enumerable.Empty(Of String)()).ToList()

        Using h As New FrmHuellaEnroll(xcon, "", idemp, jerarquia)
            h.currentMode = FrmHuellaEnroll.FingerprintMode.Verify

            If motivosList.Count > 0 Then
                h.StartPosition = FormStartPosition.Manual

                Dim ob As Rectangle = GetOwnerBounds(owner)
                Dim panelW As Integer = 360 ' o el ancho que quieras
                Dim totalW As Integer = h.Width + panelW

                Dim leftBlock As Integer = ob.Left + (ob.Width - totalW) \ 2
                Dim topBlock As Integer = ob.Top + (ob.Height - h.Height) \ 2

                h.Location = New Point(leftBlock, topBlock)

                side = New FrmPanelAutorizaciones(motivosList)
                side.FormBorderStyle = FormBorderStyle.None
                side.ShowInTaskbar = False
                side.StartPosition = FormStartPosition.Manual
                side.Size = New Size(panelW, h.Height)
                side.Location = New Point(h.Bounds.Right, h.Top)
                side.Owner = h

                AddHandler h.LocationChanged, Sub()
                                                  If side IsNot Nothing AndAlso Not side.IsDisposed Then
                                                      side.Location = New Point(h.Bounds.Right, h.Top)
                                                  End If
                                              End Sub
                AddHandler h.SizeChanged, Sub()
                                              If side IsNot Nothing AndAlso Not side.IsDisposed Then
                                                  side.Height = h.Height
                                                  side.Location = New Point(h.Bounds.Right, h.Top)
                                              End If
                                          End Sub
                AddHandler h.FormClosed, Sub()
                                             If side IsNot Nothing AndAlso Not side.IsDisposed Then side.Close()
                                         End Sub

                side.Show(h)
            End If

            Dim dr As DialogResult = If(owner Is Nothing, h.ShowDialog(), h.ShowDialog(owner))

            If dr = DialogResult.OK AndAlso h.VerificationResult Then
                res.Approved = True
                res.UserId = h.MatchedUserId
                res.UserName = h.MatchedUserName
                res.UserRole = h.MatchedUserRole
            End If
        End Using

        If side IsNot Nothing AndAlso Not side.IsDisposed Then side.Close()
        Return res
    End Function

    Private Function GetOwnerBounds(owner As IWin32Window) As Rectangle
        If owner IsNot Nothing Then
            Dim c = Control.FromHandle(owner.Handle)
            If c IsNot Nothing Then
                Dim f = c.FindForm()
                If f IsNot Nothing Then Return f.Bounds
                Return c.RectangleToScreen(c.ClientRectangle)
            End If
        End If

        ' Mejor que PrimaryScreen: usa la pantalla donde está el owner, si existe
        Return Screen.PrimaryScreen.WorkingArea
    End Function
End Module
