Public Class frmFormulario
    Dim idSalto As Integer
    Public Property IdSalto1 As Integer
        Get
            Return idSalto
        End Get
        Set(ByVal value As Integer)
            idSalto = value
        End Set
    End Property

    Dim idForm As Integer
    Public Property IdForm1 As Integer
        Get
            Return idForm
        End Get
        Set(ByVal value As Integer)
            idForm = value
        End Set
    End Property

    Dim idDetalleSeguimiento As Integer
    Public Property IdDetalleSeguimiento1 As Integer
        Get
            Return idDetalleSeguimiento
        End Get
        Set(ByVal value As Integer)
            idDetalleSeguimiento = value
        End Set
    End Property

    Private Sub frmFormulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EntityTablas.CargarUsuariosDestinoSalto(cboUsuarioDestino, idSalto)
    End Sub

    Private Sub cboUsuarioDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUsuarioDestino.SelectedIndexChanged
        Try
            Dim idUser As Integer = cboUsuarioDestino.SelectedValue
            Dim url As String = String.Format("http://win8virtual/forms/index.php?idf={0}&idu={1}&idds={2}&depto={3}&munic={4}&suc={5}&ofi={6}", idForm, idUser, idDetalleSeguimiento, Replace(SesionActiva.Depto.ToLower, " ", "_"), Replace(SesionActiva.Municipio.ToLower, " ", "_"), Replace(SesionActiva.Sucursal.ToLower, " ", "_"), Replace(SesionActiva.Oficina.ToLower, " ", "_"))
            WebBrowser1.Navigate(url)
            TextBox1.Text = url
        Catch ex As Exception
            ' Cuando EntityTablas.CargarUsuariosDestinoSalto(cboUsuarioDestino, idSalto) aun no ha terminado de cargar...
            ' se lanza una excepción en el evento SelectedIndexChanged ya que el dato obtenido es {id = x, nombre = z} y no se puede...
            ' convertir en Integer. La excepción se lanza dos veces, una para cbo.DataSource y la otra para cbo.DisplayMember
        End Try
        
    End Sub

End Class