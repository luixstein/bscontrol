<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CFDI_GrabaImagenQR
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
        Me.cboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.lblDisplayFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblDisplayTipoDocumento = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.FormattingEnabled = True
        Me.cboTipoDocumento.Location = New System.Drawing.Point(103, 26)
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(178, 21)
        Me.cboTipoDocumento.TabIndex = 0
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(103, 97)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabar.TabIndex = 1
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'lblDisplayFolio
        '
        Me.lblDisplayFolio.AutoSize = True
        Me.lblDisplayFolio.Location = New System.Drawing.Point(21, 56)
        Me.lblDisplayFolio.Name = "lblDisplayFolio"
        Me.lblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.lblDisplayFolio.TabIndex = 226
        Me.lblDisplayFolio.Text = "Folio :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(103, 53)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(83, 20)
        Me.txtFolio.TabIndex = 225
        '
        'lblDisplayTipoDocumento
        '
        Me.lblDisplayTipoDocumento.AutoSize = True
        Me.lblDisplayTipoDocumento.Location = New System.Drawing.Point(21, 29)
        Me.lblDisplayTipoDocumento.Name = "lblDisplayTipoDocumento"
        Me.lblDisplayTipoDocumento.Size = New System.Drawing.Size(68, 13)
        Me.lblDisplayTipoDocumento.TabIndex = 227
        Me.lblDisplayTipoDocumento.Text = "Documento :"
        '
        'Frm_CFDI_GrabaImagenQR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 149)
        Me.Controls.Add(Me.lblDisplayTipoDocumento)
        Me.Controls.Add(Me.lblDisplayFolio)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.cboTipoDocumento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CFDI_GrabaImagenQR"
        Me.Text = "Frm_CFDI_GrabaImagenQR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboTipoDocumento As ComboBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents lblDisplayFolio As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents lblDisplayTipoDocumento As Label
End Class
