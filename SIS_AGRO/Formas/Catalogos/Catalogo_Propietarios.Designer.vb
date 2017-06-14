<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Propietarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Propietarios))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.TxtLimiteCredito = New System.Windows.Forms.TextBox()
        Me.TxtPlazo = New System.Windows.Forms.TextBox()
        Me.LblPlazo = New System.Windows.Forms.Label()
        Me.LblLimiteCredito = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayNombreCultivo = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GridClientes = New System.Windows.Forms.DataGridView()
        Me.LblClientes = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1064, 27)
        Me.tsMenu.TabIndex = 28
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
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(644, 36)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(407, 395)
        Me.gBoxBusquedaRapida.TabIndex = 26
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
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
        Me.Grid.Size = New System.Drawing.Size(391, 334)
        Me.Grid.TabIndex = 111
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(391, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 435)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1064, 25)
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
        Me.gBoxInformacion.Controls.Add(Me.LblClientes)
        Me.gBoxInformacion.Controls.Add(Me.GridClientes)
        Me.gBoxInformacion.Controls.Add(Me.TxtLimiteCredito)
        Me.gBoxInformacion.Controls.Add(Me.TxtPlazo)
        Me.gBoxInformacion.Controls.Add(Me.LblPlazo)
        Me.gBoxInformacion.Controls.Add(Me.LblLimiteCredito)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombre)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigo)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigo)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(620, 395)
        Me.gBoxInformacion.TabIndex = 27
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'TxtLimiteCredito
        '
        Me.TxtLimiteCredito.Location = New System.Drawing.Point(136, 89)
        Me.TxtLimiteCredito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLimiteCredito.MaxLength = 50
        Me.TxtLimiteCredito.Name = "TxtLimiteCredito"
        Me.TxtLimiteCredito.Size = New System.Drawing.Size(188, 22)
        Me.TxtLimiteCredito.TabIndex = 2
        '
        'TxtPlazo
        '
        Me.TxtPlazo.Location = New System.Drawing.Point(136, 126)
        Me.TxtPlazo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPlazo.MaxLength = 50
        Me.TxtPlazo.Name = "TxtPlazo"
        Me.TxtPlazo.Size = New System.Drawing.Size(188, 22)
        Me.TxtPlazo.TabIndex = 3
        '
        'LblPlazo
        '
        Me.LblPlazo.AutoSize = True
        Me.LblPlazo.Location = New System.Drawing.Point(8, 129)
        Me.LblPlazo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPlazo.Name = "LblPlazo"
        Me.LblPlazo.Size = New System.Drawing.Size(51, 17)
        Me.LblPlazo.TabIndex = 93
        Me.LblPlazo.Text = "Plazo :"
        '
        'LblLimiteCredito
        '
        Me.LblLimiteCredito.AutoSize = True
        Me.LblLimiteCredito.Location = New System.Drawing.Point(8, 92)
        Me.LblLimiteCredito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLimiteCredito.Name = "LblLimiteCredito"
        Me.LblLimiteCredito.Size = New System.Drawing.Size(120, 17)
        Me.LblLimiteCredito.TabIndex = 92
        Me.LblLimiteCredito.Text = "Límite de crédito :"
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
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(8, 54)
        Me.LblDisplayNombreCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(103, 50)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 200
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
        'GridClientes
        '
        Me.GridClientes.AllowUserToAddRows = False
        Me.GridClientes.AllowUserToDeleteRows = False
        Me.GridClientes.AllowUserToResizeColumns = False
        Me.GridClientes.AllowUserToResizeRows = False
        Me.GridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridClientes.Location = New System.Drawing.Point(8, 188)
        Me.GridClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.ReadOnly = True
        Me.GridClientes.RowHeadersVisible = False
        Me.GridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridClientes.Size = New System.Drawing.Size(604, 199)
        Me.GridClientes.TabIndex = 112
        '
        'LblClientes
        '
        Me.LblClientes.AutoSize = True
        Me.LblClientes.Location = New System.Drawing.Point(8, 167)
        Me.LblClientes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblClientes.Name = "LblClientes"
        Me.LblClientes.Size = New System.Drawing.Size(66, 17)
        Me.LblClientes.TabIndex = 113
        Me.LblClientes.Text = "Clientes :"
        '
        'Catalogo_Propietarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 460)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Propietarios"
        Me.ShowIcon = False
        Me.Text = "Catálogo de propietarios"
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
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LblDisplayNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents TxtLimiteCredito As System.Windows.Forms.TextBox
    Friend WithEvents TxtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents LblPlazo As System.Windows.Forms.Label
    Friend WithEvents LblLimiteCredito As System.Windows.Forms.Label
    Friend WithEvents GridClientes As System.Windows.Forms.DataGridView
    Friend WithEvents LblClientes As System.Windows.Forms.Label
End Class
