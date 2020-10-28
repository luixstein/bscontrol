<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_IVA_Acreditable_Global
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_IVA_Acreditable_Global))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
        Me.tsbReactivar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.dtFechaControl = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFechaControl = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.dtFechaCaptura = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFechaCaptura = New System.Windows.Forms.Label()
        Me.gbIVAsACubrir = New System.Windows.Forms.GroupBox()
        Me.lblDisplayIvaAcreditableACubrir16 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableACubrir16 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableACubrir11 = New System.Windows.Forms.Label()
        Me.lblDisplayIvaAcreditableACubrir11 = New System.Windows.Forms.Label()
        Me.chkOcultarIVA11 = New System.Windows.Forms.CheckBox()
        Me.gbTotalesActos = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTotalActos11 = New System.Windows.Forms.Label()
        Me.lblTotalActos = New System.Windows.Forms.Label()
        Me.lblTotalActos16 = New System.Windows.Forms.Label()
        Me.lblTotalActos11 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalActos = New System.Windows.Forms.Label()
        Me.lblDisplayTotalActos16 = New System.Windows.Forms.Label()
        Me.lblTotalActos0 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalActos0 = New System.Windows.Forms.Label()
        Me.gbGrid = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.gbTotalesIVAS = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTotalIvaAcreditable16 = New System.Windows.Forms.Label()
        Me.lblTotalIvaRetenido10 = New System.Windows.Forms.Label()
        Me.lblTotalIvaRetenido4 = New System.Windows.Forms.Label()
        Me.lblTotalIvaAcreditable16 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalIvaRetenido10 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalIvaRetenido4 = New System.Windows.Forms.Label()
        Me.lblTotalIvaAcreditable11 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalIvaAcreditable11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalActos8 = New System.Windows.Forms.Label()
        Me.lblTotalIvaAcreditable8 = New System.Windows.Forms.Label()
        Me.LblDisplayTotalIvaAcreditable8 = New System.Windows.Forms.Label()
        Me.LblDisplayTotalActos8 = New System.Windows.Forms.Label()
        Me.lblTotalIvaRetenido6 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalIvaRetenido6 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableACubrir8 = New System.Windows.Forms.Label()
        Me.lblDisplayTotalIvaAcreditableACubrir8 = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.gbDatosGenerales.SuspendLayout()
        Me.gbIVAsACubrir.SuspendLayout()
        Me.gbTotalesActos.SuspendLayout()
        Me.gbGrid.SuspendLayout()
        Me.gbTotalesIVAS.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbAplicar, Me.tsbReactivar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1424, 27)
        Me.tsMenu.TabIndex = 3
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
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(78, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbAplicar
        '
        Me.tsbAplicar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(80, 24)
        Me.tsbAplicar.Text = "&Aplicar"
        '
        'tsbReactivar
        '
        Me.tsbReactivar.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbReactivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReactivar.Name = "tsbReactivar"
        Me.tsbReactivar.Size = New System.Drawing.Size(94, 24)
        Me.tsbReactivar.Text = "&Reactivar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(90, 24)
        Me.tsbCancelar.Text = "&Cancelar"
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
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 681)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1424, 29)
        Me.StatusStripEstado.TabIndex = 2
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssEstado
        '
        Me.tssEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssEstado.Name = "tssEstado"
        Me.tssEstado.Size = New System.Drawing.Size(65, 24)
        Me.tssEstado.Text = "Estado :"
        '
        'tssElaboro
        '
        Me.tssElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssElaboro.Name = "tssElaboro"
        Me.tssElaboro.Size = New System.Drawing.Size(76, 24)
        Me.tssElaboro.Text = "Elaboró : "
        '
        'gbDatosGenerales
        '
        Me.gbDatosGenerales.Controls.Add(Me.dtFechaControl)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayFechaControl)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayIvaAcreditableACubrir11)
        Me.gbDatosGenerales.Controls.Add(Me.lblIvaAcreditableACubrir11)
        Me.gbDatosGenerales.Controls.Add(Me.txtFolio)
        Me.gbDatosGenerales.Controls.Add(Me.LblDisplayFolio)
        Me.gbDatosGenerales.Controls.Add(Me.lblEstatus)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayEstatus)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayConcepto)
        Me.gbDatosGenerales.Controls.Add(Me.txtConcepto)
        Me.gbDatosGenerales.Controls.Add(Me.dtFechaCaptura)
        Me.gbDatosGenerales.Controls.Add(Me.lblDisplayFechaCaptura)
        Me.gbDatosGenerales.Controls.Add(Me.gbIVAsACubrir)
        Me.gbDatosGenerales.Location = New System.Drawing.Point(0, 34)
        Me.gbDatosGenerales.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbDatosGenerales.Name = "gbDatosGenerales"
        Me.gbDatosGenerales.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbDatosGenerales.Size = New System.Drawing.Size(1408, 116)
        Me.gbDatosGenerales.TabIndex = 0
        Me.gbDatosGenerales.TabStop = False
        Me.gbDatosGenerales.Text = "Datos generales"
        '
        'dtFechaControl
        '
        Me.dtFechaControl.Enabled = False
        Me.dtFechaControl.Location = New System.Drawing.Point(613, 46)
        Me.dtFechaControl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtFechaControl.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaControl.Name = "dtFechaControl"
        Me.dtFechaControl.Size = New System.Drawing.Size(268, 22)
        Me.dtFechaControl.TabIndex = 228
        '
        'lblDisplayFechaControl
        '
        Me.lblDisplayFechaControl.AutoSize = True
        Me.lblDisplayFechaControl.Location = New System.Drawing.Point(501, 50)
        Me.lblDisplayFechaControl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaControl.Name = "lblDisplayFechaControl"
        Me.lblDisplayFechaControl.Size = New System.Drawing.Size(59, 17)
        Me.lblDisplayFechaControl.TabIndex = 229
        Me.lblDisplayFechaControl.Text = "Fecha  :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(97, 46)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(179, 22)
        Me.txtFolio.TabIndex = 0
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(12, 50)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 227
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEstatus.Location = New System.Drawing.Point(383, 50)
        Me.lblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(12, 17)
        Me.lblEstatus.TabIndex = 224
        Me.lblEstatus.Text = "."
        '
        'lblDisplayEstatus
        '
        Me.lblDisplayEstatus.AutoSize = True
        Me.lblDisplayEstatus.Location = New System.Drawing.Point(317, 50)
        Me.lblDisplayEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayEstatus.Name = "lblDisplayEstatus"
        Me.lblDisplayEstatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayEstatus.TabIndex = 223
        Me.lblDisplayEstatus.Text = "Estatus :"
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(12, 87)
        Me.lblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.lblDisplayConcepto.TabIndex = 222
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(97, 84)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtConcepto.MaxLength = 80
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(645, 22)
        Me.txtConcepto.TabIndex = 1
        '
        'dtFechaCaptura
        '
        Me.dtFechaCaptura.Enabled = False
        Me.dtFechaCaptura.Location = New System.Drawing.Point(613, 14)
        Me.dtFechaCaptura.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtFechaCaptura.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaCaptura.Name = "dtFechaCaptura"
        Me.dtFechaCaptura.Size = New System.Drawing.Size(268, 22)
        Me.dtFechaCaptura.TabIndex = 220
        Me.dtFechaCaptura.Visible = False
        '
        'lblDisplayFechaCaptura
        '
        Me.lblDisplayFechaCaptura.AutoSize = True
        Me.lblDisplayFechaCaptura.Location = New System.Drawing.Point(501, 17)
        Me.lblDisplayFechaCaptura.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFechaCaptura.Name = "lblDisplayFechaCaptura"
        Me.lblDisplayFechaCaptura.Size = New System.Drawing.Size(66, 17)
        Me.lblDisplayFechaCaptura.TabIndex = 221
        Me.lblDisplayFechaCaptura.Text = "Captura :"
        Me.lblDisplayFechaCaptura.Visible = False
        '
        'gbIVAsACubrir
        '
        Me.gbIVAsACubrir.Controls.Add(Me.lblDisplayTotalIvaAcreditableACubrir8)
        Me.gbIVAsACubrir.Controls.Add(Me.lblIvaAcreditableACubrir8)
        Me.gbIVAsACubrir.Controls.Add(Me.lblDisplayIvaAcreditableACubrir16)
        Me.gbIVAsACubrir.Controls.Add(Me.lblIvaAcreditableACubrir16)
        Me.gbIVAsACubrir.Location = New System.Drawing.Point(965, 16)
        Me.gbIVAsACubrir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbIVAsACubrir.Name = "gbIVAsACubrir"
        Me.gbIVAsACubrir.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbIVAsACubrir.Size = New System.Drawing.Size(253, 89)
        Me.gbIVAsACubrir.TabIndex = 191
        Me.gbIVAsACubrir.TabStop = False
        Me.gbIVAsACubrir.Text = "Iva a cubir :"
        '
        'lblDisplayIvaAcreditableACubrir16
        '
        Me.lblDisplayIvaAcreditableACubrir16.AutoSize = True
        Me.lblDisplayIvaAcreditableACubrir16.Location = New System.Drawing.Point(9, 54)
        Me.lblDisplayIvaAcreditableACubrir16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaAcreditableACubrir16.Name = "lblDisplayIvaAcreditableACubrir16"
        Me.lblDisplayIvaAcreditableACubrir16.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplayIvaAcreditableACubrir16.TabIndex = 11
        Me.lblDisplayIvaAcreditableACubrir16.Text = "Al 16%"
        '
        'lblIvaAcreditableACubrir16
        '
        Me.lblIvaAcreditableACubrir16.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir16.ForeColor = System.Drawing.Color.Red
        Me.lblIvaAcreditableACubrir16.Location = New System.Drawing.Point(108, 53)
        Me.lblIvaAcreditableACubrir16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableACubrir16.Name = "lblIvaAcreditableACubrir16"
        Me.lblIvaAcreditableACubrir16.Size = New System.Drawing.Size(138, 20)
        Me.lblIvaAcreditableACubrir16.TabIndex = 8
        Me.lblIvaAcreditableACubrir16.Text = "0.00"
        Me.lblIvaAcreditableACubrir16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableACubrir11
        '
        Me.lblIvaAcreditableACubrir11.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir11.ForeColor = System.Drawing.Color.Red
        Me.lblIvaAcreditableACubrir11.Location = New System.Drawing.Point(1249, 50)
        Me.lblIvaAcreditableACubrir11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableACubrir11.Name = "lblIvaAcreditableACubrir11"
        Me.lblIvaAcreditableACubrir11.Size = New System.Drawing.Size(138, 20)
        Me.lblIvaAcreditableACubrir11.TabIndex = 5
        Me.lblIvaAcreditableACubrir11.Text = "0.00"
        Me.lblIvaAcreditableACubrir11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIvaAcreditableACubrir11.Visible = False
        '
        'lblDisplayIvaAcreditableACubrir11
        '
        Me.lblDisplayIvaAcreditableACubrir11.AutoSize = True
        Me.lblDisplayIvaAcreditableACubrir11.Location = New System.Drawing.Point(1246, 19)
        Me.lblDisplayIvaAcreditableACubrir11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaAcreditableACubrir11.Name = "lblDisplayIvaAcreditableACubrir11"
        Me.lblDisplayIvaAcreditableACubrir11.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplayIvaAcreditableACubrir11.TabIndex = 4
        Me.lblDisplayIvaAcreditableACubrir11.Text = "Al 11%"
        Me.lblDisplayIvaAcreditableACubrir11.Visible = False
        '
        'chkOcultarIVA11
        '
        Me.chkOcultarIVA11.AutoSize = True
        Me.chkOcultarIVA11.Checked = True
        Me.chkOcultarIVA11.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOcultarIVA11.Location = New System.Drawing.Point(505, 538)
        Me.chkOcultarIVA11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkOcultarIVA11.Name = "chkOcultarIVA11"
        Me.chkOcultarIVA11.Size = New System.Drawing.Size(121, 21)
        Me.chkOcultarIVA11.TabIndex = 230
        Me.chkOcultarIVA11.Text = "Ocultar IVA 11"
        Me.chkOcultarIVA11.UseVisualStyleBackColor = True
        Me.chkOcultarIVA11.Visible = False
        '
        'gbTotalesActos
        '
        Me.gbTotalesActos.Controls.Add(Me.LblDisplayTotalActos8)
        Me.gbTotalesActos.Controls.Add(Me.lblTotalActos8)
        Me.gbTotalesActos.Controls.Add(Me.lblTotalActos)
        Me.gbTotalesActos.Controls.Add(Me.lblTotalActos16)
        Me.gbTotalesActos.Controls.Add(Me.lblDisplayTotalActos)
        Me.gbTotalesActos.Controls.Add(Me.lblDisplayTotalActos16)
        Me.gbTotalesActos.Controls.Add(Me.lblTotalActos0)
        Me.gbTotalesActos.Controls.Add(Me.lblDisplayTotalActos0)
        Me.gbTotalesActos.Location = New System.Drawing.Point(699, 512)
        Me.gbTotalesActos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbTotalesActos.Name = "gbTotalesActos"
        Me.gbTotalesActos.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbTotalesActos.Size = New System.Drawing.Size(253, 134)
        Me.gbTotalesActos.TabIndex = 190
        Me.gbTotalesActos.TabStop = False
        Me.gbTotalesActos.Text = "Totales actos :"
        '
        'lblDisplayTotalActos11
        '
        Me.lblDisplayTotalActos11.AutoSize = True
        Me.lblDisplayTotalActos11.Location = New System.Drawing.Point(206, 593)
        Me.lblDisplayTotalActos11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalActos11.Name = "lblDisplayTotalActos11"
        Me.lblDisplayTotalActos11.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplayTotalActos11.TabIndex = 11
        Me.lblDisplayTotalActos11.Text = "Al 11%"
        Me.lblDisplayTotalActos11.Visible = False
        '
        'lblTotalActos
        '
        Me.lblTotalActos.BackColor = System.Drawing.Color.White
        Me.lblTotalActos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalActos.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalActos.Location = New System.Drawing.Point(108, 105)
        Me.lblTotalActos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalActos.Name = "lblTotalActos"
        Me.lblTotalActos.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalActos.TabIndex = 10
        Me.lblTotalActos.Text = "0.00"
        Me.lblTotalActos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalActos16
        '
        Me.lblTotalActos16.BackColor = System.Drawing.Color.White
        Me.lblTotalActos16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalActos16.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalActos16.Location = New System.Drawing.Point(108, 79)
        Me.lblTotalActos16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalActos16.Name = "lblTotalActos16"
        Me.lblTotalActos16.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalActos16.TabIndex = 9
        Me.lblTotalActos16.Text = "0.00"
        Me.lblTotalActos16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalActos11
        '
        Me.lblTotalActos11.BackColor = System.Drawing.Color.White
        Me.lblTotalActos11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalActos11.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalActos11.Location = New System.Drawing.Point(266, 593)
        Me.lblTotalActos11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalActos11.Name = "lblTotalActos11"
        Me.lblTotalActos11.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalActos11.TabIndex = 8
        Me.lblTotalActos11.Text = "0.00"
        Me.lblTotalActos11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotalActos11.Visible = False
        '
        'lblDisplayTotalActos
        '
        Me.lblDisplayTotalActos.AutoSize = True
        Me.lblDisplayTotalActos.Location = New System.Drawing.Point(9, 108)
        Me.lblDisplayTotalActos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalActos.Name = "lblDisplayTotalActos"
        Me.lblDisplayTotalActos.Size = New System.Drawing.Size(40, 17)
        Me.lblDisplayTotalActos.TabIndex = 7
        Me.lblDisplayTotalActos.Text = "Total"
        '
        'lblDisplayTotalActos16
        '
        Me.lblDisplayTotalActos16.AutoSize = True
        Me.lblDisplayTotalActos16.Location = New System.Drawing.Point(9, 81)
        Me.lblDisplayTotalActos16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalActos16.Name = "lblDisplayTotalActos16"
        Me.lblDisplayTotalActos16.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplayTotalActos16.TabIndex = 6
        Me.lblDisplayTotalActos16.Text = "Al 16%"
        '
        'lblTotalActos0
        '
        Me.lblTotalActos0.BackColor = System.Drawing.Color.White
        Me.lblTotalActos0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalActos0.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalActos0.Location = New System.Drawing.Point(108, 27)
        Me.lblTotalActos0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalActos0.Name = "lblTotalActos0"
        Me.lblTotalActos0.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalActos0.TabIndex = 5
        Me.lblTotalActos0.Text = "0.00"
        Me.lblTotalActos0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalActos0
        '
        Me.lblDisplayTotalActos0.AutoSize = True
        Me.lblDisplayTotalActos0.Location = New System.Drawing.Point(9, 27)
        Me.lblDisplayTotalActos0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalActos0.Name = "lblDisplayTotalActos0"
        Me.lblDisplayTotalActos0.Size = New System.Drawing.Size(44, 17)
        Me.lblDisplayTotalActos0.TabIndex = 4
        Me.lblDisplayTotalActos0.Text = "Al 0%"
        '
        'gbGrid
        '
        Me.gbGrid.Controls.Add(Me.Grid)
        Me.gbGrid.Location = New System.Drawing.Point(0, 158)
        Me.gbGrid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbGrid.Name = "gbGrid"
        Me.gbGrid.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbGrid.Size = New System.Drawing.Size(1408, 347)
        Me.gbGrid.TabIndex = 1
        Me.gbGrid.TabStop = False
        '
        'Grid
        '
        Me.Grid.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DefaultRowHeight = CType(24, Short)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(8, 23)
        Me.Grid.LockButton = True
        Me.Grid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 2
        Me.Grid.Size = New System.Drawing.Size(1392, 316)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbTotalesIVAS
        '
        Me.gbTotalesIVAS.Controls.Add(Me.lblDisplayTotalIvaRetenido6)
        Me.gbTotalesIVAS.Controls.Add(Me.lblTotalIvaRetenido6)
        Me.gbTotalesIVAS.Controls.Add(Me.LblDisplayTotalIvaAcreditable8)
        Me.gbTotalesIVAS.Controls.Add(Me.lblTotalIvaAcreditable8)
        Me.gbTotalesIVAS.Controls.Add(Me.lblDisplayTotalIvaAcreditable16)
        Me.gbTotalesIVAS.Controls.Add(Me.lblTotalIvaRetenido10)
        Me.gbTotalesIVAS.Controls.Add(Me.lblTotalIvaRetenido4)
        Me.gbTotalesIVAS.Controls.Add(Me.lblTotalIvaAcreditable16)
        Me.gbTotalesIVAS.Controls.Add(Me.lblDisplayTotalIvaRetenido10)
        Me.gbTotalesIVAS.Controls.Add(Me.lblDisplayTotalIvaRetenido4)
        Me.gbTotalesIVAS.Location = New System.Drawing.Point(965, 512)
        Me.gbTotalesIVAS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbTotalesIVAS.Name = "gbTotalesIVAS"
        Me.gbTotalesIVAS.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbTotalesIVAS.Size = New System.Drawing.Size(328, 165)
        Me.gbTotalesIVAS.TabIndex = 192
        Me.gbTotalesIVAS.TabStop = False
        Me.gbTotalesIVAS.Text = "Totales IVAs"
        '
        'lblDisplayTotalIvaAcreditable16
        '
        Me.lblDisplayTotalIvaAcreditable16.AutoSize = True
        Me.lblDisplayTotalIvaAcreditable16.Location = New System.Drawing.Point(9, 54)
        Me.lblDisplayTotalIvaAcreditable16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalIvaAcreditable16.Name = "lblDisplayTotalIvaAcreditable16"
        Me.lblDisplayTotalIvaAcreditable16.Size = New System.Drawing.Size(134, 17)
        Me.lblDisplayTotalIvaAcreditable16.TabIndex = 11
        Me.lblDisplayTotalIvaAcreditable16.Text = "Acreditable al 16% :"
        '
        'lblTotalIvaRetenido10
        '
        Me.lblTotalIvaRetenido10.BackColor = System.Drawing.Color.White
        Me.lblTotalIvaRetenido10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIvaRetenido10.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalIvaRetenido10.Location = New System.Drawing.Point(181, 134)
        Me.lblTotalIvaRetenido10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIvaRetenido10.Name = "lblTotalIvaRetenido10"
        Me.lblTotalIvaRetenido10.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalIvaRetenido10.TabIndex = 10
        Me.lblTotalIvaRetenido10.Text = "0.00"
        Me.lblTotalIvaRetenido10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalIvaRetenido4
        '
        Me.lblTotalIvaRetenido4.BackColor = System.Drawing.Color.White
        Me.lblTotalIvaRetenido4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIvaRetenido4.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalIvaRetenido4.Location = New System.Drawing.Point(181, 79)
        Me.lblTotalIvaRetenido4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIvaRetenido4.Name = "lblTotalIvaRetenido4"
        Me.lblTotalIvaRetenido4.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalIvaRetenido4.TabIndex = 9
        Me.lblTotalIvaRetenido4.Text = "0.00"
        Me.lblTotalIvaRetenido4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalIvaAcreditable16
        '
        Me.lblTotalIvaAcreditable16.BackColor = System.Drawing.Color.White
        Me.lblTotalIvaAcreditable16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIvaAcreditable16.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalIvaAcreditable16.Location = New System.Drawing.Point(181, 53)
        Me.lblTotalIvaAcreditable16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIvaAcreditable16.Name = "lblTotalIvaAcreditable16"
        Me.lblTotalIvaAcreditable16.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalIvaAcreditable16.TabIndex = 8
        Me.lblTotalIvaAcreditable16.Text = "0.00"
        Me.lblTotalIvaAcreditable16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalIvaRetenido10
        '
        Me.lblDisplayTotalIvaRetenido10.AutoSize = True
        Me.lblDisplayTotalIvaRetenido10.Location = New System.Drawing.Point(9, 136)
        Me.lblDisplayTotalIvaRetenido10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalIvaRetenido10.Name = "lblDisplayTotalIvaRetenido10"
        Me.lblDisplayTotalIvaRetenido10.Size = New System.Drawing.Size(120, 17)
        Me.lblDisplayTotalIvaRetenido10.TabIndex = 7
        Me.lblDisplayTotalIvaRetenido10.Text = "Retenido al 10% :"
        '
        'lblDisplayTotalIvaRetenido4
        '
        Me.lblDisplayTotalIvaRetenido4.AutoSize = True
        Me.lblDisplayTotalIvaRetenido4.Location = New System.Drawing.Point(9, 81)
        Me.lblDisplayTotalIvaRetenido4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalIvaRetenido4.Name = "lblDisplayTotalIvaRetenido4"
        Me.lblDisplayTotalIvaRetenido4.Size = New System.Drawing.Size(112, 17)
        Me.lblDisplayTotalIvaRetenido4.TabIndex = 6
        Me.lblDisplayTotalIvaRetenido4.Text = "Retenido al 4% :"
        '
        'lblTotalIvaAcreditable11
        '
        Me.lblTotalIvaAcreditable11.BackColor = System.Drawing.Color.White
        Me.lblTotalIvaAcreditable11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIvaAcreditable11.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalIvaAcreditable11.Location = New System.Drawing.Point(429, 593)
        Me.lblTotalIvaAcreditable11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIvaAcreditable11.Name = "lblTotalIvaAcreditable11"
        Me.lblTotalIvaAcreditable11.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalIvaAcreditable11.TabIndex = 5
        Me.lblTotalIvaAcreditable11.Text = "0.00"
        Me.lblTotalIvaAcreditable11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotalIvaAcreditable11.Visible = False
        '
        'lblDisplayTotalIvaAcreditable11
        '
        Me.lblDisplayTotalIvaAcreditable11.AutoSize = True
        Me.lblDisplayTotalIvaAcreditable11.Location = New System.Drawing.Point(426, 568)
        Me.lblDisplayTotalIvaAcreditable11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalIvaAcreditable11.Name = "lblDisplayTotalIvaAcreditable11"
        Me.lblDisplayTotalIvaAcreditable11.Size = New System.Drawing.Size(134, 17)
        Me.lblDisplayTotalIvaAcreditable11.TabIndex = 4
        Me.lblDisplayTotalIvaAcreditable11.Text = "Acreditable al 11% :"
        Me.lblDisplayTotalIvaAcreditable11.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 539)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(392, 17)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "* Para agregar/modificar el detalle utilize F6 en los renglones"
        '
        'lblTotalActos8
        '
        Me.lblTotalActos8.BackColor = System.Drawing.Color.White
        Me.lblTotalActos8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalActos8.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalActos8.Location = New System.Drawing.Point(108, 54)
        Me.lblTotalActos8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalActos8.Name = "lblTotalActos8"
        Me.lblTotalActos8.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalActos8.TabIndex = 231
        Me.lblTotalActos8.Text = "0.00"
        Me.lblTotalActos8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalIvaAcreditable8
        '
        Me.lblTotalIvaAcreditable8.BackColor = System.Drawing.Color.White
        Me.lblTotalIvaAcreditable8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIvaAcreditable8.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalIvaAcreditable8.Location = New System.Drawing.Point(181, 27)
        Me.lblTotalIvaAcreditable8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIvaAcreditable8.Name = "lblTotalIvaAcreditable8"
        Me.lblTotalIvaAcreditable8.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalIvaAcreditable8.TabIndex = 231
        Me.lblTotalIvaAcreditable8.Text = "0.00"
        Me.lblTotalIvaAcreditable8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDisplayTotalIvaAcreditable8
        '
        Me.LblDisplayTotalIvaAcreditable8.AutoSize = True
        Me.LblDisplayTotalIvaAcreditable8.Location = New System.Drawing.Point(9, 29)
        Me.LblDisplayTotalIvaAcreditable8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTotalIvaAcreditable8.Name = "LblDisplayTotalIvaAcreditable8"
        Me.LblDisplayTotalIvaAcreditable8.Size = New System.Drawing.Size(134, 17)
        Me.LblDisplayTotalIvaAcreditable8.TabIndex = 231
        Me.LblDisplayTotalIvaAcreditable8.Text = "Acreditable al 11% :"
        '
        'LblDisplayTotalActos8
        '
        Me.LblDisplayTotalActos8.AutoSize = True
        Me.LblDisplayTotalActos8.Location = New System.Drawing.Point(9, 54)
        Me.LblDisplayTotalActos8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayTotalActos8.Name = "LblDisplayTotalActos8"
        Me.LblDisplayTotalActos8.Size = New System.Drawing.Size(44, 17)
        Me.LblDisplayTotalActos8.TabIndex = 231
        Me.LblDisplayTotalActos8.Text = "Al 8%"
        '
        'lblTotalIvaRetenido6
        '
        Me.lblTotalIvaRetenido6.BackColor = System.Drawing.Color.White
        Me.lblTotalIvaRetenido6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIvaRetenido6.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalIvaRetenido6.Location = New System.Drawing.Point(181, 106)
        Me.lblTotalIvaRetenido6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalIvaRetenido6.Name = "lblTotalIvaRetenido6"
        Me.lblTotalIvaRetenido6.Size = New System.Drawing.Size(138, 20)
        Me.lblTotalIvaRetenido6.TabIndex = 232
        Me.lblTotalIvaRetenido6.Text = "0.00"
        Me.lblTotalIvaRetenido6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalIvaRetenido6
        '
        Me.lblDisplayTotalIvaRetenido6.AutoSize = True
        Me.lblDisplayTotalIvaRetenido6.Location = New System.Drawing.Point(9, 108)
        Me.lblDisplayTotalIvaRetenido6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalIvaRetenido6.Name = "lblDisplayTotalIvaRetenido6"
        Me.lblDisplayTotalIvaRetenido6.Size = New System.Drawing.Size(112, 17)
        Me.lblDisplayTotalIvaRetenido6.TabIndex = 233
        Me.lblDisplayTotalIvaRetenido6.Text = "Retenido al 6% :"
        '
        'lblIvaAcreditableACubrir8
        '
        Me.lblIvaAcreditableACubrir8.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir8.ForeColor = System.Drawing.Color.Red
        Me.lblIvaAcreditableACubrir8.Location = New System.Drawing.Point(107, 19)
        Me.lblIvaAcreditableACubrir8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableACubrir8.Name = "lblIvaAcreditableACubrir8"
        Me.lblIvaAcreditableACubrir8.Size = New System.Drawing.Size(138, 20)
        Me.lblIvaAcreditableACubrir8.TabIndex = 230
        Me.lblIvaAcreditableACubrir8.Text = "0.00"
        Me.lblIvaAcreditableACubrir8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayTotalIvaAcreditableACubrir8
        '
        Me.lblDisplayTotalIvaAcreditableACubrir8.AutoSize = True
        Me.lblDisplayTotalIvaAcreditableACubrir8.Location = New System.Drawing.Point(9, 21)
        Me.lblDisplayTotalIvaAcreditableACubrir8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTotalIvaAcreditableACubrir8.Name = "lblDisplayTotalIvaAcreditableACubrir8"
        Me.lblDisplayTotalIvaAcreditableACubrir8.Size = New System.Drawing.Size(44, 17)
        Me.lblDisplayTotalIvaAcreditableACubrir8.TabIndex = 230
        Me.lblDisplayTotalIvaAcreditableACubrir8.Text = "Al 8%"
        '
        'Frm_Contabilidad_IVA_Acreditable_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1424, 710)
        Me.Controls.Add(Me.lblDisplayTotalActos11)
        Me.Controls.Add(Me.chkOcultarIVA11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbTotalesIVAS)
        Me.Controls.Add(Me.lblTotalActos11)
        Me.Controls.Add(Me.gbGrid)
        Me.Controls.Add(Me.lblTotalIvaAcreditable11)
        Me.Controls.Add(Me.gbTotalesActos)
        Me.Controls.Add(Me.lblDisplayTotalIvaAcreditable11)
        Me.Controls.Add(Me.gbDatosGenerales)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_IVA_Acreditable_Global"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IVA acreditable"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.gbDatosGenerales.ResumeLayout(False)
        Me.gbDatosGenerales.PerformLayout()
        Me.gbIVAsACubrir.ResumeLayout(False)
        Me.gbIVAsACubrir.PerformLayout()
        Me.gbTotalesActos.ResumeLayout(False)
        Me.gbTotalesActos.PerformLayout()
        Me.gbGrid.ResumeLayout(False)
        Me.gbTotalesIVAS.ResumeLayout(False)
        Me.gbTotalesIVAS.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbReactivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents gbTotalesActos As System.Windows.Forms.GroupBox
    Friend WithEvents gbGrid As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayTotalActos0 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalActos As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalActos16 As System.Windows.Forms.Label
    Friend WithEvents lblTotalActos0 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalActos11 As System.Windows.Forms.Label
    Friend WithEvents lblTotalActos As System.Windows.Forms.Label
    Friend WithEvents lblTotalActos16 As System.Windows.Forms.Label
    Friend WithEvents lblTotalActos11 As System.Windows.Forms.Label
    Friend WithEvents gbTotalesIVAS As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayTotalIvaAcreditable16 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIvaRetenido10 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIvaRetenido4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIvaAcreditable16 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalIvaRetenido10 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalIvaRetenido4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIvaAcreditable11 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalIvaAcreditable11 As System.Windows.Forms.Label
    Friend WithEvents gbIVAsACubrir As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayIvaAcreditableACubrir16 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableACubrir16 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableACubrir11 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaAcreditableACubrir11 As System.Windows.Forms.Label
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents dtFechaCaptura As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayFechaCaptura As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtFechaControl As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayFechaControl As System.Windows.Forms.Label
    Friend WithEvents chkOcultarIVA11 As System.Windows.Forms.CheckBox
    Friend WithEvents lblDisplayTotalIvaAcreditableACubrir8 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableACubrir8 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayTotalActos8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalActos8 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalIvaRetenido6 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIvaRetenido6 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayTotalIvaAcreditable8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIvaAcreditable8 As System.Windows.Forms.Label
End Class
