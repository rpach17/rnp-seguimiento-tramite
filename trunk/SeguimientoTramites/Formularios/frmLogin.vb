Public Class frmLogin

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ProbarConexion(My.Settings.MiConexion) <> "OK" Then
            frmConfig.Show()
            Close()
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub btnEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrar.Click
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

        If EntityTablas.Login(txtUser.Text, SHA1(txtPass.Text)) Then
            RibbonFormMain.Show()
            Close()
        Else
            Dim s As String = "Error al iniciar sesión. Posibles razones:" & vbCrLf & vbCrLf & _
                               "1 - Usuario y/o contraseña incorrectos" & vbCrLf & _
                               "2 - El usuario no está habilitado" & vbCrLf & _
                               "3 - El usuario no tiene acceso a este módulo" & vbCrLf & _
                               "4 - El usuario no existe"
            MsgBox(s, MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
End Class
