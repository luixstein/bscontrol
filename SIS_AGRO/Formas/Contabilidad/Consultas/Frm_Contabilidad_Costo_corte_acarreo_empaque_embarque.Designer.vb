<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblEjercicio = New System.Windows.Forms.Label
        Me.lblTipoCambio = New System.Windows.Forms.Label
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.lblFechaHasta = New System.Windows.Forms.Label
        Me.DtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.lblFechaDesde = New System.Windows.Forms.Label
        Me.DtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RdbTotalEmpresa = New System.Windows.Forms.RadioButton
        Me.RdbTarriba = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEjercicio)
        Me.GroupBox1.Controls.Add(Me.lblTipoCambio)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaHasta)
        Me.GroupBox1.Controls.Add(Me.DtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.lblFechaDesde)
        Me.GroupBox1.Controls.Add(Me.DtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 133)
        Me.GroupBox1.TabIndex = 252
        Me.GroupBox1.TabStop = False
        '
        'lblEjercicio
        '
        Me.lblEjercicio.AutoSize = True
        Me.lblEjercicio.Location = New System.Drawing.Point(20, 16)
        Me.lblEjercicio.Name = "lblEjercicio"
        Me.lblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.lblEjercicio.TabIndex = 8
        Me.lblEjercicio.Text = "Ejercicio :"
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Location = New System.Drawing.Point(20, 95)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(71, 13)
        Me.lblTipoCambio.TabIndex = 11
        Me.lblTipoCambio.Text = "Tipo cambio :"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(109, 13)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(133, 21)
        Me.CmbEjercicio.TabIndex = 0
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.Location = New System.Drawing.Point(20, 70)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaHasta.TabIndex = 10
        Me.lblFechaHasta.Text = "Hasta"
        '
        'DtFechaDesde
        '
        Me.DtFechaDesde.Location = New System.Drawing.Point(109, 40)
        Me.DtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaDesde.Name = "DtFechaDesde"
        Me.DtFechaDesde.Size = New System.Drawing.Size(222, 20)
        Me.DtFechaDesde.TabIndex = 1
        Me.DtFechaDesde.Value = New Date(2011, 1, 1, 0, 0, 0, 0)
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.Location = New System.Drawing.Point(20, 44)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(44, 13)
        Me.lblFechaDesde.TabIndex = 9
        Me.lblFechaDesde.Text = "Desde :"
        '
        'DtFechaHasta
        '
        Me.DtFechaHasta.Location = New System.Drawing.Point(109, 66)
        Me.DtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtFechaHasta.Name = "DtFechaHasta"
        Me.DtFechaHasta.Size = New System.Drawing.Size(222, 20)
        Me.DtFechaHasta.TabIndex = 2
        Me.DtFechaHasta.Value = New Date(2011, 12, 31, 0, 0, 0, 0)
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(109, 92)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(133, 20)
        Me.txtTipoCambio.TabIndex = 3
        Me.txtTipoCambio.Text = "12"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(354, 25)
        Me.ToolStrip1.TabIndex = 251
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RdbTotalEmpresa)
        Me.GroupBox2.Controls.Add(Me.RdbTarriba)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(351, 46)
        Me.GroupBox2.TabIndex = 253
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de reporte :"
        '
        'RdbTotalEmpresa
        '
        Me.RdbTotalEmpresa.AutoSize = True
        Me.RdbTotalEmpresa.Checked = True
        Me.RdbTotalEmpresa.Location = New System.Drawing.Point(27, 20)
        Me.RdbTotalEmpresa.Name = "RdbTotalEmpresa"
        Me.RdbTotalEmpresa.Size = New System.Drawing.Size(92, 17)
        Me.RdbTotalEmpresa.TabIndex = 0
        Me.RdbTotalEmpresa.TabStop = True
        Me.RdbTotalEmpresa.Text = "Total empresa"
        Me.RdbTotalEmpresa.UseVisualStyleBackColor = True
        '
        'RdbTarriba
        '
        Me.RdbTarriba.AutoSize = True
        Me.RdbTarriba.Location = New System.Drawing.Point(177, 19)
        Me.RdbTarriba.Name = "RdbTarriba"
        Me.RdbTarriba.Size = New System.Drawing.Size(84, 17)
        Me.RdbTarriba.TabIndex = 1
        Me.RdbTarriba.Text = "Socio tarriba"
        Me.RdbTarriba.UseVisualStyleBackColor = True
        '
        'Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 221)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_Costo_corte_acarreo_empaque_embarque"
        Me.Text = "Costo corte acarreo empaque embarque"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEjercicio As System.Windows.Forms.Label
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents DtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents DtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbTotalEmpresa As System.Windows.Forms.RadioButton
    Friend WithEvents RdbTarriba As System.Windows.Forms.RadioButton
End Class
