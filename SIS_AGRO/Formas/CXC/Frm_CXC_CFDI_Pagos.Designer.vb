<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXC_CFDI_Pagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXC_CFDI_Pagos))
        Me.gbDocumentosPago = New System.Windows.Forms.GroupBox()
        Me.GridPagos = New FlexCell.Grid()
        Me.gbVentas = New System.Windows.Forms.GroupBox()
        Me.GridVentas = New FlexCell.Grid()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelarTimbre = New System.Windows.Forms.ToolStripButton()
        Me.tsbTimbrar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tsbEnviarCorreo = New System.Windows.Forms.ToolStripButton()
        Me.gbDocumentosPago.SuspendLayout()
        Me.gbVentas.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDocumentosPago
        '
        Me.gbDocumentosPago.Controls.Add(Me.GridPagos)
        Me.gbDocumentosPago.Location = New System.Drawing.Point(12, 37)
        Me.gbDocumentosPago.Name = "gbDocumentosPago"
        Me.gbDocumentosPago.Size = New System.Drawing.Size(1034, 159)
        Me.gbDocumentosPago.TabIndex = 3
        Me.gbDocumentosPago.TabStop = False
        Me.gbDocumentosPago.Text = "Documentos de pago :"
        '
        'GridPagos
        '
        Me.GridPagos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridPagos.CheckedImage = CType(resources.GetObject("GridPagos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridPagos.Cols = 1
        Me.GridPagos.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridPagos.DisplayRowNumber = True
        Me.GridPagos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPagos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridPagos.Location = New System.Drawing.Point(7, 19)
        Me.GridPagos.LockButton = True
        Me.GridPagos.Name = "GridPagos"
        Me.GridPagos.Rows = 6
        Me.GridPagos.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridPagos.Size = New System.Drawing.Size(1021, 122)
        Me.GridPagos.TabIndex = 0
        Me.GridPagos.UncheckedImage = CType(resources.GetObject("GridPagos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbVentas
        '
        Me.gbVentas.Controls.Add(Me.GridVentas)
        Me.gbVentas.Location = New System.Drawing.Point(12, 217)
        Me.gbVentas.Name = "gbVentas"
        Me.gbVentas.Size = New System.Drawing.Size(1034, 203)
        Me.gbVentas.TabIndex = 4
        Me.gbVentas.TabStop = False
        Me.gbVentas.Text = "Ventas"
        '
        'GridVentas
        '
        Me.GridVentas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridVentas.CheckedImage = CType(resources.GetObject("GridVentas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridVentas.Cols = 1
        Me.GridVentas.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridVentas.DisplayRowNumber = True
        Me.GridVentas.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridVentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridVentas.Location = New System.Drawing.Point(7, 19)
        Me.GridVentas.LockButton = True
        Me.GridVentas.Name = "GridVentas"
        Me.GridVentas.Rows = 8
        Me.GridVentas.Size = New System.Drawing.Size(1021, 178)
        Me.GridVentas.TabIndex = 0
        Me.GridVentas.UncheckedImage = CType(resources.GetObject("GridVentas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbTimbrar, Me.tsbCancelarTimbre, Me.tsbEnviarCorreo, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1060, 25)
        Me.tsMenu.TabIndex = 5
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbCancelarTimbre
        '
        Me.tsbCancelarTimbre.Image = Global.Agrinet.My.Resources.Resources._782
        Me.tsbCancelarTimbre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelarTimbre.Name = "tsbCancelarTimbre"
        Me.tsbCancelarTimbre.Size = New System.Drawing.Size(111, 22)
        Me.tsbCancelarTimbre.Text = "Cancelar timbre"
        '
        'tsbTimbrar
        '
        Me.tsbTimbrar.Image = Global.Agrinet.My.Resources.Resources._782
        Me.tsbTimbrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTimbrar.Name = "tsbTimbrar"
        Me.tsbTimbrar.Size = New System.Drawing.Size(69, 22)
        Me.tsbTimbrar.Text = "Timbrar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbEnviarCorreo
        '
        Me.tsbEnviarCorreo.Image = CType(resources.GetObject("tsbEnviarCorreo.Image"), System.Drawing.Image)
        Me.tsbEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarCorreo.Name = "tsbEnviarCorreo"
        Me.tsbEnviarCorreo.Size = New System.Drawing.Size(96, 22)
        Me.tsbEnviarCorreo.Text = "&Enviar correo"
        '
        'Frm_CXC_CFDI_Pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 461)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gbDocumentosPago)
        Me.Controls.Add(Me.gbVentas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXC_CFDI_Pagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CFDI's de pagos"
        Me.gbDocumentosPago.ResumeLayout(False)
        Me.gbVentas.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbDocumentosPago As GroupBox
    Friend WithEvents GridPagos As FlexCell.Grid
    Friend WithEvents gbVentas As GroupBox
    Friend WithEvents GridVentas As FlexCell.Grid
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbImprimir As ToolStripButton
    Friend WithEvents tsbTimbrar As ToolStripButton
    Friend WithEvents tsbCancelarTimbre As ToolStripButton
    Friend WithEvents tsbEnviarCorreo As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
End Class
