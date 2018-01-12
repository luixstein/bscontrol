<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas_Movimientos
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
        Me.tsbCancelarTimbre = New System.Windows.Forms.ToolStripButton()
        Me.tsbTimbrar = New System.Windows.Forms.ToolStripButton()
        Me.tsbRecuperarXMLPDF = New System.Windows.Forms.ToolStripButton()
        Me.tsbEnviarCorreo = New System.Windows.Forms.ToolStripButton()
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
        Me.lblIEPS = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.gbDolares = New System.Windows.Forms.GroupBox()
        Me.lblTotalDolares = New System.Windows.Forms.Label()
        Me.lblSubtotalDolares = New System.Windows.Forms.Label()
        Me.lblImpuestoDolares = New System.Windows.Forms.Label()
        Me.lblDisplayTotalDolares = New System.Windows.Forms.Label()
        Me.lblDisplaySubtotalDolares = New System.Windows.Forms.Label()
        Me.lblDisplayImpuestoDolares = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.lblDisplaySaldo = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.frmDatos = New System.Windows.Forms.GroupBox()
        Me.lblConceptoCancelacion = New System.Windows.Forms.Label()
        Me.TxtConceptoCancelacion = New System.Windows.Forms.TextBox()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblVersionCFDI = New System.Windows.Forms.Label()
        Me.cboUsoCFDI = New System.Windows.Forms.ComboBox()
        Me.lblDisplayMetodoPago = New System.Windows.Forms.Label()
        Me.cboMetodoPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayUsoCFDI = New System.Windows.Forms.Label()
        Me.CboTipoCredito = New System.Windows.Forms.ComboBox()
        Me.LblTipoCredito = New System.Windows.Forms.Label()
        Me.ckbMostrarUtilidad = New System.Windows.Forms.CheckBox()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIEPSIncluido = New System.Windows.Forms.Label()
        Me.btnSeries = New System.Windows.Forms.Button()
        Me.btnAgregaAddenda = New System.Windows.Forms.Button()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grid = New FlexCell.Grid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridSeries = New FlexCell.Grid()
        Me.tsMenu.SuspendLayout()
        Me.gbPesos.SuspendLayout()
        Me.gbDolares.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.frmDatos.SuspendLayout()
        Me.gbTotales.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(80, 20)
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
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbCancelar, Me.tsbCotizacionRemision, Me.tsbCotizacionFactura, Me.tsbRemisionVenta, Me.tsbCancelarTimbre, Me.tsbTimbrar, Me.tsbRecuperarXMLPDF, Me.tsbEnviarCorreo, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1339, 27)
        Me.tsMenu.TabIndex = 3
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
        Me.tsbRecuperarXMLPDF.Size = New System.Drawing.Size(157, 24)
        Me.tsbRecuperarXMLPDF.Text = "Recuperar xml/pdf"
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
        Me.dpFecha.TabIndex = 12
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
        Me.dpVencimiento.TabIndex = 13
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
        Me.lblCliente.Location = New System.Drawing.Point(231, 176)
        Me.lblCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(547, 16)
        Me.lblCliente.TabIndex = 233
        Me.lblCliente.Text = "."
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
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(3, 238)
        Me.LblDisplayDireccionEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayDireccionEmpresa.TabIndex = 235
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(112, 235)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(721, 24)
        Me.TxtConcepto.TabIndex = 10
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
        Me.lblDisplayImpuestoPesos.Location = New System.Drawing.Point(8, 65)
        Me.lblDisplayImpuestoPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayImpuestoPesos.Name = "lblDisplayImpuestoPesos"
        Me.lblDisplayImpuestoPesos.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplayImpuestoPesos.TabIndex = 244
        Me.lblDisplayImpuestoPesos.Text = "Impuesto :"
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(8, 89)
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
        Me.gbPesos.Controls.Add(Me.lblIEPS)
        Me.gbPesos.Controls.Add(Me.Label2)
        Me.gbPesos.Controls.Add(Me.lblTotal)
        Me.gbPesos.Controls.Add(Me.lblSubtotal)
        Me.gbPesos.Controls.Add(Me.lblImpuesto)
        Me.gbPesos.Controls.Add(Me.lblDisplayTotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplaySubtotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplayImpuestoPesos)
        Me.gbPesos.Location = New System.Drawing.Point(833, 0)
        Me.gbPesos.Margin = New System.Windows.Forms.Padding(4)
        Me.gbPesos.Name = "gbPesos"
        Me.gbPesos.Padding = New System.Windows.Forms.Padding(4)
        Me.gbPesos.Size = New System.Drawing.Size(245, 119)
        Me.gbPesos.TabIndex = 292
        Me.gbPesos.TabStop = False
        Me.gbPesos.Text = "Pesos"
        '
        'lblIEPS
        '
        Me.lblIEPS.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPS.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPS.Location = New System.Drawing.Point(91, 43)
        Me.lblIEPS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIEPS.Name = "lblIEPS"
        Me.lblIEPS.Size = New System.Drawing.Size(147, 16)
        Me.lblIEPS.TabIndex = 251
        Me.lblIEPS.Text = "0.00"
        Me.lblIEPS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 42)
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
        Me.lblTotal.Location = New System.Drawing.Point(91, 89)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(147, 16)
        Me.lblTotal.TabIndex = 249
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal.Location = New System.Drawing.Point(91, 20)
        Me.lblSubtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(147, 16)
        Me.lblSubtotal.TabIndex = 247
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto.Location = New System.Drawing.Point(91, 66)
        Me.lblImpuesto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(147, 16)
        Me.lblImpuesto.TabIndex = 248
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.lblTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblSubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblImpuestoDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplaySubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayImpuestoDolares)
        Me.gbDolares.Location = New System.Drawing.Point(599, 23)
        Me.gbDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Size = New System.Drawing.Size(235, 96)
        Me.gbDolares.TabIndex = 293
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "Dólares"
        Me.gbDolares.Visible = False
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalDolares.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotalDolares.Location = New System.Drawing.Point(91, 65)
        Me.lblTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(136, 16)
        Me.lblTotalDolares.TabIndex = 249
        Me.lblTotalDolares.Text = "0.00"
        Me.lblTotalDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotalDolares
        '
        Me.lblSubtotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotalDolares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotalDolares.Location = New System.Drawing.Point(91, 20)
        Me.lblSubtotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotalDolares.Name = "lblSubtotalDolares"
        Me.lblSubtotalDolares.Size = New System.Drawing.Size(136, 16)
        Me.lblSubtotalDolares.TabIndex = 247
        Me.lblSubtotalDolares.Text = "0.00"
        Me.lblSubtotalDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuestoDolares
        '
        Me.lblImpuestoDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuestoDolares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuestoDolares.Location = New System.Drawing.Point(91, 43)
        Me.lblImpuestoDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpuestoDolares.Name = "lblImpuestoDolares"
        Me.lblImpuestoDolares.Size = New System.Drawing.Size(136, 16)
        Me.lblImpuestoDolares.TabIndex = 248
        Me.lblImpuestoDolares.Text = "0.00"
        Me.lblImpuestoDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotalDolares
        '
        Me.lblDisplayTotalDolares.AutoSize = True
        Me.lblDisplayTotalDolares.Location = New System.Drawing.Point(8, 65)
        Me.lblDisplayTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalDolares.Name = "lblDisplayTotalDolares"
        Me.lblDisplayTotalDolares.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotalDolares.TabIndex = 246
        Me.lblDisplayTotalDolares.Text = "Total :"
        '
        'lblDisplaySubtotalDolares
        '
        Me.lblDisplaySubtotalDolares.AutoSize = True
        Me.lblDisplaySubtotalDolares.Location = New System.Drawing.Point(8, 20)
        Me.lblDisplaySubtotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySubtotalDolares.Name = "lblDisplaySubtotalDolares"
        Me.lblDisplaySubtotalDolares.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplaySubtotalDolares.TabIndex = 242
        Me.lblDisplaySubtotalDolares.Text = "Subtotal :"
        '
        'lblDisplayImpuestoDolares
        '
        Me.lblDisplayImpuestoDolares.AutoSize = True
        Me.lblDisplayImpuestoDolares.Location = New System.Drawing.Point(8, 42)
        Me.lblDisplayImpuestoDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayImpuestoDolares.Name = "lblDisplayImpuestoDolares"
        Me.lblDisplayImpuestoDolares.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplayImpuestoDolares.TabIndex = 244
        Me.lblDisplayImpuestoDolares.Text = "Impuesto :"
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.lblSaldo.Location = New System.Drawing.Point(259, 20)
        Me.lblSaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(12, 17)
        Me.lblSaldo.TabIndex = 298
        Me.lblSaldo.Text = "."
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(187, 20)
        Me.lblDisplaySaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplaySaldo.TabIndex = 297
        Me.lblDisplaySaldo.Text = "Saldo :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 746)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1339, 29)
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
        Me.frmDatos.Controls.Add(Me.lblConceptoCancelacion)
        Me.frmDatos.Controls.Add(Me.TxtConceptoCancelacion)
        Me.frmDatos.Controls.Add(Me.cboFormaPago)
        Me.frmDatos.Controls.Add(Me.lblVersionCFDI)
        Me.frmDatos.Controls.Add(Me.cboUsoCFDI)
        Me.frmDatos.Controls.Add(Me.lblDisplayMetodoPago)
        Me.frmDatos.Controls.Add(Me.cboMetodoPago)
        Me.frmDatos.Controls.Add(Me.lblDisplayUsoCFDI)
        Me.frmDatos.Controls.Add(Me.CboTipoCredito)
        Me.frmDatos.Controls.Add(Me.LblTipoCredito)
        Me.frmDatos.Controls.Add(Me.ckbMostrarUtilidad)
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
        Me.frmDatos.Size = New System.Drawing.Size(1315, 267)
        Me.frmDatos.TabIndex = 0
        Me.frmDatos.TabStop = False
        '
        'lblConceptoCancelacion
        '
        Me.lblConceptoCancelacion.AutoSize = True
        Me.lblConceptoCancelacion.Location = New System.Drawing.Point(996, 134)
        Me.lblConceptoCancelacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConceptoCancelacion.Name = "lblConceptoCancelacion"
        Me.lblConceptoCancelacion.Size = New System.Drawing.Size(175, 17)
        Me.lblConceptoCancelacion.TabIndex = 385
        Me.lblConceptoCancelacion.Text = "Concepto de cancelación :"
        '
        'TxtConceptoCancelacion
        '
        Me.TxtConceptoCancelacion.Location = New System.Drawing.Point(999, 157)
        Me.TxtConceptoCancelacion.MaxLength = 120
        Me.TxtConceptoCancelacion.Multiline = True
        Me.TxtConceptoCancelacion.Name = "TxtConceptoCancelacion"
        Me.TxtConceptoCancelacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConceptoCancelacion.Size = New System.Drawing.Size(301, 65)
        Me.TxtConceptoCancelacion.TabIndex = 384
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(112, 203)
        Me.cboFormaPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(272, 24)
        Me.cboFormaPago.TabIndex = 9
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
        'cboUsoCFDI
        '
        Me.cboUsoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsoCFDI.FormattingEnabled = True
        Me.cboUsoCFDI.Location = New System.Drawing.Point(563, 139)
        Me.cboUsoCFDI.Margin = New System.Windows.Forms.Padding(4)
        Me.cboUsoCFDI.MaxLength = 1
        Me.cboUsoCFDI.Name = "cboUsoCFDI"
        Me.cboUsoCFDI.Size = New System.Drawing.Size(400, 24)
        Me.cboUsoCFDI.TabIndex = 14
        '
        'lblDisplayMetodoPago
        '
        Me.lblDisplayMetodoPago.AutoSize = True
        Me.lblDisplayMetodoPago.Location = New System.Drawing.Point(437, 208)
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
        Me.cboMetodoPago.Location = New System.Drawing.Point(563, 204)
        Me.cboMetodoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMetodoPago.MaxLength = 1
        Me.cboMetodoPago.Name = "cboMetodoPago"
        Me.cboMetodoPago.Size = New System.Drawing.Size(400, 24)
        Me.cboMetodoPago.TabIndex = 15
        '
        'lblDisplayUsoCFDI
        '
        Me.lblDisplayUsoCFDI.AutoSize = True
        Me.lblDisplayUsoCFDI.Location = New System.Drawing.Point(437, 145)
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
        'LblTipoCredito
        '
        Me.LblTipoCredito.AutoSize = True
        Me.LblTipoCredito.Location = New System.Drawing.Point(852, 108)
        Me.LblTipoCredito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTipoCredito.Name = "LblTipoCredito"
        Me.LblTipoCredito.Size = New System.Drawing.Size(91, 17)
        Me.LblTipoCredito.TabIndex = 376
        Me.LblTipoCredito.Text = "Tipo crédito :"
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
        Me.txtNumeroCuentaPago.TabIndex = 11
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
        Me.lblFormaPago.Location = New System.Drawing.Point(3, 208)
        Me.lblFormaPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(112, 17)
        Me.lblFormaPago.TabIndex = 335
        Me.lblFormaPago.Text = "Forma de pago :"
        '
        'llblAgregarSeguimiento
        '
        Me.llblAgregarSeguimiento.AutoSize = True
        Me.llblAgregarSeguimiento.Location = New System.Drawing.Point(853, 180)
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
        Me.gbTotales.Location = New System.Drawing.Point(11, 610)
        Me.gbTotales.Margin = New System.Windows.Forms.Padding(4)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Padding = New System.Windows.Forms.Padding(4)
        Me.gbTotales.Size = New System.Drawing.Size(1315, 133)
        Me.gbTotales.TabIndex = 2
        Me.gbTotales.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1137, 20)
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
        Me.lblIEPSIncluido.Location = New System.Drawing.Point(1093, 42)
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
        Me.btnAgregaAddenda.Location = New System.Drawing.Point(424, 91)
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
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(11, 309)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1315, 293)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1307, 264)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Artículos"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.Grid.Size = New System.Drawing.Size(1292, 251)
        Me.Grid.TabIndex = 2
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridSeries)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1307, 264)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Series"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.GridSeries.Size = New System.Drawing.Size(1288, 244)
        Me.GridSeries.TabIndex = 2
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Ventas_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1339, 775)
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
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
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
    Friend WithEvents lblTotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblSubtotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblImpuestoDolares As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySubtotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblDisplayImpuestoDolares As System.Windows.Forms.Label
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
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
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
    Friend WithEvents LblTipoCredito As System.Windows.Forms.Label
    Friend WithEvents cboUsoCFDI As ComboBox
    Friend WithEvents lblDisplayMetodoPago As Label
    Friend WithEvents cboMetodoPago As ComboBox
    Friend WithEvents lblDisplayUsoCFDI As Label
    Friend WithEvents lblVersionCFDI As Label
    Friend WithEvents tsbRecuperarXMLPDF As ToolStripButton
    Friend WithEvents lblConceptoCancelacion As System.Windows.Forms.Label
    Friend WithEvents TxtConceptoCancelacion As System.Windows.Forms.TextBox
End Class
