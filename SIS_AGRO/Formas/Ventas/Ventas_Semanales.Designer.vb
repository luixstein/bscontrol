<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas_Semanales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ventas_Semanales))
        Me.GridVentas = New FlexCell.Grid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNavegadorSemanaAdelante = New System.Windows.Forms.Button()
        Me.btnNavegadorSemanaAtras = New System.Windows.Forms.Button()
        Me.txtSemana2 = New System.Windows.Forms.TextBox()
        Me.lblDisplayTotalesVenta = New System.Windows.Forms.Label()
        Me.txtTotalPrecioPromedioA = New System.Windows.Forms.TextBox()
        Me.txtTotalVentaNetasA = New System.Windows.Forms.TextBox()
        Me.txtTotalAjustesA = New System.Windows.Forms.TextBox()
        Me.txtTotalVentaA = New System.Windows.Forms.TextBox()
        Me.txtTotalBultosA = New System.Windows.Forms.TextBox()
        Me.txtTotalPrecioPromedioS = New System.Windows.Forms.TextBox()
        Me.txtTotalVentaNetasS = New System.Windows.Forms.TextBox()
        Me.txtTotalAjustesS = New System.Windows.Forms.TextBox()
        Me.txtTotalVentaS = New System.Windows.Forms.TextBox()
        Me.txtTotalBultosS = New System.Windows.Forms.TextBox()
        Me.lblDisplayPrecioPromedio = New System.Windows.Forms.Label()
        Me.txtPrecioPromedio = New System.Windows.Forms.TextBox()
        Me.btnEliminarVenta = New System.Windows.Forms.Button()
        Me.btnAgregarVenta = New System.Windows.Forms.Button()
        Me.txtVentaNeta = New System.Windows.Forms.TextBox()
        Me.lblDisplayVentaNeta = New System.Windows.Forms.Label()
        Me.txtAjustes = New System.Windows.Forms.TextBox()
        Me.lblDisplayAjustes = New System.Windows.Forms.Label()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.lblDisplayVentas = New System.Windows.Forms.Label()
        Me.lblDisplayContrato = New System.Windows.Forms.Label()
        Me.cboContrato = New System.Windows.Forms.ComboBox()
        Me.lblDisplaySemana1 = New System.Windows.Forms.Label()
        Me.CboSemana1 = New System.Windows.Forms.ComboBox()
        Me.txtBultos = New System.Windows.Forms.TextBox()
        Me.lblDisplayBultos = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCultivo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Gastos = New System.Windows.Forms.GroupBox()
        Me.lblDisplaySaldoEstadoCuenta = New System.Windows.Forms.Label()
        Me.lblDisplaySaldo = New System.Windows.Forms.Label()
        Me.lblDisplayDiferenciaSaldo = New System.Windows.Forms.Label()
        Me.txtDiferenciaSaldo = New System.Windows.Forms.TextBox()
        Me.txtSaldoEstadoCuenta = New System.Windows.Forms.TextBox()
        Me.txtSaldoS = New System.Windows.Forms.TextBox()
        Me.txtTotalGastosA = New System.Windows.Forms.TextBox()
        Me.lblDisplayTotalesGasto = New System.Windows.Forms.Label()
        Me.txtTotalGastosS = New System.Windows.Forms.TextBox()
        Me.GridGastos = New FlexCell.Grid()
        Me.btnEliminarGasto = New System.Windows.Forms.Button()
        Me.btnAgregarGasto = New System.Windows.Forms.Button()
        Me.txtGasto = New System.Windows.Forms.TextBox()
        Me.lblDisplayImporteGasto = New System.Windows.Forms.Label()
        Me.cboGasto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTipoGasto = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldoA = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Gastos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridVentas
        '
        Me.GridVentas.CheckedImage = CType(resources.GetObject("GridVentas.CheckedImage"), System.Drawing.Bitmap)
        Me.GridVentas.Cols = 3
        Me.GridVentas.DisplayRowNumber = True
        Me.GridVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridVentas.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridVentas.Location = New System.Drawing.Point(6, 85)
        Me.GridVentas.Name = "GridVentas"
        Me.GridVentas.Rows = 2
        Me.GridVentas.Size = New System.Drawing.Size(1165, 232)
        Me.GridVentas.TabIndex = 11
        Me.GridVentas.UncheckedImage = CType(resources.GetObject("GridVentas.UncheckedImage"), System.Drawing.Bitmap)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1189, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnNavegadorSemanaAdelante)
        Me.GroupBox1.Controls.Add(Me.btnNavegadorSemanaAtras)
        Me.GroupBox1.Controls.Add(Me.txtSemana2)
        Me.GroupBox1.Controls.Add(Me.lblDisplayTotalesVenta)
        Me.GroupBox1.Controls.Add(Me.txtTotalPrecioPromedioA)
        Me.GroupBox1.Controls.Add(Me.txtTotalVentaNetasA)
        Me.GroupBox1.Controls.Add(Me.txtTotalAjustesA)
        Me.GroupBox1.Controls.Add(Me.txtTotalVentaA)
        Me.GroupBox1.Controls.Add(Me.txtTotalBultosA)
        Me.GroupBox1.Controls.Add(Me.txtTotalPrecioPromedioS)
        Me.GroupBox1.Controls.Add(Me.txtTotalVentaNetasS)
        Me.GroupBox1.Controls.Add(Me.txtTotalAjustesS)
        Me.GroupBox1.Controls.Add(Me.txtTotalVentaS)
        Me.GroupBox1.Controls.Add(Me.txtTotalBultosS)
        Me.GroupBox1.Controls.Add(Me.lblDisplayPrecioPromedio)
        Me.GroupBox1.Controls.Add(Me.txtPrecioPromedio)
        Me.GroupBox1.Controls.Add(Me.btnEliminarVenta)
        Me.GroupBox1.Controls.Add(Me.btnAgregarVenta)
        Me.GroupBox1.Controls.Add(Me.txtVentaNeta)
        Me.GroupBox1.Controls.Add(Me.GridVentas)
        Me.GroupBox1.Controls.Add(Me.lblDisplayVentaNeta)
        Me.GroupBox1.Controls.Add(Me.txtAjustes)
        Me.GroupBox1.Controls.Add(Me.lblDisplayAjustes)
        Me.GroupBox1.Controls.Add(Me.txtVenta)
        Me.GroupBox1.Controls.Add(Me.lblDisplayVentas)
        Me.GroupBox1.Controls.Add(Me.lblDisplayContrato)
        Me.GroupBox1.Controls.Add(Me.cboContrato)
        Me.GroupBox1.Controls.Add(Me.lblDisplaySemana1)
        Me.GroupBox1.Controls.Add(Me.CboSemana1)
        Me.GroupBox1.Controls.Add(Me.txtBultos)
        Me.GroupBox1.Controls.Add(Me.lblDisplayBultos)
        Me.GroupBox1.Controls.Add(Me.cboCultivo)
        Me.GroupBox1.Controls.Add(Me.lblDisplayCultivo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1177, 356)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ventas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(496, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 400
        Me.Label2.Text = "<           Semana"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(622, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(403, 13)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "|                                                       Acumulado                " & _
    "                                          |"
        '
        'btnNavegadorSemanaAdelante
        '
        Me.btnNavegadorSemanaAdelante.Location = New System.Drawing.Point(290, 18)
        Me.btnNavegadorSemanaAdelante.Name = "btnNavegadorSemanaAdelante"
        Me.btnNavegadorSemanaAdelante.Size = New System.Drawing.Size(22, 23)
        Me.btnNavegadorSemanaAdelante.TabIndex = 398
        Me.btnNavegadorSemanaAdelante.Text = ">"
        Me.btnNavegadorSemanaAdelante.UseVisualStyleBackColor = True
        '
        'btnNavegadorSemanaAtras
        '
        Me.btnNavegadorSemanaAtras.Location = New System.Drawing.Point(269, 18)
        Me.btnNavegadorSemanaAtras.Name = "btnNavegadorSemanaAtras"
        Me.btnNavegadorSemanaAtras.Size = New System.Drawing.Size(22, 23)
        Me.btnNavegadorSemanaAtras.TabIndex = 397
        Me.btnNavegadorSemanaAtras.Text = "<"
        Me.btnNavegadorSemanaAtras.UseVisualStyleBackColor = True
        '
        'txtSemana2
        '
        Me.txtSemana2.Location = New System.Drawing.Point(178, 19)
        Me.txtSemana2.MaxLength = 8
        Me.txtSemana2.Name = "txtSemana2"
        Me.txtSemana2.ReadOnly = True
        Me.txtSemana2.Size = New System.Drawing.Size(90, 20)
        Me.txtSemana2.TabIndex = 396
        '
        'lblDisplayTotalesVenta
        '
        Me.lblDisplayTotalesVenta.AutoSize = True
        Me.lblDisplayTotalesVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayTotalesVenta.Location = New System.Drawing.Point(8, 326)
        Me.lblDisplayTotalesVenta.Name = "lblDisplayTotalesVenta"
        Me.lblDisplayTotalesVenta.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplayTotalesVenta.TabIndex = 395
        Me.lblDisplayTotalesVenta.Text = "Totales  :"
        '
        'txtTotalPrecioPromedioA
        '
        Me.txtTotalPrecioPromedioA.Location = New System.Drawing.Point(976, 323)
        Me.txtTotalPrecioPromedioA.MaxLength = 8
        Me.txtTotalPrecioPromedioA.Name = "txtTotalPrecioPromedioA"
        Me.txtTotalPrecioPromedioA.ReadOnly = True
        Me.txtTotalPrecioPromedioA.Size = New System.Drawing.Size(49, 20)
        Me.txtTotalPrecioPromedioA.TabIndex = 394
        Me.txtTotalPrecioPromedioA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVentaNetasA
        '
        Me.txtTotalVentaNetasA.Location = New System.Drawing.Point(889, 323)
        Me.txtTotalVentaNetasA.MaxLength = 8
        Me.txtTotalVentaNetasA.Name = "txtTotalVentaNetasA"
        Me.txtTotalVentaNetasA.ReadOnly = True
        Me.txtTotalVentaNetasA.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalVentaNetasA.TabIndex = 393
        Me.txtTotalVentaNetasA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAjustesA
        '
        Me.txtTotalAjustesA.Location = New System.Drawing.Point(801, 323)
        Me.txtTotalAjustesA.MaxLength = 8
        Me.txtTotalAjustesA.Name = "txtTotalAjustesA"
        Me.txtTotalAjustesA.ReadOnly = True
        Me.txtTotalAjustesA.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalAjustesA.TabIndex = 392
        Me.txtTotalAjustesA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVentaA
        '
        Me.txtTotalVentaA.Location = New System.Drawing.Point(714, 323)
        Me.txtTotalVentaA.MaxLength = 8
        Me.txtTotalVentaA.Name = "txtTotalVentaA"
        Me.txtTotalVentaA.ReadOnly = True
        Me.txtTotalVentaA.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalVentaA.TabIndex = 391
        Me.txtTotalVentaA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBultosA
        '
        Me.txtTotalBultosA.Location = New System.Drawing.Point(625, 323)
        Me.txtTotalBultosA.MaxLength = 8
        Me.txtTotalBultosA.Name = "txtTotalBultosA"
        Me.txtTotalBultosA.ReadOnly = True
        Me.txtTotalBultosA.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalBultosA.TabIndex = 390
        Me.txtTotalBultosA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPrecioPromedioS
        '
        Me.txtTotalPrecioPromedioS.Location = New System.Drawing.Point(574, 323)
        Me.txtTotalPrecioPromedioS.MaxLength = 8
        Me.txtTotalPrecioPromedioS.Name = "txtTotalPrecioPromedioS"
        Me.txtTotalPrecioPromedioS.ReadOnly = True
        Me.txtTotalPrecioPromedioS.Size = New System.Drawing.Size(49, 20)
        Me.txtTotalPrecioPromedioS.TabIndex = 389
        Me.txtTotalPrecioPromedioS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVentaNetasS
        '
        Me.txtTotalVentaNetasS.Location = New System.Drawing.Point(480, 323)
        Me.txtTotalVentaNetasS.MaxLength = 8
        Me.txtTotalVentaNetasS.Name = "txtTotalVentaNetasS"
        Me.txtTotalVentaNetasS.ReadOnly = True
        Me.txtTotalVentaNetasS.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalVentaNetasS.TabIndex = 388
        Me.txtTotalVentaNetasS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalAjustesS
        '
        Me.txtTotalAjustesS.Location = New System.Drawing.Point(402, 323)
        Me.txtTotalAjustesS.MaxLength = 8
        Me.txtTotalAjustesS.Name = "txtTotalAjustesS"
        Me.txtTotalAjustesS.ReadOnly = True
        Me.txtTotalAjustesS.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalAjustesS.TabIndex = 387
        Me.txtTotalAjustesS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVentaS
        '
        Me.txtTotalVentaS.Location = New System.Drawing.Point(308, 323)
        Me.txtTotalVentaS.MaxLength = 8
        Me.txtTotalVentaS.Name = "txtTotalVentaS"
        Me.txtTotalVentaS.ReadOnly = True
        Me.txtTotalVentaS.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalVentaS.TabIndex = 386
        Me.txtTotalVentaS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBultosS
        '
        Me.txtTotalBultosS.Location = New System.Drawing.Point(230, 323)
        Me.txtTotalBultosS.MaxLength = 8
        Me.txtTotalBultosS.Name = "txtTotalBultosS"
        Me.txtTotalBultosS.ReadOnly = True
        Me.txtTotalBultosS.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalBultosS.TabIndex = 385
        Me.txtTotalBultosS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayPrecioPromedio
        '
        Me.lblDisplayPrecioPromedio.AutoSize = True
        Me.lblDisplayPrecioPromedio.Location = New System.Drawing.Point(347, 43)
        Me.lblDisplayPrecioPromedio.Name = "lblDisplayPrecioPromedio"
        Me.lblDisplayPrecioPromedio.Size = New System.Drawing.Size(49, 13)
        Me.lblDisplayPrecioPromedio.TabIndex = 384
        Me.lblDisplayPrecioPromedio.Text = "P. prom :"
        '
        'txtPrecioPromedio
        '
        Me.txtPrecioPromedio.Location = New System.Drawing.Point(350, 59)
        Me.txtPrecioPromedio.MaxLength = 20
        Me.txtPrecioPromedio.Name = "txtPrecioPromedio"
        Me.txtPrecioPromedio.ReadOnly = True
        Me.txtPrecioPromedio.Size = New System.Drawing.Size(59, 20)
        Me.txtPrecioPromedio.TabIndex = 8
        Me.txtPrecioPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEliminarVenta
        '
        Me.btnEliminarVenta.Location = New System.Drawing.Point(1096, 56)
        Me.btnEliminarVenta.Name = "btnEliminarVenta"
        Me.btnEliminarVenta.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminarVenta.TabIndex = 10
        Me.btnEliminarVenta.Text = "Eliminar"
        Me.btnEliminarVenta.UseVisualStyleBackColor = True
        '
        'btnAgregarVenta
        '
        Me.btnAgregarVenta.Location = New System.Drawing.Point(415, 56)
        Me.btnAgregarVenta.Name = "btnAgregarVenta"
        Me.btnAgregarVenta.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarVenta.TabIndex = 9
        Me.btnAgregarVenta.Text = "Agregar"
        Me.btnAgregarVenta.UseVisualStyleBackColor = True
        '
        'txtVentaNeta
        '
        Me.txtVentaNeta.Location = New System.Drawing.Point(256, 59)
        Me.txtVentaNeta.MaxLength = 20
        Me.txtVentaNeta.Name = "txtVentaNeta"
        Me.txtVentaNeta.ReadOnly = True
        Me.txtVentaNeta.Size = New System.Drawing.Size(88, 20)
        Me.txtVentaNeta.TabIndex = 7
        Me.txtVentaNeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayVentaNeta
        '
        Me.lblDisplayVentaNeta.AutoSize = True
        Me.lblDisplayVentaNeta.Location = New System.Drawing.Point(253, 43)
        Me.lblDisplayVentaNeta.Name = "lblDisplayVentaNeta"
        Me.lblDisplayVentaNeta.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayVentaNeta.TabIndex = 380
        Me.lblDisplayVentaNeta.Text = "Venta neta"
        '
        'txtAjustes
        '
        Me.txtAjustes.Location = New System.Drawing.Point(178, 59)
        Me.txtAjustes.MaxLength = 20
        Me.txtAjustes.Name = "txtAjustes"
        Me.txtAjustes.Size = New System.Drawing.Size(72, 20)
        Me.txtAjustes.TabIndex = 6
        Me.txtAjustes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayAjustes
        '
        Me.lblDisplayAjustes.AutoSize = True
        Me.lblDisplayAjustes.Location = New System.Drawing.Point(177, 43)
        Me.lblDisplayAjustes.Name = "lblDisplayAjustes"
        Me.lblDisplayAjustes.Size = New System.Drawing.Size(47, 13)
        Me.lblDisplayAjustes.TabIndex = 378
        Me.lblDisplayAjustes.Text = "Ajustes :"
        '
        'txtVenta
        '
        Me.txtVenta.Location = New System.Drawing.Point(84, 59)
        Me.txtVenta.MaxLength = 20
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.Size = New System.Drawing.Size(88, 20)
        Me.txtVenta.TabIndex = 5
        Me.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayVentas
        '
        Me.lblDisplayVentas.AutoSize = True
        Me.lblDisplayVentas.Location = New System.Drawing.Point(81, 43)
        Me.lblDisplayVentas.Name = "lblDisplayVentas"
        Me.lblDisplayVentas.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayVentas.TabIndex = 376
        Me.lblDisplayVentas.Text = "Venta :"
        '
        'lblDisplayContrato
        '
        Me.lblDisplayContrato.AutoSize = True
        Me.lblDisplayContrato.Location = New System.Drawing.Point(326, 23)
        Me.lblDisplayContrato.Name = "lblDisplayContrato"
        Me.lblDisplayContrato.Size = New System.Drawing.Size(53, 13)
        Me.lblDisplayContrato.TabIndex = 374
        Me.lblDisplayContrato.Text = "Contrato :"
        '
        'cboContrato
        '
        Me.cboContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContrato.FormattingEnabled = True
        Me.cboContrato.Location = New System.Drawing.Point(385, 19)
        Me.cboContrato.Name = "cboContrato"
        Me.cboContrato.Size = New System.Drawing.Size(242, 21)
        Me.cboContrato.TabIndex = 2
        '
        'lblDisplaySemana1
        '
        Me.lblDisplaySemana1.AutoSize = True
        Me.lblDisplaySemana1.Location = New System.Drawing.Point(7, 23)
        Me.lblDisplaySemana1.Name = "lblDisplaySemana1"
        Me.lblDisplaySemana1.Size = New System.Drawing.Size(55, 13)
        Me.lblDisplaySemana1.TabIndex = 362
        Me.lblDisplaySemana1.Text = "Semana  :"
        '
        'CboSemana1
        '
        Me.CboSemana1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSemana1.FormattingEnabled = True
        Me.CboSemana1.Location = New System.Drawing.Point(83, 19)
        Me.CboSemana1.Name = "CboSemana1"
        Me.CboSemana1.Size = New System.Drawing.Size(88, 21)
        Me.CboSemana1.TabIndex = 0
        '
        'txtBultos
        '
        Me.txtBultos.Location = New System.Drawing.Point(6, 59)
        Me.txtBultos.MaxLength = 20
        Me.txtBultos.Name = "txtBultos"
        Me.txtBultos.Size = New System.Drawing.Size(72, 20)
        Me.txtBultos.TabIndex = 4
        Me.txtBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayBultos
        '
        Me.lblDisplayBultos.AutoSize = True
        Me.lblDisplayBultos.Location = New System.Drawing.Point(7, 43)
        Me.lblDisplayBultos.Name = "lblDisplayBultos"
        Me.lblDisplayBultos.Size = New System.Drawing.Size(42, 13)
        Me.lblDisplayBultos.TabIndex = 358
        Me.lblDisplayBultos.Text = "Bultos :"
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboCultivo.Location = New System.Drawing.Point(684, 19)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(289, 21)
        Me.cboCultivo.TabIndex = 3
        '
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(633, 23)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 278
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(621, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(403, 13)
        Me.Label3.TabIndex = 401
        Me.Label3.Text = "__________________________________________________________________"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(227, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(397, 13)
        Me.Label4.TabIndex = 402
        Me.Label4.Text = "_________________________________________________________________"
        '
        'Gastos
        '
        Me.Gastos.Controls.Add(Me.Label5)
        Me.Gastos.Controls.Add(Me.txtSaldoA)
        Me.Gastos.Controls.Add(Me.lblDisplaySaldoEstadoCuenta)
        Me.Gastos.Controls.Add(Me.lblDisplaySaldo)
        Me.Gastos.Controls.Add(Me.lblDisplayDiferenciaSaldo)
        Me.Gastos.Controls.Add(Me.txtDiferenciaSaldo)
        Me.Gastos.Controls.Add(Me.txtSaldoEstadoCuenta)
        Me.Gastos.Controls.Add(Me.txtSaldoS)
        Me.Gastos.Controls.Add(Me.txtTotalGastosA)
        Me.Gastos.Controls.Add(Me.lblDisplayTotalesGasto)
        Me.Gastos.Controls.Add(Me.txtTotalGastosS)
        Me.Gastos.Controls.Add(Me.GridGastos)
        Me.Gastos.Controls.Add(Me.btnEliminarGasto)
        Me.Gastos.Controls.Add(Me.btnAgregarGasto)
        Me.Gastos.Controls.Add(Me.txtGasto)
        Me.Gastos.Controls.Add(Me.lblDisplayImporteGasto)
        Me.Gastos.Controls.Add(Me.cboGasto)
        Me.Gastos.Controls.Add(Me.lblDisplayTipoGasto)
        Me.Gastos.Location = New System.Drawing.Point(0, 390)
        Me.Gastos.Name = "Gastos"
        Me.Gastos.Size = New System.Drawing.Size(1177, 244)
        Me.Gastos.TabIndex = 1
        Me.Gastos.TabStop = False
        '
        'lblDisplaySaldoEstadoCuenta
        '
        Me.lblDisplaySaldoEstadoCuenta.AutoSize = True
        Me.lblDisplaySaldoEstadoCuenta.Location = New System.Drawing.Point(853, 221)
        Me.lblDisplaySaldoEstadoCuenta.Name = "lblDisplaySaldoEstadoCuenta"
        Me.lblDisplaySaldoEstadoCuenta.Size = New System.Drawing.Size(100, 13)
        Me.lblDisplaySaldoEstadoCuenta.TabIndex = 403
        Me.lblDisplaySaldoEstadoCuenta.Text = "Saldo edo. cuenta :"
        '
        'lblDisplaySaldo
        '
        Me.lblDisplaySaldo.AutoSize = True
        Me.lblDisplaySaldo.Location = New System.Drawing.Point(496, 221)
        Me.lblDisplaySaldo.Name = "lblDisplaySaldo"
        Me.lblDisplaySaldo.Size = New System.Drawing.Size(62, 13)
        Me.lblDisplaySaldo.TabIndex = 402
        Me.lblDisplaySaldo.Text = "Saldo sem :"
        '
        'lblDisplayDiferenciaSaldo
        '
        Me.lblDisplayDiferenciaSaldo.AutoSize = True
        Me.lblDisplayDiferenciaSaldo.Location = New System.Drawing.Point(1047, 221)
        Me.lblDisplayDiferenciaSaldo.Name = "lblDisplayDiferenciaSaldo"
        Me.lblDisplayDiferenciaSaldo.Size = New System.Drawing.Size(26, 13)
        Me.lblDisplayDiferenciaSaldo.TabIndex = 401
        Me.lblDisplayDiferenciaSaldo.Text = "Dif :"
        '
        'txtDiferenciaSaldo
        '
        Me.txtDiferenciaSaldo.Location = New System.Drawing.Point(1083, 218)
        Me.txtDiferenciaSaldo.MaxLength = 20
        Me.txtDiferenciaSaldo.Name = "txtDiferenciaSaldo"
        Me.txtDiferenciaSaldo.ReadOnly = True
        Me.txtDiferenciaSaldo.Size = New System.Drawing.Size(88, 20)
        Me.txtDiferenciaSaldo.TabIndex = 400
        Me.txtDiferenciaSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoEstadoCuenta
        '
        Me.txtSaldoEstadoCuenta.Location = New System.Drawing.Point(953, 217)
        Me.txtSaldoEstadoCuenta.MaxLength = 20
        Me.txtSaldoEstadoCuenta.Name = "txtSaldoEstadoCuenta"
        Me.txtSaldoEstadoCuenta.Size = New System.Drawing.Size(88, 20)
        Me.txtSaldoEstadoCuenta.TabIndex = 399
        Me.txtSaldoEstadoCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoS
        '
        Me.txtSaldoS.Location = New System.Drawing.Point(561, 217)
        Me.txtSaldoS.MaxLength = 20
        Me.txtSaldoS.Name = "txtSaldoS"
        Me.txtSaldoS.ReadOnly = True
        Me.txtSaldoS.Size = New System.Drawing.Size(88, 20)
        Me.txtSaldoS.TabIndex = 398
        Me.txtSaldoS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalGastosA
        '
        Me.txtTotalGastosA.Location = New System.Drawing.Point(370, 217)
        Me.txtTotalGastosA.MaxLength = 8
        Me.txtTotalGastosA.Name = "txtTotalGastosA"
        Me.txtTotalGastosA.ReadOnly = True
        Me.txtTotalGastosA.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalGastosA.TabIndex = 397
        Me.txtTotalGastosA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTotalesGasto
        '
        Me.lblDisplayTotalesGasto.AutoSize = True
        Me.lblDisplayTotalesGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDisplayTotalesGasto.Location = New System.Drawing.Point(8, 220)
        Me.lblDisplayTotalesGasto.Name = "lblDisplayTotalesGasto"
        Me.lblDisplayTotalesGasto.Size = New System.Drawing.Size(61, 13)
        Me.lblDisplayTotalesGasto.TabIndex = 396
        Me.lblDisplayTotalesGasto.Text = "Totales  :"
        '
        'txtTotalGastosS
        '
        Me.txtTotalGastosS.Location = New System.Drawing.Point(276, 217)
        Me.txtTotalGastosS.MaxLength = 8
        Me.txtTotalGastosS.Name = "txtTotalGastosS"
        Me.txtTotalGastosS.ReadOnly = True
        Me.txtTotalGastosS.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalGastosS.TabIndex = 387
        Me.txtTotalGastosS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridGastos
        '
        Me.GridGastos.CheckedImage = CType(resources.GetObject("GridGastos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridGastos.Cols = 3
        Me.GridGastos.DisplayRowNumber = True
        Me.GridGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridGastos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridGastos.Location = New System.Drawing.Point(6, 40)
        Me.GridGastos.Name = "GridGastos"
        Me.GridGastos.Rows = 2
        Me.GridGastos.Size = New System.Drawing.Size(1165, 171)
        Me.GridGastos.TabIndex = 4
        Me.GridGastos.UncheckedImage = CType(resources.GetObject("GridGastos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnEliminarGasto
        '
        Me.btnEliminarGasto.Location = New System.Drawing.Point(1096, 10)
        Me.btnEliminarGasto.Name = "btnEliminarGasto"
        Me.btnEliminarGasto.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminarGasto.TabIndex = 3
        Me.btnEliminarGasto.Text = "Eliminar"
        Me.btnEliminarGasto.UseVisualStyleBackColor = True
        '
        'btnAgregarGasto
        '
        Me.btnAgregarGasto.Location = New System.Drawing.Point(516, 10)
        Me.btnAgregarGasto.Name = "btnAgregarGasto"
        Me.btnAgregarGasto.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarGasto.TabIndex = 2
        Me.btnAgregarGasto.Text = "Agregar"
        Me.btnAgregarGasto.UseVisualStyleBackColor = True
        '
        'txtGasto
        '
        Me.txtGasto.Location = New System.Drawing.Point(422, 13)
        Me.txtGasto.MaxLength = 8
        Me.txtGasto.Name = "txtGasto"
        Me.txtGasto.Size = New System.Drawing.Size(88, 20)
        Me.txtGasto.TabIndex = 1
        Me.txtGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayImporteGasto
        '
        Me.lblDisplayImporteGasto.AutoSize = True
        Me.lblDisplayImporteGasto.Location = New System.Drawing.Point(368, 16)
        Me.lblDisplayImporteGasto.Name = "lblDisplayImporteGasto"
        Me.lblDisplayImporteGasto.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayImporteGasto.TabIndex = 358
        Me.lblDisplayImporteGasto.Text = "Gasto :"
        '
        'cboGasto
        '
        Me.cboGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGasto.FormattingEnabled = True
        Me.cboGasto.Location = New System.Drawing.Point(83, 13)
        Me.cboGasto.Name = "cboGasto"
        Me.cboGasto.Size = New System.Drawing.Size(270, 21)
        Me.cboGasto.TabIndex = 0
        '
        'lblDisplayTipoGasto
        '
        Me.lblDisplayTipoGasto.AutoSize = True
        Me.lblDisplayTipoGasto.Location = New System.Drawing.Point(8, 16)
        Me.lblDisplayTipoGasto.Name = "lblDisplayTipoGasto"
        Me.lblDisplayTipoGasto.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayTipoGasto.TabIndex = 278
        Me.lblDisplayTipoGasto.Text = "Gasto :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(659, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 405
        Me.Label5.Text = "Saldo acumulado :"
        '
        'txtSaldoA
        '
        Me.txtSaldoA.Location = New System.Drawing.Point(759, 217)
        Me.txtSaldoA.MaxLength = 20
        Me.txtSaldoA.Name = "txtSaldoA"
        Me.txtSaldoA.ReadOnly = True
        Me.txtSaldoA.Size = New System.Drawing.Size(88, 20)
        Me.txtSaldoA.TabIndex = 404
        Me.txtSaldoA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Ventas_Semanales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1189, 640)
        Me.Controls.Add(Me.Gastos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Ventas_Semanales"
        Me.Text = "Ventas semanales"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Gastos.ResumeLayout(False)
        Me.Gastos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridVentas As FlexCell.Grid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrecioPromedio As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminarVenta As System.Windows.Forms.Button
    Friend WithEvents btnAgregarVenta As System.Windows.Forms.Button
    Friend WithEvents txtVentaNeta As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayVentaNeta As System.Windows.Forms.Label
    Friend WithEvents txtAjustes As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayAjustes As System.Windows.Forms.Label
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayVentas As System.Windows.Forms.Label
    Friend WithEvents lblDisplayContrato As System.Windows.Forms.Label
    Friend WithEvents cboContrato As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplaySemana1 As System.Windows.Forms.Label
    Friend WithEvents CboSemana1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtBultos As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayBultos As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCultivo As System.Windows.Forms.Label
    Friend WithEvents Gastos As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminarGasto As System.Windows.Forms.Button
    Friend WithEvents btnAgregarGasto As System.Windows.Forms.Button
    Friend WithEvents GridGastos As FlexCell.Grid
    Friend WithEvents txtGasto As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayImporteGasto As System.Windows.Forms.Label
    Friend WithEvents cboGasto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTipoGasto As System.Windows.Forms.Label
    Friend WithEvents lblDisplayPrecioPromedio As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrecioPromedioA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalVentaNetasA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAjustesA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalVentaA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalBultosA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPrecioPromedioS As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalVentaNetasS As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAjustesS As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalVentaS As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalBultosS As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalGastosS As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTotalesVenta As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotalesGasto As System.Windows.Forms.Label
    Friend WithEvents txtSemana2 As System.Windows.Forms.TextBox
    Friend WithEvents btnNavegadorSemanaAdelante As System.Windows.Forms.Button
    Friend WithEvents btnNavegadorSemanaAtras As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalGastosA As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySaldoEstadoCuenta As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySaldo As System.Windows.Forms.Label
    Friend WithEvents lblDisplayDiferenciaSaldo As System.Windows.Forms.Label
    Friend WithEvents txtDiferenciaSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoEstadoCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoS As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoA As System.Windows.Forms.TextBox
End Class
