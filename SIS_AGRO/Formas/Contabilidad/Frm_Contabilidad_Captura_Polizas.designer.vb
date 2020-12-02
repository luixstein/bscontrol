<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Captura_Polizas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Captura_Polizas))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbValidarGrabadoLlamadoExterior = New System.Windows.Forms.ToolStripButton()
        Me.tsbDesaplicar = New System.Windows.Forms.ToolStripButton()
        Me.tsbAplicar = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbReactivar = New System.Windows.Forms.ToolStripButton()
        Me.tsbRecalcularImporte = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtTotalCargos = New System.Windows.Forms.MaskedTextBox()
        Me.TxtTotalAbonos = New System.Windows.Forms.MaskedTextBox()
        Me.LblDisplayTotales = New System.Windows.Forms.Label()
        Me.GbPolizaGlogal = New System.Windows.Forms.GroupBox()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.btnNombreCompleto = New System.Windows.Forms.Button()
        Me.LblEsContraPoliza = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.LnkContrapoliza = New System.Windows.Forms.LinkLabel()
        Me.lblDisplayContraPoliza = New System.Windows.Forms.Label()
        Me.LblDisplayConcepto2 = New System.Windows.Forms.Label()
        Me.gpbFacturasRecibidas = New System.Windows.Forms.GroupBox()
        Me.CboFacturasRecibidas = New System.Windows.Forms.ComboBox()
        Me.gbRenglones = New System.Windows.Forms.GroupBox()
        Me.txtImportarPoliza = New System.Windows.Forms.TextBox()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.lblFolioOrigen = New System.Windows.Forms.Label()
        Me.lblDisplayFolioOrigen = New System.Windows.Forms.Label()
        Me.TxtConcepto2 = New System.Windows.Forms.TextBox()
        Me.LblCodigoEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.CmbDocumento = New System.Windows.Forms.ComboBox()
        Me.LblDisplayTipo = New System.Windows.Forms.Label()
        Me.LblDisplayConcepto1 = New System.Windows.Forms.Label()
        Me.TxtConcepto1 = New System.Windows.Forms.TextBox()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFecha = New System.Windows.Forms.Label()
        Me.lblDisplayTotalDiferenciaCargosAbonos = New System.Windows.Forms.Label()
        Me.txtTotalDiferenciaCargosAbonos = New System.Windows.Forms.MaskedTextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grid1 = New FlexCell.Grid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblXMLPDFMsg = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtXMLsTotal = New System.Windows.Forms.MaskedTextBox()
        Me.txtXMLsImpuestosRetenidos = New System.Windows.Forms.MaskedTextBox()
        Me.txtXMLsImpuestosTrasladados = New System.Windows.Forms.MaskedTextBox()
        Me.txtXMLsSubtotal = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEliminarXML = New System.Windows.Forms.Button()
        Me.btnVerPDF = New System.Windows.Forms.Button()
        Me.btnVerXML = New System.Windows.Forms.Button()
        Me.btnAgregarPDF = New System.Windows.Forms.Button()
        Me.btnAgregarXML = New System.Windows.Forms.Button()
        Me.GridXMLs = New FlexCell.Grid()
        Me.chkDetallarGastos = New System.Windows.Forms.CheckBox()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.GbPolizaGlogal.SuspendLayout()
        Me.gpbFacturasRecibidas.SuspendLayout()
        Me.gbRenglones.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbValidarGrabadoLlamadoExterior, Me.tsbDesaplicar, Me.tsbAplicar, Me.tsbCancelar, Me.tsbReactivar, Me.tsbRecalcularImporte, Me.tsbImprimir, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1119, 27)
        Me.tsMenu.TabIndex = 2
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
        'tsbValidarGrabadoLlamadoExterior
        '
        Me.tsbValidarGrabadoLlamadoExterior.Image = CType(resources.GetObject("tsbValidarGrabadoLlamadoExterior.Image"), System.Drawing.Image)
        Me.tsbValidarGrabadoLlamadoExterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbValidarGrabadoLlamadoExterior.Name = "tsbValidarGrabadoLlamadoExterior"
        Me.tsbValidarGrabadoLlamadoExterior.Size = New System.Drawing.Size(66, 24)
        Me.tsbValidarGrabadoLlamadoExterior.Text = "&Grabar"
        Me.tsbValidarGrabadoLlamadoExterior.Visible = False
        '
        'tsbDesaplicar
        '
        Me.tsbDesaplicar.Image = CType(resources.GetObject("tsbDesaplicar.Image"), System.Drawing.Image)
        Me.tsbDesaplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDesaplicar.Name = "tsbDesaplicar"
        Me.tsbDesaplicar.Size = New System.Drawing.Size(85, 24)
        Me.tsbDesaplicar.Text = "&Desaplicar"
        '
        'tsbAplicar
        '
        Me.tsbAplicar.Image = Global.BsControl.My.Resources.Resources._782
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
        Me.tsbCancelar.Size = New System.Drawing.Size(77, 24)
        Me.tsbCancelar.Text = "&Cancelar"
        '
        'tsbReactivar
        '
        Me.tsbReactivar.Image = Global.BsControl.My.Resources.Resources._096
        Me.tsbReactivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReactivar.Name = "tsbReactivar"
        Me.tsbReactivar.Size = New System.Drawing.Size(79, 24)
        Me.tsbReactivar.Text = "&Reactivar"
        '
        'tsbRecalcularImporte
        '
        Me.tsbRecalcularImporte.Image = CType(resources.GetObject("tsbRecalcularImporte.Image"), System.Drawing.Image)
        Me.tsbRecalcularImporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecalcularImporte.Name = "tsbRecalcularImporte"
        Me.tsbRecalcularImporte.Size = New System.Drawing.Size(130, 24)
        Me.tsbRecalcularImporte.Text = "&Recalcular importe"
        Me.tsbRecalcularImporte.Visible = False
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(77, 24)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(53, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 525)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(1119, 24)
        Me.StatusStripEstado.TabIndex = 185
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssEstado
        '
        Me.tssEstado.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssEstado.Name = "tssEstado"
        Me.tssEstado.Size = New System.Drawing.Size(52, 19)
        Me.tssEstado.Text = "Estado :"
        '
        'tssElaboro
        '
        Me.tssElaboro.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssElaboro.Name = "tssElaboro"
        Me.tssElaboro.Size = New System.Drawing.Size(60, 19)
        Me.tssElaboro.Text = "Elaboró : "
        '
        'tssCancelo
        '
        Me.tssCancelo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssCancelo.Name = "tssCancelo"
        Me.tssCancelo.Size = New System.Drawing.Size(60, 19)
        Me.tssCancelo.Text = "Canceló :"
        '
        'TxtTotalCargos
        '
        Me.TxtTotalCargos.Location = New System.Drawing.Point(698, 311)
        Me.TxtTotalCargos.Name = "TxtTotalCargos"
        Me.TxtTotalCargos.ReadOnly = True
        Me.TxtTotalCargos.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalCargos.TabIndex = 205
        Me.TxtTotalCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalAbonos
        '
        Me.TxtTotalAbonos.Location = New System.Drawing.Point(804, 311)
        Me.TxtTotalAbonos.Name = "TxtTotalAbonos"
        Me.TxtTotalAbonos.ReadOnly = True
        Me.TxtTotalAbonos.Size = New System.Drawing.Size(100, 20)
        Me.TxtTotalAbonos.TabIndex = 206
        Me.TxtTotalAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotalAbonos.ValidatingType = GetType(Integer)
        '
        'LblDisplayTotales
        '
        Me.LblDisplayTotales.AutoSize = True
        Me.LblDisplayTotales.Location = New System.Drawing.Point(634, 314)
        Me.LblDisplayTotales.Name = "LblDisplayTotales"
        Me.LblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.LblDisplayTotales.TabIndex = 207
        Me.LblDisplayTotales.Text = "Totales :"
        '
        'GbPolizaGlogal
        '
        Me.GbPolizaGlogal.Controls.Add(Me.chkDetallarGastos)
        Me.GbPolizaGlogal.Controls.Add(Me.btnDocumentoSiguiente)
        Me.GbPolizaGlogal.Controls.Add(Me.btnDocumentoAnterior)
        Me.GbPolizaGlogal.Controls.Add(Me.btnNombreCompleto)
        Me.GbPolizaGlogal.Controls.Add(Me.LblEsContraPoliza)
        Me.GbPolizaGlogal.Controls.Add(Me.lblEstatus)
        Me.GbPolizaGlogal.Controls.Add(Me.LnkContrapoliza)
        Me.GbPolizaGlogal.Controls.Add(Me.lblDisplayContraPoliza)
        Me.GbPolizaGlogal.Controls.Add(Me.LblDisplayConcepto2)
        Me.GbPolizaGlogal.Controls.Add(Me.gpbFacturasRecibidas)
        Me.GbPolizaGlogal.Controls.Add(Me.gbRenglones)
        Me.GbPolizaGlogal.Controls.Add(Me.TxtFolio)
        Me.GbPolizaGlogal.Controls.Add(Me.LblDisplayFolio)
        Me.GbPolizaGlogal.Controls.Add(Me.lblFolioOrigen)
        Me.GbPolizaGlogal.Controls.Add(Me.lblDisplayFolioOrigen)
        Me.GbPolizaGlogal.Controls.Add(Me.TxtConcepto2)
        Me.GbPolizaGlogal.Controls.Add(Me.LblCodigoEstatus)
        Me.GbPolizaGlogal.Controls.Add(Me.lblDisplayStatus)
        Me.GbPolizaGlogal.Controls.Add(Me.CmbDocumento)
        Me.GbPolizaGlogal.Controls.Add(Me.LblDisplayTipo)
        Me.GbPolizaGlogal.Controls.Add(Me.LblDisplayConcepto1)
        Me.GbPolizaGlogal.Controls.Add(Me.TxtConcepto1)
        Me.GbPolizaGlogal.Controls.Add(Me.DtpFecha)
        Me.GbPolizaGlogal.Controls.Add(Me.LblDisplayFecha)
        Me.GbPolizaGlogal.Location = New System.Drawing.Point(4, 28)
        Me.GbPolizaGlogal.Name = "GbPolizaGlogal"
        Me.GbPolizaGlogal.Size = New System.Drawing.Size(1103, 125)
        Me.GbPolizaGlogal.TabIndex = 0
        Me.GbPolizaGlogal.TabStop = False
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(255, 46)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoSiguiente.TabIndex = 380
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(227, 46)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoAnterior.TabIndex = 379
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'btnNombreCompleto
        '
        Me.btnNombreCompleto.Location = New System.Drawing.Point(874, 71)
        Me.btnNombreCompleto.Name = "btnNombreCompleto"
        Me.btnNombreCompleto.Size = New System.Drawing.Size(122, 23)
        Me.btnNombreCompleto.TabIndex = 227
        Me.btnNombreCompleto.Text = "Nombre completo >>"
        Me.btnNombreCompleto.UseVisualStyleBackColor = True
        '
        'LblEsContraPoliza
        '
        Me.LblEsContraPoliza.AutoSize = True
        Me.LblEsContraPoliza.Location = New System.Drawing.Point(485, 50)
        Me.LblEsContraPoliza.Name = "LblEsContraPoliza"
        Me.LblEsContraPoliza.Size = New System.Drawing.Size(79, 13)
        Me.LblEsContraPoliza.TabIndex = 226
        Me.LblEsContraPoliza.Text = "Es contrapóliza"
        Me.LblEsContraPoliza.Visible = False
        '
        'lblEstatus
        '
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEstatus.Location = New System.Drawing.Point(347, 50)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(103, 13)
        Me.lblEstatus.TabIndex = 225
        Me.lblEstatus.Text = "."
        '
        'LnkContrapoliza
        '
        Me.LnkContrapoliza.Location = New System.Drawing.Point(560, 50)
        Me.LnkContrapoliza.Name = "LnkContrapoliza"
        Me.LnkContrapoliza.Size = New System.Drawing.Size(103, 13)
        Me.LnkContrapoliza.TabIndex = 224
        Me.LnkContrapoliza.TabStop = True
        Me.LnkContrapoliza.Text = "."
        '
        'lblDisplayContraPoliza
        '
        Me.lblDisplayContraPoliza.AutoSize = True
        Me.lblDisplayContraPoliza.Location = New System.Drawing.Point(456, 50)
        Me.lblDisplayContraPoliza.Name = "lblDisplayContraPoliza"
        Me.lblDisplayContraPoliza.Size = New System.Drawing.Size(96, 13)
        Me.lblDisplayContraPoliza.TabIndex = 223
        Me.lblDisplayContraPoliza.Text = "Folio Contrapoliza :"
        '
        'LblDisplayConcepto2
        '
        Me.LblDisplayConcepto2.AutoSize = True
        Me.LblDisplayConcepto2.Location = New System.Drawing.Point(8, 102)
        Me.LblDisplayConcepto2.Name = "LblDisplayConcepto2"
        Me.LblDisplayConcepto2.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayConcepto2.TabIndex = 222
        Me.LblDisplayConcepto2.Text = "Concepto 2 :"
        '
        'gpbFacturasRecibidas
        '
        Me.gpbFacturasRecibidas.Controls.Add(Me.CboFacturasRecibidas)
        Me.gpbFacturasRecibidas.Location = New System.Drawing.Point(669, 14)
        Me.gpbFacturasRecibidas.Name = "gpbFacturasRecibidas"
        Me.gpbFacturasRecibidas.Size = New System.Drawing.Size(185, 53)
        Me.gpbFacturasRecibidas.TabIndex = 220
        Me.gpbFacturasRecibidas.TabStop = False
        Me.gpbFacturasRecibidas.Text = "Facturas recibidas :"
        '
        'CboFacturasRecibidas
        '
        Me.CboFacturasRecibidas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFacturasRecibidas.FormattingEnabled = True
        Me.CboFacturasRecibidas.Location = New System.Drawing.Point(33, 25)
        Me.CboFacturasRecibidas.Name = "CboFacturasRecibidas"
        Me.CboFacturasRecibidas.Size = New System.Drawing.Size(135, 21)
        Me.CboFacturasRecibidas.TabIndex = 301
        '
        'gbRenglones
        '
        Me.gbRenglones.Controls.Add(Me.txtImportarPoliza)
        Me.gbRenglones.Location = New System.Drawing.Point(669, 66)
        Me.gbRenglones.Name = "gbRenglones"
        Me.gbRenglones.Size = New System.Drawing.Size(185, 53)
        Me.gbRenglones.TabIndex = 218
        Me.gbRenglones.TabStop = False
        Me.gbRenglones.Text = "Importar renglones  de la póliza :"
        '
        'txtImportarPoliza
        '
        Me.txtImportarPoliza.Location = New System.Drawing.Point(33, 27)
        Me.txtImportarPoliza.MaxLength = 15
        Me.txtImportarPoliza.Name = "txtImportarPoliza"
        Me.txtImportarPoliza.Size = New System.Drawing.Size(135, 20)
        Me.txtImportarPoliza.TabIndex = 227
        '
        'TxtFolio
        '
        Me.TxtFolio.Location = New System.Drawing.Point(87, 47)
        Me.TxtFolio.MaxLength = 15
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(135, 20)
        Me.TxtFolio.TabIndex = 1
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(9, 50)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 217
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'lblFolioOrigen
        '
        Me.lblFolioOrigen.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFolioOrigen.Location = New System.Drawing.Point(560, 22)
        Me.lblFolioOrigen.Name = "lblFolioOrigen"
        Me.lblFolioOrigen.Size = New System.Drawing.Size(103, 13)
        Me.lblFolioOrigen.TabIndex = 216
        Me.lblFolioOrigen.Text = "."
        '
        'lblDisplayFolioOrigen
        '
        Me.lblDisplayFolioOrigen.AutoSize = True
        Me.lblDisplayFolioOrigen.Location = New System.Drawing.Point(485, 22)
        Me.lblDisplayFolioOrigen.Name = "lblDisplayFolioOrigen"
        Me.lblDisplayFolioOrigen.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayFolioOrigen.TabIndex = 215
        Me.lblDisplayFolioOrigen.Text = "Folio origen :"
        '
        'TxtConcepto2
        '
        Me.TxtConcepto2.Location = New System.Drawing.Point(87, 99)
        Me.TxtConcepto2.MaxLength = 80
        Me.TxtConcepto2.Name = "TxtConcepto2"
        Me.TxtConcepto2.Size = New System.Drawing.Size(576, 20)
        Me.TxtConcepto2.TabIndex = 3
        '
        'LblCodigoEstatus
        '
        Me.LblCodigoEstatus.AutoSize = True
        Me.LblCodigoEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblCodigoEstatus.Location = New System.Drawing.Point(286, 50)
        Me.LblCodigoEstatus.Name = "LblCodigoEstatus"
        Me.LblCodigoEstatus.Size = New System.Drawing.Size(10, 13)
        Me.LblCodigoEstatus.TabIndex = 214
        Me.LblCodigoEstatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(302, 50)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 213
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'CmbDocumento
        '
        Me.CmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDocumento.FormattingEnabled = True
        Me.CmbDocumento.Location = New System.Drawing.Point(87, 19)
        Me.CmbDocumento.Name = "CmbDocumento"
        Me.CmbDocumento.Size = New System.Drawing.Size(135, 21)
        Me.CmbDocumento.TabIndex = 0
        '
        'LblDisplayTipo
        '
        Me.LblDisplayTipo.AutoSize = True
        Me.LblDisplayTipo.Location = New System.Drawing.Point(9, 22)
        Me.LblDisplayTipo.Name = "LblDisplayTipo"
        Me.LblDisplayTipo.Size = New System.Drawing.Size(34, 13)
        Me.LblDisplayTipo.TabIndex = 212
        Me.LblDisplayTipo.Text = "Tipo :"
        '
        'LblDisplayConcepto1
        '
        Me.LblDisplayConcepto1.AutoSize = True
        Me.LblDisplayConcepto1.Location = New System.Drawing.Point(9, 77)
        Me.LblDisplayConcepto1.Name = "LblDisplayConcepto1"
        Me.LblDisplayConcepto1.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayConcepto1.TabIndex = 211
        Me.LblDisplayConcepto1.Text = "Concepto 1 :"
        '
        'TxtConcepto1
        '
        Me.TxtConcepto1.Location = New System.Drawing.Point(87, 74)
        Me.TxtConcepto1.MaxLength = 80
        Me.TxtConcepto1.Name = "TxtConcepto1"
        Me.TxtConcepto1.Size = New System.Drawing.Size(576, 20)
        Me.TxtConcepto1.TabIndex = 2
        '
        'DtpFecha
        '
        Me.DtpFecha.Location = New System.Drawing.Point(274, 19)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(202, 20)
        Me.DtpFecha.TabIndex = 4
        '
        'LblDisplayFecha
        '
        Me.LblDisplayFecha.AutoSize = True
        Me.LblDisplayFecha.Location = New System.Drawing.Point(225, 22)
        Me.LblDisplayFecha.Name = "LblDisplayFecha"
        Me.LblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblDisplayFecha.TabIndex = 210
        Me.LblDisplayFecha.Text = "Fecha :"
        '
        'lblDisplayTotalDiferenciaCargosAbonos
        '
        Me.lblDisplayTotalDiferenciaCargosAbonos.AutoSize = True
        Me.lblDisplayTotalDiferenciaCargosAbonos.Location = New System.Drawing.Point(335, 314)
        Me.lblDisplayTotalDiferenciaCargosAbonos.Name = "lblDisplayTotalDiferenciaCargosAbonos"
        Me.lblDisplayTotalDiferenciaCargosAbonos.Size = New System.Drawing.Size(134, 13)
        Me.lblDisplayTotalDiferenciaCargosAbonos.TabIndex = 212
        Me.lblDisplayTotalDiferenciaCargosAbonos.Text = "Diferencia cargos-abonos :"
        '
        'txtTotalDiferenciaCargosAbonos
        '
        Me.txtTotalDiferenciaCargosAbonos.Location = New System.Drawing.Point(495, 311)
        Me.txtTotalDiferenciaCargosAbonos.Name = "txtTotalDiferenciaCargosAbonos"
        Me.txtTotalDiferenciaCargosAbonos.ReadOnly = True
        Me.txtTotalDiferenciaCargosAbonos.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDiferenciaCargosAbonos.TabIndex = 211
        Me.txtTotalDiferenciaCargosAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalDiferenciaCargosAbonos.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 159)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1103, 362)
        Me.TabControl1.TabIndex = 213
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid1)
        Me.TabPage1.Controls.Add(Me.lblDisplayTotalDiferenciaCargosAbonos)
        Me.TabPage1.Controls.Add(Me.TxtTotalAbonos)
        Me.TabPage1.Controls.Add(Me.TxtTotalCargos)
        Me.TabPage1.Controls.Add(Me.txtTotalDiferenciaCargosAbonos)
        Me.TabPage1.Controls.Add(Me.LblDisplayTotales)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1095, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Renglones póliza"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Grid1
        '
        Me.Grid1.AllowUserResizing = FlexCell.ResizeEnum.Rows
        Me.Grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 1
        Me.Grid1.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid1.DefaultRowHeight = CType(24, Short)
        Me.Grid1.DisplayRowNumber = True
        Me.Grid1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(8, 6)
        Me.Grid1.LockButton = True
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 10
        Me.Grid1.Size = New System.Drawing.Size(1081, 299)
        Me.Grid1.TabIndex = 1
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblXMLPDFMsg)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.txtXMLsTotal)
        Me.TabPage2.Controls.Add(Me.txtXMLsImpuestosRetenidos)
        Me.TabPage2.Controls.Add(Me.txtXMLsImpuestosTrasladados)
        Me.TabPage2.Controls.Add(Me.txtXMLsSubtotal)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.btnEliminarXML)
        Me.TabPage2.Controls.Add(Me.btnVerPDF)
        Me.TabPage2.Controls.Add(Me.btnVerXML)
        Me.TabPage2.Controls.Add(Me.btnAgregarPDF)
        Me.TabPage2.Controls.Add(Me.btnAgregarXML)
        Me.TabPage2.Controls.Add(Me.GridXMLs)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1095, 336)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "XML's"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblXMLPDFMsg
        '
        Me.lblXMLPDFMsg.AutoSize = True
        Me.lblXMLPDFMsg.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblXMLPDFMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXMLPDFMsg.ForeColor = System.Drawing.SystemColors.Window
        Me.lblXMLPDFMsg.Location = New System.Drawing.Point(55, 269)
        Me.lblXMLPDFMsg.Name = "lblXMLPDFMsg"
        Me.lblXMLPDFMsg.Size = New System.Drawing.Size(214, 15)
        Me.lblXMLPDFMsg.TabIndex = 242
        Me.lblXMLPDFMsg.Text = "PDF relacionado correctamente."
        Me.lblXMLPDFMsg.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(940, 292)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(855, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Imp. retenidos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(770, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 239
        Me.Label3.Text = "Imp. trasladados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(685, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Subtotal"
        '
        'txtXMLsTotal
        '
        Me.txtXMLsTotal.Location = New System.Drawing.Point(943, 308)
        Me.txtXMLsTotal.Name = "txtXMLsTotal"
        Me.txtXMLsTotal.ReadOnly = True
        Me.txtXMLsTotal.Size = New System.Drawing.Size(79, 20)
        Me.txtXMLsTotal.TabIndex = 237
        Me.txtXMLsTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtXMLsImpuestosRetenidos
        '
        Me.txtXMLsImpuestosRetenidos.Location = New System.Drawing.Point(858, 308)
        Me.txtXMLsImpuestosRetenidos.Name = "txtXMLsImpuestosRetenidos"
        Me.txtXMLsImpuestosRetenidos.ReadOnly = True
        Me.txtXMLsImpuestosRetenidos.Size = New System.Drawing.Size(79, 20)
        Me.txtXMLsImpuestosRetenidos.TabIndex = 236
        Me.txtXMLsImpuestosRetenidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtXMLsImpuestosTrasladados
        '
        Me.txtXMLsImpuestosTrasladados.Location = New System.Drawing.Point(773, 308)
        Me.txtXMLsImpuestosTrasladados.Name = "txtXMLsImpuestosTrasladados"
        Me.txtXMLsImpuestosTrasladados.ReadOnly = True
        Me.txtXMLsImpuestosTrasladados.Size = New System.Drawing.Size(79, 20)
        Me.txtXMLsImpuestosTrasladados.TabIndex = 235
        Me.txtXMLsImpuestosTrasladados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtXMLsSubtotal
        '
        Me.txtXMLsSubtotal.Location = New System.Drawing.Point(688, 308)
        Me.txtXMLsSubtotal.Name = "txtXMLsSubtotal"
        Me.txtXMLsSubtotal.ReadOnly = True
        Me.txtXMLsSubtotal.Size = New System.Drawing.Size(79, 20)
        Me.txtXMLsSubtotal.TabIndex = 234
        Me.txtXMLsSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(611, 311)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 233
        Me.Label1.Text = "Totales :"
        '
        'btnEliminarXML
        '
        Me.btnEliminarXML.Image = Global.BsControl.My.Resources.Resources.xml1
        Me.btnEliminarXML.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminarXML.Location = New System.Drawing.Point(600, 227)
        Me.btnEliminarXML.Name = "btnEliminarXML"
        Me.btnEliminarXML.Size = New System.Drawing.Size(76, 36)
        Me.btnEliminarXML.TabIndex = 232
        Me.btnEliminarXML.Text = "Eliminar"
        Me.btnEliminarXML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarXML.UseVisualStyleBackColor = True
        '
        'btnVerPDF
        '
        Me.btnVerPDF.Image = Global.BsControl.My.Resources.Resources.pdf11
        Me.btnVerPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerPDF.Location = New System.Drawing.Point(518, 269)
        Me.btnVerPDF.Name = "btnVerPDF"
        Me.btnVerPDF.Size = New System.Drawing.Size(76, 36)
        Me.btnVerPDF.TabIndex = 231
        Me.btnVerPDF.Text = "Ver"
        Me.btnVerPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerPDF.UseVisualStyleBackColor = True
        '
        'btnVerXML
        '
        Me.btnVerXML.Image = Global.BsControl.My.Resources.Resources.xml1
        Me.btnVerXML.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerXML.Location = New System.Drawing.Point(518, 227)
        Me.btnVerXML.Name = "btnVerXML"
        Me.btnVerXML.Size = New System.Drawing.Size(76, 36)
        Me.btnVerXML.TabIndex = 230
        Me.btnVerXML.Text = "Ver"
        Me.btnVerXML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerXML.UseVisualStyleBackColor = True
        '
        'btnAgregarPDF
        '
        Me.btnAgregarPDF.Image = Global.BsControl.My.Resources.Resources.pdf11
        Me.btnAgregarPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarPDF.Location = New System.Drawing.Point(436, 269)
        Me.btnAgregarPDF.Name = "btnAgregarPDF"
        Me.btnAgregarPDF.Size = New System.Drawing.Size(76, 36)
        Me.btnAgregarPDF.TabIndex = 229
        Me.btnAgregarPDF.Text = "Agregar "
        Me.btnAgregarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarPDF.UseVisualStyleBackColor = True
        '
        'btnAgregarXML
        '
        Me.btnAgregarXML.Image = Global.BsControl.My.Resources.Resources.xml1
        Me.btnAgregarXML.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarXML.Location = New System.Drawing.Point(436, 227)
        Me.btnAgregarXML.Name = "btnAgregarXML"
        Me.btnAgregarXML.Size = New System.Drawing.Size(76, 36)
        Me.btnAgregarXML.TabIndex = 228
        Me.btnAgregarXML.Text = "Agregar "
        Me.btnAgregarXML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarXML.UseVisualStyleBackColor = True
        '
        'GridXMLs
        '
        Me.GridXMLs.AllowUserSort = True
        Me.GridXMLs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridXMLs.CheckedImage = CType(resources.GetObject("GridXMLs.CheckedImage"), System.Drawing.Bitmap)
        Me.GridXMLs.Cols = 1
        Me.GridXMLs.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridXMLs.DefaultRowHeight = CType(24, Short)
        Me.GridXMLs.DisplayRowNumber = True
        Me.GridXMLs.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridXMLs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridXMLs.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridXMLs.Location = New System.Drawing.Point(8, 6)
        Me.GridXMLs.LockButton = True
        Me.GridXMLs.Name = "GridXMLs"
        Me.GridXMLs.Rows = 8
        Me.GridXMLs.Size = New System.Drawing.Size(1081, 213)
        Me.GridXMLs.TabIndex = 2
        Me.GridXMLs.UncheckedImage = CType(resources.GetObject("GridXMLs.UncheckedImage"), System.Drawing.Bitmap)
        '
        'chkDetallarGastos
        '
        Me.chkDetallarGastos.AutoSize = True
        Me.chkDetallarGastos.Location = New System.Drawing.Point(874, 101)
        Me.chkDetallarGastos.Name = "chkDetallarGastos"
        Me.chkDetallarGastos.Size = New System.Drawing.Size(96, 17)
        Me.chkDetallarGastos.TabIndex = 381
        Me.chkDetallarGastos.Text = "Detallar gastos"
        Me.chkDetallarGastos.UseVisualStyleBackColor = True
        '
        'Frm_Contabilidad_Captura_Polizas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 549)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GbPolizaGlogal)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_Captura_Polizas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de pólizas."
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.GbPolizaGlogal.ResumeLayout(False)
        Me.GbPolizaGlogal.PerformLayout()
        Me.gpbFacturasRecibidas.ResumeLayout(False)
        Me.gbRenglones.ResumeLayout(False)
        Me.gbRenglones.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbReactivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtTotalCargos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TxtTotalAbonos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents tsbDesaplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GbPolizaGlogal As System.Windows.Forms.GroupBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents lblFolioOrigen As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFolioOrigen As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto2 As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents CmbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayTipo As System.Windows.Forms.Label
    Friend WithEvents LblDisplayConcepto1 As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto1 As System.Windows.Forms.TextBox
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbRenglones As System.Windows.Forms.GroupBox
    Friend WithEvents tsbValidarGrabadoLlamadoExterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents gpbFacturasRecibidas As System.Windows.Forms.GroupBox
    Friend WithEvents CboFacturasRecibidas As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayConcepto2 As System.Windows.Forms.Label
    Friend WithEvents lblDisplayContraPoliza As System.Windows.Forms.Label
    Friend WithEvents LnkContrapoliza As System.Windows.Forms.LinkLabel
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents tsbRecalcularImporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblEsContraPoliza As System.Windows.Forms.Label
    Friend WithEvents txtImportarPoliza As System.Windows.Forms.TextBox
    Friend WithEvents btnNombreCompleto As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents lblDisplayTotalDiferenciaCargosAbonos As System.Windows.Forms.Label
    Friend WithEvents txtTotalDiferenciaCargosAbonos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnAgregarPDF As Button
    Friend WithEvents btnAgregarXML As Button
    Friend WithEvents GridXMLs As FlexCell.Grid
    Friend WithEvents btnVerPDF As Button
    Friend WithEvents btnVerXML As Button
    Friend WithEvents btnEliminarXML As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtXMLsTotal As MaskedTextBox
    Friend WithEvents txtXMLsImpuestosRetenidos As MaskedTextBox
    Friend WithEvents txtXMLsImpuestosTrasladados As MaskedTextBox
    Friend WithEvents txtXMLsSubtotal As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblXMLPDFMsg As Label
    Friend WithEvents chkDetallarGastos As CheckBox
End Class
