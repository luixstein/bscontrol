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
        Me.txtCuentaContableOrigenRecursos = New System.Windows.Forms.TextBox()
        Me.lblCuentaContableOrigenRecursos = New System.Windows.Forms.Label()
        Me.lblDisplayCuentaContableOrigenRecursos = New System.Windows.Forms.Label()
        Me.ckbAbonoCuentaBeneficiario = New System.Windows.Forms.CheckBox()
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
        Me.CboFacturasRecibidas = New System.Windows.Forms.ComboBox()
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
        Me.dtFecha.Location = New System.Drawing.Point(137, 127)
        Me.dtFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(280, 22)
        Me.dtFecha.TabIndex = 3
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(8, 130)
        Me.LblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(55, 17)
        Me.LblFecha.TabIndex = 175
        Me.LblFecha.Text = "Fecha :"
        '
        'cboDocumento
        '
        Me.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumento.FormattingEnabled = True
        Me.cboDocumento.Location = New System.Drawing.Point(137, 23)
        Me.cboDocumento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(280, 24)
        Me.cboDocumento.TabIndex = 0
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(7, 27)
        Me.LblDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(88, 17)
        Me.LblDocumento.TabIndex = 177
        Me.LblDocumento.Text = "Documento :"
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbIvaAcreditable, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1637, 27)
        Me.tsMenu.TabIndex = 1
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(90, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbIvaAcreditable
        '
        Me.tsbIvaAcreditable.Image = CType(resources.GetObject("tsbIvaAcreditable.Image"), System.Drawing.Image)
        Me.tsbIvaAcreditable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbIvaAcreditable.Name = "tsbIvaAcreditable"
        Me.tsbIvaAcreditable.Size = New System.Drawing.Size(131, 24)
        Me.tsbIvaAcreditable.Text = "Iva acreditable"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(409, 240)
        Me.LblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayConcepto.TabIndex = 185
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(496, 235)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(623, 22)
        Me.TxtConcepto.TabIndex = 8
        '
        'LblDisplayTotales
        '
        Me.LblDisplayTotales.AutoSize = True
        Me.LblDisplayTotales.Location = New System.Drawing.Point(801, 786)
        Me.LblDisplayTotales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTotales.Name = "LblDisplayTotales"
        Me.LblDisplayTotales.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayTotales.TabIndex = 209
        Me.LblDisplayTotales.Text = "Totales :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(137, 89)
        Me.TxtFolio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(179, 30)
        Me.TxtFolio.TabIndex = 2
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(7, 91)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 216
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblStatus.Location = New System.Drawing.Point(491, 92)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(101, 16)
        Me.LblStatus.TabIndex = 218
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(419, 92)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 217
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'lblCuentaBancaria
        '
        Me.lblCuentaBancaria.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCuentaBancaria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCuentaBancaria.Location = New System.Drawing.Point(200, 60)
        Me.lblCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuentaBancaria.Name = "lblCuentaBancaria"
        Me.lblCuentaBancaria.Size = New System.Drawing.Size(317, 16)
        Me.lblCuentaBancaria.TabIndex = 223
        '
        'lblDisplayCuentaBancaria
        '
        Me.lblDisplayCuentaBancaria.AutoSize = True
        Me.lblDisplayCuentaBancaria.Location = New System.Drawing.Point(7, 59)
        Me.lblDisplayCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaBancaria.Name = "lblDisplayCuentaBancaria"
        Me.lblDisplayCuentaBancaria.Size = New System.Drawing.Size(120, 17)
        Me.lblDisplayCuentaBancaria.TabIndex = 222
        Me.lblDisplayCuentaBancaria.Text = "Cuenta bancaria :"
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(137, 55)
        Me.txtCuentaBancaria.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuentaBancaria.MaxLength = 6
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(53, 22)
        Me.txtCuentaBancaria.TabIndex = 1
        '
        'LblProveedor
        '
        Me.LblProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblProveedor.Location = New System.Drawing.Point(256, 169)
        Me.LblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(261, 16)
        Me.LblProveedor.TabIndex = 236
        '
        'LblDisplayProveedor
        '
        Me.LblDisplayProveedor.AutoSize = True
        Me.LblDisplayProveedor.Location = New System.Drawing.Point(7, 167)
        Me.LblDisplayProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayProveedor.Name = "LblDisplayProveedor"
        Me.LblDisplayProveedor.Size = New System.Drawing.Size(74, 17)
        Me.LblDisplayProveedor.TabIndex = 235
        Me.LblDisplayProveedor.Text = "Acreedor :"
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(137, 165)
        Me.TxtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoProveedor.MaxLength = 8
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoProveedor.TabIndex = 4
        '
        'LblDisplayImporte
        '
        Me.LblDisplayImporte.AutoSize = True
        Me.LblDisplayImporte.Location = New System.Drawing.Point(7, 199)
        Me.LblDisplayImporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayImporte.Name = "LblDisplayImporte"
        Me.LblDisplayImporte.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayImporte.TabIndex = 239
        Me.LblDisplayImporte.Text = "Importe :"
        '
        'TxtImporte
        '
        Me.TxtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImporte.Location = New System.Drawing.Point(137, 194)
        Me.TxtImporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtImporte.MaxLength = 0
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(179, 30)
        Me.TxtImporte.TabIndex = 5
        Me.TxtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(603, 91)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 17)
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
        Me.gbGlobal.Location = New System.Drawing.Point(8, 34)
        Me.gbGlobal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbGlobal.Size = New System.Drawing.Size(1625, 278)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Datos"
        '
        'txtCuentaContableOrigenRecursos
        '
        Me.txtCuentaContableOrigenRecursos.Location = New System.Drawing.Point(591, 25)
        Me.txtCuentaContableOrigenRecursos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuentaContableOrigenRecursos.MaxLength = 20
        Me.txtCuentaContableOrigenRecursos.Name = "txtCuentaContableOrigenRecursos"
        Me.txtCuentaContableOrigenRecursos.Size = New System.Drawing.Size(109, 22)
        Me.txtCuentaContableOrigenRecursos.TabIndex = 383
        '
        'lblCuentaContableOrigenRecursos
        '
        Me.lblCuentaContableOrigenRecursos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCuentaContableOrigenRecursos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCuentaContableOrigenRecursos.Location = New System.Drawing.Point(708, 28)
        Me.lblCuentaContableOrigenRecursos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuentaContableOrigenRecursos.Name = "lblCuentaContableOrigenRecursos"
        Me.lblCuentaContableOrigenRecursos.Size = New System.Drawing.Size(317, 16)
        Me.lblCuentaContableOrigenRecursos.TabIndex = 385
        '
        'lblDisplayCuentaContableOrigenRecursos
        '
        Me.lblDisplayCuentaContableOrigenRecursos.AutoSize = True
        Me.lblDisplayCuentaContableOrigenRecursos.Location = New System.Drawing.Point(428, 27)
        Me.lblDisplayCuentaContableOrigenRecursos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaContableOrigenRecursos.Name = "lblDisplayCuentaContableOrigenRecursos"
        Me.lblDisplayCuentaContableOrigenRecursos.Size = New System.Drawing.Size(167, 17)
        Me.lblDisplayCuentaContableOrigenRecursos.TabIndex = 384
        Me.lblDisplayCuentaContableOrigenRecursos.Text = "Cuenta contable origen : "
        '
        'ckbAbonoCuentaBeneficiario
        '
        Me.ckbAbonoCuentaBeneficiario.AutoSize = True
        Me.ckbAbonoCuentaBeneficiario.Checked = True
        Me.ckbAbonoCuentaBeneficiario.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbAbonoCuentaBeneficiario.Location = New System.Drawing.Point(1052, 52)
        Me.ckbAbonoCuentaBeneficiario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ckbAbonoCuentaBeneficiario.Name = "ckbAbonoCuentaBeneficiario"
        Me.ckbAbonoCuentaBeneficiario.Size = New System.Drawing.Size(278, 21)
        Me.ckbAbonoCuentaBeneficiario.TabIndex = 13
        Me.ckbAbonoCuentaBeneficiario.Text = "Para abono a la cuenta del beneficiario"
        Me.ckbAbonoCuentaBeneficiario.UseVisualStyleBackColor = True
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(337, 199)
        Me.lblMoneda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(67, 17)
        Me.lblMoneda.TabIndex = 382
        Me.lblMoneda.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(412, 194)
        Me.cboMoneda.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(109, 24)
        Me.cboMoneda.TabIndex = 381
        '
        'lblNombreMonedaDestino
        '
        Me.lblNombreMonedaDestino.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNombreMonedaDestino.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreMonedaDestino.Location = New System.Drawing.Point(529, 169)
        Me.lblNombreMonedaDestino.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreMonedaDestino.Name = "lblNombreMonedaDestino"
        Me.lblNombreMonedaDestino.Size = New System.Drawing.Size(107, 16)
        Me.lblNombreMonedaDestino.TabIndex = 380
        '
        'lblNombreMonedaOrigen
        '
        Me.lblNombreMonedaOrigen.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNombreMonedaOrigen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreMonedaOrigen.Location = New System.Drawing.Point(529, 60)
        Me.lblNombreMonedaOrigen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreMonedaOrigen.Name = "lblNombreMonedaOrigen"
        Me.lblNombreMonedaOrigen.Size = New System.Drawing.Size(107, 16)
        Me.lblNombreMonedaOrigen.TabIndex = 379
        '
        'lblDisplayTipoPago
        '
        Me.lblDisplayTipoPago.AutoSize = True
        Me.lblDisplayTipoPago.Location = New System.Drawing.Point(8, 240)
        Me.lblDisplayTipoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoPago.Name = "lblDisplayTipoPago"
        Me.lblDisplayTipoPago.Size = New System.Drawing.Size(80, 17)
        Me.lblDisplayTipoPago.TabIndex = 378
        Me.lblDisplayTipoPago.Text = "Tipo pago :"
        '
        'cboTipoPago
        '
        Me.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago.FormattingEnabled = True
        Me.cboTipoPago.Items.AddRange(New Object() {"A", "B"})
        Me.cboTipoPago.Location = New System.Drawing.Point(137, 236)
        Me.cboTipoPago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboTipoPago.MaxLength = 1
        Me.cboTipoPago.Name = "cboTipoPago"
        Me.cboTipoPago.Size = New System.Drawing.Size(263, 24)
        Me.cboTipoPago.TabIndex = 6
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(367, 91)
        Me.btnDocumentoSiguiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoSiguiente.TabIndex = 376
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'lblDissplayRetencion
        '
        Me.lblDissplayRetencion.AutoSize = True
        Me.lblDissplayRetencion.Location = New System.Drawing.Point(1133, 204)
        Me.lblDissplayRetencion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDissplayRetencion.Name = "lblDissplayRetencion"
        Me.lblDissplayRetencion.Size = New System.Drawing.Size(80, 17)
        Me.lblDissplayRetencion.TabIndex = 307
        Me.lblDissplayRetencion.Text = "Retención :"
        Me.lblDissplayRetencion.Visible = False
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(325, 91)
        Me.btnDocumentoAnterior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoAnterior.TabIndex = 375
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'txtRetencion
        '
        Me.txtRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetencion.Location = New System.Drawing.Point(1227, 194)
        Me.txtRetencion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRetencion.MaxLength = 0
        Me.txtRetencion.Name = "txtRetencion"
        Me.txtRetencion.Size = New System.Drawing.Size(149, 30)
        Me.txtRetencion.TabIndex = 11
        Me.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencion.Visible = False
        '
        'gbPagosAutorizados
        '
        Me.gbPagosAutorizados.Controls.Add(Me.btnSiguiente)
        Me.gbPagosAutorizados.Controls.Add(Me.btnAutorizaciones)
        Me.gbPagosAutorizados.Location = New System.Drawing.Point(1167, 33)
        Me.gbPagosAutorizados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbPagosAutorizados.Name = "gbPagosAutorizados"
        Me.gbPagosAutorizados.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbPagosAutorizados.Size = New System.Drawing.Size(253, 159)
        Me.gbPagosAutorizados.TabIndex = 16
        Me.gbPagosAutorizados.TabStop = False
        Me.gbPagosAutorizados.Text = "Pagos autorizados"
        Me.gbPagosAutorizados.Visible = False
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(8, 36)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(240, 52)
        Me.btnSiguiente.TabIndex = 1
        Me.btnSiguiente.Text = "Siguiente proveedor autorizado"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAutorizaciones
        '
        Me.btnAutorizaciones.Location = New System.Drawing.Point(8, 95)
        Me.btnAutorizaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAutorizaciones.Name = "btnAutorizaciones"
        Me.btnAutorizaciones.Size = New System.Drawing.Size(240, 50)
        Me.btnAutorizaciones.TabIndex = 0
        Me.btnAutorizaciones.Text = "Ver Autorizaciones"
        Me.btnAutorizaciones.UseVisualStyleBackColor = True
        '
        'CkbPagoFleteEmbarques
        '
        Me.CkbPagoFleteEmbarques.AutoSize = True
        Me.CkbPagoFleteEmbarques.Checked = True
        Me.CkbPagoFleteEmbarques.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkbPagoFleteEmbarques.Location = New System.Drawing.Point(1052, 5)
        Me.CkbPagoFleteEmbarques.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CkbPagoFleteEmbarques.Name = "CkbPagoFleteEmbarques"
        Me.CkbPagoFleteEmbarques.Size = New System.Drawing.Size(216, 21)
        Me.CkbPagoFleteEmbarques.TabIndex = 14
        Me.CkbPagoFleteEmbarques.Text = "Pago de fletes de embarques"
        Me.CkbPagoFleteEmbarques.UseVisualStyleBackColor = True
        Me.CkbPagoFleteEmbarques.Visible = False
        '
        'lblFacturasRecibidas
        '
        Me.lblFacturasRecibidas.AutoSize = True
        Me.lblFacturasRecibidas.Location = New System.Drawing.Point(1128, 240)
        Me.lblFacturasRecibidas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacturasRecibidas.Name = "lblFacturasRecibidas"
        Me.lblFacturasRecibidas.Size = New System.Drawing.Size(108, 17)
        Me.lblFacturasRecibidas.TabIndex = 301
        Me.lblFacturasRecibidas.Text = "Fact. recibidas :"
        Me.lblFacturasRecibidas.Visible = False
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Location = New System.Drawing.Point(529, 198)
        Me.lblTipoCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(113, 17)
        Me.lblTipoCambio.TabIndex = 297
        Me.lblTipoCambio.Text = "Tipo de cambio :"
        '
        'txtImporteDolares
        '
        Me.txtImporteDolares.Enabled = False
        Me.txtImporteDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtImporteDolares.Location = New System.Drawing.Point(931, 193)
        Me.txtImporteDolares.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtImporteDolares.MaxLength = 15
        Me.txtImporteDolares.Name = "txtImporteDolares"
        Me.txtImporteDolares.Size = New System.Drawing.Size(188, 30)
        Me.txtImporteDolares.TabIndex = 10
        Me.txtImporteDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(657, 194)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(132, 22)
        Me.txtTipoCambio.TabIndex = 9
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.AutoSize = True
        Me.lblTotalDolares.Enabled = False
        Me.lblTotalDolares.Location = New System.Drawing.Point(803, 197)
        Me.lblTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(119, 17)
        Me.lblTotalDolares.TabIndex = 294
        Me.lblTotalDolares.Text = "Total en dólares :"
        '
        'LblPoliza
        '
        Me.LblPoliza.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblPoliza.Location = New System.Drawing.Point(667, 91)
        Me.LblPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(199, 16)
        Me.LblPoliza.TabIndex = 291
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 684)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1637, 29)
        Me.StatusStripEstado.TabIndex = 2
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
        'gbCompras
        '
        Me.gbCompras.Controls.Add(Me.Grid1)
        Me.gbCompras.Location = New System.Drawing.Point(8, 274)
        Me.gbCompras.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCompras.Name = "gbCompras"
        Me.gbCompras.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCompras.Size = New System.Drawing.Size(1625, 405)
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
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(8, 46)
        Me.Grid1.LockButton = True
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(1609, 324)
        Me.Grid1.TabIndex = 0
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbFleteEmbarques
        '
        Me.gbFleteEmbarques.Controls.Add(Me.Grid2)
        Me.gbFleteEmbarques.Location = New System.Drawing.Point(1648, 311)
        Me.gbFleteEmbarques.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbFleteEmbarques.Name = "gbFleteEmbarques"
        Me.gbFleteEmbarques.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbFleteEmbarques.Size = New System.Drawing.Size(1304, 326)
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
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid2.Location = New System.Drawing.Point(16, 23)
        Me.Grid2.LockButton = True
        Me.Grid2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Rows = 20
        Me.Grid2.Size = New System.Drawing.Size(1280, 295)
        Me.Grid2.TabIndex = 210
        Me.Grid2.UncheckedImage = CType(resources.GetObject("Grid2.UncheckedImage"), System.Drawing.Bitmap)
        '
        'CboFacturasRecibidas
        '
        Me.CboFacturasRecibidas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFacturasRecibidas.FormattingEnabled = True
        Me.CboFacturasRecibidas.Location = New System.Drawing.Point(1245, 234)
        Me.CboFacturasRecibidas.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFacturasRecibidas.Name = "CboFacturasRecibidas"
        Me.CboFacturasRecibidas.Size = New System.Drawing.Size(168, 24)
        Me.CboFacturasRecibidas.TabIndex = 12
        Me.CboFacturasRecibidas.Visible = False
        '
        'Frm_CXP_Pagos_Acreedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1637, 713)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.gbFleteEmbarques)
        Me.Controls.Add(Me.gbCompras)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.LblDisplayTotales)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents CboFacturasRecibidas As System.Windows.Forms.ComboBox
End Class
