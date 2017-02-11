<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_CXP_SaldosProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_CXP_SaldosProveedores))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RdbDetalleCXP = New System.Windows.Forms.RadioButton
        Me.RdbGlobalCXP = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDisplayProveedor = New System.Windows.Forms.Label
        Me.txtCodicoProveedor = New System.Windows.Forms.TextBox
        Me.lblNombreProveedor = New System.Windows.Forms.Label
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(530, 25)
        Me.ToolStrip1.TabIndex = 17
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RdbDetalleCXP)
        Me.GroupBox2.Controls.Add(Me.RdbGlobalCXP)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 107)
        Me.GroupBox2.TabIndex = 267
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reporte"
        '
        'RdbDetalleCXP
        '
        Me.RdbDetalleCXP.AutoSize = True
        Me.RdbDetalleCXP.Location = New System.Drawing.Point(13, 42)
        Me.RdbDetalleCXP.Name = "RdbDetalleCXP"
        Me.RdbDetalleCXP.Size = New System.Drawing.Size(91, 17)
        Me.RdbDetalleCXP.TabIndex = 266
        Me.RdbDetalleCXP.Text = "Saldos detalle"
        Me.RdbDetalleCXP.UseVisualStyleBackColor = True
        '
        'RdbGlobalCXP
        '
        Me.RdbGlobalCXP.AutoSize = True
        Me.RdbGlobalCXP.Checked = True
        Me.RdbGlobalCXP.Location = New System.Drawing.Point(13, 19)
        Me.RdbGlobalCXP.Name = "RdbGlobalCXP"
        Me.RdbGlobalCXP.Size = New System.Drawing.Size(88, 17)
        Me.RdbGlobalCXP.TabIndex = 265
        Me.RdbGlobalCXP.TabStop = True
        Me.RdbGlobalCXP.Text = "Saldos global"
        Me.RdbGlobalCXP.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDisplayProveedor)
        Me.GroupBox1.Controls.Add(Me.txtCodicoProveedor)
        Me.GroupBox1.Controls.Add(Me.lblNombreProveedor)
        Me.GroupBox1.Location = New System.Drawing.Point(148, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(370, 107)
        Me.GroupBox1.TabIndex = 266
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblDisplayProveedor
        '
        Me.lblDisplayProveedor.AutoSize = True
        Me.lblDisplayProveedor.Location = New System.Drawing.Point(4, 26)
        Me.lblDisplayProveedor.Name = "lblDisplayProveedor"
        Me.lblDisplayProveedor.Size = New System.Drawing.Size(62, 13)
        Me.lblDisplayProveedor.TabIndex = 254
        Me.lblDisplayProveedor.Text = "Proveedor :"
        '
        'txtCodicoProveedor
        '
        Me.txtCodicoProveedor.Location = New System.Drawing.Point(72, 22)
        Me.txtCodicoProveedor.MaxLength = 15
        Me.txtCodicoProveedor.Name = "txtCodicoProveedor"
        Me.txtCodicoProveedor.Size = New System.Drawing.Size(78, 20)
        Me.txtCodicoProveedor.TabIndex = 252
        Me.txtCodicoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.Location = New System.Drawing.Point(165, 26)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreProveedor.TabIndex = 255
        Me.lblNombreProveedor.Text = "."
        '
        'Rpt_CXP_SaldosProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 145)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_CXP_SaldosProveedores"
        Me.Text = "Saldos de proveedores"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbDetalleCXP As System.Windows.Forms.RadioButton
    Friend WithEvents RdbGlobalCXP As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayProveedor As System.Windows.Forms.Label
    Friend WithEvents txtCodicoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreProveedor As System.Windows.Forms.Label
End Class
