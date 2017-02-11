<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Embarques_EmpaqueVsProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Embarques_EmpaqueVsProduccion))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.CboEmpaque = New System.Windows.Forms.ComboBox
        Me.LblEmbarque = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.rdbPorArticulo = New System.Windows.Forms.RadioButton
        Me.rdbCultivo = New System.Windows.Forms.RadioButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(291, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'CboEmpaque
        '
        Me.CboEmpaque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEmpaque.FormattingEnabled = True
        Me.CboEmpaque.Location = New System.Drawing.Point(101, 28)
        Me.CboEmpaque.Name = "CboEmpaque"
        Me.CboEmpaque.Size = New System.Drawing.Size(180, 21)
        Me.CboEmpaque.TabIndex = 340
        '
        'LblEmbarque
        '
        Me.LblEmbarque.AutoSize = True
        Me.LblEmbarque.Location = New System.Drawing.Point(8, 31)
        Me.LblEmbarque.Name = "LblEmbarque"
        Me.LblEmbarque.Size = New System.Drawing.Size(58, 13)
        Me.LblEmbarque.TabIndex = 345
        Me.LblEmbarque.Text = "Empaque :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 344
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(101, 76)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaHasta.TabIndex = 342
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(8, 56)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 343
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(101, 52)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaDesde.TabIndex = 341
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'rdbPorArticulo
        '
        Me.rdbPorArticulo.AutoSize = True
        Me.rdbPorArticulo.Location = New System.Drawing.Point(184, 102)
        Me.rdbPorArticulo.Name = "rdbPorArticulo"
        Me.rdbPorArticulo.Size = New System.Drawing.Size(83, 17)
        Me.rdbPorArticulo.TabIndex = 347
        Me.rdbPorArticulo.Text = "Por árticulos"
        Me.rdbPorArticulo.UseVisualStyleBackColor = True
        '
        'rdbCultivo
        '
        Me.rdbCultivo.AutoSize = True
        Me.rdbCultivo.Checked = True
        Me.rdbCultivo.Location = New System.Drawing.Point(101, 102)
        Me.rdbCultivo.Name = "rdbCultivo"
        Me.rdbCultivo.Size = New System.Drawing.Size(75, 17)
        Me.rdbCultivo.TabIndex = 348
        Me.rdbCultivo.TabStop = True
        Me.rdbCultivo.Text = "Por cultivo"
        Me.rdbCultivo.UseVisualStyleBackColor = True
        '
        'Rpt_Embarques_EmpaqueVsProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 124)
        Me.Controls.Add(Me.rdbCultivo)
        Me.Controls.Add(Me.rdbPorArticulo)
        Me.Controls.Add(Me.CboEmpaque)
        Me.Controls.Add(Me.LblEmbarque)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtFechaHasta)
        Me.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.Controls.Add(Me.DtFechaDesde)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Embarques_EmpaqueVsProduccion"
        Me.Text = "Empaque contra Producción"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CboEmpaque As System.Windows.Forms.ComboBox
    Friend WithEvents LblEmbarque As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdbPorArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCultivo As System.Windows.Forms.RadioButton
End Class
