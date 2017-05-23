<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cat_Nomina_Trabajadores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cat_Nomina_Trabajadores))
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
        Me.gbDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.lblDisplayIdNominaTemporada = New System.Windows.Forms.Label()
        Me.cboIdTemporada = New System.Windows.Forms.ComboBox()
        Me.cboEstadoNacimiento = New System.Windows.Forms.ComboBox()
        Me.lblDisplayEstadoNacimiento = New System.Windows.Forms.Label()
        Me.dtpFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.lblDisplayApellidoMaterno = New System.Windows.Forms.Label()
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.lblDisplayApellidoPaterno = New System.Windows.Forms.Label()
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.lblDisplaySexo = New System.Windows.Forms.Label()
        Me.cboSexo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayNombre = New System.Windows.Forms.Label()
        Me.TxtNombreTrabajador = New System.Windows.Forms.TextBox()
        Me.lblDisplayCodigo = New System.Windows.Forms.Label()
        Me.txtCodigoTrabajador = New System.Windows.Forms.TextBox()
        Me.LblDisplayEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.gBoxBusquedaRapida = New System.Windows.Forms.GroupBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.lblDisplayEstado = New System.Windows.Forms.Label()
        Me.lblDisplayLocalidad = New System.Windows.Forms.Label()
        Me.cboDomicilioEstado = New System.Windows.Forms.ComboBox()
        Me.txtDomicilioLocalidad = New System.Windows.Forms.TextBox()
        Me.lblDisplayCiudad = New System.Windows.Forms.Label()
        Me.txtDomicilioCiudad = New System.Windows.Forms.TextBox()
        Me.txtDomicilioCodigoPostal = New System.Windows.Forms.TextBox()
        Me.lblDisplayColonia = New System.Windows.Forms.Label()
        Me.lblDisplayCodigoPostal = New System.Windows.Forms.Label()
        Me.txtDomicilioColonia = New System.Windows.Forms.TextBox()
        Me.lblDisplayNumero = New System.Windows.Forms.Label()
        Me.txtDomicilioNumero = New System.Windows.Forms.TextBox()
        Me.txtDomicilioCalle = New System.Windows.Forms.TextBox()
        Me.lblDisplayCalle = New System.Windows.Forms.Label()
        Me.gbDomicilio = New System.Windows.Forms.GroupBox()
        Me.lblDisplayArea = New System.Windows.Forms.Label()
        Me.cboArea = New System.Windows.Forms.ComboBox()
        Me.lblDisplayPuesto = New System.Windows.Forms.Label()
        Me.cboPuesto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayPuntoPago = New System.Windows.Forms.Label()
        Me.cboPuntoPago = New System.Windows.Forms.ComboBox()
        Me.lblDisplayNumeroIMSS = New System.Windows.Forms.Label()
        Me.txtNumIMSS = New System.Windows.Forms.TextBox()
        Me.lblDisplaySueldo = New System.Windows.Forms.Label()
        Me.txtSueldo = New System.Windows.Forms.TextBox()
        Me.gbDatosTrabajador = New System.Windows.Forms.GroupBox()
        Me.lblDisplayNumeroCuentaBanco = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumeroTrabajadorBanco = New System.Windows.Forms.TextBox()
        Me.txtNumeroCuentaBanco = New System.Windows.Forms.TextBox()
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCuentaContable = New System.Windows.Forms.Label()
        Me.txtCuentaContable = New System.Windows.Forms.TextBox()
        Me.lblNombreMayordomo = New System.Windows.Forms.Label()
        Me.lblPagoTarjeta = New System.Windows.Forms.Label()
        Me.LblBanco = New System.Windows.Forms.Label()
        Me.lblDisplayCURP = New System.Windows.Forms.Label()
        Me.txtCurp = New System.Windows.Forms.TextBox()
        Me.lblDisplayRFC = New System.Windows.Forms.Label()
        Me.txtCodigoMayordomo = New System.Windows.Forms.TextBox()
        Me.lblDisplayCodigoMayordomo = New System.Windows.Forms.Label()
        Me.txtRfc = New System.Windows.Forms.TextBox()
        Me.lblDisplayCodigoBanco = New System.Windows.Forms.Label()
        Me.txtCodigoBanco = New System.Windows.Forms.TextBox()
        Me.lblDisplayNumTarjeta = New System.Windows.Forms.Label()
        Me.ckbPagoTarjeta = New System.Windows.Forms.CheckBox()
        Me.txtNumTarjeta = New System.Windows.Forms.TextBox()
        Me.lblDisplayFijoIMSS = New System.Windows.Forms.Label()
        Me.lblDisplayAfiliableIMSS = New System.Windows.Forms.Label()
        Me.txtNombrePadre = New System.Windows.Forms.TextBox()
        Me.lblDisplayNombrePadre = New System.Windows.Forms.Label()
        Me.lblDisplayUMF = New System.Windows.Forms.Label()
        Me.txtNombreMadre = New System.Windows.Forms.TextBox()
        Me.cboUnidadMedicaFamiliar = New System.Windows.Forms.ComboBox()
        Me.lblDisplayNombreMadre = New System.Windows.Forms.Label()
        Me.gbDatosIMSS = New System.Windows.Forms.GroupBox()
        Me.ckbSindicato = New System.Windows.Forms.CheckBox()
        Me.ckbFijoIMSS = New System.Windows.Forms.CheckBox()
        Me.ckbAfiliableIMSS = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbFotoTrabajador = New System.Windows.Forms.PictureBox()
        Me.gbInformacion = New System.Windows.Forms.GroupBox()
        Me.btnAgregaFoto = New System.Windows.Forms.Button()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbDatosGenerales.SuspendLayout()
        Me.gBoxBusquedaRapida.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDomicilio.SuspendLayout()
        Me.gbDatosTrabajador.SuspendLayout()
        Me.gbDatosIMSS.SuspendLayout()
        CType(Me.pbFotoTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1379, 27)
        Me.tsMenu.TabIndex = 1
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
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 791)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1379, 25)
        Me.StatusStripEstado.TabIndex = 16
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
        'gbDatosGenerales
        '
        Me.gbDatosGenerales.Controls.Add(Me.btnSiguiente)
        Me.gbDatosGenerales.Controls.Add(Me.btnAnterior)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayIdNominaTemporada)
        Me.gbDatosGenerales.Controls.Add(Me.cboIdTemporada)
        Me.gbDatosGenerales.Controls.Add(Me.cboEstadoNacimiento)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayEstadoNacimiento)
        Me.gbDatosGenerales.Controls.Add(Me.dtpFechaNacimiento)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayFecha)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayApellidoMaterno)
        Me.gbDatosGenerales.Controls.Add(Me.txtApellidoMaterno)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayApellidoPaterno)
        Me.gbDatosGenerales.Controls.Add(Me.txtApellidoPaterno)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplaySexo)
        Me.gbDatosGenerales.Controls.Add(Me.cboSexo)
        Me.gbDatosGenerales.Controls.Add(Me.Label2)
        Me.gbDatosGenerales.Controls.Add(Me.LblDisplayNombre)
        Me.gbDatosGenerales.Controls.Add(Me.TxtNombreTrabajador)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayCodigo)
        Me.gbDatosGenerales.Controls.Add(Me.txtCodigoTrabajador)
        Me.gbDatosGenerales.Location = New System.Drawing.Point(9, 28)
        Me.gbDatosGenerales.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDatosGenerales.Name = "gbDatosGenerales"
        Me.gbDatosGenerales.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDatosGenerales.Size = New System.Drawing.Size(439, 297)
        Me.gbDatosGenerales.TabIndex = 0
        Me.gbDatosGenerales.TabStop = False
        Me.gbDatosGenerales.Text = "Datos generales"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(355, 21)
        Me.btnSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(68, 26)
        Me.btnSiguiente.TabIndex = 372
        Me.btnSiguiente.Text = ">>"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(283, 21)
        Me.btnAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(68, 26)
        Me.btnAnterior.TabIndex = 371
        Me.btnAnterior.Text = "<<"
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'lblDisplayIdNominaTemporada
        '
        Me.lblDisplayIdNominaTemporada.AutoSize = True
        Me.lblDisplayIdNominaTemporada.Location = New System.Drawing.Point(8, 60)
        Me.lblDisplayIdNominaTemporada.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIdNominaTemporada.Name = "lblDisplayIdNominaTemporada"
        Me.lblDisplayIdNominaTemporada.Size = New System.Drawing.Size(99, 17)
        Me.lblDisplayIdNominaTemporada.TabIndex = 127
        Me.lblDisplayIdNominaTemporada.Text = "Id temporada :"
        '
        'cboIdTemporada
        '
        Me.cboIdTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIdTemporada.FormattingEnabled = True
        Me.cboIdTemporada.Location = New System.Drawing.Point(133, 57)
        Me.cboIdTemporada.Margin = New System.Windows.Forms.Padding(4)
        Me.cboIdTemporada.MaxLength = 1
        Me.cboIdTemporada.Name = "cboIdTemporada"
        Me.cboIdTemporada.Size = New System.Drawing.Size(140, 24)
        Me.cboIdTemporada.TabIndex = 1
        '
        'cboEstadoNacimiento
        '
        Me.cboEstadoNacimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstadoNacimiento.FormattingEnabled = True
        Me.cboEstadoNacimiento.Items.AddRange(New Object() {"A", "B"})
        Me.cboEstadoNacimiento.Location = New System.Drawing.Point(155, 255)
        Me.cboEstadoNacimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEstadoNacimiento.MaxLength = 80
        Me.cboEstadoNacimiento.Name = "cboEstadoNacimiento"
        Me.cboEstadoNacimiento.Size = New System.Drawing.Size(267, 24)
        Me.cboEstadoNacimiento.TabIndex = 7
        '
        'lblDisplayEstadoNacimiento
        '
        Me.lblDisplayEstadoNacimiento.AutoSize = True
        Me.lblDisplayEstadoNacimiento.Location = New System.Drawing.Point(8, 258)
        Me.lblDisplayEstadoNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEstadoNacimiento.Name = "lblDisplayEstadoNacimiento"
        Me.lblDisplayEstadoNacimiento.Size = New System.Drawing.Size(137, 17)
        Me.lblDisplayEstadoNacimiento.TabIndex = 111
        Me.lblDisplayEstadoNacimiento.Text = "Edo. de nacimiento :"
        '
        'dtpFechaNacimiento
        '
        Me.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNacimiento.Location = New System.Drawing.Point(133, 223)
        Me.dtpFechaNacimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        Me.dtpFechaNacimiento.Size = New System.Drawing.Size(191, 22)
        Me.dtpFechaNacimiento.TabIndex = 6
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(8, 226)
        Me.lblDisplayFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(86, 17)
        Me.lblDisplayFecha.TabIndex = 124
        Me.lblDisplayFecha.Text = "Fecha nac. :"
        '
        'lblDisplayApellidoMaterno
        '
        Me.lblDisplayApellidoMaterno.AutoSize = True
        Me.lblDisplayApellidoMaterno.Location = New System.Drawing.Point(8, 158)
        Me.lblDisplayApellidoMaterno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayApellidoMaterno.Name = "lblDisplayApellidoMaterno"
        Me.lblDisplayApellidoMaterno.Size = New System.Drawing.Size(122, 17)
        Me.lblDisplayApellidoMaterno.TabIndex = 123
        Me.lblDisplayApellidoMaterno.Text = "Apellido materno :"
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(133, 154)
        Me.txtApellidoMaterno.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApellidoMaterno.MaxLength = 50
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(287, 22)
        Me.txtApellidoMaterno.TabIndex = 4
        '
        'lblDisplayApellidoPaterno
        '
        Me.lblDisplayApellidoPaterno.AutoSize = True
        Me.lblDisplayApellidoPaterno.Location = New System.Drawing.Point(8, 126)
        Me.lblDisplayApellidoPaterno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayApellidoPaterno.Name = "lblDisplayApellidoPaterno"
        Me.lblDisplayApellidoPaterno.Size = New System.Drawing.Size(119, 17)
        Me.lblDisplayApellidoPaterno.TabIndex = 121
        Me.lblDisplayApellidoPaterno.Text = "Apellido paterno :"
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(133, 122)
        Me.txtApellidoPaterno.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApellidoPaterno.MaxLength = 50
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(287, 22)
        Me.txtApellidoPaterno.TabIndex = 3
        '
        'lblDisplaySexo
        '
        Me.lblDisplaySexo.AutoSize = True
        Me.lblDisplaySexo.Location = New System.Drawing.Point(8, 193)
        Me.lblDisplaySexo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySexo.Name = "lblDisplaySexo"
        Me.lblDisplaySexo.Size = New System.Drawing.Size(47, 17)
        Me.lblDisplaySexo.TabIndex = 119
        Me.lblDisplaySexo.Text = "Sexo :"
        '
        'cboSexo
        '
        Me.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSexo.FormattingEnabled = True
        Me.cboSexo.Location = New System.Drawing.Point(133, 190)
        Me.cboSexo.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSexo.MaxLength = 1
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(140, 24)
        Me.cboSexo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(161, -140)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(241, 16)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'LblDisplayNombre
        '
        Me.LblDisplayNombre.AutoSize = True
        Me.LblDisplayNombre.Location = New System.Drawing.Point(8, 94)
        Me.LblDisplayNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayNombre.Name = "LblDisplayNombre"
        Me.LblDisplayNombre.Size = New System.Drawing.Size(66, 17)
        Me.LblDisplayNombre.TabIndex = 74
        Me.LblDisplayNombre.Text = "Nombre :"
        '
        'TxtNombreTrabajador
        '
        Me.TxtNombreTrabajador.Location = New System.Drawing.Point(133, 90)
        Me.TxtNombreTrabajador.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNombreTrabajador.MaxLength = 50
        Me.TxtNombreTrabajador.Name = "TxtNombreTrabajador"
        Me.TxtNombreTrabajador.Size = New System.Drawing.Size(288, 22)
        Me.TxtNombreTrabajador.TabIndex = 2
        '
        'lblDisplayCodigo
        '
        Me.lblDisplayCodigo.AutoSize = True
        Me.lblDisplayCodigo.Location = New System.Drawing.Point(8, 26)
        Me.lblDisplayCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCodigo.Name = "lblDisplayCodigo"
        Me.lblDisplayCodigo.Size = New System.Drawing.Size(60, 17)
        Me.lblDisplayCodigo.TabIndex = 8
        Me.lblDisplayCodigo.Text = "Código :"
        '
        'txtCodigoTrabajador
        '
        Me.txtCodigoTrabajador.Location = New System.Drawing.Point(133, 22)
        Me.txtCodigoTrabajador.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoTrabajador.MaxLength = 10
        Me.txtCodigoTrabajador.Name = "txtCodigoTrabajador"
        Me.txtCodigoTrabajador.Size = New System.Drawing.Size(140, 22)
        Me.txtCodigoTrabajador.TabIndex = 0
        '
        'LblDisplayEstatus
        '
        Me.LblDisplayEstatus.AutoSize = True
        Me.LblDisplayEstatus.Location = New System.Drawing.Point(251, 150)
        Me.LblDisplayEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayEstatus.Name = "LblDisplayEstatus"
        Me.LblDisplayEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayEstatus.TabIndex = 22
        Me.LblDisplayEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.CboEstatus.Location = New System.Drawing.Point(316, 145)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(104, 24)
        Me.CboEstatus.TabIndex = 5
        '
        'gBoxBusquedaRapida
        '
        Me.gBoxBusquedaRapida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxBusquedaRapida.Controls.Add(Me.Grid)
        Me.gBoxBusquedaRapida.Controls.Add(Me.txtFiltro)
        Me.gBoxBusquedaRapida.Location = New System.Drawing.Point(939, 34)
        Me.gBoxBusquedaRapida.Margin = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Name = "gBoxBusquedaRapida"
        Me.gBoxBusquedaRapida.Padding = New System.Windows.Forms.Padding(4)
        Me.gBoxBusquedaRapida.Size = New System.Drawing.Size(432, 751)
        Me.gBoxBusquedaRapida.TabIndex = 2
        Me.gBoxBusquedaRapida.TabStop = False
        Me.gBoxBusquedaRapida.Text = "Búsqueda rápida"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Location = New System.Drawing.Point(8, 53)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(415, 690)
        Me.Grid.TabIndex = 113
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltro.Location = New System.Drawing.Point(8, 23)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(415, 22)
        Me.txtFiltro.TabIndex = 0
        '
        'lblDisplayEstado
        '
        Me.lblDisplayEstado.AutoSize = True
        Me.lblDisplayEstado.Location = New System.Drawing.Point(8, 209)
        Me.lblDisplayEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEstado.Name = "lblDisplayEstado"
        Me.lblDisplayEstado.Size = New System.Drawing.Size(60, 17)
        Me.lblDisplayEstado.TabIndex = 104
        Me.lblDisplayEstado.Text = "Estado :"
        '
        'lblDisplayLocalidad
        '
        Me.lblDisplayLocalidad.AutoSize = True
        Me.lblDisplayLocalidad.Location = New System.Drawing.Point(8, 177)
        Me.lblDisplayLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayLocalidad.Name = "lblDisplayLocalidad"
        Me.lblDisplayLocalidad.Size = New System.Drawing.Size(77, 17)
        Me.lblDisplayLocalidad.TabIndex = 103
        Me.lblDisplayLocalidad.Text = "Localidad :"
        '
        'cboDomicilioEstado
        '
        Me.cboDomicilioEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDomicilioEstado.FormattingEnabled = True
        Me.cboDomicilioEstado.Items.AddRange(New Object() {"A", "B"})
        Me.cboDomicilioEstado.Location = New System.Drawing.Point(167, 206)
        Me.cboDomicilioEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDomicilioEstado.MaxLength = 80
        Me.cboDomicilioEstado.Name = "cboDomicilioEstado"
        Me.cboDomicilioEstado.Size = New System.Drawing.Size(267, 24)
        Me.cboDomicilioEstado.TabIndex = 6
        '
        'txtDomicilioLocalidad
        '
        Me.txtDomicilioLocalidad.Location = New System.Drawing.Point(168, 174)
        Me.txtDomicilioLocalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilioLocalidad.MaxLength = 50
        Me.txtDomicilioLocalidad.Name = "txtDomicilioLocalidad"
        Me.txtDomicilioLocalidad.Size = New System.Drawing.Size(267, 22)
        Me.txtDomicilioLocalidad.TabIndex = 5
        '
        'lblDisplayCiudad
        '
        Me.lblDisplayCiudad.AutoSize = True
        Me.lblDisplayCiudad.Location = New System.Drawing.Point(8, 145)
        Me.lblDisplayCiudad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCiudad.Name = "lblDisplayCiudad"
        Me.lblDisplayCiudad.Size = New System.Drawing.Size(60, 17)
        Me.lblDisplayCiudad.TabIndex = 101
        Me.lblDisplayCiudad.Text = "Ciudad :"
        '
        'txtDomicilioCiudad
        '
        Me.txtDomicilioCiudad.Location = New System.Drawing.Point(168, 142)
        Me.txtDomicilioCiudad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilioCiudad.MaxLength = 50
        Me.txtDomicilioCiudad.Name = "txtDomicilioCiudad"
        Me.txtDomicilioCiudad.Size = New System.Drawing.Size(267, 22)
        Me.txtDomicilioCiudad.TabIndex = 4
        '
        'txtDomicilioCodigoPostal
        '
        Me.txtDomicilioCodigoPostal.Location = New System.Drawing.Point(167, 80)
        Me.txtDomicilioCodigoPostal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilioCodigoPostal.MaxLength = 10
        Me.txtDomicilioCodigoPostal.Name = "txtDomicilioCodigoPostal"
        Me.txtDomicilioCodigoPostal.Size = New System.Drawing.Size(135, 22)
        Me.txtDomicilioCodigoPostal.TabIndex = 2
        Me.txtDomicilioCodigoPostal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayColonia
        '
        Me.lblDisplayColonia.AutoSize = True
        Me.lblDisplayColonia.Location = New System.Drawing.Point(8, 113)
        Me.lblDisplayColonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayColonia.Name = "lblDisplayColonia"
        Me.lblDisplayColonia.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayColonia.TabIndex = 99
        Me.lblDisplayColonia.Text = "Colonia :"
        '
        'lblDisplayCodigoPostal
        '
        Me.lblDisplayCodigoPostal.AutoSize = True
        Me.lblDisplayCodigoPostal.Location = New System.Drawing.Point(8, 84)
        Me.lblDisplayCodigoPostal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCodigoPostal.Name = "lblDisplayCodigoPostal"
        Me.lblDisplayCodigoPostal.Size = New System.Drawing.Size(83, 17)
        Me.lblDisplayCodigoPostal.TabIndex = 109
        Me.lblDisplayCodigoPostal.Text = "Cód postal :"
        '
        'txtDomicilioColonia
        '
        Me.txtDomicilioColonia.Location = New System.Drawing.Point(168, 110)
        Me.txtDomicilioColonia.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilioColonia.MaxLength = 50
        Me.txtDomicilioColonia.Name = "txtDomicilioColonia"
        Me.txtDomicilioColonia.Size = New System.Drawing.Size(267, 22)
        Me.txtDomicilioColonia.TabIndex = 3
        '
        'lblDisplayNumero
        '
        Me.lblDisplayNumero.AutoSize = True
        Me.lblDisplayNumero.Location = New System.Drawing.Point(8, 52)
        Me.lblDisplayNumero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayNumero.Name = "lblDisplayNumero"
        Me.lblDisplayNumero.Size = New System.Drawing.Size(66, 17)
        Me.lblDisplayNumero.TabIndex = 95
        Me.lblDisplayNumero.Text = "Número :"
        '
        'txtDomicilioNumero
        '
        Me.txtDomicilioNumero.Location = New System.Drawing.Point(168, 48)
        Me.txtDomicilioNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilioNumero.MaxLength = 50
        Me.txtDomicilioNumero.Name = "txtDomicilioNumero"
        Me.txtDomicilioNumero.Size = New System.Drawing.Size(135, 22)
        Me.txtDomicilioNumero.TabIndex = 1
        Me.txtDomicilioNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDomicilioCalle
        '
        Me.txtDomicilioCalle.Location = New System.Drawing.Point(168, 16)
        Me.txtDomicilioCalle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDomicilioCalle.MaxLength = 50
        Me.txtDomicilioCalle.Name = "txtDomicilioCalle"
        Me.txtDomicilioCalle.Size = New System.Drawing.Size(267, 22)
        Me.txtDomicilioCalle.TabIndex = 0
        '
        'lblDisplayCalle
        '
        Me.lblDisplayCalle.AutoSize = True
        Me.lblDisplayCalle.Location = New System.Drawing.Point(8, 20)
        Me.lblDisplayCalle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCalle.Name = "lblDisplayCalle"
        Me.lblDisplayCalle.Size = New System.Drawing.Size(47, 17)
        Me.lblDisplayCalle.TabIndex = 93
        Me.lblDisplayCalle.Text = "Calle :"
        '
        'gbDomicilio
        '
        Me.gbDomicilio.Controls.Add(Me.lblDisplayCalle)
        Me.gbDomicilio.Controls.Add(Me.txtDomicilioCalle)
        Me.gbDomicilio.Controls.Add(Me.txtDomicilioNumero)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayNumero)
        Me.gbDomicilio.Controls.Add(Me.txtDomicilioColonia)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayCodigoPostal)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayColonia)
        Me.gbDomicilio.Controls.Add(Me.txtDomicilioCodigoPostal)
        Me.gbDomicilio.Controls.Add(Me.txtDomicilioCiudad)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayCiudad)
        Me.gbDomicilio.Controls.Add(Me.txtDomicilioLocalidad)
        Me.gbDomicilio.Controls.Add(Me.cboDomicilioEstado)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayLocalidad)
        Me.gbDomicilio.Controls.Add(Me.lblDisplayEstado)
        Me.gbDomicilio.Location = New System.Drawing.Point(456, 225)
        Me.gbDomicilio.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDomicilio.Name = "gbDomicilio"
        Me.gbDomicilio.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDomicilio.Size = New System.Drawing.Size(449, 246)
        Me.gbDomicilio.TabIndex = 2
        Me.gbDomicilio.TabStop = False
        Me.gbDomicilio.Text = "Domicilio :"
        '
        'lblDisplayArea
        '
        Me.lblDisplayArea.AutoSize = True
        Me.lblDisplayArea.Location = New System.Drawing.Point(8, 23)
        Me.lblDisplayArea.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayArea.Name = "lblDisplayArea"
        Me.lblDisplayArea.Size = New System.Drawing.Size(46, 17)
        Me.lblDisplayArea.TabIndex = 127
        Me.lblDisplayArea.Text = "Área :"
        '
        'cboArea
        '
        Me.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArea.FormattingEnabled = True
        Me.cboArea.Location = New System.Drawing.Point(137, 18)
        Me.cboArea.Margin = New System.Windows.Forms.Padding(4)
        Me.cboArea.MaxLength = 1
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(284, 24)
        Me.cboArea.TabIndex = 0
        '
        'lblDisplayPuesto
        '
        Me.lblDisplayPuesto.AutoSize = True
        Me.lblDisplayPuesto.Location = New System.Drawing.Point(8, 55)
        Me.lblDisplayPuesto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPuesto.Name = "lblDisplayPuesto"
        Me.lblDisplayPuesto.Size = New System.Drawing.Size(60, 17)
        Me.lblDisplayPuesto.TabIndex = 129
        Me.lblDisplayPuesto.Text = "Puesto :"
        '
        'cboPuesto
        '
        Me.cboPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuesto.FormattingEnabled = True
        Me.cboPuesto.Location = New System.Drawing.Point(137, 50)
        Me.cboPuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPuesto.MaxLength = 1
        Me.cboPuesto.Name = "cboPuesto"
        Me.cboPuesto.Size = New System.Drawing.Size(284, 24)
        Me.cboPuesto.TabIndex = 1
        '
        'lblDisplayPuntoPago
        '
        Me.lblDisplayPuntoPago.AutoSize = True
        Me.lblDisplayPuntoPago.Location = New System.Drawing.Point(8, 87)
        Me.lblDisplayPuntoPago.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayPuntoPago.Name = "lblDisplayPuntoPago"
        Me.lblDisplayPuntoPago.Size = New System.Drawing.Size(109, 17)
        Me.lblDisplayPuntoPago.TabIndex = 131
        Me.lblDisplayPuntoPago.Text = "Punto de pago :"
        '
        'cboPuntoPago
        '
        Me.cboPuntoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuntoPago.FormattingEnabled = True
        Me.cboPuntoPago.Location = New System.Drawing.Point(137, 82)
        Me.cboPuntoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPuntoPago.MaxLength = 1
        Me.cboPuntoPago.Name = "cboPuntoPago"
        Me.cboPuntoPago.Size = New System.Drawing.Size(284, 24)
        Me.cboPuntoPago.TabIndex = 2
        '
        'lblDisplayNumeroIMSS
        '
        Me.lblDisplayNumeroIMSS.AutoSize = True
        Me.lblDisplayNumeroIMSS.Location = New System.Drawing.Point(9, 124)
        Me.lblDisplayNumeroIMSS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayNumeroIMSS.Name = "lblDisplayNumeroIMSS"
        Me.lblDisplayNumeroIMSS.Size = New System.Drawing.Size(117, 17)
        Me.lblDisplayNumeroIMSS.TabIndex = 133
        Me.lblDisplayNumeroIMSS.Text = "# Registro IMSS :"
        '
        'txtNumIMSS
        '
        Me.txtNumIMSS.Location = New System.Drawing.Point(165, 119)
        Me.txtNumIMSS.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumIMSS.MaxLength = 11
        Me.txtNumIMSS.Name = "txtNumIMSS"
        Me.txtNumIMSS.Size = New System.Drawing.Size(267, 22)
        Me.txtNumIMSS.TabIndex = 3
        '
        'lblDisplaySueldo
        '
        Me.lblDisplaySueldo.AutoSize = True
        Me.lblDisplaySueldo.Location = New System.Drawing.Point(8, 150)
        Me.lblDisplaySueldo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySueldo.Name = "lblDisplaySueldo"
        Me.lblDisplaySueldo.Size = New System.Drawing.Size(99, 17)
        Me.lblDisplaySueldo.TabIndex = 135
        Me.lblDisplaySueldo.Text = "Sueldo diario :"
        '
        'txtSueldo
        '
        Me.txtSueldo.Location = New System.Drawing.Point(137, 145)
        Me.txtSueldo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSueldo.MaxLength = 20
        Me.txtSueldo.Name = "txtSueldo"
        Me.txtSueldo.Size = New System.Drawing.Size(104, 22)
        Me.txtSueldo.TabIndex = 4
        Me.txtSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbDatosTrabajador
        '
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayNumeroCuentaBanco)
        Me.gbDatosTrabajador.Controls.Add(Me.Label4)
        Me.gbDatosTrabajador.Controls.Add(Me.txtNumeroTrabajadorBanco)
        Me.gbDatosTrabajador.Controls.Add(Me.txtNumeroCuentaBanco)
        Me.gbDatosTrabajador.Controls.Add(Me.dtpFechaIngreso)
        Me.gbDatosTrabajador.Controls.Add(Me.Label3)
        Me.gbDatosTrabajador.Controls.Add(Me.lblCuentaContable)
        Me.gbDatosTrabajador.Controls.Add(Me.txtCuentaContable)
        Me.gbDatosTrabajador.Controls.Add(Me.lblNombreMayordomo)
        Me.gbDatosTrabajador.Controls.Add(Me.lblPagoTarjeta)
        Me.gbDatosTrabajador.Controls.Add(Me.LblBanco)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayCURP)
        Me.gbDatosTrabajador.Controls.Add(Me.txtCurp)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayRFC)
        Me.gbDatosTrabajador.Controls.Add(Me.txtCodigoMayordomo)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayCodigoMayordomo)
        Me.gbDatosTrabajador.Controls.Add(Me.txtRfc)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayCodigoBanco)
        Me.gbDatosTrabajador.Controls.Add(Me.txtCodigoBanco)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayNumTarjeta)
        Me.gbDatosTrabajador.Controls.Add(Me.ckbPagoTarjeta)
        Me.gbDatosTrabajador.Controls.Add(Me.txtNumTarjeta)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplaySueldo)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayArea)
        Me.gbDatosTrabajador.Controls.Add(Me.LblDisplayEstatus)
        Me.gbDatosTrabajador.Controls.Add(Me.txtSueldo)
        Me.gbDatosTrabajador.Controls.Add(Me.CboEstatus)
        Me.gbDatosTrabajador.Controls.Add(Me.cboArea)
        Me.gbDatosTrabajador.Controls.Add(Me.cboPuesto)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayPuesto)
        Me.gbDatosTrabajador.Controls.Add(Me.lblDisplayPuntoPago)
        Me.gbDatosTrabajador.Controls.Add(Me.cboPuntoPago)
        Me.gbDatosTrabajador.Location = New System.Drawing.Point(9, 332)
        Me.gbDatosTrabajador.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDatosTrabajador.Name = "gbDatosTrabajador"
        Me.gbDatosTrabajador.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDatosTrabajador.Size = New System.Drawing.Size(439, 411)
        Me.gbDatosTrabajador.TabIndex = 1
        Me.gbDatosTrabajador.TabStop = False
        Me.gbDatosTrabajador.Text = "Datos del  trabajador"
        '
        'lblDisplayNumeroCuentaBanco
        '
        Me.lblDisplayNumeroCuentaBanco.AutoSize = True
        Me.lblDisplayNumeroCuentaBanco.Location = New System.Drawing.Point(164, 298)
        Me.lblDisplayNumeroCuentaBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayNumeroCuentaBanco.Name = "lblDisplayNumeroCuentaBanco"
        Me.lblDisplayNumeroCuentaBanco.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplayNumeroCuentaBanco.TabIndex = 263
        Me.lblDisplayNumeroCuentaBanco.Text = "# Cuenta :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 352)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(218, 17)
        Me.Label4.TabIndex = 261
        Me.Label4.Text = "Número de trabajador en banco :"
        '
        'txtNumeroTrabajadorBanco
        '
        Me.txtNumeroTrabajadorBanco.Location = New System.Drawing.Point(232, 347)
        Me.txtNumeroTrabajadorBanco.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumeroTrabajadorBanco.MaxLength = 10
        Me.txtNumeroTrabajadorBanco.Name = "txtNumeroTrabajadorBanco"
        Me.txtNumeroTrabajadorBanco.Size = New System.Drawing.Size(96, 22)
        Me.txtNumeroTrabajadorBanco.TabIndex = 13
        '
        'txtNumeroCuentaBanco
        '
        Me.txtNumeroCuentaBanco.Location = New System.Drawing.Point(255, 293)
        Me.txtNumeroCuentaBanco.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumeroCuentaBanco.MaxLength = 18
        Me.txtNumeroCuentaBanco.Name = "txtNumeroCuentaBanco"
        Me.txtNumeroCuentaBanco.Size = New System.Drawing.Size(165, 22)
        Me.txtNumeroCuentaBanco.TabIndex = 11
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(137, 379)
        Me.dtpFechaIngreso.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(191, 22)
        Me.dtpFechaIngreso.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 379)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 17)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Fecha ingreso :"
        '
        'lblCuentaContable
        '
        Me.lblCuentaContable.AutoSize = True
        Me.lblCuentaContable.Location = New System.Drawing.Point(8, 241)
        Me.lblCuentaContable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuentaContable.Name = "lblCuentaContable"
        Me.lblCuentaContable.Size = New System.Drawing.Size(119, 17)
        Me.lblCuentaContable.TabIndex = 259
        Me.lblCuentaContable.Text = "Cuenta contable :"
        '
        'txtCuentaContable
        '
        Me.txtCuentaContable.Enabled = False
        Me.txtCuentaContable.Location = New System.Drawing.Point(137, 236)
        Me.txtCuentaContable.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCuentaContable.MaxLength = 20
        Me.txtCuentaContable.Name = "txtCuentaContable"
        Me.txtCuentaContable.Size = New System.Drawing.Size(283, 22)
        Me.txtCuentaContable.TabIndex = 8
        '
        'lblNombreMayordomo
        '
        Me.lblNombreMayordomo.Location = New System.Drawing.Point(251, 117)
        Me.lblNombreMayordomo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreMayordomo.Name = "lblNombreMayordomo"
        Me.lblNombreMayordomo.Size = New System.Drawing.Size(172, 16)
        Me.lblNombreMayordomo.TabIndex = 257
        Me.lblNombreMayordomo.Text = "."
        '
        'lblPagoTarjeta
        '
        Me.lblPagoTarjeta.AutoSize = True
        Me.lblPagoTarjeta.Location = New System.Drawing.Point(8, 271)
        Me.lblPagoTarjeta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPagoTarjeta.Name = "lblPagoTarjeta"
        Me.lblPagoTarjeta.Size = New System.Drawing.Size(120, 17)
        Me.lblPagoTarjeta.TabIndex = 256
        Me.lblPagoTarjeta.Text = "Pago con tarjeta :"
        '
        'LblBanco
        '
        Me.LblBanco.Location = New System.Drawing.Point(200, 321)
        Me.LblBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(208, 16)
        Me.LblBanco.TabIndex = 255
        Me.LblBanco.Text = "."
        '
        'lblDisplayCURP
        '
        Me.lblDisplayCURP.AutoSize = True
        Me.lblDisplayCURP.Location = New System.Drawing.Point(8, 212)
        Me.lblDisplayCURP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCURP.Name = "lblDisplayCURP"
        Me.lblDisplayCURP.Size = New System.Drawing.Size(54, 17)
        Me.lblDisplayCURP.TabIndex = 145
        Me.lblDisplayCURP.Text = "CURP :"
        '
        'txtCurp
        '
        Me.txtCurp.Location = New System.Drawing.Point(137, 207)
        Me.txtCurp.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurp.MaxLength = 20
        Me.txtCurp.Name = "txtCurp"
        Me.txtCurp.Size = New System.Drawing.Size(283, 22)
        Me.txtCurp.TabIndex = 7
        '
        'lblDisplayRFC
        '
        Me.lblDisplayRFC.AutoSize = True
        Me.lblDisplayRFC.Location = New System.Drawing.Point(8, 181)
        Me.lblDisplayRFC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayRFC.Name = "lblDisplayRFC"
        Me.lblDisplayRFC.Size = New System.Drawing.Size(43, 17)
        Me.lblDisplayRFC.TabIndex = 144
        Me.lblDisplayRFC.Text = "RFC :"
        '
        'txtCodigoMayordomo
        '
        Me.txtCodigoMayordomo.Location = New System.Drawing.Point(137, 113)
        Me.txtCodigoMayordomo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoMayordomo.MaxLength = 10
        Me.txtCodigoMayordomo.Name = "txtCodigoMayordomo"
        Me.txtCodigoMayordomo.Size = New System.Drawing.Size(104, 22)
        Me.txtCodigoMayordomo.TabIndex = 3
        '
        'lblDisplayCodigoMayordomo
        '
        Me.lblDisplayCodigoMayordomo.AutoSize = True
        Me.lblDisplayCodigoMayordomo.Location = New System.Drawing.Point(8, 117)
        Me.lblDisplayCodigoMayordomo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCodigoMayordomo.Name = "lblDisplayCodigoMayordomo"
        Me.lblDisplayCodigoMayordomo.Size = New System.Drawing.Size(123, 17)
        Me.lblDisplayCodigoMayordomo.TabIndex = 145
        Me.lblDisplayCodigoMayordomo.Text = "Cód. mayordomo :"
        '
        'txtRfc
        '
        Me.txtRfc.Location = New System.Drawing.Point(137, 176)
        Me.txtRfc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRfc.MaxLength = 20
        Me.txtRfc.Name = "txtRfc"
        Me.txtRfc.Size = New System.Drawing.Size(283, 22)
        Me.txtRfc.TabIndex = 6
        '
        'lblDisplayCodigoBanco
        '
        Me.lblDisplayCodigoBanco.AutoSize = True
        Me.lblDisplayCodigoBanco.Location = New System.Drawing.Point(8, 321)
        Me.lblDisplayCodigoBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCodigoBanco.Name = "lblDisplayCodigoBanco"
        Me.lblDisplayCodigoBanco.Size = New System.Drawing.Size(56, 17)
        Me.lblDisplayCodigoBanco.TabIndex = 141
        Me.lblDisplayCodigoBanco.Text = "Banco :"
        '
        'txtCodigoBanco
        '
        Me.txtCodigoBanco.Location = New System.Drawing.Point(137, 316)
        Me.txtCodigoBanco.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodigoBanco.MaxLength = 3
        Me.txtCodigoBanco.Name = "txtCodigoBanco"
        Me.txtCodigoBanco.Size = New System.Drawing.Size(53, 22)
        Me.txtCodigoBanco.TabIndex = 12
        '
        'lblDisplayNumTarjeta
        '
        Me.lblDisplayNumTarjeta.AutoSize = True
        Me.lblDisplayNumTarjeta.Location = New System.Drawing.Point(165, 271)
        Me.lblDisplayNumTarjeta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayNumTarjeta.Name = "lblDisplayNumTarjeta"
        Me.lblDisplayNumTarjeta.Size = New System.Drawing.Size(73, 17)
        Me.lblDisplayNumTarjeta.TabIndex = 139
        Me.lblDisplayNumTarjeta.Text = "# Tarjeta :"
        '
        'ckbPagoTarjeta
        '
        Me.ckbPagoTarjeta.AutoSize = True
        Me.ckbPagoTarjeta.Location = New System.Drawing.Point(137, 270)
        Me.ckbPagoTarjeta.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbPagoTarjeta.Name = "ckbPagoTarjeta"
        Me.ckbPagoTarjeta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ckbPagoTarjeta.Size = New System.Drawing.Size(18, 17)
        Me.ckbPagoTarjeta.TabIndex = 9
        Me.ckbPagoTarjeta.UseVisualStyleBackColor = True
        '
        'txtNumTarjeta
        '
        Me.txtNumTarjeta.Location = New System.Drawing.Point(256, 266)
        Me.txtNumTarjeta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumTarjeta.MaxLength = 16
        Me.txtNumTarjeta.Name = "txtNumTarjeta"
        Me.txtNumTarjeta.Size = New System.Drawing.Size(165, 22)
        Me.txtNumTarjeta.TabIndex = 10
        '
        'lblDisplayFijoIMSS
        '
        Me.lblDisplayFijoIMSS.AutoSize = True
        Me.lblDisplayFijoIMSS.Location = New System.Drawing.Point(9, 183)
        Me.lblDisplayFijoIMSS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFijoIMSS.Name = "lblDisplayFijoIMSS"
        Me.lblDisplayFijoIMSS.Size = New System.Drawing.Size(158, 17)
        Me.lblDisplayFijoIMSS.TabIndex = 149
        Me.lblDisplayFijoIMSS.Text = "Fijo IMSS/Incapacitado :"
        '
        'lblDisplayAfiliableIMSS
        '
        Me.lblDisplayAfiliableIMSS.AutoSize = True
        Me.lblDisplayAfiliableIMSS.Location = New System.Drawing.Point(9, 156)
        Me.lblDisplayAfiliableIMSS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayAfiliableIMSS.Name = "lblDisplayAfiliableIMSS"
        Me.lblDisplayAfiliableIMSS.Size = New System.Drawing.Size(116, 17)
        Me.lblDisplayAfiliableIMSS.TabIndex = 147
        Me.lblDisplayAfiliableIMSS.Text = "Afiliable al IMSS :"
        '
        'txtNombrePadre
        '
        Me.txtNombrePadre.Location = New System.Drawing.Point(165, 55)
        Me.txtNombrePadre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombrePadre.MaxLength = 50
        Me.txtNombrePadre.Name = "txtNombrePadre"
        Me.txtNombrePadre.Size = New System.Drawing.Size(267, 22)
        Me.txtNombrePadre.TabIndex = 1
        '
        'lblDisplayNombrePadre
        '
        Me.lblDisplayNombrePadre.AutoSize = True
        Me.lblDisplayNombrePadre.Location = New System.Drawing.Point(9, 60)
        Me.lblDisplayNombrePadre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayNombrePadre.Name = "lblDisplayNombrePadre"
        Me.lblDisplayNombrePadre.Size = New System.Drawing.Size(130, 17)
        Me.lblDisplayNombrePadre.TabIndex = 112
        Me.lblDisplayNombrePadre.Text = "Nombre del padre :"
        '
        'lblDisplayUMF
        '
        Me.lblDisplayUMF.AutoSize = True
        Me.lblDisplayUMF.Location = New System.Drawing.Point(9, 28)
        Me.lblDisplayUMF.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayUMF.Name = "lblDisplayUMF"
        Me.lblDisplayUMF.Size = New System.Drawing.Size(128, 17)
        Me.lblDisplayUMF.TabIndex = 143
        Me.lblDisplayUMF.Text = "U. Medica familiar :"
        '
        'txtNombreMadre
        '
        Me.txtNombreMadre.Location = New System.Drawing.Point(165, 86)
        Me.txtNombreMadre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombreMadre.MaxLength = 50
        Me.txtNombreMadre.Name = "txtNombreMadre"
        Me.txtNombreMadre.Size = New System.Drawing.Size(267, 22)
        Me.txtNombreMadre.TabIndex = 2
        '
        'cboUnidadMedicaFamiliar
        '
        Me.cboUnidadMedicaFamiliar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadMedicaFamiliar.FormattingEnabled = True
        Me.cboUnidadMedicaFamiliar.Location = New System.Drawing.Point(165, 23)
        Me.cboUnidadMedicaFamiliar.Margin = New System.Windows.Forms.Padding(4)
        Me.cboUnidadMedicaFamiliar.MaxLength = 1
        Me.cboUnidadMedicaFamiliar.Name = "cboUnidadMedicaFamiliar"
        Me.cboUnidadMedicaFamiliar.Size = New System.Drawing.Size(267, 24)
        Me.cboUnidadMedicaFamiliar.TabIndex = 0
        '
        'lblDisplayNombreMadre
        '
        Me.lblDisplayNombreMadre.AutoSize = True
        Me.lblDisplayNombreMadre.Location = New System.Drawing.Point(9, 91)
        Me.lblDisplayNombreMadre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayNombreMadre.Name = "lblDisplayNombreMadre"
        Me.lblDisplayNombreMadre.Size = New System.Drawing.Size(145, 17)
        Me.lblDisplayNombreMadre.TabIndex = 113
        Me.lblDisplayNombreMadre.Text = "Nombre de la madre :"
        '
        'gbDatosIMSS
        '
        Me.gbDatosIMSS.Controls.Add(Me.ckbSindicato)
        Me.gbDatosIMSS.Controls.Add(Me.ckbFijoIMSS)
        Me.gbDatosIMSS.Controls.Add(Me.ckbAfiliableIMSS)
        Me.gbDatosIMSS.Controls.Add(Me.Label1)
        Me.gbDatosIMSS.Controls.Add(Me.lblDisplayUMF)
        Me.gbDatosIMSS.Controls.Add(Me.lblDisplayFijoIMSS)
        Me.gbDatosIMSS.Controls.Add(Me.lblDisplayNombreMadre)
        Me.gbDatosIMSS.Controls.Add(Me.cboUnidadMedicaFamiliar)
        Me.gbDatosIMSS.Controls.Add(Me.lblDisplayAfiliableIMSS)
        Me.gbDatosIMSS.Controls.Add(Me.txtNombreMadre)
        Me.gbDatosIMSS.Controls.Add(Me.lblDisplayNombrePadre)
        Me.gbDatosIMSS.Controls.Add(Me.txtNombrePadre)
        Me.gbDatosIMSS.Controls.Add(Me.lblDisplayNumeroIMSS)
        Me.gbDatosIMSS.Controls.Add(Me.txtNumIMSS)
        Me.gbDatosIMSS.Location = New System.Drawing.Point(456, 478)
        Me.gbDatosIMSS.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDatosIMSS.Name = "gbDatosIMSS"
        Me.gbDatosIMSS.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDatosIMSS.Size = New System.Drawing.Size(449, 236)
        Me.gbDatosIMSS.TabIndex = 3
        Me.gbDatosIMSS.TabStop = False
        Me.gbDatosIMSS.Text = "Datos IMSS del trabajador"
        '
        'ckbSindicato
        '
        Me.ckbSindicato.AutoSize = True
        Me.ckbSindicato.Location = New System.Drawing.Point(413, 155)
        Me.ckbSindicato.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbSindicato.Name = "ckbSindicato"
        Me.ckbSindicato.Size = New System.Drawing.Size(18, 17)
        Me.ckbSindicato.TabIndex = 6
        Me.ckbSindicato.UseVisualStyleBackColor = True
        '
        'ckbFijoIMSS
        '
        Me.ckbFijoIMSS.AutoSize = True
        Me.ckbFijoIMSS.Location = New System.Drawing.Point(173, 185)
        Me.ckbFijoIMSS.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbFijoIMSS.Name = "ckbFijoIMSS"
        Me.ckbFijoIMSS.Size = New System.Drawing.Size(18, 17)
        Me.ckbFijoIMSS.TabIndex = 5
        Me.ckbFijoIMSS.UseVisualStyleBackColor = True
        '
        'ckbAfiliableIMSS
        '
        Me.ckbAfiliableIMSS.AutoSize = True
        Me.ckbAfiliableIMSS.Location = New System.Drawing.Point(173, 155)
        Me.ckbAfiliableIMSS.Margin = New System.Windows.Forms.Padding(4)
        Me.ckbAfiliableIMSS.Name = "ckbAfiliableIMSS"
        Me.ckbAfiliableIMSS.Size = New System.Drawing.Size(18, 17)
        Me.ckbAfiliableIMSS.TabIndex = 4
        Me.ckbAfiliableIMSS.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(247, 156)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 17)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Calcula sindicato :"
        '
        'pbFotoTrabajador
        '
        Me.pbFotoTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbFotoTrabajador.Location = New System.Drawing.Point(469, 38)
        Me.pbFotoTrabajador.Margin = New System.Windows.Forms.Padding(4)
        Me.pbFotoTrabajador.Name = "pbFotoTrabajador"
        Me.pbFotoTrabajador.Size = New System.Drawing.Size(164, 179)
        Me.pbFotoTrabajador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFotoTrabajador.TabIndex = 126
        Me.pbFotoTrabajador.TabStop = False
        '
        'gbInformacion
        '
        Me.gbInformacion.Controls.Add(Me.btnAgregaFoto)
        Me.gbInformacion.Controls.Add(Me.gbDatosGenerales)
        Me.gbInformacion.Controls.Add(Me.pbFotoTrabajador)
        Me.gbInformacion.Controls.Add(Me.gbDatosTrabajador)
        Me.gbInformacion.Controls.Add(Me.gbDomicilio)
        Me.gbInformacion.Controls.Add(Me.gbDatosIMSS)
        Me.gbInformacion.Location = New System.Drawing.Point(16, 34)
        Me.gbInformacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gbInformacion.Name = "gbInformacion"
        Me.gbInformacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gbInformacion.Size = New System.Drawing.Size(915, 751)
        Me.gbInformacion.TabIndex = 0
        Me.gbInformacion.TabStop = False
        Me.gbInformacion.Text = "Información del trabajador"
        '
        'btnAgregaFoto
        '
        Me.btnAgregaFoto.Location = New System.Drawing.Point(659, 190)
        Me.btnAgregaFoto.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregaFoto.Name = "btnAgregaFoto"
        Me.btnAgregaFoto.Size = New System.Drawing.Size(100, 28)
        Me.btnAgregaFoto.TabIndex = 373
        Me.btnAgregaFoto.Text = "Agregar foto"
        Me.btnAgregaFoto.UseVisualStyleBackColor = True
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'Cat_Nomina_Trabajadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1379, 816)
        Me.Controls.Add(Me.gbInformacion)
        Me.Controls.Add(Me.gBoxBusquedaRapida)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Cat_Nomina_Trabajadores"
        Me.ShowIcon = False
        Me.Text = " Catálogo de trabajadores"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbDatosGenerales.ResumeLayout(False)
        Me.gbDatosGenerales.PerformLayout()
        Me.gBoxBusquedaRapida.ResumeLayout(False)
        Me.gBoxBusquedaRapida.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDomicilio.ResumeLayout(False)
        Me.gbDomicilio.PerformLayout()
        Me.gbDatosTrabajador.ResumeLayout(False)
        Me.gbDatosTrabajador.PerformLayout()
        Me.gbDatosIMSS.ResumeLayout(False)
        Me.gbDatosIMSS.PerformLayout()
        CType(Me.pbFotoTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbInformacion.ResumeLayout(False)
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
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplaySexo As System.Windows.Forms.Label
    Friend WithEvents cboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombre As System.Windows.Forms.Label
    Friend WithEvents TxtNombreTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents gBoxBusquedaRapida As System.Windows.Forms.GroupBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayEstado As System.Windows.Forms.Label
    Friend WithEvents lblDisplayLocalidad As System.Windows.Forms.Label
    Friend WithEvents cboDomicilioEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtDomicilioLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCiudad As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioCiudad As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilioCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayColonia As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioColonia As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumero As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilioCalle As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCalle As System.Windows.Forms.Label
    Friend WithEvents gbDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayApellidoMaterno As System.Windows.Forms.Label
    Friend WithEvents txtApellidoMaterno As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayApellidoPaterno As System.Windows.Forms.Label
    Friend WithEvents txtApellidoPaterno As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents lblDisplayArea As System.Windows.Forms.Label
    Friend WithEvents cboArea As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstadoNacimiento As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayEstadoNacimiento As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPuesto As System.Windows.Forms.Label
    Friend WithEvents cboPuesto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplaySueldo As System.Windows.Forms.Label
    Friend WithEvents txtSueldo As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumeroIMSS As System.Windows.Forms.Label
    Friend WithEvents txtNumIMSS As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayPuntoPago As System.Windows.Forms.Label
    Friend WithEvents cboPuntoPago As System.Windows.Forms.ComboBox
    Friend WithEvents gbDatosTrabajador As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents ckbPagoTarjeta As System.Windows.Forms.CheckBox
    Friend WithEvents lblDisplayNumTarjeta As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCodigoBanco As System.Windows.Forms.Label
    Friend WithEvents txtCodigoBanco As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayUMF As System.Windows.Forms.Label
    Friend WithEvents cboUnidadMedicaFamiliar As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombrePadre As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNombrePadre As System.Windows.Forms.Label
    Friend WithEvents txtNombreMadre As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNombreMadre As System.Windows.Forms.Label
    Friend WithEvents txtCodigoMayordomo As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCodigoMayordomo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFijoIMSS As System.Windows.Forms.Label
    Friend WithEvents lblDisplayAfiliableIMSS As System.Windows.Forms.Label
    Friend WithEvents pbFotoTrabajador As System.Windows.Forms.PictureBox
    Friend WithEvents gbDatosIMSS As System.Windows.Forms.GroupBox
    Friend WithEvents gbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayIdNominaTemporada As System.Windows.Forms.Label
    Friend WithEvents cboIdTemporada As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCURP As System.Windows.Forms.Label
    Friend WithEvents txtCurp As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayRFC As System.Windows.Forms.Label
    Friend WithEvents txtRfc As System.Windows.Forms.TextBox
    Friend WithEvents ckbFijoIMSS As System.Windows.Forms.CheckBox
    Friend WithEvents ckbAfiliableIMSS As System.Windows.Forms.CheckBox
    Friend WithEvents lblPagoTarjeta As System.Windows.Forms.Label
    Friend WithEvents LblBanco As System.Windows.Forms.Label
    Friend WithEvents lblNombreMayordomo As System.Windows.Forms.Label
    Friend WithEvents lblCuentaContable As System.Windows.Forms.Label
    Friend WithEvents txtCuentaContable As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregaFoto As System.Windows.Forms.Button
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents ckbSindicato As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTrabajadorBanco As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumeroCuentaBanco As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCuentaBanco As System.Windows.Forms.TextBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
End Class
