<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_CambiaPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_CambiaPrecios))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.txtImporteTotalEmbarcado = New System.Windows.Forms.TextBox
        Me.gbGrid = New System.Windows.Forms.GroupBox
        Me.Grid = New FlexCell.Grid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.lblDisplayCliente = New System.Windows.Forms.Label
        Me.LblDisplayA = New System.Windows.Forms.Label
        Me.lblDisplayDe = New System.Windows.Forms.Label
        Me.DtpFecha2 = New System.Windows.Forms.DateTimePicker
        Me.DtpFecha1 = New System.Windows.Forms.DateTimePicker
        Me.CboSemana = New System.Windows.Forms.ComboBox
        Me.lblDisplaySemana = New System.Windows.Forms.Label
        Me.CboAnio = New System.Windows.Forms.ComboBox
        Me.lblAnio = New System.Windows.Forms.Label
        Me.txtBultosTotalEmbarcados = New System.Windows.Forms.TextBox
        Me.txtBultosTotalVendido = New System.Windows.Forms.TextBox
        Me.txtImporteTotalVendido = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAjustesTotal = New System.Windows.Forms.TextBox
        Me.tsMenu.SuspendLayout()
        Me.gbGrid.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(969, 25)
        Me.tsMenu.TabIndex = 3
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
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'txtImporteTotalEmbarcado
        '
        Me.txtImporteTotalEmbarcado.Location = New System.Drawing.Point(657, 356)
        Me.txtImporteTotalEmbarcado.MaxLength = 8
        Me.txtImporteTotalEmbarcado.Name = "txtImporteTotalEmbarcado"
        Me.txtImporteTotalEmbarcado.ReadOnly = True
        Me.txtImporteTotalEmbarcado.Size = New System.Drawing.Size(84, 20)
        Me.txtImporteTotalEmbarcado.TabIndex = 368
        Me.txtImporteTotalEmbarcado.Text = "  "
        Me.txtImporteTotalEmbarcado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbGrid
        '
        Me.gbGrid.Controls.Add(Me.Grid)
        Me.gbGrid.Location = New System.Drawing.Point(12, 111)
        Me.gbGrid.Name = "gbGrid"
        Me.gbGrid.Size = New System.Drawing.Size(945, 239)
        Me.gbGrid.TabIndex = 367
        Me.gbGrid.TabStop = False
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(12, 18)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 1
        Me.Grid.Size = New System.Drawing.Size(927, 210)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.LblDisplayA)
        Me.GroupBox1.Controls.Add(Me.lblDisplayDe)
        Me.GroupBox1.Controls.Add(Me.DtpFecha2)
        Me.GroupBox1.Controls.Add(Me.DtpFecha1)
        Me.GroupBox1.Controls.Add(Me.CboSemana)
        Me.GroupBox1.Controls.Add(Me.lblDisplaySemana)
        Me.GroupBox1.Controls.Add(Me.CboAnio)
        Me.GroupBox1.Controls.Add(Me.lblAnio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(945, 77)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(175, 49)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(310, 13)
        Me.lblNombreCliente.TabIndex = 356
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(81, 45)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(88, 20)
        Me.TxtCliente.TabIndex = 2
        Me.TxtCliente.Text = "  "
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(7, 49)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 355
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'LblDisplayA
        '
        Me.LblDisplayA.AutoSize = True
        Me.LblDisplayA.Location = New System.Drawing.Point(485, 19)
        Me.LblDisplayA.Name = "LblDisplayA"
        Me.LblDisplayA.Size = New System.Drawing.Size(22, 13)
        Me.LblDisplayA.TabIndex = 353
        Me.LblDisplayA.Text = "Al :"
        '
        'lblDisplayDe
        '
        Me.lblDisplayDe.AutoSize = True
        Me.lblDisplayDe.Location = New System.Drawing.Point(353, 19)
        Me.lblDisplayDe.Name = "lblDisplayDe"
        Me.lblDisplayDe.Size = New System.Drawing.Size(29, 13)
        Me.lblDisplayDe.TabIndex = 352
        Me.lblDisplayDe.Text = "Del :"
        '
        'DtpFecha2
        '
        Me.DtpFecha2.CustomFormat = "dd/MMM/yy"
        Me.DtpFecha2.Enabled = False
        Me.DtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha2.Location = New System.Drawing.Point(513, 16)
        Me.DtpFecha2.Name = "DtpFecha2"
        Me.DtpFecha2.Size = New System.Drawing.Size(91, 20)
        Me.DtpFecha2.TabIndex = 351
        '
        'DtpFecha1
        '
        Me.DtpFecha1.CustomFormat = "dd/MMM/yy"
        Me.DtpFecha1.Enabled = False
        Me.DtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha1.Location = New System.Drawing.Point(386, 15)
        Me.DtpFecha1.Name = "DtpFecha1"
        Me.DtpFecha1.Size = New System.Drawing.Size(91, 20)
        Me.DtpFecha1.TabIndex = 350
        '
        'CboSemana
        '
        Me.CboSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana.FormattingEnabled = True
        Me.CboSemana.Location = New System.Drawing.Point(247, 15)
        Me.CboSemana.Name = "CboSemana"
        Me.CboSemana.Size = New System.Drawing.Size(88, 21)
        Me.CboSemana.TabIndex = 1
        '
        'lblDisplaySemana
        '
        Me.lblDisplaySemana.AutoSize = True
        Me.lblDisplaySemana.Location = New System.Drawing.Point(189, 19)
        Me.lblDisplaySemana.Name = "lblDisplaySemana"
        Me.lblDisplaySemana.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplaySemana.TabIndex = 349
        Me.lblDisplaySemana.Text = "Semana :"
        '
        'CboAnio
        '
        Me.CboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAnio.FormattingEnabled = True
        Me.CboAnio.Location = New System.Drawing.Point(81, 15)
        Me.CboAnio.Name = "CboAnio"
        Me.CboAnio.Size = New System.Drawing.Size(88, 21)
        Me.CboAnio.TabIndex = 0
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(9, 19)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(32, 13)
        Me.lblAnio.TabIndex = 337
        Me.lblAnio.Text = "Año :"
        '
        'txtBultosTotalEmbarcados
        '
        Me.txtBultosTotalEmbarcados.Location = New System.Drawing.Point(435, 356)
        Me.txtBultosTotalEmbarcados.MaxLength = 8
        Me.txtBultosTotalEmbarcados.Name = "txtBultosTotalEmbarcados"
        Me.txtBultosTotalEmbarcados.ReadOnly = True
        Me.txtBultosTotalEmbarcados.Size = New System.Drawing.Size(84, 20)
        Me.txtBultosTotalEmbarcados.TabIndex = 370
        Me.txtBultosTotalEmbarcados.Text = "  "
        Me.txtBultosTotalEmbarcados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBultosTotalVendido
        '
        Me.txtBultosTotalVendido.Location = New System.Drawing.Point(525, 356)
        Me.txtBultosTotalVendido.MaxLength = 8
        Me.txtBultosTotalVendido.Name = "txtBultosTotalVendido"
        Me.txtBultosTotalVendido.ReadOnly = True
        Me.txtBultosTotalVendido.Size = New System.Drawing.Size(84, 20)
        Me.txtBultosTotalVendido.TabIndex = 371
        Me.txtBultosTotalVendido.Text = "  "
        Me.txtBultosTotalVendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteTotalVendido
        '
        Me.txtImporteTotalVendido.Location = New System.Drawing.Point(747, 356)
        Me.txtImporteTotalVendido.MaxLength = 8
        Me.txtImporteTotalVendido.Name = "txtImporteTotalVendido"
        Me.txtImporteTotalVendido.ReadOnly = True
        Me.txtImporteTotalVendido.Size = New System.Drawing.Size(84, 20)
        Me.txtImporteTotalVendido.TabIndex = 372
        Me.txtImporteTotalVendido.Text = "  "
        Me.txtImporteTotalVendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(347, 359)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 373
        Me.Label1.Text = "Totales :"
        '
        'txtAjustesTotal
        '
        Me.txtAjustesTotal.Location = New System.Drawing.Point(832, 356)
        Me.txtAjustesTotal.MaxLength = 8
        Me.txtAjustesTotal.Name = "txtAjustesTotal"
        Me.txtAjustesTotal.ReadOnly = True
        Me.txtAjustesTotal.Size = New System.Drawing.Size(84, 20)
        Me.txtAjustesTotal.TabIndex = 374
        Me.txtAjustesTotal.Text = "  "
        Me.txtAjustesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frm_Embarques_CambiaPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 402)
        Me.Controls.Add(Me.txtAjustesTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtImporteTotalVendido)
        Me.Controls.Add(Me.txtBultosTotalVendido)
        Me.Controls.Add(Me.txtBultosTotalEmbarcados)
        Me.Controls.Add(Me.txtImporteTotalEmbarcado)
        Me.Controls.Add(Me.gbGrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_CambiaPrecios"
        Me.Text = "Modificación de precios de productos embarcados."
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbGrid.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtImporteTotalEmbarcado As System.Windows.Forms.TextBox
    Friend WithEvents gbGrid As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboSemana As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplaySemana As System.Windows.Forms.Label
    Friend WithEvents CboAnio As System.Windows.Forms.ComboBox
    Friend WithEvents lblAnio As System.Windows.Forms.Label
    Friend WithEvents DtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBultosTotalEmbarcados As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayA As System.Windows.Forms.Label
    Friend WithEvents lblDisplayDe As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtBultosTotalVendido As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteTotalVendido As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAjustesTotal As System.Windows.Forms.TextBox
End Class
