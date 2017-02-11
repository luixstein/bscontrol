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
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbAplicar, Me.tsbCancelar, Me.tsbImprimir, Me.tsbEditarCostos, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1090, 25)
        Me.tsMenu.TabIndex = 223
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
        'tsbAplicar
        '
        Me.tsbAplicar.Image = CType(resources.GetObject("tsbAplicar.Image"), System.Drawing.Image)
        Me.tsbAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAplicar.Name = "tsbAplicar"
        Me.tsbAplicar.Size = New System.Drawing.Size(64, 22)
        Me.tsbAplicar.Text = "&Aplicar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 22)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbEditarCostos
        '
        Me.tsbEditarCostos.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbEditarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditarCostos.Name = "tsbEditarCostos"
        Me.tsbEditarCostos.Size = New System.Drawing.Size(94, 22)
        Me.tsbEditarCostos.Text = "&Editar costos"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(476, 403)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 273
        Me.Label6.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(519, 400)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 272
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Grid1
        '
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(12, 142)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 20
        Me.Grid1.Size = New System.Drawing.Size(1074, 252)
        Me.Grid1.TabIndex = 7
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 267
        Me.Label3.Text = "Almacén :"
        '
        'TxtFolioReferencia
        '
        Me.TxtFolioReferencia.Location = New System.Drawing.Point(106, 78)
        Me.TxtFolioReferencia.MaxLength = 160
        Me.TxtFolioReferencia.Name = "TxtFolioReferencia"
        Me.TxtFolioReferencia.Size = New System.Drawing.Size(135, 20)
        Me.TxtFolioReferencia.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 266
        Me.Label2.Text = "Referencia :"
        '
        'LblDisplayDireccionEmpresa
        '
        Me.LblDisplayDireccionEmpresa.AutoSize = True
        Me.LblDisplayDireccionEmpresa.Location = New System.Drawing.Point(21, 107)
        Me.LblDisplayDireccionEmpresa.Name = "LblDisplayDireccionEmpresa"
        Me.LblDisplayDireccionEmpresa.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayDireccionEmpresa.TabIndex = 265
        Me.LblDisplayDireccionEmpresa.Text = "Concepto :"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.Location = New System.Drawing.Point(106, 104)
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
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(417, 54)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 261
        Me.LblFecha.Text = "Fecha :"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblStatus.Location = New System.Drawing.Point(899, 51)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(10, 13)
        Me.LblStatus.TabIndex = 260
        Me.LblStatus.Text = "."
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
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(425, 32)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 258
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 471)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1090, 24)
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
        'LblDocumento
        '
        Me.LblDocumento.AutoSize = True
        Me.LblDocumento.Location = New System.Drawing.Point(21, 31)
        Me.LblDocumento.Name = "LblDocumento"
        Me.LblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.LblDocumento.TabIndex = 256
        Me.LblDocumento.Text = "Documento :"
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(840, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 285
        Me.Label8.Text = "Póliza :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(242, 403)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Cantidad total :"
        '
        'txtTotalCantidad
        '
        Me.txtTotalCantidad.Location = New System.Drawing.Point(326, 400)
        Me.txtTotalCantidad.Name = "txtTotalCantidad"
        Me.txtTotalCantidad.ReadOnly = True
        Me.txtTotalCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCantidad.TabIndex = 287
        Me.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(899, 75)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(13, 13)
        Me.LblPoliza.TabIndex = 329
        Me.LblPoliza.TabStop = True
        Me.LblPoliza.Text = "_"
        '
        'txtFolioEmbarque
        '
        Me.txtFolioEmbarque.Location = New System.Drawing.Point(789, 104)
        Me.txtFolioEmbarque.MaxLength = 15
        Me.txtFolioEmbarque.Name = "txtFolioEmbarque"
        Me.txtFolioEmbarque.Size = New System.Drawing.Size(135, 20)
        Me.txtFolioEmbarque.TabIndex = 330
        Me.txtFolioEmbarque.Visible = False
        '
        'lblDisplayFolioEmbarque
        '
        Me.lblDisplayFolioEmbarque.AutoSize = True
        Me.lblDisplayFolioEmbarque.Location = New System.Drawing.Point(700, 107)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(699, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 333
        Me.Label4.Text = "Copiar renglones :"
        Me.Label4.Visible = False
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
        'Inventarios_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 495)
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
        Me.Controls.Add(Me.Grid1)
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
        Me.MaximizeBox = False
        Me.Name = "Inventarios_Movimientos"
        Me.Text = "Inventarios movimientos"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
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
End Class
