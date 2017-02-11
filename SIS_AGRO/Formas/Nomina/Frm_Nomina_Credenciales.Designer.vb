<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_Credenciales
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_Credenciales))
        Me.txtCodigoTrabajador1 = New System.Windows.Forms.TextBox
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.lblDisplayCodigoTrabajador1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodigoTrabajador2 = New System.Windows.Forms.TextBox
        Me.txtCodigoTrabajador4 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCodigoTrabajador3 = New System.Windows.Forms.TextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'txtCodigoTrabajador1
        '
        Me.txtCodigoTrabajador1.Location = New System.Drawing.Point(12, 74)
        Me.txtCodigoTrabajador1.MaxLength = 10
        Me.txtCodigoTrabajador1.Name = "txtCodigoTrabajador1"
        Me.txtCodigoTrabajador1.Size = New System.Drawing.Size(104, 20)
        Me.txtCodigoTrabajador1.TabIndex = 0
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(12, 22)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(104, 23)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblDisplayCodigoTrabajador1
        '
        Me.lblDisplayCodigoTrabajador1.AutoSize = True
        Me.lblDisplayCodigoTrabajador1.Location = New System.Drawing.Point(12, 58)
        Me.lblDisplayCodigoTrabajador1.Name = "lblDisplayCodigoTrabajador1"
        Me.lblDisplayCodigoTrabajador1.Size = New System.Drawing.Size(112, 13)
        Me.lblDisplayCodigoTrabajador1.TabIndex = 386
        Me.lblDisplayCodigoTrabajador1.Text = "Codigo trabajador #1 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Codigo trabajador #2 :"
        '
        'txtCodigoTrabajador2
        '
        Me.txtCodigoTrabajador2.Location = New System.Drawing.Point(12, 124)
        Me.txtCodigoTrabajador2.MaxLength = 10
        Me.txtCodigoTrabajador2.Name = "txtCodigoTrabajador2"
        Me.txtCodigoTrabajador2.Size = New System.Drawing.Size(104, 20)
        Me.txtCodigoTrabajador2.TabIndex = 1
        '
        'txtCodigoTrabajador4
        '
        Me.txtCodigoTrabajador4.Location = New System.Drawing.Point(12, 219)
        Me.txtCodigoTrabajador4.MaxLength = 10
        Me.txtCodigoTrabajador4.Name = "txtCodigoTrabajador4"
        Me.txtCodigoTrabajador4.Size = New System.Drawing.Size(104, 20)
        Me.txtCodigoTrabajador4.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 391
        Me.Label3.Text = "Codigo trabajador #4 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 390
        Me.Label4.Text = "Codigo trabajador #3 :"
        '
        'txtCodigoTrabajador3
        '
        Me.txtCodigoTrabajador3.Location = New System.Drawing.Point(12, 172)
        Me.txtCodigoTrabajador3.MaxLength = 10
        Me.txtCodigoTrabajador3.Name = "txtCodigoTrabajador3"
        Me.txtCodigoTrabajador3.Size = New System.Drawing.Size(104, 20)
        Me.txtCodigoTrabajador3.TabIndex = 2
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(151, 12)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1214, 753)
        Me.CrystalReportViewer1.TabIndex = 5
        '
        'Frm_Nomina_Credenciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1389, 777)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.txtCodigoTrabajador4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodigoTrabajador3)
        Me.Controls.Add(Me.txtCodigoTrabajador2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDisplayCodigoTrabajador1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txtCodigoTrabajador1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_Credenciales"
        Me.Text = "Credenciales"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCodigoTrabajador1 As System.Windows.Forms.TextBox
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblDisplayCodigoTrabajador1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTrabajador4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTrabajador3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTrabajador2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
