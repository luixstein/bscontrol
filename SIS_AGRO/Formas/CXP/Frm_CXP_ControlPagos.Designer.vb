<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXP_ControlPagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXP_ControlPagos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblProveedor = New System.Windows.Forms.Label
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.cboTipoGasto = New System.Windows.Forms.ComboBox
        Me.CboAlmacen = New System.Windows.Forms.ComboBox
        Me.txtCodigoProveedor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtImporte = New System.Windows.Forms.TextBox
        Me.lblDisplayTotales = New System.Windows.Forms.Label
        Me.Grid1 = New FlexCell.Grid
        Me.txtSaldo = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.tsMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1105, 25)
        Me.tsMenu.TabIndex = 2
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblProveedor)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.cboTipoGasto)
        Me.GroupBox1.Controls.Add(Me.CboAlmacen)
        Me.GroupBox1.Controls.Add(Me.txtCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 70)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'LblProveedor
        '
        Me.LblProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblProveedor.Location = New System.Drawing.Point(193, 46)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(244, 13)
        Me.LblProveedor.TabIndex = 295
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(560, 41)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboTipoGasto
        '
        Me.cboTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoGasto.FormattingEnabled = True
        Me.cboTipoGasto.Location = New System.Drawing.Point(424, 16)
        Me.cboTipoGasto.Name = "cboTipoGasto"
        Me.cboTipoGasto.Size = New System.Drawing.Size(211, 21)
        Me.cboTipoGasto.TabIndex = 6
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(87, 16)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(211, 21)
        Me.CboAlmacen.TabIndex = 5
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(87, 43)
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoProveedor.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Proveedor :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(322, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo de gasto :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Almacén : "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtImporte)
        Me.GroupBox2.Controls.Add(Me.lblDisplayTotales)
        Me.GroupBox2.Controls.Add(Me.Grid1)
        Me.GroupBox2.Controls.Add(Me.txtSaldo)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1081, 442)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Compras con saldo"
        '
        'txtImporte
        '
        Me.txtImporte.Enabled = False
        Me.txtImporte.Location = New System.Drawing.Point(892, 416)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(95, 20)
        Me.txtImporte.TabIndex = 216
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(601, 419)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTotales.TabIndex = 215
        Me.lblDisplayTotales.Text = "Totales :"
        '
        'Grid1
        '
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(6, 19)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(1069, 391)
        Me.Grid1.TabIndex = 210
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(761, 416)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldo.TabIndex = 214
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(655, 416)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 213
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frm_CXP_ControlPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 558)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXP_ControlPagos"
        Me.Text = "Control de Pagos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents cboTipoGasto As System.Windows.Forms.ComboBox
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents LblProveedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
End Class
