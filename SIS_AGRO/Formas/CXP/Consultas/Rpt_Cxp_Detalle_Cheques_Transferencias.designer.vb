<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Cxp_Detalle_Cheques_Transferencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Cxp_Detalle_Cheques_Transferencias))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbFormatoPorConcepto = New System.Windows.Forms.RadioButton()
        Me.rbFormatoDetallado = New System.Windows.Forms.RadioButton()
        Me.cboConceptoPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayConceptoPago = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblCodigoProveedor = New System.Windows.Forms.Label()
        Me.txtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.lblCuentaBancaria = New System.Windows.Forms.Label()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDisplayTipo = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.lblEjercicio = New System.Windows.Forms.Label()
        Me.lblBancaria = New System.Windows.Forms.Label()
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.RbtFormatoPorProveedor = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbtFormatoPorProveedor)
        Me.GroupBox1.Controls.Add(Me.rbFormatoPorConcepto)
        Me.GroupBox1.Controls.Add(Me.rbFormatoDetallado)
        Me.GroupBox1.Controls.Add(Me.cboConceptoPago)
        Me.GroupBox1.Controls.Add(Me.lblDisplayConceptoPago)
        Me.GroupBox1.Controls.Add(Me.lblProveedor)
        Me.GroupBox1.Controls.Add(Me.lblCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.txtCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.lblCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.CboDocumento)
        Me.GroupBox1.Controls.Add(Me.LblDisplayTipo)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.CboEstatus)
        Me.GroupBox1.Controls.Add(Me.lblEjercicio)
        Me.GroupBox1.Controls.Add(Me.lblBancaria)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaHasta)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.lblFechaDesde)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.txtCuentaBancaria)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(545, 393)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rbFormatoPorConcepto
        '
        Me.rbFormatoPorConcepto.AutoSize = True
        Me.rbFormatoPorConcepto.Location = New System.Drawing.Point(31, 330)
        Me.rbFormatoPorConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbFormatoPorConcepto.Name = "rbFormatoPorConcepto"
        Me.rbFormatoPorConcepto.Size = New System.Drawing.Size(224, 21)
        Me.rbFormatoPorConcepto.TabIndex = 268
        Me.rbFormatoPorConcepto.Text = "Formato por concepto de pago"
        Me.rbFormatoPorConcepto.UseVisualStyleBackColor = True
        '
        'rbFormatoDetallado
        '
        Me.rbFormatoDetallado.AutoSize = True
        Me.rbFormatoDetallado.Checked = True
        Me.rbFormatoDetallado.Location = New System.Drawing.Point(31, 302)
        Me.rbFormatoDetallado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbFormatoDetallado.Name = "rbFormatoDetallado"
        Me.rbFormatoDetallado.Size = New System.Drawing.Size(143, 21)
        Me.rbFormatoDetallado.TabIndex = 267
        Me.rbFormatoDetallado.TabStop = True
        Me.rbFormatoDetallado.Text = "Formato detallado"
        Me.rbFormatoDetallado.UseVisualStyleBackColor = True
        '
        'cboConceptoPago
        '
        Me.cboConceptoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConceptoPago.FormattingEnabled = True
        Me.cboConceptoPago.Location = New System.Drawing.Point(156, 254)
        Me.cboConceptoPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboConceptoPago.Name = "cboConceptoPago"
        Me.cboConceptoPago.Size = New System.Drawing.Size(295, 24)
        Me.cboConceptoPago.TabIndex = 6
        '
        'lblDisplayConceptoPago
        '
        Me.lblDisplayConceptoPago.AutoSize = True
        Me.lblDisplayConceptoPago.Location = New System.Drawing.Point(27, 261)
        Me.lblDisplayConceptoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayConceptoPago.Name = "lblDisplayConceptoPago"
        Me.lblDisplayConceptoPago.Size = New System.Drawing.Size(76, 17)
        Me.lblDisplayConceptoPago.TabIndex = 253
        Me.lblDisplayConceptoPago.Text = "Concepto :"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(241, 226)
        Me.lblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(12, 17)
        Me.lblProveedor.TabIndex = 251
        Me.lblProveedor.Text = "."
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(27, 226)
        Me.lblCodigoProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(82, 17)
        Me.lblCodigoProveedor.TabIndex = 250
        Me.lblCodigoProveedor.Text = "Proveedor :"
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(156, 222)
        Me.txtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigoProveedor.MaxLength = 15
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(64, 22)
        Me.txtCodigoProveedor.TabIndex = 5
        Me.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(241, 192)
        Me.lblCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(12, 17)
        Me.lblCuentaBancaria.TabIndex = 248
        Me.lblCuentaBancaria.Text = "."
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(156, 116)
        Me.CboDocumento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(295, 24)
        Me.CboDocumento.TabIndex = 3
        '
        'LblDisplayTipo
        '
        Me.LblDisplayTipo.AutoSize = True
        Me.LblDisplayTipo.Location = New System.Drawing.Point(27, 123)
        Me.LblDisplayTipo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTipo.Name = "LblDisplayTipo"
        Me.LblDisplayTipo.Size = New System.Drawing.Size(114, 17)
        Me.LblDisplayTipo.TabIndex = 247
        Me.LblDisplayTipo.Text = "Tipo documento:"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(27, 158)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 246
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Location = New System.Drawing.Point(156, 149)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(176, 24)
        Me.CboEstatus.TabIndex = 4
        '
        'lblEjercicio
        '
        Me.lblEjercicio.AutoSize = True
        Me.lblEjercicio.Location = New System.Drawing.Point(27, 20)
        Me.lblEjercicio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEjercicio.Name = "lblEjercicio"
        Me.lblEjercicio.Size = New System.Drawing.Size(69, 17)
        Me.lblEjercicio.TabIndex = 8
        Me.lblEjercicio.Text = "Ejercicio :"
        '
        'lblBancaria
        '
        Me.lblBancaria.AutoSize = True
        Me.lblBancaria.Location = New System.Drawing.Point(27, 192)
        Me.lblBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBancaria.Name = "lblBancaria"
        Me.lblBancaria.Size = New System.Drawing.Size(120, 17)
        Me.lblBancaria.TabIndex = 11
        Me.lblBancaria.Text = "Cuenta bancaria :"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(156, 16)
        Me.CmbEjercicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(176, 24)
        Me.CmbEjercicio.TabIndex = 0
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.Location = New System.Drawing.Point(27, 89)
        Me.lblFechaHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(45, 17)
        Me.lblFechaHasta.TabIndex = 10
        Me.lblFechaHasta.Text = "Hasta"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(156, 49)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(295, 22)
        Me.DtFechaDesde.TabIndex = 1
        Me.DtFechaDesde.Value = New Date(2011, 1, 1, 0, 0, 0, 0)
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.Location = New System.Drawing.Point(27, 54)
        Me.lblFechaDesde.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(57, 17)
        Me.lblFechaDesde.TabIndex = 9
        Me.lblFechaDesde.Text = "Desde :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(156, 81)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(295, 22)
        Me.DtFechaHasta.TabIndex = 2
        Me.DtFechaHasta.Value = New Date(2011, 12, 31, 0, 0, 0, 0)
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(156, 187)
        Me.txtCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuentaBancaria.MaxLength = 15
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(64, 22)
        Me.txtCuentaBancaria.TabIndex = 4
        Me.txtCuentaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(573, 27)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(90, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'RbtFormatoPorProveedor
        '
        Me.RbtFormatoPorProveedor.AutoSize = True
        Me.RbtFormatoPorProveedor.Location = New System.Drawing.Point(31, 359)
        Me.RbtFormatoPorProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.RbtFormatoPorProveedor.Name = "RbtFormatoPorProveedor"
        Me.RbtFormatoPorProveedor.Size = New System.Drawing.Size(175, 21)
        Me.RbtFormatoPorProveedor.TabIndex = 269
        Me.RbtFormatoPorProveedor.Text = "Formato por proveedor"
        Me.RbtFormatoPorProveedor.UseVisualStyleBackColor = True
        '
        'Rpt_Cxp_Detalle_Cheques_Transferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 436)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Cxp_Detalle_Cheques_Transferencias"
        Me.Text = "Reporte de cxp detalle de cheques o transferencias"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEjercicio As System.Windows.Forms.Label
    Friend WithEvents lblBancaria As System.Windows.Forms.Label
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayTipo As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents lblCodigoProveedor As System.Windows.Forms.Label
    Friend WithEvents txtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboConceptoPago As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayConceptoPago As System.Windows.Forms.Label
    Friend WithEvents rbFormatoPorConcepto As System.Windows.Forms.RadioButton
    Friend WithEvents rbFormatoDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents RbtFormatoPorProveedor As System.Windows.Forms.RadioButton
End Class
