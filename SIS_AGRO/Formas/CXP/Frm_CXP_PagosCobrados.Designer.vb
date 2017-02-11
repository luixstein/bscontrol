<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CXP_PagosCobrados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CXP_PagosCobrados))
        Me.gbVentas = New System.Windows.Forms.GroupBox()
        Me.Grid = New FlexCell.Grid()
        Me.dtFechaMes = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkMostrarCobradosMes = New System.Windows.Forms.CheckBox()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.lblMsgGrabado = New System.Windows.Forms.Label()
        Me.btnMarcarTodos = New System.Windows.Forms.Button()
        Me.gbVentas.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbVentas
        '
        Me.gbVentas.Controls.Add(Me.Grid)
        Me.gbVentas.Location = New System.Drawing.Point(1, 59)
        Me.gbVentas.Name = "gbVentas"
        Me.gbVentas.Size = New System.Drawing.Size(988, 489)
        Me.gbVentas.TabIndex = 1
        Me.gbVentas.TabStop = False
        Me.gbVentas.Text = "Pagos"
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(7, 19)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(975, 464)
        Me.Grid.TabIndex = 0
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'dtFechaMes
        '
        Me.dtFechaMes.CustomFormat = "MMM/yyyy"
        Me.dtFechaMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaMes.Location = New System.Drawing.Point(51, 33)
        Me.dtFechaMes.Name = "dtFechaMes"
        Me.dtFechaMes.ShowUpDown = True
        Me.dtFechaMes.Size = New System.Drawing.Size(115, 20)
        Me.dtFechaMes.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mes :"
        '
        'chkMostrarCobradosMes
        '
        Me.chkMostrarCobradosMes.AutoSize = True
        Me.chkMostrarCobradosMes.Location = New System.Drawing.Point(853, 38)
        Me.chkMostrarCobradosMes.Name = "chkMostrarCobradosMes"
        Me.chkMostrarCobradosMes.Size = New System.Drawing.Size(130, 17)
        Me.chkMostrarCobradosMes.TabIndex = 3
        Me.chkMostrarCobradosMes.Text = "Mostrar cobrados mes"
        Me.chkMostrarCobradosMes.UseVisualStyleBackColor = True
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Location = New System.Drawing.Point(182, 32)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(118, 23)
        Me.btnRefrescar.TabIndex = 4
        Me.btnRefrescar.Text = "&Refrescar"
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.tsbSalir})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(992, 25)
        Me.tsMenu.TabIndex = 5
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
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(497, 2)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(268, 23)
        Me.ProgressBar.TabIndex = 6
        '
        'lblMsgGrabado
        '
        Me.lblMsgGrabado.AutoSize = True
        Me.lblMsgGrabado.BackColor = System.Drawing.Color.Blue
        Me.lblMsgGrabado.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMsgGrabado.Location = New System.Drawing.Point(771, 9)
        Me.lblMsgGrabado.Name = "lblMsgGrabado"
        Me.lblMsgGrabado.Size = New System.Drawing.Size(82, 13)
        Me.lblMsgGrabado.TabIndex = 7
        Me.lblMsgGrabado.Text = "Datos grabados"
        Me.lblMsgGrabado.Visible = False
        '
        'btnMarcarTodos
        '
        Me.btnMarcarTodos.Location = New System.Drawing.Point(361, 32)
        Me.btnMarcarTodos.Name = "btnMarcarTodos"
        Me.btnMarcarTodos.Size = New System.Drawing.Size(118, 23)
        Me.btnMarcarTodos.TabIndex = 8
        Me.btnMarcarTodos.Text = "&Marcar todos"
        Me.btnMarcarTodos.UseVisualStyleBackColor = True
        '
        'Frm_CXP_PagosCobrados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 553)
        Me.Controls.Add(Me.btnMarcarTodos)
        Me.Controls.Add(Me.lblMsgGrabado)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.btnRefrescar)
        Me.Controls.Add(Me.chkMostrarCobradosMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtFechaMes)
        Me.Controls.Add(Me.gbVentas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Frm_CXP_PagosCobrados"
        Me.Text = "Pagos cobrados"
        Me.gbVentas.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbVentas As System.Windows.Forms.GroupBox
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents dtFechaMes As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkMostrarCobradosMes As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMsgGrabado As System.Windows.Forms.Label
    Friend WithEvents btnMarcarTodos As System.Windows.Forms.Button
End Class
