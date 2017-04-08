<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_transportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_transportes))
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
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.lblDisplayPlaca = New System.Windows.Forms.Label()
        Me.lblMarcaTransporte = New System.Windows.Forms.Label()
        Me.lblNombreLineaTransporte = New System.Windows.Forms.Label()
        Me.txtScac = New System.Windows.Forms.TextBox()
        Me.TxtMarca = New System.Windows.Forms.TextBox()
        Me.LblDisplayMarca = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.TxtFda = New System.Windows.Forms.TextBox()
        Me.lblDisplayFda = New System.Windows.Forms.Label()
        Me.TxtSerie = New System.Windows.Forms.TextBox()
        Me.lblDisplayScac = New System.Windows.Forms.Label()
        Me.lblDisplaySerie = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodTransporte = New System.Windows.Forms.Label()
        Me.TxtCodTransporte = New System.Windows.Forms.TextBox()
        Me.LblDisplayModelo = New System.Windows.Forms.Label()
        Me.LblDisplayLinea = New System.Windows.Forms.Label()
        Me.TxtLinea = New System.Windows.Forms.TextBox()
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
        Me.gBoxInformacion.Controls.Add(Me.txtPlaca)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayPlaca)
        Me.gBoxInformacion.Controls.Add(Me.lblMarcaTransporte)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreLineaTransporte)
        Me.gBoxInformacion.Controls.Add(Me.txtScac)
        Me.gBoxInformacion.Controls.Add(Me.TxtMarca)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayMarca)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.TxtFda)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFda)
        Me.gBoxInformacion.Controls.Add(Me.TxtSerie)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayScac)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplaySerie)
        Me.gBoxInformacion.Controls.Add(Me.txtModelo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodTransporte)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodTransporte)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayModelo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayLinea)
        Me.gBoxInformacion.Controls.Add(Me.TxtLinea)
        Me.gBoxInformacion.Location = New System.Drawing.Point(19, 37)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(539, 402)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información del transporte"
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(147, 132)
        Me.txtPlaca.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPlaca.MaxLength = 20
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(373, 22)
        Me.txtPlaca.TabIndex = 3
        '
        'lblDisplayPlaca
        '
        Me.lblDisplayPlaca.AutoSize = True
        Me.lblDisplayPlaca.Location = New System.Drawing.Point(13, 135)
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
        'txtScac
        '
        Me.txtScac.Location = New System.Drawing.Point(147, 235)
        Me.txtScac.Margin = New System.Windows.Forms.Padding(4)
        Me.txtScac.MaxLength = 20
        Me.txtScac.Name = "txtScac"
        Me.txtScac.Size = New System.Drawing.Size(373, 22)
        Me.txtScac.TabIndex = 6
        '
        'TxtMarca
        '
        Me.TxtMarca.Location = New System.Drawing.Point(147, 97)
        Me.TxtMarca.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMarca.MaxLength = 8
        Me.TxtMarca.Name = "TxtMarca"
        Me.TxtMarca.Size = New System.Drawing.Size(95, 22)
        Me.TxtMarca.TabIndex = 2
        '
        'LblDisplayMarca
        '
        Me.LblDisplayMarca.AutoSize = True
        Me.LblDisplayMarca.Location = New System.Drawing.Point(13, 98)
        Me.LblDisplayMarca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayMarca.Name = "LblDisplayMarca"
        Me.LblDisplayMarca.Size = New System.Drawing.Size(55, 17)
        Me.LblDisplayMarca.TabIndex = 160
        Me.LblDisplayMarca.Text = "Marca :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(13, 308)
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
        Me.CboEstatus.Location = New System.Drawing.Point(147, 304)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(95, 24)
        Me.CboEstatus.TabIndex = 8
        '
        'TxtFda
        '
        Me.TxtFda.Location = New System.Drawing.Point(147, 270)
        Me.TxtFda.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFda.MaxLength = 20
        Me.TxtFda.Name = "TxtFda"
        Me.TxtFda.Size = New System.Drawing.Size(373, 22)
        Me.TxtFda.TabIndex = 7
        '
        'lblDisplayFda
        '
        Me.lblDisplayFda.AutoSize = True
        Me.lblDisplayFda.Location = New System.Drawing.Point(13, 273)
        Me.lblDisplayFda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFda.Name = "lblDisplayFda"
        Me.lblDisplayFda.Size = New System.Drawing.Size(43, 17)
        Me.lblDisplayFda.TabIndex = 152
        Me.lblDisplayFda.Text = "FDA :"
        '
        'TxtSerie
        '
        Me.TxtSerie.Location = New System.Drawing.Point(147, 201)
        Me.TxtSerie.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSerie.MaxLength = 20
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(373, 22)
        Me.TxtSerie.TabIndex = 5
        '
        'lblDisplayScac
        '
        Me.lblDisplayScac.AutoSize = True
        Me.lblDisplayScac.Location = New System.Drawing.Point(13, 239)
        Me.lblDisplayScac.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayScac.Name = "lblDisplayScac"
        Me.lblDisplayScac.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplayScac.TabIndex = 148
        Me.lblDisplayScac.Text = "SCAC :"
        '
        'lblDisplaySerie
        '
        Me.lblDisplaySerie.AutoSize = True
        Me.lblDisplaySerie.Location = New System.Drawing.Point(13, 204)
        Me.lblDisplaySerie.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySerie.Name = "lblDisplaySerie"
        Me.lblDisplaySerie.Size = New System.Drawing.Size(49, 17)
        Me.lblDisplaySerie.TabIndex = 147
        Me.lblDisplaySerie.Text = "Serie :"
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(147, 166)
        Me.txtModelo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtModelo.MaxLength = 20
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(373, 22)
        Me.txtModelo.TabIndex = 4
        '
        'LblDisplayCodTransporte
        '
        Me.LblDisplayCodTransporte.AutoSize = True
        Me.LblDisplayCodTransporte.Location = New System.Drawing.Point(13, 32)
        Me.LblDisplayCodTransporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodTransporte.Name = "LblDisplayCodTransporte"
        Me.LblDisplayCodTransporte.Size = New System.Drawing.Size(119, 17)
        Me.LblDisplayCodTransporte.TabIndex = 127
        Me.LblDisplayCodTransporte.Text = "Cod. Transporte :"
        '
        'TxtCodTransporte
        '
        Me.TxtCodTransporte.Location = New System.Drawing.Point(147, 28)
        Me.TxtCodTransporte.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodTransporte.MaxLength = 8
        Me.TxtCodTransporte.Name = "TxtCodTransporte"
        Me.TxtCodTransporte.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodTransporte.TabIndex = 0
        '
        'LblDisplayModelo
        '
        Me.LblDisplayModelo.AutoSize = True
        Me.LblDisplayModelo.Location = New System.Drawing.Point(13, 170)
        Me.LblDisplayModelo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayModelo.Name = "LblDisplayModelo"
        Me.LblDisplayModelo.Size = New System.Drawing.Size(62, 17)
        Me.LblDisplayModelo.TabIndex = 124
        Me.LblDisplayModelo.Text = "Modelo :"
        '
        'LblDisplayLinea
        '
        Me.LblDisplayLinea.AutoSize = True
        Me.LblDisplayLinea.Location = New System.Drawing.Point(13, 66)
        Me.LblDisplayLinea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayLinea.Name = "LblDisplayLinea"
        Me.LblDisplayLinea.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayLinea.TabIndex = 122
        Me.LblDisplayLinea.Text = "Linea :"
        '
        'TxtLinea
        '
        Me.TxtLinea.Location = New System.Drawing.Point(147, 63)
        Me.TxtLinea.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLinea.MaxLength = 8
        Me.TxtLinea.Name = "TxtLinea"
        Me.TxtLinea.Size = New System.Drawing.Size(95, 22)
        Me.TxtLinea.TabIndex = 1
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
        'Catalogo_transportes
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
        Me.Name = "Catalogo_transportes"
        Me.Text = "Catalogo de transportes"
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
    Friend WithEvents TxtMarca As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayMarca As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents TxtFda As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFda As System.Windows.Forms.Label
    Friend WithEvents TxtSerie As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayScac As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySerie As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCodTransporte As System.Windows.Forms.Label
    Friend WithEvents TxtCodTransporte As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayModelo As System.Windows.Forms.Label
    Friend WithEvents LblDisplayLinea As System.Windows.Forms.Label
    Friend WithEvents TxtLinea As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtScac As System.Windows.Forms.TextBox
    Friend WithEvents lblMarcaTransporte As System.Windows.Forms.Label
    Friend WithEvents lblNombreLineaTransporte As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayPlaca As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
