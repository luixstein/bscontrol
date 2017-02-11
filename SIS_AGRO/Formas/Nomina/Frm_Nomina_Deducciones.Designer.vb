<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_Deducciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_Deducciones))
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbSaldar = New System.Windows.Forms.ToolStripButton
        Me.tsbEliminar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.gbHistorialDeducciones = New System.Windows.Forms.GroupBox
        Me.txtSumaSaldos = New System.Windows.Forms.TextBox
        Me.txtSumaImportes = New System.Windows.Forms.TextBox
        Me.lblDisplaySumaHistorial = New System.Windows.Forms.Label
        Me.GridHistorialDeducciones = New FlexCell.Grid
        Me.gbPlanAbonos = New System.Windows.Forms.GroupBox
        Me.btnExtenderTemporada = New System.Windows.Forms.Button
        Me.BtnRecorrerSemana = New System.Windows.Forms.Button
        Me.BtnBorrarSemana = New System.Windows.Forms.Button
        Me.BtnAgregarSemana = New System.Windows.Forms.Button
        Me.txtSuma = New System.Windows.Forms.TextBox
        Me.lblDisplaySumas = New System.Windows.Forms.Label
        Me.GridPlanAbonos = New FlexCell.Grid
        Me.gbGeneral = New System.Windows.Forms.GroupBox
        Me.gbDeducciones = New System.Windows.Forms.GroupBox
        Me.LblId_Percepcion = New System.Windows.Forms.Label
        Me.rdbSiguienteSemana = New System.Windows.Forms.RadioButton
        Me.rdbMismaSemana = New System.Windows.Forms.RadioButton
        Me.TxtSaldo = New System.Windows.Forms.TextBox
        Me.lblDisplaySaldo = New System.Windows.Forms.Label
        Me.TxtDescuento = New System.Windows.Forms.TextBox
        Me.lblDisplayDescuentoSemanal = New System.Windows.Forms.Label
        Me.TxtImporte = New System.Windows.Forms.TextBox
        Me.lblDisplayImporte = New System.Windows.Forms.Label
        Me.btnGeneraPlanAbonos = New System.Windows.Forms.Button
        Me.TxtConcepto = New System.Windows.Forms.TextBox
        Me.lblDisplayConcepto = New System.Windows.Forms.Label
        Me.cboTipoDeduccion = New System.Windows.Forms.ComboBox
        Me.lblDisplayTipo = New System.Windows.Forms.Label
        Me.DtpFecha2 = New System.Windows.Forms.DateTimePicker
        Me.DtpFecha1 = New System.Windows.Forms.DateTimePicker
        Me.CboSemana = New System.Windows.Forms.ComboBox
        Me.lblDisplaySemana = New System.Windows.Forms.Label
        Me.gbTrabajador = New System.Windows.Forms.GroupBox
        Me.lblNombreTrabajador = New System.Windows.Forms.Label
        Me.txtCodigoTrabajador = New System.Windows.Forms.TextBox
        Me.lblDisplayTrabajador = New System.Windows.Forms.Label
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel
        Me.GridTrabajadores = New FlexCell.Grid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalImportePrestaciones = New System.Windows.Forms.TextBox
        Me.txtTotalSaldoPrestaciones = New System.Windows.Forms.TextBox
        Me.lblDisplaySumaTotalPrestaciones = New System.Windows.Forms.Label
        Me.txtIdSemana = New System.Windows.Forms.TextBox
        Me.txtNumeroSemana = New System.Windows.Forms.TextBox
        Me.tsMenu.SuspendLayout()
        Me.gbHistorialDeducciones.SuspendLayout()
        Me.gbPlanAbonos.SuspendLayout()
        Me.gbGeneral.SuspendLayout()
        Me.gbDeducciones.SuspendLayout()
        Me.gbTrabajador.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSaldar, Me.tsbEliminar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1071, 25)
        Me.tsMenu.TabIndex = 4
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
        'tsbSaldar
        '
        Me.tsbSaldar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbSaldar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSaldar.Name = "tsbSaldar"
        Me.tsbSaldar.Size = New System.Drawing.Size(59, 22)
        Me.tsbSaldar.Text = "&Saldar"
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
        'gbHistorialDeducciones
        '
        Me.gbHistorialDeducciones.Controls.Add(Me.txtSumaSaldos)
        Me.gbHistorialDeducciones.Controls.Add(Me.txtSumaImportes)
        Me.gbHistorialDeducciones.Controls.Add(Me.lblDisplaySumaHistorial)
        Me.gbHistorialDeducciones.Controls.Add(Me.GridHistorialDeducciones)
        Me.gbHistorialDeducciones.Location = New System.Drawing.Point(300, 55)
        Me.gbHistorialDeducciones.Name = "gbHistorialDeducciones"
        Me.gbHistorialDeducciones.Size = New System.Drawing.Size(282, 214)
        Me.gbHistorialDeducciones.TabIndex = 3
        Me.gbHistorialDeducciones.TabStop = False
        Me.gbHistorialDeducciones.Text = "Historial de deducciones :"
        '
        'txtSumaSaldos
        '
        Me.txtSumaSaldos.Enabled = False
        Me.txtSumaSaldos.Location = New System.Drawing.Point(162, 187)
        Me.txtSumaSaldos.Name = "txtSumaSaldos"
        Me.txtSumaSaldos.Size = New System.Drawing.Size(99, 20)
        Me.txtSumaSaldos.TabIndex = 383
        Me.txtSumaSaldos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSumaImportes
        '
        Me.txtSumaImportes.Enabled = False
        Me.txtSumaImportes.Location = New System.Drawing.Point(57, 187)
        Me.txtSumaImportes.Name = "txtSumaImportes"
        Me.txtSumaImportes.Size = New System.Drawing.Size(99, 20)
        Me.txtSumaImportes.TabIndex = 382
        Me.txtSumaImportes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySumaHistorial
        '
        Me.lblDisplaySumaHistorial.AutoSize = True
        Me.lblDisplaySumaHistorial.Cursor = System.Windows.Forms.Cursors.Cross
        Me.lblDisplaySumaHistorial.Location = New System.Drawing.Point(6, 190)
        Me.lblDisplaySumaHistorial.Name = "lblDisplaySumaHistorial"
        Me.lblDisplaySumaHistorial.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplaySumaHistorial.TabIndex = 10
        Me.lblDisplaySumaHistorial.Text = "Sumas :"
        '
        'GridHistorialDeducciones
        '
        Me.GridHistorialDeducciones.CheckedImage = CType(resources.GetObject("GridHistorialDeducciones.CheckedImage"), System.Drawing.Bitmap)
        Me.GridHistorialDeducciones.Cols = 2
        Me.GridHistorialDeducciones.DisplayRowNumber = True
        Me.GridHistorialDeducciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridHistorialDeducciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridHistorialDeducciones.Location = New System.Drawing.Point(11, 19)
        Me.GridHistorialDeducciones.Name = "GridHistorialDeducciones"
        Me.GridHistorialDeducciones.Rows = 2
        Me.GridHistorialDeducciones.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridHistorialDeducciones.Size = New System.Drawing.Size(263, 158)
        Me.GridHistorialDeducciones.TabIndex = 0
        Me.GridHistorialDeducciones.UncheckedImage = CType(resources.GetObject("GridHistorialDeducciones.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbPlanAbonos
        '
        Me.gbPlanAbonos.Controls.Add(Me.btnExtenderTemporada)
        Me.gbPlanAbonos.Controls.Add(Me.BtnRecorrerSemana)
        Me.gbPlanAbonos.Controls.Add(Me.BtnBorrarSemana)
        Me.gbPlanAbonos.Controls.Add(Me.BtnAgregarSemana)
        Me.gbPlanAbonos.Controls.Add(Me.txtSuma)
        Me.gbPlanAbonos.Controls.Add(Me.lblDisplaySumas)
        Me.gbPlanAbonos.Controls.Add(Me.GridPlanAbonos)
        Me.gbPlanAbonos.Location = New System.Drawing.Point(6, 275)
        Me.gbPlanAbonos.Name = "gbPlanAbonos"
        Me.gbPlanAbonos.Size = New System.Drawing.Size(574, 335)
        Me.gbPlanAbonos.TabIndex = 2
        Me.gbPlanAbonos.TabStop = False
        Me.gbPlanAbonos.Text = "Plan de abonos :"
        '
        'btnExtenderTemporada
        '
        Me.btnExtenderTemporada.Location = New System.Drawing.Point(411, 141)
        Me.btnExtenderTemporada.Name = "btnExtenderTemporada"
        Me.btnExtenderTemporada.Size = New System.Drawing.Size(157, 27)
        Me.btnExtenderTemporada.TabIndex = 397
        Me.btnExtenderTemporada.Text = "Extender a sig. temporada"
        Me.btnExtenderTemporada.UseVisualStyleBackColor = True
        '
        'BtnRecorrerSemana
        '
        Me.BtnRecorrerSemana.Location = New System.Drawing.Point(411, 108)
        Me.BtnRecorrerSemana.Name = "BtnRecorrerSemana"
        Me.BtnRecorrerSemana.Size = New System.Drawing.Size(157, 27)
        Me.BtnRecorrerSemana.TabIndex = 396
        Me.BtnRecorrerSemana.Text = "Recorrer semana"
        Me.BtnRecorrerSemana.UseVisualStyleBackColor = True
        '
        'BtnBorrarSemana
        '
        Me.BtnBorrarSemana.Location = New System.Drawing.Point(411, 76)
        Me.BtnBorrarSemana.Name = "BtnBorrarSemana"
        Me.BtnBorrarSemana.Size = New System.Drawing.Size(157, 27)
        Me.BtnBorrarSemana.TabIndex = 395
        Me.BtnBorrarSemana.Text = "Borrar última semana"
        Me.BtnBorrarSemana.UseVisualStyleBackColor = True
        '
        'BtnAgregarSemana
        '
        Me.BtnAgregarSemana.Location = New System.Drawing.Point(411, 44)
        Me.BtnAgregarSemana.Name = "BtnAgregarSemana"
        Me.BtnAgregarSemana.Size = New System.Drawing.Size(157, 27)
        Me.BtnAgregarSemana.TabIndex = 394
        Me.BtnAgregarSemana.Text = "Agregar otra Semana"
        Me.BtnAgregarSemana.UseVisualStyleBackColor = True
        '
        'txtSuma
        '
        Me.txtSuma.Enabled = False
        Me.txtSuma.Location = New System.Drawing.Point(120, 306)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(99, 20)
        Me.txtSuma.TabIndex = 382
        Me.txtSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySumas
        '
        Me.lblDisplaySumas.AutoSize = True
        Me.lblDisplaySumas.Location = New System.Drawing.Point(6, 309)
        Me.lblDisplaySumas.Name = "lblDisplaySumas"
        Me.lblDisplaySumas.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplaySumas.TabIndex = 9
        Me.lblDisplaySumas.Text = "Suma :"
        '
        'GridPlanAbonos
        '
        Me.GridPlanAbonos.CheckedImage = CType(resources.GetObject("GridPlanAbonos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridPlanAbonos.Cols = 2
        Me.GridPlanAbonos.DisplayRowNumber = True
        Me.GridPlanAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPlanAbonos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridPlanAbonos.Location = New System.Drawing.Point(9, 24)
        Me.GridPlanAbonos.Name = "GridPlanAbonos"
        Me.GridPlanAbonos.Rows = 2
        Me.GridPlanAbonos.Size = New System.Drawing.Size(397, 276)
        Me.GridPlanAbonos.TabIndex = 0
        Me.GridPlanAbonos.UncheckedImage = CType(resources.GetObject("GridPlanAbonos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.gbDeducciones)
        Me.gbGeneral.Controls.Add(Me.gbTrabajador)
        Me.gbGeneral.Controls.Add(Me.gbHistorialDeducciones)
        Me.gbGeneral.Controls.Add(Me.gbPlanAbonos)
        Me.gbGeneral.Location = New System.Drawing.Point(8, 30)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(586, 624)
        Me.gbGeneral.TabIndex = 0
        Me.gbGeneral.TabStop = False
        '
        'gbDeducciones
        '
        Me.gbDeducciones.Controls.Add(Me.txtNumeroSemana)
        Me.gbDeducciones.Controls.Add(Me.txtIdSemana)
        Me.gbDeducciones.Controls.Add(Me.LblId_Percepcion)
        Me.gbDeducciones.Controls.Add(Me.rdbSiguienteSemana)
        Me.gbDeducciones.Controls.Add(Me.rdbMismaSemana)
        Me.gbDeducciones.Controls.Add(Me.TxtSaldo)
        Me.gbDeducciones.Controls.Add(Me.lblDisplaySaldo)
        Me.gbDeducciones.Controls.Add(Me.TxtDescuento)
        Me.gbDeducciones.Controls.Add(Me.lblDisplayDescuentoSemanal)
        Me.gbDeducciones.Controls.Add(Me.TxtImporte)
        Me.gbDeducciones.Controls.Add(Me.lblDisplayImporte)
        Me.gbDeducciones.Controls.Add(Me.btnGeneraPlanAbonos)
        Me.gbDeducciones.Controls.Add(Me.TxtConcepto)
        Me.gbDeducciones.Controls.Add(Me.lblDisplayConcepto)
        Me.gbDeducciones.Controls.Add(Me.cboTipoDeduccion)
        Me.gbDeducciones.Controls.Add(Me.lblDisplayTipo)
        Me.gbDeducciones.Controls.Add(Me.DtpFecha2)
        Me.gbDeducciones.Controls.Add(Me.DtpFecha1)
        Me.gbDeducciones.Controls.Add(Me.CboSemana)
        Me.gbDeducciones.Controls.Add(Me.lblDisplaySemana)
        Me.gbDeducciones.Location = New System.Drawing.Point(6, 52)
        Me.gbDeducciones.Name = "gbDeducciones"
        Me.gbDeducciones.Size = New System.Drawing.Size(288, 217)
        Me.gbDeducciones.TabIndex = 1
        Me.gbDeducciones.TabStop = False
        '
        'LblId_Percepcion
        '
        Me.LblId_Percepcion.AutoSize = True
        Me.LblId_Percepcion.Enabled = False
        Me.LblId_Percepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId_Percepcion.Location = New System.Drawing.Point(6, 160)
        Me.LblId_Percepcion.Name = "LblId_Percepcion"
        Me.LblId_Percepcion.Size = New System.Drawing.Size(14, 20)
        Me.LblId_Percepcion.TabIndex = 396
        Me.LblId_Percepcion.Text = "."
        Me.LblId_Percepcion.Visible = False
        '
        'rdbSiguienteSemana
        '
        Me.rdbSiguienteSemana.AutoSize = True
        Me.rdbSiguienteSemana.Checked = True
        Me.rdbSiguienteSemana.Location = New System.Drawing.Point(133, 163)
        Me.rdbSiguienteSemana.Name = "rdbSiguienteSemana"
        Me.rdbSiguienteSemana.Size = New System.Drawing.Size(109, 17)
        Me.rdbSiguienteSemana.TabIndex = 4
        Me.rdbSiguienteSemana.TabStop = True
        Me.rdbSiguienteSemana.Text = "Siguiente semana"
        Me.rdbSiguienteSemana.UseVisualStyleBackColor = True
        '
        'rdbMismaSemana
        '
        Me.rdbMismaSemana.AutoSize = True
        Me.rdbMismaSemana.Location = New System.Drawing.Point(41, 163)
        Me.rdbMismaSemana.Name = "rdbMismaSemana"
        Me.rdbMismaSemana.Size = New System.Drawing.Size(94, 17)
        Me.rdbMismaSemana.TabIndex = 391
        Me.rdbMismaSemana.Text = "MismaSemana"
        Me.rdbMismaSemana.UseVisualStyleBackColor = True
        '
        'TxtSaldo
        '
        Me.TxtSaldo.Enabled = False
        Me.TxtSaldo.Location = New System.Drawing.Point(120, 137)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.Size = New System.Drawing.Size(100, 20)
        Me.TxtSaldo.TabIndex = 390
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(5, 141)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplaySaldo.TabIndex = 389
        Me.lblDisplaySaldo.Text = "Saldo :"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Location = New System.Drawing.Point(120, 113)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(100, 20)
        Me.TxtDescuento.TabIndex = 6
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayDescuentoSemanal
        '
        Me.lblDisplayDescuentoSemanal.AutoSize = True
        Me.lblDisplayDescuentoSemanal.Location = New System.Drawing.Point(5, 117)
        Me.lblDisplayDescuentoSemanal.Name = "lblDisplayDescuentoSemanal"
        Me.lblDisplayDescuentoSemanal.Size = New System.Drawing.Size(110, 13)
        Me.lblDisplayDescuentoSemanal.TabIndex = 387
        Me.lblDisplayDescuentoSemanal.Text = "Descuento semanal  :"
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(120, 90)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(100, 20)
        Me.TxtImporte.TabIndex = 5
        Me.TxtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayImporte
        '
        Me.lblDisplayImporte.AutoSize = True
        Me.lblDisplayImporte.Location = New System.Drawing.Point(5, 93)
        Me.lblDisplayImporte.Name = "lblDisplayImporte"
        Me.lblDisplayImporte.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayImporte.TabIndex = 385
        Me.lblDisplayImporte.Text = "Importe :"
        '
        'btnGeneraPlanAbonos
        '
        Me.btnGeneraPlanAbonos.Location = New System.Drawing.Point(38, 185)
        Me.btnGeneraPlanAbonos.Name = "btnGeneraPlanAbonos"
        Me.btnGeneraPlanAbonos.Size = New System.Drawing.Size(204, 21)
        Me.btnGeneraPlanAbonos.TabIndex = 7
        Me.btnGeneraPlanAbonos.Text = "Genera plan de abonos"
        Me.btnGeneraPlanAbonos.UseVisualStyleBackColor = True
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(74, 64)
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(204, 20)
        Me.TxtConcepto.TabIndex = 3
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(5, 68)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayConcepto.TabIndex = 382
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'cboTipoDeduccion
        '
        Me.cboTipoDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDeduccion.FormattingEnabled = True
        Me.cboTipoDeduccion.Location = New System.Drawing.Point(74, 38)
        Me.cboTipoDeduccion.Name = "cboTipoDeduccion"
        Me.cboTipoDeduccion.Size = New System.Drawing.Size(204, 21)
        Me.cboTipoDeduccion.TabIndex = 2
        '
        'lblDisplayTipo
        '
        Me.lblDisplayTipo.AutoSize = True
        Me.lblDisplayTipo.Location = New System.Drawing.Point(5, 42)
        Me.lblDisplayTipo.Name = "lblDisplayTipo"
        Me.lblDisplayTipo.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayTipo.TabIndex = 380
        Me.lblDisplayTipo.Text = "Tipo :"
        '
        'DtpFecha2
        '
        Me.DtpFecha2.CustomFormat = "dd-MMM-yy"
        Me.DtpFecha2.Enabled = False
        Me.DtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha2.Location = New System.Drawing.Point(206, 13)
        Me.DtpFecha2.Name = "DtpFecha2"
        Me.DtpFecha2.Size = New System.Drawing.Size(72, 20)
        Me.DtpFecha2.TabIndex = 376
        '
        'DtpFecha1
        '
        Me.DtpFecha1.CustomFormat = "dd-MMM-yy"
        Me.DtpFecha1.Enabled = False
        Me.DtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha1.Location = New System.Drawing.Point(133, 13)
        Me.DtpFecha1.Name = "DtpFecha1"
        Me.DtpFecha1.Size = New System.Drawing.Size(72, 20)
        Me.DtpFecha1.TabIndex = 375
        '
        'CboSemana
        '
        Me.CboSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana.FormattingEnabled = True
        Me.CboSemana.Location = New System.Drawing.Point(74, 12)
        Me.CboSemana.Name = "CboSemana"
        Me.CboSemana.Size = New System.Drawing.Size(53, 21)
        Me.CboSemana.TabIndex = 1
        Me.CboSemana.Visible = False
        '
        'lblDisplaySemana
        '
        Me.lblDisplaySemana.AutoSize = True
        Me.lblDisplaySemana.Location = New System.Drawing.Point(5, 16)
        Me.lblDisplaySemana.Name = "lblDisplaySemana"
        Me.lblDisplaySemana.Size = New System.Drawing.Size(52, 13)
        Me.lblDisplaySemana.TabIndex = 0
        Me.lblDisplaySemana.Text = "Semana :"
        '
        'gbTrabajador
        '
        Me.gbTrabajador.Controls.Add(Me.lblNombreTrabajador)
        Me.gbTrabajador.Controls.Add(Me.txtCodigoTrabajador)
        Me.gbTrabajador.Controls.Add(Me.lblDisplayTrabajador)
        Me.gbTrabajador.Location = New System.Drawing.Point(6, 8)
        Me.gbTrabajador.Name = "gbTrabajador"
        Me.gbTrabajador.Size = New System.Drawing.Size(576, 41)
        Me.gbTrabajador.TabIndex = 0
        Me.gbTrabajador.TabStop = False
        '
        'lblNombreTrabajador
        '
        Me.lblNombreTrabajador.AutoSize = True
        Me.lblNombreTrabajador.Location = New System.Drawing.Point(144, 16)
        Me.lblNombreTrabajador.Name = "lblNombreTrabajador"
        Me.lblNombreTrabajador.Size = New System.Drawing.Size(10, 13)
        Me.lblNombreTrabajador.TabIndex = 2
        Me.lblNombreTrabajador.Text = "."
        '
        'txtCodigoTrabajador
        '
        Me.txtCodigoTrabajador.Location = New System.Drawing.Point(76, 13)
        Me.txtCodigoTrabajador.Name = "txtCodigoTrabajador"
        Me.txtCodigoTrabajador.Size = New System.Drawing.Size(62, 20)
        Me.txtCodigoTrabajador.TabIndex = 0
        '
        'lblDisplayTrabajador
        '
        Me.lblDisplayTrabajador.AutoSize = True
        Me.lblDisplayTrabajador.Location = New System.Drawing.Point(6, 16)
        Me.lblDisplayTrabajador.Name = "lblDisplayTrabajador"
        Me.lblDisplayTrabajador.Size = New System.Drawing.Size(64, 13)
        Me.lblDisplayTrabajador.TabIndex = 0
        Me.lblDisplayTrabajador.Text = "Trabajador :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tssElaboro})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 660)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1071, 24)
        Me.StatusStripEstado.TabIndex = 386
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
        'GridTrabajadores
        '
        Me.GridTrabajadores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridTrabajadores.CheckedImage = CType(resources.GetObject("GridTrabajadores.CheckedImage"), System.Drawing.Bitmap)
        Me.GridTrabajadores.Cols = 2
        Me.GridTrabajadores.DisplayRowNumber = True
        Me.GridTrabajadores.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridTrabajadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTrabajadores.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridTrabajadores.Location = New System.Drawing.Point(6, 19)
        Me.GridTrabajadores.Name = "GridTrabajadores"
        Me.GridTrabajadores.Rows = 2
        Me.GridTrabajadores.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridTrabajadores.Size = New System.Drawing.Size(454, 565)
        Me.GridTrabajadores.TabIndex = 0
        Me.GridTrabajadores.UncheckedImage = CType(resources.GetObject("GridTrabajadores.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalImportePrestaciones)
        Me.GroupBox1.Controls.Add(Me.txtTotalSaldoPrestaciones)
        Me.GroupBox1.Controls.Add(Me.lblDisplaySumaTotalPrestaciones)
        Me.GroupBox1.Controls.Add(Me.GridTrabajadores)
        Me.GroupBox1.Location = New System.Drawing.Point(600, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(466, 624)
        Me.GroupBox1.TabIndex = 387
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Saldo global de todos los trabajadores :"
        '
        'txtTotalImportePrestaciones
        '
        Me.txtTotalImportePrestaciones.Enabled = False
        Me.txtTotalImportePrestaciones.Location = New System.Drawing.Point(255, 590)
        Me.txtTotalImportePrestaciones.Name = "txtTotalImportePrestaciones"
        Me.txtTotalImportePrestaciones.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalImportePrestaciones.TabIndex = 383
        Me.txtTotalImportePrestaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalSaldoPrestaciones
        '
        Me.txtTotalSaldoPrestaciones.Enabled = False
        Me.txtTotalSaldoPrestaciones.Location = New System.Drawing.Point(360, 590)
        Me.txtTotalSaldoPrestaciones.Name = "txtTotalSaldoPrestaciones"
        Me.txtTotalSaldoPrestaciones.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalSaldoPrestaciones.TabIndex = 382
        Me.txtTotalSaldoPrestaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplaySumaTotalPrestaciones
        '
        Me.lblDisplaySumaTotalPrestaciones.AutoSize = True
        Me.lblDisplaySumaTotalPrestaciones.Cursor = System.Windows.Forms.Cursors.Cross
        Me.lblDisplaySumaTotalPrestaciones.Location = New System.Drawing.Point(18, 593)
        Me.lblDisplaySumaTotalPrestaciones.Name = "lblDisplaySumaTotalPrestaciones"
        Me.lblDisplaySumaTotalPrestaciones.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplaySumaTotalPrestaciones.TabIndex = 10
        Me.lblDisplaySumaTotalPrestaciones.Text = "Sumas :"
        '
        'txtIdSemana
        '
        Me.txtIdSemana.Location = New System.Drawing.Point(248, 185)
        Me.txtIdSemana.Name = "txtIdSemana"
        Me.txtIdSemana.Size = New System.Drawing.Size(36, 20)
        Me.txtIdSemana.TabIndex = 3
        Me.txtIdSemana.Visible = False
        '
        'txtNumeroSemana
        '
        Me.txtNumeroSemana.Enabled = False
        Me.txtNumeroSemana.Location = New System.Drawing.Point(74, 12)
        Me.txtNumeroSemana.Name = "txtNumeroSemana"
        Me.txtNumeroSemana.Size = New System.Drawing.Size(53, 20)
        Me.txtNumeroSemana.TabIndex = 397
        Me.txtNumeroSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frm_Nomina_Deducciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 684)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbGeneral)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_Deducciones"
        Me.Text = "Deducciones"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbHistorialDeducciones.ResumeLayout(False)
        Me.gbHistorialDeducciones.PerformLayout()
        Me.gbPlanAbonos.ResumeLayout(False)
        Me.gbPlanAbonos.PerformLayout()
        Me.gbGeneral.ResumeLayout(False)
        Me.gbDeducciones.ResumeLayout(False)
        Me.gbDeducciones.PerformLayout()
        Me.gbTrabajador.ResumeLayout(False)
        Me.gbTrabajador.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbHistorialDeducciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtSumaSaldos As System.Windows.Forms.TextBox
    Friend WithEvents txtSumaImportes As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySumaHistorial As System.Windows.Forms.Label
    Friend WithEvents GridHistorialDeducciones As FlexCell.Grid
    Friend WithEvents gbPlanAbonos As System.Windows.Forms.GroupBox
    Friend WithEvents txtSuma As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySumas As System.Windows.Forms.Label
    Friend WithEvents GridPlanAbonos As FlexCell.Grid
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents gbDeducciones As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplaySemana As System.Windows.Forms.Label
    Friend WithEvents gbTrabajador As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreTrabajador As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTrabajador As System.Windows.Forms.Label
    Friend WithEvents DtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboSemana As System.Windows.Forms.ComboBox
    Friend WithEvents rdbSiguienteSemana As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMismaSemana As System.Windows.Forms.RadioButton
    Friend WithEvents TxtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySaldo As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayDescuentoSemanal As System.Windows.Forms.Label
    Friend WithEvents TxtImporte As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayImporte As System.Windows.Forms.Label
    Friend WithEvents btnGeneraPlanAbonos As System.Windows.Forms.Button
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents cboTipoDeduccion As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTipo As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnBorrarSemana As System.Windows.Forms.Button
    Friend WithEvents BtnAgregarSemana As System.Windows.Forms.Button
    Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblId_Percepcion As System.Windows.Forms.Label
    Friend WithEvents GridTrabajadores As FlexCell.Grid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalImportePrestaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSaldoPrestaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySumaTotalPrestaciones As System.Windows.Forms.Label
    Friend WithEvents BtnRecorrerSemana As System.Windows.Forms.Button
    Friend WithEvents tsbSaldar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExtenderTemporada As System.Windows.Forms.Button
    Friend WithEvents txtNumeroSemana As System.Windows.Forms.TextBox
    Friend WithEvents txtIdSemana As System.Windows.Forms.TextBox
End Class
