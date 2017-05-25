<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXC_Descuentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXC_Descuentos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSellarNotaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.tsbGeneraAcuseCancelacion = New System.Windows.Forms.ToolStripButton()
        Me.tsbRecuperaNotaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbFacturas = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.gbGlobal = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.btnNotaSiguiente = New System.Windows.Forms.Button()
        Me.btnNotaAnterior = New System.Windows.Forms.Button()
        Me.chkVentaPublicoGeneral = New System.Windows.Forms.CheckBox()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.TxtConcepto2 = New System.Windows.Forms.TextBox()
        Me.txtImporteDolares = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblDisplayConcepto2 = New System.Windows.Forms.Label()
        Me.lblTotalDolares = New System.Windows.Forms.Label()
        Me.ckbDolares = New System.Windows.Forms.CheckBox()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.LblDisplayFecha = New System.Windows.Forms.Label()
        Me.lblDisplayPoliza = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.LblDisplayCliente = New System.Windows.Forms.Label()
        Me.LblDisplayConcepto = New System.Windows.Forms.Label()
        Me.TxtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIEPS = New System.Windows.Forms.TextBox()
        Me.LblDisplayTotal = New System.Windows.Forms.Label()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.LblDisplaySubtotal = New System.Windows.Forms.Label()
        Me.TxtSubTotal = New System.Windows.Forms.TextBox()
        Me.LblDisplayIVA = New System.Windows.Forms.Label()
        Me.TxtImpuesto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIEPSIncluido = New System.Windows.Forms.TextBox()
        Me.btnCargarFacturas = New System.Windows.Forms.Button()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbFacturas.SuspendLayout()
        Me.gbGlobal.SuspendLayout()
        Me.gbTotales.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbSellarNotaElectronica, Me.tsbGeneraAcuseCancelacion, Me.tsbRecuperaNotaElectronica, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(868, 25)
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
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 22)
        Me.tsbCancelar.Text = " Cancelar"
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
        'tsbSellarNotaElectronica
        '
        Me.tsbSellarNotaElectronica.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbSellarNotaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSellarNotaElectronica.Name = "tsbSellarNotaElectronica"
        Me.tsbSellarNotaElectronica.Size = New System.Drawing.Size(143, 22)
        Me.tsbSellarNotaElectronica.Text = "S&ellar nota electronica"
        Me.tsbSellarNotaElectronica.Visible = False
        '
        'tsbGeneraAcuseCancelacion
        '
        Me.tsbGeneraAcuseCancelacion.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbGeneraAcuseCancelacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGeneraAcuseCancelacion.Name = "tsbGeneraAcuseCancelacion"
        Me.tsbGeneraAcuseCancelacion.Size = New System.Drawing.Size(111, 22)
        Me.tsbGeneraAcuseCancelacion.Text = "Cancelar timbre"
        Me.tsbGeneraAcuseCancelacion.Visible = False
        '
        'tsbRecuperaNotaElectronica
        '
        Me.tsbRecuperaNotaElectronica.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbRecuperaNotaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecuperaNotaElectronica.Name = "tsbRecuperaNotaElectronica"
        Me.tsbRecuperaNotaElectronica.Size = New System.Drawing.Size(169, 22)
        Me.tsbRecuperaNotaElectronica.Text = "Recupera  Nota Electronica"
        Me.tsbRecuperaNotaElectronica.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 519)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(868, 24)
        Me.StatusStripEstado.TabIndex = 241
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
        'gbFacturas
        '
        Me.gbFacturas.Controls.Add(Me.Grid)
        Me.gbFacturas.Location = New System.Drawing.Point(12, 207)
        Me.gbFacturas.Name = "gbFacturas"
        Me.gbFacturas.Size = New System.Drawing.Size(844, 189)
        Me.gbFacturas.TabIndex = 0
        Me.gbFacturas.TabStop = False
        Me.gbFacturas.Text = "Facturas"
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
        Me.Grid.Location = New System.Drawing.Point(12, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(826, 164)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.btnCargarFacturas)
        Me.gbGlobal.Controls.Add(Me.Label3)
        Me.gbGlobal.Controls.Add(Me.cboMoneda)
        Me.gbGlobal.Controls.Add(Me.btnNotaSiguiente)
        Me.gbGlobal.Controls.Add(Me.btnNotaAnterior)
        Me.gbGlobal.Controls.Add(Me.chkVentaPublicoGeneral)
        Me.gbGlobal.Controls.Add(Me.lblTipoCambio)
        Me.gbGlobal.Controls.Add(Me.TxtConcepto2)
        Me.gbGlobal.Controls.Add(Me.txtTipoCambio)
        Me.gbGlobal.Controls.Add(Me.lblDisplayConcepto2)
        Me.gbGlobal.Controls.Add(Me.LblPoliza)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFecha)
        Me.gbGlobal.Controls.Add(Me.lblDisplayPoliza)
        Me.gbGlobal.Controls.Add(Me.dtFecha)
        Me.gbGlobal.Controls.Add(Me.LblCliente)
        Me.gbGlobal.Controls.Add(Me.TxtConcepto)
        Me.gbGlobal.Controls.Add(Me.LblDisplayCliente)
        Me.gbGlobal.Controls.Add(Me.LblDisplayConcepto)
        Me.gbGlobal.Controls.Add(Me.TxtCodigoCliente)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFolio)
        Me.gbGlobal.Controls.Add(Me.TxtFolio)
        Me.gbGlobal.Controls.Add(Me.lblDisplayStatus)
        Me.gbGlobal.Controls.Add(Me.LblStatus)
        Me.gbGlobal.Location = New System.Drawing.Point(12, 28)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Size = New System.Drawing.Size(844, 173)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Datos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 376
        Me.Label3.Text = "Moneda :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Items.AddRange(New Object() {"MXN", "USD"})
        Me.cboMoneda.Location = New System.Drawing.Point(66, 95)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(83, 21)
        Me.cboMoneda.TabIndex = 375
        '
        'btnNotaSiguiente
        '
        Me.btnNotaSiguiente.Location = New System.Drawing.Point(247, 19)
        Me.btnNotaSiguiente.Name = "btnNotaSiguiente"
        Me.btnNotaSiguiente.Size = New System.Drawing.Size(54, 21)
        Me.btnNotaSiguiente.TabIndex = 374
        Me.btnNotaSiguiente.Text = ">>"
        Me.btnNotaSiguiente.UseVisualStyleBackColor = True
        '
        'btnNotaAnterior
        '
        Me.btnNotaAnterior.Location = New System.Drawing.Point(179, 19)
        Me.btnNotaAnterior.Name = "btnNotaAnterior"
        Me.btnNotaAnterior.Size = New System.Drawing.Size(54, 21)
        Me.btnNotaAnterior.TabIndex = 373
        Me.btnNotaAnterior.Text = "<<"
        Me.btnNotaAnterior.UseVisualStyleBackColor = True
        '
        'chkVentaPublicoGeneral
        '
        Me.chkVentaPublicoGeneral.AutoSize = True
        Me.chkVentaPublicoGeneral.Location = New System.Drawing.Point(66, 124)
        Me.chkVentaPublicoGeneral.Name = "chkVentaPublicoGeneral"
        Me.chkVentaPublicoGeneral.Size = New System.Drawing.Size(164, 17)
        Me.chkVentaPublicoGeneral.TabIndex = 2
        Me.chkVentaPublicoGeneral.Text = "Descuento al público general"
        Me.chkVentaPublicoGeneral.UseVisualStyleBackColor = True
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Enabled = False
        Me.lblTipoCambio.Location = New System.Drawing.Point(155, 98)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblTipoCambio.TabIndex = 302
        Me.lblTipoCambio.Text = "Tipo de cambio :"
        '
        'TxtConcepto2
        '
        Me.TxtConcepto2.Location = New System.Drawing.Point(398, 121)
        Me.TxtConcepto2.MaxLength = 160
        Me.TxtConcepto2.Name = "TxtConcepto2"
        Me.TxtConcepto2.Size = New System.Drawing.Size(440, 20)
        Me.TxtConcepto2.TabIndex = 7
        '
        'txtImporteDolares
        '
        Me.txtImporteDolares.Enabled = False
        Me.txtImporteDolares.Location = New System.Drawing.Point(325, 481)
        Me.txtImporteDolares.MaxLength = 15
        Me.txtImporteDolares.Name = "txtImporteDolares"
        Me.txtImporteDolares.Size = New System.Drawing.Size(110, 20)
        Me.txtImporteDolares.TabIndex = 5
        Me.txtImporteDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(247, 95)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(80, 20)
        Me.txtTipoCambio.TabIndex = 4
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayConcepto2
        '
        Me.lblDisplayConcepto2.AutoSize = True
        Me.lblDisplayConcepto2.Location = New System.Drawing.Point(333, 124)
        Me.lblDisplayConcepto2.Name = "lblDisplayConcepto2"
        Me.lblDisplayConcepto2.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayConcepto2.TabIndex = 320
        Me.lblDisplayConcepto2.Text = "Concepto2 :"
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.AutoSize = True
        Me.lblTotalDolares.Enabled = False
        Me.lblTotalDolares.Location = New System.Drawing.Point(230, 484)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(89, 13)
        Me.lblTotalDolares.TabIndex = 301
        Me.lblTotalDolares.Text = "Total en dólares :"
        '
        'ckbDolares
        '
        Me.ckbDolares.AutoSize = True
        Me.ckbDolares.Location = New System.Drawing.Point(162, 483)
        Me.ckbDolares.Name = "ckbDolares"
        Me.ckbDolares.Size = New System.Drawing.Size(62, 17)
        Me.ckbDolares.TabIndex = 3
        Me.ckbDolares.Text = "Dólares"
        Me.ckbDolares.UseVisualStyleBackColor = True
        '
        'LblPoliza
        '
        Me.LblPoliza.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblPoliza.Location = New System.Drawing.Point(728, 22)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(110, 13)
        Me.LblPoliza.TabIndex = 291
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(9, 74)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblDisplayFecha.TabIndex = 175
        Me.LblDisplayFecha.Text = "Fecha :"
        '
        'lblDisplayPoliza
        '
        Me.lblDisplayPoliza.AutoSize = True
        Me.lblDisplayPoliza.Location = New System.Drawing.Point(633, 21)
        Me.lblDisplayPoliza.Name = "lblDisplayPoliza"
        Me.lblDisplayPoliza.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayPoliza.TabIndex = 287
        Me.lblDisplayPoliza.Text = "Póliza :"
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(66, 70)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(215, 20)
        Me.dtFecha.TabIndex = 2
        '
        'LblCliente
        '
        Me.LblCliente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCliente.Location = New System.Drawing.Point(179, 46)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(376, 17)
        Me.LblCliente.TabIndex = 239
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(398, 95)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(440, 20)
        Me.TxtConcepto.TabIndex = 6
        '
        'LblDisplayCliente
        '
        Me.LblDisplayCliente.AutoSize = True
        Me.LblDisplayCliente.Location = New System.Drawing.Point(9, 46)
        Me.LblDisplayCliente.Name = "LblDisplayCliente"
        Me.LblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.LblDisplayCliente.TabIndex = 238
        Me.LblDisplayCliente.Text = "Cliente :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(333, 98)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayConcepto.TabIndex = 185
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(66, 43)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(105, 20)
        Me.TxtCodigoCliente.TabIndex = 1
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(9, 21)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 216
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(66, 18)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(105, 20)
        Me.TxtFolio.TabIndex = 0
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(466, 22)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 217
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(519, 22)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(36, 13)
        Me.LblStatus.TabIndex = 218
        '
        'gbTotales
        '
        Me.gbTotales.Controls.Add(Me.Label1)
        Me.gbTotales.Controls.Add(Me.txtIEPS)
        Me.gbTotales.Controls.Add(Me.LblDisplayTotal)
        Me.gbTotales.Controls.Add(Me.TxtTotal)
        Me.gbTotales.Controls.Add(Me.LblDisplaySubtotal)
        Me.gbTotales.Controls.Add(Me.TxtSubTotal)
        Me.gbTotales.Controls.Add(Me.LblDisplayIVA)
        Me.gbTotales.Controls.Add(Me.TxtImpuesto)
        Me.gbTotales.Location = New System.Drawing.Point(646, 402)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Size = New System.Drawing.Size(204, 106)
        Me.gbTotales.TabIndex = 244
        Me.gbTotales.TabStop = False
        Me.gbTotales.Text = "Totales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 322
        Me.Label1.Text = "IEPS :"
        '
        'txtIEPS
        '
        Me.txtIEPS.Enabled = False
        Me.txtIEPS.Location = New System.Drawing.Point(83, 37)
        Me.txtIEPS.MaxLength = 160
        Me.txtIEPS.Name = "txtIEPS"
        Me.txtIEPS.Size = New System.Drawing.Size(99, 20)
        Me.txtIEPS.TabIndex = 321
        Me.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayTotal
        '
        Me.LblDisplayTotal.AutoSize = True
        Me.LblDisplayTotal.Location = New System.Drawing.Point(6, 82)
        Me.LblDisplayTotal.Name = "LblDisplayTotal"
        Me.LblDisplayTotal.Size = New System.Drawing.Size(37, 13)
        Me.LblDisplayTotal.TabIndex = 320
        Me.LblDisplayTotal.Text = "Total :"
        '
        'TxtTotal
        '
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(83, 79)
        Me.TxtTotal.MaxLength = 160
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(99, 20)
        Me.TxtTotal.TabIndex = 319
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplaySubtotal
        '
        Me.LblDisplaySubtotal.AutoSize = True
        Me.LblDisplaySubtotal.Location = New System.Drawing.Point(6, 19)
        Me.LblDisplaySubtotal.Name = "LblDisplaySubtotal"
        Me.LblDisplaySubtotal.Size = New System.Drawing.Size(52, 13)
        Me.LblDisplaySubtotal.TabIndex = 318
        Me.LblDisplaySubtotal.Text = "Subtotal :"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Enabled = False
        Me.TxtSubTotal.Location = New System.Drawing.Point(83, 16)
        Me.TxtSubTotal.MaxLength = 160
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(99, 20)
        Me.TxtSubTotal.TabIndex = 317
        Me.TxtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayIVA
        '
        Me.LblDisplayIVA.AutoSize = True
        Me.LblDisplayIVA.Location = New System.Drawing.Point(6, 61)
        Me.LblDisplayIVA.Name = "LblDisplayIVA"
        Me.LblDisplayIVA.Size = New System.Drawing.Size(56, 13)
        Me.LblDisplayIVA.TabIndex = 316
        Me.LblDisplayIVA.Text = "Impuesto :"
        '
        'TxtImpuesto
        '
        Me.TxtImpuesto.Enabled = False
        Me.TxtImpuesto.Location = New System.Drawing.Point(83, 58)
        Me.TxtImpuesto.MaxLength = 160
        Me.TxtImpuesto.Name = "TxtImpuesto"
        Me.TxtImpuesto.Size = New System.Drawing.Size(99, 20)
        Me.TxtImpuesto.TabIndex = 3
        Me.TxtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(464, 484)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 324
        Me.Label2.Text = "IEPS incluido :"
        '
        'txtIEPSIncluido
        '
        Me.txtIEPSIncluido.Enabled = False
        Me.txtIEPSIncluido.Location = New System.Drawing.Point(541, 481)
        Me.txtIEPSIncluido.MaxLength = 160
        Me.txtIEPSIncluido.Name = "txtIEPSIncluido"
        Me.txtIEPSIncluido.Size = New System.Drawing.Size(99, 20)
        Me.txtIEPSIncluido.TabIndex = 323
        Me.txtIEPSIncluido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCargarFacturas
        '
        Me.btnCargarFacturas.Location = New System.Drawing.Point(66, 143)
        Me.btnCargarFacturas.Name = "btnCargarFacturas"
        Me.btnCargarFacturas.Size = New System.Drawing.Size(164, 23)
        Me.btnCargarFacturas.TabIndex = 377
        Me.btnCargarFacturas.Text = "Cargar facturas"
        Me.btnCargarFacturas.UseVisualStyleBackColor = True
        '
        'Frm_CXC_Descuentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 543)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIEPSIncluido)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.gbFacturas)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.txtImporteDolares)
        Me.Controls.Add(Me.lblTotalDolares)
        Me.Controls.Add(Me.ckbDolares)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Frm_CXC_Descuentos"
        Me.Text = "Descuentos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbFacturas.ResumeLayout(False)
        Me.gbGlobal.ResumeLayout(False)
        Me.gbGlobal.PerformLayout()
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbFacturas As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents gbGlobal As System.Windows.Forms.GroupBox
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents LblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPoliza As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto2 As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayConcepto2 As System.Windows.Forms.Label
    Friend WithEvents gbTotales As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplaySubtotal As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayIVA As System.Windows.Forms.Label
    Friend WithEvents TxtImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtImporteDolares As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDolares As System.Windows.Forms.Label
    Friend WithEvents ckbDolares As System.Windows.Forms.CheckBox
    Friend WithEvents tsbSellarNotaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkVentaPublicoGeneral As System.Windows.Forms.CheckBox
    Friend WithEvents tsbRecuperaNotaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGeneraAcuseCancelacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNotaSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnNotaAnterior As System.Windows.Forms.Button
    Friend WithEvents txtIEPS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIEPSIncluido As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents btnCargarFacturas As System.Windows.Forms.Button
End Class
