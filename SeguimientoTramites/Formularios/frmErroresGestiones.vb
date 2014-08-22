Public Class frmErroresGestiones
    Dim ids As Integer

    Public Property Ids1() As Integer
        Get
            Return ids
        End Get
        Set(ByVal value As Integer)
            ids = Value
        End Set
    End Property

    Private Sub frmErroresGestiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim g As GESTIONES = EntityTablas.Gestion(ids)
        lblDescripcion.Text = String.Format("{0}", g.NOMBRE)
    End Sub

    Private Sub btnDecidir_Click(sender As Object, e As EventArgs) Handles btnDecidir.Click
        EntityTablas.AgregarError(txtCodigo.Text, txtDescripcion.Text, ids)
        Close()
    End Sub
End Class