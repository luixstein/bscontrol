<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cat_Nomina_ConceptosActividades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cat_Nomina_ConceptosActividades))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.btnEditarSubActividad = New System.Windows.Forms.Button()
        Me.lstbSubActividades = New System.Windows.Forms.ListBox()
        Me.btnAgregaSubActividad = New System.Windows.Forms.Button()
        Me.LblDisplayConceptoActividad = New System.Windows.Forms.Label()
        Me.TxtConceptoActividad = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodConcepto = New System.Windows.Forms.Label()
        Me.TxtCodigoActividad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.tsMenu.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1079, 27)
        Me.tsMenu.TabIndex = 16
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
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(500, 23)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(531, 572)
        Me.gBoxBusquedaRapida.TabIndex = 20
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
        Me.txtFiltro.Size = New System.Drawing.Size(505, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 668)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1079, 25)
        Me.StatusStripEstado.TabIndex = 19
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
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.btnEditarSubActividad)
        Me.gBoxInformacion.Controls.Add(Me.lstbSubActividades)
        Me.gBoxInformacion.Controls.Add(Me.btnAgregaSubActividad)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayConceptoActividad)
        Me.gBoxInformacion.Controls.Add(Me.TxtConceptoActividad)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodConcepto)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoActividad)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Location = New System.Drawing.Point(8, 23)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(484, 572)
        Me.gBoxInformacion.TabIndex = 18
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Actividad"
        '
        'btnEditarSubActividad
        '
        Me.btnEditarSubActividad.Location = New System.Drawing.Point(12, 133)
        Me.btnEditarSubActividad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEditarSubActividad.Name = "btnEditarSubActividad"
        Me.btnEditarSubActividad.Size = New System.Drawing.Size(211, 28)
        Me.btnEditarSubActividad.TabIndex = 119
        Me.btnEditarSubActividad.Text = "Editar SubActividad"
        Me.btnEditarSubActividad.UseVisualStyleBackColor = True
        '
        'lstbSubActividades
        '
        Me.lstbSubActividades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstbSubActividades.FormattingEnabled = True
        Me.lstbSubActividades.ItemHeight = 16
        Me.lstbSubActividades.Location = New System.Drawing.Point(12, 170)
        Me.lstbSubActividades.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstbSubActividades.Name = "lstbSubActividades"
        Me.lstbSubActividades.Size = New System.Drawing.Size(459, 388)
        Me.lstbSubActividades.TabIndex = 118
        '
        'btnAgregaSubActividad
        '
        Me.btnAgregaSubActividad.Location = New System.Drawing.Point(261, 133)
        Me.btnAgregaSubActividad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregaSubActividad.Name = "btnAgregaSubActividad"
        Me.btnAgregaSubActividad.Size = New System.Drawing.Size(211, 28)
        Me.btnAgregaSubActividad.TabIndex = 117
        Me.btnAgregaSubActividad.Text = "Agregar SubActividad"
        Me.btnAgregaSubActividad.UseVisualStyleBackColor = True
        '
        'LblDisplayConceptoActividad
        '
        Me.LblDisplayConceptoActividad.AutoSize = True
        Me.LblDisplayConceptoActividad.Location = New System.Drawing.Point(16, 60)
        Me.LblDisplayConceptoActividad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayConceptoActividad.Name = "LblDisplayConceptoActividad"
        Me.LblDisplayConceptoActividad.Size = New System.Drawing.Size(156, 17)
        Me.LblDisplayConceptoActividad.TabIndex = 116
        Me.LblDisplayConceptoActividad.Text = "Concepto de actividad :"
        '
        'TxtConceptoActividad
        '
        Me.TxtConceptoActividad.Location = New System.Drawing.Point(183, 57)
        Me.TxtConceptoActividad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtConceptoActividad.MaxLength = 50
        Me.TxtConceptoActividad.Name = "TxtConceptoActividad"
        Me.TxtConceptoActividad.Size = New System.Drawing.Size(275, 22)
        Me.TxtConceptoActividad.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(16, 94)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 115
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(183, 90)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(75, 24)
        Me.CboEstatus.TabIndex = 2
        '
        'LblDisplayCodConcepto
        '
        Me.LblDisplayCodConcepto.AutoSize = True
        Me.LblDisplayCodConcepto.Location = New System.Drawing.Point(16, 27)
        Me.LblDisplayCodConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodConcepto.Name = "LblDisplayCodConcepto"
        Me.LblDisplayCodConcepto.Size = New System.Drawing.Size(107, 17)
        Me.LblDisplayCodConcepto.TabIndex = 113
        Me.LblDisplayCodConcepto.Text = "Cód. concepto :"
        '
        'TxtCodigoActividad
        '
        Me.TxtCodigoActividad.Location = New System.Drawing.Point(183, 23)
        Me.TxtCodigoActividad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodigoActividad.MaxLength = 3
        Me.TxtCodigoActividad.Name = "TxtCodigoActividad"
        Me.TxtCodigoActividad.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoActividad.TabIndex = 0
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gBoxBusquedaRapida)
        Me.GroupBox3.Controls.Add(Me.gBoxInformacion)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 47)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(1047, 615)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Actividades"
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
        Me.Grid.Size = New System.Drawing.Size(505, 505)
        Me.Grid.TabIndex = 113
        '
        'Cat_Nomina_ConceptosActividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 693)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Cat_Nomina_ConceptosActividades"
        Me.Text = "Conceptos de actividades"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
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
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayConceptoActividad As System.Windows.Forms.Label
    Friend WithEvents TxtConceptoActividad As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodConcepto As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoActividad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregaSubActividad As System.Windows.Forms.Button
    Friend WithEvents lstbSubActividades As System.Windows.Forms.ListBox
    Friend WithEvents btnEditarSubActividad As System.Windows.Forms.Button
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
