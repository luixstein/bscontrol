<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcuicolaProyectoSiembra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcuicolaProyectoSiembra))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.GbCierreCiclo = New System.Windows.Forms.GroupBox()
        Me.TxtFolioEntrada = New System.Windows.Forms.TextBox()
        Me.LblFechaCierre = New System.Windows.Forms.Label()
        Me.LblFolioEntrada = New System.Windows.Forms.Label()
        Me.DtFechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.TxtKilosCosechados = New System.Windows.Forms.TextBox()
        Me.LblKilosCosechados = New System.Windows.Forms.Label()
        Me.lblDisplayLote = New System.Windows.Forms.Label()
        Me.cboLote = New System.Windows.Forms.ComboBox()
        Me.txtHA = New System.Windows.Forms.TextBox()
        Me.lblDisplayHa = New System.Windows.Forms.Label()
        Me.lblDisplayEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.lblDisplayCiclo = New System.Windows.Forms.Label()
        Me.lblDisplayDivision = New System.Windows.Forms.Label()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.lblDisplayIDProyectoSiembra = New System.Windows.Forms.Label()
        Me.txtIDProyectoSiembra = New System.Windows.Forms.TextBox()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTemporada = New System.Windows.Forms.Label()
        Me.cboTemporada = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMenu.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.GbCierreCiclo.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(739, 27)
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
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.GbCierreCiclo)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayLote)
        Me.gBoxInformacion.Controls.Add(Me.cboLote)
        Me.gBoxInformacion.Controls.Add(Me.txtHA)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayHa)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.dtFecha)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFecha)
        Me.gBoxInformacion.Controls.Add(Me.txtCiclo)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCiclo)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayDivision)
        Me.gBoxInformacion.Controls.Add(Me.cboDivision)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayIDProyectoSiembra)
        Me.gBoxInformacion.Controls.Add(Me.txtIDProyectoSiembra)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 30)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(718, 133)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        '
        'GbCierreCiclo
        '
        Me.GbCierreCiclo.Controls.Add(Me.TxtFolioEntrada)
        Me.GbCierreCiclo.Controls.Add(Me.LblFechaCierre)
        Me.GbCierreCiclo.Controls.Add(Me.LblFolioEntrada)
        Me.GbCierreCiclo.Controls.Add(Me.DtFechaCierre)
        Me.GbCierreCiclo.Controls.Add(Me.TxtKilosCosechados)
        Me.GbCierreCiclo.Controls.Add(Me.LblKilosCosechados)
        Me.GbCierreCiclo.Location = New System.Drawing.Point(331, 16)
        Me.GbCierreCiclo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GbCierreCiclo.Name = "GbCierreCiclo"
        Me.GbCierreCiclo.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GbCierreCiclo.Size = New System.Drawing.Size(346, 110)
        Me.GbCierreCiclo.TabIndex = 408
        Me.GbCierreCiclo.TabStop = False
        Me.GbCierreCiclo.Text = "Cierre de ciclo"
        '
        'TxtFolioEntrada
        '
        Me.TxtFolioEntrada.Location = New System.Drawing.Point(103, 80)
        Me.TxtFolioEntrada.MaxLength = 15
        Me.TxtFolioEntrada.Name = "TxtFolioEntrada"
        Me.TxtFolioEntrada.Size = New System.Drawing.Size(123, 20)
        Me.TxtFolioEntrada.TabIndex = 407
        '
        'LblFechaCierre
        '
        Me.LblFechaCierre.AutoSize = True
        Me.LblFechaCierre.Location = New System.Drawing.Point(5, 20)
        Me.LblFechaCierre.Name = "LblFechaCierre"
        Me.LblFechaCierre.Size = New System.Drawing.Size(84, 13)
        Me.LblFechaCierre.TabIndex = 403
        Me.LblFechaCierre.Text = "Fecha de cierre:"
        '
        'LblFolioEntrada
        '
        Me.LblFolioEntrada.AutoSize = True
        Me.LblFolioEntrada.Location = New System.Drawing.Point(5, 82)
        Me.LblFolioEntrada.Name = "LblFolioEntrada"
        Me.LblFolioEntrada.Size = New System.Drawing.Size(71, 13)
        Me.LblFolioEntrada.TabIndex = 404
        Me.LblFolioEntrada.Text = "Folio entrada:"
        '
        'DtFechaCierre
        '
        Me.DtFechaCierre.Cursor = System.Windows.Forms.Cursors.Default
        Me.DtFechaCierre.CustomFormat = "dd-MMM-yyyy"
        Me.DtFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaCierre.Location = New System.Drawing.Point(103, 16)
        Me.DtFechaCierre.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaCierre.Name = "DtFechaCierre"
        Me.DtFechaCierre.Size = New System.Drawing.Size(123, 20)
        Me.DtFechaCierre.TabIndex = 402
        '
        'TxtKilosCosechados
        '
        Me.TxtKilosCosechados.Location = New System.Drawing.Point(103, 49)
        Me.TxtKilosCosechados.MaxLength = 15
        Me.TxtKilosCosechados.Name = "TxtKilosCosechados"
        Me.TxtKilosCosechados.Size = New System.Drawing.Size(123, 20)
        Me.TxtKilosCosechados.TabIndex = 405
        '
        'LblKilosCosechados
        '
        Me.LblKilosCosechados.AutoSize = True
        Me.LblKilosCosechados.Location = New System.Drawing.Point(5, 51)
        Me.LblKilosCosechados.Name = "LblKilosCosechados"
        Me.LblKilosCosechados.Size = New System.Drawing.Size(93, 13)
        Me.LblKilosCosechados.TabIndex = 406
        Me.LblKilosCosechados.Text = "Kilos cosechados:"
        '
        'lblDisplayLote
        '
        Me.lblDisplayLote.AutoSize = True
        Me.lblDisplayLote.Location = New System.Drawing.Point(10, 101)
        Me.lblDisplayLote.Name = "lblDisplayLote"
        Me.lblDisplayLote.Size = New System.Drawing.Size(58, 13)
        Me.lblDisplayLote.TabIndex = 401
        Me.lblDisplayLote.Text = "Estanque :"
        '
        'cboLote
        '
        Me.cboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLote.FormattingEnabled = True
        Me.cboLote.Location = New System.Drawing.Point(74, 98)
        Me.cboLote.Name = "cboLote"
        Me.cboLote.Size = New System.Drawing.Size(160, 21)
        Me.cboLote.TabIndex = 4
        '
        'txtHA
        '
        Me.txtHA.Location = New System.Drawing.Point(268, 98)
        Me.txtHA.MaxLength = 15
        Me.txtHA.Name = "txtHA"
        Me.txtHA.Size = New System.Drawing.Size(55, 20)
        Me.txtHA.TabIndex = 5
        '
        'lblDisplayHa
        '
        Me.lblDisplayHa.AutoSize = True
        Me.lblDisplayHa.Location = New System.Drawing.Point(240, 101)
        Me.lblDisplayHa.Name = "lblDisplayHa"
        Me.lblDisplayHa.Size = New System.Drawing.Size(28, 13)
        Me.lblDisplayHa.TabIndex = 399
        Me.lblDisplayHa.Text = "HA :"
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(220, 21)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayEstatus.TabIndex = 395
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "T"})
        Me.CboEstatus.Location = New System.Drawing.Point(268, 18)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(55, 21)
        Me.CboEstatus.TabIndex = 6
        '
        'dtFecha
        '
        Me.dtFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(217, 72)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(106, 20)
        Me.dtFecha.TabIndex = 3
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(170, 75)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 393
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'txtCiclo
        '
        Me.txtCiclo.Location = New System.Drawing.Point(74, 72)
        Me.txtCiclo.MaxLength = 15
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(55, 20)
        Me.txtCiclo.TabIndex = 2
        '
        'lblDisplayCiclo
        '
        Me.lblDisplayCiclo.AutoSize = True
        Me.lblDisplayCiclo.Location = New System.Drawing.Point(10, 75)
        Me.lblDisplayCiclo.Name = "lblDisplayCiclo"
        Me.lblDisplayCiclo.Size = New System.Drawing.Size(36, 13)
        Me.lblDisplayCiclo.TabIndex = 391
        Me.lblDisplayCiclo.Text = "Ciclo :"
        '
        'lblDisplayDivision
        '
        Me.lblDisplayDivision.AutoSize = True
        Me.lblDisplayDivision.Location = New System.Drawing.Point(10, 48)
        Me.lblDisplayDivision.Name = "lblDisplayDivision"
        Me.lblDisplayDivision.Size = New System.Drawing.Size(50, 13)
        Me.lblDisplayDivision.TabIndex = 390
        Me.lblDisplayDivision.Text = "División :"
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(74, 45)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(239, 21)
        Me.cboDivision.TabIndex = 1
        '
        'lblDisplayIDProyectoSiembra
        '
        Me.lblDisplayIDProyectoSiembra.AutoSize = True
        Me.lblDisplayIDProyectoSiembra.Location = New System.Drawing.Point(10, 22)
        Me.lblDisplayIDProyectoSiembra.Name = "lblDisplayIDProyectoSiembra"
        Me.lblDisplayIDProyectoSiembra.Size = New System.Drawing.Size(24, 13)
        Me.lblDisplayIDProyectoSiembra.TabIndex = 10
        Me.lblDisplayIDProyectoSiembra.Text = "ID :"
        '
        'txtIDProyectoSiembra
        '
        Me.txtIDProyectoSiembra.Enabled = False
        Me.txtIDProyectoSiembra.Location = New System.Drawing.Point(74, 19)
        Me.txtIDProyectoSiembra.MaxLength = 4
        Me.txtIDProyectoSiembra.Name = "txtIDProyectoSiembra"
        Me.txtIDProyectoSiembra.Size = New System.Drawing.Size(57, 20)
        Me.txtIDProyectoSiembra.TabIndex = 0
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.lblDisplayTemporada)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboTemporada)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.cboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(12, 168)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(718, 484)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Listado"
        '
        'lblDisplayTemporada
        '
        Me.lblDisplayTemporada.AutoSize = True
        Me.lblDisplayTemporada.Location = New System.Drawing.Point(446, 17)
        Me.lblDisplayTemporada.Name = "lblDisplayTemporada"
        Me.lblDisplayTemporada.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayTemporada.TabIndex = 392
        Me.lblDisplayTemporada.Text = "Temporada :"
        '
        'cboTemporada
        '
        Me.cboTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemporada.FormattingEnabled = True
        Me.cboTemporada.Location = New System.Drawing.Point(519, 15)
        Me.cboTemporada.Name = "cboTemporada"
        Me.cboTemporada.Size = New System.Drawing.Size(67, 21)
        Me.cboTemporada.TabIndex = 391
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(592, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 217
        Me.Label1.Text = "Estatus :"
        '
        'cboEstatusFiltro
        '
        Me.cboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatusFiltro.FormattingEnabled = True
        Me.cboEstatusFiltro.Items.AddRange(New Object() {"A", "T"})
        Me.cboEstatusFiltro.Location = New System.Drawing.Point(647, 15)
        Me.cboEstatusFiltro.MaxLength = 1
        Me.cboEstatusFiltro.Name = "cboEstatusFiltro"
        Me.cboEstatusFiltro.Size = New System.Drawing.Size(55, 21)
        Me.cboEstatusFiltro.TabIndex = 218
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(12, 40)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(690, 436)
        Me.Grid.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 657)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(739, 22)
        Me.StatusStripEstado.TabIndex = 6
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
        'AcuicolaProyectoSiembra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 679)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "AcuicolaProyectoSiembra"
        Me.Text = "Proyecto de siembra Acuícola."
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.GbCierreCiclo.ResumeLayout(False)
        Me.GbCierreCiclo.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbNuevo As ToolStripButton
    Friend WithEvents tsbEditar As ToolStripButton
    Friend WithEvents tsbGrabar As ToolStripButton
    Friend WithEvents tsbCancelar As ToolStripButton
    Friend WithEvents tsbImprimirListado As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents gBoxInformacion As GroupBox
    Friend WithEvents gBoxBusquedaRapida As GroupBox
    Friend WithEvents Grid As DataGridView
    Friend WithEvents lblDisplayIDProyectoSiembra As Label
    Friend WithEvents txtIDProyectoSiembra As TextBox
    Friend WithEvents txtCiclo As TextBox
    Friend WithEvents lblDisplayCiclo As Label
    Friend WithEvents lblDisplayDivision As Label
    Friend WithEvents cboDivision As ComboBox
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents lblDisplayFecha As Label
    Friend WithEvents lblDisplayEstatus As Label
    Friend WithEvents CboEstatus As ComboBox
    Friend WithEvents lblDisplayLote As Label
    Friend WithEvents cboLote As ComboBox
    Friend WithEvents txtHA As TextBox
    Friend WithEvents lblDisplayHa As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboEstatusFiltro As ComboBox
    Friend WithEvents StatusStripEstado As StatusStrip
    Friend WithEvents tssLabel As ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As ToolStripStatusLabel
    Friend WithEvents lblDisplayTemporada As Label
    Friend WithEvents cboTemporada As ComboBox
    Friend WithEvents GbCierreCiclo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFolioEntrada As System.Windows.Forms.TextBox
    Friend WithEvents LblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents LblFolioEntrada As System.Windows.Forms.Label
    Friend WithEvents DtFechaCierre As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtKilosCosechados As System.Windows.Forms.TextBox
    Friend WithEvents LblKilosCosechados As System.Windows.Forms.Label
End Class
