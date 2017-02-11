<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasSeleccionaTipoFactura
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
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(90, 29)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(205, 21)
        Me.CboDocumento.TabIndex = 222
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(17, 33)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 223
        Me.LblDocumento.Text = "Documento :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(167, 75)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(128, 23)
        Me.btnAceptar.TabIndex = 340
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'VentasSeleccionaTipoFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 131)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.CboDocumento)
        Me.Controls.Add(Me.LblDocumento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "VentasSeleccionaTipoFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selecciona el tipo de factura :"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
