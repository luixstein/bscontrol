<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_CentroCostos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_CentroCostos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblFecha2 = New System.Windows.Forms.Label()
        Me.CboCentroCosto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCentroConsto = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCategoria = New System.Windows.Forms.Label()
        Me.lblFecha1 = New System.Windows.Forms.Label()
        Me.cboConcepto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.RbtAgrupado = New System.Windows.Forms.RadioButton()
        Me.RbtDetallado = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.RbtVentasRel = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(605, 27)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(90, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'lblFecha2
        '
        Me.lblFecha2.AutoSize = True
        Me.lblFecha2.Location = New System.Drawing.Point(239, 39)
        Me.lblFecha2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecha2.Name = "lblFecha2"
        Me.lblFecha2.Size = New System.Drawing.Size(53, 17)
        Me.lblFecha2.TabIndex = 361
        Me.lblFecha2.Text = "Hasta :"
        '
        'CboCentroCosto
        '
        Me.CboCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCentroCosto.FormattingEnabled = True
        Me.CboCentroCosto.Location = New System.Drawing.Point(164, 68)
        Me.CboCentroCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.CboCentroCosto.Name = "CboCentroCosto"
        Me.CboCentroCosto.Size = New System.Drawing.Size(432, 24)
        Me.CboCentroCosto.TabIndex = 3
        '
        'lblDisplayCentroConsto
        '
        Me.lblDisplayCentroConsto.AutoSize = True
        Me.lblDisplayCentroConsto.Location = New System.Drawing.Point(16, 71)
        Me.lblDisplayCentroConsto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCentroConsto.Name = "lblDisplayCentroConsto"
        Me.lblDisplayCentroConsto.Size = New System.Drawing.Size(116, 17)
        Me.lblDisplayCentroConsto.TabIndex = 363
        Me.lblDisplayCentroConsto.Text = "Centro de costo :"
        '
        'cboCategoria
        '
        Me.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(164, 102)
        Me.cboCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(432, 24)
        Me.cboCategoria.TabIndex = 4
        '
        'lblDisplayCategoria
        '
        Me.lblDisplayCategoria.AutoSize = True
        Me.lblDisplayCategoria.Location = New System.Drawing.Point(16, 105)
        Me.lblDisplayCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCategoria.Name = "lblDisplayCategoria"
        Me.lblDisplayCategoria.Size = New System.Drawing.Size(77, 17)
        Me.lblDisplayCategoria.TabIndex = 382
        Me.lblDisplayCategoria.Text = "Categoria :"
        '
        'lblFecha1
        '
        Me.lblFecha1.AutoSize = True
        Me.lblFecha1.Location = New System.Drawing.Point(16, 39)
        Me.lblFecha1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(57, 17)
        Me.lblFecha1.TabIndex = 385
        Me.lblFecha1.Text = "Desde :"
        Me.lblFecha1.Visible = False
        '
        'cboConcepto
        '
        Me.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConcepto.FormattingEnabled = True
        Me.cboConcepto.Location = New System.Drawing.Point(164, 134)
        Me.cboConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.cboConcepto.Name = "cboConcepto"
        Me.cboConcepto.Size = New System.Drawing.Size(432, 24)
        Me.cboConcepto.TabIndex = 5
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(16, 137)
        Me.lblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.lblDisplayConcepto.TabIndex = 388
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'RbtAgrupado
        '
        Me.RbtAgrupado.AutoSize = True
        Me.RbtAgrupado.Checked = True
        Me.RbtAgrupado.Location = New System.Drawing.Point(6, 21)
        Me.RbtAgrupado.Name = "RbtAgrupado"
        Me.RbtAgrupado.Size = New System.Drawing.Size(91, 21)
        Me.RbtAgrupado.TabIndex = 389
        Me.RbtAgrupado.TabStop = True
        Me.RbtAgrupado.Text = "Agrupado"
        Me.RbtAgrupado.UseVisualStyleBackColor = True
        '
        'RbtDetallado
        '
        Me.RbtDetallado.AutoSize = True
        Me.RbtDetallado.Location = New System.Drawing.Point(125, 21)
        Me.RbtDetallado.Name = "RbtDetallado"
        Me.RbtDetallado.Size = New System.Drawing.Size(89, 21)
        Me.RbtDetallado.TabIndex = 390
        Me.RbtDetallado.Text = "Detallado"
        Me.RbtDetallado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbtVentasRel)
        Me.GroupBox1.Controls.Add(Me.RbtAgrupado)
        Me.GroupBox1.Controls.Add(Me.RbtDetallado)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(577, 55)
        Me.GroupBox1.TabIndex = 391
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Formato : "
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(80, 34)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(127, 22)
        Me.DtFechaDesde.TabIndex = 392
        Me.DtFechaDesde.Value = New Date(2016, 9, 2, 0, 0, 0, 0)
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(299, 34)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(114, 22)
        Me.DtFechaHasta.TabIndex = 393
        '
        'RbtVentasRel
        '
        Me.RbtVentasRel.AutoSize = True
        Me.RbtVentasRel.Location = New System.Drawing.Point(251, 21)
        Me.RbtVentasRel.Name = "RbtVentasRel"
        Me.RbtVentasRel.Size = New System.Drawing.Size(231, 21)
        Me.RbtVentasRel.TabIndex = 391
        Me.RbtVentasRel.Text = "Detalle con ventas relacionadas"
        Me.RbtVentasRel.UseVisualStyleBackColor = True
        '
        'Rpt_CentroCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 238)
        Me.Controls.Add(Me.DtFechaHasta)
        Me.Controls.Add(Me.DtFechaDesde)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboConcepto)
        Me.Controls.Add(Me.lblDisplayConcepto)
        Me.Controls.Add(Me.lblFecha1)
        Me.Controls.Add(Me.cboCategoria)
        Me.Controls.Add(Me.lblDisplayCategoria)
        Me.Controls.Add(Me.CboCentroCosto)
        Me.Controls.Add(Me.lblDisplayCentroConsto)
        Me.Controls.Add(Me.lblFecha2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_CentroCostos"
        Me.Text = "Reporte de costos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblFecha2 As System.Windows.Forms.Label
    Friend WithEvents CboCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCentroConsto As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCategoria As System.Windows.Forms.Label
    Friend WithEvents lblFecha1 As System.Windows.Forms.Label
    Friend WithEvents cboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents RbtAgrupado As System.Windows.Forms.RadioButton
    Friend WithEvents RbtDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents RbtVentasRel As System.Windows.Forms.RadioButton
End Class
