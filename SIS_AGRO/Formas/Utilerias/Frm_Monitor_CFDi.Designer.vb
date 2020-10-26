<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Monitor_CFDi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Monitor_CFDi))
        Me.Grid1 = New FlexCell.Grid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Grid2 = New FlexCell.Grid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblDocumentosSinTimbrar = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid1
        '
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(10, 19)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 8
        Me.Grid1.Size = New System.Drawing.Size(719, 205)
        Me.Grid1.TabIndex = 1
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Grid1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(735, 239)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documentos sin timbrar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 34)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Consultar documentos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Grid2
        '
        Me.Grid2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid2.CheckedImage = CType(resources.GetObject("Grid2.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid2.Cols = 1
        Me.Grid2.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid2.DisplayRowNumber = True
        Me.Grid2.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid2.Location = New System.Drawing.Point(10, 19)
        Me.Grid2.LockButton = True
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Rows = 8
        Me.Grid2.Size = New System.Drawing.Size(719, 205)
        Me.Grid2.TabIndex = 3
        Me.Grid2.UncheckedImage = CType(resources.GetObject("Grid2.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Grid2)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 300)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(735, 239)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos cancelados sin timbrar"
        '
        'LblDocumentosSinTimbrar
        '
        Me.LblDocumentosSinTimbrar.AutoSize = True
        Me.LblDocumentosSinTimbrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocumentosSinTimbrar.Location = New System.Drawing.Point(194, 19)
        Me.LblDocumentosSinTimbrar.Name = "LblDocumentosSinTimbrar"
        Me.LblDocumentosSinTimbrar.Size = New System.Drawing.Size(0, 20)
        Me.LblDocumentosSinTimbrar.TabIndex = 5
        '
        'Frm_Monitor_CFDi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 543)
        Me.Controls.Add(Me.LblDocumentosSinTimbrar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Monitor_CFDi"
        Me.Text = "Monitor de CFDi"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Grid2 As FlexCell.Grid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblDocumentosSinTimbrar As System.Windows.Forms.Label
End Class
