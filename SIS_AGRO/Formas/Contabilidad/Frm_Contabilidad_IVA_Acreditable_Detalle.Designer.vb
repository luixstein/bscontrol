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
        Me.lblDisplayActos8 = New System.Windows.Forms.Label()
        Me.txtActos8 = New System.Windows.Forms.TextBox()
        Me.lblDisplayActosTotal = New System.Windows.Forms.Label()
        Me.lblActosTotal = New System.Windows.Forms.Label()
        Me.lblDisplayActos16 = New System.Windows.Forms.Label()
        Me.lblDisplayActos0 = New System.Windows.Forms.Label()
        Me.txtActos16 = New System.Windows.Forms.TextBox()
        Me.txtActos0 = New System.Windows.Forms.TextBox()
        Me.lblDisplayActos11 = New System.Windows.Forms.Label()
        Me.txtActos11 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtFechaFacturaProveedor = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.btnCalcularIVAS = New System.Windows.Forms.Button()
        Me.gbIva = New System.Windows.Forms.GroupBox()
        Me.lblDisplayIvaAcreditable8 = New System.Windows.Forms.Label()
        Me.txtIvaAcreditable8 = New System.Windows.Forms.TextBox()
        Me.lblIvaAcreditablePorCubrir8 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableACubrir8 = New System.Windows.Forms.Label()
        Me.lblIvaAcreditableAcumulado8 = New System.Windows.Forms.Label()
        Me.lblDisplayIvaRetenido6 = New System.Windows.Forms.Label()
        Me.txtIvaRetenido6 = New System.Windows.Forms.TextBox()
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
        Me.lblDisplayActosExento = New System.Windows.Forms.Label()
        Me.txtActosExento = New System.Windows.Forms.TextBox()
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
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbAgregar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1056, 27)
        Me.tsMenu.TabIndex = 4
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
        'tsbAgregar
        '
        Me.tsbAgregar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAgregar.Name = "tsbAgregar"
        Me.tsbAgregar.Size = New System.Drawing.Size(87, 24)
        Me.tsbAgregar.Text = "&Agregar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'gbPeriodoUltimaOperacion
        '
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.lblDisplayMes)
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.lblDisplayAño)
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.txtAño)
        Me.gbPeriodoUltimaOperacion.Controls.Add(Me.cboMes)
        Me.gbPeriodoUltimaOperacion.Location = New System.Drawing.Point(443, 34)
        Me.gbPeriodoUltimaOperacion.Margin = New System.Windows.Forms.Padding(4)
        Me.gbPeriodoUltimaOperacion.Name = "gbPeriodoUltimaOperacion"
        Me.gbPeriodoUltimaOperacion.Padding = New System.Windows.Forms.Padding(4)
        Me.gbPeriodoUltimaOperacion.Size = New System.Drawing.Size(259, 57)
        Me.gbPeriodoUltimaOperacion.TabIndex = 1
        Me.gbPeriodoUltimaOperacion.TabStop = False
        Me.gbPeriodoUltimaOperacion.Text = "Periodo última operación"
        '
        'lblDisplayMes
        '
        Me.lblDisplayMes.AutoSize = True
        Me.lblDisplayMes.Location = New System.Drawing.Point(8, 25)
        Me.lblDisplayMes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayMes.Name = "lblDisplayMes"
        Me.lblDisplayMes.Size = New System.Drawing.Size(42, 17)
        Me.lblDisplayMes.TabIndex = 9
        Me.lblDisplayMes.Text = "Mes :"
        '
        'lblDisplayAño
        '
        Me.lblDisplayAño.AutoSize = True
        Me.lblDisplayAño.Location = New System.Drawing.Point(124, 26)
        Me.lblDisplayAño.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayAño.Name = "lblDisplayAño"
        Me.lblDisplayAño.Size = New System.Drawing.Size(41, 17)
        Me.lblDisplayAño.TabIndex = 8
        Me.lblDisplayAño.Text = "Año :"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(175, 22)
        Me.txtAño.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAño.MaxLength = 4
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(75, 22)
        Me.txtAño.TabIndex = 1
        '
        'cboMes
        '
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cboMes.Location = New System.Drawing.Point(52, 21)
        Me.cboMes.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(63, 24)
        Me.cboMes.TabIndex = 0
        '
        'gbNumeroOperaciones
        '
        Me.gbNumeroOperaciones.Controls.Add(Me.txtNumeroOperaciones)
        Me.gbNumeroOperaciones.Location = New System.Drawing.Point(709, 34)
        Me.gbNumeroOperaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.gbNumeroOperaciones.Name = "gbNumeroOperaciones"
        Me.gbNumeroOperaciones.Padding = New System.Windows.Forms.Padding(4)
        Me.gbNumeroOperaciones.Size = New System.Drawing.Size(168, 57)
        Me.gbNumeroOperaciones.TabIndex = 2
        Me.gbNumeroOperaciones.TabStop = False
        Me.gbNumeroOperaciones.Text = "Numero operaciones"
        '
        'txtNumeroOperaciones
        '
        Me.txtNumeroOperaciones.Location = New System.Drawing.Point(33, 22)
        Me.txtNumeroOperaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumeroOperaciones.MaxLength = 4
        Me.txtNumeroOperaciones.Name = "txtNumeroOperaciones"
        Me.txtNumeroOperaciones.Size = New System.Drawing.Size(75, 22)
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
        Me.gbProveedor.Location = New System.Drawing.Point(0, 98)
        Me.gbProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Padding = New System.Windows.Forms.Padding(4)
        Me.gbProveedor.Size = New System.Drawing.Size(1045, 86)
        Me.gbProveedor.TabIndex = 0
        Me.gbProveedor.TabStop = False
        '
        'cboTipoProveedor
        '
        Me.cboTipoProveedor.Enabled = False
        Me.cboTipoProveedor.FormattingEnabled = True
        Me.cboTipoProveedor.Location = New System.Drawing.Point(137, 48)
        Me.cboTipoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoProveedor.Name = "cboTipoProveedor"
        Me.cboTipoProveedor.Size = New System.Drawing.Size(261, 24)
        Me.cboTipoProveedor.TabIndex = 2
        '
        'lblDisplayTipoProveedor
        '
        Me.lblDisplayTipoProveedor.AutoSize = True
        Me.lblDisplayTipoProveedor.Location = New System.Drawing.Point(16, 52)
        Me.lblDisplayTipoProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayTipoProveedor.Name = "lblDisplayTipoProveedor"
        Me.lblDisplayTipoProveedor.Size = New System.Drawing.Size(113, 17)
        Me.lblDisplayTipoProveedor.TabIndex = 132
        Me.lblDisplayTipoProveedor.Text = "Tipo proveedor :"
        '
        'lblDisplayProveedor
        '
        Me.lblDisplayProveedor.AutoSize = True
        Me.lblDisplayProveedor.Location = New System.Drawing.Point(16, 20)
        Me.lblDisplayProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayProveedor.Name = "lblDisplayProveedor"
        Me.lblDisplayProveedor.Size = New System.Drawing.Size(82, 17)
        Me.lblDisplayProveedor.TabIndex = 4
        Me.lblDisplayProveedor.Text = "Proveedor :"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(137, 16)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProveedor.MaxLength = 8
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(132, 22)
        Me.txtProveedor.TabIndex = 1
        '
        'lblProveedorNombre
        '
        Me.lblProveedorNombre.Location = New System.Drawing.Point(428, 20)
        Me.lblProveedorNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProveedorNombre.Name = "lblProveedorNombre"
        Me.lblProveedorNombre.Size = New System.Drawing.Size(607, 16)
        Me.lblProveedorNombre.TabIndex = 2
        Me.lblProveedorNombre.Text = "."
        '
        'lblProveedorRFC
        '
        Me.lblProveedorRFC.Location = New System.Drawing.Point(273, 20)
        Me.lblProveedorRFC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProveedorRFC.Name = "lblProveedorRFC"
        Me.lblProveedorRFC.Size = New System.Drawing.Size(147, 16)
        Me.lblProveedorRFC.TabIndex = 1
        Me.lblProveedorRFC.Text = "."
        '
        'gbActos
        '
        Me.gbActos.Controls.Add(Me.lblDisplayActosExento)
        Me.gbActos.Controls.Add(Me.txtActosExento)
        Me.gbActos.Controls.Add(Me.lblDisplayActos8)
        Me.gbActos.Controls.Add(Me.txtActos8)
        Me.gbActos.Controls.Add(Me.lblDisplayActosTotal)
        Me.gbActos.Controls.Add(Me.lblActosTotal)
        Me.gbActos.Controls.Add(Me.lblDisplayActos16)
        Me.gbActos.Controls.Add(Me.lblDisplayActos0)
        Me.gbActos.Controls.Add(Me.txtActos16)
        Me.gbActos.Controls.Add(Me.txtActos0)
        Me.gbActos.Location = New System.Drawing.Point(8, 138)
        Me.gbActos.Margin = New System.Windows.Forms.Padding(4)
        Me.gbActos.Name = "gbActos"
        Me.gbActos.Padding = New System.Windows.Forms.Padding(4)
        Me.gbActos.Size = New System.Drawing.Size(241, 199)
        Me.gbActos.TabIndex = 3
        Me.gbActos.TabStop = False
        Me.gbActos.Text = "Actos "
        '
        'lblDisplayActos8
        '
        Me.lblDisplayActos8.AutoSize = True
        Me.lblDisplayActos8.Location = New System.Drawing.Point(9, 73)
        Me.lblDisplayActos8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayActos8.Name = "lblDisplayActos8"
        Me.lblDisplayActos8.Size = New System.Drawing.Size(44, 17)
        Me.lblDisplayActos8.TabIndex = 9
        Me.lblDisplayActos8.Text = "Al 8%"
        '
        'txtActos8
        '
        Me.txtActos8.Location = New System.Drawing.Point(92, 71)
        Me.txtActos8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtActos8.MaxLength = 12
        Me.txtActos8.Name = "txtActos8"
        Me.txtActos8.Size = New System.Drawing.Size(132, 22)
        Me.txtActos8.TabIndex = 1
        Me.txtActos8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayActosTotal
        '
        Me.lblDisplayActosTotal.AutoSize = True
        Me.lblDisplayActosTotal.Location = New System.Drawing.Point(9, 168)
        Me.lblDisplayActosTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayActosTotal.Name = "lblDisplayActosTotal"
        Me.lblDisplayActosTotal.Size = New System.Drawing.Size(44, 17)
        Me.lblDisplayActosTotal.TabIndex = 24
        Me.lblDisplayActosTotal.Text = "Total "
        '
        'lblActosTotal
        '
        Me.lblActosTotal.BackColor = System.Drawing.Color.White
        Me.lblActosTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblActosTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblActosTotal.Location = New System.Drawing.Point(92, 165)
        Me.lblActosTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblActosTotal.Name = "lblActosTotal"
        Me.lblActosTotal.Size = New System.Drawing.Size(133, 23)
        Me.lblActosTotal.TabIndex = 23
        Me.lblActosTotal.Text = "0.00"
        Me.lblActosTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayActos16
        '
        Me.lblDisplayActos16.AutoSize = True
        Me.lblDisplayActos16.Location = New System.Drawing.Point(8, 106)
        Me.lblDisplayActos16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayActos16.Name = "lblDisplayActos16"
        Me.lblDisplayActos16.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplayActos16.TabIndex = 9
        Me.lblDisplayActos16.Text = "Al 16%"
        '
        'lblDisplayActos0
        '
        Me.lblDisplayActos0.AutoSize = True
        Me.lblDisplayActos0.Location = New System.Drawing.Point(8, 42)
        Me.lblDisplayActos0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayActos0.Name = "lblDisplayActos0"
        Me.lblDisplayActos0.Size = New System.Drawing.Size(44, 17)
        Me.lblDisplayActos0.TabIndex = 5
        Me.lblDisplayActos0.Text = "Al 0%"
        '
        'txtActos16
        '
        Me.txtActos16.Location = New System.Drawing.Point(92, 102)
        Me.txtActos16.Margin = New System.Windows.Forms.Padding(4)
        Me.txtActos16.MaxLength = 12
        Me.txtActos16.Name = "txtActos16"
        Me.txtActos16.Size = New System.Drawing.Size(132, 22)
        Me.txtActos16.TabIndex = 2
        Me.txtActos16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActos0
        '
        Me.txtActos0.Location = New System.Drawing.Point(92, 38)
        Me.txtActos0.Margin = New System.Windows.Forms.Padding(4)
        Me.txtActos0.MaxLength = 12
        Me.txtActos0.Name = "txtActos0"
        Me.txtActos0.Size = New System.Drawing.Size(132, 22)
        Me.txtActos0.TabIndex = 0
        Me.txtActos0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayActos11
        '
        Me.lblDisplayActos11.AutoSize = True
        Me.lblDisplayActos11.Location = New System.Drawing.Point(17, 116)
        Me.lblDisplayActos11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayActos11.Name = "lblDisplayActos11"
        Me.lblDisplayActos11.Size = New System.Drawing.Size(52, 17)
        Me.lblDisplayActos11.TabIndex = 8
        Me.lblDisplayActos11.Text = "Al 11%"
        Me.lblDisplayActos11.Visible = False
        '
        'txtActos11
        '
        Me.txtActos11.Location = New System.Drawing.Point(101, 113)
        Me.txtActos11.Margin = New System.Windows.Forms.Padding(4)
        Me.txtActos11.MaxLength = 12
        Me.txtActos11.Name = "txtActos11"
        Me.txtActos11.Size = New System.Drawing.Size(132, 22)
        Me.txtActos11.TabIndex = 1
        Me.txtActos11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtActos11.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtFechaFacturaProveedor)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblDisplayActos11)
        Me.GroupBox2.Controls.Add(Me.txtConcepto)
        Me.GroupBox2.Controls.Add(Me.btnCalcularIVAS)
        Me.GroupBox2.Controls.Add(Me.gbIva)
        Me.GroupBox2.Controls.Add(Me.txtActos11)
        Me.GroupBox2.Controls.Add(Me.lblFolio)
        Me.GroupBox2.Controls.Add(Me.txtFolio)
        Me.GroupBox2.Controls.Add(Me.gbActos)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 192)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1045, 345)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 43)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha fac prov :"
        '
        'dtFechaFacturaProveedor
        '
        Me.dtFechaFacturaProveedor.CustomFormat = "dd/MMM/yyyy"
        Me.dtFechaFacturaProveedor.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaFacturaProveedor.Location = New System.Drawing.Point(137, 43)
        Me.dtFechaFacturaProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.dtFechaFacturaProveedor.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaFacturaProveedor.Name = "dtFechaFacturaProveedor"
        Me.dtFechaFacturaProveedor.Size = New System.Drawing.Size(144, 22)
        Me.dtFechaFacturaProveedor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Concepto :"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(137, 75)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConcepto.MaxLength = 200
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(705, 22)
        Me.txtConcepto.TabIndex = 2
        '
        'btnCalcularIVAS
        '
        Me.btnCalcularIVAS.Location = New System.Drawing.Point(361, 107)
        Me.btnCalcularIVAS.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCalcularIVAS.Name = "btnCalcularIVAS"
        Me.btnCalcularIVAS.Size = New System.Drawing.Size(133, 34)
        Me.btnCalcularIVAS.TabIndex = 4
        Me.btnCalcularIVAS.Text = "Calcula IVAS"
        Me.btnCalcularIVAS.UseVisualStyleBackColor = True
        '
        'gbIva
        '
        Me.gbIva.Controls.Add(Me.lblDisplayIvaAcreditable8)
        Me.gbIva.Controls.Add(Me.txtIvaAcreditable8)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditablePorCubrir8)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditableACubrir8)
        Me.gbIva.Controls.Add(Me.lblIvaAcreditableAcumulado8)
        Me.gbIva.Controls.Add(Me.lblDisplayIvaRetenido6)
        Me.gbIva.Controls.Add(Me.txtIvaRetenido6)
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
        Me.gbIva.Location = New System.Drawing.Point(257, 138)
        Me.gbIva.Margin = New System.Windows.Forms.Padding(4)
        Me.gbIva.Name = "gbIva"
        Me.gbIva.Padding = New System.Windows.Forms.Padding(4)
        Me.gbIva.Size = New System.Drawing.Size(777, 199)
        Me.gbIva.TabIndex = 5
        Me.gbIva.TabStop = False
        Me.gbIva.Text = "IVA"
        '
        'lblDisplayIvaAcreditable8
        '
        Me.lblDisplayIvaAcreditable8.AutoSize = True
        Me.lblDisplayIvaAcreditable8.Location = New System.Drawing.Point(21, 42)
        Me.lblDisplayIvaAcreditable8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaAcreditable8.Name = "lblDisplayIvaAcreditable8"
        Me.lblDisplayIvaAcreditable8.Size = New System.Drawing.Size(118, 17)
        Me.lblDisplayIvaAcreditable8.TabIndex = 38
        Me.lblDisplayIvaAcreditable8.Text = "Acreditable al 8%"
        '
        'txtIvaAcreditable8
        '
        Me.txtIvaAcreditable8.Location = New System.Drawing.Point(185, 39)
        Me.txtIvaAcreditable8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaAcreditable8.MaxLength = 12
        Me.txtIvaAcreditable8.Name = "txtIvaAcreditable8"
        Me.txtIvaAcreditable8.Size = New System.Drawing.Size(132, 22)
        Me.txtIvaAcreditable8.TabIndex = 0
        Me.txtIvaAcreditable8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIvaAcreditablePorCubrir8
        '
        Me.lblIvaAcreditablePorCubrir8.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditablePorCubrir8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditablePorCubrir8.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditablePorCubrir8.Location = New System.Drawing.Point(648, 39)
        Me.lblIvaAcreditablePorCubrir8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditablePorCubrir8.Name = "lblIvaAcreditablePorCubrir8"
        Me.lblIvaAcreditablePorCubrir8.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditablePorCubrir8.TabIndex = 36
        Me.lblIvaAcreditablePorCubrir8.Text = "0.00"
        Me.lblIvaAcreditablePorCubrir8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableACubrir8
        '
        Me.lblIvaAcreditableACubrir8.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir8.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableACubrir8.Location = New System.Drawing.Point(524, 39)
        Me.lblIvaAcreditableACubrir8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableACubrir8.Name = "lblIvaAcreditableACubrir8"
        Me.lblIvaAcreditableACubrir8.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditableACubrir8.TabIndex = 35
        Me.lblIvaAcreditableACubrir8.Text = "0.00"
        Me.lblIvaAcreditableACubrir8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableAcumulado8
        '
        Me.lblIvaAcreditableAcumulado8.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableAcumulado8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableAcumulado8.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableAcumulado8.Location = New System.Drawing.Point(385, 39)
        Me.lblIvaAcreditableAcumulado8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableAcumulado8.Name = "lblIvaAcreditableAcumulado8"
        Me.lblIvaAcreditableAcumulado8.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditableAcumulado8.TabIndex = 34
        Me.lblIvaAcreditableAcumulado8.Text = "0.00"
        Me.lblIvaAcreditableAcumulado8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDisplayIvaRetenido6
        '
        Me.lblDisplayIvaRetenido6.AutoSize = True
        Me.lblDisplayIvaRetenido6.Location = New System.Drawing.Point(21, 138)
        Me.lblDisplayIvaRetenido6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaRetenido6.Name = "lblDisplayIvaRetenido6"
        Me.lblDisplayIvaRetenido6.Size = New System.Drawing.Size(108, 17)
        Me.lblDisplayIvaRetenido6.TabIndex = 33
        Me.lblDisplayIvaRetenido6.Text = "Retenido al  6%"
        '
        'txtIvaRetenido6
        '
        Me.txtIvaRetenido6.Location = New System.Drawing.Point(185, 135)
        Me.txtIvaRetenido6.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaRetenido6.MaxLength = 12
        Me.txtIvaRetenido6.Name = "txtIvaRetenido6"
        Me.txtIvaRetenido6.Size = New System.Drawing.Size(132, 22)
        Me.txtIvaRetenido6.TabIndex = 3
        Me.txtIvaRetenido6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIvaAcreditablePorCubrir16
        '
        Me.lblIvaAcreditablePorCubrir16.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditablePorCubrir16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditablePorCubrir16.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditablePorCubrir16.Location = New System.Drawing.Point(648, 71)
        Me.lblIvaAcreditablePorCubrir16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditablePorCubrir16.Name = "lblIvaAcreditablePorCubrir16"
        Me.lblIvaAcreditablePorCubrir16.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditablePorCubrir16.TabIndex = 31
        Me.lblIvaAcreditablePorCubrir16.Text = "0.00"
        Me.lblIvaAcreditablePorCubrir16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditablePorCubrir11
        '
        Me.lblIvaAcreditablePorCubrir11.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditablePorCubrir11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditablePorCubrir11.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditablePorCubrir11.Location = New System.Drawing.Point(648, 150)
        Me.lblIvaAcreditablePorCubrir11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditablePorCubrir11.Name = "lblIvaAcreditablePorCubrir11"
        Me.lblIvaAcreditablePorCubrir11.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditablePorCubrir11.TabIndex = 30
        Me.lblIvaAcreditablePorCubrir11.Text = "0.00"
        Me.lblIvaAcreditablePorCubrir11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIvaAcreditablePorCubrir11.Visible = False
        '
        'lblIvaAcreditableACubrir16
        '
        Me.lblIvaAcreditableACubrir16.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir16.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableACubrir16.Location = New System.Drawing.Point(524, 71)
        Me.lblIvaAcreditableACubrir16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableACubrir16.Name = "lblIvaAcreditableACubrir16"
        Me.lblIvaAcreditableACubrir16.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditableACubrir16.TabIndex = 27
        Me.lblIvaAcreditableACubrir16.Text = "0.00"
        Me.lblIvaAcreditableACubrir16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableACubrir11
        '
        Me.lblIvaAcreditableACubrir11.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableACubrir11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableACubrir11.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableACubrir11.Location = New System.Drawing.Point(524, 150)
        Me.lblIvaAcreditableACubrir11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableACubrir11.Name = "lblIvaAcreditableACubrir11"
        Me.lblIvaAcreditableACubrir11.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditableACubrir11.TabIndex = 26
        Me.lblIvaAcreditableACubrir11.Text = "0.00"
        Me.lblIvaAcreditableACubrir11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIvaAcreditableACubrir11.Visible = False
        '
        'lblIvaAcreditableAcumulado16
        '
        Me.lblIvaAcreditableAcumulado16.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableAcumulado16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableAcumulado16.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableAcumulado16.Location = New System.Drawing.Point(385, 71)
        Me.lblIvaAcreditableAcumulado16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableAcumulado16.Name = "lblIvaAcreditableAcumulado16"
        Me.lblIvaAcreditableAcumulado16.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditableAcumulado16.TabIndex = 23
        Me.lblIvaAcreditableAcumulado16.Text = "0.00"
        Me.lblIvaAcreditableAcumulado16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIvaAcreditableAcumulado11
        '
        Me.lblIvaAcreditableAcumulado11.BackColor = System.Drawing.Color.White
        Me.lblIvaAcreditableAcumulado11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIvaAcreditableAcumulado11.ForeColor = System.Drawing.Color.Blue
        Me.lblIvaAcreditableAcumulado11.Location = New System.Drawing.Point(385, 150)
        Me.lblIvaAcreditableAcumulado11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIvaAcreditableAcumulado11.Name = "lblIvaAcreditableAcumulado11"
        Me.lblIvaAcreditableAcumulado11.Size = New System.Drawing.Size(93, 20)
        Me.lblIvaAcreditableAcumulado11.TabIndex = 22
        Me.lblIvaAcreditableAcumulado11.Text = "0.00"
        Me.lblIvaAcreditableAcumulado11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIvaAcreditableAcumulado11.Visible = False
        '
        'lblDispalyIvaAcreditablePorCubrir
        '
        Me.lblDispalyIvaAcreditablePorCubrir.AutoSize = True
        Me.lblDispalyIvaAcreditablePorCubrir.Location = New System.Drawing.Point(664, 20)
        Me.lblDispalyIvaAcreditablePorCubrir.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDispalyIvaAcreditablePorCubrir.Name = "lblDispalyIvaAcreditablePorCubrir"
        Me.lblDispalyIvaAcreditablePorCubrir.Size = New System.Drawing.Size(78, 17)
        Me.lblDispalyIvaAcreditablePorCubrir.TabIndex = 19
        Me.lblDispalyIvaAcreditablePorCubrir.Text = "Por cubrir :"
        '
        'lblDisplayIvaAcreditableACubrir
        '
        Me.lblDisplayIvaAcreditableACubrir.AutoSize = True
        Me.lblDisplayIvaAcreditableACubrir.Location = New System.Drawing.Point(552, 20)
        Me.lblDisplayIvaAcreditableACubrir.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaAcreditableACubrir.Name = "lblDisplayIvaAcreditableACubrir"
        Me.lblDisplayIvaAcreditableACubrir.Size = New System.Drawing.Size(65, 17)
        Me.lblDisplayIvaAcreditableACubrir.TabIndex = 3
        Me.lblDisplayIvaAcreditableACubrir.Text = "A cubrir :"
        '
        'lblDisplayIvaAcreditableAcumulado
        '
        Me.lblDisplayIvaAcreditableAcumulado.AutoSize = True
        Me.lblDisplayIvaAcreditableAcumulado.Location = New System.Drawing.Point(391, 20)
        Me.lblDisplayIvaAcreditableAcumulado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaAcreditableAcumulado.Name = "lblDisplayIvaAcreditableAcumulado"
        Me.lblDisplayIvaAcreditableAcumulado.Size = New System.Drawing.Size(86, 17)
        Me.lblDisplayIvaAcreditableAcumulado.TabIndex = 3
        Me.lblDisplayIvaAcreditableAcumulado.Text = "Acumulado :"
        '
        'lblDisplayIvaRetenido10
        '
        Me.lblDisplayIvaRetenido10.AutoSize = True
        Me.lblDisplayIvaRetenido10.Location = New System.Drawing.Point(21, 168)
        Me.lblDisplayIvaRetenido10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaRetenido10.Name = "lblDisplayIvaRetenido10"
        Me.lblDisplayIvaRetenido10.Size = New System.Drawing.Size(112, 17)
        Me.lblDisplayIvaRetenido10.TabIndex = 18
        Me.lblDisplayIvaRetenido10.Text = "Retenido al 10%"
        '
        'lblDisplayIvaRetenido4
        '
        Me.lblDisplayIvaRetenido4.AutoSize = True
        Me.lblDisplayIvaRetenido4.Location = New System.Drawing.Point(21, 106)
        Me.lblDisplayIvaRetenido4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaRetenido4.Name = "lblDisplayIvaRetenido4"
        Me.lblDisplayIvaRetenido4.Size = New System.Drawing.Size(108, 17)
        Me.lblDisplayIvaRetenido4.TabIndex = 17
        Me.lblDisplayIvaRetenido4.Text = "Retenido al  4%"
        '
        'lblDisplayIvaAcreditable16
        '
        Me.lblDisplayIvaAcreditable16.AutoSize = True
        Me.lblDisplayIvaAcreditable16.Location = New System.Drawing.Point(21, 74)
        Me.lblDisplayIvaAcreditable16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaAcreditable16.Name = "lblDisplayIvaAcreditable16"
        Me.lblDisplayIvaAcreditable16.Size = New System.Drawing.Size(126, 17)
        Me.lblDisplayIvaAcreditable16.TabIndex = 16
        Me.lblDisplayIvaAcreditable16.Text = "Acreditable al 16%"
        '
        'lblDisplayIvaAcreditable11
        '
        Me.lblDisplayIvaAcreditable11.AutoSize = True
        Me.lblDisplayIvaAcreditable11.Location = New System.Drawing.Point(543, 124)
        Me.lblDisplayIvaAcreditable11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayIvaAcreditable11.Name = "lblDisplayIvaAcreditable11"
        Me.lblDisplayIvaAcreditable11.Size = New System.Drawing.Size(126, 17)
        Me.lblDisplayIvaAcreditable11.TabIndex = 15
        Me.lblDisplayIvaAcreditable11.Text = "Acreditable al 11%"
        Me.lblDisplayIvaAcreditable11.Visible = False
        '
        'txtIvaRetenido10
        '
        Me.txtIvaRetenido10.Location = New System.Drawing.Point(185, 165)
        Me.txtIvaRetenido10.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaRetenido10.MaxLength = 12
        Me.txtIvaRetenido10.Name = "txtIvaRetenido10"
        Me.txtIvaRetenido10.Size = New System.Drawing.Size(132, 22)
        Me.txtIvaRetenido10.TabIndex = 4
        Me.txtIvaRetenido10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaAcreditable16
        '
        Me.txtIvaAcreditable16.Location = New System.Drawing.Point(185, 70)
        Me.txtIvaAcreditable16.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaAcreditable16.MaxLength = 12
        Me.txtIvaAcreditable16.Name = "txtIvaAcreditable16"
        Me.txtIvaAcreditable16.Size = New System.Drawing.Size(132, 22)
        Me.txtIvaAcreditable16.TabIndex = 1
        Me.txtIvaAcreditable16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaRetenido4
        '
        Me.txtIvaRetenido4.Location = New System.Drawing.Point(185, 102)
        Me.txtIvaRetenido4.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaRetenido4.MaxLength = 12
        Me.txtIvaRetenido4.Name = "txtIvaRetenido4"
        Me.txtIvaRetenido4.Size = New System.Drawing.Size(132, 22)
        Me.txtIvaRetenido4.TabIndex = 2
        Me.txtIvaRetenido4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaAcreditable11
        '
        Me.txtIvaAcreditable11.Location = New System.Drawing.Point(385, 124)
        Me.txtIvaAcreditable11.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaAcreditable11.MaxLength = 12
        Me.txtIvaAcreditable11.Name = "txtIvaAcreditable11"
        Me.txtIvaAcreditable11.Size = New System.Drawing.Size(132, 22)
        Me.txtIvaAcreditable11.TabIndex = 0
        Me.txtIvaAcreditable11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIvaAcreditable11.Visible = False
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(16, 15)
        Me.lblFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(101, 17)
        Me.lblFolio.TabIndex = 3
        Me.lblFolio.Text = "Folio fac prov :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(137, 11)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(144, 22)
        Me.txtFolio.TabIndex = 0
        '
        'lblDisplayActosExento
        '
        Me.lblDisplayActosExento.AutoSize = True
        Me.lblDisplayActosExento.Location = New System.Drawing.Point(9, 138)
        Me.lblDisplayActosExento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayActosExento.Name = "lblDisplayActosExento"
        Me.lblDisplayActosExento.Size = New System.Drawing.Size(51, 17)
        Me.lblDisplayActosExento.TabIndex = 26
        Me.lblDisplayActosExento.Text = "Exento"
        '
        'txtActosExento
        '
        Me.txtActosExento.Location = New System.Drawing.Point(92, 135)
        Me.txtActosExento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtActosExento.MaxLength = 12
        Me.txtActosExento.Name = "txtActosExento"
        Me.txtActosExento.Size = New System.Drawing.Size(132, 22)
        Me.txtActosExento.TabIndex = 25
        Me.txtActosExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frm_Contabilidad_IVA_Acreditable_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 550)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbProveedor)
        Me.Controls.Add(Me.gbNumeroOperaciones)
        Me.Controls.Add(Me.gbPeriodoUltimaOperacion)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents lblDisplayActos8 As System.Windows.Forms.Label
    Friend WithEvents txtActos8 As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayIvaAcreditable8 As System.Windows.Forms.Label
    Friend WithEvents txtIvaAcreditable8 As System.Windows.Forms.TextBox
    Friend WithEvents lblIvaAcreditablePorCubrir8 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableACubrir8 As System.Windows.Forms.Label
    Friend WithEvents lblIvaAcreditableAcumulado8 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayIvaRetenido6 As System.Windows.Forms.Label
    Friend WithEvents txtIvaRetenido6 As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayActosExento As System.Windows.Forms.Label
    Friend WithEvents txtActosExento As System.Windows.Forms.TextBox
End Class
