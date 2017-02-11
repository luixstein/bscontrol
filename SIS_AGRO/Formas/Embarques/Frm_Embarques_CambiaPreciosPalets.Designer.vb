<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_CambiaPreciosPalets
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_CambiaPreciosPalets))
        Me.Grid = New FlexCell.Grid
        Me.txtFolioEmbarque = New System.Windows.Forms.TextBox
        Me.LblDisplayFolioEmbarque = New System.Windows.Forms.Label
        Me.lblTotales = New System.Windows.Forms.Label
        Me.txtTotalBultos = New System.Windows.Forms.MaskedTextBox
        Me.TxtTotalImporte = New System.Windows.Forms.MaskedTextBox
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker
        Me.LblFecha = New System.Windows.Forms.Label
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Grid.Location = New System.Drawing.Point(8, 62)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(733, 187)
        Me.Grid.TabIndex = 1
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'txtFolioEmbarque
        '
        Me.txtFolioEmbarque.Location = New System.Drawing.Point(107, 32)
        Me.txtFolioEmbarque.Name = "txtFolioEmbarque"
        Me.txtFolioEmbarque.Size = New System.Drawing.Size(100, 20)
        Me.txtFolioEmbarque.TabIndex = 2
        '
        'LblDisplayFolioEmbarque
        '
        Me.LblDisplayFolioEmbarque.AutoSize = True
        Me.LblDisplayFolioEmbarque.Location = New System.Drawing.Point(16, 35)
        Me.LblDisplayFolioEmbarque.Name = "LblDisplayFolioEmbarque"
        Me.LblDisplayFolioEmbarque.Size = New System.Drawing.Size(85, 13)
        Me.LblDisplayFolioEmbarque.TabIndex = 279
        Me.LblDisplayFolioEmbarque.Text = "Folio embarque :"
        '
        'lblTotales
        '
        Me.lblTotales.AutoSize = True
        Me.lblTotales.Location = New System.Drawing.Point(337, 258)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblTotales.TabIndex = 325
        Me.lblTotales.Text = "Totales :"
        '
        'txtTotalBultos
        '
        Me.txtTotalBultos.Location = New System.Drawing.Point(408, 254)
        Me.txtTotalBultos.Name = "txtTotalBultos"
        Me.txtTotalBultos.ReadOnly = True
        Me.txtTotalBultos.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalBultos.TabIndex = 322
        Me.txtTotalBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalImporte
        '
        Me.TxtTotalImporte.Location = New System.Drawing.Point(619, 254)
        Me.TxtTotalImporte.Name = "TxtTotalImporte"
        Me.TxtTotalImporte.ReadOnly = True
        Me.TxtTotalImporte.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalImporte.TabIndex = 324
        Me.TxtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(753, 25)
        Me.tsMenu.TabIndex = 326
        Me.tsMenu.Text = "tsMenu"
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
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(595, 28)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(146, 20)
        Me.DtpFecha.TabIndex = 327
        Me.DtpFecha.Visible = False
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(502, 32)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 328
        Me.LblFecha.Text = "Fecha :"
        Me.LblFecha.Visible = False
        '
        'Frm_Embarques_CambiaPreciosPaletsNacional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 285)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.LblFecha)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.lblTotales)
        Me.Controls.Add(Me.txtTotalBultos)
        Me.Controls.Add(Me.TxtTotalImporte)
        Me.Controls.Add(Me.LblDisplayFolioEmbarque)
        Me.Controls.Add(Me.txtFolioEmbarque)
        Me.Controls.Add(Me.Grid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_CambiaPreciosPaletsNacional"
        Me.Text = "Cambia precios"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents txtFolioEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolioEmbarque As System.Windows.Forms.Label
    Friend WithEvents lblTotales As System.Windows.Forms.Label
    Friend WithEvents txtTotalBultos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtTotalImporte As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
End Class
