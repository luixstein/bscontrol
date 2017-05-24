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
        Me.LblNombreUnidadVenta = New System.Windows.Forms.Label()
        Me.txtCodigoUnidadVenta = New System.Windows.Forms.TextBox()
        Me.LblNombreEtiqueta = New System.Windows.Forms.Label()
        Me.LblNombreEnvase = New System.Windows.Forms.Label()
        Me.LblNombreTamaño = New System.Windows.Forms.Label()
        Me.LblNombreCultivo = New System.Windows.Forms.Label()
        Me.txtCodigoEtiqueta = New System.Windows.Forms.TextBox()
        Me.txtCodigoEnvase = New System.Windows.Forms.TextBox()
        Me.txtCodigoTamaño = New System.Windows.Forms.TextBox()
        Me.txtCodigoCultivo = New System.Windows.Forms.TextBox()
        Me.chkInventariable = New System.Windows.Forms.CheckBox()
        Me.lblDisplayUnidadVenta = New System.Windows.Forms.Label()
        Me.LblDisplayRangoPiezas = New System.Windows.Forms.Label()
        Me.TxtRangoPiezas = New System.Windows.Forms.TextBox()
        Me.LblDisplayBultosXPalets = New System.Windows.Forms.Label()
        Me.TxtCantidadBultosXPalet = New System.Windows.Forms.TextBox()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.TxtPeso = New System.Windows.Forms.TextBox()
        Me.lblDisplayEtiqueta = New System.Windows.Forms.Label()
        Me.lblDisplayEnvase = New System.Windows.Forms.Label()
        Me.lblDisplayTamaño = New System.Windows.Forms.Label()
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
        Me.gBoxInformacion.Controls.Add(Me.LblNombreUnidadVenta)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoUnidadVenta)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreEtiqueta)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreEnvase)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreTamaño)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoEtiqueta)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoEnvase)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoTamaño)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoCultivo)
        Me.gBoxInformacion.Controls.Add(Me.chkInventariable)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayUnidadVenta)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayRangoPiezas)
        Me.gBoxInformacion.Controls.Add(Me.TxtRangoPiezas)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayBultosXPalets)
        Me.gBoxInformacion.Controls.Add(Me.TxtCantidadBultosXPalet)
        Me.gBoxInformacion.Controls.Add(Me.lblPeso)
        Me.gBoxInformacion.Controls.Add(Me.TxtPeso)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayEtiqueta)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayEnvase)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTamaño)
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
        Me.gBoxInformacion.Location = New System.Drawing.Point(5, 32)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(531, 372)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información de los artículos"
        '
        'LblNombreUnidadVenta
        '
        Me.LblNombreUnidadVenta.AutoSize = True
        Me.LblNombreUnidadVenta.Location = New System.Drawing.Point(216, 342)
        Me.LblNombreUnidadVenta.Name = "LblNombreUnidadVenta"
        Me.LblNombreUnidadVenta.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreUnidadVenta.TabIndex = 165
        Me.LblNombreUnidadVenta.Text = "_"
        '
        'txtCodigoUnidadVenta
        '
        Me.txtCodigoUnidadVenta.Location = New System.Drawing.Point(129, 339)
        Me.txtCodigoUnidadVenta.Name = "txtCodigoUnidadVenta"
        Me.txtCodigoUnidadVenta.Size = New System.Drawing.Size(81, 22)
        Me.txtCodigoUnidadVenta.TabIndex = 164
        '
        'LblNombreEtiqueta
        '
        Me.LblNombreEtiqueta.AutoSize = True
        Me.LblNombreEtiqueta.Location = New System.Drawing.Point(194, 132)
        Me.LblNombreEtiqueta.Name = "LblNombreEtiqueta"
        Me.LblNombreEtiqueta.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreEtiqueta.TabIndex = 163
        Me.LblNombreEtiqueta.Text = "_"
        '
        'LblNombreEnvase
        '
        Me.LblNombreEnvase.AutoSize = True
        Me.LblNombreEnvase.Location = New System.Drawing.Point(194, 98)
        Me.LblNombreEnvase.Name = "LblNombreEnvase"
        Me.LblNombreEnvase.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreEnvase.TabIndex = 162
        Me.LblNombreEnvase.Text = "_"
        '
        'LblNombreTamaño
        '
        Me.LblNombreTamaño.AutoSize = True
        Me.LblNombreTamaño.Location = New System.Drawing.Point(194, 65)
        Me.LblNombreTamaño.Name = "LblNombreTamaño"
        Me.LblNombreTamaño.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreTamaño.TabIndex = 161
        Me.LblNombreTamaño.Text = "_"
        '
        'LblNombreCultivo
        '
        Me.LblNombreCultivo.AutoSize = True
        Me.LblNombreCultivo.Location = New System.Drawing.Point(194, 36)
        Me.LblNombreCultivo.Name = "LblNombreCultivo"
        Me.LblNombreCultivo.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreCultivo.TabIndex = 160
        Me.LblNombreCultivo.Text = "_"
        '
        'txtCodigoEtiqueta
        '
        Me.txtCodigoEtiqueta.Location = New System.Drawing.Point(129, 129)
        Me.txtCodigoEtiqueta.Name = "txtCodigoEtiqueta"
        Me.txtCodigoEtiqueta.Size = New System.Drawing.Size(59, 22)
        Me.txtCodigoEtiqueta.TabIndex = 159
        '
        'txtCodigoEnvase
        '
        Me.txtCodigoEnvase.Location = New System.Drawing.Point(129, 95)
        Me.txtCodigoEnvase.Name = "txtCodigoEnvase"
        Me.txtCodigoEnvase.Size = New System.Drawing.Size(59, 22)
        Me.txtCodigoEnvase.TabIndex = 158
        '
        'txtCodigoTamaño
        '
        Me.txtCodigoTamaño.Location = New System.Drawing.Point(129, 62)
        Me.txtCodigoTamaño.Name = "txtCodigoTamaño"
        Me.txtCodigoTamaño.Size = New System.Drawing.Size(59, 22)
        Me.txtCodigoTamaño.TabIndex = 157
        '
        'txtCodigoCultivo
        '
        Me.txtCodigoCultivo.Location = New System.Drawing.Point(129, 33)
        Me.txtCodigoCultivo.Name = "txtCodigoCultivo"
        Me.txtCodigoCultivo.Size = New System.Drawing.Size(59, 22)
        Me.txtCodigoCultivo.TabIndex = 156
        '
        'chkInventariable
        '
        Me.chkInventariable.AutoSize = True
        Me.chkInventariable.Location = New System.Drawing.Point(264, 160)
        Me.chkInventariable.Margin = New System.Windows.Forms.Padding(4)
        Me.chkInventariable.Name = "chkInventariable"
        Me.chkInventariable.Size = New System.Drawing.Size(111, 21)
        Me.chkInventariable.TabIndex = 5
        Me.chkInventariable.Text = "Inventariable"
        Me.chkInventariable.UseVisualStyleBackColor = True
        '
        'lblDisplayUnidadVenta
        '
        Me.lblDisplayUnidadVenta.AutoSize = True
        Me.lblDisplayUnidadVenta.Location = New System.Drawing.Point(13, 341)
        Me.lblDisplayUnidadVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayUnidadVenta.Name = "lblDisplayUnidadVenta"
        Me.lblDisplayUnidadVenta.Size = New System.Drawing.Size(100, 17)
        Me.lblDisplayUnidadVenta.TabIndex = 155
        Me.lblDisplayUnidadVenta.Text = "Unidad venta :"
        '
        'LblDisplayRangoPiezas
        '
        Me.LblDisplayRangoPiezas.AutoSize = True
        Me.LblDisplayRangoPiezas.Location = New System.Drawing.Point(289, 311)
        Me.LblDisplayRangoPiezas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayRangoPiezas.Name = "LblDisplayRangoPiezas"
        Me.LblDisplayRangoPiezas.Size = New System.Drawing.Size(123, 17)
        Me.LblDisplayRangoPiezas.TabIndex = 152
        Me.LblDisplayRangoPiezas.Text = "Rango de piezas :"
        '
        'TxtRangoPiezas
        '
        Me.TxtRangoPiezas.Location = New System.Drawing.Point(424, 306)
        Me.TxtRangoPiezas.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRangoPiezas.MaxLength = 21
        Me.TxtRangoPiezas.Name = "TxtRangoPiezas"
        Me.TxtRangoPiezas.Size = New System.Drawing.Size(95, 22)
        Me.TxtRangoPiezas.TabIndex = 12
        Me.TxtRangoPiezas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayBultosXPalets
        '
        Me.LblDisplayBultosXPalets.AutoSize = True
        Me.LblDisplayBultosXPalets.Location = New System.Drawing.Point(233, 282)
        Me.LblDisplayBultosXPalets.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayBultosXPalets.Name = "LblDisplayBultosXPalets"
        Me.LblDisplayBultosXPalets.Size = New System.Drawing.Size(179, 17)
        Me.LblDisplayBultosXPalets.TabIndex = 150
        Me.LblDisplayBultosXPalets.Text = "Cantidad de bultos x palet :"
        '
        'TxtCantidadBultosXPalet
        '
        Me.TxtCantidadBultosXPalet.Location = New System.Drawing.Point(424, 278)
        Me.TxtCantidadBultosXPalet.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCantidadBultosXPalet.MaxLength = 21
        Me.TxtCantidadBultosXPalet.Name = "TxtCantidadBultosXPalet"
        Me.TxtCantidadBultosXPalet.Size = New System.Drawing.Size(95, 22)
        Me.TxtCantidadBultosXPalet.TabIndex = 11
        Me.TxtCantidadBultosXPalet.Text = "0"
        Me.TxtCantidadBultosXPalet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Location = New System.Drawing.Point(13, 311)
        Me.lblPeso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(48, 17)
        Me.lblPeso.TabIndex = 148
        Me.lblPeso.Text = "Peso :"
        '
        'TxtPeso
        '
        Me.TxtPeso.Location = New System.Drawing.Point(129, 306)
        Me.TxtPeso.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPeso.MaxLength = 21
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(95, 22)
        Me.TxtPeso.TabIndex = 9
        Me.TxtPeso.Text = "0"
        Me.TxtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayEtiqueta
        '
        Me.lblDisplayEtiqueta.AutoSize = True
        Me.lblDisplayEtiqueta.Location = New System.Drawing.Point(13, 132)
        Me.lblDisplayEtiqueta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEtiqueta.Name = "lblDisplayEtiqueta"
        Me.lblDisplayEtiqueta.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplayEtiqueta.TabIndex = 146
        Me.lblDisplayEtiqueta.Text = "Etiqueta :"
        '
        'lblDisplayEnvase
        '
        Me.lblDisplayEnvase.AutoSize = True
        Me.lblDisplayEnvase.Location = New System.Drawing.Point(13, 98)
        Me.lblDisplayEnvase.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEnvase.Name = "lblDisplayEnvase"
        Me.lblDisplayEnvase.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayEnvase.TabIndex = 144
        Me.lblDisplayEnvase.Text = "Envase :"
        '
        'lblDisplayTamaño
        '
        Me.lblDisplayTamaño.AutoSize = True
        Me.lblDisplayTamaño.Location = New System.Drawing.Point(13, 65)
        Me.lblDisplayTamaño.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTamaño.Name = "lblDisplayTamaño"
        Me.lblDisplayTamaño.Size = New System.Drawing.Size(68, 17)
        Me.lblDisplayTamaño.TabIndex = 142
        Me.lblDisplayTamaño.Text = "Tamaño :"
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(13, 33)
        Me.lblDisplayCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(58, 17)
        Me.lblDisplayCultivo.TabIndex = 140
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.Enabled = False
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.CboFamilia.Location = New System.Drawing.Point(129, 242)
        Me.CboFamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(391, 24)
        Me.CboFamilia.TabIndex = 7
        '
        'lblDisplayFamilia
        '
        Me.lblDisplayFamilia.AutoSize = True
        Me.lblDisplayFamilia.Location = New System.Drawing.Point(13, 249)
        Me.lblDisplayFamilia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFamilia.Name = "lblDisplayFamilia"
        Me.lblDisplayFamilia.Size = New System.Drawing.Size(60, 17)
        Me.lblDisplayFamilia.TabIndex = 138
        Me.lblDisplayFamilia.Text = "Familia :"
        '
        'LblDisplayPrecio
        '
        Me.LblDisplayPrecio.AutoSize = True
        Me.LblDisplayPrecio.Location = New System.Drawing.Point(13, 282)
        Me.LblDisplayPrecio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayPrecio.Name = "LblDisplayPrecio"
        Me.LblDisplayPrecio.Size = New System.Drawing.Size(56, 17)
        Me.LblDisplayPrecio.TabIndex = 136
        Me.LblDisplayPrecio.Text = "Precio :"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Location = New System.Drawing.Point(129, 276)
        Me.TxtPrecio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPrecio.MaxLength = 21
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(95, 22)
        Me.TxtPrecio.TabIndex = 8
        Me.TxtPrecio.Text = "0"
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayEstatus
        '
        Me.LblDisplayEstatus.AutoSize = True
        Me.LblDisplayEstatus.Location = New System.Drawing.Point(349, 343)
        Me.LblDisplayEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayEstatus.Name = "LblDisplayEstatus"
        Me.LblDisplayEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayEstatus.TabIndex = 129
        Me.LblDisplayEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(424, 337)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(95, 24)
        Me.CboEstatus.TabIndex = 13
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(13, 165)
        Me.LblDisplayCodArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(60, 17)
        Me.LblDisplayCodArticulo.TabIndex = 127
        Me.LblDisplayCodArticulo.Text = "Código :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Enabled = False
        Me.TxtCodArticulo.Location = New System.Drawing.Point(129, 161)
        Me.TxtCodArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodArticulo.TabIndex = 4
        '
        'LblDisplayDescripcion
        '
        Me.LblDisplayDescripcion.AutoSize = True
        Me.LblDisplayDescripcion.Location = New System.Drawing.Point(13, 197)
        Me.LblDisplayDescripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDescripcion.Name = "LblDisplayDescripcion"
        Me.LblDisplayDescripcion.Size = New System.Drawing.Size(90, 17)
        Me.LblDisplayDescripcion.TabIndex = 122
        Me.LblDisplayDescripcion.Text = "Descripción :"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(129, 193)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDescripcion.MaxLength = 80
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(391, 41)
        Me.TxtDescripcion.TabIndex = 6
        '
        'GpbFormulas
        '
        Me.GpbFormulas.Controls.Add(Me.Grid)
        Me.GpbFormulas.Location = New System.Drawing.Point(5, 407)
        Me.GpbFormulas.Margin = New System.Windows.Forms.Padding(4)
        Me.GpbFormulas.Name = "GpbFormulas"
        Me.GpbFormulas.Padding = New System.Windows.Forms.Padding(4)
        Me.GpbFormulas.Size = New System.Drawing.Size(1411, 347)
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
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(17, 23)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 1
        Me.Grid.Size = New System.Drawing.Size(1385, 313)
        Me.Grid.TabIndex = 1
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid2)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(539, 32)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(869, 372)
        Me.gBoxBusquedaRapida.TabIndex = 3
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(804, 21)
        Me.CboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatusFiltro.MaxLength = 1
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(57, 24)
        Me.CboEstatusFiltro.TabIndex = 156
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(733, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
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
        Me.Grid2.Location = New System.Drawing.Point(8, 53)
        Me.Grid2.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.ReadOnly = True
        Me.Grid2.RowHeadersVisible = False
        Me.Grid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid2.Size = New System.Drawing.Size(853, 311)
        Me.Grid2.TabIndex = 115
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(717, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbEliminar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1424, 27)
        Me.tsMenu.TabIndex = 1
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
        Me.tsbCancelar.Size = New System.Drawing.Size(91, 24)
        Me.tsbCancelar.Text = "&Regresar"
        '
        'tsbEliminar
        '
        Me.tsbEliminar.Image = CType(resources.GetObject("tsbEliminar.Image"), System.Drawing.Image)
        Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminar.Name = "tsbEliminar"
        Me.tsbEliminar.Size = New System.Drawing.Size(87, 24)
        Me.tsbEliminar.Text = "&Eliminar"
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 760)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1424, 25)
        Me.StatusStripEstado.TabIndex = 124
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
        'Catalogo_Productos_Agricolas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1424, 785)
        Me.Controls.Add(Me.GpbFormulas)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Productos_Agricolas"
        Me.ShowIcon = False
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
    Friend WithEvents lblDisplayEtiqueta As System.Windows.Forms.Label
    Friend WithEvents lblDisplayEnvase As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTamaño As System.Windows.Forms.Label
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
    Friend WithEvents lblDisplayUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents chkInventariable As System.Windows.Forms.CheckBox
    Friend WithEvents Grid2 As System.Windows.Forms.DataGridView
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoEnvase As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTamaño As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCultivo As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreEtiqueta As System.Windows.Forms.Label
    Friend WithEvents LblNombreEnvase As System.Windows.Forms.Label
    Friend WithEvents LblNombreTamaño As System.Windows.Forms.Label
    Friend WithEvents LblNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents LblNombreUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents txtCodigoUnidadVenta As System.Windows.Forms.TextBox
End Class
