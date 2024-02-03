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
        Me.lblDisplayRegimenFiscalReceptor = New System.Windows.Forms.Label()
        Me.txtRegimenFiscalReceptor = New System.Windows.Forms.TextBox()
        Me.lblRegimenFiscalReceptor = New System.Windows.Forms.Label()
        Me.txtUsoCFDI = New System.Windows.Forms.TextBox()
        Me.lblUsoCFDI = New System.Windows.Forms.Label()
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
        Me.tpComplementoINE = New System.Windows.Forms.TabPage()
        Me.GbEntidades = New System.Windows.Forms.GroupBox()
        Me.BtnAgregarEntidad = New System.Windows.Forms.Button()
        Me.TxtIdContabilidadEntidad = New System.Windows.Forms.TextBox()
        Me.CboAmbito = New System.Windows.Forms.ComboBox()
        Me.CboEntidad = New System.Windows.Forms.ComboBox()
        Me.LblClaveContabilidadEntidad = New System.Windows.Forms.Label()
        Me.LblAmbito = New System.Windows.Forms.Label()
        Me.LblEntidad = New System.Windows.Forms.Label()
        Me.TxtIdContabilidad = New System.Windows.Forms.TextBox()
        Me.CboTipoComite = New System.Windows.Forms.ComboBox()
        Me.LblClaveContabilidad = New System.Windows.Forms.Label()
        Me.LblTipoComite = New System.Windows.Forms.Label()
        Me.LblTipoProceso = New System.Windows.Forms.Label()
        Me.CboTipoProceso = New System.Windows.Forms.ComboBox()
        Me.GridEntidades = New FlexCell.Grid()
        Me.lblDisplayRegimenFiscalEmisor = New System.Windows.Forms.Label()
        Me.cboRegimenFiscalEmisor = New System.Windows.Forms.ComboBox()
        Me.lblDisplayIncoterm = New System.Windows.Forms.Label()
        Me.cboIncoterm = New System.Windows.Forms.ComboBox()
        Me.chkTieneCCE = New System.Windows.Forms.CheckBox()
        Me.chkTieneCartaPorte = New System.Windows.Forms.CheckBox()
        Me.btnCartaPorte = New System.Windows.Forms.Button()
        Me.btnTimbradoTrasladoPrueba = New System.Windows.Forms.Button()
        Me.btnEliminarDatosINE = New System.Windows.Forms.Button()
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
        Me.tpComplementoINE.SuspendLayout()
        Me.GbEntidades.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(71, 20)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(12, 17)
        Me.LblEstatus.TabIndex = 226
        Me.LblEstatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(8, 20)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 225
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(112, 50)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(109, 22)
        Me.txtFolio.TabIndex = 2
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(3, 54)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 224
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbCancelar, Me.tsbCotizacionRemision, Me.tsbCotizacionFactura, Me.tsbRemisionVenta, Me.tsbFacturaACartaPorte, Me.tsbCancelarTimbre, Me.tsbTimbrar, Me.tsbRecuperarXMLPDF, Me.tsbEnviarCorreo, Me.tsbSubirXML, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1720, 27)
        Me.tsMenu.TabIndex = 4
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(76, 24)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(78, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(90, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(94, 24)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbCotizacionRemision
        '
        Me.tsbCotizacionRemision.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbCotizacionRemision.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCotizacionRemision.Name = "tsbCotizacionRemision"
        Me.tsbCotizacionRemision.Size = New System.Drawing.Size(176, 24)
        Me.tsbCotizacionRemision.Text = "&Cotización a remisión"
        Me.tsbCotizacionRemision.Visible = False
        '
        'tsbCotizacionFactura
        '
        Me.tsbCotizacionFactura.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbCotizacionFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCotizacionFactura.Name = "tsbCotizacionFactura"
        Me.tsbCotizacionFactura.Size = New System.Drawing.Size(165, 24)
        Me.tsbCotizacionFactura.Text = "&Cotización a factura"
        Me.tsbCotizacionFactura.Visible = False
        '
        'tsbRemisionVenta
        '
        Me.tsbRemisionVenta.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbRemisionVenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRemisionVenta.Name = "tsbRemisionVenta"
        Me.tsbRemisionVenta.Size = New System.Drawing.Size(146, 24)
        Me.tsbRemisionVenta.Text = "&Remisión a venta"
        Me.tsbRemisionVenta.Visible = False
        '
        'tsbFacturaACartaPorte
        '
        Me.tsbFacturaACartaPorte.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbFacturaACartaPorte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFacturaACartaPorte.Name = "tsbFacturaACartaPorte"
        Me.tsbFacturaACartaPorte.Size = New System.Drawing.Size(143, 24)
        Me.tsbFacturaACartaPorte.Text = "Fac a Carta Porte"
        Me.tsbFacturaACartaPorte.Visible = False
        '
        'tsbCancelarTimbre
        '
        Me.tsbCancelarTimbre.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbCancelarTimbre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelarTimbre.Name = "tsbCancelarTimbre"
        Me.tsbCancelarTimbre.Size = New System.Drawing.Size(138, 24)
        Me.tsbCancelarTimbre.Text = "Cancelar timbre"
        Me.tsbCancelarTimbre.Visible = False
        '
        'tsbTimbrar
        '
        Me.tsbTimbrar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbTimbrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTimbrar.Name = "tsbTimbrar"
        Me.tsbTimbrar.Size = New System.Drawing.Size(85, 24)
        Me.tsbTimbrar.Text = "Timbrar"
        Me.tsbTimbrar.Visible = False
        '
        'tsbRecuperarXMLPDF
        '
        Me.tsbRecuperarXMLPDF.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbRecuperarXMLPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecuperarXMLPDF.Name = "tsbRecuperarXMLPDF"
        Me.tsbRecuperarXMLPDF.Size = New System.Drawing.Size(183, 24)
        Me.tsbRecuperarXMLPDF.Text = "Recuperar/ver xml/pdf"
        Me.tsbRecuperarXMLPDF.Visible = False
        '
        'tsbEnviarCorreo
        '
        Me.tsbEnviarCorreo.Image = CType(resources.GetObject("tsbEnviarCorreo.Image"), System.Drawing.Image)
        Me.tsbEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarCorreo.Name = "tsbEnviarCorreo"
        Me.tsbEnviarCorreo.Size = New System.Drawing.Size(120, 24)
        Me.tsbEnviarCorreo.Text = "&Enviar correo"
        '
        'tsbSubirXML
        '
        Me.tsbSubirXML.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbSubirXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSubirXML.Name = "tsbSubirXML"
        Me.tsbSubirXML.Size = New System.Drawing.Size(100, 24)
        Me.tsbSubirXML.Text = "Subir XML"
        Me.tsbSubirXML.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(112, 18)
        Me.CboDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(272, 24)
        Me.CboDocumento.TabIndex = 0
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(3, 23)
        Me.LblDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(88, 17)
        Me.LblDocumento.TabIndex = 221
        Me.LblDocumento.Text = "Documento :"
        '
        'dpFecha
        '
        Me.dpFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dpFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(561, 76)
        Me.dpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(119, 22)
        Me.dpFecha.TabIndex = 15
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(437, 81)
        Me.LblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(55, 17)
        Me.LblFecha.TabIndex = 228
        Me.LblFecha.Text = "Fecha :"
        '
        'dpVencimiento
        '
        Me.dpVencimiento.Cursor = System.Windows.Forms.Cursors.Default
        Me.dpVencimiento.CustomFormat = "dd-MMM-yyyy"
        Me.dpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpVencimiento.Location = New System.Drawing.Point(563, 107)
        Me.dpVencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.dpVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpVencimiento.Name = "dpVencimiento"
        Me.dpVencimiento.Size = New System.Drawing.Size(119, 22)
        Me.dpVencimiento.TabIndex = 16
        '
        'lblDisplayVencimiento
        '
        Me.lblDisplayVencimiento.AutoSize = True
        Me.lblDisplayVencimiento.Location = New System.Drawing.Point(437, 112)
        Me.lblDisplayVencimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayVencimiento.Name = "lblDisplayVencimiento"
        Me.lblDisplayVencimiento.Size = New System.Drawing.Size(93, 17)
        Me.lblDisplayVencimiento.TabIndex = 230
        Me.lblDisplayVencimiento.Text = "Vencimiento :"
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCliente.Location = New System.Drawing.Point(231, 176)
        Me.lblCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(603, 16)
        Me.lblCliente.TabIndex = 233
        Me.lblCliente.Text = "_"
        '
        'LblDisplayCobrador
        '
        Me.LblDisplayCobrador.AutoSize = True
        Me.LblDisplayCobrador.Location = New System.Drawing.Point(3, 175)
        Me.LblDisplayCobrador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCobrador.Name = "LblDisplayCobrador"
        Me.LblDisplayCobrador.Size = New System.Drawing.Size(59, 17)
        Me.LblDisplayCobrador.TabIndex = 232
        Me.LblDisplayCobrador.Text = "Cliente :"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(112, 171)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(109, 22)
        Me.TxtCliente.TabIndex = 8
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(3, 257)
        Me.LblDisplayDireccionEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayDireccionEmpresa.TabIndex = 235
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(112, 257)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 4000
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConcepto.Size = New System.Drawing.Size(819, 36)
        Me.TxtConcepto.TabIndex = 13
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Enabled = False
        Me.TxtReferencia.Location = New System.Drawing.Point(112, 79)
        Me.TxtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtReferencia.MaxLength = 15
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(109, 22)
        Me.TxtReferencia.TabIndex = 3
        '
        'lblDisplayReferencia
        '
        Me.lblDisplayReferencia.AutoSize = True
        Me.lblDisplayReferencia.Location = New System.Drawing.Point(3, 82)
        Me.lblDisplayReferencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayReferencia.Name = "lblDisplayReferencia"
        Me.lblDisplayReferencia.Size = New System.Drawing.Size(85, 17)
        Me.lblDisplayReferencia.TabIndex = 237
        Me.lblDisplayReferencia.Text = "Referencia :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(953, 44)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(272, 24)
        Me.CboAlmacen.TabIndex = 18
        '
        'lblDisplayAlmacen
        '
        Me.lblDisplayAlmacen.AutoSize = True
        Me.lblDisplayAlmacen.Location = New System.Drawing.Point(853, 50)
        Me.lblDisplayAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayAlmacen.Name = "lblDisplayAlmacen"
        Me.lblDisplayAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.lblDisplayAlmacen.TabIndex = 239
        Me.lblDisplayAlmacen.Text = "Almacén :"
        '
        'lblDisplaySubtotalPesos
        '
        Me.lblDisplaySubtotalPesos.AutoSize = True
        Me.lblDisplaySubtotalPesos.Location = New System.Drawing.Point(8, 20)
        Me.lblDisplaySubtotalPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySubtotalPesos.Name = "lblDisplaySubtotalPesos"
        Me.lblDisplaySubtotalPesos.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplaySubtotalPesos.TabIndex = 242
        Me.lblDisplaySubtotalPesos.Text = "Subtotal :"
        '
        'lblDisplayImpuestoPesos
        '
        Me.lblDisplayImpuestoPesos.AutoSize = True
        Me.lblDisplayImpuestoPesos.Location = New System.Drawing.Point(8, 79)
        Me.lblDisplayImpuestoPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayImpuestoPesos.Name = "lblDisplayImpuestoPesos"
        Me.lblDisplayImpuestoPesos.Size = New System.Drawing.Size(37, 17)
        Me.lblDisplayImpuestoPesos.TabIndex = 244
        Me.lblDisplayImpuestoPesos.Text = "IVA :"
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(8, 138)
        Me.lblDisplayTotalPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalPesos.Name = "lblDisplayTotalPesos"
        Me.lblDisplayTotalPesos.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotalPesos.TabIndex = 246
        Me.lblDisplayTotalPesos.Text = "Total :"
        '
        'LblDisplayTipoSocio
        '
        Me.LblDisplayTipoSocio.AutoSize = True
        Me.LblDisplayTipoSocio.Location = New System.Drawing.Point(729, 81)
        Me.LblDisplayTipoSocio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTipoSocio.Name = "LblDisplayTipoSocio"
        Me.LblDisplayTipoSocio.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayTipoSocio.TabIndex = 281
        Me.LblDisplayTipoSocio.Text = "Plazo :"
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(789, 76)
        Me.txtPlazo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlazo.MaxLength = 3
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(43, 22)
        Me.txtPlazo.TabIndex = 10
        '
        'lblDisplayPoliza
        '
        Me.lblDisplayPoliza.AutoSize = True
        Me.lblDisplayPoliza.Location = New System.Drawing.Point(8, 52)
        Me.lblDisplayPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPoliza.Name = "lblDisplayPoliza"
        Me.lblDisplayPoliza.Size = New System.Drawing.Size(54, 17)
        Me.lblDisplayPoliza.TabIndex = 283
        Me.lblDisplayPoliza.Text = "Póliza :"
        '
        'lblDisplayMercado
        '
        Me.lblDisplayMercado.AutoSize = True
        Me.lblDisplayMercado.Location = New System.Drawing.Point(437, 18)
        Me.lblDisplayMercado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayMercado.Name = "lblDisplayMercado"
        Me.lblDisplayMercado.Size = New System.Drawing.Size(71, 17)
        Me.lblDisplayMercado.TabIndex = 285
        Me.lblDisplayMercado.Text = "Mercado :"
        '
        'cboTipoMercado
        '
        Me.cboTipoMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMercado.FormattingEnabled = True
        Me.cboTipoMercado.Location = New System.Drawing.Point(533, 14)
        Me.cboTipoMercado.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoMercado.Name = "cboTipoMercado"
        Me.cboTipoMercado.Size = New System.Drawing.Size(272, 24)
        Me.cboTipoMercado.TabIndex = 1
        '
        'cboTipoNegociacion
        '
        Me.cboTipoNegociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoNegociacion.FormattingEnabled = True
        Me.cboTipoNegociacion.Location = New System.Drawing.Point(112, 108)
        Me.cboTipoNegociacion.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoNegociacion.Name = "cboTipoNegociacion"
        Me.cboTipoNegociacion.Size = New System.Drawing.Size(109, 24)
        Me.cboTipoNegociacion.TabIndex = 5
        '
        'lblDisplayTipo
        '
        Me.lblDisplayTipo.AutoSize = True
        Me.lblDisplayTipo.Location = New System.Drawing.Point(3, 111)
        Me.lblDisplayTipo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipo.Name = "lblDisplayTipo"
        Me.lblDisplayTipo.Size = New System.Drawing.Size(44, 17)
        Me.lblDisplayTipo.TabIndex = 288
        Me.lblDisplayTipo.Text = "Tipo :"
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(953, 15)
        Me.cboVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(272, 24)
        Me.cboVendedor.TabIndex = 17
        '
        'lblDisplayVendedor
        '
        Me.lblDisplayVendedor.AutoSize = True
        Me.lblDisplayVendedor.Location = New System.Drawing.Point(853, 20)
        Me.lblDisplayVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayVendedor.Name = "lblDisplayVendedor"
        Me.lblDisplayVendedor.Size = New System.Drawing.Size(78, 17)
        Me.lblDisplayVendedor.TabIndex = 290
        Me.lblDisplayVendedor.Text = "Vendedor :"
        '
        'chkVentaPublicoGeneral
        '
        Me.chkVentaPublicoGeneral.AutoSize = True
        Me.chkVentaPublicoGeneral.Location = New System.Drawing.Point(227, 84)
        Me.chkVentaPublicoGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.chkVentaPublicoGeneral.Name = "chkVentaPublicoGeneral"
        Me.chkVentaPublicoGeneral.Size = New System.Drawing.Size(183, 21)
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
        Me.gbPesos.Location = New System.Drawing.Point(840, 0)
        Me.gbPesos.Margin = New System.Windows.Forms.Padding(4)
        Me.gbPesos.Name = "gbPesos"
        Me.gbPesos.Padding = New System.Windows.Forms.Padding(4)
        Me.gbPesos.Size = New System.Drawing.Size(252, 160)
        Me.gbPesos.TabIndex = 292
        Me.gbPesos.TabStop = False
        Me.gbPesos.Text = "MXN :"
        '
        'lblDisplayRetencionISR
        '
        Me.lblDisplayRetencionISR.AutoSize = True
        Me.lblDisplayRetencionISR.Location = New System.Drawing.Point(8, 118)
        Me.lblDisplayRetencionISR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetencionISR.Name = "lblDisplayRetencionISR"
        Me.lblDisplayRetencionISR.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplayRetencionISR.TabIndex = 257
        Me.lblDisplayRetencionISR.Text = "Ret. ISR :"
        '
        'lblTotalRetencionISR
        '
        Me.lblTotalRetencionISR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionISR.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionISR.Location = New System.Drawing.Point(93, 118)
        Me.lblTotalRetencionISR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalRetencionISR.Name = "lblTotalRetencionISR"
        Me.lblTotalRetencionISR.Size = New System.Drawing.Size(143, 16)
        Me.lblTotalRetencionISR.TabIndex = 256
        Me.lblTotalRetencionISR.Text = "0.00"
        Me.lblTotalRetencionISR.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayRetencionIVA
        '
        Me.lblDisplayRetencionIVA.AutoSize = True
        Me.lblDisplayRetencionIVA.Location = New System.Drawing.Point(8, 98)
        Me.lblDisplayRetencionIVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetencionIVA.Name = "lblDisplayRetencionIVA"
        Me.lblDisplayRetencionIVA.Size = New System.Drawing.Size(67, 17)
        Me.lblDisplayRetencionIVA.TabIndex = 255
        Me.lblDisplayRetencionIVA.Text = "Ret. IVA :"
        '
        'lblTotalRetencionIVA
        '
        Me.lblTotalRetencionIVA.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionIVA.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionIVA.Location = New System.Drawing.Point(93, 98)
        Me.lblTotalRetencionIVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalRetencionIVA.Name = "lblTotalRetencionIVA"
        Me.lblTotalRetencionIVA.Size = New System.Drawing.Size(143, 16)
        Me.lblTotalRetencionIVA.TabIndex = 254
        Me.lblTotalRetencionIVA.Text = "0.00"
        Me.lblTotalRetencionIVA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayDescuento
        '
        Me.lblDisplayDescuento.AutoSize = True
        Me.lblDisplayDescuento.Location = New System.Drawing.Point(8, 39)
        Me.lblDisplayDescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayDescuento.Name = "lblDisplayDescuento"
        Me.lblDisplayDescuento.Size = New System.Drawing.Size(84, 17)
        Me.lblDisplayDescuento.TabIndex = 253
        Me.lblDisplayDescuento.Text = "Descuento :"
        '
        'lblDescuento
        '
        Me.lblDescuento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDescuento.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDescuento.Location = New System.Drawing.Point(93, 39)
        Me.lblDescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(143, 16)
        Me.lblDescuento.TabIndex = 252
        Me.lblDescuento.Text = "0.00"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIEPS
        '
        Me.lblIEPS.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPS.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPS.Location = New System.Drawing.Point(93, 59)
        Me.lblIEPS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIEPS.Name = "lblIEPS"
        Me.lblIEPS.Size = New System.Drawing.Size(143, 16)
        Me.lblIEPS.TabIndex = 251
        Me.lblIEPS.Text = "0.00"
        Me.lblIEPS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "IEPS :"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal.Location = New System.Drawing.Point(93, 138)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(143, 16)
        Me.lblTotal.TabIndex = 249
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal.Location = New System.Drawing.Point(93, 20)
        Me.lblSubtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(143, 16)
        Me.lblSubtotal.TabIndex = 247
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto.Location = New System.Drawing.Point(93, 79)
        Me.lblImpuesto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(143, 16)
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
        Me.gbDolares.Location = New System.Drawing.Point(599, 0)
        Me.gbDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Size = New System.Drawing.Size(247, 160)
        Me.gbDolares.TabIndex = 293
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "USD :"
        Me.gbDolares.Visible = False
        '
        'lblDisplayTotalRetencionISR_USD
        '
        Me.lblDisplayTotalRetencionISR_USD.AutoSize = True
        Me.lblDisplayTotalRetencionISR_USD.Location = New System.Drawing.Point(1, 118)
        Me.lblDisplayTotalRetencionISR_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalRetencionISR_USD.Name = "lblDisplayTotalRetencionISR_USD"
        Me.lblDisplayTotalRetencionISR_USD.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplayTotalRetencionISR_USD.TabIndex = 263
        Me.lblDisplayTotalRetencionISR_USD.Text = "Ret. ISR :"
        '
        'lblTotalRetencionISR_USD
        '
        Me.lblTotalRetencionISR_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionISR_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionISR_USD.Location = New System.Drawing.Point(91, 118)
        Me.lblTotalRetencionISR_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalRetencionISR_USD.Name = "lblTotalRetencionISR_USD"
        Me.lblTotalRetencionISR_USD.Size = New System.Drawing.Size(143, 16)
        Me.lblTotalRetencionISR_USD.TabIndex = 262
        Me.lblTotalRetencionISR_USD.Text = "0.00"
        Me.lblTotalRetencionISR_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotalRetencionIVA_USD
        '
        Me.lblDisplayTotalRetencionIVA_USD.AutoSize = True
        Me.lblDisplayTotalRetencionIVA_USD.Location = New System.Drawing.Point(1, 98)
        Me.lblDisplayTotalRetencionIVA_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalRetencionIVA_USD.Name = "lblDisplayTotalRetencionIVA_USD"
        Me.lblDisplayTotalRetencionIVA_USD.Size = New System.Drawing.Size(67, 17)
        Me.lblDisplayTotalRetencionIVA_USD.TabIndex = 261
        Me.lblDisplayTotalRetencionIVA_USD.Text = "Ret. IVA :"
        '
        'lblTotalRetencionIVA_USD
        '
        Me.lblTotalRetencionIVA_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalRetencionIVA_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalRetencionIVA_USD.Location = New System.Drawing.Point(91, 98)
        Me.lblTotalRetencionIVA_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalRetencionIVA_USD.Name = "lblTotalRetencionIVA_USD"
        Me.lblTotalRetencionIVA_USD.Size = New System.Drawing.Size(143, 16)
        Me.lblTotalRetencionIVA_USD.TabIndex = 260
        Me.lblTotalRetencionIVA_USD.Text = "0.00"
        Me.lblTotalRetencionIVA_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayDescuento_USD
        '
        Me.lblDisplayDescuento_USD.AutoSize = True
        Me.lblDisplayDescuento_USD.Location = New System.Drawing.Point(1, 39)
        Me.lblDisplayDescuento_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayDescuento_USD.Name = "lblDisplayDescuento_USD"
        Me.lblDisplayDescuento_USD.Size = New System.Drawing.Size(84, 17)
        Me.lblDisplayDescuento_USD.TabIndex = 259
        Me.lblDisplayDescuento_USD.Text = "Descuento :"
        '
        'lblDescuento_USD
        '
        Me.lblDescuento_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblDescuento_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDescuento_USD.Location = New System.Drawing.Point(91, 39)
        Me.lblDescuento_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescuento_USD.Name = "lblDescuento_USD"
        Me.lblDescuento_USD.Size = New System.Drawing.Size(143, 16)
        Me.lblDescuento_USD.TabIndex = 258
        Me.lblDescuento_USD.Text = "0.00"
        Me.lblDescuento_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblIEPS_USD
        '
        Me.lblIEPS_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPS_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPS_USD.Location = New System.Drawing.Point(91, 59)
        Me.lblIEPS_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIEPS_USD.Name = "lblIEPS_USD"
        Me.lblIEPS_USD.Size = New System.Drawing.Size(143, 16)
        Me.lblIEPS_USD.TabIndex = 257
        Me.lblIEPS_USD.Text = "0.00"
        Me.lblIEPS_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayIEPS_USD
        '
        Me.lblDisplayIEPS_USD.AutoSize = True
        Me.lblDisplayIEPS_USD.Location = New System.Drawing.Point(1, 59)
        Me.lblDisplayIEPS_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIEPS_USD.Name = "lblDisplayIEPS_USD"
        Me.lblDisplayIEPS_USD.Size = New System.Drawing.Size(46, 17)
        Me.lblDisplayIEPS_USD.TabIndex = 256
        Me.lblDisplayIEPS_USD.Text = "IEPS :"
        '
        'lblTotal_USD
        '
        Me.lblTotal_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal_USD.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal_USD.Location = New System.Drawing.Point(91, 138)
        Me.lblTotal_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal_USD.Name = "lblTotal_USD"
        Me.lblTotal_USD.Size = New System.Drawing.Size(143, 16)
        Me.lblTotal_USD.TabIndex = 249
        Me.lblTotal_USD.Text = "0.00"
        Me.lblTotal_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal_USD
        '
        Me.lblSubtotal_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal_USD.Location = New System.Drawing.Point(91, 20)
        Me.lblSubtotal_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotal_USD.Name = "lblSubtotal_USD"
        Me.lblSubtotal_USD.Size = New System.Drawing.Size(143, 16)
        Me.lblSubtotal_USD.TabIndex = 247
        Me.lblSubtotal_USD.Text = "0.00"
        Me.lblSubtotal_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto_USD
        '
        Me.lblImpuesto_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto_USD.Location = New System.Drawing.Point(91, 79)
        Me.lblImpuesto_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpuesto_USD.Name = "lblImpuesto_USD"
        Me.lblImpuesto_USD.Size = New System.Drawing.Size(143, 16)
        Me.lblImpuesto_USD.TabIndex = 248
        Me.lblImpuesto_USD.Text = "0.00"
        Me.lblImpuesto_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotal_USD
        '
        Me.lblDisplayTotal_USD.AutoSize = True
        Me.lblDisplayTotal_USD.Location = New System.Drawing.Point(1, 138)
        Me.lblDisplayTotal_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotal_USD.Name = "lblDisplayTotal_USD"
        Me.lblDisplayTotal_USD.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotal_USD.TabIndex = 246
        Me.lblDisplayTotal_USD.Text = "Total :"
        '
        'lblDisplaySubtotal_USD
        '
        Me.lblDisplaySubtotal_USD.AutoSize = True
        Me.lblDisplaySubtotal_USD.Location = New System.Drawing.Point(1, 20)
        Me.lblDisplaySubtotal_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySubtotal_USD.Name = "lblDisplaySubtotal_USD"
        Me.lblDisplaySubtotal_USD.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplaySubtotal_USD.TabIndex = 242
        Me.lblDisplaySubtotal_USD.Text = "Subtotal :"
        '
        'lblDisplayImpuesto_USD
        '
        Me.lblDisplayImpuesto_USD.AutoSize = True
        Me.lblDisplayImpuesto_USD.Location = New System.Drawing.Point(1, 79)
        Me.lblDisplayImpuesto_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayImpuesto_USD.Name = "lblDisplayImpuesto_USD"
        Me.lblDisplayImpuesto_USD.Size = New System.Drawing.Size(37, 17)
        Me.lblDisplayImpuesto_USD.TabIndex = 244
        Me.lblDisplayImpuesto_USD.Text = "IVA :"
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.lblSaldo.Location = New System.Drawing.Point(284, 20)
        Me.lblSaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(143, 16)
        Me.lblSaldo.TabIndex = 298
        Me.lblSaldo.Text = "0.00"
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(187, 20)
        Me.lblDisplaySaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(86, 17)
        Me.lblDisplaySaldo.TabIndex = 297
        Me.lblDisplaySaldo.Text = "Saldo MXN :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 805)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1720, 29)
        Me.StatusStripEstado.TabIndex = 315
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tsslEstado
        '
        Me.tsslEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslEstado.Name = "tsslEstado"
        Me.tsslEstado.Size = New System.Drawing.Size(58, 24)
        Me.tsslEstado.Text = "Estado"
        '
        'tsslElaboro
        '
        Me.tsslElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslElaboro.Name = "tsslElaboro"
        Me.tsslElaboro.Size = New System.Drawing.Size(72, 24)
        Me.tsslElaboro.Text = "Elaboró :"
        '
        'tsslCancelo
        '
        Me.tsslCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCancelo.Name = "tsslCancelo"
        Me.tsslCancelo.Size = New System.Drawing.Size(73, 24)
        Me.tsslCancelo.Text = "Canceló :"
        '
        'frmDatos
        '
        Me.frmDatos.Controls.Add(Me.lblDisplayRegimenFiscalReceptor)
        Me.frmDatos.Controls.Add(Me.txtRegimenFiscalReceptor)
        Me.frmDatos.Controls.Add(Me.lblRegimenFiscalReceptor)
        Me.frmDatos.Controls.Add(Me.txtUsoCFDI)
        Me.frmDatos.Controls.Add(Me.lblUsoCFDI)
        Me.frmDatos.Controls.Add(Me.ckbMostrarUtilidad)
        Me.frmDatos.Controls.Add(Me.gbUtilidad)
        Me.frmDatos.Controls.Add(Me.lblConceptoCancelacion)
        Me.frmDatos.Controls.Add(Me.TxtConceptoCancelacion)
        Me.frmDatos.Controls.Add(Me.cboFormaPago)
        Me.frmDatos.Controls.Add(Me.lblVersionCFDI)
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
        Me.frmDatos.Location = New System.Drawing.Point(11, 34)
        Me.frmDatos.Margin = New System.Windows.Forms.Padding(4)
        Me.frmDatos.Name = "frmDatos"
        Me.frmDatos.Padding = New System.Windows.Forms.Padding(4)
        Me.frmDatos.Size = New System.Drawing.Size(1315, 297)
        Me.frmDatos.TabIndex = 0
        Me.frmDatos.TabStop = False
        '
        'lblDisplayRegimenFiscalReceptor
        '
        Me.lblDisplayRegimenFiscalReceptor.AutoSize = True
        Me.lblDisplayRegimenFiscalReceptor.Location = New System.Drawing.Point(3, 202)
        Me.lblDisplayRegimenFiscalReceptor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRegimenFiscalReceptor.Name = "lblDisplayRegimenFiscalReceptor"
        Me.lblDisplayRegimenFiscalReceptor.Size = New System.Drawing.Size(108, 17)
        Me.lblDisplayRegimenFiscalReceptor.TabIndex = 390
        Me.lblDisplayRegimenFiscalReceptor.Text = "Régimen fiscal :"
        '
        'txtRegimenFiscalReceptor
        '
        Me.txtRegimenFiscalReceptor.Location = New System.Drawing.Point(112, 201)
        Me.txtRegimenFiscalReceptor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRegimenFiscalReceptor.MaxLength = 3
        Me.txtRegimenFiscalReceptor.Name = "txtRegimenFiscalReceptor"
        Me.txtRegimenFiscalReceptor.Size = New System.Drawing.Size(59, 22)
        Me.txtRegimenFiscalReceptor.TabIndex = 9
        '
        'lblRegimenFiscalReceptor
        '
        Me.lblRegimenFiscalReceptor.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRegimenFiscalReceptor.Location = New System.Drawing.Point(180, 204)
        Me.lblRegimenFiscalReceptor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRegimenFiscalReceptor.Name = "lblRegimenFiscalReceptor"
        Me.lblRegimenFiscalReceptor.Size = New System.Drawing.Size(301, 16)
        Me.lblRegimenFiscalReceptor.TabIndex = 386
        Me.lblRegimenFiscalReceptor.Text = "_"
        '
        'txtUsoCFDI
        '
        Me.txtUsoCFDI.Location = New System.Drawing.Point(619, 201)
        Me.txtUsoCFDI.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsoCFDI.MaxLength = 3
        Me.txtUsoCFDI.Name = "txtUsoCFDI"
        Me.txtUsoCFDI.Size = New System.Drawing.Size(59, 22)
        Me.txtUsoCFDI.TabIndex = 10
        '
        'lblUsoCFDI
        '
        Me.lblUsoCFDI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUsoCFDI.Location = New System.Drawing.Point(687, 204)
        Me.lblUsoCFDI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsoCFDI.Name = "lblUsoCFDI"
        Me.lblUsoCFDI.Size = New System.Drawing.Size(249, 16)
        Me.lblUsoCFDI.TabIndex = 388
        Me.lblUsoCFDI.Text = "_"
        '
        'ckbMostrarUtilidad
        '
        Me.ckbMostrarUtilidad.AutoSize = True
        Me.ckbMostrarUtilidad.Location = New System.Drawing.Point(953, 233)
        Me.ckbMostrarUtilidad.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbMostrarUtilidad.Name = "ckbMostrarUtilidad"
        Me.ckbMostrarUtilidad.Size = New System.Drawing.Size(127, 21)
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
        Me.gbUtilidad.Location = New System.Drawing.Point(953, 238)
        Me.gbUtilidad.Margin = New System.Windows.Forms.Padding(4)
        Me.gbUtilidad.Name = "gbUtilidad"
        Me.gbUtilidad.Padding = New System.Windows.Forms.Padding(4)
        Me.gbUtilidad.Size = New System.Drawing.Size(223, 55)
        Me.gbUtilidad.TabIndex = 389
        Me.gbUtilidad.TabStop = False
        Me.gbUtilidad.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 34)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 17)
        Me.Label7.TabIndex = 390
        Me.Label7.Text = "% :"
        '
        'lblDisplayUtilidad
        '
        Me.lblDisplayUtilidad.AutoSize = True
        Me.lblDisplayUtilidad.Location = New System.Drawing.Point(8, 18)
        Me.lblDisplayUtilidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayUtilidad.Name = "lblDisplayUtilidad"
        Me.lblDisplayUtilidad.Size = New System.Drawing.Size(30, 17)
        Me.lblDisplayUtilidad.TabIndex = 389
        Me.lblDisplayUtilidad.Text = "Ut :"
        '
        'lblPorcentajeUtilidad
        '
        Me.lblPorcentajeUtilidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblPorcentajeUtilidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPorcentajeUtilidad.Location = New System.Drawing.Point(88, 36)
        Me.lblPorcentajeUtilidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPorcentajeUtilidad.Name = "lblPorcentajeUtilidad"
        Me.lblPorcentajeUtilidad.Size = New System.Drawing.Size(127, 16)
        Me.lblPorcentajeUtilidad.TabIndex = 388
        Me.lblPorcentajeUtilidad.Text = "0.00"
        Me.lblPorcentajeUtilidad.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUtilidad
        '
        Me.lblUtilidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblUtilidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblUtilidad.Location = New System.Drawing.Point(88, 18)
        Me.lblUtilidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUtilidad.Name = "lblUtilidad"
        Me.lblUtilidad.Size = New System.Drawing.Size(127, 16)
        Me.lblUtilidad.TabIndex = 387
        Me.lblUtilidad.Text = "0.00"
        Me.lblUtilidad.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblConceptoCancelacion
        '
        Me.lblConceptoCancelacion.AutoSize = True
        Me.lblConceptoCancelacion.Location = New System.Drawing.Point(1121, 135)
        Me.lblConceptoCancelacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConceptoCancelacion.Name = "lblConceptoCancelacion"
        Me.lblConceptoCancelacion.Size = New System.Drawing.Size(175, 17)
        Me.lblConceptoCancelacion.TabIndex = 385
        Me.lblConceptoCancelacion.Text = "Concepto de cancelación :"
        '
        'TxtConceptoCancelacion
        '
        Me.TxtConceptoCancelacion.Location = New System.Drawing.Point(999, 158)
        Me.TxtConceptoCancelacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtConceptoCancelacion.MaxLength = 120
        Me.TxtConceptoCancelacion.Multiline = True
        Me.TxtConceptoCancelacion.Name = "TxtConceptoCancelacion"
        Me.TxtConceptoCancelacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConceptoCancelacion.Size = New System.Drawing.Size(301, 66)
        Me.TxtConceptoCancelacion.TabIndex = 384
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(112, 228)
        Me.cboFormaPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(272, 24)
        Me.cboFormaPago.TabIndex = 11
        '
        'lblVersionCFDI
        '
        Me.lblVersionCFDI.AutoSize = True
        Me.lblVersionCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionCFDI.Location = New System.Drawing.Point(1241, 229)
        Me.lblVersionCFDI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVersionCFDI.Name = "lblVersionCFDI"
        Me.lblVersionCFDI.Size = New System.Drawing.Size(42, 25)
        Me.lblVersionCFDI.TabIndex = 383
        Me.lblVersionCFDI.Text = "0.0"
        '
        'lblDisplayMetodoPago
        '
        Me.lblDisplayMetodoPago.AutoSize = True
        Me.lblDisplayMetodoPago.Location = New System.Drawing.Point(437, 230)
        Me.lblDisplayMetodoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayMetodoPago.Name = "lblDisplayMetodoPago"
        Me.lblDisplayMetodoPago.Size = New System.Drawing.Size(119, 17)
        Me.lblDisplayMetodoPago.TabIndex = 382
        Me.lblDisplayMetodoPago.Text = "Método de pago :"
        '
        'cboMetodoPago
        '
        Me.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMetodoPago.Enabled = False
        Me.cboMetodoPago.FormattingEnabled = True
        Me.cboMetodoPago.Location = New System.Drawing.Point(563, 228)
        Me.cboMetodoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMetodoPago.MaxLength = 1
        Me.cboMetodoPago.Name = "cboMetodoPago"
        Me.cboMetodoPago.Size = New System.Drawing.Size(368, 24)
        Me.cboMetodoPago.TabIndex = 12
        '
        'lblDisplayUsoCFDI
        '
        Me.lblDisplayUsoCFDI.AutoSize = True
        Me.lblDisplayUsoCFDI.Location = New System.Drawing.Point(509, 202)
        Me.lblDisplayUsoCFDI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayUsoCFDI.Name = "lblDisplayUsoCFDI"
        Me.lblDisplayUsoCFDI.Size = New System.Drawing.Size(98, 17)
        Me.lblDisplayUsoCFDI.TabIndex = 381
        Me.lblDisplayUsoCFDI.Text = "Uso del CFDI :"
        '
        'CboTipoCredito
        '
        Me.CboTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoCredito.FormattingEnabled = True
        Me.CboTipoCredito.Location = New System.Drawing.Point(953, 106)
        Me.CboTipoCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoCredito.Name = "CboTipoCredito"
        Me.CboTipoCredito.Size = New System.Drawing.Size(272, 24)
        Me.CboTipoCredito.TabIndex = 20
        '
        'lblTipoCredito
        '
        Me.lblTipoCredito.AutoSize = True
        Me.lblTipoCredito.Location = New System.Drawing.Point(852, 108)
        Me.lblTipoCredito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoCredito.Name = "lblTipoCredito"
        Me.lblTipoCredito.Size = New System.Drawing.Size(91, 17)
        Me.lblTipoCredito.TabIndex = 376
        Me.lblTipoCredito.Text = "Tipo crédito :"
        '
        'LblDisplayMoneda
        '
        Me.LblDisplayMoneda.AutoSize = True
        Me.LblDisplayMoneda.Location = New System.Drawing.Point(3, 142)
        Me.LblDisplayMoneda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayMoneda.Name = "LblDisplayMoneda"
        Me.LblDisplayMoneda.Size = New System.Drawing.Size(67, 17)
        Me.LblDisplayMoneda.TabIndex = 374
        Me.LblDisplayMoneda.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(112, 139)
        Me.cboMoneda.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(109, 24)
        Me.cboMoneda.TabIndex = 6
        '
        'btnFacturaSiguiente
        '
        Me.btnFacturaSiguiente.Location = New System.Drawing.Point(313, 50)
        Me.btnFacturaSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFacturaSiguiente.Name = "btnFacturaSiguiente"
        Me.btnFacturaSiguiente.Size = New System.Drawing.Size(72, 26)
        Me.btnFacturaSiguiente.TabIndex = 372
        Me.btnFacturaSiguiente.Text = ">>"
        Me.btnFacturaSiguiente.UseVisualStyleBackColor = True
        '
        'btnFacturaAnterior
        '
        Me.btnFacturaAnterior.Location = New System.Drawing.Point(227, 50)
        Me.btnFacturaAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFacturaAnterior.Name = "btnFacturaAnterior"
        Me.btnFacturaAnterior.Size = New System.Drawing.Size(72, 26)
        Me.btnFacturaAnterior.TabIndex = 371
        Me.btnFacturaAnterior.Text = "<<"
        Me.btnFacturaAnterior.UseVisualStyleBackColor = True
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(227, 143)
        Me.lblDisplayTipoCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(113, 17)
        Me.lblDisplayTipoCambio.TabIndex = 332
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(341, 142)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(87, 22)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumeroCuentaPago
        '
        Me.txtNumeroCuentaPago.Location = New System.Drawing.Point(561, 46)
        Me.txtNumeroCuentaPago.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumeroCuentaPago.MaxLength = 4
        Me.txtNumeroCuentaPago.Name = "txtNumeroCuentaPago"
        Me.txtNumeroCuentaPago.Size = New System.Drawing.Size(119, 22)
        Me.txtNumeroCuentaPago.TabIndex = 14
        '
        'lblDisplayNumeroCuentaPago
        '
        Me.lblDisplayNumeroCuentaPago.AutoSize = True
        Me.lblDisplayNumeroCuentaPago.Location = New System.Drawing.Point(437, 50)
        Me.lblDisplayNumeroCuentaPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayNumeroCuentaPago.Name = "lblDisplayNumeroCuentaPago"
        Me.lblDisplayNumeroCuentaPago.Size = New System.Drawing.Size(116, 17)
        Me.lblDisplayNumeroCuentaPago.TabIndex = 337
        Me.lblDisplayNumeroCuentaPago.Text = "Num. de cuenta :"
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.Location = New System.Drawing.Point(3, 230)
        Me.lblFormaPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(112, 17)
        Me.lblFormaPago.TabIndex = 335
        Me.lblFormaPago.Text = "Forma de pago :"
        '
        'llblAgregarSeguimiento
        '
        Me.llblAgregarSeguimiento.AutoSize = True
        Me.llblAgregarSeguimiento.Location = New System.Drawing.Point(1173, 257)
        Me.llblAgregarSeguimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.llblAgregarSeguimiento.Name = "llblAgregarSeguimiento"
        Me.llblAgregarSeguimiento.Size = New System.Drawing.Size(139, 17)
        Me.llblAgregarSeguimiento.TabIndex = 333
        Me.llblAgregarSeguimiento.TabStop = True
        Me.llblAgregarSeguimiento.Text = "Agregar seguimiento"
        '
        'txtFolioEmbarque
        '
        Me.txtFolioEmbarque.Location = New System.Drawing.Point(953, 76)
        Me.txtFolioEmbarque.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioEmbarque.MaxLength = 60
        Me.txtFolioEmbarque.Name = "txtFolioEmbarque"
        Me.txtFolioEmbarque.Size = New System.Drawing.Size(119, 22)
        Me.txtFolioEmbarque.TabIndex = 19
        '
        'lblDisplayFolioEmbarque
        '
        Me.lblDisplayFolioEmbarque.AutoSize = True
        Me.lblDisplayFolioEmbarque.Location = New System.Drawing.Point(853, 81)
        Me.lblDisplayFolioEmbarque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioEmbarque.Name = "lblDisplayFolioEmbarque"
        Me.lblDisplayFolioEmbarque.Size = New System.Drawing.Size(94, 17)
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
        Me.gbTotales.Location = New System.Drawing.Point(12, 640)
        Me.gbTotales.Margin = New System.Windows.Forms.Padding(4)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Padding = New System.Windows.Forms.Padding(4)
        Me.gbTotales.Size = New System.Drawing.Size(1315, 162)
        Me.gbTotales.TabIndex = 3
        Me.gbTotales.TabStop = False
        '
        'lblDisplayIEPSIncluido_USD
        '
        Me.lblDisplayIEPSIncluido_USD.AutoSize = True
        Me.lblDisplayIEPSIncluido_USD.Location = New System.Drawing.Point(1255, 59)
        Me.lblDisplayIEPSIncluido_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIEPSIncluido_USD.Name = "lblDisplayIEPSIncluido_USD"
        Me.lblDisplayIEPSIncluido_USD.Size = New System.Drawing.Size(37, 17)
        Me.lblDisplayIEPSIncluido_USD.TabIndex = 390
        Me.lblDisplayIEPSIncluido_USD.Text = "USD"
        '
        'lblDisplayIEPSIncluido
        '
        Me.lblDisplayIEPSIncluido.AutoSize = True
        Me.lblDisplayIEPSIncluido.Location = New System.Drawing.Point(1255, 39)
        Me.lblDisplayIEPSIncluido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIEPSIncluido.Name = "lblDisplayIEPSIncluido"
        Me.lblDisplayIEPSIncluido.Size = New System.Drawing.Size(38, 17)
        Me.lblDisplayIEPSIncluido.TabIndex = 389
        Me.lblDisplayIEPSIncluido.Text = "MXN"
        '
        'lblSaldoDolares
        '
        Me.lblSaldoDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSaldoDolares.ForeColor = System.Drawing.Color.Crimson
        Me.lblSaldoDolares.Location = New System.Drawing.Point(284, 39)
        Me.lblSaldoDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSaldoDolares.Name = "lblSaldoDolares"
        Me.lblSaldoDolares.Size = New System.Drawing.Size(143, 16)
        Me.lblSaldoDolares.TabIndex = 388
        Me.lblSaldoDolares.Text = "0.00"
        Me.lblSaldoDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblSaldoDolares.Visible = False
        '
        'lblDisplaySaldoDolares
        '
        Me.lblDisplaySaldoDolares.AutoSize = True
        Me.lblDisplaySaldoDolares.Location = New System.Drawing.Point(187, 39)
        Me.lblDisplaySaldoDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySaldoDolares.Name = "lblDisplaySaldoDolares"
        Me.lblDisplaySaldoDolares.Size = New System.Drawing.Size(85, 17)
        Me.lblDisplaySaldoDolares.TabIndex = 387
        Me.lblDisplaySaldoDolares.Text = "Saldo USD :"
        Me.lblDisplaySaldoDolares.Visible = False
        '
        'lblIEPSIncluido_USD
        '
        Me.lblIEPSIncluido_USD.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPSIncluido_USD.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPSIncluido_USD.Location = New System.Drawing.Point(1100, 59)
        Me.lblIEPSIncluido_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIEPSIncluido_USD.Name = "lblIEPSIncluido_USD"
        Me.lblIEPSIncluido_USD.Size = New System.Drawing.Size(147, 16)
        Me.lblIEPSIncluido_USD.TabIndex = 386
        Me.lblIEPSIncluido_USD.Text = "0.00"
        Me.lblIEPSIncluido_USD.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtUUID
        '
        Me.txtUUID.Location = New System.Drawing.Point(71, 127)
        Me.txtUUID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUUID.MaxLength = 15
        Me.txtUUID.Name = "txtUUID"
        Me.txtUUID.ReadOnly = True
        Me.txtUUID.Size = New System.Drawing.Size(340, 22)
        Me.txtUUID.TabIndex = 385
        '
        'lblUUID
        '
        Me.lblUUID.AutoSize = True
        Me.lblUUID.Location = New System.Drawing.Point(8, 129)
        Me.lblUUID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUUID.Name = "lblUUID"
        Me.lblUUID.Size = New System.Drawing.Size(49, 17)
        Me.lblUUID.TabIndex = 384
        Me.lblUUID.Text = "UUID :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1184, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 383
        Me.Label1.Text = "IEPS Incluido :"
        '
        'lblIEPSIncluido
        '
        Me.lblIEPSIncluido.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPSIncluido.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPSIncluido.Location = New System.Drawing.Point(1100, 39)
        Me.lblIEPSIncluido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIEPSIncluido.Name = "lblIEPSIncluido"
        Me.lblIEPSIncluido.Size = New System.Drawing.Size(147, 16)
        Me.lblIEPSIncluido.TabIndex = 382
        Me.lblIEPSIncluido.Text = "0.00"
        Me.lblIEPSIncluido.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSeries
        '
        Me.btnSeries.Location = New System.Drawing.Point(12, 80)
        Me.btnSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(145, 39)
        Me.btnSeries.TabIndex = 381
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        '
        'btnAgregaAddenda
        '
        Me.btnAgregaAddenda.Location = New System.Drawing.Point(1136, 89)
        Me.btnAgregaAddenda.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregaAddenda.Name = "btnAgregaAddenda"
        Me.btnAgregaAddenda.Size = New System.Drawing.Size(151, 28)
        Me.btnAgregaAddenda.TabIndex = 339
        Me.btnAgregaAddenda.Text = "Addenda soriana"
        Me.btnAgregaAddenda.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(80, 52)
        Me.LblPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(16, 17)
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
        Me.TabControl1.Controls.Add(Me.tpComplementoINE)
        Me.TabControl1.Location = New System.Drawing.Point(11, 338)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1705, 293)
        Me.TabControl1.TabIndex = 2
        '
        'tpArticulos
        '
        Me.tpArticulos.Controls.Add(Me.btnAgregarRenglon)
        Me.tpArticulos.Controls.Add(Me.Grid)
        Me.tpArticulos.Location = New System.Drawing.Point(4, 25)
        Me.tpArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.tpArticulos.Name = "tpArticulos"
        Me.tpArticulos.Padding = New System.Windows.Forms.Padding(4)
        Me.tpArticulos.Size = New System.Drawing.Size(1697, 264)
        Me.tpArticulos.TabIndex = 0
        Me.tpArticulos.Text = "Artículos"
        Me.tpArticulos.UseVisualStyleBackColor = True
        '
        'btnAgregarRenglon
        '
        Me.btnAgregarRenglon.Location = New System.Drawing.Point(4, 233)
        Me.btnAgregarRenglon.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarRenglon.Name = "btnAgregarRenglon"
        Me.btnAgregarRenglon.Size = New System.Drawing.Size(23, 25)
        Me.btnAgregarRenglon.TabIndex = 374
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
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(4, 7)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(1688, 251)
        Me.Grid.TabIndex = 2
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpSeries
        '
        Me.tpSeries.Controls.Add(Me.btnMostrarMasColumnasGridSeries)
        Me.tpSeries.Controls.Add(Me.GridSeries)
        Me.tpSeries.Location = New System.Drawing.Point(4, 25)
        Me.tpSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.tpSeries.Name = "tpSeries"
        Me.tpSeries.Padding = New System.Windows.Forms.Padding(4)
        Me.tpSeries.Size = New System.Drawing.Size(1697, 264)
        Me.tpSeries.TabIndex = 1
        Me.tpSeries.Text = "Series"
        Me.tpSeries.UseVisualStyleBackColor = True
        '
        'btnMostrarMasColumnasGridSeries
        '
        Me.btnMostrarMasColumnasGridSeries.Location = New System.Drawing.Point(1648, 225)
        Me.btnMostrarMasColumnasGridSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMostrarMasColumnasGridSeries.Name = "btnMostrarMasColumnasGridSeries"
        Me.btnMostrarMasColumnasGridSeries.Size = New System.Drawing.Size(39, 26)
        Me.btnMostrarMasColumnasGridSeries.TabIndex = 375
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
        Me.GridSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSeries.Location = New System.Drawing.Point(7, 7)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(1629, 244)
        Me.GridSeries.TabIndex = 2
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpCFDIsRelacionados
        '
        Me.tpCFDIsRelacionados.Controls.Add(Me.GridCFDIsRelacionados)
        Me.tpCFDIsRelacionados.Controls.Add(Me.Label3)
        Me.tpCFDIsRelacionados.Controls.Add(Me.cboTipoRelacionCFDI)
        Me.tpCFDIsRelacionados.Location = New System.Drawing.Point(4, 25)
        Me.tpCFDIsRelacionados.Margin = New System.Windows.Forms.Padding(4)
        Me.tpCFDIsRelacionados.Name = "tpCFDIsRelacionados"
        Me.tpCFDIsRelacionados.Size = New System.Drawing.Size(1697, 264)
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
        Me.GridCFDIsRelacionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCFDIsRelacionados.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCFDIsRelacionados.Location = New System.Drawing.Point(7, 57)
        Me.GridCFDIsRelacionados.LockButton = True
        Me.GridCFDIsRelacionados.Margin = New System.Windows.Forms.Padding(4)
        Me.GridCFDIsRelacionados.Name = "GridCFDIsRelacionados"
        Me.GridCFDIsRelacionados.Rows = 3
        Me.GridCFDIsRelacionados.Size = New System.Drawing.Size(1275, 197)
        Me.GridCFDIsRelacionados.TabIndex = 385
        Me.GridCFDIsRelacionados.UncheckedImage = CType(resources.GetObject("GridCFDIsRelacionados.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 17)
        Me.Label3.TabIndex = 384
        Me.Label3.Text = "Tipo relación CFDI :"
        '
        'cboTipoRelacionCFDI
        '
        Me.cboTipoRelacionCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRelacionCFDI.Enabled = False
        Me.cboTipoRelacionCFDI.FormattingEnabled = True
        Me.cboTipoRelacionCFDI.Location = New System.Drawing.Point(149, 23)
        Me.cboTipoRelacionCFDI.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoRelacionCFDI.MaxLength = 1
        Me.cboTipoRelacionCFDI.Name = "cboTipoRelacionCFDI"
        Me.cboTipoRelacionCFDI.Size = New System.Drawing.Size(400, 24)
        Me.cboTipoRelacionCFDI.TabIndex = 383
        '
        'tpFacturasRemisiones
        '
        Me.tpFacturasRemisiones.Controls.Add(Me.btnAceptarRemisionesSeries)
        Me.tpFacturasRemisiones.Controls.Add(Me.btnAceptar)
        Me.tpFacturasRemisiones.Controls.Add(Me.btnCargarRemisiones)
        Me.tpFacturasRemisiones.Controls.Add(Me.GridFacturasVariasRemisiones)
        Me.tpFacturasRemisiones.Location = New System.Drawing.Point(4, 25)
        Me.tpFacturasRemisiones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpFacturasRemisiones.Name = "tpFacturasRemisiones"
        Me.tpFacturasRemisiones.Size = New System.Drawing.Size(1697, 264)
        Me.tpFacturasRemisiones.TabIndex = 3
        Me.tpFacturasRemisiones.Text = "Facturar varias remisiones"
        Me.tpFacturasRemisiones.UseVisualStyleBackColor = True
        '
        'btnAceptarRemisionesSeries
        '
        Me.btnAceptarRemisionesSeries.Location = New System.Drawing.Point(1479, 191)
        Me.btnAceptarRemisionesSeries.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptarRemisionesSeries.Name = "btnAceptarRemisionesSeries"
        Me.btnAceptarRemisionesSeries.Size = New System.Drawing.Size(164, 39)
        Me.btnAceptarRemisionesSeries.TabIndex = 7
        Me.btnAceptarRemisionesSeries.Text = "Aceptar(Cargarlas)"
        Me.btnAceptarRemisionesSeries.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(1479, 108)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(164, 39)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar(Cargarlas)"
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'btnCargarRemisiones
        '
        Me.btnCargarRemisiones.Location = New System.Drawing.Point(1479, 41)
        Me.btnCargarRemisiones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCargarRemisiones.Name = "btnCargarRemisiones"
        Me.btnCargarRemisiones.Size = New System.Drawing.Size(164, 39)
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
        Me.GridFacturasVariasRemisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridFacturasVariasRemisiones.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridFacturasVariasRemisiones.Location = New System.Drawing.Point(4, 0)
        Me.GridFacturasVariasRemisiones.LockButton = True
        Me.GridFacturasVariasRemisiones.Margin = New System.Windows.Forms.Padding(4)
        Me.GridFacturasVariasRemisiones.Name = "GridFacturasVariasRemisiones"
        Me.GridFacturasVariasRemisiones.Rows = 6
        Me.GridFacturasVariasRemisiones.Size = New System.Drawing.Size(1416, 260)
        Me.GridFacturasVariasRemisiones.TabIndex = 3
        Me.GridFacturasVariasRemisiones.UncheckedImage = CType(resources.GetObject("GridFacturasVariasRemisiones.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpComplementoINE
        '
        Me.tpComplementoINE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpComplementoINE.Controls.Add(Me.btnEliminarDatosINE)
        Me.tpComplementoINE.Controls.Add(Me.GbEntidades)
        Me.tpComplementoINE.Controls.Add(Me.TxtIdContabilidad)
        Me.tpComplementoINE.Controls.Add(Me.CboTipoComite)
        Me.tpComplementoINE.Controls.Add(Me.LblClaveContabilidad)
        Me.tpComplementoINE.Controls.Add(Me.LblTipoComite)
        Me.tpComplementoINE.Controls.Add(Me.LblTipoProceso)
        Me.tpComplementoINE.Controls.Add(Me.CboTipoProceso)
        Me.tpComplementoINE.Controls.Add(Me.GridEntidades)
        Me.tpComplementoINE.Location = New System.Drawing.Point(4, 25)
        Me.tpComplementoINE.Name = "tpComplementoINE"
        Me.tpComplementoINE.Padding = New System.Windows.Forms.Padding(3)
        Me.tpComplementoINE.Size = New System.Drawing.Size(1697, 264)
        Me.tpComplementoINE.TabIndex = 4
        Me.tpComplementoINE.Text = "Complemento INE"
        '
        'GbEntidades
        '
        Me.GbEntidades.Controls.Add(Me.BtnAgregarEntidad)
        Me.GbEntidades.Controls.Add(Me.TxtIdContabilidadEntidad)
        Me.GbEntidades.Controls.Add(Me.CboAmbito)
        Me.GbEntidades.Controls.Add(Me.CboEntidad)
        Me.GbEntidades.Controls.Add(Me.LblClaveContabilidadEntidad)
        Me.GbEntidades.Controls.Add(Me.LblAmbito)
        Me.GbEntidades.Controls.Add(Me.LblEntidad)
        Me.GbEntidades.Location = New System.Drawing.Point(393, 23)
        Me.GbEntidades.Name = "GbEntidades"
        Me.GbEntidades.Size = New System.Drawing.Size(356, 207)
        Me.GbEntidades.TabIndex = 3
        Me.GbEntidades.TabStop = False
        Me.GbEntidades.Text = "Entidades"
        '
        'BtnAgregarEntidad
        '
        Me.BtnAgregarEntidad.Location = New System.Drawing.Point(96, 162)
        Me.BtnAgregarEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAgregarEntidad.Name = "BtnAgregarEntidad"
        Me.BtnAgregarEntidad.Size = New System.Drawing.Size(176, 29)
        Me.BtnAgregarEntidad.TabIndex = 3
        Me.BtnAgregarEntidad.Text = "Agregar"
        Me.BtnAgregarEntidad.UseVisualStyleBackColor = True
        '
        'TxtIdContabilidadEntidad
        '
        Me.TxtIdContabilidadEntidad.Location = New System.Drawing.Point(151, 122)
        Me.TxtIdContabilidadEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdContabilidadEntidad.MaxLength = 6
        Me.TxtIdContabilidadEntidad.Name = "TxtIdContabilidadEntidad"
        Me.TxtIdContabilidadEntidad.Size = New System.Drawing.Size(68, 22)
        Me.TxtIdContabilidadEntidad.TabIndex = 2
        '
        'CboAmbito
        '
        Me.CboAmbito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAmbito.FormattingEnabled = True
        Me.CboAmbito.Location = New System.Drawing.Point(118, 77)
        Me.CboAmbito.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAmbito.MaxLength = 1
        Me.CboAmbito.Name = "CboAmbito"
        Me.CboAmbito.Size = New System.Drawing.Size(211, 24)
        Me.CboAmbito.TabIndex = 1
        '
        'CboEntidad
        '
        Me.CboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEntidad.FormattingEnabled = True
        Me.CboEntidad.Location = New System.Drawing.Point(118, 31)
        Me.CboEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEntidad.MaxLength = 1
        Me.CboEntidad.Name = "CboEntidad"
        Me.CboEntidad.Size = New System.Drawing.Size(211, 24)
        Me.CboEntidad.TabIndex = 0
        '
        'LblClaveContabilidadEntidad
        '
        Me.LblClaveContabilidadEntidad.AutoSize = True
        Me.LblClaveContabilidadEntidad.Location = New System.Drawing.Point(15, 125)
        Me.LblClaveContabilidadEntidad.Name = "LblClaveContabilidadEntidad"
        Me.LblClaveContabilidadEntidad.Size = New System.Drawing.Size(129, 17)
        Me.LblClaveContabilidadEntidad.TabIndex = 389
        Me.LblClaveContabilidadEntidad.Text = "Clave Contabilidad:"
        '
        'LblAmbito
        '
        Me.LblAmbito.AutoSize = True
        Me.LblAmbito.Location = New System.Drawing.Point(56, 83)
        Me.LblAmbito.Name = "LblAmbito"
        Me.LblAmbito.Size = New System.Drawing.Size(55, 17)
        Me.LblAmbito.TabIndex = 388
        Me.LblAmbito.Text = "Ambito:"
        '
        'LblEntidad
        '
        Me.LblEntidad.AutoSize = True
        Me.LblEntidad.Location = New System.Drawing.Point(51, 37)
        Me.LblEntidad.Name = "LblEntidad"
        Me.LblEntidad.Size = New System.Drawing.Size(60, 17)
        Me.LblEntidad.TabIndex = 387
        Me.LblEntidad.Text = "Entidad:"
        '
        'TxtIdContabilidad
        '
        Me.TxtIdContabilidad.Location = New System.Drawing.Point(158, 103)
        Me.TxtIdContabilidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdContabilidad.MaxLength = 6
        Me.TxtIdContabilidad.Name = "TxtIdContabilidad"
        Me.TxtIdContabilidad.Size = New System.Drawing.Size(68, 22)
        Me.TxtIdContabilidad.TabIndex = 2
        '
        'CboTipoComite
        '
        Me.CboTipoComite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoComite.FormattingEnabled = True
        Me.CboTipoComite.Location = New System.Drawing.Point(157, 57)
        Me.CboTipoComite.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoComite.MaxLength = 1
        Me.CboTipoComite.Name = "CboTipoComite"
        Me.CboTipoComite.Size = New System.Drawing.Size(211, 24)
        Me.CboTipoComite.TabIndex = 1
        '
        'LblClaveContabilidad
        '
        Me.LblClaveContabilidad.AutoSize = True
        Me.LblClaveContabilidad.Location = New System.Drawing.Point(21, 106)
        Me.LblClaveContabilidad.Name = "LblClaveContabilidad"
        Me.LblClaveContabilidad.Size = New System.Drawing.Size(129, 17)
        Me.LblClaveContabilidad.TabIndex = 388
        Me.LblClaveContabilidad.Text = "Clave Contabilidad:"
        '
        'LblTipoComite
        '
        Me.LblTipoComite.AutoSize = True
        Me.LblTipoComite.Location = New System.Drawing.Point(59, 57)
        Me.LblTipoComite.Name = "LblTipoComite"
        Me.LblTipoComite.Size = New System.Drawing.Size(87, 17)
        Me.LblTipoComite.TabIndex = 387
        Me.LblTipoComite.Text = "Tipo Comite:"
        '
        'LblTipoProceso
        '
        Me.LblTipoProceso.AutoSize = True
        Me.LblTipoProceso.Location = New System.Drawing.Point(54, 26)
        Me.LblTipoProceso.Name = "LblTipoProceso"
        Me.LblTipoProceso.Size = New System.Drawing.Size(96, 17)
        Me.LblTipoProceso.TabIndex = 386
        Me.LblTipoProceso.Text = "Tipo Proceso:"
        '
        'CboTipoProceso
        '
        Me.CboTipoProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoProceso.FormattingEnabled = True
        Me.CboTipoProceso.Location = New System.Drawing.Point(157, 23)
        Me.CboTipoProceso.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoProceso.MaxLength = 1
        Me.CboTipoProceso.Name = "CboTipoProceso"
        Me.CboTipoProceso.Size = New System.Drawing.Size(211, 24)
        Me.CboTipoProceso.TabIndex = 0
        '
        'GridEntidades
        '
        Me.GridEntidades.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridEntidades.CheckedImage = CType(resources.GetObject("GridEntidades.CheckedImage"), System.Drawing.Bitmap)
        Me.GridEntidades.Cols = 1
        Me.GridEntidades.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridEntidades.DefaultRowHeight = CType(24, Short)
        Me.GridEntidades.DisplayRowNumber = True
        Me.GridEntidades.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridEntidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEntidades.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridEntidades.Location = New System.Drawing.Point(774, 26)
        Me.GridEntidades.LockButton = True
        Me.GridEntidades.Margin = New System.Windows.Forms.Padding(4)
        Me.GridEntidades.Name = "GridEntidades"
        Me.GridEntidades.Rows = 6
        Me.GridEntidades.Size = New System.Drawing.Size(916, 204)
        Me.GridEntidades.TabIndex = 4
        Me.GridEntidades.UncheckedImage = CType(resources.GetObject("GridEntidades.UncheckedImage"), System.Drawing.Bitmap)
        '
        'lblDisplayRegimenFiscalEmisor
        '
        Me.lblDisplayRegimenFiscalEmisor.AutoSize = True
        Me.lblDisplayRegimenFiscalEmisor.Location = New System.Drawing.Point(1329, 283)
        Me.lblDisplayRegimenFiscalEmisor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRegimenFiscalEmisor.Name = "lblDisplayRegimenFiscalEmisor"
        Me.lblDisplayRegimenFiscalEmisor.Size = New System.Drawing.Size(155, 17)
        Me.lblDisplayRegimenFiscalEmisor.TabIndex = 384
        Me.lblDisplayRegimenFiscalEmisor.Text = "Régimen fiscal Emisor :"
        '
        'cboRegimenFiscalEmisor
        '
        Me.cboRegimenFiscalEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegimenFiscalEmisor.FormattingEnabled = True
        Me.cboRegimenFiscalEmisor.Location = New System.Drawing.Point(1333, 303)
        Me.cboRegimenFiscalEmisor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboRegimenFiscalEmisor.MaxLength = 1
        Me.cboRegimenFiscalEmisor.Name = "cboRegimenFiscalEmisor"
        Me.cboRegimenFiscalEmisor.Size = New System.Drawing.Size(373, 24)
        Me.cboRegimenFiscalEmisor.TabIndex = 1
        '
        'lblDisplayIncoterm
        '
        Me.lblDisplayIncoterm.AutoSize = True
        Me.lblDisplayIncoterm.Location = New System.Drawing.Point(1329, 105)
        Me.lblDisplayIncoterm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIncoterm.Name = "lblDisplayIncoterm"
        Me.lblDisplayIncoterm.Size = New System.Drawing.Size(70, 17)
        Me.lblDisplayIncoterm.TabIndex = 395
        Me.lblDisplayIncoterm.Text = "Incoterm :"
        Me.lblDisplayIncoterm.Visible = False
        '
        'cboIncoterm
        '
        Me.cboIncoterm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIncoterm.Enabled = False
        Me.cboIncoterm.FormattingEnabled = True
        Me.cboIncoterm.Location = New System.Drawing.Point(1333, 124)
        Me.cboIncoterm.Margin = New System.Windows.Forms.Padding(4)
        Me.cboIncoterm.MaxLength = 1
        Me.cboIncoterm.Name = "cboIncoterm"
        Me.cboIncoterm.Size = New System.Drawing.Size(373, 24)
        Me.cboIncoterm.TabIndex = 394
        Me.cboIncoterm.Visible = False
        '
        'chkTieneCCE
        '
        Me.chkTieneCCE.AutoSize = True
        Me.chkTieneCCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTieneCCE.Location = New System.Drawing.Point(1333, 79)
        Me.chkTieneCCE.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTieneCCE.Name = "chkTieneCCE"
        Me.chkTieneCCE.Size = New System.Drawing.Size(314, 24)
        Me.chkTieneCCE.TabIndex = 393
        Me.chkTieneCCE.Text = "Complemento comercio exterior ?"
        Me.chkTieneCCE.UseVisualStyleBackColor = True
        Me.chkTieneCCE.Visible = False
        '
        'chkTieneCartaPorte
        '
        Me.chkTieneCartaPorte.AutoSize = True
        Me.chkTieneCartaPorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTieneCartaPorte.Location = New System.Drawing.Point(1335, 197)
        Me.chkTieneCartaPorte.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTieneCartaPorte.Name = "chkTieneCartaPorte"
        Me.chkTieneCartaPorte.Size = New System.Drawing.Size(259, 24)
        Me.chkTieneCartaPorte.TabIndex = 392
        Me.chkTieneCartaPorte.Text = "Complemento carta porte ?"
        Me.chkTieneCartaPorte.UseVisualStyleBackColor = True
        Me.chkTieneCartaPorte.Visible = False
        '
        'btnCartaPorte
        '
        Me.btnCartaPorte.Location = New System.Drawing.Point(1335, 224)
        Me.btnCartaPorte.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCartaPorte.Name = "btnCartaPorte"
        Me.btnCartaPorte.Size = New System.Drawing.Size(197, 39)
        Me.btnCartaPorte.TabIndex = 391
        Me.btnCartaPorte.Text = "Carta porte"
        Me.btnCartaPorte.UseVisualStyleBackColor = True
        Me.btnCartaPorte.Visible = False
        '
        'btnTimbradoTrasladoPrueba
        '
        Me.btnTimbradoTrasladoPrueba.Location = New System.Drawing.Point(1495, 715)
        Me.btnTimbradoTrasladoPrueba.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTimbradoTrasladoPrueba.Name = "btnTimbradoTrasladoPrueba"
        Me.btnTimbradoTrasladoPrueba.Size = New System.Drawing.Size(197, 39)
        Me.btnTimbradoTrasladoPrueba.TabIndex = 396
        Me.btnTimbradoTrasladoPrueba.Text = "TimbradoTrasladoPrueba"
        Me.btnTimbradoTrasladoPrueba.UseVisualStyleBackColor = True
        '
        'btnEliminarDatosINE
        '
        Me.btnEliminarDatosINE.Location = New System.Drawing.Point(94, 201)
        Me.btnEliminarDatosINE.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarDatosINE.Name = "btnEliminarDatosINE"
        Me.btnEliminarDatosINE.Size = New System.Drawing.Size(176, 29)
        Me.btnEliminarDatosINE.TabIndex = 5
        Me.btnEliminarDatosINE.Text = "Eliminar datos"
        Me.btnEliminarDatosINE.UseVisualStyleBackColor = True
        '
        'Ventas_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1720, 834)
        Me.Controls.Add(Me.btnTimbradoTrasladoPrueba)
        Me.Controls.Add(Me.lblDisplayIncoterm)
        Me.Controls.Add(Me.cboIncoterm)
        Me.Controls.Add(Me.chkTieneCCE)
        Me.Controls.Add(Me.chkTieneCartaPorte)
        Me.Controls.Add(Me.btnCartaPorte)
        Me.Controls.Add(Me.lblDisplayRegimenFiscalEmisor)
        Me.Controls.Add(Me.cboRegimenFiscalEmisor)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.frmDatos)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
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
        Me.tpComplementoINE.ResumeLayout(False)
        Me.tpComplementoINE.PerformLayout()
        Me.GbEntidades.ResumeLayout(False)
        Me.GbEntidades.PerformLayout()
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
    Friend WithEvents lblDisplayRegimenFiscalEmisor As Label
    Friend WithEvents cboRegimenFiscalEmisor As ComboBox
    Friend WithEvents txtRegimenFiscalReceptor As TextBox
    Friend WithEvents lblRegimenFiscalReceptor As Label
    Friend WithEvents txtUsoCFDI As TextBox
    Friend WithEvents lblUsoCFDI As Label
    Friend WithEvents lblDisplayRegimenFiscalReceptor As Label
    Friend WithEvents btnMostrarMasColumnasGridSeries As Button
    Friend WithEvents btnAceptarRemisionesSeries As Button
    Friend WithEvents lblDisplayIncoterm As Label
    Friend WithEvents cboIncoterm As ComboBox
    Friend WithEvents chkTieneCCE As CheckBox
    Friend WithEvents chkTieneCartaPorte As CheckBox
    Friend WithEvents btnCartaPorte As Button
    Friend WithEvents btnTimbradoTrasladoPrueba As Button
    Friend WithEvents tsbFacturaACartaPorte As ToolStripButton
    Friend WithEvents btnAgregarRenglon As Button
    Friend WithEvents tpComplementoINE As System.Windows.Forms.TabPage
    Friend WithEvents LblClaveContabilidad As System.Windows.Forms.Label
    Friend WithEvents LblTipoComite As System.Windows.Forms.Label
    Friend WithEvents LblTipoProceso As System.Windows.Forms.Label
    Friend WithEvents CboTipoProceso As System.Windows.Forms.ComboBox
    Friend WithEvents GridEntidades As FlexCell.Grid
    Friend WithEvents GbEntidades As System.Windows.Forms.GroupBox
    Friend WithEvents TxtIdContabilidadEntidad As System.Windows.Forms.TextBox
    Friend WithEvents CboAmbito As System.Windows.Forms.ComboBox
    Friend WithEvents CboEntidad As System.Windows.Forms.ComboBox
    Friend WithEvents LblClaveContabilidadEntidad As System.Windows.Forms.Label
    Friend WithEvents LblAmbito As System.Windows.Forms.Label
    Friend WithEvents LblEntidad As System.Windows.Forms.Label
    Friend WithEvents TxtIdContabilidad As System.Windows.Forms.TextBox
    Friend WithEvents CboTipoComite As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAgregarEntidad As System.Windows.Forms.Button
    Friend WithEvents btnEliminarDatosINE As System.Windows.Forms.Button
End Class
