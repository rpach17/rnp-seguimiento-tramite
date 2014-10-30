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
                        .Municipio = u.DETALLE_SUCURSAL_OFICINA.SUCURSALES.MUNICIPIOS.NOMBRE_MPIO
                        .Depto = u.DETALLE_SUCURSAL_OFICINA.SUCURSALES.MUNICIPIOS.DEPARTAMENTOS.NOMBRE_DEPTO
                        .VinculadoCon = u.VINCULAR_CON
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

    Public Shared Function PrimerPaso(ByVal idu As Integer) As Boolean
        Dim primerSalto As Integer = (From dus In ctx.DETALLE_USUARIO_SALTOS
                                      Where dus.IDUSUARIO = idu AndAlso dus.SALTOS.NUMERO_SALTO = 1).Count
        If primerSalto >= 1 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Recepcion de tramites"
    Public Shared Sub TramitesRecibir(ByVal grid As DataGridView)
        'Se verifica si usuario esta vinculado con alguien
        Dim tramites
        If SesionActiva.VinculadoCon IsNot Nothing Then
            'Se buscan los tramites que se pueden recibir con su usuario y el vinculado
            tramites = (From dt In ctx.DETALLE_SEGUIMIENTO
                           Join u In ctx.USUARIOS On dt.IDUSUARIO Equals u.IDUSUARIO
                           Join s In ctx.SALTOS On dt.IDSALTO Equals s.IDSALTO
                           Where dt.TRAMITES.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina AndAlso dt.TRAMITES.ACTIVO = 1 And dt.FECHA_ENTREGA Is Nothing AndAlso (dt.IDUSUARIO_DESTINO = SesionActiva.IdUsuario Or dt.IDUSUARIO_DESTINO = SesionActiva.VinculadoCon)
                           Order By dt.TRAMITES.CODIGOTRAMITE
                           Select dt.TRAMITES.CODIGOTRAMITE, Gestion = dt.TRAMITES.GESTIONES.NOMBRE, u.NOMBRE, u.APELLIDOS, s.NUMERO_SALTO).ToList()
        Else
            'Se buscan los tramites que se pueden recibir
            tramites = (From dt In ctx.DETALLE_SEGUIMIENTO
                           Join u In ctx.USUARIOS On dt.IDUSUARIO Equals u.IDUSUARIO
                           Join s In ctx.SALTOS On dt.IDSALTO Equals s.IDSALTO
                           Where dt.TRAMITES.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina AndAlso dt.TRAMITES.ACTIVO = 1 And dt.FECHA_ENTREGA Is Nothing AndAlso dt.IDUSUARIO_DESTINO = SesionActiva.IdUsuario
                           Order By dt.TRAMITES.CODIGOTRAMITE
                           Select dt.TRAMITES.CODIGOTRAMITE, Gestion = dt.TRAMITES.GESTIONES.NOMBRE, u.NOMBRE, u.APELLIDOS, s.NUMERO_SALTO).ToList()

        End If

        ' Lista de los saltos que puede atender
        'Dim saltosAtender = (From s In ctx.SALTOS
        '                     Where s.IDPUESTO = SesionActiva.IdPuesto And s.NUMERO_SALTO > 1
        '                     Select s.IDSALTO).ToList


        's.DECISION = 0 OrElse (s.DECISION = 1 And Not dt.DESTINO Is Nothing AndAlso saltosAtender.Contains(dt.DESTINO)))

        grid.Rows.Clear()
        For Each tramite In tramites
            grid.Rows.Add(tramite.CODIGOTRAMITE, tramite.Gestion, String.Format("{0} {1}", tramite.NOMBRE, tramite.APELLIDOS), tramite.NUMERO_SALTO)
        Next
        'grid.DataSource = tramites
    End Sub

    Shared Sub TramitesAProcesar(ByVal grid As DataGridView)

        Dim tramites = (From dt In ctx.DETALLE_SEGUIMIENTO
                        Join s In ctx.SALTOS On dt.IDSALTO Equals s.IDSALTO
                        Join f In ctx.FORMULARIOS On s.IDSALTO Equals f.IDSALTO
                        Where dt.IDUSUARIO = SesionActiva.IdUsuario And dt.FECHA_ENTREGA Is Nothing And dt.IDUSUARIO_DESTINO Is Nothing AndAlso f.ACTIVO = 1 AndAlso s.ULTIMOSALTO = 0
                        Order By dt.IDDETALLE_SEGUIMIENTO
                        Select dt.IDDETALLE_SEGUIMIENTO, s.IDGRUPO_SALTOS, s.IDSALTO, s.NUMERO_SALTO, s.DECISION, f.IDFORMULARIO, dt.TRAMITES.CODIGOTRAMITE, dt.TRAMITES.GESTIONES.NOMBRE).ToList()

        grid.Rows.Clear()

        For Each tramite In tramites
            grid.Rows.Add(tramite.IDDETALLE_SEGUIMIENTO, tramite.IDGRUPO_SALTOS, tramite.IDSALTO, tramite.NUMERO_SALTO, tramite.DECISION, tramite.IDFORMULARIO, tramite.CODIGOTRAMITE, tramite.NOMBRE)
        Next

        'grid.Columns(0).Visible = False
        'grid.Columns(1).Visible = False
        'grid.Columns(2).Visible = False
        'grid.Columns(3).Visible = False
    End Sub

    Shared Sub DatosDecisionSalto(ByVal ids As Integer, ByVal lbl As Label, ByVal rdoV As RadioButton, ByVal rdoF As RadioButton)
        Dim info = (From s In ctx.SALTOS Where s.IDSALTO = ids Select s).SingleOrDefault
        lbl.Text = info.DESCRIPCION_DECISION
        rdoV.Tag = info.IDSALTOV
        rdoF.Tag = info.IDSALTOF
    End Sub

    Shared Sub ActualizarDetalleTramite(ByVal iddetalle As Integer, ByVal iddecision As Integer, ByVal idUserDestino As Integer)
        Dim detalle = (From d In ctx.DETALLE_SEGUIMIENTO Where d.IDDETALLE_SEGUIMIENTO = iddetalle Select d).FirstOrDefault

        With detalle
            .DESTINO = iddecision
            .IDUSUARIO_DESTINO = idUserDestino
        End With
        ctx.SaveChanges()
    End Sub

    Shared Sub ErrorTramite(ByVal iddt As Integer, ByVal ide As Integer)
        Dim tramite As TRAMITES = (From t In ctx.TRAMITES
                                  From dt In t.DETALLE_SEGUIMIENTO
                                  Where dt.IDDETALLE_SEGUIMIENTO = iddt
                                  Select t).FirstOrDefault
        Dim err As ERRORES_GESTIONES = (From e In ctx.ERRORES_GESTIONES Where e.IDERROR = ide Select e).FirstOrDefault

        tramite.ERRORES_GESTIONES.Add(err)
        ctx.SaveChanges()
    End Sub

    Shared Sub CargarUsuariosDestino(cbo As ComboBox, idg As Integer)
        Dim usuarios = (From u In ctx.DETALLE_USUARIO_SALTOS
                        Join s In ctx.SALTOS On u.IDSALTO Equals s.IDSALTO
                        Where s.GRUPO_SALTOS.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina AndAlso s.GRUPO_SALTOS.IDGESTION = idg AndAlso s.GRUPO_SALTOS.ACTIVO = 1 AndAlso s.NUMERO_SALTO = 2
                        Order By u.PRIORIDAD Descending
                        Select u.IDUSUARIO, nombre = u.USUARIOS.NOMBRE + " " + u.USUARIOS.APELLIDOS)

        cbo.DataSource = usuarios
        cbo.DisplayMember = "nombre"
        cbo.ValueMember = "IDUSUARIO"
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

        'Dim sql = ctx.

        If conteo = 1 Then
            Dim respon = (From r In ctx.RESPONSABLE
                          Join i In ctx.IDENTIFICACION On r.NUMERO_IDENTIDAD Equals i.IDENTIDAD
                               Where r.NUMERO_IDENTIDAD = identidad
                               Select i.PRIMER_NOMBRE, i.SEGUNDO_NOMBRE, i.PRIMER_APELLIDO, _
                               i.SEGUNDO_APELLIDO, r.TELEFONO, r.CELULAR, r.CORREO).SingleOrDefault

            If respon IsNot Nothing Then
                txtPN.Text = respon.PRIMER_NOMBRE
                txtSN.Text = respon.SEGUNDO_NOMBRE
                txtPA.Text = respon.PRIMER_APELLIDO
                txtSA.Text = respon.SEGUNDO_APELLIDO
                txtT.Text = respon.TELEFONO
                txtC.Text = respon.CELULAR
                txtEmail.Text = respon.CORREO
            End If

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
            lbl.Text = "Numero de identidad no encontrado"
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
            MsgBox(ex.InnerException.Message)
        End Try
    End Sub

    Shared Sub ListadoGestiones(ByVal grid As DataGridView, Optional ByVal buscar As String = "", Optional ByVal idu As Integer = 0)

        If buscar = "" And idu = 0 Then
            Dim gestiones = (From o In ctx.DETALLE_SUCURSAL_OFICINA
                                    Join g In ctx.DETALLE_OFICINA_GESTIONES
                                    On o.IDOFICINA Equals g.IDOFICINA
                                    Where o.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina
                                    Select g.GESTIONES.IDGESTION, g.GESTIONES.NOMBRE).ToList

            grid.DataSource = gestiones
            grid.Columns(0).Visible = False
        ElseIf buscar = "" And idu <> 0 Then
            Dim gestiones = (From gs In ctx.GRUPO_SALTOS
                             From dus In ctx.DETALLE_USUARIO_SALTOS
                             Where gs.IDGRUPO_SALTOS = dus.SALTOS.IDGRUPO_SALTOS AndAlso gs.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina AndAlso dus.IDUSUARIO = idu
                             Select gs.GESTIONES.IDGESTION, gs.GESTIONES.NOMBRE).ToList

            grid.DataSource = gestiones
            grid.Columns(0).Visible = False
        Else
            'Dim gestiones = (From o In ctx.DETALLE_SUCURSAL_OFICINA
            '                        Join g In ctx.DETALLE_OFICINA_GESTIONES
            '                        On o.IDOFICINA Equals g.IDOFICINA
            '                        Where o.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina AndAlso g.GESTIONES.NOMBRE.StartsWith(buscar)
            '                        Select g.GESTIONES.IDGESTION, g.GESTIONES.NOMBRE).ToList

            Dim gestiones = (From gs In ctx.GRUPO_SALTOS
                             From dus In ctx.DETALLE_USUARIO_SALTOS
                             Where gs.IDGRUPO_SALTOS = dus.SALTOS.IDGRUPO_SALTOS AndAlso gs.IDDETALLE_SUCURSAL_OFICINA = SesionActiva.IdSucursalOficina AndAlso dus.IDUSUARIO = idu AndAlso gs.GESTIONES.NOMBRE.StartsWith(buscar)
                             Select gs.GESTIONES.IDGESTION, gs.GESTIONES.NOMBRE).ToList

            grid.DataSource = gestiones
            grid.Columns(0).Visible = False
        End If
    End Sub

    Public Shared Sub TramitesEntregar(ByVal grid As DataGridView, Optional ByVal busqueda As String = "")
        'Lista de los saltos recibidos y son ultimo salto
        Dim tramiteEntregar
        If busqueda = "" Then
            tramiteEntregar = (From t In ctx.DETALLE_SEGUIMIENTO
                               Join s In ctx.SALTOS On t.IDSALTO Equals s.IDSALTO
                               Join f In ctx.FORMULARIOS On s.IDSALTO Equals f.IDSALTO
                               Where t.TRAMITES.ACTIVO = 1 AndAlso t.IDUSUARIO = SesionActiva.IdUsuario AndAlso s.ULTIMOSALTO = 1
                               Order By t.TRAMITES.CODIGOTRAMITE
                               Select t.TRAMITES.IDTRAMITE, t.IDDETALLE_SEGUIMIENTO, s.IDSALTO, f.IDFORMULARIO, t.TRAMITES.CODIGOTRAMITE, t.TRAMITES.GESTIONES.NOMBRE, t.TRAMITES.RESPONSABLE.NUMERO_IDENTIDAD).ToList()
        Else
            tramiteEntregar = (From t In ctx.DETALLE_SEGUIMIENTO
                               Join s In ctx.SALTOS On t.IDSALTO Equals s.IDSALTO
                               Join f In ctx.FORMULARIOS On s.IDSALTO Equals f.IDSALTO
                               Where t.TRAMITES.ACTIVO = 1 AndAlso t.IDUSUARIO = SesionActiva.IdUsuario AndAlso s.ULTIMOSALTO = 1 AndAlso (t.TRAMITES.CODIGOTRAMITE.StartsWith(busqueda) OrElse t.TRAMITES.RESPONSABLE.NUMERO_IDENTIDAD.StartsWith(busqueda))
                               Order By t.TRAMITES.CODIGOTRAMITE
                               Select t.TRAMITES.IDTRAMITE, t.IDDETALLE_SEGUIMIENTO, s.IDSALTO, f.IDFORMULARIO, t.TRAMITES.CODIGOTRAMITE, t.TRAMITES.GESTIONES.NOMBRE, t.TRAMITES.RESPONSABLE.NUMERO_IDENTIDAD).ToList()
        End If

        grid.Rows.Clear()
        For Each tramite In tramiteEntregar
            grid.Rows.Add(tramite.IDTRAMITE, tramite.IDDETALLE_SEGUIMIENTO, tramite.IDSALTO, tramite.IDFORMULARIO, tramite.CODIGOTRAMITE, tramite.NOMBRE, tramite.NUMERO_IDENTIDAD,
                          "Entregar Trámite")
        Next
        'grid.DataSource = saltoEntregar
    End Sub

    Shared Sub historial(ByVal codigo As String, ByVal lblcodigo As Label, ByVal lbltramite As Label, ByVal lblActivo As Label, ByVal grid As DataGridView)
        Dim tramite = (From t In ctx.TRAMITES
                      Where t.CODIGOTRAMITE = codigo
                      Select t.CODIGOTRAMITE, t.GESTIONES.NOMBRE, t.ACTIVO).FirstOrDefault

        Dim dtt = (From dt In ctx.DETALLE_SEGUIMIENTO
                 Join s In ctx.SALTOS On dt.IDSALTO Equals s.IDSALTO
                 Join us In ctx.USUARIOS On us.IDUSUARIO Equals dt.IDUSUARIO
                 Where dt.TRAMITES.CODIGOTRAMITE = codigo
                 Order By dt.IDDETALLE_SEGUIMIENTO
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
            Dim destinos = (From dt In ctx.DETALLE_SEGUIMIENTO
                           Where dt.TRAMITES.CODIGOTRAMITE = codtramite And dt.FECHA_ENTREGA Is Nothing
                           Order By dt.IDDETALLE_SEGUIMIENTO Descending
                           Select dt.DESTINO).SingleOrDefault
            If Not destinos Is Nothing Then
                Dim PasoTramite As Integer = (From dt In ctx.DETALLE_SEGUIMIENTO
                                               Where dt.TRAMITES.CODIGOTRAMITE = codtramite And dt.FECHA_ENTREGA Is Nothing
                                               Order By dt.IDDETALLE_SEGUIMIENTO Descending
                                               Select dt.DESTINO).SingleOrDefault()

                Dim Usuarios As List(Of USUARIOS) = New List(Of USUARIOS)

                Usuarios = (From u In ctx.USUARIOS
                           Join s In ctx.SALTOS On u.IDPUESTO Equals s.IDPUESTO
                           Where s.IDSALTO = PasoTramite
                           Select u).ToList()

                grid.Rows.Clear()
                For Each us In Usuarios
                    Dim c = (From dt In ctx.DETALLE_SEGUIMIENTO Where dt.IDUSUARIO = us.IDUSUARIO And dt.FECHA_ENTREGA Is Nothing AndAlso Not dt.DESTINO = 0 Select dt).Count
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
                   From gs In e.GESTIONES.GRUPO_SALTOS
                   Join s In ctx.SALTOS On gs.IDGRUPO_SALTOS Equals s.IDGRUPO_SALTOS
                   Where s.IDSALTO = salto And e.IDGESTION = gs.IDGESTION
                   Order By e.DESCRIPCION
                   Select e).ToList()

        cbo.DataSource = err
        cbo.DisplayMember = "DESCRIPCION"
        cbo.ValueMember = "IDERROR"
        cbo.SelectedValue = -1
    End Sub

    Public Shared Function Gestion(ByVal ids As Integer) As GESTIONES
        Dim ges = (From g In ctx.GESTIONES
                   From gs In g.GRUPO_SALTOS
                   Join s In ctx.SALTOS On gs.IDGRUPO_SALTOS Equals s.IDGRUPO_SALTOS
                   Where s.IDSALTO = ids And g.IDGESTION = gs.IDGESTION
                   Select g).FirstOrDefault
        Return ges
    End Function

    Public Shared Sub AgregarError(ByVal codigo As String, ByVal descripcion As String, ByVal idSalto As Integer)
        Dim gestion As Integer = (From s In ctx.SALTOS Where s.IDSALTO = idSalto Select s.GRUPO_SALTOS.IDGESTION).FirstOrDefault

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

