<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_CFDI_Ubicaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_CFDI_Ubicaciones))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.cboMunicipio = New System.Windows.Forms.ComboBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.cboPaisDomicilio = New System.Windows.Forms.ComboBox()
        Me.cboPaisResidenciaFiscal = New System.Windows.Forms.ComboBox()
        Me.LblPaisDomicilio = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblMunicipio = New System.Windows.Forms.Label()
        Me.LblNombreLocalidad = New System.Windows.Forms.Label()
        Me.LblNombreColonia = New System.Windows.Forms.Label()
        Me.TxtIdLocalidad = New System.Windows.Forms.TextBox()
        Me.LblIdLocalidad = New System.Windows.Forms.Label()
        Me.TxtIdColonia = New System.Windows.Forms.TextBox()
        Me.LblIdColonia = New System.Windows.Forms.Label()
        Me.TxtNumeroInterior = New System.Windows.Forms.TextBox()
        Me.LblNumeroInterior = New System.Windows.Forms.Label()
        Me.TxtNumeroExterior = New System.Windows.Forms.TextBox()
        Me.LblNumeroExterior = New System.Windows.Forms.Label()
        Me.TxtCalle = New System.Windows.Forms.TextBox()
        Me.LblCalle = New System.Windows.Forms.Label()
        Me.TxtDistanciaRecorrida = New System.Windows.Forms.TextBox()
        Me.LblDistanciaRecorrida = New System.Windows.Forms.Label()
        Me.LblPaisResidenciaFiscal = New System.Windows.Forms.Label()
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero = New System.Windows.Forms.TextBox()
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero = New System.Windows.Forms.Label()
        Me.TxtRfcRemitenteDestinatario = New System.Windows.Forms.TextBox()
        Me.LblRfcRemitenteDestinatario = New System.Windows.Forms.Label()
        Me.TxtNombreRemitenteDestinatario = New System.Windows.Forms.TextBox()
        Me.LblNombreRemitenteDestinatario = New System.Windows.Forms.Label()
        Me.LblTipoUbicacion = New System.Windows.Forms.Label()
        Me.CboTipoUbicacion = New System.Windows.Forms.ComboBox()
        Me.TxtIdUbicacion = New System.Windows.Forms.TextBox()
        Me.LblIdUbicacion = New System.Windows.Forms.Label()
        Me.LblDisplayNombreCliente = New System.Windows.Forms.Label()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.LblCodigoPostal = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCodigoCliente = New System.Windows.Forms.Label()
        Me.TxtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblCodigoUbicacion = New System.Windows.Forms.Label()
        Me.TxtCodigoUbicacion = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gb = New System.Windows.Forms.GroupBox()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(802, 27)
        Me.tsMenu.TabIndex = 24
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
        Me.tsbCancelar.Size = New System.Drawing.Size(77, 24)
        Me.tsbCancelar.Text = "&Cancelar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(489, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(303, 550)
        Me.gBoxBusquedaRapida.TabIndex = 22
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(201, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Estatus :"
        '
        'cboEstatusFiltro
        '
        Me.cboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatusFiltro.FormattingEnabled = True
        Me.cboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(254, 18)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(36, 21)
        Me.cboEstatusFiltro.TabIndex = 92
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(6, 44)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(290, 502)
        Me.Grid.TabIndex = 112
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(190, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 579)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(802, 22)
        Me.StatusStripEstado.TabIndex = 25
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
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.gb)
        Me.gBoxInformacion.Controls.Add(Me.cboPaisResidenciaFiscal)
        Me.gBoxInformacion.Controls.Add(Me.CboTipoUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.TxtDistanciaRecorrida)
        Me.gBoxInformacion.Controls.Add(Me.LblDistanciaRecorrida)
        Me.gBoxInformacion.Controls.Add(Me.LblPaisResidenciaFiscal)
        Me.gBoxInformacion.Controls.Add(Me.TxtNumeroIdentificacionRegistroFiscalExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.LblNumeroIdentificacionResgistroFiscalExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.TxtRfcRemitenteDestinatario)
        Me.gBoxInformacion.Controls.Add(Me.LblRfcRemitenteDestinatario)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreRemitenteDestinatario)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreRemitenteDestinatario)
        Me.gBoxInformacion.Controls.Add(Me.LblTipoUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.TxtIdUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.LblIdUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCliente)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoCliente)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoCliente)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoUbicacion)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(471, 550)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.FormattingEnabled = True
        Me.cboMunicipio.Items.AddRange(New Object() {"A", "B"})
        Me.cboMunicipio.Location = New System.Drawing.Point(90, 190)
        Me.cboMunicipio.MaxLength = 80
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(218, 21)
        Me.cboMunicipio.TabIndex = 133
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstado.Location = New System.Drawing.Point(90, 164)
        Me.cboEstado.MaxLength = 80
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(218, 21)
        Me.cboEstado.TabIndex = 132
        '
        'cboPaisDomicilio
        '
        Me.cboPaisDomicilio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaisDomicilio.FormattingEnabled = True
        Me.cboPaisDomicilio.Items.AddRange(New Object() {"A", "B"})
        Me.cboPaisDomicilio.Location = New System.Drawing.Point(90, 140)
        Me.cboPaisDomicilio.MaxLength = 80
        Me.cboPaisDomicilio.Name = "cboPaisDomicilio"
        Me.cboPaisDomicilio.Size = New System.Drawing.Size(218, 21)
        Me.cboPaisDomicilio.TabIndex = 131
        '
        'cboPaisResidenciaFiscal
        '
        Me.cboPaisResidenciaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaisResidenciaFiscal.FormattingEnabled = True
        Me.cboPaisResidenciaFiscal.Items.AddRange(New Object() {"A", "B"})
        Me.cboPaisResidenciaFiscal.Location = New System.Drawing.Point(125, 222)
        Me.cboPaisResidenciaFiscal.MaxLength = 80
        Me.cboPaisResidenciaFiscal.Name = "cboPaisResidenciaFiscal"
        Me.cboPaisResidenciaFiscal.Size = New System.Drawing.Size(218, 21)
        Me.cboPaisResidenciaFiscal.TabIndex = 130
        '
        'LblPaisDomicilio
        '
        Me.LblPaisDomicilio.AutoSize = True
        Me.LblPaisDomicilio.Location = New System.Drawing.Point(6, 142)
        Me.LblPaisDomicilio.Name = "LblPaisDomicilio"
        Me.LblPaisDomicilio.Size = New System.Drawing.Size(78, 13)
        Me.LblPaisDomicilio.TabIndex = 129
        Me.LblPaisDomicilio.Text = "País domicilio :"
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Location = New System.Drawing.Point(6, 166)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(46, 13)
        Me.LblEstado.TabIndex = 126
        Me.LblEstado.Text = "Estado :"
        '
        'LblMunicipio
        '
        Me.LblMunicipio.AutoSize = True
        Me.LblMunicipio.Location = New System.Drawing.Point(6, 192)
        Me.LblMunicipio.Name = "LblMunicipio"
        Me.LblMunicipio.Size = New System.Drawing.Size(58, 13)
        Me.LblMunicipio.TabIndex = 123
        Me.LblMunicipio.Text = "Municipio :"
        '
        'LblNombreLocalidad
        '
        Me.LblNombreLocalidad.AutoSize = True
        Me.LblNombreLocalidad.Location = New System.Drawing.Point(160, 91)
        Me.LblNombreLocalidad.Name = "LblNombreLocalidad"
        Me.LblNombreLocalidad.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreLocalidad.TabIndex = 121
        Me.LblNombreLocalidad.Text = "_"
        '
        'LblNombreColonia
        '
        Me.LblNombreColonia.AutoSize = True
        Me.LblNombreColonia.Location = New System.Drawing.Point(160, 66)
        Me.LblNombreColonia.Name = "LblNombreColonia"
        Me.LblNombreColonia.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreColonia.TabIndex = 120
        Me.LblNombreColonia.Text = "_"
        '
        'TxtIdLocalidad
        '
        Me.TxtIdLocalidad.Location = New System.Drawing.Point(90, 88)
        Me.TxtIdLocalidad.MaxLength = 50
        Me.TxtIdLocalidad.Name = "TxtIdLocalidad"
        Me.TxtIdLocalidad.Size = New System.Drawing.Size(63, 20)
        Me.TxtIdLocalidad.TabIndex = 118
        '
        'LblIdLocalidad
        '
        Me.LblIdLocalidad.AutoSize = True
        Me.LblIdLocalidad.Location = New System.Drawing.Point(6, 91)
        Me.LblIdLocalidad.Name = "LblIdLocalidad"
        Me.LblIdLocalidad.Size = New System.Drawing.Size(59, 13)
        Me.LblIdLocalidad.TabIndex = 119
        Me.LblIdLocalidad.Text = "Localidad :"
        '
        'TxtIdColonia
        '
        Me.TxtIdColonia.Location = New System.Drawing.Point(90, 64)
        Me.TxtIdColonia.MaxLength = 50
        Me.TxtIdColonia.Name = "TxtIdColonia"
        Me.TxtIdColonia.Size = New System.Drawing.Size(63, 20)
        Me.TxtIdColonia.TabIndex = 116
        '
        'LblIdColonia
        '
        Me.LblIdColonia.AutoSize = True
        Me.LblIdColonia.Location = New System.Drawing.Point(6, 66)
        Me.LblIdColonia.Name = "LblIdColonia"
        Me.LblIdColonia.Size = New System.Drawing.Size(48, 13)
        Me.LblIdColonia.TabIndex = 117
        Me.LblIdColonia.Text = "Colonia :"
        '
        'TxtNumeroInterior
        '
        Me.TxtNumeroInterior.Location = New System.Drawing.Point(327, 38)
        Me.TxtNumeroInterior.MaxLength = 50
        Me.TxtNumeroInterior.Name = "TxtNumeroInterior"
        Me.TxtNumeroInterior.Size = New System.Drawing.Size(122, 20)
        Me.TxtNumeroInterior.TabIndex = 114
        '
        'LblNumeroInterior
        '
        Me.LblNumeroInterior.AutoSize = True
        Me.LblNumeroInterior.Location = New System.Drawing.Point(227, 42)
        Me.LblNumeroInterior.Name = "LblNumeroInterior"
        Me.LblNumeroInterior.Size = New System.Drawing.Size(84, 13)
        Me.LblNumeroInterior.TabIndex = 115
        Me.LblNumeroInterior.Text = "Número interior :"
        '
        'TxtNumeroExterior
        '
        Me.TxtNumeroExterior.Location = New System.Drawing.Point(96, 38)
        Me.TxtNumeroExterior.MaxLength = 50
        Me.TxtNumeroExterior.Name = "TxtNumeroExterior"
        Me.TxtNumeroExterior.Size = New System.Drawing.Size(119, 20)
        Me.TxtNumeroExterior.TabIndex = 112
        '
        'LblNumeroExterior
        '
        Me.LblNumeroExterior.AutoSize = True
        Me.LblNumeroExterior.Location = New System.Drawing.Point(6, 42)
        Me.LblNumeroExterior.Name = "LblNumeroExterior"
        Me.LblNumeroExterior.Size = New System.Drawing.Size(87, 13)
        Me.LblNumeroExterior.TabIndex = 113
        Me.LblNumeroExterior.Text = "Número exterior :"
        '
        'TxtCalle
        '
        Me.TxtCalle.Location = New System.Drawing.Point(48, 13)
        Me.TxtCalle.MaxLength = 100
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(401, 20)
        Me.TxtCalle.TabIndex = 110
        '
        'LblCalle
        '
        Me.LblCalle.AutoSize = True
        Me.LblCalle.Location = New System.Drawing.Point(6, 16)
        Me.LblCalle.Name = "LblCalle"
        Me.LblCalle.Size = New System.Drawing.Size(36, 13)
        Me.LblCalle.TabIndex = 111
        Me.LblCalle.Text = "Calle :"
        '
        'TxtDistanciaRecorrida
        '
        Me.TxtDistanciaRecorrida.Location = New System.Drawing.Point(125, 249)
        Me.TxtDistanciaRecorrida.MaxLength = 50
        Me.TxtDistanciaRecorrida.Name = "TxtDistanciaRecorrida"
        Me.TxtDistanciaRecorrida.Size = New System.Drawing.Size(66, 20)
        Me.TxtDistanciaRecorrida.TabIndex = 108
        '
        'LblDistanciaRecorrida
        '
        Me.LblDistanciaRecorrida.AutoSize = True
        Me.LblDistanciaRecorrida.Location = New System.Drawing.Point(6, 252)
        Me.LblDistanciaRecorrida.Name = "LblDistanciaRecorrida"
        Me.LblDistanciaRecorrida.Size = New System.Drawing.Size(101, 13)
        Me.LblDistanciaRecorrida.TabIndex = 109
        Me.LblDistanciaRecorrida.Text = "Distancia recorrida :"
        '
        'LblPaisResidenciaFiscal
        '
        Me.LblPaisResidenciaFiscal.AutoSize = True
        Me.LblPaisResidenciaFiscal.Location = New System.Drawing.Point(6, 224)
        Me.LblPaisResidenciaFiscal.Name = "LblPaisResidenciaFiscal"
        Me.LblPaisResidenciaFiscal.Size = New System.Drawing.Size(113, 13)
        Me.LblPaisResidenciaFiscal.TabIndex = 107
        Me.LblPaisResidenciaFiscal.Text = "País residencia fiscal :"
        '
        'TxtNumeroIdentificacionRegistroFiscalExtranjero
        '
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Location = New System.Drawing.Point(239, 177)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.MaxLength = 40
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Name = "TxtNumeroIdentificacionRegistroFiscalExtranjero"
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Size = New System.Drawing.Size(124, 20)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.TabIndex = 105
        '
        'LblNumeroIdentificacionResgistroFiscalExtranjero
        '
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.AutoSize = True
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Location = New System.Drawing.Point(6, 180)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Name = "LblNumeroIdentificacionResgistroFiscalExtranjero"
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Size = New System.Drawing.Size(228, 13)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.TabIndex = 104
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Text = "Número identificación registro fiscal extranjero :"
        '
        'TxtRfcRemitenteDestinatario
        '
        Me.TxtRfcRemitenteDestinatario.Location = New System.Drawing.Point(152, 153)
        Me.TxtRfcRemitenteDestinatario.MaxLength = 13
        Me.TxtRfcRemitenteDestinatario.Name = "TxtRfcRemitenteDestinatario"
        Me.TxtRfcRemitenteDestinatario.Size = New System.Drawing.Size(211, 20)
        Me.TxtRfcRemitenteDestinatario.TabIndex = 102
        '
        'LblRfcRemitenteDestinatario
        '
        Me.LblRfcRemitenteDestinatario.AutoSize = True
        Me.LblRfcRemitenteDestinatario.Location = New System.Drawing.Point(6, 155)
        Me.LblRfcRemitenteDestinatario.Name = "LblRfcRemitenteDestinatario"
        Me.LblRfcRemitenteDestinatario.Size = New System.Drawing.Size(137, 13)
        Me.LblRfcRemitenteDestinatario.TabIndex = 103
        Me.LblRfcRemitenteDestinatario.Text = "RFC remitente destinatario :"
        '
        'TxtNombreRemitenteDestinatario
        '
        Me.TxtNombreRemitenteDestinatario.Location = New System.Drawing.Point(6, 128)
        Me.TxtNombreRemitenteDestinatario.MaxLength = 254
        Me.TxtNombreRemitenteDestinatario.Name = "TxtNombreRemitenteDestinatario"
        Me.TxtNombreRemitenteDestinatario.Size = New System.Drawing.Size(458, 20)
        Me.TxtNombreRemitenteDestinatario.TabIndex = 100
        '
        'LblNombreRemitenteDestinatario
        '
        Me.LblNombreRemitenteDestinatario.AutoSize = True
        Me.LblNombreRemitenteDestinatario.Location = New System.Drawing.Point(6, 111)
        Me.LblNombreRemitenteDestinatario.Name = "LblNombreRemitenteDestinatario"
        Me.LblNombreRemitenteDestinatario.Size = New System.Drawing.Size(153, 13)
        Me.LblNombreRemitenteDestinatario.TabIndex = 101
        Me.LblNombreRemitenteDestinatario.Text = "Nombre remitente destinatario :"
        '
        'LblTipoUbicacion
        '
        Me.LblTipoUbicacion.AutoSize = True
        Me.LblTipoUbicacion.Location = New System.Drawing.Point(253, 84)
        Me.LblTipoUbicacion.Name = "LblTipoUbicacion"
        Me.LblTipoUbicacion.Size = New System.Drawing.Size(83, 13)
        Me.LblTipoUbicacion.TabIndex = 99
        Me.LblTipoUbicacion.Text = "Tipo ubicación :"
        '
        'CboTipoUbicacion
        '
        Me.CboTipoUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoUbicacion.FormattingEnabled = True
        Me.CboTipoUbicacion.Items.AddRange(New Object() {"Origen", "Destino"})
        Me.CboTipoUbicacion.Location = New System.Drawing.Point(336, 81)
        Me.CboTipoUbicacion.MaxLength = 1
        Me.CboTipoUbicacion.Name = "CboTipoUbicacion"
        Me.CboTipoUbicacion.Size = New System.Drawing.Size(71, 21)
        Me.CboTipoUbicacion.TabIndex = 98
        '
        'TxtIdUbicacion
        '
        Me.TxtIdUbicacion.Location = New System.Drawing.Point(105, 82)
        Me.TxtIdUbicacion.MaxLength = 8
        Me.TxtIdUbicacion.Name = "TxtIdUbicacion"
        Me.TxtIdUbicacion.Size = New System.Drawing.Size(128, 20)
        Me.TxtIdUbicacion.TabIndex = 96
        '
        'LblIdUbicacion
        '
        Me.LblIdUbicacion.AutoSize = True
        Me.LblIdUbicacion.Location = New System.Drawing.Point(6, 84)
        Me.LblIdUbicacion.Name = "LblIdUbicacion"
        Me.LblIdUbicacion.Size = New System.Drawing.Size(73, 13)
        Me.LblIdUbicacion.TabIndex = 97
        Me.LblIdUbicacion.Text = "ID ubicación :"
        '
        'LblDisplayNombreCliente
        '
        Me.LblDisplayNombreCliente.AutoSize = True
        Me.LblDisplayNombreCliente.Location = New System.Drawing.Point(103, 63)
        Me.LblDisplayNombreCliente.Name = "LblDisplayNombreCliente"
        Me.LblDisplayNombreCliente.Size = New System.Drawing.Size(13, 13)
        Me.LblDisplayNombreCliente.TabIndex = 95
        Me.LblDisplayNombreCliente.Text = "_"
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(90, 215)
        Me.TxtCodigoPostal.MaxLength = 12
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(63, 20)
        Me.TxtCodigoPostal.TabIndex = 3
        '
        'LblCodigoPostal
        '
        Me.LblCodigoPostal.AutoSize = True
        Me.LblCodigoPostal.Location = New System.Drawing.Point(6, 218)
        Me.LblCodigoPostal.Name = "LblCodigoPostal"
        Me.LblCodigoPostal.Size = New System.Drawing.Size(77, 13)
        Me.LblCodigoPostal.TabIndex = 94
        Me.LblCodigoPostal.Text = "Código postal :"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(90, 114)
        Me.TxtReferencia.MaxLength = 250
        Me.TxtReferencia.Multiline = True
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(218, 20)
        Me.TxtReferencia.TabIndex = 2
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Location = New System.Drawing.Point(6, 117)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(65, 13)
        Me.LblReferencia.TabIndex = 92
        Me.LblReferencia.Text = "Referencia :"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'LblCodigoCliente
        '
        Me.LblCodigoCliente.AutoSize = True
        Me.LblCodigoCliente.Location = New System.Drawing.Point(6, 44)
        Me.LblCodigoCliente.Name = "LblCodigoCliente"
        Me.LblCodigoCliente.Size = New System.Drawing.Size(80, 13)
        Me.LblCodigoCliente.TabIndex = 74
        Me.LblCodigoCliente.Text = "Código cliente :"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(105, 41)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(115, 20)
        Me.TxtCodigoCliente.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(6, 529)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(72, 526)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(71, 21)
        Me.CboEstatus.TabIndex = 5
        '
        'LblCodigoUbicacion
        '
        Me.LblCodigoUbicacion.AutoSize = True
        Me.LblCodigoUbicacion.Location = New System.Drawing.Point(6, 18)
        Me.LblCodigoUbicacion.Name = "LblCodigoUbicacion"
        Me.LblCodigoUbicacion.Size = New System.Drawing.Size(95, 13)
        Me.LblCodigoUbicacion.TabIndex = 8
        Me.LblCodigoUbicacion.Text = "Código ubicación :"
        '
        'TxtCodigoUbicacion
        '
        Me.TxtCodigoUbicacion.Location = New System.Drawing.Point(105, 15)
        Me.TxtCodigoUbicacion.MaxLength = 2
        Me.TxtCodigoUbicacion.Name = "TxtCodigoUbicacion"
        Me.TxtCodigoUbicacion.Size = New System.Drawing.Size(86, 20)
        Me.TxtCodigoUbicacion.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'gb
        '
        Me.gb.Controls.Add(Me.TxtNumeroInterior)
        Me.gb.Controls.Add(Me.cboMunicipio)
        Me.gb.Controls.Add(Me.cboEstado)
        Me.gb.Controls.Add(Me.LblNumeroInterior)
        Me.gb.Controls.Add(Me.LblCalle)
        Me.gb.Controls.Add(Me.cboPaisDomicilio)
        Me.gb.Controls.Add(Me.LblReferencia)
        Me.gb.Controls.Add(Me.TxtReferencia)
        Me.gb.Controls.Add(Me.LblPaisDomicilio)
        Me.gb.Controls.Add(Me.LblCodigoPostal)
        Me.gb.Controls.Add(Me.LblEstado)
        Me.gb.Controls.Add(Me.TxtCodigoPostal)
        Me.gb.Controls.Add(Me.LblMunicipio)
        Me.gb.Controls.Add(Me.TxtCalle)
        Me.gb.Controls.Add(Me.LblNombreLocalidad)
        Me.gb.Controls.Add(Me.LblNumeroExterior)
        Me.gb.Controls.Add(Me.LblNombreColonia)
        Me.gb.Controls.Add(Me.TxtNumeroExterior)
        Me.gb.Controls.Add(Me.TxtIdLocalidad)
        Me.gb.Controls.Add(Me.LblIdColonia)
        Me.gb.Controls.Add(Me.LblIdLocalidad)
        Me.gb.Controls.Add(Me.TxtIdColonia)
        Me.gb.Location = New System.Drawing.Point(9, 271)
        Me.gb.Name = "gb"
        Me.gb.Size = New System.Drawing.Size(455, 241)
        Me.gb.TabIndex = 134
        Me.gb.TabStop = False
        Me.gb.Text = "Domicilio"
        '
        'Catalogo_CFDI_Ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 601)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_CFDI_Ubicaciones"
        Me.ShowIcon = False
        Me.Text = "Catálogo ubicaciones"
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
        Me.gb.ResumeLayout(False)
        Me.gb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblCodigoCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblCodigoUbicacion As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents LblNombreLocalidad As System.Windows.Forms.Label
    Friend WithEvents LblNombreColonia As System.Windows.Forms.Label
    Friend WithEvents TxtIdLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents LblIdLocalidad As System.Windows.Forms.Label
    Friend WithEvents TxtIdColonia As System.Windows.Forms.TextBox
    Friend WithEvents LblIdColonia As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroInterior As System.Windows.Forms.TextBox
    Friend WithEvents LblNumeroInterior As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroExterior As System.Windows.Forms.TextBox
    Friend WithEvents LblNumeroExterior As System.Windows.Forms.Label
    Friend WithEvents TxtCalle As System.Windows.Forms.TextBox
    Friend WithEvents LblCalle As System.Windows.Forms.Label
    Friend WithEvents TxtDistanciaRecorrida As System.Windows.Forms.TextBox
    Friend WithEvents LblDistanciaRecorrida As System.Windows.Forms.Label
    Friend WithEvents LblPaisResidenciaFiscal As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroIdentificacionRegistroFiscalExtranjero As System.Windows.Forms.TextBox
    Friend WithEvents LblNumeroIdentificacionResgistroFiscalExtranjero As System.Windows.Forms.Label
    Friend WithEvents TxtRfcRemitenteDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents LblRfcRemitenteDestinatario As System.Windows.Forms.Label
    Friend WithEvents TxtNombreRemitenteDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreRemitenteDestinatario As System.Windows.Forms.Label
    Friend WithEvents LblTipoUbicacion As System.Windows.Forms.Label
    Friend WithEvents CboTipoUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents TxtIdUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents LblIdUbicacion As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreCliente As System.Windows.Forms.Label
    Friend WithEvents LblPaisDomicilio As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboPaisDomicilio As System.Windows.Forms.ComboBox
    Friend WithEvents cboPaisResidenciaFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents gb As GroupBox
End Class
