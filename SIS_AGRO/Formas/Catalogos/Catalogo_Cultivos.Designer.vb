<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Cultivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Cultivos))
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
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.ckbGenerico = New System.Windows.Forms.CheckBox()
        Me.TxtObservacion1 = New System.Windows.Forms.TextBox()
        Me.lblCostosProdiccion = New System.Windows.Forms.Label()
        Me.TxtAliasExtranjero = New System.Windows.Forms.TextBox()
        Me.TxtAliasNacional = New System.Windows.Forms.TextBox()
        Me.lblDisplayAliasExtranjero = New System.Windows.Forms.Label()
        Me.LblDisplayAliasNacional = New System.Windows.Forms.Label()
        Me.txtCuentaPredio = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodCultivo = New System.Windows.Forms.Label()
        Me.TxtCodCultivo = New System.Windows.Forms.TextBox()
        Me.LblDisplayCuentaPredio = New System.Windows.Forms.Label()
        Me.LblDisplayNom = New System.Windows.Forms.Label()
        Me.TxtNomCultivo = New System.Windows.Forms.TextBox()
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
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1026, 27)
        Me.tsMenu.TabIndex = 4
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
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(563, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(450, 372)
        Me.gBoxBusquedaRapida.TabIndex = 7
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
        Me.Grid.Size = New System.Drawing.Size(434, 311)
        Me.Grid.TabIndex = 115
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(434, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.ckbGenerico)
        Me.gBoxInformacion.Controls.Add(Me.TxtObservacion1)
        Me.gBoxInformacion.Controls.Add(Me.lblCostosProdiccion)
        Me.gBoxInformacion.Controls.Add(Me.TxtAliasExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.TxtAliasNacional)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayAliasExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayAliasNacional)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaPredio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodCultivo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCuentaPredio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNom)
        Me.gBoxInformacion.Controls.Add(Me.TxtNomCultivo)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(539, 372)
        Me.gBoxInformacion.TabIndex = 6
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información del cultivo"
        '
        'ckbGenerico
        '
        Me.ckbGenerico.AutoSize = True
        Me.ckbGenerico.Location = New System.Drawing.Point(147, 249)
        Me.ckbGenerico.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbGenerico.Name = "ckbGenerico"
        Me.ckbGenerico.Size = New System.Drawing.Size(105, 21)
        Me.ckbGenerico.TabIndex = 153
        Me.ckbGenerico.Text = "Es generico"
        Me.ckbGenerico.UseVisualStyleBackColor = True
        '
        'TxtObservacion1
        '
        Me.TxtObservacion1.Location = New System.Drawing.Point(147, 194)
        Me.TxtObservacion1.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtObservacion1.MaxLength = 120
        Me.TxtObservacion1.Name = "TxtObservacion1"
        Me.TxtObservacion1.Size = New System.Drawing.Size(373, 22)
        Me.TxtObservacion1.TabIndex = 151
        '
        'lblCostosProdiccion
        '
        Me.lblCostosProdiccion.AutoSize = True
        Me.lblCostosProdiccion.Location = New System.Drawing.Point(13, 198)
        Me.lblCostosProdiccion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostosProdiccion.Name = "lblCostosProdiccion"
        Me.lblCostosProdiccion.Size = New System.Drawing.Size(135, 17)
        Me.lblCostosProdiccion.TabIndex = 152
        Me.lblCostosProdiccion.Text = "Cta. de producción :"
        '
        'TxtAliasExtranjero
        '
        Me.TxtAliasExtranjero.Location = New System.Drawing.Point(147, 161)
        Me.TxtAliasExtranjero.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAliasExtranjero.MaxLength = 120
        Me.TxtAliasExtranjero.Name = "TxtAliasExtranjero"
        Me.TxtAliasExtranjero.Size = New System.Drawing.Size(373, 22)
        Me.TxtAliasExtranjero.TabIndex = 150
        '
        'TxtAliasNacional
        '
        Me.TxtAliasNacional.Location = New System.Drawing.Point(147, 128)
        Me.TxtAliasNacional.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAliasNacional.MaxLength = 120
        Me.TxtAliasNacional.Name = "TxtAliasNacional"
        Me.TxtAliasNacional.Size = New System.Drawing.Size(373, 22)
        Me.TxtAliasNacional.TabIndex = 149
        '
        'lblDisplayAliasExtranjero
        '
        Me.lblDisplayAliasExtranjero.AutoSize = True
        Me.lblDisplayAliasExtranjero.Location = New System.Drawing.Point(13, 165)
        Me.lblDisplayAliasExtranjero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayAliasExtranjero.Name = "lblDisplayAliasExtranjero"
        Me.lblDisplayAliasExtranjero.Size = New System.Drawing.Size(113, 17)
        Me.lblDisplayAliasExtranjero.TabIndex = 148
        Me.lblDisplayAliasExtranjero.Text = "Alias extranjero :"
        '
        'LblDisplayAliasNacional
        '
        Me.LblDisplayAliasNacional.AutoSize = True
        Me.LblDisplayAliasNacional.Location = New System.Drawing.Point(13, 132)
        Me.LblDisplayAliasNacional.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayAliasNacional.Name = "LblDisplayAliasNacional"
        Me.LblDisplayAliasNacional.Size = New System.Drawing.Size(103, 17)
        Me.LblDisplayAliasNacional.TabIndex = 147
        Me.LblDisplayAliasNacional.Text = "Alias nacional :"
        '
        'txtCuentaPredio
        '
        Me.txtCuentaPredio.Location = New System.Drawing.Point(147, 95)
        Me.txtCuentaPredio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaPredio.MaxLength = 120
        Me.txtCuentaPredio.Name = "txtCuentaPredio"
        Me.txtCuentaPredio.Size = New System.Drawing.Size(373, 22)
        Me.txtCuentaPredio.TabIndex = 2
        '
        'LblDisplayCodCultivo
        '
        Me.LblDisplayCodCultivo.AutoSize = True
        Me.LblDisplayCodCultivo.Location = New System.Drawing.Point(13, 32)
        Me.LblDisplayCodCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodCultivo.Name = "LblDisplayCodCultivo"
        Me.LblDisplayCodCultivo.Size = New System.Drawing.Size(93, 17)
        Me.LblDisplayCodCultivo.TabIndex = 127
        Me.LblDisplayCodCultivo.Text = "Cod. cultivo  :"
        '
        'TxtCodCultivo
        '
        Me.TxtCodCultivo.Location = New System.Drawing.Point(147, 28)
        Me.TxtCodCultivo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodCultivo.MaxLength = 8
        Me.TxtCodCultivo.Name = "TxtCodCultivo"
        Me.TxtCodCultivo.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodCultivo.TabIndex = 0
        '
        'LblDisplayCuentaPredio
        '
        Me.LblDisplayCuentaPredio.AutoSize = True
        Me.LblDisplayCuentaPredio.Location = New System.Drawing.Point(13, 98)
        Me.LblDisplayCuentaPredio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCuentaPredio.Name = "LblDisplayCuentaPredio"
        Me.LblDisplayCuentaPredio.Size = New System.Drawing.Size(105, 17)
        Me.LblDisplayCuentaPredio.TabIndex = 124
        Me.LblDisplayCuentaPredio.Text = "Cuenta predio :"
        '
        'LblDisplayNom
        '
        Me.LblDisplayNom.AutoSize = True
        Me.LblDisplayNom.Location = New System.Drawing.Point(13, 65)
        Me.LblDisplayNom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNom.Name = "LblDisplayNom"
        Me.LblDisplayNom.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNom.TabIndex = 122
        Me.LblDisplayNom.Text = "Nombre :"
        '
        'TxtNomCultivo
        '
        Me.TxtNomCultivo.Location = New System.Drawing.Point(147, 62)
        Me.TxtNomCultivo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNomCultivo.MaxLength = 120
        Me.TxtNomCultivo.Name = "TxtNomCultivo"
        Me.TxtNomCultivo.Size = New System.Drawing.Size(373, 22)
        Me.TxtNomCultivo.TabIndex = 1
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 421)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1026, 25)
        Me.StatusStripEstado.TabIndex = 130
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
        'Catalogo_Cultivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 446)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Cultivos"
        Me.Text = "Catálogo de cultivos"
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
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtObservacion1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCostosProdiccion As System.Windows.Forms.Label
    Friend WithEvents TxtAliasExtranjero As System.Windows.Forms.TextBox
    Friend WithEvents TxtAliasNacional As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayAliasExtranjero As System.Windows.Forms.Label
    Friend WithEvents LblDisplayAliasNacional As System.Windows.Forms.Label
    Friend WithEvents txtCuentaPredio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCodCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtCodCultivo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCuentaPredio As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNom As System.Windows.Forms.Label
    Friend WithEvents TxtNomCultivo As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ckbGenerico As System.Windows.Forms.CheckBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
