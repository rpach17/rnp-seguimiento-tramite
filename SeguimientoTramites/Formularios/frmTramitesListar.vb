Public Class frmTramitesListar

    Private Sub txtCodigoTramite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoTramite.TextChanged
        Dim cant As Integer = txtCodigoTramite.TextLength
        If cant = 12 Then
            EntityTablas.historial(txtCodigoTramite.Text, lblCodigo, lblTramite, lblActivo, dgvTramites)
            txtCodigoTramite.Text = ""
            txtCodigoTramite.Focus()
        ElseIf cant > 12 Then
            txtCodigoTramite.Text = txtCodigoTramite.Text.Substring(cant - 12, 12)
        ElseIf cant = 0 Then
            lblInfo.Text = ""
        Else
            lblInfo.Text = "Ingrese código de trámite completo"
        End If
    End Sub

    Private Sub frmHistorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EntityTablas.historialTramitesIniciados(dgvTramites)
        lblActivo.Text = ""
        lblCodigo.Text = ""
        lblTramite.Text = ""
    End Sub
End Class