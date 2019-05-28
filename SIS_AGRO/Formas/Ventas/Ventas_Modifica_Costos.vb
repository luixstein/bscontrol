Option Strict On

Public Class Ventas_Modifica_Costos
    Private oVenta As New Class_Ventas_Global
    Private oCliente As New Class_CatClientes

    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyCantidad As Short = 3
    Private igyCosto As Short = 4
    Private igyPrecio As Short = 5
    Private igyUnidad As Short = 6
    Private igyImpuestoPorcentaje As Short = 7
    Private igyImpuestoImporte As Short = 8
    Private igyImporte As Short = 9
    Private igyIdArticulo As Short = 10
    Private Estado As enumEstados

    Private Enum enumEstados
        NUEVO
        APLICADO
    End Enum

    Private Sub Ventas_Modifica_Precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DesplegarAlmacenes()
        DesplegarTiposNegociaciones()
        DesplegarVendedores()
        Me.txtFolio.Focus()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.Grabar() = True Then
            Me.Cambia_Estado(enumEstados.APLICADO)
        End If
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.Inicializa()
        Me.Cambia_Estado(enumEstados.NUEVO)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub txtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFolio.KeyPress
        txtNoBeep(e)
    End Sub

    Private Sub Grid_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid.KeyDown
        GestionaGrid(e)
    End Sub

