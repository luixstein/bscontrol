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
        Me.LblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.LblNombreAlmacen = New System.Windows.Forms.Label()
        Me.TxtCodigoAlmacen = New System.Windows.Forms.TextBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayEstatus = New System.Windows.Forms.Label()
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
        Me.TxtRetencionIVA = New System.Windows.Forms.TextBox()
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRetencionISR = New System.Windows.Forms.TextBox()
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
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAgregarXML = New System.Windows.Forms.ToolStripButton()
        Me.tsbAgregarPDF = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gbFacturasRelacionadas = New System.Windows.Forms.GroupBox()
        Me.btnGrabaDetalleVenta = New System.Windows.Forms.Button()
        Me.lblTotalFacturasRelacionadas = New System.Windows.Forms.Label()
        Me.LblDisplayTotalGasto = New System.Windows.Forms.Label()
        Me.chkPromediarGasto = New System.Windows.Forms.CheckBox()
        Me.GridFacturasRelacionadas = New FlexCell.Grid()
        Me.StatusStripEstatus = New System.Windows.Forms.StatusStrip()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbProveedor.SuspendLayout()
        Me.gbCompras.SuspendLayout()
        Me.gbCompraProveedor.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbFacturasRelacionadas.SuspendLayout()
        Me.StatusStripEstatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblDisplayAlmacen
        '
        Me.LblDisplayAlmacen.AutoSize = True
        Me.LblDisplayAlmacen.Location = New System.Drawing.Point(8, 20)
        Me.LblDisplayAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayAlmacen.Name = "LblDisplayAlmacen"
        Me.LblDisplayAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.LblDisplayAlmacen.TabIndex = 283
        Me.LblDisplayAlmacen.Text = "Almacén :"
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.LblNombreAlmacen)
        Me.gbProveedor.Controls.Add(Me.TxtCodigoAlmacen)
        Me.gbProveedor.Controls.Add(Me.lblEstatus)
        Me.gbProveedor.Controls.Add(Me.lblDisplayEstatus)
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
        Me.gbProveedor.Controls.Add(Me.LblDisplayAlmacen)
        Me.gbProveedor.Controls.Add(Me.txtFolioCompra)
        Me.gbProveedor.Controls.Add(Me.LblDisplayFolio)
        Me.gbProveedor.Location = New System.Drawing.Point(16, 30)
        Me.gbProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Padding = New System.Windows.Forms.Padding(4)
        Me.gbProveedor.Size = New System.Drawing.Size(1331, 79)
        Me.gbProveedor.TabIndex = 1
        Me.gbProveedor.TabStop = False
        '
        'LblNombreAlmacen
        '
        Me.LblNombreAlmacen.AutoSize = True
        Me.LblNombreAlmacen.Location = New System.Drawing.Point(142, 20)
        Me.LblNombreAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreAlmacen.Name = "LblNombreAlmacen"
        Me.LblNombreAlmacen.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreAlmacen.TabIndex = 386
        Me.LblNombreAlmacen.Text = "_"
        '
        'TxtCodigoAlmacen
        '
        Me.TxtCodigoAlmacen.Location = New System.Drawing.Point(92, 17)
        Me.TxtCodigoAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoAlmacen.MaxLength = 15
        Me.TxtCodigoAlmacen.Name = "TxtCodigoAlmacen"
        Me.TxtCodigoAlmacen.Size = New System.Drawing.Size(42, 22)
        Me.TxtCodigoAlmacen.TabIndex = 1
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(1065, 20)
        Me.lblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(16, 17)
        Me.lblEstatus.TabIndex = 384
        Me.lblEstatus.Text = "_"
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(995, 20)
        Me.lblDisplayEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayEstatus.TabIndex = 383
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(276, 47)
        Me.btnDocumentoSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoSiguiente.TabIndex = 380
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(1232, 20)
        Me.LblPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(16, 17)
        Me.LblPoliza.TabIndex = 382
        Me.LblPoliza.TabStop = True
        Me.LblPoliza.Text = "_"
        '
        'lblDilplayPoliza
        '
        Me.lblDilplayPoliza.AutoSize = True
        Me.lblDilplayPoliza.Location = New System.Drawing.Point(1161, 20)
        Me.lblDilplayPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDilplayPoliza.Name = "lblDilplayPoliza"
        Me.lblDilplayPoliza.Size = New System.Drawing.Size(54, 17)
        Me.lblDilplayPoliza.TabIndex = 381
        Me.lblDilplayPoliza.Text = "Póliza :"
        '
        'LblProveedor
        '
        Me.LblProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblProveedor.Location = New System.Drawing.Point(617, 52)
        Me.LblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(325, 16)
        Me.LblProveedor.TabIndex = 294
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(239, 47)
        Me.btnDocumentoAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoAnterior.TabIndex = 379
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'LblCuentaContableProveedor
        '
        Me.LblCuentaContableProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCuentaContableProveedor.Location = New System.Drawing.Point(788, 20)
        Me.LblCuentaContableProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuentaContableProveedor.Name = "LblCuentaContableProveedor"
        Me.LblCuentaContableProveedor.Size = New System.Drawing.Size(197, 16)
        Me.LblCuentaContableProveedor.TabIndex = 292
        '
        'LblDisplayProveedor
        '
        Me.LblDisplayProveedor.AutoSize = True
        Me.LblDisplayProveedor.Location = New System.Drawing.Point(387, 52)
        Me.LblDisplayProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayProveedor.Name = "LblDisplayProveedor"
        Me.LblDisplayProveedor.Size = New System.Drawing.Size(82, 17)
        Me.LblDisplayProveedor.TabIndex = 293
        Me.LblDisplayProveedor.Text = "Proveedor :"
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(499, 47)
        Me.TxtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoProveedor.MaxLength = 8
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoProveedor.TabIndex = 2
        '
        'btnContinuar
        '
        Me.btnContinuar.Location = New System.Drawing.Point(1104, 47)
        Me.btnContinuar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(144, 26)
        Me.btnContinuar.TabIndex = 4
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'cboTipoGasto
        '
        Me.cboTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoGasto.FormattingEnabled = True
        Me.cboTipoGasto.Location = New System.Drawing.Point(499, 15)
        Me.cboTipoGasto.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoGasto.Name = "cboTipoGasto"
        Me.cboTipoGasto.Size = New System.Drawing.Size(280, 24)
        Me.cboTipoGasto.TabIndex = 3
        '
        'lblDisplayTipoGasto
        '
        Me.lblDisplayTipoGasto.AutoSize = True
        Me.lblDisplayTipoGasto.Location = New System.Drawing.Point(387, 20)
        Me.lblDisplayTipoGasto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoGasto.Name = "lblDisplayTipoGasto"
        Me.lblDisplayTipoGasto.Size = New System.Drawing.Size(103, 17)
        Me.lblDisplayTipoGasto.TabIndex = 284
        Me.lblDisplayTipoGasto.Text = "Tipo de gasto :"
        '
        'txtFolioCompra
        '
        Me.txtFolioCompra.Location = New System.Drawing.Point(91, 48)
        Me.txtFolioCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioCompra.MaxLength = 15
        Me.txtFolioCompra.Name = "txtFolioCompra"
        Me.txtFolioCompra.Size = New System.Drawing.Size(135, 22)
        Me.txtFolioCompra.TabIndex = 0
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(8, 53)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 337
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'gbCompras
        '
        Me.gbCompras.BackColor = System.Drawing.SystemColors.Control
        Me.gbCompras.Controls.Add(Me.btnImprimirPoliza)
        Me.gbCompras.Controls.Add(Me.btnContinuarCompras)
        Me.gbCompras.Controls.Add(Me.LblMsn)
        Me.gbCompras.Controls.Add(Me.ckbSaldos)
        Me.gbCompras.Controls.Add(Me.lblDisplayTotales)
        Me.gbCompras.Controls.Add(Me.txtSaldo)
        Me.gbCompras.Controls.Add(Me.txtTotal)
        Me.gbCompras.Controls.Add(Me.GridCompras)
        Me.gbCompras.Location = New System.Drawing.Point(-7, 0)
        Me.gbCompras.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCompras.Name = "gbCompras"
        Me.gbCompras.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCompras.Size = New System.Drawing.Size(1331, 204)
        Me.gbCompras.TabIndex = 2
        Me.gbCompras.TabStop = False
        Me.gbCompras.Text = "Compras hechas al proveedor :"
        '
        'btnImprimirPoliza
        '
        Me.btnImprimirPoliza.Location = New System.Drawing.Point(1093, 64)
        Me.btnImprimirPoliza.Margin = New System.Windows.Forms.Padding(4)
        Me.btnImprimirPoliza.Name = "btnImprimirPoliza"
        Me.btnImprimirPoliza.Size = New System.Drawing.Size(144, 26)
        Me.btnImprimirPoliza.TabIndex = 215
        Me.btnImprimirPoliza.Text = "Imprimir poliza"
        Me.btnImprimirPoliza.UseVisualStyleBackColor = True
        '
        'btnContinuarCompras
        '
        Me.btnContinuarCompras.Location = New System.Drawing.Point(1093, 97)
        Me.btnContinuarCompras.Margin = New System.Windows.Forms.Padding(4)
        Me.btnContinuarCompras.Name = "btnContinuarCompras"
        Me.btnContinuarCompras.Size = New System.Drawing.Size(144, 26)
        Me.btnContinuarCompras.TabIndex = 0
        Me.btnContinuarCompras.Text = "Continuar"
        Me.btnContinuarCompras.UseVisualStyleBackColor = True
        '
        'LblMsn
        '
        Me.LblMsn.BackColor = System.Drawing.SystemColors.HotTrack
        Me.LblMsn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsn.ForeColor = System.Drawing.SystemColors.Window
        Me.LblMsn.Location = New System.Drawing.Point(1093, 23)
        Me.LblMsn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMsn.Name = "LblMsn"
        Me.LblMsn.Size = New System.Drawing.Size(241, 37)
        Me.LblMsn.TabIndex = 214
        Me.LblMsn.Text = "Seleccione la compra que tomó a revisión :"
        '
        'ckbSaldos
        '
        Me.ckbSaldos.AutoSize = True
        Me.ckbSaldos.Location = New System.Drawing.Point(104, 177)
        Me.ckbSaldos.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbSaldos.Name = "ckbSaldos"
        Me.ckbSaldos.Size = New System.Drawing.Size(204, 21)
        Me.ckbSaldos.TabIndex = 213
        Me.ckbSaldos.Text = "Sólo documentos con saldo"
        Me.ckbSaldos.UseVisualStyleBackColor = True
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(652, 177)
        Me.lblDisplayTotales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayTotales.TabIndex = 212
        Me.lblDisplayTotales.Text = "Totales :"
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(771, 174)
        Me.txtSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(132, 22)
        Me.txtSaldo.TabIndex = 211
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(916, 174)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(132, 22)
        Me.txtTotal.TabIndex = 210
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridCompras
        '
        Me.GridCompras.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCompras.CheckedImage = CType(resources.GetObject("GridCompras.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCompras.Cols = 1
        Me.GridCompras.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCompras.DefaultRowHeight = CType(24, Short)
        Me.GridCompras.DisplayRowNumber = True
        Me.GridCompras.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCompras.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCompras.Location = New System.Drawing.Point(12, 23)
        Me.GridCompras.LockButton = True
        Me.GridCompras.Margin = New System.Windows.Forms.Padding(4)
        Me.GridCompras.Name = "GridCompras"
        Me.GridCompras.Rows = 2
        Me.GridCompras.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridCompras.Size = New System.Drawing.Size(1073, 150)
        Me.GridCompras.TabIndex = 1
        Me.GridCompras.UncheckedImage = CType(resources.GetObject("GridCompras.UncheckedImage"), System.Drawing.Bitmap)
        '
        'lblDisplayPorciento
        '
        Me.lblDisplayPorciento.AutoSize = True
        Me.lblDisplayPorciento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayPorciento.Location = New System.Drawing.Point(737, 428)
        Me.lblDisplayPorciento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPorciento.Name = "lblDisplayPorciento"
        Me.lblDisplayPorciento.Size = New System.Drawing.Size(50, 17)
        Me.lblDisplayPorciento.TabIndex = 345
        Me.lblDisplayPorciento.Text = "% IVA"
        '
        'DtpFechaFacturaProveedor
        '
        Me.DtpFechaFacturaProveedor.Location = New System.Drawing.Point(1031, 15)
        Me.DtpFechaFacturaProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpFechaFacturaProveedor.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFechaFacturaProveedor.Name = "DtpFechaFacturaProveedor"
        Me.DtpFechaFacturaProveedor.Size = New System.Drawing.Size(273, 22)
        Me.DtpFechaFacturaProveedor.TabIndex = 3
        '
        'LblDisplayRetencion
        '
        Me.LblDisplayRetencion.AutoSize = True
        Me.LblDisplayRetencion.Location = New System.Drawing.Point(809, 428)
        Me.LblDisplayRetencion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayRetencion.Name = "LblDisplayRetencion"
        Me.LblDisplayRetencion.Size = New System.Drawing.Size(97, 17)
        Me.LblDisplayRetencion.TabIndex = 344
        Me.LblDisplayRetencion.Text = "Retención IVA"
        '
        'TxtRetencionIVA
        '
        Me.TxtRetencionIVA.Enabled = False
        Me.TxtRetencionIVA.Location = New System.Drawing.Point(809, 450)
        Me.TxtRetencionIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRetencionIVA.MaxLength = 15
        Me.TxtRetencionIVA.Name = "TxtRetencionIVA"
        Me.TxtRetencionIVA.Size = New System.Drawing.Size(100, 22)
        Me.TxtRetencionIVA.TabIndex = 12
        Me.TxtRetencionIVA.Text = "0"
        Me.TxtRetencionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayTotal
        '
        Me.LblDisplayTotal.AutoSize = True
        Me.LblDisplayTotal.Location = New System.Drawing.Point(1072, 428)
        Me.LblDisplayTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTotal.Name = "LblDisplayTotal"
        Me.LblDisplayTotal.Size = New System.Drawing.Size(83, 17)
        Me.LblDisplayTotal.TabIndex = 343
        Me.LblDisplayTotal.Text = "Total (MXP)"
        '
        'LblDisplayIVA
        '
        Me.LblDisplayIVA.AutoSize = True
        Me.LblDisplayIVA.Location = New System.Drawing.Point(651, 428)
        Me.LblDisplayIVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayIVA.Name = "LblDisplayIVA"
        Me.LblDisplayIVA.Size = New System.Drawing.Size(57, 17)
        Me.LblDisplayIVA.TabIndex = 342
        Me.LblDisplayIVA.Text = "$ I.V.A. "
        '
        'LblDisplaySubTotal
        '
        Me.LblDisplaySubTotal.AutoSize = True
        Me.LblDisplaySubTotal.Location = New System.Drawing.Point(479, 428)
        Me.LblDisplaySubTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplaySubTotal.Name = "LblDisplaySubTotal"
        Me.LblDisplaySubTotal.Size = New System.Drawing.Size(104, 17)
        Me.LblDisplaySubTotal.TabIndex = 341
        Me.LblDisplaySubTotal.Text = "SubTotal(MXP)"
        '
        'lblDisplayFechaFacturaProveedor
        '
        Me.lblDisplayFechaFacturaProveedor.AutoSize = True
        Me.lblDisplayFechaFacturaProveedor.Location = New System.Drawing.Point(915, 20)
        Me.lblDisplayFechaFacturaProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaFacturaProveedor.Name = "lblDisplayFechaFacturaProveedor"
        Me.lblDisplayFechaFacturaProveedor.Size = New System.Drawing.Size(116, 17)
        Me.lblDisplayFechaFacturaProveedor.TabIndex = 347
        Me.lblDisplayFechaFacturaProveedor.Text = "Fec. proveedor  :"
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(1031, 44)
        Me.dtpFechaVencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(273, 22)
        Me.dtpFechaVencimiento.TabIndex = 5
        '
        'LblDisplayVencimiento
        '
        Me.LblDisplayVencimiento.AutoSize = True
        Me.LblDisplayVencimiento.Location = New System.Drawing.Point(915, 49)
        Me.LblDisplayVencimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayVencimiento.Name = "LblDisplayVencimiento"
        Me.LblDisplayVencimiento.Size = New System.Drawing.Size(116, 17)
        Me.LblDisplayVencimiento.TabIndex = 340
        Me.LblDisplayVencimiento.Text = "Fec. prog. pago :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(52, 43)
        Me.LblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayConcepto.TabIndex = 339
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(139, 39)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 1000
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConcepto.Size = New System.Drawing.Size(767, 43)
        Me.TxtConcepto.TabIndex = 4
        '
        'lblDisplayEmbarque
        '
        Me.lblDisplayEmbarque.AutoSize = True
        Me.lblDisplayEmbarque.Location = New System.Drawing.Point(477, 20)
        Me.lblDisplayEmbarque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEmbarque.Name = "lblDisplayEmbarque"
        Me.lblDisplayEmbarque.Size = New System.Drawing.Size(81, 17)
        Me.lblDisplayEmbarque.TabIndex = 338
        Me.lblDisplayEmbarque.Text = "Embarque :"
        '
        'gbCompraProveedor
        '
        Me.gbCompraProveedor.Controls.Add(Me.Label4)
        Me.gbCompraProveedor.Controls.Add(Me.txtRetencionISR)
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
        Me.gbCompraProveedor.Controls.Add(Me.TxtRetencionIVA)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayEmbarque)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayTotal)
        Me.gbCompraProveedor.Controls.Add(Me.txtFolioProveedor)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayFechaFacturaProveedor)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayIVA)
        Me.gbCompraProveedor.Controls.Add(Me.dtpFechaVencimiento)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplayVencimiento)
        Me.gbCompraProveedor.Controls.Add(Me.LblDisplaySubTotal)
        Me.gbCompraProveedor.Location = New System.Drawing.Point(16, 110)
        Me.gbCompraProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCompraProveedor.Name = "gbCompraProveedor"
        Me.gbCompraProveedor.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCompraProveedor.Size = New System.Drawing.Size(1663, 479)
        Me.gbCompraProveedor.TabIndex = 2
        Me.gbCompraProveedor.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(923, 428)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 382
        Me.Label4.Text = "Retención ISR"
        '
        'txtRetencionISR
        '
        Me.txtRetencionISR.Location = New System.Drawing.Point(923, 450)
        Me.txtRetencionISR.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetencionISR.MaxLength = 15
        Me.txtRetencionISR.Name = "txtRetencionISR"
        Me.txtRetencionISR.Size = New System.Drawing.Size(100, 22)
        Me.txtRetencionISR.TabIndex = 13
        Me.txtRetencionISR.Text = "0"
        Me.txtRetencionISR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnActualizaConcepto
        '
        Me.btnActualizaConcepto.Location = New System.Drawing.Point(761, 10)
        Me.btnActualizaConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnActualizaConcepto.Name = "btnActualizaConcepto"
        Me.btnActualizaConcepto.Size = New System.Drawing.Size(145, 26)
        Me.btnActualizaConcepto.TabIndex = 380
        Me.btnActualizaConcepto.Text = "Actualiza concepto"
        Me.btnActualizaConcepto.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 360
        Me.Label3.Text = "Centros de costos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 247)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 17)
        Me.Label2.TabIndex = 359
        Me.Label2.Text = "Activos y deudores diversos  :"
        '
        'GridActivos
        '
        Me.GridActivos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridActivos.CheckedImage = CType(resources.GetObject("GridActivos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridActivos.Cols = 1
        Me.GridActivos.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridActivos.DefaultRowHeight = CType(24, Short)
        Me.GridActivos.DisplayRowNumber = True
        Me.GridActivos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridActivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridActivos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridActivos.Location = New System.Drawing.Point(12, 267)
        Me.GridActivos.LockButton = True
        Me.GridActivos.Margin = New System.Windows.Forms.Padding(4)
        Me.GridActivos.Name = "GridActivos"
        Me.GridActivos.Rows = 2
        Me.GridActivos.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GridActivos.Size = New System.Drawing.Size(1643, 160)
        Me.GridActivos.TabIndex = 358
        Me.GridActivos.UncheckedImage = CType(resources.GetObject("GridActivos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(301, 431)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 357
        Me.Label1.Text = "Total USD"
        '
        'ckbDolares
        '
        Me.ckbDolares.AutoSize = True
        Me.ckbDolares.Location = New System.Drawing.Point(12, 450)
        Me.ckbDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbDolares.Name = "ckbDolares"
        Me.ckbDolares.Size = New System.Drawing.Size(79, 21)
        Me.ckbDolares.TabIndex = 7
        Me.ckbDolares.Text = "Dólares"
        Me.ckbDolares.UseVisualStyleBackColor = True
        '
        'txtImporteDolares
        '
        Me.txtImporteDolares.Enabled = False
        Me.txtImporteDolares.Location = New System.Drawing.Point(233, 450)
        Me.txtImporteDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.txtImporteDolares.MaxLength = 15
        Me.txtImporteDolares.Name = "txtImporteDolares"
        Me.txtImporteDolares.Size = New System.Drawing.Size(143, 22)
        Me.txtImporteDolares.TabIndex = 355
        Me.txtImporteDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(103, 450)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(121, 22)
        Me.txtTipoCambio.TabIndex = 8
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(99, 431)
        Me.lblDisplayTipoCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(113, 17)
        Me.lblDisplayTipoCambio.TabIndex = 356
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'GridCuentas
        '
        Me.GridCuentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCuentas.CheckedImage = CType(resources.GetObject("GridCuentas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCuentas.Cols = 1
        Me.GridCuentas.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCuentas.DefaultRowHeight = CType(24, Short)
        Me.GridCuentas.DisplayRowNumber = True
        Me.GridCuentas.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCuentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCuentas.Location = New System.Drawing.Point(12, 89)
        Me.GridCuentas.LockButton = True
        Me.GridCuentas.Margin = New System.Windows.Forms.Padding(4)
        Me.GridCuentas.Name = "GridCuentas"
        Me.GridCuentas.Rows = 2
        Me.GridCuentas.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GridCuentas.Size = New System.Drawing.Size(1643, 155)
        Me.GridCuentas.TabIndex = 6
        Me.GridCuentas.UncheckedImage = CType(resources.GetObject("GridCuentas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnRegresar
        '
        Me.btnRegresar.Location = New System.Drawing.Point(1164, 446)
        Me.btnRegresar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(144, 26)
        Me.btnRegresar.TabIndex = 15
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'txtPorciento
        '
        Me.txtPorciento.Enabled = False
        Me.txtPorciento.Location = New System.Drawing.Point(717, 450)
        Me.txtPorciento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPorciento.MaxLength = 15
        Me.txtPorciento.Name = "txtPorciento"
        Me.txtPorciento.Size = New System.Drawing.Size(72, 22)
        Me.txtPorciento.TabIndex = 11
        Me.txtPorciento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCompra
        '
        Me.txtTotalCompra.Enabled = False
        Me.txtTotalCompra.Location = New System.Drawing.Point(1033, 450)
        Me.txtTotalCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalCompra.MaxLength = 15
        Me.txtTotalCompra.Name = "txtTotalCompra"
        Me.txtTotalCompra.ReadOnly = True
        Me.txtTotalCompra.Size = New System.Drawing.Size(121, 22)
        Me.txtTotalCompra.TabIndex = 14
        Me.txtTotalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIVA
        '
        Me.TxtIVA.Enabled = False
        Me.TxtIVA.Location = New System.Drawing.Point(592, 450)
        Me.TxtIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIVA.MaxLength = 15
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.Size = New System.Drawing.Size(121, 22)
        Me.TxtIVA.TabIndex = 10
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Location = New System.Drawing.Point(461, 450)
        Me.TxtSubTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSubTotal.MaxLength = 15
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(121, 22)
        Me.TxtSubTotal.TabIndex = 9
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmbarque
        '
        Me.txtEmbarque.Location = New System.Drawing.Point(576, 15)
        Me.txtEmbarque.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmbarque.MaxLength = 60
        Me.txtEmbarque.Name = "txtEmbarque"
        Me.txtEmbarque.Size = New System.Drawing.Size(135, 22)
        Me.txtEmbarque.TabIndex = 2
        '
        'lblDisplayFolioProveedor
        '
        Me.lblDisplayFolioProveedor.AutoSize = True
        Me.lblDisplayFolioProveedor.Location = New System.Drawing.Point(245, 20)
        Me.lblDisplayFolioProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioProveedor.Name = "lblDisplayFolioProveedor"
        Me.lblDisplayFolioProveedor.Size = New System.Drawing.Size(82, 17)
        Me.lblDisplayFolioProveedor.TabIndex = 352
        Me.lblDisplayFolioProveedor.Text = "Folio prov. :"
        '
        'txtFolioProveedor
        '
        Me.txtFolioProveedor.Location = New System.Drawing.Point(333, 15)
        Me.txtFolioProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioProveedor.MaxLength = 60
        Me.txtFolioProveedor.Name = "txtFolioProveedor"
        Me.txtFolioProveedor.Size = New System.Drawing.Size(135, 22)
        Me.txtFolioProveedor.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbEditarCostos, Me.tsbCancelar, Me.tsbAgregarXML, Me.tsbAgregarPDF, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1695, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(118, 24)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(94, 24)
        Me.tsbCancelar.Text = " Cancelar"
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 596)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1304, 231)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbCompras)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(1296, 202)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Compras"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gbFacturasRelacionadas)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Size = New System.Drawing.Size(1296, 202)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Ventas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gbFacturasRelacionadas
        '
        Me.gbFacturasRelacionadas.BackColor = System.Drawing.SystemColors.Control
        Me.gbFacturasRelacionadas.Controls.Add(Me.btnGrabaDetalleVenta)
        Me.gbFacturasRelacionadas.Controls.Add(Me.lblTotalFacturasRelacionadas)
        Me.gbFacturasRelacionadas.Controls.Add(Me.LblDisplayTotalGasto)
        Me.gbFacturasRelacionadas.Controls.Add(Me.chkPromediarGasto)
        Me.gbFacturasRelacionadas.Controls.Add(Me.GridFacturasRelacionadas)
        Me.gbFacturasRelacionadas.Location = New System.Drawing.Point(0, 0)
        Me.gbFacturasRelacionadas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbFacturasRelacionadas.Name = "gbFacturasRelacionadas"
        Me.gbFacturasRelacionadas.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbFacturasRelacionadas.Size = New System.Drawing.Size(1300, 206)
        Me.gbFacturasRelacionadas.TabIndex = 0
        Me.gbFacturasRelacionadas.TabStop = False
        Me.gbFacturasRelacionadas.Text = "Facturas relacionadas :"
        '
        'btnGrabaDetalleVenta
        '
        Me.btnGrabaDetalleVenta.Location = New System.Drawing.Point(1088, 108)
        Me.btnGrabaDetalleVenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGrabaDetalleVenta.Name = "btnGrabaDetalleVenta"
        Me.btnGrabaDetalleVenta.Size = New System.Drawing.Size(145, 39)
        Me.btnGrabaDetalleVenta.TabIndex = 385
        Me.btnGrabaDetalleVenta.Text = "Grabar"
        Me.btnGrabaDetalleVenta.UseVisualStyleBackColor = True
        '
        'lblTotalFacturasRelacionadas
        '
        Me.lblTotalFacturasRelacionadas.AutoSize = True
        Me.lblTotalFacturasRelacionadas.Location = New System.Drawing.Point(1141, 62)
        Me.lblTotalFacturasRelacionadas.Name = "lblTotalFacturasRelacionadas"
        Me.lblTotalFacturasRelacionadas.Size = New System.Drawing.Size(16, 17)
        Me.lblTotalFacturasRelacionadas.TabIndex = 384
        Me.lblTotalFacturasRelacionadas.Text = "0"
        '
        'LblDisplayTotalGasto
        '
        Me.LblDisplayTotalGasto.AutoSize = True
        Me.LblDisplayTotalGasto.Location = New System.Drawing.Point(1047, 62)
        Me.LblDisplayTotalGasto.Name = "LblDisplayTotalGasto"
        Me.LblDisplayTotalGasto.Size = New System.Drawing.Size(87, 17)
        Me.LblDisplayTotalGasto.TabIndex = 383
        Me.LblDisplayTotalGasto.Text = "Total gasto :"
        '
        'chkPromediarGasto
        '
        Me.chkPromediarGasto.AutoSize = True
        Me.chkPromediarGasto.Checked = True
        Me.chkPromediarGasto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPromediarGasto.Location = New System.Drawing.Point(1051, 22)
        Me.chkPromediarGasto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkPromediarGasto.Name = "chkPromediarGasto"
        Me.chkPromediarGasto.Size = New System.Drawing.Size(134, 21)
        Me.chkPromediarGasto.TabIndex = 382
        Me.chkPromediarGasto.Text = "Promediar gasto"
        Me.chkPromediarGasto.UseVisualStyleBackColor = True
        '
        'GridFacturasRelacionadas
        '
        Me.GridFacturasRelacionadas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridFacturasRelacionadas.CheckedImage = CType(resources.GetObject("GridFacturasRelacionadas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridFacturasRelacionadas.Cols = 1
        Me.GridFacturasRelacionadas.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridFacturasRelacionadas.DefaultRowHeight = CType(24, Short)
        Me.GridFacturasRelacionadas.DisplayRowNumber = True
        Me.GridFacturasRelacionadas.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridFacturasRelacionadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridFacturasRelacionadas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridFacturasRelacionadas.Location = New System.Drawing.Point(4, 22)
        Me.GridFacturasRelacionadas.LockButton = True
        Me.GridFacturasRelacionadas.Margin = New System.Windows.Forms.Padding(4)
        Me.GridFacturasRelacionadas.Name = "GridFacturasRelacionadas"
        Me.GridFacturasRelacionadas.Rows = 2
        Me.GridFacturasRelacionadas.Size = New System.Drawing.Size(995, 155)
        Me.GridFacturasRelacionadas.TabIndex = 381
        Me.GridFacturasRelacionadas.UncheckedImage = CType(resources.GetObject("GridFacturasRelacionadas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'StatusStripEstatus
        '
        Me.StatusStripEstatus.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstatus.Location = New System.Drawing.Point(0, 832)
        Me.StatusStripEstatus.Name = "StatusStripEstatus"
        Me.StatusStripEstatus.Padding = New System.Windows.Forms.Padding(1, 0, 13, 0)
        Me.StatusStripEstatus.Size = New System.Drawing.Size(1695, 25)
        Me.StatusStripEstatus.TabIndex = 4
        Me.StatusStripEstatus.Text = "StatusStrip1"
        '
        'tsslElaboro
        '
        Me.tsslElaboro.Name = "tsslElaboro"
        Me.tsslElaboro.Size = New System.Drawing.Size(68, 20)
        Me.tsslElaboro.Text = "Elaboró :"
        '
        'tsslCancelo
        '
        Me.tsslCancelo.Name = "tsslCancelo"
        Me.tsslCancelo.Size = New System.Drawing.Size(69, 20)
        Me.tsslCancelo.Text = "Canceló :"
        '
        'Frm_CXP_Revision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1695, 857)
        Me.Controls.Add(Me.StatusStripEstatus)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbCompraProveedor)
        Me.Controls.Add(Me.gbProveedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
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
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.gbFacturasRelacionadas.ResumeLayout(False)
        Me.gbFacturasRelacionadas.PerformLayout()
        Me.StatusStripEstatus.ResumeLayout(False)
        Me.StatusStripEstatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents TxtRetencionIVA As System.Windows.Forms.TextBox
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents gbFacturasRelacionadas As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalFacturasRelacionadas As System.Windows.Forms.Label
    Friend WithEvents LblDisplayTotalGasto As System.Windows.Forms.Label
    Friend WithEvents chkPromediarGasto As System.Windows.Forms.CheckBox
    Friend WithEvents GridFacturasRelacionadas As FlexCell.Grid
    Friend WithEvents btnGrabaDetalleVenta As System.Windows.Forms.Button
    Friend WithEvents StatusStripEstatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRetencionISR As TextBox
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAgregarXML As ToolStripButton
    Friend WithEvents tsbAgregarPDF As ToolStripButton
    Friend WithEvents TxtCodigoAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreAlmacen As System.Windows.Forms.Label
End Class
