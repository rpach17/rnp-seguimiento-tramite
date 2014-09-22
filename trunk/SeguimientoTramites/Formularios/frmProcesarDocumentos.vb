Public Class frmProcesarDocumentos

    Private Sub frmProcesarDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EntityTablas.TramitesConDecision(dgvTramites)
    End Sub

    Private Sub dgvTramites_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTramites.CellClick
        If e.ColumnIndex = 4 Then
            Dim iddt As Integer = dgvTramites.CurrentRow().Cells(0).Value
            Dim ids As Integer = dgvTramites.CurrentRow().Cells(1).Value
            Dim idF As Integer = dgvTramites.CurrentRow().Cells(2).Value

            Using frm As New frmFormulario
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.WebBrowser1.Url = New Uri("http://google.com")
                frm.ShowDialog()
            End Using

            'Using frmDecidir
            '    frmDecidir.Ids1 = ids
            '    frmDecidir.Iddt1 = iddt
            '    frmDecidir.ShowDialog()
            'End Using

            EntityTablas.TramitesConDecision(dgvTramites)
        End If
    End Sub
End Class