<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXC_Seguimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXC_Seguimientos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnEdiar = New System.Windows.Forms.Button
        Me.btnAgregarNegociante = New System.Windows.Forms.Button
        Me.cbocontactadoPor = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboNombreNegociante = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboTipoAcuerdo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNombreNegocio = New System.Windows.Forms.Label
        Me.txtSeguimiento = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DtpHora = New System.Windows.Forms.DateTimePicker
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker
        Me.LblFecha = New System.Windows.Forms.Label
        Me.txtNegocio = New System.Windows.Forms.TextBox
        Me.tsMenu = New System.Windows.Forms.ToolStrip
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton
        Me.StatusStripEstado = New System.Windows.Forms.StatusStrip
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssElaboro = New System.Windows.Forms.ToolStripStatusLabel
        Me.tssCancelo = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.StatusStripEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario que negoció :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.cboTipoAcuerdo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblNombreNegocio)
        Me.GroupBox1.Controls.Add(Me.txtSeguimiento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtNegocio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 221)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnEdiar)
        Me.GroupBox3.Controls.Add(Me.btnAgregarNegociante)
        Me.GroupBox3.Controls.Add(Me.cbocontactadoPor)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cboNombreNegociante)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 136)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(663, 79)
        Me.GroupBox3.TabIndex = 270
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información adicional"
        '
        'btnEdiar
        '
        Me.btnEdiar.Location = New System.Drawing.Point(582, 22)
        Me.btnEdiar.Name = "btnEdiar"
        Me.btnEdiar.Size = New System.Drawing.Size(75, 23)
        Me.btnEdiar.TabIndex = 10
        Me.btnEdiar.Text = "Editar"
        Me.btnEdiar.UseVisualStyleBackColor = True
        '
        'btnAgregarNegociante
        '
        Me.btnAgregarNegociante.Location = New System.Drawing.Point(446, 22)
        Me.btnAgregarNegociante.Name = "btnAgregarNegociante"
        Me.btnAgregarNegociante.Size = New System.Drawing.Size(130, 23)
        Me.btnAgregarNegociante.TabIndex = 9
        Me.btnAgregarNegociante.Text = "Agregar negociante"
        Me.btnAgregarNegociante.UseVisualStyleBackColor = True
        '
        'cbocontactadoPor
        '
        Me.cbocontactadoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocontactadoPor.FormattingEnabled = True
        Me.cbocontactadoPor.Location = New System.Drawing.Point(117, 49)
        Me.cbocontactadoPor.Name = "cbocontactadoPor"
        Me.cbocontactadoPor.Size = New System.Drawing.Size(323, 21)
        Me.cbocontactadoPor.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Contactado por :"
        '
        'cboNombreNegociante
        '
        Me.cboNombreNegociante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNombreNegociante.FormattingEnabled = True
        Me.cboNombreNegociante.Location = New System.Drawing.Point(117, 22)
        Me.cboNombreNegociante.Name = "cboNombreNegociante"
        Me.cboNombreNegociante.Size = New System.Drawing.Size(323, 21)
        Me.cboNombreNegociante.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 270
        Me.Label5.Text = "Nombre negociante :"
        '
        'cboTipoAcuerdo
        '
        Me.cboTipoAcuerdo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAcuerdo.FormattingEnabled = True
        Me.cboTipoAcuerdo.Location = New System.Drawing.Point(126, 109)
        Me.cboTipoAcuerdo.Name = "cboTipoAcuerdo"
        Me.cboTipoAcuerdo.Size = New System.Drawing.Size(235, 21)
        Me.cboTipoAcuerdo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 268
        Me.Label4.Text = "Tipo de acuerdo :"
        '
        'lblNombreNegocio
        '
        Me.lblNombreNegocio.Location = New System.Drawing.Point(170, 13)
        Me.lblNombreNegocio.Name = "lblNombreNegocio"
        Me.lblNombreNegocio.Size = New System.Drawing.Size(499, 13)
        Me.lblNombreNegocio.TabIndex = 267
        Me.lblNombreNegocio.Text = "_"
        '
        'txtSeguimiento
        '
        Me.txtSeguimiento.Location = New System.Drawing.Point(9, 51)
        Me.txtSeguimiento.Multiline = True
        Me.txtSeguimiento.Name = "txtSeguimiento"
        Me.txtSeguimiento.Size = New System.Drawing.Size(486, 52)
        Me.txtSeguimiento.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 265
        Me.Label3.Text = "Seguimiento :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DtpHora)
        Me.GroupBox2.Controls.Add(Me.DtpFecha)
        Me.GroupBox2.Controls.Add(Me.LblFecha)
        Me.GroupBox2.Location = New System.Drawing.Point(501, 44)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(171, 68)
        Me.GroupBox2.TabIndex = 264
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha de compromiso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 264
        Me.Label2.Text = "Fecha :"
        '
        'DtpHora
        '
        Me.DtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DtpHora.Location = New System.Drawing.Point(55, 45)
        Me.DtpHora.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpHora.Name = "DtpHora"
        Me.DtpHora.Size = New System.Drawing.Size(107, 20)
        Me.DtpHora.TabIndex = 5
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(55, 19)
        Me.DtpFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(107, 20)
        Me.DtpFecha.TabIndex = 4
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.Location = New System.Drawing.Point(6, 23)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(43, 13)
        Me.LblFecha.TabIndex = 263
        Me.LblFecha.Text = "Fecha :"
        '
        'txtNegocio
        '
        Me.txtNegocio.Location = New System.Drawing.Point(126, 10)
        Me.txtNegocio.Name = "txtNegocio"
        Me.txtNegocio.Size = New System.Drawing.Size(38, 20)
        Me.txtNegocio.TabIndex = 2
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(687, 25)
        Me.tsMenu.TabIndex = 2
        Me.tsMenu.Text = "tsMenu"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(62, 22)
        Me.tsbGrabar.Text = "&Grabar"
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
        Me.StatusStripEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssElaboro, Me.tssCancelo})
        Me.StatusStripEstado.Location = New System.Drawing.Point(0, 245)
        Me.StatusStripEstado.Name = "StatusStripEstado"
        Me.StatusStripEstado.Size = New System.Drawing.Size(687, 24)
        Me.StatusStripEstado.TabIndex = 241
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
        'Frm_CXC_Seguimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 269)
        Me.Controls.Add(Me.StatusStripEstado)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXC_Seguimientos"
        Me.Text = "CXC Seguimientos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.StatusStripEstado.ResumeLayout(False)
        Me.StatusStripEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNegocio As System.Windows.Forms.TextBox
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStripEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssElaboro As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssCancelo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFecha As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNombreNegocio As System.Windows.Forms.Label
    Friend WithEvents txtSeguimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbocontactadoPor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboNombreNegociante As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAcuerdo As System.Windows.Forms.ComboBox
    Friend WithEvents btnEdiar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarNegociante As System.Windows.Forms.Button
End Class
