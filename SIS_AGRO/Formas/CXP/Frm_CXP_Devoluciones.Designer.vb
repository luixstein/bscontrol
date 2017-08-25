<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_CXP_Devoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXP_Devoluciones))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSellar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelarTimbre = New System.Windows.Forms.ToolStripButton()
        Me.tsbRecuperaXMLPdf = New System.Windows.Forms.ToolStripButton()
        Me.tsbEnviarCorreo = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grid = New FlexCell.Grid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridSeries = New FlexCell.Grid()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.lblDisplayIEPSIncluido = New System.Windows.Forms.Label()
        Me.lblIEPSIncluido = New System.Windows.Forms.Label()
        Me.btnSeries = New System.Windows.Forms.Button()
        Me.lblDisplayTipoCambio = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.gbPesos = New System.Windows.Forms.GroupBox()
        Me.lblIEPS = New System.Windows.Forms.Label()
        Me.lblDisplayIEPS = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.lblDisplayTotalPesos = New System.Windows.Forms.Label()
        Me.lblDisplaySubtotalPesos = New System.Windows.Forms.Label()
        Me.lblDisplayImpuestoPesos = New System.Windows.Forms.Label()
        Me.gbDolares = New System.Windows.Forms.GroupBox()
        Me.lblTotalDolares = New System.Windows.Forms.Label()
        Me.lblSubtotalDolares = New System.Windows.Forms.Label()
        Me.lblImpuestoDolares = New System.Windows.Forms.Label()
        Me.lblDisplayTotalDolares = New System.Windows.Forms.Label()
        Me.lblDisplaySubtotalDolares = New System.Windows.Forms.Label()
        Me.lblDisplayImpuestoDolares = New System.Windows.Forms.Label()
        Me.chkDolares = New System.Windows.Forms.CheckBox()
        Me.lblPoliza = New System.Windows.Forms.LinkLabel()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayPoliza = New System.Windows.Forms.Label()
        Me.frmDatos = New System.Windows.Forms.GroupBox()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.lblDisplaySaldo = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtFolioDescuento = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioDescuento = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.lblDisplayFolioDevolucion = New System.Windows.Forms.Label()
        Me.txtFolioDevolucion = New System.Windows.Forms.TextBox()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.lblDisplayProveedor = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.lblDisplayFolioVenta = New System.Windows.Forms.Label()
        Me.txtFolioCompra = New System.Windows.Forms.TextBox()
        Me.lblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbTotales.SuspendLayout()
        Me.gbPesos.SuspendLayout()
        Me.gbDolares.SuspendLayout()
        Me.frmDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbSellar, Me.tsbCancelarTimbre, Me.tsbRecuperaXMLPdf, Me.tsbEnviarCorreo, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1323, 27)
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
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(94, 24)
        Me.tsbCancelar.Text = " Cancelar"
        Me.tsbCancelar.Visible = False
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
        'tsbSellar
        '
        Me.tsbSellar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbSellar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSellar.Name = "tsbSellar"
        Me.tsbSellar.Size = New System.Drawing.Size(181, 24)
        Me.tsbSellar.Text = "S&ellar nota electronica"
        Me.tsbSellar.Visible = False
        '
        'tsbCancelarTimbre
        '
        Me.tsbCancelarTimbre.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbCancelarTimbre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelarTimbre.Name = "tsbCancelarTimbre"
        Me.tsbCancelarTimbre.Size = New System.Drawing.Size(138, 24)
        Me.tsbCancelarTimbre.Text = "Cancelar timbre"
        Me.tsbCancelarTimbre.Visible = False
        '
        'tsbRecuperaXMLPdf
        '
        Me.tsbRecuperaXMLPdf.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbRecuperaXMLPdf.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecuperaXMLPdf.Name = "tsbRecuperaXMLPdf"
        Me.tsbRecuperaXMLPdf.Size = New System.Drawing.Size(152, 24)
        Me.tsbRecuperaXMLPdf.Text = "Recupera xml/pdf"
        Me.tsbRecuperaXMLPdf.Visible = False
        '
        'tsbEnviarCorreo
        '
        Me.tsbEnviarCorreo.Image = CType(resources.GetObject("tsbEnviarCorreo.Image"), System.Drawing.Image)
        Me.tsbEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarCorreo.Name = "tsbEnviarCorreo"
        Me.tsbEnviarCorreo.Size = New System.Drawing.Size(120, 24)
        Me.tsbEnviarCorreo.Text = "&Enviar correo"
        Me.tsbEnviarCorreo.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 714)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1323, 29)
        Me.StatusStripEstado.TabIndex = 242
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 287)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1315, 293)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1307, 264)
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
        Me.Grid.DefaultRowHeight = CType(24, Short)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(4, 7)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(1292, 251)
        Me.Grid.TabIndex = 2
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridSeries)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1307, 264)
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
        Me.GridSeries.DefaultRowHeight = CType(24, Short)
        Me.GridSeries.DisplayRowNumber = True
        Me.GridSeries.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSeries.Location = New System.Drawing.Point(7, 7)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(1288, 244)
        Me.GridSeries.TabIndex = 2
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbTotales
        '
        Me.gbTotales.Controls.Add(Me.lblDisplayIEPSIncluido)
        Me.gbTotales.Controls.Add(Me.lblIEPSIncluido)
        Me.gbTotales.Controls.Add(Me.btnSeries)
        Me.gbTotales.Controls.Add(Me.lblDisplayTipoCambio)
        Me.gbTotales.Controls.Add(Me.txtTipoCambio)
        Me.gbTotales.Controls.Add(Me.gbPesos)
        Me.gbTotales.Controls.Add(Me.gbDolares)
        Me.gbTotales.Controls.Add(Me.chkDolares)
        Me.gbTotales.Location = New System.Drawing.Point(5, 577)
        Me.gbTotales.Margin = New System.Windows.Forms.Padding(4)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Padding = New System.Windows.Forms.Padding(4)
        Me.gbTotales.Size = New System.Drawing.Size(1315, 133)
        Me.gbTotales.TabIndex = 244
        Me.gbTotales.TabStop = False
        '
        'lblDisplayIEPSIncluido
        '
        Me.lblDisplayIEPSIncluido.AutoSize = True
        Me.lblDisplayIEPSIncluido.Location = New System.Drawing.Point(1137, 20)
        Me.lblDisplayIEPSIncluido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIEPSIncluido.Name = "lblDisplayIEPSIncluido"
        Me.lblDisplayIEPSIncluido.Size = New System.Drawing.Size(98, 17)
        Me.lblDisplayIEPSIncluido.TabIndex = 383
        Me.lblDisplayIEPSIncluido.Text = "IEPS Incluido :"
        '
        'lblIEPSIncluido
        '
        Me.lblIEPSIncluido.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPSIncluido.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPSIncluido.Location = New System.Drawing.Point(1093, 42)
        Me.lblIEPSIncluido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIEPSIncluido.Name = "lblIEPSIncluido"
        Me.lblIEPSIncluido.Size = New System.Drawing.Size(147, 16)
        Me.lblIEPSIncluido.TabIndex = 382
        Me.lblIEPSIncluido.Text = "0.00"
        Me.lblIEPSIncluido.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSeries
        '
        Me.btnSeries.Location = New System.Drawing.Point(12, 80)
        Me.btnSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(145, 39)
        Me.btnSeries.TabIndex = 381
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(347, 55)
        Me.lblDisplayTipoCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(113, 17)
        Me.lblDisplayTipoCambio.TabIndex = 332
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(469, 52)
        Me.txtTipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(104, 22)
        Me.txtTipoCambio.TabIndex = 331
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbPesos
        '
        Me.gbPesos.Controls.Add(Me.lblIEPS)
        Me.gbPesos.Controls.Add(Me.lblDisplayIEPS)
        Me.gbPesos.Controls.Add(Me.lblTotal)
        Me.gbPesos.Controls.Add(Me.lblSubtotal)
        Me.gbPesos.Controls.Add(Me.lblImpuesto)
        Me.gbPesos.Controls.Add(Me.lblDisplayTotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplaySubtotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplayImpuestoPesos)
        Me.gbPesos.Location = New System.Drawing.Point(833, 0)
        Me.gbPesos.Margin = New System.Windows.Forms.Padding(4)
        Me.gbPesos.Name = "gbPesos"
        Me.gbPesos.Padding = New System.Windows.Forms.Padding(4)
        Me.gbPesos.Size = New System.Drawing.Size(245, 119)
        Me.gbPesos.TabIndex = 292
        Me.gbPesos.TabStop = False
        Me.gbPesos.Text = "Pesos"
        '
        'lblIEPS
        '
        Me.lblIEPS.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPS.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPS.Location = New System.Drawing.Point(91, 43)
        Me.lblIEPS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIEPS.Name = "lblIEPS"
        Me.lblIEPS.Size = New System.Drawing.Size(147, 16)
        Me.lblIEPS.TabIndex = 251
        Me.lblIEPS.Text = "0.00"
        Me.lblIEPS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayIEPS
        '
        Me.lblDisplayIEPS.AutoSize = True
        Me.lblDisplayIEPS.Location = New System.Drawing.Point(8, 42)
        Me.lblDisplayIEPS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIEPS.Name = "lblDisplayIEPS"
        Me.lblDisplayIEPS.Size = New System.Drawing.Size(46, 17)
        Me.lblDisplayIEPS.TabIndex = 250
        Me.lblDisplayIEPS.Text = "IEPS :"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal.Location = New System.Drawing.Point(91, 89)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(147, 16)
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
        Me.lblSubtotal.Size = New System.Drawing.Size(147, 16)
        Me.lblSubtotal.TabIndex = 247
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto.Location = New System.Drawing.Point(91, 66)
        Me.lblImpuesto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(147, 16)
        Me.lblImpuesto.TabIndex = 248
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(8, 89)
        Me.lblDisplayTotalPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalPesos.Name = "lblDisplayTotalPesos"
        Me.lblDisplayTotalPesos.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotalPesos.TabIndex = 246
        Me.lblDisplayTotalPesos.Text = "Total :"
        '
        'lblDisplaySubtotalPesos
        '
        Me.lblDisplaySubtotalPesos.AutoSize = True
        Me.lblDisplaySubtotalPesos.Location = New System.Drawing.Point(8, 20)
        Me.lblDisplaySubtotalPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySubtotalPesos.Name = "lblDisplaySubtotalPesos"
        Me.lblDisplaySubtotalPesos.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplaySubtotalPesos.TabIndex = 242
        Me.lblDisplaySubtotalPesos.Text = "Subtotal :"
        '
        'lblDisplayImpuestoPesos
        '
        Me.lblDisplayImpuestoPesos.AutoSize = True
        Me.lblDisplayImpuestoPesos.Location = New System.Drawing.Point(8, 65)
        Me.lblDisplayImpuestoPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayImpuestoPesos.Name = "lblDisplayImpuestoPesos"
        Me.lblDisplayImpuestoPesos.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplayImpuestoPesos.TabIndex = 244
        Me.lblDisplayImpuestoPesos.Text = "Impuesto :"
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.lblTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblSubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblImpuestoDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplaySubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayImpuestoDolares)
        Me.gbDolares.Location = New System.Drawing.Point(599, 23)
        Me.gbDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDolares.Size = New System.Drawing.Size(235, 96)
        Me.gbDolares.TabIndex = 293
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "Dólares"
        Me.gbDolares.Visible = False
        '
        'lblTotalDolares
        '
        Me.lblTotalDolares.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalDolares.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotalDolares.Location = New System.Drawing.Point(91, 65)
        Me.lblTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalDolares.Name = "lblTotalDolares"
        Me.lblTotalDolares.Size = New System.Drawing.Size(136, 16)
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
        Me.lblSubtotalDolares.Size = New System.Drawing.Size(136, 16)
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
        Me.lblImpuestoDolares.Size = New System.Drawing.Size(136, 16)
        Me.lblImpuestoDolares.TabIndex = 248
        Me.lblImpuestoDolares.Text = "0.00"
        Me.lblImpuestoDolares.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotalDolares
        '
        Me.lblDisplayTotalDolares.AutoSize = True
        Me.lblDisplayTotalDolares.Location = New System.Drawing.Point(8, 65)
        Me.lblDisplayTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalDolares.Name = "lblDisplayTotalDolares"
        Me.lblDisplayTotalDolares.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotalDolares.TabIndex = 246
        Me.lblDisplayTotalDolares.Text = "Total :"
        '
        'lblDisplaySubtotalDolares
        '
        Me.lblDisplaySubtotalDolares.AutoSize = True
        Me.lblDisplaySubtotalDolares.Location = New System.Drawing.Point(8, 20)
        Me.lblDisplaySubtotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySubtotalDolares.Name = "lblDisplaySubtotalDolares"
        Me.lblDisplaySubtotalDolares.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplaySubtotalDolares.TabIndex = 242
        Me.lblDisplaySubtotalDolares.Text = "Subtotal :"
        '
        'lblDisplayImpuestoDolares
        '
        Me.lblDisplayImpuestoDolares.AutoSize = True
        Me.lblDisplayImpuestoDolares.Location = New System.Drawing.Point(8, 42)
        Me.lblDisplayImpuestoDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayImpuestoDolares.Name = "lblDisplayImpuestoDolares"
        Me.lblDisplayImpuestoDolares.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplayImpuestoDolares.TabIndex = 244
        Me.lblDisplayImpuestoDolares.Text = "Impuesto :"
        '
        'chkDolares
        '
        Me.chkDolares.AutoSize = True
        Me.chkDolares.Enabled = False
        Me.chkDolares.Location = New System.Drawing.Point(351, 23)
        Me.chkDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDolares.Name = "chkDolares"
        Me.chkDolares.Size = New System.Drawing.Size(133, 21)
        Me.chkDolares.TabIndex = 294
        Me.chkDolares.Text = "Es en dólares  ?"
        Me.chkDolares.UseVisualStyleBackColor = True
        '
        'lblPoliza
        '
        Me.lblPoliza.AutoSize = True
        Me.lblPoliza.Location = New System.Drawing.Point(949, 52)
        Me.lblPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPoliza.Name = "lblPoliza"
        Me.lblPoliza.Size = New System.Drawing.Size(16, 17)
        Me.lblPoliza.TabIndex = 330
        Me.lblPoliza.TabStop = True
        Me.lblPoliza.Text = "_"
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(877, 20)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 225
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEstatus.Location = New System.Drawing.Point(949, 20)
        Me.lblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(12, 17)
        Me.lblEstatus.TabIndex = 226
        Me.lblEstatus.Text = "."
        '
        'lblDisplayPoliza
        '
        Me.lblDisplayPoliza.AutoSize = True
        Me.lblDisplayPoliza.Location = New System.Drawing.Point(877, 52)
        Me.lblDisplayPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPoliza.Name = "lblDisplayPoliza"
        Me.lblDisplayPoliza.Size = New System.Drawing.Size(54, 17)
        Me.lblDisplayPoliza.TabIndex = 283
        Me.lblDisplayPoliza.Text = "Póliza :"
        '
        'frmDatos
        '
        Me.frmDatos.Controls.Add(Me.txtSaldo)
        Me.frmDatos.Controls.Add(Me.lblDisplaySaldo)
        Me.frmDatos.Controls.Add(Me.txtAlmacen)
        Me.frmDatos.Controls.Add(Me.txtFolioDescuento)
        Me.frmDatos.Controls.Add(Me.lblDisplayFolioDescuento)
        Me.frmDatos.Controls.Add(Me.lblAlmacen)
        Me.frmDatos.Controls.Add(Me.btnSiguiente)
        Me.frmDatos.Controls.Add(Me.btnAnterior)
        Me.frmDatos.Controls.Add(Me.lblDisplayFolioDevolucion)
        Me.frmDatos.Controls.Add(Me.txtFolioDevolucion)
        Me.frmDatos.Controls.Add(Me.lblPoliza)
        Me.frmDatos.Controls.Add(Me.lblDisplayFecha)
        Me.frmDatos.Controls.Add(Me.dtFecha)
        Me.frmDatos.Controls.Add(Me.lblDisplayStatus)
        Me.frmDatos.Controls.Add(Me.lblEstatus)
        Me.frmDatos.Controls.Add(Me.txtProveedor)
        Me.frmDatos.Controls.Add(Me.lblDisplayPoliza)
        Me.frmDatos.Controls.Add(Me.lblDisplayProveedor)
        Me.frmDatos.Controls.Add(Me.lblProveedor)
        Me.frmDatos.Controls.Add(Me.txtConcepto)
        Me.frmDatos.Controls.Add(Me.lblDisplayConcepto)
        Me.frmDatos.Controls.Add(Me.lblDisplayFolioVenta)
        Me.frmDatos.Controls.Add(Me.txtFolioCompra)
        Me.frmDatos.Controls.Add(Me.lblDisplayAlmacen)
        Me.frmDatos.Location = New System.Drawing.Point(5, 34)
        Me.frmDatos.Margin = New System.Windows.Forms.Padding(4)
        Me.frmDatos.Name = "frmDatos"
        Me.frmDatos.Padding = New System.Windows.Forms.Padding(4)
        Me.frmDatos.Size = New System.Drawing.Size(1315, 199)
        Me.frmDatos.TabIndex = 0
        Me.frmDatos.TabStop = False
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(527, 86)
        Me.txtSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaldo.MaxLength = 8
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(119, 22)
        Me.txtSaldo.TabIndex = 376
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(447, 90)
        Me.lblDisplaySaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplaySaldo.TabIndex = 377
        Me.lblDisplaySaldo.Text = "Saldo :"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Location = New System.Drawing.Point(527, 59)
        Me.txtAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAlmacen.MaxLength = 15
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(47, 22)
        Me.txtAlmacen.TabIndex = 375
        '
        'txtFolioDescuento
        '
        Me.txtFolioDescuento.Enabled = False
        Me.txtFolioDescuento.Location = New System.Drawing.Point(971, 90)
        Me.txtFolioDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioDescuento.MaxLength = 15
        Me.txtFolioDescuento.Name = "txtFolioDescuento"
        Me.txtFolioDescuento.ReadOnly = True
        Me.txtFolioDescuento.Size = New System.Drawing.Size(119, 22)
        Me.txtFolioDescuento.TabIndex = 8
        '
        'lblDisplayFolioDescuento
        '
        Me.lblDisplayFolioDescuento.Location = New System.Drawing.Point(876, 86)
        Me.lblDisplayFolioDescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioDescuento.Name = "lblDisplayFolioDescuento"
        Me.lblDisplayFolioDescuento.Size = New System.Drawing.Size(87, 47)
        Me.lblDisplayFolioDescuento.TabIndex = 374
        Me.lblDisplayFolioDescuento.Text = "Folio nota descuento :"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Location = New System.Drawing.Point(585, 62)
        Me.lblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(275, 16)
        Me.lblAlmacen.TabIndex = 373
        Me.lblAlmacen.Text = "."
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(332, 22)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(72, 26)
        Me.btnSiguiente.TabIndex = 6
        Me.btnSiguiente.Text = ">>"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(252, 22)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(72, 26)
        Me.btnAnterior.TabIndex = 5
        Me.btnAnterior.Text = "<<"
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'lblDisplayFolioDevolucion
        '
        Me.lblDisplayFolioDevolucion.AutoSize = True
        Me.lblDisplayFolioDevolucion.Location = New System.Drawing.Point(15, 28)
        Me.lblDisplayFolioDevolucion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioDevolucion.Name = "lblDisplayFolioDevolucion"
        Me.lblDisplayFolioDevolucion.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplayFolioDevolucion.TabIndex = 224
        Me.lblDisplayFolioDevolucion.Text = "Folio dev :"
        '
        'txtFolioDevolucion
        '
        Me.txtFolioDevolucion.Location = New System.Drawing.Point(112, 23)
        Me.txtFolioDevolucion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioDevolucion.MaxLength = 15
        Me.txtFolioDevolucion.Name = "txtFolioDevolucion"
        Me.txtFolioDevolucion.Size = New System.Drawing.Size(119, 22)
        Me.txtFolioDevolucion.TabIndex = 0
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(15, 90)
        Me.lblDisplayFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(55, 17)
        Me.lblDisplayFecha.TabIndex = 228
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'dtFecha
        '
        Me.dtFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(112, 86)
        Me.dtFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(119, 22)
        Me.dtFecha.TabIndex = 2
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(112, 118)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProveedor.MaxLength = 8
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(119, 22)
        Me.txtProveedor.TabIndex = 3
        '
        'lblDisplayProveedor
        '
        Me.lblDisplayProveedor.AutoSize = True
        Me.lblDisplayProveedor.Location = New System.Drawing.Point(15, 121)
        Me.lblDisplayProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayProveedor.Name = "lblDisplayProveedor"
        Me.lblDisplayProveedor.Size = New System.Drawing.Size(82, 17)
        Me.lblDisplayProveedor.TabIndex = 232
        Me.lblDisplayProveedor.Text = "Proveedor :"
        '
        'lblProveedor
        '
        Me.lblProveedor.Location = New System.Drawing.Point(248, 122)
        Me.lblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(529, 16)
        Me.lblProveedor.TabIndex = 233
        Me.lblProveedor.Text = "."
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(112, 150)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConcepto.MaxLength = 160
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(1188, 26)
        Me.txtConcepto.TabIndex = 4
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(15, 151)
        Me.lblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.lblDisplayConcepto.TabIndex = 235
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'lblDisplayFolioVenta
        '
        Me.lblDisplayFolioVenta.AutoSize = True
        Me.lblDisplayFolioVenta.Location = New System.Drawing.Point(15, 59)
        Me.lblDisplayFolioVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioVenta.Name = "lblDisplayFolioVenta"
        Me.lblDisplayFolioVenta.Size = New System.Drawing.Size(97, 17)
        Me.lblDisplayFolioVenta.TabIndex = 237
        Me.lblDisplayFolioVenta.Text = "Folio compra :"
        '
        'txtFolioCompra
        '
        Me.txtFolioCompra.Enabled = False
        Me.txtFolioCompra.Location = New System.Drawing.Point(112, 54)
        Me.txtFolioCompra.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioCompra.MaxLength = 15
        Me.txtFolioCompra.Name = "txtFolioCompra"
        Me.txtFolioCompra.Size = New System.Drawing.Size(119, 22)
        Me.txtFolioCompra.TabIndex = 1
        '
        'lblDisplayAlmacen
        '
        Me.lblDisplayAlmacen.AutoSize = True
        Me.lblDisplayAlmacen.Location = New System.Drawing.Point(447, 62)
        Me.lblDisplayAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayAlmacen.Name = "lblDisplayAlmacen"
        Me.lblDisplayAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.lblDisplayAlmacen.TabIndex = 239
        Me.lblDisplayAlmacen.Text = "Almacén :"
        '
        'Frm_CXP_Devoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 743)
        Me.Controls.Add(Me.frmDatos)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_CXP_Devoluciones"
        Me.Text = "Devoluciones de compras"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
        Me.gbPesos.ResumeLayout(False)
        Me.gbPesos.PerformLayout()
        Me.gbDolares.ResumeLayout(False)
        Me.gbDolares.PerformLayout()
        Me.frmDatos.ResumeLayout(False)
        Me.frmDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbNuevo As ToolStripButton
    Friend WithEvents tsbGrabar As ToolStripButton
    Friend WithEvents tsbCancelar As ToolStripButton
    Friend WithEvents tsbImprimir As ToolStripButton
    Friend WithEvents tsbSellar As ToolStripButton
    Friend WithEvents tsbCancelarTimbre As ToolStripButton
    Friend WithEvents tsbRecuperaXMLPdf As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents StatusStripEstado As StatusStrip
    Friend WithEvents tssEstado As ToolStripStatusLabel
    Friend WithEvents tssElaboro As ToolStripStatusLabel
    Friend WithEvents tssCancelo As ToolStripStatusLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GridSeries As FlexCell.Grid
    Friend WithEvents gbTotales As GroupBox
    Friend WithEvents lblDisplayIEPSIncluido As Label
    Friend WithEvents lblIEPSIncluido As Label
    Friend WithEvents btnSeries As Button
    Friend WithEvents lblDisplayTipoCambio As Label
    Friend WithEvents txtTipoCambio As TextBox
    Friend WithEvents lblPoliza As LinkLabel
    Friend WithEvents gbPesos As GroupBox
    Friend WithEvents lblIEPS As Label
    Friend WithEvents lblDisplayIEPS As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblImpuesto As Label
    Friend WithEvents lblDisplayTotalPesos As Label
    Friend WithEvents lblDisplaySubtotalPesos As Label
    Friend WithEvents lblDisplayImpuestoPesos As Label
    Friend WithEvents lblDisplayStatus As Label
    Friend WithEvents lblEstatus As Label
    Friend WithEvents lblDisplayPoliza As Label
    Friend WithEvents gbDolares As GroupBox
    Friend WithEvents lblTotalDolares As Label
    Friend WithEvents lblSubtotalDolares As Label
    Friend WithEvents lblImpuestoDolares As Label
    Friend WithEvents lblDisplayTotalDolares As Label
    Friend WithEvents lblDisplaySubtotalDolares As Label
    Friend WithEvents lblDisplayImpuestoDolares As Label
    Friend WithEvents chkDolares As CheckBox
    Friend WithEvents frmDatos As GroupBox
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents btnAnterior As Button
    Friend WithEvents lblDisplayFolioDevolucion As Label
    Friend WithEvents txtFolioDevolucion As TextBox
    Friend WithEvents lblDisplayFecha As Label
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents lblDisplayProveedor As Label
    Friend WithEvents lblProveedor As Label
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents lblDisplayConcepto As Label
    Friend WithEvents lblDisplayFolioVenta As Label
    Friend WithEvents txtFolioCompra As TextBox
    Friend WithEvents lblDisplayAlmacen As Label
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents txtFolioDescuento As TextBox
    Friend WithEvents lblDisplayFolioDescuento As Label
    Friend WithEvents tsbEnviarCorreo As ToolStripButton
    Friend WithEvents txtAlmacen As TextBox
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents lblDisplaySaldo As Label
End Class