#Region "Procesar"
    Shared Sub CargarUsuariosDestinoSalto(cbo As ComboBox, ids As Integer)
        Dim usuarios = (From u In ctx.DETALLE_USUARIO_SALTOS.ToList
                        Join s In ctx.SALTOS On u.IDSALTO Equals s.IDSALTO
                        Where s.IDSALTO = ids
                        Order By u.PRIORIDAD Descending
                        Select u.IDUSUARIO, NOMBRECOMPLETO = u.USUARIOS.NOMBRE & " " & u.USUARIOS.APELLIDOS).ToList

        'cbo.DataSource = Nothing
        cbo.DataSource = usuarios
        cbo.ValueMember = "IDUSUARIO"
        cbo.DisplayMember = "NOMBRECOMPLETO"

    End Sub

    Shared Function ObtenerSiguienteSalto(ByVal idGrupoS As Integer, ByVal numeroSalto As Integer) As Integer
        Dim siguiente As Integer = (From s In ctx.SALTOS
                        Where s.IDGRUPO_SALTOS = idGrupoS AndAlso s.NUMERO_SALTO = numeroSalto
                        Select s.IDSALTO).FirstOrDefault

        Return siguiente
    End Function

    Shared Function SaltoDescargable(ByVal idSalto As Integer) As Boolean
        Dim cuenta As Integer = (From s In ctx.SALTOS
                                 Join f In ctx.FORMULARIOS On s.IDSALTO Equals f.IDSALTO
                                 Join c In ctx.CAMPOS_FORM On f.IDFORMULARIO Equals c.FORMULARIOS.IDFORMULARIO
                                 Where s.IDSALTO = idSalto And f.ACTIVO = 1 And c.TIPOS_CAMPOS.TIPO_CAMPO = "descargable"
                                 Select s).Count()
        If cuenta > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Shared Function DescargarArchivo(ByVal idSalto As Integer)

        Dim idA = (From s In ctx.SALTOS
                From f In s.FORMULARIOS
                From a In ctx.ARCHIVOS
                Where s.IDSALTO = idSalto AndAlso f.IDFORMULARIO = a.CAMPOS_FORM.IDFORMULARIO
                Select a).SingleOrDefault

        Return idA
    End Function

#End Region

#Region "URL"
    Public Shared Function ObtenerURL(id As Integer) As String
        Dim url = (From u In ctx.FORM_URL
                   Where u.IDURL = id
                   Select u.DIRECCION).SingleOrDefault

        Return url.ToString
    End Function
#End Region

End Class
