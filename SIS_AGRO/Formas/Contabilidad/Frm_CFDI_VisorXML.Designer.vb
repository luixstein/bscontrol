<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CFDI_VisorXML
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CFDI_VisorXML))
        Me.GridConceptos = New FlexCell.Grid()
        Me.GridImpuestos = New FlexCell.Grid()
        Me.txtUUID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmisorRFC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReceptorRFC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmisorNombre = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtReceptorNombre = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFechaCaptura = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFormaPago = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMetodoPago = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTipoDeComprobante = New System.Windows.Forms.TextBox()
        Me.lblAvisoMonedaNoMXN = New System.Windows.Forms.Label()
        Me.tsbAbrirArchivoXML = New System.Windows.Forms.ToolStripButton()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridConceptos
        '
        Me.GridConceptos.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.GridConceptos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridConceptos.CheckedImage = CType(resources.GetObject("GridConceptos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridConceptos.Cols = 14
        Me.GridConceptos.DefaultFont = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GridConceptos.DefaultRowHeight = CType(21, Short)
        Me.GridConceptos.DisplayRowNumber = True
        Me.GridConceptos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridConceptos.FixedRows = 2
        Me.GridConceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridConceptos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridConceptos.Location = New System.Drawing.Point(12, 228)
        Me.GridConceptos.LockButton = True
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.Rows = 3
        Me.GridConceptos.Size = New System.Drawing.Size(1055, 368)
        Me.GridConceptos.TabIndex = 1
        Me.GridConceptos.TopRow = 2
        Me.GridConceptos.UncheckedImage = CType(resources.GetObject("GridConceptos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GridImpuestos
        '
        Me.GridImpuestos.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.GridImpuestos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridImpuestos.CheckedImage = CType(resources.GetObject("GridImpuestos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridImpuestos.DefaultFont = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GridImpuestos.DefaultRowHeight = CType(21, Short)
        Me.GridImpuestos.DisplayRowNumber = True
        Me.GridImpuestos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridImpuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridImpuestos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridImpuestos.Location = New System.Drawing.Point(600, 62)
        Me.GridImpuestos.LockButton = True
        Me.GridImpuestos.Name = "GridImpuestos"
        Me.GridImpuestos.Rows = 2
        Me.GridImpuestos.Size = New System.Drawing.Size(467, 134)
        Me.GridImpuestos.TabIndex = 2
        Me.GridImpuestos.UncheckedImage = CType(resources.GetObject("GridImpuestos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'txtUUID
        '
        Me.txtUUID.Location = New System.Drawing.Point(85, 62)
        Me.txtUUID.Name = "txtUUID"
        Me.txtUUID.ReadOnly = True
        Me.txtUUID.Size = New System.Drawing.Size(301, 20)
        Me.txtUUID.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "UUID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Conceptos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "RFC emisor"
        '
        'txtEmisorRFC
        '
        Me.txtEmisorRFC.Location = New System.Drawing.Point(85, 115)
        Me.txtEmisorRFC.Name = "txtEmisorRFC"
        Me.txtEmisorRFC.ReadOnly = True
        Me.txtEmisorRFC.Size = New System.Drawing.Size(100, 20)
        Me.txtEmisorRFC.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "RFC receptor"
        '
        'txtReceptorRFC
        '
        Me.txtReceptorRFC.Location = New System.Drawing.Point(85, 141)
        Me.txtReceptorRFC.Name = "txtReceptorRFC"
        Me.txtReceptorRFC.ReadOnly = True
        Me.txtReceptorRFC.Size = New System.Drawing.Size(100, 20)
        Me.txtReceptorRFC.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Subtotal"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(85, 167)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtSubtotal.TabIndex = 10
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Descuento"
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(286, 167)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(100, 20)
        Me.txtDescuento.TabIndex = 12
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(194, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(286, 88)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(100, 20)
        Me.txtSerie.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(194, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Nombre emisor"
        '
        'txtEmisorNombre
        '
        Me.txtEmisorNombre.Location = New System.Drawing.Point(286, 115)
        Me.txtEmisorNombre.Name = "txtEmisorNombre"
        Me.txtEmisorNombre.ReadOnly = True
        Me.txtEmisorNombre.Size = New System.Drawing.Size(306, 20)
        Me.txtEmisorNombre.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(194, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Nombre receptor"
        '
        'txtReceptorNombre
        '
        Me.txtReceptorNombre.Location = New System.Drawing.Point(286, 141)
        Me.txtReceptorNombre.Name = "txtReceptorNombre"
        Me.txtReceptorNombre.ReadOnly = True
        Me.txtReceptorNombre.Size = New System.Drawing.Size(306, 20)
        Me.txtReceptorNombre.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Folio"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(84, 88)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(100, 20)
        Me.txtFolio.TabIndex = 20
        '
        'dtFecha
        '
        Me.dtFecha.Enabled = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(286, 36)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtFecha.TabIndex = 222
        '
        'lblDisplayFechaCaptura
        '
        Me.lblDisplayFechaCaptura.AutoSize = True
        Me.lblDisplayFechaCaptura.Location = New System.Drawing.Point(194, 39)
        Me.lblDisplayFechaCaptura.Name = "lblDisplayFechaCaptura"
        Me.lblDisplayFechaCaptura.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFechaCaptura.TabIndex = 223
        Me.lblDisplayFechaCaptura.Text = "Fecha :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 225
        Me.Label11.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(85, 193)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 224
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(194, 196)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 227
        Me.Label12.Text = "Moneda"
        '
        'txtMoneda
        '
        Me.txtMoneda.Location = New System.Drawing.Point(286, 193)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(100, 20)
        Me.txtMoneda.TabIndex = 226
        Me.txtMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(400, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 229
        Me.Label13.Text = "Tipo de cambio"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(492, 193)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(100, 20)
        Me.txtTipoCambio.TabIndex = 228
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAbrirArchivoXML, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1074, 27)
        Me.tsMenu.TabIndex = 230
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(598, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 231
        Me.Label14.Text = "Impuestos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(400, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 233
        Me.Label15.Text = "Forma pago"
        '
        'txtFormaPago
        '
        Me.txtFormaPago.Location = New System.Drawing.Point(492, 62)
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.ReadOnly = True
        Me.txtFormaPago.Size = New System.Drawing.Size(100, 20)
        Me.txtFormaPago.TabIndex = 232
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(400, 91)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 13)
        Me.Label16.TabIndex = 235
        Me.Label16.Text = "Método pago"
        '
        'txtMetodoPago
        '
        Me.txtMetodoPago.Location = New System.Drawing.Point(492, 88)
        Me.txtMetodoPago.Name = "txtMetodoPago"
        Me.txtMetodoPago.ReadOnly = True
        Me.txtMetodoPago.Size = New System.Drawing.Size(100, 20)
        Me.txtMetodoPago.TabIndex = 234
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 237
        Me.Label17.Text = "Tipo Comp."
        '
        'txtTipoDeComprobante
        '
        Me.txtTipoDeComprobante.Location = New System.Drawing.Point(85, 36)
        Me.txtTipoDeComprobante.Name = "txtTipoDeComprobante"
        Me.txtTipoDeComprobante.ReadOnly = True
        Me.txtTipoDeComprobante.Size = New System.Drawing.Size(85, 20)
        Me.txtTipoDeComprobante.TabIndex = 236
        '
        'lblAvisoMonedaNoMXN
        '
        Me.lblAvisoMonedaNoMXN.AutoSize = True
        Me.lblAvisoMonedaNoMXN.ForeColor = System.Drawing.Color.Red
        Me.lblAvisoMonedaNoMXN.Location = New System.Drawing.Point(404, 27)
        Me.lblAvisoMonedaNoMXN.Name = "lblAvisoMonedaNoMXN"
        Me.lblAvisoMonedaNoMXN.Size = New System.Drawing.Size(666, 13)
        Me.lblAvisoMonedaNoMXN.TabIndex = 240
        Me.lblAvisoMonedaNoMXN.Text = "*Este xml no está en MXN, cada uno los valores que el sistema muestra de momento " &
    "están expresadas están en la moneda del  documento."
        Me.lblAvisoMonedaNoMXN.Visible = False
        '
        'tsbAbrirArchivoXML
        '
        Me.tsbAbrirArchivoXML.Image = Global.BsControl.My.Resources.Resources.xml_file
        Me.tsbAbrirArchivoXML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAbrirArchivoXML.Name = "tsbAbrirArchivoXML"
        Me.tsbAbrirArchivoXML.Size = New System.Drawing.Size(126, 24)
        Me.tsbAbrirArchivoXML.Text = "&Abrir archivo XML"
        '
        'Frm_CFDI_VisorXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 605)
        Me.Controls.Add(Me.lblAvisoMonedaNoMXN)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtTipoDeComprobante)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtMetodoPago)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtFormaPago)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.lblDisplayFechaCaptura)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtReceptorNombre)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEmisorNombre)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtReceptorRFC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEmisorRFC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUUID)
        Me.Controls.Add(Me.GridImpuestos)
        Me.Controls.Add(Me.GridConceptos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Frm_CFDI_VisorXML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visor XML"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridConceptos As FlexCell.Grid
    Friend WithEvents GridImpuestos As FlexCell.Grid
    Friend WithEvents txtUUID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmisorRFC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtReceptorRFC As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEmisorNombre As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtReceptorNombre As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents lblDisplayFechaCaptura As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMoneda As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTipoCambio As TextBox
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtFormaPago As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMetodoPago As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtTipoDeComprobante As TextBox
    Friend WithEvents lblAvisoMonedaNoMXN As Label
    Friend WithEvents tsbAbrirArchivoXML As ToolStripButton
End Class
