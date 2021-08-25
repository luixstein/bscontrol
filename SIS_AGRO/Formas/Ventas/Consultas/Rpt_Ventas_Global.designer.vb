<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Ventas_Global
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Ventas_Global))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RndTotalizadoPorCliente = New System.Windows.Forms.RadioButton()
        Me.RdnListadoDesagrupado = New System.Windows.Forms.RadioButton()
        Me.RdnPorCliente = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblIva = New System.Windows.Forms.Label()
        Me.CboIva = New System.Windows.Forms.ComboBox()
        Me.lblPlaza = New System.Windows.Forms.Label()
        Me.cboPlaza = New System.Windows.Forms.ComboBox()
        Me.CboVendedores = New System.Windows.Forms.ComboBox()
        Me.LblVendedor = New System.Windows.Forms.Label()
        Me.LblDisplayZona = New System.Windows.Forms.Label()
        Me.CboZona = New System.Windows.Forms.ComboBox()
        Me.CboMercado = New System.Windows.Forms.ComboBox()
        Me.LblDisplayMercado = New System.Windows.Forms.Label()
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.CboNegociacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDocumentos = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.CkbSaldo = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.RdnAgrupadoArticulo = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(983, 27)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(95, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdnAgrupadoArticulo)
        Me.GroupBox1.Controls.Add(Me.RndTotalizadoPorCliente)
        Me.GroupBox1.Controls.Add(Me.RdnListadoDesagrupado)
        Me.GroupBox1.Controls.Add(Me.RdnPorCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(267, 152)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'RndTotalizadoPorCliente
        '
        Me.RndTotalizadoPorCliente.AutoSize = True
        Me.RndTotalizadoPorCliente.Location = New System.Drawing.Point(21, 81)
        Me.RndTotalizadoPorCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.RndTotalizadoPorCliente.Name = "RndTotalizadoPorCliente"
        Me.RndTotalizadoPorCliente.Size = New System.Drawing.Size(165, 21)
        Me.RndTotalizadoPorCliente.TabIndex = 2
        Me.RndTotalizadoPorCliente.Text = "Totalizado por cliente"
        Me.RndTotalizadoPorCliente.UseVisualStyleBackColor = True
        '
        'RdnListadoDesagrupado
        '
        Me.RdnListadoDesagrupado.AutoSize = True
        Me.RdnListadoDesagrupado.Checked = True
        Me.RdnListadoDesagrupado.Location = New System.Drawing.Point(21, 27)
        Me.RdnListadoDesagrupado.Margin = New System.Windows.Forms.Padding(4)
        Me.RdnListadoDesagrupado.Name = "RdnListadoDesagrupado"
        Me.RdnListadoDesagrupado.Size = New System.Drawing.Size(176, 21)
        Me.RdnListadoDesagrupado.TabIndex = 1
        Me.RdnListadoDesagrupado.TabStop = True
        Me.RdnListadoDesagrupado.Text = "Listado de documentos"
        Me.RdnListadoDesagrupado.UseVisualStyleBackColor = True
        '
        'RdnPorCliente
        '
        Me.RdnPorCliente.AutoSize = True
        Me.RdnPorCliente.Location = New System.Drawing.Point(21, 53)
        Me.RdnPorCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.RdnPorCliente.Name = "RdnPorCliente"
        Me.RdnPorCliente.Size = New System.Drawing.Size(161, 21)
        Me.RdnPorCliente.TabIndex = 0
        Me.RdnPorCliente.Text = "Agrupado por cliente"
        Me.RdnPorCliente.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblIva)
        Me.GroupBox2.Controls.Add(Me.CboIva)
        Me.GroupBox2.Controls.Add(Me.lblPlaza)
        Me.GroupBox2.Controls.Add(Me.cboPlaza)
        Me.GroupBox2.Controls.Add(Me.CboVendedores)
        Me.GroupBox2.Controls.Add(Me.LblVendedor)
        Me.GroupBox2.Controls.Add(Me.LblDisplayZona)
        Me.GroupBox2.Controls.Add(Me.CboZona)
        Me.GroupBox2.Controls.Add(Me.CboMercado)
        Me.GroupBox2.Controls.Add(Me.LblDisplayMercado)
        Me.GroupBox2.Controls.Add(Me.CboTipoDocumento)
        Me.GroupBox2.Controls.Add(Me.CboAlmacen)
        Me.GroupBox2.Controls.Add(Me.CboNegociacion)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblDocumentos)
        Me.GroupBox2.Controls.Add(Me.lblAlmacen)
        Me.GroupBox2.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox2.Controls.Add(Me.TxtCliente)
        Me.GroupBox2.Controls.Add(Me.lblDisplayCliente)
        Me.GroupBox2.Controls.Add(Me.CkbSaldo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox2.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox2.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox2.Controls.Add(Me.LblEstatus)
        Me.GroupBox2.Controls.Add(Me.CboEstatus)
        Me.GroupBox2.Location = New System.Drawing.Point(291, 34)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(679, 446)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'LblIva
        '
        Me.LblIva.AutoSize = True
        Me.LblIva.Location = New System.Drawing.Point(15, 415)
        Me.LblIva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIva.Name = "LblIva"
        Me.LblIva.Size = New System.Drawing.Size(37, 17)
        Me.LblIva.TabIndex = 399
        Me.LblIva.Text = "IVA :"
        '
        'CboIva
        '
        Me.CboIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboIva.FormattingEnabled = True
        Me.CboIva.Location = New System.Drawing.Point(136, 412)
        Me.CboIva.Margin = New System.Windows.Forms.Padding(4)
        Me.CboIva.MaxLength = 1
        Me.CboIva.Name = "CboIva"
        Me.CboIva.Size = New System.Drawing.Size(165, 24)
        Me.CboIva.TabIndex = 398
        '
        'lblPlaza
        '
        Me.lblPlaza.AutoSize = True
        Me.lblPlaza.Location = New System.Drawing.Point(15, 284)
        Me.lblPlaza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlaza.Name = "lblPlaza"
        Me.lblPlaza.Size = New System.Drawing.Size(51, 17)
        Me.lblPlaza.TabIndex = 397
        Me.lblPlaza.Text = "Plaza :"
        '
        'cboPlaza
        '
        Me.cboPlaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlaza.FormattingEnabled = True
        Me.cboPlaza.Items.AddRange(New Object() {"A", "B"})
        Me.cboPlaza.Location = New System.Drawing.Point(136, 281)
        Me.cboPlaza.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPlaza.MaxLength = 1
        Me.cboPlaza.Name = "cboPlaza"
        Me.cboPlaza.Size = New System.Drawing.Size(408, 24)
        Me.cboPlaza.TabIndex = 396
        '
        'CboVendedores
        '
        Me.CboVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboVendedores.FormattingEnabled = True
        Me.CboVendedores.Location = New System.Drawing.Point(136, 379)
        Me.CboVendedores.Margin = New System.Windows.Forms.Padding(4)
        Me.CboVendedores.Name = "CboVendedores"
        Me.CboVendedores.Size = New System.Drawing.Size(408, 24)
        Me.CboVendedores.TabIndex = 395
        '
        'LblVendedor
        '
        Me.LblVendedor.AutoSize = True
        Me.LblVendedor.Location = New System.Drawing.Point(15, 382)
        Me.LblVendedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVendedor.Name = "LblVendedor"
        Me.LblVendedor.Size = New System.Drawing.Size(78, 17)
        Me.LblVendedor.TabIndex = 394
        Me.LblVendedor.Text = "Vendedor :"
        '
        'LblDisplayZona
        '
        Me.LblDisplayZona.AutoSize = True
        Me.LblDisplayZona.Location = New System.Drawing.Point(15, 316)
        Me.LblDisplayZona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayZona.Name = "LblDisplayZona"
        Me.LblDisplayZona.Size = New System.Drawing.Size(49, 17)
        Me.LblDisplayZona.TabIndex = 393
        Me.LblDisplayZona.Text = "Zona :"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Items.AddRange(New Object() {"A", "B"})
        Me.CboZona.Location = New System.Drawing.Point(136, 313)
        Me.CboZona.Margin = New System.Windows.Forms.Padding(4)
        Me.CboZona.MaxLength = 1
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(165, 24)
        Me.CboZona.TabIndex = 392
        '
        'CboMercado
        '
        Me.CboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMercado.FormattingEnabled = True
        Me.CboMercado.Location = New System.Drawing.Point(136, 347)
        Me.CboMercado.Margin = New System.Windows.Forms.Padding(4)
        Me.CboMercado.Name = "CboMercado"
        Me.CboMercado.Size = New System.Drawing.Size(408, 24)
        Me.CboMercado.TabIndex = 390
        '
        'LblDisplayMercado
        '
        Me.LblDisplayMercado.AutoSize = True
        Me.LblDisplayMercado.Location = New System.Drawing.Point(13, 349)
        Me.LblDisplayMercado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayMercado.Name = "LblDisplayMercado"
        Me.LblDisplayMercado.Size = New System.Drawing.Size(71, 17)
        Me.LblDisplayMercado.TabIndex = 391
        Me.LblDisplayMercado.Text = "Mercado :"
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Location = New System.Drawing.Point(136, 188)
        Me.CboTipoDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(408, 24)
        Me.CboTipoDocumento.TabIndex = 385
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(136, 159)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(408, 24)
        Me.CboAlmacen.TabIndex = 384
        '
        'CboNegociacion
        '
        Me.CboNegociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboNegociacion.FormattingEnabled = True
        Me.CboNegociacion.Location = New System.Drawing.Point(136, 218)
        Me.CboNegociacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CboNegociacion.Name = "CboNegociacion"
        Me.CboNegociacion.Size = New System.Drawing.Size(408, 24)
        Me.CboNegociacion.TabIndex = 386
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 222)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 17)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "Tipo de pago :"
        '
        'lblDocumentos
        '
        Me.lblDocumentos.AutoSize = True
        Me.lblDocumentos.Location = New System.Drawing.Point(15, 192)
        Me.lblDocumentos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDocumentos.Name = "lblDocumentos"
        Me.lblDocumentos.Size = New System.Drawing.Size(88, 17)
        Me.lblDocumentos.TabIndex = 388
        Me.lblDocumentos.Text = "Documento :"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Location = New System.Drawing.Point(15, 162)
        Me.lblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.lblAlmacen.TabIndex = 387
        Me.lblAlmacen.Text = "Almacén :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(207, 124)
        Me.lblNombreCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(464, 21)
        Me.lblNombreCliente.TabIndex = 383
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(87, 121)
        Me.TxtCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(95, 22)
        Me.TxtCliente.TabIndex = 381
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(15, 124)
        Me.lblDisplayCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(59, 17)
        Me.lblDisplayCliente.TabIndex = 382
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'CkbSaldo
        '
        Me.CkbSaldo.AutoSize = True
        Me.CkbSaldo.Location = New System.Drawing.Point(68, 85)
        Me.CkbSaldo.Margin = New System.Windows.Forms.Padding(4)
        Me.CkbSaldo.Name = "CkbSaldo"
        Me.CkbSaldo.Size = New System.Drawing.Size(281, 21)
        Me.CkbSaldo.TabIndex = 380
        Me.CkbSaldo.Text = "Mostrar solo documentos con saldos >0"
        Me.CkbSaldo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 379
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(136, 53)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaHasta.TabIndex = 377
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(15, 27)
        Me.LblDisplayFechaNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(92, 17)
        Me.LblDisplayFechaNacimiento.TabIndex = 378
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(136, 22)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaDesde.TabIndex = 376
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(15, 251)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 375
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(136, 249)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(408, 24)
        Me.CboEstatus.TabIndex = 374
        '
        'RdnAgrupadoArticulo
        '
        Me.RdnAgrupadoArticulo.AutoSize = True
        Me.RdnAgrupadoArticulo.Location = New System.Drawing.Point(21, 108)
        Me.RdnAgrupadoArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.RdnAgrupadoArticulo.Name = "RdnAgrupadoArticulo"
        Me.RdnAgrupadoArticulo.Size = New System.Drawing.Size(166, 21)
        Me.RdnAgrupadoArticulo.TabIndex = 3
        Me.RdnAgrupadoArticulo.Text = "Agrupado por artículo"
        Me.RdnAgrupadoArticulo.UseVisualStyleBackColor = True
        '
        'Rpt_Ventas_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 488)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Ventas_Global"
        Me.Text = "Global de ventas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RndTotalizadoPorCliente As System.Windows.Forms.RadioButton
    Friend WithEvents RdnListadoDesagrupado As System.Windows.Forms.RadioButton
    Friend WithEvents RdnPorCliente As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents CkbSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents CboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents CboNegociacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDocumentos As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents CboMercado As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayMercado As System.Windows.Forms.Label
    Friend WithEvents LblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents CboVendedores As System.Windows.Forms.ComboBox
    Friend WithEvents LblVendedor As System.Windows.Forms.Label
    Friend WithEvents lblPlaza As System.Windows.Forms.Label
    Friend WithEvents cboPlaza As System.Windows.Forms.ComboBox
    Friend WithEvents LblIva As System.Windows.Forms.Label
    Friend WithEvents CboIva As System.Windows.Forms.ComboBox
    Friend WithEvents RdnAgrupadoArticulo As System.Windows.Forms.RadioButton
End Class
