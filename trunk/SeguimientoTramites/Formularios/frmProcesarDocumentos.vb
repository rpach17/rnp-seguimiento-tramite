Public Class frmProcesarDocumentos

    Private Sub frmProcesarDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EntityTablas.TramitesAProcesar(dgvTramites)
    End Sub

    Private Sub dgvTramites_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvTramites.CellClick
        If e.ColumnIndex = 9 Then
            Dim idds As Integer = dgvTramites.CurrentRow().Cells(0).Value
            Dim idgs As Integer = dgvTramites.CurrentRow().Cells(1).Value
            Dim ids As Integer = dgvTramites.CurrentRow().Cells(2).Value
            Dim numS As Integer = dgvTramites.CurrentRow().Cells(3).Value
            Dim idf As Integer = dgvTramites.CurrentRow().Cells(5).Value
            Dim idt As Integer = dgvTramites.CurrentRow().Cells(6).Value
            Dim codTram As String = dgvTramites.CurrentRow().Cells(7).Value

            If dgvTramites.CurrentRow().Cells(4).Value = 0 Then ' Comprueba si el salto tiene decision
                If EntityTablas.SaltoDescargable(ids) Then
                    With frmDescargarDoc
                        .Iddseguimiento1 = idds
                        .Ids1 = ids
                        .IdTramite1 = idt
                        .NombreDoc1 = codTram
                        .IdGS1 = idgs
                        .NumSalto1 = numS + 1
                        .ShowDialog()
                    End With
                Else
                    'Dim url As String = String.Format("http://win8virtual/forms/index.php?id={0}", idf)
                    'Dim url As String = String.Format("http://localhost/forms/index.php?id={0}", idf)
                    'Dim url As String = "http://getbootstrap.com/2.3.2/base-css.html#forms"
                    Using frm As New frmFormularioChrome
                        frm.IdSalto1 = EntityTablas.ObtenerSiguienteSalto(idgs, numS + 1)
                        frm.IdForm1 = idf
                        frm.IdDetalleSeguimiento1 = idds
                        frm.Height = 700
                        frm.Width = 857
                        frm.EsEntrega1 = False
                        frm.ShowDialog()
                    End Using
                End If
            Else ' Hay decisión
                Using frmDecidir
                    frmDecidir.Ids1 = ids
                    frmDecidir.Iddt1 = idds
                    frmDecidir.ShowDialog()
                End Using
            End If

            EntityTablas.TramitesAProcesar(dgvTramites)
        End If
    End Sub

End Class