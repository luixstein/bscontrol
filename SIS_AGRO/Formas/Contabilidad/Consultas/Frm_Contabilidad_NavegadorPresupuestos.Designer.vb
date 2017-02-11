<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_NavegadorPresupuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_NavegadorPresupuestos))
        Me.Grid = New FlexCell.Grid
        Me.TxtCuenta2 = New System.Windows.Forms.TextBox
        Me.TxtCuenta1 = New System.Windows.Forms.TextBox
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSubeNivel = New System.Windows.Forms.Button
        Me.txtEjercido = New System.Windows.Forms.TextBox
        Me.txtPresupuesto = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.AllowUserResizing = FlexCell.ResizeEnum.Rows
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(15, 69)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.SelectionMode = FlexCell.SelectionModeEnum.ByColumn
        Me.Grid.Size = New System.Drawing.Size(1059, 609)
        Me.Grid.TabIndex = 223
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TxtCuenta2
        '
        Me.TxtCuenta2.Location = New System.Drawing.Point(941, 41)
        Me.TxtCuenta2.MaxLength = 20
        Me.TxtCuenta2.Name = "TxtCuenta2"
        Me.TxtCuenta2.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta2.TabIndex = 225
        Me.TxtCuenta2.Text = "5"
        Me.TxtCuenta2.Visible = False
        '
        'TxtCuenta1
        '
        Me.TxtCuenta1.Location = New System.Drawing.Point(941, 15)
        Me.TxtCuenta1.MaxLength = 20
        Me.TxtCuenta1.Name = "TxtCuenta1"
        Me.TxtCuenta1.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta1.TabIndex = 224
        Me.TxtCuenta1.Text = "5"
        Me.TxtCuenta1.Visible = False
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(20, 18)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 231
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(105, 14)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(133, 21)
        Me.CmbEjercicio.TabIndex = 226
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(105, 38)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaDesde.TabIndex = 227
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(20, 44)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(44, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 229
        Me.LblDisplayFechaNacimiento.Text = "Desde :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(332, 37)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaHasta.TabIndex = 228
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(247, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Hasta :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSubeNivel)
        Me.GroupBox1.Controls.Add(Me.txtEjercido)
        Me.GroupBox1.Controls.Add(Me.txtPresupuesto)
        Me.GroupBox1.Controls.Add(Me.Grid)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta2)
        Me.GroupBox1.Controls.Add(Me.LblEjercicio)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta1)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1083, 711)
        Me.GroupBox1.TabIndex = 232
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Presupuestos "
        '
        'btnSubeNivel
        '
        Me.btnSubeNivel.Location = New System.Drawing.Point(250, 14)
        Me.btnSubeNivel.Name = "btnSubeNivel"
        Me.btnSubeNivel.Size = New System.Drawing.Size(60, 21)
        Me.btnSubeNivel.TabIndex = 235
        Me.btnSubeNivel.Text = "<---"
        Me.btnSubeNivel.UseVisualStyleBackColor = True
        '
        'txtEjercido
        '
        Me.txtEjercido.BackColor = System.Drawing.SystemColors.Control
        Me.txtEjercido.Location = New System.Drawing.Point(707, 683)
        Me.txtEjercido.MaxLength = 15
        Me.txtEjercido.Name = "txtEjercido"
        Me.txtEjercido.Size = New System.Drawing.Size(118, 20)
        Me.txtEjercido.TabIndex = 233
        Me.txtEjercido.Text = "0.00"
        Me.txtEjercido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPresupuesto
        '
        Me.txtPresupuesto.BackColor = System.Drawing.SystemColors.Control
        Me.txtPresupuesto.Location = New System.Drawing.Point(465, 683)
        Me.txtPresupuesto.MaxLength = 15
        Me.txtPresupuesto.Name = "txtPresupuesto"
        Me.txtPresupuesto.Size = New System.Drawing.Size(118, 20)
        Me.txtPresupuesto.TabIndex = 232
        Me.txtPresupuesto.Text = "0.00"
        Me.txtPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1107, 25)
        Me.ToolStrip1.TabIndex = 233
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
        'Frm_Contabilidad_NavegadorPresupuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1107, 744)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_NavegadorPresupuestos"
        Me.Text = "Navegador de presupuesto general"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents TxtCuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCuenta1 As System.Windows.Forms.TextBox
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEjercido As System.Windows.Forms.TextBox
    Friend WithEvents txtPresupuesto As System.Windows.Forms.TextBox
    Friend WithEvents btnSubeNivel As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
