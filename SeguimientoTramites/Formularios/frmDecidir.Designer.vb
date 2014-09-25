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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboUserDestino = New System.Windows.Forms.ComboBox()
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
        Me.lblDescripcion.Size = New System.Drawing.Size(634, 43)
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
        Me.GroupBox1.Location = New System.Drawing.Point(104, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 149)
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
        Me.btnDecidir.Location = New System.Drawing.Point(407, 254)
        Me.btnDecidir.Name = "btnDecidir"
        Me.btnDecidir.Size = New System.Drawing.Size(124, 39)
        Me.btnDecidir.TabIndex = 3
        Me.btnDecidir.Text = "&Aceptar"
        Me.btnDecidir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(100, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Asignar a"
        '
        'cboUserDestino
        '
        Me.cboUserDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cboUserDestino.FormattingEnabled = True
        Me.cboUserDestino.Location = New System.Drawing.Point(183, 220)
        Me.cboUserDestino.Name = "cboUserDestino"
        Me.cboUserDestino.Size = New System.Drawing.Size(348, 28)
        Me.cboUserDestino.TabIndex = 5
        '
        'btnAgregarError
        '
        Me.btnAgregarError.Image = Global.SeguimientoTramites.My.Resources.Resources.add1
        Me.btnAgregarError.Location = New System.Drawing.Point(382, 94)
        Me.btnAgregarError.Name = "btnAgregarError"
        Me.btnAgregarError.Size = New System.Drawing.Size(28, 28)
        Me.btnAgregarError.TabIndex = 4
        Me.btnAgregarError.UseVisualStyleBackColor = True
        '
        'frmDecidir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 335)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDecidir)
        Me.Controls.Add(Me.cboUserDestino)
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
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoF As System.Windows.Forms.RadioButton
    Friend WithEvents rdoV As System.Windows.Forms.RadioButton
    Friend WithEvents btnDecidir As System.Windows.Forms.Button
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents cboError As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregarError As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboUserDestino As System.Windows.Forms.ComboBox
End Class
