<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerificarDisponibilidad
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
        Me.dgvTramites = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel1.Controls.Add(Me.dgvTramites)
        Me.Panel1.Controls.Add(Me.btnRecibirTramites)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(27, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 375)
        Me.Panel1.TabIndex = 4
        '
        'dgvTramites
        '
        Me.dgvTramites.AllowUserToAddRows = False
        Me.dgvTramites.AllowUserToDeleteRows = False
        Me.dgvTramites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTramites.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTramites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTramites.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvTramites.Location = New System.Drawing.Point(30, 98)
        Me.dgvTramites.Name = "dgvTramites"
        Me.dgvTramites.ReadOnly = True
        Me.dgvTramites.Size = New System.Drawing.Size(597, 204)
        Me.dgvTramites.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 43
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nombre"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 69
        '
        'Column3
        '
        Me.Column3.HeaderText = "Apellido"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 69
        '
        'Column4
        '
        Me.Column4.HeaderText = "Número trámites"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 99
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
        'frmVerificarDisponibilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 412)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmVerificarDisponibilidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificar disponibilidad"
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
