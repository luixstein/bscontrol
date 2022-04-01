<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Vehiculos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Vehiculos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.LblNombreAutransporte = New System.Windows.Forms.Label()
        Me.lblPolizaCarga = New System.Windows.Forms.Label()
        Me.txtPolizaCarga = New System.Windows.Forms.TextBox()
        Me.lblNombreAseguradoraCarga = New System.Windows.Forms.Label()
        Me.txtNombreAseguradoraCarga = New System.Windows.Forms.TextBox()
        Me.lblPolizaMedioAmbiente = New System.Windows.Forms.Label()
        Me.txtPolizaMedioAmbiente = New System.Windows.Forms.TextBox()
        Me.lblNombreAseguradoraMedioAmbiente = New System.Windows.Forms.Label()
        Me.txtNombreAseguradoraMedioAmbiente = New System.Windows.Forms.TextBox()
        Me.lblPrimaSeguro = New System.Windows.Forms.Label()
        Me.txtPrimaSeguro = New System.Windows.Forms.TextBox()
        Me.lblPolizaResponsabilidadCivil = New System.Windows.Forms.Label()
        Me.txtPolizaResponsabilidadCivil = New System.Windows.Forms.TextBox()
        Me.lblNombreAseguradoraResponsabilidadCivil = New System.Windows.Forms.Label()
        Me.txtNombreAseguradoraResponsabilidadCivil = New System.Windows.Forms.TextBox()
        Me.lblNumeroPermisoSct = New System.Windows.Forms.Label()
        Me.txtNumeroPermisoSct = New System.Windows.Forms.TextBox()
        Me.lblCodigoPermisoSct = New System.Windows.Forms.Label()
        Me.txtCodigoPermisoSct = New System.Windows.Forms.TextBox()
        Me.lblCodigoAutotransporte = New System.Windows.Forms.Label()
        Me.txtCodigoAutotransporte = New System.Windows.Forms.TextBox()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.txtAnio = New System.Windows.Forms.TextBox()
        Me.lblPlaca = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.lblTipoCategoria = New System.Windows.Forms.Label()
        Me.chkCrearCategoria = New System.Windows.Forms.CheckBox()
        Me.txtTipoCategoria = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoCategoria = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblCodigoCategoria = New System.Windows.Forms.Label()
        Me.TxtCodigoCategoria = New System.Windows.Forms.TextBox()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNombreVehiculo = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LblNombrePermisoSct = New System.Windows.Forms.Label()
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
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1085, 27)
        Me.tsMenu.TabIndex = 2
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
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label3)
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(597, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(475, 827)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(413, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 17)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Estado :"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(481, 21)
        Me.CboEstatusFiltro.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(67, 24)
        Me.CboEstatusFiltro.TabIndex = 97
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(10, 52)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(457, 767)
        Me.Grid.TabIndex = 111
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(10, 22)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(234, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 865)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1085, 25)
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
        Me.gBoxInformacion.Controls.Add(Me.LblNombrePermisoSct)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreAutransporte)
        Me.gBoxInformacion.Controls.Add(Me.lblPolizaCarga)
        Me.gBoxInformacion.Controls.Add(Me.txtPolizaCarga)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreAseguradoraCarga)
        Me.gBoxInformacion.Controls.Add(Me.txtNombreAseguradoraCarga)
        Me.gBoxInformacion.Controls.Add(Me.lblPolizaMedioAmbiente)
        Me.gBoxInformacion.Controls.Add(Me.txtPolizaMedioAmbiente)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreAseguradoraMedioAmbiente)
        Me.gBoxInformacion.Controls.Add(Me.txtNombreAseguradoraMedioAmbiente)
        Me.gBoxInformacion.Controls.Add(Me.lblPrimaSeguro)
        Me.gBoxInformacion.Controls.Add(Me.txtPrimaSeguro)
        Me.gBoxInformacion.Controls.Add(Me.lblPolizaResponsabilidadCivil)
        Me.gBoxInformacion.Controls.Add(Me.txtPolizaResponsabilidadCivil)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreAseguradoraResponsabilidadCivil)
        Me.gBoxInformacion.Controls.Add(Me.txtNombreAseguradoraResponsabilidadCivil)
        Me.gBoxInformacion.Controls.Add(Me.lblNumeroPermisoSct)
        Me.gBoxInformacion.Controls.Add(Me.txtNumeroPermisoSct)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoPermisoSct)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoPermisoSct)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoAutotransporte)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoAutotransporte)
        Me.gBoxInformacion.Controls.Add(Me.lblAnio)
        Me.gBoxInformacion.Controls.Add(Me.txtAnio)
        Me.gBoxInformacion.Controls.Add(Me.lblPlaca)
        Me.gBoxInformacion.Controls.Add(Me.txtPlaca)
        Me.gBoxInformacion.Controls.Add(Me.lblMarca)
        Me.gBoxInformacion.Controls.Add(Me.txtMarca)
        Me.gBoxInformacion.Controls.Add(Me.lblTipoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.chkCrearCategoria)
        Me.gBoxInformacion.Controls.Add(Me.txtTipoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTipoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.lblCategoria)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreVehiculo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombre)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigo)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigo)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(573, 827)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'LblNombreAutransporte
        '
        Me.LblNombreAutransporte.AutoSize = True
        Me.LblNombreAutransporte.Location = New System.Drawing.Point(15, 357)
        Me.LblNombreAutransporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreAutransporte.Name = "LblNombreAutransporte"
        Me.LblNombreAutransporte.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreAutransporte.TabIndex = 129
        Me.LblNombreAutransporte.Text = "_"
        '
        'lblPolizaCarga
        '
        Me.lblPolizaCarga.AutoSize = True
        Me.lblPolizaCarga.Location = New System.Drawing.Point(9, 728)
        Me.lblPolizaCarga.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPolizaCarga.Name = "lblPolizaCarga"
        Me.lblPolizaCarga.Size = New System.Drawing.Size(94, 17)
        Me.lblPolizaCarga.TabIndex = 128
        Me.lblPolizaCarga.Text = "Poliza carga :"
        '
        'txtPolizaCarga
        '
        Me.txtPolizaCarga.Location = New System.Drawing.Point(12, 749)
        Me.txtPolizaCarga.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPolizaCarga.MaxLength = 30
        Me.txtPolizaCarga.Name = "txtPolizaCarga"
        Me.txtPolizaCarga.Size = New System.Drawing.Size(553, 22)
        Me.txtPolizaCarga.TabIndex = 18
        '
        'lblNombreAseguradoraCarga
        '
        Me.lblNombreAseguradoraCarga.AutoSize = True
        Me.lblNombreAseguradoraCarga.Location = New System.Drawing.Point(9, 681)
        Me.lblNombreAseguradoraCarga.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreAseguradoraCarga.Name = "lblNombreAseguradoraCarga"
        Me.lblNombreAseguradoraCarga.Size = New System.Drawing.Size(191, 17)
        Me.lblNombreAseguradoraCarga.TabIndex = 126
        Me.lblNombreAseguradoraCarga.Text = "Nombre aseguradora carga :"
        '
        'txtNombreAseguradoraCarga
        '
        Me.txtNombreAseguradoraCarga.Location = New System.Drawing.Point(12, 702)
        Me.txtNombreAseguradoraCarga.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreAseguradoraCarga.MaxLength = 50
        Me.txtNombreAseguradoraCarga.Name = "txtNombreAseguradoraCarga"
        Me.txtNombreAseguradoraCarga.Size = New System.Drawing.Size(553, 22)
        Me.txtNombreAseguradoraCarga.TabIndex = 17
        '
        'lblPolizaMedioAmbiente
        '
        Me.lblPolizaMedioAmbiente.AutoSize = True
        Me.lblPolizaMedioAmbiente.Location = New System.Drawing.Point(9, 630)
        Me.lblPolizaMedioAmbiente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPolizaMedioAmbiente.Name = "lblPolizaMedioAmbiente"
        Me.lblPolizaMedioAmbiente.Size = New System.Drawing.Size(158, 17)
        Me.lblPolizaMedioAmbiente.TabIndex = 124
        Me.lblPolizaMedioAmbiente.Text = "Poliza medio ambiente :"
        '
        'txtPolizaMedioAmbiente
        '
        Me.txtPolizaMedioAmbiente.Location = New System.Drawing.Point(12, 651)
        Me.txtPolizaMedioAmbiente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPolizaMedioAmbiente.MaxLength = 30
        Me.txtPolizaMedioAmbiente.Name = "txtPolizaMedioAmbiente"
        Me.txtPolizaMedioAmbiente.Size = New System.Drawing.Size(553, 22)
        Me.txtPolizaMedioAmbiente.TabIndex = 16
        '
        'lblNombreAseguradoraMedioAmbiente
        '
        Me.lblNombreAseguradoraMedioAmbiente.AutoSize = True
        Me.lblNombreAseguradoraMedioAmbiente.Location = New System.Drawing.Point(9, 583)
        Me.lblNombreAseguradoraMedioAmbiente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreAseguradoraMedioAmbiente.Name = "lblNombreAseguradoraMedioAmbiente"
        Me.lblNombreAseguradoraMedioAmbiente.Size = New System.Drawing.Size(255, 17)
        Me.lblNombreAseguradoraMedioAmbiente.TabIndex = 122
        Me.lblNombreAseguradoraMedioAmbiente.Text = "Nombre aseguradora medio ambiente :"
        '
        'txtNombreAseguradoraMedioAmbiente
        '
        Me.txtNombreAseguradoraMedioAmbiente.Location = New System.Drawing.Point(12, 604)
        Me.txtNombreAseguradoraMedioAmbiente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreAseguradoraMedioAmbiente.MaxLength = 50
        Me.txtNombreAseguradoraMedioAmbiente.Name = "txtNombreAseguradoraMedioAmbiente"
        Me.txtNombreAseguradoraMedioAmbiente.Size = New System.Drawing.Size(553, 22)
        Me.txtNombreAseguradoraMedioAmbiente.TabIndex = 15
        '
        'lblPrimaSeguro
        '
        Me.lblPrimaSeguro.AutoSize = True
        Me.lblPrimaSeguro.Location = New System.Drawing.Point(9, 787)
        Me.lblPrimaSeguro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrimaSeguro.Name = "lblPrimaSeguro"
        Me.lblPrimaSeguro.Size = New System.Drawing.Size(100, 17)
        Me.lblPrimaSeguro.TabIndex = 120
        Me.lblPrimaSeguro.Text = "Prima seguro :"
        '
        'txtPrimaSeguro
        '
        Me.txtPrimaSeguro.Location = New System.Drawing.Point(117, 784)
        Me.txtPrimaSeguro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrimaSeguro.MaxLength = 50
        Me.txtPrimaSeguro.Name = "txtPrimaSeguro"
        Me.txtPrimaSeguro.Size = New System.Drawing.Size(209, 22)
        Me.txtPrimaSeguro.TabIndex = 19
        '
        'lblPolizaResponsabilidadCivil
        '
        Me.lblPolizaResponsabilidadCivil.AutoSize = True
        Me.lblPolizaResponsabilidadCivil.Location = New System.Drawing.Point(9, 533)
        Me.lblPolizaResponsabilidadCivil.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPolizaResponsabilidadCivil.Name = "lblPolizaResponsabilidadCivil"
        Me.lblPolizaResponsabilidadCivil.Size = New System.Drawing.Size(185, 17)
        Me.lblPolizaResponsabilidadCivil.TabIndex = 116
        Me.lblPolizaResponsabilidadCivil.Text = "Poliza responsabilidad civil :"
        '
        'txtPolizaResponsabilidadCivil
        '
        Me.txtPolizaResponsabilidadCivil.Location = New System.Drawing.Point(12, 554)
        Me.txtPolizaResponsabilidadCivil.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPolizaResponsabilidadCivil.MaxLength = 30
        Me.txtPolizaResponsabilidadCivil.Name = "txtPolizaResponsabilidadCivil"
        Me.txtPolizaResponsabilidadCivil.Size = New System.Drawing.Size(553, 22)
        Me.txtPolizaResponsabilidadCivil.TabIndex = 14
        '
        'lblNombreAseguradoraResponsabilidadCivil
        '
        Me.lblNombreAseguradoraResponsabilidadCivil.AutoSize = True
        Me.lblNombreAseguradoraResponsabilidadCivil.Location = New System.Drawing.Point(9, 486)
        Me.lblNombreAseguradoraResponsabilidadCivil.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreAseguradoraResponsabilidadCivil.Name = "lblNombreAseguradoraResponsabilidadCivil"
        Me.lblNombreAseguradoraResponsabilidadCivil.Size = New System.Drawing.Size(282, 17)
        Me.lblNombreAseguradoraResponsabilidadCivil.TabIndex = 114
        Me.lblNombreAseguradoraResponsabilidadCivil.Text = "Nombre aseguradora responsabilidad civil :"
        '
        'txtNombreAseguradoraResponsabilidadCivil
        '
        Me.txtNombreAseguradoraResponsabilidadCivil.Location = New System.Drawing.Point(12, 507)
        Me.txtNombreAseguradoraResponsabilidadCivil.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreAseguradoraResponsabilidadCivil.MaxLength = 50
        Me.txtNombreAseguradoraResponsabilidadCivil.Name = "txtNombreAseguradoraResponsabilidadCivil"
        Me.txtNombreAseguradoraResponsabilidadCivil.Size = New System.Drawing.Size(553, 22)
        Me.txtNombreAseguradoraResponsabilidadCivil.TabIndex = 13
        '
        'lblNumeroPermisoSct
        '
        Me.lblNumeroPermisoSct.AutoSize = True
        Me.lblNumeroPermisoSct.Location = New System.Drawing.Point(8, 439)
        Me.lblNumeroPermisoSct.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumeroPermisoSct.Name = "lblNumeroPermisoSct"
        Me.lblNumeroPermisoSct.Size = New System.Drawing.Size(151, 17)
        Me.lblNumeroPermisoSct.TabIndex = 112
        Me.lblNumeroPermisoSct.Text = "Número permiso SCT :"
        '
        'txtNumeroPermisoSct
        '
        Me.txtNumeroPermisoSct.Location = New System.Drawing.Point(12, 460)
        Me.txtNumeroPermisoSct.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumeroPermisoSct.MaxLength = 50
        Me.txtNumeroPermisoSct.Name = "txtNumeroPermisoSct"
        Me.txtNumeroPermisoSct.Size = New System.Drawing.Size(553, 22)
        Me.txtNumeroPermisoSct.TabIndex = 12
        '
        'lblCodigoPermisoSct
        '
        Me.lblCodigoPermisoSct.AutoSize = True
        Me.lblCodigoPermisoSct.Location = New System.Drawing.Point(9, 387)
        Me.lblCodigoPermisoSct.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoPermisoSct.Name = "lblCodigoPermisoSct"
        Me.lblCodigoPermisoSct.Size = New System.Drawing.Size(145, 17)
        Me.lblCodigoPermisoSct.TabIndex = 110
        Me.lblCodigoPermisoSct.Text = "Código permiso SCT :"
        '
        'txtCodigoPermisoSct
        '
        Me.txtCodigoPermisoSct.Location = New System.Drawing.Point(173, 384)
        Me.txtCodigoPermisoSct.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoPermisoSct.MaxLength = 10
        Me.txtCodigoPermisoSct.Name = "txtCodigoPermisoSct"
        Me.txtCodigoPermisoSct.Size = New System.Drawing.Size(194, 22)
        Me.txtCodigoPermisoSct.TabIndex = 11
        '
        'lblCodigoAutotransporte
        '
        Me.lblCodigoAutotransporte.AutoSize = True
        Me.lblCodigoAutotransporte.Location = New System.Drawing.Point(8, 331)
        Me.lblCodigoAutotransporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoAutotransporte.Name = "lblCodigoAutotransporte"
        Me.lblCodigoAutotransporte.Size = New System.Drawing.Size(157, 17)
        Me.lblCodigoAutotransporte.TabIndex = 108
        Me.lblCodigoAutotransporte.Text = "Código autotransporte :"
        '
        'txtCodigoAutotransporte
        '
        Me.txtCodigoAutotransporte.Location = New System.Drawing.Point(173, 328)
        Me.txtCodigoAutotransporte.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoAutotransporte.MaxLength = 10
        Me.txtCodigoAutotransporte.Name = "txtCodigoAutotransporte"
        Me.txtCodigoAutotransporte.Size = New System.Drawing.Size(169, 22)
        Me.txtCodigoAutotransporte.TabIndex = 10
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(232, 295)
        Me.lblAnio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(41, 17)
        Me.lblAnio.TabIndex = 106
        Me.lblAnio.Text = "Año :"
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(281, 292)
        Me.txtAnio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAnio.MaxLength = 4
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(105, 22)
        Me.txtAnio.TabIndex = 9
        '
        'lblPlaca
        '
        Me.lblPlaca.AutoSize = True
        Me.lblPlaca.Location = New System.Drawing.Point(9, 295)
        Me.lblPlaca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlaca.Name = "lblPlaca"
        Me.lblPlaca.Size = New System.Drawing.Size(51, 17)
        Me.lblPlaca.TabIndex = 104
        Me.lblPlaca.Text = "Placa :"
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(68, 292)
        Me.txtPlaca.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlaca.MaxLength = 7
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(141, 22)
        Me.txtPlaca.TabIndex = 8
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(9, 264)
        Me.lblMarca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(55, 17)
        Me.lblMarca.TabIndex = 102
        Me.lblMarca.Text = "Marca :"
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(70, 261)
        Me.txtMarca.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMarca.MaxLength = 30
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(139, 22)
        Me.txtMarca.TabIndex = 7
        '
        'lblTipoCategoria
        '
        Me.lblTipoCategoria.AutoSize = True
        Me.lblTipoCategoria.Location = New System.Drawing.Point(139, 220)
        Me.lblTipoCategoria.Name = "lblTipoCategoria"
        Me.lblTipoCategoria.Size = New System.Drawing.Size(16, 17)
        Me.lblTipoCategoria.TabIndex = 100
        Me.lblTipoCategoria.Text = "_"
        Me.lblTipoCategoria.Visible = False
        '
        'chkCrearCategoria
        '
        Me.chkCrearCategoria.AutoSize = True
        Me.chkCrearCategoria.Location = New System.Drawing.Point(12, 164)
        Me.chkCrearCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCrearCategoria.Name = "chkCrearCategoria"
        Me.chkCrearCategoria.Size = New System.Drawing.Size(252, 21)
        Me.chkCrearCategoria.TabIndex = 5
        Me.chkCrearCategoria.Text = "Crear categoría automáticamente ?"
        Me.chkCrearCategoria.UseVisualStyleBackColor = True
        '
        'txtTipoCategoria
        '
        Me.txtTipoCategoria.Location = New System.Drawing.Point(139, 192)
        Me.txtTipoCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoCategoria.MaxLength = 30
        Me.txtTipoCategoria.Name = "txtTipoCategoria"
        Me.txtTipoCategoria.Size = New System.Drawing.Size(111, 22)
        Me.txtTipoCategoria.TabIndex = 6
        Me.txtTipoCategoria.Visible = False
        '
        'lblDisplayTipoCategoria
        '
        Me.lblDisplayTipoCategoria.AutoSize = True
        Me.lblDisplayTipoCategoria.Location = New System.Drawing.Point(8, 194)
        Me.lblDisplayTipoCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoCategoria.Name = "lblDisplayTipoCategoria"
        Me.lblDisplayTipoCategoria.Size = New System.Drawing.Size(127, 17)
        Me.lblDisplayTipoCategoria.TabIndex = 99
        Me.lblDisplayTipoCategoria.Text = "Tipo de categoría :"
        Me.lblDisplayTipoCategoria.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 84)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Estatus :"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Location = New System.Drawing.Point(101, 144)
        Me.lblCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(16, 17)
        Me.lblCategoria.TabIndex = 4
        Me.lblCategoria.Text = "_"
        '
        'lblCodigoCategoria
        '
        Me.lblCodigoCategoria.AutoSize = True
        Me.lblCodigoCategoria.Location = New System.Drawing.Point(8, 117)
        Me.lblCodigoCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoCategoria.Name = "lblCodigoCategoria"
        Me.lblCodigoCategoria.Size = New System.Drawing.Size(77, 17)
        Me.lblCodigoCategoria.TabIndex = 94
        Me.lblCodigoCategoria.Text = "Categoría :"
        '
        'TxtCodigoCategoria
        '
        Me.TxtCodigoCategoria.Location = New System.Drawing.Point(103, 113)
        Me.TxtCodigoCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoCategoria.MaxLength = 2
        Me.TxtCodigoCategoria.Name = "TxtCodigoCategoria"
        Me.TxtCodigoCategoria.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoCategoria.TabIndex = 3
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(101, 81)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(100, 24)
        Me.CboEstatus.TabIndex = 2
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
        'LblNombreVehiculo
        '
        Me.LblNombreVehiculo.AutoSize = True
        Me.LblNombreVehiculo.Location = New System.Drawing.Point(8, 54)
        Me.LblNombreVehiculo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreVehiculo.Name = "LblNombreVehiculo"
        Me.LblNombreVehiculo.Size = New System.Drawing.Size(66, 17)
        Me.LblNombreVehiculo.TabIndex = 74
        Me.LblNombreVehiculo.Text = "Nombre :"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(103, 50)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(301, 22)
        Me.TxtNombre.TabIndex = 1
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
        Me.TxtCodigo.Location = New System.Drawing.Point(101, 18)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigo.MaxLength = 2
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigo.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'LblNombrePermisoSct
        '
        Me.LblNombrePermisoSct.AutoSize = True
        Me.LblNombrePermisoSct.Location = New System.Drawing.Point(15, 415)
        Me.LblNombrePermisoSct.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombrePermisoSct.Name = "LblNombrePermisoSct"
        Me.LblNombrePermisoSct.Size = New System.Drawing.Size(16, 17)
        Me.LblNombrePermisoSct.TabIndex = 130
        Me.LblNombrePermisoSct.Text = "_"
        '
        'Catalogo_Vehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 890)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Vehiculos"
        Me.ShowIcon = False
        Me.Text = "Catálogo vehículos"
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
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblNombreVehiculo As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents lblCodigoCategoria As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCategoria As System.Windows.Forms.TextBox
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoCategoria As System.Windows.Forms.Label
    Friend WithEvents chkCrearCategoria As System.Windows.Forms.CheckBox
    Friend WithEvents txtTipoCategoria As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTipoCategoria As System.Windows.Forms.Label
    Friend WithEvents lblPolizaCarga As System.Windows.Forms.Label
    Friend WithEvents txtPolizaCarga As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreAseguradoraCarga As System.Windows.Forms.Label
    Friend WithEvents txtNombreAseguradoraCarga As System.Windows.Forms.TextBox
    Friend WithEvents lblPolizaMedioAmbiente As System.Windows.Forms.Label
    Friend WithEvents txtPolizaMedioAmbiente As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreAseguradoraMedioAmbiente As System.Windows.Forms.Label
    Friend WithEvents txtNombreAseguradoraMedioAmbiente As System.Windows.Forms.TextBox
    Friend WithEvents lblPrimaSeguro As System.Windows.Forms.Label
    Friend WithEvents txtPrimaSeguro As System.Windows.Forms.TextBox
    Friend WithEvents lblPolizaResponsabilidadCivil As System.Windows.Forms.Label
    Friend WithEvents txtPolizaResponsabilidadCivil As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreAseguradoraResponsabilidadCivil As System.Windows.Forms.Label
    Friend WithEvents txtNombreAseguradoraResponsabilidadCivil As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroPermisoSct As System.Windows.Forms.Label
    Friend WithEvents txtNumeroPermisoSct As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoPermisoSct As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPermisoSct As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoAutotransporte As System.Windows.Forms.Label
    Friend WithEvents txtCodigoAutotransporte As System.Windows.Forms.TextBox
    Friend WithEvents lblAnio As System.Windows.Forms.Label
    Friend WithEvents txtAnio As System.Windows.Forms.TextBox
    Friend WithEvents lblPlaca As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreAutransporte As System.Windows.Forms.Label
    Friend WithEvents LblNombrePermisoSct As System.Windows.Forms.Label
End Class
