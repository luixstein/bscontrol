<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Ventas_TopTenProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Ventas_TopTenProductos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.cboTipoPago = New System.Windows.Forms.ComboBox()
        Me.chkFiltrarPorUtilidad = New System.Windows.Forms.CheckBox()
        Me.LblTipoPago = New System.Windows.Forms.Label()
        Me.gFiltrarUtilidad = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbMaximo = New System.Windows.Forms.RadioButton()
        Me.rbMinimo = New System.Windows.Forms.RadioButton()
        Me.txtPorcentajeUtilidad = New System.Windows.Forms.TextBox()
        Me.cboOrden = New System.Windows.Forms.ComboBox()
        Me.LblOrden = New System.Windows.Forms.Label()
        Me.TxtCodigosProductos = New System.Windows.Forms.TextBox()
        Me.LblCodigosProductos = New System.Windows.Forms.Label()
        Me.txtUtilidadMaxima = New System.Windows.Forms.TextBox()
        Me.lblDisplayUtilidadMaxima = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.CboZona = New System.Windows.Forms.ComboBox()
        Me.lblDisplayZona = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.lblDisplayFechaHasta = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFecha = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Grid = New FlexCell.Grid()
        Me.gbConsulta = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTotalUtilidad = New System.Windows.Forms.Label()
        Me.txtTotalUtilidad = New System.Windows.Forms.Label()
        Me.lblDisplayTotalCosto = New System.Windows.Forms.Label()
        Me.lblDisplayTotalVenta = New System.Windows.Forms.Label()
        Me.lblDisplayTotalCantidad = New System.Windows.Forms.Label()
        Me.txtTotalCantidad = New System.Windows.Forms.Label()
        Me.txtTotalVenta = New System.Windows.Forms.Label()
        Me.txtTotalCosto = New System.Windows.Forms.Label()
        Me.lblDisplayTotalPesos = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        Me.gFiltrarUtilidad.SuspendLayout()
        Me.gbConsulta.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTipoCambio)
        Me.GroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox1.Controls.Add(Me.cboTipoPago)
        Me.GroupBox1.Controls.Add(Me.chkFiltrarPorUtilidad)
        Me.GroupBox1.Controls.Add(Me.LblTipoPago)
        Me.GroupBox1.Controls.Add(Me.gFiltrarUtilidad)
        Me.GroupBox1.Controls.Add(Me.cboOrden)
        Me.GroupBox1.Controls.Add(Me.LblOrden)
        Me.GroupBox1.Controls.Add(Me.TxtCodigosProductos)
        Me.GroupBox1.Controls.Add(Me.LblCodigosProductos)
        Me.GroupBox1.Controls.Add(Me.txtUtilidadMaxima)
        Me.GroupBox1.Controls.Add(Me.lblDisplayUtilidadMaxima)
        Me.GroupBox1.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox1.Controls.Add(Me.LblDescripcion)
        Me.GroupBox1.Controls.Add(Me.CboDocumento)
        Me.GroupBox1.Controls.Add(Me.LblDocumento)
        Me.GroupBox1.Controls.Add(Me.CboZona)
        Me.GroupBox1.Controls.Add(Me.lblDisplayZona)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFechaHasta)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFecha)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(968, 113)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Location = New System.Drawing.Point(767, 80)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(86, 13)
        Me.lblTipoCambio.TabIndex = 397
        Me.lblTipoCambio.Text = "Tipo de cambio :"
        Me.lblTipoCambio.Visible = False
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(859, 78)
        Me.txtTipoCambio.MaxLength = 7
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(49, 20)
        Me.txtTipoCambio.TabIndex = 396
        Me.txtTipoCambio.Text = "00.0000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipoCambio.Visible = False
        '
        'cboTipoPago
        '
        Me.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago.FormattingEnabled = True
        Me.cboTipoPago.Location = New System.Drawing.Point(664, 26)
        Me.cboTipoPago.Name = "cboTipoPago"
        Me.cboTipoPago.Size = New System.Drawing.Size(89, 21)
        Me.cboTipoPago.TabIndex = 7
        '
        'chkFiltrarPorUtilidad
        '
        Me.chkFiltrarPorUtilidad.AutoSize = True
        Me.chkFiltrarPorUtilidad.Location = New System.Drawing.Point(444, 13)
        Me.chkFiltrarPorUtilidad.Name = "chkFiltrarPorUtilidad"
        Me.chkFiltrarPorUtilidad.Size = New System.Drawing.Size(125, 17)
        Me.chkFiltrarPorUtilidad.TabIndex = 398
        Me.chkFiltrarPorUtilidad.Text = "Filtrar por % utilidad ?"
        Me.chkFiltrarPorUtilidad.UseVisualStyleBackColor = True
        '
        'LblTipoPago
        '
        Me.LblTipoPago.AutoSize = True
        Me.LblTipoPago.Location = New System.Drawing.Point(595, 28)
        Me.LblTipoPago.Name = "LblTipoPago"
        Me.LblTipoPago.Size = New System.Drawing.Size(61, 13)
        Me.LblTipoPago.TabIndex = 395
        Me.LblTipoPago.Text = "Tipo pago :"
        '
        'gFiltrarUtilidad
        '
        Me.gFiltrarUtilidad.Controls.Add(Me.Label1)
        Me.gFiltrarUtilidad.Controls.Add(Me.rbMaximo)
        Me.gFiltrarUtilidad.Controls.Add(Me.rbMinimo)
        Me.gFiltrarUtilidad.Controls.Add(Me.txtPorcentajeUtilidad)
        Me.gFiltrarUtilidad.Enabled = False
        Me.gFiltrarUtilidad.Location = New System.Drawing.Point(438, 12)
        Me.gFiltrarUtilidad.Margin = New System.Windows.Forms.Padding(2)
        Me.gFiltrarUtilidad.Name = "gFiltrarUtilidad"
        Me.gFiltrarUtilidad.Padding = New System.Windows.Forms.Padding(2)
        Me.gFiltrarUtilidad.Size = New System.Drawing.Size(137, 64)
        Me.gFiltrarUtilidad.TabIndex = 4
        Me.gFiltrarUtilidad.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "%"
        '
        'rbMaximo
        '
        Me.rbMaximo.AutoSize = True
        Me.rbMaximo.Location = New System.Drawing.Point(25, 42)
        Me.rbMaximo.Name = "rbMaximo"
        Me.rbMaximo.Size = New System.Drawing.Size(61, 17)
        Me.rbMaximo.TabIndex = 400
        Me.rbMaximo.Text = "Máximo"
        Me.rbMaximo.UseVisualStyleBackColor = True
        '
        'rbMinimo
        '
        Me.rbMinimo.AutoSize = True
        Me.rbMinimo.Checked = True
        Me.rbMinimo.Location = New System.Drawing.Point(25, 22)
        Me.rbMinimo.Name = "rbMinimo"
        Me.rbMinimo.Size = New System.Drawing.Size(60, 17)
        Me.rbMinimo.TabIndex = 399
        Me.rbMinimo.TabStop = True
        Me.rbMinimo.Text = "Mínimo"
        Me.rbMinimo.UseVisualStyleBackColor = True
        '
        'txtPorcentajeUtilidad
        '
        Me.txtPorcentajeUtilidad.Location = New System.Drawing.Point(87, 28)
        Me.txtPorcentajeUtilidad.MaxLength = 3
        Me.txtPorcentajeUtilidad.Name = "txtPorcentajeUtilidad"
        Me.txtPorcentajeUtilidad.Size = New System.Drawing.Size(27, 20)
        Me.txtPorcentajeUtilidad.TabIndex = 3
        '
        'cboOrden
        '
        Me.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrden.FormattingEnabled = True
        Me.cboOrden.Location = New System.Drawing.Point(664, 78)
        Me.cboOrden.Name = "cboOrden"
        Me.cboOrden.Size = New System.Drawing.Size(89, 21)
        Me.cboOrden.TabIndex = 9
        '
        'LblOrden
        '
        Me.LblOrden.AutoSize = True
        Me.LblOrden.Location = New System.Drawing.Point(584, 80)
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Size = New System.Drawing.Size(72, 13)
        Me.LblOrden.TabIndex = 390
        Me.LblOrden.Text = "Ordenar por  :"
        '
        'TxtCodigosProductos
        '
        Me.TxtCodigosProductos.Location = New System.Drawing.Point(73, 60)
        Me.TxtCodigosProductos.MaxLength = 2000
        Me.TxtCodigosProductos.Name = "TxtCodigosProductos"
        Me.TxtCodigosProductos.Size = New System.Drawing.Size(110, 20)
        Me.TxtCodigosProductos.TabIndex = 2
        '
        'LblCodigosProductos
        '
        Me.LblCodigosProductos.AutoSize = True
        Me.LblCodigosProductos.Location = New System.Drawing.Point(6, 63)
        Me.LblCodigosProductos.Name = "LblCodigosProductos"
        Me.LblCodigosProductos.Size = New System.Drawing.Size(56, 13)
        Me.LblCodigosProductos.TabIndex = 388
        Me.LblCodigosProductos.Text = "Producto :"
        '
        'txtUtilidadMaxima
        '
        Me.txtUtilidadMaxima.Location = New System.Drawing.Point(525, 84)
        Me.txtUtilidadMaxima.MaxLength = 3
        Me.txtUtilidadMaxima.Name = "txtUtilidadMaxima"
        Me.txtUtilidadMaxima.Size = New System.Drawing.Size(49, 20)
        Me.txtUtilidadMaxima.TabIndex = 6
        Me.txtUtilidadMaxima.Text = "101"
        Me.txtUtilidadMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayUtilidadMaxima
        '
        Me.lblDisplayUtilidadMaxima.AutoSize = True
        Me.lblDisplayUtilidadMaxima.Location = New System.Drawing.Point(447, 86)
        Me.lblDisplayUtilidadMaxima.Name = "lblDisplayUtilidadMaxima"
        Me.lblDisplayUtilidadMaxima.Size = New System.Drawing.Size(70, 13)
        Me.lblDisplayUtilidadMaxima.TabIndex = 383
        Me.lblDisplayUtilidadMaxima.Text = "Utilidad máx :"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(73, 84)
        Me.TxtDescripcion.MaxLength = 30
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(236, 20)
        Me.TxtDescripcion.TabIndex = 3
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Location = New System.Drawing.Point(6, 86)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(69, 13)
        Me.LblDescripcion.TabIndex = 377
        Me.LblDescripcion.Text = "Descripcion :"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(664, 52)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(89, 21)
        Me.CboDocumento.TabIndex = 8
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(588, 54)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 373
        Me.LblDocumento.Text = "Documento :"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(73, 34)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(110, 21)
        Me.CboZona.TabIndex = 1
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(6, 39)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 372
        Me.lblDisplayZona.Text = "Zona :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(146, 15)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(402, 14)
        Me.lblNombreCliente.TabIndex = 359
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(73, 13)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(68, 20)
        Me.TxtCliente.TabIndex = 0
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(6, 15)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 358
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'lblDisplayFechaHasta
        '
        Me.lblDisplayFechaHasta.AutoSize = True
        Me.lblDisplayFechaHasta.Location = New System.Drawing.Point(768, 54)
        Me.lblDisplayFechaHasta.Name = "lblDisplayFechaHasta"
        Me.lblDisplayFechaHasta.Size = New System.Drawing.Size(85, 13)
        Me.lblDisplayFechaHasta.TabIndex = 212
        Me.lblDisplayFechaHasta.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = "dd/MMM/yy"
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaHasta.Location = New System.Drawing.Point(859, 50)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(103, 20)
        Me.DtFechaHasta.TabIndex = 11
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(782, 28)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFecha.TabIndex = 211
        Me.LblDisplayFecha.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = "dd/MMM/yy"
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaDesde.Location = New System.Drawing.Point(859, 24)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(103, 20)
        Me.DtFechaDesde.TabIndex = 10
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Grid
        '
        Me.Grid.AllowUserResizing = FlexCell.ResizeEnum.Rows
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DefaultRowHeight = CType(24, Short)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(9, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(1245, 436)
        Me.Grid.TabIndex = 223
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbConsulta
        '
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalUtilidad)
        Me.gbConsulta.Controls.Add(Me.txtTotalUtilidad)
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalCosto)
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalVenta)
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalCantidad)
        Me.gbConsulta.Controls.Add(Me.txtTotalCantidad)
        Me.gbConsulta.Controls.Add(Me.txtTotalVenta)
        Me.gbConsulta.Controls.Add(Me.txtTotalCosto)
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalPesos)
        Me.gbConsulta.Controls.Add(Me.Grid)
        Me.gbConsulta.Location = New System.Drawing.Point(12, 150)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(1257, 516)
        Me.gbConsulta.TabIndex = 224
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta"
        '
        'lblDisplayTotalUtilidad
        '
        Me.lblDisplayTotalUtilidad.AutoSize = True
        Me.lblDisplayTotalUtilidad.Location = New System.Drawing.Point(782, 483)
        Me.lblDisplayTotalUtilidad.Name = "lblDisplayTotalUtilidad"
        Me.lblDisplayTotalUtilidad.Size = New System.Drawing.Size(42, 13)
        Me.lblDisplayTotalUtilidad.TabIndex = 241
        Me.lblDisplayTotalUtilidad.Text = "Utilidad"
        Me.lblDisplayTotalUtilidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalUtilidad
        '
        Me.txtTotalUtilidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotalUtilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalUtilidad.Location = New System.Drawing.Point(731, 462)
        Me.txtTotalUtilidad.Name = "txtTotalUtilidad"
        Me.txtTotalUtilidad.Size = New System.Drawing.Size(93, 20)
        Me.txtTotalUtilidad.TabIndex = 240
        Me.txtTotalUtilidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalCosto
        '
        Me.lblDisplayTotalCosto.AutoSize = True
        Me.lblDisplayTotalCosto.Location = New System.Drawing.Point(691, 483)
        Me.lblDisplayTotalCosto.Name = "lblDisplayTotalCosto"
        Me.lblDisplayTotalCosto.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayTotalCosto.TabIndex = 239
        Me.lblDisplayTotalCosto.Text = "Costo"
        Me.lblDisplayTotalCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalVenta
        '
        Me.lblDisplayTotalVenta.AutoSize = True
        Me.lblDisplayTotalVenta.Location = New System.Drawing.Point(591, 483)
        Me.lblDisplayTotalVenta.Name = "lblDisplayTotalVenta"
        Me.lblDisplayTotalVenta.Size = New System.Drawing.Size(35, 13)
        Me.lblDisplayTotalVenta.TabIndex = 238
        Me.lblDisplayTotalVenta.Text = "Venta"
        '
        'lblDisplayTotalCantidad
        '
        Me.lblDisplayTotalCantidad.AutoSize = True
        Me.lblDisplayTotalCantidad.Location = New System.Drawing.Point(471, 482)
        Me.lblDisplayTotalCantidad.Name = "lblDisplayTotalCantidad"
        Me.lblDisplayTotalCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblDisplayTotalCantidad.TabIndex = 237
        Me.lblDisplayTotalCantidad.Text = "Cantidad"
        '
        'txtTotalCantidad
        '
        Me.txtTotalCantidad.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotalCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCantidad.Location = New System.Drawing.Point(420, 462)
        Me.txtTotalCantidad.Name = "txtTotalCantidad"
        Me.txtTotalCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCantidad.TabIndex = 236
        Me.txtTotalCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalVenta
        '
        Me.txtTotalVenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotalVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalVenta.Location = New System.Drawing.Point(526, 462)
        Me.txtTotalVenta.Name = "txtTotalVenta"
        Me.txtTotalVenta.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalVenta.TabIndex = 235
        Me.txtTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalCosto
        '
        Me.txtTotalCosto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotalCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalCosto.Location = New System.Drawing.Point(632, 462)
        Me.txtTotalCosto.Name = "txtTotalCosto"
        Me.txtTotalCosto.Size = New System.Drawing.Size(93, 20)
        Me.txtTotalCosto.TabIndex = 233
        Me.txtTotalCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(282, 466)
        Me.lblDisplayTotalPesos.Name = "lblDisplayTotalPesos"
        Me.lblDisplayTotalPesos.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTotalPesos.TabIndex = 230
        Me.lblDisplayTotalPesos.Text = "Totales :"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1274, 27)
        Me.ToolStrip2.TabIndex = 225
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(82, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(77, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'Rpt_Ventas_TopTenProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1274, 678)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Ventas_TopTenProductos"
        Me.Text = "TopTen de productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gFiltrarUtilidad.ResumeLayout(False)
        Me.gFiltrarUtilidad.PerformLayout()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaHasta As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents txtTotalVenta As System.Windows.Forms.Label
    Friend WithEvents txtTotalCosto As System.Windows.Forms.Label
    Friend WithEvents txtTotalCantidad As System.Windows.Forms.Label
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeUtilidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblDisplayUtilidadMaxima As System.Windows.Forms.Label
    Friend WithEvents txtUtilidadMaxima As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigosProductos As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigosProductos As System.Windows.Forms.Label
    Friend WithEvents LblOrden As System.Windows.Forms.Label
    Friend WithEvents cboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents gFiltrarUtilidad As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents LblTipoPago As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalPesos As System.Windows.Forms.Label
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rbMaximo As RadioButton
    Friend WithEvents rbMinimo As RadioButton
    Friend WithEvents chkFiltrarPorUtilidad As CheckBox
    Friend WithEvents lblDisplayTotalCosto As Label
    Friend WithEvents lblDisplayTotalVenta As Label
    Friend WithEvents lblDisplayTotalCantidad As Label
    Friend WithEvents lblDisplayTotalUtilidad As Label
    Friend WithEvents txtTotalUtilidad As Label
End Class
