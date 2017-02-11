<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Ventas_TopTenProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Ventas_TopTenProductos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CboZona = New System.Windows.Forms.ComboBox
        Me.lblDisplayZona = New System.Windows.Forms.Label
        Me.lblTipoCambio = New System.Windows.Forms.Label
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.RdbCultivo = New System.Windows.Forms.RadioButton
        Me.RdbCliente = New System.Windows.Forms.RadioButton
        Me.lblDisplayAgrupado = New System.Windows.Forms.Label
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
        Me.Grid = New FlexCell.Grid
        Me.gbConsulta = New System.Windows.Forms.GroupBox
        Me.txtSum6 = New System.Windows.Forms.Label
        Me.txtSum1 = New System.Windows.Forms.Label
        Me.txtSum4 = New System.Windows.Forms.Label
        Me.txtSum3 = New System.Windows.Forms.Label
        Me.txtSum2 = New System.Windows.Forms.Label
        Me.txtSum5 = New System.Windows.Forms.Label
        Me.lblDisplayTotalDolares = New System.Windows.Forms.Label
        Me.lblDisplayTotalPesos = New System.Windows.Forms.Label
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.cboMercado = New System.Windows.Forms.ComboBox
        Me.lblDisplayMercado = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.gbConsulta.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboMercado)
        Me.GroupBox1.Controls.Add(Me.lblDisplayMercado)
        Me.GroupBox1.Controls.Add(Me.CboZona)
        Me.GroupBox1.Controls.Add(Me.lblDisplayZona)
        Me.GroupBox1.Controls.Add(Me.lblTipoCambio)
        Me.GroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox1.Controls.Add(Me.RdbCultivo)
        Me.GroupBox1.Controls.Add(Me.RdbCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayAgrupado)
        Me.GroupBox1.Controls.Add(Me.lblDisplaySemana2)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(955, 104)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(440, 20)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(157, 21)
        Me.CboZona.TabIndex = 371
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(378, 23)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 372
        Me.lblDisplayZona.Text = "Zona :"
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Location = New System.Drawing.Point(5, 77)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(71, 13)
        Me.lblTipoCambio.TabIndex = 368
        Me.lblTipoCambio.Text = "Tipo cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(82, 73)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(66, 20)
        Me.txtTipoCambio.TabIndex = 367
        Me.txtTipoCambio.Text = "13"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RdbCultivo
        '
        Me.RdbCultivo.AutoSize = True
        Me.RdbCultivo.Checked = True
        Me.RdbCultivo.Location = New System.Drawing.Point(835, 77)
        Me.RdbCultivo.Name = "RdbCultivo"
        Me.RdbCultivo.Size = New System.Drawing.Size(57, 17)
        Me.RdbCultivo.TabIndex = 366
        Me.RdbCultivo.TabStop = True
        Me.RdbCultivo.Text = "Cultivo"
        Me.RdbCultivo.UseVisualStyleBackColor = True
        Me.RdbCultivo.Visible = False
        '
        'RdbCliente
        '
        Me.RdbCliente.AutoSize = True
        Me.RdbCliente.Location = New System.Drawing.Point(731, 77)
        Me.RdbCliente.Name = "RdbCliente"
        Me.RdbCliente.Size = New System.Drawing.Size(57, 17)
        Me.RdbCliente.TabIndex = 365
        Me.RdbCliente.Text = "Cliente"
        Me.RdbCliente.UseVisualStyleBackColor = True
        Me.RdbCliente.Visible = False
        '
        'lblDisplayAgrupado
        '
        Me.lblDisplayAgrupado.AutoSize = True
        Me.lblDisplayAgrupado.Location = New System.Drawing.Point(648, 79)
        Me.lblDisplayAgrupado.Name = "lblDisplayAgrupado"
        Me.lblDisplayAgrupado.Size = New System.Drawing.Size(77, 13)
        Me.lblDisplayAgrupado.TabIndex = 364
        Me.lblDisplayAgrupado.Text = "Agrupado por :"
        Me.lblDisplayAgrupado.Visible = False
        '
        'lblDisplaySemana2
        '
        Me.lblDisplaySemana2.AutoSize = True
        Me.lblDisplaySemana2.Location = New System.Drawing.Point(603, 48)
        Me.lblDisplaySemana2.Name = "lblDisplaySemana2"
        Me.lblDisplaySemana2.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplaySemana2.TabIndex = 363
        Me.lblDisplaySemana2.Text = "Semana 2 :"
        '
        'lblDisplaySemana1
        '
        Me.lblDisplaySemana1.AutoSize = True
        Me.lblDisplaySemana1.Location = New System.Drawing.Point(603, 23)
        Me.lblDisplaySemana1.Name = "lblDisplaySemana1"
        Me.lblDisplaySemana1.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplaySemana1.TabIndex = 362
        Me.lblDisplaySemana1.Text = "Semana 1 :"
        '
        'CboSemana2
        '
        Me.CboSemana2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana2.Enabled = False
        Me.CboSemana2.FormattingEnabled = True
        Me.CboSemana2.Location = New System.Drawing.Point(679, 44)
        Me.CboSemana2.Name = "CboSemana2"
        Me.CboSemana2.Size = New System.Drawing.Size(88, 21)
        Me.CboSemana2.TabIndex = 2
        '
        'CboSemana1
        '
        Me.CboSemana1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana1.Enabled = False
        Me.CboSemana1.FormattingEnabled = True
        Me.CboSemana1.Location = New System.Drawing.Point(679, 19)
        Me.CboSemana1.Name = "CboSemana1"
        Me.CboSemana1.Size = New System.Drawing.Size(88, 21)
        Me.CboSemana1.TabIndex = 1
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(175, 52)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(422, 14)
        Me.lblNombreCliente.TabIndex = 359
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(81, 48)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(88, 20)
        Me.TxtCliente.TabIndex = 3
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(5, 52)
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
        Me.cboCultivo.Location = New System.Drawing.Point(82, 19)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(270, 21)
        Me.cboCultivo.TabIndex = 0
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(6, 23)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 278
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'lblDisplayFechaHasta
        '
        Me.lblDisplayFechaHasta.AutoSize = True
        Me.lblDisplayFechaHasta.Location = New System.Drawing.Point(773, 48)
        Me.lblDisplayFechaHasta.Name = "lblDisplayFechaHasta"
        Me.lblDisplayFechaHasta.Size = New System.Drawing.Size(85, 13)
        Me.lblDisplayFechaHasta.TabIndex = 212
        Me.lblDisplayFechaHasta.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = "dd/MMM/yy"
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaHasta.Location = New System.Drawing.Point(864, 44)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaHasta.TabIndex = 4
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(787, 23)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFecha.TabIndex = 211
        Me.LblDisplayFecha.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = "dd/MMM/yy"
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaDesde.Location = New System.Drawing.Point(864, 19)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaDesde.TabIndex = 3
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Grid
        '
        Me.Grid.AllowUserResizing = FlexCell.ResizeEnum.Rows
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(9, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(940, 321)
        Me.Grid.TabIndex = 223
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbConsulta
        '
        Me.gbConsulta.Controls.Add(Me.txtSum6)
        Me.gbConsulta.Controls.Add(Me.txtSum1)
        Me.gbConsulta.Controls.Add(Me.txtSum4)
        Me.gbConsulta.Controls.Add(Me.txtSum3)
        Me.gbConsulta.Controls.Add(Me.txtSum2)
        Me.gbConsulta.Controls.Add(Me.txtSum5)
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalDolares)
        Me.gbConsulta.Controls.Add(Me.lblDisplayTotalPesos)
        Me.gbConsulta.Controls.Add(Me.Grid)
        Me.gbConsulta.Location = New System.Drawing.Point(12, 150)
        Me.gbConsulta.Name = "gbConsulta"
        Me.gbConsulta.Size = New System.Drawing.Size(955, 397)
        Me.gbConsulta.TabIndex = 224
        Me.gbConsulta.TabStop = False
        Me.gbConsulta.Text = "Consulta"
        '
        'txtSum6
        '
        Me.txtSum6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum6.Location = New System.Drawing.Point(420, 369)
        Me.txtSum6.Name = "txtSum6"
        Me.txtSum6.Size = New System.Drawing.Size(100, 20)
        Me.txtSum6.TabIndex = 237
        Me.txtSum6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSum1
        '
        Me.txtSum1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum1.Location = New System.Drawing.Point(420, 345)
        Me.txtSum1.Name = "txtSum1"
        Me.txtSum1.Size = New System.Drawing.Size(100, 20)
        Me.txtSum1.TabIndex = 236
        Me.txtSum1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSum4
        '
        Me.txtSum4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum4.Location = New System.Drawing.Point(585, 369)
        Me.txtSum4.Name = "txtSum4"
        Me.txtSum4.Size = New System.Drawing.Size(100, 20)
        Me.txtSum4.TabIndex = 235
        Me.txtSum4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSum3
        '
        Me.txtSum3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum3.Location = New System.Drawing.Point(585, 345)
        Me.txtSum3.Name = "txtSum3"
        Me.txtSum3.Size = New System.Drawing.Size(100, 20)
        Me.txtSum3.TabIndex = 234
        Me.txtSum3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSum2
        '
        Me.txtSum2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum2.Location = New System.Drawing.Point(691, 369)
        Me.txtSum2.Name = "txtSum2"
        Me.txtSum2.Size = New System.Drawing.Size(69, 20)
        Me.txtSum2.TabIndex = 233
        Me.txtSum2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSum5
        '
        Me.txtSum5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSum5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSum5.Location = New System.Drawing.Point(691, 345)
        Me.txtSum5.Name = "txtSum5"
        Me.txtSum5.Size = New System.Drawing.Size(69, 20)
        Me.txtSum5.TabIndex = 232
        Me.txtSum5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalDolares
        '
        Me.lblDisplayTotalDolares.AutoSize = True
        Me.lblDisplayTotalDolares.Location = New System.Drawing.Point(251, 349)
        Me.lblDisplayTotalDolares.Name = "lblDisplayTotalDolares"
        Me.lblDisplayTotalDolares.Size = New System.Drawing.Size(74, 13)
        Me.lblDisplayTotalDolares.TabIndex = 231
        Me.lblDisplayTotalDolares.Text = "Total dólares :"
        '
        'lblDisplayTotalPesos
        '
        Me.lblDisplayTotalPesos.AutoSize = True
        Me.lblDisplayTotalPesos.Location = New System.Drawing.Point(251, 373)
        Me.lblDisplayTotalPesos.Name = "lblDisplayTotalPesos"
        Me.lblDisplayTotalPesos.Size = New System.Drawing.Size(68, 13)
        Me.lblDisplayTotalPesos.TabIndex = 230
        Me.lblDisplayTotalPesos.Text = "Total pesos :"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(971, 25)
        Me.ToolStrip2.TabIndex = 225
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "&Consultar"
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
        'cboMercado
        '
        Me.cboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMercado.FormattingEnabled = True
        Me.cboMercado.Location = New System.Drawing.Point(440, 77)
        Me.cboMercado.Name = "cboMercado"
        Me.cboMercado.Size = New System.Drawing.Size(157, 21)
        Me.cboMercado.TabIndex = 373
        '
        'lblDisplayMercado
        '
        Me.lblDisplayMercado.AutoSize = True
        Me.lblDisplayMercado.Location = New System.Drawing.Point(378, 80)
        Me.lblDisplayMercado.Name = "lblDisplayMercado"
        Me.lblDisplayMercado.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayMercado.TabIndex = 374
        Me.lblDisplayMercado.Text = "Mercado :"
        '
        'Rpt_Ventas_TopTenProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 559)
        Me.Controls.Add(Me.gbConsulta)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Ventas_TopTenProductos"
        Me.Text = "TopTen de productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbConsulta.ResumeLayout(False)
        Me.gbConsulta.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents RdbCultivo As System.Windows.Forms.RadioButton
    Friend WithEvents RdbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents lblDisplayAgrupado As System.Windows.Forms.Label
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
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents gbConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalPesos As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalDolares As System.Windows.Forms.Label
    Friend WithEvents txtSum5 As System.Windows.Forms.Label
    Friend WithEvents txtSum4 As System.Windows.Forms.Label
    Friend WithEvents txtSum3 As System.Windows.Forms.Label
    Friend WithEvents txtSum2 As System.Windows.Forms.Label
    Friend WithEvents txtSum6 As System.Windows.Forms.Label
    Friend WithEvents txtSum1 As System.Windows.Forms.Label
    Friend WithEvents cboMercado As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayMercado As System.Windows.Forms.Label
End Class
