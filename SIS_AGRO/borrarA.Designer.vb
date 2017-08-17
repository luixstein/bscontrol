<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class borrarA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(borrarA))
        Me.gridA = New FlexCell.Grid()
        Me.SuspendLayout()
        '
        'gridA
        '
        Me.gridA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gridA.CheckedImage = CType(resources.GetObject("gridA.CheckedImage"), System.Drawing.Bitmap)
        Me.gridA.Cols = 1
        Me.gridA.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.gridA.DisplayRowNumber = True
        Me.gridA.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.gridA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridA.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gridA.Location = New System.Drawing.Point(12, 45)
        Me.gridA.LockButton = True
        Me.gridA.Name = "gridA"
        Me.gridA.Rows = 6
        Me.gridA.Size = New System.Drawing.Size(745, 130)
        Me.gridA.TabIndex = 9
        Me.gridA.UncheckedImage = CType(resources.GetObject("gridA.UncheckedImage"), System.Drawing.Bitmap)
        '
        'borrarA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 262)
        Me.Controls.Add(Me.gridA)
        Me.Name = "borrarA"
        Me.Text = "borrarA"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridA As FlexCell.Grid
End Class
