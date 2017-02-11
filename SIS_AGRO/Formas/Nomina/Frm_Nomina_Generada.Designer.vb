<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_Generada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_Generada))
        Me.GridDeduccion = New FlexCell.Grid()
        Me.gbDeducciones = New System.Windows.Forms.GroupBox()
        Me.lblDisplayTotales = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.TcNomina = New System.Windows.Forms.TabControl()
        Me.tpDeducciones = New System.Windows.Forms.TabPage()
        Me.tpDispersion = New System.Windows.Forms.TabPage()
        Me.gbDispercion = New System.Windows.Forms.GroupBox()
        Me.gbArchivos = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtRango = New System.Windows.Forms.TextBox()
        Me.txtConsecutivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalDispersion = New System.Windows.Forms.TextBox()
        Me.lblConfimado = New System.Windows.Forms.Label()
        Me.btnGenerarDispersion = New System.Windows.Forms.Button()
        Me.gbTotalesTrabajadores = New System.Windows.Forms.GroupBox()
        Me.lblDisplayIgual = New System.Windows.Forms.Label()
        Me.lblDisplayMas = New System.Windows.Forms.Label()
        Me.txtTotalTrabajadores = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtAceptados = New System.Windows.Forms.TextBox()
        Me.txtRechazados = New System.Windows.Forms.TextBox()
        Me.lblDisplayAceptados = New System.Windows.Forms.Label()
        Me.lblDisplayRechazados = New System.Windows.Forms.Label()
        Me.lblDisplayTotal = New System.Windows.Forms.Label()
        Me.CkbMarcarTodo = New System.Windows.Forms.CheckBox()
        Me.btnRegresarIntegracion = New System.Windows.Forms.Button()
        Me.cboTxtArchivos = New System.Windows.Forms.ComboBox()
        Me.GridDispersion = New FlexCell.Grid()
        Me.btnIntegrar = New System.Windows.Forms.Button()
        Me.dtFechaDispersion = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbDeducciones.SuspendLayout()
        Me.TcNomina.SuspendLayout()
        Me.tpDeducciones.SuspendLayout()
        Me.tpDispersion.SuspendLayout()
        Me.gbDispercion.SuspendLayout()
        Me.gbArchivos.SuspendLayout()
        Me.gbTotalesTrabajadores.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridDeduccion
        '
        Me.GridDeduccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridDeduccion.CheckedImage = CType(resources.GetObject("GridDeduccion.CheckedImage"), System.Drawing.Bitmap)
        Me.GridDeduccion.Cols = 1
        Me.GridDeduccion.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridDeduccion.DisplayRowNumber = True
        Me.GridDeduccion.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridDeduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDeduccion.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridDeduccion.Location = New System.Drawing.Point(12, 20)
        Me.GridDeduccion.LockButton = True
        Me.GridDeduccion.Name = "GridDeduccion"
        Me.GridDeduccion.Rows = 8
        Me.GridDeduccion.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridDeduccion.Size = New System.Drawing.Size(764, 379)
        Me.GridDeduccion.TabIndex = 375
        Me.GridDeduccion.UncheckedImage = CType(resources.GetObject("GridDeduccion.UncheckedImage"), System.Drawing.Bitmap)
        '
        'gbDeducciones
        '
        Me.gbDeducciones.Controls.Add(Me.lblDisplayTotales)
        Me.gbDeducciones.Controls.Add(Me.txtTotal)
        Me.gbDeducciones.Controls.Add(Me.GridDeduccion)
        Me.gbDeducciones.Location = New System.Drawing.Point(6, 15)
        Me.gbDeducciones.Name = "gbDeducciones"
        Me.gbDeducciones.Size = New System.Drawing.Size(782, 425)
        Me.gbDeducciones.TabIndex = 376
        Me.gbDeducciones.TabStop = False
        Me.gbDeducciones.Text = "Deducciones"
        '
        'lblDisplayTotales
        '
        Me.lblDisplayTotales.AutoSize = True
        Me.lblDisplayTotales.Location = New System.Drawing.Point(344, 402)
        Me.lblDisplayTotales.Name = "lblDisplayTotales"
        Me.lblDisplayTotales.Size = New System.Drawing.Size(156, 13)
        Me.lblDisplayTotales.TabIndex = 378
        Me.lblDisplayTotales.Text = "Total de abonos de la semana :"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(525, 399)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 376
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnRegresar
        '
        Me.btnRegresar.Location = New System.Drawing.Point(622, 446)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(119, 23)
        Me.btnRegresar.TabIndex = 390
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Location = New System.Drawing.Point(483, 446)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(119, 23)
        Me.btnConfirmar.TabIndex = 389
        Me.btnConfirmar.Text = "Confirmar"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'TcNomina
        '
        Me.TcNomina.Controls.Add(Me.tpDeducciones)
        Me.TcNomina.Controls.Add(Me.tpDispersion)
        Me.TcNomina.Location = New System.Drawing.Point(12, 32)
        Me.TcNomina.Name = "TcNomina"
        Me.TcNomina.SelectedIndex = 0
        Me.TcNomina.Size = New System.Drawing.Size(802, 536)
        Me.TcNomina.TabIndex = 391
        '
        'tpDeducciones
        '
        Me.tpDeducciones.Controls.Add(Me.gbDeducciones)
        Me.tpDeducciones.Controls.Add(Me.btnRegresar)
        Me.tpDeducciones.Controls.Add(Me.btnConfirmar)
        Me.tpDeducciones.Location = New System.Drawing.Point(4, 22)
        Me.tpDeducciones.Name = "tpDeducciones"
        Me.tpDeducciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDeducciones.Size = New System.Drawing.Size(794, 510)
        Me.tpDeducciones.TabIndex = 0
        Me.tpDeducciones.Text = "Deducciones"
        Me.tpDeducciones.UseVisualStyleBackColor = True
        '
        'tpDispersion
        '
        Me.tpDispersion.Controls.Add(Me.gbDispercion)
        Me.tpDispersion.Location = New System.Drawing.Point(4, 22)
        Me.tpDispersion.Name = "tpDispersion"
        Me.tpDispersion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDispersion.Size = New System.Drawing.Size(794, 510)
        Me.tpDispersion.TabIndex = 1
        Me.tpDispersion.Text = "Dispersión"
        Me.tpDispersion.UseVisualStyleBackColor = True
        '
        'gbDispercion
        '
        Me.gbDispercion.Controls.Add(Me.Label4)
        Me.gbDispercion.Controls.Add(Me.dtFechaDispersion)
        Me.gbDispercion.Controls.Add(Me.gbArchivos)
        Me.gbDispercion.Controls.Add(Me.Label1)
        Me.gbDispercion.Controls.Add(Me.txtTotalDispersion)
        Me.gbDispercion.Controls.Add(Me.lblConfimado)
        Me.gbDispercion.Controls.Add(Me.btnGenerarDispersion)
        Me.gbDispercion.Controls.Add(Me.gbTotalesTrabajadores)
        Me.gbDispercion.Controls.Add(Me.CkbMarcarTodo)
        Me.gbDispercion.Controls.Add(Me.btnRegresarIntegracion)
        Me.gbDispercion.Controls.Add(Me.cboTxtArchivos)
        Me.gbDispercion.Controls.Add(Me.GridDispersion)
        Me.gbDispercion.Controls.Add(Me.btnIntegrar)
        Me.gbDispercion.Location = New System.Drawing.Point(6, 6)
        Me.gbDispercion.Name = "gbDispercion"
        Me.gbDispercion.Size = New System.Drawing.Size(782, 498)
        Me.gbDispercion.TabIndex = 392
        Me.gbDispercion.TabStop = False
        Me.gbDispercion.Text = "Dispersión de trabajadores"
        '
        'gbArchivos
        '
        Me.gbArchivos.Controls.Add(Me.Label3)
        Me.gbArchivos.Controls.Add(Me.TxtRango)
        Me.gbArchivos.Controls.Add(Me.txtConsecutivo)
        Me.gbArchivos.Controls.Add(Me.Label2)
        Me.gbArchivos.Location = New System.Drawing.Point(626, 178)
        Me.gbArchivos.Name = "gbArchivos"
        Me.gbArchivos.Size = New System.Drawing.Size(150, 103)
        Me.gbArchivos.TabIndex = 400
        Me.gbArchivos.TabStop = False
        Me.gbArchivos.Text = "Archivo del banco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 399
        Me.Label3.Text = "Consecutivo :"
        '
        'TxtRango
        '
        Me.TxtRango.Location = New System.Drawing.Point(100, 77)
        Me.TxtRango.MaxLength = 3
        Me.TxtRango.Name = "TxtRango"
        Me.TxtRango.Size = New System.Drawing.Size(44, 20)
        Me.TxtRango.TabIndex = 396
        Me.TxtRango.Text = "100"
        Me.TxtRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConsecutivo
        '
        Me.txtConsecutivo.Location = New System.Drawing.Point(100, 38)
        Me.txtConsecutivo.MaxLength = 3
        Me.txtConsecutivo.Name = "txtConsecutivo"
        Me.txtConsecutivo.Size = New System.Drawing.Size(44, 20)
        Me.txtConsecutivo.TabIndex = 398
        Me.txtConsecutivo.Text = "1"
        Me.txtConsecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 397
        Me.Label2.Text = "Rango trabajadores :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(364, 460)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 395
        Me.Label1.Text = "Total :"
        '
        'txtTotalDispersion
        '
        Me.txtTotalDispersion.Enabled = False
        Me.txtTotalDispersion.Location = New System.Drawing.Point(422, 457)
        Me.txtTotalDispersion.Name = "txtTotalDispersion"
        Me.txtTotalDispersion.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDispersion.TabIndex = 394
        Me.txtTotalDispersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConfimado
        '
        Me.lblConfimado.AutoSize = True
        Me.lblConfimado.Location = New System.Drawing.Point(633, 178)
        Me.lblConfimado.Name = "lblConfimado"
        Me.lblConfimado.Size = New System.Drawing.Size(10, 13)
        Me.lblConfimado.TabIndex = 393
        Me.lblConfimado.Text = "."
        '
        'btnGenerarDispersion
        '
        Me.btnGenerarDispersion.Location = New System.Drawing.Point(624, 84)
        Me.btnGenerarDispersion.Name = "btnGenerarDispersion"
        Me.btnGenerarDispersion.Size = New System.Drawing.Size(152, 23)
        Me.btnGenerarDispersion.TabIndex = 392
        Me.btnGenerarDispersion.Text = "Generar dispersión"
        Me.btnGenerarDispersion.UseVisualStyleBackColor = True
        '
        'gbTotalesTrabajadores
        '
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayIgual)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayMas)
        Me.gbTotalesTrabajadores.Controls.Add(Me.txtTotalTrabajadores)
        Me.gbTotalesTrabajadores.Controls.Add(Me.GroupBox2)
        Me.gbTotalesTrabajadores.Controls.Add(Me.txtAceptados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.txtRechazados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayAceptados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayRechazados)
        Me.gbTotalesTrabajadores.Controls.Add(Me.lblDisplayTotal)
        Me.gbTotalesTrabajadores.Location = New System.Drawing.Point(624, 287)
        Me.gbTotalesTrabajadores.Name = "gbTotalesTrabajadores"
        Me.gbTotalesTrabajadores.Size = New System.Drawing.Size(152, 164)
        Me.gbTotalesTrabajadores.TabIndex = 391
        Me.gbTotalesTrabajadores.TabStop = False
        Me.gbTotalesTrabajadores.Text = "Totales trabajadores"
        '
        'lblDisplayIgual
        '
        Me.lblDisplayIgual.AutoSize = True
        Me.lblDisplayIgual.Location = New System.Drawing.Point(28, 131)
        Me.lblDisplayIgual.Name = "lblDisplayIgual"
        Me.lblDisplayIgual.Size = New System.Drawing.Size(13, 13)
        Me.lblDisplayIgual.TabIndex = 395
        Me.lblDisplayIgual.Text = "="
        '
        'lblDisplayMas
        '
        Me.lblDisplayMas.AutoSize = True
        Me.lblDisplayMas.Location = New System.Drawing.Point(28, 80)
        Me.lblDisplayMas.Name = "lblDisplayMas"
        Me.lblDisplayMas.Size = New System.Drawing.Size(13, 13)
        Me.lblDisplayMas.TabIndex = 394
        Me.lblDisplayMas.Text = "+"
        '
        'txtTotalTrabajadores
        '
        Me.txtTotalTrabajadores.Enabled = False
        Me.txtTotalTrabajadores.Location = New System.Drawing.Point(52, 128)
        Me.txtTotalTrabajadores.Name = "txtTotalTrabajadores"
        Me.txtTotalTrabajadores.Size = New System.Drawing.Size(94, 20)
        Me.txtTotalTrabajadores.TabIndex = 393
        Me.txtTotalTrabajadores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(12, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 10)
        Me.GroupBox2.TabIndex = 392
        Me.GroupBox2.TabStop = False
        '
        'txtAceptados
        '
        Me.txtAceptados.Enabled = False
        Me.txtAceptados.Location = New System.Drawing.Point(52, 38)
        Me.txtAceptados.Name = "txtAceptados"
        Me.txtAceptados.Size = New System.Drawing.Size(94, 20)
        Me.txtAceptados.TabIndex = 4
        Me.txtAceptados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRechazados
        '
        Me.txtRechazados.Enabled = False
        Me.txtRechazados.Location = New System.Drawing.Point(52, 77)
        Me.txtRechazados.Name = "txtRechazados"
        Me.txtRechazados.Size = New System.Drawing.Size(94, 20)
        Me.txtRechazados.TabIndex = 3
        Me.txtRechazados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayAceptados
        '
        Me.lblDisplayAceptados.AutoSize = True
        Me.lblDisplayAceptados.Location = New System.Drawing.Point(11, 22)
        Me.lblDisplayAceptados.Name = "lblDisplayAceptados"
        Me.lblDisplayAceptados.Size = New System.Drawing.Size(64, 13)
        Me.lblDisplayAceptados.TabIndex = 2
        Me.lblDisplayAceptados.Text = "Aceptados :"
        '
        'lblDisplayRechazados
        '
        Me.lblDisplayRechazados.AutoSize = True
        Me.lblDisplayRechazados.Location = New System.Drawing.Point(11, 61)
        Me.lblDisplayRechazados.Name = "lblDisplayRechazados"
        Me.lblDisplayRechazados.Size = New System.Drawing.Size(73, 13)
        Me.lblDisplayRechazados.TabIndex = 1
        Me.lblDisplayRechazados.Text = "Rechazados :"
        '
        'lblDisplayTotal
        '
        Me.lblDisplayTotal.AutoSize = True
        Me.lblDisplayTotal.Location = New System.Drawing.Point(11, 112)
        Me.lblDisplayTotal.Name = "lblDisplayTotal"
        Me.lblDisplayTotal.Size = New System.Drawing.Size(98, 13)
        Me.lblDisplayTotal.TabIndex = 0
        Me.lblDisplayTotal.Text = "Total trabajadores :"
        '
        'CkbMarcarTodo
        '
        Me.CkbMarcarTodo.AutoSize = True
        Me.CkbMarcarTodo.Location = New System.Drawing.Point(378, 33)
        Me.CkbMarcarTodo.Name = "CkbMarcarTodo"
        Me.CkbMarcarTodo.Size = New System.Drawing.Size(88, 17)
        Me.CkbMarcarTodo.TabIndex = 390
        Me.CkbMarcarTodo.Text = "Marcar todas"
        Me.CkbMarcarTodo.UseVisualStyleBackColor = True
        '
        'btnRegresarIntegracion
        '
        Me.btnRegresarIntegracion.Location = New System.Drawing.Point(624, 142)
        Me.btnRegresarIntegracion.Name = "btnRegresarIntegracion"
        Me.btnRegresarIntegracion.Size = New System.Drawing.Size(152, 23)
        Me.btnRegresarIntegracion.TabIndex = 389
        Me.btnRegresarIntegracion.Text = "Regresar"
        Me.btnRegresarIntegracion.UseVisualStyleBackColor = True
        '
        'cboTxtArchivos
        '
        Me.cboTxtArchivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTxtArchivos.FormattingEnabled = True
        Me.cboTxtArchivos.Location = New System.Drawing.Point(624, 57)
        Me.cboTxtArchivos.Name = "cboTxtArchivos"
        Me.cboTxtArchivos.Size = New System.Drawing.Size(152, 21)
        Me.cboTxtArchivos.TabIndex = 387
        '
        'GridDispersion
        '
        Me.GridDispersion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridDispersion.CheckedImage = CType(resources.GetObject("GridDispersion.CheckedImage"), System.Drawing.Bitmap)
        Me.GridDispersion.Cols = 1
        Me.GridDispersion.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridDispersion.DisplayRowNumber = True
        Me.GridDispersion.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridDispersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDispersion.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridDispersion.Location = New System.Drawing.Point(6, 56)
        Me.GridDispersion.LockButton = True
        Me.GridDispersion.Name = "GridDispersion"
        Me.GridDispersion.Rows = 8
        Me.GridDispersion.Size = New System.Drawing.Size(612, 395)
        Me.GridDispersion.TabIndex = 375
        Me.GridDispersion.UncheckedImage = CType(resources.GetObject("GridDispersion.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnIntegrar
        '
        Me.btnIntegrar.Location = New System.Drawing.Point(624, 113)
        Me.btnIntegrar.Name = "btnIntegrar"
        Me.btnIntegrar.Size = New System.Drawing.Size(152, 23)
        Me.btnIntegrar.TabIndex = 385
        Me.btnIntegrar.Text = "Confirmar"
        Me.btnIntegrar.UseVisualStyleBackColor = True
        '
        'dtFechaDispersion
        '
        Me.dtFechaDispersion.CustomFormat = "dd-MMM-yy"
        Me.dtFechaDispersion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaDispersion.Location = New System.Drawing.Point(667, 19)
        Me.dtFechaDispersion.Name = "dtFechaDispersion"
        Me.dtFechaDispersion.Size = New System.Drawing.Size(109, 20)
        Me.dtFechaDispersion.TabIndex = 401
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(571, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 402
        Me.Label4.Text = "Fecha dispersión "
        '
        'Frm_Nomina_Generada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 580)
        Me.Controls.Add(Me.TcNomina)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_Generada"
        Me.Text = "Generar nómina"
        Me.gbDeducciones.ResumeLayout(False)
        Me.gbDeducciones.PerformLayout()
        Me.TcNomina.ResumeLayout(False)
        Me.tpDeducciones.ResumeLayout(False)
        Me.tpDispersion.ResumeLayout(False)
        Me.gbDispercion.ResumeLayout(False)
        Me.gbDispercion.PerformLayout()
        Me.gbArchivos.ResumeLayout(False)
        Me.gbArchivos.PerformLayout()
        Me.gbTotalesTrabajadores.ResumeLayout(False)
        Me.gbTotalesTrabajadores.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridDeduccion As FlexCell.Grid
    Friend WithEvents gbDeducciones As System.Windows.Forms.GroupBox
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents lblDisplayTotales As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents TcNomina As System.Windows.Forms.TabControl
    Friend WithEvents tpDeducciones As System.Windows.Forms.TabPage
    Friend WithEvents tpDispersion As System.Windows.Forms.TabPage
    Friend WithEvents gbDispercion As System.Windows.Forms.GroupBox
    Friend WithEvents gbTotalesTrabajadores As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayIgual As System.Windows.Forms.Label
    Friend WithEvents lblDisplayMas As System.Windows.Forms.Label
    Friend WithEvents txtTotalTrabajadores As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAceptados As System.Windows.Forms.TextBox
    Friend WithEvents txtRechazados As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayAceptados As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRechazados As System.Windows.Forms.Label
    Friend WithEvents lblDisplayTotal As System.Windows.Forms.Label
    Friend WithEvents CkbMarcarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnRegresarIntegracion As System.Windows.Forms.Button
    Friend WithEvents cboTxtArchivos As System.Windows.Forms.ComboBox
    Friend WithEvents GridDispersion As FlexCell.Grid
    Friend WithEvents btnIntegrar As System.Windows.Forms.Button
    Friend WithEvents btnGenerarDispersion As System.Windows.Forms.Button
    Friend WithEvents lblConfimado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDispersion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRango As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtConsecutivo As System.Windows.Forms.TextBox
    Friend WithEvents gbArchivos As System.Windows.Forms.GroupBox
    Friend WithEvents dtFechaDispersion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
