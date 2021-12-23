<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Compras_Global
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Compras_Global))
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbDescuentos = New System.Windows.Forms.RadioButton()
        Me.RbDevoluciones = New System.Windows.Forms.RadioButton()
        Me.RbListadoDocumentos = New System.Windows.Forms.RadioButton()
        Me.RbAgrupadoFamilia = New System.Windows.Forms.RadioButton()
        Me.RbGlobal = New System.Windows.Forms.RadioButton()
        Me.RbTotalizadoProveedor = New System.Windows.Forms.RadioButton()
        Me.RbTotalizadoProducto = New System.Windows.Forms.RadioButton()
        Me.chkMostrarSoloDocumentosSaldoMayorCero = New System.Windows.Forms.CheckBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.LblAlmacen = New System.Windows.Forms.Label()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.TxtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboEsFiscal = New System.Windows.Forms.ComboBox()
        Me.lblDisplayEsFiscal = New System.Windows.Forms.Label()
        Me.LblDisplayLinea = New System.Windows.Forms.Label()
        Me.cboLineas = New System.Windows.Forms.ComboBox()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.LblMoneda = New System.Windows.Forms.Label()
        Me.cboInventariables = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.CboFamilia = New System.Windows.Forms.ComboBox()
        Me.lblDisplayFamilia = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.lblinventariables = New System.Windows.Forms.Label()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(109, 50)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(280, 22)
        Me.DtFechaHasta.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 57)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 17)
        Me.Label8.TabIndex = 300
        Me.Label8.Text = "Hasta :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(109, 18)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(280, 22)
        Me.DtFechaDesde.TabIndex = 0
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.Location = New System.Drawing.Point(8, 26)
        Me.LblDesde.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(57, 17)
        Me.LblDesde.TabIndex = 299
        Me.LblDesde.Text = "Desde :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbDescuentos)
        Me.GroupBox1.Controls.Add(Me.RbDevoluciones)
        Me.GroupBox1.Controls.Add(Me.RbListadoDocumentos)
        Me.GroupBox1.Controls.Add(Me.RbAgrupadoFamilia)
        Me.GroupBox1.Controls.Add(Me.RbGlobal)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(205, 182)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'RbDescuentos
        '
        Me.RbDescuentos.AutoSize = True
        Me.RbDescuentos.Location = New System.Drawing.Point(8, 140)
        Me.RbDescuentos.Margin = New System.Windows.Forms.Padding(4)
        Me.RbDescuentos.Name = "RbDescuentos"
        Me.RbDescuentos.Size = New System.Drawing.Size(104, 21)
        Me.RbDescuentos.TabIndex = 5
        Me.RbDescuentos.Text = "Descuentos"
        Me.RbDescuentos.UseVisualStyleBackColor = True
        '
        'RbDevoluciones
        '
        Me.RbDevoluciones.AutoSize = True
        Me.RbDevoluciones.Location = New System.Drawing.Point(8, 111)
        Me.RbDevoluciones.Margin = New System.Windows.Forms.Padding(4)
        Me.RbDevoluciones.Name = "RbDevoluciones"
        Me.RbDevoluciones.Size = New System.Drawing.Size(114, 21)
        Me.RbDevoluciones.TabIndex = 4
        Me.RbDevoluciones.Text = "Devoluciones"
        Me.RbDevoluciones.UseVisualStyleBackColor = True
        '
        'RbListadoDocumentos
        '
        Me.RbListadoDocumentos.AutoSize = True
        Me.RbListadoDocumentos.Location = New System.Drawing.Point(8, 82)
        Me.RbListadoDocumentos.Margin = New System.Windows.Forms.Padding(4)
        Me.RbListadoDocumentos.Name = "RbListadoDocumentos"
        Me.RbListadoDocumentos.Size = New System.Drawing.Size(176, 21)
        Me.RbListadoDocumentos.TabIndex = 3
        Me.RbListadoDocumentos.Text = "Listado de documentos"
        Me.RbListadoDocumentos.UseVisualStyleBackColor = True
        '
        'RbAgrupadoFamilia
        '
        Me.RbAgrupadoFamilia.AutoSize = True
        Me.RbAgrupadoFamilia.Location = New System.Drawing.Point(8, 52)
        Me.RbAgrupadoFamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.RbAgrupadoFamilia.Name = "RbAgrupadoFamilia"
        Me.RbAgrupadoFamilia.Size = New System.Drawing.Size(160, 21)
        Me.RbAgrupadoFamilia.TabIndex = 1
        Me.RbAgrupadoFamilia.Text = "Agrupado por familia"
        Me.RbAgrupadoFamilia.UseVisualStyleBackColor = True
        '
        'RbGlobal
        '
        Me.RbGlobal.AutoSize = True
        Me.RbGlobal.Checked = True
        Me.RbGlobal.Location = New System.Drawing.Point(8, 23)
        Me.RbGlobal.Margin = New System.Windows.Forms.Padding(4)
        Me.RbGlobal.Name = "RbGlobal"
        Me.RbGlobal.Size = New System.Drawing.Size(84, 21)
        Me.RbGlobal.TabIndex = 0
        Me.RbGlobal.TabStop = True
        Me.RbGlobal.Text = "A detalle"
        Me.RbGlobal.UseVisualStyleBackColor = True
        '
        'RbTotalizadoProveedor
        '
        Me.RbTotalizadoProveedor.AutoSize = True
        Me.RbTotalizadoProveedor.Location = New System.Drawing.Point(17, 315)
        Me.RbTotalizadoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.RbTotalizadoProveedor.Name = "RbTotalizadoProveedor"
        Me.RbTotalizadoProveedor.Size = New System.Drawing.Size(189, 21)
        Me.RbTotalizadoProveedor.TabIndex = 3
        Me.RbTotalizadoProveedor.Text = "Totalizado por proveedor"
        Me.RbTotalizadoProveedor.UseVisualStyleBackColor = True
        Me.RbTotalizadoProveedor.Visible = False
        '
        'RbTotalizadoProducto
        '
        Me.RbTotalizadoProducto.AutoSize = True
        Me.RbTotalizadoProducto.Location = New System.Drawing.Point(16, 281)
        Me.RbTotalizadoProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.RbTotalizadoProducto.Name = "RbTotalizadoProducto"
        Me.RbTotalizadoProducto.Size = New System.Drawing.Size(180, 21)
        Me.RbTotalizadoProducto.TabIndex = 2
        Me.RbTotalizadoProducto.Text = "Totalizado por producto"
        Me.RbTotalizadoProducto.UseVisualStyleBackColor = True
        Me.RbTotalizadoProducto.Visible = False
        '
        'chkMostrarSoloDocumentosSaldoMayorCero
        '
        Me.chkMostrarSoloDocumentosSaldoMayorCero.AutoSize = True
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Location = New System.Drawing.Point(109, 82)
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Margin = New System.Windows.Forms.Padding(4)
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Name = "chkMostrarSoloDocumentosSaldoMayorCero"
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Size = New System.Drawing.Size(278, 21)
        Me.chkMostrarSoloDocumentosSaldoMayorCero.TabIndex = 2
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Text = "Mostrar solo documentos con saldo > 0"
        Me.chkMostrarSoloDocumentosSaldoMayorCero.UseVisualStyleBackColor = True
        '
        'lblProveedor
        '
        Me.lblProveedor.Location = New System.Drawing.Point(105, 142)
        Me.lblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(369, 16)
        Me.lblProveedor.TabIndex = 305
        Me.lblProveedor.Text = "_"
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(109, 113)
        Me.txtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoProveedor.MaxLength = 8
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(95, 22)
        Me.txtCodigoProveedor.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 117)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 304
        Me.Label1.Text = "Proveedor :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(109, 161)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(280, 24)
        Me.CboAlmacen.TabIndex = 4
        '
        'LblAlmacen
        '
        Me.LblAlmacen.AutoSize = True
        Me.LblAlmacen.Location = New System.Drawing.Point(8, 165)
        Me.LblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAlmacen.Name = "LblAlmacen"
        Me.LblAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.LblAlmacen.TabIndex = 307
        Me.LblAlmacen.Text = "Almacén :"
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(8, 198)
        Me.LblDisplayCodArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayCodArticulo.TabIndex = 309
        Me.LblDisplayCodArticulo.Text = "Artículo :"
        '
        'TxtCodigoArticulo
        '
        Me.TxtCodigoArticulo.Location = New System.Drawing.Point(109, 194)
        Me.TxtCodigoArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoArticulo.MaxLength = 16
        Me.TxtCodigoArticulo.Name = "TxtCodigoArticulo"
        Me.TxtCodigoArticulo.Size = New System.Drawing.Size(280, 22)
        Me.TxtCodigoArticulo.TabIndex = 5
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(105, 223)
        Me.lblArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(369, 16)
        Me.lblArticulo.TabIndex = 310
        Me.lblArticulo.Text = "_"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEsFiscal)
        Me.GroupBox2.Controls.Add(Me.lblDisplayEsFiscal)
        Me.GroupBox2.Controls.Add(Me.LblDisplayLinea)
        Me.GroupBox2.Controls.Add(Me.cboLineas)
        Me.GroupBox2.Controls.Add(Me.cboMoneda)
        Me.GroupBox2.Controls.Add(Me.LblMoneda)
        Me.GroupBox2.Controls.Add(Me.cboInventariables)
        Me.GroupBox2.Controls.Add(Me.LblDocumento)
        Me.GroupBox2.Controls.Add(Me.CboFamilia)
        Me.GroupBox2.Controls.Add(Me.LblDesde)
        Me.GroupBox2.Controls.Add(Me.lblDisplayFamilia)
        Me.GroupBox2.Controls.Add(Me.lblArticulo)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Controls.Add(Me.LblEstatus)
        Me.GroupBox2.Controls.Add(Me.LblDisplayCodArticulo)
        Me.GroupBox2.Controls.Add(Me.CboEstatus)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.CboDocumento)
        Me.GroupBox2.Controls.Add(Me.lblinventariables)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoArticulo)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.CboAlmacen)
        Me.GroupBox2.Controls.Add(Me.chkMostrarSoloDocumentosSaldoMayorCero)
        Me.GroupBox2.Controls.Add(Me.LblAlmacen)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblProveedor)
        Me.GroupBox2.Controls.Add(Me.txtCodigoProveedor)
        Me.GroupBox2.Location = New System.Drawing.Point(216, 34)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(484, 473)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'cboEsFiscal
        '
        Me.cboEsFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEsFiscal.FormattingEnabled = True
        Me.cboEsFiscal.Location = New System.Drawing.Point(109, 439)
        Me.cboEsFiscal.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEsFiscal.Name = "cboEsFiscal"
        Me.cboEsFiscal.Size = New System.Drawing.Size(280, 24)
        Me.cboEsFiscal.TabIndex = 12
        '
        'lblDisplayEsFiscal
        '
        Me.lblDisplayEsFiscal.AutoSize = True
        Me.lblDisplayEsFiscal.Location = New System.Drawing.Point(8, 442)
        Me.lblDisplayEsFiscal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEsFiscal.Name = "lblDisplayEsFiscal"
        Me.lblDisplayEsFiscal.Size = New System.Drawing.Size(72, 17)
        Me.lblDisplayEsFiscal.TabIndex = 318
        Me.lblDisplayEsFiscal.Text = "Es Fiscal :"
        '
        'LblDisplayLinea
        '
        Me.LblDisplayLinea.AutoSize = True
        Me.LblDisplayLinea.Location = New System.Drawing.Point(8, 377)
        Me.LblDisplayLinea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayLinea.Name = "LblDisplayLinea"
        Me.LblDisplayLinea.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayLinea.TabIndex = 316
        Me.LblDisplayLinea.Text = "Línea :"
        '
        'cboLineas
        '
        Me.cboLineas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineas.FormattingEnabled = True
        Me.cboLineas.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboLineas.Location = New System.Drawing.Point(109, 374)
        Me.cboLineas.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLineas.Name = "cboLineas"
        Me.cboLineas.Size = New System.Drawing.Size(280, 24)
        Me.cboLineas.TabIndex = 10
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(109, 309)
        Me.cboMoneda.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(280, 24)
        Me.cboMoneda.TabIndex = 8
        '
        'LblMoneda
        '
        Me.LblMoneda.AutoSize = True
        Me.LblMoneda.Location = New System.Drawing.Point(8, 313)
        Me.LblMoneda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(67, 17)
        Me.LblMoneda.TabIndex = 314
        Me.LblMoneda.Text = "Moneda :"
        '
        'cboInventariables
        '
        Me.cboInventariables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInventariables.FormattingEnabled = True
        Me.cboInventariables.Location = New System.Drawing.Point(109, 242)
        Me.cboInventariables.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInventariables.Name = "cboInventariables"
        Me.cboInventariables.Size = New System.Drawing.Size(280, 24)
        Me.cboInventariables.TabIndex = 6
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(8, 279)
        Me.LblDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(88, 17)
        Me.LblDocumento.TabIndex = 312
        Me.LblDocumento.Text = "Documento :"
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.CboFamilia.Location = New System.Drawing.Point(109, 406)
        Me.CboFamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(280, 24)
        Me.CboFamilia.TabIndex = 11
        '
        'lblDisplayFamilia
        '
        Me.lblDisplayFamilia.AutoSize = True
        Me.lblDisplayFamilia.Location = New System.Drawing.Point(8, 409)
        Me.lblDisplayFamilia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFamilia.Name = "lblDisplayFamilia"
        Me.lblDisplayFamilia.Size = New System.Drawing.Size(60, 17)
        Me.lblDisplayFamilia.TabIndex = 288
        Me.lblDisplayFamilia.Text = "Familia :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(8, 346)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 286
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"APLICADO", "CANCELADO", "GRABADO", "RECEPCIONADO PARCIAL", "TODOS"})
        Me.CboEstatus.Location = New System.Drawing.Point(109, 342)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(280, 24)
        Me.CboEstatus.TabIndex = 9
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(109, 276)
        Me.CboDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(280, 24)
        Me.CboDocumento.TabIndex = 7
        '
        'lblinventariables
        '
        Me.lblinventariables.AutoSize = True
        Me.lblinventariables.Location = New System.Drawing.Point(8, 246)
        Me.lblinventariables.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblinventariables.Name = "lblinventariables"
        Me.lblinventariables.Size = New System.Drawing.Size(64, 17)
        Me.lblinventariables.TabIndex = 279
        Me.lblinventariables.Text = "Del tipo :"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(95, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(707, 27)
        Me.ToolStrip1.TabIndex = 312
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Rpt_Compras_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 514)
        Me.Controls.Add(Me.RbTotalizadoProducto)
        Me.Controls.Add(Me.RbTotalizadoProveedor)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Compras_Global"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras - Global de documentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDesde As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbTotalizadoProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents RbTotalizadoProducto As System.Windows.Forms.RadioButton
    Friend WithEvents RbAgrupadoFamilia As System.Windows.Forms.RadioButton
    Friend WithEvents RbGlobal As System.Windows.Forms.RadioButton
    Friend WithEvents chkMostrarSoloDocumentosSaldoMayorCero As System.Windows.Forms.CheckBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents txtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents LblAlmacen As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents lblinventariables As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents CboFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayFamilia As System.Windows.Forms.Label
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents LblMoneda As System.Windows.Forms.Label
    Friend WithEvents cboInventariables As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents RbListadoDocumentos As System.Windows.Forms.RadioButton
    Friend WithEvents cboLineas As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayLinea As System.Windows.Forms.Label
    Friend WithEvents cboEsFiscal As ComboBox
    Friend WithEvents lblDisplayEsFiscal As Label
    Friend WithEvents RbDescuentos As System.Windows.Forms.RadioButton
    Friend WithEvents RbDevoluciones As System.Windows.Forms.RadioButton
End Class
