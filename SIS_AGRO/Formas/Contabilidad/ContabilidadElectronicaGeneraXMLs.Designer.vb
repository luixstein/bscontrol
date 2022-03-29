<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadElectronicaGeneraXMLs
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGeneraXMLCatalogoCuentas = New System.Windows.Forms.Button()
        Me.chkPruebas = New System.Windows.Forms.CheckBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblDisplayFechaModificacionBalanza = New System.Windows.Forms.Label()
        Me.rbBalanzaComplementaria = New System.Windows.Forms.RadioButton()
        Me.rbBalanzaNormal = New System.Windows.Forms.RadioButton()
        Me.dtFechaModificacionBalanza = New System.Windows.Forms.DateTimePicker()
        Me.btnPrevioBalanzaComprobacion = New System.Windows.Forms.Button()
        Me.btnGeneraXMLBalanzaComprobacion = New System.Windows.Forms.Button()
        Me.CmbEjercicio = New System.Windows.Forms.ComboBox()
        Me.LblEjercicio = New System.Windows.Forms.Label()
        Me.lblDisplayFecha = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.gbOtros = New System.Windows.Forms.GroupBox()
        Me.rbAuxiliarFolios = New System.Windows.Forms.RadioButton()
        Me.rbAuxiliarCtas = New System.Windows.Forms.RadioButton()
        Me.rbPolizasPeriodo = New System.Windows.Forms.RadioButton()
        Me.btnGeneraXML = New System.Windows.Forms.Button()
        Me.lblDisplayNumTramite = New System.Windows.Forms.Label()
        Me.lblDisplayNumOrden = New System.Windows.Forms.Label()
        Me.txtNumTramite = New System.Windows.Forms.TextBox()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.cboTipoSolicitud = New System.Windows.Forms.ComboBox()
        Me.lblDisplayTipoSolicitud = New System.Windows.Forms.Label()
        Me.gbFecha = New System.Windows.Forms.GroupBox()
        Me.chkPeriodo13 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbOtros.SuspendLayout()
        Me.gbFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGeneraXMLCatalogoCuentas)
        Me.GroupBox1.Location = New System.Drawing.Point(269, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 69)
        Me.GroupBox1.TabIndex = 219
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Catálogo de cuentas"
        '
        'btnGeneraXMLCatalogoCuentas
        '
        Me.btnGeneraXMLCatalogoCuentas.Location = New System.Drawing.Point(258, 19)
        Me.btnGeneraXMLCatalogoCuentas.Name = "btnGeneraXMLCatalogoCuentas"
        Me.btnGeneraXMLCatalogoCuentas.Size = New System.Drawing.Size(147, 36)
        Me.btnGeneraXMLCatalogoCuentas.TabIndex = 2
        Me.btnGeneraXMLCatalogoCuentas.Text = "Genera xml catálogo cuentas"
        Me.btnGeneraXMLCatalogoCuentas.UseVisualStyleBackColor = True
        '
        'chkPruebas
        '
        Me.chkPruebas.AutoSize = True
        Me.chkPruebas.Location = New System.Drawing.Point(3, 329)
        Me.chkPruebas.Name = "chkPruebas"
        Me.chkPruebas.Size = New System.Drawing.Size(65, 17)
        Me.chkPruebas.TabIndex = 3
        Me.chkPruebas.Text = "Pruebas"
        Me.chkPruebas.UseVisualStyleBackColor = True
        '
        'dtFecha
        '
        Me.dtFecha.CustomFormat = "MMMM/yyyy"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFecha.Location = New System.Drawing.Point(65, 21)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(134, 20)
        Me.dtFecha.TabIndex = 220
        Me.dtFecha.Value = New Date(2015, 1, 1, 18, 13, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblDisplayFechaModificacionBalanza)
        Me.GroupBox2.Controls.Add(Me.rbBalanzaComplementaria)
        Me.GroupBox2.Controls.Add(Me.rbBalanzaNormal)
        Me.GroupBox2.Controls.Add(Me.dtFechaModificacionBalanza)
        Me.GroupBox2.Controls.Add(Me.btnPrevioBalanzaComprobacion)
        Me.GroupBox2.Controls.Add(Me.btnGeneraXMLBalanzaComprobacion)
        Me.GroupBox2.Location = New System.Drawing.Point(269, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(411, 161)
        Me.GroupBox2.TabIndex = 221
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Balanza de comprobación"
        '
        'lblDisplayFechaModificacionBalanza
        '
        Me.lblDisplayFechaModificacionBalanza.AutoSize = True
        Me.lblDisplayFechaModificacionBalanza.Location = New System.Drawing.Point(12, 115)
        Me.lblDisplayFechaModificacionBalanza.Name = "lblDisplayFechaModificacionBalanza"
        Me.lblDisplayFechaModificacionBalanza.Size = New System.Drawing.Size(192, 13)
        Me.lblDisplayFechaModificacionBalanza.TabIndex = 227
        Me.lblDisplayFechaModificacionBalanza.Text = "Asígne la fecha de última modificación:"
        Me.lblDisplayFechaModificacionBalanza.Visible = False
        '
        'rbBalanzaComplementaria
        '
        Me.rbBalanzaComplementaria.AutoSize = True
        Me.rbBalanzaComplementaria.Location = New System.Drawing.Point(13, 96)
        Me.rbBalanzaComplementaria.Name = "rbBalanzaComplementaria"
        Me.rbBalanzaComplementaria.Size = New System.Drawing.Size(140, 17)
        Me.rbBalanzaComplementaria.TabIndex = 226
        Me.rbBalanzaComplementaria.Text = "Balanza complementaria"
        Me.rbBalanzaComplementaria.UseVisualStyleBackColor = True
        '
        'rbBalanzaNormal
        '
        Me.rbBalanzaNormal.AutoSize = True
        Me.rbBalanzaNormal.Checked = True
        Me.rbBalanzaNormal.Location = New System.Drawing.Point(13, 73)
        Me.rbBalanzaNormal.Name = "rbBalanzaNormal"
        Me.rbBalanzaNormal.Size = New System.Drawing.Size(97, 17)
        Me.rbBalanzaNormal.TabIndex = 225
        Me.rbBalanzaNormal.TabStop = True
        Me.rbBalanzaNormal.Text = "Balanza normal"
        Me.rbBalanzaNormal.UseVisualStyleBackColor = True
        '
        'dtFechaModificacionBalanza
        '
        Me.dtFechaModificacionBalanza.CustomFormat = "dd/MMM/yyyy"
        Me.dtFechaModificacionBalanza.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaModificacionBalanza.Location = New System.Drawing.Point(110, 132)
        Me.dtFechaModificacionBalanza.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaModificacionBalanza.Name = "dtFechaModificacionBalanza"
        Me.dtFechaModificacionBalanza.Size = New System.Drawing.Size(94, 20)
        Me.dtFechaModificacionBalanza.TabIndex = 224
        Me.dtFechaModificacionBalanza.Value = New Date(2014, 2, 26, 0, 0, 0, 0)
        Me.dtFechaModificacionBalanza.Visible = False
        '
        'btnPrevioBalanzaComprobacion
        '
        Me.btnPrevioBalanzaComprobacion.Location = New System.Drawing.Point(258, 30)
        Me.btnPrevioBalanzaComprobacion.Name = "btnPrevioBalanzaComprobacion"
        Me.btnPrevioBalanzaComprobacion.Size = New System.Drawing.Size(147, 38)
        Me.btnPrevioBalanzaComprobacion.TabIndex = 223
        Me.btnPrevioBalanzaComprobacion.Text = "Ver reporte preliminar"
        Me.btnPrevioBalanzaComprobacion.UseVisualStyleBackColor = True
        '
        'btnGeneraXMLBalanzaComprobacion
        '
        Me.btnGeneraXMLBalanzaComprobacion.Location = New System.Drawing.Point(258, 91)
        Me.btnGeneraXMLBalanzaComprobacion.Name = "btnGeneraXMLBalanzaComprobacion"
        Me.btnGeneraXMLBalanzaComprobacion.Size = New System.Drawing.Size(147, 38)
        Me.btnGeneraXMLBalanzaComprobacion.TabIndex = 221
        Me.btnGeneraXMLBalanzaComprobacion.Text = "Genera xml balanza comprobación "
        Me.btnGeneraXMLBalanzaComprobacion.UseVisualStyleBackColor = True
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(65, 45)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio.TabIndex = 220
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(6, 45)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 219
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(6, 21)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 222
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.BackColor = System.Drawing.Color.Blue
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.White
        Me.lblMsg.Location = New System.Drawing.Point(12, 397)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(523, 16)
        Me.lblMsg.TabIndex = 386
        Me.lblMsg.Text = "ARCHIVO XML DE BALANZA DE COMPROBACION GENERADO CORRECTAMENTE"
        Me.lblMsg.Visible = False
        '
        'gbOtros
        '
        Me.gbOtros.Controls.Add(Me.rbAuxiliarFolios)
        Me.gbOtros.Controls.Add(Me.rbAuxiliarCtas)
        Me.gbOtros.Controls.Add(Me.rbPolizasPeriodo)
        Me.gbOtros.Controls.Add(Me.btnGeneraXML)
        Me.gbOtros.Controls.Add(Me.lblDisplayNumTramite)
        Me.gbOtros.Controls.Add(Me.lblDisplayNumOrden)
        Me.gbOtros.Controls.Add(Me.txtNumTramite)
        Me.gbOtros.Controls.Add(Me.txtNumOrden)
        Me.gbOtros.Controls.Add(Me.cboTipoSolicitud)
        Me.gbOtros.Controls.Add(Me.lblDisplayTipoSolicitud)
        Me.gbOtros.Location = New System.Drawing.Point(270, 255)
        Me.gbOtros.Name = "gbOtros"
        Me.gbOtros.Size = New System.Drawing.Size(411, 138)
        Me.gbOtros.TabIndex = 389
        Me.gbOtros.TabStop = False
        Me.gbOtros.Text = "Otros"
        '
        'rbAuxiliarFolios
        '
        Me.rbAuxiliarFolios.AutoSize = True
        Me.rbAuxiliarFolios.Enabled = False
        Me.rbAuxiliarFolios.Location = New System.Drawing.Point(257, 72)
        Me.rbAuxiliarFolios.Name = "rbAuxiliarFolios"
        Me.rbAuxiliarFolios.Size = New System.Drawing.Size(100, 17)
        Me.rbAuxiliarFolios.TabIndex = 232
        Me.rbAuxiliarFolios.Text = "Auxiliar de folios"
        Me.rbAuxiliarFolios.UseVisualStyleBackColor = True
        Me.rbAuxiliarFolios.Visible = False
        '
        'rbAuxiliarCtas
        '
        Me.rbAuxiliarCtas.AutoSize = True
        Me.rbAuxiliarCtas.Location = New System.Drawing.Point(257, 46)
        Me.rbAuxiliarCtas.Name = "rbAuxiliarCtas"
        Me.rbAuxiliarCtas.Size = New System.Drawing.Size(114, 17)
        Me.rbAuxiliarCtas.TabIndex = 231
        Me.rbAuxiliarCtas.Text = "Auxiliar de cuentas"
        Me.rbAuxiliarCtas.UseVisualStyleBackColor = True
        '
        'rbPolizasPeriodo
        '
        Me.rbPolizasPeriodo.AutoSize = True
        Me.rbPolizasPeriodo.Checked = True
        Me.rbPolizasPeriodo.Location = New System.Drawing.Point(257, 20)
        Me.rbPolizasPeriodo.Name = "rbPolizasPeriodo"
        Me.rbPolizasPeriodo.Size = New System.Drawing.Size(113, 17)
        Me.rbPolizasPeriodo.TabIndex = 230
        Me.rbPolizasPeriodo.TabStop = True
        Me.rbPolizasPeriodo.Text = "Pólizas del periodo"
        Me.rbPolizasPeriodo.UseVisualStyleBackColor = True
        '
        'btnGeneraXML
        '
        Me.btnGeneraXML.Location = New System.Drawing.Point(257, 95)
        Me.btnGeneraXML.Name = "btnGeneraXML"
        Me.btnGeneraXML.Size = New System.Drawing.Size(148, 38)
        Me.btnGeneraXML.TabIndex = 227
        Me.btnGeneraXML.Text = "Genera xml"
        Me.btnGeneraXML.UseVisualStyleBackColor = True
        '
        'lblDisplayNumTramite
        '
        Me.lblDisplayNumTramite.AutoSize = True
        Me.lblDisplayNumTramite.Location = New System.Drawing.Point(12, 72)
        Me.lblDisplayNumTramite.Name = "lblDisplayNumTramite"
        Me.lblDisplayNumTramite.Size = New System.Drawing.Size(84, 13)
        Me.lblDisplayNumTramite.TabIndex = 226
        Me.lblDisplayNumTramite.Text = "Núm de trámite :"
        '
        'lblDisplayNumOrden
        '
        Me.lblDisplayNumOrden.AutoSize = True
        Me.lblDisplayNumOrden.Location = New System.Drawing.Point(12, 46)
        Me.lblDisplayNumOrden.Name = "lblDisplayNumOrden"
        Me.lblDisplayNumOrden.Size = New System.Drawing.Size(80, 13)
        Me.lblDisplayNumOrden.TabIndex = 225
        Me.lblDisplayNumOrden.Text = "Núm de orden :"
        '
        'txtNumTramite
        '
        Me.txtNumTramite.Location = New System.Drawing.Point(110, 69)
        Me.txtNumTramite.MaxLength = 15
        Me.txtNumTramite.Name = "txtNumTramite"
        Me.txtNumTramite.Size = New System.Drawing.Size(135, 20)
        Me.txtNumTramite.TabIndex = 224
        '
        'txtNumOrden
        '
        Me.txtNumOrden.Location = New System.Drawing.Point(110, 43)
        Me.txtNumOrden.MaxLength = 13
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.Size = New System.Drawing.Size(135, 20)
        Me.txtNumOrden.TabIndex = 223
        '
        'cboTipoSolicitud
        '
        Me.cboTipoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoSolicitud.FormattingEnabled = True
        Me.cboTipoSolicitud.Location = New System.Drawing.Point(110, 16)
        Me.cboTipoSolicitud.MaxLength = 1
        Me.cboTipoSolicitud.Name = "cboTipoSolicitud"
        Me.cboTipoSolicitud.Size = New System.Drawing.Size(135, 21)
        Me.cboTipoSolicitud.TabIndex = 222
        '
        'lblDisplayTipoSolicitud
        '
        Me.lblDisplayTipoSolicitud.AutoSize = True
        Me.lblDisplayTipoSolicitud.Location = New System.Drawing.Point(10, 19)
        Me.lblDisplayTipoSolicitud.Name = "lblDisplayTipoSolicitud"
        Me.lblDisplayTipoSolicitud.Size = New System.Drawing.Size(75, 13)
        Me.lblDisplayTipoSolicitud.TabIndex = 221
        Me.lblDisplayTipoSolicitud.Text = "Tipo solicitud :"
        '
        'gbFecha
        '
        Me.gbFecha.Controls.Add(Me.CmbEjercicio)
        Me.gbFecha.Controls.Add(Me.LblEjercicio)
        Me.gbFecha.Controls.Add(Me.dtFecha)
        Me.gbFecha.Controls.Add(Me.lblDisplayFecha)
        Me.gbFecha.Location = New System.Drawing.Point(12, 133)
        Me.gbFecha.Name = "gbFecha"
        Me.gbFecha.Size = New System.Drawing.Size(213, 77)
        Me.gbFecha.TabIndex = 390
        Me.gbFecha.TabStop = False
        '
        'chkPeriodo13
        '
        Me.chkPeriodo13.AutoSize = True
        Me.chkPeriodo13.Location = New System.Drawing.Point(12, 223)
        Me.chkPeriodo13.Name = "chkPeriodo13"
        Me.chkPeriodo13.Size = New System.Drawing.Size(77, 17)
        Me.chkPeriodo13.TabIndex = 391
        Me.chkPeriodo13.Text = "Periodo 13"
        Me.chkPeriodo13.UseVisualStyleBackColor = True
        '
        'ContabilidadElectronicaGeneraXMLs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 417)
        Me.Controls.Add(Me.chkPeriodo13)
        Me.Controls.Add(Me.gbFecha)
        Me.Controls.Add(Me.gbOtros)
        Me.Controls.Add(Me.chkPruebas)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ContabilidadElectronicaGeneraXMLs"
        Me.Text = "Contabilidad electrónica - Genera XMLs"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbOtros.ResumeLayout(False)
        Me.gbOtros.PerformLayout()
        Me.gbFecha.ResumeLayout(False)
        Me.gbFecha.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGeneraXMLCatalogoCuentas As System.Windows.Forms.Button
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGeneraXMLBalanzaComprobacion As System.Windows.Forms.Button
    Friend WithEvents CmbEjercicio As System.Windows.Forms.ComboBox
    Friend WithEvents LblEjercicio As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents chkPruebas As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrevioBalanzaComprobacion As System.Windows.Forms.Button
    Friend WithEvents lblDisplayFechaModificacionBalanza As System.Windows.Forms.Label
    Friend WithEvents rbBalanzaComplementaria As System.Windows.Forms.RadioButton
    Friend WithEvents rbBalanzaNormal As System.Windows.Forms.RadioButton
    Friend WithEvents dtFechaModificacionBalanza As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbOtros As GroupBox
    Friend WithEvents rbAuxiliarFolios As RadioButton
    Friend WithEvents rbAuxiliarCtas As RadioButton
    Friend WithEvents rbPolizasPeriodo As RadioButton
    Friend WithEvents btnGeneraXML As Button
    Friend WithEvents lblDisplayNumTramite As Label
    Friend WithEvents lblDisplayNumOrden As Label
    Friend WithEvents txtNumTramite As TextBox
    Friend WithEvents txtNumOrden As TextBox
    Friend WithEvents cboTipoSolicitud As ComboBox
    Friend WithEvents lblDisplayTipoSolicitud As Label
    Friend WithEvents gbFecha As GroupBox
    Friend WithEvents chkPeriodo13 As CheckBox
End Class
