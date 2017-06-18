<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXC_AplicacionDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXC_AplicacionDocumentos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.lblDisplayFechaVenta = New System.Windows.Forms.Label()
        Me.dtpFechaVenta = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplaySaldo = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.lblDisplayImporte = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.lblNombreDocumento = New System.Windows.Forms.Label()
        Me.lblDisplayCodigoDocumento = New System.Windows.Forms.Label()
        Me.txtCodigoDocumento = New System.Windows.Forms.TextBox()
        Me.lblDisplayReferencia2 = New System.Windows.Forms.Label()
        Me.txtReferencia2 = New System.Windows.Forms.TextBox()
        Me.lblDisplayEstatus = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayReferencia = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.lblDisplayFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblNombreProveedor = New System.Windows.Forms.Label()
        Me.lblDisplayCodigoCliente = New System.Windows.Forms.Label()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.gbDocumento = New System.Windows.Forms.GroupBox()
        Me.rbAnticipo = New System.Windows.Forms.RadioButton()
        Me.rbDescuentoDevolucion = New System.Windows.Forms.RadioButton()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.gbDocumento.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbAplicar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(674, 25)
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
        'tsbAplicar
        '
        Me.tsbAplicar.Image = CType(resources.GetObject("tsbAplicar.Image"), System.Drawing.Image)
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(64, 22)
        Me.tsbAplicar.Text = "&Aplicar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabelEstado, Me.tssElaboro})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 262)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(674, 22)
        Me.StatusStripEstado.TabIndex = 4
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 17)
        '
        'tssElaboro
        '
        Me.tssElaboro.Name = "tssElaboro"
        Me.tssElaboro.Size = New System.Drawing.Size(0, 17)
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.lblDisplayFechaVenta)
        Me.gbDatos.Controls.Add(Me.dtpFechaVenta)
        Me.gbDatos.Controls.Add(Me.lblDisplaySaldo)
        Me.gbDatos.Controls.Add(Me.txtSaldo)
        Me.gbDatos.Controls.Add(Me.lblDisplayImporte)
        Me.gbDatos.Controls.Add(Me.txtImporte)
        Me.gbDatos.Controls.Add(Me.lblNombreDocumento)
        Me.gbDatos.Controls.Add(Me.lblDisplayCodigoDocumento)
        Me.gbDatos.Controls.Add(Me.txtCodigoDocumento)
        Me.gbDatos.Controls.Add(Me.lblDisplayReferencia2)
        Me.gbDatos.Controls.Add(Me.txtReferencia2)
        Me.gbDatos.Controls.Add(Me.lblDisplayEstatus)
        Me.gbDatos.Controls.Add(Me.lblEstatus)
        Me.gbDatos.Controls.Add(Me.lblDisplayFecha)
        Me.gbDatos.Controls.Add(Me.dtpFecha)
        Me.gbDatos.Controls.Add(Me.lblDisplayReferencia)
        Me.gbDatos.Controls.Add(Me.txtReferencia)
        Me.gbDatos.Controls.Add(Me.txtConcepto)
        Me.gbDatos.Controls.Add(Me.lblDisplayConcepto)
        Me.gbDatos.Controls.Add(Me.lblDisplayFolio)
        Me.gbDatos.Controls.Add(Me.txtFolio)
        Me.gbDatos.Controls.Add(Me.lblNombreProveedor)
        Me.gbDatos.Controls.Add(Me.lblDisplayCodigoCliente)
        Me.gbDatos.Controls.Add(Me.txtCodigoCliente)
        Me.gbDatos.Location = New System.Drawing.Point(7, 85)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(661, 174)
        Me.gbDatos.TabIndex = 5
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos"
        '
        'lblDisplayFechaVenta
        '
        Me.lblDisplayFechaVenta.AutoSize = True
        Me.lblDisplayFechaVenta.Location = New System.Drawing.Point(363, 99)
        Me.lblDisplayFechaVenta.Name = "lblDisplayFechaVenta"
        Me.lblDisplayFechaVenta.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFechaVenta.TabIndex = 276
        Me.lblDisplayFechaVenta.Text = "Fecha :"
        '
        'dtpFechaVenta
        '
        Me.dtpFechaVenta.Enabled = False
        Me.dtpFechaVenta.Location = New System.Drawing.Point(434, 96)
        Me.dtpFechaVenta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaVenta.Name = "dtpFechaVenta"
        Me.dtpFechaVenta.Size = New System.Drawing.Size(211, 20)
        Me.dtpFechaVenta.TabIndex = 275
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(186, 99)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplaySaldo.TabIndex = 274
        Me.lblDisplaySaldo.Text = "Saldo :"
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(240, 96)
        Me.txtSaldo.MaxLength = 160
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(114, 20)
        Me.txtSaldo.TabIndex = 273
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayImporte
        '
        Me.lblDisplayImporte.AutoSize = True
        Me.lblDisplayImporte.Location = New System.Drawing.Point(363, 47)
        Me.lblDisplayImporte.Name = "lblDisplayImporte"
        Me.lblDisplayImporte.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayImporte.TabIndex = 272
        Me.lblDisplayImporte.Text = "Importe :"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(434, 44)
        Me.txtImporte.MaxLength = 160
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(100, 20)
        Me.txtImporte.TabIndex = 7
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreDocumento
        '
        Me.lblNombreDocumento.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNombreDocumento.Location = New System.Drawing.Point(138, 47)
        Me.lblNombreDocumento.Name = "lblNombreDocumento"
        Me.lblNombreDocumento.Size = New System.Drawing.Size(216, 13)
        Me.lblNombreDocumento.TabIndex = 270
        '
        'lblDisplayCodigoDocumento
        '
        Me.lblDisplayCodigoDocumento.AutoSize = True
        Me.lblDisplayCodigoDocumento.Location = New System.Drawing.Point(6, 47)
        Me.lblDisplayCodigoDocumento.Name = "lblDisplayCodigoDocumento"
        Me.lblDisplayCodigoDocumento.Size = New System.Drawing.Size(68, 13)
        Me.lblDisplayCodigoDocumento.TabIndex = 269
        Me.lblDisplayCodigoDocumento.Text = "Documento :"
        '
        'txtCodigoDocumento
        '
        Me.txtCodigoDocumento.Location = New System.Drawing.Point(80, 44)
        Me.txtCodigoDocumento.MaxLength = 160
        Me.txtCodigoDocumento.Name = "txtCodigoDocumento"
        Me.txtCodigoDocumento.ReadOnly = True
        Me.txtCodigoDocumento.Size = New System.Drawing.Size(52, 20)
        Me.txtCodigoDocumento.TabIndex = 1
        '
        'lblDisplayReferencia2
        '
        Me.lblDisplayReferencia2.AutoSize = True
        Me.lblDisplayReferencia2.Location = New System.Drawing.Point(6, 125)
        Me.lblDisplayReferencia2.Name = "lblDisplayReferencia2"
        Me.lblDisplayReferencia2.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayReferencia2.TabIndex = 267
        Me.lblDisplayReferencia2.Text = "Referencia :"
        '
        'txtReferencia2
        '
        Me.txtReferencia2.Location = New System.Drawing.Point(80, 122)
        Me.txtReferencia2.MaxLength = 160
        Me.txtReferencia2.Name = "txtReferencia2"
        Me.txtReferencia2.ReadOnly = True
        Me.txtReferencia2.Size = New System.Drawing.Size(100, 20)
        Me.txtReferencia2.TabIndex = 4
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(186, 21)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayEstatus.TabIndex = 264
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'lblEstatus
        '
        Me.lblEstatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEstatus.Location = New System.Drawing.Point(240, 21)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(45, 13)
        Me.lblEstatus.TabIndex = 265
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
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Location = New System.Drawing.Point(434, 18)
        Me.dtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(211, 20)
        Me.dtpFecha.TabIndex = 6
        '
        'lblDisplayReferencia
        '
        Me.lblDisplayReferencia.AutoSize = True
        Me.lblDisplayReferencia.Location = New System.Drawing.Point(6, 99)
        Me.lblDisplayReferencia.Name = "lblDisplayReferencia"
        Me.lblDisplayReferencia.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayReferencia.TabIndex = 263
        Me.lblDisplayReferencia.Text = "Folio venta :"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(80, 96)
        Me.txtReferencia.MaxLength = 15
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(100, 20)
        Me.txtReferencia.TabIndex = 3
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(80, 148)
        Me.txtConcepto.MaxLength = 80
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ReadOnly = True
        Me.txtConcepto.Size = New System.Drawing.Size(565, 20)
        Me.txtConcepto.TabIndex = 5
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(6, 151)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayConcepto.TabIndex = 258
        Me.lblDisplayConcepto.Text = "Concepto :"
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
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNombreProveedor.Location = New System.Drawing.Point(186, 73)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(461, 13)
        Me.lblNombreProveedor.TabIndex = 262
        '
        'lblDisplayCodigoCliente
        '
        Me.lblDisplayCodigoCliente.AutoSize = True
        Me.lblDisplayCodigoCliente.Location = New System.Drawing.Point(6, 73)
        Me.lblDisplayCodigoCliente.Name = "lblDisplayCodigoCliente"
        Me.lblDisplayCodigoCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCodigoCliente.TabIndex = 261
        Me.lblDisplayCodigoCliente.Text = "Cliente :"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(80, 70)
        Me.txtCodigoCliente.MaxLength = 6
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.ReadOnly = True
        Me.txtCodigoCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoCliente.TabIndex = 2
        '
        'gbDocumento
        '
        Me.gbDocumento.Controls.Add(Me.rbDescuentoDevolucion)
        Me.gbDocumento.Controls.Add(Me.rbAnticipo)
        Me.gbDocumento.Enabled = False
        Me.gbDocumento.Location = New System.Drawing.Point(7, 36)
        Me.gbDocumento.Name = "gbDocumento"
        Me.gbDocumento.Size = New System.Drawing.Size(661, 43)
        Me.gbDocumento.TabIndex = 6
        Me.gbDocumento.TabStop = False
        Me.gbDocumento.Text = "Seleccione el tipo de documento :"
        '
        'rbAnticipo
        '
        Me.rbAnticipo.AutoSize = True
        Me.rbAnticipo.Checked = True
        Me.rbAnticipo.Location = New System.Drawing.Point(9, 20)
        Me.rbAnticipo.Name = "rbAnticipo"
        Me.rbAnticipo.Size = New System.Drawing.Size(63, 17)
        Me.rbAnticipo.TabIndex = 0
        Me.rbAnticipo.TabStop = True
        Me.rbAnticipo.Text = "Anticipo"
        Me.rbAnticipo.UseVisualStyleBackColor = True
        '
        'rbDescuentoDevolucion
        '
        Me.rbDescuentoDevolucion.AutoSize = True
        Me.rbDescuentoDevolucion.Location = New System.Drawing.Point(144, 20)
        Me.rbDescuentoDevolucion.Name = "rbDescuentoDevolucion"
        Me.rbDescuentoDevolucion.Size = New System.Drawing.Size(140, 17)
        Me.rbDescuentoDevolucion.TabIndex = 1
        Me.rbDescuentoDevolucion.Text = "Descuento x devolución"
        Me.rbDescuentoDevolucion.UseVisualStyleBackColor = True
        '
        'Frm_CXC_AplicacionDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 284)
        Me.Controls.Add(Me.gbDocumento)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_CXC_AplicacionDocumentos"
        Me.Text = "Aplicación de documentos CXC"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.gbDocumento.ResumeLayout(False)
        Me.gbDocumento.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayImporte As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreDocumento As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCodigoDocumento As System.Windows.Forms.Label
    Friend WithEvents txtCodigoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayReferencia2 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia2 As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayReferencia As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreProveedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCodigoCliente As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFechaVenta As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVenta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplaySaldo As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents gbDocumento As GroupBox
    Friend WithEvents rbDescuentoDevolucion As RadioButton
    Friend WithEvents rbAnticipo As RadioButton
End Class
