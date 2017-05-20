<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Cuentas_Contables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Cuentas_Contables))
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
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboPlazaParaFiltro = New System.Windows.Forms.ComboBox()
        Me.rdbNombreCuenta = New System.Windows.Forms.RadioButton()
        Me.rdbCuenta = New System.Windows.Forms.RadioButton()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.lblDisplayPlaza = New System.Windows.Forms.Label()
        Me.cboPlaza = New System.Windows.Forms.ComboBox()
        Me.lblNivel4NombreCuenta = New System.Windows.Forms.Label()
        Me.lblNivel3NombreCuenta = New System.Windows.Forms.Label()
        Me.lblNivel2NombreCuenta = New System.Windows.Forms.Label()
        Me.lblNivel1NombreCuenta = New System.Windows.Forms.Label()
        Me.cmbTipoContabilidad = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbMayor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNivel4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtNivel5 = New System.Windows.Forms.TextBox()
        Me.CmbNaturaleza = New System.Windows.Forms.ComboBox()
        Me.LblCuenta = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNivel2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNivel3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayNombreCultivo = New System.Windows.Forms.Label()
        Me.TxtNombreCuenta = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.LblDisplayCodCultivo = New System.Windows.Forms.Label()
        Me.TxtNivel1 = New System.Windows.Forms.TextBox()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbEliminar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1313, 27)
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
        'tsbEliminar
        '
        Me.tsbEliminar.Image = CType(resources.GetObject("tsbEliminar.Image"), System.Drawing.Image)
        Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminar.Name = "tsbEliminar"
        Me.tsbEliminar.Size = New System.Drawing.Size(87, 24)
        Me.tsbEliminar.Text = "&Eliminar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(91, 24)
        Me.tsbCancelar.Text = "&Regresar"
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 566)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1313, 25)
        Me.StatusStripEstado.TabIndex = 3
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
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 55)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(752, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label8)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboPlazaParaFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rdbNombreCuenta)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rdbCuenta)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(523, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(769, 514)
        Me.gBoxBusquedaRapida.TabIndex = 0
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(524, 30)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 114
        Me.Label8.Text = "Plaza :"
        '
        'cboPlazaParaFiltro
        '
        Me.cboPlazaParaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlazaParaFiltro.FormattingEnabled = True
        Me.cboPlazaParaFiltro.Location = New System.Drawing.Point(584, 23)
        Me.cboPlazaParaFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPlazaParaFiltro.Name = "cboPlazaParaFiltro"
        Me.cboPlazaParaFiltro.Size = New System.Drawing.Size(176, 24)
        Me.cboPlazaParaFiltro.TabIndex = 113
        '
        'rdbNombreCuenta
        '
        Me.rdbNombreCuenta.AutoSize = True
        Me.rdbNombreCuenta.Location = New System.Drawing.Point(248, 27)
        Me.rdbNombreCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbNombreCuenta.Name = "rdbNombreCuenta"
        Me.rdbNombreCuenta.Size = New System.Drawing.Size(204, 21)
        Me.rdbNombreCuenta.TabIndex = 110
        Me.rdbNombreCuenta.TabStop = True
        Me.rdbNombreCuenta.Text = "Nombre de cuenta contable"
        Me.rdbNombreCuenta.UseVisualStyleBackColor = True
        '
        'rdbCuenta
        '
        Me.rdbCuenta.AutoSize = True
        Me.rdbCuenta.Location = New System.Drawing.Point(8, 27)
        Me.rdbCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.rdbCuenta.Name = "rdbCuenta"
        Me.rdbCuenta.Size = New System.Drawing.Size(132, 21)
        Me.rdbCuenta.TabIndex = 109
        Me.rdbCuenta.TabStop = True
        Me.rdbCuenta.Text = "Cuenta contable"
        Me.rdbCuenta.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 89)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(753, 418)
        Me.Grid.TabIndex = 108
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayPlaza)
        Me.gBoxInformacion.Controls.Add(Me.cboPlaza)
        Me.gBoxInformacion.Controls.Add(Me.lblNivel4NombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.lblNivel3NombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.lblNivel2NombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.lblNivel1NombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.cmbTipoContabilidad)
        Me.gBoxInformacion.Controls.Add(Me.Label7)
        Me.gBoxInformacion.Controls.Add(Me.CmbMayor)
        Me.gBoxInformacion.Controls.Add(Me.Label3)
        Me.gBoxInformacion.Controls.Add(Me.TxtNivel4)
        Me.gBoxInformacion.Controls.Add(Me.Label6)
        Me.gBoxInformacion.Controls.Add(Me.TxtNivel5)
        Me.gBoxInformacion.Controls.Add(Me.CmbNaturaleza)
        Me.gBoxInformacion.Controls.Add(Me.LblCuenta)
        Me.gBoxInformacion.Controls.Add(Me.Label5)
        Me.gBoxInformacion.Controls.Add(Me.TxtNivel2)
        Me.gBoxInformacion.Controls.Add(Me.Label4)
        Me.gBoxInformacion.Controls.Add(Me.TxtNivel3)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNivel1)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(499, 514)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblDisplayPlaza
        '
        Me.lblDisplayPlaza.AutoSize = True
        Me.lblDisplayPlaza.Location = New System.Drawing.Point(9, 331)
        Me.lblDisplayPlaza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPlaza.Name = "lblDisplayPlaza"
        Me.lblDisplayPlaza.Size = New System.Drawing.Size(51, 17)
        Me.lblDisplayPlaza.TabIndex = 112
        Me.lblDisplayPlaza.Text = "Plaza :"
        '
        'cboPlaza
        '
        Me.cboPlaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlaza.FormattingEnabled = True
        Me.cboPlaza.Location = New System.Drawing.Point(141, 327)
        Me.cboPlaza.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPlaza.Name = "cboPlaza"
        Me.cboPlaza.Size = New System.Drawing.Size(176, 24)
        Me.cboPlaza.TabIndex = 9
        '
        'lblNivel4NombreCuenta
        '
        Me.lblNivel4NombreCuenta.AutoSize = True
        Me.lblNivel4NombreCuenta.Location = New System.Drawing.Point(177, 128)
        Me.lblNivel4NombreCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNivel4NombreCuenta.Name = "lblNivel4NombreCuenta"
        Me.lblNivel4NombreCuenta.Size = New System.Drawing.Size(16, 17)
        Me.lblNivel4NombreCuenta.TabIndex = 110
        Me.lblNivel4NombreCuenta.Text = "_"
        '
        'lblNivel3NombreCuenta
        '
        Me.lblNivel3NombreCuenta.AutoSize = True
        Me.lblNivel3NombreCuenta.Location = New System.Drawing.Point(177, 94)
        Me.lblNivel3NombreCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNivel3NombreCuenta.Name = "lblNivel3NombreCuenta"
        Me.lblNivel3NombreCuenta.Size = New System.Drawing.Size(16, 17)
        Me.lblNivel3NombreCuenta.TabIndex = 109
        Me.lblNivel3NombreCuenta.Text = "_"
        '
        'lblNivel2NombreCuenta
        '
        Me.lblNivel2NombreCuenta.AutoSize = True
        Me.lblNivel2NombreCuenta.Location = New System.Drawing.Point(177, 57)
        Me.lblNivel2NombreCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNivel2NombreCuenta.Name = "lblNivel2NombreCuenta"
        Me.lblNivel2NombreCuenta.Size = New System.Drawing.Size(16, 17)
        Me.lblNivel2NombreCuenta.TabIndex = 108
        Me.lblNivel2NombreCuenta.Text = "_"
        '
        'lblNivel1NombreCuenta
        '
        Me.lblNivel1NombreCuenta.AutoSize = True
        Me.lblNivel1NombreCuenta.Location = New System.Drawing.Point(177, 22)
        Me.lblNivel1NombreCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNivel1NombreCuenta.Name = "lblNivel1NombreCuenta"
        Me.lblNivel1NombreCuenta.Size = New System.Drawing.Size(16, 17)
        Me.lblNivel1NombreCuenta.TabIndex = 107
        Me.lblNivel1NombreCuenta.Text = "_"
        '
        'cmbTipoContabilidad
        '
        Me.cmbTipoContabilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoContabilidad.FormattingEnabled = True
        Me.cmbTipoContabilidad.Items.AddRange(New Object() {"MAYOR", "ACEPTA CARGOS"})
        Me.cmbTipoContabilidad.Location = New System.Drawing.Point(141, 294)
        Me.cmbTipoContabilidad.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTipoContabilidad.MaxLength = 1
        Me.cmbTipoContabilidad.Name = "cmbTipoContabilidad"
        Me.cmbTipoContabilidad.Size = New System.Drawing.Size(176, 24)
        Me.cmbTipoContabilidad.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 299)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 17)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Tipo contabilidad :"
        '
        'CmbMayor
        '
        Me.CmbMayor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMayor.FormattingEnabled = True
        Me.CmbMayor.Items.AddRange(New Object() {"MAYOR", "ACEPTA CARGOS"})
        Me.CmbMayor.Location = New System.Drawing.Point(141, 261)
        Me.CmbMayor.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbMayor.MaxLength = 1
        Me.CmbMayor.Name = "CmbMayor"
        Me.CmbMayor.Size = New System.Drawing.Size(176, 24)
        Me.CmbMayor.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 129)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Nivel4 :"
        '
        'TxtNivel4
        '
        Me.TxtNivel4.Location = New System.Drawing.Point(93, 124)
        Me.TxtNivel4.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNivel4.MaxLength = 4
        Me.TxtNivel4.Name = "TxtNivel4"
        Me.TxtNivel4.Size = New System.Drawing.Size(75, 22)
        Me.TxtNivel4.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 165)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Nivel5 :"
        '
        'TxtNivel5
        '
        Me.TxtNivel5.Location = New System.Drawing.Point(93, 160)
        Me.TxtNivel5.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNivel5.MaxLength = 4
        Me.TxtNivel5.Name = "TxtNivel5"
        Me.TxtNivel5.Size = New System.Drawing.Size(75, 22)
        Me.TxtNivel5.TabIndex = 4
        '
        'CmbNaturaleza
        '
        Me.CmbNaturaleza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNaturaleza.FormattingEnabled = True
        Me.CmbNaturaleza.Items.AddRange(New Object() {"DEUDOR", "ACREEDOR"})
        Me.CmbNaturaleza.Location = New System.Drawing.Point(141, 228)
        Me.CmbNaturaleza.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbNaturaleza.MaxLength = 1
        Me.CmbNaturaleza.Name = "CmbNaturaleza"
        Me.CmbNaturaleza.Size = New System.Drawing.Size(176, 24)
        Me.CmbNaturaleza.TabIndex = 6
        '
        'LblCuenta
        '
        Me.LblCuenta.AutoSize = True
        Me.LblCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCuenta.Location = New System.Drawing.Point(201, 155)
        Me.LblCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuenta.Name = "LblCuenta"
        Me.LblCuenta.Size = New System.Drawing.Size(27, 29)
        Me.LblCuenta.TabIndex = 100
        Me.LblCuenta.Text = "_"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 58)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 17)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Nivel2 :"
        '
        'TxtNivel2
        '
        Me.TxtNivel2.Location = New System.Drawing.Point(93, 53)
        Me.TxtNivel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNivel2.MaxLength = 4
        Me.TxtNivel2.Name = "TxtNivel2"
        Me.TxtNivel2.Size = New System.Drawing.Size(75, 22)
        Me.TxtNivel2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 94)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 17)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Nivel3 :"
        '
        'TxtNivel3
        '
        Me.TxtNivel3.Location = New System.Drawing.Point(93, 89)
        Me.TxtNivel3.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNivel3.MaxLength = 4
        Me.TxtNivel3.Name = "TxtNivel3"
        Me.TxtNivel3.Size = New System.Drawing.Size(75, 22)
        Me.TxtNivel3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 266)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Es mayor :"
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
        'LblDisplayNombreCultivo
        '
        Me.LblDisplayNombreCultivo.AutoSize = True
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(8, 201)
        Me.LblDisplayNombreCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'TxtNombreCuenta
        '
        Me.TxtNombreCuenta.Location = New System.Drawing.Point(92, 196)
        Me.TxtNombreCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreCuenta.MaxLength = 120
        Me.TxtNombreCuenta.Name = "TxtNombreCuenta"
        Me.TxtNombreCuenta.Size = New System.Drawing.Size(389, 22)
        Me.TxtNombreCuenta.TabIndex = 5
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(9, 233)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(85, 17)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Naturaleza :"
        '
        'LblDisplayCodCultivo
        '
        Me.LblDisplayCodCultivo.AutoSize = True
        Me.LblDisplayCodCultivo.Location = New System.Drawing.Point(8, 22)
        Me.LblDisplayCodCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodCultivo.Name = "LblDisplayCodCultivo"
        Me.LblDisplayCodCultivo.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayCodCultivo.TabIndex = 8
        Me.LblDisplayCodCultivo.Text = "Nivel1:"
        '
        'TxtNivel1
        '
        Me.TxtNivel1.Location = New System.Drawing.Point(93, 17)
        Me.TxtNivel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNivel1.MaxLength = 4
        Me.TxtNivel1.Name = "TxtNivel1"
        Me.TxtNivel1.Size = New System.Drawing.Size(75, 22)
        Me.TxtNivel1.TabIndex = 0
        '
        'Catalogo_Cuentas_Contables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1313, 591)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Cuentas_Contables"
        Me.ShowIcon = False
        Me.Text = "Cuentas contables"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents CmbNaturaleza As System.Windows.Forms.ComboBox
    Friend WithEvents LblCuenta As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNivel2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNivel3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNombreCuenta As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNivel1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNivel4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNivel5 As System.Windows.Forms.TextBox
    Friend WithEvents CmbMayor As System.Windows.Forms.ComboBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents rdbNombreCuenta As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCuenta As System.Windows.Forms.RadioButton
    Friend WithEvents cmbTipoContabilidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNivel4NombreCuenta As System.Windows.Forms.Label
    Friend WithEvents lblNivel3NombreCuenta As System.Windows.Forms.Label
    Friend WithEvents lblNivel2NombreCuenta As System.Windows.Forms.Label
    Friend WithEvents lblNivel1NombreCuenta As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPlaza As System.Windows.Forms.Label
    Friend WithEvents cboPlaza As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPlazaParaFiltro As System.Windows.Forms.ComboBox
End Class
