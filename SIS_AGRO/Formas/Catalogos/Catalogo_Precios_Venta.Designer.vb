<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Precios_Venta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Precios_Venta))
        Me.Grid = New FlexCell.Grid()
        Me.cboFamilia = New System.Windows.Forms.ComboBox()
        Me.lblDisplayFamilia = New System.Windows.Forms.Label()
        Me.cboLinea = New System.Windows.Forms.ComboBox()
        Me.lblDisplayLinea = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblDisplayArticulo = New System.Windows.Forms.Label()
        Me.txtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.AllowUserReorderColumn = True
        Me.Grid.AllowUserSort = True
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(12, 133)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 1
        Me.Grid.Size = New System.Drawing.Size(943, 379)
        Me.Grid.TabIndex = 3
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'cboFamilia
        '
        Me.cboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFamilia.FormattingEnabled = True
        Me.cboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboFamilia.Location = New System.Drawing.Point(98, 91)
        Me.cboFamilia.Name = "cboFamilia"
        Me.cboFamilia.Size = New System.Drawing.Size(212, 21)
        Me.cboFamilia.TabIndex = 2
        '
        'lblDisplayFamilia
        '
        Me.lblDisplayFamilia.AutoSize = True
        Me.lblDisplayFamilia.Location = New System.Drawing.Point(11, 94)
        Me.lblDisplayFamilia.Name = "lblDisplayFamilia"
        Me.lblDisplayFamilia.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayFamilia.TabIndex = 355
        Me.lblDisplayFamilia.Text = "Familia :"
        '
        'cboLinea
        '
        Me.cboLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinea.FormattingEnabled = True
        Me.cboLinea.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboLinea.Location = New System.Drawing.Point(98, 63)
        Me.cboLinea.Name = "cboLinea"
        Me.cboLinea.Size = New System.Drawing.Size(212, 21)
        Me.cboLinea.TabIndex = 1
        '
        'lblDisplayLinea
        '
        Me.lblDisplayLinea.AutoSize = True
        Me.lblDisplayLinea.Location = New System.Drawing.Point(11, 66)
        Me.lblDisplayLinea.Name = "lblDisplayLinea"
        Me.lblDisplayLinea.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayLinea.TabIndex = 354
        Me.lblDisplayLinea.Text = "Linea :"
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbImprimir, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(967, 25)
        Me.tsMenu.TabIndex = 4
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'lblDisplayArticulo
        '
        Me.lblDisplayArticulo.AutoSize = True
        Me.lblDisplayArticulo.Location = New System.Drawing.Point(11, 41)
        Me.lblDisplayArticulo.Name = "lblDisplayArticulo"
        Me.lblDisplayArticulo.Size = New System.Drawing.Size(50, 13)
        Me.lblDisplayArticulo.TabIndex = 358
        Me.lblDisplayArticulo.Text = "Artículo :"
        '
        'txtCodigoArticulo
        '
        Me.txtCodigoArticulo.Location = New System.Drawing.Point(98, 37)
        Me.txtCodigoArticulo.MaxLength = 16
        Me.txtCodigoArticulo.Name = "txtCodigoArticulo"
        Me.txtCodigoArticulo.Size = New System.Drawing.Size(159, 20)
        Me.txtCodigoArticulo.TabIndex = 0
        '
        'lblArticulo
        '
        Me.lblArticulo.AutoSize = True
        Me.lblArticulo.Location = New System.Drawing.Point(263, 40)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(13, 13)
        Me.lblArticulo.TabIndex = 359
        Me.lblArticulo.Text = "_"
        '
        'Catalogo_Precios_Venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 524)
        Me.Controls.Add(Me.lblArticulo)
        Me.Controls.Add(Me.lblDisplayArticulo)
        Me.Controls.Add(Me.txtCodigoArticulo)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.cboFamilia)
        Me.Controls.Add(Me.lblDisplayFamilia)
        Me.Controls.Add(Me.cboLinea)
        Me.Controls.Add(Me.lblDisplayLinea)
        Me.Controls.Add(Me.Grid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Precios_Venta"
        Me.Text = "Catálogo de precios de venta"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents cboFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayFamilia As System.Windows.Forms.Label
    Friend WithEvents cboLinea As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayLinea As System.Windows.Forms.Label
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDisplayArticulo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
End Class
