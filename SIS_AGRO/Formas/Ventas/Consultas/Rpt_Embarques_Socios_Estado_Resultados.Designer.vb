<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Embarques_Socios_Estado_Resultados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Embarques_Socios_Estado_Resultados))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.TxtCodArticulo = New System.Windows.Forms.TextBox()
        Me.LblDisplaySocio = New System.Windows.Forms.Label()
        Me.TxtCodigoSocio = New System.Windows.Forms.TextBox()
        Me.LblNombreSocio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label()
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.GpoFormatos = New System.Windows.Forms.GroupBox()
        Me.rbtAnalisisEmbarque = New System.Windows.Forms.RadioButton()
        Me.rbtAnalisisSocio = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GpoFormatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(760, 27)
        Me.ToolStrip1.TabIndex = 1
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
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.LblNombreSocio)
        Me.GroupBox1.Controls.Add(Me.LblDisplaySocio)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoSocio)
        Me.GroupBox1.Controls.Add(Me.lblArticulo)
        Me.GroupBox1.Controls.Add(Me.LblDisplayCodArticulo)
        Me.GroupBox1.Controls.Add(Me.TxtCodArticulo)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 92)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(735, 148)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(256, 34)
        Me.lblArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(478, 17)
        Me.lblArticulo.TabIndex = 276
        Me.lblArticulo.Text = "_"
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(11, 34)
        Me.LblDisplayCodArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayCodArticulo.TabIndex = 275
        Me.LblDisplayCodArticulo.Text = "Artículo :"
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Location = New System.Drawing.Point(112, 31)
        Me.TxtCodArticulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(135, 22)
        Me.TxtCodArticulo.TabIndex = 1
        '
        'LblDisplaySocio
        '
        Me.LblDisplaySocio.AutoSize = True
        Me.LblDisplaySocio.Location = New System.Drawing.Point(11, 68)
        Me.LblDisplaySocio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplaySocio.Name = "LblDisplaySocio"
        Me.LblDisplaySocio.Size = New System.Drawing.Size(51, 17)
        Me.LblDisplaySocio.TabIndex = 278
        Me.LblDisplaySocio.Text = "Socio :"
        '
        'TxtCodigoSocio
        '
        Me.TxtCodigoSocio.Location = New System.Drawing.Point(112, 65)
        Me.TxtCodigoSocio.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoSocio.MaxLength = 16
        Me.TxtCodigoSocio.Name = "TxtCodigoSocio"
        Me.TxtCodigoSocio.Size = New System.Drawing.Size(135, 22)
        Me.TxtCodigoSocio.TabIndex = 2
        '
        'LblNombreSocio
        '
        Me.LblNombreSocio.Location = New System.Drawing.Point(256, 68)
        Me.LblNombreSocio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreSocio.Name = "LblNombreSocio"
        Me.LblNombreSocio.Size = New System.Drawing.Size(479, 19)
        Me.LblNombreSocio.TabIndex = 279
        Me.LblNombreSocio.Text = "_"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(256, 111)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 383
        Me.Label1.Text = "Hasta la Fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(375, 106)
        Me.DtFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaHasta.TabIndex = 4
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(10, 111)
        Me.LblDisplayFechaNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(92, 17)
        Me.LblDisplayFechaNacimiento.TabIndex = 382
        Me.LblDisplayFechaNacimiento.Text = "De la Fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(112, 106)
        Me.DtFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(116, 22)
        Me.DtFechaDesde.TabIndex = 3
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'GpoFormatos
        '
        Me.GpoFormatos.Controls.Add(Me.rbtAnalisisSocio)
        Me.GpoFormatos.Controls.Add(Me.rbtAnalisisEmbarque)
        Me.GpoFormatos.Location = New System.Drawing.Point(13, 30)
        Me.GpoFormatos.Name = "GpoFormatos"
        Me.GpoFormatos.Size = New System.Drawing.Size(735, 55)
        Me.GpoFormatos.TabIndex = 3
        Me.GpoFormatos.TabStop = False
        Me.GpoFormatos.Text = "Formato"
        '
        'rbtAnalisisEmbarque
        '
        Me.rbtAnalisisEmbarque.AutoSize = True
        Me.rbtAnalisisEmbarque.Checked = True
        Me.rbtAnalisisEmbarque.Location = New System.Drawing.Point(78, 21)
        Me.rbtAnalisisEmbarque.Name = "rbtAnalisisEmbarque"
        Me.rbtAnalisisEmbarque.Size = New System.Drawing.Size(170, 21)
        Me.rbtAnalisisEmbarque.TabIndex = 0
        Me.rbtAnalisisEmbarque.TabStop = True
        Me.rbtAnalisisEmbarque.Text = "Analisis por embarque"
        Me.rbtAnalisisEmbarque.UseVisualStyleBackColor = True
        '
        'rbtAnalisisSocio
        '
        Me.rbtAnalisisSocio.AutoSize = True
        Me.rbtAnalisisSocio.Location = New System.Drawing.Point(414, 21)
        Me.rbtAnalisisSocio.Name = "rbtAnalisisSocio"
        Me.rbtAnalisisSocio.Size = New System.Drawing.Size(139, 21)
        Me.rbtAnalisisSocio.TabIndex = 1
        Me.rbtAnalisisSocio.Text = "Analisis por socio"
        Me.rbtAnalisisSocio.UseVisualStyleBackColor = True
        '
        'Rpt_Embarques_Socios_Estado_Resultados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 252)
        Me.Controls.Add(Me.GpoFormatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Embarques_Socios_Estado_Resultados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Embarques socios estado de resultados"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GpoFormatos.ResumeLayout(False)
        Me.GpoFormatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbConsultar As ToolStripButton
    Friend WithEvents tsbSalir As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblArticulo As Label
    Friend WithEvents LblDisplayCodArticulo As Label
    Friend WithEvents TxtCodArticulo As TextBox
    Friend WithEvents LblNombreSocio As System.Windows.Forms.Label
    Friend WithEvents LblDisplaySocio As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoSocio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents GpoFormatos As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAnalisisSocio As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnalisisEmbarque As System.Windows.Forms.RadioButton
End Class
