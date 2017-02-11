<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_ConfiguracionPesoEnvase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_ConfiguracionPesoEnvase))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox
        Me.lblDisplayTamaño = New System.Windows.Forms.Label
        Me.CboTipoTamaño = New System.Windows.Forms.ComboBox
        Me.TxtPeso = New System.Windows.Forms.TextBox
        Me.lblDisplayPeso = New System.Windows.Forms.Label
        Me.cboCultivo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblDisplayTipoTamaño = New System.Windows.Forms.Label
        Me.CboTipoEnvase = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox
        Me.rdbNombreCultivo = New System.Windows.Forms.RadioButton
        Me.rdbTipoEnvase = New System.Windows.Forms.RadioButton
        Me.Grid = New System.Windows.Forms.DataGridView
        Me.txtfiltro = New System.Windows.Forms.TextBox
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(962, 25)
        Me.tsMenu.TabIndex = 26
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(73, 22)
        Me.tsbCancelar.Text = "&Cancelar"
        '
        'tsbImprimirListado
        '
        Me.tsbImprimirListado.Image = CType(resources.GetObject("tsbImprimirListado.Image"), System.Drawing.Image)
        Me.tsbImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirListado.Name = "tsbImprimirListado"
        Me.tsbImprimirListado.Size = New System.Drawing.Size(111, 22)
        Me.tsbImprimirListado.Text = "&Imprimir listado"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 395)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(962, 22)
        Me.StatusStripEstado.TabIndex = 28
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
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTamaño)
        Me.gBoxInformacion.Controls.Add(Me.CboTipoTamaño)
        Me.gBoxInformacion.Controls.Add(Me.TxtPeso)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayPeso)
        Me.gBoxInformacion.Controls.Add(Me.cboCultivo)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayTipoTamaño)
        Me.gBoxInformacion.Controls.Add(Me.CboTipoEnvase)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(390, 346)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblDisplayTamaño
        '
        Me.lblDisplayTamaño.AutoSize = True
        Me.lblDisplayTamaño.Location = New System.Drawing.Point(9, 50)
        Me.lblDisplayTamaño.Name = "lblDisplayTamaño"
        Me.lblDisplayTamaño.Size = New System.Drawing.Size(87, 13)
        Me.lblDisplayTamaño.TabIndex = 283
        Me.lblDisplayTamaño.Text = "Tipo de tamaño :"
        '
        'CboTipoTamaño
        '
        Me.CboTipoTamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoTamaño.FormattingEnabled = True
        Me.CboTipoTamaño.Items.AddRange(New Object() {"A", "B"})
        Me.CboTipoTamaño.Location = New System.Drawing.Point(102, 46)
        Me.CboTipoTamaño.MaxLength = 1
        Me.CboTipoTamaño.Name = "CboTipoTamaño"
        Me.CboTipoTamaño.Size = New System.Drawing.Size(270, 21)
        Me.CboTipoTamaño.TabIndex = 1
        '
        'TxtPeso
        '
        Me.TxtPeso.Location = New System.Drawing.Point(102, 103)
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(100, 20)
        Me.TxtPeso.TabIndex = 3
        Me.TxtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayPeso
        '
        Me.lblDisplayPeso.AutoSize = True
        Me.lblDisplayPeso.Location = New System.Drawing.Point(9, 107)
        Me.lblDisplayPeso.Name = "lblDisplayPeso"
        Me.lblDisplayPeso.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayPeso.TabIndex = 281
        Me.lblDisplayPeso.Text = "Peso :"
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboCultivo.Location = New System.Drawing.Point(102, 19)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(270, 21)
        Me.cboCultivo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 280
        Me.Label1.Text = "Cultivo :"
        '
        'LblDisplayTipoTamaño
        '
        Me.LblDisplayTipoTamaño.AutoSize = True
        Me.LblDisplayTipoTamaño.Location = New System.Drawing.Point(9, 80)
        Me.LblDisplayTipoTamaño.Name = "LblDisplayTipoTamaño"
        Me.LblDisplayTipoTamaño.Size = New System.Drawing.Size(87, 13)
        Me.LblDisplayTipoTamaño.TabIndex = 95
        Me.LblDisplayTipoTamaño.Text = "Tipo de envase :"
        '
        'CboTipoEnvase
        '
        Me.CboTipoEnvase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoEnvase.FormattingEnabled = True
        Me.CboTipoEnvase.Items.AddRange(New Object() {"A", "B"})
        Me.CboTipoEnvase.Location = New System.Drawing.Point(102, 76)
        Me.CboTipoEnvase.MaxLength = 1
        Me.CboTipoEnvase.Name = "CboTipoEnvase"
        Me.CboTipoEnvase.Size = New System.Drawing.Size(270, 21)
        Me.CboTipoEnvase.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rdbNombreCultivo)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rdbTipoEnvase)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtfiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(408, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(534, 346)
        Me.gBoxBusquedaRapida.TabIndex = 30
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'rdbNombreCultivo
        '
        Me.rdbNombreCultivo.AutoSize = True
        Me.rdbNombreCultivo.Location = New System.Drawing.Point(6, 19)
        Me.rdbNombreCultivo.Name = "rdbNombreCultivo"
        Me.rdbNombreCultivo.Size = New System.Drawing.Size(57, 17)
        Me.rdbNombreCultivo.TabIndex = 110
        Me.rdbNombreCultivo.TabStop = True
        Me.rdbNombreCultivo.Text = "Cultivo"
        Me.rdbNombreCultivo.UseVisualStyleBackColor = True
        '
        'rdbTipoEnvase
        '
        Me.rdbTipoEnvase.AutoSize = True
        Me.rdbTipoEnvase.Location = New System.Drawing.Point(221, 19)
        Me.rdbTipoEnvase.Name = "rdbTipoEnvase"
        Me.rdbTipoEnvase.Size = New System.Drawing.Size(61, 17)
        Me.rdbTipoEnvase.TabIndex = 109
        Me.rdbTipoEnvase.TabStop = True
        Me.rdbTipoEnvase.Text = "Envase"
        Me.rdbTipoEnvase.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(6, 71)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(522, 269)
        Me.Grid.TabIndex = 108
        '
        'txtfiltro
        '
        Me.txtfiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtfiltro.Location = New System.Drawing.Point(6, 45)
        Me.txtfiltro.Name = "txtfiltro"
        Me.txtfiltro.Size = New System.Drawing.Size(522, 20)
        Me.txtfiltro.TabIndex = 0
        '
        'Frm_Embarques_ConfiguracionPesoEnvase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 417)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_ConfiguracionPesoEnvase"
        Me.Text = "Configuracion de peso de envase"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
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
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPeso As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayPeso As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayTipoTamaño As System.Windows.Forms.Label
    Friend WithEvents CboTipoEnvase As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTamaño As System.Windows.Forms.Label
    Friend WithEvents CboTipoTamaño As System.Windows.Forms.ComboBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNombreCultivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTipoEnvase As System.Windows.Forms.RadioButton
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents txtfiltro As System.Windows.Forms.TextBox
End Class
