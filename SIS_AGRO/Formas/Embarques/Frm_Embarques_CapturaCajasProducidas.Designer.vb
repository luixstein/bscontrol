<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_CapturaCajasProducidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_CapturaCajasProducidas))
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.CboLote = New System.Windows.Forms.ComboBox()
        Me.lblDisplayLote = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCultivo = New System.Windows.Forms.Label()
        Me.txtTotalCajas = New System.Windows.Forms.TextBox()
        Me.Grid = New FlexCell.Grid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblDisplayRptAsta = New System.Windows.Forms.Label()
        Me.dtHasta = New System.Windows.Forms.DateTimePicker()
        Me.CboCultivoRpt = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDisplayDesde = New System.Windows.Forms.Label()
        Me.dtDesde = New System.Windows.Forms.DateTimePicker()
        Me.cboLoteRpt = New System.Windows.Forms.ComboBox()
        Me.lblDisplayRptLote = New System.Windows.Forms.Label()
        Me.cboEmpaque = New System.Windows.Forms.ComboBox()
        Me.lblDisplayEmpaque = New System.Windows.Forms.Label()
        Me.btnDiaSiguiente = New System.Windows.Forms.Button()
        Me.btnDiaAnterior = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalFleteAcarreo = New System.Windows.Forms.TextBox()
        Me.txtTotalFleteEntrega = New System.Windows.Forms.TextBox()
        Me.CboCentroCosto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCentroConsto = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DtpFecha
        '
        Me.DtpFecha.CustomFormat = "dd/MMM/yyyy"
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(8, 49)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(111, 20)
        Me.DtpFecha.TabIndex = 0
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(8, 21)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 1
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'CboLote
        '
        Me.CboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLote.FormattingEnabled = True
        Me.CboLote.Location = New System.Drawing.Point(466, 52)
        Me.CboLote.Name = "CboLote"
        Me.CboLote.Size = New System.Drawing.Size(241, 21)
        Me.CboLote.TabIndex = 345
        '
        'lblDisplayLote
        '
        Me.lblDisplayLote.AutoSize = True
        Me.lblDisplayLote.Location = New System.Drawing.Point(466, 20)
        Me.lblDisplayLote.Name = "lblDisplayLote"
        Me.lblDisplayLote.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayLote.TabIndex = 346
        Me.lblDisplayLote.Text = "Lote :"
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Location = New System.Drawing.Point(583, 3)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(288, 21)
        Me.cboCultivo.TabIndex = 347
        Me.cboCultivo.Visible = False
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(532, 6)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 348
        Me.lblDisplayCultivo.Text = "Cultivo :"
        Me.lblDisplayCultivo.Visible = False
        '
        'txtTotalCajas
        '
        Me.txtTotalCajas.Enabled = False
        Me.txtTotalCajas.Location = New System.Drawing.Point(317, 436)
        Me.txtTotalCajas.Name = "txtTotalCajas"
        Me.txtTotalCajas.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCajas.TabIndex = 349
        Me.txtTotalCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Grid.Location = New System.Drawing.Point(8, 75)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 1
        Me.Grid.Size = New System.Drawing.Size(1030, 355)
        Me.Grid.TabIndex = 350
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(170, 439)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 13)
        Me.Label1.TabIndex = 351
        Me.Label1.Text = "Total de cajas produccidas :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.lblDisplayRptAsta)
        Me.GroupBox1.Controls.Add(Me.dtHasta)
        Me.GroupBox1.Controls.Add(Me.CboCultivoRpt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblDisplayDesde)
        Me.GroupBox1.Controls.Add(Me.dtDesde)
        Me.GroupBox1.Controls.Add(Me.cboLoteRpt)
        Me.GroupBox1.Controls.Add(Me.lblDisplayRptLote)
        Me.GroupBox1.Location = New System.Drawing.Point(474, 476)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 104)
        Me.GroupBox1.TabIndex = 352
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(350, 25)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(162, 23)
        Me.btnImprimir.TabIndex = 359
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblDisplayRptAsta
        '
        Me.lblDisplayRptAsta.AutoSize = True
        Me.lblDisplayRptAsta.Location = New System.Drawing.Point(9, 53)
        Me.lblDisplayRptAsta.Name = "lblDisplayRptAsta"
        Me.lblDisplayRptAsta.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayRptAsta.TabIndex = 358
        Me.lblDisplayRptAsta.Text = "Hasta :"
        '
        'dtHasta
        '
        Me.dtHasta.CustomFormat = "dd/MMM/yyyy"
        Me.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtHasta.Location = New System.Drawing.Point(70, 47)
        Me.dtHasta.Name = "dtHasta"
        Me.dtHasta.Size = New System.Drawing.Size(111, 20)
        Me.dtHasta.TabIndex = 357
        '
        'CboCultivoRpt
        '
        Me.CboCultivoRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCultivoRpt.FormattingEnabled = True
        Me.CboCultivoRpt.Location = New System.Drawing.Point(289, 73)
        Me.CboCultivoRpt.Name = "CboCultivoRpt"
        Me.CboCultivoRpt.Size = New System.Drawing.Size(223, 21)
        Me.CboCultivoRpt.TabIndex = 355
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 356
        Me.Label3.Text = "Cultivo :"
        '
        'lblDisplayDesde
        '
        Me.lblDisplayDesde.AutoSize = True
        Me.lblDisplayDesde.Location = New System.Drawing.Point(6, 25)
        Me.lblDisplayDesde.Name = "lblDisplayDesde"
        Me.lblDisplayDesde.Size = New System.Drawing.Size(44, 13)
        Me.lblDisplayDesde.TabIndex = 3
        Me.lblDisplayDesde.Text = "Desde :"
        '
        'dtDesde
        '
        Me.dtDesde.CustomFormat = "dd/MMM/yyyy"
        Me.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDesde.Location = New System.Drawing.Point(70, 19)
        Me.dtDesde.Name = "dtDesde"
        Me.dtDesde.Size = New System.Drawing.Size(111, 20)
        Me.dtDesde.TabIndex = 2
        '
        'cboLoteRpt
        '
        Me.cboLoteRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoteRpt.FormattingEnabled = True
        Me.cboLoteRpt.Location = New System.Drawing.Point(70, 73)
        Me.cboLoteRpt.Name = "cboLoteRpt"
        Me.cboLoteRpt.Size = New System.Drawing.Size(162, 21)
        Me.cboLoteRpt.TabIndex = 353
        '
        'lblDisplayRptLote
        '
        Me.lblDisplayRptLote.AutoSize = True
        Me.lblDisplayRptLote.Location = New System.Drawing.Point(9, 76)
        Me.lblDisplayRptLote.Name = "lblDisplayRptLote"
        Me.lblDisplayRptLote.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayRptLote.TabIndex = 354
        Me.lblDisplayRptLote.Text = "Lote :"
        '
        'cboEmpaque
        '
        Me.cboEmpaque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpaque.FormattingEnabled = True
        Me.cboEmpaque.Location = New System.Drawing.Point(215, 52)
        Me.cboEmpaque.Name = "cboEmpaque"
        Me.cboEmpaque.Size = New System.Drawing.Size(245, 21)
        Me.cboEmpaque.TabIndex = 353
        '
        'lblDisplayEmpaque
        '
        Me.lblDisplayEmpaque.AutoSize = True
        Me.lblDisplayEmpaque.Location = New System.Drawing.Point(215, 20)
        Me.lblDisplayEmpaque.Name = "lblDisplayEmpaque"
        Me.lblDisplayEmpaque.Size = New System.Drawing.Size(58, 13)
        Me.lblDisplayEmpaque.TabIndex = 354
        Me.lblDisplayEmpaque.Text = "Empaque :"
        '
        'btnDiaSiguiente
        '
        Me.btnDiaSiguiente.Location = New System.Drawing.Point(168, 48)
        Me.btnDiaSiguiente.Name = "btnDiaSiguiente"
        Me.btnDiaSiguiente.Size = New System.Drawing.Size(37, 21)
        Me.btnDiaSiguiente.TabIndex = 372
        Me.btnDiaSiguiente.Text = ">>"
        Me.btnDiaSiguiente.UseVisualStyleBackColor = True
        '
        'btnDiaAnterior
        '
        Me.btnDiaAnterior.Location = New System.Drawing.Point(125, 48)
        Me.btnDiaAnterior.Name = "btnDiaAnterior"
        Me.btnDiaAnterior.Size = New System.Drawing.Size(37, 21)
        Me.btnDiaAnterior.TabIndex = 371
        Me.btnDiaAnterior.Text = "<<"
        Me.btnDiaAnterior.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(765, 436)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 373
        Me.Label2.Text = "Total de fletes :"
        '
        'txtTotalFleteAcarreo
        '
        Me.txtTotalFleteAcarreo.Enabled = False
        Me.txtTotalFleteAcarreo.Location = New System.Drawing.Point(851, 432)
        Me.txtTotalFleteAcarreo.Name = "txtTotalFleteAcarreo"
        Me.txtTotalFleteAcarreo.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalFleteAcarreo.TabIndex = 374
        Me.txtTotalFleteAcarreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalFleteEntrega
        '
        Me.txtTotalFleteEntrega.Enabled = False
        Me.txtTotalFleteEntrega.Location = New System.Drawing.Point(945, 432)
        Me.txtTotalFleteEntrega.Name = "txtTotalFleteEntrega"
        Me.txtTotalFleteEntrega.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalFleteEntrega.TabIndex = 375
        Me.txtTotalFleteEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CboCentroCosto
        '
        Me.CboCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCentroCosto.FormattingEnabled = True
        Me.CboCentroCosto.Location = New System.Drawing.Point(713, 52)
        Me.CboCentroCosto.Name = "CboCentroCosto"
        Me.CboCentroCosto.Size = New System.Drawing.Size(325, 21)
        Me.CboCentroCosto.TabIndex = 376
        '
        'lblDisplayCentroConsto
        '
        Me.lblDisplayCentroConsto.AutoSize = True
        Me.lblDisplayCentroConsto.Location = New System.Drawing.Point(710, 21)
        Me.lblDisplayCentroConsto.Name = "lblDisplayCentroConsto"
        Me.lblDisplayCentroConsto.Size = New System.Drawing.Size(88, 13)
        Me.lblDisplayCentroConsto.TabIndex = 377
        Me.lblDisplayCentroConsto.Text = "Centro de costo :"
        '
        'Frm_Embarques_CapturaCajasProducidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 577)
        Me.Controls.Add(Me.CboCentroCosto)
        Me.Controls.Add(Me.lblDisplayCentroConsto)
        Me.Controls.Add(Me.txtTotalFleteEntrega)
        Me.Controls.Add(Me.txtTotalFleteAcarreo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDiaSiguiente)
        Me.Controls.Add(Me.btnDiaAnterior)
        Me.Controls.Add(Me.cboEmpaque)
        Me.Controls.Add(Me.lblDisplayEmpaque)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.txtTotalCajas)
        Me.Controls.Add(Me.cboCultivo)
        Me.Controls.Add(Me.lblDisplayCultivo)
        Me.Controls.Add(Me.CboLote)
        Me.Controls.Add(Me.lblDisplayLote)
        Me.Controls.Add(Me.lblDisplayFecha)
        Me.Controls.Add(Me.DtpFecha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_CapturaCajasProducidas"
        Me.Text = "Captura de corte y acarreo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents CboLote As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayLote As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCultivo As System.Windows.Forms.Label
    Friend WithEvents txtTotalCajas As System.Windows.Forms.TextBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayDesde As System.Windows.Forms.Label
    Friend WithEvents dtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboCultivoRpt As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboLoteRpt As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayRptLote As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRptAsta As System.Windows.Forms.Label
    Friend WithEvents dtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents cboEmpaque As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayEmpaque As System.Windows.Forms.Label
    Friend WithEvents btnDiaSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDiaAnterior As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFleteAcarreo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalFleteEntrega As System.Windows.Forms.TextBox
    Friend WithEvents CboCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCentroConsto As System.Windows.Forms.Label
End Class
