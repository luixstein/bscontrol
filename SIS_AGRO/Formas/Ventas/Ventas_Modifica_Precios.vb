Option Strict On

Public Class Ventas_Modifica_Precios
    Private oVenta As New Class_Ventas_Global
    Private oCliente As New Class_CatClientes

    Private igyCodigo As Short = 1
    Private igyDescripcion As Short = 2
    Private igyCantidad As Short = 3
    Private igyPrecio As Short = 4
    Private igyUnidad As Short = 5
    Private igyImpuestoPorcentaje As Short = 6
    Private igyImporte As Short = 7
    Private igyCuentaContable As Short = 8
    Private igyImpuestoImporte As Short = 9
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
            Me.Consultar()
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
            'Me.chkImprimirDolares.Checked = False

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
        Me.Grid.Column(Me.igyPrecio).Width = 100
        Me.Grid.Column(Me.igyUnidad).Width = 75
        Me.Grid.Column(Me.igyImpuestoPorcentaje).Width = 70
        Me.Grid.Column(Me.igyImporte).Width = 100
        Me.Grid.Column(Me.igyCuentaContable).Width = 100
        Me.Grid.Column(Me.igyImpuestoImporte).Width = 100
        Me.Grid.Column(Me.igyIdArticulo).Width = 100

        Me.Grid.Cell(0, Me.igyCodigo).Text = "Código"
        Me.Grid.Cell(0, Me.igyDescripcion).Text = "Descripción"
        Me.Grid.Cell(0, Me.igyCantidad).Text = "Cantidad"
        Me.Grid.Cell(0, Me.igyPrecio).Text = "Precio"
        Me.Grid.Cell(0, Me.igyUnidad).Text = "Unidad"
        Me.Grid.Cell(0, Me.igyImpuestoPorcentaje).Text = "IVA %"
        Me.Grid.Cell(0, Me.igyImporte).Text = "Importe"
        Me.Grid.Cell(0, Me.igyCuentaContable).Text = "Cuenta Contable"
        Me.Grid.Cell(0, Me.igyImpuestoImporte).Text = "IVA"
        Me.Grid.Cell(0, Me.igyIdArticulo).Text = "Id Articulo"

        Me.Grid.Column(Me.igyCantidad).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyCantidad).DecimalLength = Empresa_Sistema.DECIMALES_CANTIDAD
        Me.Grid.Column(Me.igyCantidad).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyPrecio).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_PRECIO)
        Me.Grid.Column(Me.igyPrecio).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyPrecio).DecimalLength = Empresa_Sistema.DECIMALES_PRECIO
        Me.Grid.Column(Me.igyPrecio).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImpuestoPorcentaje).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImpuestoPorcentaje).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImpuestoPorcentaje).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImporte).FormatString = "$ ###,###,##0." & CerosEnCadena(Empresa_Sistema.DECIMALES_CONTABILIDAD)
        Me.Grid.Column(Me.igyImporte).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyCuentaContable).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyImpuestoImporte).Mask = FlexCell.MaskEnum.Numeric
        Me.Grid.Column(Me.igyImpuestoImporte).DecimalLength = Empresa_Sistema.DECIMALES_CONTABILIDAD
        Me.Grid.Column(Me.igyImpuestoImporte).Alignment = FlexCell.AlignmentEnum.RightCenter

        Me.Grid.Column(Me.igyIdArticulo).Mask = FlexCell.MaskEnum.Numeric

        Me.Grid.Column(Me.igyImpuestoImporte).Visible = False
        Me.Grid.Column(Me.igyIdArticulo).Visible = False
        Me.Grid.Column(Me.igyCuentaContable).Visible = False

        Me.Grid.Column(Me.igyCodigo).Locked = True
        Me.Grid.Column(Me.igyDescripcion).Locked = True
        Me.Grid.Column(Me.igyCantidad).Locked = True
        Me.Grid.Column(Me.igyPrecio).Locked = False
        Me.Grid.Column(Me.igyUnidad).Locked = True
        Me.Grid.Column(Me.igyImpuestoPorcentaje).Locked = True
        Me.Grid.Column(Me.igyImporte).Locked = True
        Me.Grid.Column(Me.igyCuentaContable).Locked = True
        Me.Grid.Column(Me.igyImpuestoImporte).Locked = True
        Me.Grid.Column(Me.igyIdArticulo).Locked = True
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
                Me.Grid.Locked = False

                Me.tsslEstado.Text = "Estado: Consultando movimiento"
                Me.tsslElaboro.Visible = True : Me.tsslElaboro.Text = "Elaboró: " + Me.oVenta.NOMBRE_USUARIO.ToUpper + " el " + Format(Me.dpFecha.Value, "dd/MMM/yy").ToUpper
                Me.tsslCancelo.Visible = False : Me.tsslCancelo.Text = ""

        End Select

        Application.DoEvents()
    End Sub

    Function Grabar() As Boolean
        Dim i As Integer
        Try
            If MsgBox("Deseas grabar la remision con el folio : " & Me.txtFolio.Text & " ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Grabar") = MsgBoxResult.No Then
                Exit Function
            End If

            If SiTieneImporte() = False Then
                MsgBox("El importe en los renglones debe de ser mayor a 0", MsgBoxStyle.Exclamation)
                Exit Function
            End If

            Totales()

            With Me.oVenta
                'se graba el detalle
                For i = 1 To Me.Grid.Rows - 2
                    .NuevoRenglon()
                    .oVentasDetalle.FOLIO_VENTA = Me.oVenta.FOLIO_VENTA.ToUpper
                    .oVentasDetalle.ID_VENTA_DETALLE = CInt(Me.Grid.Cell(i, Me.igyIdArticulo).Text)
                    .oVentasDetalle.PRECIO_NUEVO = valorNumerico(Me.Grid.Cell(i, Me.igyPrecio).Text)
                    .oVentasDetalle.IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text)
                    .oVentasDetalle.IMPUESTO_IMPORTE = valorNumerico(Me.Grid.Cell(i, Me.igyImpuestoImporte).Text)

                    If .oVentasDetalle.ActualizaPrecioRemision = False Then
                        MsgBox("Error al tratar de actualizar el precio de los renglones.", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Function
                    End If
                Next

                If .ActualizaPrecioTotalGlobal = False Then
                    MsgBox("Error al tratar de actualizar el total de la factura.", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Function
                End If

                Grabar = True
                MsgBox("Remision grabada satisfactoriamente.", MsgBoxStyle.Information, Me.Text)
            End With
        Catch ex As Exception
            HandleError(Me.Name, "Grabar", ex)
        End Try
    End Function

    Private Function SiTieneImporte() As Boolean
        Dim i As Integer
        For i = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(i, Me.igyCodigo).Text) = True Then
                If valorNumerico(Me.Grid.Cell(i, Me.igyImporte).Text) = 0 Then
                    SiTieneImporte = False
                    Exit Function
                End If
            End If
        Next
        SiTieneImporte = True
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
        Dim I As Integer
        Dim dCantidad As Double, dPrecio As Double, dPorcentajeIVA As Double, dImporte As Double
        For I = 1 To Me.Grid.Rows - 1
            If txtLEN(Me.Grid.Cell(I, Me.igyCantidad).Text) = True Then
                dCantidad = valorNumerico(Me.Grid.Cell(I, Me.igyCantidad).Text)
                dPrecio = valorNumerico(Me.Grid.Cell(I, Me.igyPrecio).Text)
                dPorcentajeIVA = valorNumerico(Me.Grid.Cell(I, Me.igyImpuestoPorcentaje).Text)
                If dCantidad > 0 Then
                    dImporte = Redondear((dPrecio * dCantidad), Empresa_Sistema.DECIMALES_CONTABILIDAD)
                    Me.Grid.Cell(I, Me.igyImporte).Text = dImporte.ToString
                    Me.Grid.Cell(I, Me.igyImpuestoImporte).Text = Redondear(dImporte * ((dPorcentajeIVA / 100)), Empresa_Sistema.DECIMALES_CONTABILIDAD).ToString
                Else
                    Me.Grid.Cell(I, Me.igyImporte).Text = "0"
                    Me.Grid.Cell(I, Me.igyImpuestoImporte).Text = "0"
                End If
            End If
        Next I

        Me.lblSaldo.Text = FormatImporteContable(valorNumerico(Me.lblSaldo.Text))
        Me.lblSubtotal.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Me.lblImpuesto.Text = FormatImporteContable(Redondear(FG_Grid_SumaCol(Me.Grid, Me.igyImpuestoImporte), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        Me.lblTotal.Text = FormatImporteContable((valorNumerico(Me.lblSubtotal.Text) + valorNumerico(Me.lblImpuesto.Text)))

        If valorNumerico(Me.txtTipoCambio.Text) > 0 Then
            Me.lblSubtotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblSubtotal.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Me.lblImpuestoDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblImpuesto.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))
            Me.lblTotalDolares.Text = FormatImporteContable(Redondear(valorNumerico(Me.lblTotal.Text) / valorNumerico(Me.txtTipoCambio.Text), Empresa_Sistema.DECIMALES_CONTABILIDAD))
        End If

    End Sub

    Private Sub GestionaGrid(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim Columna As Integer, Renglon As Integer
        Dim StrCod As String, dCantidad As Double, dPrecio As Double

        Columna = Me.Grid.Selection.FirstCol
        Renglon = Me.Grid.Selection.FirstRow
        StrCod = Me.Grid.Cell(Renglon, Me.igyCodigo).Text
        dCantidad = valorNumerico(Me.Grid.Cell(Renglon, Me.igyCantidad).Text)
        dPrecio = valorNumerico(Me.Grid.Cell(Renglon, Me.igyPrecio).Text)

        If Columna <> igyPrecio Then
            Exit Sub
        End If

        Select Case e.KeyCode
            Case Keys.Enter
                If Columna = Me.igyPrecio Then
                    If dPrecio <= 0 Then
                        MsgBox("El precio debe de ser mayor a 0.", MsgBoxStyle.Exclamation, Me.Text)
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
            Me.Grid.DataSource = Me.oVenta.ObtenerDetalle
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
                Me.txtFolio.Text = Me.oVenta.BusquedaVisual_Remiciones_PorCodigo
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