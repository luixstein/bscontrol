<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Contabilidad_Saldos_CUENTA_CONTABLE_PESOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Contabilidad_Saldos_CUENTA_CONTABLE_PESOS))
        Me.LblCuenta = New System.Windows.Forms.Label
        Me.LblDisplayNombreSocio = New System.Windows.Forms.Label
        Me.TxtCuenta1 = New System.Windows.Forms.TextBox
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.LblDisplayFechaNacimiento = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblCuenta
        '
        Me.LblCuenta.AutoSize = True
        Me.LblCuenta.Location = New System.Drawing.Point(85, 54)
        Me.LblCuenta.Name = "LblCuenta"
        Me.LblCuenta.Size = New System.Drawing.Size(10, 13)
        Me.LblCuenta.TabIndex = 224
        Me.LblCuenta.Text = "."
        '
        'LblDisplayNombreSocio
        '
        Me.LblDisplayNombreSocio.AutoSize = True
        Me.LblDisplayNombreSocio.Location = New System.Drawing.Point(8, 29)
        Me.LblDisplayNombreSocio.Name = "LblDisplayNombreSocio"
        Me.LblDisplayNombreSocio.Size = New System.Drawing.Size(74, 13)
        Me.LblDisplayNombreSocio.TabIndex = 222
        Me.LblDisplayNombreSocio.Text = "De la cuenta :"
        '
        'TxtCuenta1
        '
        Me.TxtCuenta1.Location = New System.Drawing.Point(88, 26)
        Me.TxtCuenta1.MaxLength = 15
        Me.TxtCuenta1.Name = "TxtCuenta1"
        Me.TxtCuenta1.Size = New System.Drawing.Size(200, 20)
        Me.TxtCuenta1.TabIndex = 0
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(437, 25)
        Me.ToolStrip1.TabIndex = 215
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(88, 70)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(200, 21)
        Me.CmbEjercicio.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox1.Controls.Add(Me.dtFechaDesde)
        Me.GroupBox1.Controls.Add(Me.LblDisplayFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtFechaHasta)
        Me.GroupBox1.Controls.Add(Me.LblCuenta)
        Me.GroupBox1.Controls.Add(Me.LblDisplayNombreSocio)
        Me.GroupBox1.Controls.Add(Me.TxtCuenta1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 162)
        Me.GroupBox1.TabIndex = 231
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 246
        Me.Label1.Text = "Ejercicio :"
        '
        'dtFechaDesde
        '
        Me.dtFechaDesde.Location = New System.Drawing.Point(88, 98)
        Me.dtFechaDesde.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaDesde.Name = "dtFechaDesde"
        Me.dtFechaDesde.Size = New System.Drawing.Size(200, 20)
        Me.dtFechaDesde.TabIndex = 3
        '
        'LblDisplayFechaNacimiento
        '
        Me.LblDisplayFechaNacimiento.AutoSize = True
        Me.LblDisplayFechaNacimiento.Location = New System.Drawing.Point(8, 102)
        Me.LblDisplayFechaNacimiento.Name = "LblDisplayFechaNacimiento"
        Me.LblDisplayFechaNacimiento.Size = New System.Drawing.Size(68, 13)
        Me.LblDisplayFechaNacimiento.TabIndex = 247
        Me.LblDisplayFechaNacimiento.Text = "De la fecha :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 248
        Me.Label3.Text = "Hasta la fecha :"
        '
        'dtFechaHasta
        '
        Me.dtFechaHasta.Location = New System.Drawing.Point(88, 125)
        Me.dtFechaHasta.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaHasta.Name = "dtFechaHasta"
        Me.dtFechaHasta.Size = New System.Drawing.Size(200, 20)
        Me.dtFechaHasta.TabIndex = 4
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(73, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'Frm_Contabilidad_Saldos_CUENTA_CONTABLE_PESOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 197)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_Contabilidad_Saldos_CUENTA_CONTABLE_PESOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldos de cuentas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblCuenta As System.Windows.Forms.Label
    Friend WithEvents LblDisplayNombreSocio As System.Windows.Forms.Label
    Friend WithEvents TxtCuenta1 As System.Windows.Forms.TextBox
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisplayFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
End Class
