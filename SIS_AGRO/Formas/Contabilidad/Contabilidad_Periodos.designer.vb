<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Periodos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Periodos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbEjecutar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.Rdb2 = New System.Windows.Forms.RadioButton
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.Rdb1 = New System.Windows.Forms.RadioButton
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbEjecutar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(330, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbEjecutar
        '
        Me.tsbEjecutar.Image = CType(resources.GetObject("tsbEjecutar.Image"), System.Drawing.Image)
        Me.tsbEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEjecutar.Name = "tsbEjecutar"
        Me.tsbEjecutar.Size = New System.Drawing.Size(62, 22)
        Me.tsbEjecutar.Text = "&Grabar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.Rdb2)
        Me.GroupBox1.Controls.Add(Me.LblEjercicio)
        Me.GroupBox1.Controls.Add(Me.Rdb1)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 173)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione el periodo de trabajo :"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(100, 25)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(200, 21)
        Me.CmbEjercicio.TabIndex = 0
        '
        'Rdb2
        '
        Me.Rdb2.AutoSize = True
        Me.Rdb2.Location = New System.Drawing.Point(100, 152)
        Me.Rdb2.Name = "Rdb2"
        Me.Rdb2.Size = New System.Drawing.Size(85, 17)
        Me.Rdb2.TabIndex = 4
        Me.Rdb2.Text = "Permanente."
        Me.Rdb2.UseVisualStyleBackColor = True
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(9, 28)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 246
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'Rdb1
        '
        Me.Rdb1.AutoSize = True
        Me.Rdb1.Checked = True
        Me.Rdb1.Location = New System.Drawing.Point(100, 129)
        Me.Rdb1.Name = "Rdb1"
        Me.Rdb1.Size = New System.Drawing.Size(79, 17)
        Me.Rdb1.TabIndex = 3
        Me.Rdb1.TabStop = True
        Me.Rdb1.Text = "A la sesión."
        Me.Rdb1.UseVisualStyleBackColor = True
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(100, 50)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(200, 20)
        Me.DtFechaDesde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "El cambio se hará:"
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(9, 50)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 247
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "Hasta la fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(100, 74)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(200, 20)
        Me.DtFechaHasta.TabIndex = 2
        '
        'Contabilidad_Periodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 207)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_Periodos"
        Me.Text = "Periodos de trabajo contable"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbEjecutar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Rdb2 As System.Windows.Forms.RadioButton
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents Rdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
End Class
