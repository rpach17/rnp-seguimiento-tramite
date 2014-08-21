Public Class frmNotificacion
    Private Sub frmNotificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim src = Screen.FromPoint(Location)
        Location = New Point(src.WorkingArea.Right - Width, src.WorkingArea.Bottom - Height)
        MyBase.OnActivated(e)

        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Opacity = 100.0R Then
            Timer1.Enabled = False
        Else
            Opacity += 0.1R
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Dim i As Integer = 1
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If (i Mod 2) <> 0 Then
            lblInfo.BackColor = Color.Black
            Label2.BackColor = Color.Black
        Else
            lblInfo.BackColor = Color.Red
            Label2.BackColor = Color.Red
        End If
        i += 1
    End Sub
End Class