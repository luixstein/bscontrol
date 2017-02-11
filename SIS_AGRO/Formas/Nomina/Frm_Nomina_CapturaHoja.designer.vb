<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_CapturaHoja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_CapturaHoja))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbSemanaDia = New System.Windows.Forms.GroupBox()
        Me.lblIdSemana = New System.Windows.Forms.Label()
        Me.txtNombreDia = New System.Windows.Forms.TextBox()
        Me.txtDia = New System.Windows.Forms.TextBox()
        Me.txtSemana = New System.Windows.Forms.TextBox()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayDia = New System.Windows.Forms.Label()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.lblDisplaySemana = New System.Windows.Forms.Label()
        Me.gbHoja = New System.Windows.Forms.GroupBox()
        Me.lblCentroCosto = New System.Windows.Forms.Label()
        Me.txtCentroCosto = New System.Windows.Forms.TextBox()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTurno = New System.Windows.Forms.Label()
        Me.cboConceptoActividad = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreActividad = New System.Windows.Forms.Label()
        Me.txtActividad = New System.Windows.Forms.TextBox()
        Me.CboHoras = New System.Windows.Forms.ComboBox()
        Me.CboPuntoPago = New System.Windows.Forms.ComboBox()
        Me.CboTipoPercepcion = New System.Windows.Forms.ComboBox()
        Me.CboLote = New System.Windows.Forms.ComboBox()
        Me.CboMercado = New System.Windows.Forms.ComboBox()
        Me.btnHojaSiguiente = New System.Windows.Forms.Button()
        Me.lblDisplayHoja = New System.Windows.Forms.Label()
        Me.CboCultivo = New System.Windows.Forms.ComboBox()
        Me.cboHojas = New System.Windows.Forms.ComboBox()
        Me.btnHojaAnterior = New System.Windows.Forms.Button()
        Me.lblDisplayHoras = New System.Windows.Forms.Label()
        Me.lblDisplayPuntoPago = New System.Windows.Forms.Label()
        Me.lblDisplayTipoPercepcion = New System.Windows.Forms.Label()
        Me.lblDisplayActividad = New System.Windows.Forms.Label()
        Me.lblDisplayLote = New System.Windows.Forms.Label()
        Me.lblDisplayMercado = New System.Windows.Forms.Label()
        Me.lblDisplayCultivo = New System.Windows.Forms.Label()
        Me.lblDisplayCentroCosto = New System.Windows.Forms.Label()
        Me.gbPercepciones = New System.Windows.Forms.GroupBox()
        Me.txtTotalCajasCortadas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalJornales = New System.Windows.Forms.TextBox()
        Me.txtTotalPercepcion = New System.Windows.Forms.TextBox()
        Me.lblTotalJornales = New System.Windows.Forms.Label()
        Me.lblDisplayTotalPercepciones = New System.Windows.Forms.Label()
        Me.GridPercepciones = New FlexCell.Grid()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsMenu.SuspendLayout()
        Me.gbSemanaDia.SuspendLayout()
        Me.gbHoja.SuspendLayout()
        Me.gbPercepciones.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbEliminar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1102, 25)
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
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbSemanaDia
        '
        Me.gbSemanaDia.Controls.Add(Me.lblIdSemana)
        Me.gbSemanaDia.Controls.Add(Me.txtNombreDia)
        Me.gbSemanaDia.Controls.Add(Me.txtDia)
        Me.gbSemanaDia.Controls.Add(Me.txtSemana)
        Me.gbSemanaDia.Controls.Add(Me.DtpFecha)
        Me.gbSemanaDia.Controls.Add(Me.lblDisplayDia)
        Me.gbSemanaDia.Controls.Add(Me.lblDisplayFecha)
        Me.gbSemanaDia.Controls.Add(Me.lblDisplaySemana)
        Me.gbSemanaDia.Location = New System.Drawing.Point(12, 28)
        Me.gbSemanaDia.Name = "gbSemanaDia"
        Me.gbSemanaDia.Size = New System.Drawing.Size(908, 47)
        Me.gbSemanaDia.TabIndex = 4
        Me.gbSemanaDia.TabStop = False
        '
        'lblIdSemana
        '
        Me.lblIdSemana.AutoSize = True
        Me.lblIdSemana.Location = New System.Drawing.Point(131, 23)
        Me.lblIdSemana.Name = "lblIdSemana"
        Me.lblIdSemana.Size = New System.Drawing.Size(10, 13)
        Me.lblIdSemana.TabIndex = 382
        Me.lblIdSemana.Text = "."
        Me.lblIdSemana.Visible = False
        '
        'txtNombreDia
        '
        Me.txtNombreDia.Enabled = False
        Me.txtNombreDia.Location = New System.Drawing.Point(529, 19)
        Me.txtNombreDia.Name = "txtNombreDia"
        Me.txtNombreDia.Size = New System.Drawing.Size(195, 20)
        Me.txtNombreDia.TabIndex = 381
        '
        'txtDia
        '
        Me.txtDia.Enabled = False
        Me.txtDia.Location = New System.Drawing.Point(467, 19)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.Size = New System.Drawing.Size(57, 20)
        Me.txtDia.TabIndex = 380
        '
        'txtSemana
        '
        Me.txtSemana.Enabled = False
        Me.txtSemana.Location = New System.Drawing.Point(68, 19)
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.Size = New System.Drawing.Size(57, 20)
        Me.txtSemana.TabIndex = 379
        '
        'DtpFecha
        '
        Me.DtpFecha.CustomFormat = "dd-MMM-yyyy"
        Me.DtpFecha.Enabled = False
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(235, 19)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(88, 20)
        Me.DtpFecha.TabIndex = 4
        '
        'lblDisplayDia
        '
        Me.lblDisplayDia.AutoSize = True
        Me.lblDisplayDia.Location = New System.Drawing.Point(409, 23)
        Me.lblDisplayDia.Name = "lblDisplayDia"
        Me.lblDisplayDia.Size = New System.Drawing.Size(31, 13)
        Me.lblDisplayDia.TabIndex = 3
        Me.lblDisplayDia.Text = "Día :"
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(177, 23)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 2
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'lblDisplaySemana
        '
        Me.lblDisplaySemana.AutoSize = True
        Me.lblDisplaySemana.Location = New System.Drawing.Point(10, 23)
        Me.lblDisplaySemana.Name = "lblDisplaySemana"
        Me.lblDisplaySemana.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplaySemana.TabIndex = 1
        Me.lblDisplaySemana.Text = "Semana :"
        '
        'gbHoja
        '
        Me.gbHoja.Controls.Add(Me.lblCentroCosto)
        Me.gbHoja.Controls.Add(Me.txtCentroCosto)
        Me.gbHoja.Controls.Add(Me.cboTurno)
        Me.gbHoja.Controls.Add(Me.lblDisplayTurno)
        Me.gbHoja.Controls.Add(Me.cboConceptoActividad)
        Me.gbHoja.Controls.Add(Me.Label1)
        Me.gbHoja.Controls.Add(Me.lblNombreActividad)
        Me.gbHoja.Controls.Add(Me.txtActividad)
        Me.gbHoja.Controls.Add(Me.CboHoras)
        Me.gbHoja.Controls.Add(Me.CboPuntoPago)
        Me.gbHoja.Controls.Add(Me.CboTipoPercepcion)
        Me.gbHoja.Controls.Add(Me.CboLote)
        Me.gbHoja.Controls.Add(Me.CboMercado)
        Me.gbHoja.Controls.Add(Me.btnHojaSiguiente)
        Me.gbHoja.Controls.Add(Me.lblDisplayHoja)
        Me.gbHoja.Controls.Add(Me.CboCultivo)
        Me.gbHoja.Controls.Add(Me.cboHojas)
        Me.gbHoja.Controls.Add(Me.btnHojaAnterior)
        Me.gbHoja.Controls.Add(Me.lblDisplayHoras)
        Me.gbHoja.Controls.Add(Me.lblDisplayPuntoPago)
        Me.gbHoja.Controls.Add(Me.lblDisplayTipoPercepcion)
        Me.gbHoja.Controls.Add(Me.lblDisplayActividad)
        Me.gbHoja.Controls.Add(Me.lblDisplayLote)
        Me.gbHoja.Controls.Add(Me.lblDisplayMercado)
        Me.gbHoja.Controls.Add(Me.lblDisplayCultivo)
        Me.gbHoja.Controls.Add(Me.lblDisplayCentroCosto)
        Me.gbHoja.Location = New System.Drawing.Point(12, 81)
        Me.gbHoja.Name = "gbHoja"
        Me.gbHoja.Size = New System.Drawing.Size(257, 443)
        Me.gbHoja.TabIndex = 0
        Me.gbHoja.TabStop = False
        Me.gbHoja.Text = "Datos de la hoja"
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.AutoSize = True
        Me.lblCentroCosto.Location = New System.Drawing.Point(10, 70)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(21, 13)
        Me.lblCentroCosto.TabIndex = 384
        Me.lblCentroCosto.Text = "CC"
        '
        'txtCentroCosto
        '
        Me.txtCentroCosto.Location = New System.Drawing.Point(101, 50)
        Me.txtCentroCosto.MaxLength = 5
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.Size = New System.Drawing.Size(57, 20)
        Me.txtCentroCosto.TabIndex = 1
        '
        'cboTurno
        '
        Me.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Items.AddRange(New Object() {"MAÑANA", "TARDE"})
        Me.cboTurno.Location = New System.Drawing.Point(100, 324)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(150, 21)
        Me.cboTurno.TabIndex = 9
        '
        'lblDisplayTurno
        '
        Me.lblDisplayTurno.AutoSize = True
        Me.lblDisplayTurno.Location = New System.Drawing.Point(6, 328)
        Me.lblDisplayTurno.Name = "lblDisplayTurno"
        Me.lblDisplayTurno.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayTurno.TabIndex = 382
        Me.lblDisplayTurno.Text = "Turno :"
        '
        'cboConceptoActividad
        '
        Me.cboConceptoActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConceptoActividad.FormattingEnabled = True
        Me.cboConceptoActividad.Location = New System.Drawing.Point(8, 149)
        Me.cboConceptoActividad.Name = "cboConceptoActividad"
        Me.cboConceptoActividad.Size = New System.Drawing.Size(242, 21)
        Me.cboConceptoActividad.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 380
        Me.Label1.Text = "Actividad :"
        '
        'lblNombreActividad
        '
        Me.lblNombreActividad.AutoSize = True
        Me.lblNombreActividad.Location = New System.Drawing.Point(31, 200)
        Me.lblNombreActividad.Name = "lblNombreActividad"
        Me.lblNombreActividad.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreActividad.TabIndex = 379
        Me.lblNombreActividad.Text = "."
        '
        'txtActividad
        '
        Me.txtActividad.Location = New System.Drawing.Point(100, 175)
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.Size = New System.Drawing.Size(57, 20)
        Me.txtActividad.TabIndex = 4
        '
        'CboHoras
        '
        Me.CboHoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboHoras.FormattingEnabled = True
        Me.CboHoras.Location = New System.Drawing.Point(100, 297)
        Me.CboHoras.Name = "CboHoras"
        Me.CboHoras.Size = New System.Drawing.Size(57, 21)
        Me.CboHoras.TabIndex = 8
        '
        'CboPuntoPago
        '
        Me.CboPuntoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPuntoPago.FormattingEnabled = True
        Me.CboPuntoPago.Location = New System.Drawing.Point(100, 271)
        Me.CboPuntoPago.Name = "CboPuntoPago"
        Me.CboPuntoPago.Size = New System.Drawing.Size(151, 21)
        Me.CboPuntoPago.TabIndex = 7
        '
        'CboTipoPercepcion
        '
        Me.CboTipoPercepcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoPercepcion.FormattingEnabled = True
        Me.CboTipoPercepcion.Location = New System.Drawing.Point(100, 245)
        Me.CboTipoPercepcion.Name = "CboTipoPercepcion"
        Me.CboTipoPercepcion.Size = New System.Drawing.Size(151, 21)
        Me.CboTipoPercepcion.TabIndex = 6
        '
        'CboLote
        '
        Me.CboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLote.FormattingEnabled = True
        Me.CboLote.Location = New System.Drawing.Point(8, 107)
        Me.CboLote.Name = "CboLote"
        Me.CboLote.Size = New System.Drawing.Size(242, 21)
        Me.CboLote.TabIndex = 2
        '
        'CboMercado
        '
        Me.CboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMercado.FormattingEnabled = True
        Me.CboMercado.Location = New System.Drawing.Point(100, 385)
        Me.CboMercado.Name = "CboMercado"
        Me.CboMercado.Size = New System.Drawing.Size(151, 21)
        Me.CboMercado.TabIndex = 10
        Me.CboMercado.Visible = False
        '
        'btnHojaSiguiente
        '
        Me.btnHojaSiguiente.Location = New System.Drawing.Point(211, 20)
        Me.btnHojaSiguiente.Name = "btnHojaSiguiente"
        Me.btnHojaSiguiente.Size = New System.Drawing.Size(41, 21)
        Me.btnHojaSiguiente.TabIndex = 370
        Me.btnHojaSiguiente.Text = ">>"
        Me.btnHojaSiguiente.UseVisualStyleBackColor = True
        '
        'lblDisplayHoja
        '
        Me.lblDisplayHoja.AutoSize = True
        Me.lblDisplayHoja.Location = New System.Drawing.Point(9, 24)
        Me.lblDisplayHoja.Name = "lblDisplayHoja"
        Me.lblDisplayHoja.Size = New System.Drawing.Size(35, 13)
        Me.lblDisplayHoja.TabIndex = 0
        Me.lblDisplayHoja.Text = "Hoja :"
        '
        'CboCultivo
        '
        Me.CboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCultivo.FormattingEnabled = True
        Me.CboCultivo.Location = New System.Drawing.Point(100, 216)
        Me.CboCultivo.Name = "CboCultivo"
        Me.CboCultivo.Size = New System.Drawing.Size(151, 21)
        Me.CboCultivo.TabIndex = 5
        '
        'cboHojas
        '
        Me.cboHojas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHojas.FormattingEnabled = True
        Me.cboHojas.Location = New System.Drawing.Point(101, 20)
        Me.cboHojas.Name = "cboHojas"
        Me.cboHojas.Size = New System.Drawing.Size(57, 21)
        Me.cboHojas.TabIndex = 0
        '
        'btnHojaAnterior
        '
        Me.btnHojaAnterior.Location = New System.Drawing.Point(164, 20)
        Me.btnHojaAnterior.Name = "btnHojaAnterior"
        Me.btnHojaAnterior.Size = New System.Drawing.Size(41, 21)
        Me.btnHojaAnterior.TabIndex = 369
        Me.btnHojaAnterior.Text = "<<"
        Me.btnHojaAnterior.UseVisualStyleBackColor = True
        '
        'lblDisplayHoras
        '
        Me.lblDisplayHoras.AutoSize = True
        Me.lblDisplayHoras.Location = New System.Drawing.Point(6, 301)
        Me.lblDisplayHoras.Name = "lblDisplayHoras"
        Me.lblDisplayHoras.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayHoras.TabIndex = 8
        Me.lblDisplayHoras.Text = "Horas :"
        '
        'lblDisplayPuntoPago
        '
        Me.lblDisplayPuntoPago.AutoSize = True
        Me.lblDisplayPuntoPago.Location = New System.Drawing.Point(6, 275)
        Me.lblDisplayPuntoPago.Name = "lblDisplayPuntoPago"
        Me.lblDisplayPuntoPago.Size = New System.Drawing.Size(83, 13)
        Me.lblDisplayPuntoPago.TabIndex = 7
        Me.lblDisplayPuntoPago.Text = "Punto de pago :"
        '
        'lblDisplayTipoPercepcion
        '
        Me.lblDisplayTipoPercepcion.AutoSize = True
        Me.lblDisplayTipoPercepcion.Location = New System.Drawing.Point(6, 249)
        Me.lblDisplayTipoPercepcion.Name = "lblDisplayTipoPercepcion"
        Me.lblDisplayTipoPercepcion.Size = New System.Drawing.Size(90, 13)
        Me.lblDisplayTipoPercepcion.TabIndex = 6
        Me.lblDisplayTipoPercepcion.Text = "Tipo percepción :"
        '
        'lblDisplayActividad
        '
        Me.lblDisplayActividad.AutoSize = True
        Me.lblDisplayActividad.Location = New System.Drawing.Point(6, 179)
        Me.lblDisplayActividad.Name = "lblDisplayActividad"
        Me.lblDisplayActividad.Size = New System.Drawing.Size(79, 13)
        Me.lblDisplayActividad.TabIndex = 5
        Me.lblDisplayActividad.Text = "Sub-Actividad :"
        '
        'lblDisplayLote
        '
        Me.lblDisplayLote.AutoSize = True
        Me.lblDisplayLote.Location = New System.Drawing.Point(7, 91)
        Me.lblDisplayLote.Name = "lblDisplayLote"
        Me.lblDisplayLote.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayLote.TabIndex = 4
        Me.lblDisplayLote.Text = "Lote :"
        '
        'lblDisplayMercado
        '
        Me.lblDisplayMercado.AutoSize = True
        Me.lblDisplayMercado.Location = New System.Drawing.Point(6, 389)
        Me.lblDisplayMercado.Name = "lblDisplayMercado"
        Me.lblDisplayMercado.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplayMercado.TabIndex = 3
        Me.lblDisplayMercado.Text = "Mercado :"
        Me.lblDisplayMercado.Visible = False
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(6, 220)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 2
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'lblDisplayCentroCosto
        '
        Me.lblDisplayCentroCosto.AutoSize = True
        Me.lblDisplayCentroCosto.Location = New System.Drawing.Point(7, 50)
        Me.lblDisplayCentroCosto.Name = "lblDisplayCentroCosto"
        Me.lblDisplayCentroCosto.Size = New System.Drawing.Size(88, 13)
        Me.lblDisplayCentroCosto.TabIndex = 1
        Me.lblDisplayCentroCosto.Text = "Centro de costo :"
        '
        'gbPercepciones
        '
        Me.gbPercepciones.Controls.Add(Me.txtTotalCajasCortadas)
        Me.gbPercepciones.Controls.Add(Me.Label2)
        Me.gbPercepciones.Controls.Add(Me.txtTotalJornales)
        Me.gbPercepciones.Controls.Add(Me.txtTotalPercepcion)
        Me.gbPercepciones.Controls.Add(Me.lblTotalJornales)
        Me.gbPercepciones.Controls.Add(Me.lblDisplayTotalPercepciones)
        Me.gbPercepciones.Controls.Add(Me.GridPercepciones)
        Me.gbPercepciones.Location = New System.Drawing.Point(275, 81)
        Me.gbPercepciones.Name = "gbPercepciones"
        Me.gbPercepciones.Size = New System.Drawing.Size(815, 473)
        Me.gbPercepciones.TabIndex = 1
        Me.gbPercepciones.TabStop = False
        Me.gbPercepciones.Text = "Percepciones de trabajadores"
        '
        'txtTotalCajasCortadas
        '
        Me.txtTotalCajasCortadas.Enabled = False
        Me.txtTotalCajasCortadas.Location = New System.Drawing.Point(624, 443)
        Me.txtTotalCajasCortadas.Name = "txtTotalCajasCortadas"
        Me.txtTotalCajasCortadas.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalCajasCortadas.TabIndex = 385
        Me.txtTotalCajasCortadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Cross
        Me.Label2.Location = New System.Drawing.Point(470, 446)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 384
        Me.Label2.Text = "Total de cajas cortadas  :"
        '
        'txtTotalJornales
        '
        Me.txtTotalJornales.Enabled = False
        Me.txtTotalJornales.Location = New System.Drawing.Point(624, 417)
        Me.txtTotalJornales.Name = "txtTotalJornales"
        Me.txtTotalJornales.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalJornales.TabIndex = 383
        Me.txtTotalJornales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPercepcion
        '
        Me.txtTotalPercepcion.Enabled = False
        Me.txtTotalPercepcion.Location = New System.Drawing.Point(624, 391)
        Me.txtTotalPercepcion.Name = "txtTotalPercepcion"
        Me.txtTotalPercepcion.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalPercepcion.TabIndex = 382
        Me.txtTotalPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalJornales
        '
        Me.lblTotalJornales.AutoSize = True
        Me.lblTotalJornales.Cursor = System.Windows.Forms.Cursors.Cross
        Me.lblTotalJornales.Location = New System.Drawing.Point(470, 420)
        Me.lblTotalJornales.Name = "lblTotalJornales"
        Me.lblTotalJornales.Size = New System.Drawing.Size(91, 13)
        Me.lblTotalJornales.TabIndex = 10
        Me.lblTotalJornales.Text = "Total de jornales :"
        '
        'lblDisplayTotalPercepciones
        '
        Me.lblDisplayTotalPercepciones.AutoSize = True
        Me.lblDisplayTotalPercepciones.Location = New System.Drawing.Point(470, 393)
        Me.lblDisplayTotalPercepciones.Name = "lblDisplayTotalPercepciones"
        Me.lblDisplayTotalPercepciones.Size = New System.Drawing.Size(119, 13)
        Me.lblDisplayTotalPercepciones.TabIndex = 9
        Me.lblDisplayTotalPercepciones.Text = "Total de percepciones :"
        '
        'GridPercepciones
        '
        Me.GridPercepciones.CheckedImage = CType(resources.GetObject("GridPercepciones.CheckedImage"), System.Drawing.Bitmap)
        Me.GridPercepciones.Cols = 2
        Me.GridPercepciones.DisplayRowNumber = True
        Me.GridPercepciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPercepciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridPercepciones.Location = New System.Drawing.Point(11, 19)
        Me.GridPercepciones.Name = "GridPercepciones"
        Me.GridPercepciones.Rows = 2
        Me.GridPercepciones.Size = New System.Drawing.Size(798, 366)
        Me.GridPercepciones.TabIndex = 0
        Me.GridPercepciones.UncheckedImage = CType(resources.GetObject("GridPercepciones.UncheckedImage"), System.Drawing.Bitmap)
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tssElaboro})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 557)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1102, 24)
        Me.StatusStripEstado.TabIndex = 316
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tsslEstado
        '
        Me.tsslEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslEstado.Name = "tsslEstado"
        Me.tsslEstado.Size = New System.Drawing.Size(46, 19)
        Me.tsslEstado.Text = "Estado"
        '
        'tssElaboro
        '
        Me.tssElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssElaboro.Name = "tssElaboro"
        Me.tssElaboro.Size = New System.Drawing.Size(57, 19)
        Me.tssElaboro.Text = "Elaboró :"
        '
        'Frm_Nomina_CapturaHoja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 581)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbPercepciones)
        Me.Controls.Add(Me.gbHoja)
        Me.Controls.Add(Me.gbSemanaDia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_CapturaHoja"
        Me.Text = "Captura hoja"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbSemanaDia.ResumeLayout(False)
        Me.gbSemanaDia.PerformLayout()
        Me.gbHoja.ResumeLayout(False)
        Me.gbHoja.PerformLayout()
        Me.gbPercepciones.ResumeLayout(False)
        Me.gbPercepciones.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbSemanaDia As System.Windows.Forms.GroupBox
    Friend WithEvents gbHoja As System.Windows.Forms.GroupBox
    Friend WithEvents gbPercepciones As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayHoras As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPuntoPago As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTipoPercepcion As System.Windows.Forms.Label
    Friend WithEvents lblDisplayActividad As System.Windows.Forms.Label
    Friend WithEvents lblDisplayLote As System.Windows.Forms.Label
    Friend WithEvents lblDisplayMercado As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCultivo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCentroCosto As System.Windows.Forms.Label
    Friend WithEvents lblDisplayHoja As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboHojas As System.Windows.Forms.ComboBox
    Friend WithEvents btnHojaSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnHojaAnterior As System.Windows.Forms.Button
    Friend WithEvents CboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreActividad As System.Windows.Forms.Label
    Friend WithEvents txtActividad As System.Windows.Forms.TextBox
    Friend WithEvents CboHoras As System.Windows.Forms.ComboBox
    Friend WithEvents CboPuntoPago As System.Windows.Forms.ComboBox
    Friend WithEvents CboTipoPercepcion As System.Windows.Forms.ComboBox
    Friend WithEvents CboLote As System.Windows.Forms.ComboBox
    Friend WithEvents CboMercado As System.Windows.Forms.ComboBox
    Friend WithEvents GridPercepciones As FlexCell.Grid
    Friend WithEvents lblDisplaySemana As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayDia As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents txtNombreDia As System.Windows.Forms.TextBox
    Friend WithEvents txtDia As System.Windows.Forms.TextBox
    Friend WithEvents txtSemana As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalJornales As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPercepcion As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalJornales As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalPercepciones As System.Windows.Forms.Label
    Friend WithEvents lblIdSemana As System.Windows.Forms.Label
    Friend WithEvents cboConceptoActividad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTurno As System.Windows.Forms.Label
    Friend WithEvents txtTotalCajasCortadas As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCentroCosto As System.Windows.Forms.Label
    Friend WithEvents txtCentroCosto As System.Windows.Forms.TextBox
End Class
