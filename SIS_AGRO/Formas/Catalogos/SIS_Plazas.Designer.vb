<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SIS_Plazas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SIS_Plazas))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.TxtIdentificador = New System.Windows.Forms.TextBox()
        Me.LblIdentificador = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNombreConcepto = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblEstatusPlaza = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gBoxDomicilio = New System.Windows.Forms.GroupBox()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.LblTelefono = New System.Windows.Forms.Label()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.TxtLocalidad = New System.Windows.Forms.TextBox()
        Me.TxtCodLocalidad = New System.Windows.Forms.TextBox()
        Me.TxtColonia = New System.Windows.Forms.TextBox()
        Me.TxtCodColonia = New System.Windows.Forms.TextBox()
        Me.LblCodPostal = New System.Windows.Forms.Label()
        Me.LblLocalidad = New System.Windows.Forms.Label()
        Me.LblCodLocalidad = New System.Windows.Forms.Label()
        Me.LblColonia = New System.Windows.Forms.Label()
        Me.LblCodColonia = New System.Windows.Forms.Label()
        Me.TxtInterior = New System.Windows.Forms.TextBox()
        Me.TxtExterior = New System.Windows.Forms.TextBox()
        Me.LblInterior = New System.Windows.Forms.Label()
        Me.LblExterior = New System.Windows.Forms.Label()
        Me.LblCallle = New System.Windows.Forms.Label()
        Me.TxtCalle = New System.Windows.Forms.TextBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.cboCiudad = New System.Windows.Forms.ComboBox()
        Me.cboPais = New System.Windows.Forms.ComboBox()
        Me.LblPais = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblCiudad = New System.Windows.Forms.Label()
        Me.gBoxVentas = New System.Windows.Forms.GroupBox()
        Me.LblImpuesto = New System.Windows.Forms.Label()
        Me.TxtImpuestoPorcentaje = New System.Windows.Forms.TextBox()
        Me.TxtCodigoClienteNacional = New System.Windows.Forms.TextBox()
        Me.TxtCodigoClienteExportacion = New System.Windows.Forms.TextBox()
        Me.LblCodigoClienteNacional = New System.Windows.Forms.Label()
        Me.LblCodigoClienteExportacion = New System.Windows.Forms.Label()
        Me.TxtIdTemporadaProduccion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckbValidarFechaVentas = New System.Windows.Forms.CheckBox()
        Me.TxtPlazoVentaContado = New System.Windows.Forms.TextBox()
        Me.LblPlazoVentaContado = New System.Windows.Forms.Label()
        Me.TxtCtaContadoNacional = New System.Windows.Forms.TextBox()
        Me.TxtCtaContadoExportacion = New System.Windows.Forms.TextBox()
        Me.TxtCtaContableMayorNacional = New System.Windows.Forms.TextBox()
        Me.TxtCtaContableMayorExportacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCuentaContableVentas = New System.Windows.Forms.TextBox()
        Me.LblCuentaContableVentas = New System.Windows.Forms.Label()
        Me.gBoxZona = New System.Windows.Forms.GroupBox()
        Me.LblNombreZona = New System.Windows.Forms.Label()
        Me.TxtCodigoZona = New System.Windows.Forms.TextBox()
        Me.LblCodigoZona = New System.Windows.Forms.Label()
        Me.dtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.gBoxEjercicio = New System.Windows.Forms.GroupBox()
        Me.CboEjercicios = New System.Windows.Forms.ComboBox()
        Me.LblFechaFin = New System.Windows.Forms.Label()
        Me.LblFechaInicio = New System.Windows.Forms.Label()
        Me.gBoxCuentasContables = New System.Windows.Forms.GroupBox()
        Me.txtCuentaRebajas = New System.Windows.Forms.TextBox()
        Me.TxtCuentaProveedor = New System.Windows.Forms.TextBox()
        Me.LblCtaDescuentos = New System.Windows.Forms.Label()
        Me.LblCtaContableProveedor = New System.Windows.Forms.Label()
        Me.gBoxInventarios = New System.Windows.Forms.GroupBox()
        Me.TxtCodigoPuntoPago = New System.Windows.Forms.TextBox()
        Me.TxtCodigoLotePlanta = New System.Windows.Forms.TextBox()
        Me.TxtCodigoLoteEmbarque = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblLotePlanta = New System.Windows.Forms.Label()
        Me.LblLoteEmpaque = New System.Windows.Forms.Label()
        Me.LblNombreAlmacen = New System.Windows.Forms.Label()
        Me.LblProveedor = New System.Windows.Forms.Label()
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.TxtCodigoAlmacen = New System.Windows.Forms.TextBox()
        Me.LblAlmacen = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxDomicilio.SuspendLayout()
        Me.gBoxVentas.SuspendLayout()
        Me.gBoxZona.SuspendLayout()
        Me.gBoxEjercicio.SuspendLayout()
        Me.gBoxCuentasContables.SuspendLayout()
        Me.gBoxInventarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1414, 27)
        Me.tsMenu.TabIndex = 28
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
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(948, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(453, 715)
        Me.gBoxBusquedaRapida.TabIndex = 26
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 91)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(437, 616)
        Me.Grid.TabIndex = 111
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 24)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(437, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 761)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1414, 25)
        Me.StatusStripEstado.TabIndex = 29
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
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.TxtIdentificador)
        Me.gBoxInformacion.Controls.Add(Me.LblIdentificador)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreConcepto)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombre)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatusPlaza)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigo)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigo)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(468, 165)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'TxtIdentificador
        '
        Me.TxtIdentificador.Location = New System.Drawing.Point(114, 88)
        Me.TxtIdentificador.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdentificador.MaxLength = 3
        Me.TxtIdentificador.Name = "TxtIdentificador"
        Me.TxtIdentificador.Size = New System.Drawing.Size(96, 22)
        Me.TxtIdentificador.TabIndex = 2
        '
        'LblIdentificador
        '
        Me.LblIdentificador.AutoSize = True
        Me.LblIdentificador.Location = New System.Drawing.Point(8, 91)
        Me.LblIdentificador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdentificador.Name = "LblIdentificador"
        Me.LblIdentificador.Size = New System.Drawing.Size(98, 17)
        Me.LblIdentificador.TabIndex = 92
        Me.LblIdentificador.Text = "Identeficador :"
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
        'LblNombreConcepto
        '
        Me.LblNombreConcepto.AutoSize = True
        Me.LblNombreConcepto.Location = New System.Drawing.Point(8, 54)
        Me.LblNombreConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreConcepto.Name = "LblNombreConcepto"
        Me.LblNombreConcepto.Size = New System.Drawing.Size(66, 17)
        Me.LblNombreConcepto.TabIndex = 74
        Me.LblNombreConcepto.Text = "Nombre :"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(114, 51)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(294, 22)
        Me.TxtNombre.TabIndex = 1
        '
        'LblEstatusPlaza
        '
        Me.LblEstatusPlaza.AutoSize = True
        Me.LblEstatusPlaza.Location = New System.Drawing.Point(8, 125)
        Me.LblEstatusPlaza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatusPlaza.Name = "LblEstatusPlaza"
        Me.LblEstatusPlaza.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatusPlaza.TabIndex = 22
        Me.LblEstatusPlaza.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(114, 122)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(96, 24)
        Me.CboEstatus.TabIndex = 3
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(8, 22)
        Me.LblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(60, 17)
        Me.LblCodigo.TabIndex = 8
        Me.LblCodigo.Text = "Código :"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(114, 19)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigo.MaxLength = 2
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodigo.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'gBoxDomicilio
        '
        Me.gBoxDomicilio.Controls.Add(Me.TxtTelefono)
        Me.gBoxDomicilio.Controls.Add(Me.LblTelefono)
        Me.gBoxDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.gBoxDomicilio.Controls.Add(Me.TxtLocalidad)
        Me.gBoxDomicilio.Controls.Add(Me.TxtCodLocalidad)
        Me.gBoxDomicilio.Controls.Add(Me.TxtColonia)
        Me.gBoxDomicilio.Controls.Add(Me.TxtCodColonia)
        Me.gBoxDomicilio.Controls.Add(Me.LblCodPostal)
        Me.gBoxDomicilio.Controls.Add(Me.LblLocalidad)
        Me.gBoxDomicilio.Controls.Add(Me.LblCodLocalidad)
        Me.gBoxDomicilio.Controls.Add(Me.LblColonia)
        Me.gBoxDomicilio.Controls.Add(Me.LblCodColonia)
        Me.gBoxDomicilio.Controls.Add(Me.TxtInterior)
        Me.gBoxDomicilio.Controls.Add(Me.TxtExterior)
        Me.gBoxDomicilio.Controls.Add(Me.LblInterior)
        Me.gBoxDomicilio.Controls.Add(Me.LblExterior)
        Me.gBoxDomicilio.Controls.Add(Me.LblCallle)
        Me.gBoxDomicilio.Controls.Add(Me.TxtCalle)
        Me.gBoxDomicilio.Controls.Add(Me.cboEstado)
        Me.gBoxDomicilio.Controls.Add(Me.cboCiudad)
        Me.gBoxDomicilio.Controls.Add(Me.cboPais)
        Me.gBoxDomicilio.Controls.Add(Me.LblPais)
        Me.gBoxDomicilio.Controls.Add(Me.LblEstado)
        Me.gBoxDomicilio.Controls.Add(Me.LblCiudad)
        Me.gBoxDomicilio.Location = New System.Drawing.Point(16, 207)
        Me.gBoxDomicilio.Name = "gBoxDomicilio"
        Me.gBoxDomicilio.Size = New System.Drawing.Size(468, 420)
        Me.gBoxDomicilio.TabIndex = 1
        Me.gBoxDomicilio.TabStop = False
        Me.gBoxDomicilio.Text = "Domicilio :"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(125, 351)
        Me.TxtTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTelefono.MaxLength = 20
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(96, 22)
        Me.TxtTelefono.TabIndex = 11
        '
        'LblTelefono
        '
        Me.LblTelefono.AutoSize = True
        Me.LblTelefono.Location = New System.Drawing.Point(8, 354)
        Me.LblTelefono.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTelefono.Name = "LblTelefono"
        Me.LblTelefono.Size = New System.Drawing.Size(72, 17)
        Me.LblTelefono.TabIndex = 110
        Me.LblTelefono.Text = "Telefono :"
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(125, 321)
        Me.TxtCodigoPostal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoPostal.MaxLength = 20
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodigoPostal.TabIndex = 10
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(125, 287)
        Me.TxtLocalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLocalidad.MaxLength = 50
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(283, 22)
        Me.TxtLocalidad.TabIndex = 9
        '
        'TxtCodLocalidad
        '
        Me.TxtCodLocalidad.Location = New System.Drawing.Point(125, 257)
        Me.TxtCodLocalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodLocalidad.MaxLength = 50
        Me.TxtCodLocalidad.Name = "TxtCodLocalidad"
        Me.TxtCodLocalidad.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodLocalidad.TabIndex = 8
        '
        'TxtColonia
        '
        Me.TxtColonia.Location = New System.Drawing.Point(125, 227)
        Me.TxtColonia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtColonia.MaxLength = 50
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(283, 22)
        Me.TxtColonia.TabIndex = 7
        '
        'TxtCodColonia
        '
        Me.TxtCodColonia.Location = New System.Drawing.Point(125, 193)
        Me.TxtCodColonia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodColonia.MaxLength = 50
        Me.TxtCodColonia.Name = "TxtCodColonia"
        Me.TxtCodColonia.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodColonia.TabIndex = 6
        '
        'LblCodPostal
        '
        Me.LblCodPostal.AutoSize = True
        Me.LblCodPostal.Location = New System.Drawing.Point(8, 326)
        Me.LblCodPostal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodPostal.Name = "LblCodPostal"
        Me.LblCodPostal.Size = New System.Drawing.Size(102, 17)
        Me.LblCodPostal.TabIndex = 104
        Me.LblCodPostal.Text = "Código postal :"
        '
        'LblLocalidad
        '
        Me.LblLocalidad.AutoSize = True
        Me.LblLocalidad.Location = New System.Drawing.Point(8, 290)
        Me.LblLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLocalidad.Name = "LblLocalidad"
        Me.LblLocalidad.Size = New System.Drawing.Size(77, 17)
        Me.LblLocalidad.TabIndex = 103
        Me.LblLocalidad.Text = "Localidad :"
        '
        'LblCodLocalidad
        '
        Me.LblCodLocalidad.AutoSize = True
        Me.LblCodLocalidad.Location = New System.Drawing.Point(7, 260)
        Me.LblCodLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodLocalidad.Name = "LblCodLocalidad"
        Me.LblCodLocalidad.Size = New System.Drawing.Size(120, 17)
        Me.LblCodLocalidad.TabIndex = 102
        Me.LblCodLocalidad.Text = "Código localidad :"
        '
        'LblColonia
        '
        Me.LblColonia.AutoSize = True
        Me.LblColonia.Location = New System.Drawing.Point(8, 230)
        Me.LblColonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblColonia.Name = "LblColonia"
        Me.LblColonia.Size = New System.Drawing.Size(63, 17)
        Me.LblColonia.TabIndex = 101
        Me.LblColonia.Text = "Colonia :"
        '
        'LblCodColonia
        '
        Me.LblCodColonia.AutoSize = True
        Me.LblCodColonia.Location = New System.Drawing.Point(7, 196)
        Me.LblCodColonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodColonia.Name = "LblCodColonia"
        Me.LblCodColonia.Size = New System.Drawing.Size(109, 17)
        Me.LblCodColonia.TabIndex = 100
        Me.LblCodColonia.Text = "Codigo colonia :"
        '
        'TxtInterior
        '
        Me.TxtInterior.Location = New System.Drawing.Point(325, 158)
        Me.TxtInterior.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtInterior.MaxLength = 10
        Me.TxtInterior.Name = "TxtInterior"
        Me.TxtInterior.Size = New System.Drawing.Size(121, 22)
        Me.TxtInterior.TabIndex = 5
        '
        'TxtExterior
        '
        Me.TxtExterior.Location = New System.Drawing.Point(92, 158)
        Me.TxtExterior.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtExterior.MaxLength = 10
        Me.TxtExterior.Name = "TxtExterior"
        Me.TxtExterior.Size = New System.Drawing.Size(96, 22)
        Me.TxtExterior.TabIndex = 4
        '
        'LblInterior
        '
        Me.LblInterior.AutoSize = True
        Me.LblInterior.Location = New System.Drawing.Point(245, 161)
        Me.LblInterior.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblInterior.Name = "LblInterior"
        Me.LblInterior.Size = New System.Drawing.Size(72, 17)
        Me.LblInterior.TabIndex = 97
        Me.LblInterior.Text = "# Interior :"
        '
        'LblExterior
        '
        Me.LblExterior.AutoSize = True
        Me.LblExterior.Location = New System.Drawing.Point(8, 161)
        Me.LblExterior.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblExterior.Name = "LblExterior"
        Me.LblExterior.Size = New System.Drawing.Size(76, 17)
        Me.LblExterior.TabIndex = 96
        Me.LblExterior.Text = "# Exterior :"
        '
        'LblCallle
        '
        Me.LblCallle.AutoSize = True
        Me.LblCallle.Location = New System.Drawing.Point(8, 128)
        Me.LblCallle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCallle.Name = "LblCallle"
        Me.LblCallle.Size = New System.Drawing.Size(47, 17)
        Me.LblCallle.TabIndex = 95
        Me.LblCallle.Text = "Calle :"
        '
        'TxtCalle
        '
        Me.TxtCalle.Location = New System.Drawing.Point(92, 128)
        Me.TxtCalle.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCalle.MaxLength = 50
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(354, 22)
        Me.TxtCalle.TabIndex = 3
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(92, 57)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(354, 24)
        Me.cboEstado.TabIndex = 1
        '
        'cboCiudad
        '
        Me.cboCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCiudad.FormattingEnabled = True
        Me.cboCiudad.Location = New System.Drawing.Point(92, 87)
        Me.cboCiudad.Name = "cboCiudad"
        Me.cboCiudad.Size = New System.Drawing.Size(354, 24)
        Me.cboCiudad.TabIndex = 2
        '
        'cboPais
        '
        Me.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPais.FormattingEnabled = True
        Me.cboPais.Location = New System.Drawing.Point(92, 27)
        Me.cboPais.Name = "cboPais"
        Me.cboPais.Size = New System.Drawing.Size(354, 24)
        Me.cboPais.TabIndex = 0
        '
        'LblPais
        '
        Me.LblPais.AutoSize = True
        Me.LblPais.Location = New System.Drawing.Point(8, 30)
        Me.LblPais.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPais.Name = "LblPais"
        Me.LblPais.Size = New System.Drawing.Size(43, 17)
        Me.LblPais.TabIndex = 25
        Me.LblPais.Text = "País :"
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Location = New System.Drawing.Point(7, 60)
        Me.LblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(60, 17)
        Me.LblEstado.TabIndex = 24
        Me.LblEstado.Text = "Estado :"
        '
        'LblCiudad
        '
        Me.LblCiudad.AutoSize = True
        Me.LblCiudad.Location = New System.Drawing.Point(7, 90)
        Me.LblCiudad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCiudad.Name = "LblCiudad"
        Me.LblCiudad.Size = New System.Drawing.Size(60, 17)
        Me.LblCiudad.TabIndex = 23
        Me.LblCiudad.Text = "Ciudad :"
        '
        'gBoxVentas
        '
        Me.gBoxVentas.Controls.Add(Me.LblImpuesto)
        Me.gBoxVentas.Controls.Add(Me.TxtImpuestoPorcentaje)
        Me.gBoxVentas.Controls.Add(Me.TxtCodigoClienteNacional)
        Me.gBoxVentas.Controls.Add(Me.TxtCodigoClienteExportacion)
        Me.gBoxVentas.Controls.Add(Me.LblCodigoClienteNacional)
        Me.gBoxVentas.Controls.Add(Me.LblCodigoClienteExportacion)
        Me.gBoxVentas.Controls.Add(Me.TxtIdTemporadaProduccion)
        Me.gBoxVentas.Controls.Add(Me.Label1)
        Me.gBoxVentas.Controls.Add(Me.ckbValidarFechaVentas)
        Me.gBoxVentas.Controls.Add(Me.TxtPlazoVentaContado)
        Me.gBoxVentas.Controls.Add(Me.LblPlazoVentaContado)
        Me.gBoxVentas.Location = New System.Drawing.Point(490, 267)
        Me.gBoxVentas.Name = "gBoxVentas"
        Me.gBoxVentas.Size = New System.Drawing.Size(451, 212)
        Me.gBoxVentas.TabIndex = 4
        Me.gBoxVentas.TabStop = False
        Me.gBoxVentas.Text = "Ventas :"
        '
        'LblImpuesto
        '
        Me.LblImpuesto.AutoSize = True
        Me.LblImpuesto.Location = New System.Drawing.Point(8, 35)
        Me.LblImpuesto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblImpuesto.Name = "LblImpuesto"
        Me.LblImpuesto.Size = New System.Drawing.Size(89, 17)
        Me.LblImpuesto.TabIndex = 105
        Me.LblImpuesto.Text = "% impuesto :"
        '
        'TxtImpuestoPorcentaje
        '
        Me.TxtImpuestoPorcentaje.Location = New System.Drawing.Point(237, 32)
        Me.TxtImpuestoPorcentaje.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtImpuestoPorcentaje.MaxLength = 10
        Me.TxtImpuestoPorcentaje.Name = "TxtImpuestoPorcentaje"
        Me.TxtImpuestoPorcentaje.Size = New System.Drawing.Size(86, 22)
        Me.TxtImpuestoPorcentaje.TabIndex = 0
        '
        'TxtCodigoClienteNacional
        '
        Me.TxtCodigoClienteNacional.Location = New System.Drawing.Point(237, 183)
        Me.TxtCodigoClienteNacional.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoClienteNacional.MaxLength = 10
        Me.TxtCodigoClienteNacional.Name = "TxtCodigoClienteNacional"
        Me.TxtCodigoClienteNacional.Size = New System.Drawing.Size(86, 22)
        Me.TxtCodigoClienteNacional.TabIndex = 5
        '
        'TxtCodigoClienteExportacion
        '
        Me.TxtCodigoClienteExportacion.Location = New System.Drawing.Point(237, 153)
        Me.TxtCodigoClienteExportacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoClienteExportacion.MaxLength = 10
        Me.TxtCodigoClienteExportacion.Name = "TxtCodigoClienteExportacion"
        Me.TxtCodigoClienteExportacion.Size = New System.Drawing.Size(86, 22)
        Me.TxtCodigoClienteExportacion.TabIndex = 4
        '
        'LblCodigoClienteNacional
        '
        Me.LblCodigoClienteNacional.AutoSize = True
        Me.LblCodigoClienteNacional.Location = New System.Drawing.Point(8, 186)
        Me.LblCodigoClienteNacional.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoClienteNacional.Name = "LblCodigoClienteNacional"
        Me.LblCodigoClienteNacional.Size = New System.Drawing.Size(149, 17)
        Me.LblCodigoClienteNacional.TabIndex = 101
        Me.LblCodigoClienteNacional.Text = "Cod. Cliente nacional :"
        '
        'LblCodigoClienteExportacion
        '
        Me.LblCodigoClienteExportacion.AutoSize = True
        Me.LblCodigoClienteExportacion.Location = New System.Drawing.Point(8, 156)
        Me.LblCodigoClienteExportacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoClienteExportacion.Name = "LblCodigoClienteExportacion"
        Me.LblCodigoClienteExportacion.Size = New System.Drawing.Size(189, 17)
        Me.LblCodigoClienteExportacion.TabIndex = 100
        Me.LblCodigoClienteExportacion.Text = "Cod. Cliente de exportación :"
        '
        'TxtIdTemporadaProduccion
        '
        Me.TxtIdTemporadaProduccion.Location = New System.Drawing.Point(237, 123)
        Me.TxtIdTemporadaProduccion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdTemporadaProduccion.MaxLength = 5
        Me.TxtIdTemporadaProduccion.Name = "TxtIdTemporadaProduccion"
        Me.TxtIdTemporadaProduccion.Size = New System.Drawing.Size(86, 22)
        Me.TxtIdTemporadaProduccion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 126)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 17)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Id temporada producción :"
        '
        'ckbValidarFechaVentas
        '
        Me.ckbValidarFechaVentas.AutoSize = True
        Me.ckbValidarFechaVentas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckbValidarFechaVentas.Location = New System.Drawing.Point(10, 94)
        Me.ckbValidarFechaVentas.Name = "ckbValidarFechaVentas"
        Me.ckbValidarFechaVentas.Size = New System.Drawing.Size(187, 21)
        Me.ckbValidarFechaVentas.TabIndex = 2
        Me.ckbValidarFechaVentas.Text = "Validar fecha de ventas :"
        Me.ckbValidarFechaVentas.UseVisualStyleBackColor = True
        '
        'TxtPlazoVentaContado
        '
        Me.TxtPlazoVentaContado.Location = New System.Drawing.Point(237, 62)
        Me.TxtPlazoVentaContado.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPlazoVentaContado.MaxLength = 5
        Me.TxtPlazoVentaContado.Name = "TxtPlazoVentaContado"
        Me.TxtPlazoVentaContado.Size = New System.Drawing.Size(86, 22)
        Me.TxtPlazoVentaContado.TabIndex = 1
        '
        'LblPlazoVentaContado
        '
        Me.LblPlazoVentaContado.AutoSize = True
        Me.LblPlazoVentaContado.Location = New System.Drawing.Point(7, 65)
        Me.LblPlazoVentaContado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPlazoVentaContado.Name = "LblPlazoVentaContado"
        Me.LblPlazoVentaContado.Size = New System.Drawing.Size(165, 17)
        Me.LblPlazoVentaContado.TabIndex = 95
        Me.LblPlazoVentaContado.Text = "Plazo venta de contado :"
        '
        'TxtCtaContadoNacional
        '
        Me.TxtCtaContadoNacional.Location = New System.Drawing.Point(266, 139)
        Me.TxtCtaContadoNacional.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCtaContadoNacional.MaxLength = 20
        Me.TxtCtaContadoNacional.Name = "TxtCtaContadoNacional"
        Me.TxtCtaContadoNacional.Size = New System.Drawing.Size(178, 22)
        Me.TxtCtaContadoNacional.TabIndex = 4
        '
        'TxtCtaContadoExportacion
        '
        Me.TxtCtaContadoExportacion.Location = New System.Drawing.Point(266, 109)
        Me.TxtCtaContadoExportacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCtaContadoExportacion.MaxLength = 20
        Me.TxtCtaContadoExportacion.Name = "TxtCtaContadoExportacion"
        Me.TxtCtaContadoExportacion.Size = New System.Drawing.Size(178, 22)
        Me.TxtCtaContadoExportacion.TabIndex = 3
        '
        'TxtCtaContableMayorNacional
        '
        Me.TxtCtaContableMayorNacional.Location = New System.Drawing.Point(266, 79)
        Me.TxtCtaContableMayorNacional.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCtaContableMayorNacional.MaxLength = 20
        Me.TxtCtaContableMayorNacional.Name = "TxtCtaContableMayorNacional"
        Me.TxtCtaContableMayorNacional.Size = New System.Drawing.Size(178, 22)
        Me.TxtCtaContableMayorNacional.TabIndex = 2
        '
        'TxtCtaContableMayorExportacion
        '
        Me.TxtCtaContableMayorExportacion.Location = New System.Drawing.Point(266, 49)
        Me.TxtCtaContableMayorExportacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCtaContableMayorExportacion.MaxLength = 20
        Me.TxtCtaContableMayorExportacion.Name = "TxtCtaContableMayorExportacion"
        Me.TxtCtaContableMayorExportacion.Size = New System.Drawing.Size(178, 22)
        Me.TxtCtaContableMayorExportacion.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 142)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(231, 17)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Cuenta contable contado nacional :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 112)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(251, 17)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Cuenta contable contado exportación :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 82)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(219, 17)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Cuenta contable mayor nacional :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(239, 17)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Cuenta contable mayor exportación :"
        '
        'TxtCuentaContableVentas
        '
        Me.TxtCuentaContableVentas.Location = New System.Drawing.Point(266, 19)
        Me.TxtCuentaContableVentas.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCuentaContableVentas.MaxLength = 20
        Me.TxtCuentaContableVentas.Name = "TxtCuentaContableVentas"
        Me.TxtCuentaContableVentas.Size = New System.Drawing.Size(178, 22)
        Me.TxtCuentaContableVentas.TabIndex = 0
        '
        'LblCuentaContableVentas
        '
        Me.LblCuentaContableVentas.AutoSize = True
        Me.LblCuentaContableVentas.Location = New System.Drawing.Point(7, 22)
        Me.LblCuentaContableVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuentaContableVentas.Name = "LblCuentaContableVentas"
        Me.LblCuentaContableVentas.Size = New System.Drawing.Size(165, 17)
        Me.LblCuentaContableVentas.TabIndex = 23
        Me.LblCuentaContableVentas.Text = "Cuenta contable ventas :"
        '
        'gBoxZona
        '
        Me.gBoxZona.Controls.Add(Me.LblNombreZona)
        Me.gBoxZona.Controls.Add(Me.TxtCodigoZona)
        Me.gBoxZona.Controls.Add(Me.LblCodigoZona)
        Me.gBoxZona.Location = New System.Drawing.Point(490, 485)
        Me.gBoxZona.Name = "gBoxZona"
        Me.gBoxZona.Size = New System.Drawing.Size(451, 57)
        Me.gBoxZona.TabIndex = 5
        Me.gBoxZona.TabStop = False
        Me.gBoxZona.Text = "Zona :"
        '
        'LblNombreZona
        '
        Me.LblNombreZona.AutoSize = True
        Me.LblNombreZona.Location = New System.Drawing.Point(262, 28)
        Me.LblNombreZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreZona.Name = "LblNombreZona"
        Me.LblNombreZona.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreZona.TabIndex = 113
        Me.LblNombreZona.Text = "_"
        '
        'TxtCodigoZona
        '
        Me.TxtCodigoZona.Location = New System.Drawing.Point(168, 25)
        Me.TxtCodigoZona.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoZona.MaxLength = 5
        Me.TxtCodigoZona.Name = "TxtCodigoZona"
        Me.TxtCodigoZona.Size = New System.Drawing.Size(86, 22)
        Me.TxtCodigoZona.TabIndex = 0
        '
        'LblCodigoZona
        '
        Me.LblCodigoZona.AutoSize = True
        Me.LblCodigoZona.Location = New System.Drawing.Point(8, 28)
        Me.LblCodigoZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoZona.Name = "LblCodigoZona"
        Me.LblCodigoZona.Size = New System.Drawing.Size(152, 17)
        Me.LblCodigoZona.TabIndex = 96
        Me.LblCodigoZona.Text = "Código zona principal :"
        '
        'dtFechaInicio
        '
        Me.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicio.Location = New System.Drawing.Point(58, 63)
        Me.dtFechaInicio.Name = "dtFechaInicio"
        Me.dtFechaInicio.Size = New System.Drawing.Size(95, 22)
        Me.dtFechaInicio.TabIndex = 1
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFinal.Location = New System.Drawing.Point(249, 63)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Size = New System.Drawing.Size(95, 22)
        Me.dtFechaFinal.TabIndex = 2
        '
        'gBoxEjercicio
        '
        Me.gBoxEjercicio.Controls.Add(Me.CboEjercicios)
        Me.gBoxEjercicio.Controls.Add(Me.LblFechaFin)
        Me.gBoxEjercicio.Controls.Add(Me.LblFechaInicio)
        Me.gBoxEjercicio.Controls.Add(Me.dtFechaFinal)
        Me.gBoxEjercicio.Controls.Add(Me.dtFechaInicio)
        Me.gBoxEjercicio.Location = New System.Drawing.Point(16, 633)
        Me.gBoxEjercicio.Name = "gBoxEjercicio"
        Me.gBoxEjercicio.Size = New System.Drawing.Size(451, 116)
        Me.gBoxEjercicio.TabIndex = 2
        Me.gBoxEjercicio.TabStop = False
        Me.gBoxEjercicio.Text = "Ejercicio contable"
        '
        'CboEjercicios
        '
        Me.CboEjercicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEjercicios.FormattingEnabled = True
        Me.CboEjercicios.Location = New System.Drawing.Point(11, 26)
        Me.CboEjercicios.Name = "CboEjercicios"
        Me.CboEjercicios.Size = New System.Drawing.Size(147, 24)
        Me.CboEjercicios.TabIndex = 0
        '
        'LblFechaFin
        '
        Me.LblFechaFin.AutoSize = True
        Me.LblFechaFin.Location = New System.Drawing.Point(196, 68)
        Me.LblFechaFin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFechaFin.Name = "LblFechaFin"
        Me.LblFechaFin.Size = New System.Drawing.Size(46, 17)
        Me.LblFechaFin.TabIndex = 118
        Me.LblFechaFin.Text = "Final :"
        '
        'LblFechaInicio
        '
        Me.LblFechaInicio.AutoSize = True
        Me.LblFechaInicio.Location = New System.Drawing.Point(8, 68)
        Me.LblFechaInicio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFechaInicio.Name = "LblFechaInicio"
        Me.LblFechaInicio.Size = New System.Drawing.Size(48, 17)
        Me.LblFechaInicio.TabIndex = 117
        Me.LblFechaInicio.Text = "Inicio :"
        '
        'gBoxCuentasContables
        '
        Me.gBoxCuentasContables.Controls.Add(Me.txtCuentaRebajas)
        Me.gBoxCuentasContables.Controls.Add(Me.TxtCuentaProveedor)
        Me.gBoxCuentasContables.Controls.Add(Me.LblCtaDescuentos)
        Me.gBoxCuentasContables.Controls.Add(Me.LblCtaContableProveedor)
        Me.gBoxCuentasContables.Controls.Add(Me.TxtCtaContadoNacional)
        Me.gBoxCuentasContables.Controls.Add(Me.TxtCuentaContableVentas)
        Me.gBoxCuentasContables.Controls.Add(Me.TxtCtaContadoExportacion)
        Me.gBoxCuentasContables.Controls.Add(Me.LblCuentaContableVentas)
        Me.gBoxCuentasContables.Controls.Add(Me.TxtCtaContableMayorNacional)
        Me.gBoxCuentasContables.Controls.Add(Me.Label3)
        Me.gBoxCuentasContables.Controls.Add(Me.TxtCtaContableMayorExportacion)
        Me.gBoxCuentasContables.Controls.Add(Me.Label4)
        Me.gBoxCuentasContables.Controls.Add(Me.Label6)
        Me.gBoxCuentasContables.Controls.Add(Me.Label5)
        Me.gBoxCuentasContables.Location = New System.Drawing.Point(490, 34)
        Me.gBoxCuentasContables.Name = "gBoxCuentasContables"
        Me.gBoxCuentasContables.Size = New System.Drawing.Size(451, 237)
        Me.gBoxCuentasContables.TabIndex = 3
        Me.gBoxCuentasContables.TabStop = False
        Me.gBoxCuentasContables.Text = "Cuentas contables :"
        '
        'txtCuentaRebajas
        '
        Me.txtCuentaRebajas.Location = New System.Drawing.Point(265, 199)
        Me.txtCuentaRebajas.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaRebajas.MaxLength = 20
        Me.txtCuentaRebajas.Name = "txtCuentaRebajas"
        Me.txtCuentaRebajas.Size = New System.Drawing.Size(178, 22)
        Me.txtCuentaRebajas.TabIndex = 6
        '
        'TxtCuentaProveedor
        '
        Me.TxtCuentaProveedor.Location = New System.Drawing.Point(266, 169)
        Me.TxtCuentaProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCuentaProveedor.MaxLength = 20
        Me.TxtCuentaProveedor.Name = "TxtCuentaProveedor"
        Me.TxtCuentaProveedor.Size = New System.Drawing.Size(178, 22)
        Me.TxtCuentaProveedor.TabIndex = 5
        '
        'LblCtaDescuentos
        '
        Me.LblCtaDescuentos.AutoSize = True
        Me.LblCtaDescuentos.Location = New System.Drawing.Point(7, 202)
        Me.LblCtaDescuentos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCtaDescuentos.Name = "LblCtaDescuentos"
        Me.LblCtaDescuentos.Size = New System.Drawing.Size(261, 17)
        Me.LblCtaDescuentos.TabIndex = 113
        Me.LblCtaDescuentos.Text = "Cuenta descuentos rebajas nacionales :"
        '
        'LblCtaContableProveedor
        '
        Me.LblCtaContableProveedor.AutoSize = True
        Me.LblCtaContableProveedor.Location = New System.Drawing.Point(7, 172)
        Me.LblCtaContableProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCtaContableProveedor.Name = "LblCtaContableProveedor"
        Me.LblCtaContableProveedor.Size = New System.Drawing.Size(188, 17)
        Me.LblCtaContableProveedor.TabIndex = 112
        Me.LblCtaContableProveedor.Text = "Cuenta contable proveedor :"
        '
        'gBoxInventarios
        '
        Me.gBoxInventarios.Controls.Add(Me.TxtCodigoPuntoPago)
        Me.gBoxInventarios.Controls.Add(Me.TxtCodigoLotePlanta)
        Me.gBoxInventarios.Controls.Add(Me.TxtCodigoLoteEmbarque)
        Me.gBoxInventarios.Controls.Add(Me.Label9)
        Me.gBoxInventarios.Controls.Add(Me.LblLotePlanta)
        Me.gBoxInventarios.Controls.Add(Me.LblLoteEmpaque)
        Me.gBoxInventarios.Controls.Add(Me.LblNombreAlmacen)
        Me.gBoxInventarios.Controls.Add(Me.LblProveedor)
        Me.gBoxInventarios.Controls.Add(Me.TxtCodigoProveedor)
        Me.gBoxInventarios.Controls.Add(Me.TxtCodigoAlmacen)
        Me.gBoxInventarios.Controls.Add(Me.LblAlmacen)
        Me.gBoxInventarios.Location = New System.Drawing.Point(490, 548)
        Me.gBoxInventarios.Name = "gBoxInventarios"
        Me.gBoxInventarios.Size = New System.Drawing.Size(451, 201)
        Me.gBoxInventarios.TabIndex = 6
        Me.gBoxInventarios.TabStop = False
        Me.gBoxInventarios.Text = "Inventarios"
        '
        'TxtCodigoPuntoPago
        '
        Me.TxtCodigoPuntoPago.Location = New System.Drawing.Point(214, 173)
        Me.TxtCodigoPuntoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoPuntoPago.MaxLength = 10
        Me.TxtCodigoPuntoPago.Name = "TxtCodigoPuntoPago"
        Me.TxtCodigoPuntoPago.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoPuntoPago.TabIndex = 4
        '
        'TxtCodigoLotePlanta
        '
        Me.TxtCodigoLotePlanta.Location = New System.Drawing.Point(214, 143)
        Me.TxtCodigoLotePlanta.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoLotePlanta.MaxLength = 10
        Me.TxtCodigoLotePlanta.Name = "TxtCodigoLotePlanta"
        Me.TxtCodigoLotePlanta.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoLotePlanta.TabIndex = 3
        '
        'TxtCodigoLoteEmbarque
        '
        Me.TxtCodigoLoteEmbarque.Location = New System.Drawing.Point(214, 113)
        Me.TxtCodigoLoteEmbarque.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoLoteEmbarque.MaxLength = 10
        Me.TxtCodigoLoteEmbarque.Name = "TxtCodigoLoteEmbarque"
        Me.TxtCodigoLoteEmbarque.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoLoteEmbarque.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 176)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(199, 17)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "Código punto pago empaque :"
        '
        'LblLotePlanta
        '
        Me.LblLotePlanta.AutoSize = True
        Me.LblLotePlanta.Location = New System.Drawing.Point(7, 146)
        Me.LblLotePlanta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLotePlanta.Name = "LblLotePlanta"
        Me.LblLotePlanta.Size = New System.Drawing.Size(130, 17)
        Me.LblLotePlanta.TabIndex = 102
        Me.LblLotePlanta.Text = "Código lote planta :"
        '
        'LblLoteEmpaque
        '
        Me.LblLoteEmpaque.AutoSize = True
        Me.LblLoteEmpaque.Location = New System.Drawing.Point(7, 116)
        Me.LblLoteEmpaque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLoteEmpaque.Name = "LblLoteEmpaque"
        Me.LblLoteEmpaque.Size = New System.Drawing.Size(150, 17)
        Me.LblLoteEmpaque.TabIndex = 101
        Me.LblLoteEmpaque.Text = "Código lote empaque :"
        '
        'LblNombreAlmacen
        '
        Me.LblNombreAlmacen.AutoSize = True
        Me.LblNombreAlmacen.Location = New System.Drawing.Point(211, 50)
        Me.LblNombreAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreAlmacen.Name = "LblNombreAlmacen"
        Me.LblNombreAlmacen.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreAlmacen.TabIndex = 100
        Me.LblNombreAlmacen.Text = "_"
        '
        'LblProveedor
        '
        Me.LblProveedor.AutoSize = True
        Me.LblProveedor.Location = New System.Drawing.Point(8, 86)
        Me.LblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(129, 17)
        Me.LblProveedor.TabIndex = 99
        Me.LblProveedor.Text = "Código proveedor :"
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(214, 83)
        Me.TxtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoProveedor.MaxLength = 10
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoProveedor.TabIndex = 1
        '
        'TxtCodigoAlmacen
        '
        Me.TxtCodigoAlmacen.Location = New System.Drawing.Point(214, 24)
        Me.TxtCodigoAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoAlmacen.MaxLength = 5
        Me.TxtCodigoAlmacen.Name = "TxtCodigoAlmacen"
        Me.TxtCodigoAlmacen.Size = New System.Drawing.Size(109, 22)
        Me.TxtCodigoAlmacen.TabIndex = 0
        '
        'LblAlmacen
        '
        Me.LblAlmacen.AutoSize = True
        Me.LblAlmacen.Location = New System.Drawing.Point(7, 27)
        Me.LblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAlmacen.Name = "LblAlmacen"
        Me.LblAlmacen.Size = New System.Drawing.Size(174, 17)
        Me.LblAlmacen.TabIndex = 96
        Me.LblAlmacen.Text = "Código almacen principal :"
        '
        'SIS_Plazas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1414, 786)
        Me.Controls.Add(Me.gBoxInventarios)
        Me.Controls.Add(Me.gBoxZona)
        Me.Controls.Add(Me.gBoxEjercicio)
        Me.Controls.Add(Me.gBoxCuentasContables)
        Me.Controls.Add(Me.gBoxVentas)
        Me.Controls.Add(Me.gBoxDomicilio)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "SIS_Plazas"
        Me.ShowIcon = False
        Me.Text = "Plazas"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxDomicilio.ResumeLayout(False)
        Me.gBoxDomicilio.PerformLayout()
        Me.gBoxVentas.ResumeLayout(False)
        Me.gBoxVentas.PerformLayout()
        Me.gBoxZona.ResumeLayout(False)
        Me.gBoxZona.PerformLayout()
        Me.gBoxEjercicio.ResumeLayout(False)
        Me.gBoxEjercicio.PerformLayout()
        Me.gBoxCuentasContables.ResumeLayout(False)
        Me.gBoxCuentasContables.PerformLayout()
        Me.gBoxInventarios.ResumeLayout(False)
        Me.gBoxInventarios.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblNombreConcepto As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatusPlaza As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents TxtIdentificador As System.Windows.Forms.TextBox
    Friend WithEvents LblIdentificador As System.Windows.Forms.Label
    Friend WithEvents gBoxDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cboCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents cboPais As System.Windows.Forms.ComboBox
    Friend WithEvents LblPais As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblCiudad As System.Windows.Forms.Label
    Friend WithEvents LblCallle As System.Windows.Forms.Label
    Friend WithEvents TxtCalle As System.Windows.Forms.TextBox
    Friend WithEvents TxtInterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtExterior As System.Windows.Forms.TextBox
    Friend WithEvents LblInterior As System.Windows.Forms.Label
    Friend WithEvents LblExterior As System.Windows.Forms.Label
    Friend WithEvents LblCodColonia As System.Windows.Forms.Label
    Friend WithEvents LblColonia As System.Windows.Forms.Label
    Friend WithEvents LblLocalidad As System.Windows.Forms.Label
    Friend WithEvents LblCodLocalidad As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtColonia As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodColonia As System.Windows.Forms.TextBox
    Friend WithEvents LblCodPostal As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents LblTelefono As System.Windows.Forms.Label
    Friend WithEvents gBoxVentas As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCtaContadoNacional As System.Windows.Forms.TextBox
    Friend WithEvents TxtCtaContadoExportacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtCtaContableMayorNacional As System.Windows.Forms.TextBox
    Friend WithEvents TxtCtaContableMayorExportacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoClienteNacional As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoClienteExportacion As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoClienteNacional As System.Windows.Forms.Label
    Friend WithEvents LblCodigoClienteExportacion As System.Windows.Forms.Label
    Friend WithEvents TxtIdTemporadaProduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckbValidarFechaVentas As System.Windows.Forms.CheckBox
    Friend WithEvents TxtPlazoVentaContado As System.Windows.Forms.TextBox
    Friend WithEvents LblPlazoVentaContado As System.Windows.Forms.Label
    Friend WithEvents TxtCuentaContableVentas As System.Windows.Forms.TextBox
    Friend WithEvents LblCuentaContableVentas As System.Windows.Forms.Label
    Friend WithEvents gBoxEjercicio As System.Windows.Forms.GroupBox
    Friend WithEvents LblFechaFin As System.Windows.Forms.Label
    Friend WithEvents LblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents dtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents gBoxZona As System.Windows.Forms.GroupBox
    Friend WithEvents LblNombreZona As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoZona As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoZona As System.Windows.Forms.Label
    Friend WithEvents gBoxInventarios As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoPuntoPago As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoLotePlanta As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoLoteEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblLotePlanta As System.Windows.Forms.Label
    Friend WithEvents LblLoteEmpaque As System.Windows.Forms.Label
    Friend WithEvents LblNombreAlmacen As System.Windows.Forms.Label
    Friend WithEvents LblProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents LblAlmacen As System.Windows.Forms.Label
    Friend WithEvents gBoxCuentasContables As System.Windows.Forms.GroupBox
    Friend WithEvents txtCuentaRebajas As System.Windows.Forms.TextBox
    Friend WithEvents TxtCuentaProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LblCtaDescuentos As System.Windows.Forms.Label
    Friend WithEvents LblCtaContableProveedor As System.Windows.Forms.Label
    Friend WithEvents LblImpuesto As System.Windows.Forms.Label
    Friend WithEvents TxtImpuestoPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents CboEjercicios As System.Windows.Forms.ComboBox
End Class
