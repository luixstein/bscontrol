<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Acuicola_Global
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Acuicola_Global))
        Me.DtFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbBiometrias = New System.Windows.Forms.RadioButton()
        Me.RbAlimentacion = New System.Windows.Forms.RadioButton()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.LblCiclo = New System.Windows.Forms.Label()
        Me.LblDivision = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CboDivision = New System.Windows.Forms.ComboBox()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(109, 21)
        Me.DtFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(280, 22)
        Me.DtFecha.TabIndex = 0
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(8, 26)
        Me.LblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(55, 17)
        Me.LblFecha.TabIndex = 299
        Me.LblFecha.Text = "Fecha :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbBiometrias)
        Me.GroupBox1.Controls.Add(Me.RbAlimentacion)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(205, 135)
        Me.GroupBox1.TabIndex = 301
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'RbBiometrias
        '
        Me.RbBiometrias.AutoSize = True
        Me.RbBiometrias.Location = New System.Drawing.Point(8, 52)
        Me.RbBiometrias.Margin = New System.Windows.Forms.Padding(4)
        Me.RbBiometrias.Name = "RbBiometrias"
        Me.RbBiometrias.Size = New System.Drawing.Size(95, 21)
        Me.RbBiometrias.TabIndex = 1
        Me.RbBiometrias.Text = "Biometrias"
        Me.RbBiometrias.UseVisualStyleBackColor = True
        '
        'RbAlimentacion
        '
        Me.RbAlimentacion.AutoSize = True
        Me.RbAlimentacion.Checked = True
        Me.RbAlimentacion.Location = New System.Drawing.Point(8, 23)
        Me.RbAlimentacion.Margin = New System.Windows.Forms.Padding(4)
        Me.RbAlimentacion.Name = "RbAlimentacion"
        Me.RbAlimentacion.Size = New System.Drawing.Size(148, 21)
        Me.RbAlimentacion.TabIndex = 0
        Me.RbAlimentacion.TabStop = True
        Me.RbAlimentacion.Text = "Alimentación diaria"
        Me.RbAlimentacion.UseVisualStyleBackColor = True
        '
        'txtCiclo
        '
        Me.txtCiclo.Location = New System.Drawing.Point(109, 63)
        Me.txtCiclo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCiclo.MaxLength = 8
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(95, 22)
        Me.txtCiclo.TabIndex = 3
        '
        'LblCiclo
        '
        Me.LblCiclo.AutoSize = True
        Me.LblCiclo.Location = New System.Drawing.Point(8, 66)
        Me.LblCiclo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCiclo.Name = "LblCiclo"
        Me.LblCiclo.Size = New System.Drawing.Size(46, 17)
        Me.LblCiclo.TabIndex = 304
        Me.LblCiclo.Text = "Ciclo :"
        '
        'LblDivision
        '
        Me.LblDivision.AutoSize = True
        Me.LblDivision.Location = New System.Drawing.Point(8, 114)
        Me.LblDivision.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDivision.Name = "LblDivision"
        Me.LblDivision.Size = New System.Drawing.Size(65, 17)
        Me.LblDivision.TabIndex = 309
        Me.LblDivision.Text = "División :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CboDivision)
        Me.GroupBox2.Controls.Add(Me.LblFecha)
        Me.GroupBox2.Controls.Add(Me.DtFecha)
        Me.GroupBox2.Controls.Add(Me.LblDivision)
        Me.GroupBox2.Controls.Add(Me.LblCiclo)
        Me.GroupBox2.Controls.Add(Me.txtCiclo)
        Me.GroupBox2.Location = New System.Drawing.Point(216, 34)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(448, 268)
        Me.GroupBox2.TabIndex = 311
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'CboDivision
        '
        Me.CboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDivision.FormattingEnabled = True
        Me.CboDivision.Location = New System.Drawing.Point(108, 111)
        Me.CboDivision.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDivision.Name = "CboDivision"
        Me.CboDivision.Size = New System.Drawing.Size(281, 24)
        Me.CboDivision.TabIndex = 311
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(95, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(679, 27)
        Me.ToolStrip1.TabIndex = 312
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Rpt_Acuicola_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 320)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Acuicola_Global"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acuicola - Global de documentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbBiometrias As System.Windows.Forms.RadioButton
    Friend WithEvents RbAlimentacion As System.Windows.Forms.RadioButton
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents LblCiclo As System.Windows.Forms.Label
    Friend WithEvents LblDivision As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CboDivision As System.Windows.Forms.ComboBox
End Class
