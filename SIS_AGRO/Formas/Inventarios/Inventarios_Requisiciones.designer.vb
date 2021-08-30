<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventarios_Requisiciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventarios_Requisiciones))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSolicitar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbAnular = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblDisplayAlmacen = New System.Windows.Forms.Label()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.dtFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblDisplayFolio = New System.Windows.Forms.Label()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslSolicito = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCancelo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnDocumentoSiguiente = New System.Windows.Forms.Button()
        Me.btnDocumentoAnterior = New System.Windows.Forms.Button()
        Me.Grid1 = New FlexCell.Grid()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblNombreEstatus = New System.Windows.Forms.Label()
        Me.txtComprador = New System.Windows.Forms.TextBox()
        Me.lblDisplayComprador = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblComprador = New System.Windows.Forms.Label()
        Me.CboPrioridad = New System.Windows.Forms.ComboBox()
        Me.LblPrioridad = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbSolicitar, Me.tsbImprimir, Me.tsbAnular, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1059, 27)
        Me.tsMenu.TabIndex = 6
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
        'tsbSolicitar
        '
        Me.tsbSolicitar.Image = Global.BsControl.My.Resources.Resources._782
        Me.tsbSolicitar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSolicitar.Name = "tsbSolicitar"
        Me.tsbSolicitar.Size = New System.Drawing.Size(87, 24)
        Me.tsbSolicitar.Text = "&Solicitar"
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
        'tsbAnular
        '
        Me.tsbAnular.Image = CType(resources.GetObject("tsbAnular.Image"), System.Drawing.Image)
        Me.tsbAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAnular.Name = "tsbAnular"
        Me.tsbAnular.Size = New System.Drawing.Size(76, 24)
        Me.tsbAnular.Text = "&Anular"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(94, 24)
        Me.tsbCancelar.Text = " Cancelar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'lblDisplayAlmacen
        '
        Me.lblDisplayAlmacen.AutoSize = True
        Me.lblDisplayAlmacen.Location = New System.Drawing.Point(13, 78)
        Me.lblDisplayAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayAlmacen.Name = "lblDisplayAlmacen"
        Me.lblDisplayAlmacen.Size = New System.Drawing.Size(70, 17)
        Me.lblDisplayAlmacen.TabIndex = 267
        Me.lblDisplayAlmacen.Text = "Almacén :"
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(13, 142)
        Me.lblDisplayConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(76, 17)
        Me.lblDisplayConcepto.TabIndex = 265
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(101, 142)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtConcepto.MaxLength = 160
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(777, 38)
        Me.txtConcepto.TabIndex = 4
        '
        'dtFechaEntrega
        '
        Me.dtFechaEntrega.Location = New System.Drawing.Point(560, 39)
        Me.dtFechaEntrega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtFechaEntrega.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaEntrega.Name = "dtFechaEntrega"
        Me.dtFechaEntrega.Size = New System.Drawing.Size(280, 22)
        Me.dtFechaEntrega.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(427, 42)
        Me.lblFecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(125, 17)
        Me.lblFecha.TabIndex = 261
        Me.lblFecha.Text = "Fecha a entregar :"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatus.Location = New System.Drawing.Point(515, 75)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(17, 17)
        Me.lblStatus.TabIndex = 260
        Me.lblStatus.Text = "E"
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(427, 75)
        Me.lblDisplayStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(63, 17)
        Me.lblDisplayStatus.TabIndex = 259
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(101, 39)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFolio.MaxLength = 20
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(187, 22)
        Me.txtFolio.TabIndex = 0
        '
        'lblDisplayFolio
        '
        Me.lblDisplayFolio.AutoSize = True
        Me.lblDisplayFolio.Location = New System.Drawing.Point(13, 42)
        Me.lblDisplayFolio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayFolio.Name = "lblDisplayFolio"
        Me.lblDisplayFolio.Size = New System.Drawing.Size(46, 17)
        Me.lblDisplayFolio.TabIndex = 258
        Me.lblDisplayFolio.Text = "Folio :"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro, Me.tsslSolicito, Me.tsslCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 607)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripEstado.Size = New System.Drawing.Size(1059, 29)
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
        'tsslSolicito
        '
        Me.tsslSolicito.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslSolicito.Name = "tsslSolicito"
        Me.tsslSolicito.Size = New System.Drawing.Size(70, 24)
        Me.tsslSolicito.Text = "Solicito :"
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
        'btnDocumentoSiguiente
        '
        Me.btnDocumentoSiguiente.Location = New System.Drawing.Point(339, 37)
        Me.btnDocumentoSiguiente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDocumentoSiguiente.Name = "btnDocumentoSiguiente"
        Me.btnDocumentoSiguiente.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoSiguiente.TabIndex = 382
        Me.btnDocumentoSiguiente.Text = ">"
        Me.btnDocumentoSiguiente.UseVisualStyleBackColor = True
        '
        'btnDocumentoAnterior
        '
        Me.btnDocumentoAnterior.Location = New System.Drawing.Point(297, 37)
        Me.btnDocumentoAnterior.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDocumentoAnterior.Name = "btnDocumentoAnterior"
        Me.btnDocumentoAnterior.Size = New System.Drawing.Size(33, 26)
        Me.btnDocumentoAnterior.TabIndex = 381
        Me.btnDocumentoAnterior.Text = "<"
        Me.btnDocumentoAnterior.UseVisualStyleBackColor = True
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
        Me.Grid1.Location = New System.Drawing.Point(13, 188)
        Me.Grid1.LockButton = True
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Rows = 10
        Me.Grid1.Size = New System.Drawing.Size(1036, 415)
        Me.Grid1.TabIndex = 5
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblNombreEstatus
        '
        Me.lblNombreEstatus.AutoSize = True
        Me.lblNombreEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblNombreEstatus.Location = New System.Drawing.Point(533, 75)
        Me.lblNombreEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreEstatus.Name = "lblNombreEstatus"
        Me.lblNombreEstatus.Size = New System.Drawing.Size(55, 17)
        Me.lblNombreEstatus.TabIndex = 383
        Me.lblNombreEstatus.Text = "Estatus"
        '
        'txtComprador
        '
        Me.txtComprador.Location = New System.Drawing.Point(101, 108)
        Me.txtComprador.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtComprador.MaxLength = 3
        Me.txtComprador.Name = "txtComprador"
        Me.txtComprador.Size = New System.Drawing.Size(75, 22)
        Me.txtComprador.TabIndex = 3
        '
        'lblDisplayComprador
        '
        Me.lblDisplayComprador.AutoSize = True
        Me.lblDisplayComprador.Location = New System.Drawing.Point(13, 112)
        Me.lblDisplayComprador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplayComprador.Name = "lblDisplayComprador"
        Me.lblDisplayComprador.Size = New System.Drawing.Size(86, 17)
        Me.lblDisplayComprador.TabIndex = 385
        Me.lblDisplayComprador.Text = "Comprador :"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Location = New System.Drawing.Point(101, 74)
        Me.txtAlmacen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAlmacen.MaxLength = 4
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.Size = New System.Drawing.Size(75, 22)
        Me.txtAlmacen.TabIndex = 2
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Location = New System.Drawing.Point(185, 78)
        Me.lblAlmacen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(233, 16)
        Me.lblAlmacen.TabIndex = 387
        Me.lblAlmacen.Text = "_"
        '
        'lblComprador
        '
        Me.lblComprador.Location = New System.Drawing.Point(185, 112)
        Me.lblComprador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblComprador.Name = "lblComprador"
        Me.lblComprador.Size = New System.Drawing.Size(233, 16)
        Me.lblComprador.TabIndex = 388
        Me.lblComprador.Text = "_"
        '
        'CboPrioridad
        '
        Me.CboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPrioridad.FormattingEnabled = True
        Me.CboPrioridad.Items.AddRange(New Object() {"TODOS"})
        Me.CboPrioridad.Location = New System.Drawing.Point(518, 104)
        Me.CboPrioridad.Margin = New System.Windows.Forms.Padding(4)
        Me.CboPrioridad.Name = "CboPrioridad"
        Me.CboPrioridad.Size = New System.Drawing.Size(262, 24)
        Me.CboPrioridad.TabIndex = 389
        '
        'LblPrioridad
        '
        Me.LblPrioridad.AutoSize = True
        Me.LblPrioridad.Location = New System.Drawing.Point(427, 107)
        Me.LblPrioridad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPrioridad.Name = "LblPrioridad"
        Me.LblPrioridad.Size = New System.Drawing.Size(73, 17)
        Me.LblPrioridad.TabIndex = 390
        Me.LblPrioridad.Text = "Prioridad :"
        '
        'Inventarios_Requisiciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 636)
        Me.Controls.Add(Me.CboPrioridad)
        Me.Controls.Add(Me.LblPrioridad)
        Me.Controls.Add(Me.lblComprador)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtComprador)
        Me.Controls.Add(Me.lblDisplayComprador)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.lblNombreEstatus)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.btnDocumentoSiguiente)
        Me.Controls.Add(Me.btnDocumentoAnterior)
        Me.Controls.Add(Me.lblDisplayAlmacen)
        Me.Controls.Add(Me.lblDisplayConcepto)
        Me.Controls.Add(Me.dtFechaEntrega)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblDisplayStatus)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.lblDisplayFolio)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Inventarios_Requisiciones"
        Me.ShowIcon = False
        Me.Text = "Requisiciones de inventario."
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
    Friend WithEvents lblDisplayAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents dtFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDisplayStatus As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFolio As System.Windows.Forms.Label
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSolicitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsslElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDocumentoSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnDocumentoAnterior As System.Windows.Forms.Button
    Friend WithEvents Grid1 As FlexCell.Grid
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents tsslSolicito As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNombreEstatus As System.Windows.Forms.Label
    Friend WithEvents txtComprador As TextBox
    Friend WithEvents lblDisplayComprador As Label
    Friend WithEvents txtAlmacen As TextBox
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents lblComprador As Label
    Friend WithEvents CboPrioridad As System.Windows.Forms.ComboBox
    Friend WithEvents LblPrioridad As System.Windows.Forms.Label
End Class
