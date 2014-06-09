Public Class frmDecidir
    Dim ids As Integer
    Dim iddt As Integer
    Public Property Iddt1() As Integer
        Get
            Return iddt
        End Get
        Set(ByVal value As Integer)
            iddt = Value
        End Set
    End Property
    Public Property Ids1() As Integer
        Get
            Return ids
        End Get
        Set(ByVal value As Integer)
            ids = Value
        End Set
    End Property

    Private Sub frmDecidir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EntityTablas.DatosDecisionSalto(ids, lblDescripcion, rdoV, rdoF)
    End Sub

    Private Sub btnDecidir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecidir.Click
        If rdoV.Checked Then
            EntityTablas.ActualizarDetalleTramite(iddt, rdoV.Tag)
        End If

        If rdoF.Checked Then
            EntityTablas.ActualizarDetalleTramite(iddt, rdoF.Tag)
        End If

        Close()
    End Sub
End Class