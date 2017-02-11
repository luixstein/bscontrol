<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizaXMLAsistencia
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
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnBuscaArchivo = New System.Windows.Forms.Button()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.btnSincronizaAgrinet = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Location = New System.Drawing.Point(89, 23)
        Me.txtRutaArchivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.Size = New System.Drawing.Size(568, 22)
        Me.txtRutaArchivo.TabIndex = 1
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(16, 27)
        Me.lblArchivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(63, 17)
        Me.lblArchivo.TabIndex = 2
        Me.lblArchivo.Text = "Archivo :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(89, 55)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(569, 28)
        Me.ProgressBar1.TabIndex = 3
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(667, 20)
        Me.btnBuscaArchivo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(193, 28)
        Me.btnBuscaArchivo.TabIndex = 4
        Me.btnBuscaArchivo.Text = "Buscar archivo"
        Me.btnBuscaArchivo.UseVisualStyleBackColor = True
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 129)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(868, 22)
        Me.StatusStripEstado.TabIndex = 186
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'btnSincronizaAgrinet
        '
        Me.btnSincronizaAgrinet.Location = New System.Drawing.Point(667, 55)
        Me.btnSincronizaAgrinet.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSincronizaAgrinet.Name = "btnSincronizaAgrinet"
        Me.btnSincronizaAgrinet.Size = New System.Drawing.Size(193, 28)
        Me.btnSincronizaAgrinet.TabIndex = 187
        Me.btnSincronizaAgrinet.Text = "Sincroniza"
        Me.btnSincronizaAgrinet.UseVisualStyleBackColor = True
        '
        'SincronizaXMLAsistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 151)
        Me.Controls.Add(Me.btnSincronizaAgrinet)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.btnBuscaArchivo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblArchivo)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "SincronizaXMLAsistencia"
        Me.Text = "SincronizaXMLAsistencia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRutaArchivo As System.Windows.Forms.TextBox
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnBuscaArchivo As System.Windows.Forms.Button
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents btnSincronizaAgrinet As System.Windows.Forms.Button
End Class
