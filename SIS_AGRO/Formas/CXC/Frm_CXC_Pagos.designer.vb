<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_CXC_Pagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXC_Pagos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirPoliza = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirComprobante = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbGlobal = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalUSD = New System.Windows.Forms.MaskedTextBox()
        Me.cboRegimenFiscal = New System.Windows.Forms.ComboBox()
        Me.lblDisplayRegimenFiscal = New System.Windows.Forms.Label()
        Me.lblEsCuentaFiscal = New System.Windows.Forms.Label()
        Me.chkVentasNoFiscales = New System.Windows.Forms.CheckBox()
        Me.cmdPruebaPagoCFDI = New System.Windows.Forms.Button()
        Me.TxtTotal = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstClientesAgregados = New System.Windows.Forms.ListView()
        Me.col_CodigoSocio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_NombreSocio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.col_Total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.btnDepositosSiguiente = New System.Windows.Forms.Button()
        Me.btnDepositosAnterior = New System.Windows.Forms.Button()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblCuentaContableCuentaBancaria = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.LblDisplayConcepto = New System.Windows.Forms.Label()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.LblCuentaBancaria = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.LblDisplayCuentaBancaria = New System.Windows.Forms.Label()
        Me.TxtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.CboMedioDePago = New System.Windows.Forms.ComboBox()
        Me.LblDisplayMedioPago = New System.Windows.Forms.Label()
        Me.gbAgregaDocCliente = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTiposVentas = New System.Windows.Forms.Label()
        Me.cboTipoVentas = New System.Windows.Forms.ComboBox()
        Me.cmdSeleccionaSPEI = New System.Windows.Forms.Button()
        Me.txtSPEI_cadenaCDA = New System.Windows.Forms.TextBox()
        Me.txtSPEI_sello = New System.Windows.Forms.TextBox()
        Me.txtSPEI_numeroCertificado = New System.Windows.Forms.TextBox()
        Me.dtFechaCheque = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFechaCheque = New System.Windows.Forms.Label()
        Me.dtFechaPagoCliente = New System.Windows.Forms.DateTimePicker()
        Me.CboBancos = New System.Windows.Forms.ComboBox()
        Me.txtCuentaEmisor = New System.Windows.Forms.TextBox()
        Me.txtFolioDetalle = New System.Windows.Forms.TextBox()
        Me.btnEditarCuentaBancariaCliente = New System.Windows.Forms.Button()
        Me.btnAgregarCuentaBancariaCliente = New System.Windows.Forms.Button()
        Me.lblDisplayCuenta = New System.Windows.Forms.Label()
        Me.lblRFCEmisor = New System.Windows.Forms.Label()
        Me.lblDisplayRFCEmisor = New System.Windows.Forms.Label()
        Me.cboCuentaEmisor = New System.Windows.Forms.ComboBox()
        Me.txtRFCEmisor = New System.Windows.Forms.TextBox()
        Me.btnLimpiarDocumentoPagos = New System.Windows.Forms.Button()
        Me.lblDisplayMonto = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDisplayCuentaEmisor = New System.Windows.Forms.Label()
        Me.lblDisplayFolioDetalle = New System.Windows.Forms.Label()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.cboMonedaPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayFormaPago = New System.Windows.Forms.Label()
        Me.chkAnticipo = New System.Windows.Forms.CheckBox()
        Me.btnAgregarDocumentosClientes = New System.Windows.Forms.Button()
        Me.LblDisplayReferencia = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.LblDisplayBanco = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.LblDisplayCliente = New System.Windows.Forms.Label()
        Me.TxtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.chkEsBancoExtranjero = New System.Windows.Forms.CheckBox()
        Me.gbVentas = New System.Windows.Forms.GroupBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssFechaEmisionCFDI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbDocumentosPago = New System.Windows.Forms.GroupBox()
        Me.btnEliminarDocumentoPago = New System.Windows.Forms.Button()
        Me.GridDocumentosPago = New FlexCell.Grid()
        Me.btnVerCFDIS = New System.Windows.Forms.Button()
        Me.btnGenerarCFDIS = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GridVentas = New FlexCell.Grid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridCFDIsRelacionados = New FlexCell.Grid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoRelacionCFDI = New System.Windows.Forms.ComboBox()
        Me.tsMenu.SuspendLayout()
        Me.gbGlobal.SuspendLayout()
        Me.gbAgregaDocCliente.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbDocumentosPago.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirPoliza, Me.tsbImprimirComprobante, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1539, 27)
        Me.tsMenu.TabIndex = 5
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
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(94, 24)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbImprimirPoliza
        '
        Me.tsbImprimirPoliza.Image = CType(resources.GetObject("tsbImprimirPoliza.Image"), System.Drawing.Image)
        Me.tsbImprimirPoliza.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirPoliza.Name = "tsbImprimirPoliza"
        Me.tsbImprimirPoliza.Size = New System.Drawing.Size(135, 24)
        Me.tsbImprimirPoliza.Text = "&Imprimir póliza"
        Me.tsbImprimirPoliza.ToolTipText = "Imprimir"
        '
        'tsbImprimirComprobante
        '
        Me.tsbImprimirComprobante.Image = CType(resources.GetObject("tsbImprimirComprobante.Image"), System.Drawing.Image)
        Me.tsbImprimirComprobante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirComprobante.Name = "tsbImprimirComprobante"
        Me.tsbImprimirComprobante.Size = New System.Drawing.Size(184, 24)
        Me.tsbImprimirComprobante.Text = "Imprimir comprobante"
        Me.tsbImprimirComprobante.ToolTipText = "Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.Label2)
        Me.gbGlobal.Controls.Add(Me.txtTotalUSD)
        Me.gbGlobal.Controls.Add(Me.cboRegimenFiscal)
        Me.gbGlobal.Controls.Add(Me.lblDisplayRegimenFiscal)
        Me.gbGlobal.Controls.Add(Me.lblEsCuentaFiscal)
        Me.gbGlobal.Controls.Add(Me.chkVentasNoFiscales)
        Me.gbGlobal.Controls.Add(Me.cmdPruebaPagoCFDI)
        Me.gbGlobal.Controls.Add(Me.TxtTotal)
        Me.gbGlobal.Controls.Add(Me.Label1)
        Me.gbGlobal.Controls.Add(Me.lstClientesAgregados)
        Me.gbGlobal.Controls.Add(Me.TxtConcepto)
        Me.gbGlobal.Controls.Add(Me.btnDepositosSiguiente)
        Me.gbGlobal.Controls.Add(Me.btnDepositosAnterior)
        Me.gbGlobal.Controls.Add(Me.lblTipoCambio)
        Me.gbGlobal.Controls.Add(Me.txtTipoCambio)
        Me.gbGlobal.Controls.Add(Me.LblPoliza)
        Me.gbGlobal.Controls.Add(Me.CboDocumento)
        Me.gbGlobal.Controls.Add(Me.LblFecha)
        Me.gbGlobal.Controls.Add(Me.Label8)
        Me.gbGlobal.Controls.Add(Me.LblCuentaContableCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.dtFecha)
        Me.gbGlobal.Controls.Add(Me.LblDocumento)
        Me.gbGlobal.Controls.Add(Me.LblDisplayConcepto)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFolio)
        Me.gbGlobal.Controls.Add(Me.TxtFolio)
        Me.gbGlobal.Controls.Add(Me.lblDisplayStatus)
        Me.gbGlobal.Controls.Add(Me.LblCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.LblStatus)
        Me.gbGlobal.Controls.Add(Me.LblDisplayCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.TxtCuentaBancaria)
        Me.gbGlobal.Location = New System.Drawing.Point(11, 34)
        Me.gbGlobal.Margin = New System.Windows.Forms.Padding(4)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Padding = New System.Windows.Forms.Padding(4)
        Me.gbGlobal.Size = New System.Drawing.Size(1379, 191)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Datos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1013, 165)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 20)
        Me.Label2.TabIndex = 403
        Me.Label2.Text = "Total USD :"
        '
        'txtTotalUSD
        '
        Me.txtTotalUSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSD.Location = New System.Drawing.Point(1145, 161)
        Me.txtTotalUSD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalUSD.Name = "txtTotalUSD"
        Me.txtTotalUSD.ReadOnly = True
        Me.txtTotalUSD.Size = New System.Drawing.Size(163, 26)
        Me.txtTotalUSD.TabIndex = 402
        Me.txtTotalUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboRegimenFiscal
        '
        Me.cboRegimenFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegimenFiscal.FormattingEnabled = True
        Me.cboRegimenFiscal.Location = New System.Drawing.Point(504, 154)
        Me.cboRegimenFiscal.Margin = New System.Windows.Forms.Padding(4)
        Me.cboRegimenFiscal.MaxLength = 1
        Me.cboRegimenFiscal.Name = "cboRegimenFiscal"
        Me.cboRegimenFiscal.Size = New System.Drawing.Size(444, 24)
        Me.cboRegimenFiscal.TabIndex = 400
        '
        'lblDisplayRegimenFiscal
        '
        Me.lblDisplayRegimenFiscal.AutoSize = True
        Me.lblDisplayRegimenFiscal.Location = New System.Drawing.Point(396, 159)
        Me.lblDisplayRegimenFiscal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRegimenFiscal.Name = "lblDisplayRegimenFiscal"
        Me.lblDisplayRegimenFiscal.Size = New System.Drawing.Size(108, 17)
        Me.lblDisplayRegimenFiscal.TabIndex = 401
        Me.lblDisplayRegimenFiscal.Text = "Régimen fiscal :"
        '
        'lblEsCuentaFiscal
        '
        Me.lblEsCuentaFiscal.AutoSize = True
        Me.lblEsCuentaFiscal.Location = New System.Drawing.Point(133, 159)
        Me.lblEsCuentaFiscal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEsCuentaFiscal.Name = "lblEsCuentaFiscal"
        Me.lblEsCuentaFiscal.Size = New System.Drawing.Size(13, 17)
        Me.lblEsCuentaFiscal.TabIndex = 383
        Me.lblEsCuentaFiscal.Text = "*"
        '
        'chkVentasNoFiscales
        '
        Me.chkVentasNoFiscales.AutoSize = True
        Me.chkVentasNoFiscales.Location = New System.Drawing.Point(160, 159)
        Me.chkVentasNoFiscales.Margin = New System.Windows.Forms.Padding(4)
        Me.chkVentasNoFiscales.Name = "chkVentasNoFiscales"
        Me.chkVentasNoFiscales.Size = New System.Drawing.Size(155, 21)
        Me.chkVentasNoFiscales.TabIndex = 382
        Me.chkVentasNoFiscales.Text = "Pago de remisiones"
        Me.chkVentasNoFiscales.UseVisualStyleBackColor = True
        Me.chkVentasNoFiscales.Visible = False
        '
        'cmdPruebaPagoCFDI
        '
        Me.cmdPruebaPagoCFDI.Location = New System.Drawing.Point(676, 82)
        Me.cmdPruebaPagoCFDI.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPruebaPagoCFDI.Name = "cmdPruebaPagoCFDI"
        Me.cmdPruebaPagoCFDI.Size = New System.Drawing.Size(141, 37)
        Me.cmdPruebaPagoCFDI.TabIndex = 378
        Me.cmdPruebaPagoCFDI.Text = "Prueba CFDI-Pago"
        Me.cmdPruebaPagoCFDI.UseVisualStyleBackColor = True
        Me.cmdPruebaPagoCFDI.Visible = False
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(1145, 129)
        Me.TxtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(163, 26)
        Me.TxtTotal.TabIndex = 376
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1013, 133)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 377
        Me.Label1.Text = "Total MXN :"
        '
        'lstClientesAgregados
        '
        Me.lstClientesAgregados.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lstClientesAgregados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_CodigoSocio, Me.col_NombreSocio, Me.col_Total})
        Me.lstClientesAgregados.GridLines = True
        Me.lstClientesAgregados.Location = New System.Drawing.Point(845, 28)
        Me.lstClientesAgregados.Margin = New System.Windows.Forms.Padding(4)
        Me.lstClientesAgregados.Name = "lstClientesAgregados"
        Me.lstClientesAgregados.Size = New System.Drawing.Size(493, 95)
        Me.lstClientesAgregados.TabIndex = 375
        Me.lstClientesAgregados.UseCompatibleStateImageBehavior = False
        Me.lstClientesAgregados.View = System.Windows.Forms.View.Details
        '
        'col_CodigoSocio
        '
        Me.col_CodigoSocio.Tag = "STRING"
        Me.col_CodigoSocio.Text = "Código"
        Me.col_CodigoSocio.Width = 49
        '
        'col_NombreSocio
        '
        Me.col_NombreSocio.Text = "Nombre"
        Me.col_NombreSocio.Width = 199
        '
        'col_Total
        '
        Me.col_Total.Tag = "NUMBER"
        Me.col_Total.Text = "Total"
        Me.col_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.col_Total.Width = 100
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(504, 126)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(444, 22)
        Me.TxtConcepto.TabIndex = 5
        '
        'btnDepositosSiguiente
        '
        Me.btnDepositosSiguiente.Location = New System.Drawing.Point(376, 86)
        Me.btnDepositosSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDepositosSiguiente.Name = "btnDepositosSiguiente"
        Me.btnDepositosSiguiente.Size = New System.Drawing.Size(43, 32)
        Me.btnDepositosSiguiente.TabIndex = 374
        Me.btnDepositosSiguiente.Text = ">>"
        Me.btnDepositosSiguiente.UseVisualStyleBackColor = True
        '
        'btnDepositosAnterior
        '
        Me.btnDepositosAnterior.Location = New System.Drawing.Point(325, 86)
        Me.btnDepositosAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDepositosAnterior.Name = "btnDepositosAnterior"
        Me.btnDepositosAnterior.Size = New System.Drawing.Size(43, 32)
        Me.btnDepositosAnterior.TabIndex = 373
        Me.btnDepositosAnterior.Text = "<<"
        Me.btnDepositosAnterior.UseVisualStyleBackColor = True
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Enabled = False
        Me.lblTipoCambio.Location = New System.Drawing.Point(427, 95)
        Me.lblTipoCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(113, 17)
        Me.lblTipoCambio.TabIndex = 305
        Me.lblTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(547, 95)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(103, 22)
        Me.txtTipoCambio.TabIndex = 304
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblPoliza
        '
        Me.LblPoliza.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblPoliza.Location = New System.Drawing.Point(659, 26)
        Me.LblPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(140, 16)
        Me.LblPoliza.TabIndex = 291
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(137, 23)
        Me.CboDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(280, 24)
        Me.CboDocumento.TabIndex = 0
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(11, 129)
        Me.LblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(55, 17)
        Me.LblFecha.TabIndex = 175
        Me.LblFecha.Text = "Fecha :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(595, 26)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 17)
        Me.Label8.TabIndex = 287
        Me.Label8.Text = "Póliza :"
        '
        'LblCuentaContableCuentaBancaria
        '
        Me.LblCuentaContableCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaContableCuentaBancaria.Location = New System.Drawing.Point(564, 59)
        Me.LblCuentaContableCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuentaContableCuentaBancaria.Name = "LblCuentaContableCuentaBancaria"
        Me.LblCuentaContableCuentaBancaria.Size = New System.Drawing.Size(235, 16)
        Me.LblCuentaContableCuentaBancaria.TabIndex = 224
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(137, 126)
        Me.dtFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(280, 22)
        Me.dtFecha.TabIndex = 3
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(11, 28)
        Me.LblDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(88, 17)
        Me.LblDocumento.TabIndex = 177
        Me.LblDocumento.Text = "Documento :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(427, 129)
        Me.LblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayConcepto.TabIndex = 185
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(11, 95)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 216
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(137, 86)
        Me.TxtFolio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(179, 30)
        Me.TxtFolio.TabIndex = 2
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(427, 27)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 217
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblCuentaBancaria
        '
        Me.LblCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaBancaria.Location = New System.Drawing.Point(200, 59)
        Me.LblCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuentaBancaria.Name = "LblCuentaBancaria"
        Me.LblCuentaBancaria.Size = New System.Drawing.Size(356, 16)
        Me.LblCuentaBancaria.TabIndex = 223
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(497, 27)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(91, 16)
        Me.LblStatus.TabIndex = 218
        '
        'LblDisplayCuentaBancaria
        '
        Me.LblDisplayCuentaBancaria.AutoSize = True
        Me.LblDisplayCuentaBancaria.Location = New System.Drawing.Point(11, 59)
        Me.LblDisplayCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCuentaBancaria.Name = "LblDisplayCuentaBancaria"
        Me.LblDisplayCuentaBancaria.Size = New System.Drawing.Size(120, 17)
        Me.LblDisplayCuentaBancaria.TabIndex = 222
        Me.LblDisplayCuentaBancaria.Text = "Cuenta bancaria :"
        '
        'TxtCuentaBancaria
        '
        Me.TxtCuentaBancaria.Location = New System.Drawing.Point(137, 54)
        Me.TxtCuentaBancaria.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCuentaBancaria.MaxLength = 6
        Me.TxtCuentaBancaria.Name = "TxtCuentaBancaria"
        Me.TxtCuentaBancaria.Size = New System.Drawing.Size(53, 22)
        Me.TxtCuentaBancaria.TabIndex = 1
        '
        'CboMedioDePago
        '
        Me.CboMedioDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMedioDePago.FormattingEnabled = True
        Me.CboMedioDePago.Location = New System.Drawing.Point(1137, 463)
        Me.CboMedioDePago.Margin = New System.Windows.Forms.Padding(4)
        Me.CboMedioDePago.Name = "CboMedioDePago"
        Me.CboMedioDePago.Size = New System.Drawing.Size(280, 24)
        Me.CboMedioDePago.TabIndex = 1
        Me.CboMedioDePago.Visible = False
        '
        'LblDisplayMedioPago
        '
        Me.LblDisplayMedioPago.AutoSize = True
        Me.LblDisplayMedioPago.Location = New System.Drawing.Point(1276, 443)
        Me.LblDisplayMedioPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayMedioPago.Name = "LblDisplayMedioPago"
        Me.LblDisplayMedioPago.Size = New System.Drawing.Size(111, 17)
        Me.LblDisplayMedioPago.TabIndex = 312
        Me.LblDisplayMedioPago.Text = "Medio de Pago :"
        Me.LblDisplayMedioPago.Visible = False
        '
        'gbAgregaDocCliente
        '
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayTiposVentas)
        Me.gbAgregaDocCliente.Controls.Add(Me.cboTipoVentas)
        Me.gbAgregaDocCliente.Controls.Add(Me.cmdSeleccionaSPEI)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtSPEI_cadenaCDA)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtSPEI_sello)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtSPEI_numeroCertificado)
        Me.gbAgregaDocCliente.Controls.Add(Me.dtFechaCheque)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayFechaCheque)
        Me.gbAgregaDocCliente.Controls.Add(Me.dtFechaPagoCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.CboBancos)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtCuentaEmisor)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtFolioDetalle)
        Me.gbAgregaDocCliente.Controls.Add(Me.btnEditarCuentaBancariaCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.btnAgregarCuentaBancariaCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayCuenta)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblRFCEmisor)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayRFCEmisor)
        Me.gbAgregaDocCliente.Controls.Add(Me.cboCuentaEmisor)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtRFCEmisor)
        Me.gbAgregaDocCliente.Controls.Add(Me.btnLimpiarDocumentoPagos)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayMonto)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtMonto)
        Me.gbAgregaDocCliente.Controls.Add(Me.Label5)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayCuentaEmisor)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayFolioDetalle)
        Me.gbAgregaDocCliente.Controls.Add(Me.cboFormaPago)
        Me.gbAgregaDocCliente.Controls.Add(Me.cboMonedaPago)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayFormaPago)
        Me.gbAgregaDocCliente.Controls.Add(Me.chkAnticipo)
        Me.gbAgregaDocCliente.Controls.Add(Me.btnAgregarDocumentosClientes)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblDisplayReferencia)
        Me.gbAgregaDocCliente.Controls.Add(Me.TxtReferencia)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblDisplayBanco)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblDisplayCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.TxtCodigoCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.chkEsBancoExtranjero)
        Me.gbAgregaDocCliente.Location = New System.Drawing.Point(11, 231)
        Me.gbAgregaDocCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.gbAgregaDocCliente.Name = "gbAgregaDocCliente"
        Me.gbAgregaDocCliente.Padding = New System.Windows.Forms.Padding(4)
        Me.gbAgregaDocCliente.Size = New System.Drawing.Size(1379, 172)
        Me.gbAgregaDocCliente.TabIndex = 1
        Me.gbAgregaDocCliente.TabStop = False
        Me.gbAgregaDocCliente.Text = "Documentos de pago :"
        '
        'lblDisplayTiposVentas
        '
        Me.lblDisplayTiposVentas.AutoSize = True
        Me.lblDisplayTiposVentas.Location = New System.Drawing.Point(284, 149)
        Me.lblDisplayTiposVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTiposVentas.Name = "lblDisplayTiposVentas"
        Me.lblDisplayTiposVentas.Size = New System.Drawing.Size(83, 17)
        Me.lblDisplayTiposVentas.TabIndex = 389
        Me.lblDisplayTiposVentas.Text = "Ventas del :"
        '
        'cboTipoVentas
        '
        Me.cboTipoVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVentas.Enabled = False
        Me.cboTipoVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoVentas.FormattingEnabled = True
        Me.cboTipoVentas.Items.AddRange(New Object() {"MISMO RFC CLIENTE", "MISMO CODIGO CLIENTE"})
        Me.cboTipoVentas.Location = New System.Drawing.Point(389, 144)
        Me.cboTipoVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoVentas.Name = "cboTipoVentas"
        Me.cboTipoVentas.Size = New System.Drawing.Size(235, 25)
        Me.cboTipoVentas.TabIndex = 388
        '
        'cmdSeleccionaSPEI
        '
        Me.cmdSeleccionaSPEI.Location = New System.Drawing.Point(977, 144)
        Me.cmdSeleccionaSPEI.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSeleccionaSPEI.Name = "cmdSeleccionaSPEI"
        Me.cmdSeleccionaSPEI.Size = New System.Drawing.Size(141, 30)
        Me.cmdSeleccionaSPEI.TabIndex = 387
        Me.cmdSeleccionaSPEI.Text = "Selecciona SPEI"
        Me.cmdSeleccionaSPEI.UseVisualStyleBackColor = True
        Me.cmdSeleccionaSPEI.Visible = False
        '
        'txtSPEI_cadenaCDA
        '
        Me.txtSPEI_cadenaCDA.Location = New System.Drawing.Point(921, 146)
        Me.txtSPEI_cadenaCDA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSPEI_cadenaCDA.MaxLength = 0
        Me.txtSPEI_cadenaCDA.Name = "txtSPEI_cadenaCDA"
        Me.txtSPEI_cadenaCDA.Size = New System.Drawing.Size(136, 22)
        Me.txtSPEI_cadenaCDA.TabIndex = 386
        Me.txtSPEI_cadenaCDA.Visible = False
        '
        'txtSPEI_sello
        '
        Me.txtSPEI_sello.Location = New System.Drawing.Point(779, 146)
        Me.txtSPEI_sello.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSPEI_sello.MaxLength = 0
        Me.txtSPEI_sello.Name = "txtSPEI_sello"
        Me.txtSPEI_sello.Size = New System.Drawing.Size(136, 22)
        Me.txtSPEI_sello.TabIndex = 385
        Me.txtSPEI_sello.Visible = False
        '
        'txtSPEI_numeroCertificado
        '
        Me.txtSPEI_numeroCertificado.Location = New System.Drawing.Point(633, 148)
        Me.txtSPEI_numeroCertificado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSPEI_numeroCertificado.MaxLength = 0
        Me.txtSPEI_numeroCertificado.Name = "txtSPEI_numeroCertificado"
        Me.txtSPEI_numeroCertificado.Size = New System.Drawing.Size(136, 22)
        Me.txtSPEI_numeroCertificado.TabIndex = 384
        Me.txtSPEI_numeroCertificado.Visible = False
        '
        'dtFechaCheque
        '
        Me.dtFechaCheque.Location = New System.Drawing.Point(1051, 80)
        Me.dtFechaCheque.Margin = New System.Windows.Forms.Padding(4)
        Me.dtFechaCheque.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaCheque.Name = "dtFechaCheque"
        Me.dtFechaCheque.Size = New System.Drawing.Size(280, 22)
        Me.dtFechaCheque.TabIndex = 345
        '
        'lblDisplayFechaCheque
        '
        Me.lblDisplayFechaCheque.AutoSize = True
        Me.lblDisplayFechaCheque.Location = New System.Drawing.Point(923, 85)
        Me.lblDisplayFechaCheque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaCheque.Name = "lblDisplayFechaCheque"
        Me.lblDisplayFechaCheque.Size = New System.Drawing.Size(129, 17)
        Me.lblDisplayFechaCheque.TabIndex = 346
        Me.lblDisplayFechaCheque.Text = "Fecha del cheque :"
        '
        'dtFechaPagoCliente
        '
        Me.dtFechaPagoCliente.Location = New System.Drawing.Point(1051, 47)
        Me.dtFechaPagoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.dtFechaPagoCliente.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaPagoCliente.Name = "dtFechaPagoCliente"
        Me.dtFechaPagoCliente.Size = New System.Drawing.Size(280, 22)
        Me.dtFechaPagoCliente.TabIndex = 10
        '
        'CboBancos
        '
        Me.CboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBancos.Enabled = False
        Me.CboBancos.FormattingEnabled = True
        Me.CboBancos.Location = New System.Drawing.Point(633, 94)
        Me.CboBancos.Margin = New System.Windows.Forms.Padding(4)
        Me.CboBancos.Name = "CboBancos"
        Me.CboBancos.Size = New System.Drawing.Size(280, 24)
        Me.CboBancos.TabIndex = 8
        '
        'txtCuentaEmisor
        '
        Me.txtCuentaEmisor.Enabled = False
        Me.txtCuentaEmisor.Location = New System.Drawing.Point(759, 47)
        Me.txtCuentaEmisor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaEmisor.MaxLength = 50
        Me.txtCuentaEmisor.Name = "txtCuentaEmisor"
        Me.txtCuentaEmisor.Size = New System.Drawing.Size(164, 22)
        Me.txtCuentaEmisor.TabIndex = 7
        '
        'txtFolioDetalle
        '
        Me.txtFolioDetalle.Location = New System.Drawing.Point(848, 18)
        Me.txtFolioDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioDetalle.MaxLength = 100
        Me.txtFolioDetalle.Name = "txtFolioDetalle"
        Me.txtFolioDetalle.Size = New System.Drawing.Size(136, 22)
        Me.txtFolioDetalle.TabIndex = 6
        '
        'btnEditarCuentaBancariaCliente
        '
        Me.btnEditarCuentaBancariaCliente.Location = New System.Drawing.Point(560, 74)
        Me.btnEditarCuentaBancariaCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEditarCuentaBancariaCliente.Name = "btnEditarCuentaBancariaCliente"
        Me.btnEditarCuentaBancariaCliente.Size = New System.Drawing.Size(71, 46)
        Me.btnEditarCuentaBancariaCliente.TabIndex = 344
        Me.btnEditarCuentaBancariaCliente.Text = "Editar cuenta"
        Me.btnEditarCuentaBancariaCliente.UseVisualStyleBackColor = True
        '
        'btnAgregarCuentaBancariaCliente
        '
        Me.btnAgregarCuentaBancariaCliente.Location = New System.Drawing.Point(485, 74)
        Me.btnAgregarCuentaBancariaCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarCuentaBancariaCliente.Name = "btnAgregarCuentaBancariaCliente"
        Me.btnAgregarCuentaBancariaCliente.Size = New System.Drawing.Size(71, 46)
        Me.btnAgregarCuentaBancariaCliente.TabIndex = 343
        Me.btnAgregarCuentaBancariaCliente.Text = "Agregar cuenta"
        Me.btnAgregarCuentaBancariaCliente.UseVisualStyleBackColor = True
        '
        'lblDisplayCuenta
        '
        Me.lblDisplayCuenta.AutoSize = True
        Me.lblDisplayCuenta.Location = New System.Drawing.Point(8, 52)
        Me.lblDisplayCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuenta.Name = "lblDisplayCuenta"
        Me.lblDisplayCuenta.Size = New System.Drawing.Size(107, 17)
        Me.lblDisplayCuenta.TabIndex = 342
        Me.lblDisplayCuenta.Text = "Cuenta emisor :"
        '
        'lblRFCEmisor
        '
        Me.lblRFCEmisor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblRFCEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCEmisor.Location = New System.Drawing.Point(771, 127)
        Me.lblRFCEmisor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRFCEmisor.Name = "lblRFCEmisor"
        Me.lblRFCEmisor.Size = New System.Drawing.Size(237, 16)
        Me.lblRFCEmisor.TabIndex = 340
        '
        'lblDisplayRFCEmisor
        '
        Me.lblDisplayRFCEmisor.AutoSize = True
        Me.lblDisplayRFCEmisor.Location = New System.Drawing.Point(536, 126)
        Me.lblDisplayRFCEmisor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRFCEmisor.Name = "lblDisplayRFCEmisor"
        Me.lblDisplayRFCEmisor.Size = New System.Drawing.Size(89, 17)
        Me.lblDisplayRFCEmisor.TabIndex = 339
        Me.lblDisplayRFCEmisor.Text = "RFC emisor :"
        '
        'cboCuentaEmisor
        '
        Me.cboCuentaEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuentaEmisor.FormattingEnabled = True
        Me.cboCuentaEmisor.Location = New System.Drawing.Point(132, 47)
        Me.cboCuentaEmisor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCuentaEmisor.Name = "cboCuentaEmisor"
        Me.cboCuentaEmisor.Size = New System.Drawing.Size(497, 24)
        Me.cboCuentaEmisor.TabIndex = 1
        '
        'txtRFCEmisor
        '
        Me.txtRFCEmisor.Location = New System.Drawing.Point(633, 122)
        Me.txtRFCEmisor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRFCEmisor.MaxLength = 13
        Me.txtRFCEmisor.Name = "txtRFCEmisor"
        Me.txtRFCEmisor.Size = New System.Drawing.Size(128, 22)
        Me.txtRFCEmisor.TabIndex = 9
        '
        'btnLimpiarDocumentoPagos
        '
        Me.btnLimpiarDocumentoPagos.Location = New System.Drawing.Point(1232, 126)
        Me.btnLimpiarDocumentoPagos.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLimpiarDocumentoPagos.Name = "btnLimpiarDocumentoPagos"
        Me.btnLimpiarDocumentoPagos.Size = New System.Drawing.Size(100, 37)
        Me.btnLimpiarDocumentoPagos.TabIndex = 13
        Me.btnLimpiarDocumentoPagos.Text = "Limpiar"
        Me.btnLimpiarDocumentoPagos.UseVisualStyleBackColor = True
        '
        'lblDisplayMonto
        '
        Me.lblDisplayMonto.AutoSize = True
        Me.lblDisplayMonto.Location = New System.Drawing.Point(8, 118)
        Me.lblDisplayMonto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayMonto.Name = "lblDisplayMonto"
        Me.lblDisplayMonto.Size = New System.Drawing.Size(55, 17)
        Me.lblDisplayMonto.TabIndex = 336
        Me.lblDisplayMonto.Text = "Monto :"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(132, 114)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMonto.MaxLength = 20
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(143, 22)
        Me.txtMonto.TabIndex = 3
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(923, 47)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 37)
        Me.Label5.TabIndex = 330
        Me.Label5.Text = "Fecha en que pagó el cliente :"
        '
        'lblDisplayCuentaEmisor
        '
        Me.lblDisplayCuentaEmisor.AutoSize = True
        Me.lblDisplayCuentaEmisor.Location = New System.Drawing.Point(639, 49)
        Me.lblDisplayCuentaEmisor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaEmisor.Name = "lblDisplayCuentaEmisor"
        Me.lblDisplayCuentaEmisor.Size = New System.Drawing.Size(119, 17)
        Me.lblDisplayCuentaEmisor.TabIndex = 329
        Me.lblDisplayCuentaEmisor.Text = "# Cuenta emisor :"
        '
        'lblDisplayFolioDetalle
        '
        Me.lblDisplayFolioDetalle.AutoSize = True
        Me.lblDisplayFolioDetalle.Location = New System.Drawing.Point(553, 21)
        Me.lblDisplayFolioDetalle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioDetalle.Name = "lblDisplayFolioDetalle"
        Me.lblDisplayFolioDetalle.Size = New System.Drawing.Size(294, 17)
        Me.lblDisplayFolioDetalle.TabIndex = 328
        Me.lblDisplayFolioDetalle.Text = "Número de operación(Folio chq/transf/ficha) :"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(132, 81)
        Me.cboFormaPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(304, 24)
        Me.cboFormaPago.TabIndex = 2
        '
        'cboMonedaPago
        '
        Me.cboMonedaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonedaPago.Enabled = False
        Me.cboMonedaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonedaPago.FormattingEnabled = True
        Me.cboMonedaPago.Location = New System.Drawing.Point(284, 114)
        Me.cboMonedaPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMonedaPago.Name = "cboMonedaPago"
        Me.cboMonedaPago.Size = New System.Drawing.Size(96, 25)
        Me.cboMonedaPago.TabIndex = 4
        '
        'lblDisplayFormaPago
        '
        Me.lblDisplayFormaPago.AutoSize = True
        Me.lblDisplayFormaPago.Location = New System.Drawing.Point(8, 85)
        Me.lblDisplayFormaPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFormaPago.Name = "lblDisplayFormaPago"
        Me.lblDisplayFormaPago.Size = New System.Drawing.Size(112, 17)
        Me.lblDisplayFormaPago.TabIndex = 327
        Me.lblDisplayFormaPago.Text = "Forma de pago :"
        '
        'chkAnticipo
        '
        Me.chkAnticipo.AutoSize = True
        Me.chkAnticipo.Location = New System.Drawing.Point(389, 118)
        Me.chkAnticipo.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAnticipo.Name = "chkAnticipo"
        Me.chkAnticipo.Size = New System.Drawing.Size(80, 21)
        Me.chkAnticipo.TabIndex = 5
        Me.chkAnticipo.Text = "Anticipo"
        Me.chkAnticipo.UseVisualStyleBackColor = True
        Me.chkAnticipo.Visible = False
        '
        'btnAgregarDocumentosClientes
        '
        Me.btnAgregarDocumentosClientes.Location = New System.Drawing.Point(1127, 126)
        Me.btnAgregarDocumentosClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarDocumentosClientes.Name = "btnAgregarDocumentosClientes"
        Me.btnAgregarDocumentosClientes.Size = New System.Drawing.Size(100, 37)
        Me.btnAgregarDocumentosClientes.TabIndex = 12
        Me.btnAgregarDocumentosClientes.Text = "Agregar"
        Me.btnAgregarDocumentosClientes.UseVisualStyleBackColor = True
        '
        'LblDisplayReferencia
        '
        Me.LblDisplayReferencia.AutoSize = True
        Me.LblDisplayReferencia.Location = New System.Drawing.Point(993, 21)
        Me.LblDisplayReferencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayReferencia.Name = "LblDisplayReferencia"
        Me.LblDisplayReferencia.Size = New System.Drawing.Size(85, 17)
        Me.LblDisplayReferencia.TabIndex = 316
        Me.LblDisplayReferencia.Text = "Referencia :"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(1088, 18)
        Me.TxtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtReferencia.MaxLength = 160
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(243, 22)
        Me.TxtReferencia.TabIndex = 11
        '
        'LblDisplayBanco
        '
        Me.LblDisplayBanco.AutoSize = True
        Me.LblDisplayBanco.Location = New System.Drawing.Point(639, 74)
        Me.LblDisplayBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayBanco.Name = "LblDisplayBanco"
        Me.LblDisplayBanco.Size = New System.Drawing.Size(159, 17)
        Me.LblDisplayBanco.TabIndex = 314
        Me.LblDisplayBanco.Text = "Banco emisor nacional :"
        '
        'LblCliente
        '
        Me.LblCliente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCliente.Location = New System.Drawing.Point(228, 22)
        Me.LblCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(311, 16)
        Me.LblCliente.TabIndex = 239
        '
        'LblDisplayCliente
        '
        Me.LblDisplayCliente.AutoSize = True
        Me.LblDisplayCliente.Location = New System.Drawing.Point(8, 22)
        Me.LblDisplayCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCliente.Name = "LblDisplayCliente"
        Me.LblDisplayCliente.Size = New System.Drawing.Size(59, 17)
        Me.LblDisplayCliente.TabIndex = 238
        Me.LblDisplayCliente.Text = "Cliente :"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(132, 18)
        Me.TxtCodigoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(87, 22)
        Me.TxtCodigoCliente.TabIndex = 0
        '
        'chkEsBancoExtranjero
        '
        Me.chkEsBancoExtranjero.Enabled = False
        Me.chkEsBancoExtranjero.Location = New System.Drawing.Point(53, 145)
        Me.chkEsBancoExtranjero.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEsBancoExtranjero.Name = "chkEsBancoExtranjero"
        Me.chkEsBancoExtranjero.Size = New System.Drawing.Size(183, 26)
        Me.chkEsBancoExtranjero.TabIndex = 385
        Me.chkEsBancoExtranjero.Text = "Es banco extranjero ?"
        Me.chkEsBancoExtranjero.UseVisualStyleBackColor = True
        '
        'gbVentas
        '
        Me.gbVentas.Location = New System.Drawing.Point(1433, 377)
        Me.gbVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.gbVentas.Name = "gbVentas"
        Me.gbVentas.Padding = New System.Windows.Forms.Padding(4)
        Me.gbVentas.Size = New System.Drawing.Size(71, 35)
        Me.gbVentas.TabIndex = 2
        Me.gbVentas.TabStop = False
        Me.gbVentas.Text = "Ventas"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo, Me.tssFechaEmisionCFDI})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 808)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1539, 29)
        Me.StatusStripEstado.TabIndex = 240
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssEstado
        '
        Me.tssEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssEstado.Name = "tssEstado"
        Me.tssEstado.Size = New System.Drawing.Size(65, 24)
        Me.tssEstado.Text = "Estado :"
        '
        'tssElaboro
        '
        Me.tssElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssElaboro.Name = "tssElaboro"
        Me.tssElaboro.Size = New System.Drawing.Size(76, 24)
        Me.tssElaboro.Text = "Elaboró : "
        '
        'tssCancelo
        '
        Me.tssCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssCancelo.Name = "tssCancelo"
        Me.tssCancelo.Size = New System.Drawing.Size(73, 24)
        Me.tssCancelo.Text = "Canceló :"
        '
        'tssFechaEmisionCFDI
        '
        Me.tssFechaEmisionCFDI.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssFechaEmisionCFDI.Name = "tssFechaEmisionCFDI"
        Me.tssFechaEmisionCFDI.Size = New System.Drawing.Size(149, 24)
        Me.tssFechaEmisionCFDI.Text = "Fecha emisión CFDI :"
        '
        'gbDocumentosPago
        '
        Me.gbDocumentosPago.Controls.Add(Me.btnEliminarDocumentoPago)
        Me.gbDocumentosPago.Controls.Add(Me.GridDocumentosPago)
        Me.gbDocumentosPago.Location = New System.Drawing.Point(11, 411)
        Me.gbDocumentosPago.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDocumentosPago.Name = "gbDocumentosPago"
        Me.gbDocumentosPago.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDocumentosPago.Size = New System.Drawing.Size(1379, 111)
        Me.gbDocumentosPago.TabIndex = 1
        Me.gbDocumentosPago.TabStop = False
        Me.gbDocumentosPago.Text = "Documentos de pago :"
        '
        'btnEliminarDocumentoPago
        '
        Me.btnEliminarDocumentoPago.Location = New System.Drawing.Point(1203, 0)
        Me.btnEliminarDocumentoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarDocumentoPago.Name = "btnEliminarDocumentoPago"
        Me.btnEliminarDocumentoPago.Size = New System.Drawing.Size(100, 23)
        Me.btnEliminarDocumentoPago.TabIndex = 13
        Me.btnEliminarDocumentoPago.Text = "Eliminar"
        Me.btnEliminarDocumentoPago.UseVisualStyleBackColor = True
        '
        'GridDocumentosPago
        '
        Me.GridDocumentosPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridDocumentosPago.CheckedImage = CType(resources.GetObject("GridDocumentosPago.CheckedImage"), System.Drawing.Bitmap)
        Me.GridDocumentosPago.Cols = 1
        Me.GridDocumentosPago.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridDocumentosPago.DefaultRowHeight = CType(24, Short)
        Me.GridDocumentosPago.DisplayRowNumber = True
        Me.GridDocumentosPago.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridDocumentosPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDocumentosPago.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridDocumentosPago.Location = New System.Drawing.Point(9, 23)
        Me.GridDocumentosPago.LockButton = True
        Me.GridDocumentosPago.Margin = New System.Windows.Forms.Padding(4)
        Me.GridDocumentosPago.Name = "GridDocumentosPago"
        Me.GridDocumentosPago.Rows = 3
        Me.GridDocumentosPago.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridDocumentosPago.Size = New System.Drawing.Size(1361, 75)
        Me.GridDocumentosPago.TabIndex = 0
        Me.GridDocumentosPago.UncheckedImage = CType(resources.GetObject("GridDocumentosPago.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnVerCFDIS
        '
        Me.btnVerCFDIS.Location = New System.Drawing.Point(1395, 245)
        Me.btnVerCFDIS.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVerCFDIS.Name = "btnVerCFDIS"
        Me.btnVerCFDIS.Size = New System.Drawing.Size(141, 82)
        Me.btnVerCFDIS.TabIndex = 379
        Me.btnVerCFDIS.Text = "Ver CFDI's"
        Me.btnVerCFDIS.UseVisualStyleBackColor = True
        '
        'btnGenerarCFDIS
        '
        Me.btnGenerarCFDIS.Location = New System.Drawing.Point(1395, 151)
        Me.btnGenerarCFDIS.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerarCFDIS.Name = "btnGenerarCFDIS"
        Me.btnGenerarCFDIS.Size = New System.Drawing.Size(141, 82)
        Me.btnGenerarCFDIS.TabIndex = 381
        Me.btnGenerarCFDIS.Text = "Generar CFDI's"
        Me.btnGenerarCFDIS.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(11, 529)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1516, 267)
        Me.TabControl1.TabIndex = 382
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GridVentas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1508, 238)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ventas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GridVentas
        '
        Me.GridVentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridVentas.CheckedImage = CType(resources.GetObject("GridVentas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridVentas.Cols = 1
        Me.GridVentas.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridVentas.DefaultRowHeight = CType(24, Short)
        Me.GridVentas.DisplayRowNumber = True
        Me.GridVentas.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridVentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridVentas.Location = New System.Drawing.Point(0, 0)
        Me.GridVentas.LockButton = True
        Me.GridVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.GridVentas.Name = "GridVentas"
        Me.GridVentas.Rows = 7
        Me.GridVentas.Size = New System.Drawing.Size(1504, 242)
        Me.GridVentas.TabIndex = 1
        Me.GridVentas.UncheckedImage = CType(resources.GetObject("GridVentas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridCFDIsRelacionados)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.cboTipoRelacionCFDI)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1508, 238)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Relacionar CFDIs"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.GridCFDIsRelacionados.Location = New System.Drawing.Point(0, 43)
        Me.GridCFDIsRelacionados.LockButton = True
        Me.GridCFDIsRelacionados.Margin = New System.Windows.Forms.Padding(4)
        Me.GridCFDIsRelacionados.Name = "GridCFDIsRelacionados"
        Me.GridCFDIsRelacionados.Rows = 3
        Me.GridCFDIsRelacionados.Size = New System.Drawing.Size(1393, 197)
        Me.GridCFDIsRelacionados.TabIndex = 388
        Me.GridCFDIsRelacionados.UncheckedImage = CType(resources.GetObject("GridCFDIsRelacionados.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 13)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 17)
        Me.Label3.TabIndex = 387
        Me.Label3.Text = "Tipo relación CFDI :"
        '
        'cboTipoRelacionCFDI
        '
        Me.cboTipoRelacionCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRelacionCFDI.Enabled = False
        Me.cboTipoRelacionCFDI.FormattingEnabled = True
        Me.cboTipoRelacionCFDI.Location = New System.Drawing.Point(148, 9)
        Me.cboTipoRelacionCFDI.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoRelacionCFDI.MaxLength = 1
        Me.cboTipoRelacionCFDI.Name = "cboTipoRelacionCFDI"
        Me.cboTipoRelacionCFDI.Size = New System.Drawing.Size(518, 24)
        Me.cboTipoRelacionCFDI.TabIndex = 386
        '
        'Frm_CXC_Pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1539, 837)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnGenerarCFDIS)
        Me.Controls.Add(Me.btnVerCFDIS)
        Me.Controls.Add(Me.gbDocumentosPago)
        Me.Controls.Add(Me.gbAgregaDocCliente)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbVentas)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.CboMedioDePago)
        Me.Controls.Add(Me.LblDisplayMedioPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_CXC_Pagos"
        Me.Text = "Elaboración de pagos de clientes"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbGlobal.ResumeLayout(False)
        Me.gbGlobal.PerformLayout()
        Me.gbAgregaDocCliente.ResumeLayout(False)
        Me.gbAgregaDocCliente.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbDocumentosPago.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbGlobal As System.Windows.Forms.GroupBox
    Friend WithEvents LblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblCuentaContableCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents LblCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents gbVentas As System.Windows.Forms.GroupBox
    Friend WithEvents gbAgregaDocCliente As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregarDocumentosClientes As System.Windows.Forms.Button
    Friend WithEvents LblDisplayReferencia As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayBanco As System.Windows.Forms.Label
    Friend WithEvents LblDisplayMedioPago As System.Windows.Forms.Label
    Friend WithEvents CboBancos As System.Windows.Forms.ComboBox
    Friend WithEvents CboMedioDePago As System.Windows.Forms.ComboBox
    Friend WithEvents chkAnticipo As System.Windows.Forms.CheckBox
    Friend WithEvents tsbImprimirPoliza As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents btnDepositosSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDepositosAnterior As System.Windows.Forms.Button
    Friend WithEvents cboMonedaPago As System.Windows.Forms.ComboBox
    Friend WithEvents dtFechaPagoCliente As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCuentaEmisor As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioDetalle As System.Windows.Forms.TextBox
    Friend WithEvents cboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayFormaPago As System.Windows.Forms.Label
    Friend WithEvents gbDocumentosPago As System.Windows.Forms.GroupBox
    Friend WithEvents GridDocumentosPago As FlexCell.Grid
    Friend WithEvents lblDisplayMonto As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCuentaEmisor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFolioDetalle As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarDocumentoPagos As System.Windows.Forms.Button
    Friend WithEvents lblDisplayRFCEmisor As System.Windows.Forms.Label
    Friend WithEvents txtRFCEmisor As System.Windows.Forms.TextBox
    Friend WithEvents lblRFCEmisor As System.Windows.Forms.Label
    Friend WithEvents TxtTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstClientesAgregados As System.Windows.Forms.ListView
    Friend WithEvents col_CodigoSocio As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_NombreSocio As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_Total As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnEliminarDocumentoPago As System.Windows.Forms.Button
    Friend WithEvents lblDisplayCuenta As System.Windows.Forms.Label
    Friend WithEvents cboCuentaEmisor As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditarCuentaBancariaCliente As System.Windows.Forms.Button
    Friend WithEvents btnAgregarCuentaBancariaCliente As System.Windows.Forms.Button
    Friend WithEvents cmdPruebaPagoCFDI As Button
    Friend WithEvents dtFechaCheque As DateTimePicker
    Friend WithEvents lblDisplayFechaCheque As Label
    Friend WithEvents btnVerCFDIS As Button
    Friend WithEvents cmdSeleccionaSPEI As Button
    Friend WithEvents txtSPEI_cadenaCDA As TextBox
    Friend WithEvents txtSPEI_sello As TextBox
    Friend WithEvents txtSPEI_numeroCertificado As TextBox
    Friend WithEvents chkEsBancoExtranjero As CheckBox
    Friend WithEvents btnGenerarCFDIS As Button
    Friend WithEvents tssFechaEmisionCFDI As ToolStripStatusLabel
    Friend WithEvents chkVentasNoFiscales As CheckBox
    Friend WithEvents tsbImprimirComprobante As ToolStripButton
    Friend WithEvents lblEsCuentaFiscal As Label
    Friend WithEvents lblDisplayTiposVentas As Label
    Friend WithEvents cboTipoVentas As ComboBox
    Friend WithEvents cboRegimenFiscal As ComboBox
    Friend WithEvents lblDisplayRegimenFiscal As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTotalUSD As MaskedTextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GridVentas As FlexCell.Grid
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GridCFDIsRelacionados As FlexCell.Grid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoRelacionCFDI As System.Windows.Forms.ComboBox
End Class
