<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Catalogo_Folios_Documentos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Folios_Documentos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.cMenuStripAccion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tStripMenuItemEditar = New System.Windows.Forms.ToolStripMenuItem
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox
        Me.TxtFolioNuevo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblPlaza = New System.Windows.Forms.Label
        Me.cboCentros = New System.Windows.Forms.ComboBox
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.LblDisplayFolio = New System.Windows.Forms.Label
        Me.CmbDocumento = New System.Windows.Forms.ComboBox
        Me.LblDocumento = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.cMenuStripAccion.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(368, 25)
        Me.tsMenu.TabIndex = 3
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
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
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(48, 17)
        Me.tssLabel.Text = "Estado :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 165)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(368, 22)
        Me.StatusStripEstado.TabIndex = 5
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 17)
        '
        'cMenuStripAccion
        '
        Me.cMenuStripAccion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tStripMenuItemEditar})
        Me.cMenuStripAccion.Name = "ContextMenuStrip1"
        Me.cMenuStripAccion.Size = New System.Drawing.Size(105, 26)
        '
        'tStripMenuItemEditar
        '
        Me.tStripMenuItemEditar.Image = CType(resources.GetObject("tStripMenuItemEditar.Image"), System.Drawing.Image)
        Me.tStripMenuItemEditar.Name = "tStripMenuItemEditar"
        Me.tStripMenuItemEditar.Size = New System.Drawing.Size(104, 22)
        Me.tStripMenuItemEditar.Text = "&Editar"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.TxtFolioNuevo)
        Me.gBoxInformacion.Controls.Add(Me.Label1)
        Me.gBoxInformacion.Controls.Add(Me.LblPlaza)
        Me.gBoxInformacion.Controls.Add(Me.cboCentros)
        Me.gBoxInformacion.Controls.Add(Me.TxtFolio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayFolio)
        Me.gBoxInformacion.Controls.Add(Me.CmbDocumento)
        Me.gBoxInformacion.Controls.Add(Me.LblDocumento)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(345, 134)
        Me.gBoxInformacion.TabIndex = 2
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'TxtFolioNuevo
        '
        Me.TxtFolioNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolioNuevo.Location = New System.Drawing.Point(89, 93)
        Me.TxtFolioNuevo.MaxLength = 160
        Me.TxtFolioNuevo.Name = "TxtFolioNuevo"
        Me.TxtFolioNuevo.Size = New System.Drawing.Size(121, 20)
        Me.TxtFolioNuevo.TabIndex = 286
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 287
        Me.Label1.Text = "Folio :"
        '
        'LblPlaza
        '
        Me.LblPlaza.AutoSize = True
        Me.LblPlaza.Location = New System.Drawing.Point(4, 24)
        Me.LblPlaza.Name = "LblPlaza"
        Me.LblPlaza.Size = New System.Drawing.Size(39, 13)
        Me.LblPlaza.TabIndex = 285
        Me.LblPlaza.Text = "Plaza :"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(89, 16)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(250, 21)
        Me.cboCentros.TabIndex = 280
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(89, 67)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.ReadOnly = True
        Me.TxtFolio.Size = New System.Drawing.Size(121, 20)
        Me.TxtFolio.TabIndex = 282
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(6, 74)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(64, 13)
        Me.LblDisplayFolio.TabIndex = 284
        Me.LblDisplayFolio.Text = "Folio actual:"
        '
        'CmbDocumento
        '
        Me.CmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDocumento.FormattingEnabled = True
        Me.CmbDocumento.Location = New System.Drawing.Point(89, 40)
        Me.CmbDocumento.Name = "CmbDocumento"
        Me.CmbDocumento.Size = New System.Drawing.Size(250, 21)
        Me.CmbDocumento.TabIndex = 281
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(4, 48)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 283
        Me.LblDocumento.Text = "Documento :"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'Catalogo_Folios_Documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 187)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Folios_Documentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catalogo de folios de documentos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.cMenuStripAccion.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cMenuStripAccion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tStripMenuItemEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblPlaza As System.Windows.Forms.Label
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents CmbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents TxtFolioNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
