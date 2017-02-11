<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Nomina_EdicionSUA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Nomina_EdicionSUA))
        Me.gbTrabajadores = New System.Windows.Forms.GroupBox
        Me.GridTrabajadores = New FlexCell.Grid
        Me.btnFiltrar = New System.Windows.Forms.Button
        Me.btnBorrar = New System.Windows.Forms.Button
        Me.gbFiltros = New System.Windows.Forms.GroupBox
        Me.lblDisplayNombre = New System.Windows.Forms.Label
        Me.lblDisplayApellidoMaterno = New System.Windows.Forms.Label
        Me.lblDisplayApellidoPaterno = New System.Windows.Forms.Label
        Me.lblDisplayCodigoTrabajador = New System.Windows.Forms.Label
        Me.lblDisplayRegistroIMSS = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox
        Me.txtCodigoTrabajador = New System.Windows.Forms.TextBox
        Me.txtNumeroIMSS = New System.Windows.Forms.TextBox
        Me.gbMovimientosSUA = New System.Windows.Forms.GroupBox
        Me.cboMovimientos = New System.Windows.Forms.ComboBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnRegresar = New System.Windows.Forms.Button
        Me.DtpFecha1 = New System.Windows.Forms.DateTimePicker
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.lblDisplaySueldoDI = New System.Windows.Forms.Label
        Me.lblDisplayMovimiento = New System.Windows.Forms.Label
        Me.lblDisplayFecha = New System.Windows.Forms.Label
        Me.txtCodigoMovimiento = New System.Windows.Forms.TextBox
        Me.txtSueldoDI = New System.Windows.Forms.TextBox
        Me.GridMovimientos = New FlexCell.Grid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridMovimientosTrabajador = New FlexCell.Grid
        Me.gbTrabajadores.SuspendLayout()
        Me.gbFiltros.SuspendLayout()
        Me.gbMovimientosSUA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTrabajadores
        '
        Me.gbTrabajadores.Controls.Add(Me.GridTrabajadores)
        Me.gbTrabajadores.Controls.Add(Me.btnFiltrar)
        Me.gbTrabajadores.Controls.Add(Me.btnBorrar)
        Me.gbTrabajadores.Controls.Add(Me.gbFiltros)
        Me.gbTrabajadores.Location = New System.Drawing.Point(12, 12)
        Me.gbTrabajadores.Name = "gbTrabajadores"
        Me.gbTrabajadores.Size = New System.Drawing.Size(648, 572)
        Me.gbTrabajadores.TabIndex = 0
        Me.gbTrabajadores.TabStop = False
        Me.gbTrabajadores.Text = "Trabajadores :"
        '
        'GridTrabajadores
        '
        Me.GridTrabajadores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridTrabajadores.CheckedImage = CType(resources.GetObject("GridTrabajadores.CheckedImage"), System.Drawing.Bitmap)
        Me.GridTrabajadores.Cols = 1
        Me.GridTrabajadores.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridTrabajadores.DisplayRowNumber = True
        Me.GridTrabajadores.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridTrabajadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridTrabajadores.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridTrabajadores.Location = New System.Drawing.Point(17, 127)
        Me.GridTrabajadores.LockButton = True
        Me.GridTrabajadores.Name = "GridTrabajadores"
        Me.GridTrabajadores.Rows = 8
        Me.GridTrabajadores.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridTrabajadores.Size = New System.Drawing.Size(622, 431)
        Me.GridTrabajadores.TabIndex = 3
        Me.GridTrabajadores.UncheckedImage = CType(resources.GetObject("GridTrabajadores.UncheckedImage"), System.Drawing.Bitmap)
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(512, 20)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(117, 23)
        Me.btnFiltrar.TabIndex = 1
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(362, 20)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(117, 23)
        Me.btnBorrar.TabIndex = 0
        Me.btnBorrar.Text = "Borrar filtros"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.lblDisplayNombre)
        Me.gbFiltros.Controls.Add(Me.lblDisplayApellidoMaterno)
        Me.gbFiltros.Controls.Add(Me.lblDisplayApellidoPaterno)
        Me.gbFiltros.Controls.Add(Me.lblDisplayCodigoTrabajador)
        Me.gbFiltros.Controls.Add(Me.lblDisplayRegistroIMSS)
        Me.gbFiltros.Controls.Add(Me.txtNombre)
        Me.gbFiltros.Controls.Add(Me.txtApellidoMaterno)
        Me.gbFiltros.Controls.Add(Me.txtApellidoPaterno)
        Me.gbFiltros.Controls.Add(Me.txtCodigoTrabajador)
        Me.gbFiltros.Controls.Add(Me.txtNumeroIMSS)
        Me.gbFiltros.Location = New System.Drawing.Point(17, 49)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(622, 72)
        Me.gbFiltros.TabIndex = 2
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros para la búsqueda"
        '
        'lblDisplayNombre
        '
        Me.lblDisplayNombre.AutoSize = True
        Me.lblDisplayNombre.Location = New System.Drawing.Point(469, 30)
        Me.lblDisplayNombre.Name = "lblDisplayNombre"
        Me.lblDisplayNombre.Size = New System.Drawing.Size(50, 13)
        Me.lblDisplayNombre.TabIndex = 9
        Me.lblDisplayNombre.Text = "Nombre :"
        '
        'lblDisplayApellidoMaterno
        '
        Me.lblDisplayApellidoMaterno.AutoSize = True
        Me.lblDisplayApellidoMaterno.Location = New System.Drawing.Point(345, 30)
        Me.lblDisplayApellidoMaterno.Name = "lblDisplayApellidoMaterno"
        Me.lblDisplayApellidoMaterno.Size = New System.Drawing.Size(91, 13)
        Me.lblDisplayApellidoMaterno.TabIndex = 8
        Me.lblDisplayApellidoMaterno.Text = "Apellido materno :"
        '
        'lblDisplayApellidoPaterno
        '
        Me.lblDisplayApellidoPaterno.AutoSize = True
        Me.lblDisplayApellidoPaterno.Location = New System.Drawing.Point(221, 30)
        Me.lblDisplayApellidoPaterno.Name = "lblDisplayApellidoPaterno"
        Me.lblDisplayApellidoPaterno.Size = New System.Drawing.Size(89, 13)
        Me.lblDisplayApellidoPaterno.TabIndex = 7
        Me.lblDisplayApellidoPaterno.Text = "Apellido paterno :"
        '
        'lblDisplayCodigoTrabajador
        '
        Me.lblDisplayCodigoTrabajador.AutoSize = True
        Me.lblDisplayCodigoTrabajador.Location = New System.Drawing.Point(133, 30)
        Me.lblDisplayCodigoTrabajador.Name = "lblDisplayCodigoTrabajador"
        Me.lblDisplayCodigoTrabajador.Size = New System.Drawing.Size(79, 13)
        Me.lblDisplayCodigoTrabajador.TabIndex = 6
        Me.lblDisplayCodigoTrabajador.Text = "Cód. trabajador"
        '
        'lblDisplayRegistroIMSS
        '
        Me.lblDisplayRegistroIMSS.AutoSize = True
        Me.lblDisplayRegistroIMSS.Location = New System.Drawing.Point(11, 30)
        Me.lblDisplayRegistroIMSS.Name = "lblDisplayRegistroIMSS"
        Me.lblDisplayRegistroIMSS.Size = New System.Drawing.Size(82, 13)
        Me.lblDisplayRegistroIMSS.TabIndex = 5
        Me.lblDisplayRegistroIMSS.Text = "#Registro IMSS"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(469, 46)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(125, 20)
        Me.txtNombre.TabIndex = 4
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(345, 46)
        Me.txtApellidoMaterno.MaxLength = 50
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(118, 20)
        Me.txtApellidoMaterno.TabIndex = 3
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(221, 46)
        Me.txtApellidoPaterno.MaxLength = 50
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(118, 20)
        Me.txtApellidoPaterno.TabIndex = 2
        '
        'txtCodigoTrabajador
        '
        Me.txtCodigoTrabajador.Location = New System.Drawing.Point(133, 46)
        Me.txtCodigoTrabajador.MaxLength = 6
        Me.txtCodigoTrabajador.Name = "txtCodigoTrabajador"
        Me.txtCodigoTrabajador.Size = New System.Drawing.Size(79, 20)
        Me.txtCodigoTrabajador.TabIndex = 1
        '
        'txtNumeroIMSS
        '
        Me.txtNumeroIMSS.Location = New System.Drawing.Point(11, 46)
        Me.txtNumeroIMSS.MaxLength = 11
        Me.txtNumeroIMSS.Name = "txtNumeroIMSS"
        Me.txtNumeroIMSS.Size = New System.Drawing.Size(113, 20)
        Me.txtNumeroIMSS.TabIndex = 0
        '
        'gbMovimientosSUA
        '
        Me.gbMovimientosSUA.Controls.Add(Me.cboMovimientos)
        Me.gbMovimientosSUA.Controls.Add(Me.btnNuevo)
        Me.gbMovimientosSUA.Controls.Add(Me.btnRegresar)
        Me.gbMovimientosSUA.Controls.Add(Me.DtpFecha1)
        Me.gbMovimientosSUA.Controls.Add(Me.btnEliminar)
        Me.gbMovimientosSUA.Controls.Add(Me.btnGrabar)
        Me.gbMovimientosSUA.Controls.Add(Me.lblDisplaySueldoDI)
        Me.gbMovimientosSUA.Controls.Add(Me.lblDisplayMovimiento)
        Me.gbMovimientosSUA.Controls.Add(Me.lblDisplayFecha)
        Me.gbMovimientosSUA.Controls.Add(Me.txtCodigoMovimiento)
        Me.gbMovimientosSUA.Controls.Add(Me.txtSueldoDI)
        Me.gbMovimientosSUA.Controls.Add(Me.GridMovimientos)
        Me.gbMovimientosSUA.Location = New System.Drawing.Point(666, 12)
        Me.gbMovimientosSUA.Name = "gbMovimientosSUA"
        Me.gbMovimientosSUA.Size = New System.Drawing.Size(467, 572)
        Me.gbMovimientosSUA.TabIndex = 1
        Me.gbMovimientosSUA.TabStop = False
        Me.gbMovimientosSUA.Text = "Movimientos SUA"
        '
        'cboMovimientos
        '
        Me.cboMovimientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMovimientos.FormattingEnabled = True
        Me.cboMovimientos.Location = New System.Drawing.Point(76, 518)
        Me.cboMovimientos.Name = "cboMovimientos"
        Me.cboMovimientos.Size = New System.Drawing.Size(113, 21)
        Me.cboMovimientos.TabIndex = 18
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(344, 492)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(117, 23)
        Me.btnNuevo.TabIndex = 17
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Location = New System.Drawing.Point(221, 492)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(113, 23)
        Me.btnRegresar.TabIndex = 16
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'DtpFecha1
        '
        Me.DtpFecha1.CustomFormat = "dd-MMM-yy"
        Me.DtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha1.Location = New System.Drawing.Point(76, 493)
        Me.DtpFecha1.Name = "DtpFecha1"
        Me.DtpFecha1.Size = New System.Drawing.Size(113, 20)
        Me.DtpFecha1.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(344, 542)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(117, 23)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(344, 517)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(117, 23)
        Me.btnGrabar.TabIndex = 2
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'lblDisplaySueldoDI
        '
        Me.lblDisplaySueldoDI.AutoSize = True
        Me.lblDisplaySueldoDI.Location = New System.Drawing.Point(6, 547)
        Me.lblDisplaySueldoDI.Name = "lblDisplaySueldoDI"
        Me.lblDisplaySueldoDI.Size = New System.Drawing.Size(69, 13)
        Me.lblDisplaySueldoDI.TabIndex = 15
        Me.lblDisplaySueldoDI.Text = "Sueldo D. I. :"
        '
        'lblDisplayMovimiento
        '
        Me.lblDisplayMovimiento.AutoSize = True
        Me.lblDisplayMovimiento.Location = New System.Drawing.Point(6, 522)
        Me.lblDisplayMovimiento.Name = "lblDisplayMovimiento"
        Me.lblDisplayMovimiento.Size = New System.Drawing.Size(67, 13)
        Me.lblDisplayMovimiento.TabIndex = 14
        Me.lblDisplayMovimiento.Text = "Movimiento :"
        '
        'lblDisplayFecha
        '
        Me.lblDisplayFecha.AutoSize = True
        Me.lblDisplayFecha.Location = New System.Drawing.Point(6, 497)
        Me.lblDisplayFecha.Name = "lblDisplayFecha"
        Me.lblDisplayFecha.Size = New System.Drawing.Size(43, 13)
        Me.lblDisplayFecha.TabIndex = 10
        Me.lblDisplayFecha.Text = "Fecha :"
        '
        'txtCodigoMovimiento
        '
        Me.txtCodigoMovimiento.Enabled = False
        Me.txtCodigoMovimiento.Location = New System.Drawing.Point(221, 543)
        Me.txtCodigoMovimiento.MaxLength = 11
        Me.txtCodigoMovimiento.Name = "txtCodigoMovimiento"
        Me.txtCodigoMovimiento.Size = New System.Drawing.Size(113, 20)
        Me.txtCodigoMovimiento.TabIndex = 12
        '
        'txtSueldoDI
        '
        Me.txtSueldoDI.Location = New System.Drawing.Point(76, 543)
        Me.txtSueldoDI.MaxLength = 12
        Me.txtSueldoDI.Name = "txtSueldoDI"
        Me.txtSueldoDI.Size = New System.Drawing.Size(113, 20)
        Me.txtSueldoDI.TabIndex = 1
        Me.txtSueldoDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridMovimientos
        '
        Me.GridMovimientos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridMovimientos.CheckedImage = CType(resources.GetObject("GridMovimientos.CheckedImage"), System.Drawing.Bitmap)
        Me.GridMovimientos.Cols = 1
        Me.GridMovimientos.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridMovimientos.DisplayRowNumber = True
        Me.GridMovimientos.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridMovimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridMovimientos.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridMovimientos.Location = New System.Drawing.Point(6, 20)
        Me.GridMovimientos.LockButton = True
        Me.GridMovimientos.Name = "GridMovimientos"
        Me.GridMovimientos.Rows = 8
        Me.GridMovimientos.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridMovimientos.Size = New System.Drawing.Size(455, 467)
        Me.GridMovimientos.TabIndex = 4
        Me.GridMovimientos.UncheckedImage = CType(resources.GetObject("GridMovimientos.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridMovimientosTrabajador)
        Me.GroupBox1.Location = New System.Drawing.Point(1139, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(283, 500)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GridMovimientosTrabajador
        '
        Me.GridMovimientosTrabajador.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridMovimientosTrabajador.CheckedImage = CType(resources.GetObject("GridMovimientosTrabajador.CheckedImage"), System.Drawing.Bitmap)
        Me.GridMovimientosTrabajador.Cols = 1
        Me.GridMovimientosTrabajador.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridMovimientosTrabajador.DisplayRowNumber = True
        Me.GridMovimientosTrabajador.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridMovimientosTrabajador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridMovimientosTrabajador.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridMovimientosTrabajador.Location = New System.Drawing.Point(6, 20)
        Me.GridMovimientosTrabajador.LockButton = True
        Me.GridMovimientosTrabajador.Name = "GridMovimientosTrabajador"
        Me.GridMovimientosTrabajador.Rows = 8
        Me.GridMovimientosTrabajador.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.GridMovimientosTrabajador.Size = New System.Drawing.Size(271, 467)
        Me.GridMovimientosTrabajador.TabIndex = 5
        Me.GridMovimientosTrabajador.UncheckedImage = CType(resources.GetObject("GridMovimientosTrabajador.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Frm_Nomina_EdicionSUA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1434, 591)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbMovimientosSUA)
        Me.Controls.Add(Me.gbTrabajadores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_Nomina_EdicionSUA"
        Me.Text = "Edición SUA"
        Me.gbTrabajadores.ResumeLayout(False)
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.gbMovimientosSUA.ResumeLayout(False)
        Me.gbMovimientosSUA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTrabajadores As System.Windows.Forms.GroupBox
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplayNombre As System.Windows.Forms.Label
    Friend WithEvents lblDisplayApellidoMaterno As System.Windows.Forms.Label
    Friend WithEvents lblDisplayApellidoPaterno As System.Windows.Forms.Label
    Friend WithEvents lblDisplayCodigoTrabajador As System.Windows.Forms.Label
    Friend WithEvents lblDisplayRegistroIMSS As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtApellidoMaterno As System.Windows.Forms.TextBox
    Friend WithEvents txtApellidoPaterno As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoTrabajador As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroIMSS As System.Windows.Forms.TextBox
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents gbMovimientosSUA As System.Windows.Forms.GroupBox
    Friend WithEvents GridTrabajadores As FlexCell.Grid
    Friend WithEvents GridMovimientos As FlexCell.Grid
    Friend WithEvents txtSueldoDI As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplayMovimiento As System.Windows.Forms.Label
    Friend WithEvents lblDisplayFecha As System.Windows.Forms.Label
    Friend WithEvents lblDisplaySueldoDI As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents DtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboMovimientos As System.Windows.Forms.ComboBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents txtCodigoMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridMovimientosTrabajador As FlexCell.Grid
End Class
