<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Lineas_Transportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Lineas_Transportes))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.LblCuentaFlete = New System.Windows.Forms.Label()
        Me.txtCuentaContableFlete = New System.Windows.Forms.TextBox()
        Me.lblDisplayCuentaContable = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayNombreCultivo = New System.Windows.Forms.Label()
        Me.TxtNombreLineaTransporte = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodCultivo = New System.Windows.Forms.Label()
        Me.TxtCodigoLineaTransporte = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(860, 27)
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
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 615)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(860, 25)
        Me.StatusStripEstado.TabIndex = 6
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
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(433, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(417, 575)
        Me.gBoxBusquedaRapida.TabIndex = 7
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(400, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.LblCuentaFlete)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContableFlete)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreLineaTransporte)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoLineaTransporte)
        Me.gBoxInformacion.Location = New System.Drawing.Point(11, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(413, 575)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'LblCuentaFlete
        '
        Me.LblCuentaFlete.Location = New System.Drawing.Point(116, 114)
        Me.LblCuentaFlete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCuentaFlete.Name = "LblCuentaFlete"
        Me.LblCuentaFlete.Size = New System.Drawing.Size(289, 18)
        Me.LblCuentaFlete.TabIndex = 260
        Me.LblCuentaFlete.Text = "."
        '
        'txtCuentaContableFlete
        '
        Me.txtCuentaContableFlete.Location = New System.Drawing.Point(152, 86)
        Me.txtCuentaContableFlete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuentaContableFlete.MaxLength = 15
        Me.txtCuentaContableFlete.Name = "txtCuentaContableFlete"
        Me.txtCuentaContableFlete.Size = New System.Drawing.Size(212, 22)
        Me.txtCuentaContableFlete.TabIndex = 2
        '
        'lblDisplayCuentaContable
        '
        Me.lblDisplayCuentaContable.AutoSize = True
        Me.lblDisplayCuentaContable.Location = New System.Drawing.Point(9, 90)
        Me.lblDisplayCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaContable.Name = "lblDisplayCuentaContable"
        Me.lblDisplayCuentaContable.Size = New System.Drawing.Size(122, 17)
        Me.lblDisplayCuentaContable.TabIndex = 259
        Me.lblDisplayCuentaContable.Text = "Cta contable flete:"
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
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(8, 59)
        Me.LblDisplayNombreCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'TxtNombreLineaTransporte
        '
        Me.TxtNombreLineaTransporte.Location = New System.Drawing.Point(116, 54)
        Me.TxtNombreLineaTransporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombreLineaTransporte.MaxLength = 80
        Me.TxtNombreLineaTransporte.Name = "TxtNombreLineaTransporte"
        Me.TxtNombreLineaTransporte.Size = New System.Drawing.Size(288, 22)
        Me.TxtNombreLineaTransporte.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(8, 146)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(116, 137)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(75, 24)
        Me.CboEstatus.TabIndex = 3
        '
        'LblDisplayCodCultivo
        '
        Me.LblDisplayCodCultivo.AutoSize = True
        Me.LblDisplayCodCultivo.Location = New System.Drawing.Point(8, 28)
        Me.LblDisplayCodCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodCultivo.Name = "LblDisplayCodCultivo"
        Me.LblDisplayCodCultivo.Size = New System.Drawing.Size(99, 17)
        Me.LblDisplayCodCultivo.TabIndex = 8
        Me.LblDisplayCodCultivo.Text = "Cod. de linea :"
        '
        'TxtCodigoLineaTransporte
        '
        Me.TxtCodigoLineaTransporte.Location = New System.Drawing.Point(116, 23)
        Me.TxtCodigoLineaTransporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoLineaTransporte.MaxLength = 0
        Me.TxtCodigoLineaTransporte.Name = "TxtCodigoLineaTransporte"
        Me.TxtCodigoLineaTransporte.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoLineaTransporte.TabIndex = 0
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
        Me.Grid.Size = New System.Drawing.Size(400, 514)
        Me.Grid.TabIndex = 112
        '
        'Catalogo_Lineas_Transportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 640)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Lineas_Transportes"
        Me.Text = "Catalogo de lineas de transportes"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNombreLineaTransporte As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoLineaTransporte As System.Windows.Forms.TextBox
    Friend WithEvents LblCuentaFlete As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContableFlete As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCuentaContable As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
