<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Imprimir_Embarques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Imprimir_Embarques))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RdbManifiestoAduana = New System.Windows.Forms.RadioButton
        Me.RdbManifiestoEmbarque = New System.Windows.Forms.RadioButton
        Me.RdbFactura = New System.Windows.Forms.RadioButton
        Me.RdbCartaRespectiva = New System.Windows.Forms.RadioButton
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(263, 25)
        Me.tsMenu.TabIndex = 5
        Me.tsMenu.Text = "tsMenu"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(73, 22)
        Me.ToolStripButton1.Text = "&Imprimir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdbManifiestoAduana)
        Me.GroupBox1.Controls.Add(Me.RdbManifiestoEmbarque)
        Me.GroupBox1.Controls.Add(Me.RdbFactura)
        Me.GroupBox1.Controls.Add(Me.RdbCartaRespectiva)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 150)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Formato"
        '
        'RdbManifiestoAduana
        '
        Me.RdbManifiestoAduana.AutoSize = True
        Me.RdbManifiestoAduana.Location = New System.Drawing.Point(22, 108)
        Me.RdbManifiestoAduana.Name = "RdbManifiestoAduana"
        Me.RdbManifiestoAduana.Size = New System.Drawing.Size(127, 17)
        Me.RdbManifiestoAduana.TabIndex = 3
        Me.RdbManifiestoAduana.TabStop = True
        Me.RdbManifiestoAduana.Text = "Manifiesto de aduana"
        Me.RdbManifiestoAduana.UseVisualStyleBackColor = True
        '
        'RdbManifiestoEmbarque
        '
        Me.RdbManifiestoEmbarque.AutoSize = True
        Me.RdbManifiestoEmbarque.Location = New System.Drawing.Point(22, 83)
        Me.RdbManifiestoEmbarque.Name = "RdbManifiestoEmbarque"
        Me.RdbManifiestoEmbarque.Size = New System.Drawing.Size(138, 17)
        Me.RdbManifiestoEmbarque.TabIndex = 2
        Me.RdbManifiestoEmbarque.TabStop = True
        Me.RdbManifiestoEmbarque.Text = "Manifiesto de embarque"
        Me.RdbManifiestoEmbarque.UseVisualStyleBackColor = True
        '
        'RdbFactura
        '
        Me.RdbFactura.AutoSize = True
        Me.RdbFactura.Location = New System.Drawing.Point(22, 58)
        Me.RdbFactura.Name = "RdbFactura"
        Me.RdbFactura.Size = New System.Drawing.Size(61, 17)
        Me.RdbFactura.TabIndex = 1
        Me.RdbFactura.TabStop = True
        Me.RdbFactura.Text = "Factura"
        Me.RdbFactura.UseVisualStyleBackColor = True
        '
        'RdbCartaRespectiva
        '
        Me.RdbCartaRespectiva.AutoSize = True
        Me.RdbCartaRespectiva.Location = New System.Drawing.Point(22, 33)
        Me.RdbCartaRespectiva.Name = "RdbCartaRespectiva"
        Me.RdbCartaRespectiva.Size = New System.Drawing.Size(104, 17)
        Me.RdbCartaRespectiva.TabIndex = 0
        Me.RdbCartaRespectiva.TabStop = True
        Me.RdbCartaRespectiva.Text = "Carta responsiva"
        Me.RdbCartaRespectiva.UseVisualStyleBackColor = True
        '
        'Frm_Imprimir_Embarques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 185)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Imprimir_Embarques"
        Me.Text = "Imprimir embarques"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbFactura As System.Windows.Forms.RadioButton
    Friend WithEvents RdbCartaRespectiva As System.Windows.Forms.RadioButton
    Friend WithEvents RdbManifiestoAduana As System.Windows.Forms.RadioButton
    Friend WithEvents RdbManifiestoEmbarque As System.Windows.Forms.RadioButton
End Class
