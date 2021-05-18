<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Ventas_Calificas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Ventas_Calificas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdnCalificaProductoFlujo = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblDisplayZona = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTop = New System.Windows.Forms.TextBox()
        Me.lblDisplayTop = New System.Windows.Forms.Label()
        Me.lblNombreZona = New System.Windows.Forms.Label()
        Me.txtCodigoZona = New System.Windows.Forms.TextBox()
        Me.lblNombreArticulo = New System.Windows.Forms.Label()
        Me.txtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.lblDisplayArticulo = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdnCalificaProductoFlujo)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 64)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'rdnCalificaProductoFlujo
        '
        Me.rdnCalificaProductoFlujo.AutoSize = True
        Me.rdnCalificaProductoFlujo.Checked = True
        Me.rdnCalificaProductoFlujo.Location = New System.Drawing.Point(16, 22)
        Me.rdnCalificaProductoFlujo.Name = "rdnCalificaProductoFlujo"
        Me.rdnCalificaProductoFlujo.Size = New System.Drawing.Size(126, 17)
        Me.rdnCalificaProductoFlujo.TabIndex = 0
        Me.rdnCalificaProductoFlujo.TabStop = True
        Me.rdnCalificaProductoFlujo.Text = "Califica producto flujo"
        Me.rdnCalificaProductoFlujo.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(723, 27)
        Me.ToolStrip1.TabIndex = 2
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
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(97, 18)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaDesde.TabIndex = 4
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(6, 22)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 378
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(97, 43)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaHasta.TabIndex = 5
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 379
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(6, 101)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 382
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(65, 98)
        Me.txtCliente.MaxLength = 8
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(72, 20)
        Me.txtCliente.TabIndex = 0
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(155, 101)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(348, 17)
        Me.lblNombreCliente.TabIndex = 383
        Me.lblNombreCliente.Text = "_"
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(6, 127)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 393
        Me.lblDisplayZona.Text = "Zona :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTop)
        Me.GroupBox2.Controls.Add(Me.lblDisplayTop)
        Me.GroupBox2.Controls.Add(Me.lblNombreZona)
        Me.GroupBox2.Controls.Add(Me.txtCodigoZona)
        Me.GroupBox2.Controls.Add(Me.lblNombreArticulo)
        Me.GroupBox2.Controls.Add(Me.txtCodigoArticulo)
        Me.GroupBox2.Controls.Add(Me.lblDisplayArticulo)
        Me.GroupBox2.Controls.Add(Me.lblDisplayZona)
        Me.GroupBox2.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Location = New System.Drawing.Point(210, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 212)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'txtTop
        '
        Me.txtTop.Location = New System.Drawing.Point(65, 176)
        Me.txtTop.MaxLength = 3
        Me.txtTop.Name = "txtTop"
        Me.txtTop.Size = New System.Drawing.Size(72, 20)
        Me.txtTop.TabIndex = 3
        Me.txtTop.Text = "0"
        Me.txtTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTop
        '
        Me.lblDisplayTop.AutoSize = True
        Me.lblDisplayTop.Location = New System.Drawing.Point(6, 179)
        Me.lblDisplayTop.Name = "lblDisplayTop"
        Me.lblDisplayTop.Size = New System.Drawing.Size(32, 13)
        Me.lblDisplayTop.TabIndex = 403
        Me.lblDisplayTop.Text = "Top :"
        '
        'lblNombreZona
        '
        Me.lblNombreZona.Location = New System.Drawing.Point(155, 127)
        Me.lblNombreZona.Name = "lblNombreZona"
        Me.lblNombreZona.Size = New System.Drawing.Size(348, 17)
        Me.lblNombreZona.TabIndex = 401
        Me.lblNombreZona.Text = "_"
        '
        'txtCodigoZona
        '
        Me.txtCodigoZona.Location = New System.Drawing.Point(65, 124)
        Me.txtCodigoZona.MaxLength = 2
        Me.txtCodigoZona.Name = "txtCodigoZona"
        Me.txtCodigoZona.Size = New System.Drawing.Size(72, 20)
        Me.txtCodigoZona.TabIndex = 1
        '
        'lblNombreArticulo
        '
        Me.lblNombreArticulo.Location = New System.Drawing.Point(155, 153)
        Me.lblNombreArticulo.Name = "lblNombreArticulo"
        Me.lblNombreArticulo.Size = New System.Drawing.Size(325, 17)
        Me.lblNombreArticulo.TabIndex = 399
        Me.lblNombreArticulo.Text = "_"
        '
        'txtCodigoArticulo
        '
        Me.txtCodigoArticulo.Location = New System.Drawing.Point(65, 150)
        Me.txtCodigoArticulo.MaxLength = 16
        Me.txtCodigoArticulo.Name = "txtCodigoArticulo"
        Me.txtCodigoArticulo.Size = New System.Drawing.Size(72, 20)
        Me.txtCodigoArticulo.TabIndex = 2
        '
        'lblDisplayArticulo
        '
        Me.lblDisplayArticulo.AutoSize = True
        Me.lblDisplayArticulo.Location = New System.Drawing.Point(6, 153)
        Me.lblDisplayArticulo.Name = "lblDisplayArticulo"
        Me.lblDisplayArticulo.Size = New System.Drawing.Size(50, 13)
        Me.lblDisplayArticulo.TabIndex = 398
        Me.lblDisplayArticulo.Text = "Artículo :"
        '
        'Rpt_Ventas_Calificas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 276)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Ventas_Calificas"
        Me.Text = "Calificas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdnCalificaProductoFlujo As RadioButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbConsultar As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents DtFechaDesde As DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As Label
    Friend WithEvents DtFechaHasta As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDisplayCliente As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblDisplayZona As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblNombreZona As Label
    Friend WithEvents txtCodigoZona As TextBox
    Friend WithEvents lblNombreArticulo As Label
    Friend WithEvents txtCodigoArticulo As TextBox
    Friend WithEvents lblDisplayArticulo As Label
    Friend WithEvents txtTop As TextBox
    Friend WithEvents lblDisplayTop As Label
End Class
