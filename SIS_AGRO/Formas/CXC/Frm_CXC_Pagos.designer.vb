<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXC_Pagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXC_Pagos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton
        Me.tsbImprimirPoliza = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.gbGlobal = New System.Windows.Forms.GroupBox
        Me.btnDepositosSiguiente = New System.Windows.Forms.Button
        Me.btnDepositosAnterior = New System.Windows.Forms.Button
        Me.lblTipoCambio = New System.Windows.Forms.Label
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.gbAgregaDocCliente = New System.Windows.Forms.GroupBox
        Me.CkbAnticipo = New System.Windows.Forms.CheckBox
        Me.CboBancos = New System.Windows.Forms.ComboBox
        Me.CboMedioDePago = New System.Windows.Forms.ComboBox
        Me.lblDisplayAnticipo = New System.Windows.Forms.Label
        Me.txtAnticipo = New System.Windows.Forms.TextBox
        Me.btnAgregarDocumentosClientes = New System.Windows.Forms.Button
        Me.LblDisplayReferencia = New System.Windows.Forms.Label
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.LblDisplayBanco = New System.Windows.Forms.Label
        Me.LblDisplayMedioPago = New System.Windows.Forms.Label
        Me.LblCliente = New System.Windows.Forms.Label
        Me.LblDisplayCliente = New System.Windows.Forms.Label
        Me.TxtCodigoCliente = New System.Windows.Forms.TextBox
        Me.ckbDolares = New System.Windows.Forms.CheckBox
        Me.LblPoliza = New System.Windows.Forms.LinkLabel
        Me.CmbDocumento = New System.Windows.Forms.ComboBox
        Me.LblFecha = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtFecha = New System.Windows.Forms.DateTimePicker
        Me.LblDocumento = New System.Windows.Forms.Label
        Me.TxtConcepto = New System.Windows.Forms.TextBox
        Me.LblDisplayConcepto = New System.Windows.Forms.Label
        Me.LblDisplayFolio = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.LblCuentaContableCuentaBancaria = New System.Windows.Forms.Label
        Me.lblDisplayStatus = New System.Windows.Forms.Label
        Me.LblCuentaBancaria = New System.Windows.Forms.Label
        Me.LblStatus = New System.Windows.Forms.Label
        Me.LblDisplayCuentaBancaria = New System.Windows.Forms.Label
        Me.TxtCuentaBancaria = New System.Windows.Forms.TextBox
        Me.gbVentas = New System.Windows.Forms.GroupBox
        Me.Grid = New FlexCell.Grid
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel
        Me.gbTotales = New System.Windows.Forms.GroupBox
        Me.lstClientesAgregados = New System.Windows.Forms.ListView
        Me.col_CodigoSocio = New System.Windows.Forms.ColumnHeader
        Me.col_NombreSocio = New System.Windows.Forms.ColumnHeader
        Me.col_Total = New System.Windows.Forms.ColumnHeader
        Me.TxtTotal = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tsMenu.SuspendLayout()
        Me.gbGlobal.SuspendLayout()
        Me.gbAgregaDocCliente.SuspendLayout()
        Me.gbVentas.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbTotales.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirPoliza, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1006, 25)
        Me.tsMenu.TabIndex = 1
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
        Me.tsbGrabar.Size = New System.Drawing.Size(97, 22)
        Me.tsbGrabar.Text = "&Grabar Pagos"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 22)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbImprimirPoliza
        '
        Me.tsbImprimirPoliza.Image = CType(resources.GetObject("tsbImprimirPoliza.Image"), System.Drawing.Image)
        Me.tsbImprimirPoliza.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirPoliza.Name = "tsbImprimirPoliza"
        Me.tsbImprimirPoliza.Size = New System.Drawing.Size(107, 22)
        Me.tsbImprimirPoliza.Text = "&Imprimir póliza"
        Me.tsbImprimirPoliza.ToolTipText = "Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.btnDepositosSiguiente)
        Me.gbGlobal.Controls.Add(Me.btnDepositosAnterior)
        Me.gbGlobal.Controls.Add(Me.lblTipoCambio)
        Me.gbGlobal.Controls.Add(Me.txtTipoCambio)
        Me.gbGlobal.Controls.Add(Me.gbAgregaDocCliente)
        Me.gbGlobal.Controls.Add(Me.ckbDolares)
        Me.gbGlobal.Controls.Add(Me.LblPoliza)
        Me.gbGlobal.Controls.Add(Me.CmbDocumento)
        Me.gbGlobal.Controls.Add(Me.LblFecha)
        Me.gbGlobal.Controls.Add(Me.Label8)
        Me.gbGlobal.Controls.Add(Me.dtFecha)
        Me.gbGlobal.Controls.Add(Me.LblDocumento)
        Me.gbGlobal.Controls.Add(Me.TxtConcepto)
        Me.gbGlobal.Controls.Add(Me.LblDisplayConcepto)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFolio)
        Me.gbGlobal.Controls.Add(Me.TxtFolio)
        Me.gbGlobal.Controls.Add(Me.LblCuentaContableCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.lblDisplayStatus)
        Me.gbGlobal.Controls.Add(Me.LblCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.LblStatus)
        Me.gbGlobal.Controls.Add(Me.LblDisplayCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.TxtCuentaBancaria)
        Me.gbGlobal.Location = New System.Drawing.Point(8, 28)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Size = New System.Drawing.Size(988, 165)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Datos"
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
        Me.lblTipoCambio.Location = New System.Drawing.Point(423, 105)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblTipoCambio.TabIndex = 305
        Me.lblTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(515, 101)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(105, 20)
        Me.txtTipoCambio.TabIndex = 304
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbAgregaDocCliente
        '
        Me.gbAgregaDocCliente.Controls.Add(Me.CkbAnticipo)
        Me.gbAgregaDocCliente.Controls.Add(Me.CboBancos)
        Me.gbAgregaDocCliente.Controls.Add(Me.CboMedioDePago)
        Me.gbAgregaDocCliente.Controls.Add(Me.lblDisplayAnticipo)
        Me.gbAgregaDocCliente.Controls.Add(Me.txtAnticipo)
        Me.gbAgregaDocCliente.Controls.Add(Me.btnAgregarDocumentosClientes)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblDisplayReferencia)
        Me.gbAgregaDocCliente.Controls.Add(Me.TxtReferencia)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblDisplayBanco)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblDisplayMedioPago)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.LblDisplayCliente)
        Me.gbAgregaDocCliente.Controls.Add(Me.TxtCodigoCliente)
        Me.gbAgregaDocCliente.Location = New System.Drawing.Point(638, 12)
        Me.gbAgregaDocCliente.Name = "gbAgregaDocCliente"
        Me.gbAgregaDocCliente.Size = New System.Drawing.Size(344, 146)
        Me.gbAgregaDocCliente.TabIndex = 6
        Me.gbAgregaDocCliente.TabStop = False
        Me.gbAgregaDocCliente.Text = "Agregar documentos del cliente"
        '
        'CkbAnticipo
        '
        Me.CkbAnticipo.AutoSize = True
        Me.CkbAnticipo.Location = New System.Drawing.Point(254, 92)
        Me.CkbAnticipo.Name = "CkbAnticipo"
        Me.CkbAnticipo.Size = New System.Drawing.Size(64, 17)
        Me.CkbAnticipo.TabIndex = 4
        Me.CkbAnticipo.Text = "Anticipo"
        Me.CkbAnticipo.UseVisualStyleBackColor = True
        '
        'CboBancos
        '
        Me.CboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBancos.FormattingEnabled = True
        Me.CboBancos.Location = New System.Drawing.Point(89, 65)
        Me.CboBancos.Name = "CboBancos"
        Me.CboBancos.Size = New System.Drawing.Size(211, 21)
        Me.CboBancos.TabIndex = 2
        '
        'CboMedioDePago
        '
        Me.CboMedioDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMedioDePago.FormattingEnabled = True
        Me.CboMedioDePago.Location = New System.Drawing.Point(89, 38)
        Me.CboMedioDePago.Name = "CboMedioDePago"
        Me.CboMedioDePago.Size = New System.Drawing.Size(211, 21)
        Me.CboMedioDePago.TabIndex = 1
        '
        'lblDisplayAnticipo
        '
        Me.lblDisplayAnticipo.AutoSize = True
        Me.lblDisplayAnticipo.Location = New System.Drawing.Point(6, 119)
        Me.lblDisplayAnticipo.Name = "lblDisplayAnticipo"
        Me.lblDisplayAnticipo.Size = New System.Drawing.Size(51, 13)
        Me.lblDisplayAnticipo.TabIndex = 318
        Me.lblDisplayAnticipo.Text = "Anticipo :"
        Me.lblDisplayAnticipo.Visible = False
        '
        'txtAnticipo
        '
        Me.txtAnticipo.Location = New System.Drawing.Point(89, 115)
        Me.txtAnticipo.MaxLength = 6
        Me.txtAnticipo.Name = "txtAnticipo"
        Me.txtAnticipo.Size = New System.Drawing.Size(159, 20)
        Me.txtAnticipo.TabIndex = 5
        Me.txtAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAnticipo.Visible = False
        '
        'btnAgregarDocumentosClientes
        '
        Me.btnAgregarDocumentosClientes.Location = New System.Drawing.Point(254, 114)
        Me.btnAgregarDocumentosClientes.Name = "btnAgregarDocumentosClientes"
        Me.btnAgregarDocumentosClientes.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarDocumentosClientes.TabIndex = 6
        Me.btnAgregarDocumentosClientes.Text = "Agregar"
        Me.btnAgregarDocumentosClientes.UseVisualStyleBackColor = True
        '
        'LblDisplayReferencia
        '
        Me.LblDisplayReferencia.AutoSize = True
        Me.LblDisplayReferencia.Location = New System.Drawing.Point(6, 92)
        Me.LblDisplayReferencia.Name = "LblDisplayReferencia"
        Me.LblDisplayReferencia.Size = New System.Drawing.Size(65, 13)
        Me.LblDisplayReferencia.TabIndex = 316
        Me.LblDisplayReferencia.Text = "Referencia :"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(89, 90)
        Me.TxtReferencia.MaxLength = 160
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(159, 20)
        Me.TxtReferencia.TabIndex = 3
        '
        'LblDisplayBanco
        '
        Me.LblDisplayBanco.AutoSize = True
        Me.LblDisplayBanco.Location = New System.Drawing.Point(6, 67)
        Me.LblDisplayBanco.Name = "LblDisplayBanco"
        Me.LblDisplayBanco.Size = New System.Drawing.Size(44, 13)
        Me.LblDisplayBanco.TabIndex = 314
        Me.LblDisplayBanco.Text = "Banco :"
        '
        'LblDisplayMedioPago
        '
        Me.LblDisplayMedioPago.AutoSize = True
        Me.LblDisplayMedioPago.Location = New System.Drawing.Point(6, 41)
        Me.LblDisplayMedioPago.Name = "LblDisplayMedioPago"
        Me.LblDisplayMedioPago.Size = New System.Drawing.Size(85, 13)
        Me.LblDisplayMedioPago.TabIndex = 312
        Me.LblDisplayMedioPago.Text = "Medio de Pago :"
        '
        'LblCliente
        '
        Me.LblCliente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCliente.Location = New System.Drawing.Point(165, 18)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(164, 13)
        Me.LblCliente.TabIndex = 239
        '
        'LblDisplayCliente
        '
        Me.LblDisplayCliente.AutoSize = True
        Me.LblDisplayCliente.Location = New System.Drawing.Point(5, 18)
        Me.LblDisplayCliente.Name = "LblDisplayCliente"
        Me.LblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.LblDisplayCliente.TabIndex = 238
        Me.LblDisplayCliente.Text = "Cliente :"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(89, 15)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(66, 20)
        Me.TxtCodigoCliente.TabIndex = 0
        '
        'ckbDolares
        '
        Me.ckbDolares.AutoSize = True
        Me.ckbDolares.Location = New System.Drawing.Point(362, 103)
        Me.ckbDolares.Name = "ckbDolares"
        Me.ckbDolares.Size = New System.Drawing.Size(62, 17)
        Me.ckbDolares.TabIndex = 4
        Me.ckbDolares.Text = "Dólares"
        Me.ckbDolares.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblPoliza.Location = New System.Drawing.Point(470, 77)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(149, 13)
        Me.LblPoliza.TabIndex = 291
        '
        'CmbDocumento
        '
        Me.CmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDocumento.FormattingEnabled = True
        Me.CmbDocumento.Location = New System.Drawing.Point(103, 19)
        Me.CmbDocumento.Name = "CmbDocumento"
        Me.CmbDocumento.Size = New System.Drawing.Size(211, 21)
        Me.CmbDocumento.TabIndex = 0
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
        Me.Label8.Location = New System.Drawing.Point(423, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 287
        Me.Label8.Text = "Póliza :"
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(103, 101)
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
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(103, 126)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(516, 20)
        Me.TxtConcepto.TabIndex = 5
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(8, 130)
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
        'LblCuentaContableCuentaBancaria
        '
        Me.LblCuentaContableCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaContableCuentaBancaria.Location = New System.Drawing.Point(423, 49)
        Me.LblCuentaContableCuentaBancaria.Name = "LblCuentaContableCuentaBancaria"
        Me.LblCuentaContableCuentaBancaria.Size = New System.Drawing.Size(196, 13)
        Me.LblCuentaContableCuentaBancaria.TabIndex = 224
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(328, 77)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 217
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblCuentaBancaria
        '
        Me.LblCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaBancaria.Location = New System.Drawing.Point(150, 49)
        Me.LblCuentaBancaria.Name = "LblCuentaBancaria"
        Me.LblCuentaBancaria.Size = New System.Drawing.Size(267, 13)
        Me.LblCuentaBancaria.TabIndex = 223
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(381, 77)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(36, 13)
        Me.LblStatus.TabIndex = 218
        '
        'LblDisplayCuentaBancaria
        '
        Me.LblDisplayCuentaBancaria.AutoSize = True
        Me.LblDisplayCuentaBancaria.Location = New System.Drawing.Point(8, 49)
        Me.LblDisplayCuentaBancaria.Name = "LblDisplayCuentaBancaria"
        Me.LblDisplayCuentaBancaria.Size = New System.Drawing.Size(91, 13)
        Me.LblDisplayCuentaBancaria.TabIndex = 222
        Me.LblDisplayCuentaBancaria.Text = "Cuenta bancaria :"
        '
        'TxtCuentaBancaria
        '
        Me.TxtCuentaBancaria.Location = New System.Drawing.Point(103, 45)
        Me.TxtCuentaBancaria.MaxLength = 6
        Me.TxtCuentaBancaria.Name = "TxtCuentaBancaria"
        Me.TxtCuentaBancaria.Size = New System.Drawing.Size(41, 20)
        Me.TxtCuentaBancaria.TabIndex = 1
        '
        'gbVentas
        '
        Me.gbVentas.Controls.Add(Me.Grid)
        Me.gbVentas.Location = New System.Drawing.Point(8, 199)
        Me.gbVentas.Name = "gbVentas"
        Me.gbVentas.Size = New System.Drawing.Size(988, 212)
        Me.gbVentas.TabIndex = 0
        Me.gbVentas.TabStop = False
        Me.gbVentas.Text = "Ventas"
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
        Me.Grid.Location = New System.Drawing.Point(7, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(975, 181)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 594)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1006, 24)
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
        'gbTotales
        '
        Me.gbTotales.Controls.Add(Me.lstClientesAgregados)
        Me.gbTotales.Controls.Add(Me.TxtTotal)
        Me.gbTotales.Controls.Add(Me.Label1)
        Me.gbTotales.Location = New System.Drawing.Point(618, 417)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Size = New System.Drawing.Size(378, 164)
        Me.gbTotales.TabIndex = 1
        Me.gbTotales.TabStop = False
        Me.gbTotales.Text = "Totales"
        '
        'lstClientesAgregados
        '
        Me.lstClientesAgregados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.col_CodigoSocio, Me.col_NombreSocio, Me.col_Total})
        Me.lstClientesAgregados.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstClientesAgregados.GridLines = True
        Me.lstClientesAgregados.Location = New System.Drawing.Point(3, 16)
        Me.lstClientesAgregados.Name = "lstClientesAgregados"
        Me.lstClientesAgregados.Size = New System.Drawing.Size(372, 108)
        Me.lstClientesAgregados.TabIndex = 211
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
        Me.col_Total.Width = 118
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(235, 130)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(123, 23)
        Me.TxtTotal.TabIndex = 208
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(174, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Total :"
        '
        'Frm_CXC_Pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 618)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbVentas)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.tsMenu)
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
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
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
    Friend WithEvents CmbDocumento As System.Windows.Forms.ComboBox
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
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents gbAgregaDocCliente As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayAnticipo As System.Windows.Forms.Label
    Friend WithEvents txtAnticipo As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregarDocumentosClientes As System.Windows.Forms.Button
    Friend WithEvents LblDisplayReferencia As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayBanco As System.Windows.Forms.Label
    Friend WithEvents LblDisplayMedioPago As System.Windows.Forms.Label
    Friend WithEvents gbTotales As System.Windows.Forms.GroupBox
    Friend WithEvents lstClientesAgregados As System.Windows.Forms.ListView
    Friend WithEvents col_CodigoSocio As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_NombreSocio As System.Windows.Forms.ColumnHeader
    Friend WithEvents col_Total As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboBancos As System.Windows.Forms.ComboBox
    Friend WithEvents CboMedioDePago As System.Windows.Forms.ComboBox
    Friend WithEvents CkbAnticipo As System.Windows.Forms.CheckBox
    Friend WithEvents tsbImprimirPoliza As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents ckbDolares As System.Windows.Forms.CheckBox
    Friend WithEvents btnDepositosSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDepositosAnterior As System.Windows.Forms.Button
End Class
