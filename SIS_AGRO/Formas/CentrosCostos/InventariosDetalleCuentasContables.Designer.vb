<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventariosDetalleCuentasContables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventariosDetalleCuentasContables))
        Me.Grid = New FlexCell.Grid()
        Me.GridPrePoliza = New FlexCell.Grid()
        Me.cboConceptoProduccion = New System.Windows.Forms.ComboBox()
        Me.lblConceptoProduccion = New System.Windows.Forms.Label()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.txtTotalHectareas = New System.Windows.Forms.MaskedTextBox()
        Me.txtTotalImporte = New System.Windows.Forms.MaskedTextBox()
        Me.btnChecarTodos = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtArticulo = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.MaskedTextBox()
        Me.cboConcepto = New System.Windows.Forms.ComboBox()
        Me.lblDisplayConcepto = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.lblDisplayCategoria = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblDisplay = New System.Windows.Forms.Label()
        Me.txtCosto = New System.Windows.Forms.MaskedTextBox()
        Me.txtTotalCantidad = New System.Windows.Forms.MaskedTextBox()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grid.CheckedImage = CType(resources.GetObject("Grid.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid.Cols = 1
        Me.Grid.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Grid.DefaultRowHeight = CType(24, Short)
        Me.Grid.DisplayRowNumber = True
        Me.Grid.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(12, 120)
        Me.Grid.LockButton = True
        Me.Grid.Name = "Grid"
        Me.Grid.Rows = 20
        Me.Grid.Size = New System.Drawing.Size(1015, 294)
        Me.Grid.TabIndex = 8
        Me.Grid.UncheckedImage = CType(resources.GetObject("Grid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'GridPrePoliza
        '
        Me.GridPrePoliza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GridPrePoliza.CheckedImage = CType(resources.GetObject("GridPrePoliza.CheckedImage"), System.Drawing.Bitmap)
        Me.GridPrePoliza.Cols = 1
        Me.GridPrePoliza.DefaultFont = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridPrePoliza.DefaultRowHeight = CType(24, Short)
        Me.GridPrePoliza.DisplayRowNumber = True
        Me.GridPrePoliza.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.VisualStyles
        Me.GridPrePoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPrePoliza.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridPrePoliza.Location = New System.Drawing.Point(12, 449)
        Me.GridPrePoliza.LockButton = True
        Me.GridPrePoliza.Name = "GridPrePoliza"
        Me.GridPrePoliza.Rows = 20
        Me.GridPrePoliza.Size = New System.Drawing.Size(947, 324)
        Me.GridPrePoliza.TabIndex = 9
        Me.GridPrePoliza.UncheckedImage = CType(resources.GetObject("GridPrePoliza.UncheckedImage"), System.Drawing.Bitmap)
        Me.GridPrePoliza.Visible = False
        '
        'cboConceptoProduccion
        '
        Me.cboConceptoProduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConceptoProduccion.FormattingEnabled = True
        Me.cboConceptoProduccion.Location = New System.Drawing.Point(782, 41)
        Me.cboConceptoProduccion.Name = "cboConceptoProduccion"
        Me.cboConceptoProduccion.Size = New System.Drawing.Size(287, 21)
        Me.cboConceptoProduccion.TabIndex = 268
        Me.cboConceptoProduccion.Visible = False
        '
        'lblConceptoProduccion
        '
        Me.lblConceptoProduccion.AutoSize = True
        Me.lblConceptoProduccion.Location = New System.Drawing.Point(643, 44)
        Me.lblConceptoProduccion.Name = "lblConceptoProduccion"
        Me.lblConceptoProduccion.Size = New System.Drawing.Size(130, 13)
        Me.lblConceptoProduccion.TabIndex = 269
        Me.lblConceptoProduccion.Text = "Concepto de producción :"
        Me.lblConceptoProduccion.Visible = False
        '
        'btnCalcular
        '
        Me.btnCalcular.Location = New System.Drawing.Point(580, 90)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(75, 23)
        Me.btnCalcular.TabIndex = 271
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
        Me.btnCalcular.Visible = False
        '
        'txtTotalHectareas
        '
        Me.txtTotalHectareas.Location = New System.Drawing.Point(384, 420)
        Me.txtTotalHectareas.Name = "txtTotalHectareas"
        Me.txtTotalHectareas.ReadOnly = True
        Me.txtTotalHectareas.Size = New System.Drawing.Size(78, 20)
        Me.txtTotalHectareas.TabIndex = 273
        Me.txtTotalHectareas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalImporte
        '
        Me.txtTotalImporte.Location = New System.Drawing.Point(554, 420)
        Me.txtTotalImporte.Name = "txtTotalImporte"
        Me.txtTotalImporte.ReadOnly = True
        Me.txtTotalImporte.Size = New System.Drawing.Size(78, 20)
        Me.txtTotalImporte.TabIndex = 274
        Me.txtTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnChecarTodos
        '
        Me.btnChecarTodos.Location = New System.Drawing.Point(841, 91)
        Me.btnChecarTodos.Name = "btnChecarTodos"
        Me.btnChecarTodos.Size = New System.Drawing.Size(93, 23)
        Me.btnChecarTodos.TabIndex = 275
        Me.btnChecarTodos.Text = "Checar todos"
        Me.btnChecarTodos.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(841, 420)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(93, 23)
        Me.btnAceptar.TabIndex = 276
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtArticulo
        '
        Me.txtArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArticulo.Location = New System.Drawing.Point(68, 12)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.ReadOnly = True
        Me.txtArticulo.Size = New System.Drawing.Size(263, 20)
        Me.txtArticulo.TabIndex = 277
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Artículo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(343, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Cantidad :"
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(399, 12)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(95, 20)
        Me.txtCantidad.TabIndex = 279
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(498, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 282
        Me.Label3.Text = "Importe :"
        '
        'txtImporte
        '
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Location = New System.Drawing.Point(554, 12)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(108, 20)
        Me.txtImporte.TabIndex = 281
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboConcepto
        '
        Me.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConcepto.FormattingEnabled = True
        Me.cboConcepto.Location = New System.Drawing.Point(78, 90)
        Me.cboConcepto.Name = "cboConcepto"
        Me.cboConcepto.Size = New System.Drawing.Size(449, 21)
        Me.cboConcepto.TabIndex = 285
        '
        'lblDisplayConcepto
        '
        Me.lblDisplayConcepto.AutoSize = True
        Me.lblDisplayConcepto.Location = New System.Drawing.Point(12, 93)
        Me.lblDisplayConcepto.Name = "lblDisplayConcepto"
        Me.lblDisplayConcepto.Size = New System.Drawing.Size(59, 13)
        Me.lblDisplayConcepto.TabIndex = 286
        Me.lblDisplayConcepto.Text = "Concepto :"
        '
        'cboCategoria
        '
        Me.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(78, 62)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(449, 21)
        Me.cboCategoria.TabIndex = 287
        '
        'lblDisplayCategoria
        '
        Me.lblDisplayCategoria.AutoSize = True
        Me.lblDisplayCategoria.Location = New System.Drawing.Point(12, 65)
        Me.lblDisplayCategoria.Name = "lblDisplayCategoria"
        Me.lblDisplayCategoria.Size = New System.Drawing.Size(60, 13)
        Me.lblDisplayCategoria.TabIndex = 288
        Me.lblDisplayCategoria.Text = "Categoría :"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(734, 91)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(93, 23)
        Me.btnLimpiar.TabIndex = 289
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblDisplay
        '
        Me.lblDisplay.AutoSize = True
        Me.lblDisplay.Location = New System.Drawing.Point(343, 39)
        Me.lblDisplay.Name = "lblDisplay"
        Me.lblDisplay.Size = New System.Drawing.Size(40, 13)
        Me.lblDisplay.TabIndex = 291
        Me.lblDisplay.Text = "Costo :"
        '
        'txtCosto
        '
        Me.txtCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCosto.Location = New System.Drawing.Point(399, 36)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.ReadOnly = True
        Me.txtCosto.Size = New System.Drawing.Size(95, 20)
        Me.txtCosto.TabIndex = 290
        Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCantidad
        '
        Me.txtTotalCantidad.Location = New System.Drawing.Point(470, 420)
        Me.txtTotalCantidad.Name = "txtTotalCantidad"
        Me.txtTotalCantidad.ReadOnly = True
        Me.txtTotalCantidad.Size = New System.Drawing.Size(78, 20)
        Me.txtTotalCantidad.TabIndex = 292
        Me.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'InventariosDetalleCuentasContables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 448)
        Me.Controls.Add(Me.txtTotalCantidad)
        Me.Controls.Add(Me.lblDisplay)
        Me.Controls.Add(Me.txtCosto)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.cboCategoria)
        Me.Controls.Add(Me.lblDisplayCategoria)
        Me.Controls.Add(Me.cboConcepto)
        Me.Controls.Add(Me.lblDisplayConcepto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnChecarTodos)
        Me.Controls.Add(Me.txtTotalImporte)
        Me.Controls.Add(Me.txtTotalHectareas)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.cboConceptoProduccion)
        Me.Controls.Add(Me.lblConceptoProduccion)
        Me.Controls.Add(Me.GridPrePoliza)
        Me.Controls.Add(Me.Grid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InventariosDetalleCuentasContables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de cuentas contables"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid As FlexCell.Grid
    Friend WithEvents GridPrePoliza As FlexCell.Grid
    Friend WithEvents cboConceptoProduccion As System.Windows.Forms.ComboBox
    Friend WithEvents lblConceptoProduccion As System.Windows.Forms.Label
    Friend WithEvents btnCalcular As System.Windows.Forms.Button
    Friend WithEvents txtTotalHectareas As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTotalImporte As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnChecarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtArticulo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayConcepto As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblDisplayCategoria As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblDisplay As System.Windows.Forms.Label
    Friend WithEvents txtCosto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTotalCantidad As System.Windows.Forms.MaskedTextBox
End Class
