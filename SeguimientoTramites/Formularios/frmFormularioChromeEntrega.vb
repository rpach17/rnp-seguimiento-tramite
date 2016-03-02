Public Class frmFormularioChromeEntrega

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

    Dim esEntrega As Boolean
    Public Property EsEntrega1 As Boolean
        Get
            Return esEntrega
        End Get
        Set(ByVal value As Boolean)
            esEntrega = value
        End Set
    End Property

    Private Sub frmFormulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim url As String = String.Format("{0}?idf={1}&idu={2}&idds={3}&depto={4}&munic={5}&suc={6}&ofi={7}&entrega={8}", My.Settings.URLForm, idForm, 0, idDetalleSeguimiento, Replace(SesionActiva.Depto.ToLower, " ", "_"), Replace(SesionActiva.Municipio.ToLower, " ", "_"), Replace(SesionActiva.Sucursal.ToLower, " ", "_"), Replace(SesionActiva.Oficina.ToLower, " ", "_"), esEntrega)
        WebControl1.Source = New Uri(url)
        TextBox1.Text = url
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(13) Then
            WebControl1.Source = New Uri(TextBox1.Text)
        End If
    End Sub
End Class