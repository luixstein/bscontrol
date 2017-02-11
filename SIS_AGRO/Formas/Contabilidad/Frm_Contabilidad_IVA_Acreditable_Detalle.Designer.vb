<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_IVA_Acreditable_Detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_IVA_Acreditable_Detalle))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbPeriodoUltimaOperacion = New System.Windows.Forms.GroupBox()
        Me.lblDisplayMes = New System.Windows.Forms.Label()
        Me.lblDisplayAño = New System.Windows.Forms.Label()
        Me.txtAño = New System.Windows.Forms.TextBox()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.gbNumeroOperaciones = New System.Windows.Forms.GroupBox()
        Me.txtNumeroOperaciones = New System.Windows.Forms.TextBox()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.cboTipoProveedor = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTipoProveedor = New System.Windows.Forms.Label()
        Me.lblDisplayProveedor = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.lblProveedorNombre = New System.Windows.Forms.Label()
        Me.lblProveedorRFC = New System.Windows.Forms.Label()
        Me.gbActos = New System.Windows.Forms.GroupBox()
        Me.lblDisplayActosTotal = New System.Windows.Forms.Label()
        Me.lblActosTotal = New System.Windows.Forms.Label()
        Me.lblDisplayActos16 = New System.Windows.Forms.Label()
        Me.lblDisplayActos11 = New System.Windows.Forms.Label()
        Me.lblDisplayActos0 = New System.Windows.Forms.Label()
        Me.txtActos16 = New System.Windows.Forms.TextBox()
        Me.txtActos11 = New System.Windows.Forms.TextBox()
        Me.txtActos0 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtFechaFacturaProveedor = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.btnCalcularIVAS = New System.Windows.Forms.Button()
        Me.gbIva = New System.Windows.Forms.GroupBox()
        Me.lblIvaAcreditablePorCubrir16 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditablePorCubrir11 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableACubrir16 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableACubrir11 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableAcumulado16 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableAcumulado11 = New System.Windows.Forms.Label()
        Me.lblDispalyIvaAcreditablePorCubrir = New System.Windows.Forms.Label()
        Me.lblDisplayIvaAcreditableACubrir = New System.Windows.Forms.Label()
        Me.lblDisplayIvaAcreditableAcumulado = New System.Windows.Forms.Label()
        Me.lblDisplayIvaRetenido10 = New System.Windows.Forms.Label()
        Me.lblDisplayIvaRetenido4 = New System.Windows.Forms.Label()
        Me.lblDisplayIvaAcreditable16 = New System.Windows.Forms.Label()
        Me.lblDisplayIvaAcreditable11 = New System.Windows.Forms.Label()
        Me.txtIvaRetenido10 = New System.Windows.Forms.TextBox()
        Me.txtIvaAcreditable16 = New System.Windows.Forms.TextBox()
        Me.txtIvaRetenido4 = New System.Windows.Forms.TextBox()
        Me.txtIvaAcreditable11 = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.tsMenu.SuspendLayout()
        Me.gbPeriodoUltimaOperacion.SuspendLayout()
        Me.gbNumeroOperaciones.SuspendLayout()
        Me.gbProveedor.SuspendLayout()
        Me.gbActos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbIva.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbAgregar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(792, 25)
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
        'tsbAgregar
        '
        Me.tsbAgregar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregar.Name = "tsbAgregar"
        Me.tsbAgregar.Size = New System.Drawing.Size(69, 22)
        Me.tsbAgregar.Text = "&Agregar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbPeriodoUltimaOperacion
        '
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.lblDisplayMes)
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.lblDisplayAño)
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.txtAño)
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.cboMes)
        Me.gbPeriodoUltimaOperacion.Location = New System.Drawing.Point(332, 28)
        Me.gbPeriodoUltimaOperacion.Name = "gbPeriodoUltimaOperacion"
        Me.gbPeriodoUltimaOperacion.Size = New System.Drawing.Size(194, 46)
        Me.gbPeriodoUltimaOperacion.TabIndex = 1
        Me.gbPeriodoUltimaOperacion.TabStop = False
        Me.gbPeriodoUltimaOperacion.Text = "Periodo última operación"
        '
        'lblDisplayMes
        '
        Me.lblDisplayMes.AutoSize = True
        Me.lblDisplayMes.Location = New System.Drawing.Point(6, 20)
        Me.lblDisplayMes.Name = "lblDisplayMes"
        Me.lblDisplayMes.Size = New System.Drawing.Size(33, 13)
        Me.lblDisplayMes.TabIndex = 9
        Me.lblDisplayMes.Text = "Mes :"
        '
        'lblDisplayAño
        '
        Me.lblDisplayAño.AutoSize = True
        Me.lblDisplayAño.Location = New System.Drawing.Point(93, 21)
        Me.lblDisplayAño.Name = "lblDisplayAño"
        Me.lblDisplayAño.Size = New System.Drawing.Size(32, 13)
        Me.lblDisplayAño.TabIndex = 8
        Me.lblDisplayAño.Text = "Año :"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(131, 18)
        Me.txtAño.MaxLength = 4
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(57, 20)
        Me.txtAño.TabIndex = 1
        '
        'cboMes
        '
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cboMes.Location = New System.Drawing.Point(39, 17)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(48, 21)
        Me.cboMes.TabIndex = 0
        '
        'gbNumeroOperaciones
        '
        Me.gbNumeroOperaciones.Controls.Add(Me.txtNumeroOperaciones)
        Me.gbNumeroOperaciones.Location = New System.Drawing.Point(532, 28)
        Me.gbNumeroOperaciones.Name = "gbNumeroOperaciones"
        Me.gbNumeroOperaciones.Size = New System.Drawing.Size(126, 46)
        Me.gbNumeroOperaciones.TabIndex = 2
        Me.gbNumeroOperaciones.TabStop = False
        Me.gbNumeroOperaciones.Text = "Numero operaciones"
        '
        'txtNumeroOperaciones
        '
        Me.txtNumeroOperaciones.Location = New System.Drawing.Point(25, 18)
        Me.txtNumeroOperaciones.MaxLength = 4
        Me.txtNumeroOperaciones.Name = "txtNumeroOperaciones"
        Me.txtNumeroOperaciones.Size = New System.Drawing.Size(57, 20)
        Me.txtNumeroOperaciones.TabIndex = 0
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.cboTipoProveedor)
        Me.gbProveedor.Controls.Add(Me.lblDisplayTipoProveedor)
        Me.gbProveedor.Controls.Add(Me.lblDisplayProveedor)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.lblProveedorNombre)
        Me.gbProveedor.Controls.Add(Me.lblProveedorRFC)
        Me.gbProveedor.Location = New System.Drawing.Point(0, 80)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(784, 70)
        Me.gbProveedor.TabIndex = 0
        Me.gbProveedor.TabStop = False
        '
        'cboTipoProveedor
        '
        Me.cboTipoProveedor.Enabled = False
        Me.cboTipoProveedor.FormattingEnabled = True
        Me.cboTipoProveedor.Location = New System.Drawing.Point(103, 39)
        Me.cboTipoProveedor.Name = "cboTipoProveedor"
        Me.cboTipoProveedor.Size = New System.Drawing.Size(197, 21)
        Me.cboTipoProveedor.TabIndex = 2
        '
        'lblDisplayTipoProveedor
        '
        Me.lblDisplayTipoProveedor.AutoSize = True
        Me.lblDisplayTipoProveedor.Location = New System.Drawing.Point(12, 42)
        Me.lblDisplayTipoProveedor.Name = "lblDisplayTipoProveedor"
        Me.lblDisplayTipoProveedor.Size = New System.Drawing.Size(85, 13)
        Me.lblDisplayTipoProveedor.TabIndex = 132
        Me.lblDisplayTipoProveedor.Text = "Tipo proveedor :"
        '
        'lblDisplayProveedor
        '
        Me.lblDisplayProveedor.AutoSize = True
        Me.lblDisplayProveedor.Location = New System.Drawing.Point(12, 16)
        Me.lblDisplayProveedor.Name = "lblDisplayProveedor"
        Me.lblDisplayProveedor.Size = New System.Drawing.Size(62, 13)
        Me.lblDisplayProveedor.TabIndex = 4
        Me.lblDisplayProveedor.Text = "Proveedor :"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(103, 13)
        Me.txtProveedor.MaxLength = 8
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(100, 20)
        Me.txtProveedor.TabIndex = 1
        '
        'lblProveedorNombre
        '
        Me.lblProveedorNombre.Location = New System.Drawing.Point(321, 16)
        Me.lblProveedorNombre.Name = "lblProveedorNombre"
        Me.lblProveedorNombre.Size = New System.Drawing.Size(455, 13)
        Me.lblProveedorNombre.TabIndex = 2
        Me.lblProveedorNombre.Text = "."
        '
        'lblProveedorRFC
        '
        Me.lblProveedorRFC.Location = New System.Drawing.Point(205, 16)
        Me.lblProveedorRFC.Name = "lblProveedorRFC"
        Me.lblProveedorRFC.Size = New System.Drawing.Size(110, 13)
        Me.lblProveedorRFC.TabIndex = 1
        Me.lblProveedorRFC.Text = "."
        '
        'gbActos
        '
        Me.gbActos.Controls.Add(Me.lblDisplayActosTotal)
        Me.gbActos.Controls.Add(Me.lblActosTotal)
        Me.gbActos.Controls.Add(Me.lblDisplayActos16)
        Me.gbActos.Controls.Add(Me.lblDisplayActos11)
        Me.gbActos.Controls.Add(Me.lblDisplayActos0)
        Me.gbActos.Controls.Add(Me.txtActos16)
        Me.gbActos.Controls.Add(Me.txtActos11)
        Me.gbActos.Controls.Add(Me.txtActos0)
        Me.gbActos.Location = New System.Drawing.Point(6, 112)
        Me.gbActos.Name = "gbActos"
        Me.gbActos.Size = New System.Drawing.Size(181, 138)
        Me.gbActos.TabIndex = 3
        Me.gbActos.TabStop = False
        Me.gbActos.Text = "Actos "
        '
        'lblDisplayActosTotal
        '
        Me.lblDisplayActosTotal.AutoSize = True
        Me.lblDisplayActosTotal.Location = New System.Drawing.Point(7, 114)
        Me.lblDisplayActosTotal.Name = "lblDisplayActosTotal"
        Me.lblDisplayActosTotal.Size = New System.Drawing.Size(34, 13)
        Me.lblDisplayActosTotal.TabIndex = 24
        Me.lblDisplayActosTotal.Text = "Total "
        '
        'lblActosTotal
        '
        Me.lblActosTotal.BackColor = System.Drawing.Color.White
        Me.lblActosTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActosTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblActosTotal.Location = New System.Drawing.Point(69, 111)
        Me.lblActosTotal.Name = "lblActosTotal"
        Me.lblActosTotal.Size = New System.Drawing.Size(100, 19)
        Me.lblActosTotal.TabIndex = 23
        Me.lblActosTotal.Text = "0.00"
        Me.lblActosTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayActos16
        '
        Me.lblDisplayActos16.AutoSize = True
        Me.lblDisplayActos16.Location = New System.Drawing.Point(6, 86)
        Me.lblDisplayActos16.Name = "lblDisplayActos16"
        Me.lblDisplayActos16.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayActos16.TabIndex = 9
        Me.lblDisplayActos16.Text = "Al 16%"
        '
        'lblDisplayActos11
        '
        Me.lblDisplayActos11.AutoSize = True
        Me.lblDisplayActos11.Location = New System.Drawing.Point(6, 60)
        Me.lblDisplayActos11.Name = "lblDisplayActos11"
        Me.lblDisplayActos11.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayActos11.TabIndex = 8
        Me.lblDisplayActos11.Text = "Al 11%"
        '
        'lblDisplayActos0
        '
        Me.lblDisplayActos0.AutoSize = True
        Me.lblDisplayActos0.Location = New System.Drawing.Point(6, 34)
        Me.lblDisplayActos0.Name = "lblDisplayActos0"
        Me.lblDisplayActos0.Size = New System.Drawing.Size(33, 13)
        Me.lblDisplayActos0.TabIndex = 5
        Me.lblDisplayActos0.Text = "Al 0%"
        '
        'txtActos16
        '
        Me.txtActos16.Location = New System.Drawing.Point(69, 83)
        Me.txtActos16.MaxLength = 12
        Me.txtActos16.Name = "txtActos16"
        Me.txtActos16.Size = New System.Drawing.Size(100, 20)
        Me.txtActos16.TabIndex = 2
        Me.txtActos16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActos11
        '
        Me.txtActos11.Location = New System.Drawing.Point(69, 57)
        Me.txtActos11.MaxLength = 12
        Me.txtActos11.Name = "txtActos11"
        Me.txtActos11.Size = New System.Drawing.Size(100, 20)
        Me.txtActos11.TabIndex = 1
        Me.txtActos11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActos0
        '
        Me.txtActos0.Location = New System.Drawing.Point(69, 31)
        Me.txtActos0.MaxLength = 12
        Me.txtActos0.Name = "txtActos0"
        Me.txtActos0.Size = New System.Drawing.Size(100, 20)
        Me.txtActos0.TabIndex = 0
        Me.txtActos0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtFechaFacturaProveedor)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtConcepto)
        Me.GroupBox2.Controls.Add(Me.btnCalcularIVAS)
        Me.GroupBox2.Controls.Add(Me.gbIva)
        Me.GroupBox2.Controls.Add(Me.lblFolio)
        Me.GroupBox2.Controls.Add(Me.txtFolio)
        Me.GroupBox2.Controls.Add(Me.gbActos)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 156)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(784, 256)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha fac prov :"
        '
        'dtFechaFacturaProveedor
        '
        Me.dtFechaFacturaProveedor.CustomFormat = "dd/MMM/yyyy"
        Me.dtFechaFacturaProveedor.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaFacturaProveedor.Location = New System.Drawing.Point(103, 35)
        Me.dtFechaFacturaProveedor.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaFacturaProveedor.Name = "dtFechaFacturaProveedor"
        Me.dtFechaFacturaProveedor.Size = New System.Drawing.Size(109, 20)
        Me.dtFechaFacturaProveedor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Concepto :"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(103, 61)
        Me.txtConcepto.MaxLength = 200
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(530, 20)
        Me.txtConcepto.TabIndex = 2
        '
        'btnCalcularIVAS
        '
        Me.btnCalcularIVAS.Location = New System.Drawing.Point(271, 87)
        Me.btnCalcularIVAS.Name = "btnCalcularIVAS"
        Me.btnCalcularIVAS.Size = New System.Drawing.Size(100, 28)
        Me.btnCalcularIVAS.TabIndex = 4
        Me.btnCalcularIVAS.Text = "Calcula IVAS"
        Me.btnCalcularIVAS.UseVisualStyleBackColor = True
        '
        'gbIva
        '
        Me.gbIva.Controls.Add(Me.lblIvaAcreditablePorCubrir16)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditablePorCubrir11)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditableACubrir16)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditableACubrir11)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditableAcumulado16)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditableAcumulado11)
        Me.gbIva.Controls.Add(Me.lblDispalyIvaAcreditablePorCubrir)
        Me.gbIva.Controls.Add(Me.lblDisplayIvaAcreditableACubrir)
        Me.gbIva.Controls.Add(Me.lblDisplayIvaAcreditableAcumulado)
        Me.gbIva.Controls.Add(Me.lblDisplayIvaRetenido10)
        Me.gbIva.Controls.Add(Me.lblDisplayIvaRetenido4)
        Me.gbIva.Controls.Add(Me.lblDisplayIvaAcreditable16)
        Me.gbIva.Controls.Add(Me.lblDisplayIvaAcreditable11)
        Me.gbIva.Controls.Add(Me.txtIvaRetenido10)
        Me.gbIva.Controls.Add(Me.txtIvaAcreditable16)
        Me.gbIva.Controls.Add(Me.txtIvaRetenido4)
        Me.gbIva.Controls.Add(Me.txtIvaAcreditable11)
        Me.gbIva.Location = New System.Drawing.Point(193, 112)
        Me.gbIva.Name = "gbIva"
        Me.gbIva.Size = New System.Drawing.Size(583, 138)
        Me.gbIva.TabIndex = 5
        Me.gbIva.TabStop = False
        Me.gbIva.Text = "IVA"
        '
        'lblIvaAcreditablePorCubrir16
        '
        Me.lblIvaAcreditablePorCubrir16.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditablePorCubrir16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditablePorCubrir16.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditablePorCubrir16.Location = New System.Drawing.Point(486, 58)
        Me.lblIvaAcreditablePorCubrir16.Name = "lblIvaAcreditablePorCubrir16"
        Me.lblIvaAcreditablePorCubrir16.Size = New System.Drawing.Size(70, 17)
        Me.lblIvaAcreditablePorCubrir16.TabIndex = 31
        Me.lblIvaAcreditablePorCubrir16.Text = "0.00"
        Me.lblIvaAcreditablePorCubrir16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditablePorCubrir11
        '
        Me.lblIvaAcreditablePorCubrir11.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditablePorCubrir11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditablePorCubrir11.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditablePorCubrir11.Location = New System.Drawing.Point(486, 32)
        Me.lblIvaAcreditablePorCubrir11.Name = "lblIvaAcreditablePorCubrir11"
        Me.lblIvaAcreditablePorCubrir11.Size = New System.Drawing.Size(70, 17)
        Me.lblIvaAcreditablePorCubrir11.TabIndex = 30
        Me.lblIvaAcreditablePorCubrir11.Text = "0.00"
        Me.lblIvaAcreditablePorCubrir11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableACubrir16
        '
        Me.lblIvaAcreditableACubrir16.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir16.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableACubrir16.Location = New System.Drawing.Point(393, 58)
        Me.lblIvaAcreditableACubrir16.Name = "lblIvaAcreditableACubrir16"
        Me.lblIvaAcreditableACubrir16.Size = New System.Drawing.Size(70, 17)
        Me.lblIvaAcreditableACubrir16.TabIndex = 27
        Me.lblIvaAcreditableACubrir16.Text = "0.00"
        Me.lblIvaAcreditableACubrir16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableACubrir11
        '
        Me.lblIvaAcreditableACubrir11.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir11.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableACubrir11.Location = New System.Drawing.Point(393, 32)
        Me.lblIvaAcreditableACubrir11.Name = "lblIvaAcreditableACubrir11"
        Me.lblIvaAcreditableACubrir11.Size = New System.Drawing.Size(70, 17)
        Me.lblIvaAcreditableACubrir11.TabIndex = 26
        Me.lblIvaAcreditableACubrir11.Text = "0.00"
        Me.lblIvaAcreditableACubrir11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableAcumulado16
        '
        Me.lblIvaAcreditableAcumulado16.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableAcumulado16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableAcumulado16.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableAcumulado16.Location = New System.Drawing.Point(289, 58)
        Me.lblIvaAcreditableAcumulado16.Name = "lblIvaAcreditableAcumulado16"
        Me.lblIvaAcreditableAcumulado16.Size = New System.Drawing.Size(70, 17)
        Me.lblIvaAcreditableAcumulado16.TabIndex = 23
        Me.lblIvaAcreditableAcumulado16.Text = "0.00"
        Me.lblIvaAcreditableAcumulado16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableAcumulado11
        '
        Me.lblIvaAcreditableAcumulado11.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableAcumulado11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableAcumulado11.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableAcumulado11.Location = New System.Drawing.Point(289, 32)
        Me.lblIvaAcreditableAcumulado11.Name = "lblIvaAcreditableAcumulado11"
        Me.lblIvaAcreditableAcumulado11.Size = New System.Drawing.Size(70, 17)
        Me.lblIvaAcreditableAcumulado11.TabIndex = 22
        Me.lblIvaAcreditableAcumulado11.Text = "0.00"
        Me.lblIvaAcreditableAcumulado11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDispalyIvaAcreditablePorCubrir
        '
        Me.lblDispalyIvaAcreditablePorCubrir.AutoSize = True
        Me.lblDispalyIvaAcreditablePorCubrir.Location = New System.Drawing.Point(498, 16)
        Me.lblDispalyIvaAcreditablePorCubrir.Name = "lblDispalyIvaAcreditablePorCubrir"
        Me.lblDispalyIvaAcreditablePorCubrir.Size = New System.Drawing.Size(58, 13)
        Me.lblDispalyIvaAcreditablePorCubrir.TabIndex = 19
        Me.lblDispalyIvaAcreditablePorCubrir.Text = "Por cubrir :"
        '
        'lblDisplayIvaAcreditableACubrir
        '
        Me.lblDisplayIvaAcreditableACubrir.AutoSize = True
        Me.lblDisplayIvaAcreditableACubrir.Location = New System.Drawing.Point(414, 16)
        Me.lblDisplayIvaAcreditableACubrir.Name = "lblDisplayIvaAcreditableACubrir"
        Me.lblDisplayIvaAcreditableACubrir.Size = New System.Drawing.Size(49, 13)
        Me.lblDisplayIvaAcreditableACubrir.TabIndex = 3
        Me.lblDisplayIvaAcreditableACubrir.Text = "A cubrir :"
        '
        'lblDisplayIvaAcreditableAcumulado
        '
        Me.lblDisplayIvaAcreditableAcumulado.AutoSize = True
        Me.lblDisplayIvaAcreditableAcumulado.Location = New System.Drawing.Point(293, 16)
        Me.lblDisplayIvaAcreditableAcumulado.Name = "lblDisplayIvaAcreditableAcumulado"
        Me.lblDisplayIvaAcreditableAcumulado.Size = New System.Drawing.Size(66, 13)
        Me.lblDisplayIvaAcreditableAcumulado.TabIndex = 3
        Me.lblDisplayIvaAcreditableAcumulado.Text = "Acumulado :"
        '
        'lblDisplayIvaRetenido10
        '
        Me.lblDisplayIvaRetenido10.AutoSize = True
        Me.lblDisplayIvaRetenido10.Location = New System.Drawing.Point(16, 110)
        Me.lblDisplayIvaRetenido10.Name = "lblDisplayIvaRetenido10"
        Me.lblDisplayIvaRetenido10.Size = New System.Drawing.Size(84, 13)
        Me.lblDisplayIvaRetenido10.TabIndex = 18
        Me.lblDisplayIvaRetenido10.Text = "Retenido al 10%"
        '
        'lblDisplayIvaRetenido4
        '
        Me.lblDisplayIvaRetenido4.AutoSize = True
        Me.lblDisplayIvaRetenido4.Location = New System.Drawing.Point(16, 86)
        Me.lblDisplayIvaRetenido4.Name = "lblDisplayIvaRetenido4"
        Me.lblDisplayIvaRetenido4.Size = New System.Drawing.Size(81, 13)
        Me.lblDisplayIvaRetenido4.TabIndex = 17
        Me.lblDisplayIvaRetenido4.Text = "Retenido al  4%"
        '
        'lblDisplayIvaAcreditable16
        '
        Me.lblDisplayIvaAcreditable16.AutoSize = True
        Me.lblDisplayIvaAcreditable16.Location = New System.Drawing.Point(16, 60)
        Me.lblDisplayIvaAcreditable16.Name = "lblDisplayIvaAcreditable16"
        Me.lblDisplayIvaAcreditable16.Size = New System.Drawing.Size(94, 13)
        Me.lblDisplayIvaAcreditable16.TabIndex = 16
        Me.lblDisplayIvaAcreditable16.Text = "Acreditable al 16%"
        '
        'lblDisplayIvaAcreditable11
        '
        Me.lblDisplayIvaAcreditable11.AutoSize = True
        Me.lblDisplayIvaAcreditable11.Location = New System.Drawing.Point(16, 34)
        Me.lblDisplayIvaAcreditable11.Name = "lblDisplayIvaAcreditable11"
        Me.lblDisplayIvaAcreditable11.Size = New System.Drawing.Size(94, 13)
        Me.lblDisplayIvaAcreditable11.TabIndex = 15
        Me.lblDisplayIvaAcreditable11.Text = "Acreditable al 11%"
        '
        'txtIvaRetenido10
        '
        Me.txtIvaRetenido10.Location = New System.Drawing.Point(139, 110)
        Me.txtIvaRetenido10.MaxLength = 12
        Me.txtIvaRetenido10.Name = "txtIvaRetenido10"
        Me.txtIvaRetenido10.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaRetenido10.TabIndex = 3
        Me.txtIvaRetenido10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaAcreditable16
        '
        Me.txtIvaAcreditable16.Location = New System.Drawing.Point(139, 57)
        Me.txtIvaAcreditable16.MaxLength = 12
        Me.txtIvaAcreditable16.Name = "txtIvaAcreditable16"
        Me.txtIvaAcreditable16.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaAcreditable16.TabIndex = 1
        Me.txtIvaAcreditable16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaRetenido4
        '
        Me.txtIvaRetenido4.Location = New System.Drawing.Point(139, 83)
        Me.txtIvaRetenido4.MaxLength = 12
        Me.txtIvaRetenido4.Name = "txtIvaRetenido4"
        Me.txtIvaRetenido4.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaRetenido4.TabIndex = 2
        Me.txtIvaRetenido4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaAcreditable11
        '
        Me.txtIvaAcreditable11.Location = New System.Drawing.Point(139, 31)
        Me.txtIvaAcreditable11.MaxLength = 12
        Me.txtIvaAcreditable11.Name = "txtIvaAcreditable11"
        Me.txtIvaAcreditable11.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaAcreditable11.TabIndex = 0
        Me.txtIvaAcreditable11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(12, 12)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(77, 13)
        Me.lblFolio.TabIndex = 3
        Me.lblFolio.Text = "Folio fac prov :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(103, 9)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(109, 20)
        Me.txtFolio.TabIndex = 0
        '
        'Frm_Contabilidad_IVA_Acreditable_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 416)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbProveedor)
        Me.Controls.Add(Me.gbNumeroOperaciones)
        Me.Controls.Add(Me.gbPeriodoUltimaOperacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_IVA_Acreditable_Detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IVA acreditable detalle"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbPeriodoUltimaOperacion.ResumeLayout(False)
        Me.gbPeriodoUltimaOperacion.PerformLayout()
        Me.gbNumeroOperaciones.ResumeLayout(False)
        Me.gbNumeroOperaciones.PerformLayout()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        Me.gbActos.ResumeLayout(False)
        Me.gbActos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbIva.ResumeLayout(False)
        Me.gbIva.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbPeriodoUltimaOperacion As System.Windows.Forms.GroupBox
    Friend WithEvents txtAño As System.Windows.Forms.TextBox
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents gbNumeroOperaciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumeroOperaciones As System.Windows.Forms.TextBox
    Friend WithEvents gbProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents lblProveedorNombre As System.Windows.Forms.Label
    Friend WithEvents lblProveedorRFC As System.Windows.Forms.Label
    Friend WithEvents gbActos As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayActos16 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayActos11 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayActos0 As System.Windows.Forms.Label
    Friend WithEvents txtActos16 As System.Windows.Forms.TextBox
    Friend WithEvents txtActos11 As System.Windows.Forms.TextBox
    Friend WithEvents txtActos0 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents btnCalcularIVAS As System.Windows.Forms.Button
    Friend WithEvents gbIva As System.Windows.Forms.GroupBox
    Friend WithEvents txtIvaAcreditable16 As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaRetenido4 As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaAcreditable11 As System.Windows.Forms.TextBox
    Friend WithEvents lblDispalyIvaAcreditablePorCubrir As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaAcreditableACubrir As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaAcreditableAcumulado As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaRetenido10 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaRetenido4 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaAcreditable16 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaAcreditable11 As System.Windows.Forms.Label
    Friend WithEvents txtIvaRetenido10 As System.Windows.Forms.TextBox
    Friend WithEvents lblIvaAcreditablePorCubrir16 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditablePorCubrir11 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableACubrir16 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableACubrir11 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableAcumulado16 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableAcumulado11 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayProveedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayMes As System.Windows.Forms.Label
    Friend WithEvents lblDisplayAño As System.Windows.Forms.Label
    Friend WithEvents cboTipoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTipoProveedor As System.Windows.Forms.Label
    Friend WithEvents lblDisplayActosTotal As System.Windows.Forms.Label
    Friend WithEvents lblActosTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtFechaFacturaProveedor As System.Windows.Forms.DateTimePicker
End Class
