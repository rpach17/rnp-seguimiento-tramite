Public Class frmListadoGestiones

    Private Sub frmListadoGestiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BottomRightFormLocation(e)
        EntityTablas.ListadoGestiones(dgvGestiones)
    End Sub

    Sub BottomRightFormLocation(ByVal evento As EventArgs)
        Dim src = Screen.FromPoint(Location)
        Location = New Point(src.WorkingArea.Right - Width, src.WorkingArea.Bottom - Height)
        MyBase.OnActivated(evento)
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(13) Then
            EntityTablas.ListadoGestiones(dgvGestiones, txtBuscar.Text)
        End If
    End Sub

    Private Sub dgvGestiones_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGestiones.CellClick
        Dim idGestion As Integer = DameID(dgvGestiones)
        Dim nombreGestion As String = DameID(dgvGestiones, 1)

        With frmTramite
            .IdGestion1 = idGestion
            .Text = nombreGestion
            .CargarRequisitos()
        End With

        Close()
    End Sub
End Class