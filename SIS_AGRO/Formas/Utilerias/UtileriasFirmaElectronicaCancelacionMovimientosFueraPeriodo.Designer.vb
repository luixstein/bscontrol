<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
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
        Me.dtFecha = New System.Windows.Forms.DateTimePicker
        Me.LblFecha = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.lblTituloCorto = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtContraseña = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNombreUsuario = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtFechaCancelacion = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtConcepto = New System.Windows.Forms.TextBox
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtFecha
        '
        Me.dtFecha.Enabled = False
        Me.dtFecha.Location = New System.Drawing.Point(149, 28)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(211, 20)
        Me.dtFecha.TabIndex = 262
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(100, 31)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 263
        Me.LblFecha.Text = "Fecha :"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(18, 64)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(336, 88)
        Me.lblTitulo.TabIndex = 264
        Me.lblTitulo.Text = "Titulo"
        '
        'lblTituloCorto
        '
        Me.lblTituloCorto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloCorto.ForeColor = System.Drawing.Color.Red
        Me.lblTituloCorto.Location = New System.Drawing.Point(103, 152)
        Me.lblTituloCorto.Name = "lblTituloCorto"
        Me.lblTituloCorto.Size = New System.Drawing.Size(257, 26)
        Me.lblTituloCorto.TabIndex = 265
        Me.lblTituloCorto.Text = "Titulo corto"
        Me.lblTituloCorto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtContraseña)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNombreUsuario)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtFechaCancelacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 181)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(348, 99)
        Me.GroupBox1.TabIndex = 267
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información nesesaria :"
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(131, 71)
        Me.txtContraseña.MaxLength = 40
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(211, 20)
        Me.txtContraseña.TabIndex = 269
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 268
        Me.Label3.Text = "Contraseña :"
        '
        'txtNombreUsuario
        '
        Me.txtNombreUsuario.Enabled = False
        Me.txtNombreUsuario.Location = New System.Drawing.Point(131, 45)
        Me.txtNombreUsuario.MaxLength = 30
        Me.txtNombreUsuario.Name = "txtNombreUsuario"
        Me.txtNombreUsuario.Size = New System.Drawing.Size(211, 20)
        Me.txtNombreUsuario.TabIndex = 267
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 266
        Me.Label2.Text = "Usuario que registra :"
        '
        'dtFechaCancelacion
        '
        Me.dtFechaCancelacion.Location = New System.Drawing.Point(131, 19)
        Me.dtFechaCancelacion.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaCancelacion.Name = "dtFechaCancelacion"
        Me.dtFechaCancelacion.Size = New System.Drawing.Size(211, 20)
        Me.dtFechaCancelacion.TabIndex = 264
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 265
        Me.Label1.Text = "Fecha de cancelación :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtConcepto)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 286)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(348, 99)
        Me.GroupBox2.TabIndex = 268
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(6, 19)
        Me.TxtConcepto.MaxLength = 80
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(336, 74)
        Me.TxtConcepto.TabIndex = 7
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(198, 391)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 269
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(285, 391)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 270
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 417)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTituloCorto)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.LblFecha)
        Me.MaximizeBox = False
        Me.Name = "UtileriasFirmaElectronicaCancelacionMovimientosFueraPeriodo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Firma Electronica"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblTituloCorto As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtFechaCancelacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
