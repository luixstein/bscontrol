<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXP_Revision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXP_Revision))
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.LblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.lblDilplayPoliza = New System.Windows.Forms.Label()
        Me.LblProveedor = New System.Windows.Forms.Label()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.LblCuentaContableProveedor = New System.Windows.Forms.Label()
        Me.LblDisplayProveedor = New System.Windows.Forms.Label()
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.cboTipoGasto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTipoGasto = New System.Windows.Forms.Label()
        Me.txtFolioCompra = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.gbCompras = New System.Windows.Forms.GroupBox()
        Me.btnImprimirPoliza = New System.Windows.Forms.Button()
        Me.btnContinuarCompras = New System.Windows.Forms.Button()
        Me.LblMsn = New System.Windows.Forms.Label()
        Me.ckbSaldos = New System.Windows.Forms.CheckBox()
        Me.lblDisplayTotales = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.GridCompras = New FlexCell.Grid()
        Me.lblDisplayPorciento = New System.Windows.Forms.Label()
        Me.DtpFechaFacturaProveedor = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayRetencion = New System.Windows.Forms.Label()
        Me.TxtRetencion = New System.Windows.Forms.TextBox()
        Me.LblDisplayTotal = New System.Windows.Forms.Label()
        Me.LblDisplayIVA = New System.Windows.Forms.Label()
        Me.LblDisplaySubTotal = New System.Windows.Forms.Label()
        Me.lblDisplayFechaFacturaProveedor = New System.Windows.Forms.Label()
        Me.dtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayVencimiento = New System.Windows.Forms.Label()
        Me.LblDisplayConcepto = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.lblDisplayEmbarque = New System.Windows.Forms.Label()
        Me.gbCompraProveedor = New System.Windows.Forms.GroupBox()
        Me.btnActualizaConcepto = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridActivos = New FlexCell.Grid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckbDolares = New System.Windows.Forms.CheckBox()
        Me.txtImporteDolares = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoCambio = New System.Windows.Forms.Label()
        Me.GridCuentas = New FlexCell.Grid()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.txtPorciento = New System.Windows.Forms.TextBox()
        Me.txtTotalCompra = New System.Windows.Forms.TextBox()
        Me.TxtIVA = New System.Windows.Forms.TextBox()
        Me.TxtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtEmbarque = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioProveedor = New System.Windows.Forms.Label()
        Me.txtFolioProveedor = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditarCostos = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbProveedor.SuspendLayout()
        Me.gbCompras.SuspendLayout()
        Me.gbCompraProveedor.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(68, 12)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(211, 21)
        Me.CboAlmacen.TabIndex = 0
        '
        'LblDisplayAlmacen
        '
        Me.LblDisplayAlmacen.AutoSize = True
        Me.LblDisplayAlmacen.Location = New System.Drawing.Point(6, 16)
        Me.LblDisplayAlmacen.Name = "LblDisplayAlmacen"
        Me.LblDisplayAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.LblDisplayAlmacen.TabIndex = 283
        Me.LblDisplayAlmacen.Text = "Almacén :"
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnDocumentoSiguiente)
        Me.gbProveedor.Controls.Add(Me.LblPoliza)
        Me.gbProveedor.Controls.Add(Me.lblDilplayPoliza)
        Me.gbProveedor.Controls.Add(Me.LblProveedor)
        Me.gbProveedor.Controls.Add(Me.btnDocumentoAnterior)
        Me.gbProveedor.Controls.Add(Me.LblCuentaContableProveedor)
        Me.gbProveedor.Controls.Add(Me.LblDisplayProveedor)
        Me.gbProveedor.Controls.Add(Me.TxtCodigoProveedor)
        Me.gbProveedor.Controls.Add(Me.btnContinuar)
        Me.gbProveedor.Controls.Add(Me.cboTipoGasto)
        Me.gbProveedor.Controls.Add(Me.lblDisplayTipoGasto)
        Me.gbProveedor.Controls.Add(Me.CboAlmacen)
        Me.gbProveedor.Controls.Add(Me.LblDisplayAlmacen)
        Me.gbProveedor.Controls.Add(Me.txtFolioCompra)
        Me.gbProveedor.Controls.Add(Me.LblDisplayFolio)
        Me.gbProveedor.Location = New System.Drawing.Point(12, 24)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(998, 64)
        Me.gbProveedor.TabIndex = 1
        Me.gbProveedor.TabStop = False
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(207, 38)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoSiguiente.TabIndex = 380
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(902, 16)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(13, 13)
        Me.LblPoliza.TabIndex = 382
        Me.LblPoliza.TabStop = True
        Me.LblPoliza.Text = "_"
        '
        'lblDilplayPoliza
        '
        Me.lblDilplayPoliza.AutoSize = True
        Me.lblDilplayPoliza.Location = New System.Drawing.Point(825, 16)
        Me.lblDilplayPoliza.Name = "lblDilplayPoliza"
        Me.lblDilplayPoliza.Size = New System.Drawing.Size(41, 13)
        Me.lblDilplayPoliza.TabIndex = 381
        Me.lblDilplayPoliza.Text = "Póliza :"
        '
        'LblProveedor
        '
        Me.LblProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblProveedor.Location = New System.Drawing.Point(463, 42)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(244, 13)
        Me.LblProveedor.TabIndex = 294
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(179, 38)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoAnterior.TabIndex = 379
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'LblCuentaContableProveedor
        '
        Me.LblCuentaContableProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaContableProveedor.Location = New System.Drawing.Point(591, 16)
        Me.LblCuentaContableProveedor.Name = "LblCuentaContableProveedor"
        Me.LblCuentaContableProveedor.Size = New System.Drawing.Size(196, 13)
        Me.LblCuentaContableProveedor.TabIndex = 292
        '
        'LblDisplayProveedor
        '
        Me.LblDisplayProveedor.AutoSize = True
        Me.LblDisplayProveedor.Location = New System.Drawing.Point(290, 42)
        Me.LblDisplayProveedor.Name = "LblDisplayProveedor"
        Me.LblDisplayProveedor.Size = New System.Drawing.Size(62, 13)
        Me.LblDisplayProveedor.TabIndex = 293
        Me.LblDisplayProveedor.Text = "Proveedor :"
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(374, 38)
        Me.TxtCodigoProveedor.MaxLength = 8
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(83, 20)
        Me.TxtCodigoProveedor.TabIndex = 1
        '
        'btnContinuar
        '
        Me.btnContinuar.Location = New System.Drawing.Point(828, 38)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(108, 21)
        Me.btnContinuar.TabIndex = 3
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'cboTipoGasto
        '
        Me.cboTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoGasto.FormattingEnabled = True
        Me.cboTipoGasto.Location = New System.Drawing.Point(374, 12)
        Me.cboTipoGasto.Name = "cboTipoGasto"
        Me.cboTipoGasto.Size = New System.Drawing.Size(211, 21)
        Me.cboTipoGasto.TabIndex = 2
        '
        'lblDisplayTipoGasto
        '
        Me.lblDisplayTipoGasto.AutoSize = True
        Me.lblDisplayTipoGasto.Location = New System.Drawing.Point(290, 16)
        Me.lblDisplayTipoGasto.Name = "lblDisplayTipoGasto"
        Me.lblDisplayTipoGasto.Size = New System.Drawing.Size(78, 13)
        Me.lblDisplayTipoGasto.TabIndex = 284
        Me.lblDisplayTipoGasto.Text = "Tipo de gasto :"
        '
        'txtFolioCompra
        '
        Me.txtFolioCompra.Location = New System.Drawing.Point(68, 39)
        Me.txtFolioCompra.MaxLength = 15
        Me.txtFolioCompra.Name = "txtFolioCompra"
        Me.txtFolioCompra.Size = New System.Drawing.Size(102, 20)
        Me.txtFolioCompra.TabIndex = 0
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(6, 43)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 337
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'gbCompras
        '
        Me.gbCompras.Controls.Add(Me.btnImprimirPoliza)
        Me.gbCompras.Controls.Add(Me.btnContinuarCompras)
        Me.gbCompras.Controls.Add(Me.LblMsn)
        Me.gbCompras.Controls.Add(Me.ckbSaldos)
        Me.gbCompras.Controls.Add(Me.lblDisplayTotales)
        Me.gbCompras.Controls.Add(Me.txtSaldo)
        Me.gbCompras.Controls.Add(Me.txtTotal)
        Me.gbCompras.Controls.Add(Me.GridCompras)
        Me.gbCompras.Location = New System.Drawing.Point(12, 484)
        Me.gbCompras.Name = "gbCompras"
        Me.gbCompras.Size = New System.Drawing.Size(998, 166)
        Me.gbCompras.TabIndex = 2
        Me.gbCompras.TabStop = False
        Me.gbCompras.Text = "Compras hechas al proveedor :"
        '
        'btnImprimirPoliza
        '
        Me.btnImprimirPoliza.Location = New System.Drawing.Point(820, 52)
        Me.btnImprimirPoliza.Name = "btnImprimirPoliza"
        Me.btnImprimirPoliza.Size = New System.Drawing.Size(108, 21)
        Me.btnImprimirPoliza.TabIndex = 215
        Me.btnImprimirPoliza.Text = "Imprimir poliza"
        Me.btnImprimirPoliza.UseVisualStyleBackColor = True
        '
        'btnContinuarCompras
        '
        Me.btnContinuarCompras.Location = New System.Drawing.Point(820, 79)
        Me.btnContinuarCompras.Name = "btnContinuarCompras"
        Me.btnContinuarCompras.Size = New System.Drawing.Size(108, 21)
        Me.btnContinuarCompras.TabIndex = 0
        Me.btnContinuarCompras.Text = "Continuar"
        Me.btnContinuarCompras.UseVisualStyleBackColor = True
        '
        'LblMsn
        '
        Me.LblMsn.BackColor = System.Drawing.SystemColors.HotTrack
        Me.LblMsn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsn.ForeColor = System.Drawing.SystemColors.Window
        Me.LblMsn.Location = New System.Drawing.Point(820, 19)
        Me.LblMsn.Name = "LblMsn"
        Me.LblMsn.Size = New System.Drawing.Size(181, 30)
        Me.LblMsn.TabIndex = 214
        Me.LblMsn.Text = "Seleccione la compra que tomó a revisión :"
        '
        'ckbSaldos
        '
        Me.ckbSaldos.AutoSize = True
        Me.ckbSaldos.Location = New System.Drawing.Point(78, 144)
        Me.ckbSaldos.Name = "ckbSaldos"
        Me.ckbSaldos.Size = New System.Drawing.Size(157, 17)
        Me.ckbSaldos.TabIndex = 213
        Me.ckbSaldos.Text = "Sólo documentos con saldo"
        Me.ckbSaldos.UseVisualStyleBackColor = True
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(489, 144)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTotales.TabIndex = 212
        Me.lblDisplayTotales.Text = "Totales :"
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(578, 141)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldo.TabIndex = 211
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(687, 141)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 210
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridCompras
        '
        Me.GridCompras.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCompras.CheckedImage = CType(resources.GetObject("GridCompras.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCompras.Cols = 1
        Me.GridCompras.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCompras.DisplayRowNumber = True
        Me.GridCompras.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCompras.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCompras.Location = New System.Drawing.Point(9, 19)
        Me.GridCompras.LockButton = True
        Me.GridCompras.Name = "GridCompras"
        Me.GridCompras.Rows = 2
        Me.GridCompras.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridCompras.Size = New System.Drawing.Size(805, 122)
        Me.GridCompras.TabIndex = 1
        Me.GridCompras.UncheckedImage = CType(resources.GetObject("GridCompras.UncheckedImage"), System.Drawing.Bitmap)
        '
        'lblDisplayPorciento
        '
        Me.lblDisplayPorciento.AutoSize = True
        Me.lblDisplayPorciento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayPorciento.Location = New System.Drawing.Point(553, 348)
        Me.lblDisplayPorciento.Name = "lblDisplayPorciento"
        Me.lblDisplayPorciento.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplayPorciento.TabIndex = 345
        Me.lblDisplayPorciento.Text = "% IVA"
        '
        'DtpFechaFacturaProveedor
        '
        Me.DtpFechaFacturaProveedor.Location = New System.Drawing.Point(773, 12)
        Me.DtpFechaFacturaProveedor.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFechaFacturaProveedor.Name = "DtpFechaFacturaProveedor"
        Me.DtpFechaFacturaProveedor.Size = New System.Drawing.Size(206, 20)
        Me.DtpFechaFacturaProveedor.TabIndex = 3
        '
        'LblDisplayRetencion
        '
        Me.LblDisplayRetencion.AutoSize = True
        Me.LblDisplayRetencion.Location = New System.Drawing.Point(643, 348)
        Me.LblDisplayRetencion.Name = "LblDisplayRetencion"
        Me.LblDisplayRetencion.Size = New System.Drawing.Size(56, 13)
        Me.LblDisplayRetencion.TabIndex = 344
        Me.LblDisplayRetencion.Text = "Retención"
        '
        'TxtRetencion
        '
        Me.TxtRetencion.Enabled = False
        Me.TxtRetencion.Location = New System.Drawing.Point(607, 366)
        Me.TxtRetencion.MaxLength = 15
        Me.TxtRetencion.Name = "TxtRetencion"
        Me.TxtRetencion.Size = New System.Drawing.Size(92, 20)
        Me.TxtRetencion.TabIndex = 12
        Me.TxtRetencion.Text = "0"
        Me.TxtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayTotal
        '
        Me.LblDisplayTotal.AutoSize = True
        Me.LblDisplayTotal.Location = New System.Drawing.Point(734, 348)
        Me.LblDisplayTotal.Name = "LblDisplayTotal"
        Me.LblDisplayTotal.Size = New System.Drawing.Size(63, 13)
        Me.LblDisplayTotal.TabIndex = 343
        Me.LblDisplayTotal.Text = "Total (MXP)"
        '
        'LblDisplayIVA
        '
        Me.LblDisplayIVA.AutoSize = True
        Me.LblDisplayIVA.Location = New System.Drawing.Point(488, 348)
        Me.LblDisplayIVA.Name = "LblDisplayIVA"
        Me.LblDisplayIVA.Size = New System.Drawing.Size(45, 13)
        Me.LblDisplayIVA.TabIndex = 342
        Me.LblDisplayIVA.Text = "$ I.V.A. "
        '
        'LblDisplaySubTotal
        '
        Me.LblDisplaySubTotal.AutoSize = True
        Me.LblDisplaySubTotal.Location = New System.Drawing.Point(359, 348)
        Me.LblDisplaySubTotal.Name = "LblDisplaySubTotal"
        Me.LblDisplaySubTotal.Size = New System.Drawing.Size(79, 13)
        Me.LblDisplaySubTotal.TabIndex = 341
        Me.LblDisplaySubTotal.Text = "SubTotal(MXP)"
        '
        'lblDisplayFechaFacturaProveedor
        '
        Me.lblDisplayFechaFacturaProveedor.AutoSize = True
        Me.lblDisplayFechaFacturaProveedor.Location = New System.Drawing.Point(686, 16)
        Me.lblDisplayFechaFacturaProveedor.Name = "lblDisplayFechaFacturaProveedor"
        Me.lblDisplayFechaFacturaProveedor.Size = New System.Drawing.Size(88, 13)
        Me.lblDisplayFechaFacturaProveedor.TabIndex = 347
        Me.lblDisplayFechaFacturaProveedor.Text = "Fec. proveedor  :"
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(773, 36)
        Me.dtpFechaVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(206, 20)
        Me.dtpFechaVencimiento.TabIndex = 5
        '
        'LblDisplayVencimiento
        '
        Me.LblDisplayVencimiento.AutoSize = True
        Me.LblDisplayVencimiento.Location = New System.Drawing.Point(686, 40)
        Me.LblDisplayVencimiento.Name = "LblDisplayVencimiento"
        Me.LblDisplayVencimiento.Size = New System.Drawing.Size(88, 13)
        Me.LblDisplayVencimiento.TabIndex = 340
        Me.LblDisplayVencimiento.Text = "Fec. prog. pago :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(39, 35)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayConcepto.TabIndex = 339
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(104, 32)
        Me.TxtConcepto.MaxLength = 1000
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConcepto.Size = New System.Drawing.Size(576, 36)
        Me.TxtConcepto.TabIndex = 4
        '
        'lblDisplayEmbarque
        '
        Me.lblDisplayEmbarque.AutoSize = True
        Me.lblDisplayEmbarque.Location = New System.Drawing.Point(358, 16)
        Me.lblDisplayEmbarque.Name = "lblDisplayEmbarque"
        Me.lblDisplayEmbarque.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplayEmbarque.TabIndex = 338
        Me.lblDisplayEmbarque.Text = "Embarque :"
        '
        'gbCompraProveedor
        '
        Me.gbCompraProveedor.Controls.Add(Me.btnActualizaConcepto)
        Me.gbCompraProveedor.Controls.Add(Me.Label3)
        Me.gbCompraProveedor.Controls.Add(Me.Label2)
        Me.gbCompraProveedor.Controls.Add(Me.GridActivos)
        Me.gbCompraProveedor.Controls.Add(Me.Label1)
        Me.gbCompraProveedor.Controls.Add(Me.ckbDolares)
        Me.gbCompraProveedor.Controls.Add(Me.txtImporteDolares)
        Me.gbCompraProveedor.Controls.Add(Me.txtTipoCambio)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayTipoCambio)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayRetencion)
        Me.gbCompraProveedor.Controls.Add(Me.GridCuentas)
        Me.gbCompraProveedor.Controls.Add(Me.btnRegresar)
        Me.gbCompraProveedor.Controls.Add(Me.txtPorciento)
        Me.gbCompraProveedor.Controls.Add(Me.txtTotalCompra)
        Me.gbCompraProveedor.Controls.Add(Me.TxtIVA)
        Me.gbCompraProveedor.Controls.Add(Me.TxtSubTotal)
        Me.gbCompraProveedor.Controls.Add(Me.txtEmbarque)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayFolioProveedor)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayConcepto)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayPorciento)
        Me.gbCompraProveedor.Controls.Add(Me.TxtConcepto)
        Me.gbCompraProveedor.Controls.Add(Me.DtpFechaFacturaProveedor)
        Me.gbCompraProveedor.Controls.Add(Me.TxtRetencion)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayEmbarque)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayTotal)
        Me.gbCompraProveedor.Controls.Add(Me.txtFolioProveedor)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayFechaFacturaProveedor)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayIVA)
        Me.gbCompraProveedor.Controls.Add(Me.dtpFechaVencimiento)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayVencimiento)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplaySubTotal)
        Me.gbCompraProveedor.Location = New System.Drawing.Point(12, 89)
        Me.gbCompraProveedor.Name = "gbCompraProveedor"
        Me.gbCompraProveedor.Size = New System.Drawing.Size(998, 389)
        Me.gbCompraProveedor.TabIndex = 2
        Me.gbCompraProveedor.TabStop = False
        '
        'btnActualizaConcepto
        '
        Me.btnActualizaConcepto.Location = New System.Drawing.Point(571, 8)
        Me.btnActualizaConcepto.Name = "btnActualizaConcepto"
        Me.btnActualizaConcepto.Size = New System.Drawing.Size(109, 21)
        Me.btnActualizaConcepto.TabIndex = 380
        Me.btnActualizaConcepto.Text = "Actualiza concepto"
        Me.btnActualizaConcepto.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 360
        Me.Label3.Text = "Centros de costos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 13)
        Me.Label2.TabIndex = 359
        Me.Label2.Text = "Activos y deudores diversos  :"
        '
        'GridActivos
        '
        Me.GridActivos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridActivos.CheckedImage = CType(resources.GetObject("GridActivos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridActivos.Cols = 1
        Me.GridActivos.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridActivos.DisplayRowNumber = True
        Me.GridActivos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridActivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridActivos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridActivos.Location = New System.Drawing.Point(9, 217)
        Me.GridActivos.LockButton = True
        Me.GridActivos.Name = "GridActivos"
        Me.GridActivos.Rows = 2
        Me.GridActivos.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GridActivos.Size = New System.Drawing.Size(970, 130)
        Me.GridActivos.TabIndex = 358
        Me.GridActivos.UncheckedImage = CType(resources.GetObject("GridActivos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(226, 350)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 357
        Me.Label1.Text = "Total USD"
        '
        'ckbDolares
        '
        Me.ckbDolares.AutoSize = True
        Me.ckbDolares.Location = New System.Drawing.Point(9, 366)
        Me.ckbDolares.Name = "ckbDolares"
        Me.ckbDolares.Size = New System.Drawing.Size(62, 17)
        Me.ckbDolares.TabIndex = 7
        Me.ckbDolares.Text = "Dólares"
        Me.ckbDolares.UseVisualStyleBackColor = True
        '
        'txtImporteDolares
        '
        Me.txtImporteDolares.Enabled = False
        Me.txtImporteDolares.Location = New System.Drawing.Point(175, 366)
        Me.txtImporteDolares.MaxLength = 15
        Me.txtImporteDolares.Name = "txtImporteDolares"
        Me.txtImporteDolares.Size = New System.Drawing.Size(108, 20)
        Me.txtImporteDolares.TabIndex = 355
        Me.txtImporteDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(77, 366)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(92, 20)
        Me.txtTipoCambio.TabIndex = 8
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(74, 350)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblDisplayTipoCambio.TabIndex = 356
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'GridCuentas
        '
        Me.GridCuentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCuentas.CheckedImage = CType(resources.GetObject("GridCuentas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCuentas.Cols = 1
        Me.GridCuentas.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCuentas.DisplayRowNumber = True
        Me.GridCuentas.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCuentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCuentas.Location = New System.Drawing.Point(9, 72)
        Me.GridCuentas.LockButton = True
        Me.GridCuentas.Name = "GridCuentas"
        Me.GridCuentas.Rows = 2
        Me.GridCuentas.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GridCuentas.Size = New System.Drawing.Size(970, 126)
        Me.GridCuentas.TabIndex = 6
        Me.GridCuentas.UncheckedImage = CType(resources.GetObject("GridCuentas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnRegresar
        '
        Me.btnRegresar.Location = New System.Drawing.Point(873, 362)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(108, 21)
        Me.btnRegresar.TabIndex = 14
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'txtPorciento
        '
        Me.txtPorciento.Enabled = False
        Me.txtPorciento.Location = New System.Drawing.Point(538, 366)
        Me.txtPorciento.MaxLength = 15
        Me.txtPorciento.Name = "txtPorciento"
        Me.txtPorciento.Size = New System.Drawing.Size(55, 20)
        Me.txtPorciento.TabIndex = 11
        Me.txtPorciento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCompra
        '
        Me.txtTotalCompra.Enabled = False
        Me.txtTotalCompra.Location = New System.Drawing.Point(705, 366)
        Me.txtTotalCompra.MaxLength = 15
        Me.txtTotalCompra.Name = "txtTotalCompra"
        Me.txtTotalCompra.ReadOnly = True
        Me.txtTotalCompra.Size = New System.Drawing.Size(92, 20)
        Me.txtTotalCompra.TabIndex = 13
        Me.txtTotalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIVA
        '
        Me.TxtIVA.Enabled = False
        Me.TxtIVA.Location = New System.Drawing.Point(444, 366)
        Me.TxtIVA.MaxLength = 15
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.Size = New System.Drawing.Size(92, 20)
        Me.TxtIVA.TabIndex = 10
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Location = New System.Drawing.Point(346, 366)
        Me.TxtSubTotal.MaxLength = 15
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(92, 20)
        Me.TxtSubTotal.TabIndex = 9
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmbarque
        '
        Me.txtEmbarque.Location = New System.Drawing.Point(432, 12)
        Me.txtEmbarque.MaxLength = 60
        Me.txtEmbarque.Name = "txtEmbarque"
        Me.txtEmbarque.Size = New System.Drawing.Size(102, 20)
        Me.txtEmbarque.TabIndex = 2
        '
        'lblDisplayFolioProveedor
        '
        Me.lblDisplayFolioProveedor.AutoSize = True
        Me.lblDisplayFolioProveedor.Location = New System.Drawing.Point(184, 16)
        Me.lblDisplayFolioProveedor.Name = "lblDisplayFolioProveedor"
        Me.lblDisplayFolioProveedor.Size = New System.Drawing.Size(62, 13)
        Me.lblDisplayFolioProveedor.TabIndex = 352
        Me.lblDisplayFolioProveedor.Text = "Folio prov. :"
        '
        'txtFolioProveedor
        '
        Me.txtFolioProveedor.Location = New System.Drawing.Point(250, 12)
        Me.txtFolioProveedor.MaxLength = 60
        Me.txtFolioProveedor.Name = "txtFolioProveedor"
        Me.txtFolioProveedor.Size = New System.Drawing.Size(102, 20)
        Me.txtFolioProveedor.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbEditarCostos, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1016, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(94, 22)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'Frm_CXP_Revision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 652)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbCompraProveedor)
        Me.Controls.Add(Me.gbCompras)
        Me.Controls.Add(Me.gbProveedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXP_Revision"
        Me.Text = "Gastos"
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        Me.gbCompras.ResumeLayout(False)
        Me.gbCompras.PerformLayout()
        Me.gbCompraProveedor.ResumeLayout(False)
        Me.gbCompraProveedor.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayAlmacen As System.Windows.Forms.Label
    Friend WithEvents gbProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents cboTipoGasto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTipoGasto As System.Windows.Forms.Label
    Friend WithEvents gbCompras As System.Windows.Forms.GroupBox
    Friend WithEvents GridCompras As FlexCell.Grid
    Friend WithEvents lblDisplayPorciento As System.Windows.Forms.Label
    Friend WithEvents DtpFechaFacturaProveedor As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayRetencion As System.Windows.Forms.Label
    Friend WithEvents TxtRetencion As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents LblDisplayIVA As System.Windows.Forms.Label
    Friend WithEvents LblDisplaySubTotal As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaFacturaProveedor As System.Windows.Forms.Label
    Friend WithEvents txtFolioCompra As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayVencimiento As System.Windows.Forms.Label
    Friend WithEvents LblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayEmbarque As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents gbCompraProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents LblProveedor As System.Windows.Forms.Label
    Friend WithEvents LblCuentaContableProveedor As System.Windows.Forms.Label
    Friend WithEvents LblDisplayProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioProveedor As System.Windows.Forms.Label
    Friend WithEvents txtFolioProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ckbSaldos As System.Windows.Forms.CheckBox
    Friend WithEvents lblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblMsn As System.Windows.Forms.Label
    Friend WithEvents btnContinuarCompras As System.Windows.Forms.Button
    Friend WithEvents txtTotalCompra As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPorciento As System.Windows.Forms.TextBox
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridCuentas As FlexCell.Grid
    Friend WithEvents txtImporteDolares As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTipoCambio As System.Windows.Forms.Label
    Friend WithEvents ckbDolares As System.Windows.Forms.CheckBox
    Friend WithEvents btnImprimirPoliza As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GridActivos As FlexCell.Grid
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents tsbEditarCostos As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents lblDilplayPoliza As System.Windows.Forms.Label
    Friend WithEvents btnActualizaConcepto As System.Windows.Forms.Button
End Class
