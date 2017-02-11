<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_EntradaSobrante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_EntradaSobrante))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbEliminar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.CboEmpaque = New System.Windows.Forms.ComboBox
        Me.lblDisplayEmpaque = New System.Windows.Forms.Label
        Me.lblDisplayFecha = New System.Windows.Forms.Label
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.lblDisplayCatidad = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.lblDisplayFolio = New System.Windows.Forms.Label
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.lblArticulo = New System.Windows.Forms.Label
        Me.lblDisplayProducto = New System.Windows.Forms.Label
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsMenu.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbEliminar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(678, 25)
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
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbEliminar
        '
        Me.tsbEliminar.Image = CType(resources.GetObject("tsbEliminar.Image"), System.Drawing.Image)
        Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminar.Name = "tsbEliminar"
        Me.tsbEliminar.Size = New System.Drawing.Size(70, 22)
        Me.tsbEliminar.Text = "&Eliminar"
        Me.tsbEliminar.Visible = False
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtProducto)
        Me.gbDatos.Controls.Add(Me.CboEmpaque)
        Me.gbDatos.Controls.Add(Me.lblDisplayEmpaque)
        Me.gbDatos.Controls.Add(Me.lblDisplayFecha)
        Me.gbDatos.Controls.Add(Me.dtpFecha)
        Me.gbDatos.Controls.Add(Me.lblDisplayCatidad)
        Me.gbDatos.Controls.Add(Me.txtCantidad)
        Me.gbDatos.Controls.Add(Me.lblDisplayFolio)
        Me.gbDatos.Controls.Add(Me.txtFolio)
        Me.gbDatos.Controls.Add(Me.lblArticulo)
        Me.gbDatos.Controls.Add(Me.lblDisplayProducto)
        Me.gbDatos.Location = New System.Drawing.Point(12, 28)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(659, 132)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos"
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(80, 70)
        Me.txtProducto.MaxLength = 16
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtProducto.TabIndex = 270
        Me.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CboEmpaque
        '
        Me.CboEmpaque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEmpaque.FormattingEnabled = True
        Me.CboEmpaque.Location = New System.Drawing.Point(80, 43)
        Me.CboEmpaque.MaxLength = 1
        Me.CboEmpaque.Name = "CboEmpaque"
        Me.CboEmpaque.Size = New System.Drawing.Size(157, 21)
        Me.CboEmpaque.TabIndex = 1
        '
        'lblDisplayEmpaque
        '
        Me.lblDisplayEmpaque.AutoSize = True
        Me.lblDisplayEmpaque.Location = New System.Drawing.Point(6, 47)
        Me.lblDisplayEmpaque.Name = "lblDisplayEmpaque"
        Me.lblDisplayEmpaque.Size = New System.Drawing.Size(58, 13)
        Me.lblDisplayEmpaque.TabIndex = 269
        Me.lblDisplayEmpaque.Text = "Empaque :"
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(363, 21)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 257
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(434, 18)
        Me.dtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(211, 20)
        Me.dtpFecha.TabIndex = 4
        '
        'lblDisplayCatidad
        '
        Me.lblDisplayCatidad.AutoSize = True
        Me.lblDisplayCatidad.Location = New System.Drawing.Point(6, 99)
        Me.lblDisplayCatidad.Name = "lblDisplayCatidad"
        Me.lblDisplayCatidad.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayCatidad.TabIndex = 263
        Me.lblDisplayCatidad.Text = "Cantidad :"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(80, 96)
        Me.txtCantidad.MaxLength = 12
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayFolio
        '
        Me.lblDisplayFolio.AutoSize = True
        Me.lblDisplayFolio.Location = New System.Drawing.Point(6, 21)
        Me.lblDisplayFolio.Name = "lblDisplayFolio"
        Me.lblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.lblDisplayFolio.TabIndex = 259
        Me.lblDisplayFolio.Text = "Folio :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(80, 18)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 20)
        Me.txtFolio.TabIndex = 0
        '
        'lblArticulo
        '
        Me.lblArticulo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblArticulo.Location = New System.Drawing.Point(186, 73)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(461, 13)
        Me.lblArticulo.TabIndex = 262
        '
        'lblDisplayProducto
        '
        Me.lblDisplayProducto.AutoSize = True
        Me.lblDisplayProducto.Location = New System.Drawing.Point(6, 73)
        Me.lblDisplayProducto.Name = "lblDisplayProducto"
        Me.lblDisplayProducto.Size = New System.Drawing.Size(56, 13)
        Me.lblDisplayProducto.TabIndex = 261
        Me.lblDisplayProducto.Text = "Producto :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 168)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(678, 22)
        Me.StatusStripEstado.TabIndex = 5
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(48, 17)
        Me.tssLabel.Text = "Estado :"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 17)
        '
        'Frm_Embarques_EntradaSobrante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 190)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_EntradaSobrante"
        Me.Text = "Captura diaria de producción"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayEmpaque As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayCatidad As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayProducto As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CboEmpaque As System.Windows.Forms.ComboBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
End Class
