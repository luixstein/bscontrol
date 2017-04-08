<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cat_Nomina_CentroCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cat_Nomina_CentroCosto))
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.CboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.LblContabilizarporactividad = New System.Windows.Forms.Label()
        Me.LblCultivo = New System.Windows.Forms.Label()
        Me.chkContabilizarporactividad = New System.Windows.Forms.CheckBox()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.lblDisplayCuentaContable = New System.Windows.Forms.Label()
        Me.txtCuentaContable = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayNombreUnidadMedica = New System.Windows.Forms.Label()
        Me.TxtNombreCentroCosto = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodUnidadMedica = New System.Windows.Forms.Label()
        Me.TxtCodigoCentroCosto = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxInformacion.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label1)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(559, 33)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(603, 527)
        Me.gBoxBusquedaRapida.TabIndex = 18
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(537, 23)
        Me.CboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatusFiltro.MaxLength = 1
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(58, 24)
        Me.CboEstatusFiltro.TabIndex = 99
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(466, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Estatus :"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 54)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(587, 466)
        Me.Grid.TabIndex = 113
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 25)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.MaxLength = 80
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(450, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.LblContabilizarporactividad)
        Me.gBoxInformacion.Controls.Add(Me.LblCultivo)
        Me.gBoxInformacion.Controls.Add(Me.chkContabilizarporactividad)
        Me.gBoxInformacion.Controls.Add(Me.cboCultivo)
        Me.gBoxInformacion.Controls.Add(Me.lblCuenta)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreUnidadMedica)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreCentroCosto)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodUnidadMedica)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoCentroCosto)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 33)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(535, 527)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'LblContabilizarporactividad
        '
        Me.LblContabilizarporactividad.AutoSize = True
        Me.LblContabilizarporactividad.Location = New System.Drawing.Point(8, 271)
        Me.LblContabilizarporactividad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblContabilizarporactividad.Name = "LblContabilizarporactividad"
        Me.LblContabilizarporactividad.Size = New System.Drawing.Size(175, 17)
        Me.LblContabilizarporactividad.TabIndex = 98
        Me.LblContabilizarporactividad.Text = "Contabilizar por actividad :"
        Me.LblContabilizarporactividad.Visible = False
        '
        'LblCultivo
        '
        Me.LblCultivo.AutoSize = True
        Me.LblCultivo.Location = New System.Drawing.Point(8, 206)
        Me.LblCultivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCultivo.Name = "LblCultivo"
        Me.LblCultivo.Size = New System.Drawing.Size(58, 17)
        Me.LblCultivo.TabIndex = 97
        Me.LblCultivo.Text = "Cultivo :"
        Me.LblCultivo.Visible = False
        '
        'chkContabilizarporactividad
        '
        Me.chkContabilizarporactividad.AutoSize = True
        Me.chkContabilizarporactividad.Location = New System.Drawing.Point(232, 271)
        Me.chkContabilizarporactividad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkContabilizarporactividad.Name = "chkContabilizarporactividad"
        Me.chkContabilizarporactividad.Size = New System.Drawing.Size(18, 17)
        Me.chkContabilizarporactividad.TabIndex = 5
        Me.chkContabilizarporactividad.UseVisualStyleBackColor = True
        Me.chkContabilizarporactividad.Visible = False
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Location = New System.Drawing.Point(11, 226)
        Me.cboCultivo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(496, 24)
        Me.cboCultivo.TabIndex = 4
        Me.cboCultivo.Visible = False
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(171, 116)
        Me.lblCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(16, 17)
        Me.lblCuenta.TabIndex = 94
        Me.lblCuenta.Text = "_"
        '
        'lblDisplayCuentaContable
        '
        Me.lblDisplayCuentaContable.AutoSize = True
        Me.lblDisplayCuentaContable.Location = New System.Drawing.Point(8, 87)
        Me.lblDisplayCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaContable.Name = "lblDisplayCuentaContable"
        Me.lblDisplayCuentaContable.Size = New System.Drawing.Size(119, 17)
        Me.lblDisplayCuentaContable.TabIndex = 93
        Me.lblDisplayCuentaContable.Text = "Cuenta contable :"
        Me.lblDisplayCuentaContable.Visible = False
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Location = New System.Drawing.Point(137, 82)
        Me.txtCuentaContable.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaContable.MaxLength = 20
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.Size = New System.Drawing.Size(381, 22)
        Me.txtCuentaContable.TabIndex = 2
        Me.txtCuentaContable.Visible = False
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
        'LblDisplayNombreUnidadMedica
        '
        Me.LblDisplayNombreUnidadMedica.AutoSize = True
        Me.LblDisplayNombreUnidadMedica.Location = New System.Drawing.Point(8, 54)
        Me.LblDisplayNombreUnidadMedica.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombreUnidadMedica.Name = "LblDisplayNombreUnidadMedica"
        Me.LblDisplayNombreUnidadMedica.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombreUnidadMedica.TabIndex = 74
        Me.LblDisplayNombreUnidadMedica.Text = "Nombre :"
        '
        'TxtNombreCentroCosto
        '
        Me.TxtNombreCentroCosto.Location = New System.Drawing.Point(137, 49)
        Me.TxtNombreCentroCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreCentroCosto.MaxLength = 80
        Me.TxtNombreCentroCosto.Name = "TxtNombreCentroCosto"
        Me.TxtNombreCentroCosto.Size = New System.Drawing.Size(381, 22)
        Me.TxtNombreCentroCosto.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(8, 145)
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
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(175, 140)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(90, 24)
        Me.CboEstatus.TabIndex = 3
        '
        'LblDisplayCodUnidadMedica
        '
        Me.LblDisplayCodUnidadMedica.AutoSize = True
        Me.LblDisplayCodUnidadMedica.Location = New System.Drawing.Point(8, 21)
        Me.LblDisplayCodUnidadMedica.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodUnidadMedica.Name = "LblDisplayCodUnidadMedica"
        Me.LblDisplayCodUnidadMedica.Size = New System.Drawing.Size(60, 17)
        Me.LblDisplayCodUnidadMedica.TabIndex = 8
        Me.LblDisplayCodUnidadMedica.Text = "Código :"
        '
        'TxtCodigoCentroCosto
        '
        Me.TxtCodigoCentroCosto.Location = New System.Drawing.Point(137, 17)
        Me.TxtCodigoCentroCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoCentroCosto.MaxLength = 0
        Me.TxtCodigoCentroCosto.Name = "TxtCodigoCentroCosto"
        Me.TxtCodigoCentroCosto.Size = New System.Drawing.Size(91, 22)
        Me.TxtCodigoCentroCosto.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 566)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1195, 25)
        Me.StatusStripEstado.TabIndex = 16
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
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1195, 27)
        Me.tsMenu.TabIndex = 0
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
        'Cat_Nomina_CentroCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 591)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Cat_Nomina_CentroCosto"
        Me.Text = "Catálogo de centros de  costos"
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreUnidadMedica As System.Windows.Forms.Label
    Friend WithEvents TxtNombreCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodUnidadMedica As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDisplayCuentaContable As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents LblCultivo As System.Windows.Forms.Label
    Friend WithEvents chkContabilizarporactividad As System.Windows.Forms.CheckBox
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents LblContabilizarporactividad As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
