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

                For Each us In Usuarios
                    Dim c = (From dt In ctx.DETALLE_TRAMITE Where dt.IDUSUARIO = us.IDUSUARIO And dt.FECHA_ENTREGA Is Nothing Select dt).Count
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
End Class
