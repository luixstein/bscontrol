<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Articulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Articulos))
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.LblNombreUnidad = New System.Windows.Forms.Label()
        Me.chkEsSerializable = New System.Windows.Forms.CheckBox()
        Me.chkImpuesto = New System.Windows.Forms.CheckBox()
        Me.chkInventariable = New System.Windows.Forms.CheckBox()
        Me.CboFamilia = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblDisplayCodigoPostalParticular = New System.Windows.Forms.Label()
        Me.TxtPrecio = New System.Windows.Forms.TextBox()
        Me.cboLinea = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCod_Linea = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.TxtCodArticulo = New System.Windows.Forms.TextBox()
        Me.LblDisplayUnidadVenta = New System.Windows.Forms.Label()
        Me.TxtUnidadVenta = New System.Windows.Forms.TextBox()
        Me.LblDisplayDescripcion = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.rbtCodigoArticulo = New System.Windows.Forms.RadioButton()
        Me.rbtDescripcion = New System.Windows.Forms.RadioButton()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreUnidad)
        Me.gBoxInformacion.Controls.Add(Me.chkEsSerializable)
        Me.gBoxInformacion.Controls.Add(Me.chkImpuesto)
        Me.gBoxInformacion.Controls.Add(Me.chkInventariable)
        Me.gBoxInformacion.Controls.Add(Me.CboFamilia)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodigoPostalParticular)
        Me.gBoxInformacion.Controls.Add(Me.TxtPrecio)
        Me.gBoxInformacion.Controls.Add(Me.cboLinea)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCod_Linea)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodArticulo)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodArticulo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayUnidadVenta)
        Me.gBoxInformacion.Controls.Add(Me.TxtUnidadVenta)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayDescripcion)
        Me.gBoxInformacion.Controls.Add(Me.TxtDescripcion)
        Me.gBoxInformacion.Location = New System.Drawing.Point(11, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(529, 516)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información de los artículos"
        '
        'LblNombreUnidad
        '
        Me.LblNombreUnidad.AutoSize = True
        Me.LblNombreUnidad.Location = New System.Drawing.Point(228, 237)
        Me.LblNombreUnidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreUnidad.Name = "LblNombreUnidad"
        Me.LblNombreUnidad.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreUnidad.TabIndex = 139
        Me.LblNombreUnidad.Text = "_"
        '
        'chkEsSerializable
        '
        Me.chkEsSerializable.AutoSize = True
        Me.chkEsSerializable.Location = New System.Drawing.Point(296, 268)
        Me.chkEsSerializable.Margin = New System.Windows.Forms.Padding(4)
        Me.chkEsSerializable.Name = "chkEsSerializable"
        Me.chkEsSerializable.Size = New System.Drawing.Size(173, 21)
        Me.chkEsSerializable.TabIndex = 4
        Me.chkEsSerializable.Text = "Lleva control de series"
        Me.chkEsSerializable.UseVisualStyleBackColor = True
        '
        'chkImpuesto
        '
        Me.chkImpuesto.AutoSize = True
        Me.chkImpuesto.Location = New System.Drawing.Point(129, 297)
        Me.chkImpuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.chkImpuesto.Name = "chkImpuesto"
        Me.chkImpuesto.Size = New System.Drawing.Size(87, 21)
        Me.chkImpuesto.TabIndex = 5
        Me.chkImpuesto.Text = "Impuesto"
        Me.chkImpuesto.UseVisualStyleBackColor = True
        '
        'chkInventariable
        '
        Me.chkInventariable.AutoSize = True
        Me.chkInventariable.Location = New System.Drawing.Point(129, 268)
        Me.chkInventariable.Margin = New System.Windows.Forms.Padding(4)
        Me.chkInventariable.Name = "chkInventariable"
        Me.chkInventariable.Size = New System.Drawing.Size(111, 21)
        Me.chkInventariable.TabIndex = 3
        Me.chkInventariable.Text = "Inventariable"
        Me.chkInventariable.UseVisualStyleBackColor = True
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.CboFamilia.Location = New System.Drawing.Point(129, 364)
        Me.CboFamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(281, 24)
        Me.CboFamilia.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 368)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Familia :"
        '
        'LblDisplayCodigoPostalParticular
        '
        Me.LblDisplayCodigoPostalParticular.AutoSize = True
        Me.LblDisplayCodigoPostalParticular.Location = New System.Drawing.Point(13, 401)
        Me.LblDisplayCodigoPostalParticular.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodigoPostalParticular.Name = "LblDisplayCodigoPostalParticular"
        Me.LblDisplayCodigoPostalParticular.Size = New System.Drawing.Size(56, 17)
        Me.LblDisplayCodigoPostalParticular.TabIndex = 136
        Me.LblDisplayCodigoPostalParticular.Text = "Precio :"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Location = New System.Drawing.Point(129, 398)
        Me.TxtPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecio.MaxLength = 0
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(95, 22)
        Me.TxtPrecio.TabIndex = 8
        Me.TxtPrecio.Text = "0"
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboLinea
        '
        Me.cboLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinea.FormattingEnabled = True
        Me.cboLinea.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboLinea.Location = New System.Drawing.Point(129, 330)
        Me.cboLinea.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLinea.Name = "cboLinea"
        Me.cboLinea.Size = New System.Drawing.Size(281, 24)
        Me.cboLinea.TabIndex = 6
        '
        'lblDisplayCod_Linea
        '
        Me.lblDisplayCod_Linea.AutoSize = True
        Me.lblDisplayCod_Linea.Location = New System.Drawing.Point(13, 334)
        Me.lblDisplayCod_Linea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCod_Linea.Name = "lblDisplayCod_Linea"
        Me.lblDisplayCod_Linea.Size = New System.Drawing.Size(51, 17)
        Me.lblDisplayCod_Linea.TabIndex = 134
        Me.lblDisplayCod_Linea.Text = "Linea :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(13, 433)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 129
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(129, 430)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(95, 24)
        Me.CboEstatus.TabIndex = 9
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(13, 32)
        Me.LblDisplayCodArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(95, 17)
        Me.LblDisplayCodArticulo.TabIndex = 127
        Me.LblDisplayCodArticulo.Text = "Cod. artículo :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Location = New System.Drawing.Point(129, 27)
        Me.TxtCodArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodArticulo.TabIndex = 0
        '
        'LblDisplayUnidadVenta
        '
        Me.LblDisplayUnidadVenta.AutoSize = True
        Me.LblDisplayUnidadVenta.Location = New System.Drawing.Point(13, 238)
        Me.LblDisplayUnidadVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayUnidadVenta.Name = "LblDisplayUnidadVenta"
        Me.LblDisplayUnidadVenta.Size = New System.Drawing.Size(100, 17)
        Me.LblDisplayUnidadVenta.TabIndex = 123
        Me.LblDisplayUnidadVenta.Text = "Unidad venta :"
        '
        'TxtUnidadVenta
        '
        Me.TxtUnidadVenta.Location = New System.Drawing.Point(129, 234)
        Me.TxtUnidadVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtUnidadVenta.MaxLength = 20
        Me.TxtUnidadVenta.Name = "TxtUnidadVenta"
        Me.TxtUnidadVenta.Size = New System.Drawing.Size(91, 22)
        Me.TxtUnidadVenta.TabIndex = 2
        '
        'LblDisplayDescripcion
        '
        Me.LblDisplayDescripcion.AutoSize = True
        Me.LblDisplayDescripcion.Location = New System.Drawing.Point(13, 63)
        Me.LblDisplayDescripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDescripcion.Name = "LblDisplayDescripcion"
        Me.LblDisplayDescripcion.Size = New System.Drawing.Size(90, 17)
        Me.LblDisplayDescripcion.TabIndex = 122
        Me.LblDisplayDescripcion.Text = "Descripción :"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(129, 59)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDescripcion.MaxLength = 500
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(391, 170)
        Me.TxtDescripcion.TabIndex = 1
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label2)
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rbtCodigoArticulo)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rbtDescripcion)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(548, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(567, 516)
        Me.gBoxBusquedaRapida.TabIndex = 121
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(429, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Estatus :"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(500, 54)
        Me.CboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatusFiltro.MaxLength = 1
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(56, 24)
        Me.CboEstatusFiltro.TabIndex = 139
        '
        'rbtCodigoArticulo
        '
        Me.rbtCodigoArticulo.AutoSize = True
        Me.rbtCodigoArticulo.Location = New System.Drawing.Point(188, 27)
        Me.rbtCodigoArticulo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbtCodigoArticulo.Name = "rbtCodigoArticulo"
        Me.rbtCodigoArticulo.Size = New System.Drawing.Size(123, 21)
        Me.rbtCodigoArticulo.TabIndex = 115
        Me.rbtCodigoArticulo.Text = "Codigo articulo"
        Me.rbtCodigoArticulo.UseVisualStyleBackColor = True
        '
        'rbtDescripcion
        '
        Me.rbtDescripcion.AutoSize = True
        Me.rbtDescripcion.Checked = True
        Me.rbtDescripcion.Location = New System.Drawing.Point(7, 27)
        Me.rbtDescripcion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbtDescripcion.Name = "rbtDescripcion"
        Me.rbtDescripcion.Size = New System.Drawing.Size(103, 21)
        Me.rbtDescripcion.TabIndex = 114
        Me.rbtDescripcion.TabStop = True
        Me.rbtDescripcion.Text = "Descripcion"
        Me.rbtDescripcion.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(7, 86)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(549, 422)
        Me.Grid.TabIndex = 113
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 57)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(413, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbEliminar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1131, 27)
        Me.tsMenu.TabIndex = 119
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
        'tsbEliminar
        '
        Me.tsbEliminar.Image = CType(resources.GetObject("tsbEliminar.Image"), System.Drawing.Image)
        Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminar.Name = "tsbEliminar"
        Me.tsbEliminar.Size = New System.Drawing.Size(87, 24)
        Me.tsbEliminar.Text = "Eliminar"
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
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 556)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1131, 25)
        Me.StatusStripEstado.TabIndex = 120
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(61, 20)
        Me.tssLabel.Text = "Estado :"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 20)
        '
        'Catalogo_Articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 581)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(8, 28)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Articulos"
        Me.Tag = "0022"
        Me.Text = "Artículos"
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents TxtUnidadVenta As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCod_Linea As System.Windows.Forms.Label
    Friend WithEvents cboLinea As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodigoPostalParticular As System.Windows.Forms.Label
    Friend WithEvents TxtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents CboFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkInventariable As System.Windows.Forms.CheckBox
    Friend WithEvents chkImpuesto As System.Windows.Forms.CheckBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents rbtCodigoArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDescripcion As System.Windows.Forms.RadioButton
    Friend WithEvents chkEsSerializable As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblNombreUnidad As System.Windows.Forms.Label
End Class
