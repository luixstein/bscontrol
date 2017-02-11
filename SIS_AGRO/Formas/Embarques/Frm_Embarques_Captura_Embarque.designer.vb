<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_Captura_Embarque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_Captura_Embarque))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirEtiquetasPalets = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbGenerarTxtEnvio = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboEmpaque = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFolioFactura = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioFactura = New System.Windows.Forms.Label()
        Me.btnGrabarFolioPedimento = New System.Windows.Forms.Button()
        Me.txtFolioPedimento = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioPedimento = New System.Windows.Forms.Label()
        Me.lblFolioEntradaAlmacen = New System.Windows.Forms.Label()
        Me.cboAlmacen = New System.Windows.Forms.ComboBox()
        Me.lblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.txtFleteImporte = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombreChofer = New System.Windows.Forms.Label()
        Me.TxtChofer = New System.Windows.Forms.TextBox()
        Me.LblDisplayFacturado = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.lblDisplayEstado = New System.Windows.Forms.Label()
        Me.btnEmbarqueSiguiente = New System.Windows.Forms.Button()
        Me.btnEmbarqueAnterior = New System.Windows.Forms.Button()
        Me.BtnGeneraSalida = New System.Windows.Forms.Button()
        Me.BtnGeneraFlete = New System.Windows.Forms.Button()
        Me.CboLugarEntrega = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEmbarqueAdicional = New System.Windows.Forms.Button()
        Me.txtFolioViaje = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioViaje = New System.Windows.Forms.Label()
        Me.TxtMarca = New System.Windows.Forms.TextBox()
        Me.cboDocumento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.lblChofer = New System.Windows.Forms.Label()
        Me.TxtSellos = New System.Windows.Forms.TextBox()
        Me.lblSellos = New System.Windows.Forms.Label()
        Me.TxtTemperatura = New System.Windows.Forms.TextBox()
        Me.lblTemperatura = New System.Windows.Forms.Label()
        Me.lblNombrelblAduanaNacional = New System.Windows.Forms.Label()
        Me.TxtAduanaNacional = New System.Windows.Forms.TextBox()
        Me.lblAduanaNacional = New System.Windows.Forms.Label()
        Me.TxtPlacasCaja = New System.Windows.Forms.TextBox()
        Me.lblPlacasCaja = New System.Windows.Forms.Label()
        Me.TxtPlacas = New System.Windows.Forms.TextBox()
        Me.TxtModelo = New System.Windows.Forms.TextBox()
        Me.lblNombreCaja = New System.Windows.Forms.Label()
        Me.lblNombrelblAduanaExtranjera = New System.Windows.Forms.Label()
        Me.TxtAduanaExtranjera = New System.Windows.Forms.TextBox()
        Me.lblAduanaExtranjera = New System.Windows.Forms.Label()
        Me.CboDistribuidor = New System.Windows.Forms.ComboBox()
        Me.lblDistribuidor = New System.Windows.Forms.Label()
        Me.DtpFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaSalida = New System.Windows.Forms.Label()
        Me.txtCaja = New System.Windows.Forms.TextBox()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.txtLinea = New System.Windows.Forms.TextBox()
        Me.lblLineaTransporte = New System.Windows.Forms.Label()
        Me.txtCodigoTransporte = New System.Windows.Forms.TextBox()
        Me.lblTransporte = New System.Windows.Forms.Label()
        Me.txtFolioEmbarque = New System.Windows.Forms.TextBox()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.LblDisplayDireccionEmpresa = New System.Windows.Forms.Label()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtFolioAARC = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioAARC = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.CboEmbarcador = New System.Windows.Forms.ComboBox()
        Me.lblEmbarcador = New System.Windows.Forms.Label()
        Me.LblDisplayFolioEmbarque = New System.Windows.Forms.Label()
        Me.gbGrid = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.txtTotalBultos = New System.Windows.Forms.MaskedTextBox()
        Me.TxtTotalImporte = New System.Windows.Forms.MaskedTextBox()
        Me.TxtTotalPeso = New System.Windows.Forms.MaskedTextBox()
        Me.lblTotales = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnConsultarSalida = New System.Windows.Forms.Button()
        Me.btnCambiarPrecios = New System.Windows.Forms.Button()
        Me.btnCancelarFactura = New System.Windows.Forms.Button()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbGrid.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbImprimirEtiquetasPalets, Me.tsbSalir, Me.tsbGenerarTxtEnvio})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1012, 25)
        Me.tsMenu.TabIndex = 2
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
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 22)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbImprimirEtiquetasPalets
        '
        Me.tsbImprimirEtiquetasPalets.Image = CType(resources.GetObject("tsbImprimirEtiquetasPalets.Image"), System.Drawing.Image)
        Me.tsbImprimirEtiquetasPalets.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirEtiquetasPalets.Name = "tsbImprimirEtiquetasPalets"
        Me.tsbImprimirEtiquetasPalets.Size = New System.Drawing.Size(133, 22)
        Me.tsbImprimirEtiquetasPalets.Text = "&Imp etiquetas palets"
        Me.tsbImprimirEtiquetasPalets.ToolTipText = "Imprimir etiquetas palets"
        Me.tsbImprimirEtiquetasPalets.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbGenerarTxtEnvio
        '
        Me.tsbGenerarTxtEnvio.Image = CType(resources.GetObject("tsbGenerarTxtEnvio.Image"), System.Drawing.Image)
        Me.tsbGenerarTxtEnvio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGenerarTxtEnvio.Name = "tsbGenerarTxtEnvio"
        Me.tsbGenerarTxtEnvio.Size = New System.Drawing.Size(116, 22)
        Me.tsbGenerarTxtEnvio.Text = "Generar txt envío"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboEmpaque)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFolioFactura)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFolioFactura)
        Me.GroupBox1.Controls.Add(Me.btnGrabarFolioPedimento)
        Me.GroupBox1.Controls.Add(Me.txtFolioPedimento)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFolioPedimento)
        Me.GroupBox1.Controls.Add(Me.lblFolioEntradaAlmacen)
        Me.GroupBox1.Controls.Add(Me.cboAlmacen)
        Me.GroupBox1.Controls.Add(Me.lblDisplayAlmacen)
        Me.GroupBox1.Controls.Add(Me.txtFleteImporte)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblNombreChofer)
        Me.GroupBox1.Controls.Add(Me.TxtChofer)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFacturado)
        Me.GroupBox1.Controls.Add(Me.cboEstado)
        Me.GroupBox1.Controls.Add(Me.lblDisplayEstado)
        Me.GroupBox1.Controls.Add(Me.btnEmbarqueSiguiente)
        Me.GroupBox1.Controls.Add(Me.btnEmbarqueAnterior)
        Me.GroupBox1.Controls.Add(Me.BtnGeneraSalida)
        Me.GroupBox1.Controls.Add(Me.BtnGeneraFlete)
        Me.GroupBox1.Controls.Add(Me.CboLugarEntrega)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnEmbarqueAdicional)
        Me.GroupBox1.Controls.Add(Me.txtFolioViaje)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFolioViaje)
        Me.GroupBox1.Controls.Add(Me.TxtMarca)
        Me.GroupBox1.Controls.Add(Me.cboDocumento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblStatus)
        Me.GroupBox1.Controls.Add(Me.lblDisplayStatus)
        Me.GroupBox1.Controls.Add(Me.lblChofer)
        Me.GroupBox1.Controls.Add(Me.TxtSellos)
        Me.GroupBox1.Controls.Add(Me.lblSellos)
        Me.GroupBox1.Controls.Add(Me.TxtTemperatura)
        Me.GroupBox1.Controls.Add(Me.lblTemperatura)
        Me.GroupBox1.Controls.Add(Me.lblNombrelblAduanaNacional)
        Me.GroupBox1.Controls.Add(Me.TxtAduanaNacional)
        Me.GroupBox1.Controls.Add(Me.lblAduanaNacional)
        Me.GroupBox1.Controls.Add(Me.TxtPlacasCaja)
        Me.GroupBox1.Controls.Add(Me.lblPlacasCaja)
        Me.GroupBox1.Controls.Add(Me.TxtPlacas)
        Me.GroupBox1.Controls.Add(Me.TxtModelo)
        Me.GroupBox1.Controls.Add(Me.lblNombreCaja)
        Me.GroupBox1.Controls.Add(Me.lblNombrelblAduanaExtranjera)
        Me.GroupBox1.Controls.Add(Me.TxtAduanaExtranjera)
        Me.GroupBox1.Controls.Add(Me.lblAduanaExtranjera)
        Me.GroupBox1.Controls.Add(Me.CboDistribuidor)
        Me.GroupBox1.Controls.Add(Me.lblDistribuidor)
        Me.GroupBox1.Controls.Add(Me.DtpFechaSalida)
        Me.GroupBox1.Controls.Add(Me.lblFechaSalida)
        Me.GroupBox1.Controls.Add(Me.txtCaja)
        Me.GroupBox1.Controls.Add(Me.lblCaja)
        Me.GroupBox1.Controls.Add(Me.txtLinea)
        Me.GroupBox1.Controls.Add(Me.lblLineaTransporte)
        Me.GroupBox1.Controls.Add(Me.txtCodigoTransporte)
        Me.GroupBox1.Controls.Add(Me.lblTransporte)
        Me.GroupBox1.Controls.Add(Me.txtFolioEmbarque)
        Me.GroupBox1.Controls.Add(Me.dtpFechaEntrega)
        Me.GroupBox1.Controls.Add(Me.lblFechaEntrega)
        Me.GroupBox1.Controls.Add(Me.LblDisplayDireccionEmpresa)
        Me.GroupBox1.Controls.Add(Me.TxtObservaciones)
        Me.GroupBox1.Controls.Add(Me.txtFolioAARC)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFolioAARC)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.DtpFecha)
        Me.GroupBox1.Controls.Add(Me.LblFecha)
        Me.GroupBox1.Controls.Add(Me.CboEmbarcador)
        Me.GroupBox1.Controls.Add(Me.lblEmbarcador)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFolioEmbarque)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 611)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboEmpaque
        '
        Me.cboEmpaque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpaque.FormattingEnabled = True
        Me.cboEmpaque.Location = New System.Drawing.Point(99, 503)
        Me.cboEmpaque.MaxLength = 80
        Me.cboEmpaque.Name = "cboEmpaque"
        Me.cboEmpaque.Size = New System.Drawing.Size(222, 21)
        Me.cboEmpaque.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 507)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 386
        Me.Label4.Text = "Empaque :"
        '
        'txtFolioFactura
        '
        Me.txtFolioFactura.Enabled = False
        Me.txtFolioFactura.Location = New System.Drawing.Point(99, 583)
        Me.txtFolioFactura.MaxLength = 3
        Me.txtFolioFactura.Name = "txtFolioFactura"
        Me.txtFolioFactura.ReadOnly = True
        Me.txtFolioFactura.Size = New System.Drawing.Size(81, 20)
        Me.txtFolioFactura.TabIndex = 23
        Me.txtFolioFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayFolioFactura
        '
        Me.lblDisplayFolioFactura.AutoSize = True
        Me.lblDisplayFolioFactura.Location = New System.Drawing.Point(6, 587)
        Me.lblDisplayFolioFactura.Name = "lblDisplayFolioFactura"
        Me.lblDisplayFolioFactura.Size = New System.Drawing.Size(71, 13)
        Me.lblDisplayFolioFactura.TabIndex = 384
        Me.lblDisplayFolioFactura.Text = "Folio factura :"
        '
        'btnGrabarFolioPedimento
        '
        Me.btnGrabarFolioPedimento.Location = New System.Drawing.Point(367, 583)
        Me.btnGrabarFolioPedimento.Name = "btnGrabarFolioPedimento"
        Me.btnGrabarFolioPedimento.Size = New System.Drawing.Size(76, 23)
        Me.btnGrabarFolioPedimento.TabIndex = 24
        Me.btnGrabarFolioPedimento.Text = "Grabar folio ped."
        Me.btnGrabarFolioPedimento.UseVisualStyleBackColor = True
        Me.btnGrabarFolioPedimento.Visible = False
        '
        'txtFolioPedimento
        '
        Me.txtFolioPedimento.Location = New System.Drawing.Point(251, 584)
        Me.txtFolioPedimento.MaxLength = 15
        Me.txtFolioPedimento.Name = "txtFolioPedimento"
        Me.txtFolioPedimento.Size = New System.Drawing.Size(110, 20)
        Me.txtFolioPedimento.TabIndex = 24
        Me.txtFolioPedimento.Visible = False
        '
        'lblDisplayFolioPedimento
        '
        Me.lblDisplayFolioPedimento.AutoSize = True
        Me.lblDisplayFolioPedimento.Location = New System.Drawing.Point(186, 586)
        Me.lblDisplayFolioPedimento.Name = "lblDisplayFolioPedimento"
        Me.lblDisplayFolioPedimento.Size = New System.Drawing.Size(63, 13)
        Me.lblDisplayFolioPedimento.TabIndex = 383
        Me.lblDisplayFolioPedimento.Text = "Pedimento :"
        Me.lblDisplayFolioPedimento.Visible = False
        '
        'lblFolioEntradaAlmacen
        '
        Me.lblFolioEntradaAlmacen.AutoSize = True
        Me.lblFolioEntradaAlmacen.Location = New System.Drawing.Point(327, 479)
        Me.lblFolioEntradaAlmacen.Name = "lblFolioEntradaAlmacen"
        Me.lblFolioEntradaAlmacen.Size = New System.Drawing.Size(13, 13)
        Me.lblFolioEntradaAlmacen.TabIndex = 380
        Me.lblFolioEntradaAlmacen.Text = "_"
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.FormattingEnabled = True
        Me.cboAlmacen.Items.AddRange(New Object() {"A", "B"})
        Me.cboAlmacen.Location = New System.Drawing.Point(99, 476)
        Me.cboAlmacen.MaxLength = 80
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(222, 21)
        Me.cboAlmacen.TabIndex = 20
        '
        'lblDisplayAlmacen
        '
        Me.lblDisplayAlmacen.AutoSize = True
        Me.lblDisplayAlmacen.Location = New System.Drawing.Point(6, 479)
        Me.lblDisplayAlmacen.Name = "lblDisplayAlmacen"
        Me.lblDisplayAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayAlmacen.TabIndex = 379
        Me.lblDisplayAlmacen.Text = "Almacén :"
        '
        'txtFleteImporte
        '
        Me.txtFleteImporte.Location = New System.Drawing.Point(346, 423)
        Me.txtFleteImporte.MaxLength = 8
        Me.txtFleteImporte.Name = "txtFleteImporte"
        Me.txtFleteImporte.Size = New System.Drawing.Size(97, 20)
        Me.txtFleteImporte.TabIndex = 22
        Me.txtFleteImporte.Text = "0.00"
        Me.txtFleteImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(310, 426)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 377
        Me.Label3.Text = "Flete :"
        '
        'lblNombreChofer
        '
        Me.lblNombreChofer.Location = New System.Drawing.Point(175, 325)
        Me.lblNombreChofer.Name = "lblNombreChofer"
        Me.lblNombreChofer.Size = New System.Drawing.Size(231, 13)
        Me.lblNombreChofer.TabIndex = 375
        Me.lblNombreChofer.Text = "_"
        '
        'TxtChofer
        '
        Me.TxtChofer.Location = New System.Drawing.Point(99, 322)
        Me.TxtChofer.MaxLength = 80
        Me.TxtChofer.Name = "TxtChofer"
        Me.TxtChofer.Size = New System.Drawing.Size(69, 20)
        Me.TxtChofer.TabIndex = 14
        '
        'LblDisplayFacturado
        '
        Me.LblDisplayFacturado.AutoSize = True
        Me.LblDisplayFacturado.Location = New System.Drawing.Point(257, 427)
        Me.LblDisplayFacturado.Name = "LblDisplayFacturado"
        Me.LblDisplayFacturado.Size = New System.Drawing.Size(0, 13)
        Me.LblDisplayFacturado.TabIndex = 373
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstado.Location = New System.Drawing.Point(99, 449)
        Me.cboEstado.MaxLength = 80
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(222, 21)
        Me.cboEstado.TabIndex = 19
        '
        'lblDisplayEstado
        '
        Me.lblDisplayEstado.AutoSize = True
        Me.lblDisplayEstado.Location = New System.Drawing.Point(6, 452)
        Me.lblDisplayEstado.Name = "lblDisplayEstado"
        Me.lblDisplayEstado.Size = New System.Drawing.Size(49, 13)
        Me.lblDisplayEstado.TabIndex = 372
        Me.lblDisplayEstado.Text = "Destino :"
        '
        'btnEmbarqueSiguiente
        '
        Me.btnEmbarqueSiguiente.Location = New System.Drawing.Point(237, 43)
        Me.btnEmbarqueSiguiente.Name = "btnEmbarqueSiguiente"
        Me.btnEmbarqueSiguiente.Size = New System.Drawing.Size(37, 21)
        Me.btnEmbarqueSiguiente.TabIndex = 370
        Me.btnEmbarqueSiguiente.Text = ">>"
        Me.btnEmbarqueSiguiente.UseVisualStyleBackColor = True
        '
        'btnEmbarqueAnterior
        '
        Me.btnEmbarqueAnterior.Location = New System.Drawing.Point(194, 43)
        Me.btnEmbarqueAnterior.Name = "btnEmbarqueAnterior"
        Me.btnEmbarqueAnterior.Size = New System.Drawing.Size(37, 21)
        Me.btnEmbarqueAnterior.TabIndex = 369
        Me.btnEmbarqueAnterior.Text = "<<"
        Me.btnEmbarqueAnterior.UseVisualStyleBackColor = True
        '
        'BtnGeneraSalida
        '
        Me.BtnGeneraSalida.Location = New System.Drawing.Point(254, 93)
        Me.BtnGeneraSalida.Name = "BtnGeneraSalida"
        Me.BtnGeneraSalida.Size = New System.Drawing.Size(152, 23)
        Me.BtnGeneraSalida.TabIndex = 5
        Me.BtnGeneraSalida.Text = "Generar salida"
        Me.BtnGeneraSalida.UseVisualStyleBackColor = True
        '
        'BtnGeneraFlete
        '
        Me.BtnGeneraFlete.Location = New System.Drawing.Point(99, 93)
        Me.BtnGeneraFlete.Name = "BtnGeneraFlete"
        Me.BtnGeneraFlete.Size = New System.Drawing.Size(152, 23)
        Me.BtnGeneraFlete.TabIndex = 4
        Me.BtnGeneraFlete.Text = "Generar flete"
        Me.BtnGeneraFlete.UseVisualStyleBackColor = True
        '
        'CboLugarEntrega
        '
        Me.CboLugarEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLugarEntrega.FormattingEnabled = True
        Me.CboLugarEntrega.Location = New System.Drawing.Point(99, 423)
        Me.CboLugarEntrega.Name = "CboLugarEntrega"
        Me.CboLugarEntrega.Size = New System.Drawing.Size(205, 21)
        Me.CboLugarEntrega.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 427)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 361
        Me.Label2.Text = "Lugar de entrega:"
        '
        'btnEmbarqueAdicional
        '
        Me.btnEmbarqueAdicional.Location = New System.Drawing.Point(280, 43)
        Me.btnEmbarqueAdicional.Name = "btnEmbarqueAdicional"
        Me.btnEmbarqueAdicional.Size = New System.Drawing.Size(152, 23)
        Me.btnEmbarqueAdicional.TabIndex = 359
        Me.btnEmbarqueAdicional.Text = "Embarque adicional"
        Me.btnEmbarqueAdicional.UseVisualStyleBackColor = True
        '
        'txtFolioViaje
        '
        Me.txtFolioViaje.Location = New System.Drawing.Point(99, 44)
        Me.txtFolioViaje.MaxLength = 15
        Me.txtFolioViaje.Name = "txtFolioViaje"
        Me.txtFolioViaje.Size = New System.Drawing.Size(89, 20)
        Me.txtFolioViaje.TabIndex = 1
        '
        'lblDisplayFolioViaje
        '
        Me.lblDisplayFolioViaje.AutoSize = True
        Me.lblDisplayFolioViaje.Location = New System.Drawing.Point(6, 48)
        Me.lblDisplayFolioViaje.Name = "lblDisplayFolioViaje"
        Me.lblDisplayFolioViaje.Size = New System.Drawing.Size(60, 13)
        Me.lblDisplayFolioViaje.TabIndex = 358
        Me.lblDisplayFolioViaje.Text = "Folio viaje :"
        '
        'TxtMarca
        '
        Me.TxtMarca.Enabled = False
        Me.TxtMarca.Location = New System.Drawing.Point(151, 197)
        Me.TxtMarca.MaxLength = 80
        Me.TxtMarca.Name = "TxtMarca"
        Me.TxtMarca.Size = New System.Drawing.Size(123, 20)
        Me.TxtMarca.TabIndex = 356
        '
        'cboDocumento
        '
        Me.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumento.FormattingEnabled = True
        Me.cboDocumento.Location = New System.Drawing.Point(99, 18)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(166, 21)
        Me.cboDocumento.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 355
        Me.Label1.Text = "Documento  :"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(311, 402)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(10, 13)
        Me.LblStatus.TabIndex = 353
        Me.LblStatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(248, 402)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 352
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'lblChofer
        '
        Me.lblChofer.AutoSize = True
        Me.lblChofer.Location = New System.Drawing.Point(6, 326)
        Me.lblChofer.Name = "lblChofer"
        Me.lblChofer.Size = New System.Drawing.Size(44, 13)
        Me.lblChofer.TabIndex = 351
        Me.lblChofer.Text = "Chofer :"
        '
        'TxtSellos
        '
        Me.TxtSellos.Location = New System.Drawing.Point(293, 373)
        Me.TxtSellos.MaxLength = 30
        Me.TxtSellos.Name = "TxtSellos"
        Me.TxtSellos.Size = New System.Drawing.Size(113, 20)
        Me.TxtSellos.TabIndex = 21
        Me.TxtSellos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSellos
        '
        Me.lblSellos.AutoSize = True
        Me.lblSellos.Location = New System.Drawing.Point(248, 377)
        Me.lblSellos.Name = "lblSellos"
        Me.lblSellos.Size = New System.Drawing.Size(41, 13)
        Me.lblSellos.TabIndex = 349
        Me.lblSellos.Text = "Sellos :"
        '
        'TxtTemperatura
        '
        Me.TxtTemperatura.Location = New System.Drawing.Point(337, 348)
        Me.TxtTemperatura.MaxLength = 3
        Me.TxtTemperatura.Name = "TxtTemperatura"
        Me.TxtTemperatura.Size = New System.Drawing.Size(69, 20)
        Me.TxtTemperatura.TabIndex = 20
        Me.TxtTemperatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTemperatura
        '
        Me.lblTemperatura.AutoSize = True
        Me.lblTemperatura.Location = New System.Drawing.Point(248, 351)
        Me.lblTemperatura.Name = "lblTemperatura"
        Me.lblTemperatura.Size = New System.Drawing.Size(73, 13)
        Me.lblTemperatura.TabIndex = 347
        Me.lblTemperatura.Text = "Temperatura :"
        '
        'lblNombrelblAduanaNacional
        '
        Me.lblNombrelblAduanaNacional.Location = New System.Drawing.Point(175, 301)
        Me.lblNombrelblAduanaNacional.Name = "lblNombrelblAduanaNacional"
        Me.lblNombrelblAduanaNacional.Size = New System.Drawing.Size(231, 13)
        Me.lblNombrelblAduanaNacional.TabIndex = 345
        Me.lblNombrelblAduanaNacional.Text = "_"
        '
        'TxtAduanaNacional
        '
        Me.TxtAduanaNacional.Location = New System.Drawing.Point(99, 297)
        Me.TxtAduanaNacional.MaxLength = 8
        Me.TxtAduanaNacional.Name = "TxtAduanaNacional"
        Me.TxtAduanaNacional.Size = New System.Drawing.Size(69, 20)
        Me.TxtAduanaNacional.TabIndex = 13
        Me.TxtAduanaNacional.Text = "  "
        '
        'lblAduanaNacional
        '
        Me.lblAduanaNacional.AutoSize = True
        Me.lblAduanaNacional.Location = New System.Drawing.Point(6, 301)
        Me.lblAduanaNacional.Name = "lblAduanaNacional"
        Me.lblAduanaNacional.Size = New System.Drawing.Size(76, 13)
        Me.lblAduanaNacional.TabIndex = 344
        Me.lblAduanaNacional.Text = "Aduana Nac. :"
        '
        'TxtPlacasCaja
        '
        Me.TxtPlacasCaja.Enabled = False
        Me.TxtPlacasCaja.Location = New System.Drawing.Point(337, 247)
        Me.TxtPlacasCaja.MaxLength = 3
        Me.TxtPlacasCaja.Name = "TxtPlacasCaja"
        Me.TxtPlacasCaja.Size = New System.Drawing.Size(106, 20)
        Me.TxtPlacasCaja.TabIndex = 341
        Me.TxtPlacasCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPlacasCaja
        '
        Me.lblPlacasCaja.AutoSize = True
        Me.lblPlacasCaja.Location = New System.Drawing.Point(285, 251)
        Me.lblPlacasCaja.Name = "lblPlacasCaja"
        Me.lblPlacasCaja.Size = New System.Drawing.Size(45, 13)
        Me.lblPlacasCaja.TabIndex = 342
        Me.lblPlacasCaja.Text = "Placas :"
        '
        'TxtPlacas
        '
        Me.TxtPlacas.Enabled = False
        Me.TxtPlacas.Location = New System.Drawing.Point(337, 197)
        Me.TxtPlacas.MaxLength = 3
        Me.TxtPlacas.Name = "TxtPlacas"
        Me.TxtPlacas.Size = New System.Drawing.Size(69, 20)
        Me.TxtPlacas.TabIndex = 339
        Me.TxtPlacas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtModelo
        '
        Me.TxtModelo.Enabled = False
        Me.TxtModelo.Location = New System.Drawing.Point(280, 197)
        Me.TxtModelo.MaxLength = 80
        Me.TxtModelo.Name = "TxtModelo"
        Me.TxtModelo.Size = New System.Drawing.Size(47, 20)
        Me.TxtModelo.TabIndex = 338
        '
        'lblNombreCaja
        '
        Me.lblNombreCaja.Location = New System.Drawing.Point(175, 251)
        Me.lblNombreCaja.Name = "lblNombreCaja"
        Me.lblNombreCaja.Size = New System.Drawing.Size(94, 13)
        Me.lblNombreCaja.TabIndex = 336
        Me.lblNombreCaja.Text = "_"
        '
        'lblNombrelblAduanaExtranjera
        '
        Me.lblNombrelblAduanaExtranjera.Location = New System.Drawing.Point(175, 276)
        Me.lblNombrelblAduanaExtranjera.Name = "lblNombrelblAduanaExtranjera"
        Me.lblNombrelblAduanaExtranjera.Size = New System.Drawing.Size(231, 13)
        Me.lblNombrelblAduanaExtranjera.TabIndex = 335
        Me.lblNombrelblAduanaExtranjera.Text = "_"
        '
        'TxtAduanaExtranjera
        '
        Me.TxtAduanaExtranjera.Location = New System.Drawing.Point(99, 272)
        Me.TxtAduanaExtranjera.MaxLength = 8
        Me.TxtAduanaExtranjera.Name = "TxtAduanaExtranjera"
        Me.TxtAduanaExtranjera.Size = New System.Drawing.Size(69, 20)
        Me.TxtAduanaExtranjera.TabIndex = 12
        Me.TxtAduanaExtranjera.Text = "  "
        '
        'lblAduanaExtranjera
        '
        Me.lblAduanaExtranjera.AutoSize = True
        Me.lblAduanaExtranjera.Location = New System.Drawing.Point(6, 276)
        Me.lblAduanaExtranjera.Name = "lblAduanaExtranjera"
        Me.lblAduanaExtranjera.Size = New System.Drawing.Size(71, 13)
        Me.lblAduanaExtranjera.TabIndex = 334
        Me.lblAduanaExtranjera.Text = "Aduana Ext. :"
        '
        'CboDistribuidor
        '
        Me.CboDistribuidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDistribuidor.FormattingEnabled = True
        Me.CboDistribuidor.Location = New System.Drawing.Point(99, 119)
        Me.CboDistribuidor.Name = "CboDistribuidor"
        Me.CboDistribuidor.Size = New System.Drawing.Size(344, 21)
        Me.CboDistribuidor.TabIndex = 6
        '
        'lblDistribuidor
        '
        Me.lblDistribuidor.AutoSize = True
        Me.lblDistribuidor.Location = New System.Drawing.Point(6, 123)
        Me.lblDistribuidor.Name = "lblDistribuidor"
        Me.lblDistribuidor.Size = New System.Drawing.Size(63, 13)
        Me.lblDistribuidor.TabIndex = 330
        Me.lblDistribuidor.Text = "Importador :"
        '
        'DtpFechaSalida
        '
        Me.DtpFechaSalida.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.DtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaSalida.Location = New System.Drawing.Point(99, 398)
        Me.DtpFechaSalida.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFechaSalida.Name = "DtpFechaSalida"
        Me.DtpFechaSalida.Size = New System.Drawing.Size(146, 20)
        Me.DtpFechaSalida.TabIndex = 17
        '
        'lblFechaSalida
        '
        Me.lblFechaSalida.AutoSize = True
        Me.lblFechaSalida.Location = New System.Drawing.Point(6, 402)
        Me.lblFechaSalida.Name = "lblFechaSalida"
        Me.lblFechaSalida.Size = New System.Drawing.Size(76, 13)
        Me.lblFechaSalida.TabIndex = 327
        Me.lblFechaSalida.Text = "Fecha salida  :"
        '
        'txtCaja
        '
        Me.txtCaja.Location = New System.Drawing.Point(99, 247)
        Me.txtCaja.MaxLength = 80
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Size = New System.Drawing.Size(69, 20)
        Me.txtCaja.TabIndex = 11
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Location = New System.Drawing.Point(6, 251)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(34, 13)
        Me.lblCaja.TabIndex = 325
        Me.lblCaja.Text = "Caja :"
        '
        'txtLinea
        '
        Me.txtLinea.Enabled = False
        Me.txtLinea.Location = New System.Drawing.Point(99, 222)
        Me.txtLinea.MaxLength = 80
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.Size = New System.Drawing.Size(344, 20)
        Me.txtLinea.TabIndex = 10
        '
        'lblLineaTransporte
        '
        Me.lblLineaTransporte.AutoSize = True
        Me.lblLineaTransporte.Location = New System.Drawing.Point(6, 226)
        Me.lblLineaTransporte.Name = "lblLineaTransporte"
        Me.lblLineaTransporte.Size = New System.Drawing.Size(41, 13)
        Me.lblLineaTransporte.TabIndex = 321
        Me.lblLineaTransporte.Text = "Línea :"
        '
        'txtCodigoTransporte
        '
        Me.txtCodigoTransporte.Location = New System.Drawing.Point(99, 197)
        Me.txtCodigoTransporte.MaxLength = 80
        Me.txtCodigoTransporte.Name = "txtCodigoTransporte"
        Me.txtCodigoTransporte.Size = New System.Drawing.Size(47, 20)
        Me.txtCodigoTransporte.TabIndex = 9
        '
        'lblTransporte
        '
        Me.lblTransporte.AutoSize = True
        Me.lblTransporte.Location = New System.Drawing.Point(6, 201)
        Me.lblTransporte.Name = "lblTransporte"
        Me.lblTransporte.Size = New System.Drawing.Size(64, 13)
        Me.lblTransporte.TabIndex = 320
        Me.lblTransporte.Text = "Transporte :"
        '
        'txtFolioEmbarque
        '
        Me.txtFolioEmbarque.Location = New System.Drawing.Point(99, 69)
        Me.txtFolioEmbarque.MaxLength = 15
        Me.txtFolioEmbarque.Name = "txtFolioEmbarque"
        Me.txtFolioEmbarque.Size = New System.Drawing.Size(89, 20)
        Me.txtFolioEmbarque.TabIndex = 2
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(99, 373)
        Me.dtpFechaEntrega.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(146, 20)
        Me.dtpFechaEntrega.TabIndex = 16
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Location = New System.Drawing.Point(6, 377)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(82, 13)
        Me.lblFechaEntrega.TabIndex = 296
        Me.lblFechaEntrega.Text = "Fecha entrega :"
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(6, 539)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(84, 13)
        Me.LblDisplayDireccionEmpresa.TabIndex = 294
        Me.LblDisplayDireccionEmpresa.Text = "Observaciones :"
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(99, 536)
        Me.TxtObservaciones.MaxLength = 200
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(344, 41)
        Me.TxtObservaciones.TabIndex = 22
        '
        'txtFolioAARC
        '
        Me.txtFolioAARC.Location = New System.Drawing.Point(302, 69)
        Me.txtFolioAARC.MaxLength = 15
        Me.txtFolioAARC.Name = "txtFolioAARC"
        Me.txtFolioAARC.Size = New System.Drawing.Size(104, 20)
        Me.txtFolioAARC.TabIndex = 3
        '
        'lblDisplayFolioAARC
        '
        Me.lblDisplayFolioAARC.AutoSize = True
        Me.lblDisplayFolioAARC.Location = New System.Drawing.Point(209, 73)
        Me.lblDisplayFolioAARC.Name = "lblDisplayFolioAARC"
        Me.lblDisplayFolioAARC.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayFolioAARC.TabIndex = 286
        Me.lblDisplayFolioAARC.Text = "Folio AARC :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(172, 176)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(234, 13)
        Me.lblNombreCliente.TabIndex = 284
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(99, 172)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(69, 20)
        Me.TxtCliente.TabIndex = 8
        Me.TxtCliente.Text = "  "
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(6, 176)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 283
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(99, 348)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(146, 20)
        Me.DtpFecha.TabIndex = 15
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(6, 352)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 281
        Me.LblFecha.Text = "Fecha :"
        '
        'CboEmbarcador
        '
        Me.CboEmbarcador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEmbarcador.FormattingEnabled = True
        Me.CboEmbarcador.Location = New System.Drawing.Point(99, 146)
        Me.CboEmbarcador.Name = "CboEmbarcador"
        Me.CboEmbarcador.Size = New System.Drawing.Size(344, 21)
        Me.CboEmbarcador.TabIndex = 7
        '
        'lblEmbarcador
        '
        Me.lblEmbarcador.AutoSize = True
        Me.lblEmbarcador.Location = New System.Drawing.Point(6, 150)
        Me.lblEmbarcador.Name = "lblEmbarcador"
        Me.lblEmbarcador.Size = New System.Drawing.Size(70, 13)
        Me.lblEmbarcador.TabIndex = 279
        Me.lblEmbarcador.Text = "Embarcador :"
        '
        'LblDisplayFolioEmbarque
        '
        Me.LblDisplayFolioEmbarque.AutoSize = True
        Me.LblDisplayFolioEmbarque.Location = New System.Drawing.Point(6, 73)
        Me.LblDisplayFolioEmbarque.Name = "LblDisplayFolioEmbarque"
        Me.LblDisplayFolioEmbarque.Size = New System.Drawing.Size(85, 13)
        Me.LblDisplayFolioEmbarque.TabIndex = 278
        Me.LblDisplayFolioEmbarque.Text = "Folio embarque :"
        '
        'gbGrid
        '
        Me.gbGrid.Controls.Add(Me.Grid)
        Me.gbGrid.Controls.Add(Me.txtTotalBultos)
        Me.gbGrid.Controls.Add(Me.TxtTotalImporte)
        Me.gbGrid.Controls.Add(Me.TxtTotalPeso)
        Me.gbGrid.Controls.Add(Me.lblTotales)
        Me.gbGrid.Location = New System.Drawing.Point(467, 29)
        Me.gbGrid.Name = "gbGrid"
        Me.gbGrid.Size = New System.Drawing.Size(539, 611)
        Me.gbGrid.TabIndex = 1
        Me.gbGrid.TabStop = False
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(6, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(526, 497)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'txtTotalBultos
        '
        Me.txtTotalBultos.Location = New System.Drawing.Point(137, 547)
        Me.txtTotalBultos.Name = "txtTotalBultos"
        Me.txtTotalBultos.ReadOnly = True
        Me.txtTotalBultos.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalBultos.TabIndex = 3
        Me.txtTotalBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalImporte
        '
        Me.TxtTotalImporte.Location = New System.Drawing.Point(343, 547)
        Me.TxtTotalImporte.Name = "TxtTotalImporte"
        Me.TxtTotalImporte.ReadOnly = True
        Me.TxtTotalImporte.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalImporte.TabIndex = 5
        Me.TxtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalPeso
        '
        Me.TxtTotalPeso.Location = New System.Drawing.Point(243, 547)
        Me.TxtTotalPeso.Name = "TxtTotalPeso"
        Me.TxtTotalPeso.ReadOnly = True
        Me.TxtTotalPeso.Size = New System.Drawing.Size(94, 20)
        Me.TxtTotalPeso.TabIndex = 4
        Me.TxtTotalPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotales
        '
        Me.lblTotales.AutoSize = True
        Me.lblTotales.Location = New System.Drawing.Point(34, 551)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblTotales.TabIndex = 321
        Me.lblTotales.Text = "Totales :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 652)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1012, 24)
        Me.StatusStripEstado.TabIndex = 324
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tsslEstado
        '
        Me.tsslEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslEstado.Name = "tsslEstado"
        Me.tsslEstado.Size = New System.Drawing.Size(46, 19)
        Me.tsslEstado.Text = "Estado"
        '
        'tsslElaboro
        '
        Me.tsslElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslElaboro.Name = "tsslElaboro"
        Me.tsslElaboro.Size = New System.Drawing.Size(57, 19)
        Me.tsslElaboro.Text = "Elaboró :"
        '
        'tsslCancelo
        '
        Me.tsslCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCancelo.Name = "tsslCancelo"
        Me.tsslCancelo.Size = New System.Drawing.Size(60, 19)
        Me.tsslCancelo.Text = "Canceló :"
        '
        'btnConsultarSalida
        '
        Me.btnConsultarSalida.Location = New System.Drawing.Point(875, 6)
        Me.btnConsultarSalida.Name = "btnConsultarSalida"
        Me.btnConsultarSalida.Size = New System.Drawing.Size(124, 23)
        Me.btnConsultarSalida.TabIndex = 360
        Me.btnConsultarSalida.Text = "Consultar salida"
        Me.btnConsultarSalida.UseVisualStyleBackColor = True
        '
        'btnCambiarPrecios
        '
        Me.btnCambiarPrecios.Location = New System.Drawing.Point(745, 6)
        Me.btnCambiarPrecios.Name = "btnCambiarPrecios"
        Me.btnCambiarPrecios.Size = New System.Drawing.Size(124, 23)
        Me.btnCambiarPrecios.TabIndex = 361
        Me.btnCambiarPrecios.Text = "Cambiar precios"
        Me.btnCambiarPrecios.UseVisualStyleBackColor = True
        '
        'btnCancelarFactura
        '
        Me.btnCancelarFactura.Enabled = False
        Me.btnCancelarFactura.Location = New System.Drawing.Point(619, 6)
        Me.btnCancelarFactura.Name = "btnCancelarFactura"
        Me.btnCancelarFactura.Size = New System.Drawing.Size(120, 23)
        Me.btnCancelarFactura.TabIndex = 367
        Me.btnCancelarFactura.Text = "Cancelar factura"
        Me.btnCancelarFactura.UseVisualStyleBackColor = True
        '
        'btnFacturar
        '
        Me.btnFacturar.Enabled = False
        Me.btnFacturar.Location = New System.Drawing.Point(493, 6)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(120, 23)
        Me.btnFacturar.TabIndex = 365
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.UseVisualStyleBackColor = True
        '
        'Frm_Embarques_Captura_Embarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 676)
        Me.Controls.Add(Me.btnCancelarFactura)
        Me.Controls.Add(Me.btnFacturar)
        Me.Controls.Add(Me.btnCambiarPrecios)
        Me.Controls.Add(Me.btnConsultarSalida)
        Me.Controls.Add(Me.gbGrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_Captura_Embarque"
        Me.Text = "Embarques"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbGrid.ResumeLayout(False)
        Me.gbGrid.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtpFechaSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaSalida As System.Windows.Forms.Label
    Friend WithEvents txtCaja As System.Windows.Forms.TextBox
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents lblLineaTransporte As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTransporte As System.Windows.Forms.TextBox
    Friend WithEvents lblTransporte As System.Windows.Forms.Label
    Friend WithEvents txtFolioEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents LblDisplayDireccionEmpresa As System.Windows.Forms.Label
    Friend WithEvents TxtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioAARC As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioAARC As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents CboEmbarcador As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmbarcador As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFolioEmbarque As System.Windows.Forms.Label
    Friend WithEvents gbGrid As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotales As System.Windows.Forms.Label
    Friend WithEvents txtTotalBultos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtTotalPeso As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtTotalImporte As System.Windows.Forms.MaskedTextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CboDistribuidor As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistribuidor As System.Windows.Forms.Label
    Friend WithEvents lblNombrelblAduanaExtranjera As System.Windows.Forms.Label
    Friend WithEvents TxtAduanaExtranjera As System.Windows.Forms.TextBox
    Friend WithEvents lblAduanaExtranjera As System.Windows.Forms.Label
    Friend WithEvents lblNombreCaja As System.Windows.Forms.Label
    Friend WithEvents TxtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents TxtModelo As System.Windows.Forms.TextBox
    Friend WithEvents TxtPlacasCaja As System.Windows.Forms.TextBox
    Friend WithEvents lblPlacasCaja As System.Windows.Forms.Label
    Friend WithEvents TxtTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents lblTemperatura As System.Windows.Forms.Label
    Friend WithEvents lblNombrelblAduanaNacional As System.Windows.Forms.Label
    Friend WithEvents TxtAduanaNacional As System.Windows.Forms.TextBox
    Friend WithEvents lblAduanaNacional As System.Windows.Forms.Label
    Friend WithEvents TxtSellos As System.Windows.Forms.TextBox
    Friend WithEvents lblSellos As System.Windows.Forms.Label
    Friend WithEvents lblChofer As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents cboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioViaje As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioViaje As System.Windows.Forms.Label
    Friend WithEvents btnEmbarqueAdicional As System.Windows.Forms.Button
    Friend WithEvents CboLugarEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnGeneraFlete As System.Windows.Forms.Button
    Friend WithEvents BtnGeneraSalida As System.Windows.Forms.Button
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents tsbImprimirEtiquetasPalets As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEmbarqueSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnEmbarqueAnterior As System.Windows.Forms.Button
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayEstado As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFacturado As System.Windows.Forms.Label
    Friend WithEvents btnConsultarSalida As System.Windows.Forms.Button
    Friend WithEvents TxtChofer As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreChofer As System.Windows.Forms.Label
    Friend WithEvents btnCambiarPrecios As System.Windows.Forms.Button
    Friend WithEvents txtFleteImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tsbGenerarTxtEnvio As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblFolioEntradaAlmacen As System.Windows.Forms.Label
    Friend WithEvents btnGrabarFolioPedimento As System.Windows.Forms.Button
    Friend WithEvents txtFolioPedimento As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioPedimento As System.Windows.Forms.Label
    Friend WithEvents btnCancelarFactura As Button
    Friend WithEvents btnFacturar As Button
    Friend WithEvents txtFolioFactura As TextBox
    Friend WithEvents lblDisplayFolioFactura As Label
    Friend WithEvents cboEmpaque As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
