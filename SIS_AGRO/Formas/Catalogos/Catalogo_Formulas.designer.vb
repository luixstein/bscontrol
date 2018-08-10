<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Catalogo_Formulas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Formulas))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.cMenuStripAccion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tStripMenuItemEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtCodigoFormula = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodFormula = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.TxtNombreFormula = New System.Windows.Forms.TextBox()
        Me.LblDisplayNombreFormula = New System.Windows.Forms.Label()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.txtCostoProduccion = New System.Windows.Forms.TextBox()
        Me.lblPorcentajeCostoProduccion = New System.Windows.Forms.Label()
        Me.LblDisplayIngredientes = New System.Windows.Forms.Label()
        Me.Grid1 = New FlexCell.Grid()
        Me.LblNombreProductoFinal = New System.Windows.Forms.Label()
        Me.LblDisplayCodProductoFinal = New System.Windows.Forms.Label()
        Me.TxtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.cMenuStripAccion.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1316, 27)
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
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(72, 24)
        Me.tsbEditar.Text = "&Editar"
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
        Me.tsbCancelar.Size = New System.Drawing.Size(90, 24)
        Me.tsbCancelar.Text = "&Cancelar"
        '
        'tsbImprimirListado
        '
        Me.tsbImprimirListado.Image = CType(resources.GetObject("tsbImprimirListado.Image"), System.Drawing.Image)
        Me.tsbImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirListado.Name = "tsbImprimirListado"
        Me.tsbImprimirListado.Size = New System.Drawing.Size(139, 24)
        Me.tsbImprimirListado.Text = "&Imprimir listado"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(61, 20)
        Me.tssLabel.Text = "Estado :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 537)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1316, 25)
        Me.StatusStripEstado.TabIndex = 5
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 20)
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(401, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'cMenuStripAccion
        '
        Me.cMenuStripAccion.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cMenuStripAccion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tStripMenuItemEditar})
        Me.cMenuStripAccion.Name = "ContextMenuStrip1"
        Me.cMenuStripAccion.Size = New System.Drawing.Size(122, 30)
        '
        'tStripMenuItemEditar
        '
        Me.tStripMenuItemEditar.Image = CType(resources.GetObject("tStripMenuItemEditar.Image"), System.Drawing.Image)
        Me.tStripMenuItemEditar.Name = "tStripMenuItemEditar"
        Me.tStripMenuItemEditar.Size = New System.Drawing.Size(121, 26)
        Me.tStripMenuItemEditar.Text = "&Editar"
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(765, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(535, 498)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(413, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "Estatus :"
        '
        'cboEstatusFiltro
        '
        Me.cboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatusFiltro.FormattingEnabled = True
        Me.cboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(485, 18)
        Me.cboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(40, 24)
        Me.cboEstatusFiltro.TabIndex = 216
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 50)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(517, 441)
        Me.Grid.TabIndex = 113
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtCodigoFormula
        '
        Me.TxtCodigoFormula.Location = New System.Drawing.Point(143, 18)
        Me.TxtCodigoFormula.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoFormula.MaxLength = 4
        Me.TxtCodigoFormula.Name = "TxtCodigoFormula"
        Me.TxtCodigoFormula.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoFormula.TabIndex = 0
        '
        'LblDisplayCodFormula
        '
        Me.LblDisplayCodFormula.AutoSize = True
        Me.LblDisplayCodFormula.Location = New System.Drawing.Point(8, 22)
        Me.LblDisplayCodFormula.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodFormula.Name = "LblDisplayCodFormula"
        Me.LblDisplayCodFormula.Size = New System.Drawing.Size(111, 17)
        Me.LblDisplayCodFormula.TabIndex = 8
        Me.LblDisplayCodFormula.Text = "Código fórmula :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(143, 90)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(104, 24)
        Me.CboEstatus.TabIndex = 7
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(8, 94)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'TxtNombreFormula
        '
        Me.TxtNombreFormula.Location = New System.Drawing.Point(143, 50)
        Me.TxtNombreFormula.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombreFormula.MaxLength = 50
        Me.TxtNombreFormula.Name = "TxtNombreFormula"
        Me.TxtNombreFormula.Size = New System.Drawing.Size(439, 22)
        Me.TxtNombreFormula.TabIndex = 1
        '
        'LblDisplayNombreFormula
        '
        Me.LblDisplayNombreFormula.AutoSize = True
        Me.LblDisplayNombreFormula.Location = New System.Drawing.Point(8, 54)
        Me.LblDisplayNombreFormula.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreFormula.Name = "LblDisplayNombreFormula"
        Me.LblDisplayNombreFormula.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombreFormula.TabIndex = 74
        Me.LblDisplayNombreFormula.Text = "Nombre :"
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.txtCostoProduccion)
        Me.gBoxInformacion.Controls.Add(Me.lblPorcentajeCostoProduccion)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayIngredientes)
        Me.gBoxInformacion.Controls.Add(Me.Grid1)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreProductoFinal)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodProductoFinal)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoArticulo)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreFormula)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreFormula)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodFormula)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoFormula)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(741, 498)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'txtCostoProduccion
        '
        Me.txtCostoProduccion.Location = New System.Drawing.Point(444, 90)
        Me.txtCostoProduccion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCostoProduccion.MaxLength = 50
        Me.txtCostoProduccion.Name = "txtCostoProduccion"
        Me.txtCostoProduccion.Size = New System.Drawing.Size(104, 22)
        Me.txtCostoProduccion.TabIndex = 2
        '
        'lblPorcentajeCostoProduccion
        '
        Me.lblPorcentajeCostoProduccion.AutoSize = True
        Me.lblPorcentajeCostoProduccion.Location = New System.Drawing.Point(276, 94)
        Me.lblPorcentajeCostoProduccion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPorcentajeCostoProduccion.Name = "lblPorcentajeCostoProduccion"
        Me.lblPorcentajeCostoProduccion.Size = New System.Drawing.Size(160, 17)
        Me.lblPorcentajeCostoProduccion.TabIndex = 98
        Me.lblPorcentajeCostoProduccion.Text = "% costo de producción :"
        '
        'LblDisplayIngredientes
        '
        Me.LblDisplayIngredientes.AutoSize = True
        Me.LblDisplayIngredientes.Location = New System.Drawing.Point(8, 186)
        Me.LblDisplayIngredientes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayIngredientes.Name = "LblDisplayIngredientes"
        Me.LblDisplayIngredientes.Size = New System.Drawing.Size(94, 17)
        Me.LblDisplayIngredientes.TabIndex = 97
        Me.LblDisplayIngredientes.Text = "Ingredientes :"
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
        Me.Grid1.Location = New System.Drawing.Point(11, 207)
        Me.Grid1.LockButton = True
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 6
        Me.Grid1.Size = New System.Drawing.Size(723, 283)
        Me.Grid1.TabIndex = 4
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'LblNombreProductoFinal
        '
        Me.LblNombreProductoFinal.AutoSize = True
        Me.LblNombreProductoFinal.Location = New System.Drawing.Point(140, 158)
        Me.LblNombreProductoFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreProductoFinal.Name = "LblNombreProductoFinal"
        Me.LblNombreProductoFinal.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreProductoFinal.TabIndex = 95
        Me.LblNombreProductoFinal.Text = "_"
        '
        'LblDisplayCodProductoFinal
        '
        Me.LblDisplayCodProductoFinal.AutoSize = True
        Me.LblDisplayCodProductoFinal.Location = New System.Drawing.Point(8, 134)
        Me.LblDisplayCodProductoFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodProductoFinal.Name = "LblDisplayCodProductoFinal"
        Me.LblDisplayCodProductoFinal.Size = New System.Drawing.Size(103, 17)
        Me.LblDisplayCodProductoFinal.TabIndex = 94
        Me.LblDisplayCodProductoFinal.Text = "Producto final :"
        '
        'TxtCodigoArticulo
        '
        Me.TxtCodigoArticulo.Location = New System.Drawing.Point(143, 130)
        Me.TxtCodigoArticulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoArticulo.MaxLength = 50
        Me.TxtCodigoArticulo.Name = "TxtCodigoArticulo"
        Me.TxtCodigoArticulo.Size = New System.Drawing.Size(104, 22)
        Me.TxtCodigoArticulo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(161, -140)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(241, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'Catalogo_Formulas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 562)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Formulas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de fórmulas."
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.cMenuStripAccion.ResumeLayout(False)
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents cMenuStripAccion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tStripMenuItemEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreFormula As System.Windows.Forms.Label
    Friend WithEvents TxtNombreFormula As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodFormula As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoFormula As System.Windows.Forms.TextBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents LblNombreProductoFinal As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodProductoFinal As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents LblDisplayIngredientes As System.Windows.Forms.Label
    Friend WithEvents txtCostoProduccion As System.Windows.Forms.TextBox
    Friend WithEvents lblPorcentajeCostoProduccion As System.Windows.Forms.Label
End Class
