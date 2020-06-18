<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventarios_sugeridos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventarios_sugeridos))
        Me.GridArticulos = New FlexCell.Grid()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.TxtCodigoAlmacen = New System.Windows.Forms.TextBox()
        Me.LblFiltro = New System.Windows.Forms.Label()
        Me.TxtFiltro = New System.Windows.Forms.TextBox()
        Me.LblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.LblNombreAlmacen = New System.Windows.Forms.Label()
        Me.GbArticulos = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.GbArticulos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridArticulos
        '
        Me.GridArticulos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridArticulos.CheckedImage = CType(resources.GetObject("GridArticulos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridArticulos.Cols = 1
        Me.GridArticulos.DefaultFont = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GridArticulos.DefaultRowHeight = CType(24, Short)
        Me.GridArticulos.DisplayRowArrow = True
        Me.GridArticulos.DisplayRowNumber = True
        Me.GridArticulos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridArticulos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridArticulos.Location = New System.Drawing.Point(5, 18)
        Me.GridArticulos.LockButton = True
        Me.GridArticulos.Name = "GridArticulos"
        Me.GridArticulos.Rows = 6
        Me.GridArticulos.Size = New System.Drawing.Size(1262, 433)
        Me.GridArticulos.TabIndex = 0
        Me.GridArticulos.UncheckedImage = CType(resources.GetObject("GridArticulos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1290, 27)
        Me.tsMenu.TabIndex = 224
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'TxtCodigoAlmacen
        '
        Me.TxtCodigoAlmacen.Location = New System.Drawing.Point(66, 38)
        Me.TxtCodigoAlmacen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCodigoAlmacen.Name = "TxtCodigoAlmacen"
        Me.TxtCodigoAlmacen.Size = New System.Drawing.Size(76, 20)
        Me.TxtCodigoAlmacen.TabIndex = 0
        '
        'LblFiltro
        '
        Me.LblFiltro.AutoSize = True
        Me.LblFiltro.Location = New System.Drawing.Point(9, 78)
        Me.LblFiltro.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblFiltro.Name = "LblFiltro"
        Me.LblFiltro.Size = New System.Drawing.Size(117, 13)
        Me.LblFiltro.TabIndex = 225
        Me.LblFiltro.Text = "Búsqueda por nombre :"
        '
        'TxtFiltro
        '
        Me.TxtFiltro.Location = New System.Drawing.Point(131, 76)
        Me.TxtFiltro.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtFiltro.Name = "TxtFiltro"
        Me.TxtFiltro.Size = New System.Drawing.Size(455, 20)
        Me.TxtFiltro.TabIndex = 1
        '
        'LblDisplayAlmacen
        '
        Me.LblDisplayAlmacen.AutoSize = True
        Me.LblDisplayAlmacen.Location = New System.Drawing.Point(9, 41)
        Me.LblDisplayAlmacen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDisplayAlmacen.Name = "LblDisplayAlmacen"
        Me.LblDisplayAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.LblDisplayAlmacen.TabIndex = 0
        Me.LblDisplayAlmacen.Text = "Almacén :"
        '
        'LblNombreAlmacen
        '
        Me.LblNombreAlmacen.AutoSize = True
        Me.LblNombreAlmacen.Location = New System.Drawing.Point(152, 41)
        Me.LblNombreAlmacen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblNombreAlmacen.Name = "LblNombreAlmacen"
        Me.LblNombreAlmacen.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreAlmacen.TabIndex = 227
        Me.LblNombreAlmacen.Text = "_"
        '
        'GbArticulos
        '
        Me.GbArticulos.Controls.Add(Me.GridArticulos)
        Me.GbArticulos.Location = New System.Drawing.Point(11, 109)
        Me.GbArticulos.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GbArticulos.Name = "GbArticulos"
        Me.GbArticulos.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GbArticulos.Size = New System.Drawing.Size(1272, 457)
        Me.GbArticulos.TabIndex = 2
        Me.GbArticulos.TabStop = False
        Me.GbArticulos.Text = "Artículos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(713, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 13)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "* Presione ENTER para grabar la cantidad"
        '
        'Inventarios_sugeridos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 575)
        Me.Controls.Add(Me.GbArticulos)
        Me.Controls.Add(Me.LblNombreAlmacen)
        Me.Controls.Add(Me.TxtFiltro)
        Me.Controls.Add(Me.LblFiltro)
        Me.Controls.Add(Me.TxtCodigoAlmacen)
        Me.Controls.Add(Me.LblDisplayAlmacen)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Inventarios_sugeridos"
        Me.ShowIcon = False
        Me.Text = "Inventarios sugeridos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GbArticulos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridArticulos As FlexCell.Grid
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCodigoAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents LblFiltro As System.Windows.Forms.Label
    Friend WithEvents TxtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayAlmacen As System.Windows.Forms.Label
    Friend WithEvents LblNombreAlmacen As System.Windows.Forms.Label
    Friend WithEvents GbArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
