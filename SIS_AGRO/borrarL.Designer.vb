<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class borrarL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(borrarL))
        Me.gridL = New FlexCell.Grid()
        Me.SuspendLayout()
        '
        'gridL
        '
        Me.gridL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gridL.CheckedImage = CType(resources.GetObject("gridL.CheckedImage"), System.Drawing.Bitmap)
        Me.gridL.Cols = 1
        Me.gridL.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.gridL.DisplayRowNumber = True
        Me.gridL.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.gridL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridL.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gridL.Location = New System.Drawing.Point(12, 43)
        Me.gridL.LockButton = True
        Me.gridL.Name = "gridL"
        Me.gridL.Rows = 6
        Me.gridL.Size = New System.Drawing.Size(745, 130)
        Me.gridL.TabIndex = 8
        Me.gridL.UncheckedImage = CType(resources.GetObject("gridL.UncheckedImage"), System.Drawing.Bitmap)
        '
        'borrarL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 262)
        Me.Controls.Add(Me.gridL)
        Me.Name = "borrarL"
        Me.Text = "borrarL"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridL As FlexCell.Grid
End Class
