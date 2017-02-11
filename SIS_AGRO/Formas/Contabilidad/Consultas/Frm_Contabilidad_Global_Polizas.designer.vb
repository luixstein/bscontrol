<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Global_Polizas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Global_Polizas))
        Me.Grid = New System.Windows.Forms.DataGridView
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbImprimirListado = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gbTipoReporte = New System.Windows.Forms.GroupBox
        Me.rbtnReporteGlobal = New System.Windows.Forms.RadioButton
        Me.rbtnReporteDetalle = New System.Windows.Forms.RadioButton
        Me.CboEjercicio = New System.Windows.Forms.ComboBox
        Me.ChCuentasSaldo = New System.Windows.Forms.CheckBox
        Me.CboDocumento = New System.Windows.Forms.ComboBox
        Me.LblDisplayTipo = New System.Windows.Forms.Label
        Me.LblEstatus = New System.Windows.Forms.Label
        Me.CboEstatus = New System.Windows.Forms.ComboBox
        Me.LblEjercicio = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.cboPlaza = New System.Windows.Forms.ComboBox
        Me.lblDisplayPlaza = New System.Windows.Forms.Label
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbTipoReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = System.Windows.Forms.AnchorStyles.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grid.Location = New System.Drawing.Point(11, 135)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RightToLeft = System.Windows.Forms.RightToLeft.No
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Grid.RowHeadersVisible = False
        Me.Grid.Size = New System.Drawing.Size(800, 409)
        Me.Grid.StandardTab = True
        Me.Grid.TabIndex = 9
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(78, 22)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbImprimirListado, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(825, 25)
        Me.ToolStrip1.TabIndex = 215
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbImprimirListado
        '
        Me.tsbImprimirListado.Image = CType(resources.GetObject("tsbImprimirListado.Image"), System.Drawing.Image)
        Me.tsbImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirListado.Name = "tsbImprimirListado"
        Me.tsbImprimirListado.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimirListado.Text = "&Imprimir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPlaza)
        Me.GroupBox1.Controls.Add(Me.lblDisplayPlaza)
        Me.GroupBox1.Controls.Add(Me.gbTipoReporte)
        Me.GroupBox1.Controls.Add(Me.CboEjercicio)
        Me.GroupBox1.Controls.Add(Me.ChCuentasSaldo)
        Me.GroupBox1.Controls.Add(Me.CboDocumento)
        Me.GroupBox1.Controls.Add(Me.LblDisplayTipo)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.CboEstatus)
        Me.GroupBox1.Controls.Add(Me.LblEjercicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 92)
        Me.GroupBox1.TabIndex = 234
        Me.GroupBox1.TabStop = False
        '
        'gbTipoReporte
        '
        Me.gbTipoReporte.Controls.Add(Me.rbtnReporteGlobal)
        Me.gbTipoReporte.Controls.Add(Me.rbtnReporteDetalle)
        Me.gbTipoReporte.Location = New System.Drawing.Point(568, 16)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(103, 70)
        Me.gbTipoReporte.TabIndex = 245
        Me.gbTipoReporte.TabStop = False
        Me.gbTipoReporte.Text = "Tipo de reporte "
        '
        'rbtnReporteGlobal
        '
        Me.rbtnReporteGlobal.AutoSize = True
        Me.rbtnReporteGlobal.Location = New System.Drawing.Point(6, 19)
        Me.rbtnReporteGlobal.Name = "rbtnReporteGlobal"
        Me.rbtnReporteGlobal.Size = New System.Drawing.Size(55, 17)
        Me.rbtnReporteGlobal.TabIndex = 235
        Me.rbtnReporteGlobal.TabStop = True
        Me.rbtnReporteGlobal.Text = "Global"
        Me.rbtnReporteGlobal.UseVisualStyleBackColor = True
        '
        'rbtnReporteDetalle
        '
        Me.rbtnReporteDetalle.AutoSize = True
        Me.rbtnReporteDetalle.Location = New System.Drawing.Point(6, 42)
        Me.rbtnReporteDetalle.Name = "rbtnReporteDetalle"
        Me.rbtnReporteDetalle.Size = New System.Drawing.Size(58, 17)
        Me.rbtnReporteDetalle.TabIndex = 234
        Me.rbtnReporteDetalle.TabStop = True
        Me.rbtnReporteDetalle.Text = "Detalle"
        Me.rbtnReporteDetalle.UseVisualStyleBackColor = True
        '
        'CboEjercicio
        '
        Me.CboEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEjercicio.FormattingEnabled = True
        Me.CboEjercicio.Items.AddRange(New Object() {"A", "G", "T"})
        Me.CboEjercicio.Location = New System.Drawing.Point(96, 13)
        Me.CboEjercicio.MaxLength = 1
        Me.CboEjercicio.Name = "CboEjercicio"
        Me.CboEjercicio.Size = New System.Drawing.Size(135, 21)
        Me.CboEjercicio.TabIndex = 244
        '
        'ChCuentasSaldo
        '
        Me.ChCuentasSaldo.AutoSize = True
        Me.ChCuentasSaldo.Location = New System.Drawing.Point(365, 69)
        Me.ChCuentasSaldo.Name = "ChCuentasSaldo"
        Me.ChCuentasSaldo.Size = New System.Drawing.Size(165, 17)
        Me.ChCuentasSaldo.TabIndex = 238
        Me.ChCuentasSaldo.Text = "Filtrar cuentas con saldo <> 0"
        Me.ChCuentasSaldo.UseVisualStyleBackColor = True
        '
        'CboDocumento
        '
        Me.CboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDocumento.FormattingEnabled = True
        Me.CboDocumento.Location = New System.Drawing.Point(416, 13)
        Me.CboDocumento.Name = "CboDocumento"
        Me.CboDocumento.Size = New System.Drawing.Size(135, 21)
        Me.CboDocumento.TabIndex = 237
        '
        'LblDisplayTipo
        '
        Me.LblDisplayTipo.AutoSize = True
        Me.LblDisplayTipo.Location = New System.Drawing.Point(365, 16)
        Me.LblDisplayTipo.Name = "LblDisplayTipo"
        Me.LblDisplayTipo.Size = New System.Drawing.Size(34, 13)
        Me.LblDisplayTipo.TabIndex = 243
        Me.LblDisplayTipo.Text = "Tipo :"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(686, 16)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(48, 13)
        Me.LblEstatus.TabIndex = 242
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"A", "G", "T"})
        Me.CboEstatus.Location = New System.Drawing.Point(737, 13)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(57, 21)
        Me.CboEstatus.TabIndex = 236
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(6, 16)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 241
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 240
        Me.Label1.Text = "Hasta la fecha :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(96, 66)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(222, 20)
        Me.DtFechaHasta.TabIndex = 235
        Me.DtFechaHasta.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(6, 44)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 239
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(96, 40)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(223, 20)
        Me.DtFechaDesde.TabIndex = 234
        Me.DtFechaDesde.Value = New Date(2009, 9, 26, 0, 0, 0, 0)
        '
        'cboPlaza
        '
        Me.cboPlaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlaza.FormattingEnabled = True
        Me.cboPlaza.Location = New System.Drawing.Point(416, 40)
        Me.cboPlaza.Name = "cboPlaza"
        Me.cboPlaza.Size = New System.Drawing.Size(135, 21)
        Me.cboPlaza.TabIndex = 246
        '
        'lblDisplayPlaza
        '
        Me.lblDisplayPlaza.AutoSize = True
        Me.lblDisplayPlaza.Location = New System.Drawing.Point(365, 44)
        Me.lblDisplayPlaza.Name = "lblDisplayPlaza"
        Me.lblDisplayPlaza.Size = New System.Drawing.Size(39, 13)
        Me.lblDisplayPlaza.TabIndex = 247
        Me.lblDisplayPlaza.Text = "Plaza :"
        '
        'Frm_Contabilidad_Global_Polizas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 552)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_Global_Polizas"
        Me.Text = "Reporte global de pólizas"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbTipoReporte.ResumeLayout(False)
        Me.gbTipoReporte.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbTipoReporte As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnReporteGlobal As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnReporteDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents CboEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents ChCuentasSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents CboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayTipo As System.Windows.Forms.Label
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents tsbImprimirListado As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboPlaza As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayPlaza As System.Windows.Forms.Label
End Class
