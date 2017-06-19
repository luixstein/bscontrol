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
        Me.SuspendLayout()
        '
        'LblDisplayCodigoOrigen
        '
        Me.LblDisplayCodigoOrigen.AutoSize = True
        Me.LblDisplayCodigoOrigen.Location = New System.Drawing.Point(9, 58)
        Me.LblDisplayCodigoOrigen.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblDisplayCodigoOrigen.Name = "LblDisplayCodigoOrigen"
        Me.LblDisplayCodigoOrigen.Size = New System.Drawing.Size(112, 13)
        Me.LblDisplayCodigoOrigen.TabIndex = 0
        Me.LblDisplayCodigoOrigen.Text = "Código cliente origen :"
        '
        'BtnImportar
        '
        Me.BtnImportar.Location = New System.Drawing.Point(287, 23)
        Me.BtnImportar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Size = New System.Drawing.Size(106, 28)
        Me.BtnImportar.TabIndex = 1
        Me.BtnImportar.Text = "Importar"
        Me.BtnImportar.UseVisualStyleBackColor = True
        '
        'TxtCodigoClienteOrigen
        '
        Me.TxtCodigoClienteOrigen.Location = New System.Drawing.Point(11, 74)
        Me.TxtCodigoClienteOrigen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCodigoClienteOrigen.Name = "TxtCodigoClienteOrigen"
        Me.TxtCodigoClienteOrigen.Size = New System.Drawing.Size(111, 20)
        Me.TxtCodigoClienteOrigen.TabIndex = 2
        '
        'LblNombreCliente
        '
        Me.LblNombreCliente.AutoSize = True
        Me.LblNombreCliente.Location = New System.Drawing.Point(10, 98)
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
        Me.CboZonas.Location = New System.Drawing.Point(12, 23)
        Me.CboZonas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CboZonas.Name = "CboZonas"
        Me.CboZonas.Size = New System.Drawing.Size(216, 21)
        Me.CboZonas.TabIndex = 4
        '
        'LblZona
        '
        Me.LblZona.AutoSize = True
        Me.LblZona.Location = New System.Drawing.Point(10, 6)
        Me.LblZona.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblZona.Name = "LblZona"
        Me.LblZona.Size = New System.Drawing.Size(38, 13)
        Me.LblZona.TabIndex = 5
        Me.LblZona.Text = "Zona :"
        '
        'ImportarClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 131)
        Me.Controls.Add(Me.LblZona)
        Me.Controls.Add(Me.CboZonas)
        Me.Controls.Add(Me.LblNombreCliente)
        Me.Controls.Add(Me.TxtCodigoClienteOrigen)
        Me.Controls.Add(Me.BtnImportar)
        Me.Controls.Add(Me.LblDisplayCodigoOrigen)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
End Class
