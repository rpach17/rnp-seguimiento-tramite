<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeguimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecepciónDeDocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesarDocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerificarDisponibilidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblInfoConexion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblInfoUbicacion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmNotificacion = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem1, Me.SeguimientoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(919, 47)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem1
        '
        Me.OpcionesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSesiónToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.OpcionesToolStripMenuItem1.Name = "OpcionesToolStripMenuItem1"
        Me.OpcionesToolStripMenuItem1.Size = New System.Drawing.Size(78, 43)
        Me.OpcionesToolStripMenuItem1.Text = "&Opciones"
        '
        'CerrarSesiónToolStripMenuItem
        '
        Me.CerrarSesiónToolStripMenuItem.Image = Global.SeguimientoTramites.My.Resources.Resources.door_in
        Me.CerrarSesiónToolStripMenuItem.Name = "CerrarSesiónToolStripMenuItem"
        Me.CerrarSesiónToolStripMenuItem.Size = New System.Drawing.Size(158, 24)
        Me.CerrarSesiónToolStripMenuItem.Text = "Cerrar sesión"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.SeguimientoTramites.My.Resources.Resources.cross
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(158, 24)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'SeguimientoToolStripMenuItem
        '
        Me.SeguimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecepciónDeDocumentosToolStripMenuItem, Me.ProcesarDocumentosToolStripMenuItem, Me.VerificarDisponibilidadToolStripMenuItem})
        Me.SeguimientoToolStripMenuItem.Name = "SeguimientoToolStripMenuItem"
        Me.SeguimientoToolStripMenuItem.Size = New System.Drawing.Size(97, 43)
        Me.SeguimientoToolStripMenuItem.Text = "Seguimiento"
        '
        'RecepciónDeDocumentosToolStripMenuItem
        '
        Me.RecepciónDeDocumentosToolStripMenuItem.Name = "RecepciónDeDocumentosToolStripMenuItem"
        Me.RecepciónDeDocumentosToolStripMenuItem.Size = New System.Drawing.Size(238, 24)
        Me.RecepciónDeDocumentosToolStripMenuItem.Text = "Recepción de documentos"
        '
        'ProcesarDocumentosToolStripMenuItem
        '
        Me.ProcesarDocumentosToolStripMenuItem.Name = "ProcesarDocumentosToolStripMenuItem"
        Me.ProcesarDocumentosToolStripMenuItem.Size = New System.Drawing.Size(238, 24)
        Me.ProcesarDocumentosToolStripMenuItem.Text = "Procesar documentos"
        '
        'VerificarDisponibilidadToolStripMenuItem
        '
        Me.VerificarDisponibilidadToolStripMenuItem.Name = "VerificarDisponibilidadToolStripMenuItem"
        Me.VerificarDisponibilidadToolStripMenuItem.Size = New System.Drawing.Size(238, 24)
        Me.VerificarDisponibilidadToolStripMenuItem.Text = "Verificar disponibilidad"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblInfoConexion, Me.ToolStripStatusLabel2, Me.lblInfoUbicacion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 391)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(919, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(105, 17)
        Me.ToolStripStatusLabel1.Text = "Conectado como: "
        '
        'lblInfoConexion
        '
        Me.lblInfoConexion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoConexion.Name = "lblInfoConexion"
        Me.lblInfoConexion.Size = New System.Drawing.Size(128, 17)
        Me.lblInfoConexion.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel2.Text = " | "
        '
        'lblInfoUbicacion
        '
        Me.lblInfoUbicacion.Name = "lblInfoUbicacion"
        Me.lblInfoUbicacion.Size = New System.Drawing.Size(121, 17)
        Me.lblInfoUbicacion.Text = "ToolStripStatusLabel3"
        '
        'tmNotificacion
        '
        Me.tmNotificacion.Interval = 1800000
        Me.tmNotificacion.Tag = "Interval = 30 minutos"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(919, 413)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "frmPrincipal"
        Me.Text = "Seguimiento de trámites"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSesiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblInfoConexion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblInfoUbicacion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SeguimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecepciónDeDocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcesarDocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmNotificacion As System.Windows.Forms.Timer
    Friend WithEvents VerificarDisponibilidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