#Region "Métodos y procedimientos"
    Private Sub Inicializa()
        Try
            Me.txtFolio.Text = ""
            Me.TxtReferencia.Text = ""
            Me.TxtCliente.Text = ""
            Me.txtPlazo.Text = Plaza.PLAZO_VENTA_CONTADO.ToString
            Me.TxtConcepto.Text = ""

            Me.chkVentaPublicoGeneral.Checked = False

            Me.lblCliente.Text = ""
            Me.LblEstatus.Text = "N"
            Me.lblSaldo.Text = FormatImporteContable(0)
            Me.txtTipoCambio.Text = "0"
            Me.lblSubtotalDolares.Text = FormatImporteContable(0)
            Me.lblImpuestoDolares.Text = FormatImporteContable(0)
            Me.lblTotalDolares.Text = FormatImporteContable(0)
            Me.lblSubtotal.Text = FormatImporteContable(0)
            Me.lblImpuesto.Text = FormatImporteContable(0)
            Me.lblTotal.Text = FormatImporteContable(0)

            Me.dpFecha.Value = Date.Now
            Me.dpVencimiento.Value = Date.Now.AddDays(CDbl(Me.txtPlazo.Text))

            Me.InicializaGrid()
        Catch ex As Exception
            HandleError(Me.Name, "Inicializa", ex)
        End Try
    End Sub

    Private Sub InicializaGrid()
        Me.Grid.DataSource = Nothing
        FG_Grid_Limpiar(Me.Grid)
        Me.Grid.Rows = 2
        Me.FormateaGrid()
    End Sub

    Private Sub FormateaGrid()

        Me.Grid.Rows = 2
        Me.Grid.Cols = 11

        Me.Grid.Column(Me.igyCodigo).Width = 75
        Me.Grid.Column(Me.igyDescripcion).Width = 250
        Me.Grid.Column(Me.igyCantidad).Width = 90
        Me.Grid.Column(Me.igyCosto).Width = 100
        Me.Grid.Column(Me.igyPrecio).Width = 100
        Me.Grid.Column(Me.igyUnidad).Width = 75
        Me.Grid.Column(Me.igyImpuestoPorcentaje).Width = 70
        Me.Grid.Column(Me.igyImpuestoImporte).Width = 100
        Me.Grid.Column(Me.igyImporte).Width = 100
        Me.Grid.Column(Me.igyIdArticulo).Width = 100

        Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
        Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
        Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
        Me.Grid.Cell(0, Me.igyCosto).Text = "Costo"
        Me.Grid.Cell(0, Me.igyPrecio).Text = "Precio"
        Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
        Me.Grid.Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
        Me.Grid.Cell(0, Me.igyImpuestoImporte).Text = "IVA"
        Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"
        Me.Grid.Cell(0, Me.igyIdArticulo).Text = "Id Articulo"

        Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
        Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
        Me.Grid.Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyPrecio).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyCosto).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
        Me.Grid.Column(Me.igyCosto).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCosto).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyCosto).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImpuestoPorcentaje).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImpuestoPorcentaje).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImpuestoPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImpuestoImporte).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImpuestoImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImpuestoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyIdArticulo).Mask = FlexCell.MaskEnum.Numeric

        Me.Grid.Column(Me.igyImpuestoPorcentaje).Visible = False
        Me.Grid.Column(Me.igyIdArticulo).Visible = False

        Me.Grid.Column(Me.igyCodigo).Locked = True
        Me.Grid.Column(Me.igyDescripcion).Locked = True
        Me.Grid.Column(Me.igyCantidad).Locked = True
        Me.Grid.Column(Me.igyCosto).Locked = False
        Me.Grid.Column(Me.igyPrecio).Locked = True
        Me.Grid.Column(Me.igyUnidad).Locked = True
        Me.Grid.Column(Me.igyImpuestoPorcentaje).Locked = True
        Me.Grid.Column(Me.igyImporte).Locked = True
        Me.Grid.Column(Me.igyImpuestoImporte).Locked = True
        Me.Grid.Column(Me.igyIdArticulo).Locked = True

        Dim i As Integer

        For i = 1 To Me.Grid.Rows - 1
            If Me.Grid.Cell(i, Me.igyCodigo).Text = "-" Then Me.Grid.Cell(i, Me.igyCosto).Locked = True
        Next

    End Sub

    Private Sub GestionaCambioEstado()
        Select Case Me.LblEstatus.Text
            Case "N"
                Me.Cambia_Estado(enumEstados.NUEVO)
            Case "A"
                Me.Cambia_Estado(enumEstados.APLICADO)
        End Select
    End Sub

    Private Sub Cambia_Estado(ByVal pEstado As enumEstados)
        Me.Estado = pEstado

        Select Case Me.Estado
            Case enumEstados.NUEVO
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = True

                Me.frmDatos.Enabled = True
                Me.Grid.Locked = True

                Me.tsslEstado.Text = "Estado: Agregando nuevo movimiento"
                Me.tsslElaboro.Visible = False : Me.tsslElaboro.Text = ""
                Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

                Me.txtFolio.Enabled = True
                If Me.Visible = True Then
                    Me.txtFolio.Focus()
                End If

            Case enumEstados.APLICADO
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = True

                Me.frmDatos.Enabled = False
                Me.Grid.Locked = True

                Me.tsslEstado.Text = "Estado: Consultando movimiento"
                Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dpFecha.Value, "dd/MMM/yy").ToUpper
                Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

        End Select

        Application.DoEvents()
    End Sub

    Function Grabar() As Boolean
        Dim i As Integer
        Try
            If MsgBox("Deseas actualizar los costos de la venta con el folio : " & Me.txtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                Exit Function
            End If

            If Validar() = False Then
                Exit Function
            End If

            Totales()

            With Me.oVenta
                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 2
                    .NuevoRenglon()
                    .oVentasDetalle.FOLIO_VENTA = Me.oVenta.FOLIO_VENTA.ToUpper
                    .oVentasDetalle.CODIGO_ARTICULO = Me.Grid.Cell(i, Me.igyCodigo).Text
                    .oVentasDetalle.COSTO_NUEVO = valorNumerico(Me.Grid.Cell(i, Me.igyCosto).Text)

                    If .oVentasDetalle.ActualizaCostoVenta = False Then
                        MsgBox("Error al tratar de actualizar el costo de los renglones.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                Next

                'graba global
                If .ActualizaCostoTotalGlobal = False Then
                    MsgBox("Error al tratar de actualizar el costo total de la venta.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                Grabar = True
                MsgBox("Costos actualizados satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Function Validar() As Boolean
        Dim i As Integer

        'Valida que los costos no sean negativos
        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                If valorNumerico(Me.Grid.Cell(i, Me.igyCosto).Text) < 0 Then
                    MsgBox("El costo del renglon " & i.ToString & " no debe ser negativo", MsgBoxStyle.Exclamation, Me.Text)
                    Validar = False
                    Exit Function
                End If
            End If
        Next

        Validar = True
    End Function

    Private Sub DesplegarAlmacenes()
        Try
            Dim oAlmacenes As New Class_CatAlmacenes
            With Me.CboAlmacen
                .DisplayMember = "NOMBRE_ALMACEN"
                .ValueMember = "CODIGO_ALMACEN"
                Dim dView As New Data.DataView(oAlmacenes.ObtenerAlmacenes)
                dView.Sort = "NOMBRE_ALMACEN"
                .DataSource = dView
                If dView.Count > 0 Then
                    .SelectedValue = Usuario.Codigo_Almacen
                End If
            End With
        Catch ex As Exception
            HandleError(Me.Name, "DesplegarAlmacenes", ex)
        End Try
    End Sub

    Private Sub DesplegarVendedores()
        Dim oElementos As New Class_CatVendedores
        With Me.cboVendedor
            .DisplayMember = "Nombre_Vendedor"

            .ValueMember = "CODIGO_Vendedor"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            dView.Sort = "Nombre_Vendedor"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub DesplegarTiposNegociaciones()
        Dim oElementos As New Class_CatTiposNegociaciones
        With Me.cboTipoNegociacion
            .DisplayMember = "NOMBRE_TIPO_NEGOCIACION"

            .ValueMember = "CODIGO_TIPO_NEGOCIACION"

            Dim dView As New Data.DataView(oElementos.ObtenerElementos)
            dView.Sort = "NOMBRE_TIPO_NEGOCIACION"
            .DataSource = dView
            If dView.Count > 0 Then
                .SelectedIndex = 1
            End If
        End With
    End Sub

    Private Sub Totales()
        Dim i As Integer
        Dim dCantidad As Double, dCostoTotal As Double = 0

        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCantidad).Text) = True Then
                dCantidad = valorNumerico(Me.Grid.Cell(i, Me.igyCantidad).Text)

                If dCantidad > 0 Then
                    dCostoTotal = dCostoTotal + (valorNumerico(Me.Grid.Cell(i, Me.igyCosto).Text) * dCantidad)
                End If

            End If
        Next i

        Me.lblCostoTotal.Text = FormatImporteContable(Redondear(dCostoTotal, Empresa_Sistema.DECIMALES_CONTABILIDAD))

    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim dCosto As Double

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        dCosto = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCosto).Text)

        If Columna <> igyCosto Then
            Exit Sub
        End If

        Select Case e.KeyCode
            Case Keys.Enter
                If Columna = Me.igyCosto Then
                    If dCosto < 0 Then
                        MsgBox("El costo no debe ser negativo.", MsgBoxStyle.Exclamation, Me.Text)
                        Me.Grid.Cell(Renglon, Me.igyCantidad).SetFocus()
                    End If
                End If

                Call Totales()

        End Select
    End Sub

    Private Function Consultar(Optional ByVal bEsReferencia As Boolean = False) As Boolean
        Dim sVenta As String = Me.txtFolio.Text

        Me.Inicializa()
        Me.oVenta = New Class_Ventas_Global(sVenta)

        If Me.oVenta.Existe = False Then
            Me.Cambia_Estado(enumEstados.NUEVO)
            Me.txtFolio.Enabled = False
            Exit Function
        Else
            Me.TxtCliente.Text = Me.oVenta.CODIGO_CLIENTE
            Me.TxtConcepto.Text = Me.oVenta.CONCEPTO

            Me.oCliente = New Class_CatClientes(Me.TxtCliente.Text)
            Me.lblCliente.Text = Me.oCliente.NOMBRE_CLIENTE
            Me.lblSaldo.Text = FormatImporteContable(Me.oVenta.SALDO)
            Me.lblSubtotal.Text = FormatImporteContable(Me.oVenta.SUBTOTAL)
            Me.lblImpuesto.Text = FormatImporteContable(Me.oVenta.IMPUESTO)
            Me.lblTotal.Text = FormatImporteContable(Me.oVenta.TOTAL)
            Me.lblCostoTotal.Text = FormatImporteContable(Me.oVenta.COSTO)

            If Me.oVenta.TIPO_DE_CAMBIO > 0 Then
                Me.txtTipoCambio.Text = Me.oVenta.TIPO_DE_CAMBIO.ToString
                Me.lblSubtotalDolares.Text = FormatImporteContable(Me.oVenta.SUBTOTAL / Me.oVenta.TIPO_DE_CAMBIO).ToString
                Me.lblImpuestoDolares.Text = FormatImporteContable(Me.oVenta.IMPUESTO / Me.oVenta.TIPO_DE_CAMBIO).ToString
                Me.lblTotalDolares.Text = FormatImporteContable(Me.oVenta.TOTAL / Me.oVenta.TIPO_DE_CAMBIO).ToString
            Else
                Me.txtTipoCambio.Text = "0"
            End If

            Me.cboTipoNegociacion.SelectedValue = Me.oVenta.CODIGO_TIPO_NEGOCIACION
            Me.CboAlmacen.SelectedValue = Me.oVenta.CODIGO_ALMACEN
            Me.cboVendedor.SelectedValue = Me.oVenta.CODIGO_VENDEDOR

            Me.txtFolio.Text = Me.oVenta.FOLIO_VENTA.ToString.ToUpper
            Me.TxtReferencia.Text = Me.oVenta.FOLIO_REFERENCIA.ToString.ToUpper
            Me.LblEstatus.Text = Me.oVenta.ESTATUS_VENTA.ToString.ToUpper
            Me.Grid.DataSource = Me.oVenta.ObtenerDetalleCambiarCosto
            Me.dpFecha.Value = CDate(Me.oVenta.FECHA)

            Me.FormateaGrid()

        End If

        Consultar = True

        Me.GestionaCambioEstado()

        Me.txtFolio.Enabled = False

    End Function

#End Region

    Private Sub txtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFolio.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
buscar:
                Me.txtFolio.Text = Me.oVenta.BusquedaVisual_PorFolio
            Case Keys.Enter
                Me.oVenta = New Class_Ventas_Global(Me.txtFolio.Text)
                If Me.oVenta.Existe = True Then
                    If Consultar() = False Then
                        Me.cboTipoNegociacion.Focus()
                    End If
                Else
                    GoTo buscar
                End If

        End Select
    End Sub
End Class