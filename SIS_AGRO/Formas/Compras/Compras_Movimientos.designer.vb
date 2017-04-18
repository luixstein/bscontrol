<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compras_Movimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Compras_Movimientos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.chkImprimirDolares = New System.Windows.Forms.CheckBox()
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
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbPasarOrdenACompra = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditarCostos = New System.Windows.Forms.ToolStripButton()
        Me.txtSaldoMXP = New System.Windows.Forms.TextBox()
        Me.lblDisplaySaldoMXP = New System.Windows.Forms.Label()
        Me.LblDisplayRetencion = New System.Windows.Forms.Label()
        Me.TxtRetencion = New System.Windows.Forms.TextBox()
        Me.LblDisplayTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.MaskedTextBox()
        Me.LblDisplayIVA = New System.Windows.Forms.Label()
        Me.LblDisplaySubTotal = New System.Windows.Forms.Label()
        Me.TxtSubTotal = New System.Windows.Forms.MaskedTextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.lblIVAcalculado = New System.Windows.Forms.Label()
        Me.txtIVAUSD = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalUSD = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtSubTotalUSD = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbUSD = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grid = New FlexCell.Grid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridSeries = New FlexCell.Grid()
        Me.btnSeries = New System.Windows.Forms.Button()
        Me.txtSaldoUSD = New System.Windows.Forms.TextBox()
        Me.lblDisplaySaldoUSD = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSeleccionarArchivoSeries = New System.Windows.Forms.Button()
        Me.txtIEPS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbUSD.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblProveedor)
        Me.GroupBox1.Controls.Add(Me.btnActualizaConcepto)
        Me.GroupBox1.Controls.Add(Me.btnDocumentoSiguiente)
        Me.GroupBox1.Controls.Add(Me.btnDocumentoAnterior)
        Me.GroupBox1.Controls.Add(Me.BtnActualizaFolioProv)
        Me.GroupBox1.Controls.Add(Me.LblPoliza)
        Me.GroupBox1.Controls.Add(Me.DtpFechaFacturaProveedor)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFechaFacturaProveedor)
        Me.GroupBox1.Controls.Add(Me.txtConfirmo)
        Me.GroupBox1.Controls.Add(Me.lblDisplayConfirmo)
        Me.GroupBox1.Controls.Add(Me.txtPredio)
        Me.GroupBox1.Controls.Add(Me.lblDisplayPredio)
        Me.GroupBox1.Controls.Add(Me.txtConCargoA)
        Me.GroupBox1.Controls.Add(Me.lblDisplayConCargoA)
        Me.GroupBox1.Controls.Add(Me.txtFolioCompra)
        Me.GroupBox1.Controls.Add(Me.LblDisplayTipoCambio)
        Me.GroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox1.Controls.Add(Me.chkImprimirDolares)
        Me.GroupBox1.Controls.Add(Me.lblDilplayPoliza)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.lblDisplayStatus)
        Me.GroupBox1.Controls.Add(Me.dtpFechaVencimiento)
        Me.GroupBox1.Controls.Add(Me.LblDisplayVencimiento)
        Me.GroupBox1.Controls.Add(Me.LblDisplayConcepto)
        Me.GroupBox1.Controls.Add(Me.TxtConcepto)
        Me.GroupBox1.Controls.Add(Me.txtFolioProveedor)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFolioProveedor)
        Me.GroupBox1.Controls.Add(Me.txtSolicito)
        Me.GroupBox1.Controls.Add(Me.LblDisplaySolicito)
        Me.GroupBox1.Controls.Add(Me.txtEntregarA)
        Me.GroupBox1.Controls.Add(Me.LblDisplayEntregarA)
        Me.GroupBox1.Controls.Add(Me.txtPlazo)
        Me.GroupBox1.Controls.Add(Me.LblDisplayPlazo)
        Me.GroupBox1.Controls.Add(Me.txtFolioOC)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFolioOC)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.LblDisplayProveedor)
        Me.GroupBox1.Controls.Add(Me.DtpFecha)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFecha)
        Me.GroupBox1.Controls.Add(Me.CboAlmacen)
        Me.GroupBox1.Controls.Add(Me.LblDisplayAlmacen)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFolio)
        Me.GroupBox1.Controls.Add(Me.CboDocumento)
        Me.GroupBox1.Controls.Add(Me.LblDisplayDocumento)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1019, 211)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
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
        Me.btnActualizaConcepto.Enabled = False
        Me.btnActualizaConcepto.Location = New System.Drawing.Point(904, 100)
        Me.btnActualizaConcepto.Name = "btnActualizaConcepto"
        Me.btnActualizaConcepto.Size = New System.Drawing.Size(109, 21)
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
        Me.LblDisplayTipoCambio.Location = New System.Drawing.Point(131, 126)
        Me.LblDisplayTipoCambio.Name = "LblDisplayTipoCambio"
        Me.LblDisplayTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.LblDisplayTipoCambio.TabIndex = 317
        Me.LblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(223, 123)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(90, 20)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkImprimirDolares
        '
        Me.chkImprimirDolares.AutoSize = True
        Me.chkImprimirDolares.Location = New System.Drawing.Point(9, 125)
        Me.chkImprimirDolares.Name = "chkImprimirDolares"
        Me.chkImprimirDolares.Size = New System.Drawing.Size(102, 17)
        Me.chkImprimirDolares.TabIndex = 6
        Me.chkImprimirDolares.Text = "Es en dólares  ?"
        Me.chkImprimirDolares.UseVisualStyleBackColor = True
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
        Me.LblEstatus.Location = New System.Drawing.Point(739, 90)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(13, 13)
        Me.LblEstatus.TabIndex = 298
        Me.LblEstatus.Text = "_"
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(665, 90)
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
        Me.txtSolicito.Location = New System.Drawing.Point(80, 163)
        Me.txtSolicito.MaxLength = 80
        Me.txtSolicito.Name = "txtSolicito"
        Me.txtSolicito.Size = New System.Drawing.Size(233, 20)
        Me.txtSolicito.TabIndex = 9
        '
        'LblDisplaySolicito
        '
        Me.LblDisplaySolicito.AutoSize = True
        Me.LblDisplaySolicito.Location = New System.Drawing.Point(6, 166)
        Me.LblDisplaySolicito.Name = "LblDisplaySolicito"
        Me.LblDisplaySolicito.Size = New System.Drawing.Size(47, 13)
        Me.LblDisplaySolicito.TabIndex = 290
        Me.LblDisplaySolicito.Text = "Solicitó :"
        '
        'txtEntregarA
        '
        Me.txtEntregarA.Location = New System.Drawing.Point(80, 143)
        Me.txtEntregarA.MaxLength = 80
        Me.txtEntregarA.Name = "txtEntregarA"
        Me.txtEntregarA.Size = New System.Drawing.Size(233, 20)
        Me.txtEntregarA.TabIndex = 8
        '
        'LblDisplayEntregarA
        '
        Me.LblDisplayEntregarA.AutoSize = True
        Me.LblDisplayEntregarA.Location = New System.Drawing.Point(6, 145)
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
        'tsbAplicar
        '
        Me.tsbAplicar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(64, 22)
        Me.tsbAplicar.Text = "&Aplicar"
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbAplicar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbSalir, Me.tsbPasarOrdenACompra, Me.tsbEditarCostos})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1029, 25)
        Me.tsMenu.TabIndex = 3
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 22)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbPasarOrdenACompra
        '
        Me.tsbPasarOrdenACompra.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbPasarOrdenACompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPasarOrdenACompra.Name = "tsbPasarOrdenACompra"
        Me.tsbPasarOrdenACompra.Size = New System.Drawing.Size(108, 22)
        Me.tsbPasarOrdenACompra.Text = "&Pasar a compra"
        '
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(94, 22)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'txtSaldoMXP
        '
        Me.txtSaldoMXP.Location = New System.Drawing.Point(917, 486)
        Me.txtSaldoMXP.Name = "txtSaldoMXP"
        Me.txtSaldoMXP.ReadOnly = True
        Me.txtSaldoMXP.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoMXP.TabIndex = 19
        Me.txtSaldoMXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldoMXP
        '
        Me.lblDisplaySaldoMXP.AutoSize = True
        Me.lblDisplaySaldoMXP.Location = New System.Drawing.Point(853, 490)
        Me.lblDisplaySaldoMXP.Name = "lblDisplaySaldoMXP"
        Me.lblDisplaySaldoMXP.Size = New System.Drawing.Size(66, 13)
        Me.lblDisplaySaldoMXP.TabIndex = 313
        Me.lblDisplaySaldoMXP.Text = "Saldo MXP :"
        '
        'LblDisplayRetencion
        '
        Me.LblDisplayRetencion.AutoSize = True
        Me.LblDisplayRetencion.Location = New System.Drawing.Point(631, 500)
        Me.LblDisplayRetencion.Name = "LblDisplayRetencion"
        Me.LblDisplayRetencion.Size = New System.Drawing.Size(62, 13)
        Me.LblDisplayRetencion.TabIndex = 312
        Me.LblDisplayRetencion.Text = "Retención :"
        '
        'TxtRetencion
        '
        Me.TxtRetencion.Enabled = False
        Me.TxtRetencion.Location = New System.Drawing.Point(709, 497)
        Me.TxtRetencion.MaxLength = 15
        Me.TxtRetencion.Name = "TxtRetencion"
        Me.TxtRetencion.Size = New System.Drawing.Size(100, 20)
        Me.TxtRetencion.TabIndex = 2
        Me.TxtRetencion.Text = "0"
        Me.TxtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayTotal
        '
        Me.LblDisplayTotal.AutoSize = True
        Me.LblDisplayTotal.Location = New System.Drawing.Point(656, 524)
        Me.LblDisplayTotal.Name = "LblDisplayTotal"
        Me.LblDisplayTotal.Size = New System.Drawing.Size(37, 13)
        Me.LblDisplayTotal.TabIndex = 309
        Me.LblDisplayTotal.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(709, 521)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 18
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayIVA
        '
        Me.LblDisplayIVA.AutoSize = True
        Me.LblDisplayIVA.Location = New System.Drawing.Point(654, 476)
        Me.LblDisplayIVA.Name = "LblDisplayIVA"
        Me.LblDisplayIVA.Size = New System.Drawing.Size(39, 13)
        Me.LblDisplayIVA.TabIndex = 307
        Me.LblDisplayIVA.Text = "I.V.A. :"
        '
        'LblDisplaySubTotal
        '
        Me.LblDisplaySubTotal.AutoSize = True
        Me.LblDisplaySubTotal.Location = New System.Drawing.Point(637, 452)
        Me.LblDisplaySubTotal.Name = "LblDisplaySubTotal"
        Me.LblDisplaySubTotal.Size = New System.Drawing.Size(56, 13)
        Me.LblDisplaySubTotal.TabIndex = 305
        Me.LblDisplaySubTotal.Text = "SubTotal :"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Location = New System.Drawing.Point(709, 449)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.ReadOnly = True
        Me.TxtSubTotal.Size = New System.Drawing.Size(100, 20)
        Me.TxtSubTotal.TabIndex = 15
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 546)
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
        Me.txtIVA.Location = New System.Drawing.Point(709, 473)
        Me.txtIVA.MaxLength = 80
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(100, 20)
        Me.txtIVA.TabIndex = 330
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIVAcalculado
        '
        Me.lblIVAcalculado.AutoSize = True
        Me.lblIVAcalculado.Location = New System.Drawing.Point(815, 476)
        Me.lblIVAcalculado.Name = "lblIVAcalculado"
        Me.lblIVAcalculado.Size = New System.Drawing.Size(22, 13)
        Me.lblIVAcalculado.TabIndex = 331
        Me.lblIVAcalculado.Text = "0.0"
        '
        'txtIVAUSD
        '
        Me.txtIVAUSD.Location = New System.Drawing.Point(83, 37)
        Me.txtIVAUSD.MaxLength = 80
        Me.txtIVAUSD.Name = "txtIVAUSD"
        Me.txtIVAUSD.ReadOnly = True
        Me.txtIVAUSD.Size = New System.Drawing.Size(100, 20)
        Me.txtIVAUSD.TabIndex = 337
        Me.txtIVAUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 336
        Me.Label1.Text = "Total :"
        '
        'txtTotalUSD
        '
        Me.txtTotalUSD.Location = New System.Drawing.Point(83, 64)
        Me.txtTotalUSD.Name = "txtTotalUSD"
        Me.txtTotalUSD.ReadOnly = True
        Me.txtTotalUSD.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalUSD.TabIndex = 333
        Me.txtTotalUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 335
        Me.Label2.Text = "I.V.A. :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 334
        Me.Label3.Text = "SubTotal :"
        '
        'TxtSubTotalUSD
        '
        Me.TxtSubTotalUSD.Location = New System.Drawing.Point(83, 13)
        Me.TxtSubTotalUSD.Name = "TxtSubTotalUSD"
        Me.TxtSubTotalUSD.ReadOnly = True
        Me.TxtSubTotalUSD.Size = New System.Drawing.Size(100, 20)
        Me.TxtSubTotalUSD.TabIndex = 332
        Me.TxtSubTotalUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(601, 448)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 339
        Me.Label5.Text = "MPX"
        '
        'gbUSD
        '
        Me.gbUSD.Controls.Add(Me.txtIVAUSD)
        Me.gbUSD.Controls.Add(Me.TxtSubTotalUSD)
        Me.gbUSD.Controls.Add(Me.Label3)
        Me.gbUSD.Controls.Add(Me.Label2)
        Me.gbUSD.Controls.Add(Me.Label1)
        Me.gbUSD.Controls.Add(Me.txtTotalUSD)
        Me.gbUSD.Location = New System.Drawing.Point(375, 453)
        Me.gbUSD.Name = "gbUSD"
        Me.gbUSD.Size = New System.Drawing.Size(200, 90)
        Me.gbUSD.TabIndex = 340
        Me.gbUSD.TabStop = False
        Me.gbUSD.Text = "USD"
        Me.gbUSD.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 245)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1019, 204)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1011, 178)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Artículos"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.Grid.Location = New System.Drawing.Point(1, 6)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 6
        Me.Grid.Size = New System.Drawing.Size(998, 166)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridSeries)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1011, 178)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Series"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GridSeries
        '
        Me.GridSeries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridSeries.CheckedImage = CType(resources.GetObject("GridSeries.CheckedImage"), System.Drawing.Bitmap)
        Me.GridSeries.Cols = 1
        Me.GridSeries.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
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
        Me.btnSeries.Location = New System.Drawing.Point(49, 461)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(109, 32)
        Me.btnSeries.TabIndex = 380
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        '
        'txtSaldoUSD
        '
        Me.txtSaldoUSD.Location = New System.Drawing.Point(917, 512)
        Me.txtSaldoUSD.Name = "txtSaldoUSD"
        Me.txtSaldoUSD.ReadOnly = True
        Me.txtSaldoUSD.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoUSD.TabIndex = 381
        Me.txtSaldoUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldoUSD
        '
        Me.lblDisplaySaldoUSD.AutoSize = True
        Me.lblDisplaySaldoUSD.Location = New System.Drawing.Point(853, 516)
        Me.lblDisplaySaldoUSD.Name = "lblDisplaySaldoUSD"
        Me.lblDisplaySaldoUSD.Size = New System.Drawing.Size(66, 13)
        Me.lblDisplaySaldoUSD.TabIndex = 382
        Me.lblDisplaySaldoUSD.Text = "Saldo USD :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSeleccionarArchivoSeries
        '
        Me.btnSeleccionarArchivoSeries.Enabled = False
        Me.btnSeleccionarArchivoSeries.Location = New System.Drawing.Point(49, 506)
        Me.btnSeleccionarArchivoSeries.Name = "btnSeleccionarArchivoSeries"
        Me.btnSeleccionarArchivoSeries.Size = New System.Drawing.Size(165, 32)
        Me.btnSeleccionarArchivoSeries.TabIndex = 383
        Me.btnSeleccionarArchivoSeries.Text = "Seleccionar archivo con series"
        Me.btnSeleccionarArchivoSeries.UseVisualStyleBackColor = True
        '
        'txtIEPS
        '
        Me.txtIEPS.Location = New System.Drawing.Point(917, 449)
        Me.txtIEPS.MaxLength = 80
        Me.txtIEPS.Name = "txtIEPS"
        Me.txtIEPS.ReadOnly = True
        Me.txtIEPS.Size = New System.Drawing.Size(100, 20)
        Me.txtIEPS.TabIndex = 385
        Me.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(853, 452)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 384
        Me.Label4.Text = "IEPS :"
        '
        'Compras_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 570)
        Me.Controls.Add(Me.txtIEPS)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnSeleccionarArchivoSeries)
        Me.Controls.Add(Me.txtSaldoUSD)
        Me.Controls.Add(Me.lblDisplaySaldoUSD)
        Me.Controls.Add(Me.btnSeries)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbUSD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblIVAcalculado)
        Me.Controls.Add(Me.txtIVA)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.txtSaldoMXP)
        Me.Controls.Add(Me.lblDisplaySaldoMXP)
        Me.Controls.Add(Me.LblDisplayRetencion)
        Me.Controls.Add(Me.TxtRetencion)
        Me.Controls.Add(Me.LblDisplayTotal)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.LblDisplayIVA)
        Me.Controls.Add(Me.LblDisplaySubTotal)
        Me.Controls.Add(Me.TxtSubTotal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Compras_Movimientos"
        Me.Text = "Compras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbUSD.ResumeLayout(False)
        Me.gbUSD.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents txtSolicito As System.Windows.Forms.TextBox
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
    Friend WithEvents txtSaldoMXP As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySaldoMXP As System.Windows.Forms.Label
    Friend WithEvents LblDisplayRetencion As System.Windows.Forms.Label
    Friend WithEvents TxtRetencion As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LblDisplayIVA As System.Windows.Forms.Label
    Friend WithEvents LblDisplaySubTotal As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chkImprimirDolares As System.Windows.Forms.CheckBox
    Friend WithEvents LblDisplayTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtFolioCompra As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtConfirmo As System.Windows.Forms.TextBox
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
    Friend WithEvents txtIVAUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalUSD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotalUSD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbUSD As System.Windows.Forms.GroupBox
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents tsbPasarOrdenACompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditarCostos As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizaConcepto As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GridSeries As FlexCell.Grid
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents btnSeries As System.Windows.Forms.Button
    Friend WithEvents txtSaldoUSD As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySaldoUSD As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSeleccionarArchivoSeries As System.Windows.Forms.Button
    Friend WithEvents txtIEPS As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
