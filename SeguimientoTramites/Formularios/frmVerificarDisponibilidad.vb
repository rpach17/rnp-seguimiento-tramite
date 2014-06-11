Public Class frmVerificarDisponibilidad

    Private Sub txtCodigoTramite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoTramite.TextChanged
        Dim cant As Integer = txtCodigoTramite.TextLength
        If cant = 12 Then
            EntityTablas.Disponibilidad(txtCodigoTramite.Text, dgvTramites)
            lblInfo.Text = String.Format("{0}", dgvTramites.RowCount())
        Else
            lblInfo.Text = "Ingrese código de trámite completo"
        End If
    End Sub
End Class