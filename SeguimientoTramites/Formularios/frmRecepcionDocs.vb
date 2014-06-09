Imports Oracle.DataAccess.Client

Public Class frmRecepcionDocs
    Dim cnn As New OracleConnection(My.Settings.MiConexion)

    Private Sub txtCodigoTramite_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoTramite.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub frmRecepcionDocs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EntityTablas.TramitesRecibir(dgvTramites)
    End Sub

    Private Sub txtCodigoTramite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoTramite.TextChanged
        Dim cant As Integer = txtCodigoTramite.TextLength
        If cant = 12 Then
            RecepcionarTramite(txtCodigoTramite.Text)
        Else
            lblInfo.Text = "Ingrese código de trámite completo"
        End If
    End Sub

    Private Sub RecepcionarTramite(ByVal barcode As String)
        Try
            Using myCMD As New OracleCommand() With
                {
                    .Connection = cnn,
                    .CommandText = "SP_RECEPCION_TRAMITE",
                    .CommandType = CommandType.StoredProcedure
                }

                myCMD.Parameters.Add("VCODIGO", OracleDbType.NVarchar2, 12, Nothing, ParameterDirection.Input).Value = barcode
                myCMD.Parameters.Add("VIDUSUARIO", OracleDbType.Decimal, 12, Nothing, ParameterDirection.Input).Value = SesionActiva.IdUsuario
                myCMD.Parameters.Add("VIDDETALLE_SUCURSAL_OFICINA", OracleDbType.Decimal, 12, Nothing, ParameterDirection.Input).Value = SesionActiva.IdSucursalOficina
                myCMD.Parameters.Add("EXISTE", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("VACTIVO", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("MISMAOFICINA", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)

                cnn.Open()
                myCMD.ExecuteNonQuery()

                If myCMD.Parameters("EXISTE").Value = 0 Then
                    lblInfo.Text = "El trámite ingresado no existe"
                ElseIf myCMD.Parameters("VACTIVO").Value = 0 Then
                    lblInfo.Text = "El trámite ingresado ya está finalizado"
                ElseIf myCMD.Parameters("MISMAOFICINA").Value = 0 Then
                    lblInfo.Text = "El trámite ingresa corresponde a otra oficina"
                Else
                    txtCodigoTramite.Text = ""
                    EntityTablas.TramitesRecibir(dgvTramites)
                    txtCodigoTramite.Focus()
                    lblInfo.Text = "El trámite fue recibido"
                End If
            End Using
        Catch ex As Exception
            lblInfo.Text = ex.Message
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnRecibirTramites_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecibirTramites.Click
        For Each fila As DataGridViewRow In dgvTramites.Rows
            If Convert.ToBoolean(fila.Cells(4).Value) Then
                Dim barcode As String = fila.Cells(0).Value
                RecepcionarTramite(barcode)
            End If
        Next
    End Sub
End Class