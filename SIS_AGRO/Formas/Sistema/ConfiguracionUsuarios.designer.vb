<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionUsuarios))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.lstbElementos = New System.Windows.Forms.ListBox()
        Me.gbInformacion = New System.Windows.Forms.GroupBox()
        Me.gpVendedor = New System.Windows.Forms.GroupBox()
        Me.txtCodigoVendedor = New System.Windows.Forms.TextBox()
        Me.lblNombreVendedor = New System.Windows.Forms.Label()
        Me.gbCorreo = New System.Windows.Forms.GroupBox()
        Me.btnActualizarCorreo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClaveCorreo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCorreoUsuario = New System.Windows.Forms.TextBox()
        Me.tcPanelPermisos = New System.Windows.Forms.TabControl()
        Me.TpPermisosMenus = New System.Windows.Forms.TabPage()
        Me.gbControlMenus = New System.Windows.Forms.GroupBox()
        Me.TreeViewMenus = New System.Windows.Forms.TreeView()
        Me.TpPermisosDocumentos = New System.Windows.Forms.TabPage()
        Me.lblDisplayPlazaPermiso = New System.Windows.Forms.Label()
        Me.gbDocumentosConAfectacionInventarios = New System.Windows.Forms.GroupBox()
        Me.LstVDocumentos1 = New System.Windows.Forms.ListView()
        Me.LstVDocumentos2 = New System.Windows.Forms.ListView()
        Me.lblDisplayAlmacenPermiso = New System.Windows.Forms.Label()
        Me.CboAlmacen2 = New System.Windows.Forms.ComboBox()
        Me.BtnQuitar1 = New System.Windows.Forms.Button()
        Me.BtnAgregar1 = New System.Windows.Forms.Button()
        Me.CboPlazasPermiso = New System.Windows.Forms.ComboBox()
        Me.gbDocumentosSinAfectacionInventarios = New System.Windows.Forms.GroupBox()
        Me.LstVDocumentos4 = New System.Windows.Forms.ListView()
        Me.LstVDocumentos3 = New System.Windows.Forms.ListView()
        Me.BtnAgregar2 = New System.Windows.Forms.Button()
        Me.BtnQuitar2 = New System.Windows.Forms.Button()
        Me.CboModulos = New System.Windows.Forms.ComboBox()
        Me.lblDisplayModulo = New System.Windows.Forms.Label()
        Me.TpPermisosTiposDocumentos = New System.Windows.Forms.TabPage()
        Me.gbTipoDocumentosConAfectacionInventarios = New System.Windows.Forms.GroupBox()
        Me.LstVDocumentos5 = New System.Windows.Forms.ListView()
        Me.LstVDocumentos6 = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboAlmacen3 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboAlmacen4 = New System.Windows.Forms.ComboBox()
        Me.CboModulos2 = New System.Windows.Forms.ComboBox()
        Me.lblDisplayModulo3 = New System.Windows.Forms.Label()
        Me.BtnAgregar3 = New System.Windows.Forms.Button()
        Me.BtnQuitar3 = New System.Windows.Forms.Button()
        Me.TpPermisosControl = New System.Windows.Forms.TabPage()
        Me.ckbVerCostos = New System.Windows.Forms.CheckBox()
        Me.CkbAdmonCreditos = New System.Windows.Forms.CheckBox()
        Me.CkbAdministrador = New System.Windows.Forms.CheckBox()
        Me.CkbArmadoPalet = New System.Windows.Forms.CheckBox()
        Me.ckbCuentas = New System.Windows.Forms.CheckBox()
        Me.CkbClientes = New System.Windows.Forms.CheckBox()
        Me.ckbArticulos = New System.Windows.Forms.CheckBox()
        Me.gbContraseña = New System.Windows.Forms.GroupBox()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        Me.BtnRecurperar = New System.Windows.Forms.Button()
        Me.lblDisplayConfirmarClave = New System.Windows.Forms.Label()
        Me.TxtConfirmaClave = New System.Windows.Forms.TextBox()
        Me.lblDisplayClave = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.gbImportar = New System.Windows.Forms.GroupBox()
        Me.TxtNombreUsuarioImportar = New System.Windows.Forms.Label()
        Me.BtnImportar = New System.Windows.Forms.Button()
        Me.TxtCodigoUsuarioImporta = New System.Windows.Forms.TextBox()
        Me.lblDisplayImportarPermisos = New System.Windows.Forms.Label()
        Me.lblDisplayAlamcen = New System.Windows.Forms.Label()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.lblDisplayPlaza = New System.Windows.Forms.Label()
        Me.cboPlazas = New System.Windows.Forms.ComboBox()
        Me.LblNombreUsuario = New System.Windows.Forms.Label()
        Me.TxtNombreUsuario = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodUsuario = New System.Windows.Forms.Label()
        Me.TxtCodigoUsuario = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblDisplayDepartamento = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        Me.gbInformacion.SuspendLayout()
        Me.gpVendedor.SuspendLayout()
        Me.gbCorreo.SuspendLayout()
        Me.tcPanelPermisos.SuspendLayout()
        Me.TpPermisosMenus.SuspendLayout()
        Me.gbControlMenus.SuspendLayout()
        Me.TpPermisosDocumentos.SuspendLayout()
        Me.gbDocumentosConAfectacionInventarios.SuspendLayout()
        Me.gbDocumentosSinAfectacionInventarios.SuspendLayout()
        Me.TpPermisosTiposDocumentos.SuspendLayout()
        Me.gbTipoDocumentosConAfectacionInventarios.SuspendLayout()
        Me.TpPermisosControl.SuspendLayout()
        Me.gbContraseña.SuspendLayout()
        Me.gbImportar.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1158, 27)
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
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.lstbElementos)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(964, 39)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(189, 504)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(177, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'lstbElementos
        '
        Me.lstbElementos.FormattingEnabled = True
        Me.lstbElementos.Location = New System.Drawing.Point(6, 45)
        Me.lstbElementos.Name = "lstbElementos"
        Me.lstbElementos.Size = New System.Drawing.Size(178, 446)
        Me.lstbElementos.TabIndex = 1
        '
        'gbInformacion
        '
        Me.gbInformacion.Controls.Add(Me.txtDepartamento)
        Me.gbInformacion.Controls.Add(Me.lblDisplayDepartamento)
        Me.gbInformacion.Controls.Add(Me.lblDepartamento)
        Me.gbInformacion.Controls.Add(Me.gpVendedor)
        Me.gbInformacion.Controls.Add(Me.gbCorreo)
        Me.gbInformacion.Controls.Add(Me.LblEstatus)
        Me.gbInformacion.Controls.Add(Me.CboEstatus)
        Me.gbInformacion.Controls.Add(Me.tcPanelPermisos)
        Me.gbInformacion.Controls.Add(Me.gbContraseña)
        Me.gbInformacion.Controls.Add(Me.gbImportar)
        Me.gbInformacion.Controls.Add(Me.lblDisplayAlamcen)
        Me.gbInformacion.Controls.Add(Me.CboAlmacen)
        Me.gbInformacion.Controls.Add(Me.lblDisplayPlaza)
        Me.gbInformacion.Controls.Add(Me.cboPlazas)
        Me.gbInformacion.Controls.Add(Me.LblNombreUsuario)
        Me.gbInformacion.Controls.Add(Me.TxtNombreUsuario)
        Me.gbInformacion.Controls.Add(Me.LblDisplayCodUsuario)
        Me.gbInformacion.Controls.Add(Me.TxtCodigoUsuario)
        Me.gbInformacion.Location = New System.Drawing.Point(12, 39)
        Me.gbInformacion.Name = "gbInformacion"
        Me.gbInformacion.Size = New System.Drawing.Size(946, 504)
        Me.gbInformacion.TabIndex = 0
        Me.gbInformacion.TabStop = False
        Me.gbInformacion.Text = "Usuario"
        '
        'gpVendedor
        '
        Me.gpVendedor.Controls.Add(Me.txtCodigoVendedor)
        Me.gpVendedor.Controls.Add(Me.lblNombreVendedor)
        Me.gpVendedor.Location = New System.Drawing.Point(9, 397)
        Me.gpVendedor.Margin = New System.Windows.Forms.Padding(2)
        Me.gpVendedor.Name = "gpVendedor"
        Me.gpVendedor.Padding = New System.Windows.Forms.Padding(2)
        Me.gpVendedor.Size = New System.Drawing.Size(255, 51)
        Me.gpVendedor.TabIndex = 9
        Me.gpVendedor.TabStop = False
        Me.gpVendedor.Text = "Vendedor"
        '
        'txtCodigoVendedor
        '
        Me.txtCodigoVendedor.Location = New System.Drawing.Point(5, 18)
        Me.txtCodigoVendedor.MaxLength = 60
        Me.txtCodigoVendedor.Name = "txtCodigoVendedor"
        Me.txtCodigoVendedor.Size = New System.Drawing.Size(75, 20)
        Me.txtCodigoVendedor.TabIndex = 116
        '
        'lblNombreVendedor
        '
        Me.lblNombreVendedor.AutoSize = True
        Me.lblNombreVendedor.Location = New System.Drawing.Point(86, 21)
        Me.lblNombreVendedor.Name = "lblNombreVendedor"
        Me.lblNombreVendedor.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreVendedor.TabIndex = 114
        Me.lblNombreVendedor.Text = "."
        '
        'gbCorreo
        '
        Me.gbCorreo.Controls.Add(Me.btnActualizarCorreo)
        Me.gbCorreo.Controls.Add(Me.Label1)
        Me.gbCorreo.Controls.Add(Me.txtClaveCorreo)
        Me.gbCorreo.Controls.Add(Me.Label4)
        Me.gbCorreo.Controls.Add(Me.txtCorreoUsuario)
        Me.gbCorreo.Location = New System.Drawing.Point(6, 323)
        Me.gbCorreo.Name = "gbCorreo"
        Me.gbCorreo.Size = New System.Drawing.Size(257, 69)
        Me.gbCorreo.TabIndex = 8
        Me.gbCorreo.TabStop = False
        Me.gbCorreo.Text = "Correo"
        '
        'btnActualizarCorreo
        '
        Me.btnActualizarCorreo.Location = New System.Drawing.Point(187, 40)
        Me.btnActualizarCorreo.Name = "btnActualizarCorreo"
        Me.btnActualizarCorreo.Size = New System.Drawing.Size(63, 23)
        Me.btnActualizarCorreo.TabIndex = 109
        Me.btnActualizarCorreo.Text = "Actualizar"
        Me.btnActualizarCorreo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Contraseña :"
        '
        'txtClaveCorreo
        '
        Me.txtClaveCorreo.Location = New System.Drawing.Point(78, 40)
        Me.txtClaveCorreo.MaxLength = 16
        Me.txtClaveCorreo.Name = "txtClaveCorreo"
        Me.txtClaveCorreo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClaveCorreo.Size = New System.Drawing.Size(87, 20)
        Me.txtClaveCorreo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "e-Mail :"
        '
        'txtCorreoUsuario
        '
        Me.txtCorreoUsuario.Location = New System.Drawing.Point(78, 16)
        Me.txtCorreoUsuario.MaxLength = 60
        Me.txtCorreoUsuario.Name = "txtCorreoUsuario"
        Me.txtCorreoUsuario.Size = New System.Drawing.Size(172, 20)
        Me.txtCorreoUsuario.TabIndex = 0
        '
        'tcPanelPermisos
        '
        Me.tcPanelPermisos.Controls.Add(Me.TpPermisosMenus)
        Me.tcPanelPermisos.Controls.Add(Me.TpPermisosDocumentos)
        Me.tcPanelPermisos.Controls.Add(Me.TpPermisosTiposDocumentos)
        Me.tcPanelPermisos.Controls.Add(Me.TpPermisosControl)
        Me.tcPanelPermisos.Location = New System.Drawing.Point(282, 11)
        Me.tcPanelPermisos.Multiline = True
        Me.tcPanelPermisos.Name = "tcPanelPermisos"
        Me.tcPanelPermisos.SelectedIndex = 0
        Me.tcPanelPermisos.Size = New System.Drawing.Size(658, 487)
        Me.tcPanelPermisos.TabIndex = 10
        '
        'TpPermisosMenus
        '
        Me.TpPermisosMenus.BackColor = System.Drawing.Color.Transparent
        Me.TpPermisosMenus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TpPermisosMenus.Controls.Add(Me.gbControlMenus)
        Me.TpPermisosMenus.Location = New System.Drawing.Point(4, 22)
        Me.TpPermisosMenus.Name = "TpPermisosMenus"
        Me.TpPermisosMenus.Padding = New System.Windows.Forms.Padding(3)
        Me.TpPermisosMenus.Size = New System.Drawing.Size(650, 461)
        Me.TpPermisosMenus.TabIndex = 1
        Me.TpPermisosMenus.Text = "Menús"
        Me.TpPermisosMenus.UseVisualStyleBackColor = True
        '
        'gbControlMenus
        '
        Me.gbControlMenus.Controls.Add(Me.TreeViewMenus)
        Me.gbControlMenus.Location = New System.Drawing.Point(6, 12)
        Me.gbControlMenus.Name = "gbControlMenus"
        Me.gbControlMenus.Size = New System.Drawing.Size(636, 435)
        Me.gbControlMenus.TabIndex = 19
        Me.gbControlMenus.TabStop = False
        Me.gbControlMenus.Text = "Control de menus"
        '
        'TreeViewMenus
        '
        Me.TreeViewMenus.CheckBoxes = True
        Me.TreeViewMenus.Location = New System.Drawing.Point(6, 19)
        Me.TreeViewMenus.Name = "TreeViewMenus"
        Me.TreeViewMenus.Size = New System.Drawing.Size(624, 410)
        Me.TreeViewMenus.TabIndex = 16
        '
        'TpPermisosDocumentos
        '
        Me.TpPermisosDocumentos.Controls.Add(Me.lblDisplayPlazaPermiso)
        Me.TpPermisosDocumentos.Controls.Add(Me.gbDocumentosConAfectacionInventarios)
        Me.TpPermisosDocumentos.Controls.Add(Me.CboPlazasPermiso)
        Me.TpPermisosDocumentos.Controls.Add(Me.gbDocumentosSinAfectacionInventarios)
        Me.TpPermisosDocumentos.Controls.Add(Me.CboModulos)
        Me.TpPermisosDocumentos.Controls.Add(Me.lblDisplayModulo)
        Me.TpPermisosDocumentos.Location = New System.Drawing.Point(4, 22)
        Me.TpPermisosDocumentos.Name = "TpPermisosDocumentos"
        Me.TpPermisosDocumentos.Size = New System.Drawing.Size(650, 461)
        Me.TpPermisosDocumentos.TabIndex = 2
        Me.TpPermisosDocumentos.Text = "Documentos"
        Me.TpPermisosDocumentos.UseVisualStyleBackColor = True
        '
        'lblDisplayPlazaPermiso
        '
        Me.lblDisplayPlazaPermiso.AutoSize = True
        Me.lblDisplayPlazaPermiso.Location = New System.Drawing.Point(7, 49)
        Me.lblDisplayPlazaPermiso.Name = "lblDisplayPlazaPermiso"
        Me.lblDisplayPlazaPermiso.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayPlazaPermiso.TabIndex = 132
        Me.lblDisplayPlazaPermiso.Text = "Plaza :"
        '
        'gbDocumentosConAfectacionInventarios
        '
        Me.gbDocumentosConAfectacionInventarios.Controls.Add(Me.LstVDocumentos1)
        Me.gbDocumentosConAfectacionInventarios.Controls.Add(Me.LstVDocumentos2)
        Me.gbDocumentosConAfectacionInventarios.Controls.Add(Me.lblDisplayAlmacenPermiso)
        Me.gbDocumentosConAfectacionInventarios.Controls.Add(Me.CboAlmacen2)
        Me.gbDocumentosConAfectacionInventarios.Controls.Add(Me.BtnQuitar1)
        Me.gbDocumentosConAfectacionInventarios.Controls.Add(Me.BtnAgregar1)
        Me.gbDocumentosConAfectacionInventarios.Location = New System.Drawing.Point(8, 72)
        Me.gbDocumentosConAfectacionInventarios.Name = "gbDocumentosConAfectacionInventarios"
        Me.gbDocumentosConAfectacionInventarios.Size = New System.Drawing.Size(639, 202)
        Me.gbDocumentosConAfectacionInventarios.TabIndex = 113
        Me.gbDocumentosConAfectacionInventarios.TabStop = False
        Me.gbDocumentosConAfectacionInventarios.Text = "Permisos de documentos con afectacion a inventarios"
        '
        'LstVDocumentos1
        '
        Me.LstVDocumentos1.FullRowSelect = True
        Me.LstVDocumentos1.Location = New System.Drawing.Point(6, 47)
        Me.LstVDocumentos1.MultiSelect = False
        Me.LstVDocumentos1.Name = "LstVDocumentos1"
        Me.LstVDocumentos1.Size = New System.Drawing.Size(297, 146)
        Me.LstVDocumentos1.TabIndex = 132
        Me.LstVDocumentos1.UseCompatibleStateImageBehavior = False
        '
        'LstVDocumentos2
        '
        Me.LstVDocumentos2.FullRowSelect = True
        Me.LstVDocumentos2.Location = New System.Drawing.Point(336, 47)
        Me.LstVDocumentos2.MultiSelect = False
        Me.LstVDocumentos2.Name = "LstVDocumentos2"
        Me.LstVDocumentos2.Size = New System.Drawing.Size(297, 146)
        Me.LstVDocumentos2.TabIndex = 131
        Me.LstVDocumentos2.UseCompatibleStateImageBehavior = False
        '
        'lblDisplayAlmacenPermiso
        '
        Me.lblDisplayAlmacenPermiso.AutoSize = True
        Me.lblDisplayAlmacenPermiso.Location = New System.Drawing.Point(11, 23)
        Me.lblDisplayAlmacenPermiso.Name = "lblDisplayAlmacenPermiso"
        Me.lblDisplayAlmacenPermiso.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayAlmacenPermiso.TabIndex = 126
        Me.lblDisplayAlmacenPermiso.Text = "Almacen :"
        '
        'CboAlmacen2
        '
        Me.CboAlmacen2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen2.FormattingEnabled = True
        Me.CboAlmacen2.Location = New System.Drawing.Point(90, 20)
        Me.CboAlmacen2.Name = "CboAlmacen2"
        Me.CboAlmacen2.Size = New System.Drawing.Size(264, 21)
        Me.CboAlmacen2.TabIndex = 125
        '
        'BtnQuitar1
        '
        Me.BtnQuitar1.Location = New System.Drawing.Point(306, 88)
        Me.BtnQuitar1.Name = "BtnQuitar1"
        Me.BtnQuitar1.Size = New System.Drawing.Size(27, 23)
        Me.BtnQuitar1.TabIndex = 124
        Me.BtnQuitar1.Text = "<<"
        Me.BtnQuitar1.UseVisualStyleBackColor = True
        '
        'BtnAgregar1
        '
        Me.BtnAgregar1.Location = New System.Drawing.Point(306, 60)
        Me.BtnAgregar1.Name = "BtnAgregar1"
        Me.BtnAgregar1.Size = New System.Drawing.Size(27, 23)
        Me.BtnAgregar1.TabIndex = 123
        Me.BtnAgregar1.Text = ">>"
        Me.BtnAgregar1.UseVisualStyleBackColor = True
        '
        'CboPlazasPermiso
        '
        Me.CboPlazasPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPlazasPermiso.FormattingEnabled = True
        Me.CboPlazasPermiso.Location = New System.Drawing.Point(61, 45)
        Me.CboPlazasPermiso.Name = "CboPlazasPermiso"
        Me.CboPlazasPermiso.Size = New System.Drawing.Size(161, 21)
        Me.CboPlazasPermiso.TabIndex = 131
        '
        'gbDocumentosSinAfectacionInventarios
        '
        Me.gbDocumentosSinAfectacionInventarios.Controls.Add(Me.LstVDocumentos4)
        Me.gbDocumentosSinAfectacionInventarios.Controls.Add(Me.LstVDocumentos3)
        Me.gbDocumentosSinAfectacionInventarios.Controls.Add(Me.BtnAgregar2)
        Me.gbDocumentosSinAfectacionInventarios.Controls.Add(Me.BtnQuitar2)
        Me.gbDocumentosSinAfectacionInventarios.Location = New System.Drawing.Point(6, 280)
        Me.gbDocumentosSinAfectacionInventarios.Name = "gbDocumentosSinAfectacionInventarios"
        Me.gbDocumentosSinAfectacionInventarios.Size = New System.Drawing.Size(639, 178)
        Me.gbDocumentosSinAfectacionInventarios.TabIndex = 137
        Me.gbDocumentosSinAfectacionInventarios.TabStop = False
        Me.gbDocumentosSinAfectacionInventarios.Text = "Permisos de documentos sin afectación a inventarios"
        '
        'LstVDocumentos4
        '
        Me.LstVDocumentos4.FullRowSelect = True
        Me.LstVDocumentos4.Location = New System.Drawing.Point(336, 26)
        Me.LstVDocumentos4.MultiSelect = False
        Me.LstVDocumentos4.Name = "LstVDocumentos4"
        Me.LstVDocumentos4.Size = New System.Drawing.Size(297, 146)
        Me.LstVDocumentos4.TabIndex = 134
        Me.LstVDocumentos4.UseCompatibleStateImageBehavior = False
        '
        'LstVDocumentos3
        '
        Me.LstVDocumentos3.FullRowSelect = True
        Me.LstVDocumentos3.Location = New System.Drawing.Point(6, 26)
        Me.LstVDocumentos3.MultiSelect = False
        Me.LstVDocumentos3.Name = "LstVDocumentos3"
        Me.LstVDocumentos3.Size = New System.Drawing.Size(297, 146)
        Me.LstVDocumentos3.TabIndex = 133
        Me.LstVDocumentos3.UseCompatibleStateImageBehavior = False
        '
        'BtnAgregar2
        '
        Me.BtnAgregar2.Location = New System.Drawing.Point(306, 48)
        Me.BtnAgregar2.Name = "BtnAgregar2"
        Me.BtnAgregar2.Size = New System.Drawing.Size(27, 23)
        Me.BtnAgregar2.TabIndex = 129
        Me.BtnAgregar2.Text = ">>"
        Me.BtnAgregar2.UseVisualStyleBackColor = True
        '
        'BtnQuitar2
        '
        Me.BtnQuitar2.Location = New System.Drawing.Point(306, 77)
        Me.BtnQuitar2.Name = "BtnQuitar2"
        Me.BtnQuitar2.Size = New System.Drawing.Size(27, 23)
        Me.BtnQuitar2.TabIndex = 130
        Me.BtnQuitar2.Text = "<<"
        Me.BtnQuitar2.UseVisualStyleBackColor = True
        '
        'CboModulos
        '
        Me.CboModulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboModulos.FormattingEnabled = True
        Me.CboModulos.Location = New System.Drawing.Point(61, 19)
        Me.CboModulos.Name = "CboModulos"
        Me.CboModulos.Size = New System.Drawing.Size(161, 21)
        Me.CboModulos.TabIndex = 118
        '
        'lblDisplayModulo
        '
        Me.lblDisplayModulo.AutoSize = True
        Me.lblDisplayModulo.Location = New System.Drawing.Point(7, 23)
        Me.lblDisplayModulo.Name = "lblDisplayModulo"
        Me.lblDisplayModulo.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayModulo.TabIndex = 119
        Me.lblDisplayModulo.Text = "Módulo :"
        '
        'TpPermisosTiposDocumentos
        '
        Me.TpPermisosTiposDocumentos.Controls.Add(Me.gbTipoDocumentosConAfectacionInventarios)
        Me.TpPermisosTiposDocumentos.Location = New System.Drawing.Point(4, 22)
        Me.TpPermisosTiposDocumentos.Name = "TpPermisosTiposDocumentos"
        Me.TpPermisosTiposDocumentos.Size = New System.Drawing.Size(650, 461)
        Me.TpPermisosTiposDocumentos.TabIndex = 3
        Me.TpPermisosTiposDocumentos.Text = "Tipos de documentos"
        Me.TpPermisosTiposDocumentos.UseVisualStyleBackColor = True
        '
        'gbTipoDocumentosConAfectacionInventarios
        '
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.LstVDocumentos5)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.LstVDocumentos6)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.Label2)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.CboAlmacen3)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.Label3)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.CboAlmacen4)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.CboModulos2)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.lblDisplayModulo3)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.BtnAgregar3)
        Me.gbTipoDocumentosConAfectacionInventarios.Controls.Add(Me.BtnQuitar3)
        Me.gbTipoDocumentosConAfectacionInventarios.Location = New System.Drawing.Point(9, 11)
        Me.gbTipoDocumentosConAfectacionInventarios.Name = "gbTipoDocumentosConAfectacionInventarios"
        Me.gbTipoDocumentosConAfectacionInventarios.Size = New System.Drawing.Size(638, 447)
        Me.gbTipoDocumentosConAfectacionInventarios.TabIndex = 114
        Me.gbTipoDocumentosConAfectacionInventarios.TabStop = False
        Me.gbTipoDocumentosConAfectacionInventarios.Text = "Permisos de tipos de documentos con afectación a inventarios"
        '
        'LstVDocumentos5
        '
        Me.LstVDocumentos5.Location = New System.Drawing.Point(6, 110)
        Me.LstVDocumentos5.Name = "LstVDocumentos5"
        Me.LstVDocumentos5.Size = New System.Drawing.Size(297, 146)
        Me.LstVDocumentos5.TabIndex = 142
        Me.LstVDocumentos5.UseCompatibleStateImageBehavior = False
        '
        'LstVDocumentos6
        '
        Me.LstVDocumentos6.Location = New System.Drawing.Point(335, 108)
        Me.LstVDocumentos6.Name = "LstVDocumentos6"
        Me.LstVDocumentos6.Size = New System.Drawing.Size(297, 146)
        Me.LstVDocumentos6.TabIndex = 141
        Me.LstVDocumentos6.UseCompatibleStateImageBehavior = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Almacén 2 :"
        '
        'CboAlmacen3
        '
        Me.CboAlmacen3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen3.FormattingEnabled = True
        Me.CboAlmacen3.Location = New System.Drawing.Point(88, 80)
        Me.CboAlmacen3.Name = "CboAlmacen3"
        Me.CboAlmacen3.Size = New System.Drawing.Size(215, 21)
        Me.CboAlmacen3.TabIndex = 139
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "Almacén :"
        '
        'CboAlmacen4
        '
        Me.CboAlmacen4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen4.FormattingEnabled = True
        Me.CboAlmacen4.Location = New System.Drawing.Point(88, 54)
        Me.CboAlmacen4.Name = "CboAlmacen4"
        Me.CboAlmacen4.Size = New System.Drawing.Size(215, 21)
        Me.CboAlmacen4.TabIndex = 137
        '
        'CboModulos2
        '
        Me.CboModulos2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboModulos2.FormattingEnabled = True
        Me.CboModulos2.Location = New System.Drawing.Point(62, 29)
        Me.CboModulos2.Name = "CboModulos2"
        Me.CboModulos2.Size = New System.Drawing.Size(161, 21)
        Me.CboModulos2.TabIndex = 131
        '
        'lblDisplayModulo3
        '
        Me.lblDisplayModulo3.AutoSize = True
        Me.lblDisplayModulo3.Location = New System.Drawing.Point(9, 33)
        Me.lblDisplayModulo3.Name = "lblDisplayModulo3"
        Me.lblDisplayModulo3.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayModulo3.TabIndex = 136
        Me.lblDisplayModulo3.Text = "Módulo :"
        '
        'BtnAgregar3
        '
        Me.BtnAgregar3.Location = New System.Drawing.Point(303, 127)
        Me.BtnAgregar3.Name = "BtnAgregar3"
        Me.BtnAgregar3.Size = New System.Drawing.Size(29, 23)
        Me.BtnAgregar3.TabIndex = 134
        Me.BtnAgregar3.Text = ">>"
        Me.BtnAgregar3.UseVisualStyleBackColor = True
        '
        'BtnQuitar3
        '
        Me.BtnQuitar3.Location = New System.Drawing.Point(303, 156)
        Me.BtnQuitar3.Name = "BtnQuitar3"
        Me.BtnQuitar3.Size = New System.Drawing.Size(29, 23)
        Me.BtnQuitar3.TabIndex = 135
        Me.BtnQuitar3.Text = "<<"
        Me.BtnQuitar3.UseVisualStyleBackColor = True
        '
        'TpPermisosControl
        '
        Me.TpPermisosControl.Controls.Add(Me.ckbVerCostos)
        Me.TpPermisosControl.Controls.Add(Me.CkbAdmonCreditos)
        Me.TpPermisosControl.Controls.Add(Me.CkbAdministrador)
        Me.TpPermisosControl.Controls.Add(Me.CkbArmadoPalet)
        Me.TpPermisosControl.Controls.Add(Me.ckbCuentas)
        Me.TpPermisosControl.Controls.Add(Me.CkbClientes)
        Me.TpPermisosControl.Controls.Add(Me.ckbArticulos)
        Me.TpPermisosControl.Location = New System.Drawing.Point(4, 22)
        Me.TpPermisosControl.Name = "TpPermisosControl"
        Me.TpPermisosControl.Size = New System.Drawing.Size(650, 461)
        Me.TpPermisosControl.TabIndex = 4
        Me.TpPermisosControl.Text = "Control"
        Me.TpPermisosControl.UseVisualStyleBackColor = True
        '
        'ckbVerCostos
        '
        Me.ckbVerCostos.AutoSize = True
        Me.ckbVerCostos.Location = New System.Drawing.Point(15, 206)
        Me.ckbVerCostos.Name = "ckbVerCostos"
        Me.ckbVerCostos.Size = New System.Drawing.Size(76, 17)
        Me.ckbVerCostos.TabIndex = 6
        Me.ckbVerCostos.Text = "Ver costos"
        Me.ckbVerCostos.UseVisualStyleBackColor = True
        '
        'CkbAdmonCreditos
        '
        Me.CkbAdmonCreditos.AutoSize = True
        Me.CkbAdmonCreditos.Location = New System.Drawing.Point(15, 50)
        Me.CkbAdmonCreditos.Name = "CkbAdmonCreditos"
        Me.CkbAdmonCreditos.Size = New System.Drawing.Size(149, 17)
        Me.CkbAdmonCreditos.TabIndex = 5
        Me.CkbAdmonCreditos.Text = "Administración de créditos"
        Me.CkbAdmonCreditos.UseVisualStyleBackColor = True
        '
        'CkbAdministrador
        '
        Me.CkbAdministrador.AutoSize = True
        Me.CkbAdministrador.Location = New System.Drawing.Point(15, 19)
        Me.CkbAdministrador.Name = "CkbAdministrador"
        Me.CkbAdministrador.Size = New System.Drawing.Size(89, 17)
        Me.CkbAdministrador.TabIndex = 0
        Me.CkbAdministrador.Text = "Administrador"
        Me.CkbAdministrador.UseVisualStyleBackColor = True
        '
        'CkbArmadoPalet
        '
        Me.CkbArmadoPalet.AutoSize = True
        Me.CkbArmadoPalet.Location = New System.Drawing.Point(15, 80)
        Me.CkbArmadoPalet.Name = "CkbArmadoPalet"
        Me.CkbArmadoPalet.Size = New System.Drawing.Size(108, 17)
        Me.CkbArmadoPalet.TabIndex = 2
        Me.CkbArmadoPalet.Text = "Armado de palets"
        Me.CkbArmadoPalet.UseVisualStyleBackColor = True
        '
        'ckbCuentas
        '
        Me.ckbCuentas.AutoSize = True
        Me.ckbCuentas.Location = New System.Drawing.Point(15, 142)
        Me.ckbCuentas.Name = "ckbCuentas"
        Me.ckbCuentas.Size = New System.Drawing.Size(114, 17)
        Me.ckbCuentas.TabIndex = 4
        Me.ckbCuentas.Text = "Cuentas contables"
        Me.ckbCuentas.UseVisualStyleBackColor = True
        '
        'CkbClientes
        '
        Me.CkbClientes.AutoSize = True
        Me.CkbClientes.Location = New System.Drawing.Point(15, 111)
        Me.CkbClientes.Name = "CkbClientes"
        Me.CkbClientes.Size = New System.Drawing.Size(63, 17)
        Me.CkbClientes.TabIndex = 3
        Me.CkbClientes.Text = "Clientes"
        Me.CkbClientes.UseVisualStyleBackColor = True
        '
        'ckbArticulos
        '
        Me.ckbArticulos.AutoSize = True
        Me.ckbArticulos.Location = New System.Drawing.Point(15, 173)
        Me.ckbArticulos.Name = "ckbArticulos"
        Me.ckbArticulos.Size = New System.Drawing.Size(68, 17)
        Me.ckbArticulos.TabIndex = 1
        Me.ckbArticulos.Text = "Artículos"
        Me.ckbArticulos.UseVisualStyleBackColor = True
        '
        'gbContraseña
        '
        Me.gbContraseña.Controls.Add(Me.BtnActualizar)
        Me.gbContraseña.Controls.Add(Me.BtnRecurperar)
        Me.gbContraseña.Controls.Add(Me.lblDisplayConfirmarClave)
        Me.gbContraseña.Controls.Add(Me.TxtConfirmaClave)
        Me.gbContraseña.Controls.Add(Me.lblDisplayClave)
        Me.gbContraseña.Controls.Add(Me.txtClave)
        Me.gbContraseña.Location = New System.Drawing.Point(6, 250)
        Me.gbContraseña.Name = "gbContraseña"
        Me.gbContraseña.Size = New System.Drawing.Size(257, 69)
        Me.gbContraseña.TabIndex = 7
        Me.gbContraseña.TabStop = False
        Me.gbContraseña.Text = "Contraseña"
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Location = New System.Drawing.Point(187, 40)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(63, 23)
        Me.BtnActualizar.TabIndex = 109
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.UseVisualStyleBackColor = True
        '
        'BtnRecurperar
        '
        Me.BtnRecurperar.Location = New System.Drawing.Point(187, 14)
        Me.BtnRecurperar.Name = "BtnRecurperar"
        Me.BtnRecurperar.Size = New System.Drawing.Size(63, 23)
        Me.BtnRecurperar.TabIndex = 108
        Me.BtnRecurperar.Text = "Recuperar"
        Me.BtnRecurperar.UseVisualStyleBackColor = True
        '
        'lblDisplayConfirmarClave
        '
        Me.lblDisplayConfirmarClave.AutoSize = True
        Me.lblDisplayConfirmarClave.Location = New System.Drawing.Point(6, 40)
        Me.lblDisplayConfirmarClave.Name = "lblDisplayConfirmarClave"
        Me.lblDisplayConfirmarClave.Size = New System.Drawing.Size(57, 13)
        Me.lblDisplayConfirmarClave.TabIndex = 107
        Me.lblDisplayConfirmarClave.Text = "Confirmar :"
        '
        'TxtConfirmaClave
        '
        Me.TxtConfirmaClave.Location = New System.Drawing.Point(78, 40)
        Me.TxtConfirmaClave.MaxLength = 12
        Me.TxtConfirmaClave.Name = "TxtConfirmaClave"
        Me.TxtConfirmaClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmaClave.Size = New System.Drawing.Size(87, 20)
        Me.TxtConfirmaClave.TabIndex = 1
        '
        'lblDisplayClave
        '
        Me.lblDisplayClave.AutoSize = True
        Me.lblDisplayClave.Location = New System.Drawing.Point(6, 16)
        Me.lblDisplayClave.Name = "lblDisplayClave"
        Me.lblDisplayClave.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayClave.TabIndex = 105
        Me.lblDisplayClave.Text = "Nueva :"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(78, 16)
        Me.txtClave.MaxLength = 12
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(87, 20)
        Me.txtClave.TabIndex = 0
        '
        'gbImportar
        '
        Me.gbImportar.Controls.Add(Me.TxtNombreUsuarioImportar)
        Me.gbImportar.Controls.Add(Me.BtnImportar)
        Me.gbImportar.Controls.Add(Me.TxtCodigoUsuarioImporta)
        Me.gbImportar.Controls.Add(Me.lblDisplayImportarPermisos)
        Me.gbImportar.Location = New System.Drawing.Point(6, 177)
        Me.gbImportar.Name = "gbImportar"
        Me.gbImportar.Size = New System.Drawing.Size(257, 67)
        Me.gbImportar.TabIndex = 6
        Me.gbImportar.TabStop = False
        Me.gbImportar.Text = "Importar"
        '
        'TxtNombreUsuarioImportar
        '
        Me.TxtNombreUsuarioImportar.Location = New System.Drawing.Point(63, 42)
        Me.TxtNombreUsuarioImportar.Name = "TxtNombreUsuarioImportar"
        Me.TxtNombreUsuarioImportar.Size = New System.Drawing.Size(117, 17)
        Me.TxtNombreUsuarioImportar.TabIndex = 3
        '
        'BtnImportar
        '
        Me.BtnImportar.Location = New System.Drawing.Point(187, 38)
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Size = New System.Drawing.Size(63, 23)
        Me.BtnImportar.TabIndex = 2
        Me.BtnImportar.Text = "Importar"
        Me.BtnImportar.UseVisualStyleBackColor = True
        '
        'TxtCodigoUsuarioImporta
        '
        Me.TxtCodigoUsuarioImporta.Location = New System.Drawing.Point(6, 40)
        Me.TxtCodigoUsuarioImporta.MaxLength = 4
        Me.TxtCodigoUsuarioImporta.Name = "TxtCodigoUsuarioImporta"
        Me.TxtCodigoUsuarioImporta.Size = New System.Drawing.Size(54, 20)
        Me.TxtCodigoUsuarioImporta.TabIndex = 0
        '
        'lblDisplayImportarPermisos
        '
        Me.lblDisplayImportarPermisos.AutoSize = True
        Me.lblDisplayImportarPermisos.Location = New System.Drawing.Point(6, 24)
        Me.lblDisplayImportarPermisos.Name = "lblDisplayImportarPermisos"
        Me.lblDisplayImportarPermisos.Size = New System.Drawing.Size(110, 13)
        Me.lblDisplayImportarPermisos.TabIndex = 0
        Me.lblDisplayImportarPermisos.Text = "Importar permisos de :"
        '
        'lblDisplayAlamcen
        '
        Me.lblDisplayAlamcen.AutoSize = True
        Me.lblDisplayAlamcen.Location = New System.Drawing.Point(6, 104)
        Me.lblDisplayAlamcen.Name = "lblDisplayAlamcen"
        Me.lblDisplayAlamcen.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayAlamcen.TabIndex = 111
        Me.lblDisplayAlamcen.Text = "Almacén :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(84, 101)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(179, 21)
        Me.CboAlmacen.TabIndex = 3
        '
        'lblDisplayPlaza
        '
        Me.lblDisplayPlaza.AutoSize = True
        Me.lblDisplayPlaza.Location = New System.Drawing.Point(6, 77)
        Me.lblDisplayPlaza.Name = "lblDisplayPlaza"
        Me.lblDisplayPlaza.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayPlaza.TabIndex = 109
        Me.lblDisplayPlaza.Text = "Plaza :"
        '
        'cboPlazas
        '
        Me.cboPlazas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlazas.FormattingEnabled = True
        Me.cboPlazas.Location = New System.Drawing.Point(84, 74)
        Me.cboPlazas.Name = "cboPlazas"
        Me.cboPlazas.Size = New System.Drawing.Size(179, 21)
        Me.cboPlazas.TabIndex = 2
        '
        'LblNombreUsuario
        '
        Me.LblNombreUsuario.AutoSize = True
        Me.LblNombreUsuario.Location = New System.Drawing.Point(6, 52)
        Me.LblNombreUsuario.Name = "LblNombreUsuario"
        Me.LblNombreUsuario.Size = New System.Drawing.Size(50, 13)
        Me.LblNombreUsuario.TabIndex = 103
        Me.LblNombreUsuario.Text = "Nombre :"
        '
        'TxtNombreUsuario
        '
        Me.TxtNombreUsuario.Location = New System.Drawing.Point(84, 48)
        Me.TxtNombreUsuario.MaxLength = 60
        Me.TxtNombreUsuario.Name = "TxtNombreUsuario"
        Me.TxtNombreUsuario.Size = New System.Drawing.Size(179, 20)
        Me.TxtNombreUsuario.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(6, 157)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 102
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(84, 154)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(60, 21)
        Me.CboEstatus.TabIndex = 5
        '
        'LblDisplayCodUsuario
        '
        Me.LblDisplayCodUsuario.AutoSize = True
        Me.LblDisplayCodUsuario.Location = New System.Drawing.Point(6, 27)
        Me.LblDisplayCodUsuario.Name = "LblDisplayCodUsuario"
        Me.LblDisplayCodUsuario.Size = New System.Drawing.Size(46, 13)
        Me.LblDisplayCodUsuario.TabIndex = 101
        Me.LblDisplayCodUsuario.Text = "Código :"
        '
        'TxtCodigoUsuario
        '
        Me.TxtCodigoUsuario.Location = New System.Drawing.Point(84, 23)
        Me.TxtCodigoUsuario.MaxLength = 4
        Me.TxtCodigoUsuario.Name = "TxtCodigoUsuario"
        Me.TxtCodigoUsuario.Size = New System.Drawing.Size(60, 20)
        Me.TxtCodigoUsuario.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 547)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1158, 22)
        Me.StatusStripEstado.TabIndex = 21
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
        'txtDepartamento
        '
        Me.txtDepartamento.Location = New System.Drawing.Point(84, 128)
        Me.txtDepartamento.MaxLength = 60
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(75, 20)
        Me.txtDepartamento.TabIndex = 4
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(165, 131)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(10, 13)
        Me.lblDepartamento.TabIndex = 117
        Me.lblDepartamento.Text = "."
        '
        'lblDisplayDepartamento
        '
        Me.lblDisplayDepartamento.AutoSize = True
        Me.lblDisplayDepartamento.Location = New System.Drawing.Point(6, 131)
        Me.lblDisplayDepartamento.Name = "lblDisplayDepartamento"
        Me.lblDisplayDepartamento.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayDepartamento.TabIndex = 119
        Me.lblDisplayDepartamento.Text = "Departamento :"
        '
        'ConfiguracionUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1158, 569)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ConfiguracionUsuarios"
        Me.Text = "Catálogo de usuarios"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        Me.gbInformacion.ResumeLayout(False)
        Me.gbInformacion.PerformLayout()
        Me.gpVendedor.ResumeLayout(False)
        Me.gpVendedor.PerformLayout()
        Me.gbCorreo.ResumeLayout(False)
        Me.gbCorreo.PerformLayout()
        Me.tcPanelPermisos.ResumeLayout(False)
        Me.TpPermisosMenus.ResumeLayout(False)
        Me.gbControlMenus.ResumeLayout(False)
        Me.TpPermisosDocumentos.ResumeLayout(False)
        Me.TpPermisosDocumentos.PerformLayout()
        Me.gbDocumentosConAfectacionInventarios.ResumeLayout(False)
        Me.gbDocumentosConAfectacionInventarios.PerformLayout()
        Me.gbDocumentosSinAfectacionInventarios.ResumeLayout(False)
        Me.TpPermisosTiposDocumentos.ResumeLayout(False)
        Me.gbTipoDocumentosConAfectacionInventarios.ResumeLayout(False)
        Me.gbTipoDocumentosConAfectacionInventarios.PerformLayout()
        Me.TpPermisosControl.ResumeLayout(False)
        Me.TpPermisosControl.PerformLayout()
        Me.gbContraseña.ResumeLayout(False)
        Me.gbContraseña.PerformLayout()
        Me.gbImportar.ResumeLayout(False)
        Me.gbImportar.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
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
    Friend WithEvents lstbElementos As System.Windows.Forms.ListBox
    Friend WithEvents gbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreUsuario As System.Windows.Forms.Label
    Friend WithEvents TxtNombreUsuario As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodUsuario As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents ckbCuentas As System.Windows.Forms.CheckBox
    Friend WithEvents CkbClientes As System.Windows.Forms.CheckBox
    Friend WithEvents ckbArticulos As System.Windows.Forms.CheckBox
    Friend WithEvents CkbArmadoPalet As System.Windows.Forms.CheckBox
    Friend WithEvents lblDisplayPlaza As System.Windows.Forms.Label
    Friend WithEvents cboPlazas As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDisplayAlamcen As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents CkbAdministrador As System.Windows.Forms.CheckBox
    Friend WithEvents gbImportar As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoUsuarioImporta As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayImportarPermisos As System.Windows.Forms.Label
    Friend WithEvents BtnImportar As System.Windows.Forms.Button
    Friend WithEvents gbContraseña As System.Windows.Forms.GroupBox
    Friend WithEvents BtnActualizar As System.Windows.Forms.Button
    Friend WithEvents BtnRecurperar As System.Windows.Forms.Button
    Friend WithEvents lblDisplayConfirmarClave As System.Windows.Forms.Label
    Friend WithEvents TxtConfirmaClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreUsuarioImportar As System.Windows.Forms.Label
    Friend WithEvents tcPanelPermisos As System.Windows.Forms.TabControl
    Friend WithEvents TpPermisosMenus As System.Windows.Forms.TabPage
    Friend WithEvents gbControlMenus As System.Windows.Forms.GroupBox
    Friend WithEvents TreeViewMenus As System.Windows.Forms.TreeView
    Friend WithEvents TpPermisosDocumentos As System.Windows.Forms.TabPage
    Friend WithEvents gbDocumentosConAfectacionInventarios As System.Windows.Forms.GroupBox
    Friend WithEvents BtnQuitar1 As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar1 As System.Windows.Forms.Button
    Friend WithEvents lblDisplayModulo As System.Windows.Forms.Label
    Friend WithEvents CboModulos As System.Windows.Forms.ComboBox
    Friend WithEvents gbDocumentosSinAfectacionInventarios As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar2 As System.Windows.Forms.Button
    Friend WithEvents BtnQuitar2 As System.Windows.Forms.Button
    Friend WithEvents TpPermisosTiposDocumentos As System.Windows.Forms.TabPage
    Friend WithEvents gbTipoDocumentosConAfectacionInventarios As System.Windows.Forms.GroupBox
    Friend WithEvents CboModulos2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayModulo3 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar3 As System.Windows.Forms.Button
    Friend WithEvents BtnQuitar3 As System.Windows.Forms.Button
    Friend WithEvents lblDisplayPlazaPermiso As System.Windows.Forms.Label
    Friend WithEvents CboPlazasPermiso As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayAlmacenPermiso As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen4 As System.Windows.Forms.ComboBox
    Friend WithEvents LstVDocumentos2 As System.Windows.Forms.ListView
    Friend WithEvents LstVDocumentos1 As System.Windows.Forms.ListView
    Friend WithEvents LstVDocumentos3 As System.Windows.Forms.ListView
    Friend WithEvents LstVDocumentos4 As System.Windows.Forms.ListView
    Friend WithEvents TpPermisosControl As System.Windows.Forms.TabPage
    Friend WithEvents LstVDocumentos5 As System.Windows.Forms.ListView
    Friend WithEvents LstVDocumentos6 As System.Windows.Forms.ListView
    Friend WithEvents gbCorreo As System.Windows.Forms.GroupBox
    Friend WithEvents btnActualizarCorreo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClaveCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCorreoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents CkbAdmonCreditos As System.Windows.Forms.CheckBox
    Friend WithEvents ckbVerCostos As System.Windows.Forms.CheckBox
    Friend WithEvents gpVendedor As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreVendedor As System.Windows.Forms.Label
    Friend WithEvents txtCodigoVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartamento As TextBox
    Friend WithEvents lblDisplayDepartamento As Label
    Friend WithEvents lblDepartamento As Label
End Class
