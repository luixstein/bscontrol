<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Ventas_ProductosVendidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Ventas_ProductosVendidos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RdnDevoluciones = New System.Windows.Forms.RadioButton()
        Me.RdnVentasPorFacturas = New System.Windows.Forms.RadioButton()
        Me.RdnVentasPorCultivo = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkSoloUtilidadNegativa = New System.Windows.Forms.CheckBox()
        Me.lblCultivoAgricola = New System.Windows.Forms.Label()
        Me.CboCultivoAgricola = New System.Windows.Forms.ComboBox()
        Me.LblNombreProducto = New System.Windows.Forms.Label()
        Me.TxtCodigoProducto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblDisplayZona = New System.Windows.Forms.Label()
        Me.CboZona = New System.Windows.Forms.ComboBox()
        Me.CboMercado = New System.Windows.Forms.ComboBox()
        Me.LblDisplayMercado = New System.Windows.Forms.Label()
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.CboLinea = New System.Windows.Forms.ComboBox()
        Me.LblDisplayLinea = New System.Windows.Forms.Label()
        Me.lblDocumentos = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.CkbFechaReferencia = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblFamilia = New System.Windows.Forms.Label()
        Me.CboFamilia = New System.Windows.Forms.ComboBox()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(980, 27)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(95, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdnDevoluciones)
        Me.GroupBox1.Controls.Add(Me.RdnVentasPorFacturas)
        Me.GroupBox1.Controls.Add(Me.RdnVentasPorCultivo)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(267, 116)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'RdnDevoluciones
        '
        Me.RdnDevoluciones.AutoSize = True
        Me.RdnDevoluciones.Location = New System.Drawing.Point(21, 82)
        Me.RdnDevoluciones.Margin = New System.Windows.Forms.Padding(4)
        Me.RdnDevoluciones.Name = "RdnDevoluciones"
        Me.RdnDevoluciones.Size = New System.Drawing.Size(114, 21)
        Me.RdnDevoluciones.TabIndex = 2
        Me.RdnDevoluciones.Text = "Devoluciones"
        Me.RdnDevoluciones.UseVisualStyleBackColor = True
        '
        'RdnVentasPorFacturas
        '
        Me.RdnVentasPorFacturas.AutoSize = True
        Me.RdnVentasPorFacturas.Checked = True
        Me.RdnVentasPorFacturas.Location = New System.Drawing.Point(21, 27)
        Me.RdnVentasPorFacturas.Margin = New System.Windows.Forms.Padding(4)
        Me.RdnVentasPorFacturas.Name = "RdnVentasPorFacturas"
        Me.RdnVentasPorFacturas.Size = New System.Drawing.Size(218, 21)
        Me.RdnVentasPorFacturas.TabIndex = 1
        Me.RdnVentasPorFacturas.TabStop = True
        Me.RdnVentasPorFacturas.Text = "Ventas agrupadas por factura"
        Me.RdnVentasPorFacturas.UseVisualStyleBackColor = True
        '
        'RdnVentasPorCultivo
        '
        Me.RdnVentasPorCultivo.AutoSize = True
        Me.RdnVentasPorCultivo.Location = New System.Drawing.Point(21, 53)
        Me.RdnVentasPorCultivo.Margin = New System.Windows.Forms.Padding(4)
        Me.RdnVentasPorCultivo.Name = "RdnVentasPorCultivo"
        Me.RdnVentasPorCultivo.Size = New System.Drawing.Size(207, 21)
        Me.RdnVentasPorCultivo.TabIndex = 0
        Me.RdnVentasPorCultivo.Text = "Ventas agrupado por cultivo"
        Me.RdnVentasPorCultivo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblVendedor)
        Me.GroupBox2.Controls.Add(Me.cboVendedor)
        Me.GroupBox2.Controls.Add(Me.chkSoloUtilidadNegativa)
        Me.GroupBox2.Controls.Add(Me.lblCultivoAgricola)
        Me.GroupBox2.Controls.Add(Me.CboCultivoAgricola)
        Me.GroupBox2.Controls.Add(Me.LblNombreProducto)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoProducto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.LblDisplayZona)
        Me.GroupBox2.Controls.Add(Me.CboZona)
        Me.GroupBox2.Controls.Add(Me.CboMercado)
        Me.GroupBox2.Controls.Add(Me.LblDisplayMercado)
        Me.GroupBox2.Controls.Add(Me.CboTipoDocumento)
        Me.GroupBox2.Controls.Add(Me.CboAlmacen)
        Me.GroupBox2.Controls.Add(Me.CboLinea)
        Me.GroupBox2.Controls.Add(Me.LblDisplayLinea)
        Me.GroupBox2.Controls.Add(Me.lblDocumentos)
        Me.GroupBox2.Controls.Add(Me.lblAlmacen)
        Me.GroupBox2.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox2.Controls.Add(Me.TxtCliente)
        Me.GroupBox2.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox2.Controls.Add(Me.CkbFechaReferencia)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Controls.Add(Me.LblFamilia)
        Me.GroupBox2.Controls.Add(Me.CboFamilia)
        Me.GroupBox2.Location = New System.Drawing.Point(291, 34)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(679, 421)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'chkSoloUtilidadNegativa
        '
        Me.chkSoloUtilidadNegativa.AutoSize = True
        Me.chkSoloUtilidadNegativa.Location = New System.Drawing.Point(136, 387)
        Me.chkSoloUtilidadNegativa.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSoloUtilidadNegativa.Name = "chkSoloUtilidadNegativa"
        Me.chkSoloUtilidadNegativa.Size = New System.Drawing.Size(238, 21)
        Me.chkSoloUtilidadNegativa.TabIndex = 399
        Me.chkSoloUtilidadNegativa.Text = "Solo ventas con utilidad negativa"
        Me.chkSoloUtilidadNegativa.UseVisualStyleBackColor = True
        '
        'lblCultivoAgricola
        '
        Me.lblCultivoAgricola.AutoSize = True
        Me.lblCultivoAgricola.Location = New System.Drawing.Point(15, 319)
        Me.lblCultivoAgricola.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCultivoAgricola.Name = "lblCultivoAgricola"
        Me.lblCultivoAgricola.Size = New System.Drawing.Size(108, 17)
        Me.lblCultivoAgricola.TabIndex = 398
        Me.lblCultivoAgricola.Text = "Cultivo agricola:"
        '
        'CboCultivoAgricola
        '
        Me.CboCultivoAgricola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCultivoAgricola.FormattingEnabled = True
        Me.CboCultivoAgricola.Items.AddRange(New Object() {"A", "B"})
        Me.CboCultivoAgricola.Location = New System.Drawing.Point(136, 316)
        Me.CboCultivoAgricola.Margin = New System.Windows.Forms.Padding(4)
        Me.CboCultivoAgricola.MaxLength = 1
        Me.CboCultivoAgricola.Name = "CboCultivoAgricola"
        Me.CboCultivoAgricola.Size = New System.Drawing.Size(408, 24)
        Me.CboCultivoAgricola.TabIndex = 9
        '
        'LblNombreProducto
        '
        Me.LblNombreProducto.Location = New System.Drawing.Point(240, 155)
        Me.LblNombreProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreProducto.Name = "LblNombreProducto"
        Me.LblNombreProducto.Size = New System.Drawing.Size(433, 21)
        Me.LblNombreProducto.TabIndex = 396
        Me.LblNombreProducto.Text = "_"
        '
        'TxtCodigoProducto
        '
        Me.TxtCodigoProducto.Location = New System.Drawing.Point(136, 153)
        Me.TxtCodigoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoProducto.MaxLength = 8
        Me.TxtCodigoProducto.Name = "TxtCodigoProducto"
        Me.TxtCodigoProducto.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodigoProducto.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 156)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 395
        Me.Label4.Text = "Producto :"
        '
        'LblDisplayZona
        '
        Me.LblDisplayZona.AutoSize = True
        Me.LblDisplayZona.Location = New System.Drawing.Point(15, 54)
        Me.LblDisplayZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayZona.Name = "LblDisplayZona"
        Me.LblDisplayZona.Size = New System.Drawing.Size(49, 17)
        Me.LblDisplayZona.TabIndex = 393
        Me.LblDisplayZona.Text = "Zona :"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Items.AddRange(New Object() {"A", "B"})
        Me.CboZona.Location = New System.Drawing.Point(136, 52)
        Me.CboZona.Margin = New System.Windows.Forms.Padding(4)
        Me.CboZona.MaxLength = 1
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(165, 24)
        Me.CboZona.TabIndex = 1
        '
        'CboMercado
        '
        Me.CboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMercado.FormattingEnabled = True
        Me.CboMercado.Location = New System.Drawing.Point(136, 219)
        Me.CboMercado.Margin = New System.Windows.Forms.Padding(4)
        Me.CboMercado.Name = "CboMercado"
        Me.CboMercado.Size = New System.Drawing.Size(408, 24)
        Me.CboMercado.TabIndex = 6
        '
        'LblDisplayMercado
        '
        Me.LblDisplayMercado.AutoSize = True
        Me.LblDisplayMercado.Location = New System.Drawing.Point(15, 222)
        Me.LblDisplayMercado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayMercado.Name = "LblDisplayMercado"
        Me.LblDisplayMercado.Size = New System.Drawing.Size(71, 17)
        Me.LblDisplayMercado.TabIndex = 391
        Me.LblDisplayMercado.Text = "Mercado :"
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Location = New System.Drawing.Point(136, 21)
        Me.CboTipoDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(287, 24)
        Me.CboTipoDocumento.TabIndex = 0
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(136, 185)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(408, 24)
        Me.CboAlmacen.TabIndex = 5
        '
        'CboLinea
        '
        Me.CboLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLinea.FormattingEnabled = True
        Me.CboLinea.Location = New System.Drawing.Point(136, 252)
        Me.CboLinea.Margin = New System.Windows.Forms.Padding(4)
        Me.CboLinea.Name = "CboLinea"
        Me.CboLinea.Size = New System.Drawing.Size(408, 24)
        Me.CboLinea.TabIndex = 7
        '
        'LblDisplayLinea
        '
        Me.LblDisplayLinea.AutoSize = True
        Me.LblDisplayLinea.Location = New System.Drawing.Point(15, 256)
        Me.LblDisplayLinea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayLinea.Name = "LblDisplayLinea"
        Me.LblDisplayLinea.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayLinea.TabIndex = 389
        Me.LblDisplayLinea.Text = "Línea :"
        '
        'lblDocumentos
        '
        Me.lblDocumentos.AutoSize = True
        Me.lblDocumentos.Location = New System.Drawing.Point(15, 25)
        Me.lblDocumentos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDocumentos.Name = "lblDocumentos"
        Me.lblDocumentos.Size = New System.Drawing.Size(88, 17)
        Me.lblDocumentos.TabIndex = 388
        Me.lblDocumentos.Text = "Documento :"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Location = New System.Drawing.Point(15, 188)
        Me.lblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.lblAlmacen.TabIndex = 387
        Me.lblAlmacen.Text = "Almacén :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(236, 87)
        Me.lblNombreCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(437, 21)
        Me.lblNombreCliente.TabIndex = 383
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(136, 85)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(95, 22)
        Me.TxtCliente.TabIndex = 2
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(15, 89)
        Me.lblDisplayCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(59, 17)
        Me.lblDisplayCliente.TabIndex = 382
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'CkbFechaReferencia
        '
        Me.CkbFechaReferencia.AutoSize = True
        Me.CkbFechaReferencia.Location = New System.Drawing.Point(136, 117)
        Me.CkbFechaReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.CkbFechaReferencia.Name = "CkbFechaReferencia"
        Me.CkbFechaReferencia.Size = New System.Drawing.Size(218, 21)
        Me.CkbFechaReferencia.TabIndex = 3
        Me.CkbFechaReferencia.Text = "Filtrar por fecha de referencia"
        Me.CkbFechaReferencia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(432, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 379
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(553, 53)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaHasta.TabIndex = 11
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(432, 27)
        Me.LblDisplayFechaNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(92, 17)
        Me.LblDisplayFechaNacimiento.TabIndex = 378
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(553, 22)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaDesde.TabIndex = 10
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblFamilia
        '
        Me.LblFamilia.AutoSize = True
        Me.LblFamilia.Location = New System.Drawing.Point(15, 286)
        Me.LblFamilia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFamilia.Name = "LblFamilia"
        Me.LblFamilia.Size = New System.Drawing.Size(60, 17)
        Me.LblFamilia.TabIndex = 375
        Me.LblFamilia.Text = "Familia :"
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"A", "B"})
        Me.CboFamilia.Location = New System.Drawing.Point(136, 283)
        Me.CboFamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFamilia.MaxLength = 1
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(408, 24)
        Me.CboFamilia.TabIndex = 8
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Items.AddRange(New Object() {"A", "B"})
        Me.cboVendedor.Location = New System.Drawing.Point(136, 348)
        Me.cboVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboVendedor.MaxLength = 1
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(408, 24)
        Me.cboVendedor.TabIndex = 400
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Location = New System.Drawing.Point(15, 351)
        Me.lblVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(78, 17)
        Me.lblVendedor.TabIndex = 401
        Me.lblVendedor.Text = "Vendedor :"
        '
        'Rpt_Ventas_ProductosVendidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 467)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Ventas_ProductosVendidos"
        Me.Text = "Ventas productos vendidos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdnVentasPorFacturas As System.Windows.Forms.RadioButton
    Friend WithEvents RdnVentasPorCultivo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents CboMercado As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayMercado As System.Windows.Forms.Label
    Friend WithEvents CboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents CboLinea As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayLinea As System.Windows.Forms.Label
    Friend WithEvents lblDocumentos As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents CkbFechaReferencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFamilia As System.Windows.Forms.Label
    Friend WithEvents CboFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents LblNombreProducto As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCultivoAgricola As System.Windows.Forms.Label
    Friend WithEvents CboCultivoAgricola As System.Windows.Forms.ComboBox
    Friend WithEvents RdnDevoluciones As System.Windows.Forms.RadioButton
    Friend WithEvents chkSoloUtilidadNegativa As System.Windows.Forms.CheckBox
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
End Class
