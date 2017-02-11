<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXP_Autorizaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXP_Autorizaciones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDisplayTotales = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtSaldo = New System.Windows.Forms.TextBox
        Me.txtAutorizado = New System.Windows.Forms.TextBox
        Me.Grid1 = New FlexCell.Grid
        Me.btnSeleccionar = New System.Windows.Forms.Button
        Me.btnRefrescar = New System.Windows.Forms.Button
        Me.btnRegresar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDisplayTotales)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.txtSaldo)
        Me.GroupBox1.Controls.Add(Me.txtAutorizado)
        Me.GroupBox1.Controls.Add(Me.Grid1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(812, 467)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(387, 442)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTotales.TabIndex = 214
        Me.lblDisplayTotales.Text = "Totales :"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(471, 439)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 213
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(577, 439)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldo.TabIndex = 212
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAutorizado
        '
        Me.txtAutorizado.Enabled = False
        Me.txtAutorizado.Location = New System.Drawing.Point(683, 439)
        Me.txtAutorizado.Name = "txtAutorizado"
        Me.txtAutorizado.Size = New System.Drawing.Size(100, 20)
        Me.txtAutorizado.TabIndex = 211
        Me.txtAutorizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Grid1.Location = New System.Drawing.Point(11, 13)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 2
        Me.Grid1.Size = New System.Drawing.Size(791, 417)
        Me.Grid1.TabIndex = 210
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Location = New System.Drawing.Point(171, 485)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(151, 34)
        Me.btnSeleccionar.TabIndex = 1
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(331, 485)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(151, 34)
        Me.btnRefrescar.TabIndex = 2
        Me.btnRefrescar.Text = "Refrescar Autorizaciones"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Location = New System.Drawing.Point(491, 485)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(151, 34)
        Me.btnRegresar.TabIndex = 3
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'Frm_CXP_Autorizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 527)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXP_Autorizaciones"
        Me.Text = "Pagos a proveedores autorizados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtAutorizado As System.Windows.Forms.TextBox
End Class
