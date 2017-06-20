<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sis_Documentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sis_Documentos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.TxtNombreFormato = New System.Windows.Forms.TextBox()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.LblTipoDocumento = New System.Windows.Forms.Label()
        Me.LblAsientoRepetitivo = New System.Windows.Forms.Label()
        Me.LblConsecutivo = New System.Windows.Forms.Label()
        Me.LblCodigoPlaza = New System.Windows.Forms.Label()
        Me.LblDisplayNombreFormato = New System.Windows.Forms.Label()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.LblDisplayAsientoRepetitivo = New System.Windows.Forms.Label()
        Me.LblDisplayConsecutivo = New System.Windows.Forms.Label()
        Me.LblDisplayCodigoPlaza = New System.Windows.Forms.Label()
        Me.LblDisplayTipoDocumento = New System.Windows.Forms.Label()
        Me.LblEstatusDocumento = New System.Windows.Forms.Label()
        Me.LblCodigoDocumento = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayEstatus = New System.Windows.Forms.Label()
        Me.LblDisplayCodigo = New System.Windows.Forms.Label()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.CboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.LblEstatusFiltro = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(914, 27)
        Me.tsMenu.TabIndex = 24
        Me.tsMenu.Text = "tsMenu"
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 439)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(914, 25)
        Me.StatusStripEstado.TabIndex = 25
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
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreFormato)
        Me.gBoxInformacion.Controls.Add(Me.TxtFolio)
        Me.gBoxInformacion.Controls.Add(Me.LblTipoDocumento)
        Me.gBoxInformacion.Controls.Add(Me.LblAsientoRepetitivo)
        Me.gBoxInformacion.Controls.Add(Me.LblConsecutivo)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoPlaza)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreFormato)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayFolio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayAsientoRepetitivo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayConsecutivo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodigoPlaza)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayTipoDocumento)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatusDocumento)
        Me.gBoxInformacion.Controls.Add(Me.LblCodigoDocumento)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodigo)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(413, 395)
        Me.gBoxInformacion.TabIndex = 23
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'TxtNombreFormato
        '
        Me.TxtNombreFormato.Location = New System.Drawing.Point(11, 271)
        Me.TxtNombreFormato.MaxLength = 100
        Me.TxtNombreFormato.Name = "TxtNombreFormato"
        Me.TxtNombreFormato.Size = New System.Drawing.Size(381, 22)
        Me.TxtNombreFormato.TabIndex = 105
        '
        'TxtFolio
        '
        Me.TxtFolio.Location = New System.Drawing.Point(7, 217)
        Me.TxtFolio.MaxLength = 16
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(229, 22)
        Me.TxtFolio.TabIndex = 104
        '
        'LblTipoDocumento
        '
        Me.LblTipoDocumento.AutoSize = True
        Me.LblTipoDocumento.Location = New System.Drawing.Point(189, 83)
        Me.LblTipoDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTipoDocumento.Name = "LblTipoDocumento"
        Me.LblTipoDocumento.Size = New System.Drawing.Size(16, 17)
        Me.LblTipoDocumento.TabIndex = 103
        Me.LblTipoDocumento.Text = "_"
        '
        'LblAsientoRepetitivo
        '
        Me.LblAsientoRepetitivo.AutoSize = True
        Me.LblAsientoRepetitivo.Location = New System.Drawing.Point(189, 165)
        Me.LblAsientoRepetitivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAsientoRepetitivo.Name = "LblAsientoRepetitivo"
        Me.LblAsientoRepetitivo.Size = New System.Drawing.Size(16, 17)
        Me.LblAsientoRepetitivo.TabIndex = 102
        Me.LblAsientoRepetitivo.Text = "_"
        '
        'LblConsecutivo
        '
        Me.LblConsecutivo.AutoSize = True
        Me.LblConsecutivo.Location = New System.Drawing.Point(189, 139)
        Me.LblConsecutivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblConsecutivo.Name = "LblConsecutivo"
        Me.LblConsecutivo.Size = New System.Drawing.Size(16, 17)
        Me.LblConsecutivo.TabIndex = 101
        Me.LblConsecutivo.Text = "_"
        '
        'LblCodigoPlaza
        '
        Me.LblCodigoPlaza.AutoSize = True
        Me.LblCodigoPlaza.Location = New System.Drawing.Point(189, 111)
        Me.LblCodigoPlaza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoPlaza.Name = "LblCodigoPlaza"
        Me.LblCodigoPlaza.Size = New System.Drawing.Size(16, 17)
        Me.LblCodigoPlaza.TabIndex = 100
        Me.LblCodigoPlaza.Text = "_"
        '
        'LblDisplayNombreFormato
        '
        Me.LblDisplayNombreFormato.AutoSize = True
        Me.LblDisplayNombreFormato.Location = New System.Drawing.Point(8, 251)
        Me.LblDisplayNombreFormato.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreFormato.Name = "LblDisplayNombreFormato"
        Me.LblDisplayNombreFormato.Size = New System.Drawing.Size(138, 17)
        Me.LblDisplayNombreFormato.TabIndex = 99
        Me.LblDisplayNombreFormato.Text = "Nombre de formato :"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(8, 197)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 98
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'LblDisplayAsientoRepetitivo
        '
        Me.LblDisplayAsientoRepetitivo.AutoSize = True
        Me.LblDisplayAsientoRepetitivo.Location = New System.Drawing.Point(8, 165)
        Me.LblDisplayAsientoRepetitivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayAsientoRepetitivo.Name = "LblDisplayAsientoRepetitivo"
        Me.LblDisplayAsientoRepetitivo.Size = New System.Drawing.Size(172, 17)
        Me.LblDisplayAsientoRepetitivo.TabIndex = 97
        Me.LblDisplayAsientoRepetitivo.Text = "Código asiento repetitivo :"
        '
        'LblDisplayConsecutivo
        '
        Me.LblDisplayConsecutivo.AutoSize = True
        Me.LblDisplayConsecutivo.Location = New System.Drawing.Point(8, 139)
        Me.LblDisplayConsecutivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayConsecutivo.Name = "LblDisplayConsecutivo"
        Me.LblDisplayConsecutivo.Size = New System.Drawing.Size(93, 17)
        Me.LblDisplayConsecutivo.TabIndex = 96
        Me.LblDisplayConsecutivo.Text = "Consecutivo :"
        '
        'LblDisplayCodigoPlaza
        '
        Me.LblDisplayCodigoPlaza.AutoSize = True
        Me.LblDisplayCodigoPlaza.Location = New System.Drawing.Point(8, 111)
        Me.LblDisplayCodigoPlaza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodigoPlaza.Name = "LblDisplayCodigoPlaza"
        Me.LblDisplayCodigoPlaza.Size = New System.Drawing.Size(98, 17)
        Me.LblDisplayCodigoPlaza.TabIndex = 95
        Me.LblDisplayCodigoPlaza.Text = "Código plaza :"
        '
        'LblDisplayTipoDocumento
        '
        Me.LblDisplayTipoDocumento.AutoSize = True
        Me.LblDisplayTipoDocumento.Location = New System.Drawing.Point(8, 83)
        Me.LblDisplayTipoDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTipoDocumento.Name = "LblDisplayTipoDocumento"
        Me.LblDisplayTipoDocumento.Size = New System.Drawing.Size(161, 17)
        Me.LblDisplayTipoDocumento.TabIndex = 94
        Me.LblDisplayTipoDocumento.Text = "Código tipo documento :"
        '
        'LblEstatusDocumento
        '
        Me.LblEstatusDocumento.AutoSize = True
        Me.LblEstatusDocumento.Location = New System.Drawing.Point(189, 52)
        Me.LblEstatusDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatusDocumento.Name = "LblEstatusDocumento"
        Me.LblEstatusDocumento.Size = New System.Drawing.Size(16, 17)
        Me.LblEstatusDocumento.TabIndex = 93
        Me.LblEstatusDocumento.Text = "_"
        '
        'LblCodigoDocumento
        '
        Me.LblCodigoDocumento.AutoSize = True
        Me.LblCodigoDocumento.Location = New System.Drawing.Point(189, 22)
        Me.LblCodigoDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodigoDocumento.Name = "LblCodigoDocumento"
        Me.LblCodigoDocumento.Size = New System.Drawing.Size(16, 17)
        Me.LblCodigoDocumento.TabIndex = 92
        Me.LblCodigoDocumento.Text = "_"
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
        'LblDisplayEstatus
        '
        Me.LblDisplayEstatus.AutoSize = True
        Me.LblDisplayEstatus.Location = New System.Drawing.Point(8, 52)
        Me.LblDisplayEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayEstatus.Name = "LblDisplayEstatus"
        Me.LblDisplayEstatus.Size = New System.Drawing.Size(137, 17)
        Me.LblDisplayEstatus.TabIndex = 22
        Me.LblDisplayEstatus.Text = "Estatus documento :"
        '
        'LblDisplayCodigo
        '
        Me.LblDisplayCodigo.AutoSize = True
        Me.LblDisplayCodigo.Location = New System.Drawing.Point(8, 22)
        Me.LblDisplayCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodigo.Name = "LblDisplayCodigo"
        Me.LblDisplayCodigo.Size = New System.Drawing.Size(134, 17)
        Me.LblDisplayCodigo.TabIndex = 8
        Me.LblDisplayCodigo.Text = "Código documento :"
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.LblEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(439, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(462, 395)
        Me.gBoxBusquedaRapida.TabIndex = 22
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(373, 23)
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(78, 24)
        Me.CboEstatusFiltro.TabIndex = 116
        '
        'LblEstatusFiltro
        '
        Me.LblEstatusFiltro.AutoSize = True
        Me.LblEstatusFiltro.Location = New System.Drawing.Point(304, 26)
        Me.LblEstatusFiltro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatusFiltro.Name = "LblEstatusFiltro"
        Me.LblEstatusFiltro.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatusFiltro.TabIndex = 100
        Me.LblEstatusFiltro.Text = "Estatus :"
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
        Me.Grid.Size = New System.Drawing.Size(446, 334)
        Me.Grid.TabIndex = 115
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(287, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Sis_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 464)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Sis_Documentos"
        Me.ShowIcon = False
        Me.Text = "Catálogo etiquetas"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
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
    Friend WithEvents LblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodigo As System.Windows.Forms.Label
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents LblCodigoDocumento As System.Windows.Forms.Label
    Friend WithEvents LblEstatusDocumento As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreFormato As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents LblDisplayAsientoRepetitivo As System.Windows.Forms.Label
    Friend WithEvents LblDisplayConsecutivo As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodigoPlaza As System.Windows.Forms.Label
    Friend WithEvents LblDisplayTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents LblEstatusFiltro As System.Windows.Forms.Label
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents TxtNombreFormato As System.Windows.Forms.TextBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents LblAsientoRepetitivo As System.Windows.Forms.Label
    Friend WithEvents LblConsecutivo As System.Windows.Forms.Label
    Friend WithEvents LblCodigoPlaza As System.Windows.Forms.Label
End Class
