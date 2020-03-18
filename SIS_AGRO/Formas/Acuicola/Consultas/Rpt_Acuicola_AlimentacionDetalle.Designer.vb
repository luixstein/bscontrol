<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Acuicola_AlimentacionDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Acuicola_AlimentacionDetalle))
        Me.DtFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha1 = New System.Windows.Forms.Label()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.LblDivision = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DtFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha2 = New System.Windows.Forms.Label()
        Me.CkbCiclo = New System.Windows.Forms.CheckBox()
        Me.gbCiclo = New System.Windows.Forms.GroupBox()
        Me.CboLote = New System.Windows.Forms.ComboBox()
        Me.LblEstanque = New System.Windows.Forms.Label()
        Me.CboDivision = New System.Windows.Forms.ComboBox()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GroupBox2.SuspendLayout()
        Me.gbCiclo.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtFecha1
        '
        Me.DtFecha1.Location = New System.Drawing.Point(440, 25)
        Me.DtFecha1.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFecha1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFecha1.Name = "DtFecha1"
        Me.DtFecha1.Size = New System.Drawing.Size(266, 22)
        Me.DtFecha1.TabIndex = 3
        '
        'LblFecha1
        '
        Me.LblFecha1.AutoSize = True
        Me.LblFecha1.Location = New System.Drawing.Point(375, 28)
        Me.LblFecha1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha1.Name = "LblFecha1"
        Me.LblFecha1.Size = New System.Drawing.Size(57, 17)
        Me.LblFecha1.TabIndex = 299
        Me.LblFecha1.Text = "Desde :"
        '
        'txtCiclo
        '
        Me.txtCiclo.Location = New System.Drawing.Point(22, 22)
        Me.txtCiclo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCiclo.MaxLength = 8
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(95, 22)
        Me.txtCiclo.TabIndex = 0
        '
        'LblDivision
        '
        Me.LblDivision.AutoSize = True
        Me.LblDivision.Location = New System.Drawing.Point(8, 28)
        Me.LblDivision.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDivision.Name = "LblDivision"
        Me.LblDivision.Size = New System.Drawing.Size(65, 17)
        Me.LblDivision.TabIndex = 309
        Me.LblDivision.Text = "División :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DtFecha2)
        Me.GroupBox2.Controls.Add(Me.LblFecha2)
        Me.GroupBox2.Controls.Add(Me.CkbCiclo)
        Me.GroupBox2.Controls.Add(Me.gbCiclo)
        Me.GroupBox2.Controls.Add(Me.CboLote)
        Me.GroupBox2.Controls.Add(Me.LblEstanque)
        Me.GroupBox2.Controls.Add(Me.CboDivision)
        Me.GroupBox2.Controls.Add(Me.LblFecha1)
        Me.GroupBox2.Controls.Add(Me.DtFecha1)
        Me.GroupBox2.Controls.Add(Me.LblDivision)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 34)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(729, 191)
        Me.GroupBox2.TabIndex = 311
        Me.GroupBox2.TabStop = False
        '
        'DtFecha2
        '
        Me.DtFecha2.Location = New System.Drawing.Point(440, 72)
        Me.DtFecha2.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFecha2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFecha2.Name = "DtFecha2"
        Me.DtFecha2.Size = New System.Drawing.Size(266, 22)
        Me.DtFecha2.TabIndex = 4
        '
        'LblFecha2
        '
        Me.LblFecha2.AutoSize = True
        Me.LblFecha2.Location = New System.Drawing.Point(375, 77)
        Me.LblFecha2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha2.Name = "LblFecha2"
        Me.LblFecha2.Size = New System.Drawing.Size(53, 17)
        Me.LblFecha2.TabIndex = 316
        Me.LblFecha2.Text = "Hasta :"
        '
        'CkbCiclo
        '
        Me.CkbCiclo.AutoSize = True
        Me.CkbCiclo.Checked = True
        Me.CkbCiclo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkbCiclo.Location = New System.Drawing.Point(184, 135)
        Me.CkbCiclo.Name = "CkbCiclo"
        Me.CkbCiclo.Size = New System.Drawing.Size(123, 21)
        Me.CkbCiclo.TabIndex = 315
        Me.CkbCiclo.Text = "Filtrar por ciclo"
        Me.CkbCiclo.UseVisualStyleBackColor = True
        '
        'gbCiclo
        '
        Me.gbCiclo.Controls.Add(Me.txtCiclo)
        Me.gbCiclo.Location = New System.Drawing.Point(11, 112)
        Me.gbCiclo.Name = "gbCiclo"
        Me.gbCiclo.Size = New System.Drawing.Size(157, 53)
        Me.gbCiclo.TabIndex = 2
        Me.gbCiclo.TabStop = False
        Me.gbCiclo.Text = "Ciclo"
        '
        'CboLote
        '
        Me.CboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLote.FormattingEnabled = True
        Me.CboLote.Location = New System.Drawing.Point(81, 69)
        Me.CboLote.Margin = New System.Windows.Forms.Padding(4)
        Me.CboLote.Name = "CboLote"
        Me.CboLote.Size = New System.Drawing.Size(244, 24)
        Me.CboLote.TabIndex = 1
        '
        'LblEstanque
        '
        Me.LblEstanque.AutoSize = True
        Me.LblEstanque.Location = New System.Drawing.Point(8, 72)
        Me.LblEstanque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstanque.Name = "LblEstanque"
        Me.LblEstanque.Size = New System.Drawing.Size(76, 17)
        Me.LblEstanque.TabIndex = 312
        Me.LblEstanque.Text = "Estanque :"
        '
        'CboDivision
        '
        Me.CboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDivision.FormattingEnabled = True
        Me.CboDivision.Location = New System.Drawing.Point(81, 25)
        Me.CboDivision.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDivision.Name = "CboDivision"
        Me.CboDivision.Size = New System.Drawing.Size(244, 24)
        Me.CboDivision.TabIndex = 0
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
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(765, 27)
        Me.ToolStrip1.TabIndex = 312
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Rpt_Acuicola_AlimentacionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 243)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Acuicola_AlimentacionDetalle"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acuicola - Alimentación detalle"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbCiclo.ResumeLayout(False)
        Me.gbCiclo.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha1 As System.Windows.Forms.Label
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents LblDivision As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CboDivision As System.Windows.Forms.ComboBox
    Friend WithEvents CkbCiclo As System.Windows.Forms.CheckBox
    Friend WithEvents gbCiclo As System.Windows.Forms.GroupBox
    Friend WithEvents CboLote As System.Windows.Forms.ComboBox
    Friend WithEvents LblEstanque As System.Windows.Forms.Label
    Friend WithEvents LblFecha2 As System.Windows.Forms.Label
    Friend WithEvents DtFecha2 As System.Windows.Forms.DateTimePicker
End Class
