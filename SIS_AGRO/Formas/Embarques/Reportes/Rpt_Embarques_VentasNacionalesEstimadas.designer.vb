<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Embarques_VentasNacionalesEstimadas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Embarques_VentasNacionalesEstimadas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboZona = New System.Windows.Forms.ComboBox
        Me.lblDisplayZona = New System.Windows.Forms.Label
        Me.RdbCultivo = New System.Windows.Forms.RadioButton
        Me.RdbCliente = New System.Windows.Forms.RadioButton
        Me.lblDisplayAgrupado = New System.Windows.Forms.Label
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.lblDisplayCliente = New System.Windows.Forms.Label
        Me.cboCultivo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboZona)
        Me.GroupBox1.Controls.Add(Me.lblDisplayZona)
        Me.GroupBox1.Controls.Add(Me.RdbCultivo)
        Me.GroupBox1.Controls.Add(Me.RdbCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayAgrupado)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.cboCultivo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 153)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(94, 46)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(278, 21)
        Me.CboZona.TabIndex = 1
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(6, 49)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 374
        Me.lblDisplayZona.Text = "Zona :"
        '
        'RdbCultivo
        '
        Me.RdbCultivo.AutoSize = True
        Me.RdbCultivo.Checked = True
        Me.RdbCultivo.Location = New System.Drawing.Point(191, 125)
        Me.RdbCultivo.Name = "RdbCultivo"
        Me.RdbCultivo.Size = New System.Drawing.Size(57, 17)
        Me.RdbCultivo.TabIndex = 6
        Me.RdbCultivo.TabStop = True
        Me.RdbCultivo.Text = "Cultivo"
        Me.RdbCultivo.UseVisualStyleBackColor = True
        '
        'RdbCliente
        '
        Me.RdbCliente.AutoSize = True
        Me.RdbCliente.Location = New System.Drawing.Point(94, 125)
        Me.RdbCliente.Name = "RdbCliente"
        Me.RdbCliente.Size = New System.Drawing.Size(57, 17)
        Me.RdbCliente.TabIndex = 5
        Me.RdbCliente.Text = "Cliente"
        Me.RdbCliente.UseVisualStyleBackColor = True
        '
        'lblDisplayAgrupado
        '
        Me.lblDisplayAgrupado.AutoSize = True
        Me.lblDisplayAgrupado.Location = New System.Drawing.Point(6, 127)
        Me.lblDisplayAgrupado.Name = "lblDisplayAgrupado"
        Me.lblDisplayAgrupado.Size = New System.Drawing.Size(77, 13)
        Me.lblDisplayAgrupado.TabIndex = 367
        Me.lblDisplayAgrupado.Text = "Agrupado por :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(188, 102)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(184, 16)
        Me.lblNombreCliente.TabIndex = 359
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(94, 99)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(88, 20)
        Me.TxtCliente.TabIndex = 4
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(6, 102)
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
        Me.cboCultivo.Location = New System.Drawing.Point(94, 19)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(278, 21)
        Me.cboCultivo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 278
        Me.Label2.Text = "Cultivo :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(197, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = "dd/MMM/yy"
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaHasta.Location = New System.Drawing.Point(287, 73)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaHasta.TabIndex = 3
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(6, 74)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 211
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = "dd/MMM/yy"
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaDesde.Location = New System.Drawing.Point(94, 73)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaDesde.TabIndex = 2
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(405, 25)
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
        'Rpt_Embarques_VentasNacionalesEstimadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 195)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Embarques_VentasNacionalesEstimadas"
        Me.Text = "Ventas facturadas nacional"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents RdbCultivo As System.Windows.Forms.RadioButton
    Friend WithEvents RdbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents lblDisplayAgrupado As System.Windows.Forms.Label
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayZona As System.Windows.Forms.Label
End Class
