<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtileriasGeneraContraseñaCancelarMovimientosMesesPasados
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdGeneraContraseña = New System.Windows.Forms.Button
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.LblDisplayFolio = New System.Windows.Forms.Label
        Me.DtFecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdCopiar = New System.Windows.Forms.Button
        Me.txtContraseña = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdGeneraContraseña)
        Me.GroupBox1.Controls.Add(Me.TxtFolio)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFolio)
        Me.GroupBox1.Controls.Add(Me.DtFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos :"
        '
        'cmdGeneraContraseña
        '
        Me.cmdGeneraContraseña.Location = New System.Drawing.Point(9, 84)
        Me.cmdGeneraContraseña.Name = "cmdGeneraContraseña"
        Me.cmdGeneraContraseña.Size = New System.Drawing.Size(239, 23)
        Me.cmdGeneraContraseña.TabIndex = 261
        Me.cmdGeneraContraseña.Text = "Genera contraseña"
        Me.cmdGeneraContraseña.UseVisualStyleBackColor = True
        '
        'TxtFolio
        '
        Me.TxtFolio.Location = New System.Drawing.Point(79, 58)
        Me.TxtFolio.MaxLength = 160
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(135, 20)
        Me.TxtFolio.TabIndex = 259
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(6, 61)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 260
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'DtFecha
        '
        Me.DtFecha.Location = New System.Drawing.Point(9, 32)
        Me.DtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFecha.Name = "DtFecha"
        Me.DtFecha.Size = New System.Drawing.Size(239, 20)
        Me.DtFecha.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha en la que se debe cancelar el documento :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdCopiar)
        Me.GroupBox2.Controls.Add(Me.txtContraseña)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(257, 74)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'cmdCopiar
        '
        Me.cmdCopiar.Location = New System.Drawing.Point(12, 45)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(239, 23)
        Me.cmdCopiar.TabIndex = 261
        Me.cmdCopiar.Text = "Copiar"
        Me.cmdCopiar.UseVisualStyleBackColor = True
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(79, 19)
        Me.txtContraseña.MaxLength = 160
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(135, 20)
        Me.txtContraseña.TabIndex = 259
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "Contraseña :"
        '
        'UtileriasGeneraContraseñaCancelarMovimientosMesesPasados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 209)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "UtileriasGeneraContraseñaCancelarMovimientosMesesPasados"
        Me.Text = "Genera contraseña movs. pasados."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdGeneraContraseña As System.Windows.Forms.Button
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCopiar As System.Windows.Forms.Button
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
