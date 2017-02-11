<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Proveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Proveedores))
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.btnGenerarCuentaDolares = New System.Windows.Forms.Button()
        Me.txtCURP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCuentaContabledolares = New System.Windows.Forms.Label()
        Me.txtCuentaContableDolares = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtContactoTelefonoCelular = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContactoNombre = New System.Windows.Forms.TextBox()
        Me.lblDisplayContacto = New System.Windows.Forms.Label()
        Me.DTPFechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.cboTipoProveedor = New System.Windows.Forms.ComboBox()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.txtCuentaContable = New System.Windows.Forms.TextBox()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtCorreoElectronico = New System.Windows.Forms.TextBox()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblDisplayCuentaContable = New System.Windows.Forms.Label()
        Me.lblDisplayFechaApertura = New System.Windows.Forms.Label()
        Me.lblDisplaySaldo = New System.Windows.Forms.Label()
        Me.lblDisplayCorreoElectronico = New System.Windows.Forms.Label()
        Me.lblDisplayCelular = New System.Windows.Forms.Label()
        Me.lblDisplayFax = New System.Windows.Forms.Label()
        Me.lblDisplayTelefono = New System.Windows.Forms.Label()
        Me.lblDisplayTipoProveedor = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.LblDisplayCodProveedor = New System.Windows.Forms.Label()
        Me.TxtCodProveedor = New System.Windows.Forms.TextBox()
        Me.LblDisplayRFC = New System.Windows.Forms.Label()
        Me.LblDisplayDomicilio = New System.Windows.Forms.Label()
        Me.LblDisplayPlazo = New System.Windows.Forms.Label()
        Me.TxtPlazo = New System.Windows.Forms.TextBox()
        Me.LblDisplayNomProveedor = New System.Windows.Forms.Label()
        Me.TxtNomProveedor = New System.Windows.Forms.TextBox()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.CboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbtCodigoProveedor = New System.Windows.Forms.RadioButton()
        Me.rbtNombreProveedor = New System.Windows.Forms.RadioButton()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnEliminaProveedor = New System.Windows.Forms.Button()
        Me.gBoxInformacion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.btnEliminaProveedor)
        Me.gBoxInformacion.Controls.Add(Me.btnGenerarCuentaDolares)
        Me.gBoxInformacion.Controls.Add(Me.txtCURP)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.lblCuentaContabledolares)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContableDolares)
        Me.gBoxInformacion.Controls.Add(Me.Label3)
        Me.gBoxInformacion.Controls.Add(Me.lblCuenta)
        Me.gBoxInformacion.Controls.Add(Me.GroupBox1)
        Me.gBoxInformacion.Controls.Add(Me.DTPFechaApertura)
        Me.gBoxInformacion.Controls.Add(Me.cboTipoProveedor)
        Me.gBoxInformacion.Controls.Add(Me.txtRFC)
        Me.gBoxInformacion.Controls.Add(Me.txtDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.txtCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.txtSaldo)
        Me.gBoxInformacion.Controls.Add(Me.txtFax)
        Me.gBoxInformacion.Controls.Add(Me.txtCorreoElectronico)
        Me.gBoxInformacion.Controls.Add(Me.txtCelular)
        Me.gBoxInformacion.Controls.Add(Me.txtTelefono)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCuentaContable)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFechaApertura)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplaySaldo)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCorreoElectronico)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCelular)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFax)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTelefono)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTipoProveedor)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodProveedor)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodProveedor)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayRFC)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayDomicilio)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayPlazo)
        Me.gBoxInformacion.Controls.Add(Me.TxtPlazo)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNomProveedor)
        Me.gBoxInformacion.Controls.Add(Me.TxtNomProveedor)
        Me.gBoxInformacion.Location = New System.Drawing.Point(7, 34)
        Me.gBoxInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxInformacion.Size = New System.Drawing.Size(589, 683)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información de los Proveedores"
        '
        'btnGenerarCuentaDolares
        '
        Me.btnGenerarCuentaDolares.Location = New System.Drawing.Point(320, 501)
        Me.btnGenerarCuentaDolares.Name = "btnGenerarCuentaDolares"
        Me.btnGenerarCuentaDolares.Size = New System.Drawing.Size(123, 23)
        Me.btnGenerarCuentaDolares.TabIndex = 149
        Me.btnGenerarCuentaDolares.Text = "Generar cuenta en dolares"
        Me.btnGenerarCuentaDolares.UseVisualStyleBackColor = True
        '
        'txtCURP
        '
        Me.txtCURP.Location = New System.Drawing.Point(395, 158)
        Me.txtCURP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCURP.MaxLength = 30
        Me.txtCURP.Name = "txtCURP"
        Me.txtCURP.Size = New System.Drawing.Size(185, 22)
        Me.txtCURP.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(329, 161)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "CURP :"
        '
        'lblCuentaContabledolares
        '
        Me.lblCuentaContabledolares.AutoSize = True
        Me.lblCuentaContabledolares.Location = New System.Drawing.Point(143, 531)
        Me.lblCuentaContabledolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuentaContabledolares.Name = "lblCuentaContabledolares"
        Me.lblCuentaContabledolares.Size = New System.Drawing.Size(16, 17)
        Me.lblCuentaContabledolares.TabIndex = 146
        Me.lblCuentaContabledolares.Text = "_"
        '
        'txtCuentaContableDolares
        '
        Me.txtCuentaContableDolares.Location = New System.Drawing.Point(147, 503)
        Me.txtCuentaContableDolares.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaContableDolares.MaxLength = 15
        Me.txtCuentaContableDolares.Name = "txtCuentaContableDolares"
        Me.txtCuentaContableDolares.Size = New System.Drawing.Size(132, 22)
        Me.txtCuentaContableDolares.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 506)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 42)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Cuenta contable en dolares :"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(143, 483)
        Me.lblCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(16, 17)
        Me.lblCuenta.TabIndex = 143
        Me.lblCuenta.Text = "_"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtContactoTelefonoCelular)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtContactoNombre)
        Me.GroupBox1.Controls.Add(Me.lblDisplayContacto)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 551)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(524, 91)
        Me.GroupBox1.TabIndex = 142
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contacto"
        '
        'txtContactoTelefonoCelular
        '
        Me.txtContactoTelefonoCelular.Location = New System.Drawing.Point(139, 55)
        Me.txtContactoTelefonoCelular.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContactoTelefonoCelular.MaxLength = 30
        Me.txtContactoTelefonoCelular.Name = "txtContactoTelefonoCelular"
        Me.txtContactoTelefonoCelular.Size = New System.Drawing.Size(373, 22)
        Me.txtContactoTelefonoCelular.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Tel/celular :"
        '
        'txtContactoNombre
        '
        Me.txtContactoNombre.Location = New System.Drawing.Point(139, 23)
        Me.txtContactoNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtContactoNombre.MaxLength = 80
        Me.txtContactoNombre.Name = "txtContactoNombre"
        Me.txtContactoNombre.Size = New System.Drawing.Size(373, 22)
        Me.txtContactoNombre.TabIndex = 15
        '
        'lblDisplayContacto
        '
        Me.lblDisplayContacto.AutoSize = True
        Me.lblDisplayContacto.Location = New System.Drawing.Point(5, 27)
        Me.lblDisplayContacto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayContacto.Name = "lblDisplayContacto"
        Me.lblDisplayContacto.Size = New System.Drawing.Size(66, 17)
        Me.lblDisplayContacto.TabIndex = 136
        Me.lblDisplayContacto.Text = "Nombre :"
        '
        'DTPFechaApertura
        '
        Me.DTPFechaApertura.Enabled = False
        Me.DTPFechaApertura.Location = New System.Drawing.Point(147, 390)
        Me.DTPFechaApertura.Margin = New System.Windows.Forms.Padding(4)
        Me.DTPFechaApertura.Name = "DTPFechaApertura"
        Me.DTPFechaApertura.Size = New System.Drawing.Size(265, 22)
        Me.DTPFechaApertura.TabIndex = 11
        '
        'cboTipoProveedor
        '
        Me.cboTipoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoProveedor.FormattingEnabled = True
        Me.cboTipoProveedor.Location = New System.Drawing.Point(146, 425)
        Me.cboTipoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoProveedor.Name = "cboTipoProveedor"
        Me.cboTipoProveedor.Size = New System.Drawing.Size(261, 24)
        Me.cboTipoProveedor.TabIndex = 14
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(147, 158)
        Me.txtRFC.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRFC.MaxLength = 20
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(159, 22)
        Me.txtRFC.TabIndex = 3
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(147, 92)
        Me.txtDomicilio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilio.MaxLength = 120
        Me.txtDomicilio.Multiline = True
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(435, 57)
        Me.txtDomicilio.TabIndex = 2
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Location = New System.Drawing.Point(147, 455)
        Me.txtCuentaContable.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaContable.MaxLength = 15
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.Size = New System.Drawing.Size(132, 22)
        Me.txtCuentaContable.TabIndex = 12
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(147, 358)
        Me.txtSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(132, 22)
        Me.txtSaldo.TabIndex = 10
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(147, 289)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFax.MaxLength = 30
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(261, 22)
        Me.txtFax.TabIndex = 8
        '
        'txtCorreoElectronico
        '
        Me.txtCorreoElectronico.Location = New System.Drawing.Point(147, 256)
        Me.txtCorreoElectronico.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCorreoElectronico.MaxLength = 50
        Me.txtCorreoElectronico.Name = "txtCorreoElectronico"
        Me.txtCorreoElectronico.Size = New System.Drawing.Size(373, 22)
        Me.txtCorreoElectronico.TabIndex = 7
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(147, 223)
        Me.txtCelular.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCelular.MaxLength = 30
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(261, 22)
        Me.txtCelular.TabIndex = 6
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(147, 190)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelefono.MaxLength = 30
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(261, 22)
        Me.txtTelefono.TabIndex = 5
        '
        'lblDisplayCuentaContable
        '
        Me.lblDisplayCuentaContable.Location = New System.Drawing.Point(13, 458)
        Me.lblDisplayCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCuentaContable.Name = "lblDisplayCuentaContable"
        Me.lblDisplayCuentaContable.Size = New System.Drawing.Size(121, 42)
        Me.lblDisplayCuentaContable.TabIndex = 141
        Me.lblDisplayCuentaContable.Text = "Cuenta contable en pesos :"
        '
        'lblDisplayFechaApertura
        '
        Me.lblDisplayFechaApertura.AutoSize = True
        Me.lblDisplayFechaApertura.Location = New System.Drawing.Point(13, 391)
        Me.lblDisplayFechaApertura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaApertura.Name = "lblDisplayFechaApertura"
        Me.lblDisplayFechaApertura.Size = New System.Drawing.Size(82, 17)
        Me.lblDisplayFechaApertura.TabIndex = 140
        Me.lblDisplayFechaApertura.Text = "Fecha alta :"
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(13, 358)
        Me.lblDisplaySaldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplaySaldo.TabIndex = 139
        Me.lblDisplaySaldo.Text = "Saldo :"
        '
        'lblDisplayCorreoElectronico
        '
        Me.lblDisplayCorreoElectronico.AutoSize = True
        Me.lblDisplayCorreoElectronico.Location = New System.Drawing.Point(13, 258)
        Me.lblDisplayCorreoElectronico.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCorreoElectronico.Name = "lblDisplayCorreoElectronico"
        Me.lblDisplayCorreoElectronico.Size = New System.Drawing.Size(132, 17)
        Me.lblDisplayCorreoElectronico.TabIndex = 138
        Me.lblDisplayCorreoElectronico.Text = "Correo electrónico :"
        '
        'lblDisplayCelular
        '
        Me.lblDisplayCelular.AutoSize = True
        Me.lblDisplayCelular.Location = New System.Drawing.Point(13, 225)
        Me.lblDisplayCelular.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCelular.Name = "lblDisplayCelular"
        Me.lblDisplayCelular.Size = New System.Drawing.Size(60, 17)
        Me.lblDisplayCelular.TabIndex = 137
        Me.lblDisplayCelular.Text = "Celular :"
        '
        'lblDisplayFax
        '
        Me.lblDisplayFax.AutoSize = True
        Me.lblDisplayFax.Location = New System.Drawing.Point(13, 292)
        Me.lblDisplayFax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFax.Name = "lblDisplayFax"
        Me.lblDisplayFax.Size = New System.Drawing.Size(38, 17)
        Me.lblDisplayFax.TabIndex = 136
        Me.lblDisplayFax.Text = "Fax :"
        '
        'lblDisplayTelefono
        '
        Me.lblDisplayTelefono.AutoSize = True
        Me.lblDisplayTelefono.Location = New System.Drawing.Point(13, 192)
        Me.lblDisplayTelefono.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTelefono.Name = "lblDisplayTelefono"
        Me.lblDisplayTelefono.Size = New System.Drawing.Size(72, 17)
        Me.lblDisplayTelefono.TabIndex = 135
        Me.lblDisplayTelefono.Text = "Teléfono :"
        '
        'lblDisplayTipoProveedor
        '
        Me.lblDisplayTipoProveedor.AutoSize = True
        Me.lblDisplayTipoProveedor.Location = New System.Drawing.Point(13, 428)
        Me.lblDisplayTipoProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoProveedor.Name = "lblDisplayTipoProveedor"
        Me.lblDisplayTipoProveedor.Size = New System.Drawing.Size(113, 17)
        Me.lblDisplayTipoProveedor.TabIndex = 130
        Me.lblDisplayTipoProveedor.Text = "Tipo proveedor :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(13, 654)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 129
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(147, 650)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(75, 24)
        Me.CboEstatus.TabIndex = 17
        '
        'LblDisplayCodProveedor
        '
        Me.LblDisplayCodProveedor.AutoSize = True
        Me.LblDisplayCodProveedor.Location = New System.Drawing.Point(13, 32)
        Me.LblDisplayCodProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodProveedor.Name = "LblDisplayCodProveedor"
        Me.LblDisplayCodProveedor.Size = New System.Drawing.Size(111, 17)
        Me.LblDisplayCodProveedor.TabIndex = 127
        Me.LblDisplayCodProveedor.Text = "Cod Proveedor :"
        '
        'TxtCodProveedor
        '
        Me.TxtCodProveedor.Location = New System.Drawing.Point(147, 28)
        Me.TxtCodProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodProveedor.MaxLength = 8
        Me.TxtCodProveedor.Name = "TxtCodProveedor"
        Me.TxtCodProveedor.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodProveedor.TabIndex = 0
        '
        'LblDisplayRFC
        '
        Me.LblDisplayRFC.AutoSize = True
        Me.LblDisplayRFC.Location = New System.Drawing.Point(13, 161)
        Me.LblDisplayRFC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayRFC.Name = "LblDisplayRFC"
        Me.LblDisplayRFC.Size = New System.Drawing.Size(43, 17)
        Me.LblDisplayRFC.TabIndex = 125
        Me.LblDisplayRFC.Text = "RFC :"
        '
        'LblDisplayDomicilio
        '
        Me.LblDisplayDomicilio.AutoSize = True
        Me.LblDisplayDomicilio.Location = New System.Drawing.Point(13, 95)
        Me.LblDisplayDomicilio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDomicilio.Name = "LblDisplayDomicilio"
        Me.LblDisplayDomicilio.Size = New System.Drawing.Size(72, 17)
        Me.LblDisplayDomicilio.TabIndex = 124
        Me.LblDisplayDomicilio.Text = "Domicilio :"
        '
        'LblDisplayPlazo
        '
        Me.LblDisplayPlazo.AutoSize = True
        Me.LblDisplayPlazo.Location = New System.Drawing.Point(13, 324)
        Me.LblDisplayPlazo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayPlazo.Name = "LblDisplayPlazo"
        Me.LblDisplayPlazo.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplayPlazo.TabIndex = 123
        Me.LblDisplayPlazo.Text = "Plazo :"
        '
        'TxtPlazo
        '
        Me.TxtPlazo.Location = New System.Drawing.Point(147, 321)
        Me.TxtPlazo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPlazo.MaxLength = 3
        Me.TxtPlazo.Name = "TxtPlazo"
        Me.TxtPlazo.Size = New System.Drawing.Size(75, 22)
        Me.TxtPlazo.TabIndex = 9
        '
        'LblDisplayNomProveedor
        '
        Me.LblDisplayNomProveedor.AutoSize = True
        Me.LblDisplayNomProveedor.Location = New System.Drawing.Point(13, 63)
        Me.LblDisplayNomProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNomProveedor.Name = "LblDisplayNomProveedor"
        Me.LblDisplayNomProveedor.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNomProveedor.TabIndex = 122
        Me.LblDisplayNomProveedor.Text = "Nombre :"
        '
        'TxtNomProveedor
        '
        Me.TxtNomProveedor.Location = New System.Drawing.Point(147, 60)
        Me.TxtNomProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNomProveedor.MaxLength = 120
        Me.TxtNomProveedor.Name = "TxtNomProveedor"
        Me.TxtNomProveedor.Size = New System.Drawing.Size(435, 22)
        Me.TxtNomProveedor.TabIndex = 1
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label4)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rbtCodigoProveedor)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rbtNombreProveedor)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(605, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(572, 683)
        Me.gBoxBusquedaRapida.TabIndex = 1
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(507, 52)
        Me.CboEstatusFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatusFiltro.MaxLength = 1
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(56, 24)
        Me.CboEstatusFiltro.TabIndex = 149
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(444, 57)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Estatus :"
        '
        'rbtCodigoProveedor
        '
        Me.rbtCodigoProveedor.AutoSize = True
        Me.rbtCodigoProveedor.Location = New System.Drawing.Point(143, 22)
        Me.rbtCodigoProveedor.Name = "rbtCodigoProveedor"
        Me.rbtCodigoProveedor.Size = New System.Drawing.Size(142, 21)
        Me.rbtCodigoProveedor.TabIndex = 112
        Me.rbtCodigoProveedor.Text = "Codigo proveedor"
        Me.rbtCodigoProveedor.UseVisualStyleBackColor = True
        '
        'rbtNombreProveedor
        '
        Me.rbtNombreProveedor.AutoSize = True
        Me.rbtNombreProveedor.Checked = True
        Me.rbtNombreProveedor.Location = New System.Drawing.Point(8, 22)
        Me.rbtNombreProveedor.Name = "rbtNombreProveedor"
        Me.rbtNombreProveedor.Size = New System.Drawing.Size(79, 21)
        Me.rbtNombreProveedor.TabIndex = 111
        Me.rbtNombreProveedor.TabStop = True
        Me.rbtNombreProveedor.Text = "Nombre"
        Me.rbtNombreProveedor.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 84)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(556, 587)
        Me.Grid.TabIndex = 110
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 54)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(428, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1189, 27)
        Me.tsMenu.TabIndex = 2
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(76, 24)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(72, 24)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(78, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(90, 24)
        Me.tsbCancelar.Text = "&Cancelar"
        '
        'tsbImprimirListado
        '
        Me.tsbImprimirListado.Image = CType(resources.GetObject("tsbImprimirListado.Image"), System.Drawing.Image)
        Me.tsbImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirListado.Name = "tsbImprimirListado"
        Me.tsbImprimirListado.Size = New System.Drawing.Size(139, 24)
        Me.tsbImprimirListado.Text = "&Imprimir listado"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 726)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1189, 25)
        Me.StatusStripEstado.TabIndex = 128
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(61, 20)
        Me.tssLabel.Text = "Estado :"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 20)
        '
        'btnEliminaProveedor
        '
        Me.btnEliminaProveedor.Location = New System.Drawing.Point(476, 20)
        Me.btnEliminaProveedor.Name = "btnEliminaProveedor"
        Me.btnEliminaProveedor.Size = New System.Drawing.Size(104, 23)
        Me.btnEliminaProveedor.TabIndex = 150
        Me.btnEliminaProveedor.Text = "Eliminar"
        Me.btnEliminaProveedor.UseVisualStyleBackColor = True
        '
        'Catalogo_Proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1189, 751)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Proveedores"
        Me.Text = "Catalogo proveedores"
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFechaApertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTipoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtCorreoElectronico As System.Windows.Forms.TextBox
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCuentaContable As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaApertura As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySaldo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCorreoElectronico As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCelular As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFax As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTelefono As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTipoProveedor As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayCodProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtCodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayRFC As System.Windows.Forms.Label
    Friend WithEvents LblDisplayDomicilio As System.Windows.Forms.Label
    Friend WithEvents LblDisplayPlazo As System.Windows.Forms.Label
    Friend WithEvents TxtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayNomProveedor As System.Windows.Forms.Label
    Friend WithEvents TxtNomProveedor As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContactoTelefonoCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtContactoNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayContacto As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents lblCuentaContabledolares As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContableDolares As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCURP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents rbtCodigoProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNombreProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGenerarCuentaDolares As System.Windows.Forms.Button
    Friend WithEvents btnEliminaProveedor As System.Windows.Forms.Button
End Class
