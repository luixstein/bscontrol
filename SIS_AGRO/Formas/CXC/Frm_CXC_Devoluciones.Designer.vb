<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_CXC_Devoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXC_Devoluciones))
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grid = New FlexCell.Grid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridSeries = New FlexCell.Grid()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.lblDisplayIEPSIncluido = New System.Windows.Forms.Label()
        Me.lblIEPSIncluido = New System.Windows.Forms.Label()
        Me.btnSeries = New System.Windows.Forms.Button()
        Me.gbPesos = New System.Windows.Forms.GroupBox()
        Me.lblDisplayRetencionISR = New System.Windows.Forms.Label()
        Me.lblIEPS = New System.Windows.Forms.Label()
        Me.lblRetencionISR = New System.Windows.Forms.Label()
        Me.lblDisplayIEPS = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblDisplayRetencionIVA = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lblImpuesto = New System.Windows.Forms.Label()
        Me.lblRetencionIVA = New System.Windows.Forms.Label()
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
        Me.lblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.txtFolioVenta = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioVenta = New System.Windows.Forms.Label()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.chkVentaPublicoGeneral = New System.Windows.Forms.CheckBox()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.lblDisplayPoliza = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.lblPoliza = New System.Windows.Forms.LinkLabel()
        Me.txtFolioDevolucion = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioDevolucion = New System.Windows.Forms.Label()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblDisplayFolioDescuento = New System.Windows.Forms.Label()
        Me.txtFolioDescuento = New System.Windows.Forms.TextBox()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblDisplaySaldo = New System.Windows.Forms.Label()
        Me.lblDisplayTipoCambio = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.LblDisplayMoneda = New System.Windows.Forms.Label()
        Me.lblDisplayUsoCFDI = New System.Windows.Forms.Label()
        Me.lblFormaPago = New System.Windows.Forms.Label()
        Me.cboMetodoPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayMetodoPago = New System.Windows.Forms.Label()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblVersionCFDI = New System.Windows.Forms.Label()
        Me.lblDisplayTipoRelacionCFDI = New System.Windows.Forms.Label()
        Me.cboTipoRelacionCFDI = New System.Windows.Forms.ComboBox()
        Me.cboRegimenFiscalEmisor = New System.Windows.Forms.ComboBox()
        Me.lblDisplayRegimenFiscalEmisor = New System.Windows.Forms.Label()
        Me.lblRegimenFiscalReceptor = New System.Windows.Forms.Label()
        Me.txtRegimenFiscalReceptor = New System.Windows.Forms.TextBox()
        Me.lblDisplayRegimenFiscalReceptor = New System.Windows.Forms.Label()
        Me.frmDatos = New System.Windows.Forms.GroupBox()
        Me.txtUsoCFDI = New System.Windows.Forms.TextBox()
        Me.lblUsoCFDI = New System.Windows.Forms.Label()
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
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbTimbrar, Me.tsbCancelarTimbre, Me.tsbRecuperarXMLPDF, Me.tsbEnviarCorreo, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(992, 27)
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
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(80, 24)
        Me.tsbCancelar.Text = " Cancelar"
        Me.tsbCancelar.Visible = False
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
        'tsbTimbrar
        '
        Me.tsbTimbrar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbTimbrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTimbrar.Name = "tsbTimbrar"
        Me.tsbTimbrar.Size = New System.Drawing.Size(72, 24)
        Me.tsbTimbrar.Text = "Timbrar"
        '
        'tsbCancelarTimbre
        '
        Me.tsbCancelarTimbre.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbCancelarTimbre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelarTimbre.Name = "tsbCancelarTimbre"
        Me.tsbCancelarTimbre.Size = New System.Drawing.Size(115, 24)
        Me.tsbCancelarTimbre.Text = "Cancelar timbre"
        '
        'tsbRecuperarXMLPDF
        '
        Me.tsbRecuperarXMLPDF.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbRecuperarXMLPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecuperarXMLPDF.Name = "tsbRecuperarXMLPDF"
        Me.tsbRecuperarXMLPDF.Size = New System.Drawing.Size(130, 24)
        Me.tsbRecuperarXMLPDF.Text = "Recuperar xml/pdf"
        '
        'tsbEnviarCorreo
        '
        Me.tsbEnviarCorreo.Image = CType(resources.GetObject("tsbEnviarCorreo.Image"), System.Drawing.Image)
        Me.tsbEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarCorreo.Name = "tsbEnviarCorreo"
        Me.tsbEnviarCorreo.Size = New System.Drawing.Size(100, 24)
        Me.tsbEnviarCorreo.Text = "&Enviar correo"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 654)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(992, 24)
        Me.StatusStripEstado.TabIndex = 242
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 262)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(986, 238)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(978, 212)
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
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(3, 6)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(969, 204)
        Me.Grid.TabIndex = 2
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridSeries)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(978, 212)
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
        Me.GridSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSeries.Location = New System.Drawing.Point(5, 6)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(966, 198)
        Me.GridSeries.TabIndex = 2
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbTotales
        '
        Me.gbTotales.Controls.Add(Me.lblDisplayIEPSIncluido)
        Me.gbTotales.Controls.Add(Me.lblIEPSIncluido)
        Me.gbTotales.Controls.Add(Me.btnSeries)
        Me.gbTotales.Controls.Add(Me.gbPesos)
        Me.gbTotales.Controls.Add(Me.gbDolares)
        Me.gbTotales.Location = New System.Drawing.Point(4, 506)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Size = New System.Drawing.Size(986, 145)
        Me.gbTotales.TabIndex = 244
        Me.gbTotales.TabStop = False
        '
        'lblDisplayIEPSIncluido
        '
        Me.lblDisplayIEPSIncluido.AutoSize = True
        Me.lblDisplayIEPSIncluido.Location = New System.Drawing.Point(853, 16)
        Me.lblDisplayIEPSIncluido.Name = "lblDisplayIEPSIncluido"
        Me.lblDisplayIEPSIncluido.Size = New System.Drawing.Size(77, 13)
        Me.lblDisplayIEPSIncluido.TabIndex = 383
        Me.lblDisplayIEPSIncluido.Text = "IEPS Incluido :"
        '
        'lblIEPSIncluido
        '
        Me.lblIEPSIncluido.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPSIncluido.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPSIncluido.Location = New System.Drawing.Point(820, 34)
        Me.lblIEPSIncluido.Name = "lblIEPSIncluido"
        Me.lblIEPSIncluido.Size = New System.Drawing.Size(110, 13)
        Me.lblIEPSIncluido.TabIndex = 382
        Me.lblIEPSIncluido.Text = "0.00"
        Me.lblIEPSIncluido.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSeries
        '
        Me.btnSeries.Location = New System.Drawing.Point(9, 65)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(109, 32)
        Me.btnSeries.TabIndex = 381
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        '
        'gbPesos
        '
        Me.gbPesos.Controls.Add(Me.lblDisplayRetencionISR)
        Me.gbPesos.Controls.Add(Me.lblIEPS)
        Me.gbPesos.Controls.Add(Me.lblRetencionISR)
        Me.gbPesos.Controls.Add(Me.lblDisplayIEPS)
        Me.gbPesos.Controls.Add(Me.lblTotal)
        Me.gbPesos.Controls.Add(Me.lblDisplayRetencionIVA)
        Me.gbPesos.Controls.Add(Me.lblSubtotal)
        Me.gbPesos.Controls.Add(Me.lblImpuesto)
        Me.gbPesos.Controls.Add(Me.lblRetencionIVA)
        Me.gbPesos.Controls.Add(Me.lblDisplayTotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplaySubtotalPesos)
        Me.gbPesos.Controls.Add(Me.lblDisplayImpuestoPesos)
        Me.gbPesos.Location = New System.Drawing.Point(625, 0)
        Me.gbPesos.Name = "gbPesos"
        Me.gbPesos.Size = New System.Drawing.Size(184, 133)
        Me.gbPesos.TabIndex = 292
        Me.gbPesos.TabStop = False
        Me.gbPesos.Text = "Pesos"
        '
        'lblDisplayRetencionISR
        '
        Me.lblDisplayRetencionISR.AutoSize = True
        Me.lblDisplayRetencionISR.Location = New System.Drawing.Point(7, 90)
        Me.lblDisplayRetencionISR.Name = "lblDisplayRetencionISR"
        Me.lblDisplayRetencionISR.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayRetencionISR.TabIndex = 261
        Me.lblDisplayRetencionISR.Text = "Ret. ISR :"
        '
        'lblIEPS
        '
        Me.lblIEPS.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblIEPS.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIEPS.Location = New System.Drawing.Point(68, 35)
        Me.lblIEPS.Name = "lblIEPS"
        Me.lblIEPS.Size = New System.Drawing.Size(110, 13)
        Me.lblIEPS.TabIndex = 251
        Me.lblIEPS.Text = "0.00"
        Me.lblIEPS.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRetencionISR
        '
        Me.lblRetencionISR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblRetencionISR.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRetencionISR.Location = New System.Drawing.Point(68, 90)
        Me.lblRetencionISR.Name = "lblRetencionISR"
        Me.lblRetencionISR.Size = New System.Drawing.Size(110, 14)
        Me.lblRetencionISR.TabIndex = 260
        Me.lblRetencionISR.Text = "0.00"
        Me.lblRetencionISR.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayIEPS
        '
        Me.lblDisplayIEPS.AutoSize = True
        Me.lblDisplayIEPS.Location = New System.Drawing.Point(6, 34)
        Me.lblDisplayIEPS.Name = "lblDisplayIEPS"
        Me.lblDisplayIEPS.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayIEPS.TabIndex = 250
        Me.lblDisplayIEPS.Text = "IEPS :"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotal.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotal.Location = New System.Drawing.Point(68, 110)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(110, 13)
        Me.lblTotal.TabIndex = 249
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayRetencionIVA
        '
        Me.lblDisplayRetencionIVA.AutoSize = True
        Me.lblDisplayRetencionIVA.Location = New System.Drawing.Point(7, 72)
        Me.lblDisplayRetencionIVA.Name = "lblDisplayRetencionIVA"
        Me.lblDisplayRetencionIVA.Size = New System.Drawing.Size(53, 13)
        Me.lblDisplayRetencionIVA.TabIndex = 259
        Me.lblDisplayRetencionIVA.Text = "Ret. IVA :"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSubtotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSubtotal.Location = New System.Drawing.Point(68, 16)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(110, 13)
        Me.lblSubtotal.TabIndex = 247
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblImpuesto
        '
        Me.lblImpuesto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblImpuesto.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblImpuesto.Location = New System.Drawing.Point(68, 54)
        Me.lblImpuesto.Name = "lblImpuesto"
        Me.lblImpuesto.Size = New System.Drawing.Size(110, 13)
        Me.lblImpuesto.TabIndex = 248
        Me.lblImpuesto.Text = "0.00"
        Me.lblImpuesto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRetencionIVA
        '
        Me.lblRetencionIVA.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblRetencionIVA.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRetencionIVA.Location = New System.Drawing.Point(68, 72)
        Me.lblRetencionIVA.Name = "lblRetencionIVA"
        Me.lblRetencionIVA.Size = New System.Drawing.Size(111, 14)
        Me.lblRetencionIVA.TabIndex = 258
        Me.lblRetencionIVA.Text = "0.00"
        Me.lblRetencionIVA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(7, 110)
        Me.lblDisplayTotalPesos.Name = "lblDisplayTotalPesos"
        Me.lblDisplayTotalPesos.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayTotalPesos.TabIndex = 246
        Me.lblDisplayTotalPesos.Text = "Total :"
        '
        'lblDisplaySubtotalPesos
        '
        Me.lblDisplaySubtotalPesos.AutoSize = True
        Me.lblDisplaySubtotalPesos.Location = New System.Drawing.Point(6, 16)
        Me.lblDisplaySubtotalPesos.Name = "lblDisplaySubtotalPesos"
        Me.lblDisplaySubtotalPesos.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplaySubtotalPesos.TabIndex = 242
        Me.lblDisplaySubtotalPesos.Text = "Subtotal :"
        '
        'lblDisplayImpuestoPesos
        '
        Me.lblDisplayImpuestoPesos.AutoSize = True
        Me.lblDisplayImpuestoPesos.Location = New System.Drawing.Point(6, 53)
        Me.lblDisplayImpuestoPesos.Name = "lblDisplayImpuestoPesos"
        Me.lblDisplayImpuestoPesos.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayImpuestoPesos.TabIndex = 244
        Me.lblDisplayImpuestoPesos.Text = "IVA :"
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.lblTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblSubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblImpuestoDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayTotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplaySubtotalDolares)
        Me.gbDolares.Controls.Add(Me.lblDisplayImpuestoDolares)
        Me.gbDolares.Location = New System.Drawing.Point(449, 19)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Size = New System.Drawing.Size(176, 78)
        Me.gbDolares.TabIndex = 293
        Me.gbDolares.TabStop = False
        Me.gbDolares.Text = "Dólares"
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
        Me.lblDisplayImpuestoDolares.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayImpuestoDolares.TabIndex = 244
        Me.lblDisplayImpuestoDolares.Text = "IVA :"
        '
        'lblDisplayAlmacen
        '
        Me.lblDisplayAlmacen.AutoSize = True
        Me.lblDisplayAlmacen.Location = New System.Drawing.Point(335, 50)
        Me.lblDisplayAlmacen.Name = "lblDisplayAlmacen"
        Me.lblDisplayAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayAlmacen.TabIndex = 239
        Me.lblDisplayAlmacen.Text = "Almacén :"
        '
        'txtFolioVenta
        '
        Me.txtFolioVenta.Enabled = False
        Me.txtFolioVenta.Location = New System.Drawing.Point(84, 44)
        Me.txtFolioVenta.MaxLength = 15
        Me.txtFolioVenta.Name = "txtFolioVenta"
        Me.txtFolioVenta.Size = New System.Drawing.Size(90, 20)
        Me.txtFolioVenta.TabIndex = 1
        '
        'lblDisplayFolioVenta
        '
        Me.lblDisplayFolioVenta.AutoSize = True
        Me.lblDisplayFolioVenta.Location = New System.Drawing.Point(2, 48)
        Me.lblDisplayFolioVenta.Name = "lblDisplayFolioVenta"
        Me.lblDisplayFolioVenta.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayFolioVenta.TabIndex = 237
        Me.lblDisplayFolioVenta.Text = "Folio venta :"
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(2, 199)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayConcepto.TabIndex = 235
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(84, 196)
        Me.txtConcepto.MaxLength = 160
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(892, 22)
        Me.txtConcepto.TabIndex = 10
        '
        'lblCliente
        '
        Me.lblCliente.Location = New System.Drawing.Point(186, 99)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(397, 13)
        Me.lblCliente.TabIndex = 233
        Me.lblCliente.Text = "."
        '
        'chkVentaPublicoGeneral
        '
        Me.chkVentaPublicoGeneral.AutoSize = True
        Me.chkVentaPublicoGeneral.Enabled = False
        Me.chkVentaPublicoGeneral.Location = New System.Drawing.Point(189, 48)
        Me.chkVentaPublicoGeneral.Name = "chkVentaPublicoGeneral"
        Me.chkVentaPublicoGeneral.Size = New System.Drawing.Size(140, 17)
        Me.chkVentaPublicoGeneral.TabIndex = 13
        Me.chkVentaPublicoGeneral.Text = "Venta al público general"
        Me.chkVentaPublicoGeneral.UseVisualStyleBackColor = True
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(2, 98)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 232
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'lblDisplayPoliza
        '
        Me.lblDisplayPoliza.AutoSize = True
        Me.lblDisplayPoliza.Location = New System.Drawing.Point(658, 42)
        Me.lblDisplayPoliza.Name = "lblDisplayPoliza"
        Me.lblDisplayPoliza.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayPoliza.TabIndex = 283
        Me.lblDisplayPoliza.Text = "Póliza :"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(84, 96)
        Me.txtCliente.MaxLength = 8
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(90, 20)
        Me.txtCliente.TabIndex = 3
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEstatus.Location = New System.Drawing.Point(712, 16)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(10, 13)
        Me.lblEstatus.TabIndex = 226
        Me.lblEstatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(658, 16)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 225
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'dtFecha
        '
        Me.dtFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(84, 70)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(90, 20)
        Me.dtFecha.TabIndex = 2
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(2, 73)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 228
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'lblPoliza
        '
        Me.lblPoliza.AutoSize = True
        Me.lblPoliza.Location = New System.Drawing.Point(712, 42)
        Me.lblPoliza.Name = "lblPoliza"
        Me.lblPoliza.Size = New System.Drawing.Size(13, 13)
        Me.lblPoliza.TabIndex = 330
        Me.lblPoliza.TabStop = True
        Me.lblPoliza.Text = "_"
        '
        'txtFolioDevolucion
        '
        Me.txtFolioDevolucion.Location = New System.Drawing.Point(84, 19)
        Me.txtFolioDevolucion.MaxLength = 15
        Me.txtFolioDevolucion.Name = "txtFolioDevolucion"
        Me.txtFolioDevolucion.Size = New System.Drawing.Size(90, 20)
        Me.txtFolioDevolucion.TabIndex = 0
        '
        'lblDisplayFolioDevolucion
        '
        Me.lblDisplayFolioDevolucion.AutoSize = True
        Me.lblDisplayFolioDevolucion.Location = New System.Drawing.Point(2, 23)
        Me.lblDisplayFolioDevolucion.Name = "lblDisplayFolioDevolucion"
        Me.lblDisplayFolioDevolucion.Size = New System.Drawing.Size(56, 13)
        Me.lblDisplayFolioDevolucion.TabIndex = 224
        Me.lblDisplayFolioDevolucion.Text = "Folio dev :"
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(189, 18)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(54, 21)
        Me.btnAnterior.TabIndex = 11
        Me.btnAnterior.Text = "<<"
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(249, 18)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(54, 21)
        Me.btnSiguiente.TabIndex = 12
        Me.btnSiguiente.Text = ">>"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Location = New System.Drawing.Point(439, 50)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(206, 13)
        Me.lblAlmacen.TabIndex = 373
        Me.lblAlmacen.Text = "."
        '
        'lblDisplayFolioDescuento
        '
        Me.lblDisplayFolioDescuento.Location = New System.Drawing.Point(820, 42)
        Me.lblDisplayFolioDescuento.Name = "lblDisplayFolioDescuento"
        Me.lblDisplayFolioDescuento.Size = New System.Drawing.Size(65, 38)
        Me.lblDisplayFolioDescuento.TabIndex = 374
        Me.lblDisplayFolioDescuento.Text = "Folio nota descuento :"
        '
        'txtFolioDescuento
        '
        Me.txtFolioDescuento.Enabled = False
        Me.txtFolioDescuento.Location = New System.Drawing.Point(891, 45)
        Me.txtFolioDescuento.MaxLength = 15
        Me.txtFolioDescuento.Name = "txtFolioDescuento"
        Me.txtFolioDescuento.ReadOnly = True
        Me.txtFolioDescuento.Size = New System.Drawing.Size(90, 20)
        Me.txtFolioDescuento.TabIndex = 17
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Location = New System.Drawing.Point(395, 48)
        Me.txtAlmacen.MaxLength = 15
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(36, 20)
        Me.txtAlmacen.TabIndex = 375
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(281, 172)
        Me.txtTipoCambio.MaxLength = 8
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(79, 20)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "0"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipoCambio.Visible = False
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(335, 73)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplaySaldo.TabIndex = 377
        Me.lblDisplaySaldo.Text = "Saldo :"
        '
        'lblDisplayTipoCambio
        '
        Me.lblDisplayTipoCambio.AutoSize = True
        Me.lblDisplayTipoCambio.Location = New System.Drawing.Point(189, 174)
        Me.lblDisplayTipoCambio.Name = "lblDisplayTipoCambio"
        Me.lblDisplayTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblDisplayTipoCambio.TabIndex = 332
        Me.lblDisplayTipoCambio.Text = "Tipo de cambio :"
        Me.lblDisplayTipoCambio.Visible = False
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(395, 70)
        Me.txtSaldo.MaxLength = 8
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(90, 20)
        Me.txtSaldo.TabIndex = 14
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(84, 171)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(90, 21)
        Me.cboMoneda.TabIndex = 6
        '
        'LblDisplayMoneda
        '
        Me.LblDisplayMoneda.AutoSize = True
        Me.LblDisplayMoneda.Location = New System.Drawing.Point(2, 174)
        Me.LblDisplayMoneda.Name = "LblDisplayMoneda"
        Me.LblDisplayMoneda.Size = New System.Drawing.Size(52, 13)
        Me.LblDisplayMoneda.TabIndex = 379
        Me.LblDisplayMoneda.Text = "Moneda :"
        '
        'lblDisplayUsoCFDI
        '
        Me.lblDisplayUsoCFDI.AutoSize = True
        Me.lblDisplayUsoCFDI.Location = New System.Drawing.Point(2, 148)
        Me.lblDisplayUsoCFDI.Name = "lblDisplayUsoCFDI"
        Me.lblDisplayUsoCFDI.Size = New System.Drawing.Size(76, 13)
        Me.lblDisplayUsoCFDI.TabIndex = 383
        Me.lblDisplayUsoCFDI.Text = "Uso del CFDI :"
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.Location = New System.Drawing.Point(495, 123)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(84, 13)
        Me.lblFormaPago.TabIndex = 386
        Me.lblFormaPago.Text = "Forma de pago :"
        '
        'cboMetodoPago
        '
        Me.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMetodoPago.Enabled = False
        Me.cboMetodoPago.FormattingEnabled = True
        Me.cboMetodoPago.Location = New System.Drawing.Point(615, 144)
        Me.cboMetodoPago.MaxLength = 1
        Me.cboMetodoPago.Name = "cboMetodoPago"
        Me.cboMetodoPago.Size = New System.Drawing.Size(301, 21)
        Me.cboMetodoPago.TabIndex = 9
        '
        'lblDisplayMetodoPago
        '
        Me.lblDisplayMetodoPago.AutoSize = True
        Me.lblDisplayMetodoPago.Location = New System.Drawing.Point(495, 146)
        Me.lblDisplayMetodoPago.Name = "lblDisplayMetodoPago"
        Me.lblDisplayMetodoPago.Size = New System.Drawing.Size(91, 13)
        Me.lblDisplayMetodoPago.TabIndex = 387
        Me.lblDisplayMetodoPago.Text = "Método de pago :"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(615, 119)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(219, 21)
        Me.cboFormaPago.TabIndex = 8
        '
        'lblVersionCFDI
        '
        Me.lblVersionCFDI.AutoSize = True
        Me.lblVersionCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersionCFDI.Location = New System.Drawing.Point(944, 16)
        Me.lblVersionCFDI.Name = "lblVersionCFDI"
        Me.lblVersionCFDI.Size = New System.Drawing.Size(34, 20)
        Me.lblVersionCFDI.TabIndex = 388
        Me.lblVersionCFDI.Text = "0.0"
        Me.lblVersionCFDI.Visible = False
        '
        'lblDisplayTipoRelacionCFDI
        '
        Me.lblDisplayTipoRelacionCFDI.AutoSize = True
        Me.lblDisplayTipoRelacionCFDI.Location = New System.Drawing.Point(495, 73)
        Me.lblDisplayTipoRelacionCFDI.Name = "lblDisplayTipoRelacionCFDI"
        Me.lblDisplayTipoRelacionCFDI.Size = New System.Drawing.Size(101, 13)
        Me.lblDisplayTipoRelacionCFDI.TabIndex = 395
        Me.lblDisplayTipoRelacionCFDI.Text = "Tipo relación CFDI :"
        '
        'cboTipoRelacionCFDI
        '
        Me.cboTipoRelacionCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRelacionCFDI.FormattingEnabled = True
        Me.cboTipoRelacionCFDI.Location = New System.Drawing.Point(615, 70)
        Me.cboTipoRelacionCFDI.MaxLength = 1
        Me.cboTipoRelacionCFDI.Name = "cboTipoRelacionCFDI"
        Me.cboTipoRelacionCFDI.Size = New System.Drawing.Size(338, 21)
        Me.cboTipoRelacionCFDI.TabIndex = 15
        '
        'cboRegimenFiscalEmisor
        '
        Me.cboRegimenFiscalEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegimenFiscalEmisor.FormattingEnabled = True
        Me.cboRegimenFiscalEmisor.Location = New System.Drawing.Point(615, 95)
        Me.cboRegimenFiscalEmisor.MaxLength = 1
        Me.cboRegimenFiscalEmisor.Name = "cboRegimenFiscalEmisor"
        Me.cboRegimenFiscalEmisor.Size = New System.Drawing.Size(281, 21)
        Me.cboRegimenFiscalEmisor.TabIndex = 16
        '
        'lblDisplayRegimenFiscalEmisor
        '
        Me.lblDisplayRegimenFiscalEmisor.AutoSize = True
        Me.lblDisplayRegimenFiscalEmisor.Location = New System.Drawing.Point(495, 98)
        Me.lblDisplayRegimenFiscalEmisor.Name = "lblDisplayRegimenFiscalEmisor"
        Me.lblDisplayRegimenFiscalEmisor.Size = New System.Drawing.Size(115, 13)
        Me.lblDisplayRegimenFiscalEmisor.TabIndex = 397
        Me.lblDisplayRegimenFiscalEmisor.Text = "Régimen fiscal emisor :"
        '
        'lblRegimenFiscalReceptor
        '
        Me.lblRegimenFiscalReceptor.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRegimenFiscalReceptor.Location = New System.Drawing.Point(135, 124)
        Me.lblRegimenFiscalReceptor.Name = "lblRegimenFiscalReceptor"
        Me.lblRegimenFiscalReceptor.Size = New System.Drawing.Size(226, 13)
        Me.lblRegimenFiscalReceptor.TabIndex = 399
        Me.lblRegimenFiscalReceptor.Text = "_"
        '
        'txtRegimenFiscalReceptor
        '
        Me.txtRegimenFiscalReceptor.Location = New System.Drawing.Point(84, 121)
        Me.txtRegimenFiscalReceptor.MaxLength = 3
        Me.txtRegimenFiscalReceptor.Name = "txtRegimenFiscalReceptor"
        Me.txtRegimenFiscalReceptor.Size = New System.Drawing.Size(45, 20)
        Me.txtRegimenFiscalReceptor.TabIndex = 4
        '
        'lblDisplayRegimenFiscalReceptor
        '
        Me.lblDisplayRegimenFiscalReceptor.Location = New System.Drawing.Point(2, 122)
        Me.lblDisplayRegimenFiscalReceptor.Name = "lblDisplayRegimenFiscalReceptor"
        Me.lblDisplayRegimenFiscalReceptor.Size = New System.Drawing.Size(82, 29)
        Me.lblDisplayRegimenFiscalReceptor.TabIndex = 400
        Me.lblDisplayRegimenFiscalReceptor.Text = "Régimen fiscal receptor :"
        '
        'frmDatos
        '
        Me.frmDatos.Controls.Add(Me.lblDisplayUsoCFDI)
        Me.frmDatos.Controls.Add(Me.txtUsoCFDI)
        Me.frmDatos.Controls.Add(Me.lblUsoCFDI)
        Me.frmDatos.Controls.Add(Me.lblDisplayRegimenFiscalReceptor)
        Me.frmDatos.Controls.Add(Me.txtRegimenFiscalReceptor)
        Me.frmDatos.Controls.Add(Me.lblRegimenFiscalReceptor)
        Me.frmDatos.Controls.Add(Me.lblDisplayRegimenFiscalEmisor)
        Me.frmDatos.Controls.Add(Me.cboRegimenFiscalEmisor)
        Me.frmDatos.Controls.Add(Me.cboTipoRelacionCFDI)
        Me.frmDatos.Controls.Add(Me.lblDisplayTipoRelacionCFDI)
        Me.frmDatos.Controls.Add(Me.lblVersionCFDI)
        Me.frmDatos.Controls.Add(Me.cboFormaPago)
        Me.frmDatos.Controls.Add(Me.lblDisplayMetodoPago)
        Me.frmDatos.Controls.Add(Me.cboMetodoPago)
        Me.frmDatos.Controls.Add(Me.lblFormaPago)
        Me.frmDatos.Controls.Add(Me.LblDisplayMoneda)
        Me.frmDatos.Controls.Add(Me.cboMoneda)
        Me.frmDatos.Controls.Add(Me.txtSaldo)
        Me.frmDatos.Controls.Add(Me.lblDisplayTipoCambio)
        Me.frmDatos.Controls.Add(Me.lblDisplaySaldo)
        Me.frmDatos.Controls.Add(Me.txtTipoCambio)
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
        Me.frmDatos.Controls.Add(Me.txtCliente)
        Me.frmDatos.Controls.Add(Me.lblDisplayPoliza)
        Me.frmDatos.Controls.Add(Me.lblDisplayCliente)
        Me.frmDatos.Controls.Add(Me.chkVentaPublicoGeneral)
        Me.frmDatos.Controls.Add(Me.lblCliente)
        Me.frmDatos.Controls.Add(Me.txtConcepto)
        Me.frmDatos.Controls.Add(Me.lblDisplayConcepto)
        Me.frmDatos.Controls.Add(Me.lblDisplayFolioVenta)
        Me.frmDatos.Controls.Add(Me.txtFolioVenta)
        Me.frmDatos.Controls.Add(Me.lblDisplayAlmacen)
        Me.frmDatos.Location = New System.Drawing.Point(4, 28)
        Me.frmDatos.Name = "frmDatos"
        Me.frmDatos.Size = New System.Drawing.Size(986, 224)
        Me.frmDatos.TabIndex = 0
        Me.frmDatos.TabStop = False
        '
        'txtUsoCFDI
        '
        Me.txtUsoCFDI.Location = New System.Drawing.Point(84, 145)
        Me.txtUsoCFDI.MaxLength = 3
        Me.txtUsoCFDI.Name = "txtUsoCFDI"
        Me.txtUsoCFDI.Size = New System.Drawing.Size(45, 20)
        Me.txtUsoCFDI.TabIndex = 5
        '
        'lblUsoCFDI
        '
        Me.lblUsoCFDI.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUsoCFDI.Location = New System.Drawing.Point(133, 148)
        Me.lblUsoCFDI.Name = "lblUsoCFDI"
        Me.lblUsoCFDI.Size = New System.Drawing.Size(226, 13)
        Me.lblUsoCFDI.TabIndex = 402
        Me.lblUsoCFDI.Text = "_"
        '
        'Frm_CXC_Devoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 678)
        Me.Controls.Add(Me.frmDatos)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXC_Devoluciones"
        Me.Text = "Devoluciones de ventas"
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
    Friend WithEvents tsbTimbrar As ToolStripButton
    Friend WithEvents tsbCancelarTimbre As ToolStripButton
    Friend WithEvents tsbRecuperarXMLPDF As ToolStripButton
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
    Friend WithEvents gbPesos As GroupBox
    Friend WithEvents lblIEPS As Label
    Friend WithEvents lblDisplayIEPS As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblImpuesto As Label
    Friend WithEvents lblDisplayTotalPesos As Label
    Friend WithEvents lblDisplaySubtotalPesos As Label
    Friend WithEvents lblDisplayImpuestoPesos As Label
    Friend WithEvents gbDolares As GroupBox
    Friend WithEvents lblTotalDolares As Label
    Friend WithEvents lblSubtotalDolares As Label
    Friend WithEvents lblImpuestoDolares As Label
    Friend WithEvents lblDisplayTotalDolares As Label
    Friend WithEvents lblDisplaySubtotalDolares As Label
    Friend WithEvents lblDisplayImpuestoDolares As Label
    Friend WithEvents tsbEnviarCorreo As ToolStripButton
    Friend WithEvents lblDisplayRetencionISR As System.Windows.Forms.Label
    Friend WithEvents lblRetencionISR As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRetencionIVA As System.Windows.Forms.Label
    Friend WithEvents lblRetencionIVA As System.Windows.Forms.Label
    Friend WithEvents lblDisplayAlmacen As Label
    Friend WithEvents txtFolioVenta As TextBox
    Friend WithEvents lblDisplayFolioVenta As Label
    Friend WithEvents lblDisplayConcepto As Label
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents lblCliente As Label
    Friend WithEvents chkVentaPublicoGeneral As CheckBox
    Friend WithEvents lblDisplayCliente As Label
    Friend WithEvents lblDisplayPoliza As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lblEstatus As Label
    Friend WithEvents lblDisplayStatus As Label
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents lblDisplayFecha As Label
    Friend WithEvents lblPoliza As LinkLabel
    Friend WithEvents txtFolioDevolucion As TextBox
    Friend WithEvents lblDisplayFolioDevolucion As Label
    Friend WithEvents btnAnterior As Button
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents lblDisplayFolioDescuento As Label
    Friend WithEvents txtFolioDescuento As TextBox
    Friend WithEvents txtAlmacen As TextBox
    Friend WithEvents txtTipoCambio As TextBox
    Friend WithEvents lblDisplaySaldo As Label
    Friend WithEvents lblDisplayTipoCambio As Label
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents cboMoneda As ComboBox
    Friend WithEvents LblDisplayMoneda As Label
    Friend WithEvents lblDisplayUsoCFDI As Label
    Friend WithEvents lblFormaPago As Label
    Friend WithEvents cboMetodoPago As ComboBox
    Friend WithEvents lblDisplayMetodoPago As Label
    Friend WithEvents cboFormaPago As ComboBox
    Friend WithEvents lblVersionCFDI As Label
    Friend WithEvents lblDisplayTipoRelacionCFDI As Label
    Friend WithEvents cboTipoRelacionCFDI As ComboBox
    Friend WithEvents cboRegimenFiscalEmisor As ComboBox
    Friend WithEvents lblDisplayRegimenFiscalEmisor As Label
    Friend WithEvents lblRegimenFiscalReceptor As Label
    Friend WithEvents txtRegimenFiscalReceptor As TextBox
    Friend WithEvents lblDisplayRegimenFiscalReceptor As Label
    Friend WithEvents frmDatos As GroupBox
    Friend WithEvents txtUsoCFDI As TextBox
    Friend WithEvents lblUsoCFDI As Label
End Class
