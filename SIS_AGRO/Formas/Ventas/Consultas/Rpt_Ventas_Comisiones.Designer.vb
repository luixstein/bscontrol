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
        Me.RbtFormatoDetallado = New System.Windows.Forms.RadioButton()
        Me.RbtFormatoGlobal = New System.Windows.Forms.RadioButton()
        Me.txtComision90 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision90 = New System.Windows.Forms.Label()
        Me.txtComision75 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision75 = New System.Windows.Forms.Label()
        Me.txtComisionMas90 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComisionMas90 = New System.Windows.Forms.Label()
        Me.txtComision60 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision60 = New System.Windows.Forms.Label()
        Me.txtComision37 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision37 = New System.Windows.Forms.Label()
        Me.txtComision6 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision6 = New System.Windows.Forms.Label()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(711, 27)
        Me.ToolStrip1.TabIndex = 1
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbtFormatoDetallado)
        Me.GroupBox2.Controls.Add(Me.RbtFormatoGlobal)
        Me.GroupBox2.Controls.Add(Me.txtComision90)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision90)
        Me.GroupBox2.Controls.Add(Me.txtComision75)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision75)
        Me.GroupBox2.Controls.Add(Me.txtComisionMas90)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComisionMas90)
        Me.GroupBox2.Controls.Add(Me.txtComision60)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision60)
        Me.GroupBox2.Controls.Add(Me.txtComision37)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision37)
        Me.GroupBox2.Controls.Add(Me.txtComision6)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision6)
        Me.GroupBox2.Controls.Add(Me.lblVendedor)
        Me.GroupBox2.Controls.Add(Me.cboVendedor)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 37)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(679, 274)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'RbtFormatoDetallado
        '
        Me.RbtFormatoDetallado.AutoSize = True
        Me.RbtFormatoDetallado.Location = New System.Drawing.Point(188, 27)
        Me.RbtFormatoDetallado.Name = "RbtFormatoDetallado"
        Me.RbtFormatoDetallado.Size = New System.Drawing.Size(147, 21)
        Me.RbtFormatoDetallado.TabIndex = 415
        Me.RbtFormatoDetallado.Text = "Detalle de artítulos"
        Me.RbtFormatoDetallado.UseVisualStyleBackColor = True
        '
        'RbtFormatoGlobal
        '
        Me.RbtFormatoGlobal.AutoSize = True
        Me.RbtFormatoGlobal.Checked = True
        Me.RbtFormatoGlobal.Location = New System.Drawing.Point(52, 27)
        Me.RbtFormatoGlobal.Name = "RbtFormatoGlobal"
        Me.RbtFormatoGlobal.Size = New System.Drawing.Size(70, 21)
        Me.RbtFormatoGlobal.TabIndex = 414
        Me.RbtFormatoGlobal.TabStop = True
        Me.RbtFormatoGlobal.Text = "Global"
        Me.RbtFormatoGlobal.UseVisualStyleBackColor = True
        '
        'txtComision90
        '
        Me.txtComision90.Location = New System.Drawing.Point(473, 172)
        Me.txtComision90.Margin = New System.Windows.Forms.Padding(4)
        Me.txtComision90.MaxLength = 8
        Me.txtComision90.Name = "txtComision90"
        Me.txtComision90.Size = New System.Drawing.Size(71, 22)
        Me.txtComision90.TabIndex = 7
        Me.txtComision90.Text = "4"
        Me.txtComision90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision90
        '
        Me.lblDisplayComision90.AutoSize = True
        Me.lblDisplayComision90.Location = New System.Drawing.Point(300, 176)
        Me.lblDisplayComision90.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayComision90.Name = "lblDisplayComision90"
        Me.lblDisplayComision90.Size = New System.Drawing.Size(152, 17)
        Me.lblDisplayComision90.TabIndex = 413
        Me.lblDisplayComision90.Text = "% Comision 76-90 días"
        '
        'txtComision75
        '
        Me.txtComision75.Location = New System.Drawing.Point(473, 140)
        Me.txtComision75.Margin = New System.Windows.Forms.Padding(4)
        Me.txtComision75.MaxLength = 8
        Me.txtComision75.Name = "txtComision75"
        Me.txtComision75.Size = New System.Drawing.Size(71, 22)
        Me.txtComision75.TabIndex = 6
        Me.txtComision75.Text = "6"
        Me.txtComision75.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision75
        '
        Me.lblDisplayComision75.AutoSize = True
        Me.lblDisplayComision75.Location = New System.Drawing.Point(300, 144)
        Me.lblDisplayComision75.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayComision75.Name = "lblDisplayComision75"
        Me.lblDisplayComision75.Size = New System.Drawing.Size(152, 17)
        Me.lblDisplayComision75.TabIndex = 412
        Me.lblDisplayComision75.Text = "% Comision 61-75 días"
        '
        'txtComisionMas90
        '
        Me.txtComisionMas90.Location = New System.Drawing.Point(473, 204)
        Me.txtComisionMas90.Margin = New System.Windows.Forms.Padding(4)
        Me.txtComisionMas90.MaxLength = 8
        Me.txtComisionMas90.Name = "txtComisionMas90"
        Me.txtComisionMas90.Size = New System.Drawing.Size(71, 22)
        Me.txtComisionMas90.TabIndex = 8
        Me.txtComisionMas90.Text = "3"
        Me.txtComisionMas90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComisionMas90
        '
        Me.lblDisplayComisionMas90.AutoSize = True
        Me.lblDisplayComisionMas90.Location = New System.Drawing.Point(300, 208)
        Me.lblDisplayComisionMas90.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayComisionMas90.Name = "lblDisplayComisionMas90"
        Me.lblDisplayComisionMas90.Size = New System.Drawing.Size(161, 17)
        Me.lblDisplayComisionMas90.TabIndex = 409
        Me.lblDisplayComisionMas90.Text = "% Comision más 90 días"
        '
        'txtComision60
        '
        Me.txtComision60.Location = New System.Drawing.Point(188, 201)
        Me.txtComision60.Margin = New System.Windows.Forms.Padding(4)
        Me.txtComision60.MaxLength = 8
        Me.txtComision60.Name = "txtComision60"
        Me.txtComision60.Size = New System.Drawing.Size(71, 22)
        Me.txtComision60.TabIndex = 5
        Me.txtComision60.Text = "8"
        Me.txtComision60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision60
        '
        Me.lblDisplayComision60.AutoSize = True
        Me.lblDisplayComision60.Location = New System.Drawing.Point(15, 204)
        Me.lblDisplayComision60.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayComision60.Name = "lblDisplayComision60"
        Me.lblDisplayComision60.Size = New System.Drawing.Size(152, 17)
        Me.lblDisplayComision60.TabIndex = 407
        Me.lblDisplayComision60.Text = "% Comision 38-60 días"
        '
        'txtComision37
        '
        Me.txtComision37.Location = New System.Drawing.Point(188, 169)
        Me.txtComision37.Margin = New System.Windows.Forms.Padding(4)
        Me.txtComision37.MaxLength = 8
        Me.txtComision37.Name = "txtComision37"
        Me.txtComision37.Size = New System.Drawing.Size(71, 22)
        Me.txtComision37.TabIndex = 4
        Me.txtComision37.Text = "10"
        Me.txtComision37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision37
        '
        Me.lblDisplayComision37.AutoSize = True
        Me.lblDisplayComision37.Location = New System.Drawing.Point(15, 172)
        Me.lblDisplayComision37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayComision37.Name = "lblDisplayComision37"
        Me.lblDisplayComision37.Size = New System.Drawing.Size(144, 17)
        Me.lblDisplayComision37.TabIndex = 405
        Me.lblDisplayComision37.Text = "% Comision 7-37 días"
        '
        'txtComision6
        '
        Me.txtComision6.Location = New System.Drawing.Point(188, 137)
        Me.txtComision6.Margin = New System.Windows.Forms.Padding(4)
        Me.txtComision6.MaxLength = 8
        Me.txtComision6.Name = "txtComision6"
        Me.txtComision6.Size = New System.Drawing.Size(71, 22)
        Me.txtComision6.TabIndex = 3
        Me.txtComision6.Text = "12.5"
        Me.txtComision6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision6
        '
        Me.lblDisplayComision6.AutoSize = True
        Me.lblDisplayComision6.Location = New System.Drawing.Point(15, 140)
        Me.lblDisplayComision6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayComision6.Name = "lblDisplayComision6"
        Me.lblDisplayComision6.Size = New System.Drawing.Size(136, 17)
        Me.lblDisplayComision6.TabIndex = 403
        Me.lblDisplayComision6.Text = "% Comision 0-6 días"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Location = New System.Drawing.Point(15, 106)
        Me.lblVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(78, 17)
        Me.lblVendedor.TabIndex = 401
        Me.lblVendedor.Text = "Vendedor :"
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Items.AddRange(New Object() {"A", "B"})
        Me.cboVendedor.Location = New System.Drawing.Point(136, 103)
        Me.cboVendedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboVendedor.MaxLength = 1
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(289, 24)
        Me.cboVendedor.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(432, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 379
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(553, 53)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaHasta.TabIndex = 1
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(432, 27)
        Me.LblDisplayFechaNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(92, 17)
        Me.LblDisplayFechaNacimiento.TabIndex = 378
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(553, 22)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaDesde.TabIndex = 0
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Rpt_Ventas_Comisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 352)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents txtComision6 As TextBox
    Friend WithEvents lblDisplayComision6 As Label
    Friend WithEvents txtComisionMas90 As TextBox
    Friend WithEvents lblDisplayComisionMas90 As Label
    Friend WithEvents txtComision60 As TextBox
    Friend WithEvents lblDisplayComision60 As Label
    Friend WithEvents txtComision37 As TextBox
    Friend WithEvents lblDisplayComision37 As Label
    Friend WithEvents txtComision90 As TextBox
    Friend WithEvents lblDisplayComision90 As Label
    Friend WithEvents txtComision75 As TextBox
    Friend WithEvents lblDisplayComision75 As Label
    Friend WithEvents RbtFormatoDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents RbtFormatoGlobal As System.Windows.Forms.RadioButton
End Class
