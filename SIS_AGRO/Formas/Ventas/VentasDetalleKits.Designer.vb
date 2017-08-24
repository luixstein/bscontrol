<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasDetalleKits
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasDetalleKits))
        Me.gridK = New FlexCell.Grid()
        Me.btnAceptar = New System.Windows.Forms.Button()
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
        Me.gridK.Location = New System.Drawing.Point(50, 45)
        Me.gridK.LockButton = True
        Me.gridK.Name = "gridK"
        Me.gridK.Rows = 6
        Me.gridK.Size = New System.Drawing.Size(745, 172)
        Me.gridK.TabIndex = 7
        Me.gridK.UncheckedImage = CType(resources.GetObject("gridK.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(686, 223)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(109, 32)
        Me.btnAceptar.TabIndex = 382
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'VentasDetalleKits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 262)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gridK)
        Me.Name = "VentasDetalleKits"
        Me.Text = "Ventas k"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridK As FlexCell.Grid
    Friend WithEvents btnAceptar As Button
End Class
