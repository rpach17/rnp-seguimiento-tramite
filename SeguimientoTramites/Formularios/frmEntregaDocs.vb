Imports DevExpress.XtraReports.UI
Imports Oracle.DataAccess.Client

Public Class frmEntregaDocs
    Dim cnn As New OracleConnection(My.Settings.Miconexion)

    Private Sub frmEntregaDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EntityTablas.TramitesEntregar(dgvTramites)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        EntityTablas.TramitesEntregar(dgvTramites, txtCodigoTramite.Text)
    End Sub

    Private Tramitess As New List(Of TRAMITES)
    Private Sub dgvTramites_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTramites.CellClick
        If e.RowIndex < 0 OrElse Not e.ColumnIndex = dgvTramites.Columns("Entregar").Index Then Return

        Using frm As New frmFormularioChromeEntrega
            frm.IdDetalleSeguimiento1 = dgvTramites.CurrentRow().Cells(1).Value
            frm.IdSalto1 = dgvTramites.CurrentRow().Cells(2).Value
            frm.IdForm1 = dgvTramites.CurrentRow().Cells(3).Value
            frm.EsEntrega1 = True
            frm.Height = 700
            frm.Width = 857
            frm.ShowDialog()
        End Using

        'eAPPCA.entregaTramite(DameID(dgvTramites))
        'eAPPCA.entregaTramite(DameID(dgvTramites))
        'MsgBox(String.Format("Tramite {0} Entregado", DameID(dgvTramites, 1)))
        EntityTablas.TramitesEntregar(dgvTramites)

    End Sub


End Class