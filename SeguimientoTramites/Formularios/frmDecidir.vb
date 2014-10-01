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
        lblError.Visible = False
    End Sub

    Private Sub btnDecidir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecidir.Click
        If rdoV.Checked Then
            EntityTablas.ActualizarDetalleTramite(iddt, rdoV.Tag, cboUserDestino.SelectedValue)
        End If

        If rdoF.Checked Then
            If cboError.SelectedValue > 0 Then
                EntityTablas.ActualizarDetalleTramite(iddt, rdoF.Tag, cboUserDestino.SelectedValue)
                EntityTablas.ErrorTramite(iddt, cboError.SelectedValue)
            Else
                MsgBox("Debe seleccionar un error")
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub rdoF_CheckedChanged(sender As Object, e As EventArgs) Handles rdoF.CheckedChanged, rdoV.CheckedChanged
        If rdoV.Checked Then
            lblError.Visible = False
            cboError.Enabled = False
            btnAgregarError.Enabled = False
            cboError.DataSource = Nothing
            EntityTablas.CargarUsuariosDestinoSalto(cboUserDestino, rdoV.Tag)
        End If

        If rdoF.Checked Then
            lblError.Visible = True
            cboError.Enabled = True
            btnAgregarError.Enabled = True
            EntityTablas.CargarError(cboError, ids)
            EntityTablas.CargarUsuariosDestinoSalto(cboUserDestino, rdoF.Tag)
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregarError.Click
        With frmErroresGestiones
            .Ids1 = ids
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        EntityTablas.CargarError(cboError, ids)
    End Sub
End Class