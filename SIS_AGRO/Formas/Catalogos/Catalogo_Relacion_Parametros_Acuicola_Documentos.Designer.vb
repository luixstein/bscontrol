<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Relacion_Parametros_Acuicola_Documentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Relacion_Parametros_Acuicola_Documentos))
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
        Me.lblParametro = New System.Windows.Forms.Label()
        Me.lblNombreTipoDocumento = New System.Windows.Forms.Label()
        Me.Grid1 = New FlexCell.Grid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayCodigoTipoDocumento = New System.Windows.Forms.Label()
        Me.TxtCodigoTipoDocumento = New System.Windows.Forms.TextBox()
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
        Me.tsMenu.Size = New System.Drawing.Size(1151, 27)
        Me.tsMenu.TabIndex = 2
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
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(581, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(557, 395)
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
        Me.Grid.Location = New System.Drawing.Point(8, 53)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(540, 334)
        Me.Grid.TabIndex = 111
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(540, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 454)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1151, 25)
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
        Me.gBoxInformacion.Controls.Add(Me.lblParametro)
        Me.gBoxInformacion.Controls.Add(Me.lblNombreTipoDocumento)
        Me.gBoxInformacion.Controls.Add(Me.Grid1)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodigoTipoDocumento)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoTipoDocumento)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(557, 395)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblParametro
        '
        Me.lblParametro.AutoSize = True
        Me.lblParametro.Location = New System.Drawing.Point(8, 69)
        Me.lblParametro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblParametro.Name = "lblParametro"
        Me.lblParametro.Size = New System.Drawing.Size(82, 17)
        Me.lblParametro.TabIndex = 97
        Me.lblParametro.Text = "Parametro :"
        '
        'lblNombreTipoDocumento
        '
        Me.lblNombreTipoDocumento.AutoSize = True
        Me.lblNombreTipoDocumento.Location = New System.Drawing.Point(256, 22)
        Me.lblNombreTipoDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreTipoDocumento.Name = "lblNombreTipoDocumento"
        Me.lblNombreTipoDocumento.Size = New System.Drawing.Size(16, 17)
        Me.lblNombreTipoDocumento.TabIndex = 96
        Me.lblNombreTipoDocumento.Text = "_"
        '
        'Grid1
        '
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DefaultRowHeight = CType(24, Short)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(8, 99)
        Me.Grid1.LockButton = True
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 6
        Me.Grid1.Size = New System.Drawing.Size(538, 218)
        Me.Grid1.TabIndex = 95
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
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
        'LblDisplayCodigoTipoDocumento
        '
        Me.LblDisplayCodigoTipoDocumento.AutoSize = True
        Me.LblDisplayCodigoTipoDocumento.Location = New System.Drawing.Point(8, 22)
        Me.LblDisplayCodigoTipoDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodigoTipoDocumento.Name = "LblDisplayCodigoTipoDocumento"
        Me.LblDisplayCodigoTipoDocumento.Size = New System.Drawing.Size(161, 17)
        Me.LblDisplayCodigoTipoDocumento.TabIndex = 8
        Me.LblDisplayCodigoTipoDocumento.Text = "Código tipo documento :"
        '
        'TxtCodigoTipoDocumento
        '
        Me.TxtCodigoTipoDocumento.Location = New System.Drawing.Point(173, 19)
        Me.TxtCodigoTipoDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoTipoDocumento.MaxLength = 2
        Me.TxtCodigoTipoDocumento.Name = "TxtCodigoTipoDocumento"
        Me.TxtCodigoTipoDocumento.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoTipoDocumento.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Catalogo_Relacion_Parametros_Acuicola_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1151, 479)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Relacion_Parametros_Acuicola_Documentos"
        Me.ShowIcon = False
        Me.Text = "Catálogo relacion parametros acuicola con documentos"
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
    Friend WithEvents LblDisplayCodigoTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents lblParametro As System.Windows.Forms.Label
    Friend WithEvents lblNombreTipoDocumento As System.Windows.Forms.Label
End Class
