<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDecidir
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
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.cboError = New System.Windows.Forms.ComboBox()
        Me.rdoF = New System.Windows.Forms.RadioButton()
        Me.rdoV = New System.Windows.Forms.RadioButton()
        Me.btnDecidir = New System.Windows.Forms.Button()
        Me.btnAgregarError = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Gray
        Me.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.White
        Me.lblDescripcion.Location = New System.Drawing.Point(0, 0)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(491, 43)
        Me.lblDescripcion.TabIndex = 0
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAgregarError)
        Me.GroupBox1.Controls.Add(Me.lblError)
        Me.GroupBox1.Controls.Add(Me.cboError)
        Me.GroupBox1.Controls.Add(Me.rdoF)
        Me.GroupBox1.Controls.Add(Me.rdoV)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(57, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(388, 153)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblError.Location = New System.Drawing.Point(29, 97)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(44, 20)
        Me.lblError.TabIndex = 3
        Me.lblError.Text = "Error"
        '
        'cboError
        '
        Me.cboError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cboError.FormattingEnabled = True
        Me.cboError.Location = New System.Drawing.Point(79, 94)
        Me.cboError.Name = "cboError"
        Me.cboError.Size = New System.Drawing.Size(297, 28)
        Me.cboError.TabIndex = 2
        '
        'rdoF
        '
        Me.rdoF.AutoSize = True
        Me.rdoF.Location = New System.Drawing.Point(79, 67)
        Me.rdoF.Name = "rdoF"
        Me.rdoF.Size = New System.Drawing.Size(47, 21)
        Me.rdoF.TabIndex = 1
        Me.rdoF.TabStop = True
        Me.rdoF.Text = "NO"
        Me.rdoF.UseVisualStyleBackColor = True
        '
        'rdoV
        '
        Me.rdoV.AutoSize = True
        Me.rdoV.Location = New System.Drawing.Point(79, 32)
        Me.rdoV.Name = "rdoV"
        Me.rdoV.Size = New System.Drawing.Size(38, 21)
        Me.rdoV.TabIndex = 0
        Me.rdoV.TabStop = True
        Me.rdoV.Text = "SI"
        Me.rdoV.UseVisualStyleBackColor = True
        '
        'btnDecidir
        '
        Me.btnDecidir.Location = New System.Drawing.Point(57, 235)
        Me.btnDecidir.Name = "btnDecidir"
        Me.btnDecidir.Size = New System.Drawing.Size(124, 39)
        Me.btnDecidir.TabIndex = 3
        Me.btnDecidir.Text = "&Aceptar"
        Me.btnDecidir.UseVisualStyleBackColor = True
        '
        'btnAgregarError
        '
        Me.btnAgregarError.Location = New System.Drawing.Point(332, 128)
        Me.btnAgregarError.Name = "btnAgregarError"
        Me.btnAgregarError.Size = New System.Drawing.Size(44, 23)
        Me.btnAgregarError.TabIndex = 4
        Me.btnAgregarError.Text = "..."
        Me.btnAgregarError.UseVisualStyleBackColor = True
        '
        'frmDecidir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 291)
        Me.Controls.Add(Me.btnDecidir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblDescripcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDecidir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tomar decisión"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoF As System.Windows.Forms.RadioButton
    Friend WithEvents rdoV As System.Windows.Forms.RadioButton
    Friend WithEvents btnDecidir As System.Windows.Forms.Button
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents cboError As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregarError As System.Windows.Forms.Button
End Class
