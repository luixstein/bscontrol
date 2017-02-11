<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_Configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_Configuracion))
        Me.gBoxInformacion = New System.Windows.Forms.GroupBox
        Me.lblDisplayRutaDispersion = New System.Windows.Forms.Label
        Me.txtRutaDispersion = New System.Windows.Forms.TextBox
        Me.lblDisplayFormato = New System.Windows.Forms.Label
        Me.txtFormato = New System.Windows.Forms.TextBox
        Me.lblDisplayGuia = New System.Windows.Forms.Label
        Me.txtGuia = New System.Windows.Forms.TextBox
        Me.lblDisplayTipoPago = New System.Windows.Forms.Label
        Me.txtTipoPago = New System.Windows.Forms.TextBox
        Me.LblDisplayTipoSalario = New System.Windows.Forms.Label
        Me.txtTipoSalario = New System.Windows.Forms.TextBox
        Me.lblDisplayTipoTrabajador = New System.Windows.Forms.Label
        Me.txtTipoTrabajador = New System.Windows.Forms.TextBox
        Me.lblDisplayRutaIDSE = New System.Windows.Forms.Label
        Me.txtRutaIDSE = New System.Windows.Forms.TextBox
        Me.lblDisplayRunaFotosTrabajadores = New System.Windows.Forms.Label
        Me.txtRutaFotosTrabajadores = New System.Windows.Forms.TextBox
        Me.lblDisplayEdadMinima = New System.Windows.Forms.Label
        Me.txtEdadMinima = New System.Windows.Forms.TextBox
        Me.lblDisplayEquivalenciaJornalHoras = New System.Windows.Forms.Label
        Me.txtEquivalenciaJornalHoras = New System.Windows.Forms.TextBox
        Me.lblDisplayNumSemanaActual = New System.Windows.Forms.Label
        Me.txtSemanaActual = New System.Windows.Forms.TextBox
        Me.lblDisplayNumRegistroPatronal = New System.Windows.Forms.Label
        Me.txtRegistroPatronal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblDisplaySueldo = New System.Windows.Forms.Label
        Me.TxtSueldoDiario = New System.Windows.Forms.TextBox
        Me.LblDisplayId = New System.Windows.Forms.Label
        Me.TxtId = New System.Windows.Forms.TextBox
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tssLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssLabelEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.cboTemporada = New System.Windows.Forms.ComboBox
        Me.lblDisplayTemporada = New System.Windows.Forms.Label
        Me.gBoxInformacion.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxInformacion
        '
        Me.gBoxInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTemporada)
        Me.gBoxInformacion.Controls.Add(Me.cboTemporada)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayRutaDispersion)
        Me.gBoxInformacion.Controls.Add(Me.txtRutaDispersion)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayFormato)
        Me.gBoxInformacion.Controls.Add(Me.txtFormato)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayGuia)
        Me.gBoxInformacion.Controls.Add(Me.txtGuia)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTipoPago)
        Me.gBoxInformacion.Controls.Add(Me.txtTipoPago)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayTipoSalario)
        Me.gBoxInformacion.Controls.Add(Me.txtTipoSalario)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayTipoTrabajador)
        Me.gBoxInformacion.Controls.Add(Me.txtTipoTrabajador)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayRutaIDSE)
        Me.gBoxInformacion.Controls.Add(Me.txtRutaIDSE)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayRunaFotosTrabajadores)
        Me.gBoxInformacion.Controls.Add(Me.txtRutaFotosTrabajadores)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayEdadMinima)
        Me.gBoxInformacion.Controls.Add(Me.txtEdadMinima)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayEquivalenciaJornalHoras)
        Me.gBoxInformacion.Controls.Add(Me.txtEquivalenciaJornalHoras)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayNumSemanaActual)
        Me.gBoxInformacion.Controls.Add(Me.txtSemanaActual)
        Me.gBoxInformacion.Controls.Add(Me.lblDisplayNumRegistroPatronal)
        Me.gBoxInformacion.Controls.Add(Me.txtRegistroPatronal)
        Me.gBoxInformacion.Controls.Add(Me.Label2)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplaySueldo)
        Me.gBoxInformacion.Controls.Add(Me.TxtSueldoDiario)
        Me.gBoxInformacion.Controls.Add(Me.LblDisplayId)
        Me.gBoxInformacion.Controls.Add(Me.TxtId)
        Me.gBoxInformacion.Location = New System.Drawing.Point(4, 27)
        Me.gBoxInformacion.Name = "gBoxInformacion"
        Me.gBoxInformacion.Size = New System.Drawing.Size(434, 228)
        Me.gBoxInformacion.TabIndex = 1
        Me.gBoxInformacion.TabStop = False
        Me.gBoxInformacion.Text = "Información"
        '
        'lblDisplayRutaDispersion
        '
        Me.lblDisplayRutaDispersion.AutoSize = True
        Me.lblDisplayRutaDispersion.Location = New System.Drawing.Point(6, 206)
        Me.lblDisplayRutaDispersion.Name = "lblDisplayRutaDispersion"
        Me.lblDisplayRutaDispersion.Size = New System.Drawing.Size(114, 13)
        Me.lblDisplayRutaDispersion.TabIndex = 241
        Me.lblDisplayRutaDispersion.Text = "Ruta alta y dispersión :"
        '
        'txtRutaDispersion
        '
        Me.txtRutaDispersion.Location = New System.Drawing.Point(131, 202)
        Me.txtRutaDispersion.MaxLength = 225
        Me.txtRutaDispersion.Name = "txtRutaDispersion"
        Me.txtRutaDispersion.Size = New System.Drawing.Size(293, 20)
        Me.txtRutaDispersion.TabIndex = 240
        '
        'lblDisplayFormato
        '
        Me.lblDisplayFormato.AutoSize = True
        Me.lblDisplayFormato.Location = New System.Drawing.Point(201, 137)
        Me.lblDisplayFormato.Name = "lblDisplayFormato"
        Me.lblDisplayFormato.Size = New System.Drawing.Size(112, 13)
        Me.lblDisplayFormato.TabIndex = 239
        Me.lblDisplayFormato.Text = "Identificador formarto :"
        '
        'txtFormato
        '
        Me.txtFormato.Location = New System.Drawing.Point(337, 133)
        Me.txtFormato.MaxLength = 1
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.Size = New System.Drawing.Size(87, 20)
        Me.txtFormato.TabIndex = 10
        Me.txtFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayGuia
        '
        Me.lblDisplayGuia.AutoSize = True
        Me.lblDisplayGuia.Location = New System.Drawing.Point(201, 114)
        Me.lblDisplayGuia.Name = "lblDisplayGuia"
        Me.lblDisplayGuia.Size = New System.Drawing.Size(35, 13)
        Me.lblDisplayGuia.TabIndex = 235
        Me.lblDisplayGuia.Text = "Guia :"
        '
        'txtGuia
        '
        Me.txtGuia.Location = New System.Drawing.Point(337, 110)
        Me.txtGuia.MaxLength = 5
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(87, 20)
        Me.txtGuia.TabIndex = 9
        Me.txtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTipoPago
        '
        Me.lblDisplayTipoPago.AutoSize = True
        Me.lblDisplayTipoPago.Location = New System.Drawing.Point(6, 137)
        Me.lblDisplayTipoPago.Name = "lblDisplayTipoPago"
        Me.lblDisplayTipoPago.Size = New System.Drawing.Size(76, 13)
        Me.lblDisplayTipoPago.TabIndex = 233
        Me.lblDisplayTipoPago.Text = "Tipo de págo :"
        '
        'txtTipoPago
        '
        Me.txtTipoPago.Location = New System.Drawing.Point(108, 133)
        Me.txtTipoPago.MaxLength = 1
        Me.txtTipoPago.Name = "txtTipoPago"
        Me.txtTipoPago.Size = New System.Drawing.Size(87, 20)
        Me.txtTipoPago.TabIndex = 5
        Me.txtTipoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayTipoSalario
        '
        Me.LblDisplayTipoSalario.AutoSize = True
        Me.LblDisplayTipoSalario.Location = New System.Drawing.Point(6, 114)
        Me.LblDisplayTipoSalario.Name = "LblDisplayTipoSalario"
        Me.LblDisplayTipoSalario.Size = New System.Drawing.Size(82, 13)
        Me.LblDisplayTipoSalario.TabIndex = 231
        Me.LblDisplayTipoSalario.Text = "Tipo de salario :"
        '
        'txtTipoSalario
        '
        Me.txtTipoSalario.Location = New System.Drawing.Point(108, 110)
        Me.txtTipoSalario.MaxLength = 1
        Me.txtTipoSalario.Name = "txtTipoSalario"
        Me.txtTipoSalario.Size = New System.Drawing.Size(87, 20)
        Me.txtTipoSalario.TabIndex = 4
        Me.txtTipoSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayTipoTrabajador
        '
        Me.lblDisplayTipoTrabajador.AutoSize = True
        Me.lblDisplayTipoTrabajador.Location = New System.Drawing.Point(201, 91)
        Me.lblDisplayTipoTrabajador.Name = "lblDisplayTipoTrabajador"
        Me.lblDisplayTipoTrabajador.Size = New System.Drawing.Size(84, 13)
        Me.lblDisplayTipoTrabajador.TabIndex = 229
        Me.lblDisplayTipoTrabajador.Text = "Tipo trabajador :"
        '
        'txtTipoTrabajador
        '
        Me.txtTipoTrabajador.Location = New System.Drawing.Point(337, 87)
        Me.txtTipoTrabajador.MaxLength = 1
        Me.txtTipoTrabajador.Name = "txtTipoTrabajador"
        Me.txtTipoTrabajador.Size = New System.Drawing.Size(87, 20)
        Me.txtTipoTrabajador.TabIndex = 8
        Me.txtTipoTrabajador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayRutaIDSE
        '
        Me.lblDisplayRutaIDSE.AutoSize = True
        Me.lblDisplayRutaIDSE.Location = New System.Drawing.Point(6, 183)
        Me.lblDisplayRutaIDSE.Name = "lblDisplayRutaIDSE"
        Me.lblDisplayRutaIDSE.Size = New System.Drawing.Size(64, 13)
        Me.lblDisplayRutaIDSE.TabIndex = 227
        Me.lblDisplayRutaIDSE.Text = "Ruta IDSE :"
        '
        'txtRutaIDSE
        '
        Me.txtRutaIDSE.Location = New System.Drawing.Point(131, 179)
        Me.txtRutaIDSE.MaxLength = 225
        Me.txtRutaIDSE.Name = "txtRutaIDSE"
        Me.txtRutaIDSE.Size = New System.Drawing.Size(293, 20)
        Me.txtRutaIDSE.TabIndex = 12
        '
        'lblDisplayRunaFotosTrabajadores
        '
        Me.lblDisplayRunaFotosTrabajadores.AutoSize = True
        Me.lblDisplayRunaFotosTrabajadores.Location = New System.Drawing.Point(6, 160)
        Me.lblDisplayRunaFotosTrabajadores.Name = "lblDisplayRunaFotosTrabajadores"
        Me.lblDisplayRunaFotosTrabajadores.Size = New System.Drawing.Size(123, 13)
        Me.lblDisplayRunaFotosTrabajadores.TabIndex = 225
        Me.lblDisplayRunaFotosTrabajadores.Text = "Ruta fotos trabajadores :"
        '
        'txtRutaFotosTrabajadores
        '
        Me.txtRutaFotosTrabajadores.Location = New System.Drawing.Point(131, 156)
        Me.txtRutaFotosTrabajadores.MaxLength = 225
        Me.txtRutaFotosTrabajadores.Name = "txtRutaFotosTrabajadores"
        Me.txtRutaFotosTrabajadores.Size = New System.Drawing.Size(293, 20)
        Me.txtRutaFotosTrabajadores.TabIndex = 11
        '
        'lblDisplayEdadMinima
        '
        Me.lblDisplayEdadMinima.AutoSize = True
        Me.lblDisplayEdadMinima.Location = New System.Drawing.Point(201, 68)
        Me.lblDisplayEdadMinima.Name = "lblDisplayEdadMinima"
        Me.lblDisplayEdadMinima.Size = New System.Drawing.Size(73, 13)
        Me.lblDisplayEdadMinima.TabIndex = 223
        Me.lblDisplayEdadMinima.Text = "Edad minima :"
        '
        'txtEdadMinima
        '
        Me.txtEdadMinima.Location = New System.Drawing.Point(337, 64)
        Me.txtEdadMinima.MaxLength = 2
        Me.txtEdadMinima.Name = "txtEdadMinima"
        Me.txtEdadMinima.Size = New System.Drawing.Size(87, 20)
        Me.txtEdadMinima.TabIndex = 7
        Me.txtEdadMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayEquivalenciaJornalHoras
        '
        Me.lblDisplayEquivalenciaJornalHoras.AutoSize = True
        Me.lblDisplayEquivalenciaJornalHoras.Location = New System.Drawing.Point(201, 45)
        Me.lblDisplayEquivalenciaJornalHoras.Name = "lblDisplayEquivalenciaJornalHoras"
        Me.lblDisplayEquivalenciaJornalHoras.Size = New System.Drawing.Size(131, 13)
        Me.lblDisplayEquivalenciaJornalHoras.TabIndex = 221
        Me.lblDisplayEquivalenciaJornalHoras.Text = "Equivalencia jornal horas :"
        '
        'txtEquivalenciaJornalHoras
        '
        Me.txtEquivalenciaJornalHoras.Location = New System.Drawing.Point(337, 41)
        Me.txtEquivalenciaJornalHoras.MaxLength = 50
        Me.txtEquivalenciaJornalHoras.Name = "txtEquivalenciaJornalHoras"
        Me.txtEquivalenciaJornalHoras.Size = New System.Drawing.Size(87, 20)
        Me.txtEquivalenciaJornalHoras.TabIndex = 6
        Me.txtEquivalenciaJornalHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayNumSemanaActual
        '
        Me.lblDisplayNumSemanaActual.AutoSize = True
        Me.lblDisplayNumSemanaActual.Location = New System.Drawing.Point(6, 91)
        Me.lblDisplayNumSemanaActual.Name = "lblDisplayNumSemanaActual"
        Me.lblDisplayNumSemanaActual.Size = New System.Drawing.Size(85, 13)
        Me.lblDisplayNumSemanaActual.TabIndex = 219
        Me.lblDisplayNumSemanaActual.Text = "#Semana actual"
        '
        'txtSemanaActual
        '
        Me.txtSemanaActual.Location = New System.Drawing.Point(108, 87)
        Me.txtSemanaActual.MaxLength = 2
        Me.txtSemanaActual.Name = "txtSemanaActual"
        Me.txtSemanaActual.Size = New System.Drawing.Size(87, 20)
        Me.txtSemanaActual.TabIndex = 3
        Me.txtSemanaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayNumRegistroPatronal
        '
        Me.lblDisplayNumRegistroPatronal.AutoSize = True
        Me.lblDisplayNumRegistroPatronal.Location = New System.Drawing.Point(6, 68)
        Me.lblDisplayNumRegistroPatronal.Name = "lblDisplayNumRegistroPatronal"
        Me.lblDisplayNumRegistroPatronal.Size = New System.Drawing.Size(100, 13)
        Me.lblDisplayNumRegistroPatronal.TabIndex = 217
        Me.lblDisplayNumRegistroPatronal.Text = "#Registro patronal :"
        '
        'txtRegistroPatronal
        '
        Me.txtRegistroPatronal.Location = New System.Drawing.Point(108, 64)
        Me.txtRegistroPatronal.MaxLength = 11
        Me.txtRegistroPatronal.Name = "txtRegistroPatronal"
        Me.txtRegistroPatronal.Size = New System.Drawing.Size(87, 20)
        Me.txtRegistroPatronal.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, -114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = ".."
        '
        'LblDisplaySueldo
        '
        Me.LblDisplaySueldo.AutoSize = True
        Me.LblDisplaySueldo.Location = New System.Drawing.Point(6, 45)
        Me.LblDisplaySueldo.Name = "LblDisplaySueldo"
        Me.LblDisplaySueldo.Size = New System.Drawing.Size(74, 13)
        Me.LblDisplaySueldo.TabIndex = 74
        Me.LblDisplaySueldo.Text = "Sueldo diario :"
        '
        'TxtSueldoDiario
        '
        Me.TxtSueldoDiario.Location = New System.Drawing.Point(108, 41)
        Me.TxtSueldoDiario.MaxLength = 20
        Me.TxtSueldoDiario.Name = "TxtSueldoDiario"
        Me.TxtSueldoDiario.Size = New System.Drawing.Size(87, 20)
        Me.TxtSueldoDiario.TabIndex = 1
        Me.TxtSueldoDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDisplayId
        '
        Me.LblDisplayId.AutoSize = True
        Me.LblDisplayId.Location = New System.Drawing.Point(6, 18)
        Me.LblDisplayId.Name = "LblDisplayId"
        Me.LblDisplayId.Size = New System.Drawing.Size(22, 13)
        Me.LblDisplayId.TabIndex = 8
        Me.LblDisplayId.Text = "Id :"
        '
        'TxtId
        '
        Me.TxtId.Enabled = False
        Me.TxtId.Location = New System.Drawing.Point(108, 15)
        Me.TxtId.MaxLength = 4
        Me.TxtId.Name = "TxtId"
        Me.TxtId.Size = New System.Drawing.Size(57, 20)
        Me.TxtId.TabIndex = 0
        Me.TxtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsbEditar, Me.tsbGrabar, Me.tsbCancelar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(444, 25)
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
        Me.tsbNuevo.Visible = False
        '
        'tsbEditar
        '
        Me.tsbEditar.Image = CType(resources.GetObject("tsbEditar.Image"), System.Drawing.Image)
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(57, 22)
        Me.tsbEditar.Text = "&Editar"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'tsbCancelar
        '
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(73, 22)
        Me.tsbCancelar.Text = "&Cancelar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(49, 22)
        Me.tsbSalir.Text = "&Salir"
        '
        'StatusStripEstado
        '
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssLabel, Me.tssLabelEstado})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 258)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(444, 22)
        Me.StatusStripEstado.TabIndex = 13
        Me.StatusStripEstado.Text = "StatusStrip1"
        '
        'tssLabel
        '
        Me.tssLabel.Name = "tssLabel"
        Me.tssLabel.Size = New System.Drawing.Size(48, 17)
        Me.tssLabel.Text = "Estado :"
        '
        'tssLabelEstado
        '
        Me.tssLabelEstado.Name = "tssLabelEstado"
        Me.tssLabelEstado.Size = New System.Drawing.Size(0, 17)
        '
        'cboTemporada
        '
        Me.cboTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemporada.FormattingEnabled = True
        Me.cboTemporada.Location = New System.Drawing.Point(303, 14)
        Me.cboTemporada.Name = "cboTemporada"
        Me.cboTemporada.Size = New System.Drawing.Size(121, 21)
        Me.cboTemporada.TabIndex = 242
        '
        'lblDisplayTemporada
        '
        Me.lblDisplayTemporada.AutoSize = True
        Me.lblDisplayTemporada.Location = New System.Drawing.Point(201, 18)
        Me.lblDisplayTemporada.Name = "lblDisplayTemporada"
        Me.lblDisplayTemporada.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayTemporada.TabIndex = 243
        Me.lblDisplayTemporada.Text = "Temporada :"
        '
        'Frm_Nomina_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 280)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.gBoxInformacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_Configuracion"
        Me.Text = "Configuración de nomina"
        Me.gBoxInformacion.ResumeLayout(False)
        Me.gBoxInformacion.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gBoxInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblDisplaySueldo As System.Windows.Forms.Label
    Friend WithEvents TxtSueldoDiario As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayId As System.Windows.Forms.Label
    Friend WithEvents TxtId As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumSemanaActual As System.Windows.Forms.Label
    Friend WithEvents txtSemanaActual As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayNumRegistroPatronal As System.Windows.Forms.Label
    Friend WithEvents txtRegistroPatronal As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTipoTrabajador As System.Windows.Forms.Label
    Friend WithEvents txtTipoTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayRutaIDSE As System.Windows.Forms.Label
    Friend WithEvents txtRutaIDSE As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayRunaFotosTrabajadores As System.Windows.Forms.Label
    Friend WithEvents txtRutaFotosTrabajadores As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayEdadMinima As System.Windows.Forms.Label
    Friend WithEvents txtEdadMinima As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayEquivalenciaJornalHoras As System.Windows.Forms.Label
    Friend WithEvents txtEquivalenciaJornalHoras As System.Windows.Forms.TextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssLabelEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDisplayGuia As System.Windows.Forms.Label
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTipoPago As System.Windows.Forms.Label
    Friend WithEvents txtTipoPago As System.Windows.Forms.TextBox
    Friend WithEvents LblDisplayTipoSalario As System.Windows.Forms.Label
    Friend WithEvents txtTipoSalario As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayFormato As System.Windows.Forms.Label
    Friend WithEvents txtFormato As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayRutaDispersion As System.Windows.Forms.Label
    Friend WithEvents txtRutaDispersion As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayTemporada As System.Windows.Forms.Label
    Friend WithEvents cboTemporada As System.Windows.Forms.ComboBox
End Class
