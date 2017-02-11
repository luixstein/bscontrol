<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_CapturaPercepciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_CapturaPercepciones))
        Me.frame2 = New System.Windows.Forms.GroupBox()
        Me.RdbReporteSemana = New System.Windows.Forms.RadioButton()
        Me.btnImprimirRendimientoCorte = New System.Windows.Forms.Button()
        Me.RdbReporteRangoFechas = New System.Windows.Forms.RadioButton()
        Me.RdbReporteDia = New System.Windows.Forms.RadioButton()
        Me.dtFecha2_Reporte = New System.Windows.Forms.DateTimePicker()
        Me.dtFecha1_Reporte = New System.Windows.Forms.DateTimePicker()
        Me.btnImprimirListadoDiaPorLote = New System.Windows.Forms.Button()
        Me.btnImprimirListadoDiaPorCentroCosto = New System.Windows.Forms.Button()
        Me.GridDia = New FlexCell.Grid()
        Me.btnAgregaHoja = New System.Windows.Forms.Button()
        Me.lblDisplayTemporada = New System.Windows.Forms.Label()
        Me.lblTemporadaPlaza = New System.Windows.Forms.Label()
        Me.DtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.DtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.CboSemana = New System.Windows.Forms.ComboBox()
        Me.lblDisplayProductor = New System.Windows.Forms.Label()
        Me.btnSemanaSiguiente = New System.Windows.Forms.Button()
        Me.btnSemanaAnterior = New System.Windows.Forms.Button()
        Me.GridSemana = New FlexCell.Grid()
        Me.gbSemanas = New System.Windows.Forms.GroupBox()
        Me.btnGeneraPoliza = New System.Windows.Forms.Button()
        Me.lblDisplayRango = New System.Windows.Forms.Label()
        Me.txtRango = New System.Windows.Forms.TextBox()
        Me.lblDisplayConsecutivo = New System.Windows.Forms.Label()
        Me.txtConsecutivo = New System.Windows.Forms.TextBox()
        Me.gbReportes = New System.Windows.Forms.GroupBox()
        Me.txtImporteFlete = New System.Windows.Forms.TextBox()
        Me.rdbFletesPersonal = New System.Windows.Forms.RadioButton()
        Me.rdbFirma = New System.Windows.Forms.RadioButton()
        Me.rdbEmisionCosto = New System.Windows.Forms.RadioButton()
        Me.rdbCostosPresupuestos = New System.Windows.Forms.RadioButton()
        Me.RdbNominaPuntoPago = New System.Windows.Forms.RadioButton()
        Me.rdbMultiPuntoPagos = New System.Windows.Forms.RadioButton()
        Me.rdbCostos = New System.Windows.Forms.RadioButton()
        Me.lblDisplayPuntoPago = New System.Windows.Forms.Label()
        Me.cboTipoPago = New System.Windows.Forms.ComboBox()
        Me.btnImprimirReporte = New System.Windows.Forms.Button()
        Me.cboPuntoPago = New System.Windows.Forms.ComboBox()
        Me.RdbDeducciones = New System.Windows.Forms.RadioButton()
        Me.lblDisplayTipoPago = New System.Windows.Forms.Label()
        Me.RdbTotales = New System.Windows.Forms.RadioButton()
        Me.rdbSobres = New System.Windows.Forms.RadioButton()
        Me.RdbDistribucionEfectivo = New System.Windows.Forms.RadioButton()
        Me.BtnDispersion = New System.Windows.Forms.Button()
        Me.btnImprimirAlta = New System.Windows.Forms.Button()
        Me.btnPrenomina = New System.Windows.Forms.Button()
        Me.btnGeneraNomina = New System.Windows.Forms.Button()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayEstatusNomina = New System.Windows.Forms.Label()
        Me.lblDisplayFechaAl = New System.Windows.Forms.Label()
        Me.lblDisplayFechaDel = New System.Windows.Forms.Label()
        Me.txtTotalJornales = New System.Windows.Forms.TextBox()
        Me.txtTotalImporte = New System.Windows.Forms.TextBox()
        Me.lblDisplayTotales = New System.Windows.Forms.Label()
        Me.lblDisplayNota = New System.Windows.Forms.Label()
        Me.lblIDSemana = New System.Windows.Forms.Label()
        Me.lblDisplayIDSemana = New System.Windows.Forms.Label()
        Me.frame2.SuspendLayout()
        Me.gbSemanas.SuspendLayout()
        Me.gbReportes.SuspendLayout()
        Me.SuspendLayout()
        '
        'frame2
        '
        Me.frame2.Controls.Add(Me.RdbReporteSemana)
        Me.frame2.Controls.Add(Me.btnImprimirRendimientoCorte)
        Me.frame2.Controls.Add(Me.RdbReporteRangoFechas)
        Me.frame2.Controls.Add(Me.RdbReporteDia)
        Me.frame2.Controls.Add(Me.dtFecha2_Reporte)
        Me.frame2.Controls.Add(Me.dtFecha1_Reporte)
        Me.frame2.Controls.Add(Me.btnImprimirListadoDiaPorLote)
        Me.frame2.Controls.Add(Me.btnImprimirListadoDiaPorCentroCosto)
        Me.frame2.Controls.Add(Me.GridDia)
        Me.frame2.Controls.Add(Me.btnAgregaHoja)
        Me.frame2.Location = New System.Drawing.Point(482, 14)
        Me.frame2.Name = "frame2"
        Me.frame2.Size = New System.Drawing.Size(547, 602)
        Me.frame2.TabIndex = 1
        Me.frame2.TabStop = False
        Me.frame2.Text = "Hojas"
        '
        'RdbReporteSemana
        '
        Me.RdbReporteSemana.AutoSize = True
        Me.RdbReporteSemana.Location = New System.Drawing.Point(269, 28)
        Me.RdbReporteSemana.Name = "RdbReporteSemana"
        Me.RdbReporteSemana.Size = New System.Drawing.Size(86, 17)
        Me.RdbReporteSemana.TabIndex = 9
        Me.RdbReporteSemana.Text = "Esta semana"
        Me.RdbReporteSemana.UseVisualStyleBackColor = True
        '
        'btnImprimirRendimientoCorte
        '
        Me.btnImprimirRendimientoCorte.Location = New System.Drawing.Point(379, 58)
        Me.btnImprimirRendimientoCorte.Name = "btnImprimirRendimientoCorte"
        Me.btnImprimirRendimientoCorte.Size = New System.Drawing.Size(159, 23)
        Me.btnImprimirRendimientoCorte.TabIndex = 8
        Me.btnImprimirRendimientoCorte.Text = "Imprimir rendimiento corte"
        Me.btnImprimirRendimientoCorte.UseVisualStyleBackColor = True
        '
        'RdbReporteRangoFechas
        '
        Me.RdbReporteRangoFechas.AutoSize = True
        Me.RdbReporteRangoFechas.Location = New System.Drawing.Point(269, 58)
        Me.RdbReporteRangoFechas.Name = "RdbReporteRangoFechas"
        Me.RdbReporteRangoFechas.Size = New System.Drawing.Size(92, 17)
        Me.RdbReporteRangoFechas.TabIndex = 7
        Me.RdbReporteRangoFechas.Text = "Rango fechas"
        Me.RdbReporteRangoFechas.UseVisualStyleBackColor = True
        '
        'RdbReporteDia
        '
        Me.RdbReporteDia.AutoSize = True
        Me.RdbReporteDia.Checked = True
        Me.RdbReporteDia.Location = New System.Drawing.Point(269, 0)
        Me.RdbReporteDia.Name = "RdbReporteDia"
        Me.RdbReporteDia.Size = New System.Drawing.Size(107, 17)
        Me.RdbReporteDia.TabIndex = 6
        Me.RdbReporteDia.TabStop = True
        Me.RdbReporteDia.Text = "Dia seleccionado"
        Me.RdbReporteDia.UseVisualStyleBackColor = True
        '
        'dtFecha2_Reporte
        '
        Me.dtFecha2_Reporte.CustomFormat = "dd-MMM-yy"
        Me.dtFecha2_Reporte.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha2_Reporte.Location = New System.Drawing.Point(163, 28)
        Me.dtFecha2_Reporte.Name = "dtFecha2_Reporte"
        Me.dtFecha2_Reporte.Size = New System.Drawing.Size(100, 20)
        Me.dtFecha2_Reporte.TabIndex = 5
        Me.dtFecha2_Reporte.Visible = False
        '
        'dtFecha1_Reporte
        '
        Me.dtFecha1_Reporte.CustomFormat = "dd-MMM-yy"
        Me.dtFecha1_Reporte.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha1_Reporte.Location = New System.Drawing.Point(163, 4)
        Me.dtFecha1_Reporte.Name = "dtFecha1_Reporte"
        Me.dtFecha1_Reporte.Size = New System.Drawing.Size(100, 20)
        Me.dtFecha1_Reporte.TabIndex = 4
        Me.dtFecha1_Reporte.Visible = False
        '
        'btnImprimirListadoDiaPorLote
        '
        Me.btnImprimirListadoDiaPorLote.Location = New System.Drawing.Point(379, 29)
        Me.btnImprimirListadoDiaPorLote.Name = "btnImprimirListadoDiaPorLote"
        Me.btnImprimirListadoDiaPorLote.Size = New System.Drawing.Size(159, 23)
        Me.btnImprimirListadoDiaPorLote.TabIndex = 3
        Me.btnImprimirListadoDiaPorLote.Text = "Imprimir x lote"
        Me.btnImprimirListadoDiaPorLote.UseVisualStyleBackColor = True
        '
        'btnImprimirListadoDiaPorCentroCosto
        '
        Me.btnImprimirListadoDiaPorCentroCosto.Location = New System.Drawing.Point(379, 0)
        Me.btnImprimirListadoDiaPorCentroCosto.Name = "btnImprimirListadoDiaPorCentroCosto"
        Me.btnImprimirListadoDiaPorCentroCosto.Size = New System.Drawing.Size(159, 23)
        Me.btnImprimirListadoDiaPorCentroCosto.TabIndex = 2
        Me.btnImprimirListadoDiaPorCentroCosto.Text = "Imprimir x centro de costo"
        Me.btnImprimirListadoDiaPorCentroCosto.UseVisualStyleBackColor = True
        '
        'GridDia
        '
        Me.GridDia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridDia.CheckedImage = CType(resources.GetObject("GridDia.CheckedImage"), System.Drawing.Bitmap)
        Me.GridDia.Cols = 1
        Me.GridDia.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridDia.DisplayRowNumber = True
        Me.GridDia.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDia.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridDia.Location = New System.Drawing.Point(6, 90)
        Me.GridDia.LockButton = True
        Me.GridDia.Name = "GridDia"
        Me.GridDia.Rows = 8
        Me.GridDia.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridDia.Size = New System.Drawing.Size(532, 506)
        Me.GridDia.TabIndex = 1
        Me.GridDia.UncheckedImage = CType(resources.GetObject("GridDia.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnAgregaHoja
        '
        Me.btnAgregaHoja.Location = New System.Drawing.Point(6, 26)
        Me.btnAgregaHoja.Name = "btnAgregaHoja"
        Me.btnAgregaHoja.Size = New System.Drawing.Size(132, 23)
        Me.btnAgregaHoja.TabIndex = 0
        Me.btnAgregaHoja.Text = "Nueva hoja"
        Me.btnAgregaHoja.UseVisualStyleBackColor = True
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
        'lblTemporadaPlaza
        '
        Me.lblTemporadaPlaza.AutoSize = True
        Me.lblTemporadaPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemporadaPlaza.Location = New System.Drawing.Point(87, 24)
        Me.lblTemporadaPlaza.Name = "lblTemporadaPlaza"
        Me.lblTemporadaPlaza.Size = New System.Drawing.Size(12, 15)
        Me.lblTemporadaPlaza.TabIndex = 0
        Me.lblTemporadaPlaza.Text = "."
        '
        'DtpFecha2
        '
        Me.DtpFecha2.CustomFormat = "dd-MMM-yy"
        Me.DtpFecha2.Enabled = False
        Me.DtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha2.Location = New System.Drawing.Point(358, 45)
        Me.DtpFecha2.Name = "DtpFecha2"
        Me.DtpFecha2.Size = New System.Drawing.Size(100, 20)
        Me.DtpFecha2.TabIndex = 3
        '
        'DtpFecha1
        '
        Me.DtpFecha1.CustomFormat = "dd-MMM-yy"
        Me.DtpFecha1.Enabled = False
        Me.DtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha1.Location = New System.Drawing.Point(358, 21)
        Me.DtpFecha1.Name = "DtpFecha1"
        Me.DtpFecha1.Size = New System.Drawing.Size(100, 20)
        Me.DtpFecha1.TabIndex = 2
        '
        'CboSemana
        '
        Me.CboSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana.FormattingEnabled = True
        Me.CboSemana.Location = New System.Drawing.Point(87, 45)
        Me.CboSemana.Name = "CboSemana"
        Me.CboSemana.Size = New System.Drawing.Size(50, 21)
        Me.CboSemana.TabIndex = 1
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
        'btnSemanaSiguiente
        '
        Me.btnSemanaSiguiente.Location = New System.Drawing.Point(198, 45)
        Me.btnSemanaSiguiente.Name = "btnSemanaSiguiente"
        Me.btnSemanaSiguiente.Size = New System.Drawing.Size(37, 21)
        Me.btnSemanaSiguiente.TabIndex = 373
        Me.btnSemanaSiguiente.Text = ">>"
        Me.btnSemanaSiguiente.UseVisualStyleBackColor = True
        '
        'btnSemanaAnterior
        '
        Me.btnSemanaAnterior.Location = New System.Drawing.Point(155, 45)
        Me.btnSemanaAnterior.Name = "btnSemanaAnterior"
        Me.btnSemanaAnterior.Size = New System.Drawing.Size(37, 21)
        Me.btnSemanaAnterior.TabIndex = 372
        Me.btnSemanaAnterior.Text = "<<"
        Me.btnSemanaAnterior.UseVisualStyleBackColor = True
        '
        'GridSemana
        '
        Me.GridSemana.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridSemana.CheckedImage = CType(resources.GetObject("GridSemana.CheckedImage"), System.Drawing.Bitmap)
        Me.GridSemana.Cols = 1
        Me.GridSemana.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridSemana.DisplayRowNumber = True
        Me.GridSemana.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSemana.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSemana.Location = New System.Drawing.Point(6, 77)
        Me.GridSemana.LockButton = True
        Me.GridSemana.Name = "GridSemana"
        Me.GridSemana.Rows = 8
        Me.GridSemana.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridSemana.Size = New System.Drawing.Size(452, 203)
        Me.GridSemana.TabIndex = 4
        Me.GridSemana.UncheckedImage = CType(resources.GetObject("GridSemana.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbSemanas
        '
        Me.gbSemanas.Controls.Add(Me.lblIDSemana)
        Me.gbSemanas.Controls.Add(Me.lblDisplayIDSemana)
        Me.gbSemanas.Controls.Add(Me.btnGeneraPoliza)
        Me.gbSemanas.Controls.Add(Me.lblDisplayRango)
        Me.gbSemanas.Controls.Add(Me.txtRango)
        Me.gbSemanas.Controls.Add(Me.lblDisplayConsecutivo)
        Me.gbSemanas.Controls.Add(Me.txtConsecutivo)
        Me.gbSemanas.Controls.Add(Me.gbReportes)
        Me.gbSemanas.Controls.Add(Me.BtnDispersion)
        Me.gbSemanas.Controls.Add(Me.btnImprimirAlta)
        Me.gbSemanas.Controls.Add(Me.btnPrenomina)
        Me.gbSemanas.Controls.Add(Me.btnGeneraNomina)
        Me.gbSemanas.Controls.Add(Me.lblEstatus)
        Me.gbSemanas.Controls.Add(Me.lblDisplayEstatusNomina)
        Me.gbSemanas.Controls.Add(Me.lblDisplayFechaAl)
        Me.gbSemanas.Controls.Add(Me.lblDisplayFechaDel)
        Me.gbSemanas.Controls.Add(Me.txtTotalJornales)
        Me.gbSemanas.Controls.Add(Me.txtTotalImporte)
        Me.gbSemanas.Controls.Add(Me.lblDisplayTotales)
        Me.gbSemanas.Controls.Add(Me.GridSemana)
        Me.gbSemanas.Controls.Add(Me.btnSemanaSiguiente)
        Me.gbSemanas.Controls.Add(Me.btnSemanaAnterior)
        Me.gbSemanas.Controls.Add(Me.lblDisplayTemporada)
        Me.gbSemanas.Controls.Add(Me.DtpFecha2)
        Me.gbSemanas.Controls.Add(Me.lblTemporadaPlaza)
        Me.gbSemanas.Controls.Add(Me.DtpFecha1)
        Me.gbSemanas.Controls.Add(Me.lblDisplayProductor)
        Me.gbSemanas.Controls.Add(Me.CboSemana)
        Me.gbSemanas.Controls.Add(Me.lblDisplayNota)
        Me.gbSemanas.Location = New System.Drawing.Point(7, 14)
        Me.gbSemanas.Name = "gbSemanas"
        Me.gbSemanas.Size = New System.Drawing.Size(469, 602)
        Me.gbSemanas.TabIndex = 0
        Me.gbSemanas.TabStop = False
        Me.gbSemanas.Text = "Resumen semana"
        '
        'btnGeneraPoliza
        '
        Me.btnGeneraPoliza.Location = New System.Drawing.Point(6, 509)
        Me.btnGeneraPoliza.Name = "btnGeneraPoliza"
        Me.btnGeneraPoliza.Size = New System.Drawing.Size(150, 25)
        Me.btnGeneraPoliza.TabIndex = 396
        Me.btnGeneraPoliza.Text = "Generar póliza de nómina"
        Me.btnGeneraPoliza.UseVisualStyleBackColor = True
        '
        'lblDisplayRango
        '
        Me.lblDisplayRango.AutoSize = True
        Me.lblDisplayRango.Location = New System.Drawing.Point(9, 428)
        Me.lblDisplayRango.Name = "lblDisplayRango"
        Me.lblDisplayRango.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayRango.TabIndex = 395
        Me.lblDisplayRango.Text = "Rango :"
        '
        'txtRango
        '
        Me.txtRango.Location = New System.Drawing.Point(119, 425)
        Me.txtRango.MaxLength = 4
        Me.txtRango.Name = "txtRango"
        Me.txtRango.Size = New System.Drawing.Size(37, 20)
        Me.txtRango.TabIndex = 394
        Me.txtRango.Text = "100"
        Me.txtRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayConsecutivo
        '
        Me.lblDisplayConsecutivo.AutoSize = True
        Me.lblDisplayConsecutivo.Location = New System.Drawing.Point(11, 404)
        Me.lblDisplayConsecutivo.Name = "lblDisplayConsecutivo"
        Me.lblDisplayConsecutivo.Size = New System.Drawing.Size(72, 13)
        Me.lblDisplayConsecutivo.TabIndex = 393
        Me.lblDisplayConsecutivo.Text = "Consecutivo :"
        '
        'txtConsecutivo
        '
        Me.txtConsecutivo.Location = New System.Drawing.Point(119, 401)
        Me.txtConsecutivo.MaxLength = 4
        Me.txtConsecutivo.Name = "txtConsecutivo"
        Me.txtConsecutivo.Size = New System.Drawing.Size(37, 20)
        Me.txtConsecutivo.TabIndex = 385
        Me.txtConsecutivo.Text = "1"
        Me.txtConsecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbReportes
        '
        Me.gbReportes.Controls.Add(Me.txtImporteFlete)
        Me.gbReportes.Controls.Add(Me.rdbFletesPersonal)
        Me.gbReportes.Controls.Add(Me.rdbFirma)
        Me.gbReportes.Controls.Add(Me.rdbEmisionCosto)
        Me.gbReportes.Controls.Add(Me.rdbCostosPresupuestos)
        Me.gbReportes.Controls.Add(Me.RdbNominaPuntoPago)
        Me.gbReportes.Controls.Add(Me.rdbMultiPuntoPagos)
        Me.gbReportes.Controls.Add(Me.rdbCostos)
        Me.gbReportes.Controls.Add(Me.lblDisplayPuntoPago)
        Me.gbReportes.Controls.Add(Me.cboTipoPago)
        Me.gbReportes.Controls.Add(Me.btnImprimirReporte)
        Me.gbReportes.Controls.Add(Me.cboPuntoPago)
        Me.gbReportes.Controls.Add(Me.RdbDeducciones)
        Me.gbReportes.Controls.Add(Me.lblDisplayTipoPago)
        Me.gbReportes.Controls.Add(Me.RdbTotales)
        Me.gbReportes.Controls.Add(Me.rdbSobres)
        Me.gbReportes.Controls.Add(Me.RdbDistribucionEfectivo)
        Me.gbReportes.Location = New System.Drawing.Point(165, 322)
        Me.gbReportes.Name = "gbReportes"
        Me.gbReportes.Size = New System.Drawing.Size(293, 257)
        Me.gbReportes.TabIndex = 9
        Me.gbReportes.TabStop = False
        Me.gbReportes.Text = "Reportes"
        '
        'txtImporteFlete
        '
        Me.txtImporteFlete.Location = New System.Drawing.Point(134, 231)
        Me.txtImporteFlete.MaxLength = 12
        Me.txtImporteFlete.Name = "txtImporteFlete"
        Me.txtImporteFlete.Size = New System.Drawing.Size(69, 20)
        Me.txtImporteFlete.TabIndex = 397
        Me.txtImporteFlete.Text = "3.00"
        Me.txtImporteFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rdbFletesPersonal
        '
        Me.rdbFletesPersonal.AutoSize = True
        Me.rdbFletesPersonal.Location = New System.Drawing.Point(9, 231)
        Me.rdbFletesPersonal.Name = "rdbFletesPersonal"
        Me.rdbFletesPersonal.Size = New System.Drawing.Size(96, 17)
        Me.rdbFletesPersonal.TabIndex = 396
        Me.rdbFletesPersonal.Text = "Fletes personal"
        Me.rdbFletesPersonal.UseVisualStyleBackColor = True
        '
        'rdbFirma
        '
        Me.rdbFirma.AutoSize = True
        Me.rdbFirma.Location = New System.Drawing.Point(10, 208)
        Me.rdbFirma.Name = "rdbFirma"
        Me.rdbFirma.Size = New System.Drawing.Size(89, 17)
        Me.rdbFirma.TabIndex = 395
        Me.rdbFirma.Text = "Listado firmas"
        Me.rdbFirma.UseVisualStyleBackColor = True
        '
        'rdbEmisionCosto
        '
        Me.rdbEmisionCosto.AutoSize = True
        Me.rdbEmisionCosto.Location = New System.Drawing.Point(10, 54)
        Me.rdbEmisionCosto.Name = "rdbEmisionCosto"
        Me.rdbEmisionCosto.Size = New System.Drawing.Size(110, 17)
        Me.rdbEmisionCosto.TabIndex = 394
        Me.rdbEmisionCosto.Text = "Emisión de costos"
        Me.rdbEmisionCosto.UseVisualStyleBackColor = True
        '
        'rdbCostosPresupuestos
        '
        Me.rdbCostosPresupuestos.AutoSize = True
        Me.rdbCostosPresupuestos.Location = New System.Drawing.Point(143, 54)
        Me.rdbCostosPresupuestos.Name = "rdbCostosPresupuestos"
        Me.rdbCostosPresupuestos.Size = New System.Drawing.Size(144, 17)
        Me.rdbCostosPresupuestos.TabIndex = 393
        Me.rdbCostosPresupuestos.Text = "Costos con presupuestos"
        Me.rdbCostosPresupuestos.UseVisualStyleBackColor = True
        '
        'RdbNominaPuntoPago
        '
        Me.RdbNominaPuntoPago.AutoSize = True
        Me.RdbNominaPuntoPago.Checked = True
        Me.RdbNominaPuntoPago.Location = New System.Drawing.Point(10, 16)
        Me.RdbNominaPuntoPago.Name = "RdbNominaPuntoPago"
        Me.RdbNominaPuntoPago.Size = New System.Drawing.Size(151, 17)
        Me.RdbNominaPuntoPago.TabIndex = 0
        Me.RdbNominaPuntoPago.TabStop = True
        Me.RdbNominaPuntoPago.Text = "Nómina por punto de pago"
        Me.RdbNominaPuntoPago.UseVisualStyleBackColor = True
        '
        'rdbMultiPuntoPagos
        '
        Me.rdbMultiPuntoPagos.AutoSize = True
        Me.rdbMultiPuntoPagos.Location = New System.Drawing.Point(10, 128)
        Me.rdbMultiPuntoPagos.Name = "rdbMultiPuntoPagos"
        Me.rdbMultiPuntoPagos.Size = New System.Drawing.Size(124, 17)
        Me.rdbMultiPuntoPagos.TabIndex = 392
        Me.rdbMultiPuntoPagos.Text = "Multi puntos de pago"
        Me.rdbMultiPuntoPagos.UseVisualStyleBackColor = True
        '
        'rdbCostos
        '
        Me.rdbCostos.AutoSize = True
        Me.rdbCostos.Location = New System.Drawing.Point(10, 35)
        Me.rdbCostos.Name = "rdbCostos"
        Me.rdbCostos.Size = New System.Drawing.Size(141, 17)
        Me.rdbCostos.TabIndex = 1
        Me.rdbCostos.Text = "Emisión de costos (viejo)"
        Me.rdbCostos.UseVisualStyleBackColor = True
        '
        'lblDisplayPuntoPago
        '
        Me.lblDisplayPuntoPago.AutoSize = True
        Me.lblDisplayPuntoPago.Location = New System.Drawing.Point(45, 93)
        Me.lblDisplayPuntoPago.Name = "lblDisplayPuntoPago"
        Me.lblDisplayPuntoPago.Size = New System.Drawing.Size(83, 13)
        Me.lblDisplayPuntoPago.TabIndex = 0
        Me.lblDisplayPuntoPago.Text = "Punto de pago :"
        '
        'cboTipoPago
        '
        Me.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPago.FormattingEnabled = True
        Me.cboTipoPago.Location = New System.Drawing.Point(134, 111)
        Me.cboTipoPago.Name = "cboTipoPago"
        Me.cboTipoPago.Size = New System.Drawing.Size(149, 21)
        Me.cboTipoPago.TabIndex = 4
        Me.cboTipoPago.Visible = False
        '
        'btnImprimirReporte
        '
        Me.btnImprimirReporte.Location = New System.Drawing.Point(134, 178)
        Me.btnImprimirReporte.Name = "btnImprimirReporte"
        Me.btnImprimirReporte.Size = New System.Drawing.Size(149, 30)
        Me.btnImprimirReporte.TabIndex = 8
        Me.btnImprimirReporte.Text = "Imprimir"
        Me.btnImprimirReporte.UseVisualStyleBackColor = True
        '
        'cboPuntoPago
        '
        Me.cboPuntoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuntoPago.FormattingEnabled = True
        Me.cboPuntoPago.Location = New System.Drawing.Point(134, 85)
        Me.cboPuntoPago.Name = "cboPuntoPago"
        Me.cboPuntoPago.Size = New System.Drawing.Size(149, 21)
        Me.cboPuntoPago.TabIndex = 3
        '
        'RdbDeducciones
        '
        Me.RdbDeducciones.AutoSize = True
        Me.RdbDeducciones.Location = New System.Drawing.Point(10, 185)
        Me.RdbDeducciones.Name = "RdbDeducciones"
        Me.RdbDeducciones.Size = New System.Drawing.Size(88, 17)
        Me.RdbDeducciones.TabIndex = 7
        Me.RdbDeducciones.Text = "Deducciones"
        Me.RdbDeducciones.UseVisualStyleBackColor = True
        '
        'lblDisplayTipoPago
        '
        Me.lblDisplayTipoPago.AutoSize = True
        Me.lblDisplayTipoPago.Location = New System.Drawing.Point(45, 111)
        Me.lblDisplayTipoPago.Name = "lblDisplayTipoPago"
        Me.lblDisplayTipoPago.Size = New System.Drawing.Size(53, 13)
        Me.lblDisplayTipoPago.TabIndex = 390
        Me.lblDisplayTipoPago.Text = "Pago en :"
        Me.lblDisplayTipoPago.Visible = False
        '
        'RdbTotales
        '
        Me.RdbTotales.AutoSize = True
        Me.RdbTotales.Location = New System.Drawing.Point(10, 166)
        Me.RdbTotales.Name = "RdbTotales"
        Me.RdbTotales.Size = New System.Drawing.Size(60, 17)
        Me.RdbTotales.TabIndex = 6
        Me.RdbTotales.Text = "Totales"
        Me.RdbTotales.UseVisualStyleBackColor = True
        '
        'rdbSobres
        '
        Me.rdbSobres.AutoSize = True
        Me.rdbSobres.Location = New System.Drawing.Point(10, 73)
        Me.rdbSobres.Name = "rdbSobres"
        Me.rdbSobres.Size = New System.Drawing.Size(58, 17)
        Me.rdbSobres.TabIndex = 2
        Me.rdbSobres.Text = "Sobres"
        Me.rdbSobres.UseVisualStyleBackColor = True
        '
        'RdbDistribucionEfectivo
        '
        Me.RdbDistribucionEfectivo.AutoSize = True
        Me.RdbDistribucionEfectivo.Location = New System.Drawing.Point(10, 147)
        Me.RdbDistribucionEfectivo.Name = "RdbDistribucionEfectivo"
        Me.RdbDistribucionEfectivo.Size = New System.Drawing.Size(136, 17)
        Me.RdbDistribucionEfectivo.TabIndex = 5
        Me.RdbDistribucionEfectivo.Text = "Distribución de efectivo"
        Me.RdbDistribucionEfectivo.UseVisualStyleBackColor = True
        '
        'BtnDispersion
        '
        Me.BtnDispersion.Location = New System.Drawing.Point(6, 479)
        Me.BtnDispersion.Name = "BtnDispersion"
        Me.BtnDispersion.Size = New System.Drawing.Size(150, 25)
        Me.BtnDispersion.TabIndex = 8
        Me.BtnDispersion.Text = "Dispersión"
        Me.BtnDispersion.UseVisualStyleBackColor = True
        '
        'btnImprimirAlta
        '
        Me.btnImprimirAlta.Location = New System.Drawing.Point(6, 447)
        Me.btnImprimirAlta.Name = "btnImprimirAlta"
        Me.btnImprimirAlta.Size = New System.Drawing.Size(150, 25)
        Me.btnImprimirAlta.TabIndex = 7
        Me.btnImprimirAlta.Text = "Generar alta de tarjetas"
        Me.btnImprimirAlta.UseVisualStyleBackColor = True
        '
        'btnPrenomina
        '
        Me.btnPrenomina.Location = New System.Drawing.Point(5, 322)
        Me.btnPrenomina.Name = "btnPrenomina"
        Me.btnPrenomina.Size = New System.Drawing.Size(150, 25)
        Me.btnPrenomina.TabIndex = 5
        Me.btnPrenomina.Text = "Ver reporte de prenómina *"
        Me.btnPrenomina.UseVisualStyleBackColor = True
        '
        'btnGeneraNomina
        '
        Me.btnGeneraNomina.Location = New System.Drawing.Point(6, 376)
        Me.btnGeneraNomina.Name = "btnGeneraNomina"
        Me.btnGeneraNomina.Size = New System.Drawing.Size(150, 25)
        Me.btnGeneraNomina.TabIndex = 6
        Me.btnGeneraNomina.Text = "Generar nómina"
        Me.btnGeneraNomina.UseVisualStyleBackColor = True
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(11, 581)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(10, 13)
        Me.lblEstatus.TabIndex = 381
        Me.lblEstatus.Text = "."
        '
        'lblDisplayEstatusNomina
        '
        Me.lblDisplayEstatusNomina.AutoSize = True
        Me.lblDisplayEstatusNomina.Location = New System.Drawing.Point(6, 562)
        Me.lblDisplayEstatusNomina.Name = "lblDisplayEstatusNomina"
        Me.lblDisplayEstatusNomina.Size = New System.Drawing.Size(111, 13)
        Me.lblDisplayEstatusNomina.TabIndex = 380
        Me.lblDisplayEstatusNomina.Text = "Estatus de la nómina :"
        '
        'lblDisplayFechaAl
        '
        Me.lblDisplayFechaAl.AutoSize = True
        Me.lblDisplayFechaAl.Location = New System.Drawing.Point(317, 49)
        Me.lblDisplayFechaAl.Name = "lblDisplayFechaAl"
        Me.lblDisplayFechaAl.Size = New System.Drawing.Size(22, 13)
        Me.lblDisplayFechaAl.TabIndex = 379
        Me.lblDisplayFechaAl.Text = "Al :"
        '
        'lblDisplayFechaDel
        '
        Me.lblDisplayFechaDel.AutoSize = True
        Me.lblDisplayFechaDel.Location = New System.Drawing.Point(317, 25)
        Me.lblDisplayFechaDel.Name = "lblDisplayFechaDel"
        Me.lblDisplayFechaDel.Size = New System.Drawing.Size(29, 13)
        Me.lblDisplayFechaDel.TabIndex = 378
        Me.lblDisplayFechaDel.Text = "Del :"
        '
        'txtTotalJornales
        '
        Me.txtTotalJornales.Enabled = False
        Me.txtTotalJornales.Location = New System.Drawing.Point(358, 286)
        Me.txtTotalJornales.Name = "txtTotalJornales"
        Me.txtTotalJornales.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalJornales.TabIndex = 377
        Me.txtTotalJornales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalImporte
        '
        Me.txtTotalImporte.Enabled = False
        Me.txtTotalImporte.Location = New System.Drawing.Point(253, 286)
        Me.txtTotalImporte.Name = "txtTotalImporte"
        Me.txtTotalImporte.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalImporte.TabIndex = 376
        Me.txtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(189, 289)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTotales.TabIndex = 375
        Me.lblDisplayTotales.Text = "Totales :"
        '
        'lblDisplayNota
        '
        Me.lblDisplayNota.Location = New System.Drawing.Point(11, 346)
        Me.lblDisplayNota.Name = "lblDisplayNota"
        Me.lblDisplayNota.Size = New System.Drawing.Size(143, 26)
        Me.lblDisplayNota.TabIndex = 384
        Me.lblDisplayNota.Text = "*La prenómina no incluye deducciones"
        '
        'lblIDSemana
        '
        Me.lblIDSemana.AutoSize = True
        Me.lblIDSemana.Enabled = False
        Me.lblIDSemana.Location = New System.Drawing.Point(84, 293)
        Me.lblIDSemana.Name = "lblIDSemana"
        Me.lblIDSemana.Size = New System.Drawing.Size(13, 13)
        Me.lblIDSemana.TabIndex = 402
        Me.lblIDSemana.Text = "_"
        '
        'lblDisplayIDSemana
        '
        Me.lblDisplayIDSemana.AutoSize = True
        Me.lblDisplayIDSemana.Enabled = False
        Me.lblDisplayIDSemana.Location = New System.Drawing.Point(15, 293)
        Me.lblDisplayIDSemana.Name = "lblDisplayIDSemana"
        Me.lblDisplayIDSemana.Size = New System.Drawing.Size(63, 13)
        Me.lblDisplayIDSemana.TabIndex = 401
        Me.lblDisplayIDSemana.Text = "IDSemana :"
        '
        'Frm_Nomina_CapturaPercepciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 639)
        Me.Controls.Add(Me.gbSemanas)
        Me.Controls.Add(Me.frame2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_CapturaPercepciones"
        Me.Text = "Nómina percepciones"
        Me.frame2.ResumeLayout(False)
        Me.frame2.PerformLayout()
        Me.gbSemanas.ResumeLayout(False)
        Me.gbSemanas.PerformLayout()
        Me.gbReportes.ResumeLayout(False)
        Me.gbReportes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frame2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregaHoja As System.Windows.Forms.Button
    Friend WithEvents lblDisplayTemporada As System.Windows.Forms.Label
    Friend WithEvents lblTemporadaPlaza As System.Windows.Forms.Label
    Friend WithEvents DtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboSemana As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayProductor As System.Windows.Forms.Label
    Friend WithEvents btnSemanaSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnSemanaAnterior As System.Windows.Forms.Button
    Friend WithEvents GridDia As FlexCell.Grid
    Friend WithEvents GridSemana As FlexCell.Grid
    Friend WithEvents gbSemanas As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalJornales As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalImporte As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaAl As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFechaDel As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayEstatusNomina As System.Windows.Forms.Label
    Friend WithEvents lblDisplayNota As System.Windows.Forms.Label
    Friend WithEvents btnPrenomina As System.Windows.Forms.Button
    Friend WithEvents btnGeneraNomina As System.Windows.Forms.Button
    Friend WithEvents btnImprimirAlta As System.Windows.Forms.Button
    Friend WithEvents BtnDispersion As System.Windows.Forms.Button
    Friend WithEvents gbReportes As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayPuntoPago As System.Windows.Forms.Label
    Friend WithEvents RdbNominaPuntoPago As System.Windows.Forms.RadioButton
    Friend WithEvents RdbDeducciones As System.Windows.Forms.RadioButton
    Friend WithEvents RdbTotales As System.Windows.Forms.RadioButton
    Friend WithEvents RdbDistribucionEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents cboPuntoPago As System.Windows.Forms.ComboBox
    Friend WithEvents btnImprimirReporte As System.Windows.Forms.Button
    Friend WithEvents rdbSobres As System.Windows.Forms.RadioButton
    Friend WithEvents cboTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTipoPago As System.Windows.Forms.Label
    Friend WithEvents rdbCostos As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMultiPuntoPagos As System.Windows.Forms.RadioButton
    Friend WithEvents txtConsecutivo As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayConsecutivo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRango As System.Windows.Forms.Label
    Friend WithEvents txtRango As System.Windows.Forms.TextBox
    Friend WithEvents btnGeneraPoliza As System.Windows.Forms.Button
    Friend WithEvents rdbCostosPresupuestos As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEmisionCosto As System.Windows.Forms.RadioButton
    Friend WithEvents btnImprimirListadoDiaPorCentroCosto As System.Windows.Forms.Button
    Friend WithEvents rdbFirma As System.Windows.Forms.RadioButton
    Friend WithEvents btnImprimirListadoDiaPorLote As System.Windows.Forms.Button
    Friend WithEvents txtImporteFlete As System.Windows.Forms.TextBox
    Friend WithEvents rdbFletesPersonal As System.Windows.Forms.RadioButton
    Friend WithEvents RdbReporteRangoFechas As System.Windows.Forms.RadioButton
    Friend WithEvents RdbReporteDia As System.Windows.Forms.RadioButton
    Friend WithEvents dtFecha2_Reporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFecha1_Reporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnImprimirRendimientoCorte As System.Windows.Forms.Button
    Friend WithEvents RdbReporteSemana As System.Windows.Forms.RadioButton
    Friend WithEvents lblIDSemana As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIDSemana As System.Windows.Forms.Label
End Class
