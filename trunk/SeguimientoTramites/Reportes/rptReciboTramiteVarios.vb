Imports DevExpress.XtraPrinting.BarCode
Imports System.Text

Public Class rptReciboTramiteVarios
    Public Sub New(ByVal lista As List(Of DatosReporte))

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        XrBarCode1.Symbology = New QRCodeGenerator()

        XrBarCode1.AutoModule = True
        XrBarCode1.BinaryData = Encoding.ASCII.GetBytes(String.Format("http://tramites.rnp.hn/{0}", lista.Item(0).codigo))
        XrBarCode1.AutoModule = True
        XrBarCode1.ShowText = False

        DirectCast(XrBarCode1.Symbology, QRCodeGenerator).CompactionMode = QRCodeCompactionMode.Byte
        DirectCast(XrBarCode1.Symbology, QRCodeGenerator).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H
        DirectCast(XrBarCode1.Symbology, QRCodeGenerator).Version = QRCodeVersion.AutoVersion

        cellCodeBar.Text = lista.Item(0).codigo
        cellTramite.Text = lista.Item(0).nGestion
        cellFecha.Text = lista.Item(0).fecha

        cellIdentidad.Text = lista.Item(0).identidad
        cellNombre.Text = lista.Item(0).nombreCiudadano
        cellTelefono.Text = lista.Item(0).tFijo
        cellCelular.Text = lista.Item(0).tMovil
        cellCorreo.Text = lista.Item(0).email
        cellNota.Text = lista.Item(0).nota
        cellCodigoRNP.Text = lista.Item(0).codigoRNP

        cellCodigos.Text = "Trámites: "
        For Each l In lista
            cellCodigos.Text = String.Format("{0} - {1}", cellCodigos.Text, l.codigo)
        Next

    End Sub
End Class