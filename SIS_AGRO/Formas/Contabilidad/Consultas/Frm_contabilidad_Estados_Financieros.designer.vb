<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_contabilidad_Estados_Financieros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_contabilidad_Estados_Financieros))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblEjercicio = New System.Windows.Forms.Label()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblNota = New System.Windows.Forms.Label()
        Me.btnPolizaNoCuadra = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbTotales = New System.Windows.Forms.RadioButton()
        Me.RdbEstadoSituacion = New System.Windows.Forms.RadioButton()
        Me.RdbSocioTarriba = New System.Windows.Forms.RadioButton()
        Me.RdbRelacionAnalitica = New System.Windows.Forms.RadioButton()
        Me.RdnBalanceGeneral = New System.Windows.Forms.RadioButton()
        Me.rdbEstadoResultados = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblCuenta2 = New System.Windows.Forms.Label()
        Me.lblCuenta1 = New System.Windows.Forms.Label()
        Me.lblDisplayALaCuenta = New System.Windows.Forms.Label()
        Me.TxtCuenta2 = New System.Windows.Forms.TextBox()
        Me.LblDisplayDeLaCuenta = New System.Windows.Forms.Label()
        Me.TxtCuenta1 = New System.Windows.Forms.TextBox()
        Me.CmbEjercicio2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtFechaHasta2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtFechaDesde2 = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(617, 25)
        Me.ToolStrip1.TabIndex = 3
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
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(89, 13)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(133, 21)
        Me.CmbEjercicio.TabIndex = 2
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(378, 36)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(222, 20)
        Me.DtFechaHasta.TabIndex = 4
        Me.DtFechaHasta.Value = New Date(2011, 12, 31, 0, 0, 0, 0)
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(89, 38)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(222, 20)
        Me.DtFechaDesde.TabIndex = 3
        Me.DtFechaDesde.Value = New Date(2011, 1, 1, 0, 0, 0, 0)
        '
        'lblEjercicio
        '
        Me.lblEjercicio.AutoSize = True
        Me.lblEjercicio.Location = New System.Drawing.Point(8, 16)
        Me.lblEjercicio.Name = "lblEjercicio"
        Me.lblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.lblEjercicio.TabIndex = 8
        Me.lblEjercicio.Text = "Ejercicio :"
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.Location = New System.Drawing.Point(8, 42)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(44, 13)
        Me.lblFechaDesde.TabIndex = 9
        Me.lblFechaDesde.Text = "Desde :"
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.Location = New System.Drawing.Point(331, 38)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(41, 13)
        Me.lblFechaHasta.TabIndex = 10
        Me.lblFechaHasta.Text = "Hasta :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEjercicio)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaHasta)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.lblFechaDesde)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 66)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'LblNota
        '
        Me.LblNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNota.ForeColor = System.Drawing.Color.Red
        Me.LblNota.Location = New System.Drawing.Point(2, 272)
        Me.LblNota.Name = "LblNota"
        Me.LblNota.Size = New System.Drawing.Size(610, 18)
        Me.LblNota.TabIndex = 12
        Me.LblNota.Text = "* El ejercicio seleccionado esta abierto y su póliza de cierre está aplicada, se " & _
    "le sugiere cerrar el ejercicio"
        Me.LblNota.Visible = False
        '
        'btnPolizaNoCuadra
        '
        Me.btnPolizaNoCuadra.Location = New System.Drawing.Point(151, 293)
        Me.btnPolizaNoCuadra.Name = "btnPolizaNoCuadra"
        Me.btnPolizaNoCuadra.Size = New System.Drawing.Size(308, 23)
        Me.btnPolizaNoCuadra.TabIndex = 11
        Me.btnPolizaNoCuadra.Text = "Ver pólizas 6x incorrectas"
        Me.btnPolizaNoCuadra.UseVisualStyleBackColor = True
        Me.btnPolizaNoCuadra.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbTotales)
        Me.GroupBox2.Controls.Add(Me.RdbEstadoSituacion)
        Me.GroupBox2.Controls.Add(Me.RdbSocioTarriba)
        Me.GroupBox2.Controls.Add(Me.RdbRelacionAnalitica)
        Me.GroupBox2.Controls.Add(Me.RdnBalanceGeneral)
        Me.GroupBox2.Controls.Add(Me.rdbEstadoResultados)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(607, 63)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'rdbTotales
        '
        Me.rdbTotales.AutoSize = True
        Me.rdbTotales.Location = New System.Drawing.Point(173, 13)
        Me.rdbTotales.Name = "rdbTotales"
        Me.rdbTotales.Size = New System.Drawing.Size(173, 17)
        Me.rdbTotales.TabIndex = 222
        Me.rdbTotales.Text = "Edo. de resultados &solo Totales"
        Me.rdbTotales.UseVisualStyleBackColor = True
        Me.rdbTotales.Visible = False
        '
        'RdbEstadoSituacion
        '
        Me.RdbEstadoSituacion.AutoSize = True
        Me.RdbEstadoSituacion.Location = New System.Drawing.Point(304, 36)
        Me.RdbEstadoSituacion.Name = "RdbEstadoSituacion"
        Me.RdbEstadoSituacion.Size = New System.Drawing.Size(235, 17)
        Me.RdbEstadoSituacion.TabIndex = 220
        Me.RdbEstadoSituacion.Text = "&Estado de cambios de la situación financiera"
        Me.RdbEstadoSituacion.UseVisualStyleBackColor = True
        Me.RdbEstadoSituacion.Visible = False
        '
        'RdbSocioTarriba
        '
        Me.RdbSocioTarriba.AutoSize = True
        Me.RdbSocioTarriba.Location = New System.Drawing.Point(500, 13)
        Me.RdbSocioTarriba.Name = "RdbSocioTarriba"
        Me.RdbSocioTarriba.Size = New System.Drawing.Size(85, 17)
        Me.RdbSocioTarriba.TabIndex = 2
        Me.RdbSocioTarriba.Text = "SocioTarriba"
        Me.RdbSocioTarriba.UseVisualStyleBackColor = True
        Me.RdbSocioTarriba.Visible = False
        '
        'RdbRelacionAnalitica
        '
        Me.RdbRelacionAnalitica.AutoSize = True
        Me.RdbRelacionAnalitica.Location = New System.Drawing.Point(57, 37)
        Me.RdbRelacionAnalitica.Name = "RdbRelacionAnalitica"
        Me.RdbRelacionAnalitica.Size = New System.Drawing.Size(222, 17)
        Me.RdbRelacionAnalitica.TabIndex = 219
        Me.RdbRelacionAnalitica.Text = "&Estado de origen y aplicación de recursos"
        Me.RdbRelacionAnalitica.UseVisualStyleBackColor = True
        Me.RdbRelacionAnalitica.Visible = False
        '
        'RdnBalanceGeneral
        '
        Me.RdnBalanceGeneral.AutoSize = True
        Me.RdnBalanceGeneral.Location = New System.Drawing.Point(378, 13)
        Me.RdnBalanceGeneral.Name = "RdnBalanceGeneral"
        Me.RdnBalanceGeneral.Size = New System.Drawing.Size(102, 17)
        Me.RdnBalanceGeneral.TabIndex = 1
        Me.RdnBalanceGeneral.Text = "Balance general"
        Me.RdnBalanceGeneral.UseVisualStyleBackColor = True
        '
        'rdbEstadoResultados
        '
        Me.rdbEstadoResultados.AutoSize = True
        Me.rdbEstadoResultados.Location = New System.Drawing.Point(22, 13)
        Me.rdbEstadoResultados.Name = "rdbEstadoResultados"
        Me.rdbEstadoResultados.Size = New System.Drawing.Size(124, 17)
        Me.rdbEstadoResultados.TabIndex = 0
        Me.rdbEstadoResultados.Text = "Estado de resultados"
        Me.rdbEstadoResultados.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblCuenta2)
        Me.GroupBox3.Controls.Add(Me.lblCuenta1)
        Me.GroupBox3.Controls.Add(Me.lblDisplayALaCuenta)
        Me.GroupBox3.Controls.Add(Me.TxtCuenta2)
        Me.GroupBox3.Controls.Add(Me.LblDisplayDeLaCuenta)
        Me.GroupBox3.Controls.Add(Me.TxtCuenta1)
        Me.GroupBox3.Controls.Add(Me.CmbEjercicio2)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.DtFechaHasta2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.DtFechaDesde2)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(5, 158)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(607, 110)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'lblCuenta2
        '
        Me.lblCuenta2.Location = New System.Drawing.Point(228, 87)
        Me.lblCuenta2.Name = "lblCuenta2"
        Me.lblCuenta2.Size = New System.Drawing.Size(373, 15)
        Me.lblCuenta2.TabIndex = 249
        Me.lblCuenta2.Text = "_"
        Me.lblCuenta2.Visible = False
        '
        'lblCuenta1
        '
        Me.lblCuenta1.Location = New System.Drawing.Point(228, 62)
        Me.lblCuenta1.Name = "lblCuenta1"
        Me.lblCuenta1.Size = New System.Drawing.Size(373, 15)
        Me.lblCuenta1.TabIndex = 248
        Me.lblCuenta1.Text = "_"
        Me.lblCuenta1.Visible = False
        '
        'lblDisplayALaCuenta
        '
        Me.lblDisplayALaCuenta.AutoSize = True
        Me.lblDisplayALaCuenta.Location = New System.Drawing.Point(8, 90)
        Me.lblDisplayALaCuenta.Name = "lblDisplayALaCuenta"
        Me.lblDisplayALaCuenta.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayALaCuenta.TabIndex = 247
        Me.lblDisplayALaCuenta.Text = "A la cuenta :"
        Me.lblDisplayALaCuenta.Visible = False
        '
        'TxtCuenta2
        '
        Me.TxtCuenta2.Location = New System.Drawing.Point(89, 86)
        Me.TxtCuenta2.MaxLength = 20
        Me.TxtCuenta2.Name = "TxtCuenta2"
        Me.TxtCuenta2.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta2.TabIndex = 245
        Me.TxtCuenta2.Visible = False
        '
        'LblDisplayDeLaCuenta
        '
        Me.LblDisplayDeLaCuenta.AutoSize = True
        Me.LblDisplayDeLaCuenta.Location = New System.Drawing.Point(8, 66)
        Me.LblDisplayDeLaCuenta.Name = "LblDisplayDeLaCuenta"
        Me.LblDisplayDeLaCuenta.Size = New System.Drawing.Size(74, 13)
        Me.LblDisplayDeLaCuenta.TabIndex = 246
        Me.LblDisplayDeLaCuenta.Text = "De la cuenta :"
        Me.LblDisplayDeLaCuenta.Visible = False
        '
        'TxtCuenta1
        '
        Me.TxtCuenta1.Location = New System.Drawing.Point(89, 62)
        Me.TxtCuenta1.MaxLength = 20
        Me.TxtCuenta1.Name = "TxtCuenta1"
        Me.TxtCuenta1.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta1.TabIndex = 244
        Me.TxtCuenta1.Visible = False
        '
        'CmbEjercicio2
        '
        Me.CmbEjercicio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio2.FormattingEnabled = True
        Me.CmbEjercicio2.Location = New System.Drawing.Point(89, 9)
        Me.CmbEjercicio2.MaxLength = 1
        Me.CmbEjercicio2.Name = "CmbEjercicio2"
        Me.CmbEjercicio2.Size = New System.Drawing.Size(133, 21)
        Me.CmbEjercicio2.TabIndex = 243
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 242
        Me.Label2.Text = "Ejercicio 2 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(331, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 241
        Me.Label3.Text = "Hasta :"
        '
        'DtFechaHasta2
        '
        Me.DtFechaHasta2.Location = New System.Drawing.Point(378, 31)
        Me.DtFechaHasta2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta2.Name = "DtFechaHasta2"
        Me.DtFechaHasta2.Size = New System.Drawing.Size(222, 20)
        Me.DtFechaHasta2.TabIndex = 239
        Me.DtFechaHasta2.Value = New Date(2011, 9, 26, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Desde :"
        '
        'DtFechaDesde2
        '
        Me.DtFechaDesde2.Location = New System.Drawing.Point(89, 33)
        Me.DtFechaDesde2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde2.Name = "DtFechaDesde2"
        Me.DtFechaDesde2.Size = New System.Drawing.Size(222, 20)
        Me.DtFechaDesde2.TabIndex = 238
        Me.DtFechaDesde2.Value = New Date(2011, 9, 26, 0, 0, 0, 0)
        '
        'Frm_contabilidad_Estados_Financieros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 323)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnPolizaNoCuadra)
        Me.Controls.Add(Me.LblNota)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_contabilidad_Estados_Financieros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estados financieros"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEjercicio As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbEstadoResultados As System.Windows.Forms.RadioButton
    Friend WithEvents RdnBalanceGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents RdbSocioTarriba As System.Windows.Forms.RadioButton
    Friend WithEvents btnPolizaNoCuadra As System.Windows.Forms.Button
    Friend WithEvents LblNota As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCuenta2 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta1 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayALaCuenta As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayDeLaCuenta As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta1 As System.Windows.Forms.TextBox
    Friend WithEvents CmbEjercicio2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents RdbEstadoSituacion As System.Windows.Forms.RadioButton
    Friend WithEvents RdbRelacionAnalitica As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTotales As System.Windows.Forms.RadioButton
End Class
