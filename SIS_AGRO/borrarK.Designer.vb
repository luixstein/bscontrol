<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class borrarK
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(borrarK))
        Me.gridK = New FlexCell.Grid()
        Me.SuspendLayout()
        '
        'gridK
        '
        Me.gridK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gridK.CheckedImage = CType(resources.GetObject("gridK.CheckedImage"), System.Drawing.Bitmap)
        Me.gridK.Cols = 1
        Me.gridK.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.gridK.DisplayRowNumber = True
        Me.gridK.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.gridK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridK.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gridK.Location = New System.Drawing.Point(12, 12)
        Me.gridK.LockButton = True
        Me.gridK.Name = "gridK"
        Me.gridK.Rows = 6
        Me.gridK.Size = New System.Drawing.Size(745, 172)
        Me.gridK.TabIndex = 6
        Me.gridK.UncheckedImage = CType(resources.GetObject("gridK.UncheckedImage"), System.Drawing.Bitmap)
        '
        'borrarK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 196)
        Me.Controls.Add(Me.gridK)
        Me.Name = "borrarK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "borrarK"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridK As FlexCell.Grid
End Class
