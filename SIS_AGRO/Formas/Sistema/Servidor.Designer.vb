<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Servidor
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboServerName = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSistemaDirecto = New System.Windows.Forms.Button()
        Me.btnSistemaDirectoSol = New System.Windows.Forms.Button()
        Me.btnSistemaDirectoComer1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Servidor :"
        '
        'cboServerName
        '
        Me.cboServerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServerName.FormattingEnabled = True
        Me.cboServerName.Location = New System.Drawing.Point(61, 6)
        Me.cboServerName.Name = "cboServerName"
        Me.cboServerName.Size = New System.Drawing.Size(202, 21)
        Me.cboServerName.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(61, 33)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(202, 35)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnSistemaDirecto
        '
        Me.btnSistemaDirecto.Location = New System.Drawing.Point(6, 45)
        Me.btnSistemaDirecto.Name = "btnSistemaDirecto"
        Me.btnSistemaDirecto.Size = New System.Drawing.Size(28, 23)
        Me.btnSistemaDirecto.TabIndex = 3
        Me.btnSistemaDirecto.Text = "..."
        Me.btnSistemaDirecto.UseVisualStyleBackColor = True
        Me.btnSistemaDirecto.Visible = False
        '
        'btnSistemaDirectoSol
        '
        Me.btnSistemaDirectoSol.Location = New System.Drawing.Point(40, 45)
        Me.btnSistemaDirectoSol.Name = "btnSistemaDirectoSol"
        Me.btnSistemaDirectoSol.Size = New System.Drawing.Size(28, 23)
        Me.btnSistemaDirectoSol.TabIndex = 4
        Me.btnSistemaDirectoSol.Text = "..."
        Me.btnSistemaDirectoSol.UseVisualStyleBackColor = True
        Me.btnSistemaDirectoSol.Visible = False
        '
        'btnSistemaDirectoComer1
        '
        Me.btnSistemaDirectoComer1.Location = New System.Drawing.Point(74, 45)
        Me.btnSistemaDirectoComer1.Name = "btnSistemaDirectoComer1"
        Me.btnSistemaDirectoComer1.Size = New System.Drawing.Size(28, 23)
        Me.btnSistemaDirectoComer1.TabIndex = 5
        Me.btnSistemaDirectoComer1.Text = "..."
        Me.btnSistemaDirectoComer1.UseVisualStyleBackColor = True
        Me.btnSistemaDirectoComer1.Visible = False
        '
        'Servidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 80)
        Me.Controls.Add(Me.btnSistemaDirectoComer1)
        Me.Controls.Add(Me.btnSistemaDirectoSol)
        Me.Controls.Add(Me.btnSistemaDirecto)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cboServerName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Servidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione el servidor :"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboServerName As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnSistemaDirecto As System.Windows.Forms.Button
    Friend WithEvents btnSistemaDirectoSol As System.Windows.Forms.Button
    Friend WithEvents btnSistemaDirectoComer1 As System.Windows.Forms.Button
End Class
