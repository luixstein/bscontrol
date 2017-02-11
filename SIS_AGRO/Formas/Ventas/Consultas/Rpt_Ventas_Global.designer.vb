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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RndTotalizadoPorCliente = New System.Windows.Forms.RadioButton
        Me.RdnListadoDesagrupado = New System.Windows.Forms.RadioButton
        Me.RdnPorCliente = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblDisplayZona = New System.Windows.Forms.Label
        Me.CboZona = New System.Windows.Forms.ComboBox
        Me.CboMercado = New System.Windows.Forms.ComboBox
        Me.LblDisplayMercado = New System.Windows.Forms.Label
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox
        Me.CboAlmacen = New System.Windows.Forms.ComboBox
        Me.CboNegociacion = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblDocumentos = New System.Windows.Forms.Label
        Me.lblAlmacen = New System.Windows.Forms.Label
        Me.lblNombreCliente = New System.Windows.Forms.Label
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.lblDisplayCliente = New System.Windows.Forms.Label
        Me.CkbSaldo = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.LblEstatus = New System.Windows.Forms.Label
        Me.CboEstatus = New System.Windows.Forms.ComboBox
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(737, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "&Consultar"
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
        Me.GroupBox1.Controls.Add(Me.RndTotalizadoPorCliente)
        Me.GroupBox1.Controls.Add(Me.RdnListadoDesagrupado)
        Me.GroupBox1.Controls.Add(Me.RdnPorCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reportes"
        '
        'RndTotalizadoPorCliente
        '
        Me.RndTotalizadoPorCliente.AutoSize = True
        Me.RndTotalizadoPorCliente.Location = New System.Drawing.Point(16, 66)
        Me.RndTotalizadoPorCliente.Name = "RndTotalizadoPorCliente"
        Me.RndTotalizadoPorCliente.Size = New System.Drawing.Size(126, 17)
        Me.RndTotalizadoPorCliente.TabIndex = 2
        Me.RndTotalizadoPorCliente.Text = "Totalizado por cliente"
        Me.RndTotalizadoPorCliente.UseVisualStyleBackColor = True
        '
        'RdnListadoDesagrupado
        '
        Me.RdnListadoDesagrupado.AutoSize = True
        Me.RdnListadoDesagrupado.Checked = True
        Me.RdnListadoDesagrupado.Location = New System.Drawing.Point(16, 22)
        Me.RdnListadoDesagrupado.Name = "RdnListadoDesagrupado"
        Me.RdnListadoDesagrupado.Size = New System.Drawing.Size(124, 17)
        Me.RdnListadoDesagrupado.TabIndex = 1
        Me.RdnListadoDesagrupado.TabStop = True
        Me.RdnListadoDesagrupado.Text = "Listado desagrupado"
        Me.RdnListadoDesagrupado.UseVisualStyleBackColor = True
        '
        'RdnPorCliente
        '
        Me.RdnPorCliente.AutoSize = True
        Me.RdnPorCliente.Location = New System.Drawing.Point(16, 43)
        Me.RdnPorCliente.Name = "RdnPorCliente"
        Me.RdnPorCliente.Size = New System.Drawing.Size(123, 17)
        Me.RdnPorCliente.TabIndex = 0
        Me.RdnPorCliente.Text = "Agrupado por cliente"
        Me.RdnPorCliente.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
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
        Me.GroupBox2.Location = New System.Drawing.Point(218, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 307)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros"
        '
        'LblDisplayZona
        '
        Me.LblDisplayZona.AutoSize = True
        Me.LblDisplayZona.Location = New System.Drawing.Point(11, 229)
        Me.LblDisplayZona.Name = "LblDisplayZona"
        Me.LblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.LblDisplayZona.TabIndex = 393
        Me.LblDisplayZona.Text = "Zona :"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Items.AddRange(New Object() {"A", "B"})
        Me.CboZona.Location = New System.Drawing.Point(102, 227)
        Me.CboZona.MaxLength = 1
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(125, 21)
        Me.CboZona.TabIndex = 392
        '
        'CboMercado
        '
        Me.CboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMercado.FormattingEnabled = True
        Me.CboMercado.Location = New System.Drawing.Point(102, 254)
        Me.CboMercado.Name = "CboMercado"
        Me.CboMercado.Size = New System.Drawing.Size(307, 21)
        Me.CboMercado.TabIndex = 390
        '
        'LblDisplayMercado
        '
        Me.LblDisplayMercado.AutoSize = True
        Me.LblDisplayMercado.Location = New System.Drawing.Point(10, 256)
        Me.LblDisplayMercado.Name = "LblDisplayMercado"
        Me.LblDisplayMercado.Size = New System.Drawing.Size(55, 13)
        Me.LblDisplayMercado.TabIndex = 391
        Me.LblDisplayMercado.Text = "Mercado :"
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Location = New System.Drawing.Point(102, 153)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(307, 21)
        Me.CboTipoDocumento.TabIndex = 385
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(102, 129)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(307, 21)
        Me.CboAlmacen.TabIndex = 384
        '
        'CboNegociacion
        '
        Me.CboNegociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboNegociacion.FormattingEnabled = True
        Me.CboNegociacion.Location = New System.Drawing.Point(102, 177)
        Me.CboNegociacion.Name = "CboNegociacion"
        Me.CboNegociacion.Size = New System.Drawing.Size(307, 21)
        Me.CboNegociacion.TabIndex = 386
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "Crédito :"
        '
        'lblDocumentos
        '
        Me.lblDocumentos.AutoSize = True
        Me.lblDocumentos.Location = New System.Drawing.Point(11, 156)
        Me.lblDocumentos.Name = "lblDocumentos"
        Me.lblDocumentos.Size = New System.Drawing.Size(68, 13)
        Me.lblDocumentos.TabIndex = 388
        Me.lblDocumentos.Text = "Documento :"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Location = New System.Drawing.Point(11, 132)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.lblAlmacen.TabIndex = 387
        Me.lblAlmacen.Text = "Almacén :"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(155, 101)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(348, 17)
        Me.lblNombreCliente.TabIndex = 383
        Me.lblNombreCliente.Text = "_"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(65, 98)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(72, 20)
        Me.TxtCliente.TabIndex = 381
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(11, 101)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 382
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'CkbSaldo
        '
        Me.CkbSaldo.AutoSize = True
        Me.CkbSaldo.Location = New System.Drawing.Point(51, 69)
        Me.CkbSaldo.Name = "CkbSaldo"
        Me.CkbSaldo.Size = New System.Drawing.Size(213, 17)
        Me.CkbSaldo.TabIndex = 380
        Me.CkbSaldo.Text = "Mostrar solo documentos con saldos >0"
        Me.CkbSaldo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 379
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(102, 43)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaHasta.TabIndex = 377
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(11, 22)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(71, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 378
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(102, 18)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(88, 20)
        Me.DtFechaDesde.TabIndex = 376
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(11, 204)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 375
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "B"})
        Me.CboEstatus.Location = New System.Drawing.Point(102, 202)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(307, 21)
        Me.CboEstatus.TabIndex = 374
        '
        'Rpt_Ventas_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 347)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
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
End Class
