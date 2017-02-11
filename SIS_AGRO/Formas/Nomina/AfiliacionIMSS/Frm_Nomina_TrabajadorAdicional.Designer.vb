<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_TrabajadorAdicional
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_TrabajadorAdicional))
        Me.lblDisplayCodigoTrbajador = New System.Windows.Forms.Label
        Me.lblDisplayFecha = New System.Windows.Forms.Label
        Me.dtFecha = New System.Windows.Forms.DateTimePicker
        Me.txtCodigoTrabajador = New System.Windows.Forms.TextBox
        Me.lblNombreTrabajador = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblDisplayCodigoTrbajador
        '
        Me.lblDisplayCodigoTrbajador.AutoSize = True
        Me.lblDisplayCodigoTrbajador.Location = New System.Drawing.Point(12, 22)
        Me.lblDisplayCodigoTrbajador.Name = "lblDisplayCodigoTrbajador"
        Me.lblDisplayCodigoTrbajador.Size = New System.Drawing.Size(85, 13)
        Me.lblDisplayCodigoTrbajador.TabIndex = 0
        Me.lblDisplayCodigoTrbajador.Text = "Cód. trabajador :"
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(12, 64)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 1
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(103, 64)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(92, 20)
        Me.dtFecha.TabIndex = 1
        '
        'txtCodigoTrabajador
        '
        Me.txtCodigoTrabajador.Location = New System.Drawing.Point(103, 19)
        Me.txtCodigoTrabajador.Name = "txtCodigoTrabajador"
        Me.txtCodigoTrabajador.Size = New System.Drawing.Size(92, 20)
        Me.txtCodigoTrabajador.TabIndex = 0
        '
        'lblNombreTrabajador
        '
        Me.lblNombreTrabajador.AutoSize = True
        Me.lblNombreTrabajador.Location = New System.Drawing.Point(12, 43)
        Me.lblNombreTrabajador.Name = "lblNombreTrabajador"
        Me.lblNombreTrabajador.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreTrabajador.TabIndex = 4
        Me.lblNombreTrabajador.Text = "."
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(103, 92)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(92, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(195, 92)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(92, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Frm_Nomina_TrabajadorAdicional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 127)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblNombreTrabajador)
        Me.Controls.Add(Me.txtCodigoTrabajador)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.lblDisplayFecha)
        Me.Controls.Add(Me.lblDisplayCodigoTrbajador)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_TrabajadorAdicional"
        Me.Text = "Trabajador adicional"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDisplayCodigoTrbajador As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCodigoTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTrabajador As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
