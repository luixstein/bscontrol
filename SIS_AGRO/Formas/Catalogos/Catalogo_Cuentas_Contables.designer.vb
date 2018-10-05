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
        Me.cboFiltroCodigoAgrupador = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboPlazaParaFiltro = New System.Windows.Forms.ComboBox()
        Me.rdbNombreCuenta = New System.Windows.Forms.RadioButton()
        Me.rdbCuenta = New System.Windows.Forms.RadioButton()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.btnActualizarCodigoAgrupador = New System.Windows.Forms.Button()
        Me.lblDisplayPlaza = New System.Windows.Forms.Label()
        Me.chkClonarCodigoAgrupador = New System.Windows.Forms.CheckBox()
        Me.cboPlaza = New System.Windows.Forms.ComboBox()
        Me.lblNombreCuentaSAT = New System.Windows.Forms.Label()
        Me.lblNivel4NombreCuenta = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCodigoAgrupador = New System.Windows.Forms.TextBox()
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
        Me.tsMenu.Size = New System.Drawing.Size(1213, 27)
        Me.tsMenu.TabIndex = 2
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
        Me.tsbEliminar.Text = "&Eliminar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 24)
        Me.tsbCancelar.Text = "&Regresar"
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 573)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1213, 22)
        Me.StatusStripEstado.TabIndex = 3
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
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(6, 45)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(797, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboFiltroCodigoAgrupador)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label9)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label8)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboPlazaParaFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rdbNombreCuenta)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rdbCuenta)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(392, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(809, 533)
        Me.gBoxBusquedaRapida.TabIndex = 0
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'cboFiltroCodigoAgrupador
        '
        Me.cboFiltroCodigoAgrupador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFiltroCodigoAgrupador.FormattingEnabled = True
        Me.cboFiltroCodigoAgrupador.Location = New System.Drawing.Point(628, 19)
        Me.cboFiltroCodigoAgrupador.Name = "cboFiltroCodigoAgrupador"
        Me.cboFiltroCodigoAgrupador.Size = New System.Drawing.Size(175, 21)
        Me.cboFiltroCodigoAgrupador.TabIndex = 118
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(501, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 117
        Me.Label9.Text = "Filtro código agrupador :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(269, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 114
        Me.Label8.Text = "Plaza :"
        '
        'cboPlazaParaFiltro
        '
        Me.cboPlazaParaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlazaParaFiltro.FormattingEnabled = True
        Me.cboPlazaParaFiltro.Location = New System.Drawing.Point(314, 19)
        Me.cboPlazaParaFiltro.Name = "cboPlazaParaFiltro"
        Me.cboPlazaParaFiltro.Size = New System.Drawing.Size(133, 21)
        Me.cboPlazaParaFiltro.TabIndex = 113
        '
        'rdbNombreCuenta
        '
        Me.rdbNombreCuenta.AutoSize = True
        Me.rdbNombreCuenta.Location = New System.Drawing.Point(106, 23)
        Me.rdbNombreCuenta.Name = "rdbNombreCuenta"
        Me.rdbNombreCuenta.Size = New System.Drawing.Size(157, 17)
        Me.rdbNombreCuenta.TabIndex = 110
        Me.rdbNombreCuenta.TabStop = True
        Me.rdbNombreCuenta.Text = "Nombre de cuenta contable"
        Me.rdbNombreCuenta.UseVisualStyleBackColor = True
        '
        'rdbCuenta
        '
        Me.rdbCuenta.AutoSize = True
        Me.rdbCuenta.Location = New System.Drawing.Point(6, 22)
        Me.rdbCuenta.Name = "rdbCuenta"
        Me.rdbCuenta.Size = New System.Drawing.Size(103, 17)
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
        Me.Grid.Location = New System.Drawing.Point(6, 72)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(797, 455)
        Me.Grid.TabIndex = 108
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.btnActualizarCodigoAgrupador)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayPlaza)
        Me.gBoxInformacion.Controls.Add(Me.chkClonarCodigoAgrupador)
        Me.gBoxInformacion.Controls.Add(Me.cboPlaza)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreCuentaSAT)
        Me.gBoxInformacion.Controls.Add(Me.lblNivel4NombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.Label10)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoAgrupador)
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
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(374, 533)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'btnActualizarCodigoAgrupador
        '
        Me.btnActualizarCodigoAgrupador.Location = New System.Drawing.Point(80, 372)
        Me.btnActualizarCodigoAgrupador.Name = "btnActualizarCodigoAgrupador"
        Me.btnActualizarCodigoAgrupador.Size = New System.Drawing.Size(190, 23)
        Me.btnActualizarCodigoAgrupador.TabIndex = 12
        Me.btnActualizarCodigoAgrupador.Text = "Actualizar código agrupador"
        Me.btnActualizarCodigoAgrupador.UseVisualStyleBackColor = True
        Me.btnActualizarCodigoAgrupador.Visible = False
        '
        'lblDisplayPlaza
        '
        Me.lblDisplayPlaza.AutoSize = True
        Me.lblDisplayPlaza.Location = New System.Drawing.Point(7, 269)
        Me.lblDisplayPlaza.Name = "lblDisplayPlaza"
        Me.lblDisplayPlaza.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayPlaza.TabIndex = 112
        Me.lblDisplayPlaza.Text = "Plaza :"
        '
        'chkClonarCodigoAgrupador
        '
        Me.chkClonarCodigoAgrupador.AutoSize = True
        Me.chkClonarCodigoAgrupador.Location = New System.Drawing.Point(10, 349)
        Me.chkClonarCodigoAgrupador.Name = "chkClonarCodigoAgrupador"
        Me.chkClonarCodigoAgrupador.Size = New System.Drawing.Size(309, 17)
        Me.chkClonarCodigoAgrupador.TabIndex = 11
        Me.chkClonarCodigoAgrupador.Text = "Establecer mismo código agrupador a las cuentas hermanas"
        Me.chkClonarCodigoAgrupador.UseVisualStyleBackColor = True
        '
        'cboPlaza
        '
        Me.cboPlaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlaza.FormattingEnabled = True
        Me.cboPlaza.Location = New System.Drawing.Point(106, 266)
        Me.cboPlaza.Name = "cboPlaza"
        Me.cboPlaza.Size = New System.Drawing.Size(133, 21)
        Me.cboPlaza.TabIndex = 9
        '
        'lblNombreCuentaSAT
        '
        Me.lblNombreCuentaSAT.AutoSize = True
        Me.lblNombreCuentaSAT.Location = New System.Drawing.Point(133, 309)
        Me.lblNombreCuentaSAT.Name = "lblNombreCuentaSAT"
        Me.lblNombreCuentaSAT.Size = New System.Drawing.Size(13, 13)
        Me.lblNombreCuentaSAT.TabIndex = 120
        Me.lblNombreCuentaSAT.Text = "_"
        '
        'lblNivel4NombreCuenta
        '
        Me.lblNivel4NombreCuenta.AutoSize = True
        Me.lblNivel4NombreCuenta.Location = New System.Drawing.Point(133, 104)
        Me.lblNivel4NombreCuenta.Name = "lblNivel4NombreCuenta"
        Me.lblNivel4NombreCuenta.Size = New System.Drawing.Size(13, 13)
        Me.lblNivel4NombreCuenta.TabIndex = 110
        Me.lblNivel4NombreCuenta.Text = "_"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 41)
        Me.Label10.TabIndex = 119
        Me.Label10.Text = "Código agrupador SAT :"
        '
        'txtCodigoAgrupador
        '
        Me.txtCodigoAgrupador.Location = New System.Drawing.Point(70, 306)
        Me.txtCodigoAgrupador.MaxLength = 10
        Me.txtCodigoAgrupador.Name = "txtCodigoAgrupador"
        Me.txtCodigoAgrupador.Size = New System.Drawing.Size(57, 20)
        Me.txtCodigoAgrupador.TabIndex = 10
        '
        'lblNivel3NombreCuenta
        '
        Me.lblNivel3NombreCuenta.AutoSize = True
        Me.lblNivel3NombreCuenta.Location = New System.Drawing.Point(133, 76)
        Me.lblNivel3NombreCuenta.Name = "lblNivel3NombreCuenta"
        Me.lblNivel3NombreCuenta.Size = New System.Drawing.Size(13, 13)
        Me.lblNivel3NombreCuenta.TabIndex = 109
        Me.lblNivel3NombreCuenta.Text = "_"
        '
        'lblNivel2NombreCuenta
        '
        Me.lblNivel2NombreCuenta.AutoSize = True
        Me.lblNivel2NombreCuenta.Location = New System.Drawing.Point(133, 46)
        Me.lblNivel2NombreCuenta.Name = "lblNivel2NombreCuenta"
        Me.lblNivel2NombreCuenta.Size = New System.Drawing.Size(13, 13)
        Me.lblNivel2NombreCuenta.TabIndex = 108
        Me.lblNivel2NombreCuenta.Text = "_"
        '
        'lblNivel1NombreCuenta
        '
        Me.lblNivel1NombreCuenta.AutoSize = True
        Me.lblNivel1NombreCuenta.Location = New System.Drawing.Point(133, 18)
        Me.lblNivel1NombreCuenta.Name = "lblNivel1NombreCuenta"
        Me.lblNivel1NombreCuenta.Size = New System.Drawing.Size(13, 13)
        Me.lblNivel1NombreCuenta.TabIndex = 107
        Me.lblNivel1NombreCuenta.Text = "_"
        '
        'cmbTipoContabilidad
        '
        Me.cmbTipoContabilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoContabilidad.FormattingEnabled = True
        Me.cmbTipoContabilidad.Items.AddRange(New Object() {"MAYOR", "ACEPTA CARGOS"})
        Me.cmbTipoContabilidad.Location = New System.Drawing.Point(106, 239)
        Me.cmbTipoContabilidad.MaxLength = 1
        Me.cmbTipoContabilidad.Name = "cmbTipoContabilidad"
        Me.cmbTipoContabilidad.Size = New System.Drawing.Size(133, 21)
        Me.cmbTipoContabilidad.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Tipo contabilidad :"
        '
        'CmbMayor
        '
        Me.CmbMayor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMayor.FormattingEnabled = True
        Me.CmbMayor.Items.AddRange(New Object() {"MAYOR", "ACEPTA CARGOS"})
        Me.CmbMayor.Location = New System.Drawing.Point(106, 212)
        Me.CmbMayor.MaxLength = 1
        Me.CmbMayor.Name = "CmbMayor"
        Me.CmbMayor.Size = New System.Drawing.Size(133, 21)
        Me.CmbMayor.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Nivel4 :"
        '
        'TxtNivel4
        '
        Me.TxtNivel4.Location = New System.Drawing.Point(70, 101)
        Me.TxtNivel4.MaxLength = 4
        Me.TxtNivel4.Name = "TxtNivel4"
        Me.TxtNivel4.Size = New System.Drawing.Size(57, 20)
        Me.TxtNivel4.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Nivel5 :"
        '
        'TxtNivel5
        '
        Me.TxtNivel5.Location = New System.Drawing.Point(70, 130)
        Me.TxtNivel5.MaxLength = 4
        Me.TxtNivel5.Name = "TxtNivel5"
        Me.TxtNivel5.Size = New System.Drawing.Size(57, 20)
        Me.TxtNivel5.TabIndex = 4
        '
        'CmbNaturaleza
        '
        Me.CmbNaturaleza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbNaturaleza.FormattingEnabled = True
        Me.CmbNaturaleza.Items.AddRange(New Object() {"DEUDOR", "ACREEDOR"})
        Me.CmbNaturaleza.Location = New System.Drawing.Point(106, 185)
        Me.CmbNaturaleza.MaxLength = 1
        Me.CmbNaturaleza.Name = "CmbNaturaleza"
        Me.CmbNaturaleza.Size = New System.Drawing.Size(133, 21)
        Me.CmbNaturaleza.TabIndex = 6
        '
        'LblCuenta
        '
        Me.LblCuenta.AutoSize = True
        Me.LblCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCuenta.Location = New System.Drawing.Point(151, 126)
        Me.LblCuenta.Name = "LblCuenta"
        Me.LblCuenta.Size = New System.Drawing.Size(21, 24)
        Me.LblCuenta.TabIndex = 100
        Me.LblCuenta.Text = "_"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Nivel2 :"
        '
        'TxtNivel2
        '
        Me.TxtNivel2.Location = New System.Drawing.Point(70, 43)
        Me.TxtNivel2.MaxLength = 4
        Me.TxtNivel2.Name = "TxtNivel2"
        Me.TxtNivel2.Size = New System.Drawing.Size(57, 20)
        Me.TxtNivel2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Nivel3 :"
        '
        'TxtNivel3
        '
        Me.TxtNivel3.Location = New System.Drawing.Point(70, 72)
        Me.TxtNivel3.MaxLength = 4
        Me.TxtNivel3.Name = "TxtNivel3"
        Me.TxtNivel3.Size = New System.Drawing.Size(57, 20)
        Me.TxtNivel3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 216)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Es mayor :"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'LblDisplayNombreCultivo
        '
        Me.LblDisplayNombreCultivo.AutoSize = True
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(6, 163)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'TxtNombreCuenta
        '
        Me.TxtNombreCuenta.Location = New System.Drawing.Point(69, 159)
        Me.TxtNombreCuenta.MaxLength = 120
        Me.TxtNombreCuenta.Name = "TxtNombreCuenta"
        Me.TxtNombreCuenta.Size = New System.Drawing.Size(293, 20)
        Me.TxtNombreCuenta.TabIndex = 5
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(7, 189)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(64, 13)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Naturaleza :"
        '
        'LblDisplayCodCultivo
        '
        Me.LblDisplayCodCultivo.AutoSize = True
        Me.LblDisplayCodCultivo.Location = New System.Drawing.Point(6, 18)
        Me.LblDisplayCodCultivo.Name = "LblDisplayCodCultivo"
        Me.LblDisplayCodCultivo.Size = New System.Drawing.Size(40, 13)
        Me.LblDisplayCodCultivo.TabIndex = 8
        Me.LblDisplayCodCultivo.Text = "Nivel1:"
        '
        'TxtNivel1
        '
        Me.TxtNivel1.Location = New System.Drawing.Point(70, 14)
        Me.TxtNivel1.MaxLength = 4
        Me.TxtNivel1.Name = "TxtNivel1"
        Me.TxtNivel1.Size = New System.Drawing.Size(57, 20)
        Me.TxtNivel1.TabIndex = 0
        '
        'Catalogo_Cuentas_Contables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1213, 595)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
    Friend WithEvents btnActualizarCodigoAgrupador As Button
    Friend WithEvents chkClonarCodigoAgrupador As CheckBox
    Friend WithEvents lblNombreCuentaSAT As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCodigoAgrupador As TextBox
    Friend WithEvents cboFiltroCodigoAgrupador As ComboBox
    Friend WithEvents Label9 As Label
End Class
