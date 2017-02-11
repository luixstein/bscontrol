<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Embarques_ArmadoPalets
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Embarques_ArmadoPalets))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbArmar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbDesarmarPalet = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssArmo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCentroCosto = New System.Windows.Forms.Label()
        Me.txtCentroCosto = New System.Windows.Forms.TextBox()
        Me.lblDisplayCentroCosto = New System.Windows.Forms.Label()
        Me.dtFechaCorte = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbGeneraraSalida = New System.Windows.Forms.GroupBox()
        Me.rdbSi = New System.Windows.Forms.RadioButton()
        Me.rdbNo = New System.Windows.Forms.RadioButton()
        Me.btnPaletSiguiente = New System.Windows.Forms.Button()
        Me.btnPaletAnterior = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnArmarPalets = New System.Windows.Forms.Button()
        Me.btnImprimirEtiquetasPalets = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFolioPalet1Etiquetas = New System.Windows.Forms.TextBox()
        Me.txtFolioPalet2Etiquetas = New System.Windows.Forms.TextBox()
        Me.tsbImprimirEtiquetas = New System.Windows.Forms.ToolStrip()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.chkEsChepPalet = New System.Windows.Forms.CheckBox()
        Me.CboProductor = New System.Windows.Forms.ComboBox()
        Me.txtCantidadPalets = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.lblDisplayEstado = New System.Windows.Forms.Label()
        Me.lblEsCheoPalet = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDisplayProductor = New System.Windows.Forms.Label()
        Me.CboOrigen = New System.Windows.Forms.ComboBox()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.CboLote = New System.Windows.Forms.ComboBox()
        Me.lblDisplayLote = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.CboEmpaque = New System.Windows.Forms.ComboBox()
        Me.LblEmbarque = New System.Windows.Forms.Label()
        Me.gbGrid = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.TxtTotalBultos = New System.Windows.Forms.TextBox()
        Me.lblTotalBultos = New System.Windows.Forms.Label()
        Me.TxtTotalPeso = New System.Windows.Forms.TextBox()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.TxtImporteTotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnImprimirEtiquetasCajas = New System.Windows.Forms.Button()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbGeneraraSalida.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbArmar, Me.tsbCancelar, Me.tsbDesarmarPalet, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(906, 25)
        Me.tsMenu.TabIndex = 2
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
        'tsbArmar
        '
        Me.tsbArmar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbArmar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbArmar.Name = "tsbArmar"
        Me.tsbArmar.Size = New System.Drawing.Size(70, 22)
        Me.tsbArmar.Text = "&Armado"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 22)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbDesarmarPalet
        '
        Me.tsbDesarmarPalet.Image = CType(resources.GetObject("tsbDesarmarPalet.Image"), System.Drawing.Image)
        Me.tsbDesarmarPalet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDesarmarPalet.Name = "tsbDesarmarPalet"
        Me.tsbDesarmarPalet.Size = New System.Drawing.Size(106, 22)
        Me.tsbDesarmarPalet.Text = "&Desarmar palet"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tssElaboro, Me.tssArmo, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 544)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(906, 24)
        Me.StatusStripEstado.TabIndex = 315
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
        'tssArmo
        '
        Me.tssArmo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssArmo.Name = "tssArmo"
        Me.tssArmo.Size = New System.Drawing.Size(47, 19)
        Me.tssArmo.Text = "Armó :"
        '
        'tssCancelo
        '
        Me.tssCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssCancelo.Name = "tssCancelo"
        Me.tssCancelo.Size = New System.Drawing.Size(60, 19)
        Me.tssCancelo.Text = "Canceló :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCentroCosto)
        Me.GroupBox1.Controls.Add(Me.txtCentroCosto)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCentroCosto)
        Me.GroupBox1.Controls.Add(Me.dtFechaCorte)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.gbGeneraraSalida)
        Me.GroupBox1.Controls.Add(Me.btnPaletSiguiente)
        Me.GroupBox1.Controls.Add(Me.btnPaletAnterior)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.lblDisplayStatus)
        Me.GroupBox1.Controls.Add(Me.chkEsChepPalet)
        Me.GroupBox1.Controls.Add(Me.CboProductor)
        Me.GroupBox1.Controls.Add(Me.txtCantidadPalets)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CboEstatus)
        Me.GroupBox1.Controls.Add(Me.lblDisplayEstado)
        Me.GroupBox1.Controls.Add(Me.lblEsCheoPalet)
        Me.GroupBox1.Controls.Add(Me.lblProveedor)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblDisplayProductor)
        Me.GroupBox1.Controls.Add(Me.CboOrigen)
        Me.GroupBox1.Controls.Add(Me.lblOrigen)
        Me.GroupBox1.Controls.Add(Me.CboLote)
        Me.GroupBox1.Controls.Add(Me.lblDisplayLote)
        Me.GroupBox1.Controls.Add(Me.DtpFecha)
        Me.GroupBox1.Controls.Add(Me.LblFecha)
        Me.GroupBox1.Controls.Add(Me.TxtFolio)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFolio)
        Me.GroupBox1.Controls.Add(Me.CboEmpaque)
        Me.GroupBox1.Controls.Add(Me.LblEmbarque)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(882, 179)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.AutoSize = True
        Me.lblCentroCosto.Location = New System.Drawing.Point(169, 132)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(13, 13)
        Me.lblCentroCosto.TabIndex = 385
        Me.lblCentroCosto.Text = "_"
        '
        'txtCentroCosto
        '
        Me.txtCentroCosto.Location = New System.Drawing.Point(106, 129)
        Me.txtCentroCosto.MaxLength = 5
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.Size = New System.Drawing.Size(57, 20)
        Me.txtCentroCosto.TabIndex = 4
        '
        'lblDisplayCentroCosto
        '
        Me.lblDisplayCentroCosto.AutoSize = True
        Me.lblDisplayCentroCosto.Location = New System.Drawing.Point(9, 132)
        Me.lblDisplayCentroCosto.Name = "lblDisplayCentroCosto"
        Me.lblDisplayCentroCosto.Size = New System.Drawing.Size(88, 13)
        Me.lblDisplayCentroCosto.TabIndex = 379
        Me.lblDisplayCentroCosto.Text = "Centro de costo :"
        '
        'dtFechaCorte
        '
        Me.dtFechaCorte.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtFechaCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaCorte.Location = New System.Drawing.Point(343, 16)
        Me.dtFechaCorte.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaCorte.Name = "dtFechaCorte"
        Me.dtFechaCorte.Size = New System.Drawing.Size(214, 20)
        Me.dtFechaCorte.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(264, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 377
        Me.Label5.Text = "Fecha corte :"
        '
        'gbGeneraraSalida
        '
        Me.gbGeneraraSalida.Controls.Add(Me.rdbSi)
        Me.gbGeneraraSalida.Controls.Add(Me.rdbNo)
        Me.gbGeneraraSalida.Location = New System.Drawing.Point(585, 95)
        Me.gbGeneraraSalida.Name = "gbGeneraraSalida"
        Me.gbGeneraraSalida.Size = New System.Drawing.Size(146, 36)
        Me.gbGeneraraSalida.TabIndex = 375
        Me.gbGeneraraSalida.TabStop = False
        Me.gbGeneraraSalida.Text = "Generara Salida"
        '
        'rdbSi
        '
        Me.rdbSi.AutoSize = True
        Me.rdbSi.Checked = True
        Me.rdbSi.Location = New System.Drawing.Point(14, 16)
        Me.rdbSi.Name = "rdbSi"
        Me.rdbSi.Size = New System.Drawing.Size(34, 17)
        Me.rdbSi.TabIndex = 372
        Me.rdbSi.TabStop = True
        Me.rdbSi.Text = "Si"
        Me.rdbSi.UseVisualStyleBackColor = True
        '
        'rdbNo
        '
        Me.rdbNo.AutoSize = True
        Me.rdbNo.Location = New System.Drawing.Point(90, 16)
        Me.rdbNo.Name = "rdbNo"
        Me.rdbNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbNo.TabIndex = 373
        Me.rdbNo.TabStop = True
        Me.rdbNo.Text = "No"
        Me.rdbNo.UseVisualStyleBackColor = True
        '
        'btnPaletSiguiente
        '
        Me.btnPaletSiguiente.Location = New System.Drawing.Point(204, 16)
        Me.btnPaletSiguiente.Name = "btnPaletSiguiente"
        Me.btnPaletSiguiente.Size = New System.Drawing.Size(35, 21)
        Me.btnPaletSiguiente.TabIndex = 368
        Me.btnPaletSiguiente.Text = ">>"
        Me.btnPaletSiguiente.UseVisualStyleBackColor = True
        '
        'btnPaletAnterior
        '
        Me.btnPaletAnterior.Location = New System.Drawing.Point(163, 16)
        Me.btnPaletAnterior.Name = "btnPaletAnterior"
        Me.btnPaletAnterior.Size = New System.Drawing.Size(35, 21)
        Me.btnPaletAnterior.TabIndex = 367
        Me.btnPaletAnterior.Text = "<<"
        Me.btnPaletAnterior.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnArmarPalets)
        Me.GroupBox2.Controls.Add(Me.btnImprimirEtiquetasPalets)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtFolioPalet1Etiquetas)
        Me.GroupBox2.Controls.Add(Me.txtFolioPalet2Etiquetas)
        Me.GroupBox2.Controls.Add(Me.tsbImprimirEtiquetas)
        Me.GroupBox2.Location = New System.Drawing.Point(711, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(165, 131)
        Me.GroupBox2.TabIndex = 371
        Me.GroupBox2.TabStop = False
        '
        'BtnArmarPalets
        '
        Me.BtnArmarPalets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnArmarPalets.Location = New System.Drawing.Point(7, 53)
        Me.BtnArmarPalets.Name = "BtnArmarPalets"
        Me.BtnArmarPalets.Size = New System.Drawing.Size(147, 36)
        Me.BtnArmarPalets.TabIndex = 376
        Me.BtnArmarPalets.Text = "Armar palets:"
        Me.BtnArmarPalets.UseVisualStyleBackColor = True
        '
        'btnImprimirEtiquetasPalets
        '
        Me.btnImprimirEtiquetasPalets.Image = CType(resources.GetObject("btnImprimirEtiquetasPalets.Image"), System.Drawing.Image)
        Me.btnImprimirEtiquetasPalets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimirEtiquetasPalets.Location = New System.Drawing.Point(7, 11)
        Me.btnImprimirEtiquetasPalets.Name = "btnImprimirEtiquetasPalets"
        Me.btnImprimirEtiquetasPalets.Size = New System.Drawing.Size(147, 36)
        Me.btnImprimirEtiquetasPalets.TabIndex = 375
        Me.btnImprimirEtiquetasPalets.Text = "Imprimir etiquetas palets"
        Me.btnImprimirEtiquetasPalets.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimirEtiquetasPalets.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 374
        Me.Label4.Text = "Al :"
        '
        'txtFolioPalet1Etiquetas
        '
        Me.txtFolioPalet1Etiquetas.Location = New System.Drawing.Point(7, 100)
        Me.txtFolioPalet1Etiquetas.MaxLength = 15
        Me.txtFolioPalet1Etiquetas.Name = "txtFolioPalet1Etiquetas"
        Me.txtFolioPalet1Etiquetas.Size = New System.Drawing.Size(52, 20)
        Me.txtFolioPalet1Etiquetas.TabIndex = 373
        Me.txtFolioPalet1Etiquetas.Text = "0"
        Me.txtFolioPalet1Etiquetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFolioPalet2Etiquetas
        '
        Me.txtFolioPalet2Etiquetas.Location = New System.Drawing.Point(102, 100)
        Me.txtFolioPalet2Etiquetas.MaxLength = 15
        Me.txtFolioPalet2Etiquetas.Name = "txtFolioPalet2Etiquetas"
        Me.txtFolioPalet2Etiquetas.Size = New System.Drawing.Size(52, 20)
        Me.txtFolioPalet2Etiquetas.TabIndex = 372
        Me.txtFolioPalet2Etiquetas.Text = "0"
        Me.txtFolioPalet2Etiquetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsbImprimirEtiquetas
        '
        Me.tsbImprimirEtiquetas.Dock = System.Windows.Forms.DockStyle.None
        Me.tsbImprimirEtiquetas.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsbImprimirEtiquetas.Location = New System.Drawing.Point(3, 12)
        Me.tsbImprimirEtiquetas.Name = "tsbImprimirEtiquetas"
        Me.tsbImprimirEtiquetas.Size = New System.Drawing.Size(1, 0)
        Me.tsbImprimirEtiquetas.TabIndex = 371
        Me.tsbImprimirEtiquetas.Text = "ToolStrip1"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblEstatus.Location = New System.Drawing.Point(319, 76)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(10, 13)
        Me.LblEstatus.TabIndex = 362
        Me.LblEstatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(265, 76)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 361
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'chkEsChepPalet
        '
        Me.chkEsChepPalet.AutoSize = True
        Me.chkEsChepPalet.Location = New System.Drawing.Point(585, 131)
        Me.chkEsChepPalet.Name = "chkEsChepPalet"
        Me.chkEsChepPalet.Size = New System.Drawing.Size(15, 14)
        Me.chkEsChepPalet.TabIndex = 9
        Me.chkEsChepPalet.UseVisualStyleBackColor = True
        '
        'CboProductor
        '
        Me.CboProductor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboProductor.FormattingEnabled = True
        Me.CboProductor.Location = New System.Drawing.Point(106, 72)
        Me.CboProductor.Name = "CboProductor"
        Me.CboProductor.Size = New System.Drawing.Size(135, 21)
        Me.CboProductor.TabIndex = 2
        '
        'txtCantidadPalets
        '
        Me.txtCantidadPalets.Location = New System.Drawing.Point(378, 45)
        Me.txtCantidadPalets.MaxLength = 8
        Me.txtCantidadPalets.Name = "txtCantidadPalets"
        Me.txtCantidadPalets.Size = New System.Drawing.Size(102, 20)
        Me.txtCantidadPalets.TabIndex = 7
        Me.txtCantidadPalets.Text = "  "
        Me.txtCantidadPalets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(264, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 360
        Me.Label2.Text = "Cantidad de palets :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"NO EMBARCADO", "EMBARCADO"})
        Me.CboEstatus.Location = New System.Drawing.Point(552, 72)
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(146, 21)
        Me.CboEstatus.TabIndex = 358
        '
        'lblDisplayEstado
        '
        Me.lblDisplayEstado.AutoSize = True
        Me.lblDisplayEstado.Location = New System.Drawing.Point(501, 76)
        Me.lblDisplayEstado.Name = "lblDisplayEstado"
        Me.lblDisplayEstado.Size = New System.Drawing.Size(46, 13)
        Me.lblDisplayEstado.TabIndex = 357
        Me.lblDisplayEstado.Text = "Estado :"
        '
        'lblEsCheoPalet
        '
        Me.lblEsCheoPalet.AutoSize = True
        Me.lblEsCheoPalet.Location = New System.Drawing.Point(501, 132)
        Me.lblEsCheoPalet.Name = "lblEsCheoPalet"
        Me.lblEsCheoPalet.Size = New System.Drawing.Size(78, 13)
        Me.lblEsCheoPalet.TabIndex = 356
        Me.lblEsCheoPalet.Text = "Es chep palet :"
        '
        'lblProveedor
        '
        Me.lblProveedor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProveedor.Location = New System.Drawing.Point(265, 104)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(433, 13)
        Me.lblProveedor.TabIndex = 353
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Window
        Me.txtProveedor.Location = New System.Drawing.Point(106, 100)
        Me.txtProveedor.MaxLength = 8
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(135, 20)
        Me.txtProveedor.TabIndex = 3
        Me.txtProveedor.Text = "  "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 352
        Me.Label1.Text = "Prov. de envase :"
        '
        'lblDisplayProductor
        '
        Me.lblDisplayProductor.AutoSize = True
        Me.lblDisplayProductor.Location = New System.Drawing.Point(9, 76)
        Me.lblDisplayProductor.Name = "lblDisplayProductor"
        Me.lblDisplayProductor.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayProductor.TabIndex = 349
        Me.lblDisplayProductor.Text = "Productor :"
        '
        'CboOrigen
        '
        Me.CboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboOrigen.FormattingEnabled = True
        Me.CboOrigen.Items.AddRange(New Object() {"EMPAQUE", "REEMPAQUE"})
        Me.CboOrigen.Location = New System.Drawing.Point(106, 155)
        Me.CboOrigen.Name = "CboOrigen"
        Me.CboOrigen.Size = New System.Drawing.Size(146, 21)
        Me.CboOrigen.TabIndex = 8
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Location = New System.Drawing.Point(9, 158)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(44, 13)
        Me.lblOrigen.TabIndex = 345
        Me.lblOrigen.Text = "Origen :"
        '
        'CboLote
        '
        Me.CboLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLote.FormattingEnabled = True
        Me.CboLote.Location = New System.Drawing.Point(378, 152)
        Me.CboLote.Name = "CboLote"
        Me.CboLote.Size = New System.Drawing.Size(154, 21)
        Me.CboLote.TabIndex = 4
        Me.CboLote.Visible = False
        '
        'lblDisplayLote
        '
        Me.lblDisplayLote.AutoSize = True
        Me.lblDisplayLote.Location = New System.Drawing.Point(338, 156)
        Me.lblDisplayLote.Name = "lblDisplayLote"
        Me.lblDisplayLote.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayLote.TabIndex = 344
        Me.lblDisplayLote.Text = "Lote :"
        Me.lblDisplayLote.Visible = False
        '
        'DtpFecha
        '
        Me.DtpFecha.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Location = New System.Drawing.Point(653, 16)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(223, 20)
        Me.DtpFecha.TabIndex = 6
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(563, 18)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(90, 13)
        Me.LblFecha.TabIndex = 341
        Me.LblFecha.Text = "Fecha empaque :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Location = New System.Drawing.Point(106, 16)
        Me.TxtFolio.MaxLength = 15
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(52, 20)
        Me.TxtFolio.TabIndex = 0
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(9, 20)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 338
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'CboEmpaque
        '
        Me.CboEmpaque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEmpaque.FormattingEnabled = True
        Me.CboEmpaque.Location = New System.Drawing.Point(106, 44)
        Me.CboEmpaque.Name = "CboEmpaque"
        Me.CboEmpaque.Size = New System.Drawing.Size(135, 21)
        Me.CboEmpaque.TabIndex = 1
        '
        'LblEmbarque
        '
        Me.LblEmbarque.AutoSize = True
        Me.LblEmbarque.Location = New System.Drawing.Point(9, 48)
        Me.LblEmbarque.Name = "LblEmbarque"
        Me.LblEmbarque.Size = New System.Drawing.Size(58, 13)
        Me.LblEmbarque.TabIndex = 337
        Me.LblEmbarque.Text = "Empaque :"
        '
        'gbGrid
        '
        Me.gbGrid.Controls.Add(Me.Grid)
        Me.gbGrid.Location = New System.Drawing.Point(12, 226)
        Me.gbGrid.Name = "gbGrid"
        Me.gbGrid.Size = New System.Drawing.Size(882, 239)
        Me.gbGrid.TabIndex = 1
        Me.gbGrid.TabStop = False
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
        Me.Grid.Location = New System.Drawing.Point(12, 18)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 1
        Me.Grid.Size = New System.Drawing.Size(864, 207)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TxtTotalBultos
        '
        Me.TxtTotalBultos.Location = New System.Drawing.Point(713, 471)
        Me.TxtTotalBultos.MaxLength = 8
        Me.TxtTotalBultos.Name = "TxtTotalBultos"
        Me.TxtTotalBultos.ReadOnly = True
        Me.TxtTotalBultos.Size = New System.Drawing.Size(102, 20)
        Me.TxtTotalBultos.TabIndex = 361
        Me.TxtTotalBultos.Text = "  "
        Me.TxtTotalBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalBultos
        '
        Me.lblTotalBultos.AutoSize = True
        Me.lblTotalBultos.Location = New System.Drawing.Point(627, 474)
        Me.lblTotalBultos.Name = "lblTotalBultos"
        Me.lblTotalBultos.Size = New System.Drawing.Size(83, 13)
        Me.lblTotalBultos.TabIndex = 362
        Me.lblTotalBultos.Text = "Total de bultos :"
        '
        'TxtTotalPeso
        '
        Me.TxtTotalPeso.Location = New System.Drawing.Point(713, 497)
        Me.TxtTotalPeso.MaxLength = 8
        Me.TxtTotalPeso.Name = "TxtTotalPeso"
        Me.TxtTotalPeso.ReadOnly = True
        Me.TxtTotalPeso.Size = New System.Drawing.Size(102, 20)
        Me.TxtTotalPeso.TabIndex = 363
        Me.TxtTotalPeso.Text = "  "
        Me.TxtTotalPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Location = New System.Drawing.Point(673, 500)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(37, 13)
        Me.lblPeso.TabIndex = 364
        Me.lblPeso.Text = "Peso :"
        '
        'TxtImporteTotal
        '
        Me.TxtImporteTotal.Location = New System.Drawing.Point(713, 521)
        Me.TxtImporteTotal.MaxLength = 8
        Me.TxtImporteTotal.Name = "TxtImporteTotal"
        Me.TxtImporteTotal.ReadOnly = True
        Me.TxtImporteTotal.Size = New System.Drawing.Size(102, 20)
        Me.TxtImporteTotal.TabIndex = 365
        Me.TxtImporteTotal.Text = "  "
        Me.TxtImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(662, 524)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 366
        Me.Label3.Text = "Importe :"
        '
        'btnImprimirEtiquetasCajas
        '
        Me.btnImprimirEtiquetasCajas.Image = CType(resources.GetObject("btnImprimirEtiquetasCajas.Image"), System.Drawing.Image)
        Me.btnImprimirEtiquetasCajas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimirEtiquetasCajas.Location = New System.Drawing.Point(730, 196)
        Me.btnImprimirEtiquetasCajas.Name = "btnImprimirEtiquetasCajas"
        Me.btnImprimirEtiquetasCajas.Size = New System.Drawing.Size(147, 36)
        Me.btnImprimirEtiquetasCajas.TabIndex = 376
        Me.btnImprimirEtiquetasCajas.Text = "Imprimir etiquetas cajas"
        Me.btnImprimirEtiquetasCajas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimirEtiquetasCajas.UseVisualStyleBackColor = True
        '
        'Frm_Embarques_ArmadoPalets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 568)
        Me.Controls.Add(Me.btnImprimirEtiquetasCajas)
        Me.Controls.Add(Me.TxtImporteTotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTotalPeso)
        Me.Controls.Add(Me.lblPeso)
        Me.Controls.Add(Me.TxtTotalBultos)
        Me.Controls.Add(Me.lblTotalBultos)
        Me.Controls.Add(Me.gbGrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Embarques_ArmadoPalets"
        Me.Text = "Armado de palets"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbGeneraraSalida.ResumeLayout(False)
        Me.gbGeneraraSalida.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbGrid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents CboLote As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayLote As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents CboEmpaque As System.Windows.Forms.ComboBox
    Friend WithEvents LblEmbarque As System.Windows.Forms.Label
    Friend WithEvents lblDisplayProductor As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayEstado As System.Windows.Forms.Label
    Friend WithEvents lblEsCheoPalet As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtCantidadPalets As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbGrid As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents TxtTotalBultos As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalBultos As System.Windows.Forms.Label
    Friend WithEvents CboProductor As System.Windows.Forms.ComboBox
    Friend WithEvents chkEsChepPalet As System.Windows.Forms.CheckBox
    Friend WithEvents TxtTotalPeso As System.Windows.Forms.TextBox
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents TxtImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFolioPalet1Etiquetas As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioPalet2Etiquetas As System.Windows.Forms.TextBox
    Friend WithEvents tsbImprimirEtiquetas As System.Windows.Forms.ToolStrip
    Friend WithEvents btnImprimirEtiquetasPalets As System.Windows.Forms.Button
    Friend WithEvents BtnArmarPalets As System.Windows.Forms.Button
    Friend WithEvents tsbArmar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPaletSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnPaletAnterior As System.Windows.Forms.Button
    Friend WithEvents tsbDesarmarPalet As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssArmo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbGeneraraSalida As System.Windows.Forms.GroupBox
    Friend WithEvents rdbSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNo As System.Windows.Forms.RadioButton
    Friend WithEvents dtFechaCorte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirEtiquetasCajas As System.Windows.Forms.Button
    Friend WithEvents txtCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCentroCosto As System.Windows.Forms.Label
    Friend WithEvents lblCentroCosto As System.Windows.Forms.Label
End Class
