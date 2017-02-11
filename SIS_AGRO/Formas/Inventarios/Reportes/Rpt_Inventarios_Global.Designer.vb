<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Inventarios_Global
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Inventarios_Global))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.CmbDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.TxtCodArticulo = New System.Windows.Forms.TextBox()
        Me.CmbAlmacen2 = New System.Windows.Forms.ComboBox()
        Me.lblDisplayAlmacen2 = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbFiltros = New System.Windows.Forms.GroupBox()
        Me.RdbDetalleCultivo = New System.Windows.Forms.RadioButton()
        Me.RdbMovimientosGlobales = New System.Windows.Forms.RadioButton()
        Me.RdbMovimientosDetallados = New System.Windows.Forms.RadioButton()
        Me.RdbTotalesCultivo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.gbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblArticulo)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.CboEstatus)
        Me.GroupBox1.Controls.Add(Me.CmbDocumento)
        Me.GroupBox1.Controls.Add(Me.LblDocumento)
        Me.GroupBox1.Controls.Add(Me.LblDisplayCodArticulo)
        Me.GroupBox1.Controls.Add(Me.TxtCodArticulo)
        Me.GroupBox1.Controls.Add(Me.CmbAlmacen2)
        Me.GroupBox1.Controls.Add(Me.lblDisplayAlmacen2)
        Me.GroupBox1.Controls.Add(Me.CmbAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 158)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(162, 44)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(451, 13)
        Me.lblArticulo.TabIndex = 285
        Me.lblArticulo.Text = "_"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(303, 97)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 284
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DisplayMember = "A"
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Location = New System.Drawing.Point(389, 94)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(57, 21)
        Me.CboEstatus.TabIndex = 7
        '
        'CmbDocumento
        '
        Me.CmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDocumento.FormattingEnabled = True
        Me.CmbDocumento.Location = New System.Drawing.Point(84, 15)
        Me.CmbDocumento.Name = "CmbDocumento"
        Me.CmbDocumento.Size = New System.Drawing.Size(211, 21)
        Me.CmbDocumento.TabIndex = 1
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(10, 18)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 277
        Me.LblDocumento.Text = "Documento :"
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(10, 44)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayCodArticulo.TabIndex = 275
        Me.LblDisplayCodArticulo.Text = "Artículo :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Location = New System.Drawing.Point(84, 41)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(72, 20)
        Me.TxtCodArticulo.TabIndex = 2
        '
        'CmbAlmacen2
        '
        Me.CmbAlmacen2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAlmacen2.FormattingEnabled = True
        Me.CmbAlmacen2.Location = New System.Drawing.Point(389, 68)
        Me.CmbAlmacen2.Name = "CmbAlmacen2"
        Me.CmbAlmacen2.Size = New System.Drawing.Size(211, 21)
        Me.CmbAlmacen2.TabIndex = 4
        Me.CmbAlmacen2.Visible = False
        '
        'lblDisplayAlmacen2
        '
        Me.lblDisplayAlmacen2.AutoSize = True
        Me.lblDisplayAlmacen2.Location = New System.Drawing.Point(303, 71)
        Me.lblDisplayAlmacen2.Name = "lblDisplayAlmacen2"
        Me.lblDisplayAlmacen2.Size = New System.Drawing.Size(63, 13)
        Me.lblDisplayAlmacen2.TabIndex = 271
        Me.lblDisplayAlmacen2.Text = "Almacen 2 :"
        Me.lblDisplayAlmacen2.Visible = False
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAlmacen.FormattingEnabled = True
        Me.CmbAlmacen.Location = New System.Drawing.Point(84, 67)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(211, 21)
        Me.CmbAlmacen.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 269
        Me.Label3.Text = "Almacen 1:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(100, 120)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(86, 20)
        Me.DtFechaHasta.TabIndex = 6
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(10, 97)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 211
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(100, 94)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(87, 20)
        Me.DtFechaDesde.TabIndex = 5
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(644, 25)
        Me.ToolStrip1.TabIndex = 11
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
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.RdbTotalesCultivo)
        Me.gbFiltros.Controls.Add(Me.RdbDetalleCultivo)
        Me.gbFiltros.Controls.Add(Me.RdbMovimientosGlobales)
        Me.gbFiltros.Controls.Add(Me.RdbMovimientosDetallados)
        Me.gbFiltros.Location = New System.Drawing.Point(12, 28)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(619, 75)
        Me.gbFiltros.TabIndex = 10
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Tipo de Reporte"
        '
        'RdbDetalleCultivo
        '
        Me.RdbDetalleCultivo.AutoSize = True
        Me.RdbDetalleCultivo.Location = New System.Drawing.Point(205, 52)
        Me.RdbDetalleCultivo.Name = "RdbDetalleCultivo"
        Me.RdbDetalleCultivo.Size = New System.Drawing.Size(122, 17)
        Me.RdbDetalleCultivo.TabIndex = 132
        Me.RdbDetalleCultivo.Text = "Detallado por cultivo"
        Me.RdbDetalleCultivo.UseVisualStyleBackColor = True
        '
        'RdbMovimientosGlobales
        '
        Me.RdbMovimientosGlobales.AutoSize = True
        Me.RdbMovimientosGlobales.Checked = True
        Me.RdbMovimientosGlobales.Location = New System.Drawing.Point(6, 19)
        Me.RdbMovimientosGlobales.Name = "RdbMovimientosGlobales"
        Me.RdbMovimientosGlobales.Size = New System.Drawing.Size(184, 17)
        Me.RdbMovimientosGlobales.TabIndex = 130
        Me.RdbMovimientosGlobales.TabStop = True
        Me.RdbMovimientosGlobales.Text = "&Reporte de Movimientos Globales"
        Me.RdbMovimientosGlobales.UseVisualStyleBackColor = True
        '
        'RdbMovimientosDetallados
        '
        Me.RdbMovimientosDetallados.AutoSize = True
        Me.RdbMovimientosDetallados.Location = New System.Drawing.Point(205, 19)
        Me.RdbMovimientosDetallados.Name = "RdbMovimientosDetallados"
        Me.RdbMovimientosDetallados.Size = New System.Drawing.Size(193, 17)
        Me.RdbMovimientosDetallados.TabIndex = 129
        Me.RdbMovimientosDetallados.Text = "&Reporte de Movimientos Detallados"
        Me.RdbMovimientosDetallados.UseVisualStyleBackColor = True
        '
        'RdbTotalesCultivo
        '
        Me.RdbTotalesCultivo.AutoSize = True
        Me.RdbTotalesCultivo.Location = New System.Drawing.Point(6, 52)
        Me.RdbTotalesCultivo.Name = "RdbTotalesCultivo"
        Me.RdbTotalesCultivo.Size = New System.Drawing.Size(112, 17)
        Me.RdbTotalesCultivo.TabIndex = 131
        Me.RdbTotalesCultivo.Text = "Totales por cultivo"
        Me.RdbTotalesCultivo.UseVisualStyleBackColor = True
        '
        'Rpt_Inventarios_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 272)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Inventarios_Global"
        Me.Text = "Global de inventarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents CmbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents CmbAlmacen2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayAlmacen2 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents RdbMovimientosDetallados As System.Windows.Forms.RadioButton
    Friend WithEvents RdbMovimientosGlobales As System.Windows.Forms.RadioButton
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents RdbDetalleCultivo As System.Windows.Forms.RadioButton
    Friend WithEvents RdbTotalesCultivo As System.Windows.Forms.RadioButton
End Class
