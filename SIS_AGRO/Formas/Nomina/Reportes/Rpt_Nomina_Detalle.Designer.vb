<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Nomina_Detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Nomina_Detalle))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblDisplayProductor = New System.Windows.Forms.Label()
        Me.cboSemana1 = New System.Windows.Forms.ComboBox()
        Me.CboCentroCosto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCentroConsto = New System.Windows.Forms.Label()
        Me.cboConceptoActividad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSemana2 = New System.Windows.Forms.ComboBox()
        Me.cboTemporada = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTemporada = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSubactividad = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(460, 25)
        Me.ToolStrip1.TabIndex = 6
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
        'lblDisplayProductor
        '
        Me.lblDisplayProductor.AutoSize = True
        Me.lblDisplayProductor.Location = New System.Drawing.Point(12, 73)
        Me.lblDisplayProductor.Name = "lblDisplayProductor"
        Me.lblDisplayProductor.Size = New System.Drawing.Size(78, 13)
        Me.lblDisplayProductor.TabIndex = 361
        Me.lblDisplayProductor.Text = "De la semana :"
        '
        'cboSemana1
        '
        Me.cboSemana1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSemana1.FormattingEnabled = True
        Me.cboSemana1.Location = New System.Drawing.Point(123, 70)
        Me.cboSemana1.Name = "cboSemana1"
        Me.cboSemana1.Size = New System.Drawing.Size(50, 21)
        Me.cboSemana1.TabIndex = 1
        '
        'CboCentroCosto
        '
        Me.CboCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCentroCosto.FormattingEnabled = True
        Me.CboCentroCosto.Location = New System.Drawing.Point(123, 126)
        Me.CboCentroCosto.Name = "CboCentroCosto"
        Me.CboCentroCosto.Size = New System.Drawing.Size(325, 21)
        Me.CboCentroCosto.TabIndex = 3
        '
        'lblDisplayCentroConsto
        '
        Me.lblDisplayCentroConsto.AutoSize = True
        Me.lblDisplayCentroConsto.Location = New System.Drawing.Point(12, 129)
        Me.lblDisplayCentroConsto.Name = "lblDisplayCentroConsto"
        Me.lblDisplayCentroConsto.Size = New System.Drawing.Size(88, 13)
        Me.lblDisplayCentroConsto.TabIndex = 363
        Me.lblDisplayCentroConsto.Text = "Centro de costo :"
        '
        'cboConceptoActividad
        '
        Me.cboConceptoActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConceptoActividad.FormattingEnabled = True
        Me.cboConceptoActividad.Location = New System.Drawing.Point(123, 154)
        Me.cboConceptoActividad.Name = "cboConceptoActividad"
        Me.cboConceptoActividad.Size = New System.Drawing.Size(325, 21)
        Me.cboConceptoActividad.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 382
        Me.Label1.Text = "Concepto actividad :"
        '
        'cboSemana2
        '
        Me.cboSemana2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSemana2.FormattingEnabled = True
        Me.cboSemana2.Location = New System.Drawing.Point(123, 99)
        Me.cboSemana2.Name = "cboSemana2"
        Me.cboSemana2.Size = New System.Drawing.Size(50, 21)
        Me.cboSemana2.TabIndex = 2
        '
        'cboTemporada
        '
        Me.cboTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemporada.FormattingEnabled = True
        Me.cboTemporada.Location = New System.Drawing.Point(123, 43)
        Me.cboTemporada.Name = "cboTemporada"
        Me.cboTemporada.Size = New System.Drawing.Size(242, 21)
        Me.cboTemporada.TabIndex = 0
        Me.cboTemporada.Visible = False
        '
        'lblDisplayTemporada
        '
        Me.lblDisplayTemporada.AutoSize = True
        Me.lblDisplayTemporada.Location = New System.Drawing.Point(12, 46)
        Me.lblDisplayTemporada.Name = "lblDisplayTemporada"
        Me.lblDisplayTemporada.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayTemporada.TabIndex = 385
        Me.lblDisplayTemporada.Text = "Temporada :"
        Me.lblDisplayTemporada.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 386
        Me.Label3.Text = "A la semana :"
        '
        'cboSubactividad
        '
        Me.cboSubactividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubactividad.FormattingEnabled = True
        Me.cboSubactividad.Location = New System.Drawing.Point(123, 181)
        Me.cboSubactividad.Name = "cboSubactividad"
        Me.cboSubactividad.Size = New System.Drawing.Size(325, 21)
        Me.cboSubactividad.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "Subactividad :"
        '
        'Rpt_Nomina_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 262)
        Me.Controls.Add(Me.cboSubactividad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTemporada)
        Me.Controls.Add(Me.lblDisplayTemporada)
        Me.Controls.Add(Me.cboSemana2)
        Me.Controls.Add(Me.cboConceptoActividad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboCentroCosto)
        Me.Controls.Add(Me.lblDisplayCentroConsto)
        Me.Controls.Add(Me.lblDisplayProductor)
        Me.Controls.Add(Me.cboSemana1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Nomina_Detalle"
        Me.Text = "Nómina detalle"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDisplayProductor As System.Windows.Forms.Label
    Friend WithEvents cboSemana1 As System.Windows.Forms.ComboBox
    Friend WithEvents CboCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCentroConsto As System.Windows.Forms.Label
    Friend WithEvents cboConceptoActividad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSemana2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTemporada As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTemporada As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSubactividad As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
