<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Cxp_Auxiliar_proveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Cxp_Auxiliar_proveedor))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblProveedor = New System.Windows.Forms.Label()
        Me.LblDisplayCodigoProveedor = New System.Windows.Forms.Label()
        Me.TxtProveedor = New System.Windows.Forms.TextBox()
        Me.rbtAuxiliarSaldos = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisisSaldos = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(570, 27)
        Me.ToolStrip1.TabIndex = 7
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtAnalisisSaldos)
        Me.GroupBox1.Controls.Add(Me.rbtAuxiliarSaldos)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.LblProveedor)
        Me.GroupBox1.Controls.Add(Me.LblDisplayCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(534, 138)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(257, 105)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 17)
        Me.Label1.TabIndex = 225
        Me.Label1.Text = "Hasta la fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(379, 99)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaHasta.TabIndex = 3
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(8, 105)
        Me.LblDisplayFechaNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(88, 17)
        Me.LblDisplayFechaNacimiento.TabIndex = 224
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(111, 99)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(117, 22)
        Me.DtFechaDesde.TabIndex = 2
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblProveedor
        '
        Me.LblProveedor.Location = New System.Drawing.Point(107, 58)
        Me.LblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(461, 16)
        Me.LblProveedor.TabIndex = 104
        Me.LblProveedor.Text = "."
        '
        'LblDisplayCodigoProveedor
        '
        Me.LblDisplayCodigoProveedor.AutoSize = True
        Me.LblDisplayCodigoProveedor.Location = New System.Drawing.Point(8, 33)
        Me.LblDisplayCodigoProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodigoProveedor.Name = "LblDisplayCodigoProveedor"
        Me.LblDisplayCodigoProveedor.Size = New System.Drawing.Size(82, 17)
        Me.LblDisplayCodigoProveedor.TabIndex = 10
        Me.LblDisplayCodigoProveedor.Text = "Proveedor :"
        '
        'TxtProveedor
        '
        Me.TxtProveedor.Location = New System.Drawing.Point(111, 30)
        Me.TxtProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtProveedor.MaxLength = 8
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(73, 22)
        Me.TxtProveedor.TabIndex = 1
        '
        'rbtAuxiliarSaldos
        '
        Me.rbtAuxiliarSaldos.AutoSize = True
        Me.rbtAuxiliarSaldos.Checked = True
        Me.rbtAuxiliarSaldos.Location = New System.Drawing.Point(379, 22)
        Me.rbtAuxiliarSaldos.Name = "rbtAuxiliarSaldos"
        Me.rbtAuxiliarSaldos.Size = New System.Drawing.Size(119, 21)
        Me.rbtAuxiliarSaldos.TabIndex = 226
        Me.rbtAuxiliarSaldos.TabStop = True
        Me.rbtAuxiliarSaldos.Text = "Auxiliar saldos"
        Me.rbtAuxiliarSaldos.UseVisualStyleBackColor = True
        '
        'rbtAnalisisSaldos
        '
        Me.rbtAnalisisSaldos.AutoSize = True
        Me.rbtAnalisisSaldos.Location = New System.Drawing.Point(379, 58)
        Me.rbtAnalisisSaldos.Name = "rbtAnalisisSaldos"
        Me.rbtAnalisisSaldos.Size = New System.Drawing.Size(122, 21)
        Me.rbtAnalisisSaldos.TabIndex = 227
        Me.rbtAnalisisSaldos.Text = "Analisis saldos"
        Me.rbtAnalisisSaldos.UseVisualStyleBackColor = True
        '
        'Rpt_Cxp_Auxiliar_proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 185)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Cxp_Auxiliar_proveedor"
        Me.Text = "Auxiliar proveedor"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblProveedor As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodigoProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents rbtAnalisisSaldos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAuxiliarSaldos As System.Windows.Forms.RadioButton
End Class
