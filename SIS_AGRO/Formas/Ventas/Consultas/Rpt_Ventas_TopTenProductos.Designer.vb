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
        Me.cboTipoPago = New System.Windows.Forms.ComboBox()
        Me.LblTipoPago = New System.Windows.Forms.Label()
        Me.GbFiltrarValor = New System.Windows.Forms.GroupBox()
        Me.RbtnCategoria = New System.Windows.Forms.RadioButton()
        Me.RbtnPorcentaje = New System.Windows.Forms.RadioButton()
        Me.TxtPorcentaje = New System.Windows.Forms.TextBox()
        Me.TxtCategoria = New System.Windows.Forms.TextBox()
        Me.cboOrden = New System.Windows.Forms.ComboBox()
        Me.LblOrden = New System.Windows.Forms.Label()
        Me.TxtCodigosProductos = New System.Windows.Forms.TextBox()
        Me.LblCodigosProductos = New System.Windows.Forms.Label()
        Me.TxtUtilidadMaxima = New System.Windows.Forms.TextBox()
        Me.LblUtilidadMaxima = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.TxtMin = New System.Windows.Forms.TextBox()
        Me.LblMin = New System.Windows.Forms.Label()
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
        Me.txtSum1 = New System.Windows.Forms.Label()
        Me.txtSum4 = New System.Windows.Forms.Label()
        Me.txtSum2 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalPesos = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        Me.GbFiltrarValor.SuspendLayout()
        Me.gbConsulta.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTipoPago)
        Me.GroupBox1.Controls.Add(Me.LblTipoPago)
        Me.GroupBox1.Controls.Add(Me.GbFiltrarValor)
        Me.GroupBox1.Controls.Add(Me.cboOrden)
        Me.GroupBox1.Controls.Add(Me.LblOrden)
        Me.GroupBox1.Controls.Add(Me.TxtCodigosProductos)
        Me.GroupBox1.Controls.Add(Me.LblCodigosProductos)
        Me.GroupBox1.Controls.Add(Me.TxtUtilidadMaxima)
        Me.GroupBox1.Controls.Add(Me.LblUtilidadMaxima)
        Me.GroupBox1.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox1.Controls.Add(Me.TxtMin)
        Me.GroupBox1.Controls.Add(Me.LblMin)
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 49)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1290, 128)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'cboTipoPago
        '
        Me.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago.FormattingEnabled = True
        Me.cboTipoPago.Location = New System.Drawing.Point(885, 32)
        Me.cboTipoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoPago.Name = "cboTipoPago"
        Me.cboTipoPago.Size = New System.Drawing.Size(117, 24)
        Me.cboTipoPago.TabIndex = 7
        '
        'LblTipoPago
        '
        Me.LblTipoPago.AutoSize = True
        Me.LblTipoPago.Location = New System.Drawing.Point(797, 35)
        Me.LblTipoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTipoPago.Name = "LblTipoPago"
        Me.LblTipoPago.Size = New System.Drawing.Size(80, 17)
        Me.LblTipoPago.TabIndex = 395
        Me.LblTipoPago.Text = "Tipo pago :"
        '
        'GbFiltrarValor
        '
        Me.GbFiltrarValor.Controls.Add(Me.RbtnCategoria)
        Me.GbFiltrarValor.Controls.Add(Me.RbtnPorcentaje)
        Me.GbFiltrarValor.Controls.Add(Me.TxtPorcentaje)
        Me.GbFiltrarValor.Controls.Add(Me.TxtCategoria)
        Me.GbFiltrarValor.Location = New System.Drawing.Point(439, 36)
        Me.GbFiltrarValor.Name = "GbFiltrarValor"
        Me.GbFiltrarValor.Size = New System.Drawing.Size(296, 48)
        Me.GbFiltrarValor.TabIndex = 4
        Me.GbFiltrarValor.TabStop = False
        Me.GbFiltrarValor.Text = "Filtrar por :"
        '
        'RbtnCategoria
        '
        Me.RbtnCategoria.AutoSize = True
        Me.RbtnCategoria.Location = New System.Drawing.Point(6, 21)
        Me.RbtnCategoria.Name = "RbtnCategoria"
        Me.RbtnCategoria.Size = New System.Drawing.Size(98, 21)
        Me.RbtnCategoria.TabIndex = 0
        Me.RbtnCategoria.TabStop = True
        Me.RbtnCategoria.Text = "Categoría :"
        Me.RbtnCategoria.UseVisualStyleBackColor = True
        '
        'RbtnPorcentaje
        '
        Me.RbtnPorcentaje.AutoSize = True
        Me.RbtnPorcentaje.Location = New System.Drawing.Point(193, 21)
        Me.RbtnPorcentaje.Name = "RbtnPorcentaje"
        Me.RbtnPorcentaje.Size = New System.Drawing.Size(41, 21)
        Me.RbtnPorcentaje.TabIndex = 2
        Me.RbtnPorcentaje.TabStop = True
        Me.RbtnPorcentaje.Text = "%"
        Me.RbtnPorcentaje.UseVisualStyleBackColor = True
        '
        'TxtPorcentaje
        '
        Me.TxtPorcentaje.Location = New System.Drawing.Point(241, 20)
        Me.TxtPorcentaje.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcentaje.MaxLength = 3
        Me.TxtPorcentaje.Name = "TxtPorcentaje"
        Me.TxtPorcentaje.Size = New System.Drawing.Size(35, 22)
        Me.TxtPorcentaje.TabIndex = 3
        '
        'TxtCategoria
        '
        Me.TxtCategoria.Location = New System.Drawing.Point(111, 20)
        Me.TxtCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCategoria.MaxLength = 8
        Me.TxtCategoria.Name = "TxtCategoria"
        Me.TxtCategoria.Size = New System.Drawing.Size(64, 22)
        Me.TxtCategoria.TabIndex = 1
        '
        'cboOrden
        '
        Me.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrden.FormattingEnabled = True
        Me.cboOrden.Location = New System.Drawing.Point(885, 96)
        Me.cboOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.cboOrden.Name = "cboOrden"
        Me.cboOrden.Size = New System.Drawing.Size(117, 24)
        Me.cboOrden.TabIndex = 9
        '
        'LblOrden
        '
        Me.LblOrden.AutoSize = True
        Me.LblOrden.Location = New System.Drawing.Point(779, 99)
        Me.LblOrden.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblOrden.Name = "LblOrden"
        Me.LblOrden.Size = New System.Drawing.Size(98, 17)
        Me.LblOrden.TabIndex = 390
        Me.LblOrden.Text = "Ordenar por  :"
        '
        'TxtCodigosProductos
        '
        Me.TxtCodigosProductos.Location = New System.Drawing.Point(97, 74)
        Me.TxtCodigosProductos.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigosProductos.MaxLength = 2000
        Me.TxtCodigosProductos.Name = "TxtCodigosProductos"
        Me.TxtCodigosProductos.Size = New System.Drawing.Size(146, 22)
        Me.TxtCodigosProductos.TabIndex = 2
        '
        'LblCodigosProductos
        '
        Me.LblCodigosProductos.AutoSize = True
        Me.LblCodigosProductos.Location = New System.Drawing.Point(9, 77)
        Me.LblCodigosProductos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigosProductos.Name = "LblCodigosProductos"
        Me.LblCodigosProductos.Size = New System.Drawing.Size(73, 17)
        Me.LblCodigosProductos.TabIndex = 388
        Me.LblCodigosProductos.Text = "Producto :"
        '
        'TxtUtilidadMaxima
        '
        Me.TxtUtilidadMaxima.Location = New System.Drawing.Point(680, 96)
        Me.TxtUtilidadMaxima.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtUtilidadMaxima.MaxLength = 3
        Me.TxtUtilidadMaxima.Name = "TxtUtilidadMaxima"
        Me.TxtUtilidadMaxima.Size = New System.Drawing.Size(64, 22)
        Me.TxtUtilidadMaxima.TabIndex = 6
        Me.TxtUtilidadMaxima.Text = "100"
        '
        'LblUtilidadMaxima
        '
        Me.LblUtilidadMaxima.AutoSize = True
        Me.LblUtilidadMaxima.Location = New System.Drawing.Point(576, 99)
        Me.LblUtilidadMaxima.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUtilidadMaxima.Name = "LblUtilidadMaxima"
        Me.LblUtilidadMaxima.Size = New System.Drawing.Size(96, 17)
        Me.LblUtilidadMaxima.TabIndex = 383
        Me.LblUtilidadMaxima.Text = "Utilidad max. :"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(97, 103)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDescripcion.MaxLength = 30
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(313, 22)
        Me.TxtDescripcion.TabIndex = 3
        '
        'TxtMin
        '
        Me.TxtMin.Location = New System.Drawing.Point(504, 96)
        Me.TxtMin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMin.MaxLength = 3
        Me.TxtMin.Name = "TxtMin"
        Me.TxtMin.Size = New System.Drawing.Size(64, 22)
        Me.TxtMin.TabIndex = 5
        '
        'LblMin
        '
        Me.LblMin.AutoSize = True
        Me.LblMin.Location = New System.Drawing.Point(437, 99)
        Me.LblMin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMin.Name = "LblMin"
        Me.LblMin.Size = New System.Drawing.Size(60, 17)
        Me.LblMin.TabIndex = 378
        Me.LblMin.Text = "Minimo :"
        '
        'LblDescripcion
        '
        Me.LblDescripcion.AutoSize = True
        Me.LblDescripcion.Location = New System.Drawing.Point(8, 106)
        Me.LblDescripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(90, 17)
        Me.LblDescripcion.TabIndex = 377
        Me.LblDescripcion.Text = "Descripcion :"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(885, 64)
        Me.CboDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(117, 24)
        Me.CboDocumento.TabIndex = 8
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(789, 67)
        Me.LblDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(88, 17)
        Me.LblDocumento.TabIndex = 373
        Me.LblDocumento.Text = "Documento :"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(97, 42)
        Me.CboZona.Margin = New System.Windows.Forms.Padding(4)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(146, 24)
        Me.CboZona.TabIndex = 1
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(9, 48)
        Me.lblDisplayZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(49, 17)
        Me.lblDisplayZona.TabIndex = 372
        Me.lblDisplayZona.Text = "Zona :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(195, 19)
        Me.lblNombreCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(536, 17)
        Me.lblNombreCliente.TabIndex = 359
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(97, 16)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(90, 22)
        Me.TxtCliente.TabIndex = 0
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(9, 19)
        Me.lblDisplayCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(59, 17)
        Me.lblDisplayCliente.TabIndex = 358
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'lblDisplayFechaHasta
        '
        Me.lblDisplayFechaHasta.AutoSize = True
        Me.lblDisplayFechaHasta.Location = New System.Drawing.Point(1024, 66)
        Me.lblDisplayFechaHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaHasta.Name = "lblDisplayFechaHasta"
        Me.lblDisplayFechaHasta.Size = New System.Drawing.Size(111, 17)
        Me.lblDisplayFechaHasta.TabIndex = 212
        Me.lblDisplayFechaHasta.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = "dd/MMM/yy"
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaHasta.Location = New System.Drawing.Point(1145, 61)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(136, 22)
        Me.DtFechaHasta.TabIndex = 11
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(1042, 35)
        Me.LblDisplayFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(92, 17)
        Me.LblDisplayFecha.TabIndex = 211
        Me.LblDisplayFecha.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = "dd/MMM/yy"
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaDesde.Location = New System.Drawing.Point(1145, 30)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(136, 22)
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
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(12, 23)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(1269, 395)
        Me.Grid.TabIndex = 223
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbConsulta
        '
        Me.gbConsulta.Controls.Add(Me.txtSum1)
        Me.gbConsulta.Controls.Add(Me.txtSum4)
        Me.gbConsulta.Controls.Add(Me.txtSum2)
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalPesos)
        Me.gbConsulta.Controls.Add(Me.Grid)
        Me.gbConsulta.Location = New System.Drawing.Point(16, 185)
        Me.gbConsulta.Margin = New System.Windows.Forms.Padding(4)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Padding = New System.Windows.Forms.Padding(4)
        Me.gbConsulta.Size = New System.Drawing.Size(1290, 489)
        Me.gbConsulta.TabIndex = 224
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta"
        '
        'txtSum1
        '
        Me.txtSum1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum1.Location = New System.Drawing.Point(560, 425)
        Me.txtSum1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtSum1.Name = "txtSum1"
        Me.txtSum1.Size = New System.Drawing.Size(133, 24)
        Me.txtSum1.TabIndex = 236
        Me.txtSum1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSum4
        '
        Me.txtSum4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum4.Location = New System.Drawing.Point(701, 425)
        Me.txtSum4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtSum4.Name = "txtSum4"
        Me.txtSum4.Size = New System.Drawing.Size(133, 24)
        Me.txtSum4.TabIndex = 235
        Me.txtSum4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSum2
        '
        Me.txtSum2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum2.Location = New System.Drawing.Point(842, 425)
        Me.txtSum2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtSum2.Name = "txtSum2"
        Me.txtSum2.Size = New System.Drawing.Size(123, 24)
        Me.txtSum2.TabIndex = 233
        Me.txtSum2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(376, 429)
        Me.lblDisplayTotalPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalPesos.Name = "lblDisplayTotalPesos"
        Me.lblDisplayTotalPesos.Size = New System.Drawing.Size(90, 17)
        Me.lblDisplayTotalPesos.TabIndex = 230
        Me.lblDisplayTotalPesos.Text = "Total pesos :"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1317, 27)
        Me.ToolStrip2.TabIndex = 225
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(95, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(90, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'Rpt_Ventas_TopTenProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 688)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Ventas_TopTenProductos"
        Me.Text = "TopTen de productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GbFiltrarValor.ResumeLayout(False)
        Me.GbFiltrarValor.PerformLayout()
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
    Friend WithEvents txtSum4 As System.Windows.Forms.Label
    Friend WithEvents txtSum2 As System.Windows.Forms.Label
    Friend WithEvents txtSum1 As System.Windows.Forms.Label
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents TxtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtMin As System.Windows.Forms.TextBox
    Friend WithEvents LblMin As System.Windows.Forms.Label
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents LblUtilidadMaxima As System.Windows.Forms.Label
    Friend WithEvents TxtUtilidadMaxima As System.Windows.Forms.TextBox
    Friend WithEvents TxtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigosProductos As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigosProductos As System.Windows.Forms.Label
    Friend WithEvents LblOrden As System.Windows.Forms.Label
    Friend WithEvents cboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents GbFiltrarValor As System.Windows.Forms.GroupBox
    Friend WithEvents RbtnCategoria As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents cboTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents LblTipoPago As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalPesos As System.Windows.Forms.Label
End Class
