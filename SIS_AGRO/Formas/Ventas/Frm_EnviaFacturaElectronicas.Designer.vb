<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EnviaFacturaElectronicas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_EnviaFacturaElectronicas))
        Me.gbFiltros = New System.Windows.Forms.GroupBox
        Me.CboEstatus = New System.Windows.Forms.ComboBox
        Me.btnAgregarDocumentosClientes = New System.Windows.Forms.Button
        Me.ckbConSaldo = New System.Windows.Forms.CheckBox
        Me.lblDisplayEstatus = New System.Windows.Forms.Label
        Me.lblDisplayHasta = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayDesde = New System.Windows.Forms.Label
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbEnviar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.gbCliente = New System.Windows.Forms.GroupBox
        Me.txtComentarios = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.btnActualizaCorreo = New System.Windows.Forms.Button
        Me.txtCorreoCliente = New System.Windows.Forms.TextBox
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.lblDisplayCorreo = New System.Windows.Forms.Label
        Me.lblDisplayCliente = New System.Windows.Forms.Label
        Me.gbFacturas = New System.Windows.Forms.GroupBox
        Me.CkbMarcarTodo = New System.Windows.Forms.CheckBox
        Me.txtSaldo = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Grid = New FlexCell.Grid
        Me.pbBarra = New System.Windows.Forms.ProgressBar
        Me.lblDisplayProgreso = New System.Windows.Forms.Label
        Me.TxtFormatoXML = New System.Windows.Forms.TextBox
        Me.gbFiltros.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.gbCliente.SuspendLayout()
        Me.gbFacturas.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.CboEstatus)
        Me.gbFiltros.Controls.Add(Me.btnAgregarDocumentosClientes)
        Me.gbFiltros.Controls.Add(Me.ckbConSaldo)
        Me.gbFiltros.Controls.Add(Me.lblDisplayEstatus)
        Me.gbFiltros.Controls.Add(Me.lblDisplayHasta)
        Me.gbFiltros.Controls.Add(Me.DtFechaDesde)
        Me.gbFiltros.Controls.Add(Me.DtFechaHasta)
        Me.gbFiltros.Controls.Add(Me.LblDisplayDesde)
        Me.gbFiltros.Location = New System.Drawing.Point(699, 27)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(181, 183)
        Me.gbFiltros.TabIndex = 0
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "G", "T"})
        Me.CboEstatus.Location = New System.Drawing.Point(61, 83)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(57, 21)
        Me.CboEstatus.TabIndex = 237
        '
        'btnAgregarDocumentosClientes
        '
        Me.btnAgregarDocumentosClientes.Location = New System.Drawing.Point(26, 149)
        Me.btnAgregarDocumentosClientes.Name = "btnAgregarDocumentosClientes"
        Me.btnAgregarDocumentosClientes.Size = New System.Drawing.Size(131, 26)
        Me.btnAgregarDocumentosClientes.TabIndex = 219
        Me.btnAgregarDocumentosClientes.Text = "Consultar documentos"
        Me.btnAgregarDocumentosClientes.UseVisualStyleBackColor = True
        '
        'ckbConSaldo
        '
        Me.ckbConSaldo.AutoSize = True
        Me.ckbConSaldo.Location = New System.Drawing.Point(10, 117)
        Me.ckbConSaldo.Name = "ckbConSaldo"
        Me.ckbConSaldo.Size = New System.Drawing.Size(131, 17)
        Me.ckbConSaldo.TabIndex = 218
        Me.ckbConSaldo.Text = "Solo ventas con saldo"
        Me.ckbConSaldo.UseVisualStyleBackColor = True
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(7, 87)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayEstatus.TabIndex = 217
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'lblDisplayHasta
        '
        Me.lblDisplayHasta.AutoSize = True
        Me.lblDisplayHasta.Location = New System.Drawing.Point(7, 59)
        Me.lblDisplayHasta.Name = "lblDisplayHasta"
        Me.lblDisplayHasta.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayHasta.TabIndex = 216
        Me.lblDisplayHasta.Text = "Hasta :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.CustomFormat = "dd/MMM/yy"
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaDesde.Location = New System.Drawing.Point(61, 27)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(110, 20)
        Me.DtFechaDesde.TabIndex = 213
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.CustomFormat = "dd/MMM/yy"
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtFechaHasta.Location = New System.Drawing.Point(61, 55)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(110, 20)
        Me.DtFechaHasta.TabIndex = 214
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayDesde
        '
        Me.LblDisplayDesde.AutoSize = True
        Me.LblDisplayDesde.Location = New System.Drawing.Point(7, 31)
        Me.LblDisplayDesde.Name = "LblDisplayDesde"
        Me.LblDisplayDesde.Size = New System.Drawing.Size(44, 13)
        Me.LblDisplayDesde.TabIndex = 215
        Me.LblDisplayDesde.Text = "Desde :"
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEnviar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(889, 25)
        Me.tsMenu.TabIndex = 2
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
        'tsbEnviar
        '
        Me.tsbEnviar.Image = CType(resources.GetObject("tsbEnviar.Image"), System.Drawing.Image)
        Me.tsbEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviar.Name = "tsbEnviar"
        Me.tsbEnviar.Size = New System.Drawing.Size(59, 22)
        Me.tsbEnviar.Text = "&Enviar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbCliente
        '
        Me.gbCliente.Controls.Add(Me.txtComentarios)
        Me.gbCliente.Controls.Add(Me.Label1)
        Me.gbCliente.Controls.Add(Me.lblNombreCliente)
        Me.gbCliente.Controls.Add(Me.btnActualizaCorreo)
        Me.gbCliente.Controls.Add(Me.txtCorreoCliente)
        Me.gbCliente.Controls.Add(Me.txtCodigoCliente)
        Me.gbCliente.Controls.Add(Me.lblDisplayCorreo)
        Me.gbCliente.Controls.Add(Me.lblDisplayCliente)
        Me.gbCliente.Location = New System.Drawing.Point(7, 28)
        Me.gbCliente.Name = "gbCliente"
        Me.gbCliente.Size = New System.Drawing.Size(686, 151)
        Me.gbCliente.TabIndex = 3
        Me.gbCliente.TabStop = False
        '
        'txtComentarios
        '
        Me.txtComentarios.Location = New System.Drawing.Point(83, 88)
        Me.txtComentarios.MaxLength = 500
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(597, 57)
        Me.txtComentarios.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Comentarios :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(149, 30)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreCliente.TabIndex = 5
        Me.lblNombreCliente.Text = "."
        '
        'btnActualizaCorreo
        '
        Me.btnActualizaCorreo.Location = New System.Drawing.Point(549, 55)
        Me.btnActualizaCorreo.Name = "btnActualizaCorreo"
        Me.btnActualizaCorreo.Size = New System.Drawing.Size(131, 26)
        Me.btnActualizaCorreo.TabIndex = 4
        Me.btnActualizaCorreo.Text = "Actualizar correo"
        Me.btnActualizaCorreo.UseVisualStyleBackColor = True
        '
        'txtCorreoCliente
        '
        Me.txtCorreoCliente.Location = New System.Drawing.Point(83, 59)
        Me.txtCorreoCliente.MaxLength = 500
        Me.txtCorreoCliente.Name = "txtCorreoCliente"
        Me.txtCorreoCliente.Size = New System.Drawing.Size(460, 20)
        Me.txtCorreoCliente.TabIndex = 3
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(83, 27)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(60, 20)
        Me.txtCodigoCliente.TabIndex = 2
        '
        'lblDisplayCorreo
        '
        Me.lblDisplayCorreo.AutoSize = True
        Me.lblDisplayCorreo.Location = New System.Drawing.Point(6, 62)
        Me.lblDisplayCorreo.Name = "lblDisplayCorreo"
        Me.lblDisplayCorreo.Size = New System.Drawing.Size(44, 13)
        Me.lblDisplayCorreo.TabIndex = 1
        Me.lblDisplayCorreo.Text = "Correo :"
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(6, 30)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 0
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'gbFacturas
        '
        Me.gbFacturas.Controls.Add(Me.CkbMarcarTodo)
        Me.gbFacturas.Controls.Add(Me.txtSaldo)
        Me.gbFacturas.Controls.Add(Me.txtTotal)
        Me.gbFacturas.Controls.Add(Me.Grid)
        Me.gbFacturas.Location = New System.Drawing.Point(7, 185)
        Me.gbFacturas.Name = "gbFacturas"
        Me.gbFacturas.Size = New System.Drawing.Size(686, 280)
        Me.gbFacturas.TabIndex = 4
        Me.gbFacturas.TabStop = False
        Me.gbFacturas.Text = "Facturas"
        '
        'CkbMarcarTodo
        '
        Me.CkbMarcarTodo.AutoSize = True
        Me.CkbMarcarTodo.Location = New System.Drawing.Point(474, 11)
        Me.CkbMarcarTodo.Name = "CkbMarcarTodo"
        Me.CkbMarcarTodo.Size = New System.Drawing.Size(88, 17)
        Me.CkbMarcarTodo.TabIndex = 238
        Me.CkbMarcarTodo.Text = "Marcar todas"
        Me.CkbMarcarTodo.UseVisualStyleBackColor = True
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(452, 254)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldo.TabIndex = 3
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(346, 254)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 2
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(7, 34)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(673, 214)
        Me.Grid.TabIndex = 1
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'pbBarra
        '
        Me.pbBarra.Location = New System.Drawing.Point(706, 435)
        Me.pbBarra.Name = "pbBarra"
        Me.pbBarra.Size = New System.Drawing.Size(171, 23)
        Me.pbBarra.TabIndex = 5
        '
        'lblDisplayProgreso
        '
        Me.lblDisplayProgreso.AutoSize = True
        Me.lblDisplayProgreso.Location = New System.Drawing.Point(706, 419)
        Me.lblDisplayProgreso.Name = "lblDisplayProgreso"
        Me.lblDisplayProgreso.Size = New System.Drawing.Size(97, 13)
        Me.lblDisplayProgreso.TabIndex = 218
        Me.lblDisplayProgreso.Text = "Enviando correo ..."
        '
        'TxtFormatoXML
        '
        Me.TxtFormatoXML.Location = New System.Drawing.Point(706, 378)
        Me.TxtFormatoXML.MaxLength = 50
        Me.TxtFormatoXML.Name = "TxtFormatoXML"
        Me.TxtFormatoXML.Size = New System.Drawing.Size(164, 20)
        Me.TxtFormatoXML.TabIndex = 219
        Me.TxtFormatoXML.Visible = False
        '
        'Frm_EnviaFacturaElectronicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 470)
        Me.Controls.Add(Me.TxtFormatoXML)
        Me.Controls.Add(Me.lblDisplayProgreso)
        Me.Controls.Add(Me.pbBarra)
        Me.Controls.Add(Me.gbFacturas)
        Me.Controls.Add(Me.gbCliente)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gbFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Frm_EnviaFacturaElectronicas"
        Me.Text = "Envia factura electronicas"
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbCliente.ResumeLayout(False)
        Me.gbCliente.PerformLayout()
        Me.gbFacturas.ResumeLayout(False)
        Me.gbFacturas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbCliente As System.Windows.Forms.GroupBox
    Friend WithEvents btnActualizaCorreo As System.Windows.Forms.Button
    Friend WithEvents txtCorreoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCorreo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents lblDisplayHasta As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayDesde As System.Windows.Forms.Label
    Friend WithEvents gbFacturas As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregarDocumentosClientes As System.Windows.Forms.Button
    Friend WithEvents ckbConSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents lblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents CkbMarcarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents pbBarra As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDisplayProgreso As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtFormatoXML As System.Windows.Forms.TextBox
End Class
