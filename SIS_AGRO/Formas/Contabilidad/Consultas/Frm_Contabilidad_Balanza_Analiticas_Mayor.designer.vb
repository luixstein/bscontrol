<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Balanza_Analiticas_Mayor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Balanza_Analiticas_Mayor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCuenta2 = New System.Windows.Forms.Label()
        Me.lblCuenta1 = New System.Windows.Forms.Label()
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.LblEjercicio = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCuenta2 = New System.Windows.Forms.TextBox()
        Me.LblDisplayNombreSocio = New System.Windows.Forms.Label()
        Me.TxtCuenta1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.ChCuentasAfectacion = New System.Windows.Forms.CheckBox()
        Me.ChCuentasSaldo = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbFiltros = New System.Windows.Forms.GroupBox()
        Me.RdbAuxiliarMayor = New System.Windows.Forms.RadioButton()
        Me.RdbBalanzaComprobacion = New System.Windows.Forms.RadioButton()
        Me.RdbRelacionAnalitica = New System.Windows.Forms.RadioButton()
        Me.RdbBalanzaComprobacion2doNivel = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.gbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCuenta2)
        Me.GroupBox1.Controls.Add(Me.lblCuenta1)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.LblEjercicio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta2)
        Me.GroupBox1.Controls.Add(Me.LblDisplayNombreSocio)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.ChCuentasAfectacion)
        Me.GroupBox1.Controls.Add(Me.ChCuentasSaldo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 180)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblCuenta2
        '
        Me.lblCuenta2.Location = New System.Drawing.Point(319, 153)
        Me.lblCuenta2.Name = "lblCuenta2"
        Me.lblCuenta2.Size = New System.Drawing.Size(283, 13)
        Me.lblCuenta2.TabIndex = 218
        Me.lblCuenta2.Text = "_"
        '
        'lblCuenta1
        '
        Me.lblCuenta1.Location = New System.Drawing.Point(15, 153)
        Me.lblCuenta1.Name = "lblCuenta1"
        Me.lblCuenta1.Size = New System.Drawing.Size(249, 13)
        Me.lblCuenta1.TabIndex = 217
        Me.lblCuenta1.Text = "_"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(94, 13)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio.TabIndex = 216
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(15, 13)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 202
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(248, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "A la cuenta :"
        '
        'TxtCuenta2
        '
        Me.TxtCuenta2.Location = New System.Drawing.Point(322, 130)
        Me.TxtCuenta2.MaxLength = 20
        Me.TxtCuenta2.Name = "TxtCuenta2"
        Me.TxtCuenta2.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta2.TabIndex = 8
        '
        'LblDisplayNombreSocio
        '
        Me.LblDisplayNombreSocio.AutoSize = True
        Me.LblDisplayNombreSocio.Location = New System.Drawing.Point(15, 134)
        Me.LblDisplayNombreSocio.Name = "LblDisplayNombreSocio"
        Me.LblDisplayNombreSocio.Size = New System.Drawing.Size(74, 13)
        Me.LblDisplayNombreSocio.TabIndex = 136
        Me.LblDisplayNombreSocio.Text = "De la cuenta :"
        '
        'TxtCuenta1
        '
        Me.TxtCuenta1.Location = New System.Drawing.Point(92, 130)
        Me.TxtCuenta1.MaxLength = 20
        Me.TxtCuenta1.Name = "TxtCuenta1"
        Me.TxtCuenta1.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(231, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Hasta la fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(322, 45)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaHasta.TabIndex = 4
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(15, 49)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 132
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(92, 45)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(133, 20)
        Me.DtFechaDesde.TabIndex = 3
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'ChCuentasAfectacion
        '
        Me.ChCuentasAfectacion.AutoSize = True
        Me.ChCuentasAfectacion.Location = New System.Drawing.Point(165, 94)
        Me.ChCuentasAfectacion.Name = "ChCuentasAfectacion"
        Me.ChCuentasAfectacion.Size = New System.Drawing.Size(182, 17)
        Me.ChCuentasAfectacion.TabIndex = 6
        Me.ChCuentasAfectacion.Text = "Filtrar solo cuentas de afectación"
        Me.ChCuentasAfectacion.UseVisualStyleBackColor = True
        Me.ChCuentasAfectacion.Visible = False
        '
        'ChCuentasSaldo
        '
        Me.ChCuentasSaldo.AutoSize = True
        Me.ChCuentasSaldo.Location = New System.Drawing.Point(165, 71)
        Me.ChCuentasSaldo.Name = "ChCuentasSaldo"
        Me.ChCuentasSaldo.Size = New System.Drawing.Size(165, 17)
        Me.ChCuentasSaldo.TabIndex = 5
        Me.ChCuentasSaldo.Text = "Filtrar cuentas con saldo <> 0"
        Me.ChCuentasSaldo.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(625, 25)
        Me.ToolStrip1.TabIndex = 7
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
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.RdbBalanzaComprobacion2doNivel)
        Me.gbFiltros.Controls.Add(Me.RdbAuxiliarMayor)
        Me.gbFiltros.Controls.Add(Me.RdbBalanzaComprobacion)
        Me.gbFiltros.Controls.Add(Me.RdbRelacionAnalitica)
        Me.gbFiltros.Location = New System.Drawing.Point(13, 28)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(607, 52)
        Me.gbFiltros.TabIndex = 6
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Tipo de reporte"
        '
        'RdbAuxiliarMayor
        '
        Me.RdbAuxiliarMayor.AutoSize = True
        Me.RdbAuxiliarMayor.Location = New System.Drawing.Point(497, 19)
        Me.RdbAuxiliarMayor.Name = "RdbAuxiliarMayor"
        Me.RdbAuxiliarMayor.Size = New System.Drawing.Size(104, 17)
        Me.RdbAuxiliarMayor.TabIndex = 2
        Me.RdbAuxiliarMayor.Text = "&Auxiliar de mayor"
        Me.RdbAuxiliarMayor.UseVisualStyleBackColor = True
        '
        'RdbBalanzaComprobacion
        '
        Me.RdbBalanzaComprobacion.AutoSize = True
        Me.RdbBalanzaComprobacion.Location = New System.Drawing.Point(139, 19)
        Me.RdbBalanzaComprobacion.Name = "RdbBalanzaComprobacion"
        Me.RdbBalanzaComprobacion.Size = New System.Drawing.Size(148, 17)
        Me.RdbBalanzaComprobacion.TabIndex = 1
        Me.RdbBalanzaComprobacion.Text = "&Balanza de comprobación"
        Me.RdbBalanzaComprobacion.UseVisualStyleBackColor = True
        '
        'RdbRelacionAnalitica
        '
        Me.RdbRelacionAnalitica.AutoSize = True
        Me.RdbRelacionAnalitica.Checked = True
        Me.RdbRelacionAnalitica.Location = New System.Drawing.Point(6, 19)
        Me.RdbRelacionAnalitica.Name = "RdbRelacionAnalitica"
        Me.RdbRelacionAnalitica.Size = New System.Drawing.Size(125, 17)
        Me.RdbRelacionAnalitica.TabIndex = 0
        Me.RdbRelacionAnalitica.TabStop = True
        Me.RdbRelacionAnalitica.Text = "&Relaciones analiticas"
        Me.RdbRelacionAnalitica.UseVisualStyleBackColor = True
        '
        'RdbBalanzaComprobacion2doNivel
        '
        Me.RdbBalanzaComprobacion2doNivel.AutoSize = True
        Me.RdbBalanzaComprobacion2doNivel.Location = New System.Drawing.Point(295, 19)
        Me.RdbBalanzaComprobacion2doNivel.Name = "RdbBalanzaComprobacion2doNivel"
        Me.RdbBalanzaComprobacion2doNivel.Size = New System.Drawing.Size(194, 17)
        Me.RdbBalanzaComprobacion2doNivel.TabIndex = 3
        Me.RdbBalanzaComprobacion2doNivel.Text = "&Balanza de comprobación 2do nivel"
        Me.RdbBalanzaComprobacion2doNivel.UseVisualStyleBackColor = True
        '
        'Frm_Contabilidad_Balanza_Analiticas_Mayor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 275)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_Balanza_Analiticas_Mayor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Balanza, analíticas, mayor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChCuentasAfectacion As System.Windows.Forms.CheckBox
    Friend WithEvents ChCuentasSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents RdbBalanzaComprobacion As System.Windows.Forms.RadioButton
    Friend WithEvents RdbRelacionAnalitica As System.Windows.Forms.RadioButton
    Friend WithEvents RdbAuxiliarMayor As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayNombreSocio As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuenta1 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta2 As System.Windows.Forms.Label
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents RdbBalanzaComprobacion2doNivel As RadioButton
End Class
