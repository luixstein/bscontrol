<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CFDI_VisorXML
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CFDI_VisorXML))
        Me.GridConceptos = New FlexCell.Grid()
        Me.GridImpuestos = New FlexCell.Grid()
        Me.txtUUID = New System.Windows.Forms.TextBox()
        Me.lblDisplayUUID = New System.Windows.Forms.Label()
        Me.lblDisplayConceptos = New System.Windows.Forms.Label()
        Me.lblDisplayEmisorRFC = New System.Windows.Forms.Label()
        Me.txtEmisorRFC = New System.Windows.Forms.TextBox()
        Me.lblDisplayReceptorRFC = New System.Windows.Forms.Label()
        Me.txtReceptorRFC = New System.Windows.Forms.TextBox()
        Me.lblDisplaySubtotal = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.lblDisplayDescuento = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.lblDisplaySerie = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.lblDisplayEmisorNombre = New System.Windows.Forms.Label()
        Me.txtEmisorNombre = New System.Windows.Forms.TextBox()
        Me.lblDisplayReceptorNombre = New System.Windows.Forms.Label()
        Me.txtReceptorNombre = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFechaCaptura = New System.Windows.Forms.Label()
        Me.lblDisplayTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblDisplayMoneda = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoCambio = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbAbrirArchivoXML = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblDisplayImpuestos = New System.Windows.Forms.Label()
        Me.lblDisplayMetodoPago = New System.Windows.Forms.Label()
        Me.txtMetodoPago = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoDeComprobante = New System.Windows.Forms.Label()
        Me.txtTipoDeComprobante = New System.Windows.Forms.TextBox()
        Me.lblAvisoMonedaNoMXN = New System.Windows.Forms.Label()
        Me.GridCfdiRelacionados = New FlexCell.Grid()
        Me.lblDisplayCFDIsRelacionados = New System.Windows.Forms.Label()
        Me.lblDisplayTipoRelacion = New System.Windows.Forms.Label()
        Me.txtTipoRelacion = New System.Windows.Forms.TextBox()
        Me.txtFormaPago = New System.Windows.Forms.TextBox()
        Me.lblDisplayFormaPago = New System.Windows.Forms.Label()
        Me.lblDisplayCondicionesDePago = New System.Windows.Forms.Label()
        Me.txtCondicionesDePago = New System.Windows.Forms.TextBox()
        Me.lblDisplayLugarExpedicion = New System.Windows.Forms.Label()
        Me.txtLugarExpedicion = New System.Windows.Forms.TextBox()
        Me.lblDisplayDocumentosRelacionados = New System.Windows.Forms.Label()
        Me.GridCP = New FlexCell.Grid()
        Me.gbComplementoPago = New System.Windows.Forms.GroupBox()
        Me.lblDisplayCPNomBancoOrdExt = New System.Windows.Forms.Label()
        Me.txtCPNomBancoOrdExt = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPNumOperacion = New System.Windows.Forms.Label()
        Me.txtCPNumOperacion = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPCtaBeneficiario = New System.Windows.Forms.Label()
        Me.txtCPCtaBeneficiario = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPCtaOrdenante = New System.Windows.Forms.Label()
        Me.txtCPCtaOrdenante = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPRFCEmisorCtaBen = New System.Windows.Forms.Label()
        Me.txtCPRFCEmisorCtaBen = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPRFCEmisorCtaOrd = New System.Windows.Forms.Label()
        Me.txtCPRFCEmisorCtaOrd = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPTipoCambio = New System.Windows.Forms.Label()
        Me.txtCPTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPMoneda = New System.Windows.Forms.Label()
        Me.txtCPMoneda = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPMonto = New System.Windows.Forms.Label()
        Me.txtCPMonto = New System.Windows.Forms.TextBox()
        Me.lblDisplayCPFormaPago = New System.Windows.Forms.Label()
        Me.txtCPFormaPago = New System.Windows.Forms.TextBox()
        Me.dtCPFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayCPFecha = New System.Windows.Forms.Label()
        Me.lblDisplayUsoCFDI = New System.Windows.Forms.Label()
        Me.txtUsoCFDI = New System.Windows.Forms.TextBox()
        Me.lblEsRuta = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gbComplementoPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridConceptos
        '
        Me.GridConceptos.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.GridConceptos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridConceptos.CheckedImage = CType(resources.GetObject("GridConceptos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridConceptos.Cols = 14
        Me.GridConceptos.DefaultFont = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GridConceptos.DefaultRowHeight = CType(21, Short)
        Me.GridConceptos.DisplayRowNumber = True
        Me.GridConceptos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridConceptos.FixedRows = 2
        Me.GridConceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridConceptos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridConceptos.Location = New System.Drawing.Point(13, 292)
        Me.GridConceptos.LockButton = True
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.Rows = 3
        Me.GridConceptos.Size = New System.Drawing.Size(1055, 87)
        Me.GridConceptos.TabIndex = 1
        Me.GridConceptos.TopRow = 2
        Me.GridConceptos.UncheckedImage = CType(resources.GetObject("GridConceptos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GridImpuestos
        '
        Me.GridImpuestos.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.GridImpuestos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridImpuestos.CheckedImage = CType(resources.GetObject("GridImpuestos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridImpuestos.DefaultFont = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GridImpuestos.DefaultRowHeight = CType(21, Short)
        Me.GridImpuestos.DisplayRowNumber = True
        Me.GridImpuestos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridImpuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridImpuestos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridImpuestos.Location = New System.Drawing.Point(600, 62)
        Me.GridImpuestos.LockButton = True
        Me.GridImpuestos.Name = "GridImpuestos"
        Me.GridImpuestos.Rows = 1
        Me.GridImpuestos.Size = New System.Drawing.Size(467, 105)
        Me.GridImpuestos.TabIndex = 2
        Me.GridImpuestos.UncheckedImage = CType(resources.GetObject("GridImpuestos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'txtUUID
        '
        Me.txtUUID.Location = New System.Drawing.Point(85, 62)
        Me.txtUUID.Name = "txtUUID"
        Me.txtUUID.ReadOnly = True
        Me.txtUUID.Size = New System.Drawing.Size(301, 20)
        Me.txtUUID.TabIndex = 3
        '
        'lblDisplayUUID
        '
        Me.lblDisplayUUID.AutoSize = True
        Me.lblDisplayUUID.Location = New System.Drawing.Point(11, 65)
        Me.lblDisplayUUID.Name = "lblDisplayUUID"
        Me.lblDisplayUUID.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayUUID.TabIndex = 4
        Me.lblDisplayUUID.Text = "UUID"
        '
        'lblDisplayConceptos
        '
        Me.lblDisplayConceptos.AutoSize = True
        Me.lblDisplayConceptos.Location = New System.Drawing.Point(12, 276)
        Me.lblDisplayConceptos.Name = "lblDisplayConceptos"
        Me.lblDisplayConceptos.Size = New System.Drawing.Size(58, 13)
        Me.lblDisplayConceptos.TabIndex = 5
        Me.lblDisplayConceptos.Text = "Conceptos"
        '
        'lblDisplayEmisorRFC
        '
        Me.lblDisplayEmisorRFC.AutoSize = True
        Me.lblDisplayEmisorRFC.Location = New System.Drawing.Point(11, 117)
        Me.lblDisplayEmisorRFC.Name = "lblDisplayEmisorRFC"
        Me.lblDisplayEmisorRFC.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplayEmisorRFC.TabIndex = 7
        Me.lblDisplayEmisorRFC.Text = "RFC emisor"
        '
        'txtEmisorRFC
        '
        Me.txtEmisorRFC.Location = New System.Drawing.Point(85, 114)
        Me.txtEmisorRFC.Name = "txtEmisorRFC"
        Me.txtEmisorRFC.ReadOnly = True
        Me.txtEmisorRFC.Size = New System.Drawing.Size(100, 20)
        Me.txtEmisorRFC.TabIndex = 6
        '
        'lblDisplayReceptorRFC
        '
        Me.lblDisplayReceptorRFC.AutoSize = True
        Me.lblDisplayReceptorRFC.Location = New System.Drawing.Point(11, 144)
        Me.lblDisplayReceptorRFC.Name = "lblDisplayReceptorRFC"
        Me.lblDisplayReceptorRFC.Size = New System.Drawing.Size(70, 13)
        Me.lblDisplayReceptorRFC.TabIndex = 9
        Me.lblDisplayReceptorRFC.Text = "RFC receptor"
        '
        'txtReceptorRFC
        '
        Me.txtReceptorRFC.Location = New System.Drawing.Point(85, 140)
        Me.txtReceptorRFC.Name = "txtReceptorRFC"
        Me.txtReceptorRFC.ReadOnly = True
        Me.txtReceptorRFC.Size = New System.Drawing.Size(100, 20)
        Me.txtReceptorRFC.TabIndex = 8
        '
        'lblDisplaySubtotal
        '
        Me.lblDisplaySubtotal.AutoSize = True
        Me.lblDisplaySubtotal.Location = New System.Drawing.Point(11, 169)
        Me.lblDisplaySubtotal.Name = "lblDisplaySubtotal"
        Me.lblDisplaySubtotal.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplaySubtotal.TabIndex = 11
        Me.lblDisplaySubtotal.Text = "Subtotal"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(85, 166)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtSubtotal.TabIndex = 10
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayDescuento
        '
        Me.lblDisplayDescuento.AutoSize = True
        Me.lblDisplayDescuento.Location = New System.Drawing.Point(11, 195)
        Me.lblDisplayDescuento.Name = "lblDisplayDescuento"
        Me.lblDisplayDescuento.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayDescuento.TabIndex = 13
        Me.lblDisplayDescuento.Text = "Descuento"
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(85, 192)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(100, 20)
        Me.txtDescuento.TabIndex = 12
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySerie
        '
        Me.lblDisplaySerie.AutoSize = True
        Me.lblDisplaySerie.Location = New System.Drawing.Point(194, 91)
        Me.lblDisplaySerie.Name = "lblDisplaySerie"
        Me.lblDisplaySerie.Size = New System.Drawing.Size(31, 13)
        Me.lblDisplaySerie.TabIndex = 15
        Me.lblDisplaySerie.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(286, 88)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(100, 20)
        Me.txtSerie.TabIndex = 14
        '
        'lblDisplayEmisorNombre
        '
        Me.lblDisplayEmisorNombre.AutoSize = True
        Me.lblDisplayEmisorNombre.Location = New System.Drawing.Point(194, 117)
        Me.lblDisplayEmisorNombre.Name = "lblDisplayEmisorNombre"
        Me.lblDisplayEmisorNombre.Size = New System.Drawing.Size(77, 13)
        Me.lblDisplayEmisorNombre.TabIndex = 17
        Me.lblDisplayEmisorNombre.Text = "Nombre emisor"
        '
        'txtEmisorNombre
        '
        Me.txtEmisorNombre.Location = New System.Drawing.Point(286, 114)
        Me.txtEmisorNombre.Name = "txtEmisorNombre"
        Me.txtEmisorNombre.ReadOnly = True
        Me.txtEmisorNombre.Size = New System.Drawing.Size(306, 20)
        Me.txtEmisorNombre.TabIndex = 16
        '
        'lblDisplayReceptorNombre
        '
        Me.lblDisplayReceptorNombre.AutoSize = True
        Me.lblDisplayReceptorNombre.Location = New System.Drawing.Point(194, 144)
        Me.lblDisplayReceptorNombre.Name = "lblDisplayReceptorNombre"
        Me.lblDisplayReceptorNombre.Size = New System.Drawing.Size(86, 13)
        Me.lblDisplayReceptorNombre.TabIndex = 19
        Me.lblDisplayReceptorNombre.Text = "Nombre receptor"
        '
        'txtReceptorNombre
        '
        Me.txtReceptorNombre.Location = New System.Drawing.Point(286, 140)
        Me.txtReceptorNombre.Name = "txtReceptorNombre"
        Me.txtReceptorNombre.ReadOnly = True
        Me.txtReceptorNombre.Size = New System.Drawing.Size(306, 20)
        Me.txtReceptorNombre.TabIndex = 18
        '
        'lblDisplayFolio
        '
        Me.lblDisplayFolio.AutoSize = True
        Me.lblDisplayFolio.Location = New System.Drawing.Point(11, 91)
        Me.lblDisplayFolio.Name = "lblDisplayFolio"
        Me.lblDisplayFolio.Size = New System.Drawing.Size(29, 13)
        Me.lblDisplayFolio.TabIndex = 21
        Me.lblDisplayFolio.Text = "Folio"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(85, 88)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(100, 20)
        Me.txtFolio.TabIndex = 20
        '
        'dtFecha
        '
        Me.dtFecha.Enabled = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(286, 36)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtFecha.TabIndex = 222
        '
        'lblDisplayFechaCaptura
        '
        Me.lblDisplayFechaCaptura.AutoSize = True
        Me.lblDisplayFechaCaptura.Location = New System.Drawing.Point(194, 39)
        Me.lblDisplayFechaCaptura.Name = "lblDisplayFechaCaptura"
        Me.lblDisplayFechaCaptura.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFechaCaptura.TabIndex = 223
        Me.lblDisplayFechaCaptura.Text = "Fecha :"
        '
        'lblDisplayTotal
        '
        Me.lblDisplayTotal.AutoSize = True
        Me.lblDisplayTotal.Location = New System.Drawing.Point(11, 221)
        Me.lblDisplayTotal.Name = "lblDisplayTotal"
        Me.lblDisplayTotal.Size = New System.Drawing.Size(31, 13)
        Me.lblDisplayTotal.TabIndex = 225
        Me.lblDisplayTotal.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(85, 218)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 224
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayMoneda
        '
        Me.lblDisplayMoneda.AutoSize = True
        Me.lblDisplayMoneda.Location = New System.Drawing.Point(194, 221)
        Me.lblDisplayMoneda.Name = "lblDisplayMoneda"
        Me.lblDisplayMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplayMoneda.TabIndex = 227
        Me.lblDisplayMoneda.Text = "Moneda"
        '
        'txtMoneda
        '
        Me.txtMoneda.Location = New System.Drawing.Point(286, 218)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(100, 20)
        Me.txtMoneda.TabIndex = 226
        Me.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(400, 221)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayTipoCambio.TabIndex = 229
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(492, 218)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(100, 20)
        Me.txtTipoCambio.TabIndex = 228
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAbrirArchivoXML, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1074, 27)
        Me.tsMenu.TabIndex = 230
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbAbrirArchivoXML
        '
        Me.tsbAbrirArchivoXML.Image = CType(resources.GetObject("tsbAbrirArchivoXML.Image"), System.Drawing.Image)
        Me.tsbAbrirArchivoXML.Name = "tsbAbrirArchivoXML"
        Me.tsbAbrirArchivoXML.Size = New System.Drawing.Size(126, 24)
        Me.tsbAbrirArchivoXML.Text = "&Abrir archivo XML"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'lblDisplayImpuestos
        '
        Me.lblDisplayImpuestos.AutoSize = True
        Me.lblDisplayImpuestos.Location = New System.Drawing.Point(598, 46)
        Me.lblDisplayImpuestos.Name = "lblDisplayImpuestos"
        Me.lblDisplayImpuestos.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayImpuestos.TabIndex = 231
        Me.lblDisplayImpuestos.Text = "Impuestos"
        '
        'lblDisplayMetodoPago
        '
        Me.lblDisplayMetodoPago.AutoSize = True
        Me.lblDisplayMetodoPago.Location = New System.Drawing.Point(194, 195)
        Me.lblDisplayMetodoPago.Name = "lblDisplayMetodoPago"
        Me.lblDisplayMetodoPago.Size = New System.Drawing.Size(70, 13)
        Me.lblDisplayMetodoPago.TabIndex = 235
        Me.lblDisplayMetodoPago.Text = "Método pago"
        '
        'txtMetodoPago
        '
        Me.txtMetodoPago.Location = New System.Drawing.Point(286, 192)
        Me.txtMetodoPago.Name = "txtMetodoPago"
        Me.txtMetodoPago.ReadOnly = True
        Me.txtMetodoPago.Size = New System.Drawing.Size(100, 20)
        Me.txtMetodoPago.TabIndex = 234
        '
        'lblDisplayTipoDeComprobante
        '
        Me.lblDisplayTipoDeComprobante.AutoSize = True
        Me.lblDisplayTipoDeComprobante.Location = New System.Drawing.Point(11, 39)
        Me.lblDisplayTipoDeComprobante.Name = "lblDisplayTipoDeComprobante"
        Me.lblDisplayTipoDeComprobante.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplayTipoDeComprobante.TabIndex = 237
        Me.lblDisplayTipoDeComprobante.Text = "Tipo Comp."
        '
        'txtTipoDeComprobante
        '
        Me.txtTipoDeComprobante.Location = New System.Drawing.Point(85, 36)
        Me.txtTipoDeComprobante.Name = "txtTipoDeComprobante"
        Me.txtTipoDeComprobante.ReadOnly = True
        Me.txtTipoDeComprobante.Size = New System.Drawing.Size(85, 20)
        Me.txtTipoDeComprobante.TabIndex = 236
        '
        'lblAvisoMonedaNoMXN
        '
        Me.lblAvisoMonedaNoMXN.AutoSize = True
        Me.lblAvisoMonedaNoMXN.ForeColor = System.Drawing.Color.Red
        Me.lblAvisoMonedaNoMXN.Location = New System.Drawing.Point(404, 27)
        Me.lblAvisoMonedaNoMXN.Name = "lblAvisoMonedaNoMXN"
        Me.lblAvisoMonedaNoMXN.Size = New System.Drawing.Size(663, 13)
        Me.lblAvisoMonedaNoMXN.TabIndex = 240
        Me.lblAvisoMonedaNoMXN.Text = "*Este xml no está en MXN, cada uno los valores que el sistema muestra de momento " &
    "están expresadas están en la moneda del documento."
        Me.lblAvisoMonedaNoMXN.Visible = False
        '
        'GridCfdiRelacionados
        '
        Me.GridCfdiRelacionados.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.GridCfdiRelacionados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCfdiRelacionados.CheckedImage = CType(resources.GetObject("GridCfdiRelacionados.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCfdiRelacionados.DefaultFont = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GridCfdiRelacionados.DefaultRowHeight = CType(21, Short)
        Me.GridCfdiRelacionados.DisplayRowNumber = True
        Me.GridCfdiRelacionados.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCfdiRelacionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCfdiRelacionados.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCfdiRelacionados.Location = New System.Drawing.Point(600, 194)
        Me.GridCfdiRelacionados.LockButton = True
        Me.GridCfdiRelacionados.Name = "GridCfdiRelacionados"
        Me.GridCfdiRelacionados.Rows = 1
        Me.GridCfdiRelacionados.Size = New System.Drawing.Size(468, 92)
        Me.GridCfdiRelacionados.TabIndex = 241
        Me.GridCfdiRelacionados.UncheckedImage = CType(resources.GetObject("GridCfdiRelacionados.UncheckedImage"), System.Drawing.Bitmap)
        '
        'lblDisplayCFDIsRelacionados
        '
        Me.lblDisplayCFDIsRelacionados.AutoSize = True
        Me.lblDisplayCFDIsRelacionados.Location = New System.Drawing.Point(598, 178)
        Me.lblDisplayCFDIsRelacionados.Name = "lblDisplayCFDIsRelacionados"
        Me.lblDisplayCFDIsRelacionados.Size = New System.Drawing.Size(99, 13)
        Me.lblDisplayCFDIsRelacionados.TabIndex = 242
        Me.lblDisplayCFDIsRelacionados.Text = "CFDIs relacionados"
        '
        'lblDisplayTipoRelacion
        '
        Me.lblDisplayTipoRelacion.AutoSize = True
        Me.lblDisplayTipoRelacion.Location = New System.Drawing.Point(699, 178)
        Me.lblDisplayTipoRelacion.Name = "lblDisplayTipoRelacion"
        Me.lblDisplayTipoRelacion.Size = New System.Drawing.Size(68, 13)
        Me.lblDisplayTipoRelacion.TabIndex = 244
        Me.lblDisplayTipoRelacion.Text = "Tipo relación"
        '
        'txtTipoRelacion
        '
        Me.txtTipoRelacion.Location = New System.Drawing.Point(773, 173)
        Me.txtTipoRelacion.Name = "txtTipoRelacion"
        Me.txtTipoRelacion.ReadOnly = True
        Me.txtTipoRelacion.Size = New System.Drawing.Size(294, 20)
        Me.txtTipoRelacion.TabIndex = 243
        '
        'txtFormaPago
        '
        Me.txtFormaPago.Location = New System.Drawing.Point(286, 166)
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.ReadOnly = True
        Me.txtFormaPago.Size = New System.Drawing.Size(100, 20)
        Me.txtFormaPago.TabIndex = 232
        '
        'lblDisplayFormaPago
        '
        Me.lblDisplayFormaPago.AutoSize = True
        Me.lblDisplayFormaPago.Location = New System.Drawing.Point(194, 169)
        Me.lblDisplayFormaPago.Name = "lblDisplayFormaPago"
        Me.lblDisplayFormaPago.Size = New System.Drawing.Size(63, 13)
        Me.lblDisplayFormaPago.TabIndex = 233
        Me.lblDisplayFormaPago.Text = "Forma pago"
        '
        'lblDisplayCondicionesDePago
        '
        Me.lblDisplayCondicionesDePago.AutoSize = True
        Me.lblDisplayCondicionesDePago.Location = New System.Drawing.Point(400, 169)
        Me.lblDisplayCondicionesDePago.Name = "lblDisplayCondicionesDePago"
        Me.lblDisplayCondicionesDePago.Size = New System.Drawing.Size(92, 13)
        Me.lblDisplayCondicionesDePago.TabIndex = 246
        Me.lblDisplayCondicionesDePago.Text = "Condiciones pago"
        '
        'txtCondicionesDePago
        '
        Me.txtCondicionesDePago.Location = New System.Drawing.Point(492, 166)
        Me.txtCondicionesDePago.Name = "txtCondicionesDePago"
        Me.txtCondicionesDePago.ReadOnly = True
        Me.txtCondicionesDePago.Size = New System.Drawing.Size(100, 20)
        Me.txtCondicionesDePago.TabIndex = 245
        '
        'lblDisplayLugarExpedicion
        '
        Me.lblDisplayLugarExpedicion.AutoSize = True
        Me.lblDisplayLugarExpedicion.Location = New System.Drawing.Point(400, 195)
        Me.lblDisplayLugarExpedicion.Name = "lblDisplayLugarExpedicion"
        Me.lblDisplayLugarExpedicion.Size = New System.Drawing.Size(88, 13)
        Me.lblDisplayLugarExpedicion.TabIndex = 248
        Me.lblDisplayLugarExpedicion.Text = "Lugar expedición"
        '
        'txtLugarExpedicion
        '
        Me.txtLugarExpedicion.Location = New System.Drawing.Point(492, 192)
        Me.txtLugarExpedicion.Name = "txtLugarExpedicion"
        Me.txtLugarExpedicion.ReadOnly = True
        Me.txtLugarExpedicion.Size = New System.Drawing.Size(100, 20)
        Me.txtLugarExpedicion.TabIndex = 247
        '
        'lblDisplayDocumentosRelacionados
        '
        Me.lblDisplayDocumentosRelacionados.AutoSize = True
        Me.lblDisplayDocumentosRelacionados.Location = New System.Drawing.Point(10, 485)
        Me.lblDisplayDocumentosRelacionados.Name = "lblDisplayDocumentosRelacionados"
        Me.lblDisplayDocumentosRelacionados.Size = New System.Drawing.Size(130, 13)
        Me.lblDisplayDocumentosRelacionados.TabIndex = 249
        Me.lblDisplayDocumentosRelacionados.Text = "Documentos relacionados"
        Me.lblDisplayDocumentosRelacionados.Visible = False
        '
        'GridCP
        '
        Me.GridCP.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.GridCP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCP.CheckedImage = CType(resources.GetObject("GridCP.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCP.Cols = 11
        Me.GridCP.DefaultFont = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GridCP.DefaultRowHeight = CType(21, Short)
        Me.GridCP.DisplayRowNumber = True
        Me.GridCP.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCP.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCP.Location = New System.Drawing.Point(13, 501)
        Me.GridCP.LockButton = True
        Me.GridCP.Name = "GridCP"
        Me.GridCP.Rows = 1
        Me.GridCP.Size = New System.Drawing.Size(1055, 92)
        Me.GridCP.TabIndex = 250
        Me.GridCP.UncheckedImage = CType(resources.GetObject("GridCP.UncheckedImage"), System.Drawing.Bitmap)
        Me.GridCP.Visible = False
        '
        'gbComplementoPago
        '
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPNomBancoOrdExt)
        Me.gbComplementoPago.Controls.Add(Me.txtCPNomBancoOrdExt)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPNumOperacion)
        Me.gbComplementoPago.Controls.Add(Me.txtCPNumOperacion)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPCtaBeneficiario)
        Me.gbComplementoPago.Controls.Add(Me.txtCPCtaBeneficiario)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPCtaOrdenante)
        Me.gbComplementoPago.Controls.Add(Me.txtCPCtaOrdenante)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPRFCEmisorCtaBen)
        Me.gbComplementoPago.Controls.Add(Me.txtCPRFCEmisorCtaBen)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPRFCEmisorCtaOrd)
        Me.gbComplementoPago.Controls.Add(Me.txtCPRFCEmisorCtaOrd)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPTipoCambio)
        Me.gbComplementoPago.Controls.Add(Me.txtCPTipoCambio)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPMoneda)
        Me.gbComplementoPago.Controls.Add(Me.txtCPMoneda)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPMonto)
        Me.gbComplementoPago.Controls.Add(Me.txtCPMonto)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPFormaPago)
        Me.gbComplementoPago.Controls.Add(Me.txtCPFormaPago)
        Me.gbComplementoPago.Controls.Add(Me.dtCPFecha)
        Me.gbComplementoPago.Controls.Add(Me.lblDisplayCPFecha)
        Me.gbComplementoPago.Location = New System.Drawing.Point(12, 385)
        Me.gbComplementoPago.Name = "gbComplementoPago"
        Me.gbComplementoPago.Size = New System.Drawing.Size(1055, 100)
        Me.gbComplementoPago.TabIndex = 251
        Me.gbComplementoPago.TabStop = False
        Me.gbComplementoPago.Text = "Complemento pago"
        Me.gbComplementoPago.Visible = False
        '
        'lblDisplayCPNomBancoOrdExt
        '
        Me.lblDisplayCPNomBancoOrdExt.AutoSize = True
        Me.lblDisplayCPNomBancoOrdExt.Location = New System.Drawing.Point(615, 74)
        Me.lblDisplayCPNomBancoOrdExt.Name = "lblDisplayCPNomBancoOrdExt"
        Me.lblDisplayCPNomBancoOrdExt.Size = New System.Drawing.Size(97, 13)
        Me.lblDisplayCPNomBancoOrdExt.TabIndex = 255
        Me.lblDisplayCPNomBancoOrdExt.Text = "Nom banco ord ext"
        '
        'txtCPNomBancoOrdExt
        '
        Me.txtCPNomBancoOrdExt.Location = New System.Drawing.Point(719, 71)
        Me.txtCPNomBancoOrdExt.Name = "txtCPNomBancoOrdExt"
        Me.txtCPNomBancoOrdExt.ReadOnly = True
        Me.txtCPNomBancoOrdExt.Size = New System.Drawing.Size(122, 20)
        Me.txtCPNomBancoOrdExt.TabIndex = 254
        '
        'lblDisplayCPNumOperacion
        '
        Me.lblDisplayCPNumOperacion.AutoSize = True
        Me.lblDisplayCPNumOperacion.Location = New System.Drawing.Point(392, 74)
        Me.lblDisplayCPNumOperacion.Name = "lblDisplayCPNumOperacion"
        Me.lblDisplayCPNumOperacion.Size = New System.Drawing.Size(79, 13)
        Me.lblDisplayCPNumOperacion.TabIndex = 253
        Me.lblDisplayCPNumOperacion.Text = "Num operación"
        '
        'txtCPNumOperacion
        '
        Me.txtCPNumOperacion.Location = New System.Drawing.Point(496, 71)
        Me.txtCPNumOperacion.Name = "txtCPNumOperacion"
        Me.txtCPNumOperacion.ReadOnly = True
        Me.txtCPNumOperacion.Size = New System.Drawing.Size(100, 20)
        Me.txtCPNumOperacion.TabIndex = 252
        '
        'lblDisplayCPCtaBeneficiario
        '
        Me.lblDisplayCPCtaBeneficiario.AutoSize = True
        Me.lblDisplayCPCtaBeneficiario.Location = New System.Drawing.Point(615, 48)
        Me.lblDisplayCPCtaBeneficiario.Name = "lblDisplayCPCtaBeneficiario"
        Me.lblDisplayCPCtaBeneficiario.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayCPCtaBeneficiario.TabIndex = 251
        Me.lblDisplayCPCtaBeneficiario.Text = "Cta beneficiario"
        '
        'txtCPCtaBeneficiario
        '
        Me.txtCPCtaBeneficiario.Location = New System.Drawing.Point(719, 45)
        Me.txtCPCtaBeneficiario.Name = "txtCPCtaBeneficiario"
        Me.txtCPCtaBeneficiario.ReadOnly = True
        Me.txtCPCtaBeneficiario.Size = New System.Drawing.Size(122, 20)
        Me.txtCPCtaBeneficiario.TabIndex = 250
        '
        'lblDisplayCPCtaOrdenante
        '
        Me.lblDisplayCPCtaOrdenante.AutoSize = True
        Me.lblDisplayCPCtaOrdenante.Location = New System.Drawing.Point(615, 22)
        Me.lblDisplayCPCtaOrdenante.Name = "lblDisplayCPCtaOrdenante"
        Me.lblDisplayCPCtaOrdenante.Size = New System.Drawing.Size(74, 13)
        Me.lblDisplayCPCtaOrdenante.TabIndex = 249
        Me.lblDisplayCPCtaOrdenante.Text = "Cta ordenante"
        '
        'txtCPCtaOrdenante
        '
        Me.txtCPCtaOrdenante.Location = New System.Drawing.Point(719, 19)
        Me.txtCPCtaOrdenante.Name = "txtCPCtaOrdenante"
        Me.txtCPCtaOrdenante.ReadOnly = True
        Me.txtCPCtaOrdenante.Size = New System.Drawing.Size(122, 20)
        Me.txtCPCtaOrdenante.TabIndex = 248
        '
        'lblDisplayCPRFCEmisorCtaBen
        '
        Me.lblDisplayCPRFCEmisorCtaBen.AutoSize = True
        Me.lblDisplayCPRFCEmisorCtaBen.Location = New System.Drawing.Point(392, 48)
        Me.lblDisplayCPRFCEmisorCtaBen.Name = "lblDisplayCPRFCEmisorCtaBen"
        Me.lblDisplayCPRFCEmisorCtaBen.Size = New System.Drawing.Size(100, 13)
        Me.lblDisplayCPRFCEmisorCtaBen.TabIndex = 247
        Me.lblDisplayCPRFCEmisorCtaBen.Text = "RFC emisor cta ben"
        '
        'txtCPRFCEmisorCtaBen
        '
        Me.txtCPRFCEmisorCtaBen.Location = New System.Drawing.Point(496, 45)
        Me.txtCPRFCEmisorCtaBen.Name = "txtCPRFCEmisorCtaBen"
        Me.txtCPRFCEmisorCtaBen.ReadOnly = True
        Me.txtCPRFCEmisorCtaBen.Size = New System.Drawing.Size(100, 20)
        Me.txtCPRFCEmisorCtaBen.TabIndex = 246
        '
        'lblDisplayCPRFCEmisorCtaOrd
        '
        Me.lblDisplayCPRFCEmisorCtaOrd.AutoSize = True
        Me.lblDisplayCPRFCEmisorCtaOrd.Location = New System.Drawing.Point(392, 22)
        Me.lblDisplayCPRFCEmisorCtaOrd.Name = "lblDisplayCPRFCEmisorCtaOrd"
        Me.lblDisplayCPRFCEmisorCtaOrd.Size = New System.Drawing.Size(97, 13)
        Me.lblDisplayCPRFCEmisorCtaOrd.TabIndex = 245
        Me.lblDisplayCPRFCEmisorCtaOrd.Text = "RFC emisor cta ord"
        '
        'txtCPRFCEmisorCtaOrd
        '
        Me.txtCPRFCEmisorCtaOrd.Location = New System.Drawing.Point(496, 19)
        Me.txtCPRFCEmisorCtaOrd.Name = "txtCPRFCEmisorCtaOrd"
        Me.txtCPRFCEmisorCtaOrd.ReadOnly = True
        Me.txtCPRFCEmisorCtaOrd.Size = New System.Drawing.Size(100, 20)
        Me.txtCPRFCEmisorCtaOrd.TabIndex = 244
        '
        'lblDisplayCPTipoCambio
        '
        Me.lblDisplayCPTipoCambio.AutoSize = True
        Me.lblDisplayCPTipoCambio.Location = New System.Drawing.Point(182, 71)
        Me.lblDisplayCPTipoCambio.Name = "lblDisplayCPTipoCambio"
        Me.lblDisplayCPTipoCambio.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayCPTipoCambio.TabIndex = 243
        Me.lblDisplayCPTipoCambio.Text = "Tipo de cambio"
        '
        'txtCPTipoCambio
        '
        Me.txtCPTipoCambio.Location = New System.Drawing.Point(274, 71)
        Me.txtCPTipoCambio.Name = "txtCPTipoCambio"
        Me.txtCPTipoCambio.ReadOnly = True
        Me.txtCPTipoCambio.Size = New System.Drawing.Size(100, 20)
        Me.txtCPTipoCambio.TabIndex = 242
        Me.txtCPTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayCPMoneda
        '
        Me.lblDisplayCPMoneda.AutoSize = True
        Me.lblDisplayCPMoneda.Location = New System.Drawing.Point(182, 48)
        Me.lblDisplayCPMoneda.Name = "lblDisplayCPMoneda"
        Me.lblDisplayCPMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplayCPMoneda.TabIndex = 241
        Me.lblDisplayCPMoneda.Text = "Moneda"
        '
        'txtCPMoneda
        '
        Me.txtCPMoneda.Location = New System.Drawing.Point(274, 45)
        Me.txtCPMoneda.Name = "txtCPMoneda"
        Me.txtCPMoneda.ReadOnly = True
        Me.txtCPMoneda.Size = New System.Drawing.Size(100, 20)
        Me.txtCPMoneda.TabIndex = 240
        Me.txtCPMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayCPMonto
        '
        Me.lblDisplayCPMonto.AutoSize = True
        Me.lblDisplayCPMonto.Location = New System.Drawing.Point(7, 48)
        Me.lblDisplayCPMonto.Name = "lblDisplayCPMonto"
        Me.lblDisplayCPMonto.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayCPMonto.TabIndex = 239
        Me.lblDisplayCPMonto.Text = "Monto"
        '
        'txtCPMonto
        '
        Me.txtCPMonto.Location = New System.Drawing.Point(73, 45)
        Me.txtCPMonto.Name = "txtCPMonto"
        Me.txtCPMonto.ReadOnly = True
        Me.txtCPMonto.Size = New System.Drawing.Size(100, 20)
        Me.txtCPMonto.TabIndex = 238
        Me.txtCPMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayCPFormaPago
        '
        Me.lblDisplayCPFormaPago.AutoSize = True
        Me.lblDisplayCPFormaPago.Location = New System.Drawing.Point(182, 22)
        Me.lblDisplayCPFormaPago.Name = "lblDisplayCPFormaPago"
        Me.lblDisplayCPFormaPago.Size = New System.Drawing.Size(63, 13)
        Me.lblDisplayCPFormaPago.TabIndex = 237
        Me.lblDisplayCPFormaPago.Text = "Forma pago"
        '
        'txtCPFormaPago
        '
        Me.txtCPFormaPago.Location = New System.Drawing.Point(274, 19)
        Me.txtCPFormaPago.Name = "txtCPFormaPago"
        Me.txtCPFormaPago.ReadOnly = True
        Me.txtCPFormaPago.Size = New System.Drawing.Size(100, 20)
        Me.txtCPFormaPago.TabIndex = 236
        '
        'dtCPFecha
        '
        Me.dtCPFecha.Enabled = False
        Me.dtCPFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtCPFecha.Location = New System.Drawing.Point(73, 19)
        Me.dtCPFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtCPFecha.Name = "dtCPFecha"
        Me.dtCPFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtCPFecha.TabIndex = 224
        '
        'lblDisplayCPFecha
        '
        Me.lblDisplayCPFecha.AutoSize = True
        Me.lblDisplayCPFecha.Location = New System.Drawing.Point(7, 22)
        Me.lblDisplayCPFecha.Name = "lblDisplayCPFecha"
        Me.lblDisplayCPFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayCPFecha.TabIndex = 225
        Me.lblDisplayCPFecha.Text = "Fecha"
        '
        'lblDisplayUsoCFDI
        '
        Me.lblDisplayUsoCFDI.AutoSize = True
        Me.lblDisplayUsoCFDI.Location = New System.Drawing.Point(194, 247)
        Me.lblDisplayUsoCFDI.Name = "lblDisplayUsoCFDI"
        Me.lblDisplayUsoCFDI.Size = New System.Drawing.Size(53, 13)
        Me.lblDisplayUsoCFDI.TabIndex = 253
        Me.lblDisplayUsoCFDI.Text = "Uso CFDI"
        '
        'txtUsoCFDI
        '
        Me.txtUsoCFDI.Location = New System.Drawing.Point(286, 244)
        Me.txtUsoCFDI.Name = "txtUsoCFDI"
        Me.txtUsoCFDI.ReadOnly = True
        Me.txtUsoCFDI.Size = New System.Drawing.Size(100, 20)
        Me.txtUsoCFDI.TabIndex = 252
        Me.txtUsoCFDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEsRuta
        '
        Me.lblEsRuta.AutoSize = True
        Me.lblEsRuta.Location = New System.Drawing.Point(1048, 592)
        Me.lblEsRuta.Name = "lblEsRuta"
        Me.lblEsRuta.Size = New System.Drawing.Size(19, 13)
        Me.lblEsRuta.TabIndex = 256
        Me.lblEsRuta.Text = "*R"
        Me.lblEsRuta.Visible = False
        '
        'Frm_CFDI_VisorXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 605)
        Me.Controls.Add(Me.lblEsRuta)
        Me.Controls.Add(Me.lblDisplayUsoCFDI)
        Me.Controls.Add(Me.txtUsoCFDI)
        Me.Controls.Add(Me.gbComplementoPago)
        Me.Controls.Add(Me.lblDisplayDocumentosRelacionados)
        Me.Controls.Add(Me.GridCP)
        Me.Controls.Add(Me.lblDisplayLugarExpedicion)
        Me.Controls.Add(Me.txtLugarExpedicion)
        Me.Controls.Add(Me.lblDisplayCondicionesDePago)
        Me.Controls.Add(Me.txtCondicionesDePago)
        Me.Controls.Add(Me.lblDisplayTipoRelacion)
        Me.Controls.Add(Me.txtTipoRelacion)
        Me.Controls.Add(Me.lblDisplayCFDIsRelacionados)
        Me.Controls.Add(Me.GridCfdiRelacionados)
        Me.Controls.Add(Me.lblAvisoMonedaNoMXN)
        Me.Controls.Add(Me.lblDisplayTipoDeComprobante)
        Me.Controls.Add(Me.txtTipoDeComprobante)
        Me.Controls.Add(Me.lblDisplayMetodoPago)
        Me.Controls.Add(Me.txtMetodoPago)
        Me.Controls.Add(Me.lblDisplayFormaPago)
        Me.Controls.Add(Me.txtFormaPago)
        Me.Controls.Add(Me.lblDisplayImpuestos)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.lblDisplayTipoCambio)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.lblDisplayMoneda)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.lblDisplayTotal)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.lblDisplayFechaCaptura)
        Me.Controls.Add(Me.lblDisplayFolio)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.lblDisplayReceptorNombre)
        Me.Controls.Add(Me.txtReceptorNombre)
        Me.Controls.Add(Me.lblDisplayEmisorNombre)
        Me.Controls.Add(Me.txtEmisorNombre)
        Me.Controls.Add(Me.lblDisplaySerie)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.lblDisplayDescuento)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.lblDisplaySubtotal)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.lblDisplayReceptorRFC)
        Me.Controls.Add(Me.txtReceptorRFC)
        Me.Controls.Add(Me.lblDisplayEmisorRFC)
        Me.Controls.Add(Me.txtEmisorRFC)
        Me.Controls.Add(Me.lblDisplayConceptos)
        Me.Controls.Add(Me.lblDisplayUUID)
        Me.Controls.Add(Me.txtUUID)
        Me.Controls.Add(Me.GridImpuestos)
        Me.Controls.Add(Me.GridConceptos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Frm_CFDI_VisorXML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visor XML"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbComplementoPago.ResumeLayout(False)
        Me.gbComplementoPago.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridConceptos As FlexCell.Grid
    Friend WithEvents GridImpuestos As FlexCell.Grid
    Friend WithEvents txtUUID As TextBox
    Friend WithEvents lblDisplayUUID As Label
    Friend WithEvents lblDisplayConceptos As Label
    Friend WithEvents lblDisplayEmisorRFC As Label
    Friend WithEvents txtEmisorRFC As TextBox
    Friend WithEvents lblDisplayReceptorRFC As Label
    Friend WithEvents txtReceptorRFC As TextBox
    Friend WithEvents lblDisplaySubtotal As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents lblDisplayDescuento As Label
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents lblDisplaySerie As Label
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents lblDisplayEmisorNombre As Label
    Friend WithEvents txtEmisorNombre As TextBox
    Friend WithEvents lblDisplayReceptorNombre As Label
    Friend WithEvents txtReceptorNombre As TextBox
    Friend WithEvents lblDisplayFolio As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents lblDisplayFechaCaptura As Label
    Friend WithEvents lblDisplayTotal As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblDisplayMoneda As Label
    Friend WithEvents txtMoneda As TextBox
    Friend WithEvents lblDisplayTipoCambio As Label
    Friend WithEvents txtTipoCambio As TextBox
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents lblDisplayImpuestos As Label
    Friend WithEvents lblDisplayMetodoPago As Label
    Friend WithEvents txtMetodoPago As TextBox
    Friend WithEvents lblDisplayTipoDeComprobante As Label
    Friend WithEvents txtTipoDeComprobante As TextBox
    Friend WithEvents lblAvisoMonedaNoMXN As Label
    Friend WithEvents tsbAbrirArchivoXML As ToolStripButton
    Friend WithEvents GridCfdiRelacionados As FlexCell.Grid
    Friend WithEvents lblDisplayCFDIsRelacionados As Label
    Friend WithEvents lblDisplayTipoRelacion As Label
    Friend WithEvents txtTipoRelacion As TextBox
    Friend WithEvents txtFormaPago As TextBox
    Friend WithEvents lblDisplayFormaPago As Label
    Friend WithEvents lblDisplayCondicionesDePago As Label
    Friend WithEvents txtCondicionesDePago As TextBox
    Friend WithEvents lblDisplayLugarExpedicion As Label
    Friend WithEvents txtLugarExpedicion As TextBox
    Friend WithEvents lblDisplayDocumentosRelacionados As Label
    Friend WithEvents GridCP As FlexCell.Grid
    Friend WithEvents gbComplementoPago As GroupBox
    Friend WithEvents lblDisplayCPTipoCambio As Label
    Friend WithEvents txtCPTipoCambio As TextBox
    Friend WithEvents lblDisplayCPMoneda As Label
    Friend WithEvents txtCPMoneda As TextBox
    Friend WithEvents lblDisplayCPMonto As Label
    Friend WithEvents txtCPMonto As TextBox
    Friend WithEvents lblDisplayCPFormaPago As Label
    Friend WithEvents txtCPFormaPago As TextBox
    Friend WithEvents dtCPFecha As DateTimePicker
    Friend WithEvents lblDisplayCPFecha As Label
    Friend WithEvents lblDisplayCPCtaBeneficiario As Label
    Friend WithEvents txtCPCtaBeneficiario As TextBox
    Friend WithEvents lblDisplayCPCtaOrdenante As Label
    Friend WithEvents txtCPCtaOrdenante As TextBox
    Friend WithEvents lblDisplayCPRFCEmisorCtaBen As Label
    Friend WithEvents txtCPRFCEmisorCtaBen As TextBox
    Friend WithEvents lblDisplayCPRFCEmisorCtaOrd As Label
    Friend WithEvents txtCPRFCEmisorCtaOrd As TextBox
    Friend WithEvents lblDisplayCPNumOperacion As Label
    Friend WithEvents txtCPNumOperacion As TextBox
    Friend WithEvents lblDisplayCPNomBancoOrdExt As Label
    Friend WithEvents txtCPNomBancoOrdExt As TextBox
    Friend WithEvents lblDisplayUsoCFDI As Label
    Friend WithEvents txtUsoCFDI As TextBox
    Friend WithEvents lblEsRuta As Label
End Class
