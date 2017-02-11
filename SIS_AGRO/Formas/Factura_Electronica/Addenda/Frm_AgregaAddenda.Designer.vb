<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AgregaAddenda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AgregaAddenda))
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.LblDisplayProveedor = New System.Windows.Forms.Label()
        Me.lblDisplayTienda = New System.Windows.Forms.Label()
        Me.LblDisplayTipoMoneda = New System.Windows.Forms.Label()
        Me.LblDisplayTipoBulto = New System.Windows.Forms.Label()
        Me.LblDisplayFecha = New System.Windows.Forms.Label()
        Me.dpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtTienda = New System.Windows.Forms.TextBox()
        Me.cboTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.CboTipoBulto = New System.Windows.Forms.ComboBox()
        Me.txtCita = New System.Windows.Forms.TextBox()
        Me.LblDisplayCita = New System.Windows.Forms.Label()
        Me.txtFolioPedido = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolioPedido = New System.Windows.Forms.Label()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.txtcantidadbultos = New System.Windows.Forms.TextBox()
        Me.LblDisplayCantidadBultos = New System.Windows.Forms.Label()
        Me.lblNombreTiendaSoriana = New System.Windows.Forms.Label()
        Me.btnGrabarAddenda = New System.Windows.Forms.Button()
        Me.BtnEnviar = New System.Windows.Forms.Button()
        Me.rbAddendaNormal = New System.Windows.Forms.RadioButton()
        Me.rbAddendaExtemporanea = New System.Windows.Forms.RadioButton()
        Me.txtFolioNotaEntrada = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(12, 31)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 225
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'txtFolio
        '
        Me.txtFolio.Enabled = False
        Me.txtFolio.Location = New System.Drawing.Point(120, 27)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(121, 20)
        Me.txtFolio.TabIndex = 0
        '
        'LblDisplayProveedor
        '
        Me.LblDisplayProveedor.AutoSize = True
        Me.LblDisplayProveedor.Location = New System.Drawing.Point(12, 59)
        Me.LblDisplayProveedor.Name = "LblDisplayProveedor"
        Me.LblDisplayProveedor.Size = New System.Drawing.Size(62, 13)
        Me.LblDisplayProveedor.TabIndex = 227
        Me.LblDisplayProveedor.Text = "Proveedor :"
        '
        'lblDisplayTienda
        '
        Me.lblDisplayTienda.AutoSize = True
        Me.lblDisplayTienda.Location = New System.Drawing.Point(12, 87)
        Me.lblDisplayTienda.Name = "lblDisplayTienda"
        Me.lblDisplayTienda.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplayTienda.TabIndex = 228
        Me.lblDisplayTienda.Text = "Tienda :"
        '
        'LblDisplayTipoMoneda
        '
        Me.LblDisplayTipoMoneda.AutoSize = True
        Me.LblDisplayTipoMoneda.Location = New System.Drawing.Point(12, 143)
        Me.LblDisplayTipoMoneda.Name = "LblDisplayTipoMoneda"
        Me.LblDisplayTipoMoneda.Size = New System.Drawing.Size(75, 13)
        Me.LblDisplayTipoMoneda.TabIndex = 229
        Me.LblDisplayTipoMoneda.Text = "Tipo moneda :"
        '
        'LblDisplayTipoBulto
        '
        Me.LblDisplayTipoBulto.AutoSize = True
        Me.LblDisplayTipoBulto.Location = New System.Drawing.Point(12, 172)
        Me.LblDisplayTipoBulto.Name = "LblDisplayTipoBulto"
        Me.LblDisplayTipoBulto.Size = New System.Drawing.Size(60, 13)
        Me.LblDisplayTipoBulto.TabIndex = 230
        Me.LblDisplayTipoBulto.Text = "Tipo bulto :"
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(12, 229)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(97, 13)
        Me.LblDisplayFecha.TabIndex = 232
        Me.LblDisplayFecha.Text = "Fecha de entrega :"
        '
        'dpFecha
        '
        Me.dpFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dpFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(120, 225)
        Me.dpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(121, 20)
        Me.dpFecha.TabIndex = 6
        '
        'txtProveedor
        '
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(120, 55)
        Me.txtProveedor.MaxLength = 15
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(121, 20)
        Me.txtProveedor.TabIndex = 1
        '
        'txtTienda
        '
        Me.txtTienda.Location = New System.Drawing.Point(120, 83)
        Me.txtTienda.MaxLength = 15
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Size = New System.Drawing.Size(121, 20)
        Me.txtTienda.TabIndex = 2
        '
        'cboTipoMoneda
        '
        Me.cboTipoMoneda.Enabled = False
        Me.cboTipoMoneda.FormattingEnabled = True
        Me.cboTipoMoneda.Location = New System.Drawing.Point(120, 139)
        Me.cboTipoMoneda.Name = "cboTipoMoneda"
        Me.cboTipoMoneda.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoMoneda.TabIndex = 3
        '
        'CboTipoBulto
        '
        Me.CboTipoBulto.FormattingEnabled = True
        Me.CboTipoBulto.Location = New System.Drawing.Point(120, 168)
        Me.CboTipoBulto.Name = "CboTipoBulto"
        Me.CboTipoBulto.Size = New System.Drawing.Size(121, 21)
        Me.CboTipoBulto.TabIndex = 4
        '
        'txtCita
        '
        Me.txtCita.Location = New System.Drawing.Point(120, 313)
        Me.txtCita.MaxLength = 15
        Me.txtCita.Name = "txtCita"
        Me.txtCita.Size = New System.Drawing.Size(121, 20)
        Me.txtCita.TabIndex = 8
        '
        'LblDisplayCita
        '
        Me.LblDisplayCita.AutoSize = True
        Me.LblDisplayCita.Location = New System.Drawing.Point(16, 316)
        Me.LblDisplayCita.Name = "LblDisplayCita"
        Me.LblDisplayCita.Size = New System.Drawing.Size(31, 13)
        Me.LblDisplayCita.TabIndex = 237
        Me.LblDisplayCita.Text = "Cita :"
        '
        'txtFolioPedido
        '
        Me.txtFolioPedido.Location = New System.Drawing.Point(120, 254)
        Me.txtFolioPedido.MaxLength = 15
        Me.txtFolioPedido.Name = "txtFolioPedido"
        Me.txtFolioPedido.Size = New System.Drawing.Size(121, 20)
        Me.txtFolioPedido.TabIndex = 7
        '
        'LblDisplayFolioPedido
        '
        Me.LblDisplayFolioPedido.AutoSize = True
        Me.LblDisplayFolioPedido.Location = New System.Drawing.Point(12, 257)
        Me.LblDisplayFolioPedido.Name = "LblDisplayFolioPedido"
        Me.LblDisplayFolioPedido.Size = New System.Drawing.Size(70, 13)
        Me.LblDisplayFolioPedido.TabIndex = 239
        Me.LblDisplayFolioPedido.Text = "Folio pedido :"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtFolioNotaEntrada)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.rbAddendaExtemporanea)
        Me.gbDatos.Controls.Add(Me.rbAddendaNormal)
        Me.gbDatos.Controls.Add(Me.txtcantidadbultos)
        Me.gbDatos.Controls.Add(Me.LblDisplayCantidadBultos)
        Me.gbDatos.Controls.Add(Me.lblNombreTiendaSoriana)
        Me.gbDatos.Controls.Add(Me.txtTienda)
        Me.gbDatos.Controls.Add(Me.txtFolioPedido)
        Me.gbDatos.Controls.Add(Me.LblDisplayFolioPedido)
        Me.gbDatos.Controls.Add(Me.LblDisplayFolio)
        Me.gbDatos.Controls.Add(Me.txtCita)
        Me.gbDatos.Controls.Add(Me.txtFolio)
        Me.gbDatos.Controls.Add(Me.LblDisplayCita)
        Me.gbDatos.Controls.Add(Me.LblDisplayProveedor)
        Me.gbDatos.Controls.Add(Me.CboTipoBulto)
        Me.gbDatos.Controls.Add(Me.lblDisplayTienda)
        Me.gbDatos.Controls.Add(Me.cboTipoMoneda)
        Me.gbDatos.Controls.Add(Me.txtProveedor)
        Me.gbDatos.Controls.Add(Me.LblDisplayFecha)
        Me.gbDatos.Controls.Add(Me.LblDisplayTipoMoneda)
        Me.gbDatos.Controls.Add(Me.dpFecha)
        Me.gbDatos.Controls.Add(Me.LblDisplayTipoBulto)
        Me.gbDatos.Location = New System.Drawing.Point(12, 37)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(251, 401)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos"
        '
        'txtcantidadbultos
        '
        Me.txtcantidadbultos.Location = New System.Drawing.Point(120, 197)
        Me.txtcantidadbultos.MaxLength = 15
        Me.txtcantidadbultos.Name = "txtcantidadbultos"
        Me.txtcantidadbultos.Size = New System.Drawing.Size(121, 20)
        Me.txtcantidadbultos.TabIndex = 5
        '
        'LblDisplayCantidadBultos
        '
        Me.LblDisplayCantidadBultos.AutoSize = True
        Me.LblDisplayCantidadBultos.Location = New System.Drawing.Point(12, 201)
        Me.LblDisplayCantidadBultos.Name = "LblDisplayCantidadBultos"
        Me.LblDisplayCantidadBultos.Size = New System.Drawing.Size(101, 13)
        Me.LblDisplayCantidadBultos.TabIndex = 243
        Me.LblDisplayCantidadBultos.Text = "Cantidad de bultos :"
        '
        'lblNombreTiendaSoriana
        '
        Me.lblNombreTiendaSoriana.AutoSize = True
        Me.lblNombreTiendaSoriana.Location = New System.Drawing.Point(12, 115)
        Me.lblNombreTiendaSoriana.Name = "lblNombreTiendaSoriana"
        Me.lblNombreTiendaSoriana.Size = New System.Drawing.Size(13, 13)
        Me.lblNombreTiendaSoriana.TabIndex = 241
        Me.lblNombreTiendaSoriana.Text = "_"
        '
        'btnGrabarAddenda
        '
        Me.btnGrabarAddenda.Location = New System.Drawing.Point(12, 12)
        Me.btnGrabarAddenda.Name = "btnGrabarAddenda"
        Me.btnGrabarAddenda.Size = New System.Drawing.Size(75, 23)
        Me.btnGrabarAddenda.TabIndex = 1
        Me.btnGrabarAddenda.Text = "Grabar"
        Me.btnGrabarAddenda.UseVisualStyleBackColor = True
        '
        'BtnEnviar
        '
        Me.BtnEnviar.Location = New System.Drawing.Point(93, 12)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.BtnEnviar.TabIndex = 2
        Me.BtnEnviar.Text = "Enviar"
        Me.BtnEnviar.UseVisualStyleBackColor = True
        '
        'rbAddendaNormal
        '
        Me.rbAddendaNormal.AutoSize = True
        Me.rbAddendaNormal.Checked = True
        Me.rbAddendaNormal.Location = New System.Drawing.Point(15, 290)
        Me.rbAddendaNormal.Name = "rbAddendaNormal"
        Me.rbAddendaNormal.Size = New System.Drawing.Size(102, 17)
        Me.rbAddendaNormal.TabIndex = 244
        Me.rbAddendaNormal.TabStop = True
        Me.rbAddendaNormal.Text = "Addenda normal"
        Me.rbAddendaNormal.UseVisualStyleBackColor = True
        '
        'rbAddendaExtemporanea
        '
        Me.rbAddendaExtemporanea.AutoSize = True
        Me.rbAddendaExtemporanea.Location = New System.Drawing.Point(15, 339)
        Me.rbAddendaExtemporanea.Name = "rbAddendaExtemporanea"
        Me.rbAddendaExtemporanea.Size = New System.Drawing.Size(138, 17)
        Me.rbAddendaExtemporanea.TabIndex = 245
        Me.rbAddendaExtemporanea.Text = "Addenda extemporánea"
        Me.rbAddendaExtemporanea.UseVisualStyleBackColor = True
        '
        'txtFolioNotaEntrada
        '
        Me.txtFolioNotaEntrada.Location = New System.Drawing.Point(120, 363)
        Me.txtFolioNotaEntrada.MaxLength = 15
        Me.txtFolioNotaEntrada.Name = "txtFolioNotaEntrada"
        Me.txtFolioNotaEntrada.Size = New System.Drawing.Size(121, 20)
        Me.txtFolioNotaEntrada.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 366)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = "Folio nota entrada :"
        '
        'Frm_AgregaAddenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 450)
        Me.Controls.Add(Me.BtnEnviar)
        Me.Controls.Add(Me.btnGrabarAddenda)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_AgregaAddenda"
        Me.Text = "Agrega Addenda"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayProveedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTienda As System.Windows.Forms.Label
    Friend WithEvents LblDisplayTipoMoneda As System.Windows.Forms.Label
    Friend WithEvents LblDisplayTipoBulto As System.Windows.Forms.Label
    Friend WithEvents LblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtTienda As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents CboTipoBulto As System.Windows.Forms.ComboBox
    Friend WithEvents txtCita As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCita As System.Windows.Forms.Label
    Friend WithEvents txtFolioPedido As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolioPedido As System.Windows.Forms.Label
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents btnGrabarAddenda As System.Windows.Forms.Button
    Friend WithEvents lblNombreTiendaSoriana As System.Windows.Forms.Label
    Friend WithEvents txtcantidadbultos As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayCantidadBultos As System.Windows.Forms.Label
    Friend WithEvents BtnEnviar As System.Windows.Forms.Button
    Friend WithEvents txtFolioNotaEntrada As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbAddendaExtemporanea As System.Windows.Forms.RadioButton
    Friend WithEvents rbAddendaNormal As System.Windows.Forms.RadioButton
End Class
