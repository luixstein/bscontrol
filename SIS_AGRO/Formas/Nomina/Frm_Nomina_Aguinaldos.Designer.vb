<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_Aguinaldos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_Aguinaldos))
        Me.gbTemporada = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblIdPrestacionGlobal = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboPuntoPago1 = New System.Windows.Forms.ComboBox
        Me.gbReportes = New System.Windows.Forms.GroupBox
        Me.rdbSobres = New System.Windows.Forms.RadioButton
        Me.RdbNominaPuntoPago = New System.Windows.Forms.RadioButton
        Me.lblDisplayPuntoPago = New System.Windows.Forms.Label
        Me.btnImprimirReporte = New System.Windows.Forms.Button
        Me.cboPuntoPago = New System.Windows.Forms.ComboBox
        Me.RdbDistribucionEfectivo = New System.Windows.Forms.RadioButton
        Me.txtFactor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DtpFechaFinSemana2 = New System.Windows.Forms.DateTimePicker
        Me.DtpFechaInicioSemana2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.CboSemana1 = New System.Windows.Forms.ComboBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.lblDisplayFechaAl = New System.Windows.Forms.Label
        Me.txtTotalImporte = New System.Windows.Forms.TextBox
        Me.lblDisplayTotal = New System.Windows.Forms.Label
        Me.GridResumenTemporada = New FlexCell.Grid
        Me.lblDisplayTemporada = New System.Windows.Forms.Label
        Me.DtpFechaFinSemana1 = New System.Windows.Forms.DateTimePicker
        Me.lblTemporadaPlaza = New System.Windows.Forms.Label
        Me.DtpFechaInicioSemana1 = New System.Windows.Forms.DateTimePicker
        Me.lblDisplayProductor = New System.Windows.Forms.Label
        Me.CboSemana2 = New System.Windows.Forms.ComboBox
        Me.gbHojas = New System.Windows.Forms.GroupBox
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.txtCodigoTrabajador = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtTotalTrabajadores = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GridTrabajadores = New FlexCell.Grid
        Me.gbTemporada.SuspendLayout()
        Me.gbReportes.SuspendLayout()
        Me.gbHojas.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTemporada
        '
        Me.gbTemporada.Controls.Add(Me.Label6)
        Me.gbTemporada.Controls.Add(Me.lblIdPrestacionGlobal)
        Me.gbTemporada.Controls.Add(Me.Label4)
        Me.gbTemporada.Controls.Add(Me.cboPuntoPago1)
        Me.gbTemporada.Controls.Add(Me.gbReportes)
        Me.gbTemporada.Controls.Add(Me.txtFactor)
        Me.gbTemporada.Controls.Add(Me.Label3)
        Me.gbTemporada.Controls.Add(Me.Label2)
        Me.gbTemporada.Controls.Add(Me.DtpFechaFinSemana2)
        Me.gbTemporada.Controls.Add(Me.DtpFechaInicioSemana2)
        Me.gbTemporada.Controls.Add(Me.Label1)
        Me.gbTemporada.Controls.Add(Me.CboSemana1)
        Me.gbTemporada.Controls.Add(Me.btnGenerar)
        Me.gbTemporada.Controls.Add(Me.btnGrabar)
        Me.gbTemporada.Controls.Add(Me.lblDisplayFechaAl)
        Me.gbTemporada.Controls.Add(Me.txtTotalImporte)
        Me.gbTemporada.Controls.Add(Me.lblDisplayTotal)
        Me.gbTemporada.Controls.Add(Me.GridResumenTemporada)
        Me.gbTemporada.Controls.Add(Me.lblDisplayTemporada)
        Me.gbTemporada.Controls.Add(Me.DtpFechaFinSemana1)
        Me.gbTemporada.Controls.Add(Me.lblTemporadaPlaza)
        Me.gbTemporada.Controls.Add(Me.DtpFechaInicioSemana1)
        Me.gbTemporada.Controls.Add(Me.lblDisplayProductor)
        Me.gbTemporada.Controls.Add(Me.CboSemana2)
        Me.gbTemporada.Location = New System.Drawing.Point(12, 12)
        Me.gbTemporada.Name = "gbTemporada"
        Me.gbTemporada.Size = New System.Drawing.Size(414, 573)
        Me.gbTemporada.TabIndex = 2
        Me.gbTemporada.TabStop = False
        Me.gbTemporada.Text = "Resumen temporada"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 390
        Me.Label6.Text = "A"
        '
        'lblIdPrestacionGlobal
        '
        Me.lblIdPrestacionGlobal.AutoSize = True
        Me.lblIdPrestacionGlobal.Location = New System.Drawing.Point(348, 380)
        Me.lblIdPrestacionGlobal.Name = "lblIdPrestacionGlobal"
        Me.lblIdPrestacionGlobal.Size = New System.Drawing.Size(10, 13)
        Me.lblIdPrestacionGlobal.TabIndex = 389
        Me.lblIdPrestacionGlobal.Text = "."
        Me.lblIdPrestacionGlobal.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 387
        Me.Label4.Text = "Punto de pago :"
        '
        'cboPuntoPago1
        '
        Me.cboPuntoPago1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuntoPago1.FormattingEnabled = True
        Me.cboPuntoPago1.Location = New System.Drawing.Point(94, 156)
        Me.cboPuntoPago1.Name = "cboPuntoPago1"
        Me.cboPuntoPago1.Size = New System.Drawing.Size(149, 21)
        Me.cboPuntoPago1.TabIndex = 388
        '
        'gbReportes
        '
        Me.gbReportes.Controls.Add(Me.rdbSobres)
        Me.gbReportes.Controls.Add(Me.RdbNominaPuntoPago)
        Me.gbReportes.Controls.Add(Me.lblDisplayPuntoPago)
        Me.gbReportes.Controls.Add(Me.btnImprimirReporte)
        Me.gbReportes.Controls.Add(Me.cboPuntoPago)
        Me.gbReportes.Controls.Add(Me.RdbDistribucionEfectivo)
        Me.gbReportes.Location = New System.Drawing.Point(14, 379)
        Me.gbReportes.Name = "gbReportes"
        Me.gbReportes.Size = New System.Drawing.Size(273, 158)
        Me.gbReportes.TabIndex = 9
        Me.gbReportes.TabStop = False
        Me.gbReportes.Text = "Reportes"
        '
        'rdbSobres
        '
        Me.rdbSobres.AutoSize = True
        Me.rdbSobres.Location = New System.Drawing.Point(14, 40)
        Me.rdbSobres.Name = "rdbSobres"
        Me.rdbSobres.Size = New System.Drawing.Size(58, 17)
        Me.rdbSobres.TabIndex = 9
        Me.rdbSobres.Text = "Sobres"
        Me.rdbSobres.UseVisualStyleBackColor = True
        '
        'RdbNominaPuntoPago
        '
        Me.RdbNominaPuntoPago.AutoSize = True
        Me.RdbNominaPuntoPago.Checked = True
        Me.RdbNominaPuntoPago.Location = New System.Drawing.Point(14, 17)
        Me.RdbNominaPuntoPago.Name = "RdbNominaPuntoPago"
        Me.RdbNominaPuntoPago.Size = New System.Drawing.Size(151, 17)
        Me.RdbNominaPuntoPago.TabIndex = 0
        Me.RdbNominaPuntoPago.TabStop = True
        Me.RdbNominaPuntoPago.Text = "Nómina por punto de pago"
        Me.RdbNominaPuntoPago.UseVisualStyleBackColor = True
        '
        'lblDisplayPuntoPago
        '
        Me.lblDisplayPuntoPago.AutoSize = True
        Me.lblDisplayPuntoPago.Location = New System.Drawing.Point(35, 62)
        Me.lblDisplayPuntoPago.Name = "lblDisplayPuntoPago"
        Me.lblDisplayPuntoPago.Size = New System.Drawing.Size(83, 13)
        Me.lblDisplayPuntoPago.TabIndex = 0
        Me.lblDisplayPuntoPago.Text = "Punto de pago :"
        '
        'btnImprimirReporte
        '
        Me.btnImprimirReporte.Location = New System.Drawing.Point(118, 121)
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
        Me.cboPuntoPago.Location = New System.Drawing.Point(118, 62)
        Me.cboPuntoPago.Name = "cboPuntoPago"
        Me.cboPuntoPago.Size = New System.Drawing.Size(149, 21)
        Me.cboPuntoPago.TabIndex = 3
        '
        'RdbDistribucionEfectivo
        '
        Me.RdbDistribucionEfectivo.AutoSize = True
        Me.RdbDistribucionEfectivo.Location = New System.Drawing.Point(14, 89)
        Me.RdbDistribucionEfectivo.Name = "RdbDistribucionEfectivo"
        Me.RdbDistribucionEfectivo.Size = New System.Drawing.Size(136, 17)
        Me.RdbDistribucionEfectivo.TabIndex = 5
        Me.RdbDistribucionEfectivo.Text = "Distribución de efectivo"
        Me.RdbDistribucionEfectivo.UseVisualStyleBackColor = True
        '
        'txtFactor
        '
        Me.txtFactor.Location = New System.Drawing.Point(94, 129)
        Me.txtFactor.MaxLength = 25
        Me.txtFactor.Name = "txtFactor"
        Me.txtFactor.Size = New System.Drawing.Size(100, 20)
        Me.txtFactor.TabIndex = 386
        Me.txtFactor.Text = "4.0875"
        Me.txtFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 385
        Me.Label3.Text = "Factor :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(275, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 384
        Me.Label2.Text = "Al :"
        '
        'DtpFechaFinSemana2
        '
        Me.DtpFechaFinSemana2.CustomFormat = "dd-MMM-yy"
        Me.DtpFechaFinSemana2.Enabled = False
        Me.DtpFechaFinSemana2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFinSemana2.Location = New System.Drawing.Point(303, 102)
        Me.DtpFechaFinSemana2.Name = "DtpFechaFinSemana2"
        Me.DtpFechaFinSemana2.Size = New System.Drawing.Size(100, 20)
        Me.DtpFechaFinSemana2.TabIndex = 383
        '
        'DtpFechaInicioSemana2
        '
        Me.DtpFechaInicioSemana2.CustomFormat = "dd-MMM-yy"
        Me.DtpFechaInicioSemana2.Enabled = False
        Me.DtpFechaInicioSemana2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicioSemana2.Location = New System.Drawing.Point(168, 102)
        Me.DtpFechaInicioSemana2.Name = "DtpFechaInicioSemana2"
        Me.DtpFechaInicioSemana2.Size = New System.Drawing.Size(100, 20)
        Me.DtpFechaInicioSemana2.TabIndex = 382
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 381
        Me.Label1.Text = "Semana :"
        '
        'CboSemana1
        '
        Me.CboSemana1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana1.FormattingEnabled = True
        Me.CboSemana1.Location = New System.Drawing.Point(94, 48)
        Me.CboSemana1.Name = "CboSemana1"
        Me.CboSemana1.Size = New System.Drawing.Size(50, 21)
        Me.CboSemana1.TabIndex = 380
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(293, 191)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(115, 24)
        Me.btnGenerar.TabIndex = 7
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(293, 217)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(115, 24)
        Me.btnGrabar.TabIndex = 6
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'lblDisplayFechaAl
        '
        Me.lblDisplayFechaAl.AutoSize = True
        Me.lblDisplayFechaAl.Location = New System.Drawing.Point(275, 54)
        Me.lblDisplayFechaAl.Name = "lblDisplayFechaAl"
        Me.lblDisplayFechaAl.Size = New System.Drawing.Size(22, 13)
        Me.lblDisplayFechaAl.TabIndex = 379
        Me.lblDisplayFechaAl.Text = "Al :"
        '
        'txtTotalImporte
        '
        Me.txtTotalImporte.Enabled = False
        Me.txtTotalImporte.Location = New System.Drawing.Point(164, 351)
        Me.txtTotalImporte.Name = "txtTotalImporte"
        Me.txtTotalImporte.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalImporte.TabIndex = 376
        Me.txtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotal
        '
        Me.lblDisplayTotal.AutoSize = True
        Me.lblDisplayTotal.Location = New System.Drawing.Point(112, 355)
        Me.lblDisplayTotal.Name = "lblDisplayTotal"
        Me.lblDisplayTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblDisplayTotal.TabIndex = 375
        Me.lblDisplayTotal.Text = "Total :"
        '
        'GridResumenTemporada
        '
        Me.GridResumenTemporada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridResumenTemporada.CheckedImage = CType(resources.GetObject("GridResumenTemporada.CheckedImage"), System.Drawing.Bitmap)
        Me.GridResumenTemporada.Cols = 1
        Me.GridResumenTemporada.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridResumenTemporada.DisplayRowNumber = True
        Me.GridResumenTemporada.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridResumenTemporada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridResumenTemporada.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridResumenTemporada.Location = New System.Drawing.Point(14, 191)
        Me.GridResumenTemporada.LockButton = True
        Me.GridResumenTemporada.Name = "GridResumenTemporada"
        Me.GridResumenTemporada.Rows = 8
        Me.GridResumenTemporada.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridResumenTemporada.Size = New System.Drawing.Size(273, 154)
        Me.GridResumenTemporada.TabIndex = 4
        Me.GridResumenTemporada.UncheckedImage = CType(resources.GetObject("GridResumenTemporada.UncheckedImage"), System.Drawing.Bitmap)
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
        'DtpFechaFinSemana1
        '
        Me.DtpFechaFinSemana1.CustomFormat = "dd-MMM-yy"
        Me.DtpFechaFinSemana1.Enabled = False
        Me.DtpFechaFinSemana1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFinSemana1.Location = New System.Drawing.Point(303, 48)
        Me.DtpFechaFinSemana1.Name = "DtpFechaFinSemana1"
        Me.DtpFechaFinSemana1.Size = New System.Drawing.Size(100, 20)
        Me.DtpFechaFinSemana1.TabIndex = 3
        '
        'lblTemporadaPlaza
        '
        Me.lblTemporadaPlaza.AutoSize = True
        Me.lblTemporadaPlaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemporadaPlaza.Location = New System.Drawing.Point(94, 24)
        Me.lblTemporadaPlaza.Name = "lblTemporadaPlaza"
        Me.lblTemporadaPlaza.Size = New System.Drawing.Size(12, 15)
        Me.lblTemporadaPlaza.TabIndex = 0
        Me.lblTemporadaPlaza.Text = "."
        '
        'DtpFechaInicioSemana1
        '
        Me.DtpFechaInicioSemana1.CustomFormat = "dd-MMM-yy"
        Me.DtpFechaInicioSemana1.Enabled = False
        Me.DtpFechaInicioSemana1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicioSemana1.Location = New System.Drawing.Point(168, 48)
        Me.DtpFechaInicioSemana1.Name = "DtpFechaInicioSemana1"
        Me.DtpFechaInicioSemana1.Size = New System.Drawing.Size(100, 20)
        Me.DtpFechaInicioSemana1.TabIndex = 2
        '
        'lblDisplayProductor
        '
        Me.lblDisplayProductor.AutoSize = True
        Me.lblDisplayProductor.Location = New System.Drawing.Point(11, 106)
        Me.lblDisplayProductor.Name = "lblDisplayProductor"
        Me.lblDisplayProductor.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplayProductor.TabIndex = 359
        Me.lblDisplayProductor.Text = "Semana :"
        '
        'CboSemana2
        '
        Me.CboSemana2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana2.FormattingEnabled = True
        Me.CboSemana2.Location = New System.Drawing.Point(94, 102)
        Me.CboSemana2.Name = "CboSemana2"
        Me.CboSemana2.Size = New System.Drawing.Size(50, 21)
        Me.CboSemana2.TabIndex = 1
        '
        'gbHojas
        '
        Me.gbHojas.Controls.Add(Me.btnAgregar)
        Me.gbHojas.Controls.Add(Me.txtCodigoTrabajador)
        Me.gbHojas.Controls.Add(Me.Label7)
        Me.gbHojas.Controls.Add(Me.TxtTotalTrabajadores)
        Me.gbHojas.Controls.Add(Me.Label5)
        Me.gbHojas.Controls.Add(Me.GridTrabajadores)
        Me.gbHojas.Location = New System.Drawing.Point(432, 12)
        Me.gbHojas.Name = "gbHojas"
        Me.gbHojas.Size = New System.Drawing.Size(587, 573)
        Me.gbHojas.TabIndex = 3
        Me.gbHojas.TabStop = False
        Me.gbHojas.Text = "Trabajadores"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(222, 543)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 393
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtCodigoTrabajador
        '
        Me.txtCodigoTrabajador.Location = New System.Drawing.Point(106, 545)
        Me.txtCodigoTrabajador.Name = "txtCodigoTrabajador"
        Me.txtCodigoTrabajador.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoTrabajador.TabIndex = 392
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 548)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 391
        Me.Label7.Text = "Cód. Trabajador :"
        '
        'TxtTotalTrabajadores
        '
        Me.TxtTotalTrabajadores.Enabled = False
        Me.TxtTotalTrabajadores.Location = New System.Drawing.Point(459, 543)
        Me.TxtTotalTrabajadores.Name = "TxtTotalTrabajadores"
        Me.TxtTotalTrabajadores.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalTrabajadores.TabIndex = 390
        Me.TxtTotalTrabajadores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(417, 547)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Total :"
        '
        'GridTrabajadores
        '
        Me.GridTrabajadores.AllowUserReorderColumn = True
        Me.GridTrabajadores.AllowUserSort = True
        Me.GridTrabajadores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridTrabajadores.CheckedImage = CType(resources.GetObject("GridTrabajadores.CheckedImage"), System.Drawing.Bitmap)
        Me.GridTrabajadores.Cols = 1
        Me.GridTrabajadores.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridTrabajadores.DisplayRowArrow = True
        Me.GridTrabajadores.DisplayRowNumber = True
        Me.GridTrabajadores.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridTrabajadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTrabajadores.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridTrabajadores.Location = New System.Drawing.Point(9, 17)
        Me.GridTrabajadores.LockButton = True
        Me.GridTrabajadores.Name = "GridTrabajadores"
        Me.GridTrabajadores.Rows = 8
        Me.GridTrabajadores.Size = New System.Drawing.Size(569, 520)
        Me.GridTrabajadores.TabIndex = 1
        Me.GridTrabajadores.UncheckedImage = CType(resources.GetObject("GridTrabajadores.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Frm_Nomina_Aguinaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1025, 591)
        Me.Controls.Add(Me.gbTemporada)
        Me.Controls.Add(Me.gbHojas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_Aguinaldos"
        Me.Text = "Nomina Aguinaldos"
        Me.gbTemporada.ResumeLayout(False)
        Me.gbTemporada.PerformLayout()
        Me.gbReportes.ResumeLayout(False)
        Me.gbReportes.PerformLayout()
        Me.gbHojas.ResumeLayout(False)
        Me.gbHojas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTemporada As System.Windows.Forms.GroupBox
    Friend WithEvents gbReportes As System.Windows.Forms.GroupBox
    Friend WithEvents RdbNominaPuntoPago As System.Windows.Forms.RadioButton
    Friend WithEvents lblDisplayPuntoPago As System.Windows.Forms.Label
    Friend WithEvents btnImprimirReporte As System.Windows.Forms.Button
    Friend WithEvents cboPuntoPago As System.Windows.Forms.ComboBox
    Friend WithEvents RdbDistribucionEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents lblDisplayFechaAl As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents GridResumenTemporada As FlexCell.Grid
    Friend WithEvents lblDisplayTemporada As System.Windows.Forms.Label
    Friend WithEvents DtpFechaFinSemana1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTemporadaPlaza As System.Windows.Forms.Label
    Friend WithEvents DtpFechaInicioSemana1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayProductor As System.Windows.Forms.Label
    Friend WithEvents CboSemana2 As System.Windows.Forms.ComboBox
    Friend WithEvents gbHojas As System.Windows.Forms.GroupBox
    Friend WithEvents GridTrabajadores As FlexCell.Grid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaFinSemana2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaInicioSemana2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboSemana1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPuntoPago1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtFactor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalImporte As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotalTrabajadores As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIdPrestacionGlobal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rdbSobres As System.Windows.Forms.RadioButton
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtCodigoTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
