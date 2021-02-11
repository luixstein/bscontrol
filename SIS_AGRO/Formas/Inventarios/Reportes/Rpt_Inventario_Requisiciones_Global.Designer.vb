<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rpt_Inventario_Requisiciones_Global
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rpt_Inventario_Requisiciones_Global))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDisplaySolicito = New System.Windows.Forms.Label()
        Me.TxtCodigoUsuarioSolicito = New System.Windows.Forms.TextBox()
        Me.LblNombreComprador = New System.Windows.Forms.Label()
        Me.LblDisplayComprador = New System.Windows.Forms.Label()
        Me.TxtCodigoUsuarioComprador = New System.Windows.Forms.TextBox()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.LblDisplayCodArticulo = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.TxtCodArticulo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbConsultar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.LblNombreUsuarioSolicito = New System.Windows.Forms.Label()
        Me.LblEstatus = New System.Windows.Forms.Label()
        Me.CboEstatus = New System.Windows.Forms.ComboBox()
        Me.CkbIncluirCanceladas = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CkbIncluirCanceladas)
        Me.GroupBox1.Controls.Add(Me.LblEstatus)
        Me.GroupBox1.Controls.Add(Me.CboEstatus)
        Me.GroupBox1.Controls.Add(Me.LblNombreUsuarioSolicito)
        Me.GroupBox1.Controls.Add(Me.lblDisplaySolicito)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoUsuarioSolicito)
        Me.GroupBox1.Controls.Add(Me.LblNombreComprador)
        Me.GroupBox1.Controls.Add(Me.LblDisplayComprador)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoUsuarioComprador)
        Me.GroupBox1.Controls.Add(Me.lblArticulo)
        Me.GroupBox1.Controls.Add(Me.LblDisplayCodArticulo)
        Me.GroupBox1.Controls.Add(Me.CmbAlmacen)
        Me.GroupBox1.Controls.Add(Me.TxtCodArticulo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(745, 234)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblDisplaySolicito
        '
        Me.lblDisplaySolicito.AutoSize = True
        Me.lblDisplaySolicito.Location = New System.Drawing.Point(11, 149)
        Me.lblDisplaySolicito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDisplaySolicito.Name = "lblDisplaySolicito"
        Me.lblDisplaySolicito.Size = New System.Drawing.Size(61, 17)
        Me.lblDisplaySolicito.TabIndex = 281
        Me.lblDisplaySolicito.Text = "Solicitó :"
        '
        'TxtCodigoUsuarioSolicito
        '
        Me.TxtCodigoUsuarioSolicito.Location = New System.Drawing.Point(112, 146)
        Me.TxtCodigoUsuarioSolicito.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoUsuarioSolicito.MaxLength = 16
        Me.TxtCodigoUsuarioSolicito.Name = "TxtCodigoUsuarioSolicito"
        Me.TxtCodigoUsuarioSolicito.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodigoUsuarioSolicito.TabIndex = 280
        '
        'LblNombreComprador
        '
        Me.LblNombreComprador.Location = New System.Drawing.Point(215, 109)
        Me.LblNombreComprador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreComprador.Name = "LblNombreComprador"
        Me.LblNombreComprador.Size = New System.Drawing.Size(521, 16)
        Me.LblNombreComprador.TabIndex = 279
        Me.LblNombreComprador.Text = "_"
        '
        'LblDisplayComprador
        '
        Me.LblDisplayComprador.AutoSize = True
        Me.LblDisplayComprador.Location = New System.Drawing.Point(11, 109)
        Me.LblDisplayComprador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayComprador.Name = "LblDisplayComprador"
        Me.LblDisplayComprador.Size = New System.Drawing.Size(86, 17)
        Me.LblDisplayComprador.TabIndex = 278
        Me.LblDisplayComprador.Text = "Comprador :"
        '
        'TxtCodigoUsuarioComprador
        '
        Me.TxtCodigoUsuarioComprador.Location = New System.Drawing.Point(112, 106)
        Me.TxtCodigoUsuarioComprador.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodigoUsuarioComprador.MaxLength = 16
        Me.TxtCodigoUsuarioComprador.Name = "TxtCodigoUsuarioComprador"
        Me.TxtCodigoUsuarioComprador.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodigoUsuarioComprador.TabIndex = 2
        '
        'lblArticulo
        '
        Me.lblArticulo.Location = New System.Drawing.Point(216, 68)
        Me.lblArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(521, 16)
        Me.lblArticulo.TabIndex = 276
        Me.lblArticulo.Text = "_"
        '
        'LblDisplayCodArticulo
        '
        Me.LblDisplayCodArticulo.AutoSize = True
        Me.LblDisplayCodArticulo.Location = New System.Drawing.Point(11, 68)
        Me.LblDisplayCodArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDisplayCodArticulo.Name = "LblDisplayCodArticulo"
        Me.LblDisplayCodArticulo.Size = New System.Drawing.Size(63, 17)
        Me.LblDisplayCodArticulo.TabIndex = 275
        Me.LblDisplayCodArticulo.Text = "Artículo :"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAlmacen.FormattingEnabled = True
        Me.CmbAlmacen.Location = New System.Drawing.Point(112, 23)
        Me.CmbAlmacen.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(280, 24)
        Me.CmbAlmacen.TabIndex = 0
        '
        'TxtCodArticulo
        '
        Me.TxtCodArticulo.Location = New System.Drawing.Point(112, 65)
        Me.TxtCodArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCodArticulo.MaxLength = 16
        Me.TxtCodArticulo.Name = "TxtCodArticulo"
        Me.TxtCodArticulo.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodArticulo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 269
        Me.Label3.Text = "Almacen :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(769, 27)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbConsultar
        '
        Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
        Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsultar.Name = "tsbConsultar"
        Me.tsbConsultar.Size = New System.Drawing.Size(95, 24)
        Me.tsbConsultar.Text = "&Consultar"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(62, 24)
        Me.tsbSalir.Text = "&Salir"
        '
        'LblNombreUsuarioSolicito
        '
        Me.LblNombreUsuarioSolicito.Location = New System.Drawing.Point(215, 149)
        Me.LblNombreUsuarioSolicito.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNombreUsuarioSolicito.Name = "LblNombreUsuarioSolicito"
        Me.LblNombreUsuarioSolicito.Size = New System.Drawing.Size(521, 16)
        Me.LblNombreUsuarioSolicito.TabIndex = 282
        Me.LblNombreUsuarioSolicito.Text = "_"
        '
        'LblEstatus
        '
        Me.LblEstatus.AutoSize = True
        Me.LblEstatus.Location = New System.Drawing.Point(11, 190)
        Me.LblEstatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEstatus.Name = "LblEstatus"
        Me.LblEstatus.Size = New System.Drawing.Size(63, 17)
        Me.LblEstatus.TabIndex = 288
        Me.LblEstatus.Text = "Estatus :"
        '
        'CboEstatus
        '
        Me.CboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstatus.FormattingEnabled = True
        Me.CboEstatus.Items.AddRange(New Object() {"APLICADO", "CANCELADO", "GRABADO", "RECEPCIONADO PARCIAL", "TODOS"})
        Me.CboEstatus.Location = New System.Drawing.Point(112, 186)
        Me.CboEstatus.Margin = New System.Windows.Forms.Padding(4)
        Me.CboEstatus.MaxLength = 1
        Me.CboEstatus.Name = "CboEstatus"
        Me.CboEstatus.Size = New System.Drawing.Size(207, 24)
        Me.CboEstatus.TabIndex = 287
        '
        'CkbIncluirCanceladas
        '
        Me.CkbIncluirCanceladas.AutoSize = True
        Me.CkbIncluirCanceladas.Location = New System.Drawing.Point(436, 189)
        Me.CkbIncluirCanceladas.Name = "CkbIncluirCanceladas"
        Me.CkbIncluirCanceladas.Size = New System.Drawing.Size(230, 21)
        Me.CkbIncluirCanceladas.TabIndex = 289
        Me.CkbIncluirCanceladas.Text = "Incluir requisiciones canceladas"
        Me.CkbIncluirCanceladas.UseVisualStyleBackColor = True
        '
        'Rpt_Inventario_Requisiciones_Global
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 303)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Rpt_Inventario_Requisiciones_Global"
        Me.Text = "Requisiciones de inventario solicitadas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LblDisplayCodArticulo As System.Windows.Forms.Label
    Friend WithEvents TxtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents CmbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents LblNombreComprador As System.Windows.Forms.Label
    Friend WithEvents LblDisplayComprador As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoUsuarioComprador As System.Windows.Forms.TextBox
    Friend WithEvents lblDisplaySolicito As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoUsuarioSolicito As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreUsuarioSolicito As System.Windows.Forms.Label
    Friend WithEvents CkbIncluirCanceladas As System.Windows.Forms.CheckBox
    Friend WithEvents LblEstatus As System.Windows.Forms.Label
    Friend WithEvents CboEstatus As System.Windows.Forms.ComboBox
End Class
