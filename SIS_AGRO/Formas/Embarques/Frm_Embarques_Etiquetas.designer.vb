<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_Etiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_Etiquetas))
        Me.gbEtiquetas = New System.Windows.Forms.GroupBox
        Me.rbnLand2013 = New System.Windows.Forms.RadioButton
        Me.rbnLand = New System.Windows.Forms.RadioButton
        Me.rbnMastronardi = New System.Windows.Forms.RadioButton
        Me.cboImpresora = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.gbDetalle = New System.Windows.Forms.GroupBox
        Me.lblDisplayMalla = New System.Windows.Forms.Label
        Me.txtMalla = New System.Windows.Forms.TextBox
        Me.lblArticulo = New System.Windows.Forms.Label
        Me.txtCodigoArticulo = New System.Windows.Forms.TextBox
        Me.lblDisplayRango = New System.Windows.Forms.Label
        Me.txtRango = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtFecha = New System.Windows.Forms.DateTimePicker
        Me.lblDisplayCantidad = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.gbEtiquetas.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.gbDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbEtiquetas
        '
        Me.gbEtiquetas.Controls.Add(Me.rbnLand2013)
        Me.gbEtiquetas.Controls.Add(Me.rbnLand)
        Me.gbEtiquetas.Controls.Add(Me.rbnMastronardi)
        Me.gbEtiquetas.Location = New System.Drawing.Point(0, 28)
        Me.gbEtiquetas.Name = "gbEtiquetas"
        Me.gbEtiquetas.Size = New System.Drawing.Size(145, 85)
        Me.gbEtiquetas.TabIndex = 0
        Me.gbEtiquetas.TabStop = False
        Me.gbEtiquetas.Text = "Eliga el tipo de etiqueta :"
        '
        'rbnLand2013
        '
        Me.rbnLand2013.AutoSize = True
        Me.rbnLand2013.Location = New System.Drawing.Point(9, 39)
        Me.rbnLand2013.Name = "rbnLand2013"
        Me.rbnLand2013.Size = New System.Drawing.Size(118, 17)
        Me.rbnLand2013.TabIndex = 2
        Me.rbnLand2013.Text = "Land produce 2013"
        Me.rbnLand2013.UseVisualStyleBackColor = True
        '
        'rbnLand
        '
        Me.rbnLand.AutoSize = True
        Me.rbnLand.Checked = True
        Me.rbnLand.Location = New System.Drawing.Point(9, 19)
        Me.rbnLand.Name = "rbnLand"
        Me.rbnLand.Size = New System.Drawing.Size(118, 17)
        Me.rbnLand.TabIndex = 0
        Me.rbnLand.TabStop = True
        Me.rbnLand.Text = "Land produce 2012"
        Me.rbnLand.UseVisualStyleBackColor = True
        '
        'rbnMastronardi
        '
        Me.rbnMastronardi.AutoSize = True
        Me.rbnMastronardi.Location = New System.Drawing.Point(9, 62)
        Me.rbnMastronardi.Name = "rbnMastronardi"
        Me.rbnMastronardi.Size = New System.Drawing.Size(80, 17)
        Me.rbnMastronardi.TabIndex = 1
        Me.rbnMastronardi.Text = "Mastronardi"
        Me.rbnMastronardi.UseVisualStyleBackColor = True
        '
        'cboImpresora
        '
        Me.cboImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImpresora.FormattingEnabled = True
        Me.cboImpresora.Location = New System.Drawing.Point(250, 35)
        Me.cboImpresora.Name = "cboImpresora"
        Me.cboImpresora.Size = New System.Drawing.Size(233, 21)
        Me.cboImpresora.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(185, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Impresora :"
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbImprimir, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(535, 25)
        Me.tsMenu.TabIndex = 3
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(62, 22)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.lblDisplayMalla)
        Me.gbDetalle.Controls.Add(Me.txtMalla)
        Me.gbDetalle.Controls.Add(Me.lblArticulo)
        Me.gbDetalle.Controls.Add(Me.txtCodigoArticulo)
        Me.gbDetalle.Controls.Add(Me.lblDisplayRango)
        Me.gbDetalle.Controls.Add(Me.txtRango)
        Me.gbDetalle.Controls.Add(Me.Label3)
        Me.gbDetalle.Controls.Add(Me.dtFecha)
        Me.gbDetalle.Controls.Add(Me.lblDisplayCantidad)
        Me.gbDetalle.Controls.Add(Me.txtCantidad)
        Me.gbDetalle.Controls.Add(Me.Label1)
        Me.gbDetalle.Location = New System.Drawing.Point(0, 119)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(523, 143)
        Me.gbDetalle.TabIndex = 2
        Me.gbDetalle.TabStop = False
        Me.gbDetalle.Text = "Detalle :"
        '
        'lblDisplayMalla
        '
        Me.lblDisplayMalla.AutoSize = True
        Me.lblDisplayMalla.Location = New System.Drawing.Point(6, 108)
        Me.lblDisplayMalla.Name = "lblDisplayMalla"
        Me.lblDisplayMalla.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayMalla.TabIndex = 280
        Me.lblDisplayMalla.Text = "Malla :"
        '
        'txtMalla
        '
        Me.txtMalla.Location = New System.Drawing.Point(90, 105)
        Me.txtMalla.MaxLength = 20
        Me.txtMalla.Name = "txtMalla"
        Me.txtMalla.Size = New System.Drawing.Size(100, 20)
        Me.txtMalla.TabIndex = 4
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(221, 26)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(296, 13)
        Me.lblArticulo.TabIndex = 278
        Me.lblArticulo.Text = "_"
        '
        'txtCodigoArticulo
        '
        Me.txtCodigoArticulo.Location = New System.Drawing.Point(90, 27)
        Me.txtCodigoArticulo.MaxLength = 16
        Me.txtCodigoArticulo.Name = "txtCodigoArticulo"
        Me.txtCodigoArticulo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoArticulo.TabIndex = 0
        '
        'lblDisplayRango
        '
        Me.lblDisplayRango.AutoSize = True
        Me.lblDisplayRango.Location = New System.Drawing.Point(6, 82)
        Me.lblDisplayRango.Name = "lblDisplayRango"
        Me.lblDisplayRango.Size = New System.Drawing.Size(78, 13)
        Me.lblDisplayRango.TabIndex = 7
        Me.lblDisplayRango.Text = "Rango piezas :"
        '
        'txtRango
        '
        Me.txtRango.Location = New System.Drawing.Point(90, 79)
        Me.txtRango.MaxLength = 20
        Me.txtRango.Name = "txtRango"
        Me.txtRango.Size = New System.Drawing.Size(100, 20)
        Me.txtRango.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(221, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha empaque :"
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(317, 53)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtFecha.TabIndex = 2
        '
        'lblDisplayCantidad
        '
        Me.lblDisplayCantidad.AutoSize = True
        Me.lblDisplayCantidad.Location = New System.Drawing.Point(7, 56)
        Me.lblDisplayCantidad.Name = "lblDisplayCantidad"
        Me.lblDisplayCantidad.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayCantidad.TabIndex = 3
        Me.lblDisplayCantidad.Text = "Cantidad :"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(90, 53)
        Me.txtCantidad.MaxLength = 4
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 1
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Producto :"
        '
        'PrintDocument1
        '
        '
        'Frm_Embarques_Etiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 270)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboImpresora)
        Me.Controls.Add(Me.gbEtiquetas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_Etiquetas"
        Me.Text = "Etiquetas"
        Me.gbEtiquetas.ResumeLayout(False)
        Me.gbEtiquetas.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbEtiquetas As System.Windows.Forms.GroupBox
    Friend WithEvents rbnLand As System.Windows.Forms.RadioButton
    Friend WithEvents rbnMastronardi As System.Windows.Forms.RadioButton
    Friend WithEvents cboImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayRango As System.Windows.Forms.Label
    Friend WithEvents txtRango As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayCantidad As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents rbnLand2013 As System.Windows.Forms.RadioButton
    Friend WithEvents lblDisplayMalla As System.Windows.Forms.Label
    Friend WithEvents txtMalla As System.Windows.Forms.TextBox
End Class
