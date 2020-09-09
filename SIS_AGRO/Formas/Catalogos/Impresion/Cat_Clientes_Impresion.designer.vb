<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cat_Clientes_Impresion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cat_Clientes_Impresion))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RdbAgrupadoVendedor = New System.Windows.Forms.RadioButton()
        Me.RdbNormal = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CboPlazas = New System.Windows.Forms.ComboBox()
        Me.LblPlaza = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.lblDisplayVendedor = New System.Windows.Forms.Label()
        Me.txtCodigoVendedor = New System.Windows.Forms.TextBox()
        Me.lblNombreVendedor = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(502, 27)
        Me.ToolStrip1.TabIndex = 17
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RdbAgrupadoVendedor)
        Me.GroupBox2.Controls.Add(Me.RdbNormal)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 34)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(485, 61)
        Me.GroupBox2.TabIndex = 267
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Formato"
        '
        'RdbAgrupadoVendedor
        '
        Me.RdbAgrupadoVendedor.AutoSize = True
        Me.RdbAgrupadoVendedor.Checked = True
        Me.RdbAgrupadoVendedor.Location = New System.Drawing.Point(166, 23)
        Me.RdbAgrupadoVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbAgrupadoVendedor.Name = "RdbAgrupadoVendedor"
        Me.RdbAgrupadoVendedor.Size = New System.Drawing.Size(180, 21)
        Me.RdbAgrupadoVendedor.TabIndex = 266
        Me.RdbAgrupadoVendedor.TabStop = True
        Me.RdbAgrupadoVendedor.Text = "Agrupado por vendedor"
        Me.RdbAgrupadoVendedor.UseVisualStyleBackColor = True
        '
        'RdbNormal
        '
        Me.RdbNormal.AutoSize = True
        Me.RdbNormal.Location = New System.Drawing.Point(17, 23)
        Me.RdbNormal.Margin = New System.Windows.Forms.Padding(4)
        Me.RdbNormal.Name = "RdbNormal"
        Me.RdbNormal.Size = New System.Drawing.Size(106, 21)
        Me.RdbNormal.TabIndex = 265
        Me.RdbNormal.Text = "Lista normal"
        Me.RdbNormal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboPlazas)
        Me.GroupBox1.Controls.Add(Me.LblPlaza)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.CboEstatus)
        Me.GroupBox1.Controls.Add(Me.lblDisplayVendedor)
        Me.GroupBox1.Controls.Add(Me.txtCodigoVendedor)
        Me.GroupBox1.Controls.Add(Me.lblNombreVendedor)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 103)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(485, 129)
        Me.GroupBox1.TabIndex = 266
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'CboPlazas
        '
        Me.CboPlazas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPlazas.FormattingEnabled = True
        Me.CboPlazas.Items.AddRange(New Object() {"ACTIVO", "BAJA", "TODOS"})
        Me.CboPlazas.Location = New System.Drawing.Point(321, 26)
        Me.CboPlazas.Name = "CboPlazas"
        Me.CboPlazas.Size = New System.Drawing.Size(121, 24)
        Me.CboPlazas.TabIndex = 259
        '
        'LblPlaza
        '
        Me.LblPlaza.AutoSize = True
        Me.LblPlaza.Location = New System.Drawing.Point(265, 29)
        Me.LblPlaza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPlaza.Name = "LblPlaza"
        Me.LblPlaza.Size = New System.Drawing.Size(51, 17)
        Me.LblPlaza.TabIndex = 258
        Me.LblPlaza.Text = "Plaza :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(14, 29)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 257
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA", "TODOS"})
        Me.CboEstatus.Location = New System.Drawing.Point(93, 26)
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(121, 24)
        Me.CboEstatus.TabIndex = 256
        '
        'lblDisplayVendedor
        '
        Me.lblDisplayVendedor.AutoSize = True
        Me.lblDisplayVendedor.Location = New System.Drawing.Point(7, 78)
        Me.lblDisplayVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayVendedor.Name = "lblDisplayVendedor"
        Me.lblDisplayVendedor.Size = New System.Drawing.Size(78, 17)
        Me.lblDisplayVendedor.TabIndex = 254
        Me.lblDisplayVendedor.Text = "Vendedor :"
        '
        'txtCodigoVendedor
        '
        Me.txtCodigoVendedor.Location = New System.Drawing.Point(93, 75)
        Me.txtCodigoVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoVendedor.MaxLength = 15
        Me.txtCodigoVendedor.Name = "txtCodigoVendedor"
        Me.txtCodigoVendedor.Size = New System.Drawing.Size(103, 22)
        Me.txtCodigoVendedor.TabIndex = 252
        Me.txtCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreVendedor
        '
        Me.lblNombreVendedor.AutoSize = True
        Me.lblNombreVendedor.Location = New System.Drawing.Point(219, 80)
        Me.lblNombreVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreVendedor.Name = "lblNombreVendedor"
        Me.lblNombreVendedor.Size = New System.Drawing.Size(12, 17)
        Me.lblNombreVendedor.TabIndex = 255
        Me.lblNombreVendedor.Text = "."
        '
        'Cat_Clientes_Impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 245)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Cat_Clientes_Impresion"
        Me.ShowIcon = False
        Me.Text = "Impresión de catalogo de clientes"
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
    Friend WithEvents RdbAgrupadoVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents RdbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreVendedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayVendedor As System.Windows.Forms.Label
    Friend WithEvents txtCodigoVendedor As System.Windows.Forms.TextBox
    Friend WithEvents CboPlazas As System.Windows.Forms.ComboBox
    Friend WithEvents LblPlaza As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
End Class
