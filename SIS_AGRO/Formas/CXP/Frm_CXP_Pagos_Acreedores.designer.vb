<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXP_Pagos_Acreedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXP_Pagos_Acreedores))
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.cboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbIvaAcreditable = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.LblDisplayConcepto = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.LblDisplayTotales = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.lblCuentaBancaria = New System.Windows.Forms.Label()
        Me.lblDisplayCuentaBancaria = New System.Windows.Forms.Label()
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.LblProveedor = New System.Windows.Forms.Label()
        Me.LblDisplayProveedor = New System.Windows.Forms.Label()
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.LblDisplayImporte = New System.Windows.Forms.Label()
        Me.TxtImporte = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbGlobal = New System.Windows.Forms.GroupBox()
        Me.lblCuentaContableOrigenRecursos = New System.Windows.Forms.Label()
        Me.lblDisplayCuentaContableOrigenRecursos = New System.Windows.Forms.Label()
        Me.ckbAbonoCuentaBeneficiario = New System.Windows.Forms.CheckBox()
        Me.txtCuentaContableOrigenRecursos = New System.Windows.Forms.TextBox()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.lblNombreMonedaDestino = New System.Windows.Forms.Label()
        Me.lblNombreMonedaOrigen = New System.Windows.Forms.Label()
        Me.lblDisplayTipoPago = New System.Windows.Forms.Label()
        Me.cboTipoPago = New System.Windows.Forms.ComboBox()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.lblDissplayRetencion = New System.Windows.Forms.Label()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.txtRetencion = New System.Windows.Forms.TextBox()
        Me.gbPagosAutorizados = New System.Windows.Forms.GroupBox()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAutorizaciones = New System.Windows.Forms.Button()
        Me.CkbPagoFleteEmbarques = New System.Windows.Forms.CheckBox()
        Me.CboFacturasRecibidas = New System.Windows.Forms.ComboBox()
        Me.lblFacturasRecibidas = New System.Windows.Forms.Label()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.txtImporteDolares = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblTotalDolares = New System.Windows.Forms.Label()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbCompras = New System.Windows.Forms.GroupBox()
        Me.Grid1 = New FlexCell.Grid()
        Me.gbFleteEmbarques = New System.Windows.Forms.GroupBox()
        Me.Grid2 = New FlexCell.Grid()
        Me.tsMenu.SuspendLayout()
        Me.gbGlobal.SuspendLayout()
        Me.gbPagosAutorizados.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbCompras.SuspendLayout()
        Me.gbFleteEmbarques.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(103, 103)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(211, 20)
        Me.dtFecha.TabIndex = 3
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(6, 106)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 175
        Me.LblFecha.Text = "Fecha :"
        '
        'cboDocumento
        '
        Me.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumento.FormattingEnabled = True
        Me.cboDocumento.Location = New System.Drawing.Point(103, 19)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(211, 21)
        Me.cboDocumento.TabIndex = 0
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(5, 22)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 177
        Me.LblDocumento.Text = "Documento :"
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbIvaAcreditable, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1089, 27)
        Me.tsMenu.TabIndex = 1
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(77, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbIvaAcreditable
        '
        Me.tsbIvaAcreditable.Image = CType(resources.GetObject("tsbIvaAcreditable.Image"), System.Drawing.Image)
        Me.tsbIvaAcreditable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbIvaAcreditable.Name = "tsbIvaAcreditable"
        Me.tsbIvaAcreditable.Size = New System.Drawing.Size(107, 24)
        Me.tsbIvaAcreditable.Text = "Iva acreditable"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(307, 195)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayConcepto.TabIndex = 185
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(372, 191)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(468, 20)
        Me.TxtConcepto.TabIndex = 8
        '
        'LblDisplayTotales
        '
        Me.LblDisplayTotales.AutoSize = True
        Me.LblDisplayTotales.Location = New System.Drawing.Point(601, 639)
        Me.LblDisplayTotales.Name = "LblDisplayTotales"
        Me.LblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.LblDisplayTotales.TabIndex = 209
        Me.LblDisplayTotales.Text = "Totales :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(103, 72)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(135, 26)
        Me.TxtFolio.TabIndex = 2
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(5, 74)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 216
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblStatus.Location = New System.Drawing.Point(368, 75)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(76, 13)
        Me.LblStatus.TabIndex = 218
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(314, 75)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 217
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCuentaBancaria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(150, 49)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(238, 13)
        Me.lblCuentaBancaria.TabIndex = 223
        '
        'lblDisplayCuentaBancaria
        '
        Me.lblDisplayCuentaBancaria.AutoSize = True
        Me.lblDisplayCuentaBancaria.Location = New System.Drawing.Point(5, 48)
        Me.lblDisplayCuentaBancaria.Name = "lblDisplayCuentaBancaria"
        Me.lblDisplayCuentaBancaria.Size = New System.Drawing.Size(91, 13)
        Me.lblDisplayCuentaBancaria.TabIndex = 222
        Me.lblDisplayCuentaBancaria.Text = "Cuenta bancaria :"
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(103, 45)
        Me.txtCuentaBancaria.MaxLength = 6
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(41, 20)
        Me.txtCuentaBancaria.TabIndex = 1
        '
        'LblProveedor
        '
        Me.LblProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblProveedor.Location = New System.Drawing.Point(192, 137)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(196, 13)
        Me.LblProveedor.TabIndex = 236
        '
        'LblDisplayProveedor
        '
        Me.LblDisplayProveedor.AutoSize = True
        Me.LblDisplayProveedor.Location = New System.Drawing.Point(5, 136)
        Me.LblDisplayProveedor.Name = "LblDisplayProveedor"
        Me.LblDisplayProveedor.Size = New System.Drawing.Size(56, 13)
        Me.LblDisplayProveedor.TabIndex = 235
        Me.LblDisplayProveedor.Text = "Acreedor :"
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(103, 134)
        Me.TxtCodigoProveedor.MaxLength = 8
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(83, 20)
        Me.TxtCodigoProveedor.TabIndex = 4
        '
        'LblDisplayImporte
        '
        Me.LblDisplayImporte.AutoSize = True
        Me.LblDisplayImporte.Location = New System.Drawing.Point(5, 162)
        Me.LblDisplayImporte.Name = "LblDisplayImporte"
        Me.LblDisplayImporte.Size = New System.Drawing.Size(48, 13)
        Me.LblDisplayImporte.TabIndex = 239
        Me.LblDisplayImporte.Text = "Importe :"
        '
        'TxtImporte
        '
        Me.TxtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporte.Location = New System.Drawing.Point(103, 158)
        Me.TxtImporte.MaxLength = 0
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(135, 26)
        Me.TxtImporte.TabIndex = 5
        Me.TxtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(452, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 287
        Me.Label8.Text = "Póliza :"
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.txtCuentaContableOrigenRecursos)
        Me.gbGlobal.Controls.Add(Me.lblCuentaContableOrigenRecursos)
        Me.gbGlobal.Controls.Add(Me.lblDisplayCuentaContableOrigenRecursos)
        Me.gbGlobal.Controls.Add(Me.ckbAbonoCuentaBeneficiario)
        Me.gbGlobal.Controls.Add(Me.lblMoneda)
        Me.gbGlobal.Controls.Add(Me.cboMoneda)
        Me.gbGlobal.Controls.Add(Me.TxtImporte)
        Me.gbGlobal.Controls.Add(Me.lblNombreMonedaDestino)
        Me.gbGlobal.Controls.Add(Me.lblNombreMonedaOrigen)
        Me.gbGlobal.Controls.Add(Me.lblDisplayTipoPago)
        Me.gbGlobal.Controls.Add(Me.cboTipoPago)
        Me.gbGlobal.Controls.Add(Me.btnDocumentoSiguiente)
        Me.gbGlobal.Controls.Add(Me.lblDissplayRetencion)
        Me.gbGlobal.Controls.Add(Me.btnDocumentoAnterior)
        Me.gbGlobal.Controls.Add(Me.txtRetencion)
        Me.gbGlobal.Controls.Add(Me.gbPagosAutorizados)
        Me.gbGlobal.Controls.Add(Me.CkbPagoFleteEmbarques)
        Me.gbGlobal.Controls.Add(Me.CboFacturasRecibidas)
        Me.gbGlobal.Controls.Add(Me.lblFacturasRecibidas)
        Me.gbGlobal.Controls.Add(Me.lblTipoCambio)
        Me.gbGlobal.Controls.Add(Me.txtImporteDolares)
        Me.gbGlobal.Controls.Add(Me.txtTipoCambio)
        Me.gbGlobal.Controls.Add(Me.lblTotalDolares)
        Me.gbGlobal.Controls.Add(Me.LblPoliza)
        Me.gbGlobal.Controls.Add(Me.cboDocumento)
        Me.gbGlobal.Controls.Add(Me.LblFecha)
        Me.gbGlobal.Controls.Add(Me.Label8)
        Me.gbGlobal.Controls.Add(Me.dtFecha)
        Me.gbGlobal.Controls.Add(Me.LblDisplayImporte)
        Me.gbGlobal.Controls.Add(Me.LblDocumento)
        Me.gbGlobal.Controls.Add(Me.TxtConcepto)
        Me.gbGlobal.Controls.Add(Me.LblDisplayConcepto)
        Me.gbGlobal.Controls.Add(Me.LblProveedor)
        Me.gbGlobal.Controls.Add(Me.LblDisplayProveedor)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFolio)
        Me.gbGlobal.Controls.Add(Me.TxtCodigoProveedor)
        Me.gbGlobal.Controls.Add(Me.TxtFolio)
        Me.gbGlobal.Controls.Add(Me.lblDisplayStatus)
        Me.gbGlobal.Controls.Add(Me.lblCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.LblStatus)
        Me.gbGlobal.Controls.Add(Me.lblDisplayCuentaBancaria)
        Me.gbGlobal.Controls.Add(Me.txtCuentaBancaria)
        Me.gbGlobal.Location = New System.Drawing.Point(6, 28)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Size = New System.Drawing.Size(1071, 226)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Datos"
        '
        'lblCuentaContableOrigenRecursos
        '
        Me.lblCuentaContableOrigenRecursos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCuentaContableOrigenRecursos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCuentaContableOrigenRecursos.Location = New System.Drawing.Point(531, 23)
        Me.lblCuentaContableOrigenRecursos.Name = "lblCuentaContableOrigenRecursos"
        Me.lblCuentaContableOrigenRecursos.Size = New System.Drawing.Size(238, 13)
        Me.lblCuentaContableOrigenRecursos.TabIndex = 385
        '
        'lblDisplayCuentaContableOrigenRecursos
        '
        Me.lblDisplayCuentaContableOrigenRecursos.AutoSize = True
        Me.lblDisplayCuentaContableOrigenRecursos.Location = New System.Drawing.Point(321, 22)
        Me.lblDisplayCuentaContableOrigenRecursos.Name = "lblDisplayCuentaContableOrigenRecursos"
        Me.lblDisplayCuentaContableOrigenRecursos.Size = New System.Drawing.Size(126, 13)
        Me.lblDisplayCuentaContableOrigenRecursos.TabIndex = 384
        Me.lblDisplayCuentaContableOrigenRecursos.Text = "Cuenta contable origen : "
        '
        'ckbAbonoCuentaBeneficiario
        '
        Me.ckbAbonoCuentaBeneficiario.AutoSize = True
        Me.ckbAbonoCuentaBeneficiario.Checked = True
        Me.ckbAbonoCuentaBeneficiario.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbAbonoCuentaBeneficiario.Location = New System.Drawing.Point(789, 42)
        Me.ckbAbonoCuentaBeneficiario.Name = "ckbAbonoCuentaBeneficiario"
        Me.ckbAbonoCuentaBeneficiario.Size = New System.Drawing.Size(211, 17)
        Me.ckbAbonoCuentaBeneficiario.TabIndex = 13
        Me.ckbAbonoCuentaBeneficiario.Text = "Para abono a la cuenta del beneficiario"
        Me.ckbAbonoCuentaBeneficiario.UseVisualStyleBackColor = True
        '
        'txtCuentaContableOrigenRecursos
        '
        Me.txtCuentaContableOrigenRecursos.Location = New System.Drawing.Point(443, 20)
        Me.txtCuentaContableOrigenRecursos.MaxLength = 20
        Me.txtCuentaContableOrigenRecursos.Name = "txtCuentaContableOrigenRecursos"
        Me.txtCuentaContableOrigenRecursos.Size = New System.Drawing.Size(83, 20)
        Me.txtCuentaContableOrigenRecursos.TabIndex = 383
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(253, 162)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(52, 13)
        Me.lblMoneda.TabIndex = 382
        Me.lblMoneda.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(309, 158)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(83, 21)
        Me.cboMoneda.TabIndex = 381
        '
        'lblNombreMonedaDestino
        '
        Me.lblNombreMonedaDestino.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNombreMonedaDestino.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreMonedaDestino.Location = New System.Drawing.Point(397, 137)
        Me.lblNombreMonedaDestino.Name = "lblNombreMonedaDestino"
        Me.lblNombreMonedaDestino.Size = New System.Drawing.Size(80, 13)
        Me.lblNombreMonedaDestino.TabIndex = 380
        '
        'lblNombreMonedaOrigen
        '
        Me.lblNombreMonedaOrigen.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNombreMonedaOrigen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreMonedaOrigen.Location = New System.Drawing.Point(397, 49)
        Me.lblNombreMonedaOrigen.Name = "lblNombreMonedaOrigen"
        Me.lblNombreMonedaOrigen.Size = New System.Drawing.Size(80, 13)
        Me.lblNombreMonedaOrigen.TabIndex = 379
        '
        'lblDisplayTipoPago
        '
        Me.lblDisplayTipoPago.AutoSize = True
        Me.lblDisplayTipoPago.Location = New System.Drawing.Point(6, 195)
        Me.lblDisplayTipoPago.Name = "lblDisplayTipoPago"
        Me.lblDisplayTipoPago.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplayTipoPago.TabIndex = 378
        Me.lblDisplayTipoPago.Text = "Tipo pago :"
        '
        'cboTipoPago
        '
        Me.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago.FormattingEnabled = True
        Me.cboTipoPago.Items.AddRange(New Object() {"A", "B"})
        Me.cboTipoPago.Location = New System.Drawing.Point(103, 192)
        Me.cboTipoPago.MaxLength = 1
        Me.cboTipoPago.Name = "cboTipoPago"
        Me.cboTipoPago.Size = New System.Drawing.Size(198, 21)
        Me.cboTipoPago.TabIndex = 6
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(275, 74)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoSiguiente.TabIndex = 376
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'lblDissplayRetencion
        '
        Me.lblDissplayRetencion.AutoSize = True
        Me.lblDissplayRetencion.Location = New System.Drawing.Point(850, 166)
        Me.lblDissplayRetencion.Name = "lblDissplayRetencion"
        Me.lblDissplayRetencion.Size = New System.Drawing.Size(62, 13)
        Me.lblDissplayRetencion.TabIndex = 307
        Me.lblDissplayRetencion.Text = "Retención :"
        Me.lblDissplayRetencion.Visible = False
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(244, 74)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoAnterior.TabIndex = 375
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'txtRetencion
        '
        Me.txtRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetencion.Location = New System.Drawing.Point(920, 158)
        Me.txtRetencion.MaxLength = 0
        Me.txtRetencion.Name = "txtRetencion"
        Me.txtRetencion.Size = New System.Drawing.Size(113, 26)
        Me.txtRetencion.TabIndex = 11
        Me.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencion.Visible = False
        '
        'gbPagosAutorizados
        '
        Me.gbPagosAutorizados.Controls.Add(Me.btnSiguiente)
        Me.gbPagosAutorizados.Controls.Add(Me.btnAutorizaciones)
        Me.gbPagosAutorizados.Location = New System.Drawing.Point(875, 27)
        Me.gbPagosAutorizados.Name = "gbPagosAutorizados"
        Me.gbPagosAutorizados.Size = New System.Drawing.Size(190, 129)
        Me.gbPagosAutorizados.TabIndex = 16
        Me.gbPagosAutorizados.TabStop = False
        Me.gbPagosAutorizados.Text = "Pagos autorizados"
        Me.gbPagosAutorizados.Visible = False
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(6, 29)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(180, 42)
        Me.btnSiguiente.TabIndex = 1
        Me.btnSiguiente.Text = "Siguiente proveedor autorizado"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAutorizaciones
        '
        Me.btnAutorizaciones.Location = New System.Drawing.Point(6, 77)
        Me.btnAutorizaciones.Name = "btnAutorizaciones"
        Me.btnAutorizaciones.Size = New System.Drawing.Size(180, 41)
        Me.btnAutorizaciones.TabIndex = 0
        Me.btnAutorizaciones.Text = "Ver Autorizaciones"
        Me.btnAutorizaciones.UseVisualStyleBackColor = True
        '
        'CkbPagoFleteEmbarques
        '
        Me.CkbPagoFleteEmbarques.AutoSize = True
        Me.CkbPagoFleteEmbarques.Checked = True
        Me.CkbPagoFleteEmbarques.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkbPagoFleteEmbarques.Location = New System.Drawing.Point(789, 4)
        Me.CkbPagoFleteEmbarques.Name = "CkbPagoFleteEmbarques"
        Me.CkbPagoFleteEmbarques.Size = New System.Drawing.Size(164, 17)
        Me.CkbPagoFleteEmbarques.TabIndex = 14
        Me.CkbPagoFleteEmbarques.Text = "Pago de fletes de embarques"
        Me.CkbPagoFleteEmbarques.UseVisualStyleBackColor = True
        Me.CkbPagoFleteEmbarques.Visible = False
        '
        'CboFacturasRecibidas
        '
        Me.CboFacturasRecibidas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFacturasRecibidas.FormattingEnabled = True
        Me.CboFacturasRecibidas.Location = New System.Drawing.Point(934, 190)
        Me.CboFacturasRecibidas.Name = "CboFacturasRecibidas"
        Me.CboFacturasRecibidas.Size = New System.Drawing.Size(127, 21)
        Me.CboFacturasRecibidas.TabIndex = 12
        '
        'lblFacturasRecibidas
        '
        Me.lblFacturasRecibidas.AutoSize = True
        Me.lblFacturasRecibidas.Location = New System.Drawing.Point(846, 195)
        Me.lblFacturasRecibidas.Name = "lblFacturasRecibidas"
        Me.lblFacturasRecibidas.Size = New System.Drawing.Size(82, 13)
        Me.lblFacturasRecibidas.TabIndex = 301
        Me.lblFacturasRecibidas.Text = "Fact. recibidas :"
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Location = New System.Drawing.Point(397, 161)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblTipoCambio.TabIndex = 297
        Me.lblTipoCambio.Text = "Tipo de cambio :"
        '
        'txtImporteDolares
        '
        Me.txtImporteDolares.Enabled = False
        Me.txtImporteDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtImporteDolares.Location = New System.Drawing.Point(698, 157)
        Me.txtImporteDolares.MaxLength = 15
        Me.txtImporteDolares.Name = "txtImporteDolares"
        Me.txtImporteDolares.Size = New System.Drawing.Size(142, 26)
        Me.txtImporteDolares.TabIndex = 10
        Me.txtImporteDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(493, 158)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(100, 20)
        Me.txtTipoCambio.TabIndex = 9
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.AutoSize = True
        Me.lblTotalDolares.Enabled = False
        Me.lblTotalDolares.Location = New System.Drawing.Point(602, 160)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(89, 13)
        Me.lblTotalDolares.TabIndex = 294
        Me.lblTotalDolares.Text = "Total en dólares :"
        '
        'LblPoliza
        '
        Me.LblPoliza.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblPoliza.Location = New System.Drawing.Point(500, 74)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(149, 13)
        Me.LblPoliza.TabIndex = 291
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 555)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1089, 24)
        Me.StatusStripEstado.TabIndex = 2
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
        'gbCompras
        '
        Me.gbCompras.Controls.Add(Me.Grid1)
        Me.gbCompras.Location = New System.Drawing.Point(6, 223)
        Me.gbCompras.Name = "gbCompras"
        Me.gbCompras.Size = New System.Drawing.Size(1071, 329)
        Me.gbCompras.TabIndex = 210
        Me.gbCompras.TabStop = False
        Me.gbCompras.Text = "Compras "
        '
        'Grid1
        '
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DefaultRowHeight = CType(24, Short)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(6, 37)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(1055, 258)
        Me.Grid1.TabIndex = 0
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbFleteEmbarques
        '
        Me.gbFleteEmbarques.Controls.Add(Me.Grid2)
        Me.gbFleteEmbarques.Location = New System.Drawing.Point(1079, 253)
        Me.gbFleteEmbarques.Name = "gbFleteEmbarques"
        Me.gbFleteEmbarques.Size = New System.Drawing.Size(978, 265)
        Me.gbFleteEmbarques.TabIndex = 211
        Me.gbFleteEmbarques.TabStop = False
        Me.gbFleteEmbarques.Text = "Embarques"
        Me.gbFleteEmbarques.Visible = False
        '
        'Grid2
        '
        Me.Grid2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid2.CheckedImage = CType(resources.GetObject("Grid2.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid2.Cols = 1
        Me.Grid2.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid2.DefaultRowHeight = CType(24, Short)
        Me.Grid2.DisplayRowNumber = True
        Me.Grid2.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid2.Location = New System.Drawing.Point(12, 19)
        Me.Grid2.LockButton = True
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Rows = 20
        Me.Grid2.Size = New System.Drawing.Size(960, 240)
        Me.Grid2.TabIndex = 210
        Me.Grid2.UncheckedImage = CType(resources.GetObject("Grid2.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Frm_CXP_Pagos_Acreedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1089, 579)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.gbFleteEmbarques)
        Me.Controls.Add(Me.gbCompras)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.LblDisplayTotales)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXP_Pagos_Acreedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elaboración de pagos a acreedores."
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbGlobal.ResumeLayout(False)
        Me.gbGlobal.PerformLayout()
        Me.gbPagosAutorizados.ResumeLayout(False)
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbCompras.ResumeLayout(False)
        Me.gbFleteEmbarques.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents cboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCuentaBancaria As System.Windows.Forms.Label
    Friend WithEvents txtCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents LblProveedor As System.Windows.Forms.Label
    Friend WithEvents LblDisplayProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayImporte As System.Windows.Forms.Label
    Friend WithEvents TxtImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbGlobal As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents gbCompras As System.Windows.Forms.GroupBox
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents ckbAbonoCuentaBeneficiario As System.Windows.Forms.CheckBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtImporteDolares As System.Windows.Forms.TextBox
    Friend WithEvents CboFacturasRecibidas As System.Windows.Forms.ComboBox
    Friend WithEvents lblFacturasRecibidas As System.Windows.Forms.Label
    Friend WithEvents CkbPagoFleteEmbarques As System.Windows.Forms.CheckBox
    Friend WithEvents gbFleteEmbarques As System.Windows.Forms.GroupBox
    Friend WithEvents Grid2 As FlexCell.Grid
    Friend WithEvents gbPagosAutorizados As System.Windows.Forms.GroupBox
    Friend WithEvents btnAutorizaciones As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents lblDissplayRetencion As System.Windows.Forms.Label
    Friend WithEvents txtRetencion As System.Windows.Forms.TextBox
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents lblDisplayTipoPago As System.Windows.Forms.Label
    Friend WithEvents cboTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreMonedaOrigen As System.Windows.Forms.Label
    Friend WithEvents lblNombreMonedaDestino As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents tsbIvaAcreditable As ToolStripButton
    Friend WithEvents txtCuentaContableOrigenRecursos As TextBox
    Friend WithEvents lblCuentaContableOrigenRecursos As Label
    Friend WithEvents lblDisplayCuentaContableOrigenRecursos As Label
End Class
