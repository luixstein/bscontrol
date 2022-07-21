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
        Me.lblDisplayFraccionArancelaria = New System.Windows.Forms.Label()
        Me.txtFraccionArancelaria = New System.Windows.Forms.TextBox()
        Me.cboRetencionISRPorcentaje = New System.Windows.Forms.ComboBox()
        Me.chkRetencionISRTiene = New System.Windows.Forms.CheckBox()
        Me.cboRetencionIVAPorcentaje = New System.Windows.Forms.ComboBox()
        Me.chkRetencionIVATiene = New System.Windows.Forms.CheckBox()
        Me.lblDisplayImpuestoFlete = New System.Windows.Forms.Label()
        Me.cboImpuestoFlete = New System.Windows.Forms.ComboBox()
        Me.lblNombreProducto = New System.Windows.Forms.Label()
        Me.lblCodigoProducto = New System.Windows.Forms.Label()
        Me.txtCodigoProducto = New System.Windows.Forms.TextBox()
        Me.LblFactorConversion = New System.Windows.Forms.Label()
        Me.txtFactorConversion = New System.Windows.Forms.TextBox()
        Me.lblClaveProductoSATSimiliar = New System.Windows.Forms.Label()
        Me.lblDisplayImpuestoIVA = New System.Windows.Forms.Label()
        Me.cboImpuestoIVA = New System.Windows.Forms.ComboBox()
        Me.lblClaveProductoSAT = New System.Windows.Forms.Label()
        Me.lblCodigoUnidadSAT = New System.Windows.Forms.Label()
        Me.lblDisplayClaveProductoSAT = New System.Windows.Forms.Label()
        Me.txtClaveProductoSAT = New System.Windows.Forms.TextBox()
        Me.lblDisplayCodigoUnidadSAT = New System.Windows.Forms.Label()
        Me.txtCodigoUnidadSAT = New System.Windows.Forms.TextBox()
        Me.cboGradoToxicidad = New System.Windows.Forms.ComboBox()
        Me.lblDisplayGradoToxicidad = New System.Windows.Forms.Label()
        Me.LblNombreUnidad = New System.Windows.Forms.Label()
        Me.chkEsSerializable = New System.Windows.Forms.CheckBox()
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
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFraccionArancelaria)
        Me.gBoxInformacion.Controls.Add(Me.txtFraccionArancelaria)
        Me.gBoxInformacion.Controls.Add(Me.cboRetencionISRPorcentaje)
        Me.gBoxInformacion.Controls.Add(Me.chkRetencionISRTiene)
        Me.gBoxInformacion.Controls.Add(Me.cboRetencionIVAPorcentaje)
        Me.gBoxInformacion.Controls.Add(Me.chkRetencionIVATiene)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayImpuestoFlete)
        Me.gBoxInformacion.Controls.Add(Me.cboImpuestoFlete)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreProducto)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoProducto)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoProducto)
        Me.gBoxInformacion.Controls.Add(Me.LblFactorConversion)
        Me.gBoxInformacion.Controls.Add(Me.txtFactorConversion)
        Me.gBoxInformacion.Controls.Add(Me.lblClaveProductoSATSimiliar)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayImpuestoIVA)
        Me.gBoxInformacion.Controls.Add(Me.cboImpuestoIVA)
        Me.gBoxInformacion.Controls.Add(Me.lblClaveProductoSAT)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoUnidadSAT)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayClaveProductoSAT)
        Me.gBoxInformacion.Controls.Add(Me.txtClaveProductoSAT)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCodigoUnidadSAT)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoUnidadSAT)
        Me.gBoxInformacion.Controls.Add(Me.cboGradoToxicidad)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayGradoToxicidad)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreUnidad)
        Me.gBoxInformacion.Controls.Add(Me.chkEsSerializable)
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
        Me.gBoxInformacion.Enabled = False
        Me.gBoxInformacion.Location = New System.Drawing.Point(8, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(397, 630)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información de los artículos"
        '
        'lblDisplayFraccionArancelaria
        '
        Me.lblDisplayFraccionArancelaria.AutoSize = True
        Me.lblDisplayFraccionArancelaria.Location = New System.Drawing.Point(10, 607)
        Me.lblDisplayFraccionArancelaria.Name = "lblDisplayFraccionArancelaria"
        Me.lblDisplayFraccionArancelaria.Size = New System.Drawing.Size(109, 13)
        Me.lblDisplayFraccionArancelaria.TabIndex = 253
        Me.lblDisplayFraccionArancelaria.Text = "Fracción arancelaria :"
        '
        'txtFraccionArancelaria
        '
        Me.txtFraccionArancelaria.Location = New System.Drawing.Point(128, 604)
        Me.txtFraccionArancelaria.MaxLength = 10
        Me.txtFraccionArancelaria.Name = "txtFraccionArancelaria"
        Me.txtFraccionArancelaria.Size = New System.Drawing.Size(72, 20)
        Me.txtFraccionArancelaria.TabIndex = 19
        '
        'cboRetencionISRPorcentaje
        '
        Me.cboRetencionISRPorcentaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRetencionISRPorcentaje.FormattingEnabled = True
        Me.cboRetencionISRPorcentaje.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboRetencionISRPorcentaje.Location = New System.Drawing.Point(200, 316)
        Me.cboRetencionISRPorcentaje.Name = "cboRetencionISRPorcentaje"
        Me.cboRetencionISRPorcentaje.Size = New System.Drawing.Size(73, 21)
        Me.cboRetencionISRPorcentaje.TabIndex = 10
        '
        'chkRetencionISRTiene
        '
        Me.chkRetencionISRTiene.AutoSize = True
        Me.chkRetencionISRTiene.Location = New System.Drawing.Point(96, 318)
        Me.chkRetencionISRTiene.Name = "chkRetencionISRTiene"
        Me.chkRetencionISRTiene.Size = New System.Drawing.Size(96, 17)
        Me.chkRetencionISRTiene.TabIndex = 9
        Me.chkRetencionISRTiene.Text = "Retención ISR"
        Me.chkRetencionISRTiene.UseVisualStyleBackColor = True
        '
        'cboRetencionIVAPorcentaje
        '
        Me.cboRetencionIVAPorcentaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRetencionIVAPorcentaje.FormattingEnabled = True
        Me.cboRetencionIVAPorcentaje.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboRetencionIVAPorcentaje.Location = New System.Drawing.Point(200, 291)
        Me.cboRetencionIVAPorcentaje.Name = "cboRetencionIVAPorcentaje"
        Me.cboRetencionIVAPorcentaje.Size = New System.Drawing.Size(73, 21)
        Me.cboRetencionIVAPorcentaje.TabIndex = 8
        '
        'chkRetencionIVATiene
        '
        Me.chkRetencionIVATiene.AutoSize = True
        Me.chkRetencionIVATiene.Location = New System.Drawing.Point(97, 293)
        Me.chkRetencionIVATiene.Name = "chkRetencionIVATiene"
        Me.chkRetencionIVATiene.Size = New System.Drawing.Size(98, 17)
        Me.chkRetencionIVATiene.TabIndex = 7
        Me.chkRetencionIVATiene.Text = "Retención IVA "
        Me.chkRetencionIVATiene.UseVisualStyleBackColor = True
        '
        'lblDisplayImpuestoFlete
        '
        Me.lblDisplayImpuestoFlete.AutoSize = True
        Me.lblDisplayImpuestoFlete.Location = New System.Drawing.Point(238, 584)
        Me.lblDisplayImpuestoFlete.Name = "lblDisplayImpuestoFlete"
        Me.lblDisplayImpuestoFlete.Size = New System.Drawing.Size(79, 13)
        Me.lblDisplayImpuestoFlete.TabIndex = 251
        Me.lblDisplayImpuestoFlete.Text = "Impuesto flete :"
        Me.lblDisplayImpuestoFlete.Visible = False
        '
        'cboImpuestoFlete
        '
        Me.cboImpuestoFlete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImpuestoFlete.FormattingEnabled = True
        Me.cboImpuestoFlete.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboImpuestoFlete.Location = New System.Drawing.Point(236, 599)
        Me.cboImpuestoFlete.Name = "cboImpuestoFlete"
        Me.cboImpuestoFlete.Size = New System.Drawing.Size(155, 21)
        Me.cboImpuestoFlete.TabIndex = 250
        Me.cboImpuestoFlete.Visible = False
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.Location = New System.Drawing.Point(125, 584)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(13, 13)
        Me.lblNombreProducto.TabIndex = 249
        Me.lblNombreProducto.Text = "_"
        '
        'lblCodigoProducto
        '
        Me.lblCodigoProducto.AutoSize = True
        Me.lblCodigoProducto.Location = New System.Drawing.Point(10, 561)
        Me.lblCodigoProducto.Name = "lblCodigoProducto"
        Me.lblCodigoProducto.Size = New System.Drawing.Size(91, 13)
        Me.lblCodigoProducto.TabIndex = 248
        Me.lblCodigoProducto.Text = "Código producto :"
        '
        'txtCodigoProducto
        '
        Me.txtCodigoProducto.Location = New System.Drawing.Point(128, 558)
        Me.txtCodigoProducto.MaxLength = 10
        Me.txtCodigoProducto.Name = "txtCodigoProducto"
        Me.txtCodigoProducto.Size = New System.Drawing.Size(72, 20)
        Me.txtCodigoProducto.TabIndex = 18
        '
        'LblFactorConversion
        '
        Me.LblFactorConversion.AutoSize = True
        Me.LblFactorConversion.Location = New System.Drawing.Point(10, 535)
        Me.LblFactorConversion.Name = "LblFactorConversion"
        Me.LblFactorConversion.Size = New System.Drawing.Size(113, 13)
        Me.LblFactorConversion.TabIndex = 246
        Me.LblFactorConversion.Text = "Factor de conversión :"
        '
        'txtFactorConversion
        '
        Me.txtFactorConversion.Location = New System.Drawing.Point(128, 532)
        Me.txtFactorConversion.MaxLength = 12
        Me.txtFactorConversion.Name = "txtFactorConversion"
        Me.txtFactorConversion.Size = New System.Drawing.Size(72, 20)
        Me.txtFactorConversion.TabIndex = 17
        Me.txtFactorConversion.Text = "1.00"
        Me.txtFactorConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblClaveProductoSATSimiliar
        '
        Me.lblClaveProductoSATSimiliar.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblClaveProductoSATSimiliar.Location = New System.Drawing.Point(97, 505)
        Me.lblClaveProductoSATSimiliar.Name = "lblClaveProductoSATSimiliar"
        Me.lblClaveProductoSATSimiliar.Size = New System.Drawing.Size(294, 13)
        Me.lblClaveProductoSATSimiliar.TabIndex = 244
        '
        'lblDisplayImpuestoIVA
        '
        Me.lblDisplayImpuestoIVA.AutoSize = True
        Me.lblDisplayImpuestoIVA.Location = New System.Drawing.Point(10, 244)
        Me.lblDisplayImpuestoIVA.Name = "lblDisplayImpuestoIVA"
        Me.lblDisplayImpuestoIVA.Size = New System.Drawing.Size(30, 13)
        Me.lblDisplayImpuestoIVA.TabIndex = 243
        Me.lblDisplayImpuestoIVA.Text = "IVA :"
        '
        'cboImpuestoIVA
        '
        Me.cboImpuestoIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImpuestoIVA.FormattingEnabled = True
        Me.cboImpuestoIVA.Location = New System.Drawing.Point(97, 241)
        Me.cboImpuestoIVA.Name = "cboImpuestoIVA"
        Me.cboImpuestoIVA.Size = New System.Drawing.Size(212, 21)
        Me.cboImpuestoIVA.TabIndex = 5
        '
        'lblClaveProductoSAT
        '
        Me.lblClaveProductoSAT.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblClaveProductoSAT.Location = New System.Drawing.Point(97, 482)
        Me.lblClaveProductoSAT.Name = "lblClaveProductoSAT"
        Me.lblClaveProductoSAT.Size = New System.Drawing.Size(294, 13)
        Me.lblClaveProductoSAT.TabIndex = 241
        '
        'lblCodigoUnidadSAT
        '
        Me.lblCodigoUnidadSAT.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCodigoUnidadSAT.Location = New System.Drawing.Point(97, 441)
        Me.lblCodigoUnidadSAT.Name = "lblCodigoUnidadSAT"
        Me.lblCodigoUnidadSAT.Size = New System.Drawing.Size(294, 13)
        Me.lblCodigoUnidadSAT.TabIndex = 240
        '
        'lblDisplayClaveProductoSAT
        '
        Me.lblDisplayClaveProductoSAT.AutoSize = True
        Me.lblDisplayClaveProductoSAT.Location = New System.Drawing.Point(10, 460)
        Me.lblDisplayClaveProductoSAT.Name = "lblDisplayClaveProductoSAT"
        Me.lblDisplayClaveProductoSAT.Size = New System.Drawing.Size(266, 13)
        Me.lblDisplayClaveProductoSAT.TabIndex = 239
        Me.lblDisplayClaveProductoSAT.Text = "Clave producto/serv SAT: (Puede buscar con F6 ó F7)"
        '
        'txtClaveProductoSAT
        '
        Me.txtClaveProductoSAT.Location = New System.Drawing.Point(10, 479)
        Me.txtClaveProductoSAT.MaxLength = 10
        Me.txtClaveProductoSAT.Name = "txtClaveProductoSAT"
        Me.txtClaveProductoSAT.Size = New System.Drawing.Size(69, 20)
        Me.txtClaveProductoSAT.TabIndex = 16
        '
        'lblDisplayCodigoUnidadSAT
        '
        Me.lblDisplayCodigoUnidadSAT.AutoSize = True
        Me.lblDisplayCodigoUnidadSAT.Location = New System.Drawing.Point(10, 422)
        Me.lblDisplayCodigoUnidadSAT.Name = "lblDisplayCodigoUnidadSAT"
        Me.lblDisplayCodigoUnidadSAT.Size = New System.Drawing.Size(99, 13)
        Me.lblDisplayCodigoUnidadSAT.TabIndex = 238
        Me.lblDisplayCodigoUnidadSAT.Text = "Clave unidad SAT :"
        '
        'txtCodigoUnidadSAT
        '
        Me.txtCodigoUnidadSAT.Location = New System.Drawing.Point(10, 438)
        Me.txtCodigoUnidadSAT.MaxLength = 10
        Me.txtCodigoUnidadSAT.Name = "txtCodigoUnidadSAT"
        Me.txtCodigoUnidadSAT.Size = New System.Drawing.Size(69, 20)
        Me.txtCodigoUnidadSAT.TabIndex = 15
        '
        'cboGradoToxicidad
        '
        Me.cboGradoToxicidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGradoToxicidad.FormattingEnabled = True
        Me.cboGradoToxicidad.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboGradoToxicidad.Location = New System.Drawing.Point(97, 266)
        Me.cboGradoToxicidad.Name = "cboGradoToxicidad"
        Me.cboGradoToxicidad.Size = New System.Drawing.Size(212, 21)
        Me.cboGradoToxicidad.TabIndex = 6
        '
        'lblDisplayGradoToxicidad
        '
        Me.lblDisplayGradoToxicidad.AutoSize = True
        Me.lblDisplayGradoToxicidad.Location = New System.Drawing.Point(10, 269)
        Me.lblDisplayGradoToxicidad.Name = "lblDisplayGradoToxicidad"
        Me.lblDisplayGradoToxicidad.Size = New System.Drawing.Size(87, 13)
        Me.lblDisplayGradoToxicidad.TabIndex = 141
        Me.lblDisplayGradoToxicidad.Text = "Grado toxicidad :"
        '
        'LblNombreUnidad
        '
        Me.LblNombreUnidad.AutoSize = True
        Me.LblNombreUnidad.Location = New System.Drawing.Point(171, 193)
        Me.LblNombreUnidad.Name = "LblNombreUnidad"
        Me.LblNombreUnidad.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreUnidad.TabIndex = 139
        Me.LblNombreUnidad.Text = "_"
        '
        'chkEsSerializable
        '
        Me.chkEsSerializable.AutoSize = True
        Me.chkEsSerializable.Location = New System.Drawing.Point(222, 218)
        Me.chkEsSerializable.Name = "chkEsSerializable"
        Me.chkEsSerializable.Size = New System.Drawing.Size(132, 17)
        Me.chkEsSerializable.TabIndex = 4
        Me.chkEsSerializable.Text = "Lleva control de series"
        Me.chkEsSerializable.UseVisualStyleBackColor = True
        '
        'chkInventariable
        '
        Me.chkInventariable.AutoSize = True
        Me.chkInventariable.Location = New System.Drawing.Point(97, 218)
        Me.chkInventariable.Name = "chkInventariable"
        Me.chkInventariable.Size = New System.Drawing.Size(87, 17)
        Me.chkInventariable.TabIndex = 3
        Me.chkInventariable.Text = "Inventariable"
        Me.chkInventariable.UseVisualStyleBackColor = True
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.CboFamilia.Location = New System.Drawing.Point(96, 369)
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(212, 21)
        Me.CboFamilia.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 372)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Familia :"
        '
        'LblDisplayCodigoPostalParticular
        '
        Me.LblDisplayCodigoPostalParticular.AutoSize = True
        Me.LblDisplayCodigoPostalParticular.Location = New System.Drawing.Point(10, 399)
        Me.LblDisplayCodigoPostalParticular.Name = "LblDisplayCodigoPostalParticular"
        Me.LblDisplayCodigoPostalParticular.Size = New System.Drawing.Size(43, 13)
        Me.LblDisplayCodigoPostalParticular.TabIndex = 136
        Me.LblDisplayCodigoPostalParticular.Text = "Precio :"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Location = New System.Drawing.Point(96, 396)
        Me.TxtPrecio.MaxLength = 0
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(72, 20)
        Me.TxtPrecio.TabIndex = 13
        Me.TxtPrecio.Text = "0"
        Me.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboLinea
        '
        Me.cboLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLinea.FormattingEnabled = True
        Me.cboLinea.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboLinea.Location = New System.Drawing.Point(96, 341)
        Me.cboLinea.Name = "cboLinea"
        Me.cboLinea.Size = New System.Drawing.Size(212, 21)
        Me.cboLinea.TabIndex = 11
        '
        'lblDisplayCod_Linea
        '
        Me.lblDisplayCod_Linea.AutoSize = True
        Me.lblDisplayCod_Linea.Location = New System.Drawing.Point(10, 344)
        Me.lblDisplayCod_Linea.Name = "lblDisplayCod_Linea"
        Me.lblDisplayCod_Linea.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayCod_Linea.TabIndex = 134
        Me.lblDisplayCod_Linea.Text = "Linea :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(184, 398)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 129
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(236, 396)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(72, 21)
        Me.CboEstatus.TabIndex = 14
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(10, 26)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(74, 13)
        Me.LblDisplayCodArticulo.TabIndex = 127
        Me.LblDisplayCodArticulo.Text = "Cod. artículo :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Location = New System.Drawing.Point(97, 22)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(72, 20)
        Me.TxtCodArticulo.TabIndex = 0
        '
        'LblDisplayUnidadVenta
        '
        Me.LblDisplayUnidadVenta.AutoSize = True
        Me.LblDisplayUnidadVenta.Location = New System.Drawing.Point(10, 193)
        Me.LblDisplayUnidadVenta.Name = "LblDisplayUnidadVenta"
        Me.LblDisplayUnidadVenta.Size = New System.Drawing.Size(77, 13)
        Me.LblDisplayUnidadVenta.TabIndex = 123
        Me.LblDisplayUnidadVenta.Text = "Unidad venta :"
        '
        'TxtUnidadVenta
        '
        Me.TxtUnidadVenta.Location = New System.Drawing.Point(97, 190)
        Me.TxtUnidadVenta.MaxLength = 20
        Me.TxtUnidadVenta.Name = "TxtUnidadVenta"
        Me.TxtUnidadVenta.Size = New System.Drawing.Size(69, 20)
        Me.TxtUnidadVenta.TabIndex = 2
        '
        'LblDisplayDescripcion
        '
        Me.LblDisplayDescripcion.AutoSize = True
        Me.LblDisplayDescripcion.Location = New System.Drawing.Point(10, 51)
        Me.LblDisplayDescripcion.Name = "LblDisplayDescripcion"
        Me.LblDisplayDescripcion.Size = New System.Drawing.Size(69, 13)
        Me.LblDisplayDescripcion.TabIndex = 122
        Me.LblDisplayDescripcion.Text = "Descripción :"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(97, 48)
        Me.TxtDescripcion.MaxLength = 500
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(294, 139)
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
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(411, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(425, 630)
        Me.gBoxBusquedaRapida.TabIndex = 121
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(322, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Estatus :"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(375, 44)
        Me.CboEstatusFiltro.MaxLength = 1
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(43, 21)
        Me.CboEstatusFiltro.TabIndex = 139
        '
        'rbtCodigoArticulo
        '
        Me.rbtCodigoArticulo.AutoSize = True
        Me.rbtCodigoArticulo.Location = New System.Drawing.Point(141, 22)
        Me.rbtCodigoArticulo.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtCodigoArticulo.Name = "rbtCodigoArticulo"
        Me.rbtCodigoArticulo.Size = New System.Drawing.Size(97, 17)
        Me.rbtCodigoArticulo.TabIndex = 115
        Me.rbtCodigoArticulo.Text = "Código artículo"
        Me.rbtCodigoArticulo.UseVisualStyleBackColor = True
        '
        'rbtDescripcion
        '
        Me.rbtDescripcion.AutoSize = True
        Me.rbtDescripcion.Checked = True
        Me.rbtDescripcion.Location = New System.Drawing.Point(5, 22)
        Me.rbtDescripcion.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtDescripcion.Name = "rbtDescripcion"
        Me.rbtDescripcion.Size = New System.Drawing.Size(81, 17)
        Me.rbtDescripcion.TabIndex = 114
        Me.rbtDescripcion.TabStop = True
        Me.rbtDescripcion.Text = "Descripción"
        Me.rbtDescripcion.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(5, 70)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(412, 527)
        Me.Grid.TabIndex = 113
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 46)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(311, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbEliminar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(848, 27)
        Me.tsMenu.TabIndex = 119
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
        'tsbEliminar
        '
        Me.tsbEliminar.Image = CType(resources.GetObject("tsbEliminar.Image"), System.Drawing.Image)
        Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminar.Name = "tsbEliminar"
        Me.tsbEliminar.Size = New System.Drawing.Size(74, 24)
        Me.tsbEliminar.Text = "Eliminar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(77, 24)
        Me.tsbCancelar.Text = "&Cancelar"
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 660)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(848, 22)
        Me.StatusStripEstado.TabIndex = 120
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
        'Catalogo_Articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 682)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(8, 28)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Articulos"
        Me.ShowIcon = False
        Me.Tag = "0022"
        Me.Text = "Catálogo de artículos"
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
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents rbtCodigoArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDescripcion As System.Windows.Forms.RadioButton
    Friend WithEvents chkEsSerializable As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblNombreUnidad As System.Windows.Forms.Label
    Friend WithEvents cboGradoToxicidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayGradoToxicidad As System.Windows.Forms.Label
    Friend WithEvents lblClaveProductoSAT As Label
    Friend WithEvents lblCodigoUnidadSAT As Label
    Friend WithEvents lblDisplayClaveProductoSAT As Label
    Friend WithEvents txtClaveProductoSAT As TextBox
    Friend WithEvents lblDisplayCodigoUnidadSAT As Label
    Friend WithEvents txtCodigoUnidadSAT As TextBox
    Friend WithEvents lblDisplayImpuestoIVA As Label
    Friend WithEvents cboImpuestoIVA As ComboBox
    Friend WithEvents lblClaveProductoSATSimiliar As Label
    Friend WithEvents LblFactorConversion As System.Windows.Forms.Label
    Friend WithEvents txtFactorConversion As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreProducto As System.Windows.Forms.Label
    Friend WithEvents lblCodigoProducto As System.Windows.Forms.Label
    Friend WithEvents txtCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayImpuestoFlete As System.Windows.Forms.Label
    Friend WithEvents cboImpuestoFlete As System.Windows.Forms.ComboBox
    Friend WithEvents cboRetencionISRPorcentaje As ComboBox
    Friend WithEvents chkRetencionISRTiene As CheckBox
    Friend WithEvents cboRetencionIVAPorcentaje As ComboBox
    Friend WithEvents chkRetencionIVATiene As CheckBox
    Friend WithEvents lblDisplayFraccionArancelaria As Label
    Friend WithEvents txtFraccionArancelaria As TextBox
End Class
