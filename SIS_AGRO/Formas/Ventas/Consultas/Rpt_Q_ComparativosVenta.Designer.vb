<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Q_ComparativosVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Q_ComparativosVenta))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblDisplayCultivo = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.lblDisplayZona = New System.Windows.Forms.Label()
        Me.CboZona = New System.Windows.Forms.ComboBox()
        Me.gbFiltros = New System.Windows.Forms.GroupBox()
        Me.cboMercado = New System.Windows.Forms.ComboBox()
        Me.LblDisplayMercado = New System.Windows.Forms.Label()
        Me.cboPrecentacion = New System.Windows.Forms.ComboBox()
        Me.lblDisplayPresentacion = New System.Windows.Forms.Label()
        Me.cboMostrar = New System.Windows.Forms.ComboBox()
        Me.lblDisplayMostrar = New System.Windows.Forms.Label()
        Me.cboTemporada = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTemporada = New System.Windows.Forms.Label()
        Me.ToolStrip2.SuspendLayout()
        Me.gbFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir, Me.tsbSalir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(427, 25)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
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
        'lblDisplayCultivo
        '
        Me.lblDisplayCultivo.AutoSize = True
        Me.lblDisplayCultivo.Location = New System.Drawing.Point(8, 50)
        Me.lblDisplayCultivo.Name = "lblDisplayCultivo"
        Me.lblDisplayCultivo.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCultivo.TabIndex = 278
        Me.lblDisplayCultivo.Text = "Cultivo :"
        '
        'cboCultivo
        '
        Me.cboCultivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Items.AddRange(New Object() {"CARNES", "GRANOS Y", "ABARROTE", "CREMAS", "HIELOS", "JACOBSEN", "REGULADO", "RODILLO", "REFACCIO", "TRACTOR", "VINO BLA", "CONDIMEN", "ANIS", "BRANDY", "APERITIV", "RONES", "HERVICID", "COGÑAC", "VODKA", "GINEBRA", "HARINAS,", "TEQUILA", "VINO TIN", "VARIOS", "POLLO", "REFRESCO", "FRUTAS Y", "GRENN KI", "SALSAS Y", "GREENERA", "LATAS", "WHISKYS", "SALDOS", "PRODUCTO", "CREMERIA", "FUNGICID", "JUGO LAC", "PESCADO", "LICOR", "ACCESORI", "VAERATOR", "INSECTIC", "FERTILIZ"})
        Me.cboCultivo.Location = New System.Drawing.Point(86, 46)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(270, 21)
        Me.cboCultivo.TabIndex = 1
        '
        'lblDisplayCliente
        '
        Me.lblDisplayCliente.AutoSize = True
        Me.lblDisplayCliente.Location = New System.Drawing.Point(8, 164)
        Me.lblDisplayCliente.Name = "lblDisplayCliente"
        Me.lblDisplayCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblDisplayCliente.TabIndex = 358
        Me.lblDisplayCliente.Text = "Cliente :"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(86, 160)
        Me.TxtCliente.MaxLength = 8
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(88, 20)
        Me.TxtCliente.TabIndex = 5
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Location = New System.Drawing.Point(86, 186)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(309, 14)
        Me.lblNombreCliente.TabIndex = 359
        Me.lblNombreCliente.Text = "_"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(86, 206)
        Me.txtTipoCambio.MaxLength = 15
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(66, 20)
        Me.txtTipoCambio.TabIndex = 6
        Me.txtTipoCambio.Text = "13"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Location = New System.Drawing.Point(8, 210)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(71, 13)
        Me.lblTipoCambio.TabIndex = 368
        Me.lblTipoCambio.Text = "Tipo cambio :"
        '
        'lblDisplayZona
        '
        Me.lblDisplayZona.AutoSize = True
        Me.lblDisplayZona.Location = New System.Drawing.Point(8, 104)
        Me.lblDisplayZona.Name = "lblDisplayZona"
        Me.lblDisplayZona.Size = New System.Drawing.Size(38, 13)
        Me.lblDisplayZona.TabIndex = 372
        Me.lblDisplayZona.Text = "Zona :"
        '
        'CboZona
        '
        Me.CboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZona.FormattingEnabled = True
        Me.CboZona.Location = New System.Drawing.Point(86, 100)
        Me.CboZona.Name = "CboZona"
        Me.CboZona.Size = New System.Drawing.Size(157, 21)
        Me.CboZona.TabIndex = 3
        '
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.cboMercado)
        Me.gbFiltros.Controls.Add(Me.LblDisplayMercado)
        Me.gbFiltros.Controls.Add(Me.cboPrecentacion)
        Me.gbFiltros.Controls.Add(Me.lblDisplayPresentacion)
        Me.gbFiltros.Controls.Add(Me.cboMostrar)
        Me.gbFiltros.Controls.Add(Me.lblDisplayMostrar)
        Me.gbFiltros.Controls.Add(Me.cboTemporada)
        Me.gbFiltros.Controls.Add(Me.lblDisplayTemporada)
        Me.gbFiltros.Controls.Add(Me.CboZona)
        Me.gbFiltros.Controls.Add(Me.lblDisplayZona)
        Me.gbFiltros.Controls.Add(Me.lblTipoCambio)
        Me.gbFiltros.Controls.Add(Me.txtTipoCambio)
        Me.gbFiltros.Controls.Add(Me.lblNombreCliente)
        Me.gbFiltros.Controls.Add(Me.TxtCliente)
        Me.gbFiltros.Controls.Add(Me.lblDisplayCliente)
        Me.gbFiltros.Controls.Add(Me.cboCultivo)
        Me.gbFiltros.Controls.Add(Me.lblDisplayCultivo)
        Me.gbFiltros.Location = New System.Drawing.Point(12, 28)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(404, 238)
        Me.gbFiltros.TabIndex = 0
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros"
        '
        'cboMercado
        '
        Me.cboMercado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMercado.FormattingEnabled = True
        Me.cboMercado.Location = New System.Drawing.Point(86, 127)
        Me.cboMercado.Name = "cboMercado"
        Me.cboMercado.Size = New System.Drawing.Size(157, 21)
        Me.cboMercado.TabIndex = 4
        '
        'LblDisplayMercado
        '
        Me.LblDisplayMercado.AutoSize = True
        Me.LblDisplayMercado.Location = New System.Drawing.Point(8, 131)
        Me.LblDisplayMercado.Name = "LblDisplayMercado"
        Me.LblDisplayMercado.Size = New System.Drawing.Size(55, 13)
        Me.LblDisplayMercado.TabIndex = 380
        Me.LblDisplayMercado.Text = "Mercado :"
        '
        'cboPrecentacion
        '
        Me.cboPrecentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrecentacion.FormattingEnabled = True
        Me.cboPrecentacion.Location = New System.Drawing.Point(86, 73)
        Me.cboPrecentacion.Name = "cboPrecentacion"
        Me.cboPrecentacion.Size = New System.Drawing.Size(157, 21)
        Me.cboPrecentacion.TabIndex = 2
        '
        'lblDisplayPresentacion
        '
        Me.lblDisplayPresentacion.AutoSize = True
        Me.lblDisplayPresentacion.Location = New System.Drawing.Point(8, 77)
        Me.lblDisplayPresentacion.Name = "lblDisplayPresentacion"
        Me.lblDisplayPresentacion.Size = New System.Drawing.Size(75, 13)
        Me.lblDisplayPresentacion.TabIndex = 378
        Me.lblDisplayPresentacion.Text = "Presentación :"
        '
        'cboMostrar
        '
        Me.cboMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMostrar.FormattingEnabled = True
        Me.cboMostrar.Items.AddRange(New Object() {"VENTA", "CANTIDAD", "PRECIO_PROMEDIO"})
        Me.cboMostrar.Location = New System.Drawing.Point(238, 203)
        Me.cboMostrar.Name = "cboMostrar"
        Me.cboMostrar.Size = New System.Drawing.Size(157, 21)
        Me.cboMostrar.TabIndex = 7
        Me.cboMostrar.Visible = False
        '
        'lblDisplayMostrar
        '
        Me.lblDisplayMostrar.AutoSize = True
        Me.lblDisplayMostrar.Location = New System.Drawing.Point(160, 208)
        Me.lblDisplayMostrar.Name = "lblDisplayMostrar"
        Me.lblDisplayMostrar.Size = New System.Drawing.Size(66, 13)
        Me.lblDisplayMostrar.TabIndex = 376
        Me.lblDisplayMostrar.Text = "Mostrar por :"
        Me.lblDisplayMostrar.Visible = False
        '
        'cboTemporada
        '
        Me.cboTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemporada.FormattingEnabled = True
        Me.cboTemporada.Items.AddRange(New Object() {"ANUAL", "MIXTA"})
        Me.cboTemporada.Location = New System.Drawing.Point(86, 19)
        Me.cboTemporada.Name = "cboTemporada"
        Me.cboTemporada.Size = New System.Drawing.Size(157, 21)
        Me.cboTemporada.TabIndex = 0
        '
        'lblDisplayTemporada
        '
        Me.lblDisplayTemporada.AutoSize = True
        Me.lblDisplayTemporada.Location = New System.Drawing.Point(8, 23)
        Me.lblDisplayTemporada.Name = "lblDisplayTemporada"
        Me.lblDisplayTemporada.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayTemporada.TabIndex = 374
        Me.lblDisplayTemporada.Text = "Temporada :"
        '
        'Rpt_Q_ComparativosVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 273)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.gbFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Q_ComparativosVenta"
        Me.Text = "Comparativos de venta"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDisplayCultivo As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents lblDisplayZona As System.Windows.Forms.Label
    Friend WithEvents CboZona As System.Windows.Forms.ComboBox
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cboTemporada As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayTemporada As System.Windows.Forms.Label
    Friend WithEvents cboMostrar As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayMostrar As System.Windows.Forms.Label
    Friend WithEvents cboPrecentacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayPresentacion As System.Windows.Forms.Label
    Friend WithEvents cboMercado As System.Windows.Forms.ComboBox
    Friend WithEvents LblDisplayMercado As System.Windows.Forms.Label
End Class
