<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTramiteEditar
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
        Me.txtIdentidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrimerNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSegundoNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrimerApellido = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSegundoApellido = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTelefonoMovil = New System.Windows.Forms.MaskedTextBox()
        Me.txtTelefonoFijo = New System.Windows.Forms.MaskedTextBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCrearTramite = New System.Windows.Forms.Button()
        Me.btnCambiarTramite = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkExtranjero = New System.Windows.Forms.CheckBox()
        Me.txtNumTramites = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtCantidadDocs = New System.Windows.Forms.NumericUpDown()
        Me.cboRepresentante = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigoTramiteS = New System.Windows.Forms.TextBox()
        Me.txtMontoRecibo = New System.Windows.Forms.TextBox()
        Me.txtNumeroRecibo = New System.Windows.Forms.TextBox()
        Me.txtInfoAdicional = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboEnviarA = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtNumTramites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtCantidadDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIdentidad
        '
        Me.txtIdentidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentidad.Location = New System.Drawing.Point(109, 19)
        Me.txtIdentidad.MaxLength = 13
        Me.txtIdentidad.Name = "txtIdentidad"
        Me.txtIdentidad.Size = New System.Drawing.Size(158, 20)
        Me.txtIdentidad.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No. Identidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Primer nombre"
        '
        'txtPrimerNombre
        '
        Me.txtPrimerNombre.Location = New System.Drawing.Point(109, 45)
        Me.txtPrimerNombre.Name = "txtPrimerNombre"
        Me.txtPrimerNombre.Size = New System.Drawing.Size(158, 20)
        Me.txtPrimerNombre.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Segundo nombre"
        '
        'txtSegundoNombre
        '
        Me.txtSegundoNombre.Location = New System.Drawing.Point(109, 71)
        Me.txtSegundoNombre.Name = "txtSegundoNombre"
        Me.txtSegundoNombre.Size = New System.Drawing.Size(158, 20)
        Me.txtSegundoNombre.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Primer apellido"
        '
        'txtPrimerApellido
        '
        Me.txtPrimerApellido.Location = New System.Drawing.Point(109, 97)
        Me.txtPrimerApellido.Name = "txtPrimerApellido"
        Me.txtPrimerApellido.Size = New System.Drawing.Size(158, 20)
        Me.txtPrimerApellido.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Segundo apellido"
        '
        'txtSegundoApellido
        '
        Me.txtSegundoApellido.Location = New System.Drawing.Point(109, 123)
        Me.txtSegundoApellido.Name = "txtSegundoApellido"
        Me.txtSegundoApellido.Size = New System.Drawing.Size(158, 20)
        Me.txtSegundoApellido.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Teléfono fijo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Teléfono móvil"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Correo electrónico"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(109, 201)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(200, 20)
        Me.txtCorreo.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTelefonoMovil)
        Me.GroupBox1.Controls.Add(Me.txtTelefonoFijo)
        Me.GroupBox1.Controls.Add(Me.txtIdentidad)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCorreo)
        Me.GroupBox1.Controls.Add(Me.txtPrimerNombre)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSegundoNombre)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPrimerApellido)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtSegundoApellido)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 237)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Responsable"
        '
        'txtTelefonoMovil
        '
        Me.txtTelefonoMovil.Location = New System.Drawing.Point(109, 175)
        Me.txtTelefonoMovil.Mask = "0000-0000"
        Me.txtTelefonoMovil.Name = "txtTelefonoMovil"
        Me.txtTelefonoMovil.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefonoMovil.TabIndex = 6
        '
        'txtTelefonoFijo
        '
        Me.txtTelefonoFijo.Location = New System.Drawing.Point(109, 149)
        Me.txtTelefonoFijo.Mask = "0000-0000"
        Me.txtTelefonoFijo.Name = "txtTelefonoFijo"
        Me.txtTelefonoFijo.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefonoFijo.TabIndex = 5
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.NavajoWhite
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(0, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(1018, 30)
        Me.lblInfo.TabIndex = 17
        Me.lblInfo.Text = "Solo números"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblInfo.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(317, 153)
        Me.FlowLayoutPanel1.TabIndex = 0
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 268)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 172)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Requisitos ( * opcionales )"
        '
        'btnCrearTramite
        '
        Me.btnCrearTramite.Location = New System.Drawing.Point(492, 365)
        Me.btnCrearTramite.Name = "btnCrearTramite"
        Me.btnCrearTramite.Size = New System.Drawing.Size(141, 53)
        Me.btnCrearTramite.TabIndex = 4
        Me.btnCrearTramite.Text = "Imprimir"
        Me.btnCrearTramite.UseVisualStyleBackColor = True
        '
        'btnCambiarTramite
        '
        Me.btnCambiarTramite.Location = New System.Drawing.Point(641, 365)
        Me.btnCambiarTramite.Name = "btnCambiarTramite"
        Me.btnCambiarTramite.Size = New System.Drawing.Size(141, 53)
        Me.btnCambiarTramite.TabIndex = 5
        Me.btnCambiarTramite.Text = "Editar trámite"
        Me.btnCambiarTramite.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.chkExtranjero)
        Me.Panel1.Controls.Add(Me.txtNumTramites)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cboEnviarA)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnCambiarTramite)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnCrearTramite)
        Me.Panel1.Location = New System.Drawing.Point(77, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(863, 456)
        Me.Panel1.TabIndex = 0
        '
        'chkExtranjero
        '
        Me.chkExtranjero.AutoSize = True
        Me.chkExtranjero.Location = New System.Drawing.Point(556, 342)
        Me.chkExtranjero.Name = "chkExtranjero"
        Me.chkExtranjero.Size = New System.Drawing.Size(77, 17)
        Me.chkExtranjero.TabIndex = 30
        Me.chkExtranjero.Text = "Extrangero"
        Me.chkExtranjero.UseVisualStyleBackColor = True
        '
        'txtNumTramites
        '
        Me.txtNumTramites.Location = New System.Drawing.Point(492, 340)
        Me.txtNumTramites.Name = "txtNumTramites"
        Me.txtNumTramites.Size = New System.Drawing.Size(47, 20)
        Me.txtNumTramites.TabIndex = 28
        Me.txtNumTramites.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(361, 343)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Cantidad de Tramites"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtCantidadDocs)
        Me.GroupBox3.Controls.Add(Me.cboRepresentante)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtCodigoTramiteS)
        Me.GroupBox3.Controls.Add(Me.txtMontoRecibo)
        Me.GroupBox3.Controls.Add(Me.txtNumeroRecibo)
        Me.GroupBox3.Controls.Add(Me.txtInfoAdicional)
        Me.GroupBox3.Location = New System.Drawing.Point(354, 25)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(450, 237)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informacón Adicional"
        '
        'txtCantidadDocs
        '
        Me.txtCantidadDocs.Location = New System.Drawing.Point(138, 71)
        Me.txtCantidadDocs.Name = "txtCantidadDocs"
        Me.txtCantidadDocs.Size = New System.Drawing.Size(47, 20)
        Me.txtCantidadDocs.TabIndex = 2
        Me.txtCantidadDocs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboRepresentante
        '
        Me.cboRepresentante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRepresentante.FormattingEnabled = True
        Me.cboRepresentante.Location = New System.Drawing.Point(138, 97)
        Me.cboRepresentante.Name = "cboRepresentante"
        Me.cboRepresentante.Size = New System.Drawing.Size(290, 21)
        Me.cboRepresentante.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Tipo Representante"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 126)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Codigo Trámite"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Cantidad Docs"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Monto de Recibo(TGR)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Número de Recibo(TGR)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Nota"
        '
        'txtCodigoTramiteS
        '
        Me.txtCodigoTramiteS.Location = New System.Drawing.Point(138, 123)
        Me.txtCodigoTramiteS.Name = "txtCodigoTramiteS"
        Me.txtCodigoTramiteS.Size = New System.Drawing.Size(290, 20)
        Me.txtCodigoTramiteS.TabIndex = 4
        '
        'txtMontoRecibo
        '
        Me.txtMontoRecibo.Location = New System.Drawing.Point(138, 45)
        Me.txtMontoRecibo.Name = "txtMontoRecibo"
        Me.txtMontoRecibo.Size = New System.Drawing.Size(150, 20)
        Me.txtMontoRecibo.TabIndex = 1
        '
        'txtNumeroRecibo
        '
        Me.txtNumeroRecibo.Location = New System.Drawing.Point(138, 19)
        Me.txtNumeroRecibo.Name = "txtNumeroRecibo"
        Me.txtNumeroRecibo.Size = New System.Drawing.Size(150, 20)
        Me.txtNumeroRecibo.TabIndex = 0
        '
        'txtInfoAdicional
        '
        Me.txtInfoAdicional.Location = New System.Drawing.Point(138, 152)
        Me.txtInfoAdicional.Multiline = True
        Me.txtInfoAdicional.Name = "txtInfoAdicional"
        Me.txtInfoAdicional.Size = New System.Drawing.Size(290, 69)
        Me.txtInfoAdicional.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(361, 315)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Enviar a"
        '
        'cboEnviarA
        '
        Me.cboEnviarA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnviarA.FormattingEnabled = True
        Me.cboEnviarA.Location = New System.Drawing.Point(492, 312)
        Me.cboEnviarA.Name = "cboEnviarA"
        Me.cboEnviarA.Size = New System.Drawing.Size(290, 21)
        Me.cboEnviarA.TabIndex = 3
        '
        'frmTramiteEditar
        '
        Me.AccessibleDescription = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 536)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmTramiteEditar"
        Me.Text = "Trámite"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtNumTramites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtCantidadDocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtIdentidad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCrearTramite As System.Windows.Forms.Button
    Friend WithEvents txtTelefonoFijo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTelefonoMovil As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnCambiarTramite As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboEnviarA As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroRecibo As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoAdicional As System.Windows.Forms.TextBox
    Friend WithEvents cboRepresentante As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTramiteS As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadDocs As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtNumTramites As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkExtranjero As System.Windows.Forms.CheckBox
End Class
