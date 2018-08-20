<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transformaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Transformaciones))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Grid1 = New FlexCell.Grid()
        Me.CboAlmacen1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDisplayDireccionEmpresa = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.TxtCostoTotal = New System.Windows.Forms.TextBox()
        Me.TxtCostoUnitario = New System.Windows.Forms.TextBox()
        Me.TxtExistencia = New System.Windows.Forms.TextBox()
        Me.TxtCodigoFormula = New System.Windows.Forms.TextBox()
        Me.LblDisplayFormula = New System.Windows.Forms.Label()
        Me.LblDisplayExistencia = New System.Windows.Forms.Label()
        Me.LblNombreProductoFinal = New System.Windows.Forms.Label()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.LblCosto = New System.Windows.Forms.Label()
        Me.LblCostoTotal = New System.Windows.Forms.Label()
        Me.TxtCuentaContable = New System.Windows.Forms.TextBox()
        Me.LblDisplayProductoFinal = New System.Windows.Forms.Label()
        Me.LblCodigoArticulo = New System.Windows.Forms.Label()
        Me.cboAlmacen2 = New System.Windows.Forms.ComboBox()
        Me.txtCostoMateriaPrima = New System.Windows.Forms.TextBox()
        Me.txtCostoProduccion = New System.Windows.Forms.TextBox()
        Me.txtPorcentajeCosto = New System.Windows.Forms.TextBox()
        Me.lblGastos = New System.Windows.Forms.Label()
        Me.lblCostoMateria = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCuentaContable = New System.Windows.Forms.Label()
        Me.lblNombreCuentaContable = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridSeries = New FlexCell.Grid()
        Me.btnDetallarSeries = New System.Windows.Forms.Button()
        Me.tsMenu.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1101, 27)
        Me.tsMenu.TabIndex = 223
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
        'Grid1
        '
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DefaultRowHeight = CType(24, Short)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.LockButton = True
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(1076, 314)
        Me.Grid1.TabIndex = 6
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'CboAlmacen1
        '
        Me.CboAlmacen1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen1.FormattingEnabled = True
        Me.CboAlmacen1.Location = New System.Drawing.Point(181, 37)
        Me.CboAlmacen1.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen1.Name = "CboAlmacen1"
        Me.CboAlmacen1.Size = New System.Drawing.Size(313, 24)
        Me.CboAlmacen1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 39)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 17)
        Me.Label3.TabIndex = 267
        Me.Label3.Text = "Almacén Materia prima :"
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(431, 190)
        Me.LblDisplayDireccionEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayDireccionEmpresa.TabIndex = 265
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(515, 186)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(575, 53)
        Me.TxtConcepto.TabIndex = 5
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(1199, 63)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(12, 17)
        Me.LblStatus.TabIndex = 260
        Me.LblStatus.Text = "."
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 730)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1101, 22)
        Me.StatusStripEstado.TabIndex = 257
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(301, 186)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantidad.TabIndex = 4
        '
        'TxtCostoTotal
        '
        Me.TxtCostoTotal.Location = New System.Drawing.Point(955, 663)
        Me.TxtCostoTotal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCostoTotal.Name = "TxtCostoTotal"
        Me.TxtCostoTotal.Size = New System.Drawing.Size(128, 22)
        Me.TxtCostoTotal.TabIndex = 384
        Me.TxtCostoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCostoUnitario
        '
        Me.TxtCostoUnitario.Location = New System.Drawing.Point(955, 699)
        Me.TxtCostoUnitario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCostoUnitario.Name = "TxtCostoUnitario"
        Me.TxtCostoUnitario.Size = New System.Drawing.Size(128, 22)
        Me.TxtCostoUnitario.TabIndex = 385
        Me.TxtCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExistencia
        '
        Me.TxtExistencia.Location = New System.Drawing.Point(99, 186)
        Me.TxtExistencia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtExistencia.Name = "TxtExistencia"
        Me.TxtExistencia.Size = New System.Drawing.Size(100, 22)
        Me.TxtExistencia.TabIndex = 386
        '
        'TxtCodigoFormula
        '
        Me.TxtCodigoFormula.Location = New System.Drawing.Point(91, 111)
        Me.TxtCodigoFormula.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCodigoFormula.Name = "TxtCodigoFormula"
        Me.TxtCodigoFormula.Size = New System.Drawing.Size(100, 22)
        Me.TxtCodigoFormula.TabIndex = 3
        '
        'LblDisplayFormula
        '
        Me.LblDisplayFormula.AutoSize = True
        Me.LblDisplayFormula.Location = New System.Drawing.Point(13, 114)
        Me.LblDisplayFormula.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFormula.Name = "LblDisplayFormula"
        Me.LblDisplayFormula.Size = New System.Drawing.Size(71, 17)
        Me.LblDisplayFormula.TabIndex = 388
        Me.LblDisplayFormula.Text = "Fórmula  :"
        '
        'LblDisplayExistencia
        '
        Me.LblDisplayExistencia.AutoSize = True
        Me.LblDisplayExistencia.Location = New System.Drawing.Point(13, 190)
        Me.LblDisplayExistencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayExistencia.Name = "LblDisplayExistencia"
        Me.LblDisplayExistencia.Size = New System.Drawing.Size(79, 17)
        Me.LblDisplayExistencia.TabIndex = 389
        Me.LblDisplayExistencia.Text = "Existencia :"
        '
        'LblNombreProductoFinal
        '
        Me.LblNombreProductoFinal.AutoSize = True
        Me.LblNombreProductoFinal.Location = New System.Drawing.Point(197, 114)
        Me.LblNombreProductoFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreProductoFinal.Name = "LblNombreProductoFinal"
        Me.LblNombreProductoFinal.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreProductoFinal.TabIndex = 390
        Me.LblNombreProductoFinal.Text = "_"
        '
        'LblCantidad
        '
        Me.LblCantidad.AutoSize = True
        Me.LblCantidad.Location = New System.Drawing.Point(221, 190)
        Me.LblCantidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(72, 17)
        Me.LblCantidad.TabIndex = 391
        Me.LblCantidad.Text = "Cantidad :"
        '
        'LblCosto
        '
        Me.LblCosto.AutoSize = True
        Me.LblCosto.Location = New System.Drawing.Point(846, 702)
        Me.LblCosto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCosto.Name = "LblCosto"
        Me.LblCosto.Size = New System.Drawing.Size(103, 17)
        Me.LblCosto.TabIndex = 392
        Me.LblCosto.Text = "Costo unitario :"
        '
        'LblCostoTotal
        '
        Me.LblCostoTotal.AutoSize = True
        Me.LblCostoTotal.Location = New System.Drawing.Point(866, 667)
        Me.LblCostoTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCostoTotal.Name = "LblCostoTotal"
        Me.LblCostoTotal.Size = New System.Drawing.Size(83, 17)
        Me.LblCostoTotal.TabIndex = 393
        Me.LblCostoTotal.Text = "Costo total :"
        '
        'TxtCuentaContable
        '
        Me.TxtCuentaContable.Location = New System.Drawing.Point(181, 71)
        Me.TxtCuentaContable.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCuentaContable.Name = "TxtCuentaContable"
        Me.TxtCuentaContable.Size = New System.Drawing.Size(163, 22)
        Me.TxtCuentaContable.TabIndex = 2
        '
        'LblDisplayProductoFinal
        '
        Me.LblDisplayProductoFinal.AutoSize = True
        Me.LblDisplayProductoFinal.Location = New System.Drawing.Point(13, 150)
        Me.LblDisplayProductoFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayProductoFinal.Name = "LblDisplayProductoFinal"
        Me.LblDisplayProductoFinal.Size = New System.Drawing.Size(103, 17)
        Me.LblDisplayProductoFinal.TabIndex = 398
        Me.LblDisplayProductoFinal.Text = "Producto final :"
        '
        'LblCodigoArticulo
        '
        Me.LblCodigoArticulo.AutoSize = True
        Me.LblCodigoArticulo.Location = New System.Drawing.Point(124, 150)
        Me.LblCodigoArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoArticulo.Name = "LblCodigoArticulo"
        Me.LblCodigoArticulo.Size = New System.Drawing.Size(16, 17)
        Me.LblCodigoArticulo.TabIndex = 399
        Me.LblCodigoArticulo.Text = "_"
        '
        'cboAlmacen2
        '
        Me.cboAlmacen2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen2.FormattingEnabled = True
        Me.cboAlmacen2.Location = New System.Drawing.Point(728, 37)
        Me.cboAlmacen2.Margin = New System.Windows.Forms.Padding(4)
        Me.cboAlmacen2.Name = "cboAlmacen2"
        Me.cboAlmacen2.Size = New System.Drawing.Size(313, 24)
        Me.cboAlmacen2.TabIndex = 1
        '
        'txtCostoMateriaPrima
        '
        Me.txtCostoMateriaPrima.Location = New System.Drawing.Point(955, 592)
        Me.txtCostoMateriaPrima.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCostoMateriaPrima.Name = "txtCostoMateriaPrima"
        Me.txtCostoMateriaPrima.Size = New System.Drawing.Size(128, 22)
        Me.txtCostoMateriaPrima.TabIndex = 401
        Me.txtCostoMateriaPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoProduccion
        '
        Me.txtCostoProduccion.Location = New System.Drawing.Point(955, 627)
        Me.txtCostoProduccion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCostoProduccion.Name = "txtCostoProduccion"
        Me.txtCostoProduccion.Size = New System.Drawing.Size(128, 22)
        Me.txtCostoProduccion.TabIndex = 402
        Me.txtCostoProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorcentajeCosto
        '
        Me.txtPorcentajeCosto.Location = New System.Drawing.Point(861, 627)
        Me.txtPorcentajeCosto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPorcentajeCosto.Name = "txtPorcentajeCosto"
        Me.txtPorcentajeCosto.Size = New System.Drawing.Size(61, 22)
        Me.txtPorcentajeCosto.TabIndex = 403
        '
        'lblGastos
        '
        Me.lblGastos.AutoSize = True
        Me.lblGastos.Location = New System.Drawing.Point(793, 631)
        Me.lblGastos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastos.Name = "lblGastos"
        Me.lblGastos.Size = New System.Drawing.Size(61, 17)
        Me.lblGastos.TabIndex = 404
        Me.lblGastos.Text = "Gastos :"
        '
        'lblCostoMateria
        '
        Me.lblCostoMateria.AutoSize = True
        Me.lblCostoMateria.Location = New System.Drawing.Point(807, 595)
        Me.lblCostoMateria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoMateria.Name = "lblCostoMateria"
        Me.lblCostoMateria.Size = New System.Drawing.Size(142, 17)
        Me.lblCostoMateria.TabIndex = 405
        Me.lblCostoMateria.Text = "Costo Materia prima :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(523, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 17)
        Me.Label1.TabIndex = 406
        Me.Label1.Text = "Almacén Producto terminado :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(930, 631)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 17)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "%"
        '
        'lblCuentaContable
        '
        Me.lblCuentaContable.AutoSize = True
        Me.lblCuentaContable.Location = New System.Drawing.Point(53, 74)
        Me.lblCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuentaContable.Name = "lblCuentaContable"
        Me.lblCuentaContable.Size = New System.Drawing.Size(119, 17)
        Me.lblCuentaContable.TabIndex = 408
        Me.lblCuentaContable.Text = "Cuenta contable :"
        '
        'lblNombreCuentaContable
        '
        Me.lblNombreCuentaContable.AutoSize = True
        Me.lblNombreCuentaContable.Location = New System.Drawing.Point(351, 74)
        Me.lblNombreCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreCuentaContable.Name = "lblNombreCuentaContable"
        Me.lblNombreCuentaContable.Size = New System.Drawing.Size(16, 17)
        Me.lblNombreCuentaContable.TabIndex = 409
        Me.lblNombreCuentaContable.Text = "_"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 246)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1084, 339)
        Me.TabControl1.TabIndex = 410
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1076, 310)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridSeries)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1076, 310)
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
        Me.GridSeries.Location = New System.Drawing.Point(0, 0)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 20
        Me.GridSeries.Size = New System.Drawing.Size(1076, 314)
        Me.GridSeries.TabIndex = 411
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnDetallarSeries
        '
        Me.btnDetallarSeries.Location = New System.Drawing.Point(99, 631)
        Me.btnDetallarSeries.Name = "btnDetallarSeries"
        Me.btnDetallarSeries.Size = New System.Drawing.Size(183, 42)
        Me.btnDetallarSeries.TabIndex = 411
        Me.btnDetallarSeries.Text = "Detallar series"
        Me.btnDetallarSeries.UseVisualStyleBackColor = True
        '
        'Transformaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 752)
        Me.Controls.Add(Me.btnDetallarSeries)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblNombreCuentaContable)
        Me.Controls.Add(Me.lblCuentaContable)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCostoMateria)
        Me.Controls.Add(Me.lblGastos)
        Me.Controls.Add(Me.txtPorcentajeCosto)
        Me.Controls.Add(Me.txtCostoProduccion)
        Me.Controls.Add(Me.txtCostoMateriaPrima)
        Me.Controls.Add(Me.cboAlmacen2)
        Me.Controls.Add(Me.LblDisplayProductoFinal)
        Me.Controls.Add(Me.TxtCuentaContable)
        Me.Controls.Add(Me.LblCostoTotal)
        Me.Controls.Add(Me.LblCosto)
        Me.Controls.Add(Me.LblCantidad)
        Me.Controls.Add(Me.LblNombreProductoFinal)
        Me.Controls.Add(Me.LblDisplayExistencia)
        Me.Controls.Add(Me.LblDisplayFormula)
        Me.Controls.Add(Me.TxtCodigoFormula)
        Me.Controls.Add(Me.TxtExistencia)
        Me.Controls.Add(Me.TxtCostoUnitario)
        Me.Controls.Add(Me.TxtCostoTotal)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.CboAlmacen1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblDisplayDireccionEmpresa)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.LblCodigoArticulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Transformaciones"
        Me.Text = "Transformaciones"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents CboAlmacen1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayDireccionEmpresa As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtCostoTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtCostoUnitario As System.Windows.Forms.TextBox
    Friend WithEvents TxtExistencia As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoFormula As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFormula As System.Windows.Forms.Label
    Friend WithEvents LblDisplayExistencia As System.Windows.Forms.Label
    Friend WithEvents LblNombreProductoFinal As System.Windows.Forms.Label
    Friend WithEvents LblCantidad As System.Windows.Forms.Label
    Friend WithEvents LblCosto As System.Windows.Forms.Label
    Friend WithEvents LblCostoTotal As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayProductoFinal As System.Windows.Forms.Label
    Friend WithEvents LblCodigoArticulo As System.Windows.Forms.Label
    Friend WithEvents cboAlmacen2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtCostoMateriaPrima As System.Windows.Forms.TextBox
    Friend WithEvents txtCostoProduccion As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentajeCosto As System.Windows.Forms.TextBox
    Friend WithEvents lblGastos As System.Windows.Forms.Label
    Friend WithEvents lblCostoMateria As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCuentaContable As System.Windows.Forms.Label
    Friend WithEvents lblNombreCuentaContable As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GridSeries As FlexCell.Grid
    Friend WithEvents btnDetallarSeries As System.Windows.Forms.Button
End Class
