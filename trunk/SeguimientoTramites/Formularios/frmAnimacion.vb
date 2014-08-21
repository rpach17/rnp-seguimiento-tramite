Imports System.Threading

Public Class frmAnimacion
    Dim hilo As Thread
    Dim frm As Integer

    Private Sub frmAnimacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If hilo.ThreadState = ThreadState.Running Then
            hilo.Abort()
        End If

        If frm = 1 Then
            frmConfig.Show()
        ElseIf frm = 2 Then
            frmLogin.Show()
        End If
    End Sub

    Private Sub frmAnimacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        hilo = New Thread(AddressOf IntentarConexion)
        hilo.Start()
    End Sub

    Sub IntentarConexion()
        If ProbarConexion(My.Settings.MiConexion) <> "OK" Then
            frm = 1
            Close()
        Else
            frm = 2
            Close()
        End If
    End Sub
End Class