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
        Me.txtTotal = New System.Windows.Forms.MaskedTextBox()
        Me.CboAlmacen = New System.Windows.Forms.ComboBox()
        Me.lblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.TxtFolioReferencia = New System.Windows.Forms.TextBox()
        Me.lblDisplayReferencia = New System.Windows.Forms.Label()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.TxtConcepto = New System.Windows.Forms.TextBox()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolio = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CboDocumento = New System.Windows.Forms.ComboBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.CboAlmacenDestino = New System.Windows.Forms.ComboBox()
        Me.lblAlmacenDestino = New System.Windows.Forms.Label()
        Me.lblDisplayPoliza = New System.Windows.Forms.Label()
        Me.lblDisplayTotales = New System.Windows.Forms.Label()
        Me.txtTotalCantidad = New System.Windows.Forms.MaskedTextBox()
        Me.lblPoliza = New System.Windows.Forms.LinkLabel()
        Me.txtFolioEmbarque = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolioEmbarque = New System.Windows.Forms.Label()
        Me.txtFolioCopiarRenglones = New System.Windows.Forms.TextBox()
        Me.lblDisplayCopiarRenglones = New System.Windows.Forms.Label()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.lblCodigoAlmacen1 = New System.Windows.Forms.Label()
        Me.lblCodigoAlmacen2 = New System.Windows.Forms.Label()
        Me.btnSeries = New System.Windows.Forms.Button()
        Me.CboConceptoInventario = New System.Windows.Forms.ComboBox()
        Me.lblConceptoInventario = New System.Windows.Forms.Label()
        Me.TpSeries = New System.Windows.Forms.TabPage()
        Me.GridSeries = New FlexCell.Grid()
        Me.TpArticulos = New System.Windows.Forms.TabPage()
        Me.Grid1 = New FlexCell.Grid()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.lblDisplayProveedor = New System.Windows.Forms.Label()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFolioOrdenCompra = New System.Windows.Forms.Label()
        Me.lblDisplayFechaEntrega = New System.Windows.Forms.Label()
        Me.txtFolioOrdenCompra = New System.Windows.Forms.TextBox()
        Me.lblDisplayFleteOrdenCompra = New System.Windows.Forms.Label()
        Me.txtFleteOrdenCompra = New System.Windows.Forms.TextBox()
        Me.btnProrratearFleteOrdenCompra = New System.Windows.Forms.Button()
        Me.lblDisplayEntradasAnterioresOrdenCompra = New System.Windows.Forms.Label()
        Me.gbOrdenCompra = New System.Windows.Forms.GroupBox()
        Me.btnNuevaOrdenCompra = New System.Windows.Forms.Button()
        Me.btnConsultarOrdenCompra = New System.Windows.Forms.Button()
        Me.cboEntradasAnterioresOrdenCompra = New System.Windows.Forms.ComboBox()
        Me.txtTotalMasFlete = New System.Windows.Forms.MaskedTextBox()
        Me.txtTotalFlete = New System.Windows.Forms.MaskedTextBox()
        Me.btnSeleccionarArchivoSeries = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.TpSeries.SuspendLayout()
        Me.TpArticulos.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.gbOrdenCompra.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbAplicar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbEditarCostos, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1308, 27)
        Me.tsMenu.TabIndex = 223
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(66, 24)
        Me.tsbNuevo.Text = "&Nuevo"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(66, 24)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbAplicar
        '
        Me.tsbAplicar.Image = CType(resources.GetObject("tsbAplicar.Image"), System.Drawing.Image)
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(68, 24)
        Me.tsbAplicar.Text = "&Aplicar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(80, 24)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(77, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(98, 24)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(518, 539)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 272
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CboAlmacen
        '
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.FormattingEnabled = True
        Me.CboAlmacen.Location = New System.Drawing.Point(106, 53)
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(211, 21)
        Me.CboAlmacen.TabIndex = 3
        '
        'lblDisplayAlmacen
        '
        Me.lblDisplayAlmacen.AutoSize = True
        Me.lblDisplayAlmacen.Location = New System.Drawing.Point(51, 56)
        Me.lblDisplayAlmacen.Name = "lblDisplayAlmacen"
        Me.lblDisplayAlmacen.Size = New System.Drawing.Size(54, 13)
        Me.lblDisplayAlmacen.TabIndex = 267
        Me.lblDisplayAlmacen.Text = "Almacén :"
        '
        'TxtFolioReferencia
        '
        Me.TxtFolioReferencia.Location = New System.Drawing.Point(106, 78)
        Me.TxtFolioReferencia.MaxLength = 160
        Me.TxtFolioReferencia.Name = "TxtFolioReferencia"
        Me.TxtFolioReferencia.Size = New System.Drawing.Size(135, 20)
        Me.TxtFolioReferencia.TabIndex = 5
        '
        'lblDisplayReferencia
        '
        Me.lblDisplayReferencia.AutoSize = True
        Me.lblDisplayReferencia.Location = New System.Drawing.Point(40, 80)
        Me.lblDisplayReferencia.Name = "lblDisplayReferencia"
        Me.lblDisplayReferencia.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayReferencia.TabIndex = 266
        Me.lblDisplayReferencia.Text = "Referencia :"
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(46, 132)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayConcepto.TabIndex = 265
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(106, 128)
        Me.TxtConcepto.MaxLength = 160
        Me.TxtConcepto.Multiline = True
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(584, 32)
        Me.TxtConcepto.TabIndex = 6
        '
        'DtpFecha
        '
        Me.DtpFecha.Location = New System.Drawing.Point(479, 54)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(211, 20)
        Me.DtpFecha.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(417, 54)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblFecha.TabIndex = 261
        Me.lblFecha.Text = "Fecha :"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatus.Location = New System.Drawing.Point(899, 51)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(10, 13)
        Me.lblStatus.TabIndex = 260
        Me.lblStatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(833, 51)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 259
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'TxtFolio
        '
        Me.TxtFolio.Location = New System.Drawing.Point(479, 29)
        Me.TxtFolio.MaxLength = 20
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(135, 20)
        Me.TxtFolio.TabIndex = 0
        '
        'lblDisplayFolio
        '
        Me.lblDisplayFolio.AutoSize = True
        Me.lblDisplayFolio.Location = New System.Drawing.Point(425, 32)
        Me.lblDisplayFolio.Name = "lblDisplayFolio"
        Me.lblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.lblDisplayFolio.TabIndex = 258
        Me.lblDisplayFolio.Text = "Folio :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 563)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1308, 24)
        Me.StatusStripEstado.TabIndex = 257
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
        'tsslElaboro
        '
        Me.tsslElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslElaboro.Name = "tsslElaboro"
        Me.tsslElaboro.Size = New System.Drawing.Size(57, 19)
        Me.tsslElaboro.Text = "Elaboro :"
        '
        'tsslCancelo
        '
        Me.tsslCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCancelo.Name = "tsslCancelo"
        Me.tsslCancelo.Size = New System.Drawing.Size(60, 19)
        Me.tsslCancelo.Text = "Cancelo :"
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(106, 28)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(211, 21)
        Me.CboDocumento.TabIndex = 2
        '
        'lblDocumento
        '
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Location = New System.Drawing.Point(37, 31)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.lblDocumento.TabIndex = 256
        Me.lblDocumento.Text = "Documento :"
        '
        'CboAlmacenDestino
        '
        Me.CboAlmacenDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacenDestino.FormattingEnabled = True
        Me.CboAlmacenDestino.Location = New System.Drawing.Point(479, 77)
        Me.CboAlmacenDestino.Name = "CboAlmacenDestino"
        Me.CboAlmacenDestino.Size = New System.Drawing.Size(211, 21)
        Me.CboAlmacenDestino.TabIndex = 4
        '
        'lblAlmacenDestino
        '
        Me.lblAlmacenDestino.AutoSize = True
        Me.lblAlmacenDestino.Location = New System.Drawing.Point(369, 80)
        Me.lblAlmacenDestino.Name = "lblAlmacenDestino"
        Me.lblAlmacenDestino.Size = New System.Drawing.Size(91, 13)
        Me.lblAlmacenDestino.TabIndex = 275
        Me.lblAlmacenDestino.Text = "Almacén destino :"
        '
        'lblDisplayPoliza
        '
        Me.lblDisplayPoliza.AutoSize = True
        Me.lblDisplayPoliza.Location = New System.Drawing.Point(840, 77)
        Me.lblDisplayPoliza.Name = "lblDisplayPoliza"
        Me.lblDisplayPoliza.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayPoliza.TabIndex = 285
        Me.lblDisplayPoliza.Text = "Póliza :"
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(252, 542)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTotales.TabIndex = 288
        Me.lblDisplayTotales.Text = "Totales :"
        '
        'txtTotalCantidad
        '
        Me.txtTotalCantidad.Location = New System.Drawing.Point(325, 539)
        Me.txtTotalCantidad.Name = "txtTotalCantidad"
        Me.txtTotalCantidad.ReadOnly = True
        Me.txtTotalCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCantidad.TabIndex = 287
        Me.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPoliza
        '
        Me.lblPoliza.AutoSize = True
        Me.lblPoliza.Location = New System.Drawing.Point(899, 75)
        Me.lblPoliza.Name = "lblPoliza"
        Me.lblPoliza.Size = New System.Drawing.Size(13, 13)
        Me.lblPoliza.TabIndex = 329
        Me.lblPoliza.TabStop = True
        Me.lblPoliza.Text = "_"
        '
        'txtFolioEmbarque
        '
        Me.txtFolioEmbarque.Location = New System.Drawing.Point(789, 128)
        Me.txtFolioEmbarque.MaxLength = 15
        Me.txtFolioEmbarque.Name = "txtFolioEmbarque"
        Me.txtFolioEmbarque.Size = New System.Drawing.Size(135, 20)
        Me.txtFolioEmbarque.TabIndex = 330
        Me.txtFolioEmbarque.Visible = False
        '
        'lblDisplayFolioEmbarque
        '
        Me.lblDisplayFolioEmbarque.AutoSize = True
        Me.lblDisplayFolioEmbarque.Location = New System.Drawing.Point(700, 132)
        Me.lblDisplayFolioEmbarque.Name = "lblDisplayFolioEmbarque"
        Me.lblDisplayFolioEmbarque.Size = New System.Drawing.Size(83, 13)
        Me.lblDisplayFolioEmbarque.TabIndex = 331
        Me.lblDisplayFolioEmbarque.Text = "Folio Embarque:"
        Me.lblDisplayFolioEmbarque.Visible = False
        '
        'txtFolioCopiarRenglones
        '
        Me.txtFolioCopiarRenglones.Location = New System.Drawing.Point(789, 29)
        Me.txtFolioCopiarRenglones.MaxLength = 20
        Me.txtFolioCopiarRenglones.Name = "txtFolioCopiarRenglones"
        Me.txtFolioCopiarRenglones.Size = New System.Drawing.Size(135, 20)
        Me.txtFolioCopiarRenglones.TabIndex = 332
        Me.txtFolioCopiarRenglones.Visible = False
        '
        'lblDisplayCopiarRenglones
        '
        Me.lblDisplayCopiarRenglones.AutoSize = True
        Me.lblDisplayCopiarRenglones.Location = New System.Drawing.Point(699, 31)
        Me.lblDisplayCopiarRenglones.Name = "lblDisplayCopiarRenglones"
        Me.lblDisplayCopiarRenglones.Size = New System.Drawing.Size(92, 13)
        Me.lblDisplayCopiarRenglones.TabIndex = 333
        Me.lblDisplayCopiarRenglones.Text = "Copiar renglones :"
        Me.lblDisplayCopiarRenglones.Visible = False
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(646, 27)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoSiguiente.TabIndex = 382
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(615, 27)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoAnterior.TabIndex = 381
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'lblCodigoAlmacen1
        '
        Me.lblCodigoAlmacen1.AutoSize = True
        Me.lblCodigoAlmacen1.Location = New System.Drawing.Point(323, 56)
        Me.lblCodigoAlmacen1.Name = "lblCodigoAlmacen1"
        Me.lblCodigoAlmacen1.Size = New System.Drawing.Size(13, 13)
        Me.lblCodigoAlmacen1.TabIndex = 383
        Me.lblCodigoAlmacen1.Text = "_"
        '
        'lblCodigoAlmacen2
        '
        Me.lblCodigoAlmacen2.AutoSize = True
        Me.lblCodigoAlmacen2.Location = New System.Drawing.Point(696, 81)
        Me.lblCodigoAlmacen2.Name = "lblCodigoAlmacen2"
        Me.lblCodigoAlmacen2.Size = New System.Drawing.Size(13, 13)
        Me.lblCodigoAlmacen2.TabIndex = 384
        Me.lblCodigoAlmacen2.Text = "_"
        '
        'btnSeries
        '
        Me.btnSeries.Location = New System.Drawing.Point(3, 512)
        Me.btnSeries.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(162, 25)
        Me.btnSeries.TabIndex = 386
        Me.btnSeries.Text = "Detallar series"
        Me.btnSeries.UseVisualStyleBackColor = True
        '
        'CboConceptoInventario
        '
        Me.CboConceptoInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboConceptoInventario.FormattingEnabled = True
        Me.CboConceptoInventario.Location = New System.Drawing.Point(106, 102)
        Me.CboConceptoInventario.Name = "CboConceptoInventario"
        Me.CboConceptoInventario.Size = New System.Drawing.Size(211, 21)
        Me.CboConceptoInventario.TabIndex = 387
        '
        'lblConceptoInventario
        '
        Me.lblConceptoInventario.AutoSize = True
        Me.lblConceptoInventario.Location = New System.Drawing.Point(0, 105)
        Me.lblConceptoInventario.Name = "lblConceptoInventario"
        Me.lblConceptoInventario.Size = New System.Drawing.Size(105, 13)
        Me.lblConceptoInventario.TabIndex = 388
        Me.lblConceptoInventario.Text = "Concepto inventario:"
        '
        'TpSeries
        '
        Me.TpSeries.Controls.Add(Me.GridSeries)
        Me.TpSeries.Location = New System.Drawing.Point(4, 22)
        Me.TpSeries.Margin = New System.Windows.Forms.Padding(2)
        Me.TpSeries.Name = "TpSeries"
        Me.TpSeries.Padding = New System.Windows.Forms.Padding(2)
        Me.TpSeries.Size = New System.Drawing.Size(1291, 253)
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
        Me.GridSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSeries.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridSeries.Location = New System.Drawing.Point(0, 0)
        Me.GridSeries.LockButton = True
        Me.GridSeries.Name = "GridSeries"
        Me.GridSeries.Rows = 6
        Me.GridSeries.Size = New System.Drawing.Size(1066, 230)
        Me.GridSeries.TabIndex = 386
        Me.GridSeries.UncheckedImage = CType(resources.GetObject("GridSeries.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TpArticulos
        '
        Me.TpArticulos.Controls.Add(Me.Grid1)
        Me.TpArticulos.Location = New System.Drawing.Point(4, 22)
        Me.TpArticulos.Margin = New System.Windows.Forms.Padding(2)
        Me.TpArticulos.Name = "TpArticulos"
        Me.TpArticulos.Padding = New System.Windows.Forms.Padding(2)
        Me.TpArticulos.Size = New System.Drawing.Size(1291, 253)
        Me.TpArticulos.TabIndex = 0
        Me.TpArticulos.Text = "Artículos"
        Me.TpArticulos.UseVisualStyleBackColor = True
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
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(0, 3)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 10
        Me.Grid1.Size = New System.Drawing.Size(1289, 249)
        Me.Grid1.TabIndex = 7
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TpArticulos)
        Me.TabControl1.Controls.Add(Me.TpSeries)
        Me.TabControl1.Location = New System.Drawing.Point(9, 233)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1299, 279)
        Me.TabControl1.TabIndex = 385
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(562, 20)
        Me.txtProveedor.MaxLength = 15
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(376, 20)
        Me.txtProveedor.TabIndex = 391
        '
        'lblDisplayProveedor
        '
        Me.lblDisplayProveedor.AutoSize = True
        Me.lblDisplayProveedor.Location = New System.Drawing.Point(494, 23)
        Me.lblDisplayProveedor.Name = "lblDisplayProveedor"
        Me.lblDisplayProveedor.Size = New System.Drawing.Size(62, 13)
        Me.lblDisplayProveedor.TabIndex = 392
        Me.lblDisplayProveedor.Text = "Proveedor :"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Enabled = False
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(457, 43)
        Me.dtpFechaEntrega.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(211, 20)
        Me.dtpFechaEntrega.TabIndex = 393
        '
        'lblDisplayFolioOrdenCompra
        '
        Me.lblDisplayFolioOrdenCompra.AutoSize = True
        Me.lblDisplayFolioOrdenCompra.Location = New System.Drawing.Point(22, 20)
        Me.lblDisplayFolioOrdenCompra.Name = "lblDisplayFolioOrdenCompra"
        Me.lblDisplayFolioOrdenCompra.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayFolioOrdenCompra.TabIndex = 390
        Me.lblDisplayFolioOrdenCompra.Text = "Orden compra :"
        '
        'lblDisplayFechaEntrega
        '
        Me.lblDisplayFechaEntrega.AutoSize = True
        Me.lblDisplayFechaEntrega.Location = New System.Drawing.Point(369, 46)
        Me.lblDisplayFechaEntrega.Name = "lblDisplayFechaEntrega"
        Me.lblDisplayFechaEntrega.Size = New System.Drawing.Size(82, 13)
        Me.lblDisplayFechaEntrega.TabIndex = 394
        Me.lblDisplayFechaEntrega.Text = "Fecha entrega :"
        '
        'txtFolioOrdenCompra
        '
        Me.txtFolioOrdenCompra.Location = New System.Drawing.Point(103, 17)
        Me.txtFolioOrdenCompra.MaxLength = 15
        Me.txtFolioOrdenCompra.Name = "txtFolioOrdenCompra"
        Me.txtFolioOrdenCompra.Size = New System.Drawing.Size(135, 20)
        Me.txtFolioOrdenCompra.TabIndex = 389
        '
        'lblDisplayFleteOrdenCompra
        '
        Me.lblDisplayFleteOrdenCompra.AutoSize = True
        Me.lblDisplayFleteOrdenCompra.Location = New System.Drawing.Point(57, 46)
        Me.lblDisplayFleteOrdenCompra.Name = "lblDisplayFleteOrdenCompra"
        Me.lblDisplayFleteOrdenCompra.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayFleteOrdenCompra.TabIndex = 396
        Me.lblDisplayFleteOrdenCompra.Text = "$ Flete :"
        '
        'txtFleteOrdenCompra
        '
        Me.txtFleteOrdenCompra.Location = New System.Drawing.Point(103, 43)
        Me.txtFleteOrdenCompra.MaxLength = 15
        Me.txtFleteOrdenCompra.Name = "txtFleteOrdenCompra"
        Me.txtFleteOrdenCompra.Size = New System.Drawing.Size(135, 20)
        Me.txtFleteOrdenCompra.TabIndex = 395
        Me.txtFleteOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnProrratearFleteOrdenCompra
        '
        Me.btnProrratearFleteOrdenCompra.Location = New System.Drawing.Point(243, 40)
        Me.btnProrratearFleteOrdenCompra.Margin = New System.Windows.Forms.Padding(2)
        Me.btnProrratearFleteOrdenCompra.Name = "btnProrratearFleteOrdenCompra"
        Me.btnProrratearFleteOrdenCompra.Size = New System.Drawing.Size(118, 25)
        Me.btnProrratearFleteOrdenCompra.TabIndex = 397
        Me.btnProrratearFleteOrdenCompra.Text = "Prorratear flete"
        Me.btnProrratearFleteOrdenCompra.UseVisualStyleBackColor = True
        '
        'lblDisplayEntradasAnterioresOrdenCompra
        '
        Me.lblDisplayEntradasAnterioresOrdenCompra.AutoSize = True
        Me.lblDisplayEntradasAnterioresOrdenCompra.Location = New System.Drawing.Point(674, 46)
        Me.lblDisplayEntradasAnterioresOrdenCompra.Name = "lblDisplayEntradasAnterioresOrdenCompra"
        Me.lblDisplayEntradasAnterioresOrdenCompra.Size = New System.Drawing.Size(104, 13)
        Me.lblDisplayEntradasAnterioresOrdenCompra.TabIndex = 399
        Me.lblDisplayEntradasAnterioresOrdenCompra.Text = "Entradas anteriores :"
        '
        'gbOrdenCompra
        '
        Me.gbOrdenCompra.Controls.Add(Me.btnNuevaOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.btnConsultarOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.cboEntradasAnterioresOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.lblDisplayEntradasAnterioresOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.btnProrratearFleteOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.txtFleteOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.lblDisplayFleteOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.txtFolioOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.lblDisplayFechaEntrega)
        Me.gbOrdenCompra.Controls.Add(Me.lblDisplayFolioOrdenCompra)
        Me.gbOrdenCompra.Controls.Add(Me.dtpFechaEntrega)
        Me.gbOrdenCompra.Controls.Add(Me.lblDisplayProveedor)
        Me.gbOrdenCompra.Controls.Add(Me.txtProveedor)
        Me.gbOrdenCompra.Location = New System.Drawing.Point(3, 159)
        Me.gbOrdenCompra.Name = "gbOrdenCompra"
        Me.gbOrdenCompra.Size = New System.Drawing.Size(1074, 69)
        Me.gbOrdenCompra.TabIndex = 395
        Me.gbOrdenCompra.TabStop = False
        Me.gbOrdenCompra.Text = "Datos de la orden de compra :"
        Me.gbOrdenCompra.Visible = False
        '
        'btnNuevaOrdenCompra
        '
        Me.btnNuevaOrdenCompra.Location = New System.Drawing.Point(369, 14)
        Me.btnNuevaOrdenCompra.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNuevaOrdenCompra.Name = "btnNuevaOrdenCompra"
        Me.btnNuevaOrdenCompra.Size = New System.Drawing.Size(118, 25)
        Me.btnNuevaOrdenCompra.TabIndex = 401
        Me.btnNuevaOrdenCompra.Text = "Empezar otra Oc"
        Me.btnNuevaOrdenCompra.UseVisualStyleBackColor = True
        '
        'btnConsultarOrdenCompra
        '
        Me.btnConsultarOrdenCompra.Location = New System.Drawing.Point(243, 14)
        Me.btnConsultarOrdenCompra.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConsultarOrdenCompra.Name = "btnConsultarOrdenCompra"
        Me.btnConsultarOrdenCompra.Size = New System.Drawing.Size(118, 25)
        Me.btnConsultarOrdenCompra.TabIndex = 400
        Me.btnConsultarOrdenCompra.Text = "Traer detalle"
        Me.btnConsultarOrdenCompra.UseVisualStyleBackColor = True
        '
        'cboEntradasAnterioresOrdenCompra
        '
        Me.cboEntradasAnterioresOrdenCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntradasAnterioresOrdenCompra.FormattingEnabled = True
        Me.cboEntradasAnterioresOrdenCompra.Location = New System.Drawing.Point(776, 42)
        Me.cboEntradasAnterioresOrdenCompra.Name = "cboEntradasAnterioresOrdenCompra"
        Me.cboEntradasAnterioresOrdenCompra.Size = New System.Drawing.Size(242, 21)
        Me.cboEntradasAnterioresOrdenCompra.TabIndex = 398
        '
        'txtTotalMasFlete
        '
        Me.txtTotalMasFlete.Location = New System.Drawing.Point(1172, 539)
        Me.txtTotalMasFlete.Name = "txtTotalMasFlete"
        Me.txtTotalMasFlete.ReadOnly = True
        Me.txtTotalMasFlete.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalMasFlete.TabIndex = 396
        Me.txtTotalMasFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalFlete
        '
        Me.txtTotalFlete.Location = New System.Drawing.Point(1013, 539)
        Me.txtTotalFlete.Name = "txtTotalFlete"
        Me.txtTotalFlete.ReadOnly = True
        Me.txtTotalFlete.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalFlete.TabIndex = 397
        Me.txtTotalFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSeleccionarArchivoSeries
        '
        Me.btnSeleccionarArchivoSeries.Enabled = False
        Me.btnSeleccionarArchivoSeries.Location = New System.Drawing.Point(3, 536)
        Me.btnSeleccionarArchivoSeries.Name = "btnSeleccionarArchivoSeries"
        Me.btnSeleccionarArchivoSeries.Size = New System.Drawing.Size(162, 25)
        Me.btnSeleccionarArchivoSeries.TabIndex = 398
        Me.btnSeleccionarArchivoSeries.Text = "Seleccionar archivo con series"
        Me.btnSeleccionarArchivoSeries.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Inventarios_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1308, 587)
        Me.Controls.Add(Me.btnSeleccionarArchivoSeries)
        Me.Controls.Add(Me.txtTotalFlete)
        Me.Controls.Add(Me.txtTotalMasFlete)
        Me.Controls.Add(Me.gbOrdenCompra)
        Me.Controls.Add(Me.lblConceptoInventario)
        Me.Controls.Add(Me.CboConceptoInventario)
        Me.Controls.Add(Me.btnSeries)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblCodigoAlmacen2)
        Me.Controls.Add(Me.lblCodigoAlmacen1)
        Me.Controls.Add(Me.btnDocumentoSiguiente)
        Me.Controls.Add(Me.btnDocumentoAnterior)
        Me.Controls.Add(Me.txtFolioCopiarRenglones)
        Me.Controls.Add(Me.lblDisplayCopiarRenglones)
        Me.Controls.Add(Me.txtFolioEmbarque)
        Me.Controls.Add(Me.lblDisplayFolioEmbarque)
        Me.Controls.Add(Me.lblPoliza)
        Me.Controls.Add(Me.lblDisplayTotales)
        Me.Controls.Add(Me.txtTotalCantidad)
        Me.Controls.Add(Me.lblDisplayPoliza)
        Me.Controls.Add(Me.CboAlmacenDestino)
        Me.Controls.Add(Me.lblAlmacenDestino)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.CboAlmacen)
        Me.Controls.Add(Me.lblDisplayAlmacen)
        Me.Controls.Add(Me.TxtFolioReferencia)
        Me.Controls.Add(Me.lblDisplayReferencia)
        Me.Controls.Add(Me.lblDisplayConcepto)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblDisplayStatus)
        Me.Controls.Add(Me.TxtFolio)
        Me.Controls.Add(Me.lblDisplayFolio)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.CboDocumento)
        Me.Controls.Add(Me.lblDocumento)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Inventarios_Movimientos"
        Me.Text = "Inventarios movimientos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.TpSeries.ResumeLayout(False)
        Me.TpArticulos.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.gbOrdenCompra.ResumeLayout(False)
        Me.gbOrdenCompra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtTotal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CboAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayAlmacen As System.Windows.Forms.Label
    Friend WithEvents TxtFolioReferencia As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayReferencia As System.Windows.Forms.Label
    Friend WithEvents lblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents CboAlmacenDestino As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlmacenDestino As System.Windows.Forms.Label
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDisplayPoliza As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents txtTotalCantidad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents txtFolioEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolioEmbarque As System.Windows.Forms.Label
    Friend WithEvents txtFolioCopiarRenglones As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayCopiarRenglones As System.Windows.Forms.Label
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents lblCodigoAlmacen1 As System.Windows.Forms.Label
    Friend WithEvents lblCodigoAlmacen2 As System.Windows.Forms.Label
    Friend WithEvents tsbEditarCostos As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSeries As System.Windows.Forms.Button
    Friend WithEvents CboConceptoInventario As System.Windows.Forms.ComboBox
    Friend WithEvents lblConceptoInventario As System.Windows.Forms.Label
    Friend WithEvents TpSeries As TabPage
    Friend WithEvents GridSeries As FlexCell.Grid
    Friend WithEvents TpArticulos As TabPage
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents lblDisplayProveedor As Label
    Friend WithEvents dtpFechaEntrega As DateTimePicker
    Friend WithEvents lblDisplayFolioOrdenCompra As Label
    Friend WithEvents lblDisplayFechaEntrega As Label
    Friend WithEvents txtFolioOrdenCompra As TextBox
    Friend WithEvents lblDisplayFleteOrdenCompra As Label
    Friend WithEvents txtFleteOrdenCompra As TextBox
    Friend WithEvents btnProrratearFleteOrdenCompra As Button
    Friend WithEvents lblDisplayEntradasAnterioresOrdenCompra As Label
    Friend WithEvents gbOrdenCompra As GroupBox
    Friend WithEvents cboEntradasAnterioresOrdenCompra As ComboBox
    Friend WithEvents btnNuevaOrdenCompra As Button
    Friend WithEvents btnConsultarOrdenCompra As Button
    Friend WithEvents txtTotalMasFlete As MaskedTextBox
    Friend WithEvents txtTotalFlete As MaskedTextBox
    Friend WithEvents btnSeleccionarArchivoSeries As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
