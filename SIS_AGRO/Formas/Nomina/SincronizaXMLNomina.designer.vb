<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizaXMLNomina
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
        Me.btnSincronizaSys = New System.Windows.Forms.Button()
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnBuscaArchivo = New System.Windows.Forms.Button()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssDuracion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSincronizaAgrinet = New System.Windows.Forms.Button()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTurno = New System.Windows.Forms.Label()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSincronizaSys
        '
        Me.btnSincronizaSys.Location = New System.Drawing.Point(425, 74)
        Me.btnSincronizaSys.Name = "btnSincronizaSys"
        Me.btnSincronizaSys.Size = New System.Drawing.Size(145, 23)
        Me.btnSincronizaSys.TabIndex = 0
        Me.btnSincronizaSys.Text = "Sincroniza Sys21"
        Me.btnSincronizaSys.UseVisualStyleBackColor = True
        Me.btnSincronizaSys.Visible = False
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Location = New System.Drawing.Point(67, 19)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.Size = New System.Drawing.Size(427, 20)
        Me.txtRutaArchivo.TabIndex = 1
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(12, 22)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(49, 13)
        Me.lblArchivo.TabIndex = 2
        Me.lblArchivo.Text = "Archivo :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(67, 45)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(427, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(500, 16)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(145, 23)
        Me.btnBuscaArchivo.TabIndex = 4
        Me.btnBuscaArchivo.Text = "Buscar archivo"
        Me.btnBuscaArchivo.UseVisualStyleBackColor = True
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssDuracion})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 99)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(651, 24)
        Me.StatusStripEstado.TabIndex = 186
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssDuracion
        '
        Me.tssDuracion.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssDuracion.Name = "tssDuracion"
        Me.tssDuracion.Size = New System.Drawing.Size(128, 19)
        Me.tssDuracion.Text = "Tiempo de ejecución :"
        '
        'btnSincronizaAgrinet
        '
        Me.btnSincronizaAgrinet.Location = New System.Drawing.Point(500, 45)
        Me.btnSincronizaAgrinet.Name = "btnSincronizaAgrinet"
        Me.btnSincronizaAgrinet.Size = New System.Drawing.Size(145, 23)
        Me.btnSincronizaAgrinet.TabIndex = 187
        Me.btnSincronizaAgrinet.Text = "Sincroniza"
        Me.btnSincronizaAgrinet.UseVisualStyleBackColor = True
        '
        'cboTurno
        '
        Me.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Items.AddRange(New Object() {"MAÑANA", "TARDE"})
        Me.cboTurno.Location = New System.Drawing.Point(67, 74)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(150, 21)
        Me.cboTurno.TabIndex = 383
        '
        'lblDisplayTurno
        '
        Me.lblDisplayTurno.AutoSize = True
        Me.lblDisplayTurno.Location = New System.Drawing.Point(12, 77)
        Me.lblDisplayTurno.Name = "lblDisplayTurno"
        Me.lblDisplayTurno.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayTurno.TabIndex = 384
        Me.lblDisplayTurno.Text = "Turno :"
        '
        'SincronizaXMLNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 123)
        Me.Controls.Add(Me.cboTurno)
        Me.Controls.Add(Me.lblDisplayTurno)
        Me.Controls.Add(Me.btnSincronizaAgrinet)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.btnBuscaArchivo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblArchivo)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.Controls.Add(Me.btnSincronizaSys)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "SincronizaXMLNomina"
        Me.Text = "SincronizaXMLNomina"
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSincronizaSys As System.Windows.Forms.Button
    Friend WithEvents txtRutaArchivo As System.Windows.Forms.TextBox
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnBuscaArchivo As System.Windows.Forms.Button
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssDuracion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnSincronizaAgrinet As System.Windows.Forms.Button
    Friend WithEvents cboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTurno As System.Windows.Forms.Label
End Class
