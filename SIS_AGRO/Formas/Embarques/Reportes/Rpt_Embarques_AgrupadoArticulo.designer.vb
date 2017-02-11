<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Embarques_AgrupadoArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Embarques_AgrupadoArticulo))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboAduanaNacional = New System.Windows.Forms.ComboBox
        Me.CboAduanaExtranjera = New System.Windows.Forms.ComboBox
        Me.CboProductor = New System.Windows.Forms.ComboBox
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.lblDisplayCliente = New System.Windows.Forms.Label
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.CboTipoMercado = New System.Windows.Forms.ComboBox
        Me.lblDisplayTipoMercado = New System.Windows.Forms.Label
        Me.lblNombreArticulo = New System.Windows.Forms.Label
        Me.CboLugarEntrega = New System.Windows.Forms.ComboBox
        Me.lblDisplayArticulo = New System.Windows.Forms.Label
        Me.lblDisplayLugarEntrega = New System.Windows.Forms.Label
        Me.TxtCodigoArticulo = New System.Windows.Forms.TextBox
        Me.lblAduanaNacional = New System.Windows.Forms.Label
        Me.lblAduanaExtranjera = New System.Windows.Forms.Label
        Me.cboCultivo = New System.Windows.Forms.ComboBox
        Me.lblDisplayCultivo = New System.Windows.Forms.Label
        Me.lblDisplayProductor = New System.Windows.Forms.Label
        Me.lblDisplayHastaFecha = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.lblDisplayDeFecha = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(451, 25)
        Me.ToolStrip1.TabIndex = 12
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboAduanaNacional)
        Me.GroupBox1.Controls.Add(Me.CboAduanaExtranjera)
        Me.GroupBox1.Controls.Add(Me.CboProductor)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.CboTipoMercado)
        Me.GroupBox1.Controls.Add(Me.lblDisplayTipoMercado)
        Me.GroupBox1.Controls.Add(Me.lblNombreArticulo)
        Me.GroupBox1.Controls.Add(Me.CboLugarEntrega)
        Me.GroupBox1.Controls.Add(Me.lblDisplayArticulo)
        Me.GroupBox1.Controls.Add(Me.lblDisplayLugarEntrega)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoArticulo)
        Me.GroupBox1.Controls.Add(Me.lblAduanaNacional)
        Me.GroupBox1.Controls.Add(Me.lblAduanaExtranjera)
        Me.GroupBox1.Controls.Add(Me.cboCultivo)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCultivo)
        Me.GroupBox1.Controls.Add(Me.lblDisplayProductor)
        Me.GroupBox1.Controls.Add(Me.lblDisplayHastaFecha)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.lblDisplayDeFecha)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 291)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'CboAduanaNacional
        '
        Me.CboAduanaNacional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAduanaNacional.FormattingEnabled = True
        Me.CboAduanaNacional.Location = New System.Drawing.Point(107, 231)
        Me.CboAduanaNacional.Name = "CboAduanaNacional"
        Me.CboAduanaNacional.Size = New System.Drawing.Size(307, 21)
        Me.CboAduanaNacional.TabIndex = 8
        '
        'CboAduanaExtranjera
        '
        Me.CboAduanaExtranjera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAduanaExtranjera.FormattingEnabled = True
        Me.CboAduanaExtranjera.Location = New System.Drawing.Point(107, 205)
        Me.CboAduanaExtranjera.Name = "CboAduanaExtranjera"
        Me.CboAduanaExtranjera.Size = New System.Drawing.Size(307, 21)
        Me.CboAduanaExtranjera.TabIndex = 7
        '
        'CboProductor
        '
        Me.CboProductor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProductor.FormattingEnabled = True
        Me.CboProductor.Location = New System.Drawing.Point(107, 132)
        Me.CboProductor.Name = "CboProductor"
        Me.CboProductor.Size = New System.Drawing.Size(307, 21)
        Me.CboProductor.TabIndex = 5
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(107, 181)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(307, 15)
        Me.lblNombreCliente.TabIndex = 371
        Me.lblNombreCliente.Text = "_"
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(8, 162)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 370
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(107, 158)
        Me.TxtCliente.MaxLength = 16
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(72, 20)
        Me.TxtCliente.TabIndex = 6
        '
        'CboTipoMercado
        '
        Me.CboTipoMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoMercado.FormattingEnabled = True
        Me.CboTipoMercado.Location = New System.Drawing.Point(107, 106)
        Me.CboTipoMercado.Name = "CboTipoMercado"
        Me.CboTipoMercado.Size = New System.Drawing.Size(307, 21)
        Me.CboTipoMercado.TabIndex = 4
        '
        'lblDisplayTipoMercado
        '
        Me.lblDisplayTipoMercado.AutoSize = True
        Me.lblDisplayTipoMercado.Location = New System.Drawing.Point(8, 110)
        Me.lblDisplayTipoMercado.Name = "lblDisplayTipoMercado"
        Me.lblDisplayTipoMercado.Size = New System.Drawing.Size(93, 13)
        Me.lblDisplayTipoMercado.TabIndex = 368
        Me.lblDisplayTipoMercado.Text = "Tipo de mercado :"
        '
        'lblNombreArticulo
        '
        Me.lblNombreArticulo.Location = New System.Drawing.Point(107, 86)
        Me.lblNombreArticulo.Name = "lblNombreArticulo"
        Me.lblNombreArticulo.Size = New System.Drawing.Size(307, 15)
        Me.lblNombreArticulo.TabIndex = 366
        Me.lblNombreArticulo.Text = "_"
        '
        'CboLugarEntrega
        '
        Me.CboLugarEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLugarEntrega.FormattingEnabled = True
        Me.CboLugarEntrega.Location = New System.Drawing.Point(107, 257)
        Me.CboLugarEntrega.Name = "CboLugarEntrega"
        Me.CboLugarEntrega.Size = New System.Drawing.Size(307, 21)
        Me.CboLugarEntrega.TabIndex = 9
        '
        'lblDisplayArticulo
        '
        Me.lblDisplayArticulo.AutoSize = True
        Me.lblDisplayArticulo.Location = New System.Drawing.Point(8, 65)
        Me.lblDisplayArticulo.Name = "lblDisplayArticulo"
        Me.lblDisplayArticulo.Size = New System.Drawing.Size(50, 13)
        Me.lblDisplayArticulo.TabIndex = 365
        Me.lblDisplayArticulo.Text = "Artículo :"
        '
        'lblDisplayLugarEntrega
        '
        Me.lblDisplayLugarEntrega.AutoSize = True
        Me.lblDisplayLugarEntrega.Location = New System.Drawing.Point(8, 261)
        Me.lblDisplayLugarEntrega.Name = "lblDisplayLugarEntrega"
        Me.lblDisplayLugarEntrega.Size = New System.Drawing.Size(91, 13)
        Me.lblDisplayLugarEntrega.TabIndex = 363
        Me.lblDisplayLugarEntrega.Text = "Lugar de entrega:"
        '
        'TxtCodigoArticulo
        '
        Me.TxtCodigoArticulo.Location = New System.Drawing.Point(107, 61)
        Me.TxtCodigoArticulo.MaxLength = 16
        Me.TxtCodigoArticulo.Name = "TxtCodigoArticulo"
        Me.TxtCodigoArticulo.Size = New System.Drawing.Size(103, 20)
        Me.TxtCodigoArticulo.TabIndex = 3
        '
        'lblAduanaNacional
        '
        Me.lblAduanaNacional.AutoSize = True
        Me.lblAduanaNacional.Location = New System.Drawing.Point(8, 235)
        Me.lblAduanaNacional.Name = "lblAduanaNacional"
        Me.lblAduanaNacional.Size = New System.Drawing.Size(76, 13)
        Me.lblAduanaNacional.TabIndex = 350
        Me.lblAduanaNacional.Text = "Aduana Nac. :"
        '
        'lblAduanaExtranjera
        '
        Me.lblAduanaExtranjera.AutoSize = True
        Me.lblAduanaExtranjera.Location = New System.Drawing.Point(8, 209)
        Me.lblAduanaExtranjera.Name = "lblAduanaExtranjera"
        Me.lblAduanaExtranjera.Size = New System.Drawing.Size(71, 13)
        Me.lblAduanaExtranjera.TabIndex = 348
        Me.lblAduanaExtranjera.Text = "Aduana Ext. :"
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboCultivo.Location = New System.Drawing.Point(107, 35)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(307, 21)
        Me.cboCultivo.TabIndex = 2
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(8, 39)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 278
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'lblDisplayProductor
        '
        Me.lblDisplayProductor.AutoSize = True
        Me.lblDisplayProductor.Location = New System.Drawing.Point(8, 136)
        Me.lblDisplayProductor.Name = "lblDisplayProductor"
        Me.lblDisplayProductor.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayProductor.TabIndex = 275
        Me.lblDisplayProductor.Text = "Productor :"
        '
        'lblDisplayHastaFecha
        '
        Me.lblDisplayHastaFecha.AutoSize = True
        Me.lblDisplayHastaFecha.Location = New System.Drawing.Point(225, 14)
        Me.lblDisplayHastaFecha.Name = "lblDisplayHastaFecha"
        Me.lblDisplayHastaFecha.Size = New System.Drawing.Size(85, 13)
        Me.lblDisplayHastaFecha.TabIndex = 212
        Me.lblDisplayHastaFecha.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = ""
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(321, 10)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaHasta.TabIndex = 1
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'lblDisplayDeFecha
        '
        Me.lblDisplayDeFecha.AutoSize = True
        Me.lblDisplayDeFecha.Location = New System.Drawing.Point(8, 14)
        Me.lblDisplayDeFecha.Name = "lblDisplayDeFecha"
        Me.lblDisplayDeFecha.Size = New System.Drawing.Size(71, 13)
        Me.lblDisplayDeFecha.TabIndex = 211
        Me.lblDisplayDeFecha.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = ""
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(107, 10)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaDesde.TabIndex = 0
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Rpt_Embarques_AgrupadoArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 331)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Embarques_AgrupadoArticulo"
        Me.Text = "Reporte agrupado por articulos"
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCultivo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayProductor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayHastaFecha As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayDeFecha As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAduanaNacional As System.Windows.Forms.Label
    Friend WithEvents lblAduanaExtranjera As System.Windows.Forms.Label
    Friend WithEvents CboLugarEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayLugarEntrega As System.Windows.Forms.Label
    Friend WithEvents lblNombreArticulo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents CboTipoMercado As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTipoMercado As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents CboAduanaNacional As System.Windows.Forms.ComboBox
    Friend WithEvents CboAduanaExtranjera As System.Windows.Forms.ComboBox
    Friend WithEvents CboProductor As System.Windows.Forms.ComboBox
End Class
