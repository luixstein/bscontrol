<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_IVA_Acreditable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_IVA_Acreditable))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFilrarCobradosMes = New System.Windows.Forms.CheckBox()
        Me.gbAgrupado = New System.Windows.Forms.GroupBox()
        Me.RdbProveedor = New System.Windows.Forms.RadioButton()
        Me.RdbPoliza = New System.Windows.Forms.RadioButton()
        Me.lblNombreProveedor = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbEstatusPoliza = New System.Windows.Forms.ComboBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CmbEstatusIva = New System.Windows.Forms.ComboBox()
        Me.txtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbFormatoSAT = New System.Windows.Forms.RadioButton()
        Me.RdbDetalle = New System.Windows.Forms.RadioButton()
        Me.RdbGlobal = New System.Windows.Forms.RadioButton()
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.LblEjercicio = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblTotalIVAAcreditable16 = New System.Windows.Forms.Label()
        Me.lblTotalIVARetenido4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotalActos = New System.Windows.Forms.Label()
        Me.lblTotalActos0 = New System.Windows.Forms.Label()
        Me.lblTotalActos16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdGeneraArchivoBatch = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbAgrupado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(574, 25)
        Me.ToolStrip1.TabIndex = 2
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFilrarCobradosMes)
        Me.GroupBox1.Controls.Add(Me.gbAgrupado)
        Me.GroupBox1.Controls.Add(Me.lblNombreProveedor)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CmbEstatusPoliza)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.CmbEstatusIva)
        Me.GroupBox1.Controls.Add(Me.txtCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.LblEjercicio)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 273)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'chkFilrarCobradosMes
        '
        Me.chkFilrarCobradosMes.AutoSize = True
        Me.chkFilrarCobradosMes.Location = New System.Drawing.Point(165, 211)
        Me.chkFilrarCobradosMes.Name = "chkFilrarCobradosMes"
        Me.chkFilrarCobradosMes.Size = New System.Drawing.Size(146, 17)
        Me.chkFilrarCobradosMes.TabIndex = 259
        Me.chkFilrarCobradosMes.Text = "Filtrar cobrados en el mes"
        Me.chkFilrarCobradosMes.UseVisualStyleBackColor = True
        '
        'gbAgrupado
        '
        Me.gbAgrupado.Controls.Add(Me.RdbProveedor)
        Me.gbAgrupado.Controls.Add(Me.RdbPoliza)
        Me.gbAgrupado.Location = New System.Drawing.Point(165, 136)
        Me.gbAgrupado.Name = "gbAgrupado"
        Me.gbAgrupado.Size = New System.Drawing.Size(144, 69)
        Me.gbAgrupado.TabIndex = 258
        Me.gbAgrupado.TabStop = False
        Me.gbAgrupado.Text = "Agrupado por :"
        '
        'RdbProveedor
        '
        Me.RdbProveedor.AutoSize = True
        Me.RdbProveedor.Checked = True
        Me.RdbProveedor.Location = New System.Drawing.Point(27, 20)
        Me.RdbProveedor.Name = "RdbProveedor"
        Me.RdbProveedor.Size = New System.Drawing.Size(74, 17)
        Me.RdbProveedor.TabIndex = 0
        Me.RdbProveedor.TabStop = True
        Me.RdbProveedor.Text = "Proveedor"
        Me.RdbProveedor.UseVisualStyleBackColor = True
        '
        'RdbPoliza
        '
        Me.RdbPoliza.AutoSize = True
        Me.RdbPoliza.Location = New System.Drawing.Point(27, 43)
        Me.RdbPoliza.Name = "RdbPoliza"
        Me.RdbPoliza.Size = New System.Drawing.Size(53, 17)
        Me.RdbPoliza.TabIndex = 1
        Me.RdbPoliza.Text = "Póliza"
        Me.RdbPoliza.UseVisualStyleBackColor = True
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.BackColor = System.Drawing.Color.White
        Me.lblNombreProveedor.Location = New System.Drawing.Point(9, 120)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreProveedor.TabIndex = 257
        Me.lblNombreProveedor.Text = " "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(162, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 256
        Me.Label10.Text = "Estatus póliza:"
        '
        'CmbEstatusPoliza
        '
        Me.CmbEstatusPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstatusPoliza.FormattingEnabled = True
        Me.CmbEstatusPoliza.Items.AddRange(New Object() {"A", "G", "T"})
        Me.CmbEstatusPoliza.Location = New System.Drawing.Point(246, 234)
        Me.CmbEstatusPoliza.MaxLength = 1
        Me.CmbEstatusPoliza.Name = "CmbEstatusPoliza"
        Me.CmbEstatusPoliza.Size = New System.Drawing.Size(57, 21)
        Me.CmbEstatusPoliza.TabIndex = 5
        '
        'LblEstatus
        '
        Me.LblEstatus.Location = New System.Drawing.Point(9, 226)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(77, 29)
        Me.LblEstatus.TabIndex = 254
        Me.LblEstatus.Text = "Estatus documento :"
        '
        'CmbEstatusIva
        '
        Me.CmbEstatusIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstatusIva.FormattingEnabled = True
        Me.CmbEstatusIva.Items.AddRange(New Object() {"A", "G", "T"})
        Me.CmbEstatusIva.Location = New System.Drawing.Point(92, 234)
        Me.CmbEstatusIva.MaxLength = 1
        Me.CmbEstatusIva.Name = "CmbEstatusIva"
        Me.CmbEstatusIva.Size = New System.Drawing.Size(57, 21)
        Me.CmbEstatusIva.TabIndex = 4
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(103, 92)
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoProveedor.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "Código proveedor:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFormatoSAT)
        Me.GroupBox2.Controls.Add(Me.RdbDetalle)
        Me.GroupBox2.Controls.Add(Me.RdbGlobal)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(144, 87)
        Me.GroupBox2.TabIndex = 249
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de reporte :"
        '
        'rbFormatoSAT
        '
        Me.rbFormatoSAT.AutoSize = True
        Me.rbFormatoSAT.Location = New System.Drawing.Point(27, 66)
        Me.rbFormatoSAT.Name = "rbFormatoSAT"
        Me.rbFormatoSAT.Size = New System.Drawing.Size(87, 17)
        Me.rbFormatoSAT.TabIndex = 2
        Me.rbFormatoSAT.Text = "Formato SAT"
        Me.rbFormatoSAT.UseVisualStyleBackColor = True
        '
        'RdbDetalle
        '
        Me.RdbDetalle.AutoSize = True
        Me.RdbDetalle.Checked = True
        Me.RdbDetalle.Location = New System.Drawing.Point(27, 20)
        Me.RdbDetalle.Name = "RdbDetalle"
        Me.RdbDetalle.Size = New System.Drawing.Size(58, 17)
        Me.RdbDetalle.TabIndex = 0
        Me.RdbDetalle.TabStop = True
        Me.RdbDetalle.Text = "Detalle"
        Me.RdbDetalle.UseVisualStyleBackColor = True
        '
        'RdbGlobal
        '
        Me.RdbGlobal.AutoSize = True
        Me.RdbGlobal.Location = New System.Drawing.Point(27, 43)
        Me.RdbGlobal.Name = "RdbGlobal"
        Me.RdbGlobal.Size = New System.Drawing.Size(55, 17)
        Me.RdbGlobal.TabIndex = 1
        Me.RdbGlobal.Text = "Global"
        Me.RdbGlobal.UseVisualStyleBackColor = True
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(103, 13)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(200, 21)
        Me.CmbEjercicio.TabIndex = 0
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(9, 21)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 246
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(103, 40)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(200, 20)
        Me.DtFechaDesde.TabIndex = 1
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(9, 46)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 247
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "Hasta la fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(103, 66)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(200, 20)
        Me.DtFechaHasta.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblTotalIVAAcreditable16)
        Me.GroupBox3.Controls.Add(Me.lblTotalIVARetenido4)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.lblTotalActos)
        Me.GroupBox3.Controls.Add(Me.lblTotalActos0)
        Me.GroupBox3.Controls.Add(Me.lblTotalActos16)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmdGeneraArchivoBatch)
        Me.GroupBox3.Location = New System.Drawing.Point(353, 103)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(199, 198)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'lblTotalIVAAcreditable16
        '
        Me.lblTotalIVAAcreditable16.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalIVAAcreditable16.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalIVAAcreditable16.Location = New System.Drawing.Point(91, 148)
        Me.lblTotalIVAAcreditable16.Name = "lblTotalIVAAcreditable16"
        Me.lblTotalIVAAcreditable16.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalIVAAcreditable16.TabIndex = 255
        Me.lblTotalIVAAcreditable16.Text = "0.00"
        Me.lblTotalIVAAcreditable16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalIVARetenido4
        '
        Me.lblTotalIVARetenido4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalIVARetenido4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalIVARetenido4.Location = New System.Drawing.Point(91, 170)
        Me.lblTotalIVARetenido4.Name = "lblTotalIVARetenido4"
        Me.lblTotalIVARetenido4.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalIVARetenido4.TabIndex = 256
        Me.lblTotalIVARetenido4.Text = "0.00"
        Me.lblTotalIVARetenido4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 254
        Me.Label7.Text = "IVA acred 16% :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 253
        Me.Label9.Text = "IVA retenido 4 :"
        '
        'lblTotalActos
        '
        Me.lblTotalActos.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalActos.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalActos.Location = New System.Drawing.Point(91, 124)
        Me.lblTotalActos.Name = "lblTotalActos"
        Me.lblTotalActos.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalActos.TabIndex = 252
        Me.lblTotalActos.Text = "0.00"
        Me.lblTotalActos.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalActos0
        '
        Me.lblTotalActos0.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalActos0.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalActos0.Location = New System.Drawing.Point(91, 76)
        Me.lblTotalActos0.Name = "lblTotalActos0"
        Me.lblTotalActos0.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalActos0.TabIndex = 250
        Me.lblTotalActos0.Text = "0.00"
        Me.lblTotalActos0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalActos16
        '
        Me.lblTotalActos16.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalActos16.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTotalActos16.Location = New System.Drawing.Point(91, 100)
        Me.lblTotalActos16.Name = "lblTotalActos16"
        Me.lblTotalActos16.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalActos16.TabIndex = 251
        Me.lblTotalActos16.Text = "0.00"
        Me.lblTotalActos16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total actos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Al 16% :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Al 0% :"
        '
        'cmdGeneraArchivoBatch
        '
        Me.cmdGeneraArchivoBatch.Location = New System.Drawing.Point(9, 19)
        Me.cmdGeneraArchivoBatch.Name = "cmdGeneraArchivoBatch"
        Me.cmdGeneraArchivoBatch.Size = New System.Drawing.Size(177, 43)
        Me.cmdGeneraArchivoBatch.TabIndex = 0
        Me.cmdGeneraArchivoBatch.Text = "Genera archivo para carga batch"
        Me.cmdGeneraArchivoBatch.UseVisualStyleBackColor = True
        '
        'Frm_Contabilidad_IVA_Acreditable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 315)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_IVA_Acreditable"
        Me.Text = "Reporte de iva por acreditar"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbAgrupado.ResumeLayout(False)
        Me.gbAgrupado.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents RdbGlobal As System.Windows.Forms.RadioButton
    Friend WithEvents RdbDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbEstatusPoliza As System.Windows.Forms.ComboBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CmbEstatusIva As System.Windows.Forms.ComboBox
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNombreProveedor As System.Windows.Forms.Label
    Friend WithEvents gbAgrupado As System.Windows.Forms.GroupBox
    Friend WithEvents RdbProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents RdbPoliza As System.Windows.Forms.RadioButton
    Friend WithEvents rbFormatoSAT As System.Windows.Forms.RadioButton
    Friend WithEvents chkFilrarCobradosMes As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdGeneraArchivoBatch As System.Windows.Forms.Button
    Friend WithEvents lblTotalActos As System.Windows.Forms.Label
    Friend WithEvents lblTotalActos0 As System.Windows.Forms.Label
    Friend WithEvents lblTotalActos16 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIVAAcreditable16 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIVARetenido4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
