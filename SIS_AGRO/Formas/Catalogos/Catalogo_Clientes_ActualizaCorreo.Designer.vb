<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Clientes_ActualizaCorreo
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
        Me.gbCliente = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.btnActualizaCorreo = New System.Windows.Forms.Button()
        Me.txtCorreoCliente = New System.Windows.Forms.TextBox()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.lblDisplayCorreo = New System.Windows.Forms.Label()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCliente
        '
        Me.gbCliente.Controls.Add(Me.btnCancelar)
        Me.gbCliente.Controls.Add(Me.lblNombreCliente)
        Me.gbCliente.Controls.Add(Me.btnActualizaCorreo)
        Me.gbCliente.Controls.Add(Me.txtCorreoCliente)
        Me.gbCliente.Controls.Add(Me.txtCodigoCliente)
        Me.gbCliente.Controls.Add(Me.lblDisplayCorreo)
        Me.gbCliente.Controls.Add(Me.lblDisplayCliente)
        Me.gbCliente.Location = New System.Drawing.Point(12, 12)
        Me.gbCliente.Name = "gbCliente"
        Me.gbCliente.Size = New System.Drawing.Size(557, 151)
        Me.gbCliente.TabIndex = 0
        Me.gbCliente.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(412, 118)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(131, 26)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(163, 30)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreCliente.TabIndex = 5
        Me.lblNombreCliente.Text = "."
        '
        'btnActualizaCorreo
        '
        Me.btnActualizaCorreo.Location = New System.Drawing.Point(198, 118)
        Me.btnActualizaCorreo.Name = "btnActualizaCorreo"
        Me.btnActualizaCorreo.Size = New System.Drawing.Size(131, 26)
        Me.btnActualizaCorreo.TabIndex = 2
        Me.btnActualizaCorreo.Text = "Actualizar correo"
        Me.btnActualizaCorreo.UseVisualStyleBackColor = True
        '
        'txtCorreoCliente
        '
        Me.txtCorreoCliente.Location = New System.Drawing.Point(83, 59)
        Me.txtCorreoCliente.MaxLength = 500
        Me.txtCorreoCliente.Multiline = True
        Me.txtCorreoCliente.Name = "txtCorreoCliente"
        Me.txtCorreoCliente.Size = New System.Drawing.Size(460, 53)
        Me.txtCorreoCliente.TabIndex = 1
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Enabled = False
        Me.txtCodigoCliente.Location = New System.Drawing.Point(83, 27)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(74, 20)
        Me.txtCodigoCliente.TabIndex = 0
        '
        'lblDisplayCorreo
        '
        Me.lblDisplayCorreo.AutoSize = True
        Me.lblDisplayCorreo.Location = New System.Drawing.Point(6, 62)
        Me.lblDisplayCorreo.Name = "lblDisplayCorreo"
        Me.lblDisplayCorreo.Size = New System.Drawing.Size(44, 13)
        Me.lblDisplayCorreo.TabIndex = 1
        Me.lblDisplayCorreo.Text = "Correo :"
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(6, 30)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 0
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "*Nota, para más de un correo sepárelos con  ;"
        '
        'Catalogo_Clientes_ActualizaCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 198)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbCliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Catalogo_Clientes_ActualizaCorreo"
        Me.Text = "Correo del cliente"
        Me.gbCliente.ResumeLayout(False)
        Me.gbCliente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents btnActualizaCorreo As System.Windows.Forms.Button
    Friend WithEvents txtCorreoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCorreo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
