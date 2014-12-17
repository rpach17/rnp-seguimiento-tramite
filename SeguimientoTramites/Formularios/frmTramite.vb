Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports DevExpress.XtraReports.UI
Imports System.Xml
Imports System.Threading

Public Class frmTramite
    Dim ReqsObligatorios As Integer
    Dim result As Integer
    Dim IdGestion As Integer
    Dim NombreGestion As String
    Dim cnn As New OracleConnection(My.Settings.MiConexion)
    Dim hilo As Thread

    Public listaReporte As New List(Of DatosReporte)


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
        If IdGestion = 0 Then
            frmListadoGestiones.ShowDialog()
        End If
        EntityTablas.CargarUsuariosDestino(cboEnviarA, IdGestion)
        Text = String.Format("TRAMITE PARA {0}", NombreGestion)
        BottomRightFormLocation(e)
        ReqsObligatorios = 0
        result = 0

        EntityTablas.cagarTipoRespresentate(cboRepresentante)
        CargarRequisitos()
    End Sub

    Sub CargarRequisitos()
        'Para limpiar el control Flow
        FlowLayoutPanel1.Controls.Clear()

        Dim lista As List(Of REQUISITOS) = EntityTablas.ObtenerRequisitos(IdGestion)
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
            Control.CheckForIllegalCrossThreadCalls = False
            hilo = New Thread(AddressOf Animacion)
            hilo.Start()
            result = EntityTablas.BuscarResponsable(txtIdentidad.Text, txtPrimerNombre, txtSegundoNombre, txtPrimerApellido, txtSegundoApellido, txtTelefonoFijo, txtTelefonoMovil, txtCorreo, lblInfo)
            hilo.Abort()
        Else
            lblInfo.Visible = False
        End If
    End Sub

    Sub Animacion()
        frmAnimacionProceso.lblTexto.Text = "¡Buscando Ciudadano!"
        frmAnimacionProceso.ShowDialog()
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

            If txtNumTramites.Value = 1 Then
                crearTramite(EntityTablas.ActualizarResponsable(txtIdentidad.Text, txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text))
            ElseIf txtNumTramites.Value > 1 Then
                Dim resposnable As Integer = EntityTablas.ActualizarResponsable(txtIdentidad.Text, txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text)
                For t As Integer = 1 To txtNumTramites.Value - 1
                    crearTramite(resposnable)
                Next
                crearTramite(resposnable)
            End If

        ElseIf result = 2 Then  'Nuevo codigo para insert
            If txtCorreo.Text.Trim <> "" Then
                If Not ValidarCorreo(txtCorreo.Text) Then
                    MsgBox("El correo electrónico no es correcto", MsgBoxStyle.Exclamation, "Verificar correo")
                    txtCorreo.Focus()
                    Exit Sub
                End If
            End If
            Dim responsable As Integer = EntityTablas.NuevoResponsable(New RESPONSABLE With _
                                                             {
                                                                 .NUMERO_IDENTIDAD = txtIdentidad.Text,
                                                                 .NOMBRE = String.Format("{0} {1}", txtPrimerNombre.Text, txtSegundoNombre.Text),
                                                                 .PRIMER_APELLIDO = txtPrimerApellido.Text,
                                                                 .SEGUNDO_APELLIDO = txtSegundoApellido.Text,
                                                                 .TELEFONO = txtTelefonoFijo.Text,
                                                                 .CELULAR = txtTelefonoMovil.Text,
                                                                 .CORREO = txtCorreo.Text
                                                             })
            If txtNumTramites.Value = 1 Then
                crearTramite(responsable)
            ElseIf txtNumTramites.Value > 1 Then
                For t As Integer = 1 To txtNumTramites.Value - 1
                    crearTramite(responsable)
                Next
                crearTramite(responsable)
            End If
        End If
        imprimir()
        Close()
    End Sub

    Private Sub imprimir()
        If listaReporte.Count > 1 Then

            For Each r In listaReporte
                Using rpt As New rptReciboTramite2(r.codigo, r.nGestion, r.fecha, r.identidad, _
                                                   r.nombreCiudadano, r.tFijo, r.tMovil, _
                                                   r.email, r.nota, r.nRecibo, r.monto, r.codigoRNP)
                    Using preview As New ReportPrintTool(rpt)
                        'preview.Print()
                        preview.ShowPreviewDialog()
                    End Using
                End Using
            Next
            Using rpt As New rptReciboTramiteVarios(listaReporte)
                Using preview As New ReportPrintTool(rpt)
                    'preview.Print()
                    preview.ShowPreviewDialog()
                End Using
            End Using

        Else
            For Each r In listaReporte
                Using rpt As New rptReciboTramite2(r.codigo, r.nGestion, r.fecha, r.identidad, _
                                                   r.nombreCiudadano, r.tFijo, r.tMovil, _
                                                   r.email, r.nota, r.nRecibo, r.monto, r.codigoRNP)
                    Using preview As New ReportPrintTool(rpt)
                        'preview.Print()
                        preview.ShowPreviewDialog()
                    End Using
                End Using
                Using rpt As New rptReciboTramite(r.codigo, r.nGestion, r.fecha, r.identidad, r.nombreCiudadano, r.tFijo, r.tMovil, r.email, r.nota, String.Format("http://tramites.rnp.hn/{0}", r.codigo), r.codigoRNP)
                    Using preview As New ReportPrintTool(rpt)
                        'preview.Print()
                        preview.ShowPreviewDialog()
                    End Using
                End Using
            Next

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
                myCMD.Parameters.Add("VIDUSUARIO_DESTINO", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = cboEnviarA.SelectedValue
                myCMD.Parameters.Add("VRECIBO", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = txtNumeroRecibo.Text
                myCMD.Parameters.Add("VRECIBO_MONTO", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = txtMontoRecibo.Text
                myCMD.Parameters.Add("VCANTIDAD_DOCS", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = txtCantidadDocs.Value
                myCMD.Parameters.Add("VTIPO_REPRESENTANTE", OracleDbType.Decimal, 10, Nothing, ParameterDirection.Input).Value = cboRepresentante.SelectedValue
                myCMD.Parameters.Add("VCODIGO_OPCIONAL", OracleDbType.NVarchar2, 30, Nothing, ParameterDirection.Input).Value = txtCodigoTramiteS.Text
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

                        EntityTablas.AgregarRequisito(requi)
                    End If
                Next

                ' Imprimir el recibo del trámite
                'Using rpt As New rptReciboTramite()
                '    'rpt.Print()
                'End Using
                Dim url As String = String.Format("http://tramites.rnp.hn/{0}", myCMD.Parameters("VCODIGO").Value.ToString)

                Dim rte As New DatosReporte With _
                    {
                        .codigo = myCMD.Parameters("VCODIGO").Value.ToString,
                        .nGestion = myCMD.Parameters("NGESTION").Value.ToString,
                        .fecha = myCMD.Parameters("VFECHA").Value.ToString,
                        .identidad = txtIdentidad.Text,
                        .nombreCiudadano = String.Format("{0} {1} {2} {3}", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text),
                        .tFijo = txtTelefonoFijo.Text,
                        .tMovil = txtTelefonoMovil.Text,
                        .email = txtCorreo.Text,
                        .nota = txtInfoAdicional.Text,
                        .nRecibo = txtNumeroRecibo.Text,
                        .monto = txtMontoRecibo.Text,
                        .codigoRNP = txtCodigoTramiteS.Text
                    }

                listaReporte.Add(rte)

                'If varios Then
                '    Using rpt As New rptReciboTramite2(myCMD.Parameters("VCODIGO").Value.ToString, _
                '                                       myCMD.Parameters("NGESTION").Value.ToString, _
                '                                       myCMD.Parameters("VFECHA").Value.ToString, _
                '                                       txtIdentidad.Text, String.Format("{0} {1} {2} {3}", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text), _
                '                                       txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text, txtInfoAdicional.Text, txtNumeroRecibo.Text, txtMontoRecibo.Text)
                '        Using preview As New ReportPrintTool(rpt)
                '            'preview.Print()
                '            preview.ShowPreviewDialog()
                '        End Using
                '    End Using
                'Else
                '    Using rpt As New rptReciboTramite(myCMD.Parameters("VCODIGO").Value.ToString, myCMD.Parameters("NGESTION").Value.ToString, myCMD.Parameters("VFECHA").Value.ToString, txtIdentidad.Text, String.Format("{0} {1} {2} {3}", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text), txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text, txtInfoAdicional.Text, url)
                '        Using preview As New ReportPrintTool(rpt)
                '            'preview.Print()
                '            preview.ShowPreviewDialog()
                '        End Using
                '    End Using

                '    ' Imprimir el recibo del trámite
                '    Using rpt As New rptReciboTramite2(myCMD.Parameters("VCODIGO").Value.ToString, myCMD.Parameters("NGESTION").Value.ToString, myCMD.Parameters("VFECHA").Value.ToString, txtIdentidad.Text, String.Format("{0} {1} {2} {3}", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text), txtTelefonoFijo.Text, txtTelefonoMovil.Text, txtCorreo.Text, txtInfoAdicional.Text, txtNumeroRecibo.Text, txtMontoRecibo.Text)
                '        Using preview As New ReportPrintTool(rpt)
                '            'preview.Print()
                '            preview.ShowPreviewDialog()
                '        End Using
                '    End Using
                'End If
            End Using
            'MsgBox("El trámite ha sido registrado con éxito", MsgBoxStyle.Information, "Trámite")
            'frmTrm.btnCrear.Enabled = False
            'frmVentanilla.btnTramite.Enabled = False
            'Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical, "Error")
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnCambirTramite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambirTramite.Click
        frmListadoGestiones.ShowDialog()
        EntityTablas.CargarUsuariosDestino(cboEnviarA, IdGestion)
    End Sub

    Private Sub frmTramite_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Dim i As Integer = IdGestion
    End Sub


End Class