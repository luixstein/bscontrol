<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ventas_Movimientos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ventas_Movimientos))
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCotizacionRemision = New System.Windows.Forms.ToolStripButton()
        Me.tsbCotizacionFactura = New System.Windows.Forms.ToolStripButton()
        Me.tsbRemisionVenta = New System.Windows.Forms.ToolStripButton()
        Me.tsbFacturaACartaPorte = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelarTimbre = New System.Windows.Forms.ToolStripButton()
        Me.tsbTimbrar = New System.Windows.Forms.ToolStripButton()
        Me.tsbRecuperarXMLPDF = New System.Windows.Forms.ToolStripButton()
        Me.tsbEnviarCorreo = New System.Windows.Forms.ToolStripButton()
        Me.tsbSubirXML = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.dpFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.dpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayVencimiento = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.LblDisplayCobrador = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.LblDisplayDireccionEmpresa = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.lblDisplayReferencia = New System.Windows.Forms.Label()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.lblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.lblDisplaySubtotalPesos = New System.Windows.Forms.Label()
        Me.lblDisplayImpuestoPesos = New System.Windows.Forms.Label()
        Me.lblDisplayTotalPesos = New System.Windows.Forms.Label()
        Me.LblDisplayTipoSocio = New System.Windows.Forms.Label()
        Me.txtPlazo = New System.Windows.Forms.TextBox()
        Me.lblDisplayPoliza = New System.Windows.Forms.Label()
        Me.lblDisplayMercado = New System.Windows.Forms.Label()
        Me.cboTipoMercado = New System.Windows.Forms.ComboBox()
        Me.cboTipoNegociacion = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTipo = New System.Windows.Forms.Label()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.lblDisplayVendedor = New System.Windows.Forms.Label()
        Me.chkVentaPublicoGeneral = New System.Windows.Forms.CheckBox()
        Me.gbPesos = New System.Windows.Forms.GroupBox()
        Me.lblDisplayRetencionISR = New System.Windows.Forms.Label()
        Me.lblTotalRetencionISR = New System.Windows.Forms.Label()
        Me.lblDisplayRetencionIVA = New System.Windows.Forms.Label()
        Me.lblTotalRetencionIVA = New System.Windows.Forms.Label()
        Me.lblDisplayDescuento = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblIEPS = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.gbDolares = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTotalRetencionISR_USD = New System.Windows.Forms.Label()
        Me.lblTotalRetencionISR_USD = New System.Windows.Forms.Label()
        Me.lblDisplayTotalRetencionIVA_USD = New System.Windows.Forms.Label()
        Me.lblTotalRetencionIVA_USD = New System.Windows.Forms.Label()
        Me.lblDisplayDescuento_USD = New System.Windows.Forms.Label()
        Me.lblDescuento_USD = New System.Windows.Forms.Label()
        Me.lblIEPS_USD = New System.Windows.Forms.Label()
        Me.lblDisplayIEPS_USD = New System.Windows.Forms.Label()
        Me.lblTotal_USD = New System.Windows.Forms.Label()
        Me.lblSubtotal_USD = New System.Windows.Forms.Label()
        Me.lblImpuesto_USD = New System.Windows.Forms.Label()
        Me.lblDisplayTotal_USD = New System.Windows.Forms.Label()
        Me.lblDisplaySubtotal_USD = New System.Windows.Forms.Label()
        Me.lblDisplayImpuesto_USD = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.lblDisplaySaldo = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.frmDatos = New System.Windows.Forms.GroupBox()
        Me.ckbMostrarUtilidad = New System.Windows.Forms.CheckBox()
        Me.gbUtilidad = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDisplayUtilidad = New System.Windows.Forms.Label()
        Me.lblPorcentajeUtilidad = New System.Windows.Forms.Label()
        Me.lblUtilidad = New System.Windows.Forms.Label()
        Me.lblConceptoCancelacion = New System.Windows.Forms.Label()
        Me.TxtConceptoCancelacion = New System.Windows.Forms.TextBox()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblVersionCFDI = New System.Windows.Forms.Label()
        Me.cboUsoCFDI = New System.Windows.Forms.ComboBox()
        Me.lblDisplayMetodoPago = New System.Windows.Forms.Label()
        Me.cboMetodoPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayUsoCFDI = New System.Windows.Forms.Label()
        Me.CboTipoCredito = New System.Windows.Forms.ComboBox()
        Me.lblTipoCredito = New System.Windows.Forms.Label()
        Me.LblDisplayMoneda = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.btnFacturaSiguiente = New System.Windows.Forms.Button()
        Me.btnFacturaAnterior = New System.Windows.Forms.Button()
        Me.lblDisplayTipoCambio = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtNumeroCuentaPago = New System.Windows.Forms.TextBox()
        Me.lblDisplayNumeroCuentaPago = New System.Windows.Forms.Label()
        Me.lblFormaPago = New System.Windows.Forms.Label()
        Me.llblAgregarSeguimiento = New System.Windows.Forms.LinkLabel()
        Me.txtFolioEmbarque = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioEmbarque = New System.Windows.Forms.Label()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.lblDisplayIEPSIncluido_USD = New System.Windows.Forms.Label()
        Me.lblDisplayIEPSIncluido = New System.Windows.Forms.Label()
        Me.lblSaldoDolares = New System.Windows.Forms.Label()
        Me.lblDisplaySaldoDolares = New System.Windows.Forms.Label()
        Me.lblIEPSIncluido_USD = New System.Windows.Forms.Label()
        Me.txtUUID = New System.Windows.Forms.TextBox()
        Me.lblUUID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIEPSIncluido = New System.Windows.Forms.Label()
        Me.btnSeries = New System.Windows.Forms.Button()
        Me.btnAgregaAddenda = New System.Windows.Forms.Button()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpArticulos = New System.Windows.Forms.TabPage()
        Me.btnAgregarRenglon = New System.Windows.Forms.Button()
        Me.Grid = New FlexCell.Grid()
        Me.tpSeries = New System.Windows.Forms.TabPage()
        Me.btnMostrarMasColumnasGridSeries = New System.Windows.Forms.Button()
        Me.GridSeries = New FlexCell.Grid()
        Me.tpCFDIsRelacionados = New System.Windows.Forms.TabPage()
        Me.GridCFDIsRelacionados = New FlexCell.Grid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoRelacionCFDI = New System.Windows.Forms.ComboBox()
        Me.tpFacturasRemisiones = New System.Windows.Forms.TabPage()
        Me.btnAceptarRemisionesSeries = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCargarRemisiones = New System.Windows.Forms.Button()
        Me.GridFacturasVariasRemisiones = New FlexCell.Grid()
        Me.lblDisplayRegimenFiscal = New System.Windows.Forms.Label()
        Me.cboRegimenFiscal = New System.Windows.Forms.ComboBox()
        Me.btnTimbradoTrasladoPrueba = New System.Windows.Forms.Button()
        Me.btnCartaPorte = New System.Windows.Forms.Button()
        Me.chkTieneCartaPorte = New System.Windows.Forms.CheckBox()
        Me.chkTieneCCE = New System.Windows.Forms.CheckBox()
        Me.cboIncoterm = New System.Windows.Forms.ComboBox()
        Me.lblDisplayIncoterm = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gbPesos.SuspendLayout()
        Me.gbDolares.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.frmDatos.SuspendLayout()
        Me.gbUtilidad.SuspendLayout()
        Me.gbTotales.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpArticulos.SuspendLayout()
        Me.tpSeries.SuspendLayout()
        Me.tpCFDIsRelacionados.SuspendLayout()
        Me.tpFacturasRemisiones.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(53, 16)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(10, 13)
        Me.LblEstatus.TabIndex = 226
        Me.LblEstatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(6, 16)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 225
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(84, 41)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(83, 20)
        Me.txtFolio.TabIndex = 2
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(2, 44)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 224
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbCancelar, Me.tsbCotizacionRemision, Me.tsbCotizacionFactura, Me.tsbRemisionVenta, Me.tsbFacturaACartaPorte, Me.tsbCancelarTimbre, Me.tsbTimbrar, Me.tsbRecuperarXMLPDF, Me.tsbEnviarCorreo, Me.tsbSubirXML, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1287, 27)
        Me.tsMenu.TabIndex = 4
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(66, 24)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(66, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(77, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(80, 24)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbCotizacionRemision
        '
        Me.tsbCotizacionRemision.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbCotizacionRemision.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCotizacionRemision.Name = "tsbCotizacionRemision"
        Me.tsbCotizacionRemision.Size = New System.Drawing.Size(145, 24)
        Me.tsbCotizacionRemision.Text = "&Cotización a remisión"
        Me.tsbCotizacionRemision.Visible = False
        '
        'tsbCotizacionFactura
        '
        Me.tsbCotizacionFactura.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbCotizacionFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCotizacionFactura.Name = "tsbCotizacionFactura"
        Me.tsbCotizacionFactura.Size = New System.Drawing.Size(136, 24)
        Me.tsbCotizacionFactura.Text = "&Cotización a factura"
        Me.tsbCotizacionFactura.Visible = False
        '
        'tsbRemisionVenta
        '
        Me.tsbRemisionVenta.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbRemisionVenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRemisionVenta.Name = "tsbRemisionVenta"
        Me.tsbRemisionVenta.Size = New System.Drawing.Size(121, 24)
        Me.tsbRemisionVenta.Text = "&Remisión a venta"
        Me.tsbRemisionVenta.Visible = False
        '
        'tsbFacturaACartaPorte
        '
        Me.tsbFacturaACartaPorte.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbFacturaACartaPorte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFacturaACartaPorte.Name = "tsbFacturaACartaPorte"
        Me.tsbFacturaACartaPorte.Size = New System.Drawing.Size(120, 24)
        Me.tsbFacturaACartaPorte.Text = "Fac a Carta Porte"
        Me.tsbFacturaACartaPorte.Visible = False
        '
        'tsbCancelarTimbre
        '
        Me.tsbCancelarTimbre.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbCancelarTimbre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelarTimbre.Name = "tsbCancelarTimbre"
        Me.tsbCancelarTimbre.Size = New System.Drawing.Size(115, 24)
        Me.tsbCancelarTimbre.Text = "Cancelar timbre"
        Me.tsbCancelarTimbre.Visible = False
        '
        'tsbTimbrar
        '
        Me.tsbTimbrar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbTimbrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTimbrar.Name = "tsbTimbrar"
        Me.tsbTimbrar.Size = New System.Drawing.Size(72, 24)
        Me.tsbTimbrar.Text = "Timbrar"
        Me.tsbTimbrar.Visible = False
        '
        'tsbRecuperarXMLPDF
        '
        Me.tsbRecuperarXMLPDF.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbRecuperarXMLPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecuperarXMLPDF.Name = "tsbRecuperarXMLPDF"
        Me.tsbRecuperarXMLPDF.Size = New System.Drawing.Size(151, 24)
        Me.tsbRecuperarXMLPDF.Text = "Recuperar/ver xml/pdf"
        Me.tsbRecuperarXMLPDF.Visible = False
        '
        'tsbEnviarCorreo
        '
        Me.tsbEnviarCorreo.Image = CType(resources.GetObject("tsbEnviarCorreo.Image"), System.Drawing.Image)
        Me.tsbEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarCorreo.Name = "tsbEnviarCorreo"
        Me.tsbEnviarCorreo.Size = New System.Drawing.Size(100, 24)
        Me.tsbEnviarCorreo.Text = "&Enviar correo"
        '
        'tsbSubirXML
        '
        Me.tsbSubirXML.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbSubirXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSubirXML.Name = "tsbSubirXML"
        Me.tsbSubirXML.Size = New System.Drawing.Size(85, 24)
        Me.tsbSubirXML.Text = "Subir XML"
        Me.tsbSubirXML.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(84, 15)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(205, 21)
        Me.CboDocumento.TabIndex = 0
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(2, 19)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 221
        Me.LblDocumento.Text = "Documento :"
        '
        'dpFecha
        '
        Me.dpFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dpFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(421, 62)
        Me.dpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(90, 20)
        Me.dpFecha.TabIndex = 12
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(328, 66)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 228
        Me.LblFecha.Text = "Fecha :"
        '
        'dpVencimiento
        '
        Me.dpVencimiento.Cursor = System.Windows.Forms.Cursors.Default
        Me.dpVencimiento.CustomFormat = "dd-MMM-yyyy"
        Me.dpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpVencimiento.Location = New System.Drawing.Point(422, 87)
        Me.dpVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpVencimiento.Name = "dpVencimiento"
        Me.dpVencimiento.Size = New System.Drawing.Size(90, 20)
        Me.dpVencimiento.TabIndex = 13
        '
        'lblDisplayVencimiento
        '
        Me.lblDisplayVencimiento.AutoSize = True
        Me.lblDisplayVencimiento.Location = New System.Drawing.Point(328, 91)
        Me.lblDisplayVencimiento.Name = "lblDisplayVencimiento"
        Me.lblDisplayVencimiento.Size = New System.Drawing.Size(71, 13)
        Me.lblDisplayVencimiento.TabIndex = 230
        Me.lblDisplayVencimiento.Text = "Vencimiento :"
        '
        'lblCliente
        '
        Me.lblCliente.Location = New System.Drawing.Point(173, 143)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(410, 13)
        Me.lblCliente.TabIndex = 233
        Me.lblCliente.Text = "."
        '
        'LblDisplayCobrador
        '
        Me.LblDisplayCobrador.AutoSize = True
        Me.LblDisplayCobrador.Location = New System.Drawing.Point(2, 142)
        Me.LblDisplayCobrador.Name = "LblDisplayCobrador"
        Me.LblDisplayCobrador.Size = New System.Drawing.Size(45, 13)
        Me.LblDisplayCobrador.TabIndex = 232
        Me.LblDisplayCobrador.Text = "Cliente :"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(84, 139)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(83, 20)
        Me.TxtCliente.TabIndex = 8
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(2, 193)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayDireccionEmpresa.TabIndex = 235
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(84, 191)
        Me.TxtConcepto.MaxLength = 4000
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConcepto.Size = New System.Drawing.Size(615, 45)
        Me.TxtConcepto.TabIndex = 10
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Enabled = False
        Me.TxtReferencia.Location = New System.Drawing.Point(84, 64)
        Me.TxtReferencia.MaxLength = 15
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(83, 20)
        Me.TxtReferencia.TabIndex = 3
        '
        'lblDisplayReferencia
        '
        Me.lblDisplayReferencia.AutoSize = True
        Me.lblDisplayReferencia.Location = New System.Drawing.Point(2, 67)
        Me.lblDisplayReferencia.Name = "lblDisplayReferencia"
        Me.lblDisplayReferencia.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayReferencia.TabIndex = 237
        Me.lblDisplayReferencia.Text = "Referencia :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(715, 36)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(205, 21)
        Me.CboAlmacen.TabIndex = 18
        '
        'lblDisplayAlmacen
        '
        Me.lblDisplayAlmacen.AutoSize = True
        Me.lblDisplayAlmacen.Location = New System.Drawing.Point(640, 41)
        Me.lblDisplayAlmacen.Name = "lblDisplayAlmacen"
        Me.lblDisplayAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayAlmacen.TabIndex = 239
        Me.lblDisplayAlmacen.Text = "Almacén :"
        '
        'lblDisplaySubtotalPesos
        '
        Me.lblDisplaySubtotalPesos.AutoSize = True
        Me.lblDisplaySubtotalPesos.Location = New System.Drawing.Point(6, 16)
        Me.lblDisplaySubtotalPesos.Name = "lblDisplaySubtotalPesos"
        Me.lblDisplaySubtotalPesos.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplaySubtotalPesos.TabIndex = 242
        Me.lblDisplaySubtotalPesos.Text = "Subtotal :"
        '
        'lblDisplayImpuestoPesos
        '
        Me.lblDisplayImpuestoPesos.AutoSize = True
        Me.lblDisplayImpuestoPesos.Location = New System.Drawing.Point(6, 64)
        Me.lblDisplayImpuestoPesos.Name = "lblDisplayImpuestoPesos"
        Me.lblDisplayImpuestoPesos.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayImpuestoPesos.TabIndex = 244
        Me.lblDisplayImpuestoPesos.Text = "IVA :"
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(6, 112)
        Me.lblDisplayTotalPesos.Name = "lblDisplayTotalPesos"
        Me.lblDisplayTotalPesos.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayTotalPesos.TabIndex = 246
        Me.lblDisplayTotalPesos.Text = "Total :"
        '
        'LblDisplayTipoSocio
        '
        Me.LblDisplayTipoSocio.AutoSize = True
        Me.LblDisplayTipoSocio.Location = New System.Drawing.Point(547, 66)
        Me.LblDisplayTipoSocio.Name = "LblDisplayTipoSocio"
        Me.LblDisplayTipoSocio.Size = New System.Drawing.Size(39, 13)
        Me.LblDisplayTipoSocio.TabIndex = 281
        Me.LblDisplayTipoSocio.Text = "Plazo :"
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(592, 62)
        Me.txtPlazo.MaxLength = 3
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(33, 20)
        Me.txtPlazo.TabIndex = 10
        '
        'lblDisplayPoliza
        '
        Me.lblDisplayPoliza.AutoSize = True
        Me.lblDisplayPoliza.Location = New System.Drawing.Point(6, 42)
        Me.lblDisplayPoliza.Name = "lblDisplayPoliza"
        Me.lblDisplayPoliza.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayPoliza.TabIndex = 283
        Me.lblDisplayPoliza.Text = "Póliza :"
        '
        'lblDisplayMercado
        '
        Me.lblDisplayMercado.AutoSize = True
        Me.lblDisplayMercado.Location = New System.Drawing.Point(328, 15)
        Me.lblDisplayMercado.Name = "lblDisplayMercado"
        Me.lblDisplayMercado.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayMercado.TabIndex = 285
        Me.lblDisplayMercado.Text = "Mercado :"
        '
        'cboTipoMercado
        '
        Me.cboTipoMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMercado.FormattingEnabled = True
        Me.cboTipoMercado.Location = New System.Drawing.Point(400, 11)
        Me.cboTipoMercado.Name = "cboTipoMercado"
        Me.cboTipoMercado.Size = New System.Drawing.Size(205, 21)
        Me.cboTipoMercado.TabIndex = 1
        '
        'cboTipoNegociacion
        '
        Me.cboTipoNegociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoNegociacion.FormattingEnabled = True
        Me.cboTipoNegociacion.Location = New System.Drawing.Point(84, 88)
        Me.cboTipoNegociacion.Name = "cboTipoNegociacion"
        Me.cboTipoNegociacion.Size = New System.Drawing.Size(83, 21)
        Me.cboTipoNegociacion.TabIndex = 5
        '
        'lblDisplayTipo
        '
        Me.lblDisplayTipo.AutoSize = True
        Me.lblDisplayTipo.Location = New System.Drawing.Point(2, 90)
        Me.lblDisplayTipo.Name = "lblDisplayTipo"
        Me.lblDisplayTipo.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayTipo.TabIndex = 288
        Me.lblDisplayTipo.Text = "Tipo :"
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(715, 12)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(205, 21)
        Me.cboVendedor.TabIndex = 17
        '
        'lblDisplayVendedor
        '
        Me.lblDisplayVendedor.AutoSize = True
        Me.lblDisplayVendedor.Location = New System.Drawing.Point(640, 16)
        Me.lblDisplayVendedor.Name = "lblDisplayVendedor"
        Me.lblDisplayVendedor.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayVendedor.TabIndex = 290
        Me.lblDisplayVendedor.Text = "Vendedor :"
        '
        'chkVentaPublicoGeneral
        '
        Me.chkVentaPublicoGeneral.AutoSize = True
        Me.chkVentaPublicoGeneral.Location = New System.Drawing.Point(170, 68)
        Me.chkVentaPublicoGeneral.Name = "chkVentaPublicoGeneral"
        Me.chkVentaPublicoGeneral.Size = New System.Drawing.Size(140, 17)
        Me.chkVentaPublicoGeneral.TabIndex = 4
        Me.chkVentaPublicoGeneral.Text = "Venta al público general"
        Me.chkVentaPublicoGeneral.UseVisualStyleBackColor = True
        '
        'gbPesos
        '
        Me.gbPesos.Controls.Add(Me.lblDisplayRetencionISR)
        Me.gbPesos.Controls.Add(Me.lblTotalRetencionISR)
        Me.gbPesos.Controls.Add(Me.lblDisplayRetencionIVA)
        Me.gbPesos.Controls.Add(Me.lblTotalRetencionIVA)
        Me.gbPesos.Controls.Add(Me.lblDisplayDescuento)
        Me.gbPesos.Controls.Add(Me.lblDescuento)
        Me.gbPesos.Controls.Add(Me.lblIEPS)
        Me.gbPesos.Controls.Add(Me.Label2)
        Me.gbPesos.Controls.Add(Me.lblTotal)
        Me.gbPesos.Controls.Add(Me.lblSubtotal)
        Me.gbPesos.Controls.Add(Me.lblImpuesto)
        Me.gbPesos.Controls.Add(Me.lblDisplayTotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplaySubtotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplayImpuestoPesos)
        Me.gbPesos.Location = New System.Drawing.Point(630, 0)
        Me.gbPesos.Name = "gbPesos"
        Me.gbPesos.Size = New System.Drawing.Size(189, 130)
        Me.gbPesos.TabIndex = 292
        Me.gbPesos.TabStop = False
        Me.gbPesos.Text = "MXN :"
        '
        'lblDisplayRetencionISR
        '
        Me.lblDisplayRetencionISR.AutoSize = True
        Me.lblDisplayRetencionISR.Location = New System.Drawing.Point(6, 96)
        Me.lblDisplayRetencionISR.Name = "lblDisplayRetencionISR"
        Me.lblDisplayRetencionISR.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayRetencionISR.TabIndex = 257
        Me.lblDisplayRetencionISR.Text = "Ret. ISR :"
        '
        'lblTotalRetencionISR
        '
        Me.lblTotalRetencionISR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionISR.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionISR.Location = New System.Drawing.Point(70, 96)
        Me.lblTotalRetencionISR.Name = "lblTotalRetencionISR"
        Me.lblTotalRetencionISR.Size = New System.Drawing.Size(107, 13)
        Me.lblTotalRetencionISR.TabIndex = 256
        Me.lblTotalRetencionISR.Text = "0.00"
        Me.lblTotalRetencionISR.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayRetencionIVA
        '
        Me.lblDisplayRetencionIVA.AutoSize = True
        Me.lblDisplayRetencionIVA.Location = New System.Drawing.Point(6, 80)
        Me.lblDisplayRetencionIVA.Name = "lblDisplayRetencionIVA"
        Me.lblDisplayRetencionIVA.Size = New System.Drawing.Size(53, 13)
        Me.lblDisplayRetencionIVA.TabIndex = 255
        Me.lblDisplayRetencionIVA.Text = "Ret. IVA :"
        '
        'lblTotalRetencionIVA
        '
        Me.lblTotalRetencionIVA.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionIVA.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionIVA.Location = New System.Drawing.Point(70, 80)
        Me.lblTotalRetencionIVA.Name = "lblTotalRetencionIVA"
        Me.lblTotalRetencionIVA.Size = New System.Drawing.Size(107, 13)
        Me.lblTotalRetencionIVA.TabIndex = 254
        Me.lblTotalRetencionIVA.Text = "0.00"
        Me.lblTotalRetencionIVA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayDescuento
        '
        Me.lblDisplayDescuento.AutoSize = True
        Me.lblDisplayDescuento.Location = New System.Drawing.Point(6, 32)
        Me.lblDisplayDescuento.Name = "lblDisplayDescuento"
        Me.lblDisplayDescuento.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayDescuento.TabIndex = 253
        Me.lblDisplayDescuento.Text = "Descuento :"
        '
        'lblDescuento
        '
        Me.lblDescuento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDescuento.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDescuento.Location = New System.Drawing.Point(70, 32)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(107, 13)
        Me.lblDescuento.TabIndex = 252
        Me.lblDescuento.Text = "0.00"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIEPS
        '
        Me.lblIEPS.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPS.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPS.Location = New System.Drawing.Point(70, 48)
        Me.lblIEPS.Name = "lblIEPS"
        Me.lblIEPS.Size = New System.Drawing.Size(107, 13)
        Me.lblIEPS.TabIndex = 251
        Me.lblIEPS.Text = "0.00"
        Me.lblIEPS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "IEPS :"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal.Location = New System.Drawing.Point(70, 112)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(107, 13)
        Me.lblTotal.TabIndex = 249
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal.Location = New System.Drawing.Point(70, 16)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(107, 13)
        Me.lblSubtotal.TabIndex = 247
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto.Location = New System.Drawing.Point(70, 64)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(107, 13)
        Me.lblImpuesto.TabIndex = 248
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.lblDisplayTotalRetencionISR_USD)
        Me.gbDolares.Controls.Add(Me.lblTotalRetencionISR_USD)
        Me.gbDolares.Controls.Add(Me.lblDisplayTotalRetencionIVA_USD)
        Me.gbDolares.Controls.Add(Me.lblTotalRetencionIVA_USD)
        Me.gbDolares.Controls.Add(Me.lblDisplayDescuento_USD)
        Me.gbDolares.Controls.Add(Me.lblDescuento_USD)
        Me.gbDolares.Controls.Add(Me.lblIEPS_USD)
        Me.gbDolares.Controls.Add(Me.lblDisplayIEPS_USD)
        Me.gbDolares.Controls.Add(Me.lblTotal_USD)
        Me.gbDolares.Controls.Add(Me.lblSubtotal_USD)
        Me.gbDolares.Controls.Add(Me.lblImpuesto_USD)
        Me.gbDolares.Controls.Add(Me.lblDisplayTotal_USD)
        Me.gbDolares.Controls.Add(Me.lblDisplaySubtotal_USD)
        Me.gbDolares.Controls.Add(Me.lblDisplayImpuesto_USD)
        Me.gbDolares.Location = New System.Drawing.Point(449, 0)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Size = New System.Drawing.Size(185, 130)
        Me.gbDolares.TabIndex = 293
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "USD :"
        Me.gbDolares.Visible = False
        '
        'lblDisplayTotalRetencionISR_USD
        '
        Me.lblDisplayTotalRetencionISR_USD.AutoSize = True
        Me.lblDisplayTotalRetencionISR_USD.Location = New System.Drawing.Point(1, 96)
        Me.lblDisplayTotalRetencionISR_USD.Name = "lblDisplayTotalRetencionISR_USD"
        Me.lblDisplayTotalRetencionISR_USD.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayTotalRetencionISR_USD.TabIndex = 263
        Me.lblDisplayTotalRetencionISR_USD.Text = "Ret. ISR :"
        '
        'lblTotalRetencionISR_USD
        '
        Me.lblTotalRetencionISR_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionISR_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionISR_USD.Location = New System.Drawing.Point(68, 96)
        Me.lblTotalRetencionISR_USD.Name = "lblTotalRetencionISR_USD"
        Me.lblTotalRetencionISR_USD.Size = New System.Drawing.Size(107, 13)
        Me.lblTotalRetencionISR_USD.TabIndex = 262
        Me.lblTotalRetencionISR_USD.Text = "0.00"
        Me.lblTotalRetencionISR_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotalRetencionIVA_USD
        '
        Me.lblDisplayTotalRetencionIVA_USD.AutoSize = True
        Me.lblDisplayTotalRetencionIVA_USD.Location = New System.Drawing.Point(1, 80)
        Me.lblDisplayTotalRetencionIVA_USD.Name = "lblDisplayTotalRetencionIVA_USD"
        Me.lblDisplayTotalRetencionIVA_USD.Size = New System.Drawing.Size(53, 13)
        Me.lblDisplayTotalRetencionIVA_USD.TabIndex = 261
        Me.lblDisplayTotalRetencionIVA_USD.Text = "Ret. IVA :"
        '
        'lblTotalRetencionIVA_USD
        '
        Me.lblTotalRetencionIVA_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionIVA_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionIVA_USD.Location = New System.Drawing.Point(68, 80)
        Me.lblTotalRetencionIVA_USD.Name = "lblTotalRetencionIVA_USD"
        Me.lblTotalRetencionIVA_USD.Size = New System.Drawing.Size(107, 13)
        Me.lblTotalRetencionIVA_USD.TabIndex = 260
        Me.lblTotalRetencionIVA_USD.Text = "0.00"
        Me.lblTotalRetencionIVA_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayDescuento_USD
        '
        Me.lblDisplayDescuento_USD.AutoSize = True
        Me.lblDisplayDescuento_USD.Location = New System.Drawing.Point(1, 32)
        Me.lblDisplayDescuento_USD.Name = "lblDisplayDescuento_USD"
        Me.lblDisplayDescuento_USD.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayDescuento_USD.TabIndex = 259
        Me.lblDisplayDescuento_USD.Text = "Descuento :"
        '
        'lblDescuento_USD
        '
        Me.lblDescuento_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDescuento_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDescuento_USD.Location = New System.Drawing.Point(68, 32)
        Me.lblDescuento_USD.Name = "lblDescuento_USD"
        Me.lblDescuento_USD.Size = New System.Drawing.Size(107, 13)
        Me.lblDescuento_USD.TabIndex = 258
        Me.lblDescuento_USD.Text = "0.00"
        Me.lblDescuento_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIEPS_USD
        '
        Me.lblIEPS_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPS_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPS_USD.Location = New System.Drawing.Point(68, 48)
        Me.lblIEPS_USD.Name = "lblIEPS_USD"
        Me.lblIEPS_USD.Size = New System.Drawing.Size(107, 13)
        Me.lblIEPS_USD.TabIndex = 257
        Me.lblIEPS_USD.Text = "0.00"
        Me.lblIEPS_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayIEPS_USD
        '
        Me.lblDisplayIEPS_USD.AutoSize = True
        Me.lblDisplayIEPS_USD.Location = New System.Drawing.Point(1, 48)
        Me.lblDisplayIEPS_USD.Name = "lblDisplayIEPS_USD"
        Me.lblDisplayIEPS_USD.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayIEPS_USD.TabIndex = 256
        Me.lblDisplayIEPS_USD.Text = "IEPS :"
        '
        'lblTotal_USD
        '
        Me.lblTotal_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal_USD.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal_USD.Location = New System.Drawing.Point(68, 112)
        Me.lblTotal_USD.Name = "lblTotal_USD"
        Me.lblTotal_USD.Size = New System.Drawing.Size(107, 13)
        Me.lblTotal_USD.TabIndex = 249
        Me.lblTotal_USD.Text = "0.00"
        Me.lblTotal_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal_USD
        '
        Me.lblSubtotal_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal_USD.Location = New System.Drawing.Point(68, 16)
        Me.lblSubtotal_USD.Name = "lblSubtotal_USD"
        Me.lblSubtotal_USD.Size = New System.Drawing.Size(107, 13)
        Me.lblSubtotal_USD.TabIndex = 247
        Me.lblSubtotal_USD.Text = "0.00"
        Me.lblSubtotal_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto_USD
        '
        Me.lblImpuesto_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto_USD.Location = New System.Drawing.Point(68, 64)
        Me.lblImpuesto_USD.Name = "lblImpuesto_USD"
        Me.lblImpuesto_USD.Size = New System.Drawing.Size(107, 13)
        Me.lblImpuesto_USD.TabIndex = 248
        Me.lblImpuesto_USD.Text = "0.00"
        Me.lblImpuesto_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotal_USD
        '
        Me.lblDisplayTotal_USD.AutoSize = True
        Me.lblDisplayTotal_USD.Location = New System.Drawing.Point(1, 112)
        Me.lblDisplayTotal_USD.Name = "lblDisplayTotal_USD"
        Me.lblDisplayTotal_USD.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayTotal_USD.TabIndex = 246
        Me.lblDisplayTotal_USD.Text = "Total :"
        '
        'lblDisplaySubtotal_USD
        '
        Me.lblDisplaySubtotal_USD.AutoSize = True
        Me.lblDisplaySubtotal_USD.Location = New System.Drawing.Point(1, 16)
        Me.lblDisplaySubtotal_USD.Name = "lblDisplaySubtotal_USD"
        Me.lblDisplaySubtotal_USD.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplaySubtotal_USD.TabIndex = 242
        Me.lblDisplaySubtotal_USD.Text = "Subtotal :"
        '
        'lblDisplayImpuesto_USD
        '
        Me.lblDisplayImpuesto_USD.AutoSize = True
        Me.lblDisplayImpuesto_USD.Location = New System.Drawing.Point(1, 64)
        Me.lblDisplayImpuesto_USD.Name = "lblDisplayImpuesto_USD"
        Me.lblDisplayImpuesto_USD.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayImpuesto_USD.TabIndex = 244
        Me.lblDisplayImpuesto_USD.Text = "IVA :"
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.lblSaldo.Location = New System.Drawing.Point(213, 16)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(107, 13)
        Me.lblSaldo.TabIndex = 298
        Me.lblSaldo.Text = "0.00"
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(140, 16)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplaySaldo.TabIndex = 297
        Me.lblDisplaySaldo.Text = "Saldo MXN :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 654)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1287, 24)
        Me.StatusStripEstado.TabIndex = 315
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
        'frmDatos
        '
        Me.frmDatos.Controls.Add(Me.ckbMostrarUtilidad)
        Me.frmDatos.Controls.Add(Me.gbUtilidad)
        Me.frmDatos.Controls.Add(Me.lblConceptoCancelacion)
        Me.frmDatos.Controls.Add(Me.TxtConceptoCancelacion)
        Me.frmDatos.Controls.Add(Me.cboFormaPago)
        Me.frmDatos.Controls.Add(Me.lblVersionCFDI)
        Me.frmDatos.Controls.Add(Me.cboUsoCFDI)
        Me.frmDatos.Controls.Add(Me.lblDisplayMetodoPago)
        Me.frmDatos.Controls.Add(Me.cboMetodoPago)
        Me.frmDatos.Controls.Add(Me.lblDisplayUsoCFDI)
        Me.frmDatos.Controls.Add(Me.CboTipoCredito)
        Me.frmDatos.Controls.Add(Me.lblTipoCredito)
        Me.frmDatos.Controls.Add(Me.LblDisplayMoneda)
        Me.frmDatos.Controls.Add(Me.cboMoneda)
        Me.frmDatos.Controls.Add(Me.btnFacturaSiguiente)
        Me.frmDatos.Controls.Add(Me.btnFacturaAnterior)
        Me.frmDatos.Controls.Add(Me.lblDisplayTipoCambio)
        Me.frmDatos.Controls.Add(Me.txtTipoCambio)
        Me.frmDatos.Controls.Add(Me.txtNumeroCuentaPago)
        Me.frmDatos.Controls.Add(Me.lblDisplayNumeroCuentaPago)
        Me.frmDatos.Controls.Add(Me.lblFormaPago)
        Me.frmDatos.Controls.Add(Me.llblAgregarSeguimiento)
        Me.frmDatos.Controls.Add(Me.txtFolioEmbarque)
        Me.frmDatos.Controls.Add(Me.CboDocumento)
        Me.frmDatos.Controls.Add(Me.lblDisplayFolioEmbarque)
        Me.frmDatos.Controls.Add(Me.LblDocumento)
        Me.frmDatos.Controls.Add(Me.LblDisplayFolio)
        Me.frmDatos.Controls.Add(Me.txtFolio)
        Me.frmDatos.Controls.Add(Me.LblFecha)
        Me.frmDatos.Controls.Add(Me.dpFecha)
        Me.frmDatos.Controls.Add(Me.lblDisplayVencimiento)
        Me.frmDatos.Controls.Add(Me.dpVencimiento)
        Me.frmDatos.Controls.Add(Me.TxtCliente)
        Me.frmDatos.Controls.Add(Me.LblDisplayCobrador)
        Me.frmDatos.Controls.Add(Me.chkVentaPublicoGeneral)
        Me.frmDatos.Controls.Add(Me.lblCliente)
        Me.frmDatos.Controls.Add(Me.lblDisplayVendedor)
        Me.frmDatos.Controls.Add(Me.TxtConcepto)
        Me.frmDatos.Controls.Add(Me.cboVendedor)
        Me.frmDatos.Controls.Add(Me.LblDisplayDireccionEmpresa)
        Me.frmDatos.Controls.Add(Me.lblDisplayTipo)
        Me.frmDatos.Controls.Add(Me.lblDisplayReferencia)
        Me.frmDatos.Controls.Add(Me.cboTipoNegociacion)
        Me.frmDatos.Controls.Add(Me.TxtReferencia)
        Me.frmDatos.Controls.Add(Me.cboTipoMercado)
        Me.frmDatos.Controls.Add(Me.lblDisplayAlmacen)
        Me.frmDatos.Controls.Add(Me.lblDisplayMercado)
        Me.frmDatos.Controls.Add(Me.CboAlmacen)
        Me.frmDatos.Controls.Add(Me.txtPlazo)
        Me.frmDatos.Controls.Add(Me.LblDisplayTipoSocio)
        Me.frmDatos.Location = New System.Drawing.Point(8, 28)
        Me.frmDatos.Name = "frmDatos"
        Me.frmDatos.Size = New System.Drawing.Size(986, 241)
        Me.frmDatos.TabIndex = 0
        Me.frmDatos.TabStop = False
        '
        'ckbMostrarUtilidad
        '
        Me.ckbMostrarUtilidad.AutoSize = True
        Me.ckbMostrarUtilidad.Location = New System.Drawing.Point(715, 189)
        Me.ckbMostrarUtilidad.Name = "ckbMostrarUtilidad"
        Me.ckbMostrarUtilidad.Size = New System.Drawing.Size(97, 17)
        Me.ckbMostrarUtilidad.TabIndex = 375
        Me.ckbMostrarUtilidad.Text = "Mostrar utilidad"
        Me.ckbMostrarUtilidad.UseVisualStyleBackColor = True
        '
        'gbUtilidad
        '
        Me.gbUtilidad.Controls.Add(Me.Label7)
        Me.gbUtilidad.Controls.Add(Me.lblDisplayUtilidad)
        Me.gbUtilidad.Controls.Add(Me.lblPorcentajeUtilidad)
        Me.gbUtilidad.Controls.Add(Me.lblUtilidad)
        Me.gbUtilidad.Location = New System.Drawing.Point(715, 193)
        Me.gbUtilidad.Name = "gbUtilidad"
        Me.gbUtilidad.Size = New System.Drawing.Size(167, 45)
        Me.gbUtilidad.TabIndex = 389
        Me.gbUtilidad.TabStop = False
        Me.gbUtilidad.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 13)
        Me.Label7.TabIndex = 390
        Me.Label7.Text = "% :"
        '
        'lblDisplayUtilidad
        '
        Me.lblDisplayUtilidad.AutoSize = True
        Me.lblDisplayUtilidad.Location = New System.Drawing.Point(6, 15)
        Me.lblDisplayUtilidad.Name = "lblDisplayUtilidad"
        Me.lblDisplayUtilidad.Size = New System.Drawing.Size(24, 13)
        Me.lblDisplayUtilidad.TabIndex = 389
        Me.lblDisplayUtilidad.Text = "Ut :"
        '
        'lblPorcentajeUtilidad
        '
        Me.lblPorcentajeUtilidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblPorcentajeUtilidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPorcentajeUtilidad.Location = New System.Drawing.Point(66, 29)
        Me.lblPorcentajeUtilidad.Name = "lblPorcentajeUtilidad"
        Me.lblPorcentajeUtilidad.Size = New System.Drawing.Size(95, 13)
        Me.lblPorcentajeUtilidad.TabIndex = 388
        Me.lblPorcentajeUtilidad.Text = "0.00"
        Me.lblPorcentajeUtilidad.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUtilidad
        '
        Me.lblUtilidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblUtilidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblUtilidad.Location = New System.Drawing.Point(66, 15)
        Me.lblUtilidad.Name = "lblUtilidad"
        Me.lblUtilidad.Size = New System.Drawing.Size(95, 13)
        Me.lblUtilidad.TabIndex = 387
        Me.lblUtilidad.Text = "0.00"
        Me.lblUtilidad.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblConceptoCancelacion
        '
        Me.lblConceptoCancelacion.AutoSize = True
        Me.lblConceptoCancelacion.Location = New System.Drawing.Point(747, 109)
        Me.lblConceptoCancelacion.Name = "lblConceptoCancelacion"
        Me.lblConceptoCancelacion.Size = New System.Drawing.Size(135, 13)
        Me.lblConceptoCancelacion.TabIndex = 385
        Me.lblConceptoCancelacion.Text = "Concepto de cancelación :"
        '
        'TxtConceptoCancelacion
        '
        Me.TxtConceptoCancelacion.Location = New System.Drawing.Point(749, 128)
        Me.TxtConceptoCancelacion.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtConceptoCancelacion.MaxLength = 120
        Me.TxtConceptoCancelacion.Multiline = True
        Me.TxtConceptoCancelacion.Name = "TxtConceptoCancelacion"
        Me.TxtConceptoCancelacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConceptoCancelacion.Size = New System.Drawing.Size(227, 54)
        Me.TxtConceptoCancelacion.TabIndex = 384
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(84, 165)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(205, 21)
        Me.cboFormaPago.TabIndex = 9
        '
        'lblVersionCFDI
        '
        Me.lblVersionCFDI.AutoSize = True
        Me.lblVersionCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionCFDI.Location = New System.Drawing.Point(931, 186)
        Me.lblVersionCFDI.Name = "lblVersionCFDI"
        Me.lblVersionCFDI.Size = New System.Drawing.Size(34, 20)
        Me.lblVersionCFDI.TabIndex = 383
        Me.lblVersionCFDI.Text = "0.0"
        '
        'cboUsoCFDI
        '
        Me.cboUsoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsoCFDI.FormattingEnabled = True
        Me.cboUsoCFDI.Location = New System.Drawing.Point(422, 113)
        Me.cboUsoCFDI.MaxLength = 1
        Me.cboUsoCFDI.Name = "cboUsoCFDI"
        Me.cboUsoCFDI.Size = New System.Drawing.Size(301, 21)
        Me.cboUsoCFDI.TabIndex = 14
        '
        'lblDisplayMetodoPago
        '
        Me.lblDisplayMetodoPago.AutoSize = True
        Me.lblDisplayMetodoPago.Location = New System.Drawing.Point(328, 169)
        Me.lblDisplayMetodoPago.Name = "lblDisplayMetodoPago"
        Me.lblDisplayMetodoPago.Size = New System.Drawing.Size(91, 13)
        Me.lblDisplayMetodoPago.TabIndex = 382
        Me.lblDisplayMetodoPago.Text = "Método de pago :"
        '
        'cboMetodoPago
        '
        Me.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMetodoPago.Enabled = False
        Me.cboMetodoPago.FormattingEnabled = True
        Me.cboMetodoPago.Location = New System.Drawing.Point(422, 166)
        Me.cboMetodoPago.MaxLength = 1
        Me.cboMetodoPago.Name = "cboMetodoPago"
        Me.cboMetodoPago.Size = New System.Drawing.Size(301, 21)
        Me.cboMetodoPago.TabIndex = 15
        '
        'lblDisplayUsoCFDI
        '
        Me.lblDisplayUsoCFDI.AutoSize = True
        Me.lblDisplayUsoCFDI.Location = New System.Drawing.Point(328, 118)
        Me.lblDisplayUsoCFDI.Name = "lblDisplayUsoCFDI"
        Me.lblDisplayUsoCFDI.Size = New System.Drawing.Size(76, 13)
        Me.lblDisplayUsoCFDI.TabIndex = 381
        Me.lblDisplayUsoCFDI.Text = "Uso del CFDI :"
        '
        'CboTipoCredito
        '
        Me.CboTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCredito.FormattingEnabled = True
        Me.CboTipoCredito.Location = New System.Drawing.Point(715, 86)
        Me.CboTipoCredito.Name = "CboTipoCredito"
        Me.CboTipoCredito.Size = New System.Drawing.Size(205, 21)
        Me.CboTipoCredito.TabIndex = 20
        '
        'lblTipoCredito
        '
        Me.lblTipoCredito.AutoSize = True
        Me.lblTipoCredito.Location = New System.Drawing.Point(639, 88)
        Me.lblTipoCredito.Name = "lblTipoCredito"
        Me.lblTipoCredito.Size = New System.Drawing.Size(69, 13)
        Me.lblTipoCredito.TabIndex = 376
        Me.lblTipoCredito.Text = "Tipo crédito :"
        '
        'LblDisplayMoneda
        '
        Me.LblDisplayMoneda.AutoSize = True
        Me.LblDisplayMoneda.Location = New System.Drawing.Point(2, 115)
        Me.LblDisplayMoneda.Name = "LblDisplayMoneda"
        Me.LblDisplayMoneda.Size = New System.Drawing.Size(52, 13)
        Me.LblDisplayMoneda.TabIndex = 374
        Me.LblDisplayMoneda.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(84, 113)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(83, 21)
        Me.cboMoneda.TabIndex = 6
        '
        'btnFacturaSiguiente
        '
        Me.btnFacturaSiguiente.Location = New System.Drawing.Point(235, 41)
        Me.btnFacturaSiguiente.Name = "btnFacturaSiguiente"
        Me.btnFacturaSiguiente.Size = New System.Drawing.Size(54, 21)
        Me.btnFacturaSiguiente.TabIndex = 372
        Me.btnFacturaSiguiente.Text = ">>"
        Me.btnFacturaSiguiente.UseVisualStyleBackColor = True
        '
        'btnFacturaAnterior
        '
        Me.btnFacturaAnterior.Location = New System.Drawing.Point(170, 41)
        Me.btnFacturaAnterior.Name = "btnFacturaAnterior"
        Me.btnFacturaAnterior.Size = New System.Drawing.Size(54, 21)
        Me.btnFacturaAnterior.TabIndex = 371
        Me.btnFacturaAnterior.Text = "<<"
        Me.btnFacturaAnterior.UseVisualStyleBackColor = True
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(170, 116)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblDisplayTipoCambio.TabIndex = 332
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(256, 115)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(66, 20)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumeroCuentaPago
        '
        Me.txtNumeroCuentaPago.Location = New System.Drawing.Point(421, 37)
        Me.txtNumeroCuentaPago.MaxLength = 4
        Me.txtNumeroCuentaPago.Name = "txtNumeroCuentaPago"
        Me.txtNumeroCuentaPago.Size = New System.Drawing.Size(90, 20)
        Me.txtNumeroCuentaPago.TabIndex = 11
        '
        'lblDisplayNumeroCuentaPago
        '
        Me.lblDisplayNumeroCuentaPago.AutoSize = True
        Me.lblDisplayNumeroCuentaPago.Location = New System.Drawing.Point(328, 41)
        Me.lblDisplayNumeroCuentaPago.Name = "lblDisplayNumeroCuentaPago"
        Me.lblDisplayNumeroCuentaPago.Size = New System.Drawing.Size(89, 13)
        Me.lblDisplayNumeroCuentaPago.TabIndex = 337
        Me.lblDisplayNumeroCuentaPago.Text = "Num. de cuenta :"
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.Location = New System.Drawing.Point(2, 169)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(84, 13)
        Me.lblFormaPago.TabIndex = 335
        Me.lblFormaPago.Text = "Forma de pago :"
        '
        'llblAgregarSeguimiento
        '
        Me.llblAgregarSeguimiento.AutoSize = True
        Me.llblAgregarSeguimiento.Location = New System.Drawing.Point(640, 146)
        Me.llblAgregarSeguimiento.Name = "llblAgregarSeguimiento"
        Me.llblAgregarSeguimiento.Size = New System.Drawing.Size(103, 13)
        Me.llblAgregarSeguimiento.TabIndex = 333
        Me.llblAgregarSeguimiento.TabStop = True
        Me.llblAgregarSeguimiento.Text = "Agregar seguimiento"
        '
        'txtFolioEmbarque
        '
        Me.txtFolioEmbarque.Location = New System.Drawing.Point(715, 62)
        Me.txtFolioEmbarque.MaxLength = 60
        Me.txtFolioEmbarque.Name = "txtFolioEmbarque"
        Me.txtFolioEmbarque.Size = New System.Drawing.Size(90, 20)
        Me.txtFolioEmbarque.TabIndex = 19
        '
        'lblDisplayFolioEmbarque
        '
        Me.lblDisplayFolioEmbarque.AutoSize = True
        Me.lblDisplayFolioEmbarque.Location = New System.Drawing.Point(640, 66)
        Me.lblDisplayFolioEmbarque.Name = "lblDisplayFolioEmbarque"
        Me.lblDisplayFolioEmbarque.Size = New System.Drawing.Size(70, 13)
        Me.lblDisplayFolioEmbarque.TabIndex = 332
        Me.lblDisplayFolioEmbarque.Text = "Folio embar. :"
        '
        'gbTotales
        '
        Me.gbTotales.Controls.Add(Me.lblDisplayIEPSIncluido_USD)
        Me.gbTotales.Controls.Add(Me.lblDisplayIEPSIncluido)
        Me.gbTotales.Controls.Add(Me.lblSaldoDolares)
        Me.gbTotales.Controls.Add(Me.lblDisplaySaldoDolares)
        Me.gbTotales.Controls.Add(Me.lblIEPSIncluido_USD)
        Me.gbTotales.Controls.Add(Me.txtUUID)
        Me.gbTotales.Controls.Add(Me.lblUUID)
        Me.gbTotales.Controls.Add(Me.Label1)
        Me.gbTotales.Controls.Add(Me.lblIEPSIncluido)
        Me.gbTotales.Controls.Add(Me.btnSeries)
        Me.gbTotales.Controls.Add(Me.btnAgregaAddenda)
        Me.gbTotales.Controls.Add(Me.LblPoliza)
        Me.gbTotales.Controls.Add(Me.gbPesos)
        Me.gbTotales.Controls.Add(Me.lblDisplayStatus)
        Me.gbTotales.Controls.Add(Me.LblEstatus)
        Me.gbTotales.Controls.Add(Me.lblDisplayPoliza)
        Me.gbTotales.Controls.Add(Me.lblSaldo)
        Me.gbTotales.Controls.Add(Me.lblDisplaySaldo)
        Me.gbTotales.Controls.Add(Me.gbDolares)
        Me.gbTotales.Location = New System.Drawing.Point(9, 520)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Size = New System.Drawing.Size(986, 132)
        Me.gbTotales.TabIndex = 3
        Me.gbTotales.TabStop = False
        '
        'lblDisplayIEPSIncluido_USD
        '
        Me.lblDisplayIEPSIncluido_USD.AutoSize = True
        Me.lblDisplayIEPSIncluido_USD.Location = New System.Drawing.Point(941, 48)
        Me.lblDisplayIEPSIncluido_USD.Name = "lblDisplayIEPSIncluido_USD"
        Me.lblDisplayIEPSIncluido_USD.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayIEPSIncluido_USD.TabIndex = 390
        Me.lblDisplayIEPSIncluido_USD.Text = "USD"
        '
        'lblDisplayIEPSIncluido
        '
        Me.lblDisplayIEPSIncluido.AutoSize = True
        Me.lblDisplayIEPSIncluido.Location = New System.Drawing.Point(941, 32)
        Me.lblDisplayIEPSIncluido.Name = "lblDisplayIEPSIncluido"
        Me.lblDisplayIEPSIncluido.Size = New System.Drawing.Size(31, 13)
        Me.lblDisplayIEPSIncluido.TabIndex = 389
        Me.lblDisplayIEPSIncluido.Text = "MXN"
        '
        'lblSaldoDolares
        '
        Me.lblSaldoDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSaldoDolares.ForeColor = System.Drawing.Color.Crimson
        Me.lblSaldoDolares.Location = New System.Drawing.Point(213, 32)
        Me.lblSaldoDolares.Name = "lblSaldoDolares"
        Me.lblSaldoDolares.Size = New System.Drawing.Size(107, 13)
        Me.lblSaldoDolares.TabIndex = 388
        Me.lblSaldoDolares.Text = "0.00"
        Me.lblSaldoDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblSaldoDolares.Visible = False
        '
        'lblDisplaySaldoDolares
        '
        Me.lblDisplaySaldoDolares.AutoSize = True
        Me.lblDisplaySaldoDolares.Location = New System.Drawing.Point(140, 32)
        Me.lblDisplaySaldoDolares.Name = "lblDisplaySaldoDolares"
        Me.lblDisplaySaldoDolares.Size = New System.Drawing.Size(66, 13)
        Me.lblDisplaySaldoDolares.TabIndex = 387
        Me.lblDisplaySaldoDolares.Text = "Saldo USD :"
        Me.lblDisplaySaldoDolares.Visible = False
        '
        'lblIEPSIncluido_USD
        '
        Me.lblIEPSIncluido_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPSIncluido_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPSIncluido_USD.Location = New System.Drawing.Point(825, 48)
        Me.lblIEPSIncluido_USD.Name = "lblIEPSIncluido_USD"
        Me.lblIEPSIncluido_USD.Size = New System.Drawing.Size(110, 13)
        Me.lblIEPSIncluido_USD.TabIndex = 386
        Me.lblIEPSIncluido_USD.Text = "0.00"
        Me.lblIEPSIncluido_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtUUID
        '
        Me.txtUUID.Location = New System.Drawing.Point(53, 103)
        Me.txtUUID.MaxLength = 15
        Me.txtUUID.Name = "txtUUID"
        Me.txtUUID.ReadOnly = True
        Me.txtUUID.Size = New System.Drawing.Size(256, 20)
        Me.txtUUID.TabIndex = 385
        '
        'lblUUID
        '
        Me.lblUUID.AutoSize = True
        Me.lblUUID.Location = New System.Drawing.Point(6, 105)
        Me.lblUUID.Name = "lblUUID"
        Me.lblUUID.Size = New System.Drawing.Size(40, 13)
        Me.lblUUID.TabIndex = 384
        Me.lblUUID.Text = "UUID :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(888, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 383
        Me.Label1.Text = "IEPS Incluido :"
        '
        'lblIEPSIncluido
        '
        Me.lblIEPSIncluido.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPSIncluido.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPSIncluido.Location = New System.Drawing.Point(825, 32)
        Me.lblIEPSIncluido.Name = "lblIEPSIncluido"
        Me.lblIEPSIncluido.Size = New System.Drawing.Size(110, 13)
        Me.lblIEPSIncluido.TabIndex = 382
        Me.lblIEPSIncluido.Text = "0.00"
        Me.lblIEPSIncluido.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSeries
        '
        Me.btnSeries.Location = New System.Drawing.Point(9, 65)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(109, 32)
        Me.btnSeries.TabIndex = 381
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        '
        'btnAgregaAddenda
        '
        Me.btnAgregaAddenda.Location = New System.Drawing.Point(852, 72)
        Me.btnAgregaAddenda.Name = "btnAgregaAddenda"
        Me.btnAgregaAddenda.Size = New System.Drawing.Size(113, 23)
        Me.btnAgregaAddenda.TabIndex = 339
        Me.btnAgregaAddenda.Text = "Addenda soriana"
        Me.btnAgregaAddenda.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(60, 42)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(13, 13)
        Me.LblPoliza.TabIndex = 330
        Me.LblPoliza.TabStop = True
        Me.LblPoliza.Text = "_"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpArticulos)
        Me.TabControl1.Controls.Add(Me.tpSeries)
        Me.TabControl1.Controls.Add(Me.tpCFDIsRelacionados)
        Me.TabControl1.Controls.Add(Me.tpFacturasRemisiones)
        Me.TabControl1.Location = New System.Drawing.Point(8, 275)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1273, 238)
        Me.TabControl1.TabIndex = 2
        '
        'tpArticulos
        '
        Me.tpArticulos.Controls.Add(Me.btnAgregarRenglon)
        Me.tpArticulos.Controls.Add(Me.Grid)
        Me.tpArticulos.Location = New System.Drawing.Point(4, 22)
        Me.tpArticulos.Name = "tpArticulos"
        Me.tpArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpArticulos.Size = New System.Drawing.Size(1265, 212)
        Me.tpArticulos.TabIndex = 0
        Me.tpArticulos.Text = "Artículos"
        Me.tpArticulos.UseVisualStyleBackColor = True
        '
        'btnAgregarRenglon
        '
        Me.btnAgregarRenglon.Location = New System.Drawing.Point(3, 189)
        Me.btnAgregarRenglon.Name = "btnAgregarRenglon"
        Me.btnAgregarRenglon.Size = New System.Drawing.Size(17, 20)
        Me.btnAgregarRenglon.TabIndex = 373
        Me.btnAgregarRenglon.Text = "+"
        Me.btnAgregarRenglon.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregarRenglon.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DefaultRowHeight = CType(24, Short)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(3, 6)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(1256, 204)
        Me.Grid.TabIndex = 2
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpSeries
        '
        Me.tpSeries.Controls.Add(Me.btnMostrarMasColumnasGridSeries)
        Me.tpSeries.Controls.Add(Me.GridSeries)
        Me.tpSeries.Location = New System.Drawing.Point(4, 22)
        Me.tpSeries.Name = "tpSeries"
        Me.tpSeries.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSeries.Size = New System.Drawing.Size(1265, 212)
        Me.tpSeries.TabIndex = 1
        Me.tpSeries.Text = "Series"
        Me.tpSeries.UseVisualStyleBackColor = True
        '
        'btnMostrarMasColumnasGridSeries
        '
        Me.btnMostrarMasColumnasGridSeries.Location = New System.Drawing.Point(1233, 183)
        Me.btnMostrarMasColumnasGridSeries.Name = "btnMostrarMasColumnasGridSeries"
        Me.btnMostrarMasColumnasGridSeries.Size = New System.Drawing.Size(29, 21)
        Me.btnMostrarMasColumnasGridSeries.TabIndex = 374
        Me.btnMostrarMasColumnasGridSeries.Text = "+"
        Me.btnMostrarMasColumnasGridSeries.UseVisualStyleBackColor = True
        '
        'GridSeries
        '
        Me.GridSeries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridSeries.CheckedImage = CType(resources.GetObject("GridSeries.CheckedImage"), System.Drawing.Bitmap)
        Me.GridSeries.Cols = 1
        Me.GridSeries.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridSeries.DefaultRowHeight = CType(24, Short)
        Me.GridSeries.DisplayRowNumber = True
        Me.GridSeries.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSeries.Location = New System.Drawing.Point(5, 6)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(1222, 198)
        Me.GridSeries.TabIndex = 2
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpCFDIsRelacionados
        '
        Me.tpCFDIsRelacionados.Controls.Add(Me.GridCFDIsRelacionados)
        Me.tpCFDIsRelacionados.Controls.Add(Me.Label3)
        Me.tpCFDIsRelacionados.Controls.Add(Me.cboTipoRelacionCFDI)
        Me.tpCFDIsRelacionados.Location = New System.Drawing.Point(4, 22)
        Me.tpCFDIsRelacionados.Name = "tpCFDIsRelacionados"
        Me.tpCFDIsRelacionados.Size = New System.Drawing.Size(1265, 212)
        Me.tpCFDIsRelacionados.TabIndex = 2
        Me.tpCFDIsRelacionados.Text = "Relacionar CFDIs"
        Me.tpCFDIsRelacionados.UseVisualStyleBackColor = True
        '
        'GridCFDIsRelacionados
        '
        Me.GridCFDIsRelacionados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCFDIsRelacionados.CheckedImage = CType(resources.GetObject("GridCFDIsRelacionados.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCFDIsRelacionados.Cols = 1
        Me.GridCFDIsRelacionados.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCFDIsRelacionados.DefaultRowHeight = CType(24, Short)
        Me.GridCFDIsRelacionados.DisplayRowNumber = True
        Me.GridCFDIsRelacionados.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCFDIsRelacionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCFDIsRelacionados.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCFDIsRelacionados.Location = New System.Drawing.Point(5, 46)
        Me.GridCFDIsRelacionados.LockButton = True
        Me.GridCFDIsRelacionados.Name = "GridCFDIsRelacionados"
        Me.GridCFDIsRelacionados.Rows = 3
        Me.GridCFDIsRelacionados.Size = New System.Drawing.Size(956, 160)
        Me.GridCFDIsRelacionados.TabIndex = 385
        Me.GridCFDIsRelacionados.UncheckedImage = CType(resources.GetObject("GridCFDIsRelacionados.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 384
        Me.Label3.Text = "Tipo relación CFDI :"
        '
        'cboTipoRelacionCFDI
        '
        Me.cboTipoRelacionCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRelacionCFDI.Enabled = False
        Me.cboTipoRelacionCFDI.FormattingEnabled = True
        Me.cboTipoRelacionCFDI.Location = New System.Drawing.Point(112, 19)
        Me.cboTipoRelacionCFDI.MaxLength = 1
        Me.cboTipoRelacionCFDI.Name = "cboTipoRelacionCFDI"
        Me.cboTipoRelacionCFDI.Size = New System.Drawing.Size(301, 21)
        Me.cboTipoRelacionCFDI.TabIndex = 383
        '
        'tpFacturasRemisiones
        '
        Me.tpFacturasRemisiones.Controls.Add(Me.btnAceptarRemisionesSeries)
        Me.tpFacturasRemisiones.Controls.Add(Me.btnAceptar)
        Me.tpFacturasRemisiones.Controls.Add(Me.btnCargarRemisiones)
        Me.tpFacturasRemisiones.Controls.Add(Me.GridFacturasVariasRemisiones)
        Me.tpFacturasRemisiones.Location = New System.Drawing.Point(4, 22)
        Me.tpFacturasRemisiones.Margin = New System.Windows.Forms.Padding(2)
        Me.tpFacturasRemisiones.Name = "tpFacturasRemisiones"
        Me.tpFacturasRemisiones.Size = New System.Drawing.Size(1265, 212)
        Me.tpFacturasRemisiones.TabIndex = 3
        Me.tpFacturasRemisiones.Text = "Facturar varias remisiones"
        Me.tpFacturasRemisiones.UseVisualStyleBackColor = True
        '
        'btnAceptarRemisionesSeries
        '
        Me.btnAceptarRemisionesSeries.Location = New System.Drawing.Point(1109, 167)
        Me.btnAceptarRemisionesSeries.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAceptarRemisionesSeries.Name = "btnAceptarRemisionesSeries"
        Me.btnAceptarRemisionesSeries.Size = New System.Drawing.Size(123, 32)
        Me.btnAceptarRemisionesSeries.TabIndex = 6
        Me.btnAceptarRemisionesSeries.Text = "Aceptar(Cargarlas)"
        Me.btnAceptarRemisionesSeries.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(1109, 100)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(123, 32)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar(Cargarlas)"
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'btnCargarRemisiones
        '
        Me.btnCargarRemisiones.Location = New System.Drawing.Point(1109, 33)
        Me.btnCargarRemisiones.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCargarRemisiones.Name = "btnCargarRemisiones"
        Me.btnCargarRemisiones.Size = New System.Drawing.Size(123, 32)
        Me.btnCargarRemisiones.TabIndex = 4
        Me.btnCargarRemisiones.Text = "Listar remisiones"
        Me.btnCargarRemisiones.UseVisualStyleBackColor = True
        '
        'GridFacturasVariasRemisiones
        '
        Me.GridFacturasVariasRemisiones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridFacturasVariasRemisiones.CheckedImage = CType(resources.GetObject("GridFacturasVariasRemisiones.CheckedImage"), System.Drawing.Bitmap)
        Me.GridFacturasVariasRemisiones.Cols = 1
        Me.GridFacturasVariasRemisiones.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridFacturasVariasRemisiones.DefaultRowHeight = CType(24, Short)
        Me.GridFacturasVariasRemisiones.DisplayRowNumber = True
        Me.GridFacturasVariasRemisiones.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridFacturasVariasRemisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridFacturasVariasRemisiones.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridFacturasVariasRemisiones.Location = New System.Drawing.Point(3, 0)
        Me.GridFacturasVariasRemisiones.LockButton = True
        Me.GridFacturasVariasRemisiones.Name = "GridFacturasVariasRemisiones"
        Me.GridFacturasVariasRemisiones.Rows = 6
        Me.GridFacturasVariasRemisiones.Size = New System.Drawing.Size(1101, 211)
        Me.GridFacturasVariasRemisiones.TabIndex = 3
        Me.GridFacturasVariasRemisiones.UncheckedImage = CType(resources.GetObject("GridFacturasVariasRemisiones.UncheckedImage"), System.Drawing.Bitmap)
        '
        'lblDisplayRegimenFiscal
        '
        Me.lblDisplayRegimenFiscal.AutoSize = True
        Me.lblDisplayRegimenFiscal.Location = New System.Drawing.Point(997, 230)
        Me.lblDisplayRegimenFiscal.Name = "lblDisplayRegimenFiscal"
        Me.lblDisplayRegimenFiscal.Size = New System.Drawing.Size(82, 13)
        Me.lblDisplayRegimenFiscal.TabIndex = 384
        Me.lblDisplayRegimenFiscal.Text = "Régimen fiscal :"
        '
        'cboRegimenFiscal
        '
        Me.cboRegimenFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegimenFiscal.FormattingEnabled = True
        Me.cboRegimenFiscal.Location = New System.Drawing.Point(1000, 246)
        Me.cboRegimenFiscal.MaxLength = 1
        Me.cboRegimenFiscal.Name = "cboRegimenFiscal"
        Me.cboRegimenFiscal.Size = New System.Drawing.Size(281, 21)
        Me.cboRegimenFiscal.TabIndex = 1
        '
        'btnTimbradoTrasladoPrueba
        '
        Me.btnTimbradoTrasladoPrueba.Location = New System.Drawing.Point(1130, 562)
        Me.btnTimbradoTrasladoPrueba.Name = "btnTimbradoTrasladoPrueba"
        Me.btnTimbradoTrasladoPrueba.Size = New System.Drawing.Size(148, 32)
        Me.btnTimbradoTrasladoPrueba.TabIndex = 385
        Me.btnTimbradoTrasladoPrueba.Text = "TimbradoTrasladoPrueba"
        Me.btnTimbradoTrasladoPrueba.UseVisualStyleBackColor = True
        '
        'btnCartaPorte
        '
        Me.btnCartaPorte.Location = New System.Drawing.Point(1001, 187)
        Me.btnCartaPorte.Name = "btnCartaPorte"
        Me.btnCartaPorte.Size = New System.Drawing.Size(148, 32)
        Me.btnCartaPorte.TabIndex = 386
        Me.btnCartaPorte.Text = "Carta porte"
        Me.btnCartaPorte.UseVisualStyleBackColor = True
        Me.btnCartaPorte.Visible = False
        '
        'chkTieneCartaPorte
        '
        Me.chkTieneCartaPorte.AutoSize = True
        Me.chkTieneCartaPorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTieneCartaPorte.Location = New System.Drawing.Point(1001, 165)
        Me.chkTieneCartaPorte.Name = "chkTieneCartaPorte"
        Me.chkTieneCartaPorte.Size = New System.Drawing.Size(212, 20)
        Me.chkTieneCartaPorte.TabIndex = 387
        Me.chkTieneCartaPorte.Text = "Complemento carta porte ?"
        Me.chkTieneCartaPorte.UseVisualStyleBackColor = True
        Me.chkTieneCartaPorte.Visible = False
        '
        'chkTieneCCE
        '
        Me.chkTieneCCE.AutoSize = True
        Me.chkTieneCCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTieneCCE.Location = New System.Drawing.Point(1000, 69)
        Me.chkTieneCCE.Name = "chkTieneCCE"
        Me.chkTieneCCE.Size = New System.Drawing.Size(257, 20)
        Me.chkTieneCCE.TabIndex = 388
        Me.chkTieneCCE.Text = "Complemento comercio exterior ?"
        Me.chkTieneCCE.UseVisualStyleBackColor = True
        Me.chkTieneCCE.Visible = False
        '
        'cboIncoterm
        '
        Me.cboIncoterm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIncoterm.Enabled = False
        Me.cboIncoterm.FormattingEnabled = True
        Me.cboIncoterm.Location = New System.Drawing.Point(1000, 106)
        Me.cboIncoterm.MaxLength = 1
        Me.cboIncoterm.Name = "cboIncoterm"
        Me.cboIncoterm.Size = New System.Drawing.Size(281, 21)
        Me.cboIncoterm.TabIndex = 389
        Me.cboIncoterm.Visible = False
        '
        'lblDisplayIncoterm
        '
        Me.lblDisplayIncoterm.AutoSize = True
        Me.lblDisplayIncoterm.Location = New System.Drawing.Point(997, 90)
        Me.lblDisplayIncoterm.Name = "lblDisplayIncoterm"
        Me.lblDisplayIncoterm.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayIncoterm.TabIndex = 390
        Me.lblDisplayIncoterm.Text = "Incoterm :"
        Me.lblDisplayIncoterm.Visible = False
        '
        'Ventas_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1287, 678)
        Me.Controls.Add(Me.lblDisplayIncoterm)
        Me.Controls.Add(Me.cboIncoterm)
        Me.Controls.Add(Me.chkTieneCCE)
        Me.Controls.Add(Me.chkTieneCartaPorte)
        Me.Controls.Add(Me.btnCartaPorte)
        Me.Controls.Add(Me.btnTimbradoTrasladoPrueba)
        Me.Controls.Add(Me.lblDisplayRegimenFiscal)
        Me.Controls.Add(Me.cboRegimenFiscal)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.frmDatos)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Ventas_Movimientos"
        Me.Text = "Documentos de Ventas"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbPesos.ResumeLayout(False)
        Me.gbPesos.PerformLayout()
        Me.gbDolares.ResumeLayout(False)
        Me.gbDolares.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.frmDatos.ResumeLayout(False)
        Me.frmDatos.PerformLayout()
        Me.gbUtilidad.ResumeLayout(False)
        Me.gbUtilidad.PerformLayout()
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpArticulos.ResumeLayout(False)
        Me.tpSeries.ResumeLayout(False)
        Me.tpCFDIsRelacionados.ResumeLayout(False)
        Me.tpCFDIsRelacionados.PerformLayout()
        Me.tpFacturasRemisiones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents dpVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayVencimiento As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCobrador As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDireccionEmpresa As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayReferencia As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySubtotalPesos As System.Windows.Forms.Label
    Friend WithEvents lblDisplayImpuestoPesos As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalPesos As System.Windows.Forms.Label
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblDisplayTipoSocio As System.Windows.Forms.Label
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayPoliza As System.Windows.Forms.Label
    Friend WithEvents lblDisplayMercado As System.Windows.Forms.Label
    Friend WithEvents cboTipoMercado As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoNegociacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTipo As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayVendedor As System.Windows.Forms.Label
    Friend WithEvents chkVentaPublicoGeneral As System.Windows.Forms.CheckBox
    Friend WithEvents gbPesos As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents lblImpuesto As System.Windows.Forms.Label
    Friend WithEvents gbDolares As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotal_USD As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal_USD As System.Windows.Forms.Label
    Friend WithEvents lblImpuesto_USD As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotal_USD As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySubtotal_USD As System.Windows.Forms.Label
    Friend WithEvents lblDisplayImpuesto_USD As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySaldo As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents frmDatos As System.Windows.Forms.GroupBox
    Friend WithEvents gbTotales As System.Windows.Forms.GroupBox
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents lblDisplayTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents tsbCotizacionRemision As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRemisionVenta As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCotizacionFactura As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbTimbrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtFolioEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioEmbarque As System.Windows.Forms.Label
    Friend WithEvents llblAgregarSeguimiento As System.Windows.Forms.LinkLabel
    Friend WithEvents lblFormaPago As System.Windows.Forms.Label
    Friend WithEvents cboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumeroCuentaPago As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumeroCuentaPago As System.Windows.Forms.Label
    Friend WithEvents btnAgregaAddenda As System.Windows.Forms.Button
    Friend WithEvents tsbCancelarTimbre As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFacturaSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnFacturaAnterior As System.Windows.Forms.Button
    Friend WithEvents tsbEnviarCorreo As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpArticulos As System.Windows.Forms.TabPage
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents tpSeries As System.Windows.Forms.TabPage
    Friend WithEvents GridSeries As FlexCell.Grid
    Friend WithEvents btnSeries As System.Windows.Forms.Button
    Friend WithEvents lblIEPS As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblIEPSIncluido As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayMoneda As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents ckbMostrarUtilidad As System.Windows.Forms.CheckBox
    Friend WithEvents CboTipoCredito As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoCredito As System.Windows.Forms.Label
    Friend WithEvents cboUsoCFDI As ComboBox
    Friend WithEvents lblDisplayMetodoPago As Label
    Friend WithEvents cboMetodoPago As ComboBox
    Friend WithEvents lblDisplayUsoCFDI As Label
    Friend WithEvents lblVersionCFDI As Label
    Friend WithEvents tsbRecuperarXMLPDF As ToolStripButton
    Friend WithEvents lblConceptoCancelacion As System.Windows.Forms.Label
    Friend WithEvents TxtConceptoCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents tpCFDIsRelacionados As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents cboTipoRelacionCFDI As ComboBox
    Friend WithEvents GridCFDIsRelacionados As FlexCell.Grid
    Friend WithEvents lblDisplayDescuento As Label
    Friend WithEvents lblDescuento As Label
    Friend WithEvents txtUUID As TextBox
    Friend WithEvents lblUUID As Label
    Friend WithEvents tsbSubirXML As ToolStripButton
    Friend WithEvents lblDisplayRetencionIVA As System.Windows.Forms.Label
    Friend WithEvents lblTotalRetencionIVA As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalRetencionIVA_USD As Label
    Friend WithEvents lblTotalRetencionIVA_USD As Label
    Friend WithEvents lblDisplayDescuento_USD As Label
    Friend WithEvents lblDescuento_USD As Label
    Friend WithEvents lblIEPS_USD As Label
    Friend WithEvents lblDisplayIEPS_USD As Label
    Friend WithEvents lblIEPSIncluido_USD As Label
    Friend WithEvents lblSaldoDolares As Label
    Friend WithEvents lblDisplaySaldoDolares As Label
    Friend WithEvents lblDisplayIEPSIncluido_USD As Label
    Friend WithEvents lblDisplayIEPSIncluido As Label
    Friend WithEvents tpFacturasRemisiones As System.Windows.Forms.TabPage
    Friend WithEvents GridFacturasVariasRemisiones As FlexCell.Grid
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCargarRemisiones As System.Windows.Forms.Button
    Friend WithEvents gbUtilidad As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblDisplayUtilidad As Label
    Friend WithEvents lblPorcentajeUtilidad As Label
    Friend WithEvents lblUtilidad As Label
    Friend WithEvents lblDisplayRetencionISR As Label
    Friend WithEvents lblTotalRetencionISR As Label
    Friend WithEvents lblDisplayTotalRetencionISR_USD As Label
    Friend WithEvents lblTotalRetencionISR_USD As Label
    Friend WithEvents lblDisplayRegimenFiscal As Label
    Friend WithEvents cboRegimenFiscal As ComboBox
    Friend WithEvents btnTimbradoTrasladoPrueba As Button
    Friend WithEvents btnCartaPorte As Button
    Friend WithEvents tsbFacturaACartaPorte As ToolStripButton
    Friend WithEvents chkTieneCartaPorte As CheckBox
    Friend WithEvents btnAceptarRemisionesSeries As Button
    Friend WithEvents btnAgregarRenglon As Button
    Friend WithEvents btnMostrarMasColumnasGridSeries As Button
    Friend WithEvents chkTieneCCE As CheckBox
    Friend WithEvents cboIncoterm As ComboBox
    Friend WithEvents lblDisplayIncoterm As Label
End Class
