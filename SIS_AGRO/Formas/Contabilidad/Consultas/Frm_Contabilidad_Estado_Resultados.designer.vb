<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Estado_Resultados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Estado_Resultados))
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.CmbPeriodo2 = New System.Windows.Forms.ComboBox
        Me.LblPeriodo2 = New System.Windows.Forms.Label
        Me.CmbPeriodo1 = New System.Windows.Forms.ComboBox
        Me.LblPeriodo1 = New System.Windows.Forms.Label
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(8, 53)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 223
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(482, 25)
        Me.ToolStrip1.TabIndex = 215
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'CmbPeriodo2
        '
        Me.CmbPeriodo2.DisplayMember = "1"
        Me.CmbPeriodo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPeriodo2.FormattingEnabled = True
        Me.CmbPeriodo2.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.CmbPeriodo2.Location = New System.Drawing.Point(306, 77)
        Me.CmbPeriodo2.Name = "CmbPeriodo2"
        Me.CmbPeriodo2.Size = New System.Drawing.Size(135, 21)
        Me.CmbPeriodo2.TabIndex = 227
        '
        'LblPeriodo2
        '
        Me.LblPeriodo2.AutoSize = True
        Me.LblPeriodo2.Location = New System.Drawing.Point(234, 81)
        Me.LblPeriodo2.Name = "LblPeriodo2"
        Me.LblPeriodo2.Size = New System.Drawing.Size(60, 13)
        Me.LblPeriodo2.TabIndex = 229
        Me.LblPeriodo2.Text = "Al periodo :"
        '
        'CmbPeriodo1
        '
        Me.CmbPeriodo1.DisplayMember = "1"
        Me.CmbPeriodo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPeriodo1.FormattingEnabled = True
        Me.CmbPeriodo1.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "CIERRE"})
        Me.CmbPeriodo1.Location = New System.Drawing.Point(86, 77)
        Me.CmbPeriodo1.Name = "CmbPeriodo1"
        Me.CmbPeriodo1.Size = New System.Drawing.Size(135, 21)
        Me.CmbPeriodo1.TabIndex = 226
        '
        'LblPeriodo1
        '
        Me.LblPeriodo1.AutoSize = True
        Me.LblPeriodo1.Location = New System.Drawing.Point(9, 81)
        Me.LblPeriodo1.Name = "LblPeriodo1"
        Me.LblPeriodo1.Size = New System.Drawing.Size(65, 13)
        Me.LblPeriodo1.TabIndex = 228
        Me.LblPeriodo1.Text = "del periodo :"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(86, 49)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio.TabIndex = 230
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
        'Frm_Contabilidad_Estado_Resultados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 174)
        Me.Controls.Add(Me.CmbEjercicio)
        Me.Controls.Add(Me.CmbPeriodo2)
        Me.Controls.Add(Me.LblPeriodo2)
        Me.Controls.Add(Me.CmbPeriodo1)
        Me.Controls.Add(Me.LblPeriodo1)
        Me.Controls.Add(Me.LblEjercicio)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frm_Contabilidad_Estado_Resultados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de resultados"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CmbPeriodo2 As System.Windows.Forms.ComboBox
    Friend WithEvents LblPeriodo2 As System.Windows.Forms.Label
    Friend WithEvents CmbPeriodo1 As System.Windows.Forms.ComboBox
    Friend WithEvents LblPeriodo1 As System.Windows.Forms.Label
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
End Class
