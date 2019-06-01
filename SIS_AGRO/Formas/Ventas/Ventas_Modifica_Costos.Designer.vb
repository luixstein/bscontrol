<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas_Modifica_Costos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ventas_Modifica_Costos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbDolares = New System.Windows.Forms.GroupBox()
        Me.lblTotalDolares = New System.Windows.Forms.Label()
        Me.lblSubtotalDolares = New System.Windows.Forms.Label()
        Me.lblImpuestoDolares = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Grid = New FlexCell.Grid()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.frmDatos = New System.Windows.Forms.GroupBox()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.dpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.LblDisplayCobrador = New System.Windows.Forms.Label()
        Me.chkVentaPublicoGeneral = New System.Windows.Forms.CheckBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.LblDisplayDireccionEmpresa = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTipoNegociacion = New System.Windows.Forms.ComboBox()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.txtPlazo = New System.Windows.Forms.TextBox()
        Me.LblDisplayTipoSocio = New System.Windows.Forms.Label()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.lblDisplayCostoTotal = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gbDolares.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.frmDatos.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(1042, 587)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(200, 96)
        Me.GroupBox1.TabIndex = 319
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pesos"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal.Location = New System.Drawing.Point(91, 65)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(100, 16)
        Me.lblTotal.TabIndex = 249
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal.Location = New System.Drawing.Point(91, 20)
        Me.lblSubtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(100, 16)
        Me.lblSubtotal.TabIndex = 247
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto.Location = New System.Drawing.Point(91, 43)
        Me.lblImpuesto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(100, 16)
        Me.lblImpuesto.TabIndex = 248
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 65)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "Total :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 242
        Me.Label4.Text = "Subtotal :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 42)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 244
        Me.Label5.Text = "Impuesto :"
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.lblTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblSubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblImpuestoDolares)
        Me.gbDolares.Controls.Add(Me.Label17)
        Me.gbDolares.Controls.Add(Me.Label18)
        Me.gbDolares.Controls.Add(Me.Label19)
        Me.gbDolares.Location = New System.Drawing.Point(804, 587)
        Me.gbDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Size = New System.Drawing.Size(200, 96)
        Me.gbDolares.TabIndex = 320
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "Dólares"
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalDolares.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotalDolares.Location = New System.Drawing.Point(91, 65)
        Me.lblTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(100, 16)
        Me.lblTotalDolares.TabIndex = 249
        Me.lblTotalDolares.Text = "0.00"
        Me.lblTotalDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSubtotalDolares
        '
        Me.lblSubtotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotalDolares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotalDolares.Location = New System.Drawing.Point(91, 20)
        Me.lblSubtotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtotalDolares.Name = "lblSubtotalDolares"
        Me.lblSubtotalDolares.Size = New System.Drawing.Size(100, 16)
        Me.lblSubtotalDolares.TabIndex = 247
        Me.lblSubtotalDolares.Text = "0.00"
        Me.lblSubtotalDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuestoDolares
        '
        Me.lblImpuestoDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuestoDolares.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuestoDolares.Location = New System.Drawing.Point(91, 43)
        Me.lblImpuestoDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpuestoDolares.Name = "lblImpuestoDolares"
        Me.lblImpuestoDolares.Size = New System.Drawing.Size(100, 16)
        Me.lblImpuestoDolares.TabIndex = 248
        Me.lblImpuestoDolares.Text = "0.00"
        Me.lblImpuestoDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 65)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 17)
        Me.Label17.TabIndex = 246
        Me.Label17.Text = "Total :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 20)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 17)
        Me.Label18.TabIndex = 242
        Me.Label18.Text = "Subtotal :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 42)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 17)
        Me.Label19.TabIndex = 244
        Me.Label19.Text = "Impuesto :"
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
        Me.Grid.Location = New System.Drawing.Point(19, 320)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(1235, 259)
        Me.Grid.TabIndex = 317
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1267, 27)
        Me.tsMenu.TabIndex = 318
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(568, 602)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 17)
        Me.Label11.TabIndex = 334
        Me.Label11.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(691, 599)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(104, 22)
        Me.txtTipoCambio.TabIndex = 333
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 698)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1267, 29)
        Me.StatusStripEstado.TabIndex = 335
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
        Me.frmDatos.Location = New System.Drawing.Point(20, 34)
        Me.frmDatos.Margin = New System.Windows.Forms.Padding(4)
        Me.frmDatos.Name = "frmDatos"
        Me.frmDatos.Padding = New System.Windows.Forms.Padding(4)
        Me.frmDatos.Size = New System.Drawing.Size(1235, 278)
        Me.frmDatos.TabIndex = 321
        Me.frmDatos.TabStop = False
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(24, 114)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 325
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(145, 114)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(12, 17)
        Me.LblEstatus.TabIndex = 326
        Me.LblEstatus.Text = "."
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.ForeColor = System.Drawing.Color.Crimson
        Me.lblSaldo.Location = New System.Drawing.Point(145, 150)
        Me.lblSaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(12, 17)
        Me.lblSaldo.TabIndex = 328
        Me.lblSaldo.Text = "."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(24, 150)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 17)
        Me.Label23.TabIndex = 327
        Me.Label23.Text = "Saldo :"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(24, 18)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 314
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(149, 15)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(109, 22)
        Me.txtFolio.TabIndex = 303
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(501, 17)
        Me.LblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(55, 17)
        Me.LblFecha.TabIndex = 315
        Me.LblFecha.Text = "Fecha :"
        '
        'dpFecha
        '
        Me.dpFecha.Enabled = False
        Me.dpFecha.Location = New System.Drawing.Point(601, 15)
        Me.dpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(280, 22)
        Me.dpFecha.TabIndex = 307
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(501, 177)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 316
        Me.Label1.Text = "Vencimiento :"
        '
        'dpVencimiento
        '
        Me.dpVencimiento.Enabled = False
        Me.dpVencimiento.Location = New System.Drawing.Point(601, 173)
        Me.dpVencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.dpVencimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpVencimiento.Name = "dpVencimiento"
        Me.dpVencimiento.Size = New System.Drawing.Size(280, 22)
        Me.dpVencimiento.TabIndex = 312
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Location = New System.Drawing.Point(149, 177)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(109, 22)
        Me.TxtCliente.TabIndex = 306
        '
        'LblDisplayCobrador
        '
        Me.LblDisplayCobrador.AutoSize = True
        Me.LblDisplayCobrador.Location = New System.Drawing.Point(24, 181)
        Me.LblDisplayCobrador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCobrador.Name = "LblDisplayCobrador"
        Me.LblDisplayCobrador.Size = New System.Drawing.Size(59, 17)
        Me.LblDisplayCobrador.TabIndex = 317
        Me.LblDisplayCobrador.Text = "Cliente :"
        '
        'chkVentaPublicoGeneral
        '
        Me.chkVentaPublicoGeneral.AutoSize = True
        Me.chkVentaPublicoGeneral.Enabled = False
        Me.chkVentaPublicoGeneral.Location = New System.Drawing.Point(601, 113)
        Me.chkVentaPublicoGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.chkVentaPublicoGeneral.Name = "chkVentaPublicoGeneral"
        Me.chkVentaPublicoGeneral.Size = New System.Drawing.Size(183, 21)
        Me.chkVentaPublicoGeneral.TabIndex = 310
        Me.chkVentaPublicoGeneral.Text = "Venta al público general"
        Me.chkVentaPublicoGeneral.UseVisualStyleBackColor = True
        '
        'lblCliente
        '
        Me.lblCliente.Location = New System.Drawing.Point(145, 205)
        Me.lblCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(737, 16)
        Me.lblCliente.TabIndex = 318
        Me.lblCliente.Text = "."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(501, 50)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 17)
        Me.Label10.TabIndex = 324
        Me.Label10.Text = "Vendedor :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Enabled = False
        Me.TxtConcepto.Location = New System.Drawing.Point(149, 225)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(732, 38)
        Me.TxtConcepto.TabIndex = 313
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.Enabled = False
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(601, 47)
        Me.cboVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(280, 24)
        Me.cboVendedor.TabIndex = 308
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(24, 229)
        Me.LblDisplayDireccionEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayDireccionEmpresa.TabIndex = 319
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 82)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 17)
        Me.Label9.TabIndex = 323
        Me.Label9.Text = "Tipo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 320
        Me.Label2.Text = "Referencia :"
        '
        'cboTipoNegociacion
        '
        Me.cboTipoNegociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoNegociacion.Enabled = False
        Me.cboTipoNegociacion.FormattingEnabled = True
        Me.cboTipoNegociacion.Location = New System.Drawing.Point(149, 79)
        Me.cboTipoNegociacion.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoNegociacion.Name = "cboTipoNegociacion"
        Me.cboTipoNegociacion.Size = New System.Drawing.Size(109, 24)
        Me.cboTipoNegociacion.TabIndex = 305
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Enabled = False
        Me.TxtReferencia.Location = New System.Drawing.Point(149, 47)
        Me.TxtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtReferencia.MaxLength = 15
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(109, 22)
        Me.TxtReferencia.TabIndex = 304
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(501, 84)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 321
        Me.Label3.Text = "Almacen :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.Enabled = False
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(601, 80)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(280, 24)
        Me.CboAlmacen.TabIndex = 309
        '
        'txtPlazo
        '
        Me.txtPlazo.Enabled = False
        Me.txtPlazo.Location = New System.Drawing.Point(601, 141)
        Me.txtPlazo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlazo.MaxLength = 3
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(53, 22)
        Me.txtPlazo.TabIndex = 311
        '
        'LblDisplayTipoSocio
        '
        Me.LblDisplayTipoSocio.AutoSize = True
        Me.LblDisplayTipoSocio.Location = New System.Drawing.Point(501, 145)
        Me.LblDisplayTipoSocio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTipoSocio.Name = "LblDisplayTipoSocio"
        Me.LblDisplayTipoSocio.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayTipoSocio.TabIndex = 322
        Me.LblDisplayTipoSocio.Text = "Plazo :"
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCostoTotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCostoTotal.Location = New System.Drawing.Point(342, 602)
        Me.lblCostoTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(137, 19)
        Me.lblCostoTotal.TabIndex = 250
        Me.lblCostoTotal.Text = "0.00"
        Me.lblCostoTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayCostoTotal
        '
        Me.lblDisplayCostoTotal.AutoSize = True
        Me.lblDisplayCostoTotal.Location = New System.Drawing.Point(251, 602)
        Me.lblDisplayCostoTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCostoTotal.Name = "lblDisplayCostoTotal"
        Me.lblDisplayCostoTotal.Size = New System.Drawing.Size(83, 17)
        Me.lblDisplayCostoTotal.TabIndex = 336
        Me.lblDisplayCostoTotal.Text = "Costo total :"
        '
        'Ventas_Modifica_Costos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 727)
        Me.Controls.Add(Me.lblDisplayCostoTotal)
        Me.Controls.Add(Me.lblCostoTotal)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.frmDatos)
        Me.Controls.Add(Me.gbDolares)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Ventas_Modifica_Costos"
        Me.Text = "Modifica costos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbDolares.ResumeLayout(False)
        Me.gbDolares.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.frmDatos.ResumeLayout(False)
        Me.frmDatos.PerformLayout()
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents frmDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
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
    Friend WithEvents lblCostoTotal As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCostoTotal As System.Windows.Forms.Label
End Class
