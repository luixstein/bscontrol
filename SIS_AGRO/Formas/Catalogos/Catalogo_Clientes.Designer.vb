<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Catalogo_Clientes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Catalogo_Clientes))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox()
        Me.lblDisplayUsoCFDI = New System.Windows.Forms.Label()
        Me.cboUsoCFDI = New System.Windows.Forms.ComboBox()
        Me.TxtIdRelacion = New System.Windows.Forms.TextBox()
        Me.LblDisplayCodigoPropietario = New System.Windows.Forms.Label()
        Me.LblNombrePropietario = New System.Windows.Forms.Label()
        Me.TxtCodigoPropietario = New System.Windows.Forms.TextBox()
        Me.chkEsContribuyenteIEPS = New System.Windows.Forms.CheckBox()
        Me.lblDisplayNumeroRegistroIdentificadorExtranjero = New System.Windows.Forms.Label()
        Me.txtNumeroRegistroIdentificadorExtranjero = New System.Windows.Forms.TextBox()
        Me.cboTipoMercado = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTipoCliente = New System.Windows.Forms.Label()
        Me.lblDisplayTipoPersona = New System.Windows.Forms.Label()
        Me.cboTipoPersona = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCelCliente = New System.Windows.Forms.Label()
        Me.txtNumeroCelular = New System.Windows.Forms.TextBox()
        Me.LblDisplayTelefonoCliente = New System.Windows.Forms.Label()
        Me.txtNumeroTelefono = New System.Windows.Forms.TextBox()
        Me.lblDisplayCURP = New System.Windows.Forms.Label()
        Me.txtCurp = New System.Windows.Forms.TextBox()
        Me.lblDisplayRFC = New System.Windows.Forms.Label()
        Me.txtRfc = New System.Windows.Forms.TextBox()
        Me.LblDisplayNombreCultivo = New System.Windows.Forms.Label()
        Me.TxtNombreCliente = New System.Windows.Forms.TextBox()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCodigo = New System.Windows.Forms.Label()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.lblDisplayCalle = New System.Windows.Forms.Label()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.lblDisplayNumExterior = New System.Windows.Forms.Label()
        Me.txtNumeroExterior = New System.Windows.Forms.TextBox()
        Me.lblDisplayNumInterior = New System.Windows.Forms.Label()
        Me.txtNumeroInterior = New System.Windows.Forms.TextBox()
        Me.lblDisplayColonia = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.lblDisplayLocalidad = New System.Windows.Forms.Label()
        Me.txtLocalidad = New System.Windows.Forms.TextBox()
        Me.lblDisplayEstado = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.lblDisplayPais = New System.Windows.Forms.Label()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.lblDisplayCP = New System.Windows.Forms.Label()
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.gbDatosVentas = New System.Windows.Forms.GroupBox()
        Me.TxtCodigoAlmacen = New System.Windows.Forms.TextBox()
        Me.LblAlmacenCliente = New System.Windows.Forms.Label()
        Me.chkPermitirVentaCredito = New System.Windows.Forms.CheckBox()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.cboZona = New System.Windows.Forms.ComboBox()
        Me.lblDisplayVendedor = New System.Windows.Forms.Label()
        Me.lblDisplayZona = New System.Windows.Forms.Label()
        Me.gbCuentasContables = New System.Windows.Forms.GroupBox()
        Me.BtnGeneraCuentaContableDolares = New System.Windows.Forms.Button()
        Me.lblDisplayCuentaConDolares = New System.Windows.Forms.Label()
        Me.txtCuentaContableDolares = New System.Windows.Forms.TextBox()
        Me.lblCuentaContable = New System.Windows.Forms.Label()
        Me.txtCuentaContable = New System.Windows.Forms.TextBox()
        Me.gbDomicilio = New System.Windows.Forms.GroupBox()
        Me.cboPais = New System.Windows.Forms.ComboBox()
        Me.cboMunicipio = New System.Windows.Forms.ComboBox()
        Me.txtCiudad = New System.Windows.Forms.TextBox()
        Me.lblDisplayCiudad = New System.Windows.Forms.Label()
        Me.gbCxc = New System.Windows.Forms.GroupBox()
        Me.lblDisplayLimiteCredito = New System.Windows.Forms.Label()
        Me.txtLimiteCredito = New System.Windows.Forms.TextBox()
        Me.lblDisplayDiasPlazo = New System.Windows.Forms.Label()
        Me.txtDiasPlazo = New System.Windows.Forms.TextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbFechaAlta = New System.Windows.Forms.GroupBox()
        Me.DpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFechaAlta = New System.Windows.Forms.Label()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.CboEstatusFiltro = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtCodigoCliente = New System.Windows.Forms.RadioButton()
        Me.rbtNombreCliente = New System.Windows.Forms.RadioButton()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.gbCorreo = New System.Windows.Forms.GroupBox()
        Me.cboNombreXML = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDisplayCorreoCliente = New System.Windows.Forms.Label()
        Me.txtCorreoCliente = New System.Windows.Forms.TextBox()
        Me.gbMetodoPago = New System.Windows.Forms.GroupBox()
        Me.cboFormaPagoUSD = New System.Windows.Forms.ComboBox()
        Me.lblDisplayNCuentaDlls = New System.Windows.Forms.Label()
        Me.txtNumeroCuentaDolares = New System.Windows.Forms.TextBox()
        Me.lblDisplayFormaPagoUSD = New System.Windows.Forms.Label()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayNumCuenta = New System.Windows.Forms.Label()
        Me.txtNumeroCuenta = New System.Windows.Forms.TextBox()
        Me.lblDisplayFormaPago = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gBoxInformacion.SuspendLayout()
        Me.gbDatosVentas.SuspendLayout()
        Me.gbCuentasContables.SuspendLayout()
        Me.gbDomicilio.SuspendLayout()
        Me.gbCxc.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFechaAlta.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCorreo.SuspendLayout()
        Me.gbMetodoPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbEliminar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1138, 27)
        Me.tsMenu.TabIndex = 8
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(66, 24)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(61, 24)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(66, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbEliminar
        '
        Me.tsbEliminar.Image = CType(resources.GetObject("tsbEliminar.Image"), System.Drawing.Image)
        Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminar.Name = "tsbEliminar"
        Me.tsbEliminar.Size = New System.Drawing.Size(74, 24)
        Me.tsbEliminar.Text = "Eliminar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(77, 24)
        Me.tsbCancelar.Text = "&Cancelar"
        '
        'tsbImprimirListado
        '
        Me.tsbImprimirListado.Image = CType(resources.GetObject("tsbImprimirListado.Image"), System.Drawing.Image)
        Me.tsbImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirListado.Name = "tsbImprimirListado"
        Me.tsbImprimirListado.Size = New System.Drawing.Size(115, 24)
        Me.tsbImprimirListado.Text = "&Imprimir listado"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayUsoCFDI)
        Me.gBoxInformacion.Controls.Add(Me.cboUsoCFDI)
        Me.gBoxInformacion.Controls.Add(Me.TxtIdRelacion)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayCodigoPropietario)
        Me.gBoxInformacion.Controls.Add(Me.LblNombrePropietario)
        Me.gBoxInformacion.Controls.Add(Me.TxtCodigoPropietario)
        Me.gBoxInformacion.Controls.Add(Me.chkEsContribuyenteIEPS)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayNumeroRegistroIdentificadorExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.txtNumeroRegistroIdentificadorExtranjero)
        Me.gBoxInformacion.Controls.Add(Me.cboTipoMercado)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTipoCliente)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTipoPersona)
        Me.gBoxInformacion.Controls.Add(Me.cboTipoPersona)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCelCliente)
        Me.gBoxInformacion.Controls.Add(Me.txtNumeroCelular)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayTelefonoCliente)
        Me.gBoxInformacion.Controls.Add(Me.txtNumeroTelefono)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCURP)
        Me.gBoxInformacion.Controls.Add(Me.txtCurp)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayRFC)
        Me.gBoxInformacion.Controls.Add(Me.txtRfc)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayNombreCultivo)
        Me.gBoxInformacion.Controls.Add(Me.TxtNombreCliente)
        Me.gBoxInformacion.Controls.Add(Me.LblEstatus)
        Me.gBoxInformacion.Controls.Add(Me.CboEstatus)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayCodigo)
        Me.gBoxInformacion.Controls.Add(Me.txtCodigoCliente)
        Me.gBoxInformacion.Location = New System.Drawing.Point(12, 28)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(395, 341)
        Me.gBoxInformacion.TabIndex = 0
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Datos generales"
        '
        'lblDisplayUsoCFDI
        '
        Me.lblDisplayUsoCFDI.AutoSize = True
        Me.lblDisplayUsoCFDI.Location = New System.Drawing.Point(6, 243)
        Me.lblDisplayUsoCFDI.Name = "lblDisplayUsoCFDI"
        Me.lblDisplayUsoCFDI.Size = New System.Drawing.Size(76, 13)
        Me.lblDisplayUsoCFDI.TabIndex = 132
        Me.lblDisplayUsoCFDI.Text = "Uso del CFDI :"
        '
        'cboUsoCFDI
        '
        Me.cboUsoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsoCFDI.FormattingEnabled = True
        Me.cboUsoCFDI.Items.AddRange(New Object() {"MORAL", "FISICA"})
        Me.cboUsoCFDI.Location = New System.Drawing.Point(87, 240)
        Me.cboUsoCFDI.MaxLength = 1
        Me.cboUsoCFDI.Name = "cboUsoCFDI"
        Me.cboUsoCFDI.Size = New System.Drawing.Size(301, 21)
        Me.cboUsoCFDI.TabIndex = 10
        '
        'TxtIdRelacion
        '
        Me.TxtIdRelacion.Location = New System.Drawing.Point(209, 45)
        Me.TxtIdRelacion.MaxLength = 6
        Me.TxtIdRelacion.Name = "TxtIdRelacion"
        Me.TxtIdRelacion.Size = New System.Drawing.Size(92, 20)
        Me.TxtIdRelacion.TabIndex = 130
        Me.TxtIdRelacion.Visible = False
        '
        'LblDisplayCodigoPropietario
        '
        Me.LblDisplayCodigoPropietario.Location = New System.Drawing.Point(6, 42)
        Me.LblDisplayCodigoPropietario.Name = "LblDisplayCodigoPropietario"
        Me.LblDisplayCodigoPropietario.Size = New System.Drawing.Size(66, 27)
        Me.LblDisplayCodigoPropietario.TabIndex = 129
        Me.LblDisplayCodigoPropietario.Text = "Código " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "propietario :"
        '
        'LblNombrePropietario
        '
        Me.LblNombrePropietario.AutoSize = True
        Me.LblNombrePropietario.Location = New System.Drawing.Point(76, 68)
        Me.LblNombrePropietario.Name = "LblNombrePropietario"
        Me.LblNombrePropietario.Size = New System.Drawing.Size(13, 13)
        Me.LblNombrePropietario.TabIndex = 128
        Me.LblNombrePropietario.Text = "_"
        '
        'TxtCodigoPropietario
        '
        Me.TxtCodigoPropietario.Location = New System.Drawing.Point(76, 45)
        Me.TxtCodigoPropietario.MaxLength = 6
        Me.TxtCodigoPropietario.Name = "TxtCodigoPropietario"
        Me.TxtCodigoPropietario.Size = New System.Drawing.Size(114, 20)
        Me.TxtCodigoPropietario.TabIndex = 1
        '
        'chkEsContribuyenteIEPS
        '
        Me.chkEsContribuyenteIEPS.Location = New System.Drawing.Point(117, 298)
        Me.chkEsContribuyenteIEPS.Name = "chkEsContribuyenteIEPS"
        Me.chkEsContribuyenteIEPS.Size = New System.Drawing.Size(258, 31)
        Me.chkEsContribuyenteIEPS.TabIndex = 12
        Me.chkEsContribuyenteIEPS.Text = "Es contribuyente del IEPS ? ( Si se le desglosará por separado)"
        Me.chkEsContribuyenteIEPS.UseVisualStyleBackColor = True
        '
        'lblDisplayNumeroRegistroIdentificadorExtranjero
        '
        Me.lblDisplayNumeroRegistroIdentificadorExtranjero.Location = New System.Drawing.Point(6, 267)
        Me.lblDisplayNumeroRegistroIdentificadorExtranjero.Name = "lblDisplayNumeroRegistroIdentificadorExtranjero"
        Me.lblDisplayNumeroRegistroIdentificadorExtranjero.Size = New System.Drawing.Size(105, 27)
        Me.lblDisplayNumeroRegistroIdentificadorExtranjero.TabIndex = 125
        Me.lblDisplayNumeroRegistroIdentificadorExtranjero.Text = "Num registro id extranjero (TAX ID) :"
        '
        'txtNumeroRegistroIdentificadorExtranjero
        '
        Me.txtNumeroRegistroIdentificadorExtranjero.Location = New System.Drawing.Point(116, 270)
        Me.txtNumeroRegistroIdentificadorExtranjero.MaxLength = 100
        Me.txtNumeroRegistroIdentificadorExtranjero.Name = "txtNumeroRegistroIdentificadorExtranjero"
        Me.txtNumeroRegistroIdentificadorExtranjero.Size = New System.Drawing.Size(185, 20)
        Me.txtNumeroRegistroIdentificadorExtranjero.TabIndex = 11
        '
        'cboTipoMercado
        '
        Me.cboTipoMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMercado.FormattingEnabled = True
        Me.cboTipoMercado.Location = New System.Drawing.Point(77, 19)
        Me.cboTipoMercado.Name = "cboTipoMercado"
        Me.cboTipoMercado.Size = New System.Drawing.Size(211, 21)
        Me.cboTipoMercado.TabIndex = 0
        '
        'lblDisplayTipoCliente
        '
        Me.lblDisplayTipoCliente.AutoSize = True
        Me.lblDisplayTipoCliente.Location = New System.Drawing.Point(6, 22)
        Me.lblDisplayTipoCliente.Name = "lblDisplayTipoCliente"
        Me.lblDisplayTipoCliente.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayTipoCliente.TabIndex = 121
        Me.lblDisplayTipoCliente.Text = "Tipo cliente:"
        '
        'lblDisplayTipoPersona
        '
        Me.lblDisplayTipoPersona.AutoSize = True
        Me.lblDisplayTipoPersona.Location = New System.Drawing.Point(219, 140)
        Me.lblDisplayTipoPersona.Name = "lblDisplayTipoPersona"
        Me.lblDisplayTipoPersona.Size = New System.Drawing.Size(75, 13)
        Me.lblDisplayTipoPersona.TabIndex = 119
        Me.lblDisplayTipoPersona.Text = "Tipo persona :"
        '
        'cboTipoPersona
        '
        Me.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPersona.FormattingEnabled = True
        Me.cboTipoPersona.Items.AddRange(New Object() {"MORAL", "FISICA"})
        Me.cboTipoPersona.Location = New System.Drawing.Point(300, 136)
        Me.cboTipoPersona.MaxLength = 1
        Me.cboTipoPersona.Name = "cboTipoPersona"
        Me.cboTipoPersona.Size = New System.Drawing.Size(89, 21)
        Me.cboTipoPersona.TabIndex = 6
        '
        'lblDisplayCelCliente
        '
        Me.lblDisplayCelCliente.AutoSize = True
        Me.lblDisplayCelCliente.Location = New System.Drawing.Point(6, 218)
        Me.lblDisplayCelCliente.Name = "lblDisplayCelCliente"
        Me.lblDisplayCelCliente.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayCelCliente.TabIndex = 117
        Me.lblDisplayCelCliente.Text = "# Celular :"
        '
        'txtNumeroCelular
        '
        Me.txtNumeroCelular.Location = New System.Drawing.Point(77, 215)
        Me.txtNumeroCelular.MaxLength = 15
        Me.txtNumeroCelular.Name = "txtNumeroCelular"
        Me.txtNumeroCelular.Size = New System.Drawing.Size(129, 20)
        Me.txtNumeroCelular.TabIndex = 9
        '
        'LblDisplayTelefonoCliente
        '
        Me.LblDisplayTelefonoCliente.AutoSize = True
        Me.LblDisplayTelefonoCliente.Location = New System.Drawing.Point(6, 192)
        Me.LblDisplayTelefonoCliente.Name = "LblDisplayTelefonoCliente"
        Me.LblDisplayTelefonoCliente.Size = New System.Drawing.Size(65, 13)
        Me.LblDisplayTelefonoCliente.TabIndex = 115
        Me.LblDisplayTelefonoCliente.Text = "# Telefono :"
        '
        'txtNumeroTelefono
        '
        Me.txtNumeroTelefono.Location = New System.Drawing.Point(76, 189)
        Me.txtNumeroTelefono.MaxLength = 15
        Me.txtNumeroTelefono.Name = "txtNumeroTelefono"
        Me.txtNumeroTelefono.Size = New System.Drawing.Size(130, 20)
        Me.txtNumeroTelefono.TabIndex = 8
        '
        'lblDisplayCURP
        '
        Me.lblDisplayCURP.AutoSize = True
        Me.lblDisplayCURP.Location = New System.Drawing.Point(6, 166)
        Me.lblDisplayCURP.Name = "lblDisplayCURP"
        Me.lblDisplayCURP.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayCURP.TabIndex = 113
        Me.lblDisplayCURP.Text = "CURP :"
        '
        'txtCurp
        '
        Me.txtCurp.Location = New System.Drawing.Point(76, 163)
        Me.txtCurp.MaxLength = 30
        Me.txtCurp.Name = "txtCurp"
        Me.txtCurp.Size = New System.Drawing.Size(130, 20)
        Me.txtCurp.TabIndex = 7
        '
        'lblDisplayRFC
        '
        Me.lblDisplayRFC.AutoSize = True
        Me.lblDisplayRFC.Location = New System.Drawing.Point(6, 140)
        Me.lblDisplayRFC.Name = "lblDisplayRFC"
        Me.lblDisplayRFC.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayRFC.TabIndex = 111
        Me.lblDisplayRFC.Text = "RFC :"
        '
        'txtRfc
        '
        Me.txtRfc.Location = New System.Drawing.Point(77, 137)
        Me.txtRfc.MaxLength = 13
        Me.txtRfc.Name = "txtRfc"
        Me.txtRfc.Size = New System.Drawing.Size(129, 20)
        Me.txtRfc.TabIndex = 5
        '
        'LblDisplayNombreCultivo
        '
        Me.LblDisplayNombreCultivo.AutoSize = True
        Me.LblDisplayNombreCultivo.Location = New System.Drawing.Point(6, 114)
        Me.LblDisplayNombreCultivo.Name = "LblDisplayNombreCultivo"
        Me.LblDisplayNombreCultivo.Size = New System.Drawing.Size(50, 13)
        Me.LblDisplayNombreCultivo.TabIndex = 74
        Me.LblDisplayNombreCultivo.Text = "Nombre :"
        '
        'TxtNombreCliente
        '
        Me.TxtNombreCliente.Location = New System.Drawing.Point(77, 111)
        Me.TxtNombreCliente.MaxLength = 80
        Me.TxtNombreCliente.Name = "TxtNombreCliente"
        Me.TxtNombreCliente.Size = New System.Drawing.Size(312, 20)
        Me.TxtNombreCliente.TabIndex = 4
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(275, 88)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 22
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(325, 84)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(64, 21)
        Me.CboEstatus.TabIndex = 3
        '
        'lblDisplayCodigo
        '
        Me.lblDisplayCodigo.AutoSize = True
        Me.lblDisplayCodigo.Location = New System.Drawing.Point(6, 88)
        Me.lblDisplayCodigo.Name = "lblDisplayCodigo"
        Me.lblDisplayCodigo.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplayCodigo.TabIndex = 8
        Me.lblDisplayCodigo.Text = "Código :"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Location = New System.Drawing.Point(77, 85)
        Me.txtCodigoCliente.MaxLength = 6
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(129, 20)
        Me.txtCodigoCliente.TabIndex = 2
        '
        'lblDisplayCalle
        '
        Me.lblDisplayCalle.AutoSize = True
        Me.lblDisplayCalle.Location = New System.Drawing.Point(7, 101)
        Me.lblDisplayCalle.Name = "lblDisplayCalle"
        Me.lblDisplayCalle.Size = New System.Drawing.Size(36, 13)
        Me.lblDisplayCalle.TabIndex = 93
        Me.lblDisplayCalle.Text = "Calle :"
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(76, 98)
        Me.txtCalle.MaxLength = 100
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(312, 20)
        Me.txtCalle.TabIndex = 4
        '
        'lblDisplayNumExterior
        '
        Me.lblDisplayNumExterior.AutoSize = True
        Me.lblDisplayNumExterior.Location = New System.Drawing.Point(7, 127)
        Me.lblDisplayNumExterior.Name = "lblDisplayNumExterior"
        Me.lblDisplayNumExterior.Size = New System.Drawing.Size(58, 13)
        Me.lblDisplayNumExterior.TabIndex = 95
        Me.lblDisplayNumExterior.Text = "# Exterior :"
        '
        'txtNumeroExterior
        '
        Me.txtNumeroExterior.Location = New System.Drawing.Point(76, 124)
        Me.txtNumeroExterior.MaxLength = 20
        Me.txtNumeroExterior.Name = "txtNumeroExterior"
        Me.txtNumeroExterior.Size = New System.Drawing.Size(102, 20)
        Me.txtNumeroExterior.TabIndex = 5
        '
        'lblDisplayNumInterior
        '
        Me.lblDisplayNumInterior.AutoSize = True
        Me.lblDisplayNumInterior.Location = New System.Drawing.Point(225, 127)
        Me.lblDisplayNumInterior.Name = "lblDisplayNumInterior"
        Me.lblDisplayNumInterior.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayNumInterior.TabIndex = 97
        Me.lblDisplayNumInterior.Text = "# Interior :"
        '
        'txtNumeroInterior
        '
        Me.txtNumeroInterior.Location = New System.Drawing.Point(286, 124)
        Me.txtNumeroInterior.MaxLength = 20
        Me.txtNumeroInterior.Name = "txtNumeroInterior"
        Me.txtNumeroInterior.Size = New System.Drawing.Size(102, 20)
        Me.txtNumeroInterior.TabIndex = 6
        '
        'lblDisplayColonia
        '
        Me.lblDisplayColonia.AutoSize = True
        Me.lblDisplayColonia.Location = New System.Drawing.Point(7, 153)
        Me.lblDisplayColonia.Name = "lblDisplayColonia"
        Me.lblDisplayColonia.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayColonia.TabIndex = 99
        Me.lblDisplayColonia.Text = "Colonia :"
        '
        'txtColonia
        '
        Me.txtColonia.Location = New System.Drawing.Point(76, 150)
        Me.txtColonia.MaxLength = 50
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(312, 20)
        Me.txtColonia.TabIndex = 7
        '
        'lblDisplayLocalidad
        '
        Me.lblDisplayLocalidad.AutoSize = True
        Me.lblDisplayLocalidad.Location = New System.Drawing.Point(7, 179)
        Me.lblDisplayLocalidad.Name = "lblDisplayLocalidad"
        Me.lblDisplayLocalidad.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayLocalidad.TabIndex = 103
        Me.lblDisplayLocalidad.Text = "Localidad :"
        '
        'txtLocalidad
        '
        Me.txtLocalidad.Location = New System.Drawing.Point(76, 176)
        Me.txtLocalidad.MaxLength = 50
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.Size = New System.Drawing.Size(312, 20)
        Me.txtLocalidad.TabIndex = 8
        '
        'lblDisplayEstado
        '
        Me.lblDisplayEstado.AutoSize = True
        Me.lblDisplayEstado.Location = New System.Drawing.Point(7, 48)
        Me.lblDisplayEstado.Name = "lblDisplayEstado"
        Me.lblDisplayEstado.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplayEstado.TabIndex = 104
        Me.lblDisplayEstado.Text = "Estado :"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstado.Location = New System.Drawing.Point(77, 45)
        Me.cboEstado.MaxLength = 80
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(313, 21)
        Me.cboEstado.TabIndex = 1
        '
        'lblDisplayPais
        '
        Me.lblDisplayPais.AutoSize = True
        Me.lblDisplayPais.Location = New System.Drawing.Point(7, 22)
        Me.lblDisplayPais.Name = "lblDisplayPais"
        Me.lblDisplayPais.Size = New System.Drawing.Size(35, 13)
        Me.lblDisplayPais.TabIndex = 107
        Me.lblDisplayPais.Text = "País :"
        '
        'txtPais
        '
        Me.txtPais.Location = New System.Drawing.Point(230, 19)
        Me.txtPais.MaxLength = 50
        Me.txtPais.Name = "txtPais"
        Me.txtPais.ReadOnly = True
        Me.txtPais.Size = New System.Drawing.Size(160, 20)
        Me.txtPais.TabIndex = 10
        '
        'lblDisplayCP
        '
        Me.lblDisplayCP.AutoSize = True
        Me.lblDisplayCP.Location = New System.Drawing.Point(7, 205)
        Me.lblDisplayCP.Name = "lblDisplayCP"
        Me.lblDisplayCP.Size = New System.Drawing.Size(77, 13)
        Me.lblDisplayCP.TabIndex = 109
        Me.lblDisplayCP.Text = "Código postal :"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Location = New System.Drawing.Point(87, 202)
        Me.txtCodigoPostal.MaxLength = 10
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(130, 20)
        Me.txtCodigoPostal.TabIndex = 9
        '
        'gbDatosVentas
        '
        Me.gbDatosVentas.Controls.Add(Me.TxtCodigoAlmacen)
        Me.gbDatosVentas.Controls.Add(Me.LblAlmacenCliente)
        Me.gbDatosVentas.Controls.Add(Me.chkPermitirVentaCredito)
        Me.gbDatosVentas.Controls.Add(Me.cboVendedor)
        Me.gbDatosVentas.Controls.Add(Me.cboZona)
        Me.gbDatosVentas.Controls.Add(Me.lblDisplayVendedor)
        Me.gbDatosVentas.Controls.Add(Me.lblDisplayZona)
        Me.gbDatosVentas.Location = New System.Drawing.Point(414, 28)
        Me.gbDatosVentas.Name = "gbDatosVentas"
        Me.gbDatosVentas.Size = New System.Drawing.Size(323, 116)
        Me.gbDatosVentas.TabIndex = 2
        Me.gbDatosVentas.TabStop = False
        Me.gbDatosVentas.Text = "Datos de ventas :"
        '
        'TxtCodigoAlmacen
        '
        Me.TxtCodigoAlmacen.Location = New System.Drawing.Point(115, 85)
        Me.TxtCodigoAlmacen.MaxLength = 15
        Me.TxtCodigoAlmacen.Name = "TxtCodigoAlmacen"
        Me.TxtCodigoAlmacen.Size = New System.Drawing.Size(140, 20)
        Me.TxtCodigoAlmacen.TabIndex = 3
        '
        'LblAlmacenCliente
        '
        Me.LblAlmacenCliente.AutoSize = True
        Me.LblAlmacenCliente.Location = New System.Drawing.Point(6, 88)
        Me.LblAlmacenCliente.Name = "LblAlmacenCliente"
        Me.LblAlmacenCliente.Size = New System.Drawing.Size(88, 13)
        Me.LblAlmacenCliente.TabIndex = 75
        Me.LblAlmacenCliente.Text = "Almacén cliente :"
        '
        'chkPermitirVentaCredito
        '
        Me.chkPermitirVentaCredito.AutoSize = True
        Me.chkPermitirVentaCredito.Location = New System.Drawing.Point(115, 62)
        Me.chkPermitirVentaCredito.Name = "chkPermitirVentaCredito"
        Me.chkPermitirVentaCredito.Size = New System.Drawing.Size(140, 17)
        Me.chkPermitirVentaCredito.TabIndex = 2
        Me.chkPermitirVentaCredito.Text = "Permitir venta de crédito"
        Me.chkPermitirVentaCredito.UseVisualStyleBackColor = True
        '
        'cboVendedor
        '
        Me.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Items.AddRange(New Object() {"A", "B"})
        Me.cboVendedor.Location = New System.Drawing.Point(115, 38)
        Me.cboVendedor.MaxLength = 1
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(140, 21)
        Me.cboVendedor.TabIndex = 1
        '
        'cboZona
        '
        Me.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZona.Enabled = False
        Me.cboZona.FormattingEnabled = True
        Me.cboZona.Items.AddRange(New Object() {"A", "B"})
        Me.cboZona.Location = New System.Drawing.Point(115, 14)
        Me.cboZona.MaxLength = 1
        Me.cboZona.Name = "cboZona"
        Me.cboZona.Size = New System.Drawing.Size(140, 21)
        Me.cboZona.TabIndex = 0
        '
        'lblDisplayVendedor
        '
        Me.lblDisplayVendedor.AutoSize = True
        Me.lblDisplayVendedor.Location = New System.Drawing.Point(6, 42)
        Me.lblDisplayVendedor.Name = "lblDisplayVendedor"
        Me.lblDisplayVendedor.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayVendedor.TabIndex = 74
        Me.lblDisplayVendedor.Text = "Vendedor :"
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(6, 18)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 8
        Me.lblDisplayZona.Text = "Zona :"
        '
        'gbCuentasContables
        '
        Me.gbCuentasContables.Controls.Add(Me.BtnGeneraCuentaContableDolares)
        Me.gbCuentasContables.Controls.Add(Me.lblDisplayCuentaConDolares)
        Me.gbCuentasContables.Controls.Add(Me.txtCuentaContableDolares)
        Me.gbCuentasContables.Controls.Add(Me.lblCuentaContable)
        Me.gbCuentasContables.Controls.Add(Me.txtCuentaContable)
        Me.gbCuentasContables.Location = New System.Drawing.Point(414, 150)
        Me.gbCuentasContables.Name = "gbCuentasContables"
        Me.gbCuentasContables.Size = New System.Drawing.Size(323, 98)
        Me.gbCuentasContables.TabIndex = 3
        Me.gbCuentasContables.TabStop = False
        Me.gbCuentasContables.Text = "Datos contables :"
        '
        'BtnGeneraCuentaContableDolares
        '
        Me.BtnGeneraCuentaContableDolares.Location = New System.Drawing.Point(115, 65)
        Me.BtnGeneraCuentaContableDolares.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnGeneraCuentaContableDolares.Name = "BtnGeneraCuentaContableDolares"
        Me.BtnGeneraCuentaContableDolares.Size = New System.Drawing.Size(126, 19)
        Me.BtnGeneraCuentaContableDolares.TabIndex = 75
        Me.BtnGeneraCuentaContableDolares.Text = "Generar cuenta"
        Me.BtnGeneraCuentaContableDolares.UseVisualStyleBackColor = True
        '
        'lblDisplayCuentaConDolares
        '
        Me.lblDisplayCuentaConDolares.AutoSize = True
        Me.lblDisplayCuentaConDolares.Location = New System.Drawing.Point(6, 44)
        Me.lblDisplayCuentaConDolares.Name = "lblDisplayCuentaConDolares"
        Me.lblDisplayCuentaConDolares.Size = New System.Drawing.Size(99, 13)
        Me.lblDisplayCuentaConDolares.TabIndex = 74
        Me.lblDisplayCuentaConDolares.Text = "Cuenta en dólares :"
        '
        'txtCuentaContableDolares
        '
        Me.txtCuentaContableDolares.Location = New System.Drawing.Point(115, 41)
        Me.txtCuentaContableDolares.MaxLength = 20
        Me.txtCuentaContableDolares.Name = "txtCuentaContableDolares"
        Me.txtCuentaContableDolares.Size = New System.Drawing.Size(201, 20)
        Me.txtCuentaContableDolares.TabIndex = 1
        '
        'lblCuentaContable
        '
        Me.lblCuentaContable.AutoSize = True
        Me.lblCuentaContable.Location = New System.Drawing.Point(6, 18)
        Me.lblCuentaContable.Name = "lblCuentaContable"
        Me.lblCuentaContable.Size = New System.Drawing.Size(91, 13)
        Me.lblCuentaContable.TabIndex = 8
        Me.lblCuentaContable.Text = "Cuenta contable :"
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Enabled = False
        Me.txtCuentaContable.Location = New System.Drawing.Point(115, 15)
        Me.txtCuentaContable.MaxLength = 20
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.Size = New System.Drawing.Size(201, 20)
        Me.txtCuentaContable.TabIndex = 0
        '
        'gbDomicilio
        '
        Me.gbDomicilio.Controls.Add(Me.cboPais)
        Me.gbDomicilio.Controls.Add(Me.cboMunicipio)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayCalle)
        Me.gbDomicilio.Controls.Add(Me.txtCalle)
        Me.gbDomicilio.Controls.Add(Me.txtNumeroExterior)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayNumExterior)
        Me.gbDomicilio.Controls.Add(Me.txtNumeroInterior)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayNumInterior)
        Me.gbDomicilio.Controls.Add(Me.txtColonia)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayCP)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayColonia)
        Me.gbDomicilio.Controls.Add(Me.txtCodigoPostal)
        Me.gbDomicilio.Controls.Add(Me.txtCiudad)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayPais)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayCiudad)
        Me.gbDomicilio.Controls.Add(Me.txtPais)
        Me.gbDomicilio.Controls.Add(Me.txtLocalidad)
        Me.gbDomicilio.Controls.Add(Me.cboEstado)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayLocalidad)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayEstado)
        Me.gbDomicilio.Location = New System.Drawing.Point(12, 380)
        Me.gbDomicilio.Name = "gbDomicilio"
        Me.gbDomicilio.Size = New System.Drawing.Size(395, 234)
        Me.gbDomicilio.TabIndex = 1
        Me.gbDomicilio.TabStop = False
        Me.gbDomicilio.Text = "Domicilio :"
        '
        'cboPais
        '
        Me.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPais.FormattingEnabled = True
        Me.cboPais.Items.AddRange(New Object() {"A", "B"})
        Me.cboPais.Location = New System.Drawing.Point(78, 18)
        Me.cboPais.MaxLength = 80
        Me.cboPais.Name = "cboPais"
        Me.cboPais.Size = New System.Drawing.Size(147, 21)
        Me.cboPais.TabIndex = 0
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.FormattingEnabled = True
        Me.cboMunicipio.Items.AddRange(New Object() {"A", "B"})
        Me.cboMunicipio.Location = New System.Drawing.Point(77, 71)
        Me.cboMunicipio.MaxLength = 80
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(175, 21)
        Me.cboMunicipio.TabIndex = 2
        '
        'txtCiudad
        '
        Me.txtCiudad.Location = New System.Drawing.Point(258, 71)
        Me.txtCiudad.MaxLength = 50
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.ReadOnly = True
        Me.txtCiudad.Size = New System.Drawing.Size(132, 20)
        Me.txtCiudad.TabIndex = 3
        '
        'lblDisplayCiudad
        '
        Me.lblDisplayCiudad.AutoSize = True
        Me.lblDisplayCiudad.Location = New System.Drawing.Point(7, 75)
        Me.lblDisplayCiudad.Name = "lblDisplayCiudad"
        Me.lblDisplayCiudad.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplayCiudad.TabIndex = 101
        Me.lblDisplayCiudad.Text = "Ciudad :"
        '
        'gbCxc
        '
        Me.gbCxc.Controls.Add(Me.lblDisplayLimiteCredito)
        Me.gbCxc.Controls.Add(Me.txtLimiteCredito)
        Me.gbCxc.Controls.Add(Me.lblDisplayDiasPlazo)
        Me.gbCxc.Controls.Add(Me.txtDiasPlazo)
        Me.gbCxc.Location = New System.Drawing.Point(414, 254)
        Me.gbCxc.Name = "gbCxc"
        Me.gbCxc.Size = New System.Drawing.Size(323, 65)
        Me.gbCxc.TabIndex = 4
        Me.gbCxc.TabStop = False
        Me.gbCxc.Text = "Cuentas por cobrar"
        '
        'lblDisplayLimiteCredito
        '
        Me.lblDisplayLimiteCredito.AutoSize = True
        Me.lblDisplayLimiteCredito.Location = New System.Drawing.Point(6, 44)
        Me.lblDisplayLimiteCredito.Name = "lblDisplayLimiteCredito"
        Me.lblDisplayLimiteCredito.Size = New System.Drawing.Size(92, 13)
        Me.lblDisplayLimiteCredito.TabIndex = 74
        Me.lblDisplayLimiteCredito.Text = "Límite de crédito :"
        '
        'txtLimiteCredito
        '
        Me.txtLimiteCredito.Location = New System.Drawing.Point(115, 41)
        Me.txtLimiteCredito.MaxLength = 10
        Me.txtLimiteCredito.Name = "txtLimiteCredito"
        Me.txtLimiteCredito.Size = New System.Drawing.Size(81, 20)
        Me.txtLimiteCredito.TabIndex = 1
        Me.txtLimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayDiasPlazo
        '
        Me.lblDisplayDiasPlazo.AutoSize = True
        Me.lblDisplayDiasPlazo.Location = New System.Drawing.Point(6, 18)
        Me.lblDisplayDiasPlazo.Name = "lblDisplayDiasPlazo"
        Me.lblDisplayDiasPlazo.Size = New System.Drawing.Size(79, 13)
        Me.lblDisplayDiasPlazo.TabIndex = 8
        Me.lblDisplayDiasPlazo.Text = "Días de plazo :"
        '
        'txtDiasPlazo
        '
        Me.txtDiasPlazo.Location = New System.Drawing.Point(115, 15)
        Me.txtDiasPlazo.MaxLength = 3
        Me.txtDiasPlazo.Name = "txtDiasPlazo"
        Me.txtDiasPlazo.Size = New System.Drawing.Size(81, 20)
        Me.txtDiasPlazo.TabIndex = 0
        Me.txtDiasPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 619)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1138, 22)
        Me.StatusStripEstado.TabIndex = 15
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
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'gbFechaAlta
        '
        Me.gbFechaAlta.Controls.Add(Me.DpFecha)
        Me.gbFechaAlta.Controls.Add(Me.lblDisplayFechaAlta)
        Me.gbFechaAlta.Location = New System.Drawing.Point(414, 326)
        Me.gbFechaAlta.Name = "gbFechaAlta"
        Me.gbFechaAlta.Size = New System.Drawing.Size(323, 43)
        Me.gbFechaAlta.TabIndex = 5
        Me.gbFechaAlta.TabStop = False
        Me.gbFechaAlta.Text = "Fecha"
        '
        'DpFecha
        '
        Me.DpFecha.Enabled = False
        Me.DpFecha.Location = New System.Drawing.Point(115, 12)
        Me.DpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DpFecha.Name = "DpFecha"
        Me.DpFecha.Size = New System.Drawing.Size(201, 20)
        Me.DpFecha.TabIndex = 0
        '
        'lblDisplayFechaAlta
        '
        Me.lblDisplayFechaAlta.AutoSize = True
        Me.lblDisplayFechaAlta.Location = New System.Drawing.Point(6, 18)
        Me.lblDisplayFechaAlta.Name = "lblDisplayFechaAlta"
        Me.lblDisplayFechaAlta.Size = New System.Drawing.Size(47, 13)
        Me.lblDisplayFechaAlta.TabIndex = 8
        Me.lblDisplayFechaAlta.Text = "De alta :"
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Controls.Add(Me.CboEstatusFiltro)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Label2)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rbtCodigoCliente)
        Me.gBoxBusquedaRapida.Controls.Add(Me.rbtNombreCliente)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(743, 28)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(384, 590)
        Me.gBoxBusquedaRapida.TabIndex = 7
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'CboEstatusFiltro
        '
        Me.CboEstatusFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatusFiltro.FormattingEnabled = True
        Me.CboEstatusFiltro.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatusFiltro.Location = New System.Drawing.Point(340, 37)
        Me.CboEstatusFiltro.MaxLength = 1
        Me.CboEstatusFiltro.Name = "CboEstatusFiltro"
        Me.CboEstatusFiltro.Size = New System.Drawing.Size(38, 21)
        Me.CboEstatusFiltro.TabIndex = 126
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Estatus :"
        '
        'rbtCodigoCliente
        '
        Me.rbtCodigoCliente.AutoSize = True
        Me.rbtCodigoCliente.Location = New System.Drawing.Point(100, 15)
        Me.rbtCodigoCliente.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtCodigoCliente.Name = "rbtCodigoCliente"
        Me.rbtCodigoCliente.Size = New System.Drawing.Size(92, 17)
        Me.rbtCodigoCliente.TabIndex = 116
        Me.rbtCodigoCliente.Text = "Código cliente"
        Me.rbtCodigoCliente.UseVisualStyleBackColor = True
        '
        'rbtNombreCliente
        '
        Me.rbtNombreCliente.AutoSize = True
        Me.rbtNombreCliente.Checked = True
        Me.rbtNombreCliente.Location = New System.Drawing.Point(6, 15)
        Me.rbtNombreCliente.Margin = New System.Windows.Forms.Padding(2)
        Me.rbtNombreCliente.Name = "rbtNombreCliente"
        Me.rbtNombreCliente.Size = New System.Drawing.Size(62, 17)
        Me.rbtNombreCliente.TabIndex = 115
        Me.rbtNombreCliente.TabStop = True
        Me.rbtNombreCliente.Text = "Nombre"
        Me.rbtNombreCliente.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(6, 63)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(370, 518)
        Me.Grid.TabIndex = 114
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(6, 38)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(276, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'gbCorreo
        '
        Me.gbCorreo.Controls.Add(Me.cboNombreXML)
        Me.gbCorreo.Controls.Add(Me.Label1)
        Me.gbCorreo.Controls.Add(Me.lblDisplayCorreoCliente)
        Me.gbCorreo.Controls.Add(Me.txtCorreoCliente)
        Me.gbCorreo.Location = New System.Drawing.Point(414, 375)
        Me.gbCorreo.Name = "gbCorreo"
        Me.gbCorreo.Size = New System.Drawing.Size(323, 121)
        Me.gbCorreo.TabIndex = 6
        Me.gbCorreo.TabStop = False
        Me.gbCorreo.Text = "Correo :"
        '
        'cboNombreXML
        '
        Me.cboNombreXML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNombreXML.FormattingEnabled = True
        Me.cboNombreXML.Items.AddRange(New Object() {"RFCemisor-Serie-FolioNumerico", "RFCemisor-Fecha-SerieFolio", ""})
        Me.cboNombreXML.Location = New System.Drawing.Point(115, 90)
        Me.cboNombreXML.MaxLength = 1
        Me.cboNombreXML.Name = "cboNombreXML"
        Me.cboNombreXML.Size = New System.Drawing.Size(201, 21)
        Me.cboNombreXML.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Formato XML :"
        '
        'lblDisplayCorreoCliente
        '
        Me.lblDisplayCorreoCliente.AutoSize = True
        Me.lblDisplayCorreoCliente.Location = New System.Drawing.Point(6, 16)
        Me.lblDisplayCorreoCliente.Name = "lblDisplayCorreoCliente"
        Me.lblDisplayCorreoCliente.Size = New System.Drawing.Size(78, 13)
        Me.lblDisplayCorreoCliente.TabIndex = 8
        Me.lblDisplayCorreoCliente.Text = "Correo cliente :"
        '
        'txtCorreoCliente
        '
        Me.txtCorreoCliente.Location = New System.Drawing.Point(115, 13)
        Me.txtCorreoCliente.MaxLength = 500
        Me.txtCorreoCliente.Multiline = True
        Me.txtCorreoCliente.Name = "txtCorreoCliente"
        Me.txtCorreoCliente.Size = New System.Drawing.Size(201, 68)
        Me.txtCorreoCliente.TabIndex = 0
        '
        'gbMetodoPago
        '
        Me.gbMetodoPago.Controls.Add(Me.cboFormaPagoUSD)
        Me.gbMetodoPago.Controls.Add(Me.lblDisplayNCuentaDlls)
        Me.gbMetodoPago.Controls.Add(Me.txtNumeroCuentaDolares)
        Me.gbMetodoPago.Controls.Add(Me.lblDisplayFormaPagoUSD)
        Me.gbMetodoPago.Controls.Add(Me.cboFormaPago)
        Me.gbMetodoPago.Controls.Add(Me.lblDisplayNumCuenta)
        Me.gbMetodoPago.Controls.Add(Me.txtNumeroCuenta)
        Me.gbMetodoPago.Controls.Add(Me.lblDisplayFormaPago)
        Me.gbMetodoPago.Location = New System.Drawing.Point(414, 498)
        Me.gbMetodoPago.Name = "gbMetodoPago"
        Me.gbMetodoPago.Size = New System.Drawing.Size(323, 116)
        Me.gbMetodoPago.TabIndex = 7
        Me.gbMetodoPago.TabStop = False
        Me.gbMetodoPago.Text = "Forma de pago :"
        '
        'cboFormaPagoUSD
        '
        Me.cboFormaPagoUSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPagoUSD.FormattingEnabled = True
        Me.cboFormaPagoUSD.Items.AddRange(New Object() {"A", "B"})
        Me.cboFormaPagoUSD.Location = New System.Drawing.Point(115, 64)
        Me.cboFormaPagoUSD.MaxLength = 1
        Me.cboFormaPagoUSD.Name = "cboFormaPagoUSD"
        Me.cboFormaPagoUSD.Size = New System.Drawing.Size(204, 21)
        Me.cboFormaPagoUSD.TabIndex = 2
        '
        'lblDisplayNCuentaDlls
        '
        Me.lblDisplayNCuentaDlls.AutoSize = True
        Me.lblDisplayNCuentaDlls.Location = New System.Drawing.Point(6, 92)
        Me.lblDisplayNCuentaDlls.Name = "lblDisplayNCuentaDlls"
        Me.lblDisplayNCuentaDlls.Size = New System.Drawing.Size(97, 13)
        Me.lblDisplayNCuentaDlls.TabIndex = 78
        Me.lblDisplayNCuentaDlls.Text = "# de cuenta USD :"
        '
        'txtNumeroCuentaDolares
        '
        Me.txtNumeroCuentaDolares.Location = New System.Drawing.Point(115, 88)
        Me.txtNumeroCuentaDolares.MaxLength = 4
        Me.txtNumeroCuentaDolares.Name = "txtNumeroCuentaDolares"
        Me.txtNumeroCuentaDolares.Size = New System.Drawing.Size(81, 20)
        Me.txtNumeroCuentaDolares.TabIndex = 3
        Me.txtNumeroCuentaDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayFormaPagoUSD
        '
        Me.lblDisplayFormaPagoUSD.AutoSize = True
        Me.lblDisplayFormaPagoUSD.Location = New System.Drawing.Point(6, 68)
        Me.lblDisplayFormaPagoUSD.Name = "lblDisplayFormaPagoUSD"
        Me.lblDisplayFormaPagoUSD.Size = New System.Drawing.Size(110, 13)
        Me.lblDisplayFormaPagoUSD.TabIndex = 77
        Me.lblDisplayFormaPagoUSD.Text = "Forma de pago USD :"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Items.AddRange(New Object() {"A", "B"})
        Me.cboFormaPago.Location = New System.Drawing.Point(115, 17)
        Me.cboFormaPago.MaxLength = 1
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(204, 21)
        Me.cboFormaPago.TabIndex = 0
        '
        'lblDisplayNumCuenta
        '
        Me.lblDisplayNumCuenta.AutoSize = True
        Me.lblDisplayNumCuenta.Location = New System.Drawing.Point(6, 45)
        Me.lblDisplayNumCuenta.Name = "lblDisplayNumCuenta"
        Me.lblDisplayNumCuenta.Size = New System.Drawing.Size(95, 13)
        Me.lblDisplayNumCuenta.TabIndex = 74
        Me.lblDisplayNumCuenta.Text = "# de cuenta MXN:"
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(115, 41)
        Me.txtNumeroCuenta.MaxLength = 4
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(81, 20)
        Me.txtNumeroCuenta.TabIndex = 1
        Me.txtNumeroCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayFormaPago
        '
        Me.lblDisplayFormaPago.AutoSize = True
        Me.lblDisplayFormaPago.Location = New System.Drawing.Point(6, 21)
        Me.lblDisplayFormaPago.Name = "lblDisplayFormaPago"
        Me.lblDisplayFormaPago.Size = New System.Drawing.Size(111, 13)
        Me.lblDisplayFormaPago.TabIndex = 8
        Me.lblDisplayFormaPago.Text = "Forma de pago MXN :"
        '
        'Catalogo_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 641)
        Me.Controls.Add(Me.gbMetodoPago)
        Me.Controls.Add(Me.gbCorreo)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.gbFechaAlta)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbCxc)
        Me.Controls.Add(Me.gbDomicilio)
        Me.Controls.Add(Me.gbCuentasContables)
        Me.Controls.Add(Me.gbDatosVentas)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Catalogo_Clientes"
        Me.ShowIcon = False
        Me.Text = "Catálogo de clientes"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.gbDatosVentas.ResumeLayout(False)
        Me.gbDatosVentas.PerformLayout()
        Me.gbCuentasContables.ResumeLayout(False)
        Me.gbCuentasContables.PerformLayout()
        Me.gbDomicilio.ResumeLayout(False)
        Me.gbDomicilio.PerformLayout()
        Me.gbCxc.ResumeLayout(False)
        Me.gbCxc.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFechaAlta.ResumeLayout(False)
        Me.gbFechaAlta.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCorreo.ResumeLayout(False)
        Me.gbCorreo.PerformLayout()
        Me.gbMetodoPago.ResumeLayout(False)
        Me.gbMetodoPago.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayNombreCultivo As System.Windows.Forms.Label
    Friend WithEvents TxtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumExterior As System.Windows.Forms.Label
    Friend WithEvents txtNumeroExterior As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCalle As System.Windows.Forms.Label
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayLocalidad As System.Windows.Forms.Label
    Friend WithEvents txtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayColonia As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumInterior As System.Windows.Forms.Label
    Friend WithEvents txtNumeroInterior As System.Windows.Forms.TextBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayEstado As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPais As System.Windows.Forms.Label
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCURP As System.Windows.Forms.Label
    Friend WithEvents txtCurp As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayRFC As System.Windows.Forms.Label
    Friend WithEvents txtRfc As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCP As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCelCliente As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCelular As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayTelefonoCliente As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTelefono As System.Windows.Forms.TextBox
    Friend WithEvents gbDatosVentas As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayVendedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents gbCuentasContables As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayCuentaConDolares As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContableDolares As System.Windows.Forms.TextBox
    Friend WithEvents lblCuentaContable As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents gbDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents gbCxc As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayLimiteCredito As System.Windows.Forms.Label
    Friend WithEvents txtLimiteCredito As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayDiasPlazo As System.Windows.Forms.Label
    Friend WithEvents txtDiasPlazo As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTipoPersona As System.Windows.Forms.Label
    Friend WithEvents cboTipoPersona As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboZona As System.Windows.Forms.ComboBox
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents gbFechaAlta As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayFechaAlta As System.Windows.Forms.Label
    Friend WithEvents DpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPermitirVentaCredito As System.Windows.Forms.CheckBox
    Friend WithEvents lblDisplayTipoCliente As System.Windows.Forms.Label
    Friend WithEvents cboTipoMercado As System.Windows.Forms.ComboBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents gbCorreo As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayCorreoCliente As System.Windows.Forms.Label
    Friend WithEvents txtCorreoCliente As System.Windows.Forms.TextBox
    Friend WithEvents gbMetodoPago As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayNumCuenta As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFormaPago As System.Windows.Forms.Label
    Friend WithEvents cboFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents cboFormaPagoUSD As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayNCuentaDlls As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuentaDolares As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFormaPagoUSD As System.Windows.Forms.Label
    Friend WithEvents cboNombreXML As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayNumeroRegistroIdentificadorExtranjero As System.Windows.Forms.Label
    Friend WithEvents txtNumeroRegistroIdentificadorExtranjero As System.Windows.Forms.TextBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents rbtNombreCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCodigoCliente As System.Windows.Forms.RadioButton
    Friend WithEvents CboEstatusFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents LblAlmacenCliente As System.Windows.Forms.Label
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnGeneraCuentaContableDolares As System.Windows.Forms.Button
    Friend WithEvents cboPais As System.Windows.Forms.ComboBox
    Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents txtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCiudad As System.Windows.Forms.Label
    Friend WithEvents chkEsContribuyenteIEPS As System.Windows.Forms.CheckBox
    Friend WithEvents LblDisplayCodigoPropietario As System.Windows.Forms.Label
    Friend WithEvents LblNombrePropietario As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoPropietario As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdRelacion As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayUsoCFDI As Label
    Friend WithEvents cboUsoCFDI As ComboBox
End Class
