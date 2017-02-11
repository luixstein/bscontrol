<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Embarques_FletesNoGenerados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Embarques_FletesNoGenerados))
        Me.Grid = New FlexCell.Grid
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.txtImporteTotal = New System.Windows.Forms.TextBox
        Me.lblDisplayTotal = New System.Windows.Forms.Label
        Me.tsbReactivar = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
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
        Me.Grid.Location = New System.Drawing.Point(12, 28)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 8
        Me.Grid.Size = New System.Drawing.Size(835, 375)
        Me.Grid.TabIndex = 1
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbReactivar, Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(852, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "&Consultar"
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
        'txtImporteTotal
        '
        Me.txtImporteTotal.Enabled = False
        Me.txtImporteTotal.Location = New System.Drawing.Point(568, 409)
        Me.txtImporteTotal.Name = "txtImporteTotal"
        Me.txtImporteTotal.Size = New System.Drawing.Size(130, 20)
        Me.txtImporteTotal.TabIndex = 5
        Me.txtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotal
        '
        Me.lblDisplayTotal.AutoSize = True
        Me.lblDisplayTotal.Location = New System.Drawing.Point(488, 412)
        Me.lblDisplayTotal.Name = "lblDisplayTotal"
        Me.lblDisplayTotal.Size = New System.Drawing.Size(74, 13)
        Me.lblDisplayTotal.TabIndex = 6
        Me.lblDisplayTotal.Text = "Total importe :"
        '
        'tsbReactivar
        '
        Me.tsbReactivar.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbReactivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReactivar.Name = "tsbReactivar"
        Me.tsbReactivar.Size = New System.Drawing.Size(101, 22)
        Me.tsbReactivar.Text = "&Generar Fletes"
        '
        'Rpt_Embarques_FletesNoGenerados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 449)
        Me.Controls.Add(Me.lblDisplayTotal)
        Me.Controls.Add(Me.txtImporteTotal)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Grid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Embarques_FletesNoGenerados"
        Me.Text = "Embarques sin fletes generados"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents tsbReactivar As System.Windows.Forms.ToolStripButton
End Class
