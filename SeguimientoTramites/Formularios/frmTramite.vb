Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DevExpress.XtraReports.UI
Imports System.Xml

Public Class frmTramite
    Dim ReqsObligatorios As Integer
    Dim result As Integer
    Dim IdGestion As Integer
    Dim NombreGestion As String
    Dim cnn As New OracleConnection(My.Settings.Miconexion)

    Public Property IdGestion1() As Integer
        Get
            Return IdGestion
        End Get
        Set(ByVal value As Integer)
            IdGestion = Value
        End Set
    End Property

    Public Property NombreGestion1() As String
        Get
            Return NombreGestion
        End Get
        Set(ByVal value As String)
            NombreGestion = Value
        End Set
    End Property

    Private Sub frmTramite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = String.Format("TRAMITE PARA {0}", NombreGestion)
        BottomRightFormLocation(e)
        ReqsObligatorios = 0
        result = 0

        CargarRequisitos()
    End Sub

    Sub CargarRequisitos()
        'Para limpiar el control Flow
        FlowLayoutPanel1.Controls.Clear()

        Dim lista As List(Of REQUISITOS) = eAPPCA.ObtenerRequisitos(IdGestion)
        For Each requisito In lista
            Dim chk As New CheckBox
            chk.Tag = requisito.IDREQUISITO

            If requisito.OPCIONAL = 0 Then
                chk.Text = requisito.NOMBRE_REQUISITO
                chk.AccessibleDescription = "0"
                ReqsObligatorios += 1
            Else
                chk.Text = String.Format("{0} *", requisito.NOMBRE_REQUISITO)
                chk.AccessibleDescription = "1"
            End If

            chk.AutoSize = False
            chk.Size = New Size(FlowLayoutPanel1.Width - 30, 20)

            FlowLayoutPanel1.Controls.Add(chk)
            AddHandler chk.CheckedChanged, AddressOf EventoChecked
        Next
    End Sub

    Public Sub EventoChecked(ByVal sender As Object, ByVal e As EventArgs)
        'Dim check As CheckBox = TryCast(sender, CheckBox)
        Dim cheques As Integer = 0

        For Each chk As CheckBox In FlowLayoutPanel1.Controls
            If chk.AccessibleDescription = "0" AndAlso chk.Checked Then
                cheques += 1
            End If
        Next

        If ReqsObligatorios = cheques Then
            btnCrearTramite.Text = "Crear trámite"
            btnCrearTramite.Enabled = True
        Else
            btnCrearTramite.Text = "Verificar requisitos"
            btnCrearTramite.Enabled = False
        End If
    End Sub


    Sub BottomRightFormLocation(ByVal evento As EventArgs)
        Dim src = Screen.FromPoint(Location)
        Location = New Point(src.WorkingArea.Right - Width, src.WorkingArea.Bottom - Height)
        MyBase.OnActivated(evento)
    End Sub

    Private Sub txtIdentidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdentidad.TextChanged
        Dim cant As Integer = txtIdentidad.TextLength

        If cant = 13 Then
            result = eAPPCA.BuscarResponsable(txtIdentidad.Text, txtPrimerNombre, txtSegundoNombre, txtPrimerApellido, txtSegundoApellido, txtTelefonoFijo, txtTelefonoMovil, txtCorreo, lblInfo)
        Else
            lblInfo.Visible = False
        End If
    End Sub

    Private Sub txtIdentidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdentidad.KeyPress
        If e.KeyChar = ChrW(13) Then  ' The ENTER key.
            SendKeys.Send("{TAB}")
        End If

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefonoFijo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoFijo.KeyPress
        If e.KeyChar = ChrW(13) Then  ' The ENTER key.
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTelefonoFijo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdentidad.KeyDown, txtCorreo.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub btnCrearTramite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearTramite.Click
        If result = 0 Then
            lblInfo.Visible = True
            lblInfo.Text = "Corregir número de identidad del responsable"
            txtIdentidad.Focus()
        ElseIf result = 1 Then 'Existe en local (UPDATE)
            If txtCorreo.Text.Trim <> "" Then
                If Not ValidarCorreo(txtCorreo.Text) Then
                    MsgBox("El correo electrónico no es correcto", MsgBoxStyle.Exclamation, "Verificar correo")
                    txtCorreo.Focus()
                    Exit Sub
                End If
            
            End If

            crearTramite(eAPPCA.ActualizarResponsable(txtIdentidad.Text, txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text))

        ElseIf result = 2 Then  'Nuevo codigo para insert
            If txtCorreo.Text.Trim <> "" Then
                If Not ValidarCorreo(txtCorreo.Text) Then
                    MsgBox("El correo electrónico no es correcto", MsgBoxStyle.Exclamation, "Verificar correo")
                    txtCorreo.Focus()
                    Exit Sub
                End If
            End If

            crearTramite(eAPPCA.NuevoResponsable(New RESPONSABLE With _
                                                 {
                                                     .NUMERO_IDENTIDAD = txtIdentidad.Text,
                                                     .TELEFONO = txtTelefonoFijo.Text,
                                                     .CELULAR = txtTelefonoMovil.Text,
                                                     .CORREO = txtCorreo.Text
                                                 }))

        End If
    End Sub
    Private Sub crearTramite(ByVal idResponsable As Integer)
        Try
            Using myCMD As New OracleCommand() With {.Connection = cnn, .CommandText = "SP_TRAMITES", .CommandType = CommandType.StoredProcedure}
                myCMD.Parameters.Add("VIDRESPONSABLE", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = idResponsable
                myCMD.Parameters.Add("VIDGESTION", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = IdGestion
                myCMD.Parameters.Add("VNOTA", OracleDbType.NVarchar2, 200, Nothing, ParameterDirection.Input).Value = txtInfoAdicional.Text
                myCMD.Parameters.Add("VIDDETALLE_SUCURSAL_OFICINA", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = SesionActiva.IdSucursalOficina
                myCMD.Parameters.Add("VIDUSUARIO", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = SesionActiva.IdUsuario
                myCMD.Parameters.Add("VTRAMITE", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("VCODIGO", OracleDbType.NVarchar2, 13, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("VFECHA", OracleDbType.NVarchar2, 22, Nothing, ParameterDirection.Output)
                myCMD.Parameters.Add("NGESTION", OracleDbType.NVarchar2, 60, Nothing, ParameterDirection.Output)
                cnn.Open()
                myCMD.ExecuteNonQuery()


                For Each chk As CheckBox In FlowLayoutPanel1.Controls
                    If chk.Checked Then
                        Dim requi As New RECEPCION_REQUISITOS With
                        {
                            .IDTRAMITE = myCMD.Parameters("VTRAMITE").Value.ToString, _
                            .IDREQUISITO = chk.Tag, _
                            .RECIBIDO = 1
                        }

                        eAPPCA.AgregarRequisito(requi)
                    End If
                Next

                ' Imprimir el recibo del trámite
                'Using rpt As New rptReciboTramite()
                '    'rpt.Print()
                'End Using
                Dim url As String = String.Format("http://tramite.rnp.hn/{0}", myCMD.Parameters("VCODIGO").Value.ToString)
                Using rpt As New rptReciboTramite(myCMD.Parameters("VCODIGO").Value.ToString, myCMD.Parameters("NGESTION").Value.ToString, myCMD.Parameters("VFECHA").Value.ToString, txtIdentidad.Text, String.Format("{0} {1} {2} {3}", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text), txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text, txtInfoAdicional.Text, url)
                    Using preview As New ReportPrintTool(rpt)
                        preview.Print()
                    End Using
                End Using

                ' Imprimir el recibo del trámite
                Using rpt As New rptReciboTramite2(myCMD.Parameters("VCODIGO").Value.ToString, myCMD.Parameters("NGESTION").Value.ToString, myCMD.Parameters("VFECHA").Value.ToString, txtIdentidad.Text, String.Format("{0} {1} {2} {3}", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text), txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text, txtInfoAdicional.Text)
                    Using preview As New ReportPrintTool(rpt)
                        preview.Print()
                        'preview.ShowPreviewDialog()
                    End Using
                End Using
            End Using
            MsgBox("El trámite ha sido registrado con éxito", MsgBoxStyle.Information, "Trámite")
            frmTrm.btnCrear.Enabled = False
            'frmVentanilla.btnTramite.Enabled = False
            Close()
        Catch ex As Exception
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnCambirTramite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambirTramite.Click
        frmListadoGestiones.ShowDialog()
    End Sub

    Private Sub frmTramite_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Dim i As Integer = IdGestion
    End Sub
End Class