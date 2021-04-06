<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TipoCambioDia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TipoCambioDia))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTipoCambio = New System.Windows.Forms.TextBox()
        Me.dpFecha = New System.Windows.Forms.DateTimePicker()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslCapturo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(323, 27)
        Me.tsMenu.TabIndex = 3
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(78, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 17)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Tipo de cambio del :"
        '
        'TxtTipoCambio
        '
        Me.TxtTipoCambio.Location = New System.Drawing.Point(16, 79)
        Me.TxtTipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTipoCambio.MaxLength = 8
        Me.TxtTipoCambio.Name = "TxtTipoCambio"
        Me.TxtTipoCambio.Size = New System.Drawing.Size(106, 22)
        Me.TxtTipoCambio.TabIndex = 24
        Me.TxtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dpFecha
        '
        Me.dpFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dpFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(157, 38)
        Me.dpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(136, 22)
        Me.dpFecha.TabIndex = 25
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslCapturo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 134)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(323, 29)
        Me.StatusStripEstado.TabIndex = 258
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tsslCapturo
        '
        Me.tsslCapturo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCapturo.Name = "tsslCapturo"
        Me.tsslCapturo.Size = New System.Drawing.Size(73, 24)
        Me.tsslCapturo.Text = "Capturo :"
        '
        'TipoCambioDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 163)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.dpFecha)
        Me.Controls.Add(Me.TxtTipoCambio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tsMenu)
        Me.Name = "TipoCambioDia"
        Me.Text = "TipoCambioDia"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslCapturo As System.Windows.Forms.ToolStripStatusLabel
End Class
