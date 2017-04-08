<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Productores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Productores))
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
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.lblCodigoPostal = New System.Windows.Forms.Label()
        Me.TxtRFC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.TxtFax = New System.Windows.Forms.TextBox()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.TxtDestino = New System.Windows.Forms.TextBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.TxtEstado = New System.Windows.Forms.TextBox()
        Me.TxtCiudad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodProveedor = New System.Windows.Forms.Label()
        Me.TxtCodProductor = New System.Windows.Forms.TextBox()
        Me.LblDisplayDomicilio = New System.Windows.Forms.Label()
        Me.LblDisplayNomProveedor = New System.Windows.Forms.Label()
        Me.TxtNomProductor = New System.Windows.Forms.TextBox()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(992, 27)
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
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 450)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(992, 25)
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
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(565, 39)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(409, 402)
        Me.gBoxBusquedaRapida.TabIndex = 132
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
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoPostal)
        Me.gBoxInformacion.Controls.Add(Me.lblCodigoPostal)
        Me.gBoxInformacion.Controls.Add(Me.TxtRFC)
        Me.gBoxInformacion.Controls.Add(Me.Label5)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.TxtFax)
        Me.gBoxInformacion.Controls.Add(Me.TxtTelefono)
        Me.gBoxInformacion.Controls.Add(Me.lblFax)
        Me.gBoxInformacion.Controls.Add(Me.lblTelefono)
        Me.gBoxInformacion.Controls.Add(Me.TxtDestino)
        Me.gBoxInformacion.Controls.Add(Me.lblDestino)
        Me.gBoxInformacion.Controls.Add(Me.TxtEstado)
        Me.gBoxInformacion.Controls.Add(Me.TxtCiudad)
        Me.gBoxInformacion.Controls.Add(Me.Label4)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.txtDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodProveedor)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodProductor)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNomProveedor)
        Me.gBoxInformacion.Controls.Add(Me.TxtNomProductor)
        Me.gBoxInformacion.Location = New System.Drawing.Point(19, 39)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(539, 402)
        Me.gBoxInformacion.TabIndex = 1
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información de los prodcutores"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Location = New System.Drawing.Point(147, 329)
        Me.txtCodigoPostal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoPostal.MaxLength = 120
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(373, 22)
        Me.txtCodigoPostal.TabIndex = 9
        '
        'lblCodigoPostal
        '
        Me.lblCodigoPostal.AutoSize = True
        Me.lblCodigoPostal.Location = New System.Drawing.Point(13, 332)
        Me.lblCodigoPostal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoPostal.Name = "lblCodigoPostal"
        Me.lblCodigoPostal.Size = New System.Drawing.Size(98, 17)
        Me.lblCodigoPostal.TabIndex = 161
        Me.lblCodigoPostal.Text = "Codigo postal:"
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(147, 95)
        Me.TxtRFC.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtRFC.MaxLength = 120
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(373, 22)
        Me.TxtRFC.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 98)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 17)
        Me.Label5.TabIndex = 160
        Me.Label5.Text = "RFC :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(16, 369)
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
        Me.CboEstatus.Location = New System.Drawing.Point(147, 361)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(95, 24)
        Me.CboEstatus.TabIndex = 10
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(147, 294)
        Me.TxtFax.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFax.MaxLength = 120
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(373, 22)
        Me.TxtFax.TabIndex = 8
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(147, 261)
        Me.TxtTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTelefono.MaxLength = 120
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(373, 22)
        Me.TxtTelefono.TabIndex = 7
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Location = New System.Drawing.Point(13, 298)
        Me.lblFax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(38, 17)
        Me.lblFax.TabIndex = 154
        Me.lblFax.Text = "Fax :"
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Location = New System.Drawing.Point(13, 265)
        Me.lblTelefono.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(76, 17)
        Me.lblTelefono.TabIndex = 153
        Me.lblTelefono.Text = "Telefono  :"
        '
        'TxtDestino
        '
        Me.TxtDestino.Location = New System.Drawing.Point(147, 228)
        Me.TxtDestino.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDestino.MaxLength = 120
        Me.TxtDestino.Name = "TxtDestino"
        Me.TxtDestino.Size = New System.Drawing.Size(373, 22)
        Me.TxtDestino.TabIndex = 6
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Location = New System.Drawing.Point(13, 231)
        Me.lblDestino.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(64, 17)
        Me.lblDestino.TabIndex = 152
        Me.lblDestino.Text = "Destino :"
        '
        'TxtEstado
        '
        Me.TxtEstado.Location = New System.Drawing.Point(147, 194)
        Me.TxtEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEstado.MaxLength = 120
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.Size = New System.Drawing.Size(373, 22)
        Me.TxtEstado.TabIndex = 5
        '
        'TxtCiudad
        '
        Me.TxtCiudad.Location = New System.Drawing.Point(147, 161)
        Me.TxtCiudad.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCiudad.MaxLength = 120
        Me.TxtCiudad.Name = "TxtCiudad"
        Me.TxtCiudad.Size = New System.Drawing.Size(373, 22)
        Me.TxtCiudad.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 198)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Estado :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 165)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Ciudad :"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(147, 128)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilio.MaxLength = 120
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(373, 22)
        Me.txtDomicilio.TabIndex = 3
        '
        'LblDisplayCodProveedor
        '
        Me.LblDisplayCodProveedor.AutoSize = True
        Me.LblDisplayCodProveedor.Location = New System.Drawing.Point(13, 32)
        Me.LblDisplayCodProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodProveedor.Name = "LblDisplayCodProveedor"
        Me.LblDisplayCodProveedor.Size = New System.Drawing.Size(110, 17)
        Me.LblDisplayCodProveedor.TabIndex = 127
        Me.LblDisplayCodProveedor.Text = "Cod productor  :"
        '
        'TxtCodProductor
        '
        Me.TxtCodProductor.Location = New System.Drawing.Point(147, 28)
        Me.TxtCodProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodProductor.MaxLength = 8
        Me.TxtCodProductor.Name = "TxtCodProductor"
        Me.TxtCodProductor.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodProductor.TabIndex = 0
        '
        'LblDisplayDomicilio
        '
        Me.LblDisplayDomicilio.AutoSize = True
        Me.LblDisplayDomicilio.Location = New System.Drawing.Point(13, 132)
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
        'TxtNomProductor
        '
        Me.TxtNomProductor.Location = New System.Drawing.Point(147, 62)
        Me.TxtNomProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNomProductor.MaxLength = 120
        Me.TxtNomProductor.Name = "TxtNomProductor"
        Me.TxtNomProductor.Size = New System.Drawing.Size(373, 22)
        Me.TxtNomProductor.TabIndex = 1
        '
        'Catalogo_Productores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 475)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Productores"
        Me.Text = "Catálogo de productores"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
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
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents TxtFax As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents TxtDestino As System.Windows.Forms.TextBox
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents TxtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCodProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtCodProductor As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDomicilio As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNomProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtNomProductor As System.Windows.Forms.TextBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
