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
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDisplayDireccionEmpresa = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.TxtCostoTotal = New System.Windows.Forms.TextBox()
        Me.TxtCosto = New System.Windows.Forms.TextBox()
        Me.TxtExistencia = New System.Windows.Forms.TextBox()
        Me.TxtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.LblDisplayProductoFinal = New System.Windows.Forms.Label()
        Me.LblDisplayExistencia = New System.Windows.Forms.Label()
        Me.LblNombreProductoFinal = New System.Windows.Forms.Label()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.LblCosto = New System.Windows.Forms.Label()
        Me.LblCostoTotal = New System.Windows.Forms.Label()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.TxtCuentaContable = New System.Windows.Forms.TextBox()
        Me.LblDisplayCuentaContable = New System.Windows.Forms.Label()
        Me.LblNombreCuentaContable = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1102, 27)
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
        Me.Grid1.Location = New System.Drawing.Point(13, 249)
        Me.Grid1.LockButton = True
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(1076, 316)
        Me.Grid1.TabIndex = 4
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(141, 37)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(313, 24)
        Me.CboAlmacen.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 41)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 267
        Me.Label3.Text = "Almacén :"
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(28, 191)
        Me.LblDisplayDireccionEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayDireccionEmpresa.TabIndex = 265
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(141, 188)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(777, 53)
        Me.TxtConcepto.TabIndex = 3
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 587)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1102, 22)
        Me.StatusStripEstado.TabIndex = 257
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(141, 141)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(100, 22)
        Me.TxtCantidad.TabIndex = 2
        '
        'TxtCostoTotal
        '
        Me.TxtCostoTotal.Location = New System.Drawing.Point(555, 141)
        Me.TxtCostoTotal.Name = "TxtCostoTotal"
        Me.TxtCostoTotal.Size = New System.Drawing.Size(100, 22)
        Me.TxtCostoTotal.TabIndex = 384
        '
        'TxtCosto
        '
        Me.TxtCosto.Location = New System.Drawing.Point(354, 141)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.Size = New System.Drawing.Size(100, 22)
        Me.TxtCosto.TabIndex = 385
        '
        'TxtExistencia
        '
        Me.TxtExistencia.Location = New System.Drawing.Point(354, 77)
        Me.TxtExistencia.Name = "TxtExistencia"
        Me.TxtExistencia.Size = New System.Drawing.Size(100, 22)
        Me.TxtExistencia.TabIndex = 386
        '
        'TxtCodigoArticulo
        '
        Me.TxtCodigoArticulo.Location = New System.Drawing.Point(141, 77)
        Me.TxtCodigoArticulo.Name = "TxtCodigoArticulo"
        Me.TxtCodigoArticulo.Size = New System.Drawing.Size(100, 22)
        Me.TxtCodigoArticulo.TabIndex = 1
        '
        'LblDisplayProductoFinal
        '
        Me.LblDisplayProductoFinal.AutoSize = True
        Me.LblDisplayProductoFinal.Location = New System.Drawing.Point(28, 80)
        Me.LblDisplayProductoFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayProductoFinal.Name = "LblDisplayProductoFinal"
        Me.LblDisplayProductoFinal.Size = New System.Drawing.Size(103, 17)
        Me.LblDisplayProductoFinal.TabIndex = 388
        Me.LblDisplayProductoFinal.Text = "Producto final :"
        '
        'LblDisplayExistencia
        '
        Me.LblDisplayExistencia.AutoSize = True
        Me.LblDisplayExistencia.Location = New System.Drawing.Point(268, 80)
        Me.LblDisplayExistencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayExistencia.Name = "LblDisplayExistencia"
        Me.LblDisplayExistencia.Size = New System.Drawing.Size(79, 17)
        Me.LblDisplayExistencia.TabIndex = 389
        Me.LblDisplayExistencia.Text = "Existencia :"
        '
        'LblNombreProductoFinal
        '
        Me.LblNombreProductoFinal.AutoSize = True
        Me.LblNombreProductoFinal.Location = New System.Drawing.Point(138, 107)
        Me.LblNombreProductoFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreProductoFinal.Name = "LblNombreProductoFinal"
        Me.LblNombreProductoFinal.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreProductoFinal.TabIndex = 390
        Me.LblNombreProductoFinal.Text = "_"
        '
        'LblCantidad
        '
        Me.LblCantidad.AutoSize = True
        Me.LblCantidad.Location = New System.Drawing.Point(28, 144)
        Me.LblCantidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(72, 17)
        Me.LblCantidad.TabIndex = 391
        Me.LblCantidad.Text = "Cantidad :"
        '
        'LblCosto
        '
        Me.LblCosto.AutoSize = True
        Me.LblCosto.Location = New System.Drawing.Point(268, 144)
        Me.LblCosto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCosto.Name = "LblCosto"
        Me.LblCosto.Size = New System.Drawing.Size(52, 17)
        Me.LblCosto.TabIndex = 392
        Me.LblCosto.Text = "Costo :"
        '
        'LblCostoTotal
        '
        Me.LblCostoTotal.AutoSize = True
        Me.LblCostoTotal.Location = New System.Drawing.Point(486, 144)
        Me.LblCostoTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCostoTotal.Name = "LblCostoTotal"
        Me.LblCostoTotal.Size = New System.Drawing.Size(48, 17)
        Me.LblCostoTotal.TabIndex = 393
        Me.LblCostoTotal.Text = "Total :"
        '
        'TxtTotal
        '
        Me.TxtTotal.Location = New System.Drawing.Point(743, 141)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(175, 22)
        Me.TxtTotal.TabIndex = 394
        '
        'TxtCuentaContable
        '
        Me.TxtCuentaContable.Location = New System.Drawing.Point(612, 77)
        Me.TxtCuentaContable.Name = "TxtCuentaContable"
        Me.TxtCuentaContable.Size = New System.Drawing.Size(306, 22)
        Me.TxtCuentaContable.TabIndex = 395
        '
        'LblDisplayCuentaContable
        '
        Me.LblDisplayCuentaContable.AutoSize = True
        Me.LblDisplayCuentaContable.Location = New System.Drawing.Point(486, 80)
        Me.LblDisplayCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCuentaContable.Name = "LblDisplayCuentaContable"
        Me.LblDisplayCuentaContable.Size = New System.Drawing.Size(119, 17)
        Me.LblDisplayCuentaContable.TabIndex = 396
        Me.LblDisplayCuentaContable.Text = "Cuenta contable :"
        '
        'LblNombreCuentaContable
        '
        Me.LblNombreCuentaContable.AutoSize = True
        Me.LblNombreCuentaContable.Location = New System.Drawing.Point(609, 107)
        Me.LblNombreCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreCuentaContable.Name = "LblNombreCuentaContable"
        Me.LblNombreCuentaContable.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreCuentaContable.TabIndex = 397
        Me.LblNombreCuentaContable.Text = "_"
        '
        'Transformaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 609)
        Me.Controls.Add(Me.LblNombreCuentaContable)
        Me.Controls.Add(Me.LblDisplayCuentaContable)
        Me.Controls.Add(Me.TxtCuentaContable)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.LblCostoTotal)
        Me.Controls.Add(Me.LblCosto)
        Me.Controls.Add(Me.LblCantidad)
        Me.Controls.Add(Me.LblNombreProductoFinal)
        Me.Controls.Add(Me.LblDisplayExistencia)
        Me.Controls.Add(Me.LblDisplayProductoFinal)
        Me.Controls.Add(Me.TxtCodigoArticulo)
        Me.Controls.Add(Me.TxtExistencia)
        Me.Controls.Add(Me.TxtCosto)
        Me.Controls.Add(Me.TxtCostoTotal)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.CboAlmacen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblDisplayDireccionEmpresa)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayDireccionEmpresa As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtCostoTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtCosto As System.Windows.Forms.TextBox
    Friend WithEvents TxtExistencia As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayProductoFinal As System.Windows.Forms.Label
    Friend WithEvents LblDisplayExistencia As System.Windows.Forms.Label
    Friend WithEvents LblNombreProductoFinal As System.Windows.Forms.Label
    Friend WithEvents LblCantidad As System.Windows.Forms.Label
    Friend WithEvents LblCosto As System.Windows.Forms.Label
    Friend WithEvents LblCostoTotal As System.Windows.Forms.Label
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCuentaContable As System.Windows.Forms.Label
    Friend WithEvents LblNombreCuentaContable As System.Windows.Forms.Label
End Class
