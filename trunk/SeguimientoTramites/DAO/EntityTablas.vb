Public Class EntityTablas
    Shared ctx As New Entidades(My.Settings.CadenaAppcaSeguimiento)

#Region "Login"
    Public Shared Function Login(ByVal user As String, ByVal pass As String) As Boolean
        Dim usu = (From users In ctx.USUARIOS
                   Where users.USUARIO = user AndAlso users.CONTRASENA = pass AndAlso users.ESTADO = 1
                   Select users).ToList()

        If usu.Count = 1 Then
            Try
                For Each u In usu
                    With SesionActiva
                        .IdUsuario = u.IDUSUARIO
                        .Nombre = String.Format("{0} {1}", u.NOMBRE, u.APELLIDOS)
                        .Usuario = u.USUARIO
                        .Sucursal = u.DETALLE_SUCURSAL_OFICINA.SUCURSALES.NOMBRE
                        .Oficina = u.DETALLE_SUCURSAL_OFICINA.OFICINAS.NOMBRE_OFICINA
                        .IdSucursalOficina = u.IDDETALLE_SUCURSAL_OFICINA
                        .IdPuesto = u.IDPUESTO
                        .NombrePuesto = u.PUESTO.NOMBRE_PUESTO
                    End With
                Next
                Return True
            Catch ex As Exception
                Return False 'Usuario sin puesto genera un error, devolvemos False
            End Try
        Else
            Return False
        End If
    End Function
#End Region

#Region "Recepcion de tramites"
    Public Shared Sub TramitesRecibir(ByVal grid As DataGridView)

        ' Lista de los saltos que puede atender
        Dim saltosAtender = (From s In ctx.SALTOS
                             Where s.IDPUESTO = SesionActiva.IdPuesto And s.NUMERO_SALTO > 1
                             Select s.IDSALTO).ToList


       
        'Se buscan los tramites que se pueden recibir
        Dim tramites = (From dt In ctx.DETALLE_TRAMITE
                       Join u In ctx.USUARIOS On dt.IDUSUARIO Equals u.IDUSUARIO
                       Join s In ctx.SALTOS On dt.IDSALTO Equals s.IDSALTO
                       Where dt.TRAMITES.ACTIVO = 1 And dt.FECHA_ENTREGA Is Nothing AndAlso saltosAtender.Contains(dt.DESTINO)
                       Order By dt.TRAMITES.CODIGOTRAMITE
                       Select dt.TRAMITES.CODIGOTRAMITE, Gestion = dt.TRAMITES.GESTIONES.NOMBRE, u.NOMBRE, u.APELLIDOS, s.NUMERO_SALTO).ToList()

        's.DECISION = 0 OrElse (s.DECISION = 1 And Not dt.DESTINO Is Nothing AndAlso saltosAtender.Contains(dt.DESTINO)))


        grid.Rows.Clear()
        For Each tramite In tramites
            grid.Rows.Add(tramite.CODIGOTRAMITE, tramite.Gestion, String.Format("{0} {1}", tramite.NOMBRE, tramite.APELLIDOS), tramite.NUMERO_SALTO)
        Next
        'grid.DataSource = tramites
    End Sub

    Shared Sub TramitesConDecision(ByVal grid As DataGridView)
        Dim tramites = (From dt In ctx.DETALLE_TRAMITE
                        Join s In ctx.SALTOS
                        On dt.IDSALTO Equals s.IDSALTO
                        Where dt.IDUSUARIO = SesionActiva.IdUsuario And dt.FECHA_ENTREGA Is Nothing And s.DECISION = 1 And dt.DESTINO Is Nothing
                        Order By dt.ID_DETALLE_TRAMITE
                        Select dt.ID_DETALLE_TRAMITE, s.IDSALTO, dt.TRAMITES.CODIGOTRAMITE, dt.TRAMITES.GESTIONES.NOMBRE).ToList()

        grid.Rows.Clear()

        For Each tramite In tramites
            grid.Rows.Add(tramite.ID_DETALLE_TRAMITE, tramite.IDSALTO, tramite.CODIGOTRAMITE, tramite.NOMBRE)
        Next

        grid.Columns(0).Visible = False
        grid.Columns(1).Visible = False
    End Sub

    Shared Sub DatosDecisionSalto(ByVal ids As Integer, ByVal lbl As Label, ByVal rdoV As RadioButton, ByVal rdoF As RadioButton)
        Dim info = (From s In ctx.SALTOS Where s.IDSALTO = ids Select s).SingleOrDefault
        lbl.Text = info.DESCRIPCION_DECISION
        rdoV.Tag = info.IDSALTOV
        rdoF.Tag = info.IDSALTOF
    End Sub

    Shared Sub ActualizarDetalleTramite(ByVal iddetalle As Integer, ByVal iddecision As Integer)
        Dim detalle = (From d In ctx.DETALLE_TRAMITE Where d.ID_DETALLE_TRAMITE = iddetalle Select d).FirstOrDefault

        With detalle
            .DESTINO = iddecision
        End With

        ctx.SaveChanges()
    End Sub

    Shared Sub ErrorTramite(ByVal iddt As Integer, ByVal ide As Integer)
        Dim tramite As TRAMITES = (From t In ctx.TRAMITES
                                  From dt In t.DETALLE_TRAMITE
                                  Where dt.ID_DETALLE_TRAMITE = iddt
                                  Select t).FirstOrDefault
        Dim err As ERRORES_GESTIONES = (From e In ctx.ERRORES_GESTIONES Where e.IDERROR = ide Select e).FirstOrDefault

        tramite.ERRORES_GESTIONES.Add(err)
        ctx.SaveChanges()

    End Sub

