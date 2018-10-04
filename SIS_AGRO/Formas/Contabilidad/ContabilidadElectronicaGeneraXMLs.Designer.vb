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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.btnGeneraXMLCatalogoCuentas.Location = New System.Drawing.Point(221, 19)
        Me.btnGeneraXMLCatalogoCuentas.Name = "btnGeneraXMLCatalogoCuentas"
        Me.btnGeneraXMLCatalogoCuentas.Size = New System.Drawing.Size(184, 36)
        Me.btnGeneraXMLCatalogoCuentas.TabIndex = 2
        Me.btnGeneraXMLCatalogoCuentas.Text = "Genera xml catálogo cuentas"
        Me.btnGeneraXMLCatalogoCuentas.UseVisualStyleBackColor = True
        '
        'chkPruebas
        '
        Me.chkPruebas.AutoSize = True
        Me.chkPruebas.Location = New System.Drawing.Point(616, 296)
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
        Me.dtFecha.Location = New System.Drawing.Point(92, 113)
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
        Me.GroupBox2.Controls.Add(Me.CmbEjercicio)
        Me.GroupBox2.Controls.Add(Me.LblEjercicio)
        Me.GroupBox2.Location = New System.Drawing.Point(269, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 180)
        Me.GroupBox2.TabIndex = 221
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Balanza de comprobación"
        '
        'lblDisplayFechaModificacionBalanza
        '
        Me.lblDisplayFechaModificacionBalanza.AutoSize = True
        Me.lblDisplayFechaModificacionBalanza.Location = New System.Drawing.Point(12, 133)
        Me.lblDisplayFechaModificacionBalanza.Name = "lblDisplayFechaModificacionBalanza"
        Me.lblDisplayFechaModificacionBalanza.Size = New System.Drawing.Size(192, 13)
        Me.lblDisplayFechaModificacionBalanza.TabIndex = 227
        Me.lblDisplayFechaModificacionBalanza.Text = "Asígne la fecha de última modificación:"
        Me.lblDisplayFechaModificacionBalanza.Visible = False
        '
        'rbBalanzaComplementaria
        '
        Me.rbBalanzaComplementaria.AutoSize = True
        Me.rbBalanzaComplementaria.Location = New System.Drawing.Point(13, 113)
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
        Me.rbBalanzaNormal.Location = New System.Drawing.Point(13, 90)
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
        Me.dtFechaModificacionBalanza.Location = New System.Drawing.Point(110, 149)
        Me.dtFechaModificacionBalanza.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtFechaModificacionBalanza.Name = "dtFechaModificacionBalanza"
        Me.dtFechaModificacionBalanza.Size = New System.Drawing.Size(94, 20)
        Me.dtFechaModificacionBalanza.TabIndex = 224
        Me.dtFechaModificacionBalanza.Value = New Date(2014, 2, 26, 0, 0, 0, 0)
        Me.dtFechaModificacionBalanza.Visible = False
        '
        'btnPrevioBalanzaComprobacion
        '
        Me.btnPrevioBalanzaComprobacion.Location = New System.Drawing.Point(221, 30)
        Me.btnPrevioBalanzaComprobacion.Name = "btnPrevioBalanzaComprobacion"
        Me.btnPrevioBalanzaComprobacion.Size = New System.Drawing.Size(184, 38)
        Me.btnPrevioBalanzaComprobacion.TabIndex = 223
        Me.btnPrevioBalanzaComprobacion.Text = "Ver reporte preliminar"
        Me.btnPrevioBalanzaComprobacion.UseVisualStyleBackColor = True
        '
        'btnGeneraXMLBalanzaComprobacion
        '
        Me.btnGeneraXMLBalanzaComprobacion.Location = New System.Drawing.Point(221, 91)
        Me.btnGeneraXMLBalanzaComprobacion.Name = "btnGeneraXMLBalanzaComprobacion"
        Me.btnGeneraXMLBalanzaComprobacion.Size = New System.Drawing.Size(184, 38)
        Me.btnGeneraXMLBalanzaComprobacion.TabIndex = 221
        Me.btnGeneraXMLBalanzaComprobacion.Text = "Genera xml balanza comprobación "
        Me.btnGeneraXMLBalanzaComprobacion.UseVisualStyleBackColor = True
        '
        'CmbEjercicio
        '
        Me.CmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEjercicio.FormattingEnabled = True
        Me.CmbEjercicio.Location = New System.Drawing.Point(69, 40)
        Me.CmbEjercicio.MaxLength = 1
        Me.CmbEjercicio.Name = "CmbEjercicio"
        Me.CmbEjercicio.Size = New System.Drawing.Size(135, 21)
        Me.CmbEjercicio.TabIndex = 220
        '
        'LblEjercicio
        '
        Me.LblEjercicio.AutoSize = True
        Me.LblEjercicio.Location = New System.Drawing.Point(10, 40)
        Me.LblEjercicio.Name = "LblEjercicio"
        Me.LblEjercicio.Size = New System.Drawing.Size(53, 13)
        Me.LblEjercicio.TabIndex = 219
        Me.LblEjercicio.Text = "Ejercicio :"
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(89, 97)
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
        Me.lblMsg.Location = New System.Drawing.Point(12, 295)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(523, 16)
        Me.lblMsg.TabIndex = 386
        Me.lblMsg.Text = "ARCHIVO XML DE BALANZA DE COMPROBACION GENERADO CORRECTAMENTE"
        Me.lblMsg.Visible = False
        '
        'ContabilidadElectronicaGeneraXMLs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 320)
        Me.Controls.Add(Me.chkPruebas)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.lblDisplayFecha)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ContabilidadElectronicaGeneraXMLs"
        Me.Text = "Contabilidad electrónica - Genera XMLs"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
End Class
