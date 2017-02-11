<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Inventario_Existencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Inventario_Existencias))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbxTipoFormato = New System.Windows.Forms.GroupBox()
        Me.rbtnPorFamilias = New System.Windows.Forms.RadioButton()
        Me.rbtnParaInventario = New System.Windows.Forms.RadioButton()
        Me.rbtnConCostos = New System.Windows.Forms.RadioButton()
        Me.CboFamilia = New System.Windows.Forms.ComboBox()
        Me.chkExcluirfamilia = New System.Windows.Forms.CheckBox()
        Me.CmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.ChkFechas = New System.Windows.Forms.CheckBox()
        Me.CHSoloExistencia = New System.Windows.Forms.CheckBox()
        Me.gbFiltros = New System.Windows.Forms.GroupBox()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.TxtCodArticulo = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.rbtnSeries = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.gbxTipoFormato.SuspendLayout()
        Me.gbFiltros.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbxTipoFormato)
        Me.GroupBox1.Controls.Add(Me.CboFamilia)
        Me.GroupBox1.Controls.Add(Me.chkExcluirfamilia)
        Me.GroupBox1.Controls.Add(Me.CmbAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.ChkFechas)
        Me.GroupBox1.Controls.Add(Me.CHSoloExistencia)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 96)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(825, 222)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'gbxTipoFormato
        '
        Me.gbxTipoFormato.Controls.Add(Me.rbtnSeries)
        Me.gbxTipoFormato.Controls.Add(Me.rbtnPorFamilias)
        Me.gbxTipoFormato.Controls.Add(Me.rbtnParaInventario)
        Me.gbxTipoFormato.Controls.Add(Me.rbtnConCostos)
        Me.gbxTipoFormato.Location = New System.Drawing.Point(565, 64)
        Me.gbxTipoFormato.Margin = New System.Windows.Forms.Padding(4)
        Me.gbxTipoFormato.Name = "gbxTipoFormato"
        Me.gbxTipoFormato.Padding = New System.Windows.Forms.Padding(4)
        Me.gbxTipoFormato.Size = New System.Drawing.Size(208, 145)
        Me.gbxTipoFormato.TabIndex = 272
        Me.gbxTipoFormato.TabStop = False
        Me.gbxTipoFormato.Text = "Formato "
        '
        'rbtnPorFamilias
        '
        Me.rbtnPorFamilias.AutoSize = True
        Me.rbtnPorFamilias.Location = New System.Drawing.Point(20, 84)
        Me.rbtnPorFamilias.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnPorFamilias.Name = "rbtnPorFamilias"
        Me.rbtnPorFamilias.Size = New System.Drawing.Size(167, 21)
        Me.rbtnPorFamilias.TabIndex = 2
        Me.rbtnPorFamilias.TabStop = True
        Me.rbtnPorFamilias.Text = "Agrupado por familias"
        Me.rbtnPorFamilias.UseVisualStyleBackColor = True
        '
        'rbtnParaInventario
        '
        Me.rbtnParaInventario.AutoSize = True
        Me.rbtnParaInventario.Location = New System.Drawing.Point(20, 55)
        Me.rbtnParaInventario.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnParaInventario.Name = "rbtnParaInventario"
        Me.rbtnParaInventario.Size = New System.Drawing.Size(165, 21)
        Me.rbtnParaInventario.TabIndex = 1
        Me.rbtnParaInventario.TabStop = True
        Me.rbtnParaInventario.Text = "Para tomar inventario"
        Me.rbtnParaInventario.UseVisualStyleBackColor = True
        '
        'rbtnConCostos
        '
        Me.rbtnConCostos.AutoSize = True
        Me.rbtnConCostos.Location = New System.Drawing.Point(20, 26)
        Me.rbtnConCostos.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnConCostos.Name = "rbtnConCostos"
        Me.rbtnConCostos.Size = New System.Drawing.Size(99, 21)
        Me.rbtnConCostos.TabIndex = 0
        Me.rbtnConCostos.TabStop = True
        Me.rbtnConCostos.Text = "Con costos"
        Me.rbtnConCostos.UseVisualStyleBackColor = True
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.CboFamilia.Location = New System.Drawing.Point(157, 122)
        Me.CboFamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(355, 24)
        Me.CboFamilia.TabIndex = 271
        '
        'chkExcluirfamilia
        '
        Me.chkExcluirfamilia.AutoSize = True
        Me.chkExcluirfamilia.Location = New System.Drawing.Point(31, 124)
        Me.chkExcluirfamilia.Margin = New System.Windows.Forms.Padding(4)
        Me.chkExcluirfamilia.Name = "chkExcluirfamilia"
        Me.chkExcluirfamilia.Size = New System.Drawing.Size(115, 21)
        Me.chkExcluirfamilia.TabIndex = 270
        Me.chkExcluirfamilia.Text = "Excluir familia"
        Me.chkExcluirfamilia.UseVisualStyleBackColor = True
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAlmacen.FormattingEnabled = True
        Me.CmbAlmacen.Items.AddRange(New Object() {"TODOS"})
        Me.CmbAlmacen.Location = New System.Drawing.Point(519, 21)
        Me.CmbAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(280, 24)
        Me.CmbAlmacen.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(399, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 269
        Me.Label3.Text = "Almacén :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(277, 95)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Enabled = False
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(399, 90)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(113, 22)
        Me.DtFechaHasta.TabIndex = 5
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(27, 95)
        Me.LblDisplayFechaNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(92, 17)
        Me.LblDisplayFechaNacimiento.TabIndex = 211
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Enabled = False
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(129, 90)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(124, 22)
        Me.DtFechaDesde.TabIndex = 4
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'ChkFechas
        '
        Me.ChkFechas.AutoSize = True
        Me.ChkFechas.Location = New System.Drawing.Point(31, 55)
        Me.ChkFechas.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkFechas.Name = "ChkFechas"
        Me.ChkFechas.Size = New System.Drawing.Size(223, 21)
        Me.ChkFechas.TabIndex = 3
        Me.ChkFechas.Text = "Filtrar movimientos por  fechas"
        Me.ChkFechas.UseVisualStyleBackColor = True
        '
        'CHSoloExistencia
        '
        Me.CHSoloExistencia.AutoSize = True
        Me.CHSoloExistencia.Checked = True
        Me.CHSoloExistencia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHSoloExistencia.Location = New System.Drawing.Point(31, 23)
        Me.CHSoloExistencia.Margin = New System.Windows.Forms.Padding(4)
        Me.CHSoloExistencia.Name = "CHSoloExistencia"
        Me.CHSoloExistencia.Size = New System.Drawing.Size(258, 21)
        Me.CHSoloExistencia.TabIndex = 2
        Me.CHSoloExistencia.Text = "Ocultar artículos con existencia cero"
        Me.CHSoloExistencia.UseVisualStyleBackColor = True
        '
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.lblArticulo)
        Me.gbFiltros.Controls.Add(Me.LblDisplayCodArticulo)
        Me.gbFiltros.Controls.Add(Me.TxtCodArticulo)
        Me.gbFiltros.Location = New System.Drawing.Point(16, 34)
        Me.gbFiltros.Margin = New System.Windows.Forms.Padding(4)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Padding = New System.Windows.Forms.Padding(4)
        Me.gbFiltros.Size = New System.Drawing.Size(823, 54)
        Me.gbFiltros.TabIndex = 9
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Tipo de Reporte"
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(212, 27)
        Me.lblArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(605, 16)
        Me.lblArticulo.TabIndex = 278
        Me.lblArticulo.Text = "_"
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(33, 27)
        Me.LblDisplayCodArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayCodArticulo.TabIndex = 277
        Me.LblDisplayCodArticulo.Text = "Artículo :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Location = New System.Drawing.Point(108, 23)
        Me.TxtCodArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodArticulo.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(855, 27)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'rbtnSeries
        '
        Me.rbtnSeries.AutoSize = True
        Me.rbtnSeries.Location = New System.Drawing.Point(20, 113)
        Me.rbtnSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnSeries.Name = "rbtnSeries"
        Me.rbtnSeries.Size = New System.Drawing.Size(69, 21)
        Me.rbtnSeries.TabIndex = 3
        Me.rbtnSeries.TabStop = True
        Me.rbtnSeries.Text = "Series"
        Me.rbtnSeries.UseVisualStyleBackColor = True
        '
        'Rpt_Inventario_Existencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 332)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Inventario_Existencias"
        Me.Text = "Existencia del inventario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxTipoFormato.ResumeLayout(False)
        Me.gbxTipoFormato.PerformLayout()
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents CHSoloExistencia As System.Windows.Forms.CheckBox
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents chkExcluirfamilia As System.Windows.Forms.CheckBox
    Friend WithEvents CboFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents gbxTipoFormato As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnParaInventario As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnConCostos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPorFamilias As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSeries As System.Windows.Forms.RadioButton
End Class