#End Region

#Region "Tramites"
    Shared Function BuscarResponsable(ByVal identidad As String, _
                                 ByVal txtPN As TextBox, _
                                 ByVal txtSN As TextBox, _
                                 ByVal txtPA As TextBox, _
                                 ByVal txtSA As TextBox, _
                                 ByVal txtT As MaskedTextBox, _
                                 ByVal txtC As MaskedTextBox, _
                                 ByVal txtEmail As TextBox, _
                                 ByVal lbl As Label) As Integer

        ' 1- Si existe localmente (Para hacer UPDATE)
        ' 2- No existe y vienen los datos del RNP (INSERT)
        ' 0- No existe en local ni en DB de RNP (Mostrar mensaje)

        Dim conteo As Integer = (From r In ctx.RESPONSABLE.ToList
                                Where r.NUMERO_IDENTIDAD = identidad
                                Select r).Count

        If conteo = 1 Then
            Dim respon = (From r In ctx.RESPONSABLE
                          Join i In ctx.IDENTIFICACION On r.NUMERO_IDENTIDAD Equals i.IDENTIDAD
                               Where r.NUMERO_IDENTIDAD = identidad
                               Select i.PRIMER_NOMBRE, i.SEGUNDO_NOMBRE, i.PRIMER_APELLIDO, _
                               i.SEGUNDO_APELLIDO, r.TELEFONO, r.CELULAR, r.CORREO).SingleOrDefault

            txtPN.Text = respon.PRIMER_NOMBRE
            txtSN.Text = respon.SEGUNDO_NOMBRE
            txtPA.Text = respon.PRIMER_APELLIDO
            txtSA.Text = respon.SEGUNDO_APELLIDO
            txtT.Text = respon.TELEFONO
            txtC.Text = respon.CELULAR
            txtEmail.Text = respon.CORREO

            Return 1
        Else
            Dim CuentaID As Integer = (From i In ctx.IDENTIFICACION
                                      Where i.IDENTIDAD = identidad
                                      Select i).Count
            If CuentaID = 1 Then
                Dim respon = (From i In ctx.IDENTIFICACION
                               Where i.IDENTIDAD = identidad
                               Select i.PRIMER_NOMBRE, i.SEGUNDO_NOMBRE, i.PRIMER_APELLIDO, i.SEGUNDO_APELLIDO).SingleOrDefault

                txtPN.Text = respon.PRIMER_NOMBRE
                txtSN.Text = respon.SEGUNDO_NOMBRE
                txtPA.Text = respon.PRIMER_APELLIDO
                txtSA.Text = respon.SEGUNDO_APELLIDO
                Return 2
                Exit Function
            End If
            'Buscar en las BD del registro
            lbl.Visible = True

            Return 0
        End If
    End Function

    Public Shared Function NuevoResponsable(ByVal res As RESPONSABLE)
        Try
            ctx.RESPONSABLE.AddObject(res)
            ctx.SaveChanges()
            Return res.IDRESPONSABLE 'Después de SaveChanges(), EntityFramework carga el objeto 'res' con los datos y así retornamos el ID recien agregado
        Catch ex As UpdateException
            Return ex.Message
        End Try
    End Function


    Shared Function ActualizarResponsable(ByVal identidad As String, ByVal tel As String, ByVal cel As String, ByVal correo As String) As Integer
        Dim r As RESPONSABLE = (From re In ctx.RESPONSABLE
                                   Where re.NUMERO_IDENTIDAD = identidad
                                   Select re).SingleOrDefault
        r.TELEFONO = tel
        r.CELULAR = cel
        r.CORREO = correo

        ctx.SaveChanges()

        Return r.IDRESPONSABLE
    End Function


    Shared Function ObtenerRequisitos(ByVal idGestion As Integer) As List(Of REQUISITOS)
        Return (From req In ctx.REQUISITOS Where req.IDGESTION = idGestion Order By req.IDREQUISITO Select req).ToList()
    End Function

    Shared Sub AgregarRequisito(ByVal req As RECEPCION_REQUISITOS)
        Try
            ctx.RECEPCION_REQUISITOS.AddObject(req)
            ctx.SaveChanges()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Shared Sub ListadoGestiones(ByVal grid As DataGridView, Optional ByVal buscar As String = "")

        If buscar = "" Then
            Dim gestiones = (From o In ctx.DETALLE_SUCURSAL_OFICINA
                                    Join g In ctx.DETALLE_OFICINA_GESTIONES
                                    On o.IDOFICINA Equals g.IDOFICINA
                                    Where o.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina
                                    Select g.GESTIONES.IDGESTION, g.GESTIONES.NOMBRE).ToList

            grid.DataSource = gestiones
            grid.Columns(0).Visible = False
        Else
            Dim gestiones = (From o In ctx.DETALLE_SUCURSAL_OFICINA
                                    Join g In ctx.DETALLE_OFICINA_GESTIONES
                                    On o.IDOFICINA Equals g.IDOFICINA
                                    Where o.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina AndAlso g.GESTIONES.NOMBRE.StartsWith(buscar)
                                    Select g.GESTIONES.IDGESTION, g.GESTIONES.NOMBRE).ToList

            grid.DataSource = gestiones
            grid.Columns(0).Visible = False
        End If
    End Sub

    Public Shared Sub TramitesEntregar(ByVal grid As DataGridView, Optional ByVal busqueda As String = "")
        'Lista de los saltos recibidos y son ultimo salto
        Dim tramiteEntregar
        If busqueda = "" Then
            tramiteEntregar = (From t In ctx.DETALLE_TRAMITE
                               Join s In ctx.SALTOS On t.IDSALTO Equals s.IDSALTO
                               Where t.TRAMITES.ACTIVO = 1 AndAlso t.IDUSUARIO = SesionActiva.IdUsuario AndAlso s.ULTIMOSALTO = 1
                               Order By t.TRAMITES.CODIGOTRAMITE
                               Select t.ID_DETALLE_TRAMITE, t.TRAMITES.CODIGOTRAMITE, t.TRAMITES.GESTIONES.NOMBRE, t.TRAMITES.RESPONSABLE.NUMERO_IDENTIDAD).ToList()
        Else
            tramiteEntregar = (From t In ctx.DETALLE_TRAMITE
                               Join s In ctx.SALTOS On t.IDSALTO Equals s.IDSALTO
                               Where t.TRAMITES.ACTIVO = 1 AndAlso t.IDUSUARIO = SesionActiva.IdUsuario AndAlso s.ULTIMOSALTO = 1 AndAlso (t.TRAMITES.CODIGOTRAMITE.StartsWith(busqueda) OrElse t.TRAMITES.RESPONSABLE.NUMERO_IDENTIDAD.StartsWith(busqueda))
                               Order By t.TRAMITES.CODIGOTRAMITE
                               Select t.ID_DETALLE_TRAMITE, t.TRAMITES.CODIGOTRAMITE, t.TRAMITES.GESTIONES.NOMBRE, t.TRAMITES.RESPONSABLE.NUMERO_IDENTIDAD).ToList()
        End If

        grid.Rows.Clear()
        For Each tramite In tramiteEntregar
            grid.Rows.Add(tramite.IDTRAMITE, tramite.CODIGOTRAMITE, tramite.NOMBRE, tramite.NUMERO_IDENTIDAD,
                          "Entregar Trámite")
        Next
        'grid.DataSource = saltoEntregar
    End Sub

    Shared Sub historial(ByVal codigo As String, ByVal lblcodigo As Label, ByVal lbltramite As Label, ByVal lblActivo As Label, ByVal grid As DataGridView)
        Dim tramite = (From t In ctx.TRAMITES
                      Where t.CODIGOTRAMITE = codigo
                      Select t.CODIGOTRAMITE, t.GESTIONES.NOMBRE, t.ACTIVO).FirstOrDefault

        Dim dtt = (From dt In ctx.DETALLE_TRAMITE
                 Join s In ctx.SALTOS On dt.IDSALTO Equals s.IDSALTO
                 Join us In ctx.USUARIOS On us.IDUSUARIO Equals dt.IDUSUARIO
                 Where dt.TRAMITES.CODIGOTRAMITE = codigo
                 Order By dt.ID_DETALLE_TRAMITE
                 Select NPaso = s.NUMERO_SALTO, Descripcion = s.DESCRIPCION_SALTO, Fecha = dt.FECHA_RECEPCION, Responsable = us.NOMBRE + " " + us.APELLIDOS).ToList()

        If tramite Is Nothing Then
            MsgBox("Tramite ingresado no existe")
        Else
            lblcodigo.Text = tramite.CODIGOTRAMITE
            lbltramite.Text = tramite.NOMBRE
            If tramite.ACTIVO = 1 Then
                lblActivo.Text = "Trámite en proceso"
                lblActivo.ForeColor = Color.LightGreen
            Else
                lblActivo.Text = "Trámite finalizado"
                lblActivo.ForeColor = Color.GreenYellow
            End If
            grid.DataSource = dtt
        End If

    End Sub

