Imports DevExpress.XtraReports.UI
Imports Oracle.DataAccess.Client

Public Class frmEntregaDocs
    Dim cnn As New OracleConnection(My.Settings.Miconexion)

    Private Sub frmEntregaDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        eAPPCA.TramitesEntregar(dgvTramites)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        eAPPCA.TramitesEntregar(dgvTramites, txtCodigoTramite.Text)
    End Sub

    Private Tramitess As New List(Of TRAMITES)
    Private Sub dgvTramites_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTramites.CellClick
        If e.RowIndex < 0 OrElse Not e.ColumnIndex = dgvTramites.Columns("Entregar").Index Then Return

        Try
            Using myCMD As New OracleCommand() With _
           {
               .Connection = cnn, _
               .CommandText = "SP_ENTREGA_TRAMITE", _
               .CommandType = CommandType.StoredProcedure
           }

                cnn.Open()
                Dim IdDT As Integer = DameID(dgvTramites)
                With myCMD
                    .Parameters.Add("VIDDETALLE_TRAMITE", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = IdDT
                    .Parameters.Add("VNOMBRE", OracleDbType.Varchar2, 140, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VIDENTIDAD", OracleDbType.Varchar2, 13, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VTELEFONO", OracleDbType.Varchar2, 9, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VCELULAR", OracleDbType.Varchar2, 9, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VCORREO", OracleDbType.Varchar2, 70, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VFECHA_ENTREGA", OracleDbType.Varchar2, 10, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VTRAMITE", OracleDbType.Varchar2, 120, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VCODIGO_TRAMITE", OracleDbType.Varchar2, 12, Nothing, ParameterDirection.Output)
                    .Parameters.Add("VFECHA_INICIO", OracleDbType.Varchar2, 10, Nothing, ParameterDirection.Output)
                    .ExecuteNonQuery()
                End With

                Using rpt As New rptRecibo(myCMD.Parameters("VNOMBRE").Value.ToString, _
                                            myCMD.Parameters("VIDENTIDAD").Value.ToString, _
                                            myCMD.Parameters("VTELEFONO").Value.ToString, _
                                            myCMD.Parameters("VCELULAR").Value.ToString, _
                                            myCMD.Parameters("VCORREO").Value.ToString, _
                                            SesionActiva.Nombre, _
                                            myCMD.Parameters("VTRAMITE").Value.ToString, _
                                            myCMD.Parameters("VCODIGO_TRAMITE").Value.ToString, _
                                            myCMD.Parameters("VFECHA_INICIO").Value.ToString, _
                                            myCMD.Parameters("VFECHA_ENTREGA").Value.ToString)

                    Using pr As New ReportPrintTool(rpt)
                        'pr.ShowPreviewDialog()
                        pr.Print()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnn.Close()
        End Try

        'eAPPCA.entregaTramite(DameID(dgvTramites))
        'eAPPCA.entregaTramite(DameID(dgvTramites))
        MsgBox(String.Format("Tramite {0} Entregado", DameID(dgvTramites, 1)))
        eAPPCA.TramitesEntregar(dgvTramites)

    End Sub
End Class