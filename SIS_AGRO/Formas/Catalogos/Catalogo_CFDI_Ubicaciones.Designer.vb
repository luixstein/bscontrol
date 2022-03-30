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
        Me.cboPaisResidenciaFiscal = New System.Windows.Forms.ComboBox()
        Me.cboPaisDomicilio = New System.Windows.Forms.ComboBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.cboMunicipio = New System.Windows.Forms.ComboBox()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1069, 27)
        Me.tsMenu.TabIndex = 24
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
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(652, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(404, 677)
        Me.gBoxBusquedaRapida.TabIndex = 22
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(268, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Estatus :"
        '
        'cboEstatusFiltro
        '
        Me.cboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatusFiltro.FormattingEnabled = True
        Me.cboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(339, 22)
        Me.cboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(47, 24)
        Me.cboEstatusFiltro.TabIndex = 92
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 54)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(386, 618)
        Me.Grid.TabIndex = 112
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(252, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 715)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1069, 25)
        Me.StatusStripEstado.TabIndex = 25
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
        Me.gBoxInformacion.Controls.Add(Me.cboMunicipio)
        Me.gBoxInformacion.Controls.Add(Me.cboEstado)
        Me.gBoxInformacion.Controls.Add(Me.cboPaisDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.cboPaisResidenciaFiscal)
        Me.gBoxInformacion.Controls.Add(Me.LblPaisDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.LblEstado)
        Me.gBoxInformacion.Controls.Add(Me.LblMunicipio)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreLocalidad)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreColonia)
        Me.gBoxInformacion.Controls.Add(Me.TxtIdLocalidad)
        Me.gBoxInformacion.Controls.Add(Me.LblIdLocalidad)
        Me.gBoxInformacion.Controls.Add(Me.TxtIdColonia)
        Me.gBoxInformacion.Controls.Add(Me.LblIdColonia)
        Me.gBoxInformacion.Controls.Add(Me.TxtNumeroInterior)
        Me.gBoxInformacion.Controls.Add(Me.LblNumeroInterior)
        Me.gBoxInformacion.Controls.Add(Me.TxtNumeroExterior)
        Me.gBoxInformacion.Controls.Add(Me.LblNumeroExterior)
        Me.gBoxInformacion.Controls.Add(Me.TxtCalle)
        Me.gBoxInformacion.Controls.Add(Me.LblCalle)
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
        Me.gBoxInformacion.Controls.Add(Me.CboTipoUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.TxtIdUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.LblIdUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCliente)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoPostal)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoPostal)
        Me.gBoxInformacion.Controls.Add(Me.TxtReferencia)
        Me.gBoxInformacion.Controls.Add(Me.LblReferencia)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoCliente)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoCliente)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoUbicacion)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoUbicacion)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(628, 677)
        Me.gBoxInformacion.TabIndex = 23
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'LblPaisDomicilio
        '
        Me.LblPaisDomicilio.AutoSize = True
        Me.LblPaisDomicilio.Location = New System.Drawing.Point(11, 512)
        Me.LblPaisDomicilio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPaisDomicilio.Name = "LblPaisDomicilio"
        Me.LblPaisDomicilio.Size = New System.Drawing.Size(101, 17)
        Me.LblPaisDomicilio.TabIndex = 129
        Me.LblPaisDomicilio.Text = "País domicilio :"
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Location = New System.Drawing.Point(12, 542)
        Me.LblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(60, 17)
        Me.LblEstado.TabIndex = 126
        Me.LblEstado.Text = "Estado :"
        '
        'LblMunicipio
        '
        Me.LblMunicipio.AutoSize = True
        Me.LblMunicipio.Location = New System.Drawing.Point(11, 574)
        Me.LblMunicipio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMunicipio.Name = "LblMunicipio"
        Me.LblMunicipio.Size = New System.Drawing.Size(75, 17)
        Me.LblMunicipio.TabIndex = 123
        Me.LblMunicipio.Text = "Municipio :"
        '
        'LblNombreLocalidad
        '
        Me.LblNombreLocalidad.AutoSize = True
        Me.LblNombreLocalidad.Location = New System.Drawing.Point(199, 422)
        Me.LblNombreLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreLocalidad.Name = "LblNombreLocalidad"
        Me.LblNombreLocalidad.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreLocalidad.TabIndex = 121
        Me.LblNombreLocalidad.Text = "_"
        '
        'LblNombreColonia
        '
        Me.LblNombreColonia.AutoSize = True
        Me.LblNombreColonia.Location = New System.Drawing.Point(199, 392)
        Me.LblNombreColonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreColonia.Name = "LblNombreColonia"
        Me.LblNombreColonia.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreColonia.TabIndex = 120
        Me.LblNombreColonia.Text = "_"
        '
        'TxtIdLocalidad
        '
        Me.TxtIdLocalidad.Location = New System.Drawing.Point(106, 419)
        Me.TxtIdLocalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdLocalidad.MaxLength = 50
        Me.TxtIdLocalidad.Name = "TxtIdLocalidad"
        Me.TxtIdLocalidad.Size = New System.Drawing.Size(83, 22)
        Me.TxtIdLocalidad.TabIndex = 118
        '
        'LblIdLocalidad
        '
        Me.LblIdLocalidad.AutoSize = True
        Me.LblIdLocalidad.Location = New System.Drawing.Point(11, 422)
        Me.LblIdLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdLocalidad.Name = "LblIdLocalidad"
        Me.LblIdLocalidad.Size = New System.Drawing.Size(89, 17)
        Me.LblIdLocalidad.TabIndex = 119
        Me.LblIdLocalidad.Text = "ID localidad :"
        '
        'TxtIdColonia
        '
        Me.TxtIdColonia.Location = New System.Drawing.Point(106, 389)
        Me.TxtIdColonia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdColonia.MaxLength = 50
        Me.TxtIdColonia.Name = "TxtIdColonia"
        Me.TxtIdColonia.Size = New System.Drawing.Size(83, 22)
        Me.TxtIdColonia.TabIndex = 116
        '
        'LblIdColonia
        '
        Me.LblIdColonia.AutoSize = True
        Me.LblIdColonia.Location = New System.Drawing.Point(11, 392)
        Me.LblIdColonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdColonia.Name = "LblIdColonia"
        Me.LblIdColonia.Size = New System.Drawing.Size(78, 17)
        Me.LblIdColonia.TabIndex = 117
        Me.LblIdColonia.Text = "ID colonia :"
        '
        'TxtNumeroInterior
        '
        Me.TxtNumeroInterior.Location = New System.Drawing.Point(436, 359)
        Me.TxtNumeroInterior.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumeroInterior.MaxLength = 50
        Me.TxtNumeroInterior.Name = "TxtNumeroInterior"
        Me.TxtNumeroInterior.Size = New System.Drawing.Size(161, 22)
        Me.TxtNumeroInterior.TabIndex = 114
        '
        'LblNumeroInterior
        '
        Me.LblNumeroInterior.AutoSize = True
        Me.LblNumeroInterior.Location = New System.Drawing.Point(314, 362)
        Me.LblNumeroInterior.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumeroInterior.Name = "LblNumeroInterior"
        Me.LblNumeroInterior.Size = New System.Drawing.Size(114, 17)
        Me.LblNumeroInterior.TabIndex = 115
        Me.LblNumeroInterior.Text = "Número interior :"
        '
        'TxtNumeroExterior
        '
        Me.TxtNumeroExterior.Location = New System.Drawing.Point(136, 359)
        Me.TxtNumeroExterior.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumeroExterior.MaxLength = 50
        Me.TxtNumeroExterior.Name = "TxtNumeroExterior"
        Me.TxtNumeroExterior.Size = New System.Drawing.Size(157, 22)
        Me.TxtNumeroExterior.TabIndex = 112
        '
        'LblNumeroExterior
        '
        Me.LblNumeroExterior.AutoSize = True
        Me.LblNumeroExterior.Location = New System.Drawing.Point(11, 362)
        Me.LblNumeroExterior.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumeroExterior.Name = "LblNumeroExterior"
        Me.LblNumeroExterior.Size = New System.Drawing.Size(117, 17)
        Me.LblNumeroExterior.TabIndex = 113
        Me.LblNumeroExterior.Text = "Número exterior :"
        '
        'TxtCalle
        '
        Me.TxtCalle.Location = New System.Drawing.Point(66, 327)
        Me.TxtCalle.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCalle.MaxLength = 100
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(554, 22)
        Me.TxtCalle.TabIndex = 110
        '
        'LblCalle
        '
        Me.LblCalle.AutoSize = True
        Me.LblCalle.Location = New System.Drawing.Point(11, 330)
        Me.LblCalle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCalle.Name = "LblCalle"
        Me.LblCalle.Size = New System.Drawing.Size(47, 17)
        Me.LblCalle.TabIndex = 111
        Me.LblCalle.Text = "Calle :"
        '
        'TxtDistanciaRecorrida
        '
        Me.TxtDistanciaRecorrida.Location = New System.Drawing.Point(155, 301)
        Me.TxtDistanciaRecorrida.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDistanciaRecorrida.MaxLength = 50
        Me.TxtDistanciaRecorrida.Name = "TxtDistanciaRecorrida"
        Me.TxtDistanciaRecorrida.Size = New System.Drawing.Size(152, 22)
        Me.TxtDistanciaRecorrida.TabIndex = 108
        '
        'LblDistanciaRecorrida
        '
        Me.LblDistanciaRecorrida.AutoSize = True
        Me.LblDistanciaRecorrida.Location = New System.Drawing.Point(12, 304)
        Me.LblDistanciaRecorrida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDistanciaRecorrida.Name = "LblDistanciaRecorrida"
        Me.LblDistanciaRecorrida.Size = New System.Drawing.Size(135, 17)
        Me.LblDistanciaRecorrida.TabIndex = 109
        Me.LblDistanciaRecorrida.Text = "Distancia recorrida :"
        '
        'LblPaisResidenciaFiscal
        '
        Me.LblPaisResidenciaFiscal.AutoSize = True
        Me.LblPaisResidenciaFiscal.Location = New System.Drawing.Point(11, 276)
        Me.LblPaisResidenciaFiscal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPaisResidenciaFiscal.Name = "LblPaisResidenciaFiscal"
        Me.LblPaisResidenciaFiscal.Size = New System.Drawing.Size(148, 17)
        Me.LblPaisResidenciaFiscal.TabIndex = 107
        Me.LblPaisResidenciaFiscal.Text = "País residencia fiscal :"
        '
        'TxtNumeroIdentificacionRegistroFiscalExtranjero
        '
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Location = New System.Drawing.Point(8, 243)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.MaxLength = 40
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Name = "TxtNumeroIdentificacionRegistroFiscalExtranjero"
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Size = New System.Drawing.Size(612, 22)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.TabIndex = 105
        '
        'LblNumeroIdentificacionResgistroFiscalExtranjero
        '
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.AutoSize = True
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Location = New System.Drawing.Point(10, 222)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Name = "LblNumeroIdentificacionResgistroFiscalExtranjero"
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Size = New System.Drawing.Size(307, 17)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.TabIndex = 104
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Text = "Número identificación registro fiscal extranjero :"
        '
        'TxtRfcRemitenteDestinatario
        '
        Me.TxtRfcRemitenteDestinatario.Location = New System.Drawing.Point(202, 188)
        Me.TxtRfcRemitenteDestinatario.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRfcRemitenteDestinatario.MaxLength = 13
        Me.TxtRfcRemitenteDestinatario.Name = "TxtRfcRemitenteDestinatario"
        Me.TxtRfcRemitenteDestinatario.Size = New System.Drawing.Size(280, 22)
        Me.TxtRfcRemitenteDestinatario.TabIndex = 102
        '
        'LblRfcRemitenteDestinatario
        '
        Me.LblRfcRemitenteDestinatario.AutoSize = True
        Me.LblRfcRemitenteDestinatario.Location = New System.Drawing.Point(10, 191)
        Me.LblRfcRemitenteDestinatario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRfcRemitenteDestinatario.Name = "LblRfcRemitenteDestinatario"
        Me.LblRfcRemitenteDestinatario.Size = New System.Drawing.Size(184, 17)
        Me.LblRfcRemitenteDestinatario.TabIndex = 103
        Me.LblRfcRemitenteDestinatario.Text = "RFC remitente destinatario :"
        '
        'TxtNombreRemitenteDestinatario
        '
        Me.TxtNombreRemitenteDestinatario.Location = New System.Drawing.Point(11, 158)
        Me.TxtNombreRemitenteDestinatario.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreRemitenteDestinatario.MaxLength = 254
        Me.TxtNombreRemitenteDestinatario.Name = "TxtNombreRemitenteDestinatario"
        Me.TxtNombreRemitenteDestinatario.Size = New System.Drawing.Size(609, 22)
        Me.TxtNombreRemitenteDestinatario.TabIndex = 100
        '
        'LblNombreRemitenteDestinatario
        '
        Me.LblNombreRemitenteDestinatario.AutoSize = True
        Me.LblNombreRemitenteDestinatario.Location = New System.Drawing.Point(8, 137)
        Me.LblNombreRemitenteDestinatario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreRemitenteDestinatario.Name = "LblNombreRemitenteDestinatario"
        Me.LblNombreRemitenteDestinatario.Size = New System.Drawing.Size(207, 17)
        Me.LblNombreRemitenteDestinatario.TabIndex = 101
        Me.LblNombreRemitenteDestinatario.Text = "Nombre remitente destinatario :"
        '
        'LblTipoUbicacion
        '
        Me.LblTipoUbicacion.AutoSize = True
        Me.LblTipoUbicacion.Location = New System.Drawing.Point(337, 104)
        Me.LblTipoUbicacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTipoUbicacion.Name = "LblTipoUbicacion"
        Me.LblTipoUbicacion.Size = New System.Drawing.Size(108, 17)
        Me.LblTipoUbicacion.TabIndex = 99
        Me.LblTipoUbicacion.Text = "Tipo ubicación :"
        '
        'CboTipoUbicacion
        '
        Me.CboTipoUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoUbicacion.FormattingEnabled = True
        Me.CboTipoUbicacion.Items.AddRange(New Object() {"Origen", "Destino"})
        Me.CboTipoUbicacion.Location = New System.Drawing.Point(469, 101)
        Me.CboTipoUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoUbicacion.MaxLength = 1
        Me.CboTipoUbicacion.Name = "CboTipoUbicacion"
        Me.CboTipoUbicacion.Size = New System.Drawing.Size(93, 24)
        Me.CboTipoUbicacion.TabIndex = 98
        '
        'TxtIdUbicacion
        '
        Me.TxtIdUbicacion.Location = New System.Drawing.Point(140, 101)
        Me.TxtIdUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdUbicacion.MaxLength = 8
        Me.TxtIdUbicacion.Name = "TxtIdUbicacion"
        Me.TxtIdUbicacion.Size = New System.Drawing.Size(170, 22)
        Me.TxtIdUbicacion.TabIndex = 96
        '
        'LblIdUbicacion
        '
        Me.LblIdUbicacion.AutoSize = True
        Me.LblIdUbicacion.Location = New System.Drawing.Point(8, 104)
        Me.LblIdUbicacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdUbicacion.Name = "LblIdUbicacion"
        Me.LblIdUbicacion.Size = New System.Drawing.Size(93, 17)
        Me.LblIdUbicacion.TabIndex = 97
        Me.LblIdUbicacion.Text = "ID ubicación :"
        '
        'LblDisplayNombreCliente
        '
        Me.LblDisplayNombreCliente.AutoSize = True
        Me.LblDisplayNombreCliente.Location = New System.Drawing.Point(137, 77)
        Me.LblDisplayNombreCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreCliente.Name = "LblDisplayNombreCliente"
        Me.LblDisplayNombreCliente.Size = New System.Drawing.Size(16, 17)
        Me.LblDisplayNombreCliente.TabIndex = 95
        Me.LblDisplayNombreCliente.Text = "_"
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(193, 602)
        Me.TxtCodigoPostal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoPostal.MaxLength = 12
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(83, 22)
        Me.TxtCodigoPostal.TabIndex = 3
        '
        'LblCodigoPostal
        '
        Me.LblCodigoPostal.AutoSize = True
        Me.LblCodigoPostal.Location = New System.Drawing.Point(12, 605)
        Me.LblCodigoPostal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoPostal.Name = "LblCodigoPostal"
        Me.LblCodigoPostal.Size = New System.Drawing.Size(102, 17)
        Me.LblCodigoPostal.TabIndex = 94
        Me.LblCodigoPostal.Text = "Código postal :"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(105, 451)
        Me.TxtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtReferencia.MaxLength = 250
        Me.TxtReferencia.Multiline = True
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(515, 48)
        Me.TxtReferencia.TabIndex = 2
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Location = New System.Drawing.Point(12, 454)
        Me.LblReferencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(85, 17)
        Me.LblReferencia.TabIndex = 92
        Me.LblReferencia.Text = "Referencia :"
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
        'LblCodigoCliente
        '
        Me.LblCodigoCliente.AutoSize = True
        Me.LblCodigoCliente.Location = New System.Drawing.Point(8, 54)
        Me.LblCodigoCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoCliente.Name = "LblCodigoCliente"
        Me.LblCodigoCliente.Size = New System.Drawing.Size(105, 17)
        Me.LblCodigoCliente.TabIndex = 74
        Me.LblCodigoCliente.Text = "Código cliente :"
        '
        'TxtCodigoCliente
        '
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(140, 51)
        Me.TxtCodigoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(152, 22)
        Me.TxtCodigoCliente.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(12, 651)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(96, 648)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(93, 24)
        Me.CboEstatus.TabIndex = 5
        '
        'LblCodigoUbicacion
        '
        Me.LblCodigoUbicacion.AutoSize = True
        Me.LblCodigoUbicacion.Location = New System.Drawing.Point(8, 22)
        Me.LblCodigoUbicacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoUbicacion.Name = "LblCodigoUbicacion"
        Me.LblCodigoUbicacion.Size = New System.Drawing.Size(124, 17)
        Me.LblCodigoUbicacion.TabIndex = 8
        Me.LblCodigoUbicacion.Text = "Código ubicación :"
        '
        'TxtCodigoUbicacion
        '
        Me.TxtCodigoUbicacion.Location = New System.Drawing.Point(140, 19)
        Me.TxtCodigoUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoUbicacion.MaxLength = 2
        Me.TxtCodigoUbicacion.Name = "TxtCodigoUbicacion"
        Me.TxtCodigoUbicacion.Size = New System.Drawing.Size(113, 22)
        Me.TxtCodigoUbicacion.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'cboPaisResidenciaFiscal
        '
        Me.cboPaisResidenciaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaisResidenciaFiscal.FormattingEnabled = True
        Me.cboPaisResidenciaFiscal.Items.AddRange(New Object() {"A", "B"})
        Me.cboPaisResidenciaFiscal.Location = New System.Drawing.Point(167, 273)
        Me.cboPaisResidenciaFiscal.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPaisResidenciaFiscal.MaxLength = 80
        Me.cboPaisResidenciaFiscal.Name = "cboPaisResidenciaFiscal"
        Me.cboPaisResidenciaFiscal.Size = New System.Drawing.Size(290, 24)
        Me.cboPaisResidenciaFiscal.TabIndex = 130
        '
        'cboPaisDomicilio
        '
        Me.cboPaisDomicilio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaisDomicilio.FormattingEnabled = True
        Me.cboPaisDomicilio.Items.AddRange(New Object() {"A", "B"})
        Me.cboPaisDomicilio.Location = New System.Drawing.Point(120, 509)
        Me.cboPaisDomicilio.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPaisDomicilio.MaxLength = 80
        Me.cboPaisDomicilio.Name = "cboPaisDomicilio"
        Me.cboPaisDomicilio.Size = New System.Drawing.Size(290, 24)
        Me.cboPaisDomicilio.TabIndex = 131
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstado.Location = New System.Drawing.Point(121, 539)
        Me.cboEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEstado.MaxLength = 80
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(416, 24)
        Me.cboEstado.TabIndex = 132
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.FormattingEnabled = True
        Me.cboMunicipio.Items.AddRange(New Object() {"A", "B"})
        Me.cboMunicipio.Location = New System.Drawing.Point(121, 571)
        Me.cboMunicipio.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMunicipio.MaxLength = 80
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(290, 24)
        Me.cboMunicipio.TabIndex = 133
        '
        'Catalogo_CFDI_Ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 740)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
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
End Class
