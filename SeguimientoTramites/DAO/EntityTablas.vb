Public Class EntityTablas
    Shared ctx As New Entidades(My.Settings.CadenaAppcaSeguimiento)

#Region "Login"
    Public Shared Function Login(ByVal user As String, ByVal pass As String) As Boolean
        Dim usu = (From users In ctx.USUARIOS
                   Where users.USUARIO = user AndAlso users.CONTRASENA = pass AndAlso users.ESTADO = 1
                   Select users).ToList()

        If usu.Count = 1 Then
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
        Else
            Return False
        End If
    End Function
#End Region

#Region "Recepcion de tramites"
    Public Shared Sub TramitesRecibir(ByVal grid As DataGridView)
        'saltos que el usuario puede atender
        Dim saltos = (From s In ctx.SALTOS
                     Where s.IDPUESTO = SesionActiva.IdPuesto And s.NUMERO_SALTO > 1
                     Select s.NUMERO_SALTO, s.IDGESTION).ToList
        'Se buscan los ID de los saltos anteriores
        Dim listIdSalto As List(Of Decimal) = New List(Of Decimal)
        Dim numSalto As Integer
        Dim idGest As Integer

        For Each s In saltos
            numSalto = s.NUMERO_SALTO - 1
            idGest = s.IDGESTION
            listIdSalto.Add((From sid In ctx.SALTOS Where sid.NUMERO_SALTO = numSalto And sid.IDGESTION = idGest Select sid.IDSALTO).SingleOrDefault)
        Next

        'Se buscan los tramites que se pueden recibir
        Dim tramites = (From dt In ctx.DETALLE_TRAMITE
                       Join u In ctx.USUARIOS On dt.IDUSUARIO Equals u.IDUSUARIO
                       Join s In ctx.SALTOS On dt.IDSALTO Equals s.IDSALTO
                       Where listIdSalto.Contains(dt.IDSALTO) And dt.TRAMITES.ACTIVO = 1 And dt.FECHA_ENTREGA Is Nothing And (s.DECISION = 0 OrElse (s.DECISION = 1 And Not dt.DECISION Is Nothing))
                       Select dt.TRAMITES.CODIGOTRAMITE, Gestion = dt.TRAMITES.GESTIONES.NOMBRE, u.NOMBRE, u.APELLIDOS, s.NUMERO_SALTO).ToList()


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
                        Where dt.IDUSUARIO = SesionActiva.IdUsuario And dt.FECHA_ENTREGA Is Nothing And s.DECISION = 1 And dt.DECISION Is Nothing
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
            .DECISION = iddecision
        End With

        ctx.SaveChanges()
    End Sub
#End Region
End Class
