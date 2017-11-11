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
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
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
        Me.tsMenu.Size = New System.Drawing.Size(726, 27)
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
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(48, 17)
        Me.tssLabel.Text = "Estado :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 512)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(726, 22)
        Me.StatusStripEstado.TabIndex = 5
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 17)
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(264, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'cMenuStripAccion
        '
        Me.cMenuStripAccion.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cMenuStripAccion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tStripMenuItemEditar})
        Me.cMenuStripAccion.Name = "ContextMenuStrip1"
        Me.cMenuStripAccion.Size = New System.Drawing.Size(109, 30)
        '
        'tStripMenuItemEditar
        '
        Me.tStripMenuItemEditar.Image = CType(resources.GetObject("tStripMenuItemEditar.Image"), System.Drawing.Image)
        Me.tStripMenuItemEditar.Name = "tStripMenuItemEditar"
        Me.tStripMenuItemEditar.Size = New System.Drawing.Size(108, 26)
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
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(329, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(384, 480)
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
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(322, 19)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(57, 21)
        Me.cboEstatusFiltro.TabIndex = 265
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(275, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
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
        Me.Grid.Location = New System.Drawing.Point(6, 43)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(372, 431)
        Me.Grid.TabIndex = 109
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtIDCuenta
        '
        Me.TxtIDCuenta.Location = New System.Drawing.Point(111, 17)
        Me.TxtIDCuenta.MaxLength = 2
        Me.TxtIDCuenta.Name = "TxtIDCuenta"
        Me.TxtIDCuenta.Size = New System.Drawing.Size(57, 20)
        Me.TxtIDCuenta.TabIndex = 0
        '
        'LblDisplayCodCultivo
        '
        Me.LblDisplayCodCultivo.AutoSize = True
        Me.LblDisplayCodCultivo.Location = New System.Drawing.Point(4, 22)
        Me.LblDisplayCodCultivo.Name = "LblDisplayCodCultivo"
        Me.LblDisplayCodCultivo.Size = New System.Drawing.Size(44, 13)
        Me.LblDisplayCodCultivo.TabIndex = 16
        Me.LblDisplayCodCultivo.Text = "Cuenta:"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.IntegralHeight = False
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(112, 416)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(78, 21)
        Me.CboEstatus.TabIndex = 12
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(3, 422)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'TxtNombreCuenta
        '
        Me.TxtNombreCuenta.Location = New System.Drawing.Point(112, 43)
        Me.TxtNombreCuenta.MaxLength = 50
        Me.TxtNombreCuenta.Name = "TxtNombreCuenta"
        Me.TxtNombreCuenta.Size = New System.Drawing.Size(198, 20)
        Me.TxtNombreCuenta.TabIndex = 1
        '
        'LblDisplayNombreCultivo
        '
        Me.LblDisplayNombreCultivo.AutoSize = True
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(4, 48)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreProveedor)
        Me.gBoxInformacion.Controls.Add(Me.cboMoneda)
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
        Me.gBoxInformacion.Location = New System.Drawing.Point(7, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(316, 480)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'LblNombreProveedor
        '
        Me.LblNombreProveedor.Location = New System.Drawing.Point(110, 206)
        Me.LblNombreProveedor.Name = "LblNombreProveedor"
        Me.LblNombreProveedor.Size = New System.Drawing.Size(202, 13)
        Me.LblNombreProveedor.TabIndex = 264
        Me.LblNombreProveedor.Text = "."
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.IntegralHeight = False
        Me.cboMoneda.Location = New System.Drawing.Point(112, 68)
        Me.cboMoneda.MaxLength = 1
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(101, 21)
        Me.cboMoneda.TabIndex = 2
        '
        'LblCodigoMoneda
        '
        Me.LblCodigoMoneda.AutoSize = True
        Me.LblCodigoMoneda.Location = New System.Drawing.Point(3, 71)
        Me.LblCodigoMoneda.Name = "LblCodigoMoneda"
        Me.LblCodigoMoneda.Size = New System.Drawing.Size(49, 13)
        Me.LblCodigoMoneda.TabIndex = 263
        Me.LblCodigoMoneda.Text = "Moneda:"
        '
        'TxtCodigoProveedor
        '
        Me.TxtCodigoProveedor.Location = New System.Drawing.Point(112, 177)
        Me.TxtCodigoProveedor.MaxLength = 50
        Me.TxtCodigoProveedor.Name = "TxtCodigoProveedor"
        Me.TxtCodigoProveedor.Size = New System.Drawing.Size(98, 20)
        Me.TxtCodigoProveedor.TabIndex = 6
        '
        'LblCodigoProveedor
        '
        Me.LblCodigoProveedor.AutoSize = True
        Me.LblCodigoProveedor.Location = New System.Drawing.Point(4, 180)
        Me.LblCodigoProveedor.Name = "LblCodigoProveedor"
        Me.LblCodigoProveedor.Size = New System.Drawing.Size(109, 13)
        Me.LblCodigoProveedor.TabIndex = 261
        Me.LblCodigoProveedor.Text = "Codigo de proveedor:"
        '
        'LblCuentaDolares
        '
        Me.LblCuentaDolares.Location = New System.Drawing.Point(110, 356)
        Me.LblCuentaDolares.Name = "LblCuentaDolares"
        Me.LblCuentaDolares.Size = New System.Drawing.Size(202, 13)
        Me.LblCuentaDolares.TabIndex = 260
        Me.LblCuentaDolares.Text = "."
        '
        'txtCuentaContableDolares
        '
        Me.txtCuentaContableDolares.Location = New System.Drawing.Point(111, 331)
        Me.txtCuentaContableDolares.MaxLength = 15
        Me.txtCuentaContableDolares.Name = "txtCuentaContableDolares"
        Me.txtCuentaContableDolares.Size = New System.Drawing.Size(160, 20)
        Me.txtCuentaContableDolares.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 333)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 13)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "Cta contable dolares:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 385)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 259
        Me.Label7.Text = "Nombre del formato :"
        '
        'TxtFormatoReporte
        '
        Me.TxtFormatoReporte.Location = New System.Drawing.Point(111, 381)
        Me.TxtFormatoReporte.MaxLength = 50
        Me.TxtFormatoReporte.Name = "TxtFormatoReporte"
        Me.TxtFormatoReporte.Size = New System.Drawing.Size(199, 20)
        Me.TxtFormatoReporte.TabIndex = 11
        '
        'LblCuenta
        '
        Me.LblCuenta.Location = New System.Drawing.Point(109, 313)
        Me.LblCuenta.Name = "LblCuenta"
        Me.LblCuenta.Size = New System.Drawing.Size(202, 13)
        Me.LblCuenta.TabIndex = 257
        Me.LblCuenta.Text = "."
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Location = New System.Drawing.Point(111, 288)
        Me.txtCuentaContable.MaxLength = 15
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.Size = New System.Drawing.Size(160, 20)
        Me.txtCuentaContable.TabIndex = 9
        '
        'lblDisplayCuentaContable
        '
        Me.lblDisplayCuentaContable.AutoSize = True
        Me.lblDisplayCuentaContable.Location = New System.Drawing.Point(3, 290)
        Me.lblDisplayCuentaContable.Name = "lblDisplayCuentaContable"
        Me.lblDisplayCuentaContable.Size = New System.Drawing.Size(101, 13)
        Me.lblDisplayCuentaContable.TabIndex = 256
        Me.lblDisplayCuentaContable.Text = "Cta contable pesos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 264)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 254
        Me.Label6.Text = "Folio cheque:"
        '
        'TxtFolioCheque
        '
        Me.TxtFolioCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolioCheque.Location = New System.Drawing.Point(111, 260)
        Me.TxtFolioCheque.MaxLength = 50
        Me.TxtFolioCheque.Name = "TxtFolioCheque"
        Me.TxtFolioCheque.Size = New System.Drawing.Size(160, 22)
        Me.TxtFolioCheque.TabIndex = 8
        '
        'LblBanco
        '
        Me.LblBanco.Location = New System.Drawing.Point(158, 236)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(156, 13)
        Me.LblBanco.TabIndex = 252
        Me.LblBanco.Text = "."
        '
        'LblDisplayBanco
        '
        Me.LblDisplayBanco.AutoSize = True
        Me.LblDisplayBanco.Location = New System.Drawing.Point(3, 236)
        Me.LblDisplayBanco.Name = "LblDisplayBanco"
        Me.LblDisplayBanco.Size = New System.Drawing.Size(44, 13)
        Me.LblDisplayBanco.TabIndex = 251
        Me.LblDisplayBanco.Text = "Banco :"
        '
        'TxtBanco
        '
        Me.TxtBanco.Location = New System.Drawing.Point(112, 236)
        Me.TxtBanco.MaxLength = 6
        Me.TxtBanco.Name = "TxtBanco"
        Me.TxtBanco.Size = New System.Drawing.Size(41, 20)
        Me.TxtBanco.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(133, 447)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Saldo:"
        Me.Label5.Visible = False
        '
        'TxtSaldo
        '
        Me.TxtSaldo.Enabled = False
        Me.TxtSaldo.Location = New System.Drawing.Point(177, 444)
        Me.TxtSaldo.MaxLength = 50
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.ReadOnly = True
        Me.TxtSaldo.Size = New System.Drawing.Size(94, 20)
        Me.TxtSaldo.TabIndex = 25
        Me.TxtSaldo.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Telefono :"
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(111, 150)
        Me.TxtTelefono.MaxLength = 50
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(120, 20)
        Me.TxtTelefono.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Nº. de cuenta :"
        '
        'TxtNumeroCuenta
        '
        Me.TxtNumeroCuenta.Location = New System.Drawing.Point(111, 124)
        Me.TxtNumeroCuenta.MaxLength = 50
        Me.TxtNumeroCuenta.Name = "TxtNumeroCuenta"
        Me.TxtNumeroCuenta.Size = New System.Drawing.Size(199, 20)
        Me.TxtNumeroCuenta.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Sucursal :"
        '
        'TxtSucursal
        '
        Me.TxtSucursal.Location = New System.Drawing.Point(111, 98)
        Me.TxtSucursal.MaxLength = 50
        Me.TxtSucursal.Name = "TxtSucursal"
        Me.TxtSucursal.Size = New System.Drawing.Size(199, 20)
        Me.TxtSucursal.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'Catalogo_Cuentas_Bancarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 534)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents LblCodigoMoneda As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoProveedor As System.Windows.Forms.Label
    Friend WithEvents LblNombreProveedor As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents cboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
