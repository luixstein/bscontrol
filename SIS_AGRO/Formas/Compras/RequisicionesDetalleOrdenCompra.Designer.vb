<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RequisicionesDetalleOrdenCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RequisicionesDetalleOrdenCompra))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GridRequisiones = New FlexCell.Grid()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAgregar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1109, 27)
        Me.tsMenu.TabIndex = 5
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbAgregar
        '
        Me.tsbAgregar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregar.Name = "tsbAgregar"
        Me.tsbAgregar.Size = New System.Drawing.Size(87, 24)
        Me.tsbAgregar.Text = "&Agregar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'GridRequisiones
        '
        Me.GridRequisiones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridRequisiones.CheckedImage = CType(resources.GetObject("GridRequisiones.CheckedImage"), System.Drawing.Bitmap)
        Me.GridRequisiones.Cols = 1
        Me.GridRequisiones.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridRequisiones.DefaultRowHeight = CType(24, Short)
        Me.GridRequisiones.DisplayRowNumber = True
        Me.GridRequisiones.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridRequisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridRequisiones.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridRequisiones.Location = New System.Drawing.Point(9, 45)
        Me.GridRequisiones.LockButton = True
        Me.GridRequisiones.Margin = New System.Windows.Forms.Padding(4)
        Me.GridRequisiones.Name = "GridRequisiones"
        Me.GridRequisiones.Rows = 6
        Me.GridRequisiones.Size = New System.Drawing.Size(1087, 479)
        Me.GridRequisiones.TabIndex = 6
        Me.GridRequisiones.UncheckedImage = CType(resources.GetObject("GridRequisiones.UncheckedImage"), System.Drawing.Bitmap)
        '
        'RequisicionesDetalleOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 537)
        Me.Controls.Add(Me.GridRequisiones)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "RequisicionesDetalleOrdenCompra"
        Me.Text = "Artículos requeridos en almacén"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridRequisiones As FlexCell.Grid
End Class
