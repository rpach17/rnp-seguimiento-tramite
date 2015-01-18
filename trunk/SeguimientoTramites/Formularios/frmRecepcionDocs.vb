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

    Private Sub frmRecepcionDocs_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        EntityTablas.TramitesRecibir(dgvTramites)
    End Sub

    Private Sub txtCodigoTramite_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCodigoTramite.TextChanged
        Dim cant As Integer = txtCodigoTramite.TextLength
        If cant = 12 Then
            RecepcionarTramite(txtCodigoTramite.Text)
        ElseIf cant > 12 Then
            txtCodigoTramite.Text = txtCodigoTramite.Text.Substring(cant - 12, 12)
        ElseIf cant = 0 Then
            lblInfo.Text = ""
        Else
            lblInfo.Text = "Ingrese código de trámite completo"
        End If
    End Sub

    Public Sub RecepcionarTramite(ByVal barcode As String)
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
                myCMD.Parameters.Add("VRETORNO", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("EXISTE", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("VACTIVO", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("MISMAOFICINA", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)

                cnn.Open()
                myCMD.ExecuteNonQuery()

                Dim r = myCMD.Parameters("VRETORNO").Value

                If r = 0 Then
                    txtCodigoTramite.Text = ""
                    EntityTablas.TramitesRecibir(dgvTramites)
                    txtCodigoTramite.Focus()
                    lblInfo.Text = "El trámite fue recibido"
                ElseIf r = 1 Then
                    lblInfo.Text = "El trámite ingresado no existe"
                ElseIf r = 2 Then
                    lblInfo.Text = "El trámite ingresado ya está finalizado"
                ElseIf r = 3 Then
                    lblInfo.Text = "El trámite ingresa corresponde a otra oficina"
                ElseIf r = 4 Then
                    lblInfo.Text = "El trámite en este momento no lo puede recibir"
                End If

                'If myCMD.Parameters("EXISTE").Value = 0 Then
                '    lblInfo.Text = "El trámite ingresado no existe"
                'ElseIf myCMD.Parameters("VACTIVO").Value = 0 Then
                '    lblInfo.Text = "El trámite ingresado ya está finalizado"
                'ElseIf myCMD.Parameters("MISMAOFICINA").Value = 0 Then
                '    lblInfo.Text = "El trámite ingresa corresponde a otra oficina"
                'Else
                '    txtCodigoTramite.Text = ""
                '    EntityTablas.TramitesRecibir(dgvTramites)
                '    txtCodigoTramite.Focus()
                '    lblInfo.Text = "El trámite fue recibido"
                'End If
            End Using
        Catch ex As Exception
            lblInfo.Text = ex.Message
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub RecepcionarTramiteGrid(ByVal barcode As String)
        Try
            Using myCMD As New OracleCommand() With
                {
                    .Connection = cnn,
                    .CommandText = "SP_RECEPCION_TRAMITE",
                    .CommandType = CommandType.StoredProcedure
                }

                With myCMD.Parameters
                    .Add("VCODIGO", OracleDbType.NVarchar2, 12, Nothing, ParameterDirection.Input).Value = barcode
                    .Add("VIDUSUARIO", OracleDbType.Decimal, 12, Nothing, ParameterDirection.Input).Value = SesionActiva.IdUsuario
                    .Add("VIDDETALLE_SUCURSAL_OFICINA", OracleDbType.Decimal, 12, Nothing, ParameterDirection.Input).Value = SesionActiva.IdSucursalOficina
                    .Add("VRETORNO", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                    .Add("EXISTE", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                    .Add("VACTIVO", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                    .Add("MISMAOFICINA", OracleDbType.Decimal, 1, Nothing, ParameterDirection.Output)
                End With

                cnn.Open()
                myCMD.ExecuteNonQuery()
            End Using
        Catch ex As OracleException
            lblInfo.Text = ex.Message
        Catch ex As Exception
            lblInfo.Text = ex.Message
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnRecibirTramites_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecibirTramites.Click
        If dgvTramites.RowCount = 0 Then
            lblInfo.Text = "No hay trámites"
            Exit Sub
        End If

        For Each fila As DataGridViewRow In dgvTramites.Rows
            If Convert.ToBoolean(fila.Cells(4).Value) Then
                Dim barcode As String = fila.Cells(0).Value
                RecepcionarTramiteGrid(barcode)
            End If
        Next

        txtCodigoTramite.Text = ""
        EntityTablas.TramitesRecibir(dgvTramites)
        txtCodigoTramite.Focus()
        lblInfo.Text = "Los trámites fueron recibidos"
    End Sub


    Private Sub BtnSeleccionar_Click(sender As Object, e As EventArgs) Handles BtnSeleccionar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        If dgvTramites.Rows.Count >= 1 And BtnSeleccionar.Text = "Seleccionar todos" Then
            For Each row In dgvTramites.Rows
                row.cells(4).value = True
            Next
            BtnSeleccionar.Text = "Quitar todo"
        ElseIf dgvTramites.Rows.Count >= 1 And BtnSeleccionar.Text = "Quitar todo" Then
            For Each row In dgvTramites.Rows
                row.cells(4).value = False
            Next
            BtnSeleccionar.Text = "Seleccionar todos"
        End If
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub
End Class