<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Embarques_VentasEstimadaArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Embarques_VentasEstimadaArticulo))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboZona = New System.Windows.Forms.ComboBox
        Me.lblDisplayZona = New System.Windows.Forms.Label
        Me.lblDisplaySemana2 = New System.Windows.Forms.Label
        Me.lblDisplaySemana1 = New System.Windows.Forms.Label
        Me.CboSemana2 = New System.Windows.Forms.ComboBox
        Me.CboSemana1 = New System.Windows.Forms.ComboBox
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.lblDisplayCliente = New System.Windows.Forms.Label
        Me.cboCultivo = New System.Windows.Forms.ComboBox
        Me.lblDisplayCultivo = New System.Windows.Forms.Label
        Me.lblDisplayFechaHasta = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFecha = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.cboMercado = New System.Windows.Forms.ComboBox
        Me.lblDisplayMercado = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(385, 25)
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
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(85, 17)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio.TabIndex = 232
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(9, 21)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 231
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboMercado)
        Me.GroupBox1.Controls.Add(Me.lblDisplayMercado)
        Me.GroupBox1.Controls.Add(Me.CboZona)
        Me.GroupBox1.Controls.Add(Me.lblDisplayZona)
        Me.GroupBox1.Controls.Add(Me.lblDisplaySemana2)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.LblEjercicio)
        Me.GroupBox1.Controls.Add(Me.lblDisplaySemana1)
        Me.GroupBox1.Controls.Add(Me.CboSemana2)
        Me.GroupBox1.Controls.Add(Me.CboSemana1)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.cboCultivo)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCultivo)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFechaHasta)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFecha)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 209)
        Me.GroupBox1.TabIndex = 233
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(85, 117)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(270, 21)
        Me.CboZona.TabIndex = 369
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(9, 121)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 370
        Me.lblDisplayZona.Text = "Zona :"
        '
        'lblDisplaySemana2
        '
        Me.lblDisplaySemana2.AutoSize = True
        Me.lblDisplaySemana2.Location = New System.Drawing.Point(9, 71)
        Me.lblDisplaySemana2.Name = "lblDisplaySemana2"
        Me.lblDisplaySemana2.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplaySemana2.TabIndex = 363
        Me.lblDisplaySemana2.Text = "Semana 2 :"
        '
        'lblDisplaySemana1
        '
        Me.lblDisplaySemana1.AutoSize = True
        Me.lblDisplaySemana1.Location = New System.Drawing.Point(9, 46)
        Me.lblDisplaySemana1.Name = "lblDisplaySemana1"
        Me.lblDisplaySemana1.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplaySemana1.TabIndex = 362
        Me.lblDisplaySemana1.Text = "Semana 1 :"
        '
        'CboSemana2
        '
        Me.CboSemana2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana2.FormattingEnabled = True
        Me.CboSemana2.Location = New System.Drawing.Point(85, 67)
        Me.CboSemana2.Name = "CboSemana2"
        Me.CboSemana2.Size = New System.Drawing.Size(88, 21)
        Me.CboSemana2.TabIndex = 2
        '
        'CboSemana1
        '
        Me.CboSemana1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana1.FormattingEnabled = True
        Me.CboSemana1.Location = New System.Drawing.Point(85, 42)
        Me.CboSemana1.Name = "CboSemana1"
        Me.CboSemana1.Size = New System.Drawing.Size(88, 21)
        Me.CboSemana1.TabIndex = 1
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(179, 168)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(171, 16)
        Me.lblNombreCliente.TabIndex = 359
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(85, 166)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(88, 20)
        Me.TxtCliente.TabIndex = 3
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(9, 170)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 358
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboCultivo.Location = New System.Drawing.Point(85, 92)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(270, 21)
        Me.cboCultivo.TabIndex = 0
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(9, 96)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 278
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'lblDisplayFechaHasta
        '
        Me.lblDisplayFechaHasta.AutoSize = True
        Me.lblDisplayFechaHasta.Location = New System.Drawing.Point(179, 71)
        Me.lblDisplayFechaHasta.Name = "lblDisplayFechaHasta"
        Me.lblDisplayFechaHasta.Size = New System.Drawing.Size(85, 13)
        Me.lblDisplayFechaHasta.TabIndex = 212
        Me.lblDisplayFechaHasta.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = "dd/MMM/yy"
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaHasta.Location = New System.Drawing.Point(270, 67)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaHasta.TabIndex = 4
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(193, 46)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFecha.TabIndex = 211
        Me.LblDisplayFecha.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = "dd/MMM/yy"
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaDesde.Location = New System.Drawing.Point(270, 42)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaDesde.TabIndex = 3
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'cboMercado
        '
        Me.cboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMercado.FormattingEnabled = True
        Me.cboMercado.Location = New System.Drawing.Point(85, 142)
        Me.cboMercado.Name = "cboMercado"
        Me.cboMercado.Size = New System.Drawing.Size(270, 21)
        Me.cboMercado.TabIndex = 371
        '
        'lblDisplayMercado
        '
        Me.lblDisplayMercado.AutoSize = True
        Me.lblDisplayMercado.Location = New System.Drawing.Point(9, 146)
        Me.lblDisplayMercado.Name = "lblDisplayMercado"
        Me.lblDisplayMercado.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayMercado.TabIndex = 372
        Me.lblDisplayMercado.Text = "Mercado :"
        '
        'Rpt_Embarques_VentasEstimadaArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 249)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Embarques_VentasEstimadaArticulo"
        Me.Text = "Ventas estimada por articulo"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplaySemana2 As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySemana1 As System.Windows.Forms.Label
    Friend WithEvents CboSemana2 As System.Windows.Forms.ComboBox
    Friend WithEvents CboSemana1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCultivo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaHasta As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents cboMercado As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayMercado As System.Windows.Forms.Label
End Class
