<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarClientes
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
        Me.LblDisplayCodigoOrigen = New System.Windows.Forms.Label()
        Me.BtnImportar = New System.Windows.Forms.Button()
        Me.TxtCodigoClienteOrigen = New System.Windows.Forms.TextBox()
        Me.LblNombreCliente = New System.Windows.Forms.Label()
        Me.CboZonas = New System.Windows.Forms.ComboBox()
        Me.LblZona = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.lblDisplayVendedor = New System.Windows.Forms.Label()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblDisplayCodigoOrigen
        '
        Me.LblDisplayCodigoOrigen.AutoSize = True
        Me.LblDisplayCodigoOrigen.Location = New System.Drawing.Point(9, 15)
        Me.LblDisplayCodigoOrigen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDisplayCodigoOrigen.Name = "LblDisplayCodigoOrigen"
        Me.LblDisplayCodigoOrigen.Size = New System.Drawing.Size(112, 13)
        Me.LblDisplayCodigoOrigen.TabIndex = 0
        Me.LblDisplayCodigoOrigen.Text = "Código cliente origen :"
        '
        'BtnImportar
        '
        Me.BtnImportar.Location = New System.Drawing.Point(293, 148)
        Me.BtnImportar.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Size = New System.Drawing.Size(126, 38)
        Me.BtnImportar.TabIndex = 3
        Me.BtnImportar.Text = "Importar"
        Me.BtnImportar.UseVisualStyleBackColor = True
        '
        'TxtCodigoClienteOrigen
        '
        Me.TxtCodigoClienteOrigen.Location = New System.Drawing.Point(11, 31)
        Me.TxtCodigoClienteOrigen.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtCodigoClienteOrigen.Name = "TxtCodigoClienteOrigen"
        Me.TxtCodigoClienteOrigen.Size = New System.Drawing.Size(111, 20)
        Me.TxtCodigoClienteOrigen.TabIndex = 0
        '
        'LblNombreCliente
        '
        Me.LblNombreCliente.AutoSize = True
        Me.LblNombreCliente.Location = New System.Drawing.Point(126, 34)
        Me.LblNombreCliente.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblNombreCliente.Name = "LblNombreCliente"
        Me.LblNombreCliente.Size = New System.Drawing.Size(13, 13)
        Me.LblNombreCliente.TabIndex = 3
        Me.LblNombreCliente.Text = "_"
        '
        'CboZonas
        '
        Me.CboZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboZonas.FormattingEnabled = True
        Me.CboZonas.Location = New System.Drawing.Point(10, 79)
        Me.CboZonas.Margin = New System.Windows.Forms.Padding(2)
        Me.CboZonas.Name = "CboZonas"
        Me.CboZonas.Size = New System.Drawing.Size(216, 21)
        Me.CboZonas.TabIndex = 1
        '
        'LblZona
        '
        Me.LblZona.AutoSize = True
        Me.LblZona.Location = New System.Drawing.Point(8, 62)
        Me.LblZona.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblZona.Name = "LblZona"
        Me.LblZona.Size = New System.Drawing.Size(75, 13)
        Me.LblZona.TabIndex = 5
        Me.LblZona.Text = "Zona destino :"
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(10, 127)
        Me.txtVendedor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVendedor.MaxLength = 3
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(111, 20)
        Me.txtVendedor.TabIndex = 2
        '
        'lblDisplayVendedor
        '
        Me.lblDisplayVendedor.AutoSize = True
        Me.lblDisplayVendedor.Location = New System.Drawing.Point(8, 111)
        Me.lblDisplayVendedor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDisplayVendedor.Name = "lblDisplayVendedor"
        Me.lblDisplayVendedor.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayVendedor.TabIndex = 7
        Me.lblDisplayVendedor.Text = "Vendedor :"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Location = New System.Drawing.Point(125, 130)
        Me.lblVendedor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(13, 13)
        Me.lblVendedor.TabIndex = 8
        Me.lblVendedor.Text = "_"
        '
        'ImportarClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 192)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.lblDisplayVendedor)
        Me.Controls.Add(Me.LblZona)
        Me.Controls.Add(Me.CboZonas)
        Me.Controls.Add(Me.LblNombreCliente)
        Me.Controls.Add(Me.TxtCodigoClienteOrigen)
        Me.Controls.Add(Me.BtnImportar)
        Me.Controls.Add(Me.LblDisplayCodigoOrigen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "ImportarClientes"
        Me.Text = "Importar clientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblDisplayCodigoOrigen As System.Windows.Forms.Label
    Friend WithEvents BtnImportar As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoClienteOrigen As System.Windows.Forms.TextBox
    Friend WithEvents LblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents CboZonas As System.Windows.Forms.ComboBox
    Friend WithEvents LblZona As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents lblDisplayVendedor As Label
    Friend WithEvents lblVendedor As Label
End Class
