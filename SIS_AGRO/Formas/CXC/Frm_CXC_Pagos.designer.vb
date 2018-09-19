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
        Me.txtSPEI_cadenaCDA = New System.Windows.Forms.TextBox()
        Me.cmdSeleccionaSPEI = New System.Windows.Forms.Button()
        Me.txtSPEI_sello = New System.Windows.Forms.TextBox()
        Me.chkEsBancoExtranjero = New System.Windows.Forms.CheckBox()
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
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.lblDisplayFormaPago = New System.Windows.Forms.Label()
        Me.chkAnticipo = New System.Windows.Forms.CheckBox()
        Me.btnAgregarDocumentosClientes = New System.Windows.Forms.Button()
        Me.LblDisplayReferencia = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.LblDisplayBanco = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.LblDisplayCliente = New System.Windows.Forms.Label()
        Me.TxtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.gbVentas = New System.Windows.Forms.GroupBox()
        Me.GridVentas = New FlexCell.Grid()
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
        Me.cboTipoVentas = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTiposVentas = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gbGlobal.SuspendLayout()
        Me.gbAgregaDocCliente.SuspendLayout()
        Me.gbVentas.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbDocumentosPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirPoliza, Me.tsbImprimirComprobante, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1152, 27)
        Me.tsMenu.TabIndex = 5
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
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(80, 24)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbImprimirPoliza
        '
        Me.tsbImprimirPoliza.Image = CType(resources.GetObject("tsbImprimirPoliza.Image"), System.Drawing.Image)
        Me.tsbImprimirPoliza.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirPoliza.Name = "tsbImprimirPoliza"
        Me.tsbImprimirPoliza.Size = New System.Drawing.Size(111, 24)
        Me.tsbImprimirPoliza.Text = "&Imprimir póliza"
        Me.tsbImprimirPoliza.ToolTipText = "Imprimir"
        '
        'tsbImprimirComprobante
        '
        Me.tsbImprimirComprobante.Image = CType(resources.GetObject("tsbImprimirComprobante.Image"), System.Drawing.Image)
        Me.tsbImprimirComprobante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirComprobante.Name = "tsbImprimirComprobante"
        Me.tsbImprimirComprobante.Size = New System.Drawing.Size(152, 24)
        Me.tsbImprimirComprobante.Text = "Imprimir comprobante"
        Me.tsbImprimirComprobante.ToolTipText = "Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbGlobal
        '
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
        Me.gbGlobal.Location = New System.Drawing.Point(8, 28)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Size = New System.Drawing.Size(1034, 152)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Datos"
        '
        'lblEsCuentaFiscal
        '
        Me.lblEsCuentaFiscal.AutoSize = True
        Me.lblEsCuentaFiscal.Location = New System.Drawing.Point(100, 129)
        Me.lblEsCuentaFiscal.Name = "lblEsCuentaFiscal"
        Me.lblEsCuentaFiscal.Size = New System.Drawing.Size(11, 13)
        Me.lblEsCuentaFiscal.TabIndex = 383
        Me.lblEsCuentaFiscal.Text = "*"
        '
        'chkVentasNoFiscales
        '
        Me.chkVentasNoFiscales.AutoSize = True
        Me.chkVentasNoFiscales.Location = New System.Drawing.Point(120, 129)
        Me.chkVentasNoFiscales.Name = "chkVentasNoFiscales"
        Me.chkVentasNoFiscales.Size = New System.Drawing.Size(118, 17)
        Me.chkVentasNoFiscales.TabIndex = 382
        Me.chkVentasNoFiscales.Text = "Pago de remisiones"
        Me.chkVentasNoFiscales.UseVisualStyleBackColor = True
        Me.chkVentasNoFiscales.Visible = False
        '
        'cmdPruebaPagoCFDI
        '
        Me.cmdPruebaPagoCFDI.Location = New System.Drawing.Point(507, 67)
        Me.cmdPruebaPagoCFDI.Name = "cmdPruebaPagoCFDI"
        Me.cmdPruebaPagoCFDI.Size = New System.Drawing.Size(106, 30)
        Me.cmdPruebaPagoCFDI.TabIndex = 378
        Me.cmdPruebaPagoCFDI.Text = "Prueba CFDI-Pago"
        Me.cmdPruebaPagoCFDI.UseVisualStyleBackColor = True
        Me.cmdPruebaPagoCFDI.Visible = False
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(859, 105)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(123, 23)
        Me.TxtTotal.TabIndex = 376
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(798, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 377
        Me.Label1.Text = "Total :"
        '
        'lstClientesAgregados
        '
        Me.lstClientesAgregados.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lstClientesAgregados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_CodigoSocio, Me.col_NombreSocio, Me.col_Total})
        Me.lstClientesAgregados.GridLines = True
        Me.lstClientesAgregados.Location = New System.Drawing.Point(634, 21)
        Me.lstClientesAgregados.Name = "lstClientesAgregados"
        Me.lstClientesAgregados.Size = New System.Drawing.Size(371, 78)
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
        Me.TxtConcepto.Location = New System.Drawing.Point(378, 102)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(334, 20)
        Me.TxtConcepto.TabIndex = 5
        '
        'btnDepositosSiguiente
        '
        Me.btnDepositosSiguiente.Location = New System.Drawing.Point(282, 70)
        Me.btnDepositosSiguiente.Name = "btnDepositosSiguiente"
        Me.btnDepositosSiguiente.Size = New System.Drawing.Size(32, 26)
        Me.btnDepositosSiguiente.TabIndex = 374
        Me.btnDepositosSiguiente.Text = ">>"
        Me.btnDepositosSiguiente.UseVisualStyleBackColor = True
        '
        'btnDepositosAnterior
        '
        Me.btnDepositosAnterior.Location = New System.Drawing.Point(244, 70)
        Me.btnDepositosAnterior.Name = "btnDepositosAnterior"
        Me.btnDepositosAnterior.Size = New System.Drawing.Size(32, 26)
        Me.btnDepositosAnterior.TabIndex = 373
        Me.btnDepositosAnterior.Text = "<<"
        Me.btnDepositosAnterior.UseVisualStyleBackColor = True
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Enabled = False
        Me.lblTipoCambio.Location = New System.Drawing.Point(320, 77)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblTipoCambio.TabIndex = 305
        Me.lblTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(410, 77)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(78, 20)
        Me.txtTipoCambio.TabIndex = 304
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblPoliza
        '
        Me.LblPoliza.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblPoliza.Location = New System.Drawing.Point(494, 21)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(105, 13)
        Me.LblPoliza.TabIndex = 291
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(103, 19)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(211, 21)
        Me.CboDocumento.TabIndex = 0
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(8, 105)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 175
        Me.LblFecha.Text = "Fecha :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(446, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 287
        Me.Label8.Text = "Póliza :"
        '
        'LblCuentaContableCuentaBancaria
        '
        Me.LblCuentaContableCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaContableCuentaBancaria.Location = New System.Drawing.Point(423, 48)
        Me.LblCuentaContableCuentaBancaria.Name = "LblCuentaContableCuentaBancaria"
        Me.LblCuentaContableCuentaBancaria.Size = New System.Drawing.Size(176, 13)
        Me.LblCuentaContableCuentaBancaria.TabIndex = 224
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(103, 102)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(211, 20)
        Me.dtFecha.TabIndex = 3
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(8, 23)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 177
        Me.LblDocumento.Text = "Documento :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(320, 105)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayConcepto.TabIndex = 185
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(8, 77)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 216
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(103, 70)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(135, 26)
        Me.TxtFolio.TabIndex = 2
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(320, 22)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 217
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblCuentaBancaria
        '
        Me.LblCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaBancaria.Location = New System.Drawing.Point(150, 48)
        Me.LblCuentaBancaria.Name = "LblCuentaBancaria"
        Me.LblCuentaBancaria.Size = New System.Drawing.Size(267, 13)
        Me.LblCuentaBancaria.TabIndex = 223
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(373, 22)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(68, 13)
        Me.LblStatus.TabIndex = 218
        '
        'LblDisplayCuentaBancaria
        '
        Me.LblDisplayCuentaBancaria.AutoSize = True
        Me.LblDisplayCuentaBancaria.Location = New System.Drawing.Point(8, 48)
        Me.LblDisplayCuentaBancaria.Name = "LblDisplayCuentaBancaria"
        Me.LblDisplayCuentaBancaria.Size = New System.Drawing.Size(91, 13)
        Me.LblDisplayCuentaBancaria.TabIndex = 222
        Me.LblDisplayCuentaBancaria.Text = "Cuenta bancaria :"
        '
        'TxtCuentaBancaria
        '
        Me.TxtCuentaBancaria.Location = New System.Drawing.Point(103, 44)
        Me.TxtCuentaBancaria.MaxLength = 6
        Me.TxtCuentaBancaria.Name = "TxtCuentaBancaria"
        Me.TxtCuentaBancaria.Size = New System.Drawing.Size(41, 20)
        Me.TxtCuentaBancaria.TabIndex = 1
        '
        'CboMedioDePago
        '
        Me.CboMedioDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMedioDePago.FormattingEnabled = True
        Me.CboMedioDePago.Location = New System.Drawing.Point(853, 376)
        Me.CboMedioDePago.Name = "CboMedioDePago"
        Me.CboMedioDePago.Size = New System.Drawing.Size(211, 21)
        Me.CboMedioDePago.TabIndex = 1
        Me.CboMedioDePago.Visible = False
        '
        'LblDisplayMedioPago
        '
        Me.LblDisplayMedioPago.AutoSize = True
        Me.LblDisplayMedioPago.Location = New System.Drawing.Point(957, 360)
        Me.LblDisplayMedioPago.Name = "LblDisplayMedioPago"
        Me.LblDisplayMedioPago.Size = New System.Drawing.Size(85, 13)
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
        Me.gbAgregaDocCliente.Controls.Add(Me.cboMoneda)
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
        Me.gbAgregaDocCliente.Location = New System.Drawing.Point(8, 188)
        Me.gbAgregaDocCliente.Name = "gbAgregaDocCliente"
        Me.gbAgregaDocCliente.Size = New System.Drawing.Size(1034, 140)
        Me.gbAgregaDocCliente.TabIndex = 1
        Me.gbAgregaDocCliente.TabStop = False
        Me.gbAgregaDocCliente.Text = "Documentos de pago :"
        '
        'txtSPEI_cadenaCDA
        '
        Me.txtSPEI_cadenaCDA.Location = New System.Drawing.Point(691, 119)
        Me.txtSPEI_cadenaCDA.MaxLength = 0
        Me.txtSPEI_cadenaCDA.Name = "txtSPEI_cadenaCDA"
        Me.txtSPEI_cadenaCDA.Size = New System.Drawing.Size(103, 20)
        Me.txtSPEI_cadenaCDA.TabIndex = 386
        Me.txtSPEI_cadenaCDA.Visible = False
        '
        'cmdSeleccionaSPEI
        '
        Me.cmdSeleccionaSPEI.Location = New System.Drawing.Point(733, 117)
        Me.cmdSeleccionaSPEI.Name = "cmdSeleccionaSPEI"
        Me.cmdSeleccionaSPEI.Size = New System.Drawing.Size(106, 24)
        Me.cmdSeleccionaSPEI.TabIndex = 387
        Me.cmdSeleccionaSPEI.Text = "Selecciona SPEI"
        Me.cmdSeleccionaSPEI.UseVisualStyleBackColor = True
        Me.cmdSeleccionaSPEI.Visible = False
        '
        'txtSPEI_sello
        '
        Me.txtSPEI_sello.Location = New System.Drawing.Point(584, 119)
        Me.txtSPEI_sello.MaxLength = 0
        Me.txtSPEI_sello.Name = "txtSPEI_sello"
        Me.txtSPEI_sello.Size = New System.Drawing.Size(103, 20)
        Me.txtSPEI_sello.TabIndex = 385
        Me.txtSPEI_sello.Visible = False
        '
        'chkEsBancoExtranjero
        '
        Me.chkEsBancoExtranjero.Enabled = False
        Me.chkEsBancoExtranjero.Location = New System.Drawing.Point(40, 118)
        Me.chkEsBancoExtranjero.Name = "chkEsBancoExtranjero"
        Me.chkEsBancoExtranjero.Size = New System.Drawing.Size(137, 21)
        Me.chkEsBancoExtranjero.TabIndex = 385
        Me.chkEsBancoExtranjero.Text = "Es banco extranjero ?"
        Me.chkEsBancoExtranjero.UseVisualStyleBackColor = True
        '
        'txtSPEI_numeroCertificado
        '
        Me.txtSPEI_numeroCertificado.Location = New System.Drawing.Point(475, 120)
        Me.txtSPEI_numeroCertificado.MaxLength = 0
        Me.txtSPEI_numeroCertificado.Name = "txtSPEI_numeroCertificado"
        Me.txtSPEI_numeroCertificado.Size = New System.Drawing.Size(103, 20)
        Me.txtSPEI_numeroCertificado.TabIndex = 384
        Me.txtSPEI_numeroCertificado.Visible = False
        '
        'dtFechaCheque
        '
        Me.dtFechaCheque.Location = New System.Drawing.Point(788, 65)
        Me.dtFechaCheque.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaCheque.Name = "dtFechaCheque"
        Me.dtFechaCheque.Size = New System.Drawing.Size(211, 20)
        Me.dtFechaCheque.TabIndex = 345
        '
        'lblDisplayFechaCheque
        '
        Me.lblDisplayFechaCheque.AutoSize = True
        Me.lblDisplayFechaCheque.Location = New System.Drawing.Point(692, 69)
        Me.lblDisplayFechaCheque.Name = "lblDisplayFechaCheque"
        Me.lblDisplayFechaCheque.Size = New System.Drawing.Size(99, 13)
        Me.lblDisplayFechaCheque.TabIndex = 346
        Me.lblDisplayFechaCheque.Text = "Fecha del cheque :"
        '
        'dtFechaPagoCliente
        '
        Me.dtFechaPagoCliente.Location = New System.Drawing.Point(788, 38)
        Me.dtFechaPagoCliente.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaPagoCliente.Name = "dtFechaPagoCliente"
        Me.dtFechaPagoCliente.Size = New System.Drawing.Size(211, 20)
        Me.dtFechaPagoCliente.TabIndex = 10
        '
        'CboBancos
        '
        Me.CboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBancos.Enabled = False
        Me.CboBancos.FormattingEnabled = True
        Me.CboBancos.Location = New System.Drawing.Point(475, 76)
        Me.CboBancos.Name = "CboBancos"
        Me.CboBancos.Size = New System.Drawing.Size(211, 21)
        Me.CboBancos.TabIndex = 8
        '
        'txtCuentaEmisor
        '
        Me.txtCuentaEmisor.Enabled = False
        Me.txtCuentaEmisor.Location = New System.Drawing.Point(569, 38)
        Me.txtCuentaEmisor.MaxLength = 50
        Me.txtCuentaEmisor.Name = "txtCuentaEmisor"
        Me.txtCuentaEmisor.Size = New System.Drawing.Size(124, 20)
        Me.txtCuentaEmisor.TabIndex = 7
        '
        'txtFolioDetalle
        '
        Me.txtFolioDetalle.Location = New System.Drawing.Point(636, 15)
        Me.txtFolioDetalle.MaxLength = 100
        Me.txtFolioDetalle.Name = "txtFolioDetalle"
        Me.txtFolioDetalle.Size = New System.Drawing.Size(103, 20)
        Me.txtFolioDetalle.TabIndex = 6
        '
        'btnEditarCuentaBancariaCliente
        '
        Me.btnEditarCuentaBancariaCliente.Location = New System.Drawing.Point(420, 60)
        Me.btnEditarCuentaBancariaCliente.Name = "btnEditarCuentaBancariaCliente"
        Me.btnEditarCuentaBancariaCliente.Size = New System.Drawing.Size(53, 37)
        Me.btnEditarCuentaBancariaCliente.TabIndex = 344
        Me.btnEditarCuentaBancariaCliente.Text = "Editar cuenta"
        Me.btnEditarCuentaBancariaCliente.UseVisualStyleBackColor = True
        '
        'btnAgregarCuentaBancariaCliente
        '
        Me.btnAgregarCuentaBancariaCliente.Location = New System.Drawing.Point(364, 60)
        Me.btnAgregarCuentaBancariaCliente.Name = "btnAgregarCuentaBancariaCliente"
        Me.btnAgregarCuentaBancariaCliente.Size = New System.Drawing.Size(53, 37)
        Me.btnAgregarCuentaBancariaCliente.TabIndex = 343
        Me.btnAgregarCuentaBancariaCliente.Text = "Agregar cuenta"
        Me.btnAgregarCuentaBancariaCliente.UseVisualStyleBackColor = True
        '
        'lblDisplayCuenta
        '
        Me.lblDisplayCuenta.AutoSize = True
        Me.lblDisplayCuenta.Location = New System.Drawing.Point(6, 42)
        Me.lblDisplayCuenta.Name = "lblDisplayCuenta"
        Me.lblDisplayCuenta.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayCuenta.TabIndex = 342
        Me.lblDisplayCuenta.Text = "Cuenta emisor :"
        '
        'lblRFCEmisor
        '
        Me.lblRFCEmisor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblRFCEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCEmisor.Location = New System.Drawing.Point(578, 103)
        Me.lblRFCEmisor.Name = "lblRFCEmisor"
        Me.lblRFCEmisor.Size = New System.Drawing.Size(178, 13)
        Me.lblRFCEmisor.TabIndex = 340
        '
        'lblDisplayRFCEmisor
        '
        Me.lblDisplayRFCEmisor.AutoSize = True
        Me.lblDisplayRFCEmisor.Location = New System.Drawing.Point(402, 102)
        Me.lblDisplayRFCEmisor.Name = "lblDisplayRFCEmisor"
        Me.lblDisplayRFCEmisor.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayRFCEmisor.TabIndex = 339
        Me.lblDisplayRFCEmisor.Text = "RFC emisor :"
        '
        'cboCuentaEmisor
        '
        Me.cboCuentaEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuentaEmisor.FormattingEnabled = True
        Me.cboCuentaEmisor.Location = New System.Drawing.Point(99, 38)
        Me.cboCuentaEmisor.Name = "cboCuentaEmisor"
        Me.cboCuentaEmisor.Size = New System.Drawing.Size(374, 21)
        Me.cboCuentaEmisor.TabIndex = 1
        '
        'txtRFCEmisor
        '
        Me.txtRFCEmisor.Location = New System.Drawing.Point(475, 99)
        Me.txtRFCEmisor.MaxLength = 13
        Me.txtRFCEmisor.Name = "txtRFCEmisor"
        Me.txtRFCEmisor.Size = New System.Drawing.Size(97, 20)
        Me.txtRFCEmisor.TabIndex = 9
        '
        'btnLimpiarDocumentoPagos
        '
        Me.btnLimpiarDocumentoPagos.Location = New System.Drawing.Point(924, 102)
        Me.btnLimpiarDocumentoPagos.Name = "btnLimpiarDocumentoPagos"
        Me.btnLimpiarDocumentoPagos.Size = New System.Drawing.Size(75, 30)
        Me.btnLimpiarDocumentoPagos.TabIndex = 13
        Me.btnLimpiarDocumentoPagos.Text = "Limpiar"
        Me.btnLimpiarDocumentoPagos.UseVisualStyleBackColor = True
        '
        'lblDisplayMonto
        '
        Me.lblDisplayMonto.AutoSize = True
        Me.lblDisplayMonto.Location = New System.Drawing.Point(6, 96)
        Me.lblDisplayMonto.Name = "lblDisplayMonto"
        Me.lblDisplayMonto.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayMonto.TabIndex = 336
        Me.lblDisplayMonto.Text = "Monto :"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(99, 93)
        Me.txtMonto.MaxLength = 20
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(108, 20)
        Me.txtMonto.TabIndex = 3
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(692, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 30)
        Me.Label5.TabIndex = 330
        Me.Label5.Text = "Fecha en que pagó el cliente :"
        '
        'lblDisplayCuentaEmisor
        '
        Me.lblDisplayCuentaEmisor.AutoSize = True
        Me.lblDisplayCuentaEmisor.Location = New System.Drawing.Point(479, 40)
        Me.lblDisplayCuentaEmisor.Name = "lblDisplayCuentaEmisor"
        Me.lblDisplayCuentaEmisor.Size = New System.Drawing.Size(90, 13)
        Me.lblDisplayCuentaEmisor.TabIndex = 329
        Me.lblDisplayCuentaEmisor.Text = "# Cuenta emisor :"
        '
        'lblDisplayFolioDetalle
        '
        Me.lblDisplayFolioDetalle.AutoSize = True
        Me.lblDisplayFolioDetalle.Location = New System.Drawing.Point(415, 17)
        Me.lblDisplayFolioDetalle.Name = "lblDisplayFolioDetalle"
        Me.lblDisplayFolioDetalle.Size = New System.Drawing.Size(223, 13)
        Me.lblDisplayFolioDetalle.TabIndex = 328
        Me.lblDisplayFolioDetalle.Text = "Número de operación(Folio chq/transf/ficha) :"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(99, 66)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(229, 21)
        Me.cboFormaPago.TabIndex = 2
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(213, 93)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(73, 21)
        Me.cboMoneda.TabIndex = 4
        '
        'lblDisplayFormaPago
        '
        Me.lblDisplayFormaPago.AutoSize = True
        Me.lblDisplayFormaPago.Location = New System.Drawing.Point(6, 69)
        Me.lblDisplayFormaPago.Name = "lblDisplayFormaPago"
        Me.lblDisplayFormaPago.Size = New System.Drawing.Size(84, 13)
        Me.lblDisplayFormaPago.TabIndex = 327
        Me.lblDisplayFormaPago.Text = "Forma de pago :"
        '
        'chkAnticipo
        '
        Me.chkAnticipo.AutoSize = True
        Me.chkAnticipo.Location = New System.Drawing.Point(292, 96)
        Me.chkAnticipo.Name = "chkAnticipo"
        Me.chkAnticipo.Size = New System.Drawing.Size(64, 17)
        Me.chkAnticipo.TabIndex = 5
        Me.chkAnticipo.Text = "Anticipo"
        Me.chkAnticipo.UseVisualStyleBackColor = True
        Me.chkAnticipo.Visible = False
        '
        'btnAgregarDocumentosClientes
        '
        Me.btnAgregarDocumentosClientes.Location = New System.Drawing.Point(845, 102)
        Me.btnAgregarDocumentosClientes.Name = "btnAgregarDocumentosClientes"
        Me.btnAgregarDocumentosClientes.Size = New System.Drawing.Size(75, 30)
        Me.btnAgregarDocumentosClientes.TabIndex = 12
        Me.btnAgregarDocumentosClientes.Text = "Agregar"
        Me.btnAgregarDocumentosClientes.UseVisualStyleBackColor = True
        '
        'LblDisplayReferencia
        '
        Me.LblDisplayReferencia.AutoSize = True
        Me.LblDisplayReferencia.Location = New System.Drawing.Point(745, 17)
        Me.LblDisplayReferencia.Name = "LblDisplayReferencia"
        Me.LblDisplayReferencia.Size = New System.Drawing.Size(65, 13)
        Me.LblDisplayReferencia.TabIndex = 316
        Me.LblDisplayReferencia.Text = "Referencia :"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(816, 15)
        Me.TxtReferencia.MaxLength = 160
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(183, 20)
        Me.TxtReferencia.TabIndex = 11
        '
        'LblDisplayBanco
        '
        Me.LblDisplayBanco.AutoSize = True
        Me.LblDisplayBanco.Location = New System.Drawing.Point(479, 60)
        Me.LblDisplayBanco.Name = "LblDisplayBanco"
        Me.LblDisplayBanco.Size = New System.Drawing.Size(120, 13)
        Me.LblDisplayBanco.TabIndex = 314
        Me.LblDisplayBanco.Text = "Banco emisor nacional :"
        '
        'LblCliente
        '
        Me.LblCliente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCliente.Location = New System.Drawing.Point(171, 18)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(233, 13)
        Me.LblCliente.TabIndex = 239
        '
        'LblDisplayCliente
        '
        Me.LblDisplayCliente.AutoSize = True
        Me.LblDisplayCliente.Location = New System.Drawing.Point(6, 18)
        Me.LblDisplayCliente.Name = "LblDisplayCliente"
        Me.LblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.LblDisplayCliente.TabIndex = 238
        Me.LblDisplayCliente.Text = "Cliente :"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(99, 15)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(66, 20)
        Me.TxtCodigoCliente.TabIndex = 0
        '
        'gbVentas
        '
        Me.gbVentas.Controls.Add(Me.GridVentas)
        Me.gbVentas.Location = New System.Drawing.Point(8, 430)
        Me.gbVentas.Name = "gbVentas"
        Me.gbVentas.Size = New System.Drawing.Size(1138, 182)
        Me.gbVentas.TabIndex = 2
        Me.gbVentas.TabStop = False
        Me.gbVentas.Text = "Ventas"
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
        Me.GridVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridVentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridVentas.Location = New System.Drawing.Point(7, 19)
        Me.GridVentas.LockButton = True
        Me.GridVentas.Name = "GridVentas"
        Me.GridVentas.Rows = 7
        Me.GridVentas.Size = New System.Drawing.Size(1124, 157)
        Me.GridVentas.TabIndex = 0
        Me.GridVentas.UncheckedImage = CType(resources.GetObject("GridVentas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo, Me.tssFechaEmisionCFDI})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 615)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1152, 24)
        Me.StatusStripEstado.TabIndex = 240
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssEstado
        '
        Me.tssEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssEstado.Name = "tssEstado"
        Me.tssEstado.Size = New System.Drawing.Size(52, 19)
        Me.tssEstado.Text = "Estado :"
        '
        'tssElaboro
        '
        Me.tssElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssElaboro.Name = "tssElaboro"
        Me.tssElaboro.Size = New System.Drawing.Size(60, 19)
        Me.tssElaboro.Text = "Elaboró : "
        '
        'tssCancelo
        '
        Me.tssCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssCancelo.Name = "tssCancelo"
        Me.tssCancelo.Size = New System.Drawing.Size(60, 19)
        Me.tssCancelo.Text = "Canceló :"
        '
        'tssFechaEmisionCFDI
        '
        Me.tssFechaEmisionCFDI.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssFechaEmisionCFDI.Name = "tssFechaEmisionCFDI"
        Me.tssFechaEmisionCFDI.Size = New System.Drawing.Size(121, 19)
        Me.tssFechaEmisionCFDI.Text = "Fecha emisión CFDI :"
        '
        'gbDocumentosPago
        '
        Me.gbDocumentosPago.Controls.Add(Me.btnEliminarDocumentoPago)
        Me.gbDocumentosPago.Controls.Add(Me.GridDocumentosPago)
        Me.gbDocumentosPago.Location = New System.Drawing.Point(8, 334)
        Me.gbDocumentosPago.Name = "gbDocumentosPago"
        Me.gbDocumentosPago.Size = New System.Drawing.Size(1034, 90)
        Me.gbDocumentosPago.TabIndex = 1
        Me.gbDocumentosPago.TabStop = False
        Me.gbDocumentosPago.Text = "Documentos de pago :"
        '
        'btnEliminarDocumentoPago
        '
        Me.btnEliminarDocumentoPago.Location = New System.Drawing.Point(902, 0)
        Me.btnEliminarDocumentoPago.Name = "btnEliminarDocumentoPago"
        Me.btnEliminarDocumentoPago.Size = New System.Drawing.Size(75, 19)
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
        Me.GridDocumentosPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDocumentosPago.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridDocumentosPago.Location = New System.Drawing.Point(7, 19)
        Me.GridDocumentosPago.LockButton = True
        Me.GridDocumentosPago.Name = "GridDocumentosPago"
        Me.GridDocumentosPago.Rows = 3
        Me.GridDocumentosPago.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridDocumentosPago.Size = New System.Drawing.Size(1021, 61)
        Me.GridDocumentosPago.TabIndex = 0
        Me.GridDocumentosPago.UncheckedImage = CType(resources.GetObject("GridDocumentosPago.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnVerCFDIS
        '
        Me.btnVerCFDIS.Location = New System.Drawing.Point(1046, 199)
        Me.btnVerCFDIS.Name = "btnVerCFDIS"
        Me.btnVerCFDIS.Size = New System.Drawing.Size(106, 67)
        Me.btnVerCFDIS.TabIndex = 379
        Me.btnVerCFDIS.Text = "Ver CFDI's"
        Me.btnVerCFDIS.UseVisualStyleBackColor = True
        '
        'btnGenerarCFDIS
        '
        Me.btnGenerarCFDIS.Location = New System.Drawing.Point(1046, 123)
        Me.btnGenerarCFDIS.Name = "btnGenerarCFDIS"
        Me.btnGenerarCFDIS.Size = New System.Drawing.Size(106, 67)
        Me.btnGenerarCFDIS.TabIndex = 381
        Me.btnGenerarCFDIS.Text = "Generar CFDI's"
        Me.btnGenerarCFDIS.UseVisualStyleBackColor = True
        '
        'cboTipoVentas
        '
        Me.cboTipoVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVentas.Enabled = False
        Me.cboTipoVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoVentas.FormattingEnabled = True
        Me.cboTipoVentas.Items.AddRange(New Object() {"MISMO RFC CLIENTE", "MISMO CODIGO CLIENTE"})
        Me.cboTipoVentas.Location = New System.Drawing.Point(292, 117)
        Me.cboTipoVentas.Name = "cboTipoVentas"
        Me.cboTipoVentas.Size = New System.Drawing.Size(177, 21)
        Me.cboTipoVentas.TabIndex = 388
        '
        'lblDisplayTiposVentas
        '
        Me.lblDisplayTiposVentas.AutoSize = True
        Me.lblDisplayTiposVentas.Location = New System.Drawing.Point(213, 121)
        Me.lblDisplayTiposVentas.Name = "lblDisplayTiposVentas"
        Me.lblDisplayTiposVentas.Size = New System.Drawing.Size(63, 13)
        Me.lblDisplayTiposVentas.TabIndex = 389
        Me.lblDisplayTiposVentas.Text = "Ventas del :"
        '
        'Frm_CXC_Pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 639)
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
        Me.MaximizeBox = False
        Me.Name = "Frm_CXC_Pagos"
        Me.Text = "Elaboración de pagos de clientes"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbGlobal.ResumeLayout(False)
        Me.gbGlobal.PerformLayout()
        Me.gbAgregaDocCliente.ResumeLayout(False)
        Me.gbAgregaDocCliente.PerformLayout()
        Me.gbVentas.ResumeLayout(False)
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbDocumentosPago.ResumeLayout(False)
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
    Friend WithEvents GridVentas As FlexCell.Grid
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
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
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
End Class
