Imports DevExpress.XtraPrinting.BarCode
Imports System.Text

Public Class rptReciboTramite
    Public Sub New(barcode As String, _
                   nombreGestion As String, _
                   fecha As String, _
                   identidad As String, _
                   nombre As String, _
                   telf As String, _
                   cel As String, _
                   correo As String, _
                   nota As String, _
                   url As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        XrBarCode1.Symbology = New QRCodeGenerator()

        XrBarCode1.AutoModule = True
        XrBarCode1.BinaryData = Encoding.ASCII.GetBytes(url)
        XrBarCode1.AutoModule = True
        XrBarCode1.ShowText = False

        DirectCast(XrBarCode1.Symbology, QRCodeGenerator).CompactionMode = QRCodeCompactionMode.Byte
        DirectCast(XrBarCode1.Symbology, QRCodeGenerator).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H
        DirectCast(XrBarCode1.Symbology, QRCodeGenerator).Version = QRCodeVersion.AutoVersion

        cellCodeBar.Text = barcode
        cellTramite.Text = nombreGestion
        cellFecha.Text = fecha

        cellIdentidad.Text = identidad
        cellNombre.Text = nombre
        cellTelefono.Text = telf
        cellCelular.Text = cel
        cellCorreo.Text = correo
        cellNota.Text = nota
    End Sub
End Class