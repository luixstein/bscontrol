<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Distribuidores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Distribuidores))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.TxtObservacion3 = New System.Windows.Forms.TextBox()
        Me.TxtObservacion2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtObservacion1 = New System.Windows.Forms.TextBox()
        Me.lblObsercacion1 = New System.Windows.Forms.Label()
        Me.TxtEstado = New System.Windows.Forms.TextBox()
        Me.TxtCiudad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodProveedor = New System.Windows.Forms.Label()
        Me.TxtCodDistribuidor = New System.Windows.Forms.TextBox()
        Me.LblDisplayDomicilio = New System.Windows.Forms.Label()
        Me.LblDisplayNomProveedor = New System.Windows.Forms.Label()
        Me.TxtNomDistribuidor = New System.Windows.Forms.TextBox()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.tsMenu.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
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
        Me.tsMenu.Size = New System.Drawing.Size(992, 27)
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
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.TxtObservacion3)
        Me.gBoxInformacion.Controls.Add(Me.TxtObservacion2)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.Label3)
        Me.gBoxInformacion.Controls.Add(Me.TxtObservacion1)
        Me.gBoxInformacion.Controls.Add(Me.lblObsercacion1)
        Me.gBoxInformacion.Controls.Add(Me.TxtEstado)
        Me.gBoxInformacion.Controls.Add(Me.TxtCiudad)
        Me.gBoxInformacion.Controls.Add(Me.Label4)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.txtDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodProveedor)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodDistribuidor)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNomProveedor)
        Me.gBoxInformacion.Controls.Add(Me.TxtNomDistribuidor)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(539, 372)
        Me.gBoxInformacion.TabIndex = 4
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información de los distribuidores"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(13, 297)
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
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(147, 293)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(75, 24)
        Me.CboEstatus.TabIndex = 157
        '
        'TxtObservacion3
        '
        Me.TxtObservacion3.Location = New System.Drawing.Point(147, 261)
        Me.TxtObservacion3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtObservacion3.MaxLength = 120
        Me.TxtObservacion3.Name = "TxtObservacion3"
        Me.TxtObservacion3.Size = New System.Drawing.Size(373, 22)
        Me.TxtObservacion3.TabIndex = 156
        '
        'TxtObservacion2
        '
        Me.TxtObservacion2.Location = New System.Drawing.Point(147, 228)
        Me.TxtObservacion2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtObservacion2.MaxLength = 120
        Me.TxtObservacion2.Name = "TxtObservacion2"
        Me.TxtObservacion2.Size = New System.Drawing.Size(373, 22)
        Me.TxtObservacion2.TabIndex = 155
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 265)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 17)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "Observación 3 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 231)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 17)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "Observación 2 :"
        '
        'TxtObservacion1
        '
        Me.TxtObservacion1.Location = New System.Drawing.Point(147, 194)
        Me.TxtObservacion1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtObservacion1.MaxLength = 120
        Me.TxtObservacion1.Name = "TxtObservacion1"
        Me.TxtObservacion1.Size = New System.Drawing.Size(373, 22)
        Me.TxtObservacion1.TabIndex = 151
        '
        'lblObsercacion1
        '
        Me.lblObsercacion1.AutoSize = True
        Me.lblObsercacion1.Location = New System.Drawing.Point(13, 198)
        Me.lblObsercacion1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblObsercacion1.Name = "lblObsercacion1"
        Me.lblObsercacion1.Size = New System.Drawing.Size(108, 17)
        Me.lblObsercacion1.TabIndex = 152
        Me.lblObsercacion1.Text = "Observación 1 :"
        '
        'TxtEstado
        '
        Me.TxtEstado.Location = New System.Drawing.Point(147, 161)
        Me.TxtEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtEstado.MaxLength = 120
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.Size = New System.Drawing.Size(373, 22)
        Me.TxtEstado.TabIndex = 150
        '
        'TxtCiudad
        '
        Me.TxtCiudad.Location = New System.Drawing.Point(147, 128)
        Me.TxtCiudad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCiudad.MaxLength = 120
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(373, 22)
        Me.TxtCiudad.TabIndex = 149
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 165)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Estado :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 132)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Ciudad :"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(147, 95)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDomicilio.MaxLength = 120
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(373, 22)
        Me.txtDomicilio.TabIndex = 2
        '
        'LblDisplayCodProveedor
        '
        Me.LblDisplayCodProveedor.AutoSize = True
        Me.LblDisplayCodProveedor.Location = New System.Drawing.Point(13, 32)
        Me.LblDisplayCodProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodProveedor.Name = "LblDisplayCodProveedor"
        Me.LblDisplayCodProveedor.Size = New System.Drawing.Size(119, 17)
        Me.LblDisplayCodProveedor.TabIndex = 127
        Me.LblDisplayCodProveedor.Text = "Cod distribuidor  :"
        '
        'TxtCodDistribuidor
        '
        Me.TxtCodDistribuidor.Location = New System.Drawing.Point(147, 28)
        Me.TxtCodDistribuidor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodDistribuidor.MaxLength = 8
        Me.TxtCodDistribuidor.Name = "TxtCodDistribuidor"
        Me.TxtCodDistribuidor.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodDistribuidor.TabIndex = 0
        '
        'LblDisplayDomicilio
        '
        Me.LblDisplayDomicilio.AutoSize = True
        Me.LblDisplayDomicilio.Location = New System.Drawing.Point(13, 98)
        Me.LblDisplayDomicilio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDomicilio.Name = "LblDisplayDomicilio"
        Me.LblDisplayDomicilio.Size = New System.Drawing.Size(72, 17)
        Me.LblDisplayDomicilio.TabIndex = 124
        Me.LblDisplayDomicilio.Text = "Domicilio :"
        '
        'LblDisplayNomProveedor
        '
        Me.LblDisplayNomProveedor.AutoSize = True
        Me.LblDisplayNomProveedor.Location = New System.Drawing.Point(13, 65)
        Me.LblDisplayNomProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNomProveedor.Name = "LblDisplayNomProveedor"
        Me.LblDisplayNomProveedor.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNomProveedor.TabIndex = 122
        Me.LblDisplayNomProveedor.Text = "Nombre :"
        '
        'TxtNomDistribuidor
        '
        Me.TxtNomDistribuidor.Location = New System.Drawing.Point(147, 62)
        Me.TxtNomDistribuidor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNomDistribuidor.MaxLength = 120
        Me.TxtNomDistribuidor.Name = "TxtNomDistribuidor"
        Me.TxtNomDistribuidor.Size = New System.Drawing.Size(373, 22)
        Me.TxtNomDistribuidor.TabIndex = 1
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(563, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(409, 372)
        Me.gBoxBusquedaRapida.TabIndex = 5
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
        Me.txtFiltro.Size = New System.Drawing.Size(380, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 427)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(992, 25)
        Me.StatusStripEstado.TabIndex = 129
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
        Me.Grid.Location = New System.Drawing.Point(8, 53)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(380, 311)
        Me.Grid.TabIndex = 111
        '
        'Catalogo_Distribuidores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 452)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Distribuidores"
        Me.Text = "Catálogo de distribuidores"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
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
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCodProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtCodDistribuidor As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDomicilio As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNomProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtNomDistribuidor As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents TxtObservacion3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtObservacion2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtObservacion1 As System.Windows.Forms.TextBox
    Friend WithEvents lblObsercacion1 As System.Windows.Forms.Label
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents TxtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
