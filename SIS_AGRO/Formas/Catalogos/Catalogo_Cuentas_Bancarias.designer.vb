<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Catalogo_Cuentas_Bancarias
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Cuentas_Bancarias))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.cMenuStripAccion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tStripMenuItemEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.cboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtIDCuenta = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodCultivo = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.TxtNombreCuenta = New System.Windows.Forms.TextBox()
        Me.LblDisplayNombreCultivo = New System.Windows.Forms.Label()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.LblNombreProveedor = New System.Windows.Forms.Label()
        Me.CboCodigoMoneda = New System.Windows.Forms.ComboBox()
        Me.LblCodigoMoneda = New System.Windows.Forms.Label()
        Me.TxtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.LblCodigoProveedor = New System.Windows.Forms.Label()
        Me.LblCuentaDolares = New System.Windows.Forms.Label()
        Me.txtCuentaContableDolares = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtFormatoReporte = New System.Windows.Forms.TextBox()
        Me.LblCuenta = New System.Windows.Forms.Label()
        Me.txtCuentaContable = New System.Windows.Forms.TextBox()
        Me.lblDisplayCuentaContable = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFolioCheque = New System.Windows.Forms.TextBox()
        Me.LblBanco = New System.Windows.Forms.Label()
        Me.LblDisplayBanco = New System.Windows.Forms.Label()
        Me.TxtBanco = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtSaldo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNumeroCuenta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSucursal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.cMenuStripAccion.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(968, 27)
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
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(61, 20)
        Me.tssLabel.Text = "Estado :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 632)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(968, 25)
        Me.StatusStripEstado.TabIndex = 5
        Me.StatusStripEstado.Text = "StatusStrip1"
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
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(351, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'cMenuStripAccion
        '
        Me.cMenuStripAccion.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cMenuStripAccion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tStripMenuItemEditar})
        Me.cMenuStripAccion.Name = "ContextMenuStrip1"
        Me.cMenuStripAccion.Size = New System.Drawing.Size(124, 30)
        '
        'tStripMenuItemEditar
        '
        Me.tStripMenuItemEditar.Image = CType(resources.GetObject("tStripMenuItemEditar.Image"), System.Drawing.Image)
        Me.tStripMenuItemEditar.Name = "tStripMenuItemEditar"
        Me.tStripMenuItemEditar.Size = New System.Drawing.Size(123, 26)
        Me.tStripMenuItemEditar.Text = "&Editar"
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label8)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(439, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(512, 591)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'cboEstatusFiltro
        '
        Me.cboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatusFiltro.FormattingEnabled = True
        Me.cboEstatusFiltro.IntegralHeight = False
        Me.cboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(429, 23)
        Me.cboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(75, 24)
        Me.cboEstatusFiltro.TabIndex = 265
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(367, 26)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 17)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "Estatus :"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 53)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(496, 530)
        Me.Grid.TabIndex = 109
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtIDCuenta
        '
        Me.TxtIDCuenta.Location = New System.Drawing.Point(148, 21)
        Me.TxtIDCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtIDCuenta.MaxLength = 2
        Me.TxtIDCuenta.Name = "TxtIDCuenta"
        Me.TxtIDCuenta.Size = New System.Drawing.Size(75, 22)
        Me.TxtIDCuenta.TabIndex = 0
        '
        'LblDisplayCodCultivo
        '
        Me.LblDisplayCodCultivo.AutoSize = True
        Me.LblDisplayCodCultivo.Location = New System.Drawing.Point(5, 27)
        Me.LblDisplayCodCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodCultivo.Name = "LblDisplayCodCultivo"
        Me.LblDisplayCodCultivo.Size = New System.Drawing.Size(57, 17)
        Me.LblDisplayCodCultivo.TabIndex = 16
        Me.LblDisplayCodCultivo.Text = "Cuenta:"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.IntegralHeight = False
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(150, 512)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(103, 24)
        Me.CboEstatus.TabIndex = 12
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(4, 519)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'TxtNombreCuenta
        '
        Me.TxtNombreCuenta.Location = New System.Drawing.Point(149, 53)
        Me.TxtNombreCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreCuenta.MaxLength = 50
        Me.TxtNombreCuenta.Name = "TxtNombreCuenta"
        Me.TxtNombreCuenta.Size = New System.Drawing.Size(263, 22)
        Me.TxtNombreCuenta.TabIndex = 1
        '
        'LblDisplayNombreCultivo
        '
        Me.LblDisplayNombreCultivo.AutoSize = True
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(5, 59)
        Me.LblDisplayNombreCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreProveedor)
        Me.gBoxInformacion.Controls.Add(Me.CboCodigoMoneda)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoMoneda)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoProveedor)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoProveedor)
        Me.gBoxInformacion.Controls.Add(Me.LblCuentaDolares)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContableDolares)
        Me.gBoxInformacion.Controls.Add(Me.Label10)
        Me.gBoxInformacion.Controls.Add(Me.Label7)
        Me.gBoxInformacion.Controls.Add(Me.TxtFormatoReporte)
        Me.gBoxInformacion.Controls.Add(Me.LblCuenta)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.Label6)
        Me.gBoxInformacion.Controls.Add(Me.TxtFolioCheque)
        Me.gBoxInformacion.Controls.Add(Me.LblBanco)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayBanco)
        Me.gBoxInformacion.Controls.Add(Me.TxtBanco)
        Me.gBoxInformacion.Controls.Add(Me.Label5)
        Me.gBoxInformacion.Controls.Add(Me.TxtSaldo)
        Me.gBoxInformacion.Controls.Add(Me.Label4)
        Me.gBoxInformacion.Controls.Add(Me.TxtTelefono)
        Me.gBoxInformacion.Controls.Add(Me.Label3)
        Me.gBoxInformacion.Controls.Add(Me.TxtNumeroCuenta)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.TxtSucursal)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtIDCuenta)
        Me.gBoxInformacion.Location = New System.Drawing.Point(9, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(421, 591)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'LblNombreProveedor
        '
        Me.LblNombreProveedor.Location = New System.Drawing.Point(146, 253)
        Me.LblNombreProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreProveedor.Name = "LblNombreProveedor"
        Me.LblNombreProveedor.Size = New System.Drawing.Size(269, 16)
        Me.LblNombreProveedor.TabIndex = 264
        Me.LblNombreProveedor.Text = "."
        '
        'CboCodigoMoneda
        '
        Me.CboCodigoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCodigoMoneda.FormattingEnabled = True
        Me.CboCodigoMoneda.IntegralHeight = False
        Me.CboCodigoMoneda.Items.AddRange(New Object() {"A", "B"})
        Me.CboCodigoMoneda.Location = New System.Drawing.Point(150, 84)
        Me.CboCodigoMoneda.Margin = New System.Windows.Forms.Padding(4)
        Me.CboCodigoMoneda.MaxLength = 1
        Me.CboCodigoMoneda.Name = "CboCodigoMoneda"
        Me.CboCodigoMoneda.Size = New System.Drawing.Size(133, 24)
        Me.CboCodigoMoneda.TabIndex = 2
        '
        'LblCodigoMoneda
        '
        Me.LblCodigoMoneda.AutoSize = True
        Me.LblCodigoMoneda.Location = New System.Drawing.Point(4, 87)
        Me.LblCodigoMoneda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoMoneda.Name = "LblCodigoMoneda"
        Me.LblCodigoMoneda.Size = New System.Drawing.Size(63, 17)
        Me.LblCodigoMoneda.TabIndex = 263
        Me.LblCodigoMoneda.Text = "Moneda:"
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(150, 218)
        Me.TxtCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoProveedor.MaxLength = 50
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(129, 22)
        Me.TxtCodigoProveedor.TabIndex = 6
        '
        'LblCodigoProveedor
        '
        Me.LblCodigoProveedor.AutoSize = True
        Me.LblCodigoProveedor.Location = New System.Drawing.Point(6, 221)
        Me.LblCodigoProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoProveedor.Name = "LblCodigoProveedor"
        Me.LblCodigoProveedor.Size = New System.Drawing.Size(145, 17)
        Me.LblCodigoProveedor.TabIndex = 261
        Me.LblCodigoProveedor.Text = "Codigo de proveedor:"
        '
        'LblCuentaDolares
        '
        Me.LblCuentaDolares.Location = New System.Drawing.Point(147, 438)
        Me.LblCuentaDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuentaDolares.Name = "LblCuentaDolares"
        Me.LblCuentaDolares.Size = New System.Drawing.Size(269, 16)
        Me.LblCuentaDolares.TabIndex = 260
        Me.LblCuentaDolares.Text = "."
        '
        'txtCuentaContableDolares
        '
        Me.txtCuentaContableDolares.Location = New System.Drawing.Point(148, 407)
        Me.txtCuentaContableDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaContableDolares.MaxLength = 15
        Me.txtCuentaContableDolares.Name = "txtCuentaContableDolares"
        Me.txtCuentaContableDolares.Size = New System.Drawing.Size(212, 22)
        Me.txtCuentaContableDolares.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 410)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 17)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "Cta contable dolares:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 474)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 17)
        Me.Label7.TabIndex = 259
        Me.Label7.Text = "Nombre del formato :"
        '
        'TxtFormatoReporte
        '
        Me.TxtFormatoReporte.Location = New System.Drawing.Point(148, 469)
        Me.TxtFormatoReporte.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFormatoReporte.MaxLength = 50
        Me.TxtFormatoReporte.Name = "TxtFormatoReporte"
        Me.TxtFormatoReporte.Size = New System.Drawing.Size(264, 22)
        Me.TxtFormatoReporte.TabIndex = 11
        '
        'LblCuenta
        '
        Me.LblCuenta.Location = New System.Drawing.Point(145, 385)
        Me.LblCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuenta.Name = "LblCuenta"
        Me.LblCuenta.Size = New System.Drawing.Size(269, 16)
        Me.LblCuenta.TabIndex = 257
        Me.LblCuenta.Text = "."
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Location = New System.Drawing.Point(148, 354)
        Me.txtCuentaContable.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaContable.MaxLength = 15
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.Size = New System.Drawing.Size(212, 22)
        Me.txtCuentaContable.TabIndex = 9
        '
        'lblDisplayCuentaContable
        '
        Me.lblDisplayCuentaContable.AutoSize = True
        Me.lblDisplayCuentaContable.Location = New System.Drawing.Point(4, 357)
        Me.lblDisplayCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaContable.Name = "lblDisplayCuentaContable"
        Me.lblDisplayCuentaContable.Size = New System.Drawing.Size(133, 17)
        Me.lblDisplayCuentaContable.TabIndex = 256
        Me.lblDisplayCuentaContable.Text = "Cta contable pesos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 325)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 17)
        Me.Label6.TabIndex = 254
        Me.Label6.Text = "Folio cheque:"
        '
        'TxtFolioCheque
        '
        Me.TxtFolioCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolioCheque.Location = New System.Drawing.Point(148, 320)
        Me.TxtFolioCheque.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFolioCheque.MaxLength = 50
        Me.TxtFolioCheque.Name = "TxtFolioCheque"
        Me.TxtFolioCheque.Size = New System.Drawing.Size(212, 26)
        Me.TxtFolioCheque.TabIndex = 8
        '
        'LblBanco
        '
        Me.LblBanco.Location = New System.Drawing.Point(210, 291)
        Me.LblBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(208, 16)
        Me.LblBanco.TabIndex = 252
        Me.LblBanco.Text = "."
        '
        'LblDisplayBanco
        '
        Me.LblDisplayBanco.AutoSize = True
        Me.LblDisplayBanco.Location = New System.Drawing.Point(4, 290)
        Me.LblDisplayBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayBanco.Name = "LblDisplayBanco"
        Me.LblDisplayBanco.Size = New System.Drawing.Size(56, 17)
        Me.LblDisplayBanco.TabIndex = 251
        Me.LblDisplayBanco.Text = "Banco :"
        '
        'TxtBanco
        '
        Me.TxtBanco.Location = New System.Drawing.Point(150, 290)
        Me.TxtBanco.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBanco.MaxLength = 6
        Me.TxtBanco.Name = "TxtBanco"
        Me.TxtBanco.Size = New System.Drawing.Size(53, 22)
        Me.TxtBanco.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 550)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Saldo:"
        Me.Label5.Visible = False
        '
        'TxtSaldo
        '
        Me.TxtSaldo.Enabled = False
        Me.TxtSaldo.Location = New System.Drawing.Point(236, 547)
        Me.TxtSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSaldo.MaxLength = 50
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.ReadOnly = True
        Me.TxtSaldo.Size = New System.Drawing.Size(124, 22)
        Me.TxtSaldo.TabIndex = 25
        Me.TxtSaldo.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 188)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 17)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Telefono :"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(148, 184)
        Me.TxtTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTelefono.MaxLength = 50
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(159, 22)
        Me.TxtTelefono.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 156)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Nº. de cuenta :"
        '
        'TxtNumeroCuenta
        '
        Me.TxtNumeroCuenta.Location = New System.Drawing.Point(148, 152)
        Me.TxtNumeroCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNumeroCuenta.MaxLength = 50
        Me.TxtNumeroCuenta.Name = "TxtNumeroCuenta"
        Me.TxtNumeroCuenta.Size = New System.Drawing.Size(264, 22)
        Me.TxtNumeroCuenta.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 124)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 17)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Sucursal :"
        '
        'TxtSucursal
        '
        Me.TxtSucursal.Location = New System.Drawing.Point(148, 120)
        Me.TxtSucursal.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSucursal.MaxLength = 50
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.Size = New System.Drawing.Size(264, 22)
        Me.TxtSucursal.TabIndex = 3
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
        'Catalogo_Cuentas_Bancarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 657)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Cuentas_Bancarias"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catalogo de cuentas bancarias"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.cMenuStripAccion.ResumeLayout(False)
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents cMenuStripAccion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tStripMenuItemEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNombreCuenta As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtIDCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents LblBanco As System.Windows.Forms.Label
    Friend WithEvents LblDisplayBanco As System.Windows.Forms.Label
    Friend WithEvents TxtBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFolioCheque As System.Windows.Forms.TextBox
    Friend WithEvents LblCuenta As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCuentaContable As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFormatoReporte As System.Windows.Forms.TextBox
    Friend WithEvents LblCuentaDolares As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContableDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboCodigoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents LblCodigoMoneda As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoProveedor As System.Windows.Forms.Label
    Friend WithEvents LblNombreProveedor As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents cboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
