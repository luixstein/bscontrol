<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Ventas_Comisiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Ventas_Comisiones))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPtjeComision = New System.Windows.Forms.TextBox()
        Me.lblDisplayPtjeComision = New System.Windows.Forms.Label()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(533, 27)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(82, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPtjeComision)
        Me.GroupBox2.Controls.Add(Me.lblDisplayPtjeComision)
        Me.GroupBox2.Controls.Add(Me.lblVendedor)
        Me.GroupBox2.Controls.Add(Me.cboVendedor)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 143)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'txtPtjeComision
        '
        Me.txtPtjeComision.Location = New System.Drawing.Point(102, 111)
        Me.txtPtjeComision.MaxLength = 8
        Me.txtPtjeComision.Name = "txtPtjeComision"
        Me.txtPtjeComision.Size = New System.Drawing.Size(54, 20)
        Me.txtPtjeComision.TabIndex = 3
        Me.txtPtjeComision.Text = "10"
        Me.txtPtjeComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayPtjeComision
        '
        Me.lblDisplayPtjeComision.AutoSize = True
        Me.lblDisplayPtjeComision.Location = New System.Drawing.Point(11, 114)
        Me.lblDisplayPtjeComision.Name = "lblDisplayPtjeComision"
        Me.lblDisplayPtjeComision.Size = New System.Drawing.Size(60, 13)
        Me.lblDisplayPtjeComision.TabIndex = 403
        Me.lblDisplayPtjeComision.Text = "% Comision"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Location = New System.Drawing.Point(11, 86)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(59, 13)
        Me.lblVendedor.TabIndex = 401
        Me.lblVendedor.Text = "Vendedor :"
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Items.AddRange(New Object() {"A", "B"})
        Me.cboVendedor.Location = New System.Drawing.Point(102, 84)
        Me.cboVendedor.MaxLength = 1
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(218, 21)
        Me.cboVendedor.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(324, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 379
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(415, 43)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaHasta.TabIndex = 1
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(324, 22)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 378
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(415, 18)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaDesde.TabIndex = 0
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Rpt_Ventas_Comisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 190)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Ventas_Comisiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporte comisiones de ventas."
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbConsultar As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblVendedor As Label
    Friend WithEvents cboVendedor As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DtFechaHasta As DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As Label
    Friend WithEvents DtFechaDesde As DateTimePicker
    Friend WithEvents txtPtjeComision As TextBox
    Friend WithEvents lblDisplayPtjeComision As Label
End Class
