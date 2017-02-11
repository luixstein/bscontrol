<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_ConceptosINEGI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_ConceptosINEGI))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.RdbResumen = New System.Windows.Forms.RadioButton
        Me.RdbDetalle = New System.Windows.Forms.RadioButton
        Me.gbFormatos = New System.Windows.Forms.GroupBox
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbFormatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(406, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
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
        Me.GroupBox1.Controls.Add(Me.LblEjercicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(139, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 97)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(113, 18)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio.TabIndex = 216
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(6, 22)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 202
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Hasta la fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(113, 64)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaHasta.TabIndex = 4
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(6, 45)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 132
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(113, 41)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaDesde.TabIndex = 3
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'RdbResumen
        '
        Me.RdbResumen.AutoSize = True
        Me.RdbResumen.Checked = True
        Me.RdbResumen.Location = New System.Drawing.Point(18, 19)
        Me.RdbResumen.Name = "RdbResumen"
        Me.RdbResumen.Size = New System.Drawing.Size(70, 17)
        Me.RdbResumen.TabIndex = 217
        Me.RdbResumen.TabStop = True
        Me.RdbResumen.Text = "Resumen"
        Me.RdbResumen.UseVisualStyleBackColor = True
        '
        'RdbDetalle
        '
        Me.RdbDetalle.AutoSize = True
        Me.RdbDetalle.Location = New System.Drawing.Point(18, 45)
        Me.RdbDetalle.Name = "RdbDetalle"
        Me.RdbDetalle.Size = New System.Drawing.Size(58, 17)
        Me.RdbDetalle.TabIndex = 218
        Me.RdbDetalle.Text = "Detalle"
        Me.RdbDetalle.UseVisualStyleBackColor = True
        '
        'gbFormatos
        '
        Me.gbFormatos.Controls.Add(Me.RdbDetalle)
        Me.gbFormatos.Controls.Add(Me.RdbResumen)
        Me.gbFormatos.Location = New System.Drawing.Point(7, 28)
        Me.gbFormatos.Name = "gbFormatos"
        Me.gbFormatos.Size = New System.Drawing.Size(126, 97)
        Me.gbFormatos.TabIndex = 219
        Me.gbFormatos.TabStop = False
        Me.gbFormatos.Text = "Formatos"
        '
        'Frm_Contabilidad_ConceptosINEGI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 134)
        Me.Controls.Add(Me.gbFormatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_ConceptosINEGI"
        Me.Text = "Reporte de conceptos para INEGI"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbFormatos.ResumeLayout(False)
        Me.gbFormatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents RdbResumen As System.Windows.Forms.RadioButton
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbFormatos As System.Windows.Forms.GroupBox
End Class
