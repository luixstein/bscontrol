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
        Me.tsMenu.Size = New System.Drawing.Size(753, 27)
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
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label3)
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(329, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(418, 321)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(310, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Estado :"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(361, 17)
        Me.CboEstatusFiltro.Margin = New System.Windows.Forms.Padding(2)
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(51, 21)
        Me.CboEstatusFiltro.TabIndex = 97
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
        Me.Grid.Size = New System.Drawing.Size(405, 272)
        Me.Grid.TabIndex = 111
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(300, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 356)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(753, 22)
        Me.StatusStripEstado.TabIndex = 29
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
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(310, 321)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblTipoCategoria
        '
        Me.lblTipoCategoria.AutoSize = True
        Me.lblTipoCategoria.Location = New System.Drawing.Point(104, 179)
        Me.lblTipoCategoria.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTipoCategoria.Name = "lblTipoCategoria"
        Me.lblTipoCategoria.Size = New System.Drawing.Size(13, 13)
        Me.lblTipoCategoria.TabIndex = 100
        Me.lblTipoCategoria.Text = "_"
        Me.lblTipoCategoria.Visible = False
        '
        'chkCrearCategoria
        '
        Me.chkCrearCategoria.AutoSize = True
        Me.chkCrearCategoria.Location = New System.Drawing.Point(9, 133)
        Me.chkCrearCategoria.Name = "chkCrearCategoria"
        Me.chkCrearCategoria.Size = New System.Drawing.Size(193, 17)
        Me.chkCrearCategoria.TabIndex = 4
        Me.chkCrearCategoria.Text = "Crear categoría automáticamente ?"
        Me.chkCrearCategoria.UseVisualStyleBackColor = True
        '
        'txtTipoCategoria
        '
        Me.txtTipoCategoria.Location = New System.Drawing.Point(104, 156)
        Me.txtTipoCategoria.MaxLength = 30
        Me.txtTipoCategoria.Name = "txtTipoCategoria"
        Me.txtTipoCategoria.Size = New System.Drawing.Size(84, 20)
        Me.txtTipoCategoria.TabIndex = 5
        Me.txtTipoCategoria.Visible = False
        '
        'lblDisplayTipoCategoria
        '
        Me.lblDisplayTipoCategoria.AutoSize = True
        Me.lblDisplayTipoCategoria.Location = New System.Drawing.Point(6, 158)
        Me.lblDisplayTipoCategoria.Name = "lblDisplayTipoCategoria"
        Me.lblDisplayTipoCategoria.Size = New System.Drawing.Size(98, 13)
        Me.lblDisplayTipoCategoria.TabIndex = 99
        Me.lblDisplayTipoCategoria.Text = "Tipo de categoría :"
        Me.lblDisplayTipoCategoria.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Estatus :"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Location = New System.Drawing.Point(76, 117)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(13, 13)
        Me.lblCategoria.TabIndex = 3
        Me.lblCategoria.Text = "_"
        '
        'lblCodigoCategoria
        '
        Me.lblCodigoCategoria.AutoSize = True
        Me.lblCodigoCategoria.Location = New System.Drawing.Point(6, 95)
        Me.lblCodigoCategoria.Name = "lblCodigoCategoria"
        Me.lblCodigoCategoria.Size = New System.Drawing.Size(60, 13)
        Me.lblCodigoCategoria.TabIndex = 94
        Me.lblCodigoCategoria.Text = "Categoría :"
        '
        'TxtCodigoCategoria
        '
        Me.TxtCodigoCategoria.Location = New System.Drawing.Point(77, 92)
        Me.TxtCodigoCategoria.MaxLength = 2
        Me.TxtCodigoCategoria.Name = "TxtCodigoCategoria"
        Me.TxtCodigoCategoria.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodigoCategoria.TabIndex = 3
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(76, 66)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(2)
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(76, 21)
        Me.CboEstatus.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'LblNombreVehiculo
        '
        Me.LblNombreVehiculo.AutoSize = True
        Me.LblNombreVehiculo.Location = New System.Drawing.Point(6, 44)
        Me.LblNombreVehiculo.Name = "LblNombreVehiculo"
        Me.LblNombreVehiculo.Size = New System.Drawing.Size(50, 13)
        Me.LblNombreVehiculo.TabIndex = 74
        Me.LblNombreVehiculo.Text = "Nombre :"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(77, 41)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(227, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'LblCodigo
        '
        Me.LblCodigo.AutoSize = True
        Me.LblCodigo.Location = New System.Drawing.Point(6, 18)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(46, 13)
        Me.LblCodigo.TabIndex = 8
        Me.LblCodigo.Text = "Código :"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(76, 15)
        Me.TxtCodigo.MaxLength = 2
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodigo.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Catalogo_Vehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 378)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Vehiculos"
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
End Class
