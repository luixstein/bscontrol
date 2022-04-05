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
        Me.LblNombrePaisResidenciaFiscal = New System.Windows.Forms.Label()
        Me.gb = New System.Windows.Forms.GroupBox()
        Me.LblNombreMunicipio = New System.Windows.Forms.Label()
        Me.LblNombreEstado = New System.Windows.Forms.Label()
        Me.LblNombrePaisDomicilio = New System.Windows.Forms.Label()
        Me.TxtMunicipio = New System.Windows.Forms.TextBox()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.TxtEstado = New System.Windows.Forms.TextBox()
        Me.TxtPaisDomicilio = New System.Windows.Forms.TextBox()
        Me.TxtNumeroInterior = New System.Windows.Forms.TextBox()
        Me.LblPaisDomicilio = New System.Windows.Forms.Label()
        Me.LblCodigoPostal = New System.Windows.Forms.Label()
        Me.LblNumeroInterior = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.LblCalle = New System.Windows.Forms.Label()
        Me.LblMunicipio = New System.Windows.Forms.Label()
        Me.LblIdLocalidad = New System.Windows.Forms.Label()
        Me.TxtIdLocalidad = New System.Windows.Forms.TextBox()
        Me.LblNombreLocalidad = New System.Windows.Forms.Label()
        Me.TxtIdColonia = New System.Windows.Forms.TextBox()
        Me.LblIdColonia = New System.Windows.Forms.Label()
        Me.LblNombreColonia = New System.Windows.Forms.Label()
        Me.TxtCalle = New System.Windows.Forms.TextBox()
        Me.TxtNumeroExterior = New System.Windows.Forms.TextBox()
        Me.LblNumeroExterior = New System.Windows.Forms.Label()
        Me.TxtPaisResidenciaFiscal = New System.Windows.Forms.TextBox()
        Me.CboTipoUbicacion = New System.Windows.Forms.ComboBox()
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
        Me.TxtIdUbicacion = New System.Windows.Forms.TextBox()
        Me.LblIdUbicacion = New System.Windows.Forms.Label()
        Me.LblDisplayNombreCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCodigoCliente = New System.Windows.Forms.Label()
        Me.TxtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblCodigoUbicacion = New System.Windows.Forms.Label()
        Me.TxtCodigoUbicacion = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.gb.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1115, 27)
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
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(450, 677)
        Me.gBoxBusquedaRapida.TabIndex = 2
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(321, 26)
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
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(392, 22)
        Me.cboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(47, 24)
        Me.cboEstatusFiltro.TabIndex = 1
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
        Me.Grid.Size = New System.Drawing.Size(442, 618)
        Me.Grid.TabIndex = 112
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(298, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 716)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1115, 25)
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
        Me.gBoxInformacion.Controls.Add(Me.LblNombrePaisResidenciaFiscal)
        Me.gBoxInformacion.Controls.Add(Me.gb)
        Me.gBoxInformacion.Controls.Add(Me.TxtPaisResidenciaFiscal)
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
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(628, 677)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'LblNombrePaisResidenciaFiscal
        '
        Me.LblNombrePaisResidenciaFiscal.AutoSize = True
        Me.LblNombrePaisResidenciaFiscal.Location = New System.Drawing.Point(261, 601)
        Me.LblNombrePaisResidenciaFiscal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombrePaisResidenciaFiscal.Name = "LblNombrePaisResidenciaFiscal"
        Me.LblNombrePaisResidenciaFiscal.Size = New System.Drawing.Size(16, 17)
        Me.LblNombrePaisResidenciaFiscal.TabIndex = 137
        Me.LblNombrePaisResidenciaFiscal.Text = "_"
        '
        'gb
        '
        Me.gb.Controls.Add(Me.LblNombreMunicipio)
        Me.gb.Controls.Add(Me.LblNombreEstado)
        Me.gb.Controls.Add(Me.LblNombrePaisDomicilio)
        Me.gb.Controls.Add(Me.TxtMunicipio)
        Me.gb.Controls.Add(Me.TxtReferencia)
        Me.gb.Controls.Add(Me.LblReferencia)
        Me.gb.Controls.Add(Me.TxtEstado)
        Me.gb.Controls.Add(Me.TxtPaisDomicilio)
        Me.gb.Controls.Add(Me.TxtNumeroInterior)
        Me.gb.Controls.Add(Me.LblPaisDomicilio)
        Me.gb.Controls.Add(Me.LblCodigoPostal)
        Me.gb.Controls.Add(Me.LblNumeroInterior)
        Me.gb.Controls.Add(Me.LblEstado)
        Me.gb.Controls.Add(Me.TxtCodigoPostal)
        Me.gb.Controls.Add(Me.LblCalle)
        Me.gb.Controls.Add(Me.LblMunicipio)
        Me.gb.Controls.Add(Me.LblIdLocalidad)
        Me.gb.Controls.Add(Me.TxtIdLocalidad)
        Me.gb.Controls.Add(Me.LblNombreLocalidad)
        Me.gb.Controls.Add(Me.TxtIdColonia)
        Me.gb.Controls.Add(Me.LblIdColonia)
        Me.gb.Controls.Add(Me.LblNombreColonia)
        Me.gb.Controls.Add(Me.TxtCalle)
        Me.gb.Controls.Add(Me.TxtNumeroExterior)
        Me.gb.Controls.Add(Me.LblNumeroExterior)
        Me.gb.Location = New System.Drawing.Point(10, 249)
        Me.gb.Margin = New System.Windows.Forms.Padding(4)
        Me.gb.Name = "gb"
        Me.gb.Padding = New System.Windows.Forms.Padding(4)
        Me.gb.Size = New System.Drawing.Size(607, 305)
        Me.gb.TabIndex = 7
        Me.gb.TabStop = False
        Me.gb.Text = "Domicilio"
        '
        'LblNombreMunicipio
        '
        Me.LblNombreMunicipio.AutoSize = True
        Me.LblNombreMunicipio.Location = New System.Drawing.Point(211, 123)
        Me.LblNombreMunicipio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreMunicipio.Name = "LblNombreMunicipio"
        Me.LblNombreMunicipio.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreMunicipio.TabIndex = 135
        Me.LblNombreMunicipio.Text = "_"
        '
        'LblNombreEstado
        '
        Me.LblNombreEstado.AutoSize = True
        Me.LblNombreEstado.Location = New System.Drawing.Point(211, 91)
        Me.LblNombreEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreEstado.Name = "LblNombreEstado"
        Me.LblNombreEstado.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreEstado.TabIndex = 134
        Me.LblNombreEstado.Text = "_"
        '
        'LblNombrePaisDomicilio
        '
        Me.LblNombrePaisDomicilio.AutoSize = True
        Me.LblNombrePaisDomicilio.Location = New System.Drawing.Point(211, 59)
        Me.LblNombrePaisDomicilio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombrePaisDomicilio.Name = "LblNombrePaisDomicilio"
        Me.LblNombrePaisDomicilio.Size = New System.Drawing.Size(16, 17)
        Me.LblNombrePaisDomicilio.TabIndex = 133
        Me.LblNombrePaisDomicilio.Text = "_"
        '
        'TxtMunicipio
        '
        Me.TxtMunicipio.Location = New System.Drawing.Point(120, 120)
        Me.TxtMunicipio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMunicipio.MaxLength = 50
        Me.TxtMunicipio.Name = "TxtMunicipio"
        Me.TxtMunicipio.Size = New System.Drawing.Size(83, 22)
        Me.TxtMunicipio.TabIndex = 4
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(130, 272)
        Me.TxtReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtReferencia.MaxLength = 250
        Me.TxtReferencia.Multiline = True
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(289, 24)
        Me.TxtReferencia.TabIndex = 10
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Location = New System.Drawing.Point(10, 275)
        Me.LblReferencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(85, 17)
        Me.LblReferencia.TabIndex = 92
        Me.LblReferencia.Text = "Referencia :"
        '
        'TxtEstado
        '
        Me.TxtEstado.Location = New System.Drawing.Point(120, 88)
        Me.TxtEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEstado.MaxLength = 50
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.Size = New System.Drawing.Size(83, 22)
        Me.TxtEstado.TabIndex = 3
        '
        'TxtPaisDomicilio
        '
        Me.TxtPaisDomicilio.Location = New System.Drawing.Point(120, 56)
        Me.TxtPaisDomicilio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPaisDomicilio.MaxLength = 50
        Me.TxtPaisDomicilio.Name = "TxtPaisDomicilio"
        Me.TxtPaisDomicilio.Size = New System.Drawing.Size(83, 22)
        Me.TxtPaisDomicilio.TabIndex = 2
        '
        'TxtNumeroInterior
        '
        Me.TxtNumeroInterior.Location = New System.Drawing.Point(438, 242)
        Me.TxtNumeroInterior.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumeroInterior.MaxLength = 50
        Me.TxtNumeroInterior.Name = "TxtNumeroInterior"
        Me.TxtNumeroInterior.Size = New System.Drawing.Size(161, 22)
        Me.TxtNumeroInterior.TabIndex = 9
        '
        'LblPaisDomicilio
        '
        Me.LblPaisDomicilio.AutoSize = True
        Me.LblPaisDomicilio.Location = New System.Drawing.Point(8, 59)
        Me.LblPaisDomicilio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPaisDomicilio.Name = "LblPaisDomicilio"
        Me.LblPaisDomicilio.Size = New System.Drawing.Size(43, 17)
        Me.LblPaisDomicilio.TabIndex = 129
        Me.LblPaisDomicilio.Text = "País :"
        '
        'LblCodigoPostal
        '
        Me.LblCodigoPostal.AutoSize = True
        Me.LblCodigoPostal.Location = New System.Drawing.Point(8, 29)
        Me.LblCodigoPostal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoPostal.Name = "LblCodigoPostal"
        Me.LblCodigoPostal.Size = New System.Drawing.Size(102, 17)
        Me.LblCodigoPostal.TabIndex = 94
        Me.LblCodigoPostal.Text = "Código postal :"
        '
        'LblNumeroInterior
        '
        Me.LblNumeroInterior.AutoSize = True
        Me.LblNumeroInterior.Location = New System.Drawing.Point(305, 247)
        Me.LblNumeroInterior.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumeroInterior.Name = "LblNumeroInterior"
        Me.LblNumeroInterior.Size = New System.Drawing.Size(114, 17)
        Me.LblNumeroInterior.TabIndex = 115
        Me.LblNumeroInterior.Text = "Número interior :"
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Location = New System.Drawing.Point(8, 88)
        Me.LblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(60, 17)
        Me.LblEstado.TabIndex = 126
        Me.LblEstado.Text = "Estado :"
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(120, 26)
        Me.TxtCodigoPostal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoPostal.MaxLength = 12
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(83, 22)
        Me.TxtCodigoPostal.TabIndex = 1
        '
        'LblCalle
        '
        Me.LblCalle.AutoSize = True
        Me.LblCalle.Location = New System.Drawing.Point(10, 215)
        Me.LblCalle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCalle.Name = "LblCalle"
        Me.LblCalle.Size = New System.Drawing.Size(47, 17)
        Me.LblCalle.TabIndex = 111
        Me.LblCalle.Text = "Calle :"
        '
        'LblMunicipio
        '
        Me.LblMunicipio.AutoSize = True
        Me.LblMunicipio.Location = New System.Drawing.Point(8, 120)
        Me.LblMunicipio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMunicipio.Name = "LblMunicipio"
        Me.LblMunicipio.Size = New System.Drawing.Size(75, 17)
        Me.LblMunicipio.TabIndex = 123
        Me.LblMunicipio.Text = "Municipio :"
        '
        'LblIdLocalidad
        '
        Me.LblIdLocalidad.AutoSize = True
        Me.LblIdLocalidad.Location = New System.Drawing.Point(8, 154)
        Me.LblIdLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdLocalidad.Name = "LblIdLocalidad"
        Me.LblIdLocalidad.Size = New System.Drawing.Size(77, 17)
        Me.LblIdLocalidad.TabIndex = 119
        Me.LblIdLocalidad.Text = "Localidad :"
        '
        'TxtIdLocalidad
        '
        Me.TxtIdLocalidad.Location = New System.Drawing.Point(120, 151)
        Me.TxtIdLocalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdLocalidad.MaxLength = 50
        Me.TxtIdLocalidad.Name = "TxtIdLocalidad"
        Me.TxtIdLocalidad.Size = New System.Drawing.Size(83, 22)
        Me.TxtIdLocalidad.TabIndex = 5
        '
        'LblNombreLocalidad
        '
        Me.LblNombreLocalidad.AutoSize = True
        Me.LblNombreLocalidad.Location = New System.Drawing.Point(213, 155)
        Me.LblNombreLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreLocalidad.Name = "LblNombreLocalidad"
        Me.LblNombreLocalidad.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreLocalidad.TabIndex = 121
        Me.LblNombreLocalidad.Text = "_"
        '
        'TxtIdColonia
        '
        Me.TxtIdColonia.Location = New System.Drawing.Point(120, 181)
        Me.TxtIdColonia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdColonia.MaxLength = 50
        Me.TxtIdColonia.Name = "TxtIdColonia"
        Me.TxtIdColonia.Size = New System.Drawing.Size(83, 22)
        Me.TxtIdColonia.TabIndex = 6
        '
        'LblIdColonia
        '
        Me.LblIdColonia.AutoSize = True
        Me.LblIdColonia.Location = New System.Drawing.Point(8, 183)
        Me.LblIdColonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdColonia.Name = "LblIdColonia"
        Me.LblIdColonia.Size = New System.Drawing.Size(63, 17)
        Me.LblIdColonia.TabIndex = 117
        Me.LblIdColonia.Text = "Colonia :"
        '
        'LblNombreColonia
        '
        Me.LblNombreColonia.AutoSize = True
        Me.LblNombreColonia.Location = New System.Drawing.Point(213, 183)
        Me.LblNombreColonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreColonia.Name = "LblNombreColonia"
        Me.LblNombreColonia.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreColonia.TabIndex = 120
        Me.LblNombreColonia.Text = "_"
        '
        'TxtCalle
        '
        Me.TxtCalle.Location = New System.Drawing.Point(66, 211)
        Me.TxtCalle.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCalle.MaxLength = 100
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(533, 22)
        Me.TxtCalle.TabIndex = 7
        '
        'TxtNumeroExterior
        '
        Me.TxtNumeroExterior.Location = New System.Drawing.Point(130, 242)
        Me.TxtNumeroExterior.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumeroExterior.MaxLength = 50
        Me.TxtNumeroExterior.Name = "TxtNumeroExterior"
        Me.TxtNumeroExterior.Size = New System.Drawing.Size(157, 22)
        Me.TxtNumeroExterior.TabIndex = 8
        '
        'LblNumeroExterior
        '
        Me.LblNumeroExterior.AutoSize = True
        Me.LblNumeroExterior.Location = New System.Drawing.Point(10, 247)
        Me.LblNumeroExterior.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumeroExterior.Name = "LblNumeroExterior"
        Me.LblNumeroExterior.Size = New System.Drawing.Size(117, 17)
        Me.LblNumeroExterior.TabIndex = 113
        Me.LblNumeroExterior.Text = "Número exterior :"
        '
        'TxtPaisResidenciaFiscal
        '
        Me.TxtPaisResidenciaFiscal.Location = New System.Drawing.Point(170, 598)
        Me.TxtPaisResidenciaFiscal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPaisResidenciaFiscal.MaxLength = 50
        Me.TxtPaisResidenciaFiscal.Name = "TxtPaisResidenciaFiscal"
        Me.TxtPaisResidenciaFiscal.Size = New System.Drawing.Size(83, 22)
        Me.TxtPaisResidenciaFiscal.TabIndex = 9
        '
        'CboTipoUbicacion
        '
        Me.CboTipoUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoUbicacion.FormattingEnabled = True
        Me.CboTipoUbicacion.Items.AddRange(New Object() {"Origen", "Destino"})
        Me.CboTipoUbicacion.Location = New System.Drawing.Point(448, 100)
        Me.CboTipoUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoUbicacion.MaxLength = 1
        Me.CboTipoUbicacion.Name = "CboTipoUbicacion"
        Me.CboTipoUbicacion.Size = New System.Drawing.Size(93, 24)
        Me.CboTipoUbicacion.TabIndex = 2
        '
        'TxtDistanciaRecorrida
        '
        Me.TxtDistanciaRecorrida.Location = New System.Drawing.Point(203, 219)
        Me.TxtDistanciaRecorrida.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDistanciaRecorrida.MaxLength = 50
        Me.TxtDistanciaRecorrida.Name = "TxtDistanciaRecorrida"
        Me.TxtDistanciaRecorrida.Size = New System.Drawing.Size(133, 22)
        Me.TxtDistanciaRecorrida.TabIndex = 6
        '
        'LblDistanciaRecorrida
        '
        Me.LblDistanciaRecorrida.AutoSize = True
        Me.LblDistanciaRecorrida.Location = New System.Drawing.Point(7, 222)
        Me.LblDistanciaRecorrida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDistanciaRecorrida.Name = "LblDistanciaRecorrida"
        Me.LblDistanciaRecorrida.Size = New System.Drawing.Size(135, 17)
        Me.LblDistanciaRecorrida.TabIndex = 109
        Me.LblDistanciaRecorrida.Text = "Distancia recorrida :"
        '
        'LblPaisResidenciaFiscal
        '
        Me.LblPaisResidenciaFiscal.AutoSize = True
        Me.LblPaisResidenciaFiscal.Location = New System.Drawing.Point(11, 601)
        Me.LblPaisResidenciaFiscal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPaisResidenciaFiscal.Name = "LblPaisResidenciaFiscal"
        Me.LblPaisResidenciaFiscal.Size = New System.Drawing.Size(148, 17)
        Me.LblPaisResidenciaFiscal.TabIndex = 107
        Me.LblPaisResidenciaFiscal.Text = "País residencia fiscal :"
        '
        'TxtNumeroIdentificacionRegistroFiscalExtranjero
        '
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Location = New System.Drawing.Point(319, 564)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.MaxLength = 40
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Name = "TxtNumeroIdentificacionRegistroFiscalExtranjero"
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.Size = New System.Drawing.Size(290, 22)
        Me.TxtNumeroIdentificacionRegistroFiscalExtranjero.TabIndex = 8
        '
        'LblNumeroIdentificacionResgistroFiscalExtranjero
        '
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.AutoSize = True
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Location = New System.Drawing.Point(11, 567)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Name = "LblNumeroIdentificacionResgistroFiscalExtranjero"
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Size = New System.Drawing.Size(307, 17)
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.TabIndex = 104
        Me.LblNumeroIdentificacionResgistroFiscalExtranjero.Text = "Número identificación registro fiscal extranjero :"
        '
        'TxtRfcRemitenteDestinatario
        '
        Me.TxtRfcRemitenteDestinatario.Location = New System.Drawing.Point(203, 188)
        Me.TxtRfcRemitenteDestinatario.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRfcRemitenteDestinatario.MaxLength = 13
        Me.TxtRfcRemitenteDestinatario.Name = "TxtRfcRemitenteDestinatario"
        Me.TxtRfcRemitenteDestinatario.Size = New System.Drawing.Size(280, 22)
        Me.TxtRfcRemitenteDestinatario.TabIndex = 5
        '
        'LblRfcRemitenteDestinatario
        '
        Me.LblRfcRemitenteDestinatario.AutoSize = True
        Me.LblRfcRemitenteDestinatario.Location = New System.Drawing.Point(8, 191)
        Me.LblRfcRemitenteDestinatario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRfcRemitenteDestinatario.Name = "LblRfcRemitenteDestinatario"
        Me.LblRfcRemitenteDestinatario.Size = New System.Drawing.Size(184, 17)
        Me.LblRfcRemitenteDestinatario.TabIndex = 103
        Me.LblRfcRemitenteDestinatario.Text = "RFC remitente destinatario :"
        '
        'TxtNombreRemitenteDestinatario
        '
        Me.TxtNombreRemitenteDestinatario.Location = New System.Drawing.Point(8, 158)
        Me.TxtNombreRemitenteDestinatario.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreRemitenteDestinatario.MaxLength = 254
        Me.TxtNombreRemitenteDestinatario.Name = "TxtNombreRemitenteDestinatario"
        Me.TxtNombreRemitenteDestinatario.Size = New System.Drawing.Size(609, 22)
        Me.TxtNombreRemitenteDestinatario.TabIndex = 4
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
        Me.LblTipoUbicacion.Location = New System.Drawing.Point(337, 103)
        Me.LblTipoUbicacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTipoUbicacion.Name = "LblTipoUbicacion"
        Me.LblTipoUbicacion.Size = New System.Drawing.Size(108, 17)
        Me.LblTipoUbicacion.TabIndex = 99
        Me.LblTipoUbicacion.Text = "Tipo ubicación :"
        '
        'TxtIdUbicacion
        '
        Me.TxtIdUbicacion.Location = New System.Drawing.Point(140, 101)
        Me.TxtIdUbicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIdUbicacion.MaxLength = 8
        Me.TxtIdUbicacion.Name = "TxtIdUbicacion"
        Me.TxtIdUbicacion.Size = New System.Drawing.Size(169, 22)
        Me.TxtIdUbicacion.TabIndex = 3
        '
        'LblIdUbicacion
        '
        Me.LblIdUbicacion.AutoSize = True
        Me.LblIdUbicacion.Location = New System.Drawing.Point(8, 103)
        Me.LblIdUbicacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIdUbicacion.Name = "LblIdUbicacion"
        Me.LblIdUbicacion.Size = New System.Drawing.Size(93, 17)
        Me.LblIdUbicacion.TabIndex = 97
        Me.LblIdUbicacion.Text = "ID ubicación :"
        '
        'LblDisplayNombreCliente
        '
        Me.LblDisplayNombreCliente.AutoSize = True
        Me.LblDisplayNombreCliente.Location = New System.Drawing.Point(137, 78)
        Me.LblDisplayNombreCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreCliente.Name = "LblDisplayNombreCliente"
        Me.LblDisplayNombreCliente.Size = New System.Drawing.Size(16, 17)
        Me.LblDisplayNombreCliente.TabIndex = 95
        Me.LblDisplayNombreCliente.Text = "_"
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
        Me.TxtCodigoCliente.Location = New System.Drawing.Point(140, 50)
        Me.TxtCodigoCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoCliente.MaxLength = 8
        Me.TxtCodigoCliente.Name = "TxtCodigoCliente"
        Me.TxtCodigoCliente.Size = New System.Drawing.Size(152, 22)
        Me.TxtCodigoCliente.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(8, 648)
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
        Me.CboEstatus.Location = New System.Drawing.Point(99, 645)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(93, 24)
        Me.CboEstatus.TabIndex = 10
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
        Me.TxtCodigoUbicacion.Location = New System.Drawing.Point(140, 18)
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
        'Catalogo_CFDI_Ubicaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 741)
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
        Me.gb.ResumeLayout(False)
        Me.gb.PerformLayout()
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
    Friend WithEvents gb As GroupBox
    Friend WithEvents LblNombreMunicipio As System.Windows.Forms.Label
    Friend WithEvents LblNombreEstado As System.Windows.Forms.Label
    Friend WithEvents LblNombrePaisDomicilio As System.Windows.Forms.Label
    Friend WithEvents TxtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents TxtPaisDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents LblNombrePaisResidenciaFiscal As System.Windows.Forms.Label
    Friend WithEvents TxtPaisResidenciaFiscal As System.Windows.Forms.TextBox
End Class
