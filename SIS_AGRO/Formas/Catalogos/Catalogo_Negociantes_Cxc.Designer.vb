<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Negociantes_Cxc
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Negociantes_Cxc))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPuesto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblDisplayNombreCultivo = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(409, 25)
        Me.tsMenu.TabIndex = 28
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 184)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(409, 22)
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
        Me.gBoxInformacion.Controls.Add(Me.Label6)
        Me.gBoxInformacion.Controls.Add(Me.txtEmail)
        Me.gBoxInformacion.Controls.Add(Me.Label5)
        Me.gBoxInformacion.Controls.Add(Me.txtCelular)
        Me.gBoxInformacion.Controls.Add(Me.Label4)
        Me.gBoxInformacion.Controls.Add(Me.txtTelefono)
        Me.gBoxInformacion.Controls.Add(Me.Label3)
        Me.gBoxInformacion.Controls.Add(Me.txtPuesto)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombre)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(389, 149)
        Me.gBoxInformacion.TabIndex = 27
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Email :"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(75, 123)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(307, 20)
        Me.txtEmail.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Celular :"
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(76, 97)
        Me.txtCelular.MaxLength = 50
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(307, 20)
        Me.txtCelular.TabIndex = 98
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Telefono :"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(75, 71)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(307, 20)
        Me.txtTelefono.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Puesto :"
        '
        'txtPuesto
        '
        Me.txtPuesto.Location = New System.Drawing.Point(76, 45)
        Me.txtPuesto.MaxLength = 50
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(307, 20)
        Me.txtPuesto.TabIndex = 94
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'LblDisplayNombreCultivo
        '
        Me.LblDisplayNombreCultivo.AutoSize = True
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(5, 22)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(76, 19)
        Me.TxtNombre.MaxLength = 50
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(307, 20)
        Me.TxtNombre.TabIndex = 3
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Catalogo_Negociantes_Cxc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 206)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Name = "Catalogo_Negociantes_Cxc"
        Me.Text = "Catalogo negociantes cxc"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As System.Windows.Forms.TextBox
End Class
