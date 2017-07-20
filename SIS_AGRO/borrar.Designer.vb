<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class borrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(borrar))
        Me.gridL = New FlexCell.Grid()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gridK = New FlexCell.Grid()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.gridA = New FlexCell.Grid()
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
        Me.gridL.Location = New System.Drawing.Point(12, 354)
        Me.gridL.LockButton = True
        Me.gridL.Name = "gridL"
        Me.gridL.Rows = 6
        Me.gridL.Size = New System.Drawing.Size(745, 132)
        Me.gridL.TabIndex = 3
        Me.gridL.UncheckedImage = CType(resources.GetObject("gridL.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(268, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.gridK.Location = New System.Drawing.Point(12, 208)
        Me.gridK.LockButton = True
        Me.gridK.Name = "gridK"
        Me.gridK.Rows = 6
        Me.gridK.Size = New System.Drawing.Size(745, 130)
        Me.gridK.TabIndex = 5
        Me.gridK.UncheckedImage = CType(resources.GetObject("gridK.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(366, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(466, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
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
        Me.gridA.Location = New System.Drawing.Point(12, 72)
        Me.gridA.LockButton = True
        Me.gridA.Name = "gridA"
        Me.gridA.Rows = 6
        Me.gridA.Size = New System.Drawing.Size(745, 130)
        Me.gridA.TabIndex = 8
        Me.gridA.UncheckedImage = CType(resources.GetObject("gridA.UncheckedImage"), System.Drawing.Bitmap)
        '
        'borrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 521)
        Me.Controls.Add(Me.gridA)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.gridK)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gridL)
        Me.Name = "borrar"
        Me.Text = "borrar"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridL As FlexCell.Grid
    Friend WithEvents Button1 As Button
    Friend WithEvents gridK As FlexCell.Grid
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents gridA As FlexCell.Grid
End Class
