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
        Me.LblNombreUsuario = New System.Windows.Forms.Label()
        Me.txtCodigoUsuario = New System.Windows.Forms.TextBox()
        Me.lblCodigoUsuario = New System.Windows.Forms.Label()
        Me.gpFiltroFecha = New System.Windows.Forms.GroupBox()
        Me.rbtFechaServidor = New System.Windows.Forms.RadioButton()
        Me.rbtFechaDocumento = New System.Windows.Forms.RadioButton()
        Me.cboPlaza = New System.Windows.Forms.ComboBox()
        Me.LblDisplayPlaza = New System.Windows.Forms.Label()
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
        Me.gpFiltroFecha.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(745, 27)
        Me.ToolStrip1.TabIndex = 2
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
        'lblNombreVendedor
        '
        Me.lblNombreVendedor.AutoSize = True
        Me.lblNombreVendedor.Location = New System.Drawing.Point(191, 97)
        Me.lblNombreVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreVendedor.Name = "lblNombreVendedor"
        Me.lblNombreVendedor.Size = New System.Drawing.Size(12, 17)
        Me.lblNombreVendedor.TabIndex = 257
        Me.lblNombreVendedor.Text = "."
        '
        'lblDisplayVendedor
        '
        Me.lblDisplayVendedor.AutoSize = True
        Me.lblDisplayVendedor.Location = New System.Drawing.Point(8, 97)
        Me.lblDisplayVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayVendedor.Name = "lblDisplayVendedor"
        Me.lblDisplayVendedor.Size = New System.Drawing.Size(78, 17)
        Me.lblDisplayVendedor.TabIndex = 256
        Me.lblDisplayVendedor.Text = "Vendedor :"
        '
        'txtCodigoVendedor
        '
        Me.txtCodigoVendedor.Location = New System.Drawing.Point(117, 92)
        Me.txtCodigoVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoVendedor.MaxLength = 15
        Me.txtCodigoVendedor.Name = "txtCodigoVendedor"
        Me.txtCodigoVendedor.Size = New System.Drawing.Size(64, 22)
        Me.txtCodigoVendedor.TabIndex = 2
        Me.txtCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(191, 32)
        Me.lblNombreCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(12, 17)
        Me.lblNombreCliente.TabIndex = 255
        Me.lblNombreCliente.Text = "."
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(8, 32)
        Me.lblDisplayCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(59, 17)
        Me.lblDisplayCliente.TabIndex = 254
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(117, 28)
        Me.txtCodigoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoCliente.MaxLength = 15
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(64, 22)
        Me.txtCodigoCliente.TabIndex = 0
        Me.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayDocumento
        '
        Me.LblDisplayDocumento.AutoSize = True
        Me.LblDisplayDocumento.Location = New System.Drawing.Point(8, 132)
        Me.LblDisplayDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDocumento.Name = "LblDisplayDocumento"
        Me.LblDisplayDocumento.Size = New System.Drawing.Size(95, 17)
        Me.LblDisplayDocumento.TabIndex = 259
        Me.LblDisplayDocumento.Text = "Documentos :"
        '
        'CboDocumentos
        '
        Me.CboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumentos.FormattingEnabled = True
        Me.CboDocumentos.Location = New System.Drawing.Point(117, 128)
        Me.CboDocumentos.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDocumentos.MaxLength = 1
        Me.CboDocumentos.Name = "CboDocumentos"
        Me.CboDocumentos.Size = New System.Drawing.Size(235, 24)
        Me.CboDocumentos.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblNombreUsuario)
        Me.GroupBox1.Controls.Add(Me.txtCodigoUsuario)
        Me.GroupBox1.Controls.Add(Me.lblCodigoUsuario)
        Me.GroupBox1.Controls.Add(Me.gpFiltroFecha)
        Me.GroupBox1.Controls.Add(Me.cboPlaza)
        Me.GroupBox1.Controls.Add(Me.LblDisplayPlaza)
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
        Me.GroupBox1.Location = New System.Drawing.Point(199, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(531, 436)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'LblNombreUsuario
        '
        Me.LblNombreUsuario.AutoSize = True
        Me.LblNombreUsuario.Location = New System.Drawing.Point(191, 402)
        Me.LblNombreUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreUsuario.Name = "LblNombreUsuario"
        Me.LblNombreUsuario.Size = New System.Drawing.Size(12, 17)
        Me.LblNombreUsuario.TabIndex = 385
        Me.LblNombreUsuario.Text = "."
        '
        'txtCodigoUsuario
        '
        Me.txtCodigoUsuario.Location = New System.Drawing.Point(117, 399)
        Me.txtCodigoUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoUsuario.MaxLength = 8
        Me.txtCodigoUsuario.Name = "txtCodigoUsuario"
        Me.txtCodigoUsuario.Size = New System.Drawing.Size(64, 22)
        Me.txtCodigoUsuario.TabIndex = 384
        Me.txtCodigoUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigoUsuario
        '
        Me.lblCodigoUsuario.AutoSize = True
        Me.lblCodigoUsuario.Location = New System.Drawing.Point(8, 402)
        Me.lblCodigoUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoUsuario.Name = "lblCodigoUsuario"
        Me.lblCodigoUsuario.Size = New System.Drawing.Size(107, 17)
        Me.lblCodigoUsuario.TabIndex = 383
        Me.lblCodigoUsuario.Text = "Código usuario:"
        '
        'gpFiltroFecha
        '
        Me.gpFiltroFecha.Controls.Add(Me.rbtFechaServidor)
        Me.gpFiltroFecha.Controls.Add(Me.rbtFechaDocumento)
        Me.gpFiltroFecha.Location = New System.Drawing.Point(288, 276)
        Me.gpFiltroFecha.Name = "gpFiltroFecha"
        Me.gpFiltroFecha.Size = New System.Drawing.Size(236, 50)
        Me.gpFiltroFecha.TabIndex = 382
        Me.gpFiltroFecha.TabStop = False
        Me.gpFiltroFecha.Text = "Filtrar por fecha de:"
        '
        'rbtFechaServidor
        '
        Me.rbtFechaServidor.AutoSize = True
        Me.rbtFechaServidor.Location = New System.Drawing.Point(129, 22)
        Me.rbtFechaServidor.Name = "rbtFechaServidor"
        Me.rbtFechaServidor.Size = New System.Drawing.Size(82, 21)
        Me.rbtFechaServidor.TabIndex = 1
        Me.rbtFechaServidor.Text = "Servidor"
        Me.rbtFechaServidor.UseVisualStyleBackColor = True
        '
        'rbtFechaDocumento
        '
        Me.rbtFechaDocumento.AutoSize = True
        Me.rbtFechaDocumento.Checked = True
        Me.rbtFechaDocumento.Location = New System.Drawing.Point(7, 22)
        Me.rbtFechaDocumento.Name = "rbtFechaDocumento"
        Me.rbtFechaDocumento.Size = New System.Drawing.Size(101, 21)
        Me.rbtFechaDocumento.TabIndex = 0
        Me.rbtFechaDocumento.TabStop = True
        Me.rbtFechaDocumento.Text = "Documento"
        Me.rbtFechaDocumento.UseVisualStyleBackColor = True
        '
        'cboPlaza
        '
        Me.cboPlaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlaza.FormattingEnabled = True
        Me.cboPlaza.Location = New System.Drawing.Point(117, 166)
        Me.cboPlaza.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPlaza.Name = "cboPlaza"
        Me.cboPlaza.Size = New System.Drawing.Size(235, 24)
        Me.cboPlaza.TabIndex = 380
        '
        'LblDisplayPlaza
        '
        Me.LblDisplayPlaza.AutoSize = True
        Me.LblDisplayPlaza.Location = New System.Drawing.Point(8, 169)
        Me.LblDisplayPlaza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayPlaza.Name = "LblDisplayPlaza"
        Me.LblDisplayPlaza.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayPlaza.TabIndex = 381
        Me.LblDisplayPlaza.Text = "Plaza :"
        '
        'lblDisplayPropietario
        '
        Me.lblDisplayPropietario.AutoSize = True
        Me.lblDisplayPropietario.Location = New System.Drawing.Point(8, 64)
        Me.lblDisplayPropietario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPropietario.Name = "lblDisplayPropietario"
        Me.lblDisplayPropietario.Size = New System.Drawing.Size(85, 17)
        Me.lblDisplayPropietario.TabIndex = 378
        Me.lblDisplayPropietario.Text = "Propietario :"
        '
        'txtPropietario
        '
        Me.txtPropietario.Location = New System.Drawing.Point(117, 60)
        Me.txtPropietario.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPropietario.MaxLength = 15
        Me.txtPropietario.Name = "txtPropietario"
        Me.txtPropietario.Size = New System.Drawing.Size(64, 22)
        Me.txtPropietario.TabIndex = 1
        Me.txtPropietario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPropietario
        '
        Me.lblPropietario.AutoSize = True
        Me.lblPropietario.Location = New System.Drawing.Point(191, 64)
        Me.lblPropietario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPropietario.Name = "lblPropietario"
        Me.lblPropietario.Size = New System.Drawing.Size(12, 17)
        Me.lblPropietario.TabIndex = 379
        Me.lblPropietario.Text = "."
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(117, 202)
        Me.CboZona.Margin = New System.Windows.Forms.Padding(4)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(235, 24)
        Me.CboZona.TabIndex = 4
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(8, 205)
        Me.lblDisplayZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(49, 17)
        Me.lblDisplayZona.TabIndex = 376
        Me.lblDisplayZona.Text = "Zona :"
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.AutoSize = True
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(191, 372)
        Me.lblCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(12, 17)
        Me.lblCuentaBancaria.TabIndex = 273
        Me.lblCuentaBancaria.Text = "."
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(117, 369)
        Me.txtCuentaBancaria.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaBancaria.MaxLength = 8
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(64, 22)
        Me.txtCuentaBancaria.TabIndex = 9
        Me.txtCuentaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayCuentaBancaria
        '
        Me.lblDisplayCuentaBancaria.AutoSize = True
        Me.lblDisplayCuentaBancaria.Location = New System.Drawing.Point(8, 371)
        Me.lblDisplayCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaBancaria.Name = "lblDisplayCuentaBancaria"
        Me.lblDisplayCuentaBancaria.Size = New System.Drawing.Size(101, 17)
        Me.lblDisplayCuentaBancaria.TabIndex = 272
        Me.lblDisplayCuentaBancaria.Text = "Cta. Bancaria :"
        '
        'LblDisplayFechaFinal
        '
        Me.LblDisplayFechaFinal.AutoSize = True
        Me.LblDisplayFechaFinal.Location = New System.Drawing.Point(8, 304)
        Me.LblDisplayFechaFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFechaFinal.Name = "LblDisplayFechaFinal"
        Me.LblDisplayFechaFinal.Size = New System.Drawing.Size(53, 17)
        Me.LblDisplayFechaFinal.TabIndex = 270
        Me.LblDisplayFechaFinal.Text = "Hasta :"
        '
        'lblDisplayFechaInicio
        '
        Me.lblDisplayFechaInicio.AutoSize = True
        Me.lblDisplayFechaInicio.Location = New System.Drawing.Point(8, 277)
        Me.lblDisplayFechaInicio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaInicio.Name = "lblDisplayFechaInicio"
        Me.lblDisplayFechaInicio.Size = New System.Drawing.Size(57, 17)
        Me.lblDisplayFechaInicio.TabIndex = 269
        Me.lblDisplayFechaInicio.Text = "Desde :"
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(8, 337)
        Me.lblDisplayEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayEstatus.TabIndex = 268
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"TODOS", "APLICADOS", "CANCELADOS"})
        Me.CboEstatus.Location = New System.Drawing.Point(117, 336)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(235, 24)
        Me.CboEstatus.TabIndex = 8
        '
        'dpFechaFinal
        '
        Me.dpFechaFinal.CustomFormat = "dd-MM-yyyy"
        Me.dpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaFinal.Location = New System.Drawing.Point(117, 304)
        Me.dpFechaFinal.Margin = New System.Windows.Forms.Padding(4)
        Me.dpFechaFinal.Name = "dpFechaFinal"
        Me.dpFechaFinal.Size = New System.Drawing.Size(164, 22)
        Me.dpFechaFinal.TabIndex = 7
        '
        'dpFechaInicio
        '
        Me.dpFechaInicio.CustomFormat = "dd-MM-yyyy"
        Me.dpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaInicio.Location = New System.Drawing.Point(117, 272)
        Me.dpFechaInicio.Margin = New System.Windows.Forms.Padding(4)
        Me.dpFechaInicio.Name = "dpFechaInicio"
        Me.dpFechaInicio.Size = New System.Drawing.Size(164, 22)
        Me.dpFechaInicio.TabIndex = 6
        '
        'LblDisplayTipoMercado
        '
        Me.LblDisplayTipoMercado.AutoSize = True
        Me.LblDisplayTipoMercado.Location = New System.Drawing.Point(8, 243)
        Me.LblDisplayTipoMercado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTipoMercado.Name = "LblDisplayTipoMercado"
        Me.LblDisplayTipoMercado.Size = New System.Drawing.Size(103, 17)
        Me.LblDisplayTipoMercado.TabIndex = 264
        Me.LblDisplayTipoMercado.Text = "Tipo mercado :"
        '
        'CboTipoMercado
        '
        Me.CboTipoMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoMercado.FormattingEnabled = True
        Me.CboTipoMercado.Location = New System.Drawing.Point(117, 239)
        Me.CboTipoMercado.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoMercado.MaxLength = 1
        Me.CboTipoMercado.Name = "CboTipoMercado"
        Me.CboTipoMercado.Size = New System.Drawing.Size(235, 24)
        Me.CboTipoMercado.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbDetalleBultos)
        Me.GroupBox2.Controls.Add(Me.RdbDetalleDepositos)
        Me.GroupBox2.Controls.Add(Me.RdbDetalleCXC)
        Me.GroupBox2.Controls.Add(Me.RdbGlobalCXC)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 34)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(181, 241)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reporte"
        '
        'rdbDetalleBultos
        '
        Me.rdbDetalleBultos.AutoSize = True
        Me.rdbDetalleBultos.Location = New System.Drawing.Point(17, 111)
        Me.rdbDetalleBultos.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbDetalleBultos.Name = "rdbDetalleBultos"
        Me.rdbDetalleBultos.Size = New System.Drawing.Size(122, 21)
        Me.rdbDetalleBultos.TabIndex = 267
        Me.rdbDetalleBultos.Text = "Det. dep. btos."
        Me.rdbDetalleBultos.UseVisualStyleBackColor = True
        Me.rdbDetalleBultos.Visible = False
        '
        'RdbDetalleDepositos
        '
        Me.RdbDetalleDepositos.AutoSize = True
        Me.RdbDetalleDepositos.Location = New System.Drawing.Point(17, 80)
        Me.RdbDetalleDepositos.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbDetalleDepositos.Name = "RdbDetalleDepositos"
        Me.RdbDetalleDepositos.Size = New System.Drawing.Size(138, 21)
        Me.RdbDetalleDepositos.TabIndex = 265
        Me.RdbDetalleDepositos.Text = "Detalle depósitos"
        Me.RdbDetalleDepositos.UseVisualStyleBackColor = True
        '
        'RdbDetalleCXC
        '
        Me.RdbDetalleCXC.AutoSize = True
        Me.RdbDetalleCXC.Checked = True
        Me.RdbDetalleCXC.Location = New System.Drawing.Point(17, 52)
        Me.RdbDetalleCXC.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbDetalleCXC.Name = "RdbDetalleCXC"
        Me.RdbDetalleCXC.Size = New System.Drawing.Size(136, 21)
        Me.RdbDetalleCXC.TabIndex = 266
        Me.RdbDetalleCXC.TabStop = True
        Me.RdbDetalleCXC.Text = "Cobranza detalle"
        Me.RdbDetalleCXC.UseVisualStyleBackColor = True
        '
        'RdbGlobalCXC
        '
        Me.RdbGlobalCXC.AutoSize = True
        Me.RdbGlobalCXC.Location = New System.Drawing.Point(17, 23)
        Me.RdbGlobalCXC.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbGlobalCXC.Name = "RdbGlobalCXC"
        Me.RdbGlobalCXC.Size = New System.Drawing.Size(132, 21)
        Me.RdbGlobalCXC.TabIndex = 265
        Me.RdbGlobalCXC.Text = "Cobranza global"
        Me.RdbGlobalCXC.UseVisualStyleBackColor = True
        '
        'Rpt_CXC_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 477)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_CXC_Documentos"
        Me.Text = "Reporte de documentos de CXC."
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpFiltroFecha.ResumeLayout(False)
        Me.gpFiltroFecha.PerformLayout()
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
    Friend WithEvents cboPlaza As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayPlaza As System.Windows.Forms.Label
    Friend WithEvents gpFiltroFecha As System.Windows.Forms.GroupBox
    Friend WithEvents rbtFechaServidor As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFechaDocumento As System.Windows.Forms.RadioButton
    Friend WithEvents LblNombreUsuario As System.Windows.Forms.Label
    Friend WithEvents txtCodigoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoUsuario As System.Windows.Forms.Label
End Class
