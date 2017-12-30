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
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.lblDisplayCuentaEmisor = New System.Windows.Forms.Label()
        Me.lblDisplayBanco = New System.Windows.Forms.Label()
        Me.lblDisplayRFCEmisor = New System.Windows.Forms.Label()
        Me.lblDisplayFormaPago = New System.Windows.Forms.Label()
        Me.txtBanco = New System.Windows.Forms.TextBox()
        Me.txtRFCEmisor = New System.Windows.Forms.TextBox()
        Me.txtCuentaEmisor = New System.Windows.Forms.TextBox()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(452, 25)
        Me.tsMenu.TabIndex = 0
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
        Me.cboFormaPago.Size = New System.Drawing.Size(211, 21)
        Me.cboFormaPago.TabIndex = 2
        '
        'lblBanco
        '
        Me.lblBanco.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.Location = New System.Drawing.Point(176, 130)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(242, 13)
        Me.lblBanco.TabIndex = 350
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
        'lblDisplayBanco
        '
        Me.lblDisplayBanco.AutoSize = True
        Me.lblDisplayBanco.Location = New System.Drawing.Point(12, 129)
        Me.lblDisplayBanco.Name = "lblDisplayBanco"
        Me.lblDisplayBanco.Size = New System.Drawing.Size(98, 13)
        Me.lblDisplayBanco.TabIndex = 348
        Me.lblDisplayBanco.Text = "Banco emisor nac :"
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
        'txtBanco
        '
        Me.txtBanco.Location = New System.Drawing.Point(116, 126)
        Me.txtBanco.MaxLength = 3
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(54, 20)
        Me.txtBanco.TabIndex = 4
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
        Me.txtCuentaEmisor.MaxLength = 50
        Me.txtCuentaEmisor.Name = "txtCuentaEmisor"
        Me.txtCuentaEmisor.Size = New System.Drawing.Size(137, 20)
        Me.txtCuentaEmisor.TabIndex = 1
        '
        'Catalogo_ClientesCuentasBancarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 178)
        Me.Controls.Add(Me.cboFormaPago)
        Me.Controls.Add(Me.lblBanco)
        Me.Controls.Add(Me.lblDisplayCuentaEmisor)
        Me.Controls.Add(Me.lblDisplayBanco)
        Me.Controls.Add(Me.lblDisplayRFCEmisor)
        Me.Controls.Add(Me.lblDisplayFormaPago)
        Me.Controls.Add(Me.txtBanco)
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
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCuentaEmisor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayBanco As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRFCEmisor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFormaPago As System.Windows.Forms.Label
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtRFCEmisor As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaEmisor As System.Windows.Forms.TextBox
End Class
