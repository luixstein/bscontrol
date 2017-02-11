<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_AltaBajaIntegracionSUA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_AltaBajaIntegracionSUA))
        Me.gbSemanas = New System.Windows.Forms.GroupBox
        Me.gbValidacionesControl = New System.Windows.Forms.GroupBox
        Me.lbstValidacionesControl = New System.Windows.Forms.ListBox
        Me.ckbNuevos = New System.Windows.Forms.CheckBox
        Me.lblDisplayMovimiento = New System.Windows.Forms.Label
        Me.BtnReporte = New System.Windows.Forms.Button
        Me.lblModo = New System.Windows.Forms.Label
        Me.btnAltaAdicional = New System.Windows.Forms.Button
        Me.gbValidacionesQueCumplir = New System.Windows.Forms.GroupBox
        Me.lstbValidaciones = New System.Windows.Forms.ListBox
        Me.btnRegresar = New System.Windows.Forms.Button
        Me.btnConfirmar = New System.Windows.Forms.Button
        Me.btnGenerarBajas = New System.Windows.Forms.Button
        Me.btnGenerarAltas = New System.Windows.Forms.Button
        Me.lblDisplaySueldoDiarioIntegrado = New System.Windows.Forms.Label
        Me.txtSueldoDiario = New System.Windows.Forms.TextBox
        Me.lblDisplayTotalTrabajadores = New System.Windows.Forms.Label
        Me.lblDisplayFechaAl = New System.Windows.Forms.Label
        Me.lblDisplayFechaDel = New System.Windows.Forms.Label
        Me.txtTotalJornales = New System.Windows.Forms.TextBox
        Me.txtTotalImporte = New System.Windows.Forms.TextBox
        Me.lblDisplayTotalPercepcion = New System.Windows.Forms.Label
        Me.GridSemanaTrabajadores = New FlexCell.Grid
        Me.btnSemanaSiguiente = New System.Windows.Forms.Button
        Me.btnSemanaAnterior = New System.Windows.Forms.Button
        Me.lblDisplayTemporada = New System.Windows.Forms.Label
        Me.DtpFecha2 = New System.Windows.Forms.DateTimePicker
        Me.lblTemporadaPlaza = New System.Windows.Forms.Label
        Me.DtpFecha1 = New System.Windows.Forms.DateTimePicker
        Me.lblDisplayProductor = New System.Windows.Forms.Label
        Me.CboSemana = New System.Windows.Forms.ComboBox
        Me.tbAltaBaja = New System.Windows.Forms.TabControl
        Me.tpAltaBaja = New System.Windows.Forms.TabPage
        Me.tpIntegracion = New System.Windows.Forms.TabPage
        Me.gbIntegracion = New System.Windows.Forms.GroupBox
        Me.gbFecha = New System.Windows.Forms.GroupBox
        Me.rdbSumaDia = New System.Windows.Forms.RadioButton
        Me.rdbFechaEspecifica = New System.Windows.Forms.RadioButton
        Me.btnModificarFecha = New System.Windows.Forms.Button
        Me.dtFechaActualizar = New System.Windows.Forms.DateTimePicker
        Me.gbTotalesTrabajadores = New System.Windows.Forms.GroupBox
        Me.lblDisplayIgual = New System.Windows.Forms.Label
        Me.lblDisplayMas = New System.Windows.Forms.Label
        Me.txtTotalTrabajadores = New System.Windows.Forms.TextBox
        Me.gbLinea = New System.Windows.Forms.GroupBox
        Me.txtAceptados = New System.Windows.Forms.TextBox
        Me.txtRechazados = New System.Windows.Forms.TextBox
        Me.lblDisplayAceptados = New System.Windows.Forms.Label
        Me.lblDisplayRechazados = New System.Windows.Forms.Label
        Me.lblDisplayTotal = New System.Windows.Forms.Label
        Me.CkbMarcarTodo = New System.Windows.Forms.CheckBox
        Me.btnRegresarIntegracion = New System.Windows.Forms.Button
        Me.cboTxtArchivos = New System.Windows.Forms.ComboBox
        Me.GridIngracion = New FlexCell.Grid
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnIntegrar = New System.Windows.Forms.Button
        Me.gbSemanas.SuspendLayout()
        Me.gbValidacionesControl.SuspendLayout()
        Me.gbValidacionesQueCumplir.SuspendLayout()
        Me.tbAltaBaja.SuspendLayout()
        Me.tpAltaBaja.SuspendLayout()
        Me.tpIntegracion.SuspendLayout()
        Me.gbIntegracion.SuspendLayout()
        Me.gbFecha.SuspendLayout()
        Me.gbTotalesTrabajadores.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSemanas
        '
        Me.gbSemanas.Controls.Add(Me.gbValidacionesControl)
        Me.gbSemanas.Controls.Add(Me.ckbNuevos)
        Me.gbSemanas.Controls.Add(Me.lblDisplayMovimiento)
        Me.gbSemanas.Controls.Add(Me.BtnReporte)
        Me.gbSemanas.Controls.Add(Me.lblModo)
        Me.gbSemanas.Controls.Add(Me.btnAltaAdicional)
        Me.gbSemanas.Controls.Add(Me.gbValidacionesQueCumplir)
        Me.gbSemanas.Controls.Add(Me.btnRegresar)
        Me.gbSemanas.Controls.Add(Me.btnConfirmar)
        Me.gbSemanas.Controls.Add(Me.btnGenerarBajas)
        Me.gbSemanas.Controls.Add(Me.btnGenerarAltas)
        Me.gbSemanas.Controls.Add(Me.lblDisplaySueldoDiarioIntegrado)
        Me.gbSemanas.Controls.Add(Me.txtSueldoDiario)
        Me.gbSemanas.Controls.Add(Me.lblDisplayTotalTrabajadores)
        Me.gbSemanas.Controls.Add(Me.lblDisplayFechaAl)
        Me.gbSemanas.Controls.Add(Me.lblDisplayFechaDel)
        Me.gbSemanas.Controls.Add(Me.txtTotalJornales)
        Me.gbSemanas.Controls.Add(Me.txtTotalImporte)
        Me.gbSemanas.Controls.Add(Me.lblDisplayTotalPercepcion)
        Me.gbSemanas.Controls.Add(Me.GridSemanaTrabajadores)
        Me.gbSemanas.Controls.Add(Me.btnSemanaSiguiente)
        Me.gbSemanas.Controls.Add(Me.btnSemanaAnterior)
        Me.gbSemanas.Controls.Add(Me.lblDisplayTemporada)
        Me.gbSemanas.Controls.Add(Me.DtpFecha2)
        Me.gbSemanas.Controls.Add(Me.lblTemporadaPlaza)
        Me.gbSemanas.Controls.Add(Me.DtpFecha1)
        Me.gbSemanas.Controls.Add(Me.lblDisplayProductor)
        Me.gbSemanas.Controls.Add(Me.CboSemana)
        Me.gbSemanas.Location = New System.Drawing.Point(6, 6)
        Me.gbSemanas.Name = "gbSemanas"
        Me.gbSemanas.Size = New System.Drawing.Size(1154, 615)
        Me.gbSemanas.TabIndex = 377
        Me.gbSemanas.TabStop = False
        '
        'gbValidacionesControl
        '
        Me.gbValidacionesControl.Controls.Add(Me.lbstValidacionesControl)
        Me.gbValidacionesControl.Location = New System.Drawing.Point(861, 185)
        Me.gbValidacionesControl.Name = "gbValidacionesControl"
        Me.gbValidacionesControl.Size = New System.Drawing.Size(290, 121)
        Me.gbValidacionesControl.TabIndex = 402
        Me.gbValidacionesControl.TabStop = False
        Me.gbValidacionesControl.Text = "Validaciones de control que deben cumplirse "
        '
        'lbstValidacionesControl
        '
        Me.lbstValidacionesControl.FormattingEnabled = True
        Me.lbstValidacionesControl.Location = New System.Drawing.Point(6, 21)
        Me.lbstValidacionesControl.Name = "lbstValidacionesControl"
        Me.lbstValidacionesControl.Size = New System.Drawing.Size(278, 95)
        Me.lbstValidacionesControl.TabIndex = 395
        '
        'ckbNuevos
        '
        Me.ckbNuevos.AutoSize = True
        Me.ckbNuevos.Checked = True
        Me.ckbNuevos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbNuevos.Location = New System.Drawing.Point(867, 150)
        Me.ckbNuevos.Name = "ckbNuevos"
        Me.ckbNuevos.Size = New System.Drawing.Size(236, 17)
        Me.ckbNuevos.TabIndex = 401
        Me.ckbNuevos.Text = "Incluir trabajadores nuevos sin percepciones"
        Me.ckbNuevos.UseVisualStyleBackColor = True
        '
        'lblDisplayMovimiento
        '
        Me.lblDisplayMovimiento.AutoSize = True
        Me.lblDisplayMovimiento.Location = New System.Drawing.Point(864, 121)
        Me.lblDisplayMovimiento.Name = "lblDisplayMovimiento"
        Me.lblDisplayMovimiento.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayMovimiento.TabIndex = 400
        Me.lblDisplayMovimiento.Text = "Movimiento :"
        '
        'BtnReporte
        '
        Me.BtnReporte.Location = New System.Drawing.Point(1012, 443)
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(125, 40)
        Me.BtnReporte.TabIndex = 399
        Me.BtnReporte.Text = "Reporte de trabajadores excluidos"
        Me.BtnReporte.UseVisualStyleBackColor = True
        '
        'lblModo
        '
        Me.lblModo.AutoSize = True
        Me.lblModo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModo.Location = New System.Drawing.Point(937, 119)
        Me.lblModo.Name = "lblModo"
        Me.lblModo.Size = New System.Drawing.Size(12, 16)
        Me.lblModo.TabIndex = 398
        Me.lblModo.Text = "."
        '
        'btnAltaAdicional
        '
        Me.btnAltaAdicional.Location = New System.Drawing.Point(867, 443)
        Me.btnAltaAdicional.Name = "btnAltaAdicional"
        Me.btnAltaAdicional.Size = New System.Drawing.Size(125, 40)
        Me.btnAltaAdicional.TabIndex = 397
        Me.btnAltaAdicional.Text = "Agregar trabajador adicional"
        Me.btnAltaAdicional.UseVisualStyleBackColor = True
        '
        'gbValidacionesQueCumplir
        '
        Me.gbValidacionesQueCumplir.Controls.Add(Me.lstbValidaciones)
        Me.gbValidacionesQueCumplir.Location = New System.Drawing.Point(861, 314)
        Me.gbValidacionesQueCumplir.Name = "gbValidacionesQueCumplir"
        Me.gbValidacionesQueCumplir.Size = New System.Drawing.Size(290, 121)
        Me.gbValidacionesQueCumplir.TabIndex = 396
        Me.gbValidacionesQueCumplir.TabStop = False
        Me.gbValidacionesQueCumplir.Text = "Validaciones que deben cumplirse"
        '
        'lstbValidaciones
        '
        Me.lstbValidaciones.FormattingEnabled = True
        Me.lstbValidaciones.Location = New System.Drawing.Point(6, 19)
        Me.lstbValidaciones.Name = "lstbValidaciones"
        Me.lstbValidaciones.Size = New System.Drawing.Size(278, 95)
        Me.lstbValidaciones.TabIndex = 395
        '
        'btnRegresar
        '
        Me.btnRegresar.Location = New System.Drawing.Point(1012, 570)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(119, 23)
        Me.btnRegresar.TabIndex = 388
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Location = New System.Drawing.Point(873, 570)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(119, 23)
        Me.btnConfirmar.TabIndex = 387
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnGenerarBajas
        '
        Me.btnGenerarBajas.Location = New System.Drawing.Point(1026, 89)
        Me.btnGenerarBajas.Name = "btnGenerarBajas"
        Me.btnGenerarBajas.Size = New System.Drawing.Size(119, 23)
        Me.btnGenerarBajas.TabIndex = 384
        Me.btnGenerarBajas.Text = "Generar bajas"
        Me.btnGenerarBajas.UseVisualStyleBackColor = True
        '
        'btnGenerarAltas
        '
        Me.btnGenerarAltas.Location = New System.Drawing.Point(867, 76)
        Me.btnGenerarAltas.Name = "btnGenerarAltas"
        Me.btnGenerarAltas.Size = New System.Drawing.Size(119, 42)
        Me.btnGenerarAltas.TabIndex = 383
        Me.btnGenerarAltas.Text = "Altas sugeridas de la semana seleccionada"
        Me.btnGenerarAltas.UseVisualStyleBackColor = True
        '
        'lblDisplaySueldoDiarioIntegrado
        '
        Me.lblDisplaySueldoDiarioIntegrado.AutoSize = True
        Me.lblDisplaySueldoDiarioIntegrado.Location = New System.Drawing.Point(871, 544)
        Me.lblDisplaySueldoDiarioIntegrado.Name = "lblDisplaySueldoDiarioIntegrado"
        Me.lblDisplaySueldoDiarioIntegrado.Size = New System.Drawing.Size(121, 13)
        Me.lblDisplaySueldoDiarioIntegrado.TabIndex = 382
        Me.lblDisplaySueldoDiarioIntegrado.Text = "Sueldo diario integrado :"
        '
        'txtSueldoDiario
        '
        Me.txtSueldoDiario.Enabled = False
        Me.txtSueldoDiario.Location = New System.Drawing.Point(1012, 541)
        Me.txtSueldoDiario.Name = "txtSueldoDiario"
        Me.txtSueldoDiario.Size = New System.Drawing.Size(119, 20)
        Me.txtSueldoDiario.TabIndex = 381
        Me.txtSueldoDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotalTrabajadores
        '
        Me.lblDisplayTotalTrabajadores.AutoSize = True
        Me.lblDisplayTotalTrabajadores.Location = New System.Drawing.Point(871, 518)
        Me.lblDisplayTotalTrabajadores.Name = "lblDisplayTotalTrabajadores"
        Me.lblDisplayTotalTrabajadores.Size = New System.Drawing.Size(98, 13)
        Me.lblDisplayTotalTrabajadores.TabIndex = 380
        Me.lblDisplayTotalTrabajadores.Text = "Total trabajadores :"
        '
        'lblDisplayFechaAl
        '
        Me.lblDisplayFechaAl.AutoSize = True
        Me.lblDisplayFechaAl.Location = New System.Drawing.Point(496, 49)
        Me.lblDisplayFechaAl.Name = "lblDisplayFechaAl"
        Me.lblDisplayFechaAl.Size = New System.Drawing.Size(22, 13)
        Me.lblDisplayFechaAl.TabIndex = 379
        Me.lblDisplayFechaAl.Text = "Al :"
        '
        'lblDisplayFechaDel
        '
        Me.lblDisplayFechaDel.AutoSize = True
        Me.lblDisplayFechaDel.Location = New System.Drawing.Point(322, 49)
        Me.lblDisplayFechaDel.Name = "lblDisplayFechaDel"
        Me.lblDisplayFechaDel.Size = New System.Drawing.Size(29, 13)
        Me.lblDisplayFechaDel.TabIndex = 378
        Me.lblDisplayFechaDel.Text = "Del :"
        '
        'txtTotalJornales
        '
        Me.txtTotalJornales.Enabled = False
        Me.txtTotalJornales.Location = New System.Drawing.Point(1012, 515)
        Me.txtTotalJornales.Name = "txtTotalJornales"
        Me.txtTotalJornales.Size = New System.Drawing.Size(119, 20)
        Me.txtTotalJornales.TabIndex = 377
        Me.txtTotalJornales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalImporte
        '
        Me.txtTotalImporte.Enabled = False
        Me.txtTotalImporte.Location = New System.Drawing.Point(1012, 489)
        Me.txtTotalImporte.Name = "txtTotalImporte"
        Me.txtTotalImporte.Size = New System.Drawing.Size(119, 20)
        Me.txtTotalImporte.TabIndex = 376
        Me.txtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotalPercepcion
        '
        Me.lblDisplayTotalPercepcion.AutoSize = True
        Me.lblDisplayTotalPercepcion.Location = New System.Drawing.Point(871, 492)
        Me.lblDisplayTotalPercepcion.Name = "lblDisplayTotalPercepcion"
        Me.lblDisplayTotalPercepcion.Size = New System.Drawing.Size(104, 13)
        Me.lblDisplayTotalPercepcion.TabIndex = 375
        Me.lblDisplayTotalPercepcion.Text = "Total percepciones :"
        '
        'GridSemanaTrabajadores
        '
        Me.GridSemanaTrabajadores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridSemanaTrabajadores.CheckedImage = CType(resources.GetObject("GridSemanaTrabajadores.CheckedImage"), System.Drawing.Bitmap)
        Me.GridSemanaTrabajadores.Cols = 1
        Me.GridSemanaTrabajadores.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridSemanaTrabajadores.DisplayRowNumber = True
        Me.GridSemanaTrabajadores.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridSemanaTrabajadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSemanaTrabajadores.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSemanaTrabajadores.Location = New System.Drawing.Point(6, 76)
        Me.GridSemanaTrabajadores.LockButton = True
        Me.GridSemanaTrabajadores.Name = "GridSemanaTrabajadores"
        Me.GridSemanaTrabajadores.Rows = 8
        Me.GridSemanaTrabajadores.Size = New System.Drawing.Size(841, 517)
        Me.GridSemanaTrabajadores.TabIndex = 374
        Me.GridSemanaTrabajadores.UncheckedImage = CType(resources.GetObject("GridSemanaTrabajadores.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnSemanaSiguiente
        '
        Me.btnSemanaSiguiente.Location = New System.Drawing.Point(221, 45)
        Me.btnSemanaSiguiente.Name = "btnSemanaSiguiente"
        Me.btnSemanaSiguiente.Size = New System.Drawing.Size(50, 21)
        Me.btnSemanaSiguiente.TabIndex = 373
        Me.btnSemanaSiguiente.Text = ">>"
        Me.btnSemanaSiguiente.UseVisualStyleBackColor = True
        '
        'btnSemanaAnterior
        '
        Me.btnSemanaAnterior.Location = New System.Drawing.Point(152, 45)
        Me.btnSemanaAnterior.Name = "btnSemanaAnterior"
        Me.btnSemanaAnterior.Size = New System.Drawing.Size(50, 21)
        Me.btnSemanaAnterior.TabIndex = 372
        Me.btnSemanaAnterior.Text = "<<"
        Me.btnSemanaAnterior.UseVisualStyleBackColor = True
        '
        'lblDisplayTemporada
        '
        Me.lblDisplayTemporada.AutoSize = True
        Me.lblDisplayTemporada.Location = New System.Drawing.Point(11, 25)
        Me.lblDisplayTemporada.Name = "lblDisplayTemporada"
        Me.lblDisplayTemporada.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayTemporada.TabIndex = 356
        Me.lblDisplayTemporada.Text = "Temporada :"
        '
        'DtpFecha2
        '
        Me.DtpFecha2.CustomFormat = "dd-MMM-yy"
        Me.DtpFecha2.Enabled = False
        Me.DtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha2.Location = New System.Drawing.Point(524, 45)
        Me.DtpFecha2.Name = "DtpFecha2"
        Me.DtpFecha2.Size = New System.Drawing.Size(100, 20)
        Me.DtpFecha2.TabIndex = 361
        '
        'lblTemporadaPlaza
        '
        Me.lblTemporadaPlaza.AutoSize = True
        Me.lblTemporadaPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemporadaPlaza.Location = New System.Drawing.Point(87, 24)
        Me.lblTemporadaPlaza.Name = "lblTemporadaPlaza"
        Me.lblTemporadaPlaza.Size = New System.Drawing.Size(12, 15)
        Me.lblTemporadaPlaza.TabIndex = 357
        Me.lblTemporadaPlaza.Text = "."
        '
        'DtpFecha1
        '
        Me.DtpFecha1.CustomFormat = "dd-MMM-yy"
        Me.DtpFecha1.Enabled = False
        Me.DtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha1.Location = New System.Drawing.Point(359, 45)
        Me.DtpFecha1.Name = "DtpFecha1"
        Me.DtpFecha1.Size = New System.Drawing.Size(100, 20)
        Me.DtpFecha1.TabIndex = 360
        '
        'lblDisplayProductor
        '
        Me.lblDisplayProductor.AutoSize = True
        Me.lblDisplayProductor.Location = New System.Drawing.Point(11, 49)
        Me.lblDisplayProductor.Name = "lblDisplayProductor"
        Me.lblDisplayProductor.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplayProductor.TabIndex = 359
        Me.lblDisplayProductor.Text = "Semana :"
        '
        'CboSemana
        '
        Me.CboSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana.FormattingEnabled = True
        Me.CboSemana.Location = New System.Drawing.Point(87, 45)
        Me.CboSemana.Name = "CboSemana"
        Me.CboSemana.Size = New System.Drawing.Size(50, 21)
        Me.CboSemana.TabIndex = 358
        '
        'tbAltaBaja
        '
        Me.tbAltaBaja.Controls.Add(Me.tpAltaBaja)
        Me.tbAltaBaja.Controls.Add(Me.tpIntegracion)
        Me.tbAltaBaja.Location = New System.Drawing.Point(12, 12)
        Me.tbAltaBaja.Name = "tbAltaBaja"
        Me.tbAltaBaja.SelectedIndex = 0
        Me.tbAltaBaja.Size = New System.Drawing.Size(1174, 660)
        Me.tbAltaBaja.TabIndex = 395
        '
        'tpAltaBaja
        '
        Me.tpAltaBaja.Controls.Add(Me.gbSemanas)
        Me.tpAltaBaja.Location = New System.Drawing.Point(4, 22)
        Me.tpAltaBaja.Name = "tpAltaBaja"
        Me.tpAltaBaja.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAltaBaja.Size = New System.Drawing.Size(1166, 634)
        Me.tpAltaBaja.TabIndex = 0
        Me.tpAltaBaja.Text = "Alta/Baja"
        Me.tpAltaBaja.UseVisualStyleBackColor = True
        '
        'tpIntegracion
        '
        Me.tpIntegracion.Controls.Add(Me.gbIntegracion)
        Me.tpIntegracion.Location = New System.Drawing.Point(4, 22)
        Me.tpIntegracion.Name = "tpIntegracion"
        Me.tpIntegracion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIntegracion.Size = New System.Drawing.Size(1166, 634)
        Me.tpIntegracion.TabIndex = 1
        Me.tpIntegracion.Text = "Integración"
        Me.tpIntegracion.UseVisualStyleBackColor = True
        '
        'gbIntegracion
        '
        Me.gbIntegracion.Controls.Add(Me.gbFecha)
        Me.gbIntegracion.Controls.Add(Me.gbTotalesTrabajadores)
        Me.gbIntegracion.Controls.Add(Me.CkbMarcarTodo)
        Me.gbIntegracion.Controls.Add(Me.btnRegresarIntegracion)
        Me.gbIntegracion.Controls.Add(Me.cboTxtArchivos)
        Me.gbIntegracion.Controls.Add(Me.GridIngracion)
        Me.gbIntegracion.Controls.Add(Me.btnEliminar)
        Me.gbIntegracion.Controls.Add(Me.btnIntegrar)
        Me.gbIntegracion.Location = New System.Drawing.Point(6, 22)
        Me.gbIntegracion.Name = "gbIntegracion"
        Me.gbIntegracion.Size = New System.Drawing.Size(1011, 606)
        Me.gbIntegracion.TabIndex = 391
        Me.gbIntegracion.TabStop = False
        Me.gbIntegracion.Text = "Integración de trabajadores"
        '
        'gbFecha
        '
        Me.gbFecha.Controls.Add(Me.rdbSumaDia)
        Me.gbFecha.Controls.Add(Me.rdbFechaEspecifica)
        Me.gbFecha.Controls.Add(Me.btnModificarFecha)
        Me.gbFecha.Controls.Add(Me.dtFechaActualizar)
        Me.gbFecha.Location = New System.Drawing.Point(785, 179)
        Me.gbFecha.Name = "gbFecha"
        Me.gbFecha.Size = New System.Drawing.Size(220, 128)
        Me.gbFecha.TabIndex = 392
        Me.gbFecha.TabStop = False
        Me.gbFecha.Text = "Modificación de Fecha"
        '
        'rdbSumaDia
        '
        Me.rdbSumaDia.AutoSize = True
        Me.rdbSumaDia.Checked = True
        Me.rdbSumaDia.Location = New System.Drawing.Point(13, 26)
        Me.rdbSumaDia.Name = "rdbSumaDia"
        Me.rdbSumaDia.Size = New System.Drawing.Size(127, 17)
        Me.rdbSumaDia.TabIndex = 396
        Me.rdbSumaDia.TabStop = True
        Me.rdbSumaDia.Text = "Sumar un día a todos"
        Me.rdbSumaDia.UseVisualStyleBackColor = True
        '
        'rdbFechaEspecifica
        '
        Me.rdbFechaEspecifica.AutoSize = True
        Me.rdbFechaEspecifica.Location = New System.Drawing.Point(13, 44)
        Me.rdbFechaEspecifica.Name = "rdbFechaEspecifica"
        Me.rdbFechaEspecifica.Size = New System.Drawing.Size(106, 17)
        Me.rdbFechaEspecifica.TabIndex = 395
        Me.rdbFechaEspecifica.Text = "Fecha especifica"
        Me.rdbFechaEspecifica.UseVisualStyleBackColor = True
        '
        'btnModificarFecha
        '
        Me.btnModificarFecha.Location = New System.Drawing.Point(10, 93)
        Me.btnModificarFecha.Name = "btnModificarFecha"
        Me.btnModificarFecha.Size = New System.Drawing.Size(204, 23)
        Me.btnModificarFecha.TabIndex = 393
        Me.btnModificarFecha.Text = "Modificar"
        Me.btnModificarFecha.UseVisualStyleBackColor = True
        '
        'dtFechaActualizar
        '
        Me.dtFechaActualizar.CustomFormat = "dd-MMM-yy"
        Me.dtFechaActualizar.Enabled = False
        Me.dtFechaActualizar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaActualizar.Location = New System.Drawing.Point(41, 67)
        Me.dtFechaActualizar.Name = "dtFechaActualizar"
        Me.dtFechaActualizar.Size = New System.Drawing.Size(100, 20)
        Me.dtFechaActualizar.TabIndex = 362
        '
        'gbTotalesTrabajadores
        '
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayIgual)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayMas)
        Me.gbTotalesTrabajadores.Controls.Add(Me.txtTotalTrabajadores)
        Me.gbTotalesTrabajadores.Controls.Add(Me.gbLinea)
        Me.gbTotalesTrabajadores.Controls.Add(Me.txtAceptados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.txtRechazados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayAceptados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayRechazados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayTotal)
        Me.gbTotalesTrabajadores.Location = New System.Drawing.Point(785, 426)
        Me.gbTotalesTrabajadores.Name = "gbTotalesTrabajadores"
        Me.gbTotalesTrabajadores.Size = New System.Drawing.Size(220, 164)
        Me.gbTotalesTrabajadores.TabIndex = 391
        Me.gbTotalesTrabajadores.TabStop = False
        Me.gbTotalesTrabajadores.Text = "Totales trabajadores"
        '
        'lblDisplayIgual
        '
        Me.lblDisplayIgual.AutoSize = True
        Me.lblDisplayIgual.Location = New System.Drawing.Point(45, 132)
        Me.lblDisplayIgual.Name = "lblDisplayIgual"
        Me.lblDisplayIgual.Size = New System.Drawing.Size(13, 13)
        Me.lblDisplayIgual.TabIndex = 395
        Me.lblDisplayIgual.Text = "="
        '
        'lblDisplayMas
        '
        Me.lblDisplayMas.AutoSize = True
        Me.lblDisplayMas.Location = New System.Drawing.Point(48, 81)
        Me.lblDisplayMas.Name = "lblDisplayMas"
        Me.lblDisplayMas.Size = New System.Drawing.Size(13, 13)
        Me.lblDisplayMas.TabIndex = 394
        Me.lblDisplayMas.Text = "+"
        '
        'txtTotalTrabajadores
        '
        Me.txtTotalTrabajadores.Enabled = False
        Me.txtTotalTrabajadores.Location = New System.Drawing.Point(75, 129)
        Me.txtTotalTrabajadores.Name = "txtTotalTrabajadores"
        Me.txtTotalTrabajadores.Size = New System.Drawing.Size(124, 20)
        Me.txtTotalTrabajadores.TabIndex = 393
        '
        'gbLinea
        '
        Me.gbLinea.Location = New System.Drawing.Point(35, 100)
        Me.gbLinea.Name = "gbLinea"
        Me.gbLinea.Size = New System.Drawing.Size(166, 10)
        Me.gbLinea.TabIndex = 392
        Me.gbLinea.TabStop = False
        '
        'txtAceptados
        '
        Me.txtAceptados.Enabled = False
        Me.txtAceptados.Location = New System.Drawing.Point(75, 39)
        Me.txtAceptados.Name = "txtAceptados"
        Me.txtAceptados.Size = New System.Drawing.Size(124, 20)
        Me.txtAceptados.TabIndex = 4
        '
        'txtRechazados
        '
        Me.txtRechazados.Enabled = False
        Me.txtRechazados.Location = New System.Drawing.Point(75, 78)
        Me.txtRechazados.Name = "txtRechazados"
        Me.txtRechazados.Size = New System.Drawing.Size(124, 20)
        Me.txtRechazados.TabIndex = 3
        '
        'lblDisplayAceptados
        '
        Me.lblDisplayAceptados.AutoSize = True
        Me.lblDisplayAceptados.Location = New System.Drawing.Point(5, 23)
        Me.lblDisplayAceptados.Name = "lblDisplayAceptados"
        Me.lblDisplayAceptados.Size = New System.Drawing.Size(64, 13)
        Me.lblDisplayAceptados.TabIndex = 2
        Me.lblDisplayAceptados.Text = "Aceptados :"
        '
        'lblDisplayRechazados
        '
        Me.lblDisplayRechazados.AutoSize = True
        Me.lblDisplayRechazados.Location = New System.Drawing.Point(5, 62)
        Me.lblDisplayRechazados.Name = "lblDisplayRechazados"
        Me.lblDisplayRechazados.Size = New System.Drawing.Size(73, 13)
        Me.lblDisplayRechazados.TabIndex = 1
        Me.lblDisplayRechazados.Text = "Rechazados :"
        '
        'lblDisplayTotal
        '
        Me.lblDisplayTotal.AutoSize = True
        Me.lblDisplayTotal.Location = New System.Drawing.Point(5, 113)
        Me.lblDisplayTotal.Name = "lblDisplayTotal"
        Me.lblDisplayTotal.Size = New System.Drawing.Size(98, 13)
        Me.lblDisplayTotal.TabIndex = 0
        Me.lblDisplayTotal.Text = "Total trabajadores :"
        '
        'CkbMarcarTodo
        '
        Me.CkbMarcarTodo.AutoSize = True
        Me.CkbMarcarTodo.Location = New System.Drawing.Point(378, 33)
        Me.CkbMarcarTodo.Name = "CkbMarcarTodo"
        Me.CkbMarcarTodo.Size = New System.Drawing.Size(88, 17)
        Me.CkbMarcarTodo.TabIndex = 390
        Me.CkbMarcarTodo.Text = "Marcar todas"
        Me.CkbMarcarTodo.UseVisualStyleBackColor = True
        '
        'btnRegresarIntegracion
        '
        Me.btnRegresarIntegracion.Location = New System.Drawing.Point(793, 141)
        Me.btnRegresarIntegracion.Name = "btnRegresarIntegracion"
        Me.btnRegresarIntegracion.Size = New System.Drawing.Size(207, 23)
        Me.btnRegresarIntegracion.TabIndex = 389
        Me.btnRegresarIntegracion.Text = "Regresar"
        Me.btnRegresarIntegracion.UseVisualStyleBackColor = True
        '
        'cboTxtArchivos
        '
        Me.cboTxtArchivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTxtArchivos.FormattingEnabled = True
        Me.cboTxtArchivos.Location = New System.Drawing.Point(793, 56)
        Me.cboTxtArchivos.Name = "cboTxtArchivos"
        Me.cboTxtArchivos.Size = New System.Drawing.Size(209, 21)
        Me.cboTxtArchivos.TabIndex = 387
        '
        'GridIngracion
        '
        Me.GridIngracion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridIngracion.CheckedImage = CType(resources.GetObject("GridIngracion.CheckedImage"), System.Drawing.Bitmap)
        Me.GridIngracion.Cols = 1
        Me.GridIngracion.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridIngracion.DisplayRowNumber = True
        Me.GridIngracion.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridIngracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridIngracion.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridIngracion.Location = New System.Drawing.Point(20, 56)
        Me.GridIngracion.LockButton = True
        Me.GridIngracion.Name = "GridIngracion"
        Me.GridIngracion.Rows = 8
        Me.GridIngracion.Size = New System.Drawing.Size(759, 534)
        Me.GridIngracion.TabIndex = 375
        Me.GridIngracion.UncheckedImage = CType(resources.GetObject("GridIngracion.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(793, 83)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(207, 23)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnIntegrar
        '
        Me.btnIntegrar.Location = New System.Drawing.Point(793, 112)
        Me.btnIntegrar.Name = "btnIntegrar"
        Me.btnIntegrar.Size = New System.Drawing.Size(207, 23)
        Me.btnIntegrar.TabIndex = 385
        Me.btnIntegrar.Text = "Integrar"
        Me.btnIntegrar.UseVisualStyleBackColor = True
        '
        'Frm_Nomina_AltaBajaIntegracionSUA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 681)
        Me.Controls.Add(Me.tbAltaBaja)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_AltaBajaIntegracionSUA"
        Me.Text = "Alta/Baja/IntegracionSUA"
        Me.gbSemanas.ResumeLayout(False)
        Me.gbSemanas.PerformLayout()
        Me.gbValidacionesControl.ResumeLayout(False)
        Me.gbValidacionesQueCumplir.ResumeLayout(False)
        Me.tbAltaBaja.ResumeLayout(False)
        Me.tpAltaBaja.ResumeLayout(False)
        Me.tpIntegracion.ResumeLayout(False)
        Me.gbIntegracion.ResumeLayout(False)
        Me.gbIntegracion.PerformLayout()
        Me.gbFecha.ResumeLayout(False)
        Me.gbFecha.PerformLayout()
        Me.gbTotalesTrabajadores.ResumeLayout(False)
        Me.gbTotalesTrabajadores.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSemanas As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayTotalTrabajadores As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaAl As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaDel As System.Windows.Forms.Label
    Friend WithEvents txtTotalJornales As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalImporte As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTotalPercepcion As System.Windows.Forms.Label
    Friend WithEvents GridSemanaTrabajadores As FlexCell.Grid
    Friend WithEvents btnSemanaSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnSemanaAnterior As System.Windows.Forms.Button
    Friend WithEvents lblDisplayTemporada As System.Windows.Forms.Label
    Friend WithEvents DtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTemporadaPlaza As System.Windows.Forms.Label
    Friend WithEvents DtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayProductor As System.Windows.Forms.Label
    Friend WithEvents CboSemana As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplaySueldoDiarioIntegrado As System.Windows.Forms.Label
    Friend WithEvents txtSueldoDiario As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerarBajas As System.Windows.Forms.Button
    Friend WithEvents btnGenerarAltas As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents tbAltaBaja As System.Windows.Forms.TabControl
    Friend WithEvents tpAltaBaja As System.Windows.Forms.TabPage
    Friend WithEvents tpIntegracion As System.Windows.Forms.TabPage
    Friend WithEvents gbIntegracion As System.Windows.Forms.GroupBox
    Friend WithEvents GridIngracion As FlexCell.Grid
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnIntegrar As System.Windows.Forms.Button
    Friend WithEvents lstbValidaciones As System.Windows.Forms.ListBox
    Friend WithEvents gbValidacionesQueCumplir As System.Windows.Forms.GroupBox
    Friend WithEvents cboTxtArchivos As System.Windows.Forms.ComboBox
    Friend WithEvents btnRegresarIntegracion As System.Windows.Forms.Button
    Friend WithEvents CkbMarcarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents gbTotalesTrabajadores As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayIgual As System.Windows.Forms.Label
    Friend WithEvents lblDisplayMas As System.Windows.Forms.Label
    Friend WithEvents txtTotalTrabajadores As System.Windows.Forms.TextBox
    Friend WithEvents gbLinea As System.Windows.Forms.GroupBox
    Friend WithEvents txtAceptados As System.Windows.Forms.TextBox
    Friend WithEvents txtRechazados As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayAceptados As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRechazados As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents btnAltaAdicional As System.Windows.Forms.Button
    Friend WithEvents lblModo As System.Windows.Forms.Label
    Friend WithEvents BtnReporte As System.Windows.Forms.Button
    Friend WithEvents lblDisplayMovimiento As System.Windows.Forms.Label
    Friend WithEvents gbFecha As System.Windows.Forms.GroupBox
    Friend WithEvents btnModificarFecha As System.Windows.Forms.Button
    Friend WithEvents dtFechaActualizar As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdbSumaDia As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFechaEspecifica As System.Windows.Forms.RadioButton
    Friend WithEvents ckbNuevos As System.Windows.Forms.CheckBox
    Friend WithEvents gbValidacionesControl As System.Windows.Forms.GroupBox
    Friend WithEvents lbstValidacionesControl As System.Windows.Forms.ListBox
End Class
