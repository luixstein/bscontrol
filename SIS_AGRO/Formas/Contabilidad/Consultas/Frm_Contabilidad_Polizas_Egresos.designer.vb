<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Polizas_Egresos
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Polizas_Egresos))
        Me.Grid = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtComentario = New System.Windows.Forms.TextBox
        Me.LblCuenta = New System.Windows.Forms.Label
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.LblDisplayNombreSocio = New System.Windows.Forms.Label
        Me.TxtCuenta1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCuenta2 = New System.Windows.Forms.TextBox
        Me.LblCuenta2 = New System.Windows.Forms.Label
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = System.Windows.Forms.AnchorStyles.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle5
        Me.Grid.Location = New System.Drawing.Point(14, 156)
        Me.Grid.Name = "Grid"
        Me.Grid.RightToLeft = System.Windows.Forms.RightToLeft.No
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Grid.RowHeadersVisible = False
        Me.Grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid.Size = New System.Drawing.Size(799, 323)
        Me.Grid.StandardTab = True
        Me.Grid.TabIndex = 227
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "Cocepto :"
        '
        'TxtComentario
        '
        Me.TxtComentario.Location = New System.Drawing.Point(88, 119)
        Me.TxtComentario.MaxLength = 160
        Me.TxtComentario.Name = "TxtComentario"
        Me.TxtComentario.Size = New System.Drawing.Size(570, 20)
        Me.TxtComentario.TabIndex = 225
        '
        'LblCuenta
        '
        Me.LblCuenta.AutoSize = True
        Me.LblCuenta.Location = New System.Drawing.Point(227, 74)
        Me.LblCuenta.Name = "LblCuenta"
        Me.LblCuenta.Size = New System.Drawing.Size(10, 13)
        Me.LblCuenta.TabIndex = 224
        Me.LblCuenta.Text = "."
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(11, 100)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 223
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'LblDisplayNombreSocio
        '
        Me.LblDisplayNombreSocio.AutoSize = True
        Me.LblDisplayNombreSocio.Location = New System.Drawing.Point(11, 70)
        Me.LblDisplayNombreSocio.Name = "LblDisplayNombreSocio"
        Me.LblDisplayNombreSocio.Size = New System.Drawing.Size(74, 13)
        Me.LblDisplayNombreSocio.TabIndex = 222
        Me.LblDisplayNombreSocio.Text = "De la cuenta :"
        '
        'TxtCuenta1
        '
        Me.TxtCuenta1.Location = New System.Drawing.Point(88, 67)
        Me.TxtCuenta1.MaxLength = 15
        Me.TxtCuenta1.Name = "TxtCuenta1"
        Me.TxtCuenta1.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta1.TabIndex = 218
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(192, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "Hasta la fecha :"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaHasta.Location = New System.Drawing.Point(283, 31)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(85, 20)
        Me.DtFechaHasta.TabIndex = 217
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(11, 35)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 220
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaDesde.Location = New System.Drawing.Point(88, 31)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(87, 20)
        Me.DtFechaDesde.TabIndex = 216
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(825, 25)
        Me.ToolStrip1.TabIndex = 215
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(370, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "A la cuenta :"
        '
        'TxtCuenta2
        '
        Me.TxtCuenta2.Location = New System.Drawing.Point(444, 67)
        Me.TxtCuenta2.MaxLength = 15
        Me.TxtCuenta2.Name = "TxtCuenta2"
        Me.TxtCuenta2.Size = New System.Drawing.Size(133, 20)
        Me.TxtCuenta2.TabIndex = 228
        '
        'LblCuenta2
        '
        Me.LblCuenta2.AutoSize = True
        Me.LblCuenta2.Location = New System.Drawing.Point(583, 74)
        Me.LblCuenta2.Name = "LblCuenta2"
        Me.LblCuenta2.Size = New System.Drawing.Size(10, 13)
        Me.LblCuenta2.TabIndex = 230
        Me.LblCuenta2.Text = "."
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Items.AddRange(New Object() {"A", "G", "T"})
        Me.CmbEjercicio.Location = New System.Drawing.Point(88, 93)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(133, 21)
        Me.CmbEjercicio.TabIndex = 231
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'Frm_Contabilidad_Polizas_Egresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 491)
        Me.Controls.Add(Me.CmbEjercicio)
        Me.Controls.Add(Me.LblCuenta2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCuenta2)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtComentario)
        Me.Controls.Add(Me.LblCuenta)
        Me.Controls.Add(Me.LblEjercicio)
        Me.Controls.Add(Me.LblDisplayNombreSocio)
        Me.Controls.Add(Me.TxtCuenta1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtFechaHasta)
        Me.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.Controls.Add(Me.DtFechaDesde)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Frm_Contabilidad_Polizas_Egresos"
        Me.Text = "Polizas de egresos"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtComentario As System.Windows.Forms.TextBox
    Friend WithEvents LblCuenta As System.Windows.Forms.Label
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreSocio As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents LblCuenta2 As System.Windows.Forms.Label
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
End Class
