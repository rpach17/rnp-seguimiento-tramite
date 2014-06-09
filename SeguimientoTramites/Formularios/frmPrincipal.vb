Public Class frmPrincipal

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblInfoConexion.Text = String.Format("{0} ({1})", SesionActiva.Nombre, SesionActiva.Usuario)
        lblInfoUbicacion.Text = String.Format("{0}, {1}", SesionActiva.Sucursal, SesionActiva.Oficina)

        Dim ctlMDI As MdiClient
        For Each ctl As Control In Controls
            Try
                ctlMDI = DirectCast(ctl, MdiClient)
                ctlMDI.BackColor = BackColor
            Catch ex As InvalidCastException
            End Try
        Next

        frmRecepcionDocs.MdiParent = Me
        frmRecepcionDocs.Show()
    End Sub

    Private Sub RecepciónDeDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepciónDeDocumentosToolStripMenuItem.Click
        frmRecepcionDocs.MdiParent = Me
        frmRecepcionDocs.Show()
    End Sub

    Private Sub ProcesarDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcesarDocumentosToolStripMenuItem.Click
        frmProcesarDocumentos.MdiParent = Me
        frmProcesarDocumentos.Show()
    End Sub
End Class