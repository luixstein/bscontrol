<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCodigosPostales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCodigosPostales))
        Me.gbCodigosPostales = New System.Windows.Forms.GroupBox()
        Me.GridCodigoPostal = New FlexCell.Grid()
        Me.gbCodigosPostales.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCodigosPostales
        '
        Me.gbCodigosPostales.Controls.Add(Me.GridCodigoPostal)
        Me.gbCodigosPostales.Location = New System.Drawing.Point(12, 12)
        Me.gbCodigosPostales.Name = "gbCodigosPostales"
        Me.gbCodigosPostales.Size = New System.Drawing.Size(897, 288)
        Me.gbCodigosPostales.TabIndex = 116
        Me.gbCodigosPostales.TabStop = False
        Me.gbCodigosPostales.Text = "Información del código postal"
        '
        'GridCodigoPostal
        '
        Me.GridCodigoPostal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCodigoPostal.CheckedImage = CType(resources.GetObject("GridCodigoPostal.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCodigoPostal.Cols = 1
        Me.GridCodigoPostal.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCodigoPostal.DefaultRowHeight = CType(24, Short)
        Me.GridCodigoPostal.DisplayRowNumber = True
        Me.GridCodigoPostal.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCodigoPostal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCodigoPostal.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCodigoPostal.Location = New System.Drawing.Point(6, 51)
        Me.GridCodigoPostal.LockButton = True
        Me.GridCodigoPostal.Name = "GridCodigoPostal"
        Me.GridCodigoPostal.Rows = 4
        Me.GridCodigoPostal.Size = New System.Drawing.Size(885, 221)
        Me.GridCodigoPostal.TabIndex = 1
        Me.GridCodigoPostal.UncheckedImage = CType(resources.GetObject("GridCodigoPostal.UncheckedImage"), System.Drawing.Bitmap)
        '
        'FrmCodigosPostales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 317)
        Me.Controls.Add(Me.gbCodigosPostales)
        Me.Name = "FrmCodigosPostales"
        Me.Text = "FrmCodigosPostales"
        Me.gbCodigosPostales.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbCodigosPostales As GroupBox
    Friend WithEvents GridCodigoPostal As FlexCell.Grid
End Class
