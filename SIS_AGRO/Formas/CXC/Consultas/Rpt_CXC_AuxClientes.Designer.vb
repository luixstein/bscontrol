<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_CXC_AuxClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_CXC_AuxClientes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblDisplayFechaFinal = New System.Windows.Forms.Label
        Me.lblDisplayFechaInicio = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.lblDisplayCliente = New System.Windows.Forms.Label
        Me.LblDisplayDocumento = New System.Windows.Forms.Label
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.CboDocumentos = New System.Windows.Forms.ComboBox
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaFinal)
        Me.GroupBox1.Controls.Add(Me.lblDisplayFechaInicio)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox1.Controls.Add(Me.LblDisplayDocumento)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.CboDocumentos)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'LblDisplayFechaFinal
        '
        Me.LblDisplayFechaFinal.AutoSize = True
        Me.LblDisplayFechaFinal.Location = New System.Drawing.Point(4, 85)
        Me.LblDisplayFechaFinal.Name = "LblDisplayFechaFinal"
        Me.LblDisplayFechaFinal.Size = New System.Drawing.Size(41, 13)
        Me.LblDisplayFechaFinal.TabIndex = 270
        Me.LblDisplayFechaFinal.Text = "Hasta :"
        '
        'lblDisplayFechaInicio
        '
        Me.lblDisplayFechaInicio.AutoSize = True
        Me.lblDisplayFechaInicio.Location = New System.Drawing.Point(4, 56)
        Me.lblDisplayFechaInicio.Name = "lblDisplayFechaInicio"
        Me.lblDisplayFechaInicio.Size = New System.Drawing.Size(44, 13)
        Me.lblDisplayFechaInicio.TabIndex = 269
        Me.lblDisplayFechaInicio.Text = "Desde :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = "dd-MMM-yyyy"
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaHasta.Location = New System.Drawing.Point(88, 81)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(124, 20)
        Me.DtFechaHasta.TabIndex = 2
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = "dd-MMM-yyyy"
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaDesde.Location = New System.Drawing.Point(88, 52)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(124, 20)
        Me.DtFechaDesde.TabIndex = 1
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(4, 27)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 254
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'LblDisplayDocumento
        '
        Me.LblDisplayDocumento.AutoSize = True
        Me.LblDisplayDocumento.Location = New System.Drawing.Point(4, 113)
        Me.LblDisplayDocumento.Name = "LblDisplayDocumento"
        Me.LblDisplayDocumento.Size = New System.Drawing.Size(73, 13)
        Me.LblDisplayDocumento.TabIndex = 259
        Me.LblDisplayDocumento.Text = "Documentos :"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(88, 23)
        Me.txtCodigoCliente.MaxLength = 15
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(49, 20)
        Me.txtCodigoCliente.TabIndex = 0
        Me.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CboDocumentos
        '
        Me.CboDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumentos.FormattingEnabled = True
        Me.CboDocumentos.Location = New System.Drawing.Point(88, 109)
        Me.CboDocumentos.MaxLength = 1
        Me.CboDocumentos.Name = "CboDocumentos"
        Me.CboDocumentos.Size = New System.Drawing.Size(133, 21)
        Me.CboDocumentos.TabIndex = 3
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(143, 27)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreCliente.TabIndex = 255
        Me.lblNombreCliente.Text = "."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(418, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'Rpt_CXC_AuxClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 168)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_CXC_AuxClientes"
        Me.Text = "Auxiliar de clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayFechaFinal As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaInicio As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents LblDisplayDocumento As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents CboDocumentos As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
