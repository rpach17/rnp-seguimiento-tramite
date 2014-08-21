Public Class frmVerificarDisponibilidad

    Private Sub txtCodigoTramite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoTramite.TextChanged
        Dim cant As Integer = txtCodigoTramite.TextLength
        If cant = 12 Then
            EntityTablas.Disponibilidad(txtCodigoTramite.Text, dgvTramites, lblInfo)
        ElseIf cant > 12 Then
            txtCodigoTramite.Text = txtCodigoTramite.Text.Substring(cant - 12, 12)
        ElseIf cant = 0 Then
            lblInfo.Text = ""
        Else
            lblInfo.Text = "Ingrese código de trámite completo"
        End If
    End Sub
End Class