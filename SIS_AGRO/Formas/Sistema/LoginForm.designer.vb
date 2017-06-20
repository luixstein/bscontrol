<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents UserNameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtNombreUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnIniciarSesion As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.txtNombreUsuario = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnIniciarSesion = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cboPlazas = New System.Windows.Forms.ComboBox()
        Me.GpbCentro = New System.Windows.Forms.GroupBox()
        Me.btnEntrarAlSistema = New System.Windows.Forms.Button()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CboUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.lblDisplayRFC = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.GpbCentro.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserNameLabel
        '
        Me.UserNameLabel.Location = New System.Drawing.Point(171, 4)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New System.Drawing.Size(220, 23)
        Me.UserNameLabel.TabIndex = 5
        Me.UserNameLabel.Text = "Nombre de usuario"
        Me.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(171, 43)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
        Me.PasswordLabel.TabIndex = 6
        Me.PasswordLabel.Text = "Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNombreUsuario
        '
        Me.txtNombreUsuario.Location = New System.Drawing.Point(171, 26)
        Me.txtNombreUsuario.MaxLength = 30
        Me.txtNombreUsuario.Name = "txtNombreUsuario"
        Me.txtNombreUsuario.Size = New System.Drawing.Size(220, 20)
        Me.txtNombreUsuario.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(171, 64)
        Me.txtPassword.MaxLength = 12
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(220, 20)
        Me.txtPassword.TabIndex = 2
        '
        'btnIniciarSesion
        '
        Me.btnIniciarSesion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnIniciarSesion.Location = New System.Drawing.Point(172, 94)
        Me.btnIniciarSesion.Name = "btnIniciarSesion"
        Me.btnIniciarSesion.Size = New System.Drawing.Size(94, 23)
        Me.btnIniciarSesion.TabIndex = 3
        Me.btnIniciarSesion.Text = "&Iniciar sesión"
        Me.btnIniciarSesion.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(299, 94)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(94, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'cboPlazas
        '
        Me.cboPlazas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlazas.FormattingEnabled = True
        Me.cboPlazas.Location = New System.Drawing.Point(6, 19)
        Me.cboPlazas.Name = "cboPlazas"
        Me.cboPlazas.Size = New System.Drawing.Size(198, 21)
        Me.cboPlazas.TabIndex = 0
        '
        'GpbCentro
        '
        Me.GpbCentro.Controls.Add(Me.btnEntrarAlSistema)
        Me.GpbCentro.Controls.Add(Me.cboPlazas)
        Me.GpbCentro.Enabled = False
        Me.GpbCentro.Location = New System.Drawing.Point(171, 123)
        Me.GpbCentro.Name = "GpbCentro"
        Me.GpbCentro.Size = New System.Drawing.Size(219, 70)
        Me.GpbCentro.TabIndex = 5
        Me.GpbCentro.TabStop = False
        Me.GpbCentro.Text = "Plazas"
        '
        'btnEntrarAlSistema
        '
        Me.btnEntrarAlSistema.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnEntrarAlSistema.Location = New System.Drawing.Point(6, 44)
        Me.btnEntrarAlSistema.Name = "btnEntrarAlSistema"
        Me.btnEntrarAlSistema.Size = New System.Drawing.Size(94, 23)
        Me.btnEntrarAlSistema.TabIndex = 1
        Me.btnEntrarAlSistema.Text = "&Entrar al sistema"
        Me.btnEntrarAlSistema.UseVisualStyleBackColor = False
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(250, 196)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(141, 144)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        Me.LogoPictureBox.Visible = False
        '
        'CboUsuarios
        '
        Me.CboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboUsuarios.FormattingEnabled = True
        Me.CboUsuarios.Location = New System.Drawing.Point(270, 4)
        Me.CboUsuarios.Name = "CboUsuarios"
        Me.CboUsuarios.Size = New System.Drawing.Size(121, 21)
        Me.CboUsuarios.TabIndex = 6
        Me.CboUsuarios.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe Script", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(372, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 34)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "AgroControl"
        Me.Label1.Visible = False
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(28, 43)
        Me.txtRFC.MaxLength = 13
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(106, 20)
        Me.txtRFC.TabIndex = 0
        Me.txtRFC.Visible = False
        '
        'lblDisplayRFC
        '
        Me.lblDisplayRFC.AutoSize = True
        Me.lblDisplayRFC.Location = New System.Drawing.Point(67, 26)
        Me.lblDisplayRFC.Name = "lblDisplayRFC"
        Me.lblDisplayRFC.Size = New System.Drawing.Size(28, 13)
        Me.lblDisplayRFC.TabIndex = 14
        Me.lblDisplayRFC.Text = "RFC"
        Me.lblDisplayRFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDisplayRFC.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(12, 181)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 15
        Me.lblVersion.Text = "Versión"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(402, 203)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.txtRFC)
        Me.Controls.Add(Me.lblDisplayRFC)
        Me.Controls.Add(Me.CboUsuarios)
        Me.Controls.Add(Me.GpbCentro)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnIniciarSesion)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtNombreUsuario)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UserNameLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de sesión"
        Me.GpbCentro.ResumeLayout(False)
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPlazas As System.Windows.Forms.ComboBox
    Friend WithEvents GpbCentro As System.Windows.Forms.GroupBox
    Friend WithEvents btnEntrarAlSistema As System.Windows.Forms.Button
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CboUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayRFC As System.Windows.Forms.Label
    Friend WithEvents lblVersion As Label
End Class
