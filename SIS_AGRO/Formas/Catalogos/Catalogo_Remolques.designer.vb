<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Remolques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Remolques))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.LblNombreTipoRemolque = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.lblDisplayPlaca = New System.Windows.Forms.Label()
        Me.lblMarcaTransporte = New System.Windows.Forms.Label()
        Me.lblNombreLineaTransporte = New System.Windows.Forms.Label()
        Me.TxtCodigoTipoRemolque = New System.Windows.Forms.TextBox()
        Me.LblCodigoTipoRemolque = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.lblCodigoRemolque = New System.Windows.Forms.Label()
        Me.TxtCodigoRemolque = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxInformacion.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(992, 27)
        Me.tsMenu.TabIndex = 1
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
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(565, 37)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(409, 402)
        Me.gBoxBusquedaRapida.TabIndex = 134
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
        Me.Grid.Size = New System.Drawing.Size(380, 341)
        Me.Grid.TabIndex = 113
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(380, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.LblNombreTipoRemolque)
        Me.gBoxInformacion.Controls.Add(Me.txtPlaca)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayPlaca)
        Me.gBoxInformacion.Controls.Add(Me.lblMarcaTransporte)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreLineaTransporte)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoTipoRemolque)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoTipoRemolque)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoRemolque)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoRemolque)
        Me.gBoxInformacion.Controls.Add(Me.lblNombre)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombre)
        Me.gBoxInformacion.Location = New System.Drawing.Point(19, 37)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(539, 402)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información del remolque"
        '
        'LblNombreTipoRemolque
        '
        Me.LblNombreTipoRemolque.AutoSize = True
        Me.LblNombreTipoRemolque.Location = New System.Drawing.Point(13, 177)
        Me.LblNombreTipoRemolque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreTipoRemolque.Name = "LblNombreTipoRemolque"
        Me.LblNombreTipoRemolque.Size = New System.Drawing.Size(16, 17)
        Me.LblNombreTipoRemolque.TabIndex = 166
        Me.LblNombreTipoRemolque.Text = "_"
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(87, 100)
        Me.txtPlaca.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlaca.MaxLength = 7
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(120, 22)
        Me.txtPlaca.TabIndex = 2
        '
        'lblDisplayPlaca
        '
        Me.lblDisplayPlaca.AutoSize = True
        Me.lblDisplayPlaca.Location = New System.Drawing.Point(13, 103)
        Me.lblDisplayPlaca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPlaca.Name = "lblDisplayPlaca"
        Me.lblDisplayPlaca.Size = New System.Drawing.Size(51, 17)
        Me.lblDisplayPlaca.TabIndex = 165
        Me.lblDisplayPlaca.Text = "Placa :"
        '
        'lblMarcaTransporte
        '
        Me.lblMarcaTransporte.AutoSize = True
        Me.lblMarcaTransporte.Location = New System.Drawing.Point(251, 98)
        Me.lblMarcaTransporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMarcaTransporte.Name = "lblMarcaTransporte"
        Me.lblMarcaTransporte.Size = New System.Drawing.Size(0, 17)
        Me.lblMarcaTransporte.TabIndex = 163
        '
        'lblNombreLineaTransporte
        '
        Me.lblNombreLineaTransporte.AutoSize = True
        Me.lblNombreLineaTransporte.Location = New System.Drawing.Point(251, 65)
        Me.lblNombreLineaTransporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreLineaTransporte.Name = "lblNombreLineaTransporte"
        Me.lblNombreLineaTransporte.Size = New System.Drawing.Size(0, 17)
        Me.lblNombreLineaTransporte.TabIndex = 162
        '
        'TxtCodigoTipoRemolque
        '
        Me.TxtCodigoTipoRemolque.Location = New System.Drawing.Point(171, 141)
        Me.TxtCodigoTipoRemolque.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoTipoRemolque.MaxLength = 10
        Me.TxtCodigoTipoRemolque.Name = "TxtCodigoTipoRemolque"
        Me.TxtCodigoTipoRemolque.Size = New System.Drawing.Size(130, 22)
        Me.TxtCodigoTipoRemolque.TabIndex = 3
        '
        'LblCodigoTipoRemolque
        '
        Me.LblCodigoTipoRemolque.AutoSize = True
        Me.LblCodigoTipoRemolque.Location = New System.Drawing.Point(13, 144)
        Me.LblCodigoTipoRemolque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoTipoRemolque.Name = "LblCodigoTipoRemolque"
        Me.LblCodigoTipoRemolque.Size = New System.Drawing.Size(150, 17)
        Me.LblCodigoTipoRemolque.TabIndex = 160
        Me.LblCodigoTipoRemolque.Text = "Código tipo remolque :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(13, 229)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 158
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(100, 226)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(95, 24)
        Me.CboEstatus.TabIndex = 4
        '
        'lblCodigoRemolque
        '
        Me.lblCodigoRemolque.AutoSize = True
        Me.lblCodigoRemolque.Location = New System.Drawing.Point(13, 32)
        Me.lblCodigoRemolque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoRemolque.Name = "lblCodigoRemolque"
        Me.lblCodigoRemolque.Size = New System.Drawing.Size(123, 17)
        Me.lblCodigoRemolque.TabIndex = 127
        Me.lblCodigoRemolque.Text = "Código remolque :"
        '
        'TxtCodigoRemolque
        '
        Me.TxtCodigoRemolque.Location = New System.Drawing.Point(144, 29)
        Me.TxtCodigoRemolque.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoRemolque.MaxLength = 8
        Me.TxtCodigoRemolque.Name = "TxtCodigoRemolque"
        Me.TxtCodigoRemolque.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodigoRemolque.TabIndex = 0
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(13, 66)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(66, 17)
        Me.lblNombre.TabIndex = 122
        Me.lblNombre.Text = "Nombre :"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(87, 63)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombre.MaxLength = 100
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(444, 22)
        Me.TxtNombre.TabIndex = 1
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 450)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(992, 25)
        Me.StatusStripEstado.TabIndex = 135
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
        'Catalogo_remolques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 475)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_remolques"
        Me.ShowIcon = False
        Me.Text = "Catalogo de remolques"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
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
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoTipoRemolque As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoTipoRemolque As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigoRemolque As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoRemolque As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblMarcaTransporte As System.Windows.Forms.Label
    Friend WithEvents lblNombreLineaTransporte As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayPlaca As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents LblNombreTipoRemolque As System.Windows.Forms.Label
End Class
