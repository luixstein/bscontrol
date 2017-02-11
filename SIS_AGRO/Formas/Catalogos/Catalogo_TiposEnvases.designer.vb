<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_TiposEnvases
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_TiposEnvases))
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblDisplayNombreTipoTamaño = New System.Windows.Forms.Label
        Me.TxtNombreTipoEnvase = New System.Windows.Forms.TextBox
        Me.LblEstatus = New System.Windows.Forms.Label
        Me.CboEstatus = New System.Windows.Forms.ComboBox
        Me.LblCodigoTipoTamaño = New System.Windows.Forms.Label
        Me.TxtCodigoTipoEnvase = New System.Windows.Forms.TextBox
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox
        Me.txtFiltro = New System.Windows.Forms.TextBox
        Me.lstbElementos = New System.Windows.Forms.ListBox
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(754, 25)
        Me.tsMenu.TabIndex = 28
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 353)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(754, 22)
        Me.StatusStripEstado.TabIndex = 29
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
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreTipoTamaño)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreTipoEnvase)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoTipoTamaño)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoTipoEnvase)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(310, 321)
        Me.gBoxInformacion.TabIndex = 26
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'LblDisplayNombreTipoTamaño
        '
        Me.LblDisplayNombreTipoTamaño.AutoSize = True
        Me.LblDisplayNombreTipoTamaño.Location = New System.Drawing.Point(6, 44)
        Me.LblDisplayNombreTipoTamaño.Name = "LblDisplayNombreTipoTamaño"
        Me.LblDisplayNombreTipoTamaño.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayNombreTipoTamaño.TabIndex = 74
        Me.LblDisplayNombreTipoTamaño.Text = "Nombre :"
        '
        'TxtNombreTipoEnvase
        '
        Me.TxtNombreTipoEnvase.Location = New System.Drawing.Point(77, 41)
        Me.TxtNombreTipoEnvase.MaxLength = 50
        Me.TxtNombreTipoEnvase.Name = "TxtNombreTipoEnvase"
        Me.TxtNombreTipoEnvase.Size = New System.Drawing.Size(227, 20)
        Me.TxtNombreTipoEnvase.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(6, 70)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(76, 67)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(57, 21)
        Me.CboEstatus.TabIndex = 2
        '
        'LblCodigoTipoTamaño
        '
        Me.LblCodigoTipoTamaño.AutoSize = True
        Me.LblCodigoTipoTamaño.Location = New System.Drawing.Point(6, 18)
        Me.LblCodigoTipoTamaño.Name = "LblCodigoTipoTamaño"
        Me.LblCodigoTipoTamaño.Size = New System.Drawing.Size(46, 13)
        Me.LblCodigoTipoTamaño.TabIndex = 8
        Me.LblCodigoTipoTamaño.Text = "Código :"
        '
        'TxtCodigoTipoEnvase
        '
        Me.TxtCodigoTipoEnvase.Location = New System.Drawing.Point(76, 15)
        Me.TxtCodigoTipoEnvase.MaxLength = 2
        Me.TxtCodigoTipoEnvase.Name = "TxtCodigoTipoEnvase"
        Me.TxtCodigoTipoEnvase.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodigoTipoEnvase.TabIndex = 0
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.lstbElementos)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(329, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(418, 321)
        Me.gBoxBusquedaRapida.TabIndex = 27
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 19)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(406, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'lstbElementos
        '
        Me.lstbElementos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstbElementos.FormattingEnabled = True
        Me.lstbElementos.Location = New System.Drawing.Point(6, 45)
        Me.lstbElementos.Name = "lstbElementos"
        Me.lstbElementos.Size = New System.Drawing.Size(407, 264)
        Me.lstbElementos.TabIndex = 1
        '
        'Catalogo_TiposEnvases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 375)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_TiposEnvases"
        Me.Text = " Catalogo de tipos de envases"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreTipoTamaño As System.Windows.Forms.Label
    Friend WithEvents TxtNombreTipoEnvase As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblCodigoTipoTamaño As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoTipoEnvase As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents lstbElementos As System.Windows.Forms.ListBox
End Class
