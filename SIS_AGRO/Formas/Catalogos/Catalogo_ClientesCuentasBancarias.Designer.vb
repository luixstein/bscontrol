<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_ClientesCuentasBancarias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_ClientesCuentasBancarias))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCuentaEmisor = New System.Windows.Forms.Label()
        Me.lblDisplayBancoCodigo = New System.Windows.Forms.Label()
        Me.lblDisplayRFCEmisor = New System.Windows.Forms.Label()
        Me.lblDisplayFormaPago = New System.Windows.Forms.Label()
        Me.txtBancoCodigo = New System.Windows.Forms.TextBox()
        Me.txtRFCEmisor = New System.Windows.Forms.TextBox()
        Me.txtCuentaEmisor = New System.Windows.Forms.TextBox()
        Me.chkEsBancoExtranjero = New System.Windows.Forms.CheckBox()
        Me.txtBancoAlias = New System.Windows.Forms.TextBox()
        Me.txtBancoNombre = New System.Windows.Forms.TextBox()
        Me.lblDisplayBancoAlias = New System.Windows.Forms.Label()
        Me.lblDisplayBancoNombre = New System.Windows.Forms.Label()
        Me.lblMsgBancoExtranjero = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(631, 25)
        Me.tsMenu.TabIndex = 6
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(116, 66)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(302, 21)
        Me.cboFormaPago.TabIndex = 2
        '
        'lblDisplayCuentaEmisor
        '
        Me.lblDisplayCuentaEmisor.AutoSize = True
        Me.lblDisplayCuentaEmisor.Location = New System.Drawing.Point(12, 41)
        Me.lblDisplayCuentaEmisor.Name = "lblDisplayCuentaEmisor"
        Me.lblDisplayCuentaEmisor.Size = New System.Drawing.Size(90, 13)
        Me.lblDisplayCuentaEmisor.TabIndex = 349
        Me.lblDisplayCuentaEmisor.Text = "# Cuenta emisor :"
        '
        'lblDisplayBancoCodigo
        '
        Me.lblDisplayBancoCodigo.AutoSize = True
        Me.lblDisplayBancoCodigo.Location = New System.Drawing.Point(12, 129)
        Me.lblDisplayBancoCodigo.Name = "lblDisplayBancoCodigo"
        Me.lblDisplayBancoCodigo.Size = New System.Drawing.Size(120, 13)
        Me.lblDisplayBancoCodigo.TabIndex = 348
        Me.lblDisplayBancoCodigo.Text = "Banco emisor nacional :"
        '
        'lblDisplayRFCEmisor
        '
        Me.lblDisplayRFCEmisor.AutoSize = True
        Me.lblDisplayRFCEmisor.Location = New System.Drawing.Point(12, 100)
        Me.lblDisplayRFCEmisor.Name = "lblDisplayRFCEmisor"
        Me.lblDisplayRFCEmisor.Size = New System.Drawing.Size(68, 13)
        Me.lblDisplayRFCEmisor.TabIndex = 347
        Me.lblDisplayRFCEmisor.Text = "RFC Emisor :"
        '
        'lblDisplayFormaPago
        '
        Me.lblDisplayFormaPago.AutoSize = True
        Me.lblDisplayFormaPago.Location = New System.Drawing.Point(12, 69)
        Me.lblDisplayFormaPago.Name = "lblDisplayFormaPago"
        Me.lblDisplayFormaPago.Size = New System.Drawing.Size(84, 13)
        Me.lblDisplayFormaPago.TabIndex = 346
        Me.lblDisplayFormaPago.Text = "Forma de pago :"
        '
        'txtBancoCodigo
        '
        Me.txtBancoCodigo.Location = New System.Drawing.Point(138, 126)
        Me.txtBancoCodigo.MaxLength = 3
        Me.txtBancoCodigo.Name = "txtBancoCodigo"
        Me.txtBancoCodigo.Size = New System.Drawing.Size(54, 20)
        Me.txtBancoCodigo.TabIndex = 4
        '
        'txtRFCEmisor
        '
        Me.txtRFCEmisor.Location = New System.Drawing.Point(116, 97)
        Me.txtRFCEmisor.MaxLength = 13
        Me.txtRFCEmisor.Name = "txtRFCEmisor"
        Me.txtRFCEmisor.Size = New System.Drawing.Size(137, 20)
        Me.txtRFCEmisor.TabIndex = 3
        '
        'txtCuentaEmisor
        '
        Me.txtCuentaEmisor.Location = New System.Drawing.Point(116, 38)
        Me.txtCuentaEmisor.MaxLength = 18
        Me.txtCuentaEmisor.Name = "txtCuentaEmisor"
        Me.txtCuentaEmisor.Size = New System.Drawing.Size(137, 20)
        Me.txtCuentaEmisor.TabIndex = 1
        '
        'chkEsBancoExtranjero
        '
        Me.chkEsBancoExtranjero.Location = New System.Drawing.Point(274, 109)
        Me.chkEsBancoExtranjero.Name = "chkEsBancoExtranjero"
        Me.chkEsBancoExtranjero.Size = New System.Drawing.Size(313, 46)
        Me.chkEsBancoExtranjero.TabIndex = 7
        Me.chkEsBancoExtranjero.Text = "Es banco extranjero ? (marque esta casilla sólo si la cuenta bancaria del cliente" &
    " esta en otro pais, si la cuenta es en USD de banco mexicano no marque esta casi" &
    "lla)"
        Me.chkEsBancoExtranjero.UseVisualStyleBackColor = True
        '
        'txtBancoAlias
        '
        Me.txtBancoAlias.Location = New System.Drawing.Point(116, 152)
        Me.txtBancoAlias.MaxLength = 0
        Me.txtBancoAlias.Name = "txtBancoAlias"
        Me.txtBancoAlias.ReadOnly = True
        Me.txtBancoAlias.Size = New System.Drawing.Size(137, 20)
        Me.txtBancoAlias.TabIndex = 352
        '
        'txtBancoNombre
        '
        Me.txtBancoNombre.Location = New System.Drawing.Point(116, 178)
        Me.txtBancoNombre.MaxLength = 300
        Me.txtBancoNombre.Multiline = True
        Me.txtBancoNombre.Name = "txtBancoNombre"
        Me.txtBancoNombre.Size = New System.Drawing.Size(508, 39)
        Me.txtBancoNombre.TabIndex = 5
        '
        'lblDisplayBancoAlias
        '
        Me.lblDisplayBancoAlias.AutoSize = True
        Me.lblDisplayBancoAlias.Location = New System.Drawing.Point(12, 155)
        Me.lblDisplayBancoAlias.Name = "lblDisplayBancoAlias"
        Me.lblDisplayBancoAlias.Size = New System.Drawing.Size(68, 13)
        Me.lblDisplayBancoAlias.TabIndex = 354
        Me.lblDisplayBancoAlias.Text = "Alias banco :"
        '
        'lblDisplayBancoNombre
        '
        Me.lblDisplayBancoNombre.AutoSize = True
        Me.lblDisplayBancoNombre.Location = New System.Drawing.Point(12, 181)
        Me.lblDisplayBancoNombre.Name = "lblDisplayBancoNombre"
        Me.lblDisplayBancoNombre.Size = New System.Drawing.Size(83, 13)
        Me.lblDisplayBancoNombre.TabIndex = 355
        Me.lblDisplayBancoNombre.Text = "Nombre banco :"
        '
        'lblMsgBancoExtranjero
        '
        Me.lblMsgBancoExtranjero.AutoSize = True
        Me.lblMsgBancoExtranjero.BackColor = System.Drawing.Color.White
        Me.lblMsgBancoExtranjero.Location = New System.Drawing.Point(113, 227)
        Me.lblMsgBancoExtranjero.Name = "lblMsgBancoExtranjero"
        Me.lblMsgBancoExtranjero.Size = New System.Drawing.Size(245, 13)
        Me.lblMsgBancoExtranjero.TabIndex = 356
        Me.lblMsgBancoExtranjero.Text = "Teclee aquí arriba el nombre del banco extranjero "
        Me.lblMsgBancoExtranjero.Visible = False
        '
        'Catalogo_ClientesCuentasBancarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 249)
        Me.Controls.Add(Me.lblMsgBancoExtranjero)
        Me.Controls.Add(Me.lblDisplayBancoNombre)
        Me.Controls.Add(Me.lblDisplayBancoAlias)
        Me.Controls.Add(Me.txtBancoNombre)
        Me.Controls.Add(Me.txtBancoAlias)
        Me.Controls.Add(Me.chkEsBancoExtranjero)
        Me.Controls.Add(Me.cboFormaPago)
        Me.Controls.Add(Me.lblDisplayCuentaEmisor)
        Me.Controls.Add(Me.lblDisplayBancoCodigo)
        Me.Controls.Add(Me.lblDisplayRFCEmisor)
        Me.Controls.Add(Me.lblDisplayFormaPago)
        Me.Controls.Add(Me.txtBancoCodigo)
        Me.Controls.Add(Me.txtRFCEmisor)
        Me.Controls.Add(Me.txtCuentaEmisor)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_ClientesCuentasBancarias"
        Me.Text = "Cuentas bancarias cliente"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCuentaEmisor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayBancoCodigo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRFCEmisor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFormaPago As System.Windows.Forms.Label
    Friend WithEvents txtBancoCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtRFCEmisor As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaEmisor As System.Windows.Forms.TextBox
    Friend WithEvents chkEsBancoExtranjero As CheckBox
    Friend WithEvents txtBancoAlias As TextBox
    Friend WithEvents txtBancoNombre As TextBox
    Friend WithEvents lblDisplayBancoAlias As Label
    Friend WithEvents lblDisplayBancoNombre As Label
    Friend WithEvents lblMsgBancoExtranjero As Label
End Class
