Public Class frmProcesarDocumentos

    Private Sub frmProcesarDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EntityTablas.TramitesAProcesar(dgvTramites)
    End Sub

    Private Sub dgvTramites_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTramites.CellClick
        If e.ColumnIndex = 6 Then
            'Dim iddt As Integer = dgvTramites.CurrentRow().Cells(0).Value
            'Dim ids As Integer = dgvTramites.CurrentRow().Cells(1).Value
            Dim idF As Integer = dgvTramites.CurrentRow().Cells(3).Value

            If dgvTramites.CurrentRow().Cells(2).Value = 0 Then

                Dim url As String = String.Format("http://win8virtual/forms/index.php?id={0}", idF)
                'Dim url As String = "http://getbootstrap.com/2.3.2/base-css.html#forms"
                Using frm As New frmFormulario
                    frm.Height = 700
                    frm.Width = 857
                    frm.StartPosition = FormStartPosition.CenterScreen
                    frm.WebBrowser1.Url = New Uri(url)
                    frm.ShowDialog()
                End Using
            Else
                'Using frmDecidir
                '    frmDecidir.Ids1 = ids
                '    frmDecidir.Iddt1 = iddt
                '    frmDecidir.ShowDialog()
                'End Using
            End If

            EntityTablas.TramitesAProcesar(dgvTramites)
        End If
    End Sub
End Class