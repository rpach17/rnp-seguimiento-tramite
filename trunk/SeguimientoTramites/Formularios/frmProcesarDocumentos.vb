﻿Public Class frmProcesarDocumentos

    Private Sub frmProcesarDocumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EntityTablas.TramitesAProcesar(dgvTramites)
    End Sub

    Private Sub dgvTramites_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvTramites.CellClick
        If e.ColumnIndex = 8 Then
            Dim idds As Integer = dgvTramites.CurrentRow().Cells(0).Value
            Dim ids As Integer = dgvTramites.CurrentRow().Cells(2).Value
            Dim idf As Integer = dgvTramites.CurrentRow().Cells(5).Value

            If dgvTramites.CurrentRow().Cells(4).Value = 0 Then ' Comprueba si el salto tiene decision
                If EntityTablas.SaltoDescargable(ids) Then

                Else
                    'Dim url As String = String.Format("http://win8virtual/forms/index.php?id={0}", idf)
                    'Dim url As String = String.Format("http://localhost/forms/index.php?id={0}", idf)
                    'Dim url As String = "http://getbootstrap.com/2.3.2/base-css.html#forms"
                    Using frm As New frmFormulario
                        frm.IdSalto1 = EntityTablas.ObtenerSiguienteSalto(dgvTramites.CurrentRow().Cells(1).Value, dgvTramites.CurrentRow().Cells(3).Value + 1)
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