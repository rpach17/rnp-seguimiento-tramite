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

    Private Sub frmFormulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EntityTablas.CargarUsuariosDestinoSalto(cboUsuarioDestino, idSalto)
    End Sub

End Class