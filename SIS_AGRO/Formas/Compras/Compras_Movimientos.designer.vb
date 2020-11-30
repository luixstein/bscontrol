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
        Me.LblDisplayTransporte = New System.Windows.Forms.Label()
        Me.LblDisplayTipoEnvio = New System.Windows.Forms.Label()
        Me.TxtNombreTransporte = New System.Windows.Forms.TextBox()
        Me.CboTipoEnvio = New System.Windows.Forms.ComboBox()
        Me.btnTraerDetalleRequisicion = New System.Windows.Forms.Button()
        Me.LblRequisicion = New System.Windows.Forms.Label()
        Me.TxtRequisicion = New System.Windows.Forms.TextBox()
        Me.chkEsFiscal = New System.Windows.Forms.CheckBox()
        Me.chkEsInventariable = New System.Windows.Forms.CheckBox()
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
        Me.tsbPedir = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditarOC = New System.Windows.Forms.ToolStripButton()
        Me.tsbRecepcionarEntrada = New System.Windows.Forms.ToolStripButton()
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
        Me.tpEntradas = New System.Windows.Forms.TabPage()
        Me.gbEntradas = New System.Windows.Forms.GroupBox()
        Me.GridEntradas = New FlexCell.Grid()
        Me.btnBorrarTodasEntradasInventarios = New System.Windows.Forms.Button()
        Me.txtFolioOC_Inventarios = New System.Windows.Forms.TextBox()
        Me.btnTraerTodasEntradasInventarios = New System.Windows.Forms.Button()
        Me.lblDisplayFolioOC_Inventarios = New System.Windows.Forms.Label()
        Me.btnAgregarSeleccionadaEntradasInventarios = New System.Windows.Forms.Button()
        Me.lstEntradasInventarios = New System.Windows.Forms.ListBox()
        Me.btnAgregarTodasEntradasInventarios = New System.Windows.Forms.Button()
        Me.lblDisplayEntradasInventarios = New System.Windows.Forms.Label()
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
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.btnMultiplesRequisiciones = New System.Windows.Forms.Button()
        Me.gbGlobal.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbUSD.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpArticulos.SuspendLayout()
        Me.tpSeries.SuspendLayout()
        Me.tpEntradas.SuspendLayout()
        Me.gbEntradas.SuspendLayout()
        Me.gbMXN.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.btnMultiplesRequisiciones)
        Me.gbGlobal.Controls.Add(Me.LblDisplayTransporte)
        Me.gbGlobal.Controls.Add(Me.LblDisplayTipoEnvio)
        Me.gbGlobal.Controls.Add(Me.TxtNombreTransporte)
        Me.gbGlobal.Controls.Add(Me.CboTipoEnvio)
        Me.gbGlobal.Controls.Add(Me.btnTraerDetalleRequisicion)
        Me.gbGlobal.Controls.Add(Me.LblRequisicion)
        Me.gbGlobal.Controls.Add(Me.TxtRequisicion)
        Me.gbGlobal.Controls.Add(Me.chkEsFiscal)
        Me.gbGlobal.Controls.Add(Me.chkEsInventariable)
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
        Me.gbGlobal.Location = New System.Drawing.Point(1, 34)
        Me.gbGlobal.Margin = New System.Windows.Forms.Padding(4)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Padding = New System.Windows.Forms.Padding(4)
        Me.gbGlobal.Size = New System.Drawing.Size(1359, 260)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        '
        'LblDisplayTransporte
        '
        Me.LblDisplayTransporte.AutoSize = True
        Me.LblDisplayTransporte.Location = New System.Drawing.Point(461, 92)
        Me.LblDisplayTransporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTransporte.Name = "LblDisplayTransporte"
        Me.LblDisplayTransporte.Size = New System.Drawing.Size(86, 17)
        Me.LblDisplayTransporte.TabIndex = 392
        Me.LblDisplayTransporte.Text = "Transporte :"
        '
        'LblDisplayTipoEnvio
        '
        Me.LblDisplayTipoEnvio.AutoSize = True
        Me.LblDisplayTipoEnvio.Location = New System.Drawing.Point(468, 61)
        Me.LblDisplayTipoEnvio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTipoEnvio.Name = "LblDisplayTipoEnvio"
        Me.LblDisplayTipoEnvio.Size = New System.Drawing.Size(82, 17)
        Me.LblDisplayTipoEnvio.TabIndex = 391
        Me.LblDisplayTipoEnvio.Text = "Tipo envio :"
        '
        'TxtNombreTransporte
        '
        Me.TxtNombreTransporte.Location = New System.Drawing.Point(566, 91)
        Me.TxtNombreTransporte.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreTransporte.MaxLength = 200
        Me.TxtNombreTransporte.Name = "TxtNombreTransporte"
        Me.TxtNombreTransporte.Size = New System.Drawing.Size(301, 22)
        Me.TxtNombreTransporte.TabIndex = 392
        '
        'CboTipoEnvio
        '
        Me.CboTipoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoEnvio.FormattingEnabled = True
        Me.CboTipoEnvio.Location = New System.Drawing.Point(566, 58)
        Me.CboTipoEnvio.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoEnvio.Name = "CboTipoEnvio"
        Me.CboTipoEnvio.Size = New System.Drawing.Size(188, 24)
        Me.CboTipoEnvio.TabIndex = 390
        '
        'btnTraerDetalleRequisicion
        '
        Me.btnTraerDetalleRequisicion.Location = New System.Drawing.Point(610, 20)
        Me.btnTraerDetalleRequisicion.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTraerDetalleRequisicion.Name = "btnTraerDetalleRequisicion"
        Me.btnTraerDetalleRequisicion.Size = New System.Drawing.Size(101, 28)
        Me.btnTraerDetalleRequisicion.TabIndex = 389
        Me.btnTraerDetalleRequisicion.Text = "Traer detalle"
        Me.btnTraerDetalleRequisicion.UseVisualStyleBackColor = True
        '
        'LblRequisicion
        '
        Me.LblRequisicion.AutoSize = True
        Me.LblRequisicion.Location = New System.Drawing.Point(412, 27)
        Me.LblRequisicion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRequisicion.Name = "LblRequisicion"
        Me.LblRequisicion.Size = New System.Drawing.Size(89, 17)
        Me.LblRequisicion.TabIndex = 388
        Me.LblRequisicion.Text = "Requisición :"
        '
        'TxtRequisicion
        '
        Me.TxtRequisicion.Location = New System.Drawing.Point(510, 24)
        Me.TxtRequisicion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRequisicion.MaxLength = 15
        Me.TxtRequisicion.Name = "TxtRequisicion"
        Me.TxtRequisicion.Size = New System.Drawing.Size(92, 22)
        Me.TxtRequisicion.TabIndex = 387
        '
        'chkEsFiscal
        '
        Me.chkEsFiscal.AutoSize = True
        Me.chkEsFiscal.Enabled = False
        Me.chkEsFiscal.Location = New System.Drawing.Point(261, 180)
        Me.chkEsFiscal.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEsFiscal.Name = "chkEsFiscal"
        Me.chkEsFiscal.Size = New System.Drawing.Size(94, 21)
        Me.chkEsFiscal.TabIndex = 386
        Me.chkEsFiscal.Text = "Es fiscal ?"
        Me.chkEsFiscal.UseVisualStyleBackColor = True
        '
        'chkEsInventariable
        '
        Me.chkEsInventariable.AutoSize = True
        Me.chkEsInventariable.Location = New System.Drawing.Point(107, 180)
        Me.chkEsInventariable.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEsInventariable.Name = "chkEsInventariable"
        Me.chkEsInventariable.Size = New System.Drawing.Size(143, 21)
        Me.chkEsInventariable.TabIndex = 385
        Me.chkEsInventariable.Text = "Es inventariable ?"
        Me.chkEsInventariable.UseVisualStyleBackColor = True
        '
        'lblDisplayFechaEntrega
        '
        Me.lblDisplayFechaEntrega.AutoSize = True
        Me.lblDisplayFechaEntrega.Location = New System.Drawing.Point(875, 105)
        Me.lblDisplayFechaEntrega.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaEntrega.Name = "lblDisplayFechaEntrega"
        Me.lblDisplayFechaEntrega.Size = New System.Drawing.Size(108, 17)
        Me.lblDisplayFechaEntrega.TabIndex = 384
        Me.lblDisplayFechaEntrega.Text = "Fecha entrega :"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Enabled = False
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(989, 101)
        Me.dtpFechaEntrega.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaEntrega.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(280, 22)
        Me.dtpFechaEntrega.TabIndex = 383
        '
        'LblDisplayMoneda
        '
        Me.LblDisplayMoneda.AutoSize = True
        Me.LblDisplayMoneda.Location = New System.Drawing.Point(8, 155)
        Me.LblDisplayMoneda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayMoneda.Name = "LblDisplayMoneda"
        Me.LblDisplayMoneda.Size = New System.Drawing.Size(67, 17)
        Me.LblDisplayMoneda.TabIndex = 382
        Me.LblDisplayMoneda.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(107, 153)
        Me.cboMoneda.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(103, 24)
        Me.cboMoneda.TabIndex = 381
        '
        'lblProveedor
        '
        Me.lblProveedor.Location = New System.Drawing.Point(251, 123)
        Me.lblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(589, 16)
        Me.lblProveedor.TabIndex = 380
        Me.lblProveedor.Text = "_"
        '
        'btnActualizaConcepto
        '
        Me.btnActualizaConcepto.Location = New System.Drawing.Point(1205, 126)
        Me.btnActualizaConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnActualizaConcepto.Name = "btnActualizaConcepto"
        Me.btnActualizaConcepto.Size = New System.Drawing.Size(144, 26)
        Me.btnActualizaConcepto.TabIndex = 379
        Me.btnActualizaConcepto.Text = "Actualiza concepto"
        Me.btnActualizaConcepto.UseVisualStyleBackColor = True
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(292, 86)
        Me.btnDocumentoSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoSiguiente.TabIndex = 378
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(251, 86)
        Me.btnDocumentoAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoAnterior.TabIndex = 377
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'BtnActualizaFolioProv
        '
        Me.BtnActualizaFolioProv.Location = New System.Drawing.Point(712, 54)
        Me.BtnActualizaFolioProv.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnActualizaFolioProv.Name = "BtnActualizaFolioProv"
        Me.BtnActualizaFolioProv.Size = New System.Drawing.Size(145, 26)
        Me.BtnActualizaFolioProv.TabIndex = 329
        Me.BtnActualizaFolioProv.Text = "Actualiza folio prov"
        Me.BtnActualizaFolioProv.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(704, 20)
        Me.LblPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(16, 17)
        Me.LblPoliza.TabIndex = 328
        Me.LblPoliza.TabStop = True
        Me.LblPoliza.Text = "_"
        '
        'DtpFechaFacturaProveedor
        '
        Me.DtpFechaFacturaProveedor.Location = New System.Drawing.Point(559, 151)
        Me.DtpFechaFacturaProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpFechaFacturaProveedor.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFechaFacturaProveedor.Name = "DtpFechaFacturaProveedor"
        Me.DtpFechaFacturaProveedor.Size = New System.Drawing.Size(280, 22)
        Me.DtpFechaFacturaProveedor.TabIndex = 326
        '
        'lblDisplayFechaFacturaProveedor
        '
        Me.lblDisplayFechaFacturaProveedor.AutoSize = True
        Me.lblDisplayFechaFacturaProveedor.Location = New System.Drawing.Point(431, 155)
        Me.lblDisplayFechaFacturaProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaFacturaProveedor.Name = "lblDisplayFechaFacturaProveedor"
        Me.lblDisplayFechaFacturaProveedor.Size = New System.Drawing.Size(116, 17)
        Me.lblDisplayFechaFacturaProveedor.TabIndex = 327
        Me.lblDisplayFechaFacturaProveedor.Text = "Fac. proveedor  :"
        '
        'txtConfirmo
        '
        Me.txtConfirmo.Location = New System.Drawing.Point(559, 225)
        Me.txtConfirmo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConfirmo.MaxLength = 80
        Me.txtConfirmo.Name = "txtConfirmo"
        Me.txtConfirmo.Size = New System.Drawing.Size(280, 22)
        Me.txtConfirmo.TabIndex = 12
        '
        'lblDisplayConfirmo
        '
        Me.lblDisplayConfirmo.AutoSize = True
        Me.lblDisplayConfirmo.Location = New System.Drawing.Point(431, 229)
        Me.lblDisplayConfirmo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayConfirmo.Name = "lblDisplayConfirmo"
        Me.lblDisplayConfirmo.Size = New System.Drawing.Size(72, 17)
        Me.lblDisplayConfirmo.TabIndex = 325
        Me.lblDisplayConfirmo.Text = "Confirmó :"
        '
        'txtPredio
        '
        Me.txtPredio.Location = New System.Drawing.Point(559, 201)
        Me.txtPredio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPredio.MaxLength = 80
        Me.txtPredio.Name = "txtPredio"
        Me.txtPredio.Size = New System.Drawing.Size(280, 22)
        Me.txtPredio.TabIndex = 11
        '
        'lblDisplayPredio
        '
        Me.lblDisplayPredio.AutoSize = True
        Me.lblDisplayPredio.Location = New System.Drawing.Point(431, 204)
        Me.lblDisplayPredio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPredio.Name = "lblDisplayPredio"
        Me.lblDisplayPredio.Size = New System.Drawing.Size(57, 17)
        Me.lblDisplayPredio.TabIndex = 321
        Me.lblDisplayPredio.Text = "Predio :"
        '
        'txtConCargoA
        '
        Me.txtConCargoA.Location = New System.Drawing.Point(559, 176)
        Me.txtConCargoA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConCargoA.MaxLength = 80
        Me.txtConCargoA.Name = "txtConCargoA"
        Me.txtConCargoA.Size = New System.Drawing.Size(280, 22)
        Me.txtConCargoA.TabIndex = 10
        '
        'lblDisplayConCargoA
        '
        Me.lblDisplayConCargoA.AutoSize = True
        Me.lblDisplayConCargoA.Location = New System.Drawing.Point(431, 180)
        Me.lblDisplayConCargoA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayConCargoA.Name = "lblDisplayConCargoA"
        Me.lblDisplayConCargoA.Size = New System.Drawing.Size(93, 17)
        Me.lblDisplayConCargoA.TabIndex = 320
        Me.lblDisplayConCargoA.Text = "Con cargo a :"
        '
        'txtFolioCompra
        '
        Me.txtFolioCompra.Location = New System.Drawing.Point(107, 87)
        Me.txtFolioCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioCompra.MaxLength = 15
        Me.txtFolioCompra.Name = "txtFolioCompra"
        Me.txtFolioCompra.Size = New System.Drawing.Size(135, 22)
        Me.txtFolioCompra.TabIndex = 2
        '
        'LblDisplayTipoCambio
        '
        Me.LblDisplayTipoCambio.AutoSize = True
        Me.LblDisplayTipoCambio.Location = New System.Drawing.Point(217, 155)
        Me.LblDisplayTipoCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTipoCambio.Name = "LblDisplayTipoCambio"
        Me.LblDisplayTipoCambio.Size = New System.Drawing.Size(113, 17)
        Me.LblDisplayTipoCambio.TabIndex = 317
        Me.LblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(335, 151)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(81, 22)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDilplayPoliza
        '
        Me.lblDilplayPoliza.AutoSize = True
        Me.lblDilplayPoliza.Location = New System.Drawing.Point(605, 20)
        Me.lblDilplayPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDilplayPoliza.Name = "lblDilplayPoliza"
        Me.lblDilplayPoliza.Size = New System.Drawing.Size(54, 17)
        Me.lblDilplayPoliza.TabIndex = 299
        Me.lblDilplayPoliza.Text = "Póliza :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(1116, 52)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(16, 17)
        Me.LblEstatus.TabIndex = 298
        Me.LblEstatus.Text = "_"
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(1044, 52)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 297
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Enabled = False
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(989, 73)
        Me.dtpFechaVencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(280, 22)
        Me.dtpFechaVencimiento.TabIndex = 16
        '
        'LblDisplayVencimiento
        '
        Me.LblDisplayVencimiento.AutoSize = True
        Me.LblDisplayVencimiento.Location = New System.Drawing.Point(889, 80)
        Me.LblDisplayVencimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayVencimiento.Name = "LblDisplayVencimiento"
        Me.LblDisplayVencimiento.Size = New System.Drawing.Size(93, 17)
        Me.LblDisplayVencimiento.TabIndex = 296
        Me.LblDisplayVencimiento.Text = "Vencimiento :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(852, 133)
        Me.LblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayConcepto.TabIndex = 294
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(852, 151)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 1000
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConcepto.Size = New System.Drawing.Size(497, 100)
        Me.TxtConcepto.TabIndex = 13
        '
        'txtFolioProveedor
        '
        Me.txtFolioProveedor.Location = New System.Drawing.Point(559, 87)
        Me.txtFolioProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioProveedor.MaxLength = 60
        Me.txtFolioProveedor.Name = "txtFolioProveedor"
        Me.txtFolioProveedor.Size = New System.Drawing.Size(297, 22)
        Me.txtFolioProveedor.TabIndex = 4
        '
        'lblDisplayFolioProveedor
        '
        Me.lblDisplayFolioProveedor.AutoSize = True
        Me.lblDisplayFolioProveedor.Location = New System.Drawing.Point(555, 68)
        Me.lblDisplayFolioProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioProveedor.Name = "lblDisplayFolioProveedor"
        Me.lblDisplayFolioProveedor.Size = New System.Drawing.Size(82, 17)
        Me.lblDisplayFolioProveedor.TabIndex = 292
        Me.lblDisplayFolioProveedor.Text = "Folio prov. :"
        '
        'txtSolicito
        '
        Me.txtSolicito.Location = New System.Drawing.Point(107, 225)
        Me.txtSolicito.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSolicito.MaxLength = 80
        Me.txtSolicito.Name = "txtSolicito"
        Me.txtSolicito.Size = New System.Drawing.Size(309, 22)
        Me.txtSolicito.TabIndex = 9
        '
        'LblDisplaySolicito
        '
        Me.LblDisplaySolicito.AutoSize = True
        Me.LblDisplaySolicito.Location = New System.Drawing.Point(8, 229)
        Me.LblDisplaySolicito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplaySolicito.Name = "LblDisplaySolicito"
        Me.LblDisplaySolicito.Size = New System.Drawing.Size(61, 17)
        Me.LblDisplaySolicito.TabIndex = 290
        Me.LblDisplaySolicito.Text = "Solicitó :"
        '
        'txtEntregarA
        '
        Me.txtEntregarA.Location = New System.Drawing.Point(107, 201)
        Me.txtEntregarA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEntregarA.MaxLength = 80
        Me.txtEntregarA.Name = "txtEntregarA"
        Me.txtEntregarA.Size = New System.Drawing.Size(309, 22)
        Me.txtEntregarA.TabIndex = 8
        '
        'LblDisplayEntregarA
        '
        Me.LblDisplayEntregarA.AutoSize = True
        Me.LblDisplayEntregarA.Location = New System.Drawing.Point(8, 204)
        Me.LblDisplayEntregarA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayEntregarA.Name = "LblDisplayEntregarA"
        Me.LblDisplayEntregarA.Size = New System.Drawing.Size(83, 17)
        Me.LblDisplayEntregarA.TabIndex = 280
        Me.LblDisplayEntregarA.Text = "Entregar a :"
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(989, 48)
        Me.txtPlazo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlazo.MaxLength = 3
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(36, 22)
        Me.txtPlazo.TabIndex = 15
        Me.txtPlazo.Text = "0"
        Me.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayPlazo
        '
        Me.LblDisplayPlazo.AutoSize = True
        Me.LblDisplayPlazo.Location = New System.Drawing.Point(932, 52)
        Me.LblDisplayPlazo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayPlazo.Name = "LblDisplayPlazo"
        Me.LblDisplayPlazo.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayPlazo.TabIndex = 288
        Me.LblDisplayPlazo.Text = "Plazo :"
        '
        'txtFolioOC
        '
        Me.txtFolioOC.Location = New System.Drawing.Point(420, 87)
        Me.txtFolioOC.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioOC.MaxLength = 15
        Me.txtFolioOC.Name = "txtFolioOC"
        Me.txtFolioOC.Size = New System.Drawing.Size(129, 22)
        Me.txtFolioOC.TabIndex = 3
        '
        'lblDisplayFolioOC
        '
        Me.lblDisplayFolioOC.AutoSize = True
        Me.lblDisplayFolioOC.Location = New System.Drawing.Point(341, 91)
        Me.lblDisplayFolioOC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioOC.Name = "lblDisplayFolioOC"
        Me.lblDisplayFolioOC.Size = New System.Drawing.Size(70, 17)
        Me.lblDisplayFolioOC.TabIndex = 286
        Me.lblDisplayFolioOC.Text = "Folio OC :"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(107, 119)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProveedor.MaxLength = 8
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(135, 22)
        Me.txtProveedor.TabIndex = 5
        Me.txtProveedor.Text = "  "
        '
        'LblDisplayProveedor
        '
        Me.LblDisplayProveedor.AutoSize = True
        Me.LblDisplayProveedor.Location = New System.Drawing.Point(8, 123)
        Me.LblDisplayProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayProveedor.Name = "LblDisplayProveedor"
        Me.LblDisplayProveedor.Size = New System.Drawing.Size(82, 17)
        Me.LblDisplayProveedor.TabIndex = 283
        Me.LblDisplayProveedor.Text = "Proveedor :"
        '
        'DtpFecha
        '
        Me.DtpFecha.Location = New System.Drawing.Point(989, 23)
        Me.DtpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(280, 22)
        Me.DtpFecha.TabIndex = 14
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(927, 23)
        Me.LblDisplayFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(55, 17)
        Me.LblDisplayFecha.TabIndex = 281
        Me.LblDisplayFecha.Text = "Fecha :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(107, 54)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(280, 24)
        Me.CboAlmacen.TabIndex = 1
        '
        'LblDisplayAlmacen
        '
        Me.LblDisplayAlmacen.AutoSize = True
        Me.LblDisplayAlmacen.Location = New System.Drawing.Point(8, 58)
        Me.LblDisplayAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayAlmacen.Name = "LblDisplayAlmacen"
        Me.LblDisplayAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.LblDisplayAlmacen.TabIndex = 279
        Me.LblDisplayAlmacen.Text = "Almacén :"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(8, 91)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 278
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(107, 23)
        Me.CboDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(280, 24)
        Me.CboDocumento.TabIndex = 0
        '
        'LblDisplayDocumento
        '
        Me.LblDisplayDocumento.AutoSize = True
        Me.LblDisplayDocumento.Location = New System.Drawing.Point(8, 27)
        Me.LblDisplayDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDocumento.Name = "LblDisplayDocumento"
        Me.LblDisplayDocumento.Size = New System.Drawing.Size(88, 17)
        Me.LblDisplayDocumento.TabIndex = 277
        Me.LblDisplayDocumento.Text = "Documento :"
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbAplicar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbSalir, Me.tsbPasarOrdenACompra, Me.tsbPedir, Me.tsbEditarOC, Me.tsbRecepcionarEntrada, Me.tsbEditarCostos, Me.tsbAgregarXML, Me.tsbAgregarPDF})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1372, 27)
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
        'tsbAplicar
        '
        Me.tsbAplicar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(80, 24)
        Me.tsbAplicar.Text = "&Aplicar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(90, 24)
        Me.tsbCancelar.Text = "&Cancelar"
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbPasarOrdenACompra
        '
        Me.tsbPasarOrdenACompra.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbPasarOrdenACompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPasarOrdenACompra.Name = "tsbPasarOrdenACompra"
        Me.tsbPasarOrdenACompra.Size = New System.Drawing.Size(134, 24)
        Me.tsbPasarOrdenACompra.Text = "&Pasar a compra"
        '
        'tsbPedir
        '
        Me.tsbPedir.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbPedir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPedir.Name = "tsbPedir"
        Me.tsbPedir.Size = New System.Drawing.Size(90, 24)
        Me.tsbPedir.Text = "&Pedir OC"
        Me.tsbPedir.ToolTipText = "Pedir"
        '
        'tsbEditarOC
        '
        Me.tsbEditarOC.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarOC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarOC.Name = "tsbEditarOC"
        Me.tsbEditarOC.Size = New System.Drawing.Size(96, 24)
        Me.tsbEditarOC.Text = "Editar OC"
        '
        'tsbRecepcionarEntrada
        '
        Me.tsbRecepcionarEntrada.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbRecepcionarEntrada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecepcionarEntrada.Name = "tsbRecepcionarEntrada"
        Me.tsbRecepcionarEntrada.Size = New System.Drawing.Size(170, 24)
        Me.tsbRecepcionarEntrada.Text = "&Recepcionar entrada"
        '
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(118, 24)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'tsbAgregarXML
        '
        Me.tsbAgregarXML.Image = Global.BsControl.My.Resources.Resources.xml1
        Me.tsbAgregarXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregarXML.Name = "tsbAgregarXML"
        Me.tsbAgregarXML.Size = New System.Drawing.Size(120, 24)
        Me.tsbAgregarXML.Text = "Agregar &XML"
        '
        'tsbAgregarPDF
        '
        Me.tsbAgregarPDF.Image = Global.BsControl.My.Resources.Resources.pdf11
        Me.tsbAgregarPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregarPDF.Name = "tsbAgregarPDF"
        Me.tsbAgregarPDF.Size = New System.Drawing.Size(117, 24)
        Me.tsbAgregarPDF.Text = "Agregar PD&F"
        '
        'txtSaldo_MXP
        '
        Me.txtSaldo_MXP.Location = New System.Drawing.Point(1227, 657)
        Me.txtSaldo_MXP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaldo_MXP.Name = "txtSaldo_MXP"
        Me.txtSaldo_MXP.ReadOnly = True
        Me.txtSaldo_MXP.Size = New System.Drawing.Size(132, 22)
        Me.txtSaldo_MXP.TabIndex = 19
        Me.txtSaldo_MXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldo_MXP
        '
        Me.lblDisplaySaldo_MXP.AutoSize = True
        Me.lblDisplaySaldo_MXP.Location = New System.Drawing.Point(1141, 662)
        Me.lblDisplaySaldo_MXP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySaldo_MXP.Name = "lblDisplaySaldo_MXP"
        Me.lblDisplaySaldo_MXP.Size = New System.Drawing.Size(85, 17)
        Me.lblDisplaySaldo_MXP.TabIndex = 313
        Me.lblDisplaySaldo_MXP.Text = "Saldo MXP :"
        '
        'lblDisplayRetenciones
        '
        Me.lblDisplayRetenciones.AutoSize = True
        Me.lblDisplayRetenciones.Location = New System.Drawing.Point(4, 129)
        Me.lblDisplayRetenciones.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetenciones.Name = "lblDisplayRetenciones"
        Me.lblDisplayRetenciones.Size = New System.Drawing.Size(50, 17)
        Me.lblDisplayRetenciones.TabIndex = 312
        Me.lblDisplayRetenciones.Text = "Reten."
        Me.lblDisplayRetenciones.Visible = False
        '
        'txtRetencionIVA
        '
        Me.txtRetencionIVA.Enabled = False
        Me.txtRetencionIVA.Location = New System.Drawing.Point(104, 124)
        Me.txtRetencionIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetencionIVA.MaxLength = 15
        Me.txtRetencionIVA.Name = "txtRetencionIVA"
        Me.txtRetencionIVA.ReadOnly = True
        Me.txtRetencionIVA.Size = New System.Drawing.Size(71, 22)
        Me.txtRetencionIVA.TabIndex = 2
        Me.txtRetencionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionIVA.Visible = False
        '
        'lblDisplayTotal
        '
        Me.lblDisplayTotal.AutoSize = True
        Me.lblDisplayTotal.Location = New System.Drawing.Point(55, 101)
        Me.lblDisplayTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotal.Name = "lblDisplayTotal"
        Me.lblDisplayTotal.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotal.TabIndex = 309
        Me.lblDisplayTotal.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(112, 97)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(176, 22)
        Me.txtTotal.TabIndex = 18
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIVA
        '
        Me.lblDisplayIVA.AutoSize = True
        Me.lblDisplayIVA.Location = New System.Drawing.Point(64, 74)
        Me.lblDisplayIVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIVA.Name = "lblDisplayIVA"
        Me.lblDisplayIVA.Size = New System.Drawing.Size(37, 17)
        Me.lblDisplayIVA.TabIndex = 307
        Me.lblDisplayIVA.Text = "IVA :"
        '
        'lblDisplaySubTotal
        '
        Me.lblDisplaySubTotal.AutoSize = True
        Me.lblDisplaySubTotal.Location = New System.Drawing.Point(29, 21)
        Me.lblDisplaySubTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySubTotal.Name = "lblDisplaySubTotal"
        Me.lblDisplaySubTotal.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplaySubTotal.TabIndex = 305
        Me.lblDisplaySubTotal.Text = "SubTotal :"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Location = New System.Drawing.Point(112, 16)
        Me.TxtSubTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.ReadOnly = True
        Me.TxtSubTotal.Size = New System.Drawing.Size(176, 22)
        Me.TxtSubTotal.TabIndex = 15
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 723)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1372, 29)
        Me.StatusStripEstado.TabIndex = 314
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
        'txtIVA
        '
        Me.txtIVA.Location = New System.Drawing.Point(112, 70)
        Me.txtIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVA.MaxLength = 80
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(176, 22)
        Me.txtIVA.TabIndex = 330
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIVAcalculado
        '
        Me.lblIVAcalculado.AutoSize = True
        Me.lblIVAcalculado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVAcalculado.Location = New System.Drawing.Point(5, 74)
        Me.lblIVAcalculado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIVAcalculado.Name = "lblIVAcalculado"
        Me.lblIVAcalculado.Size = New System.Drawing.Size(22, 13)
        Me.lblIVAcalculado.TabIndex = 331
        Me.lblIVAcalculado.Text = "0.0"
        '
        'txtIVA_USD
        '
        Me.txtIVA_USD.Location = New System.Drawing.Point(111, 70)
        Me.txtIVA_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIVA_USD.MaxLength = 80
        Me.txtIVA_USD.Name = "txtIVA_USD"
        Me.txtIVA_USD.Size = New System.Drawing.Size(176, 22)
        Me.txtIVA_USD.TabIndex = 337
        Me.txtIVA_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotal_USD
        '
        Me.lblDisplayTotal_USD.AutoSize = True
        Me.lblDisplayTotal_USD.Location = New System.Drawing.Point(55, 101)
        Me.lblDisplayTotal_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotal_USD.Name = "lblDisplayTotal_USD"
        Me.lblDisplayTotal_USD.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotal_USD.TabIndex = 336
        Me.lblDisplayTotal_USD.Text = "Total :"
        '
        'txtTotal_USD
        '
        Me.txtTotal_USD.Location = New System.Drawing.Point(111, 97)
        Me.txtTotal_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal_USD.Name = "txtTotal_USD"
        Me.txtTotal_USD.ReadOnly = True
        Me.txtTotal_USD.Size = New System.Drawing.Size(176, 22)
        Me.txtTotal_USD.TabIndex = 333
        Me.txtTotal_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIVA_USD
        '
        Me.lblDisplayIVA_USD.AutoSize = True
        Me.lblDisplayIVA_USD.Location = New System.Drawing.Point(64, 74)
        Me.lblDisplayIVA_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIVA_USD.Name = "lblDisplayIVA_USD"
        Me.lblDisplayIVA_USD.Size = New System.Drawing.Size(37, 17)
        Me.lblDisplayIVA_USD.TabIndex = 335
        Me.lblDisplayIVA_USD.Text = "IVA :"
        '
        'lblDisplaySubTotal_USD
        '
        Me.lblDisplaySubTotal_USD.AutoSize = True
        Me.lblDisplaySubTotal_USD.Location = New System.Drawing.Point(29, 20)
        Me.lblDisplaySubTotal_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySubTotal_USD.Name = "lblDisplaySubTotal_USD"
        Me.lblDisplaySubTotal_USD.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplaySubTotal_USD.TabIndex = 334
        Me.lblDisplaySubTotal_USD.Text = "SubTotal :"
        '
        'TxtSubTotal_USD
        '
        Me.TxtSubTotal_USD.Location = New System.Drawing.Point(111, 16)
        Me.TxtSubTotal_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSubTotal_USD.Name = "TxtSubTotal_USD"
        Me.TxtSubTotal_USD.ReadOnly = True
        Me.TxtSubTotal_USD.Size = New System.Drawing.Size(176, 22)
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
        Me.gbUSD.Location = New System.Drawing.Point(500, 558)
        Me.gbUSD.Margin = New System.Windows.Forms.Padding(4)
        Me.gbUSD.Name = "gbUSD"
        Me.gbUSD.Padding = New System.Windows.Forms.Padding(4)
        Me.gbUSD.Size = New System.Drawing.Size(297, 155)
        Me.gbUSD.TabIndex = 340
        Me.gbUSD.TabStop = False
        Me.gbUSD.Text = "Totales USD :"
        Me.gbUSD.Visible = False
        '
        'lblIVAcalculado_USD
        '
        Me.lblIVAcalculado_USD.AutoSize = True
        Me.lblIVAcalculado_USD.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVAcalculado_USD.Location = New System.Drawing.Point(5, 74)
        Me.lblIVAcalculado_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIVAcalculado_USD.Name = "lblIVAcalculado_USD"
        Me.lblIVAcalculado_USD.Size = New System.Drawing.Size(22, 13)
        Me.lblIVAcalculado_USD.TabIndex = 394
        Me.lblIVAcalculado_USD.Text = "0.0"
        '
        'txtRetencionISR_USD
        '
        Me.txtRetencionISR_USD.Enabled = False
        Me.txtRetencionISR_USD.Location = New System.Drawing.Point(216, 124)
        Me.txtRetencionISR_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetencionISR_USD.MaxLength = 15
        Me.txtRetencionISR_USD.Name = "txtRetencionISR_USD"
        Me.txtRetencionISR_USD.ReadOnly = True
        Me.txtRetencionISR_USD.Size = New System.Drawing.Size(71, 22)
        Me.txtRetencionISR_USD.TabIndex = 392
        Me.txtRetencionISR_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionISR_USD.Visible = False
        '
        'lblDisplayRetencionISR_USD
        '
        Me.lblDisplayRetencionISR_USD.AutoSize = True
        Me.lblDisplayRetencionISR_USD.Location = New System.Drawing.Point(176, 128)
        Me.lblDisplayRetencionISR_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetencionISR_USD.Name = "lblDisplayRetencionISR_USD"
        Me.lblDisplayRetencionISR_USD.Size = New System.Drawing.Size(38, 17)
        Me.lblDisplayRetencionISR_USD.TabIndex = 393
        Me.lblDisplayRetencionISR_USD.Text = "ISR :"
        Me.lblDisplayRetencionISR_USD.Visible = False
        '
        'lblDisplayRetencionIVA_USD
        '
        Me.lblDisplayRetencionIVA_USD.AutoSize = True
        Me.lblDisplayRetencionIVA_USD.Location = New System.Drawing.Point(64, 128)
        Me.lblDisplayRetencionIVA_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetencionIVA_USD.Name = "lblDisplayRetencionIVA_USD"
        Me.lblDisplayRetencionIVA_USD.Size = New System.Drawing.Size(37, 17)
        Me.lblDisplayRetencionIVA_USD.TabIndex = 391
        Me.lblDisplayRetencionIVA_USD.Text = "IVA :"
        Me.lblDisplayRetencionIVA_USD.Visible = False
        '
        'txtRetencionIVA_USD
        '
        Me.txtRetencionIVA_USD.Enabled = False
        Me.txtRetencionIVA_USD.Location = New System.Drawing.Point(104, 124)
        Me.txtRetencionIVA_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetencionIVA_USD.MaxLength = 15
        Me.txtRetencionIVA_USD.Name = "txtRetencionIVA_USD"
        Me.txtRetencionIVA_USD.ReadOnly = True
        Me.txtRetencionIVA_USD.Size = New System.Drawing.Size(71, 22)
        Me.txtRetencionIVA_USD.TabIndex = 389
        Me.txtRetencionIVA_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionIVA_USD.Visible = False
        '
        'lblDisplayRetenciones_USD
        '
        Me.lblDisplayRetenciones_USD.AutoSize = True
        Me.lblDisplayRetenciones_USD.Location = New System.Drawing.Point(4, 128)
        Me.lblDisplayRetenciones_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetenciones_USD.Name = "lblDisplayRetenciones_USD"
        Me.lblDisplayRetenciones_USD.Size = New System.Drawing.Size(50, 17)
        Me.lblDisplayRetenciones_USD.TabIndex = 390
        Me.lblDisplayRetenciones_USD.Text = "Reten."
        Me.lblDisplayRetenciones_USD.Visible = False
        '
        'txtIEPS_USD
        '
        Me.txtIEPS_USD.Location = New System.Drawing.Point(111, 43)
        Me.txtIEPS_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIEPS_USD.MaxLength = 80
        Me.txtIEPS_USD.Name = "txtIEPS_USD"
        Me.txtIEPS_USD.ReadOnly = True
        Me.txtIEPS_USD.Size = New System.Drawing.Size(176, 22)
        Me.txtIEPS_USD.TabIndex = 387
        Me.txtIEPS_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIEPS_USD
        '
        Me.lblDisplayIEPS_USD.AutoSize = True
        Me.lblDisplayIEPS_USD.Location = New System.Drawing.Point(55, 44)
        Me.lblDisplayIEPS_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIEPS_USD.Name = "lblDisplayIEPS_USD"
        Me.lblDisplayIEPS_USD.Size = New System.Drawing.Size(46, 17)
        Me.lblDisplayIEPS_USD.TabIndex = 386
        Me.lblDisplayIEPS_USD.Text = "IEPS :"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpArticulos)
        Me.TabControl1.Controls.Add(Me.tpSeries)
        Me.TabControl1.Controls.Add(Me.tpEntradas)
        Me.TabControl1.Location = New System.Drawing.Point(1, 302)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1359, 251)
        Me.TabControl1.TabIndex = 1
        '
        'tpArticulos
        '
        Me.tpArticulos.Controls.Add(Me.Grid)
        Me.tpArticulos.Location = New System.Drawing.Point(4, 25)
        Me.tpArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.tpArticulos.Name = "tpArticulos"
        Me.tpArticulos.Padding = New System.Windows.Forms.Padding(4)
        Me.tpArticulos.Size = New System.Drawing.Size(1351, 222)
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
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(1, 7)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 6
        Me.Grid.Size = New System.Drawing.Size(1331, 204)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpSeries
        '
        Me.tpSeries.Controls.Add(Me.lblDisplayLote)
        Me.tpSeries.Controls.Add(Me.btnCopiarLote)
        Me.tpSeries.Controls.Add(Me.txtLote)
        Me.tpSeries.Controls.Add(Me.GridSeries)
        Me.tpSeries.Location = New System.Drawing.Point(4, 25)
        Me.tpSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.tpSeries.Name = "tpSeries"
        Me.tpSeries.Padding = New System.Windows.Forms.Padding(4)
        Me.tpSeries.Size = New System.Drawing.Size(1351, 222)
        Me.tpSeries.TabIndex = 1
        Me.tpSeries.Text = "Series"
        Me.tpSeries.UseVisualStyleBackColor = True
        '
        'lblDisplayLote
        '
        Me.lblDisplayLote.AutoSize = True
        Me.lblDisplayLote.Location = New System.Drawing.Point(433, 194)
        Me.lblDisplayLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayLote.Name = "lblDisplayLote"
        Me.lblDisplayLote.Size = New System.Drawing.Size(44, 17)
        Me.lblDisplayLote.TabIndex = 331
        Me.lblDisplayLote.Text = "Lote :"
        '
        'btnCopiarLote
        '
        Me.btnCopiarLote.Location = New System.Drawing.Point(663, 190)
        Me.btnCopiarLote.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopiarLote.Name = "btnCopiarLote"
        Me.btnCopiarLote.Size = New System.Drawing.Size(145, 26)
        Me.btnCopiarLote.TabIndex = 330
        Me.btnCopiarLote.Text = "Copiar"
        Me.btnCopiarLote.UseVisualStyleBackColor = True
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(512, 192)
        Me.txtLote.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLote.MaxLength = 80
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(141, 22)
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
        Me.GridSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSeries.Location = New System.Drawing.Point(4, 7)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(1332, 183)
        Me.GridSeries.TabIndex = 1
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tpEntradas
        '
        Me.tpEntradas.Controls.Add(Me.gbEntradas)
        Me.tpEntradas.Location = New System.Drawing.Point(4, 25)
        Me.tpEntradas.Margin = New System.Windows.Forms.Padding(4)
        Me.tpEntradas.Name = "tpEntradas"
        Me.tpEntradas.Padding = New System.Windows.Forms.Padding(4)
        Me.tpEntradas.Size = New System.Drawing.Size(1351, 222)
        Me.tpEntradas.TabIndex = 2
        Me.tpEntradas.Text = "Entradas inventario"
        Me.tpEntradas.UseVisualStyleBackColor = True
        '
        'gbEntradas
        '
        Me.gbEntradas.Controls.Add(Me.GridEntradas)
        Me.gbEntradas.Controls.Add(Me.btnBorrarTodasEntradasInventarios)
        Me.gbEntradas.Controls.Add(Me.txtFolioOC_Inventarios)
        Me.gbEntradas.Controls.Add(Me.btnTraerTodasEntradasInventarios)
        Me.gbEntradas.Controls.Add(Me.lblDisplayFolioOC_Inventarios)
        Me.gbEntradas.Controls.Add(Me.btnAgregarSeleccionadaEntradasInventarios)
        Me.gbEntradas.Controls.Add(Me.lstEntradasInventarios)
        Me.gbEntradas.Controls.Add(Me.btnAgregarTodasEntradasInventarios)
        Me.gbEntradas.Controls.Add(Me.lblDisplayEntradasInventarios)
        Me.gbEntradas.Location = New System.Drawing.Point(4, 9)
        Me.gbEntradas.Margin = New System.Windows.Forms.Padding(4)
        Me.gbEntradas.Name = "gbEntradas"
        Me.gbEntradas.Padding = New System.Windows.Forms.Padding(4)
        Me.gbEntradas.Size = New System.Drawing.Size(1336, 207)
        Me.gbEntradas.TabIndex = 335
        Me.gbEntradas.TabStop = False
        '
        'GridEntradas
        '
        Me.GridEntradas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridEntradas.CheckedImage = CType(resources.GetObject("GridEntradas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridEntradas.Cols = 1
        Me.GridEntradas.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridEntradas.DefaultRowHeight = CType(24, Short)
        Me.GridEntradas.DisplayRowNumber = True
        Me.GridEntradas.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridEntradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEntradas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridEntradas.Location = New System.Drawing.Point(8, 17)
        Me.GridEntradas.LockButton = True
        Me.GridEntradas.Margin = New System.Windows.Forms.Padding(4)
        Me.GridEntradas.Name = "GridEntradas"
        Me.GridEntradas.Rows = 6
        Me.GridEntradas.Size = New System.Drawing.Size(696, 182)
        Me.GridEntradas.TabIndex = 1
        Me.GridEntradas.UncheckedImage = CType(resources.GetObject("GridEntradas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnBorrarTodasEntradasInventarios
        '
        Me.btnBorrarTodasEntradasInventarios.Location = New System.Drawing.Point(1120, 156)
        Me.btnBorrarTodasEntradasInventarios.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBorrarTodasEntradasInventarios.Name = "btnBorrarTodasEntradasInventarios"
        Me.btnBorrarTodasEntradasInventarios.Size = New System.Drawing.Size(169, 26)
        Me.btnBorrarTodasEntradasInventarios.TabIndex = 334
        Me.btnBorrarTodasEntradasInventarios.Text = "Borrar todas"
        Me.btnBorrarTodasEntradasInventarios.UseVisualStyleBackColor = True
        '
        'txtFolioOC_Inventarios
        '
        Me.txtFolioOC_Inventarios.Location = New System.Drawing.Point(805, 16)
        Me.txtFolioOC_Inventarios.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioOC_Inventarios.MaxLength = 80
        Me.txtFolioOC_Inventarios.Name = "txtFolioOC_Inventarios"
        Me.txtFolioOC_Inventarios.Size = New System.Drawing.Size(159, 22)
        Me.txtFolioOC_Inventarios.TabIndex = 9
        '
        'btnTraerTodasEntradasInventarios
        '
        Me.btnTraerTodasEntradasInventarios.Location = New System.Drawing.Point(991, 20)
        Me.btnTraerTodasEntradasInventarios.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTraerTodasEntradasInventarios.Name = "btnTraerTodasEntradasInventarios"
        Me.btnTraerTodasEntradasInventarios.Size = New System.Drawing.Size(169, 26)
        Me.btnTraerTodasEntradasInventarios.TabIndex = 333
        Me.btnTraerTodasEntradasInventarios.Text = "Traer entradas"
        Me.btnTraerTodasEntradasInventarios.UseVisualStyleBackColor = True
        '
        'lblDisplayFolioOC_Inventarios
        '
        Me.lblDisplayFolioOC_Inventarios.AutoSize = True
        Me.lblDisplayFolioOC_Inventarios.Location = New System.Drawing.Point(708, 20)
        Me.lblDisplayFolioOC_Inventarios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioOC_Inventarios.Name = "lblDisplayFolioOC_Inventarios"
        Me.lblDisplayFolioOC_Inventarios.Size = New System.Drawing.Size(70, 17)
        Me.lblDisplayFolioOC_Inventarios.TabIndex = 279
        Me.lblDisplayFolioOC_Inventarios.Text = "Folio OC :"
        '
        'btnAgregarSeleccionadaEntradasInventarios
        '
        Me.btnAgregarSeleccionadaEntradasInventarios.Location = New System.Drawing.Point(1120, 98)
        Me.btnAgregarSeleccionadaEntradasInventarios.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarSeleccionadaEntradasInventarios.Name = "btnAgregarSeleccionadaEntradasInventarios"
        Me.btnAgregarSeleccionadaEntradasInventarios.Size = New System.Drawing.Size(169, 26)
        Me.btnAgregarSeleccionadaEntradasInventarios.TabIndex = 331
        Me.btnAgregarSeleccionadaEntradasInventarios.Text = "Agregar seleccionada"
        Me.btnAgregarSeleccionadaEntradasInventarios.UseVisualStyleBackColor = True
        '
        'lstEntradasInventarios
        '
        Me.lstEntradasInventarios.FormattingEnabled = True
        Me.lstEntradasInventarios.ItemHeight = 16
        Me.lstEntradasInventarios.Location = New System.Drawing.Point(805, 65)
        Me.lstEntradasInventarios.Margin = New System.Windows.Forms.Padding(4)
        Me.lstEntradasInventarios.MultiColumn = True
        Me.lstEntradasInventarios.Name = "lstEntradasInventarios"
        Me.lstEntradasInventarios.Size = New System.Drawing.Size(305, 116)
        Me.lstEntradasInventarios.TabIndex = 280
        '
        'btnAgregarTodasEntradasInventarios
        '
        Me.btnAgregarTodasEntradasInventarios.Location = New System.Drawing.Point(1120, 65)
        Me.btnAgregarTodasEntradasInventarios.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarTodasEntradasInventarios.Name = "btnAgregarTodasEntradasInventarios"
        Me.btnAgregarTodasEntradasInventarios.Size = New System.Drawing.Size(169, 26)
        Me.btnAgregarTodasEntradasInventarios.TabIndex = 330
        Me.btnAgregarTodasEntradasInventarios.Text = "Agregar todas"
        Me.btnAgregarTodasEntradasInventarios.UseVisualStyleBackColor = True
        '
        'lblDisplayEntradasInventarios
        '
        Me.lblDisplayEntradasInventarios.Location = New System.Drawing.Point(708, 65)
        Me.lblDisplayEntradasInventarios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEntradasInventarios.Name = "lblDisplayEntradasInventarios"
        Me.lblDisplayEntradasInventarios.Size = New System.Drawing.Size(88, 66)
        Me.lblDisplayEntradasInventarios.TabIndex = 281
        Me.lblDisplayEntradasInventarios.Text = "Entradas inventarios:"
        '
        'btnSeries
        '
        Me.btnSeries.Enabled = False
        Me.btnSeries.Location = New System.Drawing.Point(272, 577)
        Me.btnSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(220, 39)
        Me.btnSeries.TabIndex = 380
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        Me.btnSeries.Visible = False
        '
        'txtSaldo_USD
        '
        Me.txtSaldo_USD.Location = New System.Drawing.Point(1227, 686)
        Me.txtSaldo_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaldo_USD.Name = "txtSaldo_USD"
        Me.txtSaldo_USD.ReadOnly = True
        Me.txtSaldo_USD.Size = New System.Drawing.Size(132, 22)
        Me.txtSaldo_USD.TabIndex = 381
        Me.txtSaldo_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldo_USD
        '
        Me.lblDisplaySaldo_USD.AutoSize = True
        Me.lblDisplaySaldo_USD.Location = New System.Drawing.Point(1141, 688)
        Me.lblDisplaySaldo_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySaldo_USD.Name = "lblDisplaySaldo_USD"
        Me.lblDisplaySaldo_USD.Size = New System.Drawing.Size(85, 17)
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
        Me.btnSeleccionarArchivoSeries.Location = New System.Drawing.Point(272, 624)
        Me.btnSeleccionarArchivoSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSeleccionarArchivoSeries.Name = "btnSeleccionarArchivoSeries"
        Me.btnSeleccionarArchivoSeries.Size = New System.Drawing.Size(220, 39)
        Me.btnSeleccionarArchivoSeries.TabIndex = 383
        Me.btnSeleccionarArchivoSeries.Text = "Seleccionar archivo con series"
        Me.btnSeleccionarArchivoSeries.UseVisualStyleBackColor = True
        Me.btnSeleccionarArchivoSeries.Visible = False
        '
        'txtIEPS
        '
        Me.txtIEPS.Location = New System.Drawing.Point(112, 43)
        Me.txtIEPS.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIEPS.MaxLength = 80
        Me.txtIEPS.Name = "txtIEPS"
        Me.txtIEPS.ReadOnly = True
        Me.txtIEPS.Size = New System.Drawing.Size(176, 22)
        Me.txtIEPS.TabIndex = 385
        Me.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayIEPS
        '
        Me.lblDisplayIEPS.AutoSize = True
        Me.lblDisplayIEPS.Location = New System.Drawing.Point(55, 47)
        Me.lblDisplayIEPS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIEPS.Name = "lblDisplayIEPS"
        Me.lblDisplayIEPS.Size = New System.Drawing.Size(46, 17)
        Me.lblDisplayIEPS.TabIndex = 384
        Me.lblDisplayIEPS.Text = "IEPS :"
        '
        'TxtConceptoCancelacion
        '
        Me.TxtConceptoCancelacion.Location = New System.Drawing.Point(5, 578)
        Me.TxtConceptoCancelacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConceptoCancelacion.MaxLength = 1000
        Me.TxtConceptoCancelacion.Multiline = True
        Me.TxtConceptoCancelacion.Name = "TxtConceptoCancelacion"
        Me.TxtConceptoCancelacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConceptoCancelacion.Size = New System.Drawing.Size(257, 83)
        Me.TxtConceptoCancelacion.TabIndex = 386
        Me.TxtConceptoCancelacion.Visible = False
        '
        'LblConceptoCancelacion
        '
        Me.LblConceptoCancelacion.AutoSize = True
        Me.LblConceptoCancelacion.Location = New System.Drawing.Point(3, 556)
        Me.LblConceptoCancelacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblConceptoCancelacion.Name = "LblConceptoCancelacion"
        Me.LblConceptoCancelacion.Size = New System.Drawing.Size(155, 17)
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
        Me.gbMXN.Location = New System.Drawing.Point(820, 558)
        Me.gbMXN.Margin = New System.Windows.Forms.Padding(4)
        Me.gbMXN.Name = "gbMXN"
        Me.gbMXN.Padding = New System.Windows.Forms.Padding(4)
        Me.gbMXN.Size = New System.Drawing.Size(297, 155)
        Me.gbMXN.TabIndex = 388
        Me.gbMXN.TabStop = False
        Me.gbMXN.Text = "Totales MXN :"
        '
        'txtRetencionISR
        '
        Me.txtRetencionISR.Enabled = False
        Me.txtRetencionISR.Location = New System.Drawing.Point(217, 124)
        Me.txtRetencionISR.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetencionISR.MaxLength = 15
        Me.txtRetencionISR.Name = "txtRetencionISR"
        Me.txtRetencionISR.ReadOnly = True
        Me.txtRetencionISR.Size = New System.Drawing.Size(71, 22)
        Me.txtRetencionISR.TabIndex = 387
        Me.txtRetencionISR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRetencionISR.Visible = False
        '
        'lblDisplayRetencionISR
        '
        Me.lblDisplayRetencionISR.AutoSize = True
        Me.lblDisplayRetencionISR.Location = New System.Drawing.Point(176, 129)
        Me.lblDisplayRetencionISR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetencionISR.Name = "lblDisplayRetencionISR"
        Me.lblDisplayRetencionISR.Size = New System.Drawing.Size(38, 17)
        Me.lblDisplayRetencionISR.TabIndex = 388
        Me.lblDisplayRetencionISR.Text = "ISR :"
        Me.lblDisplayRetencionISR.Visible = False
        '
        'lblDisplayRetencionIVA
        '
        Me.lblDisplayRetencionIVA.AutoSize = True
        Me.lblDisplayRetencionIVA.Location = New System.Drawing.Point(64, 129)
        Me.lblDisplayRetencionIVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRetencionIVA.Name = "lblDisplayRetencionIVA"
        Me.lblDisplayRetencionIVA.Size = New System.Drawing.Size(37, 17)
        Me.lblDisplayRetencionIVA.TabIndex = 386
        Me.lblDisplayRetencionIVA.Text = "IVA :"
        Me.lblDisplayRetencionIVA.Visible = False
        '
        'lblAyuda
        '
        Me.lblAyuda.AutoSize = True
        Me.lblAyuda.Location = New System.Drawing.Point(4, 682)
        Me.lblAyuda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(498, 17)
        Me.lblAyuda.TabIndex = 389
        Me.lblAyuda.Text = "*F4 para agregar comentarios, F8 para eliminar renglones, F6/F7 para buscar"
        '
        'btnMultiplesRequisiciones
        '
        Me.btnMultiplesRequisiciones.Location = New System.Drawing.Point(719, 21)
        Me.btnMultiplesRequisiciones.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMultiplesRequisiciones.Name = "btnMultiplesRequisiciones"
        Me.btnMultiplesRequisiciones.Size = New System.Drawing.Size(166, 27)
        Me.btnMultiplesRequisiciones.TabIndex = 393
        Me.btnMultiplesRequisiciones.Text = "Multiples requisiciones"
        Me.btnMultiplesRequisiciones.UseVisualStyleBackColor = True
        '
        'Compras_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1372, 752)
        Me.Controls.Add(Me.lblAyuda)
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
        Me.Margin = New System.Windows.Forms.Padding(4)
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
        Me.tpEntradas.ResumeLayout(False)
        Me.gbEntradas.ResumeLayout(False)
        Me.gbEntradas.PerformLayout()
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
    Friend WithEvents tpEntradas As TabPage
    Friend WithEvents GridEntradas As FlexCell.Grid
    Friend WithEvents lblDisplayFolioOC_Inventarios As Label
    Friend WithEvents txtFolioOC_Inventarios As TextBox
    Friend WithEvents lblDisplayEntradasInventarios As Label
    Friend WithEvents lstEntradasInventarios As ListBox
    Friend WithEvents btnAgregarSeleccionadaEntradasInventarios As Button
    Friend WithEvents btnAgregarTodasEntradasInventarios As Button
    Friend WithEvents btnTraerTodasEntradasInventarios As Button
    Friend WithEvents btnBorrarTodasEntradasInventarios As Button
    Friend WithEvents chkEsInventariable As CheckBox
    Friend WithEvents gbEntradas As GroupBox
    Friend WithEvents tsbRecepcionarEntrada As ToolStripButton
    Friend WithEvents lblAyuda As Label
    Friend WithEvents chkEsFiscal As CheckBox
    Friend WithEvents tsbPedir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblRequisicion As System.Windows.Forms.Label
    Friend WithEvents TxtRequisicion As System.Windows.Forms.TextBox
    Friend WithEvents btnTraerDetalleRequisicion As System.Windows.Forms.Button
    Friend WithEvents tsbEditarOC As ToolStripButton
    Friend WithEvents LblDisplayTipoEnvio As System.Windows.Forms.Label
    Friend WithEvents CboTipoEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNombreTransporte As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayTransporte As System.Windows.Forms.Label
    Friend WithEvents btnMultiplesRequisiciones As System.Windows.Forms.Button
End Class