#End Region

#Region "Disponibilidad"

    Public Shared Sub Disponibilidad(ByVal codtramite As String, ByVal grid As DataGridView, ByRef lbl As Label)
        Dim tramite As Integer = (From t In ctx.TRAMITES Where t.CODIGOTRAMITE = codtramite Select t).Count()

        If tramite > 0 Then
            Dim destinos = (From dt In ctx.DETALLE_TRAMITE
                           Where dt.TRAMITES.CODIGOTRAMITE = codtramite And dt.FECHA_ENTREGA Is Nothing
                           Order By dt.ID_DETALLE_TRAMITE Descending
                           Select dt.DESTINO).SingleOrDefault
            If Not destinos Is Nothing Then
                Dim PasoTramite As Integer = (From dt In ctx.DETALLE_TRAMITE
                                               Where dt.TRAMITES.CODIGOTRAMITE = codtramite And dt.FECHA_ENTREGA Is Nothing
                                               Order By dt.ID_DETALLE_TRAMITE Descending
                                               Select dt.DESTINO).SingleOrDefault()

                Dim Usuarios As List(Of USUARIOS) = New List(Of USUARIOS)

                Usuarios = (From u In ctx.USUARIOS
                           Join s In ctx.SALTOS On u.IDPUESTO Equals s.IDPUESTO
                           Where s.IDSALTO = PasoTramite
                           Select u).ToList()

                grid.Rows.Clear()
                For Each us In Usuarios
                    Dim c = (From dt In ctx.DETALLE_TRAMITE Where dt.IDUSUARIO = us.IDUSUARIO And dt.FECHA_ENTREGA Is Nothing AndAlso Not dt.DESTINO = 0 Select dt).Count
                    grid.Rows.Add(us.IDUSUARIO.ToString, us.NOMBRE, us.APELLIDOS, c.ToString)
                Next

                If grid.Rows.Count() = 0 Then
                    lbl.Text = ""
                End If
            ElseIf destinos = 0 Then
                lbl.Text = "Está listo para que el ciudadno lo retire"
            Else
                lbl.Text = "Debe terminar el proceso"
            End If
        Else
            lbl.Text = "Trámite no existe"
        End If


    End Sub

