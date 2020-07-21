<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionEmpresa))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblDisplayPorcentajeUtilidad = New System.Windows.Forms.Label()
        Me.TxtPorcentajeUtilidadMinima = New System.Windows.Forms.TextBox()
        Me.lblDisplayContraseñaPeriodos = New System.Windows.Forms.Label()
        Me.txtContraseñaPeriodos = New System.Windows.Forms.TextBox()
        Me.lblDisplayContraseñaPrecios = New System.Windows.Forms.Label()
        Me.txtContraseñaPrecios = New System.Windows.Forms.TextBox()
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(800, 27)
        Me.tsMenu.TabIndex = 1
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(78, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblDisplayPorcentajeUtilidad)
        Me.GroupBox1.Controls.Add(Me.TxtPorcentajeUtilidadMinima)
        Me.GroupBox1.Controls.Add(Me.lblDisplayContraseñaPeriodos)
        Me.GroupBox1.Controls.Add(Me.txtContraseñaPeriodos)
        Me.GroupBox1.Controls.Add(Me.lblDisplayContraseñaPrecios)
        Me.GroupBox1.Controls.Add(Me.txtContraseñaPrecios)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 37)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(773, 380)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LblDisplayPorcentajeUtilidad
        '
        Me.LblDisplayPorcentajeUtilidad.AutoSize = True
        Me.LblDisplayPorcentajeUtilidad.Location = New System.Drawing.Point(21, 101)
        Me.LblDisplayPorcentajeUtilidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayPorcentajeUtilidad.Name = "LblDisplayPorcentajeUtilidad"
        Me.LblDisplayPorcentajeUtilidad.Size = New System.Drawing.Size(267, 17)
        Me.LblDisplayPorcentajeUtilidad.TabIndex = 107
        Me.LblDisplayPorcentajeUtilidad.Text = "Porcentaje de utilidad minima en ventas :"
        '
        'TxtPorcentajeUtilidadMinima
        '
        Me.TxtPorcentajeUtilidadMinima.Location = New System.Drawing.Point(296, 98)
        Me.TxtPorcentajeUtilidadMinima.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPorcentajeUtilidadMinima.MaxLength = 10
        Me.TxtPorcentajeUtilidadMinima.Name = "TxtPorcentajeUtilidadMinima"
        Me.TxtPorcentajeUtilidadMinima.Size = New System.Drawing.Size(115, 22)
        Me.TxtPorcentajeUtilidadMinima.TabIndex = 2
        '
        'lblDisplayContraseñaPeriodos
        '
        Me.lblDisplayContraseñaPeriodos.AutoSize = True
        Me.lblDisplayContraseñaPeriodos.Location = New System.Drawing.Point(21, 59)
        Me.lblDisplayContraseñaPeriodos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayContraseñaPeriodos.Name = "lblDisplayContraseñaPeriodos"
        Me.lblDisplayContraseñaPeriodos.Size = New System.Drawing.Size(141, 17)
        Me.lblDisplayContraseñaPeriodos.TabIndex = 105
        Me.lblDisplayContraseñaPeriodos.Text = "Contraseña periodo :"
        '
        'txtContraseñaPeriodos
        '
        Me.txtContraseñaPeriodos.Location = New System.Drawing.Point(180, 55)
        Me.txtContraseñaPeriodos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContraseñaPeriodos.MaxLength = 10
        Me.txtContraseñaPeriodos.Name = "txtContraseñaPeriodos"
        Me.txtContraseñaPeriodos.Size = New System.Drawing.Size(115, 22)
        Me.txtContraseñaPeriodos.TabIndex = 1
        '
        'lblDisplayContraseñaPrecios
        '
        Me.lblDisplayContraseñaPrecios.AutoSize = True
        Me.lblDisplayContraseñaPrecios.Location = New System.Drawing.Point(21, 28)
        Me.lblDisplayContraseñaPrecios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayContraseñaPrecios.Name = "lblDisplayContraseñaPrecios"
        Me.lblDisplayContraseñaPrecios.Size = New System.Drawing.Size(139, 17)
        Me.lblDisplayContraseñaPrecios.TabIndex = 103
        Me.lblDisplayContraseñaPrecios.Text = "Contraseña precios :"
        '
        'txtContraseñaPrecios
        '
        Me.txtContraseñaPrecios.Location = New System.Drawing.Point(180, 23)
        Me.txtContraseñaPrecios.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContraseñaPrecios.MaxLength = 30
        Me.txtContraseñaPrecios.Name = "txtContraseñaPrecios"
        Me.txtContraseñaPrecios.Size = New System.Drawing.Size(115, 22)
        Me.txtContraseñaPrecios.TabIndex = 0
        '
        'ConfiguracionEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 432)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "ConfiguracionEmpresa"
        Me.Text = "Configuración de la empresa"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbGrabar As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblDisplayContraseñaPrecios As Label
    Friend WithEvents txtContraseñaPrecios As TextBox
    Friend WithEvents lblDisplayContraseñaPeriodos As Label
    Friend WithEvents txtContraseñaPeriodos As TextBox
    Friend WithEvents LblDisplayPorcentajeUtilidad As System.Windows.Forms.Label
    Friend WithEvents TxtPorcentajeUtilidadMinima As System.Windows.Forms.TextBox
End Class
