<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas_Modifica_Precios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ventas_Modifica_Precios))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblSubtotal = New System.Windows.Forms.Label
        Me.lblImpuesto = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.frmDatos = New System.Windows.Forms.GroupBox
        Me.lblDisplayStatus = New System.Windows.Forms.Label
        Me.LblEstatus = New System.Windows.Forms.Label
        Me.lblSaldo = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.LblDisplayFolio = New System.Windows.Forms.Label
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.LblFecha = New System.Windows.Forms.Label
        Me.dpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpVencimiento = New System.Windows.Forms.DateTimePicker
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.LblDisplayCobrador = New System.Windows.Forms.Label
        Me.chkVentaPublicoGeneral = New System.Windows.Forms.CheckBox
        Me.lblCliente = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtConcepto = New System.Windows.Forms.TextBox
        Me.cboVendedor = New System.Windows.Forms.ComboBox
        Me.LblDisplayDireccionEmpresa = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTipoNegociacion = New System.Windows.Forms.ComboBox
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CboAlmacen = New System.Windows.Forms.ComboBox
        Me.txtPlazo = New System.Windows.Forms.TextBox
        Me.LblDisplayTipoSocio = New System.Windows.Forms.Label
        Me.gbDolares = New System.Windows.Forms.GroupBox
        Me.lblTotalDolares = New System.Windows.Forms.Label
        Me.lblSubtotalDolares = New System.Windows.Forms.Label
        Me.lblImpuestoDolares = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Grid = New FlexCell.Grid
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        Me.frmDatos.SuspendLayout()
        Me.gbDolares.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.lblSubtotal)
        Me.GroupBox1.Controls.Add(Me.lblImpuesto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(683, 509)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 78)
        Me.GroupBox1.TabIndex = 319
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pesos"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal.Location = New System.Drawing.Point(68, 53)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(75, 13)
        Me.lblTotal.TabIndex = 249
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal.Location = New System.Drawing.Point(68, 16)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(75, 13)
        Me.lblSubtotal.TabIndex = 247
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto.Location = New System.Drawing.Point(68, 35)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(75, 13)
        Me.lblImpuesto.TabIndex = 248
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "Total :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 242
        Me.Label4.Text = "Subtotal :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 244
        Me.Label5.Text = "Impuesto :"
        '
        'frmDatos
        '
        Me.frmDatos.Controls.Add(Me.lblDisplayStatus)
        Me.frmDatos.Controls.Add(Me.LblEstatus)
        Me.frmDatos.Controls.Add(Me.lblSaldo)
        Me.frmDatos.Controls.Add(Me.Label23)
        Me.frmDatos.Controls.Add(Me.LblDisplayFolio)
        Me.frmDatos.Controls.Add(Me.txtFolio)
        Me.frmDatos.Controls.Add(Me.LblFecha)
        Me.frmDatos.Controls.Add(Me.dpFecha)
        Me.frmDatos.Controls.Add(Me.Label1)
        Me.frmDatos.Controls.Add(Me.dpVencimiento)
        Me.frmDatos.Controls.Add(Me.TxtCliente)
        Me.frmDatos.Controls.Add(Me.LblDisplayCobrador)
        Me.frmDatos.Controls.Add(Me.chkVentaPublicoGeneral)
        Me.frmDatos.Controls.Add(Me.lblCliente)
        Me.frmDatos.Controls.Add(Me.Label10)
        Me.frmDatos.Controls.Add(Me.TxtConcepto)
        Me.frmDatos.Controls.Add(Me.cboVendedor)
        Me.frmDatos.Controls.Add(Me.LblDisplayDireccionEmpresa)
        Me.frmDatos.Controls.Add(Me.Label9)
        Me.frmDatos.Controls.Add(Me.Label2)
        Me.frmDatos.Controls.Add(Me.cboTipoNegociacion)
        Me.frmDatos.Controls.Add(Me.TxtReferencia)
        Me.frmDatos.Controls.Add(Me.Label3)
        Me.frmDatos.Controls.Add(Me.CboAlmacen)
        Me.frmDatos.Controls.Add(Me.txtPlazo)
        Me.frmDatos.Controls.Add(Me.LblDisplayTipoSocio)
        Me.frmDatos.Location = New System.Drawing.Point(15, 28)
        Me.frmDatos.Name = "frmDatos"
        Me.frmDatos.Size = New System.Drawing.Size(926, 228)
        Me.frmDatos.TabIndex = 321
        Me.frmDatos.TabStop = False
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(11, 101)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 299
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(102, 101)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(10, 13)
        Me.LblEstatus.TabIndex = 300
        Me.LblEstatus.Text = "."
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.lblSaldo.Location = New System.Drawing.Point(102, 130)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(10, 13)
        Me.lblSaldo.TabIndex = 302
        Me.lblSaldo.Text = "."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 130)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 301
        Me.Label23.Text = "Saldo :"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(11, 23)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 224
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(105, 20)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(83, 20)
        Me.txtFolio.TabIndex = 1
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(369, 22)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 228
        Me.LblFecha.Text = "Fecha :"
        '
        'dpFecha
        '
        Me.dpFecha.Enabled = False
        Me.dpFecha.Location = New System.Drawing.Point(444, 20)
        Me.dpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(211, 20)
        Me.dpFecha.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(369, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Vencimiento :"
        '
        'dpVencimiento
        '
        Me.dpVencimiento.Enabled = False
        Me.dpVencimiento.Location = New System.Drawing.Point(444, 149)
        Me.dpVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpVencimiento.Name = "dpVencimiento"
        Me.dpVencimiento.Size = New System.Drawing.Size(211, 20)
        Me.dpVencimiento.TabIndex = 11
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Location = New System.Drawing.Point(105, 152)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(83, 20)
        Me.TxtCliente.TabIndex = 5
        '
        'LblDisplayCobrador
        '
        Me.LblDisplayCobrador.AutoSize = True
        Me.LblDisplayCobrador.Location = New System.Drawing.Point(11, 155)
        Me.LblDisplayCobrador.Name = "LblDisplayCobrador"
        Me.LblDisplayCobrador.Size = New System.Drawing.Size(45, 13)
        Me.LblDisplayCobrador.TabIndex = 232
        Me.LblDisplayCobrador.Text = "Cliente :"
        '
        'chkVentaPublicoGeneral
        '
        Me.chkVentaPublicoGeneral.AutoSize = True
        Me.chkVentaPublicoGeneral.Enabled = False
        Me.chkVentaPublicoGeneral.Location = New System.Drawing.Point(444, 100)
        Me.chkVentaPublicoGeneral.Name = "chkVentaPublicoGeneral"
        Me.chkVentaPublicoGeneral.Size = New System.Drawing.Size(140, 17)
        Me.chkVentaPublicoGeneral.TabIndex = 9
        Me.chkVentaPublicoGeneral.Text = "Venta al público general"
        Me.chkVentaPublicoGeneral.UseVisualStyleBackColor = True
        '
        'lblCliente
        '
        Me.lblCliente.Location = New System.Drawing.Point(102, 175)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(553, 13)
        Me.lblCliente.TabIndex = 233
        Me.lblCliente.Text = "."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(369, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 290
        Me.Label10.Text = "Vendedor :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Enabled = False
        Me.TxtConcepto.Location = New System.Drawing.Point(105, 191)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(550, 32)
        Me.TxtConcepto.TabIndex = 12
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.Enabled = False
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(444, 46)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(211, 21)
        Me.cboVendedor.TabIndex = 7
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(11, 194)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayDireccionEmpresa.TabIndex = 235
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 288
        Me.Label9.Text = "Tipo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 237
        Me.Label2.Text = "Referencia :"
        '
        'cboTipoNegociacion
        '
        Me.cboTipoNegociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoNegociacion.Enabled = False
        Me.cboTipoNegociacion.FormattingEnabled = True
        Me.cboTipoNegociacion.Location = New System.Drawing.Point(105, 72)
        Me.cboTipoNegociacion.Name = "cboTipoNegociacion"
        Me.cboTipoNegociacion.Size = New System.Drawing.Size(83, 21)
        Me.cboTipoNegociacion.TabIndex = 4
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Enabled = False
        Me.TxtReferencia.Location = New System.Drawing.Point(105, 46)
        Me.TxtReferencia.MaxLength = 15
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(83, 20)
        Me.TxtReferencia.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(369, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Almacen :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.Enabled = False
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(444, 73)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(211, 21)
        Me.CboAlmacen.TabIndex = 8
        '
        'txtPlazo
        '
        Me.txtPlazo.Enabled = False
        Me.txtPlazo.Location = New System.Drawing.Point(444, 123)
        Me.txtPlazo.MaxLength = 3
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(41, 20)
        Me.txtPlazo.TabIndex = 10
        '
        'LblDisplayTipoSocio
        '
        Me.LblDisplayTipoSocio.AutoSize = True
        Me.LblDisplayTipoSocio.Location = New System.Drawing.Point(369, 126)
        Me.LblDisplayTipoSocio.Name = "LblDisplayTipoSocio"
        Me.LblDisplayTipoSocio.Size = New System.Drawing.Size(39, 13)
        Me.LblDisplayTipoSocio.TabIndex = 281
        Me.LblDisplayTipoSocio.Text = "Plazo :"
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.lblTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblSubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblImpuestoDolares)
        Me.gbDolares.Controls.Add(Me.Label17)
        Me.gbDolares.Controls.Add(Me.Label18)
        Me.gbDolares.Controls.Add(Me.Label19)
        Me.gbDolares.Location = New System.Drawing.Point(505, 509)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Size = New System.Drawing.Size(150, 78)
        Me.gbDolares.TabIndex = 320
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "Dólares"
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalDolares.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotalDolares.Location = New System.Drawing.Point(68, 53)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(75, 13)
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
        Me.lblSubtotalDolares.Size = New System.Drawing.Size(75, 13)
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
        Me.lblImpuestoDolares.Size = New System.Drawing.Size(75, 13)
        Me.lblImpuestoDolares.TabIndex = 248
        Me.lblImpuestoDolares.Text = "0.00"
        Me.lblImpuestoDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 13)
        Me.Label17.TabIndex = 246
        Me.Label17.Text = "Total :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 242
        Me.Label18.Text = "Subtotal :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 244
        Me.Label19.Text = "Impuesto :"
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
        Me.Grid.Location = New System.Drawing.Point(15, 257)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(926, 239)
        Me.Grid.TabIndex = 317
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(950, 25)
        Me.tsMenu.TabIndex = 318
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(328, 521)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 334
        Me.Label11.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(420, 518)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(79, 20)
        Me.txtTipoCambio.TabIndex = 333
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 622)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(950, 24)
        Me.StatusStripEstado.TabIndex = 335
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
        'Ventas_Modifica_Precios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 646)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.frmDatos)
        Me.Controls.Add(Me.gbDolares)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Ventas_Modifica_Precios"
        Me.Text = "Modifica precios remisiones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.frmDatos.ResumeLayout(False)
        Me.frmDatos.PerformLayout()
        Me.gbDolares.ResumeLayout(False)
        Me.gbDolares.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents lblImpuesto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents frmDatos As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCobrador As System.Windows.Forms.Label
    Friend WithEvents chkVentaPublicoGeneral As System.Windows.Forms.CheckBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayDireccionEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoNegociacion As System.Windows.Forms.ComboBox
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayTipoSocio As System.Windows.Forms.Label
    Friend WithEvents gbDolares As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblSubtotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblImpuestoDolares As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
End Class