#End Region

#Region "Error Tramite"
    Public Shared Sub CargarError(ByVal cbo As ComboBox, ByVal salto As Integer)
        Dim err = (From e In ctx.ERRORES_GESTIONES
                   From s In e.GESTIONES.SALTOS
                   Where s.IDSALTO = salto And e.IDGESTION = s.IDGESTION
                   Order By e.DESCRIPCION
                   Select e).ToList()

        cbo.DataSource = err
        cbo.DisplayMember = "DESCRIPCION"
        cbo.ValueMember = "IDERROR"
        cbo.SelectedValue = -1
    End Sub

    Public Shared Function Gestion(ByVal ids As Integer) As GESTIONES
        Dim ges = (From g In ctx.GESTIONES
                   From s In g.SALTOS
                   Where s.IDSALTO = ids And g.IDGESTION = s.IDGESTION
                   Select g).FirstOrDefault
        Return ges
    End Function

    Public Shared Sub AgregarError(ByVal codigo As String, ByVal descripcion As String, ByVal idSalto As Integer)
        Dim gestion As Integer = (From s In ctx.SALTOS Where s.IDSALTO = idSalto Select s.IDGESTION).FirstOrDefault

        Dim err As New ERRORES_GESTIONES With _
            {
                .CODIGOERROR = codigo,
                .DESCRIPCION = descripcion,
                .IDGESTION = gestion
            }
        ctx.ERRORES_GESTIONES.AddObject(err)
        ctx.SaveChanges()

    End Sub

#End Region



End Class
