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
        Me.txtFraccionArancelaria = New System.Windows.Forms.TextBox()
        Me.lblDisplayFraccionArancelaria = New System.Windows.Forms.Label()
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
        Me.tsMenu.Size = New System.Drawing.Size(770, 27)
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
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(422, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(338, 302)
        Me.gBoxBusquedaRapida.TabIndex = 1
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
        Me.Grid.Location = New System.Drawing.Point(6, 43)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(326, 253)
        Me.Grid.TabIndex = 115
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(326, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.txtFraccionArancelaria)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFraccionArancelaria)
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
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(404, 302)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información del cultivo"
        '
        'ckbGenerico
        '
        Me.ckbGenerico.AutoSize = True
        Me.ckbGenerico.Location = New System.Drawing.Point(110, 225)
        Me.ckbGenerico.Name = "ckbGenerico"
        Me.ckbGenerico.Size = New System.Drawing.Size(82, 17)
        Me.ckbGenerico.TabIndex = 7
        Me.ckbGenerico.Text = "Es generico"
        Me.ckbGenerico.UseVisualStyleBackColor = True
        Me.ckbGenerico.Visible = False
        '
        'TxtObservacion1
        '
        Me.TxtObservacion1.Location = New System.Drawing.Point(110, 158)
        Me.TxtObservacion1.MaxLength = 120
        Me.TxtObservacion1.Name = "TxtObservacion1"
        Me.TxtObservacion1.Size = New System.Drawing.Size(281, 20)
        Me.TxtObservacion1.TabIndex = 5
        '
        'lblCostosProdiccion
        '
        Me.lblCostosProdiccion.AutoSize = True
        Me.lblCostosProdiccion.Location = New System.Drawing.Point(10, 161)
        Me.lblCostosProdiccion.Name = "lblCostosProdiccion"
        Me.lblCostosProdiccion.Size = New System.Drawing.Size(103, 13)
        Me.lblCostosProdiccion.TabIndex = 152
        Me.lblCostosProdiccion.Text = "Cta. de producción :"
        '
        'TxtAliasExtranjero
        '
        Me.TxtAliasExtranjero.Location = New System.Drawing.Point(110, 131)
        Me.TxtAliasExtranjero.MaxLength = 120
        Me.TxtAliasExtranjero.Name = "TxtAliasExtranjero"
        Me.TxtAliasExtranjero.Size = New System.Drawing.Size(281, 20)
        Me.TxtAliasExtranjero.TabIndex = 4
        '
        'TxtAliasNacional
        '
        Me.TxtAliasNacional.Location = New System.Drawing.Point(110, 104)
        Me.TxtAliasNacional.MaxLength = 120
        Me.TxtAliasNacional.Name = "TxtAliasNacional"
        Me.TxtAliasNacional.Size = New System.Drawing.Size(281, 20)
        Me.TxtAliasNacional.TabIndex = 3
        '
        'lblDisplayAliasExtranjero
        '
        Me.lblDisplayAliasExtranjero.AutoSize = True
        Me.lblDisplayAliasExtranjero.Location = New System.Drawing.Point(10, 134)
        Me.lblDisplayAliasExtranjero.Name = "lblDisplayAliasExtranjero"
        Me.lblDisplayAliasExtranjero.Size = New System.Drawing.Size(84, 13)
        Me.lblDisplayAliasExtranjero.TabIndex = 148
        Me.lblDisplayAliasExtranjero.Text = "Alias extranjero :"
        '
        'LblDisplayAliasNacional
        '
        Me.LblDisplayAliasNacional.AutoSize = True
        Me.LblDisplayAliasNacional.Location = New System.Drawing.Point(10, 107)
        Me.LblDisplayAliasNacional.Name = "LblDisplayAliasNacional"
        Me.LblDisplayAliasNacional.Size = New System.Drawing.Size(78, 13)
        Me.LblDisplayAliasNacional.TabIndex = 147
        Me.LblDisplayAliasNacional.Text = "Alias nacional :"
        '
        'txtCuentaPredio
        '
        Me.txtCuentaPredio.Location = New System.Drawing.Point(110, 77)
        Me.txtCuentaPredio.MaxLength = 120
        Me.txtCuentaPredio.Name = "txtCuentaPredio"
        Me.txtCuentaPredio.Size = New System.Drawing.Size(281, 20)
        Me.txtCuentaPredio.TabIndex = 2
        '
        'LblDisplayCodCultivo
        '
        Me.LblDisplayCodCultivo.AutoSize = True
        Me.LblDisplayCodCultivo.Location = New System.Drawing.Point(10, 26)
        Me.LblDisplayCodCultivo.Name = "LblDisplayCodCultivo"
        Me.LblDisplayCodCultivo.Size = New System.Drawing.Size(72, 13)
        Me.LblDisplayCodCultivo.TabIndex = 127
        Me.LblDisplayCodCultivo.Text = "Cod. cultivo  :"
        '
        'TxtCodCultivo
        '
        Me.TxtCodCultivo.Location = New System.Drawing.Point(110, 23)
        Me.TxtCodCultivo.MaxLength = 8
        Me.TxtCodCultivo.Name = "TxtCodCultivo"
        Me.TxtCodCultivo.Size = New System.Drawing.Size(72, 20)
        Me.TxtCodCultivo.TabIndex = 0
        '
        'LblDisplayCuentaPredio
        '
        Me.LblDisplayCuentaPredio.AutoSize = True
        Me.LblDisplayCuentaPredio.Location = New System.Drawing.Point(10, 80)
        Me.LblDisplayCuentaPredio.Name = "LblDisplayCuentaPredio"
        Me.LblDisplayCuentaPredio.Size = New System.Drawing.Size(79, 13)
        Me.LblDisplayCuentaPredio.TabIndex = 124
        Me.LblDisplayCuentaPredio.Text = "Cuenta predio :"
        '
        'LblDisplayNom
        '
        Me.LblDisplayNom.AutoSize = True
        Me.LblDisplayNom.Location = New System.Drawing.Point(10, 53)
        Me.LblDisplayNom.Name = "LblDisplayNom"
        Me.LblDisplayNom.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayNom.TabIndex = 122
        Me.LblDisplayNom.Text = "Nombre :"
        '
        'TxtNomCultivo
        '
        Me.TxtNomCultivo.Location = New System.Drawing.Point(110, 50)
        Me.TxtNomCultivo.MaxLength = 120
        Me.TxtNomCultivo.Name = "TxtNomCultivo"
        Me.TxtNomCultivo.Size = New System.Drawing.Size(281, 20)
        Me.TxtNomCultivo.TabIndex = 1
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 340)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(770, 22)
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
        'txtFraccionArancelaria
        '
        Me.txtFraccionArancelaria.Location = New System.Drawing.Point(110, 194)
        Me.txtFraccionArancelaria.MaxLength = 20
        Me.txtFraccionArancelaria.Name = "txtFraccionArancelaria"
        Me.txtFraccionArancelaria.Size = New System.Drawing.Size(281, 20)
        Me.txtFraccionArancelaria.TabIndex = 6
        '
        'lblDisplayFraccionArancelaria
        '
        Me.lblDisplayFraccionArancelaria.Location = New System.Drawing.Point(10, 187)
        Me.lblDisplayFraccionArancelaria.Name = "lblDisplayFraccionArancelaria"
        Me.lblDisplayFraccionArancelaria.Size = New System.Drawing.Size(84, 27)
        Me.lblDisplayFraccionArancelaria.TabIndex = 155
        Me.lblDisplayFraccionArancelaria.Text = "Fracción arancelaria :"
        '
        'Catalogo_Cultivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 362)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
    Friend WithEvents txtFraccionArancelaria As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFraccionArancelaria As System.Windows.Forms.Label
End Class
