Public Class frmConfigURL
    Dim urlGuardada As Boolean = False

    Private Sub frmConfigURL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtURL.Text = EntityTablas.ObtenerURL(1)
        txtURL.Select(txtURL.Text.Length, 0)
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        My.Settings.URLForm = txtURL.Text
        My.Settings.Save()

        MsgBox("La URL ha sido guardada en settings", MsgBoxStyle.Information, "Formularios")
        urlGuardada = True
        RibbonFormMain.Show()
        Close()
    End Sub

    Private Sub frmConfigURL_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not urlGuardada Then
            If MsgBox("¿Está seguro de cerrar la ventana sin registrar la URL?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "URL Formulario") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                frmLogin.Show()
            End If
        End If
    End Sub
End Class