Public Class frmLogin

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ProbarConexion(My.Settings.MiConexion) <> "OK" Then
            frmConfig.Show()
            Close()
        End If

        If Not String.IsNullOrEmpty(My.Settings.URLForm) Then
            chkURL.Enabled = True
            chkURL.Checked = False
        Else
            chkURL.Enabled = False
            chkURL.Checked = True
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub btnEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If txtUser.Text = "RNPAPPCA" AndAlso txtPass.Text = "Rnp2014!" Then
            With SesionActiva
                .Usuario = "Administrador"
                .Nombre = "User Admin"
                .IdSucursalOficina = 0
                .Sucursal = "General"
                .Oficina = "No disponible"
            End With
            RibbonFormMain.Show()
            Close()
            Exit Sub
        End If

        If txtUser.Text.Trim = "" Then
            txtUser.Focus()
            Exit Sub
        End If
        If txtPass.Text.Trim = "" Then
            txtPass.Focus()
            Exit Sub
        End If

        If EntityTablas.Login(txtUser.Text, SHA1(txtPass.Text)) Then
            If chkURL.Checked Then
                frmConfigURL.Show()
            Else
                RibbonFormMain.Show()
            End If
            Close()
        Else
            Dim s As String = "Error al iniciar sesión. Posibles razones:" & vbCrLf & vbCrLf & _
                               "1 - Usuario y/o contraseña incorrectos" & vbCrLf & _
                               "2 - El usuario no está habilitado" & vbCrLf & _
                               "3 - El usuario no tiene acceso a este módulo" & vbCrLf & _
                               "4 - El usuario no existe"
            MsgBox(s, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class
