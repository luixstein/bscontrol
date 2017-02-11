<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPolizaCostos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPolizaCostos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.gbRenglones = New System.Windows.Forms.GroupBox()
        Me.txtFolioImportarPoliza = New System.Windows.Forms.TextBox()
        Me.LblDisplayConcepto1 = New System.Windows.Forms.Label()
        Me.TxtConcepto1 = New System.Windows.Forms.TextBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.gbCuentas = New System.Windows.Forms.GroupBox()
        Me.GridCostos = New FlexCell.Grid()
        Me.gbActivos = New System.Windows.Forms.GroupBox()
        Me.GridActivos = New FlexCell.Grid()
        Me.lblDisplayTotales = New System.Windows.Forms.Label()
        Me.txtTotalAbonos = New System.Windows.Forms.MaskedTextBox()
        Me.txtTotalCargos = New System.Windows.Forms.MaskedTextBox()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.LblCodigoEstatus = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.gbProveedor.SuspendLayout()
        Me.gbRenglones.SuspendLayout()
        Me.gbCuentas.SuspendLayout()
        Me.gbActivos.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbCancelar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(995, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(76, 22)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(7, 13)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 337
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(69, 9)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(102, 20)
        Me.txtFolio.TabIndex = 0
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(174, 8)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoAnterior.TabIndex = 379
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
        '
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(205, 8)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(25, 21)
        Me.btnDocumentoSiguiente.TabIndex = 380
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.LblCodigoEstatus)
        Me.gbProveedor.Controls.Add(Me.lblEstatus)
        Me.gbProveedor.Controls.Add(Me.lblDisplayStatus)
        Me.gbProveedor.Controls.Add(Me.gbRenglones)
        Me.gbProveedor.Controls.Add(Me.LblDisplayConcepto1)
        Me.gbProveedor.Controls.Add(Me.TxtConcepto1)
        Me.gbProveedor.Controls.Add(Me.dtFecha)
        Me.gbProveedor.Controls.Add(Me.lblDisplayFecha)
        Me.gbProveedor.Controls.Add(Me.btnDocumentoSiguiente)
        Me.gbProveedor.Controls.Add(Me.btnDocumentoAnterior)
        Me.gbProveedor.Controls.Add(Me.txtFolio)
        Me.gbProveedor.Controls.Add(Me.LblDisplayFolio)
        Me.gbProveedor.Location = New System.Drawing.Point(4, 28)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(982, 70)
        Me.gbProveedor.TabIndex = 1
        Me.gbProveedor.TabStop = False
        '
        'gbRenglones
        '
        Me.gbRenglones.Controls.Add(Me.txtFolioImportarPoliza)
        Me.gbRenglones.Location = New System.Drawing.Point(781, 13)
        Me.gbRenglones.Name = "gbRenglones"
        Me.gbRenglones.Size = New System.Drawing.Size(185, 53)
        Me.gbRenglones.TabIndex = 385
        Me.gbRenglones.TabStop = False
        Me.gbRenglones.Text = "Importar renglones  de la póliza :"
        '
        'txtFolioImportarPoliza
        '
        Me.txtFolioImportarPoliza.Location = New System.Drawing.Point(33, 27)
        Me.txtFolioImportarPoliza.MaxLength = 15
        Me.txtFolioImportarPoliza.Name = "txtFolioImportarPoliza"
        Me.txtFolioImportarPoliza.Size = New System.Drawing.Size(135, 20)
        Me.txtFolioImportarPoliza.TabIndex = 0
        '
        'LblDisplayConcepto1
        '
        Me.LblDisplayConcepto1.AutoSize = True
        Me.LblDisplayConcepto1.Location = New System.Drawing.Point(8, 42)
        Me.LblDisplayConcepto1.Name = "LblDisplayConcepto1"
        Me.LblDisplayConcepto1.Size = New System.Drawing.Size(59, 13)
        Me.LblDisplayConcepto1.TabIndex = 384
        Me.LblDisplayConcepto1.Text = "Concepto :"
        '
        'TxtConcepto1
        '
        Me.TxtConcepto1.Location = New System.Drawing.Point(69, 39)
        Me.TxtConcepto1.MaxLength = 80
        Me.TxtConcepto1.Name = "TxtConcepto1"
        Me.TxtConcepto1.Size = New System.Drawing.Size(576, 20)
        Me.TxtConcepto1.TabIndex = 2
        '
        'dtFecha
        '
        Me.dtFecha.Location = New System.Drawing.Point(301, 9)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(214, 20)
        Me.dtFecha.TabIndex = 1
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(252, 13)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 382
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'gbCuentas
        '
        Me.gbCuentas.Controls.Add(Me.GridCostos)
        Me.gbCuentas.Location = New System.Drawing.Point(4, 296)
        Me.gbCuentas.Name = "gbCuentas"
        Me.gbCuentas.Size = New System.Drawing.Size(982, 188)
        Me.gbCuentas.TabIndex = 3
        Me.gbCuentas.TabStop = False
        Me.gbCuentas.Text = "Centros de costos :"
        '
        'GridCostos
        '
        Me.GridCostos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridCostos.CheckedImage = CType(resources.GetObject("GridCostos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridCostos.Cols = 1
        Me.GridCostos.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridCostos.DisplayRowNumber = True
        Me.GridCostos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridCostos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCostos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCostos.Location = New System.Drawing.Point(6, 19)
        Me.GridCostos.LockButton = True
        Me.GridCostos.Name = "GridCostos"
        Me.GridCostos.Rows = 2
        Me.GridCostos.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GridCostos.Size = New System.Drawing.Size(970, 163)
        Me.GridCostos.TabIndex = 0
        Me.GridCostos.UncheckedImage = CType(resources.GetObject("GridCostos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbActivos
        '
        Me.gbActivos.Controls.Add(Me.GridActivos)
        Me.gbActivos.Location = New System.Drawing.Point(4, 102)
        Me.gbActivos.Name = "gbActivos"
        Me.gbActivos.Size = New System.Drawing.Size(982, 188)
        Me.gbActivos.TabIndex = 2
        Me.gbActivos.TabStop = False
        Me.gbActivos.Text = "Activos y deudores diversos  :"
        '
        'GridActivos
        '
        Me.GridActivos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridActivos.CheckedImage = CType(resources.GetObject("GridActivos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridActivos.Cols = 1
        Me.GridActivos.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridActivos.DisplayRowNumber = True
        Me.GridActivos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridActivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridActivos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridActivos.Location = New System.Drawing.Point(6, 19)
        Me.GridActivos.LockButton = True
        Me.GridActivos.Name = "GridActivos"
        Me.GridActivos.Rows = 2
        Me.GridActivos.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GridActivos.Size = New System.Drawing.Size(970, 163)
        Me.GridActivos.TabIndex = 0
        Me.GridActivos.UncheckedImage = CType(resources.GetObject("GridActivos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(660, 538)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTotales.TabIndex = 210
        Me.lblDisplayTotales.Text = "Totales :"
        '
        'txtTotalAbonos
        '
        Me.txtTotalAbonos.Location = New System.Drawing.Point(827, 535)
        Me.txtTotalAbonos.Name = "txtTotalAbonos"
        Me.txtTotalAbonos.ReadOnly = True
        Me.txtTotalAbonos.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalAbonos.TabIndex = 209
        Me.txtTotalAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalAbonos.ValidatingType = GetType(Integer)
        '
        'txtTotalCargos
        '
        Me.txtTotalCargos.Location = New System.Drawing.Point(724, 535)
        Me.txtTotalCargos.Name = "txtTotalCargos"
        Me.txtTotalCargos.ReadOnly = True
        Me.txtTotalCargos.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCargos.TabIndex = 208
        Me.txtTotalCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 561)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(995, 24)
        Me.StatusStripEstado.TabIndex = 211
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
        'lblEstatus
        '
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEstatus.Location = New System.Drawing.Point(593, 13)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(103, 13)
        Me.lblEstatus.TabIndex = 387
        Me.lblEstatus.Text = "."
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(523, 13)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 386
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'LblCodigoEstatus
        '
        Me.LblCodigoEstatus.AutoSize = True
        Me.LblCodigoEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.LblCodigoEstatus.Location = New System.Drawing.Point(577, 13)
        Me.LblCodigoEstatus.Name = "LblCodigoEstatus"
        Me.LblCodigoEstatus.Size = New System.Drawing.Size(10, 13)
        Me.LblCodigoEstatus.TabIndex = 388
        Me.LblCodigoEstatus.Text = "."
        '
        'FrmPolizaCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 585)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.lblDisplayTotales)
        Me.Controls.Add(Me.txtTotalAbonos)
        Me.Controls.Add(Me.txtTotalCargos)
        Me.Controls.Add(Me.gbActivos)
        Me.Controls.Add(Me.gbCuentas)
        Me.Controls.Add(Me.gbProveedor)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmPolizaCostos"
        Me.Text = "Pólizas de costos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        Me.gbRenglones.ResumeLayout(False)
        Me.gbRenglones.PerformLayout()
        Me.gbCuentas.ResumeLayout(False)
        Me.gbActivos.ResumeLayout(False)
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents gbProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents LblDisplayConcepto1 As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto1 As System.Windows.Forms.TextBox
    Friend WithEvents gbRenglones As System.Windows.Forms.GroupBox
    Friend WithEvents txtFolioImportarPoliza As System.Windows.Forms.TextBox
    Friend WithEvents gbCuentas As System.Windows.Forms.GroupBox
    Friend WithEvents GridCostos As FlexCell.Grid
    Friend WithEvents gbActivos As System.Windows.Forms.GroupBox
    Friend WithEvents GridActivos As FlexCell.Grid
    Friend WithEvents lblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents txtTotalAbonos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTotalCargos As System.Windows.Forms.MaskedTextBox
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents LblCodigoEstatus As System.Windows.Forms.Label
End Class
