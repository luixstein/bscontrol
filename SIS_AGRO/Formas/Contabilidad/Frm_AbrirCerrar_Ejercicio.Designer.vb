<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AbrirCerrar_Ejercicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AbrirCerrar_Ejercicio))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.LblDisplayCuenta = New System.Windows.Forms.Label
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.cboEjercicio = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblEstatus = New System.Windows.Forms.Label
        Me.lblDisplayEstatus = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEstatus)
        Me.GroupBox1.Controls.Add(Me.lblDisplayEstatus)
        Me.GroupBox1.Controls.Add(Me.lblCuenta)
        Me.GroupBox1.Controls.Add(Me.txtCuenta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayCuenta)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.btnAbrir)
        Me.GroupBox1.Controls.Add(Me.cboEjercicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 142)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione un ejercicio :"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(100, 75)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(10, 13)
        Me.lblCuenta.TabIndex = 254
        Me.lblCuenta.Text = "."
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(100, 52)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(100, 20)
        Me.txtCuenta.TabIndex = 1
        '
        'LblDisplayCuenta
        '
        Me.LblDisplayCuenta.AutoSize = True
        Me.LblDisplayCuenta.Location = New System.Drawing.Point(9, 55)
        Me.LblDisplayCuenta.Name = "LblDisplayCuenta"
        Me.LblDisplayCuenta.Size = New System.Drawing.Size(47, 13)
        Me.LblDisplayCuenta.TabIndex = 252
        Me.LblDisplayCuenta.Text = "Cuenta :"
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(200, 108)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(100, 23)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(100, 108)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(100, 23)
        Me.btnAbrir.TabIndex = 2
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'cboEjercicio
        '
        Me.cboEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEjercicio.FormattingEnabled = True
        Me.cboEjercicio.Location = New System.Drawing.Point(100, 25)
        Me.cboEjercicio.MaxLength = 1
        Me.cboEjercicio.Name = "cboEjercicio"
        Me.cboEjercicio.Size = New System.Drawing.Size(200, 21)
        Me.cboEjercicio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 246
        Me.Label1.Text = "Ejercicio :"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(100, 92)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(10, 13)
        Me.lblEstatus.TabIndex = 256
        Me.lblEstatus.Text = "."
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(9, 92)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayEstatus.TabIndex = 255
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'Frm_AbrirCerrar_Ejercicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 166)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_AbrirCerrar_Ejercicio"
        Me.Text = "Abrir/Cerrar Ejercicio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents cboEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCuenta As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayEstatus As System.Windows.Forms.Label
End Class
