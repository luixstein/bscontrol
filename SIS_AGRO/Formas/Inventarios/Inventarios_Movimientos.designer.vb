<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventarios_Movimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventarios_Movimientos))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditarCostos = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.MaskedTextBox()
        Me.Grid1 = New FlexCell.Grid()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFolioReferencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDisplayDireccionEmpresa = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDocumento = New System.Windows.Forms.Label()
        Me.CboAlmacenDestino = New System.Windows.Forms.ComboBox()
        Me.lblAlmacenDestino = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalCantidad = New System.Windows.Forms.MaskedTextBox()
        Me.LblPoliza = New System.Windows.Forms.LinkLabel()
        Me.txtFolioEmbarque = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioEmbarque = New System.Windows.Forms.Label()
        Me.txtFolioCopiarRenglones = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.lblCodigoAlmacen1 = New System.Windows.Forms.Label()
        Me.lblCodigoAlmacen2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TpArticulos = New System.Windows.Forms.TabPage()
        Me.TpSeries = New System.Windows.Forms.TabPage()
        Me.GridSeries = New FlexCell.Grid()
        Me.BtnSeries = New System.Windows.Forms.Button()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TpArticulos.SuspendLayout()
        Me.TpSeries.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbAplicar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbEditarCostos, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1453, 27)
        Me.tsMenu.TabIndex = 223
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
        Me.tsbAplicar.Image = CType(resources.GetObject("tsbAplicar.Image"), System.Drawing.Image)
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(80, 24)
        Me.tsbAplicar.Text = "&Aplicar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(94, 24)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(90, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(118, 24)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(635, 496)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 273
        Me.Label6.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(692, 492)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(132, 22)
        Me.txtTotal.TabIndex = 272
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Grid1
        '
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DefaultRowHeight = CType(24, Short)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.LockButton = True
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(1421, 283)
        Me.Grid1.TabIndex = 7
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(141, 65)
        Me.CboAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(280, 24)
        Me.CboAlmacen.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 69)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 267
        Me.Label3.Text = "Almacén :"
        '
        'TxtFolioReferencia
        '
        Me.TxtFolioReferencia.Location = New System.Drawing.Point(141, 96)
        Me.TxtFolioReferencia.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFolioReferencia.MaxLength = 160
        Me.TxtFolioReferencia.Name = "TxtFolioReferencia"
        Me.TxtFolioReferencia.Size = New System.Drawing.Size(179, 22)
        Me.TxtFolioReferencia.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 98)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 266
        Me.Label2.Text = "Referencia :"
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(28, 132)
        Me.LblDisplayDireccionEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(76, 17)
        Me.LblDisplayDireccionEmpresa.TabIndex = 265
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(141, 128)
        Me.TxtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(777, 38)
        Me.TxtConcepto.TabIndex = 6
        '
        'DtpFecha
        '
        Me.DtpFecha.Location = New System.Drawing.Point(639, 66)
        Me.DtpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(280, 22)
        Me.DtpFecha.TabIndex = 1
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(556, 66)
        Me.LblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(55, 17)
        Me.LblFecha.TabIndex = 261
        Me.LblFecha.Text = "Fecha :"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(1199, 63)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(12, 17)
        Me.LblStatus.TabIndex = 260
        Me.LblStatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(1111, 63)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 259
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Location = New System.Drawing.Point(639, 36)
        Me.TxtFolio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtFolio.MaxLength = 20
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(179, 22)
        Me.TxtFolio.TabIndex = 0
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(567, 39)
        Me.LblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.LblDisplayFolio.TabIndex = 258
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 580)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1453, 29)
        Me.StatusStripEstado.TabIndex = 257
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tsslEstado
        '
        Me.tsslEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslEstado.Name = "tsslEstado"
        Me.tsslEstado.Size = New System.Drawing.Size(58, 24)
        Me.tsslEstado.Text = "Estado"
        '
        'tsslElaboro
        '
        Me.tsslElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslElaboro.Name = "tsslElaboro"
        Me.tsslElaboro.Size = New System.Drawing.Size(72, 24)
        Me.tsslElaboro.Text = "Elaboro :"
        '
        'tsslCancelo
        '
        Me.tsslCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCancelo.Name = "tsslCancelo"
        Me.tsslCancelo.Size = New System.Drawing.Size(73, 24)
        Me.tsslCancelo.Text = "Cancelo :"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(141, 34)
        Me.CboDocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(280, 24)
        Me.CboDocumento.TabIndex = 2
        '
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(28, 38)
        Me.LblDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(88, 17)
        Me.LblDocumento.TabIndex = 256
        Me.LblDocumento.Text = "Documento :"
        '
        'CboAlmacenDestino
        '
        Me.CboAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacenDestino.FormattingEnabled = True
        Me.CboAlmacenDestino.Location = New System.Drawing.Point(639, 95)
        Me.CboAlmacenDestino.Margin = New System.Windows.Forms.Padding(4)
        Me.CboAlmacenDestino.Name = "CboAlmacenDestino"
        Me.CboAlmacenDestino.Size = New System.Drawing.Size(280, 24)
        Me.CboAlmacenDestino.TabIndex = 4
        '
        'lblAlmacenDestino
        '
        Me.lblAlmacenDestino.AutoSize = True
        Me.lblAlmacenDestino.Location = New System.Drawing.Point(492, 98)
        Me.lblAlmacenDestino.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlmacenDestino.Name = "lblAlmacenDestino"
        Me.lblAlmacenDestino.Size = New System.Drawing.Size(120, 17)
        Me.lblAlmacenDestino.TabIndex = 275
        Me.lblAlmacenDestino.Text = "Almacén destino :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1120, 95)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 17)
        Me.Label8.TabIndex = 285
        Me.Label8.Text = "Póliza :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(323, 496)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 17)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Cantidad total :"
        '
        'txtTotalCantidad
        '
        Me.txtTotalCantidad.Location = New System.Drawing.Point(435, 492)
        Me.txtTotalCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalCantidad.Name = "txtTotalCantidad"
        Me.txtTotalCantidad.ReadOnly = True
        Me.txtTotalCantidad.Size = New System.Drawing.Size(132, 22)
        Me.txtTotalCantidad.TabIndex = 287
        Me.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(1199, 92)
        Me.LblPoliza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(16, 17)
        Me.LblPoliza.TabIndex = 329
        Me.LblPoliza.TabStop = True
        Me.LblPoliza.Text = "_"
        '
        'txtFolioEmbarque
        '
        Me.txtFolioEmbarque.Location = New System.Drawing.Point(1052, 128)
        Me.txtFolioEmbarque.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioEmbarque.MaxLength = 15
        Me.txtFolioEmbarque.Name = "txtFolioEmbarque"
        Me.txtFolioEmbarque.Size = New System.Drawing.Size(179, 22)
        Me.txtFolioEmbarque.TabIndex = 330
        Me.txtFolioEmbarque.Visible = False
        '
        'lblDisplayFolioEmbarque
        '
        Me.lblDisplayFolioEmbarque.AutoSize = True
        Me.lblDisplayFolioEmbarque.Location = New System.Drawing.Point(933, 132)
        Me.lblDisplayFolioEmbarque.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolioEmbarque.Name = "lblDisplayFolioEmbarque"
        Me.lblDisplayFolioEmbarque.Size = New System.Drawing.Size(111, 17)
        Me.lblDisplayFolioEmbarque.TabIndex = 331
        Me.lblDisplayFolioEmbarque.Text = "Folio Embarque:"
        Me.lblDisplayFolioEmbarque.Visible = False
        '
        'txtFolioCopiarRenglones
        '
        Me.txtFolioCopiarRenglones.Location = New System.Drawing.Point(1052, 36)
        Me.txtFolioCopiarRenglones.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFolioCopiarRenglones.MaxLength = 20
        Me.txtFolioCopiarRenglones.Name = "txtFolioCopiarRenglones"
        Me.txtFolioCopiarRenglones.Size = New System.Drawing.Size(179, 22)
        Me.txtFolioCopiarRenglones.TabIndex = 332
        Me.txtFolioCopiarRenglones.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(932, 38)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 17)
        Me.Label4.TabIndex = 333
        Me.Label4.Text = "Copiar renglones :"
        Me.Label4.Visible = False
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(861, 33)
        Me.btnDocumentoSiguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoSiguiente.TabIndex = 382
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(820, 33)
        Me.btnDocumentoAnterior.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoAnterior.TabIndex = 381
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'lblCodigoAlmacen1
        '
        Me.lblCodigoAlmacen1.AutoSize = True
        Me.lblCodigoAlmacen1.Location = New System.Drawing.Point(431, 69)
        Me.lblCodigoAlmacen1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoAlmacen1.Name = "lblCodigoAlmacen1"
        Me.lblCodigoAlmacen1.Size = New System.Drawing.Size(16, 17)
        Me.lblCodigoAlmacen1.TabIndex = 383
        Me.lblCodigoAlmacen1.Text = "_"
        '
        'lblCodigoAlmacen2
        '
        Me.lblCodigoAlmacen2.AutoSize = True
        Me.lblCodigoAlmacen2.Location = New System.Drawing.Point(928, 100)
        Me.lblCodigoAlmacen2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigoAlmacen2.Name = "lblCodigoAlmacen2"
        Me.lblCodigoAlmacen2.Size = New System.Drawing.Size(16, 17)
        Me.lblCodigoAlmacen2.TabIndex = 384
        Me.lblCodigoAlmacen2.Text = "_"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TpArticulos)
        Me.TabControl1.Controls.Add(Me.TpSeries)
        Me.TabControl1.Location = New System.Drawing.Point(12, 173)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1429, 312)
        Me.TabControl1.TabIndex = 385
        '
        'TpArticulos
        '
        Me.TpArticulos.Controls.Add(Me.Grid1)
        Me.TpArticulos.Location = New System.Drawing.Point(4, 25)
        Me.TpArticulos.Name = "TpArticulos"
        Me.TpArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.TpArticulos.Size = New System.Drawing.Size(1421, 283)
        Me.TpArticulos.TabIndex = 0
        Me.TpArticulos.Text = "Artículos"
        Me.TpArticulos.UseVisualStyleBackColor = True
        '
        'TpSeries
        '
        Me.TpSeries.Controls.Add(Me.GridSeries)
        Me.TpSeries.Location = New System.Drawing.Point(4, 25)
        Me.TpSeries.Name = "TpSeries"
        Me.TpSeries.Padding = New System.Windows.Forms.Padding(3)
        Me.TpSeries.Size = New System.Drawing.Size(1421, 283)
        Me.TpSeries.TabIndex = 1
        Me.TpSeries.Text = "Series"
        Me.TpSeries.UseVisualStyleBackColor = True
        '
        'GridSeries
        '
        Me.GridSeries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridSeries.CheckedImage = CType(resources.GetObject("GridSeries.CheckedImage"), System.Drawing.Bitmap)
        Me.GridSeries.Cols = 1
        Me.GridSeries.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridSeries.DefaultRowHeight = CType(24, Short)
        Me.GridSeries.DisplayRowNumber = True
        Me.GridSeries.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSeries.Location = New System.Drawing.Point(0, 0)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(1421, 283)
        Me.GridSeries.TabIndex = 386
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'BtnSeries
        '
        Me.BtnSeries.Location = New System.Drawing.Point(74, 496)
        Me.BtnSeries.Name = "BtnSeries"
        Me.BtnSeries.Size = New System.Drawing.Size(158, 31)
        Me.BtnSeries.TabIndex = 386
        Me.BtnSeries.Text = "Detallar series"
        Me.BtnSeries.UseVisualStyleBackColor = True
        '
        'Inventarios_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1453, 609)
        Me.Controls.Add(Me.BtnSeries)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblCodigoAlmacen2)
        Me.Controls.Add(Me.lblCodigoAlmacen1)
        Me.Controls.Add(Me.btnDocumentoSiguiente)
        Me.Controls.Add(Me.btnDocumentoAnterior)
        Me.Controls.Add(Me.txtFolioCopiarRenglones)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFolioEmbarque)
        Me.Controls.Add(Me.lblDisplayFolioEmbarque)
        Me.Controls.Add(Me.LblPoliza)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalCantidad)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CboAlmacenDestino)
        Me.Controls.Add(Me.lblAlmacenDestino)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.CboAlmacen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtFolioReferencia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblDisplayDireccionEmpresa)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.LblFecha)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.lblDisplayStatus)
        Me.Controls.Add(Me.TxtFolio)
        Me.Controls.Add(Me.LblDisplayFolio)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.CboDocumento)
        Me.Controls.Add(Me.LblDocumento)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Inventarios_Movimientos"
        Me.Text = "Inventarios movimientos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TpArticulos.ResumeLayout(False)
        Me.TpSeries.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtFolioReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplayDireccionEmpresa As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDocumento As System.Windows.Forms.Label
    Friend WithEvents CboAlmacenDestino As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlmacenDestino As System.Windows.Forms.Label
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCantidad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents txtFolioEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioEmbarque As System.Windows.Forms.Label
    Friend WithEvents txtFolioCopiarRenglones As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents lblCodigoAlmacen1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigoAlmacen2 As System.Windows.Forms.Label
    Friend WithEvents tsbEditarCostos As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TpArticulos As System.Windows.Forms.TabPage
    Friend WithEvents TpSeries As System.Windows.Forms.TabPage
    Friend WithEvents GridSeries As FlexCell.Grid
    Friend WithEvents BtnSeries As System.Windows.Forms.Button
End Class
