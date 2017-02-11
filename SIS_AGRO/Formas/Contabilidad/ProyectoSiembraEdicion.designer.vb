<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProyectoSiembraEdicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProyectoSiembraEdicion))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblidProyecto = New System.Windows.Forms.Label()
        Me.txtIdProyecto = New System.Windows.Forms.TextBox()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCodCentroCosto = New System.Windows.Forms.Label()
        Me.LblCodCentroCostoOrigen = New System.Windows.Forms.Label()
        Me.LblHectareasSembradas = New System.Windows.Forms.Label()
        Me.TxtOrden = New System.Windows.Forms.TextBox()
        Me.TxtCodCultivo = New System.Windows.Forms.TextBox()
        Me.TxtCodCentroCostoOrigen = New System.Windows.Forms.TextBox()
        Me.TxtCodCentroCosto = New System.Windows.Forms.TextBox()
        Me.TxtHectareasSembradas = New System.Windows.Forms.TextBox()
        Me.LblFechaCorte = New System.Windows.Forms.Label()
        Me.LblFechaFin = New System.Windows.Forms.Label()
        Me.LblFechaSiembra = New System.Windows.Forms.Label()
        Me.dtFechaSiembra = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaCorte = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEjercicio = New System.Windows.Forms.Label()
        Me.CboEjercicio = New System.Windows.Forms.ComboBox()
        Me.LblCultivo = New System.Windows.Forms.Label()
        Me.LblCentroCostoOrigen = New System.Windows.Forms.Label()
        Me.LblCentroCosto = New System.Windows.Forms.Label()
        Me.chkbFechaSiembra = New System.Windows.Forms.CheckBox()
        Me.chkbFechaFin = New System.Windows.Forms.CheckBox()
        Me.ChkbFechaCorte = New System.Windows.Forms.CheckBox()
        Me.LblCodLote = New System.Windows.Forms.Label()
        Me.txtCodLote = New System.Windows.Forms.TextBox()
        Me.lblNombreLote = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(819, 27)
        Me.tsMenu.TabIndex = 223
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
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(1199, 63)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(12, 17)
        Me.LblStatus.TabIndex = 260
        Me.LblStatus.Text = "."
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 398)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(819, 25)
        Me.StatusStripEstado.TabIndex = 257
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(61, 20)
        Me.tssLabel.Text = "Estado :"
        '
        'lblidProyecto
        '
        Me.lblidProyecto.AutoSize = True
        Me.lblidProyecto.Location = New System.Drawing.Point(12, 44)
        Me.lblidProyecto.Name = "lblidProyecto"
        Me.lblidProyecto.Size = New System.Drawing.Size(86, 17)
        Me.lblidProyecto.TabIndex = 261
        Me.lblidProyecto.Text = "Id proyecto :"
        '
        'txtIdProyecto
        '
        Me.txtIdProyecto.Location = New System.Drawing.Point(204, 41)
        Me.txtIdProyecto.Name = "txtIdProyecto"
        Me.txtIdProyecto.Size = New System.Drawing.Size(100, 22)
        Me.txtIdProyecto.TabIndex = 0
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.Location = New System.Drawing.Point(12, 139)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(56, 17)
        Me.lblOrden.TabIndex = 263
        Me.lblOrden.Text = "Orden :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 17)
        Me.Label2.TabIndex = 264
        Me.Label2.Text = "Código cultivo :"
        '
        'LblCodCentroCosto
        '
        Me.LblCodCentroCosto.AutoSize = True
        Me.LblCodCentroCosto.Location = New System.Drawing.Point(12, 289)
        Me.LblCodCentroCosto.Name = "LblCodCentroCosto"
        Me.LblCodCentroCosto.Size = New System.Drawing.Size(142, 17)
        Me.LblCodCentroCosto.TabIndex = 265
        Me.LblCodCentroCosto.Text = "Código centro costo :"
        '
        'LblCodCentroCostoOrigen
        '
        Me.LblCodCentroCostoOrigen.AutoSize = True
        Me.LblCodCentroCostoOrigen.Location = New System.Drawing.Point(12, 239)
        Me.LblCodCentroCostoOrigen.Name = "LblCodCentroCostoOrigen"
        Me.LblCodCentroCostoOrigen.Size = New System.Drawing.Size(186, 17)
        Me.LblCodCentroCostoOrigen.TabIndex = 266
        Me.LblCodCentroCostoOrigen.Text = "Código centro costo origen :"
        '
        'LblHectareasSembradas
        '
        Me.LblHectareasSembradas.AutoSize = True
        Me.LblHectareasSembradas.Location = New System.Drawing.Point(12, 350)
        Me.LblHectareasSembradas.Name = "LblHectareasSembradas"
        Me.LblHectareasSembradas.Size = New System.Drawing.Size(155, 17)
        Me.LblHectareasSembradas.TabIndex = 267
        Me.LblHectareasSembradas.Text = "Hectareas sembradas :"
        '
        'TxtOrden
        '
        Me.TxtOrden.Location = New System.Drawing.Point(204, 136)
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(100, 22)
        Me.TxtOrden.TabIndex = 2
        '
        'TxtCodCultivo
        '
        Me.TxtCodCultivo.Location = New System.Drawing.Point(204, 185)
        Me.TxtCodCultivo.Name = "TxtCodCultivo"
        Me.TxtCodCultivo.Size = New System.Drawing.Size(100, 22)
        Me.TxtCodCultivo.TabIndex = 3
        '
        'TxtCodCentroCostoOrigen
        '
        Me.TxtCodCentroCostoOrigen.Location = New System.Drawing.Point(204, 236)
        Me.TxtCodCentroCostoOrigen.Name = "TxtCodCentroCostoOrigen"
        Me.TxtCodCentroCostoOrigen.Size = New System.Drawing.Size(100, 22)
        Me.TxtCodCentroCostoOrigen.TabIndex = 4
        '
        'TxtCodCentroCosto
        '
        Me.TxtCodCentroCosto.Location = New System.Drawing.Point(204, 286)
        Me.TxtCodCentroCosto.Name = "TxtCodCentroCosto"
        Me.TxtCodCentroCosto.Size = New System.Drawing.Size(100, 22)
        Me.TxtCodCentroCosto.TabIndex = 5
        '
        'TxtHectareasSembradas
        '
        Me.TxtHectareasSembradas.Location = New System.Drawing.Point(204, 347)
        Me.TxtHectareasSembradas.Name = "TxtHectareasSembradas"
        Me.TxtHectareasSembradas.Size = New System.Drawing.Size(100, 22)
        Me.TxtHectareasSembradas.TabIndex = 6
        '
        'LblFechaCorte
        '
        Me.LblFechaCorte.AutoSize = True
        Me.LblFechaCorte.Location = New System.Drawing.Point(343, 136)
        Me.LblFechaCorte.Name = "LblFechaCorte"
        Me.LblFechaCorte.Size = New System.Drawing.Size(91, 17)
        Me.LblFechaCorte.TabIndex = 273
        Me.LblFechaCorte.Text = "Fecha corte :"
        '
        'LblFechaFin
        '
        Me.LblFechaFin.AutoSize = True
        Me.LblFechaFin.Location = New System.Drawing.Point(343, 185)
        Me.LblFechaFin.Name = "LblFechaFin"
        Me.LblFechaFin.Size = New System.Drawing.Size(146, 17)
        Me.LblFechaFin.TabIndex = 274
        Me.LblFechaFin.Text = "Fecha fin temporada :"
        '
        'LblFechaSiembra
        '
        Me.LblFechaSiembra.AutoSize = True
        Me.LblFechaSiembra.Location = New System.Drawing.Point(343, 95)
        Me.LblFechaSiembra.Name = "LblFechaSiembra"
        Me.LblFechaSiembra.Size = New System.Drawing.Size(109, 17)
        Me.LblFechaSiembra.TabIndex = 275
        Me.LblFechaSiembra.Text = "Fecha siembra :"
        '
        'dtFechaSiembra
        '
        Me.dtFechaSiembra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaSiembra.Location = New System.Drawing.Point(495, 90)
        Me.dtFechaSiembra.Name = "dtFechaSiembra"
        Me.dtFechaSiembra.Size = New System.Drawing.Size(200, 22)
        Me.dtFechaSiembra.TabIndex = 8
        '
        'dtFechaCorte
        '
        Me.dtFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaCorte.Location = New System.Drawing.Point(496, 131)
        Me.dtFechaCorte.Name = "dtFechaCorte"
        Me.dtFechaCorte.Size = New System.Drawing.Size(200, 22)
        Me.dtFechaCorte.TabIndex = 10
        '
        'dtFechaFin
        '
        Me.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFin.Location = New System.Drawing.Point(496, 180)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.Size = New System.Drawing.Size(200, 22)
        Me.dtFechaFin.TabIndex = 12
        '
        'lblEjercicio
        '
        Me.lblEjercicio.AutoSize = True
        Me.lblEjercicio.Location = New System.Drawing.Point(12, 90)
        Me.lblEjercicio.Name = "lblEjercicio"
        Me.lblEjercicio.Size = New System.Drawing.Size(69, 17)
        Me.lblEjercicio.TabIndex = 279
        Me.lblEjercicio.Text = "Ejercicio :"
        '
        'CboEjercicio
        '
        Me.CboEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEjercicio.FormattingEnabled = True
        Me.CboEjercicio.Location = New System.Drawing.Point(204, 85)
        Me.CboEjercicio.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEjercicio.Name = "CboEjercicio"
        Me.CboEjercicio.Size = New System.Drawing.Size(100, 24)
        Me.CboEjercicio.TabIndex = 1
        '
        'LblCultivo
        '
        Me.LblCultivo.AutoSize = True
        Me.LblCultivo.Location = New System.Drawing.Point(201, 210)
        Me.LblCultivo.Name = "LblCultivo"
        Me.LblCultivo.Size = New System.Drawing.Size(16, 17)
        Me.LblCultivo.TabIndex = 27
        Me.LblCultivo.Text = "_"
        '
        'LblCentroCostoOrigen
        '
        Me.LblCentroCostoOrigen.AutoSize = True
        Me.LblCentroCostoOrigen.Location = New System.Drawing.Point(201, 261)
        Me.LblCentroCostoOrigen.Name = "LblCentroCostoOrigen"
        Me.LblCentroCostoOrigen.Size = New System.Drawing.Size(16, 17)
        Me.LblCentroCostoOrigen.TabIndex = 6
        Me.LblCentroCostoOrigen.Text = "_"
        '
        'LblCentroCosto
        '
        Me.LblCentroCosto.AutoSize = True
        Me.LblCentroCosto.Location = New System.Drawing.Point(201, 311)
        Me.LblCentroCosto.Name = "LblCentroCosto"
        Me.LblCentroCosto.Size = New System.Drawing.Size(16, 17)
        Me.LblCentroCosto.TabIndex = 283
        Me.LblCentroCosto.Text = "_"
        '
        'chkbFechaSiembra
        '
        Me.chkbFechaSiembra.AutoSize = True
        Me.chkbFechaSiembra.Location = New System.Drawing.Point(702, 94)
        Me.chkbFechaSiembra.Name = "chkbFechaSiembra"
        Me.chkbFechaSiembra.Size = New System.Drawing.Size(93, 21)
        Me.chkbFechaSiembra.TabIndex = 9
        Me.chkbFechaSiembra.Text = "Sin definir"
        Me.chkbFechaSiembra.UseVisualStyleBackColor = True
        '
        'chkbFechaFin
        '
        Me.chkbFechaFin.AutoSize = True
        Me.chkbFechaFin.Location = New System.Drawing.Point(702, 180)
        Me.chkbFechaFin.Name = "chkbFechaFin"
        Me.chkbFechaFin.Size = New System.Drawing.Size(93, 21)
        Me.chkbFechaFin.TabIndex = 13
        Me.chkbFechaFin.Text = "Sin definir"
        Me.chkbFechaFin.UseVisualStyleBackColor = True
        '
        'ChkbFechaCorte
        '
        Me.ChkbFechaCorte.AutoSize = True
        Me.ChkbFechaCorte.Location = New System.Drawing.Point(702, 135)
        Me.ChkbFechaCorte.Name = "ChkbFechaCorte"
        Me.ChkbFechaCorte.Size = New System.Drawing.Size(93, 21)
        Me.ChkbFechaCorte.TabIndex = 11
        Me.ChkbFechaCorte.Text = "Sin definir"
        Me.ChkbFechaCorte.UseVisualStyleBackColor = True
        '
        'LblCodLote
        '
        Me.LblCodLote.AutoSize = True
        Me.LblCodLote.Location = New System.Drawing.Point(343, 44)
        Me.LblCodLote.Name = "LblCodLote"
        Me.LblCodLote.Size = New System.Drawing.Size(87, 17)
        Me.LblCodLote.TabIndex = 284
        Me.LblCodLote.Text = "Código lote :"
        '
        'txtCodLote
        '
        Me.txtCodLote.Location = New System.Drawing.Point(495, 41)
        Me.txtCodLote.Name = "txtCodLote"
        Me.txtCodLote.Size = New System.Drawing.Size(100, 22)
        Me.txtCodLote.TabIndex = 7
        '
        'lblNombreLote
        '
        Me.lblNombreLote.AutoSize = True
        Me.lblNombreLote.Location = New System.Drawing.Point(492, 66)
        Me.lblNombreLote.Name = "lblNombreLote"
        Me.lblNombreLote.Size = New System.Drawing.Size(16, 17)
        Me.lblNombreLote.TabIndex = 286
        Me.lblNombreLote.Text = "_"
        '
        'ProyectoSiembraEdicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 423)
        Me.Controls.Add(Me.lblNombreLote)
        Me.Controls.Add(Me.txtCodLote)
        Me.Controls.Add(Me.LblCodLote)
        Me.Controls.Add(Me.ChkbFechaCorte)
        Me.Controls.Add(Me.chkbFechaFin)
        Me.Controls.Add(Me.chkbFechaSiembra)
        Me.Controls.Add(Me.LblCentroCosto)
        Me.Controls.Add(Me.LblCentroCostoOrigen)
        Me.Controls.Add(Me.LblCultivo)
        Me.Controls.Add(Me.CboEjercicio)
        Me.Controls.Add(Me.lblEjercicio)
        Me.Controls.Add(Me.dtFechaFin)
        Me.Controls.Add(Me.dtFechaCorte)
        Me.Controls.Add(Me.dtFechaSiembra)
        Me.Controls.Add(Me.LblFechaSiembra)
        Me.Controls.Add(Me.LblFechaFin)
        Me.Controls.Add(Me.LblFechaCorte)
        Me.Controls.Add(Me.TxtHectareasSembradas)
        Me.Controls.Add(Me.TxtCodCentroCosto)
        Me.Controls.Add(Me.TxtCodCentroCostoOrigen)
        Me.Controls.Add(Me.TxtCodCultivo)
        Me.Controls.Add(Me.TxtOrden)
        Me.Controls.Add(Me.LblHectareasSembradas)
        Me.Controls.Add(Me.LblCodCentroCostoOrigen)
        Me.Controls.Add(Me.LblCodCentroCosto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtIdProyecto)
        Me.Controls.Add(Me.lblidProyecto)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "ProyectoSiembraEdicion"
        Me.Text = "Editor de proyecto de siembra"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents lblidProyecto As System.Windows.Forms.Label
    Friend WithEvents txtIdProyecto As System.Windows.Forms.TextBox
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblCodCentroCosto As System.Windows.Forms.Label
    Friend WithEvents LblCodCentroCostoOrigen As System.Windows.Forms.Label
    Friend WithEvents LblHectareasSembradas As System.Windows.Forms.Label
    Friend WithEvents TxtOrden As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodCultivo As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodCentroCostoOrigen As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents TxtHectareasSembradas As System.Windows.Forms.TextBox
    Friend WithEvents LblFechaCorte As System.Windows.Forms.Label
    Friend WithEvents LblFechaFin As System.Windows.Forms.Label
    Friend WithEvents LblFechaSiembra As System.Windows.Forms.Label
    Friend WithEvents dtFechaSiembra As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaCorte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblEjercicio As System.Windows.Forms.Label
    Friend WithEvents CboEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents LblCultivo As System.Windows.Forms.Label
    Friend WithEvents LblCentroCostoOrigen As System.Windows.Forms.Label
    Friend WithEvents LblCentroCosto As System.Windows.Forms.Label
    Friend WithEvents chkbFechaSiembra As System.Windows.Forms.CheckBox
    Friend WithEvents chkbFechaFin As System.Windows.Forms.CheckBox
    Friend WithEvents ChkbFechaCorte As System.Windows.Forms.CheckBox
    Friend WithEvents LblCodLote As System.Windows.Forms.Label
    Friend WithEvents txtCodLote As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreLote As System.Windows.Forms.Label
End Class
