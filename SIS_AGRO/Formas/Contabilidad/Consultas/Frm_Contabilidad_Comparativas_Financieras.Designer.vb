<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Comparativas_Financieras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Comparativas_Financieras))
        Me.CmbEjercicio1 = New System.Windows.Forms.ComboBox
        Me.RdbBalanzaComprobacion = New System.Windows.Forms.RadioButton
        Me.RdbRelacionAnalitica = New System.Windows.Forms.RadioButton
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.CmbEjercicio2 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DtFechaHasta2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.DtFechaDesde2 = New System.Windows.Forms.DateTimePicker
        Me.lblCuenta2 = New System.Windows.Forms.Label
        Me.lblCuenta1 = New System.Windows.Forms.Label
        Me.lblDisplayALaCuenta = New System.Windows.Forms.Label
        Me.TxtCuenta2 = New System.Windows.Forms.TextBox
        Me.LblDisplayDeLaCuenta = New System.Windows.Forms.Label
        Me.TxtCuenta1 = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbEjercicio1
        '
        Me.CmbEjercicio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio1.FormattingEnabled = True
        Me.CmbEjercicio1.Location = New System.Drawing.Point(93, 55)
        Me.CmbEjercicio1.MaxLength = 1
        Me.CmbEjercicio1.Name = "CmbEjercicio1"
        Me.CmbEjercicio1.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio1.TabIndex = 224
        '
        'RdbBalanzaComprobacion
        '
        Me.RdbBalanzaComprobacion.AutoSize = True
        Me.RdbBalanzaComprobacion.Location = New System.Drawing.Point(270, 28)
        Me.RdbBalanzaComprobacion.Name = "RdbBalanzaComprobacion"
        Me.RdbBalanzaComprobacion.Size = New System.Drawing.Size(167, 17)
        Me.RdbBalanzaComprobacion.TabIndex = 218
        Me.RdbBalanzaComprobacion.Text = "&Estado de situación financiera"
        Me.RdbBalanzaComprobacion.UseVisualStyleBackColor = True
        '
        'RdbRelacionAnalitica
        '
        Me.RdbRelacionAnalitica.AutoSize = True
        Me.RdbRelacionAnalitica.Checked = True
        Me.RdbRelacionAnalitica.Location = New System.Drawing.Point(37, 28)
        Me.RdbRelacionAnalitica.Name = "RdbRelacionAnalitica"
        Me.RdbRelacionAnalitica.Size = New System.Drawing.Size(191, 17)
        Me.RdbRelacionAnalitica.TabIndex = 217
        Me.RdbRelacionAnalitica.TabStop = True
        Me.RdbRelacionAnalitica.Text = "&Relaciones analiticas compararivas"
        Me.RdbRelacionAnalitica.UseVisualStyleBackColor = True
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(29, 58)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(59, 13)
        Me.LblEjercicio.TabIndex = 223
        Me.LblEjercicio.Text = "Ejercicio 1:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(234, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 222
        Me.Label1.Text = "Hasta la fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(328, 87)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaHasta.TabIndex = 220
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(20, 91)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 221
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(95, 87)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaDesde.TabIndex = 219
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(527, 25)
        Me.ToolStrip1.TabIndex = 225
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
        'CmbEjercicio2
        '
        Me.CmbEjercicio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio2.FormattingEnabled = True
        Me.CmbEjercicio2.Location = New System.Drawing.Point(93, 113)
        Me.CmbEjercicio2.MaxLength = 1
        Me.CmbEjercicio2.Name = "CmbEjercicio2"
        Me.CmbEjercicio2.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio2.TabIndex = 231
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Ejercicio 2 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(234, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "Hasta la fecha :"
        '
        'DtFechaHasta2
        '
        Me.DtFechaHasta2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta2.Location = New System.Drawing.Point(328, 145)
        Me.DtFechaHasta2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta2.Name = "DtFechaHasta2"
        Me.DtFechaHasta2.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaHasta2.TabIndex = 227
        Me.DtFechaHasta2.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 228
        Me.Label4.Text = "De la fecha :"
        '
        'DtFechaDesde2
        '
        Me.DtFechaDesde2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde2.Location = New System.Drawing.Point(95, 145)
        Me.DtFechaDesde2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde2.Name = "DtFechaDesde2"
        Me.DtFechaDesde2.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaDesde2.TabIndex = 226
        Me.DtFechaDesde2.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'lblCuenta2
        '
        Me.lblCuenta2.Location = New System.Drawing.Point(234, 198)
        Me.lblCuenta2.Name = "lblCuenta2"
        Me.lblCuenta2.Size = New System.Drawing.Size(283, 13)
        Me.lblCuenta2.TabIndex = 237
        Me.lblCuenta2.Text = "_"
        '
        'lblCuenta1
        '
        Me.lblCuenta1.Location = New System.Drawing.Point(234, 173)
        Me.lblCuenta1.Name = "lblCuenta1"
        Me.lblCuenta1.Size = New System.Drawing.Size(249, 13)
        Me.lblCuenta1.TabIndex = 236
        Me.lblCuenta1.Text = "_"
        '
        'lblDisplayALaCuenta
        '
        Me.lblDisplayALaCuenta.AutoSize = True
        Me.lblDisplayALaCuenta.Location = New System.Drawing.Point(21, 199)
        Me.lblDisplayALaCuenta.Name = "lblDisplayALaCuenta"
        Me.lblDisplayALaCuenta.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayALaCuenta.TabIndex = 235
        Me.lblDisplayALaCuenta.Text = "A la cuenta :"
        '
        'TxtCuenta2
        '
        Me.TxtCuenta2.Location = New System.Drawing.Point(95, 195)
        Me.TxtCuenta2.MaxLength = 20
        Me.TxtCuenta2.Name = "TxtCuenta2"
        Me.TxtCuenta2.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta2.TabIndex = 233
        '
        'LblDisplayDeLaCuenta
        '
        Me.LblDisplayDeLaCuenta.AutoSize = True
        Me.LblDisplayDeLaCuenta.Location = New System.Drawing.Point(14, 175)
        Me.LblDisplayDeLaCuenta.Name = "LblDisplayDeLaCuenta"
        Me.LblDisplayDeLaCuenta.Size = New System.Drawing.Size(74, 13)
        Me.LblDisplayDeLaCuenta.TabIndex = 234
        Me.LblDisplayDeLaCuenta.Text = "De la cuenta :"
        '
        'TxtCuenta1
        '
        Me.TxtCuenta1.Location = New System.Drawing.Point(95, 171)
        Me.TxtCuenta1.MaxLength = 20
        Me.TxtCuenta1.Name = "TxtCuenta1"
        Me.TxtCuenta1.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta1.TabIndex = 232
        '
        'Frm_Contabilidad_Comparativas_Financieras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 224)
        Me.Controls.Add(Me.lblCuenta2)
        Me.Controls.Add(Me.lblCuenta1)
        Me.Controls.Add(Me.lblDisplayALaCuenta)
        Me.Controls.Add(Me.TxtCuenta2)
        Me.Controls.Add(Me.LblDisplayDeLaCuenta)
        Me.Controls.Add(Me.TxtCuenta1)
        Me.Controls.Add(Me.CmbEjercicio2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtFechaHasta2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DtFechaDesde2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.CmbEjercicio1)
        Me.Controls.Add(Me.RdbBalanzaComprobacion)
        Me.Controls.Add(Me.RdbRelacionAnalitica)
        Me.Controls.Add(Me.LblEjercicio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtFechaHasta)
        Me.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.Controls.Add(Me.DtFechaDesde)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_Comparativas_Financieras"
        Me.Text = "Comparativas financieras"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmbEjercicio1 As System.Windows.Forms.ComboBox
    Friend WithEvents RdbBalanzaComprobacion As System.Windows.Forms.RadioButton
    Friend WithEvents RdbRelacionAnalitica As System.Windows.Forms.RadioButton
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmbEjercicio2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCuenta2 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta1 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayALaCuenta As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDeLaCuenta As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta1 As System.Windows.Forms.TextBox
End Class
