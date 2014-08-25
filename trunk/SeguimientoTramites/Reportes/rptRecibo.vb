Public Class rptRecibo
    Public Sub New(nombre As String, id As String, fijo As String, movil As String, correo As String, usuario As String, tramite As String, codigo As String, fechaInicio As String, fechaActual As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim cuerpo As String = String.Format("Recibí de Registro Nacional de las Personas (RNP) el {0} mediante {1} el trámite de {2} con código {3} iniciado el {4}", fechaActual, usuario, tramite, codigo, fechaInicio)
        lblCuerpo.Text = cuerpo

        cellNombre.Text = "Nombre: " & nombre
        cellIdentidad.Text = "No. de identidad: " & id
        cellTelf.Text = "Teléfono fijo: " & fijo
        cellCel.Text = "Teléfono móvil: " & movil
        cellCorreo.Text = "Correo: " & correo
    End Sub
End Class