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
        Me.txtComisionMas60 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComisionMas60 = New System.Windows.Forms.Label()
        Me.txtComision60 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision60 = New System.Windows.Forms.Label()
        Me.txtComision30 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision30 = New System.Windows.Forms.Label()
        Me.txtComision15 = New System.Windows.Forms.TextBox()
        Me.lblDisplayComision15 = New System.Windows.Forms.Label()
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
        Me.GroupBox2.Controls.Add(Me.txtComisionMas60)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComisionMas60)
        Me.GroupBox2.Controls.Add(Me.txtComision60)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision60)
        Me.GroupBox2.Controls.Add(Me.txtComision30)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision30)
        Me.GroupBox2.Controls.Add(Me.txtComision15)
        Me.GroupBox2.Controls.Add(Me.lblDisplayComision15)
        Me.GroupBox2.Controls.Add(Me.lblVendedor)
        Me.GroupBox2.Controls.Add(Me.cboVendedor)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 223)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'txtComisionMas60
        '
        Me.txtComisionMas60.Location = New System.Drawing.Point(141, 189)
        Me.txtComisionMas60.MaxLength = 8
        Me.txtComisionMas60.Name = "txtComisionMas60"
        Me.txtComisionMas60.Size = New System.Drawing.Size(54, 20)
        Me.txtComisionMas60.TabIndex = 6
        Me.txtComisionMas60.Text = "5"
        Me.txtComisionMas60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComisionMas60
        '
        Me.lblDisplayComisionMas60.AutoSize = True
        Me.lblDisplayComisionMas60.Location = New System.Drawing.Point(11, 192)
        Me.lblDisplayComisionMas60.Name = "lblDisplayComisionMas60"
        Me.lblDisplayComisionMas60.Size = New System.Drawing.Size(121, 13)
        Me.lblDisplayComisionMas60.TabIndex = 409
        Me.lblDisplayComisionMas60.Text = "% Comision más 60 días"
        '
        'txtComision60
        '
        Me.txtComision60.Location = New System.Drawing.Point(141, 163)
        Me.txtComision60.MaxLength = 8
        Me.txtComision60.Name = "txtComision60"
        Me.txtComision60.Size = New System.Drawing.Size(54, 20)
        Me.txtComision60.TabIndex = 5
        Me.txtComision60.Text = "7.5"
        Me.txtComision60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision60
        '
        Me.lblDisplayComision60.AutoSize = True
        Me.lblDisplayComision60.Location = New System.Drawing.Point(11, 166)
        Me.lblDisplayComision60.Name = "lblDisplayComision60"
        Me.lblDisplayComision60.Size = New System.Drawing.Size(114, 13)
        Me.lblDisplayComision60.TabIndex = 407
        Me.lblDisplayComision60.Text = "% Comision 31-60 días"
        '
        'txtComision30
        '
        Me.txtComision30.Location = New System.Drawing.Point(141, 137)
        Me.txtComision30.MaxLength = 8
        Me.txtComision30.Name = "txtComision30"
        Me.txtComision30.Size = New System.Drawing.Size(54, 20)
        Me.txtComision30.TabIndex = 4
        Me.txtComision30.Text = "10"
        Me.txtComision30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision30
        '
        Me.lblDisplayComision30.AutoSize = True
        Me.lblDisplayComision30.Location = New System.Drawing.Point(11, 140)
        Me.lblDisplayComision30.Name = "lblDisplayComision30"
        Me.lblDisplayComision30.Size = New System.Drawing.Size(114, 13)
        Me.lblDisplayComision30.TabIndex = 405
        Me.lblDisplayComision30.Text = "% Comision 16-30 días"
        '
        'txtComision15
        '
        Me.txtComision15.Location = New System.Drawing.Point(141, 111)
        Me.txtComision15.MaxLength = 8
        Me.txtComision15.Name = "txtComision15"
        Me.txtComision15.Size = New System.Drawing.Size(54, 20)
        Me.txtComision15.TabIndex = 3
        Me.txtComision15.Text = "12.5"
        Me.txtComision15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayComision15
        '
        Me.lblDisplayComision15.AutoSize = True
        Me.lblDisplayComision15.Location = New System.Drawing.Point(11, 114)
        Me.lblDisplayComision15.Name = "lblDisplayComision15"
        Me.lblDisplayComision15.Size = New System.Drawing.Size(108, 13)
        Me.lblDisplayComision15.TabIndex = 403
        Me.lblDisplayComision15.Text = "% Comision 0-15 días"
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
        Me.ClientSize = New System.Drawing.Size(533, 286)
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
    Friend WithEvents txtComision15 As TextBox
    Friend WithEvents lblDisplayComision15 As Label
    Friend WithEvents txtComisionMas60 As TextBox
    Friend WithEvents lblDisplayComisionMas60 As Label
    Friend WithEvents txtComision60 As TextBox
    Friend WithEvents lblDisplayComision60 As Label
    Friend WithEvents txtComision30 As TextBox
    Friend WithEvents lblDisplayComision30 As Label
End Class
