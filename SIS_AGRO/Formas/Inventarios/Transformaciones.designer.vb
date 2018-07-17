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
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(826, 27)
        Me.tsMenu.TabIndex = 223
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
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
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(10, 203)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(807, 254)
        Me.Grid1.TabIndex = 6
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'CboAlmacen1
        '
        Me.CboAlmacen1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen1.FormattingEnabled = True
        Me.CboAlmacen1.Location = New System.Drawing.Point(136, 30)
        Me.CboAlmacen1.Name = "CboAlmacen1"
        Me.CboAlmacen1.Size = New System.Drawing.Size(236, 21)
        Me.CboAlmacen1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 267
        Me.Label3.Text = "Almacén Materia prima :"
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(323, 154)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayDireccionEmpresa.TabIndex = 265
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(386, 151)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(432, 44)
        Me.TxtConcepto.TabIndex = 5
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(899, 51)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(10, 13)
        Me.LblStatus.TabIndex = 260
        Me.LblStatus.Text = "."
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 579)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(826, 22)
        Me.StatusStripEstado.TabIndex = 257
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(226, 151)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(76, 20)
        Me.TxtCantidad.TabIndex = 4
        '
        'TxtCostoTotal
        '
        Me.TxtCostoTotal.Location = New System.Drawing.Point(712, 520)
        Me.TxtCostoTotal.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCostoTotal.Name = "TxtCostoTotal"
        Me.TxtCostoTotal.Size = New System.Drawing.Size(97, 20)
        Me.TxtCostoTotal.TabIndex = 384
        Me.TxtCostoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCostoUnitario
        '
        Me.TxtCostoUnitario.Location = New System.Drawing.Point(712, 549)
        Me.TxtCostoUnitario.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCostoUnitario.Name = "TxtCostoUnitario"
        Me.TxtCostoUnitario.Size = New System.Drawing.Size(97, 20)
        Me.TxtCostoUnitario.TabIndex = 385
        Me.TxtCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExistencia
        '
        Me.TxtExistencia.Location = New System.Drawing.Point(74, 151)
        Me.TxtExistencia.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtExistencia.Name = "TxtExistencia"
        Me.TxtExistencia.Size = New System.Drawing.Size(76, 20)
        Me.TxtExistencia.TabIndex = 386
        '
        'TxtCodigoFormula
        '
        Me.TxtCodigoFormula.Location = New System.Drawing.Point(68, 90)
        Me.TxtCodigoFormula.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCodigoFormula.Name = "TxtCodigoFormula"
        Me.TxtCodigoFormula.Size = New System.Drawing.Size(76, 20)
        Me.TxtCodigoFormula.TabIndex = 3
        '
        'LblDisplayFormula
        '
        Me.LblDisplayFormula.AutoSize = True
        Me.LblDisplayFormula.Location = New System.Drawing.Point(10, 93)
        Me.LblDisplayFormula.Name = "LblDisplayFormula"
        Me.LblDisplayFormula.Size = New System.Drawing.Size(53, 13)
        Me.LblDisplayFormula.TabIndex = 388
        Me.LblDisplayFormula.Text = "Fórmula  :"
        '
        'LblDisplayExistencia
        '
        Me.LblDisplayExistencia.AutoSize = True
        Me.LblDisplayExistencia.Location = New System.Drawing.Point(10, 154)
        Me.LblDisplayExistencia.Name = "LblDisplayExistencia"
        Me.LblDisplayExistencia.Size = New System.Drawing.Size(61, 13)
        Me.LblDisplayExistencia.TabIndex = 389
        Me.LblDisplayExistencia.Text = "Existencia :"
        '
        'LblNombreProductoFinal
        '
        Me.LblNombreProductoFinal.AutoSize = True
        Me.LblNombreProductoFinal.Location = New System.Drawing.Point(148, 93)
        Me.LblNombreProductoFinal.Name = "LblNombreProductoFinal"
        Me.LblNombreProductoFinal.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreProductoFinal.TabIndex = 390
        Me.LblNombreProductoFinal.Text = "_"
        '
        'LblCantidad
        '
        Me.LblCantidad.AutoSize = True
        Me.LblCantidad.Location = New System.Drawing.Point(166, 154)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(55, 13)
        Me.LblCantidad.TabIndex = 391
        Me.LblCantidad.Text = "Cantidad :"
        '
        'LblCosto
        '
        Me.LblCosto.AutoSize = True
        Me.LblCosto.Location = New System.Drawing.Point(630, 552)
        Me.LblCosto.Name = "LblCosto"
        Me.LblCosto.Size = New System.Drawing.Size(77, 13)
        Me.LblCosto.TabIndex = 392
        Me.LblCosto.Text = "Costo unitario :"
        '
        'LblCostoTotal
        '
        Me.LblCostoTotal.AutoSize = True
        Me.LblCostoTotal.Location = New System.Drawing.Point(645, 523)
        Me.LblCostoTotal.Name = "LblCostoTotal"
        Me.LblCostoTotal.Size = New System.Drawing.Size(63, 13)
        Me.LblCostoTotal.TabIndex = 393
        Me.LblCostoTotal.Text = "Costo total :"
        '
        'TxtCuentaContable
        '
        Me.TxtCuentaContable.Location = New System.Drawing.Point(136, 58)
        Me.TxtCuentaContable.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCuentaContable.Name = "TxtCuentaContable"
        Me.TxtCuentaContable.Size = New System.Drawing.Size(123, 20)
        Me.TxtCuentaContable.TabIndex = 2
        '
        'LblDisplayProductoFinal
        '
        Me.LblDisplayProductoFinal.AutoSize = True
        Me.LblDisplayProductoFinal.Location = New System.Drawing.Point(10, 122)
        Me.LblDisplayProductoFinal.Name = "LblDisplayProductoFinal"
        Me.LblDisplayProductoFinal.Size = New System.Drawing.Size(78, 13)
        Me.LblDisplayProductoFinal.TabIndex = 398
        Me.LblDisplayProductoFinal.Text = "Producto final :"
        '
        'LblCodigoArticulo
        '
        Me.LblCodigoArticulo.AutoSize = True
        Me.LblCodigoArticulo.Location = New System.Drawing.Point(93, 122)
        Me.LblCodigoArticulo.Name = "LblCodigoArticulo"
        Me.LblCodigoArticulo.Size = New System.Drawing.Size(13, 13)
        Me.LblCodigoArticulo.TabIndex = 399
        Me.LblCodigoArticulo.Text = "_"
        '
        'cboAlmacen2
        '
        Me.cboAlmacen2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen2.FormattingEnabled = True
        Me.cboAlmacen2.Location = New System.Drawing.Point(546, 30)
        Me.cboAlmacen2.Name = "cboAlmacen2"
        Me.cboAlmacen2.Size = New System.Drawing.Size(236, 21)
        Me.cboAlmacen2.TabIndex = 1
        '
        'txtCostoMateriaPrima
        '
        Me.txtCostoMateriaPrima.Location = New System.Drawing.Point(712, 462)
        Me.txtCostoMateriaPrima.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCostoMateriaPrima.Name = "txtCostoMateriaPrima"
        Me.txtCostoMateriaPrima.Size = New System.Drawing.Size(97, 20)
        Me.txtCostoMateriaPrima.TabIndex = 401
        Me.txtCostoMateriaPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCostoProduccion
        '
        Me.txtCostoProduccion.Location = New System.Drawing.Point(712, 491)
        Me.txtCostoProduccion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCostoProduccion.Name = "txtCostoProduccion"
        Me.txtCostoProduccion.Size = New System.Drawing.Size(97, 20)
        Me.txtCostoProduccion.TabIndex = 402
        Me.txtCostoProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorcentajeCosto
        '
        Me.txtPorcentajeCosto.Location = New System.Drawing.Point(641, 491)
        Me.txtPorcentajeCosto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtPorcentajeCosto.Name = "txtPorcentajeCosto"
        Me.txtPorcentajeCosto.Size = New System.Drawing.Size(47, 20)
        Me.txtPorcentajeCosto.TabIndex = 403
        '
        'lblGastos
        '
        Me.lblGastos.AutoSize = True
        Me.lblGastos.Location = New System.Drawing.Point(590, 494)
        Me.lblGastos.Name = "lblGastos"
        Me.lblGastos.Size = New System.Drawing.Size(46, 13)
        Me.lblGastos.TabIndex = 404
        Me.lblGastos.Text = "Gastos :"
        '
        'lblCostoMateria
        '
        Me.lblCostoMateria.AutoSize = True
        Me.lblCostoMateria.Location = New System.Drawing.Point(601, 465)
        Me.lblCostoMateria.Name = "lblCostoMateria"
        Me.lblCostoMateria.Size = New System.Drawing.Size(106, 13)
        Me.lblCostoMateria.TabIndex = 405
        Me.lblCostoMateria.Text = "Costo Materia prima :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(392, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 406
        Me.Label1.Text = "Almacén Producto terminado :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(693, 494)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "%"
        '
        'lblCuentaContable
        '
        Me.lblCuentaContable.AutoSize = True
        Me.lblCuentaContable.Location = New System.Drawing.Point(40, 60)
        Me.lblCuentaContable.Name = "lblCuentaContable"
        Me.lblCuentaContable.Size = New System.Drawing.Size(91, 13)
        Me.lblCuentaContable.TabIndex = 408
        Me.lblCuentaContable.Text = "Cuenta contable :"
        '
        'lblNombreCuentaContable
        '
        Me.lblNombreCuentaContable.AutoSize = True
        Me.lblNombreCuentaContable.Location = New System.Drawing.Point(263, 60)
        Me.lblNombreCuentaContable.Name = "lblNombreCuentaContable"
        Me.lblNombreCuentaContable.Size = New System.Drawing.Size(13, 13)
        Me.lblNombreCuentaContable.TabIndex = 409
        Me.lblNombreCuentaContable.Text = "_"
        '
        'Transformaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 601)
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
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.CboAlmacen1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblDisplayDireccionEmpresa)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.LblCodigoArticulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Transformaciones"
        Me.Text = "Transformaciones"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
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
End Class
