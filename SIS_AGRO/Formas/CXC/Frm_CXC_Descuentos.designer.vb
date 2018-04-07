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
        Me.tsbTimbrar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelarTimbre = New System.Windows.Forms.ToolStripButton()
        Me.tsbRecuperarXMLPDF = New System.Windows.Forms.ToolStripButton()
        Me.tsbEnviarCorreo = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbFacturas = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.gbGlobal = New System.Windows.Forms.GroupBox()
        Me.lblVersionCFDI = New System.Windows.Forms.Label()
        Me.lblDisplayMetodoPago = New System.Windows.Forms.Label()
        Me.btnCargarFacturas = New System.Windows.Forms.Button()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMetodoPago = New System.Windows.Forms.ComboBox()
        Me.chkVentaPublicoGeneral = New System.Windows.Forms.CheckBox()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblMetodoPago = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.btnNotaSiguiente = New System.Windows.Forms.Button()
        Me.btnNotaAnterior = New System.Windows.Forms.Button()
        Me.lblDisplayTipoCambio = New System.Windows.Forms.Label()
        Me.TxtConcepto2 = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblDisplayConcepto2 = New System.Windows.Forms.Label()
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
        Me.gbDolares = New System.Windows.Forms.GroupBox()
        Me.lblTotalDolares = New System.Windows.Forms.Label()
        Me.lblSubtotalDolares = New System.Windows.Forms.Label()
        Me.lblImpuestoDolares = New System.Windows.Forms.Label()
        Me.lblDisplayTotalDolares = New System.Windows.Forms.Label()
        Me.lblDisplaySubtotalDolares = New System.Windows.Forms.Label()
        Me.lblDisplayImpuestoDolares = New System.Windows.Forms.Label()
        Me.lblImpuestoPorcentaje = New System.Windows.Forms.Label()
        Me.lblDisplayUsoCFDI = New System.Windows.Forms.Label()
        Me.cboUsoCFDI = New System.Windows.Forms.ComboBox()
        Me.cboTipoRelacionCFDI = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTipoRelacionCFDI = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbFacturas.SuspendLayout()
        Me.gbGlobal.SuspendLayout()
        Me.gbTotales.SuspendLayout()
        Me.gbDolares.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbTimbrar, Me.tsbCancelarTimbre, Me.tsbRecuperarXMLPDF, Me.tsbEnviarCorreo, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(868, 25)
        Me.tsMenu.TabIndex = 2
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
        'tsbTimbrar
        '
        Me.tsbTimbrar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbTimbrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTimbrar.Name = "tsbTimbrar"
        Me.tsbTimbrar.Size = New System.Drawing.Size(69, 22)
        Me.tsbTimbrar.Text = "Timbrar"
        Me.tsbTimbrar.Visible = False
        '
        'tsbCancelarTimbre
        '
        Me.tsbCancelarTimbre.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbCancelarTimbre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelarTimbre.Name = "tsbCancelarTimbre"
        Me.tsbCancelarTimbre.Size = New System.Drawing.Size(111, 22)
        Me.tsbCancelarTimbre.Text = "Cancelar timbre"
        Me.tsbCancelarTimbre.Visible = False
        '
        'tsbRecuperarXMLPDF
        '
        Me.tsbRecuperarXMLPDF.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbRecuperarXMLPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecuperarXMLPDF.Name = "tsbRecuperarXMLPDF"
        Me.tsbRecuperarXMLPDF.Size = New System.Drawing.Size(125, 22)
        Me.tsbRecuperarXMLPDF.Text = "Recuperar xml/pdf"
        Me.tsbRecuperarXMLPDF.Visible = False
        '
        'tsbEnviarCorreo
        '
        Me.tsbEnviarCorreo.Image = CType(resources.GetObject("tsbEnviarCorreo.Image"), System.Drawing.Image)
        Me.tsbEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarCorreo.Name = "tsbEnviarCorreo"
        Me.tsbEnviarCorreo.Size = New System.Drawing.Size(96, 22)
        Me.tsbEnviarCorreo.Text = "&Enviar correo"
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
        Me.gbFacturas.Location = New System.Drawing.Point(12, 255)
        Me.gbFacturas.Name = "gbFacturas"
        Me.gbFacturas.Size = New System.Drawing.Size(844, 141)
        Me.gbFacturas.TabIndex = 1
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
        Me.Grid.Size = New System.Drawing.Size(826, 119)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.cboTipoRelacionCFDI)
        Me.gbGlobal.Controls.Add(Me.lblDisplayTipoRelacionCFDI)
        Me.gbGlobal.Controls.Add(Me.lblVersionCFDI)
        Me.gbGlobal.Controls.Add(Me.lblDisplayMetodoPago)
        Me.gbGlobal.Controls.Add(Me.btnCargarFacturas)
        Me.gbGlobal.Controls.Add(Me.CboDocumento)
        Me.gbGlobal.Controls.Add(Me.LblDocumento)
        Me.gbGlobal.Controls.Add(Me.Label3)
        Me.gbGlobal.Controls.Add(Me.cboMetodoPago)
        Me.gbGlobal.Controls.Add(Me.chkVentaPublicoGeneral)
        Me.gbGlobal.Controls.Add(Me.cboFormaPago)
        Me.gbGlobal.Controls.Add(Me.lblMetodoPago)
        Me.gbGlobal.Controls.Add(Me.cboMoneda)
        Me.gbGlobal.Controls.Add(Me.cboUsoCFDI)
        Me.gbGlobal.Controls.Add(Me.btnNotaSiguiente)
        Me.gbGlobal.Controls.Add(Me.lblDisplayUsoCFDI)
        Me.gbGlobal.Controls.Add(Me.btnNotaAnterior)
        Me.gbGlobal.Controls.Add(Me.lblDisplayTipoCambio)
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
        Me.gbGlobal.Size = New System.Drawing.Size(844, 224)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        Me.gbGlobal.Text = "Datos"
        '
        'lblVersionCFDI
        '
        Me.lblVersionCFDI.AutoSize = True
        Me.lblVersionCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionCFDI.Location = New System.Drawing.Point(804, 178)
        Me.lblVersionCFDI.Name = "lblVersionCFDI"
        Me.lblVersionCFDI.Size = New System.Drawing.Size(34, 20)
        Me.lblVersionCFDI.TabIndex = 391
        Me.lblVersionCFDI.Text = "0.0"
        '
        'lblDisplayMetodoPago
        '
        Me.lblDisplayMetodoPago.AutoSize = True
        Me.lblDisplayMetodoPago.Location = New System.Drawing.Point(389, 120)
        Me.lblDisplayMetodoPago.Name = "lblDisplayMetodoPago"
        Me.lblDisplayMetodoPago.Size = New System.Drawing.Size(91, 13)
        Me.lblDisplayMetodoPago.TabIndex = 390
        Me.lblDisplayMetodoPago.Text = "Método de pago :"
        '
        'btnCargarFacturas
        '
        Me.btnCargarFacturas.Location = New System.Drawing.Point(12, 170)
        Me.btnCargarFacturas.Name = "btnCargarFacturas"
        Me.btnCargarFacturas.Size = New System.Drawing.Size(164, 23)
        Me.btnCargarFacturas.TabIndex = 7
        Me.btnCargarFacturas.Text = "Cargar facturas"
        Me.btnCargarFacturas.UseVisualStyleBackColor = True
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(103, 13)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(242, 21)
        Me.CboDocumento.TabIndex = 0
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(9, 17)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 379
        Me.LblDocumento.Text = "Documento :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 376
        Me.Label3.Text = "Moneda :"
        '
        'cboMetodoPago
        '
        Me.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMetodoPago.Enabled = False
        Me.cboMetodoPago.FormattingEnabled = True
        Me.cboMetodoPago.Location = New System.Drawing.Point(486, 117)
        Me.cboMetodoPago.MaxLength = 1
        Me.cboMetodoPago.Name = "cboMetodoPago"
        Me.cboMetodoPago.Size = New System.Drawing.Size(301, 21)
        Me.cboMetodoPago.TabIndex = 8
        '
        'chkVentaPublicoGeneral
        '
        Me.chkVentaPublicoGeneral.AutoSize = True
        Me.chkVentaPublicoGeneral.Location = New System.Drawing.Point(392, 147)
        Me.chkVentaPublicoGeneral.Name = "chkVentaPublicoGeneral"
        Me.chkVentaPublicoGeneral.Size = New System.Drawing.Size(164, 17)
        Me.chkVentaPublicoGeneral.TabIndex = 10
        Me.chkVentaPublicoGeneral.Text = "Descuento al público general"
        Me.chkVentaPublicoGeneral.UseVisualStyleBackColor = True
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.Enabled = False
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(103, 117)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(258, 21)
        Me.cboFormaPago.TabIndex = 7
        '
        'lblMetodoPago
        '
        Me.lblMetodoPago.AutoSize = True
        Me.lblMetodoPago.Location = New System.Drawing.Point(9, 120)
        Me.lblMetodoPago.Name = "lblMetodoPago"
        Me.lblMetodoPago.Size = New System.Drawing.Size(84, 13)
        Me.lblMetodoPago.TabIndex = 389
        Me.lblMetodoPago.Text = "Forma de pago :"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(103, 65)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(83, 21)
        Me.cboMoneda.TabIndex = 2
        '
        'btnNotaSiguiente
        '
        Me.btnNotaSiguiente.Location = New System.Drawing.Point(231, 39)
        Me.btnNotaSiguiente.Name = "btnNotaSiguiente"
        Me.btnNotaSiguiente.Size = New System.Drawing.Size(48, 21)
        Me.btnNotaSiguiente.TabIndex = 374
        Me.btnNotaSiguiente.Text = ">>"
        Me.btnNotaSiguiente.UseVisualStyleBackColor = True
        '
        'btnNotaAnterior
        '
        Me.btnNotaAnterior.Location = New System.Drawing.Point(177, 39)
        Me.btnNotaAnterior.Name = "btnNotaAnterior"
        Me.btnNotaAnterior.Size = New System.Drawing.Size(48, 21)
        Me.btnNotaAnterior.TabIndex = 373
        Me.btnNotaAnterior.Text = "<<"
        Me.btnNotaAnterior.UseVisualStyleBackColor = True
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Enabled = False
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(189, 69)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblDisplayTipoCambio.TabIndex = 302
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'TxtConcepto2
        '
        Me.TxtConcepto2.Location = New System.Drawing.Point(257, 198)
        Me.TxtConcepto2.MaxLength = 200
        Me.TxtConcepto2.Name = "TxtConcepto2"
        Me.TxtConcepto2.Size = New System.Drawing.Size(530, 20)
        Me.TxtConcepto2.TabIndex = 12
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(281, 65)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(80, 20)
        Me.txtTipoCambio.TabIndex = 3
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayConcepto2
        '
        Me.lblDisplayConcepto2.AutoSize = True
        Me.lblDisplayConcepto2.Location = New System.Drawing.Point(192, 200)
        Me.lblDisplayConcepto2.Name = "lblDisplayConcepto2"
        Me.lblDisplayConcepto2.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayConcepto2.TabIndex = 320
        Me.lblDisplayConcepto2.Text = "Concepto2 :"
        '
        'LblPoliza
        '
        Me.LblPoliza.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblPoliza.Location = New System.Drawing.Point(714, 17)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(110, 13)
        Me.LblPoliza.TabIndex = 291
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(9, 148)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblDisplayFecha.TabIndex = 175
        Me.LblDisplayFecha.Text = "Fecha :"
        '
        'lblDisplayPoliza
        '
        Me.lblDisplayPoliza.AutoSize = True
        Me.lblDisplayPoliza.Location = New System.Drawing.Point(659, 17)
        Me.lblDisplayPoliza.Name = "lblDisplayPoliza"
        Me.lblDisplayPoliza.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayPoliza.TabIndex = 287
        Me.lblDisplayPoliza.Text = "Póliza :"
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(103, 144)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(215, 20)
        Me.dtFecha.TabIndex = 9
        '
        'LblCliente
        '
        Me.LblCliente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblCliente.Location = New System.Drawing.Point(214, 95)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(376, 17)
        Me.LblCliente.TabIndex = 239
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(257, 173)
        Me.TxtConcepto.MaxLength = 200
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(530, 20)
        Me.TxtConcepto.TabIndex = 11
        '
        'LblDisplayCliente
        '
        Me.LblDisplayCliente.AutoSize = True
        Me.LblDisplayCliente.Location = New System.Drawing.Point(9, 95)
        Me.LblDisplayCliente.Name = "LblDisplayCliente"
        Me.LblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.LblDisplayCliente.TabIndex = 238
        Me.LblDisplayCliente.Text = "Cliente :"
        '
        'LblDisplayConcepto
        '
        Me.LblDisplayConcepto.AutoSize = True
        Me.LblDisplayConcepto.Location = New System.Drawing.Point(192, 175)
        Me.LblDisplayConcepto.Name = "LblDisplayConcepto"
        Me.LblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayConcepto.TabIndex = 185
        Me.LblDisplayConcepto.Text = "Concepto :"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(103, 92)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(105, 20)
        Me.TxtCodigoCliente.TabIndex = 6
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(9, 43)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 216
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(103, 40)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(105, 20)
        Me.TxtFolio.TabIndex = 1
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(561, 17)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 217
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(616, 17)
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
        Me.gbTotales.Text = "Total MXN :"
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
        Me.Label2.Location = New System.Drawing.Point(464, 442)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 324
        Me.Label2.Text = "IEPS incluido :"
        '
        'txtIEPSIncluido
        '
        Me.txtIEPSIncluido.Enabled = False
        Me.txtIEPSIncluido.Location = New System.Drawing.Point(541, 439)
        Me.txtIEPSIncluido.MaxLength = 160
        Me.txtIEPSIncluido.Name = "txtIEPSIncluido"
        Me.txtIEPSIncluido.Size = New System.Drawing.Size(99, 20)
        Me.txtIEPSIncluido.TabIndex = 323
        Me.txtIEPSIncluido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.lblTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblSubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblImpuestoDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplaySubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayImpuestoDolares)
        Me.gbDolares.Location = New System.Drawing.Point(282, 430)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Size = New System.Drawing.Size(176, 78)
        Me.gbDolares.TabIndex = 325
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "Total USD :"
        Me.gbDolares.Visible = False
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalDolares.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotalDolares.Location = New System.Drawing.Point(68, 53)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalDolares.TabIndex = 249
        Me.lblTotalDolares.Text = "0.00"
        Me.lblTotalDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotalDolares
        '
        Me.lblSubtotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotalDolares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotalDolares.Location = New System.Drawing.Point(68, 16)
        Me.lblSubtotalDolares.Name = "lblSubtotalDolares"
        Me.lblSubtotalDolares.Size = New System.Drawing.Size(102, 13)
        Me.lblSubtotalDolares.TabIndex = 247
        Me.lblSubtotalDolares.Text = "0.00"
        Me.lblSubtotalDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuestoDolares
        '
        Me.lblImpuestoDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuestoDolares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuestoDolares.Location = New System.Drawing.Point(68, 35)
        Me.lblImpuestoDolares.Name = "lblImpuestoDolares"
        Me.lblImpuestoDolares.Size = New System.Drawing.Size(102, 13)
        Me.lblImpuestoDolares.TabIndex = 248
        Me.lblImpuestoDolares.Text = "0.00"
        Me.lblImpuestoDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotalDolares
        '
        Me.lblDisplayTotalDolares.AutoSize = True
        Me.lblDisplayTotalDolares.Location = New System.Drawing.Point(6, 53)
        Me.lblDisplayTotalDolares.Name = "lblDisplayTotalDolares"
        Me.lblDisplayTotalDolares.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayTotalDolares.TabIndex = 246
        Me.lblDisplayTotalDolares.Text = "Total :"
        '
        'lblDisplaySubtotalDolares
        '
        Me.lblDisplaySubtotalDolares.AutoSize = True
        Me.lblDisplaySubtotalDolares.Location = New System.Drawing.Point(6, 16)
        Me.lblDisplaySubtotalDolares.Name = "lblDisplaySubtotalDolares"
        Me.lblDisplaySubtotalDolares.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplaySubtotalDolares.TabIndex = 242
        Me.lblDisplaySubtotalDolares.Text = "Subtotal :"
        '
        'lblDisplayImpuestoDolares
        '
        Me.lblDisplayImpuestoDolares.AutoSize = True
        Me.lblDisplayImpuestoDolares.Location = New System.Drawing.Point(6, 34)
        Me.lblDisplayImpuestoDolares.Name = "lblDisplayImpuestoDolares"
        Me.lblDisplayImpuestoDolares.Size = New System.Drawing.Size(56, 13)
        Me.lblDisplayImpuestoDolares.TabIndex = 244
        Me.lblDisplayImpuestoDolares.Text = "Impuesto :"
        '
        'lblImpuestoPorcentaje
        '
        Me.lblImpuestoPorcentaje.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuestoPorcentaje.ForeColor = System.Drawing.Color.Crimson
        Me.lblImpuestoPorcentaje.Location = New System.Drawing.Point(12, 399)
        Me.lblImpuestoPorcentaje.Name = "lblImpuestoPorcentaje"
        Me.lblImpuestoPorcentaje.Size = New System.Drawing.Size(44, 13)
        Me.lblImpuestoPorcentaje.TabIndex = 326
        Me.lblImpuestoPorcentaje.Text = "0.00"
        Me.lblImpuestoPorcentaje.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayUsoCFDI
        '
        Me.lblDisplayUsoCFDI.AutoSize = True
        Me.lblDisplayUsoCFDI.Location = New System.Drawing.Point(389, 43)
        Me.lblDisplayUsoCFDI.Name = "lblDisplayUsoCFDI"
        Me.lblDisplayUsoCFDI.Size = New System.Drawing.Size(76, 13)
        Me.lblDisplayUsoCFDI.TabIndex = 388
        Me.lblDisplayUsoCFDI.Text = "Uso del CFDI :"
        '
        'cboUsoCFDI
        '
        Me.cboUsoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsoCFDI.FormattingEnabled = True
        Me.cboUsoCFDI.Location = New System.Drawing.Point(486, 40)
        Me.cboUsoCFDI.MaxLength = 1
        Me.cboUsoCFDI.Name = "cboUsoCFDI"
        Me.cboUsoCFDI.Size = New System.Drawing.Size(338, 21)
        Me.cboUsoCFDI.TabIndex = 4
        '
        'cboTipoRelacionCFDI
        '
        Me.cboTipoRelacionCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRelacionCFDI.FormattingEnabled = True
        Me.cboTipoRelacionCFDI.Location = New System.Drawing.Point(486, 66)
        Me.cboTipoRelacionCFDI.MaxLength = 1
        Me.cboTipoRelacionCFDI.Name = "cboTipoRelacionCFDI"
        Me.cboTipoRelacionCFDI.Size = New System.Drawing.Size(338, 21)
        Me.cboTipoRelacionCFDI.TabIndex = 5
        '
        'lblDisplayTipoRelacionCFDI
        '
        Me.lblDisplayTipoRelacionCFDI.AutoSize = True
        Me.lblDisplayTipoRelacionCFDI.Location = New System.Drawing.Point(389, 69)
        Me.lblDisplayTipoRelacionCFDI.Name = "lblDisplayTipoRelacionCFDI"
        Me.lblDisplayTipoRelacionCFDI.Size = New System.Drawing.Size(101, 13)
        Me.lblDisplayTipoRelacionCFDI.TabIndex = 393
        Me.lblDisplayTipoRelacionCFDI.Text = "Tipo relación CFDI :"
        '
        'Frm_CXC_Descuentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 543)
        Me.Controls.Add(Me.lblImpuestoPorcentaje)
        Me.Controls.Add(Me.gbDolares)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIEPSIncluido)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.gbFacturas)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
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
        Me.gbDolares.ResumeLayout(False)
        Me.gbDolares.PerformLayout()
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
    Friend WithEvents lblDisplayTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents tsbTimbrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkVentaPublicoGeneral As System.Windows.Forms.CheckBox
    Friend WithEvents tsbRecuperarXMLPDF As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelarTimbre As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNotaSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnNotaAnterior As System.Windows.Forms.Button
    Friend WithEvents txtIEPS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIEPSIncluido As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents btnCargarFacturas As System.Windows.Forms.Button
    Friend WithEvents CboDocumento As ComboBox
    Friend WithEvents LblDocumento As Label
    Friend WithEvents lblDisplayMetodoPago As Label
    Friend WithEvents cboMetodoPago As ComboBox
    Friend WithEvents cboFormaPago As ComboBox
    Friend WithEvents lblMetodoPago As Label
    Friend WithEvents lblVersionCFDI As Label
    Friend WithEvents tsbEnviarCorreo As ToolStripButton
    Friend WithEvents gbDolares As GroupBox
    Friend WithEvents lblTotalDolares As Label
    Friend WithEvents lblSubtotalDolares As Label
    Friend WithEvents lblImpuestoDolares As Label
    Friend WithEvents lblDisplayTotalDolares As Label
    Friend WithEvents lblDisplaySubtotalDolares As Label
    Friend WithEvents lblDisplayImpuestoDolares As Label
    Friend WithEvents lblImpuestoPorcentaje As Label
    Friend WithEvents cboTipoRelacionCFDI As ComboBox
    Friend WithEvents lblDisplayTipoRelacionCFDI As Label
    Friend WithEvents cboUsoCFDI As ComboBox
    Friend WithEvents lblDisplayUsoCFDI As Label
End Class
