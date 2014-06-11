Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Public Class frmPrincipal
    Dim cnn As New OracleConnection(My.Settings.MiConexion)

    Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            frmNotificacion.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTramitesAtrasados()
        tmNotificacion.Enabled = True

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

    Private Sub CerrarSesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        frmLogin.Show()
        Close()
    End Sub

    Sub CargarTramitesAtrasados()
        Try
            Using myCMD As New OracleCommand() With {.Connection = cnn, .CommandText = "SP_TRAMITES_SIN_ENTREGAR", .CommandType = CommandType.StoredProcedure}
                myCMD.Parameters.Add("VIDUSER", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = SesionActiva.IdUsuario
                Dim refCursor As OracleParameter = New OracleParameter With
                {
                    .OracleDbType = OracleDbType.RefCursor,
                    .Direction = ParameterDirection.Output
                }
                myCMD.Parameters.Add(refCursor)
                cnn.Open()
                myCMD.ExecuteNonQuery()

                Dim cursor As OracleRefCursor = DirectCast(refCursor.Value, OracleRefCursor)
                Dim reader As OracleDataReader = cursor.GetDataReader
                'Dim fi As FieldInfo = reader.GetType().GetField("m_rowSize", BindingFlags.Instance & BindingFlags.NonPublic)
                'Dim rowSize As Integer = Convert.ToInt32(fi.GetValue(reader))
                'reader.FetchSize = rowSize * 100

                If reader.HasRows Then
                    frmNotificacion.dgvTramites.Rows.Clear()

                    While reader.Read
                        frmNotificacion.dgvTramites.Rows.Add(reader("CODIGOTRAMITE").ToString, MinutosAHoras(CInt(reader("MINUTOS_PASADOS"))), reader("NUMERO_SALTO").ToString, String.Format("{0} minutos", reader("MINUTOS").ToString))
                    End While

                    frmNotificacion.lblInfo.Text = String.Format("Usted tiene {0} trámites pendientes de entrega", frmNotificacion.dgvTramites.Rows.Count)

                    reader.Close()
                    refCursor.Dispose()

                    frmNotificacion.TopMost = True
                    frmNotificacion.Show()
                End If

            End Using
        Catch ex As Exception
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub tmNotificacion_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmNotificacion.Tick
        CargarTramitesAtrasados()
    End Sub

    Private Sub VerificarDisponibilidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerificarDisponibilidadToolStripMenuItem.Click
        frmVerificarDisponibilidad.MdiParent = Me
        frmVerificarDisponibilidad.Show()
    End Sub
End Class