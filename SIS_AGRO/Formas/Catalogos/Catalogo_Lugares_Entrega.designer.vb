<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Lugares_Entrega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Lugares_Entrega))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.lblVisa = New System.Windows.Forms.Label()
        Me.txtImporteFlete = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayNombreCultivo = New System.Windows.Forms.Label()
        Me.TxtNombreLugarEntrega = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodLugarEntrega = New System.Windows.Forms.Label()
        Me.TxtCodigoLugarEntrega = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(879, 27)
        Me.tsMenu.TabIndex = 6
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
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(435, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(428, 517)
        Me.gBoxBusquedaRapida.TabIndex = 7
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(13, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(407, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.lblVisa)
        Me.gBoxInformacion.Controls.Add(Me.txtImporteFlete)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreLugarEntrega)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodLugarEntrega)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoLugarEntrega)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(411, 517)
        Me.gBoxInformacion.TabIndex = 8
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblVisa
        '
        Me.lblVisa.AutoSize = True
        Me.lblVisa.Location = New System.Drawing.Point(8, 91)
        Me.lblVisa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisa.Name = "lblVisa"
        Me.lblVisa.Size = New System.Drawing.Size(113, 17)
        Me.lblVisa.TabIndex = 95
        Me.lblVisa.Text = "Importe del flete:"
        '
        'txtImporteFlete
        '
        Me.txtImporteFlete.Location = New System.Drawing.Point(121, 87)
        Me.txtImporteFlete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtImporteFlete.MaxLength = 80
        Me.txtImporteFlete.Name = "txtImporteFlete"
        Me.txtImporteFlete.Size = New System.Drawing.Size(284, 22)
        Me.txtImporteFlete.TabIndex = 3
        Me.txtImporteFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'TxtNombreLugarEntrega
        '
        Me.TxtNombreLugarEntrega.Location = New System.Drawing.Point(121, 55)
        Me.TxtNombreLugarEntrega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombreLugarEntrega.MaxLength = 80
        Me.TxtNombreLugarEntrega.Name = "TxtNombreLugarEntrega"
        Me.TxtNombreLugarEntrega.Size = New System.Drawing.Size(284, 22)
        Me.TxtNombreLugarEntrega.TabIndex = 1
        '
        'LblDisplayCodLugarEntrega
        '
        Me.LblDisplayCodLugarEntrega.AutoSize = True
        Me.LblDisplayCodLugarEntrega.Location = New System.Drawing.Point(8, 27)
        Me.LblDisplayCodLugarEntrega.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodLugarEntrega.Name = "LblDisplayCodLugarEntrega"
        Me.LblDisplayCodLugarEntrega.Size = New System.Drawing.Size(170, 17)
        Me.LblDisplayCodLugarEntrega.TabIndex = 8
        Me.LblDisplayCodLugarEntrega.Text = "Cod. de lugar de entrega:"
        '
        'TxtCodigoLugarEntrega
        '
        Me.TxtCodigoLugarEntrega.Location = New System.Drawing.Point(185, 23)
        Me.TxtCodigoLugarEntrega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoLugarEntrega.MaxLength = 0
        Me.TxtCodigoLugarEntrega.Name = "TxtCodigoLugarEntrega"
        Me.TxtCodigoLugarEntrega.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoLugarEntrega.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 557)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(879, 25)
        Me.StatusStripEstado.TabIndex = 13
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
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(13, 53)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(407, 456)
        Me.Grid.TabIndex = 112
        '
        'Catalogo_Lugares_Entrega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 582)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Lugares_Entrega"
        Me.Text = "Catálogo de lugares de entrega"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
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
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblVisa As System.Windows.Forms.Label
    Friend WithEvents txtImporteFlete As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNombreLugarEntrega As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCodLugarEntrega As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoLugarEntrega As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
