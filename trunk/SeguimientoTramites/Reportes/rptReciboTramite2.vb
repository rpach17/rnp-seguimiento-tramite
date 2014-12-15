Public Class rptReciboTramite2
    Public Sub New(ByVal barcode As String, _
               ByVal nombreGestion As String, _
               ByVal fecha As String, _
               ByVal identidad As String, _
               ByVal nombre As String, _
               ByVal telf As String, _
               ByVal cel As String, _
               ByVal correo As String, _
               ByVal nota As String, _
               ByVal numeroRecibo As String, _
               ByVal montoRecibo As String, _
               ByVal codigoRNP As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'cellCodeBar.Font = New Font("barcode font", 65.75!)
        'cellCodeBar.Text = barcode
        XrBarCode1.Text = barcode
        cellTramite.Text = nombreGestion
        cellFecha.Text = fecha

        cellIdentidad.Text = identidad
        cellNombre.Text = nombre
        cellTelf.Text = telf
        cellCel.Text = cel
        cellCorre.Text = correo
        cellNota.Text = nota
        cellNoRecibo.Text = numeroRecibo
        cellMontoRecibo.Text = String.Format("L. {0}.00", montoRecibo)
        cellCodigoRNP.Text = codigoRNP

        lblCuerpo.Text = String.Format("Recibí del señor(a)  ___________________________________ que labora en Registro Nacional de las Personas (RNP) el trámite de {0}. Lugar y Fecha ___________________", _
                                      nombreGestion)

    End Sub
End Class