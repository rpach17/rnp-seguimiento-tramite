Imports DevExpress.XtraTabbedMdi
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types

Public Class RibbonFormMain
    Dim cnn As New OracleConnection(My.Settings.MiConexion)

    Private Sub GestionarPanel()
        If XTabManager.Pages.Count = 0 Then
            ClientPanel.Visible = True
        Else
            ClientPanel.Visible = False
        End If
    End Sub

    Private Sub XTabManager_Pages(ByVal sender As Object, ByVal e As MdiTabPageEventArgs) Handles XTabManager.PageAdded, XTabManager.PageRemoved
        GestionarPanel()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        With frmRecepcionDocs
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            frmProcesarDocumentos.Close()            
        Catch ex As Exception

        End Try
        With frmProcesarDocumentos
            .MdiParent = Me
            .Show()
            .Focus()
        End With

    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        With frmVerificarDisponibilidad
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        frmLogin.Show()
        Close()
    End Sub

    Private Sub BarButtonItem7_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Application.Exit()
    End Sub

    Private Sub RibbonFormMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            frmNotificacion.Close()
        Catch ex As Exception
        End Try
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

    Private Sub tmNotificacion_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmNotificacion.Tick
        CargarTramitesAtrasados()
    End Sub

    Private Sub RibbonFormMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CargarTramitesAtrasados()
        tmNotificacion.Enabled = True

        lblConectadoComo.Caption = String.Format("{0} ({1})", SesionActiva.Nombre, SesionActiva.Usuario)
        lblUbicacion.Caption = String.Format("[{0}, {1}] - {2}, {3}", SesionActiva.Depto, SesionActiva.Municipio, SesionActiva.Sucursal, SesionActiva.Oficina)
        If EntityTablas.PrimerPaso(SesionActiva.IdUsuario) Then
            BarButtonItem9.Enabled = True
        Else
            BarButtonItem9.Enabled = False
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        With frmEntregaDocs
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        With frmTramite
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        With frmHistorial
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub
End Class