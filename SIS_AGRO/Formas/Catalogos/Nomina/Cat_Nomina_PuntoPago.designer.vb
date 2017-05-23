<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cat_Nomina_PuntoPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cat_Nomina_PuntoPago))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.lblDisplaySiguiente = New System.Windows.Forms.Label()
        Me.txtCodigoSiguiente = New System.Windows.Forms.TextBox()
        Me.lblDisplayGeneraDenominacion = New System.Windows.Forms.Label()
        Me.cboGeneraDenominacion = New System.Windows.Forms.ComboBox()
        Me.txtHasta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDesde = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayNombrePuntoPago = New System.Windows.Forms.Label()
        Me.TxtNombrePuntoPago = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodPuntoPago = New System.Windows.Forms.Label()
        Me.TxtCodigoPuntoPago = New System.Windows.Forms.TextBox()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMenu.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
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
        Me.tsMenu.Size = New System.Drawing.Size(853, 27)
        Me.tsMenu.TabIndex = 4
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
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplaySiguiente)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoSiguiente)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayGeneraDenominacion)
        Me.gBoxInformacion.Controls.Add(Me.cboGeneraDenominacion)
        Me.gBoxInformacion.Controls.Add(Me.txtHasta)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.txtDesde)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombrePuntoPago)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombrePuntoPago)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodPuntoPago)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoPuntoPago)
        Me.gBoxInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(413, 514)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblDisplaySiguiente
        '
        Me.lblDisplaySiguiente.AutoSize = True
        Me.lblDisplaySiguiente.Location = New System.Drawing.Point(8, 129)
        Me.lblDisplaySiguiente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySiguiente.Name = "lblDisplaySiguiente"
        Me.lblDisplaySiguiente.Size = New System.Drawing.Size(121, 17)
        Me.lblDisplaySiguiente.TabIndex = 99
        Me.lblDisplaySiguiente.Text = "Código siguiente :"
        '
        'txtCodigoSiguiente
        '
        Me.txtCodigoSiguiente.Location = New System.Drawing.Point(175, 124)
        Me.txtCodigoSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoSiguiente.MaxLength = 0
        Me.txtCodigoSiguiente.Name = "txtCodigoSiguiente"
        Me.txtCodigoSiguiente.Size = New System.Drawing.Size(75, 22)
        Me.txtCodigoSiguiente.TabIndex = 4
        '
        'lblDisplayGeneraDenominacion
        '
        Me.lblDisplayGeneraDenominacion.AutoSize = True
        Me.lblDisplayGeneraDenominacion.Location = New System.Drawing.Point(8, 161)
        Me.lblDisplayGeneraDenominacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayGeneraDenominacion.Name = "lblDisplayGeneraDenominacion"
        Me.lblDisplayGeneraDenominacion.Size = New System.Drawing.Size(156, 17)
        Me.lblDisplayGeneraDenominacion.TabIndex = 97
        Me.lblDisplayGeneraDenominacion.Text = "Genera denominación :"
        '
        'cboGeneraDenominacion
        '
        Me.cboGeneraDenominacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGeneraDenominacion.FormattingEnabled = True
        Me.cboGeneraDenominacion.Items.AddRange(New Object() {"SI", "NO"})
        Me.cboGeneraDenominacion.Location = New System.Drawing.Point(175, 156)
        Me.cboGeneraDenominacion.Margin = New System.Windows.Forms.Padding(4)
        Me.cboGeneraDenominacion.MaxLength = 1
        Me.cboGeneraDenominacion.Name = "cboGeneraDenominacion"
        Me.cboGeneraDenominacion.Size = New System.Drawing.Size(75, 24)
        Me.cboGeneraDenominacion.TabIndex = 5
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(300, 90)
        Me.txtHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHasta.MaxLength = 0
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(103, 22)
        Me.txtHasta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 95)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 17)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Rango de códigos :"
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(175, 90)
        Me.txtDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDesde.MaxLength = 0
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(101, 22)
        Me.txtDesde.TabIndex = 2
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
        'LblDisplayNombrePuntoPago
        '
        Me.LblDisplayNombrePuntoPago.AutoSize = True
        Me.LblDisplayNombrePuntoPago.Location = New System.Drawing.Point(8, 65)
        Me.LblDisplayNombrePuntoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombrePuntoPago.Name = "LblDisplayNombrePuntoPago"
        Me.LblDisplayNombrePuntoPago.Size = New System.Drawing.Size(158, 17)
        Me.LblDisplayNombrePuntoPago.TabIndex = 74
        Me.LblDisplayNombrePuntoPago.Text = "Nombre de punto pago:"
        '
        'TxtNombrePuntoPago
        '
        Me.TxtNombrePuntoPago.Location = New System.Drawing.Point(175, 60)
        Me.TxtNombrePuntoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombrePuntoPago.MaxLength = 50
        Me.TxtNombrePuntoPago.Name = "TxtNombrePuntoPago"
        Me.TxtNombrePuntoPago.Size = New System.Drawing.Size(229, 22)
        Me.TxtNombrePuntoPago.TabIndex = 1
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(8, 194)
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
        Me.CboEstatus.Location = New System.Drawing.Point(175, 190)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(101, 24)
        Me.CboEstatus.TabIndex = 6
        '
        'LblDisplayCodPuntoPago
        '
        Me.LblDisplayCodPuntoPago.AutoSize = True
        Me.LblDisplayCodPuntoPago.Location = New System.Drawing.Point(8, 32)
        Me.LblDisplayCodPuntoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodPuntoPago.Name = "LblDisplayCodPuntoPago"
        Me.LblDisplayCodPuntoPago.Size = New System.Drawing.Size(109, 17)
        Me.LblDisplayCodPuntoPago.TabIndex = 8
        Me.LblDisplayCodPuntoPago.Text = "Punto de pago :"
        '
        'TxtCodigoPuntoPago
        '
        Me.TxtCodigoPuntoPago.Location = New System.Drawing.Point(175, 28)
        Me.TxtCodigoPuntoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoPuntoPago.MaxLength = 0
        Me.TxtCodigoPuntoPago.Name = "TxtCodigoPuntoPago"
        Me.TxtCodigoPuntoPago.Size = New System.Drawing.Size(75, 22)
        Me.TxtCodigoPuntoPago.TabIndex = 0
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(441, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(396, 514)
        Me.gBoxBusquedaRapida.TabIndex = 6
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
        Me.Grid.Size = New System.Drawing.Size(379, 453)
        Me.Grid.TabIndex = 113
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(379, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 558)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(853, 25)
        Me.StatusStripEstado.TabIndex = 7
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
        'Cat_Nomina_PuntoPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 583)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Cat_Nomina_PuntoPago"
        Me.ShowIcon = False
        Me.Text = "Catálgo de puntos de pagos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombrePuntoPago As System.Windows.Forms.Label
    Friend WithEvents TxtNombrePuntoPago As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodPuntoPago As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoPuntoPago As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDisplaySiguiente As System.Windows.Forms.Label
    Friend WithEvents txtCodigoSiguiente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayGeneraDenominacion As System.Windows.Forms.Label
    Friend WithEvents cboGeneraDenominacion As System.Windows.Forms.ComboBox
    Friend WithEvents txtHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDesde As System.Windows.Forms.TextBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
