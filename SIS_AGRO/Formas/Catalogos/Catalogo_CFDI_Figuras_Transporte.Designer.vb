<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_CFDI_Figuras_Transporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_CFDI_Figuras_Transporte))
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
        Me.LblPaisResidenciaFiscal = New System.Windows.Forms.Label()
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero = New System.Windows.Forms.TextBox()
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero = New System.Windows.Forms.Label()
        Me.TxtNumeroLicencia = New System.Windows.Forms.TextBox()
        Me.LblRfcRemitenteDestinatario = New System.Windows.Forms.Label()
        Me.TxtRfc = New System.Windows.Forms.TextBox()
        Me.LblRfc = New System.Windows.Forms.Label()
        Me.CboTipoFiguraTransporte = New System.Windows.Forms.ComboBox()
        Me.LblDisplayTipoFiguraTransporte = New System.Windows.Forms.Label()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.LblCodigoPostal = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TxtNombreFiguraTransporte = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblCodigoFiguraTransporte = New System.Windows.Forms.Label()
        Me.TxtCodigoFiguraTransporte = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbDomicilio = New System.Windows.Forms.GroupBox()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDomicilio.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(802, 27)
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
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(303, 522)
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
        Me.Grid.Size = New System.Drawing.Size(290, 472)
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 553)
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
        Me.gBoxInformacion.Controls.Add(Me.gbDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.cboPaisResidenciaFiscal)
        Me.gBoxInformacion.Controls.Add(Me.LblPaisResidenciaFiscal)
        Me.gBoxInformacion.Controls.Add(Me.TxtNumeroIdentificacionRegistroFiscalExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.LblNumeroIdentificacionResgistroFiscalExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.TxtNumeroLicencia)
        Me.gBoxInformacion.Controls.Add(Me.LblRfcRemitenteDestinatario)
        Me.gBoxInformacion.Controls.Add(Me.TxtRfc)
        Me.gBoxInformacion.Controls.Add(Me.LblRfc)
        Me.gBoxInformacion.Controls.Add(Me.CboTipoFiguraTransporte)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayTipoFiguraTransporte)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblNombre)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreFiguraTransporte)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoFiguraTransporte)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoFiguraTransporte)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(471, 522)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.FormattingEnabled = True
        Me.cboMunicipio.Items.AddRange(New Object() {"A", "B"})
        Me.cboMunicipio.Location = New System.Drawing.Point(80, 195)
        Me.cboMunicipio.MaxLength = 80
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(218, 21)
        Me.cboMunicipio.TabIndex = 8
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstado.Location = New System.Drawing.Point(80, 168)
        Me.cboEstado.MaxLength = 80
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(218, 21)
        Me.cboEstado.TabIndex = 7
        '
        'cboPaisDomicilio
        '
        Me.cboPaisDomicilio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaisDomicilio.FormattingEnabled = True
        Me.cboPaisDomicilio.Items.AddRange(New Object() {"A", "B"})
        Me.cboPaisDomicilio.Location = New System.Drawing.Point(80, 141)
        Me.cboPaisDomicilio.MaxLength = 80
        Me.cboPaisDomicilio.Name = "cboPaisDomicilio"
        Me.cboPaisDomicilio.Size = New System.Drawing.Size(218, 21)
        Me.cboPaisDomicilio.TabIndex = 6
        '
        'cboPaisResidenciaFiscal
        '
        Me.cboPaisResidenciaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaisResidenciaFiscal.FormattingEnabled = True
        Me.cboPaisResidenciaFiscal.Items.AddRange(New Object() {"A", "B"})
        Me.cboPaisResidenciaFiscal.Location = New System.Drawing.Point(126, 178)
        Me.cboPaisResidenciaFiscal.MaxLength = 80
        Me.cboPaisResidenciaFiscal.Name = "cboPaisResidenciaFiscal"
        Me.cboPaisResidenciaFiscal.Size = New System.Drawing.Size(218, 21)
        Me.cboPaisResidenciaFiscal.TabIndex = 6
        '
        'LblPaisDomicilio
        '
        Me.LblPaisDomicilio.AutoSize = True
        Me.LblPaisDomicilio.Location = New System.Drawing.Point(6, 144)
        Me.LblPaisDomicilio.Name = "LblPaisDomicilio"
        Me.LblPaisDomicilio.Size = New System.Drawing.Size(35, 13)
        Me.LblPaisDomicilio.TabIndex = 129
        Me.LblPaisDomicilio.Text = "País :"
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Location = New System.Drawing.Point(6, 171)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(46, 13)
        Me.LblEstado.TabIndex = 126
        Me.LblEstado.Text = "Estado :"
        '
        'LblMunicipio
        '
        Me.LblMunicipio.AutoSize = True
        Me.LblMunicipio.Location = New System.Drawing.Point(6, 198)
        Me.LblMunicipio.Name = "LblMunicipio"
        Me.LblMunicipio.Size = New System.Drawing.Size(58, 13)
        Me.LblMunicipio.TabIndex = 123
        Me.LblMunicipio.Text = "Municipio :"
        '
        'LblNombreLocalidad
        '
        Me.LblNombreLocalidad.AutoSize = True
        Me.LblNombreLocalidad.Location = New System.Drawing.Point(150, 91)
        Me.LblNombreLocalidad.Name = "LblNombreLocalidad"
        Me.LblNombreLocalidad.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreLocalidad.TabIndex = 121
        Me.LblNombreLocalidad.Text = "_"
        '
        'LblNombreColonia
        '
        Me.LblNombreColonia.AutoSize = True
        Me.LblNombreColonia.Location = New System.Drawing.Point(150, 67)
        Me.LblNombreColonia.Name = "LblNombreColonia"
        Me.LblNombreColonia.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreColonia.TabIndex = 120
        Me.LblNombreColonia.Text = "_"
        '
        'TxtIdLocalidad
        '
        Me.TxtIdLocalidad.Location = New System.Drawing.Point(80, 89)
        Me.TxtIdLocalidad.MaxLength = 50
        Me.TxtIdLocalidad.Name = "TxtIdLocalidad"
        Me.TxtIdLocalidad.Size = New System.Drawing.Size(63, 20)
        Me.TxtIdLocalidad.TabIndex = 4
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
        Me.TxtIdColonia.Location = New System.Drawing.Point(80, 64)
        Me.TxtIdColonia.MaxLength = 50
        Me.TxtIdColonia.Name = "TxtIdColonia"
        Me.TxtIdColonia.Size = New System.Drawing.Size(63, 20)
        Me.TxtIdColonia.TabIndex = 3
        '
        'LblIdColonia
        '
        Me.LblIdColonia.AutoSize = True
        Me.LblIdColonia.Location = New System.Drawing.Point(6, 67)
        Me.LblIdColonia.Name = "LblIdColonia"
        Me.LblIdColonia.Size = New System.Drawing.Size(48, 13)
        Me.LblIdColonia.TabIndex = 117
        Me.LblIdColonia.Text = "Colonia :"
        '
        'TxtNumeroInterior
        '
        Me.TxtNumeroInterior.Location = New System.Drawing.Point(328, 40)
        Me.TxtNumeroInterior.MaxLength = 50
        Me.TxtNumeroInterior.Name = "TxtNumeroInterior"
        Me.TxtNumeroInterior.Size = New System.Drawing.Size(122, 20)
        Me.TxtNumeroInterior.TabIndex = 2
        '
        'LblNumeroInterior
        '
        Me.LblNumeroInterior.AutoSize = True
        Me.LblNumeroInterior.Location = New System.Drawing.Point(236, 42)
        Me.LblNumeroInterior.Name = "LblNumeroInterior"
        Me.LblNumeroInterior.Size = New System.Drawing.Size(84, 13)
        Me.LblNumeroInterior.TabIndex = 115
        Me.LblNumeroInterior.Text = "Número interior :"
        '
        'TxtNumeroExterior
        '
        Me.TxtNumeroExterior.Location = New System.Drawing.Point(103, 40)
        Me.TxtNumeroExterior.MaxLength = 50
        Me.TxtNumeroExterior.Name = "TxtNumeroExterior"
        Me.TxtNumeroExterior.Size = New System.Drawing.Size(119, 20)
        Me.TxtNumeroExterior.TabIndex = 1
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
        Me.TxtCalle.Location = New System.Drawing.Point(57, 14)
        Me.TxtCalle.MaxLength = 100
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(393, 20)
        Me.TxtCalle.TabIndex = 0
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
        'LblPaisResidenciaFiscal
        '
        Me.LblPaisResidenciaFiscal.AutoSize = True
        Me.LblPaisResidenciaFiscal.Location = New System.Drawing.Point(6, 180)
        Me.LblPaisResidenciaFiscal.Name = "LblPaisResidenciaFiscal"
        Me.LblPaisResidenciaFiscal.Size = New System.Drawing.Size(113, 13)
        Me.LblPaisResidenciaFiscal.TabIndex = 107
        Me.LblPaisResidenciaFiscal.Text = "País residencia fiscal :"
        '
        'TxtNumeroIdentificacionRegistroFiscalExtranjero
        '
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Location = New System.Drawing.Point(240, 152)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.MaxLength = 40
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Name = "TxtNumeroIdentificacionRegistroFiscalExtranjero"
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Size = New System.Drawing.Size(104, 20)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.TabIndex = 5
        '
        'LblNumeroIdentificacionResgistroFiscalExtranjero
        '
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.AutoSize = True
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Location = New System.Drawing.Point(6, 155)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Name = "LblNumeroIdentificacionResgistroFiscalExtranjero"
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Size = New System.Drawing.Size(228, 13)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.TabIndex = 104
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Text = "Número identificación registro fiscal extranjero :"
        '
        'TxtNumeroLicencia
        '
        Me.TxtNumeroLicencia.Location = New System.Drawing.Point(118, 127)
        Me.TxtNumeroLicencia.MaxLength = 16
        Me.TxtNumeroLicencia.Name = "TxtNumeroLicencia"
        Me.TxtNumeroLicencia.Size = New System.Drawing.Size(106, 20)
        Me.TxtNumeroLicencia.TabIndex = 4
        '
        'LblRfcRemitenteDestinatario
        '
        Me.LblRfcRemitenteDestinatario.AutoSize = True
        Me.LblRfcRemitenteDestinatario.Location = New System.Drawing.Point(6, 129)
        Me.LblRfcRemitenteDestinatario.Name = "LblRfcRemitenteDestinatario"
        Me.LblRfcRemitenteDestinatario.Size = New System.Drawing.Size(104, 13)
        Me.LblRfcRemitenteDestinatario.TabIndex = 103
        Me.LblRfcRemitenteDestinatario.Text = "Número de licencia :"
        '
        'TxtRfc
        '
        Me.TxtRfc.Location = New System.Drawing.Point(57, 101)
        Me.TxtRfc.MaxLength = 13
        Me.TxtRfc.Name = "TxtRfc"
        Me.TxtRfc.Size = New System.Drawing.Size(106, 20)
        Me.TxtRfc.TabIndex = 3
        '
        'LblRfc
        '
        Me.LblRfc.AutoSize = True
        Me.LblRfc.Location = New System.Drawing.Point(6, 103)
        Me.LblRfc.Name = "LblRfc"
        Me.LblRfc.Size = New System.Drawing.Size(34, 13)
        Me.LblRfc.TabIndex = 101
        Me.LblRfc.Text = "RFC :"
        '
        'CboTipoFiguraTransporte
        '
        Me.CboTipoFiguraTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoFiguraTransporte.FormattingEnabled = True
        Me.CboTipoFiguraTransporte.Location = New System.Drawing.Point(128, 69)
        Me.CboTipoFiguraTransporte.MaxLength = 1
        Me.CboTipoFiguraTransporte.Name = "CboTipoFiguraTransporte"
        Me.CboTipoFiguraTransporte.Size = New System.Drawing.Size(96, 21)
        Me.CboTipoFiguraTransporte.TabIndex = 2
        '
        'LblDisplayTipoFiguraTransporte
        '
        Me.LblDisplayTipoFiguraTransporte.AutoSize = True
        Me.LblDisplayTipoFiguraTransporte.Location = New System.Drawing.Point(6, 72)
        Me.LblDisplayTipoFiguraTransporte.Name = "LblDisplayTipoFiguraTransporte"
        Me.LblDisplayTipoFiguraTransporte.Size = New System.Drawing.Size(113, 13)
        Me.LblDisplayTipoFiguraTransporte.TabIndex = 97
        Me.LblDisplayTipoFiguraTransporte.Text = "Tipo figura transporte :"
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(91, 222)
        Me.TxtCodigoPostal.MaxLength = 12
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(63, 20)
        Me.TxtCodigoPostal.TabIndex = 9
        '
        'LblCodigoPostal
        '
        Me.LblCodigoPostal.AutoSize = True
        Me.LblCodigoPostal.Location = New System.Drawing.Point(6, 225)
        Me.LblCodigoPostal.Name = "LblCodigoPostal"
        Me.LblCodigoPostal.Size = New System.Drawing.Size(77, 13)
        Me.LblCodigoPostal.TabIndex = 94
        Me.LblCodigoPostal.Text = "Código postal :"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(80, 115)
        Me.TxtReferencia.MaxLength = 250
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(218, 20)
        Me.TxtReferencia.TabIndex = 5
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
        'LblNombre
        '
        Me.LblNombre.AutoSize = True
        Me.LblNombre.Location = New System.Drawing.Point(6, 44)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(50, 13)
        Me.LblNombre.TabIndex = 74
        Me.LblNombre.Text = "Nombre :"
        '
        'TxtNombreFiguraTransporte
        '
        Me.TxtNombreFiguraTransporte.Location = New System.Drawing.Point(57, 41)
        Me.TxtNombreFiguraTransporte.MaxLength = 254
        Me.TxtNombreFiguraTransporte.Name = "TxtNombreFiguraTransporte"
        Me.TxtNombreFiguraTransporte.Size = New System.Drawing.Size(409, 20)
        Me.TxtNombreFiguraTransporte.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(6, 486)
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
        Me.CboEstatus.Location = New System.Drawing.Point(57, 483)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(71, 21)
        Me.CboEstatus.TabIndex = 8
        '
        'LblCodigoFiguraTransporte
        '
        Me.LblCodigoFiguraTransporte.AutoSize = True
        Me.LblCodigoFiguraTransporte.Location = New System.Drawing.Point(6, 18)
        Me.LblCodigoFiguraTransporte.Name = "LblCodigoFiguraTransporte"
        Me.LblCodigoFiguraTransporte.Size = New System.Drawing.Size(46, 13)
        Me.LblCodigoFiguraTransporte.TabIndex = 8
        Me.LblCodigoFiguraTransporte.Text = "Código :"
        '
        'TxtCodigoFiguraTransporte
        '
        Me.TxtCodigoFiguraTransporte.Location = New System.Drawing.Point(57, 15)
        Me.TxtCodigoFiguraTransporte.MaxLength = 5
        Me.TxtCodigoFiguraTransporte.Name = "TxtCodigoFiguraTransporte"
        Me.TxtCodigoFiguraTransporte.Size = New System.Drawing.Size(86, 20)
        Me.TxtCodigoFiguraTransporte.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'gbDomicilio
        '
        Me.gbDomicilio.Controls.Add(Me.LblCalle)
        Me.gbDomicilio.Controls.Add(Me.cboMunicipio)
        Me.gbDomicilio.Controls.Add(Me.LblReferencia)
        Me.gbDomicilio.Controls.Add(Me.cboEstado)
        Me.gbDomicilio.Controls.Add(Me.TxtReferencia)
        Me.gbDomicilio.Controls.Add(Me.cboPaisDomicilio)
        Me.gbDomicilio.Controls.Add(Me.LblCodigoPostal)
        Me.gbDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.gbDomicilio.Controls.Add(Me.LblPaisDomicilio)
        Me.gbDomicilio.Controls.Add(Me.TxtCalle)
        Me.gbDomicilio.Controls.Add(Me.LblEstado)
        Me.gbDomicilio.Controls.Add(Me.LblNumeroExterior)
        Me.gbDomicilio.Controls.Add(Me.LblMunicipio)
        Me.gbDomicilio.Controls.Add(Me.TxtNumeroExterior)
        Me.gbDomicilio.Controls.Add(Me.LblNombreLocalidad)
        Me.gbDomicilio.Controls.Add(Me.LblNumeroInterior)
        Me.gbDomicilio.Controls.Add(Me.LblNombreColonia)
        Me.gbDomicilio.Controls.Add(Me.TxtNumeroInterior)
        Me.gbDomicilio.Controls.Add(Me.TxtIdLocalidad)
        Me.gbDomicilio.Controls.Add(Me.LblIdColonia)
        Me.gbDomicilio.Controls.Add(Me.LblIdLocalidad)
        Me.gbDomicilio.Controls.Add(Me.TxtIdColonia)
        Me.gbDomicilio.Location = New System.Drawing.Point(6, 216)
        Me.gbDomicilio.Name = "gbDomicilio"
        Me.gbDomicilio.Size = New System.Drawing.Size(456, 250)
        Me.gbDomicilio.TabIndex = 7
        Me.gbDomicilio.TabStop = False
        Me.gbDomicilio.Text = "Domicilio"
        '
        'Catalogo_CFDI_Figuras_Transporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 575)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_CFDI_Figuras_Transporte"
        Me.ShowIcon = False
        Me.Text = "Catálogo figuras de transporte"
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
        Me.gbDomicilio.ResumeLayout(False)
        Me.gbDomicilio.PerformLayout()
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
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtNombreFiguraTransporte As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblCodigoFiguraTransporte As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoFiguraTransporte As System.Windows.Forms.TextBox
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
    Friend WithEvents LblPaisResidenciaFiscal As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroIdentificacionRegistroFiscalExtranjero As System.Windows.Forms.TextBox
    Friend WithEvents LblNumeroIdentificacionResgistroFiscalExtranjero As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroLicencia As System.Windows.Forms.TextBox
    Friend WithEvents LblRfcRemitenteDestinatario As System.Windows.Forms.Label
    Friend WithEvents TxtRfc As System.Windows.Forms.TextBox
    Friend WithEvents LblRfc As System.Windows.Forms.Label
    Friend WithEvents CboTipoFiguraTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayTipoFiguraTransporte As System.Windows.Forms.Label
    Friend WithEvents LblPaisDomicilio As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboPaisDomicilio As System.Windows.Forms.ComboBox
    Friend WithEvents cboPaisResidenciaFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents gbDomicilio As GroupBox
End Class
