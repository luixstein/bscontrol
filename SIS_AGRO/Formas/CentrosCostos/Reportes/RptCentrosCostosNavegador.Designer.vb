<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptCentrosCostosNavegador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptCentrosCostosNavegador))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridMovimientos = New FlexCell.Grid()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnSubeNivel = New System.Windows.Forms.Button()
        Me.txtEjercido = New System.Windows.Forms.TextBox()
        Me.txtPresupuesto = New System.Windows.Forms.TextBox()
        Me.Grid = New FlexCell.Grid()
        Me.TxtCuenta2 = New System.Windows.Forms.TextBox()
        Me.TxtCuenta1 = New System.Windows.Forms.TextBox()
        Me.LblDisplayFecha2 = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFecha1 = New System.Windows.Forms.Label()
        Me.TxtCodigoTemporada = New System.Windows.Forms.TextBox()
        Me.LblTemporada = New System.Windows.Forms.Label()
        Me.LblNombreTemporada = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1469, 27)
        Me.ToolStrip1.TabIndex = 1
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblNombreTemporada)
        Me.GroupBox1.Controls.Add(Me.LblTemporada)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoTemporada)
        Me.GroupBox1.Controls.Add(Me.GridMovimientos)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.btnSubeNivel)
        Me.GroupBox1.Controls.Add(Me.txtEjercido)
        Me.GroupBox1.Controls.Add(Me.txtPresupuesto)
        Me.GroupBox1.Controls.Add(Me.Grid)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta2)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta1)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFecha2)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFecha1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1444, 875)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GridMovimientos
        '
        Me.GridMovimientos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridMovimientos.CheckedImage = CType(resources.GetObject("GridMovimientos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridMovimientos.Cols = 1
        Me.GridMovimientos.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridMovimientos.DefaultRowHeight = CType(24, Short)
        Me.GridMovimientos.DisplayRowNumber = True
        Me.GridMovimientos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridMovimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridMovimientos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridMovimientos.Location = New System.Drawing.Point(315, 160)
        Me.GridMovimientos.LockButton = True
        Me.GridMovimientos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridMovimientos.Name = "GridMovimientos"
        Me.GridMovimientos.Rows = 20
        Me.GridMovimientos.SelectionMode = FlexCell.SelectionModeEnum.ByColumn
        Me.GridMovimientos.Size = New System.Drawing.Size(856, 565)
        Me.GridMovimientos.TabIndex = 238
        Me.GridMovimientos.UncheckedImage = CType(resources.GetObject("GridMovimientos.UncheckedImage"), System.Drawing.Bitmap)
        Me.GridMovimientos.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.BsControl.My.Resources.Resources._096
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnConsultar.Location = New System.Drawing.Point(613, 42)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(153, 28)
        Me.btnConsultar.TabIndex = 237
        Me.btnConsultar.Text = "Refrescar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnSubeNivel
        '
        Me.btnSubeNivel.Location = New System.Drawing.Point(315, 16)
        Me.btnSubeNivel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSubeNivel.Name = "btnSubeNivel"
        Me.btnSubeNivel.Size = New System.Drawing.Size(80, 26)
        Me.btnSubeNivel.TabIndex = 236
        Me.btnSubeNivel.Text = "<---"
        Me.btnSubeNivel.UseVisualStyleBackColor = True
        '
        'txtEjercido
        '
        Me.txtEjercido.BackColor = System.Drawing.SystemColors.Control
        Me.txtEjercido.Location = New System.Drawing.Point(572, 841)
        Me.txtEjercido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEjercido.MaxLength = 15
        Me.txtEjercido.Name = "txtEjercido"
        Me.txtEjercido.Size = New System.Drawing.Size(156, 22)
        Me.txtEjercido.TabIndex = 233
        Me.txtEjercido.Text = "0.00"
        Me.txtEjercido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.BackColor = System.Drawing.SystemColors.Control
        Me.txtPresupuesto.Location = New System.Drawing.Point(737, 841)
        Me.txtPresupuesto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPresupuesto.MaxLength = 15
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.Size = New System.Drawing.Size(156, 22)
        Me.txtPresupuesto.TabIndex = 232
        Me.txtPresupuesto.Text = "0.00"
        Me.txtPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPresupuesto.Visible = False
        '
        'Grid
        '
        Me.Grid.AllowUserSort = True
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DefaultRowHeight = CType(24, Short)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(20, 85)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.SelectionMode = FlexCell.SelectionModeEnum.ByColumn
        Me.Grid.Size = New System.Drawing.Size(1412, 750)
        Me.Grid.TabIndex = 223
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TxtCuenta2
        '
        Me.TxtCuenta2.Location = New System.Drawing.Point(1255, 50)
        Me.TxtCuenta2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCuenta2.MaxLength = 20
        Me.TxtCuenta2.Name = "TxtCuenta2"
        Me.TxtCuenta2.Size = New System.Drawing.Size(176, 22)
        Me.TxtCuenta2.TabIndex = 225
        Me.TxtCuenta2.Visible = False
        '
        'TxtCuenta1
        '
        Me.TxtCuenta1.Location = New System.Drawing.Point(1255, 18)
        Me.TxtCuenta1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCuenta1.MaxLength = 20
        Me.TxtCuenta1.Name = "TxtCuenta1"
        Me.TxtCuenta1.Size = New System.Drawing.Size(176, 22)
        Me.TxtCuenta1.TabIndex = 224
        Me.TxtCuenta1.Visible = False
        '
        'LblDisplayFecha2
        '
        Me.LblDisplayFecha2.AutoSize = True
        Me.LblDisplayFecha2.Location = New System.Drawing.Point(340, 54)
        Me.LblDisplayFecha2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFecha2.Name = "LblDisplayFecha2"
        Me.LblDisplayFecha2.Size = New System.Drawing.Size(53, 17)
        Me.LblDisplayFecha2.TabIndex = 230
        Me.LblDisplayFecha2.Text = "Hasta :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(143, 49)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(176, 22)
        Me.DtFechaDesde.TabIndex = 2
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(403, 49)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(176, 22)
        Me.DtFechaHasta.TabIndex = 3
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFecha1
        '
        Me.LblDisplayFecha1.AutoSize = True
        Me.LblDisplayFecha1.Location = New System.Drawing.Point(19, 54)
        Me.LblDisplayFecha1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFecha1.Name = "LblDisplayFecha1"
        Me.LblDisplayFecha1.Size = New System.Drawing.Size(57, 17)
        Me.LblDisplayFecha1.TabIndex = 229
        Me.LblDisplayFecha1.Text = "Desde :"
        '
        'TxtCodigoTemporada
        '
        Me.TxtCodigoTemporada.Location = New System.Drawing.Point(143, 20)
        Me.TxtCodigoTemporada.Name = "TxtCodigoTemporada"
        Me.TxtCodigoTemporada.Size = New System.Drawing.Size(34, 22)
        Me.TxtCodigoTemporada.TabIndex = 239
        '
        'LblTemporada
        '
        Me.LblTemporada.AutoSize = True
        Me.LblTemporada.Location = New System.Drawing.Point(17, 21)
        Me.LblTemporada.Name = "LblTemporada"
        Me.LblTemporada.Size = New System.Drawing.Size(89, 17)
        Me.LblTemporada.TabIndex = 240
        Me.LblTemporada.Text = "Temporada :"
        '
        'LblNombreTemporada
        '
        Me.LblNombreTemporada.AutoSize = True
        Me.LblNombreTemporada.Location = New System.Drawing.Point(183, 23)
        Me.LblNombreTemporada.Name = "LblNombreTemporada"
        Me.LblNombreTemporada.Size = New System.Drawing.Size(12, 17)
        Me.LblNombreTemporada.TabIndex = 241
        Me.LblNombreTemporada.Text = "."
        '
        'RptCentrosCostosNavegador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1469, 917)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "RptCentrosCostosNavegador"
        Me.Text = "Navegador de costos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEjercido As System.Windows.Forms.TextBox
    Friend WithEvents txtPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents TxtCuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCuenta1 As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFecha2 As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFecha1 As System.Windows.Forms.Label
    Friend WithEvents btnSubeNivel As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents GridMovimientos As FlexCell.Grid
    Friend WithEvents LblNombreTemporada As System.Windows.Forms.Label
    Friend WithEvents LblTemporada As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoTemporada As System.Windows.Forms.TextBox
End Class
