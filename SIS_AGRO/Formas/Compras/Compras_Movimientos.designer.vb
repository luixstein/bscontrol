<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Compras_Movimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Compras_Movimientos))
        Me.gbGlobal = New System.Windows.Forms.GroupBox()
        Me.lblDisplayFechaEntrega = New System.Windows.Forms.Label()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayMoneda = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.btnActualizaConcepto = New System.Windows.Forms.Button()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.BtnActualizaFolioProv = New System.Windows.Forms.Button()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.DtpFechaFacturaProveedor = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFechaFacturaProveedor = New System.Windows.Forms.Label()
        Me.txtConfirmo = New System.Windows.Forms.TextBox()
        Me.lblDisplayConfirmo = New System.Windows.Forms.Label()
        Me.txtPredio = New System.Windows.Forms.TextBox()
        Me.lblDisplayPredio = New System.Windows.Forms.Label()
        Me.txtConCargoA = New System.Windows.Forms.TextBox()
        Me.lblDisplayConCargoA = New System.Windows.Forms.Label()
        Me.txtFolioCompra = New System.Windows.Forms.TextBox()
        Me.LblDisplayTipoCambio = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblDilplayPoliza = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.dtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayVencimiento = New System.Windows.Forms.Label()
        Me.LblDisplayConcepto = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.txtFolioProveedor = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioProveedor = New System.Windows.Forms.Label()
        Me.txtSolicito = New System.Windows.Forms.TextBox()
        Me.LblDisplaySolicito = New System.Windows.Forms.Label()
        Me.txtEntregarA = New System.Windows.Forms.TextBox()
        Me.LblDisplayEntregarA = New System.Windows.Forms.Label()
        Me.txtPlazo = New System.Windows.Forms.TextBox()
        Me.LblDisplayPlazo = New System.Windows.Forms.Label()
        Me.txtFolioOC = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioOC = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.LblDisplayProveedor = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFecha = New System.Windows.Forms.Label()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.LblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDisplayDocumento = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbPasarOrdenACompra = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditarCostos = New System.Windows.Forms.ToolStripButton()
        Me.tsbAgregarXML = New System.Windows.Forms.ToolStripButton()
        Me.tsbAgregarPDF = New System.Windows.Forms.ToolStripButton()
        Me.txtSaldo_MXP = New System.Windows.Forms.TextBox()
        Me.lblDisplaySaldo_MXP = New System.Windows.Forms.Label()
        Me.lblDisplayRetenciones = New System.Windows.Forms.Label()
        Me.txtRetencionIVA = New System.Windows.Forms.TextBox()
        Me.lblDisplayTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.MaskedTextBox()
        Me.lblDisplayIVA = New System.Windows.Forms.Label()
        Me.lblDisplaySubTotal = New System.Windows.Forms.Label()
        Me.TxtSubTotal = New System.Windows.Forms.MaskedTextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.lblIVAcalculado = New System.Windows.Forms.Label()
        Me.txtIVA_USD = New System.Windows.Forms.TextBox()
        Me.lblDisplayTotal_USD = New System.Windows.Forms.Label()
        Me.txtTotal_USD = New System.Windows.Forms.MaskedTextBox()
        Me.lblDisplayIVA_USD = New System.Windows.Forms.Label()
        Me.lblDisplaySubTotal_USD = New System.Windows.Forms.Label()
        Me.TxtSubTotal_USD = New System.Windows.Forms.MaskedTextBox()
        Me.gbUSD = New System.Windows.Forms.GroupBox()
        Me.lblIVAcalculado_USD = New System.Windows.Forms.Label()
        Me.txtRetencionISR_USD = New System.Windows.Forms.TextBox()
        Me.lblDisplayRetencionISR_USD = New System.Windows.Forms.Label()
        Me.lblDisplayRetencionIVA_USD = New System.Windows.Forms.Label()
        Me.txtRetencionIVA_USD = New System.Windows.Forms.TextBox()
        Me.lblDisplayRetenciones_USD = New System.Windows.Forms.Label()
        Me.txtIEPS_USD = New System.Windows.Forms.TextBox()
        Me.lblDisplayIEPS_USD = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpArticulos = New System.Windows.Forms.TabPage()
        Me.Grid = New FlexCell.Grid()
        Me.tpSeries = New System.Windows.Forms.TabPage()
        Me.lblDisplayLote = New System.Windows.Forms.Label()
        Me.btnCopiarLote = New System.Windows.Forms.Button()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.GridSeries = New FlexCell.Grid()
        Me.btnSeries = New System.Windows.Forms.Button()
        Me.txtSaldo_USD = New System.Windows.Forms.TextBox()
        Me.lblDisplaySaldo_USD = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSeleccionarArchivoSeries = New System.Windows.Forms.Button()
        Me.txtIEPS = New System.Windows.Forms.TextBox()
        Me.lblDisplayIEPS = New System.Windows.Forms.Label()
        Me.TxtConceptoCancelacion = New System.Windows.Forms.TextBox()
        Me.LblConceptoCancelacion = New System.Windows.Forms.Label()
        Me.gbMXN = New System.Windows.Forms.GroupBox()
        Me.txtRetencionISR = New System.Windows.Forms.TextBox()
        Me.lblDisplayRetencionISR = New System.Windows.Forms.Label()
        Me.lblDisplayRetencionIVA = New System.Windows.Forms.Label()
        Me.gbGlobal.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbUSD.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpArticulos.SuspendLayout()
        Me.tpSeries.SuspendLayout()
        Me.gbMXN.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.lblDisplayFechaEntrega)
        Me.gbGlobal.Controls.Add(Me.dtpFechaEntrega)
        Me.gbGlobal.Controls.Add(Me.LblDisplayMoneda)
        Me.gbGlobal.Controls.Add(Me.cboMoneda)
        Me.gbGlobal.Controls.Add(Me.lblProveedor)
        Me.gbGlobal.Controls.Add(Me.btnActualizaConcepto)
        Me.gbGlobal.Controls.Add(Me.btnDocumentoSiguiente)
        Me.gbGlobal.Controls.Add(Me.btnDocumentoAnterior)
        Me.gbGlobal.Controls.Add(Me.BtnActualizaFolioProv)
        Me.gbGlobal.Controls.Add(Me.LblPoliza)
        Me.gbGlobal.Controls.Add(Me.DtpFechaFacturaProveedor)
        Me.gbGlobal.Controls.Add(Me.lblDisplayFechaFacturaProveedor)
        Me.gbGlobal.Controls.Add(Me.txtConfirmo)
        Me.gbGlobal.Controls.Add(Me.lblDisplayConfirmo)
        Me.gbGlobal.Controls.Add(Me.txtPredio)
        Me.gbGlobal.Controls.Add(Me.lblDisplayPredio)
        Me.gbGlobal.Controls.Add(Me.txtConCargoA)
        Me.gbGlobal.Controls.Add(Me.lblDisplayConCargoA)
        Me.gbGlobal.Controls.Add(Me.txtFolioCompra)
        Me.gbGlobal.Controls.Add(Me.LblDisplayTipoCambio)
        Me.gbGlobal.Controls.Add(Me.txtTipoCambio)
        Me.gbGlobal.Controls.Add(Me.lblDilplayPoliza)
        Me.gbGlobal.Controls.Add(Me.LblEstatus)
        Me.gbGlobal.Controls.Add(Me.lblDisplayStatus)
        Me.gbGlobal.Controls.Add(Me.dtpFechaVencimiento)
        Me.gbGlobal.Controls.Add(Me.LblDisplayVencimiento)
        Me.gbGlobal.Controls.Add(Me.LblDisplayConcepto)
        Me.gbGlobal.Controls.Add(Me.TxtConcepto)
        Me.gbGlobal.Controls.Add(Me.txtFolioProveedor)
        Me.gbGlobal.Controls.Add(Me.lblDisplayFolioProveedor)
        Me.gbGlobal.Controls.Add(Me.txtSolicito)
        Me.gbGlobal.Controls.Add(Me.LblDisplaySolicito)
        Me.gbGlobal.Controls.Add(Me.txtEntregarA)
        Me.gbGlobal.Controls.Add(Me.LblDisplayEntregarA)
        Me.gbGlobal.Controls.Add(Me.txtPlazo)
        Me.gbGlobal.Controls.Add(Me.LblDisplayPlazo)
        Me.gbGlobal.Controls.Add(Me.txtFolioOC)
        Me.gbGlobal.Controls.Add(Me.lblDisplayFolioOC)
        Me.gbGlobal.Controls.Add(Me.txtProveedor)
        Me.gbGlobal.Controls.Add(Me.LblDisplayProveedor)
        Me.gbGlobal.Controls.Add(Me.DtpFecha)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFecha)
        Me.gbGlobal.Controls.Add(Me.CboAlmacen)
        Me.gbGlobal.Controls.Add(Me.LblDisplayAlmacen)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFolio)
        Me.gbGlobal.Controls.Add(Me.CboDocumento)
        Me.gbGlobal.Controls.Add(Me.LblDisplayDocumento)
        Me.gbGlobal.Location = New System.Drawing.Point(1, 28)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Size = New System.Drawing.Size(1019, 211)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        '
        'lblDisplayFechaEntrega
        '
        Me.lblDisplayFechaEntrega.AutoSize = True
        Me.lblDisplayFechaEntrega.Location = New System.Drawing.Point(656, 85)
        Me.lblDisplayFechaEntrega.Name = "lblDisplayFechaEntrega"
        Me.lblDisplayFechaEntrega.Size = New System.Drawing.Size(82, 13)
        Me.lblDisplayFechaEntrega.TabIndex = 384
        Me.lblDisplayFechaEntrega.Text = "Fecha entrega :"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Enabled = False
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(742, 82)
        Me.dtpFechaEntrega.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(211, 20)
        Me.dtpFechaEntrega.TabIndex = 383
        '
        'LblDisplayMoneda
        '
        Me.LblDisplayMoneda.AutoSize = True
        Me.LblDisplayMoneda.Location = New System.Drawing.Point(6, 126)
        Me.LblDisplayMoneda.Name = "LblDisplayMoneda"
        Me.LblDisplayMoneda.Size = New System.Drawing.Size(52, 13)
        Me.LblDisplayMoneda.TabIndex = 382
        Me.LblDisplayMoneda.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(80, 124)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(78, 21)
        Me.cboMoneda.TabIndex = 381
        '
        'lblProveedor
        '
        Me.lblProveedor.Location = New System.Drawing.Point(188, 100)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(442, 13)
        Me.lblProveedor.TabIndex = 380
        Me.lblProveedor.Text = "_"
        '
        'btnActualizaConcepto
        '
        Me.btnActualizaConcepto.Location = New System.Drawing.Point(904, 102)
        Me.btnActualizaConcepto.Name = "btnActualizaConcepto"
        Me.btnActualizaConcepto.Size = New System.Drawing.Size(108, 21)
        Me.btnActualizaConcepto.TabIndex = 379
        Me.btnActualizaConcepto.Text = "Actualiza concepto"
        Me.btnActualizaConcepto.UseVisualStyleBackColor = True
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(219, 70)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoSiguiente.TabIndex = 378
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(188, 70)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoAnterior.TabIndex = 377
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'BtnActualizaFolioProv
        '
        Me.BtnActualizaFolioProv.Location = New System.Drawing.Point(534, 44)
        Me.BtnActualizaFolioProv.Name = "BtnActualizaFolioProv"
        Me.BtnActualizaFolioProv.Size = New System.Drawing.Size(109, 21)
        Me.BtnActualizaFolioProv.TabIndex = 329
        Me.BtnActualizaFolioProv.Text = "Actualiza folio prov"
        Me.BtnActualizaFolioProv.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(528, 16)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(13, 13)
        Me.LblPoliza.TabIndex = 328
        Me.LblPoliza.TabStop = True
        Me.LblPoliza.Text = "_"
        '
        'DtpFechaFacturaProveedor
        '
        Me.DtpFechaFacturaProveedor.Location = New System.Drawing.Point(419, 123)
        Me.DtpFechaFacturaProveedor.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFechaFacturaProveedor.Name = "DtpFechaFacturaProveedor"
        Me.DtpFechaFacturaProveedor.Size = New System.Drawing.Size(211, 20)
        Me.DtpFechaFacturaProveedor.TabIndex = 326
        '
        'lblDisplayFechaFacturaProveedor
        '
        Me.lblDisplayFechaFacturaProveedor.AutoSize = True
        Me.lblDisplayFechaFacturaProveedor.Location = New System.Drawing.Point(323, 126)
        Me.lblDisplayFechaFacturaProveedor.Name = "lblDisplayFechaFacturaProveedor"
        Me.lblDisplayFechaFacturaProveedor.Size = New System.Drawing.Size(88, 13)
        Me.lblDisplayFechaFacturaProveedor.TabIndex = 327
        Me.lblDisplayFechaFacturaProveedor.Text = "Fac. proveedor  :"
        '
        'txtConfirmo
        '
        Me.txtConfirmo.Location = New System.Drawing.Point(419, 183)
        Me.txtConfirmo.MaxLength = 80
        Me.txtConfirmo.Name = "txtConfirmo"
        Me.txtConfirmo.Size = New System.Drawing.Size(211, 20)
        Me.txtConfirmo.TabIndex = 12
        '
        'lblDisplayConfirmo
        '
        Me.lblDisplayConfirmo.AutoSize = True
        Me.lblDisplayConfirmo.Location = New System.Drawing.Point(323, 186)
        Me.lblDisplayConfirmo.Name = "lblDisplayConfirmo"
        Me.lblDisplayConfirmo.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayConfirmo.TabIndex = 325
        Me.lblDisplayConfirmo.Text = "Confirmó :"
        '
        'txtPredio
        '
        Me.txtPredio.Location = New System.Drawing.Point(419, 163)
        Me.txtPredio.MaxLength = 80
        Me.txtPredio.Name = "txtPredio"
        Me.txtPredio.Size = New System.Drawing.Size(211, 20)
        Me.txtPredio.TabIndex = 11
        '
        'lblDisplayPredio
        '
        Me.lblDisplayPredio.AutoSize = True
        Me.lblDisplayPredio.Location = New System.Drawing.Point(323, 166)
        Me.lblDisplayPredio.Name = "lblDisplayPredio"
        Me.lblDisplayPredio.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayPredio.TabIndex = 321
        Me.lblDisplayPredio.Text = "Predio :"
        '
        'txtConCargoA
        '
        Me.txtConCargoA.Location = New System.Drawing.Point(419, 143)
        Me.txtConCargoA.MaxLength = 80
        Me.txtConCargoA.Name = "txtConCargoA"
        Me.txtConCargoA.Size = New System.Drawing.Size(211, 20)
        Me.txtConCargoA.TabIndex = 10
        '
        'lblDisplayConCargoA
        '
        Me.lblDisplayConCargoA.AutoSize = True
        Me.lblDisplayConCargoA.Location = New System.Drawing.Point(323, 146)
        Me.lblDisplayConCargoA.Name = "lblDisplayConCargoA"
        Me.lblDisplayConCargoA.Size = New System.Drawing.Size(71, 13)
        Me.lblDisplayConCargoA.TabIndex = 320
        Me.lblDisplayConCargoA.Text = "Con cargo a :"
        '
        'txtFolioCompra
        '
        Me.txtFolioCompra.Location = New System.Drawing.Point(80, 71)
        Me.txtFolioCompra.MaxLength = 15
        Me.txtFolioCompra.Name = "txtFolioCompra"
        Me.txtFolioCompra.Size = New System.Drawing.Size(102, 20)
        Me.txtFolioCompra.TabIndex = 2
        '
        'LblDisplayTipoCambio
        '
        Me.LblDisplayTipoCambio.AutoSize = True
        Me.LblDisplayTipoCambio.Location = New System.Drawing.Point(163, 126)
        Me.LblDisplayTipoCambio.Name = "LblDisplayTipoCambio"
        Me.LblDisplayTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.LblDisplayTipoCambio.TabIndex = 317
        Me.LblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(251, 123)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(62, 20)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDilplayPoliza
        '
        Me.lblDilplayPoliza.AutoSize = True
        Me.lblDilplayPoliza.Location = New System.Drawing.Point(454, 16)
        Me.lblDilplayPoliza.Name = "lblDilplayPoliza"
        Me.lblDilplayPoliza.Size = New System.Drawing.Size(41, 13)
        Me.lblDilplayPoliza.TabIndex = 299
        Me.lblDilplayPoliza.Text = "Póliza :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(872, 42)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(13, 13)
        Me.LblEstatus.TabIndex = 298
        Me.LblEstatus.Text = "_"
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(798, 42)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 297
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Enabled = False
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(742, 59)
        Me.dtpFechaVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(211, 20)
        Me.dtpFechaVencimiento.TabIndex = 16
        '
        'LblDisplayVencimiento
        '
        Me.LblDisplayVencimiento.AutoSize = True
        Me.LblDisplayVencimiento.Location = New System.Drawing.Point(665, 65)
        Me.LblDisplayVencimiento.Name = "LblDisplayVencimiento"
        Me.LblDisplayVencimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayVencimiento.TabIndex = 296
        Me.LblDisplayVencimiento.Text = "Vencimiento :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(636, 108)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayConcepto.TabIndex = 294
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(639, 123)
        Me.TxtConcepto.MaxLength = 1000
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConcepto.Size = New System.Drawing.Size(374, 82)
        Me.TxtConcepto.TabIndex = 13
        '
        'txtFolioProveedor
        '
        Me.txtFolioProveedor.Location = New System.Drawing.Point(419, 71)
        Me.txtFolioProveedor.MaxLength = 60
        Me.txtFolioProveedor.Name = "txtFolioProveedor"
        Me.txtFolioProveedor.Size = New System.Drawing.Size(224, 20)
        Me.txtFolioProveedor.TabIndex = 4
        '
        'lblDisplayFolioProveedor
        '
        Me.lblDisplayFolioProveedor.AutoSize = True
        Me.lblDisplayFolioProveedor.Location = New System.Drawing.Point(416, 55)
        Me.lblDisplayFolioProveedor.Name = "lblDisplayFolioProveedor"
        Me.lblDisplayFolioProveedor.Size = New System.Drawing.Size(62, 13)
        Me.lblDisplayFolioProveedor.TabIndex = 292
        Me.lblDisplayFolioProveedor.Text = "Folio prov. :"
        '
        'txtSolicito
        '
        Me.txtSolicito.Location = New System.Drawing.Point(80, 183)
        Me.txtSolicito.MaxLength = 80
        Me.txtSolicito.Name = "txtSolicito"
        Me.txtSolicito.Size = New System.Drawing.Size(233, 20)
        Me.txtSolicito.TabIndex = 9
        '
        'LblDisplaySolicito
        '
        Me.LblDisplaySolicito.AutoSize = True
        Me.LblDisplaySolicito.Location = New System.Drawing.Point(6, 186)
        Me.LblDisplaySolicito.Name = "LblDisplaySolicito"
        Me.LblDisplaySolicito.Size = New System.Drawing.Size(47, 13)
        Me.LblDisplaySolicito.TabIndex = 290
        Me.LblDisplaySolicito.Text = "Solicitó :"
        '
        'txtEntregarA
        '
        Me.txtEntregarA.Location = New System.Drawing.Point(80, 163)
        Me.txtEntregarA.MaxLength = 80
        Me.txtEntregarA.Name = "txtEntregarA"
        Me.txtEntregarA.Size = New System.Drawing.Size(233, 20)
        Me.txtEntregarA.TabIndex = 8
        '
        'LblDisplayEntregarA
        '
        Me.LblDisplayEntregarA.AutoSize = True
        Me.LblDisplayEntregarA.Location = New System.Drawing.Point(6, 166)
        Me.LblDisplayEntregarA.Name = "LblDisplayEntregarA"
        Me.LblDisplayEntregarA.Size = New System.Drawing.Size(62, 13)
        Me.LblDisplayEntregarA.TabIndex = 280
        Me.LblDisplayEntregarA.Text = "Entregar a :"
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(742, 39)
        Me.txtPlazo.MaxLength = 3
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(28, 20)
        Me.txtPlazo.TabIndex = 15
        Me.txtPlazo.Text = "0"
        Me.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayPlazo
        '
        Me.LblDisplayPlazo.AutoSize = True
        Me.LblDisplayPlazo.Location = New System.Drawing.Point(665, 42)
        Me.LblDisplayPlazo.Name = "LblDisplayPlazo"
        Me.LblDisplayPlazo.Size = New System.Drawing.Size(39, 13)
        Me.LblDisplayPlazo.TabIndex = 288
        Me.LblDisplayPlazo.Text = "Plazo :"
        '
        'txtFolioOC
        '
        Me.txtFolioOC.Location = New System.Drawing.Point(315, 71)
        Me.txtFolioOC.MaxLength = 15
        Me.txtFolioOC.Name = "txtFolioOC"
        Me.txtFolioOC.Size = New System.Drawing.Size(98, 20)
        Me.txtFolioOC.TabIndex = 3
        '
        'lblDisplayFolioOC
        '
        Me.lblDisplayFolioOC.AutoSize = True
        Me.lblDisplayFolioOC.Location = New System.Drawing.Point(256, 74)
        Me.lblDisplayFolioOC.Name = "lblDisplayFolioOC"
        Me.lblDisplayFolioOC.Size = New System.Drawing.Size(53, 13)
        Me.lblDisplayFolioOC.TabIndex = 286
        Me.lblDisplayFolioOC.Text = "Folio OC :"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(80, 97)
        Me.txtProveedor.MaxLength = 8
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(102, 20)
        Me.txtProveedor.TabIndex = 5
        Me.txtProveedor.Text = "  "
        '
        'LblDisplayProveedor
        '
        Me.LblDisplayProveedor.AutoSize = True
        Me.LblDisplayProveedor.Location = New System.Drawing.Point(6, 100)
        Me.LblDisplayProveedor.Name = "LblDisplayProveedor"
        Me.LblDisplayProveedor.Size = New System.Drawing.Size(62, 13)
        Me.LblDisplayProveedor.TabIndex = 283
        Me.LblDisplayProveedor.Text = "Proveedor :"
        '
        'DtpFecha
        '
        Me.DtpFecha.Location = New System.Drawing.Point(742, 19)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(211, 20)
        Me.DtpFecha.TabIndex = 14
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(665, 19)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblDisplayFecha.TabIndex = 281
        Me.LblDisplayFecha.Text = "Fecha :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(80, 44)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(211, 21)
        Me.CboAlmacen.TabIndex = 1
        '
        'LblDisplayAlmacen
        '
        Me.LblDisplayAlmacen.AutoSize = True
        Me.LblDisplayAlmacen.Location = New System.Drawing.Point(6, 47)
        Me.LblDisplayAlmacen.Name = "LblDisplayAlmacen"
        Me.LblDisplayAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.LblDisplayAlmacen.TabIndex = 279
        Me.LblDisplayAlmacen.Text = "Almacén :"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(6, 74)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 278
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(80, 19)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(211, 21)
        Me.CboDocumento.TabIndex = 0
        '
        'LblDisplayDocumento
        '
        Me.LblDisplayDocumento.AutoSize = True
        Me.LblDisplayDocumento.Location = New System.Drawing.Point(6, 22)
        Me.LblDisplayDocumento.Name = "LblDisplayDocumento"
        Me.LblDisplayDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayDocumento.TabIndex = 277
        Me.LblDisplayDocumento.Text = "Documento :"
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbAplicar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbSalir, Me.tsbPasarOrdenACompra, Me.tsbEditarCostos, Me.tsbAgregarXML, Me.tsbAgregarPDF})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1029, 27)
        Me.tsMenu.TabIndex = 3
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
        'tsbAplicar
        '
        Me.tsbAplicar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(68, 24)
        Me.tsbAplicar.Text = "&Aplicar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(77, 24)
        Me.tsbCancelar.Text = "&Cancelar"
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbPasarOrdenACompra
        '
        Me.tsbPasarOrdenACompra.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbPasarOrdenACompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPasarOrdenACompra.Name = "tsbPasarOrdenACompra"
        Me.tsbPasarOrdenACompra.Size = New System.Drawing.Size(112, 24)
        Me.tsbPasarOrdenACompra.Text = "&Pasar a compra"
        '
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(98, 24)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'tsbAgregarXML
        '
        Me.tsbAgregarXML.Image = Global.BsControl.My.Resources.Resources.xml1
        Me.tsbAgregarXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregarXML.Name = "tsbAgregarXML"
        Me.tsbAgregarXML.Size = New System.Drawing.Size(100, 24)
        Me.tsbAgregarXML.Text = "Agregar &XML"
        '
        'tsbAgregarPDF
        '
        Me.tsbAgregarPDF.Image = Global.BsControl.My.Resources.Resources.pdf11
        Me.tsbAgregarPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregarPDF.Name = "tsbAgregarPDF"
        Me.tsbAgregarPDF.Size = New System.Drawing.Size(97, 24)
        Me.tsbAgregarPDF.Text = "Agregar PD&F"
        '
        'txtSaldo_MXP
        '
        Me.txtSaldo_MXP.Location = New System.Drawing.Point(920, 534)
        Me.txtSaldo_MXP.Name = "txtSaldo_MXP"
        Me.txtSaldo_MXP.ReadOnly = True
        Me.txtSaldo_MXP.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldo_MXP.TabIndex = 19
        Me.txtSaldo_MXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldo_MXP
        '
        Me.lblDisplaySaldo_MXP.AutoSize = True
        Me.lblDisplaySaldo_MXP.Location = New System.Drawing.Point(856, 538)
        Me.lblDisplaySaldo_MXP.Name = "lblDisplaySaldo_MXP"
        Me.lblDisplaySaldo_MXP.Size = New System.Drawing.Size(66, 13)
        Me.lblDisplaySaldo_MXP.TabIndex = 313
        Me.lblDisplaySaldo_MXP.Text = "Saldo MXP :"
        '
        'lblDisplayRetenciones
        '
        Me.lblDisplayRetenciones.AutoSize = True
        Me.lblDisplayRetenciones.Location = New System.Drawing.Point(3, 105)
        Me.lblDisplayRetenciones.Name = "lblDisplayRetenciones"
        Me.lblDisplayRetenciones.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayRetenciones.TabIndex = 312
        Me.lblDisplayRetenciones.Text = "Reten."
        Me.lblDisplayRetenciones.Visible = False
        '
        'txtRetencionIVA
        '
        Me.txtRetencionIVA.Enabled = False
        Me.txtRetencionIVA.Location = New System.Drawing.Point(78, 101)
        Me.txtRetencionIVA.MaxLength = 15
        Me.txtRetencionIVA.Name = "txtRetencionIVA"
        Me.txtRetencionIVA.ReadOnly = True
        Me.txtRetencionIVA.Size = New System.Drawing.Size(54, 20)
        Me.txtRetencionIVA.TabIndex = 2
        Me.txtRetencionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionIVA.Visible = False
        '
        'lblDisplayTotal
        '
        Me.lblDisplayTotal.AutoSize = True
        Me.lblDisplayTotal.Location = New System.Drawing.Point(41, 82)
        Me.lblDisplayTotal.Name = "lblDisplayTotal"
        Me.lblDisplayTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayTotal.TabIndex = 309
        Me.lblDisplayTotal.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(84, 79)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(133, 20)
        Me.txtTotal.TabIndex = 18
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIVA
        '
        Me.lblDisplayIVA.AutoSize = True
        Me.lblDisplayIVA.Location = New System.Drawing.Point(48, 60)
        Me.lblDisplayIVA.Name = "lblDisplayIVA"
        Me.lblDisplayIVA.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayIVA.TabIndex = 307
        Me.lblDisplayIVA.Text = "IVA :"
        '
        'lblDisplaySubTotal
        '
        Me.lblDisplaySubTotal.AutoSize = True
        Me.lblDisplaySubTotal.Location = New System.Drawing.Point(22, 17)
        Me.lblDisplaySubTotal.Name = "lblDisplaySubTotal"
        Me.lblDisplaySubTotal.Size = New System.Drawing.Size(56, 13)
        Me.lblDisplaySubTotal.TabIndex = 305
        Me.lblDisplaySubTotal.Text = "SubTotal :"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Location = New System.Drawing.Point(84, 13)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.ReadOnly = True
        Me.TxtSubTotal.Size = New System.Drawing.Size(133, 20)
        Me.TxtSubTotal.TabIndex = 15
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 587)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1029, 24)
        Me.StatusStripEstado.TabIndex = 314
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
        'txtIVA
        '
        Me.txtIVA.Location = New System.Drawing.Point(84, 57)
        Me.txtIVA.MaxLength = 80
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(133, 20)
        Me.txtIVA.TabIndex = 330
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIVAcalculado
        '
        Me.lblIVAcalculado.AutoSize = True
        Me.lblIVAcalculado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVAcalculado.Location = New System.Drawing.Point(4, 60)
        Me.lblIVAcalculado.Name = "lblIVAcalculado"
        Me.lblIVAcalculado.Size = New System.Drawing.Size(15, 9)
        Me.lblIVAcalculado.TabIndex = 331
        Me.lblIVAcalculado.Text = "0.0"
        '
        'txtIVA_USD
        '
        Me.txtIVA_USD.Location = New System.Drawing.Point(83, 57)
        Me.txtIVA_USD.MaxLength = 80
        Me.txtIVA_USD.Name = "txtIVA_USD"
        Me.txtIVA_USD.Size = New System.Drawing.Size(133, 20)
        Me.txtIVA_USD.TabIndex = 337
        Me.txtIVA_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotal_USD
        '
        Me.lblDisplayTotal_USD.AutoSize = True
        Me.lblDisplayTotal_USD.Location = New System.Drawing.Point(41, 82)
        Me.lblDisplayTotal_USD.Name = "lblDisplayTotal_USD"
        Me.lblDisplayTotal_USD.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayTotal_USD.TabIndex = 336
        Me.lblDisplayTotal_USD.Text = "Total :"
        '
        'txtTotal_USD
        '
        Me.txtTotal_USD.Location = New System.Drawing.Point(83, 79)
        Me.txtTotal_USD.Name = "txtTotal_USD"
        Me.txtTotal_USD.ReadOnly = True
        Me.txtTotal_USD.Size = New System.Drawing.Size(133, 20)
        Me.txtTotal_USD.TabIndex = 333
        Me.txtTotal_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIVA_USD
        '
        Me.lblDisplayIVA_USD.AutoSize = True
        Me.lblDisplayIVA_USD.Location = New System.Drawing.Point(48, 60)
        Me.lblDisplayIVA_USD.Name = "lblDisplayIVA_USD"
        Me.lblDisplayIVA_USD.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayIVA_USD.TabIndex = 335
        Me.lblDisplayIVA_USD.Text = "IVA :"
        '
        'lblDisplaySubTotal_USD
        '
        Me.lblDisplaySubTotal_USD.AutoSize = True
        Me.lblDisplaySubTotal_USD.Location = New System.Drawing.Point(22, 16)
        Me.lblDisplaySubTotal_USD.Name = "lblDisplaySubTotal_USD"
        Me.lblDisplaySubTotal_USD.Size = New System.Drawing.Size(56, 13)
        Me.lblDisplaySubTotal_USD.TabIndex = 334
        Me.lblDisplaySubTotal_USD.Text = "SubTotal :"
        '
        'TxtSubTotal_USD
        '
        Me.TxtSubTotal_USD.Location = New System.Drawing.Point(83, 13)
        Me.TxtSubTotal_USD.Name = "TxtSubTotal_USD"
        Me.TxtSubTotal_USD.ReadOnly = True
        Me.TxtSubTotal_USD.Size = New System.Drawing.Size(133, 20)
        Me.TxtSubTotal_USD.TabIndex = 332
        Me.TxtSubTotal_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbUSD
        '
        Me.gbUSD.Controls.Add(Me.lblIVAcalculado_USD)
        Me.gbUSD.Controls.Add(Me.txtRetencionISR_USD)
        Me.gbUSD.Controls.Add(Me.lblDisplayRetencionISR_USD)
        Me.gbUSD.Controls.Add(Me.lblDisplayRetencionIVA_USD)
        Me.gbUSD.Controls.Add(Me.txtRetencionIVA_USD)
        Me.gbUSD.Controls.Add(Me.lblDisplayRetenciones_USD)
        Me.gbUSD.Controls.Add(Me.txtIEPS_USD)
        Me.gbUSD.Controls.Add(Me.lblDisplayIEPS_USD)
        Me.gbUSD.Controls.Add(Me.txtIVA_USD)
        Me.gbUSD.Controls.Add(Me.TxtSubTotal_USD)
        Me.gbUSD.Controls.Add(Me.lblDisplaySubTotal_USD)
        Me.gbUSD.Controls.Add(Me.lblDisplayIVA_USD)
        Me.gbUSD.Controls.Add(Me.lblDisplayTotal_USD)
        Me.gbUSD.Controls.Add(Me.txtTotal_USD)
        Me.gbUSD.Location = New System.Drawing.Point(375, 453)
        Me.gbUSD.Name = "gbUSD"
        Me.gbUSD.Size = New System.Drawing.Size(223, 126)
        Me.gbUSD.TabIndex = 340
        Me.gbUSD.TabStop = False
        Me.gbUSD.Text = "Totales USD :"
        Me.gbUSD.Visible = False
        '
        'lblIVAcalculado_USD
        '
        Me.lblIVAcalculado_USD.AutoSize = True
        Me.lblIVAcalculado_USD.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVAcalculado_USD.Location = New System.Drawing.Point(4, 60)
        Me.lblIVAcalculado_USD.Name = "lblIVAcalculado_USD"
        Me.lblIVAcalculado_USD.Size = New System.Drawing.Size(15, 9)
        Me.lblIVAcalculado_USD.TabIndex = 394
        Me.lblIVAcalculado_USD.Text = "0.0"
        '
        'txtRetencionISR_USD
        '
        Me.txtRetencionISR_USD.Enabled = False
        Me.txtRetencionISR_USD.Location = New System.Drawing.Point(162, 101)
        Me.txtRetencionISR_USD.MaxLength = 15
        Me.txtRetencionISR_USD.Name = "txtRetencionISR_USD"
        Me.txtRetencionISR_USD.ReadOnly = True
        Me.txtRetencionISR_USD.Size = New System.Drawing.Size(54, 20)
        Me.txtRetencionISR_USD.TabIndex = 392
        Me.txtRetencionISR_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionISR_USD.Visible = False
        '
        'lblDisplayRetencionISR_USD
        '
        Me.lblDisplayRetencionISR_USD.AutoSize = True
        Me.lblDisplayRetencionISR_USD.Location = New System.Drawing.Point(132, 104)
        Me.lblDisplayRetencionISR_USD.Name = "lblDisplayRetencionISR_USD"
        Me.lblDisplayRetencionISR_USD.Size = New System.Drawing.Size(31, 13)
        Me.lblDisplayRetencionISR_USD.TabIndex = 393
        Me.lblDisplayRetencionISR_USD.Text = "ISR :"
        Me.lblDisplayRetencionISR_USD.Visible = False
        '
        'lblDisplayRetencionIVA_USD
        '
        Me.lblDisplayRetencionIVA_USD.AutoSize = True
        Me.lblDisplayRetencionIVA_USD.Location = New System.Drawing.Point(48, 104)
        Me.lblDisplayRetencionIVA_USD.Name = "lblDisplayRetencionIVA_USD"
        Me.lblDisplayRetencionIVA_USD.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayRetencionIVA_USD.TabIndex = 391
        Me.lblDisplayRetencionIVA_USD.Text = "IVA :"
        Me.lblDisplayRetencionIVA_USD.Visible = False
        '
        'txtRetencionIVA_USD
        '
        Me.txtRetencionIVA_USD.Enabled = False
        Me.txtRetencionIVA_USD.Location = New System.Drawing.Point(78, 101)
        Me.txtRetencionIVA_USD.MaxLength = 15
        Me.txtRetencionIVA_USD.Name = "txtRetencionIVA_USD"
        Me.txtRetencionIVA_USD.ReadOnly = True
        Me.txtRetencionIVA_USD.Size = New System.Drawing.Size(54, 20)
        Me.txtRetencionIVA_USD.TabIndex = 389
        Me.txtRetencionIVA_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionIVA_USD.Visible = False
        '
        'lblDisplayRetenciones_USD
        '
        Me.lblDisplayRetenciones_USD.AutoSize = True
        Me.lblDisplayRetenciones_USD.Location = New System.Drawing.Point(3, 104)
        Me.lblDisplayRetenciones_USD.Name = "lblDisplayRetenciones_USD"
        Me.lblDisplayRetenciones_USD.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayRetenciones_USD.TabIndex = 390
        Me.lblDisplayRetenciones_USD.Text = "Reten."
        Me.lblDisplayRetenciones_USD.Visible = False
        '
        'txtIEPS_USD
        '
        Me.txtIEPS_USD.Location = New System.Drawing.Point(83, 35)
        Me.txtIEPS_USD.MaxLength = 80
        Me.txtIEPS_USD.Name = "txtIEPS_USD"
        Me.txtIEPS_USD.ReadOnly = True
        Me.txtIEPS_USD.Size = New System.Drawing.Size(133, 20)
        Me.txtIEPS_USD.TabIndex = 387
        Me.txtIEPS_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIEPS_USD
        '
        Me.lblDisplayIEPS_USD.AutoSize = True
        Me.lblDisplayIEPS_USD.Location = New System.Drawing.Point(41, 36)
        Me.lblDisplayIEPS_USD.Name = "lblDisplayIEPS_USD"
        Me.lblDisplayIEPS_USD.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayIEPS_USD.TabIndex = 386
        Me.lblDisplayIEPS_USD.Text = "IEPS :"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpArticulos)
        Me.TabControl1.Controls.Add(Me.tpSeries)
        Me.TabControl1.Location = New System.Drawing.Point(1, 245)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1019, 204)
        Me.TabControl1.TabIndex = 1
        '
        'tpArticulos
        '
        Me.tpArticulos.Controls.Add(Me.Grid)
        Me.tpArticulos.Location = New System.Drawing.Point(4, 22)
        Me.tpArticulos.Name = "tpArticulos"
        Me.tpArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpArticulos.Size = New System.Drawing.Size(1011, 178)
        Me.tpArticulos.TabIndex = 0
        Me.tpArticulos.Text = "Artículos"
        Me.tpArticulos.UseVisualStyleBackColor = True
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
        Me.Grid.Location = New System.Drawing.Point(1, 6)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 6
        Me.Grid.Size = New System.Drawing.Size(998, 166)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpSeries
        '
        Me.tpSeries.Controls.Add(Me.lblDisplayLote)
        Me.tpSeries.Controls.Add(Me.btnCopiarLote)
        Me.tpSeries.Controls.Add(Me.txtLote)
        Me.tpSeries.Controls.Add(Me.GridSeries)
        Me.tpSeries.Location = New System.Drawing.Point(4, 22)
        Me.tpSeries.Name = "tpSeries"
        Me.tpSeries.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSeries.Size = New System.Drawing.Size(1011, 178)
        Me.tpSeries.TabIndex = 1
        Me.tpSeries.Text = "Series"
        Me.tpSeries.UseVisualStyleBackColor = True
        '
        'lblDisplayLote
        '
        Me.lblDisplayLote.AutoSize = True
        Me.lblDisplayLote.Location = New System.Drawing.Point(325, 158)
        Me.lblDisplayLote.Name = "lblDisplayLote"
        Me.lblDisplayLote.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayLote.TabIndex = 331
        Me.lblDisplayLote.Text = "Lote :"
        '
        'btnCopiarLote
        '
        Me.btnCopiarLote.Location = New System.Drawing.Point(497, 154)
        Me.btnCopiarLote.Name = "btnCopiarLote"
        Me.btnCopiarLote.Size = New System.Drawing.Size(109, 21)
        Me.btnCopiarLote.TabIndex = 330
        Me.btnCopiarLote.Text = "Copiar"
        Me.btnCopiarLote.UseVisualStyleBackColor = True
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(384, 156)
        Me.txtLote.MaxLength = 80
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(107, 20)
        Me.txtLote.TabIndex = 10
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
        Me.GridSeries.Location = New System.Drawing.Point(3, 6)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(999, 149)
        Me.GridSeries.TabIndex = 1
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnSeries
        '
        Me.btnSeries.Enabled = False
        Me.btnSeries.Location = New System.Drawing.Point(204, 469)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(165, 32)
        Me.btnSeries.TabIndex = 380
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        '
        'txtSaldo_USD
        '
        Me.txtSaldo_USD.Location = New System.Drawing.Point(920, 557)
        Me.txtSaldo_USD.Name = "txtSaldo_USD"
        Me.txtSaldo_USD.ReadOnly = True
        Me.txtSaldo_USD.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldo_USD.TabIndex = 381
        Me.txtSaldo_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldo_USD
        '
        Me.lblDisplaySaldo_USD.AutoSize = True
        Me.lblDisplaySaldo_USD.Location = New System.Drawing.Point(856, 559)
        Me.lblDisplaySaldo_USD.Name = "lblDisplaySaldo_USD"
        Me.lblDisplaySaldo_USD.Size = New System.Drawing.Size(66, 13)
        Me.lblDisplaySaldo_USD.TabIndex = 382
        Me.lblDisplaySaldo_USD.Text = "Saldo USD :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSeleccionarArchivoSeries
        '
        Me.btnSeleccionarArchivoSeries.Enabled = False
        Me.btnSeleccionarArchivoSeries.Location = New System.Drawing.Point(204, 507)
        Me.btnSeleccionarArchivoSeries.Name = "btnSeleccionarArchivoSeries"
        Me.btnSeleccionarArchivoSeries.Size = New System.Drawing.Size(165, 32)
        Me.btnSeleccionarArchivoSeries.TabIndex = 383
        Me.btnSeleccionarArchivoSeries.Text = "Seleccionar archivo con series"
        Me.btnSeleccionarArchivoSeries.UseVisualStyleBackColor = True
        '
        'txtIEPS
        '
        Me.txtIEPS.Location = New System.Drawing.Point(84, 35)
        Me.txtIEPS.MaxLength = 80
        Me.txtIEPS.Name = "txtIEPS"
        Me.txtIEPS.ReadOnly = True
        Me.txtIEPS.Size = New System.Drawing.Size(133, 20)
        Me.txtIEPS.TabIndex = 385
        Me.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIEPS
        '
        Me.lblDisplayIEPS.AutoSize = True
        Me.lblDisplayIEPS.Location = New System.Drawing.Point(41, 38)
        Me.lblDisplayIEPS.Name = "lblDisplayIEPS"
        Me.lblDisplayIEPS.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayIEPS.TabIndex = 384
        Me.lblDisplayIEPS.Text = "IEPS :"
        '
        'TxtConceptoCancelacion
        '
        Me.TxtConceptoCancelacion.Location = New System.Drawing.Point(4, 470)
        Me.TxtConceptoCancelacion.MaxLength = 1000
        Me.TxtConceptoCancelacion.Multiline = True
        Me.TxtConceptoCancelacion.Name = "TxtConceptoCancelacion"
        Me.TxtConceptoCancelacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConceptoCancelacion.Size = New System.Drawing.Size(194, 68)
        Me.TxtConceptoCancelacion.TabIndex = 386
        Me.TxtConceptoCancelacion.Visible = False
        '
        'LblConceptoCancelacion
        '
        Me.LblConceptoCancelacion.AutoSize = True
        Me.LblConceptoCancelacion.Location = New System.Drawing.Point(2, 452)
        Me.LblConceptoCancelacion.Name = "LblConceptoCancelacion"
        Me.LblConceptoCancelacion.Size = New System.Drawing.Size(120, 13)
        Me.LblConceptoCancelacion.TabIndex = 387
        Me.LblConceptoCancelacion.Text = "Concepto cancelación :"
        Me.LblConceptoCancelacion.Visible = False
        '
        'gbMXN
        '
        Me.gbMXN.Controls.Add(Me.txtRetencionISR)
        Me.gbMXN.Controls.Add(Me.lblDisplayRetencionISR)
        Me.gbMXN.Controls.Add(Me.lblDisplayRetencionIVA)
        Me.gbMXN.Controls.Add(Me.lblDisplaySubTotal)
        Me.gbMXN.Controls.Add(Me.TxtSubTotal)
        Me.gbMXN.Controls.Add(Me.lblDisplayIVA)
        Me.gbMXN.Controls.Add(Me.txtIEPS)
        Me.gbMXN.Controls.Add(Me.lblDisplayIEPS)
        Me.gbMXN.Controls.Add(Me.txtTotal)
        Me.gbMXN.Controls.Add(Me.lblIVAcalculado)
        Me.gbMXN.Controls.Add(Me.lblDisplayTotal)
        Me.gbMXN.Controls.Add(Me.txtRetencionIVA)
        Me.gbMXN.Controls.Add(Me.lblDisplayRetenciones)
        Me.gbMXN.Controls.Add(Me.txtIVA)
        Me.gbMXN.Location = New System.Drawing.Point(615, 453)
        Me.gbMXN.Name = "gbMXN"
        Me.gbMXN.Size = New System.Drawing.Size(223, 126)
        Me.gbMXN.TabIndex = 388
        Me.gbMXN.TabStop = False
        Me.gbMXN.Text = "Totales MXN :"
        '
        'txtRetencionISR
        '
        Me.txtRetencionISR.Enabled = False
        Me.txtRetencionISR.Location = New System.Drawing.Point(163, 101)
        Me.txtRetencionISR.MaxLength = 15
        Me.txtRetencionISR.Name = "txtRetencionISR"
        Me.txtRetencionISR.ReadOnly = True
        Me.txtRetencionISR.Size = New System.Drawing.Size(54, 20)
        Me.txtRetencionISR.TabIndex = 387
        Me.txtRetencionISR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionISR.Visible = False
        '
        'lblDisplayRetencionISR
        '
        Me.lblDisplayRetencionISR.AutoSize = True
        Me.lblDisplayRetencionISR.Location = New System.Drawing.Point(132, 105)
        Me.lblDisplayRetencionISR.Name = "lblDisplayRetencionISR"
        Me.lblDisplayRetencionISR.Size = New System.Drawing.Size(31, 13)
        Me.lblDisplayRetencionISR.TabIndex = 388
        Me.lblDisplayRetencionISR.Text = "ISR :"
        Me.lblDisplayRetencionISR.Visible = False
        '
        'lblDisplayRetencionIVA
        '
        Me.lblDisplayRetencionIVA.AutoSize = True
        Me.lblDisplayRetencionIVA.Location = New System.Drawing.Point(48, 105)
        Me.lblDisplayRetencionIVA.Name = "lblDisplayRetencionIVA"
        Me.lblDisplayRetencionIVA.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayRetencionIVA.TabIndex = 386
        Me.lblDisplayRetencionIVA.Text = "IVA :"
        Me.lblDisplayRetencionIVA.Visible = False
        '
        'Compras_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 611)
        Me.Controls.Add(Me.gbMXN)
        Me.Controls.Add(Me.LblConceptoCancelacion)
        Me.Controls.Add(Me.TxtConceptoCancelacion)
        Me.Controls.Add(Me.btnSeleccionarArchivoSeries)
        Me.Controls.Add(Me.txtSaldo_USD)
        Me.Controls.Add(Me.btnSeries)
        Me.Controls.Add(Me.lblDisplaySaldo_USD)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbUSD)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.txtSaldo_MXP)
        Me.Controls.Add(Me.lblDisplaySaldo_MXP)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Compras_Movimientos"
        Me.Text = "Compras"
        Me.gbGlobal.ResumeLayout(False)
        Me.gbGlobal.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbUSD.ResumeLayout(False)
        Me.gbUSD.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpArticulos.ResumeLayout(False)
        Me.tpSeries.ResumeLayout(False)
        Me.tpSeries.PerformLayout()
        Me.gbMXN.ResumeLayout(False)
        Me.gbMXN.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbGlobal As System.Windows.Forms.GroupBox
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayAlmacen As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayDocumento As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayProveedor As System.Windows.Forms.Label
    Friend WithEvents txtFolioOC As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioOC As System.Windows.Forms.Label
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayPlazo As System.Windows.Forms.Label
    Friend WithEvents txtEntregarA As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayEntregarA As System.Windows.Forms.Label
    Friend WithEvents LblDisplaySolicito As System.Windows.Forms.Label
    Friend WithEvents txtFolioProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioProveedor As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayVencimiento As System.Windows.Forms.Label
    Friend WithEvents LblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblDilplayPoliza As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents txtSaldo_MXP As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySaldo_MXP As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRetenciones As System.Windows.Forms.Label
    Friend WithEvents txtRetencionIVA As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDisplayIVA As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySubTotal As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LblDisplayTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtFolioCompra As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDisplayConfirmo As System.Windows.Forms.Label
    Friend WithEvents txtPredio As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayPredio As System.Windows.Forms.Label
    Friend WithEvents txtConCargoA As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayConCargoA As System.Windows.Forms.Label
    Friend WithEvents DtpFechaFacturaProveedor As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayFechaFacturaProveedor As System.Windows.Forms.Label
    Friend WithEvents LblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnActualizaFolioProv As System.Windows.Forms.Button
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents lblIVAcalculado As System.Windows.Forms.Label
    Friend WithEvents txtIVA_USD As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTotal_USD As System.Windows.Forms.Label
    Friend WithEvents txtTotal_USD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDisplayIVA_USD As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySubTotal_USD As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal_USD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents gbUSD As System.Windows.Forms.GroupBox
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents tsbPasarOrdenACompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditarCostos As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizaConcepto As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpArticulos As System.Windows.Forms.TabPage
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents tpSeries As System.Windows.Forms.TabPage
    Friend WithEvents GridSeries As FlexCell.Grid
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents btnSeries As System.Windows.Forms.Button
    Friend WithEvents txtSaldo_USD As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySaldo_USD As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSeleccionarArchivoSeries As System.Windows.Forms.Button
    Friend WithEvents txtIEPS As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayIEPS As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayMoneda As System.Windows.Forms.Label
    Friend WithEvents TxtConceptoCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents LblConceptoCancelacion As System.Windows.Forms.Label
    Friend WithEvents lblDisplayLote As Label
    Friend WithEvents btnCopiarLote As Button
    Friend WithEvents txtLote As TextBox
    Friend WithEvents tsbAgregarPDF As ToolStripButton
    Friend WithEvents tsbAgregarXML As ToolStripButton
    Friend WithEvents lblDisplayFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbMXN As GroupBox
    Friend WithEvents txtRetencionISR As TextBox
    Friend WithEvents lblDisplayRetencionISR As Label
    Friend WithEvents lblDisplayRetencionIVA As Label
    Friend WithEvents txtConfirmo As TextBox
    Friend WithEvents txtSolicito As TextBox
    Friend WithEvents txtIEPS_USD As TextBox
    Friend WithEvents lblDisplayIEPS_USD As Label
    Friend WithEvents txtRetencionISR_USD As TextBox
    Friend WithEvents lblDisplayRetencionISR_USD As Label
    Friend WithEvents lblDisplayRetencionIVA_USD As Label
    Friend WithEvents txtRetencionIVA_USD As TextBox
    Friend WithEvents lblDisplayRetenciones_USD As Label
    Friend WithEvents lblIVAcalculado_USD As Label
End Class
