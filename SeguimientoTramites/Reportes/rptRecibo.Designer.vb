<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptRecibo
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.cellNombre = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.cellIdentidad = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.cellTelf = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.cellCel = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.cellCorreo = New DevExpress.XtraReports.UI.XRTableCell()
        Me.lblCuerpo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2, Me.XrTable1, Me.lblCuerpo, Me.XrLine1})
        Me.Detail.HeightF = 346.7083!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable2
        '
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 0.0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow7, Me.XrTableRow9, Me.XrTableRow3, Me.XrTableRow8})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(433.3334!, 125.0!)
        Me.XrTable2.StylePriority.UseFont = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.cellNombre})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.StylePriority.UseBorders = False
        Me.XrTableRow2.Weight = 0.42458280783330271R
        '
        'cellNombre
        '
        Me.cellNombre.Name = "cellNombre"
        Me.cellNombre.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.cellNombre.StylePriority.UsePadding = False
        Me.cellNombre.StylePriority.UseTextAlignment = False
        Me.cellNombre.Text = "0601198504268"
        Me.cellNombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.cellNombre.Weight = 3.0R
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.cellIdentidad})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.StylePriority.UseBorders = False
        Me.XrTableRow7.Weight = 0.42458283699855526R
        '
        'cellIdentidad
        '
        Me.cellIdentidad.Name = "cellIdentidad"
        Me.cellIdentidad.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.cellIdentidad.StylePriority.UsePadding = False
        Me.cellIdentidad.StylePriority.UseTextAlignment = False
        Me.cellIdentidad.Text = "Josué Alfredo Alvarez Rueda"
        Me.cellIdentidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.cellIdentidad.Weight = 3.0R
        '
        'XrTableRow9
        '
        Me.XrTableRow9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.cellTelf})
        Me.XrTableRow9.Name = "XrTableRow9"
        Me.XrTableRow9.StylePriority.UseBorders = False
        Me.XrTableRow9.StylePriority.UseTextAlignment = False
        Me.XrTableRow9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableRow9.Weight = 0.4245828046054575R
        '
        'cellTelf
        '
        Me.cellTelf.Name = "cellTelf"
        Me.cellTelf.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.cellTelf.StylePriority.UsePadding = False
        Me.cellTelf.Text = "2780-1014"
        Me.cellTelf.Weight = 3.0R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.cellCel})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.StylePriority.UseBorders = False
        Me.XrTableRow3.StylePriority.UseTextAlignment = False
        Me.XrTableRow3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableRow3.Weight = 0.42458280460545744R
        '
        'cellCel
        '
        Me.cellCel.Name = "cellCel"
        Me.cellCel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.cellCel.StylePriority.UsePadding = False
        Me.cellCel.Text = "9797-8830"
        Me.cellCel.Weight = 2.9999999999999996R
        '
        'XrTableRow8
        '
        Me.XrTableRow8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.cellCorreo})
        Me.XrTableRow8.Name = "XrTableRow8"
        Me.XrTableRow8.StylePriority.UseBorders = False
        Me.XrTableRow8.StylePriority.UseTextAlignment = False
        Me.XrTableRow8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableRow8.Weight = 0.4245828046054575R
        '
        'cellCorreo
        '
        Me.cellCorreo.Name = "cellCorreo"
        Me.cellCorreo.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.cellCorreo.StylePriority.UsePadding = False
        Me.cellCorreo.Text = "josue@lapolitecnicahn.org"
        Me.cellCorreo.Weight = 3.0R
        '
        'lblCuerpo
        '
        Me.lblCuerpo.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.lblCuerpo.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 166.2083!)
        Me.lblCuerpo.Name = "lblCuerpo"
        Me.lblCuerpo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCuerpo.SizeF = New System.Drawing.SizeF(575.0!, 69.87498!)
        Me.lblCuerpo.SnapLineMargin = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 20, 100.0!)
        Me.lblCuerpo.StylePriority.UseFont = False
        Me.lblCuerpo.Text = "Recibí de Registro Nacional de las Personas (RNP) el {0} mediante {1} el trámite " & _
    "de {2} con código {3} iniciado el {4}"
        '
        'XrTable1
        '
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(170.8334!, 296.7083!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4, Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(300.0!, 50.0!)
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Weight = 3.0R
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrTableCell1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseBorders = False
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "Recibí conforme"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell1.Weight = 3.0R
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(37.5!, 125.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(575.0!, 23.0!)
        '
        'rptRecibo
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Version = "13.1"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents cellNombre As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents cellIdentidad As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents cellTelf As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents cellCel As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents cellCorreo As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents lblCuerpo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
End Class
