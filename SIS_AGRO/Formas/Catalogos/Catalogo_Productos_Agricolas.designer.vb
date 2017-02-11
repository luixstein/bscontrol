<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Productos_Agricolas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Productos_Agricolas))
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.chkInventariable = New System.Windows.Forms.CheckBox()
        Me.lblDisplayUnidadVenta = New System.Windows.Forms.Label()
        Me.cboUnidadVenta = New System.Windows.Forms.ComboBox()
        Me.LblDisplayRangoPiezas = New System.Windows.Forms.Label()
        Me.TxtRangoPiezas = New System.Windows.Forms.TextBox()
        Me.LblDisplayBultosXPalets = New System.Windows.Forms.Label()
        Me.TxtCantidadBultosXPalet = New System.Windows.Forms.TextBox()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.TxtPeso = New System.Windows.Forms.TextBox()
        Me.cboEtiqueta = New System.Windows.Forms.ComboBox()
        Me.lblDisplayEtiqueta = New System.Windows.Forms.Label()
        Me.cboEnvase = New System.Windows.Forms.ComboBox()
        Me.lblDisplayEnvase = New System.Windows.Forms.Label()
        Me.cboTamaño = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTamaño = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCultivo = New System.Windows.Forms.Label()
        Me.CboFamilia = New System.Windows.Forms.ComboBox()
        Me.lblDisplayFamilia = New System.Windows.Forms.Label()
        Me.LblDisplayPrecio = New System.Windows.Forms.Label()
        Me.TxtPrecio = New System.Windows.Forms.TextBox()
        Me.LblDisplayEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.TxtCodArticulo = New System.Windows.Forms.TextBox()
        Me.LblDisplayDescripcion = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.GpbFormulas = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.CboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid2 = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion.SuspendLayout()
        Me.GpbFormulas.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.chkInventariable)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayUnidadVenta)
        Me.gBoxInformacion.Controls.Add(Me.cboUnidadVenta)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayRangoPiezas)
        Me.gBoxInformacion.Controls.Add(Me.TxtRangoPiezas)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayBultosXPalets)
        Me.gBoxInformacion.Controls.Add(Me.TxtCantidadBultosXPalet)
        Me.gBoxInformacion.Controls.Add(Me.lblPeso)
        Me.gBoxInformacion.Controls.Add(Me.TxtPeso)
        Me.gBoxInformacion.Controls.Add(Me.cboEtiqueta)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayEtiqueta)
        Me.gBoxInformacion.Controls.Add(Me.cboEnvase)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayEnvase)
        Me.gBoxInformacion.Controls.Add(Me.cboTamaño)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTamaño)
        Me.gBoxInformacion.Controls.Add(Me.cboCultivo)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCultivo)
        Me.gBoxInformacion.Controls.Add(Me.CboFamilia)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFamilia)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayPrecio)
        Me.gBoxInformacion.Controls.Add(Me.TxtPrecio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodArticulo)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodArticulo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayDescripcion)
        Me.gBoxInformacion.Controls.Add(Me.TxtDescripcion)
        Me.gBoxInformacion.Location = New System.Drawing.Point(4, 26)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(398, 302)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información de los artículos"
        '
        'chkInventariable
        '
        Me.chkInventariable.AutoSize = True
        Me.chkInventariable.Location = New System.Drawing.Point(198, 130)
        Me.chkInventariable.Name = "chkInventariable"
        Me.chkInventariable.Size = New System.Drawing.Size(87, 17)
        Me.chkInventariable.TabIndex = 5
        Me.chkInventariable.Text = "Inventariable"
        Me.chkInventariable.UseVisualStyleBackColor = True
        '
        'lblDisplayUnidadVenta
        '
        Me.lblDisplayUnidadVenta.AutoSize = True
        Me.lblDisplayUnidadVenta.Location = New System.Drawing.Point(10, 277)
        Me.lblDisplayUnidadVenta.Name = "lblDisplayUnidadVenta"
        Me.lblDisplayUnidadVenta.Size = New System.Drawing.Size(77, 13)
        Me.lblDisplayUnidadVenta.TabIndex = 155
        Me.lblDisplayUnidadVenta.Text = "Unidad venta :"
        '
        'cboUnidadVenta
        '
        Me.cboUnidadVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadVenta.FormattingEnabled = True
        Me.cboUnidadVenta.Items.AddRange(New Object() {"CAJA", "KG"})
        Me.cboUnidadVenta.Location = New System.Drawing.Point(97, 274)
        Me.cboUnidadVenta.MaxLength = 1
        Me.cboUnidadVenta.Name = "cboUnidadVenta"
        Me.cboUnidadVenta.Size = New System.Drawing.Size(72, 21)
        Me.cboUnidadVenta.TabIndex = 10
        '
        'LblDisplayRangoPiezas
        '
        Me.LblDisplayRangoPiezas.AutoSize = True
        Me.LblDisplayRangoPiezas.Location = New System.Drawing.Point(217, 253)
        Me.LblDisplayRangoPiezas.Name = "LblDisplayRangoPiezas"
        Me.LblDisplayRangoPiezas.Size = New System.Drawing.Size(93, 13)
        Me.LblDisplayRangoPiezas.TabIndex = 152
        Me.LblDisplayRangoPiezas.Text = "Rango de piezas :"
        '
        'TxtRangoPiezas
        '
        Me.TxtRangoPiezas.Location = New System.Drawing.Point(318, 249)
        Me.TxtRangoPiezas.MaxLength = 21
        Me.TxtRangoPiezas.Name = "TxtRangoPiezas"
        Me.TxtRangoPiezas.Size = New System.Drawing.Size(72, 20)
        Me.TxtRangoPiezas.TabIndex = 12
        Me.TxtRangoPiezas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayBultosXPalets
        '
        Me.LblDisplayBultosXPalets.AutoSize = True
        Me.LblDisplayBultosXPalets.Location = New System.Drawing.Point(175, 229)
        Me.LblDisplayBultosXPalets.Name = "LblDisplayBultosXPalets"
        Me.LblDisplayBultosXPalets.Size = New System.Drawing.Size(135, 13)
        Me.LblDisplayBultosXPalets.TabIndex = 150
        Me.LblDisplayBultosXPalets.Text = "Cantidad de bultos x palet :"
        '
        'TxtCantidadBultosXPalet
        '
        Me.TxtCantidadBultosXPalet.Location = New System.Drawing.Point(318, 226)
        Me.TxtCantidadBultosXPalet.MaxLength = 21
        Me.TxtCantidadBultosXPalet.Name = "TxtCantidadBultosXPalet"
        Me.TxtCantidadBultosXPalet.Size = New System.Drawing.Size(72, 20)
        Me.TxtCantidadBultosXPalet.TabIndex = 11
        Me.TxtCantidadBultosXPalet.Text = "0"
        Me.TxtCantidadBultosXPalet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Location = New System.Drawing.Point(10, 253)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(37, 13)
        Me.lblPeso.TabIndex = 148
        Me.lblPeso.Text = "Peso :"
        '
        'TxtPeso
        '
        Me.TxtPeso.Location = New System.Drawing.Point(97, 249)
        Me.TxtPeso.MaxLength = 21
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(72, 20)
        Me.TxtPeso.TabIndex = 9
        Me.TxtPeso.Text = "0"
        Me.TxtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboEtiqueta
        '
        Me.cboEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEtiqueta.FormattingEnabled = True
        Me.cboEtiqueta.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboEtiqueta.Location = New System.Drawing.Point(97, 104)
        Me.cboEtiqueta.Name = "cboEtiqueta"
        Me.cboEtiqueta.Size = New System.Drawing.Size(294, 21)
        Me.cboEtiqueta.TabIndex = 3
        '
        'lblDisplayEtiqueta
        '
        Me.lblDisplayEtiqueta.AutoSize = True
        Me.lblDisplayEtiqueta.Location = New System.Drawing.Point(10, 107)
        Me.lblDisplayEtiqueta.Name = "lblDisplayEtiqueta"
        Me.lblDisplayEtiqueta.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplayEtiqueta.TabIndex = 146
        Me.lblDisplayEtiqueta.Text = "Etiqueta :"
        '
        'cboEnvase
        '
        Me.cboEnvase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnvase.FormattingEnabled = True
        Me.cboEnvase.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboEnvase.Location = New System.Drawing.Point(97, 77)
        Me.cboEnvase.Name = "cboEnvase"
        Me.cboEnvase.Size = New System.Drawing.Size(294, 21)
        Me.cboEnvase.TabIndex = 2
        '
        'lblDisplayEnvase
        '
        Me.lblDisplayEnvase.AutoSize = True
        Me.lblDisplayEnvase.Location = New System.Drawing.Point(10, 80)
        Me.lblDisplayEnvase.Name = "lblDisplayEnvase"
        Me.lblDisplayEnvase.Size = New System.Drawing.Size(49, 13)
        Me.lblDisplayEnvase.TabIndex = 144
        Me.lblDisplayEnvase.Text = "Envase :"
        '
        'cboTamaño
        '
        Me.cboTamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTamaño.FormattingEnabled = True
        Me.cboTamaño.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboTamaño.Location = New System.Drawing.Point(97, 50)
        Me.cboTamaño.Name = "cboTamaño"
        Me.cboTamaño.Size = New System.Drawing.Size(294, 21)
        Me.cboTamaño.TabIndex = 1
        '
        'lblDisplayTamaño
        '
        Me.lblDisplayTamaño.AutoSize = True
        Me.lblDisplayTamaño.Location = New System.Drawing.Point(10, 53)
        Me.lblDisplayTamaño.Name = "lblDisplayTamaño"
        Me.lblDisplayTamaño.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplayTamaño.TabIndex = 142
        Me.lblDisplayTamaño.Text = "Tamaño :"
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboCultivo.Location = New System.Drawing.Point(97, 23)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(294, 21)
        Me.cboCultivo.TabIndex = 0
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(10, 27)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 140
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.Enabled = False
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.CboFamilia.Location = New System.Drawing.Point(97, 197)
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(294, 21)
        Me.CboFamilia.TabIndex = 7
        '
        'lblDisplayFamilia
        '
        Me.lblDisplayFamilia.AutoSize = True
        Me.lblDisplayFamilia.Location = New System.Drawing.Point(10, 202)
        Me.lblDisplayFamilia.Name = "lblDisplayFamilia"
        Me.lblDisplayFamilia.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayFamilia.TabIndex = 138
        Me.lblDisplayFamilia.Text = "Familia :"
        '
        'LblDisplayPrecio
        '
        Me.LblDisplayPrecio.AutoSize = True
        Me.LblDisplayPrecio.Location = New System.Drawing.Point(10, 229)
        Me.LblDisplayPrecio.Name = "LblDisplayPrecio"
        Me.LblDisplayPrecio.Size = New System.Drawing.Size(43, 13)
        Me.LblDisplayPrecio.TabIndex = 136
        Me.LblDisplayPrecio.Text = "Precio :"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Location = New System.Drawing.Point(97, 224)
        Me.TxtPrecio.MaxLength = 21
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(72, 20)
        Me.TxtPrecio.TabIndex = 8
        Me.TxtPrecio.Text = "0"
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayEstatus
        '
        Me.LblDisplayEstatus.AutoSize = True
        Me.LblDisplayEstatus.Location = New System.Drawing.Point(262, 279)
        Me.LblDisplayEstatus.Name = "LblDisplayEstatus"
        Me.LblDisplayEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblDisplayEstatus.TabIndex = 129
        Me.LblDisplayEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(318, 274)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(72, 21)
        Me.CboEstatus.TabIndex = 13
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(10, 134)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(46, 13)
        Me.LblDisplayCodArticulo.TabIndex = 127
        Me.LblDisplayCodArticulo.Text = "Código :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Enabled = False
        Me.TxtCodArticulo.Location = New System.Drawing.Point(97, 131)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(72, 20)
        Me.TxtCodArticulo.TabIndex = 4
        '
        'LblDisplayDescripcion
        '
        Me.LblDisplayDescripcion.AutoSize = True
        Me.LblDisplayDescripcion.Location = New System.Drawing.Point(10, 160)
        Me.LblDisplayDescripcion.Name = "LblDisplayDescripcion"
        Me.LblDisplayDescripcion.Size = New System.Drawing.Size(69, 13)
        Me.LblDisplayDescripcion.TabIndex = 122
        Me.LblDisplayDescripcion.Text = "Descripción :"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(97, 157)
        Me.TxtDescripcion.MaxLength = 80
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(294, 34)
        Me.TxtDescripcion.TabIndex = 6
        '
        'GpbFormulas
        '
        Me.GpbFormulas.Controls.Add(Me.Grid)
        Me.GpbFormulas.Location = New System.Drawing.Point(4, 331)
        Me.GpbFormulas.Name = "GpbFormulas"
        Me.GpbFormulas.Size = New System.Drawing.Size(1058, 282)
        Me.GpbFormulas.TabIndex = 2
        Me.GpbFormulas.TabStop = False
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DefaultRowHeight = CType(24, Short)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(13, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 1
        Me.Grid.Size = New System.Drawing.Size(1039, 254)
        Me.Grid.TabIndex = 1
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid2)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(404, 26)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(652, 302)
        Me.gBoxBusquedaRapida.TabIndex = 3
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(603, 17)
        Me.CboEstatusFiltro.MaxLength = 1
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(44, 21)
        Me.CboEstatusFiltro.TabIndex = 156
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(550, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Estatus :"
        '
        'Grid2
        '
        Me.Grid2.AllowUserToAddRows = False
        Me.Grid2.AllowUserToDeleteRows = False
        Me.Grid2.AllowUserToResizeColumns = False
        Me.Grid2.AllowUserToResizeRows = False
        Me.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid2.Location = New System.Drawing.Point(6, 43)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.ReadOnly = True
        Me.Grid2.RowHeadersVisible = False
        Me.Grid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid2.Size = New System.Drawing.Size(640, 253)
        Me.Grid2.TabIndex = 115
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(539, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbEliminar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1068, 27)
        Me.tsMenu.TabIndex = 1
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
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(61, 24)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(66, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 24)
        Me.tsbCancelar.Text = "&Regresar"
        '
        'tsbEliminar
        '
        Me.tsbEliminar.Image = CType(resources.GetObject("tsbEliminar.Image"), System.Drawing.Image)
        Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminar.Name = "tsbEliminar"
        Me.tsbEliminar.Size = New System.Drawing.Size(74, 24)
        Me.tsbEliminar.Text = "&Eliminar"
        '
        'tsbImprimirListado
        '
        Me.tsbImprimirListado.Image = CType(resources.GetObject("tsbImprimirListado.Image"), System.Drawing.Image)
        Me.tsbImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirListado.Name = "tsbImprimirListado"
        Me.tsbImprimirListado.Size = New System.Drawing.Size(115, 24)
        Me.tsbImprimirListado.Text = "&Imprimir listado"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 616)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1068, 22)
        Me.StatusStripEstado.TabIndex = 124
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(48, 17)
        Me.tssLabel.Text = "Estado :"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 17)
        '
        'Catalogo_Productos_Agricolas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 638)
        Me.Controls.Add(Me.GpbFormulas)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Productos_Agricolas"
        Me.Text = "Catálogo productos agrícolas"
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.GpbFormulas.ResumeLayout(False)
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents CboFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayFamilia As System.Windows.Forms.Label
    Friend WithEvents LblDisplayPrecio As System.Windows.Forms.Label
    Friend WithEvents TxtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboEtiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayEtiqueta As System.Windows.Forms.Label
    Friend WithEvents cboEnvase As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayEnvase As System.Windows.Forms.Label
    Friend WithEvents cboTamaño As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTamaño As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCultivo As System.Windows.Forms.Label
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents TxtPeso As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayBultosXPalets As System.Windows.Forms.Label
    Friend WithEvents TxtCantidadBultosXPalet As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayRangoPiezas As System.Windows.Forms.Label
    Friend WithEvents TxtRangoPiezas As System.Windows.Forms.TextBox
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GpbFormulas As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents cboUnidadVenta As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents chkInventariable As System.Windows.Forms.CheckBox
    Friend WithEvents Grid2 As System.Windows.Forms.DataGridView
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
