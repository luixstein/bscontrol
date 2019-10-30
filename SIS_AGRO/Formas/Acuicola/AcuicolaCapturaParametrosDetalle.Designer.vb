<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcuicolaCapturaParametrosDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcuicolaCapturaParametrosDetalle))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnFolioSiguiente = New System.Windows.Forms.Button()
        Me.btnFolioAnterior = New System.Windows.Forms.Button()
        Me.LblDisplayFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.gbGlobal = New System.Windows.Forms.GroupBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.lblDisplayCiclo = New System.Windows.Forms.Label()
        Me.lblDisplayDivision = New System.Windows.Forms.Label()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTurno = New System.Windows.Forms.Label()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.gbParametros = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip()
        Me.tsslEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslElaboro = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDisplayStatus = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsMenu.SuspendLayout()
        Me.gbGlobal.SuspendLayout()
        Me.gbParametros.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbGrabar, Me.tsbImprimir, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(794, 25)
        Me.tsMenu.TabIndex = 2
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'btnFolioSiguiente
        '
        Me.btnFolioSiguiente.Location = New System.Drawing.Point(265, 13)
        Me.btnFolioSiguiente.Name = "btnFolioSiguiente"
        Me.btnFolioSiguiente.Size = New System.Drawing.Size(54, 21)
        Me.btnFolioSiguiente.TabIndex = 2
        Me.btnFolioSiguiente.Text = ">>"
        Me.btnFolioSiguiente.UseVisualStyleBackColor = True
        '
        'btnFolioAnterior
        '
        Me.btnFolioAnterior.Location = New System.Drawing.Point(205, 13)
        Me.btnFolioAnterior.Name = "btnFolioAnterior"
        Me.btnFolioAnterior.Size = New System.Drawing.Size(54, 21)
        Me.btnFolioAnterior.TabIndex = 1
        Me.btnFolioAnterior.Text = "<<"
        Me.btnFolioAnterior.UseVisualStyleBackColor = True
        '
        'LblDisplayFolio
        '
        Me.LblDisplayFolio.AutoSize = True
        Me.LblDisplayFolio.Location = New System.Drawing.Point(6, 16)
        Me.LblDisplayFolio.Name = "LblDisplayFolio"
        Me.LblDisplayFolio.Size = New System.Drawing.Size(35, 13)
        Me.LblDisplayFolio.TabIndex = 378
        Me.LblDisplayFolio.Text = "Folio :"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(88, 13)
        Me.txtFolio.MaxLength = 15
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(111, 20)
        Me.txtFolio.TabIndex = 0
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(6, 42)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(75, 13)
        Me.LblFecha.TabIndex = 379
        Me.LblFecha.Text = "Fecha y hora :"
        '
        'dtFecha
        '
        Me.dtFecha.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtFecha.CustomFormat = "dd-MMM-yyyy hh:mm tt"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(88, 39)
        Me.dtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(148, 20)
        Me.dtFecha.TabIndex = 3
        '
        'gbGlobal
        '
        Me.gbGlobal.Controls.Add(Me.txtConcepto)
        Me.gbGlobal.Controls.Add(Me.Label1)
        Me.gbGlobal.Controls.Add(Me.lblDisplayStatus)
        Me.gbGlobal.Controls.Add(Me.lblEstatus)
        Me.gbGlobal.Controls.Add(Me.txtCiclo)
        Me.gbGlobal.Controls.Add(Me.lblDisplayCiclo)
        Me.gbGlobal.Controls.Add(Me.lblDisplayDivision)
        Me.gbGlobal.Controls.Add(Me.cboDivision)
        Me.gbGlobal.Controls.Add(Me.lblDisplayTurno)
        Me.gbGlobal.Controls.Add(Me.cboTurno)
        Me.gbGlobal.Controls.Add(Me.btnFolioSiguiente)
        Me.gbGlobal.Controls.Add(Me.dtFecha)
        Me.gbGlobal.Controls.Add(Me.btnFolioAnterior)
        Me.gbGlobal.Controls.Add(Me.LblFecha)
        Me.gbGlobal.Controls.Add(Me.txtFolio)
        Me.gbGlobal.Controls.Add(Me.LblDisplayFolio)
        Me.gbGlobal.Location = New System.Drawing.Point(0, 28)
        Me.gbGlobal.Name = "gbGlobal"
        Me.gbGlobal.Size = New System.Drawing.Size(791, 147)
        Me.gbGlobal.TabIndex = 0
        Me.gbGlobal.TabStop = False
        '
        'txtCiclo
        '
        Me.txtCiclo.Location = New System.Drawing.Point(88, 119)
        Me.txtCiclo.MaxLength = 15
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(55, 20)
        Me.txtCiclo.TabIndex = 6
        '
        'lblDisplayCiclo
        '
        Me.lblDisplayCiclo.AutoSize = True
        Me.lblDisplayCiclo.Location = New System.Drawing.Point(6, 122)
        Me.lblDisplayCiclo.Name = "lblDisplayCiclo"
        Me.lblDisplayCiclo.Size = New System.Drawing.Size(36, 13)
        Me.lblDisplayCiclo.TabIndex = 387
        Me.lblDisplayCiclo.Text = "Ciclo :"
        '
        'lblDisplayDivision
        '
        Me.lblDisplayDivision.AutoSize = True
        Me.lblDisplayDivision.Location = New System.Drawing.Point(6, 95)
        Me.lblDisplayDivision.Name = "lblDisplayDivision"
        Me.lblDisplayDivision.Size = New System.Drawing.Size(50, 13)
        Me.lblDisplayDivision.TabIndex = 385
        Me.lblDisplayDivision.Text = "División :"
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(88, 92)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(171, 21)
        Me.cboDivision.TabIndex = 5
        '
        'lblDisplayTurno
        '
        Me.lblDisplayTurno.AutoSize = True
        Me.lblDisplayTurno.Location = New System.Drawing.Point(6, 68)
        Me.lblDisplayTurno.Name = "lblDisplayTurno"
        Me.lblDisplayTurno.Size = New System.Drawing.Size(41, 13)
        Me.lblDisplayTurno.TabIndex = 383
        Me.lblDisplayTurno.Text = "Turno :"
        '
        'cboTurno
        '
        Me.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Location = New System.Drawing.Point(88, 65)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(111, 21)
        Me.cboTurno.TabIndex = 4
        '
        'gbParametros
        '
        Me.gbParametros.Controls.Add(Me.Grid)
        Me.gbParametros.Location = New System.Drawing.Point(0, 181)
        Me.gbParametros.Name = "gbParametros"
        Me.gbParametros.Size = New System.Drawing.Size(791, 343)
        Me.gbParametros.TabIndex = 1
        Me.gbParametros.TabStop = False
        Me.gbParametros.Text = "Parámetros :"
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(6, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 6
        Me.Grid.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.Grid.Size = New System.Drawing.Size(779, 317)
        Me.Grid.TabIndex = 1
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEstado, Me.tsslElaboro})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 532)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(794, 24)
        Me.StatusStripEstado.TabIndex = 325
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
        Me.tsslElaboro.Text = "Elaboró :"
        '
        'lblDisplayStatus
        '
        Me.lblDisplayStatus.AutoSize = True
        Me.lblDisplayStatus.Location = New System.Drawing.Point(372, 17)
        Me.lblDisplayStatus.Name = "lblDisplayStatus"
        Me.lblDisplayStatus.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayStatus.TabIndex = 388
        Me.lblDisplayStatus.Text = "Estatus :"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEstatus.Location = New System.Drawing.Point(426, 17)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(10, 13)
        Me.lblEstatus.TabIndex = 389
        Me.lblEstatus.Text = "."
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(205, 119)
        Me.txtConcepto.MaxLength = 100
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(580, 20)
        Me.txtConcepto.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(149, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 391
        Me.Label1.Text = "Concepto :"
        '
        'AcuicolaCapturaParametrosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 556)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.gbParametros)
        Me.Controls.Add(Me.gbGlobal)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "AcuicolaCapturaParametrosDetalle"
        Me.Text = "Acuicola captura de parametros"
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbGlobal.ResumeLayout(False)
        Me.gbGlobal.PerformLayout()
        Me.gbParametros.ResumeLayout(False)
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsbNuevo As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents tsbImprimir As ToolStripButton
    Friend WithEvents btnFolioSiguiente As Button
    Friend WithEvents btnFolioAnterior As Button
    Friend WithEvents LblDisplayFolio As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents LblFecha As Label
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents gbGlobal As GroupBox
    Friend WithEvents txtCiclo As TextBox
    Friend WithEvents lblDisplayCiclo As Label
    Friend WithEvents lblDisplayDivision As Label
    Friend WithEvents cboDivision As ComboBox
    Friend WithEvents lblDisplayTurno As Label
    Friend WithEvents cboTurno As ComboBox
    Friend WithEvents gbParametros As GroupBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents tsbGrabar As ToolStripButton
    Friend WithEvents StatusStripEstado As StatusStrip
    Friend WithEvents tsslEstado As ToolStripStatusLabel
    Friend WithEvents tsslElaboro As ToolStripStatusLabel
    Friend WithEvents lblDisplayStatus As Label
    Friend WithEvents lblEstatus As Label
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents Label1 As Label
End Class
