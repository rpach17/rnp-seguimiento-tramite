<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregaDocs
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.txtCodigoTramite = New System.Windows.Forms.TextBox()
        Me.dgvTramites = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IdTramite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entregar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTramites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.dgvTramites)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(4, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(654, 491)
        Me.Panel1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFiltrar)
        Me.GroupBox1.Controls.Add(Me.lblInfo)
        Me.GroupBox1.Controls.Add(Me.txtCodigoTramite)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(597, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingrese Código de trámite o Número de Identidad"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.Location = New System.Drawing.Point(243, 19)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(112, 32)
        Me.btnFiltrar.TabIndex = 2
        Me.btnFiltrar.Text = "Buscar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
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
        'dgvTramites
        '
        Me.dgvTramites.AllowUserToAddRows = False
        Me.dgvTramites.AllowUserToDeleteRows = False
        Me.dgvTramites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvTramites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTramites.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTramite, Me.Column1, Me.Column2, Me.Column3, Me.Entregar})
        Me.dgvTramites.Location = New System.Drawing.Point(30, 121)
        Me.dgvTramites.Name = "dgvTramites"
        Me.dgvTramites.Size = New System.Drawing.Size(597, 342)
        Me.dgvTramites.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(27, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Recepción de trámites"
        '
        'IdTramite
        '
        Me.IdTramite.HeaderText = "IdTramite"
        Me.IdTramite.Name = "IdTramite"
        Me.IdTramite.Visible = False
        Me.IdTramite.Width = 76
        '
        'Column1
        '
        Me.Column1.HeaderText = "Código trámite"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 99
        '
        'Column2
        '
        Me.Column2.HeaderText = "Trámite"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 67
        '
        'Column3
        '
        Me.Column3.HeaderText = "ID Ciudadano"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 97
        '
        'Entregar
        '
        Me.Entregar.HeaderText = "Entregar"
        Me.Entregar.Name = "Entregar"
        Me.Entregar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Entregar.Text = "Entregar"
        Me.Entregar.Width = 53
        '
        'frmEntregaDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 503)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmEntregaDocs"
        Me.Text = "Entrega de Trámites"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTramites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTramite As System.Windows.Forms.TextBox
    Friend WithEvents dgvTramites As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents IdTramite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entregar As System.Windows.Forms.DataGridViewButtonColumn
End Class
