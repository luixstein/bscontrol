<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Catalogo_Almacenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Almacenes))
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtCodigoAlmacen = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodAlmacen = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.TxtNombreAlmacen = New System.Windows.Forms.TextBox()
        Me.LblDisplayNombreAlmacen = New System.Windows.Forms.Label()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.lblTipoCategoria = New System.Windows.Forms.Label()
        Me.chkCrearCategoria = New System.Windows.Forms.CheckBox()
        Me.txtTipoCategoria = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoCategoria = New System.Windows.Forms.Label()
        Me.lblCodigoCategoria = New System.Windows.Forms.Label()
        Me.LblNombreCategoria = New System.Windows.Forms.Label()
        Me.TxtCodigoCategoria = New System.Windows.Forms.TextBox()
        Me.lblNombreZona = New System.Windows.Forms.Label()
        Me.lblZona = New System.Windows.Forms.Label()
        Me.txtCodigoZona = New System.Windows.Forms.TextBox()
        Me.lblNombreCuenta = New System.Windows.Forms.Label()
        Me.txtCuentaContable = New System.Windows.Forms.TextBox()
        Me.lblDisplayCuentaContable = New System.Windows.Forms.Label()
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
        Me.tsMenu.Size = New System.Drawing.Size(734, 27)
        Me.tsMenu.TabIndex = 3
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 545)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(734, 22)
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
        Me.txtFiltro.Size = New System.Drawing.Size(174, 20)
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
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(447, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(274, 514)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "Estatus :"
        '
        'cboEstatusFiltro
        '
        Me.cboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatusFiltro.FormattingEnabled = True
        Me.cboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(238, 17)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(31, 21)
        Me.cboEstatusFiltro.TabIndex = 216
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(6, 41)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(261, 467)
        Me.Grid.TabIndex = 113
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtCodigoAlmacen
        '
        Me.TxtCodigoAlmacen.Location = New System.Drawing.Point(108, 15)
        Me.TxtCodigoAlmacen.MaxLength = 4
        Me.TxtCodigoAlmacen.Name = "TxtCodigoAlmacen"
        Me.TxtCodigoAlmacen.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodigoAlmacen.TabIndex = 0
        '
        'LblDisplayCodAlmacen
        '
        Me.LblDisplayCodAlmacen.AutoSize = True
        Me.LblDisplayCodAlmacen.Location = New System.Drawing.Point(6, 18)
        Me.LblDisplayCodAlmacen.Name = "LblDisplayCodAlmacen"
        Me.LblDisplayCodAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.LblDisplayCodAlmacen.TabIndex = 8
        Me.LblDisplayCodAlmacen.Text = "Almacén :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(107, 156)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(67, 21)
        Me.CboEstatus.TabIndex = 4
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(6, 158)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'TxtNombreAlmacen
        '
        Me.TxtNombreAlmacen.Location = New System.Drawing.Point(108, 41)
        Me.TxtNombreAlmacen.MaxLength = 50
        Me.TxtNombreAlmacen.Name = "TxtNombreAlmacen"
        Me.TxtNombreAlmacen.Size = New System.Drawing.Size(305, 20)
        Me.TxtNombreAlmacen.TabIndex = 1
        '
        'LblDisplayNombreAlmacen
        '
        Me.LblDisplayNombreAlmacen.AutoSize = True
        Me.LblDisplayNombreAlmacen.Location = New System.Drawing.Point(6, 44)
        Me.LblDisplayNombreAlmacen.Name = "LblDisplayNombreAlmacen"
        Me.LblDisplayNombreAlmacen.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayNombreAlmacen.TabIndex = 74
        Me.LblDisplayNombreAlmacen.Text = "Nombre :"
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.lblTipoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.chkCrearCategoria)
        Me.gBoxInformacion.Controls.Add(Me.txtTipoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTipoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreCategoria)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreZona)
        Me.gBoxInformacion.Controls.Add(Me.lblZona)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoZona)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreCuenta)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreAlmacen)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreAlmacen)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodAlmacen)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoAlmacen)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(429, 514)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblTipoCategoria
        '
        Me.lblTipoCategoria.AutoSize = True
        Me.lblTipoCategoria.Location = New System.Drawing.Point(104, 266)
        Me.lblTipoCategoria.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTipoCategoria.Name = "lblTipoCategoria"
        Me.lblTipoCategoria.Size = New System.Drawing.Size(13, 13)
        Me.lblTipoCategoria.TabIndex = 225
        Me.lblTipoCategoria.Text = "_"
        Me.lblTipoCategoria.Visible = False
        '
        'chkCrearCategoria
        '
        Me.chkCrearCategoria.AutoSize = True
        Me.chkCrearCategoria.Location = New System.Drawing.Point(9, 220)
        Me.chkCrearCategoria.Name = "chkCrearCategoria"
        Me.chkCrearCategoria.Size = New System.Drawing.Size(191, 17)
        Me.chkCrearCategoria.TabIndex = 6
        Me.chkCrearCategoria.Text = "Crear categoria automáticamente ?"
        Me.chkCrearCategoria.UseVisualStyleBackColor = True
        '
        'txtTipoCategoria
        '
        Me.txtTipoCategoria.Location = New System.Drawing.Point(104, 243)
        Me.txtTipoCategoria.MaxLength = 30
        Me.txtTipoCategoria.Name = "txtTipoCategoria"
        Me.txtTipoCategoria.Size = New System.Drawing.Size(84, 20)
        Me.txtTipoCategoria.TabIndex = 7
        Me.txtTipoCategoria.Visible = False
        '
        'lblDisplayTipoCategoria
        '
        Me.lblDisplayTipoCategoria.AutoSize = True
        Me.lblDisplayTipoCategoria.Location = New System.Drawing.Point(6, 245)
        Me.lblDisplayTipoCategoria.Name = "lblDisplayTipoCategoria"
        Me.lblDisplayTipoCategoria.Size = New System.Drawing.Size(98, 13)
        Me.lblDisplayTipoCategoria.TabIndex = 224
        Me.lblDisplayTipoCategoria.Text = "Tipo de categoría :"
        Me.lblDisplayTipoCategoria.Visible = False
        '
        'lblCodigoCategoria
        '
        Me.lblCodigoCategoria.AutoSize = True
        Me.lblCodigoCategoria.Location = New System.Drawing.Point(6, 185)
        Me.lblCodigoCategoria.Name = "lblCodigoCategoria"
        Me.lblCodigoCategoria.Size = New System.Drawing.Size(60, 13)
        Me.lblCodigoCategoria.TabIndex = 221
        Me.lblCodigoCategoria.Text = "Categoría :"
        '
        'LblNombreCategoria
        '
        Me.LblNombreCategoria.AutoSize = True
        Me.LblNombreCategoria.Location = New System.Drawing.Point(111, 204)
        Me.LblNombreCategoria.Name = "LblNombreCategoria"
        Me.LblNombreCategoria.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreCategoria.TabIndex = 220
        Me.LblNombreCategoria.Text = "_"
        '
        'TxtCodigoCategoria
        '
        Me.TxtCodigoCategoria.Location = New System.Drawing.Point(108, 183)
        Me.TxtCodigoCategoria.MaxLength = 4
        Me.TxtCodigoCategoria.Name = "TxtCodigoCategoria"
        Me.TxtCodigoCategoria.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodigoCategoria.TabIndex = 5
        '
        'lblNombreZona
        '
        Me.lblNombreZona.AutoSize = True
        Me.lblNombreZona.Location = New System.Drawing.Point(108, 140)
        Me.lblNombreZona.Name = "lblNombreZona"
        Me.lblNombreZona.Size = New System.Drawing.Size(13, 13)
        Me.lblNombreZona.TabIndex = 218
        Me.lblNombreZona.Text = "_"
        '
        'lblZona
        '
        Me.lblZona.AutoSize = True
        Me.lblZona.Location = New System.Drawing.Point(6, 120)
        Me.lblZona.Name = "lblZona"
        Me.lblZona.Size = New System.Drawing.Size(38, 13)
        Me.lblZona.TabIndex = 217
        Me.lblZona.Text = "Zona :"
        '
        'txtCodigoZona
        '
        Me.txtCodigoZona.Location = New System.Drawing.Point(108, 117)
        Me.txtCodigoZona.MaxLength = 4
        Me.txtCodigoZona.Name = "txtCodigoZona"
        Me.txtCodigoZona.Size = New System.Drawing.Size(57, 20)
        Me.txtCodigoZona.TabIndex = 3
        '
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.AutoSize = True
        Me.lblNombreCuenta.Location = New System.Drawing.Point(108, 92)
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Size = New System.Drawing.Size(13, 13)
        Me.lblNombreCuenta.TabIndex = 215
        Me.lblNombreCuenta.Text = "_"
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Location = New System.Drawing.Point(108, 69)
        Me.txtCuentaContable.MaxLength = 20
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.ReadOnly = True
        Me.txtCuentaContable.Size = New System.Drawing.Size(160, 20)
        Me.txtCuentaContable.TabIndex = 2
        '
        'lblDisplayCuentaContable
        '
        Me.lblDisplayCuentaContable.AutoSize = True
        Me.lblDisplayCuentaContable.Location = New System.Drawing.Point(6, 72)
        Me.lblDisplayCuentaContable.Name = "lblDisplayCuentaContable"
        Me.lblDisplayCuentaContable.Size = New System.Drawing.Size(92, 13)
        Me.lblDisplayCuentaContable.TabIndex = 143
        Me.lblDisplayCuentaContable.Text = "Cuenta Contable :"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'Catalogo_Almacenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 567)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Almacenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de almacenes."
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
    Friend WithEvents LblDisplayNombreAlmacen As System.Windows.Forms.Label
    Friend WithEvents TxtNombreAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodAlmacen As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCuentaContable As System.Windows.Forms.Label
    Friend WithEvents lblNombreCuenta As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreZona As System.Windows.Forms.Label
    Friend WithEvents lblZona As System.Windows.Forms.Label
    Friend WithEvents txtCodigoZona As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoCategoria As System.Windows.Forms.Label
    Friend WithEvents LblNombreCategoria As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCategoria As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoCategoria As System.Windows.Forms.Label
    Friend WithEvents chkCrearCategoria As System.Windows.Forms.CheckBox
    Friend WithEvents txtTipoCategoria As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTipoCategoria As System.Windows.Forms.Label
End Class
