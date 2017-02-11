<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCostosEdicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCostosEdicion))
        Me.gbCompraProveedor = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTotalImporte = New System.Windows.Forms.Label()
        Me.txtTotalImporte = New System.Windows.Forms.MaskedTextBox()
        Me.lblCodigoDocumento = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GridCuentas = New FlexCell.Grid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.gbCompraProveedor.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCompraProveedor
        '
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayTotalImporte)
        Me.gbCompraProveedor.Controls.Add(Me.txtTotalImporte)
        Me.gbCompraProveedor.Controls.Add(Me.lblCodigoDocumento)
        Me.gbCompraProveedor.Controls.Add(Me.Label1)
        Me.gbCompraProveedor.Controls.Add(Me.txtFolio)
        Me.gbCompraProveedor.Controls.Add(Me.lblDisplayFolio)
        Me.gbCompraProveedor.Controls.Add(Me.Label3)
        Me.gbCompraProveedor.Controls.Add(Me.GridCuentas)
        Me.gbCompraProveedor.Location = New System.Drawing.Point(16, 48)
        Me.gbCompraProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCompraProveedor.Name = "gbCompraProveedor"
        Me.gbCompraProveedor.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbCompraProveedor.Size = New System.Drawing.Size(1433, 594)
        Me.gbCompraProveedor.TabIndex = 0
        Me.gbCompraProveedor.TabStop = False
        '
        'lblDisplayTotalImporte
        '
        Me.lblDisplayTotalImporte.AutoSize = True
        Me.lblDisplayTotalImporte.Location = New System.Drawing.Point(1083, 567)
        Me.lblDisplayTotalImporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalImporte.Name = "lblDisplayTotalImporte"
        Me.lblDisplayTotalImporte.Size = New System.Drawing.Size(48, 17)
        Me.lblDisplayTotalImporte.TabIndex = 366
        Me.lblDisplayTotalImporte.Text = "Total :"
        '
        'txtTotalImporte
        '
        Me.txtTotalImporte.Location = New System.Drawing.Point(1155, 559)
        Me.txtTotalImporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTotalImporte.Name = "txtTotalImporte"
        Me.txtTotalImporte.ReadOnly = True
        Me.txtTotalImporte.Size = New System.Drawing.Size(129, 22)
        Me.txtTotalImporte.TabIndex = 365
        Me.txtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigoDocumento
        '
        Me.lblCodigoDocumento.AutoSize = True
        Me.lblCodigoDocumento.Location = New System.Drawing.Point(387, 16)
        Me.lblCodigoDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoDocumento.Name = "lblCodigoDocumento"
        Me.lblCodigoDocumento.Size = New System.Drawing.Size(27, 17)
        Me.lblCodigoDocumento.TabIndex = 1
        Me.lblCodigoDocumento.Text = "NA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(243, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 17)
        Me.Label1.TabIndex = 364
        Me.Label1.Text = "Código documento :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(91, 11)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(135, 22)
        Me.txtFolio.TabIndex = 0
        '
        'lblDisplayFolio
        '
        Me.lblDisplayFolio.AutoSize = True
        Me.lblDisplayFolio.Location = New System.Drawing.Point(8, 16)
        Me.lblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolio.Name = "lblDisplayFolio"
        Me.lblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.lblDisplayFolio.TabIndex = 362
        Me.lblDisplayFolio.Text = "Folio :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 53)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 360
        Me.Label3.Text = "Centros de costos"
        '
        'GridCuentas
        '
        Me.GridCuentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCuentas.CheckedImage = CType(resources.GetObject("GridCuentas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCuentas.Cols = 1
        Me.GridCuentas.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCuentas.DefaultRowHeight = CType(24, Short)
        Me.GridCuentas.DisplayRowNumber = True
        Me.GridCuentas.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCuentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCuentas.Location = New System.Drawing.Point(12, 73)
        Me.GridCuentas.LockButton = True
        Me.GridCuentas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridCuentas.Name = "GridCuentas"
        Me.GridCuentas.Rows = 2
        Me.GridCuentas.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GridCuentas.Size = New System.Drawing.Size(1420, 479)
        Me.GridCuentas.TabIndex = 4
        Me.GridCuentas.UncheckedImage = CType(resources.GetObject("GridCuentas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1453, 27)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(78, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(90, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'FrmCostosEdicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1453, 657)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbCompraProveedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmCostosEdicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edición de costos"
        Me.gbCompraProveedor.ResumeLayout(False)
        Me.gbCompraProveedor.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbCompraProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridCuentas As FlexCell.Grid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents lblCodigoDocumento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalImporte As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDisplayTotalImporte As System.Windows.Forms.Label
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
End Class
