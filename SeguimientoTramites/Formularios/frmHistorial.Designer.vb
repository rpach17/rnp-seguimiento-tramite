<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorial
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTramite = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.dgvTramites = New System.Windows.Forms.DataGridView()
        Me.btnRecibirTramites = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.txtCodigoTramite = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTramites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblTramite)
        Me.Panel1.Controls.Add(Me.lblActivo)
        Me.Panel1.Controls.Add(Me.lblCodigo)
        Me.Panel1.Controls.Add(Me.dgvTramites)
        Me.Panel1.Controls.Add(Me.btnRecibirTramites)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(27, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 488)
        Me.Panel1.TabIndex = 4
        '
        'lblTramite
        '
        Me.lblTramite.AutoSize = True
        Me.lblTramite.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTramite.Location = New System.Drawing.Point(36, 135)
        Me.lblTramite.Name = "lblTramite"
        Me.lblTramite.Size = New System.Drawing.Size(66, 24)
        Me.lblTramite.TabIndex = 5
        Me.lblTramite.Text = "Label1"
        '
        'lblActivo
        '
        Me.lblActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.Location = New System.Drawing.Point(366, 105)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblActivo.Size = New System.Drawing.Size(261, 24)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Label1"
        Me.lblActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(36, 105)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(66, 24)
        Me.lblCodigo.TabIndex = 5
        Me.lblCodigo.Text = "Label1"
        '
        'dgvTramites
        '
        Me.dgvTramites.AllowUserToAddRows = False
        Me.dgvTramites.AllowUserToDeleteRows = False
        Me.dgvTramites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTramites.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTramites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTramites.Location = New System.Drawing.Point(30, 162)
        Me.dgvTramites.Name = "dgvTramites"
        Me.dgvTramites.ReadOnly = True
        Me.dgvTramites.Size = New System.Drawing.Size(597, 307)
        Me.dgvTramites.TabIndex = 4
        '
        'btnRecibirTramites
        '
        Me.btnRecibirTramites.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnRecibirTramites.Location = New System.Drawing.Point(30, 517)
        Me.btnRecibirTramites.Name = "btnRecibirTramites"
        Me.btnRecibirTramites.Size = New System.Drawing.Size(207, 51)
        Me.btnRecibirTramites.TabIndex = 3
        Me.btnRecibirTramites.Text = "&Recibir tramites seleccionados"
        Me.btnRecibirTramites.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblInfo)
        Me.GroupBox1.Controls.Add(Me.txtCodigoTramite)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(597, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Código de trámite"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(257, 30)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(10, 13)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "."
        '
        'txtCodigoTramite
        '
        Me.txtCodigoTramite.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtCodigoTramite.Location = New System.Drawing.Point(25, 22)
        Me.txtCodigoTramite.MaxLength = 12
        Me.txtCodigoTramite.Name = "txtCodigoTramite"
        Me.txtCodigoTramite.Size = New System.Drawing.Size(197, 27)
        Me.txtCodigoTramite.TabIndex = 0
        '
        'frmHistorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 531)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmHistorial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificar disponibilidad"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvTramites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnRecibirTramites As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTramite As System.Windows.Forms.TextBox
    Friend WithEvents dgvTramites As System.Windows.Forms.DataGridView
    Friend WithEvents lblTramite As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
End Class
