<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Embarques_Empaque_Y_Embarque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Embarques_Empaque_Y_Embarque))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboProductor = New System.Windows.Forms.ComboBox
        Me.lblDisplayProductor = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdbCompleto = New System.Windows.Forms.RadioButton
        Me.rdbSoloTotales = New System.Windows.Forms.RadioButton
        Me.cboCultivo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblArticulo = New System.Windows.Forms.Label
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label
        Me.TxtCodArticulo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.CboEmpaque = New System.Windows.Forms.ComboBox
        Me.LblEmbarque = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboEmpaque)
        Me.GroupBox1.Controls.Add(Me.LblEmbarque)
        Me.GroupBox1.Controls.Add(Me.CboProductor)
        Me.GroupBox1.Controls.Add(Me.lblDisplayProductor)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cboCultivo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblArticulo)
        Me.GroupBox1.Controls.Add(Me.LblDisplayCodArticulo)
        Me.GroupBox1.Controls.Add(Me.TxtCodArticulo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(530, 183)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'CboProductor
        '
        Me.CboProductor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProductor.FormattingEnabled = True
        Me.CboProductor.Location = New System.Drawing.Point(84, 144)
        Me.CboProductor.Name = "CboProductor"
        Me.CboProductor.Size = New System.Drawing.Size(269, 21)
        Me.CboProductor.TabIndex = 5
        '
        'lblDisplayProductor
        '
        Me.lblDisplayProductor.AutoSize = True
        Me.lblDisplayProductor.Location = New System.Drawing.Point(8, 147)
        Me.lblDisplayProductor.Name = "lblDisplayProductor"
        Me.lblDisplayProductor.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayProductor.TabIndex = 351
        Me.lblDisplayProductor.Text = "Productor :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbCompleto)
        Me.GroupBox2.Controls.Add(Me.rdbSoloTotales)
        Me.GroupBox2.Location = New System.Drawing.Point(360, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(164, 45)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo"
        '
        'rdbCompleto
        '
        Me.rdbCompleto.AutoSize = True
        Me.rdbCompleto.Checked = True
        Me.rdbCompleto.Location = New System.Drawing.Point(6, 19)
        Me.rdbCompleto.Name = "rdbCompleto"
        Me.rdbCompleto.Size = New System.Drawing.Size(69, 17)
        Me.rdbCompleto.TabIndex = 0
        Me.rdbCompleto.TabStop = True
        Me.rdbCompleto.Text = "Completo"
        Me.rdbCompleto.UseVisualStyleBackColor = True
        '
        'rdbSoloTotales
        '
        Me.rdbSoloTotales.AutoSize = True
        Me.rdbSoloTotales.Location = New System.Drawing.Point(81, 19)
        Me.rdbSoloTotales.Name = "rdbSoloTotales"
        Me.rdbSoloTotales.Size = New System.Drawing.Size(80, 17)
        Me.rdbSoloTotales.TabIndex = 1
        Me.rdbSoloTotales.Text = "Solo totales"
        Me.rdbSoloTotales.UseVisualStyleBackColor = True
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboCultivo.Location = New System.Drawing.Point(84, 64)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(270, 21)
        Me.cboCultivo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 278
        Me.Label2.Text = "Cultivo :"
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(82, 48)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(424, 13)
        Me.lblArticulo.TabIndex = 276
        Me.lblArticulo.Text = "_"
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(8, 28)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(56, 13)
        Me.LblDisplayCodArticulo.TabIndex = 275
        Me.LblDisplayCodArticulo.Text = "Producto :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Location = New System.Drawing.Point(84, 25)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(72, 20)
        Me.TxtCodArticulo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(178, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(269, 118)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaHasta.TabIndex = 4
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(8, 120)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 211
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(84, 118)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaDesde.TabIndex = 3
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(532, 25)
        Me.ToolStrip1.TabIndex = 1
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
        Me.CboEmpaque.Location = New System.Drawing.Point(85, 91)
        Me.CboEmpaque.Name = "CboEmpaque"
        Me.CboEmpaque.Size = New System.Drawing.Size(180, 21)
        Me.CboEmpaque.TabIndex = 2
        '
        'LblEmbarque
        '
        Me.LblEmbarque.AutoSize = True
        Me.LblEmbarque.Location = New System.Drawing.Point(8, 94)
        Me.LblEmbarque.Name = "LblEmbarque"
        Me.LblEmbarque.Size = New System.Drawing.Size(58, 13)
        Me.LblEmbarque.TabIndex = 353
        Me.LblEmbarque.Text = "Empaque :"
        '
        'Rpt_Embarques_Empaque_Y_Embarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 223)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Embarques_Empaque_Y_Embarque"
        Me.Text = "Empaque y embarque"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSoloTotales As System.Windows.Forms.RadioButton
    Friend WithEvents CboProductor As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayProductor As System.Windows.Forms.Label
    Friend WithEvents CboEmpaque As System.Windows.Forms.ComboBox
    Friend WithEvents LblEmbarque As System.Windows.Forms.Label
End Class
