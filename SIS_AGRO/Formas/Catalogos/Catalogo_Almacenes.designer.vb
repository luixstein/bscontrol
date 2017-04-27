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
        Me.lblNombreZona = New System.Windows.Forms.Label()
        Me.lblZona = New System.Windows.Forms.Label()
        Me.txtCodigoZona = New System.Windows.Forms.TextBox()
        Me.LblCuenta = New System.Windows.Forms.Label()
        Me.txtCuentaContable = New System.Windows.Forms.TextBox()
        Me.lblDisplayCuentaContable = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodigoCategoria = New System.Windows.Forms.TextBox()
        Me.LblNombreCategoria = New System.Windows.Forms.Label()
        Me.LblCategoria = New System.Windows.Forms.Label()
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
        Me.tsMenu.Size = New System.Drawing.Size(979, 27)
        Me.tsMenu.TabIndex = 3
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 673)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(979, 25)
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
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(231, 22)
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
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(596, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(365, 633)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(245, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "Estatus :"
        '
        'cboEstatusFiltro
        '
        Me.cboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatusFiltro.FormattingEnabled = True
        Me.cboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(317, 21)
        Me.cboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(40, 24)
        Me.cboEstatusFiltro.TabIndex = 216
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 50)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(348, 575)
        Me.Grid.TabIndex = 113
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TxtCodigoAlmacen
        '
        Me.TxtCodigoAlmacen.Location = New System.Drawing.Point(144, 18)
        Me.TxtCodigoAlmacen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoAlmacen.MaxLength = 4
        Me.TxtCodigoAlmacen.Name = "TxtCodigoAlmacen"
        Me.TxtCodigoAlmacen.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoAlmacen.TabIndex = 0
        '
        'LblDisplayCodAlmacen
        '
        Me.LblDisplayCodAlmacen.AutoSize = True
        Me.LblDisplayCodAlmacen.Location = New System.Drawing.Point(8, 22)
        Me.LblDisplayCodAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodAlmacen.Name = "LblDisplayCodAlmacen"
        Me.LblDisplayCodAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.LblDisplayCodAlmacen.TabIndex = 8
        Me.LblDisplayCodAlmacen.Text = "Almacen :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(143, 263)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(88, 24)
        Me.CboEstatus.TabIndex = 3
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(8, 266)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'TxtNombreAlmacen
        '
        Me.TxtNombreAlmacen.Location = New System.Drawing.Point(144, 50)
        Me.TxtNombreAlmacen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombreAlmacen.MaxLength = 50
        Me.TxtNombreAlmacen.Name = "TxtNombreAlmacen"
        Me.TxtNombreAlmacen.Size = New System.Drawing.Size(405, 22)
        Me.TxtNombreAlmacen.TabIndex = 1
        '
        'LblDisplayNombreAlmacen
        '
        Me.LblDisplayNombreAlmacen.AutoSize = True
        Me.LblDisplayNombreAlmacen.Location = New System.Drawing.Point(8, 54)
        Me.LblDisplayNombreAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreAlmacen.Name = "LblDisplayNombreAlmacen"
        Me.LblDisplayNombreAlmacen.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombreAlmacen.TabIndex = 74
        Me.LblDisplayNombreAlmacen.Text = "Nombre :"
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.LblCategoria)
        Me.gBoxInformacion.Controls.Add(Me.LblNombreCategoria)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoCategoria)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreZona)
        Me.gBoxInformacion.Controls.Add(Me.lblZona)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoZona)
        Me.gBoxInformacion.Controls.Add(Me.LblCuenta)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreAlmacen)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreAlmacen)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodAlmacen)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoAlmacen)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(572, 633)
        Me.gBoxInformacion.TabIndex = 2
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblNombreZona
        '
        Me.lblNombreZona.AutoSize = True
        Me.lblNombreZona.Location = New System.Drawing.Point(148, 172)
        Me.lblNombreZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreZona.Name = "lblNombreZona"
        Me.lblNombreZona.Size = New System.Drawing.Size(12, 17)
        Me.lblNombreZona.TabIndex = 218
        Me.lblNombreZona.Text = "."
        '
        'lblZona
        '
        Me.lblZona.AutoSize = True
        Me.lblZona.Location = New System.Drawing.Point(8, 148)
        Me.lblZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblZona.Name = "lblZona"
        Me.lblZona.Size = New System.Drawing.Size(49, 17)
        Me.lblZona.TabIndex = 217
        Me.lblZona.Text = "Zona :"
        '
        'txtCodigoZona
        '
        Me.txtCodigoZona.Location = New System.Drawing.Point(144, 144)
        Me.txtCodigoZona.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodigoZona.MaxLength = 4
        Me.txtCodigoZona.Name = "txtCodigoZona"
        Me.txtCodigoZona.Size = New System.Drawing.Size(75, 22)
        Me.txtCodigoZona.TabIndex = 216
        '
        'LblCuenta
        '
        Me.LblCuenta.AutoSize = True
        Me.LblCuenta.Location = New System.Drawing.Point(140, 113)
        Me.LblCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuenta.Name = "LblCuenta"
        Me.LblCuenta.Size = New System.Drawing.Size(12, 17)
        Me.LblCuenta.TabIndex = 215
        Me.LblCuenta.Text = "."
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Location = New System.Drawing.Point(144, 85)
        Me.txtCuentaContable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuentaContable.MaxLength = 20
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.ReadOnly = True
        Me.txtCuentaContable.Size = New System.Drawing.Size(212, 22)
        Me.txtCuentaContable.TabIndex = 2
        '
        'lblDisplayCuentaContable
        '
        Me.lblDisplayCuentaContable.AutoSize = True
        Me.lblDisplayCuentaContable.Location = New System.Drawing.Point(8, 89)
        Me.lblDisplayCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaContable.Name = "lblDisplayCuentaContable"
        Me.lblDisplayCuentaContable.Size = New System.Drawing.Size(121, 17)
        Me.lblDisplayCuentaContable.TabIndex = 143
        Me.lblDisplayCuentaContable.Text = "Cuenta Contable :"
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
        'TxtCodigoCategoria
        '
        Me.TxtCodigoCategoria.Location = New System.Drawing.Point(144, 205)
        Me.TxtCodigoCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoCategoria.MaxLength = 4
        Me.TxtCodigoCategoria.Name = "TxtCodigoCategoria"
        Me.TxtCodigoCategoria.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoCategoria.TabIndex = 219
        '
        'LblNombreCategoria
        '
        Me.LblNombreCategoria.AutoSize = True
        Me.LblNombreCategoria.Location = New System.Drawing.Point(148, 231)
        Me.LblNombreCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreCategoria.Name = "LblNombreCategoria"
        Me.LblNombreCategoria.Size = New System.Drawing.Size(12, 17)
        Me.LblNombreCategoria.TabIndex = 220
        Me.LblNombreCategoria.Text = "."
        '
        'LblCategoria
        '
        Me.LblCategoria.AutoSize = True
        Me.LblCategoria.Location = New System.Drawing.Point(8, 208)
        Me.LblCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCategoria.Name = "LblCategoria"
        Me.LblCategoria.Size = New System.Drawing.Size(77, 17)
        Me.LblCategoria.TabIndex = 221
        Me.LblCategoria.Text = "Categoria :"
        '
        'Catalogo_Almacenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 698)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents LblCuenta As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreZona As System.Windows.Forms.Label
    Friend WithEvents lblZona As System.Windows.Forms.Label
    Friend WithEvents txtCodigoZona As System.Windows.Forms.TextBox
    Friend WithEvents LblCategoria As System.Windows.Forms.Label
    Friend WithEvents LblNombreCategoria As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCategoria As System.Windows.Forms.TextBox
End Class
