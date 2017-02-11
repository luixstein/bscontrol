<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtileriasGeneraInformeMensual
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
        Me.dtpAño = New System.Windows.Forms.DateTimePicker
        Me.dtpMes = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtRuta = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnGenerarInforme = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboEstado = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpAño
        '
        Me.dtpAño.CustomFormat = "yyyy"
        Me.dtpAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAño.Location = New System.Drawing.Point(114, 45)
        Me.dtpAño.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpAño.Name = "dtpAño"
        Me.dtpAño.Size = New System.Drawing.Size(162, 20)
        Me.dtpAño.TabIndex = 7
        '
        'dtpMes
        '
        Me.dtpMes.CustomFormat = "MMMM"
        Me.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMes.Location = New System.Drawing.Point(114, 19)
        Me.dtpMes.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpMes.Name = "dtpMes"
        Me.dtpMes.Size = New System.Drawing.Size(162, 20)
        Me.dtpMes.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRuta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnGenerarInforme)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpAño)
        Me.GroupBox1.Controls.Add(Me.dtpMes)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 131)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informe mensual de CFD's"
        '
        'txtRuta
        '
        Me.txtRuta.Enabled = False
        Me.txtRuta.Location = New System.Drawing.Point(114, 71)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(162, 20)
        Me.txtRuta.TabIndex = 12
        Me.txtRuta.Text = "c:\agrinet\informes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Ruta de guardado :"
        '
        'btnGenerarInforme
        '
        Me.btnGenerarInforme.AutoSize = True
        Me.btnGenerarInforme.Location = New System.Drawing.Point(184, 97)
        Me.btnGenerarInforme.Name = "btnGenerarInforme"
        Me.btnGenerarInforme.Size = New System.Drawing.Size(92, 23)
        Me.btnGenerarInforme.TabIndex = 10
        Me.btnGenerarInforme.Text = "Generar informe"
        Me.btnGenerarInforme.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Año a generar :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mes a generar :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEstado)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 77)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reporte"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"ACTIVOS", "CANCELADOS"})
        Me.cboEstado.Location = New System.Drawing.Point(114, 19)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(162, 21)
        Me.cboEstado.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.Location = New System.Drawing.Point(184, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Ver reporte"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Estado de CFD's :"
        '
        'UtileriasGeneraInformeMensual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 231)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "UtileriasGeneraInformeMensual"
        Me.Text = "Genera informe mensual CFD's"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpAño As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpMes As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGenerarInforme As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
