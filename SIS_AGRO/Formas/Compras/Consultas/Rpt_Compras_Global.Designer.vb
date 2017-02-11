<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Compras_Global
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Compras_Global))
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbTotalizadoProveedor = New System.Windows.Forms.RadioButton()
        Me.RbTotalizadoProducto = New System.Windows.Forms.RadioButton()
        Me.RbAgrupadoFamilia = New System.Windows.Forms.RadioButton()
        Me.RbGlobal = New System.Windows.Forms.RadioButton()
        Me.chkMostrarSoloDocumentosSaldoMayorCero = New System.Windows.Forms.CheckBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtCodigoProveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.TxtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboInventariables = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.CboFamilia = New System.Windows.Forms.ComboBox()
        Me.lblDisplayFamilia = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.lBAEL2 = New System.Windows.Forms.Label()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.RbListadoDocumentos = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(82, 41)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(211, 20)
        Me.DtFechaHasta.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 300
        Me.Label8.Text = "Hasta :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(82, 15)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(211, 20)
        Me.DtFechaDesde.TabIndex = 0
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.Location = New System.Drawing.Point(6, 21)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(44, 13)
        Me.LblDesde.TabIndex = 299
        Me.LblDesde.Text = "Desde :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbListadoDocumentos)
        Me.GroupBox1.Controls.Add(Me.RbAgrupadoFamilia)
        Me.GroupBox1.Controls.Add(Me.RbGlobal)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 110)
        Me.GroupBox1.TabIndex = 301
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'RbTotalizadoProveedor
        '
        Me.RbTotalizadoProveedor.AutoSize = True
        Me.RbTotalizadoProveedor.Location = New System.Drawing.Point(13, 256)
        Me.RbTotalizadoProveedor.Name = "RbTotalizadoProveedor"
        Me.RbTotalizadoProveedor.Size = New System.Drawing.Size(143, 17)
        Me.RbTotalizadoProveedor.TabIndex = 3
        Me.RbTotalizadoProveedor.Text = "Totalizado por proveedor"
        Me.RbTotalizadoProveedor.UseVisualStyleBackColor = True
        Me.RbTotalizadoProveedor.Visible = False
        '
        'RbTotalizadoProducto
        '
        Me.RbTotalizadoProducto.AutoSize = True
        Me.RbTotalizadoProducto.Location = New System.Drawing.Point(12, 228)
        Me.RbTotalizadoProducto.Name = "RbTotalizadoProducto"
        Me.RbTotalizadoProducto.Size = New System.Drawing.Size(137, 17)
        Me.RbTotalizadoProducto.TabIndex = 2
        Me.RbTotalizadoProducto.Text = "Totalizado por producto"
        Me.RbTotalizadoProducto.UseVisualStyleBackColor = True
        Me.RbTotalizadoProducto.Visible = False
        '
        'RbAgrupadoFamilia
        '
        Me.RbAgrupadoFamilia.AutoSize = True
        Me.RbAgrupadoFamilia.Location = New System.Drawing.Point(6, 42)
        Me.RbAgrupadoFamilia.Name = "RbAgrupadoFamilia"
        Me.RbAgrupadoFamilia.Size = New System.Drawing.Size(121, 17)
        Me.RbAgrupadoFamilia.TabIndex = 1
        Me.RbAgrupadoFamilia.Text = "Agrupado por familia"
        Me.RbAgrupadoFamilia.UseVisualStyleBackColor = True
        '
        'RbGlobal
        '
        Me.RbGlobal.AutoSize = True
        Me.RbGlobal.Checked = True
        Me.RbGlobal.Location = New System.Drawing.Point(6, 19)
        Me.RbGlobal.Name = "RbGlobal"
        Me.RbGlobal.Size = New System.Drawing.Size(66, 17)
        Me.RbGlobal.TabIndex = 0
        Me.RbGlobal.TabStop = True
        Me.RbGlobal.Text = "A detalle"
        Me.RbGlobal.UseVisualStyleBackColor = True
        '
        'chkMostrarSoloDocumentosSaldoMayorCero
        '
        Me.chkMostrarSoloDocumentosSaldoMayorCero.AutoSize = True
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Location = New System.Drawing.Point(82, 67)
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Name = "chkMostrarSoloDocumentosSaldoMayorCero"
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Size = New System.Drawing.Size(211, 17)
        Me.chkMostrarSoloDocumentosSaldoMayorCero.TabIndex = 2
        Me.chkMostrarSoloDocumentosSaldoMayorCero.Text = "Mostrar solo documentos con saldo > 0"
        Me.chkMostrarSoloDocumentosSaldoMayorCero.UseVisualStyleBackColor = True
        '
        'lblProveedor
        '
        Me.lblProveedor.Location = New System.Drawing.Point(79, 115)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(277, 13)
        Me.lblProveedor.TabIndex = 305
        Me.lblProveedor.Text = "_"
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(82, 92)
        Me.txtCodigoProveedor.MaxLength = 8
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(72, 20)
        Me.txtCodigoProveedor.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 304
        Me.Label1.Text = "Proveedor :"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(82, 131)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(211, 21)
        Me.CboAlmacen.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "Almacén :"
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(6, 161)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayCodArticulo.TabIndex = 309
        Me.LblDisplayCodArticulo.Text = "Artículo :"
        '
        'TxtCodigoArticulo
        '
        Me.TxtCodigoArticulo.Location = New System.Drawing.Point(82, 158)
        Me.TxtCodigoArticulo.MaxLength = 16
        Me.TxtCodigoArticulo.Name = "TxtCodigoArticulo"
        Me.TxtCodigoArticulo.Size = New System.Drawing.Size(211, 20)
        Me.TxtCodigoArticulo.TabIndex = 5
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(79, 181)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(277, 13)
        Me.lblArticulo.TabIndex = 310
        Me.lblArticulo.Text = "_"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboMoneda)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboInventariables)
        Me.GroupBox2.Controls.Add(Me.LblDocumento)
        Me.GroupBox2.Controls.Add(Me.CboFamilia)
        Me.GroupBox2.Controls.Add(Me.LblDesde)
        Me.GroupBox2.Controls.Add(Me.lblDisplayFamilia)
        Me.GroupBox2.Controls.Add(Me.lblArticulo)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Controls.Add(Me.LblEstatus)
        Me.GroupBox2.Controls.Add(Me.LblDisplayCodArticulo)
        Me.GroupBox2.Controls.Add(Me.CboEstatus)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.CboDocumento)
        Me.GroupBox2.Controls.Add(Me.lBAEL2)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoArticulo)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.CboAlmacen)
        Me.GroupBox2.Controls.Add(Me.chkMostrarSoloDocumentosSaldoMayorCero)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblProveedor)
        Me.GroupBox2.Controls.Add(Me.txtCodigoProveedor)
        Me.GroupBox2.Location = New System.Drawing.Point(162, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(363, 335)
        Me.GroupBox2.TabIndex = 311
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(82, 251)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(211, 21)
        Me.cboMoneda.TabIndex = 313
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 314
        Me.Label4.Text = "Moneda :"
        '
        'cboInventariables
        '
        Me.cboInventariables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInventariables.FormattingEnabled = True
        Me.cboInventariables.Location = New System.Drawing.Point(82, 197)
        Me.cboInventariables.Name = "cboInventariables"
        Me.cboInventariables.Size = New System.Drawing.Size(211, 21)
        Me.cboInventariables.TabIndex = 311
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(6, 227)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 312
        Me.LblDocumento.Text = "Documento :"
        '
        'CboFamilia
        '
        Me.CboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFamilia.FormattingEnabled = True
        Me.CboFamilia.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.CboFamilia.Location = New System.Drawing.Point(82, 305)
        Me.CboFamilia.Name = "CboFamilia"
        Me.CboFamilia.Size = New System.Drawing.Size(211, 21)
        Me.CboFamilia.TabIndex = 8
        Me.CboFamilia.Visible = False
        '
        'lblDisplayFamilia
        '
        Me.lblDisplayFamilia.AutoSize = True
        Me.lblDisplayFamilia.Location = New System.Drawing.Point(6, 308)
        Me.lblDisplayFamilia.Name = "lblDisplayFamilia"
        Me.lblDisplayFamilia.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayFamilia.TabIndex = 288
        Me.lblDisplayFamilia.Text = "Familia :"
        Me.lblDisplayFamilia.Visible = False
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(6, 281)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 286
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"APLICADO", "CANCELADO", "GRABADO", "RECEPCIONADO PARCIAL", "TODOS"})
        Me.CboEstatus.Location = New System.Drawing.Point(82, 278)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(211, 21)
        Me.CboEstatus.TabIndex = 7
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(82, 224)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(211, 21)
        Me.CboDocumento.TabIndex = 6
        '
        'lBAEL2
        '
        Me.lBAEL2.AutoSize = True
        Me.lBAEL2.Location = New System.Drawing.Point(6, 200)
        Me.lBAEL2.Name = "lBAEL2"
        Me.lBAEL2.Size = New System.Drawing.Size(49, 13)
        Me.lBAEL2.TabIndex = 279
        Me.lBAEL2.Text = "Del tipo :"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(530, 25)
        Me.ToolStrip1.TabIndex = 312
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'RbListadoDocumentos
        '
        Me.RbListadoDocumentos.AutoSize = True
        Me.RbListadoDocumentos.Location = New System.Drawing.Point(6, 67)
        Me.RbListadoDocumentos.Name = "RbListadoDocumentos"
        Me.RbListadoDocumentos.Size = New System.Drawing.Size(135, 17)
        Me.RbListadoDocumentos.TabIndex = 3
        Me.RbListadoDocumentos.Text = "Listado de documentos"
        Me.RbListadoDocumentos.UseVisualStyleBackColor = True
        '
        'Rpt_Compras_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 367)
        Me.Controls.Add(Me.RbTotalizadoProducto)
        Me.Controls.Add(Me.RbTotalizadoProveedor)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Rpt_Compras_Global"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras - Global de documentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDesde As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbTotalizadoProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents RbTotalizadoProducto As System.Windows.Forms.RadioButton
    Friend WithEvents RbAgrupadoFamilia As System.Windows.Forms.RadioButton
    Friend WithEvents RbGlobal As System.Windows.Forms.RadioButton
    Friend WithEvents chkMostrarSoloDocumentosSaldoMayorCero As System.Windows.Forms.CheckBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents txtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents lBAEL2 As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents CboFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayFamilia As System.Windows.Forms.Label
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboInventariables As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents RbListadoDocumentos As System.Windows.Forms.RadioButton
End Class
