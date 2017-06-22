<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_CXC_Documentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_CXC_Documentos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblNombreVendedor = New System.Windows.Forms.Label()
        Me.lblDisplayVendedor = New System.Windows.Forms.Label()
        Me.txtCodigoVendedor = New System.Windows.Forms.TextBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.LblDisplayDocumento = New System.Windows.Forms.Label()
        Me.CboDocumentos = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDisplayPropietario = New System.Windows.Forms.Label()
        Me.txtPropietario = New System.Windows.Forms.TextBox()
        Me.lblPropietario = New System.Windows.Forms.Label()
        Me.CboZona = New System.Windows.Forms.ComboBox()
        Me.lblDisplayZona = New System.Windows.Forms.Label()
        Me.lblCuentaBancaria = New System.Windows.Forms.Label()
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.lblDisplayCuentaBancaria = New System.Windows.Forms.Label()
        Me.LblDisplayFechaFinal = New System.Windows.Forms.Label()
        Me.lblDisplayFechaInicio = New System.Windows.Forms.Label()
        Me.lblDisplayEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.dpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayTipoMercado = New System.Windows.Forms.Label()
        Me.CboTipoMercado = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbDetalleBultos = New System.Windows.Forms.RadioButton()
        Me.RdbDetalleDepositos = New System.Windows.Forms.RadioButton()
        Me.RdbDetalleCXC = New System.Windows.Forms.RadioButton()
        Me.RdbGlobalCXC = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(559, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'lblNombreVendedor
        '
        Me.lblNombreVendedor.AutoSize = True
        Me.lblNombreVendedor.Location = New System.Drawing.Point(143, 79)
        Me.lblNombreVendedor.Name = "lblNombreVendedor"
        Me.lblNombreVendedor.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreVendedor.TabIndex = 257
        Me.lblNombreVendedor.Text = "."
        '
        'lblDisplayVendedor
        '
        Me.lblDisplayVendedor.AutoSize = True
        Me.lblDisplayVendedor.Location = New System.Drawing.Point(6, 79)
        Me.lblDisplayVendedor.Name = "lblDisplayVendedor"
        Me.lblDisplayVendedor.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayVendedor.TabIndex = 256
        Me.lblDisplayVendedor.Text = "Vendedor :"
        '
        'txtCodigoVendedor
        '
        Me.txtCodigoVendedor.Location = New System.Drawing.Point(88, 75)
        Me.txtCodigoVendedor.MaxLength = 15
        Me.txtCodigoVendedor.Name = "txtCodigoVendedor"
        Me.txtCodigoVendedor.Size = New System.Drawing.Size(49, 20)
        Me.txtCodigoVendedor.TabIndex = 2
        Me.txtCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(143, 26)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreCliente.TabIndex = 255
        Me.lblNombreCliente.Text = "."
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(6, 26)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 254
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(88, 23)
        Me.txtCodigoCliente.MaxLength = 15
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(49, 20)
        Me.txtCodigoCliente.TabIndex = 0
        Me.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayDocumento
        '
        Me.LblDisplayDocumento.AutoSize = True
        Me.LblDisplayDocumento.Location = New System.Drawing.Point(6, 107)
        Me.LblDisplayDocumento.Name = "LblDisplayDocumento"
        Me.LblDisplayDocumento.Size = New System.Drawing.Size(73, 13)
        Me.LblDisplayDocumento.TabIndex = 259
        Me.LblDisplayDocumento.Text = "Documentos :"
        '
        'CboDocumentos
        '
        Me.CboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumentos.FormattingEnabled = True
        Me.CboDocumentos.Location = New System.Drawing.Point(88, 104)
        Me.CboDocumentos.MaxLength = 1
        Me.CboDocumentos.Name = "CboDocumentos"
        Me.CboDocumentos.Size = New System.Drawing.Size(177, 21)
        Me.CboDocumentos.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDisplayPropietario)
        Me.GroupBox1.Controls.Add(Me.txtPropietario)
        Me.GroupBox1.Controls.Add(Me.lblPropietario)
        Me.GroupBox1.Controls.Add(Me.CboZona)
        Me.GroupBox1.Controls.Add(Me.lblDisplayZona)
        Me.GroupBox1.Controls.Add(Me.lblCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.txtCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaFinal)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblDisplayEstatus)
        Me.GroupBox1.Controls.Add(Me.CboEstatus)
        Me.GroupBox1.Controls.Add(Me.dpFechaFinal)
        Me.GroupBox1.Controls.Add(Me.dpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.LblDisplayTipoMercado)
        Me.GroupBox1.Controls.Add(Me.CboTipoMercado)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.LblDisplayDocumento)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.CboDocumentos)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.lblNombreVendedor)
        Me.GroupBox1.Controls.Add(Me.txtCodigoVendedor)
        Me.GroupBox1.Controls.Add(Me.lblDisplayVendedor)
        Me.GroupBox1.Location = New System.Drawing.Point(149, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 299)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblDisplayPropietario
        '
        Me.lblDisplayPropietario.AutoSize = True
        Me.lblDisplayPropietario.Location = New System.Drawing.Point(6, 52)
        Me.lblDisplayPropietario.Name = "lblDisplayPropietario"
        Me.lblDisplayPropietario.Size = New System.Drawing.Size(63, 13)
        Me.lblDisplayPropietario.TabIndex = 378
        Me.lblDisplayPropietario.Text = "Propietario :"
        '
        'txtPropietario
        '
        Me.txtPropietario.Location = New System.Drawing.Point(88, 49)
        Me.txtPropietario.MaxLength = 15
        Me.txtPropietario.Name = "txtPropietario"
        Me.txtPropietario.Size = New System.Drawing.Size(49, 20)
        Me.txtPropietario.TabIndex = 1
        Me.txtPropietario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPropietario
        '
        Me.lblPropietario.AutoSize = True
        Me.lblPropietario.Location = New System.Drawing.Point(143, 52)
        Me.lblPropietario.Name = "lblPropietario"
        Me.lblPropietario.Size = New System.Drawing.Size(10, 13)
        Me.lblPropietario.TabIndex = 379
        Me.lblPropietario.Text = "."
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(88, 133)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(177, 21)
        Me.CboZona.TabIndex = 4
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(6, 136)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 376
        Me.lblDisplayZona.Text = "Zona :"
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(152, 270)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(10, 13)
        Me.lblCuentaBancaria.TabIndex = 273
        Me.lblCuentaBancaria.Text = "."
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(88, 266)
        Me.txtCuentaBancaria.MaxLength = 8
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(49, 20)
        Me.txtCuentaBancaria.TabIndex = 9
        Me.txtCuentaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayCuentaBancaria
        '
        Me.lblDisplayCuentaBancaria.AutoSize = True
        Me.lblDisplayCuentaBancaria.Location = New System.Drawing.Point(6, 267)
        Me.lblDisplayCuentaBancaria.Name = "lblDisplayCuentaBancaria"
        Me.lblDisplayCuentaBancaria.Size = New System.Drawing.Size(77, 13)
        Me.lblDisplayCuentaBancaria.TabIndex = 272
        Me.lblDisplayCuentaBancaria.Text = "Cta. Bancaria :"
        '
        'LblDisplayFechaFinal
        '
        Me.LblDisplayFechaFinal.AutoSize = True
        Me.LblDisplayFechaFinal.Location = New System.Drawing.Point(6, 213)
        Me.LblDisplayFechaFinal.Name = "LblDisplayFechaFinal"
        Me.LblDisplayFechaFinal.Size = New System.Drawing.Size(41, 13)
        Me.LblDisplayFechaFinal.TabIndex = 270
        Me.LblDisplayFechaFinal.Text = "Hasta :"
        '
        'lblDisplayFechaInicio
        '
        Me.lblDisplayFechaInicio.AutoSize = True
        Me.lblDisplayFechaInicio.Location = New System.Drawing.Point(6, 191)
        Me.lblDisplayFechaInicio.Name = "lblDisplayFechaInicio"
        Me.lblDisplayFechaInicio.Size = New System.Drawing.Size(44, 13)
        Me.lblDisplayFechaInicio.TabIndex = 269
        Me.lblDisplayFechaInicio.Text = "Desde :"
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(6, 240)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayEstatus.TabIndex = 268
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"TODOS", "APLICADOS", "CANCELADOS"})
        Me.CboEstatus.Location = New System.Drawing.Point(88, 239)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(177, 21)
        Me.CboEstatus.TabIndex = 8
        '
        'dpFechaFinal
        '
        Me.dpFechaFinal.CustomFormat = "dd-MM-yyyy"
        Me.dpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaFinal.Location = New System.Drawing.Point(88, 213)
        Me.dpFechaFinal.Name = "dpFechaFinal"
        Me.dpFechaFinal.Size = New System.Drawing.Size(124, 20)
        Me.dpFechaFinal.TabIndex = 7
        '
        'dpFechaInicio
        '
        Me.dpFechaInicio.CustomFormat = "dd-MM-yyyy"
        Me.dpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaInicio.Location = New System.Drawing.Point(88, 187)
        Me.dpFechaInicio.Name = "dpFechaInicio"
        Me.dpFechaInicio.Size = New System.Drawing.Size(124, 20)
        Me.dpFechaInicio.TabIndex = 6
        '
        'LblDisplayTipoMercado
        '
        Me.LblDisplayTipoMercado.AutoSize = True
        Me.LblDisplayTipoMercado.Location = New System.Drawing.Point(6, 163)
        Me.LblDisplayTipoMercado.Name = "LblDisplayTipoMercado"
        Me.LblDisplayTipoMercado.Size = New System.Drawing.Size(78, 13)
        Me.LblDisplayTipoMercado.TabIndex = 264
        Me.LblDisplayTipoMercado.Text = "Tipo mercado :"
        '
        'CboTipoMercado
        '
        Me.CboTipoMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoMercado.FormattingEnabled = True
        Me.CboTipoMercado.Location = New System.Drawing.Point(88, 160)
        Me.CboTipoMercado.MaxLength = 1
        Me.CboTipoMercado.Name = "CboTipoMercado"
        Me.CboTipoMercado.Size = New System.Drawing.Size(177, 21)
        Me.CboTipoMercado.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbDetalleBultos)
        Me.GroupBox2.Controls.Add(Me.RdbDetalleDepositos)
        Me.GroupBox2.Controls.Add(Me.RdbDetalleCXC)
        Me.GroupBox2.Controls.Add(Me.RdbGlobalCXC)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 196)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reporte"
        '
        'rdbDetalleBultos
        '
        Me.rdbDetalleBultos.AutoSize = True
        Me.rdbDetalleBultos.Location = New System.Drawing.Point(13, 90)
        Me.rdbDetalleBultos.Name = "rdbDetalleBultos"
        Me.rdbDetalleBultos.Size = New System.Drawing.Size(95, 17)
        Me.rdbDetalleBultos.TabIndex = 267
        Me.rdbDetalleBultos.Text = "Det. dep. btos."
        Me.rdbDetalleBultos.UseVisualStyleBackColor = True
        Me.rdbDetalleBultos.Visible = False
        '
        'RdbDetalleDepositos
        '
        Me.RdbDetalleDepositos.AutoSize = True
        Me.RdbDetalleDepositos.Location = New System.Drawing.Point(13, 65)
        Me.RdbDetalleDepositos.Name = "RdbDetalleDepositos"
        Me.RdbDetalleDepositos.Size = New System.Drawing.Size(106, 17)
        Me.RdbDetalleDepositos.TabIndex = 265
        Me.RdbDetalleDepositos.Text = "Detalle depósitos"
        Me.RdbDetalleDepositos.UseVisualStyleBackColor = True
        '
        'RdbDetalleCXC
        '
        Me.RdbDetalleCXC.AutoSize = True
        Me.RdbDetalleCXC.Checked = True
        Me.RdbDetalleCXC.Location = New System.Drawing.Point(13, 42)
        Me.RdbDetalleCXC.Name = "RdbDetalleCXC"
        Me.RdbDetalleCXC.Size = New System.Drawing.Size(104, 17)
        Me.RdbDetalleCXC.TabIndex = 266
        Me.RdbDetalleCXC.TabStop = True
        Me.RdbDetalleCXC.Text = "Cobranza detalle"
        Me.RdbDetalleCXC.UseVisualStyleBackColor = True
        '
        'RdbGlobalCXC
        '
        Me.RdbGlobalCXC.AutoSize = True
        Me.RdbGlobalCXC.Location = New System.Drawing.Point(13, 19)
        Me.RdbGlobalCXC.Name = "RdbGlobalCXC"
        Me.RdbGlobalCXC.Size = New System.Drawing.Size(101, 17)
        Me.RdbGlobalCXC.TabIndex = 265
        Me.RdbGlobalCXC.Text = "Cobranza global"
        Me.RdbGlobalCXC.UseVisualStyleBackColor = True
        '
        'Rpt_CXC_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 333)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_CXC_Documentos"
        Me.Text = "Reporte de documentos de CXC."
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNombreVendedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayVendedor As System.Windows.Forms.Label
    Friend WithEvents txtCodigoVendedor As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDocumento As System.Windows.Forms.Label
    Friend WithEvents CboDocumentos As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayTipoMercado As System.Windows.Forms.Label
    Friend WithEvents CboTipoMercado As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbDetalleCXC As System.Windows.Forms.RadioButton
    Friend WithEvents RdbGlobalCXC As System.Windows.Forms.RadioButton
    Friend WithEvents RdbDetalleDepositos As System.Windows.Forms.RadioButton
    Friend WithEvents dpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents txtCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFechaFinal As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents rdbDetalleBultos As System.Windows.Forms.RadioButton
    Friend WithEvents lblDisplayPropietario As Label
    Friend WithEvents txtPropietario As TextBox
    Friend WithEvents lblPropietario As Label
End Class
